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

Imports System.Collections.Generic

Public Class ContractDetails

    ''
    ' Description here
    '
    '@/

    '@================================================================================
    ' Interfaces
    '@================================================================================

    '@================================================================================
    ' Events
    '@================================================================================

    '@================================================================================
    ' Enums
    '@================================================================================

    '@================================================================================
    ' Types
    '@================================================================================

    '@================================================================================
    ' Constants
    '@================================================================================

    Private Const ModuleName As String = NameOf(ContractDetails)

    '@================================================================================
    ' Member variables
    '@================================================================================

    Public Property Summary As Contract
    Public Property MarketName As String
    Public Property MinTick As Double
    Public Property PriceMagnifier As Integer
    Public Property OrderTypes As String
    Public Property ValidExchanges As String
    Public Property UnderConId As Integer
    Public Property LongName As String
    Public Property ContractMonth As String
    Public Property Industry As String
    Public Property Category As String
    Public Property Subcategory As String
    Public Property TimeZoneId As String
    Public Property TradingHours As String
    Public Property LiquidHours As String

    Public Property EvRule As String
    Public Property EvMultiplier As Double
    Public Property MDSizeMultiplier As Integer
    Public Property AggGroup As Integer
    Public Property SecIdList As List(Of TagValue) ' CUSIP/ISIN/etc.
    Public Property UnderSymbol As String
    Public Property UnderSecType As SecurityType
    Public Property MarketRuleIds As String
    Public Property RealExpirationDate As String
    Public Property LastTradeTime As String



    ' BOND values
    Public Property Cusip As String
    Public Property Ratings As String
    Public Property DescAppend As String
    Public Property BondType As String
    Public Property CouponType As String
    Public Property Callable As Boolean = False
    Public Property Putable As Boolean = False
    Public Property Coupon As Double = 0.0
    Public Property Convertible As Boolean = False
    Public Property Maturity As String
    Public Property IssueDate As String
    Public Property NextOptionDate As String
    Public Property NextOptionType As String
    Public Property NextOptionPartial As Boolean = False
    Public Property Notes As String

    '@================================================================================
    ' Class Event Handlers
    '@================================================================================

    '@================================================================================
    ' XXXX Interface Members
    '@================================================================================

    '@================================================================================
    ' XXXX Event Handlers
    '@================================================================================

    '@================================================================================
    ' Properties
    '@================================================================================



    '@================================================================================
    ' Methods
    '@================================================================================

    '@================================================================================
    ' Helper Functions
    '@================================================================================
End Class