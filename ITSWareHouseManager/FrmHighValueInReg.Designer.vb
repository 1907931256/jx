<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHighValueInReg
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
        Me.pnlMiddle = New System.Windows.Forms.Panel()
        Me.btnMdfOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.txtHighBatch = New System.Windows.Forms.TextBox()
        Me.cmbINSName = New UIControlLib.CmbDropDownList()
        Me.lblBatch = New System.Windows.Forms.Label()
        Me.lblRegistor = New System.Windows.Forms.Label()
        Me.lblCompanyCode = New System.Windows.Forms.Label()
        Me.txtCompanyCode = New System.Windows.Forms.TextBox()
        Me.txtINSType = New System.Windows.Forms.TextBox()
        Me.txtINSCode = New System.Windows.Forms.TextBox()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.lblINSCode = New System.Windows.Forms.Label()
        Me.cmbCompanyHigh = New UIControlLib.CmbDropDownList()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbRegistor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.dtpExpried = New System.Windows.Forms.DateTimePicker()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.dtpCheck = New System.Windows.Forms.DateTimePicker()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.pnlCommit = New System.Windows.Forms.Panel()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.btnDel = New DevComponents.DotNetBar.ButtonX()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.dgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlInfo.SuspendLayout()
        Me.pnlBaseTop.SuspendLayout()
        Me.pnlMiddle.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        Me.pnlTop.SuspendLayout()
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
        Me.pnlBaseTop.Controls.Add(Me.pnlMiddle)
        Me.pnlBaseTop.Controls.Add(Me.gbInfo)
        Me.pnlBaseTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBaseTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlBaseTop.Name = "pnlBaseTop"
        Me.pnlBaseTop.Size = New System.Drawing.Size(796, 107)
        Me.pnlBaseTop.TabIndex = 34
        '
        'pnlMiddle
        '
        Me.pnlMiddle.Controls.Add(Me.btnMdfOk)
        Me.pnlMiddle.Controls.Add(Me.btnAdd)
        Me.pnlMiddle.Controls.Add(Me.btnCancel)
        Me.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddle.Location = New System.Drawing.Point(781, 0)
        Me.pnlMiddle.Name = "pnlMiddle"
        Me.pnlMiddle.Size = New System.Drawing.Size(15, 107)
        Me.pnlMiddle.TabIndex = 1
        '
        'btnMdfOk
        '
        Me.btnMdfOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMdfOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnMdfOk.Location = New System.Drawing.Point(13, 28)
        Me.btnMdfOk.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMdfOk.Name = "btnMdfOk"
        Me.btnMdfOk.Size = New System.Drawing.Size(58, 22)
        Me.btnMdfOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnMdfOk.TabIndex = 32
        Me.btnMdfOk.Text = "确认"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAdd.Location = New System.Drawing.Point(13, 27)
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
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(13, 59)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "取消"
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gbInfo.Controls.Add(Me.pnlTop)
        Me.gbInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.gbInfo.Size = New System.Drawing.Size(781, 107)
        Me.gbInfo.TabIndex = 0
        Me.gbInfo.TabStop = False
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.txtHighBatch)
        Me.pnlTop.Controls.Add(Me.cmbINSName)
        Me.pnlTop.Controls.Add(Me.lblBatch)
        Me.pnlTop.Controls.Add(Me.lblRegistor)
        Me.pnlTop.Controls.Add(Me.lblCompanyCode)
        Me.pnlTop.Controls.Add(Me.txtCompanyCode)
        Me.pnlTop.Controls.Add(Me.txtINSType)
        Me.pnlTop.Controls.Add(Me.txtINSCode)
        Me.pnlTop.Controls.Add(Me.lblProductName)
        Me.pnlTop.Controls.Add(Me.lblINSCode)
        Me.pnlTop.Controls.Add(Me.cmbCompanyHigh)
        Me.pnlTop.Controls.Add(Me.Label5)
        Me.pnlTop.Controls.Add(Me.tbRegistor)
        Me.pnlTop.Controls.Add(Me.Label7)
        Me.pnlTop.Controls.Add(Me.lblSpec)
        Me.pnlTop.Controls.Add(Me.dtpExpried)
        Me.pnlTop.Controls.Add(Me.lblCompany)
        Me.pnlTop.Controls.Add(Me.dtpCheck)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTop.Location = New System.Drawing.Point(2, 16)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(777, 89)
        Me.pnlTop.TabIndex = 33
        '
        'txtHighBatch
        '
        Me.txtHighBatch.Location = New System.Drawing.Point(448, 30)
        Me.txtHighBatch.Name = "txtHighBatch"
        Me.txtHighBatch.Size = New System.Drawing.Size(124, 21)
        Me.txtHighBatch.TabIndex = 34
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
        Me.cmbINSName.Location = New System.Drawing.Point(251, 2)
        Me.cmbINSName.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(124, 20)
        Me.cmbINSName.TabIndex = 29
        Me.cmbINSName.VisibleRowCount = 10
        '
        'lblBatch
        '
        Me.lblBatch.AutoSize = True
        Me.lblBatch.Location = New System.Drawing.Point(392, 34)
        Me.lblBatch.Name = "lblBatch"
        Me.lblBatch.Size = New System.Drawing.Size(53, 12)
        Me.lblBatch.TabIndex = 33
        Me.lblBatch.Text = "产品批号"
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
        'lblCompanyCode
        '
        Me.lblCompanyCode.AutoSize = True
        Me.lblCompanyCode.Location = New System.Drawing.Point(3, 34)
        Me.lblCompanyCode.Name = "lblCompanyCode"
        Me.lblCompanyCode.Size = New System.Drawing.Size(53, 12)
        Me.lblCompanyCode.TabIndex = 31
        Me.lblCompanyCode.Text = "厂商条码"
        '
        'txtCompanyCode
        '
        Me.txtCompanyCode.Location = New System.Drawing.Point(57, 30)
        Me.txtCompanyCode.Name = "txtCompanyCode"
        Me.txtCompanyCode.Size = New System.Drawing.Size(124, 21)
        Me.txtCompanyCode.TabIndex = 32
        '
        'txtINSType
        '
        Me.txtINSType.BackColor = System.Drawing.Color.Ivory
        Me.txtINSType.Location = New System.Drawing.Point(448, 2)
        Me.txtINSType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtINSType.Name = "txtINSType"
        Me.txtINSType.ReadOnly = True
        Me.txtINSType.Size = New System.Drawing.Size(124, 21)
        Me.txtINSType.TabIndex = 23
        '
        'txtINSCode
        '
        Me.txtINSCode.Location = New System.Drawing.Point(251, 30)
        Me.txtINSCode.Name = "txtINSCode"
        Me.txtINSCode.Size = New System.Drawing.Size(124, 21)
        Me.txtINSCode.TabIndex = 17
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(195, 6)
        Me.lblProductName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(53, 12)
        Me.lblProductName.TabIndex = 4
        Me.lblProductName.Text = "物品名称"
        '
        'lblINSCode
        '
        Me.lblINSCode.AutoSize = True
        Me.lblINSCode.Location = New System.Drawing.Point(195, 34)
        Me.lblINSCode.Name = "lblINSCode"
        Me.lblINSCode.Size = New System.Drawing.Size(53, 12)
        Me.lblINSCode.TabIndex = 16
        Me.lblINSCode.Text = "序列条码"
        '
        'cmbCompanyHigh
        '
        Me.cmbCompanyHigh.AliginMent = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cmbCompanyHigh.CodeIndex = 0
        Me.cmbCompanyHigh.DisplayIndex = 1
        Me.cmbCompanyHigh.DropDownOritation = UIControlLib.CmbDropDownList.SNAP_MODE.OnLeft
        Me.cmbCompanyHigh.FormattingEnabled = True
        Me.cmbCompanyHigh.IDContent = Nothing
        Me.cmbCompanyHigh.IDIndex = 2
        Me.cmbCompanyHigh.IsIgnoreEnter = False
        Me.cmbCompanyHigh.IsSelectCont = False
        Me.cmbCompanyHigh.Location = New System.Drawing.Point(646, 2)
        Me.cmbCompanyHigh.Name = "cmbCompanyHigh"
        Me.cmbCompanyHigh.RowHeight = 19
        Me.cmbCompanyHigh.Size = New System.Drawing.Size(124, 20)
        Me.cmbCompanyHigh.TabIndex = 30
        Me.cmbCompanyHigh.VisibleRowCount = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "失效期至"
        '
        'tbRegistor
        '
        Me.tbRegistor.BackColor = System.Drawing.Color.Ivory
        Me.tbRegistor.Location = New System.Drawing.Point(57, 2)
        Me.tbRegistor.Margin = New System.Windows.Forms.Padding(2)
        Me.tbRegistor.Name = "tbRegistor"
        Me.tbRegistor.ReadOnly = True
        Me.tbRegistor.Size = New System.Drawing.Size(124, 21)
        Me.tbRegistor.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(591, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "检验日期"
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(392, 6)
        Me.lblSpec.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(53, 12)
        Me.lblSpec.TabIndex = 6
        Me.lblSpec.Text = "物品规格"
        '
        'dtpExpried
        '
        Me.dtpExpried.CustomFormat = "yyyy-MM-dd"
        Me.dtpExpried.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpried.Location = New System.Drawing.Point(57, 59)
        Me.dtpExpried.Name = "dtpExpried"
        Me.dtpExpried.Size = New System.Drawing.Size(124, 21)
        Me.dtpExpried.TabIndex = 20
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(591, 6)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(53, 12)
        Me.lblCompany.TabIndex = 8
        Me.lblCompany.Text = "厂    家"
        '
        'dtpCheck
        '
        Me.dtpCheck.CustomFormat = "yyyy-MM-dd"
        Me.dtpCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCheck.Location = New System.Drawing.Point(646, 30)
        Me.dtpCheck.Name = "dtpCheck"
        Me.dtpCheck.Size = New System.Drawing.Size(124, 21)
        Me.dtpCheck.TabIndex = 19
        '
        'pnlBtn
        '
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBtn.Location = New System.Drawing.Point(796, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(10, 107)
        Me.pnlBtn.TabIndex = 33
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
        'FrmHighValueInReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.pnlCommit)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlFunc)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmHighValueInReg"
        Me.Size = New System.Drawing.Size(806, 416)
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlBaseTop.ResumeLayout(False)
        Me.pnlMiddle.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlCommit.ResumeLayout(False)
        Me.pnlFunc.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbINSName As UIControlLib.CmbDropDownList
    Friend WithEvents txtINSType As System.Windows.Forms.TextBox
    Friend WithEvents tbRegistor As System.Windows.Forms.TextBox
    Friend WithEvents lblSpec As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents lblRegistor As System.Windows.Forms.Label
    Friend WithEvents pnlCommit As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnMdfOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlBtn As System.Windows.Forms.Panel
    Friend WithEvents txtHighBatch As System.Windows.Forms.TextBox
    Friend WithEvents lblBatch As System.Windows.Forms.Label
    Friend WithEvents lblCompanyCode As System.Windows.Forms.Label
    Friend WithEvents txtCompanyCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbCompanyHigh As UIControlLib.CmbDropDownList
    Friend WithEvents txtINSCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents lblINSCode As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpExpried As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCheck As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlBaseTop As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlMiddle As System.Windows.Forms.Panel
    Friend WithEvents dgv As DevComponents.DotNetBar.Controls.DataGridViewX

End Class
