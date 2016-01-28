Imports System.Windows.Forms
Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports ITSOperationManager.Accessory
Imports UIControlLib

Public Class FrmOperationRequestReg
    Private _surNoteInfo As SurgeryNoteInfo
    Private _dtSurList As DataTable
    Private _oDBOperater As DbOperationManage
    Private m_dtINSAll As DataTable
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        '根据手术通知单号，载入申请单信息
        InitialINS()
        Dim tableReqMaster As New DataTable
        If DBMEDITS_RESULT.SUCCESS = _oDBOperater.QueryRequestMasterInfoByNoteId(tableReqMaster, surNoteInfo.Id) AndAlso Not tableReqMaster.IsNullOrEmpty() Then
            surNoteInfo.RequestReg.TransFromDataRow(tableReqMaster.Rows(0))
        End If
        LoadTodaySurList()
        SetSureryNoteInfo(surNoteInfo)
    End Sub

    Private Sub FrmOperationRequestReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        TableConstructor.CreateSurList(_dtSurList)
        _oDBOperater = New DbOperationManage
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = TEXT_OPERATION_NAME
        Me.cmbSurList.ValueMember = TEXT_OPERATION_ID
        Me.cmbSurList.DataSource = _dtSurList
        LoadTodaySurList()
        cmbSurList.Text = String.Empty
        InitialINS()
    End Sub
    Private Sub InitialINS()
        m_dtINSAll = New DataTable
        If _oDBOperater.QueryTotal(m_dtINSAll, MST_INSTRUMENT_INFO) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
        End If
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
        '载入药品和物品
        BindDrugTable(GlobalOperationManage.GetSurgeryDrug(surNoteInfo))
        BindInstrumentTable(GlobalOperationManage.GetSurgeryInstrument(surNoteInfo))
        If surNoteInfo.NoteStatus = OPerationNoteState.Requested Then
            btnOK.Text = TEXT_MODIFY
            btnAddINS.Enabled = True
            btnDeleteINS.Enabled = True
            btnAdd.Enabled = True
            btnDelete.Enabled = True
            btnOK.Enabled = True
        ElseIf surNoteInfo.NoteStatus = OPerationNoteState.UnConfirmed Then
            btnOK.Text = TEXT_OK
            btnAddINS.Enabled = True
            btnDeleteINS.Enabled = True
            btnAdd.Enabled = True
            btnDelete.Enabled = True
            btnOK.Enabled = True
        Else
            btnAddINS.Enabled = False
            btnDeleteINS.Enabled = False
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnOK.Text = TEXT_OK
            btnOK.Enabled = False
        End If
        _surNoteInfo = surNoteInfo
    End Sub

    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {20, 20, 15, 15, 20, 10, 0}
        Dim bReadOnly() As Boolean = {True, True, True, True, True, False, True}

        Me.dgvDrug.DataSource = tableDrug.Copy()
        If dgvDrug.Columns.Count > 5 Then
            Me.dgvDrug.Columns(6).Visible = False
            Me.dgvDrug.Columns(5).ReadOnly = False
        End If
    End Sub

    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {20, 25, 20, 20, 15}
        Dim bReadOnly() As Boolean = {True, True, True, True, False}
        'Me.dgvInstrument.ColumnReadOnlyCollection = bReadOnly
        'Me.dgvInstrument.ColumnWidthCollection = nArrWidth
        Me.dgvINStrument.DataSource = tableIns.Copy()
        Me.dgvINStrument.Columns(4).ReadOnly = False
        dgvINStrument.Columns(0).Width = dgvINStrument.Width / 5
        dgvINStrument.Columns(1).Width = dgvINStrument.Width / 5
        dgvINStrument.Columns(2).Width = dgvINStrument.Width / 5
        dgvINStrument.Columns(3).Width = dgvINStrument.Width / 5
        dgvINStrument.Columns(4).Width = dgvINStrument.Width / 5
    End Sub
    Private Sub ClearAll()
        _dtSurList.Clear()
        If Not dgvDrug.DataSource Is Nothing Then
            Dim dtDrug As DataTable = CType(dgvDrug.DataSource, DataTable).Clone
            BindDrugTable(dtDrug)
        End If
        If Not dgvINStrument.DataSource Is Nothing Then
            Dim dtINS As DataTable = CType(dgvINStrument.DataSource, DataTable).Clone
            BindInstrumentTable(dtINS)
        End If
        Clear()
    End Sub
    Private Sub Clear()
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
    End Sub
    Private Sub LoadTodaySurList()
        ClearAll()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.Requested, OPerationNoteState.UnConfirmed}
        Dim tableSurNote As DataTable = New DataTable(), tableReqMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        If DBMEDITS_RESULT.SUCCESS = _oDBOperater.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
            For Each surRow As DataRow In tableSurNote.Rows
                Dim surInfo As New SurgeryNoteInfo
                If (surInfo.TransFromDataRow(surRow)) Then
                    Dim drNew As DataRow = _dtSurList.NewRow
                    drNew.Item(TEXT_OPERATION_ID) = surInfo.Id
                    drNew.Item(TEXT_OPERATION_NAME) = String.Format("{0} {1} {2}", CDate(surInfo.OrderDate).ToString("MM/dd HH:mm"), surInfo.PatName, surInfo.SurName)
                    _dtSurList.Rows.Add(drNew)
                End If
            Next
            cmbSurList.DataSource = _dtSurList
        End If
    End Sub
    Private Sub SepINS(ByRef dtINS As DataTable, ByRef dtHighValueSU As DataTable, ByRef dtHighValueRU As DataTable)
        Dim dt As DataTable = CType(dgvINStrument.DataSource, DataTable)
        dtINS = dt.Clone
        dtHighValueSU = dt.Clone
        dtHighValueRU = dt.Clone
        If dt.Rows.Count < 1 Then
            Exit Sub
        End If
        For Each dr As DataRow In dt.Rows
            Dim rowFind() As DataRow = m_dtINSAll.Select(String.Format("{0}='{1}'", INS_CODE, dr.Item(TEXT_INS_ID)))
            Dim drNew As DataRow
            If rowFind.Length = 1 Then
                If rowFind(0).Item(INS_KIND) = INS_KINDS.OP_INSTRUMENTS Then
                    drNew = dtINS.NewRow
                    drNew.ItemArray = dr.ItemArray
                    dtINS.Rows.Add(drNew)
                ElseIf rowFind(0).Item(INS_KIND) = INS_KINDS.HIGH_VALUE_SU Then
                    drNew = dtHighValueSU.NewRow
                    drNew.ItemArray = dr.ItemArray
                    dtHighValueSU.Rows.Add(drNew)
                ElseIf rowFind(0).Item(INS_KIND) = INS_KINDS.HIGH_VALUE Then
                    drNew = dtHighValueRU.NewRow
                    drNew.ItemArray = dr.ItemArray
                    dtHighValueRU.Rows.Add(drNew)
                End If
            Else
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_REQUEST_INS_ERROR_NOT_EXIST, dr.Item(TEXT_INS_ID)))
                Exit Sub
            End If
        Next
    End Sub

    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSurList.SelectedIndexChanged
        Clear()
        If cmbSurList.Text = String.Empty Then Exit Sub
        Dim lSurId As Long = CLng(cmbSurList.SelectedValue)
        Dim surInfo As New SurgeryNoteInfo
        If Not _oDBOperater.QuerySurgeryNoteInfoByID(surInfo, lSurId) = DBMEDITS_RESULT.SUCCESS Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        SetSureryNoteInfo(surInfo)
    End Sub
    Private Sub btnDrugAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        Dim addDrugForm As New FrmAddDrug
        If addDrugForm.ShowDialog() = DialogResult.OK Then
            addDrugForm.DrugInfo.TransToDataRow(CType(Me.dgvDrug.DataSource, DataTable))
        End If
    End Sub
    Private Sub btnDrugRemove_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        'If UIMsgBox.MSGBoxShowYesNo(MSG_DEL_HARDWARE_QUERY) = DialogResult.Yes Then
        '    DeleteDgvSelRows(Me.dgvDrug)
        'End If
        If ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MSG_DEL_HARDWARE_QUERY) = DialogResult.Yes Then
            DeleteDgvSelRows(Me.dgvDrug)
        End If
    End Sub
    Private Sub btnInstrumentAdd_Click(sender As Object, e As EventArgs) Handles btnAddINS.Click
        'If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        Dim addInstrumentForm As New FrmAddInstrument
        If addInstrumentForm.ShowDialog() = DialogResult.OK Then
            addInstrumentForm.InstrumentInfo.TransToDataRow(CType(Me.dgvINStrument.DataSource, DataTable))
        End If
    End Sub
    Private Sub btnInstrumentRemove_Click(sender As Object, e As EventArgs) Handles btnDeleteINS.Click
        'If String.IsNullOrEmpty(cmbSurList.Text) Then Return
        'If UIMsgBox.MSGBoxShowYesNo(MSG_DEL_HARDWARE_QUERY) = DialogResult.Yes Then
        '    DeleteDgvSelRows(Me.dgvINStrument)
        'End If
        If ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MSG_DEL_HARDWARE_QUERY) = DialogResult.Yes Then
            DeleteDgvSelRows(Me.dgvINStrument)
        End If
    End Sub
    Private Sub DeleteDgvSelRows(ByVal dgv As DevComponents.DotNetBar.Controls.DataGridViewX)
        If dgv Is Nothing Then Return
        If dgv.SelectedRows.Count < 0 Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", CONST_TEXT_SELECT_ONE_RECORD_ATLEAST)
            Return
        End If
        For Each toDel In dgv.SelectedRows
            dgv.Rows.Remove(toDel)
        Next
    End Sub
    Private Sub dgvINS_CellContentClick(sender As Object, e As System.EventArgs) Handles dgvINStrument.DoubleClick
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Cells(TEXT_PACKAGE_ID).Value)

        Dim strINSID As String = dr.Cells(TEXT_INS_ID).Value
        Dim strINSName As String = dr.Cells(TEXT_INS_NAME).Value
        Dim strINSType As String = String.Empty
        Dim strINSUnit As String = dr.Cells(TEXT_INS_UNIT).Value
            Dim oFrmINSDetail As FrmINSDetail
            Dim oPackageINSdetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
            oPackageINSdetail.m_lPackageID = dr.Cells(TEXT_PACKAGE_ID).Value
            oPackageINSdetail.m_strINSID = dr.Cells(TEXT_INS_ID).Value
            oPackageINSdetail.m_strINSName = dr.Cells(TEXT_INS_NAME).Value
            oPackageINSdetail.m_strINSType = dr.Cells(TEXT_INS_TYPE).Value
            oPackageINSdetail.m_strINSUnit = dr.Cells(TEXT_INS_UNIT).Value
            oFrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.Front, True)
            oFrmINSDetail.ShowDialog()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        CType(Me.dgvDrug.DataSource, DataTable).AcceptChanges()
        CType(Me.dgvInstrument.DataSource, DataTable).AcceptChanges()
        Dim operationManage As New DbOperationManage
        Dim dtINS, dtHighSU, dtHighRU As DataTable
        SepINS(dtINS, dtHighSU, dtHighRU)
        If DBMEDITS_RESULT.SUCCESS = operationManage.CommitSurgeryRequestMaster(_surNoteInfo, CType(Me.dgvDrug.DataSource, DataTable), dtINS, dtHighSU, dtHighRU) Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Information, "", MSG_REQUISITION_DISTRICT_REQUEST_SUCESS)
            LoadTodaySurList()
        End If
    End Sub
End Class
