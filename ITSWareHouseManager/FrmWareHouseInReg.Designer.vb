<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseInReg
    Inherits UIControlLib.MyUserControlBase

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
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.pnlBaseTop = New System.Windows.Forms.Panel()
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.cmbINSName = New UIControlLib.CmbDropDownList()
        Me.lblRegistor = New System.Windows.Forms.Label()
        Me.cmbINSType = New System.Windows.Forms.ComboBox()
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.txtINSType = New System.Windows.Forms.TextBox()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.tbRegistor = New System.Windows.Forms.TextBox()
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.pnlDetailBottom = New System.Windows.Forms.Panel()
        Me.pnlDrug = New System.Windows.Forms.Panel()
        Me.txtDrugCompany = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDrugType = New System.Windows.Forms.TextBox()
        Me.cmbDrugUnit = New System.Windows.Forms.ComboBox()
        Me.txtDrugBatch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDrugCount = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpDrugAvailable = New System.Windows.Forms.DateTimePicker()
        Me.dtpDrugProduce = New System.Windows.Forms.DateTimePicker()
        Me.pnlWareHouse = New System.Windows.Forms.Panel()
        Me.cmbCompany = New UIControlLib.CmbDropDownList()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.txtINSUnit = New System.Windows.Forms.TextBox()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.lblMFG = New System.Windows.Forms.Label()
        Me.lblBatchNo = New System.Windows.Forms.Label()
        Me.dtpExpire = New System.Windows.Forms.DateTimePicker()
        Me.txtBatch = New System.Windows.Forms.TextBox()
        Me.dtpProductDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpire = New System.Windows.Forms.Label()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.btnMdfOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.btnDel = New DevComponents.DotNetBar.ButtonX()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.dgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlInfo.SuspendLayout()
        Me.pnlBaseTop.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.pnlDetailBottom.SuspendLayout()
        Me.pnlDrug.SuspendLayout()
        Me.pnlWareHouse.SuspendLayout()
        Me.pnlBtn.SuspendLayout()
        Me.pnlCommit.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlInfo.Controls.Add(Me.pnlBaseTop)
        Me.pnlInfo.Controls.Add(Me.pnlBtn)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 32)
        Me.pnlInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(806, 107)
        Me.pnlInfo.TabIndex = 26
        '
        'pnlBaseTop
        '
        Me.pnlBaseTop.Controls.Add(Me.gbInfo)
        Me.pnlBaseTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBaseTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlBaseTop.Name = "pnlBaseTop"
        Me.pnlBaseTop.Size = New System.Drawing.Size(743, 107)
        Me.pnlBaseTop.TabIndex = 34
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gbInfo.Controls.Add(Me.pnlTop)
        Me.gbInfo.Controls.Add(Me.pnlDetailBottom)
        Me.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.gbInfo.Size = New System.Drawing.Size(743, 107)
        Me.gbInfo.TabIndex = 0
        Me.gbInfo.TabStop = False
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.cmbINSName)
        Me.pnlTop.Controls.Add(Me.lblRegistor)
        Me.pnlTop.Controls.Add(Me.cmbINSType)
        Me.pnlTop.Controls.Add(Me.lblCommonName)
        Me.pnlTop.Controls.Add(Me.txtINSType)
        Me.pnlTop.Controls.Add(Me.lblProductName)
        Me.pnlTop.Controls.Add(Me.tbRegistor)
        Me.pnlTop.Controls.Add(Me.lblSpec)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(2, 16)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(739, 29)
        Me.pnlTop.TabIndex = 33
        '
        'cmbINSName
        '
        Me.cmbINSName.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbINSName.BackColor = System.Drawing.Color.White
        Me.cmbINSName.CodeIndex = 0
        Me.cmbINSName.DisplayIndex = 1
        Me.cmbINSName.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbINSName.FormattingEnabled = True
        Me.cmbINSName.IDContent = Nothing
        Me.cmbINSName.IDIndex = 2
        Me.cmbINSName.IsIgnoreEnter = False
        Me.cmbINSName.IsSelectCont = False
        Me.cmbINSName.Location = New System.Drawing.Point(429, 2)
        Me.cmbINSName.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(116, 20)
        Me.cmbINSName.TabIndex = 29
        Me.cmbINSName.VisibleRowCount = 10
        '
        'lblRegistor
        '
        Me.lblRegistor.AutoSize = True
        Me.lblRegistor.Location = New System.Drawing.Point(2, 6)
        Me.lblRegistor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblRegistor.Name = "lblRegistor"
        Me.lblRegistor.Size = New System.Drawing.Size(53, 12)
        Me.lblRegistor.TabIndex = 0
        Me.lblRegistor.Text = "登 记 人"
        '
        'cmbINSType
        '
        Me.cmbINSType.BackColor = System.Drawing.Color.White
        Me.cmbINSType.FormattingEnabled = True
        Me.cmbINSType.Location = New System.Drawing.Point(240, 2)
        Me.cmbINSType.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSType.Name = "cmbINSType"
        Me.cmbINSType.Size = New System.Drawing.Size(124, 20)
        Me.cmbINSType.TabIndex = 28
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(184, 6)
        Me.lblCommonName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(53, 12)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "物品类别"
        '
        'txtINSType
        '
        Me.txtINSType.BackColor = System.Drawing.Color.Ivory
        Me.txtINSType.Location = New System.Drawing.Point(610, 2)
        Me.txtINSType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtINSType.Name = "txtINSType"
        Me.txtINSType.ReadOnly = True
        Me.txtINSType.Size = New System.Drawing.Size(116, 21)
        Me.txtINSType.TabIndex = 23
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(373, 6)
        Me.lblProductName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(53, 12)
        Me.lblProductName.TabIndex = 4
        Me.lblProductName.Text = "物品名称"
        '
        'tbRegistor
        '
        Me.tbRegistor.BackColor = System.Drawing.Color.Ivory
        Me.tbRegistor.Location = New System.Drawing.Point(57, 2)
        Me.tbRegistor.Margin = New System.Windows.Forms.Padding(2)
        Me.tbRegistor.Name = "tbRegistor"
        Me.tbRegistor.ReadOnly = True
        Me.tbRegistor.Size = New System.Drawing.Size(116, 21)
        Me.tbRegistor.TabIndex = 21
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(554, 6)
        Me.lblSpec.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(53, 12)
        Me.lblSpec.TabIndex = 6
        Me.lblSpec.Text = "物品规格"
        '
        'pnlDetailBottom
        '
        Me.pnlDetailBottom.Controls.Add(Me.pnlDrug)
        Me.pnlDetailBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDetailBottom.Location = New System.Drawing.Point(2, 44)
        Me.pnlDetailBottom.Name = "pnlDetailBottom"
        Me.pnlDetailBottom.Size = New System.Drawing.Size(739, 61)
        Me.pnlDetailBottom.TabIndex = 34
        '
        'pnlDrug
        '
        Me.pnlDrug.Controls.Add(Me.txtDrugCompany)
        Me.pnlDrug.Controls.Add(Me.Label14)
        Me.pnlDrug.Controls.Add(Me.txtDrugType)
        Me.pnlDrug.Controls.Add(Me.cmbDrugUnit)
        Me.pnlDrug.Controls.Add(Me.txtDrugBatch)
        Me.pnlDrug.Controls.Add(Me.Label6)
        Me.pnlDrug.Controls.Add(Me.Label9)
        Me.pnlDrug.Controls.Add(Me.txtDrugCount)
        Me.pnlDrug.Controls.Add(Me.Label10)
        Me.pnlDrug.Controls.Add(Me.Label11)
        Me.pnlDrug.Controls.Add(Me.Label12)
        Me.pnlDrug.Controls.Add(Me.Label13)
        Me.pnlDrug.Controls.Add(Me.dtpDrugAvailable)
        Me.pnlDrug.Controls.Add(Me.dtpDrugProduce)
        Me.pnlDrug.Controls.Add(Me.pnlWareHouse)
        Me.pnlDrug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDrug.Location = New System.Drawing.Point(0, 0)
        Me.pnlDrug.Name = "pnlDrug"
        Me.pnlDrug.Size = New System.Drawing.Size(739, 61)
        Me.pnlDrug.TabIndex = 30
        '
        'txtDrugCompany
        '
        Me.txtDrugCompany.BackColor = System.Drawing.Color.Ivory
        Me.txtDrugCompany.Location = New System.Drawing.Point(240, 5)
        Me.txtDrugCompany.Name = "txtDrugCompany"
        Me.txtDrugCompany.ReadOnly = True
        Me.txtDrugCompany.Size = New System.Drawing.Size(124, 21)
        Me.txtDrugCompany.TabIndex = 50
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(2, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "药品规格"
        '
        'txtDrugType
        '
        Me.txtDrugType.BackColor = System.Drawing.Color.Ivory
        Me.txtDrugType.Location = New System.Drawing.Point(57, 5)
        Me.txtDrugType.Name = "txtDrugType"
        Me.txtDrugType.ReadOnly = True
        Me.txtDrugType.Size = New System.Drawing.Size(116, 21)
        Me.txtDrugType.TabIndex = 49
        '
        'cmbDrugUnit
        '
        Me.cmbDrugUnit.FormattingEnabled = True
        Me.cmbDrugUnit.Location = New System.Drawing.Point(429, 5)
        Me.cmbDrugUnit.Name = "cmbDrugUnit"
        Me.cmbDrugUnit.Size = New System.Drawing.Size(116, 20)
        Me.cmbDrugUnit.TabIndex = 47
        '
        'txtDrugBatch
        '
        Me.txtDrugBatch.Location = New System.Drawing.Point(57, 30)
        Me.txtDrugBatch.Name = "txtDrugBatch"
        Me.txtDrugBatch.Size = New System.Drawing.Size(116, 21)
        Me.txtDrugBatch.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "产品批号"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(373, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "单    位"
        '
        'txtDrugCount
        '
        Me.txtDrugCount.Location = New System.Drawing.Point(610, 5)
        Me.txtDrugCount.Name = "txtDrugCount"
        Me.txtDrugCount.Size = New System.Drawing.Size(116, 21)
        Me.txtDrugCount.TabIndex = 38
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(184, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "厂    家"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(554, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "数    量"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(373, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "有效期至"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(184, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "生产日期"
        '
        'dtpDrugAvailable
        '
        Me.dtpDrugAvailable.CustomFormat = "yyyy-MM-dd"
        Me.dtpDrugAvailable.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDrugAvailable.Location = New System.Drawing.Point(429, 30)
        Me.dtpDrugAvailable.Name = "dtpDrugAvailable"
        Me.dtpDrugAvailable.Size = New System.Drawing.Size(116, 21)
        Me.dtpDrugAvailable.TabIndex = 41
        '
        'dtpDrugProduce
        '
        Me.dtpDrugProduce.CustomFormat = "yyyy-MM-dd"
        Me.dtpDrugProduce.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDrugProduce.Location = New System.Drawing.Point(240, 30)
        Me.dtpDrugProduce.Name = "dtpDrugProduce"
        Me.dtpDrugProduce.Size = New System.Drawing.Size(124, 21)
        Me.dtpDrugProduce.TabIndex = 40
        '
        'pnlWareHouse
        '
        Me.pnlWareHouse.Controls.Add(Me.cmbCompany)
        Me.pnlWareHouse.Controls.Add(Me.lblUnit)
        Me.pnlWareHouse.Controls.Add(Me.Label1)
        Me.pnlWareHouse.Controls.Add(Me.lblAmount)
        Me.pnlWareHouse.Controls.Add(Me.txtINSUnit)
        Me.pnlWareHouse.Controls.Add(Me.txtCount)
        Me.pnlWareHouse.Controls.Add(Me.lblMFG)
        Me.pnlWareHouse.Controls.Add(Me.lblBatchNo)
        Me.pnlWareHouse.Controls.Add(Me.dtpExpire)
        Me.pnlWareHouse.Controls.Add(Me.txtBatch)
        Me.pnlWareHouse.Controls.Add(Me.dtpProductDate)
        Me.pnlWareHouse.Controls.Add(Me.lblExpire)
        Me.pnlWareHouse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWareHouse.Location = New System.Drawing.Point(0, 0)
        Me.pnlWareHouse.Name = "pnlWareHouse"
        Me.pnlWareHouse.Size = New System.Drawing.Size(739, 61)
        Me.pnlWareHouse.TabIndex = 32
        '
        'cmbCompany
        '
        Me.cmbCompany.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbCompany.BackColor = System.Drawing.Color.White
        Me.cmbCompany.CodeIndex = 0
        Me.cmbCompany.DisplayIndex = 1
        Me.cmbCompany.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.IDContent = Nothing
        Me.cmbCompany.IDIndex = 2
        Me.cmbCompany.IsIgnoreEnter = False
        Me.cmbCompany.IsSelectCont = False
        Me.cmbCompany.Location = New System.Drawing.Point(240, 4)
        Me.cmbCompany.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.RowHeight = 19
        Me.cmbCompany.Size = New System.Drawing.Size(124, 20)
        Me.cmbCompany.TabIndex = 30
        Me.cmbCompany.VisibleRowCount = 10
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(2, 8)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(53, 12)
        Me.lblUnit.TabIndex = 10
        Me.lblUnit.Text = "单    位"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "厂    家"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(184, 33)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(53, 12)
        Me.lblAmount.TabIndex = 12
        Me.lblAmount.Text = "数    量"
        '
        'txtINSUnit
        '
        Me.txtINSUnit.BackColor = System.Drawing.Color.Ivory
        Me.txtINSUnit.Location = New System.Drawing.Point(57, 4)
        Me.txtINSUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.txtINSUnit.Name = "txtINSUnit"
        Me.txtINSUnit.ReadOnly = True
        Me.txtINSUnit.Size = New System.Drawing.Size(116, 21)
        Me.txtINSUnit.TabIndex = 25
        '
        'txtCount
        '
        Me.txtCount.BackColor = System.Drawing.Color.White
        Me.txtCount.Location = New System.Drawing.Point(240, 29)
        Me.txtCount.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(124, 21)
        Me.txtCount.TabIndex = 13
        '
        'lblMFG
        '
        Me.lblMFG.AutoSize = True
        Me.lblMFG.Location = New System.Drawing.Point(554, 8)
        Me.lblMFG.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMFG.Name = "lblMFG"
        Me.lblMFG.Size = New System.Drawing.Size(53, 12)
        Me.lblMFG.TabIndex = 14
        Me.lblMFG.Text = "生产日期"
        '
        'lblBatchNo
        '
        Me.lblBatchNo.AutoSize = True
        Me.lblBatchNo.Location = New System.Drawing.Point(373, 8)
        Me.lblBatchNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(53, 12)
        Me.lblBatchNo.TabIndex = 16
        Me.lblBatchNo.Text = "产品批号"
        '
        'dtpExpire
        '
        Me.dtpExpire.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dtpExpire.CustomFormat = "yyyy-MM-dd"
        Me.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpire.Location = New System.Drawing.Point(57, 29)
        Me.dtpExpire.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpExpire.Name = "dtpExpire"
        Me.dtpExpire.Size = New System.Drawing.Size(116, 21)
        Me.dtpExpire.TabIndex = 20
        '
        'txtBatch
        '
        Me.txtBatch.BackColor = System.Drawing.Color.White
        Me.txtBatch.Location = New System.Drawing.Point(429, 4)
        Me.txtBatch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.Size = New System.Drawing.Size(116, 21)
        Me.txtBatch.TabIndex = 17
        '
        'dtpProductDate
        '
        Me.dtpProductDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dtpProductDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpProductDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProductDate.Location = New System.Drawing.Point(610, 4)
        Me.dtpProductDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpProductDate.Name = "dtpProductDate"
        Me.dtpProductDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpProductDate.TabIndex = 19
        '
        'lblExpire
        '
        Me.lblExpire.AutoSize = True
        Me.lblExpire.Location = New System.Drawing.Point(2, 33)
        Me.lblExpire.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpire.Name = "lblExpire"
        Me.lblExpire.Size = New System.Drawing.Size(53, 12)
        Me.lblExpire.TabIndex = 18
        Me.lblExpire.Text = "有效期至"
        '
        'pnlBtn
        '
        Me.pnlBtn.Controls.Add(Me.btnAdd)
        Me.pnlBtn.Controls.Add(Me.btnMdfOk)
        Me.pnlBtn.Controls.Add(Me.btnCancel)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBtn.Location = New System.Drawing.Point(743, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(63, 107)
        Me.pnlBtn.TabIndex = 33
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAdd.Location = New System.Drawing.Point(11, 33)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(58, 22)
        Me.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "添加"
        '
        'btnMdfOk
        '
        Me.btnMdfOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMdfOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnMdfOk.Location = New System.Drawing.Point(11, 33)
        Me.btnMdfOk.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMdfOk.Name = "btnMdfOk"
        Me.btnMdfOk.Size = New System.Drawing.Size(58, 22)
        Me.btnMdfOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnMdfOk.TabIndex = 33
        Me.btnMdfOk.Text = "确认"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(11, 60)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "取消"
        '
        'pnlCommit
        '
        Me.pnlCommit.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlCommit.Controls.Add(Me.btnClear)
        Me.pnlCommit.Controls.Add(Me.btnDel)
        Me.pnlCommit.Controls.Add(Me.btnOk)
        Me.pnlCommit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommit.Location = New System.Drawing.Point(0, 387)
        Me.pnlCommit.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCommit.Name = "pnlCommit"
        Me.pnlCommit.Size = New System.Drawing.Size(806, 29)
        Me.pnlCommit.TabIndex = 28
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnClear.Location = New System.Drawing.Point(743, 4)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(58, 22)
        Me.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnClear.TabIndex = 25
        Me.btnClear.Text = "清屏"
        '
        'btnDel
        '
        Me.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDel.Location = New System.Drawing.Point(619, 4)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(58, 22)
        Me.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnDel.TabIndex = 24
        Me.btnDel.Text = "删除"
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOk.Location = New System.Drawing.Point(681, 4)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(58, 22)
        Me.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnOk.TabIndex = 23
        Me.btnOk.Text = "确认"
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(806, 32)
        Me.pnlFunc.TabIndex = 29
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
        Me.dgv.Location = New System.Drawing.Point(0, 139)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(806, 248)
        Me.dgv.TabIndex = 30
        '
        'FrmWareHouseInReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.pnlCommit)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmWareHouseInReg"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlBaseTop.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlDetailBottom.ResumeLayout(False)
        Me.pnlDrug.ResumeLayout(False)
        Me.pnlDrug.PerformLayout()
        Me.pnlWareHouse.ResumeLayout(False)
        Me.pnlWareHouse.PerformLayout()
        Me.pnlBtn.ResumeLayout(False)
        Me.pnlCommit.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCompany As UIControlLib.CmbDropDownList
    Friend WithEvents cmbINSName As UIControlLib.CmbDropDownList
    Friend WithEvents cmbINSType As System.Windows.Forms.ComboBox
    Friend WithEvents txtINSUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtINSType As System.Windows.Forms.TextBox
    Friend WithEvents tbRegistor As System.Windows.Forms.TextBox
    Friend WithEvents dtpExpire As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpProductDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExpire As System.Windows.Forms.Label
    Friend WithEvents txtBatch As System.Windows.Forms.TextBox
    Friend WithEvents lblBatchNo As System.Windows.Forms.Label
    Friend WithEvents lblMFG As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSpec As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents lblRegistor As System.Windows.Forms.Label
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlBtn As System.Windows.Forms.Panel
    Friend WithEvents pnlBaseTop As System.Windows.Forms.Panel
    Friend WithEvents pnlWareHouse As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlDrug As System.Windows.Forms.Panel
    Friend WithEvents txtDrugCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDrugType As System.Windows.Forms.TextBox
    Friend WithEvents cmbDrugUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtDrugBatch As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDrugCount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpDrugAvailable As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDrugProduce As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnMdfOk As DevComponents.DotNetBar.ButtonX

End Class
