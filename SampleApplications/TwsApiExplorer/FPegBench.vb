Imports TradeWright.IBAPI

Public Class FPegBench

    Private ReadOnly mOrder As Order

    Sub New(order As Order)
        ' This is required by the designer.
        initializeComponent()

        Me.mOrder = order
        PeggedChangeAmountText.Text = order.PeggedChangeAmount.NullableDoubleToString
        ReferenceChangeAmountText.Text = order.ReferenceChangeAmount.NullableDoubleToString
        StartingPriceText.Text = order.StartingPrice.NullableDoubleToString
        StartingReferencePriceText.Text = order.StockReferencePrice.NullableDoubleToString
        PeggedChangeTypeCheck.SelectedIndex = If(order.IsPeggedChangeAmountDecrease, 1, 0)
        ReferenceContractIdText.Text = order.ReferenceContractId.ToString
        ReferenceContractExchangeText.Text = order.ReferenceExchange
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        mOrder.StartingPrice = IBAPI.NullableDoubleFromString(StartingPriceText.Text)
        mOrder.StockReferencePrice = IBAPI.NullableDoubleFromString(StartingReferencePriceText.Text)
        mOrder.PeggedChangeAmount = IBAPI.NullableDoubleFromString(PeggedChangeAmountText.Text)
        mOrder.IsPeggedChangeAmountDecrease = (PeggedChangeTypeCheck.SelectedIndex = 1)
        mOrder.ReferenceChangeAmount = IBAPI.NullableDoubleFromString(ReferenceChangeAmountText.Text)
        mOrder.ReferenceContractId = CInt(ReferenceContractIdText.Text)
        mOrder.ReferenceExchange = ReferenceContractExchangeText.Text

        Close()
    End Sub

    Private Sub CanceItButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        Close()
    End Sub
End Class