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

Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Friend NotInheritable Class ErrorParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(ErrorParser)

    Private mLostConnectionToIb As Boolean

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Const ProcName = NameOf(ParseAsync)

        Dim id = Await _Reader.GetIntAsync("Id")
        Dim errorCode = Await _Reader.GetIntAsync("Error code")
        Dim errorMsg = Regex.Unescape(Await _Reader.GetStringAsync("Error msg"))
        Dim advancedOrderRejectJson = ""
        If ServerVersion >= ApiServerVersion.ADVANCED_ORDER_REJECT Then
            advancedOrderRejectJson = Regex.Unescape(Await _Reader.GetStringAsync("Advanced order reject"))
        End If

        LogSocketInputMessage(ModuleName, ProcName, True)

        If handleErrorForIdType(timestamp, ProcName, id, errorCode, errorMsg, advancedOrderRejectJson) Then Return True
        handleGenericError(timestamp, ProcName, id, errorCode, errorMsg)

        Return True
    End Function

    Private Sub handleGenericError(timestamp As Date, ProcName As String, id As Integer, errorCode As Integer, errorMsg As String)
        Select Case errorCode
            Case 316
                _EventConsumers.MarketDepthConsumer?.NotifyMarketDepthReset(
                                New MarketDepthRestEventArgs(
                                                timestamp,
                                                reEstablish:=True))
            Case 317
                _EventConsumers.MarketDepthConsumer?.NotifyMarketDepthReset(
                                New MarketDepthRestEventArgs(
                                                timestamp,
                                                reEstablish:=False))
            Case 320, 321 ' invalid Request
                IBAPI.EventLogger.Log(
                                $"Error ({errorCode}; id={id}) from Tws: {errorMsg}",
                                ModuleName,
                                ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiError(
                                New ApiErrorEventArgs(
                                                timestamp,
                                                errorCode,
                                                errorMsg))
            Case 326 ' ClientID already in use

            Case 1100, 2110
                ' connectivity between Tws and IB has been lost

                mLostConnectionToIb = True
                _EventConsumers.ConnectionStatusConsumer?.NotifyIBServerConnectionStateChange(
                                New IBServerConnectionStateChangeEventArgs(
                                                timestamp,
                                                IBServerConnectionState.Disconnected,
                                                False,
                                                errorMsg))
                IBAPI.EventLogger.Log(
                                $"{errorCode} Connection to IB has been lost",
                                ModuleName,
                                ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(
                                New ApiEventEventArgs(timestamp, errorCode, errorMsg))

            Case 1101
                ' connectivity between Tws and IB has been restored, but data has been
                ' lost, so need to reestablish market data and market depth requests

                mLostConnectionToIb = False

                _EventConsumers.MarketDepthConsumer?.NotifyMarketDepthReset(
                                New MarketDepthRestEventArgs(timestamp, True))

                _EventConsumers.ConnectionStatusConsumer?.NotifyIBServerConnectionStateChange(
                                New IBServerConnectionStateChangeEventArgs(
                                                timestamp,
                                                IBServerConnectionState.Connected,
                                                True,
                                                errorMsg))

                IBAPI.EventLogger.Log(
                                $"{errorCode} Connection to IB recovered: market data must be re-established",
                                ModuleName,
                                ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(
                                New ApiEventEventArgs(timestamp, errorCode, errorMsg))

            Case 1102
                ' connectivity between Tws and IB has been restored without loss of data

                mLostConnectionToIb = False

                _EventConsumers.ConnectionStatusConsumer?.NotifyIBServerConnectionStateChange(
                                New IBServerConnectionStateChangeEventArgs(
                                                timestamp,
                                                IBServerConnectionState.Connected,
                                                False,
                                                errorMsg))

                IBAPI.EventLogger.Log(
                                $"{errorCode} Connection to IB recovered: no loss of data",
                                ModuleName,
                                ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(
                                New ApiEventEventArgs(timestamp, errorCode, errorMsg))

            Case 2103, 2104, 2105, 2106, 2107, 2108
                IBAPI.EventLogger.Log($"{errorCode} {errorMsg}", ModuleName, ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(
                                New ApiEventEventArgs(timestamp, errorCode, errorMsg))
            Case Else
                IBAPI.EventLogger.Log(
                                $"Error ({errorCode}; id={id}) from Tws: {errorMsg}",
                                ModuleName,
                                ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiError(
                                New ApiErrorEventArgs(timestamp, errorCode, errorMsg))
        End Select
    End Sub

    Private Function handleErrorForIdType(timestamp As Date, ProcName As String, id As Integer, errorCode As Integer, errorMsg As String, advancedOrderRejectJson As String) As Boolean
        Select Case IdManager.GetIdType(id)
            Case IdType.ContractData
                _EventConsumers.ContractDetailsConsumer?.NotifyContractError(
                                New RequestErrorEventArgs(
                                                timestamp,
                                                IdManager.GetCallerId(
                                                                id,
                                                                IdType.ContractData),
                                                errorCode,
                                                errorMsg))
                Return True
            Case IdType.MarketData
                _EventConsumers.MarketDataConsumer?.NotifyMarketDataError(
                                New RequestErrorEventArgs(
                                                timestamp,
                                                IdManager.GetCallerId(
                                                                id,
                                                                IdType.MarketData),
                                                errorCode,
                                                errorMsg))
                Return True
            Case IdType.MarketDepth
                _EventConsumers.MarketDepthConsumer?.NotifyMarketDepthError(
                                New RequestErrorEventArgs(
                                                timestamp,
                                                IdManager.GetCallerId(
                                                                id,
                                                                IdType.MarketDepth),
                                                errorCode,
                                                errorMsg))
                Return True
            Case IdType.HistoricalData
                If errorCode = 165 Then
                    IBAPI.EventLogger.Log(
                                    $"{errorCode} Connected to IB Historical Market Data Service - {errorMsg}",
                                    ModuleName,
                                    ProcName)
                Else
                    _EventConsumers.HistoricalDataConsumer?.NotifyHistoricalBarError(
                                    New RequestErrorEventArgs(
                                                    timestamp,
                                                    IdManager.GetCallerId(
                                                        id,
                                                        IdType.HistoricalData),
                                                    errorCode,
                                                    errorMsg))
                End If
                Return True
            Case IdType.Order
                If mLostConnectionToIb And errorCode = 200 Then Return True
                _EventConsumers.OrderInfoConsumer?.NotifyOrderError(
                                New OrderErrorEventArgs(
                                                timestamp,
                                                id,
                                                errorCode,
                                                errorMsg,
                                                advancedOrderRejectJson))
                Return True
        End Select
        Return False
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.Error
        End Get
    End Property

End Class
