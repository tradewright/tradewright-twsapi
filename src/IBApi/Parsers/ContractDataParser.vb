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

Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Friend NotInheritable Class ContractDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(ContractDataParser)

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp As Date) As Task(Of Boolean)
        Dim contract As New Contract
        Dim contractDetails As New ContractDetails With {
            .Summary = contract
        }

        Dim requestId As Integer
        If (version >= 3) Then requestId = IdManager.GetCallerId(Await _Reader.GetIntAsync("Req Id"), IdType.ContractData)

        contract.Symbol = Await _Reader.GetStringAsync("Symbol")
        contract.SecurityType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))

        Dim lExpiry = Await _Reader.GetStringAsync("Expiry")
        If Not String.IsNullOrEmpty(lExpiry) Then
            Dim ar() = lExpiry.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            If ar.Length > 0 Then contract.Expiry = ar(0)
            If ar.Length > 1 Then contractDetails.LastTradeTime = ar(1)
        End If

        contract.Strike = Await _Reader.GetDoubleAsync("Strike")
        contract.OptionRight = IBAPI.OptionRights.Parse(Await _Reader.GetStringAsync("Right"))
        contract.Exchange = Await _Reader.GetStringAsync("Exchange")
        contract.CurrencyCode = Await _Reader.GetStringAsync("Currency")
        contract.LocalSymbol = Await _Reader.GetStringAsync("Local Symbol")
        contractDetails.MarketName = Await _Reader.GetStringAsync("Market Name")
        contract.TradingClass = Await _Reader.GetStringAsync("Trading class")
        contract.ContractId = Await _Reader.GetIntAsync("Contract id")

        contractDetails.MinimumTick = Await _Reader.GetDoubleAsync("Minimum tick")
        ' note that IB gives very small tick sizes for some UK stocks, eg 0.000001 for VOD and TSCO
        ' (possibly all FTSE 100 stocks). This causes us tick encoding problems, so we up it to
        ' something that reflects reality!
        If contract.CurrencyCode = "GBP" And contract.SecurityType = SecurityType.Stock And contractDetails.MinimumTick < 0.0001 Then contractDetails.MinimumTick = 0.0001

        If ServerVersion >= ApiServerVersion.MD_SIZE_MULTIPLIER And ServerVersion < ApiServerVersion.SIZE_RULES Then
            ' MDSizeMultiplier is no longer used
            Await _Reader.GetIntAsync("MDSizeMultiplier")
        End If

        contract.Multiplier = Await _Reader.GetDoubleAsync("Multiplier")
        If contract.Multiplier = 0 Then contract.Multiplier = 1

        contractDetails.OrderTypes = Await _Reader.GetStringAsync("Order types")
        contractDetails.ValidExchanges = Await _Reader.GetStringAsync("Valid exchanges")

        If version >= 2 Then
            contractDetails.PriceMagnifier = Await _Reader.GetIntAsync("Price magnifier")
        Else
            If contract.CurrencyCode = "GBP" Then
                contractDetails.PriceMagnifier = 100
            Else
                contractDetails.PriceMagnifier = 1
            End If
        End If

        contractDetails.MinimumTick *= contractDetails.PriceMagnifier

        If version >= 4 Then contractDetails.UnderlyingContractId = Await _Reader.GetIntAsync("UnderConId")

        If version >= 5 Then
            contractDetails.LongName = Await _Reader.GetStringAsync("Long name")
            contract.PrimaryExch = Await _Reader.GetStringAsync("Primary Exchange")
        End If

        If version >= 6 Then
            contractDetails.ContractMonth = Await _Reader.GetStringAsync("ContractMonth")
            contractDetails.Industry = Await _Reader.GetStringAsync("Industry")
            contractDetails.Category = Await _Reader.GetStringAsync("Category")
            contractDetails.Subcategory = Await _Reader.GetStringAsync("Subcategory")
            contractDetails.TimeZoneId = Await _Reader.GetStringAsync("TimeZoneId")
            contractDetails.TradingHours = Await _Reader.GetStringAsync("TradingHours")
            contractDetails.LiquidHours = Await _Reader.GetStringAsync("LiquidHours")
        End If

        If version >= 8 Then
            contractDetails.EvRule = Await _Reader.GetStringAsync("EvRule")
            contractDetails.EvMultiplier = Await _Reader.GetDoubleAsync("EvMultiplier")
        End If

        If version >= 7 Then
            Dim secIdListCount = Await _Reader.GetIntAsync("SecIdListCount")
            If secIdListCount > 0 Then
                Dim secIdList = New List(Of TagValue)
                For i = 0 To secIdListCount - 1
                    Dim tv = New TagValue With {
                        .Tag = Await _Reader.GetStringAsync("Tag"),
                        .Value = Await _Reader.GetStringAsync("Value")
                    }
                    secIdList.Add(tv)
                Next
                contractDetails.SecurityIdsList = secIdList
            End If
        End If

        If ServerVersion >= ApiServerVersion.AGG_GROUP Then contractDetails.AggregatedGroup = Await _Reader.GetIntAsync("Agg Group")

        If ServerVersion >= ApiServerVersion.UNDERLYING_INFO Then
            contractDetails.UnderlyingSymbol = Await _Reader.GetStringAsync("Under Symbol")
            contractDetails.UnderlyingSecurityType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("UnderSecType"))
        End If

        If ServerVersion >= ApiServerVersion.MARKET_RULES Then contractDetails.MarketRuleIds = Await _Reader.GetStringAsync("Market Rule Ids")

        If ServerVersion >= ApiServerVersion.REAL_EXPIRATION_DATE Then contractDetails.RealExpirationDate = Await _Reader.GetStringAsync("Real Expiration Date")

        If ServerVersion >= ApiServerVersion.STOCK_TYPE Then contractDetails.StockType = Await _Reader.GetStringAsync("StockType")

        If ServerVersion >= ApiServerVersion.FRACTIONAL_SIZE_SUPPORT And ServerVersion < ApiServerVersion.SIZE_RULES Then
            ' SizeMinTick is no longer used
            Await _Reader.GetDecimalAsync("SizeMinTick")
        End If

        If ServerVersion >= ApiServerVersion.SIZE_RULES Then
            contractDetails.MinimumSize = Await _Reader.GetNullableDecimalAsync("MinimumSize")
            contractDetails.SizeIncrement = Await _Reader.GetNullableDecimalAsync("SizeIncrement")
            contractDetails.SuggestedSizeIncrement = Await _Reader.GetNullableDecimalAsync("SuggestedSizeIncrement")
        End If

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.ContractDetailsConsumer?.NotifyContract(New ContractDetailsEventArgs(timestamp, requestId, contractDetails))
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
