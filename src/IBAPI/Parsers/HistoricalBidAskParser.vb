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

Friend Class HistoricalBidAskParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(HistoricalBidAskParser)

    Private ReadOnly mTickLists As New Dictionary(Of Integer, List(Of HistoricalBidAskEventArgs))

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp As Date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("Request Id")
        Dim numberOfTicks = Await _Reader.GetIntAsync("NumTicks")

        Dim ticks As List(Of HistoricalBidAskEventArgs) = Nothing
        If Not mTickLists.TryGetValue(requestId, ticks) Then
            ticks = New List(Of HistoricalBidAskEventArgs)
            mTickLists.Add(requestId, ticks)
        End If

        For i = 1 To numberOfTicks
            Dim time = IBAPI.UnixTimestampToDateTime(Await _Reader.GetLongAsync("Time"))

            Const AskPastHigh As Integer = &H1
            Const BidPastLow As Integer = &H2

            Dim attributes = New TickAttributes
            Dim attrMask = Await _Reader.GetIntAsync("Attr Mask")
            attributes.AskPastHigh = (attrMask And AskPastHigh) > 0
            attributes.BidPastLow = (attrMask And BidPastLow) > 0

            Dim bidPrice = Await _Reader.GetDoubleAsync("Price")
            Dim askPrice = Await _Reader.GetDoubleAsync("Price")
            Dim bidSize = Await _Reader.GetLongAsync("Size")
            Dim askSize = Await _Reader.GetLongAsync("Size")
            ticks.Add(New HistoricalBidAskEventArgs(requestId, time, bidPrice, bidSize, askPrice, askSize, attributes))
        Next

        Dim done = Await _Reader.GetBoolFromIntAsync("Done")

        LogSocketInputMessage(ModuleName, "ParseAsync")

        If done Then
            Dim t As Task
            t = New Task(Async Sub()
                             For Each tick In ticks
                                 Try
                                     _EventConsumers.HistoricalDataConsumer?.NotifyHistoricalBidAsk(tick)
                                 Catch e As Exception
                                     Throw New ApiApplicationException("NotifyHistoricalBidAsk", e)
                                 End Try
                                 Await Task.Delay(1)
                             Next
                             _EventConsumers.HistoricalDataConsumer?.EndHistoricalBidAsks(New RequestEndEventArgs(timestamp, requestId))
                             mTickLists.Remove(requestId)
                         End Sub)
            t.Start(TaskScheduler.FromCurrentSynchronizationContext)
        End If

        Return True
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.HistoricalTickBidAsk
        End Get
    End Property


End Class
