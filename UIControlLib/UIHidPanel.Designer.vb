<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIHidPanel
    Inherits System.Windows.Forms.Panel

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
        Me.plTop = New System.Windows.Forms.Panel
        Me.btnHid = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.plRight = New System.Windows.Forms.Panel
        Me.lblHid = New System.Windows.Forms.Label
        Me.plTop.SuspendLayout()
        Me.plRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'plTop
        '
        Me.plTop.BackColor = System.Drawing.Color.Transparent
        Me.plTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plTop.Controls.Add(Me.btnHid)
        Me.plTop.Controls.Add(Me.lblTitle)
        Me.plTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.plTop.Location = New System.Drawing.Point(0, 0)
        Me.plTop.Name = "plTop"
        Me.plTop.Size = New System.Drawing.Size(255, 33)
        Me.plTop.TabIndex = 0
        '
        'btnHid
        '
        Me.btnHid.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnHid.Location = New System.Drawing.Point(221, 0)
        Me.btnHid.Name = "btnHid"
        Me.btnHid.Size = New System.Drawing.Size(32, 31)
        Me.btnHid.TabIndex = 1
        Me.btnHid.Text = ">>"
        Me.btnHid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(128, 31)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "title"
        '
        'plRight
        '
        Me.plRight.BackColor = System.Drawing.Color.Transparent
        Me.plRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plRight.Controls.Add(Me.lblHid)
        Me.plRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.plRight.Location = New System.Drawing.Point(222, 33)
        Me.plRight.Name = "plRight"
        Me.plRight.Size = New System.Drawing.Size(33, 252)
        Me.plRight.TabIndex = 2
        '
        'lblHid
        '
        Me.lblHid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHid.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblHid.Location = New System.Drawing.Point(0, 0)
        Me.lblHid.Name = "lblHid"
        Me.lblHid.Size = New System.Drawing.Size(31, 250)
        Me.lblHid.TabIndex = 1
        Me.lblHid.Text = "title"
        '
        'UIHidPanel
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.plRight)
        Me.Controls.Add(Me.plTop)
        Me.Size = New System.Drawing.Size(255, 285)
        Me.plTop.ResumeLayout(False)
        Me.plRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblHid As System.Windows.Forms.Label
    Friend WithEvents btnHid As System.Windows.Forms.Label
    Friend WithEvents plTop As System.Windows.Forms.Panel
    Friend WithEvents plRight As System.Windows.Forms.Panel

End Class
