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

Public Class ApiLoadTestTW
    Implements IApiLoadTestController

    Private mIBApi As IBAPI
    Private WithEvents mEventSource As EventSource

    Private mNextMarketDataTickerId As Integer
    Private mNextMarketDepthTickerId As Integer

    Private mUI As UI

    Public Sub New(ui As UI)
        mUI = ui

        mUI.TitleQualifer = "TradeWright API"
        mUI.ClientId = 4166523
    End Sub

#Region "IApiLoadTestController Interface"

    Private Sub Connect(server As String, port As Integer, clientId As Integer, useLegacyProtocol As Boolean) Implements IApiLoadTestController.Connect
        mIBApi = New IBAPI(server, port, clientId, useLegacyProtocol:=useLegacyProtocol)
        mEventSource = mIBApi.EventSource

        mIBApi.Connect()

        mNextMarketDataTickerId = 0
    End Sub

    Private Sub Disconnect() Implements IApiLoadTestController.Disconnect
        mIBApi?.Disconnect("User")
    End Sub

    Private Function StartTicker(symbol As String, secType As String, expiry As String, exchange As String, currencyCode As String, primaryExchange As String, multiplier As Integer, marketDepth As Boolean) As Integer Implements IApiLoadTestController.StartTicker
        Dim contract = New Contract() With {.Symbol = symbol, .SecType = SecurityTypes.Parse(secType), .Expiry = expiry, .Exchange = exchange, .CurrencyCode = currencyCode, .PrimaryExch = primaryExchange, .Multiplier = If(multiplier = 0, 1, multiplier)}
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

#Region "mEventSource event handlers"

    Public Sub Exception(sender As Object, e As ExceptionEventArgs) Handles mEventSource.Exception
        mUI.HandleException(e.Exception)
    End Sub

    Public Sub ApiError(sender As Object, e As ApiErrorEventArgs) Handles mEventSource.ApiError
        mUI.LogMessage($"Error {e.ErrorCode} :  {e.Message}")
    End Sub

    Private Sub ApiEvent(sender As Object, e As ApiEventEventArgs) Handles mEventSource.ApiEvent
        mUI.LogMessage($"Error {e.EventCode} :  {e.EventMessage}")
    End Sub

    Private Sub ConnectionStateChange(sender As Object, e As ApiConnectionStateChangeEventArgs) Handles mEventSource.ConnectionStateChange
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

    Public Sub CurrentTime(sender As Object, e As CurrentTimeEventArgs) Handles mEventSource.CurrentTime
        mUI.IncrementTotalTicks()
    End Sub

    Private Sub MarketDataError(sender As Object, e As RequestErrorEventArgs) Handles mEventSource.MarketDataError
        mUI.LogMessage("Error " & e.ErrorCode & "(" & e.RequestId & ") :  " & e.Message)
    End Sub

    Private Sub MarketDepthError(sender As Object, e As RequestErrorEventArgs) Handles mEventSource.MarketDepthError
        mUI.LogMessage("Error " & e.ErrorCode & "(" & e.RequestId & ") :  " & e.Message)
    End Sub

    Public Sub TickPrice(sender As Object, e As TickPriceEventArgs) Handles mEventSource.TickPrice
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickSize(sender As Object, e As TickSizeEventArgs) Handles mEventSource.TickSize
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickString(sender As Object, e As TickStringEventArgs) Handles mEventSource.TickString
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickGeneric(sender As Object, e As TickGenericEventArgs) Handles mEventSource.TickGeneric
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickEFP(sender As Object, e As TickEFPEventArgs) Handles mEventSource.TickEFP
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub DeltaNeutralValidation(sender As Object, e As DeltaNeutralValidationEventArgs) Handles mEventSource.DeltaNeutralValidation
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickOptionComputation(sender As Object, e As TickOptionComputationEventArgs) Handles mEventSource.TickOptionComputation
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub TickSnapshotEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.TickSnapshotEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ManagedAccounts(sender As Object, e As ManagedAccountsEventArgs) Handles mEventSource.ManagedAccounts
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountSummary(sender As Object, e As AccountSummaryEventArgs) Handles mEventSource.AccountSummary
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountSummaryEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.AccountSummaryEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateAccountValue(sender As Object, e As UpdateAccountValueEventArgs) Handles mEventSource.UpdateAccountValue
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdatePortfolio(sender As Object, e As UpdatePortfolioEventArgs) Handles mEventSource.UpdatePortfolio
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateAccountTime(sender As Object, e As UpdateAccountTimeEventArgs) Handles mEventSource.UpdateAccountTime
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountDownloadEnd(sender As Object, e As AccountDownloadEndEventArgs) Handles mEventSource.AccountDownloadEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub OrderStatus(sender As Object, e As OrderStatusEventArgs) Handles mEventSource.OrderStatus
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub OpenOrder(sender As Object, e As OpenOrderEventArgs) Handles mEventSource.OpenOrder
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub OpenOrderEnd(sender As Object, e As EventArgs) Handles mEventSource.OpenOrderEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ContractDetails(sender As Object, e As ContractDetailsEventArgs) Handles mEventSource.ContractDetails
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ContractDetailsEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.ContractDetailsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ExecDetails(sender As Object, e As ExecutionDetailsEventArgs) Handles mEventSource.ExecutionDetails
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ExecDetailsEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.ExecutionDetailsEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub CommissionReport(sender As Object, e As CommissionReportEventArgs) Handles mEventSource.CommissionReport
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub FundamentalData(sender As Object, e As FundamentalDataEventArgs) Handles mEventSource.FundamentalData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub HistoricalData(sender As Object, e As HistoricalDataEventArgs) Handles mEventSource.HistoricalData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub HistoricalDataEnd(sender As Object, e As HistoricalDataRequestEventArgs) Handles mEventSource.HistoricalDataEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub MarketDataType(sender As Object, e As MarketDataTypeEventArgs) Handles mEventSource.MarketDataType
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub DeepBookUpdate(sender As Object, e As MarketDepthUpdateEventArgs) Handles mEventSource.MarketDepthUpdate
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub UpdateNewsBulletin(sender As Object, e As NewsBulletinEventArgs) Handles mEventSource.NewsBulletin
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub Position(sender As Object, e As PositionEventArgs) Handles mEventSource.Position
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub PositionEnd(sender As Object, e As EventArgs) Handles mEventSource.PositionEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub RealtimeBar(sender As Object, e As RealtimeBarEventArgs) Handles mEventSource.RealtimeBar
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ScannerParameters(sender As Object, e As ScannerParametersEventArgs) Handles mEventSource.ScannerParameters
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ScannerData(sender As Object, e As ScannerDataEventArgs) Handles mEventSource.ScannerData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ScannerDataEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.ScannerDataEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub ReceiveFA(sender As Object, e As AdvisorDataEventArgs) Handles mEventSource.AdvisorData
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub DisplayGroupList(sender As Object, e As DisplayGroupListEventArgs) Handles mEventSource.DisplayGroupList
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub DisplayGroupUpdated(sender As Object, e As DisplayGroupUpdatedEventArgs) Handles mEventSource.DisplayGroupUpdated
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub PositionMulti(sender As Object, e As PositionMultiEventArgs) Handles mEventSource.PositionMulti
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub PositionMultiEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.PositionMultiEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountUpdateMulti(sender As Object, e As AccountUpdateMultiEventArgs) Handles mEventSource.AccountUpdateMulti
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub AccountUpdateMultiEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.AccountUpdateMultiEnd
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub SecurityDefinitionOptionParameter(sender As Object, e As SecurityDefinitionOptionParameterEventArgs) Handles mEventSource.SecurityDefinitionOptionParameter
        mUI.IncrementTotalTicks()
    End Sub

    Public Sub SecurityDefinitionOptionParameterEnd(sender As Object, e As RequestEndEventArgs) Handles mEventSource.SecurityDefinitionOptionParameterEnd
        mUI.IncrementTotalTicks()
    End Sub

    'Public Sub SoftDollarTiers(sender As Object, e As SoftDollarTiersEventArgs) Handles mEventSource.SoftDollarTiers
    '    mForm.IncrementTotalTicks()
    'End Sub

    'Public Sub FamilyCodes(sender As Object, e As FamilyCodesEventArgs) Handles mEventSource.FamilyCodes
    '    mForm.IncrementTotalTicks()
    'End Sub

    'Public Sub SymbolSamples(sender As Object, e As SymbolSamplesEventArgs) Handles mEventSource.SymbolSamples
    '    mForm.IncrementTotalTicks()
    'End Sub

    'Public Sub MktDepthExchanges(sender As Object, e As MktDepthExchangesEventArgs) Handles mEventSource.MktDepthExchanges
    '    mForm.IncrementTotalTicks()
    'End Sub

#End Region

End Class
