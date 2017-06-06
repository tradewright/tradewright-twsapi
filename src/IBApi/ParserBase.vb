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

Imports System.Threading.Tasks
Imports TradeWright.IBAPI.ApiException

Friend MustInherit Class ParserBase
    Implements IParser

    Protected _Reader As MessageReader
    Protected _LogSocketInputMessage As Action(Of String, String, Boolean)
    Protected _EventConsumers As ApiEventConsumers
    Protected _IdManager As IdManager

    Private mGetServerVersion As Func(Of Integer)

    Private Sub Initialise(reader As MessageReader, idManager As IdManager, eventConsumers As ApiEventConsumers, getServerVersion As Func(Of Integer), logSocketInputMessage As Action(Of String, String, Boolean)) Implements IParser.Initialise
        _Reader = reader
        _LogSocketInputMessage = logSocketInputMessage
        _EventConsumers = eventConsumers
        _IdManager = idManager
        mGetServerVersion = getServerVersion
    End Sub

    Protected Sub LogSocketInputMessage(moduleName As String, procName As String, Optional ignoreLogLevel As Boolean = False)
        _LogSocketInputMessage(moduleName, procName, ignoreLogLevel)
    End Sub

    Friend MustOverride Async Function ParseAsync(version As Integer, timestamp As Date) As Task(Of Boolean) Implements IParser.ParseAsync

    Protected ReadOnly Property ServerVersion As Integer
        Get
            Return mGetServerVersion()
        End Get
    End Property

    Private Sub SetRegistry(registry As GeneratorAndParserRegistry) Implements IParser.SetRegistry
        registry.RegisterParser(Me, MessageType)
    End Sub

    Friend MustOverride ReadOnly Property MessageType As ApiSocketInMsgType

End Class
