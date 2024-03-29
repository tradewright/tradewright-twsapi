﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FConditions
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
        Me.ignoreRth = New System.Windows.Forms.CheckBox()
        Me.cancelOrder = New System.Windows.Forms.ComboBox()
        Me.conditionList = New System.Windows.Forms.DataGridView()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Logic = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lbAddCondition = New System.Windows.Forms.LinkLabel()
        Me.lbRemoveCondition = New System.Windows.Forms.LinkLabel()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        CType(Me.conditionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ignoreRth
        '
        Me.ignoreRth.AutoSize = True
        Me.ignoreRth.Location = New System.Drawing.Point(139, 238)
        Me.ignoreRth.Name = "ignoreRth"
        Me.ignoreRth.Size = New System.Drawing.Size(402, 17)
        Me.ignoreRth.TabIndex = 18
        Me.ignoreRth.Text = "Allow condition to be satisfied and activate order outside of regular trading hou" &
    "rs"
        Me.ignoreRth.UseVisualStyleBackColor = True
        '
        'cancelOrder
        '
        Me.cancelOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cancelOrder.FormattingEnabled = True
        Me.cancelOrder.Items.AddRange(New Object() {"Submit order", "Cancel order"})
        Me.cancelOrder.Location = New System.Drawing.Point(12, 234)
        Me.cancelOrder.Name = "cancelOrder"
        Me.cancelOrder.Size = New System.Drawing.Size(121, 21)
        Me.cancelOrder.TabIndex = 17
        '
        'conditionList
        '
        Me.conditionList.AllowUserToAddRows = False
        Me.conditionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.conditionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.conditionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Description, Me.Logic})
        Me.conditionList.Dock = System.Windows.Forms.DockStyle.Top
        Me.conditionList.Location = New System.Drawing.Point(0, 0)
        Me.conditionList.Name = "conditionList"
        Me.conditionList.Size = New System.Drawing.Size(670, 228)
        Me.conditionList.TabIndex = 16
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 85
        '
        'Logic
        '
        Me.Logic.HeaderText = "Logic"
        Me.Logic.Items.AddRange(New Object() {"and", "or"})
        Me.Logic.Name = "Logic"
        Me.Logic.Width = 39
        '
        'lbAddCondition
        '
        Me.lbAddCondition.AutoSize = True
        Me.lbAddCondition.Location = New System.Drawing.Point(585, 239)
        Me.lbAddCondition.Name = "lbAddCondition"
        Me.lbAddCondition.Size = New System.Drawing.Size(25, 13)
        Me.lbAddCondition.TabIndex = 14
        Me.lbAddCondition.TabStop = True
        Me.lbAddCondition.Text = "add"
        '
        'lbRemoveCondition
        '
        Me.lbRemoveCondition.AutoSize = True
        Me.lbRemoveCondition.Location = New System.Drawing.Point(616, 239)
        Me.lbRemoveCondition.Name = "lbRemoveCondition"
        Me.lbRemoveCondition.Size = New System.Drawing.Size(42, 13)
        Me.lbRemoveCondition.TabIndex = 15
        Me.lbRemoveCondition.TabStop = True
        Me.lbRemoveCondition.Text = "remove"
        '
        'CancelButton
        '
        Me.CancelItButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelItButton.Location = New System.Drawing.Point(583, 278)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelItButton.TabIndex = 25
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(502, 278)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 24
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'fConditions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(670, 313)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.ignoreRth)
        Me.Controls.Add(Me.cancelOrder)
        Me.Controls.Add(Me.conditionList)
        Me.Controls.Add(Me.lbAddCondition)
        Me.Controls.Add(Me.lbRemoveCondition)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fConditions"
        Me.Text = "fConditions"
        CType(Me.conditionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ignoreRth As System.Windows.Forms.CheckBox
    Private WithEvents cancelOrder As System.Windows.Forms.ComboBox
    Private WithEvents conditionList As System.Windows.Forms.DataGridView
    Private WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Logic As System.Windows.Forms.DataGridViewComboBoxColumn
    Private WithEvents lbAddCondition As System.Windows.Forms.LinkLabel
    Private WithEvents lbRemoveCondition As System.Windows.Forms.LinkLabel
    Friend WithEvents CancelItButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
