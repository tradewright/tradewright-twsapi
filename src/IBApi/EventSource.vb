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

Imports TradeWright.IBAPI

Public Class EventSource
    Inherits CallbackHandler
    Implements IAccountDataConsumer,
        IConnectionStatusConsumer,
        IContractDetailsConsumer,
        IDisplayGroupConsumer,
        IErrorAndNotificationConsumer,
        IFundamentalDataConsumer,
        IHistoricalDataConsumer,
        IMarketDataConsumer,
        IMarketDepthConsumer,
        INewsConsumer,
        IOrderInfoConsumer,
        IPerformanceDataConsumer,
        IScannerDataConsumer,
        ISocketDataConsumer

#Region "IAccountDataConsumer"

    Public Overrides Sub EndAccountUpdateMulti(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndAccountUpdateMulti
        OnAccountUpdateMultiEnd(e)
    End Sub

    Public Event AccountUpdateMultiEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnAccountUpdateMultiEnd(e As RequestEndEventArgs)
        RaiseEvent AccountUpdateMultiEnd(Me, e)
    End Sub

    Public Overrides Sub EndPositionMulti(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndPositionMulti
        OnPositionMultiEnd(e)
    End Sub

    Public Event PositionMultiEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnPositionMultiEnd(e As RequestEndEventArgs)
        RaiseEvent PositionMultiEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyAccountUpdateMulti(e As AccountUpdateMultiEventArgs) Implements IAccountDataConsumer.NotifyAccountUpdateMulti
        OnAccountUpdateMulti(e)
    End Sub

    Public Event AccountUpdateMulti(sender As Object, e As AccountUpdateMultiEventArgs)
    Protected Overridable Sub OnAccountUpdateMulti(e As AccountUpdateMultiEventArgs)
        RaiseEvent AccountUpdateMulti(Me, e)
    End Sub

    Public Overrides Sub NotifyPnL(e As PnLEventArgs) Implements IAccountDataConsumer.NotifyPnL
        OnPnL(e)
    End Sub

    Public Event PnL(sender As Object, e As PnLEventArgs)
    Protected Overridable Sub OnPnL(e As PnLEventArgs)
        RaiseEvent PnL(Me, e)
    End Sub

    Public Overrides Sub NotifyPnLSingle(e As PnLSingleEventArgs) Implements IAccountDataConsumer.NotifyPnLSingle
        OnPnLSingle(e)
    End Sub

    Public Event PnLSingle(sender As Object, e As PnLSingleEventArgs)
    Protected Overridable Sub OnPnLSingle(e As PnLSingleEventArgs)
        RaiseEvent PnLSingle(Me, e)
    End Sub

    Public Overrides Sub NotifyFamilyCodes(e As FamilyCodesEventArgs) Implements IAccountDataConsumer.NotifyFamilyCodes
        OnFamilyCodes(e)
    End Sub

    Public Event FamilyCodes(sender As Object, e As FamilyCodesEventArgs)
    Protected Overridable Sub OnFamilyCodes(e As FamilyCodesEventArgs)
        RaiseEvent FamilyCodes(Me, e)
    End Sub

    Public Overrides Sub NotifyPositionMulti(e As PositionMultiEventArgs) Implements IAccountDataConsumer.NotifyPositionMulti
        OnPositionMulti(e)
    End Sub

    Public Event PositionMulti(sender As Object, e As PositionMultiEventArgs)
    Protected Overridable Sub OnPositionMulti(e As PositionMultiEventArgs)
        RaiseEvent PositionMulti(Me, e)
    End Sub

    Public Overrides Sub NotifySoftDollarTiers(e As SoftDollarTiersEventArgs) Implements IAccountDataConsumer.NotifySoftDollarTiers
        OnSoftDollarTiers(e)
    End Sub

    Public Event SoftDollarTiers(sender As Object, e As SoftDollarTiersEventArgs)
    Protected Overridable Sub OnSoftDollarTiers(e As SoftDollarTiersEventArgs)
        RaiseEvent SoftDollarTiers(Me, e)
    End Sub

    Public Overrides Sub EndAccountSummary(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndAccountSummary
        OnAccountSummaryEnd(e)
    End Sub

    Public Event AccountSummaryEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnAccountSummaryEnd(e As RequestEndEventArgs)
        RaiseEvent AccountSummaryEnd(Me, e)
    End Sub

    Public Overrides Sub EndAccountValue(e As AccountDownloadEndEventArgs) Implements IAccountDataConsumer.EndAccountValue
        OnAccountDownloadEnd(e)
    End Sub

    Public Event AccountDownloadEnd(sender As Object, e As AccountDownloadEndEventArgs)
    Protected Overridable Sub OnAccountDownloadEnd(e As AccountDownloadEndEventArgs)
        RaiseEvent AccountDownloadEnd(Me, e)
    End Sub

    Public Overrides Sub EndPosition(e As EventArgs) Implements IAccountDataConsumer.EndPosition
        OnPositionEnd(EventArgs.Empty)
    End Sub

    Public Event PositionEnd(sender As Object, e As EventArgs)
    Protected Overridable Sub OnPositionEnd(e As EventArgs)
        RaiseEvent PositionEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyAccountSummary(e As AccountSummaryEventArgs) Implements IAccountDataConsumer.NotifyAccountSummary
        OnAccountSummary(e)
    End Sub

    Public Event AccountSummary(sender As Object, e As AccountSummaryEventArgs)
    Protected Overridable Sub OnAccountSummary(e As AccountSummaryEventArgs)
        RaiseEvent AccountSummary(Me, e)
    End Sub

    Public Overrides Sub NotifyAccountValue(e As UpdateAccountValueEventArgs) Implements IAccountDataConsumer.NotifyAccountValue
        OnUpdateAccountValue(e)
    End Sub

    Public Event UpdateAccountValue(sender As Object, e As UpdateAccountValueEventArgs)
    Protected Overridable Sub OnUpdateAccountValue(e As UpdateAccountValueEventArgs)
        RaiseEvent UpdateAccountValue(Me, e)
    End Sub

    Public Overrides Sub NotifyAccountTime(e As UpdateAccountTimeEventArgs) Implements IAccountDataConsumer.NotifyAccountTime
        OnUpdateAccountTime(e)
    End Sub

    Public Event UpdateAccountTime(sender As Object, e As UpdateAccountTimeEventArgs)
    Protected Overridable Sub OnUpdateAccountTime(e As UpdateAccountTimeEventArgs)
        RaiseEvent UpdateAccountTime(Me, e)
    End Sub

    Public Overrides Sub NotifyAdvisorData(e As AdvisorDataEventArgs) Implements IAccountDataConsumer.NotifyAdvisorData
        OnAdvisorData(e)
    End Sub

    Public Event AdvisorData(sender As Object, e As AdvisorDataEventArgs)
    Protected Overridable Sub OnAdvisorData(e As AdvisorDataEventArgs)
        RaiseEvent AdvisorData(Me, e)
    End Sub

    Public Overrides Sub NotifyManagedAccounts(e As ManagedAccountsEventArgs) Implements IAccountDataConsumer.NotifyManagedAccounts
        OnManagedAccounts(e)
    End Sub

    Public Event ManagedAccounts(sender As Object, e As ManagedAccountsEventArgs)
    Protected Overridable Sub OnManagedAccounts(e As ManagedAccountsEventArgs)
        RaiseEvent ManagedAccounts(Me, e)
    End Sub

    Public Overrides Sub NotifyPosition(e As PositionEventArgs) Implements IAccountDataConsumer.NotifyPosition
        OnPosition(e)
    End Sub

    Public Event Position(sender As Object, e As PositionEventArgs)
    Protected Overridable Sub OnPosition(e As PositionEventArgs)
        RaiseEvent Position(Me, e)
    End Sub

    Public Overrides Sub NotifyPortfolioUpdate(e As UpdatePortfolioEventArgs) Implements IAccountDataConsumer.NotifyPortfolioUpdate
        OnUpdatePortfolio(e)
    End Sub

    Public Event UpdatePortfolio(sender As Object, e As UpdatePortfolioEventArgs)
    Protected Overridable Sub OnUpdatePortfolio(e As UpdatePortfolioEventArgs)
        RaiseEvent UpdatePortfolio(Me, e)
    End Sub

#End Region

#Region "IConnectionStatusConsumer"

    Public Overrides Sub NotifyAPIConnectionStateChange(e As ApiConnectionStateChangeEventArgs) Implements IConnectionStatusConsumer.NotifyAPIConnectionStateChange
        OnConnectionStateChange(e)
    End Sub

    Public Event ConnectionStateChange(sender As Object, e As ApiConnectionStateChangeEventArgs)
    Protected Overridable Sub OnConnectionStateChange(e As ApiConnectionStateChangeEventArgs)
        RaiseEvent ConnectionStateChange(Me, e)
    End Sub

    Public Overrides Sub NotifyCurrentTime(e As CurrentTimeEventArgs) Implements IConnectionStatusConsumer.NotifyCurrentTime
        OnCurrentTime(e)
    End Sub

    Public Event CurrentTime(sender As Object, e As CurrentTimeEventArgs)
    Protected Overridable Sub OnCurrentTime(e As CurrentTimeEventArgs)
        RaiseEvent CurrentTime(Me, e)
    End Sub

    Public Overrides Sub NotifyIBServerConnectionStateChange(e As IBServerConnectionStateChangeEventArgs) Implements IConnectionStatusConsumer.NotifyIBServerConnectionStateChange
        IBServerConnectionStateChangedIBServerConnectionClosed(e)
    End Sub

    Public Event IBServerConnectionStateChanged(sender As Object, e As IBServerConnectionStateChangeEventArgs)
    Protected Overridable Sub IBServerConnectionStateChangedIBServerConnectionClosed(e As IBServerConnectionStateChangeEventArgs)
        RaiseEvent IBServerConnectionStateChanged(Me, e)
    End Sub

#End Region

#Region "IContractDetailsConsumer"

    Public Overrides Sub EndSecurityDefinitionOptionParameter(e As RequestEndEventArgs) Implements IContractDetailsConsumer.EndSecurityDefinitionOptionParameter
        OnSecurityDefinitionOptionParameterEnd(e)
    End Sub

    Public Event SecurityDefinitionOptionParameterEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnSecurityDefinitionOptionParameterEnd(e As RequestEndEventArgs)
        RaiseEvent SecurityDefinitionOptionParameterEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyMarketRule(e As MarketRuleEventArgs) Implements IContractDetailsConsumer.NotifyMarketRule
        OnMarketRule(e)
    End Sub

    Public Event MarketRule(sender As Object, e As MarketRuleEventArgs)
    Protected Overridable Sub OnMarketRule(e As MarketRuleEventArgs)
        RaiseEvent MarketRule(Me, e)
    End Sub

    Public Overrides Sub NotifySecurityDefinitionOptionParameter(e As SecurityDefinitionOptionParameterEventArgs) Implements IContractDetailsConsumer.NotifySecurityDefinitionOptionParameter
        OnSecurityDefinitionOptionParameter(e)
    End Sub

    Public Event SecurityDefinitionOptionParameter(sender As Object, e As SecurityDefinitionOptionParameterEventArgs)
    Protected Overridable Sub OnSecurityDefinitionOptionParameter(e As SecurityDefinitionOptionParameterEventArgs)
        RaiseEvent SecurityDefinitionOptionParameter(Me, e)
    End Sub

    Public Overrides Sub NotifySymbolSamples(e As SymbolSamplesEventArgs) Implements IContractDetailsConsumer.NotifySymbolSamples
        OnSymbolSamples(e)
    End Sub

    Public Event SymbolSamples(sender As Object, e As SymbolSamplesEventArgs)
    Protected Overridable Sub OnSymbolSamples(e As SymbolSamplesEventArgs)
        RaiseEvent SymbolSamples(Me, e)
    End Sub

    Public Overrides Sub EndContractDetails(e As RequestEndEventArgs) Implements IContractDetailsConsumer.EndContractDetails
        OnContractDetailsEnd(e)
    End Sub

    Public Event ContractDetailsEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnContractDetailsEnd(e As RequestEndEventArgs)
        RaiseEvent ContractDetailsEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyContract(e As ContractDetailsEventArgs) Implements IContractDetailsConsumer.NotifyContract
        OnContractDetails(e)
    End Sub

    Public Event ContractDetails(sender As Object, e As ContractDetailsEventArgs)
    Protected Overridable Sub OnContractDetails(e As ContractDetailsEventArgs)
        RaiseEvent ContractDetails(Me, e)
    End Sub

    Public Overrides Sub NotifyContractError(e As RequestErrorEventArgs) Implements IContractDetailsConsumer.NotifyContractError
        OnContractDetailsError(e)
    End Sub

    Public Event ContractDetailsError(sender As Object, e As RequestErrorEventArgs)
    Protected Overridable Sub OnContractDetailsError(e As RequestErrorEventArgs)
        RaiseEvent ContractDetailsError(Me, e)
    End Sub

#End Region

#Region "IDisplayGroupConsumer"

    Public Overrides Sub NotifyDisplayGroupList(e As DisplayGroupListEventArgs) Implements IDisplayGroupConsumer.NotifyDisplayGroupList
        OnDisplayGroupList(e)
    End Sub

    Public Event DisplayGroupList(sender As Object, e As DisplayGroupListEventArgs)
    Protected Overridable Sub OnDisplayGroupList(e As DisplayGroupListEventArgs)
        RaiseEvent DisplayGroupList(Me, e)
    End Sub

    Public Overrides Sub NotifyDisplayGroupUpdated(e As DisplayGroupUpdatedEventArgs) Implements IDisplayGroupConsumer.NotifyDisplayGroupUpdated
        OnDisplayGroupUpdated(e)
    End Sub

    Public Event DisplayGroupUpdated(sender As Object, e As DisplayGroupUpdatedEventArgs)
    Protected Overridable Sub OnDisplayGroupUpdated(e As DisplayGroupUpdatedEventArgs)
        RaiseEvent DisplayGroupUpdated(Me, e)
    End Sub

#End Region

#Region "IErrorAndNotificationConsumer"

    Public Overrides Sub NotifyException(e As ExceptionEventArgs) Implements IErrorAndNotificationConsumer.NotifyException
        OnException(e)
    End Sub

    Public Event Exception(sender As Object, e As ExceptionEventArgs)
    Protected Overridable Sub OnException(e As ExceptionEventArgs)
        RaiseEvent Exception(Me, e)
    End Sub

    Public Overrides Sub NotifyApiError(e As ApiErrorEventArgs) Implements IErrorAndNotificationConsumer.NotifyApiError
        OnApiError(e)
    End Sub

    Public Event ApiError(sender As Object, e As ApiErrorEventArgs)
    Protected Overridable Sub OnApiError(e As ApiErrorEventArgs)
        RaiseEvent ApiError(Me, e)
    End Sub

    Public Overrides Sub NotifyApiEvent(e As ApiEventEventArgs) Implements IErrorAndNotificationConsumer.NotifyApiEvent
        OnApiEvent(e)
    End Sub

    Public Event ApiEvent(sender As Object, e As ApiEventEventArgs)
    Protected Overridable Sub OnApiEvent(e As ApiEventEventArgs)
        RaiseEvent ApiEvent(Me, e)
    End Sub

#End Region

#Region "IFundamentalDataConsumer"

    Public Overrides Sub NotifyFundamentalData(e As FundamentalDataEventArgs) Implements IFundamentalDataConsumer.NotifyFundamentalData
        OnFundamentalData(e)
    End Sub

    Public Event FundamentalData(sender As Object, e As FundamentalDataEventArgs)

    Protected Overridable Sub OnFundamentalData(e As FundamentalDataEventArgs)
        RaiseEvent FundamentalData(Me, e)
    End Sub

#End Region

#Region "IHistoricalDataConsumer"

    Public Overrides Sub NotifyHeadTimestamp(e As HeadTimestampEventArgs) Implements IHistoricalDataConsumer.NotifyHeadTimestamp
        OnHeadTimestamp(e)
    End Sub

    Public Event HeadTimestamp(sender As Object, e As HeadTimestampEventArgs)
    Protected Overridable Sub OnHeadTimestamp(e As HeadTimestampEventArgs)
        RaiseEvent HeadTimestamp(Me, e)
    End Sub

    Public Overrides Sub NotifyHistogramData(e As HistogramDataEventArgs) Implements IHistoricalDataConsumer.NotifyHistogramData
        OnHistogramData(e)
    End Sub

    Public Event HistogramData(sender As Object, e As HistogramDataEventArgs)
    Protected Overridable Sub OnHistogramData(e As HistogramDataEventArgs)
        RaiseEvent HistogramData(Me, e)
    End Sub

    Public Overrides Sub EndHistoricalBars(e As HistoricalBarsRequestEventArgs) Implements IHistoricalDataConsumer.EndHistoricalBars
        OnHistoricalBarsEnd(e)
    End Sub

    Public Event HistoricalBarsEnd(sender As Object, e As HistoricalBarsRequestEventArgs)
    Protected Overridable Sub OnHistoricalBarsEnd(e As HistoricalBarsRequestEventArgs)
        RaiseEvent HistoricalBarsEnd(Me, e)
    End Sub

    Public Overrides Sub EndHistoricalBidAsks(e As RequestEndEventArgs) Implements IHistoricalDataConsumer.EndHistoricalBidAsks
        OnHistoricalBidAsksEnd(e)
    End Sub

    Public Event HistoricalBidAsksEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnHistoricalBidAsksEnd(e As RequestEndEventArgs)
        RaiseEvent HistoricalBidAsksEnd(Me, e)
    End Sub

    Public Overrides Sub EndHistoricalMidpoints(e As RequestEndEventArgs) Implements IHistoricalDataConsumer.EndHistoricalMidpoints
        OnHistoricalMidpointsEnd(e)
    End Sub

    Public Event HistoricalMidpointsEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnHistoricalMidpointsEnd(e As RequestEndEventArgs)
        RaiseEvent HistoricalMidpointsEnd(Me, e)
    End Sub

    Public Overrides Sub EndHistoricalTrades(e As RequestEndEventArgs) Implements IHistoricalDataConsumer.EndHistoricalTrades
        OnHistoricalTradesEnd(e)
    End Sub

    Public Event HistoricalTradesEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnHistoricalTradesEnd(e As RequestEndEventArgs)
        RaiseEvent HistoricalTradesEnd(Me, e)
    End Sub

    Public Overrides Sub UpdateHistoricalBar(e As HistoricalBarEventArgs) Implements IHistoricalDataConsumer.UpdateHistoricalBar
        OnHistoricalBar(e)
    End Sub

    Public Overrides Sub NotifyHistoricalBar(e As HistoricalBarEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalBar
        OnHistoricalBar(e)
    End Sub

    Public Event HistoricalBar(sender As Object, e As HistoricalBarEventArgs)
    Protected Overridable Sub OnHistoricalBar(e As HistoricalBarEventArgs)
        RaiseEvent HistoricalBar(Me, e)
    End Sub

    Public Overrides Sub NotifyHistoricalBarError(e As RequestErrorEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalBarError
        OnHistoricalBarError(e)
    End Sub

    Public Event HistoricalBarError(sender As Object, e As RequestErrorEventArgs)
    Protected Overridable Sub OnHistoricalBarError(e As RequestErrorEventArgs)
        RaiseEvent HistoricalBarError(Me, e)
    End Sub

    Public Overrides Sub NotifyHistoricalBidAsk(e As HistoricalBidAskEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalBidAsk
        OnHistoricalBidAsk(e)
    End Sub

    Public Event HistoricalBidAsk(sender As Object, e As HistoricalBidAskEventArgs)
    Protected Overridable Sub OnHistoricalBidAsk(e As HistoricalBidAskEventArgs)
        RaiseEvent HistoricalBidAsk(Me, e)
    End Sub

    Public Overrides Sub NotifyHistoricalMidpoint(e As HistoricalMidpointEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalMidpoint
        OnHistoricalMidpoint(e)
    End Sub

    Public Event HistoricalMidpoint(sender As Object, e As HistoricalMidpointEventArgs)
    Protected Overridable Sub OnHistoricalMidpoint(e As HistoricalMidpointEventArgs)
        RaiseEvent HistoricalMidpoint(Me, e)
    End Sub

    Public Overrides Sub NotifyHistoricalTrade(e As HistoricalTradeEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalTrade
        OnHistoricalTrade(e)
    End Sub

    Public Event HistoricalTrade(sender As Object, e As HistoricalTradeEventArgs)
    Protected Overridable Sub OnHistoricalTrade(e As HistoricalTradeEventArgs)
        RaiseEvent HistoricalTrade(Me, e)
    End Sub

    Public Overrides Sub StartHistoricalBars(e As HistoricalBarsRequestEventArgs) Implements IHistoricalDataConsumer.StartHistoricalBars
        OnHistoricalDataStart(e)
    End Sub

    Public Event HistoricalBarsStart(sender As Object, e As HistoricalBarsRequestEventArgs)
    Protected Overridable Sub OnHistoricalDataStart(e As HistoricalBarsRequestEventArgs)
        RaiseEvent HistoricalBarsStart(Me, e)
    End Sub

#End Region

#Region "IMarketDataConsumer"

    Public Overrides Sub NotifyRerouteData(e As RerouteDataEventArgs) Implements IMarketDataConsumer.NotifyRerouteData
        OnRerouteMarketData(e)
    End Sub

    Public Event RerouteMarketData(sender As Object, e As RerouteDataEventArgs)
    Protected Overridable Sub OnRerouteMarketData(e As RerouteDataEventArgs)
        RaiseEvent RerouteMarketData(Me, e)
    End Sub

    Public Overrides Sub NotifyTickRequestParams(e As TickRequestParamsEventArgs) Implements IMarketDataConsumer.NotifyTickRequestParams
        OnTickRequestParams(e)
    End Sub

    Public Event TickRequestParams(sender As Object, e As TickRequestParamsEventArgs)
    Protected Overridable Sub OnTickRequestParams(e As TickRequestParamsEventArgs)
        RaiseEvent TickRequestParams(Me, e)
    End Sub

    Public Overrides Sub EndTickSnapshot(e As RequestEndEventArgs) Implements IMarketDataConsumer.EndTickSnapshot
        OnTickSnapshotEnd(e)
    End Sub

    Public Event TickSnapshotEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnTickSnapshotEnd(e As RequestEndEventArgs)
        RaiseEvent TickSnapshotEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyMarketDataError(e As RequestErrorEventArgs) Implements IMarketDataConsumer.NotifyMarketDataError
        OnMarketDataError(e)
    End Sub

    Public Event MarketDataError(sender As Object, e As RequestErrorEventArgs)
    Protected Overridable Sub OnMarketDataError(e As RequestErrorEventArgs)
        RaiseEvent MarketDataError(Me, e)
    End Sub

    Public Overrides Sub NotifyMarketDataType(e As MarketDataTypeEventArgs) Implements IMarketDataConsumer.NotifyMarketDataType
        OnMarketDataType(e)
    End Sub

    Public Event MarketDataType(sender As Object, e As MarketDataTypeEventArgs)
    Protected Overridable Sub OnMarketDataType(e As MarketDataTypeEventArgs)
        RaiseEvent MarketDataType(Me, e)
    End Sub

    Public Overrides Sub NotifyRealtimeBar(e As RealtimeBarEventArgs) Implements IMarketDataConsumer.NotifyRealtimeBar
        OnRealtimeBar(e)
    End Sub

    Public Event RealtimeBar(sender As Object, e As RealtimeBarEventArgs)
    Protected Overridable Sub OnRealtimeBar(e As RealtimeBarEventArgs)
        RaiseEvent RealtimeBar(Me, e)
    End Sub

    Public Overrides Sub NotifyTickByTickAllLast(e As TickByTickAllLastEventArgs) Implements IMarketDataConsumer.NotifyTickByTickAllLast
        OnTickByTickAllLast(e)
    End Sub

    Public Event TickByTickAllLast(sender As Object, e As TickByTickAllLastEventArgs)
    Protected Overridable Sub OnTickByTickAllLast(e As TickByTickAllLastEventArgs)
        RaiseEvent TickByTickAllLast(Me, e)
    End Sub

    Public Overrides Sub NotifySmartComponents(e As SmartComponentsEventArgs) Implements IMarketDataConsumer.NotifySmartComponents
        OnSmartComponents(e)
    End Sub

    Public Event SmartComponents(sender As Object, e As SmartComponentsEventArgs)
    Protected Overridable Sub OnSmartComponents(e As SmartComponentsEventArgs)
        RaiseEvent SmartComponents(Me, e)
    End Sub

    Public Overrides Sub NotifyTickByTickBidAsk(e As TickByTickBidAskEventArgs) Implements IMarketDataConsumer.NotifyTickByTickBidAsk
        OnTickByTickBidAsk(e)
    End Sub

    Public Event TickByTickBidAsk(sender As Object, e As TickByTickBidAskEventArgs)
    Protected Overridable Sub OnTickByTickBidAsk(e As TickByTickBidAskEventArgs)
        RaiseEvent TickByTickBidAsk(Me, e)
    End Sub

    Public Overrides Sub NotifyTickByTickMidPoint(e As TickByTickMidPointEventArgs) Implements IMarketDataConsumer.NotifyTickByTickMidPoint
        OnTickByTickMidPoint(e)
    End Sub

    Public Event TickByTickMidPoint(sender As Object, e As TickByTickMidPointEventArgs)
    Protected Overridable Sub OnTickByTickMidPoint(e As TickByTickMidPointEventArgs)
        RaiseEvent TickByTickMidPoint(Me, e)
    End Sub

    Public Overrides Sub NotifyTickEFP(e As TickEFPEventArgs) Implements IMarketDataConsumer.NotifyTickEFP
        OnTickEFP(e)
    End Sub

    Public Event TickEFP(sender As Object, e As TickEFPEventArgs)
    Protected Overridable Sub OnTickEFP(e As TickEFPEventArgs)
        RaiseEvent TickEFP(Me, e)
    End Sub

    Public Overrides Sub NotifyTickGeneric(e As TickGenericEventArgs) Implements IMarketDataConsumer.NotifyTickGeneric
        OnTickGeneric(e)
    End Sub

    Public Event TickGeneric(sender As Object, e As TickGenericEventArgs)
    Protected Overridable Sub OnTickGeneric(e As TickGenericEventArgs)
        RaiseEvent TickGeneric(Me, e)
    End Sub

    Public Overrides Sub NotifyTickOptionComputation(e As TickOptionComputationEventArgs) Implements IMarketDataConsumer.NotifyTickOptionComputation
        OnTickOptionComputation(e)
    End Sub

    Public Event TickOptionComputation(sender As Object, e As TickOptionComputationEventArgs)
    Protected Overridable Sub OnTickOptionComputation(e As TickOptionComputationEventArgs)
        RaiseEvent TickOptionComputation(Me, e)
    End Sub

    Public Overrides Sub NotifyTickPrice(e As TickPriceEventArgs) Implements IMarketDataConsumer.NotifyTickPrice
        OnTickPrice(e)
    End Sub

    Public Event TickPrice(sender As Object, e As TickPriceEventArgs)
    Protected Overridable Sub OnTickPrice(e As TickPriceEventArgs)
        RaiseEvent TickPrice(Me, e)
    End Sub

    Public Overrides Sub NotifyTickSize(e As TickSizeEventArgs) Implements IMarketDataConsumer.NotifyTickSize
        OnTickSize(e)
    End Sub

    Public Event TickSize(sender As Object, e As TickSizeEventArgs)
    Protected Overridable Sub OnTickSize(e As TickSizeEventArgs)
        RaiseEvent TickSize(Me, e)
    End Sub

    Public Overrides Sub NotifyTickString(e As TickStringEventArgs) Implements IMarketDataConsumer.NotifyTickString
        OnTickString(e)
    End Sub

    Public Event TickString(sender As Object, e As TickStringEventArgs)
    Protected Overridable Sub OnTickString(e As TickStringEventArgs)
        RaiseEvent TickString(Me, e)
    End Sub

#End Region

#Region "IMarketDepthConsumer"

    Public Overrides Sub NotifyMarketDepthExchanges(e As MarketDepthExchangesEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthExchanges
        OnMarketDepthExchanges(e)
    End Sub

    Public Event MarketDepthExchanges(sender As Object, e As MarketDepthExchangesEventArgs)
    Protected Overridable Sub OnMarketDepthExchanges(e As MarketDepthExchangesEventArgs)
        RaiseEvent MarketDepthExchanges(Me, e)
    End Sub

    Public Overrides Sub NotifyRerouteDepthData(e As RerouteDataEventArgs) Implements IMarketDepthConsumer.NotifyRerouteData
        OnRerouteDepthData(e)
    End Sub

    Public Event RerouteDepthData(sender As Object, e As RerouteDataEventArgs)
    Protected Overridable Sub OnRerouteDepthData(e As RerouteDataEventArgs)
        RaiseEvent RerouteDepthData(Me, e)
    End Sub

    Public Overrides Sub NotifyMarketDepthError(e As RequestErrorEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthError
        OnMarketDepthError(e)
    End Sub

    Public Event MarketDepthError(sender As Object, e As RequestErrorEventArgs)
    Protected Overridable Sub OnMarketDepthError(e As RequestErrorEventArgs)
        RaiseEvent MarketDepthError(Me, e)
    End Sub

    Public Overrides Sub NotifyMarketDepth(e As MarketDepthUpdateEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepth
        OnMarketDepthUpdate(e)
    End Sub

    Public Event MarketDepthUpdate(sender As Object, e As MarketDepthUpdateEventArgs)
    Protected Overridable Sub OnMarketDepthUpdate(e As MarketDepthUpdateEventArgs)
        RaiseEvent MarketDepthUpdate(Me, e)
    End Sub

    Public Overrides Sub NotifyMarketDepthReset(e As MarketDepthRestEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthReset
        OnResetMarketDepth(e)
    End Sub

    Public Event ResetMarketDepth(sender As Object, e As MarketDepthRestEventArgs)
    Protected Overridable Sub OnResetMarketDepth(e As MarketDepthRestEventArgs)
        RaiseEvent ResetMarketDepth(Me, e)
    End Sub

#End Region

#Region "INewsConsumer"

    Public Overrides Sub EndHistoricalNews(e As HistoricalNewsEndEventArgs) Implements INewsConsumer.EndHistoricalNews
        OnHistoricalNewsEnd(e)
    End Sub

    Public Event HistoricalNewsEnd(sender As Object, e As HistoricalNewsEndEventArgs)
    Protected Overridable Sub OnHistoricalNewsEnd(e As HistoricalNewsEndEventArgs)
        RaiseEvent HistoricalNewsEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyNewsArticle(e As NewsArticleEventArgs) Implements INewsConsumer.NotifyNewsArticle
        OnNewsArticle(e)
    End Sub

    Public Event NewsArticle(sender As Object, e As NewsArticleEventArgs)
    Protected Overridable Sub OnNewsArticle(e As NewsArticleEventArgs)
        RaiseEvent NewsArticle(Me, e)
    End Sub

    Public Overrides Sub NotifyHistoricalNews(e As HistoricalNewsEventArgs) Implements INewsConsumer.NotifyHistoricalNews
        OnHistoricalNews(e)
    End Sub

    Public Event HistoricalNews(sender As Object, e As HistoricalNewsEventArgs)
    Protected Overridable Sub OnHistoricalNews(e As HistoricalNewsEventArgs)
        RaiseEvent HistoricalNews(Me, e)
    End Sub

    Public Overrides Sub NotifyNewsProviders(e As NewsProvidersEventArgs) Implements INewsConsumer.NotifyNewsProviders
        OnNewsProviders(e)
    End Sub

    Public Event NewsProviders(sender As Object, e As NewsProvidersEventArgs)
    Protected Overridable Sub OnNewsProviders(e As NewsProvidersEventArgs)
        RaiseEvent NewsProviders(Me, e)
    End Sub

    Public Overrides Sub NotifyTickNews(e As TickNewsEventArgs) Implements INewsConsumer.NotifyTickNews
        OnTickNews(e)
    End Sub

    Public Event TickNews(sender As Object, e As TickNewsEventArgs)
    Protected Overridable Sub OnTickNews(e As TickNewsEventArgs)
        RaiseEvent TickNews(Me, e)
    End Sub

    Public Overrides Sub NotifyNewsBulletin(e As NewsBulletinEventArgs) Implements INewsConsumer.NotifyNewsBulletin
        OnNewsBulletin(e)
    End Sub

    Public Event NewsBulletin(sender As Object, e As NewsBulletinEventArgs)
    Protected Overridable Sub OnNewsBulletin(e As NewsBulletinEventArgs)
        RaiseEvent NewsBulletin(Me, e)
    End Sub

#End Region

#Region "IOrderInfoConsumer"

    Public Overrides Sub EndExecutions(e As RequestEndEventArgs) Implements IOrderInfoConsumer.EndExecutions
        OnExecutionDetailsEnd(e)
    End Sub

    Public Event ExecutionDetailsEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnExecutionDetailsEnd(e As RequestEndEventArgs)
        RaiseEvent ExecutionDetailsEnd(Me, e)
    End Sub

    Public Overrides Sub EndOpenOrders(e As EventArgs) Implements IOrderInfoConsumer.EndOpenOrders
        OnOpenOrderEnd(EventArgs.Empty)
    End Sub

    Public Event OpenOrderEnd(sender As Object, e As EventArgs)
    Protected Overridable Sub OnOpenOrderEnd(e As EventArgs)
        RaiseEvent OpenOrderEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyCommissionReport(e As CommissionReportEventArgs) Implements IOrderInfoConsumer.NotifyCommissionReport
        OnCommissionReport(e)
    End Sub

    Public Event CommissionReport(sender As Object, e As CommissionReportEventArgs)
    Protected Overridable Sub OnCommissionReport(e As CommissionReportEventArgs)
        RaiseEvent CommissionReport(Me, e)
    End Sub

    Public Overrides Sub NotifyDeltaNeutralValidation(e As DeltaNeutralValidationEventArgs) Implements IOrderInfoConsumer.NotifyDeltaNeutralValidation
        OnDeltaNeutralValidation(e)
    End Sub

    Public Event DeltaNeutralValidation(sender As Object, e As DeltaNeutralValidationEventArgs)
    Protected Overridable Sub OnDeltaNeutralValidation(e As DeltaNeutralValidationEventArgs)
        RaiseEvent DeltaNeutralValidation(Me, e)
    End Sub

    Public Overrides Sub NotifyOrderError(e As OrderErrorEventArgs) Implements IOrderInfoConsumer.NotifyOrderError
        OnOrderError(e)
    End Sub

    Public Event OrderError(sender As Object, e As OrderErrorEventArgs)
    Protected Overridable Sub OnOrderError(e As OrderErrorEventArgs)
        RaiseEvent OrderError(Me, e)
    End Sub

    Public Overrides Sub NotifyExecution(e As ExecutionDetailsEventArgs) Implements IOrderInfoConsumer.NotifyExecution
        OnExecutionDetails(e)
    End Sub

    Public Event ExecutionDetails(sender As Object, e As ExecutionDetailsEventArgs)
    Protected Overridable Sub OnExecutionDetails(e As ExecutionDetailsEventArgs)
        RaiseEvent ExecutionDetails(Me, e)
    End Sub

    Public Overrides Sub NotifyOpenOrder(e As OpenOrderEventArgs) Implements IOrderInfoConsumer.NotifyOpenOrder
        OnOpenOrder(e)
    End Sub

    Public Event OpenOrder(sender As Object, e As OpenOrderEventArgs)
    Protected Overridable Sub OnOpenOrder(e As OpenOrderEventArgs)
        RaiseEvent OpenOrder(Me, e)
    End Sub

    Public Overrides Sub NotifyOrderStatus(e As OrderStatusEventArgs) Implements IOrderInfoConsumer.NotifyOrderStatus
        OnOrderStatus(e)
    End Sub

    Public Event OrderStatus(sender As Object, e As OrderStatusEventArgs)
    Protected Overridable Sub OnOrderStatus(e As OrderStatusEventArgs)
        RaiseEvent OrderStatus(Me, e)
    End Sub

#End Region

#Region "IPerformanceDataConsumer"

    Public Overrides Sub NotifyPerformanceStats(e As PerformanceStatsUpdateEventArgs) Implements IPerformanceDataConsumer.NotifyPerformanceStats
        OnPerformanceStatsUpdate(e)
    End Sub

    Public Event PerformanceStatsUpdate(sender As Object, e As PerformanceStatsUpdateEventArgs)
    Protected Overridable Sub OnPerformanceStatsUpdate(e As PerformanceStatsUpdateEventArgs)
        RaiseEvent PerformanceStatsUpdate(Me, e)
    End Sub

#End Region

#Region "IScannerDataConsumer"

    Public Overrides Sub EndScannerData(e As RequestEndEventArgs) Implements IScannerDataConsumer.EndScannerData
        OnScannerDataEnd(e)
    End Sub

    Public Event ScannerDataEnd(sender As Object, e As RequestEndEventArgs)
    Protected Overridable Sub OnScannerDataEnd(e As RequestEndEventArgs)
        RaiseEvent ScannerDataEnd(Me, e)
    End Sub

    Public Overrides Sub NotifyScannerData(e As ScannerDataEventArgs) Implements IScannerDataConsumer.NotifyScannerData
        OnScannerData(e)
    End Sub

    Public Event ScannerData(sender As Object, e As ScannerDataEventArgs)
    Protected Overridable Sub OnScannerData(e As ScannerDataEventArgs)
        RaiseEvent ScannerData(Me, e)
    End Sub

    Public Overrides Sub NotifyScannerParameters(e As ScannerParametersEventArgs) Implements IScannerDataConsumer.NotifyScannerParameters
        OnScannerParameters(e)
    End Sub

    Public Event ScannerParameters(sender As Object, e As ScannerParametersEventArgs)
    Protected Overridable Sub OnScannerParameters(e As ScannerParametersEventArgs)
        RaiseEvent ScannerParameters(Me, e)
    End Sub

#End Region

#Region "ISocketDataConsumer"

    Public Overrides Sub NotifySocketInputData(e As SocketDataEventArgs) Implements ISocketDataConsumer.NotifySocketInputData
        OnSocketInputData(e)
    End Sub

    Public Event SocketInputData(sender As Object, e As SocketDataEventArgs)
    Protected Overridable Sub OnSocketInputData(e As SocketDataEventArgs)
        RaiseEvent SocketInputData(Me, e)
    End Sub

    Public Overrides Sub NotifySocketInputMessage(e As ApiMessageEventArgs) Implements ISocketDataConsumer.NotifySocketInputMessage
        OnSocketInputMessage(e)
    End Sub

    Public Event SocketInputMessage(sender As Object, e As ApiMessageEventArgs)
    Protected Overridable Sub OnSocketInputMessage(e As ApiMessageEventArgs)
        RaiseEvent SocketInputMessage(Me, e)
    End Sub

    Public Overrides Sub NotifySocketOutputData(e As SocketDataEventArgs) Implements ISocketDataConsumer.NotifySocketOutputData
        OnSocketOutputData(e)
    End Sub

    Public Event SocketOutputData(sender As Object, e As SocketDataEventArgs)
    Protected Overridable Sub OnSocketOutputData(e As SocketDataEventArgs)
        RaiseEvent SocketOutputData(Me, e)
    End Sub

    Public Overrides Sub NotifySocketOutputMessage(e As ApiMessageEventArgs) Implements ISocketDataConsumer.NotifySocketOutputMessage
        OnSocketOutputMessage(e)
    End Sub

    Public Event SocketOutputMessage(sender As Object, e As ApiMessageEventArgs)
    Protected Overridable Sub OnSocketOutputMessage(e As ApiMessageEventArgs)
        RaiseEvent SocketOutputMessage(Me, e)
    End Sub

#End Region
End Class
