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

Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Threading
Imports System.Threading.Tasks

''' <summary>
''' This class provides the Application Programming Interface to Interactive Brokers' 
''' Trader Workstation and Gateway products.
''' </summary>
Public Class IBAPI
    Implements IDisposable

#Region "Constants"

    Private Const ModuleName As String = NameOf(IBAPI)

    Public Const MaxContractRequestId As Integer = IdManager.MaxCallersContractRequestId
    Public Const MaxExecutionsRequestId As Integer = IdManager.MaxCallersExecutionsRequestId
    Public Const MaxHistoricalDataRequestId As Integer = IdManager.MaxCallersHistoricalDataRequestId
    Public Const MaxMarketDataRequestId As Integer = IdManager.MaxCallersMarketDataRequestId
    Public Const MaxMarketDepthRequestId As Integer = IdManager.MaxCallersMarketDepthRequestId

#End Region

#Region "Member variables"

    Private mServer As String
    Private mPort As Integer
    Private mClientID As Integer

    Private mUseSSL As Boolean
    Private mUseV100Plus As Boolean

    Private mCallbackHandler As CallbackHandler

    Private mIdManager As New IdManager

    Private mCancellationSource As CancellationTokenSource
    Friend Property Scheduler As TaskScheduler
    Private mSyncContext As SynchronizationContext

    Private mConnectionManager As ApiConnectionManager

    Private mEventConsumers As New ApiEventConsumers

    Private mRegistry As New GeneratorAndParserRegistry

    Private mInMessageHandler As InputMessageHandler = New InputMessageHandler(mEventConsumers, mRegistry)

    Private mStatsRecorder As PerformanceStatsRecorder = New PerformanceStatsRecorder(mEventConsumers)

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
                   Optional useLegacyProtocol As Boolean = False)
        Logger = New NullLogger
        PerformanceLogger = New NullLogger
        SocketLogger = New NullLogger

        If Not (port > 0) Then Throw New ArgumentException("Port must be > 0")
        If Not (clientId >= 0) Then Throw New ArgumentException("ClientID must be >= 0")
        If String.IsNullOrEmpty(server) Then server = "127.0.0.1"

        mServer = server
        mPort = port
        mClientID = clientId

        If Not disableEventSource Then mCallbackHandler = registerCallbackHandler(New EventSource())
        Me.SyncContext = syncContext
        mUseSSL = useSSL
        mUseV100Plus = Not useLegacyProtocol

        mConnectionManager = New ApiConnectionManager(mServer, mPort, mClientID, mUseV100Plus, mRegistry, mEventConsumers)
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

#Region "Properties"

    Public Property AccountDataConsumer() As IAccountDataConsumer
        Get
            AccountDataConsumer = mEventConsumers.AccountDataConsumer
        End Get
        Set(Value As IAccountDataConsumer)
            mEventConsumers.AccountDataConsumer = Value
        End Set
    End Property

    Public ReadOnly Property ClientID() As Integer
        Get
            ClientID = mClientID
        End Get
    End Property


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
            Return mEventConsumers.HistDataConsumer
        End Get
        Set(Value As IHistoricalDataConsumer)
            mEventConsumers.HistDataConsumer = Value
        End Set
    End Property

    Public WriteOnly Property Logger As ILogger
        Set
            EventLogger = Value
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

    Public ReadOnly Property NextOrderId() As Integer
        Get
            NextOrderId = mIdManager.NextOrderId
        End Get
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

    Public WriteOnly Property PerformanceLogger As ILogger
        Set
            mStatsRecorder.Logger = Value
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
        Set(Value As IScannerDataConsumer)
            mEventConsumers.ScannerDataConsumer = Value
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

    Public WriteOnly Property SocketLogger As ILogger
        Set
            Globals.SocketLogger = Value
        End Set
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

    Public Shared Function IsContractExpired(pContract As Contract) As Boolean
        If pContract.SecType = SecurityType.Cash Or pContract.SecType = SecurityType.Index Or pContract.SecType = SecurityType.Stock Then Return False

        Return contractExpiryToDate(pContract) < Now
    End Function

    Friend Shared Function UnixTimestampToDateTime(unixTimestamp As Long) As DateTime
        Dim unixBaseTime = New DateTime(1970, 1, 1, 0, 0, 0, 0)
        Return unixBaseTime.AddSeconds(unixTimestamp)
    End Function

#End Region

#Region "Methods"

    Public Sub CalculateImpliedVolatility(pReqId As Integer, pContract As Contract, pOptionPrice As Double, pUnderPrice As Double)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CalculateImpliedVolatility, {pReqId, pContract, pOptionPrice, pUnderPrice})
    End Sub

    Public Sub CalculateOptionPrice(pReqId As Integer, pContract As Contract, pVolatility As Double, pUnderPrice As Double)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CalculateOptionPrice, {pReqId, pContract, pVolatility, pUnderPrice})
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

    Public Sub CancelDailyPnL(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelDailyPnL, {requestId})
    End Sub

    Sub CancelDailyPnLSingle(requestId As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.CancelDailyPnLSingle, {requestId})
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

    Public Sub Connect(Optional useSSL As Boolean = False)
        mCancellationSource = New CancellationTokenSource()
        Dim lreader = mConnectionManager.Connect(AddressOf startInputMessageHandler,
                                                mCancellationSource,
                                                mUseSSL)

        mInMessageHandler.Initialise(lreader, mStatsRecorder)
        mInMessageHandler.Reset()

        mRegistry.Initialise(mIdManager,
                             mEventConsumers,
                             lreader,
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

    Public Sub Disconnect(pReason As String)
        mConnectionManager.Disconnect(pReason)

        mStatsRecorder?.StopRecording()
    End Sub

    Public Sub ExerciseOptions(pTickerId As Integer, pContract As Contract, pExerciseAction As Integer, pExerciseQuantity As Integer, pAccount As String, pOverride As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.ExerciseOptions, {pTickerId, pContract, pExerciseAction, pExerciseQuantity, pAccount, pOverride})
    End Sub

    Public Sub PlaceOrder(pOrder As Order, pContract As Contract)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.PlaceOrder, {pOrder, pContract})
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
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestContractData, {pRequestId, pContract})
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

    Public Sub RequestHistoricalData(pRequestId As Integer, pRequest As HistoricalDataRequest, Optional useRTH As Boolean = False, Optional keepUpToDate As Boolean = False, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestHistoricalData, {pRequestId, pRequest, useRTH, keepUpToDate, options})
    End Sub

    Public Sub RequestHistoricalNews(requestId As Integer, conid As Integer, providerCodes As String, startTime As Date, endTime As Date, maxResults As Integer)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestHistoricalNews, {requestId, conid, providerCodes, startTime, endTime, maxResults})
    End Sub

    Public Sub RequestManagedAccounts()
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestManagedAccounts, Nothing)
    End Sub

    Public Sub RequestMarketData(pTickerId As Integer, pContract As Contract, Optional pGenericTicks As String = "", Optional pSnapshot As Boolean = False, Optional regulatorySnapshot As Boolean = False, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestMarketData, {pTickerId, pContract, pGenericTicks, pSnapshot, regulatorySnapshot, options})
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

    Public Sub RequestNewsArticle(requestId As Integer, providerCode As String, articleId As String)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestNewsArticle, {requestId, providerCode, articleId})
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

    Public Sub RequestScannerSubscription(pTickerId As Integer, pSubscription As ScannerSubscription, Optional options As List(Of TagValue) = Nothing)
        mRegistry.InvokeGenerator(ApiSocketOutMsgType.RequestScannerSubscription, {pTickerId, pSubscription, options})
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

    Public Sub SetLogLevel(pLogLevel As ApiLogLevel)
        mConnectionManager.SetLogLevel(pLogLevel)
    End Sub

    Public Sub SetPerformanceDataCollection(logger As ILogger)
        SetPerformanceDataCollection(logger, Nothing)
    End Sub

    Public Sub SetPerformanceDataCollection(performanceDataConsumer As IPerformanceDataConsumer)
        SetPerformanceDataCollection(Nothing, performanceDataConsumer)
    End Sub

    Public Sub SetPerformanceDataCollection(logger As ILogger, performanceDataConsumer As IPerformanceDataConsumer)
        mStatsRecorder.Logger = logger
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
        If Len(pContract.Expiry) = 8 Then Return CDate($"{Left(pContract.Expiry, 4)}/{Mid(pContract.Expiry, 5, 2)}/{Right(pContract.Expiry, 2)}")
        If Len(pContract.Expiry) = 6 Then Return CDate($"{Left(pContract.Expiry, 4)}/{Mid(pContract.Expiry, 5, 2)}/01")
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
            EventLogger.Log($"Failed loading generators: {e.ToString}")
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
            EventLogger.Log($"Failed loading parsers: {e.ToString}")
            Throw
        End Try
    End Sub

    Private Sub startInputMessageHandler()
        mInMessageHandler.Start(Scheduler, mCancellationSource, Sub() mConnectionManager.Disconnect("Message processing completed"))
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
        Return handler
    End Function

#End Region

End Class