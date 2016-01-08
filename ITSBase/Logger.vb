Option Explicit On
Option Strict On
Imports System.Xml
Imports System.Runtime.CompilerServices

Public Module LoggerModule
    Const CONST_STRING_LOGGER As String = "Logger"
    Const CONST_STRING_EVENT As String = "Event"
    Const CONST_STRING_TIME As String = "Time"
    Const CONST_STRING_MSG As String = "Message"
    Const CONST_STRING_CLASS As String = "Class"
    Const CONST_STRING_METHOD As String = "Method"
    Const CONST_STRING_TYPE As String = "Type"
    Const CONST_STRING_XML_FILE As String = ".xml"

    Public Class Logger
        Private Shared m_Instance As Logger = Nothing
        Private Shared m_strFilePath As String
        Public Shared Event BeforeWriteLine()
        Private Sub New()
        End Sub

        Private Shared Function Create() As Logger
            If m_Instance Is Nothing Then
                m_Instance = New Logger
            End If

            Return m_Instance
        End Function
        <MethodImpl(MethodImplOptions.Synchronized)> _
        Public Shared Function WriteLine(ByVal strInfo As String, Optional ByVal emType As EVENT_ENTRY_TYPE = EVENT_ENTRY_TYPE.ERRORR) As Boolean
            Create()
            RaiseEvent BeforeWriteLine()
            'Do something
            If String.IsNullOrEmpty(m_strFilePath) OrElse System.IO.File.Exists(m_strFilePath) = False Then
                Return False
            Else
                Try
                    Dim doc As New XmlDocument
                    doc.Load(m_strFilePath)
                    'find the root node, and append a child node to the root node.
                    Dim ndRoot As XmlNode = doc.DocumentElement
                    Dim ndParent As XmlElement = doc.CreateElement(CONST_STRING_EVENT)
                    ndRoot.AppendChild(ndParent)
                    'add time node and message node
                    Dim strTime As String = Now.ToString(TEXT_DATETIME_FORMATION_TIME_SECOND)
                    Dim ndTime As XmlElement = doc.CreateElement(CONST_STRING_TIME)
                    Dim ndClass As XmlElement = doc.CreateElement(CONST_STRING_CLASS)
                    Dim ndMethod As XmlElement = doc.CreateElement(CONST_STRING_METHOD)
                    Dim ndType As XmlElement = doc.CreateElement(CONST_STRING_TYPE)
                    Dim ndMsg As XmlElement = doc.CreateElement(CONST_STRING_MSG)
                    ndTime.InnerText = strTime
                    ndClass.InnerText = (New StackTrace).GetFrame(1).GetMethod.ReflectedType.FullName
                    ndMethod.InnerText = (New StackTrace).GetFrame(1).GetMethod.ToString
                    ndType.InnerText = CInt(emType).ToString
                    ndMsg.InnerText = strInfo
                    ndParent.AppendChild(ndTime)
                    ndParent.AppendChild(ndClass)
                    ndParent.AppendChild(ndMethod)
                    ndParent.AppendChild(ndType)
                    ndParent.AppendChild(ndMsg)
                    doc.Save(m_strFilePath)
                Catch ex As Exception
                    Return False
                End Try
            End If
            Return True
        End Function

        

#Region "Property"
        Public Shared Property FilePath() As String
            Get
                FilePath = m_strFilePath
            End Get
            Set(ByVal value As String)
                m_strFilePath = value
            End Set
        End Property
#End Region
    End Class

    Public Class LoggerManager
        Private Shared m_nValidDaysCount As Integer = 20
        Private Shared m_Logman As LoggerManager
        Private Shared m_strLogFolder As String = ""
        Private Sub New()
            AddHandler Logger.BeforeWriteLine, AddressOf BeforeLoggerWrite
        End Sub

        Private Shared Function Create() As LoggerManager
            If m_Logman Is Nothing Then
                m_Logman = New LoggerManager
            End If

            Return m_Logman
        End Function

        Public Shared ReadOnly Property LoggerManager() As LoggerManager
            Get
                Return m_Logman
            End Get
        End Property

        Public Shared WriteOnly Property LoggerFolder() As String
            Set(ByVal value As String)
                Create()
                m_strLogFolder = value
            End Set
        End Property

        Private Shared Sub DeleteExpireFiles()
            Create()
            If System.IO.Directory.Exists(m_strLogFolder) = False Then
                Return
            End If
            'get current date
            Dim dtExpire As System.DateTime = CType(Now.AddDays(-1 * m_nValidDaysCount), System.DateTime)
            'if it is beyond the exprie day, delete it.
            For Each eachFile As String In System.IO.Directory.GetFiles(m_strLogFolder)
                Dim nArrData(2) As Integer
                Dim strFileExtension As String = System.IO.Path.GetExtension(eachFile)
                If String.Compare(strFileExtension, CONST_STRING_XML_FILE, True) <> 0 Then
                    Continue For
                End If
                Dim strFile As String = System.IO.Path.GetFileNameWithoutExtension(eachFile)
                Try
                    Dim nYear As Integer = strFile.IndexOf("-")
                    If nYear = -1 Then
                        Continue For
                    Else
                        nArrData(0) = CInt(strFile.Substring(0, nYear))
                    End If
                    Dim nMonth As Integer = strFile.IndexOf("-", nYear + 1)
                    If nMonth = -1 Then
                        Continue For
                    Else
                        nArrData(1) = CInt(strFile.Substring(nYear + 1, nMonth - nYear - 1))
                    End If
                    nArrData(2) = CInt(strFile.Substring(nMonth + 1))
                    Dim dtFile As New System.DateTime(nArrData(0), nArrData(1), nArrData(2))
                    If dtFile < dtExpire Then 'delete file before the expire day
                        System.IO.File.Delete(eachFile)
                    End If
                Catch ex As Exception
                    Continue For
                End Try
            Next
        End Sub

        Private Shared Function CreateFile() As Boolean
            Create()
            If String.IsNullOrEmpty(m_strLogFolder) Then
                Return False
            End If
            If Not System.IO.Directory.Exists(m_strLogFolder) Then
                System.IO.Directory.CreateDirectory(m_strLogFolder)
            End If
            Dim strFileName As String = String.Format("{0}-{1}-{2}.xml", Now.Year, Now.Month, Now.Day)
            strFileName = System.IO.Path.Combine(m_strLogFolder, strFileName)
            If Not System.IO.File.Exists(strFileName) Then
                If Not CreateFile(strFileName, CONST_STRING_LOGGER) Then Return False
            End If

            Logger.FilePath = strFileName
            Return True
        End Function

        Private Shared Function CreateFile(ByVal strFileName As String, ByVal strRoot As String) As Boolean
            Dim NewXML As XmlTextWriter = Nothing
            Try
                Dim fs As System.IO.FileStream = System.IO.File.Create(strFileName)
                NewXML = New XmlTextWriter(fs, System.Text.Encoding.Unicode)
                NewXML.Formatting = Formatting.Indented
                NewXML.WriteStartDocument()
                NewXML.WriteStartElement(strRoot)
                NewXML.WriteEndElement()
                NewXML.WriteEndDocument()
                NewXML.Flush()
                NewXML.Close()
            Catch ex As Exception
                Return False
            Finally
                If NewXML IsNot Nothing Then
                    NewXML.Close()
                    NewXML = Nothing
                End If
            End Try
            Return True
        End Function

        Private Sub BeforeLoggerWrite()
            CreateFile()
            DeleteExpireFiles()
        End Sub

#Region "Property"
        Public Shared WriteOnly Property ValidDaysCount() As Integer
            Set(ByVal value As Integer)
                If value > 0 Then
                    m_nValidDaysCount = value
                End If
            End Set
        End Property
#End Region
    End Class
End Module