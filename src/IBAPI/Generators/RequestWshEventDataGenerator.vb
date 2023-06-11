#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2023 Richard L King (TradeWright Software Systems)
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

#End Region

Friend Class RequestWshEventDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, request As WshEventDataRequest)

    Private Const ModuleName As String = NameOf(RequestWshEventDataGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf RequestWshEventDataGenerator)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestWshEventData
        End Get
    End Property

    Private Sub RequestWshEventDataGenerator(requestId As Integer, request As WshEventDataRequest)
        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.WSHE_CALENDAR Then Throw New InvalidOperationException("WshEventData not supported")
        If ServerVersion < ApiServerVersion.WSH_EVENT_DATA_FILTERS And
            (Not String.IsNullOrEmpty(request.Filter) Or request.FillWatchlist Or request.FillPortfolio Or request.FillCompetitors) Then
            Throw New InvalidOperationException("WshEventData filters not supported")
        End If
        If ServerVersion < ApiServerVersion.WSH_EVENT_DATA_FILTERS_DATE And
                (Not String.IsNullOrEmpty(request.StartDate) Or Not String.IsNullOrEmpty(request.EndDate) Or request.TotalLimit <> Integer.MaxValue) Then
            Throw New InvalidOperationException("WshEventData date filters not supported")
        End If

        Dim writer = CreateOutputMessageGenerator()
        StartMessage(writer, MessageType)
        writer.AddInteger(requestId, "RequestId")
        writer.AddInteger(request.ContractId, "ContractId")

        If ServerVersion >= ApiServerVersion.WSH_EVENT_DATA_FILTERS Then
            writer.AddString(request.Filter, "Filter")
            writer.AddBoolean(request.FillWatchlist, "FillWatchlist")
            writer.AddBoolean(request.FillPortfolio, "FillPortfolio")
            writer.AddBoolean(request.FillCompetitors, "FillCompetitors")
        End If

        If ServerVersion >= ApiServerVersion.WSH_EVENT_DATA_FILTERS_DATE Then
            writer.AddString(request.StartDate, "StartDate")
            writer.AddString(request.EndDate, "EndDate")
            writer.AddInteger(request.TotalLimit, "TotalLimit")
        End If

        writer.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
