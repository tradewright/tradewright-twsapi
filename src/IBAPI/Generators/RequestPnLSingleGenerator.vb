Friend Class RequestPnLSingleGeneratorGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, account As String, modelCode As String, conId As Integer)

    Private Const ModuleName As String = NameOf(RequestPnLSingleGeneratorGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestPnLSingleGenerator)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestPnLSingle
        End Get
    End Property

    Private Sub requestPnLSingleGenerator(requestId As Integer, account As String, modelCode As String, conId As Integer)
        Const ProcName As String = NameOf(requestPnLSingleGenerator)

        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.PNL Then Throw New InvalidOperationException("PnL requests not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request Id")
        lWriter.AddElement(account, "Account")
        lWriter.AddElement(modelCode, "Model Code")
        lWriter.AddElement(conId, "Contract Id")

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
