Option Explicit On
Option Strict On

Imports System.Data
Public Module StructureModule
    Public Class UserInfo
        Public m_strUserID As String   'user id
        Public m_strFullName As String 'user name
        Public m_strPassword As String 'user password
        Public m_strDPID As String
        Public m_strDPName As String 'user department name
        Public m_strWardID As String 'user ward id
        Public m_strWardName As String 'user Ward name
        Public m_strChineseCode As String

        Public m_shRole As Short 'user role in DB
        Public m_strRole As String

        Public m_shUseRole As Short 'user role in APP,Please use this value
        Public m_strUseRole As String

        Public m_bScanPermit As Boolean
        Public m_bArrangePermit As Boolean
        Public m_shStopFlag As Short

        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_strUserID = ""
            m_strFullName = ""
            m_strPassword = ""
            m_strChineseCode = ""
            m_strDPID = ""
            m_strDPName = ""
            m_strWardId = ""
            m_strWardName = ""
            m_shRole = USER_ROLE.ROLE_NULL
            m_strRole = ""
            m_shUseRole = USER_ROLE.ROLE_NULL
            m_strUseRole = ""
            m_bScanPermit = False
            m_shStopFlag = CShort(USER_STATE.NORMAL_USE)


        End Sub

        Public Sub GetRealityRole(ByVal nHardwareRole As Short)
            If (m_shRole = USER_ROLE.CSSD_ADMINISTRATOR Or m_shRole = USER_ROLE.CSSD_COMMONS) And _
                nHardwareRole <> HARDWARE_ROLE.CSSD Then

                m_shUseRole = USER_ROLE.CSSD_BROWSER
                m_strUseRole = MatchUserRoleToString(USER_ROLE.CSSD_BROWSER)
            Else
                m_shUseRole = m_shRole
                m_strUseRole = m_strRole
            End If

        End Sub
    End Class

    Public Class ChineseCharacter
        Public m_strChineseCharacter As String
        Public m_lstChineseCode As List(Of String)
        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_strChineseCharacter = String.Empty
            If Not (m_lstChineseCode Is Nothing) Then
                m_lstChineseCode.Clear()
            Else
                m_lstChineseCode = New List(Of String)
            End If
        End Sub
    End Class
    Public Class ChineseCharacterCollection
        Inherits List(Of ChineseCharacter)
    End Class

    ''' <summary>
    ''' 手持机数据
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TimerList
        Public m_strTime As String
        Public m_strPath As String
        Public Sub New()
            Reset()
        End Sub
        Public Sub Reset()
            m_strTime = String.Empty
            m_strPath = String.Empty
        End Sub
    End Class
    Public Class PackageInfo
        Public m_lPackageID As Long
        Public m_strINSID As String
        Public m_strINSName As String
        Public m_strINSType As String
        Public m_strINSUnit As String
        Public m_datSterilize As DateTime
        Public m_datAvailable As DateTime
        Public m_nSterilizRoomID As Integer
        Public m_shPackageState As Short
        Public Sub New()
            Reset()
        End Sub
        Public Sub Reset()
            m_shPackageState = 0
            m_lPackageID = -1
            m_nSterilizRoomID = -1
            m_strINSID = String.Empty
            m_strINSName = String.Empty
            m_strINSType = String.Empty
            m_strINSUnit = String.Empty
            m_datSterilize = New Date
            m_datAvailable = New Date
        End Sub

    End Class
    Public Class SUInfoCollection
        Inherits List(Of SUInfo)
        Private m_strFindINSID As String
        Private m_lFindCompanyID As Long
        Private m_strFindBatch As String

        Private m_dtTotalStock As DataTable
        Private m_dtDetailStock As DataTable
        Private m_dtStockReg As DataTable

        Public ReadOnly Property TotalStockTable() As DataTable
            Get
                Return m_dtTotalStock
            End Get
        End Property
        Public ReadOnly Property DetailStockTable() As DataTable
            Get
                Return m_dtDetailStock
            End Get
        End Property
        Public ReadOnly Property StockRegTable() As DataTable
            Get
                Return m_dtStockReg
            End Get
        End Property
        Public Sub New()
            MyBase.New()
            Reset()
        End Sub
        Public Sub Reset()
            m_strFindINSID = String.Empty
            m_lFindCompanyID = CONST_INVALID_DATA
            m_strFindBatch = String.Empty

            If m_dtStockReg IsNot Nothing Then
                m_dtStockReg.Clear()
            Else
                TableConstructor.CreateSUStockReg(m_dtStockReg)
            End If

            If m_dtDetailStock IsNot Nothing Then
                m_dtDetailStock.Clear()
            Else
                TableConstructor.CreateSUStockDetail(m_dtDetailStock)
            End If

            If m_dtTotalStock IsNot Nothing Then
                m_dtTotalStock.Clear()
            Else
                TableConstructor.CreateSUStockTotal(m_dtTotalStock)
            End If
        End Sub
        'Public Sub LoadInfoToTotalStockTable()
        '    m_dtTotalStock.Clear()
        '    For Each oSUInfo As SUInfo In Me
        '        Dim dr As DataRow = m_dtTotalStock.NewRow
        '        LoadInfoToDataRow(oSUInfo, dr)
        '        RowMerge.RowMergeCount(m_dtTotalStock, dr, TEXT_INS_ID, TEXT_STOCK_COUNT)
        '    Next

        '    For Each dr As DataRow In m_dtTotalStock.Rows
        '        Dim oINSInfo As INSInfo = LocalData.GetINSInfo(dr.Item(TEXT_INS_ID).ToString, False)
        '        Dim nFixCount As Integer = 0
        '        If oINSInfo IsNot Nothing Then nFixCount = oINSInfo.m_nSRFixCount
        '        dr.Item(TEXT_STOCK_FIX_COUNT) = nFixCount
        '        Dim nBalanceCount As Integer = CInt(dr.Item(TEXT_STOCK_COUNT)) - nFixCount
        '        dr.Item(TEXT_STOCK_BALANCE_COUNT) = nBalanceCount
        '        If nBalanceCount < 0 Then
        '            dr.Item(TEXT_COLOR_MARK) = Color.Red
        '        Else
        '            dr.Item(TEXT_COLOR_MARK) = DBNull.Value
        '        End If
        '    Next

        'End Sub
        Public Sub LoadInfoToDetailStockTable()
            m_dtDetailStock.Clear()
            For Each oSUInfo As SUInfo In Me
                Dim dr As DataRow = m_dtDetailStock.NewRow
                LoadInfoToDataRow(oSUInfo, dr)
                m_dtDetailStock.Rows.Add(dr)
            Next
        End Sub
        Public Sub LoadInfoToStockRegTable()
            m_dtStockReg.Clear()
            For Each oSUInfo As SUInfo In Me
                Dim dr As DataRow = m_dtStockReg.NewRow
                LoadInfoToDataRow(oSUInfo, dr)
                m_dtStockReg.Rows.Add(dr)
            Next
        End Sub
        Private Sub LoadInfoToDataRow(ByVal oSUInfo As SUInfo, ByRef dr As DataRow)
            dr.Item(TEXT_INS_ID) = oSUInfo.m_strINSID
            dr.Item(TEXT_INS_NAME) = oSUInfo.m_strName
            dr.Item(TEXT_INS_TYPE) = oSUInfo.m_strType
            dr.Item(TEXT_UNIT) = oSUInfo.m_strUnit
            If dr.Table.Columns.Contains(TEXT_INS_BATCH) Then
                dr.Item(TEXT_INS_BATCH) = oSUInfo.m_strBatch
            End If
            If dr.Table.Columns.Contains(TEXT_EXPIRE_DATE) Then
                dr.Item(TEXT_EXPIRE_DATE) = oSUInfo.m_dtimeExpire.ToString(TEXT_DATETIME_FORMATION_DATE)
            End If
            If dr.Table.Columns.Contains(TEXT_STOCK_COUNT) Then
                dr.Item(TEXT_STOCK_COUNT) = oSUInfo.m_nCount
            End If
            If dr.Table.Columns.Contains(SSS_COMPANY_ID) Then
                dr.Item(SSS_COMPANY_ID) = oSUInfo.m_lCompanyID
            End If
            If dr.Table.Columns.Contains(TEXT_PRODUCE_COMPANY) Then
                dr.Item(TEXT_PRODUCE_COMPANY) = oSUInfo.m_strCompanyName
            End If
            If dr.Table.Columns.Contains(TEXT_COUNT) Then
                dr.Item(TEXT_COUNT) = oSUInfo.m_nCount
            End If

        End Sub
        Public Function FindItem(ByVal strINSID As String, ByVal lCompany As Long, ByVal strBatch As String) As SUInfo
            m_strFindBatch = strBatch
            m_strFindINSID = strINSID
            m_lFindCompanyID = lCompany
            Dim oSUInfo As SUInfo = MyBase.Find(AddressOf FindItem)
            Reset()
            Return oSUInfo

        End Function
        Private Function FindItem(ByVal oElement As SUInfo) As Boolean
            Return (oElement.m_strBatch = m_strFindBatch And _
                    oElement.m_strINSID = m_strFindINSID And _
                    oElement.m_lCompanyID = m_lFindCompanyID)
        End Function
    End Class

    Public Class SUInfo
        Public m_strINSID As String
        Public m_strName As String
        Public m_strType As String
        Public m_strUnit As String
        Public m_strBatch As String
        Public m_dtimeProduce As Date
        Public m_dtimeExpire As Date
        Public m_lCompanyID As Long
        Public m_strCompanyName As String
        Public m_nDispatchCount As Integer
        Public m_nCount As Integer
        Public m_nRealityCount As Integer 'for Stocktaking
        Public m_nWS_WIR_REG_ID As Integer 'for TBL_WAREHOUSE_STOCK
        Public m_lSterilizerRoomID As Long
        Public m_strWHCode As String
        Public m_nInBoxCount As Integer
        Public Sub New()
            Reset()
        End Sub
        Public Sub Reset()
            m_strINSID = String.Empty
            m_strName = String.Empty
            m_strType = String.Empty
            m_strUnit = String.Empty
            m_strBatch = String.Empty
            m_dtimeProduce = New DateTime(1900, 1, 1, 0, 0, 0, 0)
            m_dtimeExpire = (New DateTime(1900, 1, 1, 0, 0, 0, 0))
            m_lCompanyID = CONST_INVALID_DATA
            m_strCompanyName = String.Empty
            m_nCount = 0
            m_nDispatchCount = 0
            m_nRealityCount = 0
            m_nWS_WIR_REG_ID = -1
            m_lSterilizerRoomID = -1
            m_strWHCode = String.Empty
            m_nInBoxCount = 1
        End Sub
        Public Function Copy() As SUInfo
            Dim newObject As New SUInfo
            newObject.m_strINSID = Me.m_strINSID
            newObject.m_strName = Me.m_strName
            newObject.m_strType = Me.m_strType
            newObject.m_strUnit = Me.m_strUnit
            newObject.m_strBatch = Me.m_strBatch
            newObject.m_dtimeProduce = Me.m_dtimeProduce
            newObject.m_dtimeExpire = Me.m_dtimeExpire
            newObject.m_lCompanyID = Me.m_lCompanyID
            newObject.m_strCompanyName = Me.m_strCompanyName
            newObject.m_nDispatchCount = Me.m_nDispatchCount
            newObject.m_nCount = Me.m_nCount
            newObject.m_nRealityCount = Me.m_nRealityCount
            newObject.m_lSterilizerRoomID = Me.m_lSterilizerRoomID
            newObject.m_strWHCode = Me.m_strWHCode
            Return newObject
        End Function
    End Class

#Region "机器连接画图信息"
    Public Class CLog
        Private m_dtDateTime As DateTime
        Private m_dtStartDateTime As DateTime
        Private m_dtEndDateTime As DateTime
        Private m_lstLogEvent As List(Of CLogEvent)

        Public Sub New()
            m_dtDateTime = Nothing
            m_lstLogEvent = New List(Of CLogEvent)
        End Sub

        Public Property LogDate() As Date
            Get
                Return m_dtDateTime
            End Get
            Set(ByVal value As Date)
                m_dtDateTime = value
            End Set
        End Property
        Public Property LogStartDate() As Date
            Get
                Return m_dtStartDateTime
            End Get
            Set(ByVal value As Date)
                m_dtStartDateTime = value
            End Set
        End Property
        Public Property LogEndDate() As Date
            Get
                Return m_dtEndDateTime
            End Get
            Set(ByVal value As Date)
                m_dtEndDateTime = value
            End Set
        End Property
        Public Sub SetDateTime(ByVal nYear As Integer, ByVal nMonth As Integer, ByVal nDay As Integer, ByVal nHour As Integer, ByVal nMinute As Integer, ByVal nSecond As Integer)
            m_dtDateTime = New DateTime(nYear, nMonth, nDay, nHour, nMinute, nSecond)
        End Sub

        Public Function GetDateTime() As DateTime
            Return m_dtDateTime
        End Function

        Public Function GetDate() As String
            Return [String].Format("{0:D}", m_dtDateTime)
        End Function

        Public Function GetTime() As String
            Return [String].Format("{0:T}", m_dtDateTime)
        End Function

        Public Sub AddLogEvent(ByVal dIntervalTime As Double, ByVal dPressure As Double, ByVal dJacketTemp As Double, ByVal dDraintTemp As Double, _
                                ByVal dChamberTemp As Double, ByVal dDryerTemp As Double)
            Dim oLogEvent As New CLogEvent
            oLogEvent.m_dIntervalTime = dIntervalTime
            oLogEvent.m_dPressure = dPressure
            oLogEvent.m_dJacketTemp = dJacketTemp
            oLogEvent.m_dDraintTemp = dDraintTemp
            oLogEvent.m_dChamberTemp = dChamberTemp
            oLogEvent.m_dDryerTemp = dDryerTemp
            m_lstLogEvent.Add(oLogEvent)
            'm_lstLogEvent.Insert(m_lstLogEvent.Count(), oLogEvent)
        End Sub

        Public Function GetLogEventCount() As Integer
            Return m_lstLogEvent.Count
        End Function
        Public Sub GetLogEvent(ByVal nIndex As Integer, ByRef dIntervalTime As Double, ByRef dPressure As Double, ByRef dJacketTemp As Double, ByRef dDraintTemp As Double, _
                                ByRef dChamberTemp As Double, ByRef dDryerTemp As Double)
            Dim oLogEvent As CLogEvent = m_lstLogEvent.Item(nIndex)
            dIntervalTime = oLogEvent.m_dIntervalTime
            dPressure = oLogEvent.m_dPressure
            dJacketTemp = oLogEvent.m_dJacketTemp
            dDraintTemp = oLogEvent.m_dDraintTemp
            dChamberTemp = oLogEvent.m_dChamberTemp
            dDryerTemp = oLogEvent.m_dDryerTemp
        End Sub
    End Class

    Public Class CLogEvent
        Public m_dIntervalTime As Double    '数据测量时间
        Public m_dPressure As Double        '压强
        Public m_dJacketTemp As Double      '保温温度
        Public m_dDraintTemp As Double
        Public m_dChamberTemp As Double
        Public m_dDryerTemp As Double
        Public Sub New()
            m_dIntervalTime = Nothing
            m_dPressure = Nothing
            m_dJacketTemp = Nothing
            m_dDraintTemp = Nothing
            m_dChamberTemp = Nothing
            m_dDryerTemp = Nothing
        End Sub

        Public Sub New(ByRef oLogEvent As CLogEvent)
            m_dIntervalTime = oLogEvent.m_dIntervalTime
            m_dPressure = oLogEvent.m_dPressure
            m_dJacketTemp = oLogEvent.m_dJacketTemp
            m_dDraintTemp = oLogEvent.m_dDraintTemp
            m_dChamberTemp = oLogEvent.m_dChamberTemp
            m_dDryerTemp = oLogEvent.m_dDryerTemp
        End Sub
    End Class
    Public Class PackageCheck
        Public m_oPackageInfo As PackageInfo
        Public m_nResult As Short
        Public m_strReason As String
        Public Sub New()
            m_oPackageInfo = New PackageInfo
            m_nResult = -1
            m_strReason = String.Empty
        End Sub
    End Class

#End Region
End Module
