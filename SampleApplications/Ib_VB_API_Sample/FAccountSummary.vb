' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Friend Class FAccountSummary
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        initializeComponent()
        formInitialize()
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
    Public WithEvents GroupNameText As System.Windows.Forms.TextBox
    Public WithEvents TagsText As System.Windows.Forms.TextBox
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents GroupNameLabel As System.Windows.Forms.Label
    Public WithEvents TagsLabel As System.Windows.Forms.Label
    Public WithEvents ReqIdText As System.Windows.Forms.TextBox
    Private components As System.ComponentModel.IContainer
    Public WithEvents ReqIdLabel As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupNameText = New System.Windows.Forms.TextBox()
        Me.TagsText = New System.Windows.Forms.TextBox()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.GroupNameLabel = New System.Windows.Forms.Label()
        Me.TagsLabel = New System.Windows.Forms.Label()
        Me.ReqIdText = New System.Windows.Forms.TextBox()
        Me.ReqIdLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'GroupNameText
        '
        Me.GroupNameText.AcceptsReturn = True
        Me.GroupNameText.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.GroupNameText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GroupNameText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GroupNameText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupNameText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupNameText.Location = New System.Drawing.Point(119, 38)
        Me.GroupNameText.MaxLength = 0
        Me.GroupNameText.Name = "GroupNameText"
        Me.GroupNameText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupNameText.Size = New System.Drawing.Size(97, 13)
        Me.GroupNameText.TabIndex = 2
        Me.GroupNameText.Text = "All"
        '
        'TagsText
        '
        Me.TagsText.AcceptsReturn = True
        Me.TagsText.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.TagsText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TagsText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TagsText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TagsText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TagsText.Location = New System.Drawing.Point(119, 63)
        Me.TagsText.MaxLength = 0
        Me.TagsText.Name = "TagsText"
        Me.TagsText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TagsText.Size = New System.Drawing.Size(97, 13)
        Me.TagsText.TabIndex = 3
        Me.TagsText.Text = "AccruedCash,BuyingPower,NetLiquidation"
        '
        'CancelItButton
        '
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(143, 89)
        Me.CancelItButton.Name = "CancelItButton"
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
        Me.OkButton.Location = New System.Drawing.Point(64, 89)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'GroupNameLabel
        '
        Me.GroupNameLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupNameLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupNameLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupNameLabel.Location = New System.Drawing.Point(15, 38)
        Me.GroupNameLabel.Name = "GroupNameLabel"
        Me.GroupNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupNameLabel.Size = New System.Drawing.Size(97, 17)
        Me.GroupNameLabel.TabIndex = 14
        Me.GroupNameLabel.Text = "Group Name"
        '
        'TagsLabel
        '
        Me.TagsLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.TagsLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TagsLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TagsLabel.Location = New System.Drawing.Point(15, 63)
        Me.TagsLabel.Name = "TagsLabel"
        Me.TagsLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TagsLabel.Size = New System.Drawing.Size(97, 17)
        Me.TagsLabel.TabIndex = 13
        Me.TagsLabel.Text = "Tags"
        '
        'ReqIdText
        '
        Me.ReqIdText.AcceptsReturn = True
        Me.ReqIdText.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ReqIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqIdText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqIdText.Location = New System.Drawing.Point(119, 12)
        Me.ReqIdText.MaxLength = 0
        Me.ReqIdText.Name = "ReqIdText"
        Me.ReqIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqIdText.Size = New System.Drawing.Size(97, 13)
        Me.ReqIdText.TabIndex = 1
        Me.ReqIdText.Text = "0"
        '
        'ReqIdLabel
        '
        Me.ReqIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReqIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqIdLabel.Location = New System.Drawing.Point(15, 9)
        Me.ReqIdLabel.Name = "ReqIdLabel"
        Me.ReqIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqIdLabel.Size = New System.Drawing.Size(97, 17)
        Me.ReqIdLabel.TabIndex = 15
        Me.ReqIdLabel.Text = "Request Id"
        '
        'FAccountSummary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(237, 118)
        Me.Controls.Add(Me.ReqIdLabel)
        Me.Controls.Add(Me.ReqIdText)
        Me.Controls.Add(Me.GroupNameText)
        Me.Controls.Add(Me.TagsText)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.GroupNameLabel)
        Me.Controls.Add(Me.TagsLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAccountSummary"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Account Summary"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Public Enum Dlg_Type
        REQUEST_ACCOUNT_SUMMARY = 1
        CANCEL_ACCOUNT_SUMMARY
    End Enum

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private mArrDlgTitles As New Collection
    Private mReqId As Integer
    Private mGroupName As String
    Private mTags As String
    Private mOk As Boolean

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================

    Public ReadOnly Property ReqId() As Integer
        Get
            ReqId = mReqId
        End Get
    End Property
    Public ReadOnly Property GroupName() As String
        Get
            GroupName = mGroupName
        End Get
    End Property
    Public ReadOnly Property Tags() As String
        Get
            Tags = mTags
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

        mReqId = Text2Int(ReqIdText.Text)
        mGroupName = GroupNameText.Text
        mTags = TagsText.Text

        mOk = True
        Me.Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Me.Hide()
    End Sub

    Private Sub fAccountSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mReqId = 0
    End Sub

    ' ========================================================
    ' Public Methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Sets the dialog field and button states based on the dialog type
    '--------------------------------------------------------------------------------
    Public Sub Init(fType As Dlg_Type)
        mOk = False

        Text = mArrDlgTitles.Item(fType)

        ReqIdText.Enabled = True
        GroupNameText.Enabled = (fType = Dlg_Type.REQUEST_ACCOUNT_SUMMARY)
        TagsText.Enabled = (fType = Dlg_Type.REQUEST_ACCOUNT_SUMMARY)

    End Sub

    '--------------------------------------------------------------------------------
    ' Set the various dialog title string for each dialog type and the initial
    ' dialog data.
    '--------------------------------------------------------------------------------
    Private Sub formInitialize()
        mArrDlgTitles.Add("Request Account Summary")
        mArrDlgTitles.Add("Cancel Account Summary")
    End Sub
End Class


