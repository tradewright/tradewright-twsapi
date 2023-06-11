' Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FWsh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        OkButton = New Button()
        Cancel_Button = New Button()
        ReqIdLabel = New Label()
        ReqIdText = New TextBox()
        ConIdText = New TextBox()
        ConIdLabel = New Label()
        FilterLabel = New Label()
        FilterText = New TextBox()
        FillWatchlistCheck = New CheckBox()
        FillPortfolioCheck = New CheckBox()
        FillCompetitorsCHeck = New CheckBox()
        StartDateText = New TextBox()
        StartDateLabel = New Label()
        EndDateText = New TextBox()
        EndDateLabel = New Label()
        TotalLimitText = New TextBox()
        TotalLimitLabel = New Label()
        SuspendLayout()
        ' 
        ' OkButton
        ' 
        OkButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        OkButton.Location = New Point(36, 331)
        OkButton.Margin = New Padding(4, 3, 4, 3)
        OkButton.Name = "OkButton"
        OkButton.Size = New Size(88, 27)
        OkButton.TabIndex = 0
        OkButton.Text = "OK"
        OkButton.UseVisualStyleBackColor = True
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Cancel_Button.Location = New Point(131, 331)
        Cancel_Button.Margin = New Padding(4, 3, 4, 3)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(88, 27)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        Cancel_Button.UseVisualStyleBackColor = True
        ' 
        ' ReqIdLabel
        ' 
        ReqIdLabel.AutoSize = True
        ReqIdLabel.Location = New Point(15, 15)
        ReqIdLabel.Margin = New Padding(4, 0, 4, 0)
        ReqIdLabel.Name = "ReqIdLabel"
        ReqIdLabel.Size = New Size(62, 15)
        ReqIdLabel.TabIndex = 2
        ReqIdLabel.Text = "Request Id"
        ' 
        ' ReqIdText
        ' 
        ReqIdText.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ReqIdText.Location = New Point(102, 7)
        ReqIdText.Margin = New Padding(4, 3, 4, 3)
        ReqIdText.Name = "ReqIdText"
        ReqIdText.Size = New Size(116, 23)
        ReqIdText.TabIndex = 4
        ' 
        ' ConIdText
        ' 
        ConIdText.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ConIdText.Location = New Point(102, 37)
        ConIdText.Margin = New Padding(4, 3, 4, 3)
        ConIdText.Name = "ConIdText"
        ConIdText.Size = New Size(116, 23)
        ConIdText.TabIndex = 6
        ' 
        ' ConIdLabel
        ' 
        ConIdLabel.AutoSize = True
        ConIdLabel.Location = New Point(15, 45)
        ConIdLabel.Margin = New Padding(4, 0, 4, 0)
        ConIdLabel.Name = "ConIdLabel"
        ConIdLabel.Size = New Size(66, 15)
        ConIdLabel.TabIndex = 5
        ConIdLabel.Text = "Contract Id"
        ' 
        ' FilterLabel
        ' 
        FilterLabel.AutoSize = True
        FilterLabel.Location = New Point(14, 75)
        FilterLabel.Margin = New Padding(4, 0, 4, 0)
        FilterLabel.Name = "FilterLabel"
        FilterLabel.Size = New Size(33, 15)
        FilterLabel.TabIndex = 7
        FilterLabel.Text = "Filter"
        ' 
        ' FilterText
        ' 
        FilterText.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        FilterText.Location = New Point(102, 67)
        FilterText.Margin = New Padding(4, 3, 4, 3)
        FilterText.Name = "FilterText"
        FilterText.Size = New Size(116, 23)
        FilterText.TabIndex = 8
        ' 
        ' FillWatchlistCheck
        ' 
        FillWatchlistCheck.AutoSize = True
        FillWatchlistCheck.Location = New Point(103, 97)
        FillWatchlistCheck.Margin = New Padding(4, 3, 4, 3)
        FillWatchlistCheck.Name = "FillWatchlistCheck"
        FillWatchlistCheck.Size = New Size(93, 19)
        FillWatchlistCheck.TabIndex = 9
        FillWatchlistCheck.Text = "Fill Watchlist"
        FillWatchlistCheck.UseVisualStyleBackColor = True
        ' 
        ' FillPortfolioCheck
        ' 
        FillPortfolioCheck.AutoSize = True
        FillPortfolioCheck.Location = New Point(102, 123)
        FillPortfolioCheck.Margin = New Padding(4, 3, 4, 3)
        FillPortfolioCheck.Name = "FillPortfolioCheck"
        FillPortfolioCheck.Size = New Size(90, 19)
        FillPortfolioCheck.TabIndex = 10
        FillPortfolioCheck.Text = "Fill Portfolio"
        FillPortfolioCheck.UseVisualStyleBackColor = True
        ' 
        ' FillCompetitorsCHeck
        ' 
        FillCompetitorsCHeck.AutoSize = True
        FillCompetitorsCHeck.Location = New Point(103, 150)
        FillCompetitorsCHeck.Margin = New Padding(4, 3, 4, 3)
        FillCompetitorsCHeck.Name = "FillCompetitorsCHeck"
        FillCompetitorsCHeck.Size = New Size(110, 19)
        FillCompetitorsCHeck.TabIndex = 11
        FillCompetitorsCHeck.Text = "Fill Competitors"
        FillCompetitorsCHeck.UseVisualStyleBackColor = True
        ' 
        ' StartDateText
        ' 
        StartDateText.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        StartDateText.Location = New Point(102, 174)
        StartDateText.Margin = New Padding(4, 3, 4, 3)
        StartDateText.Name = "StartDateText"
        StartDateText.Size = New Size(116, 23)
        StartDateText.TabIndex = 13
        ' 
        ' StartDateLabel
        ' 
        StartDateLabel.AutoSize = True
        StartDateLabel.Location = New Point(15, 182)
        StartDateLabel.Margin = New Padding(4, 0, 4, 0)
        StartDateLabel.Name = "StartDateLabel"
        StartDateLabel.Size = New Size(58, 15)
        StartDateLabel.TabIndex = 12
        StartDateLabel.Text = "Start Date"
        ' 
        ' EndDateText
        ' 
        EndDateText.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        EndDateText.Location = New Point(102, 204)
        EndDateText.Margin = New Padding(4, 3, 4, 3)
        EndDateText.Name = "EndDateText"
        EndDateText.Size = New Size(116, 23)
        EndDateText.TabIndex = 15
        ' 
        ' EndDateLabel
        ' 
        EndDateLabel.AutoSize = True
        EndDateLabel.Location = New Point(14, 212)
        EndDateLabel.Margin = New Padding(4, 0, 4, 0)
        EndDateLabel.Name = "EndDateLabel"
        EndDateLabel.Size = New Size(54, 15)
        EndDateLabel.TabIndex = 14
        EndDateLabel.Text = "End Date"
        ' 
        ' TotalLimitText
        ' 
        TotalLimitText.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TotalLimitText.Location = New Point(103, 234)
        TotalLimitText.Margin = New Padding(4, 3, 4, 3)
        TotalLimitText.Name = "TotalLimitText"
        TotalLimitText.Size = New Size(116, 23)
        TotalLimitText.TabIndex = 0
        ' 
        ' TotalLimitLabel
        ' 
        TotalLimitLabel.AutoSize = True
        TotalLimitLabel.Location = New Point(14, 242)
        TotalLimitLabel.Margin = New Padding(4, 0, 4, 0)
        TotalLimitLabel.Name = "TotalLimitLabel"
        TotalLimitLabel.Size = New Size(62, 15)
        TotalLimitLabel.TabIndex = 16
        TotalLimitLabel.Text = "Total Limit"
        ' 
        ' FWsh
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(232, 372)
        Controls.Add(TotalLimitText)
        Controls.Add(TotalLimitLabel)
        Controls.Add(EndDateText)
        Controls.Add(EndDateLabel)
        Controls.Add(StartDateText)
        Controls.Add(StartDateLabel)
        Controls.Add(FillCompetitorsCHeck)
        Controls.Add(FillPortfolioCheck)
        Controls.Add(FillWatchlistCheck)
        Controls.Add(FilterText)
        Controls.Add(FilterLabel)
        Controls.Add(ConIdText)
        Controls.Add(ConIdLabel)
        Controls.Add(ReqIdText)
        Controls.Add(ReqIdLabel)
        Controls.Add(Cancel_Button)
        Controls.Add(OkButton)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        Name = "FWsh"
        Text = "Req WSH"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ReqIdLabel As System.Windows.Forms.Label
    Friend WithEvents ReqIdText As System.Windows.Forms.TextBox
    Friend WithEvents ConIdText As System.Windows.Forms.TextBox
    Friend WithEvents ConIdLabel As System.Windows.Forms.Label
    Friend WithEvents FilterLabel As Label
    Friend WithEvents FilterText As TextBox
    Friend WithEvents FillWatchlistCheck As CheckBox
    Friend WithEvents FillPortfolioCheck As CheckBox
    Friend WithEvents FillCompetitorsCHeck As CheckBox
    Friend WithEvents StartDateText As TextBox
    Friend WithEvents StartDateLabel As Label
    Friend WithEvents EndDateText As TextBox
    Friend WithEvents EndDateLabel As Label
    Friend WithEvents TotalLimitText As TextBox
    Friend WithEvents TotalLimitLabel As Label
End Class
