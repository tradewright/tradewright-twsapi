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

Imports TradeWright.IBAPI.ApiException

Imports System.Threading
Imports System.Threading.Tasks

Friend Class ApiConnectionManager

    Private Const ModuleName As String = NameOf(ApiConnectionManager)
    Private Const MaxMessageSize As Integer = 20 * 1024 * 1024
    Private Const ClientVersion As Integer = 66
    Private Const MinReqdServerVersion As Integer = ApiServerVersion.RANDOMIZE_SIZE_AND_PRICE


    Private mServer As String
    Private mPort As Integer
    Private mClientId As Integer

    Private WithEvents mSocketHandler As SocketHandler
    Private mConnectedAction As Action

    Private mUseV100Plus As Boolean

    Private mReader As MessageReader

    Private mServerVersion As Integer

    Private mEventConsumers As New ApiEventConsumers

    Private mConnectionState As ApiConnectionState = ApiConnectionState.NotConnected

    Private mRegistry As GeneratorAndParserRegistry

    Private mLogLevel As ApiLogLevel = ApiLogLevel.Information

    Private mConnectionRetryIntervalSecs As Integer


#Region "Constructors"

    Friend Sub New(server As String, port As Integer, clientId As Integer, useV100Plus As Boolean, registry As GeneratorAndParserRegistry, eventConsumers As ApiEventConsumers)
        mServer = server
        mPort = port
        mClientId = clientId
        mUseV100Plus = useV100Plus
        mRegistry = registry
        mEventConsumers = eventConsumers
    End Sub

#End Region

#Region "Properties"

    Friend Property ConnectionRetryIntervalSecs() As Integer
        Get
            ConnectionRetryIntervalSecs = mConnectionRetryIntervalSecs
        End Get
        Set(Value As Integer)
            If Value < 0 Then Throw New ArgumentException("Value cannot be negative")
            mConnectionRetryIntervalSecs = Value
            If Not mSocketHandler Is Nothing Then mSocketHandler.ConnectionRetryIntervalSecs = Value
        End Set
    End Property

    Friend ReadOnly Property ConnectionState() As ApiConnectionState
        Get
            Return mConnectionState
        End Get
    End Property

    Friend ReadOnly Property ConnectionString() As String
        Get
            Return $"server={mServer}; port={mPort}; client Id={mClientId}"
        End Get
    End Property

    Friend ReadOnly Property ServerVersion As Integer
        Get
            Return mServerVersion
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Function Connect(connectedAction As Action, cancellationSource As CancellationTokenSource, Optional useSSL As Boolean = False) As MessageReader
        mConnectedAction = connectedAction
        Dim socket = createSocket(mServer, mPort, useSSL)
        mSocketHandler = New SocketHandler(socket,
                                           Sub() setConnectionState(ApiConnectionState.Connecting, ConnectionString),
                                           AddressOf socketHandlerConnected,
                                           Sub(message) setConnectionState(ApiConnectionState.Failed, $"{message}: {ConnectionString}"),
                                           Sub(reason) setConnectionState(ApiConnectionState.NotConnected, $"{reason}: {ConnectionString}"),
                                           Sub(reason) setConnectionState(ApiConnectionState.NotConnected, $"{reason}: {ConnectionString}"),
                                           mConnectionRetryIntervalSecs)
        mReader = New MessageReader(New InputStringReader(socket, cancellationSource, MaxMessageSize), mUseV100Plus)
        mSocketHandler.Connect(keepAlive:=True)
        Return mReader
    End Function

    Friend Function CreateMessageGenerator() As MessageGenerator
        Return mSocketHandler.CreateMessageGenerator(mUseV100Plus)
    End Function

    Friend Sub Disconnect(pReason As String)
        mSocketHandler?.Disconnect(pReason)
        mSocketHandler = Nothing
    End Sub

    Friend Sub SetLogLevel(pLogLevel As ApiLogLevel)
        If pLogLevel = 0 Then pLogLevel = ApiLogLevel.System
        If pLogLevel = mLogLevel Then Exit Sub
        If Not [Enum].IsDefined(GetType(ApiLogLevel), pLogLevel) Then Throw New ArgumentException("Invalid TWS log level")

        mLogLevel = pLogLevel

        If mConnectionState <> ApiConnectionState.Connected Then Exit Sub

        If mLogLevel <> 0 Then
            EventLogger.Log("Setting TWS log level", ModuleName, NameOf(SetLogLevel))
            mRegistry.InvokeGenerator(ApiSocketOutMsgType.SetServerLogLevel, {mLogLevel})
        End If
    End Sub

#End Region

#Region "Private Methods"
    Private Function createSocket(host As String, port As Integer, useSSL As Boolean) As SocketManager
        If String.IsNullOrEmpty(host) Then host = "127.0.0.1"

        If useSSL Then
            Return New SocketManagerSSL(mServer, port)
        Else
            Return New SocketManager(mServer, port)
        End If
    End Function

    Private Function isValidServerVersion() As Boolean
        Return (mUseV100Plus And mServerVersion >= ApiServerVersion.MinV100Plus And mServerVersion <= ApiServerVersion.Max) Or
                ((Not mUseV100Plus) And mServerVersion >= MinReqdServerVersion)
    End Function

    Private Async Function negotiateConnection() As Task(Of Boolean)
        Const ProcName = "negotiateConnection"

        Try
            Await mReader.BeginMessageAsync("IN: ", True)
            mServerVersion = Await mReader.GetIntAsync("Server Version")

            Dim lServerTime = Await mReader.GetStringAsync("TWS Time")
            mReader.LogSocketInputMessage(ModuleName, ProcName)
            mReader.EndMessage()

            If Not isValidServerVersion() Then
                Dim e = New ApplicationException("TWS is out of date and needs to be upgraded")
                EventLogger.Log("An exception occurred:" & vbCrLf & e.ToString(), ModuleName, ProcName, ILogger.LogLevel.Severe)
                mEventConsumers.ErrorAndNotificationConsumer.NotifyException(New ExceptionEventArgs(Date.UtcNow, e))
                Return False
            End If

            EventLogger.Log($"TWS version: {mServerVersion}; TWS Time at connection: {lServerTime}", ModuleName, ProcName)

            Return True
        Catch e As ApiException When e.ErrorCode = ErrorCodes.DataStreamEnded
            Return False
        End Try

    End Function

    Private Sub setConnectionState(pState As ApiConnectionState, pMessage As String)
        If pState = mConnectionState Then Exit Sub
        mConnectionState = pState
        mEventConsumers.ConnectionStatusConsumer?.NotifyAPIConnectionStateChange(New ApiConnectionStateChangeEventArgs(Date.UtcNow, mConnectionState, pMessage))
    End Sub

    Private Async Sub socketHandlerConnected()
        Const ProcName As String = "socketHandlerConnected"

        Dim lwriter = mSocketHandler.CreateMessageGenerator(mUseV100Plus)
        If mUseV100Plus Then
            EventLogger.Log("Connecting to Tws: negotiating API connection", ModuleName, ProcName)
            lwriter.StartMessage("API")
            lwriter.AddString("v" & ApiServerVersion.MinV100Plus & ".." & ApiServerVersion.Max, "SupportedServerVersions")
            lwriter.SendMessage(ModuleName, ProcName)
        Else
            EventLogger.Log("Connecting to Tws: sending client version", ModuleName, ProcName)
            lwriter.StartMessage()
            lwriter.AddElement(ClientVersion, "Client Version")
            lwriter.SendMessage(ModuleName, ProcName)
        End If

        If Await negotiateConnection() Then
            EventLogger.Log("Connecting to Tws: starting API", ModuleName, ProcName)
            mRegistry.InvokeGenerator(ApiSocketOutMsgType.StartApi, {mClientId, ""})

            If mLogLevel <> 0 Then
                EventLogger.Log("Connecting to Tws: setting TWS log level", ModuleName, ProcName)
                mRegistry.InvokeGenerator(ApiSocketOutMsgType.SetServerLogLevel, {mLogLevel})
            End If

            mConnectedAction.Invoke
            setConnectionState(ApiConnectionState.Connected, ConnectionString)
        End If
    End Sub

#End Region

End Class
