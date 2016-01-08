Imports UIControlLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDrugManager
    Inherits MyUserControlBase

    'UserControl 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnBack = New UIControlLib.LabelEx()
        Me.pnlFunction = New System.Windows.Forms.Panel()
        Me.btnConsumeStatistics = New UIControlLib.LabelPerform(Me.components)
        Me.btnInOutStatistics = New UIControlLib.LabelPerform(Me.components)
        Me.btnStockTaking = New UIControlLib.LabelPerform(Me.components)
        Me.btnDrugOut = New UIControlLib.LabelPerform(Me.components)
        Me.btnDrugIn = New UIControlLib.LabelPerform(Me.components)
        Me.btnDrugDispatch = New UIControlLib.LabelPerform(Me.components)
        Me.lblLine = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlFunction.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitle.Size = New System.Drawing.Size(1074, 32)
        Me.LblTitle.Visible = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Fore_Color = System.Drawing.Color.Black
        Me.btnBack.ForeColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(2, 4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(88, 30)
        Me.btnBack.TabIndex = 9
        Me.btnBack.Text = "返回"
        Me.btnBack.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBack.TipText = ""
        '
        'pnlFunction
        '
        Me.pnlFunction.Controls.Add(Me.btnConsumeStatistics)
        Me.pnlFunction.Controls.Add(Me.btnInOutStatistics)
        Me.pnlFunction.Controls.Add(Me.btnStockTaking)
        Me.pnlFunction.Controls.Add(Me.btnDrugOut)
        Me.pnlFunction.Controls.Add(Me.btnDrugIn)
        Me.pnlFunction.Controls.Add(Me.btnDrugDispatch)
        Me.pnlFunction.Controls.Add(Me.btnBack)
        Me.pnlFunction.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFunction.Location = New System.Drawing.Point(0, 32)
        Me.pnlFunction.Name = "pnlFunction"
        Me.pnlFunction.Size = New System.Drawing.Size(1074, 39)
        Me.pnlFunction.TabIndex = 13
        '
        'btnConsumeStatistics
        '
        Me.btnConsumeStatistics.BackColor = System.Drawing.Color.Transparent
        Me.btnConsumeStatistics.Fore_Color = System.Drawing.Color.Black
        Me.btnConsumeStatistics.ForeColor = System.Drawing.Color.Transparent
        Me.btnConsumeStatistics.Location = New System.Drawing.Point(685, 4)
        Me.btnConsumeStatistics.Name = "btnConsumeStatistics"
        Me.btnConsumeStatistics.Size = New System.Drawing.Size(111, 30)
        Me.btnConsumeStatistics.TabIndex = 17
        Me.btnConsumeStatistics.Text = "药品耗损统计"
        Me.btnConsumeStatistics.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsumeStatistics.TipText = ""
        '
        'btnInOutStatistics
        '
        Me.btnInOutStatistics.BackColor = System.Drawing.Color.Transparent
        Me.btnInOutStatistics.Fore_Color = System.Drawing.Color.Black
        Me.btnInOutStatistics.ForeColor = System.Drawing.Color.Transparent
        Me.btnInOutStatistics.Location = New System.Drawing.Point(554, 4)
        Me.btnInOutStatistics.Name = "btnInOutStatistics"
        Me.btnInOutStatistics.Size = New System.Drawing.Size(126, 30)
        Me.btnInOutStatistics.TabIndex = 16
        Me.btnInOutStatistics.Text = "药品出入库统计"
        Me.btnInOutStatistics.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnInOutStatistics.TipText = ""
        '
        'btnStockTaking
        '
        Me.btnStockTaking.BackColor = System.Drawing.Color.Transparent
        Me.btnStockTaking.Fore_Color = System.Drawing.Color.Black
        Me.btnStockTaking.ForeColor = System.Drawing.Color.Transparent
        Me.btnStockTaking.Location = New System.Drawing.Point(439, 4)
        Me.btnStockTaking.Name = "btnStockTaking"
        Me.btnStockTaking.Size = New System.Drawing.Size(111, 30)
        Me.btnStockTaking.TabIndex = 15
        Me.btnStockTaking.Text = "药品库存管理"
        Me.btnStockTaking.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockTaking.TipText = ""
        '
        'btnDrugOut
        '
        Me.btnDrugOut.BackColor = System.Drawing.Color.Transparent
        Me.btnDrugOut.Fore_Color = System.Drawing.Color.Black
        Me.btnDrugOut.ForeColor = System.Drawing.Color.Transparent
        Me.btnDrugOut.Location = New System.Drawing.Point(324, 4)
        Me.btnDrugOut.Name = "btnDrugOut"
        Me.btnDrugOut.Size = New System.Drawing.Size(111, 30)
        Me.btnDrugOut.TabIndex = 14
        Me.btnDrugOut.Text = "药品出库登记"
        Me.btnDrugOut.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDrugOut.TipText = ""
        '
        'btnDrugIn
        '
        Me.btnDrugIn.BackColor = System.Drawing.Color.Transparent
        Me.btnDrugIn.Fore_Color = System.Drawing.Color.Black
        Me.btnDrugIn.ForeColor = System.Drawing.Color.Transparent
        Me.btnDrugIn.Location = New System.Drawing.Point(209, 4)
        Me.btnDrugIn.Name = "btnDrugIn"
        Me.btnDrugIn.Size = New System.Drawing.Size(111, 30)
        Me.btnDrugIn.TabIndex = 13
        Me.btnDrugIn.Text = "药品入库登记"
        Me.btnDrugIn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDrugIn.TipText = ""
        '
        'btnDrugDispatch
        '
        Me.btnDrugDispatch.BackColor = System.Drawing.Color.Transparent
        Me.btnDrugDispatch.Fore_Color = System.Drawing.Color.Black
        Me.btnDrugDispatch.ForeColor = System.Drawing.Color.Transparent
        Me.btnDrugDispatch.Location = New System.Drawing.Point(94, 4)
        Me.btnDrugDispatch.Name = "btnDrugDispatch"
        Me.btnDrugDispatch.Size = New System.Drawing.Size(111, 30)
        Me.btnDrugDispatch.TabIndex = 12
        Me.btnDrugDispatch.Text = "药品发放登记"
        Me.btnDrugDispatch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDrugDispatch.TipText = ""
        '
        'lblLine
        '
        Me.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLine.Location = New System.Drawing.Point(0, 71)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(1074, 1)
        Me.lblLine.TabIndex = 14
        '
        'pnlMain
        '
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 72)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1074, 483)
        Me.pnlMain.TabIndex = 15
        '
        'FrmDrugManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.pnlFunction)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmDrugManager"
        Me.Size = New System.Drawing.Size(1074, 555)
        Me.Controls.SetChildIndex(Me.LblTitle, 0)
        Me.Controls.SetChildIndex(Me.pnlFunction, 0)
        Me.Controls.SetChildIndex(Me.lblLine, 0)
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.pnlFunction.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBack As UIControlLib.LabelEx
    Friend WithEvents pnlFunction As System.Windows.Forms.Panel
    Friend WithEvents btnDrugIn As UIControlLib.LabelPerform
    Friend WithEvents btnDrugDispatch As UIControlLib.LabelPerform
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnInOutStatistics As UIControlLib.LabelPerform
    Friend WithEvents btnStockTaking As UIControlLib.LabelPerform
    Friend WithEvents btnDrugOut As UIControlLib.LabelPerform
    Friend WithEvents btnConsumeStatistics As UIControlLib.LabelPerform

End Class
