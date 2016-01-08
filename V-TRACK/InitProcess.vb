Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports ITSBase
Imports System.Windows.Forms

Public Class InitProcess

    Public Function Init() As Boolean
         Dim oLocalData As LocalData = LocalData.Create()
        oLocalData.SetPath(Application.StartupPath)
        LoggerManager.LoggerFolder = System.IO.Path.Combine(LocalData.StartUpPath, CONST_TEXT_ERRORFILE_FOLDER)
        LoggerManager.ValidDaysCount = 20
        Logger.WriteLine(LogConstDef.LOG_INFORMATION_STARTUP, EnumDef.EVENT_ENTRY_TYPE.INFORMATION)

        If Not ConfigParse.LoadDBSetting() Then Return False

        Return True
    End Function

End Class
