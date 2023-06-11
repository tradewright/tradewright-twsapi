' Copyright (C) 2022 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Public Class FWsh

    Public Property RequestId As Integer
    Public Property ContractId As Integer
    Public Property Filter As String
    Public Property FillWatchlist As Boolean
    Public Property FillPortfolio As Boolean
    Public Property FillCompetitors As Boolean
    Public Property StartDate As String
    Public Property EndDate As String
    Public Property TotalLimit As Integer


    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        RequestId = If(String.IsNullOrWhiteSpace(ReqIdText.Text), 0, Integer.Parse(ReqIdText.Text))
        ContractId = If(String.IsNullOrWhiteSpace(ConIdText.Text), Integer.MaxValue, Integer.Parse(ConIdText.Text))
        Filter = FilterText.Text
        FillWatchlist = FillWatchlistCheck.Checked
        FillPortfolio = FillPortfolioCheck.Checked
        FillCompetitors = FillCompetitorsCHeck.Checked
        StartDate = StartDateText.Text
        EndDate = EndDateText.Text
        TotalLimit = If(String.IsNullOrWhiteSpace(TotalLimitText.Text), Integer.MaxValue, Integer.Parse(TotalLimitText.Text))

        DialogResult = System.Windows.Forms.DialogResult.OK

        Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel

        Close()
    End Sub
End Class