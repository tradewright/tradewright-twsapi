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

Public Class ScannerSubscription

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

    '@================================================================================
    ' Member variables
    '@================================================================================

    Public Property NumberOfRows As Integer?
    Public Property Instrument As String
    Public Property LocationCode As String
    Public Property ScanCode As String
    Public Property AbovePrice As Double?
    Public Property BelowPrice As Double?
    Public Property AboveVolume As Integer?
    Public Property AverageOptionVolumeAbove As Integer?
    Public Property MarketCapAbove As Double?
    Public Property MarketCapBelow As Double?
    Public Property MoodyRatingAbove As String
    Public Property MoodyRatingBelow As String
    Public Property SpRatingAbove As String
    Public Property SpRatingBelow As String
    Public Property MaturityDateAbove As String
    Public Property MaturityDateBelow As String
    Public Property CouponRateAbove As Double?
    Public Property CouponRateBelow As Double?
    Public Property ExcludeConvertible As Boolean
    Public Property ScannerSettingPairs As String
    Public Property StockTypeFilter As String

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