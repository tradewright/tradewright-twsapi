﻿#Region "License"

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

Imports TradeWright.IBAPI.ApiException

Imports System.Threading
Imports System.Threading.Tasks
Imports System.Formats.Asn1

Friend Class ApiConnectionManager

    Private Const ModuleName As String = NameOf(ApiConnectionManager)
    Private Const MaxMessageSize As Integer = 20 * 1024 * 1024
    Private Const ClientVersion As Integer = 66
    Private Const MinReqdServerVersion As Integer = ApiServerVersion.RANDOMIZE_SIZE_AND_PRICE


    Private ReadOnly mServer As String = "127.0.0.1"
    Private ReadOnly mPort As Integer
    Private ReadOnly mClientId As Integer

    Private TheSocketHandler As SocketHandler
    Private mConnectedAction As Action

    Private ReadOnly mUseV100Plus As Boolean

    Private mServerVersion As Integer

    Private ReadOnly mEventConsumers As ApiEventConsumers

    Private mConnectionState As ApiConnectionState = ApiConnectionState.NotConnected

    Private ReadOnly mRegistry As GeneratorAndParserRegistry

    Private mLogLevel As ApiLogLevel = ApiLogLevel.Information

    Private mConnectionRetryIntervalSecs As Integer

    Private ReadOnly mGenerateSocketDataEvents As Boolean


#Region "Constructors"

    Friend Sub New(server As String,
                   port As Integer,
                   clientId As Integer,
                   useV100Plus As Boolean,
                   cancellationSource As CancellationTokenSource,
                   registry As GeneratorAndParserRegistry,
                   eventConsumers As ApiEventConsumers,
                   generateSocketDataEvents As Boolean)
        mServer = server
        mPort = port
        mClientId = clientId
        mUseV100Plus = useV100Plus
        mRegistry = registry
        mEventConsumers = eventConsumers
        mGenerateSocketDataEvents = generateSocketDataEvents

        Dim socket = New SocketManager(mServer, port)
        TheSocketHandler = New SocketHandler(socket,
                                           Sub() setConnectionState(ApiConnectionState.Connecting, ConnectionString),
                                           AddressOf socketHandlerConnected,
                                           Sub(reason) setConnectionState(ApiConnectionState.Failed, $"{reason}: {ConnectionString}"),
                                           Sub(reason) setConnectionState(ApiConnectionState.NotConnected, $"{reason}: {ConnectionString}"),
                                           Sub(reason) setConnectionState(ApiConnectionState.NotConnected, $"{reason}: {ConnectionString}"),
                                           mConnectionRetryIntervalSecs)
        Reader = New MessageReader(New InputStringReader(socket, cancellationSource, MaxMessageSize), mUseV100Plus, mGenerateSocketDataEvents)
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
            If TheSocketHandler IsNot Nothing Then TheSocketHandler.ConnectionRetryIntervalSecs = Value
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

    Friend ReadOnly Property Reader As MessageReader

    Friend ReadOnly Property ServerVersion As Integer
        Get
            Return mServerVersion
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub Connect(connectedAction As Action)
        mConnectedAction = connectedAction
        TheSocketHandler.Connect(keepAlive:=True)
    End Sub

    Friend Function CreateMessageGenerator() As MessageGenerator
        Return TheSocketHandler.CreateMessageGenerator(mUseV100Plus, mGenerateSocketDataEvents)
    End Function

    Friend Sub Disconnect(pReason As String)
        TheSocketHandler?.Disconnect(pReason)
        TheSocketHandler = Nothing
    End Sub

    Friend Sub SetLogLevel(pLogLevel As ApiLogLevel)
        If pLogLevel = 0 Then pLogLevel = ApiLogLevel.System
        If pLogLevel = mLogLevel Then Exit Sub
        If Not [Enum].IsDefined(GetType(ApiLogLevel), pLogLevel) Then Throw New ArgumentException("Invalid TWS log level")

        mLogLevel = pLogLevel

        If mConnectionState <> ApiConnectionState.Connected Then Exit Sub

        If mLogLevel <> 0 Then
            IBAPI.EventLogger.Log("Setting TWS log level", ModuleName, NameOf(SetLogLevel))
            mRegistry.InvokeGenerator(ApiSocketOutMsgType.SetServerLogLevel, {mLogLevel})
        End If
    End Sub

#End Region

#Region "Private Methods"
    Private Function isValidServerVersion() As Boolean
        Return (mUseV100Plus And mServerVersion >= ApiServerVersion.MinV100Plus And mServerVersion <= ApiServerVersion.Max) Or
                ((Not mUseV100Plus) And mServerVersion >= MinReqdServerVersion)
    End Function

    Private Async Function negotiateConnection() As Task(Of Boolean)
        Const ProcName = "negotiateConnection"

        Try
            Await Reader.BeginMessageAsync("IN: ", True)
            mServerVersion = Await Reader.GetIntAsync("Server Version")

            Dim lServerTime = Await Reader.GetStringAsync("TWS Time")
            Reader.LogSocketInputMessage(mEventConsumers.SocketDataConsumer)
            Reader.EndMessage()

            If Not isValidServerVersion() Then
                Dim e = New ApiException(ErrorCodes.TwsOutOfDate, "TWS is out of date and needs to be upgraded")
                IBAPI.EventLogger.Log($"An exception occurred:{vbCrLf}{e}", ModuleName, ProcName, ILogger.LogLevel.Severe)
                mEventConsumers.ErrorAndNotificationConsumer.NotifyException(New ExceptionEventArgs(Date.UtcNow, e))
                Return False
            End If

            IBAPI.EventLogger.Log($"TWS version: {mServerVersion}; TWS Time at connection: {lServerTime}", ModuleName, ProcName)

            Return True
        Catch e As ApiException When e.ErrorCode = ErrorCodes.DataStreamEnded
            Return False
        End Try

    End Function

    Private Sub setConnectionState(pState As ApiConnectionState, pMessage As String)
        If pState = mConnectionState Then Exit Sub
        mConnectionState = pState
        mEventConsumers.ConnectionStatusConsumer?.NotifyAPIConnectionStateChange(New ApiConnectionStateChangeEventArgs(Date.UtcNow, mConnectionState, pMessage, mServer, mPort, mClientId))
    End Sub

    Private Async Sub socketHandlerConnected()
        Const ProcName As String = "socketHandlerConnected"

        Dim lwriter = TheSocketHandler.CreateMessageGenerator(mUseV100Plus, mGenerateSocketDataEvents)
        If mUseV100Plus Then
            IBAPI.EventLogger.Log("Connecting to Tws: negotiating API connection", ModuleName, ProcName)
            lwriter.StartMessage("API")
            lwriter.AddUnterminatedString($"v{CInt(ApiServerVersion.MinV100Plus)}..{CInt(ApiServerVersion.Max)} +PACEAPI", "SupportedServerVersions")
            lwriter.SendMessage(mEventConsumers.SocketDataConsumer)
        Else
            IBAPI.EventLogger.Log("Connecting to Tws: sending client version", ModuleName, ProcName)
            lwriter.StartMessage()
            lwriter.AddInteger(ClientVersion, "Client Version")
            lwriter.SendMessage(mEventConsumers.SocketDataConsumer)
        End If

        If Await negotiateConnection() Then
            IBAPI.EventLogger.Log("Connecting to Tws: starting API", ModuleName, ProcName)
            mRegistry.InvokeGenerator(ApiSocketOutMsgType.StartApi, {mClientId, ""})

            If mLogLevel <> 0 Then
                IBAPI.EventLogger.Log("Connecting to Tws: setting TWS log level", ModuleName, ProcName)
                mRegistry.InvokeGenerator(ApiSocketOutMsgType.SetServerLogLevel, {mLogLevel})
            End If

            mConnectedAction.Invoke
            setConnectionState(ApiConnectionState.Connected, ConnectionString)
        End If
    End Sub

#End Region

End Class
