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

Imports System.Threading.Tasks

Friend NotInheritable Class HistoricalDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(HistoricalDataParser)

       Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim reqId = Await _Reader.GetIntAsync("Request id")
        Dim requestId = IdManager.GetCallerId(reqId, IdType.HistoricalData)

        Dim startDate = String.Empty
        Dim endDate = String.Empty
        If pVersion >= 2 Then
            startDate = Await _Reader.GetStringAsync("Start date")
            endDate = Await _Reader.GetStringAsync("End date")
        End If

        Dim barCount = Await _Reader.GetIntAsync("Item count")
        Debug.Print("Bars retrieved: " & barCount)

        _EventConsumers.HistDataConsumer?.StartHistoricalData(New HistoricalDataRequestEventArgs(timestamp, requestId, startDate, endDate, barCount))

        For i = 0 To barCount - 1
            Dim bar As New Bar With {
                .TimeStamp = TwsDateStringToDate(Await _Reader.GetStringAsync("Bar date")).theDate,
                .OpenValue = Await _Reader.GetDoubleAsync("Open"),
                .HighValue = Await _Reader.GetDoubleAsync("High"),
                .LowValue = Await _Reader.GetDoubleAsync("Low"),
                .CloseValue = Await _Reader.GetDoubleAsync("Close"),
                .Volume = Await _Reader.GetLongAsync("Volume"),
                .WAP = Await _Reader.GetDoubleAsync("WAP")
            }
            If ServerVersion < ApiServerVersion.SYNT_REALTIME_BARS Then Await _Reader.GetBooleanAsync("Has gaps")
            If pVersion >= 3 Then bar.TickVolume = Await _Reader.GetIntAsync("Tick volume")

            _EventConsumers.HistDataConsumer?.NotifyHistoricalData(New HistoricalDataEventArgs(timestamp, requestId, bar))

        Next

        LogSocketInputMessage(ModuleName,"ParseAsync")

        Try
        _EventConsumers.HistDataConsumer?.EndHistoricalData(New HistoricalDataRequestEventArgs(timestamp, requestId, startDate, endDate, barCount))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("EndHistoricalData", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.HistoricalData
        End Get
    End Property

End Class
