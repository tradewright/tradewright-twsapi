Imports TradeWright.Utilities.Logging

Friend Class SocketLogListener
    Implements ILogListener

    Private WithEvents Logger As TradeWright.Utilities.Logging.Logger

    Private mLogText As TextBox

    Friend Sub New(logText As TextBox)
        mLogText = logText
    End Sub

    Public Sub ILogListener_Initialise(logger As TradeWright.Utilities.Logging.Logger, synchronized As Boolean) Implements ILogListener.Initialise
        Me.Logger = logger
    End Sub

    Private Sub logRecord(sender As Object, e As LogRecordEventArgs) Handles Logger.LogRecord
        mLogText.AppendText($"{e.LogRecord.Timestamp.ToString("yyyyMMdd HH:mm:ss.fff")}  {e.LogRecord.Data.ToString}{Environment.NewLine}")
    End Sub

#Region "IDisposable Support"
    Private isDisposed As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not isDisposed Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        isDisposed = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub

#End Region


End Class
