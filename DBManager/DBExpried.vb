Imports ITSBase
Imports DBAdapter
Public Class DBExpried
    Inherits DBOperateOle
    Public Sub New(Optional ByVal bSynchronized As Boolean = True)
        MyBase.New(bSynchronized)
    End Sub
    Public Function QueryWareHouseExpried(ByRef dt As DataTable) As Long
        dt.Clear()
        Dim strCon, strSql As String
        strCon = String.Format("{0} < to_date('{1}','{2}')", WS_EXPIRE_DATE, LocalData.ServerNow.Date.ToString(TEXT_DATETIME_FORMATION_DATE), CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
        strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, TBL_WAREHOUSE_STOCK, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_WS_ID) = CLng(JudgeDataValue(dr.Item(WS_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_WS_INS_ID) = CStr(JudgeDataValue(dr.Item(WS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_NAME) = CStr(JudgeDataValue(dr.Item(WS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_TYPE) = CStr(JudgeDataValue(dr.Item(WS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_UNIT) = CStr(JudgeDataValue(dr.Item(WS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_COMPANY_ID) = CStr(JudgeDataValue(dr.Item(WS_COMPANY_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_COMPANY_NAME) = CStr(JudgeDataValue(dr.Item(WS_COMPANY_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_BATCH_ID) = CStr(JudgeDataValue(dr.Item(WS_BATCH_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_PRODUCE_DATE) = CDate(JudgeDataValue(dr.Item(WS_PRODUCE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
            drNew.Item(TEXT_WS_EXPIRE_DATE) = CDate(JudgeDataValue(dr.Item(WS_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
            drNew.Item(TEXT_STOCK_COUNT) = CStr(JudgeDataValue(dr.Item(WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryPackageExpried(ByRef dt As DataTable) As Long
        dt.Clear()
        Dim strCon, strSql, strTable As String
        strCon = String.Format("{0} < to_date('{1}','{2}')", SRS_AVAILABLE_DATE, LocalData.ServerNow.Date.ToString(TEXT_DATETIME_FORMATION_DATE), CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
        strTable = String.Format("{0} inner join {1} on {2}={3}", TBL_STERILEROOM_RU_STOCK, MST_STERILEROOM_INFO, SRS_STERILIZE_ROOM_ID, SI_ID)
        strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, strTable, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(SRS_STERILIZE_ROOM_ID) = CLng(JudgeDataValue(dr.Item(SRS_STERILIZE_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_STERILIZEROOM_NAME) = CStr(JudgeDataValue(dr.Item(SI_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_PACKAGE_ID) = CStr(JudgeDataValue(dr.Item(SRS_PACKAGE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_ID) = CStr(JudgeDataValue(dr.Item(SRS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_NAME) = CStr(JudgeDataValue(dr.Item(SRS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_TYPE) = CStr(JudgeDataValue(dr.Item(SRS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_UNIT) = CStr(JudgeDataValue(dr.Item(SRS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_EXPIRE_DATE) = CDate(JudgeDataValue(dr.Item(SRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function ExpriedOutStock(ByVal dt As DataTable) As Long
        Dim strCon, strSQL As String
        Dim lOutID As Long
        If Not QueryNextVal(lOutID, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In dt.Rows
            strCon = String.Format("{0}={1}", WS_ID, dr.Item(TEXT_WS_ID))
            strSQL = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_WAREHOUSE_STOCK, strCon)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        If Not ImplementSterileRoomAbnormalInOutLog(SR_LOG_INOUT_TYPE.WH_OUT_EXPIRED, lOutID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not StoreRoomAbnormalDetailLog(lOutID, dt) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not ImplementSterileRoomInOutLog(SR_LOG_INOUT_TYPE.WH_OUT_EXPIRED, lOutID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function PackageExpriedOutStock(ByVal dt As DataTable) As Long
        Dim strCon, strSQL As String
        Dim lOutID As Long
        If Not QueryNextVal(lOutID, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In dt.Rows
            strCon = String.Format("{0}={1}", SRS_PACKAGE_ID, dr.Item(TEXT_PACKAGE_ID))
            strSQL = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_STERILEROOM_RU_STOCK, strCon)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        If Not ImplementSterileRoomAbnormalInOutLog(SR_LOG_INOUT_TYPE.INS_EXPRIED_OUT, lOutID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not StoreRoomruRuAbnormalDetailLog(lOutID, dt) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not ImplementSterileRoomInOutLog(SR_LOG_INOUT_TYPE.INS_EXPRIED_OUT, lOutID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Protected Function StoreRoomAbnormalDetailLog(ByVal lRegID As Long, ByVal dt As DataTable) As Boolean

        Dim strCols, strValues, strSql As String

        'Check condition is INS ID and BatchID and Company ID

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", _
                                SAID_REG_ID, SAID_INS_ID, SAID_INS_NAME, SAID_INS_TYPE, _
                                SAID_INS_UNIT, SAID_BATCH_ID, SAID_PRODUCE_DATE, SAID_EXPIRE_DATE, _
                                SAID_COMPANY_ID, SAID_COMPANY_NAME, SAID_COUNT)

        For Each dr As DataRow In dt.Rows
            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}',to_date('{6}','{11}'),to_date('{7}','{11}'),{8},'{9}',{10}", _
                              lRegID, CStr(dr.Item(TEXT_WS_INS_ID)), _
                              CStr(dr.Item(TEXT_WS_INS_NAME)), _
                              CStr(dr.Item(TEXT_WS_INS_TYPE)), _
                              CStr(dr.Item(TEXT_WS_INS_UNIT)), _
                              CStr(dr.Item(TEXT_WS_BATCH_ID)), _
                              CDate(JudgeDataValue(dr.Item(TEXT_WS_PRODUCE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CDate(JudgeDataValue(dr.Item(TEXT_WS_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CStr(dr.Item(TEXT_WS_COMPANY_ID)), _
                              CStr(dr.Item(TEXT_WS_COMPANY_NAME)), _
                               CStr(dr.Item(TEXT_STOCK_COUNT)), _
                              CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
            strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_ABNORMAL_INOUT_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSql) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return False
            End If
        Next
        Return True
    End Function

    Protected Function StoreRoomruRuAbnormalDetailLog(ByVal lRegID As Long, ByVal dt As DataTable) As Boolean
        For Each dr As DataRow In dt.Rows
            Dim oPackage As PackageInfo = New PackageInfo
            oPackage.m_lPackageID = CLng(JudgeDataValue(dr.Item(TEXT_PACKAGE_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            oPackage.m_strINSID = CStr(JudgeDataValue(dr.Item(TEXT_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackage.m_strINSName = CStr(JudgeDataValue(dr.Item(TEXT_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackage.m_strINSType = CStr(JudgeDataValue(dr.Item(TEXT_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackage.m_strINSUnit = CStr(JudgeDataValue(dr.Item(TEXT_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackage.m_datAvailable = CDate(JudgeDataValue(dr.Item(TEXT_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            If Not ImplementStoreRoomruRuAbnormalDetailLog(lRegID, oPackage) Then
                Return False
            End If
        Next
        Return True
    End Function

End Class
