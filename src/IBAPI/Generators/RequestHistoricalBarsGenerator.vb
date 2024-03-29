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

Friend Class RequestHistoricalBarsGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(pRequestId As Integer, pRequest As HistoricalBarsRequest, useRTH As Boolean, keepUpToDate As Boolean, chartOptions As List(Of TagValue))

    Private Const ModuleName As String = NameOf(RequestHistoricalBarsGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestHistoricalBars)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestHistoricalBars
        End Get
    End Property

    Private Sub requestHistoricalBars(pRequestId As Integer, pRequest As HistoricalBarsRequest, useRTH As Boolean, keepUpToDate As Boolean, options As List(Of TagValue))
        Const ProcName As String = NameOf(requestHistoricalBars)
        Const VERSION As Integer = 6

        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")

        If ServerVersion < ApiServerVersion.HISTORICAL_SCHEDULE And
            "SCHEDULE".Equals(pRequest.WhatToShow, StringComparison.InvariantCultureIgnoreCase) Then Throw New ApiApplicationException("Historical schedule requests not supported")

        Dim lTwsId = IdManager.GetTwsId(pRequestId, IdType.HistoricalData)
        IBAPI.EventLogger.Log($"Requesting historical data for: {pRequest.Contract.LocalSymbol.ToUpper()}; id={lTwsId}; barsize={pRequest.BarSizeSetting}; endTime={pRequest.EndDateTime}; duration={pRequest.Duration}", ModuleName, ProcName)

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.RequestHistoricalBars)
        If ServerVersion < ApiServerVersion.SYNT_REALTIME_BARS Then lWriter.AddInteger(VERSION, "Version")
        lWriter.AddInteger(lTwsId, "Request id")
        lWriter.AddContract(pRequest.Contract, "Contract")

        lWriter.AddInteger(If(IBAPI.IsContractExpirable(pRequest.Contract), 1, 0), "Include expired") ' can't include expired for non-expiring contracts

        lWriter.AddString(If(pRequest.EndDateTime.HasValue,
                              pRequest.EndDateTime.Value.ToString("yyyyMMdd HH:mm:ss") & If(String.IsNullOrEmpty(pRequest.TimeZone), "", " " & pRequest.TimeZone), ""),
                              "End date")

        lWriter.AddString(pRequest.BarSizeSetting, "Bar Size")

        lWriter.AddString(pRequest.Duration, "Duration")
        lWriter.AddBoolean(useRTH, "Use RTH")
        lWriter.AddString(pRequest.WhatToShow, "What to show")

        lWriter.AddInteger(HistoricalDataDateFormat.DateFormatString, "Date format")

        Dim lComboLeg As ComboLeg
        Dim i As Integer
        If pRequest.Contract.SecurityType = SecurityType.Combo Then
            lWriter.AddInteger(pRequest.Contract.ComboLegs.Count, "Combo legs count")
            For Each lComboLeg In pRequest.Contract.ComboLegs
                With lComboLeg
                    i += 1
                    lWriter.AddInteger(.contractId,"ContractId" & i)
                    lWriter.AddInteger(.Ratio, "Ratio" & i)
                    lWriter.AddString(IBAPI.OrderActions.ToInternalString(.Action), "Action" & i)
                    lWriter.AddString(.Exchange, "Exchange" & i)
                End With
            Next
        End If

        If ServerVersion >= ApiServerVersion.SYNT_REALTIME_BARS Then lWriter.AddBoolean(keepUpToDate, "KeepUpToDate")

        lWriter.AddOptions(options, "Options")

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
