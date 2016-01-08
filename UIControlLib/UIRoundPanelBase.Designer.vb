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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UIRoundPanelBase))
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.pnlTopMid = New System.Windows.Forms.Panel
        Me.pnlTopRight = New System.Windows.Forms.Panel
        Me.pnlTopLeft = New System.Windows.Forms.Panel
        Me.pnlTail = New System.Windows.Forms.Panel
        Me.pnlTailMid = New System.Windows.Forms.Panel
        Me.pnlTailRight = New System.Windows.Forms.Panel
        Me.pnlTailLeft = New System.Windows.Forms.Panel
        Me.pnlLeft = New System.Windows.Forms.Panel
        Me.pnlRight = New System.Windows.Forms.Panel
        Me.pnlWhiteline = New System.Windows.Forms.Panel
        Me.pnlWhitelineRight = New System.Windows.Forms.Panel
        Me.pnlWhitelineLeft = New System.Windows.Forms.Panel
        Me.pnlHead = New System.Windows.Forms.Panel
        Me.pnlClient = New System.Windows.Forms.Panel
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlTop.SuspendLayout()
        Me.pnlTail.SuspendLayout()
        Me.pnlWhiteline.SuspendLayout()
        Me.pnlHead.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.pnlTopMid)
        Me.pnlTop.Controls.Add(Me.pnlTopRight)
        Me.pnlTop.Controls.Add(Me.pnlTopLeft)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(263, 29)
        Me.pnlTop.TabIndex = 0
        '
        'pnlTopMid
        '
        Me.pnlTopMid.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.pnlTopMid.BackgroundImage = CType(resources.GetObject("pnlTopMid.BackgroundImage"), System.Drawing.Image)
        Me.pnlTopMid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTopMid.Location = New System.Drawing.Point(5, 0)
        Me.pnlTopMid.Name = "pnlTopMid"
        Me.pnlTopMid.Size = New System.Drawing.Size(253, 29)
        Me.pnlTopMid.TabIndex = 2
        '
        'pnlTopRight
        '
        Me.pnlTopRight.BackgroundImage = CType(resources.GetObject("pnlTopRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTopRight.Location = New System.Drawing.Point(258, 0)
        Me.pnlTopRight.Name = "pnlTopRight"
        Me.pnlTopRight.Size = New System.Drawing.Size(5, 29)
        Me.pnlTopRight.TabIndex = 1
        '
        'pnlTopLeft
        '
        Me.pnlTopLeft.BackgroundImage = CType(resources.GetObject("pnlTopLeft.BackgroundImage"), System.Drawing.Image)
        Me.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTopLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopLeft.Name = "pnlTopLeft"
        Me.pnlTopLeft.Size = New System.Drawing.Size(5, 29)
        Me.pnlTopLeft.TabIndex = 0
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
        Me.pnlLeft.Location = New System.Drawing.Point(0, 30)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(5, 353)
        Me.pnlLeft.TabIndex = 2
        '
        'pnlRight
        '
        Me.pnlRight.BackgroundImage = CType(resources.GetObject("pnlRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRight.Location = New System.Drawing.Point(258, 30)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(5, 353)
        Me.pnlRight.TabIndex = 3
        '
        'pnlWhiteline
        '
        Me.pnlWhiteline.BackColor = System.Drawing.Color.White
        Me.pnlWhiteline.Controls.Add(Me.pnlWhitelineRight)
        Me.pnlWhiteline.Controls.Add(Me.pnlWhitelineLeft)
        Me.pnlWhiteline.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlWhiteline.Location = New System.Drawing.Point(0, 29)
        Me.pnlWhiteline.Name = "pnlWhiteline"
        Me.pnlWhiteline.Size = New System.Drawing.Size(263, 1)
        Me.pnlWhiteline.TabIndex = 4
        '
        'pnlWhitelineRight
        '
        Me.pnlWhitelineRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.pnlWhitelineRight.BackgroundImage = CType(resources.GetObject("pnlWhitelineRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlWhitelineRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlWhitelineRight.Location = New System.Drawing.Point(238, 0)
        Me.pnlWhitelineRight.Name = "pnlWhitelineRight"
        Me.pnlWhitelineRight.Size = New System.Drawing.Size(25, 1)
        Me.pnlWhitelineRight.TabIndex = 1
        '
        'pnlWhitelineLeft
        '
        Me.pnlWhitelineLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.pnlWhitelineLeft.BackgroundImage = CType(resources.GetObject("pnlWhitelineLeft.BackgroundImage"), System.Drawing.Image)
        Me.pnlWhitelineLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlWhitelineLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlWhitelineLeft.Name = "pnlWhitelineLeft"
        Me.pnlWhitelineLeft.Size = New System.Drawing.Size(25, 1)
        Me.pnlWhitelineLeft.TabIndex = 0
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.Color.Transparent
        Me.pnlHead.Controls.Add(Me.pnlTop)
        Me.pnlHead.Controls.Add(Me.pnlWhiteline)
        Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(263, 30)
        Me.pnlHead.TabIndex = 5
        '
        'pnlClient
        '
        Me.pnlClient.BackColor = System.Drawing.Color.DarkGray
        Me.pnlClient.Location = New System.Drawing.Point(2, 310)
        Me.pnlClient.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlClient.Name = "pnlClient"
        Me.pnlClient.Size = New System.Drawing.Size(259, 75)
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
        Me.Controls.Add(Me.pnlHead)
        Me.Controls.Add(Me.pnlTail)
        Me.Name = "UIRoundPanelBase"
        Me.Size = New System.Drawing.Size(263, 388)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTail.ResumeLayout(False)
        Me.pnlWhiteline.ResumeLayout(False)
        Me.pnlHead.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlTopLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlTopMid As System.Windows.Forms.Panel
    Friend WithEvents pnlTopRight As System.Windows.Forms.Panel
    Friend WithEvents pnlTail As System.Windows.Forms.Panel
    Friend WithEvents pnlTailMid As System.Windows.Forms.Panel
    Friend WithEvents pnlTailRight As System.Windows.Forms.Panel
    Friend WithEvents pnlTailLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlWhiteline As System.Windows.Forms.Panel
    Friend WithEvents pnlWhitelineRight As System.Windows.Forms.Panel
    Friend WithEvents pnlWhitelineLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlHead As System.Windows.Forms.Panel
    Friend WithEvents pnlClient As System.Windows.Forms.Panel
    Friend WithEvents Timer As System.Windows.Forms.Timer

End Class
