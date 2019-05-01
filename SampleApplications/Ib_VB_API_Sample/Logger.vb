' Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

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
        If mBaseLogger IsNot Nothing Then Return mBaseLogger.IsLoggable(translateLogLevel(logLevel))
        Return mBaseFormattingLogger.IsLoggable(translateLogLevel(logLevel))
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
