Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWorkloadAccount
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlLayoutSetting = New System.Windows.Forms.Panel()
        Me.gbCondition = New System.Windows.Forms.GroupBox()
        Me.pnlItemsSel = New System.Windows.Forms.Panel()
        Me.dgvItemsSel = New UIControlLib.UIDataGridView()
        Me.lblItemsSel = New UIControlLib.LabelEx()
        Me.lblSep1 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.lblSep0 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.pnlFunction = New System.Windows.Forms.Panel()
        Me.btnAccount = New UIControlLib.LabelEx()
        Me.pnlTraceContainer = New System.Windows.Forms.Panel()
        Me.pnlAccount = New System.Windows.Forms.Panel()
        Me.pnlAccountFunc = New System.Windows.Forms.Panel()
        Me.btnDetail = New UIControlLib.LabelEx()
        Me.btnOutline = New UIControlLib.LabelEx()
        Me.chtAccount = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvAccount = New UIControlLib.UIDataGridView()
        Me.pnlLayoutSetting.SuspendLayout()
        Me.gbCondition.SuspendLayout()
        Me.pnlItemsSel.SuspendLayout()
        CType(Me.dgvItemsSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFunction.SuspendLayout()
        Me.pnlTraceContainer.SuspendLayout()
        Me.pnlAccount.SuspendLayout()
        Me.pnlAccountFunc.SuspendLayout()
        CType(Me.chtAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLayoutSetting
        '
        Me.pnlLayoutSetting.Controls.Add(Me.gbCondition)
        Me.pnlLayoutSetting.Controls.Add(Me.pnlFunction)
        Me.pnlLayoutSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayoutSetting.Location = New System.Drawing.Point(610, 34)
        Me.pnlLayoutSetting.Name = "pnlLayoutSetting"
        Me.pnlLayoutSetting.Size = New System.Drawing.Size(222, 446)
        Me.pnlLayoutSetting.TabIndex = 12
        '
        'gbCondition
        '
        Me.gbCondition.Controls.Add(Me.pnlItemsSel)
        Me.gbCondition.Controls.Add(Me.lblSep1)
        Me.gbCondition.Controls.Add(Me.dtpEnd)
        Me.gbCondition.Controls.Add(Me.lblEnd)
        Me.gbCondition.Controls.Add(Me.lblSep0)
        Me.gbCondition.Controls.Add(Me.dtpStart)
        Me.gbCondition.Controls.Add(Me.lblStart)
        Me.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbCondition.Location = New System.Drawing.Point(0, 0)
        Me.gbCondition.Name = "gbCondition"
        Me.gbCondition.Size = New System.Drawing.Size(222, 409)
        Me.gbCondition.TabIndex = 7
        Me.gbCondition.TabStop = False
        Me.gbCondition.Text = "设置"
        '
        'pnlItemsSel
        '
        Me.pnlItemsSel.Controls.Add(Me.dgvItemsSel)
        Me.pnlItemsSel.Controls.Add(Me.lblItemsSel)
        Me.pnlItemsSel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlItemsSel.Location = New System.Drawing.Point(3, 132)
        Me.pnlItemsSel.Name = "pnlItemsSel"
        Me.pnlItemsSel.Size = New System.Drawing.Size(216, 274)
        Me.pnlItemsSel.TabIndex = 19
        '
        'dgvItemsSel
        '
        Me.dgvItemsSel.AllowDelete = True
        Me.dgvItemsSel.AllowSort = True
        Me.dgvItemsSel.AllowUserToAddRows = False
        Me.dgvItemsSel.AllowUserToResizeColumns = False
        Me.dgvItemsSel.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvItemsSel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItemsSel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvItemsSel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvItemsSel.ChangeHeaderSize = False
        Me.dgvItemsSel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemsSel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItemsSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItemsSel.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItemsSel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemsSel.EnableHeadersVisualStyles = False
        Me.dgvItemsSel.Location = New System.Drawing.Point(0, 30)
        Me.dgvItemsSel.MultiSelect = False
        Me.dgvItemsSel.Name = "dgvItemsSel"
        Me.dgvItemsSel.NoItemAlter = ""
        Me.dgvItemsSel.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvItemsSel.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItemsSel.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvItemsSel.RowTemplate.Height = 23
        Me.dgvItemsSel.SelCombineKeyEnable = False
        Me.dgvItemsSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItemsSel.ShowSelectionColor = True
        Me.dgvItemsSel.Size = New System.Drawing.Size(216, 244)
        Me.dgvItemsSel.TabIndex = 10
        '
        'lblItemsSel
        '
        Me.lblItemsSel.BackColor = System.Drawing.Color.Transparent
        Me.lblItemsSel.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblItemsSel.Fore_Color = System.Drawing.Color.Black
        Me.lblItemsSel.ForeColor = System.Drawing.Color.Transparent
        Me.lblItemsSel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblItemsSel.Location = New System.Drawing.Point(0, 0)
        Me.lblItemsSel.Name = "lblItemsSel"
        Me.lblItemsSel.Size = New System.Drawing.Size(216, 30)
        Me.lblItemsSel.TabIndex = 9
        Me.lblItemsSel.Text = "已选择的项："
        Me.lblItemsSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblItemsSel.TipText = ""
        '
        'lblSep1
        '
        Me.lblSep1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep1.Location = New System.Drawing.Point(3, 122)
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(216, 10)
        Me.lblSep1.TabIndex = 18
        '
        'dtpEnd
        '
        Me.dtpEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpEnd.Location = New System.Drawing.Point(3, 96)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(216, 26)
        Me.dtpEnd.TabIndex = 17
        '
        'lblEnd
        '
        Me.lblEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEnd.Location = New System.Drawing.Point(3, 76)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(216, 20)
        Me.lblEnd.TabIndex = 16
        Me.lblEnd.Text = "结束时间："
        '
        'lblSep0
        '
        Me.lblSep0.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep0.Location = New System.Drawing.Point(3, 68)
        Me.lblSep0.Name = "lblSep0"
        Me.lblSep0.Size = New System.Drawing.Size(216, 8)
        Me.lblSep0.TabIndex = 15
        '
        'dtpStart
        '
        Me.dtpStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpStart.Location = New System.Drawing.Point(3, 42)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(216, 26)
        Me.dtpStart.TabIndex = 14
        '
        'lblStart
        '
        Me.lblStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStart.Location = New System.Drawing.Point(3, 22)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(216, 20)
        Me.lblStart.TabIndex = 13
        Me.lblStart.Text = "开始时间："
        '
        'pnlFunction
        '
        Me.pnlFunction.Controls.Add(Me.btnAccount)
        Me.pnlFunction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunction.Location = New System.Drawing.Point(0, 409)
        Me.pnlFunction.Name = "pnlFunction"
        Me.pnlFunction.Size = New System.Drawing.Size(222, 37)
        Me.pnlFunction.TabIndex = 8
        '
        'btnAccount
        '
        Me.btnAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAccount.BackColor = System.Drawing.Color.Transparent
        Me.btnAccount.Fore_Color = System.Drawing.Color.Black
        Me.btnAccount.ForeColor = System.Drawing.Color.Transparent
        Me.btnAccount.Location = New System.Drawing.Point(67, 3)
        Me.btnAccount.Name = "btnAccount"
        Me.btnAccount.Size = New System.Drawing.Size(84, 30)
        Me.btnAccount.TabIndex = 8
        Me.btnAccount.Text = "统计"
        Me.btnAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAccount.TipText = ""
        '
        'pnlTraceContainer
        '
        Me.pnlTraceContainer.Controls.Add(Me.pnlAccount)
        Me.pnlTraceContainer.Controls.Add(Me.pnlAccountFunc)
        Me.pnlTraceContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTraceContainer.Location = New System.Drawing.Point(0, 34)
        Me.pnlTraceContainer.Name = "pnlTraceContainer"
        Me.pnlTraceContainer.Size = New System.Drawing.Size(610, 446)
        Me.pnlTraceContainer.TabIndex = 11
        '
        'pnlAccount
        '
        Me.pnlAccount.Controls.Add(Me.dgvAccount)
        Me.pnlAccount.Controls.Add(Me.chtAccount)
        Me.pnlAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAccount.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccount.Name = "pnlAccount"
        Me.pnlAccount.Size = New System.Drawing.Size(610, 409)
        Me.pnlAccount.TabIndex = 1
        '
        'pnlAccountFunc
        '
        Me.pnlAccountFunc.Controls.Add(Me.btnDetail)
        Me.pnlAccountFunc.Controls.Add(Me.btnOutline)
        Me.pnlAccountFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAccountFunc.Location = New System.Drawing.Point(0, 409)
        Me.pnlAccountFunc.Name = "pnlAccountFunc"
        Me.pnlAccountFunc.Size = New System.Drawing.Size(610, 37)
        Me.pnlAccountFunc.TabIndex = 0
        '
        'btnDetail
        '
        Me.btnDetail.BackColor = System.Drawing.Color.Transparent
        Me.btnDetail.Fore_Color = System.Drawing.Color.Black
        Me.btnDetail.ForeColor = System.Drawing.Color.Transparent
        Me.btnDetail.Location = New System.Drawing.Point(95, 4)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(84, 30)
        Me.btnDetail.TabIndex = 10
        Me.btnDetail.Text = "详细"
        Me.btnDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDetail.TipText = ""
        '
        'btnOutline
        '
        Me.btnOutline.BackColor = System.Drawing.Color.Transparent
        Me.btnOutline.Fore_Color = System.Drawing.Color.Black
        Me.btnOutline.ForeColor = System.Drawing.Color.Transparent
        Me.btnOutline.Location = New System.Drawing.Point(5, 4)
        Me.btnOutline.Name = "btnOutline"
        Me.btnOutline.Size = New System.Drawing.Size(84, 30)
        Me.btnOutline.TabIndex = 9
        Me.btnOutline.Text = "概要"
        Me.btnOutline.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOutline.TipText = ""
        '
        'chtAccount
        '
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.Name = "ChartArea1"
        Me.chtAccount.ChartAreas.Add(ChartArea1)
        Me.chtAccount.Dock = System.Windows.Forms.DockStyle.Top
        Legend1.Name = "Legend1"
        Me.chtAccount.Legends.Add(Legend1)
        Me.chtAccount.Location = New System.Drawing.Point(0, 0)
        Me.chtAccount.Name = "chtAccount"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "MainSerial"
        Series1.ToolTip = "#LEGENDTEXT: #VAL{C} 小时"
        Me.chtAccount.Series.Add(Series1)
        Me.chtAccount.Size = New System.Drawing.Size(610, 193)
        Me.chtAccount.TabIndex = 0
        Me.chtAccount.Text = "工作量统计"
        '
        'dgvAccount
        '
        Me.dgvAccount.AllowDelete = True
        Me.dgvAccount.AllowSort = True
        Me.dgvAccount.AllowUserToAddRows = False
        Me.dgvAccount.AllowUserToResizeColumns = False
        Me.dgvAccount.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvAccount.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAccount.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvAccount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvAccount.ChangeHeaderSize = False
        Me.dgvAccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccount.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAccount.EnableHeadersVisualStyles = False
        Me.dgvAccount.Location = New System.Drawing.Point(0, 193)
        Me.dgvAccount.MultiSelect = False
        Me.dgvAccount.Name = "dgvAccount"
        Me.dgvAccount.NoItemAlter = ""
        Me.dgvAccount.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvAccount.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvAccount.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvAccount.RowTemplate.Height = 23
        Me.dgvAccount.SelCombineKeyEnable = False
        Me.dgvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccount.ShowSelectionColor = True
        Me.dgvAccount.Size = New System.Drawing.Size(610, 216)
        Me.dgvAccount.TabIndex = 1
        '
        'FrmWorkloadAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlLayoutSetting)
        Me.Controls.Add(Me.pnlTraceContainer)
        Me.Name = "FrmWorkloadAccount"
        Me.Size = New System.Drawing.Size(832, 480)
        Me.Controls.SetChildIndex(Me.pnlTraceContainer, 0)
        Me.Controls.SetChildIndex(Me.pnlLayoutSetting, 0)
        Me.pnlLayoutSetting.ResumeLayout(False)
        Me.gbCondition.ResumeLayout(False)
        Me.pnlItemsSel.ResumeLayout(False)
        CType(Me.dgvItemsSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFunction.ResumeLayout(False)
        Me.pnlTraceContainer.ResumeLayout(False)
        Me.pnlAccount.ResumeLayout(False)
        Me.pnlAccountFunc.ResumeLayout(False)
        CType(Me.chtAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLayoutSetting As System.Windows.Forms.Panel
    Friend WithEvents gbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblSep0 As System.Windows.Forms.Label
    Friend WithEvents btnAccount As UIControlLib.LabelEx
    Friend WithEvents lblSep1 As System.Windows.Forms.Label
    Friend WithEvents pnlItemsSel As System.Windows.Forms.Panel
    Friend WithEvents dgvItemsSel As UIControlLib.UIDataGridView
    Friend WithEvents lblItemsSel As UIControlLib.LabelEx
    Friend WithEvents pnlTraceContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlFunction As System.Windows.Forms.Panel
    Friend WithEvents pnlAccount As System.Windows.Forms.Panel
    Friend WithEvents pnlAccountFunc As System.Windows.Forms.Panel
    Friend WithEvents btnDetail As UIControlLib.LabelEx
    Friend WithEvents btnOutline As UIControlLib.LabelEx
    Friend WithEvents dgvAccount As UIControlLib.UIDataGridView
    Friend WithEvents chtAccount As System.Windows.Forms.DataVisualization.Charting.Chart

End Class
