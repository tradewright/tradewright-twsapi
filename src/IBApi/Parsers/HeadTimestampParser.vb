﻿#Region "License"

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

Imports System.Globalization
Imports System.Threading.Tasks

Friend NotInheritable Class HeadTimestampParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(HeadTimestampParser)

       Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("Request Id")
        Dim headTimestamp = Date.ParseExact(Await _Reader.GetStringAsync("Headtimestamp"), "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture)

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
        _EventConsumers.HistDataConsumer?.NotifyHeadTimestamp(New HeadTimestampEventArgs(timestamp, requestId, headTimestamp))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifyHeadTimestamp", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.HeadTimestamp
        End Get
    End Property

End Class
