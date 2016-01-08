<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorLabel
    Inherits System.Windows.Forms.Label

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
        Me.pnlMid = New System.Windows.Forms.Panel
        Me.pnlRight = New System.Windows.Forms.Panel
        Me.pnlLeft = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'pnlMid
        '
        Me.pnlMid.BackgroundImage = Global.UIControlLib.My.Resources.Resources.listtitleB_mid
        Me.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMid.Location = New System.Drawing.Point(10, 0)
        Me.pnlMid.Name = "pnlMid"
        Me.pnlMid.Size = New System.Drawing.Size(187, 28)
        Me.pnlMid.TabIndex = 2
        '
        'pnlRight
        '
        Me.pnlRight.BackgroundImage = Global.UIControlLib.My.Resources.Resources.listtitleB_right
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRight.Location = New System.Drawing.Point(197, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(10, 28)
        Me.pnlRight.TabIndex = 1
        '
        'pnlLeft
        '
        Me.pnlLeft.BackgroundImage = Global.UIControlLib.My.Resources.Resources.listtitleB_left
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(10, 28)
        Me.pnlLeft.TabIndex = 0
        '
        'ColorLabel
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlMid)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlLeft)
        Me.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(207, 28)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlMid As System.Windows.Forms.Panel

End Class
