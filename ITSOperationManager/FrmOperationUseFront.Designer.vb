Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperationUseFront
    Inherits MyUserControlBase

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
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
        Me.pnlInstrumentDGV = New System.Windows.Forms.Panel()
        Me.dgvInstrument = New UIControlLib.UIDataGridView()
        Me.pnlInstrumentFunc = New System.Windows.Forms.Panel()
        Me.txtInsScan = New System.Windows.Forms.TextBox()
        Me.lblInsScan = New System.Windows.Forms.Label()
        Me.btnInsConfirm = New UIControlLib.LabelEx()
        Me.tbDiagnosis = New System.Windows.Forms.TextBox()
        Me.tbMemo = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.lblSurTime = New System.Windows.Forms.Label()
        Me.lblSurName = New System.Windows.Forms.Label()
        Me.tbSurName = New System.Windows.Forms.TextBox()
        Me.tbSurTime = New System.Windows.Forms.TextBox()
        Me.pnlInstrument = New System.Windows.Forms.Panel()
        Me.btnOK = New UIControlLib.LabelEx()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.lblSurRoom = New System.Windows.Forms.Label()
        Me.tbSurRoom = New System.Windows.Forms.TextBox()
        Me.lblTable = New System.Windows.Forms.Label()
        Me.tbVisit = New System.Windows.Forms.TextBox()
        Me.lblSep = New System.Windows.Forms.Label()
        Me.tbTable = New System.Windows.Forms.TextBox()
        Me.pnlDrugFunc = New System.Windows.Forms.Panel()
        Me.btnMed = New UIControlLib.LabelEx()
        Me.lblVisit = New System.Windows.Forms.Label()
        Me.tbPatName = New System.Windows.Forms.TextBox()
        Me.lblPatName = New System.Windows.Forms.Label()
        Me.tbGender = New System.Windows.Forms.TextBox()
        Me.tbAge = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.tbSurDr = New System.Windows.Forms.TextBox()
        Me.pnlDrugDGV = New System.Windows.Forms.Panel()
        Me.dgvDrug = New UIControlLib.UIDataGridView()
        Me.pnlDrug = New System.Windows.Forms.Panel()
        Me.cmbSurList = New System.Windows.Forms.ComboBox()
        Me.lblSurList = New System.Windows.Forms.Label()
        Me.pnlSurList = New System.Windows.Forms.Panel()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblSurDr = New System.Windows.Forms.Label()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.gbSurDetail = New System.Windows.Forms.GroupBox()
        Me.pnlSurInfo = New System.Windows.Forms.Panel()
        Me.pnlInstrumentDGV.SuspendLayout()
        CType(Me.dgvInstrument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInstrumentFunc.SuspendLayout()
        Me.pnlInstrument.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.pnlDrugFunc.SuspendLayout()
        Me.pnlDrugDGV.SuspendLayout()
        CType(Me.dgvDrug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDrug.SuspendLayout()
        Me.pnlSurList.SuspendLayout()
        Me.gbSurDetail.SuspendLayout()
        Me.pnlSurInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInstrumentDGV
        '
        Me.pnlInstrumentDGV.Controls.Add(Me.dgvInstrument)
        Me.pnlInstrumentDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInstrumentDGV.Location = New System.Drawing.Point(0, 37)
        Me.pnlInstrumentDGV.Name = "pnlInstrumentDGV"
        Me.pnlInstrumentDGV.Size = New System.Drawing.Size(668, 218)
        Me.pnlInstrumentDGV.TabIndex = 1
        '
        'dgvInstrument
        '
        Me.dgvInstrument.AllowDelete = True
        Me.dgvInstrument.AllowSelectChangeRow = False
        Me.dgvInstrument.AllowSort = True
        Me.dgvInstrument.AllowUserToAddRows = False
        Me.dgvInstrument.AllowUserToResizeColumns = False
        Me.dgvInstrument.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvInstrument.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInstrument.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvInstrument.BeQuerying = False
        Me.dgvInstrument.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvInstrument.ChangeHeaderSize = False
        Me.dgvInstrument.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInstrument.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInstrument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInstrument.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInstrument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInstrument.EnableHeadersVisualStyles = False
        Me.dgvInstrument.Location = New System.Drawing.Point(0, 0)
        Me.dgvInstrument.MultiSelect = False
        Me.dgvInstrument.Name = "dgvInstrument"
        Me.dgvInstrument.NoItemAlter = ""
        Me.dgvInstrument.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvInstrument.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvInstrument.RowTemplate.Height = 23
        Me.dgvInstrument.SelCombineKeyEnable = False
        Me.dgvInstrument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInstrument.ShowSelectionColor = True
        Me.dgvInstrument.Size = New System.Drawing.Size(668, 218)
        Me.dgvInstrument.TabIndex = 13
        '
        'pnlInstrumentFunc
        '
        Me.pnlInstrumentFunc.Controls.Add(Me.txtInsScan)
        Me.pnlInstrumentFunc.Controls.Add(Me.lblInsScan)
        Me.pnlInstrumentFunc.Controls.Add(Me.btnInsConfirm)
        Me.pnlInstrumentFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInstrumentFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlInstrumentFunc.Name = "pnlInstrumentFunc"
        Me.pnlInstrumentFunc.Size = New System.Drawing.Size(668, 37)
        Me.pnlInstrumentFunc.TabIndex = 2
        '
        'txtInsScan
        '
        Me.txtInsScan.Location = New System.Drawing.Point(76, 5)
        Me.txtInsScan.Name = "txtInsScan"
        Me.txtInsScan.Size = New System.Drawing.Size(171, 26)
        Me.txtInsScan.TabIndex = 5
        '
        'lblInsScan
        '
        Me.lblInsScan.AutoSize = True
        Me.lblInsScan.Location = New System.Drawing.Point(3, 10)
        Me.lblInsScan.Name = "lblInsScan"
        Me.lblInsScan.Size = New System.Drawing.Size(72, 16)
        Me.lblInsScan.TabIndex = 4
        Me.lblInsScan.Text = "器械扫描"
        '
        'btnInsConfirm
        '
        Me.btnInsConfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsConfirm.BackColor = System.Drawing.Color.Transparent
        Me.btnInsConfirm.Fore_Color = System.Drawing.Color.Black
        Me.btnInsConfirm.ForeColor = System.Drawing.Color.Transparent
        Me.btnInsConfirm.Location = New System.Drawing.Point(577, 5)
        Me.btnInsConfirm.Name = "btnInsConfirm"
        Me.btnInsConfirm.Size = New System.Drawing.Size(86, 30)
        Me.btnInsConfirm.TabIndex = 3
        Me.btnInsConfirm.Text = "拆包确认确认"
        Me.btnInsConfirm.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnInsConfirm.TipText = ""
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
        'pnlInstrument
        '
        Me.pnlInstrument.Controls.Add(Me.pnlInstrumentDGV)
        Me.pnlInstrument.Controls.Add(Me.pnlInstrumentFunc)
        Me.pnlInstrument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInstrument.Location = New System.Drawing.Point(302, 305)
        Me.pnlInstrument.Name = "pnlInstrument"
        Me.pnlInstrument.Size = New System.Drawing.Size(668, 255)
        Me.pnlInstrument.TabIndex = 19
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Fore_Color = System.Drawing.Color.Black
        Me.btnOK.ForeColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(277, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 30)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "确认"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.TipText = ""
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnOK)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(302, 560)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(668, 37)
        Me.pnlFunc.TabIndex = 18
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
        'lblSep
        '
        Me.lblSep.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSep.Location = New System.Drawing.Point(302, 295)
        Me.lblSep.Name = "lblSep"
        Me.lblSep.Size = New System.Drawing.Size(668, 10)
        Me.lblSep.TabIndex = 17
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
        'pnlDrugFunc
        '
        Me.pnlDrugFunc.Controls.Add(Me.btnMed)
        Me.pnlDrugFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDrugFunc.Location = New System.Drawing.Point(0, 219)
        Me.pnlDrugFunc.Name = "pnlDrugFunc"
        Me.pnlDrugFunc.Size = New System.Drawing.Size(668, 38)
        Me.pnlDrugFunc.TabIndex = 1
        '
        'btnMed
        '
        Me.btnMed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMed.BackColor = System.Drawing.Color.Transparent
        Me.btnMed.Fore_Color = System.Drawing.Color.Black
        Me.btnMed.ForeColor = System.Drawing.Color.Transparent
        Me.btnMed.Location = New System.Drawing.Point(577, 5)
        Me.btnMed.Name = "btnMed"
        Me.btnMed.Size = New System.Drawing.Size(86, 30)
        Me.btnMed.TabIndex = 1
        Me.btnMed.Text = "药品确认"
        Me.btnMed.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMed.TipText = ""
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
        'pnlDrugDGV
        '
        Me.pnlDrugDGV.Controls.Add(Me.dgvDrug)
        Me.pnlDrugDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDrugDGV.Location = New System.Drawing.Point(0, 0)
        Me.pnlDrugDGV.Name = "pnlDrugDGV"
        Me.pnlDrugDGV.Size = New System.Drawing.Size(668, 219)
        Me.pnlDrugDGV.TabIndex = 0
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
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
        Me.dgvDrug.RowTemplate.Height = 23
        Me.dgvDrug.SelCombineKeyEnable = False
        Me.dgvDrug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDrug.ShowSelectionColor = True
        Me.dgvDrug.Size = New System.Drawing.Size(668, 219)
        Me.dgvDrug.TabIndex = 12
        '
        'pnlDrug
        '
        Me.pnlDrug.Controls.Add(Me.pnlDrugDGV)
        Me.pnlDrug.Controls.Add(Me.pnlDrugFunc)
        Me.pnlDrug.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDrug.Location = New System.Drawing.Point(302, 38)
        Me.pnlDrug.Name = "pnlDrug"
        Me.pnlDrug.Size = New System.Drawing.Size(668, 257)
        Me.pnlDrug.TabIndex = 16
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
        'pnlSurList
        '
        Me.pnlSurList.Controls.Add(Me.cmbSurList)
        Me.pnlSurList.Controls.Add(Me.lblSurList)
        Me.pnlSurList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSurList.Location = New System.Drawing.Point(0, 0)
        Me.pnlSurList.Name = "pnlSurList"
        Me.pnlSurList.Size = New System.Drawing.Size(302, 49)
        Me.pnlSurList.TabIndex = 2
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
        Me.gbSurDetail.Location = New System.Drawing.Point(0, 49)
        Me.gbSurDetail.Name = "gbSurDetail"
        Me.gbSurDetail.Size = New System.Drawing.Size(302, 510)
        Me.gbSurDetail.TabIndex = 3
        Me.gbSurDetail.TabStop = False
        Me.gbSurDetail.Text = "手术详细信息"
        '
        'pnlSurInfo
        '
        Me.pnlSurInfo.Controls.Add(Me.gbSurDetail)
        Me.pnlSurInfo.Controls.Add(Me.pnlSurList)
        Me.pnlSurInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSurInfo.Location = New System.Drawing.Point(0, 38)
        Me.pnlSurInfo.Name = "pnlSurInfo"
        Me.pnlSurInfo.Size = New System.Drawing.Size(302, 559)
        Me.pnlSurInfo.TabIndex = 15
        '
        'FrmOperationUseFront
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlInstrument)
        Me.Controls.Add(Me.pnlFunc)
        Me.Controls.Add(Me.lblSep)
        Me.Controls.Add(Me.pnlDrug)
        Me.Controls.Add(Me.pnlSurInfo)
        Me.Name = "FrmOperationUseFront"
        Me.Controls.SetChildIndex(Me.pnlSurInfo, 0)
        Me.Controls.SetChildIndex(Me.pnlDrug, 0)
        Me.Controls.SetChildIndex(Me.lblSep, 0)
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.pnlInstrument, 0)
        Me.pnlInstrumentDGV.ResumeLayout(False)
        CType(Me.dgvInstrument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInstrumentFunc.ResumeLayout(False)
        Me.pnlInstrumentFunc.PerformLayout()
        Me.pnlInstrument.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlDrugFunc.ResumeLayout(False)
        Me.pnlDrugDGV.ResumeLayout(False)
        CType(Me.dgvDrug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDrug.ResumeLayout(False)
        Me.pnlSurList.ResumeLayout(False)
        Me.pnlSurList.PerformLayout()
        Me.gbSurDetail.ResumeLayout(False)
        Me.gbSurDetail.PerformLayout()
        Me.pnlSurInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInstrumentDGV As System.Windows.Forms.Panel
    Friend WithEvents dgvInstrument As UIControlLib.UIDataGridView
    Friend WithEvents pnlInstrumentFunc As System.Windows.Forms.Panel
    Friend WithEvents txtInsScan As System.Windows.Forms.TextBox
    Friend WithEvents lblInsScan As System.Windows.Forms.Label
    Friend WithEvents btnInsConfirm As UIControlLib.LabelEx
    Friend WithEvents tbDiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents tbMemo As System.Windows.Forms.TextBox
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents lblSurTime As System.Windows.Forms.Label
    Friend WithEvents lblSurName As System.Windows.Forms.Label
    Friend WithEvents tbSurName As System.Windows.Forms.TextBox
    Friend WithEvents tbSurTime As System.Windows.Forms.TextBox
    Friend WithEvents pnlInstrument As System.Windows.Forms.Panel
    Friend WithEvents btnOK As UIControlLib.LabelEx
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents lblSurRoom As System.Windows.Forms.Label
    Friend WithEvents tbSurRoom As System.Windows.Forms.TextBox
    Friend WithEvents lblTable As System.Windows.Forms.Label
    Friend WithEvents tbVisit As System.Windows.Forms.TextBox
    Friend WithEvents lblSep As System.Windows.Forms.Label
    Friend WithEvents tbTable As System.Windows.Forms.TextBox
    Friend WithEvents pnlDrugFunc As System.Windows.Forms.Panel
    Friend WithEvents btnMed As UIControlLib.LabelEx
    Friend WithEvents lblVisit As System.Windows.Forms.Label
    Friend WithEvents tbPatName As System.Windows.Forms.TextBox
    Friend WithEvents lblPatName As System.Windows.Forms.Label
    Friend WithEvents tbGender As System.Windows.Forms.TextBox
    Friend WithEvents tbAge As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents tbSurDr As System.Windows.Forms.TextBox
    Friend WithEvents pnlDrugDGV As System.Windows.Forms.Panel
    Friend WithEvents dgvDrug As UIControlLib.UIDataGridView
    Friend WithEvents pnlDrug As System.Windows.Forms.Panel
    Friend WithEvents cmbSurList As System.Windows.Forms.ComboBox
    Friend WithEvents lblSurList As System.Windows.Forms.Label
    Friend WithEvents pnlSurList As System.Windows.Forms.Panel
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblSurDr As System.Windows.Forms.Label
    Friend WithEvents lblMemo As System.Windows.Forms.Label
    Friend WithEvents gbSurDetail As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSurInfo As System.Windows.Forms.Panel

End Class
