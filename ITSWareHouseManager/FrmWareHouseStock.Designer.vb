﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseStock
    Inherits UIControlLib.MyUserControlBase

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.btnExport = New DevComponents.DotNetBar.ButtonX()
        Me.btnDetail = New DevComponents.DotNetBar.ButtonX()
        Me.btnExpried = New DevComponents.DotNetBar.ButtonX()
        Me.btnChange = New DevComponents.DotNetBar.ButtonX()
        Me.btnTaking = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnldgv = New System.Windows.Forms.Panel()
        Me.dgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbINSTYPE = New System.Windows.Forms.ComboBox()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.pnlCommit.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnldgv.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCommit
        '
        Me.pnlCommit.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlCommit.Controls.Add(Me.btnRefresh)
        Me.pnlCommit.Controls.Add(Me.btnPrint)
        Me.pnlCommit.Controls.Add(Me.btnExport)
        Me.pnlCommit.Controls.Add(Me.btnDetail)
        Me.pnlCommit.Controls.Add(Me.btnExpried)
        Me.pnlCommit.Controls.Add(Me.btnChange)
        Me.pnlCommit.Controls.Add(Me.btnTaking)
        Me.pnlCommit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommit.Location = New System.Drawing.Point(0, 386)
        Me.pnlCommit.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCommit.Name = "pnlCommit"
        Me.pnlCommit.Size = New System.Drawing.Size(806, 30)
        Me.pnlCommit.TabIndex = 11
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRefresh.Location = New System.Drawing.Point(556, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(59, 21)
        Me.btnRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.Text = "刷新"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrint.Location = New System.Drawing.Point(680, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(59, 21)
        Me.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrint.TabIndex = 16
        Me.btnPrint.Text = "打印"
        '
        'btnExport
        '
        Me.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnExport.Location = New System.Drawing.Point(742, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(59, 21)
        Me.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExport.TabIndex = 15
        Me.btnExport.Text = "导出"
        '
        'btnDetail
        '
        Me.btnDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDetail.Location = New System.Drawing.Point(618, 5)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(59, 21)
        Me.btnDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDetail.TabIndex = 14
        Me.btnDetail.Text = "详细"
        '
        'btnExpried
        '
        Me.btnExpried.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExpried.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnExpried.Location = New System.Drawing.Point(67, 5)
        Me.btnExpried.Name = "btnExpried"
        Me.btnExpried.Size = New System.Drawing.Size(59, 21)
        Me.btnExpried.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExpried.TabIndex = 13
        Me.btnExpried.Text = "过期提醒"
        '
        'btnChange
        '
        Me.btnChange.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnChange.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnChange.Location = New System.Drawing.Point(129, 5)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(59, 21)
        Me.btnChange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnChange.TabIndex = 12
        Me.btnChange.Text = "变更"
        '
        'btnTaking
        '
        Me.btnTaking.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnTaking.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnTaking.Location = New System.Drawing.Point(5, 5)
        Me.btnTaking.Name = "btnTaking"
        Me.btnTaking.Size = New System.Drawing.Size(59, 21)
        Me.btnTaking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnTaking.TabIndex = 11
        Me.btnTaking.Text = "盘点"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnldgv)
        Me.Panel1.Controls.Add(Me.pnlTop)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(806, 354)
        Me.Panel1.TabIndex = 12
        '
        'pnldgv
        '
        Me.pnldgv.Controls.Add(Me.dgv)
        Me.pnldgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnldgv.Location = New System.Drawing.Point(0, 38)
        Me.pnldgv.Margin = New System.Windows.Forms.Padding(2)
        Me.pnldgv.Name = "pnldgv"
        Me.pnldgv.Size = New System.Drawing.Size(806, 316)
        Me.pnldgv.TabIndex = 11
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(806, 316)
        Me.dgv.TabIndex = 19
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.cmbINSTYPE)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(806, 38)
        Me.pnlTop.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "物品类型"
        '
        'cmbINSTYPE
        '
        Me.cmbINSTYPE.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.cmbINSTYPE.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.cmbINSTYPE.FormattingEnabled = True
        Me.cmbINSTYPE.Location = New System.Drawing.Point(62, 10)
        Me.cmbINSTYPE.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSTYPE.Name = "cmbINSTYPE"
        Me.cmbINSTYPE.Size = New System.Drawing.Size(141, 20)
        Me.cmbINSTYPE.TabIndex = 2
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(806, 32)
        Me.pnlFunc.TabIndex = 18
        '
        'btnClose
        '
        Me.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnClose.Location = New System.Drawing.Point(4, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(59, 21)
        Me.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "关闭"
        '
        'FrmWareHouseStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlCommit)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmWareHouseStock"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlCommit.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnldgv.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlFunc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnldgv As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbINSTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetail As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExpried As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnChange As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnTaking As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgv As DevComponents.DotNetBar.Controls.DataGridViewX

End Class
