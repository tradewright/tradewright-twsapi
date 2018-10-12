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

Public Class TickByTickAllLastEventArgs
    Inherits AbstractEventArgsWithTimestamp

    Public ReadOnly Property RequestId As Integer
    Public ReadOnly Property DataType As TickByTickDataType
    Public ReadOnly Property Time As Date
    Public ReadOnly Property Price As Double
    Public ReadOnly Property Size As Integer
    Public ReadOnly Property Attributes As TickAttributes
    Public ReadOnly Property Exchange As String
    Public ReadOnly Property SpecialConditions As String

    Public Sub New(reqId As Integer, tickType As TickByTickDataType, time As Date, price As Double, size As Integer, attributes As TickAttributes, exchange As String, specialConditions As String)
        MyBase.New()
        Me._Timestamp = Timestamp
        Me.RequestId = reqId
        Me.DataType = tickType
        Me.Time = time
        Me.Price = price
        Me.Size = size
        Me.Attributes = attributes
        Me.Exchange = exchange
        Me.SpecialConditions = specialConditions
    End Sub

End Class
