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
        Public ReadOnly Property PackageID() As Long
            Get
                Return m_lPackageID
            End Get
        End Property
        Public ReadOnly Property INSName() As String
            Get
                Return m_oINSInfo.m_strName
            End Get
        End Property
        Public ReadOnly Property INSType() As String
            Get
                Return m_oINSInfo.m_strType
            End Get
        End Property
        Public ReadOnly Property SterilizeMethod() As String
            Get
                Return String.Empty
            End Get
        End Property

        Public ReadOnly Property SterilizeMethodSub() As String
            Get
                Return m_strSterilizeMethodSub
            End Get
        End Property

        Public ReadOnly Property PackStaff() As String
            Get
                Return m_strStaffIDMain
            End Get
        End Property
        Public Property SterilizeDate() As DateTime
            Get
                Return m_dtimeSterilize
            End Get
            Set(value As DateTime)
                m_dtimeSterilize = value
            End Set
        End Property
        Public Property AvailableDate() As DateTime
            Get
                Return m_dtimeAvailable
            End Get
            Set(value As DateTime)
                m_dtimeAvailable = value
            End Set
        End Property
        Public ReadOnly Property EffectiveDate() As DateTime
            Get
                Return m_dtimeAvailable.AddDays(-1)
            End Get
        End Property
        Public ReadOnly Property SubPackStaff() As String
            Get
                Return m_strStaffIDSub
            End Get
        End Property
        Public ReadOnly Property FormtPackageID() As String
            Get
                Return BarCodeParse.PackageIDFormat(m_lPackageID)
            End Get
        End Property
        Public ReadOnly Property CleanMethod() As String
            Get
                Return m_strSterilizeMethodSub
            End Get
        End Property

        Public ReadOnly Property CleanDate() As DateTime
            Get
                Return m_dtimeSterilize
            End Get
        End Property

        Public ReadOnly Property StockDate() As DateTime
            Get
                Return m_dtimeAvailable
            End Get
        End Property

        Public ReadOnly Property SterilizerStaff() As String
            Get
                Return String.Empty
            End Get
        End Property

        Public m_bInvalid As Boolean '治疗包在发放时，是否可用，主要用于免申请发放，默认为true。

        Public m_lPackageID As Long
        Public m_shPackageType As Short
        Public m_dtimePackage As DateTime
        Public m_shSterilizeMethod As Short
        Public m_strSterilizeMethodSub As String
        Public m_dtimeSterilize As DateTime
        Public m_dtimeAvailable As DateTime
        Public m_strLocality As String
        Public m_shState As Short

        Public m_strStaffIDMain As String
        Public m_strStaffNameMain As String
        Public m_strStaffIDSub As String
        Public m_strStaffNameSub As String
        Public m_lPrepareCleanReg As Long
        Public m_lCleanReg As Long
        Public m_lSterilizeReg As Long

        Public m_strSterilizerStaffID As String
        Public m_strSterilizerStaffName As String

        Public m_lRelationshipID As Long

        Public m_oINSInfo As INSInfo
        Public m_lSterileRoomID As Long

        Public Sub New()
            m_oINSInfo = New INSInfo
            Reset()
        End Sub

        Public Sub New(ByRef oINSInfo As INSInfo)
            m_oINSInfo = New INSInfo
            Reset()
            m_shSterilizeMethod = oINSInfo.m_oSterilizeKindInfo.m_shMethod
            m_strSterilizeMethodSub = oINSInfo.m_oSterilizeKindInfo.m_strDescription
            m_oINSInfo = oINSInfo
        End Sub

        Public Sub Reset()

            m_bInvalid = True

            m_lPackageID = CONST_INVALID_DATA
            m_shPackageType = PACKAGE_TYPE.PACK_PUB

            m_dtimePackage = New DateTime(1900, 1, 1, 0, 0, 0, 0)
            m_shSterilizeMethod = CONST_INVALID_DATA
            m_strSterilizeMethodSub = String.Empty
            m_dtimeSterilize = New DateTime(1900, 1, 1, 0, 0, 0, 0)
            m_dtimeAvailable = New DateTime(1900, 1, 1, 0, 0, 0, 0)
            m_strLocality = ""
            m_shState = PACKAGE_STATE.STATE_NULL

            m_strStaffIDMain = ""
            m_strStaffNameMain = ""
            m_strStaffIDSub = ""
            m_strStaffNameSub = ""
            m_lPrepareCleanReg = CONST_INVALID_DATA
            m_lCleanReg = CONST_INVALID_DATA
            m_lSterilizeReg = CONST_INVALID_DATA

            m_oINSInfo.Reset()
            m_lSterileRoomID = CONST_INVALID_DATA

            m_strSterilizerStaffID = ""
            m_strSterilizerStaffName = ""
        End Sub

        'Public Function LoadINSInfo(ByVal strINSCode As String) As Boolean
        '    Dim oINSInfo As INSInfo = LocalData.GetINSInfo(strINSCode, False)
        '    If oINSInfo IsNot Nothing Then
        '        m_oINSInfo = oINSInfo
        '    Else
        '        Return False
        '    End If
        '    m_shSterilizeMethod = oINSInfo.m_oSterilizeKindInfo.m_shMethod
        '    m_strSterilizeMethodSub = oINSInfo.m_oSterilizeKindInfo.m_strDescription
        '    Return True
        'End Function

        Public Function LoadINSInfo(ByRef oINSInfo As INSInfo) As Boolean
            If oINSInfo Is Nothing Then Return False

            m_shSterilizeMethod = oINSInfo.m_oSterilizeKindInfo.m_shMethod
            m_strSterilizeMethodSub = oINSInfo.m_oSterilizeKindInfo.m_strDescription
            m_oINSInfo = oINSInfo

            Return True
        End Function

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
    Public Class PackageINSDetailCountCheck
        Public m_lOPNID As Long
        Public m_lPackageID As Long
        Public m_strINSName As String
        Public m_strINSID As String
        Public m_strINSType As String
        Public m_strINSUnit As String
        Public m_ePackageDetailCheck As PACKAGE_DETAIL_CHECK


        Public m_lstINSDetail As List(Of INSDetailInfo)
        Public Sub New()
            m_lPackageID = CONST_INVALID_DATA
            m_ePackageDetailCheck = PACKAGE_DETAIL_CHECK.NULL
            m_strINSID = String.Empty
            m_strINSName = String.Empty
            m_strINSType = String.Empty
            m_strINSUnit = String.Empty
            m_lstINSDetail = New List(Of INSDetailInfo)
            m_lOPNID = CONST_INVALID_DATA
        End Sub

    End Class
    Public Class INSDetailInfo
        Public m_strINSName As String
        Public m_strINSType As String
        Public m_nCount As Integer
        Public Sub New()
            m_strINSName = String.Empty
            m_strINSType = String.Empty
            m_nCount = CONST_INVALID_DATA
        End Sub
    End Class
    Public Class HighValueInfo
        Public m_strINSID As String
        Public m_strINSName As String
        Public m_strINSType As String
        Public m_strINSUnit As String
        Public m_nCompanyID As Integer
        Public m_strCompanyName As String
        Public m_strCompanyCode As String
        Public m_strSequenceBarcode As String
        Public m_datExamDate As Date
        Public m_datExpriedDate As Date
        Public m_strBatch As String
        Public m_lPackageID As Long
        Public Sub New()
            m_strINSID = String.Empty
            m_strINSName = String.Empty
            m_strINSType = String.Empty
            m_strINSUnit = String.Empty
            m_nCompanyID = CONST_INVALID_DATA
            m_strCompanyCode = String.Empty
            m_strCompanyName = String.Empty
            m_strBatch = String.Empty
            m_datExamDate = New Date(1900, 1, 1)
            m_datExpriedDate = New Date(1900, 1, 1)
            m_strSequenceBarcode = String.Empty
            m_lPackageID = CONST_INVALID_DATA
        End Sub
    End Class
    Public Class PackageLabel

        Public ReadOnly Property SterilizeDate() As DateTime
            Get
                Return m_dtimeSterilize
            End Get
        End Property
        Public ReadOnly Property EffectiveDate() As DateTime
            Get
                Return m_dtimeAvailable.AddDays(-1)
            End Get
        End Property
        Public ReadOnly Property AvailableDate() As DateTime
            Get
                Return m_dtimeAvailable
            End Get
        End Property
        Public ReadOnly Property PackDate() As DateTime
            Get
                Return m_dtimePackage
            End Get
        End Property
        Public ReadOnly Property FormtPackageID() As String
            Get
                Return m_strFormtPackageID
            End Get
        End Property
        Public ReadOnly Property INSProduceCompany() As String
            Get
                Return m_strProduceCompany
            End Get
        End Property
        Public ReadOnly Property INSCount() As Integer
            Get
                Return m_oINSInfo.m_nSUInCount
            End Get
        End Property
        Public ReadOnly Property INSName() As String
            Get
                Return m_oINSInfo.m_strName
            End Get
        End Property
        Public ReadOnly Property INSType() As String
            Get
                Return m_oINSInfo.m_strType
            End Get
        End Property

        Public ReadOnly Property SterilizeMethod() As String
            Get
                'Return MatchSterilizeMethodToString(CType(m_shSterilizeMethod, STERILIZE_TYPE))
            End Get
        End Property

        Public ReadOnly Property SterilizeMethodSub() As String
            Get
                Return m_strSterilizeMethodSub
            End Get
        End Property

        Public ReadOnly Property MachineAndBatch() As String
            Get
                If m_strMachineID.Trim = String.Empty OrElse m_strBatch.Trim = String.Empty Then
                    Return String.Empty
                End If
                Return m_strMachineID & "/" & String.Format("{0:D2}", IIf(Integer.TryParse(m_strBatch, New Integer), CInt(m_strBatch), m_strBatch))
            End Get
        End Property

        Public ReadOnly Property Machine() As String
            Get
                Return m_strMachineID
            End Get
        End Property

        Public ReadOnly Property Batch() As String
            Get
                If m_strBatch.Trim = String.Empty Then
                    Return String.Empty
                End If
                Return String.Format("{0:D2}", IIf(Integer.TryParse(m_strBatch, New Integer), CInt(m_strBatch), m_strBatch))
            End Get
        End Property

        Public ReadOnly Property MachineBatch() As String
            Get
                Return m_strBatch
            End Get
        End Property

        Public ReadOnly Property DepartmentName() As String
            Get
                Return m_strPRIDepartName
            End Get
        End Property
        Public ReadOnly Property CleanStaff() As String
            Get
                'Return IIf(LocalData.Printer.DisplayUser = CShort(LABEL_PRINT_DISPLAY_USER.USER_NAME), m_strStaffNameClean, m_strStaffIDClean).ToString
            End Get
        End Property
        Public ReadOnly Property PackStaff() As String
            Get
                'Return IIf(LocalData.Printer.DisplayUser = CShort(LABEL_PRINT_DISPLAY_USER.USER_NAME), m_strStaffNamePack, m_strStaffIDPack).ToString
            End Get
        End Property
        Public ReadOnly Property CheckStaff() As String
            Get
                'Return IIf(LocalData.Printer.DisplayUser = CShort(LABEL_PRINT_DISPLAY_USER.USER_NAME), m_strStaffNameCheck, m_strStaffIDCheck).ToString
            End Get
        End Property
        Public ReadOnly Property SterilizeStaff() As String
            Get
                'Return IIf(LocalData.Printer.DisplayUser = CShort(LABEL_PRINT_DISPLAY_USER.USER_NAME), m_strStaffNameSterilize, m_strStaffIDSterilize).ToString
            End Get
        End Property
        Public ReadOnly Property DispatchStaff() As String
            Get
                'Return IIf(LocalData.Printer.DisplayUser = CShort(LABEL_PRINT_DISPLAY_USER.USER_NAME), m_strStaffNameDispatch, m_strStaffIDDispatch).ToString
            End Get
        End Property

        Public m_lPackageID As Long
        Public m_bPack As Boolean
        Public m_dtimePackage As DateTime
        Public m_shSterilizeMethod As Short
        Public m_strSterilizeMethodSub As String
        Public m_bSterilize As Boolean
        Public m_dtimeSterilize As DateTime
        Public m_bAvailable As Boolean
        Public m_dtimeAvailable As DateTime

        Public m_strMachineID As String
        Public m_strBatch As String

        Public m_strStaffIDClean As String
        Public m_strStaffNameClean As String
        Public m_strStaffIDPack As String
        Public m_strStaffNamePack As String
        Public m_strStaffIDCheck As String
        Public m_strStaffNameCheck As String
        Public m_strStaffIDSterilize As String
        Public m_strStaffNameSterilize As String
        Public m_strStaffIDDispatch As String
        Public m_strStaffNameDispatch As String
        Public m_strTrackID As String

        Public m_nPRIDepartID As Integer
        Public m_strPRIDepartName As String

        Public m_oINSInfo As INSInfo

        Public m_shState As Short

        Public m_strFormtPackageID As String
        Public m_strProduceCompany As String

        Public Sub New()
            m_oINSInfo = New INSInfo
            Reset()
        End Sub

        Public Sub New(ByRef oINSInfo As INSInfo)
            m_oINSInfo = New INSInfo
            Reset()
            m_shSterilizeMethod = oINSInfo.m_oSterilizeKindInfo.m_shMethod
            m_strSterilizeMethodSub = oINSInfo.m_oSterilizeKindInfo.m_strDescription
            m_oINSInfo = oINSInfo
        End Sub

        Public Sub Reset()
            m_lPackageID = CONST_INVALID_DATA

            m_bPack = False
            m_dtimePackage = New DateTime(1900, 1, 1, 0, 0, 0, 0)
            m_shSterilizeMethod = CONST_INVALID_DATA
            m_strSterilizeMethodSub = String.Empty
            m_bSterilize = False
            m_dtimeSterilize = New DateTime(1900, 1, 1, 0, 0, 0, 0)
            m_bAvailable = False
            m_dtimeAvailable = New DateTime(1900, 1, 1, 0, 0, 0, 0)

            m_strStaffIDClean = ""
            m_strStaffNameClean = ""
            m_strStaffIDPack = ""
            m_strStaffNamePack = ""
            m_strStaffIDCheck = ""
            m_strStaffNameCheck = ""
            m_strStaffIDSterilize = ""
            m_strStaffNameSterilize = ""
            m_strStaffIDDispatch = ""
            m_strStaffNameDispatch = ""
            m_strTrackID = ""

            m_strMachineID = ""
            m_strBatch = ""
            m_strFormtPackageID = String.Empty
            m_strProduceCompany = String.Empty

            m_nPRIDepartID = CONST_INVALID_DATA
            m_strPRIDepartName = ""

            m_oINSInfo.Reset()

            m_shState = PACKAGE_STATE.STATE_NULL
        End Sub

        Public Function LoadINSInfo(ByVal strINSCode As String) As Boolean
            'Dim oINSInfo As INSInfo = LocalData.GetINSInfo(strINSCode, False)
            'If oINSInfo IsNot Nothing Then
            '    m_oINSInfo = oINSInfo
            'Else
            '    Return False
            'End If
            'm_shSterilizeMethod = oINSInfo.m_oSterilizeKindInfo.m_shMethod
            'm_strSterilizeMethodSub = oINSInfo.m_oSterilizeKindInfo.m_strDescription
            Return True
        End Function

        Public Function LoadINSInfo(ByRef oINSInfo As INSInfo) As Boolean
            If oINSInfo Is Nothing Then Return False

            m_shSterilizeMethod = oINSInfo.m_oSterilizeKindInfo.m_shMethod
            m_strSterilizeMethodSub = oINSInfo.m_oSterilizeKindInfo.m_strDescription
            m_oINSInfo = oINSInfo

            Return True
        End Function

    End Class

    Public Class INSInfo
        Public m_strINSID As String
        Public m_strChineseCode As String
        Public m_strName As String
        Public m_strType As String
        Public m_strUnit As String
        Public m_fUintPrice As Single
        Public m_fCostPrice As Single
        Public m_oSterilizeKindInfo As SterilizeKindInfo
        Public m_nSRFixCount As Integer
        Public m_nSUInCount As Integer
        Public m_shINSKind As Short
        Public m_lLoanerCompanyID As Long
        Public m_shEidtFlag As Short
        Public m_bMultiUseFlag As Boolean
        Public m_bSpecialFlag As Boolean
        Public m_bCleanToStockFlag As Boolean
        Public m_bBIOCheckFlag As Boolean
        Public m_strImagePath As String
        Public m_lstDetail As List(Of INSDetailInfo)
        Public m_lstOriDetailImagePath As List(Of String)
        Private m_dtDetail As DataTable
        Private m_dtOperationDetail As DataTable
        Public m_fExpenablePrice As Single

        Public ReadOnly Property OperationdetailTable() As DataTable
            Get
                Return m_dtOperationDetail
            End Get
        End Property


        Public ReadOnly Property INSDetailTable() As DataTable
            Get
                Return m_dtDetail
            End Get
        End Property
        Public ReadOnly Property IsExternal() As Boolean
            Get
                Return (m_lLoanerCompanyID > 0)
            End Get
        End Property
        Public Property ChineseCode() As String
            Get
                Return m_strChineseCode
            End Get
            Set(ByVal value As String)
                m_strChineseCode = value
            End Set
        End Property
        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_strINSID = ""
            m_strChineseCode = ""
            m_strName = ""
            m_strType = ""
            m_strUnit = ""
            m_fUintPrice = 0.0
            m_fCostPrice = 0.0
            m_oSterilizeKindInfo = New SterilizeKindInfo
            m_nSRFixCount = 0
            m_nSUInCount = 1
            m_shINSKind = INS_KINDS.INS_NULL
            m_lLoanerCompanyID = CONST_INVALID_DATA
            'm_shEidtFlag = EDIT_FLAG.EDITABLE
            m_bMultiUseFlag = False
            m_bSpecialFlag = False
            m_bCleanToStockFlag = False
            m_bBIOCheckFlag = False
            m_strImagePath = ""
            m_fExpenablePrice = 0.0
            If Not (m_lstDetail Is Nothing) Then
                m_lstDetail.Clear()
                m_lstOriDetailImagePath.Clear()
            Else
                m_lstDetail = New List(Of INSDetailInfo)
                m_lstOriDetailImagePath = New List(Of String)
            End If
            If m_dtDetail IsNot Nothing Then
                m_dtDetail.Clear()
            Else
                m_dtDetail = New DataTable
                m_dtDetail.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
                m_dtDetail.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
                m_dtDetail.Columns.Add(New DataColumn(TEXT_COUNT, GetType(Integer)))
                m_dtDetail.Columns.Add(New DataColumn(INSCT_ID, GetType(Long)))
                m_dtDetail.Columns.Add(New DataColumn(TEXT_INS_CONTAINER, GetType(String)))
                m_dtDetail.Columns.Add(New DataColumn(TEXT_RETURN_FLAG, GetType(Boolean)))
                m_dtDetail.Columns.Add(New DataColumn(TEXT_IMAGE_PATH, GetType(String)))
            End If
        End Sub

        Public Sub LoadInfoToTable()
            m_dtDetail.Clear()
            For Each oINSDetailInfo As INSDetailInfo In m_lstDetail
                Dim dr As DataRow = m_dtDetail.NewRow
                dr.Item(TEXT_INS_NAME) = oINSDetailInfo.m_strINSName
                dr.Item(TEXT_INS_TYPE) = oINSDetailInfo.m_strINSType
                dr.Item(TEXT_COUNT) = oINSDetailInfo.m_nCount

                m_dtDetail.Rows.Add(dr)
            Next
        End Sub
    End Class
    Public Class SterilizeKindInfo
        Public m_lID As Long        '表的主键，作为外键时用到
        Public m_shMethod As Short
        Public m_shValue As Short
        Public m_strUnit As String
        Public m_strDescription As String
        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_lID = CONST_INVALID_DATA
            m_shMethod = CONST_INVALID_DATA
            m_shValue = CONST_INVALID_DATA
            m_strUnit = ""
            m_strDescription = ""
        End Sub
        Public Function GetAvailabelDate(ByVal dtimeSerilizeDate As DateTime, ByRef dtimeAvailDate As DateTime) As Boolean

            'If Not DateParse.GetValidityDate(m_shValue, m_strUnit, dtimeSerilizeDate, dtimeAvailDate) Then
            '    Dim strMessage As String = String.Format(LOG_STERILIZE_INFO_ERROR_AVAILABELDATE_INVALID, m_shMethod, m_strUnit, m_shValue)
            '    Logger.WriteLine(strMessage & DateParse.LastError, EVENT_ENTRY_TYPE.ERRORR)
            '    Return False
            'End If
            Return True
        End Function

        Public Function GetAvailabelDateToString() As String
            'Return DateParse.GetValidityDateToString(m_shValue, m_strUnit)
        End Function

    End Class
    Public Class PrintPackInfo
        Public m_nId As Integer
        Public m_strText As String
        Public m_shPrintModel As Short
        Public m_shPackageType As Short
        Public m_nWidth As Integer
        Public m_nHeigh As Integer
        Public m_nOffSet As Integer
        Public m_bRotate As Boolean
        Public m_shBarCodeType As Short

        Public m_lstPackDetailInfo As List(Of PrintPackDetailInfo)
        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_nId = 0
            m_strText = ""
            m_shPrintModel = LABEL_PRINTER_TYPE.TYPE_NULL
            m_shPackageType = PACKAGE_TYPE.PACK_PUB
            m_nWidth = 0
            m_nHeigh = 0
            m_nOffSet = 0
            m_bRotate = False
            m_shBarCodeType = BAR_CODE_2D_MODE.NOT_PRINT_2D_BAR_CODE
            If m_lstPackDetailInfo Is Nothing Then
                m_lstPackDetailInfo = New List(Of PrintPackDetailInfo)
            Else
                m_lstPackDetailInfo.Clear()
            End If

        End Sub

        Public Function Copy() As PrintPackInfo
            Dim newObject As New PrintPackInfo
            newObject.m_strText = Me.m_strText
            newObject.m_shPrintModel = Me.m_shPrintModel
            newObject.m_shPackageType = Me.m_shPackageType
            newObject.m_nWidth = Me.m_nWidth
            newObject.m_nHeigh = Me.m_nHeigh
            newObject.m_nOffSet = Me.m_nOffSet
            newObject.m_bRotate = Me.m_bRotate
            newObject.m_shBarCodeType = Me.m_shBarCodeType
            For Each oPrintPackDetailInfo As PrintPackDetailInfo In Me.m_lstPackDetailInfo
                Dim oNewPrintPackDetailInfo As PrintPackDetailInfo = New PrintPackDetailInfo
                oNewPrintPackDetailInfo.m_strText = oPrintPackDetailInfo.m_strText
                oNewPrintPackDetailInfo.m_nX = oPrintPackDetailInfo.m_nX
                oNewPrintPackDetailInfo.m_nY = oPrintPackDetailInfo.m_nY
                oNewPrintPackDetailInfo.m_nWidth = oPrintPackDetailInfo.m_nWidth
                oNewPrintPackDetailInfo.m_strFont = oPrintPackDetailInfo.m_strFont
                oNewPrintPackDetailInfo.m_nSize = oPrintPackDetailInfo.m_nSize
                oNewPrintPackDetailInfo.m_bBarCode = oPrintPackDetailInfo.m_bBarCode
                oNewPrintPackDetailInfo.m_bReverse = oPrintPackDetailInfo.m_bReverse
                oNewPrintPackDetailInfo.m_bVisible = oPrintPackDetailInfo.m_bVisible
                oNewPrintPackDetailInfo.m_bFrame = oPrintPackDetailInfo.m_bFrame
                oNewPrintPackDetailInfo.m_strFormat = oPrintPackDetailInfo.m_strFormat

                newObject.m_lstPackDetailInfo.Add(oNewPrintPackDetailInfo)
            Next

            Return newObject
        End Function

        Public Function MaxSubINSName() As Integer
            Dim nMaxName As Integer = 0

            'For Each oPrintPackDetailInfo As PrintPackDetailInfo In Me.m_lstPackDetailInfo
            '    Dim nOldPos As Integer = 0
            '    Dim nPos As Integer = oPrintPackDetailInfo.m_strText.IndexOf(CONST_TEXT_PARAMETER_INDICATOR, nOldPos)
            '    If oPrintPackDetailInfo.m_strText.Substring(nPos + 2, 1).Equals(PARSE_PRINT_FORMAT_SUB_PARAMETER_START_FLAG) AndAlso Not (oPrintPackDetailInfo.m_strText.IndexOf(PARSE_PRINT_FORMAT_SUB_PARAMETER_END_FLAG, nPos + 2) = -1) Then
            '        Dim strParameterName As String = oPrintPackDetailInfo.m_strText.Substring(nPos + 3, oPrintPackDetailInfo.m_strText.IndexOf(PARSE_PRINT_FORMAT_SUB_PARAMETER_END_FLAG, nPos + 2) - nPos - 3).Trim
            '        If strParameterName.Contains(PARSE_PRINT_FORMAT_SUB_INS_NAME) AndAlso strParameterName.IndexOf(PARSE_PRINT_FORMAT_SUB_INS_NAME) = 0 Then
            '            Dim strIndex As String = strParameterName.Substring(PARSE_PRINT_FORMAT_SUB_INS_NAME.Length)
            '            Dim nIndex As Integer
            '            If Integer.TryParse(strIndex, nIndex) Then
            '                nMaxName += 1
            '            End If
            '        End If
            '    End If
            'Next

            Return nMaxName
        End Function

        Public Function MaxSubINSCount() As Integer
            Dim nMaxCount As Integer = 0

            'For Each oPrintPackDetailInfo As PrintPackDetailInfo In Me.m_lstPackDetailInfo
            '    Dim nOldPos As Integer = 0
            '    Dim nPos As Integer = oPrintPackDetailInfo.m_strText.IndexOf(CONST_TEXT_PARAMETER_INDICATOR, nOldPos)
            '    If oPrintPackDetailInfo.m_strText.Substring(nPos + 2, 1).Equals(PARSE_PRINT_FORMAT_SUB_PARAMETER_START_FLAG) AndAlso Not (oPrintPackDetailInfo.m_strText.IndexOf(PARSE_PRINT_FORMAT_SUB_PARAMETER_END_FLAG, nPos + 2) = -1) Then
            '        Dim strParameterName As String = oPrintPackDetailInfo.m_strText.Substring(nPos + 3, oPrintPackDetailInfo.m_strText.IndexOf(PARSE_PRINT_FORMAT_SUB_PARAMETER_END_FLAG, nPos + 2) - nPos - 3).Trim
            '        If strParameterName.Contains(PARSE_PRINT_FORMAT_SUB_INS_COUNT) AndAlso strParameterName.IndexOf(PARSE_PRINT_FORMAT_SUB_INS_COUNT) = 0 Then
            '            Dim strIndex As String = strParameterName.Substring(PARSE_PRINT_FORMAT_SUB_INS_COUNT.Length)
            '            Dim nIndex As Integer
            '            If Integer.TryParse(strIndex, nIndex) Then
            '                nMaxCount += 1
            '            End If
            '        End If
            '    End If
            'Next

            Return nMaxCount
        End Function
    End Class
    Public Class PrintPackDetailInfo
        Public m_strText As String
        Public m_nX As Integer
        Public m_nY As Integer
        Public m_nWidth As Integer
        Public m_strFont As String
        Public m_nSize As Integer
        Public m_bBarCode As Boolean
        Public m_bReverse As Boolean
        Public m_bVisible As Boolean
        Public m_bFrame As Boolean
        Public m_strFormat As String

        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_strText = ""
            m_nX = 0
            m_nY = 0
            m_nWidth = 0
            m_strFont = ""
            m_nSize = 0
            m_bBarCode = False
            m_bReverse = False
            m_bVisible = True
            m_bFrame = False
            m_strFormat = ""

        End Sub
    End Class
    Public Class LocalPrintPackInfo
        Private m_lstPrintPackInfo As List(Of PrintPackInfo)
        Private m_oINSLabelPrint As PrintPackInfo
        Private m_lstWHLabelInfo As List(Of PrintPackInfo)
        Private m_lstMachineBatchPrint As List(Of PrintPackInfo)
        Private m_oToolPrint As PrintPackInfo
        Private m_dtData As DataTable

        Public Property INSLabelPrint() As PrintPackInfo
            Get
                Return m_oINSLabelPrint
            End Get
            Set(ByVal value As PrintPackInfo)
                m_oINSLabelPrint = value
            End Set
        End Property

        Public Property ToolLabelPrint() As PrintPackInfo
            Get
                Return m_oToolPrint
            End Get
            Set(ByVal value As PrintPackInfo)
                m_oToolPrint = value
            End Set
        End Property

        Public ReadOnly Property lstPrintPackInfo() As List(Of PrintPackInfo)
            Get
                Return m_lstPrintPackInfo
            End Get
        End Property
        Public ReadOnly Property LabelFormat() As DataTable
            Get
                Return m_dtData
            End Get
        End Property

        Public ReadOnly Property lstWHLabelInfo() As List(Of PrintPackInfo)
            Get
                Return m_lstWHLabelInfo
            End Get
        End Property

        Public ReadOnly Property lstMachineBatch() As List(Of PrintPackInfo)
            Get
                Return m_lstMachineBatchPrint
            End Get
        End Property

        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_oINSLabelPrint = New PrintPackInfo

            If m_lstPrintPackInfo Is Nothing Then
                m_lstPrintPackInfo = New List(Of PrintPackInfo)
            Else
                m_lstPrintPackInfo.Clear()
            End If

            If m_lstMachineBatchPrint Is Nothing Then
                m_lstMachineBatchPrint = New List(Of PrintPackInfo)
            Else
                m_lstMachineBatchPrint.Clear()
            End If

            If m_lstWHLabelInfo Is Nothing Then
                m_lstWHLabelInfo = New List(Of PrintPackInfo)
            Else
                m_lstWHLabelInfo.Clear()
            End If

            If m_oToolPrint Is Nothing Then
                m_oToolPrint = New PrintPackInfo
            Else
                m_oToolPrint.Reset()
            End If


            If m_dtData Is Nothing Then
                TableConstructor.CreateLabelFomat(m_dtData)
            Else
                m_dtData.Clear()
            End If
        End Sub

        Public Sub LoadLabelFormat()
            m_dtData.Clear()

            For Each oPrintPackInfo As PrintPackInfo In Me.m_lstPrintPackInfo
                Dim drFind As DataRow() = m_dtData.Select(String.Format("{0}='{1}'", TEXT_ID, oPrintPackInfo.m_nId))
                If drFind.Length = 0 Then
                    Dim drNew As DataRow = m_dtData.NewRow
                    drNew.Item(TEXT_ID) = oPrintPackInfo.m_nId
                    drNew.Item(TEXT_NAME) = oPrintPackInfo.m_strText

                    m_dtData.Rows.Add(drNew)
                End If
            Next
        End Sub

        Public Function GetLabelFormatNameByID(ByVal nID As Integer) As String
            Dim strName As String = String.Empty

            For Each oPrintPackInfo As PrintPackInfo In Me.m_lstPrintPackInfo

                If oPrintPackInfo.m_nId = nID Then
                    strName = oPrintPackInfo.m_strText
                    Exit For
                End If
            Next

            Return strName
        End Function
    End Class
    Public Class PackageScanInfo
        Public Enum STATE_ERROR As Short
            NULL = -1
            SUCCESS = 0
            STATE_ERROR = 100
            INS_NOT_EXIST
            MORE_COUNT
            PRI_DEPARTMENT_ERROR
            ERROR_EXPIRED
            ERROR_PACKAGE_TYPE
            STOCK_NOT_EXIST
            RECEIVE_ERROR
            BORROW_BACK_ERROR
            DISPATCH_DETAIL_ERROR
            NOTHINH_ERROR
        End Enum
        Public m_eType As STATE_ERROR
        Public m_strErrorInfo As String
        Public m_oPackage As PackageInfo
        Public Sub New()
            m_eType = STATE_ERROR.NULL
            m_strErrorInfo = String.Empty
            m_oPackage = Nothing
        End Sub
        Public Sub New(ByRef oPackage As PackageInfo)
            m_eType = STATE_ERROR.NULL
            m_strErrorInfo = String.Empty
            m_oPackage = oPackage
        End Sub
    End Class
#End Region
End Module
