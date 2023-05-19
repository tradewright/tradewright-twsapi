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

Imports System.Globalization
Imports System.Text
Imports System.Threading.Tasks

Friend NotInheritable Class MessageReader
    Private ReadOnly mInputReader As InputStringReader

    Private ReadOnly mUseV100Plus As Boolean

    Private mInMessageBuilder As StringBuilder

    Friend Sub New(inputReader As InputStringReader, useV100Plus As Boolean, generateSocketDataEvents As Boolean)
        mUseV100Plus = useV100Plus
        mInputReader = inputReader
        Me.GenerateSocketDataEvents = generateSocketDataEvents
    End Sub

    Friend ReadOnly Property GenerateSocketDataEvents As Boolean

    Friend ReadOnly Property Message As String
        Get
            Return mInMessageBuilder?.ToString()
        End Get
    End Property

    Friend WriteOnly Property NewDataCallback As Action
        Set(value As Action)
            mInputReader.NewDataCallback = value
        End Set
    End Property

    Friend Sub AppendToMessageString(s As String)
        mInMessageBuilder?.Append(s)
    End Sub

    Friend Async Function BeginMessageAsync(prefix As String, buildMessageString As Boolean) As Task
        If (Not buildMessageString) Then
            mInMessageBuilder = Nothing
        ElseIf mInMessageBuilder IsNot Nothing Then
            mInMessageBuilder.Clear()
            mInMessageBuilder.Append(prefix)
        Else
            mInMessageBuilder = New StringBuilder(prefix)
        End If
        mInputReader.BeginMessage()
        Await discardLengthIfPresentAsync()
    End Function

    Friend Sub EndMessage()
        mInMessageBuilder = Nothing
    End Sub

    Friend Async Function GetBooleanAsync(fieldName As String) As Task(Of Boolean)
        Dim s = Await GetStringAsync(fieldName)
        Return s = "1"
    End Function

    Friend Async Function GetBoolFromIntAsync(fieldName As String) As Task(Of Boolean)
        Dim str = Await GetStringAsync(fieldName)
        Return Not String.IsNullOrEmpty(str) AndAlso Integer.Parse(str) <> 0
    End Function

    Friend Async Function GetCharAsync(fieldName As String) As Task(Of Char)
        Dim s = Await GetStringAsync(fieldName)
        Return If(String.IsNullOrEmpty(s), ChrW(0), s(0))
    End Function

    Friend Async Function GetDecimalAsync(fieldName As String) As Task(Of Decimal)
        Dim s = Await GetStringAsync(fieldName)
        Return If(Not String.IsNullOrEmpty(s), Decimal.Parse(s), 0)
    End Function

    Friend Async Function GetDoubleAsync(fieldName As String) As Task(Of Double)
        Dim s = Await GetStringAsync(fieldName)
        Return If(Not String.IsNullOrEmpty(s), Double.Parse(s, NumberFormatInfo.InvariantInfo), 0)
    End Function

    Friend Async Function GetIntAsync(fieldName As String) As Task(Of Integer)
        Dim s = Await GetStringAsync(fieldName)
        Return If(Not String.IsNullOrEmpty(s), Integer.Parse(s), 0)
    End Function

    Friend Async Function GetLongAsync(fieldName As String) As Task(Of Long)
        Dim s = Await GetStringAsync(fieldName)
        Return If(Not String.IsNullOrEmpty(s), Long.Parse(s), CLng(0))
    End Function

    Friend Async Function GetNullableDecimalAsync(fieldName As String) As Task(Of Decimal?)
        Dim s = Await GetStringAsync(fieldName)
        Dim result? = If(String.IsNullOrEmpty(s), Nothing, Decimal.Parse(s, NumberFormatInfo.InvariantInfo))
        If result.HasValue And (result.Value = Decimal.MaxValue Or result.Value = Integer.MaxValue Or result.Value = Double.MaxValue) Then result = Nothing
        Return result
    End Function

    Friend Async Function GetNullableDoubleAsync(fieldName As String) As Task(Of Double?)
        Dim s = Await GetStringAsync(fieldName)
        Dim result? = If(String.IsNullOrEmpty(s), Nothing, Double.Parse(s, NumberFormatInfo.InvariantInfo))
        If result.HasValue And result.Value = Double.MaxValue Then result = Nothing
        Return result
    End Function

    Friend Async Function GetNullableIntAsync(fieldName As String) As Task(Of Integer?)
        Dim s = Await GetStringAsync(fieldName)
        Dim result? = If(String.IsNullOrEmpty(s), Nothing, Integer.Parse(s))
        If result.HasValue And result.Value = Integer.MaxValue Then result = Nothing
        Return result
    End Function

    Friend Async Function GetNullableLongAsync(fieldName As String) As Task(Of Long?)
        Dim s = Await GetStringAsync(fieldName)
        Dim result? = If(String.IsNullOrEmpty(s), Nothing, Long.Parse(s))
        If result.HasValue And result.Value = Long.MaxValue Then result = Nothing
        Return result
    End Function

    Friend Async Function GetStringAsync(fieldName As String) As Task(Of String)
        Dim element = Await mInputReader.ReadStringAsync()

        mInMessageBuilder?.Append(fieldName)
        mInMessageBuilder?.Append("="c)
        mInMessageBuilder?.Append(element)
        mInMessageBuilder?.Append(";"c)

        Return element
    End Function

    Friend Sub ProcessCurrentProtocolMessage(process As Action(Of Byte(), Integer, Integer, Integer))
        mInputReader.ProcessCurrentProtocolMessage(process)
    End Sub

    Friend Sub ProcessLatestSocketData(process As Action(Of Byte(), Integer, Integer))
        mInputReader.ProcessLatestSocketData(process)
    End Sub

    Private Async Function discardLengthIfPresentAsync() As Task
        If (mUseV100Plus) Then Await mInputReader.ReadBinaryIntAsync()
    End Function

End Class
