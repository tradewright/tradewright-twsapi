' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FOptions
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.frmParameters = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.AddParamButton = New System.Windows.Forms.Button()
        Me.RemoveParamButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ValueText = New System.Windows.Forms.TextBox()
        Me.ParamLabel = New System.Windows.Forms.Label()
        Me.ValueLabel = New System.Windows.Forms.Label()
        Me.ParamText = New System.Windows.Forms.TextBox()
        Me.ParamsGrid = New System.Windows.Forms.ListView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.frmParameters.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OkButton, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CancelItButton, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(121, 338)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OkButton
        '
        Me.OkButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkButton.Location = New System.Drawing.Point(3, 3)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(67, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "OK"
        '
        'CancelItButton
        '
        Me.CancelItButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CancelItButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelItButton.Location = New System.Drawing.Point(76, 3)
        Me.CancelItButton.Name = "CancelItButton"
        Me.CancelItButton.Size = New System.Drawing.Size(67, 23)
        Me.CancelItButton.TabIndex = 1
        Me.CancelItButton.Text = "Cancel"
        '
        'frmParameters
        '
        Me.frmParameters.Controls.Add(Me.TableLayoutPanel3)
        Me.frmParameters.Controls.Add(Me.TableLayoutPanel2)
        Me.frmParameters.Controls.Add(Me.ParamsGrid)
        Me.frmParameters.Location = New System.Drawing.Point(18, 12)
        Me.frmParameters.Name = "frmParameters"
        Me.frmParameters.Size = New System.Drawing.Size(249, 327)
        Me.frmParameters.TabIndex = 2
        Me.frmParameters.TabStop = False
        Me.frmParameters.Text = "Parameters"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.AddParamButton, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RemoveParamButton, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(86, 289)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'AddParamButton
        '
        Me.AddParamButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AddParamButton.Location = New System.Drawing.Point(3, 3)
        Me.AddParamButton.Name = "AddParamButton"
        Me.AddParamButton.Size = New System.Drawing.Size(67, 23)
        Me.AddParamButton.TabIndex = 0
        Me.AddParamButton.Text = "Add"
        '
        'RemoveParamButton
        '
        Me.RemoveParamButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RemoveParamButton.Location = New System.Drawing.Point(76, 3)
        Me.RemoveParamButton.Name = "RemoveParamButton"
        Me.RemoveParamButton.Size = New System.Drawing.Size(67, 23)
        Me.RemoveParamButton.TabIndex = 1
        Me.RemoveParamButton.Text = "Remove"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0777!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.9223!))
        Me.TableLayoutPanel2.Controls.Add(Me.ValueText, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ParamLabel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ValueLabel, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ParamText, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 215)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.9925!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0075!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(226, 68)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'ValueText
        '
        Me.ValueText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ValueText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ValueText.Location = New System.Drawing.Point(63, 44)
        Me.ValueText.Name = "ValueText"
        Me.ValueText.Size = New System.Drawing.Size(156, 13)
        Me.ValueText.TabIndex = 1
        '
        'ParamLabel
        '
        Me.ParamLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ParamLabel.AutoSize = True
        Me.ParamLabel.Location = New System.Drawing.Point(8, 10)
        Me.ParamLabel.Name = "ParamLabel"
        Me.ParamLabel.Size = New System.Drawing.Size(40, 13)
        Me.ParamLabel.TabIndex = 3
        Me.ParamLabel.Text = "Param:"
        '
        'ValueLabel
        '
        Me.ValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.Location = New System.Drawing.Point(9, 44)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(37, 13)
        Me.ValueLabel.TabIndex = 4
        Me.ValueLabel.Text = "Value:"
        '
        'ParamText
        '
        Me.ParamText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ParamText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ParamText.Location = New System.Drawing.Point(64, 10)
        Me.ParamText.Name = "ParamText"
        Me.ParamText.Size = New System.Drawing.Size(154, 13)
        Me.ParamText.TabIndex = 0
        '
        'ParamsGrid
        '
        Me.ParamsGrid.AutoArrange = False
        Me.ParamsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ParamsGrid.FullRowSelect = True
        Me.ParamsGrid.HideSelection = False
        Me.ParamsGrid.Location = New System.Drawing.Point(6, 19)
        Me.ParamsGrid.Name = "ParamsGrid"
        Me.ParamsGrid.Size = New System.Drawing.Size(226, 190)
        Me.ParamsGrid.TabIndex = 0
        Me.ParamsGrid.UseCompatibleStateImageBehavior = False
        Me.ParamsGrid.View = System.Windows.Forms.View.Details
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        '
        'fSmartComboRoutingParams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(284, 379)
        Me.Controls.Add(Me.frmParameters)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fSmartComboRoutingParams"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Smart Combo Routing Parameters"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.frmParameters.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CancelItButton As System.Windows.Forms.Button
    Friend WithEvents frmParameters As System.Windows.Forms.GroupBox
    Friend WithEvents ParamsGrid As ListView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ValueText As System.Windows.Forms.TextBox
    Friend WithEvents ParamLabel As System.Windows.Forms.Label
    Friend WithEvents ValueLabel As System.Windows.Forms.Label
    Friend WithEvents ParamText As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AddParamButton As System.Windows.Forms.Button
    Friend WithEvents RemoveParamButton As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
