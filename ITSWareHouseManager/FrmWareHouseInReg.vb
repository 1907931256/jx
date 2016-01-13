Imports DBManager
Imports ITSBase
Imports System.Windows.Forms
Imports UIControlLib

Public Class FrmWareHouseInReg
    Private m_dtWareHouse As DataTable
    Private oEnterProcessManager As EnterProcessManager
    Private m_dtWareHouseINS As DataTable
    Private m_dtHighValueINS As DataTable
    Private m_oDBWareHouseManager As DBWareHouseManager
    Public Sub InitialControls()

        ' This call is required by the designer.
        'InitializeComponent()
        oEnterProcessManager = New EnterProcessManager
        oEnterProcessManager.Add(cmbINSName)
        oEnterProcessManager.Add(cmbCompany)
        oEnterProcessManager.Add(txtBatch)
        oEnterProcessManager.Add(dtpProductDate)
        oEnterProcessManager.Add(dtpExpire)
        oEnterProcessManager.Add(txtCount)
        TableConstructor.CreateWareHouseTable(m_dtWareHouse)
        TableConstructor.CreateINSColumns(m_dtHighValueINS)
        TableConstructor.CreateINSColumns(m_dtWareHouseINS)
        cmbINSType.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS)
        cmbINSType.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_HIGN_VALUE)
        cmbINSType.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG)
        cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS

        m_oDBWareHouseManager = New DBWareHouseManager
        InitialINS()
        InitialCompany()
        InitialINSName()
        Clear()
        Binding()
        tbRegistor.Text = LocalData.LoginUser.m_strFullName
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmOperationNoteQuery_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialControls()
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
        dgv.ClearBoolColumn()
        dgv.AllowUserToResizeColumns = True
        dgv.AllowSort = True
        Dim arrWith() As Short = {80, 100, 80, 80, 100, 0, 100, 100, 100, 100}
        dgv.RealColumnWidthCollection = arrWith
        Dim arrReadOnly() As Boolean = {True, True, True, True, True, True, True, True, True, False}
        dgv.ColumnReadOnlyCollection = arrReadOnly
        If cmbINSType.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            arrWith = {120, 180, 100, 100, 180, 0, 180, 180, 180, 100}
            dgv.RealColumnWidthCollection = arrWith
            arrReadOnly = {True, True, True, True, True, True, True, True, True, False}
            dgv.ColumnReadOnlyCollection = arrReadOnly
            dgv.DataSource = m_dtWareHouse
        Else
            arrWith = {80, 100, 80, 80, 100, 0, 100, 100, 100, 100, 100, 100}
            dgv.RealColumnWidthCollection = arrWith
            arrReadOnly = {True, True, True, True, True, True, True, True, True, True, True, False}
            dgv.ColumnReadOnlyCollection = arrReadOnly
        End If

    End Sub
    Private Sub InitialINSName()
        If cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS Then
            If m_dtWareHouseINS.Rows.Count > 0 Then
                With cmbINSName
                    .CodeIndex = 1
                    .IDIndex = 0
                    .DisplayIndex = 2
                    .ColumnWidthCollection = New Short() {0, 100, 100, 100, 100, 100}
                    .Attach(m_dtWareHouseINS)
                End With
            End If
        ElseIf cmbINSType.Text = TEXT_WAREHOUSE_IN_REG_TYPE_HIGN_VALUE Then
            If m_dtHighValueINS.Rows.Count > 0 Then
                With cmbINSName
                    .CodeIndex = 1
                    .IDIndex = 0
                    .DisplayIndex = 2
                    .ColumnWidthCollection = New Short() {0, 100, 100, 100, 100, 100}
                    .Attach(m_dtHighValueINS)
                End With
            End If
        Else
        End If
    End Sub
    Private Sub InitialINS()
        Dim arrINSKind() As INS_KINDS = New INS_KINDS() {INS_KINDS.WAREHOUSE_SU, INS_KINDS.WAREHOUSE_INSTRUMENTS}
        If m_oDBWareHouseManager.QueryINSInfo(m_dtWareHouseINS, arrINSKind) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        End If
        arrINSKind = {INS_KINDS.HIGH_VALUE_SU}
        If m_oDBWareHouseManager.QueryINSInfo(m_dtHighValueINS, arrINSKind) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        End If
    End Sub

    Private Sub cmbINSName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINSName.SelectedIndexChanged, cmbINSName.TextChanged
        Dim oSelectINSInfo As DataRow = cmbINSName.CurrentSelectedRow
        If cmbINSName.Text = String.Empty OrElse oSelectINSInfo Is Nothing Then
            Exit Sub
        End If
        txtINSType.Text = oSelectINSInfo.Item(INS_TYPE).ToString
        txtINSUnit.Text = oSelectINSInfo.Item(INS_UNIT).ToString
    End Sub
    Private Function CheckValid() As Boolean
        'Dim dr As DataRow = cmbINSName.CurrentSelectedRow
        If cmbINSName.Text = String.Empty Then
            UIMsgBox.MSGBoxShow(MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        If Not cmbINSName.ValidateText Then
            UIMsgBox.MSGBoxShow(MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If

        If Not cmbCompany.ValidateText OrElse cmbCompany.Text = String.Empty Then
            UIMsgBox.MSGBoxShow(MSG_COMPANY_ERROR_INFO)
            cmbCompany.Focus()
            cmbCompany.SelectAll()
            Return False
        End If
        If Not Judgement.IsBatchNum(txtBatch.Text) Then
            UIMsgBox.MSGBoxShow(MSG_BATCH_INFO_ERROR)
            txtBatch.Focus()
            Return False
        End If

        If dtpExpire.Value.Date < dtpProductDate.Value.Date Then
            UIMsgBox.MSGBoxShow(MSG_INPUT_CONtROL_ERROR_INS_EXPRIED_LESS_PRODUCE_DATE)
            dtpExpire.Focus()
            Return False
        End If
        If dtpExpire.Value.Date < LocalData.ServerNow.Date Then
            UIMsgBox.MSGBoxShow(MSG_INPUT_CONTROL_ERROR_INS_EXPIRED_LATER)
            dtpExpire.Focus()
            Return False
        End If
        If Not Judgement.IsPlusInteger(txtCount.Text) Then
            UIMsgBox.MSGBoxShow(MSG_OP_INS_RQUEST_ERROR_INS_COUNT)
            txtCount.Focus()
            Return False
        End If
        Return True
    End Function
    Public Sub Clear()
        cmbINSName.Text = String.Empty
        cmbCompany.Text = String.Empty
        txtBatch.Text = String.Empty
        dtpExpire.Value = LocalData.ServerNow
        dtpProductDate.Value = LocalData.ServerNow
        txtCount.Text = String.Empty
        txtINSType.Text = String.Empty
        txtINSUnit.Text = String.Empty
        cmbINSName.Focus()
    End Sub
    Public Sub ClearAll()
        Clear()
        m_dtWareHouse.Clear()
    End Sub
    Private Function CheckSamBatchExpried() As Boolean
        Dim lRet As Long, dtExpried As Date
        For Each dr As DataRow In m_dtWareHouse.Rows
            lRet = m_oDBWareHouseManager.CheckSameBatchExpried(dtExpried, dr.Item(TEXT_WS_INS_ID), dr.Item(TEXT_WS_BATCH_ID), CInt(dr.Item(TEXT_WS_COMPANY_ID)))
            If lRet = DBMEDITS_RESULT.ERROR_EXCEPTION Then
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
                Return False
            ElseIf lRet = DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW Then
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
                Return False
            ElseIf lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
                Return True
            Else
                If dtExpried.Date <> CDate(dr.Item(TEXT_WS_EXPIRE_DATE)).Date Then
                    UIMsgBox.MSGBoxShow(String.Format(MSG_SU_IN_REG_INSERT_ERROR, dr.Item(TEXT_WS_BATCH_ID), CStr(dtExpried.Date.ToString(TEXT_DATETIME_FORMATION_DATE))))
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnMdfOk_Click(sender As Object, e As EventArgs)
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
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)
        If m_dtWareHouse.Rows.Count > 0 AndAlso CheckSamBatchExpried() Then
            If Not m_oDBWareHouseManager.WareHouseInReg(m_dtWareHouse) = DBMEDITS_RESULT.SUCCESS Then
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
                Exit Sub
            End If
            m_dtWareHouse.Clear()
            Clear()
        End If
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs)
        Dim dr As DataRow = dgv.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        Dim strINSID As String = dr.Item(TEXT_WS_INS_ID).ToString
        If Not strINSID = String.Empty Then
            m_dtWareHouse.Rows.Remove(dr)
        End If
        Binding()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Clear()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        ClearAll()
    End Sub

    Private Sub cmbINSType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINSType.SelectedIndexChanged
        InitialINSName()
    End Sub
End Class
