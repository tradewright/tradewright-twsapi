' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports TradeWright.IBAPI
Imports TradeWright.IBAPI.IBAPI

Friend Class FAccountSummary
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
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
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents GroupNameLabel As System.Windows.Forms.Label
    Public WithEvents TagsLabel As System.Windows.Forms.Label
    Public WithEvents ReqIdText As System.Windows.Forms.TextBox
    Private components As System.ComponentModel.IContainer
    Friend WithEvents TagsList As ListBox
    Public WithEvents ReqIdLabel As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        ToolTip1 = New ToolTip(components)
        GroupNameText = New TextBox()
        CancelItButton = New Button()
        OkButton = New Button()
        GroupNameLabel = New Label()
        TagsLabel = New Label()
        ReqIdText = New TextBox()
        ReqIdLabel = New Label()
        TagsList = New ListBox()
        SuspendLayout()
        ' 
        ' GroupNameText
        ' 
        GroupNameText.AcceptsReturn = True
        GroupNameText.BackColor = Color.FromArgb(CByte(232), CByte(232), CByte(232))
        GroupNameText.BorderStyle = BorderStyle.None
        GroupNameText.Cursor = Cursors.IBeam
        GroupNameText.Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        GroupNameText.ForeColor = SystemColors.ControlText
        GroupNameText.Location = New Point(87, 38)
        GroupNameText.MaxLength = 0
        GroupNameText.Name = "GroupNameText"
        GroupNameText.RightToLeft = RightToLeft.No
        GroupNameText.Size = New Size(146, 13)
        GroupNameText.TabIndex = 2
        GroupNameText.Text = "All"
        ' 
        ' CancelItButton
        ' 
        CancelItButton.BackColor = SystemColors.Control
        CancelItButton.Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        CancelItButton.ForeColor = SystemColors.ControlText
        CancelItButton.Location = New Point(160, 273)
        CancelItButton.Name = "CancelItButton"
        CancelItButton.RightToLeft = RightToLeft.No
        CancelItButton.Size = New Size(73, 25)
        CancelItButton.TabIndex = 1
        CancelItButton.Text = "Cancel"
        CancelItButton.UseVisualStyleBackColor = True
        ' 
        ' OkButton
        ' 
        OkButton.BackColor = SystemColors.Control
        OkButton.Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        OkButton.ForeColor = SystemColors.ControlText
        OkButton.Location = New Point(84, 273)
        OkButton.Name = "OkButton"
        OkButton.RightToLeft = RightToLeft.No
        OkButton.Size = New Size(70, 25)
        OkButton.TabIndex = 0
        OkButton.Text = "Ok"
        OkButton.UseVisualStyleBackColor = True
        ' 
        ' GroupNameLabel
        ' 
        GroupNameLabel.Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        GroupNameLabel.ForeColor = SystemColors.ControlText
        GroupNameLabel.Location = New Point(15, 38)
        GroupNameLabel.Name = "GroupNameLabel"
        GroupNameLabel.RightToLeft = RightToLeft.No
        GroupNameLabel.Size = New Size(67, 15)
        GroupNameLabel.TabIndex = 14
        GroupNameLabel.Text = "Group Name"
        ' 
        ' TagsLabel
        ' 
        TagsLabel.Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        TagsLabel.ForeColor = SystemColors.ControlText
        TagsLabel.Location = New Point(16, 67)
        TagsLabel.Name = "TagsLabel"
        TagsLabel.RightToLeft = RightToLeft.No
        TagsLabel.Size = New Size(66, 15)
        TagsLabel.TabIndex = 13
        TagsLabel.Text = "Tags"
        ' 
        ' ReqIdText
        ' 
        ReqIdText.AcceptsReturn = True
        ReqIdText.BackColor = Color.FromArgb(CByte(232), CByte(232), CByte(232))
        ReqIdText.BorderStyle = BorderStyle.None
        ReqIdText.Cursor = Cursors.IBeam
        ReqIdText.Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        ReqIdText.ForeColor = SystemColors.ControlText
        ReqIdText.Location = New Point(88, 9)
        ReqIdText.MaxLength = 0
        ReqIdText.Name = "ReqIdText"
        ReqIdText.RightToLeft = RightToLeft.No
        ReqIdText.Size = New Size(41, 13)
        ReqIdText.TabIndex = 1
        ReqIdText.Text = "0"
        ' 
        ' ReqIdLabel
        ' 
        ReqIdLabel.Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        ReqIdLabel.ForeColor = SystemColors.ControlText
        ReqIdLabel.Location = New Point(15, 9)
        ReqIdLabel.Name = "ReqIdLabel"
        ReqIdLabel.RightToLeft = RightToLeft.No
        ReqIdLabel.Size = New Size(67, 13)
        ReqIdLabel.TabIndex = 15
        ReqIdLabel.Text = "Request Id"
        ' 
        ' TagsList
        ' 
        TagsList.Enabled = False
        TagsList.FormattingEnabled = True
        TagsList.ItemHeight = 14
        TagsList.Location = New Point(84, 67)
        TagsList.Name = "TagsList"
        TagsList.SelectionMode = SelectionMode.MultiExtended
        TagsList.Size = New Size(230, 200)
        TagsList.Sorted = True
        TagsList.TabIndex = 16
        ' 
        ' FAccountSummary
        ' 
        AutoScaleBaseSize = New Size(5, 13)
        BackColor = Color.Gainsboro
        ClientSize = New Size(326, 307)
        Controls.Add(TagsList)
        Controls.Add(ReqIdLabel)
        Controls.Add(ReqIdText)
        Controls.Add(GroupNameText)
        Controls.Add(CancelItButton)
        Controls.Add(OkButton)
        Controls.Add(GroupNameLabel)
        Controls.Add(TagsLabel)
        Font = New Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Location = New Point(184, 250)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FAccountSummary"
        RightToLeft = RightToLeft.No
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "Account Summary"
        ResumeLayout(False)
        PerformLayout()
    End Sub
#End Region

    Public Enum Dlg_Type
        REQUEST_ACCOUNT_SUMMARY = 1
        CANCEL_ACCOUNT_SUMMARY
    End Enum

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private mArrDlgTitles As New Dictionary(Of Integer, String)
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
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        mReqId = Text2Int(ReqIdText.Text)
        mGroupName = GroupNameText.Text
        Dim ar(TagsList.SelectedItems.Count - 1) As String
        Dim i = 0
        For Each o In TagsList.SelectedItems
            ar(i) = o.ToString
            i += 1
        Next
        mTags = String.Join(","c, ar)

        mOk = True
        Me.Hide()
    End Sub

    Private Sub CancelItButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
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
        TagsList.Enabled = True

    End Sub

    '--------------------------------------------------------------------------------
    ' Set the various dialog title string for each dialog type and the initial
    ' dialog data.
    '--------------------------------------------------------------------------------
    Private Sub formInitialize()
        mArrDlgTitles.Add(Dlg_Type.REQUEST_ACCOUNT_SUMMARY, "Request Account Summary")
        mArrDlgTitles.Add(Dlg_Type.CANCEL_ACCOUNT_SUMMARY, "Cancel Account Summary")
        TagsList.Items.AddRange(IBAPI.AccountSummaryValues.ExternalNames)
    End Sub
End Class


