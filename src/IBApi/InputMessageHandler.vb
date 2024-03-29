#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2018 Richard L King (TradeWright Software Systems)
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

#End Region

Imports System.Threading

Friend Class InputMessageHandler

    ''
    ' Description here
    '
    '@/

    '@================================================================================
    ' Interfaces
    '@================================================================================

    '@================================================================================
    ' Events
    '@================================================================================

    '@================================================================================
    ' Enums
    '@================================================================================

    '@================================================================================
    ' Types
    '@================================================================================

    '@================================================================================
    ' Constants
    '@================================================================================

    Private Const ModuleName As String = NameOf(InputMessageHandler)

    '@================================================================================
    ' Member variables
    '@================================================================================

    Private ReadOnly mEventConsumers As ApiEventConsumers

    Private ReadOnly mRegistry As GeneratorAndParserRegistry

    Private mReader As MessageReader

    Private mApiConnectionEstablished As Boolean

    Private mStatsRecorder As PerformanceStatsRecorder

    Private mServerVersion As Integer

    Private ReadOnly mGenerateSocketDataEvents As Boolean

    '@================================================================================
    ' Class Event Handlers
    '@================================================================================

    Friend Sub New(eventConsumers As ApiEventConsumers, registry As GeneratorAndParserRegistry, generateSocketDataEvents As Boolean)
        mEventConsumers = eventConsumers
        mRegistry = registry
        mGenerateSocketDataEvents = generateSocketDataEvents
    End Sub

    '@================================================================================
    ' XXXX Interface Members
    '@================================================================================

    '@================================================================================
    ' Properties
    '@================================================================================

    '@================================================================================
    ' Methods
    '@================================================================================

    Friend Sub Initialise(pReader As MessageReader, pStatsRecorder As PerformanceStatsRecorder)
        mReader = pReader
        mStatsRecorder = pStatsRecorder
        mApiConnectionEstablished = False
        getElapsedTimer()

        If IBAPI.SocketLogger?.IsLoggable(ILogger.LogLevel.Detail) Or
            (mGenerateSocketDataEvents And mEventConsumers.SocketDataConsumer IsNot Nothing) Then
            mReader.NewDataCallback = Sub()
                                          Dim s = getBuffer("In buf: ")
                                          IBAPI.SocketLogger?.Log(s, ModuleName, "NewDataCallback", ILogger.LogLevel.HighDetail)
                                          mEventConsumers.SocketDataConsumer?.NotifySocketInputData(New SocketDataEventArgs(s))
                                      End Sub
        End If
    End Sub

    Friend Sub LogSocketInputMessage()
        mReader.LogSocketInputMessage(mEventConsumers.SocketDataConsumer)
    End Sub

    Friend Sub Reset()
        mApiConnectionEstablished = False
    End Sub

    Friend Sub Start(serverVersion As Integer, scheduler As TaskScheduler, cancellationSource As CancellationTokenSource, closeSocket As Action)
        Const ProcName As String = NameOf(Start)

        mServerVersion = serverVersion

        Dim token = cancellationSource.Token
        Dim t As Task
        t = New Task(Async Sub()
                         Dim terminationReason = ""
                         Try
                             mStatsRecorder.StartRecording()
                             While (Not token.IsCancellationRequested And Await processNextMessageAsync())
                             End While

                             If token.IsCancellationRequested Then
                                 terminationReason = "cancellation"
                             Else
                                 terminationReason = "processing failure"
                             End If
                         Catch e As ApplicationException
                             ' these have already been notified to the application
                             terminationReason = "application failure"
                         Catch e As Exception
                             IBAPI.EventLogger.Log($"Exception in message processing loop{Environment.NewLine}{e}", ModuleName, ProcName, pLogLevel:=ILogger.LogLevel.Severe)
                             terminationReason = "exception"
                             mEventConsumers.ErrorAndNotificationConsumer?.NotifyException(New ExceptionEventArgs(Date.UtcNow, e))
                         Finally
                             IBAPI.EventLogger.Log($"Message processing terminated due to {terminationReason}", ModuleName, ProcName, pLogLevel:=ILogger.LogLevel.Severe)
                             System.Diagnostics.Debug.WriteLine("Reader finished")
                             closeSocket()
                             mStatsRecorder.StopRecording()
                         End Try
                     End Sub, token)
        t.Start(scheduler)
    End Sub

    '@================================================================================
    ' Helper Functions
    '@================================================================================

    Private Function getBuffer(pHeader As String) As String
        Dim s = ""

        mReader.ProcessLatestSocketData(Sub(b, i, l)
                                            s = System.Text.UnicodeEncoding.ASCII.GetString(b, i, l)
                                        End Sub)

        Return pHeader & s.Replace(ChrW(0), "_")
    End Function

    Private Function getElapsedTimer() As Stopwatch
        Static sElapsedTimer As Stopwatch
        If sElapsedTimer Is Nothing Then
            sElapsedTimer = New Stopwatch()
            sElapsedTimer.Start()
        End If
        getElapsedTimer = sElapsedTimer
    End Function

    Private Function getPerformanceTimer() As Stopwatch
        Static sPerformanceElapsedTimer As Stopwatch
        If sPerformanceElapsedTimer Is Nothing Then sPerformanceElapsedTimer = New Stopwatch
        Return sPerformanceElapsedTimer
    End Function

    Private Async Function handleMessageAsync(pMessageId As ApiSocketInMsgType, pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Const Procname As String = "handleMessageAsync"
        Try
            Await If(mRegistry.GetParser(pMessageId)?.ParseAsync(pVersion, timestamp), Task.CompletedTask)
            Return True
        Catch e As ApiException When e.ErrorCode = ErrorCodes.DataStreamEnded
            Return False
        Catch e As ApiApplicationException
            IBAPI.EventLogger.Log($"An exception occurred in the API user's application code while it was processing a callback: {IBAPI.ApiSocketInMsgTypes.ToExternalString(pMessageId)}{vbCrLf}{e}", NameOf(InputMessageHandler), Procname, ILogger.LogLevel.Severe)
            mEventConsumers.ErrorAndNotificationConsumer.NotifyException(New ExceptionEventArgs(Date.UtcNow, e))
            Return False
        End Try
    End Function

    Private Function messageHasVersion(messageId As ApiSocketInMsgType) As Boolean
        If messageId = ApiSocketInMsgType.ExecutionData And mServerVersion >= ApiServerVersion.LAST_LIQUIDITY Then Return False
        If messageId = ApiSocketInMsgType.HistoricalBar And mServerVersion >= ApiServerVersion.SYNT_REALTIME_BARS Then Return False
        If messageId = ApiSocketInMsgType.OrderStatus And mServerVersion >= ApiServerVersion.MARKET_CAP_PRICE Then Return False
        If messageId = ApiSocketInMsgType.OpenOrder And mServerVersion >= ApiServerVersion.ORDER_CONTAINER Then Return False
        If messageId = ApiSocketInMsgType.TickOptionComputation And mServerVersion >= ApiServerVersion.PRICE_BASED_VOLATILITY Then Return False
        If messageId = ApiSocketInMsgType.BondContractData And mServerVersion >= ApiServerVersion.SIZE_RULES Then Return False
        If messageId = ApiSocketInMsgType.ContractData And mServerVersion >= ApiServerVersion.SIZE_RULES Then Return False

        Return messageId <= ApiSocketInMsgType.MaxIdWithVersion
    End Function

    Private Async Function processNextMessageAsync() As Task(Of Boolean)
        Const ProcName = "processNextMessageAsync"

        Dim messageId As ApiSocketInMsgType
        Dim messageVersion = Integer.MaxValue
        Try
            Await mReader.BeginMessageAsync("IN: ", mGenerateSocketDataEvents)
            messageId = DirectCast(Await mReader.GetIntAsync("Msg id"), ApiSocketInMsgType)
            Dim timestamp = Date.UtcNow
            mReader.AppendToMessageString($" ({IBAPI.ApiSocketInMsgTypes.ToExternalString(messageId)}) ")

            If messageHasVersion(messageId) Then messageVersion = Await mReader.GetIntAsync("Version")

            getPerformanceTimer.Restart()
            If Not Await handleMessageAsync(messageId, messageVersion, timestamp) Then Return False
            updateStats(messageId, getPerformanceTimer.ElapsedTicks)
            mReader.EndMessage()
            Return True
        Catch e As ApiException When e.ErrorCode = ErrorCodes.DataStreamEnded
            Return False
        Catch e As Exception
            Dim s = ""
            mReader.ProcessCurrentProtocolMessage(Sub(b, i, c, l)
                                                      Dim buff = System.Text.UnicodeEncoding.ASCII.GetString(b, 0, l).Replace(ChrW(0), "_")
                                                      s = $"Error while processing input message:{Environment.NewLine}" &
                                                        $"Message ID={messageId} ({IBAPI.ApiSocketInMsgTypes.ToExternalString(messageId)}); version={messageVersion}{Environment.NewLine}" &
                                                        $"MessageStartindex={i}; InputBufferNextFreeIndex={l}; InputParseIndex={c}{Environment.NewLine}" &
                                                        $"Buffer contents:{Environment.NewLine}" &
                                                        $"{IBAPI.FormatBuffer(buff, l)}{Environment.NewLine}" &
                                                        $"{e}"
                                                  End Sub)

            IBAPI.EventLogger.Log(s, ModuleName, ProcName, pLogLevel:=ILogger.LogLevel.Severe)
            LogSocketInputMessage()

            Return False
        End Try
    End Function

    Private Sub updateStats(pMessageId As Integer, pMessageElapsedTime As Long)
        Const ProcName = NameOf(updateStats)
        Static sEventCount As Integer


        mStatsRecorder.UpdateMessageTypeStats(CType(pMessageId, ApiSocketInMsgType), pMessageElapsedTime)
        sEventCount += 1

        Dim secs = getElapsedTimer.ElapsedTicks / Stopwatch.Frequency
        If secs >= 10.0 Then
            Dim s = $"Event rate per second: {sEventCount / secs,0:0.0}"
            IBAPI.EventLogger.Log(s, ModuleName, ProcName, ILogger.LogLevel.Detail)
            Debug.Print(s)
            sEventCount = 0
            getElapsedTimer.Restart()
        End If
    End Sub
End Class