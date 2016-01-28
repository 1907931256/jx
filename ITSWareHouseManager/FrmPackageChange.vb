Imports DBManager
Imports ITSBase
Imports UIControlLib
Public Class FrmPackageChange
    Private m_lPackageID As Long = -1
    Public Sub New(ByVal lPackageID As Long)

        ' This call is required by the designer.
        InitializeComponent()
        m_lPackageID = lPackageID
        Dim oDB As DBOperateOle = New DBOperateOle
        Dim dt As DataTable = New DataTable
        If oDB.QueryTotal(dt, MST_STERILEROOM_INFO) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
        Else
            cmbSterilizeRoom.DisplayMember = SI_NAME
            cmbSterilizeRoom.ValueMember = SI_ID
            cmbSterilizeRoom.DataSource = dt
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If cmbSterilizeRoom.Text = String.Empty OrElse m_lPackageID = -1 Then
            Exit Sub
        End If
        Dim oDBPeration As DbOperationManage = New DbOperationManage

        If Not oDBPeration.ChangePackageLocality(cmbSterilizeRoom.SelectedValue, m_lPackageID) = DBMEDITS_RESULT.SUCCESS Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(Windows.Forms.MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class