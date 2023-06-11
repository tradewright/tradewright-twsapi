' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports TradeWright.IBAPI

Imports System.Collections.Generic
Imports System.Linq

Class FAlgoParams

    Private mAlgoStrategy As String
    Private mAlgoParams As List(Of TagValue)

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property AlgoStrategy() As String
        Get
            AlgoStrategy = mAlgoStrategy
        End Get
    End Property

    Public ReadOnly Property AlgoParams() As TagValue()
        Get
            AlgoParams = mAlgoParams.ToArray()
        End Get
    End Property

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub Init(algoStrategy As String, algoParams() As TagValue)
        If (ParamsGrid.Items.Count = 0) Then
            ParamsGrid.Columns.AddRange(New ColumnHeader() {New ColumnHeader() With {.Text = "Param"}, New ColumnHeader() With {.Text = "Value"}})
        End If

        StrategyText.Text = algoStrategy

        If algoParams IsNot Nothing Then
            For Each param In algoParams
                ParamsGrid.Items.Add(New ListViewItem(New String() {param.Tag, param.Value}))
            Next
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================

    Private Sub oKButton_Click(sender As System.Object, e As System.EventArgs) Handles OkButton.Click
        mAlgoStrategy = StrategyText.Text

        If (mAlgoStrategy <> "") Then
            If ParamsGrid.Items.Count > 0 Then
                mAlgoParams = New List(Of TagValue)
                For Each row As ListViewItem In ParamsGrid.Items
                    mAlgoParams.Add(New TagValue() With
                                     {.Tag = row.SubItems(0).Text,
                                     .Value = row.SubItems(1).Text})
                Next
            End If
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cancelItButton_Click(sender As System.Object, e As System.EventArgs) Handles CancelItButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------
    ' Adds a param to the list
    '--------------------------------------------------------------------------------
    Private Sub addParamClickButton(sender As Object, e As System.EventArgs) Handles AddParamButton.Click
        Dim row = New String() {ParamText.Text, ValueText.Text}
        ParamsGrid.Items.Add(New ListViewItem(row))
    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a param from the list
    '--------------------------------------------------------------------------------
    Private Sub removeParamClickButton(sender As Object, e As System.EventArgs) Handles RemoveParamButton.Click
        ParamsGrid.SelectedItems.OfType(Of ListViewItem).ToList().ForEach(Sub(x) ParamsGrid.Items.Remove(x))
    End Sub

End Class
