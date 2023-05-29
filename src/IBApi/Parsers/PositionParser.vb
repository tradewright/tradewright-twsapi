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

Friend NotInheritable Class PositionParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(PositionParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lAccount = Await _Reader.GetStringAsync("Account")
        Dim lContract As New Contract With {
            .ContractId = Await _Reader.GetIntAsync("Contract id"),
            .Symbol = Await _Reader.GetStringAsync("Symbol"),
            .SecurityType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("SecType")),
            .Expiry = Await _Reader.GetStringAsync("Expiry"),
            .Strike = Await _Reader.GetDoubleAsync("Strike"),
            .OptionRight = IBAPI.OptionRights.Parse(Await _Reader.GetStringAsync("Right")),
            .Multiplier = Await _Reader.GetDoubleAsync("Multiplier"),
            .Exchange = Await _Reader.GetStringAsync("Exchange"),
            .CurrencyCode = Await _Reader.GetStringAsync("Currency"),
            .LocalSymbol = Await _Reader.GetStringAsync("LocalSymbol"),
            .TradingClass = Await _Reader.GetStringAsync("Trading Class")
        }

        If lContract.Multiplier = 0 Then lContract.Multiplier = 1

        Dim lPosition? = Await _Reader.GetNullableDecimalAsync("Position")

        Dim lAverageCost As Double
        If pVersion >= 3 Then lAverageCost = Await _Reader.GetDoubleAsync("Average Cost")

        LogSocketInputMessage(ModuleName,"ParseAsync")

        Try
        _EventConsumers.AccountDataConsumer?.NotifyPosition(New PositionEventArgs(timestamp, lAccount, lContract, lPosition, lAverageCost))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifyPosition", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.Position
        End Get
    End Property

End Class
