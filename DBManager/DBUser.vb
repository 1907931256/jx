'********************************************************************
'	Title:			DBUser
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-7-20
'	Description:    
'*********************************************************************
Option Explicit On
Option Strict On

Imports ITSBase
Imports DBAdapter
Imports System.IO
Imports RegisterLib
Public Class DBUser
    Inherits DBOperate
    Public Sub New(Optional ByVal bSynchronized As Boolean = True)
        MyBase.New(bSynchronized)
    End Sub
  
    Public Function CheckUserIDExist(ByVal strID As String) As DBMEDITS_RESULT
        Dim strSql, strCondition As String
        strCondition = String.Format("{0}='{1}'", UR_ID, strID)
        strSql = String.Format(DBCONSTDEF_SQL_SELECT_WHERE, UR_ID, MST_USER_INFO, strCondition)
        Dim ds As New DataSet()
        If Not QuerySQL(strSql, ds) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return DBMEDITS_RESULT.ERROR_EXCEPTION
        End If
        m_oDBConnect.CloseDB()
        Dim nCount As Integer = ds.Tables(0).Rows.Count

        If nCount = 0 Then
            Return DBMEDITS_RESULT.ERROR_NOT_EXIST
        ElseIf nCount = 1 Then
            Return DBMEDITS_RESULT.ERROR_EXIST
        Else
            Return DBMEDITS_RESULT.ERROR_EXIST_OVERFLOW
        End If
    End Function


    'Public Function QueryTotalUser(ByRef dtUser As DataTable) As DBMEDITS_RESULT
    '    Dim lRet As DBMEDITS_RESULT = QueryTotal(dtUser, MST_USER_INFO)
    '    If lRet <> DBMEDITS_RESULT.SUCCESS Then
    '        Return lRet
    '    End If

    '    For Each dr As DataRow In dtUser.Rows
    '        Dim strEncrypt As String = CStr(JudgeDataValue(dr.Item(UR_PW), EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING))
    '        dr.Item(UR_PW) = XorHex.Decrypt(strEncrypt)
    '    Next

    '    Return DBMEDITS_RESULT.SUCCESS
    'End Function
    '********************************************************************
    '	Title:			QueryUserInfo
    '	Author:			cdx
    '	Create Date:	2010-7-1
    '	Description:    Get Total User  
    '   Operate Tables: MST_USER_INFO
    '*********************************************************************
    'Public Function QueryUserInfo(ByRef dtUser As DataTable) As DBMEDITS_RESULT
    '    dtUser.Clear()

    '    Dim strSql, strCols, strTables As String

    '    strCols = String.Format("{0} as '{1}',{2} as '{3}',{4} as '{5}',{6} as '{7}',{8} as '{9}'", _
    '                                 UR_ID, TEXT_USER_ID, _
    '                                 UR_NAME, TEXT_USER_NAME, _
    '                                 UR_PW, TEXT_USER_PWD, _
    '                                 UR_DEPART_NAME, TEXT_USER_DP, _
    '                                 UR_TYPE_NO, TEXT_ROLE)
    '    strTables = String.Format("{0}", MST_USER_INFO)
    '    strSql = String.Format(DBCONSTDEF_SQL_SELECT_ORDER, strCols, strTables, UR_ID)
    '    Dim ds As New DataSet
    '    If Not QuerySQL(strSql, ds) Then
    '        Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
    '        Return DBMEDITS_RESULT.ERROR_EXCEPTION
    '    End If

    '    If ds.Tables(0).Rows.Count = 0 Then Return DBMEDITS_RESULT.ERROR_NOT_EXIST
    '    For Each dr As DataRow In ds.Tables(0).Rows
    '        Dim drNew As DataRow = dtUser.NewRow
    '        drNew.Item(TEXT_USER_ID) = CStr(JudgeDataValue(dr.Item(TEXT_USER_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING))
    '        drNew.Item(TEXT_USER_NAME) = CStr(JudgeDataValue(dr.Item(TEXT_USER_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING))
    '        Dim strEncrypt As String = CStr(JudgeDataValue(dr.Item(TEXT_USER_PWD), EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING))
    '        drNew.Item(TEXT_USER_PWD) = XorHex.Decrypt(strEncrypt)
    '        drNew.Item(TEXT_USER_DP) = CStr(JudgeDataValue(dr.Item(TEXT_USER_DP), ENUM_DATA_TYPE.DATA_TYPE_STRING))
    '        drNew.Item(TEXT_ROLE) = TransDef.MatchUserRoleToString(CShort(JudgeDataValue(dr.Item(TEXT_ROLE), ENUM_DATA_TYPE.DATA_TYPE_STRING)))

    '        dtUser.Rows.Add(drNew)
    '    Next
    '    ds.Dispose()
    '    Return DBMEDITS_RESULT.SUCCESS
    'End Function

    '********************************************************************
    '	Title:			InsertUser
    '	Author:			cdx
    '	Create Date:	2009-9-24
    '	Description:    Register new User
    '   Operate Tables: MST_USER_INFO
    '*********************************************************************
    'Public Function InsertUser(ByVal oUser As UserInfo) As DBMEDITS_RESULT

    '    'Set record into MST_USER_INFO
    '    Dim strCols, strValues, strSql As String
    '    strCols = String.Format("{0},{1},{2},{3},{4}", _
    '                           UR_ID, UR_NAME, UR_PW, _
    '                           UR_DEPART_NAME, UR_TYPE_NO)

    '    Dim strDecrypt As String = oUser.m_strPassword
    '    strValues = String.Format("'{0}','{1}','{2}','{3}','{4}'", _
    '                                MakeSQLInputPattern(oUser.m_strUserID), _
    '                                MakeSQLInputPattern(oUser.m_strFullName), _
    '                                XorHex.Encrypt(strDecrypt), _
    '                                MakeSQLInputPattern(oUser.m_strDPName), _
    '                                oUser.m_shRole)

    '    strSql = String.Format(DBCONSTDEF_SQL_INSERT_FULL, MST_USER_INFO, strCols, strValues)

    '    If Not UpdateSQL(strSql) Then
    '        Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
    '        Return DBMEDITS_RESULT.ERROR_EXCEPTION
    '    End If

    '    Return DBMEDITS_RESULT.SUCCESS
    'End Function

    '********************************************************************
    '	Title:			ModifyUserInfo
    '	Author:			cdx
    '	Create Date:	2009-9-24
    '	Description:    Modify User Info
    '   Operate Tables: MST_USER_INFO
    '*********************************************************************
    'Public Function ModifyUserInfo(ByVal strUserID As String, ByVal oUser As UserInfo) As DBMEDITS_RESULT
    '    Dim strCondition, strValues, strSql As String

    '    strCondition = String.Format("{0}='{1}'", UR_ID, strUserID)
    '    Dim strDecrypt As String = oUser.m_strPassword
    '    strValues = String.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}'", _
    '                                UR_NAME, MakeSQLInputPattern(oUser.m_strFullName), _
    '                                UR_PW, XorHex.Encrypt(strDecrypt), _
    '                                UR_DEPART_NAME, MakeSQLInputPattern(oUser.m_strDPName), _
    '                                UR_TYPE_NO, oUser.m_shRole)

    '    strSql = String.Format(DBCONSTDEF_SQL_UPDATE_WHERE, MST_USER_INFO, strValues, strCondition)

    '    If Not UpdateSQL(strSql) Then
    '        Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
    '        Return DBMEDITS_RESULT.ERROR_EXCEPTION
    '    End If

    '    Return DBMEDITS_RESULT.SUCCESS
    'End Function

    '********************************************************************
    '	Title:			DeleteUserInfoByID
    '	Author:			cdx
    '	Create Date:	2009-9-24
    '	Description:    Delete User Info By ID
    '   Operate Tables: MST_USER_INFO
    '*********************************************************************
    Public Function DeleteUserInfoByID(ByVal strUserID As String) As Boolean

        Dim strCondition, strSql As String
        strCondition = String.Format("{0}='{1}'", UR_ID, strUserID)

        strSql = String.Format(DBCONSTDEF_SQL_DELETE_WHERE, MST_USER_INFO, strCondition)

        If Not UpdateSQL(strSql) Then
            Logger.WriteLine(DBMEDITS_CONST_TEXT_ERROR_EXCEPTION)
            Return False
        End If

        Return True
    End Function

End Class