' Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On

Imports System.Collections.Generic
Imports TradeWright.IBAPI

Friend Class FHistoricalNews
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        initializeComponent()
    End Sub
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
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents HistoricalNewsConIdText As System.Windows.Forms.TextBox
    Public WithEvents HistoricalNewsProviderCodesText As System.Windows.Forms.TextBox
    Public WithEvents HistoricalNewsRequstIdText As System.Windows.Forms.TextBox
    Public WithEvents HistoricalNewsProviderCodesLabel As System.Windows.Forms.Label
    Public WithEvents HistoricalNewsConIdLabel As System.Windows.Forms.Label
    Public WithEvents HistoricalNewsStartDateTimeLabel As System.Windows.Forms.Label
    Public WithEvents HistoricalNewsEndDateTimeLabel As System.Windows.Forms.Label
    Public WithEvents HistoricalNewsTotalResultsLabel As System.Windows.Forms.Label
    Public WithEvents HistoricalNewsStartDateTimeText As System.Windows.Forms.TextBox
    Public WithEvents HistoricalNewsEndDateTimeText As System.Windows.Forms.TextBox
    Public WithEvents HistoricalNewsTotalResultsText As System.Windows.Forms.TextBox
    Public WithEvents MiscOptionsButton As System.Windows.Forms.Button
    Public WithEvents HistoricalNewsRequestIdLabel As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.HistoricalNewsConIdText = New System.Windows.Forms.TextBox()
        Me.HistoricalNewsProviderCodesText = New System.Windows.Forms.TextBox()
        Me.HistoricalNewsRequstIdText = New System.Windows.Forms.TextBox()
        Me.HistoricalNewsProviderCodesLabel = New System.Windows.Forms.Label()
        Me.HistoricalNewsConIdLabel = New System.Windows.Forms.Label()
        Me.HistoricalNewsRequestIdLabel = New System.Windows.Forms.Label()
        Me.HistoricalNewsStartDateTimeLabel = New System.Windows.Forms.Label()
        Me.HistoricalNewsEndDateTimeLabel = New System.Windows.Forms.Label()
        Me.HistoricalNewsTotalResultsLabel = New System.Windows.Forms.Label()
        Me.HistoricalNewsStartDateTimeText = New System.Windows.Forms.TextBox()
        Me.HistoricalNewsEndDateTimeText = New System.Windows.Forms.TextBox()
        Me.HistoricalNewsTotalResultsText = New System.Windows.Forms.TextBox()
        Me.MiscOptionsButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OkButton.BackColor = System.Drawing.SystemColors.Control
        Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OkButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OkButton.Location = New System.Drawing.Point(60, 203)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 12
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelItButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(148, 203)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(73, 25)
        Me.CancelItButton.TabIndex = 13
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'HistoricalNewsConIdText
        '
        Me.HistoricalNewsConIdText.AcceptsReturn = True
        Me.HistoricalNewsConIdText.BackColor = System.Drawing.SystemColors.Window
        Me.HistoricalNewsConIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HistoricalNewsConIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HistoricalNewsConIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsConIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HistoricalNewsConIdText.Location = New System.Drawing.Point(117, 42)
        Me.HistoricalNewsConIdText.MaxLength = 0
        Me.HistoricalNewsConIdText.Name = "HistoricalNewsConIdText"
        Me.HistoricalNewsConIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsConIdText.Size = New System.Drawing.Size(151, 13)
        Me.HistoricalNewsConIdText.TabIndex = 3
        Me.HistoricalNewsConIdText.Text = "8314"
        '
        'HistoricalNewsProviderCodesText
        '
        Me.HistoricalNewsProviderCodesText.AcceptsReturn = True
        Me.HistoricalNewsProviderCodesText.BackColor = System.Drawing.SystemColors.Window
        Me.HistoricalNewsProviderCodesText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HistoricalNewsProviderCodesText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HistoricalNewsProviderCodesText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsProviderCodesText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HistoricalNewsProviderCodesText.Location = New System.Drawing.Point(117, 68)
        Me.HistoricalNewsProviderCodesText.MaxLength = 0
        Me.HistoricalNewsProviderCodesText.Name = "HistoricalNewsProviderCodesText"
        Me.HistoricalNewsProviderCodesText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsProviderCodesText.Size = New System.Drawing.Size(151, 13)
        Me.HistoricalNewsProviderCodesText.TabIndex = 5
        Me.HistoricalNewsProviderCodesText.Text = "BZ+FLY"
        '
        'HistoricalNewsRequstIdText
        '
        Me.HistoricalNewsRequstIdText.AcceptsReturn = True
        Me.HistoricalNewsRequstIdText.BackColor = System.Drawing.SystemColors.Window
        Me.HistoricalNewsRequstIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HistoricalNewsRequstIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HistoricalNewsRequstIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsRequstIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HistoricalNewsRequstIdText.Location = New System.Drawing.Point(117, 16)
        Me.HistoricalNewsRequstIdText.MaxLength = 0
        Me.HistoricalNewsRequstIdText.Name = "HistoricalNewsRequstIdText"
        Me.HistoricalNewsRequstIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsRequstIdText.Size = New System.Drawing.Size(151, 13)
        Me.HistoricalNewsRequstIdText.TabIndex = 1
        Me.HistoricalNewsRequstIdText.Text = "0"
        '
        'HistoricalNewsProviderCodesLabel
        '
        Me.HistoricalNewsProviderCodesLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.HistoricalNewsProviderCodesLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.HistoricalNewsProviderCodesLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsProviderCodesLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HistoricalNewsProviderCodesLabel.Location = New System.Drawing.Point(16, 70)
        Me.HistoricalNewsProviderCodesLabel.Name = "HistoricalNewsProviderCodesLabel"
        Me.HistoricalNewsProviderCodesLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsProviderCodesLabel.Size = New System.Drawing.Size(95, 17)
        Me.HistoricalNewsProviderCodesLabel.TabIndex = 4
        Me.HistoricalNewsProviderCodesLabel.Text = "Provider Codes"
        '
        'HistoricalNewsConIdLabel
        '
        Me.HistoricalNewsConIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.HistoricalNewsConIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.HistoricalNewsConIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsConIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HistoricalNewsConIdLabel.Location = New System.Drawing.Point(16, 43)
        Me.HistoricalNewsConIdLabel.Name = "HistoricalNewsConIdLabel"
        Me.HistoricalNewsConIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsConIdLabel.Size = New System.Drawing.Size(95, 17)
        Me.HistoricalNewsConIdLabel.TabIndex = 2
        Me.HistoricalNewsConIdLabel.Text = "Contract Id"
        '
        'HistoricalNewsRequestIdLabel
        '
        Me.HistoricalNewsRequestIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.HistoricalNewsRequestIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.HistoricalNewsRequestIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsRequestIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HistoricalNewsRequestIdLabel.Location = New System.Drawing.Point(16, 16)
        Me.HistoricalNewsRequestIdLabel.Name = "HistoricalNewsRequestIdLabel"
        Me.HistoricalNewsRequestIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsRequestIdLabel.Size = New System.Drawing.Size(95, 17)
        Me.HistoricalNewsRequestIdLabel.TabIndex = 0
        Me.HistoricalNewsRequestIdLabel.Text = "Request Id"
        '
        'HistoricalNewsStartDateTimeLabel
        '
        Me.HistoricalNewsStartDateTimeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.HistoricalNewsStartDateTimeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.HistoricalNewsStartDateTimeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsStartDateTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HistoricalNewsStartDateTimeLabel.Location = New System.Drawing.Point(16, 97)
        Me.HistoricalNewsStartDateTimeLabel.Name = "HistoricalNewsStartDateTimeLabel"
        Me.HistoricalNewsStartDateTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsStartDateTimeLabel.Size = New System.Drawing.Size(95, 17)
        Me.HistoricalNewsStartDateTimeLabel.TabIndex = 6
        Me.HistoricalNewsStartDateTimeLabel.Text = "Start Date/Time"
        '
        'HistoricalNewsEndDateTimeLabel
        '
        Me.HistoricalNewsEndDateTimeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.HistoricalNewsEndDateTimeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.HistoricalNewsEndDateTimeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsEndDateTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HistoricalNewsEndDateTimeLabel.Location = New System.Drawing.Point(16, 124)
        Me.HistoricalNewsEndDateTimeLabel.Name = "HistoricalNewsEndDateTimeLabel"
        Me.HistoricalNewsEndDateTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsEndDateTimeLabel.Size = New System.Drawing.Size(95, 17)
        Me.HistoricalNewsEndDateTimeLabel.TabIndex = 8
        Me.HistoricalNewsEndDateTimeLabel.Text = "End Date/Time"
        '
        'HistoricalNewsTotalResultsLabel
        '
        Me.HistoricalNewsTotalResultsLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.HistoricalNewsTotalResultsLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.HistoricalNewsTotalResultsLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsTotalResultsLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HistoricalNewsTotalResultsLabel.Location = New System.Drawing.Point(16, 151)
        Me.HistoricalNewsTotalResultsLabel.Name = "HistoricalNewsTotalResultsLabel"
        Me.HistoricalNewsTotalResultsLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsTotalResultsLabel.Size = New System.Drawing.Size(95, 17)
        Me.HistoricalNewsTotalResultsLabel.TabIndex = 10
        Me.HistoricalNewsTotalResultsLabel.Text = "Total Results"
        '
        'HistoricalNewsStartDateTimeText
        '
        Me.HistoricalNewsStartDateTimeText.AcceptsReturn = True
        Me.HistoricalNewsStartDateTimeText.BackColor = System.Drawing.SystemColors.Window
        Me.HistoricalNewsStartDateTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HistoricalNewsStartDateTimeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HistoricalNewsStartDateTimeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsStartDateTimeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HistoricalNewsStartDateTimeText.Location = New System.Drawing.Point(117, 97)
        Me.HistoricalNewsStartDateTimeText.MaxLength = 0
        Me.HistoricalNewsStartDateTimeText.Name = "HistoricalNewsStartDateTimeText"
        Me.HistoricalNewsStartDateTimeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsStartDateTimeText.Size = New System.Drawing.Size(151, 13)
        Me.HistoricalNewsStartDateTimeText.TabIndex = 7
        '
        'HistoricalNewsEndDateTimeText
        '
        Me.HistoricalNewsEndDateTimeText.AcceptsReturn = True
        Me.HistoricalNewsEndDateTimeText.BackColor = System.Drawing.SystemColors.Window
        Me.HistoricalNewsEndDateTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HistoricalNewsEndDateTimeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HistoricalNewsEndDateTimeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsEndDateTimeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HistoricalNewsEndDateTimeText.Location = New System.Drawing.Point(117, 124)
        Me.HistoricalNewsEndDateTimeText.MaxLength = 0
        Me.HistoricalNewsEndDateTimeText.Name = "HistoricalNewsEndDateTimeText"
        Me.HistoricalNewsEndDateTimeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsEndDateTimeText.Size = New System.Drawing.Size(151, 13)
        Me.HistoricalNewsEndDateTimeText.TabIndex = 9
        '
        'HistoricalNewsTotalResultsText
        '
        Me.HistoricalNewsTotalResultsText.AcceptsReturn = True
        Me.HistoricalNewsTotalResultsText.BackColor = System.Drawing.SystemColors.Window
        Me.HistoricalNewsTotalResultsText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HistoricalNewsTotalResultsText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HistoricalNewsTotalResultsText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoricalNewsTotalResultsText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HistoricalNewsTotalResultsText.Location = New System.Drawing.Point(117, 151)
        Me.HistoricalNewsTotalResultsText.MaxLength = 0
        Me.HistoricalNewsTotalResultsText.Name = "HistoricalNewsTotalResultsText"
        Me.HistoricalNewsTotalResultsText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HistoricalNewsTotalResultsText.Size = New System.Drawing.Size(151, 13)
        Me.HistoricalNewsTotalResultsText.TabIndex = 11
        Me.HistoricalNewsTotalResultsText.Text = "10"
        '
        'MiscOptionsButton
        '
        Me.MiscOptionsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MiscOptionsButton.BackColor = System.Drawing.SystemColors.Control
        Me.MiscOptionsButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.MiscOptionsButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MiscOptionsButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MiscOptionsButton.Location = New System.Drawing.Point(19, 172)
        Me.MiscOptionsButton.Name = "MiscOptionsButton"
        Me.MiscOptionsButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MiscOptionsButton.Size = New System.Drawing.Size(249, 25)
        Me.MiscOptionsButton.TabIndex = 14
        Me.MiscOptionsButton.Text = "Misc Options"
        Me.MiscOptionsButton.UseVisualStyleBackColor = True
        '
        'fHistoricalNews
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(280, 236)
        Me.Controls.Add(Me.MiscOptionsButton)
        Me.Controls.Add(Me.HistoricalNewsTotalResultsText)
        Me.Controls.Add(Me.HistoricalNewsEndDateTimeText)
        Me.Controls.Add(Me.HistoricalNewsStartDateTimeText)
        Me.Controls.Add(Me.HistoricalNewsTotalResultsLabel)
        Me.Controls.Add(Me.HistoricalNewsEndDateTimeLabel)
        Me.Controls.Add(Me.HistoricalNewsStartDateTimeLabel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.HistoricalNewsConIdText)
        Me.Controls.Add(Me.HistoricalNewsProviderCodesText)
        Me.Controls.Add(Me.HistoricalNewsRequstIdText)
        Me.Controls.Add(Me.HistoricalNewsProviderCodesLabel)
        Me.Controls.Add(Me.HistoricalNewsConIdLabel)
        Me.Controls.Add(Me.HistoricalNewsRequestIdLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fHistoricalNews"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Historical News"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private mRequestId As Integer
    Private mConId As Integer
    Private mProviderCodes As String
    Private mStartDateTime As String
    Private mEndDateTime As String
    Private mTotalResults As Integer
    Private mOk As Boolean = False
    Private mOptions As List(Of TagValue) = New List(Of TagValue)

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property RequestId() As Integer
        Get
            RequestId = mRequestId
        End Get
    End Property

    Public ReadOnly Property ContractId() As Integer
        Get
            ContractId = mConId
        End Get
    End Property

    Public ReadOnly Property ProviderCodes() As String
        Get
            ProviderCodes = mProviderCodes
        End Get
    End Property

    Public ReadOnly Property StartDateTime() As String
        Get
            StartDateTime = mStartDateTime
        End Get
    End Property

    Public ReadOnly Property EndDateTime() As String
        Get
            EndDateTime = mEndDateTime
        End Get
    End Property

    Public ReadOnly Property TotalResults() As Integer
        Get
            TotalResults = mTotalResults
        End Get
    End Property

    Public ReadOnly Property Ok() As Boolean
        Get
            Ok = mOk
        End Get
    End Property

    Public ReadOnly Property Options() As List(Of TagValue)
        Get
            Return mOptions
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        mRequestId = Text2Int(HistoricalNewsRequstIdText.Text)
        mConId = Text2Int(HistoricalNewsConIdText.Text)
        mProviderCodes = HistoricalNewsProviderCodesText.Text
        mStartDateTime = HistoricalNewsStartDateTimeText.Text
        mEndDateTime = HistoricalNewsEndDateTimeText.Text
        mTotalResults = Text2Int(HistoricalNewsTotalResultsText.Text)
        mOk = True

        Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Hide()
    End Sub

    Private Sub fHistoricalNews_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mRequestId = 0
        HistoricalNewsStartDateTimeText.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss.0}", DateTime.Now.AddDays(-4))
        HistoricalNewsEndDateTimeText.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss.0}", DateTime.Now.AddDays(-3))
    End Sub

    ' ========================================================
    ' Public Methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Sets the dialog field and button states based on the dialog type
    '--------------------------------------------------------------------------------
    Public Sub Init()
        mOk = False
    End Sub

    Private Sub miscOptionsButton_Click(sender As Object, e As EventArgs) Handles MiscOptionsButton.Click
        Dim f As New FOptions
        f.init(options, "Misc Options")
        Dim res As DialogResult
        res = f.ShowDialog()
        If res = DialogResult.OK Then
            mOptions = New List(Of TagValue)(f.Options)
        End If
    End Sub
End Class
