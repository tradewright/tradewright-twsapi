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

Friend NotInheritable Class OrderStatusParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(OrderStatusParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lorderId = Await _Reader.GetIntAsync("id")
        Dim lStatus = Await _Reader.GetStringAsync("Status")
        Dim lFilled = Await _Reader.GetDecimalAsync("Filled")
        Dim lRemaining = Await _Reader.GetDecimalAsync("Remaining")
        Dim lAvgFillPrice = Await _Reader.GetDoubleAsync("Avg fill price")

        Dim lPermId As Integer
        If pVersion >= 2 Then lPermId = Await _Reader.GetIntAsync("Perm id")

        Dim lParentId As Integer
        If pVersion >= 3 Then lParentId = Await _Reader.GetIntAsync("Parent id")

        Dim lLastFillPrice As Double
        If pVersion >= 4 Then lLastFillPrice = Await _Reader.GetDoubleAsync("Last fill price")

        Dim lClientID As Integer
        If pVersion >= 5 Then lClientID = Await _Reader.GetIntAsync("Client id")

        Dim lWhyHeld = ""
        If pVersion >= 6 Then lWhyHeld = Await _Reader.GetStringAsync("Why held")

        Dim marketCapPrice = Double.MaxValue

        If ServerVersion >= ApiServerVersion.MARKET_CAP_PRICE Then
            marketCapPrice = Await _Reader.GetDoubleAsync("Market cap price")
        End If

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.OrderInfoConsumer?.NotifyOrderStatus(New OrderStatusEventArgs(timestamp, lorderId, lStatus, lFilled, lRemaining, lAvgFillPrice, lPermId, lParentId, lLastFillPrice, lClientID, lWhyHeld, marketCapPrice))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyOrderStatus", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.OrderStatus
        End Get
    End Property

End Class
