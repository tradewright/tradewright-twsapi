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

Imports System.Net
Imports System.Text
Imports System.Threading

Friend NotInheritable Class InputStringReader

    Private Const SizeOfInt As Integer = 4  ' sizeof Integer

    Private mSocketManager As SocketManager

    Private ReadOnly mToken As CancellationToken

    Friend Const DataStreamEnded As String = "Data stream ended"

    ' it doesn't much matter what size we make the buffer initially, as it will 
    ' quickly be expanded when necessary. Note that we never bother to reduce
    ' the buffer's size once it has been increased, because even the largest message
    ' (ie 10 days of 1-minute historical data) Is only a megabyte Or so, And that's
    ' Not really a significant amount of memory in comparison with what the rest of
    ' the application Is likely to be using. So we set it initially to something that's likely
    ' to be adequate for most programs that don't make large historical data requests.
    Private Const InitialBufferSize As Integer = 4096

    Private mBuffer As Byte() = New Byte(4095) {}

    ' index of the start of the next unprocessed message
    Private mBufferIndex As Integer

    ' total data read into the buffer
    Private mDataLength As Integer

    ' the current position at which data Is being read from the buffer
    Private mCurrIndex As Integer

    Private mEncoding As Encoding = New UTF8Encoding(False, True)

    Private ReadOnly mMaxMessageSize As Integer

    ' the index of the start of the latest data read from the socket
    Private mLatestDataStartIndex As Integer

    ' the length of the latest data read from the socket
    Private mLatestDataLength As Integer

    ' the index of the start of the current message
    Private mMessageStartIndex As Integer

    Friend Property NewDataCallback As Action

    Friend Sub New(socketManager As SocketManager, cancellationSource As CancellationTokenSource, maxMessageSize As Integer)
        mSocketManager = socketManager
        mToken = cancellationSource.Token
        mMaxMessageSize = maxMessageSize
    End Sub

    Private Async Function appendDataAsync() As Task
        If (isBufferFull()) Then ensureSpaceInBuffer()

        Dim bytesRead = Await mSocketManager.ReadByteArrayAsync(mBuffer, mDataLength, mToken)
        If (bytesRead = 0) Then throwDataStreamEnded()

        mLatestDataStartIndex = mDataLength
        mLatestDataLength = bytesRead
        mDataLength += bytesRead

        NewDataCallback?.Invoke()
    End Function

    Friend Sub BeginMessage()
        mMessageStartIndex = mCurrIndex
    End Sub

    Private Sub ensureSpaceInBuffer()
        Dim oldBuf As Byte() = mBuffer
        ReDim mBuffer(2 * CInt(oldBuf.Length) - 1)
        Debug.WriteLine($"Buffer size increased to: {mBuffer.Length}")
        System.Buffer.BlockCopy(oldBuf, mBufferIndex, mBuffer, 0, mDataLength - mBufferIndex)
        mDataLength -= mBufferIndex
        mCurrIndex -= mBufferIndex
        mBufferIndex = 0
    End Sub

    Private Function isBufferFull() As Boolean
        Return mDataLength >= mBuffer.Length
    End Function

    Friend Sub ProcessCurrentProtocolMessage(process As Action(Of Byte(), Integer, Integer, Integer))
        process(mBuffer, mMessageStartIndex, mCurrIndex, mDataLength)
    End Sub

    Friend Sub ProcessLatestSocketData(process As Action(Of Byte(), Integer, Integer))
        process(mBuffer, mLatestDataStartIndex, mLatestDataLength)
    End Sub

    Friend Async Function ReadBinaryIntAsync() As Task(Of Integer)
        While mDataLength - mCurrIndex < SizeOfInt
            Await appendDataAsync()
        End While

        Dim value As Integer = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(mBuffer, mCurrIndex))
        If (value > mMaxMessageSize) Then Throw New ApiException(ErrorCodes.MessageTooLong, "Input message exceeds maximum size")

        mCurrIndex += SizeOfInt
        Return value
    End Function

    Friend Async Function ReadStringAsync() As Task(Of String)
        If mCurrIndex >= mDataLength Then Await appendDataAsync()

        Dim firstIndex = mCurrIndex
        If getByte() = 0 Then Return Nothing

        Do
            If mCurrIndex >= mDataLength Then Await appendDataAsync()
        Loop While getByte() <> 0

        Dim element = mEncoding.GetString(mBuffer, firstIndex, mCurrIndex - firstIndex - 1)

        If mCurrIndex >= mDataLength Then
            ' start using the buffer from the beginning again
            mBufferIndex = 0
            mDataLength = 0
            mCurrIndex = 0
        End If

        Return element
    End Function

    Private Function getByte() As Byte
        Dim b = mBuffer(mCurrIndex)
        mCurrIndex += 1
        Return b
    End Function

    Private Sub throwDataStreamEnded()
        Throw New ApiException(ErrorCodes.DataStreamEnded, "")
    End Sub
End Class
