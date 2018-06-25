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

Imports System.Text

Public Class Contract

    ''
    ' Description here
    '
    '@/

    '@================================================================================
    ' Interfaces
    '@================================================================================

    '@================================================================================
    ' Events
    '@================================================================================

    '@================================================================================
    ' Enums
    '@================================================================================

    '@================================================================================
    ' Types
    '@================================================================================

    '@================================================================================
    ' Constants
    '@================================================================================

    Private Const ModuleName As String = NameOf(Contract)

    '@================================================================================
    ' Member variables
    '@================================================================================

    Public Property ConId As Integer
    Public Property Symbol As String
    Public Property SecType As SecurityType
    Public Property Expiry As String
    Public Property Strike As Double
    Public Property OptRight As OptionRight
    Public Property Multiplier As Integer = 1
    Public Property Exchange As String

    Public Property CurrencyCode As String
    Public Property LocalSymbol As String
    Public Property TradingClass As String
    Public Property PrimaryExch As String ' pick a non-aggregate (ie not the SMART Exchange) Exchange that the contract trades on.  DO NOT SET TO SMART.

    Public Property IncludeExpired As Boolean ' can not be set to true for orders.

    Public Property SecIdType As String ' CUSIP;SEDOL;ISIN;RIC
    Public Property SecId As String

    ' COMBOS
    Public Property ComboLegsDescription As String ' received in open Order version 14 and up for all combos
    Public ReadOnly Property ComboLegs As New ComboLegs

    ' delta neutral
    Public Property UnderComp As UnderComp

    '@================================================================================
    ' Class Event Handlers
    '@================================================================================

    '@================================================================================
    ' XXXX Interface Members
    '@================================================================================

    '@================================================================================
    ' XXXX Event Handlers
    '@================================================================================

    '@================================================================================
    ' Properties
    '@================================================================================


    '@================================================================================
    ' Methods
    '@================================================================================

    Public Overrides Function ToString() As String
        Dim sb As New System.Text.StringBuilder

        addField("Con Id", CStr(ConId), sb)
        addField("Local Symbol", LocalSymbol, sb)
        addField("Symbol", Symbol, sb)
        addField("Sec Type", SecurityTypes.ToInternalString(SecType), sb)
        addField("Expiry", Expiry, sb)
        addField("Exchange", Exchange, sb)
        addField("Currency", CurrencyCode, sb)
        addField("Strike", CStr(Strike), sb)
        addField("Right", OptionRights.ToExternalString(OptRight), sb)
        addField("Multiplier", CStr(Multiplier), sb)
        addField("Primary exchange", PrimaryExch, sb)
        addField("Sec id type", SecIdType, sb)
        addField("Sec id", SecId, sb)

        Dim lLeg As ComboLeg
        Dim i As Integer
        If ComboLegs.Count > 0 Then
            addField("Combo legs count", CStr(ComboLegs.Count), sb)
            For Each lLeg In ComboLegs
                i = i + 1
                addField("Con id " & i, CStr(lLeg.ConId), sb)
                addField("Exchange " & i, lLeg.Exchange, sb)
                addField("Action " & i, OrderActions.ToInternalString(lLeg.Action), sb)
                addField("Ratio " & i, CStr(lLeg.Ratio), sb)
                addField("Open/close " & i, CStr(If(lLeg.OpenClose = LegOpenCloseCode.Same, "", CStr(lLeg.OpenClose))), sb)
                addField("Designated location " & i, lLeg.DesignatedLocation, sb)
                addField("Short sale slot " & i, CStr(If(lLeg.ShortSaleSlot = ShortSaleSlotCode.NotApplicable, "", CStr(lLeg.ShortSaleSlot))), sb)
            Next lLeg
        End If

        If UnderComp?.ConId <> 0 Then
            addField("Under con id", CStr(UnderComp.ConId), sb)
            addField("Under delta", CStr(UnderComp.Delta), sb)
            addField("Under price", CStr(UnderComp.Price), sb)
        End If

        Return sb.ToString
    End Function

    '@================================================================================
    ' Helper Functions
    '@================================================================================

    Private Sub addField(pName As String, pValue As String, sb As StringBuilder)
        If pValue = "" Then Exit Sub

        sb.Append(pName)
        sb.Append(": ")
        sb.Append(pValue)
        sb.Append("; ")
    End Sub

End Class