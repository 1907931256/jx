Imports System.Drawing
Imports System.ComponentModel
Imports system.Windows.forms

Public Class LabelList
    Inherits MyLabelBase
    Private m_cLabelMenu As LabelMenu = New LabelMenu
    Private m_cContextMenu As ContextMenu = New ContextMenu
    Private m_strText As String
    Public Event OnSelectMenuItemChange(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Sub New()
        MyBase.New()
        Me.Image = My.Resources.btnNormal_90_Dropdown
        Me.SetImageList(My.Resources.btnNormal_90_Dropdown, My.Resources.btnOver_90_Dropdown, My.Resources.btnPress_90_Dropdown)
    End Sub

    Private Sub LabelList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If m_cContextMenu Is Nothing Then Exit Sub
        m_cContextMenu.Show(Me, New System.Drawing.Point(0, Me.Height))
    End Sub

    Private Sub OnSelectMenuItemClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oMenu As xpmenuitem.xpMenu = CType(sender, xpmenuitem.xpMenu)
        If Not oMenu Is Nothing Then
            Me.Text = oMenu.Text
        End If
        RaiseEvent OnSelectMenuItemChange(sender, e)
    End Sub

    Private Sub OnSelectContextMenuItemChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        RaiseEvent OnSelectMenuItemChange(sender, e)
    End Sub

    Public Sub Clear()
        If m_cContextMenu Is Nothing Then Exit Sub
        m_cContextMenu.MenuItems.Clear()
    End Sub

    Public Sub Add(ByVal strItem As String)
        If m_cContextMenu Is Nothing Then
            m_cContextMenu = New ContextMenu
        End If
        Dim oMenuItem As New xpmenuitem.xpMenu
        oMenuItem.OwnerDraw = True
        oMenuItem.Text = strItem

        AddHandler oMenuItem.Click, AddressOf OnSelectMenuItemClick
        m_cContextMenu.MenuItems.Add(oMenuItem)
    End Sub

    Public Overrides Property Text() As String
        Get
            Return m_strText
        End Get
        Set(ByVal value As String)
            m_strText = value
            If m_cContextMenu Is Nothing Then
                m_cContextMenu = New ContextMenu
            End If
            For Each oMenuItem As xpmenuitem.xpMenu In m_cContextMenu.MenuItems
                oMenuItem.Checked = False
                If oMenuItem.Text = m_strText Then
                    oMenuItem.Checked = True
                End If
            Next
            MyBase.Text = m_strText
            MyBase.Refresh()
        End Set
    End Property

End Class
