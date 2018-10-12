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

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lContract As New Contract
        Dim lContractDetails As New ContractDetails With {
            .Summary = lContract
        }

        Dim lRequestId = If(pVersion >= 3, Await _Reader.GetIntAsync("Req Id"), -1)

        lContract.Symbol = Await _Reader.GetStringAsync("Symbol")
        lContract.SecType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sectype"))

        With lContractDetails
            .Cusip = Await _Reader.GetStringAsync("Cusip")
            .Coupon = Await _Reader.GetDoubleAsync("Coupon")

            Dim lMaturity = Await _Reader.GetStringAsync("Maturity")
            If Not String.IsNullOrEmpty(lMaturity) Then
                Dim ar() = lMaturity.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                If ar.Length > 0 Then lContract.Expiry = ar(0)
                If ar.Length > 1 Then lContractDetails.LastTradeTime = ar(1)
                If ar.Length > 2 Then lContractDetails.TimeZoneId = ar(2)
            End If
            .Maturity = Await _Reader.GetStringAsync("Maturity")
            .IssueDate = Await _Reader.GetStringAsync("IssueDate")
            .Ratings = Await _Reader.GetStringAsync("Ratings")
            .BondType = Await _Reader.GetStringAsync("BondType")
            .CouponType = Await _Reader.GetStringAsync("CouponType")
            .Convertible = Await _Reader.GetBooleanAsync("Convertible")
            .Callable = Await _Reader.GetBooleanAsync("Callable")
            .Putable = Await _Reader.GetBooleanAsync("Putable")
            .DescAppend = Await _Reader.GetStringAsync("DescAppend")
        End With

        lContract.Exchange = Await _Reader.GetStringAsync("Exchange")
        lContract.CurrencyCode = Await _Reader.GetStringAsync("Currency")
        lContractDetails.MarketName = Await _Reader.GetStringAsync("MarketName")
        lContract.TradingClass = Await _Reader.GetStringAsync("TradingClass")
        lContract.ConId = Await _Reader.GetIntAsync("Con Id")
        lContractDetails.MinTick = Await _Reader.GetDoubleAsync("MinTick")

        If ServerVersion >= ApiServerVersion.MD_SIZE_MULTIPLIER Then lContractDetails.MDSizeMultiplier = Await _Reader.GetIntAsync("MDSizeMultiplier")

        lContractDetails.OrderTypes = Await _Reader.GetStringAsync("OrderTypes")
        lContractDetails.ValidExchanges = Await _Reader.GetStringAsync("ValidExchanges")

        If (pVersion >= 2) Then
            lContractDetails.NextOptionDate = Await _Reader.GetStringAsync("Next Option Date")
            lContractDetails.NextOptionType = Await _Reader.GetStringAsync("Next Option Type")
            lContractDetails.NextOptionPartial = Await _Reader.GetBooleanAsync("Next Option Partial")
            lContractDetails.Notes = Await _Reader.GetStringAsync("Notes")
        End If
        If pVersion >= 4 Then Await _Reader.GetStringAsync("LongName")
        If pVersion >= 6 Then
            lContractDetails.EvRule = Await _Reader.GetStringAsync("EvRule")
            lContractDetails.EvMultiplier = Await _Reader.GetDoubleAsync("EvMultiplier")
        End If

        If pVersion >= 5 Then
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

        If ServerVersion >= ApiServerVersion.MARKET_RULES Then lContractDetails.MarketRuleIds = Await _Reader.GetStringAsync("Market Rule Ids")

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.ContractDetailsConsumer?.NotifyContract(New ContractDetailsEventArgs(timestamp, lRequestId, lContractDetails))
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
