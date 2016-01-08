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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.btnCancel = New UIControlLib.LabelEx()
        Me.btnAdd = New UIControlLib.LabelEx()
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.txtBatch = New System.Windows.Forms.TextBox()
        Me.cmbINSName = New UIControlLib.CmbDropDownList()
        Me.cmbCompany = New UIControlLib.CmbDropDownList()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbRegistor = New System.Windows.Forms.TextBox()
        Me.lblMFG = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblCommonName = New System.Windows.Forms.Label()
        Me.lblRegistor = New System.Windows.Forms.Label()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnClear = New UIControlLib.LabelEx()
        Me.btnDel = New UIControlLib.LabelEx()
        Me.btnOk = New UIControlLib.LabelEx()
        Me.pnlInfo.SuspendLayout()
        Me.gbInfo.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.btnCancel)
        Me.pnlInfo.Controls.Add(Me.btnAdd)
        Me.pnlInfo.Controls.Add(Me.gbInfo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 38)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(970, 112)
        Me.pnlInfo.TabIndex = 10
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(889, 79)
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
        Me.btnAdd.Location = New System.Drawing.Point(889, 45)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "添加"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.TipText = ""
        '
        'gbInfo
        '
        Me.gbInfo.Controls.Add(Me.txtBatch)
        Me.gbInfo.Controls.Add(Me.cmbINSName)
        Me.gbInfo.Controls.Add(Me.cmbCompany)
        Me.gbInfo.Controls.Add(Me.Label1)
        Me.gbInfo.Controls.Add(Me.tbRegistor)
        Me.gbInfo.Controls.Add(Me.lblMFG)
        Me.gbInfo.Controls.Add(Me.txtCount)
        Me.gbInfo.Controls.Add(Me.lblAmount)
        Me.gbInfo.Controls.Add(Me.lblUnit)
        Me.gbInfo.Controls.Add(Me.lblCommonName)
        Me.gbInfo.Controls.Add(Me.lblRegistor)
        Me.gbInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbInfo.Location = New System.Drawing.Point(0, 0)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Size = New System.Drawing.Size(970, 112)
        Me.gbInfo.TabIndex = 0
        Me.gbInfo.TabStop = False
        '
        'txtBatch
        '
        Me.txtBatch.Location = New System.Drawing.Point(572, 16)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.Size = New System.Drawing.Size(154, 26)
        Me.txtBatch.TabIndex = 34
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
        Me.cmbINSName.Location = New System.Drawing.Point(324, 18)
        Me.cmbINSName.Name = "cmbINSName"
        Me.cmbINSName.RowHeight = 19
        Me.cmbINSName.Size = New System.Drawing.Size(154, 24)
        Me.cmbINSName.TabIndex = 33
        Me.cmbINSName.VisibleRowCount = 10
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
        Me.cmbCompany.Location = New System.Drawing.Point(810, 16)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.RowHeight = 19
        Me.cmbCompany.Size = New System.Drawing.Size(154, 24)
        Me.cmbCompany.TabIndex = 32
        Me.cmbCompany.VisibleRowCount = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(732, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "厂    家"
        '
        'tbRegistor
        '
        Me.tbRegistor.BackColor = System.Drawing.Color.Ivory
        Me.tbRegistor.Location = New System.Drawing.Point(84, 18)
        Me.tbRegistor.Name = "tbRegistor"
        Me.tbRegistor.ReadOnly = True
        Me.tbRegistor.Size = New System.Drawing.Size(154, 26)
        Me.tbRegistor.TabIndex = 23
        '
        'lblMFG
        '
        Me.lblMFG.AutoSize = True
        Me.lblMFG.Location = New System.Drawing.Point(6, 84)
        Me.lblMFG.Name = "lblMFG"
        Me.lblMFG.Size = New System.Drawing.Size(0, 16)
        Me.lblMFG.TabIndex = 14
        '
        'txtCount
        '
        Me.txtCount.Location = New System.Drawing.Point(84, 54)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(154, 26)
        Me.txtCount.TabIndex = 13
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(9, 59)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(72, 16)
        Me.lblAmount.TabIndex = 12
        Me.lblAmount.Text = "数    量"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(494, 22)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(72, 16)
        Me.lblUnit.TabIndex = 10
        Me.lblUnit.Text = "批    号"
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(246, 22)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(72, 16)
        Me.lblCommonName.TabIndex = 2
        Me.lblCommonName.Text = "物品名称"
        '
        'lblRegistor
        '
        Me.lblRegistor.AutoSize = True
        Me.lblRegistor.Location = New System.Drawing.Point(9, 22)
        Me.lblRegistor.Name = "lblRegistor"
        Me.lblRegistor.Size = New System.Drawing.Size(72, 16)
        Me.lblRegistor.TabIndex = 0
        Me.lblRegistor.Text = "登 记 人"
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
        Me.dgv.Location = New System.Drawing.Point(0, 150)
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
        Me.dgv.Size = New System.Drawing.Size(970, 408)
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
        Me.pnlFunc.Size = New System.Drawing.Size(970, 39)
        Me.pnlFunc.TabIndex = 12
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.Fore_Color = System.Drawing.Color.Black
        Me.btnClear.ForeColor = System.Drawing.Color.Transparent
        Me.btnClear.Location = New System.Drawing.Point(889, 5)
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
        Me.btnDel.Location = New System.Drawing.Point(733, 5)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 30)
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
        Me.btnOk.Location = New System.Drawing.Point(811, 5)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 30)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "确定"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOk.TipText = ""
        '
        'FrmWareHouseOutReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.pnlFunc)
        Me.Controls.Add(Me.pnlInfo)
        Me.Name = "FrmWareHouseOutReg"
        Me.Controls.SetChildIndex(Me.pnlInfo, 0)
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.dgv, 0)
        Me.pnlInfo.ResumeLayout(False)
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFunc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As UIControlLib.LabelEx
    Friend WithEvents btnAdd As UIControlLib.LabelEx
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents tbRegistor As System.Windows.Forms.TextBox
    Friend WithEvents lblMFG As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents lblRegistor As System.Windows.Forms.Label
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents btnClear As UIControlLib.LabelEx
    Friend WithEvents btnDel As UIControlLib.LabelEx
    Friend WithEvents btnOk As UIControlLib.LabelEx
    Friend WithEvents cmbCompany As UIControlLib.CmbDropDownList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBatch As System.Windows.Forms.TextBox
    Friend WithEvents cmbINSName As UIControlLib.CmbDropDownList

End Class
