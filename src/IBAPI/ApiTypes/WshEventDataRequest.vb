#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2023 Richard L King (TradeWright Software Systems)
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

Public Class WshEventDataRequest
    Public ReadOnly ContractId As Integer

    Public ReadOnly Filter As String

    Public ReadOnly FillWatchlist As Boolean

    Public ReadOnly FillPortfolio As Boolean

    Public ReadOnly FillCompetitors As Boolean

    Public ReadOnly StartDate As String

    Public ReadOnly EndDate As String

    Public ReadOnly TotalLimit As Integer


    Public Sub New(contractId As Integer, fillWatchlist As Boolean, fillPortfolio As Boolean, fillCompetitors As Boolean, startDate As String, endDate As String, totalLimit As Integer)
        Me.ContractId = contractId
        Me.Filter = ""
        Me.FillWatchlist = fillWatchlist
        Me.FillPortfolio = fillPortfolio
        Me.FillCompetitors = fillCompetitors
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.TotalLimit = totalLimit
    End Sub

    Public Sub New(filter As String, fillWatchlist As Boolean, fillPortfolio As Boolean, fillCompetitors As Boolean, startDate As String, endDate As String, totalLimit As Integer)
        Me.ContractId = Integer.MaxValue
        Me.Filter = filter
        Me.FillWatchlist = fillWatchlist
        Me.FillWatchlist = fillPortfolio
        Me.FillCompetitors = fillCompetitors
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.TotalLimit = totalLimit
    End Sub
End Class
