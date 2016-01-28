Imports ITSBase
Imports DBAdapter
Imports ITSBase.Accessory.SurgeryInfoAccessory

Public Class DBHighValue
    Inherits DBOperateOle
    Public Function QueryHighRequestList(ByRef dt As DataTable) As Long
        Dim strSQL, strCon As String
        Dim strCols As String = String.Format("{0},{1},{2}", DR_ID, DR_DEPARTMENT_NAME, DR_REQUEST_DATE)
        strCon = String.Format("{0} in ('{1}','{2}') and {3}='{4}'", DR_STATE, CStr(REQUEST_STATE.UNCOMFIRM), CStr(REQUEST_STATE.PART_DISPATCH), DR_KIND, CStr(REQUEST_KIND.HIGH_VALUE_SU))
        strSQL = String.Format(DBCONSTDEF_SQL_SELECT_WHERE_ORDER, strCols, TBL_OPERATION_REQUEST_MASTER, strCon, DR_REQUEST_DATE)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQL, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(DR_ID) = JudgeDataValue(dr.Item(DR_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            drNew.Item(DR_DEPARTMENT_NAME) = JudgeDataValue(dr.Item(DR_DEPARTMENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(DR_REQUEST_DATE) = CDate(JudgeDataValue(dr.Item(DR_REQUEST_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryRequestInfoByID(ByRef oRequestInfo As SurgeryRequestMaster, ByVal lID As Long) As Long
        Dim strCon, strSQl, strTable As String
        strTable = String.Format("{0} inner join {1} on {2}={3}", TBL_OPERATION_REQUEST_MASTER, TBL_OPERATION_NOTE, DR_OPN_REG_ID, OPN_ID)
        strCon = String.Format("{0} ={1}", DR_ID, lID)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, strTable, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count = 1 Then
            oRequestInfo._id = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            oRequestInfo._noteId = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_OPN_REG_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            oRequestInfo._requestDate = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_REQUEST_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            oRequestInfo._roomID = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            oRequestInfo._room = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_ROOM_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            oRequestInfo._tableId = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_TABLE_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            oRequestInfo._status = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_STATE), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            oRequestInfo.m_shEidtFlag = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_EDIT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            oRequestInfo._staffName = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_STAFF_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            oRequestInfo._staffId = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_STAFF_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            oRequestInfo._depId = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_DEPARTMENT_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            oRequestInfo._depName = JudgeDataValue(ds.Tables(0).Rows(0).Item(DR_DEPARTMENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)

        End If

        If Not QueryRequestDetailByID(oRequestInfo.m_dtRequestDetail, lID) = DBMEDITS_RESULT.SUCCESS Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Private Function QuerySterilizeRoomID(ByRef lSterilizeRoomID As Long, ByVal lRoomID As Long) As Long
        Dim strCon, strSQL As String
        strCon = String.Format("{0}={1}", SI_ROOM_ID, lRoomID)
        strSQL = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, SI_ID, MST_STERILEROOM_INFO, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQL, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            lSterilizeRoomID = CLng(JudgeDataValue(ds.Tables(0).Rows(0).Item(SI_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            Return DBMEDITS_RESULT.SUCCESS
        End If
        Logger.WriteLine(String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_NOT_EXIST, MST_STERILEROOM_INFO, m_oDBConnect.GetCommandString))
        Return DBMEDITS_RESULT.ERROR_NOT_EXIST
    End Function
    Public Function QueryRequestDetailByID(ByRef dt As DataTable, ByVal lID As Long) As Long
        Dim strCon, strSQL, strCols As String
        strCols = String.Format("{0},{1},{2},{3},({4}-{5}) as {4},{5}", IRD_CODE, IRD_NAME, IRD_SPEC, IRD_UNIT, IRD_COUNT, IRD_INS_DISPATCH_COUNT)
        strCon = String.Format("{0}={1}", IRD_REG_ID, lID)
        strSQL = String.Format(DBCONSTDEF_SQL_SELECT_WHERE_ORDER, strCols, TBL_INS_REQUEST_DETAIL, strCon, IRD_CODE)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQL, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            If CInt(JudgeDataValue(dr.Item(IRD_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)) = 0 Then
                Continue For
            End If
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_INS_ID) = JudgeDataValue(dr.Item(IRD_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_INS_NAME) = JudgeDataValue(dr.Item(IRD_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_INS_TYPE) = JudgeDataValue(dr.Item(IRD_SPEC), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_INS_UNIT) = JudgeDataValue(dr.Item(IRD_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_COUNT) = JudgeDataValue(dr.Item(IRD_COUNT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DISPATCH_COUNT) = 0
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    '********************************************************************
    '	Title:			.QueryHighValueExist 
    '	Author:			CXX
    '	Create Date:	2009-9-14
    '	Description:    Generally use the Synchronized (Singleton Instance In all application)
    '                   Some Multi Thread should use the self-governed Connection such as Monitor
    '                   In that time call it with False
    '*********************************************************************
    Public Function QueryHighValueExist(ByVal strINSCode As String) As Long
        Dim strCon, strSQl As String
        strCon = String.Format("{0}='{1}'", PKD_PRODUCT_ORDER_CODE, strINSCode)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, PKD_INS_ID, TBL_PACKAGE_DETAIL_INFO, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count = 0 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        ElseIf ds.Tables(0).Rows.Count = 1 Then
            Return DBMEDITS_RESULT.ERROR_EXIST
        Else
            Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    '********************************************************************
    '	Title:			InsertHighValue 
    '	Author:			CXX
    '	Create Date:	2016-1-18
    '	Description:    Generally use the Synchronized (Singleton Instance In all application)
    '                   Some Multi Thread should use the self-governed Connection such as Monitor
    '                   In that time call it with False
    '*********************************************************************
    Public Function InsertHighValue(ByVal oHighValue As HighValueInfo, ByVal nSterilizeRoomID As Integer, ByVal oUserInfo As UserInfo, ByRef lPackageID As Long) As Long
        Dim strSQL, strValues, strCols As String
        Dim lHighValueLogID As Long

        '需集成，暂时先使用自带数据库
        If Not QueryNextVal(lPackageID, SEQ_TBL_PACKAGE_INFO) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        oHighValue.m_lPackageID = lPackageID
        If Not QueryNextVal(lHighValueLogID, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '插入治疗包信息表，返回治疗包号


        '插入治疗包详细表
        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", PKD_REG_ID, PKD_INS_ID, PKD_INS_NAME, PKD_INS_TYPE, PKD_BATCH_ID, _
                                 PKD_COMPANY_ID, PKD_COMPANY_NAME, PKD_COMPANY_PRODUCT_CODE, PKD_PRODUCT_ORDER_CODE, PKD_STATE, PKD_EXAM_DATE, PKD_EXPIRE_DATE)
        strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',to_date('{10}','{12}'),to_date('{11}','{12}')", oHighValue.m_lPackageID, oHighValue.m_strINSID, oHighValue.m_strINSName, _
                                  oHighValue.m_strINSType, oHighValue.m_strBatch, oHighValue.m_nCompanyID, oHighValue.m_strCompanyName, oHighValue.m_strCompanyCode, _
                                  oHighValue.m_strSequenceBarcode, CStr(HIGHVALUE_STATE.UNUSED), CDate(oHighValue.m_datExamDate).ToString(TEXT_DATETIME_FORMATION_DATE), _
                                  CDate(oHighValue.m_datExpriedDate).ToString(TEXT_DATETIME_FORMATION_DATE), CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
        strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_PACKAGE_DETAIL_INFO, strCols, strValues)
        If Not TransactionExecute(strSQL) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        '插入无菌区库存表
        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", SRS_PACKAGE_ID, SRS_INS_ID, SRS_INS_NAME, SRS_INS_TYPE, SRS_INS_UNIT, SRS_STERILIZE_ROOM_ID, SRS_STERILIZE_DATE, SRS_AVAILABLE_DATE)
        strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}',to_date('{6}','{8}'),to_date('{7}','{8}')", oHighValue.m_lPackageID, oHighValue.m_strINSID, oHighValue.m_strINSName, _
                                  oHighValue.m_strINSType, oHighValue.m_strINSUnit, nSterilizeRoomID, CDate(oHighValue.m_datExamDate).ToString(TEXT_DATETIME_FORMATION_DATE), _
                                  CDate(oHighValue.m_datExpriedDate).ToString(TEXT_DATETIME_FORMATION_DATE), CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
        strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_STERILEROOM_RU_STOCK, strCols, strValues)
        If Not TransactionExecute(strSQL) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '插入非正常入库日志表

        If Not ImplementSterileRoomAbnormalInOutLog(SR_LOG_INOUT_TYPE.HV_IN_STOCK, lHighValueLogID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If


        '插入入库日志表
        If Not ImplementSterileRoomInOutLog(SR_LOG_INOUT_TYPE.HV_IN_STOCK, lHighValueLogID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        '插入入库日志详细表

        If Not ImplementSterileRoomAbnormalHVLog(lHighValueLogID, oHighValue) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    'Public Function QueryRequestInfoByID(ByRef oRequestInfo As RequestInfo, ByVal lRequestID As Long) As Long
    '    Dim strCon, strSQL, strTable As String
    '    strTable = String.Format("{0} inner join {1} on {2}={3} ", TBL_OPERATION_REQUEST_MASTER, TBL_OPERATION_NOTE, ORM_REG_ID, OPN_ID)
    '    strCon = String.Format("{0}={1}", DR_ID, lRequestID)
    '    strSQL = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, strTable, strCon)
    '    Dim ds As New DataSet
    '    If Not QueryOleDb(strSQL, ds) Then
    '        Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
    '        Return DBMEDITS_RESULT.ERROR_EXCEPTION
    '    End If
    '    If ds.Tables(0).Rows.Count > 1 Then
    '        Logger.WriteLine(String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_EXIST_OVERFLOW, strTable, m_oDBConnect.GetCommandString))
    '        Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
    '    ElseIf ds.Tables(0).Rows.Count < 1 Then
    '        Logger.WriteLine(String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_NOT_EXIST, strTable, m_oDBConnect.GetCommandString))
    '        Return DBMEDITS_RESULT.ERROR_EXCEPTION
    '    End If
    'End Function
    Public Function InsertDispatch(ByVal oRequest As SurgeryRequestMaster, ByVal m_lstPackage As List(Of PackageInfo), ByVal bPartDispatch As Boolean, ByVal oUserInfo As UserInfo) As Long
        Dim strSQL, strCols, strValues, strCon As String
        Dim lDispatchID As Long
        Dim lSterilizeRoomID As Long
        If Not QueryNextVal(lDispatchID, SEQ_TBL_INS_DISPATCH) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not QuerySterilizeRoomID(lSterilizeRoomID, oRequest._roomID) = DBMEDITS_RESULT.SUCCESS Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        '插入发放主表
        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", ID_ID, ID_OPN_REG_ID, ID_REG_ID, ID_DP_ID, ID_DP_NAME, ID_ROOM_ID, ID_ROOM_NAME, _
                                ID_STAFF_ID, ID_STAFF_NAME, ID_DISPATCH_DATE)
        strValues = String.Format("{0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}',to_date('{9}','{10}')", lDispatchID, oRequest._id, oRequest._noteId, oRequest._depId, oRequest._depName, oRequest._roomID, _
                                 oRequest._room, oUserInfo.m_strUserID, oUserInfo.m_strFullName, LocalData.ServerNow, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)
        strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_INS_DISPATCH, strCols, strValues)
        If Not TransactionExecute(strSQL) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '插入发放详细表
        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6}", IDD_REG_ID, IDD_INS_ID, IDD_INS_NAME, IDD_INS_TYPE, IDD_INS_UNIT, IDD_PACKAGE_ID, IDD_BACK)
        For Each oPackInfo As PackageInfo In m_lstPackage
            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}'", _
                                    lDispatchID, oPackInfo.m_oINSInfo.m_strINSID, oPackInfo.m_oINSInfo.m_strName, oPackInfo.m_oINSInfo.m_strType, _
                                    oPackInfo.m_oINSInfo.m_strUnit, oPackInfo.m_lPackageID, CStr(BACK.NOTBACK))

            strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_INS_DISPATCH_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            '更新库存无菌区信息
            strCon = String.Format("{0}={1}", SRS_PACKAGE_ID, oPackInfo.m_lPackageID)
            strValues = String.Format("{0}={1}", SRS_STERILIZE_ROOM_ID, lSterilizeRoomID)
            strSQL = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_STERILEROOM_RU_STOCK, strValues, strCon)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        '更新申请主表
        Dim eRequestState As REQUEST_STATE = REQUEST_STATE.NULL
        If bPartDispatch Then
            eRequestState = REQUEST_STATE.PART_DISPATCH
        Else
            eRequestState = REQUEST_STATE.DISPATCH
        End If
        strValues = String.Format("{0}='{1}'", DR_STATE, CStr(eRequestState))
        strCon = String.Format("{0}={1}", DR_ID, oRequest._id)
        strSQL = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_OPERATION_REQUEST_MASTER, strValues, strCon)
        If Not TransactionExecute(strSQL) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '更新申请详细表
        For Each oRequestDetail As RequestDetailInfo In oRequest.m_lstDetail
            strValues = String.Format("{0}={0}+{1}", IRD_INS_DISPATCH_COUNT, oRequestDetail.m_nDispatchCount)
            strCon = String.Format("{0}='{1}'", IRD_CODE, oRequestDetail.m_strINSID)
            strSQL = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_INS_REQUEST_DETAIL, strValues, strCon)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next

        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Private Function UpdateRequestInfo(ByVal oRequest As SurgeryRequestMaster) As Long
        Dim strCon, strSQL As String
        strCon = String.Format("{0}")
    End Function
End Class
