<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPegBench
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PeggedChangeTypeCheck = New System.Windows.Forms.ComboBox()
        Me.ReferenceChangeAmountText = New System.Windows.Forms.TextBox()
        Me.PeggedChangeAmountText = New System.Windows.Forms.TextBox()
        Me.StartingReferencePriceText = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StartingPriceText = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.ReferenceContractIdText = New System.Windows.Forms.TextBox()
        Me.ReferenceContractExchangeText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PeggedChangeTypeCheck
        '
        Me.PeggedChangeTypeCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PeggedChangeTypeCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PeggedChangeTypeCheck.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PeggedChangeTypeCheck.FormattingEnabled = True
        Me.PeggedChangeTypeCheck.Items.AddRange(New Object() {"Increase", "Decrease"})
        Me.PeggedChangeTypeCheck.Location = New System.Drawing.Point(167, 137)
        Me.PeggedChangeTypeCheck.Name = "PeggedChangeTypeCheck"
        Me.PeggedChangeTypeCheck.Size = New System.Drawing.Size(195, 21)
        Me.PeggedChangeTypeCheck.TabIndex = 21
        '
        'ReferenceChangeAmountText
        '
        Me.ReferenceChangeAmountText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReferenceChangeAmountText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReferenceChangeAmountText.Location = New System.Drawing.Point(167, 163)
        Me.ReferenceChangeAmountText.Name = "ReferenceChangeAmountText"
        Me.ReferenceChangeAmountText.Size = New System.Drawing.Size(195, 13)
        Me.ReferenceChangeAmountText.TabIndex = 20
        '
        'PeggedChangeAmountText
        '
        Me.PeggedChangeAmountText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PeggedChangeAmountText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PeggedChangeAmountText.Location = New System.Drawing.Point(167, 111)
        Me.PeggedChangeAmountText.Name = "PeggedChangeAmountText"
        Me.PeggedChangeAmountText.Size = New System.Drawing.Size(195, 13)
        Me.PeggedChangeAmountText.TabIndex = 19
        '
        'StartingReferencePriceText
        '
        Me.StartingReferencePriceText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartingReferencePriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StartingReferencePriceText.Location = New System.Drawing.Point(167, 85)
        Me.StartingReferencePriceText.Name = "StartingReferencePriceText"
        Me.StartingReferencePriceText.Size = New System.Drawing.Size(195, 13)
        Me.StartingReferencePriceText.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 166)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Reference change amount"
        '
        'Label9
        '
        Me.Label9.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Pegged change type"
        '
        'Label8
        '
        Me.Label8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Pegged change amount"
        '
        'Label7
        '
        Me.Label7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Starting reference price"
        '
        'Label6
        '
        Me.Label6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Reference contract id"
        '
        'StartingPriceText
        '
        Me.StartingPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StartingPriceText.Location = New System.Drawing.Point(167, 6)
        Me.StartingPriceText.Name = "StartingPriceText"
        Me.StartingPriceText.Size = New System.Drawing.Size(195, 13)
        Me.StartingPriceText.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Starting price"
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(209, 202)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 22
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelItButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelItButton.Location = New System.Drawing.Point(290, 202)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelItButton.TabIndex = 23
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'ReferenceContractIdText
        '
        Me.ReferenceContractIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReferenceContractIdText.Location = New System.Drawing.Point(167, 32)
        Me.ReferenceContractIdText.Name = "ReferenceContractIdText"
        Me.ReferenceContractIdText.Size = New System.Drawing.Size(195, 13)
        Me.ReferenceContractIdText.TabIndex = 24
        '
        'ReferenceContractExchangeText
        '
        Me.ReferenceContractExchangeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReferenceContractExchangeText.Location = New System.Drawing.Point(167, 58)
        Me.ReferenceContractExchangeText.Name = "ReferenceContractExchangeText"
        Me.ReferenceContractExchangeText.Size = New System.Drawing.Size(195, 13)
        Me.ReferenceContractExchangeText.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Reference contract exchange"
        '
        'fPegBench
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(377, 237)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReferenceContractExchangeText)
        Me.Controls.Add(Me.ReferenceContractIdText)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.PeggedChangeTypeCheck)
        Me.Controls.Add(Me.ReferenceChangeAmountText)
        Me.Controls.Add(Me.PeggedChangeAmountText)
        Me.Controls.Add(Me.StartingReferencePriceText)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.StartingPriceText)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fPegBench"
        Me.Text = "fPegBench"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents PeggedChangeTypeCheck As System.Windows.Forms.ComboBox
    Private WithEvents ReferenceChangeAmountText As System.Windows.Forms.TextBox
    Private WithEvents PeggedChangeAmountText As System.Windows.Forms.TextBox
    Private WithEvents StartingReferencePriceText As System.Windows.Forms.TextBox
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents StartingPriceText As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CancelItButton As System.Windows.Forms.Button
    Friend WithEvents ReferenceContractIdText As System.Windows.Forms.TextBox
    Friend WithEvents ReferenceContractExchangeText As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
End Class
