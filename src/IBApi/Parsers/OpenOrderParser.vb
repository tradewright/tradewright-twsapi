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
Imports System.Threading.Tasks

Friend NotInheritable Class OpenOrderParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(OpenOrderParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lOrderState As New OrderState
        Dim lOrder As New Order
        lOrder.OrderId = Await _Reader.GetIntAsync("Id")

        ' read contract fields
        Dim lContract As New Contract
        With lContract
            .ConId = Await _Reader.GetIntAsync("conId")
            .Symbol = Await _Reader.GetStringAsync("Symbol")
            .SecType = SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))
            .Expiry = Await _Reader.GetStringAsync("Expiry")
            .Strike = Await _Reader.GetDoubleAsync("Strike")
            .OptRight = OptionRights.Parse(Await _Reader.GetStringAsync("Right"))
            .Multiplier = Await _Reader.GetIntAsync("Multiplier")
            If .Multiplier = 0 Then .Multiplier = 1
            .Exchange = Await _Reader.GetStringAsync("Exchange")
            .CurrencyCode = Await _Reader.GetStringAsync("Currency")
            .LocalSymbol = Await _Reader.GetStringAsync("Local Symbol")
            .TradingClass = Await _Reader.GetStringAsync("Trading Class")
        End With

        ' read Order fields
        With lOrder
            .Action = OrderActions.Parse(Await _Reader.GetStringAsync("Action"))
            .TotalQuantity = Await _Reader.GetDoubleAsync("Quantity")
            .OrderType = OrderTypes.Parse(Await _Reader.GetStringAsync("Order type"))
            If .OrderType = OrderType.None Then Throw New InvalidOperationException("Invalid OrderYype")
            .LmtPrice = Await _Reader.GetNullableDoubleAsync("Limit price")
            .AuxPrice = Await _Reader.GetNullableDoubleAsync("Aux price")
            .Tif = OrderTIFs.Parse(Await _Reader.GetStringAsync("Time in force"))
            .OcaGroup = Await _Reader.GetStringAsync("OCA group")
            .Account = Await _Reader.GetStringAsync("Account")
            .OpenClose = Await _Reader.GetStringAsync("Open/close")
            .Origin = Await _Reader.GetIntAsync("Origin")
            .OrderRef = Await _Reader.GetStringAsync("Order ref")
            .ClientID = Await _Reader.GetIntAsync("Client id")

            .PermId = Await _Reader.GetIntAsync("Perm id")
            .OutsideRth = Await _Reader.GetBooleanAsync("Outside RTH")
            .Hidden = Await _Reader.GetBooleanAsync("Hidden")
            .DiscretionaryAmt = Await _Reader.GetDoubleAsync("Discr amt")

            .GoodAfterTime = Await _Reader.GetStringAsync("Good after Time")

            ' sharesAllocation no longer used
            Await _Reader.GetStringAsync("Shares allocation")

            .FaGroup = Await _Reader.GetStringAsync("FA Group")
            .FaMethod = Await _Reader.GetStringAsync("FA method")
            .FaPercentage = Await _Reader.GetStringAsync("FA Percentage")
            .FaProfile = Await _Reader.GetStringAsync("FA Profile")

            If ServerVersion >= ApiServerVersion.MODELS_SUPPORT Then .ModelCode = Await _Reader.GetStringAsync("Model Code")

            .GoodTillDate = Await _Reader.GetStringAsync("Good till date")

            .Rule80A = Await _Reader.GetStringAsync("Rule80A")
            .PercentOffset = Await _Reader.GetDoubleAsync("Percent Offset")
            .SettlingFirm = Await _Reader.GetStringAsync("Settling Firm")
            .ShortSaleSlot = Await _Reader.GetIntAsync("shortSaleSlot")
            .DesignatedLocation = Await _Reader.GetStringAsync("designatedLocation")
            .ExemptCode = Await _Reader.GetIntAsync("ExemptCode")
            .AuctionStrategy = DirectCast(Await _Reader.GetIntAsync("Auction Strategy"), AuctionStrategy)
            .StartingPrice = Await _Reader.GetDoubleAsync("starting Price")
            .StockRefPrice = Await _Reader.GetDoubleAsync("stockRefPrice")
            .Delta = Await _Reader.GetDoubleAsync("delta")
            .StockRangeLower = Await _Reader.GetDoubleAsync("stockRangeLower")
            .StockRangeUpper = Await _Reader.GetDoubleAsync("stockRangeUpper")
            .DisplaySize = Await _Reader.GetIntAsync("displaySize")
            .BlockOrder = Await _Reader.GetBooleanAsync("blockOrder")
            .SweepToFill = Await _Reader.GetBooleanAsync("sweepToFill")
            .AllOrNone = Await _Reader.GetBooleanAsync("allOrNone")
            .MinQty = Await _Reader.GetIntAsync("minQty")
            .OcaType = DirectCast(Await _Reader.GetIntAsync("ocaType"), OcaType)
            .ETradeOnly = Await _Reader.GetBooleanAsync("eTradeOnly")
            .FirmQuoteOnly = Await _Reader.GetBooleanAsync("firmQuoteOnly")
            .NbboPriceCap = Await _Reader.GetDoubleAsync("nbboPriceCap")

            .ParentId = Await _Reader.GetIntAsync("ParentId")
            .TriggerMethod = DirectCast(Await _Reader.GetIntAsync("TriggerMethod"), TriggerMethod)

            .Volatility = Await _Reader.GetDoubleAsync("Volatility")
            .VolatilityType = Await _Reader.GetIntAsync("VolatilityType")

            .DeltaNeutralOrderType = OrderTypes.Parse(Await _Reader.GetStringAsync("DeltaNeutralOrderType"))
            .DeltaNeutralAuxPrice = Await _Reader.GetNullableDoubleAsync("DeltaNeutralAuxPrice")

            If .DeltaNeutralOrderType = OrderType.None Then
                .DeltaNeutralConId = Await _Reader.GetIntAsync("DeltaNeutralConId")
                .DeltaNeutralSettlingFirm = Await _Reader.GetStringAsync("DeltaNeutralSettlingFirm")
                .DeltaNeutralClearingAccount = Await _Reader.GetStringAsync("DeltaNeutralClearingAccount")
                .DeltaNeutralClearingIntent = Await _Reader.GetStringAsync("DeltaNeutralClearingIntent")
                .DeltaNeutralOpenClose = Await _Reader.GetStringAsync("DeltaNeutralOpenClose")
                .DeltaNeutralShortSale = Await _Reader.GetBooleanAsync("DeltaNeutralShortSale")
                .DeltaNeutralShortSaleSlot = Await _Reader.GetIntAsync("DeltaNeutralShortSaleSlot")
                .DeltaNeutralDesignatedLocation = Await _Reader.GetStringAsync("DeltaNeutralDesignatedLocation")
            End If

            .ContinuousUpdate = Await _Reader.GetIntAsync("ContinuousUpdate")
            .ReferencePriceType = Await _Reader.GetIntAsync("ReferencePriceType")

            .TrailStopPrice = Await _Reader.GetNullableDoubleAsync("TrailStopPrice")

            .TrailingPercent = Await _Reader.GetNullableDoubleAsync("TrailingPercent")

            .BasisPoints = Await _Reader.GetNullableDoubleAsync("BasisPoints")
            .BasisPointsType = Await _Reader.GetNullableIntAsync("BasisPointsType")
            lContract.ComboLegsDescription = Await _Reader.GetStringAsync("ComboLegsDescrip")

            Dim lComboLegsCount = Await _Reader.GetIntAsync("ComboLegsCount")
            If lComboLegsCount > 0 Then
                For i = 1 To lComboLegsCount
                    Dim lComboLeg As New ComboLeg
                    lComboLeg.ConId = Await _Reader.GetIntAsync($"ConId{i}")
                    lComboLeg.Ratio = Await _Reader.GetIntAsync($"Ratio{i}")
                    lComboLeg.Action = OrderActions.Parse(Await _Reader.GetStringAsync($"Action{i}"))
                    lComboLeg.Exchange = Await _Reader.GetStringAsync($"Exchange{i}")
                    lComboLeg.OpenClose = DirectCast(Await _Reader.GetIntAsync($"OpenClose{i}"), LegOpenCloseCode)
                    lComboLeg.ShortSaleSlot = DirectCast(Await _Reader.GetIntAsync($"ShortSaleSlot{i}"), ShortSaleSlotCode)
                    lComboLeg.DesignatedLocation = Await _Reader.GetStringAsync($"DesignatedLocation{i}")
                    lComboLeg.ExemptCode = Await _Reader.GetIntAsync($"ExemptCode{i}")

                    lContract.ComboLegs.Add((lComboLeg))
                Next
            End If

            Dim lOrderComboLegsCount = Await _Reader.GetIntAsync("OrderComboLegsCount")
            If lOrderComboLegsCount > 0 Then
                Dim lOrderComboLegs(lOrderComboLegsCount - 1) As OrderComboLeg
                For i = 0 To lOrderComboLegsCount - 1
                    lOrderComboLegs(i) = New OrderComboLeg With {
                            .Price = Await _Reader.GetDoubleAsync($"Price{i + 1}")
                        }
                Next
                .OrderComboLegs = lOrderComboLegs
            End If

            Dim lSmartComboRoutingParamsCount = Await _Reader.GetIntAsync("SmartComboRoutingParamsCount")
            If lSmartComboRoutingParamsCount > 0 Then
                .SmartComboRoutingParams = New List(Of TagValue)()
                For i = 1 To lSmartComboRoutingParamsCount
                    .SmartComboRoutingParams.Add(New TagValue() With {
                                                                    .Tag = Await _Reader.GetStringAsync("Tag" & (i + 1)),
                                                                    .Value = Await _Reader.GetStringAsync("Value" & (i + 1))
                                                                    })
                Next
            End If

            .ScaleInitLevelSize = Await _Reader.GetNullableIntAsync("Scale Init Level Size")
            .ScaleSubsLevelSize = Await _Reader.GetNullableIntAsync("Scale Subs Level Size")
            .ScalePriceIncrement = Await _Reader.GetNullableDoubleAsync("Scale Price Increment")

            If .ScalePriceIncrement.HasValue And .ScalePriceIncrement > 0.0# Then
                .ScalePriceAdjustValue = Await _Reader.GetNullableDoubleAsync("ScalePriceAdjustValue")
                .ScalePriceAdjustInterval = Await _Reader.GetNullableIntAsync("ScalePriceAdjustInterval")
                .ScaleProfitOffset = Await _Reader.GetNullableDoubleAsync("ScaleProfitOffset")
                .ScaleAutoReset = Await _Reader.GetBooleanAsync("ScaleAutoReset")
                .ScaleInitPosition = Await _Reader.GetNullableIntAsync("ScaleInitPosition")
                .ScaleInitFillQty = Await _Reader.GetNullableIntAsync("ScaleInitFillQty")
                .ScaleRandomPercent = Await _Reader.GetBooleanAsync("ScaleRandomPercent")
            End If

            .HedgeType = HedgeTypes.Parse(Await _Reader.GetStringAsync("HedgeType"))
            If .HedgeType <> HedgeType.None Then .HedgeParam = Await _Reader.GetStringAsync("HedgeParam")

            .OptOutSmartRouting = Await _Reader.GetBooleanAsync("OptOutSmartRouting")

            .ClearingAccount = Await _Reader.GetStringAsync("Clearing Account")
            .ClearingIntent = Await _Reader.GetStringAsync("Clearing Intent")

            .NotHeld = Await _Reader.GetBooleanAsync("Not held")

            If CBool(Await _Reader.GetIntAsync("UnderComp")) Then
                Dim lUnderComp = New UnderComp With {
                    .ConId = Await _Reader.GetIntAsync("UnderComp ConId"),
                    .Delta = Await _Reader.GetDoubleAsync("UnderComp Delta"),
                    .Price = Await _Reader.GetDoubleAsync("UnderComp Price")
                }
                lContract.UnderComp = lUnderComp
            End If

            .AlgoStrategy = Await _Reader.GetStringAsync("Algo strategy")
            If .AlgoStrategy <> "" Then
                Dim algoParamsCount = Await _Reader.GetIntAsync("Algo params count")
                If algoParamsCount > 0 Then
                    Dim lAlgoParams(algoParamsCount - 1) As TagValue
                    For i = 0 To algoParamsCount - 1
                        lAlgoParams(i).Tag = Await _Reader.GetStringAsync($"Tag{i + 1}")
                        lAlgoParams(i).Value = Await _Reader.GetStringAsync($"Value{i + 1}")
                    Next
                    .AlgoParams = lAlgoParams
                End If
            End If

            .Solicited = Await _Reader.GetBoolFromIntAsync("Solicited")

            .WhatIf = Await _Reader.GetBooleanAsync("What If")

            lOrderState = New OrderState()
            With lOrderState
                .Status = Await _Reader.GetStringAsync("Status")
                .InitMargin = Await _Reader.GetNullableDoubleAsync("Init Margin")
                .MaintMargin = Await _Reader.GetNullableDoubleAsync("Maint Margin")
                .EquityWithLoan = Await _Reader.GetNullableDoubleAsync("Equity With Loan")
                .Commission = Await _Reader.GetNullableDoubleAsync("Commission")
                .MinCommission = Await _Reader.GetNullableDoubleAsync("Min Commission")
                .MaxCommission = Await _Reader.GetNullableDoubleAsync("Max Commission")
                .CommissionCurrency = Await _Reader.GetStringAsync("Commission Currency")
                .WarningText = Await _Reader.GetStringAsync("Warning Text")
            End With

            .RandomizeSize = Await _Reader.GetBooleanAsync("Randomize Size")
            .RandomizePrice = Await _Reader.GetBooleanAsync("Randomize Price")

            If ServerVersion >= ApiServerVersion.PEGGED_TO_BENCHMARK Then
                If .OrderType = OrderType.PeggedToBenchmark Then
                    .ReferenceContractId = Await _Reader.GetIntAsync("ReferenceContractId")
                    .IsPeggedChangeAmountDecrease = Await _Reader.GetBoolFromIntAsync("IsPeggedChangeAmountDecrease")
                    .PeggedChangeAmount = Await _Reader.GetNullableDoubleAsync("PeggedChangeAmount")
                    .ReferenceChangeAmount = Await _Reader.GetNullableDoubleAsync("ReferenceChangeAmount")
                    .ReferenceExchange = Await _Reader.GetStringAsync("ReferenceExchange")
                End If

                Dim nConditions = Await _Reader.GetIntAsync("Conditions count")

                If (nConditions > 0) Then
                    For i = 1 To nConditions
                        Dim orderConditionType = CType(Await _Reader.GetIntAsync("OrderConditionType"), OrderConditionType)
                        Dim condition = OrderCondition.Create(orderConditionType)

                        condition.Deserialize(_Reader)
                        .Conditions.Add(condition)

                        .ConditionsIgnoreRth = Await _Reader.GetBoolFromIntAsync("Conditions Ignore Rth")
                        .ConditionsCancelOrder = Await _Reader.GetBoolFromIntAsync("Conditions Cancel Order")
                    Next
                End If

                .AdjustedOrderType = OrderTypes.Parse(Await _Reader.GetStringAsync("AdjustedOrderType"))
                .TriggerPrice = Await _Reader.GetNullableDoubleAsync("TriggerPrice")
                .TrailStopPrice = Await _Reader.GetNullableDoubleAsync("TrailStopPrice")
                .LmtPriceOffset = Await _Reader.GetNullableDoubleAsync("LmtPriceOffset")
                .AdjustedStopPrice = Await _Reader.GetNullableDoubleAsync("AdjustedStopPrice")
                .AdjustedStopLimitPrice = Await _Reader.GetNullableDoubleAsync("AdjustedStopLimitPrice")
                .AdjustedTrailingAmount = Await _Reader.GetNullableDoubleAsync("AdjustedTrailingAmount")
                .AdjustableTrailingUnit = Await _Reader.GetIntAsync("AdjustableTrailingUnit")
            End If

            If (ServerVersion >= ApiServerVersion.SOFT_DOLLAR_TIER) Then
                .Tier = New SoftDollarTier(Await _Reader.GetStringAsync("Name"), Await _Reader.GetStringAsync("Value"), Await _Reader.GetStringAsync("Display Name"))
            End If

            If (ServerVersion >= ApiServerVersion.CASH_QTY) Then
                .CashQty = Await _Reader.GetNullableDoubleAsync("Cash Qty")
            End If
        End With

        LogSocketInputMessage(ModuleName, "ParseAsync")

        _EventConsumers.OrderInfoConsumer?.NotifyOpenOrder(New OpenOrderEventArgs(timestamp, lOrder.OrderId, lContract, lOrder, lOrderState))
        Return True
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.OpenOrder
        End Get
    End Property

End Class
