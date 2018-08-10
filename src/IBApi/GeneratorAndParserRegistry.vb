#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2017 Richard L King (TradeWright Software Systems)
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

Imports TradeWright.IBAPI.ApiException

Friend NotInheritable Class GeneratorAndParserRegistry
    Private ReadOnly mParsers(ApiSocketInMsgType.Max) As IParser
    Private ReadOnly mGenerators(ApiSocketOutMsgType.Max) As [Delegate]

    Private mReader As MessageReader
    Private mEventConsumers As ApiEventConsumers
    Private mIdManager As IdManager

    Private mLogSocketInputMessage As Action(Of String, String, Boolean)
    Private mGetServerVersion As Func(Of Integer)
    Private mCreateOutputMessageGenerator As Func(Of MessageGenerator)
    Private mGetConnectionState As Func(Of ApiConnectionState)

    Friend Sub Initialise(idManager As IdManager,
                          eventConsumers As ApiEventConsumers,
                          reader As MessageReader,
                          logSocketInputMessage As Action(Of String, String, Boolean),
                          getServerVersion As Func(Of Integer),
                          createOutputMessageGenerator As Func(Of MessageGenerator),
                          getConnectionState As Func(Of ApiConnectionState))
        mIdManager = idManager
        mEventConsumers = eventConsumers
        mReader = reader
        mLogSocketInputMessage = logSocketInputMessage
        mGetServerVersion = getServerVersion
        mCreateOutputMessageGenerator = createOutputMessageGenerator
        mGetConnectionState = getConnectionState
    End Sub

    Friend Sub InvokeGenerator(messageType As ApiSocketOutMsgType, params() As Object)
        Try
            getGeneratorDelegate(messageType).DynamicInvoke(params)
        Catch e As Exception
            mEventConsumers.ErrorAndNotificationConsumer.NotifyException(New ExceptionEventArgs(Date.UtcNow, e))
            Throw
        End Try
    End Sub

    Friend Sub RegisterParser(parser As IParser, messageType As ApiSocketInMsgType)
        If mParsers(messageType) IsNot Nothing Then Throw New InvalidOperationException($"Parser already registered for message type {messageType}")
        mParsers(messageType) = parser
        parser.Initialise(mReader, mIdManager, mEventConsumers, mGetServerVersion, mLogSocketInputMessage)
    End Sub

    Friend Sub RegisterGenerator(generator As IGenerator, messageType As ApiSocketOutMsgType)
        If mGenerators(messageType) IsNot Nothing Then Throw New InvalidOperationException($"Generator already registered for message type {messageType}")
        mGenerators(messageType) = generator.GeneratorDelegate
        generator.Initialise(mIdManager, mEventConsumers, mGetServerVersion, mCreateOutputMessageGenerator, mGetConnectionState)
    End Sub

    Friend Function GetParser(messageType As ApiSocketInMsgType) As IParser
        Return mParsers(messageType)
    End Function

    Private Function getGeneratorDelegate(messageType As ApiSocketOutMsgType) As [Delegate]
        Return mGenerators(messageType)
    End Function

End Class
