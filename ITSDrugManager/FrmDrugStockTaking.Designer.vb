Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDrugStockTaking
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlFunc = New System.Windows.Forms.Panel()
        Me.btnPrint = New UIControlLib.LabelEx()
        Me.btnRefresh = New UIControlLib.LabelEx()
        Me.btnTaking = New UIControlLib.LabelEx()
        Me.btnDetail = New UIControlLib.LabelEx()
        Me.pnlDgv = New System.Windows.Forms.Panel()
        Me.dgv = New UIControlLib.UIDataGridView()
        Me.pnlFunc.SuspendLayout()
        Me.pnlDgv.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.Size = New System.Drawing.Size(1074, 42)
        Me.LblTitle.Text = "药品库存盘点"
        '
        'pnlFunc
        '
        Me.pnlFunc.Controls.Add(Me.btnPrint)
        Me.pnlFunc.Controls.Add(Me.btnRefresh)
        Me.pnlFunc.Controls.Add(Me.btnTaking)
        Me.pnlFunc.Controls.Add(Me.btnDetail)
        Me.pnlFunc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFunc.Location = New System.Drawing.Point(0, 516)
        Me.pnlFunc.Name = "pnlFunc"
        Me.pnlFunc.Size = New System.Drawing.Size(1074, 39)
        Me.pnlFunc.TabIndex = 10
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.Fore_Color = System.Drawing.Color.Black
        Me.btnPrint.ForeColor = System.Drawing.Color.Transparent
        Me.btnPrint.Location = New System.Drawing.Point(993, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 30)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "打印"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.TipText = ""
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Fore_Color = System.Drawing.Color.Black
        Me.btnRefresh.ForeColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Location = New System.Drawing.Point(837, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "刷新"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.TipText = ""
        '
        'btnTaking
        '
        Me.btnTaking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTaking.BackColor = System.Drawing.Color.Transparent
        Me.btnTaking.Fore_Color = System.Drawing.Color.Black
        Me.btnTaking.ForeColor = System.Drawing.Color.Transparent
        Me.btnTaking.Location = New System.Drawing.Point(5, 5)
        Me.btnTaking.Name = "btnTaking"
        Me.btnTaking.Size = New System.Drawing.Size(75, 30)
        Me.btnTaking.TabIndex = 1
        Me.btnTaking.Text = "盘点"
        Me.btnTaking.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTaking.TipText = ""
        '
        'btnDetail
        '
        Me.btnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetail.BackColor = System.Drawing.Color.Transparent
        Me.btnDetail.Fore_Color = System.Drawing.Color.Black
        Me.btnDetail.ForeColor = System.Drawing.Color.Transparent
        Me.btnDetail.Location = New System.Drawing.Point(915, 5)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(75, 30)
        Me.btnDetail.TabIndex = 0
        Me.btnDetail.Text = "详细"
        Me.btnDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDetail.TipText = ""
        '
        'pnlDgv
        '
        Me.pnlDgv.Controls.Add(Me.dgv)
        Me.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDgv.Location = New System.Drawing.Point(0, 42)
        Me.pnlDgv.Name = "pnlDgv"
        Me.pnlDgv.Size = New System.Drawing.Size(1074, 474)
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
        Me.dgv.Size = New System.Drawing.Size(1074, 474)
        Me.dgv.TabIndex = 0
        '
        'FrmDrugStockTaking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDgv)
        Me.Controls.Add(Me.pnlFunc)
        Me.Name = "FrmDrugStockTaking"
        Me.Size = New System.Drawing.Size(1074, 555)
        Me.Controls.SetChildIndex(Me.LblTitle, 0)
        Me.Controls.SetChildIndex(Me.pnlFunc, 0)
        Me.Controls.SetChildIndex(Me.pnlDgv, 0)
        Me.pnlFunc.ResumeLayout(False)
        Me.pnlDgv.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFunc As System.Windows.Forms.Panel
    Friend WithEvents pnlDgv As System.Windows.Forms.Panel
    Friend WithEvents dgv As UIControlLib.UIDataGridView
    Friend WithEvents btnPrint As UIControlLib.LabelEx
    Friend WithEvents btnRefresh As UIControlLib.LabelEx
    Friend WithEvents btnDetail As UIControlLib.LabelEx
    Friend WithEvents btnTaking As UIControlLib.LabelEx

End Class
