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

Imports System.Runtime.CompilerServices

Module ExtensionMethods

    <Extension()>
    Friend Function CreateMessageGenerator(socketHandler As SocketHandler, useV100Plus As Boolean, generateSocketDataEvents As Boolean) As MessageGenerator
        Return New MessageGenerator(socketHandler.SocketManager, useV100Plus, IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail), generateSocketDataEvents)
    End Function

    <Extension()>
    Friend Sub LogSocketInputMessage(reader As MessageReader, socketDataConsumer As ISocketDataConsumer, Optional pIgnoreLogLevel As Boolean = False)
        Dim s = ""
        If pIgnoreLogLevel Or IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Or
            (socketDataConsumer IsNot Nothing And reader.GenerateSocketDataEvents) Then
            s = reader.Message
        End If

        If pIgnoreLogLevel Then
            IBAPI.SocketLogger.Log(s, pLogLevel:=ILogger.LogLevel.Normal)
        ElseIf IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Then
            IBAPI.SocketLogger.Log(s, pLogLevel:=ILogger.LogLevel.Detail)
        End If

        If reader.GenerateSocketDataEvents Then socketDataConsumer?.NotifySocketInputMessage(New ApiMessageEventArgs(s))
    End Sub

    <Extension()>
    Friend Sub LogSocketOutputMessage(messageWriter As MessageGenerator, socketDataConsumer As ISocketDataConsumer, Optional ignoreLogLevel As Boolean = False)
        If ignoreLogLevel Then
            IBAPI.SocketLogger.Log(messageWriter.MessageAsStructuredString)
        ElseIf IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Then
            IBAPI.SocketLogger.Log(messageWriter.MessageAsStructuredString, pLogLevel:=ILogger.LogLevel.Detail)
        End If

        If messageWriter.GenerateSocketDataEvents Then socketDataConsumer?.NotifySocketOutputMessage(New ApiMessageEventArgs(messageWriter.MessageAsStructuredString))

        Dim s = ""
        If IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.HighDetail) Or
            (messageWriter.GenerateSocketDataEvents And socketDataConsumer IsNot Nothing) Then
            s = messageWriter.MessageAsPrintableBytes
        End If
        If IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.HighDetail) Then IBAPI.SocketLogger.Log(s, pLogLevel:=ILogger.LogLevel.HighDetail)
        If messageWriter.GenerateSocketDataEvents Then socketDataConsumer?.NotifySocketOutputData(New SocketDataEventArgs(s))
    End Sub

    <Extension()>
    Friend Sub SendMessage(writer As MessageGenerator, socketDataConsumer As ISocketDataConsumer, Optional ignoreLogLevel As Boolean = False)
        writer.Send()
        writer.LogSocketOutputMessage(socketDataConsumer, ignoreLogLevel)
    End Sub

End Module
