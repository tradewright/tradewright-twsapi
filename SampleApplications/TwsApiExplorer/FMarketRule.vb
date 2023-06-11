' Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On
Friend Class FMarketRule
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
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents MarketRuleIdText As System.Windows.Forms.TextBox
    Public WithEvents MarketRuleIdLabel As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.MarketRuleIdText = New System.Windows.Forms.TextBox()
        Me.MarketRuleIdLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CancelButton
        '
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(143, 42)
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
        Me.OkButton.Location = New System.Drawing.Point(64, 42)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'MarketRuleIdText
        '
        Me.MarketRuleIdText.AcceptsReturn = True
        Me.MarketRuleIdText.BackColor = System.Drawing.SystemColors.Window
        Me.MarketRuleIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MarketRuleIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MarketRuleIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarketRuleIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MarketRuleIdText.Location = New System.Drawing.Point(119, 12)
        Me.MarketRuleIdText.MaxLength = 0
        Me.MarketRuleIdText.Name = "MarketRuleIdText"
        Me.MarketRuleIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MarketRuleIdText.Size = New System.Drawing.Size(97, 13)
        Me.MarketRuleIdText.TabIndex = 1
        Me.MarketRuleIdText.Text = "0"
        '
        'MarketRuleIdLabel
        '
        Me.MarketRuleIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.MarketRuleIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.MarketRuleIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarketRuleIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MarketRuleIdLabel.Location = New System.Drawing.Point(15, 15)
        Me.MarketRuleIdLabel.Name = "MarketRuleIdLabel"
        Me.MarketRuleIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MarketRuleIdLabel.Size = New System.Drawing.Size(97, 17)
        Me.MarketRuleIdLabel.TabIndex = 15
        Me.MarketRuleIdLabel.Text = "Market Rule Id"
        '
        'fMarketRule
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(237, 70)
        Me.Controls.Add(Me.MarketRuleIdLabel)
        Me.Controls.Add(Me.MarketRuleIdText)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OkButton)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fMarketRule"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Market Rule"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private mMarketRuleId As Integer
    Private mOk As Boolean

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================

    Public ReadOnly Property MarketRuleId() As Integer
        Get
            MarketRuleId = mMarketRuleId
        End Get
    End Property
    Public ReadOnly Property Ok() As Boolean
        Get
            Ok = mOk
        End Get
    End Property
    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        mMarketRuleId = Text2Int(MarketRuleIdText.Text)

        mOk = True
        Me.Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Me.Hide()
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
End Class


