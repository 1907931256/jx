Imports System.Windows.Forms
Public Class CmbDropDownList
    Public Enum SNAP_MODE As Short
        OnLeft = 1
        OnRight = 2
    End Enum
#Region "Components"
    Private WithEvents m_dgvDropDown As UIDataGridView '意义：代表下拉的GridView。
    Private WithEvents m_frmShow As Form '意义：承载GridView的对话框。
    Private m_dtblSource As DataTable '意义：控件所有条目的信息存储者。
    Private m_ptPosition As Drawing.Point '意义：m_frmShow的显示位置。
    Private m_nCodeIndex As Integer '意义：拼音编码字段在m_dgvDropDown和m_dtblSource中列的位置。
    Private m_nDisplayIndex As Integer '意义：控件显示内容字段在m_dgvDropDown和m_dtblSource中列的位置。
    Private m_nIDIndex As Integer '意义：ID列在m_dgvDropDown和m_dtblSource中列的位置。
    Private m_strIDContent As String '意义：ID列的内容。
    Private m_strDisplay As String '意义：显示列的内容。
    Private m_nVisibleRowCount As Integer '意义：控件显示的列数。
    Private m_smDropDownOritation As SNAP_MODE '意义：GridView中每个小格内容的对齐方式。
    Private m_ArrColWidth As Array '意义：GridView各列的宽度。
    Private m_nRowHeight As Integer
    Private m_nNormalDropDownHeight As Integer
    Private m_nMinDropDownHeight As Integer
    Private m_bDropDownBeShowing As Boolean
    Private m_drSelectedRow As DataRow
    Private m_amAlignment As System.Windows.Forms.DataGridViewContentAlignment
    Private m_bShouldSendEnter As Boolean
    Private m_bFirstGotFocus As Boolean
    Private m_bIgnoreEnter As Boolean
    Private m_bSelectCont As Boolean
    Public Event PressEnter()
#End Region

#Region "Properties"
    Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            If value = "" OrElse value = String.Empty Then
                MyBase.SelectedIndex = -1
                MyBase.SelectedItem = Nothing
            End If
            MyBase.Text = value
        End Set
    End Property
    Property CodeIndex() As Integer
        '作用：指定或者获得拼音编码字段在m_dgvDropDown和m_dtblSour列的位置。
        Get
            CodeIndex = m_nCodeIndex
        End Get
        Set(ByVal Value As Integer)
            m_nCodeIndex = Value
        End Set
    End Property

    Property DisplayIndex() As Integer
        '作用：指定控件显示内容字段在m_dgvDropDown和m_dtblSource中列的位置。 
        Set(ByVal Value As Integer)
            m_nDisplayIndex = Value
        End Set
        Get
            DisplayIndex = m_nDisplayIndex
        End Get
    End Property

    ReadOnly Property DisplayContent() As String
        '作用：获取控件显示内容字段的内容。
        Get
            Return m_strDisplay
        End Get
    End Property

    Property IDIndex() As Integer
        '作用：指定控件ID字段在m_dgvDropDown和m_dtblSource中列的位置。
        Set(ByVal Value As Integer)
            m_nIDIndex = Value
        End Set
        Get
            IDIndex = m_nIDIndex
        End Get
    End Property

    Property IDContent() As String
        Set(ByVal value As String)
            m_strIDContent = value
        End Set
        '作用：获取ID字段的内容。
        Get
            IDContent = m_strIDContent
        End Get
    End Property

    Property VisibleRowCount() As Integer
        '作用：指定或获得m_dgvDropDown最多一次显示的行数。
        Get
            VisibleRowCount = m_nVisibleRowCount
        End Get
        Set(ByVal Value As Integer)
            m_nVisibleRowCount = Value
        End Set
    End Property

    Property DropDownOritation() As SNAP_MODE
        '作用：指定m_dgvDropDown中每一个行中每一个小格内容显示的格式，向左对齐或者向右对齐。
        Get
            DropDownOritation = m_smDropDownOritation
        End Get
        Set(ByVal Value As SNAP_MODE)
            m_smDropDownOritation = Value
        End Set
    End Property

    WriteOnly Property ColumnWidthCollection() As Array
        '作用：设定GridView各列的宽度。
        Set(ByVal Value As Array)
            m_ArrColWidth = Value
        End Set
    End Property

    ReadOnly Property CurrentSelectedRow() As DataRow
        Get
            If CheckInputValid() Then
                CurrentSelectedRow = m_drSelectedRow
            Else
                CurrentSelectedRow = Nothing
            End If
        End Get
    End Property

    ReadOnly Property CurrentRow() As DataRow
        Get
            Return GetRowFromText()
        End Get
    End Property

    Property RowHeight() As Integer
        '作用：指定m_dgvDropDown中每一个行中每一个小格内容显示的格式，向左对齐或者向右对齐。
        Get
            RowHeight = m_nRowHeight
        End Get
        Set(ByVal Value As Integer)
            m_nRowHeight = Value
        End Set
    End Property

    ReadOnly Property ValidateText() As Boolean
        Get
            ValidateText = CheckInputValid()
        End Get
    End Property

    Property AliginMent() As System.Windows.Forms.DataGridViewContentAlignment
        Get
            AliginMent = m_amAlignment
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridViewContentAlignment)
            m_amAlignment = value
        End Set
    End Property

    Property IsIgnoreEnter() As Boolean
        '作用：选择下拉框选项后，是否输入ENTRE键
        Get
            Return m_bIgnoreEnter
        End Get
        Set(ByVal value As Boolean)
            m_bIgnoreEnter = value
        End Set
    End Property
    Property IsSelectCont() As Boolean
        '作用：获得焦点后是否可以选择框内内容
        Get
            Return m_bSelectCont
        End Get
        Set(ByVal value As Boolean)
            m_bSelectCont = value
        End Set
    End Property
#End Region

#Region "ComboBox Events"

    Private Sub OnCmbGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        '功能：捕捉获得焦点事件，设定m_ptFormPosition的值。
        If MyBase.Text.Length >= 0 Then
            m_ptPosition.X = 0
            m_ptPosition.Y = MyBase.Height + 3
        End If
        If m_bSelectCont Then
            m_bSelectCont = False
        Else
            MyBase.SelectionStart = MyBase.Text.Length
        End If
        'MyBase.SelectionLength = 0
        '让鼠标处在文字末端
    End Sub

    Private Sub OnCmbDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '功能：捕捉按键消息。
        'A、如果是当前控件的m_dtblSource没有任何内容，即没有供筛选的内容，如果按下的是Enter键，则切换到下一个控件；否则不做任何动作。
        'B、m_dtblSource不为空条件下：
        '如果按下的是向下键，判断m_dgvDropDown是否有项目，如果有，将第一条设为选中状态，如果无，不做动作；
        '如果按下的Enter键，判断m_dgvDropDown是否有符合筛选条件的项目，如果有，选择第一条。如果无，切换到下一个控件。
        If (m_dtblSource.Rows.Count = 0) Then
            If e.KeyCode = Keys.Enter Then
                RaiseEvent PressEnter()
            End If
            Return
        End If
        If (e.KeyCode = Keys.Down) Then
            If m_dgvDropDown.Rows.Count > 0 Then
                m_dgvDropDown.Focus()
                If m_dgvDropDown.SelectedRows.Count = 0 Then
                    m_dgvDropDown.Rows.Item(0).Selected = True
                End If
                m_dgvDropDown.Select()
            End If
            '表示本消息已处理，禁止Combobox自带的对dropdown的上下键选择事件
            e.Handled = True
        ElseIf (e.KeyCode = Keys.Up) Then
            '表示本消息已处理，禁止Combobox自带的对dropdown的上下键选择事件
            e.Handled = True
        ElseIf (e.KeyCode = Keys.Enter) Then
            If m_dgvDropDown.SelectedRows.Count = 0 AndAlso m_dgvDropDown.Rows.Count > 0 Then
                m_dgvDropDown.Rows.Item(0).Selected = True
                AfterSelect(m_dgvDropDown.Rows.Item(0), 0, e.KeyCode)
            Else
                HideDropDown()
                RaiseEvent PressEnter()
            End If
        ElseIf (e.KeyCode = Keys.Tab) Then 'Notise: here,TAB event message comes from previous control,NOT itself!
            'do nothing
        End If

    End Sub

    Private Sub OnCmbChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        '功能：捕捉内容输入内容改变的消息。实时地根据其内容更新m_dgvDropDown中符合筛选条件的选项，将m_dgvDropDown和m_frmShow显示出来。
        If MyBase.Focused Then
            ShowFilteredData(False)
            MyBase.Focus()
        End If

    End Sub

    Private Sub OnCmbLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        If (m_dtblSource.Rows.Count = 0) Then Return
        HideDropDown()
        CheckInputValid()
    End Sub

    Private Sub OnCmbDropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DropDown
        HideDropDown()
    End Sub

    Private Sub OnCmbSelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SelectionChangeCommitted
        m_bShouldSendEnter = True
    End Sub

    Private Sub OnCmbKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If Me.Text <> m_strDisplay Then
            MyBase.OnTextChanged(e)
        End If
    End Sub

    Private Sub OnCmbSelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged, Me.SelectedValueChanged
        If MyBase.SelectedValue Is Nothing Then Exit Sub
        Dim strFilter As String = String.Empty
        If m_dtblSource.Columns(m_nIDIndex).DataType Is GetType(Integer) OrElse _
            m_dtblSource.Columns(m_nIDIndex).DataType Is GetType(Long) OrElse _
            m_dtblSource.Columns(m_nIDIndex).DataType Is GetType(Short) OrElse _
            m_dtblSource.Columns(m_nIDIndex).DataType Is GetType(Decimal) OrElse _
            m_dtblSource.Columns(m_nIDIndex).DataType Is GetType(Single) Then
            strFilter = String.Format("{0}={1}", m_dtblSource.Columns(m_nIDIndex).ColumnName, MyBase.SelectedValue)
        Else
            strFilter = String.Format("{0}='{1}'", m_dtblSource.Columns(m_nIDIndex).ColumnName, MyBase.SelectedValue)
        End If
        Dim drFind As DataRow() = m_dtblSource.Select(strFilter)
        If drFind.Length = 1 Then
            m_strDisplay = drFind(0).Item(m_nDisplayIndex)
            m_strIDContent = drFind(0).Item(m_nIDIndex)
            m_drSelectedRow = drFind(0)
            If m_bShouldSendEnter And m_bIgnoreEnter = False Then
                SendKeys.Send("{Enter}")
                m_bShouldSendEnter = False
            End If
        Else
            m_drSelectedRow = Nothing
        End If
    End Sub
#End Region

#Region "GridView Events"
    Private Sub OnGridViewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles m_dgvDropDown.KeyDown
        If e.KeyCode = Keys.Enter Then
            AfterSelect(m_dgvDropDown.SelectedRows(0), m_dgvDropDown.SelectedRows(0).Index)
            SendKeys.Send("{Enter}")
        End If
        '注意，此处本来是处理的KeyUp事件，但是发现，Enter键KeyDown的时候，控件默认会将选择项向下移动
        '一行，KeyUp时选择的就出错了，所以直接处理KeyDown事件。
    End Sub

    Private Sub OnGridViewCellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles m_dgvDropDown.CellMouseClick
        m_dgvDropDown.Rows(e.RowIndex).Selected = True
        AfterSelect(m_dgvDropDown.SelectedRows(0), m_dgvDropDown.SelectedRows(0).Index)
        SendKeys.Send("{Enter}")
    End Sub
#End Region

#Region "Form Events"
    Private Sub OnFrmShowResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_frmShow.Resize
        '功能：捕捉m_frmShow的大小改变信息，让m_frmShow的大小变成跟m_dgvDropDown的大小一致。
        m_frmShow.Size = m_dgvDropDown.Size
    End Sub
#End Region

#Region "Methods"
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_frmShow = New Form
        m_dgvDropDown = New UIDataGridView
        m_dtblSource = New DataTable("DropDown")
        m_nCodeIndex = 0
        m_nDisplayIndex = 1
        m_nIDIndex = 2
        m_nVisibleRowCount = 10
        m_nRowHeight = MyBase.ItemHeight + 3
        m_nNormalDropDownHeight = MyBase.DropDownHeight
        m_nMinDropDownHeight = 1
        m_bDropDownBeShowing = False
        m_ArrColWidth = Nothing
        m_drSelectedRow = Nothing
        m_smDropDownOritation = SNAP_MODE.OnLeft
        m_amAlignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        m_bShouldSendEnter = False
        m_bFirstGotFocus = True
        m_bIgnoreEnter = False
        m_bSelectCont = False
    End Sub

    Public Sub Attach(Optional ByVal dtResource As DataTable = Nothing)
        m_dtblSource = dtResource
        '如果m_dgvDropDown有数据时，隐藏ComboBox本身的下拉项
        MyBase.DisplayMember = m_dtblSource.Columns(m_nDisplayIndex).ColumnName
        MyBase.ValueMember = m_dtblSource.Columns(m_nIDIndex).ColumnName

        Dim dv As DataView = New DataView(m_dtblSource)
        dv.Sort = m_dtblSource.Columns(m_nDisplayIndex).ColumnName
        MyBase.DataSource = dv.ToTable

        MyBase.SelectedIndex = -1
        InitialGridView()
        InitialForm()
    End Sub

    Private Sub AfterSelect(ByVal selRow As DataGridViewRow, ByVal nRowIndex As Integer, Optional ByVal keys As System.Windows.Forms.Keys = Keys.A)
        If selRow Is Nothing Then
            Return
        End If
        '因为宽度为0的行，UIDataGridView里根本没有加载，故原来通过selRow.Cells(nIndex)的方法不可用
        Dim dtblFiltered As DataTable = m_dgvDropDown.DataSource
        m_strDisplay = dtblFiltered.Rows(nRowIndex).Item(m_nDisplayIndex)
        m_strIDContent = dtblFiltered.Rows(nRowIndex).Item(m_nIDIndex)
        m_drSelectedRow = dtblFiltered.Rows(nRowIndex)
        Me.SelectedValue = m_strIDContent

        HideDropDown()
        RaiseEvent PressEnter()
        Me.SelectAll()
        'If keys <> Windows.Forms.Keys.Enter Then
        '    SendKeys.Send("{Enter}")
        'End If
    End Sub

    Private Sub InitialGridView()
        With m_dgvDropDown
            .TabStop = False
            .BorderStyle = BorderStyle.FixedSingle
            .Visible = False
            .Font = Me.Font
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowTemplate.Height = m_nRowHeight
            .ColumnHeadersVisible = False
            .ShowSelectionColor = True
            .RowTemplate.DefaultCellStyle.Alignment = m_amAlignment
        End With
    End Sub

    Private Sub ModifyGridViewStyle()
        With m_dgvDropDown
            .RowTemplate.Height = m_nRowHeight
            .RowTemplate.DefaultCellStyle.Alignment = m_amAlignment
        End With
    End Sub

    Private Sub InitialForm()
        With m_frmShow
            .FormBorderStyle = FormBorderStyle.None
            .BackColor = Drawing.Color.White
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.Manual
            .Controls.Add(m_dgvDropDown)
            .TopMost = True
        End With
    End Sub

    Private Sub ShowFilteredData(Optional ByVal bShowAllData As Boolean = False)
        ModifyGridViewStyle()

        If m_dtblSource.Rows.Count = 0 Then
            HideDropDown()
            Exit Sub
        End If

        Dim strtxt As String = MyBase.Text.ToString
        Dim dvIntermediate As New DataView(m_dtblSource)
        Dim nRowsShow As Integer = m_nVisibleRowCount
        Dim bHorizonScrollBar As Boolean = False
        strtxt = MakeSQLLIKEPattern(strtxt)

        If Not bShowAllData Then
            If (strtxt = "" Or strtxt Is Nothing) Then
                HideDropDown()
                Return
            End If
        Else
            strtxt = ""
        End If

        With dvIntermediate
            .AllowNew = False
            If dvIntermediate.Table.Columns.Count > 0 Then
                If m_dtblSource.Columns(m_nCodeIndex).DataType Is strtxt.GetType() AndAlso m_dtblSource.Columns(m_nIDIndex).DataType Is strtxt.GetType() Then
                    .RowFilter = String.Format("{0} like '%{1}%' or {2} like '%{3}%'", m_dtblSource.Columns(m_nCodeIndex).ColumnName, strtxt, m_dtblSource.Columns(m_nIDIndex).ColumnName, strtxt)
                ElseIf m_dtblSource.Columns(m_nCodeIndex).DataType Is strtxt.GetType() Then
                    .RowFilter = String.Format("{0} like '%{1}%' ", m_dtblSource.Columns(m_nCodeIndex).ColumnName, strtxt)
                ElseIf m_dtblSource.Columns(m_nIDIndex).DataType Is strtxt.GetType() Then
                    .RowFilter = String.Format("{0} like '%{1}%' ", m_dtblSource.Columns(m_nIDIndex).ColumnName, strtxt)
                End If
            End If
        End With

        '指定列宽，如果给定的列宽数组元素个数比数据源列数少，则不处理
        If Not m_ArrColWidth Is Nothing AndAlso Not m_ArrColWidth.Length < m_dtblSource.Columns.Count Then
            Dim nColumnWholeWidth As Integer = 0
            For Each nWidth As Integer In m_ArrColWidth
                nColumnWholeWidth += nWidth
            Next
            '根据各列宽，设定DataGridView总宽度
            m_dgvDropDown.RealColumnWidthCollection = m_ArrColWidth
            m_dgvDropDown.Width = nColumnWholeWidth
        End If


        '指定数据源，根据UIDataGridView的设计，指定数据源要放在设定列宽后边，列宽才能生效
        m_dgvDropDown.DataSource = dvIntermediate.ToTable

        '指定一次要显示的行数
        If (dvIntermediate.Count > m_nVisibleRowCount) Then
            nRowsShow = m_nVisibleRowCount
        Else
            nRowsShow = dvIntermediate.Count
        End If

        '设定DataGridView和Form的位置和size
        If (dvIntermediate.Count > 0) Then
            Dim ptPoint As Drawing.Point = m_ptPosition
            ptPoint = PointToScreen(ptPoint)
            '防止窗体右边界超出。
            If m_smDropDownOritation = SNAP_MODE.OnLeft Then
                If ptPoint.X + m_dgvDropDown.Width > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    'm_dgvDropDown.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - ptPoint.X - 2
                    'bHorizonScrollBar = True
                    ptPoint.X = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - m_dgvDropDown.Width - 2
                End If
                '防止窗体左边界超出。
            Else
                ptPoint.X = ptPoint.X + Me.Width - m_dgvDropDown.Width
                If ptPoint.X <= 0 Then
                    'm_dgvDropDown.Width = PointToScreen(m_ptPosition).X + Me.Width - 2
                    ptPoint.X = 2
                    'bHorizonScrollBar = True
                End If
            End If
            '设定DataGridView高度
            If m_dgvDropDown.Rows.Count > 0 Then
                m_dgvDropDown.Height = m_dgvDropDown.Rows(0).Height * nRowsShow + System.Windows.Forms.SystemInformation.BorderSize.Width * 2
                If bHorizonScrollBar Then
                    m_dgvDropDown.Height += System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight
                End If
            Else
                m_dgvDropDown.Height = 0
            End If

            '设定窗体size
            With m_frmShow
                .Size = m_dgvDropDown.Size
                .Location = ptPoint
            End With

            ShowDropDown()
            m_dgvDropDown.ClearSelection()
            m_frmShow.Show()
        Else
            HideDropDown()
        End If
    End Sub

    Private Sub HideDropDown()
        m_dgvDropDown.Visible = False
        m_frmShow.Visible = False
        m_bDropDownBeShowing = False
    End Sub

    Private Sub ShowDropDown()
        m_dgvDropDown.Visible = True
        m_frmShow.Visible = True
        m_bDropDownBeShowing = True
    End Sub

    Private Function CheckInputValid() As Boolean
        Dim strText = MyBase.Text
        If Not strText.Equals("") Then
            Dim dvIntermediate As New DataView(m_dtblSource)
            dvIntermediate.RowFilter = String.Format("{0} = '{1}'", m_dtblSource.Columns(m_nDisplayIndex).ColumnName, strText)
            If dvIntermediate.ToTable().Rows.Count = 0 Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Function GetRowFromText() As DataRow
        If m_dtblSource Is Nothing Then Return Nothing
        If m_dtblSource.Rows.Count = 0 Then Return Nothing
        If MyBase.Text.Trim = String.Empty Then Return Nothing

        Dim dvIntermediate As New DataView(m_dtblSource)
        dvIntermediate.RowFilter = String.Format("{0} = '{1}'", _
                                  m_dtblSource.Columns(m_nDisplayIndex).ColumnName, MyBase.Text.Trim)
        Dim dtTemp As DataTable = dvIntermediate.ToTable
        Dim nCount As Integer = dtTemp.Rows.Count
        If nCount < 1 Then
            Return Nothing
        ElseIf nCount = 1 Then
            Return dtTemp.Rows(0)
        Else
            '如果有多条符合项，则与当前选择的ROW的ID列对比，如果有相同刚反回当前选择的行，否则返回第一条ROW
            If m_drSelectedRow Is Nothing Then Return dtTemp.Rows(0)
            For Each dr As DataRow In dtTemp.Rows
                If m_drSelectedRow(m_nIDIndex).ToString = dr(m_nIDIndex).ToString Then
                    Return m_drSelectedRow
                End If
            Next
            Return dtTemp.Rows(0)
        End If
    End Function
#End Region

#Region "SQL Method"
    Public Function MakeSQLLIKEPattern(ByVal strInput As String) As String
        Dim strOutput As String = strInput
        strOutput = strOutput.Replace("[", "[[]")
        strOutput = strOutput.Replace("%", "[%]")
        strOutput = strOutput.Replace("_", "[_]")
        strOutput = strOutput.Replace("^", "[^]")
        strOutput = strOutput.Replace("*", "[*]")
        strOutput = strOutput.Replace("'", "''")
        Return strOutput
    End Function

    Public Function MakeSQLInputPattern(ByVal strInput As String) As String
        If strInput Is Nothing Then Return String.Empty
        Return strInput.Replace("'", "''")
    End Function
#End Region

End Class
