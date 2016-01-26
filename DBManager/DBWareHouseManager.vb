Imports ITSBase
Imports DBAdapter
Imports ITSBase.Accessory
Imports System.Data.OleDb
Imports System.Reflection

Public Class DbWareHouseManager
    Inherits DbOperateSummery
    Public Function QueryInsInfo(ByRef dt As DataTable, ByVal ParamArray arrType() As INS_KINDS) As Long
        Dim strSQl, strCon, strCols As String
        strCon = CreateArrayCondition(INS_KIND, SqlDbType.SmallInt, True, arrType)
        strCols = String.Format("{0},{1},{2},{3},{4}", INS_CODE, INS_NAME_INPUTCODE, INS_NAME, INS_TYPE, INS_UNIT)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, strCols, MST_INSTRUMENT_INFO, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            dt = ds.Tables(0).Copy
            ds.Dispose()
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryProductCompanyInfo(ByRef dt As DataTable) As Long
        Dim strSQl As String
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT, DBCONSTDEF_SQL_SELECT_ALL, MST_PRODUCE_COMPANY_INFO)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            dt = ds.Tables(0).Copy
            ds.Dispose()
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function WareHouseInReg(ByVal dt As DataTable) As Long
        Dim strSQL, strCondition, strCols, strValues, strJudge, strSqlInsert, strSqlUpdate As String
        Dim lRetID As Long = -1
        If Not QueryNextVal(lRetID, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In dt.Rows
            Dim strINSID As String = JudgeDataValue(dr.Item(TEXT_WS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            Dim strBatch As String = JudgeDataValue(dr.Item(TEXT_WS_BATCH_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            Dim strCompanyID As String = JudgeDataValue(dr.Item(TEXT_WS_COMPANY_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            Dim nCount As Integer = JudgeDataValue(dr.Item(TEXT_WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            strCondition = String.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'", _
                                     WS_INS_ID, strINSID, WS_BATCH_ID, strBatch, WS_COMPANY_ID, strCompanyID)

            strJudge = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, WS_INS_ID, TBL_WAREHOUSE_STOCK, strCondition)

            strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", _
                               WS_ID, WS_INS_ID, WS_INS_NAME, WS_INS_TYPE, WS_INS_UNIT, _
                               WS_BATCH_ID, WS_PRODUCE_DATE, WS_EXPIRE_DATE, _
                               WS_COMPANY_ID, WS_COMPANY_NAME, WS_INS_COUNT)
            strValues = String.Format("{0}.nextval,'{1}','{2}','{3}','{4}','{5}',to_date('{6}','YYYY-HH-DD'),to_date('{7}','YYYY-HH-DD'),'{8}','{9}','{10}'", _
                                     SEQ_TBL_WAREHOUSE_STOCK, strINSID, _
                                    CStr(JudgeDataValue(dr.Item(TEXT_WS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_WS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_WS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_WS_BATCH_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CDate(JudgeDataValue(dr.Item(TEXT_WS_PRODUCE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                                    CDate(JudgeDataValue(dr.Item(TEXT_WS_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_WS_COMPANY_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_WS_COMPANY_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                     CInt(JudgeDataValue(dr.Item(TEXT_WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)))
            strSqlInsert = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_WAREHOUSE_STOCK, strCols, strValues)

            strValues = String.Format("{0}={0}+{1}", WS_INS_COUNT, nCount)
            strSqlUpdate = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_WAREHOUSE_STOCK, _
                                     strValues, strCondition)

            strSQL = String.Format(DBCONSTDEF_ORACLE_SELECT_INSERT_UPDATE, TBL_WAREHOUSE_STOCK, strJudge, strSqlUpdate, strSqlInsert)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next

        If Not ImplementSterileRoomAbnormalInOutLog(EnumDef.SR_LOG_INOUT_TYPE.WH_IN, lRetID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not ImplementStoreRoomAbnormalDetailLog(lRetID, dt) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not ImplementSterileRoomInOutLog(SR_LOG_INOUT_TYPE.WH_IN, lRetID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function CheckWareHouseStock(ByVal strINSID As String, ByVal nCompanyID As Integer, ByVal strBatch As String, ByRef nStockCount As Integer, Optional ByRef dtProducDate As Date = Nothing, Optional ByRef dtExpried As Date = Nothing) As Long
        Dim strSQL, strCon As String
        strCon = String.Format("{0}='{1}' and {2}='{3}' and {4}='{5}'", WS_INS_ID, strINSID, WS_COMPANY_ID, nCompanyID, WS_BATCH_ID, strBatch)
        strSQL = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, TBL_WAREHOUSE_STOCK, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQL, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count < 1 Then
            Logger.WriteLine(String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_NOT_EXIST, TBL_WAREHOUSE_STOCK, WS_ID))
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST

        ElseIf ds.Tables(0).Rows.Count > 1 Then
            Logger.WriteLine(String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_EXIST_OVERFLOW, TBL_WAREHOUSE_STOCK, WS_ID))
            Return DBMEDITS_RESULT.EXIST_OVERFLOW
        Else
            nStockCount = CInt(JudgeDataValue(ds.Tables(0).Rows(0).Item(WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            dtProducDate = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(WS_PRODUCE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            dtExpried = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(WS_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            Return DBMEDITS_RESULT.SUCCESS
        End If
    End Function
    Public Function WareHouseOutReg(ByVal dt As DataTable) As Long
        Dim strCondition, strSQl, strConditionMore, strConditionEqual, strJudgeEqual, strJudgeMore, strValues, strSqlUpdate, strSqlDelete As String

        Dim lRetID As Long = -1
        If Not QueryNextVal(lRetID, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        'strSqlCheckCount = String.Format("IF EXISTS({0}) SET {1} := 1  ELSE SET {1} := 0", strJudgeMore, "@CHECK_COUNT")
        'strSQl = String.Format("IF EXISTS(0}) {1}  ELSE {2}", strJudgeEqual, strSqlDelete, strSqlUpdate)


        For Each dr As DataRow In dt.Rows

            strCondition = String.Format("{0}='{1}' AND {2}='{3}' AND {4}={5} ", _
                                      WS_INS_ID, CStr(JudgeDataValue(dr.Item(TEXT_WS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                      WS_BATCH_ID, CStr(JudgeDataValue(dr.Item(TEXT_WS_BATCH_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                      WS_COMPANY_ID, CInt(JudgeDataValue(dr.Item(TEXT_WS_COMPANY_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)))

            strConditionMore = String.Format("{0} AND {1} >= {2}", strCondition, WS_INS_COUNT, CInt(JudgeDataValue(dr.Item(TEXT_WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)))
            strConditionEqual = String.Format("{0} AND {1} = {2}", strCondition, WS_INS_COUNT, CInt(JudgeDataValue(dr.Item(TEXT_WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)))

            strJudgeEqual = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, WS_INS_ID, TBL_WAREHOUSE_STOCK, strConditionEqual)
            strJudgeMore = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, WS_INS_ID, TBL_WAREHOUSE_STOCK, strConditionMore)

            strValues = String.Format("{0}={0}-{1}", WS_INS_COUNT, CInt(JudgeDataValue(dr.Item(TEXT_WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)))
            strSqlUpdate = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_WAREHOUSE_STOCK, _
                                         strValues, strCondition)

            strSqlDelete = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_WAREHOUSE_STOCK, strCondition)

            strSQl = String.Format(DBCONSTDEF_ORACLE_SELECT_INSERT_UPDATE, TBL_WAREHOUSE_STOCK, strJudgeEqual, strSqlDelete, strSqlUpdate)

            If Not TransactionExecute(strSQl) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
                Dim str As String = m_oDBConnect.GetCommandString
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        If Not ImplementSterileRoomAbnormalInOutLog(EnumDef.SR_LOG_INOUT_TYPE.WH_OUT_OTHER, lRetID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not ImplementStoreRoomAbnormalDetailLog(lRetID, dt) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not ImplementSterileRoomInOutLog(SR_LOG_INOUT_TYPE.WH_OUT_OTHER, lRetID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS

    End Function


    Public Function QueryWareHouseStockTotal(ByRef dt As DataTable) As Long
        dt.Clear()
        Dim strSQl, strCols, strGroup As String
        strCols = String.Format("{0},{1},{2},{3},sum({4}) as {4}", _
                                 WS_INS_ID, WS_INS_NAME, WS_INS_TYPE, WS_INS_UNIT, WS_INS_COUNT)
        strGroup = String.Format("{0},{1},{2},{3}", _
                                 WS_INS_ID, WS_INS_NAME, WS_INS_TYPE, WS_INS_UNIT)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_GROUP_ORDER, strCols, TBL_WAREHOUSE_STOCK, strGroup, WS_INS_ID)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_WS_INS_ID) = CStr(JudgeDataValue(dr.Item(WS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_NAME) = CStr(JudgeDataValue(dr.Item(WS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_TYPE) = CStr(JudgeDataValue(dr.Item(WS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_UNIT) = CStr(JudgeDataValue(dr.Item(WS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_STOCK_COUNT) = CInt(JudgeDataValue(dr.Item(WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryPackageStockTotal(ByRef dt As DataTable) As Long
        dt.Clear()
        Dim strSQl, strCols, strGroup As String
        strCols = String.Format("{0},{1},{2},{3},count({4}) as {5}", _
                                 SRS_INS_ID, SRS_INS_NAME, SRS_INS_TYPE, SRS_INS_UNIT, SRS_PACKAGE_ID, TEXT_STOCK_COUNT)
        strGroup = String.Format("{0},{1},{2},{3}", _
                                 SRS_INS_ID, SRS_INS_NAME, SRS_INS_TYPE, SRS_INS_UNIT)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_GROUP_ORDER, strCols, TBL_STERILEROOM_RU_STOCK, strGroup, SRS_INS_ID)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_WS_INS_ID) = CStr(JudgeDataValue(dr.Item(SRS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_NAME) = CStr(JudgeDataValue(dr.Item(SRS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_TYPE) = CStr(JudgeDataValue(dr.Item(SRS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_UNIT) = CStr(JudgeDataValue(dr.Item(SRS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_STOCK_COUNT) = CInt(JudgeDataValue(dr.Item(TEXT_STOCK_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryWareHouseStockDetail(ByRef dt As DataTable) As Long
        dt.Clear()
        Dim strSQl As String
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_ORDER_ASC, DBCONSTDEF_SQL_SELECT_ALL, TBL_WAREHOUSE_STOCK, WS_INS_ID)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_WS_ID) = CInt(JudgeDataValue(dr.Item(WS_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_WS_INS_ID) = CStr(JudgeDataValue(dr.Item(WS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_NAME) = CStr(JudgeDataValue(dr.Item(WS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_TYPE) = CStr(JudgeDataValue(dr.Item(WS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_INS_UNIT) = CStr(JudgeDataValue(dr.Item(WS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_WS_COMPANY_ID) = CInt(JudgeDataValue(dr.Item(WS_COMPANY_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_COMPANY_NAME) = CStr(JudgeDataValue(dr.Item(WS_COMPANY_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_BATCH_ID) = CStr(JudgeDataValue(dr.Item(WS_BATCH_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WS_PRODUCE_DATE) = CDate(JudgeDataValue(dr.Item(WS_PRODUCE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
            drNew.Item(TEXT_WS_EXPIRE_DATE) = CDate(JudgeDataValue(dr.Item(WS_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
            drNew.Item(TEXT_STOCK_COUNT) = CInt(JudgeDataValue(dr.Item(WS_INS_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function UpdateWareHouseStock(ByVal lWsID As Long, ByVal oSuInfo As SUInfo, ByVal etype As SR_LOG_INOUT_TYPE) As Long
        Dim strSQL, strCon, strValue As String
        Dim lRet As Long = CONST_INVALID_DATA
        If Not QueryNextVal(lRet, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString + m_oDBConnect.GetCommandString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        strCon = String.Format("{0}={1}", WS_ID, lWsID)
        strValue = String.Format("{0}={1}", WS_INS_COUNT, oSuInfo.m_nRealityCount)
        strSQL = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_WAREHOUSE_STOCK, strValue, strCon)
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString + m_oDBConnect.GetCommandString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionExecute(strSQL) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not ImplementSterileRoomAbnormalInOutLog(etype, lRet) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not ImplementStoreRoomAbnormalDetailLog(lRet, oSuInfo) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not ImplementSterileRoomInOutLog(etype, lRet) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryPackageStockDetail(ByRef dt As DataTable) As Long
        dt.Clear()
        Dim strSql, strTable As String
        strTable = String.Format("{0} inner join {1} on {2}={3}", TBL_STERILEROOM_RU_STOCK, MST_STERILEROOM_INFO, SRS_STERILIZE_ROOM_ID, SI_ID)
        strSql = String.Format(DBCONSTDEF_SQL_SELECT_ORDER_ASC, DBCONSTDEF_SQL_SELECT_ALL, strTable, SRS_STERILIZE_ROOM_ID)
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
    Public Function CheckSameBatchExpried(ByRef dtExpried As Date, ByVal strINSID As String, ByVal strBatch As String, ByVal nCompanyID As Integer) As Long
        Dim strCondition, strOrder, strSql As String

        'Check condition is INS ID and BatchID and Company ID
        strCondition = String.Format("{0}='{1}' AND {2}='{3}' AND {4}={5}", _
                                     WS_INS_ID, strINSID, _
                                     WS_BATCH_ID, strBatch, _
                                     WS_COMPANY_ID, nCompanyID)
        strOrder = String.Format("{0} {1}, {2} {1}", WS_INS_ID, DBCONSTDEF_SQL_ASCEND, WS_EXPIRE_DATE)
        strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE_ORDER, DBCONSTDEF_SQL_SELECT_ALL, TBL_WAREHOUSE_STOCK, strCondition, strOrder)
        Dim ds As New DataSet()
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If ds.Tables(0).Rows.Count = 0 Then
            ds.Dispose()
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        End If

        If ds.Tables(0).Rows.Count > 1 Then
            ds.Dispose()
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_EXIST_OVERFLOW, TBL_WAREHOUSE_STOCK, m_oDBConnect.GetCommandString)
            Logger.WriteLine(m_strErrorReason, EVENT_ENTRY_TYPE.ERRORR)
            Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
        End If

        dtExpried = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(WS_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
        Return DBMEDITS_RESULT.SUCCESS
    End Function


    Public Function QueryWareHouseINSInOut(ByRef dtWareHouseINS As DataTable, ByVal dtimeStart As DateTime, ByVal dtimeEnd As DateTime, _
                                                  ByVal lstType As List(Of SR_LOG_INOUT_TYPE)) As Long
        dtWareHouseINS.Clear()
        Dim strCols, strDateCon, strCondition, strTables, strTablesHistory, strSqlHistory As String
        strTablesHistory = String.Empty
        strSqlHistory = String.Empty
        Dim strSql As String = String.Empty
        Dim bHistory As Boolean = False

        For Each eType As SR_LOG_INOUT_TYPE In lstType
            strDateCon = String.Format("({0} BETWEEN to_date('{1}','{3}') AND to_date('{2}','{3}'))", SAI_DATETIME, dtimeStart.Date, dtimeEnd.AddDays(1).Date, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)
            strCondition = String.Format("{0}={1} AND {2}", _
                                          SAI_TYPE, CShort(eType), _
                                          strDateCon)

            Select Case eType
                Case SR_LOG_INOUT_TYPE.WH_IN, SR_LOG_INOUT_TYPE.WH_IN_BALANCE, SR_LOG_INOUT_TYPE.WH_OUT_BALANCE, SR_LOG_INOUT_TYPE.WH_OUT_EXPIRED, _
                    SR_LOG_INOUT_TYPE.WH_OUT_OTHER, SR_LOG_INOUT_TYPE.INS_EXPRIED_OUT, SR_LOG_INOUT_TYPE.INS_USE_OUT, _
                    SR_LOG_INOUT_TYPE.HV_IN_STOCK, SR_LOG_INOUT_TYPE.HV_OUT_BACK, SR_LOG_INOUT_TYPE.HV_OUT_DISPATCH

                    strCols = String.Format("{0} as {1},{2} as {3},{4} as {5},{6} as {7},{8} as {9},{10}", _
                                            SIM_ID, TEXT_STERILIZEROOM_INS_INOUT_NO, _
                                            SIM_TYPE, TEXT_STERILIZEROOM_INS_INOUT_TYPE, _
                                            SAI_SF_ID, TEXT_STERILIZEROOM_INS_INOUT_STAFF_ID, _
                                            SAI_SF_NAME, TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME, _
                                            SAI_DATETIME, TEXT_STERILIZEROOM_INS_INOUT_REG_TIME, _
                                            SIM_REG_ID)
                    strTables = String.Format("{0} inner join {1} on {2} = {3}", _
                                            LOG_STOREROOM_INOUT_MASTER, LOG_STOREROOM_ABNORMAL_INOUT, _
                                            SIM_REG_ID, SAI_ID)
                    strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE_ORDER, strCols, strTables, strCondition, SIM_DATETIME)
                Case Else
                    Return DBMEDITS_RESULT.ERROR_PARAMETER
            End Select
            Dim ds As New DataSet()
            If Not QueryOleDb(strSql, ds) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString + m_oDBConnect.GetCommandString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim drNew As DataRow = dtWareHouseINS.NewRow
                drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_NO) = CLng(JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_NO), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
                drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_TYPE) = MatchStelizeRoomINSInOutTypeToString(CType((JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_TYPE), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)), SR_LOG_INOUT_TYPE))
                drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_TYPE_ID) = CLng(JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_TYPE), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
                drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_STAFF_ID) = CStr(JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_STAFF_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
                drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
                drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_REG_TIME) = CDate(JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_REG_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE_TIME)
                drNew.Item(SIM_REG_ID) = CLng(JudgeDataValue(dr.Item(SIM_REG_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
                dtWareHouseINS.Rows.Add(drNew)
            Next
            ds.Dispose()
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryWareHouseInOutDetail(ByRef dtSterilizeRoomINSDetail As DataTable, ByVal dtimeStart As DateTime, ByVal dtimeEnd As DateTime, _
                                                   ByVal eType As SR_LOG_INOUT_TYPE, ByVal strINSID As String, Optional ByVal lRegID As Long = -1) As Long
        dtSterilizeRoomINSDetail.Clear()

        Dim strCols, strSql, strTables, strDateCon As String
        Dim strCondition As String = String.Empty

        strDateCon = String.Format(" and ({0} BETWEEN to_date('{1}','{3}') AND to_date('{2}','{3}'))", SIM_DATETIME, dtimeStart.Date, dtimeEnd.AddDays(1).Date, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)

        Select Case eType
            Case SR_LOG_INOUT_TYPE.WH_IN, SR_LOG_INOUT_TYPE.WH_IN_BALANCE, _
                SR_LOG_INOUT_TYPE.WH_OUT_BALANCE, SR_LOG_INOUT_TYPE.WH_OUT_EXPIRED, SR_LOG_INOUT_TYPE.WH_OUT_OTHER

                strCondition = String.Format(" {0}={1}", SIM_TYPE, CShort(eType))
                If lRegID <> -1 Then
                    strCondition += String.Format(" and {0}={1}", SAID_REG_ID, lRegID)
                End If

                If Not String.IsNullOrEmpty(strINSID) Then
                    strCondition += String.Format("and {0}='{1}'", SAID_INS_ID, strINSID)
                End If

                strCondition += strDateCon
                strCols = String.Format(" distinct {0} as {1},{2} as {3},{4} as {5},{6} as {7},{8} as {9},{10} as {11},{12} as {13},{14} as {15},{16} as {17},{18} as {19}", _
                                        SAID_INS_ID, TEXT_INS_ID, _
                                        SAID_INS_NAME, TEXT_INS_NAME, _
                                        SAID_INS_TYPE, TEXT_INS_TYPE, _
                                        SAID_INS_UNIT, TEXT_UNIT, _
                                        SAID_COUNT, TEXT_COUNT, _
                                        SAID_COMPANY_NAME, TEXT_PRODUCE_COMPANY, _
                                        SAID_BATCH_ID, TEXT_INS_BATCH, _
                                        SAID_EXPIRE_DATE, TEXT_EXPIRE_DATE, _
                                        SAI_SF_NAME, TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME, _
                                        SAI_DATETIME, TEXT_STERILIZEROOM_INS_INOUT_REG_TIME)
                strTables = String.Format(" {0} INNER JOIN {1} ON {2} = {3} INNER JOIN {4} ON {5} = {6} INNER JOIN {7} ON {8} = {9}", _
                                            LOG_STOREROOM_INOUT_MASTER, LOG_STOREROOM_ABNORMAL_INOUT, SIM_REG_ID, SAI_ID, _
                                            LOG_ABNORMAL_INOUT_DETAIL, SAID_REG_ID, SAI_ID, _
                                            MST_INSTRUMENT_INFO, SAID_INS_ID, INS_CODE)
                strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE_ORDER, strCols, strTables, strCondition, SAID_INS_ID)
            Case Else
                Return DBMEDITS_RESULT.ERROR_PARAMETER
        End Select

        Dim ds As New DataSet()
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If ds.Tables(0).Rows.Count = 0 Then Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dtSterilizeRoomINSDetail.NewRow
            drNew.Item(TEXT_INS_ID) = CStr(JudgeDataValue(dr.Item(TEXT_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_TYPE) = CStr(JudgeDataValue(dr.Item(TEXT_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_UNIT) = CStr(JudgeDataValue(dr.Item(TEXT_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_COUNT) = CInt(JudgeDataValue(dr.Item(TEXT_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_PRODUCE_COMPANY) = CStr(JudgeDataValue(dr.Item(TEXT_PRODUCE_COMPANY), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_BATCH) = CStr(JudgeDataValue(dr.Item(TEXT_INS_BATCH), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_EXPIRE_DATE) = CDate(JudgeDataValue(dr.Item(TEXT_EXPIRE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
            drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_STERILIZEROOM_INS_INOUT_REG_TIME) = CDate(JudgeDataValue(dr.Item(TEXT_STERILIZEROOM_INS_INOUT_REG_TIME), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE_TIME)
            dtSterilizeRoomINSDetail.Rows.Add(drNew)
        Next

        ds.Dispose()
        Return DBMEDITS_RESULT.SUCCESS
    End Function
End Class
