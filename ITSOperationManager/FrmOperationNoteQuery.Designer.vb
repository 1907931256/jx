﻿Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperationNoteQuery
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
        Me.pnlQuery = New System.Windows.Forms.Panel()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefresh = New UIControlLib.LabelEx()
        Me.cmbSurRoom = New System.Windows.Forms.ComboBox()
        Me.lblSurRoom = New System.Windows.Forms.Label()
        Me.dtpTimeEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblTimeTo = New System.Windows.Forms.Label()
        Me.dtpTimeStart = New System.Windows.Forms.DateTimePicker()
        Me.lblSurTime = New System.Windows.Forms.Label()
        Me.pnlFunction = New System.Windows.Forms.Panel()
        Me.btnRecycle = New DevComponents.DotNetBar.ButtonX()
        Me.btnUse = New DevComponents.DotNetBar.ButtonX()
        Me.btnFrontUse = New DevComponents.DotNetBar.ButtonX()
        Me.btnRequest = New DevComponents.DotNetBar.ButtonX()
        Me.btnRequestAll = New DevComponents.DotNetBar.ButtonX()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlQuery.SuspendLayout()
        Me.pnlFunction.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlQuery
        '
        Me.pnlQuery.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQuery.Controls.Add(Me.cmbStatus)
        Me.pnlQuery.Controls.Add(Me.Label1)
        Me.pnlQuery.Controls.Add(Me.btnRefresh)
        Me.pnlQuery.Controls.Add(Me.cmbSurRoom)
        Me.pnlQuery.Controls.Add(Me.lblSurRoom)
        Me.pnlQuery.Controls.Add(Me.dtpTimeEnd)
        Me.pnlQuery.Controls.Add(Me.lblTimeTo)
        Me.pnlQuery.Controls.Add(Me.dtpTimeStart)
        Me.pnlQuery.Controls.Add(Me.lblSurTime)
        Me.pnlQuery.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlQuery.Location = New System.Drawing.Point(0, 28)
        Me.pnlQuery.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlQuery.Name = "pnlQuery"
        Me.pnlQuery.Size = New System.Drawing.Size(786, 39)
        Me.pnlQuery.TabIndex = 9
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(480, 12)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(92, 20)
        Me.cmbStatus.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(446, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "状态"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Fore_Color = System.Drawing.Color.Black
        Me.btnRefresh.ForeColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Location = New System.Drawing.Point(736, 9)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(46, 22)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "刷新"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.TipText = ""
        '
        'cmbSurRoom
        '
        Me.cmbSurRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSurRoom.FormattingEnabled = True
        Me.cmbSurRoom.Location = New System.Drawing.Point(346, 11)
        Me.cmbSurRoom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbSurRoom.Name = "cmbSurRoom"
        Me.cmbSurRoom.Size = New System.Drawing.Size(92, 20)
        Me.cmbSurRoom.TabIndex = 5
        '
        'lblSurRoom
        '
        Me.lblSurRoom.AutoSize = True
        Me.lblSurRoom.Location = New System.Drawing.Point(304, 14)
        Me.lblSurRoom.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurRoom.Name = "lblSurRoom"
        Me.lblSurRoom.Size = New System.Drawing.Size(41, 12)
        Me.lblSurRoom.TabIndex = 4
        Me.lblSurRoom.Text = "手术间"
        '
        'dtpTimeEnd
        '
        Me.dtpTimeEnd.Location = New System.Drawing.Point(186, 10)
        Me.dtpTimeEnd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpTimeEnd.Name = "dtpTimeEnd"
        Me.dtpTimeEnd.Size = New System.Drawing.Size(102, 21)
        Me.dtpTimeEnd.TabIndex = 3
        '
        'lblTimeTo
        '
        Me.lblTimeTo.AutoSize = True
        Me.lblTimeTo.Location = New System.Drawing.Point(166, 14)
        Me.lblTimeTo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTimeTo.Name = "lblTimeTo"
        Me.lblTimeTo.Size = New System.Drawing.Size(17, 12)
        Me.lblTimeTo.TabIndex = 2
        Me.lblTimeTo.Text = "至"
        '
        'dtpTimeStart
        '
        Me.dtpTimeStart.Location = New System.Drawing.Point(61, 10)
        Me.dtpTimeStart.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpTimeStart.Name = "dtpTimeStart"
        Me.dtpTimeStart.Size = New System.Drawing.Size(102, 21)
        Me.dtpTimeStart.TabIndex = 1
        '
        'lblSurTime
        '
        Me.lblSurTime.AutoSize = True
        Me.lblSurTime.Location = New System.Drawing.Point(4, 14)
        Me.lblSurTime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurTime.Name = "lblSurTime"
        Me.lblSurTime.Size = New System.Drawing.Size(53, 12)
        Me.lblSurTime.TabIndex = 0
        Me.lblSurTime.Text = "手术时间"
        '
        'pnlFunction
        '
        Me.pnlFunction.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunction.Controls.Add(Me.btnRecycle)
        Me.pnlFunction.Controls.Add(Me.btnUse)
        Me.pnlFunction.Controls.Add(Me.btnFrontUse)
        Me.pnlFunction.Controls.Add(Me.btnRequest)
        Me.pnlFunction.Controls.Add(Me.btnRequestAll)
        Me.pnlFunction.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunction.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunction.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlFunction.Name = "pnlFunction"
        Me.pnlFunction.Size = New System.Drawing.Size(786, 28)
        Me.pnlFunction.TabIndex = 10
        '
        'btnRecycle
        '
        Me.btnRecycle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRecycle.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRecycle.Location = New System.Drawing.Point(244, 3)
        Me.btnRecycle.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRecycle.Name = "btnRecycle"
        Me.btnRecycle.Size = New System.Drawing.Size(58, 22)
        Me.btnRecycle.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnRecycle.TabIndex = 9
        Me.btnRecycle.Text = "回收登记"
        '
        'btnUse
        '
        Me.btnUse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUse.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnUse.Location = New System.Drawing.Point(184, 3)
        Me.btnUse.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnUse.Name = "btnUse"
        Me.btnUse.Size = New System.Drawing.Size(58, 22)
        Me.btnUse.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnUse.TabIndex = 8
        Me.btnUse.Text = "使用登记"
        '
        'btnFrontUse
        '
        Me.btnFrontUse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFrontUse.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnFrontUse.Location = New System.Drawing.Point(124, 3)
        Me.btnFrontUse.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnFrontUse.Name = "btnFrontUse"
        Me.btnFrontUse.Size = New System.Drawing.Size(58, 22)
        Me.btnFrontUse.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnFrontUse.TabIndex = 7
        Me.btnFrontUse.Text = "拆包登记"
        '
        'btnRequest
        '
        Me.btnRequest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRequest.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRequest.Location = New System.Drawing.Point(64, 3)
        Me.btnRequest.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(58, 22)
        Me.btnRequest.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnRequest.TabIndex = 6
        Me.btnRequest.Text = "请领登记"
        '
        'btnRequestAll
        '
        Me.btnRequestAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRequestAll.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRequestAll.Location = New System.Drawing.Point(4, 3)
        Me.btnRequestAll.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRequestAll.Name = "btnRequestAll"
        Me.btnRequestAll.Size = New System.Drawing.Size(58, 22)
        Me.btnRequestAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnRequestAll.TabIndex = 5
        Me.btnRequestAll.Text = "一键请领"
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
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.Location = New System.Drawing.Point(0, 67)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.NoItemAlter = ""
        Me.dgv.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelCombineKeyEnable = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.ShowSelectionColor = True
        Me.dgv.Size = New System.Drawing.Size(786, 436)
        Me.dgv.TabIndex = 11
        '
        'FrmOperationNoteQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.pnlQuery)
        Me.Controls.Add(Me.pnlFunction)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmOperationNoteQuery"
        Me.Size = New System.Drawing.Size(786, 503)
        Me.pnlQuery.ResumeLayout(False)
        Me.pnlQuery.PerformLayout()
        Me.pnlFunction.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlQuery As System.Windows.Forms.Panel
    Friend WithEvents pnlFunction As System.Windows.Forms.Panel
    Friend WithEvents dgv As UIDataGridView
    Friend WithEvents cmbSurRoom As System.Windows.Forms.ComboBox
    Friend WithEvents lblSurRoom As System.Windows.Forms.Label
    Friend WithEvents dtpTimeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTimeTo As System.Windows.Forms.Label
    Friend WithEvents dtpTimeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSurTime As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As UIControlLib.LabelEx
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRequestAll As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRequest As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRecycle As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUse As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnFrontUse As DevComponents.DotNetBar.ButtonX

End Class