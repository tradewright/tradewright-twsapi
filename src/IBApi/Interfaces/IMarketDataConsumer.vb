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

Public Interface IMarketDataConsumer

    Sub EndTickSnapshot(e As RequestEndEventArgs)

    Sub NotifyMarketDataError(e As RequestErrorEventArgs)

    Sub NotifyMarketDataType(e As MarketDataTypeEventArgs)

    Sub NotifyRealtimeBar(e As RealtimeBarEventArgs)

    Sub NotifyRerouteData(e As RerouteDataEventArgs)

    Sub NotifySmartComponents(e As SmartComponentsEventArgs)

    Sub NotifyTickByTickAllLast(e As TickByTickAllLastEventArgs)

    Sub NotifyTickByTickBidAsk(e As TickByTickBidAskEventArgs)

    Sub NotifyTickByTickMidPoint(e As TickByTickMidPointEventArgs)

    Sub NotifyTickEFP(e As TickEFPEventArgs)

    Sub NotifyTickGeneric(e As TickGenericEventArgs)

    Sub NotifyTickOptionComputation(e As TickOptionComputationEventArgs)

    Sub NotifyTickPrice(e As TickPriceEventArgs)

    Sub NotifyTickRequestParams(e As TickRequestParamsEventArgs)

    Sub NotifyTickSize(e As TickSizeEventArgs)

    Sub NotifyTickString(e As TickStringEventArgs)

End Interface