'********************************************************************
'	Title:			ConfigParse
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-7-21
'	Description:    Parse Config XML file
'*********************************************************************
Option Explicit On
Option Strict On

Imports System.Xml
Imports System.IO
Imports DBAdapter

Public Class ConfigParse
    Private Const FILE_CONNECTION_FILE As String = "Set.bat"
    
    Public Shared Function LoadDBSetting() As Boolean

        Dim strConfigFile As String = Path.Combine(LocalData.StartUpPath, CONST_CONFIG_FILENAME)
        Dim oDoc As XmlDocument = New XmlDocument
        Try
            oDoc.Load(strConfigFile)
        Catch ex As Exception
            Logger.WriteLine(LOG_CONFIGFILE_LOAD_FAILURE & ex.ToString)
            Return False
        End Try

        Dim NodeDB As XmlNode = oDoc.SelectSingleNode(XML_PATH_DBSETTING)
        If NodeDB Is Nothing Then
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE, XML_PATH_DBSETTING), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If Not NodeDB.Attributes(XML_PATH_DBTYPE) Is Nothing Then
            If NodeDB.Attributes(XML_PATH_DBTYPE).Value.Equals(CONST_XML_VALUE_SQL_SERVER) Then
                LocalData.SetDBType(MatchStringToDBType(NodeDB.Attributes(XML_PATH_DBTYPE).Value))
                Dim oConnectionString As SQLConnectionString = SQLConnectionString.Create
                If Not NodeDB.Attributes(XML_ATT_SERVER) Is Nothing Then
                    oConnectionString.ServerName = Decrypt(NodeDB.Attributes(XML_ATT_SERVER).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_SERVER), EVENT_ENTRY_TYPE.ERRORR)
                    Return False
                End If

                If Not NodeDB.Attributes(XML_ATT_USER) Is Nothing Then
                    oConnectionString.UserName = Decrypt(NodeDB.Attributes(XML_ATT_USER).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_USER), EVENT_ENTRY_TYPE.ERRORR)
                    Return False
                End If

                If Not NodeDB.Attributes(XML_ATT_PWD) Is Nothing Then
                    oConnectionString.Password = Decrypt(NodeDB.Attributes(XML_ATT_PWD).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_PWD), EVENT_ENTRY_TYPE.ERRORR)
                    Return False
                End If

                If Not NodeDB.Attributes(XML_ATT_INSTANCE) Is Nothing Then
                    oConnectionString.Instance = Decrypt(NodeDB.Attributes(XML_ATT_INSTANCE).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_INSTANCE), EVENT_ENTRY_TYPE.ERRORR)
                    Return False
                End If

                If Not NodeDB.Attributes(XML_ATT_TIMEOUT) Is Nothing Then
                    Dim strTimeOut As String = Decrypt(NodeDB.Attributes(XML_ATT_TIMEOUT).Value)
                    If Judgement.IsPlusInteger(strTimeOut) Then
                        oConnectionString.Timeout = CInt(strTimeOut)
                    Else
                        oConnectionString.Timeout = 30
                        Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, NodeDB.OuterXml, XML_ATT_TIMEOUT, strTimeOut), EVENT_ENTRY_TYPE.WARNING)
                    End If
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_TIMEOUT), EVENT_ENTRY_TYPE.ERRORR)
                    Return False
                End If
        ElseIf NodeDB.Attributes(XML_PATH_DBTYPE).Value.Equals(CONST_XML_VALUE_ORACLE) Then 'Oracle
            LocalData.SetDBType(MatchStringToDBType(NodeDB.Attributes(XML_PATH_DBTYPE).Value))
            Dim oConnectionString As OleConnectionString = OleConnectionString.Create
            If Not NodeDB.Attributes(XML_ATT_SERVER) Is Nothing Then
                oConnectionString.Provider = Decrypt(NodeDB.Attributes(XML_ATT_SERVER).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, CONST_XML_VALUE_ORACLE), EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If Not NodeDB.Attributes(XML_ATT_USER) Is Nothing Then
                oConnectionString.UserName = Decrypt(NodeDB.Attributes(XML_ATT_USER).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_USER), EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If Not NodeDB.Attributes(XML_ATT_PWD) Is Nothing Then
                oConnectionString.Password = Decrypt(NodeDB.Attributes(XML_ATT_PWD).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_PWD), EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If Not NodeDB.Attributes(XML_ATT_INSTANCE) Is Nothing Then
                oConnectionString.DataSource = Decrypt(NodeDB.Attributes(XML_ATT_INSTANCE).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_INSTANCE), EVENT_ENTRY_TYPE.ERRORR)
                Return False
                End If
            End If
        Else
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_SERVER), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If
        Return True
    End Function

    Private Shared Function Decrypt(ByVal strSource As String) As String


        '#If CompileMethod = "Release" OrElse CompileMethod = "ReleaseRight" OrElse CompileMethod = "ReleaseLK" Then
        '        Logger.WriteLine(XorHex.Decrypt(strSource))
        '        Return XorHex.Decrypt(strSource)
        '#Else
        ' Logger.WriteLine(strSource)
        Return strSource
        '#End If

    End Function

End Class
