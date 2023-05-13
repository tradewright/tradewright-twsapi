Imports System.Threading.Tasks

Friend NotInheritable Class OrderBoundParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(OrderBoundParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim orderId = Await _Reader.GetLongAsync("Order Id")
        Dim apiClientId = Await _Reader.GetIntAsync("Api Client Id")
        Dim apiOrderId = Await _Reader.GetIntAsync("Api Order Id")

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.OrderInfoConsumer?.NotifyOrderBound(New OrderBoundEventArgs(timestamp, orderId, apiClientId, apiOrderId))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyOrderBound", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.OrderBound
        End Get
    End Property

End Class
