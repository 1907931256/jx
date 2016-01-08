Imports System.Windows.Forms
Imports System.Drawing

Imports System.Threading
Imports ITSBase

Public Class UITerminalDataLoadButton

    Private m_MenuContext As ContextMenu
    Private m_ButtonType As String 'Ready,Working
    Protected Const BUTTONTYPEREADY As String = "Ready"
    Protected Const BUTTONTYPEWORKING As String = "Working"
    Private m_HasContext As Boolean = False
    Private m_lstTimerList As List(Of StructureModule.TimerList)
    Protected ReadOnly EDITTEXT As String = TEXT_BTN_EDITTEXT
    Protected ReadOnly WORKINGTEXT As String = TEXT_BTN_WORKINGTEXT
    Protected ReadOnly STATICTEXT As String = TEXT_BTN_STATICTEXT


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_lstTimerList = New List(Of TimerList)
        m_ButtonType = BUTTONTYPEREADY
        SetPicMenuVisible()

    End Sub

    Public Property LoadTimerList() As List(Of TimerList)
        Get
            Return m_lstTimerList
        End Get
        Set(ByVal value As List(Of TimerList))
            m_lstTimerList = value
        End Set
    End Property

    Public Property ButtonType() As String
        Get
            Return m_ButtonType.ToString()
        End Get
        Set(ByVal value As String)
            m_ButtonType = value
            SetPicMenuVisible()
            If m_ButtonType = BUTTONTYPEREADY Then
                Me.btnLoad.Image = Global.UIControlLib.My.Resources.Resources.Handhelds
            Else
                Me.btnLoad.Image = Global.UIControlLib.My.Resources.Resources.computer
                Me.picMenu.Visible = False
            End If
            Me.Refresh()
        End Set
    End Property
    Public Property HasContext() As Boolean
        Get
            Return m_HasContext
        End Get
        Set(ByVal value As Boolean)
            m_HasContext = value
            SetPicMenuVisible()
        End Set
    End Property

    Private Sub SetPicMenuVisible()
        If m_HasContext Then
            Me.picMenu.Visible = True
        Else
            Me.picMenu.Visible = False
        End If
    End Sub

    Private Sub OnpicMenuClick(ByVal sender As Object, ByVal e As EventArgs) Handles picMenu.Click
        'TODO:在此处获取手持机日志信息，添加菜单
        m_MenuContext = New ContextMenu
        For Each oTimerList As TimerList In m_lstTimerList
            Dim menu As New xpmenuitem.xpMenu
            menu.OwnerDraw = True
            menu.Text = oTimerList.m_strTime
            menu.Tag = oTimerList.m_strPath
            'AddHandler menu.Click, AddressOf OnMenuItemClick
            m_MenuContext.MenuItems.Add(menu)
        Next
        Dim menuLine As New xpmenuitem.xpMenu
        menuLine.OwnerDraw = True
        menuLine.Text = "-"
        m_MenuContext.MenuItems.Add(menuLine)

        Dim menuEdit As New xpmenuitem.xpMenu
        menuEdit.OwnerDraw = True
        menuEdit.Text = EDITTEXT
        AddHandler menuEdit.Click, AddressOf OnMenuItemClick
        m_MenuContext.MenuItems.Add(menuEdit)
        m_MenuContext.Show(Me, New System.Drawing.Point(90, 30))
    End Sub

    Private Sub OnMenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim oMenu As xpmenuitem.xpMenu = CType(sender, xpmenuitem.xpMenu)
        If oMenu.Text = EDITTEXT Then
            Me.OnMenuEditClick(sender, EventArgs.Empty)
        End If
    End Sub
    Protected Overridable Sub OnMenuEditClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TODO:在此处添加菜单项事件
    End Sub
    Private Sub OnBtnMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLoad.MouseDown, picMenu.MouseDown
        Me.btnLoad.BackgroundImage = Global.UIControlLib.My.Resources.Resources.btnPress_
        Me.picMenu.BackgroundImage = Global.UIControlLib.My.Resources.Resources.button_mid_press
        If sender.Equals(picMenu) Then
            Me.picMenu.Image = Global.UIControlLib.My.Resources.Resources.DropDown_press
        End If
    End Sub

    Private Sub OnBtnMouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.MouseEnter, picMenu.MouseEnter
        Me.btnLoad.BackgroundImage = Global.UIControlLib.My.Resources.Resources.btnOver_
        Me.picMenu.BackgroundImage = Global.UIControlLib.My.Resources.Resources.button_mid_over
        If sender.Equals(picMenu) Then
            Me.picMenu.Image = Global.UIControlLib.My.Resources.Resources.DropDown_over
        End If
    End Sub

    Private Sub OnBtnMouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.MouseLeave, picMenu.MouseLeave
        Me.btnLoad.BackgroundImage = Global.UIControlLib.My.Resources.Resources.btnNormal_
        Me.picMenu.BackgroundImage = Global.UIControlLib.My.Resources.Resources.button_mid_normal
        If sender.Equals(picMenu) Then
            Me.picMenu.Image = Global.UIControlLib.My.Resources.Resources.DropDown_normal
        End If

    End Sub
    Dim nImgIndex As Integer = -1

    Private Sub btnLoad_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnLoad.Paint
        Dim fontBrush As New SolidBrush(ForeColor)
        If m_ButtonType = BUTTONTYPEREADY Then
            e.Graphics.DrawString(STATICTEXT, New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte)), fontBrush, 28, 7)
        Else
            e.Graphics.DrawString(WORKINGTEXT, New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte)), fontBrush, 28, 7)
        End If
    End Sub

End Class
