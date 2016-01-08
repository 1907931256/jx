Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTraceQuery
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
        Me.pnlLayoutSetting = New System.Windows.Forms.Panel()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.gbCondition = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.lblSep3 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.lblSep2 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblSep1 = New System.Windows.Forms.Label()
        Me.tbNameFilter = New System.Windows.Forms.TextBox()
        Me.lblNameFilter = New System.Windows.Forms.Label()
        Me.lblSep0 = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.pnlTraceContainer = New System.Windows.Forms.Panel()
        Me.playProgress = New System.Windows.Forms.ProgressBar()
        Me.pnlLayoutSetting.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCondition.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLayoutSetting
        '
        Me.pnlLayoutSetting.Controls.Add(Me.dgv)
        Me.pnlLayoutSetting.Controls.Add(Me.gbCondition)
        Me.pnlLayoutSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayoutSetting.Location = New System.Drawing.Point(610, 34)
        Me.pnlLayoutSetting.Name = "pnlLayoutSetting"
        Me.pnlLayoutSetting.Size = New System.Drawing.Size(222, 446)
        Me.pnlLayoutSetting.TabIndex = 12
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
        Me.dgv.Location = New System.Drawing.Point(0, 278)
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
        Me.dgv.Size = New System.Drawing.Size(222, 168)
        Me.dgv.TabIndex = 8
        '
        'gbCondition
        '
        Me.gbCondition.Controls.Add(Me.Panel1)
        Me.gbCondition.Controls.Add(Me.lblSep3)
        Me.gbCondition.Controls.Add(Me.dtpEnd)
        Me.gbCondition.Controls.Add(Me.lblEnd)
        Me.gbCondition.Controls.Add(Me.lblSep2)
        Me.gbCondition.Controls.Add(Me.dtpStart)
        Me.gbCondition.Controls.Add(Me.lblStart)
        Me.gbCondition.Controls.Add(Me.lblSep1)
        Me.gbCondition.Controls.Add(Me.tbNameFilter)
        Me.gbCondition.Controls.Add(Me.lblNameFilter)
        Me.gbCondition.Controls.Add(Me.lblSep0)
        Me.gbCondition.Controls.Add(Me.cmbCategory)
        Me.gbCondition.Controls.Add(Me.lblCategory)
        Me.gbCondition.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbCondition.Location = New System.Drawing.Point(0, 0)
        Me.gbCondition.Name = "gbCondition"
        Me.gbCondition.Size = New System.Drawing.Size(222, 278)
        Me.gbCondition.TabIndex = 7
        Me.gbCondition.TabStop = False
        Me.gbCondition.Text = "设置"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.playProgress)
        Me.Panel1.Controls.Add(Me.btnPlay)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 236)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(216, 36)
        Me.Panel1.TabIndex = 20
        '
        'btnPlay
        '
        Me.btnPlay.BackgroundImage = Global.ITSTraceManager.My.Resources.Resources.play1
        Me.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPlay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPlay.Location = New System.Drawing.Point(180, 0)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(36, 36)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'lblSep3
        '
        Me.lblSep3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep3.Location = New System.Drawing.Point(3, 228)
        Me.lblSep3.Name = "lblSep3"
        Me.lblSep3.Size = New System.Drawing.Size(216, 8)
        Me.lblSep3.TabIndex = 18
        '
        'dtpEnd
        '
        Me.dtpEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpEnd.Location = New System.Drawing.Point(3, 202)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(216, 26)
        Me.dtpEnd.TabIndex = 17
        '
        'lblEnd
        '
        Me.lblEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEnd.Location = New System.Drawing.Point(3, 182)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(216, 20)
        Me.lblEnd.TabIndex = 16
        Me.lblEnd.Text = "结束时间："
        '
        'lblSep2
        '
        Me.lblSep2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep2.Location = New System.Drawing.Point(3, 174)
        Me.lblSep2.Name = "lblSep2"
        Me.lblSep2.Size = New System.Drawing.Size(216, 8)
        Me.lblSep2.TabIndex = 15
        '
        'dtpStart
        '
        Me.dtpStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpStart.Location = New System.Drawing.Point(3, 148)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(216, 26)
        Me.dtpStart.TabIndex = 14
        '
        'lblStart
        '
        Me.lblStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStart.Location = New System.Drawing.Point(3, 128)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(216, 20)
        Me.lblStart.TabIndex = 13
        Me.lblStart.Text = "开始时间："
        '
        'lblSep1
        '
        Me.lblSep1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep1.Location = New System.Drawing.Point(3, 120)
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(216, 8)
        Me.lblSep1.TabIndex = 12
        '
        'tbNameFilter
        '
        Me.tbNameFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbNameFilter.Location = New System.Drawing.Point(3, 94)
        Me.tbNameFilter.Name = "tbNameFilter"
        Me.tbNameFilter.Size = New System.Drawing.Size(216, 26)
        Me.tbNameFilter.TabIndex = 11
        '
        'lblNameFilter
        '
        Me.lblNameFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNameFilter.Location = New System.Drawing.Point(3, 74)
        Me.lblNameFilter.Name = "lblNameFilter"
        Me.lblNameFilter.Size = New System.Drawing.Size(216, 20)
        Me.lblNameFilter.TabIndex = 10
        Me.lblNameFilter.Text = "名称过滤："
        '
        'lblSep0
        '
        Me.lblSep0.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep0.Location = New System.Drawing.Point(3, 66)
        Me.lblSep0.Name = "lblSep0"
        Me.lblSep0.Size = New System.Drawing.Size(216, 8)
        Me.lblSep0.TabIndex = 8
        '
        'cmbCategory
        '
        Me.cmbCategory.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(3, 42)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(216, 24)
        Me.cmbCategory.TabIndex = 7
        '
        'lblCategory
        '
        Me.lblCategory.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCategory.Location = New System.Drawing.Point(3, 22)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(216, 20)
        Me.lblCategory.TabIndex = 1
        Me.lblCategory.Text = "所属类别："
        '
        'pnlTraceContainer
        '
        Me.pnlTraceContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTraceContainer.Location = New System.Drawing.Point(0, 34)
        Me.pnlTraceContainer.Name = "pnlTraceContainer"
        Me.pnlTraceContainer.Size = New System.Drawing.Size(610, 446)
        Me.pnlTraceContainer.TabIndex = 11
        '
        'playProgress
        '
        Me.playProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.playProgress.Location = New System.Drawing.Point(0, 0)
        Me.playProgress.Name = "playProgress"
        Me.playProgress.Size = New System.Drawing.Size(180, 36)
        Me.playProgress.TabIndex = 2
        '
        'FrmTraceQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlLayoutSetting)
        Me.Controls.Add(Me.pnlTraceContainer)
        Me.Name = "FrmTraceQuery"
        Me.Size = New System.Drawing.Size(832, 480)
        Me.Controls.SetChildIndex(Me.pnlTraceContainer, 0)
        Me.Controls.SetChildIndex(Me.pnlLayoutSetting, 0)
        Me.pnlLayoutSetting.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCondition.ResumeLayout(False)
        Me.gbCondition.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLayoutSetting As System.Windows.Forms.Panel
    Friend WithEvents gbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents lblSep0 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents pnlTraceContainer As System.Windows.Forms.Panel
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents lblNameFilter As System.Windows.Forms.Label
    Friend WithEvents tbNameFilter As System.Windows.Forms.TextBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblSep1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents lblSep3 As System.Windows.Forms.Label
    Friend WithEvents lblSep2 As System.Windows.Forms.Label
    Friend WithEvents playProgress As System.Windows.Forms.ProgressBar

End Class
