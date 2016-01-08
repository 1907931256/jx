<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIFrmInfo
    Inherits System.Windows.Forms.Panel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UIFrmInfo))
        Me.PanelLeftTop = New System.Windows.Forms.Panel
        Me.PanelMidTop = New System.Windows.Forms.Panel
        Me.PanelRightTop = New System.Windows.Forms.Panel
        Me.PanelMidLeft = New System.Windows.Forms.Panel
        Me.PanelMidRight = New System.Windows.Forms.Panel
        Me.PanelRightDown = New System.Windows.Forms.Panel
        Me.PanelLeftDown = New System.Windows.Forms.Panel
        Me.PanelMidDown = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.PanelBackColor = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'PanelLeftTop
        '
        Me.PanelLeftTop.BackgroundImage = CType(resources.GetObject("PanelLeftTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelLeftTop.Location = New System.Drawing.Point(3, 3)
        Me.PanelLeftTop.Name = "PanelLeftTop"
        Me.PanelLeftTop.Size = New System.Drawing.Size(7, 7)
        Me.PanelLeftTop.TabIndex = 0
        '
        'PanelMidTop
        '
        Me.PanelMidTop.BackgroundImage = CType(resources.GetObject("PanelMidTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidTop.Location = New System.Drawing.Point(132, 3)
        Me.PanelMidTop.Name = "PanelMidTop"
        Me.PanelMidTop.Size = New System.Drawing.Size(218, 7)
        Me.PanelMidTop.TabIndex = 1
        '
        'PanelRightTop
        '
        Me.PanelRightTop.BackgroundImage = CType(resources.GetObject("PanelRightTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelRightTop.Location = New System.Drawing.Point(356, 3)
        Me.PanelRightTop.Name = "PanelRightTop"
        Me.PanelRightTop.Size = New System.Drawing.Size(7, 7)
        Me.PanelRightTop.TabIndex = 1
        '
        'PanelMidLeft
        '
        Me.PanelMidLeft.BackgroundImage = CType(resources.GetObject("PanelMidLeft.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidLeft.Location = New System.Drawing.Point(3, 19)
        Me.PanelMidLeft.Name = "PanelMidLeft"
        Me.PanelMidLeft.Size = New System.Drawing.Size(7, 129)
        Me.PanelMidLeft.TabIndex = 1
        '
        'PanelMidRight
        '
        Me.PanelMidRight.BackgroundImage = CType(resources.GetObject("PanelMidRight.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidRight.Location = New System.Drawing.Point(353, 67)
        Me.PanelMidRight.Name = "PanelMidRight"
        Me.PanelMidRight.Size = New System.Drawing.Size(10, 99)
        Me.PanelMidRight.TabIndex = 1
        '
        'PanelRightDown
        '
        Me.PanelRightDown.BackgroundImage = CType(resources.GetObject("PanelRightDown.BackgroundImage"), System.Drawing.Image)
        Me.PanelRightDown.Location = New System.Drawing.Point(356, 167)
        Me.PanelRightDown.Name = "PanelRightDown"
        Me.PanelRightDown.Size = New System.Drawing.Size(7, 7)
        Me.PanelRightDown.TabIndex = 1
        '
        'PanelLeftDown
        '
        Me.PanelLeftDown.BackgroundImage = CType(resources.GetObject("PanelLeftDown.BackgroundImage"), System.Drawing.Image)
        Me.PanelLeftDown.Location = New System.Drawing.Point(3, 167)
        Me.PanelLeftDown.Name = "PanelLeftDown"
        Me.PanelLeftDown.Size = New System.Drawing.Size(7, 7)
        Me.PanelLeftDown.TabIndex = 1
        '
        'PanelMidDown
        '
        Me.PanelMidDown.BackgroundImage = CType(resources.GetObject("PanelMidDown.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidDown.Location = New System.Drawing.Point(16, 167)
        Me.PanelMidDown.Name = "PanelMidDown"
        Me.PanelMidDown.Size = New System.Drawing.Size(234, 10)
        Me.PanelMidDown.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("SimSun", 11.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Image = CType(resources.GetObject("lblTitle.Image"), System.Drawing.Image)
        Me.lblTitle.Location = New System.Drawing.Point(13, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(129, 23)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PanelBackColor
        '
        Me.PanelBackColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.PanelBackColor.Location = New System.Drawing.Point(0, 0)
        Me.PanelBackColor.Name = "PanelBackColor"
        Me.PanelBackColor.Size = New System.Drawing.Size(200, 100)
        Me.PanelBackColor.TabIndex = 0
        '
        'UIFrmInfo
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PanelMidDown)
        Me.Controls.Add(Me.PanelLeftDown)
        Me.Controls.Add(Me.PanelRightDown)
        Me.Controls.Add(Me.PanelMidRight)
        Me.Controls.Add(Me.PanelMidLeft)
        Me.Controls.Add(Me.PanelRightTop)
        Me.Controls.Add(Me.PanelMidTop)
        Me.Controls.Add(Me.PanelLeftTop)
        Me.Controls.Add(Me.PanelBackColor)
        Me.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.Size = New System.Drawing.Size(366, 177)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelLeftTop As System.Windows.Forms.Panel
    Friend WithEvents PanelMidTop As System.Windows.Forms.Panel
    Friend WithEvents PanelRightTop As System.Windows.Forms.Panel
    Friend WithEvents PanelMidLeft As System.Windows.Forms.Panel
    Friend WithEvents PanelMidRight As System.Windows.Forms.Panel
    Friend WithEvents PanelRightDown As System.Windows.Forms.Panel
    Friend WithEvents PanelLeftDown As System.Windows.Forms.Panel
    Friend WithEvents PanelMidDown As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents PanelBackColor As System.Windows.Forms.Panel

End Class
