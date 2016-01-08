Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddDrug
    Inherits ModalDialogBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddDrug))
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
        Me.lbl_OK = New UIControlLib.LabelEx()
        Me.lbl_Cancel = New UIControlLib.LabelEx()
        Me.tbCommonName = New UIControlLib.UIDropDownList(Me.components)
        Me.tbProductName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LblClose
        '
        Me.LblClose.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblClose.Size = New System.Drawing.Size(21, 21)
        '
        'PanelMidTop
        '
        Me.PanelMidTop.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelMidTop.Size = New System.Drawing.Size(565, 43)
        '
        'lblDrugName
        '
        Me.lblDrugName.AutoSize = True
        Me.lblDrugName.Location = New System.Drawing.Point(44, 50)
        Me.lblDrugName.Name = "lblDrugName"
        Me.lblDrugName.Size = New System.Drawing.Size(72, 16)
        Me.lblDrugName.TabIndex = 6
        Me.lblDrugName.Text = "药品名称"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(316, 50)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(88, 16)
        Me.lblProductName.TabIndex = 31
        Me.lblProductName.Text = "药品商品名"
        '
        'tbSpec
        '
        Me.tbSpec.BackColor = System.Drawing.Color.Ivory
        Me.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSpec.Enabled = False
        Me.tbSpec.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbSpec.Location = New System.Drawing.Point(118, 77)
        Me.tbSpec.Name = "tbSpec"
        Me.tbSpec.ReadOnly = True
        Me.tbSpec.Size = New System.Drawing.Size(176, 26)
        Me.tbSpec.TabIndex = 34
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(44, 82)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(72, 16)
        Me.lblSpec.TabIndex = 33
        Me.lblSpec.Text = "药品规格"
        '
        'tbUnit
        '
        Me.tbUnit.BackColor = System.Drawing.Color.Ivory
        Me.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbUnit.Enabled = False
        Me.tbUnit.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbUnit.Location = New System.Drawing.Point(118, 109)
        Me.tbUnit.Name = "tbUnit"
        Me.tbUnit.ReadOnly = True
        Me.tbUnit.Size = New System.Drawing.Size(176, 26)
        Me.tbUnit.TabIndex = 36
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(44, 114)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(72, 16)
        Me.lblUnit.TabIndex = 35
        Me.lblUnit.Text = "药品单位"
        '
        'tbManufacture
        '
        Me.tbManufacture.BackColor = System.Drawing.Color.Ivory
        Me.tbManufacture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbManufacture.Enabled = False
        Me.tbManufacture.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbManufacture.Location = New System.Drawing.Point(402, 77)
        Me.tbManufacture.Name = "tbManufacture"
        Me.tbManufacture.ReadOnly = True
        Me.tbManufacture.Size = New System.Drawing.Size(176, 26)
        Me.tbManufacture.TabIndex = 38
        '
        'lblManufactur
        '
        Me.lblManufactur.AutoSize = True
        Me.lblManufactur.Location = New System.Drawing.Point(316, 82)
        Me.lblManufactur.Name = "lblManufactur"
        Me.lblManufactur.Size = New System.Drawing.Size(72, 16)
        Me.lblManufactur.TabIndex = 37
        Me.lblManufactur.Text = "药品厂家"
        '
        'tbQuantity
        '
        Me.tbQuantity.BackColor = System.Drawing.SystemColors.Window
        Me.tbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbQuantity.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbQuantity.Location = New System.Drawing.Point(402, 109)
        Me.tbQuantity.Name = "tbQuantity"
        Me.tbQuantity.Size = New System.Drawing.Size(176, 26)
        Me.tbQuantity.TabIndex = 40
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(316, 114)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(72, 16)
        Me.lblQuantity.TabIndex = 39
        Me.lblQuantity.Text = "药品数量"
        '
        'lbl_OK
        '
        Me.lbl_OK.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_OK.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl_OK.Fore_Color = System.Drawing.Color.Black
        Me.lbl_OK.ForeColor = System.Drawing.Color.Transparent
        Me.lbl_OK.Image = CType(resources.GetObject("lbl_OK.Image"), System.Drawing.Image)
        Me.lbl_OK.Location = New System.Drawing.Point(217, 168)
        Me.lbl_OK.Name = "lbl_OK"
        Me.lbl_OK.Size = New System.Drawing.Size(88, 30)
        Me.lbl_OK.TabIndex = 42
        Me.lbl_OK.Text = "确定"
        Me.lbl_OK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbl_OK.TipText = ""
        '
        'lbl_Cancel
        '
        Me.lbl_Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Cancel.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl_Cancel.Fore_Color = System.Drawing.Color.Black
        Me.lbl_Cancel.ForeColor = System.Drawing.Color.Transparent
        Me.lbl_Cancel.Image = CType(resources.GetObject("lbl_Cancel.Image"), System.Drawing.Image)
        Me.lbl_Cancel.Location = New System.Drawing.Point(313, 168)
        Me.lbl_Cancel.Name = "lbl_Cancel"
        Me.lbl_Cancel.Size = New System.Drawing.Size(88, 30)
        Me.lbl_Cancel.TabIndex = 41
        Me.lbl_Cancel.Text = "关闭"
        Me.lbl_Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbl_Cancel.TipText = ""
        '
        'tbCommonName
        '
        Me.tbCommonName.BackColor = System.Drawing.SystemColors.Window
        Me.tbCommonName.ColNoOfCode = 0
        Me.tbCommonName.ColNoOfContent = 1
        Me.tbCommonName.ContentID = 2
        Me.tbCommonName.DisplayContent = ""
        Me.tbCommonName.IDContent = ""
        Me.tbCommonName.Location = New System.Drawing.Point(118, 45)
        Me.tbCommonName.Name = "tbCommonName"
        Me.tbCommonName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.tbCommonName.Size = New System.Drawing.Size(176, 26)
        Me.tbCommonName.TabIndex = 33
        Me.tbCommonName.VisibleRowCount = 10
        '
        'tbProductName
        '
        Me.tbProductName.BackColor = System.Drawing.Color.Ivory
        Me.tbProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbProductName.Enabled = False
        Me.tbProductName.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbProductName.Location = New System.Drawing.Point(402, 45)
        Me.tbProductName.Name = "tbProductName"
        Me.tbProductName.ReadOnly = True
        Me.tbProductName.Size = New System.Drawing.Size(176, 26)
        Me.tbProductName.TabIndex = 44
        '
        'FrmAddDrug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 223)
        Me.Controls.Add(Me.tbProductName)
        Me.Controls.Add(Me.tbCommonName)
        Me.Controls.Add(Me.lbl_OK)
        Me.Controls.Add(Me.lbl_Cancel)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmAddDrug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "添加药品"
        Me.Controls.SetChildIndex(Me.PanelMidTop, 0)
        Me.Controls.SetChildIndex(Me.lblDrugName, 0)
        Me.Controls.SetChildIndex(Me.lblProductName, 0)
        Me.Controls.SetChildIndex(Me.lblSpec, 0)
        Me.Controls.SetChildIndex(Me.tbSpec, 0)
        Me.Controls.SetChildIndex(Me.lblUnit, 0)
        Me.Controls.SetChildIndex(Me.tbUnit, 0)
        Me.Controls.SetChildIndex(Me.lblManufactur, 0)
        Me.Controls.SetChildIndex(Me.tbManufacture, 0)
        Me.Controls.SetChildIndex(Me.lblQuantity, 0)
        Me.Controls.SetChildIndex(Me.tbQuantity, 0)
        Me.Controls.SetChildIndex(Me.lbl_Cancel, 0)
        Me.Controls.SetChildIndex(Me.lbl_OK, 0)
        Me.Controls.SetChildIndex(Me.tbCommonName, 0)
        Me.Controls.SetChildIndex(Me.tbProductName, 0)
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
    Friend WithEvents lbl_OK As UIControlLib.LabelEx
    Friend WithEvents lbl_Cancel As UIControlLib.LabelEx
    Friend WithEvents tbCommonName As UIControlLib.UIDropDownList
    Friend WithEvents tbProductName As System.Windows.Forms.TextBox
End Class
