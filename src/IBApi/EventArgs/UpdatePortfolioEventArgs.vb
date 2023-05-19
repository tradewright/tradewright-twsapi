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

Public Class UpdatePortfolioEventArgs
    Inherits AbstractEventArgsWithTimestamp
    Public Property AccountName As String

    Public Property AverageCost As Double

    Public Property Contract As Contract

    Public Property MarketPrice As Double

    Public Property MarketValue As Double

    Public Property Position As Decimal

    Public Property RealizedPNL As Double

    Public Property UnrealizedPNL As Double

    Public Sub New(timestamp As DateTime, contract As TradeWright.IBAPI.Contract, position As Decimal, marketPrice As Double, marketValue As Double, averageCost As Double, unrealizedPNL As Double, realizedPNL As Double, accountName As String)
        MyBase.New()
        Me._Timestamp = timestamp
        Me.Contract = contract
        Me.Position = position
        Me.MarketPrice = marketPrice
        Me.MarketValue = marketValue
        Me.AverageCost = averageCost
        Me.UnrealizedPNL = unrealizedPNL
        Me.RealizedPNL = realizedPNL
        Me.AccountName = accountName
    End Sub
End Class