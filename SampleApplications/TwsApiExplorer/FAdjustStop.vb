Imports TradeWright.IBAPI

Public Class FAdjustStop

    Private mOrder As Order

    Sub New(order As Order)
        initializeComponent()

        Me.mOrder = order
        AdjustedOrderTypeCombo.Text = IBAPI.OrderTypes.ToExternalString(order.AdjustedOrderType)
        TriggerPriceText.Text = order.TriggerPrice.NullableDoubleToString
        AdjustedStopPriceText.Text = order.AdjustedStopPrice.NullableDoubleToString
        AdjustedStopLimitPriceText.Text = order.AdjustedStopLimitPrice.NullableDoubleToString
        AdjustedTrailingAmntText.Text = order.AdjustedTrailingAmount.NullableDoubleToString
        AdjustedTrailingAmntUnitCombo.SelectedIndex = order.AdjustableTrailingUnit
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        mOrder.AdjustedOrderType = IBAPI.OrderTypes.Parse(AdjustedOrderTypeCombo.Text)
        mOrder.TriggerPrice = TriggerPriceText.Text.NullableDoubleFromString
        mOrder.AdjustedStopPrice = AdjustedStopPriceText.Text.NullableDoubleFromString
        mOrder.AdjustedStopLimitPrice = AdjustedStopLimitPriceText.Text.NullableDoubleFromString
        mOrder.AdjustedTrailingAmount = AdjustedTrailingAmntText.Text.NullableDoubleFromString
        mOrder.AdjustableTrailingUnit = AdjustedTrailingAmntUnitCombo.SelectedIndex

        Close()
    End Sub

    Private Sub CancelItButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        Close()
    End Sub
End Class