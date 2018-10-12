Imports TradeWright.IBAPI

Public Class FPegBench

    Private mOrder As Order

    Sub New(order As Order)
        ' This is required by the designer.
        initializeComponent()

        Me.mOrder = order
        tbPeggedChangeAmount.Text = IBAPI.NullableToString(order.PeggedChangeAmount)
        tbReferenceChangeAmount.Text = IBAPI.NullableToString(order.ReferenceChangeAmount)
        tbStartingPrice.Text = IBAPI.NullableToString(order.StartingPrice)
        tbStartingReferencePrice.Text = IBAPI.NullableToString(order.StockRefPrice)
        cbPeggedChangeType.SelectedIndex = If(order.IsPeggedChangeAmountDecrease, 1, 0)
        tbReferenceContractId.Text = order.ReferenceContractId
        tbReferenceContractExchange.Text = order.ReferenceExchange
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        mOrder.StartingPrice = IBAPI.NullableDoubleFromString(tbStartingPrice.Text)
        mOrder.StockRefPrice = IBAPI.NullableDoubleFromString(tbStartingReferencePrice.Text)
        mOrder.PeggedChangeAmount = IBAPI.NullableDoubleFromString(tbPeggedChangeAmount.Text)
        mOrder.IsPeggedChangeAmountDecrease = cbPeggedChangeType.SelectedIndex
        mOrder.ReferenceChangeAmount = IBAPI.NullableDoubleFromString(tbReferenceChangeAmount.Text)
        mOrder.ReferenceContractId = CInt(tbReferenceContractId.Text)
        mOrder.ReferenceExchange = tbReferenceContractExchange.Text

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class