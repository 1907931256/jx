Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports ITSOperationManager.Accessory
Imports UIControlLib
Imports System.Windows.Forms

Public Class FrmOperationUseReg
    Private _surNoteInfo As SurgeryInfoAccessory.SurgeryNoteInfo
    Private m_oDbOperationManage As DbOperationManage
    Private m_dtPackage As DataTable
    Private m_dtDrug As DataTable
    Private m_lstPackageINSDetailCheck As List(Of PackageINSDetailCountCheck)
    Private _dtSurList As DataTable
    Private m_dtHighValue As DataTable
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        m_oDbOperationManage = New DbOperationManage
        m_lstPackageINSDetailCheck = New List(Of PackageINSDetailCountCheck)
        LoadTodaySurList()
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
        m_lstPackageINSDetailCheck = New List(Of PackageINSDetailCountCheck)
        TableConstructor.CreateSurList(_dtSurList)
        m_oDbOperationManage = New DbOperationManage
        Dim arrINS_KIND() As INS_KINDS = {INS_KINDS.HIGH_VALUE, INS_KINDS.HIGH_VALUE_SU}
        m_oDbOperationManage.QueryInfoByType(m_dtHighValue, arrINS_KIND)
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = TEXT_OPERATION_NAME
        Me.cmbSurList.ValueMember = TEXT_OPERATION_ID
        Me.cmbSurList.DataSource = _dtSurList

        TableConstructor.CreateUseingINS(m_dtPackage)
        TableConstructor.CreateUseDrug(m_dtDrug)

        btnOrderExec.Visible = False
        btnInsConfirm.Visible = False
        LoadTodaySurList()
        cmbSurList.Text = String.Empty
    End Sub
    Private Function IsHighValue(ByVal strINSID As String) As Boolean
        Dim drFind() As DataRow = m_dtHighValue.Select(String.Format("{0}='{1}'", INS_CODE, strINSID))
        If drFind.Length < 1 Then
            Return False
        Else
            Return True
        End If
    End Function
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
            BindDrugTable(GetSurgeryDrugFrontUseTable(surNoteInfo.Id))
        ElseIf surNoteInfo.NoteStatus = OPerationNoteState.SurgeryEnd OrElse surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
            BindDrugTable(GetSurgeryDrugUseTable(surNoteInfo.UseReg.Id))
            Dim dt As DataTable = GetSurgeryInsUseTable(surNoteInfo.UseReg.Id)
            For Each dr As DataRow In dt.Rows
                Dim drNew As DataRow = m_dtPackage.NewRow
                drNew.Item(TEXT_PACKAGE_ID) = dr.Item(TEXT_PACKAGE_ID)
                drNew.Item(TEXT_INS_ID) = dr.Item(TEXT_INS_ID)
                drNew.Item(TEXT_INS_NAME) = dr.Item(TEXT_INS_NAME)
                drNew.Item(TEXT_INS_TYPE) = dr.Item(TEXT_INS_TYPE)
                drNew.Item(TEXT_INS_UNIT) = dr.Item(TEXT_INS_UNIT)
                m_dtPackage.Rows.Add(drNew)
            Next
            BindInstrumentTable(m_dtPackage)
        Else
        End If
        For Each dr As DataRow In m_dtPackage.Rows
            Dim oPackageDetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
            oPackageDetail.m_lPackageID = dr.Item(TEXT_PACKAGE_ID)
            oPackageDetail.m_lOPNID = _surNoteInfo.Id

            If _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryConfirm Then
                oPackageDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front
            ElseIf _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryEnd OrElse _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
                oPackageDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE
            End If
            If Not m_oDbOperationManage.QueryINSDetailByPKID(oPackageDetail) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                Exit Sub
            End If
            m_lstPackageINSDetailCheck.Add(oPackageDetail)
        Next
    End Sub
    Private Sub LoadInsTable()
        If m_oDbOperationManage.QueryFrontUseINSInfoByID(m_dtPackage, _surNoteInfo.Id) = DBMEDITS_RESULT.SUCCESS Then
            BindInstrumentTable(m_dtPackage)
        End If
    End Sub

    Private Function GetSurgeryDrugUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryDrugUseTable(returnTable, useRegId)
        Return returnTable
    End Function
    Private Function GetSurgeryDrugFrontUseTable(NoteRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryDrugFrontUseTable(returnTable, NoteRegId)
        Return returnTable
    End Function
    Private Sub Clear()
        m_dtPackage.Clear()
        m_dtDrug.Clear()
        BindDrugTable(m_dtDrug)
        BindInstrumentTable(m_dtPackage)
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
    Private Function GetSurgeryInsUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryInsUseTable(returnTable, useRegId)
        Return returnTable
    End Function

    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {0, 0, 20, 20, 15, 15, 10, 10, 10}
        Me.dgvDrug.DataSource = tableDrug.Copy()
        dgvDrug.Columns(0).Visible = False
        dgvDrug.Columns(1).Visible = False
    End Sub


    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Me.dgvInstrument.DataSource = tableIns.Copy()
    End Sub

    Private Sub LoadTodaySurList()
        'cmbSurList.Items.Clear()
        _dtSurList.Clear()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()
        Dim operationManage As New DbOperationManage, tableSurNote As DataTable = New DataTable(), tableUseMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.SurgeryConfirm}
        If DBMEDITS_RESULT.SUCCESS = operationManage.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
            For Each surRow As DataRow In tableSurNote.Rows
                Dim surInfo As New SurgeryNoteInfo
                If (surInfo.TransFromDataRow(surRow)) Then
                    If (surInfo.TransFromDataRow(surRow)) Then
                        Dim drNew As DataRow = _dtSurList.NewRow
                        drNew.Item(TEXT_OPERATION_ID) = surInfo.Id
                        drNew.Item(TEXT_OPERATION_NAME) = String.Format("{0} {1} {2}", CDate(surInfo.OrderDate).ToString("MM/dd HH:mm"), surInfo.PatName, surInfo.SurName)
                        _dtSurList.Rows.Add(drNew)
                    End If
                End If
            Next
            cmbSurList.DataSource = _dtSurList
        End If
    End Sub
    Private Sub ClearScan()
        txtInsScan.Text = String.Empty
        txtInsScan.Focus()
    End Sub
    Private Function CheckPackageInvalid(ByRef oPackageInfo As PackageInfo, ByVal lPackageID As Long) As Boolean
        Dim lRet As Long = m_oDbOperationManage.QueryPackageInfoByID(oPackageInfo, lPackageID)
        If lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_OPERATOR_USE_FRONT_NO_PACKAGE_INFO, lPackageID))
            ClearScan()
            Return False
        ElseIf lRet = DBMEDITS_RESULT.EXIST_OVERFLOW Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OPERATOR_USE_FRONT_OVER_PACKAGE_INFO)
            ClearScan()
            Return False
        Else
            If oPackageInfo.AvailableDate.Date < LocalData.ServerNow.Date Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_OPERATOR_USE_PACKAGE_CANNOT_USE, lPackageID))
                ClearScan()
                Return False
            End If
        End If
        Return True
    End Function
    Private Function FindPackageDetailCheck(ByVal lPackageID As Long) As PackageINSDetailCountCheck
        For Each oPackageDetailCheck As PackageINSDetailCountCheck In m_lstPackageINSDetailCheck
            If oPackageDetailCheck.m_lPackageID = lPackageID Then
                Return oPackageDetailCheck
            End If
        Next
        Return Nothing
    End Function
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
        Dim oPackageInfo As New PackageInfo
        If Not CheckPackageInvalid(oPackageInfo, CLng(strText)) Then
            Exit Sub
        End If

        For Each dr As DataRow In m_dtPackage.Rows
            If CLng(dr.Item(TEXT_PACKAGE_ID)) = CLng(strText) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_USE_PACKAGE_SCAN_ALREADY, strText))
                Exit Sub
            End If
        Next
        Dim oPackageCheck As PackageCheck = New PackageCheck
        Dim drNew As DataRow = m_dtPackage.NewRow
        drNew.Item(TEXT_PACKAGE_ID) = oPackageInfo.m_lPackageID
        drNew.Item(TEXT_INS_ID) = oPackageInfo.m_oINSInfo.m_strINSID
        drNew.Item(TEXT_INS_NAME) = oPackageInfo.m_oINSInfo.m_strName
        drNew.Item(TEXT_INS_TYPE) = oPackageInfo.m_oINSInfo.m_strType
        drNew.Item(TEXT_INS_UNIT) = oPackageInfo.m_oINSInfo.m_strUnit
        'drNew.Item(TEXT_RESULT) = TEXT_RESULT_OK
        m_dtPackage.Rows.Add(drNew)
        BindInstrumentTable(m_dtPackage)

        Dim oPackageINSdetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
        oPackageINSdetail.m_lPackageID = oPackageInfo.m_lPackageID
        oPackageINSdetail.m_strINSID = oPackageInfo.m_oINSInfo.m_strINSID
        oPackageINSdetail.m_strINSName = oPackageInfo.m_oINSInfo.m_strName
        oPackageINSdetail.m_strINSType = oPackageInfo.m_oINSInfo.m_strType
        oPackageINSdetail.m_strINSUnit = oPackageInfo.m_oINSInfo.m_strUnit

        oPackageINSdetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE
        If Not IsHighValue(oPackageInfo.m_oINSInfo.m_strINSID) Then
            Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.MIDDLE, True)
            If oFrmINSDetail.ShowDialog() = DialogResult.OK Then
                m_lstPackageINSDetailCheck.Add(oPackageINSdetail)
            End If
        End If
    End Sub
    Private Sub txtScan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInsScan.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Scan()
            txtInsScan.Clear()
            txtInsScan.Focus()
        End If
    End Sub
    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSurList.SelectedIndexChanged
        m_dtPackage.Clear()
        m_lstPackageINSDetailCheck.Clear()
        If cmbSurList.Text = String.Empty Then Exit Sub
        Dim lSurId As Long = CLng(cmbSurList.SelectedValue)
        Dim surInfo As New SurgeryNoteInfo
        If Not m_oDbOperationManage.QuerySurgeryNoteInfoByID(surInfo, lSurId) = DBMEDITS_RESULT.SUCCESS Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        SetSureryNoteInfo(surInfo)
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
            If DBMEDITS_RESULT.SUCCESS = operationManage.CommitSurgeryUseMaster(_surNoteInfo, CType(Me.dgvDrug.DataSource, DataTable), CType(Me.dgvInstrument.DataSource, DataTable), m_lstPackageINSDetailCheck) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Information, "", MSG_USE_SUCESS)
                LoadTodaySurList()
                Clear()
            Else
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            End If
        End If
      
    End Sub
    Private Sub dgvINS_CellContentClick(sender As Object, e As System.EventArgs) Handles dgvInstrument.DoubleClick
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Cells(TEXT_PACKAGE_ID).Value)

        Dim strINSID As String = dr.Cells(TEXT_INS_ID).Value
        Dim strINSName As String = dr.Cells(TEXT_INS_NAME).Value
        Dim strINSType As String = String.Empty
        Dim strINSUnit As String = Judgement.JudgeDBNullValue(dr.Cells(TEXT_INS_UNIT).Value, ENUM_DATA_TYPE.DATA_TYPE_STRING)

        If IsHighValue(strINSID) Then
            Dim oHighValueInfo As HighValueInfo = New HighValueInfo
            If m_oDbOperationManage.QueryHighValueInfoByID(oHighValueInfo, lPackageID) = DBMEDITS_RESULT.SUCCESS Then

                Dim oFrmHighValueDetail As FrmHighValueDetail = New FrmHighValueDetail(oHighValueInfo)
                oFrmHighValueDetail.ShowDialog()
            End If
        Else
            Dim oPackageINSdetail As PackageINSDetailCountCheck = FindPackageDetailCheck(lPackageID)
            Dim oFrmINSDetail As FrmINSDetail
            If oPackageINSdetail Is Nothing Then
                oPackageINSdetail = New PackageINSDetailCountCheck
                oPackageINSdetail.m_lPackageID = dr.Cells(TEXT_PACKAGE_ID).Value
                oPackageINSdetail.m_strINSID = dr.Cells(TEXT_INS_ID).Value
                oPackageINSdetail.m_strINSName = dr.Cells(TEXT_INS_NAME).Value
                oPackageINSdetail.m_strINSType = dr.Cells(TEXT_INS_TYPE).Value
                oPackageINSdetail.m_strINSUnit = dr.Cells(TEXT_INS_UNIT).Value
                oFrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.Front, True)
            Else
                oPackageINSdetail.m_lPackageID = dr.Cells(TEXT_PACKAGE_ID).Value
                oPackageINSdetail.m_strINSID = dr.Cells(TEXT_INS_ID).Value
                oPackageINSdetail.m_strINSName = dr.Cells(TEXT_INS_NAME).Value
                oPackageINSdetail.m_strINSType = dr.Cells(TEXT_INS_TYPE).Value
                oPackageINSdetail.m_strINSUnit = dr.Cells(TEXT_INS_UNIT).Value
                oFrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.Front, False)
            End If

            If oFrmINSDetail.ShowDialog() = DialogResult.OK Then
                Dim oPackageDetailCheck As PackageINSDetailCountCheck = FindPackageDetailCheck(oPackageINSdetail.m_lPackageID)
                If Not oPackageDetailCheck Is Nothing Then
                    m_lstPackageINSDetailCheck.Remove(oPackageDetailCheck)
                End If
                m_lstPackageINSDetailCheck.Add(oPackageINSdetail)
            End If

        End If



    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Cells(TEXT_PACKAGE_ID).Value)
        For Each oPackageINSDetail As PackageINSDetailCountCheck In m_lstPackageINSDetailCheck
            If oPackageINSDetail.m_lPackageID = lPackageID Then
                m_lstPackageINSDetailCheck.Remove(oPackageINSDetail)
                Exit For
            End If
        Next
        Dim nIndex As Integer = dgvInstrument.CurrentRow.Index
        If nIndex > -1 Then
            m_dtPackage.Rows.RemoveAt(nIndex)
        End If
    End Sub
End Class
