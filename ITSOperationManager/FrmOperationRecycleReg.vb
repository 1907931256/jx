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
    Private m_lstPackageINSDetailCheck As List(Of PackageINSDetailCountCheck)
    Private _dtSurList As DataTable
    Private m_dtOPerarerINSList As DataTable
    Private m_nCurrentRow As Integer
    Private m_dtHighValue As New DataTable
    Private Sub FrmOperationRecycleReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_lstPackageINSDetailCheck = New List(Of PackageINSDetailCountCheck)
        TableConstructor.CreateSurList(_dtSurList)
        m_oDbOperationManage = New DbOperationManage
        Dim arrINS_KIND() As INS_KINDS = {INS_KINDS.HIGH_VALUE, INS_KINDS.HIGH_VALUE_SU}
        m_oDbOperationManage.QueryInfoByType(m_dtHighValue, arrINS_KIND)
        m_nCurrentRow = 0
        TableConstructor.CreateSurINSList(m_dtOPerarerINSList)
        Me.cmbSurList.Items.Clear()
        Me.cmbSurList.DisplayMember = TEXT_OPERATION_NAME
        Me.cmbSurList.ValueMember = TEXT_OPERATION_ID
        Me.cmbSurList.DataSource = _dtSurList
        _surNoteInfo = New SurgeryNoteInfo
        TableConstructor.CreateReturnDrug(m_dtDrug)
        TableConstructor.CreateReturnINS(m_dtINS)
        BindDrugTable(m_dtDrug)
        BindInstrumentTable(m_dtINS)
        LoadTodaySurList()
        cmbSurList.Text = String.Empty
    End Sub

    Private Sub LoadTodaySurList()
        ClearAll()
        Dim startTime As String = DateTime.Now.Date.ToString()
        Dim endTime As String = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString()

        Dim operationManage As New DbOperationManage, tableSurNote As DataTable = New DataTable(), tableUseMaster As New DataTable
        TableConstructor.CreateOperationNote(tableSurNote)
        Dim arrStatus() As OPerationNoteState = New OPerationNoteState() {OPerationNoteState.SurgeryEnd}
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QuerySurgeryNoteInfo(tableSurNote, startTime, endTime, String.Empty, arrStatus) AndAlso Not tableSurNote.IsNullOrEmpty() Then
            For Each surRow As DataRow In tableSurNote.Rows
                Dim surInfo As New SurgeryInfoAccessory.SurgeryNoteInfo
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
    Private Function FindPackageDetailCheck(ByVal lPackageID As Long) As PackageINSDetailCountCheck
        For Each oPackageDetailCheck As PackageINSDetailCountCheck In m_lstPackageINSDetailCheck
            If oPackageDetailCheck.m_lPackageID = lPackageID Then
                Return oPackageDetailCheck
            End If
        Next
        Return Nothing
    End Function
    Private Sub cmbSurList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSurList.SelectedIndexChanged
        m_dtINS.Clear()
        m_dtOPerarerINSList.Clear()
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
    Private Function IsHighValue(ByVal strINSID As String) As Boolean
        Dim drFind() As DataRow = m_dtHighValue.Select(String.Format("{0}='{1}'", INS_CODE, strINSID))
        If drFind.Length < 1 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub LoadSurgeryInfo(ByVal surNoteInfo As SurgeryNoteInfo)
        m_oDbOperationManage = New DbOperationManage
        m_nCurrentRow = 0
        _surNoteInfo = surNoteInfo
        LoadTodaySurList()
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
        If surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
            btnOK.Enabled = False
        Else
            btnOK.Enabled = True
        End If
        _surNoteInfo = surNoteInfo
        If _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
            BindDrugTable(GetSurgeryDrugReturnTable(surNoteInfo.Id))
            BindInstrumentTable(GetSurgeryInsReturnTable(surNoteInfo.Id))
        Else
            BindDrugTable(GetSurgeryDrugUseTable(surNoteInfo.UseReg.Id))
            BindInstrumentTable(GetSurgeryInsUseTable(surNoteInfo.UseReg.Id))
        End If

        For Each dr As DataRow In m_dtINS.Rows
            Dim oPackageDetail As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
            oPackageDetail.m_lPackageID = dr.Item(TEXT_PACKAGE_ID)
            oPackageDetail.m_strINSID = dr.Item(TEXT_INS_ID)
            oPackageDetail.m_strINSName = dr.Item(TEXT_INS_NAME)
            oPackageDetail.m_strINSType = Judgement.JudgeDBNullValue(dr.Item(TEXT_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            oPackageDetail.m_strINSUnit = Judgement.JudgeDBNullValue(dr.Item(TEXT_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            oPackageDetail.m_lOPNID = _surNoteInfo.Id

            If _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
                oPackageDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.AFTER
            ElseIf _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryEnd Then
                oPackageDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE
            End If
            If Not m_oDbOperationManage.QueryINSDetailByPKID(oPackageDetail) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                Exit Sub
            End If
            m_lstPackageINSDetailCheck.Add(oPackageDetail)
        Next
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
        _dtSurList.Clear()
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
        m_dtOPerarerINSList.Clear()
        m_dtDrug.Clear()
        m_dtINS.Clear()
        BindDrugTable(m_dtDrug)
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
    Private Function GetSurgeryDrugReturnTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryDrugReturnTable(returnTable, useRegId)
        m_dtDrug.Clear()
        For Each dr As DataRow In returnTable.Rows
            Dim drNew As DataRow = m_dtDrug.NewRow
            drNew.Item(TEXT_DRUG_ID) = dr.Item(DRD_DRUG_ID)
            drNew.Item(TEXT_DRUG_COMMON_NAME) = dr.Item(DRD_COMMON_NAME)
            drNew.Item(TEXT_DRUG_PRODUCT_NAME) = dr.Item(DRD_PRODUCT_NAME)
            drNew.Item(TEXT_DRUG_SPECIFICATION) = dr.Item(DRD_DRUG_SPEC)
            drNew.Item(TEXT_DRUG_UNIT) = dr.Item(DRD_MEASUER_UNITS)
            drNew.Item(TEXT_DRUG_FACTORY) = dr.Item(DRD_DRUG_FACTORY)
            drNew.Item(TEXT_DRUG_BACK_COUNT) = dr.Item(DRD_BACK_COUNT)
            drNew.Item(TEXT_DRUG_RETURN_COUNT) = dr.Item(DRD_PACK_COUNT)
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
    Private Function GetSurgeryInsReturnTable(useRegId As String) As DataTable
        Dim returnTable As New DataTable, operationManage As New DbOperationManage
        operationManage.QuerySurgeryInsReturnTable(returnTable, useRegId)
        For Each dr As DataRow In returnTable.Rows
            Dim drNew As DataRow = m_dtINS.NewRow
            drNew.Item(TEXT_PACKAGE_ID) = dr.Item(IRD_PACKAGE_ID)
            drNew.Item(TEXT_INS_ID) = dr.Item(IRD_INS_ID)
            drNew.Item(TEXT_INS_NAME) = dr.Item(IRD_INS_NAME)
            drNew.Item(TEXT_INS_TYPE) = dr.Item(IRD_INS_TYPE)
            drNew.Item(TEXT_INS_UNIT) = dr.Item(IRD_INS_UNIT)
            drNew.Item(TEXT_RETURN_IS_EXIST) = TEXT_CHECK
            m_dtINS.Rows.Add(drNew)
        Next
        Return m_dtINS
    End Function
    Private Sub BindDrugTable(ByVal tableDrug As DataTable)
        If tableDrug Is Nothing Then Return
        Dim nArrWidth() As Short = {0, 0, 15, 15, 15, 15, 10, 10, 10, 10}
        Dim nRead() As Boolean = {True, True, True, True, True, True, True, False, False, False}
        Me.dgvDrug.DataSource = tableDrug.Copy()
        dgvDrug.Columns(0).Visible = False
        dgvDrug.Columns(1).Visible = False
        dgvDrug.Columns(7).ReadOnly = False
        dgvDrug.Columns(8).ReadOnly = False
        'dgvDrug.Columns(9).ReadOnly = False
        If _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
            dgvDrug.Columns(6).Visible = False
        End If
    End Sub
    Private Sub BindInstrumentTable(ByVal tableIns As DataTable)
        If tableIns Is Nothing Then Return
        Dim nArrWidth() As Short = {15, 15, 25, 20, 15, 10}
        Me.dgvInstrument.DataSource = tableIns.Copy()
        If _surNoteInfo.NoteStatus = OPerationNoteState.SurgeryReturn Then
            dgvInstrument.Columns(5).Visible = False
        Else
            dgvInstrument.Columns(5).Visible = True
        End If
    End Sub
    Private Function CheckPackageInvalid(ByVal lPackageID As Long) As Boolean
        For Each dr As DataRow In m_dtINS.Rows
            If CInt(dr.Item(TEXT_PACKAGE_ID)) = lPackageID Then
                dr.Item(TEXT_RETURN_IS_EXIST) = TEXT_CHECK
                Return True
            End If
        Next
        ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_RETURN_PACKAGE_NOT_USE, lPackageID))
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
            If Not oDbReturn.InsertReturnInfo(_surNoteInfo, m_dtDrug, m_dtINS, m_lstPackageINSDetailCheck) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Else
                For Each dr As DataRow In m_dtINS.Rows
                    Dim oPackageCheck As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
                    oPackageCheck.m_lPackageID = dr.Item(TEXT_PACKAGE_ID).ToString
                    oPackageCheck.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front
                    oPackageCheck.m_lOPNID = _surNoteInfo.Id
                    oDbReturn.QueryINSDetailByPKID(oPackageCheck)
                    If oPackageCheck.m_lstINSDetail.Count < 1 Then
                        Continue For
                    End If
                    CreatePrint(oPackageCheck)
                Next
                PrintINSList()
                m_nCurrentRow = 0
                LoadTodaySurList()
            End If
        End If
    End Sub
    Private Sub CreatePrint(ByVal oPackageCheck As PackageINSDetailCountCheck)
        If oPackageCheck.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front Then
            For Each oPackageCheckDetail As INSDetailInfo In oPackageCheck.m_lstINSDetail
                Dim drNew As DataRow = m_dtOPerarerINSList.NewRow
                drNew.Item(TEXT_INS_NAME) = oPackageCheckDetail.m_strINSName
                drNew.Item(TEXT_OPERATER_FRONT) = oPackageCheckDetail.m_nCount
                m_dtOPerarerINSList.Rows.Add(drNew)
            Next
        ElseIf oPackageCheck.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE Then
            Dim nRow As Integer = m_nCurrentRow
            For Each oPackageCheckDetail As INSDetailInfo In oPackageCheck.m_lstINSDetail
                m_dtOPerarerINSList.Rows(nRow).Item(TEXT_OPERATER_USING) = oPackageCheckDetail.m_nCount
                nRow += 1
            Next
        ElseIf oPackageCheck.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.AFTER Then
            Dim nRow As Integer = m_nCurrentRow
            For Each oPackageCheckDetail As INSDetailInfo In oPackageCheck.m_lstINSDetail
                m_dtOPerarerINSList.Rows(nRow).Item(TEXT_OPERATER_AFTER) = oPackageCheckDetail.m_nCount
                nRow += 1
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
        If Not CheckPackageInvalid(CLng(strText)) Then
            Exit Sub
        End If
        Dim oPackageINSdetail As PackageINSDetailCountCheck = FindPackageDetailCheck(CLng(strText))
        If oPackageINSdetail Is Nothing Then
            Exit Sub
        Else
            If Not IsHighValue(oPackageINSdetail.m_strINSID) Then
                oPackageINSdetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE
                Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.MIDDLE, False)
                If oFrmINSDetail.ShowDialog() = DialogResult.OK Then
                    'm_lstPackageINSDetailCheck.Add(oPackageINSdetail)
                End If
            End If 
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
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim lPackageID As Long = CLng(dr.Cells(TEXT_PACKAGE_ID).Value)
        If Not CheckPackageInvalid(lPackageID) Then
            Exit Sub
        End If
        Dim oPackageINSdetail As PackageINSDetailCountCheck = FindPackageDetailCheck(lPackageID)
        If oPackageINSdetail Is Nothing Then
            Exit Sub
        Else
            If Not IsHighValue(dr.Cells(TEXT_INS_ID).Value) Then
                oPackageINSdetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE
                Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.MIDDLE, False)
            End If
        End If
        BindInstrumentTable(m_dtINS)
    End Sub
    Private Sub PrintINSList()
        m_dtOPerarerINSList.Clear()
        Dim nIndex As Integer = 0
        For Each dr As DataRow In m_dtINS.Rows
            If Not nIndex = 0 AndAlso Not m_dtOPerarerINSList.Rows.Count = 0 Then
                m_nCurrentRow = m_dtOPerarerINSList.Rows.Count
            End If
            Dim oPackageCheck As PackageINSDetailCountCheck = New PackageINSDetailCountCheck
            oPackageCheck.m_lPackageID = dr.Item(TEXT_PACKAGE_ID).ToString
            oPackageCheck.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front
            oPackageCheck.m_lOPNID = _surNoteInfo.Id
            Dim oDbReturn As DbOperationManage = New DbOperationManage
            oDbReturn.QueryINSDetailByPKID(oPackageCheck)
            CreatePrint(oPackageCheck)
            oPackageCheck.m_lstINSDetail.Clear()
            oPackageCheck.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE
            oDbReturn.QueryINSDetailByPKID(oPackageCheck)
            CreatePrint(oPackageCheck)
            oPackageCheck.m_lstINSDetail.Clear()
            oPackageCheck.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.AFTER
            oDbReturn.QueryINSDetailByPKID(oPackageCheck)
            CreatePrint(oPackageCheck)
            nIndex += 1
        Next
        Dim strHighValueINS As String = String.Empty
        If Not m_oDbOperationManage.QueryHighUseByID(_surNoteInfo.UseReg.Id, strHighValueINS) = DBMEDITS_RESULT.SUCCESS Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        PrintList(strHighValueINS)
    End Sub

    Private Sub PrintList(ByVal strHighName As String)
        Dim daPrintDocument As New UIControlLib.PrintReport
        daPrintDocument.m_bPrintList = True
        daPrintDocument.setXML("_printOPerationINSList.xml")
        Dim parameters As New Hashtable
        m_dtOPerarerINSList.TableName = "printTable"
        Dim strPrintName As String = String.Empty

        Dim prtSetting As System.Drawing.Printing.PrinterSettings = New System.Drawing.Printing.PrinterSettings
        'prtSetting.PrinterName = LocalData.Printer.MedITSPrinter
        daPrintDocument.PrinterSettings = prtSetting

        Dim szTableName As String = m_dtOPerarerINSList.TableName
        daPrintDocument.AddData(m_dtOPerarerINSList)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_NAME, _surNoteInfo.PatName)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_AGE, _surNoteInfo.Age)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_SEX, _surNoteInfo.Gender)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_WEIGHT, _surNoteInfo.Weight)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_DP, _surNoteInfo.DepartmentName)
        parameters.Add(CONST_PRINT_TITLE_HIGH_VALUE, strHighName)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_BED_NO, String.Empty)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_OPERATION_TIME, CDate(_surNoteInfo.OrderDate).ToString("MM月dd日"))
        parameters.Add(CONST_PRINT_TITLE_PATIENT_OPERATION_NAME, _surNoteInfo.SurName)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_PATIENT_ID, _surNoteInfo.PatId)
        parameters.Add(CONST_PRINT_TITLE_PATIENT_VISIT_ID, _surNoteInfo.VisitId)
        parameters.Add(CONST_PRINT_TITLE_RECORD, LocalData.LoginUser.m_strFullName)
        daPrintDocument.SetParameters(parameters)
        daPrintDocument.PrintReport()
    End Sub

    Private Sub btnPrintList_Click(sender As Object, e As EventArgs) Handles btnPrintList.Click
        If m_dtINS.Rows.Count < 1 Then Exit Sub
        PrintINSList()
        m_nCurrentRow = 0
    End Sub
    Private Sub dgvINS_CellContentClick(sender As Object, e As System.EventArgs) Handles dgvInstrument.DoubleClick
        Dim dr As DataGridViewRow = dgvInstrument.CurrentRow
        If dr Is Nothing Then Exit Sub
        Dim oPackageINSdetail As PackageINSDetailCountCheck = FindPackageDetailCheck(CLng(dr.Cells(TEXT_PACKAGE_ID).Value))
        If oPackageINSdetail Is Nothing Then
            Exit Sub
        Else
            If Not IsHighValue(oPackageINSdetail.m_strINSID) Then
                oPackageINSdetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.MIDDLE
                Dim oFrmINSDetail As FrmINSDetail = New FrmINSDetail(oPackageINSdetail, PACKAGE_DETAIL_CHECK.MIDDLE, False)
                oFrmINSDetail.ShowDialog()
        End If
        End If
        BindInstrumentTable(m_dtINS)
    End Sub
End Class
