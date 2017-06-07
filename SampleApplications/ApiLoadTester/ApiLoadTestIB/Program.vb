Imports ApiLoadTestUI

Module Program
    Private mController As ApiLoadTestIB
    Private mUi As UI

    <STAThread>
    Public Sub Main(args() As String)
        mUi = New UI()
        mController = New ApiLoadTestIB(mUi)
        mUi.Initialise(mController)
        Application.EnableVisualStyles()
        Application.Run(mUi)
    End Sub
End Module
