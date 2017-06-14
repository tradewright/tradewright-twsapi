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


' Note the use of Option Strict Off in this file allows the widening conversion from 
' the base methods to the eventHandler Delegate in the QueueEntry structure.
Option Strict Off

Imports TradeWright.IBAPI

Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Public Class QueueingEventSource
    Inherits EventSource

    Private Structure QueueEntry(Of T As EventArgs)
        Dim e As T
        Dim eventHandler As Action(Of T)
    End Structure

    Private mQueue As BlockingCollection(Of QueueEntry(Of EventArgs)) = New BlockingCollection(Of QueueEntry(Of EventArgs))()

    Private mSyncContext As SynchronizationContext

    Public Sub New(syncContext As SynchronizationContext)
        If syncContext Is Nothing Then Throw New ArgumentNullException(NameOf(syncContext))
        mSyncContext = syncContext

        Dim dispatcher = Task.Factory.StartNew(Sub() dispatchLoop())
    End Sub

#Region "IAccountDataConsumer"

    Protected Overrides Sub OnAccountUpdateMultiEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnAccountUpdateMultiEnd)
    End Sub

    Protected Overrides Sub OnPositionMultiEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnPositionMultiEnd)
    End Sub

    Protected Overrides Sub OnAccountUpdateMulti(e As AccountUpdateMultiEventArgs)
        queueEvent(e, AddressOf MyBase.OnAccountUpdateMulti)
    End Sub

    Protected Overrides Sub OnDailyPnL(e As DailyPnLEventArgs)
        queueEvent(e, AddressOf MyBase.OnDailyPnL)
    End Sub

    Protected Overrides Sub OnDailyPnLSingle(e As DailyPnLSingleEventArgs)
        queueEvent(e, AddressOf MyBase.OnDailyPnLSingle)
    End Sub

    Protected Overrides Sub OnFamilyCodes(e As FamilyCodesEventArgs)
        queueEvent(e, AddressOf MyBase.OnFamilyCodes)
    End Sub

    Protected Overrides Sub OnPositionMulti(e As PositionMultiEventArgs)
        queueEvent(e, AddressOf MyBase.OnPositionMulti)
    End Sub

    Protected Overrides Sub OnSoftDollarTiers(e As SoftDollarTiersEventArgs)
        queueEvent(e, AddressOf MyBase.OnSoftDollarTiers)
    End Sub

    Protected Overrides Sub OnAccountSummaryEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnAccountSummaryEnd)
    End Sub

    Protected Overrides Sub OnAccountDownloadEnd(e As AccountDownloadEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnAccountDownloadEnd)
    End Sub

    Protected Overrides Sub OnPositionEnd(e As EventArgs)
        queueEvent(EventArgs.Empty, AddressOf MyBase.OnPositionEnd)
    End Sub

    Protected Overrides Sub OnAccountSummary(e As AccountSummaryEventArgs)
        queueEvent(e, AddressOf MyBase.OnAccountSummary)
    End Sub

    Protected Overrides Sub OnUpdateAccountValue(e As UpdateAccountValueEventArgs)
        queueEvent(e, AddressOf MyBase.OnUpdateAccountValue)
    End Sub

    Protected Overrides Sub OnUpdateAccountTime(e As UpdateAccountTimeEventArgs)
        queueEvent(e, AddressOf MyBase.OnUpdateAccountTime)
    End Sub

    Protected Overrides Sub OnAdvisorData(e As AdvisorDataEventArgs)
        queueEvent(e, AddressOf MyBase.OnAdvisorData)
    End Sub

    Protected Overrides Sub OnManagedAccounts(e As ManagedAccountsEventArgs)
        queueEvent(e, AddressOf MyBase.OnManagedAccounts)
    End Sub

    Protected Overrides Sub OnPosition(e As PositionEventArgs)
        queueEvent(e, AddressOf MyBase.OnPosition)
    End Sub

    Protected Overrides Sub OnUpdatePortfolio(e As UpdatePortfolioEventArgs)
        queueEvent(e, AddressOf MyBase.OnUpdatePortfolio)
    End Sub

#End Region

#Region "IConnectionStatusConsumer"

    Protected Overrides Sub OnConnectionStateChange(e As ApiConnectionStateChangeEventArgs)
        queueEvent(e, AddressOf MyBase.OnConnectionStateChange)
    End Sub

    Protected Overrides Sub OnCurrentTime(e As CurrentTimeEventArgs)
        queueEvent(e, AddressOf MyBase.OnCurrentTime)
    End Sub

    Protected Overrides Sub OnIBServerConnectionClosed(e As IBServerConnectionStateChangeEventArgs)
        queueEvent(e, AddressOf MyBase.OnIBServerConnectionClosed)
    End Sub

#End Region

#Region "IContractDetailsConsumer"

    Protected Overrides Sub OnSecurityDefinitionOptionParameterEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnSecurityDefinitionOptionParameterEnd)
    End Sub

    Protected Overrides Sub OnMarketRule(e As MarketRuleEventArgs)
        queueEvent(e, AddressOf MyBase.OnMarketRule)
    End Sub

    Protected Overrides Sub OnSecurityDefinitionOptionParameter(e As SecurityDefinitionOptionParameterEventArgs)
        queueEvent(e, AddressOf MyBase.OnSecurityDefinitionOptionParameter)
    End Sub

    Protected Overrides Sub OnSmartComponents(e As SmartComponentsEventArgs)
        queueEvent(e, AddressOf MyBase.OnSmartComponents)
    End Sub

    Protected Overrides Sub OnSymbolSamples(e As SymbolSamplesEventArgs)
        queueEvent(e, AddressOf MyBase.OnSymbolSamples)
    End Sub

    Protected Overrides Sub OnContractDetailsEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnContractDetailsEnd)
    End Sub

    Protected Overrides Sub OnContractDetails(e As ContractDetailsEventArgs)
        queueEvent(e, AddressOf MyBase.OnContractDetails)
    End Sub

    Protected Overrides Sub OnContractDetailsError(e As RequestErrorEventArgs)
        queueEvent(e, AddressOf MyBase.OnContractDetailsError)
    End Sub

#End Region

#Region "IDisplayGroupConsumer"

    Protected Overrides Sub OnDisplayGroupList(e As DisplayGroupListEventArgs)
        queueEvent(e, AddressOf MyBase.OnDisplayGroupList)
    End Sub

    Protected Overrides Sub OnDisplayGroupUpdated(e As DisplayGroupUpdatedEventArgs)
        queueEvent(e, AddressOf MyBase.OnDisplayGroupUpdated)
    End Sub

#End Region

#Region "IErrorAndNotificationConsumer"

    Protected Overrides Sub OnException(e As ExceptionEventArgs)
        queueEvent(e, AddressOf MyBase.OnException)
    End Sub

    Protected Overrides Sub OnApiError(e As ApiErrorEventArgs)
        queueEvent(e, AddressOf MyBase.OnApiError)
    End Sub

    Protected Overrides Sub OnApiEvent(e As ApiEventEventArgs)
        queueEvent(e, AddressOf MyBase.OnApiEvent)
    End Sub

#End Region

#Region "IFundamentalDataConsumer"


    Protected Overrides Sub OnFundamentalData(e As FundamentalDataEventArgs)
        queueEvent(e, AddressOf MyBase.OnFundamentalData)
    End Sub

#End Region

#Region "IHistDataConsumer"

    Protected Overrides Sub OnHeadTimestamp(e As HeadTimestampEventArgs)
        queueEvent(e, AddressOf MyBase.OnHeadTimestamp)
    End Sub

    Protected Overrides Sub OnHistogramData(e As HistogramDataEventArgs)
        queueEvent(e, AddressOf MyBase.OnHistogramData)
    End Sub

    Protected Overrides Sub OnHistoricalDataEnd(e As HistoricalDataRequestEventArgs)
        queueEvent(e, AddressOf MyBase.OnHistoricalDataEnd)
    End Sub

    Protected Overrides Sub OnHistoricalData(e As HistoricalDataEventArgs)
        queueEvent(e, AddressOf MyBase.OnHistoricalData)
    End Sub

    Protected Overrides Sub OnHistoricalDataError(e As RequestErrorEventArgs)
        queueEvent(e, AddressOf MyBase.OnHistoricalDataError)
    End Sub

    Protected Overrides Sub OnHistoricalDataStart(e As HistoricalDataRequestEventArgs)
        queueEvent(e, AddressOf MyBase.OnHistoricalDataStart)
    End Sub

#End Region

#Region "IMarketDataConsumer"

    Protected Overrides Sub OnRerouteMarketData(e As RerouteDataEventArgs)
        queueEvent(e, AddressOf MyBase.OnRerouteMarketData)
    End Sub

    Protected Overrides Sub OnTickRequestParams(e As TickRequestParamsEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickRequestParams)
    End Sub

    Protected Overrides Sub OnTickSnapshotEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickSnapshotEnd)
    End Sub

    Protected Overrides Sub OnMarketDataError(e As RequestErrorEventArgs)
        queueEvent(e, AddressOf MyBase.OnMarketDataError)
    End Sub

    Protected Overrides Sub OnMarketDataType(e As MarketDataTypeEventArgs)
        queueEvent(e, AddressOf MyBase.OnMarketDataType)
    End Sub

    Protected Overrides Sub OnRealtimeBar(e As RealtimeBarEventArgs)
        queueEvent(e, AddressOf MyBase.OnRealtimeBar)
    End Sub

    Protected Overrides Sub OnTickEFP(e As TickEFPEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickEFP)
    End Sub

    Protected Overrides Sub OnTickGeneric(e As TickGenericEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickGeneric)
    End Sub

    Protected Overrides Sub OnTickOptionComputation(e As TickOptionComputationEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickOptionComputation)
    End Sub

    Protected Overrides Sub OnTickPrice(e As TickPriceEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickPrice)
    End Sub

    Protected Overrides Sub OnTickSize(e As TickSizeEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickSize)
    End Sub

    Protected Overrides Sub OnTickString(e As TickStringEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickString)
    End Sub

#End Region

#Region "IMarketDepthConsumer"

    Protected Overrides Sub OnMarketDepthExchanges(e As MarketDepthExchangesEventArgs)
        queueEvent(e, AddressOf MyBase.OnMarketDepthExchanges)
    End Sub

    Protected Overrides Sub OnRerouteDepthData(e As RerouteDataEventArgs)
        queueEvent(e, AddressOf MyBase.OnRerouteDepthData)
    End Sub

    Protected Overrides Sub OnMarketDepthError(e As RequestErrorEventArgs)
        queueEvent(e, AddressOf MyBase.OnMarketDepthError)
    End Sub

    Protected Overrides Sub OnMarketDepthUpdate(e As MarketDepthUpdateEventArgs)
        queueEvent(e, AddressOf MyBase.OnMarketDepthUpdate)
    End Sub

    Protected Overrides Sub OnResetMarketDepth(e As MarketDepthRestEventArgs)
        queueEvent(e, AddressOf MyBase.OnResetMarketDepth)
    End Sub

#End Region

#Region "INewsConsumer"

    Protected Overrides Sub OnHistoricalNewsEnd(e As HistoricalNewsEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnHistoricalNewsEnd)
    End Sub

    Protected Overrides Sub OnNewsArticle(e As NewsArticleEventArgs)
        queueEvent(e, AddressOf MyBase.OnNewsArticle)
    End Sub

    Protected Overrides Sub OnHistoricalNews(e As HistoricalNewsEventArgs)
        queueEvent(e, AddressOf MyBase.OnHistoricalNews)
    End Sub

    Protected Overrides Sub OnNewsProviders(e As NewsProvidersEventArgs)
        queueEvent(e, AddressOf MyBase.OnNewsProviders)
    End Sub

    Protected Overrides Sub OnTickNews(e As TickNewsEventArgs)
        queueEvent(e, AddressOf MyBase.OnTickNews)
    End Sub

    Protected Overrides Sub OnNewsBulletin(e As NewsBulletinEventArgs)
        queueEvent(e, AddressOf MyBase.OnNewsBulletin)
    End Sub

#End Region

#Region "IOrderInfoConsumer"

    Protected Overrides Sub OnExecutionDetailsEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnExecutionDetailsEnd)
    End Sub

    Protected Overrides Sub OnOpenOrderEnd(e As EventArgs)
        queueEvent(e, AddressOf MyBase.OnOpenOrderEnd)
    End Sub

    Protected Overrides Sub OnCommissionReport(e As CommissionReportEventArgs)
        queueEvent(e, AddressOf MyBase.OnCommissionReport)
    End Sub

    Protected Overrides Sub OnDeltaNeutralValidation(e As DeltaNeutralValidationEventArgs)
        queueEvent(e, AddressOf MyBase.OnDeltaNeutralValidation)
    End Sub

    Protected Overrides Sub OnOrderError(e As OrderErrorEventArgs)
        queueEvent(e, AddressOf MyBase.OnOrderError)
    End Sub

    Protected Overrides Sub OnExecutionDetails(e As ExecutionDetailsEventArgs)
        queueEvent(e, AddressOf MyBase.OnExecutionDetails)
    End Sub

    Protected Overrides Sub OnOpenOrder(e As OpenOrderEventArgs)
        queueEvent(e, AddressOf MyBase.OnOpenOrder)
    End Sub

    Protected Overrides Sub OnOrderStatus(e As OrderStatusEventArgs)
        queueEvent(e, AddressOf MyBase.OnOrderStatus)
    End Sub

#End Region

#Region "IPerformanceDataConsumer"

    Protected Overrides Sub OnPerformanceStatsUpdate(e As PerformanceStatsUpdateEventArgs)
        queueEvent(e, AddressOf MyBase.OnPerformanceStatsUpdate)
    End Sub

#End Region

#Region "IScannerDataConsumer"

    Protected Overrides Sub OnScannerDataEnd(e As RequestEndEventArgs)
        queueEvent(e, AddressOf MyBase.OnScannerDataEnd)
    End Sub

    Protected Overrides Sub OnScannerData(e As ScannerDataEventArgs)
        queueEvent(e, AddressOf MyBase.OnScannerData)
    End Sub

    Protected Overrides Sub OnScannerParameters(e As ScannerParametersEventArgs)
        queueEvent(e, AddressOf MyBase.OnScannerParameters)
    End Sub

#End Region

#Region "Helper functions"

    Private Sub queueEvent(e As EventArgs, eventHandler As Action(Of EventArgs))
        Dim entry = New QueueEntry(Of EventArgs) With {.e = e, .eventHandler = eventHandler}
        mQueue.Add(entry)
    End Sub

    Private Sub dispatchLoop()
        For Each entry In mQueue.GetConsumingEnumerable()
            dispatchItem(entry)
        Next
    End Sub

    Private Sub dispatchItem(entry As QueueEntry(Of EventArgs))
        If mSyncContext Is Nothing Then
            entry.eventHandler(entry.e)
        Else
            mSyncContext.Post(Sub() entry.eventHandler(entry.e), Nothing)
        End If
    End Sub

#End Region

End Class
