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

Friend NotInheritable Class PositionMultiParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(PositionMultiParser)

       Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("Request id")
        Dim account = Await _Reader.GetStringAsync("Account")

        Dim contract = New Contract()
        contract.ConId = Await _Reader.GetIntAsync("Conid")
        contract.Symbol = Await _Reader.GetStringAsync("Symbol")
        contract.SecType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))
        contract.Expiry = Await _Reader.GetStringAsync("Expiry")
        contract.Strike = Await _Reader.GetDoubleAsync("Strike")
        contract.OptRight = IBAPI.OptionRights.Parse(Await _Reader.GetStringAsync("Right"))
        Dim mult = Await _Reader.GetStringAsync("Multiplier")
        contract.Multiplier = If(mult = "", 1, CInt(mult))
        contract.Exchange = Await _Reader.GetStringAsync("Exchange")
        contract.CurrencyCode = Await _Reader.GetStringAsync("CurrencyCode")
        contract.LocalSymbol = Await _Reader.GetStringAsync("LocalSymbol")
        contract.TradingClass = Await _Reader.GetStringAsync("TradingClass")

        Dim position = Await _Reader.GetNullableDoubleAsync("Position")
        Dim avgCost = Await _Reader.GetNullableDoubleAsync("Avg Cost")
        Dim modelCode = Await _Reader.GetStringAsync("Model Code")

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
        _EventConsumers.AccountDataConsumer?.NotifyPositionMulti(New PositionMultiEventArgs(timestamp, requestId, account, modelCode, contract, position, avgCost))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifyPositionMulti", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.PositionMulti
        End Get
    End Property

End Class
