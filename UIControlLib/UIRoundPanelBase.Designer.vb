<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIRoundPanelBase
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UIRoundPanelBase))
        Me.pnlTail = New System.Windows.Forms.Panel()
        Me.pnlTailMid = New System.Windows.Forms.Panel()
        Me.pnlTailRight = New System.Windows.Forms.Panel()
        Me.pnlTailLeft = New System.Windows.Forms.Panel()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.pnlClient = New System.Windows.Forms.Panel()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlTail.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTail
        '
        Me.pnlTail.Controls.Add(Me.pnlTailMid)
        Me.pnlTail.Controls.Add(Me.pnlTailRight)
        Me.pnlTail.Controls.Add(Me.pnlTailLeft)
        Me.pnlTail.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTail.Location = New System.Drawing.Point(0, 383)
        Me.pnlTail.Name = "pnlTail"
        Me.pnlTail.Size = New System.Drawing.Size(263, 5)
        Me.pnlTail.TabIndex = 1
        '
        'pnlTailMid
        '
        Me.pnlTailMid.BackgroundImage = CType(resources.GetObject("pnlTailMid.BackgroundImage"), System.Drawing.Image)
        Me.pnlTailMid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTailMid.Location = New System.Drawing.Point(5, 0)
        Me.pnlTailMid.Name = "pnlTailMid"
        Me.pnlTailMid.Size = New System.Drawing.Size(253, 5)
        Me.pnlTailMid.TabIndex = 2
        '
        'pnlTailRight
        '
        Me.pnlTailRight.BackgroundImage = CType(resources.GetObject("pnlTailRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlTailRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTailRight.Location = New System.Drawing.Point(258, 0)
        Me.pnlTailRight.Name = "pnlTailRight"
        Me.pnlTailRight.Size = New System.Drawing.Size(5, 5)
        Me.pnlTailRight.TabIndex = 1
        '
        'pnlTailLeft
        '
        Me.pnlTailLeft.BackgroundImage = CType(resources.GetObject("pnlTailLeft.BackgroundImage"), System.Drawing.Image)
        Me.pnlTailLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTailLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlTailLeft.Name = "pnlTailLeft"
        Me.pnlTailLeft.Size = New System.Drawing.Size(5, 5)
        Me.pnlTailLeft.TabIndex = 0
        '
        'pnlLeft
        '
        Me.pnlLeft.BackgroundImage = CType(resources.GetObject("pnlLeft.BackgroundImage"), System.Drawing.Image)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(5, 383)
        Me.pnlLeft.TabIndex = 2
        '
        'pnlRight
        '
        Me.pnlRight.BackgroundImage = CType(resources.GetObject("pnlRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRight.Location = New System.Drawing.Point(258, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(5, 383)
        Me.pnlRight.TabIndex = 3
        '
        'pnlClient
        '
        Me.pnlClient.BackColor = System.Drawing.Color.DarkGray
        Me.pnlClient.Location = New System.Drawing.Point(2, 0)
        Me.pnlClient.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlClient.Name = "pnlClient"
        Me.pnlClient.Size = New System.Drawing.Size(259, 385)
        Me.pnlClient.TabIndex = 6
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 250
        '
        'UIRoundPanelBase
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlClient)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlTail)
        Me.Name = "UIRoundPanelBase"
        Me.Size = New System.Drawing.Size(263, 388)
        Me.pnlTail.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTail As System.Windows.Forms.Panel
    Friend WithEvents pnlTailMid As System.Windows.Forms.Panel
    Friend WithEvents pnlTailRight As System.Windows.Forms.Panel
    Friend WithEvents pnlTailLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlClient As System.Windows.Forms.Panel
    Friend WithEvents Timer As System.Windows.Forms.Timer

End Class
