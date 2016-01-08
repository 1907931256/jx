Imports System.Drawing
Public Class ModalDialogBase
    Inherits System.Windows.Forms.Form
    'use api 
    Private Declare Function ReleaseCapture Lib "user32" () As Long
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Friend WithEvents PanelLeftTop As System.Windows.Forms.Panel
    Friend WithEvents PanelRightTop As System.Windows.Forms.Panel
    Friend WithEvents PanelLeftDown As System.Windows.Forms.Panel
    Friend WithEvents PanelRightDown As System.Windows.Forms.Panel
    Protected Friend WithEvents LblClose As UIControlLib.MyLabelBase
    Private Const HTCAPTION As Integer = 2
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        Me.LblClose.SetImageList(Me.LblClose.Image, Me.LblCloseOver.Image, Me.LblClosePress.Image)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        FocusDispatch.RaiseModalDlgBaseDispose(Me)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PanelMidLeft As System.Windows.Forms.Panel
    Friend WithEvents PanelMidRight As System.Windows.Forms.Panel
    Friend WithEvents PanelMidDown As System.Windows.Forms.Panel
    Friend WithEvents LblCloseOver As UIControlLib.MyLabelBase
    Friend WithEvents LblClosePress As UIControlLib.MyLabelBase
    Protected Friend WithEvents PanelMidTop As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModalDialogBase))
        Me.PanelRightTop = New System.Windows.Forms.Panel
        Me.PanelLeftDown = New System.Windows.Forms.Panel
        Me.PanelRightDown = New System.Windows.Forms.Panel
        Me.PanelLeftTop = New System.Windows.Forms.Panel
        Me.PanelMidRight = New System.Windows.Forms.Panel
        Me.PanelMidLeft = New System.Windows.Forms.Panel
        Me.PanelMidTop = New System.Windows.Forms.Panel
        Me.PanelMidDown = New System.Windows.Forms.Panel
        Me.LblClosePress = New UIControlLib.MyLabelBase
        Me.LblCloseOver = New UIControlLib.MyLabelBase
        Me.LblClose = New UIControlLib.MyLabelBase
        Me.PanelRightTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelRightTop
        '
        Me.PanelRightTop.BackgroundImage = CType(resources.GetObject("PanelRightTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelRightTop.Controls.Add(Me.LblClosePress)
        Me.PanelRightTop.Controls.Add(Me.LblCloseOver)
        Me.PanelRightTop.Controls.Add(Me.LblClose)
        Me.PanelRightTop.Location = New System.Drawing.Point(485, 0)
        Me.PanelRightTop.Name = "PanelRightTop"
        Me.PanelRightTop.Size = New System.Drawing.Size(25, 32)
        Me.PanelRightTop.TabIndex = 5
        '
        'PanelLeftDown
        '
        Me.PanelLeftDown.BackgroundImage = CType(resources.GetObject("PanelLeftDown.BackgroundImage"), System.Drawing.Image)
        Me.PanelLeftDown.Location = New System.Drawing.Point(0, 346)
        Me.PanelLeftDown.Name = "PanelLeftDown"
        Me.PanelLeftDown.Size = New System.Drawing.Size(25, 21)
        Me.PanelLeftDown.TabIndex = 5
        '
        'PanelRightDown
        '
        Me.PanelRightDown.BackgroundImage = CType(resources.GetObject("PanelRightDown.BackgroundImage"), System.Drawing.Image)
        Me.PanelRightDown.Location = New System.Drawing.Point(482, 346)
        Me.PanelRightDown.Name = "PanelRightDown"
        Me.PanelRightDown.Size = New System.Drawing.Size(25, 21)
        Me.PanelRightDown.TabIndex = 5
        '
        'PanelLeftTop
        '
        Me.PanelLeftTop.BackgroundImage = CType(resources.GetObject("PanelLeftTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelLeftTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelLeftTop.Name = "PanelLeftTop"
        Me.PanelLeftTop.Size = New System.Drawing.Size(25, 32)
        Me.PanelLeftTop.TabIndex = 4
        '
        'PanelMidRight
        '
        Me.PanelMidRight.BackgroundImage = CType(resources.GetObject("PanelMidRight.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidRight.Location = New System.Drawing.Point(482, 29)
        Me.PanelMidRight.Name = "PanelMidRight"
        Me.PanelMidRight.Size = New System.Drawing.Size(25, 317)
        Me.PanelMidRight.TabIndex = 2
        '
        'PanelMidLeft
        '
        Me.PanelMidLeft.BackgroundImage = CType(resources.GetObject("PanelMidLeft.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidLeft.Location = New System.Drawing.Point(0, 29)
        Me.PanelMidLeft.Name = "PanelMidLeft"
        Me.PanelMidLeft.Size = New System.Drawing.Size(25, 317)
        Me.PanelMidLeft.TabIndex = 1
        '
        'PanelMidTop
        '
        Me.PanelMidTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelMidTop.BackgroundImage = CType(resources.GetObject("PanelMidTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidTop.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PanelMidTop.Location = New System.Drawing.Point(23, 0)
        Me.PanelMidTop.Name = "PanelMidTop"
        Me.PanelMidTop.Size = New System.Drawing.Size(461, 32)
        Me.PanelMidTop.TabIndex = 0
        '
        'PanelMidDown
        '
        Me.PanelMidDown.BackgroundImage = CType(resources.GetObject("PanelMidDown.BackgroundImage"), System.Drawing.Image)
        Me.PanelMidDown.Location = New System.Drawing.Point(23, 346)
        Me.PanelMidDown.Name = "PanelMidDown"
        Me.PanelMidDown.Size = New System.Drawing.Size(461, 21)
        Me.PanelMidDown.TabIndex = 3
        '
        'LblClosePress
        '
        Me.LblClosePress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClosePress.BackColor = System.Drawing.Color.Transparent
        Me.LblClosePress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblClosePress.Image = CType(resources.GetObject("LblClosePress.Image"), System.Drawing.Image)
        Me.LblClosePress.Location = New System.Drawing.Point(3, 6)
        Me.LblClosePress.Name = "LblClosePress"
        Me.LblClosePress.Size = New System.Drawing.Size(16, 16)
        Me.LblClosePress.TabIndex = 2
        Me.LblClosePress.Visible = False
        '
        'LblCloseOver
        '
        Me.LblCloseOver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCloseOver.BackColor = System.Drawing.Color.Transparent
        Me.LblCloseOver.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCloseOver.Image = CType(resources.GetObject("LblCloseOver.Image"), System.Drawing.Image)
        Me.LblCloseOver.Location = New System.Drawing.Point(3, 6)
        Me.LblCloseOver.Name = "LblCloseOver"
        Me.LblCloseOver.Size = New System.Drawing.Size(16, 16)
        Me.LblCloseOver.TabIndex = 1
        Me.LblCloseOver.Visible = False
        '
        'LblClose
        '
        Me.LblClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClose.BackColor = System.Drawing.Color.Transparent
        Me.LblClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblClose.Image = CType(resources.GetObject("LblClose.Image"), System.Drawing.Image)
        Me.LblClose.Location = New System.Drawing.Point(3, 6)
        Me.LblClose.Name = "LblClose"
        Me.LblClose.Size = New System.Drawing.Size(16, 16)
        Me.LblClose.TabIndex = 3
        '
        'ModalDialogBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(507, 369)
        Me.Controls.Add(Me.PanelRightTop)
        Me.Controls.Add(Me.PanelLeftDown)
        Me.Controls.Add(Me.PanelRightDown)
        Me.Controls.Add(Me.PanelLeftTop)
        Me.Controls.Add(Me.PanelMidRight)
        Me.Controls.Add(Me.PanelMidLeft)
        Me.Controls.Add(Me.PanelMidTop)
        Me.Controls.Add(Me.PanelMidDown)
        Me.Font = New System.Drawing.Font("SimSun", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "ModalDialogBase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModalDialog"
        Me.PanelRightTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'for move windows
    Private Sub PanelTop_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelMidTop.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub


#Region "change pictureboxclose's picture"

    'Private Sub PictureBoxClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxClose.MouseMove
    '    PictureBoxClose.Image = System.Drawing.Image.FromFile("..\img\¹Ø±Õ_over.png")
    'End Sub

    'Private Sub PictureBoxClose_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxClose.MouseDown
    '    PictureBoxClose.Image = System.Drawing.Image.FromFile("..\img\¹Ø±Õ_press.png")

    'End Sub

    'Private Sub ModalDialog_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
    '    PictureBoxClose.Image = System.Drawing.Image.FromFile("..\img\¹Ø±Õ_normal.png")
    'End Sub
#End Region
    'Private Sub PictureBoxClose_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxClose.Click
    '    Me.Close()
    'End Sub

    'resize windows
    Private Sub ModalDialog_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        PanelLeftTop.Top = 0
        PanelLeftTop.Left = 0
        PanelRightTop.Top = 0
        PanelRightTop.Left = Me.Width - PanelRightTop.Width
        PanelMidTop.Top = 0
        PanelMidTop.Left = PanelLeftTop.Width
        PanelMidTop.Width = Me.Width - PanelLeftTop.Width - PanelRightTop.Width
        PanelMidLeft.Left = 0
        PanelMidLeft.Top = PanelLeftTop.Height
        PanelMidLeft.Height = Me.Height - PanelLeftTop.Height - PanelLeftDown.Height
        PanelLeftDown.Left = 0
        PanelLeftDown.Top = Me.Height - PanelLeftDown.Height
        PanelRightDown.Left = Me.Width - PanelRightDown.Width
        PanelRightDown.Top = Me.Height - PanelRightDown.Height
        PanelMidDown.Left = PanelRightDown.Width
        PanelMidDown.Top = PanelLeftDown.Top
        PanelMidDown.Width = Me.Width - PanelRightDown.Width - PanelLeftDown.Width
        PanelMidRight.Left = PanelRightTop.Left
        PanelMidRight.Top = PanelRightTop.Height
        PanelMidRight.Height = Me.Height - PanelRightDown.Height - PanelRightTop.Height
        LblClose.Top = 10
        LblClose.Left = 0
    End Sub


    'for set the windows title,u change szTitle then u'll change the title
    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelMidTop.Paint
        Dim mFont As Font = New Font(System.Drawing.FontStyle.Bold, 13)
        Dim mBrush As New SolidBrush(Color.DarkSlateBlue)
        e.Graphics.DrawString(Me.Text, mFont, mBrush, 3, 7)
    End Sub

    Private Sub PictureBoxClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
#Region "Overrides"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim WM_KEYDOWN As Integer = 256
        Dim WM_SYSKEYDOWN As Integer = 260
        If ((msg.Msg = WM_KEYDOWN) Or (msg.Msg = WM_SYSKEYDOWN)) Then
            Select Case keyData
                Case Windows.Forms.Keys.Escape
                    DialogResult = Windows.Forms.DialogResult.Cancel
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
