Imports ITSBase
Imports DBManager
Imports UIControlLib
Public Class FrmOPFrontCheck
    Private m_lstPackageCheck As List(Of PackageCheck)
    Private m_lPackageID As Long
    Public Sub New(ByRef lstPackageCheck As List(Of PackageCheck), ByVal lPackageID As Long)

        ' This call is required by the designer.
        InitializeComponent()
        m_lstPackageCheck = lstPackageCheck
        m_lPackageID = lPackageID
        ' Add any initialization after the InitializeComponent() call.
        InitCmbResult()
        InitCmbReason()
        InitialPackage()
    End Sub
    Private Sub InitCmbResult()
        cmbResult.Items.Add(TEXT_SERVICE_RESULT_QUALIFIED)
        cmbResult.Items.Add(TEXT_SERVICE_RESULT_DISQULIFICATION)
    End Sub
    Private Sub InitCmbReason()
        Dim oDBOperateOle As New DBOperateOle

        Dim dt As DataTable = New DataTable
        If oDBOperateOle.QueryTotal(dt, MST_PACKAGE_CHECK_REASON) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        cmbReaon.DisplayMember = PCR_REASON
        cmbReaon.DataSource = dt
    End Sub
    Private Sub InitialPackage()
        Dim oPackageCheckInfo As PackageCheck = Nothing
        For Each oPackageCheck As PackageCheck In m_lstPackageCheck
            If oPackageCheck.m_oPackageInfo.m_lPackageID = m_lPackageID Then
                oPackageCheckInfo = oPackageCheck
                Exit For
            End If
        Next
        If oPackageCheckInfo Is Nothing Then
            Exit Sub
        End If
        txtPackageID.Text = oPackageCheckInfo.m_oPackageInfo.m_lPackageID
        txtINSID.Text = oPackageCheckInfo.m_oPackageInfo.m_strINSID
        txtINSName.Text = oPackageCheckInfo.m_oPackageInfo.m_strINSName
        txtINSType.Text = oPackageCheckInfo.m_oPackageInfo.m_strINSType
        txtINSUnit.Text = oPackageCheckInfo.m_oPackageInfo.m_strINSUnit
        cmbResult.Text = MatchCheckStateToString(oPackageCheckInfo.m_nResult)
        cmbReaon.Text = oPackageCheckInfo.m_strReason
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If cmbReaon.Text = String.Empty Then
            UIMsgBox.MSGBoxShow(MSG_USE_FRONT_REASON)
            Exit Sub
        End If
        For Each oPackageCheck As PackageCheck In m_lstPackageCheck
            If oPackageCheck.m_oPackageInfo.m_lPackageID = m_lPackageID Then
                oPackageCheck.m_nResult = MatchCheckStringToState(cmbResult.Text)
                oPackageCheck.m_strReason = cmbReaon.Text
            End If
        Next
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnReson_Click(sender As Object, e As EventArgs) Handles btnReson.Click
        Dim oFrmFaild As FrmOPUseFaileReason = New FrmOPUseFaileReason()
        oFrmFaild.ShowDialog()
        InitCmbReason()
    End Sub
    Private Sub cmbResult_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbResult.SelectedIndexChanged
        If cmbResult.Text = TEXT_RESULT_OK Then
            cmbReaon.Enabled = False
            cmbReaon.Text = String.Empty
        Else
            cmbReaon.Enabled = True
        End If
    End Sub
End Class