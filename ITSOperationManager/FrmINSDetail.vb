Imports ITSBase
Imports DBManager
Imports UIControlLib

Public Class FrmINSDetail

    Public Sub New(ByVal strINSID As String, ByVal strINSName As String, ByVal strINStype As String, ByVal strINSUnit As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        lblINSID.Text = strINSID
        lblINSName.Text = strINSName
        lblINSType.Text = strINStype
        lblINSUnit.Text = strINSUnit

        Dim oDB As DbOperationManage = New DbOperationManage
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_COUNT, GetType(String)))
        Binding(dt)
        Dim dtTemp As DataTable = New DataTable
        If oDB.QueryINSDetailInfoByID(dtTemp, strINSID) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        For Each dr As DataRow In dtTemp.Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_INS_NAME) = dr.Item(IDI_NAME)
            drNew.Item(TEXT_INS_TYPE) = dr.Item(IDI_TYPE)
            drNew.Item(TEXT_COUNT) = dr.Item(IDI_COUNT)
            dt.Rows.Add(drNew)
        Next
        Binding(dt)
    End Sub
    Private Sub Binding(ByVal dt As DataTable)
        Dim nShort() As Short = {40, 20, 40}
        dgvMain.ColumnWidthCollection = nShort
        dgvMain.DataSource = dt
    End Sub

    Private Sub btnColse_Click(sender As Object, e As EventArgs) Handles btnColse.Click
        Me.Close()
    End Sub
End Class