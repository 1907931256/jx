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
        Me.pnlToDispatch = New System.Windows.Forms.Panel()
        Me.rptList = New UIControlLib.UIRoundPanelBase()
        Me.tvToDispatch = New System.Windows.Forms.TreeView()
        Me.pnlLeftBottom = New System.Windows.Forms.Panel()
        Me.pnlDispatchDetail = New System.Windows.Forms.Panel()
        Me.dgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.lblReady = New DevComponents.DotNetBar.ButtonX()
        Me.tbChecker = New System.Windows.Forms.TextBox()
        Me.lblChecker = New System.Windows.Forms.Label()
        Me.gbOrderInfo = New System.Windows.Forms.GroupBox()
        Me.txtRequestName = New System.Windows.Forms.TextBox()
        Me.tbApplyDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.pnlToDispatch.Controls.Add(Me.rptList)
        Me.pnlToDispatch.Controls.Add(Me.tvToDispatch)
        Me.pnlToDispatch.Controls.Add(Me.pnlLeftBottom)
        Me.pnlToDispatch.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlToDispatch.Location = New System.Drawing.Point(0, 32)
        Me.pnlToDispatch.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlToDispatch.Name = "pnlToDispatch"
        Me.pnlToDispatch.Size = New System.Drawing.Size(318, 384)
        Me.pnlToDispatch.TabIndex = 9
        '
        'rptList
        '
        Me.rptList.BackColor = System.Drawing.Color.Transparent
        Me.rptList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptList.Location = New System.Drawing.Point(0, 0)
        Me.rptList.Name = "rptList"
        Me.rptList.Size = New System.Drawing.Size(316, 352)
        Me.rptList.TabIndex = 1
        Me.rptList.Visible = False
        '
        'tvToDispatch
        '
        Me.tvToDispatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tvToDispatch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvToDispatch.Location = New System.Drawing.Point(0, 0)
        Me.tvToDispatch.Margin = New System.Windows.Forms.Padding(2)
        Me.tvToDispatch.Name = "tvToDispatch"
        Me.tvToDispatch.Size = New System.Drawing.Size(316, 352)
        Me.tvToDispatch.TabIndex = 0
        '
        'pnlLeftBottom
        '
        Me.pnlLeftBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlLeftBottom.Location = New System.Drawing.Point(0, 352)
        Me.pnlLeftBottom.Name = "pnlLeftBottom"
        Me.pnlLeftBottom.Size = New System.Drawing.Size(316, 30)
        Me.pnlLeftBottom.TabIndex = 3
        '
        'pnlDispatchDetail
        '
        Me.pnlDispatchDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDispatchDetail.Controls.Add(Me.dgv)
        Me.pnlDispatchDetail.Controls.Add(Me.pnlCommit)
        Me.pnlDispatchDetail.Controls.Add(Me.gbOrderInfo)
        Me.pnlDispatchDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDispatchDetail.Location = New System.Drawing.Point(318, 32)
        Me.pnlDispatchDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlDispatchDetail.Name = "pnlDispatchDetail"
        Me.pnlDispatchDetail.Size = New System.Drawing.Size(488, 384)
        Me.pnlDispatchDetail.TabIndex = 10
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
        Me.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(0, 94)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(486, 258)
        Me.dgv.TabIndex = 48
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
        Me.pnlCommit.Size = New System.Drawing.Size(486, 30)
        Me.pnlCommit.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(422, 5)
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
        Me.lblReady.Location = New System.Drawing.Point(357, 5)
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
        Me.tbChecker.Size = New System.Drawing.Size(99, 21)
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
        Me.gbOrderInfo.Controls.Add(Me.txtRequestName)
        Me.gbOrderInfo.Controls.Add(Me.tbApplyDate)
        Me.gbOrderInfo.Controls.Add(Me.Label1)
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
        Me.gbOrderInfo.Size = New System.Drawing.Size(486, 94)
        Me.gbOrderInfo.TabIndex = 0
        Me.gbOrderInfo.TabStop = False
        Me.gbOrderInfo.Text = "单据详细信息"
        '
        'txtRequestName
        '
        Me.txtRequestName.BackColor = System.Drawing.Color.Ivory
        Me.txtRequestName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtRequestName.Location = New System.Drawing.Point(71, 55)
        Me.txtRequestName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRequestName.Name = "txtRequestName"
        Me.txtRequestName.ReadOnly = True
        Me.txtRequestName.Size = New System.Drawing.Size(116, 21)
        Me.txtRequestName.TabIndex = 35
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(15, 60)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "申请人员"
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
    Friend WithEvents tbChecker As System.Windows.Forms.TextBox
    Friend WithEvents lblChecker As System.Windows.Forms.Label
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
    Friend WithEvents rptList As UIControlLib.UIRoundPanelBase
    Friend WithEvents txtRequestName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlLeftBottom As System.Windows.Forms.Panel
    Friend WithEvents dgv As DevComponents.DotNetBar.Controls.DataGridViewX

End Class
