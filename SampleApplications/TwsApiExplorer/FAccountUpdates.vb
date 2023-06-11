' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Friend Class FAccountUpdates
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
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents SubscribeButton As Button
    Public WithEvents AcctCodeText As TextBox
    Public WithEvents Label2 As Label
    Public WithEvents Label1 As Label
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.SubscribeButton = New System.Windows.Forms.Button()
        Me.AcctCodeText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CancelItButton
        '
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(164, 100)
        Me.CancelItButton.Name = "CancelItButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(81, 25)
        Me.CancelItButton.TabIndex = 6
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = False
        '
        'SubscribeButton
        '
        Me.SubscribeButton.BackColor = System.Drawing.SystemColors.Control
        Me.SubscribeButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.SubscribeButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubscribeButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SubscribeButton.Location = New System.Drawing.Point(58, 100)
        Me.SubscribeButton.Name = "SubscribeButton"
        Me.SubscribeButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SubscribeButton.Size = New System.Drawing.Size(81, 25)
        Me.SubscribeButton.TabIndex = 10
        Me.SubscribeButton.Text = "Subscribe"
        Me.SubscribeButton.UseVisualStyleBackColor = False
        '
        'AcctCodeText
        '
        Me.AcctCodeText.AcceptsReturn = True
        Me.AcctCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.AcctCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AcctCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AcctCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AcctCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AcctCodeText.Location = New System.Drawing.Point(124, 68)
        Me.AcctCodeText.MaxLength = 0
        Me.AcctCodeText.Name = "AcctCodeText"
        Me.AcctCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AcctCodeText.Size = New System.Drawing.Size(121, 13)
        Me.AcctCodeText.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(28, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Account Code :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(225, 33)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = " Enter the account code for the FA managed account you wish to receive updates fo" &
    "r : "
        '
        'FAccountUpdates
        '
        Me.AcceptButton = Me.SubscribeButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.CancelItButton
        Me.ClientSize = New System.Drawing.Size(257, 142)
        Me.Controls.Add(Me.SubscribeButton)
        Me.Controls.Add(Me.AcctCodeText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CancelItButton)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAccountUpdates"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Account Updates (FA customers only)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private mAccountCode As String

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property AccountCode() As String
        Get
            AccountCode = mAccountCode
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub subscribeButton_Click(sender As Object, e As EventArgs) Handles SubscribeButton.Click
        mAccountCode = AcctCodeText.Text
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mAccountCode = ""
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

End Class
