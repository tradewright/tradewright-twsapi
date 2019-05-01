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
Imports TradeWright.IBAPI

Imports System.Threading

Public Class ApiLoadTestTW
    Implements IApiLoadTestController

    Private mIBApi As IBAPI
    Private WithEvents ApiEventSource As EventSource
    Private ReadOnly mCallbackHandler As CallbackHandler

    Private mNextMarketDataTickerId As Integer
    Private mNextMarketDepthTickerId As Integer

    Private mUI As UI

    Public Sub New(ui As UI)
        mUI = ui

        mUI.TitleQualifer = "TradeWright API"
        mUI.ClientId = 4166523
    End Sub

#Region "Properties"

    Public ReadOnly Property EnableUseV100ProtocolCheckbox As Boolean Implements IApiLoadTestController.EnableUseV100ProtocolCheckbox
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property EnableUseQueueingCallbackHandlerCheckbox As Boolean Implements IApiLoadTestController.EnableUseQueueingCallbackHandlerCheckbox
        Get
            Return True
        End Get
    End Property

#End Region

#Region "IApiLoadTestController Interface"

    Private Sub Connect(server As String, port As Integer, clientId As Integer) Implements IApiLoadTestController.Connect
        mIBApi = New IBAPI(server, port, clientId, True, useLegacyProtocol:=(Not mUI.UseV100Protocol))
        ApiEventSource = New EventSource()
        If mUI.UseQueueingCallbackHandler Then
            mIBApi.CallbackHandler = New QueueingCallbackHandler(ApiEventSource, SynchronizationContext.Current)
        Else
            mIBApi.CallbackHandler = ApiEventSource
        End If

        mIBApi.Connect()

        mNextMarketDataTickerId = 0
    End Sub

    Private Sub Disconnect() Implements IApiLoadTestController.Disconnect
        mIBApi?.Disconnect("User")
    End Sub

    Private Function StartTicker(symbol As String,
                                 secType As String,
                                 expiry As String,
                                 exchange As String,
                                 currencyCode As String,
                                 primaryExchange As String,
                                 multiplier As Integer,
                                 marketDepth As Boolean) As Integer Implements IApiLoadTestController.StartTicker
        Dim contract = New Contract() With {
            .Symbol = symbol,
            .SecType = IBAPI.SecurityTypes.Parse(secType),
            .Expiry = expiry,
            .Exchange = exchange,
            .CurrencyCode = currencyCode,
            .PrimaryExch = primaryExchange,
            .Multiplier = If(multiplier = 0, 1, multiplier)}

        Dim tickerId = mNextMarketDataTickerId
        mNextMarketDataTickerId += 1

        mIBApi.RequestMarketData(tickerId, contract, "", False)

        If marketDepth Then
            mIBApi.RequestMarketDepth(mNextMarketDepthTickerId, contract, 20)
            mNextMarketDepthTickerId += 1
        End If

        Return tickerId
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

#Region "ApiEventSource event handlers"

    Private Sub exception(sender As Object, e As ExceptionEventArgs) Handles ApiEventSource.Exception
        mUI.HandleException(e.Exception)
    End Sub

    Private Sub apiError(sender As Object, e As ApiErrorEventArgs) Handles ApiEventSource.ApiError
        mUI.LogMessage($"Error {e.ErrorCode} :  {e.Message}")
    End Sub

    Private Sub apiEvent(sender As Object, e As ApiEventEventArgs) Handles ApiEventSource.ApiEvent
        mUI.LogMessage($"Error {e.EventCode} :  {e.EventMessage}")
    End Sub

    Private Sub connectionStateChange(sender As Object, e As ApiConnectionStateChangeEventArgs) Handles ApiEventSource.ConnectionStateChange
        Select Case e.State
            Case ApiConnectionState.NotConnected
                mUI.NotifyConnectionStateChange(ConnectionState.NotConnected)
            Case ApiConnectionState.Connecting
                mUI.NotifyConnectionStateChange(ConnectionState.Connecting)
            Case ApiConnectionState.Connected
                mUI.NotifyConnectionStateChange(ConnectionState.Connected)
            Case ApiConnectionState.Failed
                mUI.NotifyConnectionStateChange(ConnectionState.Failed)
        End Select
    End Sub

    Private Sub currentTime(sender As Object, e As CurrentTimeEventArgs) Handles ApiEventSource.CurrentTime
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub marketDataError(sender As Object, e As RequestErrorEventArgs) Handles ApiEventSource.MarketDataError
        mUI.LogMessage("Error " & e.ErrorCode & "(" & e.RequestId & ") :  " & e.Message)
    End Sub

    Private Sub marketDepthError(sender As Object, e As RequestErrorEventArgs) Handles ApiEventSource.MarketDepthError
        mUI.LogMessage("Error " & e.ErrorCode & "(" & e.RequestId & ") :  " & e.Message)
    End Sub

    Private Sub tickPrice(sender As Object, e As TickPriceEventArgs) Handles ApiEventSource.TickPrice
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub tickSize(sender As Object, e As TickSizeEventArgs) Handles ApiEventSource.TickSize
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub tickString(sender As Object, e As TickStringEventArgs) Handles ApiEventSource.TickString
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub tickGeneric(sender As Object, e As TickGenericEventArgs) Handles ApiEventSource.TickGeneric
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub tickEFP(sender As Object, e As TickEFPEventArgs) Handles ApiEventSource.TickEFP
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub deltaNeutralValidation(sender As Object, e As DeltaNeutralValidationEventArgs) Handles ApiEventSource.DeltaNeutralValidation
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub tickOptionComputation(sender As Object, e As TickOptionComputationEventArgs) Handles ApiEventSource.TickOptionComputation
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub tickSnapshotEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.TickSnapshotEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub managedAccounts(sender As Object, e As ManagedAccountsEventArgs) Handles ApiEventSource.ManagedAccounts
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub accountSummary(sender As Object, e As AccountSummaryEventArgs) Handles ApiEventSource.AccountSummary
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub accountSummaryEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.AccountSummaryEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub updateAccountValue(sender As Object, e As UpdateAccountValueEventArgs) Handles ApiEventSource.UpdateAccountValue
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub updatePortfolio(sender As Object, e As UpdatePortfolioEventArgs) Handles ApiEventSource.UpdatePortfolio
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub updateAccountTime(sender As Object, e As UpdateAccountTimeEventArgs) Handles ApiEventSource.UpdateAccountTime
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub accountDownloadEnd(sender As Object, e As AccountDownloadEndEventArgs) Handles ApiEventSource.AccountDownloadEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub orderStatus(sender As Object, e As OrderStatusEventArgs) Handles ApiEventSource.OrderStatus
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub openOrder(sender As Object, e As OpenOrderEventArgs) Handles ApiEventSource.OpenOrder
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub openOrderEnd(sender As Object, e As EventArgs) Handles ApiEventSource.OpenOrderEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub contractDetails(sender As Object, e As ContractDetailsEventArgs) Handles ApiEventSource.ContractDetails
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub contractDetailsEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.ContractDetailsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub execDetails(sender As Object, e As ExecutionDetailsEventArgs) Handles ApiEventSource.ExecutionDetails
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub execDetailsEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.ExecutionDetailsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub commissionReport(sender As Object, e As CommissionReportEventArgs) Handles ApiEventSource.CommissionReport
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub fundamentalData(sender As Object, e As FundamentalDataEventArgs) Handles ApiEventSource.FundamentalData
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub historicalBar(sender As Object, e As HistoricalBarEventArgs) Handles ApiEventSource.HistoricalBar
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub historicalBarsEnd(sender As Object, e As HistoricalBarsRequestEventArgs) Handles ApiEventSource.HistoricalBarsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub marketDataType(sender As Object, e As MarketDataTypeEventArgs) Handles ApiEventSource.MarketDataType
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub deepBookUpdate(sender As Object, e As MarketDepthUpdateEventArgs) Handles ApiEventSource.MarketDepthUpdate
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub updateNewsBulletin(sender As Object, e As NewsBulletinEventArgs) Handles ApiEventSource.NewsBulletin
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub position(sender As Object, e As PositionEventArgs) Handles ApiEventSource.Position
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub positionEnd(sender As Object, e As EventArgs) Handles ApiEventSource.PositionEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub realtimeBar(sender As Object, e As RealtimeBarEventArgs) Handles ApiEventSource.RealtimeBar
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub scannerParameters(sender As Object, e As ScannerParametersEventArgs) Handles ApiEventSource.ScannerParameters
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub scannerData(sender As Object, e As ScannerDataEventArgs) Handles ApiEventSource.ScannerData
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub scannerDataEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.ScannerDataEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub receiveFA(sender As Object, e As AdvisorDataEventArgs) Handles ApiEventSource.AdvisorData
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub displayGroupList(sender As Object, e As DisplayGroupListEventArgs) Handles ApiEventSource.DisplayGroupList
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub displayGroupUpdated(sender As Object, e As DisplayGroupUpdatedEventArgs) Handles ApiEventSource.DisplayGroupUpdated
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub positionMulti(sender As Object, e As PositionMultiEventArgs) Handles ApiEventSource.PositionMulti
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub positionMultiEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.PositionMultiEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub accountUpdateMulti(sender As Object, e As AccountUpdateMultiEventArgs) Handles ApiEventSource.AccountUpdateMulti
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub accountUpdateMultiEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.AccountUpdateMultiEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub securityDefinitionOptionParameter(sender As Object, e As SecurityDefinitionOptionParameterEventArgs) Handles ApiEventSource.SecurityDefinitionOptionParameter
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub securityDefinitionOptionParameterEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEventSource.SecurityDefinitionOptionParameterEnd
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub softDollarTiers(sender As Object, e As SoftDollarTiersEventArgs) Handles ApiEventSource.SoftDollarTiers
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub familyCodes(sender As Object, e As FamilyCodesEventArgs) Handles ApiEventSource.FamilyCodes
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub symbolSamples(sender As Object, e As SymbolSamplesEventArgs) Handles ApiEventSource.SymbolSamples
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub mktDepthExchanges(sender As Object, e As MarketDepthExchangesEventArgs) Handles ApiEventSource.MarketDepthExchanges
        mUI.IncrementTotalTicks()
    End Sub

#End Region

End Class
