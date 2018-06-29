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

Public Enum ApiSocketInMsgType
    TickPrice = 1
    TickSize = 2
    OrderStatus = 3
    [Error] = 4
    OpenOrder = 5
    AccountValue = 6
    PortfolioValue = 7
    AccountTime = 8
    NextValidId = 9
    ContractData = 10
    ExecutionData = 11
    MarketDepth = 12
    MarketDepthL2 = 13
    NewsBulletins = 14
    ManagedAccounts = 15
    FinanialAdvisorData = 16
    HistoricalData = 17
    BondContractData = 18
    ScannerParameters = 19
    ScannerData = 20
    TickOptionComputation = 21
    TickGeneric = 45
    Tickstring = 46
    TickEFP = 47
    CurrentTime = 49
    RealtimeBars = 50
    FundamentalData = 51
    ContractDataEnd = 52
    OpenOrderEnd = 53
    AccountDownloadEnd = 54
    ExecutionDataEnd = 55
    DeltaNeutralValidation = 56
    TickSnapshotEnd = 57
    MarketDataType = 58
    CommissionReport = 59
    Position = 61
    PositionEnd = 62
    AccountSummary = 63
    AccountSummaryEnd = 64
    VerifyMessageApi = 65
    VerifyCompleted = 66
    DisplayGroupList = 67
    DisplayGroupUpdated = 68
    VerifyAndAuthMessageApi = 69
    VerifyAndAuthCompleted = 70
    PositionMulti = 71
    PositionMultiEnd = 72
    AccountUpdateMulti = 73
    AccountUpdateMultiEnd = 74

    ' Messages from here on don't have a version number
    MaxIdWithVersion = AccountUpdateMultiEnd

    SecurityDefinitionOptionParameter = 75
    SecurityDefinitionOptionParameterEnd = 76
    SoftDollarTiers = 77
    FamilyCodes = 78
    SymbolSamples = 79
    MarketDepthExchanges = 80
    TickRequestParams = 81
    SmartComponents = 82
    NewsArticle = 83
    TickNews = 84
    NewsProviders = 85
    HistoricalNews = 86
    HistoricalNewsEnd = 87
    HeadTimestamp = 88
    HistogramData = 89
    HistoricalDataUpdate = 90
    RerouteMarketData = 91
    RerouteMarketDepth = 92
    MarketRule = 93
    PnL = 94
    PnLSingle = 95
    HistoricalTick = 96
    HistoricalTickBidAsk = 97
    HistoricalTickLast = 98
    TickByTick = 99
    OrderBound = 100
    Max = OrderBound
End Enum

