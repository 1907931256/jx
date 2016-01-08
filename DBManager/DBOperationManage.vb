Imports ITSBase
Imports DBAdapter
Imports ITSBase.Accessory

Public Class DbOperationManage
    Inherits DbOperateSummery

    Public Function QueryTotalOperationRoom(ByRef operationRoom As DataTable) As EnumDef.DBMEDITS_RESULT
        Dim lRet As DBMEDITS_RESULT = QueryTotal(operationRoom, DIC_OPERATING_ROOM)
        If lRet <> DBMEDITS_RESULT.SUCCESS Then
            Return lRet
        End If

        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryTotalReason(ByRef dt As DataTable) As Long
        Dim strSQL = String.Format(DBCONSTDEF_SQL_SELECT, DBCONSTDEF_SQL_SELECT_ALL, MST_PACKAGE_CHECK_REASON)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQL, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_ID) = CLng(JudgeDataValue(dr.Item(PCR_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_REASON) = CStr(JudgeDataValue(dr.Item(PCR_REASON), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QuerySurgeryNoteInfo(ByRef tableSureryNote As DataTable, startTime As String, endTime As String, surRoomId As String, ByVal ParamArray arrStatus() As OPerationNoteState) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0},{1} As {2},{3} As {4},{5} As {6},{7} As {8},{9} As {10},{11} As {12},{13} As {14},{15} As {16},{17} As {18},{19} As {20},{21} As {22},{23} As {24},{25} As {26}, {27},{28} AS {29}，{30}", _
                    OPN_ID, OPN_VISIT_ID, TEXT_VISIT_ID, OPN_PATIENT_NAME, TEXT_PATIENT_NAME, OPN_GENDER, TEXT_GENDER, OPN_AGE, TEXT_AGE, OPN_OPERATION_NAME, TEXT_OPERATION_NAME, _
                    OPN_ORDER_DATE, TEXT_ORDER_DATE, ROOM_NAME, TEXT_ROOM_NAME, OPN_TABLE_ID, TEXT_TABLE_ID, TRUE_NAME, TEXT_DOCTOR_NAME, FULL_NAME, TEXT_DEPARTMENT_NAME, _
                    OPN_WEIGHT, TEXT_WEIGHT, OPN_DIAGNOSIS, TEXT_DIAGNOSIS, OPN_DR_MEMO, TEXT_DR_MEMO, OPN_OPERATION_ID, OPN_OPERATION_STATUS, TEXT_OPERATION_STATUS, OPN_ROOM_ID)
        Dim leftJoin As String = String.Format(" Left Join {0} On {1}={2}", DIC_USER_INFO, USER_CODE, OPN_DOCTOR_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_DEPT_INFO, DEPT_ID, OPN_DEPARTMENT_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATING_ROOM, ROOM_ID, OPN_ROOM_ID)
        'leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATION, OPERATION_CODE, OPN_OPERATION_ID)
        Dim condition As String = String.Format("{0} BETWEEN　to_date('{1}','{3}') AND to_date('{2}','{3}')", OPN_ORDER_DATE, startTime, endTime, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)
        If Not String.IsNullOrEmpty(surRoomId) Then
            condition += String.Format(" AND {0}='{1}'", OPN_ROOM_ID, surRoomId)
        End If
        Dim statusCondition As String = CreateArrayCondition(OPN_OPERATION_STATUS, SqlDbType.SmallInt, True, arrStatus)
        If Not String.IsNullOrEmpty(statusCondition) Then
            condition = String.Format("{0} and {1}", condition, statusCondition)
        End If
        Dim orderBy As String = String.Format("{0}", TEXT_ORDER_DATE)
        Dim strSql = String.Format("Select {0} From {1} {2} Where {3} Order By {4}", columns, TBL_OPERATION_NOTE, leftJoin, condition, orderBy)
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = tableSureryNote.NewRow
            drNew.Item(OPN_ID) = CLng(JudgeDataValue(dr.Item(OPN_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_VISIT_ID) = CStr(JudgeDataValue(dr.Item(TEXT_VISIT_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_PATIENT_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_PATIENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_GENDER) = IIf(CStr(JudgeDataValue(dr.Item(TEXT_GENDER), ENUM_DATA_TYPE.DATA_TYPE_STRING)).Equals("1"), "男", "女")
            drNew.Item(TEXT_AGE) = CStr(JudgeDataValue(dr.Item(TEXT_AGE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_OPERATION_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_OPERATION_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_ORDER_DATE) = CStr(JudgeDataValue(dr.Item(TEXT_ORDER_DATE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(OPN_ROOM_ID) = CLng(JudgeDataValue(dr.Item(OPN_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_ROOM_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_ROOM_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_TABLE_ID) = CStr(JudgeDataValue(dr.Item(TEXT_TABLE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_DOCTOR_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_DOCTOR_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_DEPARTMENT_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_DEPARTMENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_WEIGHT) = CStr(JudgeDataValue(dr.Item(TEXT_WEIGHT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_DIAGNOSIS) = CStr(JudgeDataValue(dr.Item(TEXT_DIAGNOSIS), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_DR_MEMO) = CStr(JudgeDataValue(dr.Item(TEXT_DR_MEMO), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(OPN_OPERATION_ID) = CStr(JudgeDataValue(dr.Item(OPN_OPERATION_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_OPERATION_STATUS) = MatchNoteStatusToString(CInt(JudgeDataValue(dr.Item(TEXT_OPERATION_STATUS), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)))
            tableSureryNote.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function InsertRequestList(ByVal dt As DataTable) As Long
        For Each dr As DataRow In dt.Rows
            Dim oSurvery As SurgeryNoteInfo = New SurgeryNoteInfo
            oSurvery.TransFromDataRow(dr)
            Dim strSurveryID As String = CStr(JudgeDataValue(dr.Item(OPN_OPERATION_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            Dim dtDrugDefault As DataTable = New DataTable
            If QueryDrugPredefineDetail(dtDrugDefault, strSurveryID) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
                Logger.WriteLine(m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            Dim dtINSDefault As DataTable = New DataTable
            If QueryInstrumentPredefineDetail(dtINSDefault, strSurveryID) = DBMEDITS_RESULT.ERROR_EXCEPTION Then
                Logger.WriteLine(m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            Dim lRequestID As Long = -1
            If Not QueryNextVal(lRequestID, SEQ_TBL_OPER_REQUEST_MASTER) Then
                Logger.WriteLine(m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            If Not CommitSurgeryRequestMaster(oSurvery, dtDrugDefault, dtINSDefault) = DBMEDITS_RESULT.SUCCESS Then
                Logger.WriteLine(m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QuerySurgeryInfoByID(ByRef oSurvery As SurgeryNoteInfo, ByVal lOPN_ID As Long) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0},{1} As {2},{3} As {4},{5} As {6},{7} As {8},{9} As {10},{11} As {12},{13} As {14},{15} As {16},{17} As {18},{19} As {20},{21} As {22},{23} As {24},{25} As {26}, {27},{28} AS {29}", _
                    OPN_ID, OPN_VISIT_ID, TEXT_VISIT_ID, OPN_PATIENT_NAME, TEXT_PATIENT_NAME, OPN_GENDER, TEXT_GENDER, OPN_AGE, TEXT_AGE, OPERATION_NAME, TEXT_OPERATION_NAME, _
                    OPN_ORDER_DATE, TEXT_ORDER_DATE, ROOM_NAME, TEXT_ROOM_NAME, OPN_TABLE_ID, TEXT_TABLE_ID, TRUE_NAME, TEXT_DOCTOR_NAME, FULL_NAME, TEXT_DEPARTMENT_NAME, _
                    OPN_WEIGHT, TEXT_WEIGHT, OPN_DIAGNOSIS, TEXT_DIAGNOSIS, OPN_DR_MEMO, TEXT_DR_MEMO, OPN_OPERATION_ID, OPN_OPERATION_STATUS, TEXT_OPERATION_STATUS)
        Dim leftJoin As String = String.Format(" Left Join {0} On {1}={2}", DIC_USER_INFO, USER_CODE, OPN_DOCTOR_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_DEPT_INFO, DEPT_ID, OPN_DEPARTMENT_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATING_ROOM, ROOM_ID, OPN_ROOM_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATION, OPERATION_CODE, OPN_OPERATION_ID)
        
        Dim condition = String.Format("{0}={1}", OPN_ID, lOPN_ID)
        Dim strSql = String.Format("Select {0} From {1} {2} Where {3}", columns, TBL_OPERATION_NOTE, leftJoin, condition)
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count = 1 Then
            oSurvery.Id = CLng(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            oSurvery.VisitId = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_VISIT_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.PatName = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_PATIENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.Gender = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_GENDER), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.Age = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_AGE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.SurName = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_OPERATION_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.OrderDate = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_ORDER_DATE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.Room = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_ROOM_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.Table = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_TABLE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.Surgeon = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_DOCTOR_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.Diagnosis = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_DIAGNOSIS), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.Memo = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_DR_MEMO), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.SurId = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_OPERATION_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurvery.NoteStatus = MatchNoteStatusToString(CInt(JudgeDataValue(ds.Tables(0).Rows(0).Item(TEXT_OPERATION_STATUS), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)))
        ElseIf ds.Tables(0).Rows.Count < 1 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        Else
            Return DBMEDITS_RESULT.EXIST_OVERFLOW
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QuerySurgeryNoteList(ByRef tableSureryNote As DataTable, startTime As String, endTime As String, surRoomId As String, ByVal ParamArray arrStatus() As OPerationNoteState) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0},{1} as {2}, {3} as {4}", _
                    OPN_ID, OPN_PATIENT_NAME, TEXT_PATIENT_NAME, OPN_OPERATION_ID, TEXT_OPERATION_NAME)
        Dim leftJoin As String = String.Format(" Left Join {0} On {1}={2}", DIC_USER_INFO, USER_CODE, OPN_DOCTOR_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_DEPT_INFO, DEPT_ID, OPN_DEPARTMENT_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATING_ROOM, ROOM_ID, OPN_ROOM_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATION, OPERATION_CODE, OPN_OPERATION_ID)
        Dim condition As String = String.Format("{0} BETWEEN　to_date('{1}','{3}') AND to_date('{2}','{3}')", OPN_ORDER_DATE, startTime, endTime, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)
        If Not String.IsNullOrEmpty(surRoomId) Then
            condition += String.Format(" AND {0}='{1}'", OPN_ROOM_ID, surRoomId)
        End If
        condition = String.Format("{0} and {1}", condition, CreateArrayCondition(OPN_OPERATION_STATUS, SqlDbType.SmallInt, True, arrStatus))
        Dim orderBy As String = String.Format("{0}", TEXT_ORDER_DATE)
        Dim strSql = String.Format("Select {0} From {1} {2} Where {3} Order By {4}", columns, TBL_OPERATION_NOTE, leftJoin, condition, orderBy)
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = tableSureryNote.NewRow
            drNew.Item(OPN_ID) = CLng(JudgeDataValue(dr.Item(OPN_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            drNew.Item(TEXT_PATIENT_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_PATIENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))    
            drNew.Item(TEXT_OPERATION_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_OPERATION_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            tableSureryNote.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Public Function QueryDrugRequestDetail(ByRef drugRequest As DataTable, ByVal surNoteId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0} as {1}, {2} as {3}, {4} as {5}, {6} as {7}, {8} as {9}, {10} as {11},{12}", DRD_COMMON_NAME, TEXT_DRUG_COMMON_NAME, _
                        DRD_PRODUCT_NAME, TEXT_DRUG_PRODUCT_NAME, DRD_DRUG_SPEC, TEXT_DRUG_SPECIFICATION, DRD_DRUG_FACTORY, TEXT_DRUG_FACTORY, _
                        DRD_MEASUER_UNITS, TEXT_DRUG_UNIT, DRD_PACK_COUNT, TEXT_DRUG_AMOUNT, DRD_DRUG_ID)
        Dim tableJoin As String = String.Format("{0},{1},{2}", TBL_DRUG_REQUEST_DETAIL, TBL_OPERATION_REQUEST_MASTER, TBL_OPERATION_NOTE)
        Dim where As String = String.Format("{0}={1} AND {2}={3} AND {3}='{4}'", DRD_REG_ID, DR_ID, DR_OPN_REG_ID, OPN_ID, surNoteId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, tableJoin, where)
        Return QueryTable(querySql, drugRequest)
    End Function

    Public Function QueryRequestMasterInfoByNoteId(ByRef tableReqMaster As DataTable, ByVal noteId As String) As Long
        Dim columns As String = String.Format("{0},{1},{2},{3}", DR_ID, DR_OPN_REG_ID, DR_ROOM_NAME, DR_TABLE_ID)
        Dim where As String = String.Format("{0}='{1}'", DR_OPN_REG_ID, noteId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, TBL_OPERATION_REQUEST_MASTER, where)
        Return QueryTable(querySql, tableReqMaster)
    End Function

    Public Function QueryUseMasterInfoByNoteId(ByRef tableReqMaster As DataTable, ByVal noteId As String) As Long
        Dim columns As String = String.Format("{0},{1},{2}", UM_ID, UM_OPN_REG_ID, UM_USE_DATE)
        Dim where As String = String.Format("{0}='{1}'", UM_OPN_REG_ID, noteId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, TBL_OPERATION_USE_MASTER, where)
        Return QueryTable(querySql, tableReqMaster)
    End Function

    Public Function QueryFrontUseInfoByNoteId(ByRef lstPackageCheck As List(Of PackageCheck), ByVal noteId As String, ByVal eType As CHECK_TYPE) As Long
        Dim where As String = String.Format("{0}='{1}' and {2}={3}", ODUM_NOTE_ID, noteId, ODUM_TYPE, CStr(eType))

        Dim strTable As String = String.Format("{0} inner join {1} on {2}={3}", TBL_OPERATION_FRONT_USE_MASTER, TBL_FRONT_USE_INS_DETAIL, ODUM_ID, FUID_REG_ID)
        Dim strCols As String = String.Format("{0},{1},{2},{3},{4},{5},{6}", FUID_PACKAGE_ID, FUID_INS_ID, FUID_INS_NAME, FUID_INS_TYPE, _
                                              FUID_INS_UNIT, FUID_RESULT, FUID_REASON)
        Dim querySql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, strCols, strTable, where)
        Dim ds As New DataSet
        If Not QueryOleDb(querySql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oPackgeCheck As PackageCheck = New PackageCheck
            oPackgeCheck.m_oPackageInfo.m_lPackageID = CLng(JudgeDataValue(dr.Item(FUID_PACKAGE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackgeCheck.m_oPackageInfo.m_strINSID = CStr(JudgeDataValue(dr.Item(FUID_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackgeCheck.m_oPackageInfo.m_strINSName = CStr(JudgeDataValue(dr.Item(FUID_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackgeCheck.m_oPackageInfo.m_strINSType = CStr(JudgeDataValue(dr.Item(FUID_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackgeCheck.m_oPackageInfo.m_strINSUnit = CStr(JudgeDataValue(dr.Item(FUID_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackgeCheck.m_nResult = CStr(JudgeDataValue(dr.Item(FUID_RESULT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackgeCheck.m_strReason = CStr(JudgeDataValue(dr.Item(FUID_REASON), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            lstPackageCheck.Add(oPackgeCheck)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Public Function QueryDrugPredefineDetail(ByRef drugRequest As DataTable, ByVal surId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0} as {1}, {2} as {3}, {4} as {5}, {6} as {7}, {8} as {9}, {10} as {11},{12} as {13}", OPDD_COMMON_NAME, TEXT_DRUG_COMMON_NAME, _
                        OPDD_PRODUCT_NAME, TEXT_DRUG_PRODUCT_NAME, OPDD_DRUG_SPEC, TEXT_DRUG_SPECIFICATION, OPDD_DRUG_FACTORY, TEXT_DRUG_FACTORY, _
                        OPDD_MEASUER_UNITS, TEXT_DRUG_UNIT, OPDD_AMOUNT, TEXT_DRUG_AMOUNT, OPDD_DRUG_CODE, TEXT_DRUG_ID)
        Dim tableJoin As String = String.Format("{0},{1}", MST_OPERATION_DRUG_DETAIL, TBL_OPERATION_NOTE)
        'Dim where As String = String.Format("{0}={1} AND {1}='{2}'", OPDD_REG_ID, OPN_OPERATION_ID, surId)

        Dim where As String = String.Format("{0}='{1}'", OPDD_REG_ID, surId)

        Dim querySql = String.Format("Select distinct  {0} From {1} Where {2}", columns, MST_OPERATION_DRUG_DETAIL, where)
        Return QueryTable(querySql, drugRequest)
    End Function

    Public Function QueryInstrumentRequestDetail(ByRef insRequest As DataTable, ByVal surNoteId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0} as {1}, {2} as {3}, {4} as {5}, {6} as {7}, {8} as {9}", IRD_CODE, TEXT_INS_CODE, IRD_NAME, TEXT_INS_NAME, _
                        IRD_SPEC, TEXT_INS_SPECIFICATION, IRD_UNIT, TEXT_INS_UNIT, IRD_COUNT, TEXT_INS_AMOUNT)
        Dim tableJoin As String = String.Format("{0},{1},{2}", TBL_INS_REQUEST_DETAIL, TBL_OPERATION_REQUEST_MASTER, TBL_OPERATION_NOTE)
        Dim where As String = String.Format("{0}={1} AND {2}={3} AND {3}='{4}'", IRD_REG_ID, DR_ID, DR_OPN_REG_ID, OPN_ID, surNoteId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, tableJoin, where)
        Return QueryTable(querySql, insRequest)
    End Function

    Public Function QueryInstrumentPredefineDetail(ByRef insRequest As DataTable, ByVal surId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0} as {1}, {2} as {3}, {4} as {5}, {6} as {7}, {8} as {9}", INS_CODE, TEXT_INS_CODE, INS_NAME, TEXT_INS_NAME, _
                        INS_SPEC, TEXT_INS_SPECIFICATION, INS_UNIT, TEXT_INS_UNIT, OPID_INS_COUNT, TEXT_INS_AMOUNT)
        Dim tableJoin As String = String.Format("{0},{1}", MST_OPERATION_INS_DETAIL, MST_INSTRUMENT_INFO)
        Dim where As String = String.Format("{0}={1} AND {2}='{3}'", OPID_INS_ID, INS_CODE, OPID_REG_ID, surId)

        'Dim tableJoin As String = String.Format("{0},{1},{2}", MST_OPERATION_INS_DETAIL, TBL_OPERATION_NOTE, MST_INSTRUMENT_INFO)
        'Dim where As String = String.Format("{0}={1} AND {2}={3} AND {3}='{4}'", OPID_INS_ID, INS_CODE, OPID_REG_ID, OPN_OPERATION_ID, surId)
        Dim querySql = String.Format("Select distinct  {0} From {1} Where {2}", columns, tableJoin, where)
        Return QueryTable(querySql, insRequest)
    End Function

    Public Function QueryDrugInfo(ByRef drugInfo As DataTable) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7},{8},{9}", DRUG_CODE, DRUG_COMMON_NAME, DRUG_COMMON_NAME_INPUTCODE, DRUG_PRODUCT_NAME, _
                        DRUG_PRODUCT_NAME_INPUTCODE, DRUG_SPECIFICATION, DRUG_MANUFACTURERS, DRUG_MEASUER_UNITS, DRUG_UNITS, DRUG_TO_PACK_CONVERSION_RATIO)
        Dim querySql = String.Format("Select {0} From {1} Order By {2}", columns, MST_DRUG_INFO, DRUG_COMMON_NAME)

        Return QueryTable(querySql, drugInfo)
    End Function

    Public Function QueryInstrumentInfo(ByRef insInfo As DataTable) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", INS_CODE, INS_TYPE, INS_CODE, INS_NAME, _
                                                INS_PRODUCT_NAME, INS_NAME_INPUTCODE, INS_SPEC, INS_UNIT)
        Dim querySql = String.Format("Select {0} From {1} Order By {2}", columns, MST_INSTRUMENT_INFO, INS_NAME)
        Return QueryTable(querySql, insInfo)
    End Function

    Public Function QuerySurgeryDrugUseTable(ByRef drugInfo As DataTable, useRegId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0}, {1}, {2} As {3}, {4} As {5}, {6} As {7}, {8} As {9}, {10} As {11}, {12} As {13}, {14} As {15}", DUD_ID, DUD_REG_ID, DUD_COMMON_NAME, TEXT_DRUG_COMMON_NAME, _
                                                 DUD_PRODUCT_NAME, TEXT_DRUG_PRODUCT_NAME, DUD_DRUG_SPEC, TEXT_DRUG_SPECIFICATION, DUD_DRUG_FACTORY, TEXT_DRUG_FACTORY, _
                                                 DUD_MEASUER_UNITS, TEXT_INS_UNIT, DUD_PACK_COUNT, TEXT_DRUG_AMOUNT, DUD_STATUS, TEXT_DRUG_STATUS)
        Dim where = String.Format("{0}='{1}'", DUD_REG_ID, useRegId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, TBL_DRUG_USE_DETAIL, where)
        Return QueryTable(querySql, drugInfo)
    End Function
    Public Function QuerySurgeryDrugUseEndTable(ByRef drugInfo As DataTable, useRegId As String) As EnumDef.DBMEDITS_RESULT
        Dim strCon As String = String.Format("{0}='{1}'", DUD_REG_ID, useRegId)
        Dim querySql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, TBL_DRUG_USE_DETAIL, strCon)
        Return QueryTable(querySql, drugInfo)
    End Function
    Public Function QuerySurgeryDrugRequestTable(ByRef drugInfo As DataTable, OPNoteId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0}, {1}, {2} As {3}, {4} As {5}, {6} As {7}, {8} As {9}, {10} As {11}, {12} As {13}", _
                                                 DRD_ID, DRD_REG_ID, DRD_COMMON_NAME, TEXT_DRUG_COMMON_NAME, _
                                                 DRD_PRODUCT_NAME, TEXT_DRUG_PRODUCT_NAME, DRD_DRUG_SPEC, _
                                                 TEXT_DRUG_SPECIFICATION, DRD_DRUG_FACTORY, TEXT_DRUG_FACTORY, _
                                                 DRD_MEASUER_UNITS, TEXT_INS_UNIT, DRD_PACK_COUNT, TEXT_DRUG_AMOUNT)
        Dim strTable As String = String.Format("{0} inner join {1} on {2}={3}", TBL_OPERATION_REQUEST_MASTER, TBL_DRUG_REQUEST_DETAIL, DRD_REG_ID, DR_ID)
        Dim where = String.Format("{0}='{1}'", DR_OPN_REG_ID, OPNoteId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, strTable, where)
        Return QueryTable(querySql, drugInfo)
    End Function

    Public Function QuerySurgeryDrugFrontUseTable(ByRef drugInfo As DataTable, OPNoteId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0}, {1}, {2} As {3}, {4} As {5}, {6} As {7}, {8} As {9}, {10} As {11}, {12} As {13}", _
                                                 FUDD_ID, FUDD_REG_ID, FUDD_COMMON_NAME, TEXT_DRUG_COMMON_NAME, _
                                                 FUDD_PRODUCT_NAME, TEXT_DRUG_PRODUCT_NAME, FUDD_DRUG_SPEC, _
                                                 TEXT_DRUG_SPECIFICATION, FUDD_DRUG_FACTORY, TEXT_DRUG_FACTORY, _
                                                 FUDD_MEASURE_UNITS, TEXT_INS_UNIT, FUDD_PACK_COUNT, TEXT_DRUG_AMOUNT)
        Dim strTable As String = String.Format("{0} inner join {1} on {2}={3}", TBL_OPERATION_FRONT_USE_MASTER, TBL_FRONT_USE_DRUG_DETAIL, FUDD_REG_ID, ODUM_ID)
        Dim where = String.Format("{0}='{1}'", ODUM_NOTE_ID, OPNoteId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, strTable, where)
        Return QueryTable(querySql, drugInfo)
    End Function
    Public Function QuerySurgeryInsUseTable(ByRef insInfo As DataTable, useRegId As String) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0}, {1}, {2} As {3}, {4} As {5}, {6} As {7}, {8} As {9}, {10} As {11}, {12} As {13},{14} As {15}", IUD_ID, IUD_REG_ID, IUD_PACKAGE_ID, TEXT_PACKAGE_ID, IUD_CODE, TEXT_INS_CODE, _
                                                 IUD_NAME, TEXT_INS_NAME, IUD_SPEC, TEXT_INS_SPECIFICATION, IUD_UNIT, TEXT_INS_UNIT, _
                                                 IUD_COUNT, TEXT_INS_AMOUNT, IUD_STATUS, TEXT_INS_STATUS)
        Dim where = String.Format("{0}='{1}'", IUD_REG_ID, useRegId)
        Dim querySql = String.Format("Select {0} From {1} Where {2}", columns, TBL_INS_USE_DETAIL, where)
        Return QueryTable(querySql, insInfo)
    End Function

    Public Function CommitSurgeryRequestMaster(ByRef surgeryNoteInfo As SurgeryNoteInfo, ByVal drugTable As DataTable, ByVal insTable As DataTable) As DBMEDITS_RESULT
        If surgeryNoteInfo Is Nothing OrElse drugTable Is Nothing OrElse insTable Is Nothing Then Return DBMEDITS_RESULT.ERROR_PARAMETER
        Dim reqMasterId As String = surgeryNoteInfo.RequestReg.Id
        If String.IsNullOrEmpty(surgeryNoteInfo.RequestReg.Id) Then
            Dim lRequestID As Long
            If Not QueryNextVal(lRequestID, SEQ_TBL_OPER_REQUEST_MASTER) Then
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            reqMasterId = lRequestID
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        '如果手术申请单不存在的话，就先添加,并获取返回的ID号；
        If String.IsNullOrEmpty(surgeryNoteInfo.RequestReg.Id) Then
            Dim strCols As String = String.Format("{0},{1},{2},{3},{4}", DR_ID, DR_OPN_REG_ID, DR_ROOM_NAME, DR_TABLE_ID, DR_REQUEST_DATE)
            Dim strValues As String = String.Format("{0},'{1}','{2}','{3}',to_date('{4}','{5}')", reqMasterId, surgeryNoteInfo.Id, surgeryNoteInfo.Room, surgeryNoteInfo.Table, DateTime.Now, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)
            Dim insertSql As String = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_OPERATION_REQUEST_MASTER, strCols, strValues)
            If Not TransactionExecute(insertSql) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        End If

        '先删除药品和物品信息，再添加回去
        Dim delSql As String = String.Format("Delete From {0} Where {1}='{2}'", TBL_DRUG_REQUEST_DETAIL, DRD_REG_ID, reqMasterId)
        If Not TransactionExecute(delSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        delSql = String.Format("Delete From {0} Where {1}='{2}'", TBL_INS_REQUEST_DETAIL, IRD_REG_ID, reqMasterId)
        If Not TransactionExecute(delSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        For Each drugRow As DataRow In drugTable.Rows
            Dim drugInfo As New DrugInfo()
            drugInfo.TransFromDataRow(drugRow)
            Dim insertCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", DRD_REG_ID, DRD_COMMON_NAME, DRD_PRODUCT_NAME, DRD_DRUG_SPEC, DRD_DRUG_FACTORY, DRD_MEASUER_UNITS, DRD_PACK_COUNT, DRD_DRUG_ID)
            Dim colValues = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'", reqMasterId, drugInfo.CommonName, drugInfo.ProductName, drugInfo.Specification, drugInfo.Factory, drugInfo.Unit, drugInfo.Amount, drugInfo.strDrugID)
            Dim insertSql = String.Format("Insert Into {0} ({1}) Values ({2})", TBL_DRUG_REQUEST_DETAIL, insertCols, colValues)
            If Not TransactionExecute(insertSql) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next

        For Each insRow As DataRow In insTable.Rows
            Dim insInfo As New InstrumentInfo()
            insInfo.TransFromDataRow(insRow)
            Dim insertCols = String.Format("{0},{1},{2},{3},{4},{5}", IRD_REG_ID, IRD_CODE, IRD_NAME, IRD_SPEC, IRD_UNIT, IRD_COUNT)
            Dim colValues = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}'", reqMasterId, insInfo.Code, insInfo.Name, insInfo.Specification, insInfo.Unit, insInfo.Amount)
            Dim insertSql = String.Format("Insert Into {0} ({1}) Values ({2})", TBL_INS_REQUEST_DETAIL, insertCols, colValues)
            If Not TransactionExecute(insertSql) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next

        If Not ImplementUpdateOPerationStatus(surgeryNoteInfo.Id, OPerationNoteState.Requested) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        '提交事务后，获取申请单值，确保是新增的情况下
        surgeryNoteInfo.RequestReg.Id = reqMasterId

        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Public Function GenerateSurgeryUseMaster(ByRef surgeryNoteInfo As SurgeryNoteInfo)
        If surgeryNoteInfo Is Nothing Then Return DBMEDITS_RESULT.ERROR_PARAMETER

        Dim aiid As Long
        If Me.GetPrimaryKeyValue(aiid, TBL_OPERATION_USE_MASTER) <> DBMEDITS_RESULT.SUCCESS Then Return DBMEDITS_RESULT.ERROR_EXCEPTION
        Dim useMasterId = (aiid + 1).ToString()

        Dim drugInfo As New DataTable, insInfo As New DataTable
        Dim drugQueryReturn = QueryDrugRequestDetail(drugInfo, surgeryNoteInfo.Id)
        Dim insQueryReturn = QueryInstrumentRequestDetail(insInfo, surgeryNoteInfo.Id)

        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        Dim insertSql As String = String.Format("Insert Into {0} ({1},{2}) Values ('{3}','{4}')", TBL_OPERATION_USE_MASTER, UM_OPN_REG_ID, UM_USE_DATE, _
                                                surgeryNoteInfo.Id, DateTime.Now.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS))
        If Not TransactionExecute(insertSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        '获取所有药品和物品信息
        If DBMEDITS_RESULT.SUCCESS = drugQueryReturn AndAlso Not drugInfo.IsNullOrEmpty() Then
            For Each dr As DataRow In drugInfo.Rows
                Dim commonName = Judgement.JudgeDBNullValue(dr.Item(TEXT_DRUG_COMMON_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim productName = Judgement.JudgeDBNullValue(dr.Item(TEXT_DRUG_PRODUCT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim spec = Judgement.JudgeDBNullValue(dr.Item(TEXT_DRUG_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim factory = Judgement.JudgeDBNullValue(dr.Item(TEXT_DRUG_FACTORY), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim unit = Judgement.JudgeDBNullValue(dr.Item(TEXT_DRUG_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim amount = Judgement.JudgeDBNullValue(dr.Item(TEXT_DRUG_AMOUNT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                insertSql = String.Format("Insert Into {0} ({1},{2},{3},{4},{5},{6},{7}) Values('{8}','{9}','{10}','{11}','{12}','{13}','{14}')", TBL_DRUG_USE_DETAIL, _
                            DUD_REG_ID, DUD_COMMON_NAME, DUD_PRODUCT_NAME, DUD_DRUG_SPEC, DUD_DRUG_FACTORY, DUD_MEASUER_UNITS, DUD_PACK_COUNT, _
                            useMasterId, commonName, productName, spec, factory, unit, amount)
                If Not TransactionExecute(insertSql) Then
                    Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                    Return DBMEDITS_RESULT.ERROR_EXCEPTION
                End If
            Next
        End If

        If DBMEDITS_RESULT.SUCCESS = insQueryReturn AndAlso Not insInfo.IsNullOrEmpty() Then
            For Each dr As DataRow In insInfo.Rows
                Dim code = Judgement.JudgeDBNullValue(dr.Item(TEXT_INS_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim name = Judgement.JudgeDBNullValue(dr.Item(TEXT_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim spec = Judgement.JudgeDBNullValue(dr.Item(TEXT_INS_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim amount = Judgement.JudgeDBNullValue(dr.Item(TEXT_INS_AMOUNT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Dim unit = Judgement.JudgeDBNullValue(dr.Item(TEXT_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                insertSql = String.Format("Insert Into {0} ({1},{2},{3},{4},{5},{6}) Values('{7}','{8}','{9}','{10}','{11}','{12}')", TBL_INS_USE_DETAIL, _
                            IUD_REG_ID, IUD_CODE, IUD_NAME, IUD_SPEC, IUD_UNIT, IUD_COUNT, useMasterId, code, name, spec, unit, amount)
                If Not TransactionExecute(insertSql) Then
                    Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                    Return DBMEDITS_RESULT.ERROR_EXCEPTION
                End If
            Next
        End If

        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        surgeryNoteInfo.UseReg.Id = useMasterId
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Public Function CommitSurgeryUseMaster(ByVal surgeryNoteInfo As SurgeryNoteInfo, ByVal drugTable As DataTable, ByVal insTable As DataTable) As DBMEDITS_RESULT
        If surgeryNoteInfo Is Nothing OrElse drugTable Is Nothing OrElse insTable Is Nothing Then Return DBMEDITS_RESULT.ERROR_PARAMETER

        Dim lUseID As Long
        If Not QueryNextVal(lUseID, SEQ_TBL_OPERATION_USE_MASTER) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Dim strSQL, strCols, strValues, strCon As String
        strCols = String.Format("{0},{1},{2}", UM_ID, UM_OPN_REG_ID, UM_USE_DATE)
        strValues = String.Format("{0},{1},to_date('{2}','{3}')", lUseID, surgeryNoteInfo.Id, LocalData.ServerNow, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)
        strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_OPERATION_USE_MASTER, strCols, strValues)
        If Not TransactionExecute(strSQL) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        '更新药品和物品信息
        For Each drugRow As DataRow In drugTable.Rows
            strCols = String.Format("{0},{1},{2},{3},{4},{5},{6}", DUD_REG_ID, DUD_COMMON_NAME, DUD_PRODUCT_NAME, DUD_DRUG_SPEC, _
                                    DUD_DRUG_FACTORY, DUD_MEASUER_UNITS, DUD_PACK_COUNT)
            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}'", lUseID, drugRow.Item(TEXT_DRUG_COMMON_NAME), drugRow.Item(TEXT_DRUG_PRODUCT_NAME), _
                                      drugRow.Item(TEXT_DRUG_SPECIFICATION), drugRow.Item(TEXT_DRUG_FACTORY), drugRow.Item(TEXT_INS_UNIT), _
                                      drugRow.Item(TEXT_DRUG_AMOUNT))
            strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_DRUG_USE_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        For Each insRow As DataRow In insTable.Rows
            strCols = String.Format("{0},{1},{2},{3},{4},{5}", IUD_REG_ID, IUD_PACKAGE_ID, IUD_CODE, IUD_NAME, IUD_SPEC, IUD_UNIT)
            strValues = String.Format("{0},{1},'{2}','{3}','{4}','{5}'", lUseID, insRow.Item(TEXT_PACKAGE_ID), insRow.Item(TEXT_INS_ID), _
                                      insRow.Item(TEXT_INS_NAME), insRow.Item(TEXT_INS_TYPE), insRow.Item(TEXT_INS_UNIT))
            strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_INS_USE_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            strCon = String.Format("{0}={1}", SRS_PACKAGE_ID, insRow.Item(TEXT_PACKAGE_ID))
            strSQL = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_STERILEROOM_RU_STOCK, strCon)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If 
        Next
        If Not ImplementSterileRoomInOutLog(SR_LOG_INOUT_TYPE.INS_USE_OUT, lUseID) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '更新单据的状态
        If Not ImplementUpdateOPerationStatus(surgeryNoteInfo.Id, OPerationNoteState.SurgeryEnd) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Public Function CommitSurgeryFrontUseMaster(ByVal lstPackageCheck As List(Of PackageCheck), ByVal dt As DataTable, ByVal oSurgeryNoteInfo As SurgeryNoteInfo, ByVal eType As CHECK_TYPE) As DBMEDITS_RESULT
        If oSurgeryNoteInfo Is Nothing Then Return DBMEDITS_RESULT.ERROR_PARAMETER
        Dim lFrontUseID As Long
        If Not QueryNextVal(lFrontUseID, SEQ_MST_FRONT_USE_MASTER) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '插入术前拆包登记主表信息
        Dim strSQl, strCols, strValues As String
        strValues = String.Format("{0},'{1}','{2}','{3}',to_date('{4}','{5}'),'{6}'", lFrontUseID, oSurgeryNoteInfo.Id, _
                                  LocalData.LoginUser.m_strUserID, LocalData.LoginUser.m_strFullName, LocalData.ServerNow.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS), _
                                  CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS, CStr(eType))
        strCols = String.Format("{0},{1},{2},{3},{4},{5}", ODUM_ID, ODUM_NOTE_ID, ODUM_STAFF_ID, ODUM_STAFF_NAME, ODUM_DATETIME, ODUM_TYPE)
        strSQl = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_OPERATION_FRONT_USE_MASTER, strCols, strValues)
        If Not TransactionExecute(strSQl) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", FUID_REG_ID, FUID_PACKAGE_ID, FUID_INS_ID, FUID_INS_NAME, FUID_INS_TYPE, FUID_INS_UNIT, _
                                FUID_RESULT, FUID_REASON)

        For Each oPackageCheck As PackageCheck In lstPackageCheck
            strValues = String.Format("{0},{1},'{2}','{3}','{4}','{5}','{6}','{7}'", lFrontUseID, oPackageCheck.m_oPackageInfo.m_lPackageID, oPackageCheck.m_oPackageInfo.m_strINSID, _
                                      oPackageCheck.m_oPackageInfo.m_strINSName, oPackageCheck.m_oPackageInfo.m_strINSType, oPackageCheck.m_oPackageInfo.m_strINSUnit, _
                                      oPackageCheck.m_nResult, oPackageCheck.m_strReason)
            strSQl = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_FRONT_USE_INS_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQl) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
            If oPackageCheck.m_nResult = CHECK_RESULT.FAILD Then
                Dim strCon As String = String.Format("{0}={1}", SRS_PACKAGE_ID, oPackageCheck.m_oPackageInfo.m_lPackageID)
                strSQl = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_STERILEROOM_RU_STOCK, strCon)
                If Not TransactionExecute(strSQl) Then
                    Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                    Return DBMEDITS_RESULT.ERROR_EXCEPTION
                End If
            End If
        Next
        For Each dr As DataRow In dt.Rows
            strCols = String.Format("{0},{1},{2},{3},{4},{5},{6}", FUDD_REG_ID, FUDD_COMMON_NAME, FUDD_PRODUCT_NAME, FUDD_DRUG_SPEC, _
                                  FUDD_DRUG_FACTORY, FUDD_MEASURE_UNITS, FUDD_PACK_COUNT)
            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}',{6}", _
                                      lFrontUseID, dr.Item(TEXT_DRUG_COMMON_NAME), dr.Item(TEXT_DRUG_PRODUCT_NAME), _
                                       dr.Item(TEXT_DRUG_SPECIFICATION), dr.Item(TEXT_DRUG_FACTORY), _
                                        dr.Item(TEXT_INS_UNIT), dr.Item(TEXT_DRUG_AMOUNT))
            strSQl = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_FRONT_USE_DRUG_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQl) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        '更新单据的状态
        If Not ImplementUpdateOPerationStatus(oSurgeryNoteInfo.Id, OPerationNoteState.SurgeryConfirm) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function ImplementUpdateOPerationStatus(ByVal lOperatorID As Long, ByVal eStatus As OPerationNoteState) As Boolean
        Dim StrCon As String = String.Format("{0}={1}", OPN_ID, lOperatorID)
        Dim strValues = String.Format("{0}={1}", OPN_OPERATION_STATUS, CStr(eStatus))
        Dim strSQl = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_OPERATION_NOTE, strValues, StrCon)
        If Not TransactionExecute(strSQl) Then
            Return False
        End If
        Return True
    End Function

    Public Function ModifySurgeryFrontUseMaster(ByVal lstPackageCheck As List(Of PackageCheck), ByVal dt As DataTable, ByVal oSurgeryNoteInfo As SurgeryNoteInfo, ByVal eType As CHECK_TYPE) As DBMEDITS_RESULT
        If oSurgeryNoteInfo Is Nothing Then Return DBMEDITS_RESULT.ERROR_PARAMETER
        Dim lFrontUseID As Long
        If Not QueryNextVal(lFrontUseID, SEQ_MST_FRONT_USE_MASTER) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Dim strSQl, strCols, strValues, strCondition As String
        '删除以前的信息
        strCondition = String.Format("{0}={1}", OPN_ID, oSurgeryNoteInfo.Id)
        strSQl = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_OPERATION_FRONT_USE_MASTER, strCondition)
        If Not TransactionExecute(strSQl) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        strCondition = String.Format("{0}={1}", ODUM_NOTE_ID, oSurgeryNoteInfo.Id)
        Dim strSQlSub As String = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, ODUM_ID, TBL_OPERATION_FRONT_USE_MASTER, strCondition)
        strCondition = String.Format("{0}={1}", ODUM_NOTE_ID, strSQlSub)
        strSQl = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_FRONT_USE_INS_DETAIL, strCondition)

        If Not TransactionExecute(strSQl) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        strCondition = String.Format("{0}={1}", FUDD_REG_ID, oSurgeryNoteInfo.Id)
        strSQlSub = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, ODUM_ID, TBL_OPERATION_FRONT_USE_MASTER, strCondition)
        strCondition = String.Format("{0}={1}", FUDD_REG_ID, strSQlSub)
        strSQl = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, TBL_FRONT_USE_DRUG_DETAIL, strCondition)

        If Not TransactionExecute(strSQl) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If


        '插入术前拆包登记主表信息

        strValues = String.Format("{0},'{1}','{2}','{3}',to_date('{4}','{5}'),'{6}'", lFrontUseID, oSurgeryNoteInfo.Id, _
                                  LocalData.LoginUser.m_strUserID, LocalData.LoginUser.m_strFullName, LocalData.ServerNow.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS), _
                                  CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS, CStr(eType))
        strCols = String.Format("{0},{1},{2},{3},{4},{5}", ODUM_ID, ODUM_NOTE_ID, ODUM_STAFF_ID, ODUM_STAFF_NAME, ODUM_DATETIME, ODUM_TYPE)
        strSQl = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_OPERATION_FRONT_USE_MASTER, strCols, strValues)
        If Not TransactionExecute(strSQl) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", FUID_REG_ID, FUID_PACKAGE_ID, FUID_INS_ID, FUID_INS_NAME, FUID_INS_TYPE, FUID_INS_UNIT, _
                                FUID_RESULT, FUID_REASON)

        For Each oPackageCheck As PackageCheck In lstPackageCheck
            strValues = String.Format("{0},{1},'{2}','{3}','{4}','{5}','{6}','{7}'", lFrontUseID, oPackageCheck.m_oPackageInfo.m_lPackageID, oPackageCheck.m_oPackageInfo.m_strINSID, _
                                      oPackageCheck.m_oPackageInfo.m_strINSName, oPackageCheck.m_oPackageInfo.m_strINSType, oPackageCheck.m_oPackageInfo.m_strINSUnit, _
                                      oPackageCheck.m_nResult, oPackageCheck.m_strReason)
            strSQl = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_FRONT_USE_INS_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQl) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        For Each dr As DataRow In dt.Rows
            strCols = String.Format("{0},{1},{2},{3},{4},{5},{6}", FUDD_REG_ID, FUDD_COMMON_NAME, FUDD_PRODUCT_NAME, FUDD_DRUG_SPEC, _
                                  FUDD_DRUG_FACTORY, FUDD_MEASURE_UNITS, FUDD_PACK_COUNT)
            strValues = String.Format("{0},{1},{2},{3},{4},{5},{6}", _
                                      lFrontUseID, dr.Item(TEXT_DRUG_COMMON_NAME), dr.Item(TEXT_DRUG_PRODUCT_NAME), _
                                       dr.Item(TEXT_DRUG_SPECIFICATION), dr.Item(TEXT_DRUG_FACTORY), _
                                        dr.Item(TEXT_DRUG_UNIT), dr.Item(TEXT_DRUG_AMOUNT))
            strSQl = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_FRONT_USE_DRUG_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQl) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        '更新单据的状态
        Dim StrCon As String = String.Format("{0}={1}", OPN_ID, oSurgeryNoteInfo.Id)
        strValues = String.Format("{0}={1}", OPN_OPERATION_STATUS, CStr(EnumDef.OPerationNoteState.SurgeryConfirm))
        strSQl = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_OPERATION_NOTE, strValues, StrCon)
        If Not TransactionExecute(strSQl) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If Not TransactionCommit() Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function


    Public Function QueryPackageInfoByID(ByRef oPakcageInfo As DataTable, ByVal lPackageID As Long) As DBMEDITS_RESULT
        Dim strCon, strSql As String
        strCon = String.Format("{0}={1}", SRS_PACKAGE_ID, lPackageID)
        strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, TBL_STERILEROOM_RU_STOCK, strCon)
        Return QueryTable(strSql, oPakcageInfo)
    End Function

    Public Function QueryPackageInfoByID(ByRef oPakcageInfo As PackageInfo, ByVal lPackageID As Long) As DBMEDITS_RESULT
        Dim strCon, strSql As String
        strCon = String.Format("{0}={1}", SRS_PACKAGE_ID, lPackageID)
        strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, TBL_STERILEROOM_RU_STOCK, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count < 1 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        ElseIf ds.Tables(0).Rows.Count > 1 Then
            Return DBMEDITS_RESULT.EXIST_OVERFLOW
        Else
            oPakcageInfo.m_lPackageID = CLng(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_PACKAGE_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            oPakcageInfo.m_strINSID = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPakcageInfo.m_strINSName = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPakcageInfo.m_strINSType = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPakcageInfo.m_strINSUnit = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPakcageInfo.m_datSterilize = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_STERILIZE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            oPakcageInfo.m_datAvailable = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            oPakcageInfo.m_nSterilizRoomID = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(SRS_STERILIZE_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function InsertUseFaileReason(ByVal strReason As String) As Long
        Dim strValues = String.Format("'{0}'", strReason)
        Dim strSQl = String.Format(DBCONSTDEF_SQL_INSERT_FULL, MST_PACKAGE_CHECK_REASON, PCR_REASON, strValues)
        If Not UpdateOleDb(strSQl) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function ModifyUseFaileReason(ByVal strReason As String, ByVal lID As Long) As Long
        Dim strCOn As String = String.Format("{0}={1}", PCR_ID, lID)
        Dim strValue As String = String.Format("{0}='{1}'", PCR_REASON, strReason)
        Dim strSQl = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, MST_PACKAGE_CHECK_REASON, strValue, strCOn)
        If Not UpdateOleDb(strSQl) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function DeleteUseFaileReason(ByVal lID As Long) As Long
        Dim strCOn As String = String.Format("{0}={1}", PCR_ID, lID)
        Dim strSQl = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, MST_PACKAGE_CHECK_REASON, strCOn)
        If Not UpdateOleDb(strSQl) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryFrontUseINSInfoByID(ByRef dt As DataTable, ByVal lOPN_ID As Long, Optional ByVal eCheck As EnumDef.CHECK_RESULT = CHECK_RESULT.PASS) As Long
        dt.Clear()
        Dim strCon As String = String.Format("{0}={1} and {2}={3}", ODUM_NOTE_ID, lOPN_ID, FUID_RESULT, CStr(eCheck))
        Dim strTable As String = String.Format("{0} inner join {1} on {2}={3}", TBL_OPERATION_FRONT_USE_MASTER, TBL_FRONT_USE_INS_DETAIL, _
                                             ODUM_ID, FUID_REG_ID)
        Dim strCols As String = String.Format("{0},{1},{2},{3},{4}", FUID_PACKAGE_ID, FUID_INS_ID, FUID_INS_NAME, FUID_INS_TYPE, FUID_INS_UNIT)

        Dim strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, strCols, strTable, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim drNew As DataRow = dt.NewRow
            drNew.Item(TEXT_PACKAGE_ID) = CStr(JudgeDataValue(dr.Item(FUID_PACKAGE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_ID) = CStr(JudgeDataValue(dr.Item(FUID_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_NAME) = CStr(JudgeDataValue(dr.Item(FUID_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_TYPE) = CStr(JudgeDataValue(dr.Item(FUID_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            drNew.Item(TEXT_INS_UNIT) = CStr(JudgeDataValue(dr.Item(FUID_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            dt.Rows.Add(drNew)
        Next
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function InsertReturnInfo(ByVal oSur As SurgeryNoteInfo, ByVal dtDurg As DataTable, ByVal dtINS As DataTable) As Long
        Dim strSQL, strCols, strValues As String
        Dim lReturnID As Long
        '获取回收主表主键
        If Not QueryNextVal(lReturnID, SEQ_TBL_RETURN_MASTER) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionBegin() Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", ORM_ID, ORM_REG_ID, ORM_DP_ID, ORM_DP_NAME, ORM_ROOM_ID, _
                                ORM_ROOM_NAME, ORM_TABLE_ID, ORM_NURSE_ID, ORM_NURSE_NAME, ORM_DATE)
        strValues = String.Format("{0},{1},'{2}','{3}','{4}','{5}',{6},'{7}','{8}',to_DATE('{9}','{10}')", lReturnID, oSur.Id, oSur.DepartmentID, oSur.DepartmentName, _
                                  oSur.RoomID, oSur.Room, oSur.Table, LocalData.LoginUser.m_strUserID, LocalData.LoginUser.m_strFullName, _
                                  LocalData.ServerNow, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)
        strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_OPERATION_RETURN_MASTER, strCols, strValues)
        If Not TransactionExecute(strSQL) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        '插入物品回收表
        For Each dr As DataRow In dtDurg.Rows
            If CInt(dr.Item(TEXT_DRUG_RETURN_COUNT)) = 0 Then
                Continue For
            End If
            strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", DRD_REG_ID, DRD_DRUG_ID, DRD_COMMON_NAME, DRD_PRODUCT_NAME, _
                               DRD_DRUG_SPEC, DRD_DRUG_FACTORY, DRD_MEASUER_UNITS, DRD_PACK_COUNT)
            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}'", lReturnID, dr.Item(TEXT_DRUG_ID), _
                                      dr.Item(TEXT_DRUG_COMMON_NAME), dr.Item(TEXT_DRUG_PRODUCT_NAME), _
                                      dr.Item(TEXT_DRUG_SPECIFICATION), dr.Item(TEXT_DRUG_FACTORY), _
                                      dr.Item(TEXT_DRUG_UNIT), dr.Item(TEXT_DRUG_RETURN_COUNT))
            strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_DRUG_RETURN_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSQL) Then
                Logger.WriteLine(m_oDBConnect.GetErrorString)
                Return DBMEDITS_RESULT.ERROR_EXCEPTION
            End If
        Next
        '插入器械回收表
        For Each drINS As DataRow In dtINS.Rows
            If drINS.Item(TEXT_RETURN_IS_EXIST).Equals(TEXT_CHECK) Then
                strCols = String.Format("{0},{1},{2},{3},{4},{5}", IRD_REG_ID, IRD_PACKAGE_ID, IRD_INS_ID, IRD_INS_NAME, _
                              IRD_INS_TYPE, IRD_INS_UNIT)
                strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}'", lReturnID, drINS.Item(TEXT_PACKAGE_ID), _
                                          drINS.Item(TEXT_INS_ID), drINS.Item(TEXT_INS_NAME), _
                                          drINS.Item(TEXT_INS_TYPE), drINS.Item(TEXT_INS_UNIT))
                strSQL = String.Format(DBCONSTDEF_SQL_INSERT_FULL, TBL_INS_RETURN_DETAIL, strCols, strValues)
                If Not TransactionExecute(strSQL) Then
                    Logger.WriteLine(m_oDBConnect.GetErrorString)
                    Return DBMEDITS_RESULT.ERROR_EXCEPTION
                End If
            End If
        Next
        '更新单据状态
        If Not ImplementUpdateOPerationStatus(oSur.Id, OPerationNoteState.SurgeryReturn) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If Not TransactionCommit() Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION

        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function ChangePackageLocality(ByVal nSterilizeID As Integer, ByVal lPackageID As Long) As Long
        Dim strCon, strSQl, strValues As String
        strCon = String.Format("{0}={1}", SRS_PACKAGE_ID, lPackageID)
        strValues = String.Format("{0}={1}", SRS_STERILIZE_ROOM_ID, nSterilizeID)
        strSQl = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, TBL_STERILEROOM_RU_STOCK, strValues, strCon)
        If Not UpdateOleDb(strSQl) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryINSDetailInfoByID(ByRef dt As DataTable, ByVal strINSID As String) As Long
        Dim strCon, strSQl As String
        strCon = String.Format("{0}='{1}'", IDI_REG_ID, strINSID)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, MST_INS_DETAIL_INFO, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count = 0 Then
            dt = ds.Tables(0).Clone
        Else
            dt = ds.Tables(0).Copy
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
End Class
