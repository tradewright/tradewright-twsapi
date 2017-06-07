Public Interface IApiLoadTestController

    Sub Connect(server As String, clientId As Integer, port As Integer, useLegacyProtocol As Boolean)

    Sub Disconnect()

    Function StartTicker(symbol As String, secType As String, expiry As String, exchange As String, currencyCode As String, primaryExchange As String, multiplier As Integer, marketDepth As Boolean) As Integer

    Sub StopTickers()
End Interface
