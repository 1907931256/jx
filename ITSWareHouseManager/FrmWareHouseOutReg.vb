
Imports DBManager
Imports ITSBase
Imports System.Windows.Forms
Imports UIControlLib

Public Class FrmWareHouseOutReg
    Private m_dtWareHouse As DataTable
    Private oEnterProcessManager As EnterProcessManager
    Private m_dtWareHouseINS As DataTable
    Private m_dtDrug As DataTable
    Private m_dtDrugINS As DataTable
    Private m_oDBWareHouseManager As DBWareHouseManager
    Private m_nDrugChange As Integer
    Private Sub FrmOperationNoteQuery_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialControls()
    End Sub
    Public Sub InitialControls()
        oEnterProcessManager = New EnterProcessManager
        oEnterProcessManager.Add(cmbINSName)
        oEnterProcessManager.Add(cmbCompany)
        oEnterProcessManager.Add(cmbINSBatch)
        oEnterProcessManager.Add(txtCount)
        m_oDBWareHouseManager = New DBWareHouseManager
        TableConstructor.CreateWareHouseTable(m_dtWareHouse)
        TableConstructor.CreateINSColumns(m_dtWareHouseINS)

        TableConstructor.CreateDrugStock(m_dtDrug)
        TableConstructor.CreateDrugInfo(m_dtDrugINS)
        InitialINS()
        InitialDrug()
        InitialCompany()
        m_nDrugChange = 1
        cmbINSType.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS)
        cmbINSType.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG)
        cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS
        tbRegistor.Text = LocalData.LoginUser.m_strFullName
     
        Binding()
        tbRegistor.Text = LocalData.LoginUser.m_strFullName
        ClearINS()
        ClearDrug()
    End Sub
    Private Sub InitialDrug()
        If m_oDBWareHouseManager.QueryDrugInfo(m_dtDrugINS) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
        End If
    End Sub
    Private Sub InitialINS()
        Dim arrINSKind() As INS_KINDS = New INS_KINDS() {INS_KINDS.WAREHOUSE_SU, INS_KINDS.WAREHOUSE_INSTRUMENTS}
        If m_oDBWareHouseManager.QueryINSInfo(m_dtWareHouseINS, arrINSKind) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
        End If
    End Sub
    Private Sub InitialCompany()
        cmbCompany.DataSource = Nothing
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(PC_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(PC_CHINESECODE, GetType(String)))
        dt.Columns.Add(New DataColumn(PC_NAME, GetType(String)))

        Dim lRet As Long = m_oDBWareHouseManager.QueryProductCompanyInfo(dt)
        With cmbCompany
            .DisplayIndex = 2
            .IDIndex = 0
            .CodeIndex = 1
            .ColumnWidthCollection = New Short() {0, 100, 150}
            .Attach(dt)
        End With
    End Sub
    Private Sub Binding()
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            dgv.DataSource = m_dtWareHouse
            dgv.Columns(5).Visible = False
            dgv.Columns(9).ReadOnly = False
        ElseIf cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            dgv.DataSource = m_dtDrug
            dgv.Columns(0).Visible = False
        End If
    End Sub
    Private Function CheckValid() As Boolean
        If cmbINSName.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbINSName.ValidateText Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbCompany.ValidateText Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_COMPANY_ERROR_INFO)
            cmbCompany.Focus()
            cmbCompany.SelectAll()
            Return False
        End If
        If cmbINSBatch.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_BATCH_INFO_ERROR_TOO_LONG)
            cmbINSBatch.Focus()
            Return False
        End If
        If Not IsNumeric(txtCount.Text) Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OP_INS_RQUEST_ERROR_INS_COUNT)
            txtCount.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function CheckDrugValid() As Boolean
        If cmbINSName.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OP_INS_RQUEST_ERROR_DRUG_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbINSName.ValidateText Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OP_INS_RQUEST_ERROR_DRUG_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If cmbDrugBatch.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_BATCH_INFO_ERROR_TOO_LONG)
            cmbDrugBatch.Focus()
            Return False
        End If
        If Not IsNumeric(txtDrugCount.Text) Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_OP_INS_RQUEST_ERROR_INS_COUNT)
            txtDrugCount.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function CheckExist(ByVal strINSID As String, ByVal nCompanyID As Integer, ByVal strBatch As String, ByVal strINSName As String, ByVal strCompany As String, Optional ByRef dtProduce As Date = Nothing, Optional ByRef dtExpried As Date = Nothing) As Boolean
        Dim nStock As Integer = 0
        Dim lRet As Long = m_oDBWareHouseManager.CheckWareHouseStock(strINSID, nCompanyID, strBatch, nStock, dtProduce, dtExpried)
        If lRet = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Return False
        ElseIf lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_WAREHOUSE_STOCK_NOT_EXIST, strINSName, strCompany, strBatch))
            Return False
        Else
            If nStock < txtCount.Text.Trim Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_WAREHOUSE_STOCK_NOT_ENOUGH, strINSName, strCompany, strBatch))
                txtCount.Focus()
                txtCount.SelectAll()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub ClearINS()
        cmbINSName.Text = String.Empty
        cmbCompany.Text = String.Empty
        cmbINSBatch.Text = String.Empty
        cmbINSBatch.DataSource = Nothing
        txtCount.Text = String.Empty
        cmbINSName.Focus()
    End Sub
    Private Sub ClearDrug()
        cmbINSName.Text = String.Empty
        cmbCompany.Text = String.Empty
        cmbDrugBatch.Text = String.Empty
        cmbDrugUnit.Text = String.Empty
        cmbDrugUnit.DataSource = Nothing
        cmbDrugBatch.DataSource = Nothing
        txtDrugCount.Text = String.Empty
        cmbINSName.Focus()
    End Sub
    Private Function CheckValidTotal() As Boolean
        If m_dtWareHouse.Rows.Count < 1 Then
            Return False
        End If
        For Each dr As DataRow In m_dtWareHouse.Rows
            If Not Judgement.IsCountedPlusInteger(dr.Item(TEXT_WS_INS_COUNT), 5) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_ERROR_INS_COUNT)
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub InitialINSName()
        cmbINSName.DataSource = Nothing
        If cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS Then
            With cmbINSName
                .CodeIndex = 1
                .IDIndex = 0
                .DisplayIndex = 2
                .ColumnWidthCollection = New Short() {0, 100, 100, 100, 100, 100}
                .Attach(m_dtWareHouseINS)
            End With

            lblCommonName.Text = TEXT_INS_NAME
            cmbCompany.Enabled = True
            pnlWareINS.BringToFront()
            'pnlDrug.SendToBack()
            InitialCompany()
        ElseIf cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_DRUG Then
            With cmbINSName
                .CodeIndex = 2
                .IDIndex = 0
                .DisplayIndex = 1
                .ColumnWidthCollection = New Short() {0, 100, 100, 100, 100, 0, 0, 0}
                .Attach(m_dtDrugINS)
            End With
            lblCommonName.Text = TEXT_DRUG_COMMON_NAME
            cmbCompany.Enabled = False
            'pnlDrug.BringToFront()
            pnlWareINS.SendToBack()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If CheckValid() Then
                Dim dtProduce As Date, dtExpried As Date
                If CheckExist(cmbINSName.IDContent, cmbCompany.IDContent, cmbINSBatch.Text, cmbINSName.Text, cmbCompany.Text, dtProduce, dtExpried) Then
                    For Each dr As DataRow In m_dtWareHouse.Rows
                        If dr.Item(TEXT_WS_INS_ID).Equals(cmbINSName.IDContent) AndAlso dr.Item(TEXT_WS_BATCH_ID).Equals(cmbINSBatch.Text.Trim) _
                            AndAlso dr.Item(TEXT_WS_COMPANY_ID).Equals(cmbCompany.IDContent) Then
                            dr.Item(TEXT_WS_INS_COUNT) = CInt(dr.Item(TEXT_WS_INS_COUNT)) + CInt(txtCount.Text.Trim)
                            ClearINS()
                            Exit Sub
                        End If
                    Next
                    Dim drNew As DataRow = m_dtWareHouse.NewRow
                    Dim drINS As DataRow = cmbINSName.CurrentSelectedRow
                    drNew.Item(TEXT_WS_INS_ID) = Judgement.JudgeDBNullValue(drINS.Item(INS_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                    drNew.Item(TEXT_WS_INS_NAME) = Judgement.JudgeDBNullValue(drINS.Item(INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                    drNew.Item(TEXT_WS_INS_TYPE) = Judgement.JudgeDBNullValue(drINS.Item(INS_SPEC), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                    drNew.Item(TEXT_WS_INS_UNIT) = Judgement.JudgeDBNullValue(drINS.Item(INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                    drNew.Item(TEXT_WS_BATCH_ID) = cmbINSBatch.Text.Trim
                    drNew.Item(TEXT_WS_COMPANY_ID) = cmbCompany.IDContent
                    drNew.Item(TEXT_WS_PRODUCE_DATE) = dtProduce.ToString(TEXT_DATETIME_FORMATION_DATE)
                    drNew.Item(TEXT_WS_EXPIRE_DATE) = dtExpried.ToString(TEXT_DATETIME_FORMATION_DATE)
                    drNew.Item(TEXT_WS_COMPANY_NAME) = cmbCompany.Text
                    drNew.Item(TEXT_WS_INS_COUNT) = txtCount.Text.Trim
                    m_dtWareHouse.Rows.Add(drNew)
                    ClearINS()
                End If
            End If
        Else
            If CheckDrugValid() Then
                Dim nCount As Integer = 0
                Dim oSelect As DataRow = cmbDrugBatch.CurrentSelectedRow
                If oSelect Is Nothing Then Exit Sub
                Dim nTotalCount As Integer = 0
                nTotalCount = oSelect.Item(DRS_DRUG_COUNT)
                If cmbDrugUnit.SelectedValue = TEXT_DRUG_STOCK_UNIT_BIG Then
                    nCount = m_nDrugChange * CInt(txtDrugCount.Text)
                Else
                    nCount = CInt(txtDrugCount.Text)
                End If
                If nCount > nTotalCount Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", String.Format(MSG_DRUG_OUT_REG_COUNT_NOT_ENOUGH, cmbINSName.Text, nTotalCount))
                    txtDrugCount.Focus()
                    Return
                End If
                For Each dr As DataRow In m_dtDrug.Rows
                    If dr.Item(TEXT_DRUG_ID).Equals(cmbINSName.IDContent) AndAlso dr.Item(TEXT_DRUG_BATCHNO).Equals(cmbDrugBatch.Text.Trim) _
                        Then
                        If cmbDrugUnit.SelectedValue = TEXT_DRUG_STOCK_UNIT_BIG Then
                            nCount = m_nDrugChange * CInt(txtDrugCount.Text)
                        Else
                            nCount = CInt(txtDrugCount.Text)
                        End If
                        dr.Item(TEXT_DRUG_AMOUNT) = CInt(dr.Item(TEXT_DRUG_AMOUNT)) + nCount
                        If CInt(dr.Item(TEXT_DRUG_AMOUNT)) > nTotalCount Then
                            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", "")
                            txtDrugCount.Focus()
                            Return
                        End If
                        ClearDrug()
                        Exit Sub
                    End If
                Next
                Dim drNew As DataRow = m_dtDrug.NewRow
                Dim drINS As DataRow = cmbINSName.CurrentSelectedRow
                drNew.Item(TEXT_DRUG_ID) = Judgement.JudgeDBNullValue(drINS.Item(DRUG_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_DRUG_COMMON_NAME) = Judgement.JudgeDBNullValue(drINS.Item(DRUG_COMMON_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_DRUG_NAME) = Judgement.JudgeDBNullValue(drINS.Item(DRUG_PRODUCT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_DRUG_SPECIFICATION) = Judgement.JudgeDBNullValue(drINS.Item(DRUG_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_DRUG_UNIT) = Judgement.JudgeDBNullValue(drINS.Item(DRUG_MEASUER_UNITS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_DRUG_BATCHNO) = cmbDrugBatch.Text.Trim
                drNew.Item(TEXT_DRUG_FACTORY) = cmbCompany.Text
               
                drNew.Item(TEXT_WS_PRODUCE_DATE) = CDate(oSelect.Item(DRS_PRODUCE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
                drNew.Item(TEXT_WS_EXPIRE_DATE) = CDate(oSelect.Item(DRS_AVAILABLE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)

                drNew.Item(TEXT_DRUG_AMOUNT) = nCount
                m_dtDrug.Rows.Add(drNew)
                ClearDrug()
            End If
        End If
       
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        ClearINS()
        ClearDrug()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        ClearINS()
        ClearDrug()
        m_dtWareHouse.Clear()
        m_dtDrug.Clear()
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim nIndex As Integer = dgv.CurrentCell.RowIndex
        If nIndex < 0 Then Exit Sub
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            m_dtWareHouse.Rows.RemoveAt(nIndex)
        Else
            m_dtDrug.Rows.RemoveAt(nIndex)
        End If

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If CheckValidTotal() Then
                For Each dr As DataRow In m_dtWareHouse.Rows
                    'If Not CheckExist(dr.Item(TEXT_WS_INS_ID), CInt(dr.Item(TEXT_WS_COMPANY_ID)), dr.Item(TEXT_WS_BATCH_ID), dr.Item(TEXT_WS_INS_NAME), dr.Item(TEXT_WS_COMPANY_NAME), dtProduce, dtExpried) Then
                    '    Exit Sub
                    'End If
                Next
                Dim lRet As Long = m_oDBWareHouseManager.WareHouseOutReg(m_dtWareHouse)
                If Not lRet = DBMEDITS_RESULT.SUCCESS Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                    Exit Sub
                End If
                m_dtWareHouse.Clear()
                ClearINS()
            End If
        Else
            Dim lRet As Long = m_oDBWareHouseManager.DrugOutReg(m_dtDrug)
            If Not lRet = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                Exit Sub
            End If
            m_dtDrug.Clear()
            Binding()
            ClearDrug()
        End If

    End Sub

    Private Sub cmbINSType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINSType.SelectedIndexChanged
        InitialINSName()
        Binding()
        ClearDrug()
        ClearINS()
    End Sub

    Private Sub cmbINSName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINSName.SelectedIndexChanged, cmbINSName.TextChanged
        Dim oSelectINSInfo As DataRow = cmbINSName.CurrentSelectedRow
        If cmbINSName.Text = String.Empty OrElse oSelectINSInfo Is Nothing Then
            Exit Sub
        End If
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If Not cmbCompany.Text = String.Empty Then
                Dim dt As New DataTable
                If Not m_oDBWareHouseManager.QueryWareHouseStockBatch(dt, cmbINSName.IDContent, cmbCompany.IDContent) = DBMEDITS_RESULT.SUCCESS Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                    Return
                End If

                cmbINSBatch.ColumnWidthCollection = New Short() {80, 120, 120, 120}
                cmbINSBatch.IDIndex = 0
                cmbINSBatch.DisplayIndex = 0
                cmbINSBatch.CodeIndex = 0
                cmbINSBatch.Attach(dt)

            End If
         

        Else
            cmbCompany.Text = oSelectINSInfo.Item(DRUG_MANUFACTURERS)
            cmbCompany.Enabled = False
            m_nDrugChange = Judgement.JudgeDBNullValue(oSelectINSInfo.Item(DRUG_TO_PACK_CONVERSION_RATIO), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            Dim dtUnit As New DataTable
            dtUnit.Columns.Add(New DataColumn(TEXT_DRUG_UNIT_KIND, GetType(String)))
            dtUnit.Columns.Add(New DataColumn(TEXT_DRUG_UNIT_NAME, GetType(String)))
            Dim drNew As DataRow
            If Not Judgement.JudgeDBNullValue(oSelectINSInfo.Item(DRUG_PACK_UNITS), ENUM_DATA_TYPE.DATA_TYPE_STRING) = String.Empty Then
                drNew = dtUnit.NewRow
                drNew.Item(TEXT_DRUG_UNIT_NAME) = oSelectINSInfo.Item(DRUG_PACK_UNITS)
                drNew.Item(TEXT_DRUG_UNIT_KIND) = TEXT_DRUG_STOCK_UNIT_BIG
                dtUnit.Rows.Add(drNew)
            End If
            If Not oSelectINSInfo.Item(DRUG_MEASUER_UNITS) = String.Empty Then
                drNew = dtUnit.NewRow
                drNew.Item(TEXT_DRUG_UNIT_NAME) = oSelectINSInfo.Item(DRUG_MEASUER_UNITS)
                drNew.Item(TEXT_DRUG_UNIT_KIND) = TEXT_DRUG_STOCK_UNIT
                dtUnit.Rows.Add(drNew)
            End If
            If dtUnit.Rows.Count > 0 Then
                cmbDrugUnit.ValueMember = TEXT_DRUG_UNIT_KIND
                cmbDrugUnit.DisplayMember = TEXT_DRUG_UNIT_NAME
                cmbDrugUnit.DataSource = dtUnit
            End If
            Dim dt As New DataTable
            If Not m_oDBWareHouseManager.QueryDrugStockBatch(dt, oSelectINSInfo.Item(DRUG_CODE)) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                Return
            End If
            cmbINSBatch.ColumnWidthCollection = New Short() {80, 120, 120, 120}

            cmbDrugBatch.IDIndex = 0
            cmbDrugBatch.DisplayIndex = 0
            cmbDrugBatch.CodeIndex = 0
            cmbDrugBatch.Attach(dt)

        End If
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            Dim dt As New DataTable
            If Not m_oDBWareHouseManager.QueryWareHouseStockBatch(dt, cmbINSName.IDContent, cmbCompany.IDContent) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                Return
            End If
            cmbINSBatch.DisplayIndex = 0
            cmbINSBatch.CodeIndex = 0
            cmbINSBatch.IDIndex = 0
            cmbINSBatch.ColumnWidthCollection = New Short() {80, 120, 120, 120}
            cmbINSBatch.Attach(dt)
        End If
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearDrug()
        ClearINS()
        m_dtDrug.Clear()
        m_dtWareHouse.Clear()

    End Sub
End Class
