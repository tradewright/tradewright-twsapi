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

Public Class OrderStatusEventArgs
    Inherits AbstractEventArgsWithTimestamp
    Public Property AvgFillPrice As Double

    Public Property ClientId As Integer

    Public Property Filled As Double

    Public Property LastFillPrice As Double

    Public Property OrderId As Integer

    Public Property ParentId As Integer

    Public Property PermId As Integer

    Public Property Remaining As Double

    Public Property Status As String

    Public Property WhyHeld As String

    Public Property MarketCapPrice As Double

    Public Sub New(timestamp As DateTime, orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String, marketCapPrice As Double)
        MyBase.New()
        Me._Timestamp = timestamp
        Me.OrderId = orderId
        Me.Status = status
        Me.Filled = filled
        Me.Remaining = remaining
        Me.AvgFillPrice = avgFillPrice
        Me.PermId = permId
        Me.ParentId = parentId
        Me.LastFillPrice = lastFillPrice
        Me.ClientId = clientId
        Me.WhyHeld = whyHeld
        Me.MarketCapPrice = marketCapPrice
    End Sub
End Class