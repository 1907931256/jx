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
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.gbDrugInfo = New System.Windows.Forms.GroupBox()
        Me.cmbINSName = New UIControlLib.CmbDropDownList()
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.pnlSep = New System.Windows.Forms.Panel()
        Me.gbDateSelector = New System.Windows.Forms.GroupBox()
        Me.lblSpan = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.tvType = New System.Windows.Forms.TreeView()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnTotal = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.btnExport = New DevComponents.DotNetBar.ButtonX()
        Me.btnDetail = New DevComponents.DotNetBar.ButtonX()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.dgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlInfo.SuspendLayout
        Me.gbDrugInfo.SuspendLayout
        Me.gbDateSelector.SuspendLayout
        Me.pnlCommit.SuspendLayout
        Me.pnlFunc.SuspendLayout
        CType(Me.dgv,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194,Byte),Integer), CType(CType(217,Byte),Integer), CType(CType(247,Byte),Integer))
        Me.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfo.Controls.Add(Me.btnRefresh)
        Me.pnlInfo.Controls.Add(Me.gbDrugInfo)
        Me.pnlInfo.Controls.Add(Me.pnlSep)
        Me.pnlInfo.Controls.Add(Me.gbDateSelector)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 32)
        Me.pnlInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(806, 45)
        Me.pnlInfo.TabIndex = 10
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRefresh.Location = New System.Drawing.Point(742, 19)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(59, 21)
        Me.btnRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnRefresh.TabIndex = 22
        Me.btnRefresh.Text = "刷新"
        '
        'gbDrugInfo
        '
        Me.gbDrugInfo.Controls.Add(Me.cmbINSName)
        Me.gbDrugInfo.Controls.Add(Me.lblCommonName)
        Me.gbDrugInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbDrugInfo.Location = New System.Drawing.Point(298, 0)
        Me.gbDrugInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDrugInfo.Name = "gbDrugInfo"
        Me.gbDrugInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDrugInfo.Size = New System.Drawing.Size(338, 43)
        Me.gbDrugInfo.TabIndex = 7
        Me.gbDrugInfo.TabStop = false
        Me.gbDrugInfo.Text = "物品信息"
        '
        'cmbINSName
        '
        Me.cmbINSName.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbINSName.CodeIndex = 0
        Me.cmbINSName.DisplayIndex = 1
        Me.cmbINSName.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbINSName.FormattingEnabled = true
        Me.cmbINSName.IDContent = Nothing
        Me.cmbINSName.IDIndex = 2
        Me.cmbINSName.IsIgnoreEnter = false
        Me.cmbINSName.IsSelectCont = false
        Me.cmbINSName.Location = New System.Drawing.Point(78, 22)
        Me.cmbINSName.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(116, 20)
        Me.cmbINSName.TabIndex = 30
        Me.cmbINSName.VisibleRowCount = 10
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = true
        Me.lblCommonName.Location = New System.Drawing.Point(20, 24)
        Me.lblCommonName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(53, 12)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "物品名称"
        '
        'pnlSep
        '
        Me.pnlSep.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSep.Location = New System.Drawing.Point(290, 0)
        Me.pnlSep.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSep.Name = "pnlSep"
        Me.pnlSep.Size = New System.Drawing.Size(8, 43)
        Me.pnlSep.TabIndex = 6
        '
        'gbDateSelector
        '
        Me.gbDateSelector.Controls.Add(Me.lblSpan)
        Me.gbDateSelector.Controls.Add(Me.dtpEnd)
        Me.gbDateSelector.Controls.Add(Me.dtpStart)
        Me.gbDateSelector.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbDateSelector.Location = New System.Drawing.Point(0, 0)
        Me.gbDateSelector.Margin = New System.Windows.Forms.Padding(2)
        Me.gbDateSelector.Name = "gbDateSelector"
        Me.gbDateSelector.Padding = New System.Windows.Forms.Padding(2)
        Me.gbDateSelector.Size = New System.Drawing.Size(290, 43)
        Me.gbDateSelector.TabIndex = 0
        Me.gbDateSelector.TabStop = false
        Me.gbDateSelector.Text = "时间范围"
        '
        'lblSpan
        '
        Me.lblSpan.AutoSize = true
        Me.lblSpan.Location = New System.Drawing.Point(146, 28)
        Me.lblSpan.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSpan.Name = "lblSpan"
        Me.lblSpan.Size = New System.Drawing.Size(11, 12)
        Me.lblSpan.TabIndex = 21
        Me.lblSpan.Text = "~"
        Me.lblSpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'dtpEnd
        '
        Me.dtpEnd.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(194,Byte),Integer), CType(CType(217,Byte),Integer), CType(CType(247,Byte),Integer))
        Me.dtpEnd.CustomFormat = "yyyy-MM-dd"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(167, 19)
        Me.dtpEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(116, 21)
        Me.dtpEnd.TabIndex = 20
        '
        'dtpStart
        '
        Me.dtpStart.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(194,Byte),Integer), CType(CType(217,Byte),Integer), CType(CType(247,Byte),Integer))
        Me.dtpStart.CustomFormat = "yyyy-MM-dd"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(20, 19)
        Me.dtpStart.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(116, 21)
        Me.dtpStart.TabIndex = 19
        '
        'tvType
        '
        Me.tvType.BackColor = System.Drawing.Color.FromArgb(CType(CType(194,Byte),Integer), CType(CType(217,Byte),Integer), CType(CType(247,Byte),Integer))
        Me.tvType.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvType.Location = New System.Drawing.Point(0, 77)
        Me.tvType.Margin = New System.Windows.Forms.Padding(2)
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
        Me.tvType.Size = New System.Drawing.Size(206, 311)
        Me.tvType.TabIndex = 11
        '
        'pnlCommit
        '
        Me.pnlCommit.BackColor = System.Drawing.Color.FromArgb(CType(CType(194,Byte),Integer), CType(CType(217,Byte),Integer), CType(CType(247,Byte),Integer))
        Me.pnlCommit.Controls.Add(Me.btnTotal)
        Me.pnlCommit.Controls.Add(Me.btnPrint)
        Me.pnlCommit.Controls.Add(Me.btnExport)
        Me.pnlCommit.Controls.Add(Me.btnDetail)
        Me.pnlCommit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommit.Location = New System.Drawing.Point(0, 388)
        Me.pnlCommit.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCommit.Name = "pnlCommit"
        Me.pnlCommit.Size = New System.Drawing.Size(806, 28)
        Me.pnlCommit.TabIndex = 13
        '
        'btnTotal
        '
        Me.btnTotal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnTotal.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnTotal.Location = New System.Drawing.Point(557, 4)
        Me.btnTotal.Name = "btnTotal"
        Me.btnTotal.Size = New System.Drawing.Size(59, 21)
        Me.btnTotal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnTotal.TabIndex = 21
        Me.btnTotal.Text = "总计"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrint.Location = New System.Drawing.Point(681, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(59, 21)
        Me.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrint.TabIndex = 20
        Me.btnPrint.Text = "打印"
        '
        'btnExport
        '
        Me.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnExport.Location = New System.Drawing.Point(743, 4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(59, 21)
        Me.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExport.TabIndex = 19
        Me.btnExport.Text = "导出"
        '
        'btnDetail
        '
        Me.btnDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDetail.Location = New System.Drawing.Point(616, 4)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(59, 21)
        Me.btnDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDetail.TabIndex = 18
        Me.btnDetail.Text = "详细"
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194,Byte),Integer), CType(CType(217,Byte),Integer), CType(CType(247,Byte),Integer))
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
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(208,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(229,Byte),Integer))
        Me.dgv.Location = New System.Drawing.Point(206, 77)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = true
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(600, 311)
        Me.dgv.TabIndex = 48
        '
        'FrmWareHouseInOutQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.tvType)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlCommit)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmWareHouseInOutQuery"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlInfo.ResumeLayout(false)
        Me.gbDrugInfo.ResumeLayout(false)
        Me.gbDrugInfo.PerformLayout
        Me.gbDateSelector.ResumeLayout(false)
        Me.gbDateSelector.PerformLayout
        Me.pnlCommit.ResumeLayout(false)
        Me.pnlFunc.ResumeLayout(false)
        CType(Me.dgv,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents gbDrugInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents pnlSep As System.Windows.Forms.Panel
    Friend WithEvents gbDateSelector As System.Windows.Forms.GroupBox
    Friend WithEvents lblSpan As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents tvType As System.Windows.Forms.TreeView
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents cmbINSName As UIControlLib.CmbDropDownList
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnTotal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDetail As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgv As DevComponents.DotNetBar.Controls.DataGridViewX

End Class
