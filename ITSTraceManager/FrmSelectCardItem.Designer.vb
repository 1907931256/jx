Imports DevComponents.DotNetBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectCardItem
    Inherits Office2007Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectCardItem))
        Me.tbUnsel = New System.Windows.Forms.TextBox()
        Me.dgvNoSel = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tbSel = New System.Windows.Forms.TextBox()
        Me.btnSel = New DevComponents.DotNetBar.ButtonX()
        Me.btnUnsel = New DevComponents.DotNetBar.ButtonX()
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.dgvSel = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.dgvNoSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbUnsel
        '
        Me.tbUnsel.Location = New System.Drawing.Point(0, 4)
        Me.tbUnsel.Name = "tbUnsel"
        Me.tbUnsel.Size = New System.Drawing.Size(212, 21)
        Me.tbUnsel.TabIndex = 12
        '
        'dgvNoSel
        '
        Me.dgvNoSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNoSel.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNoSel.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvNoSel.Location = New System.Drawing.Point(0, 28)
        Me.dgvNoSel.Name = "dgvNoSel"
        Me.dgvNoSel.ReadOnly = True
        Me.dgvNoSel.RowHeadersVisible = False
        Me.dgvNoSel.RowTemplate.Height = 23
        Me.dgvNoSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNoSel.Size = New System.Drawing.Size(212, 250)
        Me.dgvNoSel.TabIndex = 13
        '
        'tbSel
        '
        Me.tbSel.Location = New System.Drawing.Point(280, 4)
        Me.tbSel.Name = "tbSel"
        Me.tbSel.Size = New System.Drawing.Size(212, 21)
        Me.tbSel.TabIndex = 14
        '
        'btnSel
        '
        Me.btnSel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSel.Location = New System.Drawing.Point(217, 106)
        Me.btnSel.Name = "btnSel"
        Me.btnSel.Size = New System.Drawing.Size(57, 23)
        Me.btnSel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSel.TabIndex = 15
        Me.btnSel.Text = ">"
        '
        'btnUnsel
        '
        Me.btnUnsel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUnsel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnUnsel.Location = New System.Drawing.Point(217, 132)
        Me.btnUnsel.Name = "btnUnsel"
        Me.btnUnsel.Size = New System.Drawing.Size(57, 23)
        Me.btnUnsel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUnsel.TabIndex = 16
        Me.btnUnsel.Text = "<"
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOK.Location = New System.Drawing.Point(217, 254)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(57, 23)
        Me.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOK.TabIndex = 17
        Me.btnOK.Text = "确定"
        '
        'dgvSel
        '
        Me.dgvSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSel.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSel.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvSel.Location = New System.Drawing.Point(280, 28)
        Me.dgvSel.Name = "dgvSel"
        Me.dgvSel.ReadOnly = True
        Me.dgvSel.RowHeadersVisible = False
        Me.dgvSel.RowTemplate.Height = 23
        Me.dgvSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSel.Size = New System.Drawing.Size(212, 250)
        Me.dgvSel.TabIndex = 18
        '
        'FrmSelectCardItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 287)
        Me.Controls.Add(Me.dgvSel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnUnsel)
        Me.Controls.Add(Me.btnSel)
        Me.Controls.Add(Me.tbSel)
        Me.Controls.Add(Me.dgvNoSel)
        Me.Controls.Add(Me.tbUnsel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSelectCardItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "选择统计项目"
        CType(Me.dgvNoSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbUnsel As System.Windows.Forms.TextBox
    Friend WithEvents dgvNoSel As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tbSel As System.Windows.Forms.TextBox
    Friend WithEvents btnSel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUnsel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgvSel As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
