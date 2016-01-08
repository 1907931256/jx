'********************************************************************
'	Title:			outputDispatchView
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-6-1
'	Description:    
'*********************************************************************
Option Explicit On 
Option Strict On

Imports System.Windows.Forms
Imports System.Drawing
Imports ITSBase

Public Class OutputDispatchView
    Inherits System.Windows.Forms.ListView
    Private m_oListView As ListView

    Public Sub New()

        MyBase.New()
        m_oListView = Me

        m_oListView.View = View.Details
        m_oListView.LabelEdit = False
        m_oListView.CheckBoxes = False
        m_oListView.FullRowSelect = True
        m_oListView.GridLines = False
        m_oListView.Sorting = SortOrder.None
        m_oListView.HeaderStyle = ColumnHeaderStyle.None
        m_oListView.BorderStyle = BorderStyle.FixedSingle
        m_oListView.Activation = ItemActivation.TwoClick
        m_oListView.MultiSelect = False

        ' Create columns for the items and subitems.
        m_oListView.Columns.Add("information", -1, HorizontalAlignment.Left)

    End Sub
    Public Sub AddNewLine(ByVal eOutputTag As OUTPUT_TAG, ByVal strMessage As String)
        m_oListView.Columns.Item(0).Width = MyBase.Width
        If eOutputTag = EnumDef.OUTPUT_TAG.CLEAR Then
            m_oListView.Items.Clear()
            Exit Sub
        End If

        ' Create three items and three sets of subitems for each item.
        Dim oItem As New ListViewItem(strMessage)

        If eOutputTag = EnumDef.OUTPUT_TAG.INFOERROR Then
            oItem.ForeColor = Color.Red
        End If

        ''Add the items to the ListView.

        m_oListView.Items.Add(oItem)
        m_oListView.Items(m_oListView.Items.Count - 1).EnsureVisible()
        ChangeListViewWidth()
    End Sub

    Public Sub Remove(ByVal strMessage As String)
        If strMessage = String.Empty OrElse m_oListView.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To m_oListView.Items.Count - 1
            If strMessage = m_oListView.Items(i).SubItems(0).Text Then
                m_oListView.Items.RemoveAt(i)
                Exit For
            End If
        Next
        ChangeListViewWidth()
    End Sub
    Private Sub ChangeListViewWidth()
        If m_oListView.Items.Count > 0 Then
            If Not m_oListView.Items.Item(0) Is Nothing Then
                Dim fHeight As Single = m_oListView.Items.Item(0).Bounds.Height * (m_oListView.Items.Count + 1)
                If fHeight > m_oListView.Height Then
                    m_oListView.Columns.Item(0).Width = MyBase.Width - 20
                End If
            End If
        End If
        m_oListView.Refresh()
    End Sub
End Class
