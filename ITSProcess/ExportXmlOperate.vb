Imports ITSBase
Imports System.Xml
Public Class ExportXmlOperate
    Public strxmlDocPath As String
    Private oXmlDoc As XmlDocument
    Private oXMLNamespace As XmlNamespaceManager
    Public Sub New(ByVal str_xmlDocPath As String)
        If Not str_xmlDocPath Is Nothing Then
            Me.strxmlDocPath = str_xmlDocPath
        Else
            Me.strxmlDocPath = String.Empty
        End If
        Try
            oXmlDoc = New XmlDocument
            oXmlDoc.Load(strxmlDocPath)
        Catch ex As Exception
            Logger.WriteLine(ex.Message)
        End Try
    End Sub
    Public Function ReadAttrValues(ByVal strNodeXmlPath As String, ByVal strAttrName As String) As String

        Dim oNode As XmlNode
        Try
            Dim oRoot As XmlElement = oXmlDoc.DocumentElement
            oNode = oRoot.SelectSingleNode(strNodeXmlPath)
        Catch ex As System.ArgumentException
            oNode = Nothing
            Logger.WriteLine(ex.Message)
        End Try
        If oNode Is Nothing Then
            Return String.Empty
        End If

        If Not oNode.Attributes(strAttrName) Is Nothing Then
            Return oNode.Attributes(strAttrName).Value.ToString()
        Else
            Return String.Empty
        End If
    End Function

    Public Function ReadAttrValues(ByVal strNodeXmlPath As String, ByVal strAttrName As String, ByRef strAttrValue As String) As Boolean

        Dim oNode As XmlNode
        Try
            Dim oRoot As XmlElement = oXmlDoc.DocumentElement
            oNode = oRoot.SelectSingleNode(strNodeXmlPath)
        Catch ex As System.ArgumentException
            oNode = Nothing
        End Try
        If oNode Is Nothing Then
            Return False
        End If

        If oNode.Attributes(strAttrName) IsNot Nothing Then
            strAttrValue = oNode.Attributes(strAttrName).Value.ToString()
            Return True
        Else
            Return False
        End If

    End Function

    Public Function ReadColumnNodeList(ByVal strNodeXmlPath As String) As XmlNodeList
        Dim oNodelist As XmlNodeList
        Dim oRoot As XmlElement = oXmlDoc.DocumentElement
        oNodelist = oRoot.SelectNodes(strNodeXmlPath, oXMLNamespace)
        If Not oNodelist Is Nothing Then
            Return oNodelist
        Else
            Return Nothing
        End If
    End Function
End Class
