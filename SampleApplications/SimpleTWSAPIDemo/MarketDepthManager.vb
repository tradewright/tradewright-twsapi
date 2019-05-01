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

Imports TradeWright.IBAPI

Friend Class MarketDepthManager

    Enum Cell
        MarketMaker
        Price
        Size
        CumSize
        AvgPrice
    End Enum

    Private Class ModelEntry
        Friend MarketMaker As String
        Friend Price As Double
        Friend Size As Integer
        Friend CumSize As Integer
        Friend TotalPrice As Double
    End Class

    Private mAsks As List(Of ModelEntry)
    Private mBids As List(Of ModelEntry)

    Private mBidGrid As DataGridView
    Private mAskGrid As DataGridView

    Friend Sub New(bidGrid As DataGridView, askGrid As DataGridView)
        mBidGrid = bidGrid
        mAskGrid = askGrid
    End Sub

    Friend Sub updateMktDepth(tickerId As Integer, rowId As Integer, marketMaker As String, operation As DOMOperation, side As DOMSide, price As Double, size As Integer)
        Select Case side
            Case DOMSide.Bid
                updateDepth(mBids, mBidGrid, rowId, marketMaker, operation, side, price, size)
            Case DOMSide.Ask
                updateDepth(mAsks, mAskGrid, rowId, marketMaker, operation, side, price, size)
            Case Else
                Throw New InvalidOperationException
        End Select
    End Sub

    Friend Sub Initialise(numberOfRows As Integer)
        mAsks = New List(Of ModelEntry)(numberOfRows)
        mBids = New List(Of ModelEntry)(numberOfRows)

        ' flush the book entries
        clear()
    End Sub

    Friend Sub clear()
        mAskGrid.Rows.Clear()
        mBidGrid.Rows.Clear()
    End Sub

    Private Sub updateDepth(model As List(Of ModelEntry), bookEntries As DataGridView, rowId As Integer, marketMaker As String, operation As DOMOperation, side As DOMSide, price As Double, size As Integer)
        Select Case operation
            Case DOMOperation.Insert
                model.Insert(rowId, New ModelEntry() With {.MarketMaker = marketMaker, .Price = price, .Size = size})
            Case DOMOperation.Update
                With model(rowId)
                    .MarketMaker = marketMaker
                    .Price = price
                    .Size = size
                End With
            Case DOMOperation.Delete
                If rowId < model.Count Then model.RemoveAt(rowId)
        End Select

        ' recalc only the average cost and cumulative sizes that could have changed
        updateList(model, bookEntries, rowId)
    End Sub

    Private Sub updateList(model As List(Of ModelEntry), bookEntries As DataGridView, baseRow As Integer)
        Dim totalPrice = 0.0
        Dim cumSize = 0
        If baseRow > 0 And baseRow < model.Count Then
            Dim entry = model(baseRow - 1)
            cumSize = model(baseRow - 1).CumSize
            totalPrice = model(baseRow - 1).TotalPrice
        End If

        For i = baseRow To model.Count - 1
            With model(i)
                cumSize = cumSize + .Size
                .CumSize = cumSize
                totalPrice = totalPrice + (.Price * .Size)
                .TotalPrice = totalPrice

                Dim avgPrice = totalPrice / cumSize

                If i > (bookEntries.Rows.Count - 1) Then bookEntries.Rows.Add()
                bookEntries.Rows(i).SetValues(.MarketMaker, .Price, .Size, cumSize, avgPrice)
            End With
        Next
    End Sub

End Class
