Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports ITSBase
Imports DBManager
Imports UIControlLib

Public Class FrmOPUseFaileReason
    Private m_dtUnit As DataTable
    Private m_oDBOperateOle As DbOperationManage = New DbOperationManage
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        dgvMain.NoItemAlter = MSG_GRIDVIEW_NOITEM_INFO_NOT_EXIST
        ' Add any initialization after the InitializeComponent() call.
        m_dtUnit = New DataTable
        m_dtUnit.Columns.Add(New DataColumn(TEXT_ID, GetType(String)))
        m_dtUnit.Columns.Add(New DataColumn(TEXT_REASON, GetType(String)))
        Dim nArrWidth() As Short = {25, 75}
        dgvMain.ColumnWidthCollection = nArrWidth
        dgvMain.DataSource = m_dtUnit
        'Init Button
        Query()
    End Sub
#Region "Method"
    Private Sub Query()
        m_dtUnit.Clear()
        If m_oDBOperateOle.QueryTotalReason(m_dtUnit) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        Else
            dgvMain.DataSource = m_dtUnit
        End If
    End Sub
    Private Sub Insert()
        If Not m_oDBOperateOle.InsertUseFaileReason(txtReason.Text) = DBMEDITS_RESULT.SUCCESS Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        Clear()
        Query()
    End Sub

    Private Sub Modify(ByVal strID As String)
        If Not m_oDBOperateOle.ModifyUseFaileReason(txtReason.Text, CLng(strID)) = DBMEDITS_RESULT.SUCCESS Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        Clear()
        Query()
    End Sub

    Private Sub Delete()
        Dim dr As DataRow = dgvMain.CurrentDataRow
        If dr Is Nothing Then
            Exit Sub
        End If
        If m_oDBOperateOle.DeleteUseFaileReason(CLng(dr.Item(TEXT_ID))) = DBMEDITS_RESULT.SUCCESS Then
            Clear()
            Query()
        Else
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
        End If
    End Sub

    Private Sub Clear()
        txtReason.Text = String.Empty
        ResetButton(True)
        txtReason.Focus()
    End Sub

    Private Function CheckIsExist(ByVal strID As String) As Boolean
        Dim strTemp As String = txtReason.Text
        Dim strCol As String = String.Empty
        strCol = String.Format("{0}='{1}'", TEXT_REASON, strTemp)
        If strID <> String.Empty Then
            strCol = strCol + String.Format(" And {0}<>'{1}'", TEXT_ID, strID)
        End If
        Dim drFind() As DataRow = m_dtUnit.Select(strCol)
        If drFind.Length > 0 Then
            UIMsgBox.MSGBoxShow(String.Format(MSG_ERROR_USE_FAILE_REASON_EXIST))
            txtReason.Focus()
            txtReason.SelectAll()
            Return True
        End If
        Return False
    End Function

    Private Function GetInfoToControl() As Boolean
        Dim dr As DataRow = dgvMain.CurrentDataRow
        If dr Is Nothing Then
            Return False
        End If
        txtReason.Text = dr.Item(TEXT_REASON).ToString
        txtReason.Focus()
        Return True
    End Function

    Private Sub ResetButton(ByVal bAdded As Boolean)
        If bAdded Then
            btnAdd.Text = TEXT_BTN_ADD
        Else
            btnAdd.Text = TEXT_BTN_OK
        End If
    End Sub
    Private Function IsChanged(ByVal strReason As String) As Boolean
        If txtReason.Text <> strReason Then Return True
        Return False
    End Function

    Private Sub Add()
        If btnAdd.Text = TEXT_BTN_ADD Then
            If Not CheckIsExist(String.Empty) Then
                Insert()
            End If
        End If
        If btnAdd.Text = TEXT_BTN_OK Then
            Dim dr As DataRow = dgvMain.CurrentDataRow
            If dr Is Nothing Then
                Exit Sub
            End If
            Dim strID As String = dr.Item(TEXT_ID).ToString
            Dim strReason As String = dr.Item(TEXT_REASON).ToString
            If IsChanged(strReason) Then
                If Not CheckIsExist(strID) Then
                    Modify(strID)
                End If
            Else
                Clear()
                ResetButton(True)
            End If
        End If
    End Sub

#End Region
#Region "Event"
    Private Sub OndgvMainClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMain.Click
        If btnAdd.Text = TEXT_BTN_OK Then
            GetInfoToControl()
        End If
    End Sub

    Private Sub OndgvMainCurrentRowIndexChanged(ByVal nOldIndex As Integer, ByVal nNewIndex As Integer) Handles dgvMain.CurrentRowIndexChanged
        If btnAdd.Text = TEXT_BTN_OK Then
            GetInfoToControl()
        End If
    End Sub

    Private Sub OndgvMainDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMain.DoubleClick
        If GetInfoToControl() Then
            ResetButton(False)
        End If
    End Sub

    Private Sub OnbtnAddClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Private Sub OnbtnDeleteClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub OnbtnModifyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        If GetInfoToControl() Then
            ResetButton(False)
        End If
    End Sub

    Private Sub OnbtnCloseClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub OnbtnCancelClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub
    Private Sub txtReason_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReason.KeyPress
        If e.KeyChar = Chr(13) Then
            e.KeyChar = Nothing
            btnAdd.PerformClick()
        End If
    End Sub
#End Region

#Region "Overrides"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim WM_KEYDOWN As Integer = 256
        Dim WM_SYSKEYDOWN As Integer = 260
        If ((msg.Msg = WM_KEYDOWN) Or (msg.Msg = WM_SYSKEYDOWN)) Then
            Select Case keyData
                Case Windows.Forms.Keys.Escape
                    btnClose.PerformClick()
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
End Class