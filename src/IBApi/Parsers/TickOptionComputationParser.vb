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

Friend NotInheritable Class TickOptionComputationParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(TickOptionComputationParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim lTickerId = Await _Reader.GetIntAsync("tickerId")
        Dim lTickType = DirectCast(Await _Reader.GetIntAsync("tickType"), TickType)

        Dim lImpliedVol = Await _Reader.GetDoubleAsync("impliedVol")
        If lImpliedVol < 0 Then
            ' -1 is the "not yet computed" indicator
            lImpliedVol = Double.MaxValue
        End If

        Dim lDelta = Await _Reader.GetDoubleAsync("delta")
        If System.Math.Abs(lDelta) > 1 Then
            ' -2 is the "not yet computed" indicator
            lDelta = Double.MaxValue
        End If

        Dim lOptPrice = Double.MaxValue
        Dim lPvDividend = Double.MaxValue
        If pVersion >= 6 Or lTickType = TickType.ModelOption Then ' introduced in pVersion == 5
            lOptPrice = Await _Reader.GetDoubleAsync("optPrice")
            If lOptPrice < 0 Then ' -1 is the "not yet computed" indicator
                lOptPrice = Double.MaxValue
            End If
            lPvDividend = Await _Reader.GetDoubleAsync("pvDividend")
            If lPvDividend < 0 Then ' -1 is the "not yet computed" indicator
                lPvDividend = Double.MaxValue
            End If
        End If

        Dim lGamma = Double.MaxValue
        Dim lVega = Double.MaxValue
        Dim lTheta = Double.MaxValue
        Dim lUndPrice = Double.MaxValue
        If (pVersion >= 6) Then
            lGamma = Await _Reader.GetDoubleAsync("gamma")
            If (System.Math.Abs(lGamma) > 1) Then ' -2 is the "not yet computed" indicator
                lGamma = Double.MaxValue
            End If
            lVega = Await _Reader.GetDoubleAsync("Vega")
            If (System.Math.Abs(lVega) > 1) Then ' -2 is the "not yet computed" indicator
                lVega = Double.MaxValue
            End If
            lTheta = Await _Reader.GetDoubleAsync("theta")
            If (System.Math.Abs(lTheta) > 1) Then ' -2 is the "not yet computed" indicator
                lTheta = Double.MaxValue
            End If
            lUndPrice = Await _Reader.GetDoubleAsync("undPrice")
            If (lUndPrice < 0) Then ' -1 is the "not yet computed" indicator
                lUndPrice = Double.MaxValue
            End If
        End If

        LogSocketInputMessage(ModuleName,"ParseAsync")

        _EventConsumers.MarketDataConsumer?.NotifyTickOptionComputation(New TickOptionComputationEventArgs(timestamp, IdManager.GetCallerId(lTickerId, IdType.MarketData), lTickType, lImpliedVol, lDelta, lOptPrice, lPvDividend, lGamma, lVega, lTheta, lUndPrice))
        Return True
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.TickOptionComputation
        End Get
    End Property

End Class
