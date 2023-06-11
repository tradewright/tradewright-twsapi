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
    Public WithEvents AliasesList As System.Windows.Forms.TextBox
    Public WithEvents GroupsList As System.Windows.Forms.TextBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents CloseButton As System.Windows.Forms.Button
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.AliasesList = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.GroupsList = New System.Windows.Forms.TextBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AliasesList
        '
        Me.AliasesList.AcceptsReturn = True
        Me.AliasesList.BackColor = System.Drawing.SystemColors.Window
        Me.AliasesList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AliasesList.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AliasesList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AliasesList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AliasesList.Location = New System.Drawing.Point(16, 363)
        Me.AliasesList.MaxLength = 0
        Me.AliasesList.Multiline = True
        Me.AliasesList.Name = "AliasesList"
        Me.AliasesList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AliasesList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AliasesList.Size = New System.Drawing.Size(633, 150)
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
        Me.Frame1.Size = New System.Drawing.Size(649, 313)
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
        Me.GroupsList.Size = New System.Drawing.Size(633, 276)
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
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame3.Location = New System.Drawing.Point(8, 335)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(649, 194)
        Me.Frame3.TabIndex = 6
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Aliases"
        '
        'fFinancialAdvisor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(667, 595)
        Me.Controls.Add(Me.AliasesList)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.CloseButton)
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
    Public AliasesXML, GroupsXML As String

    Private Const LF As String = Chr(10)
    Private Const CRLF As String = Chr(13) & Chr(10)

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

    Public Sub Init(faGroupXML As String, faAliasesXML As String)
        GroupsList.Text = Replace(faGroupXML, LF, CRLF)
        AliasesList.Text = Replace(faAliasesXML, LF, CRLF)
        mOk = False
    End Sub
    Public Function Ok() As Boolean
        GroupsXML = Replace(GroupsList.Text, CRLF, LF)
        AliasesXML = Replace(AliasesList.Text, CRLF, LF)
        Ok = mOk
    End Function
End Class
