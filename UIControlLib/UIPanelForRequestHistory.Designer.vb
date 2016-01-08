<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIPanelForRequestHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UIPanelForRequestHistory))
        Me.PanelContent = New System.Windows.Forms.Panel
        Me.PanelParent = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.ImageListType = New System.Windows.Forms.ImageList(Me.components)
        Me.pbContentIcon = New System.Windows.Forms.PictureBox
        Me.pbType = New System.Windows.Forms.PictureBox
        Me.PanelParent.SuspendLayout()
        CType(Me.pbContentIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelContent
        '
        Me.PanelContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.PanelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContent.Location = New System.Drawing.Point(0, 37)
        Me.PanelContent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelContent.Name = "PanelContent"
        Me.PanelContent.Size = New System.Drawing.Size(675, 248)
        Me.PanelContent.TabIndex = 3
        Me.PanelContent.Visible = False
        '
        'PanelParent
        '
        Me.PanelParent.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.PanelParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelParent.Controls.Add(Me.pbContentIcon)
        Me.PanelParent.Controls.Add(Me.lblTitle)
        Me.PanelParent.Controls.Add(Me.lblTime)
        Me.PanelParent.Controls.Add(Me.lblUserName)
        Me.PanelParent.Controls.Add(Me.pbType)
        Me.PanelParent.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelParent.Location = New System.Drawing.Point(0, 0)
        Me.PanelParent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelParent.Name = "PanelParent"
        Me.PanelParent.Size = New System.Drawing.Size(675, 37)
        Me.PanelParent.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(72, 11)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(48, 16)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "Title"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(395, 11)
        Me.lblTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(40, 16)
        Me.lblTime.TabIndex = 3
        Me.lblTime.Text = "Time"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(203, 11)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(72, 16)
        Me.lblUserName.TabIndex = 2
        Me.lblUserName.Text = "UserName"
        '
        'ImageListType
        '
        Me.ImageListType.ImageStream = CType(resources.GetObject("ImageListType.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListType.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListType.Images.SetKeyName(0, "create")
        Me.ImageListType.Images.SetKeyName(1, "delete")
        Me.ImageListType.Images.SetKeyName(2, "update")
        Me.ImageListType.Images.SetKeyName(3, "lock")
        Me.ImageListType.Images.SetKeyName(4, "Unlock")
        Me.ImageListType.Images.SetKeyName(5, "CompulsoryUnlock")
        Me.ImageListType.Images.SetKeyName(6, "dispatch")
        Me.ImageListType.Images.SetKeyName(7, "return")
        Me.ImageListType.Images.SetKeyName(8, "BorrowRequestReturn")
        Me.ImageListType.Images.SetKeyName(9, "ConfirmBorrowRequestReturn")
        '
        'pbContentIcon
        '
        Me.pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Expand_normal
        Me.pbContentIcon.Location = New System.Drawing.Point(584, 8)
        Me.pbContentIcon.Margin = New System.Windows.Forms.Padding(4)
        Me.pbContentIcon.Name = "pbContentIcon"
        Me.pbContentIcon.Size = New System.Drawing.Size(23, 23)
        Me.pbContentIcon.TabIndex = 6
        Me.pbContentIcon.TabStop = False
        Me.pbContentIcon.Visible = False
        '
        'pbType
        '
        Me.pbType.Location = New System.Drawing.Point(17, 9)
        Me.pbType.Margin = New System.Windows.Forms.Padding(4)
        Me.pbType.Name = "pbType"
        Me.pbType.Size = New System.Drawing.Size(21, 21)
        Me.pbType.TabIndex = 0
        Me.pbType.TabStop = False
        '
        'UIPanelForRequestHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelContent)
        Me.Controls.Add(Me.PanelParent)
        Me.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UIPanelForRequestHistory"
        Me.Size = New System.Drawing.Size(675, 285)
        Me.PanelParent.ResumeLayout(False)
        Me.PanelParent.PerformLayout()
        CType(Me.pbContentIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelContent As System.Windows.Forms.Panel
    Friend WithEvents PanelParent As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents pbType As System.Windows.Forms.PictureBox
    Friend WithEvents pbContentIcon As System.Windows.Forms.PictureBox
    Friend WithEvents ImageListType As System.Windows.Forms.ImageList

End Class
