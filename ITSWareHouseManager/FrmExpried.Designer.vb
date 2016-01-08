<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExpried
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.cmbINSTYPE = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAll = New UIControlLib.LabelEx()
        Me.btnCancel = New UIControlLib.LabelEx()
        Me.btbOK = New UIControlLib.LabelEx()
        Me.dgvMain = New UIControlLib.UIDataGridView()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbINSTYPE
        '
        Me.cmbINSTYPE.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.cmbINSTYPE.FormattingEnabled = True
        Me.cmbINSTYPE.Location = New System.Drawing.Point(108, 12)
        Me.cmbINSTYPE.Name = "cmbINSTYPE"
        Me.cmbINSTYPE.Size = New System.Drawing.Size(187, 24)
        Me.cmbINSTYPE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(30, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "物品类型"
        '
        'btnAll
        '
        Me.btnAll.BackColor = System.Drawing.Color.Transparent
        Me.btnAll.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.btnAll.Fore_Color = System.Drawing.Color.Black
        Me.btnAll.ForeColor = System.Drawing.Color.Transparent
        Me.btnAll.Location = New System.Drawing.Point(906, 397)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(96, 30)
        Me.btnAll.TabIndex = 6
        Me.btnAll.Text = "全部移出"
        Me.btnAll.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAll.TipText = ""
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(501, 439)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 30)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.TipText = ""
        '
        'btbOK
        '
        Me.btbOK.BackColor = System.Drawing.Color.Transparent
        Me.btbOK.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.btbOK.Fore_Color = System.Drawing.Color.Black
        Me.btbOK.ForeColor = System.Drawing.Color.Transparent
        Me.btbOK.Location = New System.Drawing.Point(399, 439)
        Me.btbOK.Name = "btbOK"
        Me.btbOK.Size = New System.Drawing.Size(96, 30)
        Me.btbOK.TabIndex = 3
        Me.btbOK.Text = "确定"
        Me.btbOK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btbOK.TipText = ""
        '
        'dgvMain
        '
        Me.dgvMain.AllowDelete = True
        Me.dgvMain.AllowSelectChangeRow = False
        Me.dgvMain.AllowSort = True
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMain.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvMain.BeQuerying = False
        Me.dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvMain.ChangeHeaderSize = True
        Me.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMain.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMain.EnableHeadersVisualStyles = False
        Me.dgvMain.Location = New System.Drawing.Point(12, 44)
        Me.dgvMain.MultiSelect = False
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.NoItemAlter = ""
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMain.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMain.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.dgvMain.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvMain.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvMain.RowTemplate.Height = 23
        Me.dgvMain.SelCombineKeyEnable = False
        Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMain.ShowSelectionColor = True
        Me.dgvMain.Size = New System.Drawing.Size(990, 352)
        Me.dgvMain.TabIndex = 2
        '
        'FrmExpried
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 481)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btbOK)
        Me.Controls.Add(Me.dgvMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbINSTYPE)
        Me.Name = "FrmExpried"
        Me.Text = "物品过期提醒"
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbINSTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvMain As UIControlLib.UIDataGridView
    Friend WithEvents btbOK As UIControlLib.LabelEx
    Friend WithEvents btnCancel As UIControlLib.LabelEx
    Friend WithEvents btnAll As UIControlLib.LabelEx
End Class
