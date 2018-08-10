Friend Class RequestPnLGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, account As String, modelCode As String)

    Private Const ModuleName As String = NameOf(RequestPnLGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf reqPnL)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestPnL
        End Get
    End Property

    Private Sub reqPnL(requestId As Integer, account As String, modelCode As String)
        Const ProcName As String = NameOf(reqPnL)

        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.PNL Then Throw New InvalidOperationException("PnL requests not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request Id")
        lWriter.AddElement(account, "Account")
        lWriter.AddElement(modelCode, "Model Code")

       lwriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
