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
Imports System.Threading.Tasks

Friend NotInheritable Class SymbolSamplesParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(SymbolSamplesParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("Request Id")
        Dim contractDescriptions = New List(Of ContractDescription)
        Dim nContractDescriptions = Await _Reader.GetIntAsync("Contract Descriptions Count")

        For i = 1 To nContractDescriptions
            ' read contract fields
            Dim contract = New Contract()
            contract.ConId = Await _Reader.GetIntAsync("Conid")
            contract.Symbol = Await _Reader.GetStringAsync("Symbol")
            contract.SecType = IBAPI.SecurityTypes.Parse(Await _Reader.GetStringAsync("Sec type"))
            contract.PrimaryExch = Await _Reader.GetStringAsync("Primary exch")
                contract.CurrencyCode = Await _Reader.GetStringAsync("Currency")

                ' read derivative sec types list
                dim derivativeSecTypes = New List(Of String)
            Dim nDerivativeSecTypes = Await _Reader.GetIntAsync("Derivative Sectypes Count")
            For j=1 to nDerivativeSecTypes
                derivativeSecTypes.Add(Await _Reader.GetStringAsync("Derivative Sectype"))
            Next

            Dim contractDescription = New ContractDescription(contract, derivativeSecTypes)
            contractDescriptions.Add(contractDescription)
        Next

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
        _EventConsumers.ContractDetailsConsumer?.NotifySymbolSamples(New SymbolSamplesEventArgs(timestamp, requestId, contractDescriptions))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifySymbolSamples", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.SymbolSamples
        End Get
    End Property

End Class
