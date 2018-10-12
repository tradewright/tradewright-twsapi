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

Imports System.IO
Imports System.Net.Sockets
Imports System.Threading

Friend Class SocketManager

    Private Structure TcpKeepAlive
        Friend KeepaliveInterval As Integer
        Friend KeepaliveTime As Integer
        Friend Onoff As Integer
    End Structure

    Protected _Host As String

    Private mTcpClient As TcpClient
    Private mSocket As Socket
    Private mBaseStream As NetworkStream
    Protected _ClientStream As Stream

    Private mClosedAction As Action

    Friend Sub New(host As String, port As Integer)
        Me._Host = host
        Me.Port = port
    End Sub

    Friend ReadOnly Property Host As String
        Get
            Return Me._Host
        End Get
    End Property

    Friend ReadOnly Property Port As Integer

    Friend Sub Close()
        If mBaseStream IsNot Nothing Then mBaseStream.Dispose()
        If _ClientStream IsNot Nothing Then _ClientStream.Dispose()
        If mSocket IsNot Nothing Then mSocket.Dispose()
        If mTcpClient IsNot Nothing Then mTcpClient.Close()

        mClosedAction()
    End Sub

    Friend Overridable Async Function ConnectAsync(connectedAction As Action, closedAction As Action, errorAction As Action(Of SocketEventArgs), keepAlive As Boolean) As Task(Of Boolean)
        Try
            mClosedAction = closedAction

            Me.mTcpClient = New TcpClient()
            Await Me.mTcpClient.ConnectAsync(Me._Host, Me.Port)

            Me.mSocket = Me.mTcpClient.Client

            If keepAlive Then Me.setKeepAliveOn()

            Me.mBaseStream = Me.mTcpClient.GetStream()
            Me._ClientStream = Me.mBaseStream

            connectedAction()

        Catch e As System.Net.Sockets.SocketException
            errorAction(New SocketEventArgs(e, Me._Host, Me.Port, 0, String.Empty))
        End Try

        Return True
    End Function

    Friend Async Function ReadByteArrayAsync(buf As Byte(), offset As Integer, token As CancellationToken) As Task(Of Integer)
        Try
            While Not (Me.mBaseStream.DataAvailable Or token.IsCancellationRequested)
                Await Task.Delay(1)
            End While
            Return If(token.IsCancellationRequested, 0, Me._ClientStream.Read(buf, offset, CInt(buf.Length) - offset))
        Catch objectDisposedException As System.ObjectDisposedException
            Return 0
        Catch oException As IOException
            Return 0
        End Try
    End Function

    Friend Sub Send(msg As Byte())
        _ClientStream.Write(msg, 0, msg.Length)
    End Sub

    Private Sub setKeepAliveOn()
        Me.mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, True)

        Dim ka = New TcpKeepAlive With {
            .Onoff = 1,
            .KeepaliveInterval = 1000,
            .KeepaliveTime = 15000
        }

        Dim mem = New MemoryStream()
        Dim w = New BinaryWriter(mem)
        w.Write(ka.KeepaliveInterval)
        w.Write(ka.KeepaliveTime)
        w.Write(ka.Onoff)

        Dim outValue = BitConverter.GetBytes(0)
        Me.mSocket.IOControl(IOControlCode.KeepAliveValues, mem.ToArray(), outValue)
    End Sub

End Class
