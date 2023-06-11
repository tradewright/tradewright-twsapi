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

Friend Class PlaceOrderGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub PlaceOrderDelegate(pOrder As Order, pContract As Contract, transmit As Boolean, pSecIdType As String, pSecId As String)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New PlaceOrderDelegate(AddressOf placeOrder)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.PlaceOrder
        End Get
    End Property

    Private Sub placeOrder(order As Order, contract As Contract, transmit As Boolean, secIdType As String, secId As String)
        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")

        If ServerVersion < ApiServerVersion.ORDER_CONTAINER And order.IsOmsContainer Then Throw New InvalidOperationException("IsOmsContainer attribute not supported")
        If ServerVersion < ApiServerVersion.D_PEG_ORDERS And order.DiscretionaryUpToLimitPrice Then Throw New InvalidOperationException("DiscretionaryUpToLimitPrice attribute not supported")
        If ServerVersion < ApiServerVersion.PRICE_MGMT_ALGO And order.UsePriceMgmtAlgo.HasValue Then Throw New InvalidOperationException("UsePriceMgmtAlgo attribute not supported")
        If ServerVersion < ApiServerVersion.DURATION And order.Duration.HasValue Then Throw New InvalidOperationException("Duration attribute not supported")
        If ServerVersion < ApiServerVersion.POST_TO_ATS And order.PostToAts.HasValue Then Throw New InvalidOperationException("PostToAts attribute not supported")
        If ServerVersion < ApiServerVersion.AUTO_CANCEL_PARENT And order.AutoCancelParent Then Throw New InvalidOperationException("AutoCancelParent attribute not supported")
        If ServerVersion < ApiServerVersion.ADVANCED_ORDER_REJECT And String.IsNullOrEmpty(order.AdvancedErrorOverride) Then Throw New InvalidOperationException("AdvancedErrorOverride attribute not supported")
        If ServerVersion < ApiServerVersion.PEGBEST_PEGMID_OFFSETS And (order.MinimumTradeQuantity.HasValue Or
                                                                        order.MinimumCompeteSize.HasValue Or
                                                                        order.CompeteAgainstBestOffset.HasValue Or
                                                                        order.MidOffsetAtWhole.HasValue Or
                                                                        order.MidOffsetAtHalf.HasValue) Then Throw New InvalidOperationException("PEGBEST/PEGMID-related  attributes not supported")

        Const VERSION As Integer = 45

        Dim writer = CreateOutputMessageGenerator()
        StartMessage(writer, ApiSocketOutMsgType.PlaceOrder)
        If ServerVersion < ApiServerVersion.ORDER_CONTAINER Then writer.AddInteger(VERSION, "Version")

        If order.OrderId = 0 Then order.OrderId = _IdManager.NextOrderId
        If order.OrderId < IdManager.BaseOrderId Then Throw New ArgumentException($"Order id must not be less than {IdManager.BaseOrderId}")
        If order.OrderId > _IdManager.NextOrderId Then _IdManager.NextOrderId = order.OrderId + 1

        writer.AddInteger(order.OrderId, "Order id")

        writer.AddContract(contract, "Contract")

        writer.AddString(secIdType, "Sec id type")
        writer.AddString(secId, "Sec id")

        With order

            ' mwriter.send main Order fields
            writer.AddString(IBAPI.OrderActions.ToInternalString(.Action), "Action")
            writer.AddDecimal(.TotalQuantity, "Quantity")
            writer.AddString(IBAPI.OrderTypes.ToInternalString(.OrderType), "Order type")

            writer.AddNullableDouble(.LimitPrice, "Price")
            writer.AddNullableDouble(.AuxPrice, "Aux price")

            ' mwriter.send extended Order fields
            If .OrderType = OrderType.MarketOnOpen Or .OrderType = OrderType.LimitOnOpen Then
                writer.AddString("OPG", "TimeInForce")
            Else
                writer.AddString(IBAPI.OrderTIFs.ToInternalString(.TimeInForce), "TimeInForce")
            End If
            writer.AddString(.OcaGroup, "Oca Group")
            writer.AddString(.Account, "Account")
            writer.AddString(.OpenClose, "OpenClose")
            writer.AddInteger(.Origin, "Origin")
            writer.AddString(.OrderReference, "Order ref")
            writer.AddBoolean(transmit, "Transmit")
            writer.AddInteger(.ParentId, "Parent id")
            writer.AddBoolean(.BlockOrder, "Block Order")
            writer.AddBoolean(.SweepToFill, "Sweep to fill")
            writer.AddNullableInteger(.DisplaySize, "Display Size")
            writer.AddString(stopTriggerMethodToString(.TriggerMethod), "Trigger method")
            writer.AddBoolean(.OutsideRth, "Outside RTH")
            writer.AddBoolean(.Hidden, "Hidden")
        End With

        ' send combo legs for BAG requests
        With contract
            If .SecurityType = SecurityType.Combo Then
                writer.AddInteger(.ComboLegs.Count, "Combo legs count")
                If .ComboLegs.Count <> 0 Then
                    For i = 0 To .ComboLegs.Count - 1
                        With .ComboLegs.Item(i)
                            writer.AddInteger(.ContractId, $"Leg {i} Con id")
                            writer.AddInteger(.Ratio, $"Leg {i} Ratio")
                            writer.AddString(IBAPI.OrderActions.ToInternalString(.Action), $"Leg {i} Action")
                            writer.AddString(.Exchange, $"Leg {i} Exchange")
                            writer.AddString(legOpenCloseToString(.OpenClose), $"Leg {i} Open/close")

                            writer.AddInteger(.ShortSaleSlot, "Short Sale Slot")
                            writer.AddString(.DesignatedLocation, "Designated Location")
                            writer.AddInteger(.ExemptCode, "Exempt Code")
                        End With
                    Next
                End If
            End If
        End With

        ' Send order combo legs for BAG requests
        If contract.SecurityType = SecurityType.Combo Then
            writer.AddInteger(order.OrderComboLegs.Length, "Order Combo Legs Count")
            If order.OrderComboLegs.Length <> 0 Then
                For i = 0 To order.OrderComboLegs.Length - 1
                    writer.AddNullableDouble(order.OrderComboLegs(i).Price, $"Leg {i} Price")
                Next
            End If
        End If

        If contract.SecurityType = SecurityType.Combo Then
            writer.AddInteger(order.SmartComboRoutingParameters.Count, "Smart Combo Routing Params Count")
            If order.SmartComboRoutingParameters.Count <> 0 Then
                For i = 0 To order.SmartComboRoutingParameters.Count - 1
                    writer.AddString(order.SmartComboRoutingParameters(i).Tag, $"Param {i} Tag")
                    writer.AddString(order.SmartComboRoutingParameters(i).Value, $"Param {i} Value")
                Next
            End If
        End If

        With order
            writer.AddString("", "Shares Allocation")
            writer.AddDouble(.DiscretionaryAmount, "Discretionary amount")
            writer.AddString(.GoodAfterTime, "Good after Time")
            writer.AddString(.GoodTillDate, "Good till date")

            writer.AddString(.FaGroup, "FAGroup")
            writer.AddString(.FaMethod, "FAMethod")
            writer.AddString(.FaPercentage, "FAPercentage")
            If ServerVersion < ApiServerVersion.FA_PROFILE_DESUPPORT Then writer.AddString("", "FAProfile")

            If ServerVersion >= ApiServerVersion.MODELS_SUPPORT Then writer.AddString(.ModelCode, "Model Code")

            'institutional short sale slot fields.
            writer.AddInteger(.ShortSaleSlot, " Short Sale Slot") ' 0 only for retail, 1 or 2 only for institution.
            writer.AddString(.DesignatedLocation, "Designated Location") ' only populate when shortSaleSlot = 2.

            writer.AddInteger(.ExemptCode, "Exempt Code")

            writer.AddInteger(.OcaType, "Oca type")
            writer.AddString(.Rule80A, "Rule 80A")
            writer.AddString(.SettlingFirm, "Settling firm")
            writer.AddBoolean(.AllOrNone, "All or none")
            writer.AddNullableInteger(.MinimumQuantity, "Minimum quantity")
            writer.AddNullableDouble(.PercentOffset, "Percent Offset")
            writer.AddBoolean(False, "E-trade only")
            writer.AddBoolean(False, "Firm quote only")
            writer.AddNullableDouble(Nothing, "NBBO price cap")
            writer.AddNullableInteger(.AuctionStrategy, "Auction strategy")
            writer.AddNullableDouble(.StartingPrice, "Starting price")
            writer.AddNullableDouble(.StockReferencePrice, "Stock ref price")
            writer.AddNullableDouble(.Delta, "Delta")

            writer.AddNullableDouble(.StockRangeLower, "Stock range lower")
            writer.AddNullableDouble(.StockRangeUpper, "Stock range upper")

            writer.AddBoolean(.OverridePercentageConstraints, "Override percentage constraints")

            ' Volatility orders
            writer.AddNullableDouble(.Volatility, "Volatility")
            writer.AddNullableInteger(.VolatilityType, "Volatility type")
            writer.AddString(IBAPI.OrderTypes.ToInternalString(.DeltaNeutralOrderType), "Delta neutral Order type")
            writer.AddNullableDouble(.DeltaNeutralAuxPrice, "Delta neutral aux price")
            If .DeltaNeutralOrderType <> SecurityType.None Then
                writer.AddInteger(.DeltaNeutralContractId, "Delta Neutral Con Id")
                writer.AddString(.DeltaNeutralSettlingFirm, "Delta Neutral Settling Firm")
                writer.AddString(.DeltaNeutralClearingAccount, "Delta Neutral Clearing Account")
                writer.AddString(.DeltaNeutralClearingIntent, "Delta Neutral Clearing Intent")
            End If

            If .DeltaNeutralOrderType <> SecurityType.None Then
                writer.AddString(.DeltaNeutralOpenClose, "Delta Neutral Open Close")
                writer.AddBoolean(.DeltaNeutralShortSale, "Delta Neutral Short Sale")
                writer.AddInteger(.DeltaNeutralShortSaleSlot, "Delta Neutral Short Sale Slot")
                writer.AddString(.DeltaNeutralDesignatedLocation, "Delta Neutral Designated Location")
            End If

            writer.AddInteger(.ContinuousUpdate, "Continuous update")

            writer.AddNullableInteger(.ReferencePriceType, "Reference price type")

            writer.AddNullableDouble(.TrailStopPrice, "Trail stop price")
            writer.AddNullableDouble(.TrailingPercent, "Trailing Percent")

            writer.AddNullableInteger(.ScaleInititialLevelSize, "ScaleInitLevelSize")
            writer.AddNullableInteger(.ScaleSubsequentLevelSize, "ScaleSubsLevelSize")
            writer.AddNullableDouble(.ScalePriceIncrement, "ScalePriceIncrement")

            If .ScalePriceIncrement > 0.0# And .ScalePriceIncrement <> Double.MaxValue Then
                writer.AddNullableDouble(.ScalePriceAdjustValue, "Scale Price Adjust Value")
                writer.AddNullableInteger(.ScalePriceAdjustInterval, "Scale Price Adjust Interval")
                writer.AddNullableDouble(.ScaleProfitOffset, "Scale Profit Offset")
                writer.AddBoolean(.ScaleAutoReset, "Scale Auto Reset")
                writer.AddNullableInteger(.ScaleInitialPosition, "Scale Init POSITION")
                writer.AddNullableInteger(.ScaleInitialFillQuantity, "Scale Init Fill Qty")
                writer.AddBoolean(.ScaleRandomPercent, "Scale Random Percent")
            End If

            writer.AddString(.ScaleTable, "Scale Table")
            writer.AddString(.ActiveStartTime, "Active Start Time")
            writer.AddString(.ActiveStopTime, "Active Stop Time")

            writer.AddString(IBAPI.HedgeTypes.ToInternalString(.HedgeType), "Hedge Type")
            If .HedgeType <> HedgeType.None Then writer.AddString(.HedgeParameter, "Hedge Param")

            writer.AddBoolean(.OptOutSmartRouting, "Opt Out Smart Routing")

            writer.AddString(.ClearingAccount, "Clearing account")
            writer.AddString(.ClearingIntent, "Clearing intent")

            If .OrderType = OrderType.PeggedToBest Or .OrderType = OrderType.PeggedToMidpoint Then
                writer.AddBoolean(True, "Not held")
            Else
                writer.AddBoolean(.NotHeld, "Not held")
            End If

            If contract.DeltaNeutralContract IsNot Nothing Then
                writer.AddBoolean(True, "Under comp")
                writer.AddInteger(contract.DeltaNeutralContract.ContractId, "Under comp ContractId")
                writer.AddDouble(contract.DeltaNeutralContract.Delta, "Under comp delta")
                writer.AddDouble(contract.DeltaNeutralContract.Price, "Under comp price")
            Else
                writer.AddBoolean(False, "Under comp")
            End If

            writer.AddString(.AlgorithmStrategy, "Algo strategy")
            If .AlgorithmStrategy <> "" Then

                Dim algoParamsCount = .AlgorithmParameters.Length

                writer.AddInteger(algoParamsCount, "Algo params count")
                If algoParamsCount > 0 Then
                    Dim lAlgoParams = .AlgorithmParameters

                    For i = 0 To algoParamsCount - 1
                        writer.AddString(lAlgoParams(i).Tag, "Tag " & i)
                        writer.AddString(lAlgoParams(i).Value, "value " & i)
                    Next
                End If
            End If

            writer.AddString(.AlgorithmId, "Algo Id")

            writer.AddBoolean(.WhatIf, "WhatIf")

            writer.AddString(If(.OrderMiscellaneousOptions Is Nothing, "", String.Join(Of TagValue)(";", .OrderMiscellaneousOptions) & ";"), "Misc Options")

            writer.AddBoolean(.Solicited, "Solicited")

            writer.AddBoolean(.RandomizeSize, "Randomize Size")
            writer.AddBoolean(.RandomizePrice, "Randomize Price")

            If (ServerVersion >= ApiServerVersion.PEGGED_TO_BENCHMARK) Then
                If (.OrderType = OrderType.PeggedToBenchmark) Then
                    writer.AddInteger(.ReferenceContractId, "ReferenceContractId")
                    writer.AddBoolean(.IsPeggedChangeAmountDecrease, "IsPeggedChangeAmountDecrease")
                    writer.AddNullableDouble(.PeggedChangeAmount, "PeggedChangeAmount")
                    writer.AddNullableDouble(.ReferenceChangeAmount, "ReferenceChangeAmount")
                    writer.AddString(.ReferenceExchange, "ReferenceExchange")
                End If

                writer.AddInteger(.Conditions.Count, "Conditions Count")

                If (.Conditions.Count > 0) Then
                    For Each item In .Conditions
                        writer.AddInteger(item.Type, "Type")
                        item.Serialize(writer)
                    Next

                    writer.AddBoolean(.ConditionsIgnoreRth, "ConditionsIgnoreRth")
                    writer.AddBoolean(.ConditionsCancelOrder, "ConditionsCancelOrder")
                End If

                writer.AddString(IBAPI.OrderTypes.ToInternalString(.AdjustedOrderType), "AdjustedOrderType")
                writer.AddNullableDouble(.TriggerPrice, "TriggerPrice")
                writer.AddNullableDouble(.LimitPriceOffset, "LmtPriceOffset")
                writer.AddNullableDouble(.AdjustedStopPrice, "AdjustedStopPrice")
                writer.AddNullableDouble(.AdjustedStopLimitPrice, "AdjustedStopLimitPrice")
                writer.AddNullableDouble(.AdjustedTrailingAmount, "AdjustedTrailingAmount")
                writer.AddInteger(.AdjustableTrailingUnit, "AdjustableTrailingUnit")
            End If

            If (ServerVersion >= ApiServerVersion.EXT_OPERATOR) Then
                writer.AddString(.ExtOperator, "ExtOperator")
            End If

            If (ServerVersion >= ApiServerVersion.SOFT_DOLLAR_TIER) Then
                writer.AddString(.Tier.Name, "Tier Name")
                writer.AddString(.Tier.Value, "Tier Value")
            End If

            If (ServerVersion >= ApiServerVersion.CASH_QTY) Then
                writer.AddNullableDouble(.CashQuantity, "Cash Qty")
            End If

            If ServerVersion >= ApiServerVersion.DECISION_MAKER Then
                writer.AddString(.Mifid2DecisionMaker, "Mifid2DecisionMaker")
                writer.AddString(.Mifid2DecisionAlgo, "Mifid2DecisionAlgo")
            End If

            If ServerVersion >= ApiServerVersion.MIFID_EXECUTION Then
                writer.AddString(.Mifid2ExecutionTrader, "Mifid2ExecutionTrader")
                writer.AddString(.Mifid2ExecutionAlgo, "Mifid2ExecutionAlgo")
            End If

            If ServerVersion >= ApiServerVersion.AUTO_PRICE_FOR_HEDGE Then
                writer.AddBoolean(.DontUseAutoPriceForHedge, "DontUseAutoPriceForHedge")
            End If

            If ServerVersion >= ApiServerVersion.ORDER_CONTAINER Then
                writer.AddBoolean(.IsOmsContainer, "IsOmsContainer")
            End If

            If ServerVersion >= ApiServerVersion.D_PEG_ORDERS Then
                writer.AddBoolean(.DiscretionaryUpToLimitPrice, "DiscretionaryUpToLimitPrice")
            End If

            If ServerVersion >= ApiServerVersion.PRICE_MGMT_ALGO Then
                writer.AddNullableBoolean(.UsePriceMgmtAlgo, "UsePriceMgmtAlgo")
            End If

            If ServerVersion >= ApiServerVersion.DURATION Then
                writer.AddNullableInteger(.Duration, "Duration")
            End If

            If ServerVersion >= ApiServerVersion.POST_TO_ATS Then
                writer.AddNullableInteger(.PostToAts, "PostToAts")
            End If

            If ServerVersion >= ApiServerVersion.AUTO_CANCEL_PARENT Then
                writer.AddBoolean(.AutoCancelParent, "AutoCancelParent")
            End If

            If ServerVersion >= ApiServerVersion.ADVANCED_ORDER_REJECT Then
                writer.AddString(order.AdvancedErrorOverride, "AdvancedErrorOverride")
            End If

            If ServerVersion >= ApiServerVersion.MANUAL_ORDER_TIME Then
                writer.AddString(order.ManualOrderTime, "ManualOrderTime")
            End If

            If ServerVersion >= ApiServerVersion.PEGBEST_PEGMID_OFFSETS Then
                If contract.Exchange.Equals("IBKRATS", StringComparison.InvariantCultureIgnoreCase) Then
                    writer.AddNullableDouble(order.MinimumTradeQuantity, "MinimumTradeQuantity")
                End If
                If order.OrderType = OrderType.PeggedToBest Then
                    writer.AddNullableInteger(order.MinimumCompeteSize, "MinimumCompeteSize")
                    writer.AddNullableDouble(order.CompeteAgainstBestOffset, "CompeteAgainstBestOffset")
                    If order.CompeteAgainstBestOffset = Order.CompeteAgainstBestOffsetUpToMid Then
                        writer.AddNullableDouble(order.MidOffsetAtWhole, "MidOffsetAtWhole")
                        writer.AddNullableDouble(order.MidOffsetAtHalf, "MidOffsetAtHalf")
                    End If
                ElseIf order.OrderType = OrderType.PeggedToMidpoint Then
                    writer.AddNullableDouble(order.MidOffsetAtWhole, "MidOffsetAtWhole")
                    writer.AddNullableDouble(order.MidOffsetAtHalf, "MidOffsetAtHalf")
                End If
            End If

        End With

        writer.SendMessage(_EventConsumers.SocketDataConsumer, True)
    End Sub

    Private Shared Function legOpenCloseToString(Value As LegOpenCloseCode) As String
        Select Case Value
            Case LegOpenCloseCode.Same, LegOpenCloseCode.Open, LegOpenCloseCode.Close, LegOpenCloseCode.Unknown
                legOpenCloseToString = CStr(Value)
            Case Else
                Throw New ArgumentException("Invalid leg open/close value")
        End Select
    End Function

    Private Shared Function stopTriggerMethodToString(Value As TriggerMethod) As String
        Select Case Value
            Case TriggerMethod.BidAsk, TriggerMethod.[Default], TriggerMethod.DoubleBidAsk, TriggerMethod.DoubleLast, TriggerMethod.Last, TriggerMethod.LastOrBidAsk, TriggerMethod.MidPoint
                stopTriggerMethodToString = CStr(Value)
            Case Else
                Throw New ArgumentException("Invalid stop trigger method")
        End Select
    End Function

End Class
