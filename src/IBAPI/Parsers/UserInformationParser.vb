Imports System.Threading.Tasks

Friend NotInheritable Class UserInformationParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(UserInformationParser)

    Friend Overrides Async Function ParseAsync(version As Integer, timestamp as date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("requestId")
        Dim whiteBrandigId = Await _Reader.GetStringAsync("whiteBrandigId")

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.AccountDataConsumer?.NotifyUserInformation(New UserInformationEventArgs(timestamp, requestId, whiteBrandigId))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyUserInformation", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.UserInformation
        End Get
    End Property

End Class
