<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnExpried = New UIControlLib.LabelEx()
        Me.btnExport = New UIControlLib.LabelEx()
        Me.btnPrint = New UIControlLib.LabelEx()
        Me.btnRefresh = New UIControlLib.LabelEx()
        Me.btnTaking = New UIControlLib.LabelEx()
        Me.btnDetail = New UIControlLib.LabelEx()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.pnldgv = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbINSTYPE = New System.Windows.Forms.ComboBox()
        Me.btnChange = New UIControlLib.LabelEx()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFunc.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.pnldgv.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowDelete = True
        Me.dgv.AllowSelectChangeRow = False
        Me.dgv.AllowSort = True
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv.BeQuerying = False
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv.ChangeHeaderSize = False
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.NoItemAlter = ""
        Me.dgv.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelCombineKeyEnable = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.ShowSelectionColor = True
        Me.dgv.Size = New System.Drawing.Size(970, 469)
        Me.dgv.TabIndex = 9
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnChange)
        Me.pnlFunc.Controls.Add(Me.btnExpried)
        Me.pnlFunc.Controls.Add(Me.btnExport)
        Me.pnlFunc.Controls.Add(Me.btnPrint)
        Me.pnlFunc.Controls.Add(Me.btnRefresh)
        Me.pnlFunc.Controls.Add(Me.btnTaking)
        Me.pnlFunc.Controls.Add(Me.btnDetail)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 557)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(970, 40)
        Me.pnlFunc.TabIndex = 11
        '
        'btnExpried
        '
        Me.btnExpried.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExpried.BackColor = System.Drawing.Color.Transparent
        Me.btnExpried.Fore_Color = System.Drawing.Color.Black
        Me.btnExpried.ForeColor = System.Drawing.Color.Transparent
        Me.btnExpried.Location = New System.Drawing.Point(86, 6)
        Me.btnExpried.Name = "btnExpried"
        Me.btnExpried.Size = New System.Drawing.Size(75, 30)
        Me.btnExpried.TabIndex = 5
        Me.btnExpried.Text = "过期提醒"
        Me.btnExpried.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpried.TipText = ""
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.Color.Transparent
        Me.btnExport.Fore_Color = System.Drawing.Color.Black
        Me.btnExport.ForeColor = System.Drawing.Color.Transparent
        Me.btnExport.Location = New System.Drawing.Point(892, 6)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 30)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "导出"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExport.TipText = ""
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.Fore_Color = System.Drawing.Color.Black
        Me.btnPrint.ForeColor = System.Drawing.Color.Transparent
        Me.btnPrint.Location = New System.Drawing.Point(811, 6)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 30)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "打印"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.TipText = ""
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Fore_Color = System.Drawing.Color.Black
        Me.btnRefresh.ForeColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Location = New System.Drawing.Point(649, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "刷新"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.TipText = ""
        '
        'btnTaking
        '
        Me.btnTaking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTaking.BackColor = System.Drawing.Color.Transparent
        Me.btnTaking.Fore_Color = System.Drawing.Color.Black
        Me.btnTaking.ForeColor = System.Drawing.Color.Transparent
        Me.btnTaking.Location = New System.Drawing.Point(5, 6)
        Me.btnTaking.Name = "btnTaking"
        Me.btnTaking.Size = New System.Drawing.Size(75, 30)
        Me.btnTaking.TabIndex = 1
        Me.btnTaking.Text = "盘点"
        Me.btnTaking.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTaking.TipText = ""
        '
        'btnDetail
        '
        Me.btnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetail.BackColor = System.Drawing.Color.Transparent
        Me.btnDetail.Fore_Color = System.Drawing.Color.Black
        Me.btnDetail.ForeColor = System.Drawing.Color.Transparent
        Me.btnDetail.Location = New System.Drawing.Point(730, 6)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(75, 30)
        Me.btnDetail.TabIndex = 0
        Me.btnDetail.Text = "详细"
        Me.btnDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDetail.TipText = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnldgv)
        Me.Panel1.Controls.Add(Me.pnlTop)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(970, 519)
        Me.Panel1.TabIndex = 12
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.cmbINSTYPE)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(970, 50)
        Me.pnlTop.TabIndex = 10
        '
        'pnldgv
        '
        Me.pnldgv.Controls.Add(Me.dgv)
        Me.pnldgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnldgv.Location = New System.Drawing.Point(0, 50)
        Me.pnldgv.Name = "pnldgv"
        Me.pnldgv.Size = New System.Drawing.Size(970, 469)
        Me.pnldgv.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "物品类型"
        '
        'cmbINSTYPE
        '
        Me.cmbINSTYPE.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.cmbINSTYPE.FormattingEnabled = True
        Me.cmbINSTYPE.Location = New System.Drawing.Point(86, 13)
        Me.cmbINSTYPE.Name = "cmbINSTYPE"
        Me.cmbINSTYPE.Size = New System.Drawing.Size(187, 24)
        Me.cmbINSTYPE.TabIndex = 2
        '
        'btnChange
        '
        Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChange.BackColor = System.Drawing.Color.Transparent
        Me.btnChange.Fore_Color = System.Drawing.Color.Black
        Me.btnChange.ForeColor = System.Drawing.Color.Transparent
        Me.btnChange.Location = New System.Drawing.Point(167, 6)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(75, 30)
        Me.btnChange.TabIndex = 6
        Me.btnChange.Text = "变更"
        Me.btnChange.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnChange.TipText = ""
        '
        'FrmWareHouseStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlFunc)
        Me.Name = "FrmWareHouseStock"
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFunc.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnldgv.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As UIControlLib.LabelEx
    Friend WithEvents btnRefresh As UIControlLib.LabelEx
    Friend WithEvents btnTaking As UIControlLib.LabelEx
    Friend WithEvents btnDetail As UIControlLib.LabelEx
    Friend WithEvents btnExport As UIControlLib.LabelEx
    Friend WithEvents btnExpried As UIControlLib.LabelEx
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnldgv As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbINSTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents btnChange As UIControlLib.LabelEx

End Class
