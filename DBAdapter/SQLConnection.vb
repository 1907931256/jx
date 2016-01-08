Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class SqlParameters
    Inherits List(Of SqlParameter)
    Private m_stIDKey As String

    Public ReadOnly Property Parameters(ByVal strItemName As String) As SqlParameter
        Get
            m_stIDKey = strItemName
            Return MyBase.Find(AddressOf FindItem)
        End Get
    End Property

    Public Overloads Function Add(ByVal strName As String, ByVal oType As SqlDbType) As SqlParameter
        Dim oItem As New SqlParameter(strName, oType)
        MyBase.Add(oItem)
        Return oItem
    End Function

    Public Function AddWithValue(ByVal strName As String, ByVal oValue As Object) As SqlParameter
        Dim oItem As New SqlParameter(strName, oValue)
        MyBase.Add(oItem)
        Return oItem
    End Function

    Protected Function FindItem(ByVal oSqlParameter As SqlParameter) As Boolean
        Return oSqlParameter.ParameterName = m_stIDKey
    End Function

    Public Overloads Sub Add(myParm As OleDbParameters)
        Throw New NotImplementedException
    End Sub

End Class
Public Class SingletonSQLConnection
    Inherits SQLAdapter
    Private Shared m_Instance As SingletonSQLConnection = Nothing
    Private Sub New()
        MyBase.New()
    End Sub

    Public Shared Function Create() As SingletonSQLConnection
        If m_Instance Is Nothing Then
            m_Instance = New SingletonSQLConnection
        End If

        Return m_Instance
    End Function
End Class

Public Class SQLAdapter
    Inherits ConnectionBase
    Private m_oSqlCon As SqlConnection          'connection to SQL Server
    Private m_oTransDBCommand As SqlCommand
    Public Sub New()
        MyBase.new()
        m_oSqlCon = New SqlConnection
        m_oSqlCon.ConnectionString = SQLConnectionString.GetConnectString
        m_oTransDBCommand = Nothing
    End Sub

    Public Function OpenDB() As Boolean

        ResetString()

        If m_oSqlCon.State = ConnectionState.Open Then
            Return True
        ElseIf m_oSqlCon.State = ConnectionState.Closed Then
            Try
                m_oSqlCon.Open()
                Return True
            Catch ex As Exception
                m_strErrorString = ERRORCONSTDEF_CONNECT_STRING + m_oSqlCon.ConnectionString + vbCrLf + ex.ToString()
            End Try
        End If

        Return False
    End Function

    Public Function CloseDB() As Boolean

        If m_oTransDBCommand IsNot Nothing Then Return True 'continue Transaction

        If m_oSqlCon.State = ConnectionState.Closed Then
            Return True
        Else
            Try
                m_oSqlCon.Close()
                Return True
            Catch Ex As Exception
                m_strErrorString = m_strErrorString & Ex.ToString()
            End Try
        End If

        Return False
    End Function

    Public Overloads Function QuerySQL(ByVal strSQLCommand As String, ByRef dsResult As DataSet, Optional ByVal oSQLParameters As SqlParameters = Nothing) As Boolean

        If Not OpenDB() Then Return False
        SetCommandString(strSQLCommand, oSQLParameters)

        Dim oDBCommand As New SqlCommand(strSQLCommand, m_oSqlCon)
        PassParameter(oDBCommand, oSQLParameters)

        Dim oDBAdapter As New SqlDataAdapter
        oDBAdapter.SelectCommand = oDBCommand

        Try
            oDBAdapter.Fill(dsResult)
        Catch ex As Exception
            m_strErrorString = ex.ToString()
            Return False
        Finally
            oDBCommand.Dispose()
            oDBAdapter.Dispose()
            CloseDB()
        End Try

        Return True

    End Function

    Public Overloads Function UpdateSQL(ByVal strSQLCommand As String, Optional ByVal oSQLParameters As SqlParameters = Nothing) As Boolean

        If Not OpenDB() Then Return False
        SetCommandString(strSQLCommand, oSQLParameters)

        Dim oDBCommand As New SqlCommand(strSQLCommand, m_oSqlCon)
        PassParameter(oDBCommand, oSQLParameters)

        Try
            oDBCommand.ExecuteNonQuery()
        Catch ex As Exception
            m_strErrorString = ex.ToString()
            Return False
        Finally
            oDBCommand.Dispose()
            CloseDB()
        End Try

        Return True

    End Function

    Public Overloads Function TransactionBegin() As Boolean

        If Not OpenDB() Then Return False
        If m_oTransDBCommand IsNot Nothing Then
            m_strErrorString = ERRORCONSTDEF_TRANSACTION_EXIST
            CloseDB()
            Return False
        End If

        m_oTransDBCommand = m_oSqlCon.CreateCommand
        m_oTransDBCommand.Connection = m_oSqlCon
        m_oTransDBCommand.Transaction = m_oSqlCon.BeginTransaction

        Return True

    End Function

    Public Overloads Function TransactionExecute(ByVal strSQLCommand As String, Optional ByVal oSQLParameters As SqlParameters = Nothing, Optional ByVal oType As CommandType = CommandType.Text) As Boolean

        m_strErrorString = ""
        SetCommandString(strSQLCommand, oSQLParameters)

        If m_oTransDBCommand Is Nothing Then
            m_strErrorString = ERRORCONSTDEF_TRANSACTION_NOTHING
            CloseDB()
            Return False
        End If

        m_oTransDBCommand.CommandText = strSQLCommand
        m_oTransDBCommand.CommandType = oType
        m_oTransDBCommand.Parameters.Clear()

        PassParameter(m_oTransDBCommand, oSQLParameters)

        Try
            m_oTransDBCommand.ExecuteNonQuery()
            m_arrTransProcedure.Add(m_strCommandString)
            Return True
        Catch ex As Exception
            m_oTransDBCommand.Transaction.Rollback()
            m_strErrorString = ex.ToString()
            m_oTransDBCommand.Dispose()
            m_oTransDBCommand = Nothing
            CloseDB()
            Return False
        End Try

    End Function

    Public Overloads Function TransactionCommit() As Boolean
        m_strErrorString = ""
        m_strCommandString = ""

        If m_oTransDBCommand Is Nothing Then
            m_strErrorString = ERRORCONSTDEF_TRANSACTION_NOTHING
            CloseDB()
            Return False
        End If

        Try
            m_oTransDBCommand.Transaction.Commit()
        Catch ex As Exception
            m_oTransDBCommand.Transaction.Rollback()
            m_strErrorString = ex.ToString()
            Return False
        Finally
            m_oTransDBCommand.Dispose()
            m_oTransDBCommand = Nothing
            CloseDB()
        End Try

        Return True

    End Function

    Public Overloads Function TransactionRollback() As Boolean
        m_strErrorString = ""
        m_strCommandString = ""

        If m_oTransDBCommand Is Nothing Then
            m_strErrorString = ERRORCONSTDEF_TRANSACTION_NOTHING
            CloseDB()
            Return False
        End If

        Try
            m_oTransDBCommand.Transaction.Rollback()
        Catch ex As Exception
            m_strErrorString = ex.ToString()
            Return False
        Finally
            m_oTransDBCommand.Dispose()
            m_oTransDBCommand = Nothing
            CloseDB()
        End Try

        Return True
    End Function

    Private Sub SetCommandString(ByVal strCommandText As String, ByVal oParameters As SqlParameters)
        Dim strCommandParameters As String = ""
        If oParameters IsNot Nothing Then
            For Each oParameter As SqlParameter In oParameters

                strCommandParameters += String.Format(ERRORCONSTDEF_COMMAND_PARAMETERS, _
                                                oParameter.ParameterName.ToString, _
                                                oParameter.Direction.ToString, _
                                                oParameter.SqlDbType.ToString, _
                                                oParameter.Value.ToString)

            Next
        End If
        m_strCommandString = String.Format(ERRORCONSTDEF_COMMANDTEXT, strCommandText.ToString) + strCommandParameters
    End Sub

    Private Sub PassParameter(ByRef oDBCommand As SqlCommand, ByVal oSQLParameters As SqlParameters)
        If oDBCommand Is Nothing Then Exit Sub
        If oSQLParameters Is Nothing Then Exit Sub

        For Each oParameter As SqlParameter In oSQLParameters
            oDBCommand.Parameters.Add(oParameter)
        Next
    End Sub

End Class

