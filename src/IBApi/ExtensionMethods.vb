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
    Friend Function CreateMessageGenerator(socketHandler As SocketHandler, useV100Plus As Boolean) As MessageGenerator
        Return New MessageGenerator(socketHandler.SocketManager, useV100Plus, SocketLogger.IsLoggable(ILogger.LogLevel.Detail))
    End Function

    <Extension()>
    Friend Sub LogSocketInputMessage(reader As MessageReader, moduleName As String, procName As String, Optional pIgnoreLogLevel As Boolean = False)
        If pIgnoreLogLevel Then
            EventLogger.Log(reader.Message, moduleName, procName, ILogger.LogLevel.Normal)
        ElseIf EventLogger.IsLoggable(ILogger.LogLevel.HighDetail) Then
            EventLogger.Log(reader.Message, moduleName, procName, ILogger.LogLevel.HighDetail)
        End If
    End Sub

    <Extension()>
    Friend Sub LogSocketOutputMessage(messageWriter As MessageGenerator, moduleName As String, procName As String, Optional ignoreLogLevel As Boolean = False)
        If ignoreLogLevel Then
            SocketLogger.Log(messageWriter.MessageAsStructuredString, moduleName, procName)
        ElseIf SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Then
            SocketLogger.Log(messageWriter.MessageAsStructuredString, moduleName, procName, ILogger.LogLevel.Detail)
        End If
        If SocketLogger.IsLoggable(ILogger.LogLevel.HighDetail) Then
            SocketLogger.Log(messageWriter.MessageAsPrintableBytes, moduleName, procName, ILogger.LogLevel.HighDetail)
        End If
    End Sub

    <Extension()>
    Friend Sub SendMessage(writer As MessageGenerator, moduleName As String, procName As String, Optional ignoreLogLevel As Boolean = False)
        writer.Send()
        writer.LogSocketOutputMessage(moduleName, procName, ignoreLogLevel)
    End Sub

End Module
