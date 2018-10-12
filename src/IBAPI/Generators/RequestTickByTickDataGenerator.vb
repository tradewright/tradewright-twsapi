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

Friend Class RequestTickByTickDataGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(requestId As Integer, contract As Contract, tickType As TickByTickDataType, numberOfTicks As Integer, ignoreSize As Boolean)

    Private Const ModuleName As String = NameOf(RequestTickByTickDataGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf requestTickByTickData)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.RequestTickByTickData
        End Get
    End Property

    Private Sub requestTickByTickData(requestId As Integer, contract As Contract, tickType As TickByTickDataType, numberOfTicks As Integer, ignoreSize As Boolean)
        Const ProcName As String = NameOf(requestTickByTickData)

        If ConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")
        If ServerVersion < ApiServerVersion.TICK_BY_TICK Then Throw New InvalidOperationException("Tick-by-tick requests not supported")
        If ServerVersion < ApiServerVersion.TICK_BY_TICK_IGNORE_SIZE And (numberOfTicks <> 0 Or ignoreSize) Then Throw New InvalidOperationException("ignoreSize and numberOfTicks parameters not supported")

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, MessageType)

        lWriter.AddElement(requestId, "Request Id")
        lWriter.AddElement(contract, "Contract")
        lWriter.AddElement(IBAPI.TickByTickDataTypes.ToInternalString(tickType), "Tick Type")

        If ServerVersion >= ApiServerVersion.TICK_BY_TICK_IGNORE_SIZE Then
            lWriter.AddElement(numberOfTicks, "NumberOfTicks")
            lWriter.AddElement(ignoreSize, "Ignore Size")
        End If

        lWriter.SendMessage(_EventConsumers.SocketDataConsumer)
    End Sub

End Class