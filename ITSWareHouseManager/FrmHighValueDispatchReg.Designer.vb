Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHighValueDispatchReg
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
        Me.pnlToDispatch = New System.Windows.Forms.Panel()
        Me.tvToDispatch = New System.Windows.Forms.TreeView()
        Me.pnlDispatchDetail = New System.Windows.Forms.Panel()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.lblReady = New DevComponents.DotNetBar.ButtonX()
        Me.tbChecker = New System.Windows.Forms.TextBox()
        Me.lblChecker = New System.Windows.Forms.Label()
        Me.gbOrderInfo = New System.Windows.Forms.GroupBox()
        Me.tbApplyDate = New System.Windows.Forms.TextBox()
        Me.tbDoctor = New System.Windows.Forms.TextBox()
        Me.lblDoctor = New System.Windows.Forms.Label()
        Me.tbDiagnosis = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.tbVisitId = New System.Windows.Forms.TextBox()
        Me.lblVisitId = New System.Windows.Forms.Label()
        Me.tbPatName = New System.Windows.Forms.TextBox()
        Me.lblPatName = New System.Windows.Forms.Label()
        Me.tbApplyRoom = New System.Windows.Forms.TextBox()
        Me.lblApplyRoom = New System.Windows.Forms.Label()
        Me.lblApplyDate = New System.Windows.Forms.Label()
        Me.tbApplyNo = New System.Windows.Forms.TextBox()
        Me.lblApplyNo = New System.Windows.Forms.Label()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.pnlToDispatch.SuspendLayout()
        Me.pnlDispatchDetail.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCommit.SuspendLayout()
        Me.gbOrderInfo.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToDispatch
        '
        Me.pnlToDispatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlToDispatch.Controls.Add(Me.tvToDispatch)
        Me.pnlToDispatch.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlToDispatch.Location = New System.Drawing.Point(0, 32)
        Me.pnlToDispatch.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlToDispatch.Name = "pnlToDispatch"
        Me.pnlToDispatch.Size = New System.Drawing.Size(208, 384)
        Me.pnlToDispatch.TabIndex = 9
        '
        'tvToDispatch
        '
        Me.tvToDispatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tvToDispatch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvToDispatch.Location = New System.Drawing.Point(0, 0)
        Me.tvToDispatch.Margin = New System.Windows.Forms.Padding(2)
        Me.tvToDispatch.Name = "tvToDispatch"
        Me.tvToDispatch.Size = New System.Drawing.Size(206, 382)
        Me.tvToDispatch.TabIndex = 0
        '
        'pnlDispatchDetail
        '
        Me.pnlDispatchDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDispatchDetail.Controls.Add(Me.dgv)
        Me.pnlDispatchDetail.Controls.Add(Me.pnlCommit)
        Me.pnlDispatchDetail.Controls.Add(Me.gbOrderInfo)
        Me.pnlDispatchDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDispatchDetail.Location = New System.Drawing.Point(208, 32)
        Me.pnlDispatchDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlDispatchDetail.Name = "pnlDispatchDetail"
        Me.pnlDispatchDetail.Size = New System.Drawing.Size(598, 384)
        Me.pnlDispatchDetail.TabIndex = 10
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
        Me.dgv.Location = New System.Drawing.Point(0, 94)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2)
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
        Me.dgv.Size = New System.Drawing.Size(596, 258)
        Me.dgv.TabIndex = 2
        '
        'pnlCommit
        '
        Me.pnlCommit.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlCommit.Controls.Add(Me.btnCancel)
        Me.pnlCommit.Controls.Add(Me.lblReady)
        Me.pnlCommit.Controls.Add(Me.tbChecker)
        Me.pnlCommit.Controls.Add(Me.lblChecker)
        Me.pnlCommit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommit.Location = New System.Drawing.Point(0, 352)
        Me.pnlCommit.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCommit.Name = "pnlCommit"
        Me.pnlCommit.Size = New System.Drawing.Size(596, 30)
        Me.pnlCommit.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(532, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "取消"
        '
        'lblReady
        '
        Me.lblReady.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.lblReady.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReady.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.lblReady.Location = New System.Drawing.Point(469, 5)
        Me.lblReady.Name = "lblReady"
        Me.lblReady.Size = New System.Drawing.Size(59, 21)
        Me.lblReady.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblReady.TabIndex = 9
        Me.lblReady.Text = "准备发放"
        '
        'tbChecker
        '
        Me.tbChecker.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tbChecker.Location = New System.Drawing.Point(45, 5)
        Me.tbChecker.Margin = New System.Windows.Forms.Padding(2)
        Me.tbChecker.Name = "tbChecker"
        Me.tbChecker.Size = New System.Drawing.Size(86, 21)
        Me.tbChecker.TabIndex = 8
        '
        'lblChecker
        '
        Me.lblChecker.AutoSize = True
        Me.lblChecker.Location = New System.Drawing.Point(2, 9)
        Me.lblChecker.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChecker.Name = "lblChecker"
        Me.lblChecker.Size = New System.Drawing.Size(41, 12)
        Me.lblChecker.TabIndex = 7
        Me.lblChecker.Text = "审核人"
        '
        'gbOrderInfo
        '
        Me.gbOrderInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gbOrderInfo.Controls.Add(Me.tbApplyDate)
        Me.gbOrderInfo.Controls.Add(Me.tbDoctor)
        Me.gbOrderInfo.Controls.Add(Me.lblDoctor)
        Me.gbOrderInfo.Controls.Add(Me.tbDiagnosis)
        Me.gbOrderInfo.Controls.Add(Me.lblDiagnosis)
        Me.gbOrderInfo.Controls.Add(Me.tbVisitId)
        Me.gbOrderInfo.Controls.Add(Me.lblVisitId)
        Me.gbOrderInfo.Controls.Add(Me.tbPatName)
        Me.gbOrderInfo.Controls.Add(Me.lblPatName)
        Me.gbOrderInfo.Controls.Add(Me.tbApplyRoom)
        Me.gbOrderInfo.Controls.Add(Me.lblApplyRoom)
        Me.gbOrderInfo.Controls.Add(Me.lblApplyDate)
        Me.gbOrderInfo.Controls.Add(Me.tbApplyNo)
        Me.gbOrderInfo.Controls.Add(Me.lblApplyNo)
        Me.gbOrderInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbOrderInfo.Font = New System.Drawing.Font("SimSun", 11.0!)
        Me.gbOrderInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbOrderInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.gbOrderInfo.Name = "gbOrderInfo"
        Me.gbOrderInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.gbOrderInfo.Size = New System.Drawing.Size(596, 94)
        Me.gbOrderInfo.TabIndex = 0
        Me.gbOrderInfo.TabStop = False
        Me.gbOrderInfo.Text = "单据详细信息"
        '
        'tbApplyDate
        '
        Me.tbApplyDate.BackColor = System.Drawing.Color.Ivory
        Me.tbApplyDate.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbApplyDate.Location = New System.Drawing.Point(274, 21)
        Me.tbApplyDate.Margin = New System.Windows.Forms.Padding(2)
        Me.tbApplyDate.Name = "tbApplyDate"
        Me.tbApplyDate.ReadOnly = True
        Me.tbApplyDate.Size = New System.Drawing.Size(116, 21)
        Me.tbApplyDate.TabIndex = 33
        '
        'tbDoctor
        '
        Me.tbDoctor.BackColor = System.Drawing.Color.Ivory
        Me.tbDoctor.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbDoctor.Location = New System.Drawing.Point(71, 70)
        Me.tbDoctor.Margin = New System.Windows.Forms.Padding(2)
        Me.tbDoctor.Name = "tbDoctor"
        Me.tbDoctor.ReadOnly = True
        Me.tbDoctor.Size = New System.Drawing.Size(116, 21)
        Me.tbDoctor.TabIndex = 31
        '
        'lblDoctor
        '
        Me.lblDoctor.AutoSize = True
        Me.lblDoctor.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblDoctor.Location = New System.Drawing.Point(15, 74)
        Me.lblDoctor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDoctor.Name = "lblDoctor"
        Me.lblDoctor.Size = New System.Drawing.Size(53, 12)
        Me.lblDoctor.TabIndex = 30
        Me.lblDoctor.Text = "产品批号"
        '
        'tbDiagnosis
        '
        Me.tbDiagnosis.BackColor = System.Drawing.Color.Ivory
        Me.tbDiagnosis.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbDiagnosis.Location = New System.Drawing.Point(478, 46)
        Me.tbDiagnosis.Margin = New System.Windows.Forms.Padding(2)
        Me.tbDiagnosis.Multiline = True
        Me.tbDiagnosis.Name = "tbDiagnosis"
        Me.tbDiagnosis.ReadOnly = True
        Me.tbDiagnosis.Size = New System.Drawing.Size(116, 45)
        Me.tbDiagnosis.TabIndex = 29
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.AutoSize = True
        Me.lblDiagnosis.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblDiagnosis.Location = New System.Drawing.Point(410, 50)
        Me.lblDiagnosis.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(65, 12)
        Me.lblDiagnosis.TabIndex = 28
        Me.lblDiagnosis.Text = "诊      断"
        '
        'tbVisitId
        '
        Me.tbVisitId.BackColor = System.Drawing.Color.Ivory
        Me.tbVisitId.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbVisitId.Location = New System.Drawing.Point(274, 46)
        Me.tbVisitId.Margin = New System.Windows.Forms.Padding(2)
        Me.tbVisitId.Name = "tbVisitId"
        Me.tbVisitId.ReadOnly = True
        Me.tbVisitId.Size = New System.Drawing.Size(116, 21)
        Me.tbVisitId.TabIndex = 27
        '
        'lblVisitId
        '
        Me.lblVisitId.AutoSize = True
        Me.lblVisitId.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblVisitId.Location = New System.Drawing.Point(218, 50)
        Me.lblVisitId.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVisitId.Name = "lblVisitId"
        Me.lblVisitId.Size = New System.Drawing.Size(53, 12)
        Me.lblVisitId.TabIndex = 26
        Me.lblVisitId.Text = "就 诊 ID"
        '
        'tbPatName
        '
        Me.tbPatName.BackColor = System.Drawing.Color.Ivory
        Me.tbPatName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbPatName.Location = New System.Drawing.Point(71, 46)
        Me.tbPatName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbPatName.Name = "tbPatName"
        Me.tbPatName.ReadOnly = True
        Me.tbPatName.Size = New System.Drawing.Size(116, 21)
        Me.tbPatName.TabIndex = 25
        '
        'lblPatName
        '
        Me.lblPatName.AutoSize = True
        Me.lblPatName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblPatName.Location = New System.Drawing.Point(15, 50)
        Me.lblPatName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPatName.Name = "lblPatName"
        Me.lblPatName.Size = New System.Drawing.Size(53, 12)
        Me.lblPatName.TabIndex = 24
        Me.lblPatName.Text = "病人姓名"
        '
        'tbApplyRoom
        '
        Me.tbApplyRoom.BackColor = System.Drawing.Color.Ivory
        Me.tbApplyRoom.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbApplyRoom.Location = New System.Drawing.Point(478, 21)
        Me.tbApplyRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.tbApplyRoom.Name = "tbApplyRoom"
        Me.tbApplyRoom.ReadOnly = True
        Me.tbApplyRoom.Size = New System.Drawing.Size(116, 21)
        Me.tbApplyRoom.TabIndex = 23
        '
        'lblApplyRoom
        '
        Me.lblApplyRoom.AutoSize = True
        Me.lblApplyRoom.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblApplyRoom.Location = New System.Drawing.Point(410, 26)
        Me.lblApplyRoom.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblApplyRoom.Name = "lblApplyRoom"
        Me.lblApplyRoom.Size = New System.Drawing.Size(65, 12)
        Me.lblApplyRoom.TabIndex = 22
        Me.lblApplyRoom.Text = "申请手术间"
        '
        'lblApplyDate
        '
        Me.lblApplyDate.AutoSize = True
        Me.lblApplyDate.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblApplyDate.Location = New System.Drawing.Point(218, 26)
        Me.lblApplyDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblApplyDate.Name = "lblApplyDate"
        Me.lblApplyDate.Size = New System.Drawing.Size(53, 12)
        Me.lblApplyDate.TabIndex = 20
        Me.lblApplyDate.Text = "申请日期"
        '
        'tbApplyNo
        '
        Me.tbApplyNo.BackColor = System.Drawing.Color.Ivory
        Me.tbApplyNo.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbApplyNo.Location = New System.Drawing.Point(71, 21)
        Me.tbApplyNo.Margin = New System.Windows.Forms.Padding(2)
        Me.tbApplyNo.Name = "tbApplyNo"
        Me.tbApplyNo.ReadOnly = True
        Me.tbApplyNo.Size = New System.Drawing.Size(116, 21)
        Me.tbApplyNo.TabIndex = 19
        '
        'lblApplyNo
        '
        Me.lblApplyNo.AutoSize = True
        Me.lblApplyNo.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblApplyNo.Location = New System.Drawing.Point(15, 26)
        Me.lblApplyNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblApplyNo.Name = "lblApplyNo"
        Me.lblApplyNo.Size = New System.Drawing.Size(53, 12)
        Me.lblApplyNo.TabIndex = 18
        Me.lblApplyNo.Text = "申请单号"
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(806, 32)
        Me.pnlFunc.TabIndex = 16
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
        'FrmHighValueDispatchReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDispatchDetail)
        Me.Controls.Add(Me.pnlToDispatch)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmHighValueDispatchReg"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlToDispatch.ResumeLayout(False)
        Me.pnlDispatchDetail.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCommit.ResumeLayout(False)
        Me.pnlCommit.PerformLayout()
        Me.gbOrderInfo.ResumeLayout(False)
        Me.gbOrderInfo.PerformLayout()
        Me.pnlFunc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlToDispatch As System.Windows.Forms.Panel
    Friend WithEvents pnlDispatchDetail As System.Windows.Forms.Panel
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents gbOrderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents tbChecker As System.Windows.Forms.TextBox
    Friend WithEvents lblChecker As System.Windows.Forms.Label
    Friend WithEvents tbDoctor As System.Windows.Forms.TextBox
    Friend WithEvents lblDoctor As System.Windows.Forms.Label
    Friend WithEvents tbDiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents tbVisitId As System.Windows.Forms.TextBox
    Friend WithEvents lblVisitId As System.Windows.Forms.Label
    Friend WithEvents tbPatName As System.Windows.Forms.TextBox
    Friend WithEvents lblPatName As System.Windows.Forms.Label
    Friend WithEvents tbApplyRoom As System.Windows.Forms.TextBox
    Friend WithEvents lblApplyRoom As System.Windows.Forms.Label
    Friend WithEvents lblApplyDate As System.Windows.Forms.Label
    Friend WithEvents tbApplyNo As System.Windows.Forms.TextBox
    Friend WithEvents lblApplyNo As System.Windows.Forms.Label
    Friend WithEvents tvToDispatch As System.Windows.Forms.TreeView
    Friend WithEvents tbApplyDate As System.Windows.Forms.TextBox
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents lblReady As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX

End Class
