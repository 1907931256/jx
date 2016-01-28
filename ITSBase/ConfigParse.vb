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
    Public Shared Function LoadINSInfo() As Boolean

    End Function
    Public Shared Function LoadPrinterSetting() As Boolean
        LoadPrintPackInfo()
        Dim strConfigFile As String = Path.Combine(LocalData.StartUpPath, CONST_CONFIG_FILENAME)
        Dim oDoc As XmlDocument = New XmlDocument
        Try
            oDoc.Load(strConfigFile)
        Catch ex As Exception
            Logger.WriteLine(LOG_CONFIGFILE_LOAD_FAILURE & ex.ToString)
            Return False
        End Try

        Dim strPrinter As String = String.Empty
        Dim eFormat As Integer = 0
        Dim ePaperType As PRINTER_PAPER_FORMAT = PRINTER_PAPER_FORMAT.NOT_CONTINUOUS_PAPER
        Dim oPrinter As Printer = LocalData.Printer
        Dim strPort As String = String.Empty
        '********************************************************************
        'Label Printer
        '*********************************************************************
        Dim NodeDB As XmlNode = oDoc.SelectSingleNode(XML_PATH_PRINTER_LABEL)
        If NodeDB Is Nothing Then
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE, XML_PATH_PRINTER_LABEL), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If Not NodeDB.Attributes(XML_ATT_VALUE) Is Nothing Then
            strPrinter = NodeDB.Attributes(XML_ATT_VALUE).Value
        Else
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_VALUE), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If Not NodeDB.Attributes(XML_ATT_FORMAT) Is Nothing AndAlso Judgement.IsPlusOrZeroInteger(NodeDB.Attributes(XML_ATT_FORMAT).Value) Then
            eFormat = CInt(NodeDB.Attributes(XML_ATT_FORMAT).Value)
        Else
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_FORMAT), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If Not NodeDB.Attributes(XML_ATT_PORT) Is Nothing Then
            strPort = NodeDB.Attributes(XML_ATT_PORT).Value
        Else
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_PORT), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If Not oPrinter.CheckPrinterExist(strPrinter) Then
            Logger.WriteLine(LOG_CONFIGFILE_LABEL_PRINTER_FAILURE & oPrinter.LastError)
        Else
            If Not oPrinter.LabelPrinter(strPrinter, eFormat, strPort) Then
                Return False
            End If
        End If

        '********************************************************************
        'MedITS Printer
        '*********************************************************************
        NodeDB = oDoc.SelectSingleNode(XML_PATH_PRINTER_MEDITS)
        If NodeDB Is Nothing Then
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE, XML_PATH_PRINTER_MEDITS), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If Not NodeDB.Attributes(XML_ATT_VALUE) Is Nothing Then
            strPrinter = NodeDB.Attributes(XML_ATT_VALUE).Value
        Else
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_VALUE), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If Not NodeDB.Attributes(XML_ATT_FORMAT) Is Nothing Then
            ePaperType = CType(NodeDB.Attributes(XML_ATT_FORMAT).Value, PRINTER_PAPER_FORMAT)
        Else
            Logger.WriteLine(String.Format(LOG_ELEMENT_READ_FAILURE_SUB, NodeDB.OuterXml, XML_ATT_FORMAT), EVENT_ENTRY_TYPE.ERRORR)
            Return False
        End If

        If oPrinter.CheckPrinterExist(strPrinter) Then
            oPrinter.MedITSPrinter = strPrinter
            oPrinter.MedITSPrinterPaper = ePaperType
            Return True
        End If

        Logger.WriteLine(LOG_CONFIGFILE_MEDITS_PRINTER_FAILURE & oPrinter.LastError, EVENT_ENTRY_TYPE.WARNING)
        If Not oPrinter.GetSystemDefaultPrinter(strPrinter) Then
            Dim strError As String = String.Format(LOG_PERINTER_ERROR_SYSTEM_DEFAULT_NOT_EXIST & oPrinter.LastError)
            Logger.WriteLine(LOG_CONFIGFILE_RESET_MEDITS_PRINTER_FAILURE & vbCrLf & strError, EVENT_ENTRY_TYPE.WARNING)
        End If

        'Reset Print
        oPrinter.MedITSPrinter = strPrinter
        NodeDB.Attributes(XML_ATT_VALUE).Value = strPrinter
        oPrinter.MedITSPrinterPaper = ePaperType
        NodeDB.Attributes(XML_ATT_FORMAT).Value = CShort(PRINTER_PAPER_FORMAT.NOT_CONTINUOUS_PAPER).ToString

        oDoc.Save(strConfigFile)
        Logger.WriteLine(LOG_CONFIGFILE_RESET_MEDITS_PRINTER_SUCCESS, EVENT_ENTRY_TYPE.INFORMATION)

        Return True
    End Function
    Public Shared Function LoadPrintPackInfo() As Boolean
        Dim oDoc As New XmlDocument
        Dim xmlFile As String = Path.Combine(LocalData.StartUpPath, CONST_LABEL_FORMAT_FILENAME)

        Try
            oDoc.Load(xmlFile)
        Catch ex As Exception
            Logger.WriteLine(LOG_PACKPRINTINFO_LOAD_FAILURE & ex.ToString)
            Return False
        End Try

        Dim NodeList As XmlNodeList = oDoc.SelectNodes(XML_PATH_LABEL_FORMAT_ITEM)
        For Each Node As XmlNode In NodeList
            Dim oPrintPackInfo As PrintPackInfo = New PrintPackInfo
            If Node.Attributes(XML_ATT_SMALL_ID) IsNot Nothing AndAlso Judgement.IsPlusInteger(Node.Attributes(XML_ATT_SMALL_ID).Value) Then
                oPrintPackInfo.m_nId = CInt(Node.Attributes(XML_ATT_SMALL_ID).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_SMALL_ID), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_nId = 0
            End If

            If Node.Attributes(XML_ATT_TEXT) IsNot Nothing Then
                oPrintPackInfo.m_strText = Node.Attributes(XML_ATT_TEXT).Value
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_TEXT), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_strText = ""
            End If

            If Node.Attributes(XML_ATT_PRINTER_MODEL) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(Node.Attributes(XML_ATT_PRINTER_MODEL).Value) Then
                oPrintPackInfo.m_shPrintModel = CShort(Node.Attributes(XML_ATT_PRINTER_MODEL).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_PRINTER_MODEL), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_shPrintModel = 0
            End If

            If Node.Attributes(XML_ATT_PACKAGE_TYPE) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(Node.Attributes(XML_ATT_PACKAGE_TYPE).Value) Then
                oPrintPackInfo.m_shPackageType = CShort(Node.Attributes(XML_ATT_PACKAGE_TYPE).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_PACKAGE_TYPE), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_shPackageType = 0
            End If

            If Node.Attributes(XML_ATT_WIDTH) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(Node.Attributes(XML_ATT_WIDTH).Value) Then
                oPrintPackInfo.m_nWidth = CInt(Node.Attributes(XML_ATT_WIDTH).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_WIDTH), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_nWidth = 0
            End If

            If Node.Attributes(XML_ATT_HEIGH) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(Node.Attributes(XML_ATT_HEIGH).Value) Then
                oPrintPackInfo.m_nHeigh = CInt(Node.Attributes(XML_ATT_HEIGH).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_HEIGH), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_nHeigh = 0
            End If

            If Node.Attributes(XML_ATT_OFFSET) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(Node.Attributes(XML_ATT_OFFSET).Value) Then
                oPrintPackInfo.m_nOffSet = CInt(Node.Attributes(XML_ATT_OFFSET).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_OFFSET), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_nOffSet = 0
            End If

            If Node.Attributes(XML_ATT_ROTATE) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(Node.Attributes(XML_ATT_ROTATE).Value) Then
                oPrintPackInfo.m_bRotate = CBool(Node.Attributes(XML_ATT_ROTATE).Value)
            Else
                Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_ROTATE), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_bRotate = False
            End If

            If Node.Attributes(XML_ATT_BARCODE_TYPE) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(Node.Attributes(XML_ATT_BARCODE_TYPE).Value) Then
                oPrintPackInfo.m_shBarCodeType = CType(Node.Attributes(XML_ATT_BARCODE_TYPE).Value, BAR_CODE_2D_MODE)
            Else
                ' Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE, XML_PATH_LABEL_FORMAT_ITEM, XML_ATT_ROTATE), EVENT_ENTRY_TYPE.ERRORR)
                oPrintPackInfo.m_shBarCodeType = BAR_CODE_2D_MODE.NOT_PRINT_2D_BAR_CODE
            End If

            For Each oSub As XmlNode In Node.ChildNodes
                If oSub.Attributes Is Nothing Then Continue For
                Dim oPrintPackDetailInfo As PrintPackDetailInfo = New PrintPackDetailInfo
                If oSub.Attributes(XML_ATT_TEXT) IsNot Nothing Then
                    oPrintPackDetailInfo.m_strText = oSub.Attributes(XML_ATT_TEXT).Value
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_TEXT), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_strText = ""
                End If

                If oSub.Attributes(XML_ATT_FORMAT) IsNot Nothing Then
                    oPrintPackDetailInfo.m_strFormat = oSub.Attributes(XML_ATT_FORMAT).Value
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_FORMAT), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_strFormat = ""
                End If

                If oSub.Attributes(XML_ATT_X) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_X).Value) Then
                    oPrintPackDetailInfo.m_nX = CInt(oSub.Attributes(XML_ATT_X).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_X), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_nX = 0
                End If

                If oSub.Attributes(XML_ATT_Y) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_Y).Value) Then
                    oPrintPackDetailInfo.m_nY = CInt(oSub.Attributes(XML_ATT_Y).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_Y), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_nY = 0
                End If

                If oSub.Attributes(XML_ATT_WIDTH) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_WIDTH).Value) Then
                    oPrintPackDetailInfo.m_nWidth = CInt(oSub.Attributes(XML_ATT_WIDTH).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_WIDTH), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_nWidth = 0
                End If

                If oSub.Attributes(XML_ATT_FONT) IsNot Nothing Then
                    oPrintPackDetailInfo.m_strFont = oSub.Attributes(XML_ATT_FONT).Value
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_FONT), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_strFont = ""
                End If

                If oSub.Attributes(XML_ATT_SIZE) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_SIZE).Value) Then
                    oPrintPackDetailInfo.m_nSize = CInt(oSub.Attributes(XML_ATT_SIZE).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_SIZE), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_nSize = 0
                End If

                If oSub.Attributes(XML_ATT_BARCODE) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_BARCODE).Value) Then
                    oPrintPackDetailInfo.m_bBarCode = CBool(oSub.Attributes(XML_ATT_BARCODE).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_BARCODE), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_bBarCode = False
                End If

                If oSub.Attributes(XML_ATT_REVERSE) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_REVERSE).Value) Then
                    oPrintPackDetailInfo.m_bReverse = CBool(oSub.Attributes(XML_ATT_REVERSE).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_REVERSE), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_bReverse = False
                End If

                If oSub.Attributes(XML_ATT_VISIBLE) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_VISIBLE).Value) Then
                    oPrintPackDetailInfo.m_bVisible = CBool(oSub.Attributes(XML_ATT_VISIBLE).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_VISIBLE), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_bVisible = True
                End If

                If oSub.Attributes(XML_ATT_FRAME) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(oSub.Attributes(XML_ATT_FRAME).Value) Then
                    oPrintPackDetailInfo.m_bFrame = CBool(oSub.Attributes(XML_ATT_FRAME).Value)
                Else
                    Logger.WriteLine(String.Format(LOG_ELEMENT_VALUE_SUB, XML_PATH_LABEL_FORMAT_ITEM, XML_PATH_LABEL_FORMAT_SUB_ITEM, XML_ATT_FRAME), EVENT_ENTRY_TYPE.ERRORR)
                    oPrintPackDetailInfo.m_bFrame = False
                End If

                oPrintPackInfo.m_lstPackDetailInfo.Add(oPrintPackDetailInfo)
            Next
            If oPrintPackInfo.m_shPackageType = PACKAGE_TYPE.PACK_INS Then
                LocalData.LocalPrintPackInfo.INSLabelPrint = oPrintPackInfo
            ElseIf oPrintPackInfo.m_shPackageType = PACKAGE_TYPE.PACK_BATCH Then
                LocalData.LocalPrintPackInfo.lstMachineBatch.Add(oPrintPackInfo)
            ElseIf oPrintPackInfo.m_shPackageType = PACKAGE_TYPE.PACK_SU_INS Then
                LocalData.LocalPrintPackInfo.lstWHLabelInfo.Add(oPrintPackInfo)
            ElseIf oPrintPackInfo.m_shPackageType = PACKAGE_TYPE.PACK_TOOL Then
                LocalData.LocalPrintPackInfo.ToolLabelPrint = oPrintPackInfo
            Else
                LocalData.LocalPrintPackInfo.lstPrintPackInfo.Add(oPrintPackInfo)
            End If
        Next

        Return True
    End Function
End Class
