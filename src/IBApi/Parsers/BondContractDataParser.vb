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

Friend NotInheritable Class BondContractDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(BondContractDataParser)

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp As Date) As Task(Of Boolean)
        Dim contract As New Contract
        Dim contractDetails As New ContractDetails With {
            .Summary = contract
        }

        Dim requestId = If(version >= 3, Await _Reader.GetIntAsync("Req Id"), -1)

        contract.Symbol = Await _Reader.GetStringAsync("Symbol")
        contract.SecurityType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sectype"))

        With contractDetails
            .Cusip = Await _Reader.GetStringAsync("Cusip")
            .Coupon = Await _Reader.GetDoubleAsync("Coupon")

            Dim lMaturity = Await _Reader.GetStringAsync("Maturity")
            If Not String.IsNullOrEmpty(lMaturity) Then
                Dim ar() = lMaturity.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                If ar.Length > 0 Then contractDetails.Maturity = ar(0)
                If ar.Length > 1 Then contractDetails.LastTradeTime = ar(1)
                If ar.Length > 2 Then contractDetails.TimeZoneId = ar(2)
            End If
            .IssueDate = Await _Reader.GetStringAsync("IssueDate")
            .Ratings = Await _Reader.GetStringAsync("Ratings")
            .BondType = Await _Reader.GetStringAsync("BondType")
            .CouponType = Await _Reader.GetStringAsync("CouponType")
            .Convertible = Await _Reader.GetBooleanAsync("Convertible")
            .Callable = Await _Reader.GetBooleanAsync("Callable")
            .Putable = Await _Reader.GetBooleanAsync("Putable")
            .BondDescription = Await _Reader.GetStringAsync("DescAppend")
        End With

        contract.Exchange = Await _Reader.GetStringAsync("Exchange")
        contract.CurrencyCode = Await _Reader.GetStringAsync("Currency")
        contractDetails.MarketName = Await _Reader.GetStringAsync("MarketName")
        contract.TradingClass = Await _Reader.GetStringAsync("TradingClass")
        contract.ContractId = Await _Reader.GetIntAsync("Con Id")
        contractDetails.MinimumTick = Await _Reader.GetDoubleAsync("MinTick")

        If ServerVersion >= ApiServerVersion.MD_SIZE_MULTIPLIER And ServerVersion < ApiServerVersion.SIZE_RULES Then
            ' MDSizeMultiplier is no longer used
            Await _Reader.GetIntAsync("MDSizeMultiplier")
        End If

        contractDetails.OrderTypes = Await _Reader.GetStringAsync("OrderTypes")
        contractDetails.ValidExchanges = Await _Reader.GetStringAsync("ValidExchanges")

        If (version >= 2) Then
            contractDetails.NextOptionDate = Await _Reader.GetStringAsync("Next Option Date")
            contractDetails.NextOptionType = Await _Reader.GetStringAsync("Next Option Type")
            contractDetails.NextOptionPartial = Await _Reader.GetBooleanAsync("Next Option Partial")
            contractDetails.Notes = Await _Reader.GetStringAsync("Notes")
        End If
        If version >= 4 Then Await _Reader.GetStringAsync("LongName")
        If version >= 6 Then
            contractDetails.EvRule = Await _Reader.GetStringAsync("EvRule")
            contractDetails.EvMultiplier = Await _Reader.GetDoubleAsync("EvMultiplier")
        End If

        If version >= 5 Then
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

        If ServerVersion >= ApiServerVersion.MARKET_RULES Then contractDetails.MarketRuleIds = Await _Reader.GetStringAsync("Market Rule Ids")

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
            Return ApiSocketInMsgType.BondContractData
        End Get
    End Property

End Class
