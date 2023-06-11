' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Imports TradeWright.IBAPI

Friend Class FComboOrderLegs
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
            If mComponents IsNot Nothing Then
                mComponents.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private mComponents As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents OkButton As System.Windows.Forms.Button
    Public WithEvents CancelItButton As System.Windows.Forms.Button
    Public WithEvents RemoveLegButton As System.Windows.Forms.Button
    Public WithEvents AddLegButton As System.Windows.Forms.Button
    Public WithEvents OpenCloseText As System.Windows.Forms.TextBox
    Public WithEvents ExchangeText As System.Windows.Forms.TextBox
    Public WithEvents ActionText As System.Windows.Forms.TextBox
    Public WithEvents RatioText As System.Windows.Forms.TextBox
    Public WithEvents ConidText As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LegDetailsFrame As System.Windows.Forms.GroupBox
    Public WithEvents ComboLegsGrid As ListView
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents DesignatedLocationText As System.Windows.Forms.TextBox
    Public WithEvents ShortSaleSlotText As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ExemptCodeText As System.Windows.Forms.TextBox
    Friend WithEvents PriceText As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mComponents = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.mComponents)
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelItButton = New System.Windows.Forms.Button()
        Me.RemoveLegButton = New System.Windows.Forms.Button()
        Me.LegDetailsFrame = New System.Windows.Forms.GroupBox()
        Me.PriceText = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ExemptCodeText = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DesignatedLocationText = New System.Windows.Forms.TextBox()
        Me.ShortSaleSlotText = New System.Windows.Forms.TextBox()
        Me.AddLegButton = New System.Windows.Forms.Button()
        Me.OpenCloseText = New System.Windows.Forms.TextBox()
        Me.ExchangeText = New System.Windows.Forms.TextBox()
        Me.ActionText = New System.Windows.Forms.TextBox()
        Me.RatioText = New System.Windows.Forms.TextBox()
        Me.ConidText = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.ComboLegsGrid = New System.Windows.Forms.ListView()
        Me.LegDetailsFrame.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.BackColor = System.Drawing.SystemColors.Control
        Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OkButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OkButton.Location = New System.Drawing.Point(558, 306)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OkButton.Size = New System.Drawing.Size(73, 25)
        Me.OkButton.TabIndex = 2
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelItButton.BackColor = System.Drawing.SystemColors.Control
        Me.CancelItButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelItButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelItButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelItButton.Location = New System.Drawing.Point(637, 307)
        Me.CancelItButton.Name = "CancelButton"
        Me.CancelItButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelItButton.Size = New System.Drawing.Size(73, 25)
        Me.CancelItButton.TabIndex = 3
        Me.CancelItButton.Text = "Cancel"
        Me.CancelItButton.UseVisualStyleBackColor = True
        '
        'RemoveLegButton
        '
        Me.RemoveLegButton.BackColor = System.Drawing.SystemColors.Control
        Me.RemoveLegButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.RemoveLegButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveLegButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RemoveLegButton.Location = New System.Drawing.Point(215, 259)
        Me.RemoveLegButton.Name = "RemoveLegButton"
        Me.RemoveLegButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RemoveLegButton.Size = New System.Drawing.Size(65, 25)
        Me.RemoveLegButton.TabIndex = 1
        Me.RemoveLegButton.Text = "Remove"
        Me.RemoveLegButton.UseVisualStyleBackColor = True
        '
        'frmLegDetails
        '
        Me.LegDetailsFrame.BackColor = System.Drawing.Color.Gainsboro
        Me.LegDetailsFrame.Controls.Add(Me.PriceText)
        Me.LegDetailsFrame.Controls.Add(Me.Label9)
        Me.LegDetailsFrame.Controls.Add(Me.Label8)
        Me.LegDetailsFrame.Controls.Add(Me.ExemptCodeText)
        Me.LegDetailsFrame.Controls.Add(Me.Label7)
        Me.LegDetailsFrame.Controls.Add(Me.Label6)
        Me.LegDetailsFrame.Controls.Add(Me.DesignatedLocationText)
        Me.LegDetailsFrame.Controls.Add(Me.ShortSaleSlotText)
        Me.LegDetailsFrame.Controls.Add(Me.AddLegButton)
        Me.LegDetailsFrame.Controls.Add(Me.OpenCloseText)
        Me.LegDetailsFrame.Controls.Add(Me.ExchangeText)
        Me.LegDetailsFrame.Controls.Add(Me.ActionText)
        Me.LegDetailsFrame.Controls.Add(Me.RatioText)
        Me.LegDetailsFrame.Controls.Add(Me.ConidText)
        Me.LegDetailsFrame.Controls.Add(Me.Label5)
        Me.LegDetailsFrame.Controls.Add(Me.Label4)
        Me.LegDetailsFrame.Controls.Add(Me.Label3)
        Me.LegDetailsFrame.Controls.Add(Me.Label2)
        Me.LegDetailsFrame.Controls.Add(Me.Label1)
        Me.LegDetailsFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LegDetailsFrame.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LegDetailsFrame.Location = New System.Drawing.Point(514, 8)
        Me.LegDetailsFrame.Name = "frmLegDetails"
        Me.LegDetailsFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LegDetailsFrame.Size = New System.Drawing.Size(196, 290)
        Me.LegDetailsFrame.TabIndex = 1
        Me.LegDetailsFrame.TabStop = False
        Me.LegDetailsFrame.Text = "Leg Details"
        '
        'PriceText
        '
        Me.PriceText.AcceptsReturn = True
        Me.PriceText.BackColor = System.Drawing.SystemColors.Window
        Me.PriceText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PriceText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PriceText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PriceText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PriceText.Location = New System.Drawing.Point(97, 229)
        Me.PriceText.MaxLength = 0
        Me.PriceText.Name = "PriceText"
        Me.PriceText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PriceText.Size = New System.Drawing.Size(93, 13)
        Me.PriceText.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Exempt Code"
        '
        'ExemptCodeText
        '
        Me.ExemptCodeText.AcceptsReturn = True
        Me.ExemptCodeText.BackColor = System.Drawing.SystemColors.Window
        Me.ExemptCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExemptCodeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExemptCodeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExemptCodeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExemptCodeText.Location = New System.Drawing.Point(97, 202)
        Me.ExemptCodeText.MaxLength = 0
        Me.ExemptCodeText.Name = "ExemptCodeText"
        Me.ExemptCodeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExemptCodeText.Size = New System.Drawing.Size(93, 13)
        Me.ExemptCodeText.TabIndex = 15
        Me.ExemptCodeText.Text = "-1"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(85, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Location"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(6, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(85, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Short Sale Slot"
        '
        'DesignatedLocationText
        '
        Me.DesignatedLocationText.AcceptsReturn = True
        Me.DesignatedLocationText.BackColor = System.Drawing.SystemColors.Window
        Me.DesignatedLocationText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DesignatedLocationText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DesignatedLocationText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignatedLocationText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DesignatedLocationText.Location = New System.Drawing.Point(97, 175)
        Me.DesignatedLocationText.MaxLength = 0
        Me.DesignatedLocationText.Name = "DesignatedLocationText"
        Me.DesignatedLocationText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DesignatedLocationText.Size = New System.Drawing.Size(93, 13)
        Me.DesignatedLocationText.TabIndex = 13
        '
        'ShortSaleSlotText
        '
        Me.ShortSaleSlotText.AcceptsReturn = True
        Me.ShortSaleSlotText.BackColor = System.Drawing.SystemColors.Window
        Me.ShortSaleSlotText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ShortSaleSlotText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ShortSaleSlotText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShortSaleSlotText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ShortSaleSlotText.Location = New System.Drawing.Point(97, 149)
        Me.ShortSaleSlotText.MaxLength = 0
        Me.ShortSaleSlotText.Name = "ShortSaleSlotText"
        Me.ShortSaleSlotText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShortSaleSlotText.Size = New System.Drawing.Size(93, 13)
        Me.ShortSaleSlotText.TabIndex = 11
        Me.ShortSaleSlotText.Text = "0"
        '
        'AddLegButton
        '
        Me.AddLegButton.BackColor = System.Drawing.SystemColors.Control
        Me.AddLegButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.AddLegButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddLegButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AddLegButton.Location = New System.Drawing.Point(64, 259)
        Me.AddLegButton.Name = "AddLegButton"
        Me.AddLegButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AddLegButton.Size = New System.Drawing.Size(65, 25)
        Me.AddLegButton.TabIndex = 18
        Me.AddLegButton.Text = "Add"
        Me.AddLegButton.UseVisualStyleBackColor = True
        '
        'OpenCloseText
        '
        Me.OpenCloseText.AcceptsReturn = True
        Me.OpenCloseText.BackColor = System.Drawing.SystemColors.Window
        Me.OpenCloseText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OpenCloseText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OpenCloseText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenCloseText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OpenCloseText.Location = New System.Drawing.Point(97, 124)
        Me.OpenCloseText.MaxLength = 0
        Me.OpenCloseText.Name = "OpenCloseText"
        Me.OpenCloseText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpenCloseText.Size = New System.Drawing.Size(93, 13)
        Me.OpenCloseText.TabIndex = 9
        Me.OpenCloseText.Text = "0"
        '
        'ExchangeText
        '
        Me.ExchangeText.AcceptsReturn = True
        Me.ExchangeText.BackColor = System.Drawing.SystemColors.Window
        Me.ExchangeText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExchangeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExchangeText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExchangeText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExchangeText.Location = New System.Drawing.Point(97, 99)
        Me.ExchangeText.MaxLength = 0
        Me.ExchangeText.Name = "ExchangeText"
        Me.ExchangeText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExchangeText.Size = New System.Drawing.Size(93, 13)
        Me.ExchangeText.TabIndex = 7
        Me.ExchangeText.Text = "SMART"
        '
        'ActionText
        '
        Me.ActionText.AcceptsReturn = True
        Me.ActionText.BackColor = System.Drawing.SystemColors.Window
        Me.ActionText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ActionText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ActionText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActionText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ActionText.Location = New System.Drawing.Point(97, 74)
        Me.ActionText.MaxLength = 0
        Me.ActionText.Name = "ActionText"
        Me.ActionText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ActionText.Size = New System.Drawing.Size(93, 13)
        Me.ActionText.TabIndex = 5
        Me.ActionText.Text = "BUY"
        '
        'RatioText
        '
        Me.RatioText.AcceptsReturn = True
        Me.RatioText.BackColor = System.Drawing.SystemColors.Window
        Me.RatioText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RatioText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RatioText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RatioText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RatioText.Location = New System.Drawing.Point(97, 49)
        Me.RatioText.MaxLength = 0
        Me.RatioText.Name = "RatioText"
        Me.RatioText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RatioText.Size = New System.Drawing.Size(93, 13)
        Me.RatioText.TabIndex = 3
        Me.RatioText.Text = "1"
        '
        'ConidText
        '
        Me.ConidText.AcceptsReturn = True
        Me.ConidText.BackColor = System.Drawing.SystemColors.Window
        Me.ConidText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ConidText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ConidText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConidText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ConidText.Location = New System.Drawing.Point(97, 24)
        Me.ConidText.MaxLength = 0
        Me.ConidText.Name = "ConidText"
        Me.ConidText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ConidText.Size = New System.Drawing.Size(93, 13)
        Me.ConidText.TabIndex = 1
        Me.ConidText.Text = "0"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(85, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Open/Close"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(85, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Exchange"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(85, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Side"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ratio"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ContractId"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame1.Controls.Add(Me.ComboLegsGrid)
        Me.Frame1.Controls.Add(Me.RemoveLegButton)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(500, 290)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Combo Legs"
        '
        'ComboLegsGrid
        '
        Me.ComboLegsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ComboLegsGrid.FullRowSelect = True
        Me.ComboLegsGrid.Location = New System.Drawing.Point(8, 24)
        Me.ComboLegsGrid.Name = "ComboLegsGrid"
        Me.ComboLegsGrid.Size = New System.Drawing.Size(486, 198)
        Me.ComboLegsGrid.TabIndex = 0
        Me.ComboLegsGrid.UseCompatibleStateImageBehavior = False
        Me.ComboLegsGrid.View = System.Windows.Forms.View.Details
        '
        'fComboOrderLegs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(722, 344)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.LegDetailsFrame)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fComboOrderLegs"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Combination Order Legs"
        Me.LegDetailsFrame.ResumeLayout(False)
        Me.LegDetailsFrame.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private mComboLegs As ComboLegs
    Private mOrderComboLegs As List(Of OrderComboLeg)

    Private mOk As Boolean

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property Ok() As Boolean
        Get
            Ok = mOk
        End Get
    End Property

    Public ReadOnly Property ComboLegs() As ComboLegs
        Get
            ComboLegs = mComboLegs
        End Get
    End Property

    Public ReadOnly Property OrderComboLegs() As List(Of OrderComboLeg)
        Get
            OrderComboLegs = mOrderComboLegs
        End Get
    End Property

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================

    Public Sub Init(comboLegs As ComboLegs, orderComboLegs() As OrderComboLeg)
        mComboLegs = comboLegs
        If (comboLegs IsNot Nothing) And (orderComboLegs IsNot Nothing) Then

            Dim i = 0
            For Each LegCombo In comboLegs
                Dim orderCmbLeg = orderComboLegs(i)
                Dim row = New List(Of String)

                With LegCombo
                    row.AddRange(New String() {CStr(.ContractId),
                                                CStr(.Ratio),
                                                CStr(.Action),
                                                CStr(.Exchange),
                                                CStr(.OpenClose),
                                                CStr(.ShortSaleSlot),
                                                CStr(.DesignatedLocation),
                                                CStr(.ExemptCode)})
                End With

                With orderCmbLeg
                    row.Add(If(.Price = Double.MaxValue, "", CStr(.Price)))
                End With

                ComboLegsGrid.Items.Add(New ListViewItem(row.ToArray()))
                i += 1
            Next
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================

    Private Sub oKButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If (ComboLegsGrid.Items.Count > 0) Then

            mOrderComboLegs = New List(Of OrderComboLeg)

            For Each row As ListViewItem In ComboLegsGrid.Items
                Dim LegCombo As New ComboLeg
                mComboLegs.Add(LegCombo)
                Dim orderCmbLeg As OrderComboLeg = New OrderComboLeg
                mOrderComboLegs.Add(orderCmbLeg)

                LegCombo.ContractId = CInt(row.SubItems(0).Text)

                LegCombo.Ratio = CInt(row.SubItems(1).Text)

                LegCombo.Action = [Enum].Parse(Of OrderAction)(row.SubItems(2).Text, True)

                LegCombo.Exchange = row.SubItems(3).Text

                LegCombo.OpenClose = [Enum].Parse(Of LegOpenCloseCode)(row.SubItems(4).Text, True)

                LegCombo.ShortSaleSlot = [Enum].Parse(Of ShortSaleSlotCode)(row.SubItems(5).Text, True)

                LegCombo.DesignatedLocation = row.SubItems(6).Text

                If Not String.IsNullOrEmpty(row.SubItems(7).Text) Then
                    LegCombo.ExemptCode = CInt(row.SubItems(7).Text)
                Else
                    LegCombo.ExemptCode = CInt("-1")
                End If

                If Len(row.SubItems(8).Text) = 0 Then
                    orderCmbLeg.Price = Double.MaxValue
                Else
                    orderCmbLeg.Price = CDbl(row.SubItems(8).Text)
                End If
            Next

        End If

        mOk = True
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel
    '--------------------------------------------------------------------------------
    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles CancelItButton.Click
        mOk = False
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    ' Adds a combo leg to the list
    '--------------------------------------------------------------------------------
    Private Sub addLegButton_Click(sender As Object, e As EventArgs) Handles AddLegButton.Click
        Dim row = {ConidText.Text, RatioText.Text, ActionText.Text, ExchangeText.Text, OpenCloseText.Text, ShortSaleSlotText.Text, DesignatedLocationText.Text, ExemptCodeText.Text, PriceText.Text}
        ComboLegsGrid.Items.Add(New ListViewItem(row))
    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a combo leg from the list
    '--------------------------------------------------------------------------------
    Private Sub removeLegButton_Click(sender As Object, e As EventArgs) Handles RemoveLegButton.Click
        ComboLegsGrid.SelectedItems.OfType(Of ListViewItem).ToList().ForEach(Sub(x) ComboLegsGrid.Items.Remove(x))
    End Sub

    '--------------------------------------------------------------------------------
    ' when the form is first loaded and the combo leg header row is added
    '--------------------------------------------------------------------------------
    Private Sub fComboOrderLegs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim title As String
        title = "Combination Order Legs"
        ComboLegsGrid.Columns.AddRange(
            New String() {
            "ContractId", "Ratio", "Side", "Exchange", "Open/Close", "Short Sale Slot", "Location", "Exempt Code", "Price"
                         }.Select(Function(x) New ColumnHeader() With {.Text = x}).ToArray())
    End Sub
End Class
