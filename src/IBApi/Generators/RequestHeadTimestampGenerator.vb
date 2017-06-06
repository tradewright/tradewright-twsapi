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

Friend Class RequestHeadTimestampGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, contract As Contract, whatToShow As String, useRTH As Boolean)

    Private Const ModuleName As String = NameOf(RequestHeadTimestampGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf RequestHeadTimestamp)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestHeadTimestamp
        End Get
    End Property

    Private Sub RequestHeadTimestamp(requestId As Integer, contract As Contract, whatToShow As String, useRTH As Boolean)
        Const ProcName As String = NameOf(RequestHeadTimestamp)

        If mConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.REQ_HEAD_TIMESTAMP Then Throw New InvalidOperationException("Head timestamp requests not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request ID")
        lWriter.AddElement(contract.ConId, "Conid")
        lWriter.AddElement(contract.Symbol, "Symbol")
        lWriter.AddElement(SecurityTypes.ToInternalString(contract.SecType), "Sectype")
        lWriter.AddElement(contract.Expiry, "Expiry")
        lWriter.AddElement(contract.Strike, "Strike")
        lWriter.AddElement(OptionRights.ToInternalString(contract.OptRight), "Right")
        lWriter.AddElement(If(contract.Multiplier = 1, "", CStr(contract.Multiplier)), "Multiplier")
        lWriter.AddElement(contract.Exchange, "Exchange")
        lWriter.AddElement(contract.PrimaryExch, "Primary Exchg")
        lWriter.AddElement(contract.CurrencyCode, "Currency")

        Dim lExpired = IBAPI.IsContractExpired(contract)
        lWriter.AddElement(If(lExpired, "", UCase(contract.LocalSymbol)), "Local Symbol")
        lWriter.AddElement(contract.TradingClass, "Trading Class")
        lWriter.AddElement(If(lExpired, 1, 0), "Include expired") ' can't include expired for non-expiring contracts

        lWriter.AddElement(useRTH, "Use RTH")
        lWriter.AddElement(whatToShow, "What to Show")
        lWriter.AddElement(HistoricalDataDateFormat.DateFormatString, "Date format")

        SendMessage(lWriter, ModuleName, ProcName)
    End Sub

End Class
