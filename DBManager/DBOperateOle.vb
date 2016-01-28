Option Explicit On
Option Strict On

Imports ITSBase
Imports DBAdapter
Imports System.Data.OleDb
Public Class DBOperateOle
    Protected m_oDBConnect As OleDbAdapter
    Protected m_strErrorReason As String
    Public Sub New(Optional ByVal bSynchronized As Boolean = True)
        If bSynchronized Then
            m_oDBConnect = SingletonOleDbConnection.Create
        Else
            m_oDBConnect = New OleDbAdapter
        End If
        m_strErrorReason = ""
    End Sub
    ReadOnly Property GetErrorReason() As String
        Get
            GetErrorReason = m_strErrorReason
        End Get
    End Property
    Public Function QueryTotal(ByRef dtResult As DataTable, ByVal strTable As String) As Long
        Dim strSql As String
        strSql = String.Format(DBCONSTDEF_SQL_SELECT, DBCONSTDEF_SQL_SELECT_ALL, strTable)
        Dim ds As New DataSet

        If Not QueryOleDb(strSql, ds) Then
            m_strErrorReason = DBMEDITS_CONST_TEXT_ERROR_EXCEPTION
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            dtResult = ds.Tables(0).Copy()
            ds.Dispose()
            Return DBMEDITS_RESULT.SUCCESS
        Else
            dtResult = ds.Tables(0).Clone
            ds.Dispose()
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_NOT_EXIST, strTable, m_oDBConnect.GetCommandString)
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        End If
    End Function
#Region "OleDB Operate"
    Protected Function QueryOleDb(ByVal strSql As String, ByRef dsResult As DataSet, Optional ByVal oOleDbParameters As OleDbParameters = Nothing) As Boolean
        If dsResult Is Nothing Then
            dsResult = New DataSet
        Else
            dsResult.Clear()
        End If

        If Not m_oDBConnect.QueryOleDb(strSql, dsResult, oOleDbParameters) Then
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_SQLQUERY_EXECUTE_EXCEPTION, m_oDBConnect.GetCommandString) & m_oDBConnect.GetErrorString
            Return False
        End If
        Return True
    End Function

    Protected Function UpdateOleDb(ByVal strSql As String, Optional ByVal oOleDbParameters As OleDbParameters = Nothing) As Boolean

        If Not m_oDBConnect.UpdateOleDb(strSql, oOleDbParameters) Then
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_SQLCOMMAND_EXECUTE_EXCEPTION, m_oDBConnect.GetCommandString) & m_oDBConnect.GetErrorString
            Return False
        End If

        Return True
    End Function

    Protected Function TransactionBegin() As Boolean

        If Not m_oDBConnect.TransactionBegin() Then
            m_strErrorReason = m_oDBConnect.GetErrorString
            Return False
        End If

        Return True

    End Function
    Protected Function TransactionExecute(ByVal strSQLCommand As String, Optional ByVal oOleDbParameters As OleDbParameters = Nothing, Optional ByVal oType As CommandType = CommandType.Text) As Boolean

        If Not m_oDBConnect.TransactionExecute(strSQLCommand, oOleDbParameters, oType) Then
            m_oDBConnect.CloseDB()
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_TRANSACTION_EXECUTE_EXCEPTION, m_oDBConnect.GetCommandString) & m_oDBConnect.GetErrorString
            Return False
        End If

        Return True
    End Function

    Protected Function TransactionCommit() As Boolean

        If Not m_oDBConnect.TransactionCommit() Then
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_TRANSACTION_COMMIT_EXCEPTION, m_oDBConnect.GetTransactionProcedure) & m_oDBConnect.GetErrorString
            Return False
        End If

        Return True

    End Function
    Protected Function TransactionRollback() As Boolean

        If Not m_oDBConnect.TransactionRollback() Then
            m_strErrorReason = DBMEDITS_CONST_TEXT_ERROR_TRANSACTION_ROLLBACK_EXCEPTION & m_oDBConnect.GetErrorString
            Return False
        End If

        Return True
    End Function
    Protected Function QueryNextVal(ByRef lRegID As Long, ByVal strSequence As String) As Boolean
        Dim strSQl As String = String.Format(DBCONSTDEF_SQL_SELECT_NEXTVAL, strSequence)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return False
        End If
        If ds.Tables.Count < 1 OrElse ds.Tables(0).Rows.Count < 1 Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return False
        End If
        lRegID = CLng(JudgeDataValue(ds.Tables(0).Rows(0).Item(DBCONSTDEF_SQL_SEQ_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
        Return True
    End Function
#End Region
#Region "Tool"
    Protected Shared Function JudgeDataValue(ByVal objSourceObject As Object, ByVal enumDataType As ENUM_DATA_TYPE) As Object
        Return Judgement.JudgeDBNullValue(objSourceObject, enumDataType)
    End Function
    '********************************************************************
    '	Title:			CreateArrayCondition
    '	Author:			FB
    '	Create Date:	2009-9-7
    '	Description:    Create condition using the ParamArray
    '                   ColumnName = Condition   OR  ColumnName IN ( Condition ) 
    '                   eDBtype Only support DateTime,VarChar, Char , BigInt , Int
    '*********************************************************************
    Public Shared Function CreateArrayCondition(ByVal strColumnName As String, ByVal eDBtype As SqlDbType, ByVal bEqual As Boolean, ByVal ParamArray arrItem() As Short) As String

        Dim lst As ArrayList = New ArrayList
        For Each oItem As Object In arrItem
            lst.Add(CStr(oItem))
        Next

        Return CreateArrayCondition(strColumnName, eDBtype, bEqual, CType(lst.ToArray(GetType(String)), String()))
    End Function
    Public Shared Function CreateArrayCondition(ByVal strColumnName As String, ByVal eDBtype As SqlDbType, ByVal bEqual As Boolean, ByVal ParamArray arrItem() As Long) As String

        Dim lst As ArrayList = New ArrayList
        For Each oItem As Object In arrItem
            lst.Add(CStr(oItem))
        Next

        Return CreateArrayCondition(strColumnName, eDBtype, bEqual, CType(lst.ToArray(GetType(String)), String()))
    End Function
    Public Shared Function CreateArrayCondition(ByVal strColumnName As String, ByVal eDBtype As SqlDbType, ByVal bEqual As Boolean, ByVal ParamArray arrItem() As String) As String

        If arrItem.Length <= 0 Then Return String.Empty

        Dim strValueFormat As String
        If eDBtype = SqlDbType.DateTime OrElse _
           eDBtype = SqlDbType.VarChar OrElse _
           eDBtype = SqlDbType.Char Then
            strValueFormat = "'{0}'"
        Else
            strValueFormat = "{0}"
        End If

        If arrItem.Length = 1 Then
            If bEqual Then
                Return String.Format("{0}={1}", strColumnName, String.Format(strValueFormat, CStr(arrItem(0))))
            Else
                Return String.Format("{0}<>{1}", strColumnName, String.Format(strValueFormat, CStr(arrItem(0))))
            End If
        End If

        Dim strCondition As String = String.Empty
        For Each eType As Object In arrItem
            Dim strValue As String = String.Format(strValueFormat, CStr(eType))
            If strCondition.Length = 0 Then
                strCondition = strValue
            Else
                strCondition = strCondition & "," & strValue
            End If

        Next

        If bEqual Then
            Return String.Format("{0} IN ({1})", strColumnName, strCondition)
        Else
            Return String.Format("{0} NOT IN ({1})", strColumnName, strCondition)
        End If


    End Function
#End Region
#Region "Common Function"
    Public Function QueryPackageInfo(ByRef oPackageInfo As PackageInfo, ByVal lPackageID As Long, ByVal eSterilizeType As STERILIZE_ROOM_TYPE) As DBMEDITS_RESULT
        If oPackageInfo Is Nothing Then
            oPackageInfo = New PackageInfo
        Else
            oPackageInfo.Reset()
        End If
        Dim strCon, strSQl, strTable As String
        strCon = String.Format("{0}={1} and {2}='{3}'", SRS_PACKAGE_ID, lPackageID, SI_TYPE, CStr(eSterilizeType))
        strTable = String.Format("{0} inner join {1} on {2}={3}", TBL_STERILEROOM_RU_STOCK, MST_STERILEROOM_INFO, SI_ID, SRS_STERILIZE_ROOM_ID)

        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, strTable, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count = 1 Then
            oPackageInfo.m_lPackageID = CLng(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_PACKAGE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_oINSInfo.m_strINSID = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_oINSInfo.m_strName = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_oINSInfo.m_strType = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_oINSInfo.m_strUnit = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.SterilizeDate = CDate(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_STERILIZE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            oPackageInfo.AvailableDate = CDate(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            oPackageInfo.m_lSterileRoomID = CInt(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_STERILIZE_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            'oPackageInfo.m_shState = CShort(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            Return DBMEDITS_RESULT.SUCCESS
        ElseIf ds.Tables(0).Rows.Count < 1 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        Else
            Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
        End If
    End Function
    Protected Function ImplementSterileRoomAbnormalInOutLog(ByVal eType As SR_LOG_INOUT_TYPE, ByVal lRegID As Long) As Boolean

        Dim strCols, strValues, strSql As String
        Dim oParameters As OleDbParameters = New OleDbParameters

        strCols = String.Format("{0},{1},{2},{3},{4}", _
                               SAI_TYPE, SAI_SF_ID, SAI_SF_NAME, SAI_DATETIME, SAI_ID)

        strValues = String.Format("{0},'{1}','{2}',to_date('{3}','{4}'),{5}", CShort(eType), _
                                    MakeSQLInputPattern(LocalData.LoginUser.m_strUserID), _
                                    MakeSQLInputPattern(LocalData.LoginUser.m_strFullName), _
                                    LocalData.ServerNow, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS, lRegID)
        strSql = String.Format(DBCONSTDEF_ORACLE_INSERT_FULL, LOG_STOREROOM_ABNORMAL_INOUT, strCols, strValues)
        If Not TransactionExecute(strSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return False
        End If
        Return True
    End Function
    Protected Function ImplementStoreRoomAbnormalDetailLog(ByVal lRegID As Long, ByVal dt As DataTable) As Boolean

        Dim strCols as String = string.Empty, strValues as String = string.Empty, strSql As String = string.Empty

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
                              CDate(dr.Item(TEXT_WS_PRODUCE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CDate(dr.Item(TEXT_WS_EXPIRE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CStr(dr.Item(TEXT_WS_COMPANY_ID)), _
                              CStr(dr.Item(TEXT_WS_COMPANY_NAME)), _
                               CStr(dr.Item(TEXT_WS_INS_COUNT)), _
                              CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
            strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_ABNORMAL_INOUT_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSql) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + MA_INSTALL_DATE + m_oDBConnect.GetErrorString)
                Return False
            End If
        Next
        Return True
    End Function
    Protected Function ImplementStoreRoomDrugAbnormalDetailLog(ByVal lRegID As Long, ByVal dt As DataTable) As Boolean

        Dim strCols As String = String.Empty, strValues As String = String.Empty, strSql As String = String.Empty

        'Check condition is INS ID and BatchID and Company ID

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", _
                                DSAID_REG_ID, DSAID_DRUG_CODE, DSAID_DRUG_COMMON_NAME, DSAID_DRUG_PRODUCT_NAME, _
                                DSAID_DRUG_MEASUER_UNITS, DSAID_MANUFACTURERS, DSAID_SPECIFICATION, DSAID_DRUG_COUNT, _
                                DSAID_DRUG_UNIT, DSAID_PRODUCE_DATE, DSAID_BATCH_ID, DSAID_AVAILABLE_DATE)

        For Each dr As DataRow In dt.Rows

            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',to_date('{9}','{12}'),'{10}',to_date('{11}','{12}')", _
                              lRegID, CStr(dr.Item(TEXT_DRUG_ID)), _
                              CStr(dr.Item(TEXT_DRUG_COMMON_NAME)), _
                              CStr(dr.Item(TEXT_DRUG_NAME)), _
                              CStr(dr.Item(TEXT_DRUG_UNIT)), _
                              CStr(dr.Item(TEXT_DRUG_FACTORY)), _
                              CStr(dr.Item(TEXT_DRUG_SPECIFICATION)), _
                              CStr(dr.Item(TEXT_DRUG_AMOUNT)), _
                              CStr(dr.Item(TEXT_DRUG_UNIT)), _
                              CDate(dr.Item(TEXT_WS_PRODUCE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CStr(dr.Item(TEXT_DRUG_BATCHNO)), _
                              CDate(dr.Item(TEXT_WS_EXPIRE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
            strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_DRUG_ABNORMAL_INOUT_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSql) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
                Return False
            End If
        Next
        Return True
    End Function
    Protected Function ImplementStoreRoomAbnormalDetailLog(ByVal lRegID As Long, ByVal oSuInfo As SUInfo) As Boolean

        Dim strCols as String = String.Empty, strValues as String =String.Empty, strSql As String = String.Empty
        Dim oParameters As New OleDbParameters

        'Check condition is INS ID and BatchID and Company ID

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", _
                                 SAID_REG_ID, SAID_INS_ID, SAID_INS_NAME, SAID_INS_TYPE, _
                                SAID_INS_UNIT, SAID_BATCH_ID, SAID_PRODUCE_DATE, SAID_EXPIRE_DATE, _
                                SAID_COMPANY_ID, SAID_COMPANY_NAME, SAID_COUNT)

        Dim nCount As Integer = oSuInfo.m_nCount - oSuInfo.m_nRealityCount
        If nCount < 0 Then
            nCount = -nCount
        End If

        strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}',to_date('{6}','{11}'),to_date('{7}','{11}'),{8},'{9}',{10}", _
                          lRegID, oSuInfo.m_strINSID, _
                          oSuInfo.m_strName, _
                         oSuInfo.m_strType, _
                         oSuInfo.m_strUnit, _
                         oSuInfo.m_strBatch, _
                         oSuInfo.m_dtimeProduce.ToString(TEXT_DATETIME_FORMATION_DATE), _
                          oSuInfo.m_dtimeExpire.ToString(TEXT_DATETIME_FORMATION_DATE), _
                          oSuInfo.m_lCompanyID, _
                          oSuInfo.m_strCompanyName, _
                           nCount, _
                          CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
        strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_ABNORMAL_INOUT_DETAIL, strCols, strValues)

        If Not TransactionExecute(strSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_oDBConnect.GetErrorString)
            Return False
        End If

        Return True
    End Function
    Protected Function ImplementDrugAbnormalDetailLog(ByVal lRegID As Long, ByVal dt As DataTable) As Boolean

        Dim strCols, strValues, strSql As String

        'Check condition is INS ID and BatchID and Company ID

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", _
                                DSAID_REG_ID, DSAID_DRUG_CODE, DSAID_DRUG_COMMON_NAME, DSAID_DRUG_PRODUCT_NAME, _
                                DSAID_DRUG_MEASUER_UNITS, DSAID_MANUFACTURERS, DSAID_SPECIFICATION, _
                                DSAID_DRUG_COUNT, DSAID_PRODUCE_DATE, DSAID_BATCH_ID, DSAID_AVAILABLE_DATE)

        For Each dr As DataRow In dt.Rows

            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},to_date('{8}','{11}'),'{9}',to_date('{10}','{11}')", _
                              lRegID, CStr(dr.Item(TEXT_DRUG_ID)), _
                              CStr(dr.Item(TEXT_DRUG_COMMON_NAME)), _
                              CStr(dr.Item(TEXT_DRUG_NAME)), _
                              CStr(dr.Item(TEXT_DRUG_UNIT)), _
                              CStr(dr.Item(TEXT_DRUG_FACTORY)), _
                              CStr(dr.Item(TEXT_DRUG_SPECIFICATION)), _
                              CInt(dr.Item(TEXT_DRUG_AMOUNT)), _
                              CDate(dr.Item(TEXT_WS_PRODUCE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                               CStr(dr.Item(TEXT_DRUG_BATCHNO)), _
                               CDate(dr.Item(TEXT_WS_EXPIRE_DATE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
            strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_DRUG_ABNORMAL_INOUT_DETAIL, strCols, strValues)
            If Not TransactionExecute(strSql) Then
                Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + MA_INSTALL_DATE + m_oDBConnect.GetErrorString)
                Return False
            End If
        Next
        Return True
    End Function
    Protected Function ImplementSterileRoomInOutLog(ByVal eType As SR_LOG_INOUT_TYPE, ByVal lRegID As Long) As Boolean

        Dim strCols, strValues, strSql As String
        strCols = String.Format("{0},{1},{2},{3}", _
                              SIM_ID, SIM_TYPE, SIM_REG_ID, SIM_DATETIME)


        strValues = String.Format("{0}.nextval,{1},{2},to_date('{3}','{4}')", SEQ_STOREROOM_INOUT_MASTER, CShort(eType), lRegID, LocalData.ServerNow, CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDDHHMMSS)

        strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_STOREROOM_INOUT_MASTER, strCols, strValues)

        If Not TransactionExecute(strSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return False
        End If

        Return True
    End Function

    Public Function ImplementStoreRoomruRuAbnormalDetailLog(ByVal lRegID As Long, ByVal oPackage As PackageInfo) As Boolean

        Dim strCols, strValues, strSql As String

        'Check condition is INS ID and BatchID and Company ID

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6}", _
                                RAID_REG_ID, RAID_INS_ID, RAID_INS_NAME, RAID_INS_TYPE, _
                               RAID_INS_UNIT, RAID_PACKAGE_ID, RAID_EXPRIED_DATE)
        strValues = String.Format("{0},'{1}','{2}','{3}','{4}',{5},to_date('{6}','{7}')", _
                          lRegID, oPackage.m_oINSInfo.m_strINSID, _
                          oPackage.m_oINSInfo.m_strName, _
                         oPackage.m_oINSInfo.m_strType, _
                         oPackage.m_oINSInfo.m_strUnit, _
                           oPackage.m_lPackageID, _
                           oPackage.AvailableDate.ToString(TEXT_DATETIME_FORMATION_DATE), _
                          CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
        strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_RU_ABNORMAL_INOUT_DETAIL, strCols, strValues)
        If Not TransactionExecute(strSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return False
        End If
        Return True
    End Function

    Public Function QuerySurgeryNoteInfoByID(ByRef oSurInfo As Accessory.SurgeryNoteInfo, ByVal lID As Long) As EnumDef.DBMEDITS_RESULT
        Dim columns As String = String.Format("{0},{1}, {2},{3} , {4},{5} , {6},{7} , {8},{9}, {10},{11} ,{12},{13}, {14},{15} , {16},{17}", _
                    OPN_ID, OPN_VISIT_ID, OPN_PATIENT_NAME, OPN_GENDER, OPN_AGE, OPN_OPERATION_NAME, _
                    OPN_ORDER_DATE, ROOM_NAME, OPN_TABLE_ID, TRUE_NAME, FULL_NAME, _
                    OPN_WEIGHT, OPN_DIAGNOSIS, OPN_DR_MEMO, OPN_OPERATION_ID, OPN_OPERATION_STATUS, OPN_ROOM_ID, OPN_DEPARTMENT_ID)
        Dim leftJoin As String = String.Format("{0} Left Join {1} On {2}={3}", TBL_OPERATION_NOTE, DIC_USER_INFO, USER_CODE, OPN_DOCTOR_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_DEPT_INFO, DEPT_ID, OPN_DEPARTMENT_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATING_ROOM, ROOM_ID, OPN_ROOM_ID)
        leftJoin += String.Format(" Left Join {0} On {1}={2}", DIC_OPERATION, OPERATION_CODE, OPN_OPERATION_ID)
        Dim condition As String = String.Format("{0}={1}", OPN_ID, lID)
        
        Dim strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, columns, leftJoin, condition)
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count > 1 Then
            Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
        ElseIf ds.Tables(0).Rows.Count < 1 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        Else
            oSurInfo.Id = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.VisitId = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_VISIT_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.PatName = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_PATIENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.Gender = Judgement.Sex(CStr((JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_GENDER), ENUM_DATA_TYPE.DATA_TYPE_STRING))))
            oSurInfo.Age = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_AGE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.SurName = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_PATIENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.OrderDate = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_ORDER_DATE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.RoomID = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.Room = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(ROOM_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.Table = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_TABLE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.DepartmentID = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_DEPARTMENT_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.DepartmentName = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(FULL_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.Weight = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_WEIGHT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.Diagnosis = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_DIAGNOSIS), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.Memo = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_DR_MEMO), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.SurId = CStr(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_OPERATION_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oSurInfo.NoteStatus = CType(JudgeDataValue(ds.Tables(0).Rows(0).Item(OPN_OPERATION_STATUS), ENUM_DATA_TYPE.DATA_TYPE_INTEGER), OPerationNoteState)
            Return DBMEDITS_RESULT.SUCCESS
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QuerySterilizeRoomByType(ByRef nSterilizeID As Integer, ByVal eType As STERILIZE_ROOM_TYPE) As Long
        Dim strCon, strSQl As String
        strCon = String.Format("{0}='{1}'", SI_TYPE, CStr(eType))
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, SI_ID, MST_STERILEROOM_INFO, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Logger.WriteLine(m_oDBConnect.GetErrorString)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            nSterilizeID = CInt(JudgeDataValue(ds.Tables(0).Rows(0).Item(SI_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
        Else
            Logger.WriteLine(String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_NOT_EXIST, MST_STERILEROOM_INFO, SI_ID))
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        End If
        Return DBMEDITS_RESULT.SUCCESS
    End Function
    Public Function QueryINSInfo(ByRef dt As DataTable, ByVal ParamArray arrType() As INS_KINDS) As Long
        Dim strSQl, strCon, strCols As String
        strCon = CreateArrayCondition(INS_KIND, SqlDbType.SmallInt, True, arrType)
        strCols = String.Format("{0},{1},{2},{3},{4}", INS_CODE, INS_NAME_INPUTCODE, INS_NAME, INS_SPEC, INS_UNIT)
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
    Protected Function ImplementSterileRoomAbnormalHVLog(ByVal lRegID As Long, _
                                                         ByVal oHVINSInfo As HighValueInfo) As Boolean

        Dim strCols, strValues, strSql As String

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", _
                                SHAID_REG_ID, SHAID_INS_ID, SHAID_INS_NAME, SHAID_INS_TYPE, _
                                SHAID_INS_UNIT, SHAID_BATCH_ID, _
                                SHAID_COMPANY_ID, SHAID_COMPANY_NAME, SHAID_COMPANY_CODE, _
                                SHAID_SN_CODE, SHAID_PACKAGE_ID, SHAID_EXAM_DATE, SHAID_EXPIRE_DATE)
        strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',to_date('{11}','{13}'),to_date('{12}','{13}')", _
                                lRegID, oHVINSInfo.m_strINSID, oHVINSInfo.m_strINSName, oHVINSInfo.m_strINSType, _
                                oHVINSInfo.m_strINSUnit, oHVINSInfo.m_strBatch, _
                                oHVINSInfo.m_nCompanyID, oHVINSInfo.m_strCompanyName, _
                               oHVINSInfo.m_strCompanyCode, oHVINSInfo.m_strSequenceBarcode, _
                               oHVINSInfo.m_lPackageID, CDate(oHVINSInfo.m_datExamDate).ToString(TEXT_DATETIME_FORMATION_DATE), _
                               CDate(oHVINSInfo.m_datExpriedDate).ToString(TEXT_DATETIME_FORMATION_DATE), CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)

        strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_STERILEROOM_HV_ABNORMAL_INOUT_DETAIL, strCols, strValues)
        If Not TransactionExecute(strSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return False
        End If
        Return True
    End Function
#End Region
End Class
