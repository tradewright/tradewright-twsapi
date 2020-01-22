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

Imports System.Collections.Generic
Imports System.Threading.Tasks

Friend NotInheritable Class FamilyCodesParser
    Inherits ParserBase
    Implements IParser

    Private Const ModuleName As String = NameOf(FamilyCodesParser)

    Friend Overrides Async Function ParseAsync(pVersion As Integer, timestamp As Date) As Task(Of Boolean)
        Dim familyCodes = New List(Of FamilyCode)
        Dim familyCodesCount = Await _Reader.GetIntAsync("Family Codes Count")

        For i = 1 To familyCodesCount
            familyCodes.Add(New FamilyCode(Await _Reader.GetStringAsync("AccountId"), Await _Reader.GetStringAsync("Family Code")))
        Next

        LogSocketInputMessage(ModuleName, "ParseAsync")

        Try
        _EventConsumers.AccountDataConsumer?.NotifyFamilyCodes(New FamilyCodesEventArgs(timestamp, familyCodes))
        Return True
            Catch e As Exception
                Throw New ApiApplicationException("NotifyFamilyCodes", e)
            End Try
    End Function

    Friend Overrides ReadOnly Property MessageType As ApiSocketInMsgType
        Get
            Return ApiSocketInMsgType.FamilyCodes
        End Get
    End Property

End Class
