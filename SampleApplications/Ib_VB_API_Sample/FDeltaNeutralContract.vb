' Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Windows.Forms
Imports TradeWright.IBAPI

Public Class FDeltaNeutralContract

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private mDeltaNeutralContract As DeltaNeutralContract

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub Init(deltaNeutralContract As DeltaNeutralContract)

        mDeltaNeutralContract = deltaNeutralContract

        With deltaNeutralContract
            ConIdText.Text = .ConId
            DeltaText.Text = .Delta
            PriceText.Text = .Price
        End With

    End Sub

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As System.Object, e As System.EventArgs) Handles OkButton.Click

        With mDeltaNeutralContract
            .ConId = ConIdText.Text
            .Delta = DeltaText.Text
            .Price = PriceText.Text
        End With

        mDeltaNeutralContract = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub resetButton_Click(sender As System.Object, e As System.EventArgs) Handles ResetButton.Click

        With mDeltaNeutralContract
            .ConId = 0
            .Delta = 0
            .Price = 0
        End With

        mDeltaNeutralContract = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.Close()

    End Sub

    Private Sub cancelButton_Click(sender As System.Object, e As System.EventArgs) Handles CancelItButton.Click

        mDeltaNeutralContract = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

End Class
