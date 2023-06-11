' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAlgoParams
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
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.AlgorithmFrame = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.StrategyLabel = New System.Windows.Forms.Label()
        Me.StrategyText = New System.Windows.Forms.TextBox()
        Me.ParametersFrame = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.AddParamButton = New System.Windows.Forms.Button()
        Me.RemoveParamButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ValueText = New System.Windows.Forms.TextBox()
        Me.ParamLabel = New System.Windows.Forms.Label()
        Me.ValueLabel = New System.Windows.Forms.Label()
        Me.ParamText = New System.Windows.Forms.TextBox()
        Me.ParamsGrid = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.AlgorithmFrame.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.ParametersFrame.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(121, 425)
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
        'frmAlgorithm
        '
        Me.AlgorithmFrame.BackColor = System.Drawing.Color.Gainsboro
        Me.AlgorithmFrame.Controls.Add(Me.TableLayoutPanel4)
        Me.AlgorithmFrame.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.AlgorithmFrame.Location = New System.Drawing.Point(16, 7)
        Me.AlgorithmFrame.Name = "frmAlgorithm"
        Me.AlgorithmFrame.Size = New System.Drawing.Size(251, 74)
        Me.AlgorithmFrame.TabIndex = 1
        Me.AlgorithmFrame.TabStop = False
        Me.AlgorithmFrame.Text = "Algorithm"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.08!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.92!))
        Me.TableLayoutPanel4.Controls.Add(Me.StrategyLabel, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.StrategyText, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(13, 19)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(226, 39)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'StrategyLabel
        '
        Me.StrategyLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StrategyLabel.AutoSize = True
        Me.StrategyLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StrategyLabel.Location = New System.Drawing.Point(3, 13)
        Me.StrategyLabel.Name = "StrategyLabel"
        Me.StrategyLabel.Size = New System.Drawing.Size(49, 13)
        Me.StrategyLabel.TabIndex = 3
        Me.StrategyLabel.Text = "Strategy:"
        '
        'StrategyText
        '
        Me.StrategyText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StrategyText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StrategyText.Location = New System.Drawing.Point(64, 13)
        Me.StrategyText.Name = "StrategyText"
        Me.StrategyText.Size = New System.Drawing.Size(154, 13)
        Me.StrategyText.TabIndex = 0
        '
        'frmParameters
        '
        Me.ParametersFrame.Controls.Add(Me.TableLayoutPanel3)
        Me.ParametersFrame.Controls.Add(Me.TableLayoutPanel2)
        Me.ParametersFrame.Controls.Add(Me.ParamsGrid)
        Me.ParametersFrame.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ParametersFrame.Location = New System.Drawing.Point(18, 87)
        Me.ParametersFrame.Name = "frmParameters"
        Me.ParametersFrame.Size = New System.Drawing.Size(249, 331)
        Me.ParametersFrame.TabIndex = 2
        Me.ParametersFrame.TabStop = False
        Me.ParametersFrame.Text = "Parameters"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.AddParamButton, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RemoveParamButton, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(91, 293)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'AddParamButton
        '
        Me.AddParamButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AddParamButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AddParamButton.Location = New System.Drawing.Point(3, 3)
        Me.AddParamButton.Name = "AddParamButton"
        Me.AddParamButton.Size = New System.Drawing.Size(67, 23)
        Me.AddParamButton.TabIndex = 0
        Me.AddParamButton.Text = "Add"
        '
        'RemoveParamButton
        '
        Me.RemoveParamButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RemoveParamButton.ForeColor = System.Drawing.SystemColors.ControlText
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(11, 215)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.9925!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0075!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(226, 72)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'ValueText
        '
        Me.ValueText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ValueText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ValueText.Location = New System.Drawing.Point(63, 47)
        Me.ValueText.Name = "ValueText"
        Me.ValueText.Size = New System.Drawing.Size(156, 13)
        Me.ValueText.TabIndex = 1
        '
        'ParamLabel
        '
        Me.ParamLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ParamLabel.AutoSize = True
        Me.ParamLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ParamLabel.Location = New System.Drawing.Point(8, 11)
        Me.ParamLabel.Name = "ParamLabel"
        Me.ParamLabel.Size = New System.Drawing.Size(40, 13)
        Me.ParamLabel.TabIndex = 3
        Me.ParamLabel.Text = "Param:"
        '
        'ValueLabel
        '
        Me.ValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ValueLabel.Location = New System.Drawing.Point(9, 47)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(37, 13)
        Me.ValueLabel.TabIndex = 4
        Me.ValueLabel.Text = "Value:"
        '
        'ParamText
        '
        Me.ParamText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ParamText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ParamText.Location = New System.Drawing.Point(64, 11)
        Me.ParamText.Name = "ParamText"
        Me.ParamText.Size = New System.Drawing.Size(154, 13)
        Me.ParamText.TabIndex = 0
        '
        'ParamsGrid
        '
        Me.ParamsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ParamsGrid.FullRowSelect = True
        Me.ParamsGrid.Location = New System.Drawing.Point(11, 19)
        Me.ParamsGrid.Name = "ParamsGrid"
        Me.ParamsGrid.Size = New System.Drawing.Size(226, 190)
        Me.ParamsGrid.TabIndex = 0
        Me.ParamsGrid.UseCompatibleStateImageBehavior = False
        Me.ParamsGrid.View = System.Windows.Forms.View.Details
        '
        'fAlgoParams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(284, 466)
        Me.Controls.Add(Me.ParametersFrame)
        Me.Controls.Add(Me.AlgorithmFrame)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fAlgoParams"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Algo Order Parameters"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.AlgorithmFrame.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ParametersFrame.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CancelItButton As System.Windows.Forms.Button
    Friend WithEvents AlgorithmFrame As System.Windows.Forms.GroupBox
    Friend WithEvents ParametersFrame As System.Windows.Forms.GroupBox
    Friend WithEvents ParamsGrid As ListView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ValueText As System.Windows.Forms.TextBox
    Friend WithEvents ParamLabel As System.Windows.Forms.Label
    Friend WithEvents ValueLabel As System.Windows.Forms.Label
    Friend WithEvents ParamText As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AddParamButton As System.Windows.Forms.Button
    Friend WithEvents RemoveParamButton As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents StrategyLabel As System.Windows.Forms.Label
    Friend WithEvents StrategyText As System.Windows.Forms.TextBox

End Class
