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

Imports TradeWright.IBAPI

Public Class StatisticsEntry
    Private _messageId As ApiSocketInMsgType
    Private _lastSecondCount As Integer
    Private _lastSecondTime As Long
    Private _lastPeriodCount As Integer
    Private _lastPeriodTime As Long
    Private _totalCount As Integer
    Private _totalTime As Long
    Private _maxSecondCount As Integer
    Private _longestTime As Single
    Private _shortestTime As Single

    Public Property MessageId As ApiSocketInMsgType
        Get
            Return _messageId
        End Get
        Friend Set
            _messageId = Value
        End Set
    End Property

    Public Property LastSecondCount As Integer
        Get
            Return _lastSecondCount
        End Get
        Friend Set
            _lastSecondCount = Value
        End Set
    End Property

    Public Property LastSecondTime As Long
        Get
            Return _lastSecondTime
        End Get
        Friend Set
            _lastSecondTime = Value
        End Set
    End Property

    Public Property LastPeriodCount As Integer
        Get
            Return _lastPeriodCount
        End Get
        Friend Set
            _lastPeriodCount = Value
        End Set
    End Property

    Public Property LastPeriodTime As Long
        Get
            Return _lastPeriodTime
        End Get
        Friend Set
            _lastPeriodTime = Value
        End Set
    End Property

    Public Property TotalCount As Integer
        Get
            Return _totalCount
        End Get
        Friend Set
            _totalCount = Value
        End Set
    End Property

    Public Property TotalTime As Long
        Get
            Return _totalTime
        End Get
        Friend Set
            _totalTime = Value
        End Set
    End Property

    Public Property MaxSecondCount As Integer
        Get
            Return _maxSecondCount
        End Get
        Friend Set
            _maxSecondCount = Value
        End Set
    End Property

    Public Property LongestTime As Single
        Get
            Return _longestTime
        End Get
        Friend Set
            _longestTime = Value
        End Set
    End Property

    Public Property ShortestTime As Single
        Get
            Return _shortestTime
        End Get
        Friend Set
            _shortestTime = Value
        End Set
    End Property
End Class

