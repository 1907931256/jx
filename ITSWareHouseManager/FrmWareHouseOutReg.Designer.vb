<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseOutReg
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.pnlDrug = New System.Windows.Forms.Panel()
        Me.pnlWareINS = New System.Windows.Forms.Panel()
        Me.cmbINSBatch = New UIControlLib.CmbDropDownList()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDrugBatch = New UIControlLib.CmbDropDownList()
        Me.cmbDrugUnit = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDrugCount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlOutTop = New System.Windows.Forms.Panel()
        Me.cmbINSType = New System.Windows.Forms.ComboBox()
        Me.lblRegistor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.tbRegistor = New System.Windows.Forms.TextBox()
        Me.cmbINSName = New UIControlLib.CmbDropDownList()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCompany = New UIControlLib.CmbDropDownList()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.btnDel = New DevComponents.DotNetBar.ButtonX()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.dgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlInfo.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        Me.pnlDrug.SuspendLayout()
        Me.pnlWareINS.SuspendLayout()
        Me.pnlOutTop.SuspendLayout()
        Me.pnlFunc.SuspendLayout()
        Me.pnlCommit.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlInfo.Controls.Add(Me.btnCancel)
        Me.pnlInfo.Controls.Add(Me.btnAdd)
        Me.pnlInfo.Controls.Add(Me.gbInfo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 32)
        Me.pnlInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(806, 73)
        Me.pnlInfo.TabIndex = 10
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(743, 51)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "取消"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAdd.Location = New System.Drawing.Point(743, 24)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(58, 22)
        Me.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "添加"
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gbInfo.Controls.Add(Me.pnlDrug)
        Me.gbInfo.Controls.Add(Me.pnlOutTop)
        Me.gbInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.gbInfo.Size = New System.Drawing.Size(738, 73)
        Me.gbInfo.TabIndex = 0
        Me.gbInfo.TabStop = False
        '
        'pnlDrug
        '
        Me.pnlDrug.Controls.Add(Me.pnlWareINS)
        Me.pnlDrug.Controls.Add(Me.cmbDrugBatch)
        Me.pnlDrug.Controls.Add(Me.cmbDrugUnit)
        Me.pnlDrug.Controls.Add(Me.Label9)
        Me.pnlDrug.Controls.Add(Me.txtDrugCount)
        Me.pnlDrug.Controls.Add(Me.Label5)
        Me.pnlDrug.Controls.Add(Me.Label6)
        Me.pnlDrug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDrug.Location = New System.Drawing.Point(2, 41)
        Me.pnlDrug.Name = "pnlDrug"
        Me.pnlDrug.Size = New System.Drawing.Size(734, 30)
        Me.pnlDrug.TabIndex = 39
        '
        'pnlWareINS
        '
        Me.pnlWareINS.Controls.Add(Me.cmbINSBatch)
        Me.pnlWareINS.Controls.Add(Me.txtCount)
        Me.pnlWareINS.Controls.Add(Me.Label3)
        Me.pnlWareINS.Controls.Add(Me.Label4)
        Me.pnlWareINS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWareINS.Location = New System.Drawing.Point(0, 0)
        Me.pnlWareINS.Name = "pnlWareINS"
        Me.pnlWareINS.Size = New System.Drawing.Size(734, 30)
        Me.pnlWareINS.TabIndex = 38
        '
        'cmbINSBatch
        '
        Me.cmbINSBatch.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbINSBatch.BackColor = System.Drawing.Color.White
        Me.cmbINSBatch.CodeIndex = 0
        Me.cmbINSBatch.DisplayIndex = 1
        Me.cmbINSBatch.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbINSBatch.FormattingEnabled = True
        Me.cmbINSBatch.IDContent = Nothing
        Me.cmbINSBatch.IDIndex = 2
        Me.cmbINSBatch.IsIgnoreEnter = False
        Me.cmbINSBatch.IsSelectCont = False
        Me.cmbINSBatch.Location = New System.Drawing.Point(58, 5)
        Me.cmbINSBatch.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSBatch.Name = "cmbINSBatch"
        Me.cmbINSBatch.RowHeight = 19
        Me.cmbINSBatch.Size = New System.Drawing.Size(116, 20)
        Me.cmbINSBatch.TabIndex = 49
        Me.cmbINSBatch.VisibleRowCount = 10
        '
        'txtCount
        '
        Me.txtCount.BackColor = System.Drawing.Color.White
        Me.txtCount.Location = New System.Drawing.Point(234, 4)
        Me.txtCount.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(116, 21)
        Me.txtCount.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "数    量"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "批    号"
        '
        'cmbDrugBatch
        '
        Me.cmbDrugBatch.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbDrugBatch.BackColor = System.Drawing.Color.White
        Me.cmbDrugBatch.CodeIndex = 0
        Me.cmbDrugBatch.DisplayIndex = 1
        Me.cmbDrugBatch.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbDrugBatch.FormattingEnabled = True
        Me.cmbDrugBatch.IDContent = Nothing
        Me.cmbDrugBatch.IDIndex = 2
        Me.cmbDrugBatch.IsIgnoreEnter = False
        Me.cmbDrugBatch.IsSelectCont = False
        Me.cmbDrugBatch.Location = New System.Drawing.Point(59, 5)
        Me.cmbDrugBatch.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbDrugBatch.Name = "cmbDrugBatch"
        Me.cmbDrugBatch.RowHeight = 19
        Me.cmbDrugBatch.Size = New System.Drawing.Size(116, 20)
        Me.cmbDrugBatch.TabIndex = 34
        Me.cmbDrugBatch.VisibleRowCount = 10
        '
        'cmbDrugUnit
        '
        Me.cmbDrugUnit.FormattingEnabled = True
        Me.cmbDrugUnit.Location = New System.Drawing.Point(234, 5)
        Me.cmbDrugUnit.Name = "cmbDrugUnit"
        Me.cmbDrugUnit.Size = New System.Drawing.Size(116, 20)
        Me.cmbDrugUnit.TabIndex = 49
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(178, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "单    位"
        '
        'txtDrugCount
        '
        Me.txtDrugCount.BackColor = System.Drawing.Color.White
        Me.txtDrugCount.Location = New System.Drawing.Point(417, 6)
        Me.txtDrugCount.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDrugCount.Name = "txtDrugCount"
        Me.txtDrugCount.Size = New System.Drawing.Size(116, 21)
        Me.txtDrugCount.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(361, 9)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "数    量"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 9)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "批    号"
        '
        'pnlOutTop
        '
        Me.pnlOutTop.Controls.Add(Me.cmbINSType)
        Me.pnlOutTop.Controls.Add(Me.lblRegistor)
        Me.pnlOutTop.Controls.Add(Me.Label2)
        Me.pnlOutTop.Controls.Add(Me.lblCommonName)
        Me.pnlOutTop.Controls.Add(Me.tbRegistor)
        Me.pnlOutTop.Controls.Add(Me.cmbINSName)
        Me.pnlOutTop.Controls.Add(Me.Label1)
        Me.pnlOutTop.Controls.Add(Me.cmbCompany)
        Me.pnlOutTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOutTop.Location = New System.Drawing.Point(2, 16)
        Me.pnlOutTop.Name = "pnlOutTop"
        Me.pnlOutTop.Size = New System.Drawing.Size(734, 25)
        Me.pnlOutTop.TabIndex = 37
        '
        'cmbINSType
        '
        Me.cmbINSType.BackColor = System.Drawing.Color.White
        Me.cmbINSType.FormattingEnabled = True
        Me.cmbINSType.Location = New System.Drawing.Point(234, 0)
        Me.cmbINSType.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSType.Name = "cmbINSType"
        Me.cmbINSType.Size = New System.Drawing.Size(116, 20)
        Me.cmbINSType.TabIndex = 36
        '
        'lblRegistor
        '
        Me.lblRegistor.AutoSize = True
        Me.lblRegistor.Location = New System.Drawing.Point(2, 4)
        Me.lblRegistor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblRegistor.Name = "lblRegistor"
        Me.lblRegistor.Size = New System.Drawing.Size(53, 12)
        Me.lblRegistor.TabIndex = 0
        Me.lblRegistor.Text = "登 记 人"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "物品类别"
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(359, 4)
        Me.lblCommonName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(53, 12)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "物品名称"
        '
        'tbRegistor
        '
        Me.tbRegistor.BackColor = System.Drawing.Color.Ivory
        Me.tbRegistor.Location = New System.Drawing.Point(58, 0)
        Me.tbRegistor.Margin = New System.Windows.Forms.Padding(2)
        Me.tbRegistor.Name = "tbRegistor"
        Me.tbRegistor.ReadOnly = True
        Me.tbRegistor.Size = New System.Drawing.Size(116, 21)
        Me.tbRegistor.TabIndex = 23
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
        Me.cmbINSName.Location = New System.Drawing.Point(418, 0)
        Me.cmbINSName.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(116, 20)
        Me.cmbINSName.TabIndex = 33
        Me.cmbINSName.VisibleRowCount = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(544, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "厂    家"
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
        Me.cmbCompany.Location = New System.Drawing.Point(603, 0)
        Me.cmbCompany.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.RowHeight = 19
        Me.cmbCompany.Size = New System.Drawing.Size(116, 20)
        Me.cmbCompany.TabIndex = 32
        Me.cmbCompany.VisibleRowCount = 10
        '
        'pnlFunc
        '
        Me.pnlFunc.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlFunc.Controls.Add(Me.btnClose)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunc.Location = New System.Drawing.Point(0, 0)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(806, 32)
        Me.pnlFunc.TabIndex = 17
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
        Me.pnlCommit.TabIndex = 29
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
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(0, 105)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(806, 282)
        Me.dgv.TabIndex = 30
        '
        'FrmWareHouseOutReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.pnlCommit)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmWareHouseOutReg"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.pnlDrug.ResumeLayout(False)
        Me.pnlDrug.PerformLayout()
        Me.pnlWareINS.ResumeLayout(False)
        Me.pnlWareINS.PerformLayout()
        Me.pnlOutTop.ResumeLayout(False)
        Me.pnlOutTop.PerformLayout()
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlCommit.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents tbRegistor As System.Windows.Forms.TextBox
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents lblRegistor As System.Windows.Forms.Label
    Friend WithEvents cmbCompany As UIControlLib.CmbDropDownList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbINSName As UIControlLib.CmbDropDownList
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgv As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cmbINSType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlOutTop As System.Windows.Forms.Panel
    Friend WithEvents pnlWareINS As System.Windows.Forms.Panel
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlDrug As System.Windows.Forms.Panel
    Friend WithEvents txtDrugCount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbDrugUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbDrugBatch As UIControlLib.CmbDropDownList
    Friend WithEvents cmbINSBatch As UIControlLib.CmbDropDownList

End Class
