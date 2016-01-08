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
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.tbChecker = New System.Windows.Forms.TextBox()
        Me.lblChecker = New System.Windows.Forms.Label()
        Me.lblReady = New UIControlLib.LabelEx()
        Me.btnCancel = New UIControlLib.LabelEx()
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
        Me.pnlToDispatch.SuspendLayout()
        Me.pnlDispatchDetail.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFunc.SuspendLayout()
        Me.gbOrderInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToDispatch
        '
        Me.pnlToDispatch.Controls.Add(Me.tvToDispatch)
        Me.pnlToDispatch.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlToDispatch.Location = New System.Drawing.Point(0, 42)
        Me.pnlToDispatch.Name = "pnlToDispatch"
        Me.pnlToDispatch.Size = New System.Drawing.Size(277, 513)
        Me.pnlToDispatch.TabIndex = 9
        '
        'tvToDispatch
        '
        Me.tvToDispatch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvToDispatch.Location = New System.Drawing.Point(0, 0)
        Me.tvToDispatch.Name = "tvToDispatch"
        Me.tvToDispatch.Size = New System.Drawing.Size(277, 513)
        Me.tvToDispatch.TabIndex = 0
        '
        'pnlDispatchDetail
        '
        Me.pnlDispatchDetail.Controls.Add(Me.dgv)
        Me.pnlDispatchDetail.Controls.Add(Me.pnlFunc)
        Me.pnlDispatchDetail.Controls.Add(Me.gbOrderInfo)
        Me.pnlDispatchDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDispatchDetail.Location = New System.Drawing.Point(277, 42)
        Me.pnlDispatchDetail.Name = "pnlDispatchDetail"
        Me.pnlDispatchDetail.Size = New System.Drawing.Size(797, 513)
        Me.pnlDispatchDetail.TabIndex = 10
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
        Me.dgv.Location = New System.Drawing.Point(0, 126)
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
        Me.dgv.Size = New System.Drawing.Size(797, 347)
        Me.dgv.TabIndex = 2
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.tbChecker)
        Me.pnlFunc.Controls.Add(Me.lblChecker)
        Me.pnlFunc.Controls.Add(Me.lblReady)
        Me.pnlFunc.Controls.Add(Me.btnCancel)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 473)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(797, 40)
        Me.pnlFunc.TabIndex = 1
        '
        'tbChecker
        '
        Me.tbChecker.Location = New System.Drawing.Point(60, 7)
        Me.tbChecker.Name = "tbChecker"
        Me.tbChecker.Size = New System.Drawing.Size(114, 26)
        Me.tbChecker.TabIndex = 8
        '
        'lblChecker
        '
        Me.lblChecker.AutoSize = True
        Me.lblChecker.Location = New System.Drawing.Point(3, 12)
        Me.lblChecker.Name = "lblChecker"
        Me.lblChecker.Size = New System.Drawing.Size(56, 16)
        Me.lblChecker.TabIndex = 7
        Me.lblChecker.Text = "审核人"
        '
        'lblReady
        '
        Me.lblReady.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReady.BackColor = System.Drawing.Color.Transparent
        Me.lblReady.Fore_Color = System.Drawing.Color.Black
        Me.lblReady.ForeColor = System.Drawing.Color.Transparent
        Me.lblReady.Location = New System.Drawing.Point(636, 5)
        Me.lblReady.Name = "lblReady"
        Me.lblReady.Size = New System.Drawing.Size(75, 30)
        Me.lblReady.TabIndex = 6
        Me.lblReady.Text = "准备发放"
        Me.lblReady.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblReady.TipText = ""
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(717, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.TipText = ""
        '
        'gbOrderInfo
        '
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
        Me.gbOrderInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbOrderInfo.Name = "gbOrderInfo"
        Me.gbOrderInfo.Size = New System.Drawing.Size(797, 126)
        Me.gbOrderInfo.TabIndex = 0
        Me.gbOrderInfo.TabStop = False
        Me.gbOrderInfo.Text = "单据详细信息"
        '
        'tbApplyDate
        '
        Me.tbApplyDate.BackColor = System.Drawing.Color.Ivory
        Me.tbApplyDate.Location = New System.Drawing.Point(366, 28)
        Me.tbApplyDate.Name = "tbApplyDate"
        Me.tbApplyDate.ReadOnly = True
        Me.tbApplyDate.Size = New System.Drawing.Size(154, 26)
        Me.tbApplyDate.TabIndex = 33
        '
        'tbDoctor
        '
        Me.tbDoctor.BackColor = System.Drawing.Color.Ivory
        Me.tbDoctor.Location = New System.Drawing.Point(95, 94)
        Me.tbDoctor.Name = "tbDoctor"
        Me.tbDoctor.ReadOnly = True
        Me.tbDoctor.Size = New System.Drawing.Size(154, 26)
        Me.tbDoctor.TabIndex = 31
        '
        'lblDoctor
        '
        Me.lblDoctor.AutoSize = True
        Me.lblDoctor.Location = New System.Drawing.Point(20, 99)
        Me.lblDoctor.Name = "lblDoctor"
        Me.lblDoctor.Size = New System.Drawing.Size(72, 16)
        Me.lblDoctor.TabIndex = 30
        Me.lblDoctor.Text = "产品批号"
        '
        'tbDiagnosis
        '
        Me.tbDiagnosis.BackColor = System.Drawing.Color.Ivory
        Me.tbDiagnosis.Location = New System.Drawing.Point(637, 61)
        Me.tbDiagnosis.Multiline = True
        Me.tbDiagnosis.Name = "tbDiagnosis"
        Me.tbDiagnosis.ReadOnly = True
        Me.tbDiagnosis.Size = New System.Drawing.Size(154, 59)
        Me.tbDiagnosis.TabIndex = 29
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.AutoSize = True
        Me.lblDiagnosis.Location = New System.Drawing.Point(546, 66)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(88, 16)
        Me.lblDiagnosis.TabIndex = 28
        Me.lblDiagnosis.Text = "诊      断"
        '
        'tbVisitId
        '
        Me.tbVisitId.BackColor = System.Drawing.Color.Ivory
        Me.tbVisitId.Location = New System.Drawing.Point(366, 61)
        Me.tbVisitId.Name = "tbVisitId"
        Me.tbVisitId.ReadOnly = True
        Me.tbVisitId.Size = New System.Drawing.Size(154, 26)
        Me.tbVisitId.TabIndex = 27
        '
        'lblVisitId
        '
        Me.lblVisitId.AutoSize = True
        Me.lblVisitId.Location = New System.Drawing.Point(291, 66)
        Me.lblVisitId.Name = "lblVisitId"
        Me.lblVisitId.Size = New System.Drawing.Size(72, 16)
        Me.lblVisitId.TabIndex = 26
        Me.lblVisitId.Text = "就 诊 ID"
        '
        'tbPatName
        '
        Me.tbPatName.BackColor = System.Drawing.Color.Ivory
        Me.tbPatName.Location = New System.Drawing.Point(95, 61)
        Me.tbPatName.Name = "tbPatName"
        Me.tbPatName.ReadOnly = True
        Me.tbPatName.Size = New System.Drawing.Size(154, 26)
        Me.tbPatName.TabIndex = 25
        '
        'lblPatName
        '
        Me.lblPatName.AutoSize = True
        Me.lblPatName.Location = New System.Drawing.Point(20, 66)
        Me.lblPatName.Name = "lblPatName"
        Me.lblPatName.Size = New System.Drawing.Size(72, 16)
        Me.lblPatName.TabIndex = 24
        Me.lblPatName.Text = "病人姓名"
        '
        'tbApplyRoom
        '
        Me.tbApplyRoom.BackColor = System.Drawing.Color.Ivory
        Me.tbApplyRoom.Location = New System.Drawing.Point(637, 28)
        Me.tbApplyRoom.Name = "tbApplyRoom"
        Me.tbApplyRoom.ReadOnly = True
        Me.tbApplyRoom.Size = New System.Drawing.Size(154, 26)
        Me.tbApplyRoom.TabIndex = 23
        '
        'lblApplyRoom
        '
        Me.lblApplyRoom.AutoSize = True
        Me.lblApplyRoom.Location = New System.Drawing.Point(546, 34)
        Me.lblApplyRoom.Name = "lblApplyRoom"
        Me.lblApplyRoom.Size = New System.Drawing.Size(88, 16)
        Me.lblApplyRoom.TabIndex = 22
        Me.lblApplyRoom.Text = "申请手术间"
        '
        'lblApplyDate
        '
        Me.lblApplyDate.AutoSize = True
        Me.lblApplyDate.Location = New System.Drawing.Point(291, 34)
        Me.lblApplyDate.Name = "lblApplyDate"
        Me.lblApplyDate.Size = New System.Drawing.Size(72, 16)
        Me.lblApplyDate.TabIndex = 20
        Me.lblApplyDate.Text = "申请日期"
        '
        'tbApplyNo
        '
        Me.tbApplyNo.BackColor = System.Drawing.Color.Ivory
        Me.tbApplyNo.Location = New System.Drawing.Point(95, 28)
        Me.tbApplyNo.Name = "tbApplyNo"
        Me.tbApplyNo.ReadOnly = True
        Me.tbApplyNo.Size = New System.Drawing.Size(154, 26)
        Me.tbApplyNo.TabIndex = 19
        '
        'lblApplyNo
        '
        Me.lblApplyNo.AutoSize = True
        Me.lblApplyNo.Location = New System.Drawing.Point(20, 34)
        Me.lblApplyNo.Name = "lblApplyNo"
        Me.lblApplyNo.Size = New System.Drawing.Size(72, 16)
        Me.lblApplyNo.TabIndex = 18
        Me.lblApplyNo.Text = "申请单号"
        '
        'FrmHighValueDispatchReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDispatchDetail)
        Me.Controls.Add(Me.pnlToDispatch)
        Me.Name = "FrmHighValueDispatchReg"
        Me.Size = New System.Drawing.Size(1074, 555)
        Me.Controls.SetChildIndex(Me.pnlToDispatch, 0)
        Me.Controls.SetChildIndex(Me.pnlDispatchDetail, 0)
        Me.pnlToDispatch.ResumeLayout(False)
        Me.pnlDispatchDetail.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlFunc.PerformLayout()
        Me.gbOrderInfo.ResumeLayout(False)
        Me.gbOrderInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlToDispatch As System.Windows.Forms.Panel
    Friend WithEvents pnlDispatchDetail As System.Windows.Forms.Panel
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents gbOrderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblReady As UIControlLib.LabelEx
    Friend WithEvents btnCancel As UIControlLib.LabelEx
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

End Class
