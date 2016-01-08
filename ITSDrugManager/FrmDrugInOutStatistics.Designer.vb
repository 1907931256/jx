Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDrugInOutStatistics
    Inherits MyUserControlBase

    'UserControl 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("药品入库")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("药品出入库", New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.gbDrugInfo = New System.Windows.Forms.GroupBox()
        Me.ddlCommonName = New UIControlLib.UIDropDownList(Me.components)
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.ddlProductName = New UIControlLib.UIDropDownList(Me.components)
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.pnlSep = New System.Windows.Forms.Panel()
        Me.btnRefresh = New UIControlLib.LabelEx()
        Me.gbDateSelector = New System.Windows.Forms.GroupBox()
        Me.lblSpan = New System.Windows.Forms.Label()
        Me.dtpExpire = New System.Windows.Forms.DateTimePicker()
        Me.dtpMFG = New System.Windows.Forms.DateTimePicker()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnDetail = New UIControlLib.LabelEx()
        Me.btnExport = New UIControlLib.LabelEx()
        Me.btnPrint = New UIControlLib.LabelEx()
        Me.pnlDgv = New System.Windows.Forms.Panel()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.tvType = New System.Windows.Forms.TreeView()
        Me.pnlInfo.SuspendLayout()
        Me.gbDrugInfo.SuspendLayout()
        Me.gbDateSelector.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.pnlDgv.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.Size = New System.Drawing.Size(1074, 42)
        Me.LblTitle.Text = "药品入库登记"
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.gbDrugInfo)
        Me.pnlInfo.Controls.Add(Me.pnlSep)
        Me.pnlInfo.Controls.Add(Me.btnRefresh)
        Me.pnlInfo.Controls.Add(Me.gbDateSelector)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 42)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(1074, 60)
        Me.pnlInfo.TabIndex = 9
        '
        'gbDrugInfo
        '
        Me.gbDrugInfo.Controls.Add(Me.ddlCommonName)
        Me.gbDrugInfo.Controls.Add(Me.lblCommonName)
        Me.gbDrugInfo.Controls.Add(Me.ddlProductName)
        Me.gbDrugInfo.Controls.Add(Me.lblProductName)
        Me.gbDrugInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbDrugInfo.Location = New System.Drawing.Point(400, 0)
        Me.gbDrugInfo.Name = "gbDrugInfo"
        Me.gbDrugInfo.Size = New System.Drawing.Size(527, 60)
        Me.gbDrugInfo.TabIndex = 7
        Me.gbDrugInfo.TabStop = False
        Me.gbDrugInfo.Text = "药品信息"
        '
        'ddlCommonName
        '
        Me.ddlCommonName.ColNoOfCode = 0
        Me.ddlCommonName.ColNoOfContent = 1
        Me.ddlCommonName.ContentID = 2
        Me.ddlCommonName.DisplayContent = ""
        Me.ddlCommonName.IDContent = ""
        Me.ddlCommonName.Location = New System.Drawing.Point(101, 27)
        Me.ddlCommonName.Name = "ddlCommonName"
        Me.ddlCommonName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.ddlCommonName.Size = New System.Drawing.Size(154, 26)
        Me.ddlCommonName.TabIndex = 3
        Me.ddlCommonName.VisibleRowCount = 10
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(26, 32)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(72, 16)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "药品名称"
        '
        'ddlProductName
        '
        Me.ddlProductName.ColNoOfCode = 0
        Me.ddlProductName.ColNoOfContent = 1
        Me.ddlProductName.ContentID = 2
        Me.ddlProductName.DisplayContent = ""
        Me.ddlProductName.IDContent = ""
        Me.ddlProductName.Location = New System.Drawing.Point(358, 27)
        Me.ddlProductName.Name = "ddlProductName"
        Me.ddlProductName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.ddlProductName.Size = New System.Drawing.Size(154, 26)
        Me.ddlProductName.TabIndex = 5
        Me.ddlProductName.VisibleRowCount = 10
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(283, 32)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(72, 16)
        Me.lblProductName.TabIndex = 4
        Me.lblProductName.Text = "药品别称"
        '
        'pnlSep
        '
        Me.pnlSep.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSep.Location = New System.Drawing.Point(386, 0)
        Me.pnlSep.Name = "pnlSep"
        Me.pnlSep.Size = New System.Drawing.Size(14, 60)
        Me.pnlSep.TabIndex = 6
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Fore_Color = System.Drawing.Color.Black
        Me.btnRefresh.ForeColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Location = New System.Drawing.Point(993, 25)
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
        Me.gbDateSelector.Controls.Add(Me.dtpExpire)
        Me.gbDateSelector.Controls.Add(Me.dtpMFG)
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
        'dtpExpire
        '
        Me.dtpExpire.CustomFormat = "yyyy-MM-dd"
        Me.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpire.Location = New System.Drawing.Point(223, 25)
        Me.dtpExpire.Name = "dtpExpire"
        Me.dtpExpire.Size = New System.Drawing.Size(154, 26)
        Me.dtpExpire.TabIndex = 20
        '
        'dtpMFG
        '
        Me.dtpMFG.CustomFormat = "yyyy-MM-dd"
        Me.dtpMFG.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMFG.Location = New System.Drawing.Point(26, 25)
        Me.dtpMFG.Name = "dtpMFG"
        Me.dtpMFG.Size = New System.Drawing.Size(154, 26)
        Me.dtpMFG.TabIndex = 19
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnDetail)
        Me.pnlFunc.Controls.Add(Me.btnExport)
        Me.pnlFunc.Controls.Add(Me.btnPrint)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 516)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(1074, 39)
        Me.pnlFunc.TabIndex = 10
        '
        'btnDetail
        '
        Me.btnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetail.BackColor = System.Drawing.Color.Transparent
        Me.btnDetail.Fore_Color = System.Drawing.Color.Black
        Me.btnDetail.ForeColor = System.Drawing.Color.Transparent
        Me.btnDetail.Location = New System.Drawing.Point(993, 5)
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
        Me.btnExport.Location = New System.Drawing.Point(837, 5)
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
        Me.btnPrint.Location = New System.Drawing.Point(915, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 30)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "打印"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.TipText = ""
        '
        'pnlDgv
        '
        Me.pnlDgv.Controls.Add(Me.dgv)
        Me.pnlDgv.Controls.Add(Me.tvType)
        Me.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDgv.Location = New System.Drawing.Point(0, 102)
        Me.pnlDgv.Name = "pnlDgv"
        Me.pnlDgv.Size = New System.Drawing.Size(1074, 414)
        Me.pnlDgv.TabIndex = 11
        '
        'dgv
        '
        Me.dgv.AllowDelete = True
        Me.dgv.AllowSort = True
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
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
        Me.dgv.Location = New System.Drawing.Point(274, 0)
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
        Me.dgv.Size = New System.Drawing.Size(800, 414)
        Me.dgv.TabIndex = 1
        '
        'tvType
        '
        Me.tvType.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvType.Location = New System.Drawing.Point(0, 0)
        Me.tvType.Name = "tvType"
        TreeNode1.Name = "Node1"
        TreeNode1.Text = "药品入库"
        TreeNode2.Name = "Node0"
        TreeNode2.Text = "药品出入库"
        Me.tvType.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.tvType.Size = New System.Drawing.Size(274, 414)
        Me.tvType.TabIndex = 0
        '
        'FrmDrugInOutStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDgv)
        Me.Controls.Add(Me.pnlFunc)
        Me.Controls.Add(Me.pnlInfo)
        Me.Name = "FrmDrugInOutStatistics"
        Me.Size = New System.Drawing.Size(1074, 555)
        Me.Controls.SetChildIndex(Me.LblTitle, 0)
        Me.Controls.SetChildIndex(Me.pnlInfo, 0)
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.pnlDgv, 0)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbDrugInfo.ResumeLayout(False)
        Me.gbDrugInfo.PerformLayout()
        Me.gbDateSelector.ResumeLayout(False)
        Me.gbDateSelector.PerformLayout()
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlDgv.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents pnlDgv As System.Windows.Forms.Panel
    Friend WithEvents btnDetail As UIControlLib.LabelEx
    Friend WithEvents btnExport As UIControlLib.LabelEx
    Friend WithEvents btnPrint As UIControlLib.LabelEx
    Friend WithEvents gbDateSelector As System.Windows.Forms.GroupBox
    Friend WithEvents dtpExpire As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpMFG As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents tvType As System.Windows.Forms.TreeView
    Friend WithEvents btnRefresh As UIControlLib.LabelEx
    Friend WithEvents gbDrugInfo As System.Windows.Forms.GroupBox
    Friend WithEvents ddlCommonName As UIControlLib.UIDropDownList
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents ddlProductName As UIControlLib.UIDropDownList
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents pnlSep As System.Windows.Forms.Panel
    Friend WithEvents lblSpan As System.Windows.Forms.Label

End Class
