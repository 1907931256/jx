<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmINSDetail
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
        Me.btnColse = New UIControlLib.LabelEx()
        Me.dgvMain = New UIControlLib.UIDataGridView()
        Me.UiFrmInfo1 = New UIControlLib.UIFrmInfo()
        Me.lblINSUnit = New System.Windows.Forms.Label()
        Me.lblINSType = New System.Windows.Forms.Label()
        Me.lblINSName = New System.Windows.Forms.Label()
        Me.lblINSID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.物品编号 = New System.Windows.Forms.Label()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiFrmInfo1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnColse
        '
        Me.btnColse.BackColor = System.Drawing.Color.Transparent
        Me.btnColse.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.btnColse.Fore_Color = System.Drawing.Color.Black
        Me.btnColse.ForeColor = System.Drawing.Color.Transparent
        Me.btnColse.Location = New System.Drawing.Point(263, 322)
        Me.btnColse.Name = "btnColse"
        Me.btnColse.Size = New System.Drawing.Size(108, 30)
        Me.btnColse.TabIndex = 2
        Me.btnColse.Text = "关闭"
        Me.btnColse.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnColse.TipText = ""
        '
        'dgvMain
        '
        Me.dgvMain.AllowDelete = True
        Me.dgvMain.AllowSelectChangeRow = False
        Me.dgvMain.AllowSort = True
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToResizeColumns = False
        Me.dgvMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dgvMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMain.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvMain.BeQuerying = False
        Me.dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvMain.ChangeHeaderSize = False
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
        Me.dgvMain.Location = New System.Drawing.Point(12, 101)
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
        Me.dgvMain.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvMain.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvMain.RowTemplate.Height = 23
        Me.dgvMain.SelCombineKeyEnable = False
        Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMain.ShowSelectionColor = True
        Me.dgvMain.Size = New System.Drawing.Size(612, 215)
        Me.dgvMain.TabIndex = 1
        '
        'UiFrmInfo1
        '
        Me.UiFrmInfo1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.UiFrmInfo1.Controls.Add(Me.lblINSUnit)
        Me.UiFrmInfo1.Controls.Add(Me.lblINSType)
        Me.UiFrmInfo1.Controls.Add(Me.lblINSName)
        Me.UiFrmInfo1.Controls.Add(Me.lblINSID)
        Me.UiFrmInfo1.Controls.Add(Me.Label1)
        Me.UiFrmInfo1.Controls.Add(Me.Label3)
        Me.UiFrmInfo1.Controls.Add(Me.Label2)
        Me.UiFrmInfo1.Controls.Add(Me.物品编号)
        Me.UiFrmInfo1.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.UiFrmInfo1.Location = New System.Drawing.Point(12, 15)
        Me.UiFrmInfo1.Name = "UiFrmInfo1"
        Me.UiFrmInfo1.Size = New System.Drawing.Size(612, 80)
        Me.UiFrmInfo1.TabIndex = 0
        Me.UiFrmInfo1.TitleText = ""
        Me.UiFrmInfo1.TitleVisable = False
        '
        'lblINSUnit
        '
        Me.lblINSUnit.AutoSize = True
        Me.lblINSUnit.Location = New System.Drawing.Point(356, 52)
        Me.lblINSUnit.Name = "lblINSUnit"
        Me.lblINSUnit.Size = New System.Drawing.Size(0, 16)
        Me.lblINSUnit.TabIndex = 10
        '
        'lblINSType
        '
        Me.lblINSType.AutoSize = True
        Me.lblINSType.Location = New System.Drawing.Point(118, 52)
        Me.lblINSType.Name = "lblINSType"
        Me.lblINSType.Size = New System.Drawing.Size(0, 16)
        Me.lblINSType.TabIndex = 9
        '
        'lblINSName
        '
        Me.lblINSName.AutoSize = True
        Me.lblINSName.Location = New System.Drawing.Point(356, 22)
        Me.lblINSName.Name = "lblINSName"
        Me.lblINSName.Size = New System.Drawing.Size(0, 16)
        Me.lblINSName.TabIndex = 8
        '
        'lblINSID
        '
        Me.lblINSID.AutoSize = True
        Me.lblINSID.Location = New System.Drawing.Point(118, 22)
        Me.lblINSID.Name = "lblINSID"
        Me.lblINSID.Size = New System.Drawing.Size(0, 16)
        Me.lblINSID.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(271, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "物品单位："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "物品规格："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(271, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "物品名称："
        '
        '物品编号
        '
        Me.物品编号.AutoSize = True
        Me.物品编号.Location = New System.Drawing.Point(24, 22)
        Me.物品编号.Name = "物品编号"
        Me.物品编号.Size = New System.Drawing.Size(88, 16)
        Me.物品编号.TabIndex = 3
        Me.物品编号.Text = "物品编号："
        '
        'FrmINSDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 358)
        Me.Controls.Add(Me.btnColse)
        Me.Controls.Add(Me.dgvMain)
        Me.Controls.Add(Me.UiFrmInfo1)
        Me.Name = "FrmINSDetail"
        Me.Text = "治疗包详细物品查看"
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiFrmInfo1.ResumeLayout(False)
        Me.UiFrmInfo1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiFrmInfo1 As UIControlLib.UIFrmInfo
    Friend WithEvents lblINSUnit As System.Windows.Forms.Label
    Friend WithEvents lblINSType As System.Windows.Forms.Label
    Friend WithEvents lblINSName As System.Windows.Forms.Label
    Friend WithEvents lblINSID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 物品编号 As System.Windows.Forms.Label
    Friend WithEvents dgvMain As UIControlLib.UIDataGridView
    Friend WithEvents btnColse As UIControlLib.LabelEx
End Class
