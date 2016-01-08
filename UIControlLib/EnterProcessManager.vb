'********************************************************************
'	Title:			EnterProcessManager
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-4-18
'	Description:    Make the enter key like Tab, focus one by one
'*********************************************************************
Option Explicit On 
Option Strict On

Imports System.Windows.Forms
Public Class EnterProcessManager
    Private m_arrControl As ArrayList
    Public Sub New()
        m_arrControl = Nothing
    End Sub
    Public Sub Add(ByVal oCtl As Control)
        If Not TypeOf (oCtl) Is Control Then Exit Sub
        If m_arrControl Is Nothing Then m_arrControl = New ArrayList
        m_arrControl.Add(oCtl)
        AddHandler oCtl.KeyPress, AddressOf OnControlKeyPress
    End Sub
    Public Sub Remove(ByVal oCtl As Control)
        If m_arrControl Is Nothing Then Exit Sub

        Dim nIndex As Integer = m_arrControl.IndexOf(oCtl)
        If nIndex < 0 Then Exit Sub

        m_arrControl.Remove(oCtl)
        RemoveHandler oCtl.KeyPress, AddressOf OnControlKeyPress
    End Sub
    Public Sub RemoveALL()
        If m_arrControl Is Nothing Then Exit Sub
        For Each oCtl As Control In m_arrControl
            RemoveHandler oCtl.KeyPress, AddressOf OnControlKeyPress
        Next
        m_arrControl.Clear()
    End Sub
    Private Sub OnControlKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If m_arrControl Is Nothing Then Exit Sub
        If e.KeyChar.ToString <> Chr(13) AndAlso e.KeyChar.ToString <> Chr(10) Then Exit Sub

        Dim nCurIndex As Integer = m_arrControl.IndexOf(sender)
        If nCurIndex < 0 Then Exit Sub

        Dim nNextIndex As Integer = GetNext(nCurIndex)
        If nNextIndex >= 0 AndAlso nNextIndex < m_arrControl.Count Then
            If TypeOf (m_arrControl.Item(nNextIndex)) Is Button Then
                CType(m_arrControl.Item(nNextIndex), Button).PerformClick()
            ElseIf TypeOf (m_arrControl.Item(nNextIndex)) Is MyLabelBase Then
                CType(m_arrControl.Item(nNextIndex), MyLabelBase).PerformClick()
            Else
                CType(m_arrControl.Item(nNextIndex), Control).Focus()
            End If
        End If
        '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
        e.Handled = True
    End Sub

    Private Function GetNext(ByVal nIndex As Integer) As Integer
        If nIndex >= m_arrControl.Count - 1 Then
            Return -1
        End If

        If TypeOf (m_arrControl.Item(nIndex)) Is TextBox Then
            Dim oTextBox As TextBox = CType(m_arrControl.Item(nIndex), TextBox)
            If oTextBox.Multiline = True Then
                Return -1
            End If
        End If

        If TypeOf (m_arrControl.Item(nIndex)) Is RichTextBox Then
            Dim oTextBox As RichTextBox = CType(m_arrControl.Item(nIndex), RichTextBox)
            If oTextBox.Multiline = True Then
                Return -1
            End If
        End If

        If TypeOf (m_arrControl.Item(nIndex + 1)) Is TextBox Then
            Dim oTextBox As TextBox = CType(m_arrControl.Item(nIndex + 1), TextBox)
            If oTextBox.ReadOnly = True Then
                Return GetNext(nIndex + 1)
            End If
        End If

        Dim oCtl As Control = CType(m_arrControl.Item(nIndex + 1), Control)
        If oCtl.Enabled = False OrElse oCtl.Visible = False Then
            Return GetNext(nIndex + 1)
        End If

        Return nIndex + 1

    End Function
End Class
