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

Friend NotInheritable Class TickPriceParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(TickPriceParser)

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lTickerId = Await _Reader.GetIntAsync("Ticker id")
        Dim lTickType = DirectCast(Await _Reader.GetIntAsync("Tick type"), TickType)
        Dim lPrice = Await _Reader.GetDoubleAsync("Price")

        Dim lSize As Integer
        If version >= 2 Then lSize = Await _Reader.GetIntAsync("Size")

        Dim lAttributes = New TickAttributes

        If version >= 3 Then
            Const CanAutoExecute As Integer = &H1
            Const PastLimit As Integer = &H2
            Const PreOpen As Integer = &H4

            Dim attrMask = Await _Reader.GetIntAsync("Attr Mask")

            lAttributes.CanAutoExecute = (attrMask = 1)

            If ServerVersion >= ApiServerVersion.PAST_LIMIT Then
                lAttributes.CanAutoExecute = (attrMask And CanAutoExecute) > 0
                lAttributes.PastLimit = (attrMask And PastLimit) > 0
                If ServerVersion >= ApiServerVersion.PRE_OPEN_BID_ASK Then
                    lAttributes.PreOpen = (attrMask And PreOpen) > 0
                End If
            End If
        End If

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.MarketDataConsumer?.NotifyTickPrice(New TickPriceEventArgs(timestamp, IdManager.GetCallerId(lTickerId, IdType.MarketData), lTickType, lPrice, lSize, lAttributes))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyTickPrice", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.TickPrice
        End Get
    End Property

End Class
