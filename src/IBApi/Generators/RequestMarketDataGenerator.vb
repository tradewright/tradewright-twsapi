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

Imports System.Collections.Generic

Friend Class RequestMarketDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(pTickerId As Integer, pContract As Contract, pGenericTicks As String, pSnapshot As Boolean, regulatorySnapshot As Boolean, options As List(Of TagValue))

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf RequestMarketData)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestMarketData
        End Get
    End Property

    Private Sub RequestMarketData(pTickerId As Integer, pContract As Contract, pGenericTicks As String, pSnapshot As Boolean, regulatorySnapshot As Boolean, options As List(Of TagValue))
        If mConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")

        Const VERSION As Integer = 11

        EventLogger.Log($"Requesting market data for: {pContract.ToString()}", NameOf(RequestMarketDataGenerator), NameOf(RequestMarketData))

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.RequestMarketData)
        lWriter.AddElement(VERSION, "Version")
        lWriter.AddElement(IdManager.GetTwsId(pTickerId, IdType.MarketData), "Ticker id")
        Dim comboLeg As ComboLeg
        Dim i As Integer
        With pContract
            lWriter.AddElement(.ConId, "Con id")
            lWriter.AddElement(.Symbol, "Symbol")
            lWriter.AddElement(SecurityTypes.ToInternalString(.SecType), "Sec type")
            lWriter.AddElement(.Expiry, "Expiry")
            lWriter.AddElement(.Strike, "Strike")
            lWriter.AddElement(OptionRights.ToInternalString(.OptRight), "Right")
            lWriter.AddElement(If(.Multiplier = 1, "", CStr(.Multiplier)), "Multiplier")
            lWriter.AddElement(.Exchange, "Exchange")
            lWriter.AddElement(.PrimaryExch, "Primary Exchange")
            lWriter.AddElement(.CurrencyCode, "Currency")
            lWriter.AddElement(UCase(.LocalSymbol), "Local Symbol")
            lWriter.AddElement(.TradingClass, "Trading Class")

            ' Add combo legs for BAG requests
            If .SecType = SecurityType.Combo Then
                lWriter.AddElement(.ComboLegs.Count, "Combolegs count")
                For Each comboLeg In .ComboLegs
                    With comboLeg
                        i = i + 1
                        lWriter.AddElement(.ConId, "ConId" & i)
                        lWriter.AddElement(.Ratio, "Ratio" & i)
                        lWriter.AddElement(OrderActions.ToInternalString(.Action), "Action" & i)
                        lWriter.AddElement(.Exchange, "Exchange" & i)
                    End With
                Next comboLeg
            End If

            If .UnderComp?.ConId <> 0 Then
                lWriter.AddElement(True, "Under comp")
                lWriter.AddElement(.UnderComp.ConId, "Under comp conid")
                lWriter.AddElement(.UnderComp.Delta, "Under comp delta")
                lWriter.AddElement(.UnderComp.Price, "Under comp price")
            Else
                lWriter.AddElement(False, "Under comp")
            End If

            lWriter.AddElement(pGenericTicks, "Generic tick list")

            lWriter.AddElement(pSnapshot, "Snapshot")

            If ServerVersion >= ApiServerVersion.SMART_COMPONENTS Then lWriter.AddElement(regulatorySnapshot, "Regulatory Snapshot")

            lWriter.AddElement(If(options Is Nothing, "", String.Join(Of TagValue)(";", options) & ";"), "Options")

            SendMessage(lWriter, NameOf(RequestMarketDataGenerator), NameOf(RequestMarketData))
        End With
    End Sub

End Class