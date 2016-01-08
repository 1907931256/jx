Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDrugOutReg
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.btnCancel = New UIControlLib.LabelEx()
        Me.btnAdd = New UIControlLib.LabelEx()
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.tbUnit = New System.Windows.Forms.TextBox()
        Me.tbCode = New System.Windows.Forms.TextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.tbRegistor = New System.Windows.Forms.TextBox()
        Me.cmbOutType = New System.Windows.Forms.ComboBox()
        Me.lblOutType = New System.Windows.Forms.Label()
        Me.dtpExpire = New System.Windows.Forms.DateTimePicker()
        Me.dtpMFG = New System.Windows.Forms.DateTimePicker()
        Me.lblExpire = New System.Windows.Forms.Label()
        Me.tbBatchNo = New System.Windows.Forms.TextBox()
        Me.lblBatchNo = New System.Windows.Forms.Label()
        Me.lblMFG = New System.Windows.Forms.Label()
        Me.tbAmount = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.tbFactory = New UIControlLib.UIDropDownList(Me.components)
        Me.lblFactory = New System.Windows.Forms.Label()
        Me.tbSpec = New UIControlLib.UIDropDownList(Me.components)
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.tbProductName = New UIControlLib.UIDropDownList(Me.components)
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.ddlCommonName = New UIControlLib.UIDropDownList(Me.components)
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.lblRegistor = New System.Windows.Forms.Label()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClear = New UIControlLib.LabelEx()
        Me.btnDel = New UIControlLib.LabelEx()
        Me.btnModify = New UIControlLib.LabelEx()
        Me.btnOk = New UIControlLib.LabelEx()
        Me.pnlDgv = New System.Windows.Forms.Panel()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.btnMdfOk = New UIControlLib.LabelEx()
        Me.pnlInfo.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.pnlDgv.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.Size = New System.Drawing.Size(1074, 42)
        Me.LblTitle.Text = "药品出库登记"
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.btnMdfOk)
        Me.pnlInfo.Controls.Add(Me.btnCancel)
        Me.pnlInfo.Controls.Add(Me.btnAdd)
        Me.pnlInfo.Controls.Add(Me.gbInfo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 42)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(1074, 112)
        Me.pnlInfo.TabIndex = 9
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(993, 79)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.TipText = ""
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Fore_Color = System.Drawing.Color.Black
        Me.btnAdd.ForeColor = System.Drawing.Color.Transparent
        Me.btnAdd.Location = New System.Drawing.Point(993, 45)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "添加"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.TipText = ""
        '
        'gbInfo
        '
        Me.gbInfo.Controls.Add(Me.tbUnit)
        Me.gbInfo.Controls.Add(Me.tbCode)
        Me.gbInfo.Controls.Add(Me.lblCode)
        Me.gbInfo.Controls.Add(Me.tbRegistor)
        Me.gbInfo.Controls.Add(Me.cmbOutType)
        Me.gbInfo.Controls.Add(Me.lblOutType)
        Me.gbInfo.Controls.Add(Me.dtpExpire)
        Me.gbInfo.Controls.Add(Me.dtpMFG)
        Me.gbInfo.Controls.Add(Me.lblExpire)
        Me.gbInfo.Controls.Add(Me.tbBatchNo)
        Me.gbInfo.Controls.Add(Me.lblBatchNo)
        Me.gbInfo.Controls.Add(Me.lblMFG)
        Me.gbInfo.Controls.Add(Me.tbAmount)
        Me.gbInfo.Controls.Add(Me.lblAmount)
        Me.gbInfo.Controls.Add(Me.lblUnit)
        Me.gbInfo.Controls.Add(Me.tbFactory)
        Me.gbInfo.Controls.Add(Me.lblFactory)
        Me.gbInfo.Controls.Add(Me.tbSpec)
        Me.gbInfo.Controls.Add(Me.lblSpec)
        Me.gbInfo.Controls.Add(Me.tbProductName)
        Me.gbInfo.Controls.Add(Me.lblProductName)
        Me.gbInfo.Controls.Add(Me.ddlCommonName)
        Me.gbInfo.Controls.Add(Me.lblCommonName)
        Me.gbInfo.Controls.Add(Me.lblRegistor)
        Me.gbInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Size = New System.Drawing.Size(987, 112)
        Me.gbInfo.TabIndex = 0
        Me.gbInfo.TabStop = False
        '
        'tbUnit
        '
        Me.tbUnit.BackColor = System.Drawing.Color.Ivory
        Me.tbUnit.Location = New System.Drawing.Point(577, 49)
        Me.tbUnit.Name = "tbUnit"
        Me.tbUnit.ReadOnly = True
        Me.tbUnit.Size = New System.Drawing.Size(154, 26)
        Me.tbUnit.TabIndex = 26
        '
        'tbCode
        '
        Me.tbCode.Location = New System.Drawing.Point(825, 78)
        Me.tbCode.Name = "tbCode"
        Me.tbCode.Size = New System.Drawing.Size(154, 26)
        Me.tbCode.TabIndex = 25
        Me.tbCode.Visible = False
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(750, 82)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(72, 16)
        Me.lblCode.TabIndex = 24
        Me.lblCode.Text = "药品别称"
        Me.lblCode.Visible = False
        '
        'tbRegistor
        '
        Me.tbRegistor.BackColor = System.Drawing.Color.Ivory
        Me.tbRegistor.Location = New System.Drawing.Point(329, 18)
        Me.tbRegistor.Name = "tbRegistor"
        Me.tbRegistor.ReadOnly = True
        Me.tbRegistor.Size = New System.Drawing.Size(154, 26)
        Me.tbRegistor.TabIndex = 23
        '
        'cmbOutType
        '
        Me.cmbOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOutType.FormattingEnabled = True
        Me.cmbOutType.Location = New System.Drawing.Point(81, 18)
        Me.cmbOutType.Name = "cmbOutType"
        Me.cmbOutType.Size = New System.Drawing.Size(154, 24)
        Me.cmbOutType.TabIndex = 22
        '
        'lblOutType
        '
        Me.lblOutType.AutoSize = True
        Me.lblOutType.Location = New System.Drawing.Point(6, 22)
        Me.lblOutType.Name = "lblOutType"
        Me.lblOutType.Size = New System.Drawing.Size(72, 16)
        Me.lblOutType.TabIndex = 21
        Me.lblOutType.Text = "出库类型"
        '
        'dtpExpire
        '
        Me.dtpExpire.CustomFormat = "yyyy-MM-dd"
        Me.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpire.Location = New System.Drawing.Point(577, 78)
        Me.dtpExpire.Name = "dtpExpire"
        Me.dtpExpire.Size = New System.Drawing.Size(154, 26)
        Me.dtpExpire.TabIndex = 20
        '
        'dtpMFG
        '
        Me.dtpMFG.CustomFormat = "yyyy-MM-dd"
        Me.dtpMFG.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMFG.Location = New System.Drawing.Point(81, 78)
        Me.dtpMFG.Name = "dtpMFG"
        Me.dtpMFG.Size = New System.Drawing.Size(154, 26)
        Me.dtpMFG.TabIndex = 19
        '
        'lblExpire
        '
        Me.lblExpire.AutoSize = True
        Me.lblExpire.Location = New System.Drawing.Point(502, 84)
        Me.lblExpire.Name = "lblExpire"
        Me.lblExpire.Size = New System.Drawing.Size(72, 16)
        Me.lblExpire.TabIndex = 18
        Me.lblExpire.Text = "有效期至"
        '
        'tbBatchNo
        '
        Me.tbBatchNo.Location = New System.Drawing.Point(329, 78)
        Me.tbBatchNo.Name = "tbBatchNo"
        Me.tbBatchNo.Size = New System.Drawing.Size(154, 26)
        Me.tbBatchNo.TabIndex = 17
        '
        'lblBatchNo
        '
        Me.lblBatchNo.AutoSize = True
        Me.lblBatchNo.Location = New System.Drawing.Point(254, 84)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(72, 16)
        Me.lblBatchNo.TabIndex = 16
        Me.lblBatchNo.Text = "产品批号"
        '
        'lblMFG
        '
        Me.lblMFG.AutoSize = True
        Me.lblMFG.Location = New System.Drawing.Point(6, 84)
        Me.lblMFG.Name = "lblMFG"
        Me.lblMFG.Size = New System.Drawing.Size(72, 16)
        Me.lblMFG.TabIndex = 14
        Me.lblMFG.Text = "生产日期"
        '
        'tbAmount
        '
        Me.tbAmount.Location = New System.Drawing.Point(825, 48)
        Me.tbAmount.Name = "tbAmount"
        Me.tbAmount.Size = New System.Drawing.Size(154, 26)
        Me.tbAmount.TabIndex = 13
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(750, 53)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(72, 16)
        Me.lblAmount.TabIndex = 12
        Me.lblAmount.Text = "数    量"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(502, 53)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(72, 16)
        Me.lblUnit.TabIndex = 10
        Me.lblUnit.Text = "单    位"
        '
        'tbFactory
        '
        Me.tbFactory.BackColor = System.Drawing.Color.Ivory
        Me.tbFactory.ColNoOfCode = 0
        Me.tbFactory.ColNoOfContent = 1
        Me.tbFactory.ContentID = 2
        Me.tbFactory.DisplayContent = ""
        Me.tbFactory.IDContent = ""
        Me.tbFactory.Location = New System.Drawing.Point(329, 48)
        Me.tbFactory.Name = "tbFactory"
        Me.tbFactory.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.tbFactory.ReadOnly = True
        Me.tbFactory.Size = New System.Drawing.Size(154, 26)
        Me.tbFactory.TabIndex = 9
        Me.tbFactory.TabStop = False
        Me.tbFactory.VisibleRowCount = 10
        '
        'lblFactory
        '
        Me.lblFactory.AutoSize = True
        Me.lblFactory.Location = New System.Drawing.Point(254, 53)
        Me.lblFactory.Name = "lblFactory"
        Me.lblFactory.Size = New System.Drawing.Size(72, 16)
        Me.lblFactory.TabIndex = 8
        Me.lblFactory.Text = "厂    家"
        '
        'tbSpec
        '
        Me.tbSpec.BackColor = System.Drawing.Color.Ivory
        Me.tbSpec.ColNoOfCode = 0
        Me.tbSpec.ColNoOfContent = 1
        Me.tbSpec.ContentID = 2
        Me.tbSpec.DisplayContent = ""
        Me.tbSpec.IDContent = ""
        Me.tbSpec.Location = New System.Drawing.Point(81, 48)
        Me.tbSpec.Name = "tbSpec"
        Me.tbSpec.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.tbSpec.ReadOnly = True
        Me.tbSpec.Size = New System.Drawing.Size(154, 26)
        Me.tbSpec.TabIndex = 7
        Me.tbSpec.TabStop = False
        Me.tbSpec.VisibleRowCount = 10
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(6, 53)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(72, 16)
        Me.lblSpec.TabIndex = 6
        Me.lblSpec.Text = "药品规格"
        '
        'tbProductName
        '
        Me.tbProductName.BackColor = System.Drawing.Color.Ivory
        Me.tbProductName.ColNoOfCode = 0
        Me.tbProductName.ColNoOfContent = 1
        Me.tbProductName.ContentID = 2
        Me.tbProductName.DisplayContent = ""
        Me.tbProductName.IDContent = ""
        Me.tbProductName.Location = New System.Drawing.Point(825, 18)
        Me.tbProductName.Name = "tbProductName"
        Me.tbProductName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.tbProductName.ReadOnly = True
        Me.tbProductName.Size = New System.Drawing.Size(154, 26)
        Me.tbProductName.TabIndex = 5
        Me.tbProductName.TabStop = False
        Me.tbProductName.VisibleRowCount = 10
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(750, 22)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(72, 16)
        Me.lblProductName.TabIndex = 4
        Me.lblProductName.Text = "药品别称"
        '
        'ddlCommonName
        '
        Me.ddlCommonName.ColNoOfCode = 0
        Me.ddlCommonName.ColNoOfContent = 1
        Me.ddlCommonName.ContentID = 2
        Me.ddlCommonName.DisplayContent = ""
        Me.ddlCommonName.IDContent = ""
        Me.ddlCommonName.Location = New System.Drawing.Point(577, 18)
        Me.ddlCommonName.Name = "ddlCommonName"
        Me.ddlCommonName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.ddlCommonName.Size = New System.Drawing.Size(154, 26)
        Me.ddlCommonName.TabIndex = 3
        Me.ddlCommonName.VisibleRowCount = 10
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(502, 22)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(72, 16)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "药品名称"
        '
        'lblRegistor
        '
        Me.lblRegistor.AutoSize = True
        Me.lblRegistor.Location = New System.Drawing.Point(254, 22)
        Me.lblRegistor.Name = "lblRegistor"
        Me.lblRegistor.Size = New System.Drawing.Size(72, 16)
        Me.lblRegistor.TabIndex = 0
        Me.lblRegistor.Text = "登 记 人"
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnClear)
        Me.pnlFunc.Controls.Add(Me.btnDel)
        Me.pnlFunc.Controls.Add(Me.btnModify)
        Me.pnlFunc.Controls.Add(Me.btnOk)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 516)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(1074, 39)
        Me.pnlFunc.TabIndex = 10
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.Fore_Color = System.Drawing.Color.Black
        Me.btnClear.ForeColor = System.Drawing.Color.Transparent
        Me.btnClear.Location = New System.Drawing.Point(993, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 30)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "清屏"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClear.TipText = ""
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.BackColor = System.Drawing.Color.Transparent
        Me.btnDel.Fore_Color = System.Drawing.Color.Black
        Me.btnDel.ForeColor = System.Drawing.Color.Transparent
        Me.btnDel.Location = New System.Drawing.Point(837, 5)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 30)
        Me.btnDel.TabIndex = 2
        Me.btnDel.Text = "删除"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDel.TipText = ""
        '
        'btnModify
        '
        Me.btnModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModify.BackColor = System.Drawing.Color.Transparent
        Me.btnModify.Fore_Color = System.Drawing.Color.Black
        Me.btnModify.ForeColor = System.Drawing.Color.Transparent
        Me.btnModify.Location = New System.Drawing.Point(759, 5)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(75, 30)
        Me.btnModify.TabIndex = 1
        Me.btnModify.Text = "修改"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModify.TipText = ""
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.Fore_Color = System.Drawing.Color.Black
        Me.btnOk.ForeColor = System.Drawing.Color.Transparent
        Me.btnOk.Location = New System.Drawing.Point(915, 5)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 30)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "确定"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOk.TipText = ""
        '
        'pnlDgv
        '
        Me.pnlDgv.Controls.Add(Me.dgv)
        Me.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDgv.Location = New System.Drawing.Point(0, 154)
        Me.pnlDgv.Name = "pnlDgv"
        Me.pnlDgv.Size = New System.Drawing.Size(1074, 362)
        Me.pnlDgv.TabIndex = 11
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
        Me.dgv.Location = New System.Drawing.Point(0, 0)
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
        Me.dgv.Size = New System.Drawing.Size(1074, 362)
        Me.dgv.TabIndex = 0
        '
        'btnMdfOk
        '
        Me.btnMdfOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMdfOk.BackColor = System.Drawing.Color.Transparent
        Me.btnMdfOk.Fore_Color = System.Drawing.Color.Black
        Me.btnMdfOk.ForeColor = System.Drawing.Color.Transparent
        Me.btnMdfOk.Location = New System.Drawing.Point(993, 45)
        Me.btnMdfOk.Name = "btnMdfOk"
        Me.btnMdfOk.Size = New System.Drawing.Size(75, 30)
        Me.btnMdfOk.TabIndex = 6
        Me.btnMdfOk.Text = "确定修改"
        Me.btnMdfOk.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMdfOk.TipText = ""
        '
        'FrmDrugOutReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDgv)
        Me.Controls.Add(Me.pnlFunc)
        Me.Controls.Add(Me.pnlInfo)
        Me.Name = "FrmDrugOutReg"
        Me.Size = New System.Drawing.Size(1074, 555)
        Me.Controls.SetChildIndex(Me.LblTitle, 0)
        Me.Controls.SetChildIndex(Me.pnlInfo, 0)
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.pnlDgv, 0)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlDgv.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents pnlDgv As System.Windows.Forms.Panel
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents btnClear As UIControlLib.LabelEx
    Friend WithEvents btnDel As UIControlLib.LabelEx
    Friend WithEvents btnModify As UIControlLib.LabelEx
    Friend WithEvents btnOk As UIControlLib.LabelEx
    Friend WithEvents btnCancel As UIControlLib.LabelEx
    Friend WithEvents btnAdd As UIControlLib.LabelEx
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblExpire As System.Windows.Forms.Label
    Friend WithEvents tbBatchNo As System.Windows.Forms.TextBox
    Friend WithEvents lblBatchNo As System.Windows.Forms.Label
    Friend WithEvents lblMFG As System.Windows.Forms.Label
    Friend WithEvents tbAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents tbFactory As UIControlLib.UIDropDownList
    Friend WithEvents lblFactory As System.Windows.Forms.Label
    Friend WithEvents tbSpec As UIControlLib.UIDropDownList
    Friend WithEvents lblSpec As System.Windows.Forms.Label
    Friend WithEvents tbProductName As UIControlLib.UIDropDownList
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents ddlCommonName As UIControlLib.UIDropDownList
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents lblRegistor As System.Windows.Forms.Label
    Friend WithEvents dtpExpire As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpMFG As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbOutType As System.Windows.Forms.ComboBox
    Friend WithEvents lblOutType As System.Windows.Forms.Label
    Friend WithEvents tbUnit As System.Windows.Forms.TextBox
    Friend WithEvents tbCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents tbRegistor As System.Windows.Forms.TextBox
    Friend WithEvents btnMdfOk As UIControlLib.LabelEx

End Class
