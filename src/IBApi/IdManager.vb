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

Friend Class IdManager

    Private Const BaseMarketDataRequestId As Integer = 0
    Private Const BaseMarketDepthRequestId As Integer = &H40000
    Private Const BaseHistoricalDataRequestId As Integer = &H60000
    Private Const BaseRealtimeBarsRequestId As Integer = &H80000
    Private Const BaseExecutionsRequestId As Integer = &HC0000
    Private Const BaseContractRequestId As Integer = &H100000
    Friend Const BaseOrderId As Integer = &H10000000

    Friend Const MaxCallersMarketDataRequestId As Integer = BaseMarketDepthRequestId - 1
    Friend Const MaxCallersMarketDepthRequestId As Integer = BaseHistoricalDataRequestId - BaseMarketDepthRequestId - 1
    Friend Const MaxCallersHistoricalDataRequestId As Integer = BaseRealtimeBarsRequestId - BaseHistoricalDataRequestId - 1
    Friend Const MaxCallersRealtimeBarsRequestId As Integer = BaseExecutionsRequestId - BaseRealtimeBarsRequestId - 1
    Friend Const MaxCallersExecutionsRequestId As Integer = BaseContractRequestId - BaseExecutionsRequestId - 1
    Friend Const MaxCallersContractRequestId As Integer = BaseOrderId - BaseContractRequestId - 1
    Friend Const MaxCallersOrderId As Integer = &H7FFFFFFF - BaseOrderId - 1

    Private mNextOrderID As Integer = IdManager.BaseOrderId

    Friend Shared Function GetCallerId(twsId As Integer, idType As IdType) As Integer
        Select Case idType
            Case IdType.MarketData
                Return twsId - BaseMarketDataRequestId
            Case IdType.MarketDepth
                Return twsId - BaseMarketDepthRequestId
            Case IdType.HistoricalData
                Return twsId - BaseHistoricalDataRequestId
            Case IdType.RealtimeBars
                Return twsId - BaseRealtimeBarsRequestId
            Case IdType.Execution
                Return twsId - BaseExecutionsRequestId
            Case IdType.ContractData
                Return twsId - BaseContractRequestId
            Case IdType.Order
                Return twsId - BaseOrderId
            Case Else
                Throw New ArgumentException("")
        End Select
    End Function

    Friend Shared Function GetIdType(id As Integer) As IdType
        If id >= BaseOrderId Then
            Return IdType.Order
        ElseIf id >= BaseContractRequestId Then
            Return IdType.ContractData
        ElseIf id >= BaseExecutionsRequestId Then
            Return IdType.Execution
        ElseIf id >= BaseRealtimeBarsRequestId Then
            Return IdType.RealtimeBars
        ElseIf id >= BaseHistoricalDataRequestId Then
            Return IdType.HistoricalData
        ElseIf id >= BaseMarketDepthRequestId Then
            Return IdType.MarketDepth
        ElseIf id >= 0 Then
            Return IdType.MarketData
        Else
            Return IdType.None
        End If
    End Function

    Friend Property NextOrderId() As Integer
        Get
            NextOrderId = mNextOrderID
            mNextOrderID += 1
        End Get
        Set(Value As Integer)
            If Value < mNextOrderID Then Throw New ArgumentException($"Value must be >={mNextOrderID}")
            mNextOrderID = Value
        End Set
    End Property

    Friend Shared Function GetTwsId(callerId As Integer, idType As IdType) As Integer
        If callerId < 0 Then Throw New ArgumentException("Id must be greater then 0")
        Select Case idType
            Case IdType.MarketData
                If callerId > MaxCallersMarketDataRequestId Then Throw New ArgumentException($"Max request id is {MaxCallersMarketDataRequestId}")
                Return callerId + BaseMarketDataRequestId
            Case IdType.MarketDepth
                If callerId > MaxCallersMarketDepthRequestId Then Throw New ArgumentException($"Max request id is {MaxCallersMarketDepthRequestId}")
                Return callerId + BaseMarketDepthRequestId
            Case IdType.HistoricalData
                If callerId > MaxCallersHistoricalDataRequestId Then Throw New ArgumentException($"Max request id is {MaxCallersHistoricalDataRequestId}")
                Return callerId + BaseHistoricalDataRequestId
            Case IdType.RealtimeBars
                If callerId > MaxCallersRealtimeBarsRequestId Then Throw New ArgumentException($"Max request id is {MaxCallersRealtimeBarsRequestId}")
                Return callerId + BaseRealtimeBarsRequestId
            Case IdType.Execution
                If callerId > MaxCallersExecutionsRequestId Then Throw New ArgumentException($"Max request id is {MaxCallersExecutionsRequestId}")
                Return callerId + BaseExecutionsRequestId
            Case IdType.ContractData
                If callerId > MaxCallersContractRequestId Then Throw New ArgumentException($"Max request id is {MaxCallersContractRequestId}")
                Return callerId + BaseContractRequestId
            Case IdType.Order
                Throw New InvalidOperationException("Invalid call")
            Case Else
                Throw New ArgumentException("")
        End Select
    End Function
End Class
