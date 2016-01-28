Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports ITSOperationManager.Accessory
Imports UIControlLib
Imports System.Windows.Forms

Public Class FrmOperationUseFront
    Private _surNoteInfo As SurgeryInfoAccessory.SurgeryNoteInfo
    Private m_dtPackage As DataTable
    Private m_oDbOperationManage As DbOperationManage
    Private m_lstPackageCheck As List(Of PackageCheck)
    Private m_lstPackageINSDetailCheck As List(Of PackageINSDetailCountCheck)
    Private _dtSurList As DataTable
    Private m_dtHighValue As DataTable
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        m_oDbOperationManage = New DbOperationManage
        TableConstructor.CreateUseINS(m_dtPackage)
        m_lstPackageCheck.Clear()
        m_lstPackageINSDetailCheck.Clear()
        LoadTodaySurList()
        SetSureryNoteInfo(surNoteInfo)
    End Sub

    Private Sub LoadSurUseInfo(ByRef surNoteInfo As SurgeryNoteInfo)
        '根据手术通知单号，载入术前拆包确认登记使用信息
        Dim operationManage As New DbOperationManage, tableUseMaster As New DataTable
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QueryFrontUseInfoByNoteId(m_lstPackageCheck, surNoteInfo.Id, CHECK_TYPE.FRONT) Then
            UpdateInsTable()
            BindInstrumentTable(tableUseMaster)
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
        m_oDbOperationManage = New DbOperationManage
        TableConstructor.CreateUseINS(m_dtPackage)
        BindInstrumentTable(m_dtPackage)
        btnMed.Visible = False
        m_lstPackageCheck = New List(Of PackageCheck)
        m_lstPackageINSDetailCheck = New List(Of PackageINSDetailCountCheck)
        m_dtHighValue = New DataTable
        Dim arrINS_KIND() As INS_KINDS = {INS_KINDS.HIGH_VALUE, INS_KINDS.HIGH_VALUE_SU}
        m_oDbOperationManage.QueryInfoByType(m_dtHighValue, arrINS_KIND)
        TableConstructor.CreateSurList(_dtSurList)
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = TEXT_OPERATION_NAME
        Me.cmbSurList.ValueMember = TEXT_OPERATION_ID
        Me.cmbSurList.DataSource = _dtSurList
        LoadTodaySurList()
        cmbSurList.Text = String.Empty
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
        If surNoteInfo.NoteStatus = OPerationNoteState.UnConfirmed OrElse surNoteInfo.NoteStatus = OPerationNoteState.Requested Then
            BtnEnable(True)
            BindDrugTable(GetSurgeryDrugRequestTable(surNoteInfo.Id))
        Else
            BindDrugTable(GetSurgeryDrugFrontUseTable(surNoteInfo.Id))
            LoadSurUseInfo(surNoteInfo)
            m_lstPackageINSDetailCheck.Clear()
            For Each dr As DataRow In m_dtPackage.Rows
                Dim oPackageDetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
                oPackageDetail.m_lPackageID = dr.Item(TEXT_PACKAGE_ID)
                oPackageDetail.m_lOPNID = surNoteInfo.Id
                oPackageDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front
                If Not m_oDbOperationManage.QueryINSDetailByPKID(oPackageDetail) = DBMEDITS_RESULT.SUCCESS Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                    Exit Sub
                End If
                m_lstPackageINSDetailCheck.Add(oPackageDetail)
            Next
            BtnEnable(False)
        End If
        BindInstrumentTable(m_dtPackage)
        _surNoteInfo = surNoteInfo
    End Sub
    Private Sub SetSureryNoteInfo()
        Dim lOPN_ID As Long = cmbSurList.SelectedValue
        If Not m_oDbOperationManage.QuerySurgeryInfoByID(_surNoteInfo, lOPN_ID) = DBMEDITS_RESULT.SUCCESS Then
            Exit Sub
        End If
        Me.tbSurTime.Text = _surNoteInfo.OrderDate
        Me.tbSurName.Text = _surNoteInfo.SurName
        Me.tbSurRoom.Text = _surNoteInfo.Room
        Me.tbTable.Text = _surNoteInfo.Table
        Me.tbVisit.Text = _surNoteInfo.VisitId
        Me.tbPatName.Text = _surNoteInfo.PatName
        Me.tbGender.Text = _surNoteInfo.Gender
        Me.tbAge.Text = _surNoteInfo.Age
        Me.tbSurDr.Text = _surNoteInfo.Surgeon
        Me.tbDiagnosis.Text = _surNoteInfo.Diagnosis
        Me.tbMemo.Text = _surNoteInfo.Memo
        Me.cmbSurList.Text = String.Format("{0} {1} {2}", CDate(_surNoteInfo.OrderDate).ToString("MM/dd HH:mm"), _surNoteInfo.PatName, _surNoteInfo.SurName)
        '载入药品和物品
        If _surNoteInfo.NoteStatus = OPerationNoteState.UnConfirmed OrElse _surNoteInfo.NoteStatus = OPerationNoteState.Requested Then
            BtnEnable(True)
            BindDrugTable(GetSurgeryDrugRequestTable(_surNoteInfo.Id))
        Else
            BindDrugTable(GetSurgeryDrugFrontUseTable(_surNoteInfo.Id))
            LoadSurUseInfo(_surNoteInfo)
            m_lstPackageINSDetailCheck.Clear()
            For Each dr As DataRow In m_dtPackage.Rows
                Dim oPackageDetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
                oPackageDetail.m_lPackageID = dr.Item(TEXT_PACKAGE_ID)
                oPackageDetail.m_lOPNID = _surNoteInfo.Id
                oPackageDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front
                If Not m_oDbOperationManage.QueryINSDetailByPKID(oPackageDetail) = DBMEDITS_RESULT.SUCCESS Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                    Exit Sub
                End If
                m_lstPackageINSDetailCheck.Add(oPackageDetail)
            Next
            BtnEnable(False)
        End If

        BindInstrumentTable(m_dtPackage)
        _surNoteInfo = _surNoteInfo
    End Sub
    Private Sub BtnEnable(ByVal bEnable As Boolean)
        btnOK.Enabled = bEnable
        btnInsConfirm.Enabled = bEnable
    End Sub
    Private Function GetSurgeryDrugRequestTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryDrugRequestTable(returnTable, useRegId)
        Return returnTable
    End Function
    Private Function GetSurgeryDrugFrontUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryDrugFrontUseTable(returnTable, useRegId)
        Return returnTable
    End Function


    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {0, 0, 25, 25, 20, 10, 10, 10}
        Dim nReadOnly() As Short = {True, True, True, True, True, True, True, False}
        Me.dgvDrug.DataSource = tableDrug.Copy()
        dgvDrug.Columns(0).Visible = False
        dgvDrug.Columns(1).Visible = False
        dgvDrug.Columns(7).ReadOnly = False
    End Sub

    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {15, 15, 25, 20, 15, 10}
        Me.dgvInstrument.DataSource = tableIns.Copy()
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

    Private Sub ClearScan()
        txtInsScan.Text = String.Empty
        txtInsScan.Focus()
    End Sub

    Private Sub LoadTodaySurList()
        ClearAll()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.UnConfirmed, OPerationNoteState.Requested, OPerationNoteState.SurgeryConfirm}
        Dim tableSurNote As DataTable = New DataTable(), tableReqMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        If DBMEDITS_RESULT.SUCCESS = m_oDbOperationManage.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
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

        For Each oPackageInfoChec As PackageCheck In m_lstPackageCheck
            If oPackageInfoChec.m_oPackageInfo.m_lPackageID = CLng(strText) Then
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
        drNew.Item(TEXT_RESULT) = TEXT_RESULT_OK
        m_dtPackage.Rows.Add(drNew)
        oPackageCheck.m_oPackageInfo = oPackageInfo
        oPackageCheck.m_nResult = EnumDef.CHECK_RESULT.PASS
        oPackageCheck.m_strReason = String.Empty
        m_lstPackageCheck.Add(oPackageCheck)
        BindInstrumentTable(m_dtPackage)
        If Not IsHighValue(oPackageInfo.m_oINSInfo.m_strINSID) Then
            Dim oPackageINSdetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
            oPackageINSdetail.m_lPackageID = oPackageInfo.m_lPackageID
            oPackageINSdetail.m_strINSID = oPackageInfo.m_oINSInfo.m_strINSID
            oPackageINSdetail.m_strINSName = oPackageInfo.m_oINSInfo.m_strName
            oPackageINSdetail.m_strINSType = oPackageInfo.m_oINSInfo.m_strType
            oPackageINSdetail.m_strINSUnit = oPackageInfo.m_oINSInfo.m_strUnit
            oPackageINSdetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front
            Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.Front, True)
            If oFrmINSDetail.ShowDialog() = DialogResult.OK Then
                m_lstPackageINSDetailCheck.Add(oPackageINSdetail)
            End If
        End If

    End Sub
    Private Sub ClearAll()
        _dtSurList.Clear()
        m_lstPackageINSDetailCheck.Clear()
        m_lstPackageCheck.Clear()
        m_dtPackage.Clear()
        BindInstrumentTable(m_dtPackage)
        Dim dt As DataTable = dgvDrug.DataSource
        If Not dt Is Nothing Then
            dt.Clear()
            BindDrugTable(dt)
        End If
        Clear()
    End Sub
    Private Function IsHighValue(ByVal strINSID As String) As Boolean
        Dim drFind() As DataRow = m_dtHighValue.Select(String.Format("{0}='{1}'", INS_CODE, strINSID))
        If drFind.Length < 1 Then
            Return False
        Else
            Return True
        End If
    End Function
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
    Private Sub UpdateInsTable()
        m_dtPackage.Clear()
        For Each oPackageCheck As PackageCheck In m_lstPackageCheck
            Dim drNew As DataRow = m_dtPackage.NewRow
            drNew.Item(TEXT_PACKAGE_ID) = oPackageCheck.m_oPackageInfo.m_lPackageID
            drNew.Item(TEXT_INS_ID) = oPackageCheck.m_oPackageInfo.m_oINSInfo.m_strINSID
            drNew.Item(TEXT_INS_NAME) = oPackageCheck.m_oPackageInfo.m_oINSInfo.m_strName
            drNew.Item(TEXT_INS_TYPE) = oPackageCheck.m_oPackageInfo.m_oINSInfo.m_strType
            drNew.Item(TEXT_INS_UNIT) = oPackageCheck.m_oPackageInfo.m_oINSInfo.m_strUnit
            drNew.Item(TEXT_RESULT) = MatchCheckStateToString(oPackageCheck.m_nResult)
            m_dtPackage.Rows.Add(drNew)
            If oPackageCheck.m_nResult = CInt(CHECK_RESULT.FAILD) Then
                Dim oPackageDetailCheck As PackageINSDetailCountCheck = FindPackageDetailCheck(oPackageCheck.m_oPackageInfo.m_lPackageID)
                If Not oPackageDetailCheck Is Nothing Then
                    m_lstPackageINSDetailCheck.Remove(oPackageDetailCheck)
                End If
            End If
        Next

        BindInstrumentTable(m_dtPackage)
    End Sub
    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSurList.SelectedIndexChanged
        m_dtPackage.Clear()
        m_lstPackageCheck.Clear()
        m_lstPackageINSDetailCheck.Clear()
        Clear()
        If cmbSurList.Text = String.Empty Then Exit Sub
        Dim lSurId As Long = CLng(cmbSurList.SelectedValue)
        Dim surInfo As New SurgeryNoteInfo
        If Not m_oDbOperationManage.QuerySurgeryNoteInfoByID(surInfo, lSurId) = DBMEDITS_RESULT.SUCCESS Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        SetSureryNoteInfo(surInfo)
        m_lstPackageINSDetailCheck.Clear()
        For Each dr As DataRow In m_dtPackage.Rows
            Dim oPackageDetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
            oPackageDetail.m_lPackageID = dr.Item(TEXT_PACKAGE_ID)
            oPackageDetail.m_lOPNID = surInfo.Id
            oPackageDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front
            If Not m_oDbOperationManage.QueryINSDetailByPKID(oPackageDetail) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                Exit Sub
            End If
            m_lstPackageINSDetailCheck.Add(oPackageDetail)
        Next
    End Sub

    Private Sub btnInsConfirm_Click(sender As Object, e As EventArgs) Handles btnInsConfirm.Click
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Cells(TEXT_PACKAGE_ID).Value)
        Dim oFrmOPFrontCheck As FrmOPFrontCheck = New FrmOPFrontCheck(m_lstPackageCheck, lPackageID)
        If oFrmOPFrontCheck.ShowDialog = DialogResult.OK Then
            UpdateInsTable()
        End If
    End Sub
    Private Function QueryPackageInfo(ByRef oPackageInfo As PackageInfo) As Boolean
        Dim operationManage As New DbOperationManage, dtPackageInfo As New DataTable
        Dim lRet As DBMEDITS_RESULT
        lRet = operationManage.QueryPackageInfoByID(dtPackageInfo, dgvInstrument.CurrentRow.Cells(TEXT_PACKAGE_ID).Value)
        If lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OPERATOR_USE_FRONT_NO_PACKAGE_INFO)
        ElseIf lRet = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
        Else
            Dim datAvaliable As DateTime = dtPackageInfo.Rows(0).Item(SRS_AVAILABLE_DATE)
            If datAvaliable.Date < LocalData.ServerNow.Date Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_OPERATOR_USE_PACKAGE_CANNOT_USE, dtPackageInfo.Rows(0).Item(SRS_PACKAGE_ID)))
            End If
            oPackageInfo.m_lPackageID = dtPackageInfo.Rows(0).Item(TEXT_PACKAGE_ID)
            oPackageInfo.m_oINSInfo.m_strINSID = dtPackageInfo.Rows(0).Item(TEXT_INS_ID)
            oPackageInfo.m_oINSInfo.m_strName = dtPackageInfo.Rows(0).Item(TEXT_INS_NAME)
            oPackageInfo.m_oINSInfo.m_strType = dtPackageInfo.Rows(0).Item(TEXT_INS_TYPE)
            oPackageInfo.m_oINSInfo.m_strUnit = dtPackageInfo.Rows(0).Item(TEXT_INS_TYPE)
            oPackageInfo.SterilizeDate = dtPackageInfo.Rows(0).Item(TEXT_STERILIZE_DATE)
            oPackageInfo.AvailableDate = dtPackageInfo.Rows(0).Item(TEXT_VALID_DATE)
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


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim operationManage As New DbOperationManage
        Dim dt As DataTable = dgvDrug.DataSource

        If _surNoteInfo.NoteStatus = OPerationNoteState.Requested OrElse _surNoteInfo.NoteStatus = OPerationNoteState.UnConfirmed Then
            If DBMEDITS_RESULT.SUCCESS = operationManage.CommitSurgeryFrontUseMaster(m_lstPackageCheck, m_lstPackageINSDetailCheck, dt, _surNoteInfo, CHECK_TYPE.FRONT) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_USE_FRONT_SUCESS)
                LoadTodaySurList()
            Else
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            End If
        ElseIf _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryConfirm Then
            If DBMEDITS_RESULT.SUCCESS = operationManage.ModifySurgeryFrontUseMaster(m_lstPackageCheck, dt, _surNoteInfo, CHECK_TYPE.FRONT) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_USE_FRONT_SUCESS)
                LoadTodaySurList()
            Else
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            End If
        Else

        End If
       
    End Sub
    Private Sub txtScan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInsScan.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Scan()
            txtInsScan.Clear()
            txtInsScan.Focus()
        End If
    End Sub
    Private Sub dgvINS_CellContentClick(sender As Object, e As System.EventArgs) Handles dgvInstrument.DoubleClick
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Cells(TEXT_PACKAGE_ID).Value)

        Dim strINSID As String = dr.Cells(TEXT_INS_ID).Value
        Dim strINSName As String = dr.Cells(TEXT_INS_NAME).Value
        Dim strINSType As String = String.Empty
        Dim strINSUnit As String = dr.Cells(TEXT_INS_UNIT).Value
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
    Private Sub OnButtonCellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.RowIndex > -1 Then
            Dim dr As DataRow
            dr = m_dtPackage.Rows(e.RowIndex)
            If dr Is Nothing Then Exit Sub

            Dim oPackageDetailCheck As PackageINSDetailCountCheck = FindPackageDetailCheck(dr.Item(TEXT_PACKAGE_ID))
            If Not oPackageDetailCheck Is Nothing Then
                m_lstPackageINSDetailCheck.Remove(oPackageDetailCheck)
            End If
            m_dtPackage.Rows.Remove(dr)
            'BindInstrumentTable(m_dtPackage)
        End If
    End Sub

    Private Sub btnMed_Click(sender As Object, e As EventArgs) Handles btnMed.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Cells(TEXT_PACKAGE_ID).Value)
        For Each oPackageCheck As PackageCheck In m_lstPackageCheck
            If oPackageCheck.m_oPackageInfo.m_lPackageID = lPackageID Then
                m_lstPackageCheck.Remove(oPackageCheck)
                Exit For
            End If
        Next
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
        BindInstrumentTable(m_dtPackage)
    End Sub

End Class
