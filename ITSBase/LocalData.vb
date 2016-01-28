Option Explicit On
Option Strict On

Imports System.Runtime.CompilerServices
Imports System.Data
Imports System.IO
Imports System
Imports System.Drawing.Printing
Imports System.Drawing
Public Module LocalDataModule
    Public Class LocalData
#Region "Member Variable"
        Private Shared m_Instance As LocalData = Nothing
        Private m_strPath As String
        Private Shared m_eDBType As EVENT_DBTYPE
        Private m_tsLocalMinusServer As TimeSpan
        Private _loginUserInfo As UserInfo
        Private m_oLocalPrintPackInfo As LocalPrintPackInfo
        Private m_oSetting As Setting
        Private m_oPrinter As Printer
        Private m_dtINSInfo As DataTable
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
        Public Shared ReadOnly Property Setting() As Setting
            Get
                Return m_Instance.m_oSetting
            End Get
        End Property
        Public Shared ReadOnly Property INSInfo() As DataTable
            Get
                Return m_Instance.m_dtINSInfo
            End Get
        End Property
        Public Shared ReadOnly Property Printer() As Printer
            Get
                Return m_Instance.m_oPrinter
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
        Public Shared ReadOnly Property LocalPrintPackInfo() As LocalPrintPackInfo
            Get
                Return m_Instance.m_oLocalPrintPackInfo
            End Get
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
            m_oPrinter = New Printer
            m_oSetting = New Setting
            If Not m_oLocalPrintPackInfo Is Nothing Then
                m_oLocalPrintPackInfo.Reset()
            Else
                m_oLocalPrintPackInfo = New LocalPrintPackInfo
            End If
            m_dtINSInfo = New DataTable
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
        Public Sub SetLocalPrintPackInfo()
            m_oLocalPrintPackInfo = New LocalPrintPackInfo
        End Sub
        Public Sub SetINSInfo()
            m_dtINSInfo = New DataTable
        End Sub

#End Region
    End Class
    Public Class Setting
        Private m_shBarCode2D As Short
        Public Property BarCode2D() As Short
            Get
                Return m_shBarCode2D
            End Get
            Set(ByVal value As Short)
                m_shBarCode2D = value
            End Set
        End Property
        Public Sub New()
            m_shBarCode2D = CShort(BAR_CODE_2D_MODE.NOT_PRINT_2D_BAR_CODE)
        End Sub
    End Class
    '********************************************************************
    '	Title:			Printer
    '	Copyright:		(C) 2009 VICO Software, Ltd
    '	Author:			FB
    '	Create Date:	2009-9-18
    '	Description:    Printer Info
    '*********************************************************************
    Public Class Printer
        Private Const LPT1 As String = "LPT1"
        Private Const LPT2 As String = "LPT2"
        Private Const LPT3 As String = "LPT3"

        Private m_strLastError As String
        Private m_strLabelPrinter As String
        Private m_eLabelPrinterType As LABEL_PRINTER_TYPE
        Private m_eLabelPrinterFormat As Integer
        Private m_strMedITSPrinter As String
        Private m_eMedITSPrinterPaper As PRINTER_PAPER_FORMAT
        Private m_strPort As String
        Private m_eDisplayUser As Short
        Public ReadOnly Property LastError() As String
            Get
                Return m_strLastError
            End Get
        End Property
        Public Property DisplayUser() As Short
            Get
                Return m_eDisplayUser
            End Get
            Set(ByVal value As Short)
                m_eDisplayUser = value
            End Set
        End Property
        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_strLastError = ""
            m_strLabelPrinter = ""
            m_strPort = String.Empty
            m_eLabelPrinterType = LABEL_PRINTER_TYPE.TYPE_NULL
            m_eLabelPrinterFormat = 0
            'm_eDisplayUser = LABEL_PRINT_DISPLAY_USER.USER_ID
            m_eMedITSPrinterPaper = PRINTER_PAPER_FORMAT.NOT_CONTINUOUS_PAPER
        End Sub

        Public WriteOnly Property MedITSPrinter() As String
            Set(ByVal value As String)
                m_strMedITSPrinter = value
            End Set
        End Property
        Public Property MedITSPrinterPaper() As PRINTER_PAPER_FORMAT
            Get
                Return m_eMedITSPrinterPaper
            End Get
            Set(ByVal value As PRINTER_PAPER_FORMAT)
                m_eMedITSPrinterPaper = value
            End Set
        End Property
        Public Function LabelPrinter(ByVal strLabelPrinter As String, ByVal eFormat As Integer, ByVal strPort As String) As Boolean
            m_strLabelPrinter = strLabelPrinter
            Dim strTemp As String = strLabelPrinter.ToUpper
            If strTemp.IndexOf(TEXT_LABEL_PRINTER_TYPE_KEYWORD_TSC) > -1 Then
                m_eLabelPrinterType = LABEL_PRINTER_TYPE.TSC
            ElseIf strTemp.IndexOf(TEXT_LABEL_PRINTER_TYPE_KEYWORD_ZEBRA) > -1 OrElse strTemp.IndexOf(TEXT_LABEL_PRINTER_TYPE_KEYWORD_ZDESIGNER) > -1 Then
                m_eLabelPrinterType = LABEL_PRINTER_TYPE.ZEBRA
            Else
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_LABELTYPE_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
            End If

            Dim bExistFormat As Boolean = False
            For Each oPrintPackInfo As PrintPackInfo In LocalData.LocalPrintPackInfo.lstPrintPackInfo
                If oPrintPackInfo.m_nId = eFormat Then
                    bExistFormat = True
                    Exit For
                End If
            Next
            If bExistFormat Then
                m_eLabelPrinterFormat = eFormat
            Else
                m_eLabelPrinterFormat = 0
                m_strLastError = TEXT_PRINTER_ERROR_LABELFORMAT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
            End If

            If strPort = String.Empty OrElse Not (strPort = LPT1 OrElse strPort = LPT2 OrElse strPort = LPT3) Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_PORT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
            Else
                m_strPort = strPort
            End If

            Return True
        End Function

        Public Function GetMedITSLabelPrinter(ByRef strPrinter As String, ByRef eFormat As Integer, ByRef eType As LABEL_PRINTER_TYPE, ByRef strPort As String) As Boolean
            m_strLastError = String.Empty
            strPrinter = String.Empty
            strPort = String.Empty
            eFormat = 0
            eType = LABEL_PRINTER_TYPE.TYPE_NULL

            If Not CheckPrinterExist(m_strLabelPrinter) Then
                m_strLastError = m_strLastError & vbCrLf & TEXT_PRINTER_ERROR_NOTEXIST_MEDITS_LABEL_PRINTER
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            Dim bExistFormat As Boolean = False
            For Each oPrintPackInfo As PrintPackInfo In LocalData.LocalPrintPackInfo.lstPrintPackInfo
                If oPrintPackInfo.m_nId = m_eLabelPrinterFormat Then
                    eFormat = oPrintPackInfo.m_nId
                    bExistFormat = True
                    Exit For
                End If
            Next
            If Not bExistFormat Then
                m_eLabelPrinterFormat = 0
                m_strLastError = TEXT_PRINTER_ERROR_LABELFORMAT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If m_eLabelPrinterType <> LABEL_PRINTER_TYPE.TSC AndAlso m_eLabelPrinterType <> LABEL_PRINTER_TYPE.ZEBRA Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_LABELTYPE_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If m_strPort = String.Empty OrElse Not (m_strPort = LPT1 OrElse m_strPort = LPT2 OrElse m_strPort = LPT3) Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_PORT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            strPrinter = m_strLabelPrinter
            eFormat = m_eLabelPrinterFormat
            eType = m_eLabelPrinterType
            strPort = m_strPort

            Return True
        End Function
        Public Function GetSUINSLabelPrinter(ByRef strPrinter As String, ByRef eFormat As Integer, ByRef eType As LABEL_PRINTER_TYPE, ByRef strPort As String) As Boolean
            m_strLastError = String.Empty
            strPrinter = String.Empty
            strPort = String.Empty
            eFormat = 0
            eType = LABEL_PRINTER_TYPE.TYPE_NULL

            If Not CheckPrinterExist(m_strLabelPrinter) Then
                m_strLastError = m_strLastError & vbCrLf & TEXT_PRINTER_ERROR_NOTEXIST_MEDITS_LABEL_PRINTER
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If
            If m_eLabelPrinterType <> LABEL_PRINTER_TYPE.TSC AndAlso m_eLabelPrinterType <> LABEL_PRINTER_TYPE.ZEBRA Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_LABELTYPE_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If m_strPort = String.Empty OrElse Not (m_strPort = LPT1 OrElse m_strPort = LPT2 OrElse m_strPort = LPT3) Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_PORT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            strPrinter = m_strLabelPrinter
            eFormat = m_eLabelPrinterFormat
            eType = m_eLabelPrinterType
            strPort = m_strPort

            Return True
        End Function

        Public Function GetINSLabelPrinter(ByRef strPrinter As String, ByRef eFormat As Integer, ByRef eType As LABEL_PRINTER_TYPE, ByRef strPort As String) As Boolean
            m_strLastError = String.Empty
            strPrinter = String.Empty
            strPort = String.Empty
            eFormat = 0
            eType = LABEL_PRINTER_TYPE.TYPE_NULL

            If Not CheckPrinterExist(m_strLabelPrinter) Then
                m_strLastError = m_strLastError & vbCrLf & TEXT_PRINTER_ERROR_NOTEXIST_MEDITS_LABEL_PRINTER
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            Dim bExistFormat As Boolean = False

            eFormat = LocalData.LocalPrintPackInfo.INSLabelPrint.m_nId
            If eFormat = 0 Then
                bExistFormat = False
            Else
                bExistFormat = True
            End If

            If Not bExistFormat Then
                m_eLabelPrinterFormat = 0
                m_strLastError = TEXT_PRINTER_ERROR_LABELFORMAT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If m_eLabelPrinterType <> LABEL_PRINTER_TYPE.TSC AndAlso m_eLabelPrinterType <> LABEL_PRINTER_TYPE.ZEBRA Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_LABELTYPE_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If m_strPort = String.Empty OrElse Not (m_strPort = LPT1 OrElse m_strPort = LPT2 OrElse m_strPort = LPT3) Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_PORT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            strPrinter = m_strLabelPrinter
            'eFormat = m_eLabelPrinterFormat
            eType = m_eLabelPrinterType
            strPort = m_strPort

            Return True
        End Function
        Public Function GetToolLabelPrinter(ByRef strPrinter As String, ByRef eFormat As Integer, ByRef eType As LABEL_PRINTER_TYPE, ByRef strPort As String) As Boolean
            m_strLastError = String.Empty
            strPrinter = String.Empty
            strPort = String.Empty
            eFormat = 0
            eType = LABEL_PRINTER_TYPE.TYPE_NULL

            If Not CheckPrinterExist(m_strLabelPrinter) Then
                m_strLastError = m_strLastError & vbCrLf & TEXT_PRINTER_ERROR_NOTEXIST_MEDITS_LABEL_PRINTER
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            Dim bExistFormat As Boolean = False

            eFormat = LocalData.LocalPrintPackInfo.ToolLabelPrint.m_nId
            If eFormat = 0 Then
                bExistFormat = False
            Else
                bExistFormat = True
            End If

            If Not bExistFormat Then
                m_eLabelPrinterFormat = 0
                m_strLastError = TEXT_PRINTER_ERROR_LABELFORMAT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If m_eLabelPrinterType <> LABEL_PRINTER_TYPE.TSC AndAlso m_eLabelPrinterType <> LABEL_PRINTER_TYPE.ZEBRA Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_LABELTYPE_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            If m_strPort = String.Empty OrElse Not (m_strPort = LPT1 OrElse m_strPort = LPT2 OrElse m_strPort = LPT3) Then
                m_strLabelPrinter = String.Empty
                m_strLastError = TEXT_PRINTER_ERROR_PORT_NOT_SUPPORT
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            strPrinter = m_strLabelPrinter
            'eFormat = m_eLabelPrinterFormat
            eType = m_eLabelPrinterType
            strPort = m_strPort

            Return True
        End Function

        Public Function GetMedITSDefaultPrinter(ByRef strPrinter As String) As Boolean
            m_strLastError = String.Empty

            strPrinter = m_strMedITSPrinter
            If Not CheckPrinterExist(strPrinter) Then
                strPrinter = String.Empty
                m_strLastError = m_strLastError & vbCrLf & TEXT_PRINTER_ERROR_NOTEXIST_MEDITS_DEFAULT_PRINTER
                Logger.WriteLine(LOG_PERINTER_ERROR_MEDITS_DEFAULT_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End If

            Return True
        End Function

        Public Function GetSystemDefaultPrinter(ByRef strPrinter As String) As Boolean
            m_strLastError = String.Empty

            Dim oPrintDocument As New System.Drawing.Printing.PrintDocument
            strPrinter = oPrintDocument.PrinterSettings.PrinterName
            If Not CheckPrinterExist(strPrinter) Then
                strPrinter = String.Empty
                m_strLastError = m_strLastError & vbCrLf & TEXT_PRINTER_ERROR_NOTEXIST_SYSTEM_DEFAULT_PRINTER
                Logger.WriteLine(LOG_PERINTER_ERROR_SYSTEM_DEFAULT_NOT_EXIST & m_strLastError, EVENT_ENTRY_TYPE.WARNING)
                Return False
            End If

            Return True

        End Function

        Public Function CheckPrinterExist(ByVal strPrinter As String) As Boolean
            m_strLastError = String.Empty
            For Each obj As Object In Printing.PrinterSettings.InstalledPrinters
                If strPrinter = obj.ToString Then
                    Return True
                End If
            Next

            m_strLastError = String.Format(TEXT_PRINTER_ERROR_NOTEXIST_INLIST, strPrinter)
            Return False

        End Function
    End Class

    Public Class LocalPrintPackInfo
        Private m_lstPrintPackInfo As List(Of PrintPackInfo)
        Private m_oINSLabelPrint As PrintPackInfo
        Private m_lstWHLabelInfo As List(Of PrintPackInfo)
        Private m_lstMachineBatchPrint As List(Of PrintPackInfo)
        Private m_oToolPrint As PrintPackInfo
        Private m_dtData As DataTable

        Public Property INSLabelPrint() As PrintPackInfo
            Get
                Return m_oINSLabelPrint
            End Get
            Set(ByVal value As PrintPackInfo)
                m_oINSLabelPrint = value
            End Set
        End Property

        Public Property ToolLabelPrint() As PrintPackInfo
            Get
                Return m_oToolPrint
            End Get
            Set(ByVal value As PrintPackInfo)
                m_oToolPrint = value
            End Set
        End Property

        Public ReadOnly Property lstPrintPackInfo() As List(Of PrintPackInfo)
            Get
                Return m_lstPrintPackInfo
            End Get
        End Property
        Public ReadOnly Property LabelFormat() As DataTable
            Get
                Return m_dtData
            End Get
        End Property

        Public ReadOnly Property lstWHLabelInfo() As List(Of PrintPackInfo)
            Get
                Return m_lstWHLabelInfo
            End Get
        End Property

        Public ReadOnly Property lstMachineBatch() As List(Of PrintPackInfo)
            Get
                Return m_lstMachineBatchPrint
            End Get
        End Property

        Public Sub New()
            Reset()
        End Sub

        Public Sub Reset()
            m_oINSLabelPrint = New PrintPackInfo

            If m_lstPrintPackInfo Is Nothing Then
                m_lstPrintPackInfo = New List(Of PrintPackInfo)
            Else
                m_lstPrintPackInfo.Clear()
            End If

            If m_lstMachineBatchPrint Is Nothing Then
                m_lstMachineBatchPrint = New List(Of PrintPackInfo)
            Else
                m_lstMachineBatchPrint.Clear()
            End If

            If m_lstWHLabelInfo Is Nothing Then
                m_lstWHLabelInfo = New List(Of PrintPackInfo)
            Else
                m_lstWHLabelInfo.Clear()
            End If

            If m_oToolPrint Is Nothing Then
                m_oToolPrint = New PrintPackInfo
            Else
                m_oToolPrint.Reset()
            End If


            If m_dtData Is Nothing Then
                TableConstructor.CreateLabelFomat(m_dtData)
            Else
                m_dtData.Clear()
            End If
        End Sub

        Public Sub LoadLabelFormat()
            m_dtData.Clear()

            For Each oPrintPackInfo As PrintPackInfo In Me.m_lstPrintPackInfo
                Dim drFind As DataRow() = m_dtData.Select(String.Format("{0}='{1}'", TEXT_ID, oPrintPackInfo.m_nId))
                If drFind.Length = 0 Then
                    Dim drNew As DataRow = m_dtData.NewRow
                    drNew.Item(TEXT_ID) = oPrintPackInfo.m_nId
                    drNew.Item(TEXT_NAME) = oPrintPackInfo.m_strText

                    m_dtData.Rows.Add(drNew)
                End If
            Next
        End Sub

        Public Function GetLabelFormatNameByID(ByVal nID As Integer) As String
            Dim strName As String = String.Empty

            For Each oPrintPackInfo As PrintPackInfo In Me.m_lstPrintPackInfo

                If oPrintPackInfo.m_nId = nID Then
                    strName = oPrintPackInfo.m_strText
                    Exit For
                End If
            Next

            Return strName
        End Function
    End Class

End Module