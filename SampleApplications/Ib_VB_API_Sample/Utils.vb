' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.



Imports TradeWright.IBAPI

Friend Module Utils

    '================================================================================
    ' Public Helper Routines
    '================================================================================

    Public Function FaMsgTypeName(faMsgType As FinancialAdvisorDataType) As String
        Return [Enum].GetName(GetType(FinancialAdvisorDataType), faMsgType)
    End Function

    '--------------------------------------------------------------------------------
    ' Returns the tick display string used when adding tick data to the display list.
    '--------------------------------------------------------------------------------
    Public Function GetField(field As TickType) As String
        Return [Enum].GetName(GetType(TickType), field)
    End Function

    Public Function Text2Int(text As String) As Integer
        Dim result = 0
        Integer.TryParse(text, result)
        Return result
    End Function


End Module
