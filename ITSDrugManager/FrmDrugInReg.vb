Imports System.Windows.Forms
Imports DBManager
Imports ITSBase
Imports UIControlLib

Public Class FrmDrugInReg
    Private _drugDict As DataTable
    Private _inModifyStatus As Boolean = False

    Private Sub FrmDrugInReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialTable()
        InitialDrugInfo()
        Reset()
        SetModifyStatus(_inModifyStatus)
    End Sub

    Private Sub InitialTable()
        Dim dataSource = New DataTable
        dataSource.Columns.Add(TEXT_DRUG_ID, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_COMMON_NAME, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_PRODUCT_NAME, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_SPECIFICATION, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_FACTORY, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_UNIT, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_AMOUNT, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_MFG, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_BATCHNO, GetType(String))
        dataSource.Columns.Add(TEXT_DRUG_EXPIRE, GetType(String))
        Dim nArrWidth() As Short = {100, 125, 200, 125, 150, 100, 100, 200, 150, 200}
        Me.dgv.RealColumnWidthCollection = nArrWidth
        Me.dgv.DataSource = dataSource
    End Sub

    Private Sub InitialDrugInfo()
        _drugDict = New DataTable()
        Dim operationManage As New DbOperationManage
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QueryDrugInfo(_drugDict) AndAlso Not _drugDict.IsNullOrEmpty() Then
            AddHandler ddlCommonName.PressEnter, AddressOf CommonNamePressEnter
            ddlCommonName.ColNoOfCode = 2
            ddlCommonName.IDIndex = 0
            With ddlCommonName
                .DisplayIndex = 1
                .ColumnWidthCollection = New Short() {0, 100, 0, 200, 0, 100, 125, 50}
                .Attach(CType(ddlCommonName, TextBox), _drugDict)
            End With
        End If
    End Sub

    Private Sub CommonNamePressEnter()
        If _drugDict.IsNullOrEmpty() Then Return
        Dim firstSel As ListViewItem = ddlCommonName.GetFirstSelListItem()
        If firstSel Is Nothing Then Return
        Dim selRows As DataRow() = _drugDict.Select(String.Format("{0}='{1}'", DRUG_ID, firstSel.Text))
        If selRows.IsNullOrEmpty() Then Return
        Me.tbCode.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.ddlCommonName.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_COMMON_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbProductName.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_PRODUCT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbSpec.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbFactory.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_MANUFACTURERS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbUnit.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_MEASUER_UNITS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbAmount.Text = String.Empty
    End Sub

    Private Sub Reset()
        Me.tbRegistor.Text = LocalData.LoginUser.m_strFullName
        Me.tbCode.Text = String.Empty
        Me.ddlCommonName.Text = String.Empty
        Me.tbProductName.Text = String.Empty
        Me.tbSpec.Text = String.Empty
        Me.tbFactory.Text = String.Empty
        Me.tbUnit.Text = String.Empty
        Me.tbAmount.Text = String.Empty
        Me.tbBatchNo.Text = String.Empty
        Me.dtpMFG.Value = Now
        Me.dtpExpire.Value = Now
        Me.ddlCommonName.Focus()
    End Sub

    Private Sub tbAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbAmount.KeyPress
        '48代表0，57代表9，8代表空格
        If ((e.KeyChar <= Chr(48) OrElse e.KeyChar >= Chr(57)) AndAlso (e.KeyChar <> Chr(8))) Then e.Handled = True
    End Sub

    Private Function CheckParameter(ByRef errorMsg As String) As Boolean
        errorMsg = String.Empty
        If _drugDict.IsNullOrEmpty() Then
            errorMsg = MSG_ERROR_DRUG_DICT_EMPTY
            Return False
        End If
        '验证药品信息
        Dim selRows As DataRow() = _drugDict.Select(String.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}='{9}'", DRUG_COMMON_NAME, ddlCommonName.Text, _
                                    DRUG_PRODUCT_NAME, tbProductName.Text, DRUG_SPECIFICATION, tbSpec.Text, DRUG_MANUFACTURERS, tbFactory.Text, DRUG_MEASUER_UNITS, tbUnit.Text))
        If selRows.IsNullOrEmpty() Then
            errorMsg = MSG_ERROR_DRUG_DICT_FIND_NULL
            Return False
        End If

        If String.IsNullOrEmpty(Me.tbAmount.Text) Then
            errorMsg = MSG_ERROR_INPUT_AMOUNT
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If _inModifyStatus Then
            SetModifyStatus(False)
        End If
        Reset()
    End Sub

    Private Sub SetModifyStatus(modify As Boolean)
        btnDel.Enabled = Not modify
        btnOk.Enabled = Not modify
        btnClear.Enabled = Not modify
        dgv.Enabled = Not modify
        Me.btnAdd.Visible = Not modify
        Me.btnMdfOk.Visible = Not Me.btnAdd.Visible
        _inModifyStatus = modify
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim errorMsg As String = String.Empty
        If Not CheckParameter(errorMsg) Then
            UIMsgBox.Show(errorMsg)
            Return
        End If

        '添加一条记录
        Dim dataSource = CType(Me.dgv.DataSource, DataTable)
        Dim newRow = dataSource.NewRow()
        newRow.Item(TEXT_DRUG_ID) = Me.tbCode.Text
        newRow.Item(TEXT_DRUG_COMMON_NAME) = Me.ddlCommonName.Text
        newRow.Item(TEXT_DRUG_PRODUCT_NAME) = Me.tbProductName.Text
        newRow.Item(TEXT_DRUG_SPECIFICATION) = Me.tbSpec.Text
        newRow.Item(TEXT_DRUG_FACTORY) = Me.tbFactory.Text
        newRow.Item(TEXT_DRUG_UNIT) = Me.tbUnit.Text
        newRow.Item(TEXT_DRUG_AMOUNT) = Me.tbAmount.Text
        newRow.Item(TEXT_DRUG_MFG) = Me.dtpMFG.Value
        newRow.Item(TEXT_DRUG_BATCHNO) = Me.tbBatchNo.Text
        newRow.Item(TEXT_DRUG_EXPIRE) = Me.dtpExpire.Value
        dataSource.Rows.Add(newRow)

        Reset()
    End Sub

    Private Sub btnMdfOk_Click(sender As Object, e As EventArgs) Handles btnMdfOk.Click
        Dim errorMsg As String = String.Empty
        If Not CheckParameter(errorMsg) Then
            UIMsgBox.Show(errorMsg)
            Return
        End If

        If Me.dgv.SelectedRows.Count <> 1 Then
            Return
        End If

        '修改一条记录
        Dim selRow = Me.dgv.SelectedRows(0)
        selRow.Cells(TEXT_DRUG_ID).Value = Me.tbCode.Text
        selRow.Cells(TEXT_DRUG_COMMON_NAME).Value = Me.ddlCommonName.Text
        selRow.Cells(TEXT_DRUG_PRODUCT_NAME).Value = Me.tbProductName.Text
        selRow.Cells(TEXT_DRUG_SPECIFICATION).Value = Me.tbSpec.Text
        selRow.Cells(TEXT_DRUG_FACTORY).Value = Me.tbFactory.Text
        selRow.Cells(TEXT_DRUG_UNIT).Value = Me.tbUnit.Text
        selRow.Cells(TEXT_DRUG_AMOUNT).Value = Me.tbAmount.Text
        selRow.Cells(TEXT_DRUG_MFG).Value = Me.dtpMFG.Value
        selRow.Cells(TEXT_DRUG_BATCHNO).Value = Me.tbBatchNo.Text
        selRow.Cells(TEXT_DRUG_EXPIRE).Value = Me.dtpExpire.Value

        Reset()
        SetModifyStatus(False)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Reset()
        For i = Me.dgv.Rows.Count - 1 To 0 Step -1
            Me.dgv.Rows.RemoveAt(i)
        Next
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If Me.dgv.SelectedRows.Count <> 1 Then
            UIMsgBox.Show(MSG_ERROR_DGV_SEL_ONE)
            Return
        End If

        Dim selRow = Me.dgv.SelectedRows(0)
        Me.tbCode.Text = selRow.Cells(TEXT_DRUG_ID).Value
        Me.ddlCommonName.Text = selRow.Cells(TEXT_DRUG_COMMON_NAME).Value
        Me.tbProductName.Text = selRow.Cells(TEXT_DRUG_PRODUCT_NAME).Value
        Me.tbSpec.Text = selRow.Cells(TEXT_DRUG_SPECIFICATION).Value
        Me.tbFactory.Text = selRow.Cells(TEXT_DRUG_FACTORY).Value
        Me.tbUnit.Text = selRow.Cells(TEXT_DRUG_UNIT).Value
        Me.tbAmount.Text = selRow.Cells(TEXT_DRUG_AMOUNT).Value
        Me.dtpMFG.Value = selRow.Cells(TEXT_DRUG_MFG).Value
        Me.tbBatchNo.Text = selRow.Cells(TEXT_DRUG_BATCHNO).Value
        Me.dtpExpire.Value = selRow.Cells(TEXT_DRUG_EXPIRE).Value

        SetModifyStatus(True)
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If Me.dgv.SelectedRows.Count > 0 Then
            If UIMsgBox.MSGBoxShowYesNo(MSG_DEL_HARDWARE_QUERY) = DialogResult.Yes Then
                For i = Me.dgv.SelectedRows.Count - 1 To 0 Step -1
                    Me.dgv.Rows.RemoveAt(i)
                Next
            End If
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim dataSource = CType(Me.dgv.DataSource, DataTable)
        dataSource.AcceptChanges()
        Dim drugManage As New DbDrugManage
        If DBMEDITS_RESULT.SUCCESS = drugManage.CommitDrugIn(dataSource, LocalData.LoginUser) Then
            UIMsgBox.Show(MSG_DRUG_IN_SUCCESS)
            Reset()
            For i = Me.dgv.Rows.Count - 1 To 0 Step -1
                Me.dgv.Rows.RemoveAt(i)
            Next
        End If
    End Sub
End Class
