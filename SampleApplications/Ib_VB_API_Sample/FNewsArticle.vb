' Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On

Imports System.Collections.Generic
Imports System.IO
Imports TradeWright.IBAPI

Friend Class FNewsArticle
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
    Public WithEvents ReqNewsArticleProviderCodeText As System.Windows.Forms.TextBox
    Public WithEvents ReqNewsArticleArticleIdText As System.Windows.Forms.TextBox
    Public WithEvents ReqNewsArticleRequestIdText As System.Windows.Forms.TextBox
    Public WithEvents ReqNewsArticleArticleIdLabel As System.Windows.Forms.Label
    Public WithEvents ReqNewsArticleProviderCodeLabel As System.Windows.Forms.Label
    Public WithEvents MiscOptionsButton As System.Windows.Forms.Button
    Public WithEvents ReqNewsArticlePathLabel As System.Windows.Forms.Label
    Public WithEvents ReqNewsArticlePathText As System.Windows.Forms.TextBox
    Friend WithEvents SelectFolderDialogButton As System.Windows.Forms.Button
    Public WithEvents ReqNewsArticleRequestIdLabel As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.ReqNewsArticleProviderCodeText = New System.Windows.Forms.TextBox()
        Me.ReqNewsArticleArticleIdText = New System.Windows.Forms.TextBox()
        Me.ReqNewsArticleRequestIdText = New System.Windows.Forms.TextBox()
        Me.ReqNewsArticleArticleIdLabel = New System.Windows.Forms.Label()
        Me.ReqNewsArticleProviderCodeLabel = New System.Windows.Forms.Label()
        Me.ReqNewsArticleRequestIdLabel = New System.Windows.Forms.Label()
        Me.MiscOptionsButton = New System.Windows.Forms.Button()
        Me.ReqNewsArticlePathLabel = New System.Windows.Forms.Label()
        Me.ReqNewsArticlePathText = New System.Windows.Forms.TextBox()
        Me.SelectFolderDialogButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OkButton.BackColor = System.Drawing.SystemColors.Control
        Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OkButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OkButton.Location = New System.Drawing.Point(57, 171)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 7
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
        Me.CancelItButton.Location = New System.Drawing.Point(136, 171)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(73, 25)
        Me.CancelItButton.TabIndex = 8
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'ReqNewsArticleProviderCodeText
        '
        Me.ReqNewsArticleProviderCodeText.AcceptsReturn = True
        Me.ReqNewsArticleProviderCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.ReqNewsArticleProviderCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqNewsArticleProviderCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqNewsArticleProviderCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticleProviderCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReqNewsArticleProviderCodeText.Location = New System.Drawing.Point(117, 42)
        Me.ReqNewsArticleProviderCodeText.MaxLength = 0
        Me.ReqNewsArticleProviderCodeText.Name = "ReqNewsArticleProviderCodeText"
        Me.ReqNewsArticleProviderCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticleProviderCodeText.Size = New System.Drawing.Size(151, 13)
        Me.ReqNewsArticleProviderCodeText.TabIndex = 3
        '
        'ReqNewsArticleArticleIdText
        '
        Me.ReqNewsArticleArticleIdText.AcceptsReturn = True
        Me.ReqNewsArticleArticleIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ReqNewsArticleArticleIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqNewsArticleArticleIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqNewsArticleArticleIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticleArticleIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReqNewsArticleArticleIdText.Location = New System.Drawing.Point(117, 71)
        Me.ReqNewsArticleArticleIdText.MaxLength = 0
        Me.ReqNewsArticleArticleIdText.Name = "ReqNewsArticleArticleIdText"
        Me.ReqNewsArticleArticleIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticleArticleIdText.Size = New System.Drawing.Size(151, 13)
        Me.ReqNewsArticleArticleIdText.TabIndex = 5
        '
        'ReqNewsArticleRequestIdText
        '
        Me.ReqNewsArticleRequestIdText.AcceptsReturn = True
        Me.ReqNewsArticleRequestIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ReqNewsArticleRequestIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqNewsArticleRequestIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqNewsArticleRequestIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticleRequestIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReqNewsArticleRequestIdText.Location = New System.Drawing.Point(117, 16)
        Me.ReqNewsArticleRequestIdText.MaxLength = 0
        Me.ReqNewsArticleRequestIdText.Name = "ReqNewsArticleRequestIdText"
        Me.ReqNewsArticleRequestIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticleRequestIdText.Size = New System.Drawing.Size(151, 13)
        Me.ReqNewsArticleRequestIdText.TabIndex = 1
        Me.ReqNewsArticleRequestIdText.Text = "0"
        '
        'ReqNewsArticleArticleIdLabel
        '
        Me.ReqNewsArticleArticleIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ReqNewsArticleArticleIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReqNewsArticleArticleIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticleArticleIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqNewsArticleArticleIdLabel.Location = New System.Drawing.Point(16, 71)
        Me.ReqNewsArticleArticleIdLabel.Name = "ReqNewsArticleArticleIdLabel"
        Me.ReqNewsArticleArticleIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticleArticleIdLabel.Size = New System.Drawing.Size(89, 17)
        Me.ReqNewsArticleArticleIdLabel.TabIndex = 4
        Me.ReqNewsArticleArticleIdLabel.Text = "Article Id"
        '
        'ReqNewsArticleProviderCodeLabel
        '
        Me.ReqNewsArticleProviderCodeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ReqNewsArticleProviderCodeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReqNewsArticleProviderCodeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticleProviderCodeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqNewsArticleProviderCodeLabel.Location = New System.Drawing.Point(16, 42)
        Me.ReqNewsArticleProviderCodeLabel.Name = "ReqNewsArticleProviderCodeLabel"
        Me.ReqNewsArticleProviderCodeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticleProviderCodeLabel.Size = New System.Drawing.Size(89, 19)
        Me.ReqNewsArticleProviderCodeLabel.TabIndex = 2
        Me.ReqNewsArticleProviderCodeLabel.Text = "Provider Code"
        '
        'ReqNewsArticleRequestIdLabel
        '
        Me.ReqNewsArticleRequestIdLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton
        Me.ReqNewsArticleRequestIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ReqNewsArticleRequestIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReqNewsArticleRequestIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticleRequestIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqNewsArticleRequestIdLabel.Location = New System.Drawing.Point(16, 16)
        Me.ReqNewsArticleRequestIdLabel.Name = "ReqNewsArticleRequestIdLabel"
        Me.ReqNewsArticleRequestIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticleRequestIdLabel.Size = New System.Drawing.Size(95, 17)
        Me.ReqNewsArticleRequestIdLabel.TabIndex = 0
        Me.ReqNewsArticleRequestIdLabel.Text = "Request Id"
        '
        'MiscOptionsButton
        '
        Me.MiscOptionsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MiscOptionsButton.BackColor = System.Drawing.SystemColors.Control
        Me.MiscOptionsButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.MiscOptionsButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MiscOptionsButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MiscOptionsButton.Location = New System.Drawing.Point(19, 140)
        Me.MiscOptionsButton.Name = "MiscOptionsButton"
        Me.MiscOptionsButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MiscOptionsButton.Size = New System.Drawing.Size(249, 25)
        Me.MiscOptionsButton.TabIndex = 9
        Me.MiscOptionsButton.Text = "Misc Options"
        Me.MiscOptionsButton.UseVisualStyleBackColor = True
        '
        'ReqNewsArticlePathLabel
        '
        Me.ReqNewsArticlePathLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ReqNewsArticlePathLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReqNewsArticlePathLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticlePathLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqNewsArticlePathLabel.Location = New System.Drawing.Point(16, 101)
        Me.ReqNewsArticlePathLabel.Name = "ReqNewsArticlePathLabel"
        Me.ReqNewsArticlePathLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticlePathLabel.Size = New System.Drawing.Size(89, 36)
        Me.ReqNewsArticlePathLabel.TabIndex = 10
        Me.ReqNewsArticlePathLabel.Text = "Path to Save binary/pdf"
        '
        'ReqNewsArticlePathText
        '
        Me.ReqNewsArticlePathText.AcceptsReturn = True
        Me.ReqNewsArticlePathText.BackColor = System.Drawing.SystemColors.Window
        Me.ReqNewsArticlePathText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqNewsArticlePathText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqNewsArticlePathText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqNewsArticlePathText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReqNewsArticlePathText.Location = New System.Drawing.Point(117, 101)
        Me.ReqNewsArticlePathText.MaxLength = 0
        Me.ReqNewsArticlePathText.Name = "ReqNewsArticlePathText"
        Me.ReqNewsArticlePathText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqNewsArticlePathText.Size = New System.Drawing.Size(116, 13)
        Me.ReqNewsArticlePathText.TabIndex = 11
        '
        'SelectFolderDialogButton
        '
        Me.SelectFolderDialogButton.Location = New System.Drawing.Point(239, 98)
        Me.SelectFolderDialogButton.Name = "SelectFolderDialogButton"
        Me.SelectFolderDialogButton.Size = New System.Drawing.Size(29, 20)
        Me.SelectFolderDialogButton.TabIndex = 12
        Me.SelectFolderDialogButton.Text = "..."
        Me.SelectFolderDialogButton.UseVisualStyleBackColor = True
        '
        'fNewsArticle
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(280, 208)
        Me.Controls.Add(Me.SelectFolderDialogButton)
        Me.Controls.Add(Me.ReqNewsArticlePathText)
        Me.Controls.Add(Me.ReqNewsArticlePathLabel)
        Me.Controls.Add(Me.MiscOptionsButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.ReqNewsArticleProviderCodeText)
        Me.Controls.Add(Me.ReqNewsArticleArticleIdText)
        Me.Controls.Add(Me.ReqNewsArticleRequestIdText)
        Me.Controls.Add(Me.ReqNewsArticleArticleIdLabel)
        Me.Controls.Add(Me.ReqNewsArticleProviderCodeLabel)
        Me.Controls.Add(Me.ReqNewsArticleRequestIdLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fNewsArticle"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request News Article"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private mRequestId As Integer
    Private mProviderCode As String
    Private mArticleId As String
    Private mPath As String
    Private mOk As Boolean = False
    Private mOptions As List(Of TagValue)

    Protected Overrides Sub OnLoad(e As EventArgs)
        mPath = Directory.GetCurrentDirectory()
        MyBase.OnLoad(e)
    End Sub

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property RequestId() As Integer
        Get
            RequestId = mRequestId
        End Get
    End Property

    Public ReadOnly Property ProviderCode() As String
        Get
            ProviderCode = mProviderCode
        End Get
    End Property

    Public ReadOnly Property ArticleId() As String
        Get
            ArticleId = mArticleId
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            Path = mPath
        End Get
    End Property

    Public ReadOnly Property Ok() As Boolean
        Get
            Ok = mOk
        End Get
    End Property

    Public ReadOnly Property Options() As List(Of TagValue)
        Get
            Options = mOptions
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        mRequestId = Text2Int(ReqNewsArticleRequestIdText.Text)
        mProviderCode = ReqNewsArticleProviderCodeText.Text
        mArticleId = ReqNewsArticleArticleIdText.Text
        mPath = ReqNewsArticlePathText.Text + "\" + articleId + ".pdf"
        mOk = True

        Hide()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Hide()
    End Sub

    Private Sub fNewsArticle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mRequestId = 0
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

    Private Sub selectFolderDialogButton_Click(sender As Object, e As EventArgs) Handles SelectFolderDialogButton.Click
        Dim f As New FolderBrowserDialog With {.SelectedPath = ReqNewsArticlePathText.Text}

        If f.ShowDialog <> DialogResult.OK Then
            Return
        End If

        ReqNewsArticlePathText.Text = f.SelectedPath
    End Sub
End Class
