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

    '@================================================================================
    ' Member variables
    '@================================================================================

    Public Property ContractId As Integer
    Public Property Symbol As String
    Public Property SecurityType As SecurityType
    Public Property Expiry As String
    Public Property Strike As Double
    Public Property OptionRight As OptionRight
    Public Property Multiplier As Double = 1
    Public Property Exchange As String

    Public Property CurrencyCode As String
    Public Property LocalSymbol As String
    Public Property TradingClass As String

    ' only relevant when Exchange is SMART and there are SMART routers in more
    ' than one country (eg try IBM in Tws)
    Public Property PrimaryExch As String

    ' COMBOS
    Public Property ComboLegsDescription As String ' received in open Order version 14 and up for all combos
    Public ReadOnly Property ComboLegs As New ComboLegs

    ' delta neutral
    Public Property DeltaNeutralContract As DeltaNeutralContract


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

        addField("Con Id", CStr(ContractId), sb)
        addField("Local Symbol", LocalSymbol, sb)
        addField("Symbol", Symbol, sb)
        addField("Sec Type", IBAPI.SecurityTypes.ToInternalString(SecurityType), sb)
        addField("Expiry", Expiry, sb)
        addField("Exchange", Exchange, sb)
        addField("Currency", CurrencyCode, sb)
        addField("Strike", CStr(Strike), sb)
        addField("Right", IBAPI.OptionRights.ToExternalString(OptionRight), sb)
        addField("Multiplier", CStr(Multiplier), sb)
        addField("Primary exchange", PrimaryExch, sb)

        Dim lLeg As ComboLeg
        Dim i As Integer
        If ComboLegs.Count > 0 Then
            addField("Combo legs count", CStr(ComboLegs.Count), sb)
            For Each lLeg In ComboLegs
                i += 1
                addField("Con id " & i, CStr(lLeg.ContractId), sb)
                addField("Exchange " & i, lLeg.Exchange, sb)
                addField("Action " & i, IBAPI.OrderActions.ToInternalString(lLeg.Action), sb)
                addField("Ratio " & i, CStr(lLeg.Ratio), sb)
                addField("Open/close " & i, CStr(If(lLeg.OpenClose = LegOpenCloseCode.Same, "", CStr(lLeg.OpenClose))), sb)
                addField("Designated location " & i, lLeg.DesignatedLocation, sb)
                addField("Short sale slot " & i, CStr(If(lLeg.ShortSaleSlot = ShortSaleSlotCode.NotApplicable, "", CStr(lLeg.ShortSaleSlot))), sb)
            Next lLeg
        End If

        If DeltaNeutralContract?.ContractId <> 0 Then
            addField("Under con id", CStr(DeltaNeutralContract.ContractId), sb)
            addField("Under delta", CStr(DeltaNeutralContract.Delta), sb)
            addField("Under price", CStr(DeltaNeutralContract.Price), sb)
        End If

        Return sb.ToString
    End Function

    '@================================================================================
    ' Helper Functions
    '@================================================================================

    Private Shared Sub addField(pName As String, pValue As String, sb As StringBuilder)
        If pValue = "" Then Exit Sub

        sb.Append(pName)
        sb.Append(": ")
        sb.Append(pValue)
        sb.Append("; ")
    End Sub

End Class