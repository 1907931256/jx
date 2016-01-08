'********************************************************************
'	Title:			DBOperate
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-4-17
'	Description:    Data base Operate base class
'*********************************************************************

Option Explicit On
Option Strict On

Imports ITSBase
Imports DBAdapter
Imports System.Data.SqlClient

Public Class DBOperate
    Protected m_oDBConnect As SQLAdapter
    Protected m_strErrorReason As String
    '********************************************************************
    '	Title:			Constructor 
    '	Author:			FB
    '	Create Date:	2009-9-14
    '	Description:    Generally use the Synchronized (Singleton Instance In all application)
    '                   Some Multi Thread should use the self-governed Connection such as Monitor
    '                   In that time call it with False
    '*********************************************************************
    Public Sub New(Optional ByVal bSynchronized As Boolean = True)
        If bSynchronized Then
            m_oDBConnect = SingletonSQLConnection.Create
        Else
            m_oDBConnect = New SQLAdapter
        End If
        m_strErrorReason = ""
    End Sub
    '********************************************************************
    '	Title:			GetErrorReason
    ' 	Author:			FB
    '	Create Date:	2009-4-17
    '	Description:    Get last error string  
    '*********************************************************************
    ReadOnly Property GetErrorReason() As String
        Get
            GetErrorReason = m_strErrorReason
        End Get
    End Property
#Region "Method"
    Protected Sub CalcultateSum(ByRef dtResult As DataTable)
        Dim fSum As Decimal = 0
        Dim nCount As Integer = 0
        For Each dr As DataRow In dtResult.Rows
            fSum = fSum + CDec(dr.Item(TEXT_MONEY_SUM))
            nCount = nCount + CInt(dr.Item(TEXT_COUNT))
        Next

        dtResult.Rows.Add(dtResult.NewRow)
        Dim drNew As DataRow = dtResult.NewRow
        drNew(0) = TEXT_EXPENSE_STATISTIC_TOTAL_MONEY
        drNew(TEXT_COUNT) = nCount
        drNew(TEXT_MONEY_SUM) = fSum
        dtResult.Rows.Add(drNew)
    End Sub
    Protected Sub MergerTable(ByRef dtTarget As DataTable, ByVal dtSource As DataTable)
        If dtTarget Is Nothing OrElse dtSource Is Nothing Then
            Return
        End If

        For Each drRow As DataRow In dtSource.Rows
            Dim drNew As DataRow = dtTarget.NewRow
            drNew.Item(TEXT_INS_ID) = drRow.Item(TEXT_INS_ID)
            drNew.Item(TEXT_INS_NAME) = drRow.Item(TEXT_INS_NAME)
            drNew.Item(TEXT_INS_TYPE) = drRow.Item(TEXT_INS_TYPE)
            drNew.Item(TEXT_UNIT) = drRow.Item(TEXT_UNIT)
            drNew.Item(TEXT_INS_UNITPRICE) = drRow.Item(TEXT_INS_UNITPRICE)
            drNew.Item(TEXT_COUNT) = drRow.Item(TEXT_COUNT)
            drNew.Item(TEXT_MONEY_SUM) = drRow.Item(TEXT_MONEY_SUM)

            dtTarget.Rows.Add(drNew)
        Next
    End Sub
    Public Function GetServerDateTime(ByRef dtTime As DateTime) As Long
        Dim strSql As String = "select getdate() as 'ServerTime'"
        Dim ds As New DataSet

        If Not QuerySQL(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        dtTime = CDate(JudgeDataValue(ds.Tables(0).Rows(0).Item("ServerTime"), ENUM_DATA_TYPE.DATA_TYPE_DATE))
        ds.Dispose()
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    '********************************************************************
    '	Title:			QueryTotal
    ' 	Author:			FB
    '	Create Date:	2009-8-26
    '	Description:    Get Total Information according to the table name 
    '*********************************************************************
    Protected Function QueryTotal(ByRef dtResult As DataTable, ByVal strTable As String) As DBMEDITS_RESULT
        Dim strSql As String
        strSql = String.Format(DBCONSTDEF_SQL_SELECT, DBCONSTDEF_SQL_SELECT_ALL, strTable)
        Dim ds As New DataSet

        If Not QuerySQL(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
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
            Logger.WriteLine(m_strErrorReason, EVENT_ENTRY_TYPE.WARNING)
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        End If
    End Function

  
#End Region

#Region "DB Operate"
    Protected Function QuerySQL(ByVal strSql As String, ByRef dsResult As DataSet, Optional ByVal oSQLParameters As SqlParameters = Nothing) As Boolean
        If dsResult Is Nothing Then
            dsResult = New DataSet
        Else
            dsResult.Clear()
        End If

        If Not m_oDBConnect.QuerySQL(strSql, dsResult, oSQLParameters) Then
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_SQLQUERY_EXECUTE_EXCEPTION, m_oDBConnect.GetCommandString) & m_oDBConnect.GetErrorString
            Logger.WriteLine(m_strErrorReason)
            Return False
        End If
        Return True
    End Function

    Protected Function UpdateSQL(ByVal strSql As String, Optional ByVal oSQLParameters As SqlParameters = Nothing) As Boolean

        If Not m_oDBConnect.UpdateSQL(strSql, oSQLParameters) Then
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_SQLCOMMAND_EXECUTE_EXCEPTION, m_oDBConnect.GetCommandString) & m_oDBConnect.GetErrorString
            Logger.WriteLine(m_strErrorReason)
            Return False
        End If

        Return True
    End Function

    Protected Function TransactionBegin() As Boolean

        If Not m_oDBConnect.TransactionBegin() Then
            m_strErrorReason = m_oDBConnect.GetErrorString
            Logger.WriteLine(m_strErrorReason)
            Return False
        End If

        Return True

    End Function
    Protected Function TransactionExecute(ByVal strSQLCommand As String, Optional ByVal oSQLParameters As SqlParameters = Nothing, Optional ByVal oType As CommandType = CommandType.Text) As Boolean

        If Not m_oDBConnect.TransactionExecute(strSQLCommand, oSQLParameters, CommandType.Text) Then
            m_oDBConnect.CloseDB()
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_TRANSACTION_EXECUTE_EXCEPTION, m_oDBConnect.GetCommandString) & m_oDBConnect.GetErrorString
            Logger.WriteLine(m_strErrorReason, EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        Return True
    End Function

    Protected Function TransactionCommit() As Boolean

        If Not m_oDBConnect.TransactionCommit() Then
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_ERROR_TRANSACTION_COMMIT_EXCEPTION, m_oDBConnect.GetTransactionProcedure) & m_oDBConnect.GetErrorString
            Logger.WriteLine(m_strErrorReason)
            Return False
        End If

        Return True

    End Function
    Protected Function TransactionRollback() As Boolean

        If Not m_oDBConnect.TransactionRollback() Then
            m_strErrorReason = DBMEDITS_CONST_TEXT_ERROR_TRANSACTION_ROLLBACK_EXCEPTION & m_oDBConnect.GetErrorString
            Logger.WriteLine(m_strErrorReason)
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Tool"
    Protected Shared Function JudgeDataValue(ByVal objSourceObject As Object, ByVal enumDataType As ENUM_DATA_TYPE) As Object
        Return Judgement.JudgeDBNullValue(objSourceObject, enumDataType)
    End Function


   
#End Region

End Class
