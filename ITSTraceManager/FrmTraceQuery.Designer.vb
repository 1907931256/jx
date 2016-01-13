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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlLayoutSetting = New System.Windows.Forms.Panel()
        Me.dgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.gbCondition = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.playProgress = New System.Windows.Forms.ProgressBar()
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
        Me.dgv1 = New UIControlLib.UIDataGridView()
        Me.pnlTraceContainer = New System.Windows.Forms.Panel()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.pnlLayoutSetting.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCondition.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTraceContainer.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLayoutSetting
        '
        Me.pnlLayoutSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLayoutSetting.Controls.Add(Me.dgv)
        Me.pnlLayoutSetting.Controls.Add(Me.gbCondition)
        Me.pnlLayoutSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayoutSetting.Location = New System.Drawing.Point(458, 32)
        Me.pnlLayoutSetting.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlLayoutSetting.Name = "pnlLayoutSetting"
        Me.pnlLayoutSetting.Size = New System.Drawing.Size(166, 328)
        Me.pnlLayoutSetting.TabIndex = 12
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
        Me.dgv.Location = New System.Drawing.Point(0, 208)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(164, 118)
        Me.dgv.TabIndex = 8
        '
        'gbCondition
        '
        Me.gbCondition.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
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
        Me.gbCondition.Margin = New System.Windows.Forms.Padding(2)
        Me.gbCondition.Name = "gbCondition"
        Me.gbCondition.Padding = New System.Windows.Forms.Padding(2)
        Me.gbCondition.Size = New System.Drawing.Size(164, 208)
        Me.gbCondition.TabIndex = 7
        Me.gbCondition.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.playProgress)
        Me.Panel1.Controls.Add(Me.btnPlay)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 183)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 27)
        Me.Panel1.TabIndex = 20
        '
        'playProgress
        '
        Me.playProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.playProgress.Location = New System.Drawing.Point(0, 0)
        Me.playProgress.Margin = New System.Windows.Forms.Padding(2)
        Me.playProgress.Name = "playProgress"
        Me.playProgress.Size = New System.Drawing.Size(133, 27)
        Me.playProgress.TabIndex = 2
        '
        'btnPlay
        '
        Me.btnPlay.BackgroundImage = Global.ITSTraceManager.My.Resources.Resources.play1
        Me.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPlay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPlay.Location = New System.Drawing.Point(133, 0)
        Me.btnPlay.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(27, 27)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'lblSep3
        '
        Me.lblSep3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep3.Location = New System.Drawing.Point(2, 177)
        Me.lblSep3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep3.Name = "lblSep3"
        Me.lblSep3.Size = New System.Drawing.Size(160, 6)
        Me.lblSep3.TabIndex = 18
        '
        'dtpEnd
        '
        Me.dtpEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpEnd.Location = New System.Drawing.Point(2, 156)
        Me.dtpEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(160, 21)
        Me.dtpEnd.TabIndex = 17
        '
        'lblEnd
        '
        Me.lblEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEnd.Location = New System.Drawing.Point(2, 141)
        Me.lblEnd.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(160, 15)
        Me.lblEnd.TabIndex = 16
        Me.lblEnd.Text = "结束时间："
        '
        'lblSep2
        '
        Me.lblSep2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep2.Location = New System.Drawing.Point(2, 135)
        Me.lblSep2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep2.Name = "lblSep2"
        Me.lblSep2.Size = New System.Drawing.Size(160, 6)
        Me.lblSep2.TabIndex = 15
        '
        'dtpStart
        '
        Me.dtpStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpStart.Location = New System.Drawing.Point(2, 114)
        Me.dtpStart.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(160, 21)
        Me.dtpStart.TabIndex = 14
        '
        'lblStart
        '
        Me.lblStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStart.Location = New System.Drawing.Point(2, 99)
        Me.lblStart.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(160, 15)
        Me.lblStart.TabIndex = 13
        Me.lblStart.Text = "开始时间："
        '
        'lblSep1
        '
        Me.lblSep1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep1.Location = New System.Drawing.Point(2, 93)
        Me.lblSep1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(160, 6)
        Me.lblSep1.TabIndex = 12
        '
        'tbNameFilter
        '
        Me.tbNameFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbNameFilter.Location = New System.Drawing.Point(2, 72)
        Me.tbNameFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.tbNameFilter.Name = "tbNameFilter"
        Me.tbNameFilter.Size = New System.Drawing.Size(160, 21)
        Me.tbNameFilter.TabIndex = 11
        '
        'lblNameFilter
        '
        Me.lblNameFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNameFilter.Location = New System.Drawing.Point(2, 57)
        Me.lblNameFilter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNameFilter.Name = "lblNameFilter"
        Me.lblNameFilter.Size = New System.Drawing.Size(160, 15)
        Me.lblNameFilter.TabIndex = 10
        Me.lblNameFilter.Text = "名称过滤："
        '
        'lblSep0
        '
        Me.lblSep0.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep0.Location = New System.Drawing.Point(2, 51)
        Me.lblSep0.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep0.Name = "lblSep0"
        Me.lblSep0.Size = New System.Drawing.Size(160, 6)
        Me.lblSep0.TabIndex = 8
        '
        'cmbCategory
        '
        Me.cmbCategory.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(2, 31)
        Me.cmbCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(160, 20)
        Me.cmbCategory.TabIndex = 7
        '
        'lblCategory
        '
        Me.lblCategory.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCategory.Location = New System.Drawing.Point(2, 16)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(160, 15)
        Me.lblCategory.TabIndex = 1
        Me.lblCategory.Text = "所属类别："
        '
        'dgv1
        '
        Me.dgv1.AllowDelete = True
        Me.dgv1.AllowSelectChangeRow = False
        Me.dgv1.AllowSort = True
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToResizeColumns = False
        Me.dgv1.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv1.BeQuerying = False
        Me.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv1.ChangeHeaderSize = False
        Me.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv1.EnableHeadersVisualStyles = False
        Me.dgv1.Location = New System.Drawing.Point(341, 235)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.NoItemAlter = ""
        Me.dgv1.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv1.RowTemplate.Height = 23
        Me.dgv1.SelCombineKeyEnable = False
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.ShowSelectionColor = True
        Me.dgv1.Size = New System.Drawing.Size(93, 56)
        Me.dgv1.TabIndex = 8
        Me.dgv1.Visible = False
        '
        'pnlTraceContainer
        '
        Me.pnlTraceContainer.Controls.Add(Me.dgv1)
        Me.pnlTraceContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTraceContainer.Location = New System.Drawing.Point(0, 32)
        Me.pnlTraceContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlTraceContainer.Name = "pnlTraceContainer"
        Me.pnlTraceContainer.Size = New System.Drawing.Size(458, 328)
        Me.pnlTraceContainer.TabIndex = 11
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(624, 32)
        Me.pnlFunc.TabIndex = 14
        '
        'btnClose
        '
        Me.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnClose.Location = New System.Drawing.Point(4, 5)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(58, 22)
        Me.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "关闭"
        '
        'FrmTraceQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlLayoutSetting)
        Me.Controls.Add(Me.pnlTraceContainer)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmTraceQuery"
        Me.Size = New System.Drawing.Size(624, 360)
        Me.pnlLayoutSetting.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCondition.ResumeLayout(False)
        Me.gbCondition.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTraceContainer.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLayoutSetting As System.Windows.Forms.Panel
    Friend WithEvents gbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents lblSep0 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents pnlTraceContainer As System.Windows.Forms.Panel
    Friend WithEvents dgv1 As UIControlLib.UIDataGridView
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
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgv As DevComponents.DotNetBar.Controls.DataGridViewX

End Class
