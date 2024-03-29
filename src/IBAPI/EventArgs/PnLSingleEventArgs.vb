﻿#Region "License"

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

Public Class PnLSingleEventArgs
    Inherits AbstractEventArgsWithTimestamp

    Public Property PnL As Double
    Public Property Position As Decimal
    Public Property RequestId As Integer
    Public Property UnrealizedPnL As Double?
    Public Property RealizedPnL As Double?
    Public Property Value As Double

    Public Sub New(timestamp As DateTime, requestId As Integer, position As Decimal, pnl As Double, unrealizedPnL As Double?, realizedPnL As Double?, value As Double)
        MyBase.New()
        Me._Timestamp = timestamp
        Me.RequestId = requestId
        Me.Position = position
        Me.PnL = pnl
        Me.UnrealizedPnL = unrealizedPnL
        Me.RealizedPnL = realizedPnL
        Me.Value = value
    End Sub
End Class