' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.



Imports System.Globalization
Imports System.Security.Cryptography.Xml
Imports TradeWright.IBAPI

Public Class FOrderAttribs
    Inherits Form
#Region "Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            mComponents?.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private ReadOnly mComponents As System.ComponentModel.IContainer
    Public ToolTip1 As ToolTip
    Public WithEvents Rule80AText As TextBox
    Public WithEvents SettlingFirmText As TextBox
    Public WithEvents MinQtyText As TextBox
    Public WithEvents PercentOffsetText As TextBox
    Public WithEvents AuctionStrategyText As TextBox
    Public WithEvents StartingPriceText As TextBox
    Public WithEvents StockRefPriceText As TextBox
    Public WithEvents DeltaText As TextBox
    Public WithEvents StockRangeLowerText As TextBox
    Public WithEvents StockRangeUpperText As TextBox
    Public WithEvents ShortSaleSlotText As TextBox
    Public WithEvents DesignatedLocationText As TextBox
    Public WithEvents DiscretionaryAmtText As TextBox
    Public WithEvents OkButton As Button
    Public WithEvents CancelItButton As Button
    Public WithEvents HiddenText As TextBox
    Public WithEvents TriggerMethodCombo As ComboBox
    Public WithEvents DisplaySizeText As TextBox
    Public WithEvents ParentIdText As TextBox
    Public WithEvents OrderRefText As TextBox
    Public WithEvents OriginText As TextBox
    Public WithEvents OpenCloseText As TextBox
    Public WithEvents AccountText As TextBox
    Public WithEvents OCAText As TextBox
    Public WithEvents Label35 As Label
    Public WithEvents Label34 As Label
    Public WithEvents Label33 As Label
    Public WithEvents Label32 As Label
    Public WithEvents Label28 As Label
    Public WithEvents Label27 As Label
    Public WithEvents Label26 As Label
    Public WithEvents Label25 As Label
    Public WithEvents Label24 As Label
    Public WithEvents Label23 As Label
    Public WithEvents Label19 As Label
    Public WithEvents Label17 As Label
    Public WithEvents Label16 As Label
    Public WithEvents Label15 As Label
    Public WithEvents Label14 As Label
    Public WithEvents Label12 As Label
    Public WithEvents Label11 As Label
    Public WithEvents Label7 As Label
    Public WithEvents Label6 As Label
    Public WithEvents Label5 As Label
    Public WithEvents Label4 As Label
    Public WithEvents Label3 As Label
    Public WithEvents Label2 As Label
    Public WithEvents Label1 As Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents VolatilityText As TextBox
    Public WithEvents VolatilityTypeText As TextBox
    Public WithEvents ReferencePriceTypeText As TextBox
    Public WithEvents Label21 As Label
    Public WithEvents Label22 As Label
    Public WithEvents Label36 As Label
    Public WithEvents Label40 As Label
    Public WithEvents DeltaNeutralOrderTypeText As TextBox
    Public WithEvents DeltaNeutralAuxPriceText As TextBox
    Public WithEvents Label38 As Label
    Public WithEvents TrailStopPriceText As TextBox
    Public WithEvents Label39 As Label
    Public WithEvents ScaleInitLevelSizeText As TextBox
    Public WithEvents ScaleSubsLevelSizeText As TextBox
    Public WithEvents ScalePriceIncrText As TextBox
    Public WithEvents Label42 As Label
    Public WithEvents Label43 As Label
    Public WithEvents Label44 As Label
    Public WithEvents ClearingAccountText As TextBox
    Public WithEvents Label18 As Label
    Public WithEvents ClearingIntentText As TextBox
    Public WithEvents Label45 As Label
    Friend WithEvents ExemptCodeText As TextBox
    Friend WithEvents Label46 As Label
    Public WithEvents HedgeTypeText As TextBox
    Public WithEvents HedgeParamText As TextBox
    Public WithEvents LabelHedgeType As Label
    Public WithEvents LabelHedgeParam As Label
    Friend WithEvents OptOutSmartRoutingCheck As CheckBox
    Public WithEvents Label47 As Label
    Public WithEvents Label48 As Label
    Public WithEvents Label49 As Label
    Public WithEvents Label50 As Label
    Public WithEvents DeltaNeutralConIdText As TextBox
    Public WithEvents DeltaNeutralClearingIntentText As TextBox
    Public WithEvents DeltaNeutralClearingAccountText As TextBox
    Public WithEvents DeltaNeutralSettlingFirmText As TextBox
    Public WithEvents Label51 As Label
    Public WithEvents Label52 As Label
    Public WithEvents Label53 As Label
    Friend WithEvents ScaleAutoResetCheck As CheckBox
    Public WithEvents ScalePriceAdjustValueText As TextBox
    Public WithEvents Label54 As Label
    Public WithEvents Label55 As Label
    Friend WithEvents ScaleRandomPercentCheck As CheckBox
    Public WithEvents ScalePriceAdjustIntervalText As TextBox
    Public WithEvents ScaleInitPositionText As TextBox
    Public WithEvents ScaleInitFillQtyText As TextBox
    Public WithEvents ScaleProfitOffsetText As TextBox
    Public WithEvents Label56 As Label
    Public WithEvents TrailingPercentText As TextBox
    Public WithEvents DeltaNeutralOpenCloseText As TextBox
    Public WithEvents Label57 As Label
    Friend WithEvents DeltaNeutralShortSaleCheck As CheckBox
    Public WithEvents DeltaNeutralShortSaleSlotText As TextBox
    Public WithEvents Label58 As Label
    Public WithEvents DeltaNeutralDesignatedLocationText As TextBox
    Public WithEvents Label59 As Label
    Public WithEvents ActiveStopTimeText As TextBox
    Public WithEvents ActiveStartTimeText As TextBox
    Public WithEvents ScaleTableText As TextBox
    Public WithEvents Label60 As Label
    Public WithEvents Label61 As Label
    Public WithEvents Label62 As Label
    Friend WithEvents SolicitedCheck As CheckBox
    Friend WithEvents RandomizeSizeCheck As CheckBox
    Friend WithEvents RandomizePriceCheck As CheckBox
    Public WithEvents ModelCodeText As TextBox
    Public WithEvents Label63 As Label
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
    Friend WithEvents ContinuousUpdateCheck As CheckBox
    Friend WithEvents OrderPropertyGrid As PropertyGrid
    Private components As System.ComponentModel.IContainer
    Public WithEvents LmtPriceOffsetText As TextBox
    Public WithEvents Label8 As Label
    Public WithEvents DurationText As TextBox
    Public WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PostToAtsText As TextBox
    Friend WithEvents NotHeldCheck As CheckBox
    Friend WithEvents OmsContainerCheck As CheckBox
    Friend WithEvents RelativeDiscretionaryCheck As CheckBox
    Friend WithEvents OutsideRTHCheck As CheckBox
    Friend WithEvents AutoCancelParentCheck As CheckBox
    Public WithEvents Label31 As Label
    Public WithEvents AdvancedErrorOverrideText As TextBox
    Public WithEvents LabelManualOrderTime As Label
    Public WithEvents ManualOrderTimeText As TextBox
    Public WithEvents LabelManualOrderCancelTime As Label
    Friend WithEvents OcaTypeCombo As ComboBox
    Friend WithEvents TifCombo As ComboBox
    Public WithEvents ManualOrderCancelTimeText As TextBox
    Public WithEvents MinTradeQtyLabel As Label
    Public WithEvents MinTradeQtyText As TextBox
    Public WithEvents MinCompeteSizeLabel As Label
    Public WithEvents MinCompeteSizeText As TextBox
    Public WithEvents CompeteAgainstBestOffsetLabel As Label
    Public WithEvents CompeteAgainstBestOffsetText As TextBox
    Friend WithEvents CompeteAgainstBestOffsetUpToMidCheck As CheckBox
    Public WithEvents MidOffsetAtWholeLabel As Label
    Public WithEvents MidOffsetAtWholeText As TextBox
    Public WithEvents MidOffsetAtHalfLabel As Label
    Public WithEvents MidOffsetAtHalfText As TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        ToolTip1 = New ToolTip(components)
        HedgeParamText = New TextBox()
        RelativeDiscretionaryCheck = New CheckBox()
        Rule80AText = New TextBox()
        SettlingFirmText = New TextBox()
        MinQtyText = New TextBox()
        PercentOffsetText = New TextBox()
        DurationText = New TextBox()
        AuctionStrategyText = New TextBox()
        StartingPriceText = New TextBox()
        StockRefPriceText = New TextBox()
        DeltaText = New TextBox()
        StockRangeLowerText = New TextBox()
        StockRangeUpperText = New TextBox()
        ShortSaleSlotText = New TextBox()
        DesignatedLocationText = New TextBox()
        DiscretionaryAmtText = New TextBox()
        OkButton = New Button()
        CancelItButton = New Button()
        HiddenText = New TextBox()
        TriggerMethodCombo = New ComboBox()
        DisplaySizeText = New TextBox()
        ParentIdText = New TextBox()
        OrderRefText = New TextBox()
        OriginText = New TextBox()
        OpenCloseText = New TextBox()
        AccountText = New TextBox()
        OCAText = New TextBox()
        Label35 = New Label()
        Label34 = New Label()
        Label33 = New Label()
        Label32 = New Label()
        Label28 = New Label()
        Label27 = New Label()
        Label26 = New Label()
        Label25 = New Label()
        Label24 = New Label()
        Label23 = New Label()
        Label19 = New Label()
        Label17 = New Label()
        Label16 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        VolatilityText = New TextBox()
        VolatilityTypeText = New TextBox()
        DeltaNeutralOrderTypeText = New TextBox()
        ReferencePriceTypeText = New TextBox()
        Label21 = New Label()
        Label22 = New Label()
        Label36 = New Label()
        Label40 = New Label()
        DeltaNeutralAuxPriceText = New TextBox()
        Label38 = New Label()
        TrailStopPriceText = New TextBox()
        Label39 = New Label()
        ScaleInitLevelSizeText = New TextBox()
        ScaleSubsLevelSizeText = New TextBox()
        ScalePriceIncrText = New TextBox()
        Label42 = New Label()
        Label43 = New Label()
        Label44 = New Label()
        ClearingAccountText = New TextBox()
        Label18 = New Label()
        ClearingIntentText = New TextBox()
        Label45 = New Label()
        ExemptCodeText = New TextBox()
        Label46 = New Label()
        HedgeTypeText = New TextBox()
        LabelHedgeType = New Label()
        LabelHedgeParam = New Label()
        OptOutSmartRoutingCheck = New CheckBox()
        Label47 = New Label()
        Label48 = New Label()
        Label49 = New Label()
        Label50 = New Label()
        DeltaNeutralConIdText = New TextBox()
        DeltaNeutralClearingIntentText = New TextBox()
        DeltaNeutralClearingAccountText = New TextBox()
        DeltaNeutralSettlingFirmText = New TextBox()
        Label51 = New Label()
        Label52 = New Label()
        Label53 = New Label()
        ScaleAutoResetCheck = New CheckBox()
        ScalePriceAdjustValueText = New TextBox()
        Label54 = New Label()
        Label55 = New Label()
        ScaleRandomPercentCheck = New CheckBox()
        ScalePriceAdjustIntervalText = New TextBox()
        ScaleInitPositionText = New TextBox()
        ScaleInitFillQtyText = New TextBox()
        ScaleProfitOffsetText = New TextBox()
        Label56 = New Label()
        TrailingPercentText = New TextBox()
        DeltaNeutralOpenCloseText = New TextBox()
        Label57 = New Label()
        DeltaNeutralShortSaleCheck = New CheckBox()
        DeltaNeutralShortSaleSlotText = New TextBox()
        Label58 = New Label()
        DeltaNeutralDesignatedLocationText = New TextBox()
        Label59 = New Label()
        ActiveStopTimeText = New TextBox()
        ActiveStartTimeText = New TextBox()
        ScaleTableText = New TextBox()
        Label60 = New Label()
        Label61 = New Label()
        Label62 = New Label()
        SolicitedCheck = New CheckBox()
        RandomizeSizeCheck = New CheckBox()
        RandomizePriceCheck = New CheckBox()
        ModelCodeText = New TextBox()
        Label63 = New Label()
        TransmitCheck = New CheckBox()
        DontUseAutoPriceForHedgeCheck = New CheckBox()
        Mifid2ExecutionTraderText = New TextBox()
        Label66 = New Label()
        Mifid2ExecutionAlgoText = New TextBox()
        Label67 = New Label()
        Mifid2DecisionMakerText = New TextBox()
        Label64 = New Label()
        Mifid2DecisionAlgoText = New TextBox()
        Label65 = New Label()
        BlockOrderCheck = New CheckBox()
        SweepToFillCheck = New CheckBox()
        OutsideRTHCheck = New CheckBox()
        OverridePercentageConstraintsCheck = New CheckBox()
        AllOrNoneCheck = New CheckBox()
        ContinuousUpdateCheck = New CheckBox()
        OrderPropertyGrid = New PropertyGrid()
        LmtPriceOffsetText = New TextBox()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        PostToAtsText = New TextBox()
        NotHeldCheck = New CheckBox()
        OmsContainerCheck = New CheckBox()
        AutoCancelParentCheck = New CheckBox()
        Label31 = New Label()
        AdvancedErrorOverrideText = New TextBox()
        LabelManualOrderTime = New Label()
        ManualOrderTimeText = New TextBox()
        LabelManualOrderCancelTime = New Label()
        ManualOrderCancelTimeText = New TextBox()
        OcaTypeCombo = New ComboBox()
        TifCombo = New ComboBox()
        MinTradeQtyLabel = New Label()
        MinTradeQtyText = New TextBox()
        MinCompeteSizeLabel = New Label()
        MinCompeteSizeText = New TextBox()
        CompeteAgainstBestOffsetLabel = New Label()
        CompeteAgainstBestOffsetText = New TextBox()
        CompeteAgainstBestOffsetUpToMidCheck = New CheckBox()
        MidOffsetAtWholeLabel = New Label()
        MidOffsetAtWholeText = New TextBox()
        MidOffsetAtHalfLabel = New Label()
        MidOffsetAtHalfText = New TextBox()
        SuspendLayout()
        ' 
        ' HedgeParamText
        ' 
        HedgeParamText.AcceptsReturn = True
        HedgeParamText.BackColor = SystemColors.Window
        HedgeParamText.BorderStyle = BorderStyle.None
        HedgeParamText.Cursor = Cursors.IBeam
        HedgeParamText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        HedgeParamText.ForeColor = SystemColors.WindowText
        HedgeParamText.Location = New Point(143, 444)
        HedgeParamText.MaxLength = 0
        HedgeParamText.Name = "HedgeParamText"
        HedgeParamText.RightToLeft = RightToLeft.No
        HedgeParamText.Size = New Size(85, 13)
        HedgeParamText.TabIndex = 37
        ToolTip1.SetToolTip(HedgeParamText, "Allowed values are 'beta' for beta hedge and 'ratio' for pair hedge")
        ' 
        ' RelativeDiscretionaryCheck
        ' 
        RelativeDiscretionaryCheck.AutoSize = True
        RelativeDiscretionaryCheck.Location = New Point(549, 639)
        RelativeDiscretionaryCheck.Name = "RelativeDiscretionaryCheck"
        RelativeDiscretionaryCheck.Size = New Size(130, 18)
        RelativeDiscretionaryCheck.TabIndex = 149
        RelativeDiscretionaryCheck.Text = "Relative discretionary"
        RelativeDiscretionaryCheck.UseVisualStyleBackColor = True
        ' 
        ' Rule80AText
        ' 
        Rule80AText.AcceptsReturn = True
        Rule80AText.BackColor = SystemColors.Window
        Rule80AText.BorderStyle = BorderStyle.None
        Rule80AText.Cursor = Cursors.IBeam
        Rule80AText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Rule80AText.ForeColor = SystemColors.WindowText
        Rule80AText.Location = New Point(144, 394)
        Rule80AText.MaxLength = 0
        Rule80AText.Name = "Rule80AText"
        Rule80AText.RightToLeft = RightToLeft.No
        Rule80AText.Size = New Size(85, 13)
        Rule80AText.TabIndex = 33
        ' 
        ' SettlingFirmText
        ' 
        SettlingFirmText.AcceptsReturn = True
        SettlingFirmText.BackColor = SystemColors.Window
        SettlingFirmText.BorderStyle = BorderStyle.None
        SettlingFirmText.Cursor = Cursors.IBeam
        SettlingFirmText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        SettlingFirmText.ForeColor = SystemColors.WindowText
        SettlingFirmText.Location = New Point(144, 106)
        SettlingFirmText.MaxLength = 0
        SettlingFirmText.Name = "SettlingFirmText"
        SettlingFirmText.RightToLeft = RightToLeft.No
        SettlingFirmText.Size = New Size(85, 13)
        SettlingFirmText.TabIndex = 9
        ' 
        ' MinQtyText
        ' 
        MinQtyText.AcceptsReturn = True
        MinQtyText.BackColor = SystemColors.Window
        MinQtyText.BorderStyle = BorderStyle.None
        MinQtyText.Cursor = Cursors.IBeam
        MinQtyText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MinQtyText.ForeColor = SystemColors.WindowText
        MinQtyText.Location = New Point(433, 82)
        MinQtyText.MaxLength = 0
        MinQtyText.Name = "MinQtyText"
        MinQtyText.RightToLeft = RightToLeft.No
        MinQtyText.Size = New Size(85, 13)
        MinQtyText.TabIndex = 51
        ' 
        ' PercentOffsetText
        ' 
        PercentOffsetText.AcceptsReturn = True
        PercentOffsetText.BackColor = SystemColors.Window
        PercentOffsetText.BorderStyle = BorderStyle.None
        PercentOffsetText.Cursor = Cursors.IBeam
        PercentOffsetText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        PercentOffsetText.ForeColor = SystemColors.WindowText
        PercentOffsetText.Location = New Point(433, 106)
        PercentOffsetText.MaxLength = 0
        PercentOffsetText.Name = "PercentOffsetText"
        PercentOffsetText.RightToLeft = RightToLeft.No
        PercentOffsetText.Size = New Size(85, 13)
        PercentOffsetText.TabIndex = 53
        ' 
        ' DurationText
        ' 
        DurationText.AcceptsReturn = True
        DurationText.BackColor = SystemColors.Window
        DurationText.BorderStyle = BorderStyle.None
        DurationText.Cursor = Cursors.IBeam
        DurationText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DurationText.ForeColor = SystemColors.WindowText
        DurationText.Location = New Point(433, 130)
        DurationText.MaxLength = 0
        DurationText.Name = "DurationText"
        DurationText.RightToLeft = RightToLeft.No
        DurationText.Size = New Size(85, 13)
        DurationText.TabIndex = 167
        ' 
        ' AuctionStrategyText
        ' 
        AuctionStrategyText.AcceptsReturn = True
        AuctionStrategyText.BackColor = SystemColors.Window
        AuctionStrategyText.BorderStyle = BorderStyle.None
        AuctionStrategyText.Cursor = Cursors.IBeam
        AuctionStrategyText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        AuctionStrategyText.ForeColor = SystemColors.WindowText
        AuctionStrategyText.Location = New Point(433, 370)
        AuctionStrategyText.MaxLength = 0
        AuctionStrategyText.Name = "AuctionStrategyText"
        AuctionStrategyText.RightToLeft = RightToLeft.No
        AuctionStrategyText.Size = New Size(85, 13)
        AuctionStrategyText.TabIndex = 75
        AuctionStrategyText.Text = "0"
        ' 
        ' StartingPriceText
        ' 
        StartingPriceText.AcceptsReturn = True
        StartingPriceText.BackColor = SystemColors.Window
        StartingPriceText.BorderStyle = BorderStyle.None
        StartingPriceText.Cursor = Cursors.IBeam
        StartingPriceText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        StartingPriceText.ForeColor = SystemColors.WindowText
        StartingPriceText.Location = New Point(433, 394)
        StartingPriceText.MaxLength = 0
        StartingPriceText.Name = "StartingPriceText"
        StartingPriceText.RightToLeft = RightToLeft.No
        StartingPriceText.Size = New Size(85, 13)
        StartingPriceText.TabIndex = 77
        ' 
        ' StockRefPriceText
        ' 
        StockRefPriceText.AcceptsReturn = True
        StockRefPriceText.BackColor = SystemColors.Window
        StockRefPriceText.BorderStyle = BorderStyle.None
        StockRefPriceText.Cursor = Cursors.IBeam
        StockRefPriceText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        StockRefPriceText.ForeColor = SystemColors.WindowText
        StockRefPriceText.Location = New Point(433, 418)
        StockRefPriceText.MaxLength = 0
        StockRefPriceText.Name = "StockRefPriceText"
        StockRefPriceText.RightToLeft = RightToLeft.No
        StockRefPriceText.Size = New Size(85, 13)
        StockRefPriceText.TabIndex = 79
        ' 
        ' DeltaText
        ' 
        DeltaText.AcceptsReturn = True
        DeltaText.BackColor = SystemColors.Window
        DeltaText.BorderStyle = BorderStyle.None
        DeltaText.Cursor = Cursors.IBeam
        DeltaText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaText.ForeColor = SystemColors.WindowText
        DeltaText.Location = New Point(433, 442)
        DeltaText.MaxLength = 0
        DeltaText.Name = "DeltaText"
        DeltaText.RightToLeft = RightToLeft.No
        DeltaText.Size = New Size(85, 13)
        DeltaText.TabIndex = 81
        ' 
        ' StockRangeLowerText
        ' 
        StockRangeLowerText.AcceptsReturn = True
        StockRangeLowerText.BackColor = SystemColors.Window
        StockRangeLowerText.BorderStyle = BorderStyle.None
        StockRangeLowerText.Cursor = Cursors.IBeam
        StockRangeLowerText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        StockRangeLowerText.ForeColor = SystemColors.WindowText
        StockRangeLowerText.Location = New Point(433, 468)
        StockRangeLowerText.MaxLength = 0
        StockRangeLowerText.Name = "StockRangeLowerText"
        StockRangeLowerText.RightToLeft = RightToLeft.No
        StockRangeLowerText.Size = New Size(85, 13)
        StockRangeLowerText.TabIndex = 83
        ' 
        ' StockRangeUpperText
        ' 
        StockRangeUpperText.AcceptsReturn = True
        StockRangeUpperText.BackColor = SystemColors.Window
        StockRangeUpperText.BorderStyle = BorderStyle.None
        StockRangeUpperText.Cursor = Cursors.IBeam
        StockRangeUpperText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        StockRangeUpperText.ForeColor = SystemColors.WindowText
        StockRangeUpperText.Location = New Point(433, 494)
        StockRangeUpperText.MaxLength = 0
        StockRangeUpperText.Name = "StockRangeUpperText"
        StockRangeUpperText.RightToLeft = RightToLeft.No
        StockRangeUpperText.Size = New Size(85, 13)
        StockRangeUpperText.TabIndex = 85
        ' 
        ' ShortSaleSlotText
        ' 
        ShortSaleSlotText.AcceptsReturn = True
        ShortSaleSlotText.BackColor = SystemColors.Window
        ShortSaleSlotText.BorderStyle = BorderStyle.None
        ShortSaleSlotText.Cursor = Cursors.IBeam
        ShortSaleSlotText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ShortSaleSlotText.ForeColor = SystemColors.WindowText
        ShortSaleSlotText.Location = New Point(433, 346)
        ShortSaleSlotText.MaxLength = 0
        ShortSaleSlotText.Name = "ShortSaleSlotText"
        ShortSaleSlotText.RightToLeft = RightToLeft.No
        ShortSaleSlotText.Size = New Size(85, 13)
        ShortSaleSlotText.TabIndex = 73
        ' 
        ' DesignatedLocationText
        ' 
        DesignatedLocationText.AcceptsReturn = True
        DesignatedLocationText.BackColor = SystemColors.Window
        DesignatedLocationText.BorderStyle = BorderStyle.None
        DesignatedLocationText.Cursor = Cursors.IBeam
        DesignatedLocationText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DesignatedLocationText.ForeColor = SystemColors.WindowText
        DesignatedLocationText.Location = New Point(144, 346)
        DesignatedLocationText.MaxLength = 0
        DesignatedLocationText.Name = "DesignatedLocationText"
        DesignatedLocationText.RightToLeft = RightToLeft.No
        DesignatedLocationText.Size = New Size(85, 13)
        DesignatedLocationText.TabIndex = 29
        ' 
        ' DiscretionaryAmtText
        ' 
        DiscretionaryAmtText.AcceptsReturn = True
        DiscretionaryAmtText.BackColor = SystemColors.Window
        DiscretionaryAmtText.BorderStyle = BorderStyle.None
        DiscretionaryAmtText.Cursor = Cursors.IBeam
        DiscretionaryAmtText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DiscretionaryAmtText.ForeColor = SystemColors.WindowText
        DiscretionaryAmtText.Location = New Point(433, 322)
        DiscretionaryAmtText.MaxLength = 0
        DiscretionaryAmtText.Name = "DiscretionaryAmtText"
        DiscretionaryAmtText.RightToLeft = RightToLeft.No
        DiscretionaryAmtText.Size = New Size(85, 13)
        DiscretionaryAmtText.TabIndex = 71
        DiscretionaryAmtText.Text = "0"
        ' 
        ' OkButton
        ' 
        OkButton.BackColor = SystemColors.Control
        OkButton.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        OkButton.ForeColor = SystemColors.ControlText
        OkButton.Location = New Point(550, 754)
        OkButton.Name = "OkButton"
        OkButton.RightToLeft = RightToLeft.No
        OkButton.Size = New Size(73, 25)
        OkButton.TabIndex = 137
        OkButton.Text = "Ok"
        OkButton.UseVisualStyleBackColor = True
        ' 
        ' CancelItButton
        ' 
        CancelItButton.BackColor = SystemColors.Control
        CancelItButton.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        CancelItButton.ForeColor = SystemColors.ControlText
        CancelItButton.Location = New Point(665, 754)
        CancelItButton.Name = "CancelItButton"
        CancelItButton.RightToLeft = RightToLeft.No
        CancelItButton.Size = New Size(73, 25)
        CancelItButton.TabIndex = 138
        CancelItButton.Text = "Cancel"
        CancelItButton.UseVisualStyleBackColor = True
        ' 
        ' HiddenText
        ' 
        HiddenText.AcceptsReturn = True
        HiddenText.BackColor = SystemColors.Window
        HiddenText.BorderStyle = BorderStyle.None
        HiddenText.Cursor = Cursors.IBeam
        HiddenText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        HiddenText.ForeColor = SystemColors.WindowText
        HiddenText.Location = New Point(433, 298)
        HiddenText.MaxLength = 0
        HiddenText.Name = "HiddenText"
        HiddenText.RightToLeft = RightToLeft.No
        HiddenText.Size = New Size(85, 13)
        HiddenText.TabIndex = 69
        HiddenText.Text = "0"
        ' 
        ' TriggerMethodCombo
        ' 
        TriggerMethodCombo.BackColor = SystemColors.Window
        TriggerMethodCombo.Cursor = Cursors.IBeam
        TriggerMethodCombo.DropDownStyle = ComboBoxStyle.DropDownList
        TriggerMethodCombo.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        TriggerMethodCombo.ForeColor = SystemColors.WindowText
        TriggerMethodCombo.Location = New Point(433, 250)
        TriggerMethodCombo.Name = "TriggerMethodCombo"
        TriggerMethodCombo.RightToLeft = RightToLeft.No
        TriggerMethodCombo.Size = New Size(85, 22)
        TriggerMethodCombo.TabIndex = 65
        ' 
        ' DisplaySizeText
        ' 
        DisplaySizeText.AcceptsReturn = True
        DisplaySizeText.BackColor = SystemColors.Window
        DisplaySizeText.BorderStyle = BorderStyle.None
        DisplaySizeText.Cursor = Cursors.IBeam
        DisplaySizeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DisplaySizeText.ForeColor = SystemColors.WindowText
        DisplaySizeText.Location = New Point(433, 226)
        DisplaySizeText.MaxLength = 0
        DisplaySizeText.Name = "DisplaySizeText"
        DisplaySizeText.RightToLeft = RightToLeft.No
        DisplaySizeText.Size = New Size(85, 13)
        DisplaySizeText.TabIndex = 63
        DisplaySizeText.Text = "0"
        ' 
        ' ParentIdText
        ' 
        ParentIdText.AcceptsReturn = True
        ParentIdText.BackColor = SystemColors.Window
        ParentIdText.BorderStyle = BorderStyle.None
        ParentIdText.Cursor = Cursors.IBeam
        ParentIdText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ParentIdText.ForeColor = SystemColors.WindowText
        ParentIdText.Location = New Point(144, 250)
        ParentIdText.MaxLength = 0
        ParentIdText.Name = "ParentIdText"
        ParentIdText.RightToLeft = RightToLeft.No
        ParentIdText.Size = New Size(85, 13)
        ParentIdText.TabIndex = 21
        ParentIdText.Text = "0"
        ' 
        ' OrderRefText
        ' 
        OrderRefText.AcceptsReturn = True
        OrderRefText.BackColor = SystemColors.Window
        OrderRefText.BorderStyle = BorderStyle.None
        OrderRefText.Cursor = Cursors.IBeam
        OrderRefText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        OrderRefText.ForeColor = SystemColors.WindowText
        OrderRefText.Location = New Point(144, 226)
        OrderRefText.MaxLength = 0
        OrderRefText.Name = "OrderRefText"
        OrderRefText.RightToLeft = RightToLeft.No
        OrderRefText.Size = New Size(85, 13)
        OrderRefText.TabIndex = 19
        ' 
        ' OriginText
        ' 
        OriginText.AcceptsReturn = True
        OriginText.BackColor = SystemColors.Window
        OriginText.BorderStyle = BorderStyle.None
        OriginText.Cursor = Cursors.IBeam
        OriginText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        OriginText.ForeColor = SystemColors.WindowText
        OriginText.Location = New Point(144, 202)
        OriginText.MaxLength = 0
        OriginText.Name = "OriginText"
        OriginText.RightToLeft = RightToLeft.No
        OriginText.Size = New Size(85, 13)
        OriginText.TabIndex = 17
        OriginText.Text = "0"
        ' 
        ' OpenCloseText
        ' 
        OpenCloseText.AcceptsReturn = True
        OpenCloseText.BackColor = SystemColors.Window
        OpenCloseText.BorderStyle = BorderStyle.None
        OpenCloseText.Cursor = Cursors.IBeam
        OpenCloseText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        OpenCloseText.ForeColor = SystemColors.WindowText
        OpenCloseText.Location = New Point(144, 178)
        OpenCloseText.MaxLength = 0
        OpenCloseText.Name = "OpenCloseText"
        OpenCloseText.RightToLeft = RightToLeft.No
        OpenCloseText.Size = New Size(85, 13)
        OpenCloseText.TabIndex = 15
        ' 
        ' AccountText
        ' 
        AccountText.AcceptsReturn = True
        AccountText.BackColor = SystemColors.Window
        AccountText.BorderStyle = BorderStyle.None
        AccountText.Cursor = Cursors.IBeam
        AccountText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        AccountText.ForeColor = SystemColors.WindowText
        AccountText.Location = New Point(144, 82)
        AccountText.MaxLength = 0
        AccountText.Name = "AccountText"
        AccountText.RightToLeft = RightToLeft.No
        AccountText.Size = New Size(85, 13)
        AccountText.TabIndex = 7
        ' 
        ' OCAText
        ' 
        OCAText.AcceptsReturn = True
        OCAText.BackColor = SystemColors.Window
        OCAText.BorderStyle = BorderStyle.None
        OCAText.Cursor = Cursors.IBeam
        OCAText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        OCAText.ForeColor = SystemColors.WindowText
        OCAText.Location = New Point(144, 34)
        OCAText.MaxLength = 0
        OCAText.Name = "OCAText"
        OCAText.RightToLeft = RightToLeft.No
        OCAText.Size = New Size(85, 13)
        OCAText.TabIndex = 3
        ' 
        ' Label35
        ' 
        Label35.BackColor = Color.Gainsboro
        Label35.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label35.ForeColor = SystemColors.ControlText
        Label35.Location = New Point(16, 396)
        Label35.Name = "Label35"
        Label35.RightToLeft = RightToLeft.No
        Label35.Size = New Size(73, 17)
        Label35.TabIndex = 32
        Label35.Text = "Rule 80 A"
        ' 
        ' Label34
        ' 
        Label34.BackColor = Color.Gainsboro
        Label34.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label34.ForeColor = SystemColors.ControlText
        Label34.Location = New Point(16, 108)
        Label34.Name = "Label34"
        Label34.RightToLeft = RightToLeft.No
        Label34.Size = New Size(73, 17)
        Label34.TabIndex = 8
        Label34.Text = "Settling Firm"
        ' 
        ' Label33
        ' 
        Label33.BackColor = Color.Gainsboro
        Label33.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label33.ForeColor = SystemColors.ControlText
        Label33.Location = New Point(265, 83)
        Label33.Name = "Label33"
        Label33.RightToLeft = RightToLeft.No
        Label33.Size = New Size(121, 17)
        Label33.TabIndex = 50
        Label33.Text = "Minimum Quantity"
        ' 
        ' Label32
        ' 
        Label32.BackColor = Color.Gainsboro
        Label32.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label32.ForeColor = SystemColors.ControlText
        Label32.Location = New Point(265, 108)
        Label32.Name = "Label32"
        Label32.RightToLeft = RightToLeft.No
        Label32.Size = New Size(105, 17)
        Label32.TabIndex = 52
        Label32.Text = "Percent Offset"
        ' 
        ' Label28
        ' 
        Label28.BackColor = Color.Gainsboro
        Label28.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label28.ForeColor = SystemColors.ControlText
        Label28.Location = New Point(265, 372)
        Label28.Name = "Label28"
        Label28.RightToLeft = RightToLeft.No
        Label28.Size = New Size(120, 17)
        Label28.TabIndex = 74
        Label28.Text = "BOX: Auction Strategy"
        ' 
        ' Label27
        ' 
        Label27.BackColor = Color.Gainsboro
        Label27.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label27.ForeColor = SystemColors.ControlText
        Label27.Location = New Point(265, 397)
        Label27.Name = "Label27"
        Label27.RightToLeft = RightToLeft.No
        Label27.Size = New Size(113, 17)
        Label27.TabIndex = 76
        Label27.Text = "BOX: Starting Price"
        ' 
        ' Label26
        ' 
        Label26.BackColor = Color.Gainsboro
        Label26.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label26.ForeColor = SystemColors.ControlText
        Label26.Location = New Point(265, 420)
        Label26.Name = "Label26"
        Label26.RightToLeft = RightToLeft.No
        Label26.Size = New Size(113, 17)
        Label26.TabIndex = 78
        Label26.Text = "BOX: Stock Ref Price"
        ' 
        ' Label25
        ' 
        Label25.BackColor = Color.Gainsboro
        Label25.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label25.ForeColor = SystemColors.ControlText
        Label25.Location = New Point(265, 445)
        Label25.Name = "Label25"
        Label25.RightToLeft = RightToLeft.No
        Label25.Size = New Size(73, 17)
        Label25.TabIndex = 80
        Label25.Text = "BOX: Delta"
        ' 
        ' Label24
        ' 
        Label24.BackColor = Color.Gainsboro
        Label24.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label24.ForeColor = SystemColors.ControlText
        Label24.Location = New Point(265, 471)
        Label24.Name = "Label24"
        Label24.RightToLeft = RightToLeft.No
        Label24.Size = New Size(160, 17)
        Label24.TabIndex = 82
        Label24.Text = "BOX/VOL: Stock Range Lower"
        ' 
        ' Label23
        ' 
        Label23.BackColor = Color.Gainsboro
        Label23.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label23.ForeColor = SystemColors.ControlText
        Label23.Location = New Point(265, 497)
        Label23.Name = "Label23"
        Label23.RightToLeft = RightToLeft.No
        Label23.Size = New Size(160, 17)
        Label23.TabIndex = 84
        Label23.Text = "BOX/VOL: Stock Range Upper"
        ' 
        ' Label19
        ' 
        Label19.BackColor = Color.Gainsboro
        Label19.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label19.ForeColor = SystemColors.ControlText
        Label19.Location = New Point(16, 59)
        Label19.Name = "Label19"
        Label19.RightToLeft = RightToLeft.No
        Label19.Size = New Size(65, 17)
        Label19.TabIndex = 4
        Label19.Text = "OCA type"
        ' 
        ' Label17
        ' 
        Label17.BackColor = Color.Gainsboro
        Label17.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label17.ForeColor = SystemColors.ControlText
        Label17.Location = New Point(265, 348)
        Label17.Name = "Label17"
        Label17.RightToLeft = RightToLeft.No
        Label17.Size = New Size(152, 17)
        Label17.TabIndex = 72
        Label17.Text = "Short Sales Slot"
        ' 
        ' Label16
        ' 
        Label16.BackColor = Color.Gainsboro
        Label16.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label16.ForeColor = SystemColors.ControlText
        Label16.Location = New Point(16, 348)
        Label16.Name = "Label16"
        Label16.RightToLeft = RightToLeft.No
        Label16.Size = New Size(113, 17)
        Label16.TabIndex = 28
        Label16.Text = "Designated Location"
        ' 
        ' Label15
        ' 
        Label15.BackColor = Color.Gainsboro
        Label15.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label15.ForeColor = SystemColors.ControlText
        Label15.Location = New Point(265, 324)
        Label15.Name = "Label15"
        Label15.RightToLeft = RightToLeft.No
        Label15.Size = New Size(152, 17)
        Label15.TabIndex = 70
        Label15.Text = "Discretionary Amt"
        ' 
        ' Label14
        ' 
        Label14.BackColor = Color.Gainsboro
        Label14.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.ForeColor = SystemColors.ControlText
        Label14.Location = New Point(265, 300)
        Label14.Name = "Label14"
        Label14.RightToLeft = RightToLeft.No
        Label14.Size = New Size(65, 17)
        Label14.TabIndex = 68
        Label14.Text = "Hidden"
        ' 
        ' Label12
        ' 
        Label12.BackColor = Color.Gainsboro
        Label12.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.ForeColor = SystemColors.ControlText
        Label12.Location = New Point(265, 252)
        Label12.Name = "Label12"
        Label12.RightToLeft = RightToLeft.No
        Label12.Size = New Size(88, 17)
        Label12.TabIndex = 64
        Label12.Text = "Trigger Method"
        ' 
        ' Label11
        ' 
        Label11.BackColor = Color.Gainsboro
        Label11.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = SystemColors.ControlText
        Label11.Location = New Point(265, 228)
        Label11.Name = "Label11"
        Label11.RightToLeft = RightToLeft.No
        Label11.Size = New Size(81, 17)
        Label11.TabIndex = 62
        Label11.Text = "Display Size"
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.Gainsboro
        Label7.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = SystemColors.ControlText
        Label7.Location = New Point(16, 252)
        Label7.Name = "Label7"
        Label7.RightToLeft = RightToLeft.No
        Label7.Size = New Size(65, 17)
        Label7.TabIndex = 20
        Label7.Text = "Parent Id"
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.Gainsboro
        Label6.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = SystemColors.ControlText
        Label6.Location = New Point(16, 228)
        Label6.Name = "Label6"
        Label6.RightToLeft = RightToLeft.No
        Label6.Size = New Size(65, 17)
        Label6.TabIndex = 18
        Label6.Text = "Order Ref"
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Gainsboro
        Label5.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = SystemColors.ControlText
        Label5.Location = New Point(16, 204)
        Label5.Name = "Label5"
        Label5.RightToLeft = RightToLeft.No
        Label5.Size = New Size(65, 17)
        Label5.TabIndex = 16
        Label5.Text = "Origin"
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Gainsboro
        Label4.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = SystemColors.ControlText
        Label4.Location = New Point(16, 180)
        Label4.Name = "Label4"
        Label4.RightToLeft = RightToLeft.No
        Label4.Size = New Size(65, 17)
        Label4.TabIndex = 14
        Label4.Text = "Open/Close"
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Gainsboro
        Label3.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = SystemColors.ControlText
        Label3.Location = New Point(16, 84)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.No
        Label3.Size = New Size(65, 17)
        Label3.TabIndex = 6
        Label3.Text = "Account"
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Gainsboro
        Label2.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = SystemColors.ControlText
        Label2.Location = New Point(16, 35)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.No
        Label2.Size = New Size(65, 17)
        Label2.TabIndex = 2
        Label2.Text = "OCA group"
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Gainsboro
        Label1.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ControlText
        Label1.Location = New Point(16, 11)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.No
        Label1.Size = New Size(88, 17)
        Label1.TabIndex = 0
        Label1.Text = "Time in Force"
        ' 
        ' VolatilityText
        ' 
        VolatilityText.AcceptsReturn = True
        VolatilityText.BackColor = SystemColors.Window
        VolatilityText.BorderStyle = BorderStyle.None
        VolatilityText.Cursor = Cursors.IBeam
        VolatilityText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        VolatilityText.ForeColor = SystemColors.WindowText
        VolatilityText.Location = New Point(753, 10)
        VolatilityText.MaxLength = 0
        VolatilityText.Name = "VolatilityText"
        VolatilityText.RightToLeft = RightToLeft.No
        VolatilityText.Size = New Size(85, 13)
        VolatilityText.TabIndex = 93
        ' 
        ' VolatilityTypeText
        ' 
        VolatilityTypeText.AcceptsReturn = True
        VolatilityTypeText.BackColor = SystemColors.Window
        VolatilityTypeText.BorderStyle = BorderStyle.None
        VolatilityTypeText.Cursor = Cursors.IBeam
        VolatilityTypeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        VolatilityTypeText.ForeColor = SystemColors.WindowText
        VolatilityTypeText.Location = New Point(753, 34)
        VolatilityTypeText.MaxLength = 0
        VolatilityTypeText.Name = "VolatilityTypeText"
        VolatilityTypeText.RightToLeft = RightToLeft.No
        VolatilityTypeText.Size = New Size(85, 13)
        VolatilityTypeText.TabIndex = 95
        ' 
        ' DeltaNeutralOrderTypeText
        ' 
        DeltaNeutralOrderTypeText.AcceptsReturn = True
        DeltaNeutralOrderTypeText.BackColor = SystemColors.Window
        DeltaNeutralOrderTypeText.BorderStyle = BorderStyle.None
        DeltaNeutralOrderTypeText.Cursor = Cursors.IBeam
        DeltaNeutralOrderTypeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralOrderTypeText.ForeColor = SystemColors.WindowText
        DeltaNeutralOrderTypeText.Location = New Point(753, 58)
        DeltaNeutralOrderTypeText.MaxLength = 0
        DeltaNeutralOrderTypeText.Name = "DeltaNeutralOrderTypeText"
        DeltaNeutralOrderTypeText.RightToLeft = RightToLeft.No
        DeltaNeutralOrderTypeText.Size = New Size(85, 13)
        DeltaNeutralOrderTypeText.TabIndex = 97
        ' 
        ' ReferencePriceTypeText
        ' 
        ReferencePriceTypeText.AcceptsReturn = True
        ReferencePriceTypeText.BackColor = SystemColors.Window
        ReferencePriceTypeText.BorderStyle = BorderStyle.None
        ReferencePriceTypeText.Cursor = Cursors.IBeam
        ReferencePriceTypeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ReferencePriceTypeText.ForeColor = SystemColors.WindowText
        ReferencePriceTypeText.Location = New Point(753, 322)
        ReferencePriceTypeText.MaxLength = 0
        ReferencePriceTypeText.Name = "ReferencePriceTypeText"
        ReferencePriceTypeText.RightToLeft = RightToLeft.No
        ReferencePriceTypeText.Size = New Size(85, 13)
        ReferencePriceTypeText.TabIndex = 118
        ' 
        ' Label21
        ' 
        Label21.BackColor = Color.Gainsboro
        Label21.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label21.ForeColor = SystemColors.ControlText
        Label21.Location = New Point(550, 11)
        Label21.Name = "Label21"
        Label21.RightToLeft = RightToLeft.No
        Label21.Size = New Size(105, 17)
        Label21.TabIndex = 92
        Label21.Text = "VOL: Volatility"
        ' 
        ' Label22
        ' 
        Label22.BackColor = Color.Gainsboro
        Label22.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label22.ForeColor = SystemColors.ControlText
        Label22.Location = New Point(550, 35)
        Label22.Name = "Label22"
        Label22.RightToLeft = RightToLeft.No
        Label22.Size = New Size(144, 17)
        Label22.TabIndex = 94
        Label22.Text = "VOL: Volatility Type (1 or 2)"
        ' 
        ' Label36
        ' 
        Label36.BackColor = Color.Gainsboro
        Label36.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label36.ForeColor = SystemColors.ControlText
        Label36.Location = New Point(550, 59)
        Label36.Name = "Label36"
        Label36.RightToLeft = RightToLeft.No
        Label36.Size = New Size(152, 17)
        Label36.TabIndex = 96
        Label36.Text = "VOL: Hedge Delta Order Type"
        ' 
        ' Label40
        ' 
        Label40.BackColor = Color.Gainsboro
        Label40.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label40.ForeColor = SystemColors.ControlText
        Label40.Location = New Point(550, 324)
        Label40.Name = "Label40"
        Label40.RightToLeft = RightToLeft.No
        Label40.Size = New Size(181, 17)
        Label40.TabIndex = 117
        Label40.Text = "VOL: Reference Price Type (1 or 2)"
        ' 
        ' DeltaNeutralAuxPriceText
        ' 
        DeltaNeutralAuxPriceText.AcceptsReturn = True
        DeltaNeutralAuxPriceText.BackColor = SystemColors.Window
        DeltaNeutralAuxPriceText.BorderStyle = BorderStyle.None
        DeltaNeutralAuxPriceText.Cursor = Cursors.IBeam
        DeltaNeutralAuxPriceText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralAuxPriceText.ForeColor = SystemColors.WindowText
        DeltaNeutralAuxPriceText.Location = New Point(753, 82)
        DeltaNeutralAuxPriceText.MaxLength = 0
        DeltaNeutralAuxPriceText.Name = "DeltaNeutralAuxPriceText"
        DeltaNeutralAuxPriceText.RightToLeft = RightToLeft.No
        DeltaNeutralAuxPriceText.Size = New Size(85, 13)
        DeltaNeutralAuxPriceText.TabIndex = 99
        ' 
        ' Label38
        ' 
        Label38.BackColor = Color.Gainsboro
        Label38.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label38.ForeColor = SystemColors.ControlText
        Label38.Location = New Point(550, 84)
        Label38.Name = "Label38"
        Label38.RightToLeft = RightToLeft.No
        Label38.Size = New Size(152, 17)
        Label38.TabIndex = 98
        Label38.Text = "VOL: Hedge Delta Aux Price"
        ' 
        ' TrailStopPriceText
        ' 
        TrailStopPriceText.AcceptsReturn = True
        TrailStopPriceText.BackColor = SystemColors.Window
        TrailStopPriceText.BorderStyle = BorderStyle.None
        TrailStopPriceText.Cursor = Cursors.IBeam
        TrailStopPriceText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        TrailStopPriceText.ForeColor = SystemColors.WindowText
        TrailStopPriceText.Location = New Point(432, 10)
        TrailStopPriceText.MaxLength = 0
        TrailStopPriceText.Name = "TrailStopPriceText"
        TrailStopPriceText.RightToLeft = RightToLeft.No
        TrailStopPriceText.Size = New Size(85, 13)
        TrailStopPriceText.TabIndex = 45
        ' 
        ' Label39
        ' 
        Label39.BackColor = Color.Gainsboro
        Label39.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label39.ForeColor = SystemColors.ControlText
        Label39.Location = New Point(264, 11)
        Label39.Name = "Label39"
        Label39.RightToLeft = RightToLeft.No
        Label39.Size = New Size(96, 17)
        Label39.TabIndex = 44
        Label39.Text = "Trail Stop Price"
        ' 
        ' ScaleInitLevelSizeText
        ' 
        ScaleInitLevelSizeText.AcceptsReturn = True
        ScaleInitLevelSizeText.BackColor = SystemColors.Window
        ScaleInitLevelSizeText.BorderStyle = BorderStyle.None
        ScaleInitLevelSizeText.Cursor = Cursors.IBeam
        ScaleInitLevelSizeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScaleInitLevelSizeText.ForeColor = SystemColors.WindowText
        ScaleInitLevelSizeText.Location = New Point(753, 346)
        ScaleInitLevelSizeText.MaxLength = 0
        ScaleInitLevelSizeText.Name = "ScaleInitLevelSizeText"
        ScaleInitLevelSizeText.RightToLeft = RightToLeft.No
        ScaleInitLevelSizeText.Size = New Size(85, 13)
        ScaleInitLevelSizeText.TabIndex = 120
        ' 
        ' ScaleSubsLevelSizeText
        ' 
        ScaleSubsLevelSizeText.AcceptsReturn = True
        ScaleSubsLevelSizeText.BackColor = SystemColors.Window
        ScaleSubsLevelSizeText.BorderStyle = BorderStyle.None
        ScaleSubsLevelSizeText.Cursor = Cursors.IBeam
        ScaleSubsLevelSizeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScaleSubsLevelSizeText.ForeColor = SystemColors.WindowText
        ScaleSubsLevelSizeText.Location = New Point(753, 370)
        ScaleSubsLevelSizeText.MaxLength = 0
        ScaleSubsLevelSizeText.Name = "ScaleSubsLevelSizeText"
        ScaleSubsLevelSizeText.RightToLeft = RightToLeft.No
        ScaleSubsLevelSizeText.Size = New Size(85, 13)
        ScaleSubsLevelSizeText.TabIndex = 122
        ' 
        ' ScalePriceIncrText
        ' 
        ScalePriceIncrText.AcceptsReturn = True
        ScalePriceIncrText.BackColor = SystemColors.Window
        ScalePriceIncrText.BorderStyle = BorderStyle.None
        ScalePriceIncrText.Cursor = Cursors.IBeam
        ScalePriceIncrText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScalePriceIncrText.ForeColor = SystemColors.WindowText
        ScalePriceIncrText.Location = New Point(753, 394)
        ScalePriceIncrText.MaxLength = 0
        ScalePriceIncrText.Name = "ScalePriceIncrText"
        ScalePriceIncrText.RightToLeft = RightToLeft.No
        ScalePriceIncrText.Size = New Size(85, 13)
        ScalePriceIncrText.TabIndex = 124
        ' 
        ' Label42
        ' 
        Label42.BackColor = Color.Gainsboro
        Label42.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label42.ForeColor = SystemColors.ControlText
        Label42.Location = New Point(550, 348)
        Label42.Name = "Label42"
        Label42.RightToLeft = RightToLeft.No
        Label42.Size = New Size(128, 17)
        Label42.TabIndex = 119
        Label42.Text = "SCALE: Init Level Size"
        ' 
        ' Label43
        ' 
        Label43.BackColor = Color.Gainsboro
        Label43.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label43.ForeColor = SystemColors.ControlText
        Label43.Location = New Point(550, 372)
        Label43.Name = "Label43"
        Label43.RightToLeft = RightToLeft.No
        Label43.Size = New Size(128, 17)
        Label43.TabIndex = 121
        Label43.Text = "SCALE: Subs Level Size"
        ' 
        ' Label44
        ' 
        Label44.BackColor = Color.Gainsboro
        Label44.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label44.ForeColor = SystemColors.ControlText
        Label44.Location = New Point(550, 396)
        Label44.Name = "Label44"
        Label44.RightToLeft = RightToLeft.No
        Label44.Size = New Size(128, 17)
        Label44.TabIndex = 123
        Label44.Text = "SCALE: Price Increment"
        ' 
        ' ClearingAccountText
        ' 
        ClearingAccountText.AcceptsReturn = True
        ClearingAccountText.BackColor = SystemColors.Window
        ClearingAccountText.BorderStyle = BorderStyle.None
        ClearingAccountText.Cursor = Cursors.IBeam
        ClearingAccountText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ClearingAccountText.ForeColor = SystemColors.WindowText
        ClearingAccountText.Location = New Point(144, 130)
        ClearingAccountText.MaxLength = 0
        ClearingAccountText.Name = "ClearingAccountText"
        ClearingAccountText.RightToLeft = RightToLeft.No
        ClearingAccountText.Size = New Size(85, 13)
        ClearingAccountText.TabIndex = 11
        ' 
        ' Label18
        ' 
        Label18.BackColor = Color.Gainsboro
        Label18.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.ForeColor = SystemColors.ControlText
        Label18.Location = New Point(17, 132)
        Label18.Name = "Label18"
        Label18.RightToLeft = RightToLeft.No
        Label18.Size = New Size(96, 17)
        Label18.TabIndex = 10
        Label18.Text = "Clearing Account"
        ' 
        ' ClearingIntentText
        ' 
        ClearingIntentText.AcceptsReturn = True
        ClearingIntentText.BackColor = SystemColors.Window
        ClearingIntentText.BorderStyle = BorderStyle.None
        ClearingIntentText.Cursor = Cursors.IBeam
        ClearingIntentText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ClearingIntentText.ForeColor = SystemColors.WindowText
        ClearingIntentText.Location = New Point(144, 154)
        ClearingIntentText.MaxLength = 0
        ClearingIntentText.Name = "ClearingIntentText"
        ClearingIntentText.RightToLeft = RightToLeft.No
        ClearingIntentText.Size = New Size(85, 13)
        ClearingIntentText.TabIndex = 13
        ' 
        ' Label45
        ' 
        Label45.BackColor = Color.Gainsboro
        Label45.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label45.ForeColor = SystemColors.ControlText
        Label45.Location = New Point(17, 156)
        Label45.Name = "Label45"
        Label45.RightToLeft = RightToLeft.No
        Label45.Size = New Size(96, 17)
        Label45.TabIndex = 12
        Label45.Text = "Clearing Intent"
        ' 
        ' ExemptCodeText
        ' 
        ExemptCodeText.BorderStyle = BorderStyle.None
        ExemptCodeText.Location = New Point(144, 370)
        ExemptCodeText.Name = "ExemptCodeText"
        ExemptCodeText.Size = New Size(84, 13)
        ExemptCodeText.TabIndex = 31
        ExemptCodeText.Text = "-1"
        ' 
        ' Label46
        ' 
        Label46.AutoSize = True
        Label46.Location = New Point(16, 373)
        Label46.Name = "Label46"
        Label46.Size = New Size(70, 14)
        Label46.TabIndex = 30
        Label46.Text = "Exempt Code"
        ' 
        ' HedgeTypeText
        ' 
        HedgeTypeText.AcceptsReturn = True
        HedgeTypeText.BackColor = SystemColors.Window
        HedgeTypeText.BorderStyle = BorderStyle.None
        HedgeTypeText.Cursor = Cursors.IBeam
        HedgeTypeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        HedgeTypeText.ForeColor = SystemColors.WindowText
        HedgeTypeText.Location = New Point(143, 418)
        HedgeTypeText.MaxLength = 0
        HedgeTypeText.Name = "HedgeTypeText"
        HedgeTypeText.RightToLeft = RightToLeft.No
        HedgeTypeText.Size = New Size(85, 13)
        HedgeTypeText.TabIndex = 35
        ' 
        ' LabelHedgeType
        ' 
        LabelHedgeType.BackColor = Color.Gainsboro
        LabelHedgeType.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        LabelHedgeType.ForeColor = SystemColors.ControlText
        LabelHedgeType.Location = New Point(16, 421)
        LabelHedgeType.Name = "LabelHedgeType"
        LabelHedgeType.RightToLeft = RightToLeft.No
        LabelHedgeType.Size = New Size(73, 17)
        LabelHedgeType.TabIndex = 34
        LabelHedgeType.Text = "Hedge: type"
        ' 
        ' LabelHedgeParam
        ' 
        LabelHedgeParam.BackColor = Color.Gainsboro
        LabelHedgeParam.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        LabelHedgeParam.ForeColor = SystemColors.ControlText
        LabelHedgeParam.Location = New Point(16, 447)
        LabelHedgeParam.Name = "LabelHedgeParam"
        LabelHedgeParam.RightToLeft = RightToLeft.No
        LabelHedgeParam.Size = New Size(85, 17)
        LabelHedgeParam.TabIndex = 36
        LabelHedgeParam.Text = "Hedge: param"
        ' 
        ' OptOutSmartRoutingCheck
        ' 
        OptOutSmartRoutingCheck.AutoSize = True
        OptOutSmartRoutingCheck.Location = New Point(16, 471)
        OptOutSmartRoutingCheck.Name = "OptOutSmartRoutingCheck"
        OptOutSmartRoutingCheck.Size = New Size(166, 18)
        OptOutSmartRoutingCheck.TabIndex = 38
        OptOutSmartRoutingCheck.Text = "Opting out of SMART Routing"
        OptOutSmartRoutingCheck.UseVisualStyleBackColor = True
        ' 
        ' Label47
        ' 
        Label47.BackColor = Color.Gainsboro
        Label47.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label47.ForeColor = SystemColors.ControlText
        Label47.Location = New Point(550, 108)
        Label47.Name = "Label47"
        Label47.RightToLeft = RightToLeft.No
        Label47.Size = New Size(152, 17)
        Label47.TabIndex = 100
        Label47.Text = "VOL: Hedge Delta Con Id"
        ' 
        ' Label48
        ' 
        Label48.BackColor = Color.Gainsboro
        Label48.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label48.ForeColor = SystemColors.ControlText
        Label48.Location = New Point(550, 132)
        Label48.Name = "Label48"
        Label48.RightToLeft = RightToLeft.No
        Label48.Size = New Size(181, 17)
        Label48.TabIndex = 102
        Label48.Text = "VOL: Hedge Delta Settling Firm"
        ' 
        ' Label49
        ' 
        Label49.BackColor = Color.Gainsboro
        Label49.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label49.ForeColor = SystemColors.ControlText
        Label49.Location = New Point(550, 156)
        Label49.Name = "Label49"
        Label49.RightToLeft = RightToLeft.No
        Label49.Size = New Size(188, 17)
        Label49.TabIndex = 104
        Label49.Text = "VOL: Hedge Delta Clearing Account"
        ' 
        ' Label50
        ' 
        Label50.BackColor = Color.Gainsboro
        Label50.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label50.ForeColor = SystemColors.ControlText
        Label50.Location = New Point(550, 180)
        Label50.Name = "Label50"
        Label50.RightToLeft = RightToLeft.No
        Label50.Size = New Size(181, 17)
        Label50.TabIndex = 106
        Label50.Text = "VOL: Hedge Delta Clearing Intent"
        ' 
        ' DeltaNeutralConIdText
        ' 
        DeltaNeutralConIdText.AcceptsReturn = True
        DeltaNeutralConIdText.BackColor = SystemColors.Window
        DeltaNeutralConIdText.BorderStyle = BorderStyle.None
        DeltaNeutralConIdText.Cursor = Cursors.IBeam
        DeltaNeutralConIdText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralConIdText.ForeColor = SystemColors.WindowText
        DeltaNeutralConIdText.Location = New Point(753, 106)
        DeltaNeutralConIdText.MaxLength = 0
        DeltaNeutralConIdText.Name = "DeltaNeutralConIdText"
        DeltaNeutralConIdText.RightToLeft = RightToLeft.No
        DeltaNeutralConIdText.Size = New Size(85, 13)
        DeltaNeutralConIdText.TabIndex = 101
        ' 
        ' DeltaNeutralClearingIntentText
        ' 
        DeltaNeutralClearingIntentText.AcceptsReturn = True
        DeltaNeutralClearingIntentText.BackColor = SystemColors.Window
        DeltaNeutralClearingIntentText.BorderStyle = BorderStyle.None
        DeltaNeutralClearingIntentText.Cursor = Cursors.IBeam
        DeltaNeutralClearingIntentText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralClearingIntentText.ForeColor = SystemColors.WindowText
        DeltaNeutralClearingIntentText.Location = New Point(753, 178)
        DeltaNeutralClearingIntentText.MaxLength = 0
        DeltaNeutralClearingIntentText.Name = "DeltaNeutralClearingIntentText"
        DeltaNeutralClearingIntentText.RightToLeft = RightToLeft.No
        DeltaNeutralClearingIntentText.Size = New Size(85, 13)
        DeltaNeutralClearingIntentText.TabIndex = 107
        ' 
        ' DeltaNeutralClearingAccountText
        ' 
        DeltaNeutralClearingAccountText.AcceptsReturn = True
        DeltaNeutralClearingAccountText.BackColor = SystemColors.Window
        DeltaNeutralClearingAccountText.BorderStyle = BorderStyle.None
        DeltaNeutralClearingAccountText.Cursor = Cursors.IBeam
        DeltaNeutralClearingAccountText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralClearingAccountText.ForeColor = SystemColors.WindowText
        DeltaNeutralClearingAccountText.Location = New Point(753, 154)
        DeltaNeutralClearingAccountText.MaxLength = 0
        DeltaNeutralClearingAccountText.Name = "DeltaNeutralClearingAccountText"
        DeltaNeutralClearingAccountText.RightToLeft = RightToLeft.No
        DeltaNeutralClearingAccountText.Size = New Size(85, 13)
        DeltaNeutralClearingAccountText.TabIndex = 105
        ' 
        ' DeltaNeutralSettlingFirmText
        ' 
        DeltaNeutralSettlingFirmText.AcceptsReturn = True
        DeltaNeutralSettlingFirmText.BackColor = SystemColors.Window
        DeltaNeutralSettlingFirmText.BorderStyle = BorderStyle.None
        DeltaNeutralSettlingFirmText.Cursor = Cursors.IBeam
        DeltaNeutralSettlingFirmText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralSettlingFirmText.ForeColor = SystemColors.WindowText
        DeltaNeutralSettlingFirmText.Location = New Point(753, 130)
        DeltaNeutralSettlingFirmText.MaxLength = 0
        DeltaNeutralSettlingFirmText.Name = "DeltaNeutralSettlingFirmText"
        DeltaNeutralSettlingFirmText.RightToLeft = RightToLeft.No
        DeltaNeutralSettlingFirmText.Size = New Size(85, 13)
        DeltaNeutralSettlingFirmText.TabIndex = 103
        ' 
        ' Label51
        ' 
        Label51.BackColor = Color.Gainsboro
        Label51.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label51.ForeColor = SystemColors.ControlText
        Label51.Location = New Point(550, 420)
        Label51.Name = "Label51"
        Label51.RightToLeft = RightToLeft.No
        Label51.Size = New Size(181, 17)
        Label51.TabIndex = 125
        Label51.Text = "SCALE: Price Adjust Value"
        ' 
        ' Label52
        ' 
        Label52.BackColor = Color.Gainsboro
        Label52.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label52.ForeColor = SystemColors.ControlText
        Label52.Location = New Point(550, 444)
        Label52.Name = "Label52"
        Label52.RightToLeft = RightToLeft.No
        Label52.Size = New Size(181, 17)
        Label52.TabIndex = 127
        Label52.Text = "SCALE: Price Adjust Interval"
        ' 
        ' Label53
        ' 
        Label53.BackColor = Color.Gainsboro
        Label53.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label53.ForeColor = SystemColors.ControlText
        Label53.Location = New Point(550, 469)
        Label53.Name = "Label53"
        Label53.RightToLeft = RightToLeft.No
        Label53.Size = New Size(181, 17)
        Label53.TabIndex = 129
        Label53.Text = "SCALE: Profit Offset"
        ' 
        ' ScaleAutoResetCheck
        ' 
        ScaleAutoResetCheck.AutoSize = True
        ScaleAutoResetCheck.Location = New Point(550, 490)
        ScaleAutoResetCheck.Name = "ScaleAutoResetCheck"
        ScaleAutoResetCheck.Size = New Size(119, 18)
        ScaleAutoResetCheck.TabIndex = 131
        ScaleAutoResetCheck.Text = "SCALE: Auto Reset"
        ScaleAutoResetCheck.UseVisualStyleBackColor = True
        ' 
        ' ScalePriceAdjustValueText
        ' 
        ScalePriceAdjustValueText.AcceptsReturn = True
        ScalePriceAdjustValueText.BackColor = SystemColors.Window
        ScalePriceAdjustValueText.BorderStyle = BorderStyle.None
        ScalePriceAdjustValueText.Cursor = Cursors.IBeam
        ScalePriceAdjustValueText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScalePriceAdjustValueText.ForeColor = SystemColors.WindowText
        ScalePriceAdjustValueText.Location = New Point(753, 418)
        ScalePriceAdjustValueText.MaxLength = 0
        ScalePriceAdjustValueText.Name = "ScalePriceAdjustValueText"
        ScalePriceAdjustValueText.RightToLeft = RightToLeft.No
        ScalePriceAdjustValueText.Size = New Size(85, 13)
        ScalePriceAdjustValueText.TabIndex = 126
        ' 
        ' Label54
        ' 
        Label54.BackColor = Color.Gainsboro
        Label54.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label54.ForeColor = SystemColors.ControlText
        Label54.Location = New Point(550, 517)
        Label54.Name = "Label54"
        Label54.RightToLeft = RightToLeft.No
        Label54.Size = New Size(181, 17)
        Label54.TabIndex = 132
        Label54.Text = "SCALE: Init Position"
        ' 
        ' Label55
        ' 
        Label55.BackColor = Color.Gainsboro
        Label55.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label55.ForeColor = SystemColors.ControlText
        Label55.Location = New Point(550, 543)
        Label55.Name = "Label55"
        Label55.RightToLeft = RightToLeft.No
        Label55.Size = New Size(181, 17)
        Label55.TabIndex = 134
        Label55.Text = "SCALE: Init Fill Qty"
        ' 
        ' ScaleRandomPercentCheck
        ' 
        ScaleRandomPercentCheck.AutoSize = True
        ScaleRandomPercentCheck.Location = New Point(550, 567)
        ScaleRandomPercentCheck.Name = "ScaleRandomPercentCheck"
        ScaleRandomPercentCheck.Size = New Size(145, 18)
        ScaleRandomPercentCheck.TabIndex = 136
        ScaleRandomPercentCheck.Text = "SCALE: Random Percent"
        ScaleRandomPercentCheck.UseVisualStyleBackColor = True
        ' 
        ' ScalePriceAdjustIntervalText
        ' 
        ScalePriceAdjustIntervalText.AcceptsReturn = True
        ScalePriceAdjustIntervalText.BackColor = SystemColors.Window
        ScalePriceAdjustIntervalText.BorderStyle = BorderStyle.None
        ScalePriceAdjustIntervalText.Cursor = Cursors.IBeam
        ScalePriceAdjustIntervalText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScalePriceAdjustIntervalText.ForeColor = SystemColors.WindowText
        ScalePriceAdjustIntervalText.Location = New Point(753, 442)
        ScalePriceAdjustIntervalText.MaxLength = 0
        ScalePriceAdjustIntervalText.Name = "ScalePriceAdjustIntervalText"
        ScalePriceAdjustIntervalText.RightToLeft = RightToLeft.No
        ScalePriceAdjustIntervalText.Size = New Size(85, 13)
        ScalePriceAdjustIntervalText.TabIndex = 128
        ' 
        ' ScaleInitPositionText
        ' 
        ScaleInitPositionText.AcceptsReturn = True
        ScaleInitPositionText.BackColor = SystemColors.Window
        ScaleInitPositionText.BorderStyle = BorderStyle.None
        ScaleInitPositionText.Cursor = Cursors.IBeam
        ScaleInitPositionText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScaleInitPositionText.ForeColor = SystemColors.WindowText
        ScaleInitPositionText.Location = New Point(753, 514)
        ScaleInitPositionText.MaxLength = 0
        ScaleInitPositionText.Name = "ScaleInitPositionText"
        ScaleInitPositionText.RightToLeft = RightToLeft.No
        ScaleInitPositionText.Size = New Size(85, 13)
        ScaleInitPositionText.TabIndex = 133
        ' 
        ' ScaleInitFillQtyText
        ' 
        ScaleInitFillQtyText.AcceptsReturn = True
        ScaleInitFillQtyText.BackColor = SystemColors.Window
        ScaleInitFillQtyText.BorderStyle = BorderStyle.None
        ScaleInitFillQtyText.Cursor = Cursors.IBeam
        ScaleInitFillQtyText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScaleInitFillQtyText.ForeColor = SystemColors.WindowText
        ScaleInitFillQtyText.Location = New Point(753, 540)
        ScaleInitFillQtyText.MaxLength = 0
        ScaleInitFillQtyText.Name = "ScaleInitFillQtyText"
        ScaleInitFillQtyText.RightToLeft = RightToLeft.No
        ScaleInitFillQtyText.Size = New Size(85, 13)
        ScaleInitFillQtyText.TabIndex = 135
        ' 
        ' ScaleProfitOffsetText
        ' 
        ScaleProfitOffsetText.AcceptsReturn = True
        ScaleProfitOffsetText.BackColor = SystemColors.Window
        ScaleProfitOffsetText.BorderStyle = BorderStyle.None
        ScaleProfitOffsetText.Cursor = Cursors.IBeam
        ScaleProfitOffsetText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScaleProfitOffsetText.ForeColor = SystemColors.WindowText
        ScaleProfitOffsetText.Location = New Point(753, 466)
        ScaleProfitOffsetText.MaxLength = 0
        ScaleProfitOffsetText.Name = "ScaleProfitOffsetText"
        ScaleProfitOffsetText.RightToLeft = RightToLeft.No
        ScaleProfitOffsetText.Size = New Size(85, 13)
        ScaleProfitOffsetText.TabIndex = 130
        ' 
        ' Label56
        ' 
        Label56.BackColor = Color.Gainsboro
        Label56.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label56.ForeColor = SystemColors.ControlText
        Label56.Location = New Point(264, 35)
        Label56.Name = "Label56"
        Label56.RightToLeft = RightToLeft.No
        Label56.Size = New Size(136, 17)
        Label56.TabIndex = 46
        Label56.Text = "Trailing Percent"
        ' 
        ' TrailingPercentText
        ' 
        TrailingPercentText.AcceptsReturn = True
        TrailingPercentText.BackColor = SystemColors.Window
        TrailingPercentText.BorderStyle = BorderStyle.None
        TrailingPercentText.Cursor = Cursors.IBeam
        TrailingPercentText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        TrailingPercentText.ForeColor = SystemColors.WindowText
        TrailingPercentText.Location = New Point(432, 34)
        TrailingPercentText.MaxLength = 0
        TrailingPercentText.Name = "TrailingPercentText"
        TrailingPercentText.RightToLeft = RightToLeft.No
        TrailingPercentText.Size = New Size(85, 13)
        TrailingPercentText.TabIndex = 47
        ' 
        ' DeltaNeutralOpenCloseText
        ' 
        DeltaNeutralOpenCloseText.AcceptsReturn = True
        DeltaNeutralOpenCloseText.BackColor = SystemColors.Window
        DeltaNeutralOpenCloseText.BorderStyle = BorderStyle.None
        DeltaNeutralOpenCloseText.Cursor = Cursors.IBeam
        DeltaNeutralOpenCloseText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralOpenCloseText.ForeColor = SystemColors.WindowText
        DeltaNeutralOpenCloseText.Location = New Point(753, 202)
        DeltaNeutralOpenCloseText.MaxLength = 0
        DeltaNeutralOpenCloseText.Name = "DeltaNeutralOpenCloseText"
        DeltaNeutralOpenCloseText.RightToLeft = RightToLeft.No
        DeltaNeutralOpenCloseText.Size = New Size(85, 13)
        DeltaNeutralOpenCloseText.TabIndex = 109
        ' 
        ' Label57
        ' 
        Label57.BackColor = Color.Gainsboro
        Label57.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label57.ForeColor = SystemColors.ControlText
        Label57.Location = New Point(550, 204)
        Label57.Name = "Label57"
        Label57.RightToLeft = RightToLeft.No
        Label57.Size = New Size(181, 17)
        Label57.TabIndex = 108
        Label57.Text = "VOL: Hedge Delta Open/Close"
        ' 
        ' DeltaNeutralShortSaleCheck
        ' 
        DeltaNeutralShortSaleCheck.AutoSize = True
        DeltaNeutralShortSaleCheck.Location = New Point(553, 228)
        DeltaNeutralShortSaleCheck.Name = "DeltaNeutralShortSaleCheck"
        DeltaNeutralShortSaleCheck.Size = New Size(165, 18)
        DeltaNeutralShortSaleCheck.TabIndex = 110
        DeltaNeutralShortSaleCheck.Text = "VOL: Hedge Delta Short Sale"
        DeltaNeutralShortSaleCheck.UseVisualStyleBackColor = True
        ' 
        ' DeltaNeutralShortSaleSlotText
        ' 
        DeltaNeutralShortSaleSlotText.AcceptsReturn = True
        DeltaNeutralShortSaleSlotText.BackColor = SystemColors.Window
        DeltaNeutralShortSaleSlotText.BorderStyle = BorderStyle.None
        DeltaNeutralShortSaleSlotText.Cursor = Cursors.IBeam
        DeltaNeutralShortSaleSlotText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralShortSaleSlotText.ForeColor = SystemColors.WindowText
        DeltaNeutralShortSaleSlotText.Location = New Point(753, 250)
        DeltaNeutralShortSaleSlotText.MaxLength = 0
        DeltaNeutralShortSaleSlotText.Name = "DeltaNeutralShortSaleSlotText"
        DeltaNeutralShortSaleSlotText.RightToLeft = RightToLeft.No
        DeltaNeutralShortSaleSlotText.Size = New Size(85, 13)
        DeltaNeutralShortSaleSlotText.TabIndex = 112
        DeltaNeutralShortSaleSlotText.Text = "0"
        ' 
        ' Label58
        ' 
        Label58.BackColor = Color.Gainsboro
        Label58.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label58.ForeColor = SystemColors.ControlText
        Label58.Location = New Point(550, 252)
        Label58.Name = "Label58"
        Label58.RightToLeft = RightToLeft.No
        Label58.Size = New Size(181, 17)
        Label58.TabIndex = 111
        Label58.Text = "VOL: Hedge Delta Short Sale Slot"
        ' 
        ' DeltaNeutralDesignatedLocationText
        ' 
        DeltaNeutralDesignatedLocationText.AcceptsReturn = True
        DeltaNeutralDesignatedLocationText.BackColor = SystemColors.Window
        DeltaNeutralDesignatedLocationText.BorderStyle = BorderStyle.None
        DeltaNeutralDesignatedLocationText.Cursor = Cursors.IBeam
        DeltaNeutralDesignatedLocationText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DeltaNeutralDesignatedLocationText.ForeColor = SystemColors.WindowText
        DeltaNeutralDesignatedLocationText.Location = New Point(753, 274)
        DeltaNeutralDesignatedLocationText.MaxLength = 0
        DeltaNeutralDesignatedLocationText.Name = "DeltaNeutralDesignatedLocationText"
        DeltaNeutralDesignatedLocationText.RightToLeft = RightToLeft.No
        DeltaNeutralDesignatedLocationText.Size = New Size(85, 13)
        DeltaNeutralDesignatedLocationText.TabIndex = 114
        ' 
        ' Label59
        ' 
        Label59.BackColor = Color.Gainsboro
        Label59.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label59.ForeColor = SystemColors.ControlText
        Label59.Location = New Point(550, 269)
        Label59.Name = "Label59"
        Label59.RightToLeft = RightToLeft.No
        Label59.Size = New Size(181, 31)
        Label59.TabIndex = 113
        Label59.Text = "VOL: Hedge Delta Designated Location"
        ' 
        ' ActiveStopTimeText
        ' 
        ActiveStopTimeText.AcceptsReturn = True
        ActiveStopTimeText.BackColor = SystemColors.Window
        ActiveStopTimeText.BorderStyle = BorderStyle.None
        ActiveStopTimeText.Cursor = Cursors.IBeam
        ActiveStopTimeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ActiveStopTimeText.ForeColor = SystemColors.WindowText
        ActiveStopTimeText.Location = New Point(433, 567)
        ActiveStopTimeText.MaxLength = 0
        ActiveStopTimeText.Name = "ActiveStopTimeText"
        ActiveStopTimeText.RightToLeft = RightToLeft.No
        ActiveStopTimeText.Size = New Size(85, 13)
        ActiveStopTimeText.TabIndex = 91
        ' 
        ' ActiveStartTimeText
        ' 
        ActiveStartTimeText.AcceptsReturn = True
        ActiveStartTimeText.BackColor = SystemColors.Window
        ActiveStartTimeText.BorderStyle = BorderStyle.None
        ActiveStartTimeText.Cursor = Cursors.IBeam
        ActiveStartTimeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ActiveStartTimeText.ForeColor = SystemColors.WindowText
        ActiveStartTimeText.Location = New Point(433, 543)
        ActiveStartTimeText.MaxLength = 0
        ActiveStartTimeText.Name = "ActiveStartTimeText"
        ActiveStartTimeText.RightToLeft = RightToLeft.No
        ActiveStartTimeText.Size = New Size(85, 13)
        ActiveStartTimeText.TabIndex = 89
        ' 
        ' ScaleTableText
        ' 
        ScaleTableText.AcceptsReturn = True
        ScaleTableText.BackColor = SystemColors.Window
        ScaleTableText.BorderStyle = BorderStyle.None
        ScaleTableText.Cursor = Cursors.IBeam
        ScaleTableText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ScaleTableText.ForeColor = SystemColors.WindowText
        ScaleTableText.Location = New Point(433, 519)
        ScaleTableText.MaxLength = 0
        ScaleTableText.Name = "ScaleTableText"
        ScaleTableText.RightToLeft = RightToLeft.No
        ScaleTableText.Size = New Size(85, 13)
        ScaleTableText.TabIndex = 87
        ' 
        ' Label60
        ' 
        Label60.BackColor = Color.Gainsboro
        Label60.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label60.ForeColor = SystemColors.ControlText
        Label60.Location = New Point(265, 570)
        Label60.Name = "Label60"
        Label60.RightToLeft = RightToLeft.No
        Label60.Size = New Size(160, 17)
        Label60.TabIndex = 90
        Label60.Text = "Active Stop Time"
        ' 
        ' Label61
        ' 
        Label61.BackColor = Color.Gainsboro
        Label61.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label61.ForeColor = SystemColors.ControlText
        Label61.Location = New Point(265, 545)
        Label61.Name = "Label61"
        Label61.RightToLeft = RightToLeft.No
        Label61.Size = New Size(160, 17)
        Label61.TabIndex = 88
        Label61.Text = "Active Start Time"
        ' 
        ' Label62
        ' 
        Label62.BackColor = Color.Gainsboro
        Label62.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label62.ForeColor = SystemColors.ControlText
        Label62.Location = New Point(265, 521)
        Label62.Name = "Label62"
        Label62.RightToLeft = RightToLeft.No
        Label62.Size = New Size(160, 17)
        Label62.TabIndex = 86
        Label62.Text = "SCALE: Scale Table"
        ' 
        ' SolicitedCheck
        ' 
        SolicitedCheck.AutoSize = True
        SolicitedCheck.Location = New Point(16, 497)
        SolicitedCheck.Name = "SolicitedCheck"
        SolicitedCheck.Size = New Size(66, 18)
        SolicitedCheck.TabIndex = 39
        SolicitedCheck.Text = "Solicited"
        SolicitedCheck.UseVisualStyleBackColor = True
        ' 
        ' RandomizeSizeCheck
        ' 
        RandomizeSizeCheck.AutoSize = True
        RandomizeSizeCheck.Location = New Point(16, 521)
        RandomizeSizeCheck.Name = "RandomizeSizeCheck"
        RandomizeSizeCheck.Size = New Size(103, 18)
        RandomizeSizeCheck.TabIndex = 40
        RandomizeSizeCheck.Text = "Randomize Size"
        RandomizeSizeCheck.UseVisualStyleBackColor = True
        ' 
        ' RandomizePriceCheck
        ' 
        RandomizePriceCheck.AutoSize = True
        RandomizePriceCheck.Location = New Point(16, 545)
        RandomizePriceCheck.Name = "RandomizePriceCheck"
        RandomizePriceCheck.Size = New Size(106, 18)
        RandomizePriceCheck.TabIndex = 41
        RandomizePriceCheck.Text = "Randomize Price"
        RandomizePriceCheck.UseVisualStyleBackColor = True
        ' 
        ' ModelCodeText
        ' 
        ModelCodeText.AcceptsReturn = True
        ModelCodeText.BackColor = SystemColors.Window
        ModelCodeText.BorderStyle = BorderStyle.None
        ModelCodeText.Cursor = Cursors.IBeam
        ModelCodeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ModelCodeText.ForeColor = SystemColors.WindowText
        ModelCodeText.Location = New Point(143, 567)
        ModelCodeText.MaxLength = 0
        ModelCodeText.Name = "ModelCodeText"
        ModelCodeText.RightToLeft = RightToLeft.No
        ModelCodeText.Size = New Size(85, 13)
        ModelCodeText.TabIndex = 43
        ' 
        ' Label63
        ' 
        Label63.BackColor = Color.Gainsboro
        Label63.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label63.ForeColor = SystemColors.ControlText
        Label63.Location = New Point(13, 570)
        Label63.Name = "Label63"
        Label63.RightToLeft = RightToLeft.No
        Label63.Size = New Size(65, 17)
        Label63.TabIndex = 42
        Label63.Text = "Model Code"
        ' 
        ' TransmitCheck
        ' 
        TransmitCheck.AutoSize = True
        TransmitCheck.Location = New Point(19, 273)
        TransmitCheck.Name = "TransmitCheck"
        TransmitCheck.Size = New Size(67, 18)
        TransmitCheck.TabIndex = 22
        TransmitCheck.Text = "Transmit"
        TransmitCheck.UseVisualStyleBackColor = True
        ' 
        ' DontUseAutoPriceForHedgeCheck
        ' 
        DontUseAutoPriceForHedgeCheck.AutoSize = True
        DontUseAutoPriceForHedgeCheck.Location = New Point(550, 591)
        DontUseAutoPriceForHedgeCheck.Name = "DontUseAutoPriceForHedgeCheck"
        DontUseAutoPriceForHedgeCheck.Size = New Size(172, 18)
        DontUseAutoPriceForHedgeCheck.TabIndex = 146
        DontUseAutoPriceForHedgeCheck.Text = "Don't use auto price for hedge"
        DontUseAutoPriceForHedgeCheck.UseVisualStyleBackColor = True
        ' 
        ' Mifid2ExecutionTraderText
        ' 
        Mifid2ExecutionTraderText.AcceptsReturn = True
        Mifid2ExecutionTraderText.BackColor = SystemColors.Window
        Mifid2ExecutionTraderText.BorderStyle = BorderStyle.None
        Mifid2ExecutionTraderText.Cursor = Cursors.IBeam
        Mifid2ExecutionTraderText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Mifid2ExecutionTraderText.ForeColor = SystemColors.WindowText
        Mifid2ExecutionTraderText.Location = New Point(143, 612)
        Mifid2ExecutionTraderText.MaxLength = 0
        Mifid2ExecutionTraderText.Name = "Mifid2ExecutionTraderText"
        Mifid2ExecutionTraderText.RightToLeft = RightToLeft.No
        Mifid2ExecutionTraderText.Size = New Size(85, 13)
        Mifid2ExecutionTraderText.TabIndex = 150
        ' 
        ' Label66
        ' 
        Label66.BackColor = Color.Gainsboro
        Label66.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label66.ForeColor = SystemColors.ControlText
        Label66.Location = New Point(11, 612)
        Label66.Name = "Label66"
        Label66.RightToLeft = RightToLeft.No
        Label66.Size = New Size(133, 17)
        Label66.TabIndex = 149
        Label66.Text = "MiFID II Execution Trader"
        ' 
        ' Mifid2ExecutionAlgoText
        ' 
        Mifid2ExecutionAlgoText.AcceptsReturn = True
        Mifid2ExecutionAlgoText.BackColor = SystemColors.Window
        Mifid2ExecutionAlgoText.BorderStyle = BorderStyle.None
        Mifid2ExecutionAlgoText.Cursor = Cursors.IBeam
        Mifid2ExecutionAlgoText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Mifid2ExecutionAlgoText.ForeColor = SystemColors.WindowText
        Mifid2ExecutionAlgoText.Location = New Point(432, 614)
        Mifid2ExecutionAlgoText.MaxLength = 0
        Mifid2ExecutionAlgoText.Name = "Mifid2ExecutionAlgoText"
        Mifid2ExecutionAlgoText.RightToLeft = RightToLeft.No
        Mifid2ExecutionAlgoText.Size = New Size(85, 13)
        Mifid2ExecutionAlgoText.TabIndex = 154
        ' 
        ' Label67
        ' 
        Label67.BackColor = Color.Gainsboro
        Label67.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label67.ForeColor = SystemColors.ControlText
        Label67.Location = New Point(264, 612)
        Label67.Name = "Label67"
        Label67.RightToLeft = RightToLeft.No
        Label67.Size = New Size(160, 17)
        Label67.TabIndex = 153
        Label67.Text = "MiFID II Execution Algo"
        ' 
        ' Mifid2DecisionMakerText
        ' 
        Mifid2DecisionMakerText.AcceptsReturn = True
        Mifid2DecisionMakerText.BackColor = SystemColors.Window
        Mifid2DecisionMakerText.BorderStyle = BorderStyle.None
        Mifid2DecisionMakerText.Cursor = Cursors.IBeam
        Mifid2DecisionMakerText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Mifid2DecisionMakerText.ForeColor = SystemColors.WindowText
        Mifid2DecisionMakerText.Location = New Point(142, 591)
        Mifid2DecisionMakerText.MaxLength = 0
        Mifid2DecisionMakerText.Name = "Mifid2DecisionMakerText"
        Mifid2DecisionMakerText.RightToLeft = RightToLeft.No
        Mifid2DecisionMakerText.Size = New Size(85, 13)
        Mifid2DecisionMakerText.TabIndex = 148
        ' 
        ' Label64
        ' 
        Label64.BackColor = Color.Gainsboro
        Label64.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label64.ForeColor = SystemColors.ControlText
        Label64.Location = New Point(13, 591)
        Label64.Name = "Label64"
        Label64.RightToLeft = RightToLeft.No
        Label64.Size = New Size(121, 17)
        Label64.TabIndex = 147
        Label64.Text = "MiFID II Decision Maker"
        ' 
        ' Mifid2DecisionAlgoText
        ' 
        Mifid2DecisionAlgoText.AcceptsReturn = True
        Mifid2DecisionAlgoText.BackColor = SystemColors.Window
        Mifid2DecisionAlgoText.BorderStyle = BorderStyle.None
        Mifid2DecisionAlgoText.Cursor = Cursors.IBeam
        Mifid2DecisionAlgoText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Mifid2DecisionAlgoText.ForeColor = SystemColors.WindowText
        Mifid2DecisionAlgoText.Location = New Point(432, 591)
        Mifid2DecisionAlgoText.MaxLength = 0
        Mifid2DecisionAlgoText.Name = "Mifid2DecisionAlgoText"
        Mifid2DecisionAlgoText.RightToLeft = RightToLeft.No
        Mifid2DecisionAlgoText.Size = New Size(85, 13)
        Mifid2DecisionAlgoText.TabIndex = 152
        ' 
        ' Label65
        ' 
        Label65.BackColor = Color.Gainsboro
        Label65.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label65.ForeColor = SystemColors.ControlText
        Label65.Location = New Point(264, 591)
        Label65.Name = "Label65"
        Label65.RightToLeft = RightToLeft.No
        Label65.Size = New Size(160, 17)
        Label65.TabIndex = 151
        Label65.Text = "MiFID II Decision Algo"
        ' 
        ' BlockOrderCheck
        ' 
        BlockOrderCheck.AutoSize = True
        BlockOrderCheck.Location = New Point(19, 297)
        BlockOrderCheck.Name = "BlockOrderCheck"
        BlockOrderCheck.Size = New Size(83, 18)
        BlockOrderCheck.TabIndex = 155
        BlockOrderCheck.Text = "Block Order"
        BlockOrderCheck.UseVisualStyleBackColor = True
        ' 
        ' SweepToFillCheck
        ' 
        SweepToFillCheck.AutoSize = True
        SweepToFillCheck.Location = New Point(19, 321)
        SweepToFillCheck.Name = "SweepToFillCheck"
        SweepToFillCheck.Size = New Size(88, 18)
        SweepToFillCheck.TabIndex = 156
        SweepToFillCheck.Text = "Sweep to Fill"
        SweepToFillCheck.UseVisualStyleBackColor = True
        ' 
        ' OutsideRTHCheck
        ' 
        OutsideRTHCheck.AutoSize = True
        OutsideRTHCheck.Location = New Point(267, 272)
        OutsideRTHCheck.Name = "OutsideRTHCheck"
        OutsideRTHCheck.Size = New Size(86, 18)
        OutsideRTHCheck.TabIndex = 157
        OutsideRTHCheck.Text = "Outside RTH"
        OutsideRTHCheck.UseVisualStyleBackColor = True
        ' 
        ' OverridePercentageConstraintsCheck
        ' 
        OverridePercentageConstraintsCheck.AutoSize = True
        OverridePercentageConstraintsCheck.Location = New Point(267, 200)
        OverridePercentageConstraintsCheck.Name = "OverridePercentageConstraintsCheck"
        OverridePercentageConstraintsCheck.Size = New Size(184, 18)
        OverridePercentageConstraintsCheck.TabIndex = 158
        OverridePercentageConstraintsCheck.Text = "Override Percentage Constraints"
        OverridePercentageConstraintsCheck.UseVisualStyleBackColor = True
        ' 
        ' AllOrNoneCheck
        ' 
        AllOrNoneCheck.AutoSize = True
        AllOrNoneCheck.Location = New Point(267, 57)
        AllOrNoneCheck.Name = "AllOrNoneCheck"
        AllOrNoneCheck.Size = New Size(79, 18)
        AllOrNoneCheck.TabIndex = 159
        AllOrNoneCheck.Text = "All or None"
        AllOrNoneCheck.UseVisualStyleBackColor = True
        ' 
        ' ContinuousUpdateCheck
        ' 
        ContinuousUpdateCheck.AutoSize = True
        ContinuousUpdateCheck.Location = New Point(552, 299)
        ContinuousUpdateCheck.Name = "ContinuousUpdateCheck"
        ContinuousUpdateCheck.Size = New Size(142, 18)
        ContinuousUpdateCheck.TabIndex = 162
        ContinuousUpdateCheck.Text = "VOL Continuous Update"
        ContinuousUpdateCheck.UseVisualStyleBackColor = True
        ' 
        ' OrderPropertyGrid
        ' 
        OrderPropertyGrid.Location = New Point(855, 214)
        OrderPropertyGrid.Name = "OrderPropertyGrid"
        OrderPropertyGrid.Size = New Size(287, 595)
        OrderPropertyGrid.TabIndex = 163
        ' 
        ' LmtPriceOffsetText
        ' 
        LmtPriceOffsetText.AcceptsReturn = True
        LmtPriceOffsetText.BackColor = SystemColors.Window
        LmtPriceOffsetText.BorderStyle = BorderStyle.None
        LmtPriceOffsetText.Cursor = Cursors.IBeam
        LmtPriceOffsetText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        LmtPriceOffsetText.ForeColor = SystemColors.WindowText
        LmtPriceOffsetText.Location = New Point(433, 699)
        LmtPriceOffsetText.MaxLength = 0
        LmtPriceOffsetText.Name = "LmtPriceOffsetText"
        LmtPriceOffsetText.RightToLeft = RightToLeft.No
        LmtPriceOffsetText.Size = New Size(85, 13)
        LmtPriceOffsetText.TabIndex = 165
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.Gainsboro
        Label8.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = SystemColors.ControlText
        Label8.Location = New Point(265, 699)
        Label8.Name = "Label8"
        Label8.RightToLeft = RightToLeft.No
        Label8.Size = New Size(136, 17)
        Label8.TabIndex = 164
        Label8.Text = "Lmt Price Offset"
        ' 
        ' Label9
        ' 
        Label9.BackColor = Color.Gainsboro
        Label9.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.ForeColor = SystemColors.ControlText
        Label9.Location = New Point(265, 132)
        Label9.Name = "Label9"
        Label9.RightToLeft = RightToLeft.No
        Label9.Size = New Size(105, 17)
        Label9.TabIndex = 166
        Label9.Text = "Duration"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(264, 154)
        Label10.Name = "Label10"
        Label10.Size = New Size(61, 14)
        Label10.TabIndex = 168
        Label10.Text = "Post To Ats"
        ' 
        ' PostToAtsText
        ' 
        PostToAtsText.BorderStyle = BorderStyle.None
        PostToAtsText.Location = New Point(433, 154)
        PostToAtsText.Name = "PostToAtsText"
        PostToAtsText.Size = New Size(85, 13)
        PostToAtsText.TabIndex = 169
        ' 
        ' NotHeldCheck
        ' 
        NotHeldCheck.AutoSize = True
        NotHeldCheck.Location = New Point(267, 177)
        NotHeldCheck.Name = "NotHeldCheck"
        NotHeldCheck.Size = New Size(65, 18)
        NotHeldCheck.TabIndex = 170
        NotHeldCheck.Text = "Not held"
        NotHeldCheck.UseVisualStyleBackColor = True
        ' 
        ' OmsContainerCheck
        ' 
        OmsContainerCheck.AutoSize = True
        OmsContainerCheck.Location = New Point(550, 615)
        OmsContainerCheck.Name = "OmsContainerCheck"
        OmsContainerCheck.Size = New Size(97, 18)
        OmsContainerCheck.TabIndex = 171
        OmsContainerCheck.Text = "OMS container"
        OmsContainerCheck.UseVisualStyleBackColor = True
        ' 
        ' AutoCancelParentCheck
        ' 
        AutoCancelParentCheck.AutoSize = True
        AutoCancelParentCheck.Location = New Point(15, 639)
        AutoCancelParentCheck.Name = "AutoCancelParentCheck"
        AutoCancelParentCheck.Size = New Size(119, 18)
        AutoCancelParentCheck.TabIndex = 155
        AutoCancelParentCheck.Text = "Auto Cancel Parent"
        AutoCancelParentCheck.UseVisualStyleBackColor = True
        ' 
        ' Label31
        ' 
        Label31.BackColor = Color.Gainsboro
        Label31.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        Label31.ForeColor = SystemColors.ControlText
        Label31.Location = New Point(264, 637)
        Label31.Name = "Label31"
        Label31.RightToLeft = RightToLeft.No
        Label31.Size = New Size(160, 17)
        Label31.TabIndex = 156
        Label31.Text = "Advanced Error Override"
        ' 
        ' AdvancedErrorOverrideText
        ' 
        AdvancedErrorOverrideText.AcceptsReturn = True
        AdvancedErrorOverrideText.BackColor = SystemColors.Window
        AdvancedErrorOverrideText.BorderStyle = BorderStyle.None
        AdvancedErrorOverrideText.Cursor = Cursors.IBeam
        AdvancedErrorOverrideText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        AdvancedErrorOverrideText.ForeColor = SystemColors.WindowText
        AdvancedErrorOverrideText.Location = New Point(432, 637)
        AdvancedErrorOverrideText.MaxLength = 0
        AdvancedErrorOverrideText.Name = "AdvancedErrorOverrideText"
        AdvancedErrorOverrideText.RightToLeft = RightToLeft.No
        AdvancedErrorOverrideText.Size = New Size(85, 13)
        AdvancedErrorOverrideText.TabIndex = 157
        ' 
        ' LabelManualOrderTime
        ' 
        LabelManualOrderTime.BackColor = Color.Gainsboro
        LabelManualOrderTime.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        LabelManualOrderTime.ForeColor = SystemColors.ControlText
        LabelManualOrderTime.Location = New Point(13, 660)
        LabelManualOrderTime.Name = "LabelManualOrderTime"
        LabelManualOrderTime.RightToLeft = RightToLeft.No
        LabelManualOrderTime.Size = New Size(117, 17)
        LabelManualOrderTime.TabIndex = 158
        LabelManualOrderTime.Text = "Manual Order Time"
        ' 
        ' ManualOrderTimeText
        ' 
        ManualOrderTimeText.AcceptsReturn = True
        ManualOrderTimeText.BackColor = SystemColors.Window
        ManualOrderTimeText.BorderStyle = BorderStyle.None
        ManualOrderTimeText.Cursor = Cursors.IBeam
        ManualOrderTimeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ManualOrderTimeText.ForeColor = SystemColors.WindowText
        ManualOrderTimeText.Location = New Point(143, 660)
        ManualOrderTimeText.MaxLength = 0
        ManualOrderTimeText.Name = "ManualOrderTimeText"
        ManualOrderTimeText.RightToLeft = RightToLeft.No
        ManualOrderTimeText.Size = New Size(85, 13)
        ManualOrderTimeText.TabIndex = 159
        ' 
        ' LabelManualOrderCancelTime
        ' 
        LabelManualOrderCancelTime.BackColor = Color.Gainsboro
        LabelManualOrderCancelTime.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        LabelManualOrderCancelTime.ForeColor = SystemColors.ControlText
        LabelManualOrderCancelTime.Location = New Point(264, 660)
        LabelManualOrderCancelTime.Name = "LabelManualOrderCancelTime"
        LabelManualOrderCancelTime.RightToLeft = RightToLeft.No
        LabelManualOrderCancelTime.Size = New Size(150, 17)
        LabelManualOrderCancelTime.TabIndex = 160
        LabelManualOrderCancelTime.Text = "Manual Order Cancel Time"
        ' 
        ' ManualOrderCancelTimeText
        ' 
        ManualOrderCancelTimeText.AcceptsReturn = True
        ManualOrderCancelTimeText.BackColor = SystemColors.Window
        ManualOrderCancelTimeText.BorderStyle = BorderStyle.None
        ManualOrderCancelTimeText.Cursor = Cursors.IBeam
        ManualOrderCancelTimeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        ManualOrderCancelTimeText.ForeColor = SystemColors.WindowText
        ManualOrderCancelTimeText.Location = New Point(432, 660)
        ManualOrderCancelTimeText.MaxLength = 0
        ManualOrderCancelTimeText.Name = "ManualOrderCancelTimeText"
        ManualOrderCancelTimeText.RightToLeft = RightToLeft.No
        ManualOrderCancelTimeText.Size = New Size(85, 13)
        ManualOrderCancelTimeText.TabIndex = 161
        ' 
        ' OcaTypeCombo
        ' 
        OcaTypeCombo.BackColor = SystemColors.Window
        OcaTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList
        OcaTypeCombo.FormattingEnabled = True
        OcaTypeCombo.ItemHeight = 14
        OcaTypeCombo.Location = New Point(144, 58)
        OcaTypeCombo.Name = "OcaTypeCombo"
        OcaTypeCombo.Size = New Size(85, 22)
        OcaTypeCombo.TabIndex = 172
        ' 
        ' TifCombo
        ' 
        TifCombo.DropDownStyle = ComboBoxStyle.DropDownList
        TifCombo.FormattingEnabled = True
        TifCombo.ItemHeight = 14
        TifCombo.Location = New Point(142, 9)
        TifCombo.Name = "TifCombo"
        TifCombo.Size = New Size(87, 22)
        TifCombo.TabIndex = 172
        ' 
        ' MinTradeQtyLabel
        ' 
        MinTradeQtyLabel.BackColor = Color.Gainsboro
        MinTradeQtyLabel.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MinTradeQtyLabel.ForeColor = SystemColors.ControlText
        MinTradeQtyLabel.Location = New Point(13, 684)
        MinTradeQtyLabel.Name = "MinTradeQtyLabel"
        MinTradeQtyLabel.RightToLeft = RightToLeft.No
        MinTradeQtyLabel.Size = New Size(117, 17)
        MinTradeQtyLabel.TabIndex = 162
        MinTradeQtyLabel.Text = "Min Trade Qty"
        ' 
        ' MinTradeQtyText
        ' 
        MinTradeQtyText.AcceptsReturn = True
        MinTradeQtyText.BackColor = SystemColors.Window
        MinTradeQtyText.BorderStyle = BorderStyle.None
        MinTradeQtyText.Cursor = Cursors.IBeam
        MinTradeQtyText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MinTradeQtyText.ForeColor = SystemColors.WindowText
        MinTradeQtyText.Location = New Point(144, 684)
        MinTradeQtyText.MaxLength = 0
        MinTradeQtyText.Name = "MinTradeQtyText"
        MinTradeQtyText.RightToLeft = RightToLeft.No
        MinTradeQtyText.Size = New Size(85, 13)
        MinTradeQtyText.TabIndex = 163
        ' 
        ' MinCompeteSizeLabel
        ' 
        MinCompeteSizeLabel.BackColor = Color.Gainsboro
        MinCompeteSizeLabel.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MinCompeteSizeLabel.ForeColor = SystemColors.ControlText
        MinCompeteSizeLabel.Location = New Point(264, 684)
        MinCompeteSizeLabel.Name = "MinCompeteSizeLabel"
        MinCompeteSizeLabel.RightToLeft = RightToLeft.No
        MinCompeteSizeLabel.Size = New Size(117, 17)
        MinCompeteSizeLabel.TabIndex = 164
        MinCompeteSizeLabel.Text = "Min Compete Size"
        ' 
        ' MinCompeteSizeText
        ' 
        MinCompeteSizeText.AcceptsReturn = True
        MinCompeteSizeText.BackColor = SystemColors.Window
        MinCompeteSizeText.BorderStyle = BorderStyle.None
        MinCompeteSizeText.Cursor = Cursors.IBeam
        MinCompeteSizeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MinCompeteSizeText.ForeColor = SystemColors.WindowText
        MinCompeteSizeText.Location = New Point(432, 684)
        MinCompeteSizeText.MaxLength = 0
        MinCompeteSizeText.Name = "MinCompeteSizeText"
        MinCompeteSizeText.RightToLeft = RightToLeft.No
        MinCompeteSizeText.Size = New Size(85, 13)
        MinCompeteSizeText.TabIndex = 165
        ' 
        ' CompeteAgainstBestOffsetLabel
        ' 
        CompeteAgainstBestOffsetLabel.BackColor = Color.Gainsboro
        CompeteAgainstBestOffsetLabel.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        CompeteAgainstBestOffsetLabel.ForeColor = SystemColors.ControlText
        CompeteAgainstBestOffsetLabel.Location = New Point(547, 684)
        CompeteAgainstBestOffsetLabel.Name = "CompeteAgainstBestOffsetLabel"
        CompeteAgainstBestOffsetLabel.RightToLeft = RightToLeft.No
        CompeteAgainstBestOffsetLabel.Size = New Size(155, 17)
        CompeteAgainstBestOffsetLabel.TabIndex = 166
        CompeteAgainstBestOffsetLabel.Text = "Compete Against Best Offset"
        ' 
        ' CompeteAgainstBestOffsetText
        ' 
        CompeteAgainstBestOffsetText.AcceptsReturn = True
        CompeteAgainstBestOffsetText.BackColor = SystemColors.Window
        CompeteAgainstBestOffsetText.BorderStyle = BorderStyle.None
        CompeteAgainstBestOffsetText.Cursor = Cursors.IBeam
        CompeteAgainstBestOffsetText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        CompeteAgainstBestOffsetText.ForeColor = SystemColors.WindowText
        CompeteAgainstBestOffsetText.Location = New Point(753, 684)
        CompeteAgainstBestOffsetText.MaxLength = 0
        CompeteAgainstBestOffsetText.Name = "CompeteAgainstBestOffsetText"
        CompeteAgainstBestOffsetText.RightToLeft = RightToLeft.No
        CompeteAgainstBestOffsetText.Size = New Size(85, 13)
        CompeteAgainstBestOffsetText.TabIndex = 167
        ' 
        ' CompeteAgainstBestOffsetUpToMidCheck
        ' 
        CompeteAgainstBestOffsetUpToMidCheck.AutoSize = True
        CompeteAgainstBestOffsetUpToMidCheck.Location = New Point(17, 715)
        CompeteAgainstBestOffsetUpToMidCheck.Name = "CompeteAgainstBestOffsetUpToMidCheck"
        CompeteAgainstBestOffsetUpToMidCheck.Size = New Size(215, 18)
        CompeteAgainstBestOffsetUpToMidCheck.TabIndex = 168
        CompeteAgainstBestOffsetUpToMidCheck.Text = "Compete Against Best Offset Up To Mid"
        CompeteAgainstBestOffsetUpToMidCheck.UseVisualStyleBackColor = True
        ' 
        ' MidOffsetAtWholeLabel
        ' 
        MidOffsetAtWholeLabel.BackColor = Color.Gainsboro
        MidOffsetAtWholeLabel.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MidOffsetAtWholeLabel.ForeColor = SystemColors.ControlText
        MidOffsetAtWholeLabel.Location = New Point(265, 716)
        MidOffsetAtWholeLabel.Name = "MidOffsetAtWholeLabel"
        MidOffsetAtWholeLabel.RightToLeft = RightToLeft.No
        MidOffsetAtWholeLabel.Size = New Size(117, 17)
        MidOffsetAtWholeLabel.TabIndex = 169
        MidOffsetAtWholeLabel.Text = "Mid Offset At Whole"
        ' 
        ' MidOffsetAtWholeText
        ' 
        MidOffsetAtWholeText.AcceptsReturn = True
        MidOffsetAtWholeText.BackColor = SystemColors.Window
        MidOffsetAtWholeText.BorderStyle = BorderStyle.None
        MidOffsetAtWholeText.Cursor = Cursors.IBeam
        MidOffsetAtWholeText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MidOffsetAtWholeText.ForeColor = SystemColors.WindowText
        MidOffsetAtWholeText.Location = New Point(433, 716)
        MidOffsetAtWholeText.MaxLength = 0
        MidOffsetAtWholeText.Name = "MidOffsetAtWholeText"
        MidOffsetAtWholeText.RightToLeft = RightToLeft.No
        MidOffsetAtWholeText.Size = New Size(85, 13)
        MidOffsetAtWholeText.TabIndex = 170
        ' 
        ' MidOffsetAtHalfLabel
        ' 
        MidOffsetAtHalfLabel.BackColor = Color.Gainsboro
        MidOffsetAtHalfLabel.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MidOffsetAtHalfLabel.ForeColor = SystemColors.ControlText
        MidOffsetAtHalfLabel.Location = New Point(548, 716)
        MidOffsetAtHalfLabel.Name = "MidOffsetAtHalfLabel"
        MidOffsetAtHalfLabel.RightToLeft = RightToLeft.No
        MidOffsetAtHalfLabel.Size = New Size(117, 17)
        MidOffsetAtHalfLabel.TabIndex = 171
        MidOffsetAtHalfLabel.Text = "Mid Offset At Half"
        ' 
        ' MidOffsetAtHalfText
        ' 
        MidOffsetAtHalfText.AcceptsReturn = True
        MidOffsetAtHalfText.BackColor = SystemColors.Window
        MidOffsetAtHalfText.BorderStyle = BorderStyle.None
        MidOffsetAtHalfText.Cursor = Cursors.IBeam
        MidOffsetAtHalfText.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        MidOffsetAtHalfText.ForeColor = SystemColors.WindowText
        MidOffsetAtHalfText.Location = New Point(753, 715)
        MidOffsetAtHalfText.MaxLength = 0
        MidOffsetAtHalfText.Name = "MidOffsetAtHalfText"
        MidOffsetAtHalfText.RightToLeft = RightToLeft.No
        MidOffsetAtHalfText.Size = New Size(85, 13)
        MidOffsetAtHalfText.TabIndex = 172
        ' 
        ' FOrderAttribs
        ' 
        AutoScaleBaseSize = New Size(5, 13)
        BackColor = Color.Gainsboro
        ClientSize = New Size(1158, 832)
        Controls.Add(MidOffsetAtHalfText)
        Controls.Add(MidOffsetAtHalfLabel)
        Controls.Add(MidOffsetAtWholeText)
        Controls.Add(MidOffsetAtWholeLabel)
        Controls.Add(CompeteAgainstBestOffsetUpToMidCheck)
        Controls.Add(CompeteAgainstBestOffsetText)
        Controls.Add(CompeteAgainstBestOffsetLabel)
        Controls.Add(MinCompeteSizeText)
        Controls.Add(MinCompeteSizeLabel)
        Controls.Add(MinTradeQtyText)
        Controls.Add(MinTradeQtyLabel)
        Controls.Add(OcaTypeCombo)
        Controls.Add(TifCombo)
        Controls.Add(ManualOrderCancelTimeText)
        Controls.Add(LabelManualOrderCancelTime)
        Controls.Add(ManualOrderTimeText)
        Controls.Add(LabelManualOrderTime)
        Controls.Add(AdvancedErrorOverrideText)
        Controls.Add(Label31)
        Controls.Add(AutoCancelParentCheck)
        Controls.Add(OmsContainerCheck)
        Controls.Add(NotHeldCheck)
        Controls.Add(PostToAtsText)
        Controls.Add(Label10)
        Controls.Add(DurationText)
        Controls.Add(Label9)
        Controls.Add(RelativeDiscretionaryCheck)
        Controls.Add(LmtPriceOffsetText)
        Controls.Add(Label8)
        Controls.Add(OrderPropertyGrid)
        Controls.Add(ContinuousUpdateCheck)
        Controls.Add(AllOrNoneCheck)
        Controls.Add(OverridePercentageConstraintsCheck)
        Controls.Add(OutsideRTHCheck)
        Controls.Add(SweepToFillCheck)
        Controls.Add(BlockOrderCheck)
        Controls.Add(Mifid2ExecutionTraderText)
        Controls.Add(Label66)
        Controls.Add(Mifid2ExecutionAlgoText)
        Controls.Add(Label67)
        Controls.Add(Mifid2DecisionMakerText)
        Controls.Add(Label64)
        Controls.Add(Mifid2DecisionAlgoText)
        Controls.Add(Label65)
        Controls.Add(DontUseAutoPriceForHedgeCheck)
        Controls.Add(TransmitCheck)
        Controls.Add(ModelCodeText)
        Controls.Add(Label63)
        Controls.Add(RandomizePriceCheck)
        Controls.Add(RandomizeSizeCheck)
        Controls.Add(SolicitedCheck)
        Controls.Add(ActiveStopTimeText)
        Controls.Add(ActiveStartTimeText)
        Controls.Add(ScaleTableText)
        Controls.Add(Label60)
        Controls.Add(Label61)
        Controls.Add(Label62)
        Controls.Add(Label59)
        Controls.Add(DeltaNeutralDesignatedLocationText)
        Controls.Add(Label58)
        Controls.Add(DeltaNeutralShortSaleSlotText)
        Controls.Add(DeltaNeutralShortSaleCheck)
        Controls.Add(Label57)
        Controls.Add(DeltaNeutralOpenCloseText)
        Controls.Add(TrailingPercentText)
        Controls.Add(Label56)
        Controls.Add(ScaleProfitOffsetText)
        Controls.Add(ScaleInitFillQtyText)
        Controls.Add(ScaleInitPositionText)
        Controls.Add(ScalePriceAdjustIntervalText)
        Controls.Add(ScaleRandomPercentCheck)
        Controls.Add(Label55)
        Controls.Add(Label54)
        Controls.Add(ScalePriceAdjustValueText)
        Controls.Add(ScaleAutoResetCheck)
        Controls.Add(Label53)
        Controls.Add(Label52)
        Controls.Add(Label51)
        Controls.Add(DeltaNeutralSettlingFirmText)
        Controls.Add(DeltaNeutralClearingAccountText)
        Controls.Add(DeltaNeutralClearingIntentText)
        Controls.Add(DeltaNeutralConIdText)
        Controls.Add(Label50)
        Controls.Add(Label49)
        Controls.Add(Label48)
        Controls.Add(Label47)
        Controls.Add(OptOutSmartRoutingCheck)
        Controls.Add(LabelHedgeParam)
        Controls.Add(LabelHedgeType)
        Controls.Add(HedgeParamText)
        Controls.Add(HedgeTypeText)
        Controls.Add(Label46)
        Controls.Add(ExemptCodeText)
        Controls.Add(Label45)
        Controls.Add(ClearingIntentText)
        Controls.Add(Label18)
        Controls.Add(ClearingAccountText)
        Controls.Add(Label44)
        Controls.Add(Label43)
        Controls.Add(Label42)
        Controls.Add(ScalePriceIncrText)
        Controls.Add(ScaleSubsLevelSizeText)
        Controls.Add(ScaleInitLevelSizeText)
        Controls.Add(TrailStopPriceText)
        Controls.Add(Label39)
        Controls.Add(DeltaNeutralAuxPriceText)
        Controls.Add(Label38)
        Controls.Add(VolatilityText)
        Controls.Add(VolatilityTypeText)
        Controls.Add(DeltaNeutralOrderTypeText)
        Controls.Add(ReferencePriceTypeText)
        Controls.Add(Rule80AText)
        Controls.Add(SettlingFirmText)
        Controls.Add(MinQtyText)
        Controls.Add(PercentOffsetText)
        Controls.Add(AuctionStrategyText)
        Controls.Add(StartingPriceText)
        Controls.Add(StockRefPriceText)
        Controls.Add(DeltaText)
        Controls.Add(StockRangeLowerText)
        Controls.Add(StockRangeUpperText)
        Controls.Add(ShortSaleSlotText)
        Controls.Add(DesignatedLocationText)
        Controls.Add(DiscretionaryAmtText)
        Controls.Add(HiddenText)
        Controls.Add(TriggerMethodCombo)
        Controls.Add(DisplaySizeText)
        Controls.Add(ParentIdText)
        Controls.Add(OrderRefText)
        Controls.Add(OriginText)
        Controls.Add(OpenCloseText)
        Controls.Add(AccountText)
        Controls.Add(OCAText)
        Controls.Add(Label21)
        Controls.Add(Label22)
        Controls.Add(Label36)
        Controls.Add(Label40)
        Controls.Add(OkButton)
        Controls.Add(CancelItButton)
        Controls.Add(Label35)
        Controls.Add(Label34)
        Controls.Add(Label33)
        Controls.Add(Label32)
        Controls.Add(Label28)
        Controls.Add(Label27)
        Controls.Add(Label26)
        Controls.Add(Label25)
        Controls.Add(Label24)
        Controls.Add(Label23)
        Controls.Add(Label19)
        Controls.Add(Label17)
        Controls.Add(Label16)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Location = New Point(1030, 270)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FOrderAttribs"
        RightToLeft = RightToLeft.No
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Extended Order Attributes"
        ResumeLayout(False)
        PerformLayout()
    End Sub
#End Region

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

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

        TifCombo.DataSource = IBAPI.OrderTIFs.ExternalNames
        TifCombo.SelectedIndex = TifCombo.FindStringExact(IBAPI.OrderTIFs.ToExternalString(mOrderInfo.TimeInForce))

        ActiveStartTimeText.Text = mOrderInfo.ActiveStartTime
        ActiveStopTimeText.Text = mOrderInfo.ActiveStopTime
        OCAText.Text = mOrderInfo.OcaGroup
        OcaTypeCombo.DataSource = IBAPI.OcaTypes.ExternalNames
        OcaTypeCombo.SelectedIndex = OcaTypeCombo.FindStringExact(IBAPI.OcaTypes.ToExternalString(mOrderInfo.OcaType))
        OrderRefText.Text = mOrderInfo.OrderReference
        ParentIdText.Text = mOrderInfo.ParentId.ToString
        BlockOrderCheck.Checked = mOrderInfo.BlockOrder
        SweepToFillCheck.Checked = mOrderInfo.SweepToFill
        DisplaySizeText.Text = mOrderInfo.DisplaySize.NullableIntegerToString

        TriggerMethodCombo.DataSource = IBAPI.TriggerMethods.ExternalNames
        TriggerMethodCombo.SelectedIndex = TriggerMethodCombo.FindStringExact(IBAPI.TriggerMethods.ToExternalString(mOrderInfo.TriggerMethod))

        OutsideRTHCheck.Checked = mOrderInfo.OutsideRth
        HiddenText.Text = mOrderInfo.Hidden.ToString
        OverridePercentageConstraintsCheck.Checked = mOrderInfo.OverridePercentageConstraints
        Rule80AText.Text = mOrderInfo.Rule80A
        AllOrNoneCheck.Checked = mOrderInfo.AllOrNone
        MinQtyText.Text = mOrderInfo.MinimumQuantity.NullableIntegerToString
        PercentOffsetText.Text = mOrderInfo.PercentOffset.NullableDoubleToString
        TrailStopPriceText.Text = mOrderInfo.TrailStopPrice.NullableDoubleToString
        TrailingPercentText.Text = mOrderInfo.TrailingPercent.NullableDoubleToString
        LmtPriceOffsetText.Text = mOrderInfo.LimitPriceOffset.NullableDoubleToString

        ' Institutional orders only
        OpenCloseText.Text = mOrderInfo.OpenClose
        OriginText.Text = mOrderInfo.Origin.ToString
        ShortSaleSlotText.Text = mOrderInfo.ShortSaleSlot.ToString
        DesignatedLocationText.Text = mOrderInfo.DesignatedLocation
        ExemptCodeText.Text = mOrderInfo.ExemptCode.ToString

        'SMART routing only
        DiscretionaryAmtText.Text = mOrderInfo.DiscretionaryAmount.ToString
        OptOutSmartRoutingCheck.Checked = mOrderInfo.OptOutSmartRouting

        ' BOX or VOL orders only
        AuctionStrategyText.Text = mOrderInfo.AuctionStrategy.ToString

        'BOX orders only
        StartingPriceText.Text = mOrderInfo.StartingPrice.NullableDoubleToString
        StockRefPriceText.Text = mOrderInfo.StockReferencePrice.NullableDoubleToString
        DeltaText.Text = mOrderInfo.Delta.NullableDoubleToString

        ' pegged to stock or VOL orders
        StockRangeLowerText.Text = mOrderInfo.StockRangeLower.NullableDoubleToString
        StockRangeUpperText.Text = mOrderInfo.StockRangeUpper.NullableDoubleToString

        ' VOLATILITY orders only
        VolatilityText.Text = mOrderInfo.Volatility.NullableDoubleToString
        VolatilityTypeText.Text = mOrderInfo.VolatilityType.NullableIntegerToString
        ContinuousUpdateCheck.Checked = CBool(mOrderInfo.ContinuousUpdate)
        ReferencePriceTypeText.Text = mOrderInfo.ReferencePriceType.NullableIntegerToString
        DeltaNeutralOrderTypeText.Text = IBAPI.OrderTypes.ToExternalString(mOrderInfo.DeltaNeutralOrderType)
        DeltaNeutralAuxPriceText.Text = mOrderInfo.DeltaNeutralAuxPrice.NullableDoubleToString
        DeltaNeutralConIdText.Text = CStr(mOrderInfo.DeltaNeutralContractId)
        DeltaNeutralSettlingFirmText.Text = mOrderInfo.DeltaNeutralSettlingFirm
        DeltaNeutralClearingAccountText.Text = mOrderInfo.DeltaNeutralClearingAccount
        DeltaNeutralClearingIntentText.Text = mOrderInfo.DeltaNeutralClearingIntent
        DeltaNeutralOpenCloseText.Text = mOrderInfo.DeltaNeutralOpenClose
        DeltaNeutralShortSaleCheck.Checked = mOrderInfo.DeltaNeutralShortSale
        DeltaNeutralShortSaleSlotText.Text = mOrderInfo.DeltaNeutralShortSaleSlot.ToString
        DeltaNeutralDesignatedLocationText.Text = mOrderInfo.DeltaNeutralDesignatedLocation

        ' SCALE orders only
        ScaleInitLevelSizeText.Text = mOrderInfo.ScaleInititialLevelSize.NullableIntegerToString
        ScaleSubsLevelSizeText.Text = mOrderInfo.ScaleSubsequentLevelSize.NullableIntegerToString
        ScalePriceIncrText.Text = mOrderInfo.ScalePriceIncrement.NullableDoubleToString
        ScalePriceAdjustValueText.Text = mOrderInfo.ScalePriceAdjustValue.NullableDoubleToString
        ScalePriceAdjustIntervalText.Text = mOrderInfo.ScalePriceAdjustInterval.NullableIntegerToString
        ScaleProfitOffsetText.Text = mOrderInfo.ScaleProfitOffset.NullableDoubleToString
        ScaleAutoResetCheck.Checked = mOrderInfo.ScaleAutoReset
        ScaleInitPositionText.Text = mOrderInfo.ScaleInitialPosition.NullableIntegerToString
        ScaleInitFillQtyText.Text = mOrderInfo.ScaleInitialFillQuantity.NullableIntegerToString
        ScaleRandomPercentCheck.Checked = mOrderInfo.ScaleRandomPercent
        ScaleTableText.Text = mOrderInfo.ScaleTable

        ' HEDGE orders only
        HedgeTypeText.Text = IBAPI.HedgeTypes.ToExternalString(mOrderInfo.HedgeType)
        HedgeParamText.Text = mOrderInfo.HedgeParameter

        ' Clearing info
        AccountText.Text = mOrderInfo.Account
        SettlingFirmText.Text = mOrderInfo.SettlingFirm
        ClearingAccountText.Text = mOrderInfo.ClearingAccount
        ClearingIntentText.Text = mOrderInfo.ClearingIntent

        SolicitedCheck.Checked = mOrderInfo.Solicited

        Mifid2DecisionMakerText.Text = mOrderInfo.Mifid2DecisionMaker
        Mifid2DecisionAlgoText.Text = mOrderInfo.Mifid2DecisionAlgo
        Mifid2ExecutionTraderText.Text = mOrderInfo.Mifid2ExecutionTrader
        Mifid2ExecutionAlgoText.Text = mOrderInfo.Mifid2ExecutionAlgo

        DontUseAutoPriceForHedgeCheck.Checked = mOrderInfo.DontUseAutoPriceForHedge
        OmsContainerCheck.Checked = mOrderInfo.IsOmsContainer
        RelativeDiscretionaryCheck.Checked = mOrderInfo.DiscretionaryUpToLimitPrice
        DurationText.Text = mOrderInfo.Duration.NullableIntegerToString
        PostToAtsText.Text = mOrderInfo.PostToAts.NullableIntegerToString
        NotHeldCheck.Checked = mOrderInfo.NotHeld
        AutoCancelParentCheck.Checked = mOrderInfo.AutoCancelParent
        AdvancedErrorOverrideText.Text = mOrderInfo.AdvancedErrorOverride
        'MinimumTradeQty.Text = ivalStr(mOrderInfo.MinTradeQty)
        'txtMinCompeteSize.Text = ivalStr(mOrderInfo.MinCompeteSize)
        'If mOrderInfo.CompeteAgainstBestOffset = IBAPI.Order.COMPETE_AGAINST_BEST_OFFSET_UP_TO_MID Then
        '    checkCompeteAgainstBestOffsetUpToMid.Checked = True
        'Else
        '    checkCompeteAgainstBestOffsetUpToMid.Checked = False
        '    txtCompeteAgainstBestOffset.Text = dvalStr(mOrderInfo.CompeteAgainstBestOffset)
        'End If
        'txtMidOffsetAtWhole.Text = dvalStr(mOrderInfo.MidOffsetAtWhole)
        'txtMidOffsetAtHalf.Text = dvalStr(mOrderInfo.MidOffsetAtHalf)
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

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        mOrderInfo.TimeInForce = IBAPI.OrderTIFs.Parse(TifCombo.SelectedItem.ToString)

        mOrderInfo.ActiveStartTime = ActiveStartTimeText.Text
        mOrderInfo.ActiveStopTime = ActiveStopTimeText.Text
        mOrderInfo.OcaGroup = OCAText.Text
        mOrderInfo.OcaType = IBAPI.OcaTypes.Parse(OcaTypeCombo.SelectedItem.ToString)
        mOrderInfo.OrderReference = OrderRefText.Text
        mOrderInfo.ParentId = CInt(ParentIdText.Text)
        mOrderInfo.BlockOrder = BlockOrderCheck.Checked
        mOrderInfo.SweepToFill = SweepToFillCheck.Checked
        mOrderInfo.DisplaySize = DisplaySizeText.Text.NullableIntegerFromString
        mOrderInfo.TriggerMethod = IBAPI.TriggerMethods.Parse(TriggerMethodCombo.SelectedItem.ToString)
        mOrderInfo.OutsideRth = OutsideRTHCheck.Checked
        mOrderInfo.Hidden = CBool(HiddenText.Text)
        mOrderInfo.OverridePercentageConstraints = OverridePercentageConstraintsCheck.Checked
        mOrderInfo.Rule80A = Rule80AText.Text
        mOrderInfo.AllOrNone = AllOrNoneCheck.Checked
        mOrderInfo.MinimumQuantity = MinQtyText.Text.NullableIntegerFromString
        mOrderInfo.PercentOffset = PercentOffsetText.Text.NullableDoubleFromString
        mOrderInfo.TrailStopPrice = TrailStopPriceText.Text.NullableDoubleFromString
        mOrderInfo.TrailingPercent = TrailingPercentText.Text.NullableDoubleFromString
        mOrderInfo.LimitPriceOffset = LmtPriceOffsetText.Text.NullableDoubleFromString

        ' Institutional orders only
        mOrderInfo.OpenClose = OpenCloseText.Text
        mOrderInfo.Origin = CInt(OriginText.Text)
        mOrderInfo.ShortSaleSlot = CInt(ShortSaleSlotText.Text)
        mOrderInfo.DesignatedLocation = DesignatedLocationText.Text
        mOrderInfo.ExemptCode = CInt(ExemptCodeText.Text)

        'SMART routing only
        mOrderInfo.DiscretionaryAmount = Double.Parse(DiscretionaryAmtText.Text, provider:=CultureInfo.InvariantCulture)
        mOrderInfo.OptOutSmartRouting = OptOutSmartRoutingCheck.Checked

        ' BOX or VOL orders only
        mOrderInfo.AuctionStrategy = AuctionStrategyText.Text.NullableEnumFromString(Of AuctionStrategy)

        'BOX orders only
        mOrderInfo.StartingPrice = StartingPriceText.Text.NullableDoubleFromString
        mOrderInfo.StockReferencePrice = StockRefPriceText.Text.NullableDoubleFromString
        mOrderInfo.Delta = DeltaText.Text.NullableDoubleFromString

        ' pegged to stock or VOL orders
        mOrderInfo.StockRangeLower = StockRangeLowerText.Text.NullableDoubleFromString
        mOrderInfo.StockRangeUpper = StockRangeUpperText.Text.NullableDoubleFromString

        ' VOLATILITY orders only
        mOrderInfo.Volatility = VolatilityText.Text.NullableDoubleFromString
        mOrderInfo.VolatilityType = VolatilityTypeText.Text.NullableIntegerFromString
        mOrderInfo.ContinuousUpdate = If(ContinuousUpdateCheck.Checked, 1, 0)
        mOrderInfo.ReferencePriceType = ReferencePriceTypeText.Text.NullableIntegerFromString
        mOrderInfo.DeltaNeutralOrderType = IBAPI.OrderTypes.Parse(DeltaNeutralOrderTypeText.Text)
        mOrderInfo.DeltaNeutralAuxPrice = DeltaNeutralAuxPriceText.Text.NullableDoubleFromString
        mOrderInfo.DeltaNeutralContractId = CInt(DeltaNeutralConIdText.Text)
        mOrderInfo.DeltaNeutralSettlingFirm = DeltaNeutralSettlingFirmText.Text
        mOrderInfo.DeltaNeutralClearingAccount = DeltaNeutralClearingAccountText.Text
        mOrderInfo.DeltaNeutralClearingIntent = DeltaNeutralClearingIntentText.Text
        mOrderInfo.DeltaNeutralOpenClose = DeltaNeutralOpenCloseText.Text
        mOrderInfo.DeltaNeutralShortSale = DeltaNeutralShortSaleCheck.Checked
        mOrderInfo.DeltaNeutralShortSaleSlot = CInt(DeltaNeutralShortSaleSlotText.Text)
        mOrderInfo.DeltaNeutralDesignatedLocation = DeltaNeutralDesignatedLocationText.Text

        ' SCALE orders only
        mOrderInfo.ScaleInititialLevelSize = ScaleInitLevelSizeText.Text.NullableIntegerFromString
        mOrderInfo.ScaleSubsequentLevelSize = ScaleSubsLevelSizeText.Text.NullableIntegerFromString
        mOrderInfo.ScalePriceIncrement = ScalePriceIncrText.Text.NullableDoubleFromString
        mOrderInfo.ScalePriceAdjustValue = ScalePriceAdjustValueText.Text.NullableDoubleFromString
        mOrderInfo.ScalePriceAdjustInterval = ScalePriceAdjustIntervalText.Text.NullableIntegerFromString
        mOrderInfo.ScaleProfitOffset = ScaleProfitOffsetText.Text.NullableDoubleFromString
        mOrderInfo.ScaleAutoReset = ScaleAutoResetCheck.Checked
        mOrderInfo.ScaleInitialPosition = ScaleInitPositionText.Text.NullableIntegerFromString
        mOrderInfo.ScaleInitialFillQuantity = ScaleInitFillQtyText.Text.NullableIntegerFromString
        mOrderInfo.ScaleRandomPercent = ScaleRandomPercentCheck.Checked
        mOrderInfo.ScaleTable = ScaleTableText.Text

        ' HEDGE orders only
        mOrderInfo.HedgeType = IBAPI.HedgeTypes.Parse(HedgeTypeText.Text, True)
        mOrderInfo.HedgeParameter = HedgeParamText.Text

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

        mOrderInfo.IsOmsContainer = OmsContainerCheck.Checked
        mOrderInfo.Duration = DurationText.Text.NullableIntegerFromString
        mOrderInfo.PostToAts = PostToAtsText.Text.NullableIntegerFromString
        mOrderInfo.NotHeld = NotHeldCheck.Checked


        mOk = True
        Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Hide()
    End Sub

End Class
