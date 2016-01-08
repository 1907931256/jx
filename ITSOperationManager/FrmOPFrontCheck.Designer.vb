<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOPFrontCheck
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnConfirm = New UIControlLib.LabelEx()
        Me.btnCancel = New UIControlLib.LabelEx()
        Me.btnReson = New UIControlLib.LabelEx()
        Me.cmbResult = New System.Windows.Forms.ComboBox()
        Me.cmbReaon = New System.Windows.Forms.ComboBox()
        Me.UiFrmInfo1.SuspendLayout()
        Me.UiFrmInfo2.SuspendLayout()
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
        Me.PanelMidTop.Size = New System.Drawing.Size(656, 32)
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
        Me.UiFrmInfo1.Location = New System.Drawing.Point(40, 50)
        Me.UiFrmInfo1.Name = "UiFrmInfo1"
        Me.UiFrmInfo1.Size = New System.Drawing.Size(626, 185)
        Me.UiFrmInfo1.TabIndex = 6
        Me.UiFrmInfo1.TitleText = "治疗包详情"
        Me.UiFrmInfo1.TitleVisable = True
        '
        'txtAvailableDate
        '
        Me.txtAvailableDate.BackColor = System.Drawing.Color.Ivory
        Me.txtAvailableDate.Location = New System.Drawing.Point(406, 143)
        Me.txtAvailableDate.Name = "txtAvailableDate"
        Me.txtAvailableDate.ReadOnly = True
        Me.txtAvailableDate.Size = New System.Drawing.Size(180, 26)
        Me.txtAvailableDate.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(322, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "失效日期"
        '
        'txtSterilizeDate
        '
        Me.txtSterilizeDate.BackColor = System.Drawing.Color.Ivory
        Me.txtSterilizeDate.Location = New System.Drawing.Point(111, 143)
        Me.txtSterilizeDate.Name = "txtSterilizeDate"
        Me.txtSterilizeDate.ReadOnly = True
        Me.txtSterilizeDate.Size = New System.Drawing.Size(180, 26)
        Me.txtSterilizeDate.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "灭菌日期"
        '
        'txtINSUnit
        '
        Me.txtINSUnit.BackColor = System.Drawing.Color.Ivory
        Me.txtINSUnit.Location = New System.Drawing.Point(406, 108)
        Me.txtINSUnit.Name = "txtINSUnit"
        Me.txtINSUnit.ReadOnly = True
        Me.txtINSUnit.Size = New System.Drawing.Size(180, 26)
        Me.txtINSUnit.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(322, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "物品单位"
        '
        'txtINSType
        '
        Me.txtINSType.BackColor = System.Drawing.Color.Ivory
        Me.txtINSType.Location = New System.Drawing.Point(111, 108)
        Me.txtINSType.Name = "txtINSType"
        Me.txtINSType.ReadOnly = True
        Me.txtINSType.Size = New System.Drawing.Size(180, 26)
        Me.txtINSType.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "物品规格"
        '
        'txtINSName
        '
        Me.txtINSName.BackColor = System.Drawing.Color.Ivory
        Me.txtINSName.Location = New System.Drawing.Point(406, 73)
        Me.txtINSName.Name = "txtINSName"
        Me.txtINSName.ReadOnly = True
        Me.txtINSName.Size = New System.Drawing.Size(180, 26)
        Me.txtINSName.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(322, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "物品名称"
        '
        'txtINSID
        '
        Me.txtINSID.BackColor = System.Drawing.Color.Ivory
        Me.txtINSID.Location = New System.Drawing.Point(111, 73)
        Me.txtINSID.Name = "txtINSID"
        Me.txtINSID.ReadOnly = True
        Me.txtINSID.Size = New System.Drawing.Size(180, 26)
        Me.txtINSID.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "物品编号"
        '
        'txtPackageID
        '
        Me.txtPackageID.BackColor = System.Drawing.Color.Ivory
        Me.txtPackageID.Location = New System.Drawing.Point(111, 38)
        Me.txtPackageID.Name = "txtPackageID"
        Me.txtPackageID.ReadOnly = True
        Me.txtPackageID.Size = New System.Drawing.Size(180, 26)
        Me.txtPackageID.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
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
        Me.UiFrmInfo2.Location = New System.Drawing.Point(40, 241)
        Me.UiFrmInfo2.Name = "UiFrmInfo2"
        Me.UiFrmInfo2.Size = New System.Drawing.Size(626, 90)
        Me.UiFrmInfo2.TabIndex = 7
        Me.UiFrmInfo2.TitleText = ""
        Me.UiFrmInfo2.TitleVisable = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(30, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "原    因"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "确认结果"
        '
        'btnConfirm
        '
        Me.btnConfirm.BackColor = System.Drawing.Color.Transparent
        Me.btnConfirm.Fore_Color = System.Drawing.Color.Black
        Me.btnConfirm.ForeColor = System.Drawing.Color.Transparent
        Me.btnConfirm.Location = New System.Drawing.Point(229, 345)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(118, 30)
        Me.btnConfirm.TabIndex = 8
        Me.btnConfirm.Text = "确认"
        Me.btnConfirm.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConfirm.TipText = ""
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(362, 345)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 30)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.TipText = ""
        '
        'btnReson
        '
        Me.btnReson.BackColor = System.Drawing.Color.Transparent
        Me.btnReson.Fore_Color = System.Drawing.Color.Black
        Me.btnReson.ForeColor = System.Drawing.Color.Transparent
        Me.btnReson.Location = New System.Drawing.Point(37, 345)
        Me.btnReson.Name = "btnReson"
        Me.btnReson.Size = New System.Drawing.Size(118, 30)
        Me.btnReson.TabIndex = 10
        Me.btnReson.Text = "原因设置"
        Me.btnReson.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReson.TipText = ""
        '
        'cmbResult
        '
        Me.cmbResult.FormattingEnabled = True
        Me.cmbResult.Location = New System.Drawing.Point(111, 21)
        Me.cmbResult.Name = "cmbResult"
        Me.cmbResult.Size = New System.Drawing.Size(121, 24)
        Me.cmbResult.TabIndex = 18
        '
        'cmbReaon
        '
        Me.cmbReaon.FormattingEnabled = True
        Me.cmbReaon.Location = New System.Drawing.Point(111, 54)
        Me.cmbReaon.Name = "cmbReaon"
        Me.cmbReaon.Size = New System.Drawing.Size(475, 24)
        Me.cmbReaon.TabIndex = 19
        '
        'FrmOPFrontCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 407)
        Me.Controls.Add(Me.btnReson)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.UiFrmInfo2)
        Me.Controls.Add(Me.UiFrmInfo1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmOPFrontCheck"
        Me.Text = "术前确认登记"
        Me.Controls.SetChildIndex(Me.PanelMidTop, 0)
        Me.Controls.SetChildIndex(Me.UiFrmInfo1, 0)
        Me.Controls.SetChildIndex(Me.UiFrmInfo2, 0)
        Me.Controls.SetChildIndex(Me.btnConfirm, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnReson, 0)
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
    Friend WithEvents btnConfirm As UIControlLib.LabelEx
    Friend WithEvents btnCancel As UIControlLib.LabelEx
    Friend WithEvents btnReson As UIControlLib.LabelEx
    Friend WithEvents cmbReaon As System.Windows.Forms.ComboBox
    Friend WithEvents cmbResult As System.Windows.Forms.ComboBox
End Class
