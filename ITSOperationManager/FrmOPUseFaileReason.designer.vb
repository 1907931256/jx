<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOPUseFaileReason
    Inherits UIControlLib.ModalDialogBase

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
        Me.btnClose = New UIControlLib.LabelEx()
        Me.btnModify = New UIControlLib.LabelEx()
        Me.btnDelete = New UIControlLib.LabelEx()
        Me.btnCancel = New UIControlLib.LabelEx()
        Me.btnAdd = New UIControlLib.LabelEx()
        Me.UiFrmInfo1 = New UIControlLib.UIFrmInfo()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.dgvMain = New UIControlLib.UIDataGridView()
        Me.UiFrmInfo1.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblClose
        '
        Me.LblClose.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblClose.Size = New System.Drawing.Size(21, 21)
        '
        'PanelMidTop
        '
        Me.PanelMidTop.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelMidTop.Size = New System.Drawing.Size(565, 32)
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Fore_Color = System.Drawing.Color.Black
        Me.btnClose.ForeColor = System.Drawing.Color.Transparent
        Me.btnClose.Location = New System.Drawing.Point(501, 215)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 30)
        Me.btnClose.TabIndex = 56
        Me.btnClose.Text = "关闭"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.TipText = ""
        '
        'btnModify
        '
        Me.btnModify.BackColor = System.Drawing.Color.Transparent
        Me.btnModify.Fore_Color = System.Drawing.Color.Black
        Me.btnModify.ForeColor = System.Drawing.Color.Transparent
        Me.btnModify.Location = New System.Drawing.Point(501, 176)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(80, 30)
        Me.btnModify.TabIndex = 54
        Me.btnModify.Text = "修改"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModify.TipText = ""
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.Fore_Color = System.Drawing.Color.Black
        Me.btnDelete.ForeColor = System.Drawing.Color.Transparent
        Me.btnDelete.Location = New System.Drawing.Point(501, 137)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 30)
        Me.btnDelete.TabIndex = 53
        Me.btnDelete.Text = "删除"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.TipText = ""
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(501, 93)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 30)
        Me.btnCancel.TabIndex = 52
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.TipText = ""
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Fore_Color = System.Drawing.Color.Black
        Me.btnAdd.ForeColor = System.Drawing.Color.Transparent
        Me.btnAdd.Location = New System.Drawing.Point(501, 54)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 30)
        Me.btnAdd.TabIndex = 51
        Me.btnAdd.Text = "添加"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.TipText = ""
        '
        'UiFrmInfo1
        '
        Me.UiFrmInfo1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.UiFrmInfo1.Controls.Add(Me.txtReason)
        Me.UiFrmInfo1.Controls.Add(Me.lblReason)
        Me.UiFrmInfo1.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.UiFrmInfo1.Location = New System.Drawing.Point(35, 40)
        Me.UiFrmInfo1.Name = "UiFrmInfo1"
        Me.UiFrmInfo1.Size = New System.Drawing.Size(460, 91)
        Me.UiFrmInfo1.TabIndex = 49
        Me.UiFrmInfo1.TitleText = "               "
        Me.UiFrmInfo1.TitleVisable = False
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.SystemColors.Window
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Location = New System.Drawing.Point(106, 26)
        Me.txtReason.MaxLength = 20
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReason.Size = New System.Drawing.Size(341, 49)
        Me.txtReason.TabIndex = 30
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Location = New System.Drawing.Point(12, 28)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(88, 16)
        Me.lblReason.TabIndex = 36
        Me.lblReason.Text = "不合格原因"
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvMain
        '
        Me.dgvMain.AllowDelete = True
        Me.dgvMain.AllowSort = True
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMain.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
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
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMain.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMain.EnableHeadersVisualStyles = False
        Me.dgvMain.Location = New System.Drawing.Point(35, 137)
        Me.dgvMain.MultiSelect = False
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.NoItemAlter = ""
        Me.dgvMain.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvMain.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMain.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvMain.RowTemplate.Height = 23
        Me.dgvMain.SelCombineKeyEnable = False
        Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMain.ShowSelectionColor = True
        Me.dgvMain.Size = New System.Drawing.Size(460, 299)
        Me.dgvMain.TabIndex = 50
        '
        'FrmOPUseFaileReason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 468)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.UiFrmInfo1)
        Me.Controls.Add(Me.dgvMain)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmOPUseFaileReason"
        Me.Text = "拆包检查不合格原因"
        Me.Controls.SetChildIndex(Me.PanelMidTop, 0)
        Me.Controls.SetChildIndex(Me.dgvMain, 0)
        Me.Controls.SetChildIndex(Me.UiFrmInfo1, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnModify, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.UiFrmInfo1.ResumeLayout(False)
        Me.UiFrmInfo1.PerformLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents btnClose As UIControlLib.LabelEx
    Protected Friend WithEvents btnModify As UIControlLib.LabelEx
    Protected Friend WithEvents btnDelete As UIControlLib.LabelEx
    Protected Friend WithEvents btnCancel As UIControlLib.LabelEx
    Protected Friend WithEvents btnAdd As UIControlLib.LabelEx
    Friend WithEvents UiFrmInfo1 As UIControlLib.UIFrmInfo
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents dgvMain As UIControlLib.UIDataGridView
End Class
