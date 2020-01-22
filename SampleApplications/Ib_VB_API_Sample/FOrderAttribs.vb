' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.



Imports TradeWright.IBAPI

Public Class FOrderAttribs
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
            If Not mComponents Is Nothing Then
                mComponents.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private mComponents As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Rule80AText As System.Windows.Forms.TextBox
    Public WithEvents SettlingFirmText As System.Windows.Forms.TextBox
    Public WithEvents MinQtyText As System.Windows.Forms.TextBox
    Public WithEvents PercentOffsetText As System.Windows.Forms.TextBox
    Public WithEvents NBBOPriceCapText As System.Windows.Forms.TextBox
    Public WithEvents AuctionStrategyText As System.Windows.Forms.TextBox
    Public WithEvents StartingPriceText As System.Windows.Forms.TextBox
    Public WithEvents StockRefPriceText As System.Windows.Forms.TextBox
    Public WithEvents DeltaText As System.Windows.Forms.TextBox
    Public WithEvents StockRangeLowerText As System.Windows.Forms.TextBox
    Public WithEvents StockRangeUpperText As System.Windows.Forms.TextBox
    Public WithEvents OcaTypeText As System.Windows.Forms.TextBox
    Public WithEvents ShortSaleSlotText As System.Windows.Forms.TextBox
    Public WithEvents DesignatedLocationText As System.Windows.Forms.TextBox
    Public WithEvents DiscretionaryAmtText As System.Windows.Forms.TextBox
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents HiddenText As System.Windows.Forms.TextBox
    Public WithEvents TriggerMethodText As System.Windows.Forms.TextBox
    Public WithEvents DisplaySizeText As System.Windows.Forms.TextBox
    Public WithEvents ParentIdText As System.Windows.Forms.TextBox
    Public WithEvents OrderRefText As System.Windows.Forms.TextBox
    Public WithEvents OriginText As System.Windows.Forms.TextBox
    Public WithEvents OpenCloseText As System.Windows.Forms.TextBox
    Public WithEvents AccountText As System.Windows.Forms.TextBox
    Public WithEvents OCAText As System.Windows.Forms.TextBox
    Public WithEvents TIFText As System.Windows.Forms.TextBox
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents VolatilityText As System.Windows.Forms.TextBox
    Public WithEvents VolatilityTypeText As System.Windows.Forms.TextBox
    Public WithEvents ReferencePriceTypeText As System.Windows.Forms.TextBox
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents DeltaNeutralOrderTypeText As System.Windows.Forms.TextBox
    Public WithEvents DeltaNeutralAuxPriceText As System.Windows.Forms.TextBox
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents TrailStopPriceText As System.Windows.Forms.TextBox
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents ScaleInitLevelSizeText As System.Windows.Forms.TextBox
    Public WithEvents ScaleSubsLevelSizeText As System.Windows.Forms.TextBox
    Public WithEvents ScalePriceIncrText As System.Windows.Forms.TextBox
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents ClearingAccountText As System.Windows.Forms.TextBox
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents ClearingIntentText As System.Windows.Forms.TextBox
    Public WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents ExemptCodeText As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents HedgeTypeText As System.Windows.Forms.TextBox
    Public WithEvents HedgeParamText As System.Windows.Forms.TextBox
    Public WithEvents LabelHedgeType As System.Windows.Forms.Label
    Public WithEvents LabelHedgeParam As System.Windows.Forms.Label
    Friend WithEvents OptOutSmartRoutingCheck As System.Windows.Forms.CheckBox
    Public WithEvents Label47 As System.Windows.Forms.Label
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents Label49 As System.Windows.Forms.Label
    Public WithEvents Label50 As System.Windows.Forms.Label
    Public WithEvents DeltaNeutralConIdText As System.Windows.Forms.TextBox
    Public WithEvents DeltaNeutralClearingIntentText As System.Windows.Forms.TextBox
    Public WithEvents DeltaNeutralClearingAccountText As System.Windows.Forms.TextBox
    Public WithEvents DeltaNeutralSettlingFirmText As System.Windows.Forms.TextBox
    Public WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents Label52 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents ScaleAutoResetCheck As System.Windows.Forms.CheckBox
    Public WithEvents ScalePriceAdjustValueText As System.Windows.Forms.TextBox
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents ScaleRandomPercentCheck As System.Windows.Forms.CheckBox
    Public WithEvents ScalePriceAdjustIntervalText As System.Windows.Forms.TextBox
    Public WithEvents ScaleInitPositionText As System.Windows.Forms.TextBox
    Public WithEvents ScaleInitFillQtyText As System.Windows.Forms.TextBox
    Public WithEvents ScaleProfitOffsetText As System.Windows.Forms.TextBox
    Public WithEvents Label56 As System.Windows.Forms.Label
    Public WithEvents TrailingPercentText As System.Windows.Forms.TextBox
    Public WithEvents DeltaNeutralOpenCloseText As System.Windows.Forms.TextBox
    Public WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents DeltaNeutralShortSaleCheck As System.Windows.Forms.CheckBox
    Public WithEvents DeltaNeutralShortSaleSlotText As System.Windows.Forms.TextBox
    Public WithEvents Label58 As System.Windows.Forms.Label
    Public WithEvents DeltaNeutralDesignatedLocationText As System.Windows.Forms.TextBox
    Public WithEvents Label59 As System.Windows.Forms.Label
    Public WithEvents ActiveStopTimeText As System.Windows.Forms.TextBox
    Public WithEvents ActiveStartTimeText As System.Windows.Forms.TextBox
    Public WithEvents ScaleTableText As System.Windows.Forms.TextBox
    Public WithEvents Label60 As System.Windows.Forms.Label
    Public WithEvents Label61 As System.Windows.Forms.Label
    Public WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents SolicitedCheck As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizeSizeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents RandomizePriceCheck As System.Windows.Forms.CheckBox
    Public WithEvents ModelCodeText As System.Windows.Forms.TextBox
    Public WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents TransmitCheck As CheckBox
    Friend WithEvents DontUseAutoPriceForHedgeCheck As CheckBox
    Public WithEvents Mifid2ExecutionTraderText As TextBox
    Public WithEvents Label66 As Label
    Public WithEvents Mifid2ExecutionAlgoText As TextBox
    Public WithEvents Label67 As Label
    Public WithEvents Mifid2DecisionMakerText As TextBox
    Public WithEvents Label64 As Label
    Public WithEvents Mifid2DecisionAlgoText As TextBox
    Public WithEvents Label65 As Label
    Friend WithEvents BlockOrderCheck As CheckBox
    Friend WithEvents SweepToFillCheck As CheckBox
    Friend WithEvents OverridePercentageConstraintsCheck As CheckBox
    Friend WithEvents AllOrNoneCheck As CheckBox
    Friend WithEvents FirmQuoteOnlyCheck As CheckBox
    Friend WithEvents ETradeOnlyCheck As CheckBox
    Friend WithEvents ContinuousUpdateCheck As CheckBox
    Friend WithEvents OrderPropertyGrid As PropertyGrid
    Private components As System.ComponentModel.IContainer
    Public WithEvents LmtPriceOffsetText As TextBox
    Public WithEvents Label8 As Label
    Friend WithEvents OutsideRTHCheck As CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HedgeParamText = New System.Windows.Forms.TextBox()
        Me.Rule80AText = New System.Windows.Forms.TextBox()
        Me.SettlingFirmText = New System.Windows.Forms.TextBox()
        Me.MinQtyText = New System.Windows.Forms.TextBox()
        Me.PercentOffsetText = New System.Windows.Forms.TextBox()
        Me.NBBOPriceCapText = New System.Windows.Forms.TextBox()
        Me.AuctionStrategyText = New System.Windows.Forms.TextBox()
        Me.StartingPriceText = New System.Windows.Forms.TextBox()
        Me.StockRefPriceText = New System.Windows.Forms.TextBox()
        Me.DeltaText = New System.Windows.Forms.TextBox()
        Me.StockRangeLowerText = New System.Windows.Forms.TextBox()
        Me.StockRangeUpperText = New System.Windows.Forms.TextBox()
        Me.OcaTypeText = New System.Windows.Forms.TextBox()
        Me.ShortSaleSlotText = New System.Windows.Forms.TextBox()
        Me.DesignatedLocationText = New System.Windows.Forms.TextBox()
        Me.DiscretionaryAmtText = New System.Windows.Forms.TextBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.HiddenText = New System.Windows.Forms.TextBox()
        Me.TriggerMethodText = New System.Windows.Forms.TextBox()
        Me.DisplaySizeText = New System.Windows.Forms.TextBox()
        Me.ParentIdText = New System.Windows.Forms.TextBox()
        Me.OrderRefText = New System.Windows.Forms.TextBox()
        Me.OriginText = New System.Windows.Forms.TextBox()
        Me.OpenCloseText = New System.Windows.Forms.TextBox()
        Me.AccountText = New System.Windows.Forms.TextBox()
        Me.OCAText = New System.Windows.Forms.TextBox()
        Me.TIFText = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VolatilityText = New System.Windows.Forms.TextBox()
        Me.VolatilityTypeText = New System.Windows.Forms.TextBox()
        Me.DeltaNeutralOrderTypeText = New System.Windows.Forms.TextBox()
        Me.ReferencePriceTypeText = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.DeltaNeutralAuxPriceText = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TrailStopPriceText = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.ScaleInitLevelSizeText = New System.Windows.Forms.TextBox()
        Me.ScaleSubsLevelSizeText = New System.Windows.Forms.TextBox()
        Me.ScalePriceIncrText = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.ClearingAccountText = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ClearingIntentText = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.ExemptCodeText = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.HedgeTypeText = New System.Windows.Forms.TextBox()
        Me.LabelHedgeType = New System.Windows.Forms.Label()
        Me.LabelHedgeParam = New System.Windows.Forms.Label()
        Me.OptOutSmartRoutingCheck = New System.Windows.Forms.CheckBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.DeltaNeutralConIdText = New System.Windows.Forms.TextBox()
        Me.DeltaNeutralClearingIntentText = New System.Windows.Forms.TextBox()
        Me.DeltaNeutralClearingAccountText = New System.Windows.Forms.TextBox()
        Me.DeltaNeutralSettlingFirmText = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.ScaleAutoResetCheck = New System.Windows.Forms.CheckBox()
        Me.ScalePriceAdjustValueText = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.ScaleRandomPercentCheck = New System.Windows.Forms.CheckBox()
        Me.ScalePriceAdjustIntervalText = New System.Windows.Forms.TextBox()
        Me.ScaleInitPositionText = New System.Windows.Forms.TextBox()
        Me.ScaleInitFillQtyText = New System.Windows.Forms.TextBox()
        Me.ScaleProfitOffsetText = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TrailingPercentText = New System.Windows.Forms.TextBox()
        Me.DeltaNeutralOpenCloseText = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.DeltaNeutralShortSaleCheck = New System.Windows.Forms.CheckBox()
        Me.DeltaNeutralShortSaleSlotText = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.DeltaNeutralDesignatedLocationText = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.ActiveStopTimeText = New System.Windows.Forms.TextBox()
        Me.ActiveStartTimeText = New System.Windows.Forms.TextBox()
        Me.ScaleTableText = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.SolicitedCheck = New System.Windows.Forms.CheckBox()
        Me.RandomizeSizeCheck = New System.Windows.Forms.CheckBox()
        Me.RandomizePriceCheck = New System.Windows.Forms.CheckBox()
        Me.ModelCodeText = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.TransmitCheck = New System.Windows.Forms.CheckBox()
        Me.DontUseAutoPriceForHedgeCheck = New System.Windows.Forms.CheckBox()
        Me.Mifid2ExecutionTraderText = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Mifid2ExecutionAlgoText = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Mifid2DecisionMakerText = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Mifid2DecisionAlgoText = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.BlockOrderCheck = New System.Windows.Forms.CheckBox()
        Me.SweepToFillCheck = New System.Windows.Forms.CheckBox()
        Me.OutsideRTHCheck = New System.Windows.Forms.CheckBox()
        Me.OverridePercentageConstraintsCheck = New System.Windows.Forms.CheckBox()
        Me.AllOrNoneCheck = New System.Windows.Forms.CheckBox()
        Me.FirmQuoteOnlyCheck = New System.Windows.Forms.CheckBox()
        Me.ETradeOnlyCheck = New System.Windows.Forms.CheckBox()
        Me.ContinuousUpdateCheck = New System.Windows.Forms.CheckBox()
        Me.OrderPropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.LmtPriceOffsetText = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'HedgeParamText
        '
        Me.HedgeParamText.AcceptsReturn = True
        Me.HedgeParamText.BackColor = System.Drawing.SystemColors.Window
        Me.HedgeParamText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HedgeParamText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HedgeParamText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HedgeParamText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HedgeParamText.Location = New System.Drawing.Point(143, 444)
        Me.HedgeParamText.MaxLength = 0
        Me.HedgeParamText.Name = "HedgeParamText"
        Me.HedgeParamText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HedgeParamText.Size = New System.Drawing.Size(85, 13)
        Me.HedgeParamText.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.HedgeParamText, "Allowed values are 'beta' for beta hedge and 'ratio' for pair hedge")
        '
        'Rule80AText
        '
        Me.Rule80AText.AcceptsReturn = True
        Me.Rule80AText.BackColor = System.Drawing.SystemColors.Window
        Me.Rule80AText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rule80AText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Rule80AText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rule80AText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Rule80AText.Location = New System.Drawing.Point(144, 394)
        Me.Rule80AText.MaxLength = 0
        Me.Rule80AText.Name = "Rule80AText"
        Me.Rule80AText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Rule80AText.Size = New System.Drawing.Size(85, 13)
        Me.Rule80AText.TabIndex = 33
        '
        'SettlingFirmText
        '
        Me.SettlingFirmText.AcceptsReturn = True
        Me.SettlingFirmText.BackColor = System.Drawing.SystemColors.Window
        Me.SettlingFirmText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SettlingFirmText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SettlingFirmText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettlingFirmText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SettlingFirmText.Location = New System.Drawing.Point(144, 106)
        Me.SettlingFirmText.MaxLength = 0
        Me.SettlingFirmText.Name = "SettlingFirmText"
        Me.SettlingFirmText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SettlingFirmText.Size = New System.Drawing.Size(85, 13)
        Me.SettlingFirmText.TabIndex = 9
        '
        'MinQtyText
        '
        Me.MinQtyText.AcceptsReturn = True
        Me.MinQtyText.BackColor = System.Drawing.SystemColors.Window
        Me.MinQtyText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MinQtyText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MinQtyText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinQtyText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MinQtyText.Location = New System.Drawing.Point(433, 106)
        Me.MinQtyText.MaxLength = 0
        Me.MinQtyText.Name = "MinQtyText"
        Me.MinQtyText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MinQtyText.Size = New System.Drawing.Size(85, 13)
        Me.MinQtyText.TabIndex = 51
        '
        'PercentOffsetText
        '
        Me.PercentOffsetText.AcceptsReturn = True
        Me.PercentOffsetText.BackColor = System.Drawing.SystemColors.Window
        Me.PercentOffsetText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PercentOffsetText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PercentOffsetText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PercentOffsetText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PercentOffsetText.Location = New System.Drawing.Point(433, 130)
        Me.PercentOffsetText.MaxLength = 0
        Me.PercentOffsetText.Name = "PercentOffsetText"
        Me.PercentOffsetText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PercentOffsetText.Size = New System.Drawing.Size(85, 13)
        Me.PercentOffsetText.TabIndex = 53
        '
        'NBBOPriceCapText
        '
        Me.NBBOPriceCapText.AcceptsReturn = True
        Me.NBBOPriceCapText.BackColor = System.Drawing.SystemColors.Window
        Me.NBBOPriceCapText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NBBOPriceCapText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NBBOPriceCapText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NBBOPriceCapText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NBBOPriceCapText.Location = New System.Drawing.Point(433, 202)
        Me.NBBOPriceCapText.MaxLength = 0
        Me.NBBOPriceCapText.Name = "NBBOPriceCapText"
        Me.NBBOPriceCapText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NBBOPriceCapText.Size = New System.Drawing.Size(85, 13)
        Me.NBBOPriceCapText.TabIndex = 59
        '
        'AuctionStrategyText
        '
        Me.AuctionStrategyText.AcceptsReturn = True
        Me.AuctionStrategyText.BackColor = System.Drawing.SystemColors.Window
        Me.AuctionStrategyText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AuctionStrategyText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AuctionStrategyText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuctionStrategyText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AuctionStrategyText.Location = New System.Drawing.Point(433, 394)
        Me.AuctionStrategyText.MaxLength = 0
        Me.AuctionStrategyText.Name = "AuctionStrategyText"
        Me.AuctionStrategyText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AuctionStrategyText.Size = New System.Drawing.Size(85, 13)
        Me.AuctionStrategyText.TabIndex = 75
        Me.AuctionStrategyText.Text = "0"
        '
        'StartingPriceText
        '
        Me.StartingPriceText.AcceptsReturn = True
        Me.StartingPriceText.BackColor = System.Drawing.SystemColors.Window
        Me.StartingPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StartingPriceText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.StartingPriceText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartingPriceText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.StartingPriceText.Location = New System.Drawing.Point(433, 418)
        Me.StartingPriceText.MaxLength = 0
        Me.StartingPriceText.Name = "StartingPriceText"
        Me.StartingPriceText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartingPriceText.Size = New System.Drawing.Size(85, 13)
        Me.StartingPriceText.TabIndex = 77
        '
        'StockRefPriceText
        '
        Me.StockRefPriceText.AcceptsReturn = True
        Me.StockRefPriceText.BackColor = System.Drawing.SystemColors.Window
        Me.StockRefPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StockRefPriceText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.StockRefPriceText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockRefPriceText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.StockRefPriceText.Location = New System.Drawing.Point(433, 442)
        Me.StockRefPriceText.MaxLength = 0
        Me.StockRefPriceText.Name = "StockRefPriceText"
        Me.StockRefPriceText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StockRefPriceText.Size = New System.Drawing.Size(85, 13)
        Me.StockRefPriceText.TabIndex = 79
        '
        'DeltaText
        '
        Me.DeltaText.AcceptsReturn = True
        Me.DeltaText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaText.Location = New System.Drawing.Point(433, 466)
        Me.DeltaText.MaxLength = 0
        Me.DeltaText.Name = "DeltaText"
        Me.DeltaText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaText.TabIndex = 81
        '
        'StockRangeLowerText
        '
        Me.StockRangeLowerText.AcceptsReturn = True
        Me.StockRangeLowerText.BackColor = System.Drawing.SystemColors.Window
        Me.StockRangeLowerText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StockRangeLowerText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.StockRangeLowerText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockRangeLowerText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.StockRangeLowerText.Location = New System.Drawing.Point(433, 492)
        Me.StockRangeLowerText.MaxLength = 0
        Me.StockRangeLowerText.Name = "StockRangeLowerText"
        Me.StockRangeLowerText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StockRangeLowerText.Size = New System.Drawing.Size(85, 13)
        Me.StockRangeLowerText.TabIndex = 83
        '
        'StockRangeUpperText
        '
        Me.StockRangeUpperText.AcceptsReturn = True
        Me.StockRangeUpperText.BackColor = System.Drawing.SystemColors.Window
        Me.StockRangeUpperText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StockRangeUpperText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.StockRangeUpperText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockRangeUpperText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.StockRangeUpperText.Location = New System.Drawing.Point(433, 518)
        Me.StockRangeUpperText.MaxLength = 0
        Me.StockRangeUpperText.Name = "StockRangeUpperText"
        Me.StockRangeUpperText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StockRangeUpperText.Size = New System.Drawing.Size(85, 13)
        Me.StockRangeUpperText.TabIndex = 85
        '
        'OcaTypeText
        '
        Me.OcaTypeText.AcceptsReturn = True
        Me.OcaTypeText.BackColor = System.Drawing.SystemColors.Window
        Me.OcaTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OcaTypeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OcaTypeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OcaTypeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OcaTypeText.Location = New System.Drawing.Point(144, 58)
        Me.OcaTypeText.MaxLength = 0
        Me.OcaTypeText.Name = "OcaTypeText"
        Me.OcaTypeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OcaTypeText.Size = New System.Drawing.Size(85, 13)
        Me.OcaTypeText.TabIndex = 5
        Me.OcaTypeText.Text = "0"
        '
        'ShortSaleSlotText
        '
        Me.ShortSaleSlotText.AcceptsReturn = True
        Me.ShortSaleSlotText.BackColor = System.Drawing.SystemColors.Window
        Me.ShortSaleSlotText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ShortSaleSlotText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ShortSaleSlotText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShortSaleSlotText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ShortSaleSlotText.Location = New System.Drawing.Point(433, 370)
        Me.ShortSaleSlotText.MaxLength = 0
        Me.ShortSaleSlotText.Name = "ShortSaleSlotText"
        Me.ShortSaleSlotText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShortSaleSlotText.Size = New System.Drawing.Size(85, 13)
        Me.ShortSaleSlotText.TabIndex = 73
        '
        'DesignatedLocationText
        '
        Me.DesignatedLocationText.AcceptsReturn = True
        Me.DesignatedLocationText.BackColor = System.Drawing.SystemColors.Window
        Me.DesignatedLocationText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DesignatedLocationText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DesignatedLocationText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignatedLocationText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DesignatedLocationText.Location = New System.Drawing.Point(144, 346)
        Me.DesignatedLocationText.MaxLength = 0
        Me.DesignatedLocationText.Name = "DesignatedLocationText"
        Me.DesignatedLocationText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DesignatedLocationText.Size = New System.Drawing.Size(85, 13)
        Me.DesignatedLocationText.TabIndex = 29
        '
        'DiscretionaryAmtText
        '
        Me.DiscretionaryAmtText.AcceptsReturn = True
        Me.DiscretionaryAmtText.BackColor = System.Drawing.SystemColors.Window
        Me.DiscretionaryAmtText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DiscretionaryAmtText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DiscretionaryAmtText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiscretionaryAmtText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DiscretionaryAmtText.Location = New System.Drawing.Point(433, 346)
        Me.DiscretionaryAmtText.MaxLength = 0
        Me.DiscretionaryAmtText.Name = "DiscretionaryAmtText"
        Me.DiscretionaryAmtText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DiscretionaryAmtText.Size = New System.Drawing.Size(85, 13)
        Me.DiscretionaryAmtText.TabIndex = 71
        Me.DiscretionaryAmtText.Text = "0"
        '
        'OkButton
        '
        Me.OkButton.BackColor = System.Drawing.SystemColors.Control
        Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OkButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OkButton.Location = New System.Drawing.Point(550, 660)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 137
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancelItButton
        '
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(665, 660)
        Me.CancelItButton.Name = "CancelItButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(73, 25)
        Me.CancelItButton.TabIndex = 138
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'HiddenText
        '
        Me.HiddenText.AcceptsReturn = True
        Me.HiddenText.BackColor = System.Drawing.SystemColors.Window
        Me.HiddenText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HiddenText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HiddenText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HiddenText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HiddenText.Location = New System.Drawing.Point(433, 322)
        Me.HiddenText.MaxLength = 0
        Me.HiddenText.Name = "HiddenText"
        Me.HiddenText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HiddenText.Size = New System.Drawing.Size(85, 13)
        Me.HiddenText.TabIndex = 69
        Me.HiddenText.Text = "0"
        '
        'TriggerMethodText
        '
        Me.TriggerMethodText.AcceptsReturn = True
        Me.TriggerMethodText.BackColor = System.Drawing.SystemColors.Window
        Me.TriggerMethodText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TriggerMethodText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TriggerMethodText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TriggerMethodText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TriggerMethodText.Location = New System.Drawing.Point(433, 274)
        Me.TriggerMethodText.MaxLength = 0
        Me.TriggerMethodText.Name = "TriggerMethodText"
        Me.TriggerMethodText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TriggerMethodText.Size = New System.Drawing.Size(85, 13)
        Me.TriggerMethodText.TabIndex = 65
        Me.TriggerMethodText.Text = "0"
        '
        'DisplaySizeText
        '
        Me.DisplaySizeText.AcceptsReturn = True
        Me.DisplaySizeText.BackColor = System.Drawing.SystemColors.Window
        Me.DisplaySizeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DisplaySizeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DisplaySizeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplaySizeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DisplaySizeText.Location = New System.Drawing.Point(433, 250)
        Me.DisplaySizeText.MaxLength = 0
        Me.DisplaySizeText.Name = "DisplaySizeText"
        Me.DisplaySizeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DisplaySizeText.Size = New System.Drawing.Size(85, 13)
        Me.DisplaySizeText.TabIndex = 63
        Me.DisplaySizeText.Text = "0"
        '
        'ParentIdText
        '
        Me.ParentIdText.AcceptsReturn = True
        Me.ParentIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ParentIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ParentIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ParentIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParentIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ParentIdText.Location = New System.Drawing.Point(144, 250)
        Me.ParentIdText.MaxLength = 0
        Me.ParentIdText.Name = "ParentIdText"
        Me.ParentIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ParentIdText.Size = New System.Drawing.Size(85, 13)
        Me.ParentIdText.TabIndex = 21
        Me.ParentIdText.Text = "0"
        '
        'OrderRefText
        '
        Me.OrderRefText.AcceptsReturn = True
        Me.OrderRefText.BackColor = System.Drawing.SystemColors.Window
        Me.OrderRefText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OrderRefText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OrderRefText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderRefText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OrderRefText.Location = New System.Drawing.Point(144, 226)
        Me.OrderRefText.MaxLength = 0
        Me.OrderRefText.Name = "OrderRefText"
        Me.OrderRefText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OrderRefText.Size = New System.Drawing.Size(85, 13)
        Me.OrderRefText.TabIndex = 19
        '
        'OriginText
        '
        Me.OriginText.AcceptsReturn = True
        Me.OriginText.BackColor = System.Drawing.SystemColors.Window
        Me.OriginText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OriginText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OriginText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OriginText.Location = New System.Drawing.Point(144, 202)
        Me.OriginText.MaxLength = 0
        Me.OriginText.Name = "OriginText"
        Me.OriginText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OriginText.Size = New System.Drawing.Size(85, 13)
        Me.OriginText.TabIndex = 17
        Me.OriginText.Text = "0"
        '
        'OpenCloseText
        '
        Me.OpenCloseText.AcceptsReturn = True
        Me.OpenCloseText.BackColor = System.Drawing.SystemColors.Window
        Me.OpenCloseText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OpenCloseText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OpenCloseText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenCloseText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OpenCloseText.Location = New System.Drawing.Point(144, 178)
        Me.OpenCloseText.MaxLength = 0
        Me.OpenCloseText.Name = "OpenCloseText"
        Me.OpenCloseText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpenCloseText.Size = New System.Drawing.Size(85, 13)
        Me.OpenCloseText.TabIndex = 15
        Me.OpenCloseText.Text = "O"
        '
        'AccountText
        '
        Me.AccountText.AcceptsReturn = True
        Me.AccountText.BackColor = System.Drawing.SystemColors.Window
        Me.AccountText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AccountText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AccountText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccountText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AccountText.Location = New System.Drawing.Point(144, 82)
        Me.AccountText.MaxLength = 0
        Me.AccountText.Name = "AccountText"
        Me.AccountText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AccountText.Size = New System.Drawing.Size(85, 13)
        Me.AccountText.TabIndex = 7
        '
        'OCAText
        '
        Me.OCAText.AcceptsReturn = True
        Me.OCAText.BackColor = System.Drawing.SystemColors.Window
        Me.OCAText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OCAText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OCAText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OCAText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OCAText.Location = New System.Drawing.Point(144, 34)
        Me.OCAText.MaxLength = 0
        Me.OCAText.Name = "OCAText"
        Me.OCAText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OCAText.Size = New System.Drawing.Size(85, 13)
        Me.OCAText.TabIndex = 3
        '
        'TIFText
        '
        Me.TIFText.AcceptsReturn = True
        Me.TIFText.BackColor = System.Drawing.SystemColors.Window
        Me.TIFText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TIFText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TIFText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIFText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TIFText.Location = New System.Drawing.Point(144, 10)
        Me.TIFText.MaxLength = 0
        Me.TIFText.Name = "TIFText"
        Me.TIFText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TIFText.Size = New System.Drawing.Size(85, 13)
        Me.TIFText.TabIndex = 1
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Gainsboro
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(16, 396)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(73, 17)
        Me.Label35.TabIndex = 32
        Me.Label35.Text = "Rule 80 A"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Gainsboro
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(16, 108)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(73, 17)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "Settling Firm"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Gainsboro
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(265, 107)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(121, 17)
        Me.Label33.TabIndex = 50
        Me.Label33.Text = "Minimum Quantity"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Gainsboro
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(265, 132)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(105, 17)
        Me.Label32.TabIndex = 52
        Me.Label32.Text = "Percent Offset"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gainsboro
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(265, 204)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(105, 17)
        Me.Label29.TabIndex = 58
        Me.Label29.Text = "NBBO Price Cap"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Gainsboro
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(265, 396)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(120, 17)
        Me.Label28.TabIndex = 74
        Me.Label28.Text = "BOX: Auction Strategy"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Gainsboro
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(265, 421)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(113, 17)
        Me.Label27.TabIndex = 76
        Me.Label27.Text = "BOX: Starting Price"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Gainsboro
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(265, 444)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(113, 17)
        Me.Label26.TabIndex = 78
        Me.Label26.Text = "BOX: Stock Ref Price"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Gainsboro
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(265, 469)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(73, 17)
        Me.Label25.TabIndex = 80
        Me.Label25.Text = "BOX: Delta"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Gainsboro
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(265, 495)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(160, 17)
        Me.Label24.TabIndex = 82
        Me.Label24.Text = "BOX/VOL: Stock Range Lower"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Gainsboro
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(265, 521)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(160, 17)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "BOX/VOL: Stock Range Upper"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Gainsboro
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(16, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(65, 17)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "OCA type"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Gainsboro
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(265, 372)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(152, 17)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Short Sales Slot"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Gainsboro
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(16, 348)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(113, 17)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Designated Location"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Gainsboro
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(265, 348)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(152, 17)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "Discretionary Amt"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(265, 324)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(65, 17)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Hidden"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(265, 276)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(88, 17)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Trigger Method"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(265, 252)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(65, 17)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Display Size"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(65, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Parent Id"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Order Ref"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Origin"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Open/Close"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Account"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "OCA group"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Time in Force"
        '
        'VolatilityText
        '
        Me.VolatilityText.AcceptsReturn = True
        Me.VolatilityText.BackColor = System.Drawing.SystemColors.Window
        Me.VolatilityText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.VolatilityText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.VolatilityText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolatilityText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.VolatilityText.Location = New System.Drawing.Point(753, 10)
        Me.VolatilityText.MaxLength = 0
        Me.VolatilityText.Name = "VolatilityText"
        Me.VolatilityText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.VolatilityText.Size = New System.Drawing.Size(85, 13)
        Me.VolatilityText.TabIndex = 93
        '
        'VolatilityTypeText
        '
        Me.VolatilityTypeText.AcceptsReturn = True
        Me.VolatilityTypeText.BackColor = System.Drawing.SystemColors.Window
        Me.VolatilityTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.VolatilityTypeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.VolatilityTypeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolatilityTypeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.VolatilityTypeText.Location = New System.Drawing.Point(753, 34)
        Me.VolatilityTypeText.MaxLength = 0
        Me.VolatilityTypeText.Name = "VolatilityTypeText"
        Me.VolatilityTypeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.VolatilityTypeText.Size = New System.Drawing.Size(85, 13)
        Me.VolatilityTypeText.TabIndex = 95
        '
        'DeltaNeutralOrderTypeText
        '
        Me.DeltaNeutralOrderTypeText.AcceptsReturn = True
        Me.DeltaNeutralOrderTypeText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralOrderTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralOrderTypeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralOrderTypeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralOrderTypeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralOrderTypeText.Location = New System.Drawing.Point(753, 58)
        Me.DeltaNeutralOrderTypeText.MaxLength = 0
        Me.DeltaNeutralOrderTypeText.Name = "DeltaNeutralOrderTypeText"
        Me.DeltaNeutralOrderTypeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralOrderTypeText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralOrderTypeText.TabIndex = 97
        '
        'ReferencePriceTypeText
        '
        Me.ReferencePriceTypeText.AcceptsReturn = True
        Me.ReferencePriceTypeText.BackColor = System.Drawing.SystemColors.Window
        Me.ReferencePriceTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReferencePriceTypeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReferencePriceTypeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReferencePriceTypeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReferencePriceTypeText.Location = New System.Drawing.Point(753, 322)
        Me.ReferencePriceTypeText.MaxLength = 0
        Me.ReferencePriceTypeText.Name = "ReferencePriceTypeText"
        Me.ReferencePriceTypeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReferencePriceTypeText.Size = New System.Drawing.Size(85, 13)
        Me.ReferencePriceTypeText.TabIndex = 118
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Gainsboro
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(550, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(105, 17)
        Me.Label21.TabIndex = 92
        Me.Label21.Text = "VOL: Volatility"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Gainsboro
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(550, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(144, 17)
        Me.Label22.TabIndex = 94
        Me.Label22.Text = "VOL: Volatility Type (1 or 2)"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Gainsboro
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(550, 59)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(152, 17)
        Me.Label36.TabIndex = 96
        Me.Label36.Text = "VOL: Hedge Delta Order Type"
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Gainsboro
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(550, 324)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(181, 17)
        Me.Label40.TabIndex = 117
        Me.Label40.Text = "VOL: Reference Price Type (1 or 2)"
        '
        'DeltaNeutralAuxPriceText
        '
        Me.DeltaNeutralAuxPriceText.AcceptsReturn = True
        Me.DeltaNeutralAuxPriceText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralAuxPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralAuxPriceText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralAuxPriceText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralAuxPriceText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralAuxPriceText.Location = New System.Drawing.Point(753, 82)
        Me.DeltaNeutralAuxPriceText.MaxLength = 0
        Me.DeltaNeutralAuxPriceText.Name = "DeltaNeutralAuxPriceText"
        Me.DeltaNeutralAuxPriceText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralAuxPriceText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralAuxPriceText.TabIndex = 99
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Gainsboro
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(550, 84)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(152, 17)
        Me.Label38.TabIndex = 98
        Me.Label38.Text = "VOL: Hedge Delta Aux Price"
        '
        'TrailStopPriceText
        '
        Me.TrailStopPriceText.AcceptsReturn = True
        Me.TrailStopPriceText.BackColor = System.Drawing.SystemColors.Window
        Me.TrailStopPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrailStopPriceText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TrailStopPriceText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrailStopPriceText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TrailStopPriceText.Location = New System.Drawing.Point(432, 10)
        Me.TrailStopPriceText.MaxLength = 0
        Me.TrailStopPriceText.Name = "TrailStopPriceText"
        Me.TrailStopPriceText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TrailStopPriceText.Size = New System.Drawing.Size(85, 13)
        Me.TrailStopPriceText.TabIndex = 45
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Gainsboro
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(264, 11)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(96, 17)
        Me.Label39.TabIndex = 44
        Me.Label39.Text = "Trail Stop Price"
        '
        'ScaleInitLevelSizeText
        '
        Me.ScaleInitLevelSizeText.AcceptsReturn = True
        Me.ScaleInitLevelSizeText.BackColor = System.Drawing.SystemColors.Window
        Me.ScaleInitLevelSizeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScaleInitLevelSizeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScaleInitLevelSizeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleInitLevelSizeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScaleInitLevelSizeText.Location = New System.Drawing.Point(753, 346)
        Me.ScaleInitLevelSizeText.MaxLength = 0
        Me.ScaleInitLevelSizeText.Name = "ScaleInitLevelSizeText"
        Me.ScaleInitLevelSizeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScaleInitLevelSizeText.Size = New System.Drawing.Size(85, 13)
        Me.ScaleInitLevelSizeText.TabIndex = 120
        '
        'ScaleSubsLevelSizeText
        '
        Me.ScaleSubsLevelSizeText.AcceptsReturn = True
        Me.ScaleSubsLevelSizeText.BackColor = System.Drawing.SystemColors.Window
        Me.ScaleSubsLevelSizeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScaleSubsLevelSizeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScaleSubsLevelSizeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleSubsLevelSizeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScaleSubsLevelSizeText.Location = New System.Drawing.Point(753, 370)
        Me.ScaleSubsLevelSizeText.MaxLength = 0
        Me.ScaleSubsLevelSizeText.Name = "ScaleSubsLevelSizeText"
        Me.ScaleSubsLevelSizeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScaleSubsLevelSizeText.Size = New System.Drawing.Size(85, 13)
        Me.ScaleSubsLevelSizeText.TabIndex = 122
        '
        'ScalePriceIncrText
        '
        Me.ScalePriceIncrText.AcceptsReturn = True
        Me.ScalePriceIncrText.BackColor = System.Drawing.SystemColors.Window
        Me.ScalePriceIncrText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScalePriceIncrText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScalePriceIncrText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScalePriceIncrText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScalePriceIncrText.Location = New System.Drawing.Point(753, 394)
        Me.ScalePriceIncrText.MaxLength = 0
        Me.ScalePriceIncrText.Name = "ScalePriceIncrText"
        Me.ScalePriceIncrText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScalePriceIncrText.Size = New System.Drawing.Size(85, 13)
        Me.ScalePriceIncrText.TabIndex = 124
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Gainsboro
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(550, 348)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(128, 17)
        Me.Label42.TabIndex = 119
        Me.Label42.Text = "SCALE: Init Level Size"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Gainsboro
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(550, 372)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(128, 17)
        Me.Label43.TabIndex = 121
        Me.Label43.Text = "SCALE: Subs Level Size"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Gainsboro
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(550, 396)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(128, 17)
        Me.Label44.TabIndex = 123
        Me.Label44.Text = "SCALE: Price Increment"
        '
        'ClearingAccountText
        '
        Me.ClearingAccountText.AcceptsReturn = True
        Me.ClearingAccountText.BackColor = System.Drawing.SystemColors.Window
        Me.ClearingAccountText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ClearingAccountText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ClearingAccountText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearingAccountText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ClearingAccountText.Location = New System.Drawing.Point(144, 130)
        Me.ClearingAccountText.MaxLength = 0
        Me.ClearingAccountText.Name = "ClearingAccountText"
        Me.ClearingAccountText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ClearingAccountText.Size = New System.Drawing.Size(85, 13)
        Me.ClearingAccountText.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Gainsboro
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(17, 132)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(96, 17)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Clearing Account"
        '
        'ClearingIntentText
        '
        Me.ClearingIntentText.AcceptsReturn = True
        Me.ClearingIntentText.BackColor = System.Drawing.SystemColors.Window
        Me.ClearingIntentText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ClearingIntentText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ClearingIntentText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearingIntentText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ClearingIntentText.Location = New System.Drawing.Point(144, 154)
        Me.ClearingIntentText.MaxLength = 0
        Me.ClearingIntentText.Name = "ClearingIntentText"
        Me.ClearingIntentText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ClearingIntentText.Size = New System.Drawing.Size(85, 13)
        Me.ClearingIntentText.TabIndex = 13
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Gainsboro
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(17, 156)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(96, 17)
        Me.Label45.TabIndex = 12
        Me.Label45.Text = "Clearing Intent"
        '
        'ExemptCodeText
        '
        Me.ExemptCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExemptCodeText.Location = New System.Drawing.Point(144, 370)
        Me.ExemptCodeText.Name = "ExemptCodeText"
        Me.ExemptCodeText.Size = New System.Drawing.Size(84, 13)
        Me.ExemptCodeText.TabIndex = 31
        Me.ExemptCodeText.Text = "-1"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(16, 373)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(70, 14)
        Me.Label46.TabIndex = 30
        Me.Label46.Text = "Exempt Code"
        '
        'HedgeTypeText
        '
        Me.HedgeTypeText.AcceptsReturn = True
        Me.HedgeTypeText.BackColor = System.Drawing.SystemColors.Window
        Me.HedgeTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HedgeTypeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HedgeTypeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HedgeTypeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HedgeTypeText.Location = New System.Drawing.Point(143, 418)
        Me.HedgeTypeText.MaxLength = 0
        Me.HedgeTypeText.Name = "HedgeTypeText"
        Me.HedgeTypeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HedgeTypeText.Size = New System.Drawing.Size(85, 13)
        Me.HedgeTypeText.TabIndex = 35
        '
        'LabelHedgeType
        '
        Me.LabelHedgeType.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelHedgeType.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelHedgeType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHedgeType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelHedgeType.Location = New System.Drawing.Point(16, 421)
        Me.LabelHedgeType.Name = "LabelHedgeType"
        Me.LabelHedgeType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelHedgeType.Size = New System.Drawing.Size(73, 17)
        Me.LabelHedgeType.TabIndex = 34
        Me.LabelHedgeType.Text = "Hedge: type"
        '
        'LabelHedgeParam
        '
        Me.LabelHedgeParam.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelHedgeParam.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelHedgeParam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHedgeParam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelHedgeParam.Location = New System.Drawing.Point(16, 447)
        Me.LabelHedgeParam.Name = "LabelHedgeParam"
        Me.LabelHedgeParam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelHedgeParam.Size = New System.Drawing.Size(85, 17)
        Me.LabelHedgeParam.TabIndex = 36
        Me.LabelHedgeParam.Text = "Hedge: param"
        '
        'OptOutSmartRoutingCheck
        '
        Me.OptOutSmartRoutingCheck.AutoSize = True
        Me.OptOutSmartRoutingCheck.Location = New System.Drawing.Point(16, 471)
        Me.OptOutSmartRoutingCheck.Name = "OptOutSmartRoutingCheck"
        Me.OptOutSmartRoutingCheck.Size = New System.Drawing.Size(166, 18)
        Me.OptOutSmartRoutingCheck.TabIndex = 38
        Me.OptOutSmartRoutingCheck.Text = "Opting out of SMART Routing"
        Me.OptOutSmartRoutingCheck.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Gainsboro
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(550, 108)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(152, 17)
        Me.Label47.TabIndex = 100
        Me.Label47.Text = "VOL: Hedge Delta Con Id"
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Gainsboro
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(550, 132)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(181, 17)
        Me.Label48.TabIndex = 102
        Me.Label48.Text = "VOL: Hedge Delta Settling Firm"
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Gainsboro
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(550, 156)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(188, 17)
        Me.Label49.TabIndex = 104
        Me.Label49.Text = "VOL: Hedge Delta Clearing Account"
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Gainsboro
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label50.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(550, 180)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label50.Size = New System.Drawing.Size(181, 17)
        Me.Label50.TabIndex = 106
        Me.Label50.Text = "VOL: Hedge Delta Clearing Intent"
        '
        'DeltaNeutralConIdText
        '
        Me.DeltaNeutralConIdText.AcceptsReturn = True
        Me.DeltaNeutralConIdText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralConIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralConIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralConIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralConIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralConIdText.Location = New System.Drawing.Point(753, 106)
        Me.DeltaNeutralConIdText.MaxLength = 0
        Me.DeltaNeutralConIdText.Name = "DeltaNeutralConIdText"
        Me.DeltaNeutralConIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralConIdText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralConIdText.TabIndex = 101
        '
        'DeltaNeutralClearingIntentText
        '
        Me.DeltaNeutralClearingIntentText.AcceptsReturn = True
        Me.DeltaNeutralClearingIntentText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralClearingIntentText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralClearingIntentText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralClearingIntentText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralClearingIntentText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralClearingIntentText.Location = New System.Drawing.Point(753, 178)
        Me.DeltaNeutralClearingIntentText.MaxLength = 0
        Me.DeltaNeutralClearingIntentText.Name = "DeltaNeutralClearingIntentText"
        Me.DeltaNeutralClearingIntentText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralClearingIntentText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralClearingIntentText.TabIndex = 107
        '
        'DeltaNeutralClearingAccountText
        '
        Me.DeltaNeutralClearingAccountText.AcceptsReturn = True
        Me.DeltaNeutralClearingAccountText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralClearingAccountText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralClearingAccountText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralClearingAccountText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralClearingAccountText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralClearingAccountText.Location = New System.Drawing.Point(753, 154)
        Me.DeltaNeutralClearingAccountText.MaxLength = 0
        Me.DeltaNeutralClearingAccountText.Name = "DeltaNeutralClearingAccountText"
        Me.DeltaNeutralClearingAccountText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralClearingAccountText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralClearingAccountText.TabIndex = 105
        '
        'DeltaNeutralSettlingFirmText
        '
        Me.DeltaNeutralSettlingFirmText.AcceptsReturn = True
        Me.DeltaNeutralSettlingFirmText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralSettlingFirmText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralSettlingFirmText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralSettlingFirmText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralSettlingFirmText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralSettlingFirmText.Location = New System.Drawing.Point(753, 130)
        Me.DeltaNeutralSettlingFirmText.MaxLength = 0
        Me.DeltaNeutralSettlingFirmText.Name = "DeltaNeutralSettlingFirmText"
        Me.DeltaNeutralSettlingFirmText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralSettlingFirmText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralSettlingFirmText.TabIndex = 103
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Gainsboro
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label51.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(550, 420)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label51.Size = New System.Drawing.Size(181, 17)
        Me.Label51.TabIndex = 125
        Me.Label51.Text = "SCALE: Price Adjust Value"
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Gainsboro
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(550, 444)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(181, 17)
        Me.Label52.TabIndex = 127
        Me.Label52.Text = "SCALE: Price Adjust Interval"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Gainsboro
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(550, 469)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(181, 17)
        Me.Label53.TabIndex = 129
        Me.Label53.Text = "SCALE: Profit Offset"
        '
        'ScaleAutoResetCheck
        '
        Me.ScaleAutoResetCheck.AutoSize = True
        Me.ScaleAutoResetCheck.Location = New System.Drawing.Point(550, 490)
        Me.ScaleAutoResetCheck.Name = "ScaleAutoResetCheck"
        Me.ScaleAutoResetCheck.Size = New System.Drawing.Size(119, 18)
        Me.ScaleAutoResetCheck.TabIndex = 131
        Me.ScaleAutoResetCheck.Text = "SCALE: Auto Reset"
        Me.ScaleAutoResetCheck.UseVisualStyleBackColor = True
        '
        'ScalePriceAdjustValueText
        '
        Me.ScalePriceAdjustValueText.AcceptsReturn = True
        Me.ScalePriceAdjustValueText.BackColor = System.Drawing.SystemColors.Window
        Me.ScalePriceAdjustValueText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScalePriceAdjustValueText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScalePriceAdjustValueText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScalePriceAdjustValueText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScalePriceAdjustValueText.Location = New System.Drawing.Point(753, 418)
        Me.ScalePriceAdjustValueText.MaxLength = 0
        Me.ScalePriceAdjustValueText.Name = "ScalePriceAdjustValueText"
        Me.ScalePriceAdjustValueText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScalePriceAdjustValueText.Size = New System.Drawing.Size(85, 13)
        Me.ScalePriceAdjustValueText.TabIndex = 126
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Gainsboro
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(550, 517)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(181, 17)
        Me.Label54.TabIndex = 132
        Me.Label54.Text = "SCALE: Init Position"
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Gainsboro
        Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label55.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(550, 543)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(181, 17)
        Me.Label55.TabIndex = 134
        Me.Label55.Text = "SCALE: Init Fill Qty"
        '
        'ScaleRandomPercentCheck
        '
        Me.ScaleRandomPercentCheck.AutoSize = True
        Me.ScaleRandomPercentCheck.Location = New System.Drawing.Point(550, 567)
        Me.ScaleRandomPercentCheck.Name = "ScaleRandomPercentCheck"
        Me.ScaleRandomPercentCheck.Size = New System.Drawing.Size(145, 18)
        Me.ScaleRandomPercentCheck.TabIndex = 136
        Me.ScaleRandomPercentCheck.Text = "SCALE: Random Percent"
        Me.ScaleRandomPercentCheck.UseVisualStyleBackColor = True
        '
        'ScalePriceAdjustIntervalText
        '
        Me.ScalePriceAdjustIntervalText.AcceptsReturn = True
        Me.ScalePriceAdjustIntervalText.BackColor = System.Drawing.SystemColors.Window
        Me.ScalePriceAdjustIntervalText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScalePriceAdjustIntervalText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScalePriceAdjustIntervalText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScalePriceAdjustIntervalText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScalePriceAdjustIntervalText.Location = New System.Drawing.Point(753, 442)
        Me.ScalePriceAdjustIntervalText.MaxLength = 0
        Me.ScalePriceAdjustIntervalText.Name = "ScalePriceAdjustIntervalText"
        Me.ScalePriceAdjustIntervalText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScalePriceAdjustIntervalText.Size = New System.Drawing.Size(85, 13)
        Me.ScalePriceAdjustIntervalText.TabIndex = 128
        '
        'ScaleInitPositionText
        '
        Me.ScaleInitPositionText.AcceptsReturn = True
        Me.ScaleInitPositionText.BackColor = System.Drawing.SystemColors.Window
        Me.ScaleInitPositionText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScaleInitPositionText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScaleInitPositionText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleInitPositionText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScaleInitPositionText.Location = New System.Drawing.Point(753, 514)
        Me.ScaleInitPositionText.MaxLength = 0
        Me.ScaleInitPositionText.Name = "ScaleInitPositionText"
        Me.ScaleInitPositionText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScaleInitPositionText.Size = New System.Drawing.Size(85, 13)
        Me.ScaleInitPositionText.TabIndex = 133
        '
        'ScaleInitFillQtyText
        '
        Me.ScaleInitFillQtyText.AcceptsReturn = True
        Me.ScaleInitFillQtyText.BackColor = System.Drawing.SystemColors.Window
        Me.ScaleInitFillQtyText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScaleInitFillQtyText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScaleInitFillQtyText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleInitFillQtyText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScaleInitFillQtyText.Location = New System.Drawing.Point(753, 540)
        Me.ScaleInitFillQtyText.MaxLength = 0
        Me.ScaleInitFillQtyText.Name = "ScaleInitFillQtyText"
        Me.ScaleInitFillQtyText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScaleInitFillQtyText.Size = New System.Drawing.Size(85, 13)
        Me.ScaleInitFillQtyText.TabIndex = 135
        '
        'ScaleProfitOffsetText
        '
        Me.ScaleProfitOffsetText.AcceptsReturn = True
        Me.ScaleProfitOffsetText.BackColor = System.Drawing.SystemColors.Window
        Me.ScaleProfitOffsetText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScaleProfitOffsetText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScaleProfitOffsetText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleProfitOffsetText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScaleProfitOffsetText.Location = New System.Drawing.Point(753, 466)
        Me.ScaleProfitOffsetText.MaxLength = 0
        Me.ScaleProfitOffsetText.Name = "ScaleProfitOffsetText"
        Me.ScaleProfitOffsetText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScaleProfitOffsetText.Size = New System.Drawing.Size(85, 13)
        Me.ScaleProfitOffsetText.TabIndex = 130
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Gainsboro
        Me.Label56.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label56.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(264, 35)
        Me.Label56.Name = "Label56"
        Me.Label56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label56.Size = New System.Drawing.Size(136, 17)
        Me.Label56.TabIndex = 46
        Me.Label56.Text = "Trailing Percent"
        '
        'TrailingPercentText
        '
        Me.TrailingPercentText.AcceptsReturn = True
        Me.TrailingPercentText.BackColor = System.Drawing.SystemColors.Window
        Me.TrailingPercentText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrailingPercentText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TrailingPercentText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrailingPercentText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TrailingPercentText.Location = New System.Drawing.Point(432, 34)
        Me.TrailingPercentText.MaxLength = 0
        Me.TrailingPercentText.Name = "TrailingPercentText"
        Me.TrailingPercentText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TrailingPercentText.Size = New System.Drawing.Size(85, 13)
        Me.TrailingPercentText.TabIndex = 47
        '
        'DeltaNeutralOpenCloseText
        '
        Me.DeltaNeutralOpenCloseText.AcceptsReturn = True
        Me.DeltaNeutralOpenCloseText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralOpenCloseText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralOpenCloseText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralOpenCloseText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralOpenCloseText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralOpenCloseText.Location = New System.Drawing.Point(753, 202)
        Me.DeltaNeutralOpenCloseText.MaxLength = 0
        Me.DeltaNeutralOpenCloseText.Name = "DeltaNeutralOpenCloseText"
        Me.DeltaNeutralOpenCloseText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralOpenCloseText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralOpenCloseText.TabIndex = 109
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Gainsboro
        Me.Label57.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label57.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(550, 204)
        Me.Label57.Name = "Label57"
        Me.Label57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label57.Size = New System.Drawing.Size(181, 17)
        Me.Label57.TabIndex = 108
        Me.Label57.Text = "VOL: Hedge Delta Open/Close"
        '
        'DeltaNeutralShortSaleCheck
        '
        Me.DeltaNeutralShortSaleCheck.AutoSize = True
        Me.DeltaNeutralShortSaleCheck.Location = New System.Drawing.Point(553, 228)
        Me.DeltaNeutralShortSaleCheck.Name = "DeltaNeutralShortSaleCheck"
        Me.DeltaNeutralShortSaleCheck.Size = New System.Drawing.Size(165, 18)
        Me.DeltaNeutralShortSaleCheck.TabIndex = 110
        Me.DeltaNeutralShortSaleCheck.Text = "VOL: Hedge Delta Short Sale"
        Me.DeltaNeutralShortSaleCheck.UseVisualStyleBackColor = True
        '
        'DeltaNeutralShortSaleSlotText
        '
        Me.DeltaNeutralShortSaleSlotText.AcceptsReturn = True
        Me.DeltaNeutralShortSaleSlotText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralShortSaleSlotText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralShortSaleSlotText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralShortSaleSlotText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralShortSaleSlotText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralShortSaleSlotText.Location = New System.Drawing.Point(753, 250)
        Me.DeltaNeutralShortSaleSlotText.MaxLength = 0
        Me.DeltaNeutralShortSaleSlotText.Name = "DeltaNeutralShortSaleSlotText"
        Me.DeltaNeutralShortSaleSlotText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralShortSaleSlotText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralShortSaleSlotText.TabIndex = 112
        Me.DeltaNeutralShortSaleSlotText.Text = "0"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Gainsboro
        Me.Label58.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(550, 252)
        Me.Label58.Name = "Label58"
        Me.Label58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label58.Size = New System.Drawing.Size(181, 17)
        Me.Label58.TabIndex = 111
        Me.Label58.Text = "VOL: Hedge Delta Short Sale Slot"
        '
        'DeltaNeutralDesignatedLocationText
        '
        Me.DeltaNeutralDesignatedLocationText.AcceptsReturn = True
        Me.DeltaNeutralDesignatedLocationText.BackColor = System.Drawing.SystemColors.Window
        Me.DeltaNeutralDesignatedLocationText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaNeutralDesignatedLocationText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeltaNeutralDesignatedLocationText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaNeutralDesignatedLocationText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeltaNeutralDesignatedLocationText.Location = New System.Drawing.Point(753, 274)
        Me.DeltaNeutralDesignatedLocationText.MaxLength = 0
        Me.DeltaNeutralDesignatedLocationText.Name = "DeltaNeutralDesignatedLocationText"
        Me.DeltaNeutralDesignatedLocationText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeltaNeutralDesignatedLocationText.Size = New System.Drawing.Size(85, 13)
        Me.DeltaNeutralDesignatedLocationText.TabIndex = 114
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Gainsboro
        Me.Label59.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label59.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(550, 269)
        Me.Label59.Name = "Label59"
        Me.Label59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label59.Size = New System.Drawing.Size(181, 31)
        Me.Label59.TabIndex = 113
        Me.Label59.Text = "VOL: Hedge Delta Designated Location"
        '
        'ActiveStopTimeText
        '
        Me.ActiveStopTimeText.AcceptsReturn = True
        Me.ActiveStopTimeText.BackColor = System.Drawing.SystemColors.Window
        Me.ActiveStopTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ActiveStopTimeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ActiveStopTimeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActiveStopTimeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ActiveStopTimeText.Location = New System.Drawing.Point(433, 591)
        Me.ActiveStopTimeText.MaxLength = 0
        Me.ActiveStopTimeText.Name = "ActiveStopTimeText"
        Me.ActiveStopTimeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ActiveStopTimeText.Size = New System.Drawing.Size(85, 13)
        Me.ActiveStopTimeText.TabIndex = 91
        '
        'ActiveStartTimeText
        '
        Me.ActiveStartTimeText.AcceptsReturn = True
        Me.ActiveStartTimeText.BackColor = System.Drawing.SystemColors.Window
        Me.ActiveStartTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ActiveStartTimeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ActiveStartTimeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActiveStartTimeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ActiveStartTimeText.Location = New System.Drawing.Point(433, 567)
        Me.ActiveStartTimeText.MaxLength = 0
        Me.ActiveStartTimeText.Name = "ActiveStartTimeText"
        Me.ActiveStartTimeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ActiveStartTimeText.Size = New System.Drawing.Size(85, 13)
        Me.ActiveStartTimeText.TabIndex = 89
        '
        'ScaleTableText
        '
        Me.ScaleTableText.AcceptsReturn = True
        Me.ScaleTableText.BackColor = System.Drawing.SystemColors.Window
        Me.ScaleTableText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScaleTableText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ScaleTableText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleTableText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ScaleTableText.Location = New System.Drawing.Point(433, 543)
        Me.ScaleTableText.MaxLength = 0
        Me.ScaleTableText.Name = "ScaleTableText"
        Me.ScaleTableText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScaleTableText.Size = New System.Drawing.Size(85, 13)
        Me.ScaleTableText.TabIndex = 87
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.Gainsboro
        Me.Label60.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(265, 594)
        Me.Label60.Name = "Label60"
        Me.Label60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label60.Size = New System.Drawing.Size(160, 17)
        Me.Label60.TabIndex = 90
        Me.Label60.Text = "Active Stop Time"
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Gainsboro
        Me.Label61.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label61.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(265, 569)
        Me.Label61.Name = "Label61"
        Me.Label61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label61.Size = New System.Drawing.Size(160, 17)
        Me.Label61.TabIndex = 88
        Me.Label61.Text = "Active Start Time"
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.Gainsboro
        Me.Label62.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label62.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(265, 545)
        Me.Label62.Name = "Label62"
        Me.Label62.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label62.Size = New System.Drawing.Size(160, 17)
        Me.Label62.TabIndex = 86
        Me.Label62.Text = "SCALE: Scale Table"
        '
        'SolicitedCheck
        '
        Me.SolicitedCheck.AutoSize = True
        Me.SolicitedCheck.Location = New System.Drawing.Point(16, 497)
        Me.SolicitedCheck.Name = "SolicitedCheck"
        Me.SolicitedCheck.Size = New System.Drawing.Size(66, 18)
        Me.SolicitedCheck.TabIndex = 39
        Me.SolicitedCheck.Text = "Solicited"
        Me.SolicitedCheck.UseVisualStyleBackColor = True
        '
        'RandomizeSizeCheck
        '
        Me.RandomizeSizeCheck.AutoSize = True
        Me.RandomizeSizeCheck.Location = New System.Drawing.Point(16, 521)
        Me.RandomizeSizeCheck.Name = "RandomizeSizeCheck"
        Me.RandomizeSizeCheck.Size = New System.Drawing.Size(103, 18)
        Me.RandomizeSizeCheck.TabIndex = 40
        Me.RandomizeSizeCheck.Text = "Randomize Size"
        Me.RandomizeSizeCheck.UseVisualStyleBackColor = True
        '
        'RandomizePriceCheck
        '
        Me.RandomizePriceCheck.AutoSize = True
        Me.RandomizePriceCheck.Location = New System.Drawing.Point(16, 545)
        Me.RandomizePriceCheck.Name = "RandomizePriceCheck"
        Me.RandomizePriceCheck.Size = New System.Drawing.Size(106, 18)
        Me.RandomizePriceCheck.TabIndex = 41
        Me.RandomizePriceCheck.Text = "Randomize Price"
        Me.RandomizePriceCheck.UseVisualStyleBackColor = True
        '
        'ModelCodeText
        '
        Me.ModelCodeText.AcceptsReturn = True
        Me.ModelCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.ModelCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModelCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ModelCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModelCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ModelCodeText.Location = New System.Drawing.Point(143, 567)
        Me.ModelCodeText.MaxLength = 0
        Me.ModelCodeText.Name = "ModelCodeText"
        Me.ModelCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ModelCodeText.Size = New System.Drawing.Size(85, 13)
        Me.ModelCodeText.TabIndex = 43
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Gainsboro
        Me.Label63.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label63.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(13, 570)
        Me.Label63.Name = "Label63"
        Me.Label63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label63.Size = New System.Drawing.Size(65, 17)
        Me.Label63.TabIndex = 42
        Me.Label63.Text = "Model Code"
        '
        'TransmitCheck
        '
        Me.TransmitCheck.AutoSize = True
        Me.TransmitCheck.Location = New System.Drawing.Point(19, 273)
        Me.TransmitCheck.Name = "TransmitCheck"
        Me.TransmitCheck.Size = New System.Drawing.Size(67, 18)
        Me.TransmitCheck.TabIndex = 22
        Me.TransmitCheck.Text = "Transmit"
        Me.TransmitCheck.UseVisualStyleBackColor = True
        '
        'DontUseAutoPriceForHedgeCheck
        '
        Me.DontUseAutoPriceForHedgeCheck.AutoSize = True
        Me.DontUseAutoPriceForHedgeCheck.Location = New System.Drawing.Point(550, 591)
        Me.DontUseAutoPriceForHedgeCheck.Name = "DontUseAutoPriceForHedgeCheck"
        Me.DontUseAutoPriceForHedgeCheck.Size = New System.Drawing.Size(172, 18)
        Me.DontUseAutoPriceForHedgeCheck.TabIndex = 146
        Me.DontUseAutoPriceForHedgeCheck.Text = "Don't use auto price for hedge"
        Me.DontUseAutoPriceForHedgeCheck.UseVisualStyleBackColor = True
        '
        'Mifid2ExecutionTraderText
        '
        Me.Mifid2ExecutionTraderText.AcceptsReturn = True
        Me.Mifid2ExecutionTraderText.BackColor = System.Drawing.SystemColors.Window
        Me.Mifid2ExecutionTraderText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Mifid2ExecutionTraderText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Mifid2ExecutionTraderText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mifid2ExecutionTraderText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mifid2ExecutionTraderText.Location = New System.Drawing.Point(143, 612)
        Me.Mifid2ExecutionTraderText.MaxLength = 0
        Me.Mifid2ExecutionTraderText.Name = "Mifid2ExecutionTraderText"
        Me.Mifid2ExecutionTraderText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Mifid2ExecutionTraderText.Size = New System.Drawing.Size(85, 13)
        Me.Mifid2ExecutionTraderText.TabIndex = 150
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.Gainsboro
        Me.Label66.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label66.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(11, 612)
        Me.Label66.Name = "Label66"
        Me.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label66.Size = New System.Drawing.Size(133, 17)
        Me.Label66.TabIndex = 149
        Me.Label66.Text = "MiFID II Execution Trader"
        '
        'Mifid2ExecutionAlgoText
        '
        Me.Mifid2ExecutionAlgoText.AcceptsReturn = True
        Me.Mifid2ExecutionAlgoText.BackColor = System.Drawing.SystemColors.Window
        Me.Mifid2ExecutionAlgoText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Mifid2ExecutionAlgoText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Mifid2ExecutionAlgoText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mifid2ExecutionAlgoText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mifid2ExecutionAlgoText.Location = New System.Drawing.Point(432, 638)
        Me.Mifid2ExecutionAlgoText.MaxLength = 0
        Me.Mifid2ExecutionAlgoText.Name = "Mifid2ExecutionAlgoText"
        Me.Mifid2ExecutionAlgoText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Mifid2ExecutionAlgoText.Size = New System.Drawing.Size(85, 13)
        Me.Mifid2ExecutionAlgoText.TabIndex = 154
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Gainsboro
        Me.Label67.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label67.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(264, 636)
        Me.Label67.Name = "Label67"
        Me.Label67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label67.Size = New System.Drawing.Size(160, 17)
        Me.Label67.TabIndex = 153
        Me.Label67.Text = "MiFID II Execution Algo"
        '
        'Mifid2DecisionMakerText
        '
        Me.Mifid2DecisionMakerText.AcceptsReturn = True
        Me.Mifid2DecisionMakerText.BackColor = System.Drawing.SystemColors.Window
        Me.Mifid2DecisionMakerText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Mifid2DecisionMakerText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Mifid2DecisionMakerText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mifid2DecisionMakerText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mifid2DecisionMakerText.Location = New System.Drawing.Point(142, 591)
        Me.Mifid2DecisionMakerText.MaxLength = 0
        Me.Mifid2DecisionMakerText.Name = "Mifid2DecisionMakerText"
        Me.Mifid2DecisionMakerText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Mifid2DecisionMakerText.Size = New System.Drawing.Size(85, 13)
        Me.Mifid2DecisionMakerText.TabIndex = 148
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Gainsboro
        Me.Label64.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label64.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(13, 591)
        Me.Label64.Name = "Label64"
        Me.Label64.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label64.Size = New System.Drawing.Size(121, 17)
        Me.Label64.TabIndex = 147
        Me.Label64.Text = "MiFID II Decision Maker"
        '
        'Mifid2DecisionAlgoText
        '
        Me.Mifid2DecisionAlgoText.AcceptsReturn = True
        Me.Mifid2DecisionAlgoText.BackColor = System.Drawing.SystemColors.Window
        Me.Mifid2DecisionAlgoText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Mifid2DecisionAlgoText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Mifid2DecisionAlgoText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mifid2DecisionAlgoText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mifid2DecisionAlgoText.Location = New System.Drawing.Point(432, 615)
        Me.Mifid2DecisionAlgoText.MaxLength = 0
        Me.Mifid2DecisionAlgoText.Name = "Mifid2DecisionAlgoText"
        Me.Mifid2DecisionAlgoText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Mifid2DecisionAlgoText.Size = New System.Drawing.Size(85, 13)
        Me.Mifid2DecisionAlgoText.TabIndex = 152
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.Gainsboro
        Me.Label65.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label65.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(264, 615)
        Me.Label65.Name = "Label65"
        Me.Label65.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label65.Size = New System.Drawing.Size(160, 17)
        Me.Label65.TabIndex = 151
        Me.Label65.Text = "MiFID II Decision Algo"
        '
        'BlockOrderCheck
        '
        Me.BlockOrderCheck.AutoSize = True
        Me.BlockOrderCheck.Location = New System.Drawing.Point(19, 297)
        Me.BlockOrderCheck.Name = "BlockOrderCheck"
        Me.BlockOrderCheck.Size = New System.Drawing.Size(83, 18)
        Me.BlockOrderCheck.TabIndex = 155
        Me.BlockOrderCheck.Text = "Block Order"
        Me.BlockOrderCheck.UseVisualStyleBackColor = True
        '
        'SweepToFillCheck
        '
        Me.SweepToFillCheck.AutoSize = True
        Me.SweepToFillCheck.Location = New System.Drawing.Point(19, 321)
        Me.SweepToFillCheck.Name = "SweepToFillCheck"
        Me.SweepToFillCheck.Size = New System.Drawing.Size(88, 18)
        Me.SweepToFillCheck.TabIndex = 156
        Me.SweepToFillCheck.Text = "Sweep to Fill"
        Me.SweepToFillCheck.UseVisualStyleBackColor = True
        '
        'OutsideRTHCheck
        '
        Me.OutsideRTHCheck.AutoSize = True
        Me.OutsideRTHCheck.Location = New System.Drawing.Point(267, 296)
        Me.OutsideRTHCheck.Name = "OutsideRTHCheck"
        Me.OutsideRTHCheck.Size = New System.Drawing.Size(86, 18)
        Me.OutsideRTHCheck.TabIndex = 157
        Me.OutsideRTHCheck.Text = "Outside RTH"
        Me.OutsideRTHCheck.UseVisualStyleBackColor = True
        '
        'OverridePercentageConstraintsCheck
        '
        Me.OverridePercentageConstraintsCheck.AutoSize = True
        Me.OverridePercentageConstraintsCheck.Location = New System.Drawing.Point(267, 224)
        Me.OverridePercentageConstraintsCheck.Name = "OverridePercentageConstraintsCheck"
        Me.OverridePercentageConstraintsCheck.Size = New System.Drawing.Size(184, 18)
        Me.OverridePercentageConstraintsCheck.TabIndex = 158
        Me.OverridePercentageConstraintsCheck.Text = "Override Percentage Constraints"
        Me.OverridePercentageConstraintsCheck.UseVisualStyleBackColor = True
        '
        'AllOrNoneCheck
        '
        Me.AllOrNoneCheck.AutoSize = True
        Me.AllOrNoneCheck.Location = New System.Drawing.Point(267, 81)
        Me.AllOrNoneCheck.Name = "AllOrNoneCheck"
        Me.AllOrNoneCheck.Size = New System.Drawing.Size(79, 18)
        Me.AllOrNoneCheck.TabIndex = 159
        Me.AllOrNoneCheck.Text = "All or None"
        Me.AllOrNoneCheck.UseVisualStyleBackColor = True
        '
        'FirmQuoteOnlyCheck
        '
        Me.FirmQuoteOnlyCheck.AutoSize = True
        Me.FirmQuoteOnlyCheck.Location = New System.Drawing.Point(268, 179)
        Me.FirmQuoteOnlyCheck.Name = "FirmQuoteOnlyCheck"
        Me.FirmQuoteOnlyCheck.Size = New System.Drawing.Size(103, 18)
        Me.FirmQuoteOnlyCheck.TabIndex = 160
        Me.FirmQuoteOnlyCheck.Text = "Firm Quote Only"
        Me.FirmQuoteOnlyCheck.UseVisualStyleBackColor = True
        '
        'ETradeOnlyCheck
        '
        Me.ETradeOnlyCheck.AutoSize = True
        Me.ETradeOnlyCheck.Location = New System.Drawing.Point(267, 154)
        Me.ETradeOnlyCheck.Name = "ETradeOnlyCheck"
        Me.ETradeOnlyCheck.Size = New System.Drawing.Size(149, 18)
        Me.ETradeOnlyCheck.TabIndex = 161
        Me.ETradeOnlyCheck.Text = "Electronic Exchange Only"
        Me.ETradeOnlyCheck.UseVisualStyleBackColor = True
        '
        'ContinuousUpdateCheck
        '
        Me.ContinuousUpdateCheck.AutoSize = True
        Me.ContinuousUpdateCheck.Location = New System.Drawing.Point(552, 299)
        Me.ContinuousUpdateCheck.Name = "ContinuousUpdateCheck"
        Me.ContinuousUpdateCheck.Size = New System.Drawing.Size(142, 18)
        Me.ContinuousUpdateCheck.TabIndex = 162
        Me.ContinuousUpdateCheck.Text = "VOL Continuous Update"
        Me.ContinuousUpdateCheck.UseVisualStyleBackColor = True
        '
        'OrderPropertyGrid
        '
        Me.OrderPropertyGrid.Location = New System.Drawing.Point(855, 214)
        Me.OrderPropertyGrid.Name = "OrderPropertyGrid"
        Me.OrderPropertyGrid.Size = New System.Drawing.Size(287, 595)
        Me.OrderPropertyGrid.TabIndex = 163
        '
        'LmtPriceOffsetText
        '
        Me.LmtPriceOffsetText.AcceptsReturn = True
        Me.LmtPriceOffsetText.BackColor = System.Drawing.SystemColors.Window
        Me.LmtPriceOffsetText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LmtPriceOffsetText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LmtPriceOffsetText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LmtPriceOffsetText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LmtPriceOffsetText.Location = New System.Drawing.Point(432, 58)
        Me.LmtPriceOffsetText.MaxLength = 0
        Me.LmtPriceOffsetText.Name = "LmtPriceOffsetText"
        Me.LmtPriceOffsetText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LmtPriceOffsetText.Size = New System.Drawing.Size(85, 13)
        Me.LmtPriceOffsetText.TabIndex = 165
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(264, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(136, 17)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Lmt Price Offset"
        '
        'FOrderAttribs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1158, 832)
        Me.Controls.Add(Me.LmtPriceOffsetText)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.OrderPropertyGrid)
        Me.Controls.Add(Me.ContinuousUpdateCheck)
        Me.Controls.Add(Me.ETradeOnlyCheck)
        Me.Controls.Add(Me.FirmQuoteOnlyCheck)
        Me.Controls.Add(Me.AllOrNoneCheck)
        Me.Controls.Add(Me.OverridePercentageConstraintsCheck)
        Me.Controls.Add(Me.OutsideRTHCheck)
        Me.Controls.Add(Me.SweepToFillCheck)
        Me.Controls.Add(Me.BlockOrderCheck)
        Me.Controls.Add(Me.Mifid2ExecutionTraderText)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Mifid2ExecutionAlgoText)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Mifid2DecisionMakerText)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Mifid2DecisionAlgoText)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.DontUseAutoPriceForHedgeCheck)
        Me.Controls.Add(Me.TransmitCheck)
        Me.Controls.Add(Me.ModelCodeText)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.RandomizePriceCheck)
        Me.Controls.Add(Me.RandomizeSizeCheck)
        Me.Controls.Add(Me.SolicitedCheck)
        Me.Controls.Add(Me.ActiveStopTimeText)
        Me.Controls.Add(Me.ActiveStartTimeText)
        Me.Controls.Add(Me.ScaleTableText)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.DeltaNeutralDesignatedLocationText)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.DeltaNeutralShortSaleSlotText)
        Me.Controls.Add(Me.DeltaNeutralShortSaleCheck)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.DeltaNeutralOpenCloseText)
        Me.Controls.Add(Me.TrailingPercentText)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.ScaleProfitOffsetText)
        Me.Controls.Add(Me.ScaleInitFillQtyText)
        Me.Controls.Add(Me.ScaleInitPositionText)
        Me.Controls.Add(Me.ScalePriceAdjustIntervalText)
        Me.Controls.Add(Me.ScaleRandomPercentCheck)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.ScalePriceAdjustValueText)
        Me.Controls.Add(Me.ScaleAutoResetCheck)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.DeltaNeutralSettlingFirmText)
        Me.Controls.Add(Me.DeltaNeutralClearingAccountText)
        Me.Controls.Add(Me.DeltaNeutralClearingIntentText)
        Me.Controls.Add(Me.DeltaNeutralConIdText)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.OptOutSmartRoutingCheck)
        Me.Controls.Add(Me.LabelHedgeParam)
        Me.Controls.Add(Me.LabelHedgeType)
        Me.Controls.Add(Me.HedgeParamText)
        Me.Controls.Add(Me.HedgeTypeText)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.ExemptCodeText)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.ClearingIntentText)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ClearingAccountText)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.ScalePriceIncrText)
        Me.Controls.Add(Me.ScaleSubsLevelSizeText)
        Me.Controls.Add(Me.ScaleInitLevelSizeText)
        Me.Controls.Add(Me.TrailStopPriceText)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.DeltaNeutralAuxPriceText)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.VolatilityText)
        Me.Controls.Add(Me.VolatilityTypeText)
        Me.Controls.Add(Me.DeltaNeutralOrderTypeText)
        Me.Controls.Add(Me.ReferencePriceTypeText)
        Me.Controls.Add(Me.Rule80AText)
        Me.Controls.Add(Me.SettlingFirmText)
        Me.Controls.Add(Me.MinQtyText)
        Me.Controls.Add(Me.PercentOffsetText)
        Me.Controls.Add(Me.NBBOPriceCapText)
        Me.Controls.Add(Me.AuctionStrategyText)
        Me.Controls.Add(Me.StartingPriceText)
        Me.Controls.Add(Me.StockRefPriceText)
        Me.Controls.Add(Me.DeltaText)
        Me.Controls.Add(Me.StockRangeLowerText)
        Me.Controls.Add(Me.StockRangeUpperText)
        Me.Controls.Add(Me.OcaTypeText)
        Me.Controls.Add(Me.ShortSaleSlotText)
        Me.Controls.Add(Me.DesignatedLocationText)
        Me.Controls.Add(Me.DiscretionaryAmtText)
        Me.Controls.Add(Me.HiddenText)
        Me.Controls.Add(Me.TriggerMethodText)
        Me.Controls.Add(Me.DisplaySizeText)
        Me.Controls.Add(Me.ParentIdText)
        Me.Controls.Add(Me.OrderRefText)
        Me.Controls.Add(Me.OriginText)
        Me.Controls.Add(Me.OpenCloseText)
        Me.Controls.Add(Me.AccountText)
        Me.Controls.Add(Me.OCAText)
        Me.Controls.Add(Me.TIFText)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(1030, 270)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FOrderAttribs"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extended Order Attributes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    ' ========================================================
    ' Member variables
    ' ========================================================
    Private mOrderInfo As Order

    Private mOk As Boolean

    ' ========================================================
    ' Public Methods
    ' ========================================================
    Public Sub Init(orderInfo As Order, transmit As Boolean)
        mOrderInfo = orderInfo

        OrderPropertyGrid.SelectedObject = mOrderInfo
        TransmitCheck.Checked = transmit

        mOk = False

        '        ModelCodeText.Text = mOrderInfo.ModelCode
        TIFText.Text = mOrderInfo.Tif
        ActiveStartTimeText.Text = mOrderInfo.ActiveStartTime
        ActiveStopTimeText.Text = mOrderInfo.ActiveStopTime
        OCAText.Text = mOrderInfo.OcaGroup
        OcaTypeText.Text = mOrderInfo.OcaType
        OrderRefText.Text = mOrderInfo.OrderRef
        ParentIdText.Text = mOrderInfo.ParentId
        BlockOrderCheck.Checked = mOrderInfo.BlockOrder
        SweepToFillCheck.Checked = mOrderInfo.SweepToFill
        DisplaySizeText.Text = mOrderInfo.DisplaySize
        TriggerMethodText.Text = mOrderInfo.TriggerMethod
        OutsideRTHCheck.Checked = mOrderInfo.OutsideRth
        HiddenText.Text = mOrderInfo.Hidden
        OverridePercentageConstraintsCheck.Checked = mOrderInfo.OverridePercentageConstraints
        Rule80AText.Text = mOrderInfo.Rule80A
        AllOrNoneCheck.Checked = mOrderInfo.AllOrNone
        MinQtyText.Text = IBAPI.NullableToString(mOrderInfo.MinQty)
        PercentOffsetText.Text = IBAPI.NullableToString(mOrderInfo.PercentOffset)
        TrailStopPriceText.Text = IBAPI.NullableToString(mOrderInfo.TrailStopPrice)
        TrailingPercentText.Text = IBAPI.NullableToString(mOrderInfo.TrailingPercent)
        LmtPriceOffsetText.Text = IBAPI.NullableToString(mOrderInfo.LmtPriceOffset)

        ' Institutional orders only
        OpenCloseText.Text = mOrderInfo.OpenClose
        OriginText.Text = mOrderInfo.Origin
        ShortSaleSlotText.Text = mOrderInfo.ShortSaleSlot
        DesignatedLocationText.Text = mOrderInfo.DesignatedLocation
        ExemptCodeText.Text = mOrderInfo.ExemptCode

        'SMART routing only
        DiscretionaryAmtText.Text = mOrderInfo.DiscretionaryAmt
        ETradeOnlyCheck.Checked = mOrderInfo.ETradeOnly
        FirmQuoteOnlyCheck.Checked = mOrderInfo.FirmQuoteOnly
        NBBOPriceCapText.Text = IBAPI.NullableToString(mOrderInfo.NbboPriceCap)
        OptOutSmartRoutingCheck.Checked = mOrderInfo.OptOutSmartRouting

        ' BOX or VOL orders only
        AuctionStrategyText.Text = mOrderInfo.AuctionStrategy

        'BOX orders only
        StartingPriceText.Text = IBAPI.NullableToString(mOrderInfo.StartingPrice)
        StockRefPriceText.Text = IBAPI.NullableToString(mOrderInfo.StockRefPrice)
        DeltaText.Text = IBAPI.NullableToString(mOrderInfo.Delta)

        ' pegged to stock or VOL orders
        StockRangeLowerText.Text = IBAPI.NullableToString(mOrderInfo.StockRangeLower)
        StockRangeUpperText.Text = IBAPI.NullableToString(mOrderInfo.StockRangeUpper)

        ' VOLATILITY orders only
        VolatilityText.Text = IBAPI.NullableToString(mOrderInfo.Volatility)
        VolatilityTypeText.Text = IBAPI.NullableToString(mOrderInfo.VolatilityType)
        ContinuousUpdateCheck.Checked = mOrderInfo.ContinuousUpdate
        ReferencePriceTypeText.Text = IBAPI.NullableToString(mOrderInfo.ReferencePriceType)
        DeltaNeutralOrderTypeText.Text = mOrderInfo.DeltaNeutralOrderType
        DeltaNeutralAuxPriceText.Text = IBAPI.NullableToString(mOrderInfo.DeltaNeutralAuxPrice)
        DeltaNeutralConIdText.Text = IBAPI.NullableToString(mOrderInfo.DeltaNeutralConId)
        DeltaNeutralSettlingFirmText.Text = mOrderInfo.DeltaNeutralSettlingFirm
        DeltaNeutralClearingAccountText.Text = mOrderInfo.DeltaNeutralClearingAccount
        DeltaNeutralClearingIntentText.Text = mOrderInfo.DeltaNeutralClearingIntent
        DeltaNeutralOpenCloseText.Text = mOrderInfo.DeltaNeutralOpenClose
        DeltaNeutralShortSaleCheck.Checked = mOrderInfo.DeltaNeutralShortSale
        DeltaNeutralShortSaleSlotText.Text = IBAPI.NullableToString(mOrderInfo.DeltaNeutralShortSaleSlot)
        DeltaNeutralDesignatedLocationText.Text = mOrderInfo.DeltaNeutralDesignatedLocation

        ' SCALE orders only
        ScaleInitLevelSizeText.Text = IBAPI.NullableToString(mOrderInfo.ScaleInitLevelSize)
        ScaleSubsLevelSizeText.Text = IBAPI.NullableToString(mOrderInfo.ScaleSubsLevelSize)
        ScalePriceIncrText.Text = IBAPI.NullableToString(mOrderInfo.ScalePriceIncrement)
        ScalePriceAdjustValueText.Text = IBAPI.NullableToString(mOrderInfo.ScalePriceAdjustValue)
        ScalePriceAdjustIntervalText.Text = IBAPI.NullableToString(mOrderInfo.ScalePriceAdjustInterval)
        ScaleProfitOffsetText.Text = IBAPI.NullableToString(mOrderInfo.ScaleProfitOffset)
        ScaleAutoResetCheck.Checked = mOrderInfo.ScaleAutoReset
        ScaleInitPositionText.Text = IBAPI.NullableToString(mOrderInfo.ScaleInitPosition)
        ScaleInitFillQtyText.Text = IBAPI.NullableToString(mOrderInfo.ScaleInitFillQty)
        ScaleRandomPercentCheck.Checked = mOrderInfo.ScaleRandomPercent
        ScaleTableText.Text = mOrderInfo.ScaleTable

        ' HEDGE orders only
        HedgeTypeText.Text = mOrderInfo.HedgeType
        HedgeParamText.Text = mOrderInfo.HedgeParam

        ' Clearing info
        AccountText.Text = mOrderInfo.Account
        SettlingFirmText.Text = mOrderInfo.SettlingFirm
        ClearingAccountText.Text = mOrderInfo.ClearingAccount
        ClearingIntentText.Text = mOrderInfo.ClearingIntent

        '        cbSolicited.CheckEd = mOrderInfo.Solicited

    End Sub

    ' ========================================================
    ' Public Properties
    ' ========================================================

    Public ReadOnly Property Transmit As Boolean
        Get
            Return TransmitCheck.Checked
        End Get
    End Property

    Public ReadOnly Property Ok() As Boolean
        Get
            Ok = mOk
        End Get
    End Property

    Private Function ival(text As String) As Integer
        If Len(text) = 0 Then
            Return Int32.MaxValue
        Else
            Return CInt(text)
        End If
    End Function

    Private Function dval(text As String) As Double
        If Len(text) = 0 Then
            Return Double.MaxValue
        Else
            Return CDbl(text)
        End If
    End Function

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        mOrderInfo.Tif = TIFText.Text
        mOrderInfo.ActiveStartTime = ActiveStartTimeText.Text
        mOrderInfo.ActiveStopTime = ActiveStopTimeText.Text
        mOrderInfo.OcaGroup = OCAText.Text
        mOrderInfo.OcaType = ival(OcaTypeText.Text)
        mOrderInfo.OrderRef = OrderRefText.Text
        mOrderInfo.ParentId = ival(ParentIdText.Text)
        mOrderInfo.BlockOrder = BlockOrderCheck.Checked
        mOrderInfo.SweepToFill = SweepToFillCheck.Checked
        mOrderInfo.DisplaySize = ival(DisplaySizeText.Text)
        mOrderInfo.TriggerMethod = TriggerMethodText.Text
        mOrderInfo.OutsideRth = OutsideRTHCheck.Checked
        mOrderInfo.Hidden = HiddenText.Text
        mOrderInfo.OverridePercentageConstraints = OverridePercentageConstraintsCheck.Checked
        mOrderInfo.Rule80A = Rule80AText.Text
        mOrderInfo.AllOrNone = AllOrNoneCheck.Checked
        mOrderInfo.MinQty = IBAPI.NullableIntegerFromString(MinQtyText.Text)
        mOrderInfo.PercentOffset = IBAPI.NullableDoubleFromString(PercentOffsetText.Text)
        mOrderInfo.TrailStopPrice = IBAPI.NullableDoubleFromString(TrailStopPriceText.Text)
        mOrderInfo.TrailingPercent = IBAPI.NullableDoubleFromString(TrailingPercentText.Text)
        mOrderInfo.LmtPriceOffset = LmtPriceOffsetText.Text

        ' Institutional orders only
        mOrderInfo.OpenClose = OpenCloseText.Text
        mOrderInfo.Origin = ival(OriginText.Text)
        mOrderInfo.ShortSaleSlot = ival(ShortSaleSlotText.Text)
        mOrderInfo.DesignatedLocation = DesignatedLocationText.Text
        If Not String.IsNullOrEmpty(ExemptCodeText.Text) Then
            mOrderInfo.ExemptCode = ival(ExemptCodeText.Text)
        Else
            mOrderInfo.ExemptCode = ival("-1")
        End If

        'SMART routing only
        mOrderInfo.DiscretionaryAmt = dval(DiscretionaryAmtText.Text)
        mOrderInfo.ETradeOnly = ETradeOnlyCheck.Checked
        mOrderInfo.FirmQuoteOnly = FirmQuoteOnlyCheck.Checked
        mOrderInfo.NbboPriceCap = NBBOPriceCapText.Text
        mOrderInfo.OptOutSmartRouting = OptOutSmartRoutingCheck.Checked

        ' BOX or VOL orders only
        mOrderInfo.AuctionStrategy = ival(AuctionStrategyText.Text)

        'BOX orders only
        mOrderInfo.StartingPrice = dval(StartingPriceText.Text)
        mOrderInfo.StockRefPrice = dval(StockRefPriceText.Text)
        mOrderInfo.Delta = dval(DeltaText.Text)

        ' pegged to stock or VOL orders
        mOrderInfo.StockRangeLower = dval(StockRangeLowerText.Text)
        mOrderInfo.StockRangeUpper = dval(StockRangeUpperText.Text)

        ' VOLATILITY orders only
        mOrderInfo.Volatility = dval(VolatilityText.Text)
        mOrderInfo.VolatilityType = ival(VolatilityTypeText.Text)
        mOrderInfo.ContinuousUpdate = ContinuousUpdateCheck.Checked
        mOrderInfo.ReferencePriceType = ival(ReferencePriceTypeText.Text)
        mOrderInfo.DeltaNeutralOrderType = DeltaNeutralOrderTypeText.Text
        mOrderInfo.DeltaNeutralAuxPrice = dval(DeltaNeutralAuxPriceText.Text)
        mOrderInfo.DeltaNeutralConId = ival(DeltaNeutralConIdText.Text)
        mOrderInfo.DeltaNeutralSettlingFirm = DeltaNeutralSettlingFirmText.Text
        mOrderInfo.DeltaNeutralClearingAccount = DeltaNeutralClearingAccountText.Text
        mOrderInfo.DeltaNeutralClearingIntent = DeltaNeutralClearingIntentText.Text
        mOrderInfo.DeltaNeutralOpenClose = DeltaNeutralOpenCloseText.Text
        mOrderInfo.DeltaNeutralShortSale = DeltaNeutralShortSaleCheck.Checked
        mOrderInfo.DeltaNeutralShortSaleSlot = ival(DeltaNeutralShortSaleSlotText.Text)
        mOrderInfo.DeltaNeutralDesignatedLocation = DeltaNeutralDesignatedLocationText.Text

        ' SCALE orders only
        mOrderInfo.ScaleInitLevelSize = ScaleInitLevelSizeText.Text
        mOrderInfo.ScaleSubsLevelSize = ScaleSubsLevelSizeText.Text
        mOrderInfo.ScalePriceIncrement = ScalePriceIncrText.Text
        mOrderInfo.ScalePriceAdjustValue = ScalePriceAdjustValueText.Text
        mOrderInfo.ScalePriceAdjustInterval = ScalePriceAdjustIntervalText.Text
        mOrderInfo.ScaleProfitOffset = ScaleProfitOffsetText.Text
        mOrderInfo.ScaleAutoReset = ScaleAutoResetCheck.Checked
        mOrderInfo.ScaleInitPosition = ScaleInitPositionText.Text
        mOrderInfo.ScaleInitFillQty = ScaleInitFillQtyText.Text
        mOrderInfo.ScaleRandomPercent = ScaleRandomPercentCheck.Checked
        mOrderInfo.ScaleTable = ScaleTableText.Text

        ' HEDGE orders only
        mOrderInfo.HedgeType = HedgeTypeText.Text
        mOrderInfo.HedgeParam = HedgeParamText.Text

        ' Clearing info
        mOrderInfo.Account = AccountText.Text
        mOrderInfo.SettlingFirm = SettlingFirmText.Text
        mOrderInfo.ClearingAccount = ClearingAccountText.Text
        mOrderInfo.ClearingIntent = ClearingIntentText.Text

        mOrderInfo.Solicited = SolicitedCheck.Checked
        mOrderInfo.RandomizePrice = RandomizePriceCheck.Checked
        mOrderInfo.RandomizeSize = RandomizeSizeCheck.Checked
        mOrderInfo.ModelCode = ModelCodeText.Text
        mOrderInfo.Mifid2DecisionMaker = Mifid2DecisionMakerText.Text
        mOrderInfo.Mifid2DecisionAlgo = Mifid2DecisionAlgoText.Text
        mOrderInfo.Mifid2ExecutionTrader = Mifid2ExecutionTraderText.Text
        mOrderInfo.Mifid2ExecutionAlgo = Mifid2ExecutionAlgoText.Text

        mOrderInfo.DontUseAutoPriceForHedge = DontUseAutoPriceForHedgeCheck.Checked

        mOk = True
        Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Hide()
    End Sub

End Class
