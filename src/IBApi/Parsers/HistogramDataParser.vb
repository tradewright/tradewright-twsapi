﻿#Region "License"

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
Imports System.Threading.Tasks

Friend NotInheritable Class HistogramDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(HistogramDataParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("RequestId")
        Dim entryCount = Await _Reader.GetIntAsync("Entry Count")
        Dim histData = New List(Of HistogramEntry)

        For i = 1 To entryCount
            histData.Add(New HistogramEntry() With {.Price = Await _Reader.GetDoubleAsync("Price"),
                                                    .Size = Await _Reader.GetLongAsync("Size")})
        Next

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
        _EventConsumers.HistoricalDataConsumer?.NotifyHistogramData(New HistogramDataEventArgs(timestamp, requestId, histData))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifyHistogramData", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.HistogramData
        End Get
    End Property

End Class
