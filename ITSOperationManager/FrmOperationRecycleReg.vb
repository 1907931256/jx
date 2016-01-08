Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports UIControlLib
Imports System.Windows.Forms

Public Class FrmOperationRecycleReg
    Private _surNoteInfo As SurgeryInfoAccessory.SurgeryNoteInfo
    Private m_dtDrug As DataTable
    Private m_dtINS As DataTable
    Private m_oDbOperationManage As DbOperationManage
    Private Sub FrmOperationRecycleReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = "Value"
        Me.cmbSurList.ValueMember = "Key"
        m_oDbOperationManage = New DbOperationManage
        TableConstructor.CreateReturnDrug(m_dtDrug)
        TableConstructor.CreateReturnINS(m_dtINS)
        BindDrugTable(m_dtDrug)
        BindInstrumentTable(m_dtINS)
        LoadTodaySurList()
    End Sub

    Private Sub LoadTodaySurList()
        ClearAll()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()

        Dim operationManage As New DbOperationManage, tableSurNote As DataTable = New DataTable(), tableUseMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.SurgeryEnd, OPerationNoteState.UnConfirmed, OPerationNoteState.Requested, OPerationNoteState.SurgeryConfirm}
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
            For Each surRow As DataRow In tableSurNote.Rows
                Dim surInfo As New SurgeryInfoAccessory.SurgeryNoteInfo
                If (surInfo.TransFromDataRow(surRow)) Then
                    Me.cmbSurList.Items.Add(New With {.Key = surInfo.Id, .Value = String.Format("{0} {1} {2}", CDate(surInfo.OrderDate).ToString("MM/dd HH:mm"), surInfo.PatName, surInfo.SurName), .Detail = surInfo})
                End If
            Next
        End If
    End Sub
    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSurList.SelectedIndexChanged
        SetSureryNoteInfo(Me.cmbSurList.SelectedItem.Detail)
    End Sub
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        m_oDbOperationManage = New DbOperationManage
        SetSureryNoteInfo(surNoteInfo)
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
        LoadSurUseInfo(surNoteInfo)
        BindDrugTable(GetSurgeryDrugUseTable(surNoteInfo.UseReg.Id))
        BindInstrumentTable(GetSurgeryInsUseTable(surNoteInfo.UseReg.Id))
        _surNoteInfo = surNoteInfo
    End Sub
    Private Sub LoadSurUseInfo(ByRef surNoteInfo As SurgeryNoteInfo)
        '根据手术通知单号，载入使用信息
        m_oDbOperationManage = New DbOperationManage
        TableConstructor.CreateReturnDrug(m_dtDrug)
        TableConstructor.CreateReturnINS(m_dtINS)
        BindDrugTable(m_dtDrug)
        BindInstrumentTable(m_dtINS)
        Dim operationManage As New DbOperationManage, tableUseMaster As New DataTable
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QueryUseMasterInfoByNoteId(tableUseMaster, surNoteInfo.Id) AndAlso Not tableUseMaster.IsNullOrEmpty() Then
            surNoteInfo.UseReg.TransFromDataRow(tableUseMaster.Rows(0))
        Else
            'FormUseRegInfo(surNoteInfo)
        End If
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
        m_dtDrug.Clear()
        m_dtINS.Clear()
        BindInstrumentTable(m_dtINS)
    End Sub
    Private Function GetSurgeryDrugUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryDrugUseEndTable(returnTable, useRegId)
        m_dtDrug.Clear()
        For Each dr As DataRow In returnTable.Rows
            Dim drNew As DataRow = m_dtDrug.NewRow
            drNew.Item(TEXT_DRUG_ID) = dr.Item(DUD_DRUG_CODE)
            drNew.Item(TEXT_DRUG_COMMON_NAME) = dr.Item(DUD_COMMON_NAME)
            drNew.Item(TEXT_DRUG_PRODUCT_NAME) = dr.Item(DUD_PRODUCT_NAME)
            drNew.Item(TEXT_DRUG_SPECIFICATION) = dr.Item(DUD_DRUG_SPEC)
            drNew.Item(TEXT_DRUG_UNIT) = dr.Item(DUD_MEASUER_UNITS)
            drNew.Item(TEXT_DRUG_FACTORY) = dr.Item(DUD_DRUG_FACTORY)
            drNew.Item(TEXT_DRUG_AMOUNT) = dr.Item(DUD_PACK_COUNT)
            drNew.Item(TEXT_DRUG_BACK_COUNT) = 0
            drNew.Item(TEXT_DRUG_RETURN_COUNT) = 0
            m_dtDrug.Rows.Add(drNew)
        Next
        Return m_dtDrug
    End Function
    Private Function GetSurgeryInsUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryInsUseTable(returnTable, useRegId)
        For Each dr As DataRow In returnTable.Rows
            Dim drNew As DataRow = m_dtINS.NewRow
            drNew.Item(TEXT_PACKAGE_ID) = dr.Item(TEXT_PACKAGE_ID)
            drNew.Item(TEXT_INS_ID) = dr.Item(TEXT_INS_ID)
            drNew.Item(TEXT_INS_NAME) = dr.Item(TEXT_INS_NAME)
            drNew.Item(TEXT_INS_TYPE) = dr.Item(TEXT_INS_TYPE)
            drNew.Item(TEXT_INS_UNIT) = dr.Item(TEXT_INS_UNIT)
            drNew.Item(TEXT_RETURN_IS_EXIST) = String.Empty
            m_dtINS.Rows.Add(drNew)
        Next
        Return m_dtINS
    End Function
    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {0, 0, 15, 15, 15, 15, 10, 10, 10, 10}
        Dim nRead() As Boolean = {True, True, True, True, True, True, True, False, False, False}
        Me.dgvDrug.ColumnReadOnlyCollection = nRead
        Me.dgvDrug.ColumnWidthCollection = nArrWidth
        Me.dgvDrug.DataSource = tableDrug.Copy()
    End Sub
    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {15, 15, 25, 20, 15, 10}
        Me.dgvInstrument.ClearBoolColumn()
        Me.dgvInstrument.SetBoolColumn(TEXT_RETURN_IS_EXIST, TEXT_CHECK, String.Empty)
        Me.dgvInstrument.ColumnWidthCollection = nArrWidth
        Me.dgvInstrument.DataSource = tableIns.Copy()
    End Sub
    Private Function CheckPackageInvalid(ByVal lPackageID As Long) As Boolean
        For Each dr As DataRow In m_dtINS.Rows
            If CInt(dr.Item(TEXT_PACKAGE_ID)) = lPackageID Then
                dr.Item(TEXT_RETURN_IS_EXIST) = TEXT_CHECK
                Return True
            End If
        Next
        UIMsgBox.MSGBoxShow(String.Format(MSG_RETURN_PACKAGE_NOT_USE, lPackageID))
        Return False
    End Function
    Private Sub ClearScan()
        txtInsScan.Text = String.Empty
        txtInsScan.Focus()
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If _surNoteInfo Is Nothing Then
            Exit Sub
        End If
        m_dtDrug = dgvDrug.DataSource
        If m_dtDrug.Rows.Count < 1 AndAlso m_dtINS.Rows.Count < 1 Then
            Exit Sub
        End If
        If _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryEnd Then
            Dim oDbReturn As DbOperationManage = New DbOperationManage
            If Not oDbReturn.InsertReturnInfo(_surNoteInfo, m_dtDrug, m_dtINS) = DBMEDITS_RESULT.SUCCESS Then
                UIMsgBox.Show(MSG_DBERROR_EXCEPTION)
            Else
                UIMsgBox.Show(MSG_RETURN_SUCESS)
                LoadTodaySurList()
            End If
        End If
    End Sub
    Private Sub Scan()
        Dim strText As String = txtInsScan.Text
        Dim oType As BAR_CODE_TYPE = BarCodeParse.ParseCode(strText)
        If oType = BAR_CODE_TYPE.BARCODE_PACKAGE Then
            If Not IsNumeric(strText) Then
                Exit Sub
            End If
            If strText = String.Empty Then
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        If Not CheckPackageInvalid(CLng(strText)) Then
            Exit Sub
        End If
        BindInstrumentTable(m_dtINS)
    End Sub
    Private Sub txtScan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInsScan.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Scan()
            txtInsScan.Clear()
            txtInsScan.Focus()
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim dr As DataRow = dgvInstrument.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Item(TEXT_PACKAGE_ID))
        If Not CheckPackageInvalid(lPackageID) Then
            Exit Sub
        End If
        BindInstrumentTable(m_dtINS)
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
