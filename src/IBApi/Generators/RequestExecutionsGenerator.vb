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

Friend Class RequestExecutionsGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(pRequestId As Integer, filter As ExecutionFilter)

    Private Const ModuleName As String = NameOf(RequestExecutionsGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestExecutions)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestExecutions
        End Get
    End Property

    Private Sub requestExecutions(pRequestId As Integer, filter As ExecutionFilter)
        Const ProcName As String = NameOf(requestExecutions)
        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")

        Const VERSION As Integer = 3

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.RequestExecutions)
        lWriter.AddElement(VERSION, "Version")

        lWriter.AddElement(IdManager.GetTwsId(pRequestId, IdType.Execution), "ReqId")

        Dim theFilter As ExecutionFilter
        If ServerVersion >= 9 Then
            If filter Is Nothing Then
                theFilter = New ExecutionFilter
            Else
                theFilter = filter
            End If

            With theFilter
                lWriter.AddElement(.ClientID, "Client id")
                lWriter.AddElement("", "Client id")
                lWriter.AddElement(.AccountCode, "Account code")
                lWriter.AddElement(CStr(If(.Time <> Date.MaxValue, $"{ .Time,0:yyyyMMdd-hh:mm:ss}", "")), "Fill Time")
                lWriter.AddElement(.Symbol?.ToUpper(), "Symbol")
                lWriter.AddElement(IBAPI.SecurityTypes.ToInternalString(.SecType), "Sec type")
                lWriter.AddElement(.Exchange, "Exchange")
                lWriter.AddElement(IBAPI.OrderActions.ToInternalString(.Action), "Action")
            End With
        End If

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class
