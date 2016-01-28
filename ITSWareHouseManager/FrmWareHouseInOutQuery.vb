Imports ITSBase
Imports UIControlLib
Imports DBManager
Imports ITSProcess
Imports System.Windows.Forms

Public Class FrmWareHouseInOutQuery
    Private m_oDBWareHouseManager As DbWareHouseManager
    Private m_dtWareHouseInOutDetail As DataTable
    Private m_dtInOutTotal As DataTable
    Private m_dtWareHouse As DataTable
    Private m_dtDrugInOutDetail As DataTable
    Private m_dtWareHouseInOutTotal As DataTable
    Private m_lstCurrentSelectSIIType As New List(Of SR_LOG_INOUT_TYPE)
    Private m_strdgvTag As String = String.Empty
    Private Sub FrmOperationNoteQuery_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialControls()
    End Sub
    Private Sub InitialControls()
        m_oDBWareHouseManager = New DbWareHouseManager
        TableConstructor.CreateWareHouseINSInOut(m_dtWareHouseInOutTotal)
        TableConstructor.CreateWareHouseInOutDetail(m_dtWareHouseInOutDetail)
        TableConstructor.CreateDrugInOutDetail(m_dtDrugInOutDetail)
        TableConstructor.CreateWareHouseINSInOutTotal(m_dtInOutTotal)
        InitialINS()
        InitialINSName()
        tvType.ExpandAll()
        m_lstCurrentSelectSIIType.Add(MatchStringToStelizeRoomINSInOutType(tvType.Nodes(0).Text))
        TableConstructor.CreateINSColumns(m_dtWareHouse)
        BindingInOutTotal()
        tvType.SelectedNode = tvType.Nodes(0)
        InitialBtn()
    End Sub
    Private Sub BindingInOutTotal()
        dgv.DataSource = m_dtWareHouseInOutTotal
        m_strdgvTag = dgv.Tag
    End Sub
    Private Sub BindingInOutDetail(ByVal dt As DataTable)
        dgv.DataSource = dt
        m_strdgvTag = dgv.Tag
    End Sub
    Private Sub BindingWareHouseINSInOutTable()

        Dim nArrWidth() As Short = {0, 90, 0, 0, 75, 75, 0}
        dgv.DataSource = m_dtInOutTotal
        dgv.Tag = m_strdgvTag
        dgv.Columns(0).Visible = False
        dgv.Columns(2).Visible = False
        dgv.Columns(3).Visible = False
        dgv.Columns(6).Visible = False
    End Sub

    Private Sub InitialINSName()
        If m_dtWareHouse.Rows.Count > 0 Then
            With cmbINSName
                .CodeIndex = 1
                .IDIndex = 0
                .DisplayIndex = 2
                .ColumnWidthCollection = New Short() {0, 100, 100, 100, 100, 100}
                .Attach(m_dtWareHouse)
            End With
        End If
    End Sub
    Private Sub InitialINS()
        Dim arrINSKind() As INS_KINDS = New INS_KINDS() {INS_KINDS.WAREHOUSE_SU, INS_KINDS.WAREHOUSE_INSTRUMENTS}
        If m_oDBWareHouseManager.QueryInsInfo(m_dtWareHouse, arrINSKind) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
        End If
    End Sub
    Private Function CheckValid() As Boolean
        If String.IsNullOrEmpty(cmbINSName.Text) Then
            Return True
        End If
        If Not cmbINSName.ValidateText Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_OP_INS_RQUEST_ERROR_INS_INFO)
            cmbINSName.Focus()
            cmbINSName.SelectAll()
            Return False
        End If
        Return True
    End Function
    Private Sub InitialBtn()
        btnDetail.Enabled = False
        btnTotal.Enabled = False
        If dgv.DataSource Is m_dtInOutTotal Then
            btnDetail.Enabled = True
        ElseIf dgv.DataSource Is m_dtWareHouseInOutDetail Then
            btnTotal.Enabled = True
        ElseIf dgv.DataSource Is m_dtWareHouseInOutTotal Then
            btnDetail.Enabled = True
        End If
    End Sub
    Private Sub SetGridViewDataByTreeView()
        If Not CheckValid() Then Exit Sub
        Dim strINSID As String = String.Empty
        If Not String.IsNullOrEmpty(cmbINSName.Text) Then
            strINSID = cmbINSName.IDContent
        End If
        If tvType.SelectedNode.Text.Equals(TEXT_INS_KIND_WAREHOUSE) Then
            m_lstCurrentSelectSIIType.Clear()
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.WH_IN)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.WH_OUT_OTHER)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.WH_IN_BALANCE)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.WH_OUT_BALANCE)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.WH_OUT_EXPIRED)
        ElseIf tvType.SelectedNode.Text.Equals(TEXT_INS_KIND_PACKAGE) Then
            m_lstCurrentSelectSIIType.Clear()
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.INS_DISPATCH_IN)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.INS_USE_OUT)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.INS_EXPRIED_OUT)
        ElseIf tvType.SelectedNode.Text.Equals(TEXT_INS_KIND_DRUG) Then
            m_lstCurrentSelectSIIType.Clear()
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.DRUG_IN)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.DRUG_DISPATCH)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.DRUG_BACK_OUT)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.DRUG_IN_BALANCE)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.DRUG_OUT_BALANCE)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.DRUG_OUT_EXPRIED)
            m_lstCurrentSelectSIIType.Add(SR_LOG_INOUT_TYPE.DRUG_OUT_OTHER)
        End If
        dgv.Tag = tvType.SelectedNode.Text.ToString
        If dtpStart.Value.Date > dtpEnd.Value.Date Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_ERROR_STAR_BIGER_END)
            Return
        End If
        If tvType.SelectedNode.Text.Equals(TEXT_INS_KIND_WAREHOUSE) OrElse tvType.SelectedNode.Text.Equals(TEXT_INS_KIND_PACKAGE) OrElse tvType.SelectedNode.Text.Equals(TEXT_INS_KIND_DRUG) Then
            GetSterilizeRoomINSInOut()
            Return
        End If
        dgv.Tag = tvType.SelectedNode.Text.ToString
        If dtpStart.Value.Date > dtpEnd.Value.Date Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DATE_ERROR_STARTDATE_LATER_THAN_ENDDATE)
            Return
        End If
        If tvType.SelectedNode.Parent.Text.Equals(TEXT_INS_KIND_WAREHOUSE) Then
            m_oDBWareHouseManager.QueryWareHouseInOutDetail(m_dtWareHouseInOutDetail, dtpStart.Value, dtpEnd.Value, MatchStringToStelizeRoomINSInOutType(TEXT_INS_KIND_WAREHOUSE + tvType.SelectedNode.Text.ToString), strINSID)
            BindingInOutDetail(m_dtWareHouseInOutDetail)
        ElseIf tvType.SelectedNode.Parent.Text.Equals(TEXT_INS_KIND_DRUG) Then
            m_oDBWareHouseManager.QueryWareHouseInOutDetail(m_dtDrugInOutDetail, dtpStart.Value, dtpEnd.Value, MatchStringToStelizeRoomINSInOutType(TEXT_INS_KIND_DRUG + tvType.SelectedNode.Text.ToString), strINSID)
            BindingInOutDetail(m_dtDrugInOutDetail)
        End If
    End Sub

    Private Sub GetSterilizeRoomINSInOut()
        If dtpStart.Value.Date > dtpEnd.Value.Date Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DATE_ERROR_STARTDATE_LATER_THAN_ENDDATE)
            Return
        End If
        BindingWareHouseINSInOutTable()
        m_oDBWareHouseManager.QueryWareHouseINSInOut(m_dtInOutTotal, dtpStart.Value, dtpEnd.Value, m_lstCurrentSelectSIIType)
        dgv.DataSource = m_dtInOutTotal
        InitialBtn()
    End Sub
    Private Sub ShowTotalCount()
        If dgv.DataSource Is m_dtWareHouseInOutDetail Then
            m_dtWareHouseInOutTotal.Clear()
            For Each dr As DataRow In m_dtWareHouseInOutDetail.Rows
                Dim drNew As DataRow = m_dtWareHouseInOutTotal.NewRow
                drNew.Item(TEXT_INS_ID) = dr.Item(TEXT_INS_ID)
                drNew.Item(TEXT_INS_NAME) = dr.Item(TEXT_INS_NAME)
                drNew.Item(TEXT_INS_TYPE) = dr.Item(TEXT_INS_TYPE)
                drNew.Item(TEXT_UNIT) = dr.Item(TEXT_UNIT)
                drNew.Item(TEXT_CONST_TOTAL_COUNT) = dr.Item(TEXT_COUNT)

                RowMerge.RowMergeCount(m_dtWareHouseInOutTotal, drNew, TEXT_INS_ID, TEXT_CONST_TOTAL_COUNT)
            Next
            BindingInOutTotal()
        End If
        btnDetail.Enabled = True
        btnTotal.Enabled = False
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        SetGridViewDataByTreeView()
    End Sub

    Private Sub tvType_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles tvType.AfterSelect
        If tvType.SelectedNode.Parent Is Nothing Then
            cmbINSName.Enabled = False
            cmbINSName.BackColor = System.Drawing.Color.Ivory
        Else
            cmbINSName.Enabled = True
            cmbINSName.BackColor = System.Drawing.SystemColors.Window
        End If
        SetGridViewDataByTreeView()
    End Sub

    Private Sub btnTotal_Click(sender As Object, e As EventArgs) Handles btnTotal.Click
        ShowTotalCount()
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        If dgv.DataSource Is m_dtInOutTotal Then
            '获取物品名称
            Dim strINSID As String = String.Empty
            If Not String.IsNullOrEmpty(cmbINSName.Text) Then
                strINSID = cmbINSName.IDContent
            End If

            Dim dr As DataGridViewRow = dgv.CurrentRow
            If dr Is Nothing Then Exit Sub
            Dim strSIIID As Long = CLng(dr.Cells(SIM_REG_ID).Value.ToString())
            Dim strSR_LOG_INOUT_TYPE As String = dr.Cells(TEXT_STERILIZEROOM_INS_INOUT_TYPE).Value.ToString()
            dgv.Tag = strSR_LOG_INOUT_TYPE

            If strSR_LOG_INOUT_TYPE.Substring(0, 4).Equals(TEXT_INS_KIND_WAREHOUSE) Then
                m_oDBWareHouseManager.QueryWareHouseInOutDetail(m_dtWareHouseInOutDetail, dtpStart.Value, dtpEnd.Value, MatchStringToStelizeRoomINSInOutType(strSR_LOG_INOUT_TYPE), strINSID, strSIIID)
                BindingInOutDetail(m_dtWareHouseInOutDetail)
            ElseIf strSR_LOG_INOUT_TYPE.Substring(0, 4).Equals(TEXT_INS_KIND_DRUG) Then
                m_oDBWareHouseManager.QueryWareHouseInOutDetail(m_dtDrugInOutDetail, dtpStart.Value, dtpEnd.Value, MatchStringToStelizeRoomINSInOutType(strSR_LOG_INOUT_TYPE), strINSID, strSIIID)
                BindingInOutDetail(m_dtWareHouseInOutDetail)
            End If
        ElseIf dgv.DataSource Is m_dtWareHouseInOutTotal Then
            'BindingInOutDetail()
        End If
        InitialBtn()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim oPrint As ReportPrinter = ReportPrinter.GetInstanse
        Dim strName As String = String.Empty
        If dgv.DataSource Is m_dtInOutTotal Then
            If m_dtInOutTotal.Rows.Count < 1 Then
                Exit Sub
            End If
            If tvType.SelectedNode.Parent Is Nothing Then
                strName = String.Format(TEXT_WAREHOUSE_IN_OUT_QUERY, tvType.SelectedNode.Text.ToString)
            End If
            If Not oPrint.PrintWareHouseInOut(m_dtInOutTotal, strName) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", oPrint.ErrorMessage)
            End If
        ElseIf dgv.DataSource Is m_dtWareHouseInOutDetail Then
            If m_dtWareHouseInOutDetail.Rows.Count < 1 Then
                Exit Sub
            End If
            If Not tvType.SelectedNode.Parent Is Nothing Then
                strName = String.Format(TEXT_WAREHOUSE_IN_OUT_DETAIL, tvType.SelectedNode.Parent.Text.ToString + tvType.SelectedNode.Text.ToString)
            Else
                strName = String.Format(TEXT_WAREHOUSE_IN_OUT_DETAIL, tvType.SelectedNode.Text.ToString)
            End If
            If Not oPrint.PrintWareHouseInOutDetail(m_dtWareHouseInOutDetail, strName) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", oPrint.ErrorMessage)
            End If
        ElseIf dgv.DataSource Is m_dtWareHouseInOutTotal Then
            If m_dtWareHouseInOutTotal.Rows.Count < 1 Then
                Exit Sub
            End If
            If Not tvType.SelectedNode.Parent Is Nothing Then
                strName = String.Format(TEXT_WAREHOUSE_IN_OUT_TOTAL, tvType.SelectedNode.Parent.Text.ToString + tvType.SelectedNode.Text.ToString)
            Else
                strName = String.Format(TEXT_WAREHOUSE_IN_OUT_TOTAL, tvType.SelectedNode.Text.ToString)
            End If
            If Not oPrint.PrintWareHouseInOutTotal(m_dtWareHouseInOutTotal, strName) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", oPrint.ErrorMessage)
            End If
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim oExport As ExportManager = ExportManager.GetInstanse
        Dim strName As String = dgv.Tag
        If dgv.DataSource Is m_dtInOutTotal Then
            If m_dtInOutTotal.Rows.Count < 1 Then
                Exit Sub
            End If
            If Not oExport.ExportWareHouseInOut(m_dtInOutTotal, strName) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", oExport.ErrorMessage)
            End If
        ElseIf dgv.DataSource Is m_dtWareHouseInOutDetail Then
            If m_dtWareHouseInOutDetail.Rows.Count < 1 Then
                Exit Sub
            End If
            If Not oExport.ExportWareHouseInOutDetail(m_dtWareHouseInOutDetail, strName) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", oExport.ErrorMessage)
            End If
        ElseIf dgv.DataSource Is m_dtWareHouseInOutTotal Then
            If m_dtWareHouseInOutTotal.Rows.Count < 1 Then
                Exit Sub
            End If
            If Not oExport.ExportWareHouseInOutDetail(m_dtWareHouseInOutTotal, strName) Then
                ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", oExport.ErrorMessage)
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click_1(sender As Object, e As EventArgs) Handles btnRefresh.Click

    End Sub
End Class

