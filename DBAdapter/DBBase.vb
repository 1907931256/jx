Option Explicit On
Option Strict On

Imports System.IO
Imports System.Xml

Public MustInherit Class ConnectionBase
    Protected m_strErrorString As String          'Error Reason
    Protected m_strCommandString As String        'Command
    Protected m_arrTransProcedure As ArrayList    'Transaction Procedure

    Public Sub New()
        ResetString()
    End Sub
    Protected Sub ResetString()
        m_strErrorString = ""
        m_strCommandString = ""
        If m_arrTransProcedure Is Nothing Then
            m_arrTransProcedure = New ArrayList
        Else
            m_arrTransProcedure.Clear()
        End If
    End Sub
    Public Function GetErrorString() As String
        Return m_strErrorString
    End Function
    Public Function GetCommandString() As String
        Return m_strCommandString
    End Function
    Public Function GetTransactionProcedure() As String
        Dim strTransProcedure As String = ""
        For Each strSingle As String In m_arrTransProcedure
            strTransProcedure += String.Format("{{{0}}}", strSingle)
        Next
        Return strTransProcedure
    End Function

End Class

Public Class SQLConnectionString

    Private Shared m_Instance As SQLConnectionString = Nothing
    Private m_strServer As String     'Database server: 192.168.1.149
    Private m_strUserName As String   'user name
    Private m_strPWD As String        'password
    Private m_strInstance As String   'Instance name
    Private m_nTimeOut As Integer     'Timeout

    Public Property ServerName() As String
        Get
            ServerName = m_strServer
        End Get
        Set(ByVal value As String)
            m_strServer = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            UserName = m_strUserName
        End Get
        Set(ByVal value As String)
            m_strUserName = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Password = m_strPWD
        End Get
        Set(ByVal value As String)
            m_strPWD = value
        End Set
    End Property
    Public Property Instance() As String
        Get
            Instance = m_strInstance
        End Get
        Set(ByVal value As String)
            m_strInstance = value
        End Set
    End Property
    Public Property Timeout() As Integer
        Get
            Timeout = m_nTimeOut
        End Get
        Set(ByVal value As Integer)
            m_nTimeOut = value
        End Set
    End Property
    Private Sub New()
        m_strServer = ""
        m_strUserName = ""
        m_strPWD = ""
        m_strInstance = ""
        m_nTimeOut = 30
    End Sub

    Public Shared Function Create() As SQLConnectionString
        If m_Instance Is Nothing Then
            m_Instance = New SQLConnectionString
        End If
        Return m_Instance
    End Function

    Public Shared Function GetConnectString() As String
        Create()
        Dim strConnection As String = String.Format("user id={0};pwd={1};Addr={2};database={3};Connect Timeout={4}", _
                                                  m_Instance.UserName, _
                                                  m_Instance.Password, _
                                                  m_Instance.ServerName, _
                                                  m_Instance.Instance, _
                                                  m_Instance.Timeout)
        Return strConnection
    End Function
End Class
Public Class OleConnectionString
    Private Shared m_Instance As OleConnectionString = Nothing
    Private m_strProvider As String     'Provider=Microsoft.Jet.OLEDB.4.0;
    Private m_strDataSource As String   'Data Source=D:\V-Label\Debug\labelData.mdbn
    Private m_strUserName As String
    Private m_strPWD As String


    Public Property Provider() As String
        Get
            Provider = m_strProvider
        End Get
        Set(ByVal value As String)
            m_strProvider = value
        End Set
    End Property
    Public Property DataSource() As String
        Get
            DataSource = m_strDataSource
        End Get
        Set(ByVal value As String)
            m_strDataSource = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            UserName = m_strUserName
        End Get
        Set(ByVal value As String)
            m_strUserName = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Password = m_strPWD
        End Get
        Set(ByVal value As String)
            m_strPWD = value
        End Set
    End Property

    Private Sub New()
        m_strProvider = String.Empty
        m_strDataSource = String.Empty
        m_strUserName = String.Empty
        m_strPWD = String.Empty
    End Sub

    Public Shared Function Create() As OleConnectionString
        If m_Instance Is Nothing Then
            m_Instance = New OleConnectionString
        End If
        Return m_Instance
    End Function

    Public Shared Function GetConnectString() As String
        Create()
        Dim strConnection As String = String.Format("Provider={0};Data Source={1};User ID={2};Password={3}", _
                                                 m_Instance.Provider, _
                                                 m_Instance.DataSource, m_Instance.UserName, m_Instance.Password)
        Return strConnection
    End Function
End Class
