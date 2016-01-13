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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlInfo = New System.Windows.Forms.Panel()
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
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnMdfOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnDel = New DevComponents.DotNetBar.ButtonX()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.pnlInfo.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCommit.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlInfo.Controls.Add(Me.btnMdfOk)
        Me.pnlInfo.Controls.Add(Me.btnCancel)
        Me.pnlInfo.Controls.Add(Me.btnAdd)
        Me.pnlInfo.Controls.Add(Me.gbInfo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlInfo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(806, 88)
        Me.pnlInfo.TabIndex = 26
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
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
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbInfo.Size = New System.Drawing.Size(738, 88)
        Me.gbInfo.TabIndex = 0
        Me.gbInfo.TabStop = False
        '
        'cmbCompany
        '
        Me.cmbCompany.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbCompany.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.cmbCompany.CodeIndex = 0
        Me.cmbCompany.DisplayIndex = 1
        Me.cmbCompany.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.IDContent = Nothing
        Me.cmbCompany.IDIndex = 2
        Me.cmbCompany.IsIgnoreEnter = False
        Me.cmbCompany.IsSelectCont = False
        Me.cmbCompany.Location = New System.Drawing.Point(242, 38)
        Me.cmbCompany.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.RowHeight = 19
        Me.cmbCompany.Size = New System.Drawing.Size(124, 20)
        Me.cmbCompany.TabIndex = 30
        Me.cmbCompany.VisibleRowCount = 10
        '
        'cmbINSName
        '
        Me.cmbINSName.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbINSName.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.cmbINSName.CodeIndex = 0
        Me.cmbINSName.DisplayIndex = 1
        Me.cmbINSName.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbINSName.FormattingEnabled = True
        Me.cmbINSName.IDContent = Nothing
        Me.cmbINSName.IDIndex = 2
        Me.cmbINSName.IsIgnoreEnter = False
        Me.cmbINSName.IsSelectCont = False
        Me.cmbINSName.Location = New System.Drawing.Point(431, 13)
        Me.cmbINSName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(116, 20)
        Me.cmbINSName.TabIndex = 29
        Me.cmbINSName.VisibleRowCount = 10
        '
        'cmbINSType
        '
        Me.cmbINSType.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.cmbINSType.FormattingEnabled = True
        Me.cmbINSType.Location = New System.Drawing.Point(242, 13)
        Me.cmbINSType.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbINSType.Name = "cmbINSType"
        Me.cmbINSType.Size = New System.Drawing.Size(124, 20)
        Me.cmbINSType.TabIndex = 28
        '
        'txtINSUnit
        '
        Me.txtINSUnit.BackColor = System.Drawing.Color.Ivory
        Me.txtINSUnit.Location = New System.Drawing.Point(59, 38)
        Me.txtINSUnit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtINSUnit.Name = "txtINSUnit"
        Me.txtINSUnit.ReadOnly = True
        Me.txtINSUnit.Size = New System.Drawing.Size(116, 21)
        Me.txtINSUnit.TabIndex = 25
        '
        'txtINSType
        '
        Me.txtINSType.BackColor = System.Drawing.Color.Ivory
        Me.txtINSType.Location = New System.Drawing.Point(612, 13)
        Me.txtINSType.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtINSType.Name = "txtINSType"
        Me.txtINSType.ReadOnly = True
        Me.txtINSType.Size = New System.Drawing.Size(116, 21)
        Me.txtINSType.TabIndex = 23
        '
        'tbRegistor
        '
        Me.tbRegistor.BackColor = System.Drawing.Color.Ivory
        Me.tbRegistor.Location = New System.Drawing.Point(59, 13)
        Me.tbRegistor.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbRegistor.Name = "tbRegistor"
        Me.tbRegistor.ReadOnly = True
        Me.tbRegistor.Size = New System.Drawing.Size(116, 21)
        Me.tbRegistor.TabIndex = 21
        '
        'dtpExpire
        '
        Me.dtpExpire.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dtpExpire.CustomFormat = "yyyy-MM-dd"
        Me.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpire.Location = New System.Drawing.Point(59, 63)
        Me.dtpExpire.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpExpire.Name = "dtpExpire"
        Me.dtpExpire.Size = New System.Drawing.Size(116, 21)
        Me.dtpExpire.TabIndex = 20
        '
        'dtpProductDate
        '
        Me.dtpProductDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dtpProductDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpProductDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProductDate.Location = New System.Drawing.Point(612, 38)
        Me.dtpProductDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpProductDate.Name = "dtpProductDate"
        Me.dtpProductDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpProductDate.TabIndex = 19
        '
        'lblExpire
        '
        Me.lblExpire.AutoSize = True
        Me.lblExpire.Location = New System.Drawing.Point(4, 67)
        Me.lblExpire.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpire.Name = "lblExpire"
        Me.lblExpire.Size = New System.Drawing.Size(53, 12)
        Me.lblExpire.TabIndex = 18
        Me.lblExpire.Text = "有效期至"
        '
        'txtBatch
        '
        Me.txtBatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.txtBatch.Location = New System.Drawing.Point(431, 38)
        Me.txtBatch.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.Size = New System.Drawing.Size(116, 21)
        Me.txtBatch.TabIndex = 17
        '
        'lblBatchNo
        '
        Me.lblBatchNo.AutoSize = True
        Me.lblBatchNo.Location = New System.Drawing.Point(375, 42)
        Me.lblBatchNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(53, 12)
        Me.lblBatchNo.TabIndex = 16
        Me.lblBatchNo.Text = "产品批号"
        '
        'lblMFG
        '
        Me.lblMFG.AutoSize = True
        Me.lblMFG.Location = New System.Drawing.Point(556, 42)
        Me.lblMFG.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMFG.Name = "lblMFG"
        Me.lblMFG.Size = New System.Drawing.Size(53, 12)
        Me.lblMFG.TabIndex = 14
        Me.lblMFG.Text = "生产日期"
        '
        'txtCount
        '
        Me.txtCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.txtCount.Location = New System.Drawing.Point(242, 63)
        Me.txtCount.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(124, 21)
        Me.txtCount.TabIndex = 13
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(186, 67)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(53, 12)
        Me.lblAmount.TabIndex = 12
        Me.lblAmount.Text = "数    量"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(4, 42)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(53, 12)
        Me.lblUnit.TabIndex = 10
        Me.lblUnit.Text = "单    位"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(186, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "厂    家"
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(556, 17)
        Me.lblSpec.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(53, 12)
        Me.lblSpec.TabIndex = 6
        Me.lblSpec.Text = "物品规格"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(375, 17)
        Me.lblProductName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(53, 12)
        Me.lblProductName.TabIndex = 4
        Me.lblProductName.Text = "物品名称"
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(186, 17)
        Me.lblCommonName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(53, 12)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "物品类别"
        '
        'lblRegistor
        '
        Me.lblRegistor.AutoSize = True
        Me.lblRegistor.Location = New System.Drawing.Point(4, 17)
        Me.lblRegistor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblRegistor.Name = "lblRegistor"
        Me.lblRegistor.Size = New System.Drawing.Size(53, 12)
        Me.lblRegistor.TabIndex = 0
        Me.lblRegistor.Text = "登 记 人"
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
        Me.dgv.Location = New System.Drawing.Point(0, 88)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
        Me.dgv.Size = New System.Drawing.Size(806, 299)
        Me.dgv.TabIndex = 27
        '
        'pnlCommit
        '
        Me.pnlCommit.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlCommit.Controls.Add(Me.btnClear)
        Me.pnlCommit.Controls.Add(Me.btnDel)
        Me.pnlCommit.Controls.Add(Me.btnOk)
        Me.pnlCommit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommit.Location = New System.Drawing.Point(0, 387)
        Me.pnlCommit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlCommit.Name = "pnlCommit"
        Me.pnlCommit.Size = New System.Drawing.Size(806, 29)
        Me.pnlCommit.TabIndex = 28
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
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAdd.Location = New System.Drawing.Point(742, 38)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(58, 22)
        Me.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "添加"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(742, 63)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "取消"
        '
        'btnMdfOk
        '
        Me.btnMdfOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMdfOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMdfOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnMdfOk.Location = New System.Drawing.Point(742, 37)
        Me.btnMdfOk.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMdfOk.Name = "btnMdfOk"
        Me.btnMdfOk.Size = New System.Drawing.Size(58, 22)
        Me.btnMdfOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnMdfOk.TabIndex = 32
        Me.btnMdfOk.Text = "确认"
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
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 88)
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
        'FrmWareHouseInReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.pnlCommit)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmWareHouseInReg"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCommit.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
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
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnMdfOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX

End Class
