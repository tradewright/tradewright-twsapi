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

Public Interface IHistoricalDataConsumer

    Sub EndHistoricalBidAsks(e As RequestEndEventArgs)

    Sub EndHistoricalMidpoints(e As RequestEndEventArgs)

    Sub EndHistoricalTrades(e As RequestEndEventArgs)

    Sub EndHistoricalBars(e As HistoricalBarsRequestEventArgs)

    Sub NotifyHistoricalBarError(e As RequestErrorEventArgs)

    Sub NotifyHeadTimestamp(e As HeadTimestampEventArgs)

    Sub NotifyHistogramData(e As HistogramDataEventArgs)

    Sub NotifyHistoricalBar(e As HistoricalBarEventArgs)

    Sub NotifyHistoricalBidAsk(e As HistoricalBidAskEventArgs)

    Sub NotifyHistoricalMidpoint(e As HistoricalMidpointEventArgs)

    Sub NotifyHistoricalSchedule(e As HistoricalScheduleEventArgs)

    Sub NotifyHistoricalTrade(e As HistoricalTradeEventArgs)

    Sub StartHistoricalBars(e As HistoricalBarsRequestEventArgs)

    Sub UpdateHistoricalBar(e As HistoricalBarEventArgs)

    '@================================================================================
    ' Helper Functions
    '@================================================================================
End Interface