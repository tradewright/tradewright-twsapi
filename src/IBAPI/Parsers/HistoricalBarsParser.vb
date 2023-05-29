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

Friend NotInheritable Class HistoricalBarsParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(HistoricalBarsParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim reqId = Await _Reader.GetIntAsync("Request id")
        Dim requestId = IdManager.GetCallerId(reqId, IdType.HistoricalData)

        Dim startDate As Date
        Dim endDate As Date
        If pVersion >= 2 Then
            startDate = IBAPI.TwsDateStringToDate(Await _Reader.GetStringAsync("Start date")).theDate
            endDate = IBAPI.TwsDateStringToDate(Await _Reader.GetStringAsync("End date")).theDate
        End If

        Dim barCount = Await _Reader.GetIntAsync("Item count")
        Debug.Print("Bars retrieved: " & barCount)

        _EventConsumers.HistoricalDataConsumer?.StartHistoricalBars(New HistoricalBarsRequestEventArgs(timestamp, requestId, startDate, endDate, barCount))

        For i = 0 To barCount - 1
            Dim bar As New Bar With {
                .TimeStamp = IBAPI.TwsDateStringToDate(Await _Reader.GetStringAsync("Bar date")).theDate,
                .OpenValue = Await _Reader.GetDoubleAsync("Open"),
                .HighValue = Await _Reader.GetDoubleAsync("High"),
                .LowValue = Await _Reader.GetDoubleAsync("Low"),
                .CloseValue = Await _Reader.GetDoubleAsync("Close"),
                .Volume = Await _Reader.GetLongAsync("Volume"),
                .WAP = Await _Reader.GetDecimalAsync("WAP")
            }
            If ServerVersion < ApiServerVersion.SYNT_REALTIME_BARS Then Await _Reader.GetBooleanAsync("Has gaps")
            If pVersion >= 3 Then bar.TickVolume = Await _Reader.GetIntAsync("Tick volume")

            _EventConsumers.HistoricalDataConsumer?.NotifyHistoricalBar(New HistoricalBarEventArgs(timestamp, requestId, bar))

        Next

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.HistoricalDataConsumer?.EndHistoricalBars(New HistoricalBarsRequestEventArgs(timestamp, requestId, startDate, endDate, barCount))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("EndHistoricalData", e)
        End Try
    End Function


    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.HistoricalBar
        End Get
    End Property

End Class
