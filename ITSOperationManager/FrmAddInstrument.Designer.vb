Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddInstrument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddInstrument))
        Me.lblCode = New System.Windows.Forms.Label()
        Me.tbCode = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.tbSpec = New System.Windows.Forms.TextBox()
        Me.lblSpec = New System.Windows.Forms.Label()
        Me.tbQuantity = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.tbUnit = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lbl_OK = New UIControlLib.LabelEx()
        Me.lbl_Cancel = New UIControlLib.LabelEx()
        Me.ddlInsName = New UIControlLib.UIDropDownList(Me.components)
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
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(328, 57)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(72, 16)
        Me.lblCode.TabIndex = 6
        Me.lblCode.Text = "物品编号"
        '
        'tbCode
        '
        Me.tbCode.BackColor = System.Drawing.Color.Ivory
        Me.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCode.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbCode.Location = New System.Drawing.Point(402, 52)
        Me.tbCode.Name = "tbCode"
        Me.tbCode.ReadOnly = True
        Me.tbCode.Size = New System.Drawing.Size(176, 26)
        Me.tbCode.TabIndex = 30
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(43, 57)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 16)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "物品名称"
        '
        'tbSpec
        '
        Me.tbSpec.BackColor = System.Drawing.Color.Ivory
        Me.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSpec.Enabled = False
        Me.tbSpec.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbSpec.Location = New System.Drawing.Point(118, 84)
        Me.tbSpec.Name = "tbSpec"
        Me.tbSpec.ReadOnly = True
        Me.tbSpec.Size = New System.Drawing.Size(176, 26)
        Me.tbSpec.TabIndex = 34
        '
        'lblSpec
        '
        Me.lblSpec.AutoSize = True
        Me.lblSpec.Location = New System.Drawing.Point(44, 89)
        Me.lblSpec.Name = "lblSpec"
        Me.lblSpec.Size = New System.Drawing.Size(72, 16)
        Me.lblSpec.TabIndex = 33
        Me.lblSpec.Text = "物品规格"
        '
        'tbQuantity
        '
        Me.tbQuantity.BackColor = System.Drawing.SystemColors.Window
        Me.tbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbQuantity.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbQuantity.Location = New System.Drawing.Point(118, 119)
        Me.tbQuantity.Name = "tbQuantity"
        Me.tbQuantity.Size = New System.Drawing.Size(176, 26)
        Me.tbQuantity.TabIndex = 36
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(327, 89)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(72, 16)
        Me.lblUnit.TabIndex = 35
        Me.lblUnit.Text = "物品单位"
        '
        'tbUnit
        '
        Me.tbUnit.BackColor = System.Drawing.Color.Ivory
        Me.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbUnit.Enabled = False
        Me.tbUnit.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.tbUnit.Location = New System.Drawing.Point(402, 84)
        Me.tbUnit.Name = "tbUnit"
        Me.tbUnit.ReadOnly = True
        Me.tbUnit.Size = New System.Drawing.Size(176, 26)
        Me.tbUnit.TabIndex = 40
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(44, 121)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(72, 16)
        Me.lblQuantity.TabIndex = 39
        Me.lblQuantity.Text = "物品数量"
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
        'ddlInsName
        '
        Me.ddlInsName.ColNoOfCode = 0
        Me.ddlInsName.ColNoOfContent = 1
        Me.ddlInsName.ContentID = 2
        Me.ddlInsName.DisplayContent = ""
        Me.ddlInsName.IDContent = ""
        Me.ddlInsName.Location = New System.Drawing.Point(118, 50)
        Me.ddlInsName.Name = "ddlInsName"
        Me.ddlInsName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft
        Me.ddlInsName.Size = New System.Drawing.Size(176, 26)
        Me.ddlInsName.TabIndex = 22
        Me.ddlInsName.VisibleRowCount = 10
        '
        'FrmAddInstrument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 223)
        Me.Controls.Add(Me.ddlInsName)
        Me.Controls.Add(Me.lbl_OK)
        Me.Controls.Add(Me.lbl_Cancel)
        Me.Controls.Add(Me.tbUnit)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.tbQuantity)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.tbSpec)
        Me.Controls.Add(Me.lblSpec)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.tbCode)
        Me.Controls.Add(Me.lblCode)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmAddInstrument"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "添加物品"
        Me.Controls.SetChildIndex(Me.PanelMidTop, 0)
        Me.Controls.SetChildIndex(Me.lblCode, 0)
        Me.Controls.SetChildIndex(Me.tbCode, 0)
        Me.Controls.SetChildIndex(Me.lblName, 0)
        Me.Controls.SetChildIndex(Me.lblSpec, 0)
        Me.Controls.SetChildIndex(Me.tbSpec, 0)
        Me.Controls.SetChildIndex(Me.lblUnit, 0)
        Me.Controls.SetChildIndex(Me.tbQuantity, 0)
        Me.Controls.SetChildIndex(Me.lblQuantity, 0)
        Me.Controls.SetChildIndex(Me.tbUnit, 0)
        Me.Controls.SetChildIndex(Me.lbl_Cancel, 0)
        Me.Controls.SetChildIndex(Me.lbl_OK, 0)
        Me.Controls.SetChildIndex(Me.ddlInsName, 0)
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
    Friend WithEvents lbl_OK As UIControlLib.LabelEx
    Friend WithEvents lbl_Cancel As UIControlLib.LabelEx
    Friend WithEvents ddlInsName As UIControlLib.UIDropDownList
End Class
