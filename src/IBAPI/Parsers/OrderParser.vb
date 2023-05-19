#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2023 Richard L King (TradeWright Software Systems)
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

Friend Class OrderParser

    Private Const ModuleName As String = NameOf(OpenOrderParser)

    Friend Enum OrderPhase
        Open
        Completed
    End Enum

    Friend Async Function ParseAsync(reader As MessageReader,
                                     serverVersion As Integer,
                                     contract As Contract,
                                     order As Order,
                                     orderState As OrderState,
                                     orderPhase As OrderPhase) As Task(Of Boolean)
        With contract
            .ConId = Await reader.GetIntAsync("conId")
            .Symbol = Await reader.GetStringAsync("Symbol")
            .SecType = IBAPI.SecurityTypes.Parse(Await reader.GetStringAsync("Sec type"))
            .Expiry = Await reader.GetStringAsync("Expiry")
            .Strike = Await reader.GetDoubleAsync("Strike")
            .OptRight = IBAPI.OptionRights.Parse(Await reader.GetStringAsync("Right"))
            .Multiplier = Await reader.GetDoubleAsync("Multiplier")
            If .Multiplier = 0 Then .Multiplier = 1
            .Exchange = Await reader.GetStringAsync("Exchange")
            .CurrencyCode = Await reader.GetStringAsync("Currency")
            .LocalSymbol = Await reader.GetStringAsync("Local Symbol")
            .TradingClass = Await reader.GetStringAsync("Trading Class")
        End With

        ' read Order fields
        With order
            .Action = IBAPI.OrderActions.Parse(Await reader.GetStringAsync("Action"))
            .TotalQuantity = Await reader.GetDecimalAsync("Quantity")
            .OrderType = IBAPI.OrderTypes.Parse(Await reader.GetStringAsync("Order type"))
            If .OrderType = OrderType.None Then Throw New InvalidOperationException("Invalid OrderYype")
            .LmtPrice = Await reader.GetNullableDoubleAsync("Limit price")
            .AuxPrice = Await reader.GetNullableDoubleAsync("Aux price")
            .Tif = IBAPI.OrderTIFs.Parse(Await reader.GetStringAsync("Time in force"))
            .OcaGroup = Await reader.GetStringAsync("OCA group")
            .Account = Await reader.GetStringAsync("Account")
            .OpenClose = Await reader.GetStringAsync("Open/close")
            .Origin = Await reader.GetIntAsync("Origin")
            .OrderRef = Await reader.GetStringAsync("Order ref")
            If orderPhase = OrderPhase.Open Then .ClientID = Await reader.GetIntAsync("Client id")

            .PermId = Await reader.GetIntAsync("Perm id")
            .OutsideRth = Await reader.GetBooleanAsync("Outside RTH")
            .Hidden = Await reader.GetBooleanAsync("Hidden")
            .DiscretionaryAmt = Await reader.GetDoubleAsync("Discr amt")

            .GoodAfterTime = Await reader.GetStringAsync("Good after Time")

            ' sharesAllocation no longer used
            If orderPhase = OrderPhase.Open Then Await reader.GetStringAsync("Shares allocation")

            If orderPhase = OrderPhase.Open Then
                .FaGroup = Await reader.GetStringAsync("FA Group")
                .FaMethod = Await reader.GetStringAsync("FA method")
                .FaPercentage = Await reader.GetStringAsync("FA Percentage")
                .FaProfile = Await reader.GetStringAsync("FA Profile")
            End If

            If serverVersion >= ApiServerVersion.MODELS_SUPPORT Then .ModelCode = Await reader.GetStringAsync("Model Code")

            .GoodTillDate = Await reader.GetStringAsync("Good till date")

            .Rule80A = Await reader.GetStringAsync("Rule80A")
            .PercentOffset = Await reader.GetNullableDoubleAsync("Percent Offset")
            .SettlingFirm = Await reader.GetStringAsync("Settling Firm")

            .ShortSaleSlot = Await reader.GetIntAsync("shortSaleSlot")
            .DesignatedLocation = Await reader.GetStringAsync("designatedLocation")
            .ExemptCode = Await reader.GetIntAsync("ExemptCode")

            If orderPhase = OrderPhase.Open Then .AuctionStrategy = DirectCast(Await reader.GetIntAsync("Auction Strategy"), AuctionStrategy)

            .StartingPrice = Await reader.GetDoubleAsync("starting Price")
            .StockRefPrice = Await reader.GetDoubleAsync("stockRefPrice")
            .Delta = Await reader.GetDoubleAsync("delta")

            .StockRangeLower = Await reader.GetDoubleAsync("stockRangeLower")
            .StockRangeUpper = Await reader.GetDoubleAsync("stockRangeUpper")

            .DisplaySize = Await reader.GetNullableIntAsync("displaySize")

            If orderPhase = OrderPhase.Open Then .BlockOrder = Await reader.GetBooleanAsync("blockOrder")

            .SweepToFill = Await reader.GetBooleanAsync("sweepToFill")
            .AllOrNone = Await reader.GetBooleanAsync("allOrNone")
            .MinQty = Await reader.GetIntAsync("minQty")
            .OcaType = DirectCast(Await reader.GetIntAsync("ocaType"), OcaType)

            If orderPhase = OrderPhase.Open Then
                Await reader.GetBooleanAsync("eTradeOnly")      ' desupported
                Await reader.GetBooleanAsync("firmQuoteOnly")   ' desupported
                Await reader.GetDoubleAsync("nbboPriceCap")     ' desupported

                .ParentId = Await reader.GetIntAsync("ParentId")
            End If

            .TriggerMethod = DirectCast(Await reader.GetIntAsync("TriggerMethod"), TriggerMethod)

            .Volatility = Await reader.GetDoubleAsync("Volatility")
            .VolatilityType = Await reader.GetIntAsync("VolatilityType")

            Dim deltaNeutralOrderTypeStr = Await reader.GetStringAsync("DeltaNeutralOrderType")
            .DeltaNeutralOrderType = IBAPI.OrderTypes.Parse(deltaNeutralOrderTypeStr)
            .DeltaNeutralAuxPrice = Await reader.GetNullableDoubleAsync("DeltaNeutralAuxPrice")

            If deltaNeutralOrderTypeStr <> "" Then
                .DeltaNeutralConId = Await reader.GetIntAsync("DeltaNeutralConId")
                If orderPhase = OrderPhase.Open Then
                    .DeltaNeutralSettlingFirm = Await reader.GetStringAsync("DeltaNeutralSettlingFirm")
                    .DeltaNeutralClearingAccount = Await reader.GetStringAsync("DeltaNeutralClearingAccount")
                    .DeltaNeutralClearingIntent = Await reader.GetStringAsync("DeltaNeutralClearingIntent")
                    .DeltaNeutralOpenClose = Await reader.GetStringAsync("DeltaNeutralOpenClose")
                End If
                .DeltaNeutralShortSale = Await reader.GetBooleanAsync("DeltaNeutralShortSale")
                .DeltaNeutralShortSaleSlot = Await reader.GetIntAsync("DeltaNeutralShortSaleSlot")
                .DeltaNeutralDesignatedLocation = Await reader.GetStringAsync("DeltaNeutralDesignatedLocation")
            End If

            .ContinuousUpdate = Await reader.GetIntAsync("ContinuousUpdate")
            .ReferencePriceType = Await reader.GetIntAsync("ReferencePriceType")

            .TrailStopPrice = Await reader.GetNullableDoubleAsync("TrailStopPrice")
            .TrailingPercent = Await reader.GetNullableDoubleAsync("TrailingPercent")

            If orderPhase = OrderPhase.Open Then
                .BasisPoints = Await reader.GetNullableDoubleAsync("BasisPoints")
                .BasisPointsType = Await reader.GetNullableIntAsync("BasisPointsType")
            End If

            contract.ComboLegsDescription = Await reader.GetStringAsync("ComboLegsDescrip")

            Dim lComboLegsCount = Await reader.GetIntAsync("ComboLegsCount")
            If lComboLegsCount > 0 Then
                For i = 1 To lComboLegsCount
                    Dim lComboLeg As New ComboLeg With {
                        .ConId = Await reader.GetIntAsync($"ConId{i}"),
                        .Ratio = Await reader.GetIntAsync($"Ratio{i}"),
                        .Action = IBAPI.OrderActions.Parse(Await reader.GetStringAsync($"Action{i}")),
                        .Exchange = Await reader.GetStringAsync($"Exchange{i}"),
                        .OpenClose = DirectCast(Await reader.GetIntAsync($"OpenClose{i}"), LegOpenCloseCode),
                        .ShortSaleSlot = DirectCast(Await reader.GetIntAsync($"ShortSaleSlot{i}"), ShortSaleSlotCode),
                        .DesignatedLocation = Await reader.GetStringAsync($"DesignatedLocation{i}"),
                        .ExemptCode = Await reader.GetIntAsync($"ExemptCode{i}")
                    }

                    contract.ComboLegs.Add((lComboLeg))
                Next
            End If

            Dim lOrderComboLegsCount = Await reader.GetIntAsync("OrderComboLegsCount")
            If lOrderComboLegsCount > 0 Then
                Dim lOrderComboLegs(lOrderComboLegsCount - 1) As OrderComboLeg
                For i = 0 To lOrderComboLegsCount - 1
                    lOrderComboLegs(i) = New OrderComboLeg With {
                            .Price = Await reader.GetNullableDoubleAsync($"Price{i + 1}")
                        }
                Next
                .OrderComboLegs = lOrderComboLegs
            End If

            Dim lSmartComboRoutingParamsCount = Await reader.GetIntAsync("SmartComboRoutingParamsCount")
            If lSmartComboRoutingParamsCount > 0 Then
                .SmartComboRoutingParams = New List(Of TagValue)()
                For i = 1 To lSmartComboRoutingParamsCount
                    .SmartComboRoutingParams.Add(New TagValue() With {
                                                                    .Tag = Await reader.GetStringAsync("Tag" & (i + 1)),
                                                                    .Value = Await reader.GetStringAsync("Value" & (i + 1))
                                                                    })
                Next
            End If

            .ScaleInitLevelSize = Await reader.GetNullableIntAsync("Scale Init Level Size")
            .ScaleSubsLevelSize = Await reader.GetNullableIntAsync("Scale Subs Level Size")
            .ScalePriceIncrement = Await reader.GetNullableDoubleAsync("Scale Price Increment")

            If .ScalePriceIncrement.HasValue And .ScalePriceIncrement > 0.0# Then
                .ScalePriceAdjustValue = Await reader.GetNullableDoubleAsync("ScalePriceAdjustValue")
                .ScalePriceAdjustInterval = Await reader.GetNullableIntAsync("ScalePriceAdjustInterval")
                .ScaleProfitOffset = Await reader.GetNullableDoubleAsync("ScaleProfitOffset")
                .ScaleAutoReset = Await reader.GetBooleanAsync("ScaleAutoReset")
                .ScaleInitPosition = Await reader.GetNullableIntAsync("ScaleInitPosition")
                .ScaleInitFillQty = Await reader.GetNullableIntAsync("ScaleInitFillQty")
                .ScaleRandomPercent = Await reader.GetBooleanAsync("ScaleRandomPercent")
            End If

            .HedgeType = IBAPI.HedgeTypes.Parse(Await reader.GetStringAsync("HedgeType"))
            If .HedgeType <> HedgeType.None Then .HedgeParam = Await reader.GetStringAsync("HedgeParam")

            If orderPhase = OrderPhase.Open Then .OptOutSmartRouting = Await reader.GetBooleanAsync("OptOutSmartRouting")

            .ClearingAccount = Await reader.GetStringAsync("Clearing Account")
            .ClearingIntent = Await reader.GetStringAsync("Clearing Intent")

            .NotHeld = Await reader.GetBooleanAsync("Not held")

            If CBool(Await reader.GetIntAsync("UnderComp")) Then
                Dim lDeltaNeutralContract = New DeltaNeutralContract With {
                    .ConId = Await reader.GetIntAsync("UnderComp ConId"),
                    .Delta = Await reader.GetDoubleAsync("UnderComp Delta"),
                    .Price = Await reader.GetDoubleAsync("UnderComp Price")
                }
                contract.DeltaNeutralContract = lDeltaNeutralContract
            End If

            .AlgoStrategy = Await reader.GetStringAsync("Algo strategy")
            If .AlgoStrategy <> "" Then
                Dim algoParamsCount = Await reader.GetIntAsync("Algo params count")
                If algoParamsCount > 0 Then
                    Dim lAlgoParams(algoParamsCount - 1) As TagValue
                    For i = 0 To algoParamsCount - 1
                        lAlgoParams(i).Tag = Await reader.GetStringAsync($"Tag{i + 1}")
                        lAlgoParams(i).Value = Await reader.GetStringAsync($"Value{i + 1}")
                    Next
                    .AlgoParams = lAlgoParams
                End If
            End If

            .Solicited = Await reader.GetBoolFromIntAsync("Solicited")

            If orderPhase = OrderPhase.Open Then .WhatIf = Await reader.GetBooleanAsync("What If")

            With orderState
                .Status = Await reader.GetStringAsync("Status")
                If orderPhase = OrderPhase.Open Then
                    If serverVersion >= ApiServerVersion.WHAT_IF_EXT_FIELDS Then
                        .InitMarginBefore = Await reader.GetNullableDoubleAsync("Init Margin Before")
                        .MaintMarginBefore = Await reader.GetNullableDoubleAsync("Maint Margin Before")
                        .EquityWithLoanBefore = Await reader.GetNullableDoubleAsync("Equity With Loan Before")
                        .InitMarginChange = Await reader.GetNullableDoubleAsync("Init Margin Change")
                        .MaintMarginChange = Await reader.GetNullableDoubleAsync("Maint Margin Change")
                        .EquityWithLoanChange = Await reader.GetNullableDoubleAsync("Equity With Loan Change")
                    End If

                    .InitMarginAfter = Await reader.GetNullableDoubleAsync("Init Margin After")
                    .MaintMarginAfter = Await reader.GetNullableDoubleAsync("Maint Margin After")
                    .EquityWithLoanAfter = Await reader.GetNullableDoubleAsync("Equity With Loan After")

                    .Commission = Await reader.GetNullableDoubleAsync("Commission")
                    .MinCommission = Await reader.GetNullableDoubleAsync("Min Commission")
                    .MaxCommission = Await reader.GetNullableDoubleAsync("Max Commission")
                    .CommissionCurrency = Await reader.GetStringAsync("Commission Currency")
                    .WarningText = Await reader.GetStringAsync("Warning Text")
                End If
            End With

            .RandomizeSize = Await reader.GetBooleanAsync("Randomize Size")
            .RandomizePrice = Await reader.GetBooleanAsync("Randomize Price")

            If serverVersion >= ApiServerVersion.PEGGED_TO_BENCHMARK Then
                If .OrderType = OrderType.PeggedToBenchmark Then
                    .ReferenceContractId = Await reader.GetIntAsync("ReferenceContractId")
                    .IsPeggedChangeAmountDecrease = Await reader.GetBoolFromIntAsync("IsPeggedChangeAmountDecrease")
                    .PeggedChangeAmount = Await reader.GetNullableDoubleAsync("PeggedChangeAmount")
                    .ReferenceChangeAmount = Await reader.GetNullableDoubleAsync("ReferenceChangeAmount")
                    .ReferenceExchange = Await reader.GetStringAsync("ReferenceExchange")
                End If
            End If

            If serverVersion >= ApiServerVersion.PEGGED_TO_BENCHMARK Then
                Dim nConditions = Await reader.GetIntAsync("Conditions count")

                If (nConditions > 0) Then
                    For i = 1 To nConditions
                        Dim orderConditionType = CType(Await reader.GetIntAsync("OrderConditionType"), OrderConditionType)
                        Dim condition = OrderCondition.Create(orderConditionType)

                        condition.Deserialize(reader)
                        .Conditions.Add(condition)

                        .ConditionsIgnoreRth = Await reader.GetBoolFromIntAsync("Conditions Ignore Rth")
                        .ConditionsCancelOrder = Await reader.GetBoolFromIntAsync("Conditions Cancel Order")
                    Next
                End If
            End If

            If serverVersion >= ApiServerVersion.PEGGED_TO_BENCHMARK Then
                If orderPhase = OrderPhase.Open Then
                    .AdjustedOrderType = IBAPI.OrderTypes.Parse(Await reader.GetStringAsync("AdjustedOrderType"))
                    .TriggerPrice = Await reader.GetNullableDoubleAsync("TriggerPrice")
                    .TrailStopPrice = Await reader.GetNullableDoubleAsync("TrailStopPrice")
                    .LmtPriceOffset = Await reader.GetNullableDoubleAsync("LmtPriceOffset")
                    .AdjustedStopPrice = Await reader.GetNullableDoubleAsync("AdjustedStopPrice")
                    .AdjustedStopLimitPrice = Await reader.GetNullableDoubleAsync("AdjustedStopLimitPrice")
                    .AdjustedTrailingAmount = Await reader.GetNullableDoubleAsync("AdjustedTrailingAmount")
                    .AdjustableTrailingUnit = Await reader.GetIntAsync("AdjustableTrailingUnit")
                Else
                    .TrailStopPrice = Await reader.GetNullableDoubleAsync("TrailStopPrice")
                    .LmtPriceOffset = Await reader.GetNullableDoubleAsync("LmtPriceOffset")
                End If
            End If

            If orderPhase = OrderPhase.Open Then
                If serverVersion >= ApiServerVersion.SOFT_DOLLAR_TIER Then
                    .Tier = New SoftDollarTier(Await reader.GetStringAsync("Name"), Await reader.GetStringAsync("Value"), Await reader.GetStringAsync("Display Name"))
                End If
            End If

            If serverVersion >= ApiServerVersion.CASH_QTY Then
                .CashQty = Await reader.GetNullableDoubleAsync("Cash Qty")
            End If

            If serverVersion >= ApiServerVersion.AUTO_PRICE_FOR_HEDGE Then
                .DontUseAutoPriceForHedge = Await reader.GetBoolFromIntAsync("Dont Use Auto Price For Hedge")
            End If

            If serverVersion >= ApiServerVersion.ORDER_CONTAINER Then
                .IsOmsContainer = Await reader.GetBoolFromIntAsync("IsOmsContainer")
            End If

            If orderPhase = OrderPhase.Open Then
                If serverVersion >= ApiServerVersion.D_PEG_ORDERS Then
                    .DiscretionaryUpToLimitPrice = Await reader.GetBoolFromIntAsync("DiscretionaryUpToLimitPrice")
                End If
                If serverVersion >= ApiServerVersion.PRICE_MGMT_ALGO Then
                    .UsePriceMgmtAlgo = Await reader.GetBoolFromIntAsync("UsePriceMgmtAlgo")
                End If
                If serverVersion >= ApiServerVersion.DURATION Then
                    .Duration = Await reader.GetNullableIntAsync("Duration")
                End If
                If serverVersion >= ApiServerVersion.POST_TO_ATS Then
                    .PostToAts = Await reader.GetNullableIntAsync("PostToAts")
                End If
                If serverVersion >= ApiServerVersion.AUTO_CANCEL_PARENT Then
                    .AutoCancelParent = Await reader.GetBoolFromIntAsync("AutoCancelParent")
                End If
            End If

                If orderPhase = OrderPhase.Completed Then
                .AutoCancelDate = Await reader.GetStringAsync("AutoCancelDate")
                .FilledQuantity = Await reader.GetNullableDecimalAsync("FilledQuantity")
                .RefFuturesConId = Await reader.GetIntAsync("RefFuturesConId")
                '                If serverVersion >= ApiServerVersion.AUTO_CANCEL_PARENT Then
                .AutoCancelParent = Await reader.GetBoolFromIntAsync("AutoCancelParent")
                '                End If
                .Shareholder = Await reader.GetStringAsync("Shareholder")
                .ImbalanceOnly = Await reader.GetBoolFromIntAsync("ImbalanceOnly")
                .RouteMarketableToBbo = Await reader.GetBoolFromIntAsync("RouteMarketableToBbo")
                .ParentPermId = Await reader.GetNullableLongAsync("ParentPermId")
                orderState.CompletedTime = Await reader.GetStringAsync("CompletedTime")
                orderState.CompletedStatus = Await reader.GetStringAsync("CompletedStatus")
            End If

            'If serverVersion >= ApiServerVersion.PEGBEST_PEGMID_OFFSETS Then
            '    .MinTradeQty = Await reader.GetNullableIntAsync("MinTradeQty")
            '    .MinCompeteSize = Await reader.GetNullableIntAsync("MinCompeteSize")
            '    .CompeteAgainstBestOffset = Await reader.GetNullableDoubleAsync("CompeteAgainstBestOffset")
            '    .MidOffsetAtWhole = Await reader.GetNullableDoubleAsync("MidOffsetAtWhole")
            '    .MidOffsetAtHalf = Await reader.GetNullableDoubleAsync("MidOffsetAtHalf")
            'End If
        End With

        Return True

    End Function

End Class
