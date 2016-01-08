Option Explicit On
Option Strict On

Imports System.Data.OleDb
Public Class OleDbParameters
    Inherits List(Of OleDbParameter)
    Private m_stIDKey As String

    Public ReadOnly Property Parameters(ByVal strItemName As String) As OleDbParameter
        Get
            m_stIDKey = strItemName
            Return MyBase.Find(AddressOf FindItem)
        End Get
    End Property

    Public Overloads Function Add(ByVal strName As String, ByVal oType As SqlDbType) As OleDbParameter
        Dim oItem As New OleDbParameter(strName, oType)
        MyBase.Add(oItem)
        Return oItem
    End Function

    Public Function AddWithValue(ByVal strName As String, ByVal oValue As Object) As OleDbParameter
        Dim oItem As New OleDbParameter(strName, oValue)
        MyBase.Add(oItem)
        Return oItem
    End Function

    Protected Function FindItem(ByVal oOleDbParameter As OleDbParameter) As Boolean
        Return oOleDbParameter.ParameterName = m_stIDKey
    End Function

End Class
Public Class SingletonOleDbConnection
    Inherits OleDbAdapter
    Private Shared m_Instance As SingletonOleDbConnection = Nothing
    Private Sub New()
        MyBase.New()
    End Sub

    Public Shared Function Create() As SingletonOleDbConnection
        If m_Instance Is Nothing Then
            m_Instance = New SingletonOleDbConnection
        End If

        Return m_Instance
    End Function
End Class
Public Class OleDbAdapter
    Inherits ConnectionBase
    Private m_oOleDbCon As OleDbConnection          'connection to access
    Private m_oTransDBCommand As OleDbCommand
    Public Sub New()
        MyBase.new()
        m_oOleDbCon = New OleDbConnection

        m_oOleDbCon.ConnectionString = OleConnectionString.GetConnectString

        m_oTransDBCommand = Nothing
    End Sub

    Public Function OpenDB() As Boolean

        ResetString()

        If m_oOleDbCon.State = ConnectionState.Open Then
            Return True
        ElseIf m_oOleDbCon.State = ConnectionState.Closed Then
            Try
                m_oOleDbCon.Open()
                Return True
            Catch ex As Exception
                m_strErrorString = ERRORCONSTDEF_CONNECT_STRING + m_oOleDbCon.ConnectionString + vbCrLf + ex.ToString()
            End Try
        End If

        Return False
    End Function

    Public Function CloseDB() As Boolean

        If m_oTransDBCommand IsNot Nothing Then Return True 'continue Transaction

        If m_oOleDbCon.State = ConnectionState.Closed Then
            Return True
        Else
            Try
                m_oOleDbCon.Close()
                Return True
            Catch Ex As Exception
                m_strErrorString = m_strErrorString & Ex.ToString()
            End Try
        End If

        Return False
    End Function

    Public Overloads Function QueryOleDb(ByVal strOleCommand As String, ByRef dsResult As DataSet, Optional ByVal oOleParameters As OleDbParameters = Nothing) As Boolean

        If Not OpenDB() Then Return False
        SetCommandString(strOleCommand, oOleParameters)

        Dim oDBCommand As New OleDbCommand(strOleCommand, m_oOleDbCon)
        PassParameter(oDBCommand, oOleParameters)

        Dim oDBAdapter As New OleDbDataAdapter
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
    Public Overloads Function UpdateOleDb(ByVal strOleCommand As String, Optional ByVal oOleParameters As OleDbParameters = Nothing) As Boolean

        If Not OpenDB() Then Return False
        SetCommandString(strOleCommand, oOleParameters)

        Dim oDBCommand As New OleDbCommand(strOleCommand, m_oOleDbCon)
        PassParameter(oDBCommand, oOleParameters)

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

        m_oTransDBCommand = m_oOleDbCon.CreateCommand
        m_oTransDBCommand.Connection = m_oOleDbCon
        m_oTransDBCommand.Transaction = m_oOleDbCon.BeginTransaction

        Return True

    End Function

    Public Overloads Function TransactionExecute(ByVal strSQLCommand As String, Optional ByRef oOleParameters As OleDbParameters = Nothing, Optional ByVal oType As CommandType = CommandType.Text) As Boolean

        m_strErrorString = ""
        SetCommandString(strSQLCommand, oOleParameters)

        If m_oTransDBCommand Is Nothing Then
            m_strErrorString = ERRORCONSTDEF_TRANSACTION_NOTHING
            CloseDB()
            Return False
        End If

        m_oTransDBCommand.CommandText = strSQLCommand
        m_oTransDBCommand.CommandType = oType
        m_oTransDBCommand.Parameters.Clear()

        PassParameter(m_oTransDBCommand, oOleParameters)

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

    Private Sub SetCommandString(ByVal strCommandText As String, ByRef oParameters As OleDbParameters)
        Dim strCommandParameters As String = ""
        If oParameters IsNot Nothing Then
            For Each oParameter As OleDbParameter In oParameters

                strCommandParameters += String.Format(ERRORCONSTDEF_COMMAND_PARAMETERS, _
                                                oParameter.ParameterName.ToString, _
                                                oParameter.Direction.ToString, _
                                                oParameter.OleDbType.ToString, _
                                                oParameter.Value.ToString)

            Next
        End If
        m_strCommandString = String.Format(ERRORCONSTDEF_COMMANDTEXT, strCommandText.ToString) + strCommandParameters
    End Sub

    Private Sub PassParameter(ByRef oDBCommand As OleDbCommand, ByVal oOleDbParameters As OleDbParameters)
        If oDBCommand Is Nothing Then Exit Sub
        If oOleDbParameters Is Nothing Then Exit Sub

        For Each oParameter As OleDbParameter In oOleDbParameters
            oDBCommand.Parameters.Add(oParameter)
        Next
    End Sub
End Class