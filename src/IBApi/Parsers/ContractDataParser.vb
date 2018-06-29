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

Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Friend NotInheritable Class ContractDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(ContractDataParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lReqId As Integer
        If (pVersion >= 3) Then lReqId = IdManager.GetCallerId(Await _Reader.GetIntAsync("Req Id"), IdType.ContractData)

        Dim lContract As New Contract
        Dim lContractDetails As New ContractDetails With {
            .Summary = lContract
        }

        lContract.Symbol = Await _Reader.GetStringAsync("Symbol")
        lContract.SecType = SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))

        Dim lExpiry = Await _Reader.GetStringAsync("Expiry")
        If Not String.IsNullOrEmpty(lExpiry) Then
            Dim ar() = lExpiry.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            If ar.Length > 0 Then lContract.Expiry = ar(0)
            If ar.Length > 1 Then lContractDetails.LastTradeTime = ar(1)
        End If

        lContract.Strike = Await _Reader.GetDoubleAsync("Strike")
        lContract.OptRight = OptionRights.Parse(Await _Reader.GetStringAsync("Right"))
        lContract.Exchange = Await _Reader.GetStringAsync("Exchange")
        lContract.CurrencyCode = Await _Reader.GetStringAsync("Currency")
        lContract.LocalSymbol = Await _Reader.GetStringAsync("Local Symbol")
        lContractDetails.MarketName = Await _Reader.GetStringAsync("Market Name")
        lContract.TradingClass = Await _Reader.GetStringAsync("Trading class")
        lContract.ConId = Await _Reader.GetIntAsync("Contract id")

        lContractDetails.MinTick = Await _Reader.GetDoubleAsync("Minimum tick")
        ' note that IB gives very small tick sizes for some UK stocks, eg 0.000001 for VOD and TSCO
        ' (possibly all FTSE 100 stocks). This causes us tick encoding problems, so we up it to
        ' something that reflects reality!
        If lContract.CurrencyCode = "GBP" And lContract.SecType = SecurityType.Stock And lContractDetails.MinTick < 0.0001 Then lContractDetails.MinTick = 0.0001

        If ServerVersion >= ApiServerVersion.MD_SIZE_MULTIPLIER Then lContractDetails.MDSizeMultiplier = Await _Reader.GetIntAsync("MDSizeMultiplier")

        lContract.Multiplier = Await _Reader.GetIntAsync("Multiplier")
        If lContract.Multiplier = 0 Then lContract.Multiplier = 1

        lContractDetails.OrderTypes = Await _Reader.GetStringAsync("Order types")
        lContractDetails.ValidExchanges = Await _Reader.GetStringAsync("Valid exchanges")

        If pVersion >= 2 Then
            lContractDetails.PriceMagnifier = Await _Reader.GetIntAsync("Price magnifier")
        Else
            If lContract.CurrencyCode = "GBP" Then
                lContractDetails.PriceMagnifier = 100
            Else
                lContractDetails.PriceMagnifier = 1
            End If
        End If

        lContractDetails.MinTick = lContractDetails.MinTick * lContractDetails.PriceMagnifier

        If pVersion >= 4 Then lContractDetails.UnderConId = Await _Reader.GetIntAsync("UnderConId")

        If pVersion >= 5 Then
            lContractDetails.LongName = Await _Reader.GetStringAsync("Long name")
            lContract.PrimaryExch = Await _Reader.GetStringAsync("Primary Exchange")
        End If

        If pVersion >= 6 Then
            lContractDetails.ContractMonth = Await _Reader.GetStringAsync("ContractMonth")
            lContractDetails.Industry = Await _Reader.GetStringAsync("Industry")
            lContractDetails.Category = Await _Reader.GetStringAsync("Category")
            lContractDetails.Subcategory = Await _Reader.GetStringAsync("Subcategory")
            lContractDetails.TimeZoneId = Await _Reader.GetStringAsync("TimeZoneId")
            lContractDetails.TradingHours = Await _Reader.GetStringAsync("TradingHours")
            lContractDetails.LiquidHours = Await _Reader.GetStringAsync("LiquidHours")
        End If

        If pVersion >= 8 Then
            lContractDetails.EvRule = Await _Reader.GetStringAsync("EvRule")
            lContractDetails.EvMultiplier = Await _Reader.GetDoubleAsync("EvMultiplier")
        End If

        If pVersion >= 7 Then
            Dim lSecIdListCount = Await _Reader.GetIntAsync("SecIdListCount")
            If lSecIdListCount > 0 Then
                Dim lSecIdList = New List(Of TagValue)
                For i = 0 To lSecIdListCount - 1
                    Dim tv = New TagValue With {
                        .Tag = Await _Reader.GetStringAsync("Tag"),
                        .Value = Await _Reader.GetStringAsync("Value")
                    }
                    lSecIdList.Add(tv)
                Next
                lContractDetails.SecIdList = lSecIdList
            End If
        End If

        If ServerVersion >= ApiServerVersion.AGG_GROUP Then lContractDetails.AggGroup = Await _Reader.GetIntAsync("Agg Group")

        If ServerVersion >= ApiServerVersion.UNDERLYING_INFO Then
            lContractDetails.UnderSymbol = Await _Reader.GetStringAsync("Under Symbol")
            lContractDetails.UnderSecType = SecurityTypes.Parse(Await _Reader.GetStringAsync("UnderSecType"))
        End If

        If ServerVersion >= ApiServerVersion.MARKET_RULES Then lContractDetails.MarketRuleIds = Await _Reader.GetStringAsync("Market Rule Ids")

        If ServerVersion >= ApiServerVersion.REAL_EXPIRATION_DATE Then lContractDetails.RealExpirationDate = Await _Reader.GetStringAsync("Real Expiration Date")

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.ContractDetailsConsumer?.NotifyContract(New ContractDetailsEventArgs(timestamp, lReqId, lContractDetails))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyContract", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.ContractData
        End Get
    End Property

End Class
