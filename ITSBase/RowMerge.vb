'********************************************************************
'	Title:			RowMerge
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-9-15
'	Description:    
'*********************************************************************
Option Explicit On
Option Strict On

Imports System.Data
Imports ITSBase

Public Class RowMerge
    Public Class MergeColInfo
        Public m_strColName As String
        Public m_oType As Type
        Public Sub New(ByVal strColName As String, ByVal oType As Type)
            m_strColName = strColName
            m_oType = oType
        End Sub
    End Class
    Public Delegate Function FunTypeInvalid(ByVal oType As Type) As Boolean

    Public Shared Function RowMergeCountAndSUM(ByRef dt As DataTable, ByRef dr As DataRow, ByVal strKeyColName As String, ByVal strCountColName As String, ByVal strSUMColName As String) As Boolean
        If Not CheckTableStyle(dt, dr.Table) Then Return False

        If Not dt.Columns.Contains(strKeyColName) Then Return False
        If Not dt.Columns.Contains(strCountColName) Then Return False
        If Not dt.Columns.Contains(strSUMColName) Then Return False

        Dim strFilter As String = String.Format("{0}='{1}'", strKeyColName, dr.Item(strKeyColName).ToString)
        Dim arrdrFind As DataRow() = dt.Select(strFilter)
        If arrdrFind.Length > 1 Then Return False

        If arrdrFind.Length = 0 Then
            Try
                dt.Rows.Add(dr)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

        If IsDBNull(arrdrFind(0).Item(strCountColName)) Then
            arrdrFind(0).Item(strCountColName) = CInt(dr.Item(strCountColName))
        Else
            arrdrFind(0).Item(strCountColName) = CInt(arrdrFind(0).Item(strCountColName)) + CInt(dr.Item(strCountColName))
        End If
        If IsDBNull(arrdrFind(0).Item(strSUMColName)) Then
            arrdrFind(0).Item(strSUMColName) = CSng(dr.Item(strSUMColName))
        Else
            arrdrFind(0).Item(strSUMColName) = CSng(arrdrFind(0).Item(strSUMColName)) + CSng(dr.Item(strSUMColName))
        End If

        Return True
    End Function
    Public Shared Function RowMergeCountAndSUM(ByRef dt As DataTable, ByRef dr As DataRow, ByVal strKeyColName As String, ByVal strCountColName As String, ByVal strPriceColName As String, ByVal strSUMColName As String) As Boolean
        If Not CheckTableStyle(dt, dr.Table) Then Return False

        If Not dt.Columns.Contains(strKeyColName) Then Return False
        If Not dt.Columns.Contains(strCountColName) Then Return False
        If Not dt.Columns.Contains(strSUMColName) Then Return False

        Dim strFilter As String = String.Format("{0}='{1}'", strKeyColName, dr.Item(strKeyColName).ToString)
        Dim arrdrFind As DataRow() = dt.Select(strFilter)
        If arrdrFind.Length > 1 Then Return False

        If arrdrFind.Length = 0 Then
            Try
                dr.Item(strSUMColName) = CInt(dr.Item(strCountColName)) * CSng(dr.Item(strPriceColName))
                dt.Rows.Add(dr)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

        If IsDBNull(arrdrFind(0).Item(strCountColName)) Then
            arrdrFind(0).Item(strCountColName) = CInt(dr.Item(strCountColName))
        Else
            arrdrFind(0).Item(strCountColName) = CInt(arrdrFind(0).Item(strCountColName)) + CInt(dr.Item(strCountColName))
        End If
        arrdrFind(0).Item(strSUMColName) = CInt(arrdrFind(0).Item(strCountColName)) * CSng(dr.Item(strPriceColName))
        Return True
    End Function
    Public Shared Function RowMergeCount(ByRef dt As DataTable, ByRef dr As DataRow, ByVal strKeyColName As String, ByVal strCountColName As String) As Boolean
        If Not CheckTableStyle(dt, dr.Table) Then Return False

        If Not dt.Columns.Contains(strKeyColName) Then Return False
        If Not dt.Columns.Contains(strCountColName) Then Return False

        Dim strFilter As String = String.Format("{0}='{1}'", strKeyColName, dr.Item(strKeyColName).ToString)
        Dim arrdrFind As DataRow() = dt.Select(strFilter)
        If arrdrFind.Length > 1 Then Return False

        If arrdrFind.Length = 0 Then
            Try
                dt.Rows.Add(dr)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

        If IsDBNull(arrdrFind(0).Item(strCountColName)) Then
            arrdrFind(0).Item(strCountColName) = CInt(Judgement.JudgeDBNullValue(dr.Item(strCountColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
        Else
            arrdrFind(0).Item(strCountColName) = CInt(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strCountColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)) + CInt(Judgement.JudgeDBNullValue(dr.Item(strCountColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))

        End If
        Return True
    End Function
    Public Shared Function RowMergeCount(ByRef dt As DataTable, ByRef dr As DataRow, ByVal strCountColName As String, ByVal ParamArray arrKeyColName As String()) As Boolean
        If Not CheckTableStyle(dt, dr.Table) Then Return False

        For Each strKeyName As String In arrKeyColName
            If Not dt.Columns.Contains(strKeyName) Then Return False
        Next
        If Not dt.Columns.Contains(strCountColName) Then Return False

        Dim strFilter As String = String.Empty
        For Each strKeyName As String In arrKeyColName
            If strFilter.Length = 0 Then
                strFilter = String.Format("{0}='{1}'", strKeyName, dr.Item(strKeyName).ToString)
            Else
                strFilter = String.Format("{0} and {1}='{2}'", strFilter, strKeyName, dr.Item(strKeyName).ToString)
            End If
        Next

        Dim arrdrFind As DataRow() = dt.Select(strFilter)
        If arrdrFind.Length > 1 Then Return False

        If arrdrFind.Length = 0 Then
            Try
                dt.Rows.Add(dr)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

        If IsDBNull(arrdrFind(0).Item(strCountColName)) Then
            arrdrFind(0).Item(strCountColName) = CInt(Judgement.JudgeDBNullValue(dr.Item(strCountColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
        Else
            arrdrFind(0).Item(strCountColName) = CInt(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strCountColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)) + CInt(Judgement.JudgeDBNullValue(dr.Item(strCountColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))

        End If
        Return True
    End Function
    Public Shared Function RowMerge(ByRef dt As DataTable, ByRef dr As DataRow, ByVal oKeyInfo As MergeColInfo, ByVal ParamArray arrInfo() As MergeColInfo) As Boolean
        If Not CheckTableStyle(dt, dr.Table) Then Return False

        If Not CheckMergeColInfo(dt, oKeyInfo) Then Return False

        For Each oInfo As MergeColInfo In arrInfo
            If Not CheckNumericMergeColInfo(dt, oInfo) Then Return False
        Next

        Dim strFilter As String

        If oKeyInfo.m_oType Is GetType(String) Then
            strFilter = String.Format("{0}='{1}'", oKeyInfo.m_strColName, dr.Item(oKeyInfo.m_strColName).ToString)
        Else
            strFilter = String.Format("{0}={1}", oKeyInfo.m_strColName, dr.Item(oKeyInfo.m_strColName))
        End If

        Dim arrdrFind As DataRow() = Nothing

        Try
            arrdrFind = dt.Select(strFilter)
        Catch ex As Exception
            Return False
        End Try

        If arrdrFind.Length > 1 Then Return False

        If arrdrFind.Length = 0 Then
            Try
                dt.Rows.Add(dr)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
     
        For Each oInfo As MergeColInfo In arrInfo
            Dim strColName As String = oInfo.m_strColName
            Dim oType As Type = oInfo.m_oType

            If oInfo.m_oType Is GetType(Short) Then
                arrdrFind(0).Item(strColName) = _
                CShort(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)) + _
                CShort(Judgement.JudgeDBNullValue(dr.Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            ElseIf oInfo.m_oType Is GetType(Integer) Then
                arrdrFind(0).Item(strColName) = _
                CInt(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)) + _
                CInt(Judgement.JudgeDBNullValue(dr.Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            ElseIf oInfo.m_oType Is GetType(Long) Then
                arrdrFind(0).Item(strColName) = _
               CLng(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)) + _
               CLng(Judgement.JudgeDBNullValue(dr.Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_INTEGER))
            ElseIf oInfo.m_oType Is GetType(Single) Then
                arrdrFind(0).Item(strColName) = _
                CSng(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_FLOAT)) + _
                CSng(Judgement.JudgeDBNullValue(dr.Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_FLOAT))
            ElseIf oInfo.m_oType Is GetType(Double) Then
                arrdrFind(0).Item(strColName) = _
                CDbl(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_FLOAT)) + _
                CDbl(Judgement.JudgeDBNullValue(dr.Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_FLOAT))
            ElseIf oInfo.m_oType Is GetType(Decimal) Then
                arrdrFind(0).Item(strColName) = _
                CDec(Judgement.JudgeDBNullValue(arrdrFind(0).Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_FLOAT)) + _
                CDec(Judgement.JudgeDBNullValue(dr.Item(strColName), ENUM_DATA_TYPE.DATA_TYPE_FLOAT))
            Else
                Return False
            End If

        Next


        Return True
    End Function
    Public Shared Function CheckMergeColInfo(ByVal dt As DataTable, ByVal oKeyInfo As MergeColInfo) As Boolean
        Dim Fun As FunTypeInvalid = New FunTypeInvalid(AddressOf IsType)
        Return CheckMergeColInfoBase(dt, oKeyInfo, Fun)
    End Function

    Public Shared Function CheckNumericMergeColInfo(ByVal dt As DataTable, ByVal oKeyInfo As MergeColInfo) As Boolean
        Dim Fun As FunTypeInvalid = New FunTypeInvalid(AddressOf IsNumericType)
        Return CheckMergeColInfoBase(dt, oKeyInfo, Fun)
    End Function

    Private Shared Function CheckMergeColInfoBase(ByVal dt As DataTable, ByVal oKeyInfo As MergeColInfo, ByVal Fun As FunTypeInvalid) As Boolean
        If Not dt.Columns.Contains(oKeyInfo.m_strColName) Then Return False
        Return Fun(oKeyInfo.m_oType)
        Return True
    End Function

    Private Shared Function IsNumericType(ByVal oType As Type) As Boolean
        If oType IsNot GetType(Short) AndAlso _
           oType IsNot GetType(Integer) AndAlso _
           oType IsNot GetType(Long) AndAlso _
           oType IsNot GetType(Single) AndAlso _
           oType IsNot GetType(Double) AndAlso _
           oType IsNot GetType(Decimal) Then
            Return False
        End If

        Return True
    End Function
    Private Shared Function IsType(ByVal oType As Type) As Boolean

        If IsNumericType(oType) Then Return True
        If oType IsNot GetType(String) Then Return False

        Return True
    End Function
    Public Shared Function CheckTableStyle(ByRef dtActual As DataTable, ByRef dtExpected As DataTable) As Boolean
        If dtActual Is Nothing Then Return False
        If dtExpected Is Nothing Then Return False

        For Each dc As DataColumn In dtActual.Columns
            If Not dtExpected.Columns.Contains(dc.ColumnName) Then Return False
        Next

        Return True

    End Function

End Class
