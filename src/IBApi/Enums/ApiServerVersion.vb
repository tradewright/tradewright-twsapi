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

Friend Enum ApiServerVersion
    'SCALE_ORDERS = 60
    'ORDER_COMBO_LEGS_PRICE = 61
    'TRAILING_PERCENT = 62
    'DELTA_NEUTRAL_OPEN_CLOSE = 66
    'ACCT_SUMMARY = 67
    'TRADING_CLASS = 68
    'SCALE_TABLE = 69
    'LINKING = 70
    'ALGO_ID = 71
    'OPTIONAL_CAPABILITIES = 72
    'ORDER_SOLICITED = 73
    'LINKING_AUTH = 74
    'PRIMARYEXCH = 75
    RANDOMIZE_SIZE_AND_PRICE = 76
    MinV100Plus = 100
    FRACTIONAL_POSITIONS = 101
    PEGGED_TO_BENCHMARK = 102
    MODELS_SUPPORT = 103
    SEC_DEF_OPT_PARAMS_REQ = 104
    EXT_OPERATOR = 105
    SOFT_DOLLAR_TIER = 106
    REQ_FAMILY_CODES = 107
    REQ_MATCHING_SYMBOLS = 108
    PAST_LIMIT = 109
    MD_SIZE_MULTIPLIER = 110
    CASH_QTY = 111
    REQ_MKT_DEPTH_EXCHANGES = 112
    TICK_NEWS = 113
    SMART_COMPONENTS = 114
    REQ_NEWS_PROVIDERS = 115
    REQ_NEWS_ARTICLE = 116
    REQ_HISTORICAL_NEWS = 117
    REQ_HEAD_TIMESTAMP = 118
    REQ_HISTOGRAM_DATA = 119
    SERVICE_DATA_TYPE = 120
    AGG_GROUP = 121
    UNDERLYING_INFO = 122
    CANCEL_HEADTIMESTAMP = 123
    SYNT_REALTIME_BARS = 124
    CFD_REROUTE = 125
    MARKET_RULES = 126
    DAILY_PNL = 127
    Max = DAILY_PNL
End Enum

