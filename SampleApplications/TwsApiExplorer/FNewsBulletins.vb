' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Friend Class FNewsBulletins
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
    Public WithEvents SubscribeButton As System.Windows.Forms.Button
    Public WithEvents AllMsgsOption As System.Windows.Forms.RadioButton
    Public WithEvents NewMsgsOption As System.Windows.Forms.RadioButton
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents CloseButton As System.Windows.Forms.Button
    Public WithEvents UnsubscribeButton As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.SubscribeButton = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.AllMsgsOption = New System.Windows.Forms.RadioButton()
        Me.NewMsgsOption = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.UnsubscribeButton = New System.Windows.Forms.Button()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SubscribeButton
        '
        Me.SubscribeButton.BackColor = System.Drawing.SystemColors.Control
        Me.SubscribeButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.SubscribeButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubscribeButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SubscribeButton.Location = New System.Drawing.Point(72, 112)
        Me.SubscribeButton.Name = "SubscribeButton"
        Me.SubscribeButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SubscribeButton.Size = New System.Drawing.Size(81, 25)
        Me.SubscribeButton.TabIndex = 4
        Me.SubscribeButton.Text = "Subscribe"
        Me.SubscribeButton.UseVisualStyleBackColor = True
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame1.Controls.Add(Me.AllMsgsOption)
        Me.Frame1.Controls.Add(Me.NewMsgsOption)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(353, 89)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        '
        'optAllMsgs
        '
        Me.AllMsgsOption.BackColor = System.Drawing.Color.Gainsboro
        Me.AllMsgsOption.Cursor = System.Windows.Forms.Cursors.Default
        Me.AllMsgsOption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllMsgsOption.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AllMsgsOption.Location = New System.Drawing.Point(32, 56)
        Me.AllMsgsOption.Name = "optAllMsgs"
        Me.AllMsgsOption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AllMsgsOption.Size = New System.Drawing.Size(305, 17)
        Me.AllMsgsOption.TabIndex = 6
        Me.AllMsgsOption.TabStop = True
        Me.AllMsgsOption.Text = "receive all current day's messages and any new messages."
        Me.AllMsgsOption.UseVisualStyleBackColor = False
        '
        'optNewMsgs
        '
        Me.NewMsgsOption.BackColor = System.Drawing.Color.Gainsboro
        Me.NewMsgsOption.Cursor = System.Windows.Forms.Cursors.Default
        Me.NewMsgsOption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewMsgsOption.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NewMsgsOption.Location = New System.Drawing.Point(32, 32)
        Me.NewMsgsOption.Name = "optNewMsgs"
        Me.NewMsgsOption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NewMsgsOption.Size = New System.Drawing.Size(241, 17)
        Me.NewMsgsOption.TabIndex = 5
        Me.NewMsgsOption.TabStop = True
        Me.NewMsgsOption.Text = "receive new messages only."
        Me.NewMsgsOption.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(297, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "When subscribing to IB news bulletins you have 2 options:"
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.SystemColors.Control
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CloseButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CloseButton.Location = New System.Drawing.Point(280, 112)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CloseButton.Size = New System.Drawing.Size(81, 25)
        Me.CloseButton.TabIndex = 1
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'UnsubscribeButton
        '
        Me.UnsubscribeButton.BackColor = System.Drawing.SystemColors.Control
        Me.UnsubscribeButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.UnsubscribeButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnsubscribeButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UnsubscribeButton.Location = New System.Drawing.Point(160, 112)
        Me.UnsubscribeButton.Name = "UnsubscribeButton"
        Me.UnsubscribeButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UnsubscribeButton.Size = New System.Drawing.Size(81, 25)
        Me.UnsubscribeButton.TabIndex = 0
        Me.UnsubscribeButton.Text = "UnSubscribe"
        Me.UnsubscribeButton.UseVisualStyleBackColor = True
        '
        'fNewsBulletins
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(371, 146)
        Me.Controls.Add(Me.SubscribeButton)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.UnsubscribeButton)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fNewsBulletins"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "IB News Bulletin Subscription"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

    '================================================================================
    ' Private Members
    '================================================================================
    Private mSubscribe As Boolean
    Private mAllMsgs As Boolean
    Private mOk As Boolean

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================
    Public ReadOnly Property Subscribe() As Boolean
        Get
            Subscribe = mSubscribe
        End Get
    End Property

    Public ReadOnly Property AllMsgs() As Boolean
        Get
            AllMsgs = mAllMsgs
        End Get
    End Property

    Public ReadOnly Property Ok() As Boolean
        Get
            Ok = mOk
        End Get
    End Property

    '================================================================================
    ' Button Events
    '================================================================================

    '--------------------------------------------------------------------------------
    '   Aborts the news bulletin request and hides this dialog
    '--------------------------------------------------------------------------------
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        mOk = False
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    '   Subscribes to IB news bulletins. When subscribing users can get all the existing
    '   days messages and will be notified of new messages
    '--------------------------------------------------------------------------------
    Private Sub subscribeButton_Click(sender As Object, e As EventArgs) Handles SubscribeButton.Click
        mOk = True
        mSubscribe = True
        mAllMsgs = (AllMsgsOption.Checked = True)
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    '   Unsubscribes to news bulletins so users will not receive IB new bulletin
    '   notifications.
    '--------------------------------------------------------------------------------
    Private Sub unsubscribeButton_Click(sender As Object, e As EventArgs) Handles UnsubscribeButton.Click
        mOk = True
        mSubscribe = False
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    '   Default to the 'new messages only' subscription option if not is specified.
    '--------------------------------------------------------------------------------
    Private Sub fNewsBulletins_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewMsgsOption.Checked = True
    End Sub
End Class
