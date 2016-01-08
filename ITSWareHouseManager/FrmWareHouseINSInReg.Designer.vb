<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseINSInReg
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbFactory = New System.Windows.Forms.TextBox()
        Me.lblFactory = New System.Windows.Forms.Label()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClear = New UIControlLib.LabelEx()
        Me.btnDel = New UIControlLib.LabelEx()
        Me.btnOk = New UIControlLib.LabelEx()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.btnMdfOk = New UIControlLib.LabelEx()
        Me.btnCancel = New UIControlLib.LabelEx()
        Me.btnAdd = New UIControlLib.LabelEx()
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.cmbCompany = New UIControlLib.CmbDropDownList()
        Me.cmbINSName = New UIControlLib.CmbDropDownList()
        Me.cmbINSType = New System.Windows.Forms.ComboBox()
        Me.txtINSUnit = New System.Windows.Forms.TextBox()
        Me.txtINSType = New System.Windows.Forms.TextBox()
        Me.tbRegistor = New System.Windows.Forms.TextBox()
        Me.dtpExpire = New System.Windows.Forms.DateTimePicker()
        Me.dtpProductDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpire = New System.Windows.Forms.Label()
        Me.txtBatch = New System.Windows.Forms.TextBox()
        Me.lblBatchNo = New System.Windows.Forms.Label()
        Me.lblMFG = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.lblRegistor = New System.Windows.Forms.Label()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFunc.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.Size = New System.Drawing.Size(1074, 42)
        Me.LblTitle.Text = "库房物品入库登记"
        '
        'tbFactory
        '
        Me.tbFactory.BackColor = System.Drawing.Color.Ivory
        Me.tbFactory.Location = New System.Drawing.Point(317, 197)
        Me.tbFactory.Name = "tbFactory"
        Me.tbFactory.ReadOnly = True
        Me.tbFactory.Size = New System.Drawing.Size(154, 26)
        Me.tbFactory.TabIndex = 24
        '
        'lblFactory
        '
        Me.lblFactory.AutoSize = True
        Me.lblFactory.Location = New System.Drawing.Point(242, 202)
        Me.lblFactory.Name = "lblFactory"
        Me.lblFactory.Size = New System.Drawing.Size(72, 16)
        Me.lblFactory.TabIndex = 8
        Me.lblFactory.Text = "厂    家"
        '
        'dgv
        '
        Me.dgv.AllowDelete = True
        Me.dgv.AllowSort = True
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv.ChangeHeaderSize = False
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle18.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.NoItemAlter = ""
        Me.dgv.RowHeadersVisible = False
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle20
        Me.dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelCombineKeyEnable = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.ShowSelectionColor = True
        Me.dgv.Size = New System.Drawing.Size(1074, 597)
        Me.dgv.TabIndex = 11
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnClear)
        Me.pnlFunc.Controls.Add(Me.btnDel)
        Me.pnlFunc.Controls.Add(Me.btnOk)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 558)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(1074, 39)
        Me.pnlFunc.TabIndex = 12
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.Fore_Color = System.Drawing.Color.Black
        Me.btnClear.ForeColor = System.Drawing.Color.Transparent
        Me.btnClear.Location = New System.Drawing.Point(982, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(86, 30)
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
        Me.btnDel.Location = New System.Drawing.Point(802, 5)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(86, 30)
        Me.btnDel.TabIndex = 2
        Me.btnDel.Text = "删除"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDel.TipText = ""
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.Fore_Color = System.Drawing.Color.Black
        Me.btnOk.ForeColor = System.Drawing.Color.Transparent
        Me.btnOk.Location = New System.Drawing.Point(892, 5)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 30)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "确定"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOk.TipText = ""
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
        Me.pnlInfo.Size = New System.Drawing.Size(1074, 117)
        Me.pnlInfo.TabIndex = 25
        '
        'btnMdfOk
        '
        Me.btnMdfOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMdfOk.BackColor = System.Drawing.Color.Transparent
        Me.btnMdfOk.Fore_Color = System.Drawing.Color.Black
        Me.btnMdfOk.ForeColor = System.Drawing.Color.Transparent
        Me.btnMdfOk.Location = New System.Drawing.Point(982, 50)
        Me.btnMdfOk.Name = "btnMdfOk"
        Me.btnMdfOk.Size = New System.Drawing.Size(86, 30)
        Me.btnMdfOk.TabIndex = 6
        Me.btnMdfOk.Text = "确定"
        Me.btnMdfOk.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMdfOk.TipText = ""
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(982, 84)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 30)
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
        Me.btnAdd.Location = New System.Drawing.Point(982, 50)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(86, 30)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "添加"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.TipText = ""
        '
        'gbInfo
        '
        Me.gbInfo.Controls.Add(Me.cmbCompany)
        Me.gbInfo.Controls.Add(Me.cmbINSName)
        Me.gbInfo.Controls.Add(Me.cmbINSType)
        Me.gbInfo.Controls.Add(Me.txtINSUnit)
        Me.gbInfo.Controls.Add(Me.txtINSType)
        Me.gbInfo.Controls.Add(Me.tbRegistor)
        Me.gbInfo.Controls.Add(Me.dtpExpire)
        Me.gbInfo.Controls.Add(Me.dtpProductDate)
        Me.gbInfo.Controls.Add(Me.lblExpire)
        Me.gbInfo.Controls.Add(Me.txtBatch)
        Me.gbInfo.Controls.Add(Me.lblBatchNo)
        Me.gbInfo.Controls.Add(Me.lblMFG)
        Me.gbInfo.Controls.Add(Me.txtCount)
        Me.gbInfo.Controls.Add(Me.lblAmount)
        Me.gbInfo.Controls.Add(Me.lblUnit)
        Me.gbInfo.Controls.Add(Me.Label1)
        Me.gbInfo.Controls.Add(Me.lblSpec)
        Me.gbInfo.Controls.Add(Me.lblProductName)
        Me.gbInfo.Controls.Add(Me.lblCommonName)
        Me.gbInfo.Controls.Add(Me.lblRegistor)
        Me.gbInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Size = New System.Drawing.Size(976, 117)
        Me.gbInfo.TabIndex = 0
        Me.gbInfo.TabStop = False
        '
        'cmbCompany
        '
        Me.cmbCompany.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbCompany.CodeIndex = 0
        Me.cmbCompany.DisplayIndex = 1
        Me.cmbCompany.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.IDContent = Nothing
        Me.cmbCompany.IDIndex = 2
        Me.cmbCompany.IsIgnoreEnter = False
        Me.cmbCompany.IsSelectCont = False
        Me.cmbCompany.Location = New System.Drawing.Point(329, 51)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.RowHeight = 19
        Me.cmbCompany.Size = New System.Drawing.Size(154, 24)
        Me.cmbCompany.TabIndex = 30
        Me.cmbCompany.VisibleRowCount = 10
        '
        'cmbINSName
        '
        Me.cmbINSName.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbINSName.CodeIndex = 0
        Me.cmbINSName.DisplayIndex = 1
        Me.cmbINSName.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbINSName.FormattingEnabled = True
        Me.cmbINSName.IDContent = Nothing
        Me.cmbINSName.IDIndex = 2
        Me.cmbINSName.IsIgnoreEnter = False
        Me.cmbINSName.IsSelectCont = False
        Me.cmbINSName.Location = New System.Drawing.Point(571, 19)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(154, 24)
        Me.cmbINSName.TabIndex = 29
        Me.cmbINSName.VisibleRowCount = 10
        '
        'cmbINSType
        '
        Me.cmbINSType.FormattingEnabled = True
        Me.cmbINSType.Location = New System.Drawing.Point(329, 19)
        Me.cmbINSType.Name = "cmbINSType"
        Me.cmbINSType.Size = New System.Drawing.Size(151, 24)
        Me.cmbINSType.TabIndex = 28
        '
        'txtINSUnit
        '
        Me.txtINSUnit.BackColor = System.Drawing.Color.Ivory
        Me.txtINSUnit.Location = New System.Drawing.Point(81, 51)
        Me.txtINSUnit.Name = "txtINSUnit"
        Me.txtINSUnit.ReadOnly = True
        Me.txtINSUnit.Size = New System.Drawing.Size(154, 26)
        Me.txtINSUnit.TabIndex = 25
        '
        'txtINSType
        '
        Me.txtINSType.BackColor = System.Drawing.Color.Ivory
        Me.txtINSType.Location = New System.Drawing.Point(816, 18)
        Me.txtINSType.Name = "txtINSType"
        Me.txtINSType.ReadOnly = True
        Me.txtINSType.Size = New System.Drawing.Size(154, 26)
        Me.txtINSType.TabIndex = 23
        '
        'tbRegistor
        '
        Me.tbRegistor.BackColor = System.Drawing.Color.Ivory
        Me.tbRegistor.Location = New System.Drawing.Point(81, 18)
        Me.tbRegistor.Name = "tbRegistor"
        Me.tbRegistor.ReadOnly = True
        Me.tbRegistor.Size = New System.Drawing.Size(154, 26)
        Me.tbRegistor.TabIndex = 21
        '
        'dtpExpire
        '
        Me.dtpExpire.CustomFormat = "yyyy-MM-dd"
        Me.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpire.Location = New System.Drawing.Point(81, 85)
        Me.dtpExpire.Name = "dtpExpire"
        Me.dtpExpire.Size = New System.Drawing.Size(154, 26)
        Me.dtpExpire.TabIndex = 20
        '
        'dtpProductDate
        '
        Me.dtpProductDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpProductDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProductDate.Location = New System.Drawing.Point(816, 51)
        Me.dtpProductDate.Name = "dtpProductDate"
        Me.dtpProductDate.Size = New System.Drawing.Size(154, 26)
        Me.dtpProductDate.TabIndex = 19
        '
        'lblExpire
        '
        Me.lblExpire.AutoSize = True
        Me.lblExpire.Location = New System.Drawing.Point(6, 90)
        Me.lblExpire.Name = "lblExpire"
        Me.lblExpire.Size = New System.Drawing.Size(72, 16)
        Me.lblExpire.TabIndex = 18
        Me.lblExpire.Text = "有效期至"
        '
        'txtBatch
        '
        Me.txtBatch.Location = New System.Drawing.Point(571, 51)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.Size = New System.Drawing.Size(154, 26)
        Me.txtBatch.TabIndex = 17
        '
        'lblBatchNo
        '
        Me.lblBatchNo.AutoSize = True
        Me.lblBatchNo.Location = New System.Drawing.Point(496, 56)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(72, 16)
        Me.lblBatchNo.TabIndex = 16
        Me.lblBatchNo.Text = "产品批号"
        '
        'lblMFG
        '
        Me.lblMFG.AutoSize = True
        Me.lblMFG.Location = New System.Drawing.Point(741, 56)
        Me.lblMFG.Name = "lblMFG"
        Me.lblMFG.Size = New System.Drawing.Size(72, 16)
        Me.lblMFG.TabIndex = 14
        Me.lblMFG.Text = "生产日期"
        '
        'txtCount
        '
        Me.txtCount.Location = New System.Drawing.Point(329, 85)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(154, 26)
        Me.txtCount.TabIndex = 13
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(251, 90)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(72, 16)
        Me.lblAmount.TabIndex = 12
        Me.lblAmount.Text = "数    量"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(6, 56)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(72, 16)
        Me.lblUnit.TabIndex = 10
        Me.lblUnit.Text = "单    位"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "厂    家"
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(741, 23)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(72, 16)
        Me.lblSpec.TabIndex = 6
        Me.lblSpec.Text = "物品规格"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(496, 23)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(72, 16)
        Me.lblProductName.TabIndex = 4
        Me.lblProductName.Text = "物品名称"
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(251, 23)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(72, 16)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "物品类别"
        '
        'lblRegistor
        '
        Me.lblRegistor.AutoSize = True
        Me.lblRegistor.Location = New System.Drawing.Point(6, 23)
        Me.lblRegistor.Name = "lblRegistor"
        Me.lblRegistor.Size = New System.Drawing.Size(72, 16)
        Me.lblRegistor.TabIndex = 0
        Me.lblRegistor.Text = "登 记 人"
        '
        'FrmWareHouseINSInReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlFunc)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.tbFactory)
        Me.Controls.Add(Me.lblFactory)
        Me.Name = "FrmWareHouseINSInReg"
        Me.Size = New System.Drawing.Size(1074, 597)
        Me.Controls.SetChildIndex(Me.lblFactory, 0)
        Me.Controls.SetChildIndex(Me.tbFactory, 0)
        Me.Controls.SetChildIndex(Me.dgv, 0)
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.LblTitle, 0)
        Me.Controls.SetChildIndex(Me.pnlInfo, 0)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbFactory As System.Windows.Forms.TextBox
    Friend WithEvents lblFactory As System.Windows.Forms.Label
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClear As UIControlLib.LabelEx
    Friend WithEvents btnDel As UIControlLib.LabelEx
    Friend WithEvents btnOk As UIControlLib.LabelEx
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents btnMdfOk As UIControlLib.LabelEx
    Friend WithEvents btnCancel As UIControlLib.LabelEx
    Friend WithEvents btnAdd As UIControlLib.LabelEx
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
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
    Friend WithEvents cmbINSName As UIControlLib.CmbDropDownList
    Friend WithEvents cmbCompany As UIControlLib.CmbDropDownList

End Class
