Imports System.Drawing
Imports System.ComponentModel

Public Class LabelMenu
    Private m_ContextMenu As System.Windows.Forms.ContextMenu

    Private Sub MenuLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If m_ContextMenu Is Nothing Then
            Return
        End If
        Me.Focus() 'as the pnl will not get the focus as soon as it is clicked like btn,so here complusive set it
        Dim ptShow As Point = New Point(2, Me.Height + 2)
        m_ContextMenu.Show(Me, ptShow)
    End Sub
    Private Sub ColorLabel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Me.ForeColor = System.Drawing.Color.Orange
    End Sub

    Private Sub ColorLabel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        Me.ForeColor = System.Drawing.Color.White
    End Sub


#Region " Ù–‘"
    <Browsable(True)> _
    <DisplayNameAttribute("ContextMenu")> _
    Public Property MenuContext() As System.Windows.Forms.ContextMenu
        Get
            Return m_ContextMenu
        End Get
        Set(ByVal value As System.Windows.Forms.ContextMenu)
            m_ContextMenu = value
        End Set
    End Property
#End Region
End Class
