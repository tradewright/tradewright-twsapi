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

Imports System.Globalization
Imports System.Linq

<Flags>
Friend Enum EnumNameType
    None = 0
    Internal = 1
    External = 2
    [Alias] = 4
    NonAliasExternal = 8
    NonAliasInternal = 16
    Both = Internal Or External
End Enum

Public Class ExtendedEnum(Of TClass As Class, TEnum As {Structure, IConvertible, TClass})

    ' Thanks for assistance from this StackOverflow answer: http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum

    Private mNames() As (Name As String, Value As TEnum, Type As EnumNameType)

    Friend Sub New(friendlyNames() As (Name As String, Value As TEnum, Type As EnumNameType))
        If friendlyNames Is Nothing OrElse friendlyNames.Length = 0 Then Throw New ArgumentNullException(NameOf(friendlyNames))
        mNames = friendlyNames.OrderByDescending(Function(n) n.Name.Length).ToArray()
    End Sub

    Public ReadOnly Property ExternalNames As String()
        Get
            Return (From t In mNames Where t.Type = EnumNameType.External Select t.Name).ToArray()
        End Get
    End Property

    Public ReadOnly Property InternalNames As String()
        Get
            Return (From t In mNames Where t.Type = EnumNameType.Internal Select t.Name).ToArray()
        End Get
    End Property

    Public Function Parse(value As String, Optional ignoreCase As Boolean = False) As TEnum
        Dim result As TEnum = Nothing
        If TryParse(value, result, ignoreCase) Then Return result
        Throw New ArgumentException("Invalid value", NameOf(value))
    End Function

    Public Function ToExternalString(value As TEnum) As String
        Return toExtString(value, EnumNameType.External Or EnumNameType.NonAliasExternal)
    End Function

    Public Function ToInternalString(value As TEnum) As String
        Return toExtString(value, EnumNameType.Internal Or EnumNameType.NonAliasInternal)
    End Function

    Public Function TryParse(value As String, ByRef result As TEnum, Optional ignoreCase As Boolean = False) As Boolean
        Dim nextIndex As Integer
        If TryParseFrom(value, result, nextIndex, ignoreCase) Then Return If(value Is Nothing, True, nextIndex = value.Length)
        Return False
    End Function

    Public Function TryParseFrom(value As String, ByRef result As TEnum, ByRef nextIndex As Integer, Optional ignoreCase As Boolean = False) As Boolean
        For i = 0 To mNames.Length - 1
            If (mNames(i).Type And (EnumNameType.Alias Or EnumNameType.Internal Or EnumNameType.External)) <> 0 Then
                Dim match = False
                If String.IsNullOrEmpty(value) And String.IsNullOrEmpty(mNames(i).Name) Then
                    match = True
                ElseIf String.IsNullOrEmpty(value) Or String.IsNullOrEmpty(mNames(i).Name) Then
                ElseIf ignoreCase Then
                    If value.StartsWith(mNames(i).Name, StringComparison.InvariantCultureIgnoreCase) Then match = True
                Else
                    If value.StartsWith(mNames(i).Name) Then match = True
                End If
                If match Then
                    result = mNames(i).Value
                    nextIndex = mNames(i).Name.Length
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Function toExtString(value As TEnum, nameType As EnumNameType) As String
        For i = 0 To mNames.Length - 1
            If mNames(i).Value.ToInt32(CultureInfo.InvariantCulture) = value.ToInt32(CultureInfo.InvariantCulture) And ((mNames(i).Type And nameType) <> 0) Then Return mNames(i).Name
        Next
        Throw New ArgumentException("Invalid value", NameOf(value))
    End Function

End Class
