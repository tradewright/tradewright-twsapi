Friend Class RequestTickByTickDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, contract As Contract, tickType As String, numberOfTicks As Integer, ignoreSize As Boolean)

    Private Const ModuleName As String = NameOf(RequestTickByTickDataGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestTickByTickData)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestTickByTickData
        End Get
    End Property

    Private Sub requestTickByTickData(requestId As Integer, contract As Contract, tickType As String, numberOfTicks As Integer, ignoreSize As Boolean)
        Const ProcName As String = NameOf(requestTickByTickData)

        If mConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.TICK_BY_TICK Then Throw New InvalidOperationException("Tick-by-tick requests not supported")
        If ServerVersion < ApiServerVersion.TICK_BY_TICK_IGNORE_SIZE And (numberOfTicks <> 0 Or ignoreSize) Then Throw New InvalidOperationException("ignoreSize and numberOfTicks parameters not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request Id")
        lWriter.AddElement(contract, "Contract")
        lWriter.AddElement(tickType, "Tick Type")

        If ServerVersion >= ApiServerVersion.TICK_BY_TICK_IGNORE_SIZE Then
            lWriter.AddElement(numberOfTicks, "NumberOfTicks")
            lWriter.AddElement(ignoreSize, "Ignore Size")
        End If

        SendMessage(lWriter, ModuleName, ProcName)
    End Sub

End Class
