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


Imports System.IO
Imports System.Threading
Imports System.Timers

Public Enum ConnectionState
    NotConnected
    Connecting
    Connected
    Failed
End Enum

Public Class UI
    Inherits System.Windows.Forms.Form

#Region "Description"

    ' A simple program that uses the TWS API to control a set of tickers,
    ' and keep track of the number of ticks received via the API, and the
    ' CPU utilisation.
    '
    ' The symbols to use are specified in the symbols.txt file which must be in the
    ' same folder that the program is running in. The symbols.txt file supplied
    ' in the download contains all the NASDAQ 100 stocks, but you can easily
    ' edit it to include whatever you like.

#End Region

#Region "Fields"

    ' Set to True while counting ticks received from the API
    Private mCounting As Boolean

    ' total number of tick events via API
    Private mTotalTicks As Integer

    ' number of tick events in the current second
    Private mTicksThisSecond As Integer

    ' maximum number of tick events received in a second
    Private mMaxEventsPerSecond As Integer

    ' maximum % CPU utilisation in a second
    Private mMaxCpuPercentPerSecond As Double

    ' number of seconds since the start button was pressed
    Private mSecondsSinceStart As Integer

    ' handle to this process allowing us to get info about the process from Windows
    Private mCurrentProcess As Process

    ' total processor time at start of tick counting
    Private mInitialCPUTime As Long

    ' the amount of time the process had spent in kernel mode at the end of
    ' the previous second
    Private mPrevCPUTime As Long

    Private mPerformanceTimer As Timers.Timer

    Private mController As IApiLoadTestController

    Private mSyncContext As SynchronizationContext

#End Region

#Region "Form Event Handlers"

    Protected Overrides Sub OnLoad(e As EventArgs)
        mSyncContext = SynchronizationContext.Current
        mCurrentProcess = Process.GetCurrentProcess()
        MyBase.OnLoad(e)
    End Sub

    Protected Overrides Sub OnClosed(e As EventArgs)
        LogMessage("Disconnecting from TWS")
        mController.Disconnect()
        MyBase.OnClosed(e)
    End Sub

#End Region

#Region "Other Event Handlers"

    Private Sub connectButton_Click(sender As Object, eventArgs As EventArgs) Handles ConnectButton.Click
        LogMessage($"Connect(): Thread id: {System.Threading.Thread.CurrentThread.ManagedThreadId}")
        If ConnectButton.Text = "Connect" Then
            mController.Connect(ServerText.Text, CInt(PortText.Text), CInt(ClientIdText.Text))

            ConnectButton.Enabled = False
            ConnectButton.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Else
            LogMessage("Disconnecting from TWS")
            mController.Disconnect()

            ConnectButton.Text = "Connect"
        End If
    End Sub

    Private Sub startTickersButton_Click(sender As Object, eventArgs As EventArgs) Handles StartTickersButton.Click
        clearPerformanceFields()

        startTickers()

        StartTickersButton.Enabled = False
        StopTickersButton.Enabled = True

        StartTickCountingButton.Enabled = True
        StartTickCountingButton.Focus()
    End Sub

    Private Sub startTickCountingButton_Click(sender As Object, eventArgs As EventArgs) Handles StartTickCountingButton.Click

        clearPerformanceFields()

        StartTickCountingButton.Enabled = False
        StopTickCountingButton.Enabled = True
        StopTickCountingButton.Focus()

        mCounting = True
    End Sub

    Private Sub stopTickersButton_Click(sender As Object, eventArgs As EventArgs) Handles StopTickersButton.Click
        If mPerformanceTimer IsNot Nothing Then mPerformanceTimer.Stop()

        mController.StopTickers()

        StartTickersButton.Enabled = True
        StartTickersButton.Focus()
        StopTickersButton.Enabled = False

        StartTickCountingButton.Enabled = False
        StopTickCountingButton.Enabled = False

        mCounting = False
        StopTickCountingButton.Enabled = False
    End Sub

    Private Sub stopTickCountingButton_Click(sender As Object, eventArgs As EventArgs) Handles StopTickCountingButton.Click
        StartTickCountingButton.Enabled = True
        StartTickCountingButton.Focus()
        StopTickCountingButton.Enabled = False
        mCounting = False
        If mPerformanceTimer IsNot Nothing Then mPerformanceTimer.Stop()
        LogMessage("Tick counting stopped")
    End Sub

    Private Sub performanceTimer_Elapsed(sender As Object, e As ElapsedEventArgs)
        mSecondsSinceStart += 1
        SecondsElapsedText.Text = CStr(mSecondsSinceStart)
        TotalEventsText.Text = CStr(mTotalTicks)
        AvgEventsPerSecondText.Text = CStr(Math.Round(mTotalTicks / mSecondsSinceStart, 0))
        EventsLastSecondText.Text = CStr(mTicksThisSecond)

        If mTicksThisSecond > mMaxEventsPerSecond Then
            mMaxEventsPerSecond = mTicksThisSecond
            MaxEventsPerSecText.Text = CStr(mMaxEventsPerSecond)
        End If

        Dim cpuTime = getCpuTime()
        If cpuTime <> mPrevCPUTime Then
            TotalProcessTimeText.Text = String.Format("{0:F4}", (cpuTime - mInitialCPUTime) / TimeSpan.TicksPerMillisecond)
            AvgCpuUtilisationPercentText.Text = String.Format("{0:F4}", 100 * (cpuTime - mInitialCPUTime) / TimeSpan.TicksPerSecond / mSecondsSinceStart)
            MicrosecsPerTickText.Text = String.Format("{0:F4}", 1000 * (cpuTime - mInitialCPUTime) / TimeSpan.TicksPerMillisecond / mTotalTicks)

            Dim cpuPercentThisSecond = 100 * (cpuTime - mPrevCPUTime) / TimeSpan.TicksPerSecond
            If cpuPercentThisSecond > mMaxCpuPercentPerSecond Then
                mMaxCpuPercentPerSecond = cpuPercentThisSecond
                MaxCpuPercentPerSecText.Text = String.Format("{0:F4}", mMaxCpuPercentPerSecond)
            End If

            mPrevCPUTime = cpuTime
        End If

        mTicksThisSecond = 0
    End Sub

#End Region


#Region "Properties"

    Public Property ClientId As Integer
        Get
            Return CInt(ClientIdText.Text)
        End Get
        Set(value As Integer)
            ClientIdText.Text = CStr(value)
        End Set
    End Property

    Public WriteOnly Property TitleQualifer As String
        Set
            Me.Text = $"{Me.Text} ({Value})"
        End Set
    End Property

    Public ReadOnly Property UseQueueingCallbackHandler As Boolean
        Get
            Return UseQueueingCheck.Checked
        End Get
    End Property

    Public ReadOnly Property UseV100Protocol As Boolean
        Get
            Return UseV100Check.Checked
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub HandleException(e As Exception)
        MsgBox($"An unhandled exception has occurred. The program will close.{vbCrLf}{vbCrLf}{e.ToString()}",
                MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical,
                "Fatal error")
    End Sub

    Public Sub Initialise(controller As IApiLoadTestController)
        mController = controller
        If mController.EnableUseQueueingCallbackHandlerCheckbox Then UseQueueingCheck.Enabled = True
        If mController.EnableUseV100ProtocolCheckbox Then UseV100Check.Enabled = True
    End Sub

    Public Sub IncrementTotalTicks()
        If mTotalTicks = 0 And mCounting Then
            LogMessage($"IncrementTotalTicks(): Thread id: {System.Threading.Thread.CurrentThread.ManagedThreadId}")
            mPerformanceTimer = startPerformanceTimer()
            mInitialCPUTime = getCpuTime()
            mPrevCPUTime = mInitialCPUTime

            LogMessage("Tick counting started")
        End If
        If mCounting Then
            mTotalTicks += 1
            mTicksThisSecond += 1
        End If
    End Sub

    Public Sub LogMessage(message As String)
        mSyncContext.Post(Sub() If Not LogText.IsDisposed Then LogText.AppendText(message & vbCrLf), Nothing)
    End Sub

    Public Sub NotifyConnectionStateChange(state As ConnectionState)
        Select Case state
            Case ConnectionState.NotConnected
                LogMessage("Disconnected from TWS")
            Case ConnectionState.Connecting
                LogMessage("Connecting to TWS")
            Case ConnectionState.Connected
                LogMessage("Connected to TWS")
                ConnectButton.Enabled = True
                ConnectButton.Cursor = System.Windows.Forms.Cursors.Default
                ConnectButton.Text = "Disconnect"

                StartTickersButton.Enabled = True
                StartTickersButton.Focus()
            Case ConnectionState.Failed
                LogMessage("Failed to connect to TWS")
        End Select
    End Sub

#End Region

#Region "Helper Functions"

    Private Sub clearPerformanceFields()
        mTotalTicks = 0
        mTicksThisSecond = 0
        mSecondsSinceStart = 0
        mMaxEventsPerSecond = 0
        mMaxCpuPercentPerSecond = 0

        TotalEventsText.Text = ""
        EventsLastSecondText.Text = ""
        AvgEventsPerSecondText.Text = ""
        SecondsElapsedText.Text = ""
        TotalProcessTimeText.Text = ""
        AvgCpuUtilisationPercentText.Text = ""
        MaxEventsPerSecText.Text = ""
        MaxCpuPercentPerSecText.Text = ""
        MicrosecsPerTickText.Text = ""
    End Sub

    Private Function getCpuTime() As Long
        Return mCurrentProcess.TotalProcessorTime.Ticks
    End Function

    Private Function startPerformanceTimer() As Timers.Timer
        Dim performanceTimer = New Timers.Timer(1000) With {
            .SynchronizingObject = Me
        }
        AddHandler performanceTimer.Elapsed, AddressOf performanceTimer_Elapsed
        performanceTimer.Start()
        Return performanceTimer
    End Function

    Private Sub startTickers()
        Try
            Dim inFile = File.OpenText(My.Application.Info.DirectoryPath & "\symbols.txt")

            Dim lineNum As Integer
            Do While Not inFile.EndOfStream
                Dim inBuff = inFile.ReadLine
                lineNum = lineNum + 1

                'ignore comment lines
                Do While String.IsNullOrEmpty(inBuff) OrElse inBuff.Substring(0, 2) = "//"
                    If inFile.EndOfStream Then Exit Sub
                    inBuff = inFile.ReadLine
                    lineNum = lineNum + 1
                Loop

                inBuff = Replace(inBuff, " ", "")
                inBuff = Replace(inBuff, vbTab, "")

                Dim tokens = Split(inBuff, ",")
                If tokens.Length < 2 Then
                    LogMessage($"Missing column(s) in line {lineNum} of symbols.txt")
                    Continue Do
                End If

                Dim symbol = tokens(0)
                Dim sectype = tokens(1)
                Dim expiry = If(tokens.Length >= 3, tokens(2), "")
                Dim exchange = If(tokens.Length >= 4, tokens(3), "")
                Dim currency = If(tokens.Length >= 5, tokens(4), "")
                Dim primaryExchange = If(tokens.Length >= 6, tokens(5), "")
                Dim multiplier = If(tokens.Length >= 7, tokens(6), "")
                Dim marketDepth = If(tokens.Length >= 8, CBool(tokens(7)), False)
                Dim tickerId = mController.StartTicker(symbol, sectype, expiry, exchange, currency, primaryExchange, If(multiplier = "", 1, CInt(multiplier)), marketDepth)
                LogMessage($"Starting {symbol} : id={tickerId}")
            Loop

            Exit Sub

        Catch e As Exception
            LogMessage($"Problem with symbols.txt: {e.Message}")
        End Try
    End Sub

#End Region


End Class