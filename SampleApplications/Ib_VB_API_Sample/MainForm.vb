' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict On


Imports System.Xml
Imports System.Collections.Generic

Imports TradeWright.IBAPI
Imports TradeWright.Utilities.DataStorage
Imports TradeWright.Utilities.Logging
Imports TradeWright.UI.Themes
Imports System.ComponentModel

Friend Class MainForm
    Inherits System.Windows.Forms.Form

#Region "Windows Form Designer generated code "
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            If Not mComponents Is Nothing Then
                mComponents.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private mComponents As System.ComponentModel.IContainer
    Public WithEvents ReqHistoricalDataButton As System.Windows.Forms.Button
    Public WithEvents FinancialAdvisorButton As System.Windows.Forms.Button
    Public WithEvents ReqAllOpenOrdersButton As System.Windows.Forms.Button
    Public WithEvents ReqAutoOpenOrdersButton As System.Windows.Forms.Button
    Public WithEvents ServerLogLevelButton As System.Windows.Forms.Button
    Public WithEvents ReqNewsButton As System.Windows.Forms.Button
    Public WithEvents ReqAcctDataButton As System.Windows.Forms.Button
    Public WithEvents ReqExecutionsButton As System.Windows.Forms.Button
    Public WithEvents ClearFormButton As TradeWright.UI.Themes.ThemedButton1
    Public WithEvents CancelMktDepthButton As System.Windows.Forms.Button
    Public WithEvents PlaceOrderButton As System.Windows.Forms.Button
    Public WithEvents CancelOrderButton As System.Windows.Forms.Button
    Public WithEvents ExtendedOrderAtribsButton As System.Windows.Forms.Button
    Public WithEvents ReqContractDataButton As System.Windows.Forms.Button
    Public WithEvents ReqOpenOrdersButton As System.Windows.Forms.Button
    Public WithEvents ConnectDisconnectButton As TradeWright.UI.Themes.ThemedButton1
    Public WithEvents ReqAcctsButton As System.Windows.Forms.Button
    Public WithEvents ExerciseOptionsButton As System.Windows.Forms.Button
    Public WithEvents CancelHistDataButton As System.Windows.Forms.Button
    Public WithEvents ReqRealTimeBarsButton As System.Windows.Forms.Button
    Public WithEvents CancelRealTimeBarsButton As System.Windows.Forms.Button
    Public WithEvents ReqCurrentTimeButton As System.Windows.Forms.Button
    Public WithEvents WhatIfButton As System.Windows.Forms.Button
    Friend WithEvents CalcImpliedVolatilityButton As System.Windows.Forms.Button
    Friend WithEvents CalcOptionPriceButton As System.Windows.Forms.Button
    Friend WithEvents CancelCalcImpliedVolatilityButton As System.Windows.Forms.Button
    Friend WithEvents CancelCalcOptionPriceButton As System.Windows.Forms.Button
    Friend WithEvents ReqGlobalCancelButton As System.Windows.Forms.Button
    Friend WithEvents ReqMarketDataTypeButton As System.Windows.Forms.Button
    Friend WithEvents ReqPositionsButton As System.Windows.Forms.Button
    Friend WithEvents ReqAccountSummaryButton As System.Windows.Forms.Button
    Friend WithEvents CancelAccountSummaryButton As System.Windows.Forms.Button
    Friend WithEvents CancelPositionsButton As System.Windows.Forms.Button
    Friend WithEvents GroupsButton As System.Windows.Forms.Button
    Friend WithEvents ReqFundamentalDataButton As System.Windows.Forms.Button
    Friend WithEvents CancelFundamentalDataButton As System.Windows.Forms.Button
    Friend WithEvents ReqPositionsMultiButton As System.Windows.Forms.Button
    Friend WithEvents CancelPositionsMultiButton As System.Windows.Forms.Button
    Friend WithEvents ReqAccountUpdatesMultiButton As System.Windows.Forms.Button
    Friend WithEvents CancelAccountUpdatesMultiButton As System.Windows.Forms.Button
    Friend WithEvents ReqSecDefOptParamsButton As System.Windows.Forms.Button
    Friend WithEvents FamilyCodesButton As System.Windows.Forms.Button
    Friend WithEvents ReqMatchingSymbolsButton As System.Windows.Forms.Button
    Friend WithEvents ReqMktDepthExchangesButton As System.Windows.Forms.Button
    Friend WithEvents ReqTickByTickButton As Button
    Friend WithEvents ReqHistoricalTicksButton As Button
    Friend WithEvents ReqPnlSingleButton As Button
    Friend WithEvents ReqPnlButton As Button
    Friend WithEvents ReqHistogramDataButton As Button
    Friend WithEvents ReqHistoricalNewsButton As Button
    Friend WithEvents ReqSmartComponentsButton As Button
    Friend WithEvents CancelTickByTickButton As Button
    Friend WithEvents CancelPnlSingleButton As Button
    Public WithEvents CancelPnlButton As Button
    Friend WithEvents ReqMarketRuleButton As Button
    Public WithEvents ReqHeadTimestampButton As Button
    Friend WithEvents ReqNewsArticleButton As Button
    Friend WithEvents ReqNewsProvidersButton As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Private WithEvents ConnectionStatusLabel As Label
    Friend WithEvents SplitContainer4 As SplitContainer
    Private WithEvents Label13 As Label
    Friend WithEvents DisplaySocketDataCheck As CheckBox
    Friend WithEvents UseQueueingCheck As CheckBox
    Friend WithEvents ErrorsText As TextBox
    Friend WithEvents SocketLogText As TextBox
    Friend WithEvents Label1 As ThemedLabel1
    Friend WithEvents Label4 As ThemedLabel1
    Friend WithEvents ServerResponsesText As TextBox
    Friend WithEvents MarketDataText As TextBox
    Friend WithEvents Label2 As ThemedLabel1
    Friend WithEvents ButtonsPanel As TableLayoutPanel
    Public WithEvents ReqMktDepthButton As Button
    Public WithEvents ReqMktDataButton As Button
    Public WithEvents CancelMktDataButton As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ThemedLabel11 As ThemedLabel1
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TopPanel As TableLayoutPanel
    Friend WithEvents TopPanelCheckboxesSite As TableLayoutPanel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ApiDetailsPanel As TableLayoutPanel
    Private WithEvents Label15 As Label
    Private WithEvents Label14 As Label
    Private WithEvents ClientIdText As TextBox
    Friend WithEvents ServerText As TextBox
    Private WithEvents PortText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DisplayApiMessageStatisticsCheck As CheckBox
    Friend WithEvents DisplaySocketMessagesCheck As CheckBox
    Public WithEvents PauseAPIButton As ThemedButton1
    Public WithEvents ScannerButton As System.Windows.Forms.Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ReqHistoricalDataButton = New System.Windows.Forms.Button()
        Me.FinancialAdvisorButton = New System.Windows.Forms.Button()
        Me.ReqAcctsButton = New System.Windows.Forms.Button()
        Me.ReqAllOpenOrdersButton = New System.Windows.Forms.Button()
        Me.ReqAutoOpenOrdersButton = New System.Windows.Forms.Button()
        Me.ServerLogLevelButton = New System.Windows.Forms.Button()
        Me.ReqNewsButton = New System.Windows.Forms.Button()
        Me.ReqAcctDataButton = New System.Windows.Forms.Button()
        Me.ReqExecutionsButton = New System.Windows.Forms.Button()
        Me.ClearFormButton = New TradeWright.UI.Themes.ThemedButton1()
        Me.CancelMktDepthButton = New System.Windows.Forms.Button()
        Me.PlaceOrderButton = New System.Windows.Forms.Button()
        Me.CancelOrderButton = New System.Windows.Forms.Button()
        Me.ExtendedOrderAtribsButton = New System.Windows.Forms.Button()
        Me.ReqContractDataButton = New System.Windows.Forms.Button()
        Me.ReqOpenOrdersButton = New System.Windows.Forms.Button()
        Me.ConnectDisconnectButton = New TradeWright.UI.Themes.ThemedButton1()
        Me.ExerciseOptionsButton = New System.Windows.Forms.Button()
        Me.CancelHistDataButton = New System.Windows.Forms.Button()
        Me.ScannerButton = New System.Windows.Forms.Button()
        Me.ReqRealTimeBarsButton = New System.Windows.Forms.Button()
        Me.CancelRealTimeBarsButton = New System.Windows.Forms.Button()
        Me.ReqCurrentTimeButton = New System.Windows.Forms.Button()
        Me.WhatIfButton = New System.Windows.Forms.Button()
        Me.CalcImpliedVolatilityButton = New System.Windows.Forms.Button()
        Me.CalcOptionPriceButton = New System.Windows.Forms.Button()
        Me.CancelCalcImpliedVolatilityButton = New System.Windows.Forms.Button()
        Me.CancelCalcOptionPriceButton = New System.Windows.Forms.Button()
        Me.ReqGlobalCancelButton = New System.Windows.Forms.Button()
        Me.ReqMarketDataTypeButton = New System.Windows.Forms.Button()
        Me.ReqPositionsButton = New System.Windows.Forms.Button()
        Me.ReqAccountSummaryButton = New System.Windows.Forms.Button()
        Me.CancelAccountSummaryButton = New System.Windows.Forms.Button()
        Me.CancelPositionsButton = New System.Windows.Forms.Button()
        Me.GroupsButton = New System.Windows.Forms.Button()
        Me.ReqFundamentalDataButton = New System.Windows.Forms.Button()
        Me.CancelFundamentalDataButton = New System.Windows.Forms.Button()
        Me.ReqPositionsMultiButton = New System.Windows.Forms.Button()
        Me.CancelPositionsMultiButton = New System.Windows.Forms.Button()
        Me.ReqAccountUpdatesMultiButton = New System.Windows.Forms.Button()
        Me.CancelAccountUpdatesMultiButton = New System.Windows.Forms.Button()
        Me.ReqSecDefOptParamsButton = New System.Windows.Forms.Button()
        Me.FamilyCodesButton = New System.Windows.Forms.Button()
        Me.ReqMatchingSymbolsButton = New System.Windows.Forms.Button()
        Me.ReqMktDepthExchangesButton = New System.Windows.Forms.Button()
        Me.ReqTickByTickButton = New System.Windows.Forms.Button()
        Me.ReqHistoricalTicksButton = New System.Windows.Forms.Button()
        Me.ReqPnlSingleButton = New System.Windows.Forms.Button()
        Me.ReqPnlButton = New System.Windows.Forms.Button()
        Me.ReqHistogramDataButton = New System.Windows.Forms.Button()
        Me.ReqHistoricalNewsButton = New System.Windows.Forms.Button()
        Me.ReqSmartComponentsButton = New System.Windows.Forms.Button()
        Me.CancelTickByTickButton = New System.Windows.Forms.Button()
        Me.CancelPnlSingleButton = New System.Windows.Forms.Button()
        Me.CancelPnlButton = New System.Windows.Forms.Button()
        Me.ReqMarketRuleButton = New System.Windows.Forms.Button()
        Me.ReqHeadTimestampButton = New System.Windows.Forms.Button()
        Me.ReqNewsArticleButton = New System.Windows.Forms.Button()
        Me.ReqNewsProvidersButton = New System.Windows.Forms.Button()
        Me.ConnectionStatusLabel = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ButtonsPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ReqMktDataButton = New System.Windows.Forms.Button()
        Me.CancelMktDataButton = New System.Windows.Forms.Button()
        Me.ReqMktDepthButton = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ServerResponsesText = New System.Windows.Forms.TextBox()
        Me.ThemedLabel11 = New TradeWright.UI.Themes.ThemedLabel1()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.MarketDataText = New System.Windows.Forms.TextBox()
        Me.Label4 = New TradeWright.UI.Themes.ThemedLabel1()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.ErrorsText = New System.Windows.Forms.TextBox()
        Me.Label2 = New TradeWright.UI.Themes.ThemedLabel1()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.SocketLogText = New System.Windows.Forms.TextBox()
        Me.Label1 = New TradeWright.UI.Themes.ThemedLabel1()
        Me.TopPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.PauseAPIButton = New TradeWright.UI.Themes.ThemedButton1()
        Me.TopPanelCheckboxesSite = New System.Windows.Forms.TableLayoutPanel()
        Me.DisplayApiMessageStatisticsCheck = New System.Windows.Forms.CheckBox()
        Me.DisplaySocketMessagesCheck = New System.Windows.Forms.CheckBox()
        Me.UseQueueingCheck = New System.Windows.Forms.CheckBox()
        Me.DisplaySocketDataCheck = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ApiDetailsPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ClientIdText = New System.Windows.Forms.TextBox()
        Me.ServerText = New System.Windows.Forms.TextBox()
        Me.PortText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ButtonsPanel.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TopPanel.SuspendLayout()
        Me.TopPanelCheckboxesSite.SuspendLayout()
        Me.ApiDetailsPanel.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReqHistoricalDataButton
        '
        Me.ReqHistoricalDataButton.AutoSize = True
        Me.ReqHistoricalDataButton.Location = New System.Drawing.Point(3, 65)
        Me.ReqHistoricalDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistoricalDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistoricalDataButton.Name = "ReqHistoricalDataButton"
        Me.ReqHistoricalDataButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqHistoricalDataButton.TabIndex = 4
        Me.ReqHistoricalDataButton.Text = "Historical Data..."
        '
        'FinancialAdvisorButton
        '
        Me.FinancialAdvisorButton.AutoSize = True
        Me.FinancialAdvisorButton.Location = New System.Drawing.Point(3, 499)
        Me.FinancialAdvisorButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.FinancialAdvisorButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.FinancialAdvisorButton.Name = "FinancialAdvisorButton"
        Me.FinancialAdvisorButton.Size = New System.Drawing.Size(133, 25)
        Me.FinancialAdvisorButton.TabIndex = 31
        Me.FinancialAdvisorButton.Text = "Financial Advisor"
        '
        'ReqAcctsButton
        '
        Me.ReqAcctsButton.AutoSize = True
        Me.ReqAcctsButton.Location = New System.Drawing.Point(158, 468)
        Me.ReqAcctsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqAcctsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqAcctsButton.Name = "ReqAcctsButton"
        Me.ReqAcctsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqAcctsButton.TabIndex = 30
        Me.ReqAcctsButton.Text = "Req Accounts"
        '
        'ReqAllOpenOrdersButton
        '
        Me.ReqAllOpenOrdersButton.AutoSize = True
        Me.ReqAllOpenOrdersButton.Location = New System.Drawing.Point(3, 375)
        Me.ReqAllOpenOrdersButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqAllOpenOrdersButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqAllOpenOrdersButton.Name = "ReqAllOpenOrdersButton"
        Me.ReqAllOpenOrdersButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqAllOpenOrdersButton.TabIndex = 24
        Me.ReqAllOpenOrdersButton.Text = "Req All Open Orders"
        '
        'ReqAutoOpenOrdersButton
        '
        Me.ReqAutoOpenOrdersButton.AutoSize = True
        Me.ReqAutoOpenOrdersButton.Location = New System.Drawing.Point(158, 375)
        Me.ReqAutoOpenOrdersButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqAutoOpenOrdersButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqAutoOpenOrdersButton.Name = "ReqAutoOpenOrdersButton"
        Me.ReqAutoOpenOrdersButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqAutoOpenOrdersButton.TabIndex = 25
        Me.ReqAutoOpenOrdersButton.Text = "Req Auto Open Orders"
        '
        'ServerLogLevelButton
        '
        Me.ServerLogLevelButton.AutoSize = True
        Me.ServerLogLevelButton.Location = New System.Drawing.Point(3, 468)
        Me.ServerLogLevelButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ServerLogLevelButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ServerLogLevelButton.Name = "ServerLogLevelButton"
        Me.ServerLogLevelButton.Size = New System.Drawing.Size(133, 25)
        Me.ServerLogLevelButton.TabIndex = 29
        Me.ServerLogLevelButton.Text = "Log Configuration..."
        '
        'ReqNewsButton
        '
        Me.ReqNewsButton.AutoSize = True
        Me.ReqNewsButton.Location = New System.Drawing.Point(158, 437)
        Me.ReqNewsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqNewsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqNewsButton.Name = "ReqNewsButton"
        Me.ReqNewsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqNewsButton.TabIndex = 28
        Me.ReqNewsButton.Text = "Req News Bulletins..."
        '
        'ReqAcctDataButton
        '
        Me.ReqAcctDataButton.AutoSize = True
        Me.ReqAcctDataButton.Location = New System.Drawing.Point(3, 406)
        Me.ReqAcctDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqAcctDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqAcctDataButton.Name = "ReqAcctDataButton"
        Me.ReqAcctDataButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqAcctDataButton.TabIndex = 26
        Me.ReqAcctDataButton.Text = "Req Acct Data..."
        '
        'ReqExecutionsButton
        '
        Me.ReqExecutionsButton.AutoSize = True
        Me.ReqExecutionsButton.Location = New System.Drawing.Point(158, 406)
        Me.ReqExecutionsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqExecutionsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqExecutionsButton.Name = "ReqExecutionsButton"
        Me.ReqExecutionsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqExecutionsButton.TabIndex = 27
        Me.ReqExecutionsButton.Text = "Req Executions..."
        '
        'ClearFormButton
        '
        Me.ClearFormButton.AutoSize = True
        Me.ClearFormButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClearFormButton.Location = New System.Drawing.Point(556, 3)
        Me.ClearFormButton.Name = "ClearFormButton"
        Me.ClearFormButton.Size = New System.Drawing.Size(89, 70)
        Me.ClearFormButton.TabIndex = 5
        Me.ClearFormButton.Text = "Clear data"
        '
        'CancelMktDepthButton
        '
        Me.CancelMktDepthButton.AutoSize = True
        Me.CancelMktDepthButton.Location = New System.Drawing.Point(158, 34)
        Me.CancelMktDepthButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelMktDepthButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelMktDepthButton.Name = "CancelMktDepthButton"
        Me.CancelMktDepthButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelMktDepthButton.TabIndex = 3
        Me.CancelMktDepthButton.Text = "Cancel Mkt Depth..."
        '
        'PlaceOrderButton
        '
        Me.PlaceOrderButton.AutoSize = True
        Me.PlaceOrderButton.Location = New System.Drawing.Point(3, 282)
        Me.PlaceOrderButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.PlaceOrderButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.PlaceOrderButton.Name = "PlaceOrderButton"
        Me.PlaceOrderButton.Size = New System.Drawing.Size(133, 25)
        Me.PlaceOrderButton.TabIndex = 18
        Me.PlaceOrderButton.Text = "Place Order..."
        '
        'CancelOrderButton
        '
        Me.CancelOrderButton.AutoSize = True
        Me.CancelOrderButton.Location = New System.Drawing.Point(158, 282)
        Me.CancelOrderButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelOrderButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelOrderButton.Name = "CancelOrderButton"
        Me.CancelOrderButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelOrderButton.TabIndex = 19
        Me.CancelOrderButton.Text = "Cancel Order..."
        '
        'ExtendedOrderAtribsButton
        '
        Me.ExtendedOrderAtribsButton.AutoSize = True
        Me.ExtendedOrderAtribsButton.Location = New System.Drawing.Point(158, 313)
        Me.ExtendedOrderAtribsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ExtendedOrderAtribsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ExtendedOrderAtribsButton.Name = "ExtendedOrderAtribsButton"
        Me.ExtendedOrderAtribsButton.Size = New System.Drawing.Size(133, 25)
        Me.ExtendedOrderAtribsButton.TabIndex = 21
        Me.ExtendedOrderAtribsButton.Text = "Extended..."
        '
        'ReqContractDataButton
        '
        Me.ReqContractDataButton.AutoSize = True
        Me.ReqContractDataButton.Location = New System.Drawing.Point(3, 344)
        Me.ReqContractDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqContractDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqContractDataButton.Name = "ReqContractDataButton"
        Me.ReqContractDataButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqContractDataButton.TabIndex = 22
        Me.ReqContractDataButton.Text = "Req Contract Data..."
        '
        'ReqOpenOrdersButton
        '
        Me.ReqOpenOrdersButton.AutoSize = True
        Me.ReqOpenOrdersButton.Location = New System.Drawing.Point(158, 344)
        Me.ReqOpenOrdersButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqOpenOrdersButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqOpenOrdersButton.Name = "ReqOpenOrdersButton"
        Me.ReqOpenOrdersButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqOpenOrdersButton.TabIndex = 23
        Me.ReqOpenOrdersButton.Text = "Req Open Orders"
        '
        'ConnectDisconnectButton
        '
        Me.ConnectDisconnectButton.AutoSize = True
        Me.ConnectDisconnectButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConnectDisconnectButton.Location = New System.Drawing.Point(3, 3)
        Me.ConnectDisconnectButton.Name = "ConnectDisconnectButton"
        Me.ConnectDisconnectButton.Size = New System.Drawing.Size(113, 70)
        Me.ConnectDisconnectButton.TabIndex = 1
        Me.ConnectDisconnectButton.Text = "#"
        '
        'ExerciseOptionsButton
        '
        Me.ExerciseOptionsButton.AutoSize = True
        Me.ExerciseOptionsButton.Location = New System.Drawing.Point(3, 313)
        Me.ExerciseOptionsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ExerciseOptionsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ExerciseOptionsButton.Name = "ExerciseOptionsButton"
        Me.ExerciseOptionsButton.Size = New System.Drawing.Size(133, 25)
        Me.ExerciseOptionsButton.TabIndex = 20
        Me.ExerciseOptionsButton.Text = "Exercise Options..."
        '
        'CancelHistDataButton
        '
        Me.CancelHistDataButton.AutoSize = True
        Me.CancelHistDataButton.Location = New System.Drawing.Point(158, 65)
        Me.CancelHistDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelHistDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelHistDataButton.Name = "CancelHistDataButton"
        Me.CancelHistDataButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelHistDataButton.TabIndex = 5
        Me.CancelHistDataButton.Text = "Cancel Hist. Data..."
        '
        'ScannerButton
        '
        Me.ScannerButton.AutoSize = True
        Me.ScannerButton.Location = New System.Drawing.Point(158, 158)
        Me.ScannerButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ScannerButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ScannerButton.Name = "ScannerButton"
        Me.ScannerButton.Size = New System.Drawing.Size(133, 25)
        Me.ScannerButton.TabIndex = 11
        Me.ScannerButton.Text = "Market Scanner..."
        '
        'ReqRealTimeBarsButton
        '
        Me.ReqRealTimeBarsButton.AutoSize = True
        Me.ReqRealTimeBarsButton.Location = New System.Drawing.Point(3, 127)
        Me.ReqRealTimeBarsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqRealTimeBarsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqRealTimeBarsButton.Name = "ReqRealTimeBarsButton"
        Me.ReqRealTimeBarsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqRealTimeBarsButton.TabIndex = 8
        Me.ReqRealTimeBarsButton.Text = "Real Time Bars"
        '
        'CancelRealTimeBarsButton
        '
        Me.CancelRealTimeBarsButton.AutoSize = True
        Me.CancelRealTimeBarsButton.Location = New System.Drawing.Point(158, 127)
        Me.CancelRealTimeBarsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelRealTimeBarsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelRealTimeBarsButton.Name = "CancelRealTimeBarsButton"
        Me.CancelRealTimeBarsButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelRealTimeBarsButton.TabIndex = 9
        Me.CancelRealTimeBarsButton.Text = "Canc Real Time Bars"
        '
        'ReqCurrentTimeButton
        '
        Me.ReqCurrentTimeButton.AutoSize = True
        Me.ReqCurrentTimeButton.Location = New System.Drawing.Point(3, 158)
        Me.ReqCurrentTimeButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqCurrentTimeButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqCurrentTimeButton.Name = "ReqCurrentTimeButton"
        Me.ReqCurrentTimeButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqCurrentTimeButton.TabIndex = 10
        Me.ReqCurrentTimeButton.Text = "Current Time"
        '
        'WhatIfButton
        '
        Me.WhatIfButton.AutoSize = True
        Me.WhatIfButton.Location = New System.Drawing.Point(3, 251)
        Me.WhatIfButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.WhatIfButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.WhatIfButton.Name = "WhatIfButton"
        Me.WhatIfButton.Size = New System.Drawing.Size(133, 25)
        Me.WhatIfButton.TabIndex = 16
        Me.WhatIfButton.Text = "What If..."
        '
        'CalcImpliedVolatilityButton
        '
        Me.CalcImpliedVolatilityButton.AutoSize = True
        Me.CalcImpliedVolatilityButton.Location = New System.Drawing.Point(3, 189)
        Me.CalcImpliedVolatilityButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CalcImpliedVolatilityButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CalcImpliedVolatilityButton.Name = "CalcImpliedVolatilityButton"
        Me.CalcImpliedVolatilityButton.Size = New System.Drawing.Size(133, 25)
        Me.CalcImpliedVolatilityButton.TabIndex = 12
        Me.CalcImpliedVolatilityButton.Text = "Calc Implied Volatility"
        '
        'CalcOptionPriceButton
        '
        Me.CalcOptionPriceButton.AutoSize = True
        Me.CalcOptionPriceButton.Location = New System.Drawing.Point(3, 220)
        Me.CalcOptionPriceButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CalcOptionPriceButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CalcOptionPriceButton.Name = "CalcOptionPriceButton"
        Me.CalcOptionPriceButton.Size = New System.Drawing.Size(133, 25)
        Me.CalcOptionPriceButton.TabIndex = 14
        Me.CalcOptionPriceButton.Text = "Calc Option Price"
        '
        'CancelCalcImpliedVolatilityButton
        '
        Me.CancelCalcImpliedVolatilityButton.AutoSize = True
        Me.CancelCalcImpliedVolatilityButton.Location = New System.Drawing.Point(158, 189)
        Me.CancelCalcImpliedVolatilityButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelCalcImpliedVolatilityButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelCalcImpliedVolatilityButton.Name = "CancelCalcImpliedVolatilityButton"
        Me.CancelCalcImpliedVolatilityButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelCalcImpliedVolatilityButton.TabIndex = 13
        Me.CancelCalcImpliedVolatilityButton.Text = "Cancel Calc Impl Vol"
        '
        'CancelCalcOptionPriceButton
        '
        Me.CancelCalcOptionPriceButton.AutoSize = True
        Me.CancelCalcOptionPriceButton.Location = New System.Drawing.Point(158, 220)
        Me.CancelCalcOptionPriceButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelCalcOptionPriceButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelCalcOptionPriceButton.Name = "CancelCalcOptionPriceButton"
        Me.CancelCalcOptionPriceButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelCalcOptionPriceButton.TabIndex = 15
        Me.CancelCalcOptionPriceButton.Text = "Cancel Calc Opt Price"
        '
        'ReqGlobalCancelButton
        '
        Me.ReqGlobalCancelButton.AutoSize = True
        Me.ReqGlobalCancelButton.Location = New System.Drawing.Point(158, 499)
        Me.ReqGlobalCancelButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqGlobalCancelButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqGlobalCancelButton.Name = "ReqGlobalCancelButton"
        Me.ReqGlobalCancelButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqGlobalCancelButton.TabIndex = 32
        Me.ReqGlobalCancelButton.Text = "Global Cancel"
        '
        'ReqMarketDataTypeButton
        '
        Me.ReqMarketDataTypeButton.AutoSize = True
        Me.ReqMarketDataTypeButton.Location = New System.Drawing.Point(3, 530)
        Me.ReqMarketDataTypeButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqMarketDataTypeButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqMarketDataTypeButton.Name = "ReqMarketDataTypeButton"
        Me.ReqMarketDataTypeButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqMarketDataTypeButton.TabIndex = 33
        Me.ReqMarketDataTypeButton.Text = "Req Mkt Data Type"
        '
        'ReqPositionsButton
        '
        Me.ReqPositionsButton.AutoSize = True
        Me.ReqPositionsButton.Location = New System.Drawing.Point(3, 561)
        Me.ReqPositionsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqPositionsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqPositionsButton.Name = "ReqPositionsButton"
        Me.ReqPositionsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqPositionsButton.TabIndex = 35
        Me.ReqPositionsButton.Text = "Req Positions"
        '
        'ReqAccountSummaryButton
        '
        Me.ReqAccountSummaryButton.AutoSize = True
        Me.ReqAccountSummaryButton.Location = New System.Drawing.Point(3, 592)
        Me.ReqAccountSummaryButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqAccountSummaryButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqAccountSummaryButton.Name = "ReqAccountSummaryButton"
        Me.ReqAccountSummaryButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqAccountSummaryButton.TabIndex = 37
        Me.ReqAccountSummaryButton.Text = "Req Acct Summary"
        '
        'CancelAccountSummaryButton
        '
        Me.CancelAccountSummaryButton.AutoSize = True
        Me.CancelAccountSummaryButton.Location = New System.Drawing.Point(158, 592)
        Me.CancelAccountSummaryButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelAccountSummaryButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelAccountSummaryButton.Name = "CancelAccountSummaryButton"
        Me.CancelAccountSummaryButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelAccountSummaryButton.TabIndex = 38
        Me.CancelAccountSummaryButton.Text = "Cancel Acct Summary"
        '
        'CancelPositionsButton
        '
        Me.CancelPositionsButton.AutoSize = True
        Me.CancelPositionsButton.Location = New System.Drawing.Point(158, 561)
        Me.CancelPositionsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelPositionsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelPositionsButton.Name = "CancelPositionsButton"
        Me.CancelPositionsButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelPositionsButton.TabIndex = 36
        Me.CancelPositionsButton.Text = "Cancel Positions"
        '
        'GroupsButton
        '
        Me.GroupsButton.AutoSize = True
        Me.GroupsButton.Location = New System.Drawing.Point(3, 623)
        Me.GroupsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.GroupsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.GroupsButton.Name = "GroupsButton"
        Me.GroupsButton.Size = New System.Drawing.Size(133, 25)
        Me.GroupsButton.TabIndex = 39
        Me.GroupsButton.Text = "Groups"
        '
        'ReqFundamentalDataButton
        '
        Me.ReqFundamentalDataButton.AutoSize = True
        Me.ReqFundamentalDataButton.Location = New System.Drawing.Point(3, 96)
        Me.ReqFundamentalDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqFundamentalDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqFundamentalDataButton.Name = "ReqFundamentalDataButton"
        Me.ReqFundamentalDataButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqFundamentalDataButton.TabIndex = 6
        Me.ReqFundamentalDataButton.Text = "Fundamental Data..."
        '
        'CancelFundamentalDataButton
        '
        Me.CancelFundamentalDataButton.AutoSize = True
        Me.CancelFundamentalDataButton.Location = New System.Drawing.Point(158, 96)
        Me.CancelFundamentalDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelFundamentalDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelFundamentalDataButton.Name = "CancelFundamentalDataButton"
        Me.CancelFundamentalDataButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelFundamentalDataButton.TabIndex = 7
        Me.CancelFundamentalDataButton.Text = "Cancel Fund. Data..."
        '
        'ReqPositionsMultiButton
        '
        Me.ReqPositionsMultiButton.AutoSize = True
        Me.ReqPositionsMultiButton.Location = New System.Drawing.Point(3, 654)
        Me.ReqPositionsMultiButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqPositionsMultiButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqPositionsMultiButton.Name = "ReqPositionsMultiButton"
        Me.ReqPositionsMultiButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqPositionsMultiButton.TabIndex = 41
        Me.ReqPositionsMultiButton.Text = "Req Positions Multi"
        '
        'CancelPositionsMultiButton
        '
        Me.CancelPositionsMultiButton.AutoSize = True
        Me.CancelPositionsMultiButton.Location = New System.Drawing.Point(158, 654)
        Me.CancelPositionsMultiButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelPositionsMultiButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelPositionsMultiButton.Name = "CancelPositionsMultiButton"
        Me.CancelPositionsMultiButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelPositionsMultiButton.TabIndex = 42
        Me.CancelPositionsMultiButton.Text = "Cancel Positions Multi"
        '
        'ReqAccountUpdatesMultiButton
        '
        Me.ReqAccountUpdatesMultiButton.AutoSize = True
        Me.ReqAccountUpdatesMultiButton.Location = New System.Drawing.Point(3, 685)
        Me.ReqAccountUpdatesMultiButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqAccountUpdatesMultiButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqAccountUpdatesMultiButton.Name = "ReqAccountUpdatesMultiButton"
        Me.ReqAccountUpdatesMultiButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqAccountUpdatesMultiButton.TabIndex = 43
        Me.ReqAccountUpdatesMultiButton.Text = "Req Acct Upd Multi"
        '
        'CancelAccountUpdatesMultiButton
        '
        Me.CancelAccountUpdatesMultiButton.AutoSize = True
        Me.CancelAccountUpdatesMultiButton.Location = New System.Drawing.Point(158, 685)
        Me.CancelAccountUpdatesMultiButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelAccountUpdatesMultiButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelAccountUpdatesMultiButton.Name = "CancelAccountUpdatesMultiButton"
        Me.CancelAccountUpdatesMultiButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelAccountUpdatesMultiButton.TabIndex = 44
        Me.CancelAccountUpdatesMultiButton.Text = "Cancel Acct Upd Multi"
        '
        'ReqSecDefOptParamsButton
        '
        Me.ReqSecDefOptParamsButton.AutoSize = True
        Me.ReqSecDefOptParamsButton.Location = New System.Drawing.Point(158, 530)
        Me.ReqSecDefOptParamsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqSecDefOptParamsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqSecDefOptParamsButton.Name = "ReqSecDefOptParamsButton"
        Me.ReqSecDefOptParamsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqSecDefOptParamsButton.TabIndex = 34
        Me.ReqSecDefOptParamsButton.Text = "Req Sec Def Opt"
        '
        'FamilyCodesButton
        '
        Me.FamilyCodesButton.AutoSize = True
        Me.FamilyCodesButton.Location = New System.Drawing.Point(158, 251)
        Me.FamilyCodesButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.FamilyCodesButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.FamilyCodesButton.Name = "FamilyCodesButton"
        Me.FamilyCodesButton.Size = New System.Drawing.Size(133, 25)
        Me.FamilyCodesButton.TabIndex = 17
        Me.FamilyCodesButton.Text = "Req Family Codes"
        '
        'ReqMatchingSymbolsButton
        '
        Me.ReqMatchingSymbolsButton.AutoSize = True
        Me.ReqMatchingSymbolsButton.Location = New System.Drawing.Point(158, 623)
        Me.ReqMatchingSymbolsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqMatchingSymbolsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqMatchingSymbolsButton.Name = "ReqMatchingSymbolsButton"
        Me.ReqMatchingSymbolsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqMatchingSymbolsButton.TabIndex = 40
        Me.ReqMatchingSymbolsButton.Text = "Req Matching Symbols"
        '
        'ReqMktDepthExchangesButton
        '
        Me.ReqMktDepthExchangesButton.AutoSize = True
        Me.ReqMktDepthExchangesButton.Location = New System.Drawing.Point(3, 716)
        Me.ReqMktDepthExchangesButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqMktDepthExchangesButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqMktDepthExchangesButton.Name = "ReqMktDepthExchangesButton"
        Me.ReqMktDepthExchangesButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqMktDepthExchangesButton.TabIndex = 45
        Me.ReqMktDepthExchangesButton.Text = "Req Mkt Depth Exch"
        '
        'ReqTickByTickButton
        '
        Me.ReqTickByTickButton.AutoSize = True
        Me.ReqTickByTickButton.Location = New System.Drawing.Point(3, 933)
        Me.ReqTickByTickButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqTickByTickButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqTickByTickButton.Name = "ReqTickByTickButton"
        Me.ReqTickByTickButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqTickByTickButton.TabIndex = 58
        Me.ReqTickByTickButton.Text = "Req Tick-By-Tick"
        '
        'ReqHistoricalTicksButton
        '
        Me.ReqHistoricalTicksButton.AutoSize = True
        Me.ReqHistoricalTicksButton.Location = New System.Drawing.Point(3, 902)
        Me.ReqHistoricalTicksButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistoricalTicksButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistoricalTicksButton.Name = "ReqHistoricalTicksButton"
        Me.ReqHistoricalTicksButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqHistoricalTicksButton.TabIndex = 57
        Me.ReqHistoricalTicksButton.Text = "Req Historical Ticks"
        '
        'ReqPnlSingleButton
        '
        Me.ReqPnlSingleButton.AutoSize = True
        Me.ReqPnlSingleButton.Location = New System.Drawing.Point(3, 871)
        Me.ReqPnlSingleButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqPnlSingleButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqPnlSingleButton.Name = "ReqPnlSingleButton"
        Me.ReqPnlSingleButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqPnlSingleButton.TabIndex = 55
        Me.ReqPnlSingleButton.Text = "Req PnL Single..."
        '
        'ReqPnlButton
        '
        Me.ReqPnlButton.AutoSize = True
        Me.ReqPnlButton.Location = New System.Drawing.Point(3, 840)
        Me.ReqPnlButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqPnlButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqPnlButton.Name = "ReqPnlButton"
        Me.ReqPnlButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqPnlButton.TabIndex = 53
        Me.ReqPnlButton.Text = "Req PnL..."
        '
        'ReqHistogramDataButton
        '
        Me.ReqHistogramDataButton.AutoSize = True
        Me.ReqHistogramDataButton.Location = New System.Drawing.Point(3, 809)
        Me.ReqHistogramDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistogramDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistogramDataButton.Name = "ReqHistogramDataButton"
        Me.ReqHistogramDataButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqHistogramDataButton.TabIndex = 51
        Me.ReqHistogramDataButton.Text = "Req Histogram Data"
        '
        'ReqHistoricalNewsButton
        '
        Me.ReqHistoricalNewsButton.AutoSize = True
        Me.ReqHistoricalNewsButton.Location = New System.Drawing.Point(3, 778)
        Me.ReqHistoricalNewsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistoricalNewsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqHistoricalNewsButton.Name = "ReqHistoricalNewsButton"
        Me.ReqHistoricalNewsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqHistoricalNewsButton.TabIndex = 49
        Me.ReqHistoricalNewsButton.Text = "Req Historical News"
        '
        'ReqSmartComponentsButton
        '
        Me.ReqSmartComponentsButton.AutoSize = True
        Me.ReqSmartComponentsButton.Location = New System.Drawing.Point(3, 747)
        Me.ReqSmartComponentsButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqSmartComponentsButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqSmartComponentsButton.Name = "ReqSmartComponentsButton"
        Me.ReqSmartComponentsButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqSmartComponentsButton.TabIndex = 47
        Me.ReqSmartComponentsButton.Text = "Req Smart Components"
        '
        'CancelTickByTickButton
        '
        Me.CancelTickByTickButton.AutoSize = True
        Me.CancelTickByTickButton.Location = New System.Drawing.Point(158, 933)
        Me.CancelTickByTickButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelTickByTickButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelTickByTickButton.Name = "CancelTickByTickButton"
        Me.CancelTickByTickButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelTickByTickButton.TabIndex = 59
        Me.CancelTickByTickButton.Text = "Cancel Tick-By-Tick"
        '
        'CancelPnlSingleButton
        '
        Me.CancelPnlSingleButton.AutoSize = True
        Me.CancelPnlSingleButton.Location = New System.Drawing.Point(158, 871)
        Me.CancelPnlSingleButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelPnlSingleButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelPnlSingleButton.Name = "CancelPnlSingleButton"
        Me.CancelPnlSingleButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelPnlSingleButton.TabIndex = 56
        Me.CancelPnlSingleButton.Text = "Cancel PnL Single"
        '
        'CancelPnlButton
        '
        Me.CancelPnlButton.AutoSize = True
        Me.CancelPnlButton.Location = New System.Drawing.Point(158, 840)
        Me.CancelPnlButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelPnlButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelPnlButton.Name = "CancelPnlButton"
        Me.CancelPnlButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelPnlButton.TabIndex = 54
        Me.CancelPnlButton.Text = "Cancel PnL"
        '
        'ReqMarketRuleButton
        '
        Me.ReqMarketRuleButton.AutoSize = True
        Me.ReqMarketRuleButton.Location = New System.Drawing.Point(158, 809)
        Me.ReqMarketRuleButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqMarketRuleButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqMarketRuleButton.Name = "ReqMarketRuleButton"
        Me.ReqMarketRuleButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqMarketRuleButton.TabIndex = 52
        Me.ReqMarketRuleButton.Text = "Req Market Rule"
        '
        'ReqHeadTimestampButton
        '
        Me.ReqHeadTimestampButton.AutoSize = True
        Me.ReqHeadTimestampButton.Location = New System.Drawing.Point(158, 778)
        Me.ReqHeadTimestampButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqHeadTimestampButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqHeadTimestampButton.Name = "ReqHeadTimestampButton"
        Me.ReqHeadTimestampButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqHeadTimestampButton.TabIndex = 50
        Me.ReqHeadTimestampButton.Text = "Req Head Time Stamp..."
        '
        'ReqNewsArticleButton
        '
        Me.ReqNewsArticleButton.AutoSize = True
        Me.ReqNewsArticleButton.Location = New System.Drawing.Point(158, 747)
        Me.ReqNewsArticleButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqNewsArticleButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqNewsArticleButton.Name = "ReqNewsArticleButton"
        Me.ReqNewsArticleButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqNewsArticleButton.TabIndex = 48
        Me.ReqNewsArticleButton.Text = "Req News Article"
        '
        'ReqNewsProvidersButton
        '
        Me.ReqNewsProvidersButton.AutoSize = True
        Me.ReqNewsProvidersButton.Location = New System.Drawing.Point(158, 716)
        Me.ReqNewsProvidersButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqNewsProvidersButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqNewsProvidersButton.Name = "ReqNewsProvidersButton"
        Me.ReqNewsProvidersButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqNewsProvidersButton.TabIndex = 46
        Me.ReqNewsProvidersButton.Text = "Req News Providers"
        '
        'ConnectionStatusLabel
        '
        Me.ConnectionStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ConnectionStatusLabel.AutoSize = True
        Me.ConnectionStatusLabel.BackColor = System.Drawing.Color.Transparent
        Me.ConnectionStatusLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectionStatusLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.ConnectionStatusLabel.Location = New System.Drawing.Point(1163, 29)
        Me.ConnectionStatusLabel.Name = "ConnectionStatusLabel"
        Me.ConnectionStatusLabel.Size = New System.Drawing.Size(98, 17)
        Me.ConnectionStatusLabel.TabIndex = 57
        Me.ConnectionStatusLabel.Text = "Not connected"
        Me.ConnectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.PowderBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 76)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonsPanel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 909)
        Me.SplitContainer1.SplitterDistance = 320
        Me.SplitContainer1.TabIndex = 1
        Me.SplitContainer1.TabStop = False
        '
        'ButtonsPanel
        '
        Me.ButtonsPanel.AutoScroll = True
        Me.ButtonsPanel.ColumnCount = 4
        Me.ButtonsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ButtonsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.ButtonsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ButtonsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.ButtonsPanel.Controls.Add(Me.ReqMktDataButton, 0, 0)
        Me.ButtonsPanel.Controls.Add(Me.CancelMktDataButton, 2, 0)
        Me.ButtonsPanel.Controls.Add(Me.ReqMktDepthButton, 0, 1)
        Me.ButtonsPanel.Controls.Add(Me.CancelMktDepthButton, 2, 1)
        Me.ButtonsPanel.Controls.Add(Me.ReqHistoricalDataButton, 0, 2)
        Me.ButtonsPanel.Controls.Add(Me.CancelHistDataButton, 2, 2)
        Me.ButtonsPanel.Controls.Add(Me.ReqFundamentalDataButton, 0, 3)
        Me.ButtonsPanel.Controls.Add(Me.CancelFundamentalDataButton, 2, 3)
        Me.ButtonsPanel.Controls.Add(Me.ReqRealTimeBarsButton, 0, 4)
        Me.ButtonsPanel.Controls.Add(Me.CancelRealTimeBarsButton, 2, 4)
        Me.ButtonsPanel.Controls.Add(Me.ReqCurrentTimeButton, 0, 5)
        Me.ButtonsPanel.Controls.Add(Me.ScannerButton, 2, 5)
        Me.ButtonsPanel.Controls.Add(Me.CalcImpliedVolatilityButton, 0, 6)
        Me.ButtonsPanel.Controls.Add(Me.CancelCalcImpliedVolatilityButton, 2, 6)
        Me.ButtonsPanel.Controls.Add(Me.CalcOptionPriceButton, 0, 7)
        Me.ButtonsPanel.Controls.Add(Me.CancelCalcOptionPriceButton, 2, 7)
        Me.ButtonsPanel.Controls.Add(Me.WhatIfButton, 0, 8)
        Me.ButtonsPanel.Controls.Add(Me.FamilyCodesButton, 2, 8)
        Me.ButtonsPanel.Controls.Add(Me.PlaceOrderButton, 0, 9)
        Me.ButtonsPanel.Controls.Add(Me.CancelOrderButton, 2, 9)
        Me.ButtonsPanel.Controls.Add(Me.ExerciseOptionsButton, 0, 10)
        Me.ButtonsPanel.Controls.Add(Me.ExtendedOrderAtribsButton, 2, 10)
        Me.ButtonsPanel.Controls.Add(Me.ReqContractDataButton, 0, 11)
        Me.ButtonsPanel.Controls.Add(Me.ReqOpenOrdersButton, 2, 11)
        Me.ButtonsPanel.Controls.Add(Me.ReqAllOpenOrdersButton, 0, 12)
        Me.ButtonsPanel.Controls.Add(Me.ReqAutoOpenOrdersButton, 2, 12)
        Me.ButtonsPanel.Controls.Add(Me.ReqAcctDataButton, 0, 13)
        Me.ButtonsPanel.Controls.Add(Me.ReqExecutionsButton, 2, 13)
        Me.ButtonsPanel.Controls.Add(Me.ReqNewsButton, 2, 14)
        Me.ButtonsPanel.Controls.Add(Me.ServerLogLevelButton, 0, 15)
        Me.ButtonsPanel.Controls.Add(Me.ReqAcctsButton, 2, 15)
        Me.ButtonsPanel.Controls.Add(Me.FinancialAdvisorButton, 0, 16)
        Me.ButtonsPanel.Controls.Add(Me.ReqGlobalCancelButton, 2, 16)
        Me.ButtonsPanel.Controls.Add(Me.ReqMarketDataTypeButton, 0, 17)
        Me.ButtonsPanel.Controls.Add(Me.ReqSecDefOptParamsButton, 2, 17)
        Me.ButtonsPanel.Controls.Add(Me.ReqPositionsButton, 0, 18)
        Me.ButtonsPanel.Controls.Add(Me.CancelPositionsButton, 2, 18)
        Me.ButtonsPanel.Controls.Add(Me.ReqAccountSummaryButton, 0, 19)
        Me.ButtonsPanel.Controls.Add(Me.CancelAccountSummaryButton, 2, 19)
        Me.ButtonsPanel.Controls.Add(Me.GroupsButton, 0, 20)
        Me.ButtonsPanel.Controls.Add(Me.ReqMatchingSymbolsButton, 2, 20)
        Me.ButtonsPanel.Controls.Add(Me.ReqPositionsMultiButton, 0, 21)
        Me.ButtonsPanel.Controls.Add(Me.CancelPositionsMultiButton, 2, 21)
        Me.ButtonsPanel.Controls.Add(Me.ReqAccountUpdatesMultiButton, 0, 22)
        Me.ButtonsPanel.Controls.Add(Me.CancelAccountUpdatesMultiButton, 2, 22)
        Me.ButtonsPanel.Controls.Add(Me.ReqMktDepthExchangesButton, 0, 23)
        Me.ButtonsPanel.Controls.Add(Me.ReqNewsProvidersButton, 2, 23)
        Me.ButtonsPanel.Controls.Add(Me.ReqSmartComponentsButton, 0, 24)
        Me.ButtonsPanel.Controls.Add(Me.ReqNewsArticleButton, 2, 24)
        Me.ButtonsPanel.Controls.Add(Me.ReqHistoricalNewsButton, 0, 25)
        Me.ButtonsPanel.Controls.Add(Me.ReqHeadTimestampButton, 2, 25)
        Me.ButtonsPanel.Controls.Add(Me.ReqHistogramDataButton, 0, 26)
        Me.ButtonsPanel.Controls.Add(Me.ReqMarketRuleButton, 2, 26)
        Me.ButtonsPanel.Controls.Add(Me.ReqPnlButton, 0, 27)
        Me.ButtonsPanel.Controls.Add(Me.CancelPnlButton, 2, 27)
        Me.ButtonsPanel.Controls.Add(Me.ReqPnlSingleButton, 0, 28)
        Me.ButtonsPanel.Controls.Add(Me.CancelPnlSingleButton, 2, 28)
        Me.ButtonsPanel.Controls.Add(Me.ReqHistoricalTicksButton, 0, 29)
        Me.ButtonsPanel.Controls.Add(Me.ReqTickByTickButton, 0, 30)
        Me.ButtonsPanel.Controls.Add(Me.CancelTickByTickButton, 2, 30)
        Me.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonsPanel.Location = New System.Drawing.Point(0, 0)
        Me.ButtonsPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonsPanel.Name = "ButtonsPanel"
        Me.ButtonsPanel.RowCount = 31
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ButtonsPanel.Size = New System.Drawing.Size(320, 909)
        Me.ButtonsPanel.TabIndex = 0
        '
        'ReqMktDataButton
        '
        Me.ReqMktDataButton.AutoSize = True
        Me.ReqMktDataButton.Location = New System.Drawing.Point(3, 3)
        Me.ReqMktDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqMktDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqMktDataButton.Name = "ReqMktDataButton"
        Me.ReqMktDataButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqMktDataButton.TabIndex = 0
        Me.ReqMktDataButton.Text = "Req Mkt Data..."
        '
        'CancelMktDataButton
        '
        Me.CancelMktDataButton.AutoSize = True
        Me.CancelMktDataButton.Location = New System.Drawing.Point(158, 3)
        Me.CancelMktDataButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.CancelMktDataButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.CancelMktDataButton.Name = "CancelMktDataButton"
        Me.CancelMktDataButton.Size = New System.Drawing.Size(133, 25)
        Me.CancelMktDataButton.TabIndex = 1
        Me.CancelMktDataButton.Text = "Cancel Mkt Data..."
        '
        'ReqMktDepthButton
        '
        Me.ReqMktDepthButton.AutoSize = True
        Me.ReqMktDepthButton.Location = New System.Drawing.Point(3, 34)
        Me.ReqMktDepthButton.MaximumSize = New System.Drawing.Size(133, 0)
        Me.ReqMktDepthButton.MinimumSize = New System.Drawing.Size(133, 0)
        Me.ReqMktDepthButton.Name = "ReqMktDepthButton"
        Me.ReqMktDepthButton.Size = New System.Drawing.Size(133, 25)
        Me.ReqMktDepthButton.TabIndex = 2
        Me.ReqMktDepthButton.Text = "Req Mkt Depth..."
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer2.Size = New System.Drawing.Size(940, 909)
        Me.SplitContainer2.SplitterDistance = 598
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.PowderBlue
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.SplitContainer3.Size = New System.Drawing.Size(940, 598)
        Me.SplitContainer3.SplitterDistance = 446
        Me.SplitContainer3.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ServerResponsesText, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ThemedLabel11, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(446, 598)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ServerResponsesText
        '
        Me.ServerResponsesText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ServerResponsesText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ServerResponsesText.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerResponsesText.Location = New System.Drawing.Point(0, 24)
        Me.ServerResponsesText.Margin = New System.Windows.Forms.Padding(0)
        Me.ServerResponsesText.Multiline = True
        Me.ServerResponsesText.Name = "ServerResponsesText"
        Me.ServerResponsesText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ServerResponsesText.Size = New System.Drawing.Size(446, 574)
        Me.ServerResponsesText.TabIndex = 1
        '
        'ThemedLabel11
        '
        Me.ThemedLabel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ThemedLabel11.AutoSize = True
        Me.ThemedLabel11.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ThemedLabel11.Location = New System.Drawing.Point(0, 0)
        Me.ThemedLabel11.Margin = New System.Windows.Forms.Padding(0)
        Me.ThemedLabel11.Name = "ThemedLabel11"
        Me.ThemedLabel11.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.ThemedLabel11.Size = New System.Drawing.Size(446, 24)
        Me.ThemedLabel11.TabIndex = 0
        Me.ThemedLabel11.Text = "TWS Server Responses"
        Me.ThemedLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.MarketDataText, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(490, 598)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'MarketDataText
        '
        Me.MarketDataText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MarketDataText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MarketDataText.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarketDataText.Location = New System.Drawing.Point(0, 24)
        Me.MarketDataText.Margin = New System.Windows.Forms.Padding(0)
        Me.MarketDataText.Multiline = True
        Me.MarketDataText.Name = "MarketDataText"
        Me.MarketDataText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.MarketDataText.Size = New System.Drawing.Size(490, 574)
        Me.MarketDataText.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Label4.Size = New System.Drawing.Size(490, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Market && Historical Data"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.TableLayoutPanel4)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.TableLayoutPanel5)
        Me.SplitContainer4.Size = New System.Drawing.Size(940, 307)
        Me.SplitContainer4.SplitterDistance = 404
        Me.SplitContainer4.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.ErrorsText, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(404, 307)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'ErrorsText
        '
        Me.ErrorsText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ErrorsText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ErrorsText.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorsText.Location = New System.Drawing.Point(0, 24)
        Me.ErrorsText.Margin = New System.Windows.Forms.Padding(0)
        Me.ErrorsText.Multiline = True
        Me.ErrorsText.Name = "ErrorsText"
        Me.ErrorsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ErrorsText.Size = New System.Drawing.Size(404, 283)
        Me.ErrorsText.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Label2.Size = New System.Drawing.Size(404, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Errors and Notifications"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.SocketLogText, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(532, 307)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'SocketLogText
        '
        Me.SocketLogText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SocketLogText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SocketLogText.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SocketLogText.ForeColor = System.Drawing.Color.DimGray
        Me.SocketLogText.Location = New System.Drawing.Point(0, 24)
        Me.SocketLogText.Margin = New System.Windows.Forms.Padding(0)
        Me.SocketLogText.Multiline = True
        Me.SocketLogText.Name = "SocketLogText"
        Me.SocketLogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SocketLogText.Size = New System.Drawing.Size(532, 283)
        Me.SocketLogText.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Label1.Size = New System.Drawing.Size(532, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Socket Messages"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TopPanel
        '
        Me.TopPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TopPanel.AutoSize = True
        Me.TopPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TopPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.TopPanel.ColumnCount = 8
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TopPanel.Controls.Add(Me.ConnectionStatusLabel, 7, 0)
        Me.TopPanel.Controls.Add(Me.PauseAPIButton, 5, 0)
        Me.TopPanel.Controls.Add(Me.ClearFormButton, 4, 0)
        Me.TopPanel.Controls.Add(Me.TopPanelCheckboxesSite, 3, 0)
        Me.TopPanel.Controls.Add(Me.Label13, 1, 0)
        Me.TopPanel.Controls.Add(Me.ConnectDisconnectButton, 0, 0)
        Me.TopPanel.Controls.Add(Me.ApiDetailsPanel, 2, 0)
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.RowCount = 1
        Me.TopPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TopPanel.Size = New System.Drawing.Size(1264, 76)
        Me.TopPanel.TabIndex = 0
        '
        'PauseAPIButton
        '
        Me.PauseAPIButton.AutoSize = True
        Me.PauseAPIButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PauseAPIButton.Enabled = False
        Me.PauseAPIButton.Location = New System.Drawing.Point(651, 3)
        Me.PauseAPIButton.Name = "PauseAPIButton"
        Me.PauseAPIButton.Size = New System.Drawing.Size(89, 70)
        Me.PauseAPIButton.TabIndex = 6
        Me.PauseAPIButton.Text = "Pause API"
        '
        'TopPanelCheckboxesSite
        '
        Me.TopPanelCheckboxesSite.AutoSize = True
        Me.TopPanelCheckboxesSite.ColumnCount = 1
        Me.TopPanelCheckboxesSite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TopPanelCheckboxesSite.Controls.Add(Me.DisplayApiMessageStatisticsCheck, 0, 2)
        Me.TopPanelCheckboxesSite.Controls.Add(Me.DisplaySocketMessagesCheck, 0, 1)
        Me.TopPanelCheckboxesSite.Controls.Add(Me.UseQueueingCheck, 0, 3)
        Me.TopPanelCheckboxesSite.Controls.Add(Me.DisplaySocketDataCheck, 0, 0)
        Me.TopPanelCheckboxesSite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TopPanelCheckboxesSite.Location = New System.Drawing.Point(338, 0)
        Me.TopPanelCheckboxesSite.Margin = New System.Windows.Forms.Padding(0)
        Me.TopPanelCheckboxesSite.Name = "TopPanelCheckboxesSite"
        Me.TopPanelCheckboxesSite.RowCount = 4
        Me.TopPanelCheckboxesSite.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TopPanelCheckboxesSite.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TopPanelCheckboxesSite.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TopPanelCheckboxesSite.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TopPanelCheckboxesSite.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TopPanelCheckboxesSite.Size = New System.Drawing.Size(215, 76)
        Me.TopPanelCheckboxesSite.TabIndex = 3
        '
        'DisplayApiMessageStatisticsCheck
        '
        Me.DisplayApiMessageStatisticsCheck.AutoSize = True
        Me.DisplayApiMessageStatisticsCheck.FlatAppearance.BorderSize = 0
        Me.DisplayApiMessageStatisticsCheck.Location = New System.Drawing.Point(3, 38)
        Me.DisplayApiMessageStatisticsCheck.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.DisplayApiMessageStatisticsCheck.Name = "DisplayApiMessageStatisticsCheck"
        Me.DisplayApiMessageStatisticsCheck.Size = New System.Drawing.Size(149, 19)
        Me.DisplayApiMessageStatisticsCheck.TabIndex = 2
        Me.DisplayApiMessageStatisticsCheck.Text = "Display socket statistics"
        Me.DisplayApiMessageStatisticsCheck.UseVisualStyleBackColor = False
        '
        'DisplaySocketMessagesCheck
        '
        Me.DisplaySocketMessagesCheck.AutoSize = True
        Me.DisplaySocketMessagesCheck.Checked = True
        Me.DisplaySocketMessagesCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DisplaySocketMessagesCheck.FlatAppearance.BorderSize = 0
        Me.DisplaySocketMessagesCheck.Location = New System.Drawing.Point(3, 19)
        Me.DisplaySocketMessagesCheck.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.DisplaySocketMessagesCheck.Name = "DisplaySocketMessagesCheck"
        Me.DisplaySocketMessagesCheck.Size = New System.Drawing.Size(155, 19)
        Me.DisplaySocketMessagesCheck.TabIndex = 1
        Me.DisplaySocketMessagesCheck.Text = "Display socket messages"
        Me.DisplaySocketMessagesCheck.UseVisualStyleBackColor = False
        '
        'UseQueueingCheck
        '
        Me.UseQueueingCheck.AutoSize = True
        Me.UseQueueingCheck.Location = New System.Drawing.Point(3, 57)
        Me.UseQueueingCheck.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.UseQueueingCheck.Name = "UseQueueingCheck"
        Me.UseQueueingCheck.Size = New System.Drawing.Size(209, 19)
        Me.UseQueueingCheck.TabIndex = 3
        Me.UseQueueingCheck.Text = "Use the Queueing callback handler"
        Me.UseQueueingCheck.UseVisualStyleBackColor = True
        '
        'DisplaySocketDataCheck
        '
        Me.DisplaySocketDataCheck.AutoSize = True
        Me.DisplaySocketDataCheck.Checked = True
        Me.DisplaySocketDataCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DisplaySocketDataCheck.FlatAppearance.BorderSize = 0
        Me.DisplaySocketDataCheck.Location = New System.Drawing.Point(3, 0)
        Me.DisplaySocketDataCheck.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.DisplaySocketDataCheck.Name = "DisplaySocketDataCheck"
        Me.DisplaySocketDataCheck.Size = New System.Drawing.Size(149, 19)
        Me.DisplaySocketDataCheck.TabIndex = 0
        Me.DisplaySocketDataCheck.Text = "Display socket raw data"
        Me.DisplaySocketDataCheck.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(122, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 76)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "API Details"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ApiDetailsPanel
        '
        Me.ApiDetailsPanel.ColumnCount = 2
        Me.ApiDetailsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.ApiDetailsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.ApiDetailsPanel.Controls.Add(Me.Label15, 0, 2)
        Me.ApiDetailsPanel.Controls.Add(Me.Label14, 0, 1)
        Me.ApiDetailsPanel.Controls.Add(Me.ClientIdText, 1, 2)
        Me.ApiDetailsPanel.Controls.Add(Me.ServerText, 1, 0)
        Me.ApiDetailsPanel.Controls.Add(Me.PortText, 1, 1)
        Me.ApiDetailsPanel.Controls.Add(Me.Label3, 0, 0)
        Me.ApiDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ApiDetailsPanel.Location = New System.Drawing.Point(191, 3)
        Me.ApiDetailsPanel.Name = "ApiDetailsPanel"
        Me.ApiDetailsPanel.RowCount = 3
        Me.ApiDetailsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.ApiDetailsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.ApiDetailsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.ApiDetailsPanel.Size = New System.Drawing.Size(144, 70)
        Me.ApiDetailsPanel.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Location = New System.Drawing.Point(3, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 24)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "ClientID"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Location = New System.Drawing.Point(3, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 23)
        Me.Label14.TabIndex = 62
        Me.Label14.Text = "Port"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ClientIdText
        '
        Me.ClientIdText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ClientIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ClientIdText.Location = New System.Drawing.Point(60, 50)
        Me.ClientIdText.Name = "ClientIdText"
        Me.ClientIdText.Size = New System.Drawing.Size(66, 16)
        Me.ClientIdText.TabIndex = 2
        Me.ClientIdText.Text = "49723415"
        '
        'ServerText
        '
        Me.ServerText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ServerText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ServerText.Location = New System.Drawing.Point(60, 3)
        Me.ServerText.Name = "ServerText"
        Me.ServerText.Size = New System.Drawing.Size(81, 16)
        Me.ServerText.TabIndex = 0
        '
        'PortText
        '
        Me.PortText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PortText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PortText.Location = New System.Drawing.Point(60, 26)
        Me.PortText.Name = "PortText"
        Me.PortText.Size = New System.Drawing.Size(34, 16)
        Me.PortText.TabIndex = 1
        Me.PortText.Text = "7496"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Server"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.TopPanel, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1264, 985)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'MainForm
        '
        Me.AcceptButton = Me.ConnectDisconnectButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1264, 985)
        Me.Controls.Add(Me.TableLayoutPanel6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Location = New System.Drawing.Point(348, 193)
        Me.Name = "MainForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VB.NET Sample"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ButtonsPanel.ResumeLayout(False)
        Me.ButtonsPanel.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TopPanel.ResumeLayout(False)
        Me.TopPanel.PerformLayout()
        Me.TopPanelCheckboxesSite.ResumeLayout(False)
        Me.TopPanelCheckboxesSite.PerformLayout()
        Me.ApiDetailsPanel.ResumeLayout(False)
        Me.ApiDetailsPanel.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region


#Region "Member variables"

    Private WithEvents ApiEvents As EventSource
    Private mCallbackHandler As QueueingCallbackHandler
    Private mUseQueueing As Boolean

    Private mConnectionState As ApiConnectionState

    Private mApi As IBAPI
    Private mApiPaused As Boolean

    Private mMarketDataText As TextboxDisplayManager
    Private mSocketDataText As TextboxDisplayManager
    Private mServerResponsesText As TextboxDisplayManager
    Private mErrorsText As TextboxDisplayManager

    Private mExecFilter As ExecutionFilter
    Private mMarketDataOptions As List(Of TagValue)
    Private mChartOptions As List(Of TagValue)
    Private mMarketDepthOptions As List(Of TagValue)
    Private mRealTimeBarsOptions As List(Of TagValue)

    Private ReadOnly mPnLForm As New FPnL
    Private ReadOnly mOrderForm As New FOrder()
    Private mMarketDepthForm As FMarketDepth
    Private ReadOnly mAccountDataForm As New FAcctData
    Private ReadOnly mAccountUpdatesForm As New FAccountUpdates
    Private ReadOnly mNewsBulletinsForm As New FNewsBulletins
    Private ReadOnly mLogConfigForm As New FLogConfig
    Private ReadOnly mFinancialAdvisorForm As New FFinancialAdvisor
    Private ReadOnly mScannerForm As New FScanner
    Private ReadOnly mGroupsForm As New FGroups
    Private ReadOnly mAccountSummaryForm As New FAccountSummary

    Private mFaAccount As Boolean
    Private mFaError As Boolean
    Private mFaAccountsList As String
    Private mFaGroupXML As String
    Private mFaProfilesXML As String
    Private mFaAliasesXML As String
    Private ReadOnly mFaErrorCodes As Integer() = {503, 504, 505, 522, 1100, 321}

    Private mTransmit As Boolean = True

    Private mNewsArticlePath As String

    Private ReadOnly mTheme As Theme

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Application.EnableVisualStyles()

        disableButtons()

        mTheme = New AppTheme()
        mTheme.ApplyTheme(Me.Controls)
        mTheme.ApplyTheme(mOrderForm.Controls)
        mTheme.ApplyTheme(mAccountDataForm.Controls)
        mTheme.ApplyTheme(mAccountUpdatesForm.Controls)
        mTheme.ApplyTheme(mPnLForm.Controls)
        mTheme.ApplyTheme(mNewsBulletinsForm.Controls)
        mTheme.ApplyTheme(mLogConfigForm.Controls)
        mTheme.ApplyTheme(mFinancialAdvisorForm.Controls)
        mTheme.ApplyTheme(mScannerForm.Controls)
        mTheme.ApplyTheme(mGroupsForm.Controls)
        mTheme.ApplyTheme(mAccountSummaryForm.Controls)

        ' Override the theme for the top panel
        TopPanel.ForeColor = Color.DimGray
        TopPanelCheckboxesSite.ForeColor = Color.DimGray

        ServerText.BackColor = Color.Gainsboro
        ServerText.ForeColor = Color.DimGray
        PortText.BackColor = Color.Gainsboro
        PortText.ForeColor = Color.DimGray
        ClientIdText.BackColor = Color.Gainsboro
        ClientIdText.ForeColor = Color.DimGray

    End Sub

#End Region

#Region "Form event handlers"

    Protected Overrides Sub OnClosing(e As CancelEventArgs)
        If mApi IsNot Nothing Then
            mApi.Disconnect("Form closed")
            mApi.Dispose()
        End If
        If mMarketDataText IsNot Nothing Then mMarketDataText.Dispose()
        If mSocketDataText IsNot Nothing Then mSocketDataText.Dispose()
        MyBase.OnClosing(e)
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        mMarketDataText = New TextboxDisplayManager(MarketDataText)
        mSocketDataText = New TextboxDisplayManager(SocketLogText)
        mServerResponsesText = New TextboxDisplayManager(ServerResponsesText)
        mErrorsText = New TextboxDisplayManager(ErrorsText)

        mOrderForm.Initialise(mErrorsText)

        Logging.DefaultLogLevel = LogLevel.Detail
        ApplicationDataPathUser = Application.UserAppDataPath
        Logging.SetupDefaultLogging(synchronized:=True)

        IBAPI.EventLogger = New Logger(New FormattingLogger("ibapi", NameOf(IBAPI)))
        IBAPI.PerformanceLogger = New Logger(Logging.GetLogger("ibapi.perfdata"))

        IBAPI.SocketLogger = New Logger(Logging.GetLogger("ibapi.socketdata"))

        AddHandler AppDomain.CurrentDomain.UnhandledException,
                    Sub(s, ex)
                        Logging.DefaultLogger.Log($"Unhandled exception:{Environment.NewLine}{ex.ExceptionObject.ToString()}", LogLevel.Severe)
                        Me.Dispose()
                    End Sub

        mScannerForm.Init(Me)

        mExecFilter = New ExecutionFilter

        ServerText.Focus()

        MyBase.OnLoad(e)
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        setConnectionState(ApiConnectionState.NotConnected)
        MyBase.OnShown(e)
    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property Api As IBAPI
        Get
            Return mApi
        End Get
    End Property

    Public ReadOnly Property IsFAAccount() As Boolean
        Get
            IsFAAccount = mFaAccount
        End Get
    End Property

    Public ReadOnly Property FAManagedAccounts() As String
        Get
            FAManagedAccounts = mFaAccountsList
        End Get
    End Property

#End Region

#Region "Control event handlers"

    '--------------------------------------------------------------------------------
    ' Connect this API client to the TWS instance
    '--------------------------------------------------------------------------------
    Private Sub connectDisconnectButton_Click(sender As Object, e As EventArgs) Handles ConnectDisconnectButton.Click
        If mConnectionState = ApiConnectionState.NotConnected Then
            connectToTws()
        Else
            disconnectFromTWS()
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Pause or resume the flow of events from the API
    '--------------------------------------------------------------------------------
    Private Sub pauseAPIButton_Click(sender As Object, e As EventArgs) Handles PauseAPIButton.Click
        If mApiPaused Then
            PauseAPIButton.Text = "Pause API"
            mApiPaused = False
            mCallbackHandler.Start()
        Else
            PauseAPIButton.Text = "Resume API"
            mApiPaused = True
            mCallbackHandler.Pause()
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request market data for a security
    '--------------------------------------------------------------------------------
    Private Sub reqMktDataButton_Click(sender As Object, e As EventArgs) Handles ReqMktDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestMarketData, mMarketDataOptions, Me)

        mOrderForm.ShowDialog()

        mMarketDataOptions = mOrderForm.Options

        If mOrderForm.Ok Then
            mApi.RequestMarketData(mOrderForm.RequestId, mOrderForm.ContractInfo,
                    mOrderForm.GenericTickTags, mOrderForm.SnapshotMktData)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel market data for a security
    '--------------------------------------------------------------------------------
    Private Sub cancelMktDataButton_Click(sender As Object, e As EventArgs) Handles CancelMktDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelMarketData, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.CancelMarketData(mOrderForm.RequestId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request market depth for a security
    '--------------------------------------------------------------------------------
    Private Sub reqMktDepthButton_Click(sender As Object, e As EventArgs) Handles ReqMktDepthButton.Click
        If mMarketDepthForm IsNot Nothing Then
            mErrorsText.DisplayMessage("Market depth is already being displayed")
            Exit Sub
        End If

        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestMarketDepth, mMarketDepthOptions, Me)

        mOrderForm.ShowDialog()

        mMarketDepthOptions = mOrderForm.Options

        If mOrderForm.Ok Then
            mMarketDepthForm = New FMarketDepth
            mTheme.ApplyTheme(mMarketDepthForm.Controls)
            mMarketDepthForm.Init(mOrderForm.NumRows, mOrderForm.ContractInfo)
            AddHandler mMarketDepthForm.FormClosing, Sub(s, ev)
                                                         ' unsubscribe from mkt depth when the dialog is closed
                                                         mApi.CancelMarketDepth(mOrderForm.RequestId)
                                                         mMarketDepthForm = Nothing
                                                     End Sub
            mApi.RequestMarketDepth(mOrderForm.RequestId, mOrderForm.ContractInfo, mOrderForm.NumRows)
            mMarketDepthForm.Show(Me)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel market depth for a security
    '--------------------------------------------------------------------------------
    Private Sub cancelMktDepthButton_Click(sender As Object, e As EventArgs) Handles CancelMktDepthButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelMarketDepth, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            If mMarketDepthForm IsNot Nothing Then
                mMarketDepthForm.Close()
                mMarketDepthForm = Nothing
            End If
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request historical market data for a security
    '--------------------------------------------------------------------------------
    Private Sub reqHistoricalDataButton_Click(sender As Object, e As EventArgs) Handles ReqHistoricalDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestHistoricalData, mChartOptions, Me)

        mOrderForm.ShowDialog()

        mChartOptions = mOrderForm.Options

        If mOrderForm.Ok Then
            mApi.RequestHistoricalBars(mOrderForm.RequestId,
                                        New HistoricalBarsRequest() With
                                            {.Contract = mOrderForm.ContractInfo,
                                            .EndDateTime = mOrderForm.HistEndDateTime,
                                            .TimeZone = mOrderForm.HistEndTimezone,
                                            .Duration = mOrderForm.HistDuration,
                                            .BarSizeSetting = mOrderForm.HistBarSizeSetting,
                                            .WhatToShow = mOrderForm.WhatToShow
                                        },
                                        mOrderForm.UseRTH,
                                        mOrderForm.KeepUpToDate,
                                        mChartOptions)
        End If
    End Sub

    Private Function parseDateString(value As String) As (ok As Boolean, timestamp As Date, timeZone As String)
        Dim arr() = value.Split(" "c)

        If arr.Length = 3 Then
            Dim t As Date
            If Date.TryParse($"{arr(0)} {arr(1)}", t) Then Return (True, t, arr(2))
            Return (False, Date.MinValue, String.Empty)
        End If

        If arr.Length = 2 Then
            Dim t As Date
            If Date.TryParse($"{arr(0)} {arr(1)}", t) Then Return (True, t, String.Empty)
            If Date.TryParse(arr(0), t) Then Return (True, t, arr(1))
            Return (False, Date.MinValue, String.Empty)
        End If

        If arr.Length = 1 Then
            Dim t As Date
            If Date.TryParse(arr(0), t) Then Return (True, t, String.Empty)
            Return (False, Date.MinValue, String.Empty)
        End If

        Return (False, Date.MinValue, String.Empty)
    End Function

    '--------------------------------------------------------------------------------
    ' Cancel historical market data for a security
    '--------------------------------------------------------------------------------
    Private Sub cancelHistDataButton_Click(sender As Object, e As EventArgs) Handles CancelHistDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelHistoricalData, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.CancelHistoricalData(mOrderForm.RequestId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request fundamental data for a security
    '--------------------------------------------------------------------------------
    Private Sub reqFundamentalDataButton_Click(sender As Object, e As EventArgs) Handles ReqFundamentalDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestFundamentalData, Nothing, Me)
        mOrderForm.ShowDialog()

        If mOrderForm.Ok Then
            mApi.RequestFundamentalData(mOrderForm.RequestId, mOrderForm.ContractInfo, mOrderForm.WhatToShow)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel fundamental data for a security
    '--------------------------------------------------------------------------------
    Private Sub cancelFundamentalDataButton_Click(sender As Object, e As EventArgs) Handles CancelFundamentalDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelFundamentalData, Nothing, Me)

        mOrderForm.ShowDialog()
        mApi.CancelFundamentalData(mOrderForm.RequestId)

    End Sub

    '--------------------------------------------------------------------------------
    ' Request real time bars for a security
    '--------------------------------------------------------------------------------
    Private Sub reqRealTimeBarsButton_Click(sender As Object, e As EventArgs) Handles ReqRealTimeBarsButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestRealtimeBars, mRealTimeBarsOptions, Me)

        mOrderForm.ShowDialog()

        mRealTimeBarsOptions = mOrderForm.Options

        If mOrderForm.Ok Then
            mApi.RequestRealtimeBars(mOrderForm.RequestId, mOrderForm.ContractInfo,
                                        5, mOrderForm.WhatToShow, mOrderForm.UseRTH)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel real time bars for a security
    '--------------------------------------------------------------------------------
    Private Sub cancelRealTimeBarsButton_Click(sender As Object, e As EventArgs) Handles CancelRealTimeBarsButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelRealtimeBars, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.CancelRealtimeBars(mOrderForm.RequestId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request current server time
    '--------------------------------------------------------------------------------
    Private Sub reqCurrentTimeButton_Click(sender As Object, e As EventArgs) Handles ReqCurrentTimeButton.Click
        mApi.RequestCurrentTime()
    End Sub

    '--------------------------------------------------------------------------------
    ' Perform market scans
    '--------------------------------------------------------------------------------
    Private Sub scannerButton_Click(sender As Object, e As EventArgs) Handles ScannerButton.Click
        mScannerForm.ShowDialog()
    End Sub

    '--------------------------------------------------------------------------------
    ' Place a new or modify an existing order
    '--------------------------------------------------------------------------------
    Private Sub whatIfButton_Click(sender As Object, e As EventArgs) Handles WhatIfButton.Click
        placeOrderImpl(True)
    End Sub
    Private Sub placeOrderButton_Click(sender As Object, e As EventArgs) Handles PlaceOrderButton.Click
        placeOrderImpl(False)
    End Sub
    Private Sub placeOrderImpl(whatIf As Boolean)

        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.PlaceOrder, Nothing, Me)

        mOrderForm.ShowDialog()

        If mOrderForm.Ok Then

            Dim savedWhatIf = mOrderForm.OrderInfo.WhatIf()
            mOrderForm.OrderInfo.WhatIf = whatIf

            mApi.PlaceOrder(mOrderForm.OrderInfo, mOrderForm.ContractInfo, mTransmit, mOrderForm.SecIdType, mOrderForm.SecId)
            mOrderForm.OrderInfo.WhatIf = savedWhatIf
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel an existing order
    '--------------------------------------------------------------------------------
    Private Sub cancelOrderButton_Click(sender As Object, e As EventArgs) Handles CancelOrderButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelOrder, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.CancelOrder(mOrderForm.OrderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Exercise options
    '--------------------------------------------------------------------------------
    Private Sub exerciseOptionsButton_Click(sender As Object, e As EventArgs) Handles ExerciseOptionsButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.ExerciseOptions, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.ExerciseOptions(mOrderForm.RequestId, mOrderForm.ContractInfo,
                            mOrderForm.ExerciseAction, mOrderForm.ExerciseQuantity,
                            mOrderForm.OrderInfo.Account, mOrderForm.ExerciseOverride)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Sets the extended order attributes
    '--------------------------------------------------------------------------------
    Private Sub extendedOrderAtribsButton_Click(sender As Object, e As EventArgs) Handles ExtendedOrderAtribsButton.Click
        Dim fOrderAttribs As New FOrderAttribs
        mTheme.ApplyTheme(fOrderAttribs.Controls)

        fOrderAttribs.Init(mOrderForm.OrderInfo, mTransmit)
        fOrderAttribs.ShowDialog()
        mTransmit = fOrderAttribs.Transmit
        ' nothing to do besides that
    End Sub

    '--------------------------------------------------------------------------------
    ' Request the details for a contract
    '--------------------------------------------------------------------------------
    Private Sub reqContractDataButton_Click(sender As Object, e As EventArgs) Handles ReqContractDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestContractDetails, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.RequestContractData(mOrderForm.RequestId, mOrderForm.ContractInfo, mOrderForm.IncludeExpiredContracts)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request all the API open orders that were placed by this client. Note the
    ' clientID with a client id of 0 returns its, plus the TWS TWS open orders. Once
    ' requested the TWS orders retain their API association.
    '--------------------------------------------------------------------------------
    Private Sub reqOpenOrdersButton_Click(sender As Object, e As EventArgs) Handles ReqOpenOrdersButton.Click
        mApi.RequestOpenOrders()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request the list of all the current open orders (from API clients and TWS). Note
    ' that no API order association is made.
    '--------------------------------------------------------------------------------
    Private Sub reqAllOpenOrdersButton_Click(sender As Object, e As EventArgs) Handles ReqAllOpenOrdersButton.Click
        mApi.RequestAllOpenOrders()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request that all new TWS orders are automatically associated with this client.
    ' NOTE: This feature is only available for a client with client id of 0.
    '--------------------------------------------------------------------------------
    Private Sub reqAutoOpenOrdersButton_Click(sender As Object, e As EventArgs) Handles ReqAutoOpenOrdersButton.Click
        mApi.RequestAutoOpenOrders(True)
    End Sub

    '--------------------------------------------------------------------------------
    ' Requests account details
    '--------------------------------------------------------------------------------
    Private Sub reqAcctDataButton_Click(sender As Object, e As EventArgs) Handles ReqAcctDataButton.Click
        mAccountUpdatesForm.ShowDialog()
        If (mAccountUpdatesForm.DialogResult = DialogResult.OK) Then
            mAccountDataForm.AccountDownloadBegin(mAccountUpdatesForm.AccountCode, Sub() mApi.RequestAccountData(False, mAccountUpdatesForm.AccountCode))
            mApi.RequestAccountData(True, mAccountUpdatesForm.AccountCode)
            If Not mAccountDataForm.Visible Then mAccountDataForm.Show(Me)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request all todays execution reports
    '--------------------------------------------------------------------------------
    Private Sub reqExecutionsButton_Click(sender As Object, e As EventArgs) Handles ReqExecutionsButton.Click
        Dim fExecFilter As New FExecFilter
        mTheme.ApplyTheme(fExecFilter.Controls)

        fExecFilter.Init(mExecFilter)
        fExecFilter.ShowDialog()
        If fExecFilter.Ok Then
            mApi.RequestExecutions(fExecFilter.ReqId, mExecFilter)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Requests to be notified for new IB news bulletins
    '--------------------------------------------------------------------------------
    Private Sub reqNewsButton_Click(sender As Object, e As EventArgs) Handles ReqNewsButton.Click
        mNewsBulletinsForm.ShowDialog()
        If mNewsBulletinsForm.Ok Then
            If mNewsBulletinsForm.Subscribe = True Then
                mApi.RequestNewsBulletins(mNewsBulletinsForm.AllMsgs)
            Else
                mApi.CancelNewsBulletins()
            End If
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Sets the TWS server logging level
    '--------------------------------------------------------------------------------
    Private Sub serverLogLevelButton_Click(sender As Object, e As EventArgs) Handles ServerLogLevelButton.Click
        mLogConfigForm.ShowDialog()
        If mLogConfigForm.Ok Then
            mApi.SetLogLevel(mLogConfigForm.ServerLogLevel())
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request managed accounts
    '--------------------------------------------------------------------------------
    Private Sub reqAcctsButton_Click(sender As Object, e As EventArgs) Handles ReqAcctsButton.Click
        mApi.RequestManagedAccounts()
    End Sub

    Private Sub financialAdvisorButton_Click(sender As Object, e As EventArgs) Handles FinancialAdvisorButton.Click
        mFaGroupXML = ""
        mFaProfilesXML = ""
        mFaAliasesXML = ""
        mFaError = False
        mApi.RequestFinancialAdvisorData(FinancialAdvisorDataType.AccountAliases)
        mApi.RequestFinancialAdvisorData(FinancialAdvisorDataType.Groups)
        mApi.RequestFinancialAdvisorData(FinancialAdvisorDataType.Profiles)
    End Sub

    '--------------------------------------------------------------------------------
    ' Calculate Implied Volatility
    '--------------------------------------------------------------------------------
    Private Sub calcImpliedVolatilityButton_Click(sender As Object, e As EventArgs) Handles CalcImpliedVolatilityButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CalculateImpliedVolatility, Nothing, Me)

        mOrderForm.ShowDialog()

        If mOrderForm.Ok Then
            mApi.CalculateImpliedVolatility(mOrderForm.RequestId, mOrderForm.ContractInfo, mOrderForm.OrderInfo.LmtPrice.Value, mOrderForm.OrderInfo.AuxPrice.Value)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Calculate Option Price
    '--------------------------------------------------------------------------------
    Private Sub calcOptionPriceButton_Click(sender As Object, e As EventArgs) Handles CalcOptionPriceButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CalculateOptionPrice, Nothing, Me)
        mOrderForm.ShowDialog()

        If mOrderForm.Ok Then

            mApi.CalculateOptionPrice(mOrderForm.RequestId, mOrderForm.ContractInfo, mOrderForm.OrderInfo.LmtPrice.Value, mOrderForm.OrderInfo.AuxPrice.Value)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel Calculate Implied Volatility
    '--------------------------------------------------------------------------------
    Private Sub cancelCalcImpliedVolatilityButton_Click(sender As Object, e As EventArgs) Handles CancelCalcImpliedVolatilityButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelCalculateImpliedVolatility, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.CancelCalculateImpliedVolatility(mOrderForm.RequestId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel Calculate Option Price
    '--------------------------------------------------------------------------------
    Private Sub cancelCalcOptionPriceButton_Click(sender As Object, e As EventArgs) Handles CancelCalcOptionPriceButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.CancelCalculateOptionPrice, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.CancelCalculateOptionPrice(mOrderForm.RequestId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request global cancel
    '--------------------------------------------------------------------------------
    Private Sub reqGlobalCancelButton_Click(sender As Object, e As EventArgs) Handles ReqGlobalCancelButton.Click
        mApi.RequestGlobalCancel()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request market data type
    '--------------------------------------------------------------------------------
    Private Sub reqMarketDataTypeButton_Click(sender As Object, e As EventArgs) Handles ReqMarketDataTypeButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestMarketDataType, Nothing, Me)

        mOrderForm.ShowDialog()
        If mOrderForm.Ok Then
            mApi.RequestMarketDataType(mOrderForm.MarketDataType)
        End If

        Select Case mOrderForm.MarketDataType
            Case MarketDataType.Realtime
                mServerResponsesText.DisplayMessage("Frozen, Delayed and Delayed-Frozen market data types are disabled")
            Case MarketDataType.Frozen
                mServerResponsesText.DisplayMessage("Frozen market data type is enabled")
            Case MarketDataType.Delayed
                mServerResponsesText.DisplayMessage("Delayed market data type is enabled, Delayed-Frozen market data type is disabled")
            Case MarketDataType.DelayedFrozen
                mServerResponsesText.DisplayMessage("Delayed and Delayed-Frozen market data types are enabled")
            Case Else
                mServerResponsesText.DisplayMessage("Unknown market data type")
        End Select
    End Sub

    '--------------------------------------------------------------------------------
    ' Request positions
    '--------------------------------------------------------------------------------
    Private Sub reqPositionsButton_Click(sender As Object, e As EventArgs) Handles ReqPositionsButton.Click
        mApi.RequestPositions()
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel positions
    '--------------------------------------------------------------------------------
    Private Sub cancelPositionsButton_Click(sender As Object, e As EventArgs) Handles CancelPositionsButton.Click
        mApi.CancelPositions()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request account summary
    '--------------------------------------------------------------------------------
    Private Sub reqAccountSummaryButton_Click(sender As Object, e As EventArgs) Handles ReqAccountSummaryButton.Click
        ' Set the dialog state
        mAccountSummaryForm.Init(FAccountSummary.Dlg_Type.REQUEST_ACCOUNT_SUMMARY)
        mAccountSummaryForm.ShowDialog()

        If mAccountSummaryForm.Ok Then
            mApi.RequestAccountSummary(mAccountSummaryForm.ReqId, mAccountSummaryForm.GroupName, mAccountSummaryForm.Tags)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel account summary
    '--------------------------------------------------------------------------------
    Private Sub cancelAccountSummaryButton_Click(sender As Object, e As EventArgs) Handles CancelAccountSummaryButton.Click
        ' Set the dialog state
        mAccountSummaryForm.Init(FAccountSummary.Dlg_Type.CANCEL_ACCOUNT_SUMMARY)
        mAccountSummaryForm.ShowDialog()

        If mAccountSummaryForm.Ok Then
            mApi.CancelAccountSummary(mAccountSummaryForm.ReqId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Open Groups dialog
    '--------------------------------------------------------------------------------
    Private Sub groupsButton_Click(sender As Object, e As EventArgs) Handles GroupsButton.Click
        mGroupsForm.Init(Me)
        mGroupsForm.ShowDialog()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request Positions Multi
    '--------------------------------------------------------------------------------
    Private Sub reqPositionsMultiButton_Click(sender As Object, e As EventArgs) Handles ReqPositionsMultiButton.Click
        Dim fPositions As New FPositions
        mTheme.ApplyTheme(fPositions.Controls)

        ' Set the dialog state
        fPositions.Init(FPositions.DialogType.RequestPositionsMulti)
        fPositions.ShowDialog()

        If fPositions.Ok Then
            mApi.RequestPositionsMulti(fPositions.Id, fPositions.Account, fPositions.ModelCode)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel Positions Multi
    '--------------------------------------------------------------------------------
    Private Sub cancelPositionsMultiButton_Click(sender As Object, e As EventArgs) Handles CancelPositionsMultiButton.Click
        Dim fPositions As New FPositions
        mTheme.ApplyTheme(fPositions.Controls)

        ' Set the dialog state
        fPositions.Init(FPositions.DialogType.CancelPositionsMulti)
        fPositions.ShowDialog()

        If fPositions.Ok Then
            mApi.CancelPositionsMulti(fPositions.Id)
        End If


    End Sub

    '--------------------------------------------------------------------------------
    ' Request Account Updates Multi
    '--------------------------------------------------------------------------------
    Private Sub reqAccountUpdatesMultiButton_Click(sender As Object, e As EventArgs) Handles ReqAccountUpdatesMultiButton.Click
        Dim fPositions As New FPositions
        mTheme.ApplyTheme(fPositions.Controls)

        ' Set the dialog state
        fPositions.Init(FPositions.DialogType.RequestAccountUpdatesMulti)
        fPositions.ShowDialog()

        If fPositions.Ok Then
            mApi.RequestAccountDataMulti(fPositions.Id, fPositions.Account, fPositions.ModelCode, fPositions.LedgerAndNLV)
        End If

    End Sub

    ''--------------------------------------------------------------------------------
    '' Cancel Account Updates Multi
    ''--------------------------------------------------------------------------------
    Private Sub cancelAccountUpdatesMultiButton_Click(sender As Object, e As EventArgs) Handles CancelAccountUpdatesMultiButton.Click
        Dim fPositions As New FPositions
        mTheme.ApplyTheme(fPositions.Controls)

        ' Set the dialog state
        fPositions.Init(FPositions.DialogType.CancelAccountUpdatesMulti)
        fPositions.ShowDialog()

        If fPositions.Ok Then
            mApi.CancelAccountUpdatesMulti(fPositions.Id)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Request Market Depth Exchanges
    '--------------------------------------------------------------------------------
    Private Sub reqMktDepthExchangesButton_Click(sender As Object, e As EventArgs) Handles ReqMktDepthExchangesButton.Click
        mApi.RequestMarketDepthExchanges()
    End Sub

    '--------------------------------------------------------------------------------
    ' Clear the form display lists
    '--------------------------------------------------------------------------------
    Private Sub clearFormButton_Click(sender As Object, e As EventArgs) Handles ClearFormButton.Click
        mMarketDataText.Clear()
        ServerResponsesText.Clear()
        ErrorsText.Clear()
        SocketLogText.Clear()
    End Sub

    Private Sub reqSecDefOptParamsButton_Click(sender As Object, e As EventArgs) Handles ReqSecDefOptParamsButton.Click
        Dim f = New FSecDefOptParamsReq()
        mTheme.ApplyTheme(FSecDefOptParamsReq.Controls)

        If f.ShowDialog() = DialogResult.OK Then
            mApi.RequestSecurityDefinitionOptionParams(f.ReqId, f.Symbol, f.Exchange, IBAPI.SecurityTypes.Parse(f.SecType, True), f.ConId)
        End If
    End Sub

    Private Sub familyCodesButton_Click(sender As Object, e As EventArgs) Handles FamilyCodesButton.Click
        mApi.RequestFamilyCodes()
    End Sub

    Private Sub reqMatchingSymbolsButton_Click(sender As Object, e As EventArgs) Handles ReqMatchingSymbolsButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestMatchingSymbols, Nothing, Me)

        mOrderForm.ShowDialog()

        If mOrderForm.Ok Then
            mApi.RequestMatchingSymbols(mOrderForm.RequestId, mOrderForm.ContractInfo.Symbol)
        End If
    End Sub

    Private Sub reqNewsProvidersButton_Click(sender As Object, e As EventArgs) Handles ReqNewsProvidersButton.Click
        mApi.RequestNewsProviders()
    End Sub


    Private Sub reqSmartComponentsButton_Click(sender As Object, e As EventArgs) Handles ReqSmartComponentsButton.Click

    End Sub

    '--------------------------------------------------------------------------------
    ' Request News Article
    '--------------------------------------------------------------------------------
    Private Sub reqNewsArticleButton_Click(sender As Object, e As EventArgs) Handles ReqNewsArticleButton.Click
        Static fNewsArticle As FNewsArticle
        If fNewsArticle Is Nothing Then
            fNewsArticle = New FNewsArticle
            mTheme.ApplyTheme(fNewsArticle.Controls)
        End If

        ' Set the dialog state
        fNewsArticle.Init()
        fNewsArticle.ShowDialog()

        If fNewsArticle.Ok Then
            mNewsArticlePath = fNewsArticle.Path
            mApi.RequestNewsArticle(fNewsArticle.RequestId, fNewsArticle.ProviderCode, fNewsArticle.ArticleId, fNewsArticle.Options)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request Historical News
    '--------------------------------------------------------------------------------
    Private Sub reqHistoricalNewsButton_Click(sender As Object, e As EventArgs) Handles ReqHistoricalNewsButton.Click
        Static fHistoricalNews As FHistoricalNews
        If fHistoricalNews Is Nothing Then
            fHistoricalNews = New FHistoricalNews
            mTheme.ApplyTheme(fHistoricalNews.Controls)
        End If

        ' Set the dialog state
        fHistoricalNews.Init()
        fHistoricalNews.ShowDialog()

        If fHistoricalNews.Ok Then
            mApi.RequestHistoricalNews(fHistoricalNews.RequestId, fHistoricalNews.ConId, fHistoricalNews.ProviderCodes,
                                    CDate(fHistoricalNews.StartDateTime), CDate(fHistoricalNews.EndDateTime), fHistoricalNews.TotalResults, fHistoricalNews.Options)
        End If
    End Sub

    Private Sub reqMarketRuleButton_Click(sender As Object, e As EventArgs) Handles ReqMarketRuleButton.Click
        Dim fMarketRule As New FMarketRule
        mTheme.ApplyTheme(fMarketRule.Controls)

        fMarketRule.Init()
        fMarketRule.ShowDialog()

        If fMarketRule.Ok Then
            mApi.RequestMarketRule(fMarketRule.MarketRuleId)
        End If
    End Sub

    Private Sub reqTickByTickButton_Click(sender As Object, e As EventArgs) Handles ReqTickByTickButton.Click
        mOrderForm.Init(FOrder.OrderFormMode.RequestTickByTick, Nothing, Me)

        If mOrderForm.ShowDialog() = DialogResult.OK Then
            mApi.RequestTickByTickData(mOrderForm.RequestId, mOrderForm.ContractInfo, mOrderForm.TickByTickDataType, mOrderForm.NumberOfTicks, mOrderForm.IgnoreSize)
        End If
    End Sub

    Private Sub cancelTickByTickButton_Click(sender As Object, e As EventArgs) Handles CancelTickByTickButton.Click
        mOrderForm.Init(FOrder.OrderFormMode.CancelTickByTick, Nothing, Me)

        If mOrderForm.ShowDialog() = DialogResult.OK Then
            mApi.CancelTickByTickData(mOrderForm.RequestId)
        End If
    End Sub

    Private Sub reqHeadTimestampButton_Click(sender As Object, e As EventArgs) Handles ReqHeadTimestampButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestHistoricalData, mChartOptions, Me)

        mOrderForm.ShowDialog()

        mChartOptions = mOrderForm.Options

        If mOrderForm.Ok Then

            mApi.RequestHeadTimestamp(mOrderForm.RequestId, mOrderForm.ContractInfo,
                mOrderForm.WhatToShow, mOrderForm.UseRTH)
        End If
    End Sub

    Private Sub reqHistogramDataButton_Click(sender As Object, e As EventArgs) Handles ReqHistogramDataButton.Click
        ' Set the dialog state
        mOrderForm.Init(FOrder.OrderFormMode.RequestHistoricalData, mChartOptions, Me)

        mOrderForm.ShowDialog()

        mChartOptions = mOrderForm.Options

        If mOrderForm.Ok Then

            mApi.RequestHistogramData(mOrderForm.RequestId, mOrderForm.ContractInfo, mOrderForm.HistBarSizeSetting, mOrderForm.UseRTH)
        End If
    End Sub

    Private Sub reqPnlButton_Click(sender As Object, e As EventArgs) Handles ReqPnlButton.Click
        If mPnLForm.ShowDialog() = DialogResult.OK Then
            mApi.RequestPnL(mPnLForm.ReqId, mPnLForm.Account, mPnLForm.ModelCode)
        End If
    End Sub

    Private Sub cancelPnlButton_Click(sender As Object, e As EventArgs) Handles CancelPnlButton.Click
        mApi.CancelPnL(mPnLForm.ReqId)
    End Sub

    Private Sub reqPnlSingleButton_Click(sender As Object, e As EventArgs) Handles ReqPnlSingleButton.Click
        If mPnLForm.ShowDialog() = DialogResult.OK Then
            mApi.RequestPnLSingle(mPnLForm.ReqId, mPnLForm.Account, mPnLForm.ModelCode, mPnLForm.ConId)
        End If
    End Sub

    Private Sub cancelPnlSingleButton_Click(sender As Object, e As EventArgs) Handles CancelPnlSingleButton.Click
        mApi.CancelPnLSingle(mPnLForm.ReqId)
    End Sub

    Private Sub reqHistoricalTicksButton_Click(sender As Object, e As EventArgs) Handles ReqHistoricalTicksButton.Click
        mOrderForm.Init(FOrder.OrderFormMode.RequestHistoricalTicks, mMarketDataOptions, Me)

        If mOrderForm.ShowDialog() = DialogResult.OK Then
            Dim r As New HistoricalTicksRequest With {.Contract = mOrderForm.ContractInfo,
                .EndDateTime = mOrderForm.HistEndDateTime,
                .EndTimezone = mOrderForm.HistEndTimezone,
                .NumberOfTicks = mOrderForm.NumberOfTicks,
                .StartDateTime = mOrderForm.HistStartDateTime,
                .StartTimezone = mOrderForm.HistStartTimezone,
                .WhatToShow = mOrderForm.WhatToShow}
            mApi.RequestHistoricalTickData(mOrderForm.RequestId, r, mOrderForm.UseRTH, mOrderForm.IgnoreSize, mOrderForm.Options)
        End If
    End Sub

#End Region

#Region "API event handlers"

#Region "Account Events"
    Private Sub _AccountDownloadEnd(sender As Object, e As AccountDownloadEndEventArgs) Handles ApiEvents.AccountDownloadEnd
        Dim accountName = e.Account
        mAccountDataForm.AccountDownloadEnd(accountName)
        mServerResponsesText.DisplayMessage($"Account Download End: {accountName}")
    End Sub

    Private Sub _AccountSummary(sender As Object, e As AccountSummaryEventArgs) Handles ApiEvents.AccountSummary
        mServerResponsesText.DisplayMessage($"reqId={e.RequestId} account={e.Account} tag={e.Tag} value={e.Value} currency={e.Currency}")
    End Sub

    Private Sub _AccountSummaryEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.AccountSummaryEnd
        mServerResponsesText.DisplayMessage($"AccountSummary({e.RequestId}) =============== end ===============")
    End Sub

    Private Sub _AccountUpdateMulti(sender As Object, e As AccountUpdateMultiEventArgs) Handles ApiEvents.AccountUpdateMulti
        mServerResponsesText.DisplayMessage($"reqId={e.ReqId} account={e.Account} modelCode={e.ModelCode} key={e.Key} value={e.Value} currency={e.Currency}")
    End Sub

    Private Sub _AccountUpdateMultiEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.AccountUpdateMultiEnd
        mServerResponsesText.DisplayMessage($"==== Account Update Multi End reqId={e.RequestId} ==== ", e.Timestamp)
    End Sub

    Private Sub _AdvisorData(sender As Object, e As AdvisorDataEventArgs) Handles ApiEvents.AdvisorData
        mServerResponsesText.DisplayMessage($"FA {FaMsgTypeName(e.FaDataType)}={e.Data}", e.Timestamp)
        Select Case e.FaDataType
            Case FinancialAdvisorDataType.Groups
                mFaGroupXML = e.Data
            Case FinancialAdvisorDataType.Profiles
                mFaProfilesXML = e.Data
            Case FinancialAdvisorDataType.AccountAliases
                mFaAliasesXML = e.Data
        End Select

        If mFaError = False And mFaGroupXML <> "" And mFaProfilesXML <> "" And mFaAliasesXML <> "" Then

            mFinancialAdvisorForm.Init(mFaGroupXML, mFaProfilesXML, mFaAliasesXML)
            mFinancialAdvisorForm.ShowDialog()
            If mFinancialAdvisorForm.Ok Then
                mApi.ReplaceFA(FinancialAdvisorDataType.Groups, mFinancialAdvisorForm.GroupsXML)
                mApi.ReplaceFA(FinancialAdvisorDataType.Profiles, mFinancialAdvisorForm.ProfilesXML)
                mApi.ReplaceFA(FinancialAdvisorDataType.AccountAliases, mFinancialAdvisorForm.AliasesXML)
            End If

        End If

    End Sub

    Private Sub _FamilyCodes(sender As Object, e As FamilyCodesEventArgs) Handles ApiEvents.FamilyCodes
        mServerResponsesText.DisplayMessage(" ==== Family Codes Begin (total={e.FamilyCodes.Count}) ====", e.Timestamp)
        Dim count = 0
        For Each familyCode As FamilyCode In e.FamilyCodes
            mServerResponsesText.DisplayMessage($"Family Code ({count}): accountID={familyCode.AccountID} familyCode={familyCode.FamilyCode}")
            count += 1
        Next
        mServerResponsesText.DisplayMessage($" ==== Family Codes End (total={e.FamilyCodes.Count}) ====")
    End Sub

    Private Sub _ManagedAccounts(sender As Object, e As ManagedAccountsEventArgs) Handles ApiEvents.ManagedAccounts
        mFaAccountsList = String.Join(Of String)(",", e.ManagedAccounts)
        mServerResponsesText.DisplayMessage($"Managed accounts: {mFaAccountsList}", e.Timestamp)
        mFaAccount = True
    End Sub

    Private Sub _PnL(sender As Object, e As PnLEventArgs) Handles ApiEvents.PnL
        mServerResponsesText.DisplayMessage($"PnL: req id={e.RequestId} DailyPnL={e.DailyPnL} UnrealizedPnL={e.UnrealizedPnL} RealizedPnL={e.RealizedPnL}", e.Timestamp)
    End Sub

    Private Sub _PnLSingle(sender As Object, e As PnLSingleEventArgs) Handles ApiEvents.PnLSingle
        mServerResponsesText.DisplayMessage($"PnL Single: req id: {e.RequestId}, Pos:{e.Position}, Daily PnL: {e.PnL}, Unrealized PnL: {e.UnrealizedPnL}, Realized PnL: {e.RealizedPnL}, Value: {e.Value}", e.Timestamp)
    End Sub

    Private Sub _Position(sender As Object, e As PositionEventArgs) Handles ApiEvents.Position
        mServerResponsesText.DisplayMessage(" ---- Position ----", e.Timestamp)
        mServerResponsesText.DisplayMessage($"account={e.Account}")
        mServerResponsesText.DisplayMessage("Contract")

        With e.Contract
            mServerResponsesText.DisplayMessage($"  conId={ .ConId}")
            mServerResponsesText.DisplayMessage($"  symbol={ .Symbol}")
            mServerResponsesText.DisplayMessage($"  secType={ .SecType}")
            mServerResponsesText.DisplayMessage($"  lastTradeDate={ .Expiry}")
            mServerResponsesText.DisplayMessage($"  strike={ .Strike}")
            mServerResponsesText.DisplayMessage($"  right={ .OptRight}")
            mServerResponsesText.DisplayMessage($"  multiplier={ .Multiplier}")
            mServerResponsesText.DisplayMessage($"  exchange={ .Exchange}")
            mServerResponsesText.DisplayMessage($"  primaryExchange={ .PrimaryExch}")
            mServerResponsesText.DisplayMessage($"  currency={ .CurrencyCode}")
            mServerResponsesText.DisplayMessage($"  localSymbol={ .LocalSymbol}")
            mServerResponsesText.DisplayMessage($"  tradingClass={ .TradingClass}")
        End With

        mServerResponsesText.DisplayMessage($"position={IBAPI.NullableToString(e.Position)}")
        mServerResponsesText.DisplayMessage($"avgCost={IBAPI.NullableToString(e.AverageCost)}")
        mServerResponsesText.DisplayMessage(" ---- Position End ----")
    End Sub

    Private Sub _PositionEnd(sender As Object, e As EventArgs) Handles ApiEvents.PositionEnd
        mServerResponsesText.DisplayMessage(" ==== Position End ==== ")
    End Sub

    Private Sub _PositionMulti(sender As Object, e As PositionMultiEventArgs) Handles ApiEvents.PositionMulti
        mServerResponsesText.DisplayMessage(" ---- Position Multi ----", e.Timestamp)
        mServerResponsesText.DisplayMessage($"reqId={e.ReqId}")
        mServerResponsesText.DisplayMessage($"account={e.Account}")
        mServerResponsesText.DisplayMessage($"modelCode={e.ModelCode}")
        mServerResponsesText.DisplayMessage("Contract")

        With e.Contract
            mServerResponsesText.DisplayMessage($"  conId={ .ConId}")
            mServerResponsesText.DisplayMessage($"  symbol={ .Symbol}")
            mServerResponsesText.DisplayMessage($"  secType={ .SecType}")
            mServerResponsesText.DisplayMessage($"  lastTradeDate={ .Expiry}")
            mServerResponsesText.DisplayMessage($"  strike={ .Strike}")
            mServerResponsesText.DisplayMessage($"  right={ .OptRight}")
            mServerResponsesText.DisplayMessage($"  multiplier={ .Multiplier}")
            mServerResponsesText.DisplayMessage($"  exchange={ .Exchange}")
            mServerResponsesText.DisplayMessage($"  primaryExchange={ .PrimaryExch}")
            mServerResponsesText.DisplayMessage($"  currency={ .CurrencyCode}")
            mServerResponsesText.DisplayMessage($"  localSymbol={ .LocalSymbol}")
            mServerResponsesText.DisplayMessage($"  tradingClass={ .TradingClass}")
        End With

        mServerResponsesText.DisplayMessage($"position={IBAPI.NullableToString(e.Position)}")
        mServerResponsesText.DisplayMessage($"avgCost={IBAPI.NullableToString(e.AverageCost)}")
        mServerResponsesText.DisplayMessage(" ---- Position Multi End ----")
    End Sub

    Private Sub _PositionMultiEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.PositionMultiEnd
        mServerResponsesText.DisplayMessage("reqId={e.RequestId} ==== Position Multi End ==== ")
    End Sub

    Private Sub _SoftDollarTiers(sender As Object, e As SoftDollarTiersEventArgs) Handles ApiEvents.SoftDollarTiers
        mServerResponsesText.DisplayMessage(" ==== Soft Dollar Tiers Begin ====", e.Timestamp)
        e.Tiers.ForEach(Sub(t) mServerResponsesText.DisplayMessage($"DisplayName={t.DisplayName}, Name={t.Name}, Value={t.Value}"))
        mServerResponsesText.DisplayMessage(" ==== Soft Dollar Tiers End ====")
    End Sub

    Private Sub _UpdateAccountTime(sender As Object, e As UpdateAccountTimeEventArgs) Handles ApiEvents.UpdateAccountTime
        mAccountDataForm.UpdateAccountTime(e.AccountTimestamp)
    End Sub

    Private Sub _UpdateAccountValue(sender As Object, e As UpdateAccountValueEventArgs) Handles ApiEvents.UpdateAccountValue
        mAccountDataForm.UpdateAccountValue(e.Key, e.Value, e.Currency, e.AccountName)
    End Sub

    Private Sub _UpdatePortfolio(sender As Object, e As UpdatePortfolioEventArgs) Handles ApiEvents.UpdatePortfolio
        mAccountDataForm.UpdatePortfolio(e.Contract, e.Position, e.MarketPrice, e.MarketValue, e.AverageCost, e.UnrealizedPNL, e.RealizedPNL, e.AccountName)
    End Sub

#End Region

#Region "Connection Status Events"

    Private Sub _ConnectionStateChange(sender As Object, e As ApiConnectionStateChangeEventArgs) Handles ApiEvents.ConnectionStateChange
        If e.State = ApiConnectionState.Connected Then
            If mApi.ServerVersion() <= 0 Then Throw New InvalidOperationException("Not server version returned")

            setConnectionState(ApiConnectionState.Connected)

            mServerResponsesText.DisplayMessage($"Connected to Tws: server version {mApi.ServerVersion}", e.Timestamp)

            If mUseQueueing Then
                PauseAPIButton.Enabled = True
                PauseAPIButton.Text = "Pause API"
            End If
        ElseIf e.State = ApiConnectionState.Failed Then
            setConnectionState(ApiConnectionState.Failed)
            mServerResponsesText.DisplayMessage($"Connection to Tws failed: {e.Message}", e.Timestamp)
            PauseAPIButton.Enabled = False
        ElseIf e.State = ApiConnectionState.NotConnected Then
            setConnectionState(ApiConnectionState.NotConnected)
            mServerResponsesText.DisplayMessage("Connection to Tws has been closed", e.Timestamp)
            PauseAPIButton.Enabled = False
        End If
    End Sub

    Private Sub _CurrentTime(sender As Object, e As CurrentTimeEventArgs) Handles ApiEvents.CurrentTime
        mServerResponsesText.DisplayMessage($"Current server time = {e.ServerTimestamp.ToString("yyyyMMdd-HH:mm:ss.fff")}", e.Timestamp)
    End Sub

    Private Sub _IBServerConnectionStateChange(sender As Object, e As IBServerConnectionStateChangeEventArgs) Handles ApiEvents.IBServerConnectionStateChanged
        Select Case e.State
            Case IBServerConnectionState.Connected
                mServerResponsesText.DisplayMessage($"IB Server connection restored: message = {e.Message} date lost={e.DataLost}", e.Timestamp)
            Case IBServerConnectionState.Disconnected
                mServerResponsesText.DisplayMessage($"IB Server connection closed: message={e.Message}", e.Timestamp)
        End Select
    End Sub

#End Region

#Region "Contract Events"

    Private Sub _ContractDetails(sender As Object, e As ContractDetailsEventArgs) Handles ApiEvents.ContractDetails
        Dim c = e.ContractDetails.Summary
        Dim cd = e.ContractDetails
        mServerResponsesText.DisplayMessage(
$"---- Contract Details Begin ----
Contract
    conId = {c.ConId}
    symbol = {c.Symbol}
    secType = {IBAPI.SecurityTypes.ToInternalString(c.SecType)}
    lastTradeDate = {c.Expiry}
    strike = {c.Strike}
    Right = {c.OptRight}
    multiplier = {c.Multiplier}
    exchange = {c.Exchange}
    primaryExchange = {c.PrimaryExch}
    Currency = {c.CurrencyCode}
    localSymbol = {c.LocalSymbol}
    tradingClass = {c.TradingClass}

Details
    marketName = {cd.MarketName}
    minTick = {cd.MinTick}
    priceMagnifier = {cd.PriceMagnifier}
    OrderTypes = {cd.OrderTypes}
    validExchanges = {cd.ValidExchanges}
    underConId = {cd.UnderConId}
    longName = {cd.LongName}")

        If (c.SecType <> SecurityType.Bond) Then mServerResponsesText.DisplayMessage(
 $"    contractMonth = {cd.ContractMonth}
    industry = {cd.Industry}
    category = {cd.Category}
    subcategory = {cd.Subcategory}
    timeZoneId = {cd.TimeZoneId}
    tradingHours = {vbCrLf}        {String.Join(vbCrLf & "        ", cd.TradingHours.Split(";"c))}
    liquidHours = {vbCrLf}        {String.Join(vbCrLf & "        ", cd.LiquidHours.Split(";"c))}")

        mServerResponsesText.DisplayMessage(
$"    evRule = {cd.EvRule}
    evMultiplier = {cd.EvMultiplier}
    mdSizeMultiplier = {cd.MDSizeMultiplier}
    aggGroup = {cd.AggGroup}
    underSymbol = {cd.UnderSymbol}
    underSecType = {cd.UnderSecType}
    marketRuleIds = {cd.MarketRuleIds}
    realExpirationDate = {cd.RealExpirationDate}
    lastTradeTime = {cd.LastTradeTime}")

        If (c.SecType = SecurityType.Bond) Then mServerResponsesText.DisplayMessage(
$"Bond Details
    cusip = {cd.Cusip}
    ratings = {cd.Ratings}
    descAppend = {cd.DescAppend}
    bondType = {cd.BondType}
    couponType = {cd.CouponType}
    callable = {cd.Callable}
    putable = {cd.Putable}
    coupon = {cd.Coupon}
    convertible = {cd.Convertible}
    maturity = {cd.Maturity}
    issueDate = {cd.IssueDate}
    nextOptionDate = {cd.NextOptionDate}
    nextOptionType = {cd.NextOptionType}
    nextOptionPartial = {cd.NextOptionPartial}
    notes = {cd.Notes}", e.Timestamp)

        ' CUSIP/ISIN/etc.
        mServerResponsesText.DisplayMessage(
$"  secIdList=({cd.SecIdList?.ToString})
---- Contract Details End ----")
    End Sub

    Private Sub _ContractDetailsEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.ContractDetailsEnd
        mServerResponsesText.DisplayMessage($"ContractDetails({e.RequestId}) =============== end ===============")
    End Sub

    Private Sub _ContractDetailsError(sender As Object, e As RequestErrorEventArgs) Handles ApiEvents.ContractDetailsError
        mErrorsText.DisplayMessage($" Id {e.RequestId}; Error Code: {e.ErrorCode}; Error Msg: {e.Message}")
    End Sub

    Private Sub _MarketRule(sender As Object, e As MarketRuleEventArgs) Handles ApiEvents.MarketRule
        mServerResponsesText.DisplayMessage($" ==== Market Rule Begin (marketRuleId={e.MarketRuleId}) ====", e.Timestamp)
        e.PriceIncrements.ForEach(Sub(p) mServerResponsesText.DisplayMessage($"LowEdge={p.LowEdge}, Increment={p.Increment}"))
        mServerResponsesText.DisplayMessage($" ==== Market Rule End (marketRuleId={e.MarketRuleId}) ====")
    End Sub

    Private Sub _SecurityDefinitionOptionParameter(sender As Object, e As SecurityDefinitionOptionParameterEventArgs) Handles ApiEvents.SecurityDefinitionOptionParameter
        mServerResponsesText.DisplayMessage($"reqId {e.RequestId}, exchange {e.Exchange}, underlyingConId: {e.UnderlyingConId}, tradingClass: {e.TradingClass}, multiplier: {e.Multiplier}, expirations: {String.Join(",", e.Expirations)}, strikes: {String.Join(",", e.Strikes)}", e.Timestamp)
    End Sub

    Private Sub _SecurityDefinitionOptionParameterEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.SecurityDefinitionOptionParameterEnd
        mServerResponsesText.DisplayMessage($" ==== Security Definition Option Parameter End (requestId={e.RequestId}) ====")
    End Sub

    Private Sub _SymbolSamples(sender As Object, e As SymbolSamplesEventArgs) Handles ApiEvents.SymbolSamples
        mServerResponsesText.DisplayMessage($" ==== Symbol Samples (total={e.ContractDescriptions.Count}) reqId={e.RequestId} ====", e.Timestamp)
        Dim count As Integer = 0
        For Each cd As ContractDescription In e.ContractDescriptions
            mServerResponsesText.DisplayMessage($" ---- Contract Description ({count}) ----", e.Timestamp)
            With cd.Contract
                mServerResponsesText.DisplayMessage($"conId={ .ConId}")
                mServerResponsesText.DisplayMessage($"symbol={ .Symbol}")
                mServerResponsesText.DisplayMessage($"secType={ .SecType}")
                mServerResponsesText.DisplayMessage($"primExch={ .PrimaryExch}")
                mServerResponsesText.DisplayMessage($"currency={ .CurrencyCode}")
            End With

            Dim displayString = "derivative secTypes="
            For Each derivativeSecType As String In cd.DerivativeSecTypes
                displayString += (derivativeSecType & " ")
            Next
            mServerResponsesText.DisplayMessage(displayString)
            mServerResponsesText.DisplayMessage(" ---- Contract Description End ({count}) ----")
            count += 1
        Next
        mServerResponsesText.DisplayMessage(" ==== Symbol Samples End (total={e.ContractDescriptions.Count}) reqId={e.RequestId} ====")
    End Sub

#End Region

#Region "IDisplayGroup Events"

    Private Sub _DisplayGroupList(sender As Object, e As DisplayGroupListEventArgs) Handles ApiEvents.DisplayGroupList
        mGroupsForm.DisplayGroupList(e.RequestId, e.Groups)
    End Sub

    Private Sub _DisplayGroupUpdated(sender As Object, e As DisplayGroupUpdatedEventArgs) Handles ApiEvents.DisplayGroupUpdated
        mGroupsForm.DisplayGroupUpdated(e.RequestId, e.ContractInfo)
    End Sub

#End Region

#Region "Error and Notification Events"

    Private Sub _ApiError(sender As Object, e As ApiErrorEventArgs) Handles ApiEvents.ApiError
        mErrorsText.DisplayMessage($"Error Code: {e.ErrorCode}; Error Msg: {e.Message}")
        For Each errorCode In mFaErrorCodes
            If e.ErrorCode = errorCode Then mFaError = True
        Next
    End Sub

    Private Sub _ApiEvent(sender As Object, e As ApiEventEventArgs) Handles ApiEvents.ApiEvent
        mServerResponsesText.DisplayMessage($"Event Code: {e.EventCode}; Event Msg: {e.EventMessage}", e.Timestamp)
    End Sub

    Private Sub _Exception(sender As Object, e As ExceptionEventArgs) Handles ApiEvents.Exception
        mErrorsText.DisplayMessage($"Exception: {e.Exception.ToString}")
    End Sub

#End Region

#Region "IFundamentalData Events"

    Private Sub _FundamentalData(sender As Object, e As FundamentalDataEventArgs) Handles ApiEvents.FundamentalData
        mMarketDataText.DisplayMessage($"fund reqId={e.RequestId} len={Len(e.Data)}")
        mMarketDataText.DisplayMessage(e.Data)
    End Sub

#End Region

#Region "Historical Data Events"

    Private Sub _HeadTimestamp(sender As Object, e As HeadTimestampEventArgs) Handles ApiEvents.HeadTimestamp
        mServerResponsesText.DisplayMessage($"Head time stamp: request id - {e.RequestId}, time stamp - {e.HeadTimestamp}", e.Timestamp)
    End Sub

    Private Sub _HistogramData(sender As Object, e As HistogramDataEventArgs) Handles ApiEvents.HistogramData
        Dim sb = New System.Text.StringBuilder
        sb.AppendLine($"Histogram data. Request Id: {e.RequestId}, data size: {e.HistData.Count}")
        e.HistData.ForEach(Sub(i) sb.AppendLine($"{vbTab}Price: {i.Price}, Size: {i.Size}"))
        mServerResponsesText.DisplayMessage(sb.ToString(), e.Timestamp)
    End Sub

    Private Sub _HistoricalBar(sender As Object, e As HistoricalBarEventArgs) Handles ApiEvents.HistoricalBar
        mMarketDataText.DisplayMessage($"id={e.RequestId} date={e.Bar.TimeStamp.ToString("yyyyMMdd-HH:mm:ss")} open={e.Bar.OpenValue} high={e.Bar.HighValue} " &
                     $"low={e.Bar.LowValue} close={e.Bar.CloseValue} volume={e.Bar.Volume} " &
                     $"barCount={e.Bar.TickVolume} WAP={e.Bar.WAP}")
    End Sub

    Private Sub _HistoricalBarError(sender As Object, e As RequestErrorEventArgs) Handles ApiEvents.HistoricalBarError
        mErrorsText.DisplayMessage($" Id {e.RequestId}; Error Code: {e.ErrorCode}; Error Msg: {e.Message}")
    End Sub

    Private Sub _HistoricalBarsEnd(sender As Object, e As HistoricalBarsRequestEventArgs) Handles ApiEvents.HistoricalBarsEnd
        mMarketDataText.DisplayMessage($"Historical Bars End. Request Id: {e.RequestId} start: {e.StartDate} end: {e.EndDate}")
    End Sub

    Private Sub _HistoricalBarsStart(sender As Object, e As HistoricalBarsRequestEventArgs) Handles ApiEvents.HistoricalBarsStart
        mMarketDataText.DisplayMessage($"Historical Bars Start. Request Id: {e.RequestId} start: {e.StartDate} end: {e.EndDate}", e.Timestamp)
    End Sub

    Private Sub _HistoricalBidAsk(sender As Object, e As HistoricalBidAskEventArgs) Handles ApiEvents.HistoricalBidAsk
        mMarketDataText.DisplayMessage($"Historical Tick Bid/Ask. Request Id: {e.RequestId}, Time: {e.Time.ToString("yyyyMMdd-HH:mm:ss")}, Price Bid: {e.BidPrice}, Price Ask: {e.AskPrice}, Size Bid: {e.BidSize}, Size Ask: {e.AskSize}, Attributes: {e.Attributes}", e.Timestamp)
    End Sub

    Private Sub _HistoricalBidAsksEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.HistoricalBidAsksEnd
        mMarketDataText.DisplayMessage($"Historical Tick Bid/Ask End. Request Id: {e.RequestId}")
    End Sub

    Private Sub _HistoricalMidpoint(sender As Object, e As HistoricalMidpointEventArgs) Handles ApiEvents.HistoricalMidpoint
        mMarketDataText.DisplayMessage($"Historical Tick Midpoint. Request Id: {e.RequestId}, Time: {e.Time.ToString("yyyyMMdd-HH:mm:ss")}, Price: {e.Price}, Size: {e.Size}", e.Timestamp)
    End Sub

    Private Sub _HistoricalMidpointsEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.HistoricalMidpointsEnd
        mMarketDataText.DisplayMessage($"Historical Tick Midpoint End. Request Id: {e.RequestId}")
    End Sub

    Private Sub _HistoricalTrade(sender As Object, e As HistoricalTradeEventArgs) Handles ApiEvents.HistoricalTrade
        mMarketDataText.DisplayMessage($"Historical Tick Trade. Request Id: {e.RequestId}, Time: {e.Time.ToString("yyyyMMdd-HH:mm:ss")}, Price: {e.Price}, Size: {e.Size}, Exchange: {e.Exchange}, Special Conditions: {e.SpecialConditions}, Last Tick Attributes: {e.Attributes}", e.Timestamp)
    End Sub

    Private Sub _HistoricalTradesEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.HistoricalTradesEnd
        mMarketDataText.DisplayMessage($"Historical Tick Trade End. Request Id: {e.RequestId}", e.Timestamp)
    End Sub

#End Region

#Region "Market Data Events"

    Private Sub _MarketDataError(sender As Object, e As RequestErrorEventArgs) Handles ApiEvents.MarketDataError
        mErrorsText.DisplayMessage($"ID: {e.RequestId}; Error Code: {e.ErrorCode}; Error Msg: {e.Message}")
    End Sub

    Private Sub _MarketDataType(sender As Object, e As MarketDataTypeEventArgs) Handles ApiEvents.MarketDataType
        mMarketDataText.DisplayMessage($"id={e.RequestId} MarketDataType={[Enum].GetName(GetType(MarketDataType), e.MarketDataType)}", e.Timestamp)
    End Sub

    Private Sub _RealtimeBar(sender As Object, e As RealtimeBarEventArgs) Handles ApiEvents.RealtimeBar
        mMarketDataText.DisplayMessage($"id={e.RequestId} time={e.Bar.TimeStamp.ToString("yyyyMMdd-HH:mm:ss")} open={e.Bar.OpenValue} high={e.Bar.HighValue} " &
                        $"low={e.Bar.LowValue} close={e.Bar.CloseValue} volume={e.Bar.Volume} WAP={e.Bar.WAP} " &
                        $"count={e.Bar.TickVolume}", e.Timestamp)
    End Sub

    Private Sub _RerouteMarketData(sender As Object, e As RerouteDataEventArgs) Handles ApiEvents.RerouteMarketData
        mServerResponsesText.DisplayMessage($"Re-route market data request. Req Id: {e.RequestId}, Con Id: {e.ConId}, Exchange: {e.Exchange}", e.Timestamp)
    End Sub

    Private Sub _SmartComponents(sender As Object, e As SmartComponentsEventArgs) Handles ApiEvents.SmartComponents
        mServerResponsesText.DisplayMessage(" ---- Smart Components Begin ----", e.Timestamp)

        For Each item In e.Dict
            mServerResponsesText.DisplayMessage($"bitNumber={item.Key}")
            mServerResponsesText.DisplayMessage($"Exchange={item.Value.Key}")
            mServerResponsesText.DisplayMessage($"Exchange letter={item.Value.Value}")
        Next

        mServerResponsesText.DisplayMessage(" ---- Smart Components End ----")
    End Sub

    Private Sub _TickByTickAllLast(sender As Object, e As TickByTickAllLastEventArgs) Handles ApiEvents.TickByTickAllLast
        mMarketDataText.DisplayMessage($"Tick-By-Tick. Request Id: {e.RequestId}, DataType: {IBAPI.TickByTickDataTypes.ToExternalString(e.DataType)}, Time: {e.Time.ToString("yyyyMMdd-HH:mm:ss")}, Price: {e.Price}, Size: {e.Size}, Exchange: {e.Exchange}, Special Conditions: {e.SpecialConditions}, Attributes: {e.Attributes}", e.Timestamp)
        mMarketDataText.DisplayMessage($"Latency: {Now - e.Time}")
    End Sub

    Private Sub _TickByTickBidAsk(sender As Object, e As TickByTickBidAskEventArgs) Handles ApiEvents.TickByTickBidAsk
        mMarketDataText.DisplayMessage($"Tick-By-Tick. Request Id: {e.RequestId}, TickType: BidAsk, Time: {e.Time.ToString("yyyyMMdd-HH:mm:ss")}, BidPrice: {e.BidPrice}, AskPrice: {e.AskPrice}, BidSize: {e.BidSize}, AskSize: {e.AskSize}, Attributes: {e.Attributes}", e.Timestamp)
        mMarketDataText.DisplayMessage($"Latency: {Now - e.Time}")
    End Sub

    Private Sub _TickByTickMidPoint(sender As Object, e As TickByTickMidPointEventArgs) Handles ApiEvents.TickByTickMidPoint
        mMarketDataText.DisplayMessage($"Tick-By-Tick. Request Id: {e.RequestId}, TickType: MidPoint, Time: {e.Time.ToString("yyyyMMdd-HH:mm:ss")}, MidPoint: {e.MidPoint}", e.Timestamp)
        mMarketDataText.DisplayMessage($"Latency: {Now - e.Time}")
    End Sub

    Private Sub _TickEFP(sender As Object, e As TickEFPEventArgs) Handles ApiEvents.TickEFP
        mMarketDataText.DisplayMessage($"
id={e.TickerId} {GetField(e.TickType)}:{e.BasisPoints} / {e.FormattedBasisPoints}
    totalDividends = {e.DividendsToLastTradeDate} holdDays={e.HoldDays}
    futureLastTradeDate = {e.FutureLastTradeDate} dividendImpact={e.DividendImpact}
    dividendsToLastTradeDate = {e.DividendsToLastTradeDate}", e.Timestamp)
    End Sub

    Private Sub _TickGeneric(sender As Object, e As TickGenericEventArgs) Handles ApiEvents.TickGeneric
        mMarketDataText.DisplayMessage($"id={e.TickerId} {GetField(e.TickType)}={e.Value}", e.Timestamp)
    End Sub

    Private Sub _TickOptionComputation(sender As Object, e As TickOptionComputationEventArgs) Handles ApiEvents.TickOptionComputation
        mMarketDataText.DisplayMessage($"
id={e.TickerId} {GetField(e.Field)} vol={IBAPI.NullableToString(e.ImpliedVolatility)} 
    delta={IBAPI.NullableToString(e.Delta)} gamma={IBAPI.NullableToString(e.Gamma)} 
    vega={IBAPI.NullableToString(e.Vega)} theta={IBAPI.NullableToString(e.Theta) }
    optPrice={IBAPI.NullableToString(e.OptPrice)} pvDividend={IBAPI.NullableToString(e.PvDividend)}
    undPrice={IBAPI.NullableToString(e.UndPrice)}", e.Timestamp)
    End Sub

    Private Sub _TickPrice(sender As Object, e As TickPriceEventArgs) Handles ApiEvents.TickPrice
        mMarketDataText.DisplayMessage($"id={e.TickerId} {GetField(e.Field)}={e.Price} size={e.Size} {e.Attributes.ToString}", e.Timestamp)
    End Sub

    Private Sub _TickRequestParams(sender As Object, e As TickRequestParamsEventArgs) Handles ApiEvents.TickRequestParams
        mServerResponsesText.DisplayMessage($"
---- Tick Req Params Begin ----
    tickerId={e.TickerId}
    minTick={e.MinTick}
    bboExchange={e.BBOExchange}
    snapshotPermissions={e.SnapshotPermissions}
---- Tick Req Params End ----", e.Timestamp)
    End Sub

    Private Sub _TickSize(sender As Object, e As TickSizeEventArgs) Handles ApiEvents.TickSize
        mMarketDataText.DisplayMessage($"id={e.TickerId} {GetField(e.Field)}={e.Size}", e.Timestamp)
    End Sub

    Private Sub _TickSnapshotEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.TickSnapshotEnd
        mMarketDataText.DisplayMessage($"TickSnapshot({e.RequestId}) =============== end ===============", e.Timestamp)
    End Sub

    Private Sub _TickString(sender As Object, e As TickStringEventArgs) Handles ApiEvents.TickString
        mMarketDataText.DisplayMessage($"id={e.TickerId} {GetField(e.TickType)}={e.Value}", e.Timestamp)
    End Sub

#End Region

#Region "Market Depth Events"

    Private Sub _MarketDepthError(sender As Object, e As RequestErrorEventArgs) Handles ApiEvents.MarketDepthError
        mErrorsText.DisplayMessage($" Id {e.RequestId}; Error Code: {e.ErrorCode}; Error Msg: {e.Message}")
    End Sub

    Private Sub _MktDepthExchanges(sender As Object, e As MarketDepthExchangesEventArgs) Handles ApiEvents.MarketDepthExchanges
        mServerResponsesText.DisplayMessage($" ==== Market Depth Exchanges Begin (total={e.Descriptions.Count}) ====", e.Timestamp)
        Dim count As Integer = 0
        For Each depthMktDataDescription As DepthMktDataDescription In e.Descriptions
            mServerResponsesText.DisplayMessage($"Depth Market Data Description ({count}) - exchange={depthMktDataDescription.Exchange} secType={depthMktDataDescription.SecType} serviceType={depthMktDataDescription.ServiceDataType}")
            count += 1
        Next
        mServerResponsesText.DisplayMessage(" ==== Market Depth Exchanges End (total={e.Descriptions.Count}) ====")
    End Sub

    Private Sub _RerouteDepthData(sender As Object, e As RerouteDataEventArgs) Handles ApiEvents.RerouteDepthData
        mServerResponsesText.DisplayMessage($"Re-route market depth request. Req Id: {e.RequestId}, Con Id: {e.ConId}, Exchange: {e.Exchange}", e.Timestamp)
    End Sub

    Private Sub _ResetMarketDepth(sender As Object, e As MarketDepthRestEventArgs) Handles ApiEvents.ResetMarketDepth
        If mMarketDepthForm IsNot Nothing Then mMarketDepthForm.Clear()
    End Sub

    Private Sub _UpdateMktDepth(sender As Object, e As MarketDepthUpdateEventArgs) Handles ApiEvents.MarketDepthUpdate
        If mMarketDepthForm IsNot Nothing Then mMarketDepthForm.UpdateMktDepth(e.RequestId, e.Position, e.MarketMaker, e.Operation, e.Side, e.Price, e.Size)
    End Sub

#End Region

#Region "News Events"

    Private Sub _HistoricalNews(sender As Object, e As HistoricalNewsEventArgs) Handles ApiEvents.HistoricalNews
        mServerResponsesText.DisplayMessage(
$"---- Historical News Begin ----
    requestId={e.RequestId}
    time={e.Time}
    providerCode={e.ProviderCode}
    articleId={e.ArticleId}
    headline={e.Headline}
---- Historical News End ----")
    End Sub

    Private Sub _HistoricalNewsEnd(sender As Object, e As HistoricalNewsEndEventArgs) Handles ApiEvents.HistoricalNewsEnd
        Dim hasMoreStr = If(e.HasMore, "> has more ...", "")
        mServerResponsesText.DisplayMessage($"requestId = {e.RequestId} ===== Historical News End ==== {hasMoreStr}")
    End Sub

    Private Sub _NewsArticle(sender As Object, e As NewsArticleEventArgs) Handles ApiEvents.NewsArticle
        mServerResponsesText.DisplayMessage($" ==== News Article Begin requestId={e.RequestId} ====")
        mServerResponsesText.DisplayMessage($" Article Type {e.Type}")
        mServerResponsesText.DisplayMessage(" Article Text ")
        If e.Type = 0 Then
            mServerResponsesText.DisplayMessage(e.Text)
        ElseIf e.Type = 1 Then
            Dim bytes() As Byte
            bytes = System.Convert.FromBase64String(e.Text)
            System.IO.File.WriteAllBytes(mNewsArticlePath, bytes)
            mServerResponsesText.DisplayMessage("Binary/pdf article was saved to " + mNewsArticlePath)
        End If
        mServerResponsesText.DisplayMessage(" ==== News Article End requestId={e.RequestId} ====")
    End Sub

    Private Sub _NewsBulletin(sender As Object, e As NewsBulletinEventArgs) Handles ApiEvents.NewsBulletin
        Dim f As New FServerResponse With {
            .Text = "IB News Bulletin"
        }
        mTheme.ApplyTheme(f.Controls)

        f.MsgLabel.Text = $" MsgId={e.MsgId}  MsgType = {e.MsgType} : Origin = {e.OrigExchange} : Message = {e.Message}"
        f.Show()
    End Sub

    Private Sub _NewsProviders(sender As Object, e As NewsProvidersEventArgs) Handles ApiEvents.NewsProviders
        mServerResponsesText.DisplayMessage($" ==== News Providers Begin (total={e.Providers.Count}) ====")
        Dim count As Integer = 0
        For Each newsProvider As NewsProvider In e.Providers
            mServerResponsesText.DisplayMessage($"News Provider ({count}) - code={newsProvider.ProviderCode} name={newsProvider.ProviderName}")
            count += 1
        Next
        mServerResponsesText.DisplayMessage($" ==== News Providers End (total={e.Providers.Count}) ====")
    End Sub

    Private Sub _TickNews(sender As Object, e As TickNewsEventArgs) Handles ApiEvents.TickNews
        mServerResponsesText.DisplayMessage(
$"---- Tick News Begin ----
    tickerId={e.TickerId}
    timeStamp={e.Timestamp.ToString("yyyy-MM-dd HH:mm:ss zzz")}
    providerCode={e.ProviderCode}
    articleId={e.ArticleId}
    headline={e.Headline}
    extraData={e.ExtraData}
---- Tick News End ----")
    End Sub

#End Region

#Region "Order Events"

    Private Sub _CommissionReport(sender As Object, e As CommissionReportEventArgs) Handles ApiEvents.CommissionReport
        mServerResponsesText.DisplayMessage(" ---- Commission Report ----", e.Timestamp)

        With e.CommissionReport
            mServerResponsesText.DisplayMessage($"
  execId={ .ExecId}
  commission={IBAPI.NullableToString(.Commission)}
  currency={ .CurrencyCode}
  realizedPNL={IBAPI.NullableToString(.RealizedPNL)}
  yield={IBAPI.NullableToString(.Yield)}
  yieldRedemptionDate={IBAPI.NullableToString(.YieldRedemptionDate)}")

        End With

        mServerResponsesText.DisplayMessage(" ---- Commission Report End ----")
    End Sub

    Private Sub _DeltaNeutralValidation(sender As Object, e As DeltaNeutralValidationEventArgs) Handles ApiEvents.DeltaNeutralValidation
        mServerResponsesText.DisplayMessage($"deltaNeutralValidation called, reqId={e.RequestId}", e.Timestamp)

        Dim underComp = e.DeltaNeutralContract

        If (underComp IsNot Nothing) Then
            With underComp
                mServerResponsesText.DisplayMessage($"
  underComp.conId={ .ConId}
  underComp.delta={ .Delta}
  underComp.delta={ .Price}")
            End With
        End If
    End Sub

    Private Sub _ExecDetails(sender As Object, e As ExecutionDetailsEventArgs) Handles ApiEvents.ExecutionDetails
        mServerResponsesText.DisplayMessage("
---- Execution Details begin ----", e.Timestamp)
        mServerResponsesText.DisplayMessage($"reqId = {e.ReqId}")

        mServerResponsesText.DisplayMessage("Contract")
        With e.Contract

            mServerResponsesText.DisplayMessage($"  conId={ .ConId}
  symbol={ .Symbol}
  secType={ .SecType}
  lastTradeDate={ .Expiry}
  strike={ .Strike}
  right={ .OptRight}
  multiplier={ .Multiplier}
  exchange={ .Exchange}
  primaryExchange={ .PrimaryExch}
  currency={ .CurrencyCode}
  localSymbol={ .LocalSymbol}
  tradingClass={ .TradingClass}")

        End With

        mServerResponsesText.DisplayMessage("Execution")
        With e.Execution

            mServerResponsesText.DisplayMessage($"  execId = { .ExecId}
  orderId = { .OrderId}
  clientId = { .ClientID}
  permId = { .PermId}
  time = { .Time}
  acctNumber = { .AcctNumber}
  modelCode = { .ModelCode}
  exchange = { .Exchange}
  side = { .Side}
  shares = { .Shares}
  price = { .Price}
  liquidation = { .Liquidation}
  cumQty = { .CumQty}
  avgPrice = { .AvgPrice}
  orderRef = { .OrderRef}
  evRule = { .EvRule}
  evMultiplier = { .EvMultiplier}
  lastLiquidity = { .LastLiquidity.ToString()}")

        End With

        mServerResponsesText.DisplayMessage("---- Execution Details End ----")
    End Sub

    Private Sub _ExecDetailsEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.ExecutionDetailsEnd
        mServerResponsesText.DisplayMessage($"ExecDetails({e.RequestId}) =============== end ===============")
    End Sub

    Private Sub _OpenOrder(sender As Object, e As OpenOrderEventArgs) Handles ApiEvents.OpenOrder
        Dim o = e.Order
        Dim c = e.Contract
        Dim s = e.OrderState

        mServerResponsesText.DisplayMessage($"==== Order Details Begin ====", e.Timestamp)
        mServerResponsesText.DisplayMessage($"Order
    orderId = {o.OrderId}
    clientId ={o.ClientID}
    permId = {o.PermId}
    Action ={IBAPI.OrderActions.ToExternalString(o.Action)}
    quantity = {o.TotalQuantity}
    OrderType ={IBAPI.OrderTypes.ToExternalString(o.OrderType)}
    lmtPrice = {IBAPI.NullableToString(o.LmtPrice)}
    auxPrice ={IBAPI.NullableToString(o.AuxPrice)}
    cashQty={IBAPI.NullableToString(o.CashQty)}

Contract
    conId={c.ConId}
    symbol={c.Symbol}
    secType={IBAPI.SecurityTypes.ToExternalString(c.SecType)}
    lastTradeDate={c.Expiry}
    strike={c.Strike}
    right={IBAPI.OptionRights.ToExternalString(c.OptRight)}
    multiplier={c.Multiplier}
    exchange={c.Exchange}
    primaryExchange={c.PrimaryExch}
    currency={c.CurrencyCode}
    localSymbol={c.LocalSymbol}
    tradingClass={c.TradingClass}
    comboLegsDescrip={c.ComboLegsDescription}

comboLegs={{
    {comboLegsToString(o, c)}
    }}

    deltaNeutralContract.conId=={ c.DeltaNeutralContract?.ConId}
    deltaNeutralContract.delta={ c.DeltaNeutralContract?.Delta}
    deltaNeutralContract.price={ c.DeltaNeutralContract?.Price}

Order (extended)
    timeInForce={IBAPI.OrderTIFs.ToExternalString(o.Tif)}
    ocaGroup={o.OcaGroup}
    ocaType={IBAPI.OcaTypes.ToExternalString(o.OcaType)}
    orderRef={o.OrderRef}
    parentId={o.ParentId}
    blockOrder={o.BlockOrder}
    sweepToFill={o.SweepToFill}
    displaySize={o.DisplaySize}
    triggerMethod={IBAPI.TriggerMethods.ToExternalString(o.TriggerMethod)}
    outsideRth={o.OutsideRth}
    hidden={o.Hidden}
    goodAfterTime={o.GoodAfterTime}
    goodTillDate={o.GoodTillDate}
    overridePercentageConstraints={o.OverridePercentageConstraints}
    rule80A={o.Rule80A}
    allOrNone={o.AllOrNone}
    minQty={IBAPI.NullableToString(o.MinQty)}
    percentOffset={IBAPI.NullableToString(o.PercentOffset)}
    trailStopPrice={IBAPI.NullableToString(o.TrailStopPrice)}
    trailingPercent={IBAPI.NullableToString(o.TrailingPercent)}
    lmtPriceOffset={IBAPI.NullableToString(o.LmtPriceOffset)}
    whatIf={o.WhatIf}
    notHeld={o.NotHeld}

Financial advisors
    faGroup={o.FaGroup}
    faProfile = {o.FaProfile}
    faMethod = {o.FaMethod}
    faPercentage = {o.FaPercentage}

Clearing info
    account = {o.Account}
    modelCode = {o.ModelCode}
    settlingFirm = {o.SettlingFirm}
    clearingAccount = {o.ClearingAccount}
    clearingIntent = {o.ClearingIntent}

Institutional orders
    openClose = {o.OpenClose}
    origin = {o.Origin}
    shortSaleSlot = {o.ShortSaleSlot}
    designatedLocation = {o.DesignatedLocation}
    exemptCode = {o.ExemptCode}

SMART routing
    discretionaryAmt = {o.DiscretionaryAmt}
    eTradeOnly = {o.ETradeOnly}
    firmQuoteOnly = {o.FirmQuoteOnly}
    nbboPriceCap = {IBAPI.NullableToString(o.NbboPriceCap)}
    optOutSmartRouting = {o.OptOutSmartRouting}

BOX or VOL orders
    AuctionStrategy = {o.AuctionStrategy}

BOX order 
    startingPrice = {IBAPI.NullableToString(o.StartingPrice)}
    stockRefPrice = {IBAPI.NullableToString(o.StockRefPrice)}
    delta = {IBAPI.NullableToString(o.Delta)}

Pegged to stock or VOL 
    stockRangeLower = {IBAPI.NullableToString(o.StockRangeLower)}
    stockRangeUpper = {IBAPI.NullableToString(o.StockRangeUpper)}

VOLATILITY orders
    volatility = {IBAPI.NullableToString(o.Volatility)}
    volatilityType = {o.VolatilityType}
    continuousUpdate = {o.ContinuousUpdate}
    referencePriceType = {o.ReferencePriceType}
    deltaNeutralOrderType = {o.DeltaNeutralOrderType}
    deltaNeutralAuxPrice = {IBAPI.NullableToString(o.DeltaNeutralAuxPrice)}
    deltaNeutralConId = {o.DeltaNeutralConId}
    deltaNeutralSettlingFirm = {o.DeltaNeutralSettlingFirm}
    deltaNeutralClearingAccount = {o.DeltaNeutralClearingAccount}
    deltaNeutralClearingIntent = {o.DeltaNeutralClearingIntent}
    deltaNeutralOpenClose = {o.DeltaNeutralOpenClose}
    deltaNeutralShortSale = {o.DeltaNeutralShortSale}
    deltaNeutralShortSaleSlot = {o.DeltaNeutralShortSaleSlot}
    deltaNeutralDesignatedlocation = {o.DeltaNeutralDesignatedLocation}

COMBO orders 
    basisPoints = {IBAPI.NullableToString(o.BasisPoints)}
    basisPointsType = {IBAPI.NullableToString(o.BasisPointsType)}

SCALE orders only
    scaleInitLevelSize = {IBAPI.NullableToString(o.ScaleInitLevelSize)}
    scaleSubsLevelSize = {IBAPI.NullableToString(o.ScaleSubsLevelSize)}
    scalePriceIncrement = {IBAPI.NullableToString(o.ScalePriceIncrement)}
    scalePriceAdjustValue = {IBAPI.NullableToString(o.ScalePriceAdjustValue)}
    scalePriceAdjustInterval = {IBAPI.NullableToString(o.ScalePriceAdjustInterval)}
    scaleProfitOffset = {IBAPI.NullableToString(o.ScaleProfitOffset)}
    scaleAutoReset = {o.ScaleAutoReset}
    scaleInitPosition = {IBAPI.NullableToString(o.ScaleInitPosition)}
    scaleInitFillQty = {IBAPI.NullableToString(o.ScaleInitFillQty)}
    scaleRandomPercent = {o.ScaleRandomPercent}

HEDGE orders only
    HedgeType = {o.HedgeType}
    hedgeParam = {o.HedgeParam}

Solicited orders only
    solicited = {o.Solicited}

    Randomize Size = {o.RandomizeSize}
    Randomize price = {o.RandomizePrice}

ALGO orders
    algoStrategy={o.AlgoStrategy}
    algoParams={{
            {o.AlgoParams?.ToString}
  }}

Smart combo routing params
    smartComboRoutingParams={{
        {o.SmartComboRoutingParams?.ToString}
    }}

OrderState
    status={s.Status}
    initMarginBefore={IBAPI.NullableToString(s.InitMarginBefore)}
    maintMarginBefore={IBAPI.NullableToString(s.MaintMarginBefore)}
    equityWithLoanBefore={IBAPI.NullableToString(s.EquityWithLoanBefore)}
    initMarginChange={IBAPI.NullableToString(s.InitMarginChange)}
    maintMarginChange={IBAPI.NullableToString(s.MaintMarginChange)}
    equityWithLoanChange={IBAPI.NullableToString(s.EquityWithLoanChange)}
    initMargin=After{IBAPI.NullableToString(s.InitMarginAfter)}
    maintMargin=After{IBAPI.NullableToString(s.MaintMarginAfter)}
    equityWithLoan=After{IBAPI.NullableToString(s.EquityWithLoanAfter)}
    commission={IBAPI.NullableToString(s.Commission)}
    minCommission={IBAPI.NullableToString(s.MinCommission)}
    maxCommission={IBAPI.NullableToString(s.MaxCommission)}
    commissionCurrency={s.CommissionCurrency}
    warningText={s.WarningText}

==== Order Details End ====")

    End Sub

    Private Sub _OpenOrderEnd(sender As Object, e As EventArgs) Handles ApiEvents.OpenOrderEnd
        mServerResponsesText.DisplayMessage($"Request(All)OpenOrders ============= end =============")
    End Sub

    Private Sub _OrderError(sender As Object, e As RequestErrorEventArgs) Handles ApiEvents.OrderError
        mErrorsText.DisplayMessage($" Id {e.RequestId}; Error Code: {e.ErrorCode}; Error Msg: {e.Message}")
    End Sub

    Private Sub _OrderStatus(sender As Object, e As OrderStatusEventArgs) Handles ApiEvents.OrderStatus
        mServerResponsesText.DisplayMessage(
$"Order status 
    orderId = {e.OrderId} 
    client id={e.ClientId} 
    permId={e.PermId}
    status={e.Status} 
    filled={e.Filled} 
    remaining={e.Remaining}
    avgFillPrice={e.AvgFillPrice} 
    lastFillPrice={e.LastFillPrice}
    parentId={e.ParentId} 
    whyHeld={e.WhyHeld} 
    mktCapPrice={e.MarketCapPrice}
    ", e.Timestamp)
    End Sub



#End Region

#Region "Performance Data Events"

    Private Sub _PerformanceStatsUpdate(sender As Object, e As PerformanceStatsUpdateEventArgs) Handles ApiEvents.PerformanceStatsUpdate
        If DisplayApiMessageStatisticsCheck.Checked Then
            mServerResponsesText.DisplayMessage($"Socket message statistics:{vbCrLf}{e.Statistics}", Date.Now)
        End If
    End Sub

#End Region

#Region "Scanner Data Events"


    Private Sub _ScannerData(sender As Object, e As ScannerDataEventArgs) Handles ApiEvents.ScannerData
        Dim contractDetails = e.ContractDetails
        Dim contract = contractDetails.Summary

        mMarketDataText.DisplayMessage(
$"id={e.RequestId} rank={e.Rank} conId={contract.ConId} 
 symbol={contract.Symbol} secType={contract.SecType} currency={contract.CurrencyCode}
 localSymbol={contract.LocalSymbol} marketName={contractDetails.MarketName}
 tradingClass={contract.TradingClass} distance={e.Distance}
 benchmark={e.Benchmark} projection={e.Projection}
 legsStr={e.LegsStr}", e.Timestamp)
    End Sub

    Private Sub _ScannerDataEnd(sender As Object, e As RequestEndEventArgs) Handles ApiEvents.ScannerDataEnd
        mMarketDataText.DisplayMessage($"ScannerDataEnd ({e.RequestId}) =============== end ===============")
    End Sub

    Private Sub _ScannerParameters(sender As Object, e As ScannerParametersEventArgs) Handles ApiEvents.ScannerParameters
        Dim xmlDoc = New XmlDocument
        xmlDoc.LoadXml(e.XmlData)
        Dim node1 = getRootNode(xmlDoc)
        mServerResponsesText.DisplayMessage($"SCANNER PARAMETERS {node1.Name} document.", e.Timestamp)
        node1 = node1.SelectSingleNode("InstrumentList")
        Dim name1 = parseNode(node1.FirstChild, "name")
        Dim theType1 = parseNode(node1.FirstChild, "type")
        Dim name2 = parseNode(node1.FirstChild.NextSibling, "name")
        Dim theType2 = parseNode(node1.FirstChild.NextSibling, "type")
        mServerResponsesText.DisplayMessage($"InstrumentList starts with ({name1},{theType1}) followed by ({name2},{theType2})")
        mServerResponsesText.DisplayMessage(e.XmlData)
    End Sub

#End Region

#Region "Socket Data Events"

    Private Sub _SocketInputData(sender As Object, e As SocketDataEventArgs) Handles ApiEvents.SocketInputData
        If Not DisplaySocketDataCheck.Checked Then Return
        mSocketDataText.DisplayMessage($"{e.Data}", Now)
    End Sub

    Private Sub _SocketInputMessage(sender As Object, e As ApiMessageEventArgs) Handles ApiEvents.SocketInputMessage
        If Not DisplaySocketMessagesCheck.Checked Then Return
        mSocketDataText.DisplayMessage($"{e.Message}", Now)
    End Sub

    Private Sub _SocketOutputData(sender As Object, e As SocketDataEventArgs) Handles ApiEvents.SocketOutputData
        If Not DisplaySocketDataCheck.Checked Then Return
        mSocketDataText.DisplayMessage($"{e.Data}", Now)
    End Sub

    Private Sub _SocketOutputMessage(sender As Object, e As ApiMessageEventArgs) Handles ApiEvents.SocketOutputMessage
        If Not DisplaySocketMessagesCheck.Checked Then Return
        mSocketDataText.DisplayMessage($"{e.Message}", Now)
    End Sub

#End Region

#End Region

#Region "Helper methods"

    Private Function addNodeToXMLDoc(xmlDoc As XmlDocument,
                                    node As XmlElement,
                                    nodeName As String,
                                    nodeValue As String) As XmlNode
        Dim newNode = xmlDoc.CreateElement(nodeName)
        If String.IsNullOrEmpty(nodeValue) Then
            newNode.InnerText = nodeValue
        End If
        node.AppendChild(newNode)
        Return newNode
    End Function

    Private Sub appendNewLineAndTab(xmlDoc As XmlDocument, node As XmlNode)
        node.AppendChild(xmlDoc.CreateTextNode(vbNewLine + vbTab))
    End Sub

    Private Shared Function comboLegsToString(o As Order, c As Contract) As String
        If c.ComboLegs Is Nothing Then Return ""

        Dim s = ""
        Dim i = 0
        For Each comboLeg In c.ComboLegs
            Dim priceStr = ""

            If c.ComboLegs.Count = If(o.OrderComboLegs?.Length, 0) Then
                priceStr = $" price={IBAPI.NullableToString(o.OrderComboLegs(i).Price)}"
            End If

            s &= $"
    leg {(i + 1)}
        conId={comboLeg.ConId} ratio={comboLeg.Ratio} action={comboLeg.Action}
        exchange={comboLeg.Exchange} openClose={comboLeg.OpenClose}
        shortSaleSlot={comboLeg.ShortSaleSlot} designatedLocation={comboLeg.DesignatedLocation}
        exemptCode={comboLeg.ExemptCode}{priceStr}"
            i += 1
        Next
        Return s
    End Function

    Private Sub connectToTws()
        ' assume this is a non Financial Advisor account. If it is the managedAccounts()
        ' event will be fired.
        mFaAccount = False

        mServerResponsesText.DisplayMessage($"Connecting to Tws using clientId {ClientIdText.Text} ...")
        setConnectionState(ApiConnectionState.Connecting)
        ' this ensures the state changes are visible: otherwise the synchronous connection mechanism
        ' blocks them until it's finished
        TopPanel.Refresh()

        mApi = New IBAPI(ServerText.Text,
                             CInt(PortText.Text),
                             CInt(ClientIdText.Text),
                             generateSocketDataEvents:=DisplaySocketDataCheck.Checked)

        ApiEvents = New EventSource()

        mUseQueueing = UseQueueingCheck.Checked
        If mUseQueueing Then
            mCallbackHandler = New QueueingCallbackHandler(ApiEvents, WindowsFormsSynchronizationContext.Current)
            mApi.CallbackHandler = mCallbackHandler
        Else
            mApi.CallbackHandler = ApiEvents
        End If

        mApi.Connect()
    End Sub

    Private Sub disableButtons()
        For Each control As Control In ButtonsPanel.Controls
            control.Enabled = False
        Next
    End Sub

    Private Sub disconnectFromTWS()
        setConnectionState(ApiConnectionState.NotConnected)
        mApi.Disconnect("Closed by user")
        mApi.Dispose()
        mApi = Nothing
        PauseAPIButton.Enabled = False
    End Sub

    Private Sub enableButtons()
        For Each control As Control In ButtonsPanel.Controls
            control.Enabled = True
        Next
    End Sub

    Private Function findNode(xmlDoc As XmlDocument, nodeName As String, withName As String, withValue As String) As XmlNode
        Dim node1 = getRootNode(xmlDoc)
        Dim nodeList = getNodeList(node1, nodeName)
        Dim node2 = getNodeFromList(nodeList, withName, withValue)
        Return node2
    End Function

    Private Function getNode(node As XmlNode,
                               nodeName As String) As XmlNode
        Return node.SelectSingleNode(nodeName)
    End Function

    Private Function getNodeFromList(nodeList As XmlNodeList, name As String, value As String) As XmlNode
        For ctr As Integer = 0 To nodeList.Count - 1
            Dim node = nodeList.Item(ctr)
            Dim element = node.Item(name)
            If element.InnerText = value Then
                Return node
            End If
        Next
        Return Nothing
    End Function

    Private Function getNodeList(node As XmlNode,
                               nodeName As String) As XmlNodeList
        Return node.SelectNodes(nodeName)
    End Function

    Private Function getRootNode(xmlDoc As XmlDocument) As XmlNode
        Return xmlDoc.SelectSingleNode("/*")
    End Function

    Private Function parseNode(node As XmlNode,
                               nodeName As String) As String
        Return node.SelectSingleNode(nodeName).InnerText
    End Function

    Private Sub setConnectionState(state As ApiConnectionState)
        mConnectionState = state
        Select Case mConnectionState
            Case ApiConnectionState.NotConnected
                TopPanel.BackColor = Color.MistyRose
                TopPanelCheckboxesSite.BackColor = Color.MistyRose
                ApiDetailsPanel.BackColor = Color.MistyRose
                ConnectionStatusLabel.Text = "Not connected"
                ConnectionStatusLabel.ForeColor = Color.Red
                ConnectDisconnectButton.Enabled = True
                ConnectDisconnectButton.Text = "Connect"
                disableButtons()
            Case ApiConnectionState.Connecting
                TopPanel.BackColor = Color.FromArgb(251, 227, 80)
                TopPanelCheckboxesSite.BackColor = Color.FromArgb(251, 227, 80)
                ApiDetailsPanel.BackColor = Color.FromArgb(251, 227, 80)
                ConnectionStatusLabel.Text = "Connecting..."
                ConnectionStatusLabel.ForeColor = Color.FromArgb(255, 178, 82)
                ConnectDisconnectButton.Enabled = False
            Case ApiConnectionState.Connected
                TopPanel.BackColor = Color.FromArgb(179, 230, 179)
                TopPanelCheckboxesSite.BackColor = Color.FromArgb(179, 230, 179)
                ApiDetailsPanel.BackColor = Color.FromArgb(179, 230, 179)
                ConnectionStatusLabel.Text = "Connected"
                ConnectionStatusLabel.ForeColor = Color.FromArgb(19, 146, 18)
                ConnectDisconnectButton.Enabled = True
                ConnectDisconnectButton.Text = "Disconnect"
                enableButtons()
        End Select
    End Sub

    Private Sub setElemAttr(xmlDoc As XmlDocument,
                           elem As XmlElement,
                           attrName As String,
                           attrValue As String)
        Dim attr = xmlDoc.CreateAttribute(attrName)
        attr.Value = attrValue
        elem.SetAttributeNode(attr)
    End Sub

#End Region

End Class
