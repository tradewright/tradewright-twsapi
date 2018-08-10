Public Class HistoricalTickDataRequest
    Public Property Contract As Contract
    Public Property StartDateTime As DateTime? = Nothing
    Public Property StartTimezone As String
    Public Property EndDateTime As DateTime? = Nothing
    Public Property EndTimezone As String
    Public Property NumberOfTicks As Integer
    Public Property WhatToShow As String = "TRADES"
End Class
