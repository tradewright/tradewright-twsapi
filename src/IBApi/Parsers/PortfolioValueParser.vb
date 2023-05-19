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

Friend NotInheritable Class PortfolioValueParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(PortfolioValueParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lContract As New Contract

        If pVersion >= 6 Then lContract.ConId = Await _Reader.GetIntAsync("Contract id")

        lContract.Symbol = Await _Reader.GetStringAsync("Symbol")
        lContract.SecType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))
        lContract.Expiry = Await _Reader.GetStringAsync("Expiry")
        lContract.Strike = Await _Reader.GetDoubleAsync("Strike")
        lContract.OptRight = IBAPI.OptionRights.Parse(Await _Reader.GetStringAsync("Right"))

        If pVersion >= 7 Then
            lContract.Multiplier = Await _Reader.GetDoubleAsync("Multiplier")
            If lContract.Multiplier = 0 Then lContract.Multiplier = 1
            lContract.Exchange = Await _Reader.GetStringAsync("Exchange")
        End If

        lContract.CurrencyCode = Await _Reader.GetStringAsync("Currency")

        If pVersion >= 2 Then lContract.LocalSymbol = Await _Reader.GetStringAsync("Local Symbol")
        If pVersion >= 8 Then lContract.TradingClass = Await _Reader.GetStringAsync("Trading Class")

        Dim lPosition = Await _Reader.GetDecimalAsync("POSITION")
        Dim lMarketPrice = Await _Reader.GetDoubleAsync("Market price")
        Dim lMarketValue = Await _Reader.GetDoubleAsync("Market Value")
        Dim lAverageCost As Double
        Dim lUnrealizedPNL As Double
        Dim lRealizedPNL As Double
        If pVersion >= 3 Then
            lAverageCost = Await _Reader.GetDoubleAsync("Avg cost")
            lUnrealizedPNL = Await _Reader.GetDoubleAsync("Unrealized PNL")
            lRealizedPNL = Await _Reader.GetDoubleAsync("Realized PNL")
        End If

        Dim lAccountName = If(pVersion >= 4, Await _Reader.GetStringAsync("Account Name"), "")

        LogSocketInputMessage(ModuleName,"ParseAsync")

        Try
        _EventConsumers.AccountDataConsumer?.NotifyPortfolioUpdate(New UpdatePortfolioEventArgs(timestamp, lContract, lPosition, lMarketPrice, lMarketValue, lAverageCost, lUnrealizedPNL, lRealizedPNL, lAccountName))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifyPortfolioUpdate", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.PortfolioValue
        End Get
    End Property

End Class
