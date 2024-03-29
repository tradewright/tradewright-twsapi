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

Friend Class RequestHistoricalNewsGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, contractId as integer, providerCodes As String, startTime As Date, endTime As Date, maxResults As Integer, options As List(Of TagValue))

    Private Const ModuleName As String = NameOf(RequestHistoricalNewsGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestHistoricalNews)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestHistoricalNews
        End Get
    End Property

    Private Sub requestHistoricalNews(requestId As Integer, contractId as integer, providerCodes As String, startTime As Date, endTime As Date, maxResults As Integer, options As List(Of TagValue))


        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.REQ_HISTORICAL_NEWS Then Throw New InvalidOperationException("Historical news requests not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddInteger(requestId, "Request ID")
        lWriter.AddInteger(contractId,"ContractId")
        lWriter.AddString(providerCodes, "Provider Codes")

        Const DateFormat As String = "yyyy-MM-dd HH:mm:ss.0"
        lWriter.AddString(startTime.ToString(DateFormat), "Start Time")
        lWriter.AddString(endTime.ToString(DateFormat), "End Time")
        lWriter.AddInteger(maxResults, "Max Results")

        If ServerVersion >= ApiServerVersion.NEWS_QUERY_ORIGINS Then lWriter.AddOptions(options, "Options")


        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
