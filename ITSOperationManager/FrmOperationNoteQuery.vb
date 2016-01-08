Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports System.Windows.Forms
Imports UIControlLib
Public Class FrmOperationNoteQuery
    Public Event SurRequestReg(ByVal surNoteInfo As SurgeryNoteInfo)
    Public Event SurUseReg(ByVal surNoteInfo As SurgeryNoteInfo)
    Public Event SurRecycleReg(ByVal surNoteInfo As SurgeryNoteInfo)
    Public Event SurFrontUseReg(ByVal surNoteInfo As SurgeryNoteInfo)
    Public m_dtOPerationNote As DataTable
    Public m_dtSelect As DataTable

    Private Sub FrmOperationNoteQuery_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialControls()
    End Sub
    Private Sub InitialControls()
        Me.dtpTimeStart.Value = DateTime.Now
        Me.dtpTimeEnd.Value = DateTime.Now
        TableConstructor.CreateOperationNote(m_dtOPerationNote)
        TableConstructor.CreateOperationNote(m_dtSelect)
        BindTable()

        Dim tableSurRoom As New DataTable, operationManage As New DbOperationManage, surRooms As New List(Of String)
        If Not DBMEDITS_RESULT.SUCCESS = operationManage.QueryTotalOperationRoom(tableSurRoom) Then
            cmbSurRoom.Items.Add(TEXT_ALL)
        Else
            Dim drNew As DataRow = tableSurRoom.NewRow
            drNew.Item(ROOM_ID) = -1
            drNew.Item(ROOM_NAME) = TEXT_ALL
            tableSurRoom.Rows.Add(drNew)

            Me.cmbSurRoom.DisplayMember = "ROOM_NAME"
            Me.cmbSurRoom.ValueMember = "ROOM_ID"
            Me.cmbSurRoom.DataSource = tableSurRoom
            Me.cmbSurRoom.Text = TEXT_ALL
        End If
        EnableFunctionBtn(False)
        InitialStatus()
    End Sub
    Private Sub InitialStatus()
        cmbStatus.Items.Add(TEXT_CONT_NOTE_STATUS_NULL)
        cmbStatus.Items.Add(TEXT_CONT_NOTE_STATUS_REQUEST)
        cmbStatus.Items.Add(TEXT_CONT_NOTE_STATUS_USE_COMFIRED)
        cmbStatus.Items.Add(TEXT_CONT_NOTE_STATUS_USED)
        cmbStatus.Items.Add(TEXT_CONT_NOTE_STATUS_RETURN)
        'cmbStatus.Items.Add(TEXT_CONT_NOTE_STATUS_CANCEL)
        cmbStatus.Items.Add(TEXT_CONT_NOTE_STATUS_ALL)
        cmbStatus.Text = TEXT_CONT_NOTE_STATUS_ALL
    End Sub
    Private Sub EnableFunctionBtn(ByVal enable As Boolean)
        Me.btnRequest.Enabled = enable
        Me.btnUse.Enabled = enable
        Me.btnRecycle.Enabled = enable
    End Sub
    'Private Sub BindTable(ByVal tableSurNote As DataTable)

    '    If tableSurNote.IsNullOrEmpty() Then Return
    '    Me.dgv.ClearBoolColumn()
    '    Me.dgv.ClearFormatColumn()
    '    Dim nArrWidth() As Short = {0, 75, 75, 50, 50, 200, 175, 100, 100, 100, 100, 50, 100, 250, 0, 150}
    '    Me.dgv.RealColumnWidthCollection = nArrWidth
    '    Me.dgv.DataSource = tableSurNote
    'End Sub
    Private Sub BindTable()
        Me.dgv.ClearBoolColumn()
        Me.dgv.ClearFormatColumn()
        Me.dgv.HaveCheckBoxColumn = True
        Dim nArrWidth() As Short = {0, 100, 75, 50, 50, 200, 150, 0, 100, 100, 100, 100, 50, 100, 150, 150, 0}
        Me.dgv.RealColumnWidthCollection = nArrWidth
        Me.dgv.DataSource = m_dtOPerationNote
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        m_dtOPerationNote.Clear()
        Dim startTime As String = Me.dtpTimeStart.Value.Date.ToString()
        Dim endTime As String = Me.dtpTimeEnd.Value.Date.AddDays(1).AddSeconds(-1).ToString()
        Dim surRoom As String = Me.cmbSurRoom.SelectedValue
        Dim operationManage As New DbOperationManage, tableSurNote As DataTable = New DataTable()
        Dim lRet As Long
        Dim shStatus() As OPerationNoteState
        If cmbStatus.Text = TEXT_CONT_NOTE_STATUS_ALL Then
            shStatus = New OPerationNoteState() {OPerationNoteState.UnConfirmed, OPerationNoteState.Requested, OPerationNoteState.SurgeryConfirm, OPerationNoteState.SurgeryCancel, OPerationNoteState.SurgeryEnd, OPerationNoteState.SurgeryReturn}
            If cmbSurRoom.Text = TEXT_ALL Then
                lRet = operationManage.QuerySurgeryNoteInfo(m_dtOPerationNote, startTime, endTime, String.Empty, shStatus)
            Else
                lRet = operationManage.QuerySurgeryNoteInfo(m_dtOPerationNote, startTime, endTime, surRoom, shStatus)
            End If
        Else
            shStatus = New OPerationNoteState() {MatchStringToEnumNoteStatus(cmbStatus.Text)}
            If cmbSurRoom.Text = TEXT_ALL Then
                lRet = operationManage.QuerySurgeryNoteInfo(m_dtOPerationNote, startTime, endTime, String.Empty, shStatus)
            Else
                lRet = operationManage.QuerySurgeryNoteInfo(m_dtOPerationNote, startTime, endTime, surRoom, shStatus)
            End If
        End If
        If Not DBMEDITS_RESULT.SUCCESS = lRet Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        Else
            'BindTable(tableSurNote)
        End If
    End Sub

    Private Sub FunctionBtnClick(sender As Object, e As EventArgs) Handles btnRequest.Click, btnUse.Click, btnRecycle.Click, btnFrontUse.Click
        If dgv.SelectedRows.Count = 1 Then
            Dim visitId As String = dgv.SelectedRows(0).Cells(TEXT_VISIT_ID).Value.ToString()
            Dim surName As String = dgv.SelectedRows(0).Cells(TEXT_OPERATION_NAME).Value.ToString()
            Dim selRows As DataRow() = CType(dgv.DataSource, DataTable).Select(String.Format("{0}='{1}' and {2} = '{3}'", TEXT_VISIT_ID, visitId, TEXT_OPERATION_NAME, surName))
            If selRows.IsNullOrEmpty() Then Return
            Dim selRow As DataRow = selRows(0)
            Dim selSurInfo As New SurgeryNoteInfo
            If (selSurInfo.TransFromDataRow(selRow)) Then
                If sender Is btnRequest Then
                    RaiseEvent SurRequestReg(selSurInfo)
                ElseIf sender Is btnUse Then
                    RaiseEvent SurUseReg(selSurInfo)
                ElseIf sender Is btnRecycle Then
                    RaiseEvent SurRecycleReg(selSurInfo)
                ElseIf sender Is btnFrontUse Then
                    RaiseEvent SurFrontUseReg(selSurInfo)
                End If
            End If
        End If
    End Sub

    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs) Handles dgv.SelectionChanged
        Dim dr As DataRow = dgv.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        Dim strStatus As String = CStr(dr.Item(TEXT_OPERATION_STATUS))
        If strStatus.Equals(TEXT_CONT_NOTE_STATUS_USE_COMFIRED) OrElse _
            strStatus.Equals(TEXT_CONT_NOTE_STATUS_REQUEST) Then
            EnableFunctionBtn(True)
        ElseIf strStatus.Equals(TEXT_CONT_NOTE_STATUS_USE_COMFIRED) Then
            btnRequest.Enabled = False
        ElseIf strStatus.Equals(TEXT_CONT_NOTE_STATUS_USED) Then
            btnRequest.Enabled = False
            btnUse.Enabled = False
        Else
            EnableFunctionBtn(True)
        End If
        'EnableFunctionBtn(Me.dgv.SelectedRows.Count = 1)
    End Sub
    Private Sub Ondgvcheckboxcellclick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CheckBoxCellClick
        If e.RowIndex > -1 Then
            Dim dr As DataGridViewRow = dgv.Rows(e.RowIndex)
            OnCheckedChange(dr, True)
        End If
    End Sub
    Private Sub OnCheckedChange(ByVal dr As DataGridViewRow, ByVal bClickGridView As Boolean)
        If dr Is Nothing Then Exit Sub
        Dim bChecked As Boolean = False
        If dr.Cells(0).EditedFormattedValue.GetType Is GetType(Boolean) Then
            If bClickGridView Then
                bChecked = Not CType(dr.Cells(0).EditedFormattedValue, Boolean)
            Else
                bChecked = CType(dr.Cells(0).EditedFormattedValue, Boolean)
            End If
        End If
        Dim drSelect As DataRow = dgv.CurrentDataRow
        If drSelect Is Nothing Then Exit Sub

        If bChecked Then
            Dim drFind As DataRow() = m_dtSelect.Select(String.Format("{0}='{1}'", OPN_ID, drSelect.Item(OPN_ID)))
            If drFind.Length = 0 Then
                Dim drNew As DataRow = m_dtSelect.NewRow
                drNew.Item(OPN_ID) = drSelect.Item(OPN_ID)
                drNew.Item(TEXT_VISIT_ID) = drSelect.Item(OPN_ID)
                drNew.Item(TEXT_PATIENT_NAME) = drSelect.Item(TEXT_PATIENT_NAME)
                drNew.Item(TEXT_GENDER) = drSelect.Item(TEXT_GENDER)
                drNew.Item(TEXT_AGE) = drSelect.Item(TEXT_AGE)
                drNew.Item(TEXT_OPERATION_NAME) = drSelect.Item(TEXT_OPERATION_NAME)
                drNew.Item(TEXT_ORDER_DATE) = drSelect.Item(TEXT_ORDER_DATE)
                drNew.Item(TEXT_ROOM_NAME) = drSelect.Item(TEXT_ROOM_NAME)
                drNew.Item(TEXT_TABLE_ID) = drSelect.Item(TEXT_TABLE_ID)
                drNew.Item(TEXT_DOCTOR_NAME) = drSelect.Item(TEXT_DOCTOR_NAME)
                drNew.Item(TEXT_DEPARTMENT_NAME) = drSelect.Item(TEXT_DEPARTMENT_NAME)
                drNew.Item(TEXT_WEIGHT) = drSelect.Item(TEXT_WEIGHT)
                drNew.Item(TEXT_DIAGNOSIS) = drSelect.Item(TEXT_DIAGNOSIS)
                drNew.Item(TEXT_DR_MEMO) = drSelect.Item(TEXT_DR_MEMO)
                drNew.Item(OPN_OPERATION_ID) = drSelect.Item(OPN_OPERATION_ID)
                drNew.Item(TEXT_OPERATION_STATUS) = drSelect.Item(TEXT_OPERATION_STATUS)
                m_dtSelect.Rows.Add(drNew)
            End If
        Else
            Dim drFind As DataRow() = m_dtSelect.Select(String.Format("{0}='{1}'", OPN_ID, drSelect.Item(OPN_ID)))
            If drFind.Length = 1 Then
                m_dtSelect.Rows.Remove(drFind(0))
            End If
        End If
    End Sub

    Private Sub btnRequestAll_Click(sender As Object, e As EventArgs) Handles btnRequestAll.Click
        If m_dtSelect.Rows.Count < 1 Then
            UIMsgBox.MSGBoxShow(MSG_NOTE_QUERY_REQUEST_ALL)
            Exit Sub
        End If
        Dim operationManage As New DbOperationManage
        If Not operationManage.InsertRequestList(m_dtSelect) = DBMEDITS_RESULT.SUCCESS Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        End If
        m_dtSelect.Clear()
        btnRefresh.PerformClick()
    End Sub
End Class
