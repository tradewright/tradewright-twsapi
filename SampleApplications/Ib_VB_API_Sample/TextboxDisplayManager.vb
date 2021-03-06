﻿Friend Class TextboxDisplayManager
    Implements IDisposable

    Private Const TimerInterval As Integer = 100
    Private ReadOnly mSb As New System.Text.StringBuilder()
    Private ReadOnly mTextBox As TextBoxBase
    Private WithEvents Timer As New System.Timers.Timer(TimerInterval)

    Friend Sub New(textBox As TextBoxBase)
        mTextBox = textBox
        Timer.SynchronizingObject = mTextBox
    End Sub

    Friend Sub Clear()
        mTextBox.Clear()
        mSb.Clear()
        Timer.Stop()
    End Sub

    Friend Sub DisplayMessage(message As String, Optional timestamp As Date = #1/1/0001 12:00:00 AM#)
        If timestamp <> Date.MinValue Then
            mSb.Append($"{timestamp:yyyyMMdd HH:mm:ss.fff}  ")
        End If
        mSb.Append(message)
        mSb.Append(Environment.NewLine)
        If Not Timer.Enabled Then Timer.Start()
    End Sub

    Private Sub mTimer_Tick(sender As Object, e As EventArgs) Handles Timer.Elapsed
        If mTextBox.IsDisposed Then Exit Sub
        mTextBox.AppendText(mSb.ToString())
        mSb.Clear()
        Timer.Stop()
    End Sub

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        Static isDisposed As Boolean ' To detect redundant calls
        If Not isDisposed Then
            If disposing Then
                Timer.Dispose()
            End If
        End If
        isDisposed = True
    End Sub

    Friend Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub

End Class
