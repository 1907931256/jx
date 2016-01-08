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
    '********************************************************************
    '	Title:			QueryTotal
    ' 	Author:			FB
    '	Create Date:	2009-8-26
    '	Description:    Get Total Information according to the table name 
    '*********************************************************************
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
    Public Function QueryPackageInfo(ByRef oPackageInfo As PackageInfo, ByVal lPackageID As Long) As DBMEDITS_RESULT
        If oPackageInfo Is Nothing Then
            oPackageInfo = New PackageInfo
        Else
            oPackageInfo.Reset()
        End If
        Dim strCon, strSQl As String
        strCon = String.Format("{0}={1}", SRS_PACKAGE_ID, lPackageID)
        strSQl = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, DBCONSTDEF_SQL_SELECT_ALL, TBL_STERILEROOM_RU_STOCK, strCon)
        Dim ds As New DataSet
        If Not QueryOleDb(strSQl, ds) Then
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If ds.Tables(0).Rows.Count = 1 Then
            oPackageInfo.m_lPackageID = CLng(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_PACKAGE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_strINSID = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_strINSName = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_strINSType = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_TYPE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_strINSUnit = CStr(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING))
            oPackageInfo.m_datSterilize = CDate(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_STERILIZE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            oPackageInfo.m_datAvailable = CDate(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE))
            oPackageInfo.m_nSterilizRoomID = CInt(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_STERILIZE_ROOM_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            oPackageInfo.m_shPackageState = CShort(Judgement.JudgeDBNullValue(ds.Tables(0).Rows(0).Item(SRS_AVAILABLE_DATE), ENUM_DATA_TYPE.DATA_TYPE_STRING))
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

        strCols = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", _
                                DSAID_REG_ID, DSAID_DRUG_CODE, DSAID_DRUG_COMMON_NAME, DSAID_DRUG_PRODUCT_NAME, _
                                DSAID_DRUG_MEASUER_UNITS, DSAID_MANUFACTURERS, DSAID_SPECIFICATION, _
                                DSAID_DRUG_COUNT, DSAID_PRODUCE_DATE, DSAID_BATCH_ID, DSAID_AVAILABLE_DATE, DSAID_DRUG_UNIT)

        For Each dr As DataRow In dt.Rows

            strValues = String.Format("{0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},to_date('{8}','{11}'),'{9}',to_date('{10}','{11}'),'{12}'", _
                              lRegID, CStr(dr.Item(TEXT_DRUG_ID)), _
                              CStr(dr.Item(TEXT_DRUG_COMMON_NAME)), _
                              CStr(dr.Item(TEXT_DRUG_PRODUCT_NAME)), _
                              CStr(dr.Item(TEXT_DRUG_UNIT)), _
                              CStr(dr.Item(TEXT_DRUG_FACTORY)), _
                              CStr(dr.Item(TEXT_DRUG_SPECIFICATION)), _
                              CInt(dr.Item(TEXT_DRUG_AMOUNT)), _
                              CDate(dr.Item(TEXT_DRUG_MFG)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                               CStr(dr.Item(TEXT_DRUG_BATCHNO)), _
                               CDate(dr.Item(TEXT_DRUG_EXPIRE)).ToString(TEXT_DATETIME_FORMATION_DATE), _
                              CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD, _
                              CStr(dr.Item(TEXT_DRUG_STOCK_UNIT)))
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
                          lRegID, oPackage.m_strINSID, _
                          oPackage.m_strINSName, _
                         oPackage.m_strINSType, _
                         oPackage.m_strINSUnit, _
                           oPackage.m_lPackageID, _
                           oPackage.m_datAvailable.ToString(TEXT_DATETIME_FORMATION_DATE), _
                          CONST_TEXT_ORACLE_DATETIME_FORMAT_YYYYMMDD)
        strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, LOG_RU_ABNORMAL_INOUT_DETAIL, strCols, strValues)
        If Not TransactionExecute(strSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return False
        End If
        Return True
    End Function


#End Region

    Private Function TransactionExecute(strSql As String, oParameters As SqlParameters) As Boolean
        Throw New NotImplementedException
    End Function

End Class
