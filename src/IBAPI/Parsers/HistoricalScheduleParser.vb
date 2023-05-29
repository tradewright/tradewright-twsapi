Imports System.Threading.Tasks

Friend NotInheritable Class HistoricalScheduleParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(HistoricalScheduleParser)

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp as date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("requestId")
        Dim startDateTime = Await _Reader.GetStringAsync("startDateTime")
        Dim endDateTime = Await _Reader.GetStringAsync("endDateTime")
        Dim timeZone = Await _Reader.GetStringAsync("timeZone")
        Dim sessionsCount = Await _Reader.GetIntAsync("sessionsCount")
        Dim sessions As New List(Of HistoricalSession)
        For i = 0 To sessionsCount - 1
            Dim sessionStartDateTime = Await _Reader.GetStringAsync($"sessionStartDateTime.{i}")
            Dim sessionEndDateTime = Await _Reader.GetStringAsync($"sessionEndDateTime.{i}")
            Dim sessionRefDate = Await _Reader.GetStringAsync($"sessionRefDate.{i}")
            sessions.Add(New HistoricalSession(sessionStartDateTime, sessionEndDateTime, sessionRefDate))
        Next

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.HistoricalDataConsumer?.NotifyHistoricalSchedule(New HistoricalScheduleEventArgs(timestamp, requestId, startDateTime, endDateTime, timeZone, sessions))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyHistoricalSchedule", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.HistoricalSchedule
        End Get
    End Property

End Class
