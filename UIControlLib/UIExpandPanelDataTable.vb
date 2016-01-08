Public Class UIExpandPanelDataTable
    Inherits DataTable

    Private m_ArrColWidth As Array
    Private m_strMarkColName As String
    Public Property ColumnWidthCollection() As Array
        Get
            Return m_ArrColWidth
        End Get
        Set(ByVal value As Array)
            m_ArrColWidth = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        m_ArrColWidth = Nothing
        m_strMarkColName = String.Empty
    End Sub

    Public Sub New(ByVal strTableName As String)
        MyBase.New(strTableName)
        m_ArrColWidth = Nothing
    End Sub

    Public Overloads Function Copy() As UIExpandPanelDataTable
        Dim dtRet As UIExpandPanelDataTable = MyBase.Copy
        dtRet.ColumnWidthCollection = ColumnWidthCollection
        Return dtRet
    End Function

    Public Property MarkableColumn() As String
        Get
            Return m_strMarkColName
        End Get
        Set(ByVal value As String)
            m_strMarkColName = value
        End Set
    End Property

    Public Function DataFromTable(ByVal dtFill As DataTable) As Boolean
        If dtFill Is Nothing Then Return False
        For Each oCol As DataColumn In Me.Columns
            If Not dtFill.Columns.Contains(oCol.ColumnName) Then Return False
        Next
        Me.Rows.Clear()
        For Each oRow As DataRow In dtFill.Rows
            Dim oInsert As DataRow = Me.NewRow()
            oInsert.ItemArray = oRow.ItemArray
            Me.Rows.Add(oInsert)
        Next
    End Function
End Class
