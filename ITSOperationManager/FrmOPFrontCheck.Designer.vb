Imports ZhiFa.Base.ControlBase
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOPFrontCheck
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
        Me.UiFrmInfo1 = New UIControlLib.UIFrmInfo()
        Me.txtAvailableDate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSterilizeDate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtINSUnit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtINSType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtINSName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtINSID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPackageID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiFrmInfo2 = New UIControlLib.UIFrmInfo()
        Me.cmbReaon = New System.Windows.Forms.ComboBox()
        Me.cmbResult = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnReson = New DevComponents.DotNetBar.ButtonX()
        Me.btnConfirm = New DevComponents.DotNetBar.ButtonX()
        Me.UiFrmInfo1.SuspendLayout()
        Me.UiFrmInfo2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiFrmInfo1
        '
        Me.UiFrmInfo1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.UiFrmInfo1.Controls.Add(Me.txtAvailableDate)
        Me.UiFrmInfo1.Controls.Add(Me.Label7)
        Me.UiFrmInfo1.Controls.Add(Me.txtSterilizeDate)
        Me.UiFrmInfo1.Controls.Add(Me.Label6)
        Me.UiFrmInfo1.Controls.Add(Me.txtINSUnit)
        Me.UiFrmInfo1.Controls.Add(Me.Label5)
        Me.UiFrmInfo1.Controls.Add(Me.txtINSType)
        Me.UiFrmInfo1.Controls.Add(Me.Label4)
        Me.UiFrmInfo1.Controls.Add(Me.txtINSName)
        Me.UiFrmInfo1.Controls.Add(Me.Label3)
        Me.UiFrmInfo1.Controls.Add(Me.txtINSID)
        Me.UiFrmInfo1.Controls.Add(Me.Label2)
        Me.UiFrmInfo1.Controls.Add(Me.txtPackageID)
        Me.UiFrmInfo1.Controls.Add(Me.Label1)
        Me.UiFrmInfo1.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.UiFrmInfo1.Location = New System.Drawing.Point(11, 11)
        Me.UiFrmInfo1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.UiFrmInfo1.Name = "UiFrmInfo1"
        Me.UiFrmInfo1.Size = New System.Drawing.Size(508, 139)
        Me.UiFrmInfo1.TabIndex = 6
        Me.UiFrmInfo1.TitleText = "治疗包详情"
        Me.UiFrmInfo1.TitleVisable = True
        '
        'txtAvailableDate
        '
        Me.txtAvailableDate.BackColor = System.Drawing.Color.Ivory
        Me.txtAvailableDate.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtAvailableDate.Location = New System.Drawing.Point(330, 107)
        Me.txtAvailableDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtAvailableDate.Name = "txtAvailableDate"
        Me.txtAvailableDate.ReadOnly = True
        Me.txtAvailableDate.Size = New System.Drawing.Size(155, 21)
        Me.txtAvailableDate.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(268, 111)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "失效日期"
        '
        'txtSterilizeDate
        '
        Me.txtSterilizeDate.BackColor = System.Drawing.Color.Ivory
        Me.txtSterilizeDate.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtSterilizeDate.Location = New System.Drawing.Point(83, 107)
        Me.txtSterilizeDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSterilizeDate.Name = "txtSterilizeDate"
        Me.txtSterilizeDate.ReadOnly = True
        Me.txtSterilizeDate.Size = New System.Drawing.Size(155, 21)
        Me.txtSterilizeDate.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(22, 111)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "灭菌日期"
        '
        'txtINSUnit
        '
        Me.txtINSUnit.BackColor = System.Drawing.Color.Ivory
        Me.txtINSUnit.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtINSUnit.Location = New System.Drawing.Point(330, 81)
        Me.txtINSUnit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtINSUnit.Name = "txtINSUnit"
        Me.txtINSUnit.ReadOnly = True
        Me.txtINSUnit.Size = New System.Drawing.Size(155, 21)
        Me.txtINSUnit.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(268, 85)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "物品单位"
        '
        'txtINSType
        '
        Me.txtINSType.BackColor = System.Drawing.Color.Ivory
        Me.txtINSType.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtINSType.Location = New System.Drawing.Point(83, 81)
        Me.txtINSType.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtINSType.Name = "txtINSType"
        Me.txtINSType.ReadOnly = True
        Me.txtINSType.Size = New System.Drawing.Size(155, 21)
        Me.txtINSType.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(22, 85)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "物品规格"
        '
        'txtINSName
        '
        Me.txtINSName.BackColor = System.Drawing.Color.Ivory
        Me.txtINSName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtINSName.Location = New System.Drawing.Point(330, 55)
        Me.txtINSName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtINSName.Name = "txtINSName"
        Me.txtINSName.ReadOnly = True
        Me.txtINSName.Size = New System.Drawing.Size(155, 21)
        Me.txtINSName.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(268, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "物品名称"
        '
        'txtINSID
        '
        Me.txtINSID.BackColor = System.Drawing.Color.Ivory
        Me.txtINSID.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtINSID.Location = New System.Drawing.Point(83, 55)
        Me.txtINSID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtINSID.Name = "txtINSID"
        Me.txtINSID.ReadOnly = True
        Me.txtINSID.Size = New System.Drawing.Size(155, 21)
        Me.txtINSID.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(22, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "物品编号"
        '
        'txtPackageID
        '
        Me.txtPackageID.BackColor = System.Drawing.Color.Ivory
        Me.txtPackageID.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtPackageID.Location = New System.Drawing.Point(83, 28)
        Me.txtPackageID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPackageID.Name = "txtPackageID"
        Me.txtPackageID.ReadOnly = True
        Me.txtPackageID.Size = New System.Drawing.Size(155, 21)
        Me.txtPackageID.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(22, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "治疗包号"
        '
        'UiFrmInfo2
        '
        Me.UiFrmInfo2.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.UiFrmInfo2.Controls.Add(Me.cmbReaon)
        Me.UiFrmInfo2.Controls.Add(Me.cmbResult)
        Me.UiFrmInfo2.Controls.Add(Me.Label9)
        Me.UiFrmInfo2.Controls.Add(Me.Label8)
        Me.UiFrmInfo2.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.UiFrmInfo2.Location = New System.Drawing.Point(11, 154)
        Me.UiFrmInfo2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.UiFrmInfo2.Name = "UiFrmInfo2"
        Me.UiFrmInfo2.Size = New System.Drawing.Size(508, 73)
        Me.UiFrmInfo2.TabIndex = 7
        Me.UiFrmInfo2.TitleText = ""
        Me.UiFrmInfo2.TitleVisable = False
        '
        'cmbReaon
        '
        Me.cmbReaon.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.cmbReaon.FormattingEnabled = True
        Me.cmbReaon.Location = New System.Drawing.Point(83, 44)
        Me.cmbReaon.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbReaon.Name = "cmbReaon"
        Me.cmbReaon.Size = New System.Drawing.Size(402, 20)
        Me.cmbReaon.TabIndex = 19
        '
        'cmbResult
        '
        Me.cmbResult.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.cmbResult.FormattingEnabled = True
        Me.cmbResult.Location = New System.Drawing.Point(83, 20)
        Me.cmbResult.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbResult.Name = "cmbResult"
        Me.cmbResult.Size = New System.Drawing.Size(92, 20)
        Me.cmbResult.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(22, 47)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "原    因"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(22, 22)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "确认结果"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(267, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(57, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 64
        Me.btnCancel.Text = "取消"
        '
        'btnReson
        '
        Me.btnReson.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReson.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnReson.Location = New System.Drawing.Point(12, 244)
        Me.btnReson.Name = "btnReson"
        Me.btnReson.Size = New System.Drawing.Size(93, 23)
        Me.btnReson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReson.TabIndex = 63
        Me.btnReson.Text = "原因设置"
        '
        'btnConfirm
        '
        Me.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnConfirm.Location = New System.Drawing.Point(204, 244)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(57, 23)
        Me.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnConfirm.TabIndex = 62
        Me.btnConfirm.Text = "确认"
        '
        'FrmOPFrontCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 277)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnReson)
        Me.Controls.Add(Me.UiFrmInfo2)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.UiFrmInfo1)
        Me.DoubleBuffered = True
        Me.Name = "FrmOPFrontCheck"
        Me.Text = "术前确认登记"
        Me.UiFrmInfo1.ResumeLayout(False)
        Me.UiFrmInfo1.PerformLayout()
        Me.UiFrmInfo2.ResumeLayout(False)
        Me.UiFrmInfo2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiFrmInfo1 As UIControlLib.UIFrmInfo
    Friend WithEvents txtAvailableDate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSterilizeDate As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtINSUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtINSType As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtINSName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtINSID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPackageID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiFrmInfo2 As UIControlLib.UIFrmInfo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbReaon As System.Windows.Forms.ComboBox
    Friend WithEvents cmbResult As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReson As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnConfirm As DevComponents.DotNetBar.ButtonX
End Class
