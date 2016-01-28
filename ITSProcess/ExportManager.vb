Option Explicit On
'Option Strict On

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
Imports UIControlLib

Public Class ExportManager
    Private Shared m_Instance As ExportManager = Nothing
    Private m_strErrorMessage As String
    Private m_lstExcelFormatCollection As List(Of ExcelFormatCollection)
    Private m_strSeriseCollectionName As String
    Private m_strSeriseCollectionxValue() As String
    Private m_strPieTitle As String
    Private m_lstDataFromProcedure As List(Of Object)
    Private m_strFileName As String
    Private m_strXTitle As String
    Private m_strYtitle As String

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return m_strErrorMessage
        End Get
    End Property

    Private Sub New()
        If m_lstExcelFormatCollection Is Nothing Then
            m_lstExcelFormatCollection = New List(Of ExcelFormatCollection)
        Else
            m_lstExcelFormatCollection.Clear()
        End If
        If m_lstDataFromProcedure Is Nothing Then
            m_lstDataFromProcedure = New List(Of Object)
        Else
            m_lstDataFromProcedure.Clear()
        End If
        m_strPieTitle = String.Empty
        m_strSeriseCollectionName = String.Empty
        m_strFileName = String.Empty
        m_strXTitle = String.Empty
        m_strYtitle = String.Empty
        CleanError()
    End Sub
    Private Sub CleanError()
        m_strErrorMessage = String.Empty
        m_lstExcelFormatCollection.Clear()
    End Sub
    'implement singleton 
    Public Shared Function GetInstanse() As ExportManager
        If m_Instance Is Nothing Then m_Instance = New ExportManager()
        Return m_Instance
    End Function



    Public Function ExportWareHouseStock(ByVal dt As DataTable, ByVal strName As String) As Boolean
        m_lstDataFromProcedure.Clear()
        m_strFileName = strName
        Dim strPath As String = SetXmlPath(TEXT_EXPORT_WAREHOUSE_STOCK)
        Try
            ExportExcel(strPath, dt)
        Catch ex As Exception
            m_strErrorMessage = ex.Message
            Return False
        End Try
        Return True
    End Function
    Public Function ExportWareHouseStockDetail(ByVal dt As DataTable, ByVal strName As String) As Boolean
        m_lstDataFromProcedure.Clear()
        m_strFileName = strName
        Dim strPath As String = SetXmlPath(TEXT_EXPORT_WAREHOUSE_STOCK_DETAIL)
        Try
            ExportExcel(strPath, dt)
        Catch ex As Exception
            m_strErrorMessage = ex.Message
            Return False
        End Try
        Return True
    End Function
    Public Function ExportWareHouseInOut(ByVal dt As DataTable, ByVal strName As String) As Boolean
        m_lstDataFromProcedure.Clear()
        m_strFileName = strName
        Dim strPath As String = SetXmlPath(TEXT_EXPORT_WAREHOUSE_INOUT)
        Try
            ExportExcel(strPath, dt)
        Catch ex As Exception
            m_strErrorMessage = ex.Message
            Return False
        End Try
        Return True
    End Function
    Public Function ExportWareHouseInOutTotal(ByVal dt As DataTable, ByVal strName As String) As Boolean
        m_lstDataFromProcedure.Clear()
        m_strFileName = strName
        Dim strPath As String = SetXmlPath(TEXT_EXPORT_WAREHOUSE_INOUT_TOTAL)
        Try
            ExportExcel(strPath, dt)
        Catch ex As Exception
            m_strErrorMessage = ex.Message
            Return False
        End Try
        Return True
    End Function
    Public Function ExportWareHouseInOutDetail(ByVal dt As DataTable, ByVal strName As String) As Boolean
        m_lstDataFromProcedure.Clear()
        m_strFileName = strName
        Dim strPath As String = SetXmlPath(TEXT_EXPORT_WAREHOUSE_STOCK_DETAIL)
        Try
            ExportExcel(strPath, dt)
        Catch ex As Exception
            m_strErrorMessage = ex.Message
            Return False
        End Try
        Return True
    End Function

    Private Sub ExportExcel(ByVal strPath As String, ByVal dt As DataTable)
        Dim ExportResult As EXCEL_OPERATE_RESULTS
        Try
            Dim oExcelFormatCollection As ExcelFormatCollection = New ExcelFormatCollection(strPath, dt, m_lstDataFromProcedure)
            m_lstExcelFormatCollection.Clear()
            m_lstExcelFormatCollection.Add(oExcelFormatCollection)
            Dim oFormatSet As New ExportFormatSet(m_lstExcelFormatCollection)
            ExportResult = oFormatSet.ExportExcel(m_strFileName, m_strXTitle, m_strYtitle)
        Catch ex As Exception
            ExportResult = EXCEL_OPERATE_RESULTS.CONFIGERROR
        End Try
        If ExportResult = EXCEL_OPERATE_RESULTS.SOFTERROR Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_SOFT_ERROR)

        ElseIf ExportResult = EXCEL_OPERATE_RESULTS.EXCEPTIONS Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_EXPORT_ERROR)
        ElseIf ExportResult = EXCEL_OPERATE_RESULTS.FILERUN Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_REOVER_FILE_ERROR)
        ElseIf ExportResult = EXCEL_OPERATE_RESULTS.CONFIGERROR Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_CONFIG_ERROR)
        End If
    End Sub

    Private Sub ExportCostExcel(ByVal strPath As String, ByVal dt As DataTable, ByVal strRuPath As String, ByVal dtRu As DataTable, _
                                ByVal strSuPath As String, ByVal dtSu As DataTable, ByVal strMachinePath As String, _
                                ByVal dtMachine As DataTable, ByVal strOtherPath As String, ByVal dtOther As DataTable)
        Dim ExportResult As EXCEL_OPERATE_RESULTS
        Try
            Dim oExcelFormatCollection As ExcelFormatCollection = New ExcelFormatCollection(strPath, dt, m_lstDataFromProcedure)
            Dim oRuColection As ExcelFormatCollection = New ExcelFormatCollection(strRuPath, dtRu, m_lstDataFromProcedure)
            Dim oSuCollection As ExcelFormatCollection = New ExcelFormatCollection(strSuPath, dtSu, m_lstDataFromProcedure)
            Dim oMachineCollection As ExcelFormatCollection = New ExcelFormatCollection(strMachinePath, dtMachine, m_lstDataFromProcedure)
            Dim oOtherCollection As ExcelFormatCollection = New ExcelFormatCollection(strOtherPath, dtOther, m_lstDataFromProcedure)
            m_lstExcelFormatCollection.Clear()
            m_lstExcelFormatCollection.Add(oExcelFormatCollection)
            m_lstExcelFormatCollection.Add(oRuColection)
            m_lstExcelFormatCollection.Add(oSuCollection)
            m_lstExcelFormatCollection.Add(oMachineCollection)
            m_lstExcelFormatCollection.Add(oOtherCollection)
            Dim oFormatSet As New ExportFormatSet(m_lstExcelFormatCollection)
            ExportResult = oFormatSet.ExportExcel(m_strFileName, m_strXTitle, m_strYtitle)
        Catch ex As Exception
            ExportResult = EXCEL_OPERATE_RESULTS.CONFIGERROR
        End Try
        If ExportResult = EXCEL_OPERATE_RESULTS.SOFTERROR Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_SOFT_ERROR)
        ElseIf ExportResult = EXCEL_OPERATE_RESULTS.EXCEPTIONS Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_EXPORT_ERROR)
        ElseIf ExportResult = EXCEL_OPERATE_RESULTS.FILERUN Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_REOVER_FILE_ERROR)
        ElseIf ExportResult = EXCEL_OPERATE_RESULTS.CONFIGERROR Then
            UIControlLib.UIMsgBox.MSGBoxShow(MSG_EXCEL_CONFIG_ERROR)
        End If
    End Sub

    Private Function SetXmlPath(ByVal FileName As String) As String
        Dim strPath As String = Path.Combine(LocalData.StartUpPath + TEXT_PATH_CONNECT_SIGN + CONST_TEXT_TEMPLATE_FILE_FOLDER, FileName)
        If strPath.Length > 0 Then
            Return strPath
        Else
            Return String.Empty
        End If
    End Function

    Private Function CreateXValueByArray(ByVal strXValue As String()) As String
        Dim strResult As String = TEXT_EXCEL_MACHINE_XVALUE_BEGIN_STRING
        If strXValue.Length > 0 Then
            For i As Integer = 0 To strXValue.Length - 1
                If i = strXValue.Length - 1 Then
                    strResult = strResult + strXValue(i) + TEXT_EXCEL_MACHINE_XVALUE_END_STRING
                Else
                    strResult = strResult + strXValue(i) + TEXT_STRING_SYMBOL_COMMA
                End If
            Next
        End If
        Return strResult
    End Function

End Class

Public Class ExportFormatSet
    Private m_strSaveFilePath As String
    Private m_oDatatableCollectionList As List(Of ExcelFormatCollection)
    Private m_strXTitle As String
    Private m_strYTitle As String

    Public Sub New(ByVal oDatatableCollection As List(Of ExcelFormatCollection))
        If Not oDatatableCollection Is Nothing Then
            Me.m_oDatatableCollectionList = oDatatableCollection
        Else
            Me.m_oDatatableCollectionList = New List(Of ExcelFormatCollection)
        End If
        m_strXTitle = String.Empty
        m_strYTitle = String.Empty
    End Sub

    Public Function ExportExcel(ByVal strName As String, ByVal strXtitle As String, ByVal strYtitle As String) As EXCEL_OPERATE_RESULTS
        m_strXTitle = strXtitle
        m_strYTitle = strYtitle
        Dim ExcelApplication As Excel.Application = New Excel.Application()
        If ExcelApplication Is Nothing Then
            Return EXCEL_OPERATE_RESULTS.SOFTERROR
        End If
        Dim savefiledialog As SaveFileDialog = New SaveFileDialog()
        If CDbl(ExcelApplication.Version) < TEXT_EXCEL_VERSION_EXCEL2007 Then
            savefiledialog.DefaultExt = SAVEFILE_DEFAULT_EXTENSION
            savefiledialog.Filter = TEXT_XLS_FITER
        Else
            savefiledialog.DefaultExt = SAVEFILE_DEFAULT_VERSION
            savefiledialog.Filter = TEXT_XLSX_FILTER
        End If
        savefiledialog.FileName = strName + "_" + DateTime.Now.ToString(TEXT_EXCEL_TIME_FORMAT_SET)
        Dim workbook As Excel.Workbook = ExcelApplication.Workbooks.Add(Type.Missing)
        Try
            If savefiledialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                m_strSaveFilePath = savefiledialog.FileName
                If System.IO.File.Exists(savefiledialog.FileName) Then
                    Try
                        System.IO.File.Delete(savefiledialog.FileName)
                    Catch ex As Exception
                        Throw New Exception(TEXT_EXCEL_FILE_RUNING)
                    End Try
                End If
                If ExcelDataImportAndGraphics(m_strSaveFilePath, workbook, m_oDatatableCollectionList, ExcelApplication) = EXCEL_OPERATE_RESULTS.SUCESS Then
                    If System.IO.Path.GetExtension(m_strSaveFilePath).Equals(STR_FILEEXTENSION) Then
                        workbook.SaveAs(m_strSaveFilePath, Excel.XlFileFormat.xlExcel7)
                    Else
                        workbook.SaveAs(m_strSaveFilePath)
                    End If
                    Return EXCEL_OPERATE_RESULTS.SUCESS
                Else
                    Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
                End If

            End If
        Catch ex As Exception
            Logger.WriteLine(ex.Message)
            If ex.Message = TEXT_EXCEL_FILE_RUNING Then
                Return EXCEL_OPERATE_RESULTS.FILERUN
            Else
                Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
            End If
        Finally
            workbook.Close(False)
            ExcelApplication.Workbooks.Close()
            ExcelApplication.Quit()
            ExcelApplication = Nothing
            GC.Collect()
        End Try
        Return EXCEL_OPERATE_RESULTS.SUCESS
    End Function


    Private Function ExcelDataImportAndGraphics(ByVal str_FileSavePath As String, ByVal workbook As Excel.Workbook, ByVal list As List(Of ExcelFormatCollection), ByVal ExcelApplication As Excel.Application) As EXCEL_OPERATE_RESULTS
        Try
            Dim sheets As Excel.Sheets = workbook.Worksheets
            For i As Integer = 1 To list.Count
                If i > 3 Then
                    workbook.Sheets.Add(After:=sheets(sheets.Count))
                End If
            Next
            For i As Integer = 0 To list.Count - 1
                Dim dataTableCol As ExcelFormatCollection = list.Item(i)
                Dim worksheet As Excel.Worksheet = CType(sheets.Item(i + 1), Excel.Worksheet)
                worksheet.Activate()
                Dim nTotalRowsCount As Integer = dataTableCol.m_dtbl_Datable.Rows.Count
                Dim nTotalColumnsCount As Integer = dataTableCol.m_nColumnCount
                DataWriteInExcel(worksheet, dataTableCol, nTotalColumnsCount, 0, nTotalRowsCount)
                worksheet.Cells.EntireColumn.AutoFit()
                With ExcelApplication.ActiveWindow
                    .SplitColumn = 0
                    .SplitRow = 1
                End With
                ExcelApplication.ActiveWindow.FreezePanes = True
            Next
            If ExcelGraphics(workbook, list) = EXCEL_OPERATE_RESULTS.SUCESS Then
                '导出成功后，更新Sheet名称 Add by lch  2012-4-17 
                For i As Integer = 0 To list.Count - 1
                    If list(i).m_bHasSheetName Then
                        Dim worksheet As Excel.Worksheet = CType(sheets.Item(i + 1), Excel.Worksheet)
                        worksheet.Activate()
                        worksheet.Name = list(i).m_strSheetName
                    End If
                Next
                Return EXCEL_OPERATE_RESULTS.SUCESS
            Else
                Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
            End If
            
        Catch ex As Exception
            Logger.WriteLine(ex.Message)
            Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
        End Try
    End Function

    Private Function DataWriteInExcel(ByVal worksheet As Excel.Worksheet, ByVal odatatableCol As ExcelFormatCollection, ByVal nTotalColumnsCount As Integer, ByVal nBeginRowsCount As Integer, ByVal nEndRowsCount As Integer) As EXCEL_OPERATE_RESULTS
        Dim range As Excel.Range
        Dim datatable As DataTable = odatatableCol.m_dtbl_Datable
        For j As Integer = 0 To odatatableCol.m_nColumnCount - 1
            worksheet.Cells(1, j + 1) = odatatableCol.m_strColumnSetValue(j)
        Next
        For nColumn As Integer = 0 To odatatableCol.m_strFormatColumnSet.Length - 1
            If odatatableCol.m_strFormatColumnSet(nColumn) = TEXT_RMB_XML_VALUE Then
                range = worksheet.Range(worksheet.Cells(2, nColumn + 1), worksheet.Cells(nEndRowsCount - nBeginRowsCount + 1 + 1, nColumn + 1))
                range.NumberFormatLocal = TEXT_RMB_FORMAT_SET
            ElseIf odatatableCol.m_strFormatColumnSet(nColumn) = TEXT_PERCENT_XML_VALUE Then
                range = worksheet.Range(worksheet.Cells(2, nColumn + 1), worksheet.Cells(nEndRowsCount - nBeginRowsCount + 1 + 1, nColumn + 1))
                range.NumberFormatLocal = TEXT_PERCENT_FORMAT_SET
            ElseIf odatatableCol.m_strFormatColumnSet(nColumn) = TEXT_DATETIME_FORMAT_SET Then
                range = worksheet.Range(worksheet.Cells(2, nColumn + 1), worksheet.Cells(nEndRowsCount - nBeginRowsCount + 1 + 1, nColumn + 1))
                range.NumberFormatLocal = TEXT_DATETIME_FORMAT_SET
            ElseIf odatatableCol.m_strFormatColumnSet(nColumn) = TEXT_STRING_XML_VALUE Then
                range = worksheet.Range(worksheet.Cells(2, nColumn + 1), worksheet.Cells(nEndRowsCount - nBeginRowsCount + 1 + 1, nColumn + 1))
                range.NumberFormatLocal = TEXT_STRING_FORMAT_SET
            End If
        Next
        range = worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(1, odatatableCol.m_nColumnCount))
        DataAreaAttrConfig(range, odatatableCol.m_strDataTitleBackColor, odatatableCol.m_nDataTitleFontSize, odatatableCol.m_bDataTitleFontBold, odatatableCol.m_strDataTitleFontName, odatatableCol.m_DataTitleFontAlign)
        Try
            Dim DataArray(nEndRowsCount - nBeginRowsCount, odatatableCol.m_dtbl_Datable.Columns.Count - 1) As Object
            For nColumn As Integer = 0 To nTotalColumnsCount - 1
                If odatatableCol.m_nValidColumnSet(nColumn) = TEXT_CHECKVALUE_TRUE_VALUE Then
                    For nRow As Integer = nBeginRowsCount To nEndRowsCount - 1
                        If odatatableCol.m_dtbl_Datable.Rows(nRow)(odatatableCol.m_strColumnSetName(nColumn)) = TEXT_CHECKVALUE_FALSE_VALUE Then
                            DataArray(nRow, nColumn) = STR_CKECKVALUE
                        Else
                            DataArray(nRow, nColumn) = String.Empty
                        End If
                    Next
                Else
                    For nRow As Integer = nBeginRowsCount To nEndRowsCount - 1
                        DataArray(nRow, nColumn) = odatatableCol.m_dtbl_Datable.Rows(nRow)(odatatableCol.m_strColumnSetName(nColumn))
                    Next
                End If
            Next
            worksheet.Range(TEXT_BEGIN_CELL_NAME).Resize(nEndRowsCount - nBeginRowsCount + 1, odatatableCol.m_dtbl_Datable.Columns.Count).Value = DataArray
            range = worksheet.Range(worksheet.Cells(2, 1), worksheet.Cells(nEndRowsCount - nBeginRowsCount + 1, odatatableCol.m_nColumnCount))
            DataAreaAttrConfig(range, odatatableCol.m_strDataBackColor, odatatableCol.m_nDataFontSize, odatatableCol.m_bDataFontBold, odatatableCol.m_strDataFontName, odatatableCol.m_DataFontAlign)

            Return EXCEL_OPERATE_RESULTS.SUCESS
        Catch ex As Exception
            Logger.WriteLine(ex.Message)
            Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
        End Try
    End Function

    Private Sub DataAreaAttrConfig(ByVal range As Excel.Range, ByVal strBackcolor As String, ByVal nsize As Integer, ByVal bBold As Boolean, ByVal strFontName As String, ByVal oHorizontalAlignment As Excel.Constants)
        With range
            .Font.Size = nsize
            .Font.Name = strFontName
            .Font.Bold = bBold
            .HorizontalAlignment = oHorizontalAlignment
            If System.Drawing.ColorTranslator.ToOle(Color.FromName(strBackcolor)) = 0.0 Then
                .Interior.Pattern = Excel.Constants.xlNone
            Else
                .Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromName(strBackcolor))
            End If
        End With
    End Sub

    Private Function ExcelGraphics(ByVal workbook As Excel.Workbook, ByVal list As List(Of ExcelFormatCollection)) As EXCEL_OPERATE_RESULTS
        Dim sheets As Excel.Sheets = workbook.Worksheets
        Dim dataTableCol As ExcelFormatCollection
        Dim activeSheet As Excel.Worksheet = CType(sheets.Item(1), Excel.Worksheet)
        workbook.Charts.Add(Type.Missing, Type.Missing, 1, Type.Missing)
        workbook.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, TEXT_FIRST_SHEET_NAME)
        activeSheet.ChartObjects(1).Activate()
        workbook.ActiveChart.ChartArea.Copy()
        Try
            If list.Count > 1 Then
                For i As Integer = 2 To list.Count
                    If list.Item(i - 1).m_strNeedDrawing = STR_NEEDDRAWINGVALUE Then
                        activeSheet = CType(sheets.Item(i), Excel.Worksheet)
                        activeSheet.Paste()
                    End If
                Next
            End If
            For i As Integer = 1 To list.Count
                dataTableCol = list(i - 1)
                Dim worksheet As Excel.Worksheet = CType(sheets.Item(i), Excel.Worksheet)
                worksheet.Activate()
                Dim nTotalRowsCount As Integer = dataTableCol.m_dtbl_Datable.Rows.Count
                Dim nTotalColumnsCount As Integer = dataTableCol.m_nColumnCount
                If dataTableCol.m_strNeedDrawing = STR_NEEDDRAWINGVALUE Then
                    Dim range As Excel.Range = worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(nTotalRowsCount + 1, dataTableCol.m_nVaildColumnCount))
                    If dataTableCol.m_nGraphType <> TEXT_PIE_CHART Then
                        range = worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(nTotalRowsCount + 1, dataTableCol.m_nVaildColumnCount))
                    Else
                        range = worksheet.Range(worksheet.Cells(2, 2), worksheet.Cells(nTotalRowsCount + 1, 2))
                    End If
                    ChartSetting(workbook, worksheet, nTotalRowsCount, dataTableCol, range)
                Else
                    If i = 1 Then
                        worksheet.ChartObjects(1).delete()
                    End If
                End If
            Next
            Return EXCEL_OPERATE_RESULTS.SUCESS
        Catch ex As Exception
            Logger.WriteLine(ex.Message)
            Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
        End Try
    End Function

    Private Sub ChartSetting(ByVal workbook As Excel.Workbook, ByVal worksheet As Excel.Worksheet, ByVal TotalRowsCount As Integer, ByVal datatableCol As ExcelFormatCollection, ByVal sourseDataRange As Excel.Range)
        Try
            workbook.ActiveChart.ChartType = datatableCol.m_nGraphType
            If datatableCol.m_nGraphType <> TEXT_PIE_CHART Then
                workbook.ActiveChart.SetSourceData(sourseDataRange, Excel.XlRowCol.xlRows)
            Else
                workbook.ActiveChart.SetSourceData(sourseDataRange, Excel.XlRowCol.xlColumns)
            End If
        Catch ex As Exception
            workbook.ActiveChart.ChartType = TEXT_HISTOGRAM_CHART
            Logger.WriteLine(ex.Message)
        End Try
        If datatableCol.m_nGraphType <> TEXT_PIE_CHART Then
            Dim xAxis As Excel.Axis = workbook.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)
            With xAxis
                .TickLabels.AutoScaleFont = False
                .TickLabels.Font.Size = datatableCol.m_nxAixsFontSize
                '.TickLabelPosition = Excel.XlTickLabelPosition.xlTickLabelPositionLow
                '.TickLabels.Orientation = CType(Orientation.Horizontal, Excel.XlTickLabelOrientation)
            End With

            Dim yAxis As Excel.Axis = workbook.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)
            With yAxis
                .TickLabels.AutoScaleFont = False
                .TickLabels.Font.Size = datatableCol.m_nyAixsFontSize
            End With
            With workbook.ActiveChart
                .Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasTitle = True
                .Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).AxisTitle.Characters.Text = m_strXTitle
                .Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasTitle = True
                .Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).AxisTitle.Characters.Text = m_strYTitle
            End With
            With workbook.ActiveChart.Axes(Excel.XlAxisType.xlCategory)
                .CrossesAt = 1
                .TickLabelSpacing = 1
                .TickMarkSpacing = 1
                .AxisBetweenCategories = False
                .ReversePlotOrder = False
            End With
        Else
            With workbook.ActiveChart.SeriesCollection(1)
                .XValues = datatableCol.m_strSeriseCollectionxValue
                .Name = datatableCol.m_strSeriseCollectionName
            End With
            workbook.ActiveChart.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowPercent)
            workbook.ActiveChart.SeriesCollection(1).DataLabels.NumberFormatLocal = TEXT_PERCENT_FORMAT_SET
            workbook.ActiveChart.SeriesCollection(1).DataLabels.Font.Size = 10
        End If
        Dim ResizeRowsRange As Excel.Range = worksheet.Rows.Item(TotalRowsCount + datatableCol.m_nChartTop + 2, Type.Missing)
        Dim ResizeColumnsRange As Excel.Range = worksheet.Columns.Item(datatableCol.m_nChartLeft + 1, Type.Missing)
        With worksheet.Shapes.Item(1)
            .Top = CSng(ResizeRowsRange.Top)
            .Left = CSng(ResizeColumnsRange.Left)
            .Width = datatableCol.m_nChartWidth
            .Height = datatableCol.m_nChartHeigth
        End With
        workbook.ActiveChart.HasTitle = True
        With workbook.ActiveChart.ChartTitle
            .Text = datatableCol.m_strTitleText
            .AutoScaleFont = False
            .Font.Size = datatableCol.m_nTitleFontSize
            .Font.Bold = datatableCol.m_bTitleFontBold
            .Font.Name = datatableCol.m_strChartTitleFontName
        End With

        With workbook.ActiveChart.PlotArea
            If System.Drawing.ColorTranslator.ToOle(Color.FromName(datatableCol.m_PlotareaBackcolor)) = 0.0 Then
                .Interior.ColorIndex = 2
            Else
                .Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromName(datatableCol.m_PlotareaBackcolor))
            End If
            .Height = datatableCol.m_nPlotareaHeigth
            .Width = datatableCol.m_nPlotareaWidth
            .Top = datatableCol.m_nPlotareaTop
            .Left = datatableCol.m_nPlotareaLeft
        End With
        workbook.ActiveChart.HasLegend = True
        With workbook.ActiveChart.Legend
            .Left = datatableCol.m_nLegendLeft
            .Top = datatableCol.m_nLegendTop
            .Height = datatableCol.m_nLegendHeight
            .Width = datatableCol.m_nLegendWidth
            .AutoScaleFont = False
            .Font.Size = datatableCol.m_nLegendFontSize
            .Font.Name = datatableCol.m_strLegendFontName
        End With

    End Sub

    'MPY
    Public Function ExportExcel_WorkSheet(ByVal strName As String, ByVal strXtitle As String, ByVal strYtitle As String, ByVal rows As Integer, ByVal columns As Integer) As EXCEL_OPERATE_RESULTS
        m_strXTitle = strXtitle
        m_strYtitle = strYtitle
        Dim ExcelApplication As Excel.Application = New Excel.Application()
        If ExcelApplication Is Nothing Then
            Return EXCEL_OPERATE_RESULTS.SOFTERROR
        End If
        Dim savefiledialog As SaveFileDialog = New SaveFileDialog()
        If CDbl(ExcelApplication.Version) < TEXT_EXCEL_VERSION_EXCEL2007 Then
            savefiledialog.DefaultExt = SAVEFILE_DEFAULT_EXTENSION
            savefiledialog.Filter = TEXT_XLS_FITER
        Else
            savefiledialog.DefaultExt = SAVEFILE_DEFAULT_VERSION
            savefiledialog.Filter = TEXT_XLSX_FILTER
        End If
        savefiledialog.FileName = strName + "_" + DateTime.Now.ToString(TEXT_EXCEL_TIME_FORMAT_SET)
        Dim workbook As Excel.Workbook = ExcelApplication.Workbooks.Add(Type.Missing)
        Try
            If savefiledialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                m_strSaveFilePath = savefiledialog.FileName
                If System.IO.File.Exists(savefiledialog.FileName) Then
                    Try
                        System.IO.File.Delete(savefiledialog.FileName)
                    Catch ex As Exception
                        Throw New Exception(TEXT_EXCEL_FILE_RUNING)
                    End Try
                End If
                If ExcelDataImportAndGraphics(m_strSaveFilePath, workbook, m_oDatatableCollectionList, ExcelApplication) = EXCEL_OPERATE_RESULTS.SUCESS Then
                    If System.IO.Path.GetExtension(m_strSaveFilePath).Equals(STR_FILEEXTENSION) Then
                        workbook.SaveAs(m_strSaveFilePath, Excel.XlFileFormat.xlExcel7)
                    Else
                        workbook.SaveAs(m_strSaveFilePath)
                    End If

                    Dim worksheet As Excel.Worksheet
                    worksheet = CType(workbook.Sheets(1), Excel.Worksheet)
                    worksheet.Activate()
                    worksheet.Range(worksheet.Cells(1)(rows + 1), worksheet.Cells(columns - 1)(rows + 1)).MergeCells = True
                    worksheet.Range(worksheet.Cells(1)(rows + 1), worksheet.Cells(columns - 1)(rows + 1)).WrapText = True
                    worksheet.Columns(1).ColumnWidth = 12
                    worksheet.Rows(rows + 1).RowHeight = 200
                    workbook.Save()
                    Return EXCEL_OPERATE_RESULTS.SUCESS
                Else
                    Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
                End If

            End If
        Catch ex As Exception
            Logger.WriteLine(ex.Message)
            If ex.Message = TEXT_EXCEL_FILE_RUNING Then
                Return EXCEL_OPERATE_RESULTS.FILERUN
            Else
                Return EXCEL_OPERATE_RESULTS.EXCEPTIONS
            End If
        Finally
            workbook.Close(False)
            ExcelApplication.Workbooks.Close()
            ExcelApplication.Quit()
            ExcelApplication = Nothing
            GC.Collect()
        End Try
        Return EXCEL_OPERATE_RESULTS.SUCESS
    End Function
End Class


