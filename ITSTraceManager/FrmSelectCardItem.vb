Imports System.Windows.Forms
Imports DBManager
Imports DevComponents.DotNetBar.Controls
Imports ITSBase

Public Class FrmSelectCardItem
    Public Property SelItemsTable As DataTable
    Private _unselItemTable As DataTable

    Private Sub FrmSelectCardItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialCardItem()
        BindUnselTable()
        BindSelTable()
    End Sub

    Private Function GenerateFilterTable(text As String, sourceTable As DataTable) As DataTable
        If sourceTable Is Nothing Then Return Nothing

        Dim filter As String = String.Empty
        If Not String.IsNullOrEmpty(text) Then
            filter += IIf(String.IsNullOrEmpty(filter), "", " and ") + String.Format("{0} like '%{1}%'", TEXT_ID_INFO_CODE, text)
        End If
        Dim selectRows As DataRow() = sourceTable.Select(filter)
        Dim filterTable As New DataTable
        filterTable.Columns.Add(TEXT_ID_INFO_NAME, GetType(String))
        filterTable.Columns.Add(TEXT_ID_INFO_CODE, GetType(String))
        For Each selRow As DataRow In selectRows
            If selRow.Table.Columns.Contains(TEXT_ID_INFO_CATEGORY) Then
                Dim category As Integer = Judgement.JudgeDBNullValue(selRow.Item(TEXT_ID_INFO_CATEGORY), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                If category = TRACE_ID_CATEGORY.高值器械 Then Continue For
            End If
            Dim newRow As DataRow = filterTable.NewRow()
            newRow.Item(TEXT_ID_INFO_NAME) = Judgement.JudgeDBNullValue(selRow.Item(TEXT_ID_INFO_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            newRow.Item(TEXT_ID_INFO_CODE) = Judgement.JudgeDBNullValue(selRow.Item(TEXT_ID_INFO_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            filterTable.Rows.Add(newRow)
        Next
        Return filterTable
    End Function

    Private Sub BindUnselTable()
        BindEntityTable(dgvNoSel, GenerateFilterTable(tbUnsel.Text, _unselItemTable))
    End Sub

    Private Sub BindSelTable()
        BindEntityTable(dgvSel, GenerateFilterTable(tbSel.Text, SelItemsTable))
    End Sub

    Private Sub BindEntityTable(ByVal dgv As DataGridViewX, ByVal dataSource As DataTable)
        If dgv Is Nothing OrElse dataSource Is Nothing Then Return
        dgv.DataSource = dataSource
        dgv.ClearSelection()
    End Sub

    Private Sub InitialCardItem()
        _unselItemTable = New DataTable()
        _unselItemTable.Columns.Add(TEXT_ID_INFO_NAME, GetType(String))
        _unselItemTable.Columns.Add(TEXT_ID_INFO_CODE, GetType(String))
        _unselItemTable.Columns.Add(TEXT_ID_INFO_CATEGORY, GetType(String))
        If SelItemsTable Is Nothing Then
            SelItemsTable = New DataTable()
            SelItemsTable.Columns.Add(TEXT_ID_INFO_NAME, GetType(String))
            SelItemsTable.Columns.Add(TEXT_ID_INFO_CODE, GetType(String))
        End If

        Dim totalCardTable As New DataTable
        Dim traceDb As New DbTraceLayout
        If DBMEDITS_RESULT.SUCCESS = traceDb.QueryCardInfo(totalCardTable) AndAlso Not totalCardTable.IsNullOrEmpty() Then
            For Each codeRow As DataRow In totalCardTable.Rows
                Dim card As String = Judgement.JudgeDBNullValue(codeRow.Item(ID_INFO_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim name As String = Judgement.JudgeDBNullValue(codeRow.Item(ID_INFO_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim category As String = Judgement.JudgeDBNullValue(codeRow.Item(ID_INFO_CATEGORY), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim filterRows As DataRow() = SelItemsTable.Select(String.Format("{0}='{1}'", TEXT_ID_INFO_CODE, card))
                If filterRows.IsNullOrEmpty() Then 'if sel table has not this item
                    Dim newRow As DataRow = _unselItemTable.NewRow()
                    newRow.Item(TEXT_ID_INFO_CODE) = card
                    newRow.Item(TEXT_ID_INFO_NAME) = name
                    newRow.Item(TEXT_ID_INFO_CATEGORY) = category
                    _unselItemTable.Rows.Add(newRow)
                End If
            Next
        End If
    End Sub

    Private Sub btnSel_Click(sender As Object, e As EventArgs) Handles btnSel.Click
        ExchangeSelRows(dgvNoSel.SelectedRows, _unselItemTable, SelItemsTable)
    End Sub

    Private Sub btnUnsel_Click(sender As Object, e As EventArgs) Handles btnUnsel.Click
        ExchangeSelRows(dgvSel.SelectedRows, SelItemsTable, _unselItemTable)
    End Sub

    Private Sub ExchangeSelRows(ByVal selectedRows As DataGridViewSelectedRowCollection, ByVal sourceTable As DataTable, ByVal destTable As DataTable)
        For Each selrow As DataGridViewRow In selectedRows
            Dim code As String = Judgement.JudgeDBNullValue(selrow.Cells(TEXT_ID_INFO_CODE).Value, ENUM_DATA_TYPE.DATA_TYPE_STRING)
            Dim name As String = Judgement.JudgeDBNullValue(selrow.Cells(TEXT_ID_INFO_NAME).Value, ENUM_DATA_TYPE.DATA_TYPE_STRING)
            Dim filterRows As DataRow() = sourceTable.Select(String.Format("{0}='{1}'", TEXT_ID_INFO_CODE, code))
            If Not filterRows.IsNullOrEmpty() Then
                sourceTable.Rows.Remove(filterRows(0))
                Dim newRow As DataRow = destTable.NewRow()
                newRow.Item(TEXT_ID_INFO_CODE) = code
                newRow.Item(TEXT_ID_INFO_NAME) = name
                destTable.Rows.Add(newRow)
            End If
        Next
        BindUnselTable()
        BindSelTable()
    End Sub

    Private Sub tbUnsel_TextChanged(sender As Object, e As EventArgs) Handles tbUnsel.TextChanged
        BindUnselTable()
    End Sub

    Private Sub tbSel_TextChanged(sender As Object, e As EventArgs) Handles tbSel.TextChanged
        BindSelTable()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dgvNoSel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNoSel.CellDoubleClick
        btnSel.PerformClick()
    End Sub

    Private Sub dgvSel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSel.CellDoubleClick
        btnUnsel.PerformClick()
    End Sub

End Class