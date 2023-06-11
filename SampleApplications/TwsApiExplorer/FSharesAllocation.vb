' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Friend Class FSharesAllocation
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
    Public WithEvents FaProfileText As System.Windows.Forms.TextBox
    Public WithEvents OKButton As System.Windows.Forms.Button
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents FaGroupText As System.Windows.Forms.TextBox
    Public WithEvents FaPercentageText As System.Windows.Forms.TextBox
    Public WithEvents FaMethodText As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.FaProfileText = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.FaGroupText = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.FaPercentageText = New System.Windows.Forms.TextBox()
        Me.FaMethodText = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FaProfileText
        '
        Me.FaProfileText.AcceptsReturn = True
        Me.FaProfileText.BackColor = System.Drawing.SystemColors.Window
        Me.FaProfileText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FaProfileText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FaProfileText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FaProfileText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FaProfileText.Location = New System.Drawing.Point(112, 160)
        Me.FaProfileText.MaxLength = 0
        Me.FaProfileText.Name = "FaProfileText"
        Me.FaProfileText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FaProfileText.Size = New System.Drawing.Size(292, 13)
        Me.FaProfileText.TabIndex = 3
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(104, 216)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(76, 26)
        Me.OKButton.TabIndex = 4
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(240, 216)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(76, 26)
        Me.CancelItButton.TabIndex = 5
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'FaGroupText
        '
        Me.FaGroupText.AcceptsReturn = True
        Me.FaGroupText.BackColor = System.Drawing.SystemColors.Window
        Me.FaGroupText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FaGroupText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FaGroupText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FaGroupText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FaGroupText.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.FaGroupText.Location = New System.Drawing.Point(112, 24)
        Me.FaGroupText.MaxLength = 0
        Me.FaGroupText.Name = "FaGroupText"
        Me.FaGroupText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FaGroupText.Size = New System.Drawing.Size(292, 13)
        Me.FaGroupText.TabIndex = 0
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame1.Controls.Add(Me.FaPercentageText)
        Me.Frame1.Controls.Add(Me.FaMethodText)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(401, 121)
        Me.Frame1.TabIndex = 6
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Group"
        '
        'FaPercentageText
        '
        Me.FaPercentageText.AcceptsReturn = True
        Me.FaPercentageText.BackColor = System.Drawing.SystemColors.Window
        Me.FaPercentageText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FaPercentageText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FaPercentageText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FaPercentageText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FaPercentageText.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.FaPercentageText.Location = New System.Drawing.Point(104, 88)
        Me.FaPercentageText.MaxLength = 0
        Me.FaPercentageText.Name = "FaPercentageText"
        Me.FaPercentageText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FaPercentageText.Size = New System.Drawing.Size(292, 13)
        Me.FaPercentageText.TabIndex = 2
        '
        'FaMethodText
        '
        Me.FaMethodText.AcceptsReturn = True
        Me.FaMethodText.BackColor = System.Drawing.SystemColors.Window
        Me.FaMethodText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FaMethodText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FaMethodText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FaMethodText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FaMethodText.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.FaMethodText.Location = New System.Drawing.Point(104, 51)
        Me.FaMethodText.MaxLength = 0
        Me.FaMethodText.Name = "FaMethodText"
        Me.FaMethodText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FaMethodText.Size = New System.Drawing.Size(292, 13)
        Me.FaMethodText.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Percentage"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Method"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Group"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame2.Location = New System.Drawing.Point(8, 144)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(401, 49)
        Me.Frame2.TabIndex = 8
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Profile"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Profile"
        '
        'fSharesAlloc
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(418, 251)
        Me.Controls.Add(Me.FaProfileText)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.FaGroupText)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(189, 232)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fSharesAlloc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FA Allocation Info"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private mOk As Boolean
    Private mFaGroup As String
    Private mFaMethod As String
    Private mFaPercentage As String
    Private mFaProfile As String
    Public ReadOnly Property FaGroup() As String
        Get
            FaGroup = mFaGroup
        End Get
    End Property
    Public ReadOnly Property FaMethod() As String
        Get
            FaMethod = mFaMethod
        End Get
    End Property
    Public ReadOnly Property FaPercentage() As String
        Get
            FaPercentage = mFaPercentage
        End Get
    End Property
    Public ReadOnly Property FaProfile() As String
        Get
            FaProfile = mFaProfile
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
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        mFaGroup = FaGroupText.Text
        mFaMethod = FaMethodText.Text
        mFaPercentage = FaPercentageText.Text
        mFaProfile = FaProfileText.Text
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
    Public Sub Init(acctsList As String)

    End Sub
End Class
