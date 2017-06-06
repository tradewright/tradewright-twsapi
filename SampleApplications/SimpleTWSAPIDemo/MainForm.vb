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

Option Strict On
Option Infer On

Imports TradeWright.IBAPI
Imports TradeWright.Utilities.Logging

Public Class MainForm

#Region "Constants"

    ' Set this constant to the name of the computer where TWS is running. If it's running on this computer, leave it blank.
    Private Const TWSHostName As String = ""

    ' Set this constant to the port used for communicating with TWS. The default value for TWS is 7496 (for live account) and
    ' 7497 for paper-trading account; the corresponding default values for the Gateway are 4001 (live) and 4002 (paper). These
    ' values may be changed in the TWS/Gateway Configuration dialogs.
    Private Const Port As Integer = 7496

    ' The client id distinguishes this API connection from other connections. Don't use 0, as this has a special meaning
    ' and can cause problems. Otherwise the actual value is not significant. If you have more than one program connecting to
    ' the API at the same time, you must use different client ids in each one.
    Private Const ClientId As Integer = 12123434

    Private Const OrderColumnAction As String = "Action"
    Private Const OrderColumAvgPrice As String = "AvgPrice"
    Private Const OrderColumnFilled As String = "Filled"
    Private Const OrderColumnId As String = "Id"
    Private Const OrderColumnLocalSymbol As String = "LocalSymbol"
    Private Const OrderColumnStatus As String = "Status"
    Private Const OrderColumnQuantity As String = "Quantity"

    Private Const OrderStatusCancelled As String = "Cancelled"
    Private Const OrderStatusCreated As String = "Created"
    Private Const OrderStatusFilled As String = "Filled"
    Private Const OrderStatusInactive As String = "Inactive"
    Private Const OrderStatusPendingCancel As String = "PendingCancel"
    Private Const OrderStatusPreSubmitted As String = "PreSubmitted"
    Private Const OrderStatusRejected As String = "Rejected"
    Private Const OrderStatusSubmitted As String = "Submitted"

    Private Const OrderTypeMarket As String = "MKT"
    Private Const OrderTypeLimit As String = "LMT"
    Private Const OrderTypeStop As String = "STP"
    Private Const OrderTypeStopLimit As String = "STPLMT"

    Private Const TickerColumnAsk As String = "Ask"
    Private Const TickerColumnAskSize As String = "AskSize"
    Private Const TickerColumnBid As String = "Bid"
    Private Const TickerColumnBidSize As String = "BidSize"
    Private Const TickerColumnClose As String = "Close"
    Private Const TickerColumnHigh As String = "High"
    Private Const TickerColumnLast As String = "Last"
    Private Const TickerColumnLastSize As String = "LastSize"
    Private Const TickerColumnLow As String = "Low"
    Private Const TickerColumnSymbol As String = "Symbol"
    Private Const TickerColumnVolume As String = "Volume"

#End Region

#Region "Fields"

    ' For each ticker, this array stores information about it.
    Private mTickers(1023) As Ticker

    ' This will be incremented for each ticker started. It is used as an index into mTickerGridRows
    Private mTickerId As Integer

    ' For each market depth stream, this array stores information about it.
    Private mDOMTickers(127) As Ticker

    ' This will be incremented for each market depth started
    Private mDepthTickerId As Integer

    ' Used to map order ids to the corresponding ActiveOrder object that preserves information about the order
    Private mOrders As New Dictionary(Of Integer, ActiveOrder)

    ' Provides methods to invoke TWS functionality
    Private mApi As IBAPI

    Private WithEvents mApiEv As EventSource

    ' maintains the market depth model, and updates the market depth displays
    Private mDepthMgr As MarketDepthManager

#End Region

#Region "Form Event Handlers"

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Logging.DefaultLogLevel = LogLevel.HighDetail
        Logging.SetupDefaultLogging()
        logMessage($"Logfile is {Logging.DefaultLogFileName}")

        AddHandler System.AppDomain.CurrentDomain.UnhandledException,
                    Sub(s, ex)
                        Logging.DefaultLogger.Log($"Unhandled exception:{Environment.NewLine}{ex.ExceptionObject.ToString()}", LogLevel.Severe)
                        Me.Dispose()
                    End Sub

        mDepthMgr = New MarketDepthManager(BidGrid, AskGrid)

        ServerTextBox.Text = TWSHostName
        PortTextBox.Text = Port.ToString()
        ClientIdTextBox.Text = ClientId.ToString()

        SecTypeTickerCombo.SelectedItem = "FUT"
        ExchangeTickerCombo.SelectedItem = "GLOBEX"
        CurrencyTickerCombo.SelectedItem = "USD"

        SecTypeDepthCombo.SelectedItem = "FUT"
        ExchangeDepthCombo.SelectedItem = "GLOBEX"
        CurrencyDepthCombo.SelectedItem = "USD"

        SectypeOrderCombo.SelectedItem = "FUT"
        ExchangeOrderCombo.SelectedItem = "GLOBEX"
        CurrencyOrderCombo.SelectedItem = "USD"
        OrderTypeCombo.SelectedItem = "MKT"
    End Sub

#End Region

#Region "Form Controls Event Handlers"

    Private Sub BuyButton_Click(sender As System.Object, e As System.EventArgs) Handles BuyButton.Click
        generateAndPlaceOrder(OrderAction.Buy)
    End Sub

    Private Sub CancelOrderButton_Click(sender As System.Object, e As System.EventArgs) Handles CancelOrderButton.Click
        For Each row As DataGridViewRow In OrderGrid.SelectedRows
            Dim orderid = CInt(row.Tag)
            If isCancellableStatus(getOrderStatus(orderid)) Then cancelOrder(orderid)
        Next
        CancelOrderButton.Enabled = False
    End Sub

    Private Sub ConnectButton_Click(sender As System.Object, e As System.EventArgs) Handles ConnectButton.Click
        connectToTWS()
    End Sub

    Private Sub DisconnectButton_Click(sender As System.Object, e As System.EventArgs) Handles DisconnectButton.Click
        ConnectButton.Enabled = True
        DisconnectButton.Enabled = False
        StartTickerButton.Enabled = False
        BuyButton.Enabled = False
        SellButton.Enabled = False

        mDepthMgr.clear()
        stopAllTickers()
        disconnectFromTWS()
    End Sub

    Private Sub LocalSymbolDepthText_TextChanged(sender As System.Object, e As System.EventArgs) Handles LocalSymbolDepthText.TextChanged
        setStartMarketDepthButtonState()
    End Sub

    Private Sub LocalSymbolOrderText_TextChanged(sender As System.Object, e As System.EventArgs) Handles LocalSymbolOrderText.TextChanged
        setBuySellButtonsState()
    End Sub

    Private Sub LocalSymbolTickerText_TextChanged(sender As System.Object, e As System.EventArgs) Handles LocalSymbolTickerText.TextChanged
        setStartTickerButtonState()
    End Sub

    Private Sub OrderGrid_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles OrderGrid.CellMouseClick
        CancelOrderButton.Enabled = False
    End Sub

    Private Sub OrderGrid_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles OrderGrid.RowHeaderMouseClick
        CancelOrderButton.Enabled = False
        For Each row As DataGridViewRow In OrderGrid.SelectedRows
            Dim orderid = CInt(row.Tag)
            If isCancellableStatus(getOrderStatus(orderid)) Then
                CancelOrderButton.Enabled = True
                Exit For
            End If
        Next
    End Sub

    Private Sub OrderTypeCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles OrderTypeCombo.SelectedIndexChanged
        Select Case OrderTypeCombo.Text
            Case OrderTypeMarket
                LimitPriceText.Enabled = False
                TriggerPriceText.Enabled = False
            Case OrderTypeLimit
                LimitPriceText.Enabled = True
                TriggerPriceText.Enabled = False
            Case OrderTypeStop
                LimitPriceText.Enabled = False
                TriggerPriceText.Enabled = True
            Case OrderTypeStopLimit
                LimitPriceText.Enabled = True
                TriggerPriceText.Enabled = True
        End Select
    End Sub

    Private Sub QuantityText_TextChanged(sender As System.Object, e As System.EventArgs) Handles QuantityText.TextChanged
        setBuySellButtonsState()
    End Sub

    Private Sub QuantityText_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles QuantityText.Validating
        Dim errMsg = ""
        If Not validateQuantity(errMsg) Then
            ErrorProvider.SetIconAlignment(QuantityText, ErrorIconAlignment.BottomLeft)
            ErrorProvider.SetError(QuantityText, errMsg)
            e.Cancel = True
        Else
            ErrorProvider.SetError(QuantityText, "")
        End If
    End Sub

    Private Sub SectypeOrderCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles SectypeOrderCombo.SelectedIndexChanged
        setBuySellButtonsState()
    End Sub

    Private Sub SecTypeTickerCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles SecTypeTickerCombo.SelectedIndexChanged
        setStartTickerButtonState()
    End Sub

    Private Sub SellButton_Click(sender As System.Object, e As System.EventArgs) Handles SellButton.Click
        generateAndPlaceOrder(OrderAction.Sell)
    End Sub

    Private Sub StartMarketDepthButton_Click(sender As System.Object, e As System.EventArgs) Handles StartMarketDepthButton.Click
        mDepthMgr.Initialise(20)
        startMarketDepth(createContract(SecurityTypes.Parse(SecTypeDepthCombo.Text.ToUpper),
                                        LocalSymbolDepthText.Text.ToUpper,
                                        ExchangeDepthCombo.Text,
                                        CurrencyDepthCombo.Text))
        StartMarketDepthButton.Enabled = False
        StopMarketDepthButton.Enabled = True
    End Sub

    Private Sub StartTickerButton_Click(sender As System.Object, e As System.EventArgs) Handles StartTickerButton.Click
        startTicker(createContract(SecurityTypes.Parse(SecTypeTickerCombo.Text.ToUpper),
                                   LocalSymbolTickerText.Text.ToUpper,
                                   ExchangeTickerCombo.Text,
                                   CurrencyTickerCombo.Text))
    End Sub

    Private Sub StopTickerButton_Click(sender As System.Object, e As System.EventArgs) Handles StopTickerButton.Click
        For Each row As DataGridViewRow In TickerGrid.SelectedRows
            If row.Tag IsNot Nothing Then stopTicker(CInt(row.Tag))
        Next
        StopTickerButton.Enabled = False
    End Sub

    Private Sub StopMarketDepthButton_Click(sender As System.Object, e As System.EventArgs) Handles StopMarketDepthButton.Click
        stopMarketDepth()
    End Sub

    Private Sub TickerGrid_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TickerGrid.CellMouseClick
        StopTickerButton.Enabled = False
    End Sub

    Private Sub TickerGrid_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TickerGrid.RowHeaderMouseClick
        StopTickerButton.Enabled = False
        For Each row As DataGridViewRow In TickerGrid.SelectedRows
            If row.Tag IsNot Nothing Then
                StopTickerButton.Enabled = True
                Exit For
            End If
        Next
    End Sub

#End Region

#Region "TWS API Event Handlers"

    Private Sub mApiEv_ApiError(sender As Object, e As ApiErrorEventArgs) Handles mApiEv.ApiError
        logMessage($"Api error: error code={e.ErrorCode}; message={e.Message}")
    End Sub

    Private Sub mApiEv_ApiEvent(sender As Object, e As ApiEventEventArgs) Handles mApiEv.ApiEvent
        logMessage($"Api event: event code={e.EventCode}; message={e.EventMessage}")
    End Sub

    Private Sub mApiEv_ConnectionStateChange(sender As Object, e As ApiConnectionStateChangeEventArgs) Handles mApiEv.ConnectionStateChange
        Select Case e.State
            Case ApiConnectionState.NotConnected
                logMessage("Disconnected from TWS")
                ConnectButton.Enabled = True
                DisconnectButton.Enabled = False
            Case ApiConnectionState.Connecting
                logMessage("Connecting...")
            Case ApiConnectionState.Connected
                logMessage("Connected ok")
                DisconnectButton.Enabled = True
            Case ApiConnectionState.Failed
                logMessage("Connect failed")
                ConnectButton.Enabled = True
                DisconnectButton.Enabled = False
        End Select

        setStartTickerButtonState()
        setBuySellButtonsState()
        setStartMarketDepthButtonState()
    End Sub

    Private Sub mApiEv_CurrentTime(sender As Object, e As CurrentTimeEventArgs) Handles mApiEv.CurrentTime
        logMessage($"currentTime: {e.Timestamp}")
    End Sub

    Private Sub mApiEv_Exception(sender As Object, e As ExceptionEventArgs) Handles mApiEv.Exception
        logMessage($"An exception has occurred: {e.Exception.ToString()}")
    End Sub

    Private Sub mApiEv_ManagedAccounts(sender As Object, e As ManagedAccountsEventArgs) Handles mApiEv.ManagedAccounts
        logMessage($"Managed accounts: {String.Join(",", e.ManagedAccounts)}")
    End Sub

    Private Sub mApiEv_MarketDataError(sender As Object, e As RequestErrorEventArgs) Handles mApiEv.MarketDataError
        logMessage($"Marketdata error: tickerId={e.RequestId}; error code={e.ErrorCode}; message={e.Message}")
    End Sub

    Private Sub mApiEv_MarketDepthError(sender As Object, e As RequestErrorEventArgs) Handles mApiEv.MarketDepthError
        processMarketDepthError(e.RequestId, e.ErrorCode)
    End Sub

    Private Sub mApiEv_MarketDepthUpdate(sender As Object, e As MarketDepthUpdateEventArgs) Handles mApiEv.MarketDepthUpdate
        If mDOMTickers(e.RequestId)?.Contract Is Nothing Then
            ' the market depth stream has been stopped but this
            ' update was already on its way
            Return
        End If
        mDepthMgr.updateMktDepth(e.RequestId, e.Position, e.MarketMaker, e.Operation, e.Side, e.Price, e.Size)
    End Sub

    Private Sub mApiEv_OpenOrder(sender As Object, e As OpenOrderEventArgs) Handles mApiEv.OpenOrder
        If Not mOrders.ContainsKey(e.OrderId) Then
            ' this can happen after connection for orders created in the previous session
            recordOrder(e.Contract, e.Order, e.OrderState)
        Else
            Dim actOrder = mOrders.Item(e.OrderId)
            actOrder.Contract = e.Contract
            actOrder.Order = e.Order
            actOrder.State = e.OrderState
        End If
        showOrder(e.OrderId)
    End Sub

    Private Sub mApiEv_OrderError(sender As Object, e As OrderErrorEventArgs) Handles mApiEv.OrderError
        processOrderError(e.RequestId, e.ErrorCode)
    End Sub

    Private Sub mApiEv_OrderStatus(sender As Object, e As OrderStatusEventArgs) Handles mApiEv.OrderStatus
        Dim row = mOrders.Item(e.OrderId).GridRow
        showOrderValue(row, OrderColumnFilled, CStr(e.Filled))
        showOrderValue(row, OrderColumAvgPrice, CStr(e.AvgFillPrice))
        saveOrderStatus(e.OrderId, e.Status)
    End Sub

    Private Sub mApiEv_TickGeneric(sender As Object, e As TickGenericEventArgs) Handles mApiEv.TickGeneric
        logMessage($"tickGeneric: id={e.TickerId}; field={CStr(e.TickType)}; value={e.Value}")
    End Sub

    Private Sub mApiEv_TickString(sender As Object, e As TickStringEventArgs) Handles mApiEv.TickString
        logMessage($"tickString: id={e.TickerId}; field={CStr(e.TickType)}; value={e.Value}")
    End Sub

    Private Sub mApiEv_TickPrice(sender As Object, e As TickPriceEventArgs) Handles mApiEv.TickPrice
        Select Case e.Field
            Case TickType.Ask
                showTickerValue(e.TickerId, TickerColumnAsk, CStr(e.Price))
            Case TickType.Bid
                showTickerValue(e.TickerId, TickerColumnBid, CStr(e.Price))
            Case TickType.Last
                showTickerValue(e.TickerId, TickerColumnLast, CStr(e.Price))
        End Select
    End Sub

    Private Sub mApiEv_TickSize(sender As Object, e As TickSizeEventArgs) Handles mApiEv.TickSize
        Select Case e.Field
            Case TickType.AskSize
                showTickerValue(e.TickerId, TickerColumnAskSize, CStr(e.Size))
            Case TickType.BidSize
                showTickerValue(e.TickerId, TickerColumnBidSize, CStr(e.Size))
            Case TickType.LastSize
                showTickerValue(e.TickerId, TickerColumnLastSize, CStr(e.Size))
            Case TickType.Volume
                showTickerValue(e.TickerId, TickerColumnVolume, CStr(e.Size))
        End Select
    End Sub

#End Region

#Region "Helper methods"

    Private Function allocateOrderGridRow(orderId As Integer) As DataGridViewRow
        Dim row = OrderGrid.Rows(OrderGrid.Rows.Add())
        row.Tag = orderId
        Return row
    End Function

    Private Sub cancelOrder(orderId As Integer)
        Dim entry = mOrders.Item(orderId)
        saveOrderStatus(orderId, OrderStatusPendingCancel)
        mApi.CancelOrder(orderId)
    End Sub

    Private Function checkEnoughInfoForContract(secType As String, localSymbol As String) As Boolean
        ' TWS expects at least the secType and localSymbol to be supplied
        Return secType <> "" And localSymbol <> ""
    End Function

    Private Sub connectToTWS()
        logMessage("Connecting to TWS")
        ConnectButton.Enabled = False

        mApi = New IBAPI(ServerTextBox.Text, CInt(PortTextBox.Text), CInt(ClientIdTextBox.Text))
        mApiEv = mApi.EventSource
        Dim logger = New ApiLogger(New FormattingLogger(""))
        mApi.Logger = logger
        mApi.SocketLogger = logger
        mApi.PerformanceLogger = logger

        mApi.Connect()
    End Sub

    Private Function contractToString(contract As Contract) As String
        Return $"secType={SecurityTypes.ToExternalString(contract.SecType)}; localSymbol={contract.LocalSymbol}; exchange={contract.Exchange}; currency={contract.CurrencyCode}"
    End Function

    Private Function createContract(secType As SecurityType, localSymbol As String, exchange As String, currency As String) As Contract
        ' NB: we use localSymbol, eg ESM1, because it's simplest. Alternatively you could 
        ' set eg symbol="ES", expiry="201106", exchange="GLOBEX", currency="USD".

        Return New Contract() With {
            .SecType = secType,
            .LocalSymbol = localSymbol,
            .Exchange = exchange,
            .CurrencyCode = currency
        }
    End Function

    Private Function createOrder(action As OrderAction, orderType As OrderType, quantity As Integer, limitPrice As Double, triggerPrice As Double) As Order
        Return New Order() With {
            .Action = action,
            .OrderType = orderType,
            .TotalQuantity = quantity,
            .LmtPrice = limitPrice,
            .AuxPrice = triggerPrice,
            .Transmit = True
        }
    End Function

    Private Sub disconnectFromTWS()
        logMessage("Disconnecting from TWS")
        mApi.Disconnect("User action")
    End Sub

    Private Sub ensureTickerGridRowExists(tickerId As Integer)
        If mTickers(tickerId).GridRow Is Nothing Then
            Dim row = TickerGrid.Rows(TickerGrid.Rows.Add())
            row.Tag = tickerId
            mTickers(tickerId).GridRow = row
            showTickerValue(tickerId, TickerColumnSymbol, mTickers(tickerId).Contract.LocalSymbol)
        End If
    End Sub

    Private Sub generateAndPlaceOrder(action As OrderAction)
        Dim contract = createContract(SecurityTypes.Parse(SectypeOrderCombo.Text), LocalSymbolOrderText.Text.ToUpper, ExchangeOrderCombo.Text, CurrencyOrderCombo.Text)
        Dim order = createOrder(action, OrderTypes.Parse(OrderTypeCombo.Text), Integer.Parse(QuantityText.Text), Double.Parse(LimitPriceText.Text), Double.Parse(TriggerPriceText.Text))
        mApi.PlaceOrder(order, contract)

        recordOrder(contract, order, New OrderState() With {.Status = OrderStatusCreated})
    End Sub

    Private Function getOrderStatus(orderId As Integer) As String
        Return mOrders(orderId).State.Status
    End Function

    Private Function isCancellableStatus(orderStatus As String) As Boolean
        Select Case orderStatus
            Case OrderStatusCreated
                Return False
            Case OrderStatusRejected
                Return False
            Case OrderStatusPendingCancel
                Return False
            Case OrderStatusPreSubmitted
                Return True
            Case OrderStatusSubmitted
                Return True
            Case OrderStatusCancelled
                Return False
            Case OrderStatusFilled
                Return False
            Case OrderStatusInactive
                Return True
            Case Else
                Throw New InvalidOperationException("Invalid order status")
        End Select
    End Function

    Private Sub logMessage(pMsg As String)
        LogText.AppendText(pMsg & vbCrLf)
    End Sub

    Private Sub recordOrder(contract As Contract, order As Order, state As OrderState)
        Dim orderId = order.OrderId

        Dim entry = New ActiveOrder
        entry.GridRow = allocateOrderGridRow(orderId)
        entry.Contract = contract
        entry.Order = order
        entry.State = state
        mOrders.Add(orderId, entry)
    End Sub

    Private Sub processMarketDepthError(tickerId As Integer, errorCode As Integer)
        If errorCode = 200 Then setStartMarketDepthButtonState()
    End Sub

    Private Sub processOrderError(orderId As Integer, errorCode As Integer)
        Select Case errorCode
            Case 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120,
                121, 125, 126, 127, 128, 129, 130, 132, 137, 140, 141, 144,
                152, 153, 154, 157, 160, 200, 201, 312, 313, 314, 315, 325, 328,
                334, 337, 338, 339, 343, 355, 361, 382, 383, 387, 388, 391, 395, 396, 397, 451
                saveOrderStatus(orderId, OrderStatusRejected)
            Case 200
                saveOrderStatus(orderId, OrderStatusCancelled)
        End Select
    End Sub

    Private Sub saveOrderStatus(orderId As Integer, status As String)
        Dim order = mOrders(orderId)
        order.State.Status = status
        showOrderValue(mOrders(orderId).GridRow, OrderColumnStatus, status)
    End Sub

    Private Sub setBuySellButtonsState()
        Dim errMsg = ""
        If mApi?.ConnectionState = ApiConnectionState.Connected And validateQuantity(errMsg) And checkEnoughInfoForContract(SectypeOrderCombo.Text, LocalSymbolOrderText.Text) Then
            BuyButton.Enabled = True
            SellButton.Enabled = True
            ErrorProvider.SetError(QuantityText, "")
        ElseIf errMsg <> "" Then
            logMessage(errMsg)
            ErrorProvider.SetIconAlignment(QuantityText, ErrorIconAlignment.BottomLeft)
            ErrorProvider.SetError(QuantityText, errMsg)
            BuyButton.Enabled = False
            SellButton.Enabled = False
        Else
            ErrorProvider.SetError(QuantityText, "")
            BuyButton.Enabled = False
            SellButton.Enabled = False
        End If
    End Sub

    Private Sub setStartMarketDepthButtonState()
        If mApi.ConnectionState = ApiConnectionState.Connected And checkEnoughInfoForContract(SecTypeDepthCombo.Text, LocalSymbolDepthText.Text) Then
            StartMarketDepthButton.Enabled = True
        Else
            StartMarketDepthButton.Enabled = False
        End If
    End Sub

    Private Sub setStartTickerButtonState()
        If mApi?.ConnectionState = ApiConnectionState.Connected And checkEnoughInfoForContract(SecTypeTickerCombo.Text, LocalSymbolTickerText.Text) Then
            StartTickerButton.Enabled = True
        Else
            StartTickerButton.Enabled = False
        End If
    End Sub

    Private Sub showOrder(orderId As Integer)
        Dim actOrder = mOrders.Item(orderId)
        Dim gridRow = actOrder.GridRow
        showOrderValue(gridRow, OrderColumnId, CStr(orderId))
        showOrderValue(gridRow, OrderColumnLocalSymbol, actOrder.Contract.LocalSymbol)
        showOrderValue(gridRow, OrderColumnAction, OrderActions.ToExternalString(actOrder.Order.Action))
        showOrderValue(gridRow, OrderColumnQuantity, CStr(actOrder.Order.TotalQuantity))
        showOrderValue(gridRow, OrderColumnStatus, actOrder.State.Status)
    End Sub

    Private Sub showOrderValue(orderRow As DataGridViewRow, columnName As String, value As String)
        orderRow.Cells(columnName).Value = value
    End Sub

    Private Sub showTickerValue(tickerId As Integer, columnName As String, value As String)
        If mTickers(tickerId) Is Nothing Or mTickers(tickerId)?.Contract Is Nothing Then
            ' the ticker has been stopped, but this tick was already on its way,
            ' so just ignore it
            Exit Sub
        End If
        ensureTickerGridRowExists(tickerId)
        mTickers(tickerId).GridRow.Cells(columnName).Value = value
    End Sub

    Private Sub startMarketDepth(contract As Contract)
        logMessage("Starting market depth: " & contractToString(contract))

        mDepthTickerId += 1
        mApi.RequestMarketDepth(mDepthTickerId, contract, 20)

        mDOMTickers(mDepthTickerId) = New Ticker() With {.Contract = contract}
    End Sub

    Private Sub startTicker(contract As Contract)
        logMessage("Starting ticker: " & contractToString(contract))

        mTickerId += 1
        mApi.RequestMarketData(mTickerId, contract, "", False)

        mTickers(mTickerId) = New Ticker() With {.Contract = contract}
    End Sub

    Private Sub stopAllTickers()
        logMessage("Stopping all tickers")
        For i = 0 To mTickerId - 1
            If mTickers(i)?.GridRow IsNot Nothing Then stopTicker(i)
        Next
        mTickerId = 0
    End Sub

    Private Sub stopMarketDepth()
        StopMarketDepthButton.Enabled = False

        If mDOMTickers(mDepthTickerId)?.Contract Is Nothing Then Return

        logMessage("Stopping market depth: " + contractToString(mDOMTickers(mDepthTickerId).Contract))
        mDOMTickers(mDepthTickerId) = Nothing

        mApi.CancelMarketDepth(mDepthTickerId)

        BidGrid.Rows.Clear()
        BidGrid.Refresh()
        AskGrid.Rows.Clear()
        AskGrid.Refresh()

        setStartMarketDepthButtonState()
    End Sub

    Private Sub stopTicker(tickerId As Integer)
        logMessage("Stopping ticker: " & contractToString(mTickers(tickerId).Contract))
        mApi.CancelMarketData(tickerId)
        mTickers(tickerId).Contract = Nothing
        TickerGrid.Rows.Remove(mTickers(tickerId).GridRow)
        mTickers(tickerId).GridRow = Nothing
    End Sub

    Private Function validateQuantity(ByRef errorMessage As String) As Boolean
        Dim quantity As Integer
        If Not Integer.TryParse(QuantityText.Text, quantity) Then
            errorMessage = "Quantity must be an integer"
            Return False
        ElseIf quantity <= 0 Or quantity > 100 Then
            errorMessage = "Quantity must not be less than 1 or more than 100"
            Return False
        Else
            errorMessage = ""
            Return True
        End If
    End Function

#End Region

End Class
