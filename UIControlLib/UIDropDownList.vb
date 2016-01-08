Imports System.Windows.Forms
Imports ITSBase
Public Class UIDropDownList
    Public Enum SNAP_MODE As Short
        OnLeft = 1
        OnRight = 2
    End Enum
#Region " Component Designer generated code "
    WithEvents m_lvDropDown As ListView
    WithEvents m_frmShow As Form
    Private m_bFirstGotFocus As Boolean
    Private m_dtblSource As DataTable
    Private m_nVisibleRowCount As Integer 'Default visible row number is 5
    Private m_nContentIDNo As Integer
    Private m_nCodeColumnNo As Integer  'Default  Column No of the table "m_dtblSource"  to be show in the listview's first column
    Private m_nContentColNo As Integer  ' Default Column No of the Table "m_dtblSource" to be show in the  Listview's Second column
    Private m_strType As String
    Private m_strIDContent As String
    Private m_strDisplay As String
    Private m_ArrColWidth As Array
    Private m_ArrColVisible As Array
    Private m_nTypeIndex As Integer = 0
    Private m_nDisplayIndex As Integer = 1
    Private m_nIDIndex As Integer = 2
    Private m_bDisableTextChange As Boolean = False
    Private m_ptPoint As Drawing.Point
    Private m_nOnLeft As SNAP_MODE = SNAP_MODE.OnLeft

    Public Event RequireUpdateTable()
    Public Event PressEnter() '控件键入回车键后执行的操作
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        m_nCodeColumnNo = 0
        m_nContentColNo = 1
        m_nContentIDNo = 2
        m_nVisibleRowCount = 10
        m_bFirstGotFocus = False

        m_frmShow = New Form
        m_lvDropDown = New ListView

        m_strType = ""
        m_strIDContent = ""
        m_strDisplay = ""
        'Add any initialization after the InitializeComponent() call

    End Sub

#End Region
    Property ColNoOfCode() As Integer
        Get
            ColNoOfCode = m_nCodeColumnNo
        End Get
        Set(ByVal Value As Integer)
            m_nCodeColumnNo = Value
        End Set
    End Property
    ReadOnly Property TypeCode() As String
        Get
            TypeCode = m_strType
        End Get
    End Property

    WriteOnly Property TypeIndex() As Integer
        Set(ByVal Value As Integer)
            m_nTypeIndex = Value
        End Set
    End Property

    WriteOnly Property DisplayIndex() As Integer
        Set(ByVal Value As Integer)
            m_nDisplayIndex = Value
        End Set
    End Property

    WriteOnly Property IDIndex() As Integer
        Set(ByVal Value As Integer)
            m_nIDIndex = Value
        End Set
    End Property

    Property IDContent() As String
        Get
            IDContent = m_strIDContent
        End Get
        Set(ByVal Value As String)
            m_strIDContent = Value
        End Set
    End Property
    Property DisplayContent() As String
        Get
            Return m_strDisplay
        End Get
        Set(ByVal Value As String)
            m_strDisplay = Value
        End Set
    End Property
    Property ColNoOfContent() As Integer
        Get
            ColNoOfContent = m_nContentColNo
        End Get
        Set(ByVal Value As Integer)

            m_nContentColNo = Value
        End Set
    End Property
    Property ContentID() As Integer
        Get
            ContentID = m_nContentIDNo
        End Get
        Set(ByVal Value As Integer)
            m_nContentIDNo = Value
        End Set
    End Property
    Property VisibleRowCount() As Integer
        Get
            VisibleRowCount = m_nVisibleRowCount
        End Get
        Set(ByVal Value As Integer)
            m_nVisibleRowCount = Value
        End Set
    End Property
    Property OnLeft() As SNAP_MODE
        Get
            OnLeft = m_nOnLeft
        End Get
        Set(ByVal Value As SNAP_MODE)
            m_nOnLeft = Value
        End Set
    End Property
    WriteOnly Property ColumnWidthCollection() As Array
        Set(ByVal Value As Array)
            m_ArrColWidth = Value
        End Set
    End Property

    WriteOnly Property VisibleColumnCollection() As Array
        Set(ByVal Value As Array)
            m_ArrColVisible = Value
        End Set
    End Property

    ReadOnly Property SelectIndics() As ListView.SelectedIndexCollection
        Get
            If Not Me.m_lvDropDown Is Nothing Then
                Return m_lvDropDown.SelectedIndices
            End If
            Return Nothing
        End Get
    End Property

    Public Sub Attach(ByRef txtXL As TextBox, Optional ByVal dtResource As DataTable = Nothing)
        If dtResource Is Nothing Then
            If Not m_dtblSource Is Nothing Then m_dtblSource.Clear()
            Exit Sub
        ElseIf dtResource.Rows.Count <= 0 Then
            If Not m_dtblSource Is Nothing Then m_dtblSource.Clear()
        Else
            ClearListView()
            'm_lvDropDown = lvDropDown
        End If


        Dim nCol, nRow As Integer
        m_dtblSource = New DataTable("DropDown")
        For nCol = 0 To (dtResource.Columns.Count - 1)
            m_dtblSource.Columns.Add("col" & nCol.ToString, System.Type.GetType("System.String"))
        Next
        For nRow = 0 To (dtResource.Rows.Count - 1)
            Dim dbRow As DataRow
            dbRow = m_dtblSource.NewRow
            For nCol = 0 To (dtResource.Columns.Count - 1)
                If IsDBNull(dtResource.Rows(nRow).Item(nCol)) Then
                    dbRow.Item(nCol) = ""
                Else
                    dbRow.Item(nCol) = dtResource.Rows(nRow).Item(nCol)
                End If
            Next
            m_dtblSource.Rows.Add(dbRow)
        Next

        With m_lvDropDown
            .TabStop = False
            .View = View.Details
            .GridLines = True
            .HeaderStyle = ColumnHeaderStyle.None
            .BorderStyle = BorderStyle.FixedSingle
            .Visible = False
            .FullRowSelect = True
            .Font = Me.Font
            .MultiSelect = False
        End With

    End Sub

    'Show the Data Filtered by TextBox's Text
    Private Sub ShowFilteredData()
        If m_lvDropDown Is Nothing OrElse m_dtblSource Is Nothing Then
            Exit Sub
        End If
        If m_dtblSource.Rows.Count <= 0 Then
            m_lvDropDown.Clear()
            m_lvDropDown.Visible = False
            m_frmShow.Visible = False
            Exit Sub
        End If

        Dim strtxt As String = MyBase.Text.ToString

        Dim dv_Intermediate As New DataView(m_dtblSource)
        Dim nScrollBar As Integer = 0
        Dim nHeight As Integer = m_nVisibleRowCount
        strtxt = MakeSQLLIKEPattern(strtxt)

        If strtxt = "" Or strtxt Is Nothing Then
            m_lvDropDown.Visible = False
            m_frmShow.Visible = False
            Return
        End If
        With dv_Intermediate
            .AllowNew = False
            If dv_Intermediate.Table.Columns.Count > 0 Then
                .RowFilter = String.Format("{0} like '{1}%'", m_dtblSource.Columns(m_nCodeColumnNo).ColumnName, strtxt)
            End If
        End With

        Dim nRowIndex As Integer = 0
        m_lvDropDown.Clear()

        Dim nTitleWidth As Integer = 0
        With m_lvDropDown
            Dim nCount As Integer = 0
            If Not m_ArrColWidth Is Nothing Then
                For Each nWidth As Integer In m_ArrColWidth
                    nCount += 1
                    .Columns.Add(nCount.ToString, nWidth, HorizontalAlignment.Left)
                    nTitleWidth += nWidth
                Next
            End If
        End With
        For nRowIndex = 0 To (dv_Intermediate.Count - 1)
            Dim dr_DataView As DataRow
            dr_DataView = dv_Intermediate.Item(nRowIndex).Row

            'Modify by yxh at 05/11/23
            If Not m_ArrColVisible Is Nothing Then
                Dim strlvitem(m_ArrColVisible.Length - 1) As String
                Dim nIndex As Integer = 0
                For Each nValue As Integer In m_ArrColVisible
                    strlvitem(nIndex) = CType(dr_DataView.Item(nValue), String).Trim
                    nIndex += 1
                Next
                Dim item_ListView As New ListViewItem(strlvitem)
                m_lvDropDown.Items.Add(item_ListView)
            Else
                Dim strlvitem(dv_Intermediate.Table.Columns.Count - 1) As String
                For nIndex As Integer = 0 To dv_Intermediate.Table.Columns.Count - 1
                    strlvitem(nIndex) = CType(dr_DataView.Item(nIndex), String).Trim
                Next
                Dim item_ListView As New ListViewItem(strlvitem)
                m_lvDropDown.Items.Add(item_ListView)
            End If
        Next

        If (dv_Intermediate.Count > m_nVisibleRowCount) Then
            nScrollBar = 1
            nHeight = m_nVisibleRowCount
        Else
            nHeight = dv_Intermediate.Count
        End If

        If (dv_Intermediate.Count > 0) Then
            m_lvDropDown.Width = nTitleWidth + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth * nScrollBar + System.Windows.Forms.SystemInformation.BorderSize.Width * 2
            If m_lvDropDown.Items.Count > 0 Then
                m_lvDropDown.Height = m_lvDropDown.Items.Item(0).Bounds.Height * nHeight + System.Windows.Forms.SystemInformation.BorderSize.Width * 2
            Else
                m_lvDropDown.Height = 0
            End If
            m_lvDropDown.Visible = True

            Dim ptPoint As Drawing.Point = m_ptPoint
            If m_nOnLeft = SNAP_MODE.OnRight Then
                ptPoint.X = ptPoint.X + Me.Width - m_lvDropDown.Width
            End If
            ptPoint = PointToScreen(ptPoint)
            '控制窗体，防止窗体右边界超出。
            If ptPoint.X + m_lvDropDown.Width > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                ptPoint.X = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - m_lvDropDown.Width - 2
            End If
            With m_frmShow
                .FormBorderStyle = FormBorderStyle.None
                .BackColor = Drawing.Color.White
                .Size = m_lvDropDown.Size
                .ShowInTaskbar = False
                .StartPosition = FormStartPosition.Manual
                .Location = ptPoint
                .Controls.Add(m_lvDropDown)
                .TopMost = True
            End With
            m_frmShow.Show()

        Else
            m_lvDropDown.Visible = False
            m_frmShow.Visible = False
        End If

    End Sub

    Private Sub ClearListView()
        If Not Me.m_lvDropDown Is Nothing Then
            Me.m_lvDropDown.Clear()
        End If
    End Sub

    Private Sub UIDropDownList_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        m_frmShow.Dispose()
    End Sub

    'when Textbox lost input cursor,DropDown listview is set to visible
    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        If (m_dtblSource Is Nothing) Then Return
        If Not m_lvDropDown Is Nothing Then
            m_lvDropDown.Visible = False
            m_frmShow.Visible = False
        End If
        m_bFirstGotFocus = False
    End Sub

    Public Function ValidateText() As Boolean
        If Me.Text <> Me.m_strDisplay Then
            Me.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    'when mouse first down in TextBox,Select All text in the TextBox
    Private Sub TextBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        If (m_dtblSource Is Nothing) Then Return
        'Because Mouse Click will remove the text selection,
        'here force to trigger selectall event by bFirstGotFocus flag.
        If m_bFirstGotFocus = True Then
            Me.SelectAll()
        End If
        m_bFirstGotFocus = False
    End Sub
    'when textbox get focus,show the dropdown listview.
    Private Sub TextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        If MyBase.Text.Length >= 0 Then
            m_ptPoint.X = 0
            m_ptPoint.Y = MyBase.Height + 3
        End If
        If (m_dtblSource Is Nothing) Then Return
        m_bFirstGotFocus = True

    End Sub
    'When textbox input Key Down,Select the dropdown listview's first row.
    'and If the Key is Enter,send focus to the next control
    'When TextBox's Text changed,reshow the listview.
    Private Sub TextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (m_dtblSource Is Nothing) Then
            If e.KeyCode = Keys.Enter Then
                RaiseEvent PressEnter()
            End If
            Return
        End If
        If (e.KeyCode = Keys.Down) Then
            If Not m_lvDropDown Is Nothing AndAlso (m_lvDropDown.Items.Count > 0) Then
                m_lvDropDown.Focus()
                If m_lvDropDown.SelectedIndices.Count <= 0 Then
                    m_lvDropDown.Items.Item(0).Selected = True
                End If
                m_lvDropDown.Select()
            End If
        ElseIf (e.KeyCode = Keys.Enter) Then
            If Not m_lvDropDown Is Nothing Then
                'if the current selection is null, but the listview has the items. choose the first item as its selection.
                If Me.m_lvDropDown.SelectedIndices.Count = 0 AndAlso Me.m_lvDropDown.Items.Count > 0 Then
                    m_lvDropDown.Items(0).Selected = True 'select the first row
                    AfterSelect(Me.m_lvDropDown.SelectedItems(0), e.KeyCode)
                    'RaiseEvent PressEnter()
                Else
                    m_lvDropDown.Visible = False
                    m_frmShow.Visible = False
                    RaiseEvent PressEnter()
                End If
            End If
        ElseIf (e.KeyCode = Keys.Tab) Then 'Notise: here,TAB event message comes from previous control,NOT itself!
            'do nothing
        End If
    End Sub
    'under the circumstance of Listview has focused,input enter key will send selected item's text to TextBox 
    'and send focus to the next control
    Private Sub ListView_EnterKey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles m_lvDropDown.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                AfterSelect(Me.m_lvDropDown.SelectedItems(0))
        End Select
    End Sub
    Private Sub ListView_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_lvDropDown.MouseClick
        If m_lvDropDown.GetItemAt(e.X, e.Y) Is Nothing Then
        Else
            AfterSelect(m_lvDropDown.GetItemAt(e.X, e.Y))
        End If
    End Sub

    Private Sub ListView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_lvDropDown.Leave
        m_lvDropDown.Visible = False
        m_frmShow.Visible = False
    End Sub

    Private Sub ListView_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_lvDropDown.Enter
        m_lvDropDown.Visible = True
        m_frmShow.Visible = True
    End Sub

    Private Sub UserCtrlDropDown_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If MyBase.Focused AndAlso m_bDisableTextChange = False Then
            'UpdateDataTable()
            ShowFilteredData()
            MyBase.Focus()
        End If
    End Sub

    'The function is aimed to the ctrl which need update the datatable in the run-time
    Private Sub UpdateDataTable()
        RaiseEvent RequireUpdateTable()
    End Sub

    Private Sub UserCtlInpatDropDown_ReadOnlyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReadOnlyChanged
        If Me.ReadOnly Then
            Me.BackColor = System.Drawing.Color.Ivory
            Me.TabStop = False
        Else
            Me.BackColor = System.Drawing.SystemColors.Window
            Me.TabStop = True
        End If
    End Sub

    Public Function GetFirstSelListItem() As ListViewItem
        If m_lvDropDown Is Nothing Then
            Return Nothing
        End If

        If m_lvDropDown.SelectedItems.Count = 0 Then
            Return Nothing
        End If
        Return m_lvDropDown.SelectedItems.Item(0)
    End Function

    Private Sub AfterSelect(ByVal selItem As ListViewItem, Optional ByVal keys As System.Windows.Forms.Keys = Keys.A)
        If selItem Is Nothing OrElse selItem.SubItems.Count < 3 Then
            Return
        End If
        m_strType = selItem.SubItems(m_nTypeIndex).Text
        Me.m_strDisplay = selItem.SubItems(m_nDisplayIndex).Text
        Me.m_strIDContent = selItem.SubItems(m_nIDIndex).Text
        m_bDisableTextChange = True
        Me.Text = m_strDisplay
        m_bDisableTextChange = False
        Me.m_lvDropDown.Visible = False
        m_frmShow.Visible = False
        Me.SelectAll()
        RaiseEvent PressEnter()
        If keys <> Windows.Forms.Keys.Enter Then
            SendKeys.Send("{Enter}")
        End If
    End Sub

    Private Sub m_frmShow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_frmShow.Resize
        m_frmShow.Size = m_lvDropDown.Size
    End Sub

End Class
