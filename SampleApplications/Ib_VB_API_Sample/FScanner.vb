' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.



Imports TradeWright.IBAPI

Imports System.Collections.Generic

Friend Class FScanner
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
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents CancelSubscriptionButton As System.Windows.Forms.Button
    Public WithEvents SubscribeButton As System.Windows.Forms.Button
    Public WithEvents RequestParametersButton As System.Windows.Forms.Button
    Public WithEvents ReqIdText As System.Windows.Forms.TextBox
    Public WithEvents NumberOfRowsText As System.Windows.Forms.TextBox
    Public WithEvents InstrumentText As System.Windows.Forms.TextBox
    Public WithEvents LocationCodeText As System.Windows.Forms.TextBox
    Public WithEvents ScanCodeText As System.Windows.Forms.TextBox
    Public WithEvents AboveVolumeText As System.Windows.Forms.TextBox
    Public WithEvents MarketCapBelowText As System.Windows.Forms.TextBox
    Public WithEvents MoodyRatingAboveText As System.Windows.Forms.TextBox
    Public WithEvents AbovePriceText As System.Windows.Forms.TextBox
    Public WithEvents MarketCapAboveText As System.Windows.Forms.TextBox
    Public WithEvents BelowPriceText As System.Windows.Forms.TextBox
    Public WithEvents MoodyRatingBelowText As System.Windows.Forms.TextBox
    Public WithEvents SpRatingAboveText As System.Windows.Forms.TextBox
    Public WithEvents MaturityDateBelowText As System.Windows.Forms.TextBox
    Public WithEvents CouponRateBelowText As System.Windows.Forms.TextBox
    Public WithEvents ExcludeConvertiblesText As System.Windows.Forms.TextBox
    Public WithEvents SpRatingBelowText As System.Windows.Forms.TextBox
    Public WithEvents CouponRateAboveText As System.Windows.Forms.TextBox
    Public WithEvents MaturityDateAboveText As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents TickerDescFrame As System.Windows.Forms.GroupBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents ScannerSettingPairsText As System.Windows.Forms.TextBox
    Public WithEvents AverageOptionVolumeAboveText As System.Windows.Forms.TextBox
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents OptionsButton As System.Windows.Forms.Button
    Friend WithEvents FilterButton As Button
    Public WithEvents StockTypeFilterText As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CancelSubscriptionButton = New System.Windows.Forms.Button()
        Me.SubscribeButton = New System.Windows.Forms.Button()
        Me.RequestParametersButton = New System.Windows.Forms.Button()
        Me.ReqIdText = New System.Windows.Forms.TextBox()
        Me.TickerDescFrame = New System.Windows.Forms.GroupBox()
        Me.StockTypeFilterText = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.AverageOptionVolumeAboveText = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ScannerSettingPairsText = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.NumberOfRowsText = New System.Windows.Forms.TextBox()
        Me.InstrumentText = New System.Windows.Forms.TextBox()
        Me.LocationCodeText = New System.Windows.Forms.TextBox()
        Me.ScanCodeText = New System.Windows.Forms.TextBox()
        Me.AboveVolumeText = New System.Windows.Forms.TextBox()
        Me.MarketCapBelowText = New System.Windows.Forms.TextBox()
        Me.MoodyRatingAboveText = New System.Windows.Forms.TextBox()
        Me.AbovePriceText = New System.Windows.Forms.TextBox()
        Me.MarketCapAboveText = New System.Windows.Forms.TextBox()
        Me.BelowPriceText = New System.Windows.Forms.TextBox()
        Me.MoodyRatingBelowText = New System.Windows.Forms.TextBox()
        Me.SpRatingAboveText = New System.Windows.Forms.TextBox()
        Me.MaturityDateBelowText = New System.Windows.Forms.TextBox()
        Me.CouponRateBelowText = New System.Windows.Forms.TextBox()
        Me.ExcludeConvertiblesText = New System.Windows.Forms.TextBox()
        Me.SpRatingBelowText = New System.Windows.Forms.TextBox()
        Me.CouponRateAboveText = New System.Windows.Forms.TextBox()
        Me.MaturityDateAboveText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OptionsButton = New System.Windows.Forms.Button()
        Me.FilterButton = New System.Windows.Forms.Button()
        Me.TickerDescFrame.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelSubscriptionButton
        '
        Me.CancelSubscriptionButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelSubscriptionButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelSubscriptionButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelSubscriptionButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelSubscriptionButton.Location = New System.Drawing.Point(211, 576)
        Me.CancelSubscriptionButton.Name = "CancelSubscriptionButton"
        Me.CancelSubscriptionButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelSubscriptionButton.Size = New System.Drawing.Size(113, 25)
        Me.CancelSubscriptionButton.TabIndex = 5
        Me.CancelSubscriptionButton.Text = "Cancel Subscription"
        Me.CancelSubscriptionButton.UseVisualStyleBackColor = True
        '
        'SubscribeButton
        '
        Me.SubscribeButton.BackColor = System.Drawing.SystemColors.Control
        Me.SubscribeButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.SubscribeButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubscribeButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SubscribeButton.Location = New System.Drawing.Point(126, 576)
        Me.SubscribeButton.Name = "SubscribeButton"
        Me.SubscribeButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SubscribeButton.Size = New System.Drawing.Size(78, 25)
        Me.SubscribeButton.TabIndex = 4
        Me.SubscribeButton.Text = "Subscribe"
        Me.SubscribeButton.UseVisualStyleBackColor = True
        '
        'RequestParametersButton
        '
        Me.RequestParametersButton.BackColor = System.Drawing.SystemColors.Control
        Me.RequestParametersButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.RequestParametersButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequestParametersButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RequestParametersButton.Location = New System.Drawing.Point(0, 576)
        Me.RequestParametersButton.Name = "RequestParametersButton"
        Me.RequestParametersButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RequestParametersButton.Size = New System.Drawing.Size(121, 25)
        Me.RequestParametersButton.TabIndex = 3
        Me.RequestParametersButton.Text = "Request Parameters"
        Me.RequestParametersButton.UseVisualStyleBackColor = True
        '
        'ReqIdText
        '
        Me.ReqIdText.AcceptsReturn = True
        Me.ReqIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ReqIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReqIdText.Location = New System.Drawing.Point(200, 24)
        Me.ReqIdText.MaxLength = 0
        Me.ReqIdText.Name = "ReqIdText"
        Me.ReqIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqIdText.Size = New System.Drawing.Size(185, 13)
        Me.ReqIdText.TabIndex = 1
        Me.ReqIdText.Text = "0"
        '
        'TickerDescFrame
        '
        Me.TickerDescFrame.BackColor = System.Drawing.Color.Gainsboro
        Me.TickerDescFrame.Controls.Add(Me.StockTypeFilterText)
        Me.TickerDescFrame.Controls.Add(Me.Label22)
        Me.TickerDescFrame.Controls.Add(Me.AverageOptionVolumeAboveText)
        Me.TickerDescFrame.Controls.Add(Me.Label21)
        Me.TickerDescFrame.Controls.Add(Me.ScannerSettingPairsText)
        Me.TickerDescFrame.Controls.Add(Me.Label20)
        Me.TickerDescFrame.Controls.Add(Me.NumberOfRowsText)
        Me.TickerDescFrame.Controls.Add(Me.InstrumentText)
        Me.TickerDescFrame.Controls.Add(Me.LocationCodeText)
        Me.TickerDescFrame.Controls.Add(Me.ScanCodeText)
        Me.TickerDescFrame.Controls.Add(Me.AboveVolumeText)
        Me.TickerDescFrame.Controls.Add(Me.MarketCapBelowText)
        Me.TickerDescFrame.Controls.Add(Me.MoodyRatingAboveText)
        Me.TickerDescFrame.Controls.Add(Me.AbovePriceText)
        Me.TickerDescFrame.Controls.Add(Me.MarketCapAboveText)
        Me.TickerDescFrame.Controls.Add(Me.BelowPriceText)
        Me.TickerDescFrame.Controls.Add(Me.MoodyRatingBelowText)
        Me.TickerDescFrame.Controls.Add(Me.SpRatingAboveText)
        Me.TickerDescFrame.Controls.Add(Me.MaturityDateBelowText)
        Me.TickerDescFrame.Controls.Add(Me.CouponRateBelowText)
        Me.TickerDescFrame.Controls.Add(Me.ExcludeConvertiblesText)
        Me.TickerDescFrame.Controls.Add(Me.SpRatingBelowText)
        Me.TickerDescFrame.Controls.Add(Me.CouponRateAboveText)
        Me.TickerDescFrame.Controls.Add(Me.MaturityDateAboveText)
        Me.TickerDescFrame.Controls.Add(Me.Label2)
        Me.TickerDescFrame.Controls.Add(Me.Label19)
        Me.TickerDescFrame.Controls.Add(Me.Label16)
        Me.TickerDescFrame.Controls.Add(Me.Label15)
        Me.TickerDescFrame.Controls.Add(Me.Label14)
        Me.TickerDescFrame.Controls.Add(Me.Label13)
        Me.TickerDescFrame.Controls.Add(Me.Label12)
        Me.TickerDescFrame.Controls.Add(Me.Label11)
        Me.TickerDescFrame.Controls.Add(Me.Label10)
        Me.TickerDescFrame.Controls.Add(Me.Label3)
        Me.TickerDescFrame.Controls.Add(Me.Label4)
        Me.TickerDescFrame.Controls.Add(Me.Label5)
        Me.TickerDescFrame.Controls.Add(Me.Label6)
        Me.TickerDescFrame.Controls.Add(Me.Label7)
        Me.TickerDescFrame.Controls.Add(Me.Label8)
        Me.TickerDescFrame.Controls.Add(Me.Label9)
        Me.TickerDescFrame.Controls.Add(Me.Label17)
        Me.TickerDescFrame.Controls.Add(Me.Label18)
        Me.TickerDescFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TickerDescFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TickerDescFrame.Location = New System.Drawing.Point(0, 56)
        Me.TickerDescFrame.Name = "TickerDescFrame"
        Me.TickerDescFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TickerDescFrame.Size = New System.Drawing.Size(393, 512)
        Me.TickerDescFrame.TabIndex = 2
        Me.TickerDescFrame.TabStop = False
        Me.TickerDescFrame.Text = "Subscription Info"
        '
        'StockTypeFilterText
        '
        Me.StockTypeFilterText.AcceptsReturn = True
        Me.StockTypeFilterText.BackColor = System.Drawing.SystemColors.Window
        Me.StockTypeFilterText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StockTypeFilterText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.StockTypeFilterText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockTypeFilterText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.StockTypeFilterText.Location = New System.Drawing.Point(200, 484)
        Me.StockTypeFilterText.MaxLength = 0
        Me.StockTypeFilterText.Name = "StockTypeFilterText"
        Me.StockTypeFilterText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StockTypeFilterText.Size = New System.Drawing.Size(185, 13)
        Me.StockTypeFilterText.TabIndex = 41
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Gainsboro
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(16, 487)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(113, 17)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "Stock Type Filter"
        '
        'AverageOptionVolumeAboveText
        '
        Me.AverageOptionVolumeAboveText.AcceptsReturn = True
        Me.AverageOptionVolumeAboveText.BackColor = System.Drawing.SystemColors.Window
        Me.AverageOptionVolumeAboveText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AverageOptionVolumeAboveText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AverageOptionVolumeAboveText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AverageOptionVolumeAboveText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AverageOptionVolumeAboveText.Location = New System.Drawing.Point(200, 185)
        Me.AverageOptionVolumeAboveText.MaxLength = 0
        Me.AverageOptionVolumeAboveText.Name = "AverageOptionVolumeAboveText"
        Me.AverageOptionVolumeAboveText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AverageOptionVolumeAboveText.Size = New System.Drawing.Size(185, 13)
        Me.AverageOptionVolumeAboveText.TabIndex = 15
        Me.AverageOptionVolumeAboveText.Text = "0"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Gainsboro
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(16, 188)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(160, 17)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Average Option Volume Above"
        '
        'ScannerSettingPairsText
        '
        Me.ScannerSettingPairsText.AcceptsReturn = True
        Me.ScannerSettingPairsText.BackColor = System.Drawing.SystemColors.Window
        Me.ScannerSettingPairsText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScannerSettingPairsText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScannerSettingPairsText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScannerSettingPairsText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScannerSettingPairsText.Location = New System.Drawing.Point(200, 461)
        Me.ScannerSettingPairsText.MaxLength = 0
        Me.ScannerSettingPairsText.Name = "ScannerSettingPairsText"
        Me.ScannerSettingPairsText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScannerSettingPairsText.Size = New System.Drawing.Size(185, 13)
        Me.ScannerSettingPairsText.TabIndex = 39
        Me.ScannerSettingPairsText.Text = "Annual,true"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Gainsboro
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(16, 464)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(113, 17)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "Scanner Setting Pairs"
        '
        'NumberOfRowsText
        '
        Me.NumberOfRowsText.AcceptsReturn = True
        Me.NumberOfRowsText.BackColor = System.Drawing.SystemColors.Window
        Me.NumberOfRowsText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberOfRowsText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NumberOfRowsText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfRowsText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberOfRowsText.Location = New System.Drawing.Point(200, 24)
        Me.NumberOfRowsText.MaxLength = 0
        Me.NumberOfRowsText.Name = "NumberOfRowsText"
        Me.NumberOfRowsText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberOfRowsText.Size = New System.Drawing.Size(185, 13)
        Me.NumberOfRowsText.TabIndex = 1
        Me.NumberOfRowsText.Text = "10"
        '
        'InstrumentText
        '
        Me.InstrumentText.AcceptsReturn = True
        Me.InstrumentText.BackColor = System.Drawing.SystemColors.Window
        Me.InstrumentText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.InstrumentText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.InstrumentText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstrumentText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.InstrumentText.Location = New System.Drawing.Point(200, 47)
        Me.InstrumentText.MaxLength = 0
        Me.InstrumentText.Name = "InstrumentText"
        Me.InstrumentText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.InstrumentText.Size = New System.Drawing.Size(185, 13)
        Me.InstrumentText.TabIndex = 3
        Me.InstrumentText.Text = "STK"
        '
        'LocationCodeText
        '
        Me.LocationCodeText.AcceptsReturn = True
        Me.LocationCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.LocationCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LocationCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LocationCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LocationCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LocationCodeText.Location = New System.Drawing.Point(200, 70)
        Me.LocationCodeText.MaxLength = 0
        Me.LocationCodeText.Name = "LocationCodeText"
        Me.LocationCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LocationCodeText.Size = New System.Drawing.Size(185, 13)
        Me.LocationCodeText.TabIndex = 5
        Me.LocationCodeText.Text = "STK.US.MAJOR"
        '
        'ScanCodeText
        '
        Me.ScanCodeText.AcceptsReturn = True
        Me.ScanCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.ScanCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScanCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScanCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScanCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScanCodeText.Location = New System.Drawing.Point(200, 93)
        Me.ScanCodeText.MaxLength = 0
        Me.ScanCodeText.Name = "ScanCodeText"
        Me.ScanCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScanCodeText.Size = New System.Drawing.Size(185, 13)
        Me.ScanCodeText.TabIndex = 7
        Me.ScanCodeText.Text = "TOP_PERC_GAIN"
        '
        'AboveVolumeText
        '
        Me.AboveVolumeText.AcceptsReturn = True
        Me.AboveVolumeText.BackColor = System.Drawing.SystemColors.Window
        Me.AboveVolumeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AboveVolumeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AboveVolumeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboveVolumeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AboveVolumeText.Location = New System.Drawing.Point(200, 162)
        Me.AboveVolumeText.MaxLength = 0
        Me.AboveVolumeText.Name = "AboveVolumeText"
        Me.AboveVolumeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AboveVolumeText.Size = New System.Drawing.Size(185, 13)
        Me.AboveVolumeText.TabIndex = 13
        Me.AboveVolumeText.Text = "0"
        '
        'MarketCapBelowText
        '
        Me.MarketCapBelowText.AcceptsReturn = True
        Me.MarketCapBelowText.BackColor = System.Drawing.SystemColors.Window
        Me.MarketCapBelowText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MarketCapBelowText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MarketCapBelowText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarketCapBelowText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MarketCapBelowText.Location = New System.Drawing.Point(200, 231)
        Me.MarketCapBelowText.MaxLength = 0
        Me.MarketCapBelowText.Name = "MarketCapBelowText"
        Me.MarketCapBelowText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MarketCapBelowText.Size = New System.Drawing.Size(185, 13)
        Me.MarketCapBelowText.TabIndex = 19
        '
        'MoodyRatingAboveText
        '
        Me.MoodyRatingAboveText.AcceptsReturn = True
        Me.MoodyRatingAboveText.BackColor = System.Drawing.SystemColors.Window
        Me.MoodyRatingAboveText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MoodyRatingAboveText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MoodyRatingAboveText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoodyRatingAboveText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MoodyRatingAboveText.Location = New System.Drawing.Point(200, 254)
        Me.MoodyRatingAboveText.MaxLength = 0
        Me.MoodyRatingAboveText.Name = "MoodyRatingAboveText"
        Me.MoodyRatingAboveText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MoodyRatingAboveText.Size = New System.Drawing.Size(185, 13)
        Me.MoodyRatingAboveText.TabIndex = 21
        '
        'AbovePriceText
        '
        Me.AbovePriceText.AcceptsReturn = True
        Me.AbovePriceText.BackColor = System.Drawing.SystemColors.Window
        Me.AbovePriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AbovePriceText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AbovePriceText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AbovePriceText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AbovePriceText.Location = New System.Drawing.Point(200, 116)
        Me.AbovePriceText.MaxLength = 0
        Me.AbovePriceText.Name = "AbovePriceText"
        Me.AbovePriceText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AbovePriceText.Size = New System.Drawing.Size(185, 13)
        Me.AbovePriceText.TabIndex = 9
        Me.AbovePriceText.Text = "3"
        '
        'MarketCapAboveText
        '
        Me.MarketCapAboveText.AcceptsReturn = True
        Me.MarketCapAboveText.BackColor = System.Drawing.SystemColors.Window
        Me.MarketCapAboveText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MarketCapAboveText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MarketCapAboveText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarketCapAboveText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MarketCapAboveText.Location = New System.Drawing.Point(200, 208)
        Me.MarketCapAboveText.MaxLength = 0
        Me.MarketCapAboveText.Name = "MarketCapAboveText"
        Me.MarketCapAboveText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MarketCapAboveText.Size = New System.Drawing.Size(185, 13)
        Me.MarketCapAboveText.TabIndex = 17
        Me.MarketCapAboveText.Text = "100000000"
        '
        'BelowPriceText
        '
        Me.BelowPriceText.AcceptsReturn = True
        Me.BelowPriceText.BackColor = System.Drawing.SystemColors.Window
        Me.BelowPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BelowPriceText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BelowPriceText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BelowPriceText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BelowPriceText.Location = New System.Drawing.Point(200, 139)
        Me.BelowPriceText.MaxLength = 0
        Me.BelowPriceText.Name = "BelowPriceText"
        Me.BelowPriceText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BelowPriceText.Size = New System.Drawing.Size(185, 13)
        Me.BelowPriceText.TabIndex = 11
        '
        'MoodyRatingBelowText
        '
        Me.MoodyRatingBelowText.AcceptsReturn = True
        Me.MoodyRatingBelowText.BackColor = System.Drawing.SystemColors.Window
        Me.MoodyRatingBelowText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MoodyRatingBelowText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MoodyRatingBelowText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoodyRatingBelowText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MoodyRatingBelowText.Location = New System.Drawing.Point(200, 277)
        Me.MoodyRatingBelowText.MaxLength = 0
        Me.MoodyRatingBelowText.Name = "MoodyRatingBelowText"
        Me.MoodyRatingBelowText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MoodyRatingBelowText.Size = New System.Drawing.Size(185, 13)
        Me.MoodyRatingBelowText.TabIndex = 23
        '
        'SpRatingAboveText
        '
        Me.SpRatingAboveText.AcceptsReturn = True
        Me.SpRatingAboveText.BackColor = System.Drawing.SystemColors.Window
        Me.SpRatingAboveText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SpRatingAboveText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SpRatingAboveText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpRatingAboveText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpRatingAboveText.Location = New System.Drawing.Point(200, 300)
        Me.SpRatingAboveText.MaxLength = 0
        Me.SpRatingAboveText.Name = "SpRatingAboveText"
        Me.SpRatingAboveText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpRatingAboveText.Size = New System.Drawing.Size(185, 13)
        Me.SpRatingAboveText.TabIndex = 25
        '
        'MaturityDateBelowText
        '
        Me.MaturityDateBelowText.AcceptsReturn = True
        Me.MaturityDateBelowText.BackColor = System.Drawing.SystemColors.Window
        Me.MaturityDateBelowText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaturityDateBelowText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MaturityDateBelowText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaturityDateBelowText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaturityDateBelowText.Location = New System.Drawing.Point(200, 369)
        Me.MaturityDateBelowText.MaxLength = 0
        Me.MaturityDateBelowText.Name = "MaturityDateBelowText"
        Me.MaturityDateBelowText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MaturityDateBelowText.Size = New System.Drawing.Size(185, 13)
        Me.MaturityDateBelowText.TabIndex = 31
        '
        'CouponRateBelowText
        '
        Me.CouponRateBelowText.AcceptsReturn = True
        Me.CouponRateBelowText.BackColor = System.Drawing.SystemColors.Window
        Me.CouponRateBelowText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CouponRateBelowText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CouponRateBelowText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CouponRateBelowText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CouponRateBelowText.Location = New System.Drawing.Point(200, 415)
        Me.CouponRateBelowText.MaxLength = 0
        Me.CouponRateBelowText.Name = "CouponRateBelowText"
        Me.CouponRateBelowText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CouponRateBelowText.Size = New System.Drawing.Size(185, 13)
        Me.CouponRateBelowText.TabIndex = 35
        '
        'ExcludeConvertiblesText
        '
        Me.ExcludeConvertiblesText.AcceptsReturn = True
        Me.ExcludeConvertiblesText.BackColor = System.Drawing.SystemColors.Window
        Me.ExcludeConvertiblesText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExcludeConvertiblesText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExcludeConvertiblesText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExcludeConvertiblesText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExcludeConvertiblesText.Location = New System.Drawing.Point(200, 438)
        Me.ExcludeConvertiblesText.MaxLength = 0
        Me.ExcludeConvertiblesText.Name = "ExcludeConvertiblesText"
        Me.ExcludeConvertiblesText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExcludeConvertiblesText.Size = New System.Drawing.Size(185, 13)
        Me.ExcludeConvertiblesText.TabIndex = 37
        Me.ExcludeConvertiblesText.Text = "0"
        '
        'SpRatingBelowText
        '
        Me.SpRatingBelowText.AcceptsReturn = True
        Me.SpRatingBelowText.BackColor = System.Drawing.SystemColors.Window
        Me.SpRatingBelowText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SpRatingBelowText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SpRatingBelowText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpRatingBelowText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpRatingBelowText.Location = New System.Drawing.Point(200, 323)
        Me.SpRatingBelowText.MaxLength = 0
        Me.SpRatingBelowText.Name = "SpRatingBelowText"
        Me.SpRatingBelowText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpRatingBelowText.Size = New System.Drawing.Size(185, 13)
        Me.SpRatingBelowText.TabIndex = 27
        '
        'CouponRateAboveText
        '
        Me.CouponRateAboveText.AcceptsReturn = True
        Me.CouponRateAboveText.BackColor = System.Drawing.SystemColors.Window
        Me.CouponRateAboveText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CouponRateAboveText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CouponRateAboveText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CouponRateAboveText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CouponRateAboveText.Location = New System.Drawing.Point(200, 392)
        Me.CouponRateAboveText.MaxLength = 0
        Me.CouponRateAboveText.Name = "CouponRateAboveText"
        Me.CouponRateAboveText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CouponRateAboveText.Size = New System.Drawing.Size(185, 13)
        Me.CouponRateAboveText.TabIndex = 33
        '
        'MaturityDateAboveText
        '
        Me.MaturityDateAboveText.AcceptsReturn = True
        Me.MaturityDateAboveText.BackColor = System.Drawing.SystemColors.Window
        Me.MaturityDateAboveText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaturityDateAboveText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MaturityDateAboveText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaturityDateAboveText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaturityDateAboveText.Location = New System.Drawing.Point(200, 346)
        Me.MaturityDateAboveText.MaxLength = 0
        Me.MaturityDateAboveText.Name = "MaturityDateAboveText"
        Me.MaturityDateAboveText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MaturityDateAboveText.Size = New System.Drawing.Size(185, 13)
        Me.MaturityDateAboveText.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Number of Rows"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Gainsboro
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(16, 280)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(129, 17)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Moody Rating Below"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Gainsboro
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(16, 303)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(113, 17)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "S and P Rating Above"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Gainsboro
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(16, 372)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(113, 17)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Maturity Date Below"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(16, 418)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(105, 17)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Coupon Rate Below"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(16, 441)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(113, 17)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Exclude Convertibles"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 326)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(113, 17)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "S and P Rating Below"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(16, 395)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(97, 17)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Coupon Rate Above"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(16, 349)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(113, 17)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Maturity Date Above"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(113, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Instrument"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Location Code"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Scan Code"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(88, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Above Volume"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(105, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Market Cap Below"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Moody Rating Above"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(73, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Above Price"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Gainsboro
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(16, 211)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(97, 17)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Market Cap Above"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Gainsboro
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(16, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(73, 17)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Below Price"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(0, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(393, 41)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Message Id"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'OptionsButton
        '
        Me.OptionsButton.Location = New System.Drawing.Point(327, 576)
        Me.OptionsButton.Name = "OptionsButton"
        Me.OptionsButton.Size = New System.Drawing.Size(66, 25)
        Me.OptionsButton.TabIndex = 6
        Me.OptionsButton.Text = "Options"
        Me.OptionsButton.UseVisualStyleBackColor = True
        '
        'FilterButton
        '
        Me.FilterButton.Location = New System.Drawing.Point(399, 576)
        Me.FilterButton.Name = "FilterButton"
        Me.FilterButton.Size = New System.Drawing.Size(66, 25)
        Me.FilterButton.TabIndex = 8
        Me.FilterButton.Text = "Filter"
        Me.FilterButton.UseVisualStyleBackColor = True
        '
        'fScanner
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(470, 605)
        Me.Controls.Add(Me.FilterButton)
        Me.Controls.Add(Me.OptionsButton)
        Me.Controls.Add(Me.CancelSubscriptionButton)
        Me.Controls.Add(Me.SubscribeButton)
        Me.Controls.Add(Me.RequestParametersButton)
        Me.Controls.Add(Me.ReqIdText)
        Me.Controls.Add(Me.TickerDescFrame)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "fScanner"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Market Scanner"
        Me.TickerDescFrame.ResumeLayout(False)
        Me.TickerDescFrame.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    Private mSubscription As ScannerSubscription
    Private mMainWnd As MainForm

    Private mId As Integer
    Private mOk As Boolean
    Private mOptions As List(Of TagValue)
    Private mFilterOptions As List(Of TagValue)

    ' ========================================================
    ' Public Methods
    ' ========================================================
    Public Sub Init(mainWin As System.Windows.Forms.Form)
        mOk = False
        mMainWnd = mainWin
        mSubscription = New ScannerSubscription
    End Sub

    ' ========================================================
    ' Private Methods
    ' ========================================================
    Private Sub cancelButton_Click()
        mOk = False
        Hide()
    End Sub

    Private Sub requestParametersButton_Click(sender As Object, e As EventArgs) Handles RequestParametersButton.Click
        mMainWnd.Api.RequestScannerParameters()
        Hide()
    End Sub

    Private Sub cancelSubscriptionButton_Click(sender As Object, e As EventArgs) Handles CancelSubscriptionButton.Click
        populateSubscription()
        mMainWnd.Api.CancelScannerSubscription(mId)
        Hide()
    End Sub

    Private Sub subscribeButton_Click(sender As Object, e As EventArgs) Handles SubscribeButton.Click
        populateSubscription()
        mMainWnd.Api.RequestScannerSubscription(mId, mSubscription, mOptions, mFilterOptions)
        Hide()
    End Sub

    Private Sub optionsButton_Click(sender As System.Object, e As System.EventArgs) Handles OptionsButton.Click
        Dim f As New FOptions
        f.init(mOptions, "Scanner Subscription Options")
        Dim res As DialogResult
        res = f.ShowDialog()
        If res = DialogResult.OK Then
            mOptions = New List(Of TagValue)(f.Options)
        End If
    End Sub

    Private Sub populateSubscription()
        mId = CInt(ReqIdText.Text)
        With mSubscription
            .NumberOfRows = IBAPI.NullableIntegerFromString(NumberOfRowsText.Text)
            .Instrument = InstrumentText.Text
            .LocationCode = LocationCodeText.Text
            .ScanCode = ScanCodeText.Text
            .AbovePrice = IBAPI.NullableDoubleFromString(AbovePriceText.Text)
            .BelowPrice = IBAPI.NullableDoubleFromString(BelowPriceText.Text)
            .AboveVolume = IBAPI.NullableIntegerFromString(AboveVolumeText.Text)
            .AverageOptionVolumeAbove = IBAPI.NullableIntegerFromString(AverageOptionVolumeAboveText.Text)
            .MarketCapAbove = IBAPI.NullableDoubleFromString(MarketCapAboveText.Text)
            .MarketCapBelow = IBAPI.NullableDoubleFromString(MarketCapBelowText.Text)
            .MoodyRatingAbove = MoodyRatingAboveText.Text
            .MoodyRatingBelow = MoodyRatingBelowText.Text
            .SpRatingAbove = SpRatingAboveText.Text
            .SpRatingBelow = SpRatingBelowText.Text
            .MaturityDateAbove = MaturityDateAboveText.Text
            .MaturityDateBelow = MaturityDateBelowText.Text
            .CouponRateAbove = IBAPI.NullableDoubleFromString(CouponRateAboveText.Text)
            .CouponRateBelow = IBAPI.NullableDoubleFromString(CouponRateBelowText.Text)
            .ExcludeConvertible = ExcludeConvertiblesText.Text
            .ScannerSettingPairs = ScannerSettingPairsText.Text
            .StockTypeFilter = StockTypeFilterText.Text
        End With
    End Sub

    Private Sub filterButton_Click(sender As Object, e As EventArgs) Handles FilterButton.Click
        Dim f As New FOptions

        f.init(mFilterOptions, "Scanner Subscription Filter Options")

        Dim res = f.ShowDialog()

        If res = DialogResult.OK Then
            mFilterOptions = New List(Of TagValue)(f.Options)
        End If
    End Sub
End Class
