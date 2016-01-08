Option Explicit On
Option Strict On

Imports System.Runtime.CompilerServices
Imports System.Data
Imports System.IO
Imports System
Public Module LocalDataModule
    Public Class LocalData
#Region "Member Variable"
        Private Shared m_Instance As LocalData = Nothing
        Private m_strPath As String
        Private Shared m_eDBType As EVENT_DBTYPE
        Private m_tsLocalMinusServer As TimeSpan
        Private _loginUserInfo As UserInfo
#End Region

#Region "Property"
        Public Shared ReadOnly Property ServerNow() As DateTime
            Get
                Return DateTime.Now.Subtract(m_Instance.m_tsLocalMinusServer)
            End Get
        End Property

        Public Shared ReadOnly Property StartUpPath() As String
            Get
                Return m_Instance.m_strPath
            End Get
        End Property

        Public Shared Property LoginUser() As UserInfo
            Get
                Return m_Instance._loginUserInfo
            End Get
            Set(value As UserInfo)
                m_Instance._loginUserInfo = value
            End Set
        End Property
#End Region

        Private Sub New()
            m_Instance = Nothing
           Reset()
        End Sub

        Public Shared Sub Release()
            If m_Instance IsNot Nothing Then m_Instance.Reset()
        End Sub
        Private Sub Reset()
            m_tsLocalMinusServer = Nothing
            m_eDBType = EVENT_DBTYPE.NONE
            _loginUserInfo = New UserInfo()
        End Sub

#Region "Init"

        Public Shared Function Create() As LocalData
            If m_Instance Is Nothing Then
                m_Instance = New LocalData
            End If

            Return m_Instance
        End Function

        Public Sub SetServerTime(ByVal dtimeServerNow As DateTime)
            m_tsLocalMinusServer = Date.Now.Subtract(dtimeServerNow)
        End Sub
        Public Sub SetPath(ByVal strPath As String)
            m_strPath = strPath
        End Sub
        Public Shared Sub SetDBType(ByVal eDBType As EVENT_DBTYPE)
            m_eDBType = eDBType
        End Sub
#End Region
    End Class


End Module