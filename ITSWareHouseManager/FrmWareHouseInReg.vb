Imports DBManager
Imports ITSBase
Imports System.Windows.Forms
Imports UIControlLib
Imports UiControlLibCS


Public Class FrmWareHouseInReg
    Private m_dtWareHouse As DataTable
    Private m_dtHighValue As DataTable
    Private m_dtDrug As DataTable
    Private m_dtDrugINS As DataTable
    Private m_oEnterProcessManager As EnterProcessManager
    Private m_dtWareHouseINS As DataTable
    Private m_dtHighValueINS As DataTable
    Private m_oDBWareHouseManager As DBWareHouseManager
    Private m_nDrugChange As Integer
    Private m_strDrugUnit As String
    Private m_lstHighValueInfo As List(Of HighValueInfo)
    Public Sub InitialControls()

        ' This call is required by the designer.
        'InitializeComponent()
        m_oEnterProcessManager = New EnterProcessManager
        m_oEnterProcessManager.Add(cmbINSName)
        m_oEnterProcessManager.Add(cmbCompany)
        m_oEnterProcessManager.Add(txtBatch)
        m_oEnterProcessManager.Add(dtpProductDate)
        m_oEnterProcessManager.Add(dtpExpire)
        m_oEnterProcessManager.Add(txtCount)
        TableConstructor.CreateWareHouseTable(m_dtWareHouse)
        TableConstructor.CreateHighValueINS(m_dtHighValue)
        TableConstructor.CreateDrugStock(m_dtDrug)

        TableConstructor.CreateDrugInfo(m_dtDrugINS)
        TableConstructor.CreateINSColumns(m_dtHighValueINS)
        TableConstructor.CreateINSColumns(m_dtWareHouseINS)
       
        m_lstHighValueInfo = New List(Of HighValueInfo)
        m_oDBWareHouseManager = New DBWareHouseManager
        InitialINS()
        InitialDrug()
        InitialCompany()
        InitialINSName()
        Clear()
        Binding()
        m_nDrugChange = 1
        cmbINSType.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS)
        cmbINSType.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG)
        cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS
        tbRegistor.Text = LocalData.LoginUser.m_strFullName
        Binding()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmOperationNoteQuery_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialControls()
    End Sub
    Private Sub InitialDrug()
        If m_oDBWareHouseManager.QueryDrugInfo(m_dtDrugINS) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
        End If
    End Sub
    Private Sub InitialCompany()
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
        dgv.AllowUserToResizeColumns = True
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            dgv.DataSource = m_dtWareHouse
            dgv.Columns(5).Visible = False
            dgv.Columns(9).ReadOnly = False
        ElseIf cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            dgv.DataSource = m_dtDrug
            dgv.Columns(0).Visible = False
        End If
    End Sub
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

            lblProductName.Text = TEXT_INS_NAME
            lblSpec.Text = TEXT_INS_TYPE
            pnlWareHouse.BringToFront()
            pnlDrug.SendToBack()
        ElseIf cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_DRUG Then
            With cmbINSName
                .CodeIndex = 2
                .IDIndex = 0
                .DisplayIndex = 1
                .ColumnWidthCollection = New Short() {0, 100, 100, 100, 100, 0, 0, 0}
                .Attach(m_dtDrugINS)
            End With
            lblProductName.Text = TEXT_DRUG_COMMON_NAME
            lblSpec.Text = TEXT_DRUG_NAME
            pnlDrug.BringToFront()
            pnlWareHouse.SendToBack()
        End If
    End Sub
    Private Sub InitialINS()
        Dim arrINSKind() As INS_KINDS = New INS_KINDS() {INS_KINDS.WAREHOUSE_SU, INS_KINDS.WAREHOUSE_INSTRUMENTS}
        If m_oDBWareHouseManager.QueryINSInfo(m_dtWareHouseINS, arrINSKind) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
        End If
    End Sub


    Private Sub cmbINSName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINSName.SelectedIndexChanged, cmbINSName.TextChanged
        Dim oSelectINSInfo As DataRow = cmbINSName.CurrentSelectedRow
        If cmbINSName.Text = String.Empty OrElse oSelectINSInfo Is Nothing Then
            Exit Sub
        End If
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            txtINSType.Text = oSelectINSInfo.Item(INS_SPEC).ToString
            txtINSUnit.Text = oSelectINSInfo.Item(INS_UNIT).ToString
        Else
            txtINSType.Text = oSelectINSInfo.Item(DRUG_COMMON_NAME)
            txtDrugType.Text = oSelectINSInfo.Item(DRUG_SPECIFICATION)
            txtDrugCompany.Text = oSelectINSInfo.Item(DRUG_MANUFACTURERS)
            m_nDrugChange = Judgement.JudgeDBNullValue(oSelectINSInfo.Item(DRUG_TO_PACK_CONVERSION_RATIO), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            m_strDrugUnit = oSelectINSInfo(DRUG_MEASUER_UNITS)

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
        End If
    End Sub
    Private Function CheckValid() As Boolean
        'Dim dr As DataRow = cmbINSName.CurrentSelectedRow
        If cmbINSName.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbINSName.ValidateText Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If

        If Not cmbCompany.ValidateText OrElse cmbCompany.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_COMPANY_ERROR_INFO)
            cmbCompany.Focus()
            cmbCompany.SelectAll()
            Return False
        End If
        If Not Judgement.IsBatchNum(txtBatch.Text) Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_BATCH_INFO_ERROR)
            txtBatch.Focus()
            Return False
        End If

        If dtpExpire.Value.Date < dtpProductDate.Value.Date Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_INPUT_CONtROL_ERROR_INS_EXPRIED_LESS_PRODUCE_DATE)
            dtpExpire.Focus()
            Return False
        End If
        If dtpExpire.Value.Date < LocalData.ServerNow.Date Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_INPUT_CONTROL_ERROR_INS_EXPIRED_LATER)
            dtpExpire.Focus()
            Return False
        End If
        If Not Judgement.IsPlusInteger(txtCount.Text) Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_INS_COUNT)
            txtCount.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function CheckBaseValid() As Boolean
        If cmbINSName.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbINSName.ValidateText Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbCompany.ValidateText OrElse cmbCompany.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_COMPANY_ERROR_INFO)
            cmbCompany.Focus()
            cmbCompany.SelectAll()
            Return False
        End If
        Return True
    End Function
    Private Function CheckDrugValid() As Boolean
        If cmbINSName.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_DRUG_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbINSName.ValidateText Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_DRUG_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If txtDrugBatch.Text = String.Empty Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_DRUG_INFO)
            txtDrugBatch.Focus()
            Return False
        End If
        If Not IsNumeric(txtDrugCount.Text) Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Warning, MSG_ERROR_WARRING, MSG_OP_INS_RQUEST_ERROR_DRUG_INFO)
            txtDrugCount.Focus()
            Return False
        End If
        Return True
    End Function
    Public Sub Clear()
        cmbINSName.Text = String.Empty
        cmbCompany.Text = String.Empty
        txtBatch.Text = String.Empty
        txtDrugBatch.Text = String.Empty
        txtDrugCompany.Text = String.Empty
        dtpExpire.Value = LocalData.ServerNow
        dtpProductDate.Value = LocalData.ServerNow
        dtpDrugAvailable.Value = LocalData.ServerNow
        dtpDrugProduce.Value = LocalData.ServerNow
        txtCount.Text = String.Empty
        txtDrugCount.Text = String.Empty
        txtINSType.Text = String.Empty
        txtINSUnit.Text = String.Empty
        cmbINSName.Focus()
        txtDrugType.Text = String.Empty
        cmbDrugUnit.Text = String.Empty
        cmbDrugUnit.DataSource = Nothing
    End Sub

    Public Sub ClearDrug()
        cmbINSName.Text = String.Empty
        txtINSType.Text = String.Empty
        txtDrugType.Text = String.Empty
        txtDrugBatch.Text = String.Empty
        txtDrugCompany.Text = String.Empty
        txtDrugCount.Text = String.Empty
        cmbDrugUnit.Text = String.Empty
        cmbINSName.Focus()
    End Sub
    Public Sub ClearAll()
        Clear()
        ClearDrug()
        m_dtWareHouse.Clear()
        m_dtDrug.Clear()
        m_dtHighValue.Clear()
    End Sub
    Private Function CheckSamBatchExpried() As Boolean
        Dim lRet As Long, dtExpried As Date
        For Each dr As DataRow In m_dtWareHouse.Rows
            lRet = m_oDBWareHouseManager.CheckSameBatchExpried(dtExpried, dr.Item(TEXT_WS_INS_ID), dr.Item(TEXT_WS_BATCH_ID), CInt(dr.Item(TEXT_WS_COMPANY_ID)))
            If lRet = DBMEDITS_RESULT.ERROR_EXCEPTION Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
                Return False
            ElseIf lRet = DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
                Return False
            ElseIf lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
                Return True
            Else
                If dtExpried.Date <> CDate(dr.Item(TEXT_WS_EXPIRE_DATE)).Date Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, String.Format(MSG_SU_IN_REG_INSERT_ERROR, dr.Item(TEXT_WS_BATCH_ID), CStr(dtExpried.Date.ToString(TEXT_DATETIME_FORMATION_DATE))))
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Private Sub SetFocus()
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            m_oEnterProcessManager = New EnterProcessManager
            m_oEnterProcessManager.Add(cmbINSName)
            m_oEnterProcessManager.Add(cmbCompany)
            m_oEnterProcessManager.Add(txtBatch)
            m_oEnterProcessManager.Add(dtpProductDate)
            m_oEnterProcessManager.Add(dtpExpire)
            m_oEnterProcessManager.Add(txtCount)
        Else
            m_oEnterProcessManager = New EnterProcessManager
            m_oEnterProcessManager.Add(cmbINSName)
            m_oEnterProcessManager.Add(cmbDrugUnit)
            m_oEnterProcessManager.Add(txtDrugCount)
            m_oEnterProcessManager.Add(txtDrugBatch)
            m_oEnterProcessManager.Add(dtpDrugProduce)
            m_oEnterProcessManager.Add(dtpDrugAvailable)
        End If
    End Sub
    Private Sub btnMdfOk_Click(sender As Object, e As EventArgs) Handles btnMdfOk.Click
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If CheckValid() Then
                For Each dr As DataRow In m_dtWareHouse.Rows
                    If dr.Item(TEXT_WS_INS_ID).Equals(cmbINSName.IDContent) AndAlso dr.Item(TEXT_WS_BATCH_ID).Equals(txtBatch.Text.Trim) Then
                        dr.Item(TEXT_WS_INS_COUNT) = CInt(dr.Item(TEXT_WS_INS_COUNT)) + CInt(txtCount.Text)
                        Clear()
                        Exit Sub
                    End If
                Next
                Dim drNew As DataRow = m_dtWareHouse.NewRow
                drNew.Item(TEXT_WS_INS_ID) = cmbINSName.IDContent
                drNew.Item(TEXT_WS_INS_NAME) = cmbINSName.DisplayContent
                drNew.Item(TEXT_WS_INS_TYPE) = txtINSType.Text
                drNew.Item(TEXT_WS_INS_UNIT) = txtINSUnit.Text
                drNew.Item(TEXT_WS_COMPANY_ID) = cmbCompany.IDContent
                drNew.Item(TEXT_WS_COMPANY_NAME) = cmbCompany.DisplayContent
                If m_dtWareHouse.Columns.Contains(TEXT_WS_INS_COUNT) Then
                    drNew.Item(TEXT_WS_INS_COUNT) = txtCount.Text.Trim
                End If
                If m_dtWareHouse.Columns.Contains(TEXT_WS_PRODUCE_DATE) Then
                    drNew.Item(TEXT_WS_PRODUCE_DATE) = dtpProductDate.Value.Date.ToString(TEXT_DATETIME_FORMATION_DATE)
                End If
                If m_dtWareHouse.Columns.Contains(TEXT_WS_EXPIRE_DATE) Then
                    drNew.Item(TEXT_WS_EXPIRE_DATE) = dtpExpire.Value.Date.ToString(TEXT_DATETIME_FORMATION_DATE)
                End If
                If m_dtWareHouse.Columns.Contains(TEXT_WS_BATCH_ID) Then
                    drNew.Item(TEXT_WS_BATCH_ID) = txtBatch.Text
                End If
                m_dtWareHouse.Rows.Add(drNew)
                Clear()
            End If
        ElseIf cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            If CheckDrugValid() Then

                Dim nCount As Integer = 0
                For Each dr As DataRow In m_dtDrug.Rows
                    If CStr(dr.Item(TEXT_DRUG_ID)).Equals(cmbINSName.IDContent) AndAlso CStr(dr.Item(TEXT_PRODUCT_SN)).Equals(txtDrugBatch.Text) Then
                        If cmbDrugUnit.SelectedValue = TEXT_DRUG_STOCK_UNIT_BIG Then
                            nCount = m_nDrugChange * CInt(txtDrugCount.Text)
                        Else
                            nCount = CInt(txtDrugCount.Text)
                        End If
                        dr.Item(TEXT_DRUG_AMOUNT) = CInt(dr.Item(TEXT_DRUG_AMOUNT)) + nCount
                        ClearDrug()
                        Binding()
                        Exit Sub
                    End If
                Next
                Dim drNew As DataRow = m_dtDrug.NewRow
                drNew.Item(TEXT_DRUG_ID) = cmbINSName.IDContent
                drNew.Item(TEXT_DRUG_COMMON_NAME) = cmbINSName.DisplayContent
                drNew.Item(TEXT_DRUG_NAME) = txtINSType.Text
                drNew.Item(TEXT_DRUG_SPECIFICATION) = txtDrugType.Text
                drNew.Item(TEXT_DRUG_UNIT) = m_strDrugUnit
                drNew.Item(TEXT_DRUG_BATCHNO) = txtDrugBatch.Text
                drNew.Item(TEXT_DRUG_FACTORY) = txtDrugCompany.Text
                drNew.Item(TEXT_WS_PRODUCE_DATE) = CDate(dtpDrugProduce.Value).ToString(TEXT_DATETIME_FORMATION_DATE)
                drNew.Item(TEXT_WS_EXPIRE_DATE) = CDate(dtpDrugAvailable.Value).ToString(TEXT_DATETIME_FORMATION_DATE)
                If cmbDrugUnit.SelectedValue = TEXT_DRUG_STOCK_UNIT_BIG Then
                    nCount = m_nDrugChange * CInt(txtDrugCount.Text)
                Else
                    nCount = CInt(txtDrugCount.Text)
                End If
                drNew.Item(TEXT_DRUG_AMOUNT) = nCount
                m_dtDrug.Rows.Add(drNew)
                ClearDrug()
                Binding()
            End If
        End If

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If m_dtWareHouse.Rows.Count > 0 AndAlso CheckSamBatchExpried() Then
                If Not m_oDBWareHouseManager.WareHouseInReg(m_dtWareHouse) = DBMEDITS_RESULT.SUCCESS Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
                    Exit Sub
                End If
                m_dtWareHouse.Clear()
                Clear()
            End If
        ElseIf cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            If m_dtDrug.Rows.Count > 0 Then
                If Not m_oDBWareHouseManager.DrugInReg(m_dtDrug) = DBMEDITS_RESULT.SUCCESS Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
                    Exit Sub
                End If
                m_dtDrug.Clear()
                ClearDrug()
            End If
        End If

    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim nIndex As Integer = dgv.CurrentCell.RowIndex
        If nIndex < 0 Then Exit Sub
        m_dtWareHouse.Rows.RemoveAt(nIndex)
        Binding()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAll()
    End Sub

    Private Sub cmbINSType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINSType.SelectedIndexChanged
        InitialINSName()
        Binding()
        SetFocus()
        Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If CheckValid() Then
                For Each dr As DataRow In m_dtWareHouse.Rows
                    If dr.Item(TEXT_WS_INS_ID).Equals(cmbINSName.IDContent) AndAlso dr.Item(TEXT_WS_BATCH_ID).Equals(txtBatch.Text.Trim) Then
                        dr.Item(TEXT_WS_INS_COUNT) = CInt(dr.Item(TEXT_WS_INS_COUNT)) + CInt(txtCount.Text)
                        Clear()
                        Exit Sub
                    End If
                Next
                Dim drNew As DataRow = m_dtWareHouse.NewRow
                drNew.Item(TEXT_WS_INS_ID) = cmbINSName.IDContent
                drNew.Item(TEXT_WS_INS_NAME) = cmbINSName.DisplayContent
                drNew.Item(TEXT_WS_INS_TYPE) = txtINSType.Text
                drNew.Item(TEXT_WS_INS_UNIT) = txtINSUnit.Text
                drNew.Item(TEXT_WS_COMPANY_ID) = cmbCompany.IDContent
                drNew.Item(TEXT_WS_COMPANY_NAME) = cmbCompany.DisplayContent
                If m_dtWareHouse.Columns.Contains(TEXT_WS_INS_COUNT) Then
                    drNew.Item(TEXT_WS_INS_COUNT) = txtCount.Text.Trim
                End If
                If m_dtWareHouse.Columns.Contains(TEXT_WS_PRODUCE_DATE) Then
                    drNew.Item(TEXT_WS_PRODUCE_DATE) = dtpProductDate.Value.Date.ToString(TEXT_DATETIME_FORMATION_DATE)
                End If
                If m_dtWareHouse.Columns.Contains(TEXT_WS_EXPIRE_DATE) Then
                    drNew.Item(TEXT_WS_EXPIRE_DATE) = dtpExpire.Value.Date.ToString(TEXT_DATETIME_FORMATION_DATE)
                End If
                If m_dtWareHouse.Columns.Contains(TEXT_WS_BATCH_ID) Then
                    drNew.Item(TEXT_WS_BATCH_ID) = txtBatch.Text
                End If
                m_dtWareHouse.Rows.Add(drNew)
                Clear()
            End If
        ElseIf cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            If CheckDrugValid() Then

                Dim nCount As Integer = 0
                For Each dr As DataRow In m_dtDrug.Rows
                    If CStr(dr.Item(TEXT_DRUG_ID)).Equals(cmbINSName.IDContent) AndAlso CStr(dr.Item(TEXT_PRODUCT_SN)).Equals(txtDrugBatch.Text) Then
                        If cmbDrugUnit.SelectedValue = TEXT_DRUG_STOCK_UNIT_BIG Then
                            nCount = m_nDrugChange * CInt(txtDrugCount.Text)
                        Else
                            nCount = CInt(txtDrugCount.Text)
                        End If
                        dr.Item(TEXT_DRUG_AMOUNT) = CInt(dr.Item(TEXT_DRUG_AMOUNT)) + nCount
                        Clear()
                        Binding()
                        Exit Sub
                    End If
                Next
                Dim drNew As DataRow = m_dtDrug.NewRow
                drNew.Item(TEXT_DRUG_ID) = cmbINSName.IDContent
                drNew.Item(TEXT_DRUG_COMMON_NAME) = cmbINSName.DisplayContent
                drNew.Item(TEXT_DRUG_NAME) = txtINSType.Text
                drNew.Item(TEXT_DRUG_SPECIFICATION) = txtDrugType.Text
                drNew.Item(TEXT_DRUG_UNIT) = m_strDrugUnit
                drNew.Item(TEXT_DRUG_BATCHNO) = txtDrugBatch.Text
                drNew.Item(TEXT_DRUG_FACTORY) = txtDrugCompany.Text
                drNew.Item(TEXT_WS_PRODUCE_DATE) = dtpDrugProduce.Value
                drNew.Item(TEXT_WS_EXPIRE_DATE) = dtpDrugAvailable.Value
                If cmbDrugUnit.SelectedValue = TEXT_DRUG_STOCK_UNIT_BIG Then
                    nCount = m_nDrugChange * CInt(txtDrugCount.Text)
                Else
                    nCount = CInt(txtDrugCount.Text)
                End If
                drNew.Item(TEXT_DRUG_AMOUNT) = nCount
                m_dtDrug.Rows.Add(drNew)
                Clear()
                Binding()
            End If

        End If
    End Sub
End Class
