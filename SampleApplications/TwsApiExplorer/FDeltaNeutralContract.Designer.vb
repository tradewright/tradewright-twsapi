' Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FDeltaNeutralContract
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PriceText = New System.Windows.Forms.TextBox()
        Me.DeltaText = New System.Windows.Forms.TextBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConIdText = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.TableLayoutPanel1.Controls.Add(Me.PriceText, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DeltaText, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.OkButton, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CancelItButton, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ResetButton, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ConIdText, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(293, 115)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PriceText
        '
        Me.PriceText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PriceText.Location = New System.Drawing.Point(100, 89)
        Me.PriceText.Name = "PriceText"
        Me.PriceText.Size = New System.Drawing.Size(91, 13)
        Me.PriceText.TabIndex = 2
        '
        'DeltaText
        '
        Me.DeltaText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DeltaText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DeltaText.Location = New System.Drawing.Point(100, 50)
        Me.DeltaText.Name = "DeltaText"
        Me.DeltaText.Size = New System.Drawing.Size(91, 13)
        Me.DeltaText.TabIndex = 1
        '
        'OkButton
        '
        Me.OkButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OkButton.Location = New System.Drawing.Point(210, 7)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(67, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "OK"
        '
        'CancelButton
        '
        Me.CancelItButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CancelItButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelItButton.Location = New System.Drawing.Point(210, 84)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.Size = New System.Drawing.Size(67, 23)
        Me.CancelItButton.TabIndex = 2
        Me.CancelItButton.Text = "Cancel"
        '
        'ResetButton
        '
        Me.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ResetButton.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.ResetButton.Location = New System.Drawing.Point(210, 45)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(67, 23)
        Me.ResetButton.TabIndex = 1
        Me.ResetButton.Text = "Reset"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Contract Id"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Delta"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Price"
        '
        'ConIdText
        '
        Me.ConIdText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ConIdText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ConIdText.Location = New System.Drawing.Point(100, 12)
        Me.ConIdText.Name = "ConIdText"
        Me.ConIdText.Size = New System.Drawing.Size(91, 13)
        Me.ConIdText.TabIndex = 0
        '
        'fDeltaNeutralContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(317, 139)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fDeltaNeutralContract"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "fDeltaNeutralContract"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CancelItButton As System.Windows.Forms.Button
    Friend WithEvents ResetButton As System.Windows.Forms.Button
    Friend WithEvents PriceText As System.Windows.Forms.TextBox
    Friend WithEvents DeltaText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ConIdText As System.Windows.Forms.TextBox

End Class
