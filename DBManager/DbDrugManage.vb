Imports ITSBase
Imports ITSBase.Accessory
Imports DBAdapter

Public Class DbDrugManage
    Inherits DbOperateSummery

    Public Function CommitDrugIn(ByVal drugTable As DataTable, user As UserInfo) As EnumDef.DBMEDITS_RESULT
        If drugTable.IsNullOrEmpty() Then Return DBMEDITS_RESULT.ERROR_PARAMETER

        Dim lRegID As Long = CONST_INVALID_DATA
        If Not QueryNextVal(lRegID, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '保存记录到非正常出入库日志表
        Dim strSQL, strCondition, strCols, strValues, strJudge, strSqlInsert, strSqlUpdate As String
        For Each dr As DataRow In drugTable.Rows
            Dim strINSID As String = JudgeDataValue(dr.Item(TEXT_DRUG_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            Dim strBatch As String = JudgeDataValue(dr.Item(TEXT_DRUG_BATCHNO), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            Dim nCount As Integer = JudgeDataValue(dr.Item(TEXT_DRUG_AMOUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            strCondition = String.Format("{0}='{1}' AND {2}='{3}'", _
                                     DRS_DRUG_CODE, strINSID, DRS_BATCH_ID, strBatch)

            strJudge = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DRS_DRUG_CODE, TBL_DRUG_STOCK, strCondition)

            strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", _
                               DRS_DRUG_CODE, DRS_DRUG_COMMON_NAME, DRS_DRUG_PRODUCT_NAME, DRS_MEASUER_UNITS, _
                               DRS_MANUFACTURERS, DRS_SPECIFICATION, DRS_DRUG_COUNT, DRS_DRUG_UNIT, DRS_PRODUCE_DATE, DRS_BATCH_ID, DRS_AVAILABLE_DATE)
            strValues = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}',to_date('{8}','{11}'),'{9}',to_date('{10}','{11}')", _
                                     strINSID, _
                                    CStr(JudgeDataValue(dr.Item(TEXT_DRUG_COMMON_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_DRUG_PRODUCT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_DRUG_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_DRUG_FACTORY), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_DRUG_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CInt(JudgeDataValue(dr.Item(TEXT_DRUG_AMOUNT), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CStr(JudgeDataValue(dr.Item(TEXT_DRUG_STOCK_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CDate(JudgeDataValue(dr.Item(TEXT_DRUG_MFG), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                                     CStr(JudgeDataValue(dr.Item(TEXT_DRUG_BATCHNO), ENUM_DATA_TYPE.DATA_TYPE_STRING)), _
                                    CDate(JudgeDataValue(dr.Item(TEXT_DRUG_EXPIRE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                                     CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
            strSqlInsert = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_DRUG_STOCK, strCols, strValues)

            strValues = String.Format("{0}={0}+{1}", DRS_DRUG_COUNT, nCount)
            strSqlUpdate = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_DRUG_STOCK, _
                                     strValues, strCondition)

            strSQL = String.Format(DBCONSTDEF_ORACLE_SELECT_INSERT_UPDATE, TBL_DRUG_STOCK, strJudge, strSqlUpdate, strSqlInsert)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next

        If Not ImplementSterileRoomAbnormalInOutLog(EnumDef.SR_LOG_INOUT_TYPE.DRUG_IN, lRegID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not ImplementDrugAbnormalDetailLog(lRegID, drugTable) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not ImplementSterileRoomInOutLog(SR_LOG_INOUT_TYPE.DRUG_IN, lRegID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Public Function GetStockAmount(ByRef stockAmount As Long, code As String, ByVal strBatch As String) As Boolean
        stockAmount = 0
        Dim querySql = String.Format("Select DRS_PACK_COUNT From TBL_DRUG_STOCK Where DRS_DRUG_CODE='{0}' and {1}='{2}'", code, DRS_BATCH_ID, strBatch)
        Dim queryTbl As New DataTable
        QueryTable(querySql, queryTbl)
        If Not queryTbl.IsNullOrEmpty() Then
            stockAmount = Judgement.JudgeDBNullValue(queryTbl.Rows(0).Item(DRS_PACK_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
        End If
        Return True
    End Function

    Public Function CommitDrugOut(ByVal drugTable As DataTable, user As UserInfo, outType As SR_LOG_INOUT_TYPE) As EnumDef.DBMEDITS_RESULT
        If drugTable.IsNullOrEmpty() Then Return DBMEDITS_RESULT.ERROR_PARAMETER

        '保存记录到非正常出入库日志表
        Dim lRegID As Long = CONST_INVALID_DATA
        If Not QueryNextVal(lRegID, SEQ_STOREROOM_ABNORMAL_INOUT) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        For Each drugRow In drugTable.Rows
            Dim id As String = drugRow.Item(TEXT_DRUG_ID)
            Dim common = drugRow.Item(TEXT_DRUG_COMMON_NAME)
            Dim product = drugRow.Item(TEXT_DRUG_PRODUCT_NAME)
            Dim unit = drugRow.Item(TEXT_DRUG_UNIT)
            Dim factory = drugRow.Item(TEXT_DRUG_FACTORY)
            Dim spec = drugRow.Item(TEXT_DRUG_SPECIFICATION)
            Dim mfg = drugRow.Item(TEXT_DRUG_MFG)
            Dim batch = drugRow.Item(TEXT_DRUG_BATCHNO)
            Dim expire = drugRow.Item(TEXT_DRUG_EXPIRE)
            Dim count As Integer = Integer.Parse(drugRow.Item(TEXT_DRUG_AMOUNT))
            '保存药品库存表

        Next

        '插入非正常入出库日志
        If Not ImplementSterileRoomAbnormalInOutLog(outType, lRegID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '插入飞正常入出库详细
        If Not ImplementDrugAbnormalDetailLog(lRegID, drugTable) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '插入出入库主表
        If Not ImplementSterileRoomInOutLog(outType, lRegID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function CheckDrugExistValid(ByRef dtExpried As Date, ByVal strDrugID As String, ByVal strBatch As String) As Long
        Dim strSQL, strCon As String
        strCon = String.Format("{0}='{1}' andalso {2}='{3}'", DRS_DRUG_CODE, strDrugID, DRS_BATCH_ID, strBatch)
        strSQL = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, TBL_DRUG_STOCK, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQL, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables.Count < 1 OrElse ds.Tables(0).Rows.Count < 1 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        End If
        If ds.Tables(0).Rows.Count > 1 Then
            Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
        End If
        dtExpried = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(DRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Public Function CheckBatchAndExpried(ByRef dtExpried As Date, ByVal strDrugID As String, ByVal strBatch As String) As Long
        Dim strSQL, strCon As String
        strCon = String.Format("{0}='{1}' and {2}='{3}'", DSAID_DRUG_CODE, strDrugID, DSAID_BATCH_ID, strBatch)
        strSQL = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DSAID_AVAILABLE_DATE, TBL_DRUG_STOCK, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQL, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count < 1 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        ElseIf ds.Tables(0).Rows.Count > 1 Then
            Logger.WriteLine(String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_EXIST_OVERFLOW, TBL_DRUG_STOCK, m_oDBConnect.GetErrorString))
            Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
        Else
            dtExpried = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(DSAID_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE)
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryDrugStockTotal(ByVal dt As DataTable) As Long
        dt.Clear()
        Dim strSQl As String
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_ORDER_ASC, DBCONSTDEF_SQL_SELECT_ALL, TBL_DRUG_STOCK, DRS_DRUG_CODE)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_DRUG_ID) = JudgeDataValue(dr.Item(DRS_DRUG_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_COMMON_NAME) = JudgeDataValue(dr.Item(DRS_DRUG_COMMON_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_PRODUCT_NAME) = JudgeDataValue(dr.Item(DRS_DRUG_PRODUCT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_FACTORY) = JudgeDataValue(dr.Item(DRS_MANUFACTURERS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_SPECIFICATION) = JudgeDataValue(dr.Item(DRS_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_STOCK_UNIT) = JudgeDataValue(dr.Item(DRS_DRUG_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_UNIT) = JudgeDataValue(dr.Item(DRS_MEASUER_UNITS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_MFG) = CDate(JudgeDataValue(dr.Item(DRS_PRODUCE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            drNew.Item(TEXT_DRUG_EXPIRE) = CDate(JudgeDataValue(dr.Item(DRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            drNew.Item(DRS_ID) = CLng(JudgeDataValue(dr.Item(DRS_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_DRUG_AMOUNT) = CLng(JudgeDataValue(dr.Item(DRS_DRUG_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_DRUG_BATCHNO) = CStr(JudgeDataValue(dr.Item(DRS_BATCH_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryDrugStockTotalDetail(ByVal dt As DataTable) As Long
        dt.Clear()
        Dim strSQl As String
        Dim strCols As String = String.Format("{0}，{1}，{2}，{3}，{4}，{5}，{6}，Sum{7} as {7},{8}", _
                                              DRS_DRUG_CODE, DRS_DRUG_COMMON_NAME, DRS_DRUG_PRODUCT_NAME, DRS_SPECIFICATION, DRS_MEASUER_UNITS, _
                                              DRS_MANUFACTURERS, DRS_DRUG_COUNT, DRS_DRUG_UNIT)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_ORDER_ASC, DBCONSTDEF_SQL_SELECT_ALL, TBL_DRUG_STOCK, DRS_DRUG_CODE)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_DRUG_ID) = JudgeDataValue(dr.Item(DRS_DRUG_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_COMMON_NAME) = JudgeDataValue(dr.Item(DRS_DRUG_COMMON_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_PRODUCT_NAME) = JudgeDataValue(dr.Item(DRS_DRUG_PRODUCT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_FACTORY) = JudgeDataValue(dr.Item(DRS_MANUFACTURERS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_SPECIFICATION) = JudgeDataValue(dr.Item(DRS_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_STOCK_UNIT) = JudgeDataValue(dr.Item(DRS_DRUG_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_UNIT) = JudgeDataValue(dr.Item(DRS_MEASUER_UNITS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
            drNew.Item(TEXT_DRUG_AMOUNT) = CLng(JudgeDataValue(dr.Item(DRS_DRUG_COUNT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_DRUG_BATCHNO) = CStr(JudgeDataValue(dr.Item(DRS_BATCH_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
End Class
