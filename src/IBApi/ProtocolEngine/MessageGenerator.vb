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
Imports System.IO
Imports System.Net
Imports System.Text

Friend NotInheritable Class MessageGenerator
    Implements IDisposable

    Private Const EOL As Byte = 0

    Private mBuffer As MemoryStream

    Private mSocketManager As SocketManager

    Private mWriter As BinaryWriter

    Private mMessage As Byte()

    Private mLength As Integer

    Private mLengthOffset As Integer

    Private ReadOnly mUseV100Plus As Boolean

    Private ReadOnly mThisLock As Object = New Object()

    Private ReadOnly mMessageBuilder As StringBuilder

    Private mDisposed As Boolean

    Friend Sub New(socketManager As SocketManager, useV100Plus As Boolean, buildMessageString As Boolean)
        mSocketManager = socketManager
        mUseV100Plus = useV100Plus
        If (buildMessageString) Then mMessageBuilder = New StringBuilder("OUT: ")
    End Sub


    Friend ReadOnly Property MessageAsStructuredString As String
        Get
            Return mMessageBuilder?.ToString()
        End Get
    End Property

    Friend ReadOnly Property MessageAsPrintableBytes As String
        Get
            If Not mUseV100Plus Then Return $"Out buf: {Encoding.UTF8.GetString(mMessage).Replace("0"c, "_")}"

            If mLengthOffset = 0 Then Return $"Out buf: {{{mLength}}}{Encoding.UTF8.GetString(mMessage, 4, mMessage.Length - 4).Replace("0"c, "_")}"

            Return $"Out buf: {Encoding.UTF8.GetString(mMessage, 0, mLengthOffset)}{{{mLength}}}{Encoding.UTF8.GetString(mMessage, mLengthOffset + 4, mMessage.Length - mLengthOffset - 4).Replace("0"c, "_")}"
        End Get
    End Property

    Friend Sub Dispose() Implements IDisposable.Dispose
        If Not mDisposed Then
            mDisposed = True
            mBuffer.Dispose()
            mWriter.Dispose()
        End If
    End Sub

    Friend Sub StartMessage(Optional initialValue As String = Nothing)
        initialise()
        If (Not String.IsNullOrEmpty(initialValue)) Then
            AddElement(initialValue, "Prefix")
            If (mUseV100Plus) Then mLengthOffset = mLength
            mLength = 0   ' don't include the prefix in the length of the message part
        End If
        makeSpaceForLength()
    End Sub

    Friend Sub StartMessage(msgId As Integer, messageName As String)
        initialise()
        makeSpaceForLength()
        AddElement(msgId, String.Format("({0}) MsgId", messageName))
    End Sub

    Friend Sub AddElement(value As Integer, fieldName As String)
        AddElement(value.ToString(CultureInfo.InvariantCulture), fieldName)
    End Sub

    Friend Sub AddElement(value As Integer?, fieldName As String)
        If value.HasValue Then
            AddElement(value.Value.ToString(CultureInfo.InvariantCulture), fieldName)
        Else
            AddElement(String.Empty, fieldName)
        End If
    End Sub

    Friend Sub AddElement(value As Double, fieldName As String)
        AddElement(value.ToString(CultureInfo.InvariantCulture), fieldName)
    End Sub

    Friend Sub AddElement(value As Double?, fieldName As String)
        If value.HasValue Then
            AddElement(value.Value.ToString(CultureInfo.InvariantCulture), fieldName)
        Else
            AddElement(String.Empty, fieldName)
        End If
    End Sub

    Friend Sub AddElement(value As Boolean, fieldName As String)
        If (Not value) Then
            AddElement("0", fieldName)
        Else
            AddElement("1", fieldName)
        End If
    End Sub

    Friend Sub AddElement(value As String, fieldName As String)
        mMessageBuilder?.Append(fieldName)?.Append("=")?.Append(value)?.Append(";")

        writeRawString(value)
        mWriter.Write(EOL)
        mLength += 1
    End Sub

    Friend Sub AddElement(value As Contract, fieldName As String)
        AddElement(value.ConId, $"{fieldName}.ConId")
        AddElement(value.Symbol?.ToUpper(), $"{fieldName}.Symbol")
        AddElement(SecurityTypes.ToInternalString(value.SecType), $"{fieldName}.Sectype")
        AddElement(value.Expiry, $"{fieldName}.Expiry")
        AddElement(value.Strike, $"{fieldName}.Strike")
        AddElement(OptionRights.ToInternalString(value.OptRight), $"{fieldName}.Right")
        AddElement(If(value.Multiplier = 1, "", CStr(value.Multiplier)), $"{fieldName}.Multiplier")
        AddElement(value.Exchange, $"{fieldName}.Exchange")
        AddElement(value.PrimaryExch, $"{fieldName}.Primary Exchange")
        AddElement(value.CurrencyCode, $"{fieldName}.Currency")
        AddElement(value.LocalSymbol?.ToUpper(), $"{fieldName}.Local Symbol")
        AddElement(value.TradingClass, $"{fieldName}.Trading Class")
    End Sub

    Friend Sub AddElement(options As List(Of TagValue), fieldName As String)
        AddElement(If(options Is Nothing, "", String.Join(Of TagValue)(";", options) & ";"), fieldName)
    End Sub

    Friend Sub Send()
        mMessage = getMessage()
        SyncLock mThisLock
            mSocketManager.Send(mMessage)
        End SyncLock
    End Sub

    Friend Sub AddString(value As String, fieldName As String)
        mMessageBuilder?.Append(fieldName)?.Append("=")?.Append(value)?.Append(";")

        writeRawString(value)
    End Sub

    Private Function getMessage() As Byte()
        If (mUseV100Plus) Then
            mWriter.Seek(mLengthOffset, SeekOrigin.Begin)
            mWriter.Write(IPAddress.HostToNetworkOrder(mLength))
        End If
        Return mBuffer.ToArray()
    End Function

    Private Sub initialise()
        mBuffer = New MemoryStream()
        mWriter = New BinaryWriter(mBuffer)
        mLength = 0
        mLengthOffset = 0
    End Sub

    Private Sub makeSpaceForLength()
        If (mUseV100Plus) Then mWriter.Write(0)
    End Sub

    Private Sub writeRawString(value As String)
        If (Not String.IsNullOrEmpty(value)) Then
            Dim b = Encoding.UTF8.GetBytes(value)
            mLength += CInt(b.Length)
            mWriter.Write(b)
        End If
    End Sub

End Class
