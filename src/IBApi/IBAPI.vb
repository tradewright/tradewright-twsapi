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
Imports System.Linq
Imports System.Reflection
Imports System.Threading
Imports System.Threading.Tasks

''' <summary>
''' This class provides the Application Programming Interface to Interactive Brokers' 
''' Trader Workstation and Gateway products.
''' 
''' Updated to IB commit 6697b6ecf2335a07229306bf52d73755b6f62d2b on 18/05/2018
''' 
''' </summary>
Public Class IBAPI
    Implements IDisposable

#Region "Constants"

    Public Const MaxContractRequestId As Integer = IdManager.MaxCallersContractRequestId
    Public Const MaxExecutionsRequestId As Integer = IdManager.MaxCallersExecutionsRequestId
    Public Const MaxHistoricalDataRequestId As Integer = IdManager.MaxCallersHistoricalDataRequestId
    Public Const MaxMarketDataRequestId As Integer = IdManager.MaxCallersMarketDataRequestId
    Public Const MaxMarketDepthRequestId As Integer = IdManager.MaxCallersMarketDepthRequestId

#End Region

#Region "Extended Enums"

    Public Shared ApiLogLevels As New ExtendedEnum(Of System.Enum, ApiLogLevel)(
        {
            ("System", ApiLogLevel.System, EnumNameType.Both),
            ("Error", ApiLogLevel.Error, EnumNameType.Both),
            ("Warning", ApiLogLevel.Warning, EnumNameType.Both),
            ("Information", ApiLogLevel.Information, EnumNameType.Both),
            ("Detail", ApiLogLevel.Detail, EnumNameType.Both)
        })

    Friend Shared ApiSocketInMsgTypes As New ExtendedEnum(Of System.Enum, ApiSocketInMsgType)(
        {
            ("TickPrice", ApiSocketInMsgType.TickPrice, EnumNameType.Both),
            ("TickSize", ApiSocketInMsgType.TickSize, EnumNameType.Both),
            ("OrderStatus", ApiSocketInMsgType.OrderStatus, EnumNameType.Both),
            ("ErrorMessage", ApiSocketInMsgType.Error, EnumNameType.Both),
            ("OpenOrder", ApiSocketInMsgType.OpenOrder, EnumNameType.Both),
            ("AccountValue", ApiSocketInMsgType.AccountValue, EnumNameType.Both),
            ("PortfolioValue", ApiSocketInMsgType.PortfolioValue, EnumNameType.Both),
            ("AccountUpdateTime", ApiSocketInMsgType.AccountTime, EnumNameType.Both),
            ("NextValidId", ApiSocketInMsgType.NextValidId, EnumNameType.Both),
            ("ContractData", ApiSocketInMsgType.ContractData, EnumNameType.Both),
            ("ExecutionData", ApiSocketInMsgType.ExecutionData, EnumNameType.Both),
            ("MarketDepth", ApiSocketInMsgType.MarketDepth, EnumNameType.Both),
            ("MarketDepthL2", ApiSocketInMsgType.MarketDepthL2, EnumNameType.Both),
            ("NewBulletin", ApiSocketInMsgType.NewsBulletins, EnumNameType.Both),
            ("ManagedAccounts", ApiSocketInMsgType.ManagedAccounts, EnumNameType.Both),
            ("FinancialAdvisorData", ApiSocketInMsgType.FinanialAdvisorData, EnumNameType.Both),
            ("HistoricalBar", ApiSocketInMsgType.HistoricalBar, EnumNameType.Both),
            ("BondContractData", ApiSocketInMsgType.BondContractData, EnumNameType.Both),
            ("ScannerParameters", ApiSocketInMsgType.ScannerParameters, EnumNameType.Both),
            ("ScannerData", ApiSocketInMsgType.ScannerData, EnumNameType.Both),
            ("OptionComputation", ApiSocketInMsgType.TickOptionComputation, EnumNameType.Both),
            ("TickGeneric", ApiSocketInMsgType.TickGeneric, EnumNameType.Both),
            ("TickString", ApiSocketInMsgType.Tickstring, EnumNameType.Both),
            ("EFP", ApiSocketInMsgType.TickEFP, EnumNameType.Both),
            ("CurrentTime", ApiSocketInMsgType.CurrentTime, EnumNameType.Both),
            ("RealtimeBar", ApiSocketInMsgType.RealtimeBars, EnumNameType.Both),
            ("FundamentalData", ApiSocketInMsgType.FundamentalData, EnumNameType.Both),
            ("ContractDataEnd", ApiSocketInMsgType.ContractDataEnd, EnumNameType.Both),
            ("OpenOrderEnd", ApiSocketInMsgType.OpenOrderEnd, EnumNameType.Both),
            ("AccountDownloadEnd", ApiSocketInMsgType.AccountDownloadEnd, EnumNameType.Both),
            ("ExecutionDataEnd", ApiSocketInMsgType.ExecutionDataEnd, EnumNameType.Both),
            ("DeltaNeutralValidation", ApiSocketInMsgType.DeltaNeutralValidation, EnumNameType.Both),
            ("TickSnapshotEnd", ApiSocketInMsgType.TickSnapshotEnd, EnumNameType.Both),
            ("MarketDataType", ApiSocketInMsgType.MarketDataType, EnumNameType.Both),
            ("CommissionReport", ApiSocketInMsgType.CommissionReport, EnumNameType.Both),
            ("Position", ApiSocketInMsgType.Position, EnumNameType.Both),
            ("PositionEnd", ApiSocketInMsgType.PositionEnd, EnumNameType.Both),
            ("AccountSummary", ApiSocketInMsgType.AccountSummary, EnumNameType.Both),
            ("AccountSummaryEnd", ApiSocketInMsgType.AccountSummaryEnd, EnumNameType.Both),
            ("VerifyMessageApi", ApiSocketInMsgType.VerifyMessageApi, EnumNameType.Both),
            ("VerifyCompleted", ApiSocketInMsgType.VerifyCompleted, EnumNameType.Both),
            ("DisplayGroupList", ApiSocketInMsgType.DisplayGroupList, EnumNameType.Both),
            ("DisplayGroupUpdated", ApiSocketInMsgType.DisplayGroupUpdated, EnumNameType.Both),
            ("VerifyAndAuthMessageApi", ApiSocketInMsgType.VerifyAndAuthMessageApi, EnumNameType.Both),
            ("VerifyAndAuthCompleted", ApiSocketInMsgType.VerifyAndAuthCompleted, EnumNameType.Both),
            ("PositionMulti", ApiSocketInMsgType.PositionMulti, EnumNameType.Both),
            ("PositionMultiEnd", ApiSocketInMsgType.PositionMultiEnd, EnumNameType.Both),
            ("AccountUpdateMulti", ApiSocketInMsgType.AccountUpdateMulti, EnumNameType.Both),
            ("AccountUpdateMultiEnd", ApiSocketInMsgType.AccountUpdateMultiEnd, EnumNameType.Both),
            ("SecurityDefinitionOptionParameter", ApiSocketInMsgType.SecurityDefinitionOptionParameter, EnumNameType.Both),
            ("SecurityDefinitionOptionParameterEnd", ApiSocketInMsgType.SecurityDefinitionOptionParameterEnd, EnumNameType.Both),
            ("SoftDollarTiers", ApiSocketInMsgType.SoftDollarTiers, EnumNameType.Both),
            ("FamilyCodes", ApiSocketInMsgType.FamilyCodes, EnumNameType.Both),
            ("SymbolSamples", ApiSocketInMsgType.SymbolSamples, EnumNameType.Both),
            ("MarketDepthExchanges", ApiSocketInMsgType.MarketDepthExchanges, EnumNameType.Both),
            ("TickRequestParams", ApiSocketInMsgType.TickRequestParams, EnumNameType.Both),
            ("SmartComponents", ApiSocketInMsgType.SmartComponents, EnumNameType.Both),
            ("NewsArticle", ApiSocketInMsgType.NewsArticle, EnumNameType.Both),
            ("TickNews", ApiSocketInMsgType.TickNews, EnumNameType.Both),
            ("NewsProviders", ApiSocketInMsgType.NewsProviders, EnumNameType.Both),
            ("HistoricalNews", ApiSocketInMsgType.HistoricalNews, EnumNameType.Both),
            ("HistoricalNewsEnd", ApiSocketInMsgType.HistoricalNewsEnd, EnumNameType.Both),
            ("HeadTimestamp", ApiSocketInMsgType.HeadTimestamp, EnumNameType.Both),
            ("HistogramData", ApiSocketInMsgType.HistogramData, EnumNameType.Both),
            ("HistoricalDataUpdate", ApiSocketInMsgType.HistoricalDataUpdate, EnumNameType.Both),
            ("RerouteMarketData", ApiSocketInMsgType.RerouteMarketData, EnumNameType.Both),
            ("RerouteMarketDepth", ApiSocketInMsgType.RerouteMarketDepth, EnumNameType.Both),
            ("MarketRule", ApiSocketInMsgType.MarketRule, EnumNameType.Both),
            ("PnL", ApiSocketInMsgType.PnL, EnumNameType.Both),
            ("PnLSingle", ApiSocketInMsgType.PnLSingle, EnumNameType.Both),
            ("HistoricalTickMidpoint", ApiSocketInMsgType.HistoricalTickMidpoint, EnumNameType.Both),
            ("HistoricalTickBidAsk", ApiSocketInMsgType.HistoricalTickBidAsk, EnumNameType.Both),
            ("HistoricalTickLast", ApiSocketInMsgType.HistoricalTickLast, EnumNameType.Both),
            ("TickByTick", ApiSocketInMsgType.TickByTick, EnumNameType.Both)
        })

    Friend Shared ApiSocketOutMsgTypes As New ExtendedEnum(Of System.Enum, ApiSocketOutMsgType)(
        {
            ("REQ_MKT_DATA", ApiSocketOutMsgType.RequestMarketData, EnumNameType.Both),
            ("CANCEL_MKT_DATA", ApiSocketOutMsgType.CancelMarketData, EnumNameType.Both),
            ("PLACE_ORDER", ApiSocketOutMsgType.PlaceOrder, EnumNameType.Both),
            ("CANCEL_ORDER", ApiSocketOutMsgType.CancelOrder, EnumNameType.Both),
            ("REQ_OPEN_ORDERS", ApiSocketOutMsgType.RequestOpenOrders, EnumNameType.Both),
            ("REQ_ACCT_DATA", ApiSocketOutMsgType.RequestAccountData, EnumNameType.Both),
            ("REQ_EXECUTIONS", ApiSocketOutMsgType.RequestExecutions, EnumNameType.Both),
            ("REQ_IDS", ApiSocketOutMsgType.RequestIds, EnumNameType.Both),
            ("REQ_CONTRACT_DATA", ApiSocketOutMsgType.RequestContractData, EnumNameType.Both),
            ("REQ_MKT_DEPTH", ApiSocketOutMsgType.RequestMarketDepth, EnumNameType.Both),
            ("CANCEL_MKT_DEPTH", ApiSocketOutMsgType.CancelMarketDepth, EnumNameType.Both),
            ("REQ_NEWS_BULLETINS", ApiSocketOutMsgType.RequestNewsBulletins, EnumNameType.Both),
            ("CANCEL_NEWS_BULLETINS", ApiSocketOutMsgType.CancelNewsBulletins, EnumNameType.Both),
            ("SET_SERVER_LOGLEVEL", ApiSocketOutMsgType.SetServerLogLevel, EnumNameType.Both),
            ("REQ_AUTO_OPEN_ORDERS", ApiSocketOutMsgType.RequestAutoOpenOrders, EnumNameType.Both),
            ("REQ_ALL_OPEN_ORDERS", ApiSocketOutMsgType.RequestAllOpenOrders, EnumNameType.Both),
            ("REQ_MANAGED_ACCTS", ApiSocketOutMsgType.RequestManagedAccounts, EnumNameType.Both),
            ("REQ_FA", ApiSocketOutMsgType.RequestFinancialAdvisorData, EnumNameType.Both),
            ("REPLACE_FA", ApiSocketOutMsgType.ReplaceFinancialAdvisorData, EnumNameType.Both),
            ("REQ_HISTORICAL_BARS", ApiSocketOutMsgType.RequestHistoricalBars, EnumNameType.Both),
            ("EXERCISE_OPTIONS", ApiSocketOutMsgType.ExerciseOptions, EnumNameType.Both),
            ("REQ_SCANNER_SUBSCRIPTION", ApiSocketOutMsgType.RequestScannerSubscription, EnumNameType.Both),
            ("CANCEL_SCANNER_SUBSCRIPTION", ApiSocketOutMsgType.CancelScannerSubscription, EnumNameType.Both),
            ("REQ_SCANNER_PARAMETERS", ApiSocketOutMsgType.RequestScannerParameters, EnumNameType.Both),
            ("CANCEL_HISTORICAL_DATA", ApiSocketOutMsgType.CancelHistoricalData, EnumNameType.Both),
            ("REQ_CURRENT_TIME", ApiSocketOutMsgType.RequestCurrentTime, EnumNameType.Both),
            ("REQ_REALTIME_BARS", ApiSocketOutMsgType.RequestRealtimeBars, EnumNameType.Both),
            ("CANCEL_REALTIME_BARS", ApiSocketOutMsgType.CancelRealtimeBars, EnumNameType.Both),
            ("REQ_FUNDAMENTAL_DATA", ApiSocketOutMsgType.RequestFundamentalData, EnumNameType.Both),
            ("CANCEL_FUNDAMENTAL_DATA", ApiSocketOutMsgType.CancelFundamentalData, EnumNameType.Both),
            ("CALC_IMPLIED_VOLATILITY", ApiSocketOutMsgType.CalculateImpliedVolatility, EnumNameType.Both),
            ("CALC_OPTION_PRICE", ApiSocketOutMsgType.CalculateOptionPrice, EnumNameType.Both),
            ("CANCEL_CALC_MPLIED_VOLATILITY", ApiSocketOutMsgType.CancelCalculateImpliedVolatility, EnumNameType.Both),
            ("CANCEL_CALC_OPTION_PRICE", ApiSocketOutMsgType.CancelCalculateOptionPrice, EnumNameType.Both),
            ("REQ_GLOBAL_CANCEL", ApiSocketOutMsgType.RequestGlobalCancel, EnumNameType.Both),
            ("REQ_MARKET_DATA_TYPE", ApiSocketOutMsgType.RequestMarketDataType, EnumNameType.Both),
            ("REQ_POSITIONS", ApiSocketOutMsgType.RequestPositions, EnumNameType.Both),
            ("REQ_ACCOUNT_SUMMARY", ApiSocketOutMsgType.RequestAccountSummary, EnumNameType.Both),
            ("CANCEL_ACCOUNT_SUMMARY", ApiSocketOutMsgType.CancelAccountSummary, EnumNameType.Both),
            ("CANCEL_POSITIONS", ApiSocketOutMsgType.CancelPositions, EnumNameType.Both),
            ("VERIFY_REQUEST", ApiSocketOutMsgType.VerifyRequest, EnumNameType.Both),
            ("VERIFY_MESSAGE", ApiSocketOutMsgType.VerifyMessage, EnumNameType.Both),
            ("QUERY_DISPLAY_GROUPS", ApiSocketOutMsgType.QueryDisplayGroups, EnumNameType.Both),
            ("SUBSCRIBE_TO_GROUP_EVENTS", ApiSocketOutMsgType.SubscribeToGroupEvents, EnumNameType.Both),
            ("UPDATE_DISPLAY_GROUP", ApiSocketOutMsgType.UpdateDisplayGroup, EnumNameType.Both),
            ("UNSUBSCRIBE_FROM_GROUP_EVENTS", ApiSocketOutMsgType.UnsubscribeFromGroupEvents, EnumNameType.Both),
            ("START_API", ApiSocketOutMsgType.StartApi, EnumNameType.Both),
            ("VERIFY_AND_AUTH_REQ", ApiSocketOutMsgType.VerifyAndAuthRequest, EnumNameType.Both),
            ("VERIFY_AND_AUTH_MESSAGE", ApiSocketOutMsgType.VerifyAndAuthMessage, EnumNameType.Both),
            ("REQ_POSITIONS_MULTI", ApiSocketOutMsgType.RequestPositionsMulti, EnumNameType.Both),
            ("CANCEL_POSITIONS_MULTI", ApiSocketOutMsgType.CancelPositionsMulti, EnumNameType.Both),
            ("REQ_ACCOUNT_UPDATES_MULTI", ApiSocketOutMsgType.RequestAccountDataMulti, EnumNameType.Both),
            ("CANCEL_ACCOUNT_UPDATES_MULTI", ApiSocketOutMsgType.CancelAccountUpdatesMulti, EnumNameType.Both),
            ("REQ_SEC_DEF_OPT_PARAMS", ApiSocketOutMsgType.RequestSecurityDefinitionOptionParameters, EnumNameType.Both),
            ("REQ_SOFT_DOLLAR_TIERS", ApiSocketOutMsgType.RequestSoftDollarTiers, EnumNameType.Both),
            ("REQ_FAMILY_CODES", ApiSocketOutMsgType.RequestFamilyCodes, EnumNameType.Both),
            ("REQ_MATCHING_SYMBOLS", ApiSocketOutMsgType.RequestMatchingSymbols, EnumNameType.Both),
            ("REQ_MKT_DEPTH_EXCHANGES", ApiSocketOutMsgType.RequestMarketDepthExchanges, EnumNameType.Both),
            ("RequestSmartComponents", ApiSocketOutMsgType.RequestSmartComponents, EnumNameType.Both),
            ("RequestNewsArticle", ApiSocketOutMsgType.RequestNewsArticle, EnumNameType.Both),
            ("RequestNewsProviders", ApiSocketOutMsgType.RequestNewsProviders, EnumNameType.Both),
            ("RequestHistoricalNews", ApiSocketOutMsgType.RequestHistoricalNews, EnumNameType.Both),
            ("RequestHeadTimestamp", ApiSocketOutMsgType.RequestHeadTimestamp, EnumNameType.Both),
            ("RequestHistogramData", ApiSocketOutMsgType.RequestHistogramData, EnumNameType.Both),
            ("CancelHistogramData", ApiSocketOutMsgType.CancelHistogramData, EnumNameType.Both),
            ("CancelHeadTimestamp", ApiSocketOutMsgType.CancelHeadTimestamp, EnumNameType.Both),
            ("RequestMarketRule", ApiSocketOutMsgType.RequestMarketRule, EnumNameType.Both),
            ("RequestPnL", ApiSocketOutMsgType.RequestPnL, EnumNameType.Both),
            ("CancelPnL", ApiSocketOutMsgType.CancelPnL, EnumNameType.Both),
            ("RequestPnLSingle", ApiSocketOutMsgType.RequestPnLSingle, EnumNameType.Both),
            ("CancelPnLSingle", ApiSocketOutMsgType.CancelPnLSingle, EnumNameType.Both),
            ("RequestHistoricalTickData", ApiSocketOutMsgType.RequestHistoricalTickData, EnumNameType.Both),
            ("RequestTickByTickData", ApiSocketOutMsgType.RequestTickByTickData, EnumNameType.Both),
            ("CancelTickByTickData", ApiSocketOutMsgType.CancelTickByTickData, EnumNameType.Both)
            })

    Public Shared HedgeTypes As New ExtendedEnum(Of System.Enum, HedgeType)({
            ("D", HedgeType.Delta, EnumNameType.Internal),
            ("Delta", HedgeType.Delta, EnumNameType.External),
            ("B", HedgeType.Beta, EnumNameType.Internal),
            ("Beta", HedgeType.Beta, EnumNameType.External),
            ("F", HedgeType.FX, EnumNameType.Internal),
            ("Fx", HedgeType.FX, EnumNameType.External),
            ("P", HedgeType.Pair, EnumNameType.Internal),
            ("Pair", HedgeType.Pair, EnumNameType.External),
            ("", HedgeType.None, EnumNameType.Internal),
            ("*None*", HedgeType.None, EnumNameType.External)
        })

    Public Shared LiquidityTypes As New ExtendedEnum(Of System.Enum, LiquidityType)({
            ("", LiquidityType.None, EnumNameType.Internal),
            ("Added Liquidity", LiquidityType.AddedLiquidity, EnumNameType.Both),
            ("Removed Liquidity", LiquidityType.RemovedLiquidity, EnumNameType.Both),
            ("Liquidity Routed Out", LiquidityType.LiquidityRoutedOut, EnumNameType.Both)
        })

    Public Shared OcaTypes As New ExtendedEnum(Of System.Enum, OcaType)({
            ("", OcaType.None, EnumNameType.Alias),
            ("*None*", OcaType.None, EnumNameType.NonAliasExternal),
            ("CancelWithBlock", OcaType.CancelWithBlock, EnumNameType.Both),
            ("ReduceWithBlock", OcaType.ReduceWithBlock, EnumNameType.Both),
            ("ReduceNonBlock", OcaType.ReduceNonBlock, EnumNameType.Both)
        })

    Public Shared OptionRights As New ExtendedEnum(Of System.Enum, OptionRight)({
            ("", OptionRight.None, EnumNameType.Internal),
            ("0", OptionRight.None, EnumNameType.Alias),    ' PortfolioValue messages seem to use this 
            ("*None*", OptionRight.None, EnumNameType.NonAliasExternal),
            ("?", OptionRight.None, EnumNameType.External),
            ("Call", OptionRight.Call, EnumNameType.External),
            ("C", OptionRight.Call, EnumNameType.Internal),
            ("Put", OptionRight.Put, EnumNameType.External),
            ("P", OptionRight.Put, EnumNameType.Internal)
    })

    Public Shared OrderActions As New ExtendedEnum(Of System.Enum, OrderAction)(
        {
            ("Buy", OrderAction.Buy, EnumNameType.External),
            ("BUY", OrderAction.Buy, EnumNameType.Internal),
            ("Sell", OrderAction.Sell, EnumNameType.External),
            ("SELL", OrderAction.Sell, EnumNameType.Internal),
            ("Sell Short", OrderAction.SellShort, EnumNameType.External),
            ("SSHORT", OrderAction.SellShort, EnumNameType.Internal),
            ("", OrderAction.None, EnumNameType.Internal),
            ("*None*", OrderAction.None, EnumNameType.NonAliasExternal)
        })

    Public Shared OrderTIFs As New ExtendedEnum(Of System.Enum, OrderTimeInForce)(
        {
            ("", OrderTimeInForce.None, EnumNameType.Internal),
            ("*None*", OrderTimeInForce.None, EnumNameType.NonAliasExternal),
            ("Day", OrderTimeInForce.Day, EnumNameType.External),
            ("DAY", OrderTimeInForce.Day, EnumNameType.Internal),
            ("Good Till Cancelled", OrderTimeInForce.GoodTillCancelled, EnumNameType.External),
            ("GTC", OrderTimeInForce.GoodTillCancelled, EnumNameType.Internal),
            ("Immediate or Cancel", OrderTimeInForce.ImmediateOrCancel, EnumNameType.External),
            ("IOC", OrderTimeInForce.ImmediateOrCancel, EnumNameType.Internal)
        })

    Public Shared OrderTypes As New ExtendedEnum(Of System.Enum, OrderType)(
        {
            ("", OrderType.None, EnumNameType.Internal),
            ("None", OrderType.None, EnumNameType.Alias),
            ("*None*", OrderType.None, EnumNameType.NonAliasExternal),
            ("MKT", OrderType.Market, EnumNameType.Both),
            ("MKTCLS", OrderType.MarketOnClose, EnumNameType.Both),
            ("LMT", OrderType.Limit, EnumNameType.Both),
            ("LMTCLS", OrderType.LimitOnClose, EnumNameType.Both),
            ("PEGMKT", OrderType.PeggedToMarket, EnumNameType.Both),
            ("STP", OrderType.Stop, EnumNameType.Both),
            ("STPLMT", OrderType.StopLimit, EnumNameType.Both),
            ("STP LMT", OrderType.StopLimit, EnumNameType.Both),
            ("TRAIL", OrderType.Trail, EnumNameType.Both),
            ("REL", OrderType.Relative, EnumNameType.Both),
            ("VWAP", OrderType.VWAP, EnumNameType.Both),
            ("MTL", OrderType.MarketToLimit, EnumNameType.Both),
            ("RFQ", OrderType.Quote, EnumNameType.Both),
            ("ADJUST", OrderType.Adjust, EnumNameType.Both),
            ("ALERT", OrderType.Alert, EnumNameType.Both),
            ("LIT", OrderType.LimitIfTouched, EnumNameType.Both),
            ("MIT", OrderType.MarketIfTouched, EnumNameType.Both),
            ("TRAILLMT", OrderType.TrailLimit, EnumNameType.Both),
            ("MKTPROT", OrderType.MarketWithProtection, EnumNameType.Both),
            ("MOO", OrderType.MarketOnOpen, EnumNameType.Both),
            ("MOC", OrderType.MarketOnClose, EnumNameType.Both),
            ("LOO", OrderType.LimitOnOpen, EnumNameType.Both),
            ("LOC", OrderType.LimitOnClose, EnumNameType.Both),
            ("PEGPRI", OrderType.PeggedToPrimary, EnumNameType.Both),
            ("VOL", OrderType.Vol, EnumNameType.Both),
            ("PEG BENCH", OrderType.PeggedToBenchmark, EnumNameType.Both)
        })

    Public Shared SecurityTypes As New ExtendedEnum(Of System.Enum, SecurityType)(
        {
            ("Bond", SecurityType.Bond, EnumNameType.External),
            ("BOND", SecurityType.Bond, EnumNameType.Internal),
            ("Cash", SecurityType.Cash, EnumNameType.External),
            ("CASH", SecurityType.Cash, EnumNameType.Internal),
            ("Combo", SecurityType.Combo, EnumNameType.External),
            ("Cmb", SecurityType.Combo, EnumNameType.Alias),
            ("BAG", SecurityType.Combo, EnumNameType.Internal),
            ("Commodity", SecurityType.Commodity, EnumNameType.External),
            ("CMDTY", SecurityType.Commodity, EnumNameType.Internal),
            ("Continuous Future", SecurityType.ContinuousFuture, EnumNameType.External),
            ("Cont Future", SecurityType.ContinuousFuture, EnumNameType.Alias),
            ("CONTFUT", SecurityType.ContinuousFuture, EnumNameType.Internal),
            ("Fund", SecurityType.Fund, EnumNameType.External),
            ("FUND", SecurityType.Fund, EnumNameType.Internal),
            ("Future", SecurityType.Future, EnumNameType.External),
            ("FUT", SecurityType.Future, EnumNameType.Internal),
            ("Futures Option", SecurityType.FuturesOption, EnumNameType.External),
            ("FOP", SecurityType.FuturesOption, EnumNameType.Internal),
            ("Index", SecurityType.Index, EnumNameType.External),
            ("IND", SecurityType.Index, EnumNameType.Internal),
            ("News", SecurityType.News, EnumNameType.External),
            ("NEWS", SecurityType.News, EnumNameType.Internal),
            ("", SecurityType.None, EnumNameType.Internal),
            ("*None*", SecurityType.None, EnumNameType.External),
            ("Option", SecurityType.Option, EnumNameType.External),
            ("OPT", SecurityType.Option, EnumNameType.Internal),
            ("Stock", SecurityType.Stock, EnumNameType.External),
            ("STK", SecurityType.Stock, EnumNameType.Internal),
            ("Warrant", SecurityType.Warrant, EnumNameType.External),
            ("WAR", SecurityType.Warrant, EnumNameType.Internal),
            ("Warr", SecurityType.Warrant, EnumNameType.Alias),
            ("CFD", SecurityType.ContractForDifference, EnumNameType.Internal),
            ("Cfd", SecurityType.ContractForDifference, EnumNameType.External),
            ("Contract for Difference", SecurityType.ContractForDifference, EnumNameType.Alias)
        })

    Public Shared ShortSaleSlotCodes As New ExtendedEnum(Of System.Enum, ShortSaleSlotCode)(
        {
            ("", ShortSaleSlotCode.NotApplicable, EnumNameType.Internal),
            ("N/A", ShortSaleSlotCode.NotApplicable, EnumNameType.External),
            ("Not applicable", ShortSaleSlotCode.NotApplicable, EnumNameType.Alias),
            ("1", ShortSaleSlotCode.ClearingBroker, EnumNameType.Internal),
            ("B", ShortSaleSlotCode.ClearingBroker, EnumNameType.Alias),
            ("BROKER", ShortSaleSlotCode.ClearingBroker, EnumNameType.External),
            ("2", ShortSaleSlotCode.ThirdParty, EnumNameType.Internal),
            ("T", ShortSaleSlotCode.ThirdParty, EnumNameType.Alias),
            ("TP", ShortSaleSlotCode.ThirdParty, EnumNameType.External),
            ("THIRD PARTY", ShortSaleSlotCode.ThirdParty, EnumNameType.Alias)
        })

    Public Shared TickByTickDataTypes As New ExtendedEnum(Of System.Enum, TickByTickDataType)(
        {
        ("", TickByTickDataType.None, EnumNameType.Both),
        ("Last", TickByTickDataType.Last, EnumNameType.Both),
        ("All Last", TickByTickDataType.AllLast, EnumNameType.External),
        ("AllLast", TickByTickDataType.AllLast, EnumNameType.Internal),
        ("Bid/Ask", TickByTickDataType.BidAsk, EnumNameType.External),
        ("BidAsk", TickByTickDataType.BidAsk, EnumNameType.Internal),
        ("MidPoint", TickByTickDataType.MidPoint, EnumNameType.Both),
        ("Midpoint", TickByTickDataType.MidPoint, EnumNameType.Alias)
        })

    Public Shared TriggerMethods As New ExtendedEnum(Of System.Enum, TriggerMethod)(
        {
        ("Default", TriggerMethod.Default, EnumNameType.Both),
        ("Double Bid/Ask", TriggerMethod.DoubleBidAsk, EnumNameType.Both),
        ("Last", TriggerMethod.Last, EnumNameType.Both),
        ("Double Last", TriggerMethod.DoubleLast, EnumNameType.Both),
        ("Bid/Ask", TriggerMethod.BidAsk, EnumNameType.Both),
        ("Last Or Bid/Ask", TriggerMethod.LastOrBidAsk, EnumNameType.Both),
        ("Midpoint", TriggerMethod.MidPoint, EnumNameType.Both)
        })

#End Region

#Region "Shared variables"

    Private Shared _EventLogger As ILogger = New NullLogger
    Private Shared _PerformanceLogger As ILogger = New NullLogger
    Private Shared _SocketLogger As ILogger = New NullLogger

#End Region

#Region "Member variables"

    Private ReadOnly mServer As String
    Private ReadOnly mPort As Integer

    Private ReadOnly mUseSSL As Boolean
    Private ReadOnly mUseV100Plus As Boolean

    Private mCallbackHandler As CallbackHandler

    Private mIdManager As IdManager

    Private mCancellationSource As CancellationTokenSource
    Friend Property Scheduler As TaskScheduler
    Private mSyncContext As SynchronizationContext

    Private mConnectionManager As ApiConnectionManager

    Private ReadOnly mEventConsumers As New ApiEventConsumers

    Private ReadOnly mRegistry As New GeneratorAndParserRegistry

    Private ReadOnly mInMessageHandler As InputMessageHandler

    Private ReadOnly mStatsRecorder As PerformanceStatsRecorder = New PerformanceStatsRecorder(mEventConsumers)

#End Region

#Region "Constructor"

    ''' <summary>
    ''' Creates a new IBAPI instance.
    ''' </summary>
    ''' 
    ''' <param name="server">The name or IP address of the computer in which TWS or Gateway is running. For the 
    ''' local computer, supply an empty string or use "127.0.0.1".
    ''' </param>
    ''' 
    ''' <param name="port">
    ''' The TCP port on which TWS or Gateway listens for API connections.
    ''' </param>
    ''' 
    ''' <param name="clientId">
    ''' A non-negative number that distinguishes this API connection from other 
    ''' connections to the same TWS or Gateway instance.
    ''' </param>
    ''' 
    ''' <param name="disableEventSource">
    ''' If <c>False</c> an <c>EventSource</c> object is automatically created to
    ''' receive API callbacks and raise corresponding events, and can be accessed via the <c>CallbackHandler</c> 
    ''' property. If <c>True</c>, the application must register its own object(s) to receive API callbacks.
    ''' </param>
    ''' 
    ''' <param name="syncContext">
    ''' Specifies the <c>SynchronizationContext</c> to which API callbacks are posted.
    ''' By default, the synchronization context for the current thread is used.
    ''' </param>
    ''' 
    ''' <param name="useSSL">
    ''' If <c>True</c>, the API connection is protected using SSL.
    ''' </param>
    ''' 
    ''' <param name="useLegacyProtocol">
    ''' If <c>True</c>, use the old API protocol to TWS. There is no practical 
    ''' benefit in doing this.
    ''' </param>
    ''' 
    Public Sub New(server As String,
                   port As Integer,
                   clientId As Integer,
                   Optional disableEventSource As Boolean = False,
                   Optional syncContext As SynchronizationContext = Nothing,
                   Optional useSSL As Boolean = False,
                   Optional useLegacyProtocol As Boolean = False,
                   Optional generateSocketDataEvents As Boolean = False)

        If Not (port > 0) Then Throw New ArgumentException("Port must be > 0")
        If Not (clientId >= 0) Then Throw New ArgumentException("ClientID must be >= 0")
        If String.IsNullOrEmpty(server) Then server = "127.0.0.1"

        mServer = server
        mPort = port
        Me.ClientID = clientId

        If Not disableEventSource Then mCallbackHandler = registerCallbackHandler(New EventSource())
        Me.SyncContext = syncContext
        mUseSSL = useSSL
        mUseV100Plus = Not useLegacyProtocol

        mEventConsumers.NotifyOpenOrderAction = Sub(e)
                                                    Dim order = e.Order
                                                    If order.OrderId > mIdManager.NextOrderId Then
                                                        ' this can happen when RequestAllOpenOrders has been called, or if this is
                                                        ' the master client. For some absurd reason, IB insists that orders placed
                                                        ' with this client must now have higher orderIDs than all other orders placed 
                                                        ' by ALL clients!
                                                        Dim id = mIdManager.NextOrderId
                                                        mIdManager.NextOrderId = order.OrderId + 1
                                                        IBAPI.EventLogger.Log($"NextOrderId was {id}, now increased to {mIdManager.NextOrderId}")
                                                    End If
                                                End Sub

        generateSocketDataEvents = If(SocketLogger?.IsLoggable(ILogger.LogLevel.Detail), True, generateSocketDataEvents)

        mCancellationSource = New CancellationTokenSource()
        mConnectionManager = New ApiConnectionManager(mServer, mPort, Me.ClientID, mUseV100Plus, useSSL, mCancellationSource, mRegistry, mEventConsumers, generateSocketDataEvents)
        mInMessageHandler = New InputMessageHandler(mEventConsumers, mRegistry, generateSocketDataEvents)

        mInMessageHandler.Initialise(mConnectionManager.Reader, mStatsRecorder)
        mInMessageHandler.Reset()

        mIdManager = New IdManager
        mRegistry.Initialise(mIdManager,
                             mEventConsumers,
                             mConnectionManager.Reader,
                             AddressOf mInMessageHandler.LogSocketInputMessage,
                             Function()
                                 Return mConnectionManager.ServerVersion
                             End Function,
                             Function()
                                 Return mConnectionManager.CreateMessageGenerator
                             End Function,
                             Function()
                                 Return mConnectionManager.ConnectionState
                             End Function)
        registerGenerators()
        registerParsers()
    End Sub

#End Region

#Region "IDisposable"

    Protected Overridable Sub Dispose(disposing As Boolean)
        Static disposed As Boolean
        If disposed Then Exit Sub
        disposed = True

        If disposing Then mCallbackHandler?.Dispose()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub

#End Region

#Region "Shared Properties"

    Public Shared Property EventLogger As ILogger
        Friend Get
            Return _EventLogger
        End Get
        Set
            _EventLogger = If(Value, New NullLogger)
        End Set
    End Property

    Public Shared Property PerformanceLogger As ILogger
        Friend Get
            Return _PerformanceLogger
        End Get
        Set
            _PerformanceLogger = If(Value, New NullLogger)
        End Set
    End Property

    Public Shared Property SocketLogger As ILogger
        Friend Get
            Return _SocketLogger
        End Get
        Set
            _SocketLogger = If(Value, New NullLogger)
        End Set
    End Property

#End Region

#Region "Properties"

    Public Property AccountDataConsumer() As IAccountDataConsumer
        Get
            Return mEventConsumers.AccountDataConsumer
        End Get
        Set(Value As IAccountDataConsumer)
            mEventConsumers.AccountDataConsumer = Value
        End Set
    End Property

    Public ReadOnly Property ClientID() As Integer


    Public Property ConnectionRetryIntervalSecs() As Integer
        Get
            ConnectionRetryIntervalSecs = mConnectionManager.ConnectionRetryIntervalSecs
        End Get
        Set(Value As Integer)
            If Value < 0 Then Throw New ArgumentException("Value cannot be negative")
            mConnectionManager.ConnectionRetryIntervalSecs = Value
        End Set
    End Property

    Public ReadOnly Property ConnectionState() As ApiConnectionState
        Get
            Return mConnectionManager.ConnectionState
        End Get
    End Property

    Public Property ConnectionStatusConsumer() As IConnectionStatusConsumer
        Get
            Return mEventConsumers.ConnectionStatusConsumer
        End Get
        Set(Value As IConnectionStatusConsumer)
            mEventConsumers.ConnectionStatusConsumer = Value
        End Set
    End Property

    Public Property CallbackHandler As CallbackHandler
        Get
            Return mCallbackHandler
        End Get
        Set
            mCallbackHandler = registerCallbackHandler(Value)
        End Set
    End Property

    Public ReadOnly Property EventSource As EventSource
        Get
            If Not TypeOf mCallbackHandler Is EventSource Then
                Throw New ArgumentException("The currently registered CallbackHandler is not of type EventSource)")
            End If
            Return DirectCast(mCallbackHandler, EventSource)
        End Get
    End Property

    Public Property FundamentalDataConsumer() As IFundamentalDataConsumer
        Get
            Return mEventConsumers.FundamentalDataConsumer
        End Get
        Set
            mEventConsumers.FundamentalDataConsumer = Value
        End Set
    End Property

    Public Property ContractDetailsConsumer() As IContractDetailsConsumer
        Get
            Return mEventConsumers.ContractDetailsConsumer
        End Get
        Set(Value As IContractDetailsConsumer)
            mEventConsumers.ContractDetailsConsumer = Value
        End Set
    End Property


    Public Property ErrorAndNotificationConsumer() As IErrorAndNotificationConsumer
        Get
            Return mEventConsumers.ErrorAndNotificationConsumer
        End Get
        Set(Value As IErrorAndNotificationConsumer)
            mEventConsumers.ErrorAndNotificationConsumer = Value
        End Set
    End Property

    Public Property HistDataConsumer() As IHistoricalDataConsumer
        Get
            Return mEventConsumers.HistoricalDataConsumer
        End Get
        Set(Value As IHistoricalDataConsumer)
            mEventConsumers.HistoricalDataConsumer = Value
        End Set
    End Property

    Public Property MarketDataConsumer() As IMarketDataConsumer
        Get
            Return mEventConsumers.MarketDataConsumer
        End Get
        Set(Value As IMarketDataConsumer)
            mEventConsumers.MarketDataConsumer = Value
        End Set
    End Property

    Public Property MarketDepthConsumer() As IMarketDepthConsumer
        Get
            Return mEventConsumers.MarketDepthConsumer
        End Get
        Set(Value As IMarketDepthConsumer)
            mEventConsumers.MarketDepthConsumer = Value
        End Set
    End Property

    Public ReadOnly Property MaxOrderId() As Integer
        Get
            MaxOrderId = &H7FFFFFFF
        End Get
    End Property

    Public Property NextOrderId() As Integer
        Get
            NextOrderId = mIdManager.NextOrderId
        End Get
        Set(value As Integer)
            mIdManager.NextOrderId = value
        End Set
    End Property

    Public Property NewsConsumer() As INewsConsumer
        Get
            Return mEventConsumers.NewsConsumer
        End Get
        Set
            mEventConsumers.NewsConsumer = Value
        End Set
    End Property

    Public Property OrderInfoConsumer() As IOrderInfoConsumer
        Get
            Return mEventConsumers.OrderInfoConsumer
        End Get
        Set(Value As IOrderInfoConsumer)
            mEventConsumers.OrderInfoConsumer = Value
        End Set
    End Property

    Public Property PerformanceDataConsumer() As IPerformanceDataConsumer
        Get
            Return mEventConsumers.PerformanceDataConsumer
        End Get
        Set
            mEventConsumers.PerformanceDataConsumer = Value
        End Set
    End Property

    Public ReadOnly Property Port() As Integer
        Get
            Port = mPort
        End Get
    End Property

    Public Property ScannerDataConsumer() As IScannerDataConsumer
        Get
            Return mEventConsumers.ScannerDataConsumer
        End Get
        Set
            mEventConsumers.ScannerDataConsumer = Value
        End Set
    End Property

    Public Property SocketDataConsumer() As ISocketDataConsumer
        Get
            Return mEventConsumers.SocketDataConsumer
        End Get
        Set
            mEventConsumers.SocketDataConsumer = Value
        End Set
    End Property

    Public ReadOnly Property Server() As String
        Get
            Server = mServer
        End Get
    End Property

    Public ReadOnly Property ServerVersion() As Integer
        Get
            ServerVersion = mConnectionManager.ServerVersion
        End Get
    End Property

    Public Property SyncContext As SynchronizationContext
        Get
            Return mSyncContext
        End Get
        Set
            If Scheduler IsNot Nothing Then Throw New InvalidOperationException($"SyncContext cannot be set after {NameOf(Connect)} has been called")
            If Value IsNot Nothing Then
                mSyncContext = Value
                SynchronizationContext.SetSynchronizationContext(mSyncContext)
            ElseIf SynchronizationContext.Current Is Nothing Then
                mSyncContext = New SynchronizationContext()
                SynchronizationContext.SetSynchronizationContext(mSyncContext)
            Else
                mSyncContext = SynchronizationContext.Current
            End If

            Scheduler = TaskScheduler.FromCurrentSynchronizationContext()
        End Set
    End Property

#End Region

#Region "Shared Methods"

    Friend Shared Function FormatBuffer(pBuffer As String, pBufferNextFreeIndex As Integer) As String
        Dim s = New Text.StringBuilder

        Dim i = 0
        Do While i < pBufferNextFreeIndex
            s.Append($"{i,-6:0000}")
            s.Append(pBuffer.Substring(i, System.Math.Min(50, pBuffer.Length - i)))
            i = i + 50
            If i < pBufferNextFreeIndex Then s.AppendLine("")
        Loop
        Return s.ToString
    End Function

    Public Shared Function IsContractExpirable(pContract As Contract) As Boolean
        Select Case pContract.SecType
            Case SecurityType.Option,
                    SecurityType.FuturesOption,
                    SecurityType.Warrant,
                    SecurityType.Bond,
                    SecurityType.Commodity
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Shared Function IsContractExpired(pContract As Contract) As Boolean
        If Not IsContractExpirable(pContract) Then Return False
        Return contractExpiryToDate(pContract) < Date.Now
    End Function

    Public Shared Function NullableDoubleFromString(val As String) As Double?
        Dim result As Double?
        If Not String.IsNullOrWhiteSpace(val) Then result = CDbl(val)
        Return result
    End Function

    Public Shared Function NullableIntegerFromString(val As String) As Integer?
        Dim result As Integer?
        If Not String.IsNullOrWhiteSpace(val) Then result = CInt(val)
        Return result
    End Function

    Public Shared Function NullableToString(Of T As Structure)(val As T?) As String
        Return NullableToString(val, "")
    End Function

    Public Shared Function NullableToString(Of T As Structure)(val As T?, defaultValue As String) As String
        Return If(val.HasValue, val.Value.ToString(), defaultValue)
    End Function

    Public Shared Function TwsDateStringToDate(pDateString As String) As (theDate As Date, timezoneName As String)
        ' format is yyyymmdd [hh:mm:ss  [timezone]]
        If String.IsNullOrEmpty(pDateString) Then Return (Date.MaxValue, String.Empty)

        Dim d As Date
        If pDateString.Length = 8 Then
            d = DateTime.ParseExact(pDateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
        ElseIf pDateString.Length > 17 Then
            d = DateTime.ParseExact(pDateString.Substring(0, 18), "yyyyMMdd  HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
        Else
            Throw New ArgumentException("Invalid date string format")
        End If

        Dim lTimezoneName As String
        If pDateString.Length > 17 Then
            lTimezoneName = pDateString.Substring(17, pDateString.Length - 18).Trim()
        Else
            lTimezoneName = ""
        End If

        Return (d, lTimezoneName)
    End Function

    Friend Shared Function UnixTimestampToDateTime(unixTimestamp As Long) As DateTime
        Dim unixBaseTime = New DateTime(1970, 1, 1, 0, 0, 0, 0)
        Return unixBaseTime.AddSeconds(unixTimestamp)
    End Function

#End Region

#Region "Methods"

    Public Sub CalculateImpliedVolatility(pReqId As Integer, pContract As Contract, pOptionPrice As Double, pUnderPrice As Double, Optional pOptions As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CalculateImpliedVolatility, {pReqId, pContract, pOptionPrice, pUnderPrice, pOptions})
    End Sub

    Public Sub CalculateOptionPrice(pReqId As Integer, pContract As Contract, pVolatility As Double, pUnderPrice As Double, Optional pOptions As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CalculateOptionPrice, {pReqId, pContract, pVolatility, pUnderPrice, pOptions})
    End Sub

    Public Sub CancelAccountSummary(pReqId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelAccountSummary, {pReqId})
    End Sub

    Public Sub CancelAccountUpdatesMulti(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelAccountUpdatesMulti, {requestId})
    End Sub

    Public Sub CancelCalculateImpliedVolatility(pReqId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelCalculateImpliedVolatility, {pReqId})
    End Sub

    Public Sub CancelCalculateOptionPrice(pReqId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelCalculateOptionPrice, {pReqId})
    End Sub

    Public Sub CancelPnL(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelPnL, {requestId})
    End Sub

    Sub CancelPnLSingle(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelPnLSingle, {requestId})
    End Sub

    Public Sub CancelFundamentalData(pReqId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelFundamentalData, {pReqId})
    End Sub

    Public Sub CancelHeadTimestamp(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelHeadTimestamp, {requestId})
    End Sub

    Public Sub CancelHistogramData(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelHistogramData, {requestId})
    End Sub

    Public Sub CancelHistoricalData(pRequestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelHistoricalData, {pRequestId})
    End Sub

    Public Sub CancelMarketData(pTickerId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelMarketData, {pTickerId})
    End Sub

    Public Sub CancelMarketDepth(pTickerId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelMarketDepth, {pTickerId})
    End Sub

    Public Sub CancelNewsBulletins()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelNewsBulletins, Nothing)
    End Sub

    Public Sub CancelOrder(pOrderId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelOrder, {pOrderId})
    End Sub

    Public Sub CancelPositions()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelPositions, Nothing)
    End Sub

    Public Sub CancelPositionsMulti(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelPositionsMulti, {requestId})
    End Sub

    Public Sub CancelRealtimeBars(pTickerId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelRealtimeBars, {pTickerId})
    End Sub

    Public Sub CancelScannerSubscription(pTickerId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelScannerSubscription, {pTickerId})
    End Sub

    Public Sub CancelTickByTickData(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelTickByTickData, {requestId})
    End Sub


    Public Sub Connect(Optional useSSL As Boolean = False)
        mConnectionManager.Connect(AddressOf startInputMessageHandler)
    End Sub

    Public Sub Disconnect(pReason As String)
        mCancellationSource.Cancel()
        mConnectionManager.Disconnect(pReason)

        mStatsRecorder?.StopRecording()
    End Sub

    Public Sub ExerciseOptions(pTickerId As Integer, pContract As Contract, pExerciseAction As ExerciseAction, pExerciseQuantity As Integer, pAccount As String, pOverride As Boolean)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.ExerciseOptions, {pTickerId, pContract, pExerciseAction, pExerciseQuantity, pAccount, pOverride})
    End Sub

    Public Sub PlaceOrder(pOrder As Order, pContract As Contract, pTransmit As Boolean)
        PlaceOrder(pOrder, pContract, pTransmit, "", "")
    End Sub

    Public Sub PlaceOrder(pOrder As Order, pContract As Contract, pTransmit As Boolean, pSecIdType As String, pSecId As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.PlaceOrder, {pOrder, pContract, pTransmit, pSecIdType, pSecId})
    End Sub

    Public Sub QueryDisplayGroups(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.QueryDisplayGroups, {requestId})
    End Sub

    Public Sub ReplaceFA(dataType As FinancialAdvisorDataType, xml As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.ReplaceFinancialAdvisorData, {dataType, xml})
    End Sub

    Public Sub RequestAccountData(subscribe As Boolean, acctCode As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestAccountData, {subscribe, acctCode})
    End Sub

    Sub RequestAccountDataMulti(requestId As Integer, account As String, modelCode As String, ledgerAndNLV As Boolean)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestAccountDataMulti, {requestId, account, modelCode, ledgerAndNLV})
    End Sub

    Public Sub RequestAccountSummary(pReqId As Integer, pGroup As String, pTags As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestAccountSummary, {pReqId, pGroup, pTags})
    End Sub

    Public Sub RequestAllOpenOrders()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestAllOpenOrders, Nothing)
    End Sub

    Public Sub RequestAutoOpenOrders(autoBind As Boolean)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestAutoOpenOrders, {autoBind})
    End Sub

    Public Sub RequestContractData(pRequestId As Integer, pContract As Contract)
        RequestContractData(pRequestId, pContract, False)
    End Sub

    Public Sub RequestContractData(pRequestId As Integer, pContract As Contract, pIncludeExpired As Boolean)
        RequestContractData(pRequestId, pContract, pIncludeExpired, "", "")
    End Sub

    Public Sub RequestContractData(pRequestId As Integer, pContract As Contract, pSecIdType As String, pSecId As String)
        RequestContractData(pRequestId, pContract, False, pSecIdType, pSecId)
    End Sub

    Public Sub RequestContractData(pRequestId As Integer, pContract As Contract, pIncludeExpired As Boolean, pSecIdType As String, pSecId As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestContractData, {pRequestId, pContract, pIncludeExpired, pSecIdType, pSecId})
    End Sub

    Public Sub RequestCurrentTime()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestCurrentTime, Nothing)
    End Sub

    Public Sub RequestExecutions(pRequestId As Integer, filter As ExecutionFilter)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestExecutions, {pRequestId, filter})
    End Sub

    Public Sub RequestFamilyCodes()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestFamilyCodes, Nothing)
    End Sub

    Public Sub RequestFinancialAdvisorData(DataType As FinancialAdvisorDataType)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestFinancialAdvisorData, {DataType})
    End Sub

    Public Sub RequestFundamentalData(pReqId As Integer, pContract As Contract, pReportType As String, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestFundamentalData, {pReqId, pContract, pReportType, options})
    End Sub

    Public Sub RequestGlobalCancel()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestGlobalCancel, Nothing)
    End Sub

    Public Sub RequestHeadTimestamp(requestId As Integer, contract As Contract, whatToShow As String, Optional useRTH As Boolean = False)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestHeadTimestamp, {requestId, contract, whatToShow, useRTH})
    End Sub

    Public Sub RequestHistogramData(requestId As Integer, contract As Contract, period As String, Optional useRTH As Boolean = False)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestHistogramData, {requestId, contract, useRTH, period})
    End Sub

    Public Sub RequestHistoricalBars(pRequestId As Integer, pRequest As HistoricalBarsRequest, Optional useRTH As Boolean = False, Optional keepUpToDate As Boolean = False, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestHistoricalBars, {pRequestId, pRequest, useRTH, keepUpToDate, options})
    End Sub

    Public Sub RequestHistoricalNews(requestId As Integer, conid As Integer, providerCodes As String, startTime As Date, endTime As Date, maxResults As Integer, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestHistoricalNews, {requestId, conid, providerCodes, startTime, endTime, maxResults, options})
    End Sub

    ''' <summary>
    ''' Requests historical time-and-sales data for an instrument
    ''' </summary>
    ''' <param name="requestId">Identifies this request</param>
    ''' <param name="request">A <c>HistoricalTicksRequest</c> object that specifies the information required</param>
    ''' <param name="useRTH">If <c>True</c> only data within regular trading hours is returned</param>
    ''' <param name="ignoreSize">A filter only used when the source price is Bid_Ask</param>
    ''' <param name="options">Reserved for internal use</param>
    Public Sub RequestHistoricalTickData(requestId As Integer, request As HistoricalTicksRequest, Optional useRTH As Boolean = False, Optional ignoreSize As Boolean = False, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestHistoricalTickData, {requestId, request, useRTH, ignoreSize, options})
    End Sub

    Public Sub RequestManagedAccounts()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestManagedAccounts, Nothing)
    End Sub

    Public Sub RequestMarketData(pTickerId As Integer, pContract As Contract, Optional pGenericTicks As String = "", Optional pSnapshot As Boolean = False, Optional pRegulatorySnapshot As Boolean = False, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestMarketData, {pTickerId, pContract, pGenericTicks, pSnapshot, pRegulatorySnapshot, options})
    End Sub

    Public Sub RequestMarketDataType(pMarketDataType As MarketDataType)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestMarketDataType, {pMarketDataType})
    End Sub

    Public Sub RequestMarketDepth(pTickerId As Integer, pContract As Contract, Optional pNumberOfRows As Integer = 20, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestMarketDepth, {pTickerId, pContract, pNumberOfRows, options})
    End Sub

    Public Sub RequestMarketDepthExchanges()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestMarketDepthExchanges, Nothing)
    End Sub

    Public Sub RequestMarketRule(marketRuleId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestMarketRule, {marketRuleId})
    End Sub

    Public Sub RequestMatchingSymbols(requestId As Integer, pattern As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestMatchingSymbols, {requestId, pattern})
    End Sub

    Public Sub RequestNewsArticle(requestId As Integer, providerCode As String, articleId As String, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestNewsArticle, {requestId, providerCode, articleId, options})
    End Sub

    Public Sub RequestNewsBulletins(allMsgs As Boolean)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestNewsBulletins, {allMsgs})
    End Sub

    Public Sub RequestNewsProviders()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestNewsProviders, Nothing)
    End Sub

    Public Sub RequestOpenOrders()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestOpenOrders, Nothing)
    End Sub

    Public Sub RequestPnL(requestId As Integer, account As String, modelCode As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestPnL, {requestId, account, modelCode})
    End Sub

    Public Sub RequestPnLSingle(requestId As Integer, account As String, modelCode As String, conId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestPnLSingle, {requestId, account, modelCode, conId})
    End Sub

    Public Sub RequestPositions()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestPositions, Nothing)
    End Sub

    Public Sub RequestPositionsMulti(requestId As Integer, account As String, modelCode As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestPositionsMulti, {requestId, account, modelCode})
    End Sub

    Public Sub RequestRealtimeBars(pTickerId As Integer, pContract As Contract, pBarSize As Integer, Optional pWhatToShow As String = "TRADES", Optional pUseRTH As Boolean = False, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestRealtimeBars, {pTickerId, pContract, pBarSize, pWhatToShow, pUseRTH, options})
    End Sub

    Public Sub RequestScannerParameters()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestScannerParameters, Nothing)
    End Sub

    Public Sub RequestScannerSubscription(requestId As Integer, pSubscription As ScannerSubscription, Optional options As List(Of TagValue) = Nothing, Optional filterOptions As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestScannerSubscription, {requestId, pSubscription, options, filterOptions})
    End Sub

    Public Sub RequestSecurityDefinitionOptionParams(requestId As Integer, underlyingSymbol As String, exchange As String, underlyingSecType As SecurityType, underlyingConId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestSecurityDefinitionOptionParameters, {requestId, underlyingSymbol, exchange, underlyingSecType, underlyingConId})
    End Sub

    Public Sub RequestSmartComponents(requestId As Integer, bboExchange As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestSmartComponents, {requestId, bboExchange})
    End Sub

    Public Sub RequestSoftDollarTiers(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestSoftDollarTiers, {requestId})
    End Sub

    Public Sub RequestTickByTickData(requestId As Integer, contract As Contract, tickType As TickByTickDataType, numberOfTicks As Integer, ignoreSize As Boolean)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestTickByTickData, {requestId, contract, tickType, numberOfTicks, ignoreSize})
    End Sub

    Public Sub SetLogLevel(pLogLevel As ApiLogLevel)
        mConnectionManager.SetLogLevel(pLogLevel)
    End Sub

    Public Sub SubscribeToGroupEvents(requestId As Integer, groupId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.SubscribeToGroupEvents, {requestId, groupId})
    End Sub

    Public Sub UnsubscribeFromGroupEvents(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.UnsubscribeFromGroupEvents, {requestId})
    End Sub

    Public Sub UpdateDisplayGroup(requestId As Integer, contractInfo As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.UpdateDisplayGroup, {requestId, contractInfo})
    End Sub

#End Region

#Region "Helper Functions"

    Private Shared Function contractExpiryToDate(pContract As Contract) As Date
        Dim expiry = pContract.Expiry.Trim
        Dim len = pContract.Expiry.Length
        If len = 8 Then Return CDate($"{pContract.Expiry.Substring(0, 4)}/{pContract.Expiry.Substring(4, 2)}/{pContract.Expiry.Substring(len - 1, 2)}")
        If len = 6 Then Return CDate($"{pContract.Expiry.Substring(0, 4)}/{pContract.Expiry.Substring(4, 2)}/01")
        Throw New InvalidOperationException
    End Function

    Private Sub registerGenerators()
        Dim generators = From t In Assembly.GetCallingAssembly().GetTypes()
                         Where t.GetInterfaces().Contains(GetType(IGenerator)) And Not t.IsAbstract
                         Select DirectCast(Activator.CreateInstance(t), IGenerator)

        Try
            For Each p In generators
                p.SetRegistry(mRegistry)
            Next
        Catch e As Exception
            IBAPI.EventLogger.Log($"Failed loading generators: {e.ToString}")
            Throw
        End Try
    End Sub

    Private Sub registerParsers()
        Dim parsers = From t In Assembly.GetCallingAssembly().GetTypes()
                      Where t.GetInterfaces().Contains(GetType(IParser)) And Not t.IsAbstract
                      Select DirectCast(Activator.CreateInstance(t), IParser)

        Try
            For Each p In parsers
                p.SetRegistry(mRegistry)
            Next
        Catch e As Exception
            IBAPI.EventLogger.Log($"Failed loading parsers: {e.ToString}")
            Throw
        End Try
    End Sub

    Private Sub startInputMessageHandler()
        mInMessageHandler.Start(mConnectionManager.ServerVersion,
                                Scheduler,
                                mCancellationSource,
                                Sub() mConnectionManager.Disconnect("Message processing completed"))
    End Sub

    Private Function registerCallbackHandler(handler As CallbackHandler) As CallbackHandler
        Me.AccountDataConsumer = handler
        Me.ConnectionStatusConsumer = handler
        Me.ContractDetailsConsumer = handler
        Me.ErrorAndNotificationConsumer = handler
        Me.FundamentalDataConsumer = handler
        Me.HistDataConsumer = handler
        Me.MarketDataConsumer = handler
        Me.MarketDepthConsumer = handler
        Me.NewsConsumer = handler
        Me.OrderInfoConsumer = handler
        Me.PerformanceDataConsumer = handler
        Me.ScannerDataConsumer = handler
        Me.SocketDataConsumer = handler
        Return handler
    End Function

#End Region

End Class