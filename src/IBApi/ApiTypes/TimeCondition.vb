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

''' <summary>
''' Used in conditional orders to submit Or cancel orders at specified time
''' </summary>
Public Class TimeCondition
    Inherits OperatorCondition
    Const Header As String = "time"

    Protected Overrides Property Value As String
        Get
            Return Time
        End Get
        Set
            Time = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Header & MyBase.ToString()
    End Function

    ''' <summary>
    ''' Used in conditional order logic. Valid format: YYYYMMDD HH :    MM:SS
    ''' </summary>
    ''' <returns></returns>
    Public Property Time As String

    Protected Overrides Function TryParse(cond As String) As Boolean
        If Not cond.StartsWith(Header) Then Return False

        cond = cond.Substring(Header.Length)
        Return MyBase.TryParse(cond)
    End Function

End Class
