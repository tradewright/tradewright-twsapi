' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.



Imports TradeWright.IBAPI

Friend Class FAcctData
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents LastUpdateTimeText As System.Windows.Forms.TextBox
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents KeyValueDataText As TextBox
    Friend WithEvents PortfolioDataText As TextBox
    Public WithEvents UnsubscribeButton As Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LastUpdateTimeText = New System.Windows.Forms.TextBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.PortfolioDataText = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.KeyValueDataText = New System.Windows.Forms.TextBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UnsubscribeButton = New System.Windows.Forms.Button()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LastUpdateTimeText
        '
        Me.LastUpdateTimeText.AcceptsReturn = True
        Me.LastUpdateTimeText.BackColor = System.Drawing.SystemColors.Window
        Me.LastUpdateTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LastUpdateTimeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LastUpdateTimeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastUpdateTimeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LastUpdateTimeText.Location = New System.Drawing.Point(104, 352)
        Me.LastUpdateTimeText.MaxLength = 0
        Me.LastUpdateTimeText.Name = "LastUpdateTimeText"
        Me.LastUpdateTimeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LastUpdateTimeText.Size = New System.Drawing.Size(89, 13)
        Me.LastUpdateTimeText.TabIndex = 6
        Me.LastUpdateTimeText.Text = "00:00"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.PortfolioDataText)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 192)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(649, 137)
        Me.Frame2.TabIndex = 3
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Portfolio Data"
        '
        'PortfolioDataText
        '
        Me.PortfolioDataText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PortfolioDataText.Location = New System.Drawing.Point(7, 23)
        Me.PortfolioDataText.Multiline = True
        Me.PortfolioDataText.Name = "PortfolioDataText"
        Me.PortfolioDataText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PortfolioDataText.Size = New System.Drawing.Size(632, 104)
        Me.PortfolioDataText.TabIndex = 5
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.KeyValueDataText)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(649, 161)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Key, Value, and Currency"
        '
        'KeyValueDataText
        '
        Me.KeyValueDataText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.KeyValueDataText.Location = New System.Drawing.Point(7, 24)
        Me.KeyValueDataText.Multiline = True
        Me.KeyValueDataText.Name = "KeyValueDataText"
        Me.KeyValueDataText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.KeyValueDataText.Size = New System.Drawing.Size(633, 127)
        Me.KeyValueDataText.TabIndex = 3
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.SystemColors.Control
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CloseButton.Location = New System.Drawing.Point(566, 344)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CloseButton.Size = New System.Drawing.Size(81, 25)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 352)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Last update time :"
        '
        'UnsubscribeButton
        '
        Me.UnsubscribeButton.BackColor = System.Drawing.SystemColors.Control
        Me.UnsubscribeButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.UnsubscribeButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnsubscribeButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UnsubscribeButton.Location = New System.Drawing.Point(453, 344)
        Me.UnsubscribeButton.Name = "UnsubscribeButton"
        Me.UnsubscribeButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UnsubscribeButton.Size = New System.Drawing.Size(89, 25)
        Me.UnsubscribeButton.TabIndex = 11
        Me.UnsubscribeButton.Text = "Unsubscribe"
        Me.UnsubscribeButton.UseVisualStyleBackColor = False
        '
        'FAcctData
        '
        Me.AcceptButton = Me.UnsubscribeButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(667, 392)
        Me.Controls.Add(Me.UnsubscribeButton)
        Me.Controls.Add(Me.LastUpdateTimeText)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(315, 341)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAcctData"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Account Update"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private mAccountName As String

    Private mKeyValueDataText As TextboxDisplayManager
    Private mPortfolioDataText As TextboxDisplayManager

    Private mUnsubscribe As Action

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        mKeyValueDataText = New TextboxDisplayManager(KeyValueDataText)
        mPortfolioDataText = New TextboxDisplayManager(PortfolioDataText)
    End Sub


    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        ' clear any existing list details
        mKeyValueDataText.Clear()
        mPortfolioDataText.Clear()
        LastUpdateTimeText.Text = "00:00"

        Hide()
    End Sub

    Private Sub unsubscribeButton_Click(sender As Object, e As EventArgs) Handles UnsubscribeButton.Click
        mUnsubscribe()
    End Sub

    ' ========================================================
    ' Public methods
    ' ========================================================

    '--------------------------------------------------------------------------------
    ' Updates a user account property
    '--------------------------------------------------------------------------------
    Public Sub UpdateAccountValue(key As String, value As String, currency As String, accountName As String)
        mKeyValueDataText.DisplayMessage($"key={key} value={value} currency={currency} account={accountName}")
    End Sub

    '--------------------------------------------------------------------------------
    ' Updates a portfolio position details
    '--------------------------------------------------------------------------------
    Public Sub UpdatePortfolio(contract As Contract, position As Double, marketPrice As Double, marketValue As Double, averageCost As Double, unrealizedPNL As Double, realizedPNL As Double, accountName As String)
        mPortfolioDataText.DisplayMessage(
            $"Contract={contract.LocalSymbol}@{contract.Exchange} position={position} mktPrice={marketPrice} mktValue={marketValue}" &
            $" avgCost={averageCost} unrealizedPNL={unrealizedPNL} realizedPNL={realizedPNL} account={accountName}")
    End Sub

    '--------------------------------------------------------------------------------
    ' Updates the server clock time
    '--------------------------------------------------------------------------------
    Public Sub UpdateAccountTime(timeStamp As String)
        LastUpdateTimeText.Text = timeStamp
    End Sub

    Public Sub AccountDownloadBegin(accountName As String, unsubscribe As Action)
        mAccountName = accountName
        mUnsubscribe = unsubscribe
        updateTitle(False)
    End Sub

    Public Sub AccountDownloadEnd(accountName As String)
        updateTitle(True)
    End Sub

    Private Sub updateTitle(complete As Boolean)
        If Len(mAccountName) = 0 Then Exit Sub

        Dim title = mAccountName
        If complete Then
            title = title & "[complete]"
        End If

        Me.Text = title
    End Sub

End Class
