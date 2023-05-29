Friend Class RequestUserInformationGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer)

    Private Const ModuleName As String = NameOf(RequestUserInformationGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf RequestUserInformation)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestUserInformation
        End Get
    End Property

    Private Sub RequestUserInformation(requestId As Integer)

        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.USER_INFO Then Throw New InvalidOperationException("User Information not supported")

        Dim writer = CreateOutputMessageGenerator()
        StartMessage(writer, MessageType)
        writer.AddInteger(requestId, "RequestId")

        writer.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
