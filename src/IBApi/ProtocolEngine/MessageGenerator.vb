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
Imports System.IO
Imports System.Net
Imports System.Text

Friend NotInheritable Class MessageGenerator
    Implements IDisposable

    Private Const EOL As Byte = 0

    Private mBuffer As MemoryStream

    Private ReadOnly mSocketManager As SocketManager

    Private mWriter As BinaryWriter

    Private mMessage As Byte()

    Private mLength As Integer

    Private mLengthOffset As Integer

    Private ReadOnly mUseV100Plus As Boolean

    Private ReadOnly mThisLock As New Object()

    Private ReadOnly mMessageBuilder As StringBuilder

    Private mDisposed As Boolean

    Friend ReadOnly Property GenerateSocketDataEvents As Boolean

    Friend Sub New(socketManager As SocketManager, useV100Plus As Boolean, buildMessageString As Boolean, generateSocketDataEvents As Boolean)
        mSocketManager = socketManager
        mUseV100Plus = useV100Plus
        If buildMessageString Or generateSocketDataEvents Then mMessageBuilder = New StringBuilder("OUT: ")
        Me.GenerateSocketDataEvents = generateSocketDataEvents
    End Sub


    Friend ReadOnly Property MessageAsStructuredString As String
        Get
            Return mMessageBuilder?.ToString()
        End Get
    End Property

    Friend ReadOnly Property MessageAsPrintableBytes As String
        Get
            If Not mUseV100Plus Then Return $"Out buf: {Encoding.UTF8.GetString(mMessage).Replace(ChrW(0), "_")}"

            If mLengthOffset = 0 Then Return $"Out buf: {{{mLength}}}{Encoding.UTF8.GetString(mMessage, 4, mLength).Replace(ChrW(0), "_")}"

            Return $"Out buf: {Encoding.UTF8.GetString(mMessage, 0, mLengthOffset)}{{{mLength}}}{Encoding.UTF8.GetString(mMessage, mLengthOffset + 4, mLength)}".Replace(ChrW(0), "_")  ' mLengthOffset + 4, mMessage.Length - mLengthOffset - 4).Replace(ChrW(0), "_")}"
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
            AddString(initialValue, "Prefix")
            If (mUseV100Plus) Then mLengthOffset = mLength
            mLength = 0   ' don't include the prefix in the length of the message part
        End If
        makeSpaceForLength()
    End Sub

    Friend Sub StartMessage(msgId As Integer, messageName As String)
        initialise()
        makeSpaceForLength()
        AddInteger(msgId, String.Format("({0}) MsgId", messageName))
    End Sub

    Friend Sub AddInteger(value As Integer, fieldName As String)
        AddString(value.ToString(CultureInfo.InvariantCulture), fieldName)
    End Sub

    Friend Sub AddNullableInteger(value As Integer?, fieldName As String)
        If value.HasValue Then
            AddString(value.Value.ToString(CultureInfo.InvariantCulture), fieldName)
        Else
            AddString(String.Empty, fieldName)
        End If
    End Sub

    Friend Sub AddDouble(value As Double, fieldName As String)
        AddString(value.ToString(CultureInfo.InvariantCulture), fieldName)
    End Sub

    Friend Sub AddNullableDouble(value As Double?, fieldName As String)
        If value.HasValue Then
            AddString(value.Value.ToString(CultureInfo.InvariantCulture), fieldName)
        Else
            AddString(String.Empty, fieldName)
        End If
    End Sub

    Friend Sub AddBoolean(value As Boolean, fieldName As String)
        If value Then
            AddString("1", fieldName)
        Else
            AddString("0", fieldName)
        End If
    End Sub

    Friend Sub AddNullableBoolean(value As Boolean?, fieldName As String)
        If value.HasValue Then
            AddString("", fieldName)
        ElseIf value.Value Then
            AddString("1", fieldName)
        Else
            AddString("0", fieldName)
        End If
    End Sub

    Friend Sub AddString(value As String, fieldName As String)
        If Not IBAPI.IsAsciiPrintableString(value) Then Throw New ApiApplicationException($"Unprintable value <{value}> passed to API for field {fieldName}")

        mMessageBuilder?.Append(fieldName)?.Append("="c)?.Append(value)?.Append(";"c)

        writeRawString(value)
        mWriter.Write(EOL)
        mLength += 1
    End Sub

    Friend Sub AddContract(value As Contract, fieldName As String, Optional ignorePrimaryExchange As Boolean = False)
        AddInteger(value.ConId, $"{fieldName}.ConId")
        AddString(value.Symbol?.ToUpper(), $"{fieldName}.Symbol")
        AddString(IBAPI.SecurityTypes.ToInternalString(value.SecType), $"{fieldName}.Sectype")
        AddString(value.Expiry, $"{fieldName}.Expiry")
        AddDouble(value.Strike, $"{fieldName}.Strike")
        AddString(IBAPI.OptionRights.ToInternalString(value.OptRight), $"{fieldName}.Right")
        AddString(If(value.Multiplier = 1, "", CStr(value.Multiplier)), $"{fieldName}.Multiplier")
        AddString(value.Exchange, $"{fieldName}.Exchange")
        If Not ignorePrimaryExchange Then AddString(value.PrimaryExch, $"{fieldName}.Primary Exchange")
        AddString(value.CurrencyCode, $"{fieldName}.Currency")
        AddString(value.LocalSymbol?.ToUpper(), $"{fieldName}.Local Symbol")
        AddString(value.TradingClass, $"{fieldName}.Trading Class")
    End Sub

    Friend Sub AddOptions(options As List(Of TagValue), fieldName As String)
        AddString(If(options Is Nothing, "", String.Join(Of TagValue)(";", options) & ";"), fieldName)
    End Sub

    Friend Sub Send()
        mMessage = getMessage()
        SyncLock mThisLock
            mSocketManager.Send(mMessage)
        End SyncLock
    End Sub

    Friend Sub AddUnterminatedString(value As String, fieldName As String)
        mMessageBuilder?.Append(fieldName)?.Append("="c)?.Append(value)?.Append(";"c)

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
