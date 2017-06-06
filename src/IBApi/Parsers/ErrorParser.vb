#Region "License"

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

Imports System.Threading.Tasks

Friend NotInheritable Class ErrorParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(ErrorParser)

    Private mLostConnectionToIb As Boolean

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Const ProcName = "ParseAsync"

        Dim id = Await _Reader.GetIntAsync("Id")
        Debug.Print("Error id: " & id)

        Dim lErrorCode = Await _Reader.GetIntAsync("Error code")
        Debug.Print("Error code: " & lErrorCode)

        Dim lErrorMsg = Await _Reader.GetStringAsync("Error msg")
        Debug.Print("Error msg: " & lErrorMsg)

        LogSocketInputMessage(ModuleName, ProcName, True)

        Select Case IdManager.GetIdType(id)
            Case IdType.ContractData
                _EventConsumers.ContractDetailsConsumer?.NotifyContractError(New RequestErrorEventArgs(timestamp, IdManager.GetCallerId(id, IdType.ContractData), lErrorCode, lErrorMsg))
                Return True
            Case IdType.MarketData
                _EventConsumers.MarketDataConsumer?.NotifyMarketDataError(New RequestErrorEventArgs(timestamp, IdManager.GetCallerId(id, IdType.MarketData), lErrorCode, lErrorMsg))
                Return True
            Case IdType.MarketDepth
                _EventConsumers.MarketDepthConsumer?.NotifyMarketDepthError(New RequestErrorEventArgs(timestamp, IdManager.GetCallerId(id, IdType.MarketDepth), lErrorCode, lErrorMsg))
                Return True
            Case IdType.HistoricalData
                If lErrorCode = 165 Then
                    EventLogger.Log("Connected to IB Historical Market Data Service - {lErrorMsg}", ModuleName, ProcName)
                Else
                    _EventConsumers.HistDataConsumer?.NotifyHistoricalDataError(New RequestErrorEventArgs(timestamp, IdManager.GetCallerId(id, IdType.HistoricalData), lErrorCode, lErrorMsg))
                End If
                Return True
            Case IdType.Order
                If mLostConnectionToIb And lErrorCode = 200 Then Return True
                _EventConsumers.OrderInfoConsumer?.NotifyOrderError(New OrderErrorEventArgs(timestamp, id, lErrorCode, lErrorMsg))
                Return True
        End Select

        Select Case lErrorCode
            Case 316
                _EventConsumers.MarketDepthConsumer?.ResetMarketDepth(New MarketDepthRestEventArgs(timestamp, reEstablish:=True))
            Case 317
                _EventConsumers.MarketDepthConsumer?.ResetMarketDepth(New MarketDepthRestEventArgs(timestamp, reEstablish:=False))
            Case 321 ' invalid Request
                EventLogger.Log($"Error ({lErrorCode}; id={id}) from Tws: {lErrorMsg}", ModuleName, ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiError(New ApiErrorEventArgs(timestamp, lErrorCode, lErrorMsg))
            Case 326 ' ClientID already in use

            Case 1100, 2110
                ' connectivity between Tws and IB has been lost

                mLostConnectionToIb = True
                _EventConsumers.ConnectionStatusConsumer?.NotifyIBServerConnectionStateChange(New IBServerConnectionStateChangeEventArgs(timestamp, IBServerConnectionState.Disconnected, False, lErrorMsg))
                EventLogger.Log("Connection to IB has been lost", ModuleName, ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(New ApiEventEventArgs(timestamp, lErrorCode, lErrorMsg))

            Case 1101
                ' connectivity between Tws and IB has been restored, but data has been
                ' lost, so need to reestablish market data and market depth requests

                mLostConnectionToIb = False

                _EventConsumers.MarketDepthConsumer?.ResetMarketDepth(New MarketDepthRestEventArgs(timestamp, True))

                _EventConsumers.ConnectionStatusConsumer?.NotifyIBServerConnectionStateChange(New IBServerConnectionStateChangeEventArgs(timestamp, IBServerConnectionState.Connected, True, lErrorMsg))

                EventLogger.Log("Connection to IB recovered: market data re-established", ModuleName, ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(New ApiEventEventArgs(timestamp, lErrorCode, lErrorMsg))

            Case 1102
                ' connectivity between Tws and IB has been restored without loss of data
                ' Now need to reassociate Order ids with Tws

                mLostConnectionToIb = False

                _EventConsumers.ConnectionStatusConsumer?.NotifyIBServerConnectionStateChange(New IBServerConnectionStateChangeEventArgs(timestamp, IBServerConnectionState.Connected, False, lErrorMsg))

                EventLogger.Log("Connection to IB recovered: no loss of data", ModuleName, ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(New ApiEventEventArgs(timestamp, lErrorCode, lErrorMsg))

            Case 2103, 2104, 2105, 2106, 2107, 2108
                EventLogger.Log(lErrorMsg, ModuleName, ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiEvent(New ApiEventEventArgs(timestamp, lErrorCode, lErrorMsg))
            Case Else
                EventLogger.Log($"Error ({lErrorCode}; id={id}) from Tws: {lErrorMsg}", ModuleName, ProcName)
                _EventConsumers.ErrorAndNotificationConsumer?.NotifyApiError(New ApiErrorEventArgs(timestamp, lErrorCode, lErrorMsg))
        End Select
        Return True
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.Error
        End Get
    End Property

End Class
