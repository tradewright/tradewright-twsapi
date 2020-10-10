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

        If ServerVersion < ApiServerVersion.EXT_OPERATOR And Not String.IsNullOrEmpty(order.ExtOperator) Then Throw New InvalidOperationException("extOperator parameter not supported")
        If ServerVersion < ApiServerVersion.CASH_QTY And order.CashQty.HasValue Then Throw New InvalidOperationException("cashQty parameter not supported")

        Const VERSION As Integer = 45

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.PlaceOrder)
        lWriter.AddInteger(VERSION, "Version")

        If order.OrderId = 0 Then order.OrderId = _IdManager.NextOrderId
        If order.OrderId < IdManager.BaseOrderId Then Throw New ArgumentException($"Order id must not be less than {IdManager.BaseOrderId}")
        If order.OrderId > _IdManager.NextOrderId Then _IdManager.NextOrderId = order.OrderId + 1

        lWriter.AddInteger(order.OrderId, "Order id")

        lWriter.AddContract(contract, "Contract")

        lWriter.AddString(secIdType, "Sec id type")
        lWriter.AddString(secId, "Sec id")

        With order

            ' mwriter.send main Order fields
            lWriter.AddString(IBAPI.OrderActions.ToInternalString(.Action), "Action")
            If ServerVersion >= ApiServerVersion.FRACTIONAL_POSITIONS Then
                lWriter.AddDouble(.TotalQuantity, "Quantity")
            Else
                lWriter.AddInteger(CInt(.TotalQuantity), "Quantity")
            End If
            lWriter.AddString(IBAPI.OrderTypes.ToInternalString(.OrderType), "Order type")

            lWriter.AddNullableDouble(.LmtPrice, "Price")
            lWriter.AddNullableDouble(.AuxPrice, "Aux price")

            ' mwriter.send extended Order fields
            lWriter.AddString(IBAPI.OrderTIFs.ToInternalString(.Tif), "TIF")
            lWriter.AddString(.OcaGroup, "Oca Group")
            lWriter.AddString(.Account, "Account")
            lWriter.AddString(.OpenClose, "OpenClose")
            lWriter.AddInteger(.Origin, "Origin")
            lWriter.AddString(.OrderRef, "Order ref")
            lWriter.AddBoolean(transmit, "Transmit")
            lWriter.AddInteger(.ParentId, "Parent id")
            lWriter.AddBoolean(.BlockOrder, "Block Order")
            lWriter.AddBoolean(.SweepToFill, "Sweep to fill")
            lWriter.AddInteger(.DisplaySize, "Display Size")
            lWriter.AddString(stopTriggerMethodToString(.TriggerMethod), "Trigger method")
            lWriter.AddBoolean(.OutsideRth, "Outside RTH")
            lWriter.AddBoolean(.Hidden, "Hidden")
        End With

        ' send combo legs for BAG requests
        With contract
            If .SecType = SecurityType.Combo Then
                lWriter.AddInteger(.ComboLegs.Count, "Combo legs count")
                If .ComboLegs.Count <> 0 Then
                    For i = 0 To .ComboLegs.Count - 1
                        With .ComboLegs.Item(i)
                            lWriter.AddInteger(.ConId, $"Leg {i} Con id")
                            lWriter.AddInteger(.Ratio, $"Leg {i} Ratio")
                            lWriter.AddString(IBAPI.OrderActions.ToInternalString(.Action), $"Leg {i} Action")
                            lWriter.AddString(.Exchange, $"Leg {i} Exchange")
                            lWriter.AddString(legOpenCloseToString(.OpenClose), $"Leg {i} Open/close")

                            lWriter.AddInteger(.ShortSaleSlot, "Short Sale Slot")
                            lWriter.AddString(.DesignatedLocation, "Designated Location")
                            lWriter.AddInteger(.ExemptCode, "Exempt Code")
                        End With
                    Next
                End If
            End If
        End With

        ' Send order combo legs for BAG requests
        If contract.SecType = SecurityType.Combo Then
            lWriter.AddInteger(order.OrderComboLegs.Length, "Order Combo Legs Count")
            If order.OrderComboLegs.Length <> 0 Then
                For i = 0 To order.OrderComboLegs.Length - 1
                    lWriter.AddNullableDouble(order.OrderComboLegs(i).Price, $"Leg {i} Price")
                Next
            End If
        End If

        If contract.SecType = SecurityType.Combo Then
            lWriter.AddInteger(order.SmartComboRoutingParams.Count, "Smart Combo Routing Params Count")
            If order.SmartComboRoutingParams.Count <> 0 Then
                For i = 0 To order.SmartComboRoutingParams.Count - 1
                    lWriter.AddString(order.SmartComboRoutingParams(i).Tag, $"Param {i} Tag")
                    lWriter.AddString(order.SmartComboRoutingParams(i).Value, $"Param {i} Value")
                Next
            End If
        End If

        With order
            lWriter.AddString("", "Shares Allocation")
            lWriter.AddDouble(.DiscretionaryAmt, "Discretionary amount")
            lWriter.AddString(.GoodAfterTime, "Good after Time")
            lWriter.AddString(.GoodTillDate, "Good till date")

            lWriter.AddString(.FaGroup, "FAGroup")
            lWriter.AddString(.FaMethod, "FAMethod")
            lWriter.AddString(.FaPercentage, "FAPercentage")
            lWriter.AddString(.FaProfile, "FAProfile")

            If ServerVersion >= ApiServerVersion.MODELS_SUPPORT Then lWriter.AddString(.ModelCode, "Model Code")

            'institutional short sale slot fields.
            lWriter.AddInteger(.ShortSaleSlot, " Short Sale Slot") ' 0 only for retail, 1 or 2 only for institution.
            lWriter.AddString(.DesignatedLocation, "Designated Location") ' only populate when shortSaleSlot = 2.

            lWriter.AddInteger(.ExemptCode, "Exempt Code")

            lWriter.AddInteger(.OcaType, "Oca type")
            lWriter.AddString(.Rule80A, "Rule 80A")
            lWriter.AddString(.SettlingFirm, "Settling firm")
            lWriter.AddBoolean(.AllOrNone, "All or none")
            lWriter.AddNullableInteger(.MinQty, "Minimum quantity")
            lWriter.AddNullableDouble(.PercentOffset, "Percent Offset")
            lWriter.AddBoolean(.ETradeOnly, "E-trade only")
            lWriter.AddBoolean(.FirmQuoteOnly, "Firm quote only")
            lWriter.AddNullableDouble(.NbboPriceCap, "NBBO price cap")
            lWriter.AddNullableInteger(.AuctionStrategy, "Auction strategy")
            lWriter.AddNullableDouble(.StartingPrice, "Starting price")
            lWriter.AddNullableDouble(.StockRefPrice, "Stock ref price")
            lWriter.AddNullableDouble(.Delta, "Delta")

            lWriter.AddNullableDouble(.StockRangeLower, "Stock range lower")
            lWriter.AddNullableDouble(.StockRangeUpper, "Stock range upper")

            lWriter.AddBoolean(.OverridePercentageConstraints, "Override percentage constraints")

            ' Volatility orders
            lWriter.AddNullableDouble(.Volatility, "Volatility")
            lWriter.AddNullableInteger(.VolatilityType, "Volatility type")
            lWriter.AddString(IBAPI.OrderTypes.ToInternalString(.DeltaNeutralOrderType), "Delta neutral Order type")
            lWriter.AddNullableDouble(.DeltaNeutralAuxPrice, "Delta neutral aux price")
            If .DeltaNeutralOrderType <> SecurityType.None Then
                lWriter.AddInteger(.DeltaNeutralConId, "Delta Neutral Con Id")
                lWriter.AddString(.DeltaNeutralSettlingFirm, "Delta Neutral Settling Firm")
                lWriter.AddString(.DeltaNeutralClearingAccount, "Delta Neutral Clearing Account")
                lWriter.AddString(.DeltaNeutralClearingIntent, "Delta Neutral Clearing Intent")
            End If

            If .DeltaNeutralOrderType <> SecurityType.None Then
                lWriter.AddString(.DeltaNeutralOpenClose, "Delta Neutral Open Close")
                lWriter.AddBoolean(.DeltaNeutralShortSale, "Delta Neutral Short Sale")
                lWriter.AddInteger(.DeltaNeutralShortSaleSlot, "Delta Neutral Short Sale Slot")
                lWriter.AddString(.DeltaNeutralDesignatedLocation, "Delta Neutral Designated Location")
            End If

            lWriter.AddInteger(.ContinuousUpdate, "Continuous update")

            lWriter.AddNullableInteger(.ReferencePriceType, "Reference price type")

            lWriter.AddNullableDouble(.TrailStopPrice, "Trail stop price")
            lWriter.AddNullableDouble(.TrailingPercent, "Trailing Percent")

            lWriter.AddNullableInteger(.ScaleInitLevelSize, "ScaleInitLevelSize")
            lWriter.AddNullableInteger(.ScaleSubsLevelSize, "ScaleSubsLevelSize")
            lWriter.AddNullableDouble(.ScalePriceIncrement, "ScalePriceIncrement")

            If .ScalePriceIncrement > 0.0# And .ScalePriceIncrement <> Double.MaxValue Then
                lWriter.AddNullableDouble(.ScalePriceAdjustValue, "Scale Price Adjust Value")
                lWriter.AddNullableInteger(.ScalePriceAdjustInterval, "Scale Price Adjust Interval")
                lWriter.AddNullableDouble(.ScaleProfitOffset, "Scale Profit Offset")
                lWriter.AddBoolean(.ScaleAutoReset, "Scale Auto Reset")
                lWriter.AddNullableInteger(.ScaleInitPosition, "Scale Init POSITION")
                lWriter.AddNullableInteger(.ScaleInitFillQty, "Scale Init Fill Qty")
                lWriter.AddBoolean(.ScaleRandomPercent, "Scale Random Percent")
            End If

            lWriter.AddString(.ScaleTable, "Scale Table")
            lWriter.AddString(.ActiveStartTime, "Active Start Time")
            lWriter.AddString(.ActiveStopTime, "Active Stop Time")

            lWriter.AddString(IBAPI.HedgeTypes.ToInternalString(.HedgeType), "Hedge Type")
            If .HedgeType <> HedgeType.None Then lWriter.AddString(.HedgeParam, "Hedge Param")

            lWriter.AddBoolean(.OptOutSmartRouting, "Opt Out Smart Routing")

            lWriter.AddString(.ClearingAccount, "Clearing account")
            lWriter.AddString(.ClearingIntent, "Clearing intent")

            lWriter.AddBoolean(.NotHeld, "Not held")

            If contract.DeltaNeutralContract IsNot Nothing Then
                lWriter.AddBoolean(True, "Under comp")
                lWriter.AddInteger(contract.DeltaNeutralContract.ConId, "Under comp conid")
                lWriter.AddDouble(contract.DeltaNeutralContract.Delta, "Under comp delta")
                lWriter.AddDouble(contract.DeltaNeutralContract.Price, "Under comp price")
            Else
                lWriter.AddBoolean(False, "Under comp")
            End If

            lWriter.AddString(.AlgoStrategy, "Algo strategy")
            If .AlgoStrategy <> "" Then

                Dim algoParamsCount = .AlgoParams.Length

                lWriter.AddInteger(algoParamsCount, "Algo params count")
                If algoParamsCount > 0 Then
                    Dim lAlgoParams = .AlgoParams

                    For i = 0 To algoParamsCount - 1
                        lWriter.AddString(lAlgoParams(i).Tag, "Tag " & i)
                        lWriter.AddString(lAlgoParams(i).Value, "value " & i)
                    Next
                End If
            End If

            lWriter.AddString(.AlgoId, "Algo Id")

            lWriter.AddBoolean(.WhatIf, "WhatIf")

            lWriter.AddString(If(.OrderMiscOptions Is Nothing, "", String.Join(Of TagValue)(";", .OrderMiscOptions) & ";"), "Misc Options")

            lWriter.AddBoolean(.Solicited, "Solicited")

            lWriter.AddBoolean(.RandomizeSize, "Randomize Size")
            lWriter.AddBoolean(.RandomizePrice, "Randomize Price")

            If (ServerVersion >= ApiServerVersion.PEGGED_TO_BENCHMARK) Then
                If (.OrderType = OrderType.PeggedToBenchmark) Then
                    lWriter.AddInteger(.ReferenceContractId, "ReferenceContractId")
                    lWriter.AddBoolean(.IsPeggedChangeAmountDecrease, "IsPeggedChangeAmountDecrease")
                    lWriter.AddNullableDouble(.PeggedChangeAmount, "PeggedChangeAmount")
                    lWriter.AddNullableDouble(.ReferenceChangeAmount, "ReferenceChangeAmount")
                    lWriter.AddString(.ReferenceExchange, "ReferenceExchange")
                End If

                lWriter.AddInteger(.Conditions.Count, "Conditions Count")

                If (.Conditions.Count > 0) Then
                    For Each item In .Conditions
                        lWriter.AddInteger(item.Type, "Type")
                        item.Serialize(lWriter)
                    Next

                    lWriter.AddBoolean(.ConditionsIgnoreRth, "ConditionsIgnoreRth")
                    lWriter.AddBoolean(.ConditionsCancelOrder, "ConditionsCancelOrder")
                End If

                lWriter.AddString(IBAPI.OrderTypes.ToInternalString(.AdjustedOrderType), "AdjustedOrderType")
                lWriter.AddNullableDouble(.TriggerPrice, "TriggerPrice")
                lWriter.AddNullableDouble(.LmtPriceOffset, "LmtPriceOffset")
                lWriter.AddNullableDouble(.AdjustedStopPrice, "AdjustedStopPrice")
                lWriter.AddNullableDouble(.AdjustedStopLimitPrice, "AdjustedStopLimitPrice")
                lWriter.AddNullableDouble(.AdjustedTrailingAmount, "AdjustedTrailingAmount")
                lWriter.AddInteger(.AdjustableTrailingUnit, "AdjustableTrailingUnit")
            End If

            If (ServerVersion >= ApiServerVersion.EXT_OPERATOR) Then
                lWriter.AddString(.ExtOperator, "ExtOperator")
            End If

            If (ServerVersion >= ApiServerVersion.SOFT_DOLLAR_TIER) Then
                lWriter.AddString(.Tier.Name, "Tier Name")
                lWriter.AddString(.Tier.Value, "Tier Value")
            End If

            If (ServerVersion >= ApiServerVersion.CASH_QTY) Then
                lWriter.AddNullableDouble(.CashQty, "Cash Qty")
            End If

            If ServerVersion >= ApiServerVersion.DECISION_MAKER Then
                lWriter.AddString(.Mifid2DecisionMaker, "Mifid2DecisionMaker")
                lWriter.AddString(.Mifid2DecisionAlgo, "Mifid2DecisionAlgo")
            End If

            If ServerVersion >= ApiServerVersion.MIFID_EXECUTION Then
                lWriter.AddString(.Mifid2ExecutionTrader, "Mifid2ExecutionTrader")
                lWriter.AddString(.Mifid2ExecutionAlgo, "Mifid2ExecutionAlgo")
            End If

            If ServerVersion >= ApiServerVersion.AUTO_PRICE_FOR_HEDGE Then
                lWriter.AddBoolean(.DontUseAutoPriceForHedge, "DontUseAutoPriceForHedge")
            End If

        End With

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer, True)
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
