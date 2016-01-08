Imports System.Windows.Forms
Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports ITSOperationManager.Accessory
Imports UIControlLib

Public Class FrmOperationRequestReg
    Private _surNoteInfo As SurgeryNoteInfo
    Private m_oCurrentPage As TabPage
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        '根据手术通知单号，载入申请单信息
        Dim operationManage As New DbOperationManage, tableReqMaster As New DataTable
        If DBMEDITS_RESULT.SUCCESS = operationManage.QueryRequestMasterInfoByNoteId(tableReqMaster, surNoteInfo.Id) AndAlso Not tableReqMaster.IsNullOrEmpty() Then
            surNoteInfo.RequestReg.TransFromDataRow(tableReqMaster.Rows(0))
        End If
        SetSureryNoteInfo(surNoteInfo)
    End Sub

    Private Sub FrmOperationRequestReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = "Value"
        Me.cmbSurList.ValueMember = "Key"
        TabPage1.Text = String.Empty
        TabPage2.Text = String.Empty
        LoadTodaySurList()
        m_oCurrentPage = TabControl1.TabPages(0)
    End Sub

    Private Sub SetSureryNoteInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        Me.tbSurTime.Text = surNoteInfo.OrderDate
        Me.tbSurName.Text = surNoteInfo.SurName
        Me.tbSurRoom.Text = surNoteInfo.Room
        Me.tbTable.Text = surNoteInfo.Table
        Me.tbVisit.Text = surNoteInfo.VisitId
        Me.tbPatName.Text = surNoteInfo.PatName
        Me.tbGender.Text = surNoteInfo.Gender
        Me.tbAge.Text = surNoteInfo.Age
        Me.tbSurDr.Text = surNoteInfo.Surgeon
        Me.tbDiagnosis.Text = surNoteInfo.Diagnosis
        Me.tbMemo.Text = surNoteInfo.Memo
        Me.cmbSurList.Text = String.Format("{0} {1} {2}", CDate(surNoteInfo.OrderDate).ToString("MM/dd HH:mm"), surNoteInfo.PatName, surNoteInfo.SurName)
        '载入药品和物品
        If surNoteInfo.NoteStatus = OPerationNoteState.UnConfirmed Then
            Dim strOperation As String = surNoteInfo.SurId
            Dim arrOPID() As String = strOperation.Split("+")
            strOperation = surNoteInfo.SurName
            Dim arrOPName() As String = strOperation.Split("+")
            TabPage1.Text = arrOPName(0)
            TabPage1.Tag = arrOPID(0)

            If arrOPID.Length > 1 Then
                TabPage2.Text = arrOPName(1)
                TabPage2.Tag = arrOPID(1)
                Dim dtDrug As New DataTable
                If dtDrug.IsNullOrEmpty() Then
                    Call New DbOperationManage().QueryDrugPredefineDetail(dtDrug, arrOPID(1)) '根据手术编号加载默认药品
                End If
                Dim dtINS_sub As New DataTable
                If dtINS_sub.IsNullOrEmpty() Then
                    Call New DbOperationManage().QueryInstrumentPredefineDetail(dtINS_sub, arrOPID(1)) '根据手术编号加载默认物品
                End If
                BindDrugTable_sub(dtDrug)
                BindInstrumentTable_sub(dtINS_sub)
            Else
                TabPage2.Text = String.Empty
                dgvDrug_sub.DataSource = Nothing
                dgvINS_SUB.DataSource = Nothing
            End If
            Dim returnTable As New DataTable
            If returnTable.IsNullOrEmpty() Then
                Call New DbOperationManage().QueryDrugPredefineDetail(returnTable, arrOPID(0)) '根据手术编号加载默认药品
            End If
            Dim dtINS As New DataTable
            If dtINS.IsNullOrEmpty() Then
                Call New DbOperationManage().QueryInstrumentPredefineDetail(dtINS, arrOPID(0)) '根据手术编号加载默认物品
            End If
            BindDrugTable(returnTable)
            BindInstrumentTable(dtINS)
        Else
            BindDrugTable(GlobalOperationManage.GetSurgeryDrug(surNoteInfo))
            BindInstrumentTable(GlobalOperationManage.GetSurgeryInstrument(surNoteInfo))
            TabPage1.Text = surNoteInfo.SurName
        End If
        _surNoteInfo = surNoteInfo
    End Sub

    Private Sub BindDrugTable_sub(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {20, 20, 15, 15, 20, 10, 0}
        Me.dgvDrug_sub.ColumnWidthCollection = nArrWidth
        Me.dgvDrug_sub.DataSource = tableDrug.Copy()
    End Sub

    Private Sub BindInstrumentTable_sub(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {20, 25, 20, 20, 15}
        Me.dgvINS_SUB.ColumnWidthCollection = nArrWidth
        Me.dgvINS_SUB.DataSource = tableIns.Copy()
    End Sub
    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {20, 20, 15, 15, 20, 10, 0}
        Dim nRead() As Boolean = {True, True, True, True, True, False, False}
        Me.dgvDrug.ColumnReadOnlyCollection = nRead
        Me.dgvDrug.ColumnWidthCollection = nArrWidth
        Me.dgvDrug.DataSource = tableDrug.Copy()
    End Sub

    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {20, 25, 20, 20, 15}
        Dim nRead() As Boolean = {True, True, True, True, False}
        Me.dgvINS.ColumnReadOnlyCollection = nRead
        Me.dgvINS.ColumnWidthCollection = nArrWidth
        Me.dgvINS.DataSource = tableIns.Copy()
    End Sub
    Private Sub ClearAll()
        cmbSurList.Items.Clear()
        Me.tbSurTime.Text = String.Empty
        Me.tbSurName.Text = String.Empty
        Me.tbSurRoom.Text = String.Empty
        Me.tbTable.Text = String.Empty
        Me.tbVisit.Text = String.Empty
        Me.tbPatName.Text = String.Empty
        Me.tbGender.Text = String.Empty
        Me.tbAge.Text = String.Empty
        Me.tbSurDr.Text = String.Empty
        Me.tbDiagnosis.Text = String.Empty
        Me.tbMemo.Text = String.Empty
        Me.cmbSurList.Text = String.Empty
    End Sub
    Private Sub LoadTodaySurList()
        ClearAll()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.Requested, OPerationNoteState.UnConfirmed}
        Dim operationManage As New DbOperationManage, tableSurNote As DataTable = New DataTable(), tableReqMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        If DBMEDITS_RESULT.SUCCESS = operationManage.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
            For Each surRow As DataRow In tableSurNote.Rows
                Dim surInfo As New SurgeryNoteInfo
                If (surInfo.TransFromDataRow(surRow)) Then
                    '根据手术通知单号，载入申请单信息
                    If DBMEDITS_RESULT.SUCCESS = operationManage.QueryRequestMasterInfoByNoteId(tableReqMaster, surInfo.Id) AndAlso Not tableReqMaster.IsNullOrEmpty() Then
                        surInfo.RequestReg.TransFromDataRow(tableReqMaster.Rows(0))
                    End If
                    Me.cmbSurList.Items.Add(New With {.Key = surInfo.Id, .Value = String.Format("{0} {1} {2}", CDate(surInfo.OrderDate).ToString("MM/dd HH:mm"), surInfo.PatName, surInfo.SurName), .Detail = surInfo})
                End If
            Next
        End If
    End Sub

    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSurList.SelectedIndexChanged
        SetSureryNoteInfo(Me.cmbSurList.SelectedItem.Detail)
    End Sub

    Private Sub DeleteDgvSelRows(ByVal dgv As UIDataGridView)
        If dgv Is Nothing Then Return
        If dgv.SelectedRows.Count < 0 Then
            UIMsgBox.Show(CONST_TEXT_SELECT_ONE_RECORD_ATLEAST)
            Return
        End If
        For Each toDel In dgv.SelectedRows
            dgv.Rows.Remove(toDel)
        Next
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        CType(Me.dgvDrug.DataSource, DataTable).AcceptChanges()
        CType(Me.dgvINS.DataSource, DataTable).AcceptChanges()
        Dim operationManage As New DbOperationManage
        If DBMEDITS_RESULT.SUCCESS = operationManage.CommitSurgeryRequestMaster(_surNoteInfo, CType(Me.dgvDrug.DataSource, DataTable), CType(Me.dgvINS.DataSource, DataTable)) Then
            UIMsgBox.Show(MSG_REQUISITION_DISTRICT_REQUEST_SUCESS)
            LoadTodaySurList()
        Else
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        End If
    End Sub

    Private Sub btnDrugAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        Dim addDrugForm As New FrmAddDrug
        If addDrugForm.ShowDialog() = DialogResult.OK Then
            addDrugForm.DrugInfo.TransToDataRow(CType(Me.dgvDrug.DataSource, DataTable))
        End If
    End Sub


    Private Sub btnDrugRemove_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        If UIMsgBox.MSGBoxShowYesNo(MSG_DEL_HARDWARE_QUERY) = DialogResult.Yes Then
            DeleteDgvSelRows(Me.dgvDrug)
        End If
    End Sub

    Private Sub btnInstrumentAdd_Click(sender As Object, e As EventArgs) Handles btnAddINS.Click
        If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        Dim addInstrumentForm As New FrmAddInstrument
        If addInstrumentForm.ShowDialog() = DialogResult.OK Then
            addInstrumentForm.InstrumentInfo.TransToDataRow(CType(Me.dgvINS.DataSource, DataTable))
        End If
    End Sub

    Private Sub btnInstrumentRemove_Click(sender As Object, e As EventArgs) Handles btnDeleteINS.Click
        If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        If UIMsgBox.MSGBoxShowYesNo(MSG_DEL_HARDWARE_QUERY) = DialogResult.Yes Then
            DeleteDgvSelRows(Me.dgvINS)
        End If
    End Sub

    Private Sub dgvINS_CellContentClick(sender As Object, e As System.EventArgs) Handles dgvINS.DoubleClick
        Dim dr As DataRow = dgvINS.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        Dim strINSID As String = dr.Item(TEXT_INS_ID)
        Dim strINSName As String = dr.Item(TEXT_INS_NAME)
        Dim strINSType As String = String.Empty
        Dim strINSUnit As String = dr.Item(TEXT_INS_UNIT)
        Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(strINSID, strINSName, strINSType, strINSUnit)
        oFrmINSDetail.ShowDialog()
    End Sub
End Class

