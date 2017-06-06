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

Imports TradeWright.IBAPI.ApiException

Friend MustInherit Class GeneratorBase
    Implements IGenerator

    Protected mIdManager As IdManager
    Protected mEventConsumers As ApiEventConsumers

    Protected CreateOutputMessageGenerator As Func(Of MessageGenerator)
    Private mGetConnectionState As Func(Of ApiConnectionState)
    Private mGetServerVersion As Func(Of Integer)

    Friend MustOverride ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate

    Private Sub Initialise(idmanager As IdManager, eventConsumers As ApiEventConsumers, getServerVersion As Func(Of Integer), createOutputMessageGenerator As Func(Of MessageGenerator), getConnectionState As Func(Of ApiConnectionState)) Implements IGenerator.Initialise
        mIdManager = idmanager
        mEventConsumers = eventConsumers
        Me.mGetServerVersion = getServerVersion
        Me.CreateOutputMessageGenerator = createOutputMessageGenerator
        Me.mGetConnectionState = getConnectionState
    End Sub

    Private Sub SetRegistry(registry As GeneratorAndParserRegistry) Implements IGenerator.SetRegistry
        registry.RegisterGenerator(Me, MessageType)
    End Sub

    Private Shared Sub logSocketOutputMessage(messageWriter As MessageGenerator, moduleName As String, procName As String, Optional ignoreLogLevel As Boolean = False)
        If ignoreLogLevel Then
            SocketLogger.Log(messageWriter.MessageAsStructuredString, moduleName, procName)
        ElseIf SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Then
            SocketLogger.Log(messageWriter.MessageAsStructuredString, moduleName, procName, ILogger.LogLevel.Detail)
        End If
        If SocketLogger.IsLoggable(ILogger.LogLevel.HighDetail) Then
            SocketLogger.Log(messageWriter.MessageAsPrintableBytes, moduleName, procName, ILogger.LogLevel.HighDetail)
        End If
    End Sub

    Protected ReadOnly Property mConnectionState As ApiConnectionState
        Get
            Return mGetConnectionState()
        End Get
    End Property

    Protected ReadOnly Property ServerVersion As Integer
        Get
            Return mGetServerVersion()
        End Get
    End Property

    Protected Sub SendMessage(writer As MessageGenerator, moduleName As String, procName As String, Optional ignoreLogLevel As Boolean = False)
        writer.Send()
        logSocketOutputMessage(writer, moduleName, procName, ignoreLogLevel)
    End Sub

    Protected Shared Sub StartMessage(writer As MessageGenerator, msgId As ApiSocketOutMsgType)
        writer.StartMessage(msgId, ApiSocketOutMsgTypes.ToExternalString(msgId))
    End Sub

    Friend MustOverride ReadOnly Property MessageType As ApiSocketOutMsgType

End Class
