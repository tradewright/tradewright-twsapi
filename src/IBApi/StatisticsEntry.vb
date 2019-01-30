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

Public Class StatisticsEntry
    Private mMessageId As ApiSocketInMsgType
    Private mLastSecondCount As Integer
    Private mLastSecondTime As Long
    Private mLastPeriodCount As Integer
    Private mLastPeriodTime As Long
    Private mTotalCount As Integer
    Private mTotalTime As Long
    Private mMaxSecondCount As Integer
    Private mLongestTime As Single
    Private mShortestTime As Single

    Public Property MessageId As ApiSocketInMsgType
        Get
            Return mMessageId
        End Get
        Friend Set
            mMessageId = Value
        End Set
    End Property

    Public Property LastSecondCount As Integer
        Get
            Return mLastSecondCount
        End Get
        Friend Set
            mLastSecondCount = Value
        End Set
    End Property

    Public Property LastSecondTime As Long
        Get
            Return mLastSecondTime
        End Get
        Friend Set
            mLastSecondTime = Value
        End Set
    End Property

    Public Property LastPeriodCount As Integer
        Get
            Return mLastPeriodCount
        End Get
        Friend Set
            mLastPeriodCount = Value
        End Set
    End Property

    Public Property LastPeriodTime As Long
        Get
            Return mLastPeriodTime
        End Get
        Friend Set
            mLastPeriodTime = Value
        End Set
    End Property

    Public Property TotalCount As Integer
        Get
            Return mTotalCount
        End Get
        Friend Set
            mTotalCount = Value
        End Set
    End Property

    Public Property TotalTime As Long
        Get
            Return mTotalTime
        End Get
        Friend Set
            mTotalTime = Value
        End Set
    End Property

    Public Property MaxSecondCount As Integer
        Get
            Return mMaxSecondCount
        End Get
        Friend Set
            mMaxSecondCount = Value
        End Set
    End Property

    Public Property LongestTime As Single
        Get
            Return mLongestTime
        End Get
        Friend Set
            mLongestTime = Value
        End Set
    End Property

    Public Property ShortestTime As Single
        Get
            Return mShortestTime
        End Get
        Friend Set
            mShortestTime = Value
        End Set
    End Property
End Class

