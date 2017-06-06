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

Public Class SoftDollarTier

    Private mName As String
    Private mValue As String
    Private mDisplayName As String

    Public ReadOnly Property Name As String
        Get
            Return mName
        End Get
    End Property

    Public ReadOnly Property Value As String
        Get
            Return mValue
        End Get
    End Property

    Public ReadOnly Property DisplayName As String
        Get
            Return mDisplayName
        End Get
    End Property


    Public Sub New(name As String, value As String, displayName As String)
        mName = name
        mValue = value
        mDisplayName = displayName
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot SoftDollarTier Then Return False

        Dim b = DirectCast(obj, SoftDollarTier)

        Return String.Compare(mName, b.Name, True) = 0 And String.Compare(mValue, b.Value, True) = 0
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return mName.GetHashCode() + mValue.GetHashCode()
    End Function

    Public Shared Operator =(left As SoftDollarTier, right As SoftDollarTier) As Boolean
        Return left.Equals(right)
    End Operator

    Public Shared Operator <>(left As SoftDollarTier, right As SoftDollarTier) As Boolean
        Return Not left.Equals(right)
    End Operator

    Public Overrides Function ToString() As String
        Return mDisplayName
    End Function

End Class
