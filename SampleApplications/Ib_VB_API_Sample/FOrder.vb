' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.



Imports TradeWright.IBAPI

Imports System.Collections.Generic

Friend Class FOrder
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            If Not mComponents Is Nothing Then
                mComponents.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private mComponents As System.ComponentModel.IContainer
    Public WithEvents WhatToShowText As System.Windows.Forms.TextBox
    Public WithEvents Frame1 As TradeWright.UI.Themes.TitledGroupBox
    Public WithEvents CancelItButton As TradeWright.UI.Themes.ThemedButton1
    Public WithEvents OkButton As TradeWright.UI.Themes.ThemedButton1
    Public WithEvents MultiplierText As System.Windows.Forms.TextBox
    Public WithEvents PrimaryExchangeText As System.Windows.Forms.TextBox
    Public WithEvents RightText As System.Windows.Forms.TextBox
    Public WithEvents LocalSymbolText As System.Windows.Forms.TextBox
    Public WithEvents CurrencyText As System.Windows.Forms.TextBox
    Public WithEvents ExchangeText As System.Windows.Forms.TextBox
    Public WithEvents StrikeText As System.Windows.Forms.TextBox
    Public WithEvents ExpiryText As System.Windows.Forms.TextBox
    Public WithEvents SecTypeText As System.Windows.Forms.TextBox
    Public WithEvents SymbolText As System.Windows.Forms.TextBox
    Public WithEvents TickerDescFrame As TradeWright.UI.Themes.TitledGroupBox
    Public WithEvents ReqIdText As System.Windows.Forms.TextBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents GroupBox1 As TradeWright.UI.Themes.TitledGroupBox
    Public WithEvents DurationText As System.Windows.Forms.TextBox
    Public WithEvents BarSizeSettingText As System.Windows.Forms.TextBox
    Public WithEvents EndDateTimeText As System.Windows.Forms.TextBox
    Public WithEvents GroupBox2 As TradeWright.UI.Themes.TitledGroupBox
    Public WithEvents ExerciseActionText As System.Windows.Forms.TextBox
    Public WithEvents ExerciseQuantityText As System.Windows.Forms.TextBox
    Public WithEvents GroupBox4 As TradeWright.UI.Themes.TitledGroupBox
    Public WithEvents GenericTickTagsText As System.Windows.Forms.TextBox
    Public WithEvents NumRowsText As System.Windows.Forms.TextBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents Label55 As System.Windows.Forms.Label
    Public WithEvents Label56 As System.Windows.Forms.Label
    Public WithEvents Label57 As System.Windows.Forms.Label
    Public WithEvents Label58 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SnapshotMktDataCheck As System.Windows.Forms.CheckBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents ConIdText As System.Windows.Forms.TextBox
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents SetShareAllocationButton As System.Windows.Forms.Button
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents ActionText As System.Windows.Forms.TextBox
    Public WithEvents QuantityText As System.Windows.Forms.TextBox
    Public WithEvents OrderTypeText As System.Windows.Forms.TextBox
    Public WithEvents LimitPriceText As System.Windows.Forms.TextBox
    Public WithEvents AuxPriceText As System.Windows.Forms.TextBox
    Public WithEvents AddCmboLegsButton As System.Windows.Forms.Button
    Public WithEvents GTDText As System.Windows.Forms.TextBox
    Public WithEvents GATText As System.Windows.Forms.TextBox
    Public WithEvents DeltaNeutralContractButton As System.Windows.Forms.Button
    Public WithEvents AlgoParamsButton As System.Windows.Forms.Button
    Public WithEvents OrderDescFrame As TradeWright.UI.Themes.TitledGroupBox
    Friend WithEvents SecIdText As System.Windows.Forms.TextBox
    Friend WithEvents SecIdTypeText As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents MarketDataTypeLabel As System.Windows.Forms.Label
    Public WithEvents MarketDataTypeFrame As TradeWright.UI.Themes.TitledGroupBox
    Friend WithEvents MarketDataTypeCombo As System.Windows.Forms.ComboBox
    Public WithEvents SmartComboRoutingParamsButton As System.Windows.Forms.Button
    Public WithEvents TradingClassText As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OptionsButton As System.Windows.Forms.Button
    Friend WithEvents PegBenchButton As System.Windows.Forms.Button
    Friend WithEvents AdjustStopButton As System.Windows.Forms.Button
    Friend WithEvents ConditionsButton As System.Windows.Forms.Button
    Public WithEvents CashQtyText As System.Windows.Forms.TextBox
    Friend WithEvents IncludeExpiredCheck As CheckBox
    Friend WithEvents UseRTHCheck As CheckBox
    Public WithEvents NumOfTicksText As TextBox
    Public WithEvents Label12 As Label
    Public WithEvents StartDateTimeText As TextBox
    Public WithEvents Label9 As Label
    Friend WithEvents TickByTickTypeCombo As ComboBox
    Public WithEvents TickByTickTypeLabel As Label
    Friend WithEvents IgnoreSizeCheck As CheckBox
    Friend WithEvents KeepUpToDateCheck As CheckBox
    Friend WithEvents ExerciseOverrideCheck As CheckBox
    Public WithEvents EndTimezoneText As TextBox
    Public WithEvents Label18 As Label
    Public WithEvents StartTimezoneText As TextBox
    Public WithEvents Label17 As Label
    Public WithEvents OrderIdText As TextBox
    Public WithEvents Label21 As Label
    Friend WithEvents GroupBox5 As TradeWright.UI.Themes.TitledGroupBox
    Public WithEvents CashQtyLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Frame1 = New TradeWright.UI.Themes.TitledGroupBox()
        Me.EndTimezoneText = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.StartTimezoneText = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.NumOfTicksText = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.StartDateTimeText = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TickByTickTypeCombo = New System.Windows.Forms.ComboBox()
        Me.TickByTickTypeLabel = New System.Windows.Forms.Label()
        Me.IgnoreSizeCheck = New System.Windows.Forms.CheckBox()
        Me.KeepUpToDateCheck = New System.Windows.Forms.CheckBox()
        Me.UseRTHCheck = New System.Windows.Forms.CheckBox()
        Me.EndDateTimeText = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.BarSizeSettingText = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.WhatToShowText = New System.Windows.Forms.TextBox()
        Me.DurationText = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CancelItButton = New TradeWright.UI.Themes.ThemedButton1()
        Me.OkButton = New TradeWright.UI.Themes.ThemedButton1()
        Me.TickerDescFrame = New TradeWright.UI.Themes.TitledGroupBox()
        Me.IncludeExpiredCheck = New System.Windows.Forms.CheckBox()
        Me.TradingClassText = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SecIdText = New System.Windows.Forms.TextBox()
        Me.SecIdTypeText = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConIdText = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MultiplierText = New System.Windows.Forms.TextBox()
        Me.PrimaryExchangeText = New System.Windows.Forms.TextBox()
        Me.RightText = New System.Windows.Forms.TextBox()
        Me.LocalSymbolText = New System.Windows.Forms.TextBox()
        Me.CurrencyText = New System.Windows.Forms.TextBox()
        Me.ExchangeText = New System.Windows.Forms.TextBox()
        Me.StrikeText = New System.Windows.Forms.TextBox()
        Me.ExpiryText = New System.Windows.Forms.TextBox()
        Me.SecTypeText = New System.Windows.Forms.TextBox()
        Me.SymbolText = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.ReqIdText = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New TradeWright.UI.Themes.TitledGroupBox()
        Me.SnapshotMktDataCheck = New System.Windows.Forms.CheckBox()
        Me.GenericTickTagsText = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New TradeWright.UI.Themes.TitledGroupBox()
        Me.ExerciseOverrideCheck = New System.Windows.Forms.CheckBox()
        Me.ExerciseQuantityText = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.ExerciseActionText = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.OrderIdText = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New TradeWright.UI.Themes.TitledGroupBox()
        Me.NumRowsText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SetShareAllocationButton = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ActionText = New System.Windows.Forms.TextBox()
        Me.QuantityText = New System.Windows.Forms.TextBox()
        Me.OrderTypeText = New System.Windows.Forms.TextBox()
        Me.LimitPriceText = New System.Windows.Forms.TextBox()
        Me.AuxPriceText = New System.Windows.Forms.TextBox()
        Me.AddCmboLegsButton = New System.Windows.Forms.Button()
        Me.GTDText = New System.Windows.Forms.TextBox()
        Me.GATText = New System.Windows.Forms.TextBox()
        Me.DeltaNeutralContractButton = New System.Windows.Forms.Button()
        Me.AlgoParamsButton = New System.Windows.Forms.Button()
        Me.OrderDescFrame = New TradeWright.UI.Themes.TitledGroupBox()
        Me.CashQtyText = New System.Windows.Forms.TextBox()
        Me.CashQtyLabel = New System.Windows.Forms.Label()
        Me.PegBenchButton = New System.Windows.Forms.Button()
        Me.AdjustStopButton = New System.Windows.Forms.Button()
        Me.ConditionsButton = New System.Windows.Forms.Button()
        Me.OptionsButton = New System.Windows.Forms.Button()
        Me.SmartComboRoutingParamsButton = New System.Windows.Forms.Button()
        Me.MarketDataTypeLabel = New System.Windows.Forms.Label()
        Me.MarketDataTypeFrame = New TradeWright.UI.Themes.TitledGroupBox()
        Me.MarketDataTypeCombo = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New TradeWright.UI.Themes.TitledGroupBox()
        Me.Frame1.SuspendLayout()
        Me.TickerDescFrame.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.OrderDescFrame.SuspendLayout()
        Me.MarketDataTypeFrame.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.EndTimezoneText)
        Me.Frame1.Controls.Add(Me.Label18)
        Me.Frame1.Controls.Add(Me.StartTimezoneText)
        Me.Frame1.Controls.Add(Me.Label17)
        Me.Frame1.Controls.Add(Me.NumOfTicksText)
        Me.Frame1.Controls.Add(Me.Label12)
        Me.Frame1.Controls.Add(Me.StartDateTimeText)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.TickByTickTypeCombo)
        Me.Frame1.Controls.Add(Me.TickByTickTypeLabel)
        Me.Frame1.Controls.Add(Me.IgnoreSizeCheck)
        Me.Frame1.Controls.Add(Me.KeepUpToDateCheck)
        Me.Frame1.Controls.Add(Me.UseRTHCheck)
        Me.Frame1.Controls.Add(Me.EndDateTimeText)
        Me.Frame1.Controls.Add(Me.Label24)
        Me.Frame1.Controls.Add(Me.BarSizeSettingText)
        Me.Frame1.Controls.Add(Me.Label23)
        Me.Frame1.Controls.Add(Me.WhatToShowText)
        Me.Frame1.Controls.Add(Me.DurationText)
        Me.Frame1.Controls.Add(Me.Label19)
        Me.Frame1.Controls.Add(Me.Label25)
        Me.Frame1.Location = New System.Drawing.Point(352, 497)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(322, 306)
        Me.Frame1.TabIndex = 7
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Historical Data"
        Me.Frame1.TitleBackColor = System.Drawing.Color.Empty
        Me.Frame1.TitleFont = Nothing
        Me.Frame1.TitleForeColor = System.Drawing.Color.Empty
        '
        'EndTimezoneText
        '
        Me.EndTimezoneText.AcceptsReturn = True
        Me.EndTimezoneText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EndTimezoneText.Location = New System.Drawing.Point(192, 90)
        Me.EndTimezoneText.Name = "EndTimezoneText"
        Me.EndTimezoneText.Size = New System.Drawing.Size(120, 23)
        Me.EndTimezoneText.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(14, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 19)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "End Timezone"
        '
        'StartTimezoneText
        '
        Me.StartTimezoneText.AcceptsReturn = True
        Me.StartTimezoneText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartTimezoneText.Location = New System.Drawing.Point(192, 42)
        Me.StartTimezoneText.Name = "StartTimezoneText"
        Me.StartTimezoneText.Size = New System.Drawing.Size(120, 23)
        Me.StartTimezoneText.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(14, 42)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 19)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Start Timezone"
        '
        'NumOfTicksText
        '
        Me.NumOfTicksText.AcceptsReturn = True
        Me.NumOfTicksText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumOfTicksText.Location = New System.Drawing.Point(192, 114)
        Me.NumOfTicksText.Name = "NumOfTicksText"
        Me.NumOfTicksText.Size = New System.Drawing.Size(120, 23)
        Me.NumOfTicksText.TabIndex = 4
        Me.NumOfTicksText.Text = "1"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(14, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(178, 23)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Number of ticks"
        '
        'StartDateTimeText
        '
        Me.StartDateTimeText.AcceptsReturn = True
        Me.StartDateTimeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartDateTimeText.Location = New System.Drawing.Point(192, 18)
        Me.StartDateTimeText.Name = "StartDateTimeText"
        Me.StartDateTimeText.Size = New System.Drawing.Size(120, 23)
        Me.StartDateTimeText.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(14, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(178, 27)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Start (YYYYMMDD hh:mm:ss)"
        '
        'TickByTickTypeCombo
        '
        Me.TickByTickTypeCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TickByTickTypeCombo.FormattingEnabled = True
        Me.TickByTickTypeCombo.Location = New System.Drawing.Point(192, 270)
        Me.TickByTickTypeCombo.Name = "TickByTickTypeCombo"
        Me.TickByTickTypeCombo.Size = New System.Drawing.Size(120, 23)
        Me.TickByTickTypeCombo.TabIndex = 11
        '
        'TickByTickTypeLabel
        '
        Me.TickByTickTypeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.TickByTickTypeLabel.Location = New System.Drawing.Point(14, 270)
        Me.TickByTickTypeLabel.Name = "TickByTickTypeLabel"
        Me.TickByTickTypeLabel.Size = New System.Drawing.Size(96, 17)
        Me.TickByTickTypeLabel.TabIndex = 22
        Me.TickByTickTypeLabel.Text = "Tick-by-tick type"
        '
        'IgnoreSizeCheck
        '
        Me.IgnoreSizeCheck.AutoSize = True
        Me.IgnoreSizeCheck.Location = New System.Drawing.Point(192, 246)
        Me.IgnoreSizeCheck.Name = "IgnoreSizeCheck"
        Me.IgnoreSizeCheck.Size = New System.Drawing.Size(82, 19)
        Me.IgnoreSizeCheck.TabIndex = 10
        Me.IgnoreSizeCheck.Text = "Ignore size"
        '
        'KeepUpToDateCheck
        '
        Me.KeepUpToDateCheck.AutoSize = True
        Me.KeepUpToDateCheck.Location = New System.Drawing.Point(17, 246)
        Me.KeepUpToDateCheck.Name = "KeepUpToDateCheck"
        Me.KeepUpToDateCheck.Size = New System.Drawing.Size(109, 19)
        Me.KeepUpToDateCheck.TabIndex = 9
        Me.KeepUpToDateCheck.Text = "Keep up to date"
        '
        'UseRTHCheck
        '
        Me.UseRTHCheck.AutoSize = True
        Me.UseRTHCheck.Checked = True
        Me.UseRTHCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseRTHCheck.Location = New System.Drawing.Point(17, 221)
        Me.UseRTHCheck.Name = "UseRTHCheck"
        Me.UseRTHCheck.Size = New System.Drawing.Size(144, 19)
        Me.UseRTHCheck.TabIndex = 8
        Me.UseRTHCheck.Text = "Regular Trading Hours"
        '
        'EndDateTimeText
        '
        Me.EndDateTimeText.AcceptsReturn = True
        Me.EndDateTimeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EndDateTimeText.Location = New System.Drawing.Point(192, 66)
        Me.EndDateTimeText.Name = "EndDateTimeText"
        Me.EndDateTimeText.Size = New System.Drawing.Size(120, 23)
        Me.EndDateTimeText.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(14, 69)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(178, 23)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "End (YYYYMMDD hh:mm:ss)"
        '
        'BarSizeSettingText
        '
        Me.BarSizeSettingText.AcceptsReturn = True
        Me.BarSizeSettingText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BarSizeSettingText.Location = New System.Drawing.Point(192, 162)
        Me.BarSizeSettingText.Name = "BarSizeSettingText"
        Me.BarSizeSettingText.Size = New System.Drawing.Size(120, 23)
        Me.BarSizeSettingText.TabIndex = 6
        Me.BarSizeSettingText.Text = "1 day"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(14, 165)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 17)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Bar Size"
        '
        'WhatToShowText
        '
        Me.WhatToShowText.AcceptsReturn = True
        Me.WhatToShowText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WhatToShowText.Location = New System.Drawing.Point(192, 186)
        Me.WhatToShowText.Name = "WhatToShowText"
        Me.WhatToShowText.Size = New System.Drawing.Size(120, 23)
        Me.WhatToShowText.TabIndex = 7
        Me.WhatToShowText.Text = "TRADES"
        '
        'DurationText
        '
        Me.DurationText.AcceptsReturn = True
        Me.DurationText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DurationText.Location = New System.Drawing.Point(192, 138)
        Me.DurationText.Name = "DurationText"
        Me.DurationText.Size = New System.Drawing.Size(120, 23)
        Me.DurationText.TabIndex = 5
        Me.DurationText.Text = "1 M"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(14, 189)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(160, 23)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "What To Show"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(14, 141)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(80, 17)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Duration"
        '
        'CancelItButton
        '
        Me.CancelItButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelItButton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.Color.DimGray
        Me.CancelItButton.Location = New System.Drawing.Point(6, 112)
        Me.CancelItButton.Name = "CancelItButton"
        Me.CancelItButton.Size = New System.Drawing.Size(65, 25)
        Me.CancelItButton.TabIndex = 3
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.Color.DimGray
        Me.OkButton.Location = New System.Drawing.Point(6, 81)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(65, 23)
        Me.OkButton.TabIndex = 2
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'TickerDescFrame
        '
        Me.TickerDescFrame.Controls.Add(Me.IncludeExpiredCheck)
        Me.TickerDescFrame.Controls.Add(Me.TradingClassText)
        Me.TickerDescFrame.Controls.Add(Me.Label8)
        Me.TickerDescFrame.Controls.Add(Me.SecIdText)
        Me.TickerDescFrame.Controls.Add(Me.SecIdTypeText)
        Me.TickerDescFrame.Controls.Add(Me.Label7)
        Me.TickerDescFrame.Controls.Add(Me.Label6)
        Me.TickerDescFrame.Controls.Add(Me.Label3)
        Me.TickerDescFrame.Controls.Add(Me.ConIdText)
        Me.TickerDescFrame.Controls.Add(Me.Label4)
        Me.TickerDescFrame.Controls.Add(Me.MultiplierText)
        Me.TickerDescFrame.Controls.Add(Me.PrimaryExchangeText)
        Me.TickerDescFrame.Controls.Add(Me.RightText)
        Me.TickerDescFrame.Controls.Add(Me.LocalSymbolText)
        Me.TickerDescFrame.Controls.Add(Me.CurrencyText)
        Me.TickerDescFrame.Controls.Add(Me.ExchangeText)
        Me.TickerDescFrame.Controls.Add(Me.StrikeText)
        Me.TickerDescFrame.Controls.Add(Me.ExpiryText)
        Me.TickerDescFrame.Controls.Add(Me.SecTypeText)
        Me.TickerDescFrame.Controls.Add(Me.SymbolText)
        Me.TickerDescFrame.Controls.Add(Me.Label5)
        Me.TickerDescFrame.Controls.Add(Me.Label2)
        Me.TickerDescFrame.Controls.Add(Me.Label37)
        Me.TickerDescFrame.Controls.Add(Me.Label53)
        Me.TickerDescFrame.Controls.Add(Me.Label54)
        Me.TickerDescFrame.Controls.Add(Me.Label55)
        Me.TickerDescFrame.Controls.Add(Me.Label56)
        Me.TickerDescFrame.Controls.Add(Me.Label57)
        Me.TickerDescFrame.Controls.Add(Me.Label58)
        Me.TickerDescFrame.Location = New System.Drawing.Point(8, 20)
        Me.TickerDescFrame.Name = "TickerDescFrame"
        Me.TickerDescFrame.Size = New System.Drawing.Size(322, 471)
        Me.TickerDescFrame.TabIndex = 1
        Me.TickerDescFrame.TabStop = False
        Me.TickerDescFrame.Text = "Ticker Description"
        Me.TickerDescFrame.TitleBackColor = System.Drawing.Color.Empty
        Me.TickerDescFrame.TitleFont = Nothing
        Me.TickerDescFrame.TitleForeColor = System.Drawing.Color.Empty
        '
        'IncludeExpiredCheck
        '
        Me.IncludeExpiredCheck.AutoSize = True
        Me.IncludeExpiredCheck.Location = New System.Drawing.Point(17, 362)
        Me.IncludeExpiredCheck.Name = "IncludeExpiredCheck"
        Me.IncludeExpiredCheck.Size = New System.Drawing.Size(106, 19)
        Me.IncludeExpiredCheck.TabIndex = 12
        Me.IncludeExpiredCheck.Text = "Include expired"
        '
        'TradingClassText
        '
        Me.TradingClassText.AcceptsReturn = True
        Me.TradingClassText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TradingClassText.Location = New System.Drawing.Point(226, 332)
        Me.TradingClassText.Name = "TradingClassText"
        Me.TradingClassText.Size = New System.Drawing.Size(88, 23)
        Me.TradingClassText.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 332)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Trading Class"
        '
        'SecIdText
        '
        Me.SecIdText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SecIdText.Location = New System.Drawing.Point(226, 418)
        Me.SecIdText.Name = "SecIdText"
        Me.SecIdText.Size = New System.Drawing.Size(85, 23)
        Me.SecIdText.TabIndex = 14
        '
        'SecIdTypeText
        '
        Me.SecIdTypeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SecIdTypeText.Location = New System.Drawing.Point(226, 390)
        Me.SecIdTypeText.Name = "SecIdTypeText"
        Me.SecIdTypeText.Size = New System.Drawing.Size(86, 23)
        Me.SecIdTypeText.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 418)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 15)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Sec Id"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 390)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Sec Id Type"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Contract Id"
        '
        'ConIdText
        '
        Me.ConIdText.AcceptsReturn = True
        Me.ConIdText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConIdText.Location = New System.Drawing.Point(226, 22)
        Me.ConIdText.Name = "ConIdText"
        Me.ConIdText.Size = New System.Drawing.Size(88, 23)
        Me.ConIdText.TabIndex = 0
        Me.ConIdText.Text = "0"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(212, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Last trade date or contract month"
        '
        'MultiplierText
        '
        Me.MultiplierText.AcceptsReturn = True
        Me.MultiplierText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MultiplierText.Location = New System.Drawing.Point(226, 190)
        Me.MultiplierText.MaxLength = 0
        Me.MultiplierText.Name = "MultiplierText"
        Me.MultiplierText.Size = New System.Drawing.Size(88, 23)
        Me.MultiplierText.TabIndex = 6
        '
        'PrimaryExchangeText
        '
        Me.PrimaryExchangeText.AcceptsReturn = True
        Me.PrimaryExchangeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrimaryExchangeText.Location = New System.Drawing.Point(226, 246)
        Me.PrimaryExchangeText.Name = "PrimaryExchangeText"
        Me.PrimaryExchangeText.Size = New System.Drawing.Size(88, 23)
        Me.PrimaryExchangeText.TabIndex = 8
        Me.PrimaryExchangeText.Text = "ISLAND"
        '
        'RightText
        '
        Me.RightText.AcceptsReturn = True
        Me.RightText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RightText.Location = New System.Drawing.Point(226, 162)
        Me.RightText.Name = "RightText"
        Me.RightText.Size = New System.Drawing.Size(88, 23)
        Me.RightText.TabIndex = 5
        '
        'LocalSymbolText
        '
        Me.LocalSymbolText.AcceptsReturn = True
        Me.LocalSymbolText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LocalSymbolText.Location = New System.Drawing.Point(226, 302)
        Me.LocalSymbolText.Name = "LocalSymbolText"
        Me.LocalSymbolText.Size = New System.Drawing.Size(88, 23)
        Me.LocalSymbolText.TabIndex = 10
        '
        'CurrencyText
        '
        Me.CurrencyText.AcceptsReturn = True
        Me.CurrencyText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyText.Location = New System.Drawing.Point(226, 274)
        Me.CurrencyText.Name = "CurrencyText"
        Me.CurrencyText.Size = New System.Drawing.Size(88, 23)
        Me.CurrencyText.TabIndex = 9
        Me.CurrencyText.Text = "USD"
        '
        'ExchangeText
        '
        Me.ExchangeText.AcceptsReturn = True
        Me.ExchangeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExchangeText.Location = New System.Drawing.Point(226, 218)
        Me.ExchangeText.Name = "ExchangeText"
        Me.ExchangeText.Size = New System.Drawing.Size(88, 23)
        Me.ExchangeText.TabIndex = 7
        Me.ExchangeText.Text = "SMART"
        '
        'StrikeText
        '
        Me.StrikeText.AcceptsReturn = True
        Me.StrikeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StrikeText.Location = New System.Drawing.Point(226, 134)
        Me.StrikeText.Name = "StrikeText"
        Me.StrikeText.Size = New System.Drawing.Size(88, 23)
        Me.StrikeText.TabIndex = 4
        Me.StrikeText.Text = "0"
        '
        'ExpiryText
        '
        Me.ExpiryText.AcceptsReturn = True
        Me.ExpiryText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpiryText.Location = New System.Drawing.Point(226, 106)
        Me.ExpiryText.Name = "ExpiryText"
        Me.ExpiryText.Size = New System.Drawing.Size(88, 23)
        Me.ExpiryText.TabIndex = 3
        '
        'SecTypeText
        '
        Me.SecTypeText.AcceptsReturn = True
        Me.SecTypeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SecTypeText.Location = New System.Drawing.Point(226, 78)
        Me.SecTypeText.Name = "SecTypeText"
        Me.SecTypeText.Size = New System.Drawing.Size(88, 23)
        Me.SecTypeText.TabIndex = 2
        Me.SecTypeText.Text = "STK"
        '
        'SymbolText
        '
        Me.SymbolText.AcceptsReturn = True
        Me.SymbolText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SymbolText.Location = New System.Drawing.Point(226, 50)
        Me.SymbolText.Name = "SymbolText"
        Me.SymbolText.Size = New System.Drawing.Size(88, 23)
        Me.SymbolText.TabIndex = 1
        Me.SymbolText.Text = "QQQ"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Strike"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Symbol"
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(14, 81)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(73, 17)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "Type"
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(14, 193)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(73, 17)
        Me.Label53.TabIndex = 12
        Me.Label53.Text = "Multiplier"
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(14, 248)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(97, 17)
        Me.Label54.TabIndex = 16
        Me.Label54.Text = "Primary Exchange"
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(14, 165)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(73, 17)
        Me.Label55.TabIndex = 10
        Me.Label55.Text = "Right"
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(14, 304)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(120, 21)
        Me.Label56.TabIndex = 20
        Me.Label56.Text = "Local Symbol"
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(14, 276)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(73, 17)
        Me.Label57.TabIndex = 18
        Me.Label57.Text = "Currency"
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(14, 221)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(73, 17)
        Me.Label58.TabIndex = 14
        Me.Label58.Text = "Exchange"
        '
        'ReqIdText
        '
        Me.ReqIdText.AcceptsReturn = True
        Me.ReqIdText.Location = New System.Drawing.Point(6, 45)
        Me.ReqIdText.Name = "ReqIdText"
        Me.ReqIdText.Size = New System.Drawing.Size(65, 23)
        Me.ReqIdText.TabIndex = 1
        Me.ReqIdText.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SnapshotMktDataCheck)
        Me.GroupBox1.Controls.Add(Me.GenericTickTagsText)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 558)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 64)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Market Data"
        Me.GroupBox1.TitleBackColor = System.Drawing.Color.Empty
        Me.GroupBox1.TitleFont = Nothing
        Me.GroupBox1.TitleForeColor = System.Drawing.Color.Empty
        '
        'SnapshotMktDataCheck
        '
        Me.SnapshotMktDataCheck.AutoSize = True
        Me.SnapshotMktDataCheck.Location = New System.Drawing.Point(17, 41)
        Me.SnapshotMktDataCheck.Name = "SnapshotMktDataCheck"
        Me.SnapshotMktDataCheck.Size = New System.Drawing.Size(75, 19)
        Me.SnapshotMktDataCheck.TabIndex = 1
        Me.SnapshotMktDataCheck.Text = "Snapshot"
        '
        'GenericTickTagsText
        '
        Me.GenericTickTagsText.AcceptsReturn = True
        Me.GenericTickTagsText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GenericTickTagsText.Location = New System.Drawing.Point(226, 19)
        Me.GenericTickTagsText.Name = "GenericTickTagsText"
        Me.GenericTickTagsText.Size = New System.Drawing.Size(88, 23)
        Me.GenericTickTagsText.TabIndex = 0
        Me.GenericTickTagsText.Text = "100,101,104,105,106,107,165,221,225,233,236,258,293,294,295,318"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(14, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(197, 22)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Generic Tick Tags"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ExerciseOverrideCheck)
        Me.GroupBox2.Controls.Add(Me.ExerciseQuantityText)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.ExerciseActionText)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 628)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(322, 108)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options Exercise"
        Me.GroupBox2.TitleBackColor = System.Drawing.Color.Empty
        Me.GroupBox2.TitleFont = Nothing
        Me.GroupBox2.TitleForeColor = System.Drawing.Color.Empty
        '
        'ExerciseOverrideCheck
        '
        Me.ExerciseOverrideCheck.AutoSize = True
        Me.ExerciseOverrideCheck.Location = New System.Drawing.Point(17, 74)
        Me.ExerciseOverrideCheck.Name = "ExerciseOverrideCheck"
        Me.ExerciseOverrideCheck.Size = New System.Drawing.Size(71, 19)
        Me.ExerciseOverrideCheck.TabIndex = 2
        Me.ExerciseOverrideCheck.Text = "Override"
        '
        'ExerciseQuantityText
        '
        Me.ExerciseQuantityText.AcceptsReturn = True
        Me.ExerciseQuantityText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExerciseQuantityText.Location = New System.Drawing.Point(226, 47)
        Me.ExerciseQuantityText.Name = "ExerciseQuantityText"
        Me.ExerciseQuantityText.Size = New System.Drawing.Size(88, 23)
        Me.ExerciseQuantityText.TabIndex = 1
        Me.ExerciseQuantityText.Text = "1"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(14, 48)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(197, 23)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Number of Contracts"
        '
        'ExerciseActionText
        '
        Me.ExerciseActionText.AcceptsReturn = True
        Me.ExerciseActionText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExerciseActionText.Location = New System.Drawing.Point(226, 19)
        Me.ExerciseActionText.Name = "ExerciseActionText"
        Me.ExerciseActionText.Size = New System.Drawing.Size(88, 23)
        Me.ExerciseActionText.TabIndex = 0
        Me.ExerciseActionText.Text = "1"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(14, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(88, 17)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Action (1 or 2)"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(14, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(154, 20)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Order ID (0 for new order)"
        '
        'OrderIdText
        '
        Me.OrderIdText.AcceptsReturn = True
        Me.OrderIdText.Location = New System.Drawing.Point(226, 22)
        Me.OrderIdText.Name = "OrderIdText"
        Me.OrderIdText.Size = New System.Drawing.Size(88, 23)
        Me.OrderIdText.TabIndex = 0
        Me.OrderIdText.Text = "0"
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(6, 25)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 17)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "Request ID"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.NumRowsText)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 497)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(322, 55)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Market Depth"
        Me.GroupBox4.TitleBackColor = System.Drawing.Color.Empty
        Me.GroupBox4.TitleFont = Nothing
        Me.GroupBox4.TitleForeColor = System.Drawing.Color.Empty
        '
        'NumRowsText
        '
        Me.NumRowsText.AcceptsReturn = True
        Me.NumRowsText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumRowsText.Location = New System.Drawing.Point(226, 19)
        Me.NumRowsText.Name = "NumRowsText"
        Me.NumRowsText.Size = New System.Drawing.Size(88, 23)
        Me.NumRowsText.TabIndex = 0
        Me.NumRowsText.Text = "20"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Max Market Depth Rows"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(14, 109)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(89, 17)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Order Type"
        '
        'SetShareAllocationButton
        '
        Me.SetShareAllocationButton.Location = New System.Drawing.Point(17, 283)
        Me.SetShareAllocationButton.Name = "SetShareAllocationButton"
        Me.SetShareAllocationButton.Size = New System.Drawing.Size(138, 30)
        Me.SetShareAllocationButton.TabIndex = 9
        Me.SetShareAllocationButton.Text = "FA Alloc"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(14, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Action"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(14, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 17)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Quantity"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(13, 139)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(155, 25)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Lmt/Opt Price / Volatility"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(13, 165)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 17)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Aux/Under Price"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(14, 222)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 17)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Good Till Date"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(14, 194)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 17)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Good After Time"
        '
        'ActionText
        '
        Me.ActionText.AcceptsReturn = True
        Me.ActionText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActionText.Location = New System.Drawing.Point(226, 50)
        Me.ActionText.Name = "ActionText"
        Me.ActionText.Size = New System.Drawing.Size(88, 23)
        Me.ActionText.TabIndex = 1
        Me.ActionText.Text = "BUY"
        '
        'QuantityText
        '
        Me.QuantityText.AcceptsReturn = True
        Me.QuantityText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuantityText.Location = New System.Drawing.Point(226, 78)
        Me.QuantityText.Name = "QuantityText"
        Me.QuantityText.Size = New System.Drawing.Size(88, 23)
        Me.QuantityText.TabIndex = 2
        Me.QuantityText.Text = "10"
        '
        'OrderTypeText
        '
        Me.OrderTypeText.AcceptsReturn = True
        Me.OrderTypeText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OrderTypeText.Location = New System.Drawing.Point(226, 106)
        Me.OrderTypeText.Name = "OrderTypeText"
        Me.OrderTypeText.Size = New System.Drawing.Size(88, 23)
        Me.OrderTypeText.TabIndex = 3
        Me.OrderTypeText.Text = "LMT"
        '
        'LimitPriceText
        '
        Me.LimitPriceText.AcceptsReturn = True
        Me.LimitPriceText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LimitPriceText.Location = New System.Drawing.Point(226, 134)
        Me.LimitPriceText.Name = "LimitPriceText"
        Me.LimitPriceText.Size = New System.Drawing.Size(88, 23)
        Me.LimitPriceText.TabIndex = 4
        Me.LimitPriceText.Text = "40"
        '
        'AuxPriceText
        '
        Me.AuxPriceText.AcceptsReturn = True
        Me.AuxPriceText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AuxPriceText.Location = New System.Drawing.Point(226, 162)
        Me.AuxPriceText.Name = "AuxPriceText"
        Me.AuxPriceText.Size = New System.Drawing.Size(88, 23)
        Me.AuxPriceText.TabIndex = 5
        Me.AuxPriceText.Text = "0"
        '
        'AddCmboLegsButton
        '
        Me.AddCmboLegsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddCmboLegsButton.Location = New System.Drawing.Point(176, 282)
        Me.AddCmboLegsButton.Name = "AddCmboLegsButton"
        Me.AddCmboLegsButton.Size = New System.Drawing.Size(138, 30)
        Me.AddCmboLegsButton.TabIndex = 10
        Me.AddCmboLegsButton.Text = "Combo Legs"
        '
        'GTDText
        '
        Me.GTDText.AcceptsReturn = True
        Me.GTDText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GTDText.Location = New System.Drawing.Point(226, 218)
        Me.GTDText.Name = "GTDText"
        Me.GTDText.Size = New System.Drawing.Size(88, 23)
        Me.GTDText.TabIndex = 7
        '
        'GATText
        '
        Me.GATText.AcceptsReturn = True
        Me.GATText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GATText.Location = New System.Drawing.Point(226, 190)
        Me.GATText.Name = "GATText"
        Me.GATText.Size = New System.Drawing.Size(88, 23)
        Me.GATText.TabIndex = 6
        '
        'DeltaNeutralContractButton
        '
        Me.DeltaNeutralContractButton.Location = New System.Drawing.Point(17, 319)
        Me.DeltaNeutralContractButton.Name = "DeltaNeutralContractButton"
        Me.DeltaNeutralContractButton.Size = New System.Drawing.Size(138, 30)
        Me.DeltaNeutralContractButton.TabIndex = 11
        Me.DeltaNeutralContractButton.Text = "Delta Neutral"
        '
        'AlgoParamsButton
        '
        Me.AlgoParamsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlgoParamsButton.Location = New System.Drawing.Point(176, 318)
        Me.AlgoParamsButton.Name = "AlgoParamsButton"
        Me.AlgoParamsButton.Size = New System.Drawing.Size(138, 30)
        Me.AlgoParamsButton.TabIndex = 12
        Me.AlgoParamsButton.Text = "Algo Params"
        '
        'OrderDescFrame
        '
        Me.OrderDescFrame.Controls.Add(Me.Label21)
        Me.OrderDescFrame.Controls.Add(Me.CashQtyText)
        Me.OrderDescFrame.Controls.Add(Me.OrderIdText)
        Me.OrderDescFrame.Controls.Add(Me.CashQtyLabel)
        Me.OrderDescFrame.Controls.Add(Me.PegBenchButton)
        Me.OrderDescFrame.Controls.Add(Me.AdjustStopButton)
        Me.OrderDescFrame.Controls.Add(Me.ConditionsButton)
        Me.OrderDescFrame.Controls.Add(Me.OptionsButton)
        Me.OrderDescFrame.Controls.Add(Me.SmartComboRoutingParamsButton)
        Me.OrderDescFrame.Controls.Add(Me.AlgoParamsButton)
        Me.OrderDescFrame.Controls.Add(Me.DeltaNeutralContractButton)
        Me.OrderDescFrame.Controls.Add(Me.GATText)
        Me.OrderDescFrame.Controls.Add(Me.GTDText)
        Me.OrderDescFrame.Controls.Add(Me.AddCmboLegsButton)
        Me.OrderDescFrame.Controls.Add(Me.AuxPriceText)
        Me.OrderDescFrame.Controls.Add(Me.LimitPriceText)
        Me.OrderDescFrame.Controls.Add(Me.OrderTypeText)
        Me.OrderDescFrame.Controls.Add(Me.QuantityText)
        Me.OrderDescFrame.Controls.Add(Me.ActionText)
        Me.OrderDescFrame.Controls.Add(Me.Label16)
        Me.OrderDescFrame.Controls.Add(Me.Label15)
        Me.OrderDescFrame.Controls.Add(Me.Label14)
        Me.OrderDescFrame.Controls.Add(Me.Label13)
        Me.OrderDescFrame.Controls.Add(Me.Label11)
        Me.OrderDescFrame.Controls.Add(Me.Label10)
        Me.OrderDescFrame.Controls.Add(Me.SetShareAllocationButton)
        Me.OrderDescFrame.Controls.Add(Me.Label27)
        Me.OrderDescFrame.Location = New System.Drawing.Point(352, 20)
        Me.OrderDescFrame.Name = "OrderDescFrame"
        Me.OrderDescFrame.Size = New System.Drawing.Size(322, 471)
        Me.OrderDescFrame.TabIndex = 6
        Me.OrderDescFrame.TabStop = False
        Me.OrderDescFrame.Text = "Order Description"
        Me.OrderDescFrame.TitleBackColor = System.Drawing.Color.Empty
        Me.OrderDescFrame.TitleFont = Nothing
        Me.OrderDescFrame.TitleForeColor = System.Drawing.Color.Empty
        '
        'CashQtyText
        '
        Me.CashQtyText.AcceptsReturn = True
        Me.CashQtyText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CashQtyText.Location = New System.Drawing.Point(226, 246)
        Me.CashQtyText.Name = "CashQtyText"
        Me.CashQtyText.Size = New System.Drawing.Size(88, 23)
        Me.CashQtyText.TabIndex = 8
        '
        'CashQtyLabel
        '
        Me.CashQtyLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.CashQtyLabel.Location = New System.Drawing.Point(14, 251)
        Me.CashQtyLabel.Name = "CashQtyLabel"
        Me.CashQtyLabel.Size = New System.Drawing.Size(89, 17)
        Me.CashQtyLabel.TabIndex = 14
        Me.CashQtyLabel.Text = "Cash Qty"
        '
        'PegBenchButton
        '
        Me.PegBenchButton.Location = New System.Drawing.Point(17, 427)
        Me.PegBenchButton.Name = "PegBenchButton"
        Me.PegBenchButton.Size = New System.Drawing.Size(138, 30)
        Me.PegBenchButton.TabIndex = 17
        Me.PegBenchButton.Text = "Pegged to benchmark"
        '
        'AdjustStopButton
        '
        Me.AdjustStopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdjustStopButton.Location = New System.Drawing.Point(176, 390)
        Me.AdjustStopButton.Name = "AdjustStopButton"
        Me.AdjustStopButton.Size = New System.Drawing.Size(138, 30)
        Me.AdjustStopButton.TabIndex = 16
        Me.AdjustStopButton.Text = "Adjustable stops"
        '
        'ConditionsButton
        '
        Me.ConditionsButton.Location = New System.Drawing.Point(17, 391)
        Me.ConditionsButton.Name = "ConditionsButton"
        Me.ConditionsButton.Size = New System.Drawing.Size(138, 30)
        Me.ConditionsButton.TabIndex = 15
        Me.ConditionsButton.Text = "Conditions"
        '
        'OptionsButton
        '
        Me.OptionsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OptionsButton.Enabled = False
        Me.OptionsButton.Location = New System.Drawing.Point(176, 354)
        Me.OptionsButton.Name = "OptionsButton"
        Me.OptionsButton.Size = New System.Drawing.Size(138, 30)
        Me.OptionsButton.TabIndex = 14
        Me.OptionsButton.Text = "Options"
        '
        'SmartComboRoutingParamsButton
        '
        Me.SmartComboRoutingParamsButton.Location = New System.Drawing.Point(17, 355)
        Me.SmartComboRoutingParamsButton.Name = "SmartComboRoutingParamsButton"
        Me.SmartComboRoutingParamsButton.Size = New System.Drawing.Size(138, 30)
        Me.SmartComboRoutingParamsButton.TabIndex = 13
        Me.SmartComboRoutingParamsButton.Text = "Combo Rou Params"
        '
        'MarketDataTypeLabel
        '
        Me.MarketDataTypeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.MarketDataTypeLabel.Location = New System.Drawing.Point(14, 21)
        Me.MarketDataTypeLabel.Name = "MarketDataTypeLabel"
        Me.MarketDataTypeLabel.Size = New System.Drawing.Size(96, 17)
        Me.MarketDataTypeLabel.TabIndex = 0
        Me.MarketDataTypeLabel.Text = "Market Data Type"
        '
        'MarketDataTypeFrame
        '
        Me.MarketDataTypeFrame.Controls.Add(Me.MarketDataTypeCombo)
        Me.MarketDataTypeFrame.Controls.Add(Me.MarketDataTypeLabel)
        Me.MarketDataTypeFrame.Location = New System.Drawing.Point(8, 742)
        Me.MarketDataTypeFrame.Name = "MarketDataTypeFrame"
        Me.MarketDataTypeFrame.Size = New System.Drawing.Size(322, 52)
        Me.MarketDataTypeFrame.TabIndex = 5
        Me.MarketDataTypeFrame.TabStop = False
        Me.MarketDataTypeFrame.Text = "Market Data Type"
        Me.MarketDataTypeFrame.TitleBackColor = System.Drawing.Color.Empty
        Me.MarketDataTypeFrame.TitleFont = Nothing
        Me.MarketDataTypeFrame.TitleForeColor = System.Drawing.Color.Empty
        '
        'MarketDataTypeCombo
        '
        Me.MarketDataTypeCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MarketDataTypeCombo.FormattingEnabled = True
        Me.MarketDataTypeCombo.Location = New System.Drawing.Point(226, 18)
        Me.MarketDataTypeCombo.Name = "MarketDataTypeCombo"
        Me.MarketDataTypeCombo.Size = New System.Drawing.Size(88, 23)
        Me.MarketDataTypeCombo.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.ReqIdText)
        Me.GroupBox5.Controls.Add(Me.OkButton)
        Me.GroupBox5.Controls.Add(Me.CancelItButton)
        Me.GroupBox5.Location = New System.Drawing.Point(691, 20)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(80, 142)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.TitleBackColor = System.Drawing.Color.Empty
        Me.GroupBox5.TitleFont = Nothing
        Me.GroupBox5.TitleForeColor = System.Drawing.Color.Empty
        '
        'FOrder
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelItButton
        Me.ClientSize = New System.Drawing.Size(781, 809)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.MarketDataTypeFrame)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.OrderDescFrame)
        Me.Controls.Add(Me.TickerDescFrame)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(-66, 115)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FOrder"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Market Data"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.TickerDescFrame.ResumeLayout(False)
        Me.TickerDescFrame.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.OrderDescFrame.ResumeLayout(False)
        Me.OrderDescFrame.PerformLayout()
        Me.MarketDataTypeFrame.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    ' Enums
    Friend Enum OrderFormMode
        RequestMarketData = 1
        CancelMarketData
        RequestMarketDepth
        CancelMarketDepth
        PlaceOrder
        CancelOrder
        RequestContractDetails
        RequestHistoricalData
        ExerciseOptions
        CancelHistoricalData
        RequestRealtimeBars
        CancelRealtimeBars
        CalculateImpliedVolatility
        CalculateOptionPrice
        CancelCalculateImpliedVolatility
        CancelCalculateOptionPrice
        RequestMarketDataType
        RequestFundamentalData
        CancelFundamentalData
        RequestMatchingSymbols
        RequestHistoricalTicks
        RequestTickByTick
        CancelTickByTick
    End Enum

    ' ========================================================
    ' Member variables
    ' ========================================================

    Private mMainWnd As MainForm

    Private ReadOnly mFormTitles As Dictionary(Of OrderFormMode, String) = New Dictionary(Of OrderFormMode, String) From {
        {OrderFormMode.RequestMarketData, "Request Market Data"},
        {OrderFormMode.CancelMarketData, "Cancel Market Data"},
        {OrderFormMode.RequestMarketDepth, "Request Market Depth"},
        {OrderFormMode.CancelMarketDepth, "Cancel Market Depth"},
        {OrderFormMode.PlaceOrder, "Place Order"},
        {OrderFormMode.CancelOrder, "Cancel Order"},
        {OrderFormMode.RequestContractDetails, "Request Contract Details"},
        {OrderFormMode.RequestHistoricalData, "Request Historical Data"},
        {OrderFormMode.ExerciseOptions, "Exercise Options"},
        {OrderFormMode.CancelHistoricalData, "Cancel Historical Data"},
        {OrderFormMode.RequestRealtimeBars, "Request Real Time Bars"},
        {OrderFormMode.CancelRealtimeBars, "Cancel Real Time Bars"},
        {OrderFormMode.CalculateImpliedVolatility, "Calculate Implied Volatility"},
        {OrderFormMode.CalculateOptionPrice, "Calculate Option Price"},
        {OrderFormMode.CancelCalculateImpliedVolatility, "Cancel Calculate Implied Volatility"},
        {OrderFormMode.CancelCalculateOptionPrice, "Cancel Calculate Option Price"},
        {OrderFormMode.RequestMarketDataType, "Request Market Data Type"},
        {OrderFormMode.RequestFundamentalData, "Request Fundamental Data"},
        {OrderFormMode.CancelFundamentalData, "Cancel Fundamental Data"},
        {OrderFormMode.RequestMatchingSymbols, "Request Matching Symbols"},
        {OrderFormMode.RequestHistoricalTicks, "Request Historical Ticks"},
        {OrderFormMode.RequestTickByTick, "Request Tick By Tick"},
        {OrderFormMode.CancelTickByTick, "Cancel Tick By Tick"}
}



    Private mFaMethod, mFaGroup, mFaPercentage As Object
    Private mFaProfile As String

    Private mMarketDataType As MarketDataType
    Private mOptionsFormTitle As String
    Private mOptions As List(Of TagValue)

    Private mErrorsText As TextboxDisplayManager

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        initialize()
    End Sub

    Public Sub Initialise(errorsText As TextboxDisplayManager)
        mErrorsText = errorsText
    End Sub

    ' ========================================================
    ' Properties
    ' ========================================================

    Public ReadOnly Property NumberOfTicks As Integer
        Get
            Return CInt(NumOfTicksText.Text)
        End Get
    End Property

    Public ReadOnly Property HistStartDateTime As Date?
        Get
            If String.IsNullOrEmpty(StartDateTimeText.Text) Then Return Nothing
            Return CDate(StartDateTimeText.Text)
        End Get
    End Property

    Public ReadOnly Property HistStartTimezone As String
        Get
            Return StartTimezoneText.Text
        End Get
    End Property

    Public ReadOnly Property IgnoreSize As Boolean
        Get
            Return IgnoreSizeCheck.Checked
        End Get
    End Property

    Friend ReadOnly Property ContractInfo As Contract = New Contract
    Friend ReadOnly Property OrderInfo As Order = New Order
    Friend ReadOnly Property DeltaNeutralContract As DeltaNeutralContract = New DeltaNeutralContract

    Public ReadOnly Property Options() As List(Of TagValue)
        Get
            Options = mOptions
        End Get
    End Property

    Public ReadOnly Property SecId As String
        Get
            Return SecIdText.Text
        End Get
    End Property

    Public ReadOnly Property SecIdType As String
        Get
            Return SecIdTypeText.Text
        End Get
    End Property

    Public Property HistBarSizeSetting() As String
        Get
            Return BarSizeSettingText.Text
        End Get
        Set(Value As String)
            BarSizeSettingText.Text = Value
        End Set
    End Property
    Public Property GenericTickTags() As String
        Get
            Return GenericTickTagsText.Text
        End Get
        Set(Value As String)
            GenericTickTagsText.Text = Value
        End Set
    End Property

    Public ReadOnly Property HistEndDateTime() As Date?
        Get
            If String.IsNullOrEmpty(EndDateTimeText.Text) Then Return Nothing
            Return CDate(EndDateTimeText.Text)
        End Get
    End Property

    Public ReadOnly Property HistEndTimezone As String
        Get
            Return EndTimezoneText.Text
        End Get
    End Property

    Public ReadOnly Property HistDuration() As String
        Get
            Return DurationText.Text
        End Get
    End Property

    Friend ReadOnly Property IncludeExpiredContracts As Boolean
        Get
            Return IncludeExpiredCheck.Checked
        End Get
    End Property

    Public ReadOnly Property KeepUpToDate As Boolean
        Get
            Return KeepUpToDateCheck.Checked
        End Get
    End Property

    Public ReadOnly Property WhatToShow() As String
        Get
            Return WhatToShowText.Text
        End Get
    End Property

    Public ReadOnly Property UseRTH() As Boolean
        Get
            Return UseRTHCheck.Checked
        End Get
    End Property

    Public ReadOnly Property OrderId() As Integer
        Get
            Return CInt(OrderIdText.Text)
        End Get
    End Property

    Public ReadOnly Property RequestId() As Integer
        Get
            Return CInt(ReqIdText.Text)
        End Get
    End Property

    Public ReadOnly Property ExerciseAction() As ExerciseAction
        Get
            Return CInt(ExerciseActionText.Text)
        End Get
    End Property

    Public ReadOnly Property ExerciseQuantity() As Integer
        Get
            Return CInt(ExerciseQuantityText.Text)
        End Get
    End Property

    Public ReadOnly Property ExerciseOverride() As Boolean
        Get
            Return ExerciseOverrideCheck.Checked
        End Get
    End Property

    Public Property NumRows() As Integer
        Get
            Return CInt(NumRowsText.Text)
        End Get
        Set(Value As Integer)
            NumRowsText.Text = CStr(Value)
        End Set
    End Property

    Public ReadOnly Property SnapshotMktData() As Boolean
        Get
            Return SnapshotMktDataCheck.CheckState
        End Get
    End Property

    Public ReadOnly Property MarketDataType() As MarketDataType
        Get
            Return mMarketDataType
        End Get
    End Property

    Public ReadOnly Property TickByTickDataType() As TickByTickDataType
        Get
            Return IBAPI.TickByTickDataTypes.Parse(TickByTickTypeCombo.Text, True)
        End Get
    End Property

    Public ReadOnly Property Ok() As Boolean
        Get
            Return DialogResult = DialogResult.OK
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub addCmboLegsButton_Click(sender As Object, e As EventArgs) Handles AddCmboLegsButton.Click

        Dim fComboLegs As New FComboOrderLegs

        fComboLegs.Init(ContractInfo.ComboLegs, OrderInfo.OrderComboLegs)
        fComboLegs.ShowDialog()

        If fComboLegs.Ok Then
            OrderInfo.OrderComboLegs = fComboLegs.OrderComboLegs.ToArray
        End If

    End Sub

    Private Sub algoParamsButton_Click(sender As Object, e As System.EventArgs) Handles AlgoParamsButton.Click
        Using f As New FAlgoParams

            f.Init(OrderInfo.AlgoStrategy, OrderInfo.AlgoParams)
            Dim res = f.ShowDialog()
            If res = DialogResult.OK Then
                OrderInfo.AlgoStrategy = f.AlgoStrategy
                OrderInfo.AlgoParams = f.AlgoParams
            End If
        End Using
    End Sub

    Private Sub setShareAllocationButton_Click(sender As Object, e As EventArgs) Handles SetShareAllocationButton.Click
        Dim f As New FSharesAllocation

        With f
            .Init((mMainWnd.FAManagedAccounts))
            .ShowDialog()
            If .Ok Then
                mFaGroup = .FaGroup
                mFaMethod = .FaMethod
                mFaPercentage = .FaPercentage
                mFaProfile = .FaProfile
            End If
        End With
    End Sub

    Private Sub underCompButton_Click(sender As Object, e As EventArgs) Handles DeltaNeutralContractButton.Click
        Dim f As New FDeltaNeutralContract

        With f
            .Init(DeltaNeutralContract)
            Dim res = .ShowDialog()
            Select Case res
                Case DialogResult.OK : ContractInfo.DeltaNeutralContract = DeltaNeutralContract
                Case DialogResult.Abort : ContractInfo.DeltaNeutralContract = Nothing
            End Select
        End With
    End Sub

    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        DialogResult = DialogResult.OK

        ' Move UI data into member fields
        ContractInfo.ConId = CInt(ConIdText.Text)
        ContractInfo.Symbol = SymbolText.Text.ToUpper

        If Not IBAPI.SecurityTypes.TryParse(SecTypeText.Text, ContractInfo.SecType, ignoreCase:=True) Then
            mErrorsText.DisplayMessage($"Invalid sec type - must be one of {String.Join(", ", IBAPI.SecurityTypes.ExternalNames)}")
            DialogResult = DialogResult.No
        End If
        ContractInfo.Expiry = ExpiryText.Text
        ContractInfo.Strike = CDbl(StrikeText.Text)
        If Not IBAPI.OptionRights.TryParse(RightText.Text, ContractInfo.OptRight, ignoreCase:=True) Then
            mErrorsText.DisplayMessage($"Invalid option right - must be one of {String.Join(", ", IBAPI.OptionRights.ExternalNames)}")
            DialogResult = DialogResult.No
        End If
        ContractInfo.Multiplier = If(MultiplierText.Text = "", 1, CInt(MultiplierText.Text))
        ContractInfo.Exchange = ExchangeText.Text.ToUpper
        ContractInfo.PrimaryExch = PrimaryExchangeText.Text.ToUpper
        ContractInfo.CurrencyCode = CurrencyText.Text.ToUpper
        ContractInfo.LocalSymbol = LocalSymbolText.Text.ToUpper
        ContractInfo.TradingClass = TradingClassText.Text.ToUpper

        OrderInfo.OrderId = CInt(OrderIdText.Text)
        If Not IBAPI.OrderActions.TryParse(ActionText.Text, OrderInfo.Action, ignoreCase:=True) Then
            mErrorsText.DisplayMessage($"Invalid order action - must be one of {String.Join(", ", IBAPI.OrderActions.ExternalNames)}")
            DialogResult = DialogResult.No
        End If
        OrderInfo.TotalQuantity = CDbl(QuantityText.Text)
        If Not IBAPI.OrderTypes.TryParse(OrderTypeText.Text, OrderInfo.OrderType, ignoreCase:=True) Then
            mErrorsText.DisplayMessage($"Invalid order type - must be one of {String.Join(", ", IBAPI.OrderTypes.ExternalNames)}")
            DialogResult = DialogResult.No
        End If
        OrderInfo.LmtPrice = IBAPI.NullableDoubleFromString(LimitPriceText.Text)
        OrderInfo.AuxPrice = IBAPI.NullableDoubleFromString(AuxPriceText.Text)
        OrderInfo.CashQty = IBAPI.NullableDoubleFromString(CashQtyText.Text)

        OrderInfo.GoodAfterTime = GATText.Text
        OrderInfo.GoodTillDate = GTDText.Text

        OrderInfo.FaGroup = mFaGroup
        OrderInfo.FaMethod = mFaMethod
        OrderInfo.FaPercentage = mFaPercentage
        OrderInfo.FaProfile = mFaProfile

        mMarketDataType = MarketDataTypeCombo.SelectedIndex + 1

        Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        DialogResult = DialogResult.Cancel
        Hide()
    End Sub

    ' ========================================================
    ' Public Methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Sets the dialog field and button states based on the dialog type
    '--------------------------------------------------------------------------------
    Public Sub Init(mode As OrderFormMode, options As List(Of TagValue),
        mainWindow As System.Windows.Forms.Form)

        mOptions = options

        mMainWnd = mainWindow
        Text = mFormTitles.Item(mode)

        SetShareAllocationButton.Enabled = (mMainWnd.IsFAAccount() And mode = OrderFormMode.PlaceOrder)
        AddCmboLegsButton.Enabled =
            (mode = OrderFormMode.PlaceOrder Or
            mode = OrderFormMode.RequestHistoricalData Or
            mode = OrderFormMode.RequestMarketData)

        DeltaNeutralContractButton.Enabled =
            (mode = OrderFormMode.PlaceOrder Or
            mode = OrderFormMode.RequestMarketData)

        AlgoParamsButton.Enabled =
            (mode = OrderFormMode.PlaceOrder)

        SmartComboRoutingParamsButton.Enabled =
            (mode = OrderFormMode.PlaceOrder)

        OptionsButton.Text = "Options"
        OptionsButton.Enabled = (mode = OrderFormMode.PlaceOrder Or
                                mode = OrderFormMode.RequestMarketData Or
                                mode = OrderFormMode.RequestMarketDepth Or
                                mode = OrderFormMode.RequestHistoricalData Or
                                mode = OrderFormMode.RequestHistoricalTicks Or
                                mode = OrderFormMode.RequestRealtimeBars)

        ReqIdText.Enabled = True
        OrderIdText.Enabled = (mode = OrderFormMode.PlaceOrder Or
                                mode = OrderFormMode.CancelOrder)
        BarSizeSettingText.Enabled = (mode = OrderFormMode.RequestHistoricalData Or
                            mode = OrderFormMode.RequestRealtimeBars)
        DurationText.Enabled = (mode = OrderFormMode.RequestHistoricalData)
        EndDateTimeText.Enabled = (mode = OrderFormMode.RequestHistoricalTicks Or
                                    mode = OrderFormMode.RequestHistoricalData)
        WhatToShowText.Enabled = (mode = OrderFormMode.RequestHistoricalData Or
                                 mode = OrderFormMode.RequestHistoricalTicks Or
                                 mode = OrderFormMode.RequestRealtimeBars Or
                                 mode = OrderFormMode.RequestFundamentalData)
        UseRTHCheck.Enabled = (mode = OrderFormMode.RequestHistoricalData Or
                               mode = OrderFormMode.RequestHistoricalTicks Or
                               mode = OrderFormMode.RequestRealtimeBars)
        GenericTickTagsText.Enabled = (mode = OrderFormMode.RequestMarketData)
        SnapshotMktDataCheck.Enabled = (mode = OrderFormMode.RequestMarketData)
        NumRowsText.Enabled = (mode = OrderFormMode.RequestMarketDepth)
        ExerciseActionText.Enabled = (mode = OrderFormMode.ExerciseOptions)
        ExerciseQuantityText.Enabled = (mode = OrderFormMode.ExerciseOptions)
        ExerciseOverrideCheck.Enabled = (mode = OrderFormMode.ExerciseOptions)
        IncludeExpiredCheck.Enabled = (mode = OrderFormMode.RequestHistoricalData Or
                                     mode = OrderFormMode.RequestContractDetails)

        MarketDataTypeCombo.Enabled = (mode = OrderFormMode.RequestMarketDataType)
        TickByTickTypeCombo.Enabled = (mode = OrderFormMode.RequestTickByTick)

        ' enable or disable contract fields
        Dim isEnabled = Not (mode = OrderFormMode.CancelMarketData Or
                           mode = OrderFormMode.CancelMarketDepth Or
                           mode = OrderFormMode.CancelOrder Or
                           mode = OrderFormMode.CancelHistoricalData Or
                           mode = OrderFormMode.CancelRealtimeBars Or
                           mode = OrderFormMode.CancelCalculateImpliedVolatility Or
                           mode = OrderFormMode.CancelCalculateOptionPrice Or
                           mode = OrderFormMode.RequestMarketDataType Or
                           mode = OrderFormMode.RequestMatchingSymbols Or
                           mode = OrderFormMode.CancelTickByTick)
        ConIdText.Enabled = isEnabled
        SymbolText.Enabled = isEnabled
        SecTypeText.Enabled = isEnabled
        ExpiryText.Enabled = isEnabled
        StrikeText.Enabled = isEnabled
        RightText.Enabled = isEnabled
        MultiplierText.Enabled = isEnabled
        ExchangeText.Enabled = isEnabled
        PrimaryExchangeText.Enabled = isEnabled
        CurrencyText.Enabled = isEnabled
        LocalSymbolText.Enabled = isEnabled
        TradingClassText.Enabled = isEnabled

        ' enable or disable order fields
        isEnabled = (mode = OrderFormMode.PlaceOrder)
        ActionText.Enabled = isEnabled
        QuantityText.Enabled = isEnabled
        OrderTypeText.Enabled = isEnabled
        LimitPriceText.Enabled = isEnabled
        AuxPriceText.Enabled = isEnabled
        GATText.Enabled = isEnabled
        GTDText.Enabled = isEnabled
        CashQtyText.Enabled = isEnabled

        If mode = OrderFormMode.CalculateImpliedVolatility Or mode = OrderFormMode.CalculateOptionPrice Then
            LimitPriceText.Enabled = True
            AuxPriceText.Enabled = True
        End If

        isEnabled = (mode = OrderFormMode.PlaceOrder Or mode = OrderFormMode.RequestContractDetails)
        SecIdTypeText.Enabled = isEnabled
        SecIdText.Enabled = isEnabled

        If mode = OrderFormMode.RequestMatchingSymbols Then
            SymbolText.Enabled = True
            ConIdText.Enabled = False
            ConditionsButton.Enabled = False
            AdjustStopButton.Enabled = False
            PegBenchButton.Enabled = False
        End If

        If mode = OrderFormMode.RequestMarketDataType Then
            MarketDataTypeCombo.Enabled = True
            ReqIdText.Enabled = False
            ConIdText.Enabled = False
            AlgoParamsButton.Enabled = False
            SmartComboRoutingParamsButton.Enabled = False
        End If

        If mode = OrderFormMode.PlaceOrder Then
            mOptionsFormTitle = "Order Options"
            OptionsButton.Text = "Order Options"
        End If

        If mode = OrderFormMode.RequestHistoricalData Then
            mOptionsFormTitle = "Chart Options"
            OptionsButton.Text = "Chart Options"
        End If

        If mode = OrderFormMode.RequestHistoricalTicks Then
            mOptionsFormTitle = "Historical Ticks Options"
            OptionsButton.Text = "Hist Ticks Options"
        End If

        If mode = OrderFormMode.RequestMarketData Then
            mOptionsFormTitle = "Market Data Options"
            OptionsButton.Text = "Market Data Options"
        End If

        If mode = OrderFormMode.RequestMarketDepth Then
            mOptionsFormTitle = "Market Depth Options"
            OptionsButton.Text = "Market Depth Options"
        End If

        If mode = OrderFormMode.RequestRealtimeBars Then
            mOptionsFormTitle = "Real Time Bars Options"
            OptionsButton.Text = "RTB Options"
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Set the various dialog title string for each dialog type and the initial
    ' dialog data.
    '--------------------------------------------------------------------------------
    Private Sub initialize()
        Me.TickByTickTypeCombo.Items.AddRange(IBAPI.TickByTickDataTypes.ExternalNames)

        EndDateTimeText.Text = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        MarketDataTypeCombo.Items.Clear()
        Dim index = MarketDataTypeCombo.Items.Add("Real-Time")
        MarketDataTypeCombo.Items.Add("Frozen")
        MarketDataTypeCombo.Items.Add("Delayed")
        MarketDataTypeCombo.Items.Add("Delayed-Frozen")
        MarketDataTypeCombo.SelectedIndex = index

    End Sub

    Private Sub smartComboRoutingParamsButton_Click(sender As System.Object, e As System.EventArgs) Handles SmartComboRoutingParamsButton.Click
        Static f As New FOptions

        f.Init(OrderInfo.SmartComboRoutingParams, "Smart Combo Routing Params")
        Dim res = f.ShowDialog()
        If res = DialogResult.OK Then
            OrderInfo.SmartComboRoutingParams = New List(Of TagValue)(f.Options)
        End If
        f.Hide()
    End Sub

    Private Sub optionsButton_Click(sender As System.Object, e As System.EventArgs) Handles OptionsButton.Click
        Dim f As New FOptions

        f.Init(mOptions, mOptionsFormTitle)
        Dim res = f.ShowDialog()
        If res = DialogResult.OK Then
            mOptions = New List(Of TagValue)(f.Options)
        End If
    End Sub


    Private Sub pegBenchButton_Click(sender As Object, e As EventArgs) Handles PegBenchButton.Click
        Dim f = New FPegBench(OrderInfo)
        f.ShowDialog()
    End Sub

    Private Sub conditionsButton_Click(sender As Object, e As EventArgs) Handles ConditionsButton.Click
        Dim f = New FConditions(OrderInfo)
        f.ShowDialog()
    End Sub

    Private Sub adjustStopButton_Click(sender As Object, e As EventArgs) Handles AdjustStopButton.Click
        Dim f = New FAdjustStop(OrderInfo)
        f.ShowDialog()
    End Sub
End Class
