<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UILabelCheckboxes
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
        Me.lbltitle = New System.Windows.Forms.Label
        Me.chba = New System.Windows.Forms.CheckBox
        Me.chbc = New System.Windows.Forms.CheckBox
        Me.chbo = New System.Windows.Forms.CheckBox
        Me.chbd = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'lbltitle
        '
        Me.lbltitle.AutoSize = True
        Me.lbltitle.Location = New System.Drawing.Point(0, 4)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(0, 12)
        Me.lbltitle.TabIndex = 0
        '
        'chba
        '
        Me.chba.AutoSize = True
        Me.chba.Location = New System.Drawing.Point(69, 3)
        Me.chba.Name = "chba"
        Me.chba.Size = New System.Drawing.Size(30, 16)
        Me.chba.TabIndex = 1
        Me.chba.Text = "a"
        Me.chba.UseVisualStyleBackColor = True
        '
        'chbc
        '
        Me.chbc.AutoSize = True
        Me.chbc.Location = New System.Drawing.Point(105, 4)
        Me.chbc.Name = "chbc"
        Me.chbc.Size = New System.Drawing.Size(30, 16)
        Me.chbc.TabIndex = 2
        Me.chbc.Text = "c"
        Me.chbc.UseVisualStyleBackColor = True
        '
        'chbo
        '
        Me.chbo.AutoSize = True
        Me.chbo.Location = New System.Drawing.Point(140, 3)
        Me.chbo.Name = "chbo"
        Me.chbo.Size = New System.Drawing.Size(30, 16)
        Me.chbo.TabIndex = 3
        Me.chbo.Text = "o"
        Me.chbo.UseVisualStyleBackColor = True
        '
        'chbd
        '
        Me.chbd.AutoSize = True
        Me.chbd.Location = New System.Drawing.Point(176, 4)
        Me.chbd.Name = "chbd"
        Me.chbd.Size = New System.Drawing.Size(30, 16)
        Me.chbd.TabIndex = 4
        Me.chbd.Text = "d"
        Me.chbd.UseVisualStyleBackColor = True
        '
        'UILabelCheckboxes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbd)
        Me.Controls.Add(Me.chbo)
        Me.Controls.Add(Me.chbc)
        Me.Controls.Add(Me.chba)
        Me.Controls.Add(Me.lbltitle)
        Me.Name = "UILabelCheckboxes"
        Me.Size = New System.Drawing.Size(316, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltitle As System.Windows.Forms.Label
    Friend WithEvents chba As System.Windows.Forms.CheckBox
    Friend WithEvents chbc As System.Windows.Forms.CheckBox
    Friend WithEvents chbo As System.Windows.Forms.CheckBox
    Friend WithEvents chbd As System.Windows.Forms.CheckBox

End Class
