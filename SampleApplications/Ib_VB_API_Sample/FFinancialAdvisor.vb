' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On
Friend Class FFinancialAdvisor
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
    Public WithEvents ProfilesList As System.Windows.Forms.TextBox
    Public WithEvents AliasesList As System.Windows.Forms.TextBox
    Public WithEvents GroupsList As System.Windows.Forms.TextBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents CloseButton As System.Windows.Forms.Button
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.ProfilesList = New System.Windows.Forms.TextBox()
        Me.AliasesList = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.GroupsList = New System.Windows.Forms.TextBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProfilesList
        '
        Me.ProfilesList.AcceptsReturn = True
        Me.ProfilesList.BackColor = System.Drawing.SystemColors.Window
        Me.ProfilesList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ProfilesList.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ProfilesList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfilesList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ProfilesList.Location = New System.Drawing.Point(16, 216)
        Me.ProfilesList.MaxLength = 0
        Me.ProfilesList.Multiline = True
        Me.ProfilesList.Name = "ProfilesList"
        Me.ProfilesList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProfilesList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ProfilesList.Size = New System.Drawing.Size(633, 121)
        Me.ProfilesList.TabIndex = 4
        Me.ProfilesList.Text = "Start" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ProfilesList.WordWrap = False
        '
        'AliasesList
        '
        Me.AliasesList.AcceptsReturn = True
        Me.AliasesList.BackColor = System.Drawing.SystemColors.Window
        Me.AliasesList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AliasesList.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AliasesList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AliasesList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AliasesList.Location = New System.Drawing.Point(16, 392)
        Me.AliasesList.MaxLength = 0
        Me.AliasesList.Multiline = True
        Me.AliasesList.Name = "AliasesList"
        Me.AliasesList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AliasesList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AliasesList.Size = New System.Drawing.Size(633, 121)
        Me.AliasesList.TabIndex = 3
        Me.AliasesList.Text = "Start" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.AliasesList.WordWrap = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame1.Controls.Add(Me.GroupsList)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame1.Location = New System.Drawing.Point(8, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(649, 161)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Groups:"
        '
        'GroupsList
        '
        Me.GroupsList.AcceptsReturn = True
        Me.GroupsList.BackColor = System.Drawing.SystemColors.Window
        Me.GroupsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GroupsList.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GroupsList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupsList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupsList.Location = New System.Drawing.Point(8, 24)
        Me.GroupsList.MaxLength = 0
        Me.GroupsList.Multiline = True
        Me.GroupsList.Name = "GroupsList"
        Me.GroupsList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupsList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.GroupsList.Size = New System.Drawing.Size(633, 121)
        Me.GroupsList.TabIndex = 2
        Me.GroupsList.Text = "Start" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.GroupsList.WordWrap = False
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.SystemColors.Control
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CloseButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CloseButton.Location = New System.Drawing.Point(293, 560)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CloseButton.Size = New System.Drawing.Size(81, 25)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Accept Edits"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame2.Location = New System.Drawing.Point(8, 192)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(649, 161)
        Me.Frame2.TabIndex = 5
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Profiles:"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame3.Location = New System.Drawing.Point(8, 368)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(649, 161)
        Me.Frame3.TabIndex = 6
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Aliases"
        '
        'fFinancialAdvisor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(667, 595)
        Me.Controls.Add(Me.ProfilesList)
        Me.Controls.Add(Me.AliasesList)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(315, 341)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fFinancialAdvisor"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Financial Advisor"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private mOk As Boolean
    Public AliasesXML, GroupsXML, ProfilesXML, CRSTR As String
    Public CRLFSTR As String
    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        ' clear any existing list details
        mOk = True
        Hide()
    End Sub

    ' ========================================================
    ' Public methods
    ' ========================================================

    Public Sub Init(faGroupXML As String, faProfilesXML As String, faAliasesXML As String)
        CRSTR = Chr(10)
        CRLFSTR = Chr(13) & Chr(10)
        GroupsList.Text = Replace(faGroupXML, CRSTR, CRLFSTR)
        ProfilesList.Text = Replace(faProfilesXML, CRSTR, CRLFSTR)
        AliasesList.Text = Replace(faAliasesXML, CRSTR, CRLFSTR)
        mOk = False
    End Sub
    Public Function Ok() As Boolean
        groupsXML = Replace(GroupsList.Text, CRLFSTR, CRSTR)
        profilesXML = Replace(ProfilesList.Text, CRLFSTR, CRSTR)
        aliasesXML = Replace(AliasesList.Text, CRLFSTR, CRSTR)
        Ok = mOk
    End Function
End Class
