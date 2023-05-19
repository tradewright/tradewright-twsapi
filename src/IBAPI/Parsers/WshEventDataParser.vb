Imports System.Threading.Tasks

Friend NotInheritable Class WshEventDataParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(WshEventDataParser)

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp as date) As Task(Of Boolean)
        Dim requestID = Await _Reader.GetIntAsync("requestId")
        Dim data = Await _Reader.GetStringAsync("Data")
        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.NewsConsumer?.NotifyWshEventData(New WshDataEventArgs(timestamp, requestID, data))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyWshEventData", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.WshEventData
        End Get
    End Property

End Class
