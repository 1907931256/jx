'the class now has two view style, one is the panel in which the buttons
'classify the different source of the data, which is outlook-style. 
' On the other hand, the other style is a datagridview with a search bar.
'remeber; this class should never used along, it is designed to embeded into others.
'fpf. 2009.08.27.

Imports System.Windows.Forms
Imports ITSBase
Imports System.Drawing

Public Class UIExpandPanel
    Const CONST_STRING_SEARCH_FITLER As String = "{0} LIKE '{1}*'"
    Const CONST_INT_MAX_SHOWN_BUTTON As Integer = 4
    Const CONST_INT_CTRL_MARGIN As Integer = 0.4
    Const CONST_DEFAULT_DATAGRIDVIEW_HEIGHT = 2
    Private Const CONST_TEXT_TOOL_BAR_REFRESH = "刷新"
    Private Const CONST_TEXT_TOOL_BAR_PRINT = "打印"
    Private Const CONST_TEXT_TOOL_BAR_PRINT_ALL = "打印全部"
    Private Const CONST_TEXT_TOOL_BAR_DISPATCH_STATISTIC = "待发放统计"
    Private m_aryButtons() As LabelEx 'Button control array
    Private m_oDataGridView As UIDataGridView 'DataGridView控件
    Private m_oDataSet As DataSet
    Private m_nDGVPreHeight As Integer 'DataGridView之前的高度
    Private m_nDGVPreWidth As Integer 'DataGridView之前的宽度
    Public Event DataGridViewSelChanged(ByVal sender As UIControlLib.UIDataGridView)
    Public Event SubItemClicked(ByVal sender As UIExpandPanel, ByVal strBindTableName As String)
    Public Event SubItemSwitch(ByVal sender As UIExpandPanel, ByVal strOldSubItemName As String, ByVal strNewSubItemName As String)
    Public Event DataGridViewCellClick(ByVal sender As UIDataGridView)
    Public Event DataGridViewCellDoubleClick(ByVal sender As UIDataGridView)
    Public Event DoRefresh()
    Public Event DoCurrentPrint()
    Public Event DoPrintAll()
    Public Event DoDispatchStatistic()
    Private m_CurSelBtn As LabelEx = Nothing 'Standard样式时，当前选择的btn
    Private m_bInnateBehavior As Boolean = True
    Private m_btnToolbar As LabelEx
    Private m_nIndexFirstBtnShow As Integer = 0
    Private m_MenuContext As ContextMenu
    Private m_emStyle As EXPAND_PANEL_TYPE = EXPAND_PANEL_TYPE.STANDARD
    Private m_bInitSelChange As Boolean = False '表示初始选择条目是否效果
    Private m_dtDepartment As DataTable
    Private m_bDataBindOver As Boolean = False
    Private m_bNotRecieveBindOver As Boolean = True '当表内容没有变化，DataBindComplete不会收到

    Public Sub New()
        Me.InitializeComponent()
        m_oDataSet = New DataSet
        m_aryButtons = New LabelEx() {}
        Me.m_oDataGridView = New UIDataGridView
        Me.m_oDataGridView.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_oDataGridView.BorderStyle = Windows.Forms.BorderStyle.None
        Me.m_oDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(255, 250, 240)
        Me.m_oDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Me.m_oDataGridView.ColumnHeadersVisible = False
        Me.m_oDataGridView.Visible = False
        Me.m_oDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Me.m_oDataGridView.BackgroundColor
        Me.m_oDataGridView.RowsDefaultCellStyle.BackColor = Me.m_oDataGridView.BackgroundColor
        Me.m_oDataGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        AddHandler m_oDataGridView.CurrentRowIndexChanged, AddressOf OnDataGridViewSelectionChanged
        AddHandler m_oDataGridView.CellClick, AddressOf OnUIDataGridViewCellClick
        AddHandler m_oDataGridView.CellDoubleClick, AddressOf OnUIDataGridViewCellDoubleClick
        AddHandler m_oDataGridView.SizeChanged, AddressOf OnUIDataGridViewSizeChanged
        AddHandler m_oDataGridView.InitSelRowIndexEffected, AddressOf OnInitSelRowIndexEffected
        AddHandler m_oDataGridView.DataBindingOver, AddressOf OnDataBindingOver
    End Sub

    Private Function IsSearchBarStyle() As Boolean
        Return m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_FILTER OrElse m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT
    End Function

    Public Sub SetDepartment(ByVal dtDep As DataTable)
        m_dtDepartment = dtDep
    End Sub

    Public Sub SetSearchCaption(ByVal strSearchCaption As String)
        Me.lblSearchSec.Text = strSearchCaption
    End Sub
    '依据DataSet控件内容，重新初始化
    Public Sub SetDataSet(ByVal oDataSet As DataSet, ByVal emStyle As EXPAND_PANEL_TYPE)
        m_oDataSet = oDataSet
        m_emStyle = emStyle
        Me.m_oDataGridView.Visible = True
        m_nDGVPreHeight = m_oDataGridView.Height
        m_oDataGridView.Left = 2 * CONST_INT_CTRL_MARGIN
        m_oDataGridView.Width = Me.Width - 4 * CONST_INT_CTRL_MARGIN
        m_nDGVPreWidth = m_oDataGridView.Width
        If (emStyle = EXPAND_PANEL_TYPE.STANDARD) Then
            CreateStandardStyle()
        ElseIf IsSearchBarStyle() Then
            CreateSearchBarStyle()
        End If
    End Sub

    Public Sub UpdateDataSet(ByVal oDataSet As DataSet, ByVal emStyle As EXPAND_PANEL_TYPE)
        SetDataSet(oDataSet, emStyle)
        If (emStyle <> EXPAND_PANEL_TYPE.STANDARD) Then
            Return
        End If
        If Not String.IsNullOrEmpty(m_CurSelBtn.Text) Then
            Dim n As Integer = 0
            Dim bFound As Boolean = False
            For Each btn As LabelEx In m_aryButtons
                If btn.Text = m_CurSelBtn.Text Then
                    bFound = True
                    Exit For
                Else
                    n += 1
                End If
            Next
            If bFound Then
                m_bInnateBehavior = False
                OnBtnClick(m_aryButtons(n), EventArgs.Empty)
                m_bInnateBehavior = True
            End If
        End If
    End Sub

    Private Sub CreateStandardStyle()
        Me.pnlSearchBarContainer.Visible = False
        If pnlSearchBarContainer.Controls.Contains(m_oDataGridView) Then
            pnlSearchBarContainer.Controls.Remove(m_oDataGridView)
        End If
        If Not Me.Controls.Contains(m_oDataGridView) Then
            Me.Controls.Add(m_oDataGridView)
            Me.m_oDataGridView.Dock = DockStyle.None
        End If
        SetButtons()
        CreateToolBar(Me)
        If m_aryButtons.Length() > 0 Then
            m_bInnateBehavior = False
            m_aryButtons(0).PerformClick() 'initial show the first button's content
            m_bInnateBehavior = True
        End If
    End Sub

    Private Sub CreateSearchBarStyle()
        Me.pnlSearchBarContainer.Visible = True
        If Me.Controls.Contains(m_oDataGridView) Then
            Me.Controls.Remove(m_oDataGridView)
        End If
        If Not pnlDataGridView.Controls.Contains(m_oDataGridView) Then
            pnlDataGridView.Controls.Add(m_oDataGridView)
            Me.m_oDataGridView.Dock = DockStyle.Fill
        End If
        If m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_FILTER Then
            CreateToolBar(pnlSearchBarContainer)
        End If
        InitialDepatrment()
        If Me.m_oDataSet.Tables.Count > 0 Then
            If m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_FILTER Then
                BindFilterTable()
            ElseIf m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT Then
                BindHighLightTable(m_oDataSet.Tables(0))
            End If
        End If
    End Sub

    Private Sub InitialDepatrment()
        Dim nArrWidth() As Short
        nArrWidth = New Short() {120, 200, 0} 'listview's width
        txtDP.ColNoOfCode = 0
        txtDP.IDIndex = 2
        With txtDP
            .DisplayIndex = 1
            .ColumnWidthCollection = nArrWidth
            .Attach(CType(txtDP, TextBox), m_dtDepartment)
        End With
    End Sub

    '编写者：wxy，创建时间20090731
    '功能：初始化Button子控件
    '返回值：无
    '备注：
    '第一步，将Button子控件从父控件中移除；
    '第二步，重新定义Button数组并初始化；
    '第三步，将Button控件添加到父控件中。
    Private Sub SetButtons()
        RemoveButtons()
        Dim nAmount As Integer = m_oDataSet.Tables.Count()
        If nAmount > 0 Then
            '当DataSet中存在表时
            ReDim m_aryButtons(nAmount - 1)
            Dim nIndex As Integer
            For nIndex = 0 To nAmount - 1
                'Create  Button object and initialize the Button
                m_aryButtons(nIndex) = New LabelEx(True)
                m_aryButtons(nIndex).Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                m_aryButtons(nIndex).Text = m_oDataSet.Tables(nIndex).TableName
                m_aryButtons(nIndex).Left = CONST_INT_CTRL_MARGIN
                m_aryButtons(nIndex).Width = Me.Width - 2 * CONST_INT_CTRL_MARGIN
                m_aryButtons(nIndex).Font = New System.Drawing.Font("SimSun", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Next
        End If
        AddButtons()
    End Sub

    '编写者：wxy，创建时间20090731
    '功能：将DataSet内容通过DataGridView显示
    '返回值：无
    Private Sub OnBtnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oCurTickBtn As LabelEx = CType(sender, LabelEx)
        If oCurTickBtn Is Nothing Then
            Return
        End If
        Dim preBtnText As String = ""
        If Not m_CurSelBtn Is Nothing Then preBtnText = m_CurSelBtn.Text
        Dim bRaiseSwitch As Boolean = m_bInnateBehavior AndAlso m_CurSelBtn IsNot oCurTickBtn
        m_CurSelBtn = oCurTickBtn
        If m_bInnateBehavior Then
            RaiseEvent SubItemClicked(Me, oCurTickBtn.Text)
        End If

        For Each btn As LabelEx In m_aryButtons
            If btn Is m_CurSelBtn Then
                btn.BtnPerformClick()
            Else
                btn.BtnPerformUnClick()
            End If
        Next

        If bRaiseSwitch Then
            RaiseEvent SubItemSwitch(Me, preBtnText, oCurTickBtn.Text)
        End If

        'get the specified table 
        Dim dtTable As DataTable = Me.m_oDataSet.Tables.Item(oCurTickBtn.Text)
        If dtTable Is Nothing Then
            Me.m_oDataGridView.Columns.Clear() 'clear the datagridview first
            Return
        End If

        ''if current table is the table, return
        'Dim dtCurTable As DataTable = CType(Me.m_oDataGridView.DataSource, DataTable)
        'If m_bInnateBehavior AndAlso dtCurTable Is dtTable Then
        '    Return
        'End If
        AdjustCtrlsPosition(sender)
        BindingTable(dtTable)
    End Sub

    '编写者：wxy，创建时间20090728
    '功能：将Button子控件从父控件中移除
    '返回值：无
    '备注：遍历Button控件，移出该控件
    Private Sub RemoveButtons()
        Dim nIndex As Integer, nCount As Integer = m_aryButtons.Length
        For nIndex = 0 To nCount - 1
            RemoveHandler m_aryButtons(nIndex).Click, AddressOf OnBtnClick
            Me.Controls.Remove(m_aryButtons(nIndex))
        Next
    End Sub

    '编写者：wxy，创建时间20090731
    '功能：将Button子控件加入父控件
    '返回值：无
    '备注：遍历Button控件，加入父控件
    Private Sub AddButtons()
        Dim nIndex As Integer, nCount As Integer = m_aryButtons.Length
        For nIndex = 0 To nCount - 1
            AddHandler m_aryButtons(nIndex).Click, AddressOf OnBtnClick
            Me.Controls.Add(m_aryButtons(nIndex))
        Next
    End Sub

    '编写者：wxy，创建时间20090730
    '功能：设置子控件的位置值
    '返回值：无
    '备注：设子ListView、Button子控件的位置，用于事件绑定
    Private Sub AdjustCtrlsPosition(ByVal sender As System.Object)
        Dim oBtn As LabelEx = CType(sender, LabelEx)
        Dim nBtnHeight As Integer = oBtn.Height
        Dim nStartPos As Integer = 0
        Debug.Assert(Me.m_nIndexFirstBtnShow < Me.m_aryButtons.Length)
        If Me.m_nIndexFirstBtnShow >= Me.m_aryButtons.Length Then
            Return
        End If
        For Each btn As LabelEx In m_aryButtons
            btn.Visible = False
        Next
        'the last row is toolbar
        Dim nHeight As Integer = Me.Height - Me.m_btnToolbar.Height - CONST_INT_CTRL_MARGIN
        Dim nLength As Integer = IIf(m_aryButtons.Length - m_nIndexFirstBtnShow > CONST_INT_MAX_SHOWN_BUTTON, CONST_INT_MAX_SHOWN_BUTTON, m_aryButtons.Length - m_nIndexFirstBtnShow)
        For i As Integer = m_nIndexFirstBtnShow To m_nIndexFirstBtnShow + nLength - 1
            Dim btnLoop As LabelEx = m_aryButtons(i)
            Dim nCurHeight As Integer = nStartPos + btnLoop.Height + CONST_INT_CTRL_MARGIN
            If nCurHeight > nHeight Then
                Exit For 'if the height is exceed the total height, exit.
            End If
            btnLoop.Top = nStartPos
            btnLoop.Visible = True
            nStartPos = nCurHeight
            If btnLoop Is oBtn Then 'if the btn is the clicked buttton, then add the gridview
                Dim nDGVHeight As Integer = nHeight - nLength * (nBtnHeight + CONST_INT_CTRL_MARGIN)
                If nDGVHeight < 0 Then
                    nDGVHeight = CONST_DEFAULT_DATAGRIDVIEW_HEIGHT
                End If
                Me.m_oDataGridView.Top = nStartPos
                Me.m_oDataGridView.Height = nDGVHeight
                nStartPos += nDGVHeight + CONST_INT_CTRL_MARGIN
            End If
        Next
        'add the last row
        Me.m_btnToolbar.Top = Me.Height - CONST_INT_CTRL_MARGIN - Me.m_btnToolbar.Height
    End Sub

    Private Sub OnPanelResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.m_oDataGridView Is Nothing OrElse Me.m_oDataGridView.DataSource Is Nothing Then
            Return
        End If
        If m_emStyle = EXPAND_PANEL_TYPE.STANDARD Then
            ResizeForStandardStyle()
        ElseIf IsSearchBarStyle() Then
            ResizeForSearchBarStyle()
        End If
    End Sub

    Private Sub ResizeForStandardStyle()
        If m_emStyle <> EXPAND_PANEL_TYPE.STANDARD Then
            Return
        End If
        If m_aryButtons Is Nothing OrElse m_aryButtons.Length = 0 Then
            Return
        End If
        If m_nDGVPreHeight = Me.Height Then
            Return
        Else
            m_nDGVPreHeight = Me.Height
        End If
        Dim iIndex As Integer = Me.m_oDataSet.Tables.IndexOf(CType(Me.m_oDataGridView.DataSource, DataTable))
        If iIndex >= 0 AndAlso iIndex < m_aryButtons.Length Then
            AdjustCtrlsPosition(m_aryButtons(iIndex))
        End If
    End Sub

    Private Sub ResizeForSearchBarStyle()
        If Not IsSearchBarStyle() Then
            Return
        End If
        If Not m_btnToolbar Is Nothing Then
            Me.m_btnToolbar.Top = Me.pnlSearchBarContainer.Height - CONST_INT_CTRL_MARGIN - Me.m_btnToolbar.Height
            Me.pnlDataGridView.Height = Me.pnlSearchBarContainer.Height - (CONST_INT_CTRL_MARGIN + Me.m_btnToolbar.Height) _
                                                                    - (Me.pnlHead.Height + CONST_INT_CTRL_MARGIN)
        Else
            Me.pnlDataGridView.Height = Me.pnlSearchBarContainer.Height - CONST_INT_CTRL_MARGIN _
                                                                               - (Me.pnlHead.Height + CONST_INT_CTRL_MARGIN)
        End If
        
    End Sub

    Private Sub BindingTable(ByRef dt As DataTable)
        SyncLock dt
            Debug.Assert(TypeOf dt Is UIExpandPanelDataTable)
            If Not (TypeOf dt Is UIExpandPanelDataTable) Then Return
            Dim expandDatatable As UIExpandPanelDataTable = CType(dt, UIExpandPanelDataTable)
            Me.m_oDataGridView.ClearBoolColumn()
            Me.m_oDataGridView.ClearFormatColumn()
            Me.m_oDataGridView.ClearMarkableColumn()
            If expandDatatable.ColumnWidthCollection IsNot Nothing Then
                Me.m_oDataGridView.ColumnWidthCollection = expandDatatable.ColumnWidthCollection
            Else
                Debug.Assert(False)
            End If
            If Not String.IsNullOrEmpty(expandDatatable.MarkableColumn) Then
                Me.m_oDataGridView.SetMarkableColumn(expandDatatable.MarkableColumn)
            End If
            m_bDataBindOver = False
            Me.m_oDataGridView.DataSource = dt
            If m_bNotRecieveBindOver Then
                m_bDataBindOver = True
            End If
            m_bNotRecieveBindOver = True
            Me.m_oDataGridView.InitSelRowIndex = -1
        End SyncLock
    End Sub

    Private Sub BindingTable(ByRef dt As DataTable, ByVal dtExpand As UIExpandPanelDataTable)
        SyncLock dt
            Me.m_oDataGridView.ClearBoolColumn()
            Me.m_oDataGridView.ClearFormatColumn()
            Me.m_oDataGridView.ClearMarkableColumn()
            If Not dtExpand Is Nothing AndAlso Not dtExpand.ColumnWidthCollection Is Nothing Then
                Me.m_oDataGridView.ColumnWidthCollection = dtExpand.ColumnWidthCollection
            End If
            If Not dtExpand Is Nothing AndAlso Not String.IsNullOrEmpty(dtExpand.MarkableColumn) Then
                Me.m_oDataGridView.SetMarkableColumn(dtExpand.MarkableColumn)
            End If
            m_bDataBindOver = False
            Me.m_oDataGridView.DataSource = dt
            If m_bNotRecieveBindOver Then
                m_bDataBindOver = True
            End If
            m_bNotRecieveBindOver = True
            Me.m_oDataGridView.InitSelRowIndex = -1
        End SyncLock
    End Sub

    Private Sub BindFilterTable()
        Debug.Assert(m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_FILTER)
        If m_emStyle <> EXPAND_PANEL_TYPE.SEARCHBAR_FILTER Then Return
        If m_oDataSet.Tables.Count <= 0 Then Return
        If m_oDataGridView Is Nothing Then Return
        'get the first column name which will show in the datagridview
        Dim dtFirst As DataTable = Me.m_oDataSet.Tables(0)
        Dim bFind As Boolean = False : Dim i As Integer = 0
        For i = 0 To CType(dtFirst, UIExpandPanelDataTable).ColumnWidthCollection.Length - 1
            If CType(dtFirst, UIExpandPanelDataTable).ColumnWidthCollection(i) <> 0 Then
                bFind = True
                Exit For
            End If
        Next
        If Not bFind Then Return
        Dim strFilter As String = String.Format(CONST_STRING_SEARCH_FITLER, dtFirst.Columns(i).ColumnName, Me.txtDP.Text.Trim)
        Dim dv As DataView = m_oDataSet.Tables(0).DefaultView
        dv.RowFilter = strFilter
        BindingTable(dv.ToTable, CType(dtFirst, UIExpandPanelDataTable))
    End Sub

    Private Sub BindHighLightTable(ByRef dt As DataTable)
        BindingTable(dt)
        HighLightItem()
    End Sub

    Private Sub HighLightItem()
        Debug.Assert(m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT)
        If m_emStyle <> EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT Then Return
        If Me.m_oDataGridView Is Nothing Then Return
        If Not String.IsNullOrEmpty(Me.txtDP.Text) Then
            'For Each row As DataGridViewRow In m_oDataGridView.SelectedRows
            '    row.Selected = False 'first, unsel all
            'Next
            For Each row As DataGridViewRow In m_oDataGridView.Rows
                If row.Cells.Count > 0 Then
                    If row.Cells.Item(0).Value Like Me.txtDP.Text + "*" Then
                        Dim oCurrentCell As DataGridViewCell = Me.m_oDataGridView.CurrentCell
                        'this sentense will raise selection change, but  CurrentDataRow is not updated until CurrentCell is set
                        Me.m_oDataGridView.CurrentCell = Me.m_oDataGridView.Item(0, row.Index)
                        row.Selected = True
                        'If oCurrentCell Is Nothing OrElse oCurrentCell.RowIndex <> row.Index Then
                        '    m_bProgrammingHit = True
                        '    OnDataGridViewSelectionChanged(0, 0)
                        'End If
                        Return
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub OnDataGridViewSelectionChanged(ByVal nOldIndex As Integer, ByVal nNewIndex As Integer)
        If Me.m_oDataGridView.Enabled AndAlso Me.m_oDataGridView.ReadOnly = False Then
            If m_bDataBindOver = False Then Return
            If Me.m_oDataGridView.SelectedRows.Count > 0 Then
                RaiseEvent DataGridViewSelChanged(m_oDataGridView)
                InterActOnDataGridSelChange()
                m_bInitSelChange = False
            End If
        End If
    End Sub

    Private Sub InterActOnDataGridSelChange()
        If m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT Then
            If Me.m_oDataGridView.SelectedRows.Count > 0 Then
                Dim firstSelRow As DataGridViewRow = Me.m_oDataGridView.SelectedRows(0)
                If firstSelRow Is Nothing Then Return
                If String.Compare(Me.txtDP.Text, firstSelRow.Cells(0).Value.ToString, True) <> 0 Then
                    Me.txtDP.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub OnDataBindingOver()
        m_bNotRecieveBindOver = False
        m_bDataBindOver = True
    End Sub

    Private Sub UpdateSearchbarContent()
        If Me.IsSearchBarStyle Then
            If Me.m_oDataGridView.SelectedRows.Count > 0 Then
                Dim firstSel As DataGridViewRow = Me.m_oDataGridView.SelectedRows(0)
                If Not firstSel Is Nothing Then
                    Me.txtDP.Text = firstSel.Cells(0).Value.ToString
                End If
            ElseIf m_emStyle <> EXPAND_PANEL_TYPE.SEARCHBAR_FILTER Then 'if filter, the default sel nothing 
                Me.txtDP.Text = ""
            End If
        End If
    End Sub

    Private Sub OnInitSelRowIndexEffected(ByVal bEffect As Boolean, ByVal nSelRowIndex As Integer)
        If bEffect Then
            m_bInitSelChange = True
        End If
    End Sub

    Private Sub OnUIDataGridViewCellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        RaiseEvent DataGridViewCellClick(sender)
    End Sub

    Private Sub OnUIDataGridViewCellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        RaiseEvent DataGridViewCellDoubleClick(sender)
    End Sub

    Private Sub OnUIDataGridViewSizeChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim obj As UIDataGridView = CType(sender, UIDataGridView)
        If m_nDGVPreWidth <> obj.Width Then
            obj.UpdateColumnsWidth()
            m_nDGVPreWidth = obj.Width
        End If
    End Sub

    Public Function UpdateDataTable(ByVal nTableIndex As Integer, ByVal dt As DataTable) As Boolean
        If Me.m_emStyle = EXPAND_PANEL_TYPE.STANDARD Then
            If nTableIndex < 0 OrElse m_aryButtons Is Nothing OrElse nTableIndex >= m_aryButtons.Length Then
                Return False
            End If
            Dim strBindTableName As String = m_aryButtons(nTableIndex).Name
            Return Me.UpdataTableForStandardStyle(strBindTableName, dt)
        ElseIf IsSearchBarStyle() Then
            Return UpdataTableForSearchbarStyle(dt)
        End If
        Return False
    End Function

    Public Function UpdateDataTable(ByVal strBindTableName As String, ByVal dt As DataTable) As Boolean
        If Me.m_emStyle = EXPAND_PANEL_TYPE.STANDARD Then
            Return Me.UpdataTableForStandardStyle(strBindTableName, dt)
        ElseIf IsSearchBarStyle() Then
            Return UpdataTableForSearchbarStyle(dt)
        End If
        Return False
    End Function

    Private Function UpdataTableForSearchbarStyle(ByVal dt As DataTable) As Boolean
        If Not IsSearchBarStyle() Then Return False
        If dt Is Nothing Then Return False

        m_oDataSet.Tables.Clear()
        m_oDataSet.Tables.Add(dt)
        If m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_FILTER Then
            BindFilterTable()
        ElseIf m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT Then
            BindHighLightTable(m_oDataSet.Tables(0))
        End If
        Return True
    End Function

    Private Function UpdataTableForStandardStyle(ByVal strBindTableName As String, ByVal dt As DataTable) As Boolean
        If Me.m_emStyle <> EXPAND_PANEL_TYPE.STANDARD Then Return False
        If String.IsNullOrEmpty(strBindTableName) OrElse dt Is Nothing Then
            Return False
        End If
        If m_aryButtons Is Nothing Then Return False
        For Each btn As LabelEx In m_aryButtons
            If String.Compare(btn.Text, strBindTableName, True) = 0 Then
                Dim n As Integer = Me.m_oDataSet.Tables.IndexOf(btn.Text)
                If n <> -1 Then 'find
                    Dim ds As DataSet = CopyDataSet()
                    m_oDataSet.Tables.Clear()
                    For i As Integer = 0 To ds.Tables.Count - 1
                        If n = i Then
                            m_oDataSet.Tables.Add(dt)
                        Else
                            m_oDataSet.Tables.Add(CType(ds.Tables(i), UIExpandPanelDataTable).Copy)
                        End If
                        If m_aryButtons.Length - 1 >= n Then
                            m_aryButtons(n).Text = dt.TableName
                            Dim nbtn As Integer = Array.IndexOf(m_aryButtons, m_CurSelBtn)
                            If nbtn = n Then 'the old datatable is shown,update the view
                                BindingTable(dt)
                            End If
                        End If
                    Next
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Function CopyDataSet() As DataSet
        Dim ds As DataSet = m_oDataSet.Copy
        For i As Integer = 0 To m_oDataSet.Tables.Count - 1
            Dim dtDest As UIExpandPanelDataTable = CType(ds.Tables(i), UIExpandPanelDataTable)
            Dim dtOri As UIExpandPanelDataTable = CType(m_oDataSet.Tables(i), UIExpandPanelDataTable)
            'copy the table deeply
            dtDest.ColumnWidthCollection = dtOri.ColumnWidthCollection
        Next
        Return ds
    End Function

    Public Function GetDataTable(ByVal strBindTableName As String) As DataTable
        If String.IsNullOrEmpty(strBindTableName) Then
            Return Nothing
        End If

        Dim n As Integer = Me.m_oDataSet.Tables.IndexOf(strBindTableName)
        If n <> -1 Then
            Return Me.m_oDataSet.Tables.Item(n)
        End If
        Return Nothing
    End Function

    Public Function GetDataTable(ByVal nTableIndex As Integer) As DataTable
        If Me.m_oDataSet Is Nothing OrElse nTableIndex < 0 OrElse nTableIndex >= Me.m_oDataSet.Tables.Count Then
            Return Nothing
        End If

        Return Me.m_oDataSet.Tables.Item(nTableIndex)
    End Function

    Public Function GetCurTableClassify(ByRef strBindTableName As String) As Boolean
        If Not Me.m_oDataGridView Is Nothing Then
            If m_emStyle = EXPAND_PANEL_TYPE.STANDARD AndAlso m_CurSelBtn IsNot Nothing Then
                strBindTableName = m_CurSelBtn.Text
                Return True
            ElseIf IsSearchBarStyle() Then
                strBindTableName = CType(m_oDataGridView.DataSource, DataTable).TableName
                Return True
            End If
        End If
        Return False
    End Function

    Public Function GetCurTableClassify(ByRef nIndex As Integer) As Boolean
        If Not Me.m_oDataGridView Is Nothing Then
            If m_emStyle = EXPAND_PANEL_TYPE.STANDARD Then
                If m_aryButtons IsNot Nothing Then
                    nIndex = Array.IndexOf(m_aryButtons, m_CurSelBtn)
                    If nIndex <> -1 Then Return True
                End If
            ElseIf IsSearchBarStyle() Then
                nIndex = 0
                Return True
            End If
        End If
        Return False
    End Function

    Public Function SetForeColor(ByVal strBindTableName As String, ByVal cr As System.Drawing.Color) As Boolean
        If String.IsNullOrEmpty(strBindTableName) OrElse m_aryButtons Is Nothing Then
            Return False
        End If

        For Each btn As LabelEx In m_aryButtons
            If String.Compare(btn.Text, strBindTableName, True) = 0 Then 'find
                btn.Fore_Color = cr
                btn.Refresh()
                Return True
            End If
        Next
        Return False
    End Function

    Public Function SetForeColor(ByVal nTableIndex As Integer, ByVal cr As System.Drawing.Color) As Boolean
        If m_aryButtons Is Nothing OrElse nTableIndex < 0 OrElse nTableIndex >= m_aryButtons.Length Then
            Return False
        End If
        Dim btn As LabelEx = m_aryButtons(nTableIndex)
        btn.Fore_Color = cr
        btn.Refresh()
        Return True
    End Function

    Private Sub txtDP_PressEnter() Handles txtDP.PressEnter
        Debug.Assert(Me.m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT OrElse Me.m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_FILTER)
        If Me.m_emStyle <> EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT AndAlso Me.m_emStyle <> EXPAND_PANEL_TYPE.SEARCHBAR_FILTER Then Return
        If Me.m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT Then
            HighLightItem()
        Else
            BindFilterTable()
        End If
    End Sub

    Private Sub txtDP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDP.TextChanged
        If Me.m_emStyle = EXPAND_PANEL_TYPE.SEARCHBAR_FILTER AndAlso String.IsNullOrEmpty(Me.txtDP.Text) Then
            BindFilterTable()
        End If
    End Sub
    '****************************************************
    Private Sub CreateToolBar(ByVal ctrlParent As Control)
        If Not Me.m_btnToolbar Is Nothing OrElse ctrlParent Is Nothing Then
            Return
        Else
            Me.m_btnToolbar = New LabelEx
            m_btnToolbar.NoExtraEffect = True
        End If

        Me.m_btnToolbar.SuspendLayout()
        'Define 3 button, that is Refresh, Print, PrintAll
        Dim picRefresh As New MyLabelBase
        picRefresh.Name = "picRefresh"
        picRefresh.TipText = CONST_TEXT_TOOL_BAR_REFRESH
        picRefresh.Image = My.Resources.refresh
        picRefresh.SetImageList(My.Resources.refresh, My.Resources.refresh_over, My.Resources.refresh_press)
        picRefresh.Location = New System.Drawing.Point(10, 7)
        picRefresh.Size = New System.Drawing.Size(16, 16)
        AddHandler picRefresh.Click, AddressOf OnpicRefreshClick
        m_btnToolbar.PnlMiddle.Controls.Add(picRefresh)

        Dim picPrint As New MyLabelBase
        picPrint.Name = "picPrint"
        picPrint.TipText = CONST_TEXT_TOOL_BAR_PRINT
        picPrint.Image = My.Resources.print
        picPrint.SetImageList(My.Resources.print, My.Resources.print_over, My.Resources.print_press)
        picPrint.Location = New System.Drawing.Point(40, 7)
        picPrint.Size = New System.Drawing.Size(16, 16)
        AddHandler picPrint.Click, AddressOf OnpicPrintClick
        m_btnToolbar.PnlMiddle.Controls.Add(picPrint)

        Dim picPrintAll As New MyLabelBase
        picPrintAll.Name = "picPrintAll"
        picPrintAll.TipText = CONST_TEXT_TOOL_BAR_PRINT_ALL
        picPrintAll.Image = My.Resources.print_2
        picPrintAll.SetImageList(My.Resources.print_2, My.Resources.print_2_over, My.Resources.print_2_press)
        picPrintAll.Location = New System.Drawing.Point(70, 7)
        picPrintAll.Size = New System.Drawing.Size(16, 16)
        AddHandler picPrintAll.Click, AddressOf OnpicPrintAllClick
        m_btnToolbar.PnlMiddle.Controls.Add(picPrintAll)

        Dim picDispatchStatistic As New MyLabelBase
        picDispatchStatistic.Name = "picDispatchStatistic"
        picDispatchStatistic.TipText = CONST_TEXT_TOOL_BAR_DISPATCH_STATISTIC
        picDispatchStatistic.Image = My.Resources.dispatch_statistic_normal
        picDispatchStatistic.SetImageList(My.Resources.dispatch_statistic_normal, My.Resources.dispatch_statistic_over, My.Resources.dispatch_statistic_press)
        picDispatchStatistic.Location = New System.Drawing.Point(100, 7)
        picDispatchStatistic.Size = New System.Drawing.Size(16, 16)
        AddHandler picDispatchStatistic.Click, AddressOf OnpicDispatchStatisticClick
        m_btnToolbar.PnlMiddle.Controls.Add(picDispatchStatistic)

        Dim picMenu As New MyLabelBase
        picMenu.Image = My.Resources.timeset_normal
        picMenu.SetImageList(My.Resources.timeset_normal, My.Resources.timeset_over, My.Resources.timeset_press)
        picMenu.Location = New System.Drawing.Point(Me.m_btnToolbar.Right - 40, 7)
        picMenu.Size = New System.Drawing.Size(28, 16)
        picMenu.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        picMenu.Visible = Me.m_aryButtons.Length > CONST_INT_MAX_SHOWN_BUTTON
        AddHandler picMenu.Click, AddressOf OnpicMenuClick
        m_btnToolbar.PnlMiddle.Controls.Add(picMenu)

        m_btnToolbar.Left = CONST_INT_CTRL_MARGIN
        m_btnToolbar.Width = Me.Width - 2 * CONST_INT_CTRL_MARGIN
        m_btnToolbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        ctrlParent.Controls.Add(Me.m_btnToolbar)
        Me.m_btnToolbar.ResumeLayout(True)
    End Sub

    Private Sub OnpicRefreshClick(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DoRefresh()
    End Sub

    Private Sub OnpicPrintClick(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DoCurrentPrint()
    End Sub

    Private Sub OnpicPrintAllClick(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DoPrintAll()
    End Sub

    Private Sub OnpicDispatchStatisticClick(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DoDispatchStatistic()
    End Sub

    Private Sub OnpicMenuClick(ByVal sender As Object, ByVal e As EventArgs)
        If m_aryButtons Is Nothing OrElse m_aryButtons.Length <= CONST_INT_MAX_SHOWN_BUTTON Then
            Return
        End If

        m_MenuContext = New ContextMenu
        Dim nIndex As Integer = 0
        For Each btn As LabelEx In m_aryButtons
            Dim menu As New xpmenuitem.xpMenu
            menu.Index = nIndex
            menu.OwnerDraw = True
            menu.Text = btn.Text
            If Me.m_nIndexFirstBtnShow <= nIndex AndAlso nIndex < Me.m_nIndexFirstBtnShow + CONST_INT_MAX_SHOWN_BUTTON Then
                menu.Checked = True
            End If
            AddHandler menu.Click, AddressOf OnMenuItemClick
            m_MenuContext.MenuItems.Add(menu)
            nIndex += 1
        Next
        m_MenuContext.Show(Me, New System.Drawing.Point(Me.Right, Me.Bottom))
    End Sub

    Private Sub OnMenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim oMenu As xpmenuitem.xpMenu = CType(sender, xpmenuitem.xpMenu)
        Dim nIndex As Integer = m_MenuContext.MenuItems.IndexOf(oMenu)
        If nIndex <> -1 Then
            m_nIndexFirstBtnShow = nIndex
            Me.OnBtnClick(m_aryButtons(nIndex), EventArgs.Empty)
        End If
    End Sub

    Public Sub ToolBarSubItemVisible(ByVal emBarItem As TOOLBAR_SUBITEM, ByVal bVisible As Boolean)
        If m_btnToolbar Is Nothing Then
            Return
        End If

        Dim oLbl As MyLabelBase = Nothing
        If emBarItem = TOOLBAR_SUBITEM.REFRESH Then
            oLbl = Me.m_btnToolbar.PnlMiddle.Controls.Item("picRefresh")         
        ElseIf emBarItem = TOOLBAR_SUBITEM.PRINT Then
            oLbl = Me.m_btnToolbar.PnlMiddle.Controls.Item("picPrint")
        ElseIf emBarItem = TOOLBAR_SUBITEM.PRINTALL Then
            oLbl = Me.m_btnToolbar.PnlMiddle.Controls.Item("picPrintAll")
        ElseIf emBarItem = TOOLBAR_SUBITEM.DISPATCHSTATISTIC Then
            oLbl = Me.m_btnToolbar.PnlMiddle.Controls.Item("picDispatchStatistic")
        End If
        If oLbl IsNot Nothing Then
            oLbl.Visible = bVisible
            ReLayoutToolBar()
        End If
    End Sub

    Private Sub ReLayoutToolBar()

    End Sub
    '****************************************************
End Class
