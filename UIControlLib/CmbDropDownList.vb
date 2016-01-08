Imports System.Windows.Forms
Public Class CmbDropDownList
    Public Enum SNAP_MODE As Short
        OnLeft = 1
        OnRight = 2
    End Enum
#Region "Components"
    Private WithEvents m_dgvDropDown As UIDataGridView '���壺����������GridView��
    Private WithEvents m_frmShow As Form '���壺����GridView�ĶԻ���
    Private m_dtblSource As DataTable '���壺�ؼ�������Ŀ����Ϣ�洢�ߡ�
    Private m_ptPosition As Drawing.Point '���壺m_frmShow����ʾλ�á�
    Private m_nCodeIndex As Integer '���壺ƴ�������ֶ���m_dgvDropDown��m_dtblSource���е�λ�á�
    Private m_nDisplayIndex As Integer '���壺�ؼ���ʾ�����ֶ���m_dgvDropDown��m_dtblSource���е�λ�á�
    Private m_nIDIndex As Integer '���壺ID����m_dgvDropDown��m_dtblSource���е�λ�á�
    Private m_strIDContent As String '���壺ID�е����ݡ�
    Private m_strDisplay As String '���壺��ʾ�е����ݡ�
    Private m_nVisibleRowCount As Integer '���壺�ؼ���ʾ��������
    Private m_smDropDownOritation As SNAP_MODE '���壺GridView��ÿ��С�����ݵĶ��뷽ʽ��
    Private m_ArrColWidth As Array '���壺GridView���еĿ�ȡ�
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
        '���ã�ָ�����߻��ƴ�������ֶ���m_dgvDropDown��m_dtblSour�е�λ�á�
        Get
            CodeIndex = m_nCodeIndex
        End Get
        Set(ByVal Value As Integer)
            m_nCodeIndex = Value
        End Set
    End Property

    Property DisplayIndex() As Integer
        '���ã�ָ���ؼ���ʾ�����ֶ���m_dgvDropDown��m_dtblSource���е�λ�á� 
        Set(ByVal Value As Integer)
            m_nDisplayIndex = Value
        End Set
        Get
            DisplayIndex = m_nDisplayIndex
        End Get
    End Property

    ReadOnly Property DisplayContent() As String
        '���ã���ȡ�ؼ���ʾ�����ֶε����ݡ�
        Get
            Return m_strDisplay
        End Get
    End Property

    Property IDIndex() As Integer
        '���ã�ָ���ؼ�ID�ֶ���m_dgvDropDown��m_dtblSource���е�λ�á�
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
        '���ã���ȡID�ֶε����ݡ�
        Get
            IDContent = m_strIDContent
        End Get
    End Property

    Property VisibleRowCount() As Integer
        '���ã�ָ������m_dgvDropDown���һ����ʾ��������
        Get
            VisibleRowCount = m_nVisibleRowCount
        End Get
        Set(ByVal Value As Integer)
            m_nVisibleRowCount = Value
        End Set
    End Property

    Property DropDownOritation() As SNAP_MODE
        '���ã�ָ��m_dgvDropDown��ÿһ������ÿһ��С��������ʾ�ĸ�ʽ���������������Ҷ��롣
        Get
            DropDownOritation = m_smDropDownOritation
        End Get
        Set(ByVal Value As SNAP_MODE)
            m_smDropDownOritation = Value
        End Set
    End Property

    WriteOnly Property ColumnWidthCollection() As Array
        '���ã��趨GridView���еĿ�ȡ�
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
        '���ã�ָ��m_dgvDropDown��ÿһ������ÿһ��С��������ʾ�ĸ�ʽ���������������Ҷ��롣
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
        '���ã�ѡ��������ѡ����Ƿ�����ENTRE��
        Get
            Return m_bIgnoreEnter
        End Get
        Set(ByVal value As Boolean)
            m_bIgnoreEnter = value
        End Set
    End Property
    Property IsSelectCont() As Boolean
        '���ã���ý�����Ƿ����ѡ���������
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
        '���ܣ���׽��ý����¼����趨m_ptFormPosition��ֵ��
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
        '����괦������ĩ��
    End Sub

    Private Sub OnCmbDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '���ܣ���׽������Ϣ��
        'A������ǵ�ǰ�ؼ���m_dtblSourceû���κ����ݣ���û�й�ɸѡ�����ݣ�������µ���Enter�������л�����һ���ؼ����������κζ�����
        'B��m_dtblSource��Ϊ�������£�
        '������µ������¼����ж�m_dgvDropDown�Ƿ�����Ŀ������У�����һ����Ϊѡ��״̬������ޣ�����������
        '������µ�Enter�����ж�m_dgvDropDown�Ƿ��з���ɸѡ��������Ŀ������У�ѡ���һ��������ޣ��л�����һ���ؼ���
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
            '��ʾ����Ϣ�Ѵ�����ֹCombobox�Դ��Ķ�dropdown�����¼�ѡ���¼�
            e.Handled = True
        ElseIf (e.KeyCode = Keys.Up) Then
            '��ʾ����Ϣ�Ѵ�����ֹCombobox�Դ��Ķ�dropdown�����¼�ѡ���¼�
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
        '���ܣ���׽�����������ݸı����Ϣ��ʵʱ�ظ��������ݸ���m_dgvDropDown�з���ɸѡ������ѡ���m_dgvDropDown��m_frmShow��ʾ������
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
        'ע�⣬�˴������Ǵ����KeyUp�¼������Ƿ��֣�Enter��KeyDown��ʱ�򣬿ؼ�Ĭ�ϻὫѡ���������ƶ�
        'һ�У�KeyUpʱѡ��ľͳ����ˣ�����ֱ�Ӵ���KeyDown�¼���
    End Sub

    Private Sub OnGridViewCellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles m_dgvDropDown.CellMouseClick
        m_dgvDropDown.Rows(e.RowIndex).Selected = True
        AfterSelect(m_dgvDropDown.SelectedRows(0), m_dgvDropDown.SelectedRows(0).Index)
        SendKeys.Send("{Enter}")
    End Sub
#End Region

#Region "Form Events"
    Private Sub OnFrmShowResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_frmShow.Resize
        '���ܣ���׽m_frmShow�Ĵ�С�ı���Ϣ����m_frmShow�Ĵ�С��ɸ�m_dgvDropDown�Ĵ�Сһ�¡�
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
        '���m_dgvDropDown������ʱ������ComboBox�����������
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
        '��Ϊ���Ϊ0���У�UIDataGridView�����û�м��أ���ԭ��ͨ��selRow.Cells(nIndex)�ķ���������
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

        'ָ���п�����������п�����Ԫ�ظ���������Դ�����٣��򲻴���
        If Not m_ArrColWidth Is Nothing AndAlso Not m_ArrColWidth.Length < m_dtblSource.Columns.Count Then
            Dim nColumnWholeWidth As Integer = 0
            For Each nWidth As Integer In m_ArrColWidth
                nColumnWholeWidth += nWidth
            Next
            '���ݸ��п��趨DataGridView�ܿ��
            m_dgvDropDown.RealColumnWidthCollection = m_ArrColWidth
            m_dgvDropDown.Width = nColumnWholeWidth
        End If


        'ָ������Դ������UIDataGridView����ƣ�ָ������ԴҪ�����趨�п��ߣ��п������Ч
        m_dgvDropDown.DataSource = dvIntermediate.ToTable

        'ָ��һ��Ҫ��ʾ������
        If (dvIntermediate.Count > m_nVisibleRowCount) Then
            nRowsShow = m_nVisibleRowCount
        Else
            nRowsShow = dvIntermediate.Count
        End If

        '�趨DataGridView��Form��λ�ú�size
        If (dvIntermediate.Count > 0) Then
            Dim ptPoint As Drawing.Point = m_ptPosition
            ptPoint = PointToScreen(ptPoint)
            '��ֹ�����ұ߽糬����
            If m_smDropDownOritation = SNAP_MODE.OnLeft Then
                If ptPoint.X + m_dgvDropDown.Width > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    'm_dgvDropDown.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - ptPoint.X - 2
                    'bHorizonScrollBar = True
                    ptPoint.X = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - m_dgvDropDown.Width - 2
                End If
                '��ֹ������߽糬����
            Else
                ptPoint.X = ptPoint.X + Me.Width - m_dgvDropDown.Width
                If ptPoint.X <= 0 Then
                    'm_dgvDropDown.Width = PointToScreen(m_ptPosition).X + Me.Width - 2
                    ptPoint.X = 2
                    'bHorizonScrollBar = True
                End If
            End If
            '�趨DataGridView�߶�
            If m_dgvDropDown.Rows.Count > 0 Then
                m_dgvDropDown.Height = m_dgvDropDown.Rows(0).Height * nRowsShow + System.Windows.Forms.SystemInformation.BorderSize.Width * 2
                If bHorizonScrollBar Then
                    m_dgvDropDown.Height += System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight
                End If
            Else
                m_dgvDropDown.Height = 0
            End If

            '�趨����size
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
            '����ж�����������뵱ǰѡ���ROW��ID�жԱȣ��������ͬ�շ��ص�ǰѡ����У����򷵻ص�һ��ROW
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
