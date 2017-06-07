Imports TradeWright.IBApi

Public Class dlgPegBench

    Dim order As Order

    Sub New(order As Order)
        ' This is required by the designer.
        InitializeComponent()

        Me.order = order
        tbPeggedChangeAmount.Text = NullableDoubleToString(order.PeggedChangeAmount)
        tbReferenceChangeAmount.Text = NullableDoubleToString(order.ReferenceChangeAmount)
        tbStartingPrice.Text = NullableDoubleToString(order.StartingPrice)
        tbStartingReferencePrice.Text = NullableDoubleToString(order.StockRefPrice)
        cbPeggedChangeType.SelectedIndex = If(order.IsPeggedChangeAmountDecrease, 1, 0)
        tbReferenceContractId.Text = order.ReferenceContractId
        tbReferenceContractExchange.Text = order.ReferenceExchange
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        order.StartingPrice = NullableDoubleFromString(tbStartingPrice.Text)
        order.StockRefPrice = NullableDoubleFromString(tbStartingReferencePrice.Text)
        order.PeggedChangeAmount = NullableDoubleFromString(tbPeggedChangeAmount.Text)
        order.IsPeggedChangeAmountDecrease = cbPeggedChangeType.SelectedIndex
        order.ReferenceChangeAmount = NullableDoubleFromString(tbReferenceChangeAmount.Text)
        order.ReferenceContractId = CInt(tbReferenceContractId.Text)
        order.ReferenceExchange = tbReferenceContractExchange.Text

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class