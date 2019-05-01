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

Public Class Logger
    Implements TradeWright.IBAPI.ILogger

    Private mBaseLogger As TradeWright.Utilities.Logging.Logger
    Private mBaseFormattingLogger As FormattingLogger

    Public Sub New(baseLogger As FormattingLogger)
        mBaseFormattingLogger = baseLogger
    End Sub

    Public Sub New(baseLogger As TradeWright.Utilities.Logging.Logger)
        mBaseLogger = baseLogger
    End Sub

    Private Function ILogger_IsLoggable(logLevel As TradeWright.IBAPI.ILogger.LogLevel) As Boolean Implements TradeWright.IBAPI.ILogger.IsLoggable
        Return mBaseLogger.IsLoggable(translateLogLevel(logLevel))
    End Function

    Public Sub Log(message As String,
                   Optional moduleName As String = Nothing,
                   Optional procName As String = Nothing,
                   Optional pLogLevel As TradeWright.IBAPI.ILogger.LogLevel = TradeWright.IBAPI.ILogger.LogLevel.Normal
                   ) Implements TradeWright.IBAPI.ILogger.Log
        If mBaseLogger IsNot Nothing Then
            mBaseLogger.Log(translateLogLevel(pLogLevel), message)
        Else
            mBaseFormattingLogger.Log(message, moduleName, procName, translateLogLevel(pLogLevel))
        End If
    End Sub

    Private Function translateLogLevel(level As TradeWright.IBAPI.ILogger.LogLevel) As TradeWright.Utilities.Logging.LogLevel
        Select Case level
            Case TradeWright.IBAPI.ILogger.LogLevel.None
                Return TradeWright.Utilities.Logging.LogLevel.None
            Case TradeWright.IBAPI.ILogger.LogLevel.Severe
                Return TradeWright.Utilities.Logging.LogLevel.Severe
            Case TradeWright.IBAPI.ILogger.LogLevel.Warning
                Return TradeWright.Utilities.Logging.LogLevel.Warning
            Case TradeWright.IBAPI.ILogger.LogLevel.Info
                Return TradeWright.Utilities.Logging.LogLevel.Info
            Case TradeWright.IBAPI.ILogger.LogLevel.Normal
                Return TradeWright.Utilities.Logging.LogLevel.Normal
            Case TradeWright.IBAPI.ILogger.LogLevel.Detail
                Return TradeWright.Utilities.Logging.LogLevel.Detail
            Case TradeWright.IBAPI.ILogger.LogLevel.HighDetail
                Return TradeWright.Utilities.Logging.LogLevel.HighDetail
        End Select
        Return TradeWright.Utilities.Logging.LogLevel.Normal
    End Function

End Class
