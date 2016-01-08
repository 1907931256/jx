<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseInOutQuery
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("入库")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("出库")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("入充")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("出充")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("过期出库")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("库房物品", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("入库")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("出库")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("入充")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("出充")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("过期出库")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("药品", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("发放入库")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("使用出库")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("过期出库")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("器械类", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14, TreeNode15})
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.gbDrugInfo = New System.Windows.Forms.GroupBox()
        Me.cmbINSName = New UIControlLib.CmbDropDownList()
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.pnlSep = New System.Windows.Forms.Panel()
        Me.btnRefresh = New UIControlLib.LabelEx()
        Me.gbDateSelector = New System.Windows.Forms.GroupBox()
        Me.lblSpan = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.tvType = New System.Windows.Forms.TreeView()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnTotal = New UIControlLib.LabelEx()
        Me.btnDetail = New UIControlLib.LabelEx()
        Me.btnExport = New UIControlLib.LabelEx()
        Me.btnPrint = New UIControlLib.LabelEx()
        Me.pnlInfo.SuspendLayout()
        Me.gbDrugInfo.SuspendLayout()
        Me.gbDateSelector.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.gbDrugInfo)
        Me.pnlInfo.Controls.Add(Me.pnlSep)
        Me.pnlInfo.Controls.Add(Me.btnRefresh)
        Me.pnlInfo.Controls.Add(Me.gbDateSelector)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 38)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(970, 60)
        Me.pnlInfo.TabIndex = 10
        '
        'gbDrugInfo
        '
        Me.gbDrugInfo.Controls.Add(Me.cmbINSName)
        Me.gbDrugInfo.Controls.Add(Me.lblCommonName)
        Me.gbDrugInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbDrugInfo.Location = New System.Drawing.Point(396, 0)
        Me.gbDrugInfo.Name = "gbDrugInfo"
        Me.gbDrugInfo.Size = New System.Drawing.Size(451, 60)
        Me.gbDrugInfo.TabIndex = 7
        Me.gbDrugInfo.TabStop = False
        Me.gbDrugInfo.Text = "物品信息"
        '
        'cmbINSName
        '
        Me.cmbINSName.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbINSName.CodeIndex = 0
        Me.cmbINSName.DisplayIndex = 1
        Me.cmbINSName.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbINSName.FormattingEnabled = True
        Me.cmbINSName.IDContent = Nothing
        Me.cmbINSName.IDIndex = 2
        Me.cmbINSName.IsIgnoreEnter = False
        Me.cmbINSName.IsSelectCont = False
        Me.cmbINSName.Location = New System.Drawing.Point(104, 29)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(154, 24)
        Me.cmbINSName.TabIndex = 30
        Me.cmbINSName.VisibleRowCount = 10
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(26, 32)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(72, 16)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "物品名称"
        '
        'pnlSep
        '
        Me.pnlSep.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSep.Location = New System.Drawing.Point(386, 0)
        Me.pnlSep.Name = "pnlSep"
        Me.pnlSep.Size = New System.Drawing.Size(10, 60)
        Me.pnlSep.TabIndex = 6
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Fore_Color = System.Drawing.Color.Black
        Me.btnRefresh.ForeColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Location = New System.Drawing.Point(889, 25)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "刷新"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.TipText = ""
        '
        'gbDateSelector
        '
        Me.gbDateSelector.Controls.Add(Me.lblSpan)
        Me.gbDateSelector.Controls.Add(Me.dtpEnd)
        Me.gbDateSelector.Controls.Add(Me.dtpStart)
        Me.gbDateSelector.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbDateSelector.Location = New System.Drawing.Point(0, 0)
        Me.gbDateSelector.Name = "gbDateSelector"
        Me.gbDateSelector.Size = New System.Drawing.Size(386, 60)
        Me.gbDateSelector.TabIndex = 0
        Me.gbDateSelector.TabStop = False
        Me.gbDateSelector.Text = "时间范围"
        '
        'lblSpan
        '
        Me.lblSpan.AutoSize = True
        Me.lblSpan.Location = New System.Drawing.Point(195, 37)
        Me.lblSpan.Name = "lblSpan"
        Me.lblSpan.Size = New System.Drawing.Size(16, 16)
        Me.lblSpan.TabIndex = 21
        Me.lblSpan.Text = "~"
        Me.lblSpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "yyyy-MM-dd"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(223, 25)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(154, 26)
        Me.dtpEnd.TabIndex = 20
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "yyyy-MM-dd"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(26, 25)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(154, 26)
        Me.dtpStart.TabIndex = 19
        '
        'tvType
        '
        Me.tvType.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvType.Location = New System.Drawing.Point(0, 98)
        Me.tvType.Name = "tvType"
        TreeNode1.Name = "nodeWHIn"
        TreeNode1.Text = "入库"
        TreeNode2.Name = "nodeOut"
        TreeNode2.Text = "出库"
        TreeNode3.Name = "nodeIn_"
        TreeNode3.Text = "入充"
        TreeNode4.Name = "nodeOut_"
        TreeNode4.Text = "出充"
        TreeNode5.Name = "nodeExpried"
        TreeNode5.Text = "过期出库"
        TreeNode6.Name = "Node0"
        TreeNode6.Text = "库房物品"
        TreeNode7.Name = "nodeDrugIn"
        TreeNode7.Text = "入库"
        TreeNode8.Name = "nodeDrugOut"
        TreeNode8.Text = "出库"
        TreeNode9.Name = "nodeDrugChangeIn"
        TreeNode9.Text = "入充"
        TreeNode10.Name = "nodeDrugChangeOut"
        TreeNode10.Text = "出充"
        TreeNode11.Name = "nodeDrugEcpried"
        TreeNode11.Text = "过期出库"
        TreeNode12.Name = "nodeDrug"
        TreeNode12.Text = "药品"
        TreeNode13.Name = "nodeINSDispatchIn"
        TreeNode13.Text = "发放入库"
        TreeNode14.Name = "nodeUseOut"
        TreeNode14.Text = "使用出库"
        TreeNode15.Name = "nodeINSExpried"
        TreeNode15.Text = "过期出库"
        TreeNode16.Name = "nodeINS"
        TreeNode16.Text = "器械类"
        Me.tvType.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode12, TreeNode16})
        Me.tvType.Size = New System.Drawing.Size(274, 461)
        Me.tvType.TabIndex = 11
        '
        'dgv
        '
        Me.dgv.AllowDelete = True
        Me.dgv.AllowSelectChangeRow = False
        Me.dgv.AllowSort = True
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv.BeQuerying = False
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv.ChangeHeaderSize = False
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.Location = New System.Drawing.Point(274, 98)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.NoItemAlter = ""
        Me.dgv.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelCombineKeyEnable = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.ShowSelectionColor = True
        Me.dgv.Size = New System.Drawing.Size(696, 461)
        Me.dgv.TabIndex = 12
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnTotal)
        Me.pnlFunc.Controls.Add(Me.btnDetail)
        Me.pnlFunc.Controls.Add(Me.btnExport)
        Me.pnlFunc.Controls.Add(Me.btnPrint)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 559)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(970, 38)
        Me.pnlFunc.TabIndex = 13
        '
        'btnTotal
        '
        Me.btnTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTotal.BackColor = System.Drawing.Color.Transparent
        Me.btnTotal.Fore_Color = System.Drawing.Color.Black
        Me.btnTotal.ForeColor = System.Drawing.Color.Transparent
        Me.btnTotal.Location = New System.Drawing.Point(649, 4)
        Me.btnTotal.Name = "btnTotal"
        Me.btnTotal.Size = New System.Drawing.Size(75, 30)
        Me.btnTotal.TabIndex = 4
        Me.btnTotal.Text = "总计"
        Me.btnTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTotal.TipText = ""
        '
        'btnDetail
        '
        Me.btnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetail.BackColor = System.Drawing.Color.Transparent
        Me.btnDetail.Fore_Color = System.Drawing.Color.Black
        Me.btnDetail.ForeColor = System.Drawing.Color.Transparent
        Me.btnDetail.Location = New System.Drawing.Point(730, 4)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(75, 30)
        Me.btnDetail.TabIndex = 3
        Me.btnDetail.Text = "详细"
        Me.btnDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDetail.TipText = ""
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.Color.Transparent
        Me.btnExport.Fore_Color = System.Drawing.Color.Black
        Me.btnExport.ForeColor = System.Drawing.Color.Transparent
        Me.btnExport.Location = New System.Drawing.Point(889, 4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 30)
        Me.btnExport.TabIndex = 2
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
        Me.btnPrint.Location = New System.Drawing.Point(811, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 30)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "打印"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.TipText = ""
        '
        'FrmWareHouseInOutQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.tvType)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlFunc)
        Me.Name = "FrmWareHouseInOutQuery"
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.pnlInfo, 0)
        Me.Controls.SetChildIndex(Me.tvType, 0)
        Me.Controls.SetChildIndex(Me.dgv, 0)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbDrugInfo.ResumeLayout(False)
        Me.gbDrugInfo.PerformLayout()
        Me.gbDateSelector.ResumeLayout(False)
        Me.gbDateSelector.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFunc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents gbDrugInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents pnlSep As System.Windows.Forms.Panel
    Friend WithEvents btnRefresh As UIControlLib.LabelEx
    Friend WithEvents gbDateSelector As System.Windows.Forms.GroupBox
    Friend WithEvents lblSpan As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents tvType As System.Windows.Forms.TreeView
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnDetail As UIControlLib.LabelEx
    Friend WithEvents btnExport As UIControlLib.LabelEx
    Friend WithEvents btnPrint As UIControlLib.LabelEx
    Friend WithEvents cmbINSName As UIControlLib.CmbDropDownList
    Friend WithEvents btnTotal As UIControlLib.LabelEx

End Class
