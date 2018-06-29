Friend Class RequestHistoricalTickDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, request As HistoricalTickDataRequest, useRTH As Boolean, ignoreSize As Boolean, options As List(Of TagValue))

    Private Const ModuleName As String = NameOf(requestHistoricalTickData)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestHistoricalTickData)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestHistoricalTickData
        End Get
    End Property

    Private Sub requestHistoricalTickData(requestId As Integer, request As HistoricalTickDataRequest, Optional useRTH As Boolean = False, Optional ignoreSize As Boolean = False, Optional options As List(Of TagValue) = Nothing)
        Const ProcName As String = NameOf(requestHistoricalTickData)

        If mConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.HISTORICAL_TICKS Then Throw New InvalidOperationException("Historical tick requests not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request Id")
        lWriter.AddElement(request.Contract, "Contract")
        lWriter.AddElement(If(request.StartDateTime.HasValue, request.StartDateTime.Value.ToString("yyyyMMdd HH:mm:ss"), ""), "StartDateTime")
        lWriter.AddElement(If(request.EndDateTime.HasValue, request.EndDateTime.Value.ToString("yyyyMMdd HH:mm:ss"), ""), "EndDateTime")
        lWriter.AddElement(request.NumberOfTicks, "NumberOfTicks")
        lWriter.AddElement(request.WhatToShow, "WhatToShow")
        lWriter.AddElement(useRTH, "UseRTH")
        lWriter.AddElement(ignoreSize, "IgnoreSize")
        lWriter.AddElement(options, "Options")

        SendMessage(lWriter, ModuleName, ProcName)
    End Sub

End Class
