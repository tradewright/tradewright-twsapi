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

Imports TradeWright.IBAPI

Public MustInherit Class CallbackHandler
    Implements IDisposable,
        IAccountDataConsumer,
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
        IScannerDataConsumer

#Region "IAccountDataConsumer"

    Public Overridable Sub EndAccountSummary(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndAccountSummary
        ' no action
    End Sub

    Public Overridable Sub EndAccountUpdateMulti(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndAccountUpdateMulti
        ' no action
    End Sub

    Public Overridable Sub EndAccountValue(e As AccountDownloadEndEventArgs) Implements IAccountDataConsumer.EndAccountValue
        ' no action
    End Sub

    Public Overridable Sub EndPosition(e As EventArgs) Implements IAccountDataConsumer.EndPosition
        ' no action
    End Sub

    Public Overridable Sub EndPositionMulti(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndPositionMulti
        ' no action
    End Sub

    Public Overridable Sub NotifyAccountSummary(e As AccountSummaryEventArgs) Implements IAccountDataConsumer.NotifyAccountSummary
        ' no action
    End Sub

    Public Overridable Sub NotifyAccountValue(e As UpdateAccountValueEventArgs) Implements IAccountDataConsumer.NotifyAccountValue
        ' no action
    End Sub

    Public Overridable Sub NotifyAccountTime(e As UpdateAccountTimeEventArgs) Implements IAccountDataConsumer.NotifyAccountTime
        ' no action
    End Sub

    Public Overridable Sub NotifyAccountUpdateMulti(e As AccountUpdateMultiEventArgs) Implements IAccountDataConsumer.NotifyAccountUpdateMulti
        ' no action
    End Sub

    Public Overridable Sub NotifyAdvisorData(e As AdvisorDataEventArgs) Implements IAccountDataConsumer.NotifyAdvisorData
        ' no action
    End Sub

    Public Overridable Sub NotifyPnL(e As PnLEventArgs) Implements IAccountDataConsumer.NotifyPnL
        ' no action
    End Sub

    Public Overridable Sub NotifyPnLSingle(e As PnLSingleEventArgs) Implements IAccountDataConsumer.NotifyPnLSingle
        ' no action
    End Sub

    Public Overridable Sub NotifyFamilyCodes(e As FamilyCodesEventArgs) Implements IAccountDataConsumer.NotifyFamilyCodes
        ' no action
    End Sub

    Public Overridable Sub NotifyManagedAccounts(e As ManagedAccountsEventArgs) Implements IAccountDataConsumer.NotifyManagedAccounts
        ' no action
    End Sub

    Public Overridable Sub NotifyPortfolioUpdate(e As UpdatePortfolioEventArgs) Implements IAccountDataConsumer.NotifyPortfolioUpdate
        ' no action
    End Sub

    Public Overridable Sub NotifyPosition(e As PositionEventArgs) Implements IAccountDataConsumer.NotifyPosition
        ' no action
    End Sub

    Public Overridable Sub NotifyPositionMulti(e As PositionMultiEventArgs) Implements IAccountDataConsumer.NotifyPositionMulti
        ' no action
    End Sub

    Public Overridable Sub NotifySoftDollarTiers(e As SoftDollarTiersEventArgs) Implements IAccountDataConsumer.NotifySoftDollarTiers
        ' no action
    End Sub

#End Region

#Region "IConnectionStatusConsumer"

    Public Overridable Sub NotifyAPIConnectionStateChange(e As ApiConnectionStateChangeEventArgs) Implements IConnectionStatusConsumer.NotifyAPIConnectionStateChange
        ' no action
    End Sub

    Public Overridable Sub NotifyCurrentTime(e As CurrentTimeEventArgs) Implements IConnectionStatusConsumer.NotifyCurrentTime
        ' no action
    End Sub

    Public Overridable Sub NotifyIBServerConnectionStateChange(e As IBServerConnectionStateChangeEventArgs) Implements IConnectionStatusConsumer.NotifyIBServerConnectionStateChange
        ' no action
    End Sub

#End Region

#Region "IContractDetailsConsumer"

    Public Overridable Sub EndContractDetails(e As RequestEndEventArgs) Implements IContractDetailsConsumer.EndContractDetails
        ' no action
    End Sub

    Public Overridable Sub EndSecurityDefinitionOptionParameter(e As RequestEndEventArgs) Implements IContractDetailsConsumer.EndSecurityDefinitionOptionParameter
        ' no action
    End Sub

    Public Overridable Sub NotifyContract(e As ContractDetailsEventArgs) Implements IContractDetailsConsumer.NotifyContract
        ' no action
    End Sub

    Public Overridable Sub NotifyContractError(e As RequestErrorEventArgs) Implements IContractDetailsConsumer.NotifyContractError
        ' no action
    End Sub

    Public Overridable Sub NotifyMarketRule(e As MarketRuleEventArgs) Implements IContractDetailsConsumer.NotifyMarketRule
        ' no action
    End Sub

    Public Overridable Sub NotifySecurityDefinitionOptionParameter(e As SecurityDefinitionOptionParameterEventArgs) Implements IContractDetailsConsumer.NotifySecurityDefinitionOptionParameter
        ' no action
    End Sub

    Public Overridable Sub NotifySmartComponents(e As SmartComponentsEventArgs) Implements IContractDetailsConsumer.NotifySmartComponents
        ' no action
    End Sub

    Public Overridable Sub NotifySymbolSamples(e As SymbolSamplesEventArgs) Implements IContractDetailsConsumer.NotifySymbolSamples
        ' no action
    End Sub

#End Region

#Region "IDisplayGroupConsumer"

    Public Overridable Sub NotifyDisplayGroupList(e As DisplayGroupListEventArgs) Implements IDisplayGroupConsumer.NotifyDisplayGroupList
        ' no action
    End Sub

    Public Overridable Sub NotifyDisplayGroupUpdated(e As DisplayGroupUpdatedEventArgs) Implements IDisplayGroupConsumer.NotifyDisplayGroupUpdated
        ' no action
    End Sub

#End Region

#Region "IDisposable"

    Protected Overridable Sub Dispose(disposing As Boolean)
        Static disposed As Boolean
        If disposed Then Exit Sub
        disposed = True

        If disposing Then
            ' TODO: dispose managed state (managed objects).
        End If

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region

#Region "IErrorAndNotificationConsumer"

    Public Overridable Sub NotifyException(e As ExceptionEventArgs) Implements IErrorAndNotificationConsumer.NotifyException
        ' no action
    End Sub

    Public Overridable Sub NotifyApiError(e As ApiErrorEventArgs) Implements IErrorAndNotificationConsumer.NotifyApiError
        ' no action
    End Sub

    Public Overridable Sub NotifyApiEvent(e As ApiEventEventArgs) Implements IErrorAndNotificationConsumer.NotifyApiEvent
        ' no action
    End Sub

#End Region

#Region "IFundamentalDataConsumer"

    Public Overridable Sub NotifyFundamentalData(e As FundamentalDataEventArgs) Implements IFundamentalDataConsumer.NotifyFundamentalData
        ' no action
    End Sub

#End Region

#Region "IHistDataConsumer"

    Public Overridable Sub EndHistoricalData(e As HistoricalDataRequestEventArgs) Implements IHistoricalDataConsumer.EndHistoricalData
        ' no action
    End Sub

    Public Overridable Sub NotifyHeadTimestamp(e As HeadTimestampEventArgs) Implements IHistoricalDataConsumer.NotifyHeadTimestamp
        ' no action
    End Sub

    Public Overridable Sub NotifyHistogramData(e As HistogramDataEventArgs) Implements IHistoricalDataConsumer.NotifyHistogramData
        ' no action
    End Sub

    Public Overridable Sub NotifyHistoricalData(e As HistoricalDataEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalData
        ' no action
    End Sub

    Public Overridable Sub NotifyHistoricalDataError(e As RequestErrorEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalDataError
        ' no action
    End Sub

    Public Overridable Sub StartHistoricalData(e As HistoricalDataRequestEventArgs) Implements IHistoricalDataConsumer.StartHistoricalData
        ' no action
    End Sub

    Public Overridable Sub UpdateHistoricalData(e As HistoricalDataEventArgs) Implements IHistoricalDataConsumer.UpdateHistoricalData
        ' no action
    End Sub

#End Region

#Region "IMarketDataConsumer"

    Public Overridable Sub EndTickSnapshot(e As RequestEndEventArgs) Implements IMarketDataConsumer.EndTickSnapshot
        ' no action
    End Sub

    Public Overridable Sub NotifyMarketDataError(e As RequestErrorEventArgs) Implements IMarketDataConsumer.NotifyMarketDataError
        ' no action
    End Sub

    Public Overridable Sub NotifyMarketDataType(e As MarketDataTypeEventArgs) Implements IMarketDataConsumer.NotifyMarketDataType
        ' no action
    End Sub

    Public Overridable Sub NotifyRealtimeBar(e As RealtimeBarEventArgs) Implements IMarketDataConsumer.NotifyRealtimeBar
        ' no action
    End Sub

    Public Overridable Sub NotifyRerouteData(e As RerouteDataEventArgs) Implements IMarketDataConsumer.NotifyRerouteData
        ' no action
    End Sub

    Public Overridable Sub NotifyTickEFP(e As TickEFPEventArgs) Implements IMarketDataConsumer.NotifyTickEFP
        ' no action
    End Sub

    Public Overridable Sub NotifyTickGeneric(e As TickGenericEventArgs) Implements IMarketDataConsumer.NotifyTickGeneric
        ' no action
    End Sub

    Public Overridable Sub NotifyTickOptionComputation(e As TickOptionComputationEventArgs) Implements IMarketDataConsumer.NotifyTickOptionComputation
        ' no action
    End Sub

    Public Overridable Sub NotifyTickPrice(e As TickPriceEventArgs) Implements IMarketDataConsumer.NotifyTickPrice
        ' no action
    End Sub

    Public Overridable Sub NotifyTickRequestParams(e As TickRequestParamsEventArgs) Implements IMarketDataConsumer.NotifyTickRequestParams
        ' no action
    End Sub

    Public Overridable Sub NotifyTickSize(e As TickSizeEventArgs) Implements IMarketDataConsumer.NotifyTickSize
        ' no action
    End Sub

    Public Overridable Sub NotifyTickString(e As TickStringEventArgs) Implements IMarketDataConsumer.NotifyTickString
        ' no action
    End Sub

#End Region

#Region "IMarketDepthConsumer"

    Public Overridable Sub NotifyMarketDepth(e As MarketDepthUpdateEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepth
        ' no action
    End Sub

    Public Overridable Sub NotifyMarketDepthError(e As RequestErrorEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthError
        ' no action
    End Sub

    Public Overridable Sub NotifyMarketDepthExchanges(e As MarketDepthExchangesEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthExchanges
        ' no action
    End Sub

    Public Overridable Sub NotifyRerouteDepthData(e As RerouteDataEventArgs) Implements IMarketDepthConsumer.NotifyRerouteData
        ' no action
    End Sub

    Public Overridable Sub NotifyMarketDepthReset(e As MarketDepthRestEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthReset
        ' no action
    End Sub

#End Region

#Region "INewsConsumer"

    Public Overridable Sub EndHistoricalNews(e As HistoricalNewsEndEventArgs) Implements INewsConsumer.EndHistoricalNews
        ' no action
    End Sub

    Public Overridable Sub NotifyHistoricalNews(e As HistoricalNewsEventArgs) Implements INewsConsumer.NotifyHistoricalNews
        ' no action
    End Sub

    Public Overridable Sub NotifyNewsArticle(e As NewsArticleEventArgs) Implements INewsConsumer.NotifyNewsArticle
        ' no action
    End Sub

    Public Overridable Sub NotifyNewsBulletin(e As NewsBulletinEventArgs) Implements INewsConsumer.NotifyNewsBulletin
        ' no action
    End Sub

    Public Overridable Sub NotifyNewsProviders(e As NewsProvidersEventArgs) Implements INewsConsumer.NotifyNewsProviders
        ' no action
    End Sub

    Public Overridable Sub NotifyTickNews(e As TickNewsEventArgs) Implements INewsConsumer.NotifyTickNews
        ' no action
    End Sub

#End Region

#Region "IOrderInfoConsumer"

    Public Overridable Sub EndExecutions(e As RequestEndEventArgs) Implements IOrderInfoConsumer.EndExecutions
        ' no action
    End Sub

    Public Overridable Sub EndOpenOrders(e As EventArgs) Implements IOrderInfoConsumer.EndOpenOrders
        ' no action
    End Sub

    Public Overridable Sub NotifyCommissionReport(e As CommissionReportEventArgs) Implements IOrderInfoConsumer.NotifyCommissionReport
        ' no action
    End Sub

    Public Overridable Sub NotifyDeltaNeutralValidation(e As DeltaNeutralValidationEventArgs) Implements IOrderInfoConsumer.NotifyDeltaNeutralValidation
        ' no action
    End Sub

    Public Overridable Sub NotifyExecution(e As ExecutionDetailsEventArgs) Implements IOrderInfoConsumer.NotifyExecution
        ' no action
    End Sub

    Public Overridable Sub NotifyOpenOrder(e As OpenOrderEventArgs) Implements IOrderInfoConsumer.NotifyOpenOrder
        ' no action
    End Sub

    Public Overridable Sub NotifyOrderError(e As OrderErrorEventArgs) Implements IOrderInfoConsumer.NotifyOrderError
        ' no action
    End Sub

    Public Overridable Sub NotifyOrderStatus(e As OrderStatusEventArgs) Implements IOrderInfoConsumer.NotifyOrderStatus
        ' no action
    End Sub

#End Region

#Region "IPerformanceDataConsumer"

    Public Overridable Sub NotifyPerformanceStats(e As PerformanceStatsUpdateEventArgs) Implements IPerformanceDataConsumer.NotifyPerformanceStats
        ' no action
    End Sub

#End Region

#Region "IScannerDataConsumer"

    Public Overridable Sub EndScannerData(e As RequestEndEventArgs) Implements IScannerDataConsumer.EndScannerData
        ' no action
    End Sub

    Public Overridable Sub NotifyScannerData(e As ScannerDataEventArgs) Implements IScannerDataConsumer.NotifyScannerData
        ' no action
    End Sub

    Public Overridable Sub NotifyScannerParameters(e As ScannerParametersEventArgs) Implements IScannerDataConsumer.NotifyScannerParameters
        ' no action
    End Sub

#End Region

End Class
