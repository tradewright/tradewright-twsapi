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

Public Class ScannerDataEventArgs
    Inherits AbstractEventArgsWithTimestamp
    Public Property Benchmark As String

    Public Property ContractDetails As ContractDetails

    Public Property Distance As String

    Public Property LegsStr As String

    Public Property Projection As String

    Public Property Rank As Integer

    Public Property RequestId As Integer

    Public Sub New(timestamp As DateTime, reqId As Integer, rank As Integer, contractDetails As TradeWright.IBAPI.ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String)
        MyBase.New()
        Me._Timestamp = timestamp
        Me.RequestId = reqId
        Me.Rank = rank
        Me.ContractDetails = contractDetails
        Me.Distance = distance
        Me.Benchmark = benchmark
        Me.Projection = projection
        Me.LegsStr = legsStr
    End Sub
End Class