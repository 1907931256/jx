Imports System.Windows.Forms
Imports System.ComponentModel
Imports ITSBase
Public Class UICheckCombobox

    Private WithEvents m_frmShow As Form
    Private WithEvents m_chblstBox As CheckedListBox
    Private m_plContainer As Panel '������ʾ������ı߿�ֱ����CheckListBox����ʽ�����Ǵ��ڵײ��߾�հף����Բ���panel������
    Private m_ptPosition As Drawing.Point
    Private m_htText As Hashtable '����ѡ��Ľ��
    Private m_dtSource As DataTable '��ǰ�ؼ�����ΪDropDownList������ֱ�Ӳ���Text���ԣ���ҪSource�е�SelectedItem
    Private m_nMaxDropDownItems As Integer
    Private Const CONST_TEXT_DEFAULT_MAX_DROP_DOWN_ITEMS As Integer = 5

    '��ʾ��������
    Public Overloads Property MaxDropDownItems() As Integer
        Get
            Return m_nMaxDropDownItems
        End Get
        Set(ByVal value As Integer)
            m_nMaxDropDownItems = value
        End Set
    End Property
    '��дItems���ԣ��󶨵�CheckListBox�� 
    Public Overloads ReadOnly Property Items() As CheckedListBox.ObjectCollection
        Get
            Return m_chblstBox.Items
        End Get
    End Property

    '��дDataSource���ԣ��󶨵�CheckListBox�ϣ����Ҷ�Combobox��DataSource���Խ��д���
    '���DropDownList���͵�Text��ʾ����Ҫͨ��SelectedItem��ʵ�֣�����ֱ�Ӳ���Text
    Public Overloads Property DataSource() As Object
        Get
            Return m_chblstBox.DataSource
        End Get
        Set(ByVal value As Object)
            MyBase.DataSource = m_dtSource
            MyBase.DisplayMember = TEXT_NAME
            m_chblstBox.DataSource = value
        End Set
    End Property

    '��дDisplayMember���ԣ��󶨵�CheckListBox�� 
    Public Overloads Property DisplayMember() As String
        Get
            Return m_chblstBox.DisplayMember
        End Get
        Set(ByVal value As String)
            m_chblstBox.DisplayMember = value
        End Set
    End Property

    '��дValueMember���ԣ��󶨵�CheckListBox�� 
    Public Overloads Property ValueMember() As String
        Get
            Return m_chblstBox.ValueMember
        End Get
        Set(ByVal value As String)
            m_chblstBox.ValueMember = value
        End Set
    End Property

    '���ص�ǰ��ѡ�е�Textֵ
    Public ReadOnly Property ValueText() As String
        Get
            Return GetShowText()
        End Get
    End Property

    '���ص�ǰ��ѡ�е�Valueֵ����������Դ�󣬶���δ������Դ����ʵû����
    Public ReadOnly Property ValueMembers() As Object()
        Get
            Return CType(m_htText.Keys, Object())
        End Get
    End Property

    '���ص�ǰ��ѡ�е�Text����
    Public ReadOnly Property ValueDisplayMember() As String()
        Get
            Return CType(m_htText.Values, String())
        End Get
    End Property

    '����ѡ�н������
    Public ReadOnly Property Values() As Hashtable
        Get
            Return m_htText
        End Get
    End Property

    Public ReadOnly Property CheckedItems() As CheckedListBox.CheckedItemCollection
        Get
            Return m_chblstBox.CheckedItems
        End Get
    End Property
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        MyBase.DropDownHeight = 1
        m_chblstBox = New CheckedListBox
        m_plContainer = New Panel
        m_frmShow = New Form
        m_htText = New Hashtable
        m_nMaxDropDownItems = CONST_TEXT_DEFAULT_MAX_DROP_DOWN_ITEMS
        Createdt(m_dtSource)
        InitialForm()
    End Sub
    Public Sub ClearChecked()
        m_dtSource.Clear()
        m_htText.Clear()
        If m_chblstBox.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To m_chblstBox.Items.Count - 1
            m_chblstBox.SetItemChecked(i, False)
        Next
    End Sub
    Private Sub Createdt(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_ID, GetType(Long)))
        dt.Columns.Add(New DataColumn(TEXT_NAME, GetType(String)))
    End Sub
    Private Sub InitialForm()
        With m_frmShow
            .FormBorderStyle = FormBorderStyle.None
            .BackColor = Drawing.Color.White
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.Manual
            .Controls.Add(m_plContainer)
            .TopMost = True
            .Font = MyBase.Font
        End With
        With m_plContainer
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .Controls.Add(m_chblstBox)
        End With
        With m_chblstBox
            .Location = New Drawing.Point(0, 0)
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub HideDropDown()
        m_frmShow.Visible = False
    End Sub

    Private Sub ShowDropDown()
        Dim ptPoint As Drawing.Point = m_ptPosition
        ptPoint = PointToScreen(ptPoint)
        If ptPoint.X + m_frmShow.Width > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
            ptPoint.X = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - m_frmShow.Width - 2
        End If
        With m_frmShow
            .Location = ptPoint
            .Visible = True
        End With
        ShowText()
    End Sub

    Private Function GetShowText() As String
        Dim strShowText As String = String.Empty
        For Each strText As String In m_htText.Values
            If strShowText = String.Empty Then
                strShowText += strText
            Else
                strShowText = String.Format("{0},{1}", strShowText, strText)
            End If
        Next
        Return strShowText
    End Function

    Private Sub ShowText()
        If MyBase.DropDownStyle = ComboBoxStyle.DropDownList Then
            m_dtSource.Clear()
            Dim drNew As DataRow = m_dtSource.NewRow
            drNew.Item(TEXT_ID) = 0
            drNew.Item(TEXT_NAME) = GetShowText()
            m_dtSource.Rows.Add(drNew)

            MyBase.SelectedIndex = 0
        Else
            MyBase.Text = GetShowText()
        End If
    End Sub

    Private Sub OnFrmShowResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_frmShow.Resize
        m_frmShow.Width = MyBase.Width
        If m_chblstBox.Items.Count > m_nMaxDropDownItems Then
            m_frmShow.Height = MyBase.FontHeight * (m_nMaxDropDownItems + 1)
        Else
            m_frmShow.Height = MyBase.FontHeight * (m_chblstBox.Items.Count + 1)
        End If
        With m_frmShow
            .Font = MyBase.Font
        End With
    End Sub

    Private Sub OnCheckComboboxDropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DropDown
        If m_frmShow.Visible Then
            HideDropDown()
            '���������ť��ʱ������ϵͳ�Դ���DropDown
            SendKeys.Send("{Escape}")
        Else
            ShowDropDown()
        End If
    End Sub

    Private Sub OnCheckComboboxGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If MyBase.Text.Length >= 0 Then
            m_ptPosition.X = 0
            m_ptPosition.Y = MyBase.Height + 3
        End If
    End Sub

    Private Sub OnCheckComboboxKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            If m_frmShow.Visible Then
                HideDropDown()
            Else
                ShowDropDown()
            End If
            e.Handled = True
        ElseIf e.KeyCode = Keys.Down Then
            ShowDropDown()
        End If
    End Sub

    Private Sub OnCheckComboboxLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        HideDropDown()
    End Sub

    Private Sub OnchblstBoxItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles m_chblstBox.ItemCheck
        If m_chblstBox.DataSource Is Nothing Then
            If e.NewValue = CheckState.Checked Then
                m_htText.Add(e.Index, CType(sender, CheckedListBox).SelectedItem.ToString)
            Else
                m_htText.Remove(e.Index)
            End If
        Else
            If e.NewValue = CheckState.Checked Then
                m_htText.Add(CType(sender, CheckedListBox).SelectedValue, CType(sender, CheckedListBox).Text)
            Else
                m_htText.Remove(CType(sender, CheckedListBox).SelectedValue)
            End If
        End If
        ShowText()
    End Sub

    Private Sub OnchblstBoxKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles m_chblstBox.KeyDown
        If (e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.F4 OrElse e.KeyCode = Keys.Escape) Then
            If m_frmShow.Visible Then
                HideDropDown()
            End If
        End If
    End Sub

    Private Sub OnCheckComboboxVisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Not MyBase.Visible Then
            HideDropDown()
        End If
    End Sub

End Class
