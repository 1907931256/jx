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
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        m_oDbOperationManage = New DbOperationManage
        TableConstructor.CreateUseINS(m_dtPackage)
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
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = "Value"
        Me.cmbSurList.ValueMember = "Key"
        m_oDbOperationManage = New DbOperationManage
        TableConstructor.CreateUseINS(m_dtPackage)
        BindInstrumentTable(m_dtPackage)
        pnlDrugFunc.Visible = False
        m_lstPackageCheck = New List(Of PackageCheck)
        LoadTodaySurList()
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
        ElseIf surNoteInfo.NoteStatus = OPerationNoteState.SurgeryConfirm Then
            BindDrugTable(GetSurgeryDrugFrontUseTable(surNoteInfo.Id))
            LoadSurUseInfo(surNoteInfo)
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

    Private Function GetSurgeryInsUseTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryInsUseTable(returnTable, useRegId)
        Return returnTable
    End Function

    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {0, 0, 25, 25, 20, 10, 10, 10}
        Dim nReadOnly() As Short = {True, True, True, True, True, True, True, False}
        Me.dgvDrug.ColumnWidthCollection = nArrWidth
        Me.dgvDrug.ColumnReadOnlyCollection = nReadOnly
        Me.dgvDrug.DataSource = tableDrug.Copy()
    End Sub

    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {15, 15, 25, 20, 15, 10}
        Me.dgvInstrument.ColumnWidthCollection = nArrWidth
        Me.dgvInstrument.DataSource = tableIns.Copy()
    End Sub
    Private Function CheckPackageInvalid(ByRef oPackageInfo As PackageInfo, ByVal lPackageID As Long) As Boolean
        Dim lRet As Long = m_oDbOperationManage.QueryPackageInfoByID(oPackageInfo, lPackageID)
        If lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
            UIMsgBox.MSGBoxShow(String.Format(MSG_OPERATOR_USE_FRONT_NO_PACKAGE_INFO, lPackageID))
            ClearScan()
            Return False
        ElseIf lRet = DBMEDITS_RESULT.EXIST_OVERFLOW Then
            UIMsgBox.MSGBoxShow(MSG_OPERATOR_USE_FRONT_OVER_PACKAGE_INFO)
            ClearScan()
            Return False
        Else
            If oPackageInfo.m_datAvailable.Date < LocalData.ServerNow.Date Then
                UIMsgBox.MSGBoxShow(String.Format(MSG_OPERATOR_USE_PACKAGE_CANNOT_USE, lPackageID))
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
        cmbSurList.Items.Clear()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()
        Dim operationManage As New DbOperationManage, tableSurNote As DataTable = New DataTable(), tableUseMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.UnConfirmed, OPerationNoteState.Requested, OPerationNoteState.SurgeryConfirm}
        If DBMEDITS_RESULT.SUCCESS = operationManage.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
            For Each surRow As DataRow In tableSurNote.Rows
                Dim surInfo As New SurgeryNoteInfo
                If (surInfo.TransFromDataRow(surRow)) Then
                    Me.cmbSurList.Items.Add(New With {.Key = surInfo.Id, .Value = String.Format("{0} {1} {2}", CDate(surInfo.OrderDate).ToString("MM/dd HH:mm"), surInfo.PatName, surInfo.SurName), .Detail = surInfo})
                End If
            Next
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
                UIMsgBox.MSGBoxShow(String.Format(MSG_USE_PACKAGE_SCAN_ALREADY, strText))
                Exit Sub
            End If
        Next
        Dim oPackageCheck As PackageCheck = New PackageCheck
        Dim drNew As DataRow = m_dtPackage.NewRow
        drNew.Item(TEXT_PACKAGE_ID) = oPackageInfo.m_lPackageID
        drNew.Item(TEXT_INS_ID) = oPackageInfo.m_strINSID
        drNew.Item(TEXT_INS_NAME) = oPackageInfo.m_strINSName
        drNew.Item(TEXT_INS_TYPE) = oPackageInfo.m_strINSType
        drNew.Item(TEXT_INS_UNIT) = oPackageInfo.m_strINSUnit
        drNew.Item(TEXT_RESULT) = TEXT_RESULT_OK
        m_dtPackage.Rows.Add(drNew)
        oPackageCheck.m_oPackageInfo = oPackageInfo
        oPackageCheck.m_nResult = EnumDef.CHECK_RESULT.PASS
        oPackageCheck.m_strReason = String.Empty
        m_lstPackageCheck.Add(oPackageCheck)
        BindInstrumentTable(m_dtPackage)

    End Sub
    Private Sub UpdateInsTable()
        m_dtPackage.Clear()
        For Each oPackageCheck As PackageCheck In m_lstPackageCheck
            Dim drNew As DataRow = m_dtPackage.NewRow
            drNew.Item(TEXT_PACKAGE_ID) = oPackageCheck.m_oPackageInfo.m_lPackageID
            drNew.Item(TEXT_INS_ID) = oPackageCheck.m_oPackageInfo.m_strINSID
            drNew.Item(TEXT_INS_NAME) = oPackageCheck.m_oPackageInfo.m_strINSName
            drNew.Item(TEXT_INS_TYPE) = oPackageCheck.m_oPackageInfo.m_strINSType
            drNew.Item(TEXT_INS_UNIT) = oPackageCheck.m_oPackageInfo.m_strINSUnit
            drNew.Item(TEXT_RESULT) = MatchCheckStateToString(oPackageCheck.m_nResult)
            m_dtPackage.Rows.Add(drNew)
        Next
        BindInstrumentTable(m_dtPackage)
    End Sub
    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs)
        m_dtPackage.Clear()
        m_lstPackageCheck.Clear()
        SetSureryNoteInfo(Me.cmbSurList.SelectedItem.Detail)
    End Sub

    Private Sub btnInsConfirm_Click(sender As Object, e As EventArgs)
        Dim dr As DataRow = dgvInstrument.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Item(TEXT_PACKAGE_ID))
        Dim oFrmOPFrontCheck As FrmOPFrontCheck = New FrmOPFrontCheck(m_lstPackageCheck, lPackageID)
        If oFrmOPFrontCheck.ShowDialog = DialogResult.OK Then
            UpdateInsTable()
        End If
    End Sub
    Private Function QueryPackageInfo(ByRef oPackageInfo As PackageInfo) As Boolean
        Dim operationManage As New DbOperationManage, dtPackageInfo As New DataTable
        Dim lRet As DBMEDITS_RESULT
        lRet = operationManage.QueryPackageInfoByID(dtPackageInfo, dgvInstrument.CurrentDataRow.Item(TEXT_PACKAGE_ID))
        If lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
            UIMsgBox.Show(MSG_OPERATOR_USE_FRONT_NO_PACKAGE_INFO)
        ElseIf lRet = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.Show(MSG_DBERROR_EXCEPTION)
        Else
            Dim datAvaliable As DateTime = dtPackageInfo.Rows(0).Item(SRS_AVAILABLE_DATE)
            If datAvaliable.Date < LocalData.ServerNow.Date Then
                UIMsgBox.Show(String.Format(MSG_OPERATOR_USE_PACKAGE_CANNOT_USE, dtPackageInfo.Rows(0).Item(SRS_PACKAGE_ID)))
            End If
            oPackageInfo.m_lPackageID = dtPackageInfo.Rows(0).Item(TEXT_PACKAGE_ID)
            oPackageInfo.m_strINSID = dtPackageInfo.Rows(0).Item(TEXT_INS_ID)
            oPackageInfo.m_strINSName = dtPackageInfo.Rows(0).Item(TEXT_INS_NAME)
            oPackageInfo.m_strINSType = dtPackageInfo.Rows(0).Item(TEXT_INS_TYPE)
            oPackageInfo.m_strINSUnit = dtPackageInfo.Rows(0).Item(TEXT_INS_TYPE)
            oPackageInfo.m_datSterilize = dtPackageInfo.Rows(0).Item(TEXT_STERILIZE_DATE)
            oPackageInfo.m_datAvailable = dtPackageInfo.Rows(0).Item(TEXT_VALID_DATE)
        End If
        Return True
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs)
        Dim operationManage As New DbOperationManage
        Dim dt As DataTable = dgvDrug.DataSource

        If _surNoteInfo.NoteStatus = OPerationNoteState.Requested OrElse _surNoteInfo.NoteStatus = OPerationNoteState.UnConfirmed Then
            If DBMEDITS_RESULT.SUCCESS = operationManage.CommitSurgeryFrontUseMaster(m_lstPackageCheck, dt, _surNoteInfo, CHECK_TYPE.FRONT) Then
                UIMsgBox.Show(MSG_USE_FRONT_SUCESS)
                LoadTodaySurList()
            Else
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            End If
        ElseIf _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryConfirm Then
            If DBMEDITS_RESULT.SUCCESS = operationManage.ModifySurgeryFrontUseMaster(m_lstPackageCheck, dt, _surNoteInfo, CHECK_TYPE.FRONT) Then
                UIMsgBox.Show(MSG_USE_FRONT_SUCESS)
                LoadTodaySurList()
            Else
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
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
        Dim dr As DataRow = dgvInstrument.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        Dim strINSID As String = dr.Item(TEXT_INS_ID)
        Dim strINSName As String = dr.Item(TEXT_INS_NAME)
        Dim strINSType As String = String.Empty
        Dim strINSUnit As String = dr.Item(TEXT_INS_UNIT)
        Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(strINSID, strINSName, strINSType, strINSUnit)
        oFrmINSDetail.ShowDialog()
    End Sub


    Private Sub FrmOperationUseFront_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.pnlSurInfo.Width = Me.Width / 4
        Me.btnOK.Left = (Me.pnlCommit.Width - Me.btnOK.Width) / 2
    End Sub
End Class
