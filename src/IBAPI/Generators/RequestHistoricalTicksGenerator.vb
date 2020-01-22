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

Friend Class RequestHistoricalTickDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, request As HistoricalTicksRequest, useRTH As Boolean, ignoreSize As Boolean, options As List(Of TagValue))

    Private Const ModuleName As String = NameOf(requestHistoricalTickData)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestHistoricalTickData)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestHistoricalTickData
        End Get
    End Property

    Private Sub requestHistoricalTickData(requestId As Integer, request As HistoricalTicksRequest, Optional useRTH As Boolean = False, Optional ignoreSize As Boolean = False, Optional options As List(Of TagValue) = Nothing)


        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.HISTORICAL_TICKS Then Throw New InvalidOperationException("Historical tick requests not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request Id")
        lWriter.AddElement(request.Contract, "Contract")
        lWriter.AddElement(If(IBAPI.IsContractExpirable(request.Contract), 1, 0), "Include expired") ' can't include expired for non-expiring contracts
        lWriter.AddElement(If(request.StartDateTime.HasValue,
                                request.StartDateTime.Value.ToString("yyyyMMdd HH:mm:ss") & If(String.IsNullOrEmpty(request.StartTimezone), "", " " & request.StartTimezone),
                                ""),
                           "StartDateTime")
        lWriter.AddElement(If(request.EndDateTime.HasValue,
                                request.EndDateTime.Value.ToString("yyyyMMdd HH:mm:ss") & If(String.IsNullOrEmpty(request.EndTimezone), "", " " & request.EndTimezone),
                                ""),
                           "EndDateTime")
        lWriter.AddElement(request.NumberOfTicks, "NumberOfTicks")
        lWriter.AddElement(request.WhatToShow, "WhatToShow")
        lWriter.AddElement(useRTH, "UseRTH")
        lWriter.AddElement(ignoreSize, "IgnoreSize")
        lWriter.AddElement(options, "Options")

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
