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

Public Class TickEFPEventArgs
    Inherits AbstractEventArgsWithTimestamp
    Public Property BasisPoints As Double

    Public Property DividendImpact As Double

    Public Property DividendsToLastTradeDate As Double

    Public Property FormattedBasisPoints As String

    Public Property FutureLastTradeDate As String

    Public Property HoldDays As Integer

    Public Property ImpliedFuturesPrice As Double

    Public Property TickerId As Integer

    Public Property TickType As TickType

    Public Sub New(timestamp As DateTime, tickerId As Integer, tickType As TradeWright.IBAPI.TickType, basisPoints As Double, formattedBasisPoints As String, impliedFuturesPrice As Double, holdDays As Integer, futureLastTradeDate As String, dividendImpact As Double, dividendsToLastTradeDate As Double)
        MyBase.New()
        Me._Timestamp = timestamp
        Me.TickerId = tickerId
        Me.TickType = tickType
        Me.BasisPoints = basisPoints
        Me.FormattedBasisPoints = formattedBasisPoints
        Me.ImpliedFuturesPrice = impliedFuturesPrice
        Me.HoldDays = holdDays
        Me.FutureLastTradeDate = futureLastTradeDate
        Me.DividendImpact = dividendImpact
        Me.DividendsToLastTradeDate = dividendsToLastTradeDate
    End Sub
End Class