Imports ITSBase
Public Class UIPanelForRequestHistory

    Private Enum RQ_LOG_IMG_TYPE As Short
        CREATE = 0        '创建
        DELETE = 1        '删除
        MODIFY = 2        '修改
        LOCK = 3          '锁定
        UNLOCK = 4        '解锁
        FORCE_UNLOCK = 5  '强制解锁
        DISPATCH = 6      '发放
        BACK = 7          '返回
        BORROW_BACK = 8   '借单归还
        BORROW_CONFIRMED = 9 '借单归还确认
    End Enum

    Private Const m_strTitle_Create As String = "创建"
    Private Const m_strTitle_Delete As String = "删除"
    Private Const m_strTitle_Modify As String = "修改"
    Private Const m_strTitle_Lock As String = "锁定"
    Private Const m_strTitle_Unlock As String = "解锁"
    Private Const m_strTitle_ForceUnlock As String = "强制解锁"
    Private Const m_strTitle_Dispatch As String = "发放"
    Private Const m_strTitle_Back As String = "返回"
    Private Const m_strTitle_BorrowBack As String = "借单归还"
    Private Const m_strTitle_BorrowConfirmed As String = "借单归还确认"

    Public ReadOnly Property Title() As String
        Get
            Return lblTitle.Text
        End Get
    End Property

    Public Property UserName() As String
        Get
            Return lblUserName.Text
        End Get
        Set(ByVal value As String)
            lblUserName.Text = value
        End Set
    End Property

    Public Property HistoryTime() As String
        Get
            Return lblTime.Text
        End Get
        Set(ByVal value As String)
            lblTime.Text = value
        End Set
    End Property

    Public ReadOnly Property ContentPanel() As System.Windows.Forms.Panel
        Get
            Return PanelContent
        End Get
    End Property

    Public Property HasContent() As Boolean
        Get
            Return pbContentIcon.Visible
        End Get
        Set(ByVal value As Boolean)
            pbContentIcon.Visible = value
        End Set
    End Property

    Public WriteOnly Property ContentEnabled() As Boolean
        Set(ByVal value As Boolean)
            pbContentIcon.Enabled = value

            If value Then
                pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Expand_normal
            Else
                pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Shrink_disable
            End If


        End Set
    End Property

    Private m_nContentHeight As Integer
    Public Property ContentHeight() As Integer
        Get
            Return m_nContentHeight
        End Get
        Set(ByVal value As Integer)
            m_nContentHeight = value
            PanelContent.Height = m_nContentHeight
        End Set
    End Property
    Public Property DefalutHeight() As Integer
        Get
            Return PanelParent.Height
        End Get
        Set(ByVal value As Integer)
            PanelParent.Height = value
            Me.Height = value
        End Set
    End Property

    Private m_RequestHistoryType As Integer
    Public Property RequestHistoryType() As Integer
        Get
            Return m_RequestHistoryType
        End Get
        Set(ByVal value As Integer)
            If value >= ImageListType.Images.Count Or value < 0 Then
                Return
            End If
            m_RequestHistoryType = value
        End Set
    End Property

    Private Sub UIPanelForRequestHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbType.Image = CType(ImageListType.Images(m_RequestHistoryType), System.Drawing.Image)
        Select Case m_RequestHistoryType
            Case RQ_LOG_IMG_TYPE.CREATE
                lblTitle.Text = m_strTitle_Create
            Case RQ_LOG_IMG_TYPE.DELETE
                lblTitle.Text = m_strTitle_Delete
            Case RQ_LOG_IMG_TYPE.MODIFY
                lblTitle.Text = m_strTitle_Modify
            Case RQ_LOG_IMG_TYPE.LOCK
                lblTitle.Text = m_strTitle_Lock
            Case RQ_LOG_IMG_TYPE.UNLOCK
                lblTitle.Text = m_strTitle_Unlock
            Case RQ_LOG_IMG_TYPE.FORCE_UNLOCK
                lblTitle.Text = m_strTitle_ForceUnlock
            Case RQ_LOG_IMG_TYPE.DISPATCH
                lblTitle.Text = m_strTitle_Dispatch
            Case RQ_LOG_IMG_TYPE.BACK
                lblTitle.Text = m_strTitle_Back
            Case RQ_LOG_IMG_TYPE.BORROW_BACK
                lblTitle.Text = m_strTitle_BorrowBack
            Case RQ_LOG_IMG_TYPE.BORROW_CONFIRMED
                lblTitle.Text = m_strTitle_BorrowConfirmed
        End Select
    End Sub

    Private Sub pbContentIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbContentIcon.Click
        If PanelContent.Visible = False Then
            PanelContent.Visible = True
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Shrink_normal
            Me.Height += m_nContentHeight
        Else
            PanelContent.Visible = False
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Expand_normal
            Me.Height -= m_nContentHeight
        End If
    End Sub

    Private Sub pbContentIcon_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbContentIcon.MouseDown
        If PanelContent.Visible = True Then
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Shrink_press
        Else
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Expand_press
        End If
    End Sub

    Private Sub pbContentIcon_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbContentIcon.MouseEnter
        If PanelContent.Visible = True Then
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Shrink_over
        Else
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Expand_over
        End If
    End Sub

    Private Sub pbContentIcon_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbContentIcon.MouseLeave
        If PanelContent.Visible = True Then
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Shrink_normal
        Else
            pbContentIcon.Image = Global.UIControlLib.My.Resources.Resources.Expand_normal
        End If
    End Sub
End Class
