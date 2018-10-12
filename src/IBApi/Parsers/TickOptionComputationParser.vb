#Region "License"

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

Friend NotInheritable Class TickOptionComputationParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(TickOptionComputationParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lTickerId = Await _Reader.GetIntAsync("tickerId")
        Dim lTickType = DirectCast(Await _Reader.GetIntAsync("tickType"), TickType)

        Dim lImpliedVol? = Await _Reader.GetDoubleAsync("impliedVol")
        If lImpliedVol = -1 Then
            ' -1 is the "not yet computed" indicator
            lImpliedVol = Nothing
        End If

        Dim lDelta? = Await _Reader.GetDoubleAsync("delta")
        If lDelta = -2 Then
            ' -2 is the "not yet computed" indicator
            lDelta = Nothing
        End If

        Dim lOptPrice As Double?
        Dim lPvDividend As Double?
        If pVersion >= 6 Or lTickType = TickType.ModelOption Or lTickType = TickType.DelayedModelOption Then ' introduced in pVersion == 5
            lOptPrice = Await _Reader.GetDoubleAsync("optPrice")
            If lOptPrice < 0 Then ' -1 is the "not yet computed" indicator
                lOptPrice = Nothing
            End If
            lPvDividend = Await _Reader.GetDoubleAsync("pvDividend")
            If lPvDividend < 0 Then ' -1 is the "not yet computed" indicator
                lPvDividend = Nothing
            End If
        End If

        Dim lGamma As Double?
        Dim lVega As Double?
        Dim lTheta As Double?
        Dim lUndPrice As Double?
        If (pVersion >= 6) Then
            lGamma = Await _Reader.GetDoubleAsync("gamma")
            If lGamma = -2 Then ' -2 is the "not yet computed" indicator
                lGamma = Nothing
            End If
            lVega = Await _Reader.GetDoubleAsync("Vega")
            If lVega = -2 Then ' -2 is the "not yet computed" indicator
                lVega = Nothing
            End If
            lTheta = Await _Reader.GetDoubleAsync("theta")
            If lTheta = -2 Then ' -2 is the "not yet computed" indicator
                lTheta = Nothing
            End If
            lUndPrice = Await _Reader.GetDoubleAsync("undPrice")
            If lUndPrice = -1 Then ' -1 is the "not yet computed" indicator
                lUndPrice = Double.MaxValue
            End If
        End If

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
            _EventConsumers.MarketDataConsumer?.NotifyTickOptionComputation(
                New TickOptionComputationEventArgs(timestamp,
                                                   IdManager.GetCallerId(lTickerId, IdType.MarketData),
                                                   lTickType,
                                                   lImpliedVol,
                                                   lDelta,
                                                   lOptPrice,
                                                   lPvDividend,
                                                   lGamma,
                                                   lVega,
                                                   lTheta,
                                                   lUndPrice))
            Return True
        Catch e As Exception
            Throw New ApiApplicationException("NotifyTickOptionComputation", e)
        End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.TickOptionComputation
        End Get
    End Property

End Class
