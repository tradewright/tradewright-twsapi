#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2017 Richard L King (TradeWright Software Systems)
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

Imports System.Collections.Generic
Imports System.Threading

Friend Class PerformanceStatsRecorder
    Implements IDisposable

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

    Private Const ModuleName As String = NameOf(PerformanceStatsRecorder)

    '@================================================================================
    ' Member variables
    '@================================================================================

    Private mPerformanceStats(ApiSocketInMsgType.Max) As StatisticsEntry

    Private WithEvents TimerSecond As Timer
    Private WithEvents TimerPeriod As Timer

    Private mEventConsumers As ApiEventConsumers

    '@================================================================================
    ' Class Event Handlers
    '@================================================================================

    Friend Sub New(eventConsumers As ApiEventConsumers)
        mEventConsumers = eventConsumers
    End Sub

    '@================================================================================
    ' XXXX Interface Members
    '@================================================================================

    '@================================================================================
    ' XXXX Event Handlers
    '@================================================================================

    '@================================================================================
    ' Properties
    '@================================================================================

    Friend ReadOnly Property StatisticsEntries As IEnumerable(Of StatisticsEntry)
        Get
            Return mPerformanceStats
        End Get
    End Property

    '@================================================================================
    ' Methods
    '@================================================================================

    Friend Sub AccumulateStats()
        For i = 0 To ApiSocketInMsgType.Max
            With mPerformanceStats(i)
                .LastPeriodCount += .LastSecondCount
                .LastPeriodTime += .LastSecondTime
                If .LastSecondCount > .MaxSecondCount Then .MaxSecondCount = .LastSecondCount
                .TotalCount = .LastSecondCount
                .TotalTime = .LastSecondTime
                .LastSecondCount = 0
                .LastSecondTime = 0
            End With
        Next
    End Sub

    Friend Sub StartRecording()
        initialise()
        createPerformanceLoggers()
    End Sub

    Friend Sub StopRecording()
        TimerSecond?.Dispose()
        TimerSecond = Nothing
        TimerPeriod?.Dispose()
        TimerPeriod = Nothing
    End Sub

    Friend Sub UpdateMessageTypeStats(pMessageId As ApiSocketInMsgType, pEt As Long)
        With mPerformanceStats(pMessageId)
            .LastSecondCount += 1
            .LastSecondTime += pEt
            If pEt > .LongestTime Then .LongestTime = pEt
            If pEt < .ShortestTime Or .ShortestTime = 0 Then .ShortestTime = pEt
        End With
    End Sub

    '@================================================================================
    ' Helper Functions
    '@================================================================================

    Private Sub createPerformanceLoggers()
        If TimerSecond Is Nothing Then
            TimerSecond = New Timer(Sub(o)
                                        AccumulateStats()
                                    End Sub,
                                                Nothing,
                                                New TimeSpan(0, 0, 0, 0, 1000 - System.DateTime.Now.Millisecond),
                                                New TimeSpan(0, 0, 0, 0, 1000))

            TimerPeriod = New Timer(Sub(o)
                                        generateStats()
                                    End Sub,
                                                Nothing,
                                                New TimeSpan(0, 0, 0, 59 - System.DateTime.Now.Second, 1000 - System.DateTime.Now.Millisecond),
                                                New TimeSpan(0, 0, 1, 0, 0))
        End If
    End Sub

    Private Sub generateStats()
        Dim lSb = New System.Text.StringBuilder("Message type          Last  Last avg    Total  Total avg Max/sec   Longest  Shortest" & vbCrLf)
        For i = 0 To ApiSocketInMsgType.Max
            With mPerformanceStats(i)
                .LastPeriodCount = .LastPeriodCount + .LastSecondCount
                .LastPeriodTime = .LastPeriodTime + .LastSecondTime
                .TotalCount = .TotalCount + .LastSecondCount
                .TotalTime = .TotalTime + .LastSecondTime

                If .TotalCount <> 0 Then
                    lSb.Append($"{IBAPI.ApiSocketInMsgTypes.ToExternalString(DirectCast(i, ApiSocketInMsgType)),-20}")
                    lSb.Append($"{ .LastPeriodCount,6:####0}")
                    If .LastPeriodCount <> 0 Then
                        lSb.Append($"{ .LastPeriodTime / .LastPeriodCount,10:######0.0}")
                    Else
                        lSb.Append("       0.0")
                    End If
                    lSb.Append($"{ .TotalCount,9:#######0}")
                    If .TotalCount <> 0 Then
                        lSb.Append($"{ .TotalTime / .TotalCount,11:######0.0}")
                    Else
                        lSb.Append("        0.0")
                    End If
                    lSb.Append($"{ .MaxSecondCount,8:###0}")
                    lSb.Append($"{ .LongestTime,10:######0.0}")
                    lSb.AppendLine($"{ .ShortestTime,10:######0.0}")
                End If

                .LastPeriodCount = 0
                .LastPeriodTime = 0
                .LastSecondCount = 0
                .LastSecondTime = 0
                .MaxSecondCount = 0
            End With
        Next

        Dim s = lSb.ToString
        IBAPI.PerformanceLogger.Log("Socket message statistics:" & vbCrLf & s)
        mEventConsumers.PerformanceDataConsumer?.NotifyPerformanceStats(New PerformanceStatsUpdateEventArgs(s))
    End Sub

    Private Sub initialise()
        For i = 0 To mPerformanceStats.Length - 1
            mPerformanceStats(i) = New StatisticsEntry With {
                .MessageId = CType(i, ApiSocketInMsgType)
            }
        Next
    End Sub

#Region "IDisposable Support"
    Private mDisposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not mDisposedValue Then
            If disposing Then
                TimerPeriod.Dispose()
                TimerSecond.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        mDisposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class