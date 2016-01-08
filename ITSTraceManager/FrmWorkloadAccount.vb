
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms
Imports DBManager
Imports ITSBase
Imports UIControlLib

Enum WorkloadPage
    Outline
    Detail
    Chart
End Enum

Public Class FrmWorkloadAccount
    Private _layoutId As Integer
    Private _workloadTable As DataTable

    Private Sub FrmWorkloadAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlTraceContainer.Width = 0.8 * Me.Width
        _layoutId = 73
        SwitchToShowPage(WorkloadPage.Outline)
    End Sub

    Private Sub btnAccount_Click(sender As Object, e As EventArgs) Handles btnAccount.Click
        UpdateAccountEnable()
        Dim errMsg As String = String.Empty
        If Not CheckParameter(errMsg) Then
            UIMsgBox.Show(errMsg)
            UpdateAccountEnable()
        Else
            Try
                Dim startTime As String = dtpStart.Value.Date
                Dim endTime As String = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)
                Dim codeColl As List(Of String) = (From cardRow As DataGridViewRow In dgvItemsSel.Rows Select cardName = Judgement.JudgeDBNullValue(cardRow.Cells(TEXT_ID_INFO_CODE).Value.ToString(), ENUM_DATA_TYPE.DATA_TYPE_STRING) Where Not String.IsNullOrEmpty(cardName)).Cast(Of String)().ToList()
                Dim backAccount As New BackgroundWorker()
                AddHandler backAccount.DoWork, AddressOf BackAccountDoWork
                AddHandler backAccount.RunWorkerCompleted, AddressOf BackAccountCompleted
                backAccount.RunWorkerAsync(New With {.StartTime = startTime, .EndTime = endTime, .CodeCol = codeColl})
            Catch ex As Exception
                UIMsgBox.Show(ex.Message)
                UpdateAccountEnable()
            End Try

        End If
    End Sub

    Private Sub BackAccountCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        _workloadTable = e.Result
        SwitchToShowPage(WorkloadPage.Outline)
        UpdateAccountEnable()
    End Sub

    Private Sub BackAccountDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim accountStartTime As String = e.Argument.StartTime
        Dim accountCloseTime As String = e.Argument.EndTime
        Dim accountCodeColl As List(Of String) = e.Argument.CodeCol
        Dim traceDb As New DbTraceLayout, surgeryDb As New DbOperationManage
        Dim workloadTable As DataTable = InitialWorkloadTable()
        '1 获取指定时间范围内的所有手术
        Dim surgeryTable As New DataTable
        TableConstructor.CreateOperationNote(surgeryTable)
        If DBMEDITS_RESULT.SUCCESS = surgeryDb.QuerySurgeryNoteInfo(surgeryTable, accountStartTime, accountCloseTime, "") AndAlso Not surgeryTable.IsNullOrEmpty() Then
            '2 过滤手术,有指定人员的排班手术
            Dim surArrangeTable As New DataTable
            For Each surRow As DataRow In surgeryTable.Rows
                Dim surNoteId As Integer = Judgement.JudgeDBNullValue(surRow.Item(OPN_OPERATION_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                Dim surRoomId As Integer = Judgement.JudgeDBNullValue(surRow.Item(OPN_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                Dim surRoomName As String = Judgement.JudgeDBNullValue(surRow.Item(TEXT_ROOM_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim surName As String = Judgement.JudgeDBNullValue(surRow.Item(TEXT_DEPARTMENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim surDate As String = Judgement.JudgeDBNullValue(surRow.Item(TEXT_ORDER_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)
                If DBMEDITS_RESULT.SUCCESS = traceDb.QuerySurSchedule(surArrangeTable, surNoteId) AndAlso Not surArrangeTable.IsNullOrEmpty() Then
                    For Each scheduleRow As DataRow In surArrangeTable.Rows
                        Dim staffCode As String = Judgement.JudgeDBNullValue(scheduleRow.Item(TEXT_ID_INFO_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                        Dim staffName As String = Judgement.JudgeDBNullValue(scheduleRow.Item(TEXT_ID_INFO_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                        Dim scheduleStartTime As String = Judgement.JudgeDBNullValue(scheduleRow.Item(WORK_SCHEDULE_START_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)
                        Dim scheduleCloseTime As String = Judgement.JudgeDBNullValue(scheduleRow.Item(WORK_SCHEDULE_CLOSE_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)
                        If Not accountCodeColl.Contains(staffCode) Then Continue For
                        '3 根据过滤后的手术房间，统计人员的工作量
                        Dim surWorkloadTable As New DataTable
                        If DBMEDITS_RESULT.SUCCESS = traceDb.QueryWorkload(surWorkloadTable, staffCode, _layoutId, surRoomId, scheduleStartTime, scheduleCloseTime) AndAlso Not surArrangeTable.IsNullOrEmpty() Then
                            For Each workloadRow As DataRow In surWorkloadTable.Rows
                                Dim workloadStartTime As String = Judgement.JudgeDBNullValue(workloadRow.Item(TRAIL_RECORD_ARRIVE_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)
                                Dim workloadCloseTime As String = Judgement.JudgeDBNullValue(workloadRow.Item(TRAIL_RECORD_LEAVE_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)
                                If CDate(workloadCloseTime) < CDate(workloadStartTime) Then
                                    workloadCloseTime = scheduleCloseTime
                                End If
                                Dim newRow As DataRow = workloadTable.NewRow()
                                newRow.Item(TEXT_ID_INFO_CODE) = staffCode
                                newRow.Item(TEXT_ID_INFO_NAME) = staffName
                                newRow.Item(TEXT_OPERATION_NAME) = surName
                                newRow.Item(TEXT_ROOM_NAME) = surRoomName
                                newRow.Item(TEXT_ORDER_DATE) = surDate
                                newRow.Item(TEXT_TRAIL_RECORD_ARRIVE_TIME) = workloadStartTime
                                newRow.Item(TEXT_TRAIL_RECORD_LEAVE_TIME) = workloadCloseTime
                                newRow.Item(TEXT_TRAIL_RECORD_TOTAL_TIME) = Math.Round(CDbl(DateDiff(DateInterval.Second, CDate(workloadStartTime), CDate(workloadCloseTime))) / 3600, 2)
                                workloadTable.Rows.Add(newRow)
                            Next
                        End If
                    Next
                End If
            Next
        End If
        e.Result = workloadTable
    End Sub

    Private Function CheckParameter(ByRef errMsg As String) As Boolean
        Dim startTime As Date = dtpStart.Value.Date
        Dim endTime As Date = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)
        If (startTime > endTime) Then
            errMsg = MSG_ERROR_STAR_BIGER_END
            Return False
        End If
        If dgvItemsSel.Rows.Count <= 0 Then
            errMsg = CONST_TEXT_SELECT_ONE_RECORD_ATLEAST
            Return False
        End If
        Return True
    End Function

    Private Sub UpdateAccountEnable()
        Me.btnAccount.Enabled = Not btnAccount.Enabled
    End Sub

    Private Sub lblItemsSel_Click(sender As Object, e As EventArgs) Handles lblItemsSel.Click
        Dim frm As New FrmSelectCardItem
        If Not Me.dgvItemsSel.DataSource Is Nothing Then
            frm.SelItemsTable = CType(Me.dgvItemsSel.DataSource, DataTable).Copy
        End If
        If frm.ShowDialog() = DialogResult.OK Then
            BindEntityTable(frm.SelItemsTable.Copy)
        End If
    End Sub

    Private Sub BindEntityTable(ByVal dataSource As DataTable)
        dgvItemsSel.ClearBoolColumn()
        dgvItemsSel.ClearFormatColumn()
        Dim nArrWidth() As Short = {60, 40}
        dgvItemsSel.ColumnWidthCollection = nArrWidth
        dgvItemsSel.DataSource = dataSource
        dgvItemsSel.ClearSelection()
    End Sub

    Private Sub btnOutline_Click(sender As Object, e As EventArgs) Handles btnOutline.Click
        SwitchToShowPage(WorkloadPage.Outline)
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        SwitchToShowPage(WorkloadPage.Detail)
    End Sub

    Private Sub SwitchToShowPage(ByVal workloadPage As WorkloadPage)
        Me.btnOutline.Enabled = workloadPage <> workloadPage.Outline
        Me.btnDetail.Enabled = workloadPage <> workloadPage.Detail
        Me.chtAccount.Height = IIf(Not btnOutline.Enabled, Me.pnlTraceContainer.Height / 2, 0)

        If _workloadTable.IsNullOrEmpty() Then Return

        If workloadPage = workloadPage.Outline Then
            Dim outlineTable As DataTable = New DataTable()
            Dim codeColl As DataTable = _workloadTable.DefaultView.ToTable(True, New String() {TEXT_ID_INFO_CODE})
            If codeColl.IsNullOrEmpty() Then Return
            Dim workloadHashtable As New Hashtable
            For Each codeRow As DataRow In codeColl.Rows
                Dim selRows() As DataRow = _workloadTable.Select(String.Format("{0}='{1}'", TEXT_ID_INFO_CODE, codeRow.Item(TEXT_ID_INFO_CODE)))
                If Not selRows.IsNullOrEmpty() Then
                    Dim workload As Double = 0.0
                    For Each trailRow As DataRow In selRows
                        Dim trailStart As Date = Judgement.JudgeDBNullValue(trailRow.Item(TEXT_TRAIL_RECORD_ARRIVE_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)
                        Dim trailLeave As Date = Judgement.JudgeDBNullValue(trailRow.Item(TEXT_TRAIL_RECORD_LEAVE_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)
                        workload += DateDiff(DateInterval.Second, trailStart, trailLeave)
                    Next
                    workloadHashtable.Add(selRows(0).Item(TEXT_ID_INFO_CODE), New With {.Name = selRows(0).Item(TEXT_ID_INFO_NAME), .Workload = Math.Round(workload / 3600, 2)})
                End If
            Next
            If workloadHashtable.Count <= 0 Then Return
            Dim nArrWidth() As Short = New Short(workloadHashtable.Count - 1) {}
            Dim index As Integer = 0
            For Each de As DictionaryEntry In workloadHashtable
                nArrWidth(index) = 200
                index += 1
                outlineTable.Columns.Add(de.Value.Name)
            Next
            Dim newRow As DataRow = outlineTable.NewRow()
            For Each de As DictionaryEntry In workloadHashtable
                newRow.Item(de.Value.name) = de.Value.Workload
            Next
            outlineTable.Rows.Add(newRow)
            dgvAccount.RealColumnWidthCollection = nArrWidth
            dgvAccount.DataSource = outlineTable
            If chtAccount.Series.Count > 0 AndAlso outlineTable.Rows.Count > 0 AndAlso outlineTable.Columns.Count > 0 Then
                Dim colArr() As String = (From col As DataColumn In outlineTable.Columns Select col.ColumnName).ToArray()
                Dim valueArr() As Object = outlineTable.Rows(0).ItemArray
                chtAccount.Series(0).Points.DataBindXY(colArr, valueArr)
            End If
        ElseIf workloadPage = workloadPage.Detail Then
            Dim dv As DataView = _workloadTable.Copy().DefaultView
            dv.Sort = String.Format("{0} asc,{1} asc", TEXT_ID_INFO_CODE, TEXT_TRAIL_RECORD_ARRIVE_TIME)
            Dim nArrWidth() As Short = {75, 75, 150, 100, 200, 200, 200, 100}
            dgvAccount.RealColumnWidthCollection = nArrWidth
            dgvAccount.DataSource = dv.Table.Copy()
        End If
    End Sub

    Private Function InitialWorkloadTable() As DataTable
        Dim workloadTable As New DataTable
        workloadTable.Columns.Add(TEXT_ID_INFO_CODE, GetType(String))
        workloadTable.Columns.Add(TEXT_ID_INFO_NAME, GetType(String))
        workloadTable.Columns.Add(TEXT_OPERATION_NAME, GetType(String))
        workloadTable.Columns.Add(TEXT_ROOM_NAME, GetType(String))
        'workloadTable.Columns.Add(TEXT_TABLE_ID, GetType(String))
        workloadTable.Columns.Add(TEXT_ORDER_DATE, GetType(String))
        workloadTable.Columns.Add(TEXT_TRAIL_RECORD_ARRIVE_TIME, GetType(String))
        workloadTable.Columns.Add(TEXT_TRAIL_RECORD_LEAVE_TIME, GetType(String))
        workloadTable.Columns.Add(TEXT_TRAIL_RECORD_TOTAL_TIME, GetType(Double))
        Return workloadTable
    End Function

    Private Sub FrmLocationQuery_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.pnlTraceContainer.Width = Me.Width * 3 / 4
        BindEntityTable(dgvItemsSel.DataSource)
    End Sub

End Class
