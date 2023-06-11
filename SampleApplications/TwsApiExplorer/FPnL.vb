' Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Public Class FPnL

    Public Property ReqId As Integer

    Public Property Account As String

    Public Property ModelCode As String

    Public Property ContractId As Integer

    Private Sub okButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        ReqId = If(String.IsNullOrWhiteSpace(ReqIdText.Text), 0, Integer.Parse(ReqIdText.Text))
        Account = AccountText.Text
        ModelCode = ModelCodeText.Text
        ContractId() = If(String.IsNullOrWhiteSpace(ConIdText.Text), 0, Integer.Parse(ConIdText.Text))

        DialogResult = DialogResult.OK

        Close()
    End Sub

    Private Sub cancelItButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        DialogResult = DialogResult.Cancel

        Close()
    End Sub
End Class