
Imports DBManager
Imports ITSBase
Imports System.Windows.Forms
Imports UIControlLib

Public Class FrmWareHouseOutReg
    Private m_dtWareHouse As DataTable
    Private oEnterProcessManager As EnterProcessManager
    Private m_dtWareHouseINS As DataTable
    Private m_oDBWareHouseManager As DBWareHouseManager
    Private Sub FrmOperationNoteQuery_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialControls()
    End Sub
    Public Sub InitialControls()
        oEnterProcessManager = New EnterProcessManager
        oEnterProcessManager.Add(cmbINSName)
        oEnterProcessManager.Add(txtBatch)
        oEnterProcessManager.Add(cmbCompany)
        oEnterProcessManager.Add(txtCount)
        m_oDBWareHouseManager = New DBWareHouseManager
        TableConstructor.CreateWareHouseTable(m_dtWareHouse)
        TableConstructor.CreateINSColumns(m_dtWareHouseINS)
        InitialINS()
        InitialCompany()
        Binding()
        tbRegistor.Text = LocalData.LoginUser.m_strFullName
        Clear()
    End Sub
    Private Sub InitialINS()
        Dim arrINSKind() As INS_KINDS = New INS_KINDS() {INS_KINDS.WAREHOUSE_SU, INS_KINDS.WAREHOUSE_INSTRUMENTS}
        If m_oDBWareHouseManager.QueryINSInfo(m_dtWareHouseINS, arrINSKind) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        Else
            If m_dtWareHouseINS.Rows.Count > 0 Then
                With cmbINSName
                    .CodeIndex = 1
                    .IDIndex = 0
                    .DisplayIndex = 2
                    .ColumnWidthCollection = New Short() {0, 100, 100, 100, 100, 100}
                    .Attach(m_dtWareHouseINS)
                End With
            End If
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
        dgv.ClearBoolColumn()
        dgv.AllowSort = True
        Dim arrWith() As Short
        Dim arrReadOnly() As Boolean = {True, True, True, True, True, True, True, True, True, False}
        dgv.ColumnReadOnlyCollection = arrReadOnly
        arrWith = {120, 180, 100, 100, 180, 0, 180, 180, 180, 100}
        dgv.RealColumnWidthCollection = arrWith
        dgv.ColumnReadOnlyCollection = arrReadOnly
        dgv.DataSource = m_dtWareHouse
    End Sub
    Private Function CheckValid() As Boolean
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
        If Not cmbCompany.ValidateText Then
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
        If Not IsNumeric(txtCount.Text) Then
            UIMsgBox.MSGBoxShow(MSG_OP_INS_RQUEST_ERROR_INS_COUNT)
            txtCount.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function CheckExist(ByVal strINSID As String, ByVal nCompanyID As Integer, ByVal strBatch As String, ByVal strINSName As String, ByVal strCompany As String, Optional ByRef dtProduce As Date = Nothing, Optional ByRef dtExpried As Date = Nothing) As Boolean
        Dim nStock As Integer = 0
        Dim lRet As Long = m_oDBWareHouseManager.CheckWareHouseStock(strINSID, nCompanyID, strBatch, nStock, dtProduce, dtExpried)
        If lRet = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Return False
        ElseIf lRet = DBMEDITS_RESULT.ERROR_NOT_EXIST Then
            UIMsgBox.MSGBoxShow(String.Format(MSG_WAREHOUSE_STOCK_NOT_EXIST, strINSName, strCompany, strBatch))
            Return False
        Else
            If nStock < txtCount.Text.Trim Then
                UIMsgBox.MSGBoxShow(String.Format(MSG_WAREHOUSE_STOCK_NOT_ENOUGH, strINSName, strCompany, strBatch))
                txtCount.Focus()
                txtCount.SelectAll()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub Clear()
        cmbINSName.Text = String.Empty
        cmbCompany.Text = String.Empty
        txtBatch.Text = String.Empty
        txtCount.Text = String.Empty
        cmbINSName.Focus()
    End Sub
    Private Function CheckValidTotal() As Boolean
        If m_dtWareHouse.Rows.Count < 1 Then
            Return False
        End If
        For Each dr As DataRow In m_dtWareHouse.Rows
            If Not Judgement.IsCountedPlusInteger(dr.Item(TEXT_WS_INS_COUNT), 5) Then
                UIMsgBox.MSGBoxShow(MSG_ERROR_INS_COUNT)
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        If CheckValid() Then
            Dim dtProduce As Date, dtExpried As Date
            If CheckExist(cmbINSName.IDContent, cmbCompany.IDContent, txtBatch.Text, cmbINSName.Text, cmbCompany.Text, dtProduce, dtExpried) Then
                For Each dr As DataRow In m_dtWareHouse.Rows
                    If dr.Item(TEXT_WS_INS_ID).Equals(cmbINSName.IDContent) AndAlso dr.Item(TEXT_WS_BATCH_ID).Equals(txtBatch.Text.Trim) _
                        AndAlso dr.Item(TEXT_WS_COMPANY_ID).Equals(cmbCompany.IDContent) Then
                        dr.Item(TEXT_WS_INS_COUNT) = CInt(dr.Item(TEXT_WS_INS_COUNT)) + CInt(txtCount.Text.Trim)
                        Clear()
                        Exit Sub
                    End If
                Next
                Dim drNew As DataRow = m_dtWareHouse.NewRow
                Dim drINS As DataRow = cmbINSName.CurrentSelectedRow
                drNew.Item(TEXT_WS_INS_ID) = Judgement.JudgeDBNullValue(drINS.Item(INS_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_WS_INS_NAME) = Judgement.JudgeDBNullValue(drINS.Item(INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_WS_INS_TYPE) = Judgement.JudgeDBNullValue(drINS.Item(INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_WS_INS_UNIT) = Judgement.JudgeDBNullValue(drINS.Item(INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                drNew.Item(TEXT_WS_BATCH_ID) = txtBatch.Text.Trim
                drNew.Item(TEXT_WS_COMPANY_ID) = cmbCompany.IDContent
                drNew.Item(TEXT_WS_PRODUCE_DATE) = dtProduce.ToString(TEXT_DATETIME_FORMATION_DATE)
                drNew.Item(TEXT_WS_EXPIRE_DATE) = dtExpried.ToString(TEXT_DATETIME_FORMATION_DATE)
                drNew.Item(TEXT_WS_COMPANY_NAME) = cmbCompany.Text
                drNew.Item(TEXT_WS_INS_COUNT) = txtCount.Text.Trim
                m_dtWareHouse.Rows.Add(drNew)
                Clear()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Clear()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        Clear()
        m_dtWareHouse.Clear()
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs)
        Dim dr As DataRow = dgv.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        m_dtWareHouse.Rows.Remove(dr)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)
        If CheckValidTotal() Then
            For Each dr As DataRow In m_dtWareHouse.Rows
                'If Not CheckExist(dr.Item(TEXT_WS_INS_ID), CInt(dr.Item(TEXT_WS_COMPANY_ID)), dr.Item(TEXT_WS_BATCH_ID), dr.Item(TEXT_WS_INS_NAME), dr.Item(TEXT_WS_COMPANY_NAME), dtProduce, dtExpried) Then
                '    Exit Sub
                'End If
            Next
            Dim lRet As Long = m_oDBWareHouseManager.WareHouseOutReg(m_dtWareHouse)
            If Not lRet = DBMEDITS_RESULT.SUCCESS Then
                UIMsgBox.MSGBoxShow(UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION))
                Exit Sub
            End If
            m_dtWareHouse.Clear()
            Clear()
        End If
    End Sub
End Class
