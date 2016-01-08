
'********************************************************************
'	Title:			OutputView
'	Author:			FB
'	Create Date:	2009-3-22
'	Description:    Output view support different font forecolor icon
'                   for different information inherits from Listview
'*********************************************************************/

Imports System.Windows.Forms
Imports System.Drawing
Imports ITSBase

Public Class OutputView
    Inherits System.Windows.Forms.ListView
    Private m_oListView As ListView
    Private m_FontCommon As Font
    Private m_FontBold As Font
    Private m_oImageList As ImageList
    Private m_nCurLineIndex As Integer
    WriteOnly Property ImageList() As ImageList
        Set(ByVal Value As ImageList)
            m_oImageList = Value
            m_oListView.SmallImageList = m_oImageList
        End Set
    End Property
    Public Enum ICON_INDEX As Integer
        OPERATE = 0
        INFORMATION
        INFOERROR
    End Enum
    Public Sub New()

        MyBase.New()
        m_nCurLineIndex = 0
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
        m_oListView.Columns.Add("time", -1, HorizontalAlignment.Center)
        m_oListView.Columns.Add("information", -1, HorizontalAlignment.Left)

    End Sub
    Public Sub AddNewLine(ByVal eOutputTag As OUTPUT_TAG, ByVal strMessage As String)
        Dim nImageIndex As Integer
        Select Case eOutputTag
            Case EnumDef.OUTPUT_TAG.INFOERROR
                nImageIndex = ICON_INDEX.INFOERROR
            Case EnumDef.OUTPUT_TAG.INFORMATION
                nImageIndex = ICON_INDEX.INFORMATION
            Case EnumDef.OUTPUT_TAG.OPERATE
                nImageIndex = ICON_INDEX.OPERATE
        End Select

        ' Create three items and three sets of subitems for each item.
        Dim oItem As New ListViewItem("")

        Select Case eOutputTag
            Case EnumDef.OUTPUT_TAG.INFOERROR
                oItem.Font = m_FontBold
                oItem.ForeColor = Color.Red
                oItem.ImageIndex = ICON_INDEX.INFOERROR
                oItem.SubItems.Add("")
            Case EnumDef.OUTPUT_TAG.INFORMATION
                oItem.Font = m_FontBold
                oItem.ImageIndex = ICON_INDEX.INFORMATION
                oItem.SubItems.Add("")
            Case EnumDef.OUTPUT_TAG.OPERATE
                oItem.Font = m_FontBold
                oItem.ForeColor = Color.Blue
                oItem.ImageIndex = ICON_INDEX.OPERATE
                oItem.SubItems.Add(LocalData.ServerNow.ToString(TEXT_DATETIME_FORMATION_TIME_SECOND))
        End Select

        oItem.SubItems.Add(strMessage)

        'Add the items to the ListView.
        If eOutputTag = OUTPUT_TAG.OPERATE Then
            m_nCurLineIndex = 0
        Else
            If m_oListView.Items.Count = 0 Then
                m_nCurLineIndex = 0
            Else
                m_nCurLineIndex += 1
            End If
        End If

         m_oListView.Items.Insert(m_nCurLineIndex, oItem)

        'm_oListView.Items(m_oListView.Items.Count - 1).EnsureVisible()

    End Sub

    Private Sub OnListViewResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        m_oListView.Columns.Item(0).Width = 20
        m_oListView.Columns.Item(1).Width = 100
        'Vertical Scroll width is 20
        m_oListView.Columns.Item(2).Width = MyBase.Width - 20 - 100 - 20

    End Sub
End Class
