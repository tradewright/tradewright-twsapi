' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Friend Class FPositions
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
    Public WithEvents AccountText As System.Windows.Forms.TextBox
    Public WithEvents ModelCodeText As System.Windows.Forms.TextBox
    Public WithEvents IdText As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LedgerAndNLVCheck As System.Windows.Forms.CheckBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.AccountText = New System.Windows.Forms.TextBox()
        Me.ModelCodeText = New System.Windows.Forms.TextBox()
        Me.IdText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LedgerAndNLVCheck = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OkButton.BackColor = System.Drawing.SystemColors.Control
        Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OkButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OkButton.Location = New System.Drawing.Point(60, 121)
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
        Me.CancelItButton.Location = New System.Drawing.Point(148, 121)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(73, 25)
        Me.CancelItButton.TabIndex = 8
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'AccountText
        '
        Me.AccountText.AcceptsReturn = True
        Me.AccountText.BackColor = System.Drawing.SystemColors.Window
        Me.AccountText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AccountText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AccountText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccountText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AccountText.Location = New System.Drawing.Point(117, 42)
        Me.AccountText.MaxLength = 0
        Me.AccountText.Name = "AccountText"
        Me.AccountText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AccountText.Size = New System.Drawing.Size(151, 13)
        Me.AccountText.TabIndex = 3
        '
        'ModelCodeText
        '
        Me.ModelCodeText.AcceptsReturn = True
        Me.ModelCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.ModelCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModelCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ModelCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModelCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ModelCodeText.Location = New System.Drawing.Point(117, 68)
        Me.ModelCodeText.MaxLength = 0
        Me.ModelCodeText.Name = "ModelCodeText"
        Me.ModelCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ModelCodeText.Size = New System.Drawing.Size(151, 13)
        Me.ModelCodeText.TabIndex = 5
        '
        'IdText
        '
        Me.IdText.AcceptsReturn = True
        Me.IdText.BackColor = System.Drawing.SystemColors.Window
        Me.IdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.IdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.IdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.IdText.Location = New System.Drawing.Point(117, 16)
        Me.IdText.MaxLength = 0
        Me.IdText.Name = "IdText"
        Me.IdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.IdText.Size = New System.Drawing.Size(151, 13)
        Me.IdText.TabIndex = 1
        Me.IdText.Text = "0"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Model Code"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Account"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(193, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'LedgerAndNLVCheck
        '
        Me.LedgerAndNLVCheck.AutoSize = True
        Me.LedgerAndNLVCheck.Location = New System.Drawing.Point(19, 94)
        Me.LedgerAndNLVCheck.Name = "LedgerAndNLVCheck"
        Me.LedgerAndNLVCheck.Size = New System.Drawing.Size(100, 18)
        Me.LedgerAndNLVCheck.TabIndex = 6
        Me.LedgerAndNLVCheck.Text = "LedgerAndNLV"
        Me.LedgerAndNLVCheck.UseVisualStyleBackColor = True
        '
        'fPositions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(280, 154)
        Me.Controls.Add(Me.LedgerAndNLVCheck)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.AccountText)
        Me.Controls.Add(Me.ModelCodeText)
        Me.Controls.Add(Me.IdText)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPositions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Positions/Account Updates"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Friend Enum DialogType
        RequestPositionsMulti = 1
        CancelPositionsMulti
        RequestAccountUpdatesMulti
        CancelAccountUpdatesMulti
    End Enum

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private mId As Integer
    Private mAccount As String
    Private mModelCode As String
    Private mLedgerAndNLV As Boolean
    Private mOk As Boolean = False

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property Id() As Integer
        Get
            Id = mId
        End Get
    End Property

    Public ReadOnly Property Account() As String
        Get
            Account = mAccount
        End Get
    End Property

    Public ReadOnly Property ModelCode() As String
        Get
            ModelCode = mModelCode
        End Get
    End Property

    Public ReadOnly Property LedgerAndNLV() As Boolean
        Get
            LedgerAndNLV = mLedgerAndNLV
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
        mId = Text2Int(IdText.Text)
        mAccount = AccountText.Text
        mModelCode = ModelCodeText.Text
        mLedgerAndNLV = LedgerAndNLVCheck.Checked
        mOk = True

        Close()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Close()
    End Sub

    Private Sub fPositions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mId = 0
    End Sub


    ' ========================================================
    ' Public Methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Sets the dialog field and button states based on the dialog type
    '--------------------------------------------------------------------------------
    Public Sub Init(fType As DialogType)
        mOk = False

        Text = getTitle(fType)

        IdText.Enabled = True
        AccountText.Enabled = (fType = DialogType.RequestPositionsMulti Or fType = DialogType.RequestAccountUpdatesMulti)
        ModelCodeText.Enabled = (fType = DialogType.RequestPositionsMulti Or fType = DialogType.RequestAccountUpdatesMulti)
        LedgerAndNLVCheck.Enabled = (fType = DialogType.RequestAccountUpdatesMulti)

    End Sub

    Private Function getTitle(f_type As DialogType) As String
        Select Case f_type
            Case DialogType.CancelAccountUpdatesMulti
                Return "Cancel Account Updates Multi"
            Case DialogType.CancelPositionsMulti
                Return "Cancel Positions Multi"
            Case DialogType.RequestAccountUpdatesMulti
                Return "Request Account Updates Multi"
            Case DialogType.RequestPositionsMulti
                Return "Request Positions Multi"
            Case Else
                Throw New InvalidOperationException
        End Select
    End Function

End Class
