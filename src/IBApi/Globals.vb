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

Public Module Globals

    '================================================================================
    ' Constants
    '================================================================================

    '================================================================================
    ' Enums
    '================================================================================

    '================================================================================
    ' Types
    '================================================================================

    '================================================================================
    ' Private fields
    '================================================================================

    Friend EventLogger As ILogger
    Friend SocketLogger As ILogger

    '================================================================================
    ' Public fields
    '================================================================================

    Friend ApiSocketInMsgTypes As New ExtendedEnum(Of System.Enum, ApiSocketInMsgType)(
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
            ("HistoricalData", ApiSocketInMsgType.HistoricalData, EnumNameType.Both),
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
            ("DeltaNeutralValidn", ApiSocketInMsgType.DeltaNeutralValidation, EnumNameType.Both),
            ("TickSnapshotEnd", ApiSocketInMsgType.TickSnapshotEnd, EnumNameType.Both),
            ("MarketDataType", ApiSocketInMsgType.MarketDataType, EnumNameType.Both),
            ("CommissionReport", ApiSocketInMsgType.CommissionReport, EnumNameType.Both),
            ("Position", ApiSocketInMsgType.Position, EnumNameType.Both),
            ("PositionEnd", ApiSocketInMsgType.PositionEnd, EnumNameType.Both),
            ("Accountsummary", ApiSocketInMsgType.AccountSummary, EnumNameType.Both),
            ("Accountsummaryend", ApiSocketInMsgType.AccountSummaryEnd, EnumNameType.Both),
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
            ("DailyPnL", ApiSocketInMsgType.DailyPnL, EnumNameType.Both),
            ("DailyPnLSingle", ApiSocketInMsgType.DailyPnLSingle, EnumNameType.Both)
        })

    Friend ApiSocketOutMsgTypes As New ExtendedEnum(Of System.Enum, ApiSocketOutMsgType)(
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
            ("REQ_HISTORICAL_DATA", ApiSocketOutMsgType.RequestHistoricalData, EnumNameType.Both),
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
            ("REQ_MKT_DEPTH_EXCHANGES", ApiSocketOutMsgType.RequestMarketDepthExchanges, EnumNameType.Both)
            })

    Public HedgeTypes As New ExtendedEnum(Of System.Enum, HedgeType)({
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

    Public OcaTypes As New ExtendedEnum(Of System.Enum, OcaType)({
            ("", OcaType.None, EnumNameType.None),
            ("*None*", OcaType.None, EnumNameType.External),
            ("CancelWithBlock", OcaType.CancelWithBlock, EnumNameType.Both),
            ("ReduceWithBlock", OcaType.ReduceWithBlock, EnumNameType.Both),
            ("ReduceNonBlock", OcaType.ReduceNonBlock, EnumNameType.Both)
        })

    Public OptionRights As New ExtendedEnum(Of System.Enum, OptionRight)({
            ("", OptionRight.None, EnumNameType.None),
            ("*None*", OptionRight.None, EnumNameType.External),
            ("?", OptionRight.None, EnumNameType.Internal),
            ("Call", OptionRight.Call, EnumNameType.External),
            ("C", OptionRight.Call, EnumNameType.Internal),
            ("Put", OptionRight.Put, EnumNameType.External),
            ("P", OptionRight.Put, EnumNameType.Internal)
    })

    Public OrderActions As New ExtendedEnum(Of System.Enum, OrderAction)(
        {
            ("Buy", OrderAction.Buy, EnumNameType.External),
            ("BUY", OrderAction.Buy, EnumNameType.Internal),
            ("Sell", OrderAction.Sell, EnumNameType.External),
            ("SELL", OrderAction.Sell, EnumNameType.Internal),
            ("Sell Short", OrderAction.SellShort, EnumNameType.External),
            ("SSHORT", OrderAction.SellShort, EnumNameType.Internal),
            ("", OrderAction.None, EnumNameType.Internal),
            ("*None*", OrderAction.None, EnumNameType.External)
        })

    Public OrderTIFs As New ExtendedEnum(Of System.Enum, OrderTimeInForce)(
        {
            ("", OrderTimeInForce.None, EnumNameType.Internal),
            ("*None*", OrderTimeInForce.None, EnumNameType.External),
            ("Day", OrderTimeInForce.Day, EnumNameType.External),
            ("DAY", OrderTimeInForce.Day, EnumNameType.Internal),
            ("Good Till Cancelled", OrderTimeInForce.GoodTillCancelled, EnumNameType.External),
            ("GTC", OrderTimeInForce.GoodTillCancelled, EnumNameType.Internal),
            ("Immediate or Cancel", OrderTimeInForce.ImmediateOrCancel, EnumNameType.External),
            ("IOC", OrderTimeInForce.ImmediateOrCancel, EnumNameType.Internal)
        })

    Public OrderTypes As New ExtendedEnum(Of System.Enum, OrderType)(
        {
            ("", OrderType.None, EnumNameType.Internal),
            ("None", OrderType.None, EnumNameType.None),
            ("*None*", OrderType.None, EnumNameType.External),
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

    Public SecurityTypes As New ExtendedEnum(Of System.Enum, SecurityType)(
        {
            ("Bond", SecurityType.Bond, EnumNameType.External),
            ("BOND", SecurityType.Bond, EnumNameType.Internal),
            ("Cash", SecurityType.Cash, EnumNameType.External),
            ("CASH", SecurityType.Cash, EnumNameType.Internal),
            ("Combo", SecurityType.Combo, EnumNameType.External),
            ("Cmb", SecurityType.Combo, EnumNameType.None),
            ("BAG", SecurityType.Combo, EnumNameType.Internal),
            ("Commodity", SecurityType.Commodity, EnumNameType.External),
            ("CMDTY", SecurityType.Commodity, EnumNameType.Internal),
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
            ("Warr", SecurityType.Warrant, EnumNameType.None)
        })

    Public ShortSaleSlotCodes As New ExtendedEnum(Of System.Enum, ShortSaleSlotCode)(
        {
            ("", ShortSaleSlotCode.NotApplicable, EnumNameType.Internal),
            ("N/A", ShortSaleSlotCode.NotApplicable, EnumNameType.External),
            ("Not applicable", ShortSaleSlotCode.NotApplicable, EnumNameType.None),
            ("1", ShortSaleSlotCode.ClearingBroker, EnumNameType.Internal),
            ("B", ShortSaleSlotCode.ClearingBroker, EnumNameType.None),
            ("BROKER", ShortSaleSlotCode.ClearingBroker, EnumNameType.External),
            ("2", ShortSaleSlotCode.ThirdParty, EnumNameType.Internal),
            ("T", ShortSaleSlotCode.ThirdParty, EnumNameType.None),
            ("TP", ShortSaleSlotCode.ThirdParty, EnumNameType.External),
            ("THIRD PARTY", ShortSaleSlotCode.ThirdParty, EnumNameType.None)
        })

    Public TriggerMethods As New ExtendedEnum(Of System.Enum, TriggerMethod)(
        {
        ("Default", TriggerMethod.Default, EnumNameType.Both),
        ("Double Bid/Ask", TriggerMethod.BidAsk, EnumNameType.Both),
        ("Last", TriggerMethod.Last, EnumNameType.Both),
        ("Double Last", TriggerMethod.DoubleLast, EnumNameType.Both),
        ("Bid/Ask", TriggerMethod.BidAsk, EnumNameType.Both),
        ("Last Or Bid/Ask", TriggerMethod.LastOrBidAsk, EnumNameType.Both),
        ("Midpoint", TriggerMethod.MidPoint, EnumNameType.Both)
        })

    '================================================================================
    ' Properties
    '================================================================================

    '================================================================================
    ' Methods
    '================================================================================

    Friend Function FormatBuffer(pBuffer As String, pBufferNextFreeIndex As Integer) As String
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

    Public Function NullableDoubleFromString(val As String) As Double?
        Dim result As Double?
        If Not String.IsNullOrWhiteSpace(val) Then result = CDbl(val)
        Return result
    End Function

    Public Function NullableDoubleToString(val As Double?) As String
        Return If(val.HasValue, val.ToString(), "")
    End Function

    Public Function NullableIntegerFromString(val As String) As Integer?
        Dim result As Integer?
        If Not String.IsNullOrWhiteSpace(val) Then result = CInt(val)
        Return result
    End Function

    Public Function NullableIntegerToString(val As Integer?) As String
        Return If(val.HasValue, val.ToString(), "")
    End Function

    Public Function TwsDateStringToDate(pDateString As String) As (theDate As Date, timezoneName As String)
        ' format is yyyymmdd [hh:mm:ss [timezone]]
        If String.IsNullOrEmpty(pDateString) Then Return (Date.MaxValue, String.Empty)

        Dim d As Date
        If Len(pDateString) = 8 Then
            d = DateTime.ParseExact(pDateString, "yyyyHHdd", System.Globalization.CultureInfo.InvariantCulture)
        ElseIf Len(pDateString) >= 17 Then
            d = DateTime.ParseExact(pDateString.Substring(0, 17), "yyyyHHdd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
        Else
            Throw New ArgumentException("Invalid date string format")
        End If

        Dim lTimezoneName As String
        If Len(pDateString) > 17 Then
            lTimezoneName = Trim(Right(pDateString, Len(pDateString) - 17))
        Else
            lTimezoneName = ""
        End If

        Return (d, lTimezoneName)
    End Function

    '================================================================================
    ' Helper Functions
    '================================================================================

End Module