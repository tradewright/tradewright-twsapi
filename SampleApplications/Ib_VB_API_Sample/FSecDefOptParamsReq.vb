' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Friend Class FSecDefOptParamsReq
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        initializeComponent()

        ConIdText.Text = mConId
        ReqIdText.Text = mReqId
        ExchangeText.Text = mExchange
        SecTypeText.Text = mSecType
        SymbolText.Text = mSymbol
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
    Public WithEvents ConIdText As System.Windows.Forms.TextBox
    Public WithEvents SymbolText As System.Windows.Forms.TextBox
    Public WithEvents SecTypeText As System.Windows.Forms.TextBox
    Public WithEvents ExchangeText As System.Windows.Forms.TextBox
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents SymbolLabel As System.Windows.Forms.Label
    Public WithEvents SecTypeLabel As System.Windows.Forms.Label
    Public WithEvents ExchangeLabel As System.Windows.Forms.Label
    Public WithEvents ReqIdText As System.Windows.Forms.TextBox
    Public WithEvents ReqIdLabel As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.ConIdText = New System.Windows.Forms.TextBox()
        Me.SymbolText = New System.Windows.Forms.TextBox()
        Me.SecTypeText = New System.Windows.Forms.TextBox()
        Me.ExchangeText = New System.Windows.Forms.TextBox()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.SymbolLabel = New System.Windows.Forms.Label()
        Me.SecTypeLabel = New System.Windows.Forms.Label()
        Me.ExchangeLabel = New System.Windows.Forms.Label()
        Me.ReqIdText = New System.Windows.Forms.TextBox()
        Me.ReqIdLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ConIdText
        '
        Me.ConIdText.AcceptsReturn = True
        Me.ConIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ConIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ConIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ConIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ConIdText.Location = New System.Drawing.Point(119, 114)
        Me.ConIdText.MaxLength = 0
        Me.ConIdText.Name = "ConIdText"
        Me.ConIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ConIdText.Size = New System.Drawing.Size(161, 13)
        Me.ConIdText.TabIndex = 6
        '
        'SymbolText
        '
        Me.SymbolText.AcceptsReturn = True
        Me.SymbolText.BackColor = System.Drawing.SystemColors.Window
        Me.SymbolText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SymbolText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SymbolText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SymbolText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SymbolText.Location = New System.Drawing.Point(119, 38)
        Me.SymbolText.MaxLength = 0
        Me.SymbolText.Name = "SymbolText"
        Me.SymbolText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SymbolText.Size = New System.Drawing.Size(161, 13)
        Me.SymbolText.TabIndex = 2
        '
        'SecTypeText
        '
        Me.SecTypeText.AcceptsReturn = True
        Me.SecTypeText.BackColor = System.Drawing.SystemColors.Window
        Me.SecTypeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SecTypeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SecTypeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecTypeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SecTypeText.Location = New System.Drawing.Point(119, 63)
        Me.SecTypeText.MaxLength = 0
        Me.SecTypeText.Name = "SecTypeText"
        Me.SecTypeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SecTypeText.Size = New System.Drawing.Size(161, 13)
        Me.SecTypeText.TabIndex = 3
        '
        'ExchangeText
        '
        Me.ExchangeText.AcceptsReturn = True
        Me.ExchangeText.BackColor = System.Drawing.SystemColors.Window
        Me.ExchangeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExchangeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExchangeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExchangeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExchangeText.Location = New System.Drawing.Point(119, 88)
        Me.ExchangeText.MaxLength = 0
        Me.ExchangeText.Name = "ExchangeText"
        Me.ExchangeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExchangeText.Size = New System.Drawing.Size(161, 13)
        Me.ExchangeText.TabIndex = 4
        '
        'CancelButton
        '
        Me.CancelItButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(207, 148)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(73, 25)
        Me.CancelItButton.TabIndex = 8
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.BackColor = System.Drawing.SystemColors.Control
        Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OkButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OkButton.Location = New System.Drawing.Point(128, 148)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 7
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'SymbolLabel
        '
        Me.SymbolLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.SymbolLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.SymbolLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SymbolLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SymbolLabel.Location = New System.Drawing.Point(15, 41)
        Me.SymbolLabel.Name = "SymbolLabel"
        Me.SymbolLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SymbolLabel.Size = New System.Drawing.Size(65, 17)
        Me.SymbolLabel.TabIndex = 11
        Me.SymbolLabel.Text = "Symbol"
        '
        'SecTypeLabel
        '
        Me.SecTypeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.SecTypeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.SecTypeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SecTypeLabel.Location = New System.Drawing.Point(15, 66)
        Me.SecTypeLabel.Name = "SecTypeLabel"
        Me.SecTypeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SecTypeLabel.Size = New System.Drawing.Size(65, 17)
        Me.SecTypeLabel.TabIndex = 10
        Me.SecTypeLabel.Text = "SecType"
        '
        'ExchangeLabel
        '
        Me.ExchangeLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ExchangeLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExchangeLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExchangeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExchangeLabel.Location = New System.Drawing.Point(15, 91)
        Me.ExchangeLabel.Name = "ExchangeLabel"
        Me.ExchangeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExchangeLabel.Size = New System.Drawing.Size(73, 17)
        Me.ExchangeLabel.TabIndex = 9
        Me.ExchangeLabel.Text = "Exchange"
        '
        'ReqIdText
        '
        Me.ReqIdText.AcceptsReturn = True
        Me.ReqIdText.BackColor = System.Drawing.SystemColors.Window
        Me.ReqIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReqIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReqIdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReqIdText.Location = New System.Drawing.Point(119, 12)
        Me.ReqIdText.MaxLength = 0
        Me.ReqIdText.Name = "ReqIdText"
        Me.ReqIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqIdText.Size = New System.Drawing.Size(161, 13)
        Me.ReqIdText.TabIndex = 1
        '
        'ReqIdLabel
        '
        Me.ReqIdLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ReqIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReqIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReqIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReqIdLabel.Location = New System.Drawing.Point(15, 15)
        Me.ReqIdLabel.Name = "ReqIdLabel"
        Me.ReqIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReqIdLabel.Size = New System.Drawing.Size(65, 17)
        Me.ReqIdLabel.TabIndex = 15
        Me.ReqIdLabel.Text = "Request Id"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "ConID"
        '
        'fSecDefOptParamsReq
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(292, 185)
        Me.Controls.Add(Me.ConIdText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReqIdLabel)
        Me.Controls.Add(Me.ReqIdText)
        Me.Controls.Add(Me.SymbolText)
        Me.Controls.Add(Me.SecTypeText)
        Me.Controls.Add(Me.ExchangeText)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.SymbolLabel)
        Me.Controls.Add(Me.SecTypeLabel)
        Me.Controls.Add(Me.ExchangeLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fSecDefOptParamsReq"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Security Definition Option Parameters Request"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    ' ========================================================
    ' Member variables
    ' ========================================================
    Private mSymbol As String
    Private mSecType As String
    Private mExchange As String
    Private mConId As String
    Private mReqId As Integer

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================

    Public ReadOnly Property ReqId As Integer
        Get
            Return mReqId
        End Get
    End Property

    Public ReadOnly Property SecType As String
        Get
            Return mSecType
        End Get
    End Property

    Public ReadOnly Property Symbol As String
        Get
            Return mSymbol
        End Get
    End Property

    Public ReadOnly Property Exchange As String
        Get
            Return mExchange
        End Get
    End Property

    Public ReadOnly Property ConId As Integer
        Get
            Return mConId
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        mReqId = Text2Int(ReqIdText.Text)
        mConId = text2IntMax(ConIdText.Text)
        mSymbol = SymbolText.Text
        mSecType = SecTypeText.Text
        mExchange = ExchangeText.Text
        DialogResult = DialogResult.OK

        Me.Hide()

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        Me.Hide()
    End Sub

    Private Sub fExecFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mReqId = 0
    End Sub

    Private Function text2IntMax(text As String) As Integer
        If Len(text) <= 0 Then
            Return Integer.MaxValue
        Else
            Return CInt(text)
        End If
    End Function

End Class
