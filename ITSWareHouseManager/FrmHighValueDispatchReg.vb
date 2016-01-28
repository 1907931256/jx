Imports System.Windows.Forms
Imports ITSBase
Imports DBManager
Imports UIControlLib
Imports ITSBase.Accessory.SurgeryInfoAccessory
Imports ZhiFa.Base.MessageControl.BaseMessageBox

Public Class FrmHighValueDispatchReg
    Private m_dtNoteList As DataTable
    Private m_oCurRequestInfo As SurgeryRequestMaster
    Private m_oDBHighValue As DBHighValue
    Private m_lRequestID As Long
    Private m_dsRequestList As DataSet
    Private m_dtDP As DataTable
    Private Sub Binding()  
        Dim nArrWidth() As Short = {15, 25, 20, 15, 10, 15}
        dgv.DataSource = m_oCurRequestInfo.m_dtRequestDetail
    End Sub
    Private Sub FrmHighValueDispatchReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initial()
    End Sub
    Private Sub Initial()
        m_oCurRequestInfo = New SurgeryRequestMaster
        m_oDBHighValue = New DBHighValue
        m_dsRequestList = New DataSet
        m_dtDP = New DataTable
        m_oDBHighValue.QueryTotal(m_dtDP, DIC_DEPT_INFO)

        Dim dv As DataView = New DataView(m_dtDP)
        m_dtDP = dv.ToTable("", True, DEPT_CODE, FULL_NAME, DEPT_ID)
        InitialRequestList()
        Binding()
        tbChecker.Text = LocalData.LoginUser.m_strFullName

    End Sub
    Private Function CreateTable() As DataTable
        Dim dtRequest As UIExpandPanelDataTable = New UIExpandPanelDataTable
        Dim nWidth() As Integer = {80, 100, 100}
        dtRequest.ColumnWidthCollection = nWidth
        dtRequest.Columns.Add(New DataColumn(DR_DEPARTMENT_NAME, GetType(String)))
        dtRequest.Columns.Add(New DataColumn(DR_ID, GetType(String)))
        dtRequest.Columns.Add(New DataColumn(DR_REQUEST_DATE, GetType(String)))
        dtRequest.MarkableColumn = TEXT_COLOR_MARK
        Return dtRequest
    End Function
    Private Sub InitialRequestList()
        m_dsRequestList.Clear()
        m_dsRequestList.Tables.Clear()
        Dim dt As DataTable = CreateTable()
        If Not m_oDBHighValue.QueryHighRequestList(dt) = DBMEDITS_RESULT.SUCCESS Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
            Return
        End If
        dt.TableName = TEXT_NOTE_LIST
        Dim ds As New DataSet
        m_dsRequestList.Tables.Add(dt)
        rptList.AddItem(TEXT_NOTE_LIST, m_dsRequestList, EXPAND_PANEL_TYPE.SEARCHBAR_HIGHLIGHT, True, m_dtDP)
    End Sub
    Public Function ReflashInfo() As Boolean
        InitialRequestList()
        'Dim dtRequest As DataTable = CreateTable()
        'Dim lRet As Long
        'lRet = m_oDBHighValue.QueryHighRequestList(dtRequest)
        'If lRet = DBMEDITS_RESULT.ERROR_EXCEPTION Then
        '    ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", MSG_DBERROR_EXCEPTION)
        '    Return False
        'End If
        'Return rptList.UpdateDataTable("", "", dtRequest)
    End Function
    Public Sub Clear()
        tbApplyNo.Text = String.Empty
        tbApplyDate.Text = String.Empty
        tbApplyRoom.Text = String.Empty
        txtRequestName.Text = String.Empty
        m_oCurRequestInfo.Reset()
        ReflashInfo()
    End Sub
    Private Sub lblReady_Click(sender As Object, e As EventArgs) Handles lblReady.Click
        Dim oFrmDisptachPare As FrmHighValueDispatchParpar = New FrmHighValueDispatchParpar(m_oCurRequestInfo)
        If oFrmDisptachPare.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Clear()
            ReflashInfo()
        End If
    End Sub
    Private Sub OnCellClick(ByVal sender As UIControlLib.UIDataGridView) Handles rptList.DataGridViewCellClick
        m_oCurRequestInfo.m_dtRequestDetail.Clear()
        Dim dr As DataRow = sender.CurrentDataRow
        If dr Is Nothing Then Exit Sub
        m_lRequestID = CLng(dr.Item(DR_ID))
        If Not m_oDBHighValue.QueryRequestInfoByID(m_oCurRequestInfo, m_lRequestID) = DBMEDITS_RESULT.SUCCESS Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, MSG_DBERROR_EXCEPTION)
            Return
        End If
        If m_oCurRequestInfo.m_shEidtFlag = EDIT_FLAG.LOCKED Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, String.Format(MSG_NOTE_LOCK, m_lRequestID))
            Return
        End If
        If m_oCurRequestInfo._status = CStr(REQUEST_STATE.DISPATCH) Then
            ZhiFa.Base.MessageControl.BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, MSG_ERROR_WARRING, String.Format(MSG_NOTE_DISPATCH, m_lRequestID))
            Return
        End If
        m_oCurRequestInfo.LoadDetailInfo(m_oCurRequestInfo.m_dtRequestDetail)
        SetNoteInfo()
    End Sub
    Private Sub SetNoteInfo()
        tbApplyNo.Text = m_oCurRequestInfo._id
        tbApplyDate.Text = CDate(m_oCurRequestInfo._requestDate).ToString(TEXT_DATETIME_FORMATION_DATE)
        tbApplyRoom.Text = m_oCurRequestInfo._room
        txtRequestName.Text = m_oCurRequestInfo._staffName
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
    End Sub
End Class
