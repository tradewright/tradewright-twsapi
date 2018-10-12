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

Public MustInherit Class OperatorCondition
    Inherits OrderCondition

    Protected MustOverride Property Value As String
    Public Property IsMore As Boolean

    Const Header As String = " is "

    Public Overrides Function ToString() As String
        Return Header & If(IsMore, ">= ", "<= ") & Value
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot OperatorCondition Then Return False

        Dim other = DirectCast(obj, OperatorCondition)
        Return MyBase.Equals(obj) And
                Value.Equals(other.Value) And
                IsMore = other.IsMore
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode() + Value.GetHashCode() + IsMore.GetHashCode()
    End Function

    Protected Overrides Function TryParse(cond As String) As Boolean
        If Not cond.StartsWith(Header) Then Return False

        Try
            cond = cond.Replace(Header, "")

            If (Not cond.StartsWith(">=")) And (Not cond.StartsWith("<=")) Then Return False

            IsMore = cond.StartsWith(">=")

            If MyBase.TryParse(cond.Substring(cond.LastIndexOf(" "))) Then cond = cond.Substring(0, cond.LastIndexOf(" "))

            Value = cond.Substring(3)
        Catch
            Return False
        End Try

        Return True
    End Function

    Friend Overrides Async Sub Deserialize(reader As MessageReader)
        MyBase.Deserialize(reader)

        IsMore = Await reader.GetBoolFromIntAsync("IsMore")
        Value = Await reader.GetStringAsync("Value")
    End Sub

    Friend Overrides Sub Serialize(writer As MessageGenerator)
        MyBase.Serialize(writer)
        writer.AddElement(IsMore, "IsMore")
        writer.AddElement(Value, "Value")
    End Sub

End Class
