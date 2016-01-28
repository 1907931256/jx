Imports ZhiFa.Base.ControlBase
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseStocking
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
        Me.txtInsID = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.txtINSName = New System.Windows.Forms.TextBox()
        Me.lblINSName = New System.Windows.Forms.Label()
        Me.txtINSType = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtINSUnit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtExpired = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBatch = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'txtInsID
        '
        Me.txtInsID.BackColor = System.Drawing.Color.Ivory
        Me.txtInsID.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtInsID.Location = New System.Drawing.Point(104, 23)
        Me.txtInsID.Name = "txtInsID"
        Me.txtInsID.ReadOnly = True
        Me.txtInsID.Size = New System.Drawing.Size(186, 21)
        Me.txtInsID.TabIndex = 15
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblAmount.Location = New System.Drawing.Point(20, 27)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(53, 12)
        Me.lblAmount.TabIndex = 14
        Me.lblAmount.Text = "物品编号"
        '
        'txtINSName
        '
        Me.txtINSName.BackColor = System.Drawing.Color.Ivory
        Me.txtINSName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtINSName.Location = New System.Drawing.Point(398, 23)
        Me.txtINSName.Name = "txtINSName"
        Me.txtINSName.ReadOnly = True
        Me.txtINSName.Size = New System.Drawing.Size(186, 21)
        Me.txtINSName.TabIndex = 17
        '
        'lblINSName
        '
        Me.lblINSName.AutoSize = True
        Me.lblINSName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.lblINSName.Location = New System.Drawing.Point(315, 27)
        Me.lblINSName.Name = "lblINSName"
        Me.lblINSName.Size = New System.Drawing.Size(53, 12)
        Me.lblINSName.TabIndex = 16
        Me.lblINSName.Text = "物品名称"
        '
        'txtINSType
        '
        Me.txtINSType.BackColor = System.Drawing.Color.Ivory
        Me.txtINSType.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtINSType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtINSType.Location = New System.Drawing.Point(104, 55)
        Me.txtINSType.Name = "txtINSType"
        Me.txtINSType.ReadOnly = True
        Me.txtINSType.Size = New System.Drawing.Size(186, 21)
        Me.txtINSType.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(20, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "物品规格"
        '
        'txtINSUnit
        '
        Me.txtINSUnit.BackColor = System.Drawing.Color.Ivory
        Me.txtINSUnit.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtINSUnit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtINSUnit.Location = New System.Drawing.Point(398, 55)
        Me.txtINSUnit.Name = "txtINSUnit"
        Me.txtINSUnit.ReadOnly = True
        Me.txtINSUnit.Size = New System.Drawing.Size(186, 21)
        Me.txtINSUnit.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(315, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "单    位"
        '
        'txtCount
        '
        Me.txtCount.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtCount.Location = New System.Drawing.Point(398, 118)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(186, 21)
        Me.txtCount.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(315, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "数    量"
        '
        'txtCompany
        '
        Me.txtCompany.BackColor = System.Drawing.Color.Ivory
        Me.txtCompany.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtCompany.Location = New System.Drawing.Point(104, 118)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.ReadOnly = True
        Me.txtCompany.Size = New System.Drawing.Size(186, 21)
        Me.txtCompany.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(20, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "厂    商"
        '
        'txtExpired
        '
        Me.txtExpired.BackColor = System.Drawing.Color.Ivory
        Me.txtExpired.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtExpired.Location = New System.Drawing.Point(398, 86)
        Me.txtExpired.Name = "txtExpired"
        Me.txtExpired.ReadOnly = True
        Me.txtExpired.Size = New System.Drawing.Size(186, 21)
        Me.txtExpired.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(315, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "失效日期"
        '
        'txtBatch
        '
        Me.txtBatch.BackColor = System.Drawing.Color.Ivory
        Me.txtBatch.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.txtBatch.Location = New System.Drawing.Point(104, 86)
        Me.txtBatch.Name = "txtBatch"
        Me.txtBatch.ReadOnly = True
        Me.txtBatch.Size = New System.Drawing.Size(186, 21)
        Me.txtBatch.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(20, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "批    号"
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOK.Location = New System.Drawing.Point(241, 161)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(59, 21)
        Me.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOK.TabIndex = 33
        Me.btnOK.Text = "确认"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(303, 161)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 32
        Me.btnCancel.Text = "取消"
        '
        'FrmWareHouseStocking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 190)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtExpired)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtBatch)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtINSUnit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtINSType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtINSName)
        Me.Controls.Add(Me.lblINSName)
        Me.Controls.Add(Me.txtInsID)
        Me.Controls.Add(Me.lblAmount)
        Me.DoubleBuffered = True
        Me.Name = "FrmWareHouseStocking"
        Me.Text = "库房物品库存盘点"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInsID As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtINSName As System.Windows.Forms.TextBox
    Friend WithEvents lblINSName As System.Windows.Forms.Label
    Friend WithEvents txtINSType As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtINSUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtExpired As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBatch As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
End Class
