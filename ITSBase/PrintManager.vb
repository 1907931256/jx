Option Explicit On
Option Strict On

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data
Imports System.Xml
Imports System.Windows.Forms
Imports System.IO
Imports ITSBase


Public Class ReportPrinter
    Private Shared m_Instance As ReportPrinter = Nothing
    Private m_strErrorMessage As String
    Public ReadOnly Property ErrorMessage() As String
        Get
            Return m_strErrorMessage
        End Get
    End Property

    Private Sub New()
        CleanError()
    End Sub
    Private Sub CleanError()
        m_strErrorMessage = String.Empty
    End Sub
    'implement singleton 
    Public Shared Function GetInstanse() As ReportPrinter
        If m_Instance Is Nothing Then m_Instance = New ReportPrinter()
        Return m_Instance
    End Function
    Public Function PrintWareHouseStock(ByVal dt As DataTable, ByVal strTitle As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)

        Dim strPrintName As String = String.Empty
        strPrintName = _PrintWareHouseStock

        If Not oPrintDoc.setXML(strPrintName) Then
            m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
            Return False
        End If

        parameters.Add(CONST_XML_PARAMETERS_TITLE, strTitle)
        oPrintDoc.SetParameters(parameters)
        Return Print(oPrintDoc, prtSetting)
    End Function
    Public Function PrintWareHouseStockDetail(ByVal dt As DataTable, ByVal strTitle As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)

        Dim strPrintName As String = String.Empty
        strPrintName = _PrintWareHouseStockDetail

        If Not oPrintDoc.setXML(strPrintName) Then
            m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
            Return False
        End If
        parameters.Add(CONST_XML_PARAMETERS_TITLE, strTitle)
        oPrintDoc.SetParameters(parameters)
        Return Print(oPrintDoc, prtSetting)
    End Function

    Public Function PrintSterilizeRoomRUInOutDetail(ByVal dt As DataTable, ByVal strTitle As String, ByVal bCleanIns As Boolean, ByVal strDistrict As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)

        Dim strPrintName As String = String.Empty
        If bCleanIns Then
            strPrintName = _printSterilizeRoomRUInOutDetailWithCleanIns
        Else
            strPrintName = _printSterilizeRoomRUInOutDetail
        End If
        
            If Not oPrintDoc.setXML(strPrintName) Then
                m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
                Return False
            End If

        parameters.Add(CONST_XML_PARAMETERS_TITLE, strTitle)
        parameters.Add(CONST_XML_PARAMETERS_REGTIME, LocalData.ServerNow)
        parameters.Add(CONST_XML_PARAMETERS_REGNAME, LocalData.LoginUser.m_strFullName)

        oPrintDoc.SetParameters(parameters)

        Return Print(oPrintDoc, prtSetting)
    End Function


    Public Function PrintSterilizeRoomHVInOutDetail(ByVal dt As DataTable, ByVal strTitle As String, ByVal strDistrict As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)
        Dim strPrintName As String = _printSterilizeRoomHVInOutDetail

       
            If Not oPrintDoc.setXML(strPrintName) Then
                m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
                Return False
            End If

        parameters.Add(CONST_XML_PARAMETERS_TITLE, strTitle)
        oPrintDoc.SetParameters(parameters)

        Return Print(oPrintDoc, prtSetting, oPrintDoc.Landscape)
    End Function

    Public Function PrintSterilizeRoomInOutTotalCount(ByVal dt As DataTable, ByVal strTitle As String, ByVal strDistrict As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)

        Dim strPrintName As String = String.Empty
        strPrintName = _printSterilizeRoomInOutTotalCount
       
            If Not oPrintDoc.setXML(strPrintName) Then
                m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
                Return False
            End If
        parameters.Add(CONST_XML_PARAMETERS_TITLE, strTitle)
        parameters.Add(CONST_XML_PARAMETERS_REGTIME, LocalData.ServerNow)
        parameters.Add(CONST_XML_PARAMETERS_REGNAME, LocalData.LoginUser.m_strFullName)

        oPrintDoc.SetParameters(parameters)

        Return Print(oPrintDoc, prtSetting)
    End Function
    
  
    Public Function PrintPerformanceEvaluation(ByVal dt As DataTable, ByVal strGroup As String, ByVal dtimeStart As DateTime, ByVal dtimeEnd As DateTime, _
                                    ByVal strDistrict As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()

        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)
        If Not oPrintDoc.setXML(_PrintPerformanceEvaluation) Then
            m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
            Return False
        End If

        Dim parameters As New Hashtable
        parameters.Add(CONST_XML_PARAMETERS_GROUP, strGroup)
        parameters.Add(CONST_XML_PARAMETERS_STARTDATE, dtimeStart.ToString(TEXT_DATETIME_FORMATION_DATE))
        parameters.Add(CONST_XML_PARAMETERS_ENDDATE, dtimeEnd.ToString(TEXT_DATETIME_FORMATION_DATE))

        oPrintDoc.SetParameters(parameters)
        Return Print(oPrintDoc, prtSetting)
    End Function
    Public Function PrintRecallINS(ByVal dt As DataTable, ByVal strTitle As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)

        If Not oPrintDoc.setXML(_printRecallINS) Then
            m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
            Return False
        End If
        parameters.Add(CONST_XML_PARAMETERS_TITLE, strTitle)
        oPrintDoc.SetParameters(parameters)

        Return Print(oPrintDoc, prtSetting)
    End Function
    'MPY
    Public Function PrintWorkSheetUnit(ByVal dt As DataTable, ByVal strNotes As String, ByVal tDate As DateTime, ByVal strDistrict As String, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)

        If Not oPrintDoc.setXML(_printWorkSheetArrange) Then
            m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
            Return False
        End If
        parameters.Add(CONST_XML_PARAMETERS_NOTES, strNotes)
        parameters.Add(CONST_XML_PARAMETERS_MON_DATE, tDate.Date.ToString(TEXT_DATETIME_FORMATION_DATE))
        oPrintDoc.SetParameters(parameters)

        Return Print(oPrintDoc, prtSetting)
    End Function
    'MPY
    Public Function PrintWorkSheetPosition(ByVal dt As DataTable, Optional ByVal prtSetting As PrinterSettings = Nothing) As Boolean

        If dt.Rows.Count = 0 Then Return False
        CleanError()
        Dim parameters As New Hashtable
        Dim oPrintDoc As ReportPrinterDetail.PrintReportImp = New ReportPrinterDetail.PrintReportImp
        dt.TableName = CONST_TEXT_DEFAULT_PRINT_TABLE_NAME
        oPrintDoc.AddData(dt)

        If Not oPrintDoc.setXML(_printWorkSheetPosition) Then
            m_strErrorMessage = MSG_PRINT_FILE_FORMAT_ERROR
            Return False
        End If
        Return Print(oPrintDoc, prtSetting)
    End Function
    Private Function Print(ByVal oPrintDoc As ReportPrinterDetail.PrintReportImp, ByVal prtSetting As PrinterSettings, Optional ByVal bLandscape As Boolean = False) As Boolean
        '单张打印流程：1.弹出对话框供用户选择
        '              2.用户根据当前弹出对话框选择打印条件，弹出错误对话框写入错误日志。
        Try '针对用户中途取消打印的异常处理
            If prtSetting Is Nothing Then
                Dim pdlg As New PrintDialog
                Dim drResult As DialogResult = pdlg.ShowDialog
                If drResult = DialogResult.OK Then
                    pdlg.PrinterSettings.DefaultPageSettings.Landscape = bLandscape
                    oPrintDoc.PrinterSettings = pdlg.PrinterSettings
                ElseIf drResult = DialogResult.Cancel Then
                    Return True
                Else
                    Logger.WriteLine(MSG_PRINT_FAIL_FINISH_PRINT, EVENT_ENTRY_TYPE.ERRORR)
                    m_strErrorMessage = MSG_PRINT_FAIL_FINISH_PRINT
                    Return False
                End If
            Else
                oPrintDoc.PrinterSettings = prtSetting
            End If

            If Not oPrintDoc.PrintReport() Then
                m_strErrorMessage = MSG_PRINT_FAIL_FINISH_PRINT
                Return False
            End If
        Catch ex As Exception
            Logger.WriteLine(LOG_PERINT_ERROR_INTERRUPT_OR_EXCEPTION & ex.Message, EVENT_ENTRY_TYPE.ERRORR)
            m_strErrorMessage = MSG_PRINT_FAIL_FINISH_PRINT
            Return False
        End Try
        Return True
    End Function
    
End Class