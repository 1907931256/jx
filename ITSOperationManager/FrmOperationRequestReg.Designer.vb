Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperationRequestReg
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlSurInfo = New System.Windows.Forms.Panel()
        Me.gbSurDetail = New System.Windows.Forms.GroupBox()
        Me.tbDiagnosis = New System.Windows.Forms.TextBox()
        Me.tbMemo = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.lblSurTime = New System.Windows.Forms.Label()
        Me.lblSurName = New System.Windows.Forms.Label()
        Me.tbSurName = New System.Windows.Forms.TextBox()
        Me.tbSurTime = New System.Windows.Forms.TextBox()
        Me.lblSurRoom = New System.Windows.Forms.Label()
        Me.tbSurRoom = New System.Windows.Forms.TextBox()
        Me.lblTable = New System.Windows.Forms.Label()
        Me.tbTable = New System.Windows.Forms.TextBox()
        Me.tbVisit = New System.Windows.Forms.TextBox()
        Me.lblVisit = New System.Windows.Forms.Label()
        Me.tbPatName = New System.Windows.Forms.TextBox()
        Me.lblPatName = New System.Windows.Forms.Label()
        Me.tbGender = New System.Windows.Forms.TextBox()
        Me.tbAge = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.tbSurDr = New System.Windows.Forms.TextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblSurDr = New System.Windows.Forms.Label()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.pnlSurList = New System.Windows.Forms.Panel()
        Me.cmbSurList = New System.Windows.Forms.ComboBox()
        Me.lblSurList = New System.Windows.Forms.Label()
        Me.pnlSurRequest = New System.Windows.Forms.Panel()
        Me.pnlInstrument = New System.Windows.Forms.Panel()
        Me.pnlRequest = New System.Windows.Forms.Panel()
        Me.pnlTab = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlINS = New System.Windows.Forms.Panel()
        Me.dgvINS = New UIControlLib.UIDataGridView()
        Me.pnlDrug = New System.Windows.Forms.Panel()
        Me.dgvDrug = New UIControlLib.UIDataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dgvDrug_sub = New UIControlLib.UIDataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvINS_SUB = New UIControlLib.UIDataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnDeleteINS = New UIControlLib.LabelEx()
        Me.btnAddINS = New UIControlLib.LabelEx()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New UIControlLib.LabelEx()
        Me.btnAdd = New UIControlLib.LabelEx()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnOK = New UIControlLib.LabelEx()
        Me.lblSep = New System.Windows.Forms.Label()
        Me.pnlSurInfo.SuspendLayout()
        Me.gbSurDetail.SuspendLayout()
        Me.pnlSurList.SuspendLayout()
        Me.pnlSurRequest.SuspendLayout()
        Me.pnlInstrument.SuspendLayout()
        Me.pnlRequest.SuspendLayout()
        Me.pnlTab.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlINS.SuspendLayout()
        CType(Me.dgvINS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDrug.SuspendLayout()
        CType(Me.dgvDrug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvDrug_sub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvINS_SUB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSurInfo
        '
        Me.pnlSurInfo.Controls.Add(Me.gbSurDetail)
        Me.pnlSurInfo.Controls.Add(Me.pnlSurList)
        Me.pnlSurInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSurInfo.Location = New System.Drawing.Point(0, 42)
        Me.pnlSurInfo.Name = "pnlSurInfo"
        Me.pnlSurInfo.Size = New System.Drawing.Size(302, 513)
        Me.pnlSurInfo.TabIndex = 9
        '
        'gbSurDetail
        '
        Me.gbSurDetail.Controls.Add(Me.tbDiagnosis)
        Me.gbSurDetail.Controls.Add(Me.tbMemo)
        Me.gbSurDetail.Controls.Add(Me.lblDiagnosis)
        Me.gbSurDetail.Controls.Add(Me.lblSurTime)
        Me.gbSurDetail.Controls.Add(Me.lblSurName)
        Me.gbSurDetail.Controls.Add(Me.tbSurName)
        Me.gbSurDetail.Controls.Add(Me.tbSurTime)
        Me.gbSurDetail.Controls.Add(Me.lblSurRoom)
        Me.gbSurDetail.Controls.Add(Me.tbSurRoom)
        Me.gbSurDetail.Controls.Add(Me.lblTable)
        Me.gbSurDetail.Controls.Add(Me.tbTable)
        Me.gbSurDetail.Controls.Add(Me.tbVisit)
        Me.gbSurDetail.Controls.Add(Me.lblVisit)
        Me.gbSurDetail.Controls.Add(Me.tbPatName)
        Me.gbSurDetail.Controls.Add(Me.lblPatName)
        Me.gbSurDetail.Controls.Add(Me.tbGender)
        Me.gbSurDetail.Controls.Add(Me.tbAge)
        Me.gbSurDetail.Controls.Add(Me.lblGender)
        Me.gbSurDetail.Controls.Add(Me.tbSurDr)
        Me.gbSurDetail.Controls.Add(Me.lblAge)
        Me.gbSurDetail.Controls.Add(Me.lblSurDr)
        Me.gbSurDetail.Controls.Add(Me.lblMemo)
        Me.gbSurDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbSurDetail.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.gbSurDetail.Location = New System.Drawing.Point(0, 59)
        Me.gbSurDetail.Name = "gbSurDetail"
        Me.gbSurDetail.Size = New System.Drawing.Size(302, 454)
        Me.gbSurDetail.TabIndex = 3
        Me.gbSurDetail.TabStop = False
        Me.gbSurDetail.Text = "手术详细信息"
        '
        'tbDiagnosis
        '
        Me.tbDiagnosis.BackColor = System.Drawing.Color.Ivory
        Me.tbDiagnosis.Enabled = False
        Me.tbDiagnosis.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbDiagnosis.Location = New System.Drawing.Point(76, 334)
        Me.tbDiagnosis.Multiline = True
        Me.tbDiagnosis.Name = "tbDiagnosis"
        Me.tbDiagnosis.Size = New System.Drawing.Size(226, 55)
        Me.tbDiagnosis.TabIndex = 32
        '
        'tbMemo
        '
        Me.tbMemo.BackColor = System.Drawing.Color.Ivory
        Me.tbMemo.Enabled = False
        Me.tbMemo.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbMemo.Location = New System.Drawing.Point(76, 400)
        Me.tbMemo.Multiline = True
        Me.tbMemo.Name = "tbMemo"
        Me.tbMemo.Size = New System.Drawing.Size(226, 55)
        Me.tbMemo.TabIndex = 31
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.AutoSize = True
        Me.lblDiagnosis.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblDiagnosis.Location = New System.Drawing.Point(3, 337)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(70, 14)
        Me.lblDiagnosis.TabIndex = 29
        Me.lblDiagnosis.Text = "诊    断:"
        '
        'lblSurTime
        '
        Me.lblSurTime.AutoSize = True
        Me.lblSurTime.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblSurTime.Location = New System.Drawing.Point(3, 33)
        Me.lblSurTime.Name = "lblSurTime"
        Me.lblSurTime.Size = New System.Drawing.Size(70, 14)
        Me.lblSurTime.TabIndex = 28
        Me.lblSurTime.Text = "手术时间:"
        '
        'lblSurName
        '
        Me.lblSurName.AutoSize = True
        Me.lblSurName.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblSurName.Location = New System.Drawing.Point(3, 67)
        Me.lblSurName.Name = "lblSurName"
        Me.lblSurName.Size = New System.Drawing.Size(70, 14)
        Me.lblSurName.TabIndex = 26
        Me.lblSurName.Text = "手术名称:"
        '
        'tbSurName
        '
        Me.tbSurName.BackColor = System.Drawing.Color.Ivory
        Me.tbSurName.Enabled = False
        Me.tbSurName.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbSurName.Location = New System.Drawing.Point(76, 62)
        Me.tbSurName.Name = "tbSurName"
        Me.tbSurName.Size = New System.Drawing.Size(226, 23)
        Me.tbSurName.TabIndex = 25
        '
        'tbSurTime
        '
        Me.tbSurTime.BackColor = System.Drawing.Color.Ivory
        Me.tbSurTime.Enabled = False
        Me.tbSurTime.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbSurTime.Location = New System.Drawing.Point(76, 28)
        Me.tbSurTime.Name = "tbSurTime"
        Me.tbSurTime.Size = New System.Drawing.Size(226, 23)
        Me.tbSurTime.TabIndex = 23
        '
        'lblSurRoom
        '
        Me.lblSurRoom.AutoSize = True
        Me.lblSurRoom.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblSurRoom.Location = New System.Drawing.Point(3, 101)
        Me.lblSurRoom.Name = "lblSurRoom"
        Me.lblSurRoom.Size = New System.Drawing.Size(70, 14)
        Me.lblSurRoom.TabIndex = 22
        Me.lblSurRoom.Text = "手术房间:"
        '
        'tbSurRoom
        '
        Me.tbSurRoom.BackColor = System.Drawing.Color.Ivory
        Me.tbSurRoom.Enabled = False
        Me.tbSurRoom.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbSurRoom.Location = New System.Drawing.Point(76, 96)
        Me.tbSurRoom.Name = "tbSurRoom"
        Me.tbSurRoom.Size = New System.Drawing.Size(226, 23)
        Me.tbSurRoom.TabIndex = 21
        '
        'lblTable
        '
        Me.lblTable.AutoSize = True
        Me.lblTable.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblTable.Location = New System.Drawing.Point(3, 136)
        Me.lblTable.Name = "lblTable"
        Me.lblTable.Size = New System.Drawing.Size(70, 14)
        Me.lblTable.TabIndex = 20
        Me.lblTable.Text = "手术台号:"
        '
        'tbTable
        '
        Me.tbTable.BackColor = System.Drawing.Color.Ivory
        Me.tbTable.Enabled = False
        Me.tbTable.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbTable.Location = New System.Drawing.Point(76, 130)
        Me.tbTable.Name = "tbTable"
        Me.tbTable.Size = New System.Drawing.Size(226, 23)
        Me.tbTable.TabIndex = 19
        '
        'tbVisit
        '
        Me.tbVisit.BackColor = System.Drawing.Color.Ivory
        Me.tbVisit.Enabled = False
        Me.tbVisit.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbVisit.Location = New System.Drawing.Point(76, 164)
        Me.tbVisit.Name = "tbVisit"
        Me.tbVisit.Size = New System.Drawing.Size(226, 23)
        Me.tbVisit.TabIndex = 17
        '
        'lblVisit
        '
        Me.lblVisit.AutoSize = True
        Me.lblVisit.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblVisit.Location = New System.Drawing.Point(3, 169)
        Me.lblVisit.Name = "lblVisit"
        Me.lblVisit.Size = New System.Drawing.Size(70, 14)
        Me.lblVisit.TabIndex = 16
        Me.lblVisit.Text = "就 诊 号:"
        '
        'tbPatName
        '
        Me.tbPatName.BackColor = System.Drawing.Color.Ivory
        Me.tbPatName.Enabled = False
        Me.tbPatName.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbPatName.Location = New System.Drawing.Point(76, 198)
        Me.tbPatName.Name = "tbPatName"
        Me.tbPatName.Size = New System.Drawing.Size(226, 23)
        Me.tbPatName.TabIndex = 15
        '
        'lblPatName
        '
        Me.lblPatName.AutoSize = True
        Me.lblPatName.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblPatName.Location = New System.Drawing.Point(3, 204)
        Me.lblPatName.Name = "lblPatName"
        Me.lblPatName.Size = New System.Drawing.Size(70, 14)
        Me.lblPatName.TabIndex = 14
        Me.lblPatName.Text = "病人姓名:"
        '
        'tbGender
        '
        Me.tbGender.BackColor = System.Drawing.Color.Ivory
        Me.tbGender.Enabled = False
        Me.tbGender.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbGender.Location = New System.Drawing.Point(76, 232)
        Me.tbGender.Name = "tbGender"
        Me.tbGender.Size = New System.Drawing.Size(226, 23)
        Me.tbGender.TabIndex = 13
        '
        'tbAge
        '
        Me.tbAge.BackColor = System.Drawing.Color.Ivory
        Me.tbAge.Enabled = False
        Me.tbAge.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbAge.Location = New System.Drawing.Point(76, 266)
        Me.tbAge.Name = "tbAge"
        Me.tbAge.Size = New System.Drawing.Size(226, 23)
        Me.tbAge.TabIndex = 11
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblGender.Location = New System.Drawing.Point(3, 238)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(70, 14)
        Me.lblGender.TabIndex = 10
        Me.lblGender.Text = "性    别:"
        '
        'tbSurDr
        '
        Me.tbSurDr.BackColor = System.Drawing.Color.Ivory
        Me.tbSurDr.Enabled = False
        Me.tbSurDr.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbSurDr.Location = New System.Drawing.Point(76, 300)
        Me.tbSurDr.Name = "tbSurDr"
        Me.tbSurDr.Size = New System.Drawing.Size(226, 23)
        Me.tbSurDr.TabIndex = 9
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblAge.Location = New System.Drawing.Point(3, 272)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(70, 14)
        Me.lblAge.TabIndex = 8
        Me.lblAge.Text = "年    龄:"
        '
        'lblSurDr
        '
        Me.lblSurDr.AutoSize = True
        Me.lblSurDr.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblSurDr.Location = New System.Drawing.Point(3, 306)
        Me.lblSurDr.Name = "lblSurDr"
        Me.lblSurDr.Size = New System.Drawing.Size(70, 14)
        Me.lblSurDr.TabIndex = 6
        Me.lblSurDr.Text = "手术医生:"
        '
        'lblMemo
        '
        Me.lblMemo.AutoSize = True
        Me.lblMemo.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMemo.Location = New System.Drawing.Point(6, 404)
        Me.lblMemo.Name = "lblMemo"
        Me.lblMemo.Size = New System.Drawing.Size(70, 14)
        Me.lblMemo.TabIndex = 2
        Me.lblMemo.Text = "备    注:"
        '
        'pnlSurList
        '
        Me.pnlSurList.Controls.Add(Me.cmbSurList)
        Me.pnlSurList.Controls.Add(Me.lblSurList)
        Me.pnlSurList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSurList.Location = New System.Drawing.Point(0, 0)
        Me.pnlSurList.Name = "pnlSurList"
        Me.pnlSurList.Size = New System.Drawing.Size(302, 59)
        Me.pnlSurList.TabIndex = 2
        '
        'cmbSurList
        '
        Me.cmbSurList.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSurList.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbSurList.FormattingEnabled = True
        Me.cmbSurList.Location = New System.Drawing.Point(0, 21)
        Me.cmbSurList.Name = "cmbSurList"
        Me.cmbSurList.Size = New System.Drawing.Size(302, 24)
        Me.cmbSurList.TabIndex = 0
        '
        'lblSurList
        '
        Me.lblSurList.AutoSize = True
        Me.lblSurList.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSurList.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblSurList.Location = New System.Drawing.Point(0, 0)
        Me.lblSurList.Name = "lblSurList"
        Me.lblSurList.Size = New System.Drawing.Size(74, 21)
        Me.lblSurList.TabIndex = 1
        Me.lblSurList.Text = "手术列表"
        '
        'pnlSurRequest
        '
        Me.pnlSurRequest.Controls.Add(Me.pnlInstrument)
        Me.pnlSurRequest.Controls.Add(Me.pnlFunc)
        Me.pnlSurRequest.Controls.Add(Me.lblSep)
        Me.pnlSurRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSurRequest.Location = New System.Drawing.Point(302, 42)
        Me.pnlSurRequest.Name = "pnlSurRequest"
        Me.pnlSurRequest.Size = New System.Drawing.Size(772, 513)
        Me.pnlSurRequest.TabIndex = 10
        '
        'pnlInstrument
        '
        Me.pnlInstrument.Controls.Add(Me.pnlRequest)
        Me.pnlInstrument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInstrument.Location = New System.Drawing.Point(0, 10)
        Me.pnlInstrument.Name = "pnlInstrument"
        Me.pnlInstrument.Size = New System.Drawing.Size(772, 466)
        Me.pnlInstrument.TabIndex = 3
        '
        'pnlRequest
        '
        Me.pnlRequest.Controls.Add(Me.pnlTab)
        Me.pnlRequest.Controls.Add(Me.Panel2)
        Me.pnlRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRequest.Location = New System.Drawing.Point(0, 0)
        Me.pnlRequest.Name = "pnlRequest"
        Me.pnlRequest.Size = New System.Drawing.Size(772, 466)
        Me.pnlRequest.TabIndex = 0
        '
        'pnlTab
        '
        Me.pnlTab.Controls.Add(Me.TabControl1)
        Me.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTab.Location = New System.Drawing.Point(0, 0)
        Me.pnlTab.Name = "pnlTab"
        Me.pnlTab.Size = New System.Drawing.Size(667, 466)
        Me.pnlTab.TabIndex = 10
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(667, 466)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pnlINS)
        Me.TabPage1.Controls.Add(Me.pnlDrug)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(659, 436)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnlINS
        '
        Me.pnlINS.Controls.Add(Me.dgvINS)
        Me.pnlINS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlINS.Location = New System.Drawing.Point(3, 221)
        Me.pnlINS.Name = "pnlINS"
        Me.pnlINS.Size = New System.Drawing.Size(653, 212)
        Me.pnlINS.TabIndex = 2
        '
        'dgvINS
        '
        Me.dgvINS.AllowDelete = True
        Me.dgvINS.AllowSelectChangeRow = False
        Me.dgvINS.AllowSort = True
        Me.dgvINS.AllowUserToAddRows = False
        Me.dgvINS.AllowUserToResizeColumns = False
        Me.dgvINS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvINS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvINS.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvINS.BeQuerying = False
        Me.dgvINS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvINS.ChangeHeaderSize = False
        Me.dgvINS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvINS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvINS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvINS.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvINS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvINS.EnableHeadersVisualStyles = False
        Me.dgvINS.Location = New System.Drawing.Point(0, 0)
        Me.dgvINS.MultiSelect = False
        Me.dgvINS.Name = "dgvINS"
        Me.dgvINS.NoItemAlter = ""
        Me.dgvINS.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvINS.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvINS.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvINS.RowTemplate.Height = 23
        Me.dgvINS.SelCombineKeyEnable = False
        Me.dgvINS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvINS.ShowSelectionColor = True
        Me.dgvINS.Size = New System.Drawing.Size(653, 212)
        Me.dgvINS.TabIndex = 0
        '
        'pnlDrug
        '
        Me.pnlDrug.Controls.Add(Me.dgvDrug)
        Me.pnlDrug.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDrug.Location = New System.Drawing.Point(3, 3)
        Me.pnlDrug.Name = "pnlDrug"
        Me.pnlDrug.Size = New System.Drawing.Size(653, 218)
        Me.pnlDrug.TabIndex = 1
        '
        'dgvDrug
        '
        Me.dgvDrug.AllowDelete = True
        Me.dgvDrug.AllowSelectChangeRow = False
        Me.dgvDrug.AllowSort = True
        Me.dgvDrug.AllowUserToAddRows = False
        Me.dgvDrug.AllowUserToResizeColumns = False
        Me.dgvDrug.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvDrug.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDrug.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvDrug.BeQuerying = False
        Me.dgvDrug.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDrug.ChangeHeaderSize = False
        Me.dgvDrug.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrug.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDrug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDrug.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDrug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDrug.EnableHeadersVisualStyles = False
        Me.dgvDrug.Location = New System.Drawing.Point(0, 0)
        Me.dgvDrug.MultiSelect = False
        Me.dgvDrug.Name = "dgvDrug"
        Me.dgvDrug.NoItemAlter = ""
        Me.dgvDrug.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvDrug.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDrug.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvDrug.RowTemplate.Height = 23
        Me.dgvDrug.SelCombineKeyEnable = False
        Me.dgvDrug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDrug.ShowSelectionColor = True
        Me.dgvDrug.Size = New System.Drawing.Size(653, 218)
        Me.dgvDrug.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel5)
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(659, 436)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgvDrug_sub)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(653, 218)
        Me.Panel5.TabIndex = 1
        '
        'dgvDrug_sub
        '
        Me.dgvDrug_sub.AllowDelete = True
        Me.dgvDrug_sub.AllowSelectChangeRow = False
        Me.dgvDrug_sub.AllowSort = True
        Me.dgvDrug_sub.AllowUserToAddRows = False
        Me.dgvDrug_sub.AllowUserToResizeColumns = False
        Me.dgvDrug_sub.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvDrug_sub.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDrug_sub.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvDrug_sub.BeQuerying = False
        Me.dgvDrug_sub.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDrug_sub.ChangeHeaderSize = False
        Me.dgvDrug_sub.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrug_sub.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDrug_sub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDrug_sub.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDrug_sub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDrug_sub.EnableHeadersVisualStyles = False
        Me.dgvDrug_sub.Location = New System.Drawing.Point(0, 0)
        Me.dgvDrug_sub.MultiSelect = False
        Me.dgvDrug_sub.Name = "dgvDrug_sub"
        Me.dgvDrug_sub.NoItemAlter = ""
        Me.dgvDrug_sub.RowHeadersVisible = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvDrug_sub.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvDrug_sub.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvDrug_sub.RowTemplate.Height = 23
        Me.dgvDrug_sub.SelCombineKeyEnable = False
        Me.dgvDrug_sub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDrug_sub.ShowSelectionColor = True
        Me.dgvDrug_sub.Size = New System.Drawing.Size(653, 218)
        Me.dgvDrug_sub.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvINS_SUB)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 221)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(653, 212)
        Me.Panel4.TabIndex = 0
        '
        'dgvINS_SUB
        '
        Me.dgvINS_SUB.AllowDelete = True
        Me.dgvINS_SUB.AllowSelectChangeRow = False
        Me.dgvINS_SUB.AllowSort = True
        Me.dgvINS_SUB.AllowUserToAddRows = False
        Me.dgvINS_SUB.AllowUserToResizeColumns = False
        Me.dgvINS_SUB.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvINS_SUB.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvINS_SUB.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvINS_SUB.BeQuerying = False
        Me.dgvINS_SUB.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvINS_SUB.ChangeHeaderSize = False
        Me.dgvINS_SUB.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvINS_SUB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvINS_SUB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvINS_SUB.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvINS_SUB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvINS_SUB.EnableHeadersVisualStyles = False
        Me.dgvINS_SUB.Location = New System.Drawing.Point(0, 0)
        Me.dgvINS_SUB.MultiSelect = False
        Me.dgvINS_SUB.Name = "dgvINS_SUB"
        Me.dgvINS_SUB.NoItemAlter = ""
        Me.dgvINS_SUB.RowHeadersVisible = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvINS_SUB.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvINS_SUB.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvINS_SUB.RowTemplate.Height = 23
        Me.dgvINS_SUB.SelCombineKeyEnable = False
        Me.dgvINS_SUB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvINS_SUB.ShowSelectionColor = True
        Me.dgvINS_SUB.Size = New System.Drawing.Size(653, 212)
        Me.dgvINS_SUB.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(667, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(105, 466)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnDeleteINS)
        Me.Panel3.Controls.Add(Me.btnAddINS)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 253)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(105, 213)
        Me.Panel3.TabIndex = 8
        '
        'btnDeleteINS
        '
        Me.btnDeleteINS.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteINS.Fore_Color = System.Drawing.Color.Black
        Me.btnDeleteINS.ForeColor = System.Drawing.Color.Transparent
        Me.btnDeleteINS.Location = New System.Drawing.Point(8, 52)
        Me.btnDeleteINS.Name = "btnDeleteINS"
        Me.btnDeleteINS.Size = New System.Drawing.Size(86, 30)
        Me.btnDeleteINS.TabIndex = 8
        Me.btnDeleteINS.Text = "删除"
        Me.btnDeleteINS.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDeleteINS.TipText = ""
        '
        'btnAddINS
        '
        Me.btnAddINS.BackColor = System.Drawing.Color.Transparent
        Me.btnAddINS.Fore_Color = System.Drawing.Color.Black
        Me.btnAddINS.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddINS.Location = New System.Drawing.Point(8, 18)
        Me.btnAddINS.Name = "btnAddINS"
        Me.btnAddINS.Size = New System.Drawing.Size(86, 30)
        Me.btnAddINS.TabIndex = 7
        Me.btnAddINS.Text = "添加"
        Me.btnAddINS.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddINS.TipText = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 168)
        Me.Panel1.TabIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.Fore_Color = System.Drawing.Color.Black
        Me.btnDelete.ForeColor = System.Drawing.Color.Transparent
        Me.btnDelete.Location = New System.Drawing.Point(11, 66)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 30)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "删除"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.TipText = ""
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Fore_Color = System.Drawing.Color.Black
        Me.btnAdd.ForeColor = System.Drawing.Color.Transparent
        Me.btnAdd.Location = New System.Drawing.Point(11, 26)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(86, 30)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "添加"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.TipText = ""
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnOK)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 476)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(772, 37)
        Me.pnlFunc.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Fore_Color = System.Drawing.Color.Black
        Me.btnOK.ForeColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(344, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 30)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "确认"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.TipText = ""
        '
        'lblSep
        '
        Me.lblSep.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep.Location = New System.Drawing.Point(0, 0)
        Me.lblSep.Name = "lblSep"
        Me.lblSep.Size = New System.Drawing.Size(772, 10)
        Me.lblSep.TabIndex = 0
        '
        'FrmOperationRequestReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlSurRequest)
        Me.Controls.Add(Me.pnlSurInfo)
        Me.Name = "FrmOperationRequestReg"
        Me.Size = New System.Drawing.Size(1074, 555)
        Me.Controls.SetChildIndex(Me.pnlSurInfo, 0)
        Me.Controls.SetChildIndex(Me.pnlSurRequest, 0)
        Me.pnlSurInfo.ResumeLayout(False)
        Me.gbSurDetail.ResumeLayout(False)
        Me.gbSurDetail.PerformLayout()
        Me.pnlSurList.ResumeLayout(False)
        Me.pnlSurList.PerformLayout()
        Me.pnlSurRequest.ResumeLayout(False)
        Me.pnlInstrument.ResumeLayout(False)
        Me.pnlRequest.ResumeLayout(False)
        Me.pnlTab.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.pnlINS.ResumeLayout(False)
        CType(Me.dgvINS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDrug.ResumeLayout(False)
        CType(Me.dgvDrug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgvDrug_sub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvINS_SUB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSurInfo As System.Windows.Forms.Panel
    Friend WithEvents lblSurList As System.Windows.Forms.Label
    Friend WithEvents cmbSurList As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSurRequest As System.Windows.Forms.Panel
    Friend WithEvents pnlSurList As System.Windows.Forms.Panel
    Friend WithEvents gbSurDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lblSurTime As System.Windows.Forms.Label
    Friend WithEvents lblSurName As System.Windows.Forms.Label
    Friend WithEvents tbSurName As System.Windows.Forms.TextBox
    Friend WithEvents tbSurTime As System.Windows.Forms.TextBox
    Friend WithEvents lblSurRoom As System.Windows.Forms.Label
    Friend WithEvents tbSurRoom As System.Windows.Forms.TextBox
    Friend WithEvents lblTable As System.Windows.Forms.Label
    Friend WithEvents tbTable As System.Windows.Forms.TextBox
    Friend WithEvents tbVisit As System.Windows.Forms.TextBox
    Friend WithEvents lblVisit As System.Windows.Forms.Label
    Friend WithEvents tbPatName As System.Windows.Forms.TextBox
    Friend WithEvents lblPatName As System.Windows.Forms.Label
    Friend WithEvents tbGender As System.Windows.Forms.TextBox
    Friend WithEvents tbAge As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents tbSurDr As System.Windows.Forms.TextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblSurDr As System.Windows.Forms.Label
    Friend WithEvents lblMemo As System.Windows.Forms.Label
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents tbDiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents tbMemo As System.Windows.Forms.TextBox
    Friend WithEvents lblSep As System.Windows.Forms.Label
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnOK As UIControlLib.LabelEx
    Friend WithEvents pnlInstrument As System.Windows.Forms.Panel
    Friend WithEvents pnlRequest As System.Windows.Forms.Panel
    Friend WithEvents btnAddINS As UIControlLib.LabelEx
    Friend WithEvents btnAdd As UIControlLib.LabelEx
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteINS As UIControlLib.LabelEx
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As UIControlLib.LabelEx
    Friend WithEvents pnlTab As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents pnlDrug As System.Windows.Forms.Panel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents pnlINS As System.Windows.Forms.Panel
    Friend WithEvents dgvINS As UIControlLib.UIDataGridView
    Friend WithEvents dgvDrug As UIControlLib.UIDataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dgvDrug_sub As UIControlLib.UIDataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dgvINS_SUB As UIControlLib.UIDataGridView

End Class
