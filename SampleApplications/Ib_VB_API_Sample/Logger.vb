Imports TradeWright.IBAPI
Imports TradeWright.Utilities.Logging

Friend Class Logger
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
        Return ILogger.LogLevel.Normal
    End Function

End Class