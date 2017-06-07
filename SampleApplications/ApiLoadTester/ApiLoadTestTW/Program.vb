Imports ApiLoadTestUI

Module Program
    Private mController As ApiLoadTestTW
    Private mUi As UI

    <STAThread>
    Public Sub Main(args() As String)
        mUi = New UI()
        mController = New ApiLoadTestTW(mUi)
        mUi.Initialise(mController)
        System.Windows.Forms.Application.EnableVisualStyles()
        System.Windows.Forms.Application.Run(mUi)
    End Sub
End Module
