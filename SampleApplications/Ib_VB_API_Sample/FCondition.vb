﻿Imports TradeWright.IBApi
Imports System.Collections.Generic
Imports System.Linq

Public Class FCondition
    Private mRadioMap As New Dictionary(Of RadioButton, Tuple(Of Panel, OrderConditionType))
    Private mRadioButtons As IEnumerable(Of RadioButton)

    Private mCondition As OrderCondition

    Public Property Condition As OrderCondition

    Private Sub fillOperator(op As ComboBox, condition As OperatorCondition)
        op.SelectedIndex = If(condition.IsMore, 1, 0)
    End Sub


    Private Sub fillFromVolumeCondition(volumeCondition As VolumeCondition)
        fillOperator(volumeOperator, volumeCondition)

        volumeConId.Text = volumeCondition.ConId
        volumeConExch.Text = volumeCondition.Exchange
        volume.Text = volumeCondition.Volume.ToString()
        volumeRb.Checked = True
    End Sub


    Private Sub fillFromTimeCondition(timeCondition As TimeCondition)
        fillOperator(timeOperator, timeCondition)

        time.Text = timeCondition.Time
        timeRb.Checked = True
    End Sub

    Private Sub fillFromPriceCondition(priceCondition As PriceCondition)
        fillOperator(priceOperator, priceCondition)

        price.Text = priceCondition.Price.ToString
        priceMethod.Text = IBAPI.TriggerMethods.ToExternalString(priceCondition.TriggerMethod)
        priceRb.Checked = True
        priceConId.Text = priceCondition.ConId
        priceConExch.Text = priceCondition.Exchange
    End Sub

    Private Sub fillFromPercentChangeCondition(percentChangeCondition As PercentChangeCondition)
        percent.Text = percentChangeCondition.ChangePercent.ToString()
        percentRb.Checked = True
        percentConId.Text = percentChangeCondition.ConId
        percentConExch.Text = percentChangeCondition.Exchange

        fillOperator(percentOperator, percentChangeCondition)
    End Sub

    Private Sub fillFromMarginCondition(marginCondition As MarginCondition)
        fillOperator(marginOperator, marginCondition)

        marginCushion.Text = marginCondition.Percent.ToString()
        marginRb.Checked = True
    End Sub

    Private Sub fillFromExecutionCondition(orderCondition As ExecutionCondition)
        tradeUnderlying.Text = orderCondition.Symbol
        tradeExchange.Text = orderCondition.Exchange
        tradeType.Text = orderCondition.SecType
        tradeRb.Checked = True
    End Sub

    Public Sub New(condition As OrderCondition)
        initializeComponent()

        mRadioMap(priceRb) = Tuple.Create(pricePanel, OrderConditionType.Price)
        mRadioMap(marginRb) = Tuple.Create(marginPanel, OrderConditionType.Margin)
        mRadioMap(tradeRb) = Tuple.Create(tradePanel, OrderConditionType.Execution)
        mRadioMap(timeRb) = Tuple.Create(timePanel, OrderConditionType.Time)
        mRadioMap(volumeRb) = Tuple.Create(volumePanel, OrderConditionType.Volume)
        mRadioMap(percentRb) = Tuple.Create(percentPanel, OrderConditionType.PercentChange)

        mRadioButtons = conditionTypePage.Controls.OfType(Of RadioButton).ToArray()
        Me.Condition = If(Not condition Is Nothing, condition, OrderCondition.Create(OrderConditionType.Price))
        priceMethod.Items.AddRange(IBAPI.TriggerMethods.ExternalNames.ToArray())


        tabControl1.TabPages.OfType(Of TabPage).Skip(2).ToList().ForEach(Sub(page) tabControl1.TabPages.Remove(page))

        Select Case Me.Condition.Type

            Case OrderConditionType.Execution
                fillFromExecutionCondition(Me.Condition)


            Case OrderConditionType.Margin
                fillFromMarginCondition(Me.Condition)


            Case OrderConditionType.PercentChange
                fillFromPercentChangeCondition(Me.Condition)


            Case OrderConditionType.Price
                fillFromPriceCondition(Me.Condition)


            Case OrderConditionType.Time
                fillFromTimeCondition(Me.Condition)


            Case OrderConditionType.Volume
                fillFromVolumeCondition(Me.Condition)

        End Select

        If Not condition Is Nothing Then
            tabControl1.TabPages.RemoveAt(0)

            back.Visible = False
            tabControl1.SelectedTab = conditionPage

            tabControl1_SelectedIndexChanged(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub nextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        tabControl1.SelectedTab = conditionPage
    End Sub

    Private Sub tabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl1.SelectedIndexChanged
        If Not tabControl1.SelectedTab Is conditionPage Then
            Return
        End If

        Dim panel = mRadioMap(mRadioButtons.FirstOrDefault(Function(rb) rb.Checked)).Item1

        conditionPanel.Controls.Clear()
        conditionPanel.Controls.Add(panel)
        panel.Controls.OfType(Of ComboBox).ToList().ForEach(Function(cb) cb.SelectedIndex = 0)
    End Sub

    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        tabControl1.SelectedTab = conditionTypePage
    End Sub

    Private Sub apply_Click(sender As Object, e As EventArgs) Handles apply.Click
        Dim type = mRadioMap(mRadioButtons.FirstOrDefault(Function(rb) rb.Checked)).Item2

        If type <> Condition.Type Then
            Condition = OrderCondition.Create(type)
        End If

        Select Case type
            Case OrderConditionType.Execution
                fillCondition(DirectCast(Condition, ExecutionCondition))

            Case OrderConditionType.Margin
                fillCondition(DirectCast(Condition, MarginCondition))

            Case OrderConditionType.PercentChange
                fillCondition(DirectCast(Condition, PercentChangeCondition))

            Case OrderConditionType.Price
                fillCondition(DirectCast(Condition, PriceCondition))

            Case OrderConditionType.Time
                fillCondition(DirectCast(Condition, TimeCondition))

            Case OrderConditionType.Volume
                fillCondition(DirectCast(Condition, VolumeCondition))
        End Select

        DialogResult = DialogResult.OK

        Close()
    End Sub

    Private Sub fillCondition(volumeCondition As VolumeCondition)
        fillOperator(volumeCondition, volumeOperator)

        volumeCondition.ConId = CInt(volumeConId.Text)
        volumeCondition.Exchange = volumeConExch.Text
        volumeCondition.Volume = CInt(volume.Text)
    End Sub

    Private Sub fillCondition(timeCondition As TimeCondition)
        fillOperator(timeCondition, timeOperator)

        timeCondition.Time = time.Text
    End Sub

    Private Sub fillCondition(priceCondition As PriceCondition)
        fillOperator(priceCondition, priceOperator)

        priceCondition.ConId = CInt(priceConId.Text)
        priceCondition.Exchange = priceConExch.Text
        priceCondition.TriggerMethod = IBAPI.TriggerMethods.Parse(priceMethod.Text)
        priceCondition.Price = CDbl(price.Text)
    End Sub

    Private Sub fillCondition(percentChangeCondition As PercentChangeCondition)
        fillOperator(percentChangeCondition, percentOperator)

        percentChangeCondition.ConId = CInt(percentConId.Text)
        percentChangeCondition.Exchange = percentConExch.Text
    End Sub

    Private Sub fillCondition(marginCondition As MarginCondition)
        fillOperator(marginCondition, marginOperator)

        marginCondition.Percent = CInt(marginCushion.Text)
    End Sub

    Private Sub fillCondition(executionCondition As ExecutionCondition)
        executionCondition.Symbol = tradeUnderlying.Text
        executionCondition.Exchange = tradeExchange.Text
        executionCondition.SecType = tradeType.Text
    End Sub

    Private Sub fillOperator(condition As OperatorCondition, op As ComboBox)
        condition.IsMore = op.SelectedIndex = 1
    End Sub

End Class