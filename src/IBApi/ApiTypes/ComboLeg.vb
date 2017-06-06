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

Public Class ComboLeg

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

    Private Const ModuleName As String = NameOf(ComboLeg)

    '@================================================================================
    ' Member variables
    '@================================================================================

    Private mConId As Integer
    Private mRatio As Integer
    Private mAction As OrderAction
    Private mExchange As String
    Private mOpenClose As LegOpenCloseCode

    ' for stock legs when doing short sale
    Private mShortSaleSlot As ShortSaleSlotCode
    Private mDesignatedLocation As String
    Private mExemptCode As Integer

    '@================================================================================
    ' Class Event Handlers
    '@================================================================================

    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        mExemptCode = -1
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    '@================================================================================
    ' XXXX Interface Members
    '@================================================================================

    '@================================================================================
    ' XXXX Event Handlers
    '@================================================================================

    '@================================================================================
    ' Properties
    '@================================================================================


    Public Property Action() As OrderAction
        Get
            Action = mAction
        End Get
        Set(value As OrderAction)
            mAction = value
        End Set
    End Property


    Public Property ConId() As Integer
        Get
            ConId = mConId
        End Get
        Set(Value As Integer)
            mConId = Value
        End Set
    End Property


    Public Property DesignatedLocation() As String
        Get
            DesignatedLocation = mDesignatedLocation
        End Get
        Set(Value As String)
            mDesignatedLocation = Value
        End Set
    End Property


    Public Property Exchange() As String
        Get
            Exchange = mExchange
        End Get
        Set(Value As String)
            mExchange = Value
        End Set
    End Property


    Public Property ExemptCode() As Integer
        Get
            ExemptCode = mExemptCode
        End Get
        Set(Value As Integer)
            mExemptCode = Value
        End Set
    End Property


    Public Property OpenClose() As LegOpenCloseCode
        Get
            OpenClose = mOpenClose
        End Get
        Set(value As LegOpenCloseCode)
            mOpenClose = value
        End Set
    End Property


    Public Property Ratio() As Integer
        Get
            Ratio = mRatio
        End Get
        Set(Value As Integer)
            mRatio = Value
        End Set
    End Property


    Public Property ShortSaleSlot() As ShortSaleSlotCode
        Get
            ShortSaleSlot = mShortSaleSlot
        End Get
        Set(value As ShortSaleSlotCode)
            mShortSaleSlot = value
        End Set
    End Property

    '@================================================================================
    ' Methods
    '@================================================================================

    '@================================================================================
    ' Helper Functions
    '@================================================================================
End Class