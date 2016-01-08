<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UITraceInfoPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UITraceInfoPanel))
        Me.pnlHead = New System.Windows.Forms.Panel
        Me.pnlHeadRight = New System.Windows.Forms.Panel
        Me.pnlHeadMid = New System.Windows.Forms.Panel
        Me.pnlHeadLeft = New System.Windows.Forms.Panel
        Me.pnlTail = New System.Windows.Forms.Panel
        Me.pnlTailMid = New System.Windows.Forms.Panel
        Me.pnlTailRight = New System.Windows.Forms.Panel
        Me.pnlTailLeft = New System.Windows.Forms.Panel
        Me.pnlContext = New System.Windows.Forms.Panel
        Me.pnlRight = New System.Windows.Forms.Panel
        Me.pnlLeft = New System.Windows.Forms.Panel
        Me.picPre = New UIControlLib.MyLabelBase
        Me.picNext = New UIControlLib.MyLabelBase
        Me.pnlHead.SuspendLayout()
        Me.pnlTail.SuspendLayout()
        Me.pnlTailMid.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHead
        '
        Me.pnlHead.Controls.Add(Me.pnlHeadRight)
        Me.pnlHead.Controls.Add(Me.pnlHeadMid)
        Me.pnlHead.Controls.Add(Me.pnlHeadLeft)
        Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(235, 26)
        Me.pnlHead.TabIndex = 0
        '
        'pnlHeadRight
        '
        Me.pnlHeadRight.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeadRight.BackgroundImage = CType(resources.GetObject("pnlHeadRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlHeadRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeadRight.Location = New System.Drawing.Point(228, 0)
        Me.pnlHeadRight.Name = "pnlHeadRight"
        Me.pnlHeadRight.Size = New System.Drawing.Size(7, 26)
        Me.pnlHeadRight.TabIndex = 1
        '
        'pnlHeadMid
        '
        Me.pnlHeadMid.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeadMid.BackgroundImage = CType(resources.GetObject("pnlHeadMid.BackgroundImage"), System.Drawing.Image)
        Me.pnlHeadMid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeadMid.Location = New System.Drawing.Point(7, 0)
        Me.pnlHeadMid.Name = "pnlHeadMid"
        Me.pnlHeadMid.Size = New System.Drawing.Size(228, 26)
        Me.pnlHeadMid.TabIndex = 1
        '
        'pnlHeadLeft
        '
        Me.pnlHeadLeft.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeadLeft.BackgroundImage = CType(resources.GetObject("pnlHeadLeft.BackgroundImage"), System.Drawing.Image)
        Me.pnlHeadLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlHeadLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeadLeft.Name = "pnlHeadLeft"
        Me.pnlHeadLeft.Size = New System.Drawing.Size(7, 26)
        Me.pnlHeadLeft.TabIndex = 0
        '
        'pnlTail
        '
        Me.pnlTail.Controls.Add(Me.pnlTailMid)
        Me.pnlTail.Controls.Add(Me.pnlTailRight)
        Me.pnlTail.Controls.Add(Me.pnlTailLeft)
        Me.pnlTail.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTail.Location = New System.Drawing.Point(0, 275)
        Me.pnlTail.Name = "pnlTail"
        Me.pnlTail.Size = New System.Drawing.Size(235, 26)
        Me.pnlTail.TabIndex = 1
        '
        'pnlTailMid
        '
        Me.pnlTailMid.BackgroundImage = CType(resources.GetObject("pnlTailMid.BackgroundImage"), System.Drawing.Image)
        Me.pnlTailMid.Controls.Add(Me.picPre)
        Me.pnlTailMid.Controls.Add(Me.picNext)
        Me.pnlTailMid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTailMid.Location = New System.Drawing.Point(7, 0)
        Me.pnlTailMid.Name = "pnlTailMid"
        Me.pnlTailMid.Size = New System.Drawing.Size(221, 26)
        Me.pnlTailMid.TabIndex = 2
        '
        'pnlTailRight
        '
        Me.pnlTailRight.BackgroundImage = CType(resources.GetObject("pnlTailRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlTailRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTailRight.Location = New System.Drawing.Point(228, 0)
        Me.pnlTailRight.Name = "pnlTailRight"
        Me.pnlTailRight.Size = New System.Drawing.Size(7, 26)
        Me.pnlTailRight.TabIndex = 1
        '
        'pnlTailLeft
        '
        Me.pnlTailLeft.BackgroundImage = CType(resources.GetObject("pnlTailLeft.BackgroundImage"), System.Drawing.Image)
        Me.pnlTailLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTailLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlTailLeft.Name = "pnlTailLeft"
        Me.pnlTailLeft.Size = New System.Drawing.Size(7, 26)
        Me.pnlTailLeft.TabIndex = 0
        '
        'pnlContext
        '
        Me.pnlContext.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlContext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContext.Location = New System.Drawing.Point(7, 26)
        Me.pnlContext.Name = "pnlContext"
        Me.pnlContext.Size = New System.Drawing.Size(221, 249)
        Me.pnlContext.TabIndex = 4
        '
        'pnlRight
        '
        Me.pnlRight.BackgroundImage = CType(resources.GetObject("pnlRight.BackgroundImage"), System.Drawing.Image)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRight.Location = New System.Drawing.Point(228, 26)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(7, 249)
        Me.pnlRight.TabIndex = 3
        '
        'pnlLeft
        '
        Me.pnlLeft.BackgroundImage = CType(resources.GetObject("pnlLeft.BackgroundImage"), System.Drawing.Image)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 26)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(7, 249)
        Me.pnlLeft.TabIndex = 2
        '
        'picPre
        '
        Me.picPre.BackColor = System.Drawing.Color.Transparent
        Me.picPre.Dock = System.Windows.Forms.DockStyle.Right
        Me.picPre.ForeColor = System.Drawing.Color.Transparent
        Me.picPre.Image = CType(resources.GetObject("picPre.Image"), System.Drawing.Image)
        Me.picPre.Location = New System.Drawing.Point(185, 0)
        Me.picPre.Name = "picPre"
        Me.picPre.Size = New System.Drawing.Size(18, 26)
        Me.picPre.TabIndex = 1
        Me.picPre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picNext
        '
        Me.picNext.BackColor = System.Drawing.Color.Transparent
        Me.picNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.picNext.ForeColor = System.Drawing.Color.Transparent
        Me.picNext.Image = CType(resources.GetObject("picNext.Image"), System.Drawing.Image)
        Me.picNext.Location = New System.Drawing.Point(203, 0)
        Me.picNext.Name = "picNext"
        Me.picNext.Size = New System.Drawing.Size(18, 26)
        Me.picNext.TabIndex = 0
        Me.picNext.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'UITraceInfoPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlContext)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlTail)
        Me.Controls.Add(Me.pnlHead)
        Me.Name = "UITraceInfoPanel"
        Me.Size = New System.Drawing.Size(235, 301)
        Me.pnlHead.ResumeLayout(False)
        Me.pnlTail.ResumeLayout(False)
        Me.pnlTailMid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHead As System.Windows.Forms.Panel
    Friend WithEvents pnlTail As System.Windows.Forms.Panel
    Friend WithEvents pnlTailLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlHeadRight As System.Windows.Forms.Panel
    Friend WithEvents pnlHeadMid As System.Windows.Forms.Panel
    Friend WithEvents pnlHeadLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlTailMid As System.Windows.Forms.Panel
    Friend WithEvents pnlTailRight As System.Windows.Forms.Panel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlContext As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents picPre As MyLabelBase
    Friend WithEvents picNext As MyLabelBase

End Class
