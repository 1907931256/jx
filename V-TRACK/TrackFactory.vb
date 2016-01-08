Imports System.Windows.Forms
Imports ITSBase

Public Class TrackFactory
    Private Shared ReadOnly Instance As TrackFactory = New TrackFactory()
    Private _host As Control
    Private ReadOnly _trackManage As VTrackManage

    Public Shared Property Host() As Control
        Get
            Return Instance._host
        End Get
        Set(value As Control)
            Instance._host = value
            Instance._trackManage.PageHost = value
        End Set
    End Property

    Private Sub New()
        _trackManage = New VTrackManage()
    End Sub

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Init() As Boolean
        Dim oLocalData As LocalDataModule.LocalData = LocalData.Create()
        oLocalData.SetPath(Application.StartupPath)
        LoggerManager.LoggerFolder = System.IO.Path.Combine(LocalData.StartUpPath, CONST_TEXT_ERRORFILE_FOLDER)
        LoggerManager.ValidDaysCount = 20
        Logger.WriteLine(LogConstDef.LOG_INFORMATION_STARTUP, EnumDef.EVENT_ENTRY_TYPE.INFORMATION)
        If Not ConfigParse.LoadDBSetting() Then Return False
        Return True
    End Function

    ''' <summary>
    ''' set the user info, now just id and name
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="userName"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetUserInfo(ByVal userId As String, ByVal userName As String)
        LocalData.LoginUser = New UserInfo() With {.m_strUserID = userId, .m_strFullName = userName}
    End Sub

    ''' <summary>
    ''' directly switch to specified page according to the pageSelector
    ''' </summary>
    ''' <param name="pageSeletor"></param>
    ''' <returns>-1 -- the specified page is not existed; 
    ''' 0 -- successful;</returns>
    ''' <remarks></remarks>
    Public Shared Function SwitchToPage(ByVal pageSeletor As PageSelector, Optional initialFunc As Long = Long.MaxValue) As Boolean
        If Host Is Nothing Then Return False
        Return Instance._trackManage.SwitchToPage(Host, pageSeletor, initialFunc) IsNot Nothing
    End Function
End Class
