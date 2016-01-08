
'********************************************************************
'	Title:			OutputDetailView
'	Author:			FB
'	Create Date:	2009-4-1  
'	Description:    Output view support inherits from Listview
'*********************************************************************/

Imports System.Windows.Forms
Imports System.Drawing
Imports ITSBase

Public Class OutputDetailView
    Inherits System.Windows.Forms.ListView
    Private m_oListView As ListView
    Private m_FontCommon As Font
    Private m_FontBold As Font
    Public Sub New()

        MyBase.New()
        m_oListView = Me
        'm_oImageList = oImageList
        m_FontCommon = New System.Drawing.Font("SimSun", 14.25!, _
                                                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, _
                                                 CType(134, Byte))

        m_FontBold = New System.Drawing.Font("SimSun", 14.25!, _
                                                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, _
                                                CType(134, Byte))

        m_oListView.View = View.Details
        m_oListView.LabelEdit = False
        m_oListView.CheckBoxes = False
        m_oListView.FullRowSelect = False
        m_oListView.GridLines = False
        m_oListView.Sorting = SortOrder.None
        m_oListView.HeaderStyle = ColumnHeaderStyle.None
        m_oListView.BorderStyle = BorderStyle.FixedSingle
        m_oListView.Activation = ItemActivation.TwoClick

        ' Create columns for the items and subitems.
        m_oListView.Columns.Add("", -1, HorizontalAlignment.Left)
        m_oListView.Columns.Add("information", -1, HorizontalAlignment.Left)

    End Sub
    Public Sub AddNewLine(ByVal eOutputTag As OUTPUT_TAG, ByVal strMessage As String)

        'added by FB on 2009/4/1 Clear all the information 
        If eOutputTag = EnumDef.OUTPUT_TAG.CLEAR Then
            m_oListView.Items.Clear()
            Exit Sub
        End If

        ' Create three items and three sets of subitems for each item.
        Dim oItem As New ListViewItem("")
        oItem.Font = m_FontBold
        oItem.SubItems.Add(strMessage)

        'Add the items to the ListView.
        m_oListView.Items.Add(oItem)
        m_oListView.Items(m_oListView.Items.Count - 1).EnsureVisible()

    End Sub
    Private Sub OnListViewResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        m_oListView.Columns.Item(0).Width = 0
        'Vertical Scroll width is 20
        m_oListView.Columns.Item(1).Width = MyBase.Width - 20
    End Sub
End Class
