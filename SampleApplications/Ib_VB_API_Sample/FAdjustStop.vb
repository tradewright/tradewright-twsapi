Imports TradeWright.IBAPI

Public Class FAdjustStop

    Private mOrder As Order

    Sub New(order As Order)
        initializeComponent()

        Me.mOrder = order
        'cbAdjustedOrderType.Text = order.AdjustedOrderType
        'tbTriggerPrice.Text = Util.DoubleMaxString(order.TriggerPrice)
        'tbAdjustedStopPrice.Text = Util.DoubleMaxString(order.AdjustedStopPrice)
        'tbAdjustedStopLimitPrice.Text = Util.DoubleMaxString(order.AdjustedStopLimitPrice)
        'tbAdjustedTrailingAmnt.Text = Util.DoubleMaxString(order.AdjustedTrailingAmount)
        'cbAdjustedTrailingAmntUnit.SelectedIndex = order.AdjustableTrailingUnit
    End Sub

    'private sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
    '    mOrder.AdjustedOrderType = cbAdjustedOrderType.Text
    '    mOrder.TriggerPrice = Utils.StringToDouble(tbTriggerPrice.Text)
    '    mOrder.AdjustedStopPrice = Utils.StringToDouble(tbAdjustedStopPrice.Text)
    '    mOrder.AdjustedStopLimitPrice = Utils.StringToDouble(tbAdjustedStopLimitPrice.Text)
    '    mOrder.AdjustedTrailingAmount = Utils.StringToDouble(tbAdjustedTrailingAmnt.Text)
    '    mOrder.AdjustableTrailingUnit = cbAdjustedTrailingAmntUnit.SelectedIndex

    '    Close()
    'End Sub

    'private sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    Close()
    'End Sub
End Class