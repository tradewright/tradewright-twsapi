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

Friend NotInheritable Class RealtimeBarsParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(RealtimeBarsParser)

       Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lReqId = Await _Reader.GetIntAsync("ReqId")

        Dim bar = New Bar With {
            .TimeStamp = IBAPI.UnixTimestampToDateTime(Await _Reader.GetLongAsync("System Time")).ToLocalTime,
            .OpenValue = Await _Reader.GetDoubleAsync("Open"),
            .HighValue = Await _Reader.GetDoubleAsync("High"),
            .LowValue = Await _Reader.GetDoubleAsync("Low"),
            .CloseValue = Await _Reader.GetDoubleAsync("Close"),
            .Volume = Await _Reader.GetIntAsync("Volume"),
            .WAP = Await _Reader.GetDoubleAsync("Wap"),
            .TickVolume = Await _Reader.GetIntAsync("Count")
        }

        LogSocketInputMessage(ModuleName,"ParseAsync")

        Try
        _EventConsumers.MarketDataConsumer?.NotifyRealtimeBar(New RealtimeBarEventArgs(timestamp, lReqId, bar))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifyRealtimeBar", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.RealtimeBars
        End Get
    End Property

End Class
