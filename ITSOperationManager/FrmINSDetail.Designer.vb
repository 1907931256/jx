Imports ZhiFa.Base.ControlBase
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmINSDetail
    Inherits ControlBase

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
        Me.UiFrmInfo1 = New UIControlLib.UIFrmInfo()
        Me.lblINSUnit = New System.Windows.Forms.Label()
        Me.lblINSType = New System.Windows.Forms.Label()
        Me.lblINSName = New System.Windows.Forms.Label()
        Me.lblINSID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.物品编号 = New System.Windows.Forms.Label()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.dgvMain = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.UiFrmInfo1.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lblINSUnit.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblINSUnit.Location = New System.Drawing.Point(356, 52)
        Me.lblINSUnit.Name = "lblINSUnit"
        Me.lblINSUnit.Size = New System.Drawing.Size(0, 12)
        Me.lblINSUnit.TabIndex = 10
        '
        'lblINSType
        '
        Me.lblINSType.AutoSize = True
        Me.lblINSType.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblINSType.Location = New System.Drawing.Point(118, 52)
        Me.lblINSType.Name = "lblINSType"
        Me.lblINSType.Size = New System.Drawing.Size(0, 12)
        Me.lblINSType.TabIndex = 9
        '
        'lblINSName
        '
        Me.lblINSName.AutoSize = True
        Me.lblINSName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblINSName.Location = New System.Drawing.Point(356, 22)
        Me.lblINSName.Name = "lblINSName"
        Me.lblINSName.Size = New System.Drawing.Size(0, 12)
        Me.lblINSName.TabIndex = 8
        '
        'lblINSID
        '
        Me.lblINSID.AutoSize = True
        Me.lblINSID.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblINSID.Location = New System.Drawing.Point(118, 22)
        Me.lblINSID.Name = "lblINSID"
        Me.lblINSID.Size = New System.Drawing.Size(0, 12)
        Me.lblINSID.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(271, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "物品单位："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(24, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "物品规格："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(271, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "物品名称："
        '
        '物品编号
        '
        Me.物品编号.AutoSize = True
        Me.物品编号.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.物品编号.Location = New System.Drawing.Point(24, 22)
        Me.物品编号.Name = "物品编号"
        Me.物品编号.Size = New System.Drawing.Size(65, 12)
        Me.物品编号.TabIndex = 3
        Me.物品编号.Text = "物品编号："
        '
        'btnClose
        '
        Me.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnClose.Location = New System.Drawing.Point(268, 458)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(59, 21)
        Me.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnClose.TabIndex = 47
        Me.btnClose.Text = "确认"
        '
        'dgvMain
        '
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMain.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMain.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvMain.Location = New System.Drawing.Point(12, 101)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.RowHeadersVisible = False
        Me.dgvMain.RowTemplate.Height = 23
        Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMain.Size = New System.Drawing.Size(612, 351)
        Me.dgvMain.TabIndex = 48
        '
        'FrmINSDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 479)
        Me.Controls.Add(Me.dgvMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.UiFrmInfo1)
        Me.DoubleBuffered = True
        Me.Name = "FrmINSDetail"
        Me.Text = "治疗包详细物品查看"
        Me.UiFrmInfo1.ResumeLayout(False)
        Me.UiFrmInfo1.PerformLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgvMain As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
