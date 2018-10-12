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

Imports System.Collections
Imports System.Collections.Generic

Public Class ComboLegs
    Implements System.Collections.IEnumerable
    Implements System.Collections.Generic.IEnumerable(Of ComboLeg)

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

    Private Const ModuleName As String = NameOf(ComboLegs)

    '@================================================================================
    ' Member variables
    '@================================================================================

    Private mComboLegs As List(Of ComboLeg) = New List(Of ComboLeg)

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

    Public ReadOnly Property Count() As Integer
        Get
            Count = mComboLegs.Count()
        End Get
    End Property

    '@================================================================================
    ' Methods
    '@================================================================================

    Public Sub Add(pComboLeg As ComboLeg)
        mComboLegs.Add(pComboLeg)
    End Sub

    Public Function Item(pIndex As Integer) As ComboLeg
        Item = mComboLegs.Item(pIndex)
    End Function

    Private Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return mComboLegs.GetEnumerator
    End Function

    Public Function GetEnumerator() As IEnumerator(Of ComboLeg) Implements IEnumerable(Of ComboLeg).GetEnumerator
        Return mComboLegs.GetEnumerator
    End Function

    '@================================================================================
    ' Helper Functions
    '@================================================================================
End Class