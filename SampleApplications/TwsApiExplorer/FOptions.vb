' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports TradeWright.IBAPI

Imports System.Collections.Generic
Imports System.Linq

Class FOptions

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================

    Public ReadOnly Property Options() As List(Of TagValue) = New List(Of TagValue)

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub Init(options As List(Of TagValue), fTitle As String)

        Me.Text = fTitle

        If (ParamsGrid.Columns.Count = 0) Then
            ParamsGrid.Columns.AddRange(New ColumnHeader() {New ColumnHeader() With {.Text = "Param"}, New ColumnHeader() With {.Text = "Value"}})
        End If

        options = options

        If Not options Is Nothing Then
            For Each param In options
                ParamsGrid.Items.Add(New ListViewItem(New String() {param.Tag, param.Value}))
            Next
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================

    Private Sub oK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OkButton.Click
        Options.Clear()

        If (ParamsGrid.Items.Count > 0) Then

            For Each item As ListViewItem In ParamsGrid.Items
                Dim tag = item.SubItems(0).Text
                Dim value = item.SubItems(1).Text

                Options.Add(New TagValue() With {.Tag = tag, .Value = value})
            Next

        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles CancelItButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------
    ' Adds a param to the list
    '--------------------------------------------------------------------------------
    Private Sub addParamClickButton(sender As Object, e As System.EventArgs) Handles AddParamButton.Click

        ParamsGrid.Items.Add(New ListViewItem(New String() {ParamText.Text, ValueText.Text}))

    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a param from the list
    '--------------------------------------------------------------------------------
    Private Sub removeParamClickButton(sender As Object, e As System.EventArgs) Handles RemoveParamButton.Click

        ParamsGrid.SelectedItems.OfType(Of ListViewItem).ToList().ForEach(Sub(x) ParamsGrid.Items.Remove(x))

    End Sub

End Class
