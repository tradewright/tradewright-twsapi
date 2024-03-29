#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2018 Richard L King (TradeWright Software Systems)
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

Imports System.Collections.Generic

Public Class Order

    ''
    ' Description here
    '
    '@/

    '@================================================================================
    ' Interfaces
    '@================================================================================

    '@================================================================================
    ' Events
    '@================================================================================

    '@================================================================================
    ' Enums
    '@================================================================================

    '@================================================================================
    ' Types
    '@================================================================================

    '@================================================================================
    ' Constants
    '@================================================================================

    Public Const Customer = 0
    Public Const FIRM = 1
    Public Const OPT_UNKNOWN = "?"c


    Public Const OPT_BROKER_DEALER = "b"c
    Public Const OPT_CUSTOMER = "c"c
    Public Const OPT_FIRM = "f"c
    Public Const OPT_ISEMM = "m"c
    Public Const OPT_FARMM = "n"c
    Public Const OPT_SPECIALIST = "y"c

    Public Const CompeteAgainstBestOffsetUpToMid = Double.PositiveInfinity

    '@================================================================================
    ' Member variables
    '@================================================================================

    ' main Order fields
    Public Property OrderId As Integer
    Public Property ClientID As Integer
    Public Property PermanentId As Integer
    Public Property Action As OrderAction
    Public Property TotalQuantity As Decimal
    Public Property OrderType As OrderType
    Public Property LimitPrice As Double?
    Public Property AuxPrice As Double?

    ' extended Order fields
    Public Property TimeInForce As OrderTimeInForce
    Public Property ActiveStartTime As String ' GTC orders
    Public Property ActiveStopTime As String ' GTC orders
    Public Property OcaGroup As String ' one cancels all group name
    Public Property OcaType As OcaType
    Public Property OrderReference As String
    Public Property ParentId As Integer ' Parent Order Id, to associate Auto STP or TRAIL orders with the original Order.
    Public Property BlockOrder As Boolean
    Public Property SweepToFill As Boolean
    Public Property DisplaySize As Integer?
    Public Property TriggerMethod As TriggerMethod
    Public Property OutsideRth As Boolean
    Public Property Hidden As Boolean
    Public Property GoodAfterTime As String ' FORMAT: 20060505 08:00:00 {Time zone}
    Public Property GoodTillDate As String ' FORMAT: 20060505 08:00:00 {Time zone}
    Public Property OverridePercentageConstraints As Boolean
    Public Property Rule80A As String ' Individual = 'I', Agency = 'A', AgentOtherMember = 'W', IndividualPTIA = 'J', AgencyPTIA = 'U', AgentOtherMemberPTIA = 'M', IndividualPT = 'K', AgencyPT = 'Y', AgentOtherMemberPT = 'N'
    Public Property AllOrNone As Boolean
    Public Property MinimumQuantity As Integer?
    Public Property PercentOffset As Double? ' REL orders only
    Public Property TrailStopPrice As Double? ' for TRAILLIMIT orders only
    Public Property TrailingPercent As Double? ' specify the percentage, e.g. 3, not .03

    ' Financial advisors only
    Public Property FaGroup As String
    Public Property FaMethod As String
    Public Property FaPercentage As String

    ' Institutional orders only
    Public Property OpenClose As String ' O=Open, C=Close
    Public Property Origin As Integer ' 0=Customer, 1=Firm
    Public Property ShortSaleSlot As Integer ' 1 if you hold the shares, 2 if they will be delivered from elsewhere.  Only for Action="SSHORT
    Public Property DesignatedLocation As String ' set when slot=2 only.
    Public Property ExemptCode As Integer

    ' SMART routing only
    Public Property DiscretionaryAmount As Double

    Public Property OptOutSmartRouting As Boolean

    ' BOX or VOL ORDERS ONLY
    Public Property AuctionStrategy As AuctionStrategy?

    ' BOX ORDERS ONLY
    Public Property StartingPrice As Double?
    Public Property StockReferencePrice As Double?
    Public Property Delta As Double?

    ' pegged to stock or VOL orders
    Public Property StockRangeLower As Double?
    Public Property StockRangeUpper As Double?

    ' VOLATILITY ORDERS ONLY
    Public Property Volatility As Double? ' enter percentage not decimal, e.g. 2 not .02
    Public Property VolatilityType As Integer? ' 1=daily, 2=annual
    Public Property ContinuousUpdate As Integer
    Public Property ReferencePriceType As Integer? ' 1=Average, 2 = BidOrAsk
    Public Property DeltaNeutralOrderType As OrderType
    Public Property DeltaNeutralAuxPrice As Double?
    Public Property DeltaNeutralContractId As Integer
    Public Property DeltaNeutralSettlingFirm As String
    Public Property DeltaNeutralClearingAccount As String
    Public Property DeltaNeutralClearingIntent As String
    Public Property DeltaNeutralOpenClose As String
    Public Property DeltaNeutralShortSale As Boolean
    Public Property DeltaNeutralShortSaleSlot As Integer
    Public Property DeltaNeutralDesignatedLocation As String

    ' COMBO ORDERS ONLY
    Public Property BasisPoints As Double? ' EFP orders only
    Public Property BasisPointsType As Integer? ' EFP orders only

    ' SCALE ORDERS ONLY
    Public Property ScaleInititialLevelSize As Integer?
    Public Property ScaleSubsequentLevelSize As Integer?
    Public Property ScalePriceIncrement As Double?
    Public Property ScalePriceAdjustValue As Double?
    Public Property ScalePriceAdjustInterval As Integer?
    Public Property ScaleProfitOffset As Double?
    Public Property ScaleAutoReset As Boolean
    Public Property ScaleInitialPosition As Integer?
    Public Property ScaleInitialFillQuantity As Integer?
    Public Property ScaleRandomPercent As Boolean
    Public Property ScaleTable As String

    ' HEDGE ORDERS ONLY
    Public Property HedgeType As HedgeType ' 'D' - delta, 'B' - beta, 'F' - FX, 'P' - pair
    Public Property HedgeParameter As String ' beta value for beta hedge (in range 0-1), ratio for pair hedge

    ' Clearing info
    Public Property Account As String ' IB account
    Public Property SettlingFirm As String
    Public Property ClearingAccount As String ' True beneficiary of the Order
    Public Property ClearingIntent As String ' "" (Default), "IB", "Away", "PTA" (PostTrade)

    ' ALGO ORDERS ONLY
    Public Property AlgorithmStrategy As String
    Public Property AlgorithmParameters() As TagValue()

    ' What-if
    Public Property WhatIf As Boolean

    Public Property AlgorithmId As String

    ' Not Held
    Public Property NotHeld As Boolean

    ' Smart combo routing params
    Public Property SmartComboRoutingParameters As List(Of TagValue)

    ' order combo legs
    Public Property OrderComboLegs() As OrderComboLeg()

    Public Property OrderMiscellaneousOptions As List(Of TagValue)

    Public Property Solicited As Boolean
    Public Property ModelCode As String

    ''' <summary>
    ''' A regulatory attribute that applies to all US Commodity (Futures) Exchanges, 
    ''' provided to allow client to comply with CFTC Tag 50 Rules
    ''' </summary>
    ''' <returns></returns>
    Public Property ExtOperator As String
    Public Property CashQuantity As Double?
    Public Property Mifid2DecisionMaker As String
    Public Property Mifid2DecisionAlgo As String
    Public Property Mifid2ExecutionTrader As String
    Public Property Mifid2ExecutionAlgo As String

    Public Property DontUseAutoPriceForHedge As Boolean
    Public Property RandomizeSize As Boolean
    Public Property RandomizePrice As Boolean
    Public Property AutoCancelDate As String
    Public Property FilledQuantity As Decimal?
    Public Property ReferenceFutureContractId As Integer?
    Public Property AutoCancelParent As Boolean
    Public Property Shareholder As String
    Public Property ImbalanceOnly As Boolean
    Public Property RouteMarketableToBbo As Boolean
    Public Property ParentPermanentId As Long?
    Public Property AdvancedErrorOverride As String
    Public Property ManualOrderTime As String
    Public Property MinimumTradeQuantity As Integer?
    Public Property MinimumCompeteSize As Integer?
    Public Property CompeteAgainstBestOffset As Double?
    Public Property MidOffsetAtWhole As Double?
    Public Property MidOffsetAtHalf As Double?


    ''' <summary>
    ''' For Pegged-to-benchmark orders, contains the Contract Id Of the contract against which the order will be pegged.
    ''' </summary>
    ''' <returns></returns>    
    Public Property ReferenceContractId As Integer

    ''' <summary>
    ''' For Pegged-to-benchmark orders, indicates whether the order's pegged price should increase or decreases.
    ''' </summary>
    ''' <returns></returns>
    Public Property IsPeggedChangeAmountDecrease As Boolean

    ''' <summary>
    ''' For Pegged-to-benchmark orders, specifies the amount by which the order's pegged price should move.
    ''' </summary>
    ''' <returns></returns>
    Public Property PeggedChangeAmount As Double?

    ''' <summary>
    ''' For Pegged-to-benchmark orders, specifies the amount the reference contract needs to move to adjust the pegged order.
    ''' </summary>
    ''' <returns></returns>
    Public Property ReferenceChangeAmount As Double?

    ''' <summary>
    ''' for Pegged-to-benchmark orders, specifies the exchange for the reference contract.
    ''' </summary>
    ''' <returns></returns>
    Public Property ReferenceExchange As String

    ''' <summary>
    ''' For Adjusted Stop orders, the parent order will be adjusted to the specified type When the adjusted trigger price is penetrated.
    ''' </summary>
    ''' <returns></returns>
    Public Property AdjustedOrderType As OrderType

    ''' <summary>
    ''' - DOC_TODO
    ''' </summary>
    ''' <returns></returns>
    Public Property TriggerPrice As Double?

    ''' <summary>
    ''' - DOC_TODO
    ''' </summary>
    ''' <returns></returns>
    Public Property LimitPriceOffset As Double?

    ''' <summary>
    ''' For Adjusted Stop orders, specifies the Stop price Of the adjusted (STP) parent.
    ''' </summary>
    ''' <returns></returns>
    Public Property AdjustedStopPrice As Double?

    ''' <summary>
    ''' For Adjusted Stop orders, specifies the Stop limit price Of the adjusted (STPL LMT) parent.
    ''' </summary>
    ''' <returns></returns>
    Public Property AdjustedStopLimitPrice As Double?

    ''' <summary>
    ''' For Adjusted Stop orders, specifies the trailing amount Of the adjusted (TRAIL) parent.
    ''' </summary>
    ''' <returns></returns>
    Public Property AdjustedTrailingAmount As Double?

    ''' <summary>
    ''' For Adjusted Stop orders, specifies whether the trailing unit is an amount (set To 0) or a percentage (set To 1).
    ''' </summary>
    ''' <returns></returns>
    Public Property AdjustableTrailingUnit As Integer

    ''' <summary>
    ''' Conditions that determine when the order will be activated or canceled.
    ''' </summary>
    ''' <returns></returns>
    Public Property Conditions As List(Of OrderCondition)

    ''' <summary>
    ''' Indicates whether conditions will also be valid outside Regular Trading Hours.
    ''' </summary>
    ''' <returns></returns>
    Public Property ConditionsIgnoreRth As Boolean

    ''' <summary>
    ''' Specifies whether conditions determine if the order should become active or be canceled.
    ''' </summary>
    ''' <returns></returns>
    Public Property ConditionsCancelOrder As Boolean

    ''' <summary>
    ''' Define the Soft Dollar Tier used for the order. Only provided for registered professional advisors And hedge And mutual funds.
    ''' </summary>
    ''' <returns></returns>
    Public Property Tier As SoftDollarTier

    Public Property IsOmsContainer As Boolean

    ''' <summary>
    ''' brief Set to true to convert order of type 'Primary Peg' to 'D-Peg'
    ''' </summary>
    Public Property DiscretionaryUpToLimitPrice As Boolean

    Public Property UsePriceMgmtAlgo As Boolean?

    Public Property Duration As Integer?

    Public Property PostToAts As Integer?

    '@================================================================================
    ' Class Event Handlers
    '@================================================================================

    Public Sub New()
        OpenClose = "O"
        Origin = Customer
        ExemptCode = -1
        DeltaNeutralOrderType = OrderType.None
        Conditions = New List(Of OrderCondition)
        Tier = New SoftDollarTier("", "", "")
    End Sub

    '@================================================================================
    ' XXXX Interface Members
    '@================================================================================

    '@================================================================================
    ' XXXX Event Handlers
    '@================================================================================

    '@================================================================================
    ' Properties
    '@================================================================================

    '@================================================================================
    ' Methods
    '@================================================================================

    '@================================================================================
    ' Helper Functions
    '@================================================================================
End Class