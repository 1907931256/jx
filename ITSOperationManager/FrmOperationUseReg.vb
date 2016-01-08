Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports ITSOperationManager.Accessory
Imports UIControlLib

Public Class FrmOperationUseReg
    Private _surNoteInfo As SurgeryInfoAccessory.SurgeryNoteInfo
    Private m_oDbOperationManage As DbOperationManage
    Private m_dtPackage As DataTable
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        m_oDbOperationManage = New DbOperationManage
        SetSureryNoteInfo(surNoteInfo)
    End Sub
    Private Sub LoadSurUseInfo(ByRef surNoteInfo As SurgeryNoteInfo)
        '根据手术通知单号，载入使用信息
        Dim operationManage As New DbOperationManage, tableUseMaster As New DataTable
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QueryUseMasterInfoByNoteId(tableUseMaster, surNoteInfo.Id) AndAlso Not tableUseMaster.IsNullOrEmpty() Then
            surNoteInfo.UseReg.TransFromDataRow(tableUseMaster.Rows(0))
        Else
            FormUseRegInfo(surNoteInfo)
        End If
    End Sub
    Private Sub FormUseRegInfo(ByRef surNoteInfo As SurgeryNoteInfo)
        '1. 插入一条使用记录，2.从申请单出获取数据，填入使用详细表中
        Dim operationManage As New DbOperationManage
        operationManage.GenerateSurgeryUseMaster(surNoteInfo)
    End Sub

    Private Sub FrmOperationUseReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = "Value"
        Me.cmbSurList.ValueMember = "Key"
        m_oDbOperationManage = New DbOperationManage
        TableConstructor.CreateUseingINS(m_dtPackage)
        btnOrderExec.Visible = False
        btnInsConfirm.Visible = False
        LoadTodaySurList()
    End Sub

    Private Sub SetSureryNoteInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        m_dtPackage.Clear()
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
        LoadSurUseInfo(surNoteInfo)
        _surNoteInfo = surNoteInfo
        If surNoteInfo.NoteStatus = OPerationNoteState.SurgeryConfirm Then
            LoadInsTable()
            BindDrugTable(GetSurgeryDrugUseTable(surNoteInfo.Id))
        ElseIf surNoteInfo.NoteStatus = OPerationNoteState.SurgeryEnd OrElse surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
            BindDrugTable(GetSurgeryDrugUseTable(surNoteInfo.UseReg.Id))
            BindInstrumentTable(GetSurgeryInsUseTable(surNoteInfo.UseReg.Id))
        Else

        End If
    End Sub
    Private Sub LoadInsTable()
        If m_oDbOperationManage.QueryFrontUseINSInfoByID(m_dtPackage, _surNoteInfo.Id) = DBMEDITS_RESULT.SUCCESS Then
            BindInstrumentTable(m_dtPackage)
        End If
    End Sub

    Private Function GetSurgeryDrugUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryDrugFrontUseTable(returnTable, useRegId)
        Return returnTable
    End Function

    Private Function GetSurgeryInsUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryInsUseTable(returnTable, useRegId)
        Return returnTable
    End Function

    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {0, 0, 20, 20, 15, 15, 10, 10, 10}
        Me.dgvDrug.ColumnWidthCollection = nArrWidth
        Me.dgvDrug.DataSource = tableDrug.Copy()
    End Sub


    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {20, 20, 25, 20, 15}
        Me.dgvInstrument.ColumnWidthCollection = nArrWidth
        Me.dgvInstrument.DataSource = tableIns.Copy()
    End Sub

    Private Sub LoadTodaySurList()
        cmbSurList.Items.Clear()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()
        Dim operationManage As New DbOperationManage, tableSurNote As DataTable = New DataTable(), tableUseMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.SurgeryConfirm, OPerationNoteState.UnConfirmed, OPerationNoteState.Requested}
        If DBMEDITS_RESULT.SUCCESS = operationManage.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
            For Each surRow As DataRow In tableSurNote.Rows
                Dim surInfo As New SurgeryNoteInfo
                If (surInfo.TransFromDataRow(surRow)) Then
                    Me.cmbSurList.Items.Add(New With {.Key = surInfo.Id, .Value = String.Format("{0} {1} {2}", CDate(surInfo.OrderDate).ToString("MM/dd HH:mm"), surInfo.PatName, surInfo.SurName), .Detail = surInfo})
                End If
            Next
        End If
    End Sub
    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSurList.SelectedIndexChanged
        SetSureryNoteInfo(Me.cmbSurList.SelectedItem.Detail)
    End Sub

    Private Sub btnOrderExec_Click(sender As Object, e As EventArgs) Handles btnOrderExec.Click
        If dgvDrug.SelectedRows.Count <> 1 Then Return
        dgvDrug.SelectedRows(0).Cells(TEXT_DRUG_STATUS).Value = "已执行"
    End Sub

    Private Sub btnInsConfirm_Click(sender As Object, e As EventArgs) Handles btnInsConfirm.Click
        If dgvInstrument.SelectedRows.Count <> 1 Then Return
        dgvInstrument.SelectedRows(0).Cells(TEXT_INS_STATUS).Value = "准备发放"
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        CType(Me.dgvDrug.DataSource, DataTable).AcceptChanges()
        CType(Me.dgvInstrument.DataSource, DataTable).AcceptChanges()
        Dim operationManage As New DbOperationManage
        If _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryConfirm Then
            If DBMEDITS_RESULT.SUCCESS = operationManage.CommitSurgeryUseMaster(_surNoteInfo, CType(Me.dgvDrug.DataSource, DataTable), CType(Me.dgvInstrument.DataSource, DataTable)) Then
                UIMsgBox.Show(MSG_USE_SUCESS)
                LoadTodaySurList()
            Else
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            End If
        End If
      
    End Sub
    Private Sub dgvINS_CellContentClick(sender As Object, e As System.EventArgs) Handles dgvInstrument.DoubleClick
        Dim dr As DataRow = dgvInstrument.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        Dim strINSID As String = dr.Item(TEXT_INS_ID)
        Dim strINSName As String = dr.Item(TEXT_INS_NAME)
        Dim strINSType As String = String.Empty
        Dim strINSUnit As String = dr.Item(TEXT_INS_UNIT)
        Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(strINSID, strINSName, strINSType, strINSUnit)
        oFrmINSDetail.ShowDialog()
    End Sub
End Class
