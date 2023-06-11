' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FGroups
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
        Me.IdLabel = New System.Windows.Forms.Label()
        Me.textId = New System.Windows.Forms.TextBox()
        Me.QueryDisplayGroupsButton = New System.Windows.Forms.Button()
        Me.comboDisplayGroups = New System.Windows.Forms.ComboBox()
        Me.DisplayGroupsLabel = New System.Windows.Forms.Label()
        Me.SubscribeToGroupEventsButton = New System.Windows.Forms.Button()
        Me.UnsubscribeFromGroupEventsButton = New System.Windows.Forms.Button()
        Me.UpdateDisplayGroupButton = New System.Windows.Forms.Button()
        Me.ContractInfoLabel = New System.Windows.Forms.Label()
        Me.textContractInfo = New System.Windows.Forms.TextBox()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.GroupMessagesText = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'IdLabel
        '
        Me.IdLabel.AutoSize = True
        Me.IdLabel.Location = New System.Drawing.Point(12, 7)
        Me.IdLabel.Name = "IdLabel"
        Me.IdLabel.Size = New System.Drawing.Size(16, 13)
        Me.IdLabel.TabIndex = 0
        Me.IdLabel.Text = "Id"
        '
        'textId
        '
        Me.textId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textId.Location = New System.Drawing.Point(42, 7)
        Me.textId.Name = "textId"
        Me.textId.Size = New System.Drawing.Size(73, 13)
        Me.textId.TabIndex = 1
        Me.textId.Text = "0"
        '
        'QueryDisplayGroupsButton
        '
        Me.QueryDisplayGroupsButton.Location = New System.Drawing.Point(12, 36)
        Me.QueryDisplayGroupsButton.Name = "QueryDisplayGroupsButton"
        Me.QueryDisplayGroupsButton.Size = New System.Drawing.Size(173, 23)
        Me.QueryDisplayGroupsButton.TabIndex = 2
        Me.QueryDisplayGroupsButton.Text = "Query Display Groups"
        Me.QueryDisplayGroupsButton.UseVisualStyleBackColor = True
        '
        'comboDisplayGroups
        '
        Me.comboDisplayGroups.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboDisplayGroups.FormattingEnabled = True
        Me.comboDisplayGroups.Location = New System.Drawing.Point(202, 65)
        Me.comboDisplayGroups.Name = "comboDisplayGroups"
        Me.comboDisplayGroups.Size = New System.Drawing.Size(174, 21)
        Me.comboDisplayGroups.TabIndex = 3
        '
        'DisplayGroupsLabel
        '
        Me.DisplayGroupsLabel.AutoSize = True
        Me.DisplayGroupsLabel.Location = New System.Drawing.Point(12, 68)
        Me.DisplayGroupsLabel.Name = "DisplayGroupsLabel"
        Me.DisplayGroupsLabel.Size = New System.Drawing.Size(78, 13)
        Me.DisplayGroupsLabel.TabIndex = 4
        Me.DisplayGroupsLabel.Text = "Display Groups"
        '
        'SubscribeToGroupEventsButton
        '
        Me.SubscribeToGroupEventsButton.Location = New System.Drawing.Point(12, 93)
        Me.SubscribeToGroupEventsButton.Name = "SubscribeToGroupEventsButton"
        Me.SubscribeToGroupEventsButton.Size = New System.Drawing.Size(174, 21)
        Me.SubscribeToGroupEventsButton.TabIndex = 5
        Me.SubscribeToGroupEventsButton.Text = "Subscribe To Group Events"
        Me.SubscribeToGroupEventsButton.UseVisualStyleBackColor = True
        '
        'UnsubscribeFromGroupEventsButton
        '
        Me.UnsubscribeFromGroupEventsButton.Location = New System.Drawing.Point(202, 93)
        Me.UnsubscribeFromGroupEventsButton.Name = "UnsubscribeFromGroupEventsButton"
        Me.UnsubscribeFromGroupEventsButton.Size = New System.Drawing.Size(174, 21)
        Me.UnsubscribeFromGroupEventsButton.TabIndex = 6
        Me.UnsubscribeFromGroupEventsButton.Text = "Unsubscribe From Group Events"
        Me.UnsubscribeFromGroupEventsButton.UseVisualStyleBackColor = True
        '
        'UpdateDisplayGroupButton
        '
        Me.UpdateDisplayGroupButton.Location = New System.Drawing.Point(12, 126)
        Me.UpdateDisplayGroupButton.Name = "UpdateDisplayGroupButton"
        Me.UpdateDisplayGroupButton.Size = New System.Drawing.Size(174, 21)
        Me.UpdateDisplayGroupButton.TabIndex = 7
        Me.UpdateDisplayGroupButton.Text = "Update Display Group"
        Me.UpdateDisplayGroupButton.UseVisualStyleBackColor = True
        '
        'ContractInfoLabel
        '
        Me.ContractInfoLabel.AutoSize = True
        Me.ContractInfoLabel.Location = New System.Drawing.Point(14, 160)
        Me.ContractInfoLabel.Name = "ContractInfoLabel"
        Me.ContractInfoLabel.Size = New System.Drawing.Size(68, 13)
        Me.ContractInfoLabel.TabIndex = 8
        Me.ContractInfoLabel.Text = "Contract Info"
        '
        'textContractInfo
        '
        Me.textContractInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textContractInfo.Location = New System.Drawing.Point(205, 150)
        Me.textContractInfo.Name = "textContractInfo"
        Me.textContractInfo.Size = New System.Drawing.Size(170, 13)
        Me.textContractInfo.TabIndex = 9
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(111, 391)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(81, 21)
        Me.ResetButton.TabIndex = 11
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(208, 391)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(81, 21)
        Me.CloseButton.TabIndex = 12
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'GroupMessagesText
        '
        Me.GroupMessagesText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GroupMessagesText.Location = New System.Drawing.Point(19, 176)
        Me.GroupMessagesText.Multiline = True
        Me.GroupMessagesText.Name = "GroupMessagesText"
        Me.GroupMessagesText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GroupMessagesText.Size = New System.Drawing.Size(354, 209)
        Me.GroupMessagesText.TabIndex = 13
        '
        'FGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(388, 421)
        Me.Controls.Add(Me.GroupMessagesText)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.textContractInfo)
        Me.Controls.Add(Me.ContractInfoLabel)
        Me.Controls.Add(Me.UpdateDisplayGroupButton)
        Me.Controls.Add(Me.UnsubscribeFromGroupEventsButton)
        Me.Controls.Add(Me.SubscribeToGroupEventsButton)
        Me.Controls.Add(Me.DisplayGroupsLabel)
        Me.Controls.Add(Me.comboDisplayGroups)
        Me.Controls.Add(Me.QueryDisplayGroupsButton)
        Me.Controls.Add(Me.textId)
        Me.Controls.Add(Me.IdLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FGroups"
        Me.ShowIcon = False
        Me.Text = "Display Groups"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IdLabel As System.Windows.Forms.Label
    Friend WithEvents textId As System.Windows.Forms.TextBox
    Friend WithEvents QueryDisplayGroupsButton As System.Windows.Forms.Button
    Friend WithEvents comboDisplayGroups As System.Windows.Forms.ComboBox
    Friend WithEvents DisplayGroupsLabel As System.Windows.Forms.Label
    Friend WithEvents SubscribeToGroupEventsButton As System.Windows.Forms.Button
    Friend WithEvents UnsubscribeFromGroupEventsButton As System.Windows.Forms.Button
    Friend WithEvents UpdateDisplayGroupButton As System.Windows.Forms.Button
    Friend WithEvents ContractInfoLabel As System.Windows.Forms.Label
    Friend WithEvents textContractInfo As System.Windows.Forms.TextBox
    Friend WithEvents ResetButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents GroupMessagesText As TextBox
End Class
