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
' the base methods to the eventHandler Delegate in the QueueEntry structure (see the
' section on Relaxed Delegate Conversion (Visual Basic) in the Microsoft Visual Basic
' documentation at https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion).
Option Strict Off

Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Imports TradeWright.IBAPI

Public Class QueueingCallbackHandler
    Inherits CallbackHandler
    Implements IAccountDataConsumer,
        IConnectionStatusConsumer,
        IContractDetailsConsumer,
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

    Private mEv As CallbackHandler

    Private Structure QueueEntry(Of T As EventArgs)
        Dim E As T
        Dim EventHandler As Action(Of T)
    End Structure

    Private mQueue As BlockingCollection(Of QueueEntry(Of EventArgs)) = New BlockingCollection(Of QueueEntry(Of EventArgs))()

    Private mSyncContext As SynchronizationContext

    Private mCancellationTokenSource As CancellationTokenSource

    Private mDispatcher As Task

    Public Sub New(Ev As CallbackHandler, syncContext As SynchronizationContext)
        mEv = Ev

        If syncContext Is Nothing Then Throw New ArgumentNullException(NameOf(syncContext))
        mSyncContext = syncContext

        Start()
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        Static disposed As Boolean
        If disposed Then Exit Sub
        disposed = True

        If disposing Then
            Pause()
            mQueue.Dispose()
        End If

        MyBase.Dispose()
    End Sub

#Region "IAccountDataConsumer"

    Public Overrides Sub EndAccountSummary(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndAccountSummary
        queueEvent(e, AddressOf mEv.EndAccountSummary)
    End Sub

    Public Overrides Sub EndAccountUpdateMulti(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndAccountUpdateMulti
        queueEvent(e, AddressOf mEv.EndAccountUpdateMulti)
    End Sub

    Public Overrides Sub EndAccountValue(e As AccountDownloadEndEventArgs) Implements IAccountDataConsumer.EndAccountValue
        queueEvent(e, AddressOf mEv.EndAccountValue)
    End Sub

    Public Overrides Sub EndPosition(e As EventArgs) Implements IAccountDataConsumer.EndPosition
        queueEvent(e, AddressOf mEv.EndPosition)
    End Sub

    Public Overrides Sub EndPositionMulti(e As RequestEndEventArgs) Implements IAccountDataConsumer.EndPositionMulti
        queueEvent(e, AddressOf mEv.EndPositionMulti)
    End Sub

    Public Overrides Sub NotifyAccountSummary(e As AccountSummaryEventArgs) Implements IAccountDataConsumer.NotifyAccountSummary
        queueEvent(e, AddressOf mEv.NotifyAccountSummary)
    End Sub

    Public Overrides Sub NotifyAccountValue(e As UpdateAccountValueEventArgs) Implements IAccountDataConsumer.NotifyAccountValue
        queueEvent(e, AddressOf mEv.NotifyAccountValue)
    End Sub

    Public Overrides Sub NotifyAccountTime(e As UpdateAccountTimeEventArgs) Implements IAccountDataConsumer.NotifyAccountTime
        queueEvent(e, AddressOf mEv.NotifyAccountTime)
    End Sub

    Public Overrides Sub NotifyAccountUpdateMulti(e As AccountUpdateMultiEventArgs) Implements IAccountDataConsumer.NotifyAccountUpdateMulti
        queueEvent(e, AddressOf mEv.NotifyAccountUpdateMulti)
    End Sub

    Public Overrides Sub NotifyAdvisorData(e As AdvisorDataEventArgs) Implements IAccountDataConsumer.NotifyAdvisorData
        queueEvent(e, AddressOf mEv.NotifyAdvisorData)
    End Sub

    Public Overrides Sub NotifyPnL(e As PnLEventArgs) Implements IAccountDataConsumer.NotifyPnL
        queueEvent(e, AddressOf mEv.NotifyPnL)
    End Sub

    Public Overrides Sub NotifyPnLSingle(e As PnLSingleEventArgs) Implements IAccountDataConsumer.NotifyPnLSingle
        queueEvent(e, AddressOf mEv.NotifyPnLSingle)
    End Sub

    Public Overrides Sub NotifyFamilyCodes(e As FamilyCodesEventArgs) Implements IAccountDataConsumer.NotifyFamilyCodes
        queueEvent(e, AddressOf mEv.NotifyFamilyCodes)
    End Sub

    Public Overrides Sub NotifyManagedAccounts(e As ManagedAccountsEventArgs) Implements IAccountDataConsumer.NotifyManagedAccounts
        queueEvent(e, AddressOf mEv.NotifyManagedAccounts)
    End Sub

    Public Overrides Sub NotifyPortfolioUpdate(e As UpdatePortfolioEventArgs) Implements IAccountDataConsumer.NotifyPortfolioUpdate
        queueEvent(e, AddressOf mEv.NotifyPortfolioUpdate)
    End Sub

    Public Overrides Sub NotifyPosition(e As PositionEventArgs) Implements IAccountDataConsumer.NotifyPosition
        queueEvent(e, AddressOf mEv.NotifyPosition)
    End Sub

    Public Overrides Sub NotifyPositionMulti(e As PositionMultiEventArgs) Implements IAccountDataConsumer.NotifyPositionMulti
        queueEvent(e, AddressOf mEv.NotifyPositionMulti)
    End Sub

    Public Overrides Sub NotifySoftDollarTiers(e As SoftDollarTiersEventArgs) Implements IAccountDataConsumer.NotifySoftDollarTiers
        queueEvent(e, AddressOf mEv.NotifySoftDollarTiers)
    End Sub

#End Region

#Region "IConnectionStatusConsumer"

    Public Overrides Sub NotifyAPIConnectionStateChange(e As ApiConnectionStateChangeEventArgs) Implements IConnectionStatusConsumer.NotifyAPIConnectionStateChange
        queueEvent(e, AddressOf mEv.NotifyAPIConnectionStateChange)
    End Sub

    Public Overrides Sub NotifyCurrentTime(e As CurrentTimeEventArgs) Implements IConnectionStatusConsumer.NotifyCurrentTime
        queueEvent(e, AddressOf mEv.NotifyCurrentTime)
    End Sub

    Public Overrides Sub NotifyIBServerConnectionStateChange(e As IBServerConnectionStateChangeEventArgs) Implements IConnectionStatusConsumer.NotifyIBServerConnectionStateChange
        queueEvent(e, AddressOf mEv.NotifyIBServerConnectionStateChange)
    End Sub

#End Region

#Region "IContractDetailsConsumer"

    Public Overrides Sub EndContractDetails(e As RequestEndEventArgs) Implements IContractDetailsConsumer.EndContractDetails
        queueEvent(e, AddressOf mEv.EndContractDetails)
    End Sub

    Public Overrides Sub EndSecurityDefinitionOptionParameter(e As RequestEndEventArgs) Implements IContractDetailsConsumer.EndSecurityDefinitionOptionParameter
        queueEvent(e, AddressOf mEv.EndSecurityDefinitionOptionParameter)
    End Sub

    Public Overrides Sub NotifyContract(e As ContractDetailsEventArgs) Implements IContractDetailsConsumer.NotifyContract
        queueEvent(e, AddressOf mEv.NotifyContract)
    End Sub

    Public Overrides Sub NotifyContractError(e As RequestErrorEventArgs) Implements IContractDetailsConsumer.NotifyContractError
        queueEvent(e, AddressOf mEv.NotifyContractError)
    End Sub

    Public Overrides Sub NotifyMarketRule(e As MarketRuleEventArgs) Implements IContractDetailsConsumer.NotifyMarketRule
        queueEvent(e, AddressOf mEv.NotifyMarketRule)
    End Sub

    Public Overrides Sub NotifySecurityDefinitionOptionParameter(e As SecurityDefinitionOptionParameterEventArgs) Implements IContractDetailsConsumer.NotifySecurityDefinitionOptionParameter
        queueEvent(e, AddressOf mEv.NotifySecurityDefinitionOptionParameter)
    End Sub

    Public Overrides Sub NotifySmartComponents(e As SmartComponentsEventArgs) Implements IContractDetailsConsumer.NotifySmartComponents
        queueEvent(e, AddressOf mEv.NotifySmartComponents)
    End Sub

    Public Overrides Sub NotifySymbolSamples(e As SymbolSamplesEventArgs) Implements IContractDetailsConsumer.NotifySymbolSamples
        queueEvent(e, AddressOf mEv.NotifySymbolSamples)
    End Sub

#End Region

#Region "IErrorAndNotificationConsumer"

    Public Overrides Sub NotifyException(e As ExceptionEventArgs) Implements IErrorAndNotificationConsumer.NotifyException
        queueEvent(e, AddressOf mEv.NotifyException)
    End Sub

    Public Overrides Sub NotifyApiError(e As ApiErrorEventArgs) Implements IErrorAndNotificationConsumer.NotifyApiError
        queueEvent(e, AddressOf mEv.NotifyApiError)
    End Sub

    Public Overrides Sub NotifyApiEvent(e As ApiEventEventArgs) Implements IErrorAndNotificationConsumer.NotifyApiEvent
        queueEvent(e, AddressOf mEv.NotifyApiEvent)
    End Sub

#End Region

#Region "IFundamentalDataConsumer"

    Public Overrides Sub NotifyFundamentalData(e As FundamentalDataEventArgs) Implements IFundamentalDataConsumer.NotifyFundamentalData
        queueEvent(e, AddressOf mEv.NotifyFundamentalData)
    End Sub

#End Region

#Region "IHistDataConsumer"

    Public Overrides Sub EndHistoricalData(e As HistoricalDataRequestEventArgs) Implements IHistoricalDataConsumer.EndHistoricalData
        queueEvent(e, AddressOf mEv.EndHistoricalData)
    End Sub

    Public Overrides Sub NotifyHeadTimestamp(e As HeadTimestampEventArgs) Implements IHistoricalDataConsumer.NotifyHeadTimestamp
        queueEvent(e, AddressOf mEv.NotifyHeadTimestamp)
    End Sub

    Public Overrides Sub NotifyHistogramData(e As HistogramDataEventArgs) Implements IHistoricalDataConsumer.NotifyHistogramData
        queueEvent(e, AddressOf mEv.NotifyHistogramData)
    End Sub

    Public Overrides Sub NotifyHistoricalData(e As HistoricalDataEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalData
        queueEvent(e, AddressOf mEv.NotifyHistoricalData)
    End Sub

    Public Overrides Sub NotifyHistoricalDataError(e As RequestErrorEventArgs) Implements IHistoricalDataConsumer.NotifyHistoricalDataError
        queueEvent(e, AddressOf mEv.NotifyHistoricalDataError)
    End Sub

    Public Overrides Sub StartHistoricalData(e As HistoricalDataRequestEventArgs) Implements IHistoricalDataConsumer.StartHistoricalData
        queueEvent(e, AddressOf mEv.StartHistoricalData)
    End Sub

    Public Overrides Sub UpdateHistoricalData(e As HistoricalDataEventArgs) Implements IHistoricalDataConsumer.UpdateHistoricalData
        queueEvent(e, AddressOf mEv.UpdateHistoricalData)
    End Sub

#End Region

#Region "IMarketDataConsumer"

    Public Overrides Sub EndTickSnapshot(e As RequestEndEventArgs) Implements IMarketDataConsumer.EndTickSnapshot
        queueEvent(e, AddressOf mEv.EndTickSnapshot)
    End Sub

    Public Overrides Sub NotifyMarketDataError(e As RequestErrorEventArgs) Implements IMarketDataConsumer.NotifyMarketDataError
        queueEvent(e, AddressOf mEv.NotifyMarketDataError)
    End Sub

    Public Overrides Sub NotifyMarketDataType(e As MarketDataTypeEventArgs) Implements IMarketDataConsumer.NotifyMarketDataType
        queueEvent(e, AddressOf mEv.NotifyMarketDataType)
    End Sub

    Public Overrides Sub NotifyRealtimeBar(e As RealtimeBarEventArgs) Implements IMarketDataConsumer.NotifyRealtimeBar
        queueEvent(e, AddressOf mEv.NotifyRealtimeBar)
    End Sub

    Public Overrides Sub NotifyRerouteData(e As RerouteDataEventArgs) Implements IMarketDataConsumer.NotifyRerouteData
        queueEvent(e, AddressOf mEv.NotifyRerouteData)
    End Sub

    Public Overrides Sub NotifyTickEFP(e As TickEFPEventArgs) Implements IMarketDataConsumer.NotifyTickEFP
        queueEvent(e, AddressOf mEv.NotifyTickEFP)
    End Sub

    Public Overrides Sub NotifyTickGeneric(e As TickGenericEventArgs) Implements IMarketDataConsumer.NotifyTickGeneric
        queueEvent(e, AddressOf mEv.NotifyTickGeneric)
    End Sub

    Public Overrides Sub NotifyTickOptionComputation(e As TickOptionComputationEventArgs) Implements IMarketDataConsumer.NotifyTickOptionComputation
        queueEvent(e, AddressOf mEv.NotifyTickOptionComputation)
    End Sub

    Public Overrides Sub NotifyTickPrice(e As TickPriceEventArgs) Implements IMarketDataConsumer.NotifyTickPrice
        queueEvent(e, AddressOf mEv.NotifyTickPrice)
    End Sub

    Public Overrides Sub NotifyTickRequestParams(e As TickRequestParamsEventArgs) Implements IMarketDataConsumer.NotifyTickRequestParams
        queueEvent(e, AddressOf mEv.NotifyTickRequestParams)
    End Sub

    Public Overrides Sub NotifyTickSize(e As TickSizeEventArgs) Implements IMarketDataConsumer.NotifyTickSize
        queueEvent(e, AddressOf mEv.NotifyTickSize)
    End Sub

    Public Overrides Sub NotifyTickString(e As TickStringEventArgs) Implements IMarketDataConsumer.NotifyTickString
        queueEvent(e, AddressOf mEv.NotifyTickString)
    End Sub

#End Region

#Region "IMarketDepthConsumer"

    Public Overrides Sub NotifyMarketDepth(e As MarketDepthUpdateEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepth
        queueEvent(e, AddressOf mEv.NotifyMarketDepth)
    End Sub

    Public Overrides Sub NotifyMarketDepthError(e As RequestErrorEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthError
        queueEvent(e, AddressOf mEv.NotifyMarketDepthError)
    End Sub

    Public Overrides Sub NotifyMarketDepthExchanges(e As MarketDepthExchangesEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthExchanges
        queueEvent(e, AddressOf mEv.NotifyMarketDepthExchanges)
    End Sub

    Public Overrides Sub NotifyRerouteDepthData(e As RerouteDataEventArgs) Implements IMarketDepthConsumer.NotifyRerouteData
        queueEvent(e, AddressOf mEv.NotifyRerouteDepthData)
    End Sub

    Public Overrides Sub NotifyMarketDepthReset(e As MarketDepthRestEventArgs) Implements IMarketDepthConsumer.NotifyMarketDepthReset
        queueEvent(e, AddressOf mEv.NotifyMarketDepthReset)
    End Sub

#End Region

#Region "INewsConsumer"

    Public Overrides Sub EndHistoricalNews(e As HistoricalNewsEndEventArgs) Implements INewsConsumer.EndHistoricalNews
        queueEvent(e, AddressOf mEv.EndHistoricalNews)
    End Sub

    Public Overrides Sub NotifyHistoricalNews(e As HistoricalNewsEventArgs) Implements INewsConsumer.NotifyHistoricalNews
        queueEvent(e, AddressOf mEv.NotifyHistoricalNews)
    End Sub

    Public Overrides Sub NotifyNewsArticle(e As NewsArticleEventArgs) Implements INewsConsumer.NotifyNewsArticle
        queueEvent(e, AddressOf mEv.NotifyNewsArticle)
    End Sub

    Public Overrides Sub NotifyNewsBulletin(e As NewsBulletinEventArgs) Implements INewsConsumer.NotifyNewsBulletin
        queueEvent(e, AddressOf mEv.NotifyNewsBulletin)
    End Sub

    Public Overrides Sub NotifyNewsProviders(e As NewsProvidersEventArgs) Implements INewsConsumer.NotifyNewsProviders
        queueEvent(e, AddressOf mEv.NotifyNewsProviders)
    End Sub

    Public Overrides Sub NotifyTickNews(e As TickNewsEventArgs) Implements INewsConsumer.NotifyTickNews
        queueEvent(e, AddressOf mEv.NotifyTickNews)
    End Sub

#End Region

#Region "IOrderInfoConsumer"

    Public Overrides Sub EndExecutions(e As RequestEndEventArgs) Implements IOrderInfoConsumer.EndExecutions
        queueEvent(e, AddressOf mEv.EndExecutions)
    End Sub

    Public Overrides Sub EndOpenOrders(e As EventArgs) Implements IOrderInfoConsumer.EndOpenOrders
        queueEvent(e, AddressOf mEv.EndOpenOrders)
    End Sub

    Public Overrides Sub NotifyCommissionReport(e As CommissionReportEventArgs) Implements IOrderInfoConsumer.NotifyCommissionReport
        queueEvent(e, AddressOf mEv.NotifyCommissionReport)
    End Sub

    Public Overrides Sub NotifyDeltaNeutralValidation(e As DeltaNeutralValidationEventArgs) Implements IOrderInfoConsumer.NotifyDeltaNeutralValidation
        queueEvent(e, AddressOf mEv.NotifyDeltaNeutralValidation)
    End Sub

    Public Overrides Sub NotifyExecution(e As ExecutionDetailsEventArgs) Implements IOrderInfoConsumer.NotifyExecution
        queueEvent(e, AddressOf mEv.NotifyExecution)
    End Sub

    Public Overrides Sub NotifyOpenOrder(e As OpenOrderEventArgs) Implements IOrderInfoConsumer.NotifyOpenOrder
        queueEvent(e, AddressOf mEv.NotifyOpenOrder)
    End Sub

    Public Overrides Sub NotifyOrderError(e As OrderErrorEventArgs) Implements IOrderInfoConsumer.NotifyOrderError
        queueEvent(e, AddressOf mEv.NotifyOrderError)
    End Sub

    Public Overrides Sub NotifyOrderStatus(e As OrderStatusEventArgs) Implements IOrderInfoConsumer.NotifyOrderStatus
        queueEvent(e, AddressOf mEv.NotifyOrderStatus)
    End Sub

#End Region

#Region "IPerformanceDataConsumer"

    Public Overrides Sub NotifyPerformanceStats(e As PerformanceStatsUpdateEventArgs) Implements IPerformanceDataConsumer.NotifyPerformanceStats
        queueEvent(e, AddressOf mEv.NotifyPerformanceStats)
    End Sub

#End Region

#Region "IScannerDataConsumer"

    Public Overrides Sub EndScannerData(e As RequestEndEventArgs) Implements IScannerDataConsumer.EndScannerData
        queueEvent(e, AddressOf mEv.EndScannerData)
    End Sub

    Public Overrides Sub NotifyScannerData(e As ScannerDataEventArgs) Implements IScannerDataConsumer.NotifyScannerData
        queueEvent(e, AddressOf mEv.NotifyScannerData)
    End Sub

    Public Overrides Sub NotifyScannerParameters(e As ScannerParametersEventArgs) Implements IScannerDataConsumer.NotifyScannerParameters
        queueEvent(e, AddressOf mEv.NotifyScannerParameters)
    End Sub

#End Region

#Region "ISocketDataConsumer"

    ' We don't queue these methods as the sending and receiving of messages continues regardless of whether
    ' our queue is paused

    Public Overrides Sub NotifySocketInputData(e As SocketDataEventArgs) Implements ISocketDataConsumer.NotifySocketInputData
        mEv.NotifySocketInputData(e)
    End Sub

    Public Overrides Sub NotifySocketInputMessage(e As ApiMessageEventArgs) Implements ISocketDataConsumer.NotifySocketInputMessage
        mEv.NotifySocketInputMessage(e)
    End Sub

    Public Overrides Sub NotifySocketOutputData(e As SocketDataEventArgs) Implements ISocketDataConsumer.NotifySocketOutputData
        mEv.NotifySocketOutputData(e)
    End Sub

    Public Overrides Sub NotifySocketOutputMessage(e As ApiMessageEventArgs) Implements ISocketDataConsumer.NotifySocketOutputMessage
        mEv.NotifySocketOutputMessage(e)
    End Sub

#End Region

#Region "Methods"

    Public Sub Start()
        mCancellationTokenSource = New CancellationTokenSource()
        mDispatcher = Task.Factory.StartNew(Sub() dispatchLoop(mCancellationTokenSource.Token))
    End Sub

    Public Sub Pause()
        mCancellationTokenSource.Cancel()
        mCancellationTokenSource.Dispose()
    End Sub

#End Region

#Region "Helper functions"

    Private Sub queueEvent(e As EventArgs, eventHandler As Action(Of EventArgs))
        Dim entry = New QueueEntry(Of EventArgs) With {.E = e, .EventHandler = eventHandler}
        mQueue.Add(entry)
    End Sub

    Private Sub dispatchLoop(token As CancellationToken)
        For Each entry In mQueue.GetConsumingEnumerable(token)
            If token.IsCancellationRequested Then Exit For
            dispatchItem(entry)
        Next
    End Sub

    Private Sub dispatchItem(entry As QueueEntry(Of EventArgs))
        If mSyncContext Is Nothing Then
            entry.EventHandler(entry.E)
        Else
            mSyncContext.Post(Sub() entry.EventHandler(entry.E), Nothing)
        End If
    End Sub

#End Region


End Class
