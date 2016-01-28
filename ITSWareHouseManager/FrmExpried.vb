
Imports ITSBase
Imports DBManager
Imports UIControlLib
Imports System.Windows.Forms

Public Class FrmExpried
    Private m_dtWareHouse As DataTable
    Private m_dtINS As DataTable
    Private m_dtDrug As DataTable
    Private m_oDBExpried As DBExpried
    Private m_dtOutStock As DataTable
    Private m_dtPackage As DataTable
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        TableConstructor.CreateWarerhouseStock(m_dtWareHouse)
        TableConstructor.CreateDrugStockDetail(m_dtDrug)
        If Not m_dtDrug.Columns.Contains(TEXT_BTN_MOVE_OUT) Then
            m_dtDrug.Columns.Add(New DataColumn(TEXT_BTN_MOVE_OUT, GetType(String)))
        End If
        TableConstructor.CreatePackageExpried(m_dtPackage)
        If Not m_dtWareHouse.Columns.Contains(TEXT_BTN_MOVE_OUT) Then
            m_dtWareHouse.Columns.Add(New DataColumn(TEXT_BTN_MOVE_OUT, GetType(String)))
        End If
        If Not m_dtPackage.Columns.Contains(TEXT_BTN_MOVE_OUT) Then
            m_dtPackage.Columns.Add(New DataColumn(TEXT_BTN_MOVE_OUT, GetType(String)))
        End If
        m_oDBExpried = New DBExpried
        m_dtOutStock = New DataTable
        cmbINSTYPE.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS)
        cmbINSTYPE.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG)
        cmbINSTYPE.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_HIGN_VALUE)
        cmbINSTYPE.Items.Add(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE)
        cmbINSTYPE.Text = TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS
        Binging()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Binging()
        Dim nShort() As Short
        If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            dgvMain.DataSource = m_dtWareHouse
            dgvMain.Columns(0).Visible = False
            dgvMain.Columns(5).Visible = False
            dgvMain.Columns(8).Visible = False
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
            nShort = New Short() {0, 20, 10, 20, 10, 10, 10, 20}
            dgvMain.DataSource = m_dtPackage
            dgvMain.Columns(0).Visible = False
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            dgvMain.DataSource = m_dtDrug
            dgvMain.Columns(0).Visible = False
        End If
    End Sub

    Private Sub QueryExpried()
        If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            m_dtOutStock = m_dtWareHouse.Clone
            If Not m_oDBExpried.QueryWareHouseExpried(m_dtWareHouse) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Else
                Binging()
            End If
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
            m_dtOutStock = m_dtPackage.Clone
            If Not m_oDBExpried.QueryPackageExpried(m_dtPackage) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Else
                Binging()
            End If
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            m_dtOutStock = m_dtDrug.Clone
            If Not m_oDBExpried.QueryDrugExpried(m_dtDrug) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Else
                Binging()
            End If
        End If
    End Sub
    Private Sub cmbINSTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINSTYPE.SelectedIndexChanged
        QueryExpried()
    End Sub
    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            m_dtOutStock = m_dtWareHouse.Copy
            m_dtWareHouse.Clear()
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
            m_dtOutStock = m_dtPackage.Copy
            m_dtPackage.Clear()
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            m_dtOutStock = m_dtDrug.Copy
            m_dtDrug.Clear()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btbOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If m_dtOutStock.Rows.Count < 1 Then
            Exit Sub
        End If
        If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If Not m_oDBExpried.ExpriedOutStock(m_dtOutStock) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Else
                Me.Close()
            End If
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
            If Not m_oDBExpried.PackageExpriedOutStock(m_dtOutStock) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Else
                Me.Close()
            End If
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
            If Not m_oDBExpried.ExpriedDrugOutStock(m_dtOutStock) = DBMEDITS_RESULT.SUCCESS Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Else
                Me.Close()
            End If
        End If
    End Sub
    Private Sub OnButtonCellClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMain.CellContentClick
        Dim cellCurrent As DataGridViewCell = dgvMain.CurrentCell
        If cellCurrent.Value.Equals(TEXT_BTN_MOVE_OUT) Then
            Dim nCurrentRowIndex As Integer = dgvMain.CurrentRow.Index
            Dim dr As DataRow
            If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
                dr = m_dtWareHouse.Rows(nCurrentRowIndex)
                If dr Is Nothing Then Exit Sub
                Dim drNew As DataRow = m_dtOutStock.NewRow
                drNew.Item(TEXT_WS_ID) = dr.Item(TEXT_WS_ID)
                drNew.Item(TEXT_WS_INS_ID) = dr.Item(TEXT_WS_INS_ID)
                drNew.Item(TEXT_WS_INS_NAME) = dr.Item(TEXT_WS_INS_NAME)
                drNew.Item(TEXT_WS_INS_TYPE) = dr.Item(TEXT_WS_INS_TYPE)
                drNew.Item(TEXT_WS_INS_UNIT) = dr.Item(TEXT_WS_INS_UNIT)
                drNew.Item(TEXT_WS_PRODUCE_DATE) = dr.Item(TEXT_WS_PRODUCE_DATE)
                drNew.Item(TEXT_WS_EXPIRE_DATE) = dr.Item(TEXT_WS_EXPIRE_DATE)
                drNew.Item(TEXT_WS_BATCH_ID) = dr.Item(TEXT_WS_BATCH_ID)
                drNew.Item(TEXT_WS_COMPANY_ID) = dr.Item(TEXT_WS_COMPANY_ID)
                drNew.Item(TEXT_WS_COMPANY_NAME) = dr.Item(TEXT_WS_COMPANY_NAME)
                drNew.Item(TEXT_STOCK_COUNT) = dr.Item(TEXT_STOCK_COUNT)
                m_dtOutStock.Rows.Add(drNew)
                m_dtWareHouse.Rows.Remove(dr)
                Binging()
            ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_DRUG) Then
                dr = m_dtDrug.Rows(nCurrentRowIndex)
                If dr Is Nothing Then Exit Sub
                Dim drNew As DataRow = m_dtOutStock.NewRow
                drNew.Item(DRS_ID) = dr.Item(DRS_ID)
                drNew.Item(TEXT_DRUG_ID) = dr.Item(TEXT_DRUG_ID)
                drNew.Item(TEXT_DRUG_COMMON_NAME) = dr.Item(TEXT_DRUG_COMMON_NAME)
                drNew.Item(TEXT_DRUG_NAME) = dr.Item(TEXT_DRUG_NAME)
                drNew.Item(TEXT_DRUG_SPECIFICATION) = dr.Item(TEXT_DRUG_SPECIFICATION)
                drNew.Item(TEXT_DRUG_FACTORY) = dr.Item(TEXT_DRUG_FACTORY)
                drNew.Item(TEXT_DRUG_UNIT) = dr.Item(TEXT_DRUG_UNIT)
                drNew.Item(TEXT_DRUG_BATCHNO) = dr.Item(TEXT_DRUG_BATCHNO)
                drNew.Item(TEXT_DRUG_AMOUNT) = dr.Item(TEXT_DRUG_AMOUNT)
                drNew.Item(TEXT_WS_PRODUCE_DATE) = dr.Item(TEXT_WS_PRODUCE_DATE)
                drNew.Item(TEXT_WS_EXPIRE_DATE) = dr.Item(TEXT_WS_EXPIRE_DATE)
                m_dtOutStock.Rows.Add(drNew)
                m_dtDrug.Rows.Remove(dr)
                Binging()
            ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
                dr = m_dtDrug.Rows(nCurrentRowIndex)
                If dr Is Nothing Then Exit Sub
                Dim drNew As DataRow = m_dtDrug.NewRow
                drNew.Item(TEXT_PACKAGE_ID) = dr.Item(TEXT_PACKAGE_ID)
                drNew.Item(TEXT_INS_ID) = dr.Item(TEXT_INS_ID)
                drNew.Item(TEXT_WS_INS_NAME) = dr.Item(TEXT_WS_INS_NAME)
                drNew.Item(TEXT_WS_INS_TYPE) = dr.Item(TEXT_WS_INS_TYPE)
                drNew.Item(TEXT_INS_UNIT) = dr.Item(TEXT_INS_UNIT)
                drNew.Item(TEXT_EXPIRE_DATE) = dr.Item(TEXT_EXPIRE_DATE)
                m_dtOutStock.Rows.Add(drNew)
                m_dtPackage.Rows.Remove(dr)
                Binging()
            End If
        End If
    End Sub
End Class