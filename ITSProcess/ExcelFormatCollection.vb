Imports ITSBase
Public Class ExcelFormatCollection
    Private m_strxmlDocPath As String
    Public m_dtbl_Datable As DataTable
    Public m_strSheetName As String
    Public m_bHasSheetName As Boolean
    Public m_nGraphType As Integer
    Public m_nChartTop As Integer
    Public m_nChartLeft As Integer
    Public m_nChartWidth As Integer
    Public m_nChartHeigth As Integer
    Public m_strTitleText As String
    Public m_strChartTitleFontName As String
    Public m_nTitleFontSize As Integer
    Public m_bTitleFontBold As Boolean
    Public m_nPlotareaTop As Integer
    Public m_nPlotareaLeft As Integer
    Public m_nPlotareaWidth As Integer
    Public m_nPlotareaHeigth As Integer
    Public m_PlotareaBackcolor As String
    Public m_nxAixsFontSize As Integer
    Public m_nyAixsFontSize As Integer
    Public m_nLegendFontSize As Integer
    Public m_strLegendFontName As String
    Public m_nLegendTop As Integer
    Public m_nLegendLeft As Integer
    Public m_nLegendWidth As Integer
    Public m_nLegendHeight As Integer
    Public m_strDataTitleBackColor As String
    Public m_nDataTitleFontSize As Integer
    Public m_strDataTitleFontName As String
    Public m_bDataTitleFontBold As Boolean
    Public m_strDataBackColor As String
    Public m_nDataFontSize As Integer
    Public m_strDataFontName As String
    Public m_bDataFontBold As Boolean
    Public m_DataFontAlign As Excel.Constants
    Public m_DataTitleFontAlign As Excel.Constants
    Public m_strColumnSetName As String()
    Public m_strColumnSetValue As String()
    Public m_nColumnCount As Integer
    Public m_nValidColumnSet As String()
    Public m_strFormatColumnSet As String()
    Public m_strNeedDrawing As String
    Public m_nVaildColumnCount As Integer
    Public m_strSeriseCollectionName As String
    Public m_strSeriseCollectionxValue As String
    Public m_strColumnSetType As String


    Public Sub New(ByVal str_xmldocPath As String, ByVal dt_Datable As DataTable, ByVal lstProcedureData As List(Of Object))
        Me.m_strxmlDocPath = str_xmldocPath
        Me.m_dtbl_Datable = dt_Datable
        Dim xmlOp As ExportXmlOperate = New ExportXmlOperate(str_xmldocPath)
        'sheet
        'Ìí¼ÓSheetÃû³Æ Add by lch  2012-4-17
        Dim strSheetName As String = String.Empty

        If xmlOp.ReadAttrValues(XML_STR_XPATH_EXCELCONFIG, XML_STR_ATTRIBUTEVALUE_SHEET, strSheetName) Then
            m_bHasSheetName = True
            Me.m_strSheetName = strSheetName
        Else
            m_bHasSheetName = False
        End If

        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_TOP), m_nChartTop) Then
            Me.m_nChartTop = 0
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_COLUMNSET_TYPE, XML_STR_ATTRIBUTE_TYPE) = XML_STR_ATTRIBUTEVALUE_RETURN Then
            If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_GRAPHTYPE), m_nGraphType) Then
                Me.m_nGraphType = 51
            End If
        Else
            Me.m_nGraphType = lstProcedureData(1)
        End If

        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_LEFT), m_nChartLeft) Then
            Me.m_nChartLeft = 0
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_WIDTH), m_nChartWidth) Then
            Me.m_nChartWidth = 400
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_HEIGHT), m_nChartHeigth) Then
            Me.m_nChartHeigth = 51
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_TITLEFONTSIZE), m_nTitleFontSize) Then
            Me.m_nTitleFontSize = 18
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_TOP), m_nPlotareaTop) Then
            Me.m_nPlotareaTop = 35
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_LEFT), m_nPlotareaLeft) Then
            Me.m_nPlotareaLeft = 0
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_WIDTH), m_nPlotareaWidth) Then
            Me.m_nPlotareaWidth = 248
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_HEIGHT), m_nPlotareaHeigth) Then
            Me.m_nPlotareaHeigth = 315
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_XAXISFONTSIZE), m_nxAixsFontSize) Then
            Me.m_nxAixsFontSize = 10
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_YAXISFONTSIZE), m_nyAixsFontSize) Then
            Me.m_nyAixsFontSize = 10
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_LEGEND, XML_STR_ATTRIBUTE_SIZE), m_nLegendFontSize) Then
            Me.m_nLegendFontSize = 10
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_LEGEND, XML_STR_ATTRIBUTE_LEFT), m_nLegendLeft) Then
            Me.m_nLegendLeft = 250
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_LEGEND, XML_STR_ATTRIBUTE_TOP), m_nLegendTop) Then
            Me.m_nLegendTop = 70
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_LEGEND, XML_STR_ATTRIBUTE_WIDTH), m_nLegendWidth) Then
            Me.m_nLegendWidth = 150
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_LEGEND, XML_STR_ATTRIBUTE_HEIGHT), m_nLegendHeight) Then
            Me.m_nLegendHeight = 200
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_SIZE), m_nDataTitleFontSize) Then
            Me.m_nDataTitleFontSize = 12
        End If
        If Not Integer.TryParse(xmlOp.ReadAttrValues(XML_STR_XPATH_DATAAREA, XML_STR_ATTRIBUTE_SIZE), m_nDataFontSize) Then
            Me.m_nDataFontSize = 12
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_BOLD).ToLower().Equals(XML_STR_ATTRIBUTEVALUE_TRUE) = True Then
            Me.m_bDataTitleFontBold = True
        Else
            Me.m_bDataTitleFontBold = False
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_TITLEFONTBOLD).ToLower().Equals(XML_STR_ATTRIBUTEVALUE_TRUE) = True Then
            Me.m_bTitleFontBold = True
        Else
            Me.m_bTitleFontBold = False
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_DATAAREA, XML_STR_ATTRIBUTE_ALIGN) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_DataFontAlign = TransDef.MatchAlignStyleToConstals(xmlOp.ReadAttrValues(XML_STR_XPATH_DATAAREA, XML_STR_ATTRIBUTE_ALIGN).ToLower)
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_ALIGN) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_DataTitleFontAlign = TransDef.MatchAlignStyleToConstals(xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_ALIGN).ToLower)
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_LEGEND, XML_STR_ATTRIBUTE_FONTNAME) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_strLegendFontName = xmlOp.ReadAttrValues(XML_STR_XPATH_LEGEND, XML_STR_ATTRIBUTE_FONTNAME)
        Else
            Me.m_strLegendFontName = XML_STR_ATTRIBUTEVALUE_FONTNAME_SONGTI
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_FONTNAME) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_strDataTitleFontName = xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_FONTNAME)
        Else
            Me.m_strDataTitleFontName = XML_STR_ATTRIBUTEVALUE_FONTNAME_SONGTI
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_DATAAREA, XML_STR_ATTRIBUTE_FONTNAME) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_strDataFontName = xmlOp.ReadAttrValues(XML_STR_XPATH_DATAAREA, XML_STR_ATTRIBUTE_FONTNAME)
        Else
            Me.m_strDataFontName = XML_STR_ATTRIBUTEVALUE_FONTNAME_SONGTI
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_DATAAREA, XML_STR_ATTRIBUTE_BACKCOLOR) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_strDataBackColor = xmlOp.ReadAttrValues(XML_STR_XPATH_DATAAREA, XML_STR_ATTRIBUTE_BACKCOLOR)
        Else
            Me.m_strDataBackColor = XML_STR_ATTRIBUTEVALUE_DATABACKCOLOR
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_BACKCOLOR) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_strDataTitleBackColor = xmlOp.ReadAttrValues(XML_STR_XPATH_DATATITLE, XML_STR_ATTRIBUTE_BACKCOLOR)
        Else
            Me.m_strDataTitleBackColor = XML_STR_ATTRIBUTEVALUE_TITLEBACKCOLOR
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_TITLEFONTNAME) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_strChartTitleFontName = xmlOp.ReadAttrValues(XML_STR_XPATH_CHARTAREA, XML_STR_ATTRIBUTE_TITLEFONTNAME)
        Else
            Me.m_strChartTitleFontName = XML_STR_ATTRIBUTEVALUE_FONTNAME_SONGTI
        End If
        If lstProcedureData.Count > 0 Then
            If lstProcedureData(0).ToString <> XML_STR_ATTRIBUTEVALUE_RETURN Then
                Me.m_strTitleText = lstProcedureData(0).ToString
            Else
                Me.m_strTitleText = XML_STR_ATTRIBUTEVALUE_RETURN
            End If
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_BACKCOLOR) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_PlotareaBackcolor = xmlOp.ReadAttrValues(XML_STR_XPATH_PLOTAREA, XML_STR_ATTRIBUTE_BACKCOLOR)
        Else
            Me.m_PlotareaBackcolor = XML_STR_ATTRIBUTEVALUE_PLOTBACKCOLOR
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_COLUMNSET_TYPE, XML_STR_ATTRIBUTE_TYPE) <> XML_STR_ATTRIBUTEVALUE_RETURN Then
            Me.m_strColumnSetName = lstProcedureData(2)
            Me.m_strColumnSetValue = lstProcedureData(2)
            Me.m_nColumnCount = lstProcedureData(2).length
            Dim nArr(lstProcedureData(2).length - 1) As String
            For i As Integer = 0 To lstProcedureData(2).length - 1
                nArr(i) = XML_STR_COLUMNVALID_STATE
            Next
            Me.m_nValidColumnSet = nArr
            Me.m_strFormatColumnSet = nArr
            Me.m_nVaildColumnCount = lstProcedureData(2).length
        Else
            If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN) Is Nothing Then
                Dim nColumnNameCount As Integer = xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Count
                Dim arrColumnName(nColumnNameCount) As String
                For i As Integer = 0 To nColumnNameCount - 1
                    arrColumnName(i) = xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Item(i).Attributes(XML_STR_ATTRIBUTE_NAME).Value
                Next
                Me.m_strColumnSetName = arrColumnName
            End If
            If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN) Is Nothing Then
                Dim nColumnNameCount As Integer = xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Count
                Dim arrColumnName(nColumnNameCount) As String
                For i As Integer = 0 To nColumnNameCount - 1
                    arrColumnName(i) = xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Item(i).Attributes(XML_STR_ATTRIBUTE_VALUE).Value
                Next
                Me.m_strColumnSetValue = arrColumnName
            End If
            If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN) Is Nothing Then
                Me.m_nColumnCount = xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Count
            End If
            If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN) Is Nothing Then
                Dim nValidColumnSet(m_nColumnCount) As String
                For i As Integer = 0 To Me.m_nColumnCount - 1
                    If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Item(i).Attributes(XML_STR_ATTRIBUTE_TYPE) Is Nothing Then
                        nValidColumnSet(i) = XML_STR_COLUMNNOTVALID_STATE
                    Else
                        nValidColumnSet(i) = XML_STR_COLUMNVALID_STATE
                    End If
                Next
                Me.m_nValidColumnSet = nValidColumnSet
            End If
            If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN) Is Nothing Then
                Dim strFormatColumnSet(m_nColumnCount) As String
                For i As Integer = 0 To Me.m_nColumnCount - 1
                    If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Item(i).Attributes(XML_STR_ATTRIBUTE_FORMAT) Is Nothing Then
                        strFormatColumnSet(i) = xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Item(i).Attributes(XML_STR_ATTRIBUTE_FORMAT).Value
                    Else
                        strFormatColumnSet(i) = XML_STR_COLUMNVALID_STATE
                    End If
                Next
                Me.m_strFormatColumnSet = strFormatColumnSet
            End If
            If Not xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN) Is Nothing Then
                Dim nCount As Integer = 0
                For i As Integer = 0 To Me.m_nColumnCount - 1
                    If xmlOp.ReadColumnNodeList(XML_STR_XPATH_COLUMN).Item(i).Attributes(XML_STR_ATTRIBUTE_TYPE) Is Nothing Then
                        nCount += 1
                    End If
                Next
                Me.m_nVaildColumnCount = nCount
            End If
        End If
        If Not xmlOp.ReadAttrValues(XML_STR_XPATH_DRAWING, XML_STR_ATTRIBUTE_NEEDDRAWING) Is Nothing Then
            Me.m_strNeedDrawing = xmlOp.ReadAttrValues(XML_STR_XPATH_DRAWING, XML_STR_ATTRIBUTE_NEEDDRAWING).ToLower()
        Else
            Me.m_strNeedDrawing = XML_STR_ATTRIBUTEVALUE_NOTNEEDDRAWING
        End If
        If xmlOp.ReadAttrValues(XML_STR_XPATH_COLUMNSET_TYPE, XML_STR_ATTRIBUTE_TYPE) = XML_STR_ATTRIBUTEVALUE_RETURN Then
            If lstProcedureData.Count > 1 Then
                If lstProcedureData(1) <> String.Empty Then
                    m_strSeriseCollectionName = lstProcedureData(1)
                Else
                    m_strSeriseCollectionName = String.Empty
                End If
            End If

            If lstProcedureData.Count > 2 Then
                If lstProcedureData(2) <> String.Empty Then
                    m_strSeriseCollectionxValue = lstProcedureData(2)
                Else
                    m_strSeriseCollectionxValue = String.Empty
                End If
            End If
        End If
    End Sub
End Class
