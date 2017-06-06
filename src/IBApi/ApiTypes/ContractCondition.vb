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

Imports TradeWright.IBAPI.ApiException

Public MustInherit Class ContractCondition
    Inherits OperatorCondition

    Public Property ConId As Integer
    Public Property Exchange As String

    Const Delimiter As String = " of "

    Public Property ContractResolver As Func(Of Integer, String, String)

    Public Sub New()
        ContractResolver = Function(cid, exch) cid & "(" & exch & ")"
    End Sub

    Public Overrides Function ToString() As String
        Return Type & Delimiter & ContractResolver(ConId, Exchange) & MyBase.ToString()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot ContractCondition Then Return False
        Dim other = DirectCast(obj, ContractCondition)

        Return MyBase.Equals(obj) And ConId = other.ConId And Exchange.Equals(other.Exchange)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode() + ConId.GetHashCode() + Exchange.GetHashCode()
    End Function

    Protected Overrides Function TryParse(cond As String) As Boolean
        Try
            If cond.Substring(0, cond.IndexOf(Delimiter)) <> Type.ToString() Then Return False

            cond = cond.Substring(cond.IndexOf(Delimiter) + Delimiter.Length)
            Dim cId As Integer

            If Not Integer.TryParse(cond.Substring(0, cond.IndexOf("(")), cId) Then Return False

            ConId = cId
            cond = cond.Substring(cond.IndexOf("(") + 1)
            Exchange = cond.Substring(0, cond.IndexOf(")"))
            cond = cond.Substring(cond.IndexOf(")") + 1)

            Return MyBase.TryParse(cond)
        Catch
            Return False
        End Try

        Return True
    End Function

    Friend Overrides Async Sub Deserialize(reader As MessageReader)
        MyBase.Deserialize(reader)

        ConId = Await reader.GetIntAsync("ConId")
        Exchange = Await reader.GetStringAsync("Exchange")
    End Sub

    Friend Overrides Sub Serialize(writer As MessageGenerator)
        MyBase.Serialize(writer)
        writer.AddElement(ConId, "ConId")
        writer.AddElement(Exchange, "Exchange")
    End Sub

End Class
