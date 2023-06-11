' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.



Imports TradeWright.IBAPI

Friend Class FExecFilter
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            If components IsNot Nothing Then components.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents ActionText As System.Windows.Forms.TextBox
    Public WithEvents ClientIdText As System.Windows.Forms.TextBox
    Public WithEvents AcctCodeText As System.Windows.Forms.TextBox
    Public WithEvents TimeText As System.Windows.Forms.TextBox
    Public WithEvents SymbolText As System.Windows.Forms.TextBox
    Public WithEvents SecTypeText As System.Windows.Forms.TextBox
    Public WithEvents ExchangeText As System.Windows.Forms.TextBox
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents ClientIdLabel As System.Windows.Forms.Label
    Public WithEvents AcctCodeLabel As System.Windows.Forms.Label
    Public WithEvents TimeLabel As System.Windows.Forms.Label
    Public WithEvents SymbolLabel As System.Windows.Forms.Label
    Public WithEvents SecTypeLabel As System.Windows.Forms.Label
    Public WithEvents ExchangeLabel As System.Windows.Forms.Label
    Public WithEvents ReqIdText As System.Windows.Forms.TextBox
    Public WithEvents ReqIdLabel As System.Windows.Forms.Label
    Public WithEvents ActionLabel As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ActionText = New System.Windows.Forms.TextBox()
        Me.ClientIdText = New System.Windows.Forms.TextBox()
        Me.AcctCodeText = New System.Windows.Forms.TextBox()
        Me.TimeText = New System.Windows.Forms.TextBox()
        Me.SymbolText = New System.Windows.Forms.TextBox()
        Me.SecTypeText = New System.Windows.Forms.TextBox()
        Me.ExchangeText = New System.Windows.Forms.TextBox()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.ClientIdLabel = New System.Windows.Forms.Label()
        Me.AcctCodeLabel = New System.Windows.Forms.Label()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.SymbolLabel = New System.Windows.Forms.Label()
        Me.SecTypeLabel = New System.Windows.Forms.Label()
        Me.ExchangeLabel = New System.Windows.Forms.Label()
        Me.ActionLabel = New System.Windows.Forms.Label()
        Me.ReqIdText = New System.Windows.Forms.TextBox()
        Me.ReqIdLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ActionText
        '
        Me.ActionText.AcceptsReturn = True
        Me.ActionText.BackColor = System.Drawing.SystemColors.Window
        Me.ActionText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ActionText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ActionText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActionText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ActionText.Location = New System.Drawing.Point(119, 188)
        Me.ActionText.MaxLength = 0
        Me.ActionText.Name = "ActionText"
        Me.ActionText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ActionText.Size = New System.Drawing.Size(97, 13)
        Me.ActionText.TabIndex = 8
        '
        'ClientIdText
        '
        Me.ClientIdText.AcceptsReturn = True
        Me.ClientIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ClientIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ClientIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ClientIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ClientIdText.Location = New System.Drawing.Point(119, 38)
        Me.ClientIdText.MaxLength = 0
        Me.ClientIdText.Name = "ClientIdText"
        Me.ClientIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ClientIdText.Size = New System.Drawing.Size(97, 13)
        Me.ClientIdText.TabIndex = 2
        '
        'AcctCodeText
        '
        Me.AcctCodeText.AcceptsReturn = True
        Me.AcctCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.AcctCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AcctCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AcctCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AcctCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AcctCodeText.Location = New System.Drawing.Point(119, 63)
        Me.AcctCodeText.MaxLength = 0
        Me.AcctCodeText.Name = "AcctCodeText"
        Me.AcctCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AcctCodeText.Size = New System.Drawing.Size(97, 13)
        Me.AcctCodeText.TabIndex = 3
        '
        'TimeText
        '
        Me.TimeText.AcceptsReturn = True
        Me.TimeText.BackColor = System.Drawing.SystemColors.Window
        Me.TimeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TimeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TimeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TimeText.Location = New System.Drawing.Point(119, 88)
        Me.TimeText.MaxLength = 0
        Me.TimeText.Name = "TimeText"
        Me.TimeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TimeText.Size = New System.Drawing.Size(97, 13)
        Me.TimeText.TabIndex = 4
        '
        'SymbolText
        '
        Me.SymbolText.AcceptsReturn = True
        Me.SymbolText.BackColor = System.Drawing.SystemColors.Window
        Me.SymbolText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SymbolText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SymbolText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SymbolText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SymbolText.Location = New System.Drawing.Point(119, 113)
        Me.SymbolText.MaxLength = 0
        Me.SymbolText.Name = "SymbolText"
        Me.SymbolText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SymbolText.Size = New System.Drawing.Size(97, 13)
        Me.SymbolText.TabIndex = 5
        '
        'SecTypeText
        '
        Me.SecTypeText.AcceptsReturn = True
        Me.SecTypeText.BackColor = System.Drawing.SystemColors.Window
        Me.SecTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SecTypeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SecTypeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecTypeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SecTypeText.Location = New System.Drawing.Point(119, 138)
        Me.SecTypeText.MaxLength = 0
        Me.SecTypeText.Name = "SecTypeText"
        Me.SecTypeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SecTypeText.Size = New System.Drawing.Size(97, 13)
        Me.SecTypeText.TabIndex = 6
        '
        'ExchangeText
        '
        Me.ExchangeText.AcceptsReturn = True
        Me.ExchangeText.BackColor = System.Drawing.SystemColors.Window
        Me.ExchangeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExchangeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExchangeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExchangeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExchangeText.Location = New System.Drawing.Point(119, 163)
        Me.ExchangeText.MaxLength = 0
        Me.ExchangeText.Name = "ExchangeText"
        Me.ExchangeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExchangeText.Size = New System.Drawing.Size(97, 13)
        Me.ExchangeText.TabIndex = 7
        '
        'CancelButton
        '
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(143, 213)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(73, 25)
        Me.CancelItButton.TabIndex = 1
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.BackColor = System.Drawing.SystemColors.Control
        Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OkButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OkButton.Location = New System.Drawing.Point(64, 213)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'ClientIdLabel
        '
        Me.ClientIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ClientIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ClientIdLabel.Location = New System.Drawing.Point(15, 41)
        Me.ClientIdLabel.Name = "ClientIdLabel"
        Me.ClientIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ClientIdLabel.Size = New System.Drawing.Size(65, 17)
        Me.ClientIdLabel.TabIndex = 14
        Me.ClientIdLabel.Text = "Client Id"
        '
        'AcctCodeLabel
        '
        Me.AcctCodeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.AcctCodeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.AcctCodeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AcctCodeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AcctCodeLabel.Location = New System.Drawing.Point(15, 66)
        Me.AcctCodeLabel.Name = "AcctCodeLabel"
        Me.AcctCodeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AcctCodeLabel.Size = New System.Drawing.Size(97, 17)
        Me.AcctCodeLabel.TabIndex = 13
        Me.AcctCodeLabel.Text = "Account Code"
        '
        'TimeLabel
        '
        Me.TimeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.TimeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.TimeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TimeLabel.Location = New System.Drawing.Point(15, 91)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TimeLabel.Size = New System.Drawing.Size(65, 17)
        Me.TimeLabel.TabIndex = 12
        Me.TimeLabel.Text = "Time"
        '
        'SymbolLabel
        '
        Me.SymbolLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.SymbolLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.SymbolLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SymbolLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SymbolLabel.Location = New System.Drawing.Point(15, 116)
        Me.SymbolLabel.Name = "SymbolLabel"
        Me.SymbolLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SymbolLabel.Size = New System.Drawing.Size(65, 17)
        Me.SymbolLabel.TabIndex = 11
        Me.SymbolLabel.Text = "Symbol"
        '
        'SecTypeLabel
        '
        Me.SecTypeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.SecTypeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.SecTypeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SecTypeLabel.Location = New System.Drawing.Point(15, 141)
        Me.SecTypeLabel.Name = "SecTypeLabel"
        Me.SecTypeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SecTypeLabel.Size = New System.Drawing.Size(65, 17)
        Me.SecTypeLabel.TabIndex = 10
        Me.SecTypeLabel.Text = "SecType"
        '
        'ExchangeLabel
        '
        Me.ExchangeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ExchangeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExchangeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExchangeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExchangeLabel.Location = New System.Drawing.Point(15, 166)
        Me.ExchangeLabel.Name = "ExchangeLabel"
        Me.ExchangeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExchangeLabel.Size = New System.Drawing.Size(73, 17)
        Me.ExchangeLabel.TabIndex = 9
        Me.ExchangeLabel.Text = "Exchange"
        '
        'ActionLabel
        '
        Me.ActionLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ActionLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ActionLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActionLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ActionLabel.Location = New System.Drawing.Point(15, 191)
        Me.ActionLabel.Name = "ActionLabel"
        Me.ActionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ActionLabel.Size = New System.Drawing.Size(81, 17)
        Me.ActionLabel.TabIndex = 8
        Me.ActionLabel.Text = "Action"
        '
        'ReqIdText
        '
        Me.ReqIdText.AcceptsReturn = True
        Me.ReqIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ReqIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReqIdText.Location = New System.Drawing.Point(119, 12)
        Me.ReqIdText.MaxLength = 0
        Me.ReqIdText.Name = "ReqIdText"
        Me.ReqIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqIdText.Size = New System.Drawing.Size(97, 13)
        Me.ReqIdText.TabIndex = 1
        '
        'ReqIdLabel
        '
        Me.ReqIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ReqIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReqIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqIdLabel.Location = New System.Drawing.Point(15, 15)
        Me.ReqIdLabel.Name = "ReqIdLabel"
        Me.ReqIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqIdLabel.Size = New System.Drawing.Size(65, 17)
        Me.ReqIdLabel.TabIndex = 15
        Me.ReqIdLabel.Text = "Request Id"
        '
        'fExecFilter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(237, 253)
        Me.Controls.Add(Me.ReqIdLabel)
        Me.Controls.Add(Me.ReqIdText)
        Me.Controls.Add(Me.ActionText)
        Me.Controls.Add(Me.ClientIdText)
        Me.Controls.Add(Me.AcctCodeText)
        Me.Controls.Add(Me.TimeText)
        Me.Controls.Add(Me.SymbolText)
        Me.Controls.Add(Me.SecTypeText)
        Me.Controls.Add(Me.ExchangeText)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.ClientIdLabel)
        Me.Controls.Add(Me.AcctCodeLabel)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.SymbolLabel)
        Me.Controls.Add(Me.SecTypeLabel)
        Me.Controls.Add(Me.ExchangeLabel)
        Me.Controls.Add(Me.ActionLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fExecFilter"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Execution Report Filter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private mExecFilter As ExecutionFilter

    Private mReqId As Integer
    Private mOk As Boolean

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================

    Public ReadOnly Property ReqId() As Integer
        Get
            ReqId = mReqId
        End Get
    End Property
    Public ReadOnly Property ExecFilter() As ExecutionFilter
        Get
            ExecFilter = mExecFilter
        End Get
    End Property

    Public ReadOnly Property Ok() As Boolean
        Get
            Ok = mOk
        End Get
    End Property
    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub Init(execFilter As ExecutionFilter)

        mExecFilter = execFilter

        With execFilter

            ClientIdText.Text = CStr(.ClientID)
            AcctCodeText.Text = .AccountCode
            TimeText.Text = If(.Time = Date.MaxValue, "", CStr(.Time))
            SymbolText.Text = .Symbol
            SecTypeText.Text = IBAPI.SecurityTypes.ToExternalString(.SecType)
            ExchangeText.Text = .Exchange
            ActionText.Text = IBAPI.OrderActions.ToInternalString(.Action)

        End With
    End Sub

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        mReqId = Text2Int(ReqIdText.Text)

        With mExecFilter

            .ClientID = Text2Int(ClientIdText.Text)
            .AccountCode = AcctCodeText.Text
            .Time = If(TimeText.Text = "", Date.MaxValue, CDate(TimeText.Text))
            .Symbol = SymbolText.Text
            .SecType = IBAPI.SecurityTypes.Parse(SecTypeText.Text, True)
            .Exchange = ExchangeText.Text
            .Action = IBAPI.OrderActions.Parse(ActionText.Text, True)

        End With

        mOk = True
        Me.Hide()

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Me.Hide()
    End Sub

    Private Sub fExecFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mReqId = 0
    End Sub

End Class
