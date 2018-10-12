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

Imports TradeWright.IBAPI.ApiException

''' <summary>
''' A TwsExecutionCondition is met whenever a trade occurs on a certain product at the given exchange.
''' </summary>
Public Class ExecutionCondition
    Inherits OrderCondition

    Const Header As String = "trade occurs for "
    Const SymbolSuffix As String = " symbol on "
    Const ExchangeSuffix As String = " exchange for "
    Const SecTypeSuffix As String = " security type"

    Public Property Exchange As String
    Public Property SecType As String
    Public Property Symbol As String

    Public Overrides Function ToString() As String
        Return Header & Symbol & SymbolSuffix & Exchange & ExchangeSuffix & SecType & SecTypeSuffix
    End Function

    Protected Overrides Function TryParse(cond As String) As Boolean
        If Not cond.StartsWith(Header) Then Return False

        Try
            Dim parser = New StringSuffixParser(cond.Replace(Header, ""))

            Symbol = parser.GetNextSuffixedValue(SymbolSuffix)
            Exchange = parser.GetNextSuffixedValue(ExchangeSuffix)
            SecType = parser.GetNextSuffixedValue(SecTypeSuffix)

            If Not String.IsNullOrWhiteSpace(parser.Rest) Then Return MyBase.TryParse(parser.Rest)
        Catch
            Return False
        End Try

        Return True
    End Function

    Friend Overrides Async Sub Deserialize(reader As MessageReader)
        MyBase.Deserialize(reader)

        SecType = Await reader.GetStringAsync("SecType")
        Exchange = Await reader.GetStringAsync("Exchange")
        Symbol = Await reader.GetStringAsync("Symbol")
    End Sub

    Friend Overrides Sub Serialize(writer As MessageGenerator)
        MyBase.Serialize(writer)

        writer.AddElement(SecType, "Sectype")
        writer.AddElement(Exchange, "Exchange")
        writer.AddElement(Symbol, "Symbol")
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot ExecutionCondition Then Return False

        Dim other = DirectCast(obj, ExecutionCondition)

        Return MyBase.Equals(obj) And
                Exchange.Equals(other.Exchange) And
                SecType.Equals(other.SecType) And
                Symbol.Equals(other.Symbol)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode() + Exchange.GetHashCode() + SecType.GetHashCode() + Symbol.GetHashCode()
    End Function


End Class
