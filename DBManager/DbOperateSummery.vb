Imports ITSBase

Public Class DbOperateSummery
    Inherits DBOperateOle

    Protected Function QueryTable(ByVal strSql As String, ByRef tableQuery As DataTable) As EnumDef.DBMEDITS_RESULT
        Dim ds As New DataSet
        If Not QueryOleDb(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION + m_strErrorReason)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If

        If ds.Tables.Count > 0 Then
            tableQuery = ds.Tables(0)
        End If
        If ds.Tables(0).Rows.Count = 0 Then
            ds.Dispose()
            m_strErrorReason = String.Format(DBMEDITS_CONST_TEXT_LOG_DB_ERROR_NOT_EXIST, TBL_WASH_DISINFECT_DETAIL, m_oDBConnect.GetCommandString)
            Logger.WriteLine(m_strErrorReason, EVENT_ENTRY_TYPE.ERRORR)
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        Else
            Return DBMEDITS_RESULT.SUCCESS
        End If
    End Function

    Protected Function GetScopeIdentity(ByRef aiid As Long) As Long
        Dim sql = "Select SCOPE_IDENTITY() as AIID"
        Dim table As New DataTable
        If DBMEDITS_RESULT.SUCCESS <> QueryTable(sql, table) Then
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        If table.IsNullOrEmpty() Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        End If
        aiid = Judgement.JudgeDBNullValue(table.Rows(0).Item("AIID"), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
        Return DBMEDITS_RESULT.SUCCESS
    End Function

    Protected Function GetPrimaryKeyValue(ByRef aiid As Long, seqName As String) As Boolean
        Try
            Dim keyTable As DataTable = New DataTable
            Dim keySql As String = String.Format("select {0}.currval as curIndex from dual", seqName)
            If DBMEDITS_RESULT.SUCCESS = QueryTable(keySql, keyTable) Then
                If Not keyTable.IsNullOrEmpty() Then
                    aiid = CLng(keyTable.Rows(0).Item("curIndex"))
                    Return True
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

End Class
