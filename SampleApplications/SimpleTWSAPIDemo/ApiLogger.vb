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

Imports TradeWright.IBAPI
Imports TradeWright.Utilities.Logging

Public Class ApiLogger
    Implements ILogger

    Private mBaseLogger As FormattingLogger

    Public Sub New(baseLogger As FormattingLogger)
        mBaseLogger = baseLogger
    End Sub

    Private Function ILogger_IsLoggable(logLevel As ILogger.LogLevel) As Boolean Implements ILogger.IsLoggable
        Return mBaseLogger.IsLoggable(translateLogLevel(logLevel))
    End Function

    Public Sub Log(message As String, Optional moduleName As String = Nothing, Optional procName As String = Nothing, Optional pLogLevel As ILogger.LogLevel = ILogger.LogLevel.Normal) Implements ILogger.Log
        mBaseLogger.Log(message, moduleName, procName, translateLogLevel(pLogLevel))
    End Sub

    Private Function translateLogLevel(level As ILogger.LogLevel) As LogLevel
        Select Case level
            Case ILogger.LogLevel.None
                Return LogLevel.None
            Case ILogger.LogLevel.Severe
                Return LogLevel.Severe
            Case ILogger.LogLevel.Warning
                Return LogLevel.Warning
            Case ILogger.LogLevel.Info
                Return LogLevel.Info
            Case ILogger.LogLevel.Normal
                Return LogLevel.Normal
            Case ILogger.LogLevel.Detail
                Return LogLevel.Detail
            Case ILogger.LogLevel.HighDetail
                Return LogLevel.HighDetail
        End Select
        Return LogLevel.Normal
    End Function

End Class
