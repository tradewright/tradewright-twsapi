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

Public Class TickOptionComputationEventArgs
    Inherits AbstractEventArgsWithTimestamp
    Public Property Delta As Double?

    Public Property Field As TickType

    Public Property Gamma As Double?

    Public Property ImpliedVolatility As Double?

    Public Property OptPrice As Double?

    Public Property PvDividend As Double?

    Public Property Theta As Double?

    Public Property TickerId As Integer

    Public Property UndPrice As Double?

    Public Property Vega As Double?

    Public Sub New(timestamp As DateTime,
                   tickerId As Integer,
                   field As TickType,
                   impliedVolatility As Double?,
                   delta As Double?,
                   optPrice As Double?,
                   pvDividend As Double?,
                   gamma As Double?,
                   vega As Double?,
                   theta As Double?,
                   undPrice As Double?)
        MyBase.New()
        Me._Timestamp = timestamp
        Me.TickerId = tickerId
        Me.Field = field
        Me.ImpliedVolatility = impliedVolatility
        Me.Delta = delta
        Me.OptPrice = optPrice
        Me.PvDividend = pvDividend
        Me.Gamma = gamma
        Me.Vega = vega
        Me.Theta = theta
        Me.UndPrice = undPrice
    End Sub
End Class