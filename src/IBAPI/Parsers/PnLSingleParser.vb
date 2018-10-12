﻿#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2018 Richard L King (TradeWright Software Systems)
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

Friend NotInheritable Class PnLSingleParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(PnLSingleParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim requestId = Await _Reader.GetIntAsync("Request Id")
        Dim position = Await _Reader.GetIntAsync("Position")
        Dim pnl = Await _Reader.GetDoubleAsync("PnL")
        Dim unrealizedPnL? = If(ServerVersion >= ApiServerVersion.UNREALIZED_PNL, Await _Reader.GetDoubleAsync("Unrealized PnL"), Nothing)
        Dim realizedPnL? = If(ServerVersion >= ApiServerVersion.REALIZED_PNL, Await _Reader.GetDoubleAsync("Realized PnL"), Nothing)
        Dim value = Await _Reader.GetDoubleAsync("Value")

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.AccountDataConsumer?.NotifyPnLSingle(New PnLSingleEventArgs(timestamp, requestId, position, pnl, unrealizedPnL, realizedPnL, value))
            Return True
            Catch e As Exception
            Throw New ApiApplicationException("NotifyPnLSingle", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.PnLSingle
        End Get
    End Property

End Class