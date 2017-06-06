#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2017 Richard L King (TradeWright Software Systems)
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

#End Region

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.DisconnectButton = New System.Windows.Forms.Button()
        Me.LogText = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.StopTickerButton = New System.Windows.Forms.Button()
        Me.StartTickerButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CurrencyTickerCombo = New System.Windows.Forms.ComboBox()
        Me.ExchangeTickerCombo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LocalSymbolTickerText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SecTypeTickerCombo = New System.Windows.Forms.ComboBox()
        Me.TickerGrid = New System.Windows.Forms.DataGridView()
        Me.Symbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Last = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ask = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AskSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Volume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CancelOrderButton = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TriggerPriceText = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LimitPriceText = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.OrderTypeCombo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.QuantityText = New System.Windows.Forms.TextBox()
        Me.SellButton = New System.Windows.Forms.Button()
        Me.BuyButton = New System.Windows.Forms.Button()
        Me.OrderGrid = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocalSymbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filled = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvgPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CurrencyOrderCombo = New System.Windows.Forms.ComboBox()
        Me.ExchangeOrderCombo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LocalSymbolOrderText = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SectypeOrderCombo = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.StopMarketDepthButton = New System.Windows.Forms.Button()
        Me.StartMarketDepthButton = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CurrencyDepthCombo = New System.Windows.Forms.ComboBox()
        Me.ExchangeDepthCombo = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LocalSymbolDepthText = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SecTypeDepthCombo = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AskGrid = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidGrid = New System.Windows.Forms.DataGridView()
        Me.MarketMaker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AveragePrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ServerTextBox = New System.Windows.Forms.TextBox()
        Me.PortTextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ClientIdTextBox = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TickerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.AskGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BidGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ConnectButton
        '
        Me.ConnectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConnectButton.Location = New System.Drawing.Point(574, 216)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(71, 37)
        Me.ConnectButton.TabIndex = 3
        Me.ConnectButton.Text = "Connect"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'DisconnectButton
        '
        Me.DisconnectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisconnectButton.Enabled = False
        Me.DisconnectButton.Location = New System.Drawing.Point(574, 259)
        Me.DisconnectButton.Name = "DisconnectButton"
        Me.DisconnectButton.Size = New System.Drawing.Size(71, 37)
        Me.DisconnectButton.TabIndex = 4
        Me.DisconnectButton.Text = "Disconnect"
        Me.DisconnectButton.UseVisualStyleBackColor = True
        '
        'LogText
        '
        Me.LogText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LogText.Location = New System.Drawing.Point(5, 513)
        Me.LogText.Multiline = True
        Me.LogText.Name = "LogText"
        Me.LogText.ReadOnly = True
        Me.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LogText.Size = New System.Drawing.Size(561, 138)
        Me.LogText.TabIndex = 9
        Me.LogText.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(5, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(561, 503)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.StopTickerButton)
        Me.TabPage1.Controls.Add(Me.StartTickerButton)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.CurrencyTickerCombo)
        Me.TabPage1.Controls.Add(Me.ExchangeTickerCombo)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.LocalSymbolTickerText)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.SecTypeTickerCombo)
        Me.TabPage1.Controls.Add(Me.TickerGrid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(553, 477)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tickers"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'StopTickerButton
        '
        Me.StopTickerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StopTickerButton.Enabled = False
        Me.StopTickerButton.Location = New System.Drawing.Point(440, 439)
        Me.StopTickerButton.Name = "StopTickerButton"
        Me.StopTickerButton.Size = New System.Drawing.Size(100, 35)
        Me.StopTickerButton.TabIndex = 21
        Me.StopTickerButton.Text = "Stop selected ticker(s)"
        Me.StopTickerButton.UseVisualStyleBackColor = True
        '
        'StartTickerButton
        '
        Me.StartTickerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartTickerButton.Enabled = False
        Me.StartTickerButton.Location = New System.Drawing.Point(334, 439)
        Me.StartTickerButton.Name = "StartTickerButton"
        Me.StartTickerButton.Size = New System.Drawing.Size(100, 35)
        Me.StartTickerButton.TabIndex = 20
        Me.StartTickerButton.Text = "Start ticker"
        Me.StartTickerButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(253, 439)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Currency"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 439)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Exchange"
        '
        'CurrencyTickerCombo
        '
        Me.CurrencyTickerCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CurrencyTickerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.CurrencyTickerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CurrencyTickerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurrencyTickerCombo.FormattingEnabled = True
        Me.CurrencyTickerCombo.Items.AddRange(New Object() {"EUR", "GBP", "JPY", "USD"})
        Me.CurrencyTickerCombo.Location = New System.Drawing.Point(253, 453)
        Me.CurrencyTickerCombo.Name = "CurrencyTickerCombo"
        Me.CurrencyTickerCombo.Size = New System.Drawing.Size(57, 21)
        Me.CurrencyTickerCombo.TabIndex = 17
        '
        'ExchangeTickerCombo
        '
        Me.ExchangeTickerCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExchangeTickerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ExchangeTickerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ExchangeTickerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ExchangeTickerCombo.FormattingEnabled = True
        Me.ExchangeTickerCombo.Items.AddRange(New Object() {"DTB", "ECBOT", "GLOBEX", "ICEEU", "IDEALPRO", "SMART"})
        Me.ExchangeTickerCombo.Location = New System.Drawing.Point(156, 453)
        Me.ExchangeTickerCombo.Name = "ExchangeTickerCombo"
        Me.ExchangeTickerCombo.Size = New System.Drawing.Size(81, 21)
        Me.ExchangeTickerCombo.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 439)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Local symbol"
        '
        'LocalSymbolTickerText
        '
        Me.LocalSymbolTickerText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LocalSymbolTickerText.Location = New System.Drawing.Point(70, 453)
        Me.LocalSymbolTickerText.Name = "LocalSymbolTickerText"
        Me.LocalSymbolTickerText.Size = New System.Drawing.Size(68, 20)
        Me.LocalSymbolTickerText.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 439)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Sec type"
        '
        'SecTypeTickerCombo
        '
        Me.SecTypeTickerCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SecTypeTickerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SecTypeTickerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SecTypeTickerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SecTypeTickerCombo.FormattingEnabled = True
        Me.SecTypeTickerCombo.Items.AddRange(New Object() {"STK", "FUT", "IND", "CASH"})
        Me.SecTypeTickerCombo.Location = New System.Drawing.Point(3, 453)
        Me.SecTypeTickerCombo.Name = "SecTypeTickerCombo"
        Me.SecTypeTickerCombo.Size = New System.Drawing.Size(53, 21)
        Me.SecTypeTickerCombo.TabIndex = 12
        '
        'TickerGrid
        '
        Me.TickerGrid.AllowUserToAddRows = False
        Me.TickerGrid.AllowUserToDeleteRows = False
        Me.TickerGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TickerGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TickerGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TickerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TickerGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TickerGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.TickerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TickerGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Symbol, Me.BidSize, Me.Bid, Me.Last, Me.LastSize, Me.Ask, Me.AskSize, Me.Volume})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TickerGrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.TickerGrid.Location = New System.Drawing.Point(0, 0)
        Me.TickerGrid.Name = "TickerGrid"
        Me.TickerGrid.Size = New System.Drawing.Size(558, 437)
        Me.TickerGrid.TabIndex = 11
        '
        'Symbol
        '
        Me.Symbol.HeaderText = "Symbol"
        Me.Symbol.Name = "Symbol"
        Me.Symbol.ReadOnly = True
        '
        'BidSize
        '
        Me.BidSize.HeaderText = "Bid Size"
        Me.BidSize.Name = "BidSize"
        Me.BidSize.ReadOnly = True
        '
        'Bid
        '
        Me.Bid.HeaderText = "Bid"
        Me.Bid.Name = "Bid"
        Me.Bid.ReadOnly = True
        '
        'Last
        '
        Me.Last.HeaderText = "Last"
        Me.Last.Name = "Last"
        Me.Last.ReadOnly = True
        '
        'LastSize
        '
        Me.LastSize.HeaderText = "Last Size"
        Me.LastSize.Name = "LastSize"
        Me.LastSize.ReadOnly = True
        '
        'Ask
        '
        Me.Ask.HeaderText = "Ask"
        Me.Ask.Name = "Ask"
        Me.Ask.ReadOnly = True
        '
        'AskSize
        '
        Me.AskSize.HeaderText = "Ask Size"
        Me.AskSize.Name = "AskSize"
        Me.AskSize.ReadOnly = True
        '
        'Volume
        '
        Me.Volume.HeaderText = "Volume"
        Me.Volume.Name = "Volume"
        Me.Volume.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CancelOrderButton)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.TriggerPriceText)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.LimitPriceText)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.OrderTypeCombo)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.QuantityText)
        Me.TabPage2.Controls.Add(Me.SellButton)
        Me.TabPage2.Controls.Add(Me.BuyButton)
        Me.TabPage2.Controls.Add(Me.OrderGrid)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.CurrencyOrderCombo)
        Me.TabPage2.Controls.Add(Me.ExchangeOrderCombo)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.LocalSymbolOrderText)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.SectypeOrderCombo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(553, 477)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Orders"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CancelOrderButton
        '
        Me.CancelOrderButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CancelOrderButton.Enabled = False
        Me.CancelOrderButton.Location = New System.Drawing.Point(418, 443)
        Me.CancelOrderButton.Name = "CancelOrderButton"
        Me.CancelOrderButton.Size = New System.Drawing.Size(52, 30)
        Me.CancelOrderButton.TabIndex = 39
        Me.CancelOrderButton.Text = "Cancel"
        Me.CancelOrderButton.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(156, 437)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Trigger price"
        '
        'TriggerPriceText
        '
        Me.TriggerPriceText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TriggerPriceText.Enabled = False
        Me.TriggerPriceText.Location = New System.Drawing.Point(156, 453)
        Me.TriggerPriceText.Name = "TriggerPriceText"
        Me.TriggerPriceText.Size = New System.Drawing.Size(68, 20)
        Me.TriggerPriceText.TabIndex = 37
        Me.TriggerPriceText.Text = "0"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(70, 437)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Limit price"
        '
        'LimitPriceText
        '
        Me.LimitPriceText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LimitPriceText.Enabled = False
        Me.LimitPriceText.Location = New System.Drawing.Point(70, 453)
        Me.LimitPriceText.Name = "LimitPriceText"
        Me.LimitPriceText.Size = New System.Drawing.Size(68, 20)
        Me.LimitPriceText.TabIndex = 35
        Me.LimitPriceText.Text = "0"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 437)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Order type"
        '
        'OrderTypeCombo
        '
        Me.OrderTypeCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OrderTypeCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.OrderTypeCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.OrderTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OrderTypeCombo.FormattingEnabled = True
        Me.OrderTypeCombo.Items.AddRange(New Object() {"MKT", "LMT", "STP", "STPLMT"})
        Me.OrderTypeCombo.Location = New System.Drawing.Point(3, 453)
        Me.OrderTypeCombo.Name = "OrderTypeCombo"
        Me.OrderTypeCombo.Size = New System.Drawing.Size(52, 21)
        Me.OrderTypeCombo.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(253, 439)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Quantity"
        '
        'QuantityText
        '
        Me.QuantityText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.QuantityText.Location = New System.Drawing.Point(253, 453)
        Me.QuantityText.Name = "QuantityText"
        Me.QuantityText.Size = New System.Drawing.Size(66, 20)
        Me.QuantityText.TabIndex = 31
        Me.QuantityText.Text = "1"
        '
        'SellButton
        '
        Me.SellButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SellButton.Enabled = False
        Me.SellButton.Location = New System.Drawing.Point(376, 443)
        Me.SellButton.Name = "SellButton"
        Me.SellButton.Size = New System.Drawing.Size(36, 30)
        Me.SellButton.TabIndex = 30
        Me.SellButton.Text = "Sell"
        Me.SellButton.UseVisualStyleBackColor = True
        '
        'BuyButton
        '
        Me.BuyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BuyButton.Enabled = False
        Me.BuyButton.Location = New System.Drawing.Point(334, 443)
        Me.BuyButton.Name = "BuyButton"
        Me.BuyButton.Size = New System.Drawing.Size(36, 30)
        Me.BuyButton.TabIndex = 29
        Me.BuyButton.Text = "Buy"
        Me.BuyButton.UseVisualStyleBackColor = True
        '
        'OrderGrid
        '
        Me.OrderGrid.AllowUserToAddRows = False
        Me.OrderGrid.AllowUserToDeleteRows = False
        Me.OrderGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.OrderGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.OrderGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OrderGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OrderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrderGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Status, Me.LocalSymbol, Me.Action, Me.Quantity, Me.Filled, Me.AvgPrice})
        Me.OrderGrid.Location = New System.Drawing.Point(0, 0)
        Me.OrderGrid.Name = "OrderGrid"
        Me.OrderGrid.Size = New System.Drawing.Size(553, 393)
        Me.OrderGrid.TabIndex = 28
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 75
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 75
        '
        'LocalSymbol
        '
        Me.LocalSymbol.HeaderText = "Symbol"
        Me.LocalSymbol.Name = "LocalSymbol"
        Me.LocalSymbol.ReadOnly = True
        Me.LocalSymbol.Width = 75
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Name = "Action"
        Me.Action.ReadOnly = True
        Me.Action.Width = 75
        '
        'Quantity
        '
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 75
        '
        'Filled
        '
        Me.Filled.HeaderText = "Filled"
        Me.Filled.Name = "Filled"
        Me.Filled.ReadOnly = True
        Me.Filled.Width = 75
        '
        'AvgPrice
        '
        Me.AvgPrice.HeaderText = "Avg price"
        Me.AvgPrice.Name = "AvgPrice"
        Me.AvgPrice.ReadOnly = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 396)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Currency"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(156, 396)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Exchange"
        '
        'CurrencyOrderCombo
        '
        Me.CurrencyOrderCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CurrencyOrderCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.CurrencyOrderCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CurrencyOrderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurrencyOrderCombo.FormattingEnabled = True
        Me.CurrencyOrderCombo.Items.AddRange(New Object() {"EUR", "GBP", "JPY", "USD"})
        Me.CurrencyOrderCombo.Location = New System.Drawing.Point(253, 410)
        Me.CurrencyOrderCombo.Name = "CurrencyOrderCombo"
        Me.CurrencyOrderCombo.Size = New System.Drawing.Size(57, 21)
        Me.CurrencyOrderCombo.TabIndex = 25
        '
        'ExchangeOrderCombo
        '
        Me.ExchangeOrderCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExchangeOrderCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ExchangeOrderCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ExchangeOrderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ExchangeOrderCombo.FormattingEnabled = True
        Me.ExchangeOrderCombo.Items.AddRange(New Object() {"DTB", "ECBOT", "GLOBEX", "ICEEU", "IDEALPRO", "SMART"})
        Me.ExchangeOrderCombo.Location = New System.Drawing.Point(156, 410)
        Me.ExchangeOrderCombo.Name = "ExchangeOrderCombo"
        Me.ExchangeOrderCombo.Size = New System.Drawing.Size(81, 21)
        Me.ExchangeOrderCombo.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(70, 396)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Local symbol"
        '
        'LocalSymbolOrderText
        '
        Me.LocalSymbolOrderText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LocalSymbolOrderText.Location = New System.Drawing.Point(70, 410)
        Me.LocalSymbolOrderText.Name = "LocalSymbolOrderText"
        Me.LocalSymbolOrderText.Size = New System.Drawing.Size(68, 20)
        Me.LocalSymbolOrderText.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 396)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Sec type"
        '
        'SectypeOrderCombo
        '
        Me.SectypeOrderCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SectypeOrderCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SectypeOrderCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SectypeOrderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SectypeOrderCombo.FormattingEnabled = True
        Me.SectypeOrderCombo.Items.AddRange(New Object() {"STK", "FUT", "IND", "CASH"})
        Me.SectypeOrderCombo.Location = New System.Drawing.Point(3, 410)
        Me.SectypeOrderCombo.Name = "SectypeOrderCombo"
        Me.SectypeOrderCombo.Size = New System.Drawing.Size(53, 21)
        Me.SectypeOrderCombo.TabIndex = 20
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.StopMarketDepthButton)
        Me.TabPage3.Controls.Add(Me.StartMarketDepthButton)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.CurrencyDepthCombo)
        Me.TabPage3.Controls.Add(Me.ExchangeDepthCombo)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.LocalSymbolDepthText)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.SecTypeDepthCombo)
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(553, 477)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Market Depth"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'StopMarketDepthButton
        '
        Me.StopMarketDepthButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StopMarketDepthButton.Enabled = False
        Me.StopMarketDepthButton.Location = New System.Drawing.Point(442, 440)
        Me.StopMarketDepthButton.Name = "StopMarketDepthButton"
        Me.StopMarketDepthButton.Size = New System.Drawing.Size(100, 35)
        Me.StopMarketDepthButton.TabIndex = 31
        Me.StopMarketDepthButton.Text = "Stop market depth"
        Me.StopMarketDepthButton.UseVisualStyleBackColor = True
        '
        'StartMarketDepthButton
        '
        Me.StartMarketDepthButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartMarketDepthButton.Enabled = False
        Me.StartMarketDepthButton.Location = New System.Drawing.Point(336, 440)
        Me.StartMarketDepthButton.Name = "StartMarketDepthButton"
        Me.StartMarketDepthButton.Size = New System.Drawing.Size(100, 35)
        Me.StartMarketDepthButton.TabIndex = 30
        Me.StartMarketDepthButton.Text = "Start market depth"
        Me.StartMarketDepthButton.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(255, 440)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Currency"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(158, 440)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Exchange"
        '
        'CurrencyDepthCombo
        '
        Me.CurrencyDepthCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CurrencyDepthCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.CurrencyDepthCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CurrencyDepthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurrencyDepthCombo.FormattingEnabled = True
        Me.CurrencyDepthCombo.Items.AddRange(New Object() {"EUR", "GBP", "JPY", "USD"})
        Me.CurrencyDepthCombo.Location = New System.Drawing.Point(255, 454)
        Me.CurrencyDepthCombo.Name = "CurrencyDepthCombo"
        Me.CurrencyDepthCombo.Size = New System.Drawing.Size(57, 21)
        Me.CurrencyDepthCombo.TabIndex = 27
        '
        'ExchangeDepthCombo
        '
        Me.ExchangeDepthCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExchangeDepthCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ExchangeDepthCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ExchangeDepthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ExchangeDepthCombo.FormattingEnabled = True
        Me.ExchangeDepthCombo.Items.AddRange(New Object() {"DTB", "ECBOT", "GLOBEX", "ICEEU", "IDEALPRO", "SMART"})
        Me.ExchangeDepthCombo.Location = New System.Drawing.Point(158, 454)
        Me.ExchangeDepthCombo.Name = "ExchangeDepthCombo"
        Me.ExchangeDepthCombo.Size = New System.Drawing.Size(81, 21)
        Me.ExchangeDepthCombo.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(72, 440)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Local symbol"
        '
        'LocalSymbolDepthText
        '
        Me.LocalSymbolDepthText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LocalSymbolDepthText.Location = New System.Drawing.Point(72, 454)
        Me.LocalSymbolDepthText.Name = "LocalSymbolDepthText"
        Me.LocalSymbolDepthText.Size = New System.Drawing.Size(68, 20)
        Me.LocalSymbolDepthText.TabIndex = 24
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 440)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Sec type"
        '
        'SecTypeDepthCombo
        '
        Me.SecTypeDepthCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SecTypeDepthCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SecTypeDepthCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SecTypeDepthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SecTypeDepthCombo.FormattingEnabled = True
        Me.SecTypeDepthCombo.Items.AddRange(New Object() {"STK", "FUT", "IND", "CASH"})
        Me.SecTypeDepthCombo.Location = New System.Drawing.Point(5, 454)
        Me.SecTypeDepthCombo.Name = "SecTypeDepthCombo"
        Me.SecTypeDepthCombo.Size = New System.Drawing.Size(53, 21)
        Me.SecTypeDepthCombo.TabIndex = 22
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AskGrid, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BidGrid, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(550, 437)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'AskGrid
        '
        Me.AskGrid.AllowUserToAddRows = False
        Me.AskGrid.AllowUserToDeleteRows = False
        Me.AskGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AskGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.AskGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.AskGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AskGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.AskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AskGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AskGrid.DefaultCellStyle = DataGridViewCellStyle8
        Me.AskGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AskGrid.Location = New System.Drawing.Point(278, 3)
        Me.AskGrid.Name = "AskGrid"
        Me.AskGrid.RowHeadersVisible = False
        Me.AskGrid.Size = New System.Drawing.Size(269, 431)
        Me.AskGrid.TabIndex = 14
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Market maker"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ask price"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Ask size"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cum size"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle7.Format = "0.000000"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn8.HeaderText = "Avg price"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BidGrid
        '
        Me.BidGrid.AllowUserToAddRows = False
        Me.BidGrid.AllowUserToDeleteRows = False
        Me.BidGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BidGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.BidGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.BidGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BidGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.BidGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BidGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MarketMaker, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn4, Me.AveragePrice})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.BidGrid.DefaultCellStyle = DataGridViewCellStyle12
        Me.BidGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BidGrid.Location = New System.Drawing.Point(3, 3)
        Me.BidGrid.Name = "BidGrid"
        Me.BidGrid.RowHeadersVisible = False
        Me.BidGrid.Size = New System.Drawing.Size(269, 431)
        Me.BidGrid.TabIndex = 13
        '
        'MarketMaker
        '
        Me.MarketMaker.HeaderText = "Market maker"
        Me.MarketMaker.Name = "MarketMaker"
        Me.MarketMaker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Bid price"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Bid size"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cum size"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AveragePrice
        '
        DataGridViewCellStyle11.Format = "0.000000"
        Me.AveragePrice.DefaultCellStyle = DataGridViewCellStyle11
        Me.AveragePrice.HeaderText = "Avg price"
        Me.AveragePrice.Name = "AveragePrice"
        Me.AveragePrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'QuantityErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(573, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "API Server"
        '
        'ServerTextBox
        '
        Me.ServerTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ServerTextBox.Location = New System.Drawing.Point(572, 51)
        Me.ServerTextBox.Name = "ServerTextBox"
        Me.ServerTextBox.Size = New System.Drawing.Size(66, 20)
        Me.ServerTextBox.TabIndex = 0
        '
        'PortTextBox
        '
        Me.PortTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PortTextBox.Location = New System.Drawing.Point(572, 109)
        Me.PortTextBox.Name = "PortTextBox"
        Me.PortTextBox.Size = New System.Drawing.Size(66, 20)
        Me.PortTextBox.TabIndex = 1
        Me.PortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(573, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Port"
        '
        'ClientIdTextBox
        '
        Me.ClientIdTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClientIdTextBox.Location = New System.Drawing.Point(572, 161)
        Me.ClientIdTextBox.Name = "ClientIdTextBox"
        Me.ClientIdTextBox.Size = New System.Drawing.Size(66, 20)
        Me.ClientIdTextBox.TabIndex = 2
        Me.ClientIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(573, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "ClientID"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 663)
        Me.Controls.Add(Me.ClientIdTextBox)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PortTextBox)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ServerTextBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.LogText)
        Me.Controls.Add(Me.DisconnectButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Name = "MainForm"
        Me.Text = "Simple TWS API Demo"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.TickerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.AskGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BidGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConnectButton As System.Windows.Forms.Button
    Friend WithEvents DisconnectButton As System.Windows.Forms.Button
    Friend WithEvents LogText As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TickerGrid As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SecTypeTickerCombo As System.Windows.Forms.ComboBox
    Friend WithEvents StartTickerButton As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CurrencyTickerCombo As System.Windows.Forms.ComboBox
    Friend WithEvents ExchangeTickerCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LocalSymbolTickerText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CurrencyOrderCombo As System.Windows.Forms.ComboBox
    Friend WithEvents ExchangeOrderCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LocalSymbolOrderText As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SectypeOrderCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents QuantityText As System.Windows.Forms.TextBox
    Friend WithEvents SellButton As System.Windows.Forms.Button
    Friend WithEvents BuyButton As System.Windows.Forms.Button
    Friend WithEvents OrderGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents StopTickerButton As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocalSymbol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Filled As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AvgPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TriggerPriceText As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LimitPriceText As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OrderTypeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents CancelOrderButton As System.Windows.Forms.Button
    Friend WithEvents Symbol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Last As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ask As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AskSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Volume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientIdTextBox As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents PortTextBox As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ServerTextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents AskGrid As DataGridView
    Friend WithEvents BidGrid As DataGridView
    Friend WithEvents StopMarketDepthButton As Button
    Friend WithEvents StartMarketDepthButton As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents CurrencyDepthCombo As ComboBox
    Friend WithEvents ExchangeDepthCombo As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents LocalSymbolDepthText As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents SecTypeDepthCombo As ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents MarketMaker As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents AveragePrice As DataGridViewTextBoxColumn
End Class
