Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectCardItem
    Inherits ModalDialogBase

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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvNoSel = New UIControlLib.UIDataGridView()
        Me.dgvSel = New UIControlLib.UIDataGridView()
        Me.btnSel = New UIControlLib.LabelEx()
        Me.btnUnsel = New UIControlLib.LabelEx()
        Me.tbUnsel = New System.Windows.Forms.TextBox()
        Me.tbSel = New System.Windows.Forms.TextBox()
        Me.btnOK = New UIControlLib.LabelEx()
        CType(Me.dgvNoSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelMidTop
        '
        Me.PanelMidTop.Size = New System.Drawing.Size(528, 32)
        '
        'dgvNoSel
        '
        Me.dgvNoSel.AllowDelete = True
        Me.dgvNoSel.AllowSort = True
        Me.dgvNoSel.AllowUserToAddRows = False
        Me.dgvNoSel.AllowUserToResizeColumns = False
        Me.dgvNoSel.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvNoSel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNoSel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvNoSel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvNoSel.ChangeHeaderSize = False
        Me.dgvNoSel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNoSel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNoSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNoSel.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvNoSel.EnableHeadersVisualStyles = False
        Me.dgvNoSel.Location = New System.Drawing.Point(25, 61)
        Me.dgvNoSel.MultiSelect = False
        Me.dgvNoSel.Name = "dgvNoSel"
        Me.dgvNoSel.NoItemAlter = ""
        Me.dgvNoSel.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvNoSel.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvNoSel.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvNoSel.RowTemplate.Height = 23
        Me.dgvNoSel.SelCombineKeyEnable = False
        Me.dgvNoSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNoSel.ShowSelectionColor = True
        Me.dgvNoSel.Size = New System.Drawing.Size(212, 287)
        Me.dgvNoSel.TabIndex = 6
        '
        'dgvSel
        '
        Me.dgvSel.AllowDelete = True
        Me.dgvSel.AllowSort = True
        Me.dgvSel.AllowUserToAddRows = False
        Me.dgvSel.AllowUserToResizeColumns = False
        Me.dgvSel.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvSel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvSel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSel.ChangeHeaderSize = False
        Me.dgvSel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSel.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSel.EnableHeadersVisualStyles = False
        Me.dgvSel.Location = New System.Drawing.Point(345, 61)
        Me.dgvSel.MultiSelect = False
        Me.dgvSel.Name = "dgvSel"
        Me.dgvSel.NoItemAlter = ""
        Me.dgvSel.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvSel.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSel.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvSel.RowTemplate.Height = 23
        Me.dgvSel.SelCombineKeyEnable = False
        Me.dgvSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSel.ShowSelectionColor = True
        Me.dgvSel.Size = New System.Drawing.Size(212, 287)
        Me.dgvSel.TabIndex = 7
        '
        'btnSel
        '
        Me.btnSel.BackColor = System.Drawing.Color.Transparent
        Me.btnSel.Fore_Color = System.Drawing.Color.Black
        Me.btnSel.ForeColor = System.Drawing.Color.Transparent
        Me.btnSel.Location = New System.Drawing.Point(243, 151)
        Me.btnSel.Name = "btnSel"
        Me.btnSel.Size = New System.Drawing.Size(96, 30)
        Me.btnSel.TabIndex = 8
        Me.btnSel.Text = ">"
        Me.btnSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSel.TipText = ""
        '
        'btnUnsel
        '
        Me.btnUnsel.BackColor = System.Drawing.Color.Transparent
        Me.btnUnsel.Fore_Color = System.Drawing.Color.Black
        Me.btnUnsel.ForeColor = System.Drawing.Color.Transparent
        Me.btnUnsel.Location = New System.Drawing.Point(243, 191)
        Me.btnUnsel.Name = "btnUnsel"
        Me.btnUnsel.Size = New System.Drawing.Size(96, 30)
        Me.btnUnsel.TabIndex = 9
        Me.btnUnsel.Text = "<"
        Me.btnUnsel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnsel.TipText = ""
        '
        'tbUnsel
        '
        Me.tbUnsel.Location = New System.Drawing.Point(25, 34)
        Me.tbUnsel.Name = "tbUnsel"
        Me.tbUnsel.Size = New System.Drawing.Size(212, 26)
        Me.tbUnsel.TabIndex = 10
        '
        'tbSel
        '
        Me.tbSel.Location = New System.Drawing.Point(345, 34)
        Me.tbSel.Name = "tbSel"
        Me.tbSel.Size = New System.Drawing.Size(212, 26)
        Me.tbSel.TabIndex = 11
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Fore_Color = System.Drawing.Color.Black
        Me.btnOK.ForeColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(243, 315)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(96, 30)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "确定"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.TipText = ""
        '
        'FrmSelectCardItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 369)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tbSel)
        Me.Controls.Add(Me.tbUnsel)
        Me.Controls.Add(Me.btnUnsel)
        Me.Controls.Add(Me.btnSel)
        Me.Controls.Add(Me.dgvSel)
        Me.Controls.Add(Me.dgvNoSel)
        Me.Name = "FrmSelectCardItem"
        Me.Text = "选择统计项目"
        Me.Controls.SetChildIndex(Me.PanelMidTop, 0)
        Me.Controls.SetChildIndex(Me.dgvNoSel, 0)
        Me.Controls.SetChildIndex(Me.dgvSel, 0)
        Me.Controls.SetChildIndex(Me.btnSel, 0)
        Me.Controls.SetChildIndex(Me.btnUnsel, 0)
        Me.Controls.SetChildIndex(Me.tbUnsel, 0)
        Me.Controls.SetChildIndex(Me.tbSel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        CType(Me.dgvNoSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvNoSel As UIControlLib.UIDataGridView
    Friend WithEvents dgvSel As UIControlLib.UIDataGridView
    Friend WithEvents btnSel As UIControlLib.LabelEx
    Friend WithEvents btnUnsel As UIControlLib.LabelEx
    Friend WithEvents tbUnsel As System.Windows.Forms.TextBox
    Friend WithEvents tbSel As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As UIControlLib.LabelEx
End Class
