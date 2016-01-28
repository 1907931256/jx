Imports UIControlLib
Imports ZhiFa.Base.ControlBase

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddDrug
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
        Me.lblDrugName = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.tbSpec = New System.Windows.Forms.TextBox()
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.tbUnit = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.tbManufacture = New System.Windows.Forms.TextBox()
        Me.lblManufactur = New System.Windows.Forms.Label()
        Me.tbQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.tbCommonName = New UIControlLib.UIDropDownList(Me.components)
        Me.tbProductName = New System.Windows.Forms.TextBox()
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'lblDrugName
        '
        Me.lblDrugName.AutoSize = True
        Me.lblDrugName.Location = New System.Drawing.Point(16, 15)
        Me.lblDrugName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDrugName.Name = "lblDrugName"
        Me.lblDrugName.Size = New System.Drawing.Size(53, 12)
        Me.lblDrugName.TabIndex = 6
        Me.lblDrugName.Text = "药品名称"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(250, 14)
        Me.lblProductName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(65, 12)
        Me.lblProductName.TabIndex = 31
        Me.lblProductName.Text = "药品商品名"
        '
        'tbSpec
        '
        Me.tbSpec.BackColor = System.Drawing.Color.Ivory
        Me.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSpec.Enabled = False
        Me.tbSpec.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbSpec.Location = New System.Drawing.Point(71, 35)
        Me.tbSpec.Margin = New System.Windows.Forms.Padding(2)
        Me.tbSpec.Name = "tbSpec"
        Me.tbSpec.ReadOnly = True
        Me.tbSpec.Size = New System.Drawing.Size(148, 21)
        Me.tbSpec.TabIndex = 34
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(16, 39)
        Me.lblSpec.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(53, 12)
        Me.lblSpec.TabIndex = 33
        Me.lblSpec.Text = "药品规格"
        '
        'tbUnit
        '
        Me.tbUnit.BackColor = System.Drawing.Color.Ivory
        Me.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbUnit.Enabled = False
        Me.tbUnit.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbUnit.Location = New System.Drawing.Point(71, 59)
        Me.tbUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.tbUnit.Name = "tbUnit"
        Me.tbUnit.ReadOnly = True
        Me.tbUnit.Size = New System.Drawing.Size(148, 21)
        Me.tbUnit.TabIndex = 36
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(16, 63)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(53, 12)
        Me.lblUnit.TabIndex = 35
        Me.lblUnit.Text = "药品单位"
        '
        'tbManufacture
        '
        Me.tbManufacture.BackColor = System.Drawing.Color.Ivory
        Me.tbManufacture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbManufacture.Enabled = False
        Me.tbManufacture.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbManufacture.Location = New System.Drawing.Point(315, 34)
        Me.tbManufacture.Margin = New System.Windows.Forms.Padding(2)
        Me.tbManufacture.Name = "tbManufacture"
        Me.tbManufacture.ReadOnly = True
        Me.tbManufacture.Size = New System.Drawing.Size(148, 21)
        Me.tbManufacture.TabIndex = 38
        '
        'lblManufactur
        '
        Me.lblManufactur.AutoSize = True
        Me.lblManufactur.Location = New System.Drawing.Point(250, 38)
        Me.lblManufactur.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblManufactur.Name = "lblManufactur"
        Me.lblManufactur.Size = New System.Drawing.Size(53, 12)
        Me.lblManufactur.TabIndex = 37
        Me.lblManufactur.Text = "药品厂家"
        '
        'tbQuantity
        '
        Me.tbQuantity.BackColor = System.Drawing.SystemColors.Window
        Me.tbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbQuantity.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbQuantity.Location = New System.Drawing.Point(315, 58)
        Me.tbQuantity.Margin = New System.Windows.Forms.Padding(2)
        Me.tbQuantity.Name = "tbQuantity"
        Me.tbQuantity.Size = New System.Drawing.Size(148, 21)
        Me.tbQuantity.TabIndex = 40
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(250, 62)
        Me.lblQuantity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(53, 12)
        Me.lblQuantity.TabIndex = 39
        Me.lblQuantity.Text = "药品数量"
        '
        'tbCommonName
        '
        Me.tbCommonName.BackColor = System.Drawing.SystemColors.Window
        Me.tbCommonName.ColNoOfCode = 0
        Me.tbCommonName.ColNoOfContent = 1
        Me.tbCommonName.ContentID = 2
        Me.tbCommonName.DisplayContent = ""
        Me.tbCommonName.IDContent = ""
        Me.tbCommonName.Location = New System.Drawing.Point(71, 11)
        Me.tbCommonName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbCommonName.Name = "tbCommonName"
        Me.tbCommonName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.tbCommonName.Size = New System.Drawing.Size(149, 21)
        Me.tbCommonName.TabIndex = 33
        Me.tbCommonName.VisibleRowCount = 10
        '
        'tbProductName
        '
        Me.tbProductName.BackColor = System.Drawing.Color.Ivory
        Me.tbProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbProductName.Enabled = False
        Me.tbProductName.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.tbProductName.Location = New System.Drawing.Point(315, 10)
        Me.tbProductName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbProductName.Name = "tbProductName"
        Me.tbProductName.ReadOnly = True
        Me.tbProductName.Size = New System.Drawing.Size(148, 21)
        Me.tbProductName.TabIndex = 44
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOK.Location = New System.Drawing.Point(172, 103)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(59, 21)
        Me.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOK.TabIndex = 46
        Me.btnOK.Text = "确认"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(237, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 21)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Text = "取消"
        '
        'FrmAddDrug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 129)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.tbProductName)
        Me.Controls.Add(Me.tbCommonName)
        Me.Controls.Add(Me.tbQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.tbManufacture)
        Me.Controls.Add(Me.lblManufactur)
        Me.Controls.Add(Me.tbUnit)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.tbSpec)
        Me.Controls.Add(Me.lblSpec)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.lblDrugName)
        Me.DoubleBuffered = True
        Me.Name = "FrmAddDrug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "添加药品"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDrugName As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents tbSpec As System.Windows.Forms.TextBox
    Friend WithEvents lblSpec As System.Windows.Forms.Label
    Friend WithEvents tbUnit As System.Windows.Forms.TextBox
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents tbManufacture As System.Windows.Forms.TextBox
    Friend WithEvents lblManufactur As System.Windows.Forms.Label
    Friend WithEvents tbQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents tbCommonName As UIControlLib.UIDropDownList
    Friend WithEvents tbProductName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
End Class
