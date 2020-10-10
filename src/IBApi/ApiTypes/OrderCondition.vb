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

Imports System.Linq
Imports TradeWright.IBAPI.ApiException

Public MustInherit Class OrderCondition

    Public Property Type As OrderConditionType
    Public IsConjunctionConnection As Boolean

    Public Shared Function Create(type As OrderConditionType) As OrderCondition
        Select Case type
            Case OrderConditionType.Execution
                Return New ExecutionCondition() With {.Type = type}
            Case OrderConditionType.Margin
                Return New MarginCondition() With {.Type = type}
            Case OrderConditionType.PercentChange
                Return New PercentChangeCondition() With {.Type = type}
            Case OrderConditionType.Price
                Return New PriceCondition() With {.Type = type}
            Case OrderConditionType.Time
                Return New TimeCondition() With {.Type = type}
            Case OrderConditionType.Volume
                Return New VolumeCondition() With {.Type = type}
        End Select

        Return Nothing
    End Function

    Friend Overridable Sub Serialize(writer As MessageGenerator)
        writer.AddString(If(IsConjunctionConnection, "a", "o"), "AndOr")
    End Sub

    Friend Overridable Async Sub Deserialize(reader As MessageReader)
        IsConjunctionConnection = (Await reader.GetStringAsync("AndOr")) = "a"
    End Sub

    Protected Overridable Function TryParse(cond As String) As Boolean
        IsConjunctionConnection = (cond = " and")

        Return IsConjunctionConnection Or (cond = " or")
    End Function

    Public Shared Function Parse(cond As String) As OrderCondition
        Dim conditions = From t In [Enum].GetValues(GetType(OrderConditionType)).OfType(Of OrderConditionType)()
                         Select Create(t)
        Return conditions.FirstOrDefault(Function(t) t.TryParse(cond))
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot OrderCondition Then Return False
        Dim other = DirectCast(obj, OrderCondition)

        Return IsConjunctionConnection = other.IsConjunctionConnection And Me.GetType() Is other.GetType()
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return IsConjunctionConnection.GetHashCode() + Type.GetHashCode()
    End Function
End Class
