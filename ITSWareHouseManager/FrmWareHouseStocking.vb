Imports ITSBase
Imports DBManager
Imports UIControlLib
Imports System.Windows.Forms

Public Class FrmWareHouseStocking
    Private m_lWSID As Long
    Private m_nStockCount As Integer
    Private m_oSuInfo As SUInfo

    Public Sub New(ByVal dr As DataRow)

        ' This call is required by the designer.
        InitializeComponent()
        m_lWSID = CONST_INVALID_DATA
        ' Add any initialization after the InitializeComponent() call.
        InitialControl(dr)
        txtCount.Focus()

    End Sub
    Private Sub InitialControl(ByVal dr As DataRow)
        If dr Is Nothing Then Exit Sub
        m_lWSID = CLng(dr.Item(TEXT_WS_ID))
        m_oSuInfo = New SUInfo
        m_oSuInfo.m_strINSID = CStr(dr.Item(TEXT_WS_INS_ID))
        m_oSuInfo.m_strName = CStr(dr.Item(TEXT_WS_INS_NAME))
        m_oSuInfo.m_strType = CStr(dr.Item(TEXT_WS_INS_TYPE))
        m_oSuInfo.m_strUnit = CStr(dr.Item(TEXT_WS_INS_UNIT))
        m_oSuInfo.m_dtimeExpire = CDate(dr.Item(TEXT_WS_EXPIRE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
        m_oSuInfo.m_dtimeProduce = CDate(dr.Item(TEXT_WS_PRODUCE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
        m_oSuInfo.m_strBatch = CStr(dr.Item(TEXT_WS_BATCH_ID))
        m_oSuInfo.m_lCompanyID = CInt(dr.Item(TEXT_WS_COMPANY_ID))
        m_oSuInfo.m_strCompanyName = CStr(dr.Item(TEXT_WS_COMPANY_NAME))
        m_oSuInfo.m_nCount = CInt(dr.Item(TEXT_STOCK_COUNT))

        txtInsID.Text = CStr(dr.Item(TEXT_WS_INS_ID))
        txtINSName.Text = CStr(dr.Item(TEXT_WS_INS_NAME))
        txtINSType.Text = CStr(dr.Item(TEXT_WS_INS_TYPE))
        txtINSUnit.Text = CStr(dr.Item(TEXT_WS_INS_UNIT))
        txtBatch.Text = CStr(dr.Item(TEXT_WS_BATCH_ID))
        txtExpired.Text = CDate(dr.Item(TEXT_WS_EXPIRE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
        txtCompany.Text = CStr(dr.Item(TEXT_WS_COMPANY_NAME))
        txtCount.Focus()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If m_lWSID = CONST_INVALID_DATA Then Exit Sub
        Dim oDBWareHouse As DBWareHouseManager = New DBWareHouseManager
        If Not Judgement.IsPlusInteger(txtCount.Text) Then
            UIMsgBox.MSGBoxShow(MSG_OP_INS_RQUEST_ERROR_INS_COUNT)
            txtCount.Focus()
            Exit Sub
        End If
        m_oSuInfo.m_nRealityCount = CInt(txtCount.Text)
        Dim lRet As Long = CONST_INVALID_DATA
        If m_oSuInfo.m_nCount > m_oSuInfo.m_nRealityCount Then
            lRet = oDBWareHouse.UpdateWareHouseStock(m_lWSID, m_oSuInfo, SR_LOG_INOUT_TYPE.WH_OUT_BALANCE)
        ElseIf m_oSuInfo.m_nCount < m_oSuInfo.m_nRealityCount Then
            lRet = oDBWareHouse.UpdateWareHouseStock(m_lWSID, m_oSuInfo, SR_LOG_INOUT_TYPE.WH_IN_BALANCE)
        Else
            Exit Sub
        End If
        If Not lRet = DBMEDITS_RESULT.SUCCESS Then
            UIMsgBox.MSGBoxShow(MSG_DBERROR_EXCEPTION)
            Exit Sub
        End If
        Me.Close()
    End Sub
    Private Sub tbQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCount.KeyPress
        '48代表0，57代表9，8代表空格，46代表小数点  
        If ((e.KeyChar < Chr(48) OrElse e.KeyChar > Chr(57)) AndAlso (e.KeyChar <> Chr(8)) AndAlso (e.KeyChar <> Chr(46))) Then e.Handled = True
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class