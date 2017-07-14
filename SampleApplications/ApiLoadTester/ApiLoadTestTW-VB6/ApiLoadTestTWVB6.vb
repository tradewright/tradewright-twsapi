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
Imports IBAPI27

Imports System.Threading

Public Class ApiLoadTestTWVB6
    Implements IApiLoadTestController
    Implements IAccountDataConsumer
    Implements IConnectionStatusConsumer
    Implements IContractDetailsConsumer
    Implements IErrorAndNotificationConsumer
    Implements IHistDataConsumer
    Implements IMarketDataConsumer
    Implements IMarketDepthConsumer
    Implements IOrderInfoConsumer
    Implements IScannerDataConsumer


    Private IB As IBAPI
    Private mIBApi As TwsAPI

    Private mNextMarketDataTickerId As Integer
    Private mNextMarketDepthTickerId As Integer

    Private mUI As UI

    Public Sub New(ui As UI)
        IB = New IBAPIClass
        mUI = ui

        mUI.TitleQualifer = "TradeWright TWSAPI (VB6)"
        mUI.ClientId = 51332078
    End Sub

#Region "Properties"

    Public ReadOnly Property EnableUseV100ProtocolCheckbox As Boolean Implements IApiLoadTestController.EnableUseV100ProtocolCheckbox
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property EnableUseQueueingCallbackHandlerCheckbox As Boolean Implements IApiLoadTestController.EnableUseQueueingCallbackHandlerCheckbox
        Get
            Return False
        End Get
    End Property

#End Region

#Region "IApiLoadTestController Interface"

    Private Sub Connect(
                    server As String,
                    port As Integer,
                    clientId As Integer
                ) Implements IApiLoadTestController.Connect
        mIBApi = IB.GetAPI(server, port, clientId)

        mIBApi.AccountDataConsumer = Me
        mIBApi.ConnectionStatusConsumer = Me
        mIBApi.ContractDetailsConsumer = Me
        mIBApi.ErrorAndNotificationConsumer = Me
        mIBApi.HistDataConsumer = Me
        mIBApi.MarketDataConsumer = Me
        mIBApi.MarketDepthConsumer = Me
        mIBApi.OrderInfoConsumer = Me
        mIBApi.ScannerDataConsumer = Me

        mIBApi.Connect()

        mNextMarketDataTickerId = 0
    End Sub

    Private Sub Disconnect() Implements IApiLoadTestController.Disconnect
        mIBApi?.Disconnect("User")
    End Sub

    Private Function StartTicker(
                    symbol As String,
                    secType As String,
                    expiry As String,
                    exchange As String,
                    currencyCode As String,
                    primaryExchange As String,
                    multiplier As Integer,
                    marketDepth As Boolean
                ) As Integer Implements IApiLoadTestController.StartTicker
        Dim contract = New TwsContract() With {
            .Symbol = symbol,
            .Sectype = IB.TwsSecTypeFromString(secType),
            .Expiry = expiry,
            .Exchange = exchange,
            .CurrencyCode = currencyCode,
            .PrimaryExch = primaryExchange,
            .Multiplier = If(multiplier = 0, 1, multiplier)
        }
        mIBApi.RequestMarketData(mNextMarketDataTickerId, contract, "", False)
        mNextMarketDataTickerId += 1
        If marketDepth Then
            mIBApi.RequestMarketDepth(mNextMarketDepthTickerId, contract, 20)
            mNextMarketDepthTickerId += 1
        End If
        Return mNextMarketDataTickerId - 1
    End Function

    Private Sub StopTickers() Implements IApiLoadTestController.StopTickers
        For i = 0 To mNextMarketDataTickerId - 1
            mIBApi.CancelMarketData(i)
            mUI.LogMessage("Stopping ticker " & i)
        Next
        mNextMarketDataTickerId = 0

        For i = 0 To mNextMarketDepthTickerId - 1
            mIBApi.CancelMarketDepth(i)
            mUI.LogMessage("Stopping market depth " & i)
        Next
        mNextMarketDepthTickerId = 0
    End Sub

#End Region

#Region "API event handlers"

    Public Sub EndAccountSummary(
                    pRequestId As Integer
                ) Implements _IAccountDataConsumer.EndAccountSummary
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub EndAcccountValue(
                    pAccountName As String
                ) Implements _IAccountDataConsumer.EndAcccountValue
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub EndPosition() Implements _IAccountDataConsumer.EndPosition
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyAccountSummary(
                    pRequestId As Integer,
                    pAccount As String,
                    pTag As String,
                    pValue As String,
                    pCurrency As String
                ) Implements _IAccountDataConsumer.NotifyAccountSummary
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyAccountValue(
                    pKey As String,
                    pValue As String,
                    pCurrency As String,
                    pAccountName As String
                ) Implements _IAccountDataConsumer.NotifyAccountValue
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyAccountTime(
                    pTimeStamp As String
                ) Implements _IAccountDataConsumer.NotifyAccountTime
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyPosition(
                    pAccount As String,
                    pContract As TwsContract,
                    pPosition As Integer,
                    pAverageCost As Double
                ) Implements _IAccountDataConsumer.NotifyPosition
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyPortfolioUpdate(
                    pContract As TwsContract,
                    pPosition As Integer,
                    pMarketPrice As Double,
                    pMarketValue As Double,
                    pAverageCost As Double,
                    pUnrealizedPNL As Double,
                    pRealizedPNL As Double,
                    pAccountName As String
                ) Implements _IAccountDataConsumer.NotifyPortfolioUpdate
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyAPIConnectionStateChange(
                    pState As TwsConnectionStates,
                    pMessage As String
                ) Implements _IConnectionStatusConsumer.NotifyAPIConnectionStateChange
        Select Case pState
            Case TwsConnectionStates.TwsConnNotConnected
                mUI.NotifyConnectionStateChange(ConnectionState.NotConnected)
            Case TwsConnectionStates.TwsConnConnecting
                mUI.NotifyConnectionStateChange(ConnectionState.Connecting)
            Case TwsConnectionStates.TwsConnConnected
                mUI.NotifyConnectionStateChange(ConnectionState.Connected)
            Case TwsConnectionStates.TwsConnFailed
                mUI.NotifyConnectionStateChange(ConnectionState.Failed)
        End Select
    End Sub

    Public Sub NotifyIBServerConnectionClosed(
                ) Implements _IConnectionStatusConsumer.NotifyIBServerConnectionClosed
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyIBServerConnectionRecovered(
                    pDataLost As Boolean
                ) Implements _IConnectionStatusConsumer.NotifyIBServerConnectionRecovered
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub EndContractDetails(
                    pRequestId As Integer
                ) Implements _IContractDetailsConsumer.EndContractDetails
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyContract(
                    pRequestId As Integer,
                    ByRef pContractDetails As TwsContractDetails
                ) Implements _IContractDetailsConsumer.NotifyContract
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyContractDataError(
                    pRequestId As Integer,
                    pErrorCode As Integer,
                    pErrorMsg As String
                ) Implements _IContractDetailsConsumer.NotifyError
        mUI.LogMessage($"Contract error {pErrorCode} :  {pErrorMsg}")
    End Sub

    Public Sub NotifyApiError(
                    pErrorCode As Integer,
                    pErrorMsg As String
                ) Implements _IErrorAndNotificationConsumer.NotifyApiError
        mUI.LogMessage($"Error {pErrorCode} :  {pErrorMsg}")
    End Sub

    Public Sub NotifyApiEvent(
                    pEventCode As Integer,
                    pEventMsg As String
                ) Implements _IErrorAndNotificationConsumer.NotifyApiEvent
        mUI.LogMessage($"Event {pEventCode} :  {pEventMsg}")
    End Sub

    Public Sub EndHistData(
                    pRequestId As Integer
                ) Implements _IHistDataConsumer.EndHistData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyBar(
                    pRequestId As Integer,
                    ByRef pBar As TwsBar
                ) Implements _IHistDataConsumer.NotifyBar
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub NotifyHistDataError(
                    pRequestId As Integer,
                    pErrorCode As Integer,
                    pErrorMsg As String
                ) Implements _IHistDataConsumer.NotifyError
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub StartHistData(
                    pRequestId As Integer,
                    pStartDate As String,
                    pEndDate As String,
                    pBarCount As Integer
                ) Implements _IHistDataConsumer.StartHistData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub EndTickSnapshot(
                    pReqId As Integer
                ) Implements _IMarketDataConsumer.EndTickSnapshot
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub NotifyMarketDataError(
                    pTickerId As Integer,
                    pErrorCode As Integer,
                    pErrorMsg As String
                ) Implements _IMarketDataConsumer.NotifyError
        mUI.LogMessage($"Error {pErrorCode} ({pTickerId}) :  {pErrorMsg}")
    End Sub

    Public Sub NotifyTickEFP(
                    pTickerId As Integer,
                    pTickType As TwsTickTypes,
                    pBasisPoints As Double,
                    pFormattedBasisPoints As String,
                    pTotalDividends As Double,
                    pHoldDays As Integer,
                    pFutureExpiry As String,
                    pDividendImpact As Double,
                    pDividendsToExpiry As Double
                ) Implements _IMarketDataConsumer.NotifyTickEFP
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyTickGeneric(
                    pTickerId As Integer,
                    pTickType As TwsTickTypes,
                    pValue As Double
                ) Implements _IMarketDataConsumer.NotifyTickGeneric
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyTickOptionComputation(
                    pTickerId As Integer,
                    pTickType As TwsTickTypes,
                    pImpliedVol As Double,
                    pDelta As Double,
                    pOptPrice As Double,
                    pPvDividend As Double,
                    pGamma As Double,
                    pVega As Double,
                    pTheta As Double,
                    pUndPrice As Double
                ) Implements _IMarketDataConsumer.NotifyTickOptionComputation
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyTickPrice(
                    pTickerId As Integer,
                    pTickType As TwsTickTypes,
                    pPrice As Double,
                    pSize As Integer,
                    pCanAutoExecute As Boolean
                ) Implements _IMarketDataConsumer.NotifyTickPrice
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyTickSize(
                    pTickerId As Integer,
                    pTickType As Integer,
                    pSize As Integer
                ) Implements _IMarketDataConsumer.NotifyTickSize
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyTickString(
                    pTickerId As Integer,
                    pTickType As TwsTickTypes,
                    pValue As String
                ) Implements _IMarketDataConsumer.NotifyTickString
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub NotifyMarketDepthError(
                    pTickerId As Integer,
                    pErrorCode As Integer,
                    pErrorMsg As String
                ) Implements _IMarketDepthConsumer.NotifyError
        mUI.LogMessage($"Error {pErrorCode} ({pTickerId}) :  {pErrorMsg}")
    End Sub

    Public Sub NotifyMarketDepth(
                    pTickerId As Integer,
                    pPosition As Integer,
                    pMarketMaker As String,
                    pOperation As TwsDOMOperations,
                    pSide As TwsDOMSides,
                    pPrice As Double,
                    pSize As Integer
                ) Implements _IMarketDepthConsumer.NotifyMarketDepth
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ResetMarketDepth(
                    pReEstablish As Boolean
                ) Implements _IMarketDepthConsumer.ResetMarketDepth
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub EndExecutions(
                    pRequestId As Integer
                ) Implements _IOrderInfoConsumer.EndExecutions
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub EndOpenOrders() Implements _IOrderInfoConsumer.EndOpenOrders
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub NotifyOrderError(
                    pOrderId As Integer,
                    pErrorCode As Integer,
                    pErrorMsg As String
                ) Implements _IOrderInfoConsumer.NotifyError
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyExecution(
                    pReqId As Integer,
                    pContract As TwsContract,
                    pExecution As TwsExecution
                ) Implements _IOrderInfoConsumer.NotifyExecution
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyOpenOrder(
                    pOrderId As Integer,
                    pContract As TwsContract,
                    pOrder As TwsOrder,
                    pOrderState As TwsOrderState
                ) Implements _IOrderInfoConsumer.NotifyOpenOrder
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyOrderStatus(
                    pOrderId As Integer,
                    pStatus As String,
                    pFilled As Integer,
                    pRemaining As Integer,
                    pAvgFillPrice As Double,
                    pPermId As Integer,
                    pParentId As Integer,
                    pLastFillPrice As Double,
                    pClientId As Integer,
                    pWhyHeld As String
                ) Implements _IOrderInfoConsumer.NotifyOrderStatus
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub EndScannerData(
                    pRequestId As Integer
                ) Implements _IScannerDataConsumer.EndScannerData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyScannerData(
                    pRequestId As Integer,
                    pRank As Integer,
                    pContractDetails As TwsContractDetails,
                    pDistance As String,
                    pBenchmark As String,
                    pProjection As String,
                    pLegs As String
                ) Implements _IScannerDataConsumer.NotifyScannerData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub NotifyScannerParameters(
                    pXml As String
                ) Implements _IScannerDataConsumer.NotifyScannerParameters
        mUI.IncrementTotalTicks()
    End Sub

#End Region

End Class
