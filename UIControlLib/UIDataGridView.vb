Imports System.Windows.Forms
Imports System.Drawing

Public Class DataGridViewAppearInfo
    Public header_font_size As Single = 0
    Public row_height As Integer = 0
    Public column_header_height As Integer = 0
End Class

Public Class UIDataGridView
    Inherits System.Windows.Forms.DataGridView

#Region "变量定义"
    Private DATAGRID_CONST_STRING_DEFAULT_BUTTON_COLUMN_NAME As String = "删除"
    Private DATAGRID_CONST_STRING_DEFAULT_EDIT_BUTTON_COLUMN_NAME As String = "新增"
    Private DATAGRID_CONST_STRING_DEFAULT_IMG_COLUMN_NAME As String = "图片"
    Private DATAGRID_CONST_STRING_BE_QUERYING As String = "查询中..."
    Private DATAGRID_COLOR_BACKGROUND As Color = Color.FromArgb(244, 247, 252)
    Private DATAGRID_COLOR_HEADER_BACK As Color = Color.FromArgb(201, 204, 209)
    Private DATAGRID_COLOR_SELECTION_BACK As Color = Color.FromArgb(255, 215, 180)
    Private DATAGRID_COLOR_WARNING_BACK As Color = Color.FromArgb(98, 206, 233)
    Private DATAGRID_COLOR_SELECTION_FORE As Color = SystemColors.ControlText
    Private DATAGRID_COLOR_DEFAULT_FORE As Color = SystemColors.ControlText
    Private DATAGRID_ALTER_ROW_BACK_COLOR As Color = Color.FromArgb(237, 242, 246)
    Private DATAGRID_ROW_BACK_COLOR As Color = Color.FromArgb(244, 247, 252)
    Private DATAGRID_COLUMN_HEADER_HEIGHT As Integer = 32
    Private DATAGRID_VER_SCROLLBAR_WIDTH As Integer = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth
    Private Const DATAGRID_CONST_FRAME_MARIGN As Integer = 3
    Private Const DATA_GRID_CONST_BUTTON_COLUMN_WIDTH As Integer = 45
    Private Const DATA_GRID_CONST_CHECK_COLUMN_WIDTH As Integer = 20
    Private Const INVLID_DATA As Integer = -1
    Private Const CHECK_TEXT As String = "√"

    Public Event CurrentRowIndexChanged(ByVal nOldIndex As Integer, ByVal nNewIndex As Integer)
    Public Event InitSelRowIndexEffected(ByVal bEffected As Boolean, ByVal nSelRowIndex As Integer)
    Public Event DataBindingOver()
    Public Event ButtonCellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    Public Event CheckBoxCellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    Private m_bHaveCheckBoxCol As Boolean
    Private m_nCheckBoxColWidth As Integer
    Private m_strCheckBoxColName As String

    Private m_bHaveBtnCol As Boolean
    Private m_bHaveEditBtnCol As Boolean
    Private m_bHaveImgCol As Boolean
    Private m_bHaveComboBoxCol As Boolean

    Private m_strBtnColName As String
    Private m_strBtnEditColName As String

    Private m_bHaveConfirmBtnCol As Boolean
    Private m_strConfirmBtnColName As String
    Private m_nConfrimBtnColWidth As Integer
    Private m_strConfirmBtnColHeadText As String
    Private m_bConfrimBtnWarnColor As Boolean

    Private m_strImgColName As String
    Private m_nBtnColWidth As Integer

    Private m_bHaveLinkCol As Boolean
    Private m_strLinkColName As String
    Private m_nLinkColWidth As Integer
    Private m_strLinkColContent As String

    Private m_bHaveArrLinkCol As Boolean
    Private m_ArrLinkColName As ArrayList
    Private m_ArrLinkColWidth As ArrayList
    Private m_ArrLinkColContent As ArrayList

    Private m_nOldIndex As Integer
    Private m_bAllowSort As Boolean
    Private m_ArrColWidth As Array
    Private m_ArrColReadOnly As Array
    Private m_ArrBoolColumn As ArrayList
    Private m_ArrFormatColumn As ArrayList
    Private m_ArrComboBoxColumn As ArrayList
    Private m_bIsReadOnly As Boolean
    Private m_bShowSelectionRow As Boolean
    Private m_oAppearInfo As DataGridViewAppearInfo
    Private m_nInitSelRowIndex As Integer = 0
    Private m_bDataBindComplete As Boolean = False
    Private m_strMarkColName As String
    Private m_nTotalColWidth As Integer
    Private m_bManualRiseSelChange As Boolean = False 'sometimes, need manual to arise event. eg, on initial, the datagrid will sel the 1st index by default,  
    'after that, when sel the 1st index, it will not arise anymore.
    Private m_aryCombineKey As Array
    Private m_htCombineKeyValue As Hashtable
    Private m_bSelCombineKeyEnable As Boolean
    Private m_strNoItemAlter As String
    Private m_ArrLinkcolumn As ArrayList
    Private m_bBeQuerying As Boolean

    Private m_bSelectChangeRow As Boolean
    Private WithEvents m_dtDatarSource As DataTable
    Private m_eDataSourceChangeType As System.ComponentModel.ListChangedType
#End Region

#Region "结构体定义"
    Public Structure ST_BOOL_COLUMN_INFO
        Dim nIndex As Integer
        Dim strName As System.String
        Dim TrueValue As Object
        Dim FalseValue As Object
        Public Sub New(ByVal bInit As Boolean)
            nIndex = INVLID_DATA
            strName = ""
            TrueValue = True
            FalseValue = False
        End Sub
    End Structure
    Public Structure ST_FORMAT_COLUMN_INFO
        Dim nIndex As Integer
        Dim strName As System.String
        Dim strFormat As System.String
        Public Sub New(ByVal bInit As Boolean)
            nIndex = INVLID_DATA
            strName = ""
            strFormat = ""
        End Sub
    End Structure
    Public Structure ST_COMBOBOX_COLUMN_INFO
        Dim nIndex As Integer
        Dim strName As String
        Dim bReadOnly As Boolean
        Dim arrItemList As ArrayList
        Public Sub New(ByVal bInit As Boolean)
            nIndex = INVLID_DATA
            strName = ""
            bReadOnly = False
            arrItemList = New ArrayList
        End Sub
    End Structure

    Public Structure ST_LINK_COLUMN_INFO
        Dim nIndex As Integer
        Dim strName As String
        Public Sub New(ByVal bInit As Boolean)
            nIndex = INVLID_DATA
            strName = ""
        End Sub
    End Structure
#End Region

#Region "属性"
    Public Overloads Property DataSource() As Object
        Get
            Return MyBase.DataSource
        End Get
        Set(ByVal value As Object)
            MyBase.DataSource = value
            Me.RowReselByCombineKey()
        End Set
    End Property
    Property NoItemAlter() As String
        Get
            Return Me.m_strNoItemAlter
        End Get
        Set(ByVal value As String)
            m_strNoItemAlter = value
        End Set
    End Property

    Property AllowDelete() As Boolean
        Get
            Return Me.AllowUserToDeleteRows
        End Get
        Set(ByVal value As Boolean)
            AllowUserToDeleteRows = value
        End Set
    End Property
    Property BeQuerying() As Boolean
        Get
            Return Me.m_bBeQuerying
        End Get
        Set(ByVal value As Boolean)
            m_bBeQuerying = value
        End Set
    End Property

    Property ChangeHeaderSize() As Boolean
        Get
            Return Me.AllowUserToResizeColumns
        End Get
        Set(ByVal value As Boolean)
            Me.AllowUserToResizeColumns = value
        End Set
    End Property

    Property AllowSort() As Boolean
        Get
            AllowSort = m_bAllowSort
        End Get
        Set(ByVal Value As Boolean)
            m_bAllowSort = Value
            ApplySortable()
        End Set
    End Property

    WriteOnly Property InitSelRowIndex() As Integer 'it will be effect only after the source has been binding
        Set(ByVal Value As Integer)
            m_nInitSelRowIndex = Value
            If m_bDataBindComplete Then
                SetInitSelRowIndex()
            End If
        End Set
    End Property

    WriteOnly Property ColumnWidthCollection() As Array
        Set(ByVal Value As Array)
            Dim total As Single = 0
            For Each item As Single In Value
                total += item
            Next

            'convert to percentage
            If total = 0 Then Return
            Dim i As Integer = 0
            Dim arraySng() As Single = {}
            Array.Resize(arraySng, Value.Length)
            For Each item As Single In Value
                arraySng(i) = item / total
                i += 1
            Next
            m_ArrColWidth = arraySng
            m_nTotalColWidth = -1
        End Set
    End Property
    WriteOnly Property RealColumnWidthCollection() As Array
        Set(ByVal value As Array)
            ColumnWidthCollection = value
            For Each item As Single In value
                m_nTotalColWidth += item
            Next
        End Set
    End Property
    WriteOnly Property ColumnReadOnlyCollection() As Array
        Set(ByVal Value As Array)
            m_ArrColReadOnly = Value
        End Set
    End Property
    ReadOnly Property CurrentDataRow() As DataRow
        Get
            If Me.DataSource Is Nothing OrElse Me.CurrentRow Is Nothing Then
                Return Nothing
            Else
                Return CType(BindingContext(Me.DataSource).Current(), DataRowView).Row
            End If
        End Get
    End Property
    Property ShowSelectionColor() As Boolean
        Get
            ShowSelectionColor = m_bShowSelectionRow
        End Get
        Set(ByVal Value As Boolean)
            m_bShowSelectionRow = Value
        End Set
    End Property
    ReadOnly Property BindingComplete() As Boolean
        Get
            Return m_bDataBindComplete
        End Get
    End Property
    WriteOnly Property BtnColWidth() As Integer
        Set(ByVal value As Integer)
            m_nBtnColWidth = value
        End Set
    End Property
    WriteOnly Property CheckBoxWidth() As Integer
        Set(ByVal value As Integer)
            m_nCheckBoxColWidth = value
        End Set
    End Property
    WriteOnly Property CheckBoxColName() As String
        Set(ByVal value As String)
            m_strCheckBoxColName = value
        End Set
    End Property

    WriteOnly Property BtnColName() As String
        Set(ByVal value As String)
            m_strBtnColName = value
        End Set
    End Property
    WriteOnly Property BtnEditColName() As String
        Set(ByVal value As String)
            m_strBtnEditColName = value
        End Set
    End Property
    WriteOnly Property HaveBtnColumn() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveBtnCol = value
        End Set
    End Property
    WriteOnly Property HaveEditBtnColumn() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveEditBtnCol = value
        End Set
    End Property
    WriteOnly Property HaveImgColumn() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveImgCol = value
        End Set
    End Property
    WriteOnly Property ImgColName() As String
        Set(ByVal value As String)
            m_strImgColName = value
        End Set
    End Property
    WriteOnly Property HaveComboBoxColumn() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveComboBoxCol = value
        End Set
    End Property

    WriteOnly Property HaveCheckBoxColumn() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveCheckBoxCol = value
        End Set
    End Property
    WriteOnly Property LinkColWidth() As Integer
        Set(ByVal value As Integer)
            m_nLinkColWidth = value
        End Set
    End Property
    WriteOnly Property LinkColName() As String
        Set(ByVal value As String)
            m_strLinkColName = value
        End Set
    End Property
    WriteOnly Property LinkColContent() As String
        Set(ByVal value As String)
            m_strLinkColContent = value
        End Set
    End Property

    WriteOnly Property HaveLinkColumn() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveLinkCol = value
        End Set
    End Property
    WriteOnly Property CombineKeyCollection() As Array
        Set(ByVal value As Array)
            m_aryCombineKey = value
            InitCombineKey()
        End Set
    End Property
    Public Property SelCombineKeyEnable() As Boolean
        Get
            Return m_bSelCombineKeyEnable
        End Get
        Set(ByVal value As Boolean)
            m_bSelCombineKeyEnable = value
            If value Then
                RowReselByCombineKey()
            End If
        End Set
    End Property

    Public Property AllowSelectChangeRow() As Boolean
        Get
            Return m_bSelectChangeRow
        End Get
        Set(ByVal value As Boolean)
            m_bSelectChangeRow = value
        End Set
    End Property

#Region "ConfirmBtnCol"
    WriteOnly Property HaveConfirmBtnColumn() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveConfirmBtnCol = value
        End Set
    End Property
    WriteOnly Property ConfirmBtnColName() As String
        Set(ByVal value As String)
            m_strConfirmBtnColName = value
        End Set
    End Property
    WriteOnly Property ConfirmBtnColWidth() As Integer
        Set(ByVal value As Integer)
            m_nConfrimBtnColWidth = value
        End Set
    End Property
    WriteOnly Property ConfirmBtnColHeadText() As String
        Set(ByVal value As String)
            m_strConfirmBtnColHeadText = value
        End Set
    End Property

    WriteOnly Property ConfirmBtnColWarnColor() As Boolean
        Set(ByVal value As Boolean)
            m_bConfrimBtnWarnColor = value
        End Set
    End Property

    ReadOnly Property WarningColor() As Color
        Get
            Return DATAGRID_COLOR_WARNING_BACK
        End Get
    End Property
#End Region

#Region "ArrLinkBtn"
    Public WriteOnly Property HaveArrLinkCol() As Boolean
        Set(ByVal value As Boolean)
            m_bHaveArrLinkCol = value
        End Set
    End Property
    Public WriteOnly Property ArrLinkColName() As String()
        Set(ByVal value As String())
            m_ArrLinkColName = New ArrayList
            For Each strName As String In value
                m_ArrLinkColName.Add(strName)
            Next
        End Set
    End Property
    Public WriteOnly Property ArrLinkColWidth() As Short()
        Set(ByVal value As Short())
            m_ArrLinkColWidth = New ArrayList
            For Each shWidth As Short In value
                m_ArrLinkColWidth.Add(shWidth)
            Next
        End Set
    End Property
    Public WriteOnly Property ArrLinkColContent() As String()
        Set(ByVal value As String())
            m_ArrLinkColContent = New ArrayList
            For Each strContent As String In value
                m_ArrLinkColContent.Add(strContent)
            Next
        End Set
    End Property
#End Region

    Private Sub InitCombineKey()
        If m_aryCombineKey Is Nothing Then
            m_htCombineKeyValue.Clear()
            Return
        End If
        'clear the key which is not in the m_aryCombineKey but m_htCombineKeyValue
        Dim lstKeys As New List(Of String)
        Dim em As IDictionaryEnumerator = m_htCombineKeyValue.GetEnumerator
        While em.MoveNext
            If -1 = Array.IndexOf(m_aryCombineKey, em.Key.ToString) Then 'can't find,need to discard
                lstKeys.Add(em.Key.ToString)
            End If
        End While
        For Each strRemoveKey As String In lstKeys
            m_htCombineKeyValue.Remove(strRemoveKey)
        Next
        For Each strCol As String In m_aryCombineKey
            If m_htCombineKeyValue.Contains(strCol) = False Then 'not contain the Key
                m_htCombineKeyValue.Add(strCol, "")
            End If
        Next
    End Sub

    Private ReadOnly Property InternalWidth() As Integer
        Get
            Dim nTotalColWidth As Integer = IIf(m_nTotalColWidth <= 0, Me.Width, m_nTotalColWidth)
            If m_bHaveBtnCol Then nTotalColWidth -= m_nBtnColWidth
            If m_bHaveLinkCol Then nTotalColWidth -= m_nLinkColWidth
            If m_bHaveCheckBoxCol Then nTotalColWidth -= m_nCheckBoxColWidth
            If m_bHaveEditBtnCol Then nTotalColWidth -= m_nBtnColWidth
            If m_bHaveImgCol Then nTotalColWidth -= m_nBtnColWidth
            If m_bHaveConfirmBtnCol Then nTotalColWidth -= m_nConfrimBtnColWidth
            If m_bHaveArrLinkCol Then
                For Each shWidth As Short In m_ArrLinkColWidth
                    nTotalColWidth -= shWidth
                Next
            End If
            Return nTotalColWidth
        End Get
    End Property

#End Region

#Region "方法"
    Public Sub New()
        MyBase.New()
        m_bAllowSort = True
        m_bShowSelectionRow = True
        m_ArrColReadOnly = Nothing
        m_ArrColWidth = Nothing
        m_aryCombineKey = Nothing
        m_bIsReadOnly = True
        m_nOldIndex = -1
        m_nTotalColWidth = -1
        m_strMarkColName = ""
        m_bHaveBtnCol = False
        m_bHaveEditBtnCol = False
        m_bHaveImgCol = False
        m_bHaveComboBoxCol = False
        m_bHaveCheckBoxCol = False
        m_bConfrimBtnWarnColor = False
        m_bHaveArrLinkCol = False
        m_ArrLinkColContent = Nothing
        m_ArrLinkColName = Nothing
        m_ArrLinkColWidth = Nothing
        m_strBtnEditColName = DATAGRID_CONST_STRING_DEFAULT_EDIT_BUTTON_COLUMN_NAME
        m_strImgColName = DATAGRID_CONST_STRING_DEFAULT_IMG_COLUMN_NAME
        m_strBtnColName = DATAGRID_CONST_STRING_DEFAULT_BUTTON_COLUMN_NAME
        m_strCheckBoxColName = ""
        m_nBtnColWidth = DATA_GRID_CONST_BUTTON_COLUMN_WIDTH
        m_nCheckBoxColWidth = DATA_GRID_CONST_CHECK_COLUMN_WIDTH
        m_bHaveLinkCol = False
        m_strLinkColName = DATAGRID_CONST_STRING_DEFAULT_BUTTON_COLUMN_NAME
        m_nLinkColWidth = DATA_GRID_CONST_BUTTON_COLUMN_WIDTH
        m_strLinkColContent = ""
        m_htCombineKeyValue = New Hashtable
        m_bSelCombineKeyEnable = False
        m_strNoItemAlter = String.Empty
        m_bSelectChangeRow = False
        m_dtDatarSource = New DataTable
        m_eDataSourceChangeType = System.ComponentModel.ListChangedType.Reset
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        With Me
            .EnableHeadersVisualStyles = False
            .BackgroundColor = DATAGRID_COLOR_BACKGROUND
            .RowHeadersVisible = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToAddRows = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = DATAGRID_COLUMN_HEADER_HEIGHT
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowsDefaultCellStyle.BackColor = DATAGRID_ROW_BACK_COLOR
            .AlternatingRowsDefaultCellStyle.BackColor = DATAGRID_ALTER_ROW_BACK_COLOR
            .RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.ForeColor = DATAGRID_COLOR_DEFAULT_FORE
            .DefaultCellStyle.SelectionForeColor = DATAGRID_COLOR_SELECTION_FORE
            MultiSelect = False
        End With
    End Sub

    Private Sub ApplySortable()
        For Each column As DataGridViewColumn In Me.Columns
            If Me.m_bAllowSort Then
                column.SortMode = DataGridViewColumnSortMode.Automatic
            Else
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            End If
        Next
    End Sub

    Protected Overrides Sub OnDataSourceChanged(ByVal e As System.EventArgs)
        m_bIsReadOnly = True
        Dim dtDataGrid As DataTable = CType(Me.DataSource, DataTable)
        If dtDataGrid Is Nothing Then Exit Sub

        'record data source
        m_dtDatarSource = dtDataGrid
        'initial the datagridview
        Me.AllowUserToAddRows = False
        Me.AllowUserToResizeRows = False
        Me.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.AutoGenerateColumns = False
        Me.RowHeadersVisible = False
        'end initial
        Dim colHeaderCellStyle As New DataGridViewCellStyle
        With colHeaderCellStyle
            .BackColor = DATAGRID_COLOR_HEADER_BACK
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Me.ColumnHeadersDefaultCellStyle = colHeaderCellStyle
        Me.Columns.Clear()

        CreateCheckBoxColumn()
        For Each dtColumn As DataColumn In dtDataGrid.Columns
            Dim csColumn As Object = CreateColumnStyle(dtDataGrid, dtColumn)
            Dim ColumnWidth As Integer = 0
            Dim nTotalColWidth As Integer = Me.InternalWidth
            If m_ArrColWidth Is Nothing OrElse m_ArrColWidth.Length < dtDataGrid.Columns.Count Then
                ColumnWidth = (Me.Font.Size * dtColumn.ColumnName.Length + 20)
            Else
                ColumnWidth = m_ArrColWidth(dtDataGrid.Columns.IndexOf(dtColumn)) * (nTotalColWidth - DATAGRID_VER_SCROLLBAR_WIDTH - DATAGRID_CONST_FRAME_MARIGN)
            End If
            csColumn.Width = ColumnWidth

            If ColumnWidth > 0 Then
                Me.Columns.Add(csColumn)
            End If
        Next
        CreateExtraColumnStyle()
    End Sub

    Private Function CreateColumnStyle(ByVal dtDataGrid As DataTable, ByVal dtColumn As DataColumn) As Object
        Dim stComboBoxColumn As New ST_COMBOBOX_COLUMN_INFO(True)
        Dim csColumn As Object
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .Alignment = HorizontalAlignment.Center
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
            .SelectionForeColor = DATAGRID_COLOR_SELECTION_FORE
        End With
        If CheckComboBoxColumn(dtDataGrid.Columns.IndexOf(dtColumn), dtColumn.ColumnName, stComboBoxColumn) Then
            csColumn = New DataGridViewComboBoxColumn
            With CType(csColumn, DataGridViewComboBoxColumn)
                .DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
                .DropDownWidth = 4
                .Resizable = System.Windows.Forms.DataGridViewTriState.[True]
                .Items.AddRange(stComboBoxColumn.arrItemList.ToArray)
                .ReadOnly = stComboBoxColumn.bReadOnly
            End With
            m_bIsReadOnly = stComboBoxColumn.bReadOnly
        ElseIf CheckLinkColumn(dtDataGrid.Columns.IndexOf(dtColumn), dtColumn.ColumnName) Then
            csColumn = New DataGridViewLinkColumn
        Else
            csColumn = New UIDataGridViewTextBoxColumn
            With CType(csColumn, UIDataGridViewTextBoxColumn)
                Dim stColumn As New ST_BOOL_COLUMN_INFO(True)
                If CheckBoolColumn(dtDataGrid.Columns.IndexOf(dtColumn), dtColumn.ColumnName, stColumn) Then
                    .ReadOnly = True
                    .BoolStyle = True
                    .TrueValue = stColumn.TrueValue
                    .FalseValue = stColumn.FalseValue
                Else
                    If m_ArrColReadOnly Is Nothing OrElse m_ArrColReadOnly.Length < dtDataGrid.Columns.Count Then
                        .ReadOnly = True
                    Else
                        .ReadOnly = m_ArrColReadOnly(dtDataGrid.Columns.IndexOf(dtColumn))
                    End If
                End If
                If Not .ReadOnly Then
                    m_bIsReadOnly = False
                End If

                Dim stFormatColumn As New ST_FORMAT_COLUMN_INFO(True)
                If CheckFormatColumn(dtDataGrid.Columns.IndexOf(dtColumn), dtColumn.ColumnName, stFormatColumn) Then
                    colCellStyle.Format = stFormatColumn.strFormat
                End If
            End With
        End If
        With CType(csColumn, DataGridViewColumn)
            .DataPropertyName = dtColumn.ColumnName.ToString
            .HeaderText = dtColumn.ColumnName.ToString
            .Name = dtColumn.ColumnName.ToString
            If Me.m_bAllowSort Then
                .SortMode = DataGridViewColumnSortMode.Automatic
            Else
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End If
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function
    Private Sub CreateCheckBoxColumn()
        'Add CheckBox
        If m_bHaveCheckBoxCol Then
            Dim csColumn As UIDataGridViewCheckBoxColumn = CreateCheckBoxColumnStyle()
            csColumn.Width = m_nCheckBoxColWidth
            Me.Columns.Add(csColumn)
        End If
    End Sub
    Private Sub CreateExtraColumnStyle()
        'Add the delete button column
        If m_bHaveBtnCol Then
            Dim csColumn As UIDataGridViewDelBtnColumn = CreateDelBtnColumnStyle()
            csColumn.Width = m_nBtnColWidth
            Me.Columns.Add(csColumn)
        End If
        If m_bHaveEditBtnCol Then
            Dim csColumn As UIDataGridViewEditBtnColumn = CreateEditBtnColumnStyle()
            csColumn.Width = m_nBtnColWidth
            Me.Columns.Add(csColumn)
        End If

        If m_bHaveImgCol Then
            Dim csColumn As UIDataGridViewImgColumn = CreateImgColumnStyle()
            csColumn.Width = m_nBtnColWidth
            Me.Columns.Add(csColumn)
        End If

        'add linkbutton
        If m_bHaveLinkCol Then
            Dim csColumn As UIDataGridViewLinkColumn = CreateLinkColumnStyle()
            csColumn.Width = m_nLinkColWidth
            Me.Columns.Add(csColumn)
        End If

        'Add confirm button at 2013-04-09 
        If m_bHaveConfirmBtnCol Then
            Dim csColumn As UIDataGridViewOKBtnColumn = CreateConfirmBtnColStyle()
            csColumn.Width = m_nConfrimBtnColWidth
            Me.Columns.Add(csColumn)
        End If

        'add arr link button by mpy as 2014-01-20
        If m_bHaveArrLinkCol = True Then
            For i As Integer = 0 To m_ArrLinkColName.Count - 1
                Dim csColumn As UIDataGridViewLinkColumn = CreateLinkColumnStyle(m_ArrLinkColName(i).ToString)
                csColumn.Width = CShort(m_ArrLinkColWidth(i))
                csColumn.Tag = m_ArrLinkColContent(i)
                Me.Columns.Add(csColumn)
            Next
        End If
    End Sub

    Private Function CreateCheckBoxColumnStyle() As UIDataGridViewCheckBoxColumn
        Dim csColumn As New UIDataGridViewCheckBoxColumn
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
        End With
        With csColumn
            .DataPropertyName = m_strCheckBoxColName
            .HeaderText = m_strCheckBoxColName
            .Name = m_strCheckBoxColName
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function

    Private Function CreateDelBtnColumnStyle() As UIDataGridViewDelBtnColumn
        Dim csColumn As New UIDataGridViewDelBtnColumn
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
        End With
        With CType(csColumn, DataGridViewColumn)
            .DataPropertyName = m_strBtnColName
            .HeaderText = m_strBtnColName
            .Name = m_strBtnColName
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function
    Private Function CreateEditBtnColumnStyle() As UIDataGridViewEditBtnColumn
        Dim csColumn As New UIDataGridViewEditBtnColumn
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
        End With
        With CType(csColumn, DataGridViewColumn)
            .DataPropertyName = m_strBtnEditColName
            .HeaderText = m_strBtnEditColName
            .Name = m_strBtnEditColName
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function

    Private Function CreateImgColumnStyle() As UIDataGridViewImgColumn
        Dim csColumn As New UIDataGridViewImgColumn
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
        End With
        With CType(csColumn, DataGridViewColumn)
            .DataPropertyName = m_strImgColName
            .HeaderText = m_strImgColName
            .Name = m_strImgColName
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function

    Private Function CreateLinkColumnStyle() As UIDataGridViewLinkColumn
        Dim csColumn As New UIDataGridViewLinkColumn
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
        End With
        With CType(csColumn, DataGridViewColumn)
            .DataPropertyName = m_strLinkColName
            .HeaderText = m_strLinkColName
            .Name = m_strLinkColName
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function
    Private Function CreateLinkColumnStyle(ByVal strName As String) As UIDataGridViewLinkColumn
        Dim csColumn As New UIDataGridViewLinkColumn
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
        End With
        With CType(csColumn, DataGridViewColumn)
            .DataPropertyName = strName
            .HeaderText = strName
            .Name = strName
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function
    Private Function CreateConfirmBtnColStyle() As UIDataGridViewOKBtnColumn
        Dim csColumn As New UIDataGridViewOKBtnColumn
        Dim colCellStyle As New DataGridViewCellStyle
        With colCellStyle
            .SelectionBackColor = DATAGRID_COLOR_SELECTION_BACK
        End With
        With CType(csColumn, DataGridViewColumn)
            .DataPropertyName = m_strConfirmBtnColName
            .HeaderText = m_strConfirmBtnColHeadText
            .Name = m_strConfirmBtnColName
            .DefaultCellStyle = colCellStyle
        End With
        Return csColumn
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        'commented by fb 04-11-03
        '是否需要对回车消息进行处理？回车应该相对于双击消息

        Dim WM_KEYDOWN As Integer = 256  '消息响应值

        Dim WM_SYSKEYDOWN As Integer = 260

        If ((msg.Msg = WM_KEYDOWN) Or (msg.Msg = WM_SYSKEYDOWN)) Then

            Select Case keyData
                Case Keys.Left, Keys.Right, Keys.Tab
                    Return True
                Case Keys.Delete
                    If m_bIsReadOnly OrElse Not Me.AllowUserToDeleteRows Then
                        Return True
                    End If
                Case Keys.Down
                    SendKeys.Send("^")
                Case Keys.Up
                    If Me.CurrentRow IsNot Nothing AndAlso Me.CurrentRow.Index = 0 Then
                        Return True
                    End If
                    SendKeys.Send("^")
                Case Keys.PageDown
                    SendKeys.Send("^")
                Case Keys.PageUp
                    If Me.CurrentRow IsNot Nothing AndAlso Me.CurrentRow.Index = 0 Then
                        Return True
                    End If
                    SendKeys.Send("^")
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub ClearBoolColumn()
        If m_ArrBoolColumn Is Nothing Then Exit Sub
        m_ArrBoolColumn.Clear()
    End Sub
    Public Sub SetBoolColumn(ByVal nIndex As Integer, ByVal TrueValue As Object, ByVal FalseValue As Object)
        Dim stColumn As ST_BOOL_COLUMN_INFO = New ST_BOOL_COLUMN_INFO(True)
        stColumn.nIndex = nIndex
        stColumn.TrueValue = TrueValue
        stColumn.FalseValue = FalseValue
        SetBoolColumn(stColumn)
    End Sub
    Public Sub SetBoolColumn(ByVal strName As String, ByVal TrueValue As Object, ByVal FalseValue As Object)
        Dim stColumn As ST_BOOL_COLUMN_INFO = New ST_BOOL_COLUMN_INFO(True)
        stColumn.strName = strName
        stColumn.TrueValue = TrueValue
        stColumn.FalseValue = FalseValue

        SetBoolColumn(stColumn)
    End Sub
    Private Sub SetBoolColumn(ByVal stColumn As ST_BOOL_COLUMN_INFO)
        If m_ArrBoolColumn Is Nothing Then m_ArrBoolColumn = New ArrayList
        m_ArrBoolColumn.Add(stColumn)
    End Sub
    Private Function CheckBoolColumn(ByVal nIndex As Integer, ByVal strName As String, ByRef stColumn As ST_BOOL_COLUMN_INFO) As Boolean
        If m_ArrBoolColumn Is Nothing Then Return False

        For Each stTemp As ST_BOOL_COLUMN_INFO In m_ArrBoolColumn
            If stTemp.strName = strName OrElse stTemp.nIndex = nIndex Then
                stColumn = stTemp
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub ClearFormatColumn()
        If m_ArrFormatColumn Is Nothing Then Exit Sub
        m_ArrFormatColumn.Clear()
    End Sub
    Public Sub SetFormatColumn(ByVal nIndex As Integer, ByVal strFormat As String)
        Dim stColumn As ST_FORMAT_COLUMN_INFO = New ST_FORMAT_COLUMN_INFO(True)
        stColumn.nIndex = nIndex
        stColumn.strFormat = strFormat
        SetFormatColumn(stColumn)
    End Sub
    Public Sub SetFormatColumn(ByVal strName As String, ByVal strFormat As String)
        Dim stColumn As ST_FORMAT_COLUMN_INFO = New ST_FORMAT_COLUMN_INFO(True)
        stColumn.strName = strName
        stColumn.strFormat = strFormat

        SetFormatColumn(stColumn)
    End Sub
    Private Sub SetFormatColumn(ByVal stColumn As ST_FORMAT_COLUMN_INFO)
        If m_ArrFormatColumn Is Nothing Then m_ArrFormatColumn = New ArrayList
        m_ArrFormatColumn.Add(stColumn)
    End Sub
    Private Function CheckFormatColumn(ByVal nIndex As Integer, ByVal strName As String, ByRef stColumn As ST_FORMAT_COLUMN_INFO) As Boolean
        If m_ArrFormatColumn Is Nothing Then Return False

        For Each stTemp As ST_FORMAT_COLUMN_INFO In m_ArrFormatColumn
            If stTemp.strName = strName OrElse stTemp.nIndex = nIndex Then
                stColumn = stTemp
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub ClearComboBoxColumn()
        If m_ArrComboBoxColumn Is Nothing Then Exit Sub
        m_ArrComboBoxColumn.Clear()
    End Sub
    Public Sub SetReadOnlyComboBoxColumn(ByVal strName As String, ByVal bReadOnly As Boolean)
        Dim stComboBoxColumn As ST_COMBOBOX_COLUMN_INFO = New ST_COMBOBOX_COLUMN_INFO(True)

        For Each dtColumn As DataGridViewColumn In Me.Columns
            If dtColumn.Name = strName Then
                If CheckComboBoxColumn(0, strName, stComboBoxColumn) Then
                    stComboBoxColumn.bReadOnly = bReadOnly
                    dtColumn.ReadOnly = bReadOnly
                End If
            End If
        Next
    End Sub
    Public Sub SetComboBoxColumn(ByVal nIndex As Integer, ByVal arrItem As ArrayList)
        Dim stColumn As ST_COMBOBOX_COLUMN_INFO = New ST_COMBOBOX_COLUMN_INFO(True)
        stColumn.nIndex = nIndex
        stColumn.arrItemList = arrItem
        SetComboBoxColumn(stColumn)
    End Sub
    Public Sub SetComboBoxColumn(ByVal strName As String, ByVal arrItem As ArrayList, ByVal bReadOnly As Boolean)
        Dim stColumn As ST_COMBOBOX_COLUMN_INFO = New ST_COMBOBOX_COLUMN_INFO(True)
        stColumn.strName = strName
        stColumn.arrItemList = arrItem
        stColumn.bReadOnly = bReadOnly

        SetComboBoxColumn(stColumn)
    End Sub
    Private Sub SetComboBoxColumn(ByVal stColumn As ST_COMBOBOX_COLUMN_INFO)
        If m_ArrComboBoxColumn Is Nothing Then m_ArrComboBoxColumn = New ArrayList
        m_ArrComboBoxColumn.Add(stColumn)
    End Sub
    Private Function CheckComboBoxColumn(ByVal nIndex As Integer, ByVal strName As String, ByRef stColumn As ST_COMBOBOX_COLUMN_INFO) As Boolean
        If m_ArrComboBoxColumn Is Nothing Then Return False

        For Each stTemp As ST_COMBOBOX_COLUMN_INFO In m_ArrComboBoxColumn
            If stTemp.strName = strName OrElse stTemp.nIndex = nIndex Then
                stColumn = stTemp
                Return True
            End If
        Next

        Return False
    End Function
    '''''''''''' add Link Column'''''''''''''''''
    Public Sub ClearLinkColumn()
        If m_ArrLinkcolumn Is Nothing Then Exit Sub
        m_ArrLinkcolumn.Clear()
    End Sub
    Public Sub SetLinkColumn(ByVal nIndex As Integer)
        Dim stColumn As ST_LINK_COLUMN_INFO = New ST_LINK_COLUMN_INFO(True)
        stColumn.nIndex = nIndex
        SetLinkColumn(stColumn)
    End Sub
    Public Sub SetLinkColumn(ByVal strName As String)
        Dim stColumn As ST_LINK_COLUMN_INFO = New ST_LINK_COLUMN_INFO(True)
        stColumn.strName = strName
        SetLinkColumn(stColumn)
    End Sub
    Private Sub SetLinkColumn(ByVal stColumn As ST_LINK_COLUMN_INFO)
        If m_ArrLinkcolumn Is Nothing Then m_ArrLinkcolumn = New ArrayList
        m_ArrLinkcolumn.Add(stColumn)
    End Sub
    Private Function CheckLinkColumn(ByVal nIndex As Integer, ByVal strName As String) As Boolean
        If m_ArrLinkcolumn Is Nothing Then Return False

        For Each stTemp As ST_LINK_COLUMN_INFO In m_ArrLinkcolumn
            If stTemp.strName = strName OrElse stTemp.nIndex = nIndex Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub SetLinkCell(ByVal strName As String, ByVal strCont As String)
        If Me.Columns.Contains(strName) Then
            For Each dDataRow As DataGridViewRow In Me.Rows
                Dim cCell As DataGridViewCell = dDataRow.Cells(strName)
                If cCell.Value.ToString = strCont Then
                    Dim dlinkCell As DataGridViewLinkCell = New DataGridViewLinkCell
                    dlinkCell.Value = cCell.Value
                    dlinkCell.Style = cCell.Style
                    Me.Rows(cCell.RowIndex).Cells(strName) = dlinkCell
                End If
            Next
        End If
    End Sub
    '''''''''End Link Column ''''''''''''''
    Private Sub RowReselByCombineKey()
        If m_htCombineKeyValue Is Nothing OrElse m_htCombineKeyValue.Count = 0 Then Return
        For Each row As DataGridViewRow In Me.Rows
            If IsRowFitCombineKey(row) Then
                row.Selected = True
                Me.CurrentCell = row.Cells(0)
                Return
            End If
        Next
    End Sub
    Private Function IsRowFitCombineKey(ByVal row As DataGridViewRow) As Boolean
        Dim em As IDictionaryEnumerator = m_htCombineKeyValue.GetEnumerator
        While em.MoveNext
            If row.DataGridView.Columns.Contains(em.Key.ToString) Then
                If String.Compare(row.Cells(em.Key.ToString).Value, em.Value, True) <> 0 Then 'the same
                    Return False
                End If
            Else
                Return False
            End If
        End While
        Return True
    End Function
    Private Sub SetCombineKeyValue(ByVal nSelIndex As Integer)
        If m_htCombineKeyValue Is Nothing OrElse m_htCombineKeyValue.Count = 0 Then Return
        If nSelIndex < 0 OrElse nSelIndex >= Me.Rows.Count Then
            ClearCombineKey()
        Else
            Dim oFirstSelRow As DataGridViewRow = Me.Rows.Item(nSelIndex)
            'clear the m_htCombineKeyValue's value
            InitCombineKey()
            For Each col As DataGridViewColumn In Me.Columns
                If m_htCombineKeyValue.Contains(col.Name) Then
                    m_htCombineKeyValue.Item(col.Name) = oFirstSelRow.Cells(col.Name).Value
                End If
            Next
        End If
    End Sub
    Public Sub ClearCombineKey()
        m_htCombineKeyValue.Clear()
    End Sub
    Protected Overrides Sub OnCellMouseDoubleClick(ByVal e As DataGridViewCellMouseEventArgs)
        If e.RowIndex >= 0 Then
            MyBase.OnCellMouseDoubleClick(e)
        End If
    End Sub

    Protected Overrides Sub OnCellClick(ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim nCurRow As Integer = CurrentCell.RowIndex
            Dim nCurCol As Integer = CurrentCell.ColumnIndex
            If nCurRow <> e.RowIndex OrElse nCurCol <> e.ColumnIndex Then
                Me.CurrentCell = Me.Item(e.ColumnIndex, e.RowIndex)
            End If
            If Not Me.Columns.Item(e.ColumnIndex).ReadOnly Then
                Me.BeginEdit(True)
            End If
            MyBase.OnCellClick(e)
        End If
    End Sub

    Protected Overrides Sub OnCurrentCellChanged(ByVal e As System.EventArgs)
        Dim curDataTable As DataTable = CType(Me.DataSource, DataTable)
        Dim curRow As DataGridViewRow = Me.CurrentRow
        If Not curDataTable Is Nothing AndAlso Not curRow Is Nothing Then
            If Me.CurrentRow.Index >= 0 AndAlso Me.CurrentRow.Index <> m_nOldIndex Then
                m_bManualRiseSelChange = False
                RaiseCurrentRowIndexChanged(m_nOldIndex, Me.CurrentRow.Index)
                m_nOldIndex = Me.CurrentRow.Index
            End If
        End If

        MyBase.OnCurrentCellChanged(e)
    End Sub

    Private Sub RaiseCurrentRowIndexChanged(ByVal nOldIndex As Integer, ByVal nNewIndex As Integer)
        'when datasource reset, it will reset the index to 0 by default.
        If m_bSelCombineKeyEnable Then SetCombineKeyValue(nNewIndex) 'only if not on DataSourcing binding can reset the combinekey
        RaiseEvent CurrentRowIndexChanged(nOldIndex, nNewIndex)
    End Sub

    Protected Overrides Sub OnCellFormatting(ByVal e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Return
        If TypeOf Columns.Item(e.ColumnIndex) Is UIDataGridViewTextBoxColumn Then
            Dim CellColumn As UIDataGridViewTextBoxColumn = CType(Me.Columns.Item(e.ColumnIndex), UIDataGridViewTextBoxColumn)
            If CellColumn.BoolStyle Then 'if it is bool style, own draw it.
                FormatBoolStyleCell(e, CellColumn)
            End If
        End If

        If Me.ShowSelectionColor = False Then 'if not not now selection rows
            If Rows(e.RowIndex).Selected Then
                Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
                e.CellStyle.SelectionBackColor = cr
            End If
        End If

        If Me.m_bHaveBtnCol AndAlso TypeOf (Me.Columns.Item(e.ColumnIndex)) Is UIDataGridViewDelBtnColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            End If
            Dim btnCell As UIDataGridViewDelBtnCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), UIDataGridViewDelBtnCell)
            btnCell.BackColor = cr
        End If

        If Me.m_bHaveEditBtnCol AndAlso TypeOf (Me.Columns.Item(e.ColumnIndex)) Is UIDataGridViewEditBtnColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            End If
            Dim btnCell As UIDataGridViewEditBtnCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), UIDataGridViewEditBtnCell)
            btnCell.BackColor = cr
        End If

        '在此处理，单元格图片
        If Me.m_bHaveImgCol AndAlso TypeOf (Me.Columns.Item(e.ColumnIndex)) Is UIDataGridViewImgColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            End If
            Dim btnCell As UIDataGridViewImgCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), UIDataGridViewImgCell)
            btnCell.BackColor = cr
            'Dim oIMAGE_LIST As IMAGE_LIST = CType(btnCell.ImageList, IMAGE_LIST)
            'btnCell.SetImageList(My.Resources.ResourceManager.GetObject(oIMAGE_LIST.ToString, My.Resources.Culture), _
            '                    My.Resources.ResourceManager.GetObject(oIMAGE_LIST.ToString, My.Resources.Culture), _
            '                    My.Resources.ResourceManager.GetObject(oIMAGE_LIST.ToString, My.Resources.Culture))
        End If


        If Me.m_bHaveLinkCol AndAlso TypeOf (Me.Columns.Item(e.ColumnIndex)) Is UIDataGridViewLinkColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            End If
            Dim btnCell As UIDataGridViewLinkCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), UIDataGridViewLinkCell)
            btnCell.BackColor = cr
            btnCell.Value = m_strLinkColContent
        End If

        'add arr link button by mpy as 2014-01-20
        If m_bHaveArrLinkCol = True AndAlso TypeOf (Me.Columns.Item(e.ColumnIndex)) Is UIDataGridViewLinkColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            End If
            Dim btnCell As UIDataGridViewLinkCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), UIDataGridViewLinkCell)
            btnCell.BackColor = cr
            btnCell.Value = Me.Columns(e.ColumnIndex).Tag.ToString
        End If

        If Me.m_bHaveCheckBoxCol AndAlso TypeOf (Me.Columns.Item(e.ColumnIndex)) Is UIDataGridViewCheckBoxColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            End If
            Dim chbCell As UIDataGridViewCheckBoxCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), UIDataGridViewCheckBoxCell)
            chbCell.BackColor = cr
        End If

        If TypeOf (Me.Columns.Item(e.ColumnIndex)) Is DataGridViewComboBoxColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            End If
            Dim CellColumn As DataGridViewComboBoxColumn = CType(Me.Columns.Item(e.ColumnIndex), DataGridViewComboBoxColumn)
            Dim btnCell As DataGridViewComboBoxCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell)
            e.Value = btnCell.Value
        End If

        If TypeOf (Me.Columns.Item(e.ColumnIndex)) Is UIDataGridViewOKBtnColumn Then
            Dim cr As Color = IIf(e.RowIndex Mod 2, Me.AlternatingRowsDefaultCellStyle.BackColor, Me.RowsDefaultCellStyle.BackColor)
            Dim CellColumn As UIDataGridViewOKBtnColumn = CType(Me.Columns.Item(e.ColumnIndex), UIDataGridViewOKBtnColumn)
            Dim btnCell As UIDataGridViewOKBtnCell = CType(Me.Item(e.ColumnIndex, e.RowIndex), UIDataGridViewOKBtnCell)
            If Me.ShowSelectionColor AndAlso Me.Rows.Item(e.RowIndex).Selected Then
                cr = Me.Columns.Item(e.ColumnIndex).DefaultCellStyle.SelectionBackColor
            ElseIf btnCell.Value IsNot Nothing AndAlso m_bConfrimBtnWarnColor AndAlso Not String.IsNullOrEmpty(btnCell.Value.ToString) Then
                cr = DATAGRID_COLOR_WARNING_BACK
            End If
           
            btnCell.BackColor = cr
            e.Value = btnCell.Value
        End If

    End Sub

    Private Sub FormatBoolStyleCell(ByVal e As DataGridViewCellFormattingEventArgs, ByVal CellColumn As UIDataGridViewTextBoxColumn)
        If e.Value = CellColumn.TrueValue Then
            e.Value = CHECK_TEXT
        Else
            e.Value = CStr("")
        End If
    End Sub

    Public Sub UpdateColumnsWidth()
        ResetColumnWidth()
    End Sub

    ''"""""""""""""""""About the resize""""""""""""""""""""""
    Public Sub ResizeRegister()
        m_oAppearInfo = New DataGridViewAppearInfo
        If Me.ColumnHeadersDefaultCellStyle IsNot Nothing AndAlso Me.ColumnHeadersDefaultCellStyle.Font IsNot Nothing Then
            m_oAppearInfo.header_font_size = ColumnHeadersDefaultCellStyle.Font.Size
        Else
            m_oAppearInfo.header_font_size = 12.0!
        End If
        m_oAppearInfo.column_header_height = Me.ColumnHeadersHeight
        m_oAppearInfo.row_height = Me.RowTemplate.Height
    End Sub

    Public Sub ResizeDetailImp(ByVal dXScale As Double, ByVal dyScale As Double)
        If dXScale <= 0.0 OrElse dyScale <= 0.0 Then
            Return
        End If

        'resize the column width
        ResetColumnWidth()
        'resize the column head's height and other row's height
        'Me.ColumnHeadersHeight = dyScale * m_oAppearInfo.column_header_height
        'Me.RowTemplate.Height = dyScale * m_oAppearInfo.row_height
        'resize header font size
        'If Not ColumnHeadersDefaultCellStyle Is Nothing AndAlso Not ColumnHeadersDefaultCellStyle.Font Is Nothing Then
        '    ColumnHeadersDefaultCellStyle.Font = New Font(ColumnHeadersDefaultCellStyle.Font.FontFamily, m_oAppearInfo.header_font_size * dyScale, _
        '                                    ColumnHeadersDefaultCellStyle.Font.Style, ColumnHeadersDefaultCellStyle.Font.Unit, _
        '                                    ColumnHeadersDefaultCellStyle.Font.GdiCharSet, ColumnHeadersDefaultCellStyle.Font.GdiVerticalFont)
        'End If
    End Sub

    Private Sub ResetColumnWidth()
        If m_ArrColWidth Is Nothing Then Return
        Dim nTotalColWidth As Integer = Me.InternalWidth
        Dim iIndex As Integer = 0
        For Each s As Single In m_ArrColWidth
            If s > 0.0 AndAlso s <= 1.0 Then
                Me.Columns(iIndex).Width = (nTotalColWidth - DATAGRID_VER_SCROLLBAR_WIDTH - DATAGRID_CONST_FRAME_MARIGN) * s
                iIndex += 1
            End If
        Next
    End Sub
    ''"""""""""""""""""End of the resize""""""""""""""""""""""

    Public Sub SetMarkableColumn(ByVal strColumnName As String)
        Dim o As Type = GetType(Color)
        m_strMarkColName = strColumnName
        Me.Refresh()
    End Sub

    Public Sub ClearMarkableColumn()
        m_strMarkColName = ""
        Me.Refresh()
    End Sub
#End Region

#Region "Event"

    Private Sub UIDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseClick
        'If Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strBtnColName) OrElse _
        '    Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strLinkColName) OrElse _
        '    Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strBtnEditColName) OrElse _
        '     Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strImgColName) Then
        '    RaiseEvent ButtonCellClick(sender, e)
        'End If
        If Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strBtnColName) OrElse _
            Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strBtnEditColName) OrElse _
             Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strImgColName) Then
            RaiseEvent ButtonCellClick(sender, e)
        End If
        If TypeOf (Me.Columns(e.ColumnIndex)) Is DataGridViewLinkColumn Then
            RaiseEvent ButtonCellClick(sender, e)
        End If
        If Me.Columns(e.ColumnIndex) Is Me.Columns.Item(m_strCheckBoxColName) Then
            RaiseEvent CheckBoxCellClick(sender, e)
        End If
    End Sub

    Private Sub SetButtonCellByMouseChange(ByVal nColIndex As Integer, ByVal nRowIndex As Integer, ByVal emImageType As IMAGE_TYPE)
        If nColIndex < 0 OrElse nColIndex >= Me.ColumnCount Then Return
        If nRowIndex < 0 OrElse nRowIndex >= Me.RowCount Then Return
        If TypeOf (Me.Columns.Item(nColIndex)) Is UIDataGridViewDelBtnColumn Then
            Dim btnCell As UIDataGridViewDelBtnCell = CType(Me.Item(nColIndex, nRowIndex), UIDataGridViewDelBtnCell)
            If btnCell Is Nothing Then Return
            btnCell.ImageType = emImageType
            Me.InvalidateCell(nColIndex, nRowIndex)
        ElseIf TypeOf (Me.Columns.Item(nColIndex)) Is UIDataGridViewEditBtnColumn Then
            Dim btnEditCell As UIDataGridViewEditBtnCell = CType(Me.Item(nColIndex, nRowIndex), UIDataGridViewEditBtnCell)
            If btnEditCell Is Nothing Then Return
            btnEditCell.ImageType = emImageType
            Me.InvalidateCell(nColIndex, nRowIndex)
        ElseIf TypeOf (Me.Columns.Item(nColIndex)) Is UIDataGridViewImgColumn Then
            Dim btnImgCell As UIDataGridViewImgCell = CType(Me.Item(nColIndex, nRowIndex), UIDataGridViewImgCell)
            If btnImgCell Is Nothing Then Return
            btnImgCell.ImageType = emImageType
            Me.InvalidateCell(nColIndex, nRowIndex)
        ElseIf TypeOf (Me.Columns.Item(nColIndex)) Is UIDataGridViewOKBtnColumn Then
            Dim btnOKCell As UIDataGridViewOKBtnCell = CType(Me.Item(nColIndex, nRowIndex), UIDataGridViewOKBtnCell)
            If btnOKCell Is Nothing Then Return
            btnOKCell.ImageType = emImageType
            Me.InvalidateCell(nColIndex, nRowIndex)
        End If
    End Sub
    Private Sub UIDataGridView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseDown
        SetButtonCellByMouseChange(e.ColumnIndex, e.RowIndex, IMAGE_TYPE.PRESS)
    End Sub

    Private Sub UIDataGridView_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellMouseEnter
        SetButtonCellByMouseChange(e.ColumnIndex, e.RowIndex, IMAGE_TYPE.OVER)
    End Sub

    Private Sub UIDataGridView_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellMouseLeave
        SetButtonCellByMouseChange(e.ColumnIndex, e.RowIndex, IMAGE_TYPE.NORMAL)
    End Sub

    Private Sub UIDataGridView_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseUp
        SetButtonCellByMouseChange(e.ColumnIndex, e.RowIndex, IMAGE_TYPE.OVER)
    End Sub

    Private Sub UIDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles Me.DataBindingComplete
        m_bDataBindComplete = True
        Dim dt As DataTable = CType(Me.DataSource, DataTable)
        If Not dt Is Nothing Then
            Dim nCount As Integer = dt.Rows.Count
            If Me.AllowUserToAddRows Then
                nCount += 1
            End If
            If m_bHaveComboBoxCol Then
                'if has ComboBox，do not update the Init Select Row Index
            Else
                If Me.Rows.Count = nCount Then 'if data is fill complete, set the initial sel index
                    SetInitSelRowIndex(False)
                End If
            End If

        End If

        m_eDataSourceChangeType = e.ListChangedType
        RaiseEvent DataBindingOver()

    End Sub
    Private Sub UIDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Me.DataError
        e.Cancel = False
    End Sub

    Private Sub UIDataGridView_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles Me.RowPrePaint
        e.PaintParts = DataGridViewPaintParts.All - DataGridViewPaintParts.Focus
        PreDrawMarkRows(e) 'draw markable rows
    End Sub

    Private Sub SetInitSelRowIndex(Optional ByVal bRaiseRowChange As Boolean = True)
        If m_nInitSelRowIndex < 0 OrElse m_nInitSelRowIndex >= Me.Rows.Count Then
            RaiseEvent InitSelRowIndexEffected(False, m_nInitSelRowIndex)
            For Each row As DataGridViewRow In Me.Rows
                row.Selected = False
            Next
            Me.CurrentCell = Nothing
            Me.ClearSelection()
            m_nOldIndex = -1
        Else
            If bRaiseRowChange Then m_bManualRiseSelChange = True
            RaiseEvent InitSelRowIndexEffected(True, m_nInitSelRowIndex)
            Me.Rows(m_nInitSelRowIndex).Selected = True
            Me.CurrentCell = Me.Rows(m_nInitSelRowIndex).Cells(0)
            If bRaiseRowChange Then
                If m_bManualRiseSelChange Then
                    RaiseCurrentRowIndexChanged(-1, Me.CurrentRow.Index)
                End If
            End If
        End If
    End Sub

    Private Sub PreDrawMarkRows(ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        Dim dt As DataTable = CType(Me.DataSource, DataTable)
        If Not dt Is Nothing Then
            Dim dtDefView As DataView = dt.DefaultView
            If dt.Columns.Contains(m_strMarkColName) Then
                Dim nIndex As Integer = dt.Columns.IndexOf(m_strMarkColName)
                Dim row As DataRow = dtDefView.Item(e.RowIndex).Row
                If row Is Nothing OrElse row.ItemArray Is Nothing OrElse row.ItemArray.Length < nIndex + 1 Then Return
                Dim value As Object = row.ItemArray(nIndex)
                If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                    If value.GetType Is GetType(Color) Then
                        If (Me.Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor <> CType(value, Color)) Then
                            Me.Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = CType(value, Color)
                        End If
                        If (Me.Rows.Item(e.RowIndex).DefaultCellStyle.SelectionForeColor <> CType(value, Color)) Then
                            Me.Rows.Item(e.RowIndex).DefaultCellStyle.SelectionForeColor = CType(value, Color)
                        End If
                    End If
                End If
            Else 'not contain the column
                Dim foreColor As Color = Me.DefaultCellStyle.ForeColor
                Dim selforeColor As Color = Me.DefaultCellStyle.SelectionForeColor
                If Me.Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor <> foreColor Then
                    Me.Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = foreColor
                End If
                If (Me.Rows.Item(e.RowIndex).DefaultCellStyle.SelectionForeColor <> selforeColor) Then
                    Me.Rows.Item(e.RowIndex).DefaultCellStyle.SelectionForeColor = selforeColor
                End If
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Try
            MyBase.OnPaint(e)
            If m_bBeQuerying Then
                DrawBeQuerying(e.Graphics)
            Else
                Dim dt As DataTable = CType(Me.DataSource, DataTable)
                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    DrawNotItemWarning(e.Graphics)
                End If
            End If
        Catch ex As Exception
            ITSBase.Logger.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub DrawNotItemWarning(ByRef g As Graphics)
        If String.IsNullOrEmpty(m_strNoItemAlter) Then Exit Sub
        Dim oFont As Font = New Font("SimSun", 12.0!)
        Dim oSize As SizeF
        oSize = g.MeasureString(m_strNoItemAlter, oFont)
        Dim x As Single = (Me.Width - oSize.Width) / 2
        g.DrawString(m_strNoItemAlter, New System.Drawing.Font("SimSun", 12.0!), Brushes.LightSlateGray, x, DATAGRID_COLUMN_HEADER_HEIGHT + 2)
    End Sub
    Private Sub DrawBeQuerying(ByRef g As Graphics)
        Dim oFont As Font = New Font("SimSun", 12.0!)
        Dim oSize As SizeF
        oSize = g.MeasureString(DATAGRID_CONST_STRING_BE_QUERYING, oFont)
        Dim x As Single = (Me.Width - oSize.Width) / 2
        g.DrawString(DATAGRID_CONST_STRING_BE_QUERYING, New System.Drawing.Font("SimSun", 12.0!), Brushes.Blue, x, DATAGRID_COLUMN_HEADER_HEIGHT + 2)
    End Sub

    Private Sub Row_Changed(ByVal sender As Object, ByVal e As DataRowChangeEventArgs) Handles m_dtDatarSource.RowChanged
        Dim nIndex As Integer = m_dtDatarSource.Rows.IndexOf(e.Row)
        If m_bSelectChangeRow Then
            If m_eDataSourceChangeType = System.ComponentModel.ListChangedType.ItemAdded OrElse _
               m_eDataSourceChangeType = System.ComponentModel.ListChangedType.ItemChanged Then
                If nIndex < Me.Rows.Count Then
                    Me.CurrentCell = Me.Rows(nIndex).Cells(0)
                End If
            End If
        End If
    End Sub

#End Region
End Class
