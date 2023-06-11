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

Imports System.Globalization

Public Class PriceCondition
    Inherits ContractCondition

    Public Property Price As Double

    Public Property TriggerMethod As TriggerMethod

    Protected Overrides Property Value As String
        Get
            Return Price.ToString(NumberFormatInfo.InvariantInfo)
        End Get
        Set
            Price = Double.Parse(Value, NumberFormatInfo.InvariantInfo)
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return IBAPI.TriggerMethods.ToExternalString(TriggerMethod) & " " & MyBase.ToString()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot PriceCondition Then Return False
        Dim other = DirectCast(obj, PriceCondition)

        Return MyBase.Equals(obj) And TriggerMethod = other.TriggerMethod
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode() + TriggerMethod.GetHashCode()
    End Function

    Friend Overrides Async Sub Deserialize(reader As MessageReader)
        MyBase.Deserialize(reader)
        TriggerMethod = CType(Await reader.GetIntAsync("Trigger Method"), TriggerMethod)
    End Sub

    Friend Overrides Sub Serialize(writer As MessageGenerator)
        MyBase.Serialize(writer)
        writer.AddInteger(TriggerMethod, "TriggerMethod")
    End Sub

    Protected Overrides Function TryParse(cond As String) As Boolean
        Dim nextIndex As Integer
        If IBAPI.TriggerMethods.TryParseFrom(cond, TriggerMethod, nextIndex) Then
            cond = cond.Substring(nextIndex)
            Return MyBase.TryParse(cond)
        End If

        Return False
    End Function

End Class

