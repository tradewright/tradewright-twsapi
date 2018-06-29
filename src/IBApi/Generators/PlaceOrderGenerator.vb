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
        If mConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")

        If ServerVersion < ApiServerVersion.EXT_OPERATOR And Not String.IsNullOrEmpty(order.ExtOperator) Then Throw New InvalidOperationException("extOperator parameter not supported")
        If ServerVersion < ApiServerVersion.CASH_QTY And order.CashQty.HasValue Then Throw New InvalidOperationException("cashQty parameter not supported")

        Const VERSION As Integer = 45

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.PlaceOrder)
        lWriter.AddElement(VERSION, "Version")

        If order.OrderId = 0 Then order.OrderId = mIdManager.NextOrderId
        If order.OrderId < IdManager.BaseOrderId Then Throw New ArgumentException($"Order id must not be less than {IdManager.BaseOrderId}")
        If order.OrderId > mIdManager.NextOrderId Then mIdManager.NextOrderId = order.OrderId + 1

        lWriter.AddElement(order.OrderId, "Order id")

        lWriter.AddElement(contract, "Contract")

        lWriter.AddElement(secIdType, "Sec id type")
        lWriter.AddElement(secId, "Sec id")

        With order

            ' mwriter.send main Order fields
            lWriter.AddElement(OrderActions.ToInternalString(.Action), "Action")
            If ServerVersion >= ApiServerVersion.FRACTIONAL_POSITIONS Then
                lWriter.AddElement(.TotalQuantity, "Quantity")
            Else
                lWriter.AddElement(CInt(.TotalQuantity), "Quantity")
            End If
            lWriter.AddElement(OrderTypes.ToInternalString(.OrderType), "Order type")

            lWriter.AddElement(.LmtPrice, "Price")
            lWriter.AddElement(.AuxPrice, "Aux price")

            ' mwriter.send extended Order fields
            lWriter.AddElement(OrderTIFs.ToInternalString(.Tif), "TIF")
            lWriter.AddElement(.OcaGroup, "Oca Group")
            lWriter.AddElement(.Account, "Account")
            lWriter.AddElement(.OpenClose, "OpenClose")
            lWriter.AddElement(.Origin, "Origin")
            lWriter.AddElement(.OrderRef, "Order ref")
            lWriter.AddElement(transmit, "Transmit")
            lWriter.AddElement(.ParentId, "Parent id")
            lWriter.AddElement(.BlockOrder, "Block Order")
            lWriter.AddElement(.SweepToFill, "Sweep to fill")
            lWriter.AddElement(.DisplaySize, "Display Size")
            lWriter.AddElement(stopTriggerMethodToString(.TriggerMethod), "Trigger method")
            lWriter.AddElement(.OutsideRth, "Outside RTH")
            lWriter.AddElement(.Hidden, "Hidden")
        End With

        ' send combo legs for BAG requests
        With contract
            If .SecType = SecurityType.Combo Then
                lWriter.AddElement(.ComboLegs.Count, "Combo legs count")
                If .ComboLegs.Count <> 0 Then
                    For i = 0 To .ComboLegs.Count - 1
                        With .ComboLegs.Item(i)
                            lWriter.AddElement(.ConId, $"Leg {i} Con id")
                            lWriter.AddElement(.Ratio, $"Leg {i} Ratio")
                            lWriter.AddElement(OrderActions.ToInternalString(.Action), $"Leg {i} Action")
                            lWriter.AddElement(.Exchange, $"Leg {i} Exchange")
                            lWriter.AddElement(legOpenCloseToString(.OpenClose), $"Leg {i} Open/close")

                            lWriter.AddElement(.ShortSaleSlot, "Short Sale Slot")
                            lWriter.AddElement(.DesignatedLocation, "Designated Location")
                            lWriter.AddElement(.ExemptCode, "Exempt Code")
                        End With
                    Next
                End If
            End If
        End With

        ' Send order combo legs for BAG requests
        If contract.SecType = SecurityType.Combo Then
            lWriter.AddElement(order.OrderComboLegs.Length, "Order Combo Legs Count")
            If order.OrderComboLegs.Length <> 0 Then
                For i = 0 To order.OrderComboLegs.Length - 1
                    lWriter.AddElement(order.OrderComboLegs(i).Price, $"Leg {i} Price")
                Next
            End If
        End If

        If contract.SecType = SecurityType.Combo Then
            lWriter.AddElement(order.SmartComboRoutingParams.Count, "Smart Combo Routing Params Count")
            If order.SmartComboRoutingParams.Count <> 0 Then
                For i = 0 To order.SmartComboRoutingParams.Count - 1
                    lWriter.AddElement(order.SmartComboRoutingParams(i).Tag, $"Param {i} Tag")
                    lWriter.AddElement(order.SmartComboRoutingParams(i).Value, $"Param {i} Value")
                Next
            End If
        End If

        With order
            lWriter.AddElement("", "Shares Allocation")
            lWriter.AddElement(.DiscretionaryAmt, "Discretionary amount")
            lWriter.AddElement(.GoodAfterTime, "Good after Time")
            lWriter.AddElement(.GoodTillDate, "Good till date")

            lWriter.AddElement(.FaGroup, "FAGroup")
            lWriter.AddElement(.FaMethod, "FAMethod")
            lWriter.AddElement(.FaPercentage, "FAPercentage")
            lWriter.AddElement(.FaProfile, "FAProfile")

            If ServerVersion >= ApiServerVersion.MODELS_SUPPORT Then lWriter.AddElement(.ModelCode, "Model Code")

            'institutional short sale slot fields.
            lWriter.AddElement(.ShortSaleSlot, " Short Sale Slot") ' 0 only for retail, 1 or 2 only for institution.
            lWriter.AddElement(.DesignatedLocation, "Designated Location") ' only populate when shortSaleSlot = 2.

            lWriter.AddElement(.ExemptCode, "Exempt Code")

            lWriter.AddElement(.OcaType, "Oca type")
            lWriter.AddElement(.Rule80A, "Rule 80A")
            lWriter.AddElement(.SettlingFirm, "Settling firm")
            lWriter.AddElement(.AllOrNone, "All or none")
            lWriter.AddElement(.MinQty, "Minimum quantity")
            lWriter.AddElement(.PercentOffset, "Percent Offset")
            lWriter.AddElement(.ETradeOnly, "E-trade only")
            lWriter.AddElement(.FirmQuoteOnly, "Firm quote only")
            lWriter.AddElement(.NbboPriceCap, "NBBO price cap")
            lWriter.AddElement(.AuctionStrategy, "Auction strategy")
            lWriter.AddElement(.StartingPrice, "Starting price")
            lWriter.AddElement(.StockRefPrice, "Stock ref price")
            lWriter.AddElement(.Delta, "Delta")

            lWriter.AddElement(.StockRangeLower, "Stock range lower")
            lWriter.AddElement(.StockRangeUpper, "Stock range upper")

            lWriter.AddElement(.OverridePercentageConstraints, "Override percentage constraints")

            ' Volatility orders
            lWriter.AddElement(.Volatility, "Volatility")
            lWriter.AddElement(.VolatilityType, "Volatility type")
            lWriter.AddElement(OrderTypes.ToInternalString(.DeltaNeutralOrderType), "Delta neutral Order type")
            lWriter.AddElement(.DeltaNeutralAuxPrice, "Delta neutral aux price")
            If .DeltaNeutralOrderType <> SecurityType.None Then
                lWriter.AddElement(.DeltaNeutralConId, "Delta Neutral Con Id")
                lWriter.AddElement(.DeltaNeutralSettlingFirm, "Delta Neutral Settling Firm")
                lWriter.AddElement(.DeltaNeutralClearingAccount, "Delta Neutral Clearing Account")
                lWriter.AddElement(.DeltaNeutralClearingIntent, "Delta Neutral Clearing Intent")
            End If

            If .DeltaNeutralOrderType <> SecurityType.None Then
                lWriter.AddElement(.DeltaNeutralOpenClose, "Delta Neutral Open Close")
                lWriter.AddElement(.DeltaNeutralShortSale, "Delta Neutral Short Sale")
                lWriter.AddElement(.DeltaNeutralShortSaleSlot, "Delta Neutral Short Sale Slot")
                lWriter.AddElement(.DeltaNeutralDesignatedLocation, "Delta Neutral Designated Location")
            End If

            lWriter.AddElement(.ContinuousUpdate, "Continuous update")

            lWriter.AddElement(.ReferencePriceType, "Reference price type")

            lWriter.AddElement(.TrailStopPrice, "Trail stop price")
            lWriter.AddElement(.TrailingPercent, "Trailing Percent")

            lWriter.AddElement(.ScaleInitLevelSize, "ScaleInitLevelSize")
            lWriter.AddElement(.ScaleSubsLevelSize, "ScaleSubsLevelSize")
            lWriter.AddElement(.ScalePriceIncrement, "ScalePriceIncrement")

            If .ScalePriceIncrement > 0.0# And .ScalePriceIncrement <> Double.MaxValue Then
                lWriter.AddElement(.ScalePriceAdjustValue, "Scale Price Adjust Value")
                lWriter.AddElement(.ScalePriceAdjustInterval, "Scale Price Adjust Interval")
                lWriter.AddElement(.ScaleProfitOffset, "Scale Profit Offset")
                lWriter.AddElement(.ScaleAutoReset, "Scale Auto Reset")
                lWriter.AddElement(.ScaleInitPosition, "Scale Init POSITION")
                lWriter.AddElement(.ScaleInitFillQty, "Scale Init Fill Qty")
                lWriter.AddElement(.ScaleRandomPercent, "Scale Random Percent")
            End If

            lWriter.AddElement(.ScaleTable, "Scale Table")
            lWriter.AddElement(.ActiveStartTime, "Active Start Time")
            lWriter.AddElement(.ActiveStopTime, "Active Stop Time")

            lWriter.AddElement(HedgeTypes.ToInternalString(.HedgeType), "Hedge Type")
            If .HedgeType <> SecurityType.None Then lWriter.AddElement(.HedgeParam, "Hedge Param")

            lWriter.AddElement(.OptOutSmartRouting, "Opt Out Smart Routing")

            lWriter.AddElement(.ClearingAccount, "Clearing account")
            lWriter.AddElement(.ClearingIntent, "Clearing intent")

            lWriter.AddElement(.NotHeld, "Not held")

            If contract.UnderComp IsNot Nothing Then
                lWriter.AddElement(True, "Under comp")
                lWriter.AddElement(contract.UnderComp.ConId, "Under comp conid")
                lWriter.AddElement(contract.UnderComp.Delta, "Under comp delta")
                lWriter.AddElement(contract.UnderComp.Price, "Under comp price")
            Else
                lWriter.AddElement(False, "Under comp")
            End If

            lWriter.AddElement(.AlgoStrategy, "Algo strategy")
            If .AlgoStrategy <> "" Then

                Dim algoParamsCount = .AlgoParams.Length

                lWriter.AddElement(algoParamsCount, "Algo params count")
                If algoParamsCount > 0 Then
                    Dim lAlgoParams = .AlgoParams

                    For i = 0 To algoParamsCount - 1
                        lWriter.AddElement(lAlgoParams(i).Tag, "Tag " & i)
                        lWriter.AddElement(lAlgoParams(i).Value, "value " & i)
                    Next
                End If
            End If

            lWriter.AddElement(.AlgoId, "Algo Id")

            lWriter.AddElement(.WhatIf, "WhatIf")

            lWriter.AddElement(If(.OrderMiscOptions Is Nothing, "", String.Join(Of TagValue)(";", .OrderMiscOptions) & ";"), "Misc Options")

            lWriter.AddElement(.Solicited, "Solicited")

            lWriter.AddElement(.RandomizeSize, "Randomize Size")
            lWriter.AddElement(.RandomizePrice, "Randomize Price")

            If (ServerVersion >= ApiServerVersion.PEGGED_TO_BENCHMARK) Then
                If (.OrderType = OrderType.PeggedToBenchmark) Then
                    lWriter.AddElement(.ReferenceContractId, "ReferenceContractId")
                    lWriter.AddElement(.IsPeggedChangeAmountDecrease, "IsPeggedChangeAmountDecrease")
                    lWriter.AddElement(.PeggedChangeAmount, "PeggedChangeAmount")
                    lWriter.AddElement(.ReferenceChangeAmount, "ReferenceChangeAmount")
                    lWriter.AddElement(.ReferenceExchange, "ReferenceExchange")
                End If

                lWriter.AddElement(.Conditions.Count, "Conditions Count")

                If (.Conditions.Count > 0) Then
                    For Each item In .Conditions
                        lWriter.AddElement(item.Type, "Type")
                        item.Serialize(lWriter)
                    Next
                End If

                lWriter.AddElement(.ConditionsIgnoreRth, "ConditionsIgnoreRth")
                lWriter.AddElement(.ConditionsCancelOrder, "ConditionsCancelOrder")
            End If

            lWriter.AddElement(.AdjustedOrderType, "AdjustedOrderType")
            lWriter.AddElement(.TriggerPrice, "TriggerPrice")
            lWriter.AddElement(.LmtPriceOffset, "LmtPriceOffset")
            lWriter.AddElement(.AdjustedStopPrice, "AdjustedStopPrice")
            lWriter.AddElement(.AdjustedStopLimitPrice, "AdjustedStopLimitPrice")
            lWriter.AddElement(.AdjustedTrailingAmount, "AdjustedTrailingAmount")
            lWriter.AddElement(.AdjustableTrailingUnit, "AdjustableTrailingUnit")

            If (ServerVersion >= ApiServerVersion.EXT_OPERATOR) Then
                lWriter.AddElement(.ExtOperator, "ExtOperator")
            End If

            If (ServerVersion >= ApiServerVersion.SOFT_DOLLAR_TIER) Then
                lWriter.AddElement(.Tier.Name, "Tier Name")
                lWriter.AddElement(.Tier.Value, "Tier Value")
            End If

            If (ServerVersion >= ApiServerVersion.CASH_QTY) Then
                lWriter.AddElement(.CashQty, "Cash Qty")
            End If

            If ServerVersion >= ApiServerVersion.DECISION_MAKER Then
                lWriter.AddElement(.Mifid2DecisionMaker, "Mifid2DecisionMaker")
                lWriter.AddElement(.Mifid2DecisionAlgo, "Mifid2DecisionAlgo")
            End If

            If ServerVersion >= ApiServerVersion.MIFID_EXECUTION Then
                lWriter.AddElement(.Mifid2ExecutionTrader, "Mifid2ExecutionTrader")
                lWriter.AddElement(.Mifid2ExecutionAlgo, "Mifid2ExecutionAlgo")
            End If

            If ServerVersion >= ApiServerVersion.AUTO_PRICE_FOR_HEDGE Then
                lWriter.AddElement(.DontUseAutoPriceForHedge, "DontUseAutoPriceForHedge")
            End If

        End With

        SendMessage(lWriter, NameOf(PlaceOrderGenerator), NameOf(placeOrder), True)
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
