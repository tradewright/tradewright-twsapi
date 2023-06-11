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

Friend Class RequestFundamentalDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(pReqId As Integer, pContract As Contract, pReportType As String, options As List(Of TagValue))

    Private Const ModuleName As String = NameOf(RequestFundamentalDataGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestFundamentalData)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestFundamentalData
        End Get
    End Property

    Private Sub requestFundamentalData(pReqId As Integer, pContract As Contract, pReportType As String, options As List(Of TagValue))
        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")

        Const VERSION As Integer = 3

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.RequestFundamentalData)
        lWriter.AddInteger(VERSION, "Version")
        lWriter.AddInteger(pReqId, "ReqId")

        lWriter.AddInteger(pContract.ContractId, "ContractId")
        lWriter.AddString(pContract.Symbol?.ToUpper(), "Symbol")
        lWriter.AddString(IBAPI.SecurityTypes.ToInternalString(pContract.SecurityType), "Sectype")
        lWriter.AddString(pContract.Exchange, "Exchange")
        lWriter.AddString(pContract.PrimaryExchange, "PrimaryExch")
        lWriter.AddString(pContract.CurrencyCode, "Currency")
        lWriter.AddString(pContract.LocalSymbol?.ToUpper(), "LocalSymbol")
        lWriter.AddString(pReportType, "ReportType")
        lWriter.AddInteger(If(options Is Nothing, 0, options.Count), "Options Count")
        lWriter.AddOptions(options, "Options")

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
