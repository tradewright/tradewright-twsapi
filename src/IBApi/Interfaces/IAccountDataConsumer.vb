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

Public Interface IAccountDataConsumer

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

    Sub EndAccountSummary(e As RequestEndEventArgs)
    Sub EndAccountUpdateMulti(e As RequestEndEventArgs)
    Sub EndAccountValue(e As AccountDownloadEndEventArgs)
    Sub EndPosition(e As EventArgs)
    Sub EndPositionMulti(e As RequestEndEventArgs)
    Sub EndReplaceFA(e As ReplaceFAEndEventArgs)
    Sub NotifyAccountSummary(e As AccountSummaryEventArgs)
    Sub NotifyAccountTime(e As UpdateAccountTimeEventArgs)
    Sub NotifyAccountUpdateMulti(e As AccountUpdateMultiEventArgs)
    Sub NotifyAccountValue(e As UpdateAccountValueEventArgs)
    Sub NotifyAdvisorData(e As AdvisorDataEventArgs)
    Sub NotifyPnL(e As PnLEventArgs)
    Sub NotifyPnLSingle(e As PnLSingleEventArgs)
    Sub NotifyFamilyCodes(e As FamilyCodesEventArgs)
    Sub NotifyManagedAccounts(e As ManagedAccountsEventArgs)
    Sub NotifyPosition(e As PositionEventArgs)
    Sub NotifyPortfolioUpdate(e As UpdatePortfolioEventArgs)
    Sub NotifyPositionMulti(e As PositionMultiEventArgs)
    Sub NotifySoftDollarTiers(e As SoftDollarTiersEventArgs)
    Sub NotifyUserInformation(e As UserInformationEventArgs)

    '@================================================================================
    ' Helper Functions
    '@================================================================================
End Interface