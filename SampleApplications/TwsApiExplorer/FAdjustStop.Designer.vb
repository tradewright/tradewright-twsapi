<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAdjustStop
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.AdjustedTrailingAmntUnitCombo = New System.Windows.Forms.ComboBox()
        Me.AdjustedTrailingAmntText = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.AdjustedStopLimitPriceText = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.AdjustedStopPriceText = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TriggerPriceText = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AdjustedOrderTypeCombo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 146)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(139, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Adjusted trailing amount unit"
        '
        'AdjustedTrailingAmntUnitCheck
        '
        Me.AdjustedTrailingAmntUnitCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdjustedTrailingAmntUnitCombo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AdjustedTrailingAmntUnitCombo.FormattingEnabled = True
        Me.AdjustedTrailingAmntUnitCombo.Items.AddRange(New Object() {"amonunt", "%"})
        Me.AdjustedTrailingAmntUnitCombo.Location = New System.Drawing.Point(162, 143)
        Me.AdjustedTrailingAmntUnitCombo.Name = "AdjustedTrailingAmntUnitCheck"
        Me.AdjustedTrailingAmntUnitCombo.Size = New System.Drawing.Size(121, 21)
        Me.AdjustedTrailingAmntUnitCombo.TabIndex = 23
        '
        'AdjustedTrailingAmntText
        '
        Me.AdjustedTrailingAmntText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AdjustedTrailingAmntText.Location = New System.Drawing.Point(162, 117)
        Me.AdjustedTrailingAmntText.Name = "AdjustedTrailingAmntText"
        Me.AdjustedTrailingAmntText.Size = New System.Drawing.Size(121, 13)
        Me.AdjustedTrailingAmntText.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(119, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Adjusted trailing amount"
        '
        'AdjustedStopLimitPriceText
        '
        Me.AdjustedStopLimitPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AdjustedStopLimitPriceText.Location = New System.Drawing.Point(162, 91)
        Me.AdjustedStopLimitPriceText.Name = "AdjustedStopLimitPriceText"
        Me.AdjustedStopLimitPriceText.Size = New System.Drawing.Size(121, 13)
        Me.AdjustedStopLimitPriceText.TabIndex = 20
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Adusted stop limit price"
        '
        'AdjustedStopPriceText
        '
        Me.AdjustedStopPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AdjustedStopPriceText.Location = New System.Drawing.Point(162, 65)
        Me.AdjustedStopPriceText.Name = "AdjustedStopPriceText"
        Me.AdjustedStopPriceText.Size = New System.Drawing.Size(121, 13)
        Me.AdjustedStopPriceText.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Adjusted stop price"
        '
        'TriggerPriceText
        '
        Me.TriggerPriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TriggerPriceText.Location = New System.Drawing.Point(162, 39)
        Me.TriggerPriceText.Name = "TriggerPriceText"
        Me.TriggerPriceText.Size = New System.Drawing.Size(121, 13)
        Me.TriggerPriceText.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Adjust to order type"
        '
        'AdjustedOrderTypeCheck
        '
        Me.AdjustedOrderTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdjustedOrderTypeCombo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AdjustedOrderTypeCombo.FormattingEnabled = True
        Me.AdjustedOrderTypeCombo.Items.AddRange(New Object() {"", "STP", "STP LMT", "TRAIL", "TRAIL LIMIT"})
        Me.AdjustedOrderTypeCombo.Location = New System.Drawing.Point(162, 12)
        Me.AdjustedOrderTypeCombo.Name = "AdjustedOrderTypeCheck"
        Me.AdjustedOrderTypeCombo.Size = New System.Drawing.Size(121, 21)
        Me.AdjustedOrderTypeCombo.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Trigger price"
        '
        'CancelButton
        '
        Me.CancelItButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelItButton.Location = New System.Drawing.Point(208, 176)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelItButton.TabIndex = 28
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(127, 176)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 27
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'fAdjustStop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(295, 211)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.AdjustedTrailingAmntUnitCombo)
        Me.Controls.Add(Me.AdjustedTrailingAmntText)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.AdjustedStopLimitPriceText)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.AdjustedStopPriceText)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TriggerPriceText)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.AdjustedOrderTypeCombo)
        Me.Controls.Add(Me.Label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fAdjustStop"
        Me.Text = "Adjustable stops"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents AdjustedTrailingAmntUnitCombo As System.Windows.Forms.ComboBox
    Private WithEvents AdjustedTrailingAmntText As System.Windows.Forms.TextBox
    Private WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents AdjustedStopLimitPriceText As System.Windows.Forms.TextBox
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents AdjustedStopPriceText As System.Windows.Forms.TextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents TriggerPriceText As System.Windows.Forms.TextBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents AdjustedOrderTypeCombo As System.Windows.Forms.ComboBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CancelItButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
