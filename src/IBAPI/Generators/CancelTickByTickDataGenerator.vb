Friend Class CancelTickByTickDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer)

    Private Const ModuleName As String = NameOf(CancelTickByTickDataGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf cancelTickByTickData)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.CancelTickByTickData
        End Get
    End Property

    Private Sub cancelTickByTickData(requestId As Integer)
        Const ProcName As String = NameOf(cancelTickByTickData)

        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.TICK_BY_TICK Then Throw New InvalidOperationException("Tick-by-tick requests not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request Id")

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
