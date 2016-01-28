Imports ITSBase
Imports DBManager
Imports UIControlLib

Public Class FrmINSDetail
    Private m_eCheck As PACKAGE_DETAIL_CHECK
    Private m_oPackageINSDetailCheck As PackageINSDetailCountCheck
    Private m_dtDetail As DataTable
    Public Sub New(ByRef oPackageINSDetail As PackageINSDetailCountCheck, ByVal eType As PACKAGE_DETAIL_CHECK, ByVal bAdd As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_eCheck = eType
        m_oPackageINSDetailCheck = oPackageINSDetail
        lblINSID.Text = oPackageINSDetail.m_strINSID
        lblINSName.Text = oPackageINSDetail.m_strINSName
        lblINSType.Text = oPackageINSDetail.m_strINSType
        lblINSUnit.Text = oPackageINSDetail.m_strINSUnit

        Dim oDB As DbOperationManage = New DbOperationManage
        m_dtDetail = New DataTable
        m_dtDetail.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
        m_dtDetail.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
        m_dtDetail.Columns.Add(New DataColumn(TEXT_COUNT, GetType(String)))
        Binding()
        m_dtDetail.Clear()
        If oPackageINSDetail.m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.Front Then
            If bAdd Then
                Dim dtTemp As DataTable = New DataTable
                If oDB.QueryINSDetailInfoByID(dtTemp, oPackageINSDetail.m_strINSID) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
                    Exit Sub
                End If
                For Each dr As DataRow In dtTemp.Rows
                    Dim drNew As DataRow = m_dtDetail.NewRow
                    drNew.Item(TEXT_INS_NAME) = dr.Item(IDI_NAME)
                    drNew.Item(TEXT_INS_TYPE) = dr.Item(IDI_TYPE)
                    drNew.Item(TEXT_COUNT) = dr.Item(IDI_COUNT)
                    m_dtDetail.Rows.Add(drNew)
                Next
            Else
                For Each oINSDetail As INSDetailInfo In oPackageINSDetail.m_lstINSDetail
                    Dim drNew As DataRow = m_dtDetail.NewRow
                    drNew.Item(TEXT_INS_NAME) = oINSDetail.m_strINSName
                    drNew.Item(TEXT_INS_TYPE) = oINSDetail.m_strINSType
                    drNew.Item(TEXT_COUNT) = oINSDetail.m_nCount
                    m_dtDetail.Rows.Add(drNew)
                Next
            End If
        Else
            If bAdd Then
                Dim dtTemp As DataTable = New DataTable
                If oDB.QueryINSDetailInfoByID(dtTemp, oPackageINSDetail.m_strINSID) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
                    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error.Error, "", MSG_DBERROR_EXCEPTION)
                    Exit Sub
                End If
                For Each dr As DataRow In dtTemp.Rows
                    Dim drNew As DataRow = m_dtDetail.NewRow
                    drNew.Item(TEXT_INS_NAME) = dr.Item(IDI_NAME)
                    drNew.Item(TEXT_INS_TYPE) = dr.Item(IDI_TYPE)
                    drNew.Item(TEXT_COUNT) = dr.Item(IDI_COUNT)
                    m_dtDetail.Rows.Add(drNew)
                Next
            Else
                For Each oINSDetail As INSDetailInfo In oPackageINSDetail.m_lstINSDetail
                    Dim drNew As DataRow = m_dtDetail.NewRow
                    drNew.Item(TEXT_INS_NAME) = oINSDetail.m_strINSName
                    drNew.Item(TEXT_INS_TYPE) = oINSDetail.m_strINSType
                    drNew.Item(TEXT_COUNT) = oINSDetail.m_nCount
                    m_dtDetail.Rows.Add(drNew)
                Next
            End If
        End If
            
    End Sub
    Private Sub Binding()
        'Me.dgvMain.HaveBtnColumn = True
        'dgvMain.BtnColName = TEXT_BTN_MOVE_OUT
        Dim bReadOnly() As Boolean = {True, True, False}
        'dgvMain.ColumnReadOnlyCollection = bReadOnly
        'dgvMain.ColumnWidthCollection = nShort
        dgvMain.DataSource = m_dtDetail
        dgvMain.Columns(2).ReadOnly = False
        dgvMain.Columns(0).Width = dgvMain.Width / 3 - 5
        dgvMain.Columns(1).Width = dgvMain.Width / 3 - 5
        dgvMain.Columns(2).Width = dgvMain.Width / 3 - 5
    End Sub

    Private Sub btnColse_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        m_oPackageINSDetailCheck.m_lstINSDetail.Clear()
        For Each dr As DataRow In m_dtDetail.Rows
            Dim oINSDetail As INSDetailInfo = New INSDetailInfo
            oINSDetail.m_strINSName = dr.Item(TEXT_INS_NAME)
            oINSDetail.m_strINSType = dr.Item(TEXT_INS_TYPE)
            oINSDetail.m_nCount = dr.Item(TEXT_COUNT)
            m_oPackageINSDetailCheck.m_lstINSDetail.Add(oINSDetail)
        Next
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub OnButtonCellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.RowIndex > -1 Then
            Dim dr As DataRow = m_dtDetail.Rows(e.RowIndex)
            If dr Is Nothing Then Exit Sub
            m_dtDetail.Rows.Remove(dr)
        End If
    End Sub
End Class