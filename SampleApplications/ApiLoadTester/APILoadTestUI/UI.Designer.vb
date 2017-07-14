#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2017 Richard L King (TradeWright Software Systems)
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

#End Region

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class UI
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
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
	Public WithEvents ConnectButton As System.Windows.Forms.Button
	Public WithEvents MaxCpuPercentPerSecText As System.Windows.Forms.TextBox
	Public WithEvents MaxEventsPerSecText As System.Windows.Forms.TextBox
    Public WithEvents StopTickCountingButton As System.Windows.Forms.Button
    Public WithEvents StartTickCountingButton As System.Windows.Forms.Button
    Public WithEvents StopTickersButton As System.Windows.Forms.Button
    Public WithEvents LogText As System.Windows.Forms.TextBox
    Public WithEvents StartTickersButton As System.Windows.Forms.Button
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.MaxCpuPercentPerSecText = New System.Windows.Forms.TextBox()
        Me.MaxEventsPerSecText = New System.Windows.Forms.TextBox()
        Me.StopTickCountingButton = New System.Windows.Forms.Button()
        Me.StartTickCountingButton = New System.Windows.Forms.Button()
        Me.StopTickersButton = New System.Windows.Forms.Button()
        Me.LogText = New System.Windows.Forms.TextBox()
        Me.StartTickersButton = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ServerText = New System.Windows.Forms.TextBox()
        Me.PortText = New System.Windows.Forms.TextBox()
        Me.ClientIdText = New System.Windows.Forms.TextBox()
        Me.UseV100Check = New System.Windows.Forms.CheckBox()
        Me.MicrosecsPerTickText = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.AvgCpuUtilisationPercentText = New System.Windows.Forms.TextBox()
        Me.TotalProcessTimeText = New System.Windows.Forms.TextBox()
        Me.SecondsElapsedText = New System.Windows.Forms.TextBox()
        Me.AvgEventsPerSecondText = New System.Windows.Forms.TextBox()
        Me.TotalEventsText = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EventsLastSecondText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UseQueueingCheck = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ConnectButton
        '
        Me.ConnectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConnectButton.BackColor = System.Drawing.SystemColors.Control
        Me.ConnectButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.ConnectButton.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ConnectButton.Location = New System.Drawing.Point(475, 12)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ConnectButton.Size = New System.Drawing.Size(129, 31)
        Me.ConnectButton.TabIndex = 4
        Me.ConnectButton.Text = "Connect"
        Me.ConnectButton.UseVisualStyleBackColor = False
        '
        'MaxCpuPercentPerSecText
        '
        Me.MaxCpuPercentPerSecText.AcceptsReturn = True
        Me.MaxCpuPercentPerSecText.BackColor = System.Drawing.SystemColors.Window
        Me.MaxCpuPercentPerSecText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaxCpuPercentPerSecText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MaxCpuPercentPerSecText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxCpuPercentPerSecText.Location = New System.Drawing.Point(383, 130)
        Me.MaxCpuPercentPerSecText.Name = "MaxCpuPercentPerSecText"
        Me.MaxCpuPercentPerSecText.ReadOnly = True
        Me.MaxCpuPercentPerSecText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MaxCpuPercentPerSecText.Size = New System.Drawing.Size(65, 13)
        Me.MaxCpuPercentPerSecText.TabIndex = 26
        Me.MaxCpuPercentPerSecText.TabStop = False
        Me.MaxCpuPercentPerSecText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MaxEventsPerSecText
        '
        Me.MaxEventsPerSecText.AcceptsReturn = True
        Me.MaxEventsPerSecText.BackColor = System.Drawing.SystemColors.Window
        Me.MaxEventsPerSecText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaxEventsPerSecText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MaxEventsPerSecText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxEventsPerSecText.Location = New System.Drawing.Point(383, 114)
        Me.MaxEventsPerSecText.Name = "MaxEventsPerSecText"
        Me.MaxEventsPerSecText.ReadOnly = True
        Me.MaxEventsPerSecText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MaxEventsPerSecText.Size = New System.Drawing.Size(65, 13)
        Me.MaxEventsPerSecText.TabIndex = 24
        Me.MaxEventsPerSecText.TabStop = False
        Me.MaxEventsPerSecText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StopTickCountingButton
        '
        Me.StopTickCountingButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StopTickCountingButton.BackColor = System.Drawing.SystemColors.Control
        Me.StopTickCountingButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.StopTickCountingButton.Enabled = False
        Me.StopTickCountingButton.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StopTickCountingButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StopTickCountingButton.Location = New System.Drawing.Point(475, 164)
        Me.StopTickCountingButton.Name = "StopTickCountingButton"
        Me.StopTickCountingButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StopTickCountingButton.Size = New System.Drawing.Size(129, 31)
        Me.StopTickCountingButton.TabIndex = 8
        Me.StopTickCountingButton.Text = "Stop counting ticks"
        Me.StopTickCountingButton.UseVisualStyleBackColor = False
        '
        'StartTickCountingButton
        '
        Me.StartTickCountingButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartTickCountingButton.BackColor = System.Drawing.SystemColors.Control
        Me.StartTickCountingButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.StartTickCountingButton.Enabled = False
        Me.StartTickCountingButton.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartTickCountingButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StartTickCountingButton.Location = New System.Drawing.Point(475, 125)
        Me.StartTickCountingButton.Name = "StartTickCountingButton"
        Me.StartTickCountingButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartTickCountingButton.Size = New System.Drawing.Size(129, 31)
        Me.StartTickCountingButton.TabIndex = 7
        Me.StartTickCountingButton.Text = "Start counting ticks"
        Me.StartTickCountingButton.UseVisualStyleBackColor = False
        '
        'StopTickersButton
        '
        Me.StopTickersButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StopTickersButton.BackColor = System.Drawing.SystemColors.Control
        Me.StopTickersButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.StopTickersButton.Enabled = False
        Me.StopTickersButton.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StopTickersButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StopTickersButton.Location = New System.Drawing.Point(475, 87)
        Me.StopTickersButton.Name = "StopTickersButton"
        Me.StopTickersButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StopTickersButton.Size = New System.Drawing.Size(129, 31)
        Me.StopTickersButton.TabIndex = 6
        Me.StopTickersButton.Text = "Stop tickers"
        Me.StopTickersButton.UseVisualStyleBackColor = False
        '
        'LogText
        '
        Me.LogText.AcceptsReturn = True
        Me.LogText.BackColor = System.Drawing.SystemColors.Window
        Me.LogText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LogText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LogText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LogText.Location = New System.Drawing.Point(0, 201)
        Me.LogText.Multiline = True
        Me.LogText.Name = "LogText"
        Me.LogText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LogText.Size = New System.Drawing.Size(616, 263)
        Me.LogText.TabIndex = 2
        Me.LogText.TabStop = False
        '
        'StartTickersButton
        '
        Me.StartTickersButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartTickersButton.BackColor = System.Drawing.SystemColors.Control
        Me.StartTickersButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.StartTickersButton.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartTickersButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StartTickersButton.Location = New System.Drawing.Point(475, 49)
        Me.StartTickersButton.Name = "StartTickersButton"
        Me.StartTickersButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartTickersButton.Size = New System.Drawing.Size(129, 31)
        Me.StartTickersButton.TabIndex = 5
        Me.StartTickersButton.Text = "Start tickers"
        Me.StartTickersButton.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(251, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(113, 17)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Max CPU % per sec"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(251, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(113, 17)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Max events per sec"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Server"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Port"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Client id"
        '
        'ServerText
        '
        Me.ServerText.Location = New System.Drawing.Point(115, 8)
        Me.ServerText.Name = "ServerText"
        Me.ServerText.Size = New System.Drawing.Size(65, 20)
        Me.ServerText.TabIndex = 0
        '
        'PortText
        '
        Me.PortText.Location = New System.Drawing.Point(115, 35)
        Me.PortText.Name = "PortText"
        Me.PortText.Size = New System.Drawing.Size(65, 20)
        Me.PortText.TabIndex = 1
        Me.PortText.Text = "7496"
        Me.PortText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ClientIdText
        '
        Me.ClientIdText.Location = New System.Drawing.Point(115, 62)
        Me.ClientIdText.Name = "ClientIdText"
        Me.ClientIdText.Size = New System.Drawing.Size(65, 20)
        Me.ClientIdText.TabIndex = 2
        Me.ClientIdText.Text = "123"
        Me.ClientIdText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UseV100Check
        '
        Me.UseV100Check.AutoSize = True
        Me.UseV100Check.Checked = True
        Me.UseV100Check.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseV100Check.Enabled = False
        Me.UseV100Check.Location = New System.Drawing.Point(227, 9)
        Me.UseV100Check.Name = "UseV100Check"
        Me.UseV100Check.Size = New System.Drawing.Size(120, 17)
        Me.UseV100Check.TabIndex = 3
        Me.UseV100Check.Text = "Use V100+ protocol"
        Me.UseV100Check.UseVisualStyleBackColor = True
        '
        'MicrosecsPerTickText
        '
        Me.MicrosecsPerTickText.AcceptsReturn = True
        Me.MicrosecsPerTickText.BackColor = System.Drawing.SystemColors.Window
        Me.MicrosecsPerTickText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MicrosecsPerTickText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MicrosecsPerTickText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MicrosecsPerTickText.Location = New System.Drawing.Point(169, 178)
        Me.MicrosecsPerTickText.Name = "MicrosecsPerTickText"
        Me.MicrosecsPerTickText.ReadOnly = True
        Me.MicrosecsPerTickText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MicrosecsPerTickText.Size = New System.Drawing.Size(65, 13)
        Me.MicrosecsPerTickText.TabIndex = 41
        Me.MicrosecsPerTickText.TabStop = False
        Me.MicrosecsPerTickText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(16, 178)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(113, 17)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Microsecs per tick"
        '
        'AvgCpuUtilisationPercentText
        '
        Me.AvgCpuUtilisationPercentText.AcceptsReturn = True
        Me.AvgCpuUtilisationPercentText.BackColor = System.Drawing.SystemColors.Window
        Me.AvgCpuUtilisationPercentText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AvgCpuUtilisationPercentText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AvgCpuUtilisationPercentText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AvgCpuUtilisationPercentText.Location = New System.Drawing.Point(169, 162)
        Me.AvgCpuUtilisationPercentText.Name = "AvgCpuUtilisationPercentText"
        Me.AvgCpuUtilisationPercentText.ReadOnly = True
        Me.AvgCpuUtilisationPercentText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AvgCpuUtilisationPercentText.Size = New System.Drawing.Size(65, 13)
        Me.AvgCpuUtilisationPercentText.TabIndex = 31
        Me.AvgCpuUtilisationPercentText.TabStop = False
        Me.AvgCpuUtilisationPercentText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalProcessTimeText
        '
        Me.TotalProcessTimeText.AcceptsReturn = True
        Me.TotalProcessTimeText.BackColor = System.Drawing.SystemColors.Window
        Me.TotalProcessTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TotalProcessTimeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TotalProcessTimeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalProcessTimeText.Location = New System.Drawing.Point(169, 146)
        Me.TotalProcessTimeText.Name = "TotalProcessTimeText"
        Me.TotalProcessTimeText.ReadOnly = True
        Me.TotalProcessTimeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TotalProcessTimeText.Size = New System.Drawing.Size(65, 13)
        Me.TotalProcessTimeText.TabIndex = 39
        Me.TotalProcessTimeText.TabStop = False
        Me.TotalProcessTimeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SecondsElapsedText
        '
        Me.SecondsElapsedText.AcceptsReturn = True
        Me.SecondsElapsedText.BackColor = System.Drawing.SystemColors.Window
        Me.SecondsElapsedText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SecondsElapsedText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SecondsElapsedText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SecondsElapsedText.Location = New System.Drawing.Point(169, 130)
        Me.SecondsElapsedText.Name = "SecondsElapsedText"
        Me.SecondsElapsedText.ReadOnly = True
        Me.SecondsElapsedText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SecondsElapsedText.Size = New System.Drawing.Size(65, 13)
        Me.SecondsElapsedText.TabIndex = 32
        Me.SecondsElapsedText.TabStop = False
        Me.SecondsElapsedText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AvgEventsPerSecondText
        '
        Me.AvgEventsPerSecondText.AcceptsReturn = True
        Me.AvgEventsPerSecondText.BackColor = System.Drawing.SystemColors.Window
        Me.AvgEventsPerSecondText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AvgEventsPerSecondText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AvgEventsPerSecondText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AvgEventsPerSecondText.Location = New System.Drawing.Point(169, 114)
        Me.AvgEventsPerSecondText.Name = "AvgEventsPerSecondText"
        Me.AvgEventsPerSecondText.ReadOnly = True
        Me.AvgEventsPerSecondText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AvgEventsPerSecondText.Size = New System.Drawing.Size(65, 13)
        Me.AvgEventsPerSecondText.TabIndex = 33
        Me.AvgEventsPerSecondText.TabStop = False
        Me.AvgEventsPerSecondText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalEventsText
        '
        Me.TotalEventsText.AcceptsReturn = True
        Me.TotalEventsText.BackColor = System.Drawing.SystemColors.Window
        Me.TotalEventsText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TotalEventsText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TotalEventsText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalEventsText.Location = New System.Drawing.Point(169, 98)
        Me.TotalEventsText.Name = "TotalEventsText"
        Me.TotalEventsText.ReadOnly = True
        Me.TotalEventsText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TotalEventsText.Size = New System.Drawing.Size(65, 13)
        Me.TotalEventsText.TabIndex = 34
        Me.TotalEventsText.TabStop = False
        Me.TotalEventsText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(113, 17)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Avg CPU %"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(147, 25)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Total process time (millisecs)"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 25)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Seconds elapsed"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Avg events per sec"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 25)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Total events"
        '
        'EventsLastSecondText
        '
        Me.EventsLastSecondText.AcceptsReturn = True
        Me.EventsLastSecondText.BackColor = System.Drawing.SystemColors.Window
        Me.EventsLastSecondText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EventsLastSecondText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.EventsLastSecondText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EventsLastSecondText.Location = New System.Drawing.Point(383, 98)
        Me.EventsLastSecondText.Name = "EventsLastSecondText"
        Me.EventsLastSecondText.ReadOnly = True
        Me.EventsLastSecondText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EventsLastSecondText.Size = New System.Drawing.Size(65, 13)
        Me.EventsLastSecondText.TabIndex = 43
        Me.EventsLastSecondText.TabStop = False
        Me.EventsLastSecondText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(251, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(97, 25)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Events last second"
        '
        'UseQueueingCheck
        '
        Me.UseQueueingCheck.AutoSize = True
        Me.UseQueueingCheck.Enabled = False
        Me.UseQueueingCheck.Location = New System.Drawing.Point(225, 34)
        Me.UseQueueingCheck.Name = "UseQueueingCheck"
        Me.UseQueueingCheck.Size = New System.Drawing.Size(173, 17)
        Me.UseQueueingCheck.TabIndex = 4
        Me.UseQueueingCheck.Text = "Use queueing callback handler"
        Me.UseQueueingCheck.UseVisualStyleBackColor = True
        '
        'UI
        '
        Me.AcceptButton = Me.ConnectButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(616, 466)
        Me.Controls.Add(Me.UseQueueingCheck)
        Me.Controls.Add(Me.MaxEventsPerSecText)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.EventsLastSecondText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MicrosecsPerTickText)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.AvgCpuUtilisationPercentText)
        Me.Controls.Add(Me.TotalProcessTimeText)
        Me.Controls.Add(Me.SecondsElapsedText)
        Me.Controls.Add(Me.AvgEventsPerSecondText)
        Me.Controls.Add(Me.TotalEventsText)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UseV100Check)
        Me.Controls.Add(Me.ClientIdText)
        Me.Controls.Add(Me.PortText)
        Me.Controls.Add(Me.ServerText)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.MaxCpuPercentPerSecText)
        Me.Controls.Add(Me.StopTickCountingButton)
        Me.Controls.Add(Me.StartTickCountingButton)
        Me.Controls.Add(Me.StopTickersButton)
        Me.Controls.Add(Me.LogText)
        Me.Controls.Add(Me.StartTickersButton)
        Me.Controls.Add(Me.Label10)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(25, 30)
        Me.Name = "UI"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "API Load Tester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ServerText As TextBox
    Friend WithEvents PortText As TextBox
    Friend WithEvents ClientIdText As TextBox
    Friend WithEvents UseV100Check As CheckBox
    Public WithEvents MicrosecsPerTickText As TextBox
    Public WithEvents Label11 As Label
    Public WithEvents AvgCpuUtilisationPercentText As TextBox
    Public WithEvents TotalProcessTimeText As TextBox
    Public WithEvents SecondsElapsedText As TextBox
    Public WithEvents AvgEventsPerSecondText As TextBox
    Public WithEvents TotalEventsText As TextBox
    Public WithEvents Label6 As Label
    Public WithEvents Label8 As Label
    Public WithEvents Label4 As Label
    Public WithEvents Label3 As Label
    Public WithEvents Label1 As Label
    Public WithEvents EventsLastSecondText As TextBox
    Public WithEvents Label2 As Label
    Friend WithEvents UseQueueingCheck As CheckBox
#End Region
End Class