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

Friend Class ApiEventConsumers
    Friend Property AccountDataConsumer() As IAccountDataConsumer

    Friend Property ConnectionStatusConsumer() As IConnectionStatusConsumer

    Friend Property ContractDetailsConsumer() As IContractDetailsConsumer

    Friend Property DisplayGroupConsumer() As IDisplayGroupConsumer

    Friend Property ErrorAndNotificationConsumer As IErrorAndNotificationConsumer

    Friend Property FundamentalDataConsumer As IFundamentalDataConsumer

    Friend Property HistoricalDataConsumer() As IHistoricalDataConsumer

    Friend Property MarketDataConsumer() As IMarketDataConsumer

    Friend Property MarketDepthConsumer() As IMarketDepthConsumer

    Friend Property NewsConsumer() As INewsConsumer

    Friend Property OrderInfoConsumer() As IOrderInfoConsumer

    Friend Property PerformanceDataConsumer As IPerformanceDataConsumer

    Friend Property ScannerDataConsumer As IScannerDataConsumer

    Friend Property SocketDataConsumer() As ISocketDataConsumer

    Friend NotifyOpenOrderAction As Action(Of OpenOrderEventArgs)

    Friend Sub NotifyOpenOrder(e As OpenOrderEventArgs)
        NotifyOpenOrderAction?(e)
        OrderInfoConsumer?.NotifyOpenOrder(e)
    End Sub

End Class
