<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UITerminalDataLoadButton
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblText = New System.Windows.Forms.Label
        Me.picMenu = New System.Windows.Forms.PictureBox
        Me.btnLoad = New System.Windows.Forms.PictureBox
        CType(Me.picMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.BackColor = System.Drawing.Color.Transparent
        Me.lblText.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblText.Location = New System.Drawing.Point(20, 7)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(0, 16)
        Me.lblText.TabIndex = 1
        '
        'picMenu
        '
        Me.picMenu.BackColor = System.Drawing.Color.Transparent
        Me.picMenu.BackgroundImage = Global.UIControlLib.My.Resources.Resources.button_mid_normal
        Me.picMenu.Image = Global.UIControlLib.My.Resources.Resources.DropDown_normal
        Me.picMenu.Location = New System.Drawing.Point(64, 0)
        Me.picMenu.Name = "picMenu"
        Me.picMenu.Size = New System.Drawing.Size(25, 30)
        Me.picMenu.TabIndex = 2
        Me.picMenu.TabStop = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.Transparent
        Me.btnLoad.BackgroundImage = Global.UIControlLib.My.Resources.Resources.btnNormal_
        Me.btnLoad.Image = Global.UIControlLib.My.Resources.Resources.Handhelds
        Me.btnLoad.Location = New System.Drawing.Point(0, 0)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(90, 30)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.TabStop = False
        '
        'UITerminalDataLoadButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.picMenu)
        Me.Controls.Add(Me.btnLoad)
        Me.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UITerminalDataLoadButton"
        Me.Size = New System.Drawing.Size(90, 30)
        CType(Me.picMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents btnLoad As System.Windows.Forms.PictureBox
    Protected WithEvents lblText As System.Windows.Forms.Label
    Protected WithEvents picMenu As System.Windows.Forms.PictureBox

End Class
