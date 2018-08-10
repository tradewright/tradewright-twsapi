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

Friend NotInheritable Class ScannerDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(ScannerDataParser)

       Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("Request Id")
        Dim numberOfElements = Await _Reader.GetIntAsync("Number of elements")

        For i = 0 To numberOfElements - 1
            Dim rank = Await _Reader.GetIntAsync("Rank")
            Dim contract = New Contract
            Dim contractDetails = New ContractDetails
            contractDetails.Summary = contract

            If (pVersion >= 3) Then contract.ConId = Await _Reader.GetIntAsync("ConId")

            contract.Symbol = Await _Reader.GetStringAsync("Symbol")
            contract.SecType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))
            contract.Expiry = Await _Reader.GetStringAsync("Expiry")
            contract.Strike = Await _Reader.GetDoubleAsync("Strike")
            contract.OptRight = IBAPI.OptionRights.Parse(Await _Reader.GetStringAsync("Right"))
            contract.Exchange = Await _Reader.GetStringAsync("Exchange")
            contract.CurrencyCode = Await _Reader.GetStringAsync("Currency")
            contract.LocalSymbol = Await _Reader.GetStringAsync("Local Symbol")

            contractDetails.MarketName = Await _Reader.GetStringAsync("Market name")
            contract.TradingClass = Await _Reader.GetStringAsync("TradingClass")

            Dim distance = Await _Reader.GetStringAsync("Distance")
            Dim benchmark = Await _Reader.GetStringAsync("Benchmark")
            Dim projection = Await _Reader.GetStringAsync("Projection")
            Dim legs = If(pVersion >= 2, Await _Reader.GetStringAsync("Legs Str"), "")

            _EventConsumers.ScannerDataConsumer?.NotifyScannerData(New ScannerDataEventArgs(timestamp, requestId, rank, contractDetails, distance, benchmark, projection, legs))
        Next

        LogSocketInputMessage(ModuleName,"ParseAsync")

        Try
        _EventConsumers.ScannerDataConsumer?.EndScannerData(New RequestEndEventArgs(timestamp, requestId))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("EndScannerData", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.ScannerData
        End Get
    End Property

End Class
