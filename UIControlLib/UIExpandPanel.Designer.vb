<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIExpandPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UIExpandPanel))
        Me.pnlSearchBarContainer = New System.Windows.Forms.Panel
        Me.pnlDataGridView = New System.Windows.Forms.Panel
        Me.pnlHead = New System.Windows.Forms.Panel
        Me.txtDP = New UIControlLib.UIDropDownList(Me.components)
        Me.lblSearchSec = New System.Windows.Forms.Label
        Me.pnlSearchBarContainer.SuspendLayout()
        Me.pnlHead.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSearchBarContainer
        '
        Me.pnlSearchBarContainer.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchBarContainer.Controls.Add(Me.pnlDataGridView)
        Me.pnlSearchBarContainer.Controls.Add(Me.pnlHead)
        Me.pnlSearchBarContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSearchBarContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearchBarContainer.Name = "pnlSearchBarContainer"
        Me.pnlSearchBarContainer.Size = New System.Drawing.Size(298, 389)
        Me.pnlSearchBarContainer.TabIndex = 0
        '
        'pnlDataGridView
        '
        Me.pnlDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDataGridView.BackColor = System.Drawing.Color.Transparent
        Me.pnlDataGridView.Location = New System.Drawing.Point(0, 32)
        Me.pnlDataGridView.Name = "pnlDataGridView"
        Me.pnlDataGridView.Size = New System.Drawing.Size(298, 357)
        Me.pnlDataGridView.TabIndex = 1
        '
        'pnlHead
        '
        Me.pnlHead.BackgroundImage = CType(resources.GetObject("pnlHead.BackgroundImage"), System.Drawing.Image)
        Me.pnlHead.Controls.Add(Me.txtDP)
        Me.pnlHead.Controls.Add(Me.lblSearchSec)
        Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(298, 32)
        Me.pnlHead.TabIndex = 0
        '
        'txtDP
        '
        Me.txtDP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDP.ColNoOfCode = 0
        Me.txtDP.ColNoOfContent = 1
        Me.txtDP.ContentID = 2
        Me.txtDP.DisplayContent = ""
        Me.txtDP.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.txtDP.IDContent = ""
        Me.txtDP.Location = New System.Drawing.Point(82, 3)
        Me.txtDP.Name = "txtDP"
        Me.txtDP.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.txtDP.Size = New System.Drawing.Size(213, 26)
        Me.txtDP.TabIndex = 4
        Me.txtDP.VisibleRowCount = 10
        '
        'lblSearchSec
        '
        Me.lblSearchSec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSearchSec.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.lblSearchSec.Location = New System.Drawing.Point(7, 6)
        Me.lblSearchSec.Name = "lblSearchSec"
        Me.lblSearchSec.Size = New System.Drawing.Size(72, 20)
        Me.lblSearchSec.TabIndex = 2
        Me.lblSearchSec.Text = "ø∆ “√˚≥∆"
        Me.lblSearchSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UIExpandPanel
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlSearchBarContainer)
        Me.Name = "UIExpandPanel"
        Me.Size = New System.Drawing.Size(298, 389)
        Me.pnlSearchBarContainer.ResumeLayout(False)
        Me.pnlHead.ResumeLayout(False)
        Me.pnlHead.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSearchBarContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlHead As System.Windows.Forms.Panel
    Friend WithEvents lblSearchSec As System.Windows.Forms.Label
    Friend WithEvents pnlDataGridView As System.Windows.Forms.Panel
    Friend WithEvents txtDP As UIControlLib.UIDropDownList

End Class
