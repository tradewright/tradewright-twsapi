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

Friend Enum ApiSocketOutMsgType
    RequestMarketData = 1
    CancelMarketData = 2
    PlaceOrder = 3
    CancelOrder = 4
    RequestOpenOrders = 5
    RequestAccountData = 6
    RequestExecutions = 7
    RequestIds = 8
    RequestContractData = 9
    RequestMarketDepth = 10
    CancelMarketDepth = 11
    RequestNewsBulletins = 12
    CancelNewsBulletins = 13
    SetServerLogLevel = 14
    RequestAutoOpenOrders = 15
    RequestAllOpenOrders = 16
    RequestManagedAccounts = 17
    RequestFinancialAdvisorData = 18
    ReplaceFinancialAdvisorData = 19
    RequestHistoricalBars = 20
    ExerciseOptions = 21
    RequestScannerSubscription = 22
    CancelScannerSubscription = 23
    RequestScannerParameters = 24
    CancelHistoricalData = 25
    RequestCurrentTime = 49
    RequestRealtimeBars = 50
    CancelRealtimeBars = 51
    RequestFundamentalData = 52
    CancelFundamentalData = 53
    CalculateImpliedVolatility = 54
    CalculateOptionPrice = 55
    CancelCalculateImpliedVolatility = 56
    CancelCalculateOptionPrice = 57
    RequestGlobalCancel = 58
    RequestMarketDataType = 59
    RequestPositions = 61
    RequestAccountSummary = 62
    CancelAccountSummary = 63
    CancelPositions = 64
    VerifyRequest = 65
    VerifyMessage = 66
    QueryDisplayGroups = 67
    SubscribeToGroupEvents = 68
    UpdateDisplayGroup = 69
    UnsubscribeFromGroupEvents = 70
    StartApi = 71
    VerifyAndAuthRequest = 72
    VerifyAndAuthMessage = 73
    RequestPositionsMulti = 74
    CancelPositionsMulti = 75
    RequestAccountDataMulti = 76
    CancelAccountUpdatesMulti = 77
    RequestSecurityDefinitionOptionParameters = 78
    RequestSoftDollarTiers = 79
    RequestFamilyCodes = 80
    RequestMatchingSymbols = 81
    RequestMarketDepthExchanges = 82
    RequestSmartComponents = 83
    RequestNewsArticle = 84
    RequestNewsProviders = 85
    RequestHistoricalNews = 86
    RequestHeadTimestamp = 87
    RequestHistogramData = 88
    CancelHistogramData = 89
    CancelHeadTimestamp = 90
    RequestMarketRule = 91
    RequestPnL = 92
    CancelPnL = 93
    RequestPnLSingle = 94
    CancelPnLSingle = 95
    RequestHistoricalTickData = 96
    RequestTickByTickData = 97
    CancelTickByTickData = 98
    RequestCompletedOrders = 99
    RequestWshMetaData = 100
    CancelWshMetaData = 101
    RequestWshEventData = 102
    CancelWshEventData = 103
    RequestUserInformation = 104

    Max
End Enum

