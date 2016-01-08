Imports System.Windows.Forms
Imports System.Windows.Forms.DialogResult
Imports System.Drawing

Public Class UIMsgBox
    Inherits ModalDialogBase
    Private Declare Function ReleaseCapture Lib "user32" () As Long
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Picbox = New PictureBox
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Friend WithEvents lbl_Text As System.Windows.Forms.Label
    Friend WithEvents btn_OK As UIControlLib.LabelEx
    Friend WithEvents btn_Cancel As UIControlLib.LabelEx
    Friend WithEvents btn_Ignore As UIControlLib.LabelEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UIMsgBox))
        Me.lbl_Text = New System.Windows.Forms.Label
        Me.btn_OK = New UIControlLib.LabelEx
        Me.btn_Cancel = New UIControlLib.LabelEx
        Me.btn_Ignore = New UIControlLib.LabelEx
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelMidTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblClose
        '
        '
        'PanelMidTop
        '
        Me.PanelMidTop.Controls.Add(Me.Label1)
        Me.PanelMidTop.Size = New System.Drawing.Size(240, 32)
        '
        'lbl_Text
        '
        Me.lbl_Text.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Text.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl_Text.Location = New System.Drawing.Point(31, 44)
        Me.lbl_Text.Name = "lbl_Text"
        Me.lbl_Text.Size = New System.Drawing.Size(104, 16)
        Me.lbl_Text.TabIndex = 4
        Me.lbl_Text.Text = "LabelText"
        '
        'btn_OK
        '
        Me.btn_OK.BackColor = System.Drawing.SystemColors.Control
        Me.btn_OK.Fore_Color = System.Drawing.Color.Black
        Me.btn_OK.ForeColor = System.Drawing.Color.Transparent
        Me.btn_OK.Image = CType(resources.GetObject("btn_OK.Image"), System.Drawing.Image)
        Me.btn_OK.Location = New System.Drawing.Point(21, 70)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(80, 30)
        Me.btn_OK.TabIndex = 1
        Me.btn_OK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn_Cancel
        '
        Me.btn_Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Cancel.Fore_Color = System.Drawing.Color.Black
        Me.btn_Cancel.ForeColor = System.Drawing.Color.Transparent
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Image)
        Me.btn_Cancel.Location = New System.Drawing.Point(101, 70)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(80, 30)
        Me.btn_Cancel.TabIndex = 2
        Me.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn_Ignore
        '
        Me.btn_Ignore.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Ignore.Fore_Color = System.Drawing.Color.Black
        Me.btn_Ignore.ForeColor = System.Drawing.Color.Transparent
        Me.btn_Ignore.Image = CType(resources.GetObject("btn_Ignore.Image"), System.Drawing.Image)
        Me.btn_Ignore.Location = New System.Drawing.Point(181, 70)
        Me.btn_Ignore.Name = "btn_Ignore"
        Me.btn_Ignore.Size = New System.Drawing.Size(80, 30)
        Me.btn_Ignore.TabIndex = 3
        Me.btn_Ignore.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label1.Location = New System.Drawing.Point(-4, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 26)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "V-TRACK"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UIMsgBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(290, 129)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Ignore)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.lbl_Text)
        Me.Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "UIMsgBox"
        Me.Controls.SetChildIndex(Me.lbl_Text, 0)
        Me.Controls.SetChildIndex(Me.btn_OK, 0)
        Me.Controls.SetChildIndex(Me.btn_Ignore, 0)
        Me.Controls.SetChildIndex(Me.btn_Cancel, 0)
        Me.Controls.SetChildIndex(Me.PanelMidTop, 0)
        Me.PanelMidTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared newForm As UIMsgBox
    Private Shared ReturnButton As DialogResult
    Private Shared nButtonNumber As Integer = 0
    Private Shared nHeight As Integer = 0
    Private Shared nWidth As Integer = 0
    Private Shared Picbox As PictureBox
    Private Shared ButtonType As MessageBoxButtons

    Public Const MSG_CAPTION As String = "MedITS"

    Public Shared Function MSGBoxShow(ByVal strContent As String) As System.Windows.Forms.DialogResult
        Return UIMsgBox.Show(strContent, MSG_CAPTION, MessageBoxButtons.OK)
    End Function

    Public Shared Function MSGBoxShow(ByVal strContent As String, ByVal strCaption As String) As System.Windows.Forms.DialogResult
        Return UIMsgBox.Show(strContent, strCaption, MessageBoxButtons.OKCancel)
    End Function

    Public Shared Function MSGBoxShowOKCancel(ByVal strContent As String) As System.Windows.Forms.DialogResult
        Return UIMsgBox.Show(strContent, MSG_CAPTION, MessageBoxButtons.OKCancel)
    End Function

    Public Shared Function MSGBoxShowOKCancel(ByVal strContent As String, ByVal strCaption As String) As System.Windows.Forms.DialogResult
        Return UIMsgBox.Show(strContent, strCaption, MessageBoxButtons.OKCancel)
    End Function

    Public Shared Function MSGBoxShowYesNo(ByVal strContent As String) As System.Windows.Forms.DialogResult
        Return UIMsgBox.Show(strContent, MSG_CAPTION, MessageBoxButtons.YesNo)
    End Function

    Public Shared Function MSGBoxShowYesNo(ByVal strContent As String, ByVal strCaption As String) As System.Windows.Forms.DialogResult
        Return UIMsgBox.Show(strContent, strCaption, MessageBoxButtons.YesNo)
    End Function

#Region " return press button "
    Private Sub bnt_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        If ButtonType = MessageBoxButtons.OK Then
            ReturnButton = OK
        ElseIf ButtonType = MessageBoxButtons.OKCancel Then
            ReturnButton = OK
        ElseIf ButtonType = MessageBoxButtons.YesNoCancel Then
            ReturnButton = Yes
        ElseIf ButtonType = MessageBoxButtons.YesNo Then
            ReturnButton = Yes
        ElseIf ButtonType = MessageBoxButtons.RetryCancel Then
            ReturnButton = Retry
        ElseIf ButtonType = MessageBoxButtons.AbortRetryIgnore Then
            ReturnButton = Abort
        End If
        Me.DialogResult = OK
        Me.Close()

    End Sub

    Private Sub bnt_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        If ButtonType = MessageBoxButtons.OKCancel Then
            ReturnButton = Cancel
        ElseIf ButtonType = MessageBoxButtons.AbortRetryIgnore Then
            ReturnButton = Retry
        ElseIf ButtonType = MessageBoxButtons.YesNoCancel Then
            ReturnButton = No
        ElseIf ButtonType = MessageBoxButtons.YesNo Then
            ReturnButton = No
        ElseIf ButtonType = MessageBoxButtons.RetryCancel Then
            ReturnButton = Cancel
        End If
        Me.DialogResult = Cancel
        Me.Close()
    End Sub

    Private Sub bnt_Ignore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ignore.Click
        If ButtonType = MessageBoxButtons.AbortRetryIgnore Then
            ReturnButton = Ignore
        ElseIf ButtonType = MessageBoxButtons.YesNoCancel Then
            ReturnButton = Cancel
        End If
        Me.DialogResult = Ignore
        Me.Close()
    End Sub
#End Region
    Private Sub PictureBoxClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblClose.Click
        If ButtonType = MessageBoxButtons.OK Then
            ReturnButton = OK
        ElseIf ButtonType = MessageBoxButtons.OKCancel Then
            ReturnButton = Cancel
        ElseIf ButtonType = MessageBoxButtons.YesNoCancel Then
            ReturnButton = Cancel
        ElseIf ButtonType = MessageBoxButtons.YesNo Then
            ReturnButton = No
        ElseIf ButtonType = MessageBoxButtons.RetryCancel Then
            ReturnButton = Cancel
        ElseIf ButtonType = MessageBoxButtons.AbortRetryIgnore Then
            ReturnButton = Ignore
        End If
    End Sub
    Private Sub MssgBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'get the windows's width 
        Dim x As Short = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width
        lbl_Text.Top = 43
        lbl_Text.Left = 20

        lbl_Text.Width = nWidth
        lbl_Text.Height = nHeight
        '118 means PanelTop+PanelDown + LabelText+ BtnHeight +space
        If nButtonNumber = 1 Then
            If nHeight > Me.Height - 118 Then
                Me.Height = nHeight + 118
            End If
            If nWidth + 40 < btn_OK.Width + 50 Then
                Me.Width = btn_OK.Width + 50
            ElseIf nWidth + 40 > btn_OK.Width + 50 And nWidth < x / 3 * 2 Then
                Me.Width = nWidth + 50
            ElseIf nWidth + 40 > x / 3 * 2 Then
                Me.Width = x / 3 * 2
                lbl_Text.Width = x / 3 * 2 - 50
            End If
            btn_OK.Left = Me.Width / 2 - 40
            btn_OK.Top = Me.Height - 60
            If lbl_Text.Width + 30 > Me.Width Then
                lbl_Text.Width = lbl_Text.Width - (lbl_Text.Width + 35 - Me.Width) - 2
            End If
            Return
        End If

        If nButtonNumber = 2 Then
            If nHeight > Me.Height - 118 Then
                Me.Height = nHeight + 118
            End If
            If nWidth + 40 < btn_OK.Width * 2 + 55 Then
                Me.Width = btn_OK.Width * 2 + 55
            ElseIf nWidth + 40 > btn_OK.Width * 2 + 55 And nWidth < x / 3 * 2 Then
                Me.Width = nWidth + 55
            ElseIf nWidth + 40 > x / 3 * 2 Then
                Me.Width = x / 3 * 2
                lbl_Text.Width = x / 3 * 2 - 55
            End If
            btn_Cancel.Top = Me.Height - 60
            btn_OK.Top = Me.Height - 60
            btn_Cancel.Left = Me.Width / 2 + 3
            btn_OK.Left = Me.Width / 2 - 83
            If lbl_Text.Width + 30 > Me.Width Then
                lbl_Text.Width = lbl_Text.Width - (lbl_Text.Width + 35 - Me.Width) - 2
            End If
            Return
        End If

        If nButtonNumber = 3 Then
            If nHeight > Me.Height - 118 Then
                Me.Height = nHeight + 118
            End If
            If nWidth + 40 < btn_OK.Width * 3 + 60 Then
                Me.Width = btn_OK.Width * 3 + 60
            ElseIf nWidth + 40 > btn_OK.Width * 3 + 60 And nWidth < x / 3 * 2 Then
                Me.Width = nWidth + 60
            ElseIf nWidth + 40 > x / 3 * 2 Then
                Me.Width = x / 3 * 2
                lbl_Text.Width = x / 3 * 2 - 60
            End If
            btn_Ignore.Top = Me.Height - 60
            btn_OK.Top = Me.Height - 60
            btn_Cancel.Top = Me.Height - 60
            btn_Cancel.Left = Me.Width / 2 - 40
            btn_OK.Left = Me.Width / 2 - 126
            btn_Ignore.Left = Me.Width / 2 + 45
            If lbl_Text.Width + 30 > Me.Width Then
                lbl_Text.Width = lbl_Text.Width - (lbl_Text.Width + 35 - Me.Width) - 2
            End If
            Return
        End If



    End Sub

    'for move windows
    Private Sub MyMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub
    'which button to show
    Private Shared Sub ButtonState(ByVal emButtons As MessageBoxButtons)
        If emButtons = MessageBoxButtons.OK Then
            newForm.btn_Cancel.Visible = False
            newForm.btn_OK.Visible = True
            newForm.btn_Ignore.Visible = False
            newForm.btn_OK.Text = "确定"
            nButtonNumber = 1
        ElseIf emButtons = MessageBoxButtons.OKCancel Then
            newForm.btn_Cancel.Visible = True
            newForm.btn_OK.Visible = True
            newForm.btn_Ignore.Visible = False
            newForm.btn_OK.Text = "确定"
            newForm.btn_Cancel.Text = "取消"
            nButtonNumber = 2
        ElseIf emButtons = MessageBoxButtons.YesNo Then
            newForm.btn_Cancel.Visible = True
            newForm.btn_OK.Visible = True
            newForm.btn_Ignore.Visible = False
            newForm.btn_OK.Text = "是"
            newForm.btn_Cancel.Text = "否"
            nButtonNumber = 2
        ElseIf emButtons = MessageBoxButtons.RetryCancel Then
            newForm.btn_Cancel.Visible = True
            newForm.btn_OK.Visible = True
            newForm.btn_Ignore.Visible = False
            newForm.btn_OK.Text = "重试"
            newForm.btn_Cancel.Text = "取消"
            nButtonNumber = 2
        ElseIf emButtons = MessageBoxButtons.YesNoCancel Then
            newForm.btn_Cancel.Visible = True
            newForm.btn_OK.Visible = True
            newForm.btn_Ignore.Visible = True
            newForm.btn_OK.Text = "是"
            newForm.btn_Cancel.Text = "否"
            newForm.btn_Ignore.Text = "取消"
            nButtonNumber = 3
        ElseIf emButtons = MessageBoxButtons.AbortRetryIgnore Then
            newForm.btn_Cancel.Visible = True
            newForm.btn_OK.Visible = True
            newForm.btn_Ignore.Visible = True
            newForm.btn_OK.Text = "终止"
            newForm.btn_Cancel.Text = "重试"
            newForm.btn_Ignore.Text = "忽略"
            nButtonNumber = 3
        End If

    End Sub


    ' get the message's width and height
    Private Shared Sub MeasureStringWidth(ByVal szMessage As String)
        Dim x As Short = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width
        Dim oCG As Graphics = Picbox.CreateGraphics
        Dim sTextSize As SizeF
        sTextSize = oCG.MeasureString(szMessage.Trim, New System.Drawing.Font("SimSun", 12))
        nWidth = sTextSize.Width + 8
        nHeight = sTextSize.Height
        If nWidth > x / 3 * 2 Then
            Dim nBiLi As Integer = nWidth / (x / 3 * 2)
            nHeight = nHeight + nBiLi * 18
        End If

    End Sub


#Region " Show "

    Overloads Shared Function Show(ByVal szMessage As String) As DialogResult
        newForm = New UIMsgBox
        ButtonState(MessageBoxButtons.OK)
        ButtonType = MessageBoxButtons.OK
        MeasureStringWidth(szMessage)
        newForm.lbl_Text.Text = szMessage.Trim
        newForm.Text = ""
        newForm.ShowDialog()
        Return ReturnButton
    End Function

    Overloads Shared Function Show(ByVal szMessage As String, ByVal szTitle As String) As DialogResult
        newForm = New UIMsgBox
        ButtonState(MessageBoxButtons.OK)
        ButtonType = MessageBoxButtons.OK
        MeasureStringWidth(szMessage)
        newForm.lbl_Text.Text = szMessage.Trim
        newForm.Text = ""
        newForm.ShowDialog()
        Return ReturnButton
    End Function

    Overloads Shared Function Show(ByVal szMessage As String, ByVal emButtons As MessageBoxButtons) As DialogResult
        newForm = New UIMsgBox
        ButtonState(emButtons)
        ButtonType = emButtons
        MeasureStringWidth(szMessage)
        newForm.lbl_Text.Text = szMessage.Trim
        newForm.Text = ""
        newForm.ShowDialog()
        Return ReturnButton
    End Function

    Overloads Shared Function Show(ByVal szMessage As String, ByVal szTitle As String, ByVal emButtons As MessageBoxButtons) As DialogResult
        newForm = New UIMsgBox
        ButtonState(emButtons)
        ButtonType = emButtons
        MeasureStringWidth(szMessage)
        newForm.lbl_Text.Text = szMessage.Trim
        newForm.Text = ""
        newForm.ShowDialog()
        Return ReturnButton
    End Function

#End Region




    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim WM_KEYDOWN As Integer = 256
        Dim WM_SYSKEYDOWN As Integer = 260
        If ((msg.Msg = WM_KEYDOWN) Or (msg.Msg = WM_SYSKEYDOWN)) Then
            Select Case keyData
                Case Keys.Enter
                    btn_OK.PerformClick()
                    Return True
                Case Keys.Y
                    btn_OK.PerformClick()
                    Return True
                Case Keys.N
                    btn_Cancel.PerformClick()
                    Return True
                Case Keys.A
                    btn_OK.PerformClick()
                    Return True
                Case Keys.I
                    btn_Ignore.PerformClick()
                    Return True
                Case Keys.R
                    btn_Cancel.PerformClick()
                    Return True
                Case Keys.Escape
                    DialogResult = Cancel
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

 
End Class
