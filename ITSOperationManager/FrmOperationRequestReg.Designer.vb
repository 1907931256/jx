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
        Me.pnlSurRequest = New System.Windows.Forms.Panel()
        Me.pnlInstrument = New System.Windows.Forms.Panel()
        Me.pnlRequest = New System.Windows.Forms.Panel()
        Me.pnlTab = New System.Windows.Forms.Panel()
        Me.pnlINS = New System.Windows.Forms.Panel()
        Me.dgvINStrument = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlDrug = New System.Windows.Forms.Panel()
        Me.dgvDrug = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnDeleteINS = New DevComponents.DotNetBar.ButtonX()
        Me.btnAddINS = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.lblSep = New System.Windows.Forms.Label()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.pnlSurInfo = New System.Windows.Forms.Panel()
        Me.gbSurDetail = New System.Windows.Forms.GroupBox()
        Me.tbTable = New System.Windows.Forms.TextBox()
        Me.tbSurRoom = New System.Windows.Forms.TextBox()
        Me.tbSurName = New System.Windows.Forms.TextBox()
        Me.tbSurTime = New System.Windows.Forms.TextBox()
        Me.tbDiagnosis = New System.Windows.Forms.TextBox()
        Me.tbMemo = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.lblSurTime = New System.Windows.Forms.Label()
        Me.lblSurName = New System.Windows.Forms.Label()
        Me.lblSurRoom = New System.Windows.Forms.Label()
        Me.lblTable = New System.Windows.Forms.Label()
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
        Me.lblSep2 = New System.Windows.Forms.Label()
        Me.pnlSurList = New System.Windows.Forms.Panel()
        Me.cmbSurList = New System.Windows.Forms.ComboBox()
        Me.lblSep4 = New System.Windows.Forms.Label()
        Me.lblSurList = New System.Windows.Forms.Label()
        Me.lblSep3 = New System.Windows.Forms.Label()
        Me.pnlSurRequest.SuspendLayout()
        Me.pnlInstrument.SuspendLayout()
        Me.pnlRequest.SuspendLayout()
        Me.pnlTab.SuspendLayout()
        Me.pnlINS.SuspendLayout()
        CType(Me.dgvINStrument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDrug.SuspendLayout()
        CType(Me.dgvDrug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlCommit.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.pnlSurInfo.SuspendLayout()
        Me.gbSurDetail.SuspendLayout()
        Me.pnlSurList.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSurRequest
        '
        Me.pnlSurRequest.Controls.Add(Me.pnlInstrument)
        Me.pnlSurRequest.Controls.Add(Me.pnlCommit)
        Me.pnlSurRequest.Controls.Add(Me.lblSep)
        Me.pnlSurRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSurRequest.Location = New System.Drawing.Point(226, 32)
        Me.pnlSurRequest.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSurRequest.Name = "pnlSurRequest"
        Me.pnlSurRequest.Size = New System.Drawing.Size(580, 384)
        Me.pnlSurRequest.TabIndex = 10
        '
        'pnlInstrument
        '
        Me.pnlInstrument.Controls.Add(Me.pnlRequest)
        Me.pnlInstrument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInstrument.Location = New System.Drawing.Point(0, 8)
        Me.pnlInstrument.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlInstrument.Name = "pnlInstrument"
        Me.pnlInstrument.Size = New System.Drawing.Size(580, 348)
        Me.pnlInstrument.TabIndex = 3
        '
        'pnlRequest
        '
        Me.pnlRequest.Controls.Add(Me.pnlTab)
        Me.pnlRequest.Controls.Add(Me.Panel2)
        Me.pnlRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRequest.Location = New System.Drawing.Point(0, 0)
        Me.pnlRequest.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlRequest.Name = "pnlRequest"
        Me.pnlRequest.Size = New System.Drawing.Size(580, 348)
        Me.pnlRequest.TabIndex = 0
        '
        'pnlTab
        '
        Me.pnlTab.Controls.Add(Me.pnlINS)
        Me.pnlTab.Controls.Add(Me.pnlDrug)
        Me.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTab.Location = New System.Drawing.Point(0, 0)
        Me.pnlTab.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlTab.Name = "pnlTab"
        Me.pnlTab.Size = New System.Drawing.Size(509, 348)
        Me.pnlTab.TabIndex = 10
        '
        'pnlINS
        '
        Me.pnlINS.Controls.Add(Me.dgvINStrument)
        Me.pnlINS.Controls.Add(Me.Panel4)
        Me.pnlINS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlINS.Location = New System.Drawing.Point(0, 138)
        Me.pnlINS.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlINS.Name = "pnlINS"
        Me.pnlINS.Size = New System.Drawing.Size(509, 210)
        Me.pnlINS.TabIndex = 2
        '
        'dgvINStrument
        '
        Me.dgvINStrument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvINStrument.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvINStrument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvINStrument.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvINStrument.Location = New System.Drawing.Point(0, 25)
        Me.dgvINStrument.Name = "dgvINStrument"
        Me.dgvINStrument.RowHeadersVisible = False
        Me.dgvINStrument.RowTemplate.Height = 23
        Me.dgvINStrument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvINStrument.Size = New System.Drawing.Size(509, 185)
        Me.dgvINStrument.TabIndex = 50
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(509, 25)
        Me.Panel4.TabIndex = 3
        '
        'pnlDrug
        '
        Me.pnlDrug.Controls.Add(Me.dgvDrug)
        Me.pnlDrug.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDrug.Location = New System.Drawing.Point(0, 0)
        Me.pnlDrug.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlDrug.Name = "pnlDrug"
        Me.pnlDrug.Size = New System.Drawing.Size(509, 138)
        Me.pnlDrug.TabIndex = 1
        '
        'dgvDrug
        '
        Me.dgvDrug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDrug.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDrug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDrug.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvDrug.Location = New System.Drawing.Point(0, 0)
        Me.dgvDrug.Name = "dgvDrug"
        Me.dgvDrug.RowHeadersVisible = False
        Me.dgvDrug.RowTemplate.Height = 23
        Me.dgvDrug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDrug.Size = New System.Drawing.Size(509, 138)
        Me.dgvDrug.TabIndex = 49
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(509, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(71, 348)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnDeleteINS)
        Me.Panel3.Controls.Add(Me.btnAddINS)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 163)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(71, 185)
        Me.Panel3.TabIndex = 8
        '
        'btnDeleteINS
        '
        Me.btnDeleteINS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteINS.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDeleteINS.Location = New System.Drawing.Point(6, 32)
        Me.btnDeleteINS.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteINS.Name = "btnDeleteINS"
        Me.btnDeleteINS.Size = New System.Drawing.Size(58, 22)
        Me.btnDeleteINS.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnDeleteINS.TabIndex = 24
        Me.btnDeleteINS.Text = "删除"
        '
        'btnAddINS
        '
        Me.btnAddINS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAddINS.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAddINS.Location = New System.Drawing.Point(6, 6)
        Me.btnAddINS.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddINS.Name = "btnAddINS"
        Me.btnAddINS.Size = New System.Drawing.Size(58, 22)
        Me.btnAddINS.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnAddINS.TabIndex = 23
        Me.btnAddINS.Text = "添加"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(71, 138)
        Me.Panel1.TabIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDelete.Location = New System.Drawing.Point(6, 36)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(58, 22)
        Me.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "删除"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAdd.Location = New System.Drawing.Point(6, 10)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(58, 22)
        Me.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnAdd.TabIndex = 25
        Me.btnAdd.Text = "添加"
        '
        'pnlCommit
        '
        Me.pnlCommit.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlCommit.Controls.Add(Me.btnOK)
        Me.pnlCommit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommit.Location = New System.Drawing.Point(0, 356)
        Me.pnlCommit.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCommit.Name = "pnlCommit"
        Me.pnlCommit.Size = New System.Drawing.Size(580, 28)
        Me.pnlCommit.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOK.Location = New System.Drawing.Point(197, 4)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(58, 22)
        Me.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "确认"
        '
        'lblSep
        '
        Me.lblSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.lblSep.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep.Location = New System.Drawing.Point(0, 0)
        Me.lblSep.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSep.Name = "lblSep"
        Me.lblSep.Size = New System.Drawing.Size(580, 8)
        Me.lblSep.TabIndex = 0
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(806, 32)
        Me.pnlFunc.TabIndex = 15
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
        'pnlSurInfo
        '
        Me.pnlSurInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlSurInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSurInfo.Controls.Add(Me.gbSurDetail)
        Me.pnlSurInfo.Controls.Add(Me.lblSep2)
        Me.pnlSurInfo.Controls.Add(Me.pnlSurList)
        Me.pnlSurInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSurInfo.Location = New System.Drawing.Point(0, 32)
        Me.pnlSurInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSurInfo.Name = "pnlSurInfo"
        Me.pnlSurInfo.Size = New System.Drawing.Size(226, 384)
        Me.pnlSurInfo.TabIndex = 16
        '
        'gbSurDetail
        '
        Me.gbSurDetail.Controls.Add(Me.tbTable)
        Me.gbSurDetail.Controls.Add(Me.tbSurRoom)
        Me.gbSurDetail.Controls.Add(Me.tbSurName)
        Me.gbSurDetail.Controls.Add(Me.tbSurTime)
        Me.gbSurDetail.Controls.Add(Me.tbDiagnosis)
        Me.gbSurDetail.Controls.Add(Me.tbMemo)
        Me.gbSurDetail.Controls.Add(Me.lblDiagnosis)
        Me.gbSurDetail.Controls.Add(Me.lblSurTime)
        Me.gbSurDetail.Controls.Add(Me.lblSurName)
        Me.gbSurDetail.Controls.Add(Me.lblSurRoom)
        Me.gbSurDetail.Controls.Add(Me.lblTable)
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
        Me.gbSurDetail.Font = New System.Drawing.Font("SimSun", 11.0!)
        Me.gbSurDetail.Location = New System.Drawing.Point(0, 53)
        Me.gbSurDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.gbSurDetail.Name = "gbSurDetail"
        Me.gbSurDetail.Padding = New System.Windows.Forms.Padding(2)
        Me.gbSurDetail.Size = New System.Drawing.Size(224, 329)
        Me.gbSurDetail.TabIndex = 3
        Me.gbSurDetail.TabStop = False
        Me.gbSurDetail.Text = "手术详细信息"
        '
        'tbTable
        '
        Me.tbTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTable.BackColor = System.Drawing.Color.Ivory
        Me.tbTable.Enabled = False
        Me.tbTable.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbTable.Location = New System.Drawing.Point(62, 96)
        Me.tbTable.Margin = New System.Windows.Forms.Padding(2)
        Me.tbTable.Name = "tbTable"
        Me.tbTable.Size = New System.Drawing.Size(162, 21)
        Me.tbTable.TabIndex = 36
        '
        'tbSurRoom
        '
        Me.tbSurRoom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSurRoom.BackColor = System.Drawing.Color.Ivory
        Me.tbSurRoom.Enabled = False
        Me.tbSurRoom.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbSurRoom.Location = New System.Drawing.Point(62, 71)
        Me.tbSurRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.tbSurRoom.Name = "tbSurRoom"
        Me.tbSurRoom.Size = New System.Drawing.Size(162, 21)
        Me.tbSurRoom.TabIndex = 35
        '
        'tbSurName
        '
        Me.tbSurName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSurName.BackColor = System.Drawing.Color.Ivory
        Me.tbSurName.Enabled = False
        Me.tbSurName.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbSurName.Location = New System.Drawing.Point(62, 46)
        Me.tbSurName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbSurName.Name = "tbSurName"
        Me.tbSurName.Size = New System.Drawing.Size(162, 21)
        Me.tbSurName.TabIndex = 34
        '
        'tbSurTime
        '
        Me.tbSurTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSurTime.BackColor = System.Drawing.Color.Ivory
        Me.tbSurTime.Enabled = False
        Me.tbSurTime.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbSurTime.Location = New System.Drawing.Point(62, 21)
        Me.tbSurTime.Margin = New System.Windows.Forms.Padding(2)
        Me.tbSurTime.Name = "tbSurTime"
        Me.tbSurTime.Size = New System.Drawing.Size(162, 21)
        Me.tbSurTime.TabIndex = 33
        '
        'tbDiagnosis
        '
        Me.tbDiagnosis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDiagnosis.BackColor = System.Drawing.Color.Ivory
        Me.tbDiagnosis.Enabled = False
        Me.tbDiagnosis.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbDiagnosis.Location = New System.Drawing.Point(62, 246)
        Me.tbDiagnosis.Margin = New System.Windows.Forms.Padding(2)
        Me.tbDiagnosis.Multiline = True
        Me.tbDiagnosis.Name = "tbDiagnosis"
        Me.tbDiagnosis.Size = New System.Drawing.Size(162, 42)
        Me.tbDiagnosis.TabIndex = 32
        '
        'tbMemo
        '
        Me.tbMemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbMemo.BackColor = System.Drawing.Color.Ivory
        Me.tbMemo.Enabled = False
        Me.tbMemo.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbMemo.Location = New System.Drawing.Point(62, 292)
        Me.tbMemo.Margin = New System.Windows.Forms.Padding(2)
        Me.tbMemo.Multiline = True
        Me.tbMemo.Name = "tbMemo"
        Me.tbMemo.Size = New System.Drawing.Size(162, 42)
        Me.tbMemo.TabIndex = 31
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.AutoSize = True
        Me.lblDiagnosis.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblDiagnosis.Location = New System.Drawing.Point(2, 252)
        Me.lblDiagnosis.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(65, 12)
        Me.lblDiagnosis.TabIndex = 29
        Me.lblDiagnosis.Text = "诊    断："
        '
        'lblSurTime
        '
        Me.lblSurTime.AutoSize = True
        Me.lblSurTime.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblSurTime.Location = New System.Drawing.Point(2, 26)
        Me.lblSurTime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurTime.Name = "lblSurTime"
        Me.lblSurTime.Size = New System.Drawing.Size(65, 12)
        Me.lblSurTime.TabIndex = 28
        Me.lblSurTime.Text = "手术时间："
        '
        'lblSurName
        '
        Me.lblSurName.AutoSize = True
        Me.lblSurName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblSurName.Location = New System.Drawing.Point(2, 51)
        Me.lblSurName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurName.Name = "lblSurName"
        Me.lblSurName.Size = New System.Drawing.Size(65, 12)
        Me.lblSurName.TabIndex = 26
        Me.lblSurName.Text = "手术名称："
        '
        'lblSurRoom
        '
        Me.lblSurRoom.AutoSize = True
        Me.lblSurRoom.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblSurRoom.Location = New System.Drawing.Point(2, 76)
        Me.lblSurRoom.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurRoom.Name = "lblSurRoom"
        Me.lblSurRoom.Size = New System.Drawing.Size(65, 12)
        Me.lblSurRoom.TabIndex = 22
        Me.lblSurRoom.Text = "手术房间："
        '
        'lblTable
        '
        Me.lblTable.AutoSize = True
        Me.lblTable.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.lblTable.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblTable.Location = New System.Drawing.Point(2, 101)
        Me.lblTable.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTable.Name = "lblTable"
        Me.lblTable.Size = New System.Drawing.Size(65, 12)
        Me.lblTable.TabIndex = 20
        Me.lblTable.Text = "手术台号："
        '
        'tbVisit
        '
        Me.tbVisit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVisit.BackColor = System.Drawing.Color.Ivory
        Me.tbVisit.Enabled = False
        Me.tbVisit.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbVisit.Location = New System.Drawing.Point(62, 121)
        Me.tbVisit.Margin = New System.Windows.Forms.Padding(2)
        Me.tbVisit.Name = "tbVisit"
        Me.tbVisit.Size = New System.Drawing.Size(162, 21)
        Me.tbVisit.TabIndex = 17
        '
        'lblVisit
        '
        Me.lblVisit.AutoSize = True
        Me.lblVisit.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblVisit.Location = New System.Drawing.Point(2, 126)
        Me.lblVisit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVisit.Name = "lblVisit"
        Me.lblVisit.Size = New System.Drawing.Size(65, 12)
        Me.lblVisit.TabIndex = 16
        Me.lblVisit.Text = "就 诊 号："
        '
        'tbPatName
        '
        Me.tbPatName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPatName.BackColor = System.Drawing.Color.Ivory
        Me.tbPatName.Enabled = False
        Me.tbPatName.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbPatName.Location = New System.Drawing.Point(62, 146)
        Me.tbPatName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbPatName.Name = "tbPatName"
        Me.tbPatName.Size = New System.Drawing.Size(162, 21)
        Me.tbPatName.TabIndex = 15
        '
        'lblPatName
        '
        Me.lblPatName.AutoSize = True
        Me.lblPatName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblPatName.Location = New System.Drawing.Point(2, 151)
        Me.lblPatName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPatName.Name = "lblPatName"
        Me.lblPatName.Size = New System.Drawing.Size(65, 12)
        Me.lblPatName.TabIndex = 14
        Me.lblPatName.Text = "病人姓名："
        '
        'tbGender
        '
        Me.tbGender.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbGender.BackColor = System.Drawing.Color.Ivory
        Me.tbGender.Enabled = False
        Me.tbGender.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbGender.Location = New System.Drawing.Point(62, 171)
        Me.tbGender.Margin = New System.Windows.Forms.Padding(2)
        Me.tbGender.Name = "tbGender"
        Me.tbGender.Size = New System.Drawing.Size(162, 21)
        Me.tbGender.TabIndex = 13
        '
        'tbAge
        '
        Me.tbAge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAge.BackColor = System.Drawing.Color.Ivory
        Me.tbAge.Enabled = False
        Me.tbAge.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbAge.Location = New System.Drawing.Point(62, 196)
        Me.tbAge.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAge.Name = "tbAge"
        Me.tbAge.Size = New System.Drawing.Size(162, 21)
        Me.tbAge.TabIndex = 11
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblGender.Location = New System.Drawing.Point(2, 176)
        Me.lblGender.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(65, 12)
        Me.lblGender.TabIndex = 10
        Me.lblGender.Text = "性    别："
        '
        'tbSurDr
        '
        Me.tbSurDr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSurDr.BackColor = System.Drawing.Color.Ivory
        Me.tbSurDr.Enabled = False
        Me.tbSurDr.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbSurDr.Location = New System.Drawing.Point(62, 221)
        Me.tbSurDr.Margin = New System.Windows.Forms.Padding(2)
        Me.tbSurDr.Name = "tbSurDr"
        Me.tbSurDr.Size = New System.Drawing.Size(162, 21)
        Me.tbSurDr.TabIndex = 9
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblAge.Location = New System.Drawing.Point(2, 201)
        Me.lblAge.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(65, 12)
        Me.lblAge.TabIndex = 8
        Me.lblAge.Text = "年    龄："
        '
        'lblSurDr
        '
        Me.lblSurDr.AutoSize = True
        Me.lblSurDr.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblSurDr.Location = New System.Drawing.Point(2, 226)
        Me.lblSurDr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurDr.Name = "lblSurDr"
        Me.lblSurDr.Size = New System.Drawing.Size(65, 12)
        Me.lblSurDr.TabIndex = 6
        Me.lblSurDr.Text = "手术医生："
        '
        'lblMemo
        '
        Me.lblMemo.AutoSize = True
        Me.lblMemo.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblMemo.Location = New System.Drawing.Point(4, 297)
        Me.lblMemo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMemo.Name = "lblMemo"
        Me.lblMemo.Size = New System.Drawing.Size(65, 12)
        Me.lblMemo.TabIndex = 2
        Me.lblMemo.Text = "备    注："
        '
        'lblSep2
        '
        Me.lblSep2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep2.Location = New System.Drawing.Point(0, 48)
        Me.lblSep2.Name = "lblSep2"
        Me.lblSep2.Size = New System.Drawing.Size(224, 5)
        Me.lblSep2.TabIndex = 33
        '
        'pnlSurList
        '
        Me.pnlSurList.Controls.Add(Me.cmbSurList)
        Me.pnlSurList.Controls.Add(Me.lblSep4)
        Me.pnlSurList.Controls.Add(Me.lblSurList)
        Me.pnlSurList.Controls.Add(Me.lblSep3)
        Me.pnlSurList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSurList.Location = New System.Drawing.Point(0, 0)
        Me.pnlSurList.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSurList.Name = "pnlSurList"
        Me.pnlSurList.Size = New System.Drawing.Size(224, 48)
        Me.pnlSurList.TabIndex = 2
        '
        'cmbSurList
        '
        Me.cmbSurList.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.cmbSurList.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbSurList.FormattingEnabled = True
        Me.cmbSurList.Location = New System.Drawing.Point(0, 25)
        Me.cmbSurList.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbSurList.Name = "cmbSurList"
        Me.cmbSurList.Size = New System.Drawing.Size(224, 20)
        Me.cmbSurList.TabIndex = 0
        '
        'lblSep4
        '
        Me.lblSep4.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep4.Location = New System.Drawing.Point(0, 20)
        Me.lblSep4.Name = "lblSep4"
        Me.lblSep4.Size = New System.Drawing.Size(224, 5)
        Me.lblSep4.TabIndex = 35
        '
        'lblSurList
        '
        Me.lblSurList.AutoSize = True
        Me.lblSurList.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSurList.Font = New System.Drawing.Font("SimSun", 11.0!)
        Me.lblSurList.Location = New System.Drawing.Point(0, 5)
        Me.lblSurList.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurList.Name = "lblSurList"
        Me.lblSurList.Size = New System.Drawing.Size(67, 15)
        Me.lblSurList.TabIndex = 1
        Me.lblSurList.Text = "手术列表"
        '
        'lblSep3
        '
        Me.lblSep3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep3.Location = New System.Drawing.Point(0, 0)
        Me.lblSep3.Name = "lblSep3"
        Me.lblSep3.Size = New System.Drawing.Size(224, 5)
        Me.lblSep3.TabIndex = 34
        '
        'FrmOperationRequestReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlSurRequest)
        Me.Controls.Add(Me.pnlSurInfo)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmOperationRequestReg"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlSurRequest.ResumeLayout(False)
        Me.pnlInstrument.ResumeLayout(False)
        Me.pnlRequest.ResumeLayout(False)
        Me.pnlTab.ResumeLayout(False)
        Me.pnlINS.ResumeLayout(False)
        CType(Me.dgvINStrument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDrug.ResumeLayout(False)
        CType(Me.dgvDrug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlCommit.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlSurInfo.ResumeLayout(False)
        Me.gbSurDetail.ResumeLayout(False)
        Me.gbSurDetail.PerformLayout()
        Me.pnlSurList.ResumeLayout(False)
        Me.pnlSurList.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents pnlSurRequest As System.Windows.Forms.Panel
    Friend WithEvents lblSep As System.Windows.Forms.Label
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents pnlInstrument As System.Windows.Forms.Panel
    Friend WithEvents pnlRequest As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlTab As System.Windows.Forms.Panel
    Friend WithEvents pnlDrug As System.Windows.Forms.Panel
    Friend WithEvents pnlINS As System.Windows.Forms.Panel
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlSurInfo As System.Windows.Forms.Panel
    Friend WithEvents gbSurDetail As System.Windows.Forms.GroupBox
    Friend WithEvents tbTable As System.Windows.Forms.TextBox
    Friend WithEvents tbSurRoom As System.Windows.Forms.TextBox
    Friend WithEvents tbSurName As System.Windows.Forms.TextBox
    Friend WithEvents tbSurTime As System.Windows.Forms.TextBox
    Friend WithEvents tbDiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents tbMemo As System.Windows.Forms.TextBox
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents lblSurTime As System.Windows.Forms.Label
    Friend WithEvents lblSurName As System.Windows.Forms.Label
    Friend WithEvents lblSurRoom As System.Windows.Forms.Label
    Friend WithEvents lblTable As System.Windows.Forms.Label
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
    Friend WithEvents lblSep2 As System.Windows.Forms.Label
    Friend WithEvents pnlSurList As System.Windows.Forms.Panel
    Friend WithEvents cmbSurList As System.Windows.Forms.ComboBox
    Friend WithEvents lblSep4 As System.Windows.Forms.Label
    Friend WithEvents lblSurList As System.Windows.Forms.Label
    Friend WithEvents lblSep3 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteINS As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAddINS As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dgvINStrument As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvDrug As DevComponents.DotNetBar.Controls.DataGridViewX

End Class
