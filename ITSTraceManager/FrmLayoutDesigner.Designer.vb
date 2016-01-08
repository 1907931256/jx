<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLayoutDesigner
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
        Me.LoyoutContainer = New System.Windows.Forms.Panel()
        Me.LayoutSetting = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'LoyoutContainer
        '
        Me.LoyoutContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.LoyoutContainer.Location = New System.Drawing.Point(0, 0)
        Me.LoyoutContainer.Name = "LoyoutContainer"
        Me.LoyoutContainer.Size = New System.Drawing.Size(984, 370)
        Me.LoyoutContainer.TabIndex = 0
        '
        'LayoutSetting
        '
        Me.LayoutSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutSetting.Location = New System.Drawing.Point(984, 0)
        Me.LayoutSetting.Name = "LayoutSetting"
        Me.LayoutSetting.Size = New System.Drawing.Size(235, 370)
        Me.LayoutSetting.TabIndex = 1
        '
        'FrmLayoutDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1219, 370)
        Me.Controls.Add(Me.LayoutSetting)
        Me.Controls.Add(Me.LoyoutContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmLayoutDesigner"
        Me.Text = "平面图设计器"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LoyoutContainer As System.Windows.Forms.Panel
    Friend WithEvents LayoutSetting As System.Windows.Forms.Panel
End Class
