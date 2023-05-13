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

Friend NotInheritable Class ExecutionDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(ExecutionDataParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lReqId = -1
        If (pVersion >= 7) Then lReqId = IdManager.GetCallerId(Await _Reader.GetIntAsync("lReqId"), IdType.Execution)

        Dim orderId = Await _Reader.GetIntAsync("OrderId")

        Dim lContract As New Contract
        With lContract
            If (pVersion >= 5) Then .ConId = Await _Reader.GetIntAsync("Con Id")
            .Symbol = Await _Reader.GetStringAsync("Symbol")
            .SecType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))
            .Expiry = Await _Reader.GetStringAsync("Expiry")
            .Strike = Await _Reader.GetDoubleAsync("Strike")
            .OptRight = IBAPI.OptionRights.Parse(Await _Reader.GetStringAsync("Right"))
            If pVersion >= 9 Then .Multiplier = Await _Reader.GetDoubleAsync("Multiplier")
            If .Multiplier = 0 Then .Multiplier = 1
            .Exchange = Await _Reader.GetStringAsync("Exchange")
            .CurrencyCode = Await _Reader.GetStringAsync("Currency")
            .LocalSymbol = Await _Reader.GetStringAsync("Local Symbol")
            If pVersion >= 10 Then .TradingClass = Await _Reader.GetStringAsync("TradingClass")
        End With

        Dim lExecution As New Execution With {
            .OrderId = orderId,
            .ExecId = Await _Reader.GetStringAsync("Exec id"),
            .Time = Await _Reader.GetStringAsync("Exec Time"),
            .AcctNumber = Await _Reader.GetStringAsync("Account id"),
            .Exchange = Await _Reader.GetStringAsync("Exchange"),
            .Side = Await _Reader.GetStringAsync("Side"),
            .Shares = Await _Reader.GetDoubleAsync("Shares"),
            .Price = Await _Reader.GetDoubleAsync("Price"),
            .PermId = If(pVersion >= 2, Await _Reader.GetIntAsync("Perm Id"), 0),
            .ClientID = If(pVersion >= 3, Await _Reader.GetIntAsync("Client id"), 0),
            .Liquidation = If(pVersion >= 4, Await _Reader.GetBooleanAsync("Liquidation"), False),
            .CumQty = If(pVersion >= 6, Await _Reader.GetIntAsync("Cum Qty"), 0),
            .AvgPrice = If(pVersion >= 6, Await _Reader.GetDoubleAsync("Avg Price"), 0),
            .OrderRef = If(pVersion >= 8, Await _Reader.GetStringAsync("OrderRef"), ""),
            .EvRule = If(pVersion >= 9, Await _Reader.GetStringAsync("EvRule"), ""),
            .EvMultiplier = If(pVersion >= 9, Await _Reader.GetDoubleAsync("EvMultiplier"), 1),
            .ModelCode = If(ServerVersion >= ApiServerVersion.MODELS_SUPPORT, Await _Reader.GetStringAsync("Model Code"), ""),
            .LastLiquidity = CType(If(ServerVersion >= ApiServerVersion.LAST_LIQUIDITY, Await _Reader.GetIntAsync("Last Liquidity"), 0), LiquidityType)
        }

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.OrderInfoConsumer?.NotifyExecution(New ExecutionDetailsEventArgs(timestamp, lReqId, lContract, lExecution))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyExecution", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.ExecutionData
        End Get
    End Property

End Class
