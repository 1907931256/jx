<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackageChange
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSterilizeRoom = New System.Windows.Forms.ComboBox()
        Me.btnOK = New UIControlLib.LabelEx()
        Me.btnCancel = New UIControlLib.LabelEx()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(20, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "无菌区名称"
        '
        'cmbSterilizeRoom
        '
        Me.cmbSterilizeRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSterilizeRoom.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.cmbSterilizeRoom.FormattingEnabled = True
        Me.cmbSterilizeRoom.Location = New System.Drawing.Point(114, 31)
        Me.cmbSterilizeRoom.Name = "cmbSterilizeRoom"
        Me.cmbSterilizeRoom.Size = New System.Drawing.Size(180, 24)
        Me.cmbSterilizeRoom.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.btnOK.Fore_Color = System.Drawing.Color.Black
        Me.btnOK.ForeColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(64, 85)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(103, 30)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "确定"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.TipText = ""
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.btnCancel.Fore_Color = System.Drawing.Color.Black
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(173, 85)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 30)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.TipText = ""
        '
        'FrmPackageChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 129)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbSterilizeRoom)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPackageChange"
        Me.Text = "治疗包变更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSterilizeRoom As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As UIControlLib.LabelEx
    Friend WithEvents btnCancel As UIControlLib.LabelEx
End Class
