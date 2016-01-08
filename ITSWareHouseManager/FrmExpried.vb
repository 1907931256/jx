
Imports ITSBase
Imports DBManager
Imports UIControlLib
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
        TableConstructor.CreatePackageExpried(m_dtPackage)
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
        Me.dgvMain.ClearBoolColumn()
        Me.dgvMain.HaveBtnColumn = True
        dgvMain.BtnColName = TEXT_BTN_MOVE_OUT
        Dim nShort() As Short
        If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            nShort = New Short() {0, 100, 150, 80, 80, 0, 250, 100, 0, 100, 100}
            dgvMain.RealColumnWidthCollection = nShort
            dgvMain.DataSource = m_dtWareHouse
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
            nShort = New Short() {0, 20, 10, 20, 10, 10, 10, 20}
            dgvMain.ColumnWidthCollection = nShort
            dgvMain.DataSource = m_dtPackage
        End If
    End Sub

    Private Sub QueryExpried()
        If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            m_dtOutStock = m_dtWareHouse.Clone
            If Not m_oDBExpried.QueryWareHouseExpried(m_dtWareHouse) = DBMEDITS_RESULT.SUCCESS Then
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Else
                Binging()
            End If
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
            m_dtOutStock = m_dtPackage.Clone
            If Not m_oDBExpried.QueryPackageExpried(m_dtPackage) = DBMEDITS_RESULT.SUCCESS Then
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
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
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btbOK_Click(sender As Object, e As EventArgs) Handles btbOK.Click
        If m_dtOutStock.Rows.Count < 1 Then
            Exit Sub
        End If
        If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
            If Not m_oDBExpried.ExpriedOutStock(m_dtOutStock) = DBMEDITS_RESULT.SUCCESS Then
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Else
                Me.Close()
            End If
        ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
            If Not m_oDBExpried.PackageExpriedOutStock(m_dtOutStock) = DBMEDITS_RESULT.SUCCESS Then
                UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Else
                Me.Close()
            End If
        End If
    End Sub
    Private Sub OnButtonCellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMain.ButtonCellClick
        If e.RowIndex > -1 Then
            Dim dr As DataRow
            If cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS) Then
                dr = m_dtWareHouse.Rows(e.RowIndex)
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
            ElseIf cmbINSTYPE.Text.Equals(TEXT_WAREHOUSE_IN_REG_TYPE_PACKAGE) Then
                dr = m_dtPackage.Rows(e.RowIndex)
                If dr Is Nothing Then Exit Sub
                Dim drNew As DataRow = m_dtOutStock.NewRow
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