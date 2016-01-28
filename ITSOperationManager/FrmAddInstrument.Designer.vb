Imports UIControlLib
Imports ZhiFa.Base.ControlBase
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddInstrument
    Inherits ControlBase

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
        Me.components = New System.ComponentModel.Container()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.tbCode = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.tbSpec = New System.Windows.Forms.TextBox()
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.tbQuantity = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.tbUnit = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.ddlInsName = New UIControlLib.UIDropDownList(Me.components)
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(257, 17)
        Me.lblCode.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(53, 12)
        Me.lblCode.TabIndex = 6
        Me.lblCode.Text = "物品编号"
        '
        'tbCode
        '
        Me.tbCode.BackColor = System.Drawing.Color.Ivory
        Me.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCode.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbCode.Location = New System.Drawing.Point(313, 13)
        Me.tbCode.Margin = New System.Windows.Forms.Padding(2)
        Me.tbCode.Name = "tbCode"
        Me.tbCode.ReadOnly = True
        Me.tbCode.Size = New System.Drawing.Size(159, 21)
        Me.tbCode.TabIndex = 30
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(20, 17)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(53, 12)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "物品名称"
        '
        'tbSpec
        '
        Me.tbSpec.BackColor = System.Drawing.Color.Ivory
        Me.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSpec.Enabled = False
        Me.tbSpec.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbSpec.Location = New System.Drawing.Point(76, 37)
        Me.tbSpec.Margin = New System.Windows.Forms.Padding(2)
        Me.tbSpec.Name = "tbSpec"
        Me.tbSpec.ReadOnly = True
        Me.tbSpec.Size = New System.Drawing.Size(159, 21)
        Me.tbSpec.TabIndex = 34
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(21, 41)
        Me.lblSpec.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(53, 12)
        Me.lblSpec.TabIndex = 33
        Me.lblSpec.Text = "物品规格"
        '
        'tbQuantity
        '
        Me.tbQuantity.BackColor = System.Drawing.SystemColors.Window
        Me.tbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbQuantity.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbQuantity.Location = New System.Drawing.Point(76, 63)
        Me.tbQuantity.Margin = New System.Windows.Forms.Padding(2)
        Me.tbQuantity.Name = "tbQuantity"
        Me.tbQuantity.Size = New System.Drawing.Size(159, 21)
        Me.tbQuantity.TabIndex = 36
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(256, 41)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(53, 12)
        Me.lblUnit.TabIndex = 35
        Me.lblUnit.Text = "物品单位"
        '
        'tbUnit
        '
        Me.tbUnit.BackColor = System.Drawing.Color.Ivory
        Me.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbUnit.Enabled = False
        Me.tbUnit.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbUnit.Location = New System.Drawing.Point(313, 37)
        Me.tbUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.tbUnit.Name = "tbUnit"
        Me.tbUnit.ReadOnly = True
        Me.tbUnit.Size = New System.Drawing.Size(159, 21)
        Me.tbUnit.TabIndex = 40
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(21, 65)
        Me.lblQuantity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(53, 12)
        Me.lblQuantity.TabIndex = 39
        Me.lblQuantity.Text = "物品数量"
        '
        'ddlInsName
        '
        Me.ddlInsName.ColNoOfCode = 0
        Me.ddlInsName.ColNoOfContent = 1
        Me.ddlInsName.ContentID = 2
        Me.ddlInsName.DisplayContent = ""
        Me.ddlInsName.IDContent = ""
        Me.ddlInsName.Location = New System.Drawing.Point(76, 12)
        Me.ddlInsName.Margin = New System.Windows.Forms.Padding(2)
        Me.ddlInsName.Name = "ddlInsName"
        Me.ddlInsName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.ddlInsName.Size = New System.Drawing.Size(160, 21)
        Me.ddlInsName.TabIndex = 22
        Me.ddlInsName.VisibleRowCount = 10
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOK.Location = New System.Drawing.Point(183, 103)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(59, 21)
        Me.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOK.TabIndex = 48
        Me.btnOK.Text = "确认"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(245, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 47
        Me.btnCancel.Text = "取消"
        '
        'FrmAddInstrument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 136)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.ddlInsName)
        Me.Controls.Add(Me.tbUnit)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.tbQuantity)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.tbSpec)
        Me.Controls.Add(Me.lblSpec)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.tbCode)
        Me.Controls.Add(Me.lblCode)
        Me.DoubleBuffered = True
        Me.Name = "FrmAddInstrument"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "添加物品"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents tbCode As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents tbSpec As System.Windows.Forms.TextBox
    Friend WithEvents lblSpec As System.Windows.Forms.Label
    Friend WithEvents tbQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents tbUnit As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents ddlInsName As UIControlLib.UIDropDownList
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
End Class
