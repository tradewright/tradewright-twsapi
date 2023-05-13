Friend NotInheritable Class CompletedOrdersEndParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(CompletedOrdersEndParser)

    Friend Overrides Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.OrderInfoConsumer?.EndCompletedOrders(EventArgs.Empty)
            Return Task.FromResult(Of Boolean)(True)
        Catch e As Exception
            Throw New ApiApplicationException("EndCompletedOrders", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.CompletedOrdersEnd
        End Get
    End Property
End Class


