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

''' <summary>
''' This class contains information about an order that has been placed with TWS.
''' </summary>
Friend Class ActiveOrder

    ''' <summary>
    ''' The row in the OrdersGrid that shows the details for this order.
    ''' </summary>
    ''' <returns></returns>
    Friend Property GridRow As DataGridViewRow

    ''' <summary>
    ''' The original Order object that was used to place the order. We keep
    ''' this to make it easy to modify the order later
    ''' </summary>
    ''' <returns></returns>
    Friend Property Order As Order

    ''' <summary>
    ''' The contract for this order
    ''' </summary>
    ''' <returns></returns>
    Friend Property Contract As Contract

    ''' <summary>
    ''' The order's current status
    ''' </summary>
    ''' <returns></returns>
    Friend Property State As OrderState

End Class
