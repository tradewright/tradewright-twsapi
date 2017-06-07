' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports TradeWright.IBAPI

Imports System.Windows.Forms

Public Class dlgUnderComp

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private m_underComp As UnderComp

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub init(underComp As UnderComp)

        m_underComp = underComp

        With underComp
            txtConId.Text = .ConId
            txtDelta.Text = .Delta
            txtPrice.Text = .Price
        End With

    End Sub

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click

        With m_underComp
            .ConId = txtConId.Text
            .Delta = txtDelta.Text
            .Price = txtPrice.Text
        End With

        m_underComp = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub cmdReset_Click(sender As System.Object, e As System.EventArgs) Handles cmdReset.Click

        With m_underComp
            .ConId = 0
            .Delta = 0
            .Price = 0
        End With

        m_underComp = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click

        m_underComp = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

End Class
