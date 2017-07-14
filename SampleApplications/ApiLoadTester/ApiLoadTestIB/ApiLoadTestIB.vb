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

Imports ApiLoadTestUI
Imports IBApi

Imports System.Threading

Public Class ApiLoadTestIB
    Implements EWrapper
    Implements IApiLoadTestController

    Private mSignal As New EReaderMonitorSignal()
    Private mIBApi As EClientSocket

    Private mNextMarketDataTickerId As Integer
    Private mNextMarketDepthTickerId As Integer

    Private mUI As UI

    Public Sub New(ui As UI)
        mUI = ui

        mUI.TitleQualifer = "IB API"
        mUI.ClientId = 13243578
    End Sub

#Region "Properties"

    Public ReadOnly Property EnableUseV100ProtocolCheckbox As Boolean Implements IApiLoadTestController.EnableUseV100ProtocolCheckbox
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property EnableUseQueueingCallbackHandlerCheckbox As Boolean Implements IApiLoadTestController.EnableUseQueueingCallbackHandlerCheckbox
        Get
            Return False
        End Get
    End Property

#End Region

#Region "IApiLoadTestController Interface"

    Private Sub Connect(server As String, port As Integer, clientId As Integer) Implements IApiLoadTestController.Connect
        mIBApi = New EClientSocket(Me, mSignal)
        If Not mUI.UseV100Protocol Then mIBApi.DisableUseV100Plus()

        Dim s = DirectCast(mIBApi, EClientSocket)
        s.eConnect(server, port, clientId, False)

        Dim reader = New EReader(mIBApi, mSignal)
        reader.Start()

        Dim t = New Thread(Sub()
                               Do While mIBApi.IsConnected()
                                   mSignal.waitForSignal()
                                   reader.processMsgs()
                               Loop
                           End Sub) With {.IsBackground = True}
        t.Start()

        mNextMarketDataTickerId = 0
    End Sub

    Private Sub Disconnect() Implements IApiLoadTestController.Disconnect
        mIBApi?.eDisconnect()
    End Sub

    Private Function StartTicker(symbol As String, secType As String, expiry As String, exchange As String, currencyCode As String, primaryExchange As String, multiplier As Integer, marketDepth As Boolean) As Integer Implements IApiLoadTestController.StartTicker
        Dim contract = New Contract() With {.Symbol = symbol, .SecType = secType, .LastTradeDateOrContractMonth = expiry, .Exchange = exchange, .Currency = currencyCode, .PrimaryExch = primaryExchange, .Multiplier = If(multiplier = 0 Or multiplier = 1, "", CStr(multiplier))}
        mIBApi.reqMktData(mNextMarketDataTickerId, contract, "", False, False, Nothing)
        mNextMarketDataTickerId += 1
        If marketDepth Then
            mIBApi.reqMarketDepth(mNextMarketDepthTickerId, contract, 20, Nothing)
            mNextMarketDepthTickerId += 1
        End If
        Return mNextMarketDataTickerId - 1
    End Function

    Private Sub StopTickers() Implements IApiLoadTestController.StopTickers
        For i = 0 To mNextMarketDataTickerId - 1
            mIBApi.cancelMktData(i)
            mUI.LogMessage("Stopping ticker " & i)
        Next
        mNextMarketDataTickerId = 0

        For i = 0 To mNextMarketDepthTickerId - 1
            mIBApi.cancelMktDepth(i)
            mUI.LogMessage("Stopping market depth " & i)
        Next
        mNextMarketDepthTickerId = 0
    End Sub

#End Region

#Region "EWrapper Interface"

    Public Sub [Error](e As Exception) Implements EWrapper.error
        mUI.HandleException(e)
    End Sub

    Public Sub [Error](str As String) Implements EWrapper.error
        mUI.LogMessage(str)
    End Sub

    Public Sub [Error](id As Integer, errorCode As Integer, errorMsg As String) Implements EWrapper.error
        mUI.LogMessage("Error " & errorCode & "(" & id & ") :  " & errorMsg)
    End Sub

    Public Sub CurrentTime(time As Long) Implements EWrapper.currentTime
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickPrice(tickerId As Integer, field As Integer, price As Double, attribs As TickAttrib) Implements EWrapper.tickPrice
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickSize(tickerId As Integer, field As Integer, size As Integer) Implements EWrapper.tickSize
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickString(tickerId As Integer, field As Integer, value As String) Implements EWrapper.tickString
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickGeneric(tickerId As Integer, field As Integer, value As Double) Implements EWrapper.tickGeneric
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickEFP(tickerId As Integer, tickType As Integer, basisPoints As Double, formattedBasisPoints As String, impliedFuture As Double, holdDays As Integer, futureLastTradeDate As String, dividendImpact As Double, dividendsToLastTradeDate As Double) Implements EWrapper.tickEFP
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub DeltaNeutralValidation(reqId As Integer, underComp As UnderComp) Implements EWrapper.deltaNeutralValidation
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickOptionComputation(tickerId As Integer, field As Integer, impliedVolatility As Double, delta As Double, optPrice As Double, pvDividend As Double, gamma As Double, vega As Double, theta As Double, undPrice As Double) Implements EWrapper.tickOptionComputation
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickSnapshotEnd(tickerId As Integer) Implements EWrapper.tickSnapshotEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NextValidId(orderId As Integer) Implements EWrapper.nextValidId
        ' When this event arrives we know we're successfully connected to TWS because it always
        ' sends this immediately.

        mUI.IncrementTotalTicks()

        mUI.LogMessage("Connected to TWS")

        mUI.NotifyConnectionStateChange(ConnectionState.Connected)

    End Sub

    Public Sub ManagedAccounts(accountsList As String) Implements EWrapper.managedAccounts
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ConnectionClosed() Implements EWrapper.connectionClosed
        mUI.LogMessage("Disconnected")
    End Sub

    Public Sub AccountSummary(reqId As Integer, account As String, tag As String, value As String, currency As String) Implements EWrapper.accountSummary
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountSummaryEnd(reqId As Integer) Implements EWrapper.accountSummaryEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub BondContractDetails(reqId As Integer, contract As ContractDetails) Implements EWrapper.bondContractDetails
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateAccountValue(key As String, value As String, currency As String, accountName As String) Implements EWrapper.updateAccountValue
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdatePortfolio(contract As Contract, position As Double, marketPrice As Double, marketValue As Double, averageCost As Double, unrealisedPNL As Double, realisedPNL As Double, accountName As String) Implements EWrapper.updatePortfolio
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateAccountTime(timestamp As String) Implements EWrapper.updateAccountTime
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountDownloadEnd(account As String) Implements EWrapper.accountDownloadEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub OrderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements EWrapper.orderStatus
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub OpenOrder(orderId As Integer, contract As Contract, order As Order, orderState As OrderState) Implements EWrapper.openOrder
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub OpenOrderEnd() Implements EWrapper.openOrderEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ContractDetails(reqId As Integer, contractDetails As ContractDetails) Implements EWrapper.contractDetails
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ContractDetailsEnd(reqId As Integer) Implements EWrapper.contractDetailsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ExecDetails(reqId As Integer, contract As Contract, execution As Execution) Implements EWrapper.execDetails
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ExecDetailsEnd(reqId As Integer) Implements EWrapper.execDetailsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub CommissionReport(commissionReport As CommissionReport) Implements EWrapper.commissionReport
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub FundamentalData(reqId As Integer, data As String) Implements EWrapper.fundamentalData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub HistoricalData(reqId As Integer, bar As Bar) Implements EWrapper.historicalData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub HistoricalDataEnd(reqId As Integer, start As String, [end] As String) Implements EWrapper.historicalDataEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub MarketDataType(reqId As Integer, marketDataType As Integer) Implements EWrapper.marketDataType
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateMktDepth(tickerId As Integer, position As Integer, operation As Integer, side As Integer, price As Double, size As Integer) Implements EWrapper.updateMktDepth
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateMktDepthL2(tickerId As Integer, position As Integer, marketMaker As String, operation As Integer, side As Integer, price As Double, size As Integer) Implements EWrapper.updateMktDepthL2
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateNewsBulletin(msgId As Integer, msgType As Integer, message As String, origExchange As String) Implements EWrapper.updateNewsBulletin
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub Position(account As String, contract As Contract, pos As Double, avgCost As Double) Implements EWrapper.position
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub PositionEnd() Implements EWrapper.positionEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub RealtimeBar(reqId As Integer, time As Long, open As Double, high As Double, low As Double, close As Double, volume As Long, WAP As Double, count As Integer) Implements EWrapper.realtimeBar
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ScannerParameters(xml As String) Implements EWrapper.scannerParameters
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ScannerData(reqId As Integer, rank As Integer, contractDetails As ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String) Implements EWrapper.scannerData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ScannerDataEnd(reqId As Integer) Implements EWrapper.scannerDataEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ReceiveFA(faDataType As Integer, faXmlData As String) Implements EWrapper.receiveFA
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub VerifyMessageAPI(apiData As String) Implements EWrapper.verifyMessageAPI
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub VerifyCompleted(isSuccessful As Boolean, errorText As String) Implements EWrapper.verifyCompleted
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub VerifyAndAuthMessageAPI(apiData As String, xyzChallenge As String) Implements EWrapper.verifyAndAuthMessageAPI
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub VerifyAndAuthCompleted(isSuccessful As Boolean, errorText As String) Implements EWrapper.verifyAndAuthCompleted
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub DisplayGroupList(reqId As Integer, groups As String) Implements EWrapper.displayGroupList
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub DisplayGroupUpdated(reqId As Integer, contractInfo As String) Implements EWrapper.displayGroupUpdated
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ConnectAck() Implements EWrapper.connectAck
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub PositionMulti(requestId As Integer, account As String, modelCode As String, contract As Contract, pos As Double, avgCost As Double) Implements EWrapper.positionMulti
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub PositionMultiEnd(requestId As Integer) Implements EWrapper.positionMultiEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountUpdateMulti(requestId As Integer, account As String, modelCode As String, key As String, value As String, currency As String) Implements EWrapper.accountUpdateMulti
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountUpdateMultiEnd(requestId As Integer) Implements EWrapper.accountUpdateMultiEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub SecurityDefinitionOptionParameter(reqId As Integer, exchange As String, underlyingConId As Integer, tradingClass As String, multiplier As String, expirations As HashSet(Of String), strikes As HashSet(Of Double)) Implements EWrapper.securityDefinitionOptionParameter
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub SecurityDefinitionOptionParameterEnd(reqId As Integer) Implements EWrapper.securityDefinitionOptionParameterEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub SoftDollarTiers(reqId As Integer, tiers() As SoftDollarTier) Implements EWrapper.softDollarTiers
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub FamilyCodes(familyCodes() As FamilyCode) Implements EWrapper.familyCodes
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub SymbolSamples(reqId As Integer, contractDescriptions() As ContractDescription) Implements EWrapper.symbolSamples
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub historicalDataUpdate(reqId As Integer, bar As Bar) Implements EWrapper.historicalDataUpdate
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub mktDepthExchanges(depthMktDataDescriptions() As DepthMktDataDescription) Implements EWrapper.mktDepthExchanges
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub tickNews(tickerId As Integer, timeStamp As Long, providerCode As String, articleId As String, headline As String, extraData As String) Implements EWrapper.tickNews
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub smartComponents(reqId As Integer, theMap As Dictionary(Of Integer, KeyValuePair(Of String, Char))) Implements EWrapper.smartComponents
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub tickReqParams(tickerId As Integer, minTick As Double, bboExchange As String, snapshotPermissions As Integer) Implements EWrapper.tickReqParams
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub newsProviders(newsProviders() As NewsProvider) Implements EWrapper.newsProviders
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub newsArticle(requestId As Integer, articleType As Integer, articleText As String) Implements EWrapper.newsArticle
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub historicalNews(requestId As Integer, time As String, providerCode As String, articleId As String, headline As String) Implements EWrapper.historicalNews
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub historicalNewsEnd(requestId As Integer, hasMore As Boolean) Implements EWrapper.historicalNewsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub headTimestamp(reqId As Integer, headTimestamp As String) Implements EWrapper.headTimestamp
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub histogramData(reqId As Integer, data() As HistogramEntry) Implements EWrapper.histogramData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub rerouteMktDataReq(reqId As Integer, conId As Integer, exchange As String) Implements EWrapper.rerouteMktDataReq
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub rerouteMktDepthReq(reqId As Integer, conId As Integer, exchange As String) Implements EWrapper.rerouteMktDepthReq
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub marketRule(marketRuleId As Integer, priceIncrements() As PriceIncrement) Implements EWrapper.marketRule
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub pnl(reqId As Integer, dailyPnL As Double, unrealizedPnL As Double) Implements EWrapper.pnl
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub pnlSingle(reqId As Integer, pos As Integer, dailyPnL As Double, unrealizedPnL As Double, value As Double) Implements EWrapper.pnlSingle
        mUI.IncrementTotalTicks()
    End Sub

#End Region

End Class
