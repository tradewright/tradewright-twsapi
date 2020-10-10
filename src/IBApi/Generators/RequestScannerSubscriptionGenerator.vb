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

Friend Class RequestScannerSubscriptionGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(pTickerId As Integer, pSubscription As ScannerSubscription, options As List(Of TagValue), filterOptions As List(Of TagValue))

    Private Const ModuleName As String = NameOf(RequestScannerSubscriptionGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestScannerSubscription)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestScannerSubscription
        End Get
    End Property

    Private Sub requestScannerSubscription(requestId As Integer, pSubscription As ScannerSubscription, options As List(Of TagValue), filterOptions As List(Of TagValue))
        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If filterOptions IsNot Nothing And ServerVersion < ApiServerVersion.SCANNER_GENERIC_OPTS Then Throw New InvalidOperationException("scanner subscription generic filter options not supported")

        Const VERSION As Integer = 4

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.RequestScannerSubscription)
        If ServerVersion < ApiServerVersion.SCANNER_GENERIC_OPTS Then lWriter.AddInteger(VERSION, "Version")
        lWriter.AddInteger(requestId, "Request Id")
        lWriter.AddNullableInteger(pSubscription.NumberOfRows, "NumberOfRows")
        lWriter.AddString(pSubscription.Instrument, "Instrument")
        lWriter.AddString(pSubscription.LocationCode, "LocationCode")
        lWriter.AddString(pSubscription.ScanCode, "ScanCode")
        lWriter.AddNullableDouble(pSubscription.AbovePrice, "AbovePrice")
        lWriter.AddNullableDouble(pSubscription.BelowPrice, "BelowPrice")
        lWriter.AddNullableInteger(pSubscription.AboveVolume, "AboveVolume")
        lWriter.AddNullableDouble(pSubscription.MarketCapAbove, "MarketCapAbove")
        lWriter.AddNullableDouble(pSubscription.MarketCapBelow, "MarketCapBelow")
        lWriter.AddString(pSubscription.MoodyRatingAbove, "MoodyRatingAbove")
        lWriter.AddString(pSubscription.MoodyRatingBelow, "MoodyRatingBelow")
        lWriter.AddString(pSubscription.SpRatingAbove, "SpRatingAbove")
        lWriter.AddString(pSubscription.SpRatingBelow, "SpRatingBelow")
        lWriter.AddString(pSubscription.MaturityDateAbove, "MaturityDateAbove")
        lWriter.AddString(pSubscription.MaturityDateBelow, "MaturityDateBelow")
        lWriter.AddNullableDouble(pSubscription.CouponRateAbove, "CouponRateAbove")
        lWriter.AddNullableDouble(pSubscription.CouponRateBelow, "CouponRateBelow")
        lWriter.AddBoolean(pSubscription.ExcludeConvertible, "ExcludeConvertible")
        lWriter.AddNullableInteger(pSubscription.AverageOptionVolumeAbove, "AverageOptionVolumeAbove")
        lWriter.AddString(pSubscription.ScannerSettingPairs, "ScannerSettingPairs")
        lWriter.AddString(pSubscription.StockTypeFilter, "StockTypeFilter")
        If ServerVersion >= ApiServerVersion.SCANNER_GENERIC_OPTS Then lWriter.AddOptions(filterOptions, "FilterOptions")
        lWriter.AddOptions(options, "Options")
        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
