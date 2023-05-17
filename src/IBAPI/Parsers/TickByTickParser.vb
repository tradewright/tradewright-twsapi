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

Imports System.Threading.Tasks

Friend NotInheritable Class TickByTickParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(TickByTickParser)

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp As Date) As Task(Of Boolean)
        Dim tickerId = Await _Reader.GetIntAsync("Ticker id")
        Dim dataType = DirectCast(Await _Reader.GetIntAsync("Data type"), TickByTickDataType)
        Dim time = IBAPI.UnixTimestampToDateTime(Await _Reader.GetLongAsync("Time"))

        Select Case dataType
            Case TickByTickDataType.None
            Case TickByTickDataType.Last,
                 TickByTickDataType.AllLast
                Dim price = Await _Reader.GetDoubleAsync("Price")
                Dim size = Await _Reader.GetLongAsync("Size")

                Const PastLimit As Integer = &H1
                Const Unreported As Integer = &H2

                Dim attributes = New TickAttributes
                Dim attrMask = Await _Reader.GetIntAsync("Attr Mask")
                attributes.PastLimit = (attrMask And PastLimit) > 0
                attributes.Unreported = (attrMask And Unreported) > 0

                Dim exchange = Await _Reader.GetStringAsync("Exchange")
                Dim specialConditions = Await _Reader.GetStringAsync("Special conditions")

                LogSocketInputMessage(ModuleName, "ParseAsync")

                Try
                    _EventConsumers.MarketDataConsumer?.NotifyTickByTickAllLast(New TickByTickAllLastEventArgs(timestamp, tickerId, dataType, time, price, size, attributes, exchange, specialConditions))
                    Return True
                Catch e As Exception
                    Throw New ApiApplicationException("NotifyTickByTickAllLast", e)
                End Try

            Case TickByTickDataType.BidAsk
                Dim bidPrice = Await _Reader.GetDoubleAsync("Bid Price")
                Dim askPrice = Await _Reader.GetDoubleAsync("Ask Price")
                Dim bidSize = Await _Reader.GetLongAsync("Bid Size")
                Dim askSize = Await _Reader.GetLongAsync("Ask Size")

                Const BidPastLow As Integer = &H1
                Const AskPastHigh As Integer = &H2

                Dim attributes = New TickAttributes
                Dim attrMask = Await _Reader.GetIntAsync("Attr Mask")
                attributes.BidPastLow = (attrMask And BidPastLow) > 0
                attributes.AskPastHigh = (attrMask And AskPastHigh) > 0

                LogSocketInputMessage(ModuleName, "ParseAsync")

                Try
                    _EventConsumers.MarketDataConsumer?.NotifyTickByTickBidAsk(New TickByTickBidAskEventArgs(timestamp, tickerId, time, bidPrice, askPrice, bidSize, askSize, attributes))
                    Return True
                Catch e As Exception
                    Throw New ApiApplicationException("NotifyTickByTickBidAsk", e)
                End Try

            Case TickByTickDataType.MidPoint
                Dim midPoint = Await _Reader.GetDoubleAsync("Bid Price")

                LogSocketInputMessage(ModuleName, "ParseAsync")

                Try
                    _EventConsumers.MarketDataConsumer?.NotifyTickByTickMidPoint(New TickByTickMidPointEventArgs(timestamp, tickerId, time, midPoint))
                    Return True
                Catch e As Exception
                    Throw New ApiApplicationException("NotifyTickByTickMidPoint", e)
                End Try

        End Select

        Return False

    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.TickByTick
        End Get
    End Property

End Class
