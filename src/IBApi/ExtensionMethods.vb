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

Imports TradeWright.IBAPI.ApiException

Imports System.Runtime.CompilerServices
Imports System.Globalization

Public Module ExtensionMethods

    <Extension()>
    Friend Function CreateMessageGenerator(socketHandler As SocketHandler, useV100Plus As Boolean, generateSocketDataEvents As Boolean) As MessageGenerator
        Return New MessageGenerator(socketHandler.SocketManager, useV100Plus, IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail), generateSocketDataEvents)
    End Function

    <Extension()>
    Friend Sub LogSocketInputMessage(reader As MessageReader, socketDataConsumer As ISocketDataConsumer, Optional pIgnoreLogLevel As Boolean = False)
        Dim s = ""
        If pIgnoreLogLevel Or IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Or
            (socketDataConsumer IsNot Nothing And reader.GenerateSocketDataEvents) Then
            s = reader.Message
        End If

        If pIgnoreLogLevel Then
            IBAPI.SocketLogger.Log(s, pLogLevel:=ILogger.LogLevel.Normal)
        ElseIf IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Then
            IBAPI.SocketLogger.Log(s, pLogLevel:=ILogger.LogLevel.Detail)
        End If

        If reader.GenerateSocketDataEvents Then socketDataConsumer?.NotifySocketInputMessage(New ApiMessageEventArgs(s))
    End Sub

    <Extension()>
    Friend Sub LogSocketOutputMessage(messageWriter As MessageGenerator, socketDataConsumer As ISocketDataConsumer, Optional ignoreLogLevel As Boolean = False)
        If ignoreLogLevel Then
            IBAPI.SocketLogger.Log(messageWriter.MessageAsStructuredString)
        ElseIf IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.Detail) Then
            IBAPI.SocketLogger.Log(messageWriter.MessageAsStructuredString, pLogLevel:=ILogger.LogLevel.Detail)
        End If

        If messageWriter.GenerateSocketDataEvents Then socketDataConsumer?.NotifySocketOutputMessage(New ApiMessageEventArgs(messageWriter.MessageAsStructuredString))

        If IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.HighDetail) Or
            (messageWriter.GenerateSocketDataEvents And socketDataConsumer IsNot Nothing) Then
            Dim s = messageWriter.MessageAsPrintableBytes
            If IBAPI.SocketLogger.IsLoggable(ILogger.LogLevel.HighDetail) Then IBAPI.SocketLogger.Log(s, pLogLevel:=ILogger.LogLevel.HighDetail)
            If messageWriter.GenerateSocketDataEvents Then socketDataConsumer?.NotifySocketOutputData(New SocketDataEventArgs(s))
        End If
    End Sub

    <Extension()>
    Public Function NullableDecimalFromString(val As String) As Decimal?
        Return If(String.IsNullOrWhiteSpace(val), Nothing, Decimal.Parse(val, CultureInfo.InvariantCulture))
    End Function

    <Extension()>
    Public Function NullableDecimalToString(val As Decimal?, Optional defaultValue As String = Nothing) As String
        If defaultValue Is Nothing Then defaultValue = String.Empty
        Return If(val.HasValue, val.Value.ToString(CultureInfo.InvariantCulture), defaultValue)
    End Function

    <Extension()>
    Public Function NullableDoubleFromString(val As String) As Double?
        Return If(String.IsNullOrWhiteSpace(val), Nothing, If(val = IBAPI.Infinity, Double.PositiveInfinity, Double.Parse(val, CultureInfo.InvariantCulture)))
    End Function

    <Extension()>
    Public Function NullableDoubleToString(val As Double?, Optional defaultValue As String = Nothing) As String
        If defaultValue Is Nothing Then defaultValue = String.Empty
        Return If(val.HasValue, val.Value.ToString(CultureInfo.InvariantCulture), defaultValue)
    End Function

    <Extension()>
    Public Function NullableEnumFromString(Of T As Structure)(val As String) As T?
        Return If(String.IsNullOrWhiteSpace(val), Nothing, [Enum].Parse(Of T)(val))
    End Function

    <Extension()>
    Public Function NullableEnumToString(Of T As Structure)(val As T?, Optional defaultValue As String = Nothing) As String
        If defaultValue Is Nothing Then defaultValue = String.Empty
        Return If(val.HasValue, val.Value.ToString, defaultValue)
    End Function

    <Extension()>
    Public Function NullableIntegerFromString(val As String) As Integer?
        Return If(String.IsNullOrWhiteSpace(val), Nothing, Integer.Parse(val, CultureInfo.InvariantCulture))
    End Function

    <Extension()>
    Public Function NullableIntegerToString(val As Integer?, Optional defaultValue As String = Nothing) As String
        If defaultValue Is Nothing Then defaultValue = String.Empty
        Return If(val.HasValue, val.Value.ToString(CultureInfo.InvariantCulture), defaultValue)
    End Function

    '<Extension()>
    'Public Function ToExternalString(Of TClass As ExtendedEnum(Of UClass as Class, TEnum As {Structure, IConvertible, UClass}))(val As TEnum, extEnum As TClass) As String

    'End Function

    <Extension()>
    Friend Sub SendMessage(writer As MessageGenerator, socketDataConsumer As ISocketDataConsumer, Optional ignoreLogLevel As Boolean = False)
        writer.prepareOutputMessage()
        writer.LogSocketOutputMessage(socketDataConsumer, ignoreLogLevel)
        writer.Send()
    End Sub

End Module
