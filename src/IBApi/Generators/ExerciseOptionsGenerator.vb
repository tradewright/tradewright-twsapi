﻿#Region "License"

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

Friend Class ExerciseOptionsGenerator
    Inherits GeneratorBase
    Implements IGenerator

    Private Delegate Sub ApiMethodDelegate(pTickerId As Integer, pContract As Contract, pExerciseAction As Integer, pExerciseQuantity As Integer, pAccount As String, pOverride As Integer)

    Private Const ModuleName As String = NameOf(ExerciseOptionsGenerator)

    Friend Overrides ReadOnly Property GeneratorDelegate As [Delegate] Implements IGenerator.GeneratorDelegate
        Get
            Return New ApiMethodDelegate(AddressOf ExerciseOptions)
        End Get
    End Property

    Friend Overrides ReadOnly Property MessageType As ApiSocketOutMsgType
        Get
            Return ApiSocketOutMsgType.ExerciseOptions
        End Get
    End Property

    Private Sub ExerciseOptions(pTickerId As Integer, pContract As Contract, pExerciseAction As Integer, pExerciseQuantity As Integer, pAccount As String, pOverride As Integer)
        Const ProcName As String = NameOf(ExerciseOptions)
        If mConnectionState <> ApiConnectionState.Connected Then Throw New InvalidOperationException("Not connected")

        Const VERSION As Integer = 2

        Dim lWriter = CreateOutputMessageGenerator()
        StartMessage(lWriter, ApiSocketOutMsgType.ExerciseOptions)
        lWriter.AddElement(VERSION, "Version")
        lWriter.AddElement(pTickerId, "TickerId")

        lWriter.AddElement(pContract.ConId, "ConId")

        lWriter.AddElement(pContract.Symbol, "Symbol")
        lWriter.AddElement(SecurityTypes.ToInternalString(pContract.SecType), "Sectype")
        lWriter.AddElement(pContract.Expiry, "Expiry")
        lWriter.AddElement(pContract.Strike, "Strike")
        lWriter.AddElement(OptionRights.ToInternalString(pContract.OptRight), "Right")
        lWriter.AddElement(If(pContract.Multiplier = 1, "", CStr(pContract.Multiplier)), "Multiplier")
        lWriter.AddElement(pContract.Exchange, "Exchange")
        lWriter.AddElement(pContract.CurrencyCode, "Currency")
        lWriter.AddElement(UCase(pContract.LocalSymbol), "LocalSymbol")
        lWriter.AddElement(pContract.TradingClass, "TradingClass")

        lWriter.AddElement(pExerciseAction, "ExerciseAction")
        lWriter.AddElement(pExerciseQuantity, "ExerciseQuantity")
        lWriter.AddElement(pAccount, "Account")
        lWriter.AddElement(pOverride, "Override")
        SendMessage(lWriter, ModuleName, ProcName)
    End Sub

End Class