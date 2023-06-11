Imports TradeWright.IBAPI

Public Class FConditions

    Dim mOrder As Order
    Dim mBindingSource As New BindingSource

    Public Sub New(order As Order)
        ' This is required by the designer.
        InitializeComponent()

        Me.mOrder = order
        cancelOrder.SelectedIndex = If(order.ConditionsCancelOrder, 1, 0)
        ignoreRth.Checked = order.ConditionsIgnoreRth
        mBindingSource.DataSource = order.Conditions
        conditionList.AutoGenerateColumns = False
        conditionList.DataSource = mBindingSource
    End Sub

    Private Property SelectedCondition As OrderCondition
        Get
            If conditionList.SelectedCells.Count = 0 OrElse conditionList.SelectedCells(0).RowIndex = -1 Then
                Return Nothing
            End If

            Return DirectCast(mBindingSource(conditionList.SelectedCells(0).RowIndex), OrderCondition)
        End Get
        Set(value As OrderCondition)
            If conditionList.SelectedCells.Count > 0 AndAlso conditionList.SelectedCells(0).RowIndex <> -1 Then
                mBindingSource(conditionList.SelectedCells(0).RowIndex) = value
            End If
        End Set
    End Property

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        mOrder.ConditionsCancelOrder = CStr(cancelOrder.SelectedItem) = "Cancel order"
        mOrder.ConditionsIgnoreRth = ignoreRth.Checked
        mOrder.Conditions = DirectCast(mBindingSource.DataSource, List(Of OrderCondition))

        Close()
    End Sub

    Private Sub lbAddCondition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbAddCondition.LinkClicked
        Dim f As New FCondition(Nothing)

        If f.ShowDialog() = DialogResult.OK Then
            mBindingSource.Add(f.Condition)
        End If
    End Sub

    Private Sub lbRemoveCondition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbRemoveCondition.LinkClicked
        mBindingSource.Remove(SelectedCondition)
    End Sub

    Private Sub conditionList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles conditionList.CellFormatting
        If mBindingSource.Count <= e.RowIndex Then
            Return
        End If

        Dim obj As OrderCondition = DirectCast(mBindingSource(e.RowIndex), OrderCondition)

        e.FormattingApplied = True


        Select Case e.ColumnIndex
            Case 0
                e.Value = obj.ToString()

            Case 1
                e.Value = If(obj.IsConjunctionConnection, "and", "or")

            Case Else
                e.FormattingApplied = False
        End Select
    End Sub

    Private Sub conditionList_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles conditionList.CellParsing
        If e.ColumnIndex = 0 Then
            e.ParsingApplied = False

            Return
        End If

        DirectCast(mBindingSource(e.RowIndex), OrderCondition).IsConjunctionConnection = e.Value.ToString().Equals("and", StringComparison.InvariantCultureIgnoreCase)
    End Sub

    Private Sub CancelItButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        Close()
    End Sub

    Private Sub conditionList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles conditionList.CellDoubleClick
        If e.ColumnIndex = 0 Then
            Dim f As New FCondition(SelectedCondition)

            If f.ShowDialog() = DialogResult.OK Then
                SelectedCondition = f.Condition
            End If
        End If
    End Sub
End Class