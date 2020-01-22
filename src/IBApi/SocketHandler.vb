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

Imports System.Threading
Imports System.Threading.Tasks

Imports TradeWright.IBAPI.ApiException

Friend Class SocketHandler

    ''
    ' Description here
    '
    '@/

    '@================================================================================
    ' Interfaces
    '@================================================================================

    '@================================================================================
    ' Events
    '@================================================================================

    '@================================================================================
    ' Enums
    '@================================================================================

    '@================================================================================
    ' Types
    '@================================================================================

    '@================================================================================
    ' Constants
    '@================================================================================

    Private Const ModuleName As String = NameOf(SocketHandler)

    '@================================================================================
    ' Member variables
    '@================================================================================

    Private Socket As SocketManager

    Private ReadOnly mServer As String
    Private ReadOnly mPort As Integer

    Private mKeepAlive As Boolean

    Private mRetryingConnection As Boolean

    Private mConnectionTimer As Timer

    Private mIsConnecting As Boolean
    Private mIsConnected As Boolean

    Private mConnectionRetryIntervalSecs As Integer

    ' Called when a successful connection to Tws has been achieved.
    Private ReadOnly mConnectedAction As Action

    ' Called when connection to Tws has failed
    Private ReadOnly mConnectFailedAction As Action(Of String)

    ' Called when an attempt to connect to Tws is initiated.
    Private ReadOnly mConnectingAction As Action

    ' Called when the connection to Tws is disconnected.
    Private ReadOnly mConnectionClosedAction As Action(Of String)

    ' Called when we Disconnect from Tws
    Private ReadOnly mDisconnectedAction As Action(Of String)


    '@================================================================================
    ' Class Event Handlers
    '@================================================================================

    Friend Sub New(socket As SocketManager,
                   connectingAction As Action,
                   connectedAction As Action,
                   connectFailedAction As Action(Of String),
                   disconnectedAction As Action(Of String),
                   connectionClosedAction As Action(Of String),
                   connectionRetryIntervalSecs As Integer)
        Me.Socket = socket
        mServer = Me.Socket.Host
        mPort = Me.Socket.Port

        mConnectingAction = connectingAction
        mConnectedAction = connectedAction
        mConnectFailedAction = connectFailedAction
        mDisconnectedAction = disconnectedAction
        mConnectionClosedAction = connectionClosedAction

        mConnectionRetryIntervalSecs = connectionRetryIntervalSecs
    End Sub

    '@================================================================================
    ' XXXX Interface Members
    '@================================================================================

    '================================================================================
    ' mConnectionTimer Event Handlers
    '================================================================================

    Private Sub mConnectionTimer_TimerExpired(state As Object)
        mConnectionTimer = Nothing
        Connect(mKeepAlive)
    End Sub

    '@================================================================================
    ' Properties
    '@================================================================================

    Friend Property ConnectionRetryIntervalSecs() As Integer
        Get
            ConnectionRetryIntervalSecs = mConnectionRetryIntervalSecs
        End Get
        Set()
            mConnectionRetryIntervalSecs = Value
            If mConnectionRetryIntervalSecs = 0 And mRetryingConnection Then mConnectionTimer = Nothing
        End Set
    End Property

    Friend ReadOnly Property SocketManager As SocketManager
        Get
            Return Socket
        End Get
    End Property

    '@================================================================================
    ' Methods
    '@================================================================================

    Friend Sub Connect(keepAlive As Boolean)
        If mIsConnected Then Throw New InvalidOperationException("Already connected")

        mKeepAlive = keepAlive

        Dim s As String
        s = $"Connecting to Tws: {getConnectionString()}"
        IBAPI.EventLogger.Log(s, ModuleName, "Connect")

        mIsConnecting = True

        ' we don't Await the following call because we don't want this Connect method to have to be async
        Dim t = Socket.ConnectAsync(Sub()
                                        mIsConnecting = False
                                        mIsConnected = True
                                        mConnectedAction()
                                    End Sub,
                                     Sub() handleTwsDisconnection("closed by peer", False),
                                     AddressOf handleSocketError,
                                     keepAlive)

        mConnectingAction()
    End Sub

    Friend Sub Disconnect(pReason As String)
        If Not (mIsConnecting Or mIsConnected) Then Exit Sub
        mIsConnecting = False
        mIsConnected = False

        If Not mConnectionTimer Is Nothing Then mConnectionTimer.Dispose()

        releaseSocket()

        IBAPI.EventLogger.Log($"Disconnected from: {getConnectionString()} : {pReason}", ModuleName, NameOf(Disconnect))
        handleTwsDisconnection("closed by application", True)
        mDisconnectedAction(pReason)
    End Sub

    '@================================================================================
    ' Helper Functions
    '@================================================================================

    Private Function getConnectionString() As String
        Return $"server={mServer} port={mPort}"
    End Function

    Private Sub handleSocketError(e As SocketEventArgs)
        Dim errorNum = CType(e.Exception.ErrorCode, SocketErrorCode)
        Select Case errorNum
            Case SocketErrorCode.WSAEADDRNOTAVAIL,
                 SocketErrorCode.WSAENETUNREACH,
                 SocketErrorCode.WSAENETRESET,
                 SocketErrorCode.WSAECONNABORTED,
                 SocketErrorCode.WSAECONNREFUSED,
                 SocketErrorCode.WSAHOST_NOT_FOUND,
                 SocketErrorCode.WSATRY_AGAIN,
                 SocketErrorCode.WSAETIMEDOUT,
                 SocketErrorCode.WSAECONNRESET

                releaseSocket()
                If Not mIsConnected Then
                    IBAPI.EventLogger.Log($"Failed to connect to Tws {CStr(If(mConnectionRetryIntervalSecs <> 0, $" - retrying In {mConnectionRetryIntervalSecs} seconds", ""))}: {e.Exception.Message} : {getConnectionString()}", ModuleName, NameOf(handleSocketError))

                    e.ConnectionRetryInterval = mConnectionRetryIntervalSecs
                    mConnectFailedAction(e.Exception.Message)
                    If mConnectionRetryIntervalSecs <> 0 Then retryConnection()
                Else
                    IBAPI.EventLogger.Log($"Socket error {e.Exception.ErrorCode} : {e.Exception.Message} : {getConnectionString()}", ModuleName, NameOf(handleSocketError))
                    handleTwsDisconnection(e.Exception.Message, False)
                End If
            Case Else
                Throw New InvalidOperationException($"Socket error {e.Exception.ErrorCode}: {e.Exception.Message} : {getConnectionString()}")
        End Select
    End Sub

    Private Sub handleTwsDisconnection(pMessage As String, pClosedByApplication As Boolean)
        IBAPI.EventLogger.Log($"Connection to Tws closed: {pMessage} : {getConnectionString()}", ModuleName, NameOf(handleTwsDisconnection))

        Socket = Nothing
        mIsConnected = False

        mConnectionClosedAction(pMessage)
        If Not pClosedByApplication Then retryConnection()
    End Sub

    Private Sub releaseSocket()
        If Not Socket Is Nothing Then
            IBAPI.EventLogger.Log($"Releasing socket: {getConnectionString()}", ModuleName, NameOf(releaseSocket))
            Socket.Close()
            Socket = Nothing
        End If

        mIsConnected = False
    End Sub

    Private Sub retryConnection()
        If mConnectionRetryIntervalSecs <> 0 Then
            IBAPI.EventLogger.Log($"Reconnecting in {mConnectionRetryIntervalSecs} seconds", ModuleName, NameOf(retryConnection))
            mConnectionTimer = New Timer(AddressOf mConnectionTimer_TimerExpired, Nothing, 1000 * mConnectionRetryIntervalSecs, Timeout.Infinite)
            mRetryingConnection = True
        End If
    End Sub

End Class