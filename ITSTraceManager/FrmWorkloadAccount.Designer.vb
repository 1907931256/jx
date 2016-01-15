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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.pnlLayoutSetting = New System.Windows.Forms.Panel()
        Me.gbCondition = New System.Windows.Forms.GroupBox()
        Me.pnlItemsSel = New System.Windows.Forms.Panel()
        Me.dgvItemsSel = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.dgvItemsSel1 = New UIControlLib.UIDataGridView()
        Me.lblItemsSel = New UIControlLib.LabelEx()
        Me.lblSep3 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblSep2 = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.lblSep1 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lblSep0 = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.pnlSettingFunc = New System.Windows.Forms.Panel()
        Me.btnAccount = New DevComponents.DotNetBar.ButtonX()
        Me.pnlTraceContainer = New System.Windows.Forms.Panel()
        Me.pnlAccount = New System.Windows.Forms.Panel()
        Me.dgvAccount = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.dgvAccount1 = New UIControlLib.UIDataGridView()
        Me.chtAccount = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlAccountFunc = New System.Windows.Forms.Panel()
        Me.btnDetail = New DevComponents.DotNetBar.ButtonX()
        Me.btnOutline = New DevComponents.DotNetBar.ButtonX()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.pnlLayoutSetting.SuspendLayout()
        Me.gbCondition.SuspendLayout()
        Me.pnlItemsSel.SuspendLayout()
        CType(Me.dgvItemsSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemsSel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSettingFunc.SuspendLayout()
        Me.pnlTraceContainer.SuspendLayout()
        Me.pnlAccount.SuspendLayout()
        CType(Me.dgvAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAccountFunc.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLayoutSetting
        '
        Me.pnlLayoutSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLayoutSetting.Controls.Add(Me.gbCondition)
        Me.pnlLayoutSetting.Controls.Add(Me.pnlSettingFunc)
        Me.pnlLayoutSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayoutSetting.Location = New System.Drawing.Point(458, 32)
        Me.pnlLayoutSetting.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlLayoutSetting.Name = "pnlLayoutSetting"
        Me.pnlLayoutSetting.Size = New System.Drawing.Size(166, 328)
        Me.pnlLayoutSetting.TabIndex = 12
        '
        'gbCondition
        '
        Me.gbCondition.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gbCondition.Controls.Add(Me.pnlItemsSel)
        Me.gbCondition.Controls.Add(Me.lblSep3)
        Me.gbCondition.Controls.Add(Me.dtpEnd)
        Me.gbCondition.Controls.Add(Me.lblSep2)
        Me.gbCondition.Controls.Add(Me.lblEnd)
        Me.gbCondition.Controls.Add(Me.lblSep1)
        Me.gbCondition.Controls.Add(Me.dtpStart)
        Me.gbCondition.Controls.Add(Me.lblSep0)
        Me.gbCondition.Controls.Add(Me.lblStart)
        Me.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbCondition.Location = New System.Drawing.Point(0, 0)
        Me.gbCondition.Margin = New System.Windows.Forms.Padding(2)
        Me.gbCondition.Name = "gbCondition"
        Me.gbCondition.Padding = New System.Windows.Forms.Padding(2)
        Me.gbCondition.Size = New System.Drawing.Size(164, 300)
        Me.gbCondition.TabIndex = 7
        Me.gbCondition.TabStop = False
        '
        'pnlItemsSel
        '
        Me.pnlItemsSel.Controls.Add(Me.dgvItemsSel)
        Me.pnlItemsSel.Controls.Add(Me.dgvItemsSel1)
        Me.pnlItemsSel.Controls.Add(Me.lblItemsSel)
        Me.pnlItemsSel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlItemsSel.Location = New System.Drawing.Point(2, 116)
        Me.pnlItemsSel.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlItemsSel.Name = "pnlItemsSel"
        Me.pnlItemsSel.Size = New System.Drawing.Size(160, 182)
        Me.pnlItemsSel.TabIndex = 19
        '
        'dgvItemsSel
        '
        Me.dgvItemsSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItemsSel.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItemsSel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemsSel.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvItemsSel.Location = New System.Drawing.Point(0, 22)
        Me.dgvItemsSel.Name = "dgvItemsSel"
        Me.dgvItemsSel.ReadOnly = True
        Me.dgvItemsSel.RowHeadersVisible = False
        Me.dgvItemsSel.RowTemplate.Height = 23
        Me.dgvItemsSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItemsSel.Size = New System.Drawing.Size(160, 160)
        Me.dgvItemsSel.TabIndex = 11
        '
        'dgvItemsSel1
        '
        Me.dgvItemsSel1.AllowDelete = True
        Me.dgvItemsSel1.AllowSelectChangeRow = False
        Me.dgvItemsSel1.AllowSort = True
        Me.dgvItemsSel1.AllowUserToAddRows = False
        Me.dgvItemsSel1.AllowUserToResizeColumns = False
        Me.dgvItemsSel1.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvItemsSel1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItemsSel1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvItemsSel1.BeQuerying = False
        Me.dgvItemsSel1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvItemsSel1.ChangeHeaderSize = False
        Me.dgvItemsSel1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemsSel1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItemsSel1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItemsSel1.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItemsSel1.EnableHeadersVisualStyles = False
        Me.dgvItemsSel1.Location = New System.Drawing.Point(115, 109)
        Me.dgvItemsSel1.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvItemsSel1.MultiSelect = False
        Me.dgvItemsSel1.Name = "dgvItemsSel1"
        Me.dgvItemsSel1.NoItemAlter = ""
        Me.dgvItemsSel1.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvItemsSel1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvItemsSel1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvItemsSel1.RowTemplate.Height = 23
        Me.dgvItemsSel1.SelCombineKeyEnable = False
        Me.dgvItemsSel1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItemsSel1.ShowSelectionColor = True
        Me.dgvItemsSel1.Size = New System.Drawing.Size(47, 86)
        Me.dgvItemsSel1.TabIndex = 10
        Me.dgvItemsSel1.Visible = False
        '
        'lblItemsSel
        '
        Me.lblItemsSel.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.lblItemsSel.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblItemsSel.Fore_Color = System.Drawing.Color.Black
        Me.lblItemsSel.ForeColor = System.Drawing.Color.Transparent
        Me.lblItemsSel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblItemsSel.Location = New System.Drawing.Point(0, 0)
        Me.lblItemsSel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblItemsSel.Name = "lblItemsSel"
        Me.lblItemsSel.Size = New System.Drawing.Size(160, 22)
        Me.lblItemsSel.TabIndex = 9
        Me.lblItemsSel.Text = "已选择的项："
        Me.lblItemsSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblItemsSel.TipText = ""
        '
        'lblSep3
        '
        Me.lblSep3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep3.Location = New System.Drawing.Point(2, 110)
        Me.lblSep3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep3.Name = "lblSep3"
        Me.lblSep3.Size = New System.Drawing.Size(160, 6)
        Me.lblSep3.TabIndex = 20
        '
        'dtpEnd
        '
        Me.dtpEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpEnd.Location = New System.Drawing.Point(2, 89)
        Me.dtpEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(160, 21)
        Me.dtpEnd.TabIndex = 17
        '
        'lblSep2
        '
        Me.lblSep2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep2.Location = New System.Drawing.Point(2, 81)
        Me.lblSep2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep2.Name = "lblSep2"
        Me.lblSep2.Size = New System.Drawing.Size(160, 8)
        Me.lblSep2.TabIndex = 21
        '
        'lblEnd
        '
        Me.lblEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEnd.Location = New System.Drawing.Point(2, 66)
        Me.lblEnd.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(160, 15)
        Me.lblEnd.TabIndex = 16
        Me.lblEnd.Text = "结束时间："
        '
        'lblSep1
        '
        Me.lblSep1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep1.Location = New System.Drawing.Point(2, 58)
        Me.lblSep1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(160, 8)
        Me.lblSep1.TabIndex = 18
        '
        'dtpStart
        '
        Me.dtpStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpStart.Location = New System.Drawing.Point(2, 37)
        Me.dtpStart.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(160, 21)
        Me.dtpStart.TabIndex = 14
        '
        'lblSep0
        '
        Me.lblSep0.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep0.Location = New System.Drawing.Point(2, 31)
        Me.lblSep0.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep0.Name = "lblSep0"
        Me.lblSep0.Size = New System.Drawing.Size(160, 6)
        Me.lblSep0.TabIndex = 15
        '
        'lblStart
        '
        Me.lblStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStart.Location = New System.Drawing.Point(2, 16)
        Me.lblStart.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(160, 15)
        Me.lblStart.TabIndex = 13
        Me.lblStart.Text = "开始时间："
        '
        'pnlSettingFunc
        '
        Me.pnlSettingFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlSettingFunc.Controls.Add(Me.btnAccount)
        Me.pnlSettingFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSettingFunc.Location = New System.Drawing.Point(0, 300)
        Me.pnlSettingFunc.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSettingFunc.Name = "pnlSettingFunc"
        Me.pnlSettingFunc.Size = New System.Drawing.Size(164, 26)
        Me.pnlSettingFunc.TabIndex = 8
        '
        'btnAccount
        '
        Me.btnAccount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAccount.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAccount.Location = New System.Drawing.Point(53, 2)
        Me.btnAccount.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAccount.Name = "btnAccount"
        Me.btnAccount.Size = New System.Drawing.Size(58, 22)
        Me.btnAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnAccount.TabIndex = 25
        Me.btnAccount.Text = "统计"
        '
        'pnlTraceContainer
        '
        Me.pnlTraceContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTraceContainer.Controls.Add(Me.pnlAccount)
        Me.pnlTraceContainer.Controls.Add(Me.pnlAccountFunc)
        Me.pnlTraceContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTraceContainer.Location = New System.Drawing.Point(0, 32)
        Me.pnlTraceContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlTraceContainer.Name = "pnlTraceContainer"
        Me.pnlTraceContainer.Size = New System.Drawing.Size(458, 328)
        Me.pnlTraceContainer.TabIndex = 11
        '
        'pnlAccount
        '
        Me.pnlAccount.Controls.Add(Me.dgvAccount)
        Me.pnlAccount.Controls.Add(Me.dgvAccount1)
        Me.pnlAccount.Controls.Add(Me.chtAccount)
        Me.pnlAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAccount.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccount.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlAccount.Name = "pnlAccount"
        Me.pnlAccount.Size = New System.Drawing.Size(456, 298)
        Me.pnlAccount.TabIndex = 1
        '
        'dgvAccount
        '
        Me.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccount.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAccount.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvAccount.Location = New System.Drawing.Point(0, 145)
        Me.dgvAccount.Name = "dgvAccount"
        Me.dgvAccount.ReadOnly = True
        Me.dgvAccount.RowTemplate.Height = 23
        Me.dgvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccount.Size = New System.Drawing.Size(456, 153)
        Me.dgvAccount.TabIndex = 2
        '
        'dgvAccount1
        '
        Me.dgvAccount1.AllowDelete = True
        Me.dgvAccount1.AllowSelectChangeRow = False
        Me.dgvAccount1.AllowSort = True
        Me.dgvAccount1.AllowUserToAddRows = False
        Me.dgvAccount1.AllowUserToResizeColumns = False
        Me.dgvAccount1.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvAccount1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvAccount1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvAccount1.BeQuerying = False
        Me.dgvAccount1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvAccount1.ChangeHeaderSize = False
        Me.dgvAccount1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccount1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvAccount1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccount1.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvAccount1.EnableHeadersVisualStyles = False
        Me.dgvAccount1.Location = New System.Drawing.Point(327, 198)
        Me.dgvAccount1.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvAccount1.MultiSelect = False
        Me.dgvAccount1.Name = "dgvAccount1"
        Me.dgvAccount1.NoItemAlter = ""
        Me.dgvAccount1.RowHeadersVisible = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvAccount1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvAccount1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvAccount1.RowTemplate.Height = 23
        Me.dgvAccount1.SelCombineKeyEnable = False
        Me.dgvAccount1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccount1.ShowSelectionColor = True
        Me.dgvAccount1.Size = New System.Drawing.Size(131, 101)
        Me.dgvAccount1.TabIndex = 1
        Me.dgvAccount1.Visible = False
        '
        'chtAccount
        '
        Me.chtAccount.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        ChartArea1.Name = "ChartArea1"
        Me.chtAccount.ChartAreas.Add(ChartArea1)
        Me.chtAccount.Dock = System.Windows.Forms.DockStyle.Top
        Legend1.Name = "Legend1"
        Me.chtAccount.Legends.Add(Legend1)
        Me.chtAccount.Location = New System.Drawing.Point(0, 0)
        Me.chtAccount.Margin = New System.Windows.Forms.Padding(2)
        Me.chtAccount.Name = "chtAccount"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "MainSerial"
        Series1.ToolTip = "#LEGENDTEXT: #VAL{C} 小时"
        Me.chtAccount.Series.Add(Series1)
        Me.chtAccount.Size = New System.Drawing.Size(456, 145)
        Me.chtAccount.TabIndex = 0
        Me.chtAccount.Text = "工作量统计"
        '
        'pnlAccountFunc
        '
        Me.pnlAccountFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlAccountFunc.Controls.Add(Me.btnDetail)
        Me.pnlAccountFunc.Controls.Add(Me.btnOutline)
        Me.pnlAccountFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAccountFunc.Location = New System.Drawing.Point(0, 298)
        Me.pnlAccountFunc.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlAccountFunc.Name = "pnlAccountFunc"
        Me.pnlAccountFunc.Size = New System.Drawing.Size(456, 28)
        Me.pnlAccountFunc.TabIndex = 0
        '
        'btnDetail
        '
        Me.btnDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDetail.Location = New System.Drawing.Point(63, 3)
        Me.btnDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(58, 22)
        Me.btnDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnDetail.TabIndex = 24
        Me.btnDetail.Text = "详细"
        '
        'btnOutline
        '
        Me.btnOutline.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOutline.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOutline.Location = New System.Drawing.Point(3, 3)
        Me.btnOutline.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOutline.Name = "btnOutline"
        Me.btnOutline.Size = New System.Drawing.Size(58, 22)
        Me.btnOutline.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnOutline.TabIndex = 23
        Me.btnOutline.Text = "概要"
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(624, 32)
        Me.pnlFunc.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnClose.Location = New System.Drawing.Point(3, 5)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(58, 22)
        Me.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "关闭"
        '
        'FrmWorkloadAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlLayoutSetting)
        Me.Controls.Add(Me.pnlTraceContainer)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmWorkloadAccount"
        Me.Size = New System.Drawing.Size(624, 360)
        Me.pnlLayoutSetting.ResumeLayout(False)
        Me.gbCondition.ResumeLayout(False)
        Me.pnlItemsSel.ResumeLayout(False)
        CType(Me.dgvItemsSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemsSel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSettingFunc.ResumeLayout(False)
        Me.pnlTraceContainer.ResumeLayout(False)
        Me.pnlAccount.ResumeLayout(False)
        CType(Me.dgvAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAccountFunc.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLayoutSetting As System.Windows.Forms.Panel
    Friend WithEvents gbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblSep0 As System.Windows.Forms.Label
    Friend WithEvents lblSep1 As System.Windows.Forms.Label
    Friend WithEvents pnlItemsSel As System.Windows.Forms.Panel
    Friend WithEvents dgvItemsSel1 As UIControlLib.UIDataGridView
    Friend WithEvents lblItemsSel As UIControlLib.LabelEx
    Friend WithEvents pnlTraceContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlSettingFunc As System.Windows.Forms.Panel
    Friend WithEvents pnlAccount As System.Windows.Forms.Panel
    Friend WithEvents pnlAccountFunc As System.Windows.Forms.Panel
    Friend WithEvents dgvAccount1 As UIControlLib.UIDataGridView
    Friend WithEvents chtAccount As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblSep2 As System.Windows.Forms.Label
    Friend WithEvents lblSep3 As System.Windows.Forms.Label
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgvAccount As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnDetail As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOutline As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgvItemsSel As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnAccount As DevComponents.DotNetBar.ButtonX

End Class
