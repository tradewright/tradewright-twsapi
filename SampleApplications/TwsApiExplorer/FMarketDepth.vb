﻿' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Imports TradeWright.IBAPI

Imports System.Collections.Generic

Friend Class FMarketDepth
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        initializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            If mComponents IsNot Nothing Then mComponents.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private mComponents As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DataGridViewBid As DataGridView
    Friend WithEvents DataGridViewAsk As DataGridView
    Friend WithEvents MarketMakerColBid As DataGridViewTextBoxColumn
    Friend WithEvents PriceColBid As DataGridViewTextBoxColumn
    Friend WithEvents SizeColBid As DataGridViewTextBoxColumn
    Friend WithEvents TotalSizeColBid As DataGridViewTextBoxColumn
    Friend WithEvents AvgPriceColBid As DataGridViewTextBoxColumn
    Friend WithEvents MarketMakerColAsk As DataGridViewTextBoxColumn
    Friend WithEvents PriceColAsk As DataGridViewTextBoxColumn
    Friend WithEvents SizeColAsk As DataGridViewTextBoxColumn
    Friend WithEvents TotalSizeColAsk As DataGridViewTextBoxColumn
    Friend WithEvents AvgPriceColAsk As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Public WithEvents Label2 As Label
    Friend WithEvents MarketMakerAsk As DataGridViewTextBoxColumn
    Friend WithEvents PriceAsk As DataGridViewTextBoxColumn
    Friend WithEvents SizeAsk As DataGridViewTextBoxColumn
    Friend WithEvents TotalSizeAsk As DataGridViewTextBoxColumn
    Friend WithEvents AvgPriceAsk As DataGridViewTextBoxColumn
    Friend WithEvents MarketMakerBid As DataGridViewTextBoxColumn
    Friend WithEvents PriceBid As DataGridViewTextBoxColumn
    Friend WithEvents SizeBid As DataGridViewTextBoxColumn
    Friend WithEvents TotalSizeBid As DataGridViewTextBoxColumn
    Friend WithEvents AvgPriceBid As DataGridViewTextBoxColumn
    Public WithEvents Label1 As Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.DataGridViewBid = New System.Windows.Forms.DataGridView()
        Me.MarketMakerBid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceBid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeBid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSizeBid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvgPriceBid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewAsk = New System.Windows.Forms.DataGridView()
        Me.MarketMakerAsk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceAsk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeAsk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSizeAsk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvgPriceAsk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewBid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewAsk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.BackColor = System.Drawing.SystemColors.Control
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CloseButton.Location = New System.Drawing.Point(886, 519)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CloseButton.Size = New System.Drawing.Size(81, 31)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'DataGridViewBid
        '
        Me.DataGridViewBid.AllowUserToAddRows = False
        Me.DataGridViewBid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridViewBid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewBid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewBid.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridViewBid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewBid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewBid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewBid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewBid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewBid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MarketMakerBid, Me.PriceBid, Me.SizeBid, Me.TotalSizeBid, Me.AvgPriceBid})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewBid.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewBid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewBid.EnableHeadersVisualStyles = False
        Me.DataGridViewBid.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridViewBid.Location = New System.Drawing.Point(3, 23)
        Me.DataGridViewBid.MultiSelect = False
        Me.DataGridViewBid.Name = "DataGridViewBid"
        Me.DataGridViewBid.ReadOnly = True
        Me.DataGridViewBid.RowHeadersVisible = False
        Me.DataGridViewBid.Size = New System.Drawing.Size(476, 480)
        Me.DataGridViewBid.TabIndex = 5
        '
        'MarketMakerBid
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.MarketMakerBid.DefaultCellStyle = DataGridViewCellStyle3
        Me.MarketMakerBid.HeaderText = "MM"
        Me.MarketMakerBid.Name = "MarketMakerBid"
        Me.MarketMakerBid.ReadOnly = True
        Me.MarketMakerBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PriceBid
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "0.00000"
        Me.PriceBid.DefaultCellStyle = DataGridViewCellStyle4
        Me.PriceBid.HeaderText = "Price"
        Me.PriceBid.Name = "PriceBid"
        Me.PriceBid.ReadOnly = True
        Me.PriceBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SizeBid
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SizeBid.DefaultCellStyle = DataGridViewCellStyle5
        Me.SizeBid.HeaderText = "Size"
        Me.SizeBid.Name = "SizeBid"
        Me.SizeBid.ReadOnly = True
        Me.SizeBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TotalSizeBid
        '
        Me.TotalSizeBid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotalSizeBid.DefaultCellStyle = DataGridViewCellStyle6
        Me.TotalSizeBid.HeaderText = "Cum. size"
        Me.TotalSizeBid.Name = "TotalSizeBid"
        Me.TotalSizeBid.ReadOnly = True
        Me.TotalSizeBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TotalSizeBid.Width = 58
        '
        'AvgPriceBid
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "0.000000"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.AvgPriceBid.DefaultCellStyle = DataGridViewCellStyle7
        Me.AvgPriceBid.HeaderText = "Avg price"
        Me.AvgPriceBid.Name = "AvgPriceBid"
        Me.AvgPriceBid.ReadOnly = True
        Me.AvgPriceBid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewAsk
        '
        Me.DataGridViewAsk.AllowUserToAddRows = False
        Me.DataGridViewAsk.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridViewAsk.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewAsk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewAsk.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridViewAsk.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewAsk.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewAsk.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAsk.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewAsk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewAsk.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MarketMakerAsk, Me.PriceAsk, Me.SizeAsk, Me.TotalSizeAsk, Me.AvgPriceAsk})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewAsk.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewAsk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewAsk.EnableHeadersVisualStyles = False
        Me.DataGridViewAsk.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridViewAsk.Location = New System.Drawing.Point(485, 23)
        Me.DataGridViewAsk.MultiSelect = False
        Me.DataGridViewAsk.Name = "DataGridViewAsk"
        Me.DataGridViewAsk.ReadOnly = True
        Me.DataGridViewAsk.RowHeadersVisible = False
        Me.DataGridViewAsk.Size = New System.Drawing.Size(476, 480)
        Me.DataGridViewAsk.TabIndex = 6
        '
        'MarketMakerAsk
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.MarketMakerAsk.DefaultCellStyle = DataGridViewCellStyle11
        Me.MarketMakerAsk.HeaderText = "MM"
        Me.MarketMakerAsk.Name = "MarketMakerAsk"
        Me.MarketMakerAsk.ReadOnly = True
        Me.MarketMakerAsk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PriceAsk
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "0.00000"
        Me.PriceAsk.DefaultCellStyle = DataGridViewCellStyle12
        Me.PriceAsk.HeaderText = "Price"
        Me.PriceAsk.Name = "PriceAsk"
        Me.PriceAsk.ReadOnly = True
        Me.PriceAsk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SizeAsk
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SizeAsk.DefaultCellStyle = DataGridViewCellStyle13
        Me.SizeAsk.HeaderText = "Size"
        Me.SizeAsk.Name = "SizeAsk"
        Me.SizeAsk.ReadOnly = True
        Me.SizeAsk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TotalSizeAsk
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotalSizeAsk.DefaultCellStyle = DataGridViewCellStyle14
        Me.TotalSizeAsk.HeaderText = "Cum. size"
        Me.TotalSizeAsk.Name = "TotalSizeAsk"
        Me.TotalSizeAsk.ReadOnly = True
        Me.TotalSizeAsk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AvgPriceAsk
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "0.000000"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.AvgPriceAsk.DefaultCellStyle = DataGridViewCellStyle15
        Me.AvgPriceAsk.HeaderText = "Avg price"
        Me.AvgPriceAsk.Name = "AvgPriceAsk"
        Me.AvgPriceAsk.ReadOnly = True
        Me.AvgPriceAsk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewAsk, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewBid, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 7)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 506)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(485, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Asks"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Bids"
        '
        'FMarketDepth
        '
        Me.AcceptButton = Me.CloseButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(979, 555)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.CloseButton)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(399, 416)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FMarketDepth"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Market Depth for: "
        CType(Me.DataGridViewBid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewAsk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

    '================================================================================
    ' Private Members
    '================================================================================

    Enum Cell
        MarketMaker
        Price
        Size
        CumSize
        AvgPrice
    End Enum

    ' types
    Private Class ModelEntry
        Friend MarketMaker As String
        Friend Price As Double
        Friend Size As Decimal
        Friend CumSize As Decimal
        Friend TotalPrice As Double
    End Class

    ' member variables
    Private mOk As Boolean = True

    Private mAsks As List(Of ModelEntry)

    Private mBids As List(Of ModelEntry)

    '================================================================================
    ' Button Events
    '================================================================================
    Private Sub CloseButton_Click(sender As Object, eventArgs As EventArgs) Handles CloseButton.Click
        mOk = False
        Me.Close()
    End Sub

    '================================================================================
    ' Public Methods
    ' ===============================================================================
    '--------------------------------------------------------------------------------
    ' Adds the market depth row to the book
    '--------------------------------------------------------------------------------
    Public Sub UpdateMktDepth(rowId As Integer, marketMaker As String, operation As DOMOperation, side As DOMSide, price As Double, Size As Decimal)
        If Not mOk Then Exit Sub

        Select Case side
            Case DOMSide.Bid
                updateDepth(mBids, DataGridViewBid, rowId, marketMaker, operation, price, Size)
            Case DOMSide.Ask
                updateDepth(mAsks, DataGridViewAsk, rowId, marketMaker, operation, price, Size)
            Case Else
                Throw New InvalidOperationException
        End Select

    End Sub

    '--------------------------------------------------------------------------------
    ' Flush the deep book
    '--------------------------------------------------------------------------------
    Public Sub Init(numberOfRows As Integer, contract As Contract)
        mAsks = New List(Of ModelEntry)(numberOfRows)
        mBids = New List(Of ModelEntry)(numberOfRows)

        ' flush the book entries
        Clear()

        Me.Text = $"Market Depth for: {getContractString(contract)}"
    End Sub

    Public Sub Clear()
        If Not mOk Then Exit Sub

        DataGridViewAsk.Rows.Clear()
        DataGridViewBid.Rows.Clear()
    End Sub

    Private Shared Function getContractString(contract As Contract) As String
        Dim contractString As String
        If Not String.IsNullOrEmpty(contract.LocalSymbol) Then
            contractString = contract.LocalSymbol
        Else
            contractString = contract.Symbol
            If Not String.IsNullOrEmpty(contract.Expiry) Then
                contractString += $" ({contract.Expiry})"
            End If
        End If

        If Not String.IsNullOrEmpty(contract.Exchange) Then
            contractString += $" @ {contract.Exchange}"
        End If

        Return contractString
    End Function


    Private Sub updateDepth(model As List(Of ModelEntry), bookEntries As DataGridView, rowId As Integer, marketMaker As String, operation As DOMOperation, price As Double, Size As Decimal)
        Select Case operation
            Case DOMOperation.Insert
                model.Insert(rowId, New ModelEntry() With {.MarketMaker = marketMaker, .Price = price, .Size = Size})
            Case DOMOperation.Update
                With model(rowId)
                    .MarketMaker = marketMaker
                    .Price = price
                    .Size = Size
                End With
            Case DOMOperation.Delete
                If rowId < model.Count Then model.RemoveAt(rowId)
        End Select

        ' recalc only the average cost and cumulative sizes that could have changed
        updateList(model, bookEntries, rowId)
    End Sub

    Private Sub updateList(model As List(Of ModelEntry), bookEntries As DataGridView, baseRow As Integer)
        Dim totalPrice = 0.0
        Dim cumSize = 0D
        If baseRow > 0 And baseRow < model.Count Then
            Dim entry = model(baseRow - 1)
            cumSize = model(baseRow - 1).CumSize
            totalPrice = model(baseRow - 1).TotalPrice
        End If

        For i = baseRow To model.Count - 1
            With model(i)
                cumSize += .Size
                .CumSize = cumSize
                totalPrice += (.Price * .Size)
                .TotalPrice = totalPrice

                Dim avgPrice As Decimal = CDec(totalPrice) / cumSize

                If i > (bookEntries.Rows.Count - 1) Then bookEntries.Rows.Add()
                bookEntries.Rows(i).SetValues(.MarketMaker, .Price, .Size, cumSize, avgPrice)
            End With
        Next
    End Sub
End Class
