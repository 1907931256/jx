'all the classes are not allowed to manipilate directly.
'fpf, 2009.10.14

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

Namespace ReportPrinterDetail
    Public Delegate Sub MarginsChangedHandler(ByVal sender As Object)
    Public Delegate Sub PageSizeChangedHandler(ByVal sender As Object)
    Public Delegate Sub PageLayoutChangedHandler(ByVal sender As Object)

    Public Class PrintReportImp
        Inherits System.Drawing.Printing.PrintDocument

#Region "member variable"
        Private Const CONST_INTEGER_DEFAULT_LEADING As Integer = 10
        Private Const CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT As Integer = 2
        Private Const CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT As Integer = 1
        Private m_Components As System.ComponentModel.Container = Nothing
        Public Event OnMarginsChanged As MarginsChangedHandler
        Public Event OnPageSizeChanged As PageSizeChangedHandler
        Public Event OnPageLayoutChanged As PageLayoutChangedHandler
        Private m_DesignLicense As License
        Private m_XmlDoc As XmlDocument
        Private m_szDocRoot As String = ""
        Private m_bIsXmlOK As Boolean = False '打印格式文件是否准备好
        Private m_PaperType As Paper.Type = Paper.Type.A4
        Private m_HtTables As Hashtable
        Private m_HtRowsPrintedSoFar As Hashtable
        Public m_HtSystemValues As Hashtable
        Private m_HTParameterValues As Hashtable
        Private m_AryDeclaredParameters As ArrayList
        Private m_XmlDynamicElements As XmlNodeList
        Private m_XmlStaticElements As XmlNodeList
        Private m_StaticObjects As ICustomPaint()
        Private m_DynamicObjects As ICustomPaint()
        Private m_FooterObjects As ICustomPaint()
        Private m_HTParaCollection As Hashtable '保存参数哈希表的哈希表
        Private m_aryKeys As List(Of String) '保存关键字符串，这个用来区别Table和参数哈希表
        Private m_nLastPos As Integer '记录的是打印对象的最后位置。
        Private m_nMaxHeight As Integer '打印配置文件中Table的底部（一般认为是打印的最下位置）
        Private m_nPrintingIndex As Integer '当前打印的Index
        Private m_nFooterPos As Integer '连续打印模式下记录页脚位置
        Private m_bNeedContinuousFirstTitle As Boolean
        Private m_bContinuousXmlOK As Boolean '连续纸打印格式文件是否准备好
        Private m_nContinuousYStartPos As Integer '第二页以后Y的起始点
#End Region

#Region "property"
        Public Property DocRoot() As String
            Get
                Return m_szDocRoot
            End Get
            Set(ByVal Value As String)
                Me.m_szDocRoot = Value
            End Set
        End Property

        Public Property PaperType() As Paper.Type
            Get
                Return m_PaperType
            End Get
            Set(ByVal Value As Paper.Type)
                m_PaperType = Value
                Dim size As Integer() = Paper.GetPaperSize(PaperType)
                Me.DefaultPageSettings.PaperSize = New PaperSize("", size(0), size(1))
                RaiseEvent OnPageSizeChanged(Me)
            End Set
        End Property

        Public Property Margins() As Margins
            Get
                Return Me.DefaultPageSettings.Margins
            End Get
            Set(ByVal Value As Margins)
                Me.DefaultPageSettings.Margins = Value
                RaiseEvent OnMarginsChanged(Me)
            End Set
        End Property

        Public ReadOnly Property DynamicObjects() As ICustomPaint()
            Get
                Return Me.m_DynamicObjects
            End Get
        End Property

        Public ReadOnly Property Landscape() As Boolean
            Get
                Return DefaultPageSettings.Landscape
            End Get
        End Property
#End Region

#Region "function"
        Public Sub New()
            InitializeComponent()
            ReSet()
        End Sub
        Public Sub ReSet()
            Dim size As Integer() = Paper.GetPaperSize(PaperType)
            DefaultPageSettings.PaperSize = New PaperSize("", size(0), size(1))
            DefaultPageSettings.Margins = New Margins(50, 50, 50, 50)
            DefaultPageSettings.Landscape = False

            InitSystemParameters()
            If m_AryDeclaredParameters Is Nothing Then
                m_AryDeclaredParameters = New ArrayList
            Else
                m_AryDeclaredParameters.Clear()
            End If
            If m_HTParameterValues Is Nothing Then
                m_HTParameterValues = New Hashtable
            Else
                m_HTParameterValues.Clear()
            End If
            If m_HtTables Is Nothing Then
                m_HtTables = New Hashtable
            Else
                m_HtTables.Clear()
            End If
            If m_HtRowsPrintedSoFar Is Nothing Then
                m_HtRowsPrintedSoFar = New Hashtable
            Else
                m_HtRowsPrintedSoFar.Clear()
            End If
            If m_aryKeys Is Nothing Then
                m_aryKeys = New List(Of String)
            Else
                m_aryKeys.Clear()
            End If
            If m_HTParaCollection Is Nothing Then
                m_HTParaCollection = New Hashtable
            Else
                m_HTParaCollection.Clear()
            End If
            m_nLastPos = 0
            m_nMaxHeight = 0
            m_nPrintingIndex = 0
            m_nFooterPos = 0
            m_bNeedContinuousFirstTitle = True
            m_nContinuousYStartPos = CONST_INTEGER_DEFAULT_SPACE
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (m_DesignLicense Is Nothing) Then
                    m_DesignLicense.Dispose()
                    m_DesignLicense = Nothing
                End If
                If Not (m_Components Is Nothing) Then
                    m_Components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub Finalize()
            Dispose()
        End Sub

        Private Sub InitializeComponent()
            AddHandler Me.BeginPrint, AddressOf Me.PrintDocument_BeginPrint
            AddHandler Me.EndPrint, AddressOf Me.PrintDocument_EndPrint
        End Sub

        Private Sub InitSystemParameters()
            If m_HtSystemValues Is Nothing Then
                m_HtSystemValues = New Hashtable
            Else
                m_HtSystemValues.Clear()
            End If
            m_HtSystemValues.Add(CONST_TEXT_PAGE_NUMBER, 0)
            m_HtSystemValues.Add(CONST_TEXT_TOTAL_PAGES, 0)
            m_HtSystemValues.Add(CONST_TEXT_SYSTEM_DATA, DateTime.Now.ToString(TEXT_DATETIME_FORMATION_DATE_FRENCH))
            m_HtSystemValues.Add(CONST_TEXT_SYSTEM_TIME, DateTime.Now.ToString(TEXT_DATETIME_FORMATION_TIME_SECOND))
        End Sub

        Public Sub AddData(ByVal newTable As DataTable)
            If newTable Is Nothing Then Return
            Dim copyTable As DataTable = newTable.Copy
            Try
                If m_HtTables.Contains(copyTable.TableName) Then
                    m_HtTables.Remove(copyTable.TableName)
                    m_HtRowsPrintedSoFar.Remove(copyTable.TableName)
                    m_aryKeys.Remove(copyTable.TableName)
                End If
                m_HtTables.Add(copyTable.TableName, copyTable)
                m_HtRowsPrintedSoFar.Add(copyTable.TableName, 0)
                m_aryKeys.Add(copyTable.TableName)
            Catch generatedExceptionVariable0 As Exception
            End Try
        End Sub
        Private Function LoadXML(ByVal FileName As String) As Boolean
            m_XmlDoc = New XmlDocument
            Dim strFormatFile As String = Path.Combine(LocalData.StartUpPath & "\" & CONST_TEXT_TEMPLATE_FILE_FOLDER, FileName)
            Try
                m_XmlDoc.Load(strFormatFile)
            Catch ex As Exception
                Logger.WriteLine(String.Format(LOG_PERINT_ERROR_FORMAT_FILE_LOAD_FAILURE, strFormatFile, ex.ToString), EVENT_ENTRY_TYPE.ERRORR)
                m_bIsXmlOK = False
                m_bContinuousXmlOK = False
                Return False
            End Try
            Return True
        End Function
        Public Function setXML(ByVal FileName As String) As Boolean
            If Not LoadXML(FileName) Then
                Return False
            End If
            DocRoot = (New FileInfo(FileName)).DirectoryName
            Return setXML()
        End Function
        Public Function setContinuousXML(ByVal strFileName As String) As Boolean
            If Not LoadXML(strFileName) Then
                Return False
            End If
            DocRoot = (New FileInfo(strFileName)).DirectoryName
            Return setContinuousXML()
        End Function
        Public Sub SetParameters(ByVal strKey As String, ByVal parameters As Hashtable)
            If m_HTParaCollection.Contains(strKey) Then
                m_HTParaCollection.Remove(strKey)
            End If
            m_HTParaCollection.Add(strKey, parameters)
            'the following is to initial the m_HTParameterValues
            If m_HTParaCollection.Keys.Count = 1 Then
                Dim em As IDictionaryEnumerator = m_HTParaCollection.GetEnumerator
                While em.MoveNext
                    m_HTParameterValues = CType(m_HTParaCollection.Item(em.Key.ToString), Hashtable)
                End While
            End If
        End Sub
        Public Sub SetParameters(ByVal parameters As Hashtable)
            m_HTParameterValues = parameters
        End Sub

        Public Function PrintReport() As Boolean
            Try
                MyBase.Print()
                Return True
            Catch ex As Exception
                Logger.WriteLine(LOG_PERINT_ERROR & ex.ToString, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End Try
        End Function
#Region "parse xml"

#Region "new parse xml"
        Private Function setContinuousXML() As Boolean
            Try
                Dim NodeList As XmlNodeList = m_XmlDoc.SelectNodes(CONST_TEXT_PATH_PAPER_ITEM)
                For Each Node As XmlNode In NodeList
                    If Node.Attributes(CONST_TEXT_ATTRI_KEY).Value = CONST_TEXT_ATTRI_PAPER_SIZE Then
                        ParsePaperSize(Node)
                    ElseIf Node.Attributes(CONST_TEXT_ATTRI_KEY).Value = CONST_TEXT_NODE_MARGINS Then
                        ParseMargins(Node)
                    ElseIf Node.Attributes(CONST_TEXT_ATTRI_KEY).Value = CONST_TEXT_NODE_PARAMETERS Then
                        ParseParameterDeclaration(Node)
                    End If
                Next
                NodeList = m_XmlDoc.SelectNodes(CONST_TEXT_PATH_STATICCONTENT_ITEM)
                m_StaticObjects = New ICustomPaint() {}
                For Each Node As XmlNode In NodeList
                    If Node.Attributes(CONST_TEXT_ATTRI_KEY).Value = CONST_TEXT_NODE_TEXT_FIELD Then
                        Array.Resize(m_StaticObjects, m_StaticObjects.Length + 1)
                        m_StaticObjects.SetValue(ResolveTextField(Node, True, True), m_StaticObjects.Length - 1)
                    ElseIf Node.Attributes(CONST_TEXT_ATTRI_KEY).Value = CONST_TEXT_NODE_BARCODE Then
                        Array.Resize(m_StaticObjects, m_StaticObjects.Length + 1)
                        m_StaticObjects.SetValue(ResolveBarCode(Node, True, True), m_StaticObjects.Length - 1)
                    End If
                Next
                Dim nTableBottom As Integer = 0
                NodeList = m_XmlDoc.SelectNodes(CONST_TEXT_PATH_DYNAMICCONTENT_ITEM)
                m_DynamicObjects = New ICustomPaint() {}
                For Each Node As XmlNode In NodeList
                    If Node.Attributes(CONST_TEXT_ATTRI_KEY).Value = CONST_TEXT_NODE_TABLE Then
                        Array.Resize(m_DynamicObjects, m_DynamicObjects.Length + 1)
                        m_DynamicObjects.SetValue(ResolveTable(Node), m_DynamicObjects.Length - 1)
                        Dim table As StyledTable = CType(m_DynamicObjects(m_DynamicObjects.Length - 1), StyledTable)
                        If nTableBottom < table.Y + table.Height Then nTableBottom = table.Y + table.Height
                    End If
                Next
                m_nMaxHeight = nTableBottom 'if there is no table, then m_nMaxHeight will not be used.
                For Each oStyledTable As StyledTable In m_DynamicObjects
                    oStyledTable.PageMaxHeight = m_nMaxHeight
                Next
                NodeList = m_XmlDoc.SelectNodes(CONST_TEXT_PATH_FOOTER_ITEM)
                m_FooterObjects = New ICustomPaint() {}
                For Each Node As XmlNode In NodeList
                    If Node.Attributes(CONST_TEXT_ATTRI_KEY).Value = CONST_TEXT_NODE_TEXT_FIELD Then
                        Array.Resize(m_FooterObjects, m_FooterObjects.Length + 1)
                        m_FooterObjects.SetValue(ResolveTextField(Node, True, True), m_FooterObjects.Length - 1)
                    End If
                Next

                AddHandler Me.OnMarginsChanged, AddressOf RepeatAlignments
                AddHandler Me.OnPageLayoutChanged, AddressOf RepeatAlignments
                m_bIsXmlOK = True
                m_bContinuousXmlOK = True
                Return True
            Catch e As FileNotFoundException
                m_bIsXmlOK = False
                m_bContinuousXmlOK = False
                Logger.WriteLine(LOG_PERINT_ERROR_FORMAT_FILE_LOAD_EXCEPTION & e.ToString, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            Catch e As XmlException
                m_bIsXmlOK = False
                m_bContinuousXmlOK = False
                Dim tmp As Exception = e
                Dim strErrorMessage As String = String.Empty
                While Not (tmp Is Nothing)
                    strErrorMessage += tmp.Message + "" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & ""
                    tmp = tmp.InnerException
                End While
                Logger.WriteLine(LOG_PERINT_ERROR_FORMAT_FILE_LOAD_EXCEPTION & strErrorMessage, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End Try
        End Function
        Private Sub ParsePaperSize(ByVal theNode As XmlNode)
            If theNode.Attributes(CONST_TEXT_ATTRI_SIZE) IsNot Nothing Then
                Dim strType As String = theNode.Attributes(CONST_TEXT_ATTRI_SIZE).Value
                Me.PaperType = Paper.GetPaperType(strType)
            Else
                Me.PaperType = Paper.Type.A4
            End If
            If theNode.Attributes(CONST_TEXT_ATTRI_LAYOUT) IsNot Nothing Then
                Dim theOrientation As String = theNode.Attributes(CONST_TEXT_ATTRI_LAYOUT).Value
                If theOrientation = CONST_TEXT_LAYOUT_LANDSCAPE Then
                    Me.DefaultPageSettings.Landscape = True
                Else
                    Me.DefaultPageSettings.Landscape = False
                End If
            Else
                Me.DefaultPageSettings.Landscape = True
            End If
        End Sub
        Private Sub ParseMargins(ByVal theNode As XmlNode)
            If theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_TOP) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_TOP).Value) Then
                Me.Margins.Top = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_TOP).Value)
            Else
                Me.Margins.Top = 50
            End If
            If theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_LFET) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_LFET).Value) Then
                Me.Margins.Left = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_LFET).Value)
            Else
                Me.Margins.Left = 50
            End If
            If theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_BOTTOM) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_BOTTOM).Value) Then
                Me.Margins.Bottom = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_BOTTOM).Value)
            Else
                Me.Margins.Bottom = 50
            End If
            If theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_RIGHT) IsNot Nothing AndAlso Judgement.IsPlusOrZeroInteger(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_RIGHT).Value) Then
                Me.Margins.Right = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_RIGHT).Value)
            Else
                Me.Margins.Right = 50
            End If
        End Sub
        Private Sub ParseParameterDeclaration(ByVal theNode As XmlNode)
            If theNode.Attributes(CONST_TEXT_ATTRI_NAME) IsNot Nothing Then
                Dim parameterName As String = theNode.Attributes(CONST_TEXT_ATTRI_NAME).Value
                If Not m_AryDeclaredParameters.Contains(parameterName) Then
                    m_AryDeclaredParameters.Add(parameterName)
                End If
            End If
        End Sub
#End Region
     
        Private Function SetXML() As Boolean
            Try
                Dim root As XmlNode = m_XmlDoc.FirstChild
                Dim temp As XmlNodeList = root.ChildNodes
                ResolvePaperSize(root)
                ResolveLayout(root)
                Dim nIndex As Integer = 0
                While nIndex < temp.Count
                    Select Case temp(nIndex).Name
                        Case CONST_TEXT_NODE_MARGINS
                            ResolveMargins(temp(nIndex))
                        Case CONST_TEXT_NODE_PARAMETERS
                            ResolveParameterDeclaration(temp(nIndex))
                        Case CONST_TEXT_NODE_CONTENT
                            ResolveContents(temp(nIndex))
                    End Select
                    System.Threading.Interlocked.Increment(nIndex)
                End While
                InitStaticObjects(True)
                InitDynamicObjects(True)
                AddHandler Me.OnMarginsChanged, AddressOf RepeatAlignments
                AddHandler Me.OnPageLayoutChanged, AddressOf RepeatAlignments
                m_bIsXmlOK = True
                m_bContinuousXmlOK = False
                Return True
            Catch e As FileNotFoundException
                m_bIsXmlOK = False
                m_bContinuousXmlOK = False
                Logger.WriteLine(LOG_PERINT_ERROR_FORMAT_FILE_LOAD_EXCEPTION & e.ToString, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            Catch e As XmlException
                m_bIsXmlOK = False
                m_bContinuousXmlOK = False
                Dim tmp As Exception = e
                Dim strErrorMessage As String = String.Empty
                While Not (tmp Is Nothing)
                    strErrorMessage += tmp.Message + "" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & ""
                    tmp = tmp.InnerException
                End While
                Logger.WriteLine(LOG_PERINT_ERROR_FORMAT_FILE_LOAD_EXCEPTION & strErrorMessage, EVENT_ENTRY_TYPE.ERRORR)
                Return False
            End Try
        End Function

        Private Sub ResolvePaperSize(ByVal theNode As XmlNode)
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_PAPER_SIZE) Is Nothing) Then
                Me.PaperType = Paper.GetPaperType(theNode.Attributes(CONST_TEXT_ATTRI_PAPER_SIZE).Value)
            End If
        End Sub

        Private Sub ResolveLayout(ByVal theNode As XmlNode)
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_SIZE) Is Nothing) Then
                Dim theSize As String = theNode.Attributes(CONST_TEXT_ATTRI_SIZE).Value
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_LAYOUT) Is Nothing) Then
                Dim theOrientation As String = theNode.Attributes(CONST_TEXT_ATTRI_LAYOUT).Value
                If theOrientation = CONST_TEXT_LAYOUT_LANDSCAPE Then
                    Me.DefaultPageSettings.Landscape = True
                Else
                    Me.DefaultPageSettings.Landscape = False
                End If
            End If
        End Sub

        Private Sub ResolveMargins(ByVal theNode As XmlNode)
            Try
                Me.Margins.Top = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_TOP).Value)
                Me.Margins.Left = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_LFET).Value)
                Me.Margins.Bottom = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_BOTTOM).Value)
                Me.Margins.Right = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_MARGIN_RIGHT).Value)
            Catch generatedExceptionVariable0 As Exception
            End Try
        End Sub

        Private Sub ResolveParameterDeclaration(ByVal theNode As XmlNode)
            Dim childNodes As XmlNodeList = theNode.ChildNodes
            Dim nIndex As Integer = 0
            While nIndex < childNodes.Count
                Try
                    Dim parameterName As String = childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_NAME).Value
                    If Not m_AryDeclaredParameters.Contains(parameterName) Then
                        m_AryDeclaredParameters.Add(parameterName)
                    End If
                Catch generatedExceptionVariable0 As Exception
                End Try
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

        Private Sub ResolveContents(ByVal theNode As XmlNode)
            Dim temp As XmlNodeList = theNode.ChildNodes
            Dim nIndex As Integer = 0
            While nIndex < temp.Count
                Select Case temp(nIndex).Name
                    Case CONST_TEXT_NODE_DYNAMIC_CONTENT
                        m_XmlDynamicElements = temp(nIndex).ChildNodes
                    Case CONST_TEXT_NODE_STATIC_CONTENT
                        m_XmlStaticElements = temp(nIndex).ChildNodes
                End Select
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

        Private Function ResolveTextField(ByVal theNode As XmlNode, ByVal designMode As Boolean, ByVal bContinuouts As Boolean) As TextField
            Dim nX As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_X).Value)
            Dim nY As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_Y).Value)
            Dim nWidth As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_WIDTH).Value)
            Dim nHeight As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_HEIGHT).Value)
            Dim textField As TextField = New TextField(nX, nY, nWidth, nHeight, Me, False)
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_HOR_ALIGH) Is Nothing) Then
                textField.HorizontalAlignment = ResolveHorizontalAlignment(theNode.Attributes(CONST_TEXT_ATTRI_HOR_ALIGH).Value)
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_VER_ALIGH) Is Nothing) Then
                textField.VerticalAlignment = ResolveVerticalAlignment(theNode.Attributes(CONST_TEXT_ATTRI_VER_ALIGH).Value)
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_SELECTABLE) Is Nothing) Then
                textField.Selectable = Convert.ToBoolean(theNode.Attributes(CONST_TEXT_ATTRI_SELECTABLE).Value)
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_REPEAT) Is Nothing) Then
                textField.Repeat = Convert.ToBoolean(theNode.Attributes(CONST_TEXT_ATTRI_REPEAT).Value)
            Else
                If bContinuouts Then
                    textField.Repeat = False
                Else
                    textField.Repeat = True
                End If
            End If
            Dim childNodes As XmlNodeList = theNode.ChildNodes
            Dim nIndex As Integer = 0
            While nIndex < childNodes.Count
                Select Case childNodes(nIndex).Name
                    Case CONST_TEXT_NODE_TEXT
                        Dim strOutKey As String = ""
                        textField.Text = IIf(designMode, childNodes(nIndex).InnerText, ResolveParameterValues(childNodes(nIndex).InnerText, strOutKey)).ToString
                        textField.InitText = textField.Text 'the InitText means the value in print config file
                        Dim alignmentType As String = IIf(childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_HOR_ALIGH) Is Nothing, _
                                                                CONST_TEXT_ALIGN_LEFT, childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_HOR_ALIGH).Value).ToString
                        Select Case alignmentType
                            Case CONST_TEXT_ALIGN_CENTER
                                textField.TextAlignment = textField.TextAlignmentType.Center
                            Case CONST_TEXT_ALIGN_RIGHT
                                textField.TextAlignment = textField.TextAlignmentType.Right
                            Case CONST_TEXT_ALIGN_JUSTIFIED
                                textField.TextAlignment = textField.TextAlignmentType.Justified
                            Case Else
                                textField.TextAlignment = textField.TextAlignmentType.Left
                        End Select
                        If Not (childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_VER_ALIGH) Is Nothing) Then
                            Select Case childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_VER_ALIGH).Value
                                Case CONST_TEXT_ALIGN_MIDDLE
                                    textField.TextVerticalAlignment = textField.TextVerticalAlignmentType.Middle
                                Case CONST_TEXT_ALIGN_BOTTOM
                                    textField.TextVerticalAlignment = textField.TextVerticalAlignmentType.Bottom
                            End Select
                        End If
                    Case CONST_TEXT_NODE_FONT
                        textField.Font = ResolveFont(childNodes(nIndex))
                    Case CONST_TEXT_NODE_FORE_COLOR
                        Try
                            textField.ForegroundColor = Color.FromName(childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_COLOR).Value)
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                    Case CONST_TEXT_NODE_BACK_COLOR
                        Try
                            textField.BackgroundColor = Color.FromName(childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_COLOR).Value)
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                    Case CONST_TEXT_NODE_BORDER
                        Try
                            textField.BorderColor = Color.FromName(childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_COLOR).Value)
                            textField.BorderWidth = CInt(IIf(childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_WIDTH) Is Nothing, _
                                     0, Convert.ToInt32(childNodes(nIndex).Attributes(CONST_TEXT_ATTRI_WIDTH).Value)))
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                End Select
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return textField
        End Function
        Private Function ResolveBarCode(ByVal theNode As XmlNode, ByVal designMode As Boolean, ByVal bContinuouts As Boolean) As TextField
            Dim nX As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_X).Value)
            Dim nY As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_Y).Value)
            Dim nWidth As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_WIDTH).Value)
            Dim nHeight As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_HEIGHT).Value)
            Dim textField As TextField = New TextField(nX, nY, nWidth, nHeight, Me, True)
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_REPEAT) Is Nothing) Then
                textField.Repeat = Convert.ToBoolean(theNode.Attributes(CONST_TEXT_ATTRI_REPEAT).Value)
            Else
                If bContinuouts Then
                    textField.Repeat = False
                Else
                    textField.Repeat = True
                End If
            End If
            Dim childNodes As XmlNodeList = theNode.ChildNodes
            Dim nIndex As Integer = 0
            While nIndex < childNodes.Count
                Select Case childNodes(nIndex).Name
                    Case CONST_TEXT_NODE_TEXT
                        Dim strOutKey As String = ""
                        textField.Text = IIf(designMode, childNodes(nIndex).InnerText, ResolveParameterValues(childNodes(nIndex).InnerText, strOutKey)).ToString
                        textField.InitText = textField.Text 'the InitText means the value in print config file
                End Select
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return textField
        End Function
        Private Function ResolveHorizontalAlignment(ByVal theAlignment As String) As ICustomPaint.HorizontalAlignmentTypes
            If theAlignment = CONST_TEXT_ALIGN_CENTER Then
                Return ICustomPaint.HorizontalAlignmentTypes.Center
            Else
                If theAlignment = CONST_TEXT_ALIGN_LEFT Then
                    Return ICustomPaint.HorizontalAlignmentTypes.Left
                Else
                    If theAlignment = CONST_TEXT_ALIGN_RIGHT Then
                        Return ICustomPaint.HorizontalAlignmentTypes.Right
                    Else
                        Return ICustomPaint.HorizontalAlignmentTypes.None
                    End If
                End If
            End If
        End Function

        Private Function ResolveVerticalAlignment(ByVal theAlignment As String) As ICustomPaint.VerticalAlignmentTypes
            If theAlignment = CONST_TEXT_ALIGN_MIDDLE Then
                Return ICustomPaint.VerticalAlignmentTypes.Middle
            Else
                If theAlignment = CONST_TEXT_ALIGN_TOP Then
                    Return ICustomPaint.VerticalAlignmentTypes.Top
                Else
                    If theAlignment = CONST_TEXT_ALIGN_BOTTOM Then
                        Return ICustomPaint.VerticalAlignmentTypes.Bottom
                    Else
                        Return ICustomPaint.VerticalAlignmentTypes.None
                    End If
                End If
            End If
        End Function

        Private Function ResolveParameterValues(ByVal input As String, ByRef strOutKey As String) As String
            Dim szBuffer As String = ""
            Dim nOldPos As Integer = 0
            Dim nPos As Integer = input.IndexOf(CONST_TEXT_PARAMETER_INDICATOR, nOldPos)

            While Not (nPos = -1)
                szBuffer += input.Substring(nOldPos, nPos - nOldPos)
                If input.Substring(nPos + 2, 1).Equals("{") AndAlso Not (input.IndexOf("}", nPos + 2) = -1) Then
                    Dim parameterName As String = input.Substring(nPos + 3, input.IndexOf("}", nPos + 2) - nPos - 3).Trim
                    If m_HtSystemValues.ContainsKey(parameterName) Then
                        strOutKey = parameterName
                        szBuffer += m_HtSystemValues(parameterName).ToString
                    Else
                        If m_AryDeclaredParameters.Contains(parameterName) AndAlso m_HTParameterValues.ContainsKey(parameterName) Then
                            strOutKey = parameterName
                            szBuffer += m_HTParameterValues(parameterName).ToString
                        End If
                    End If
                    nOldPos = input.IndexOf("}", nPos + 2) + 1
                Else
                    nOldPos = nPos + 2
                End If
                nPos = input.IndexOf(CONST_TEXT_PARAMETER_INDICATOR, nOldPos)
            End While
            szBuffer += input.Substring(nOldPos)
            Return szBuffer
        End Function

        Private Function ResolveFont(ByVal theNode As XmlNode) As Font
            Try
                Dim oFont As Font
                Dim szFntName As String
                If theNode.Attributes(CONST_TEXT_ATTRI_FONT_FAMILY) Is Nothing Then
                    szFntName = CONST_TEXT_FONT_ARAIL
                Else
                    szFntName = theNode.Attributes(CONST_TEXT_ATTRI_FONT_FAMILY).Value
                End If
                Dim nFntSize As Integer
                If theNode.Attributes(CONST_TEXT_ATTRI_SIZE) Is Nothing Then
                    nFntSize = 10
                Else
                    nFntSize = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_SIZE).Value)
                End If
                Dim nFntStyle As String
                If theNode.Attributes(CONST_TEXT_ATTRI_STYLE) Is Nothing Then
                    nFntStyle = CONST_TEXT_FONT_REGULAR
                Else
                    nFntStyle = theNode.Attributes(CONST_TEXT_ATTRI_STYLE).Value
                End If

                Select Case nFntStyle
                    Case CONST_TEXT_FONT_BOLD_ITALIC
                        oFont = New Font(szFntName, nFntSize, FontStyle.Bold Or FontStyle.Italic)
                    Case CONST_TEXT_FONT_BOLD
                        oFont = New Font(szFntName, nFntSize, FontStyle.Bold)
                    Case CONST_TEXT_FONT_ITALIC
                        oFont = New Font(szFntName, nFntSize, FontStyle.Italic)
                    Case Else
                        oFont = New Font(szFntName, nFntSize, FontStyle.Regular)
                End Select
                Return oFont
            Catch generatedExceptionVariable0 As Exception
                Return New Font(CONST_TEXT_FONT_ARAIL, 8, FontStyle.Regular)
            End Try
        End Function

        Private Function ResolveTable(ByVal theNode As XmlNode) As StyledTable
            Dim nX As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_X).Value)
            Dim nY As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_Y).Value)
            Dim nWidth As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_WIDTH).Value)
            Dim nHeight As Integer = Convert.ToInt32(theNode.Attributes(CONST_TEXT_ATTRI_HEIGHT).Value)
            Dim oStyledTable As StyledTable = New StyledTable(nX, nY, nWidth, nHeight, Me)
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_Y2) Is Nothing OrElse theNode.Attributes(CONST_TEXT_ATTRI_Y2) Is Nothing) Then
                oStyledTable.SetRegion2(nX, CInt(theNode.Attributes(CONST_TEXT_ATTRI_Y2).Value), nWidth, CInt(theNode.Attributes(CONST_TEXT_ATTRI_HEIGHT2).Value))
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_HOR_ALIGH) Is Nothing) Then
                oStyledTable.HorizontalAlignment = ResolveHorizontalAlignment(theNode.Attributes(CONST_TEXT_ATTRI_HOR_ALIGH).Value)
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_VER_ALIGH) Is Nothing) Then
                oStyledTable.VerticalAlignment = ResolveVerticalAlignment(theNode.Attributes(CONST_TEXT_ATTRI_VER_ALIGH).Value)
            End If
            If Not (theNode.Attributes(CONST_TEXT_NODE_BORDER_COLOR) Is Nothing) Then
                oStyledTable.BorderColor = Color.FromName(theNode.Attributes(CONST_TEXT_NODE_BORDER_COLOR).Value)
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_SELECTABLE) Is Nothing) Then
                oStyledTable.Selectable = Convert.ToBoolean(theNode.Attributes(CONST_TEXT_ATTRI_SELECTABLE).Value)
            End If
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_GROUP_BY_FIELD) Is Nothing) Then
                oStyledTable.GroupByField = theNode.Attributes(CONST_TEXT_ATTRI_GROUP_BY_FIELD).Value
            End If
            Dim bHasDataSource As Boolean = False
            If Not (theNode.Attributes(CONST_TEXT_ATTRI_DATA_SOURCE) Is Nothing) Then
                oStyledTable.DataSource = theNode.Attributes(CONST_TEXT_ATTRI_DATA_SOURCE).Value
                bHasDataSource = True
            End If
            Try
                oStyledTable.DrawHeader = Convert.ToBoolean(IIf(theNode.Attributes(CONST_TEXT_SHOW_HEADER) Is Nothing, True, Convert.ToBoolean(theNode.Attributes(CONST_TEXT_SHOW_HEADER).Value)))
            Catch generatedExceptionVariable0 As Exception
            End Try
            Try
                oStyledTable.DrawEmptyRows = Convert.ToBoolean(IIf(theNode.Attributes(CONST_TEXT_DRAW_EMPTY_ROWS) Is Nothing, False, Convert.ToBoolean(theNode.Attributes(CONST_TEXT_DRAW_EMPTY_ROWS).Value)))
            Catch generatedExceptionVariable0 As Exception
            End Try
            Try
                oStyledTable.CellHeight = CInt(IIf(theNode.Attributes(CONST_TEXT_CELL_HEIGHT) Is Nothing, 18, Convert.ToInt32(theNode.Attributes(CONST_TEXT_CELL_HEIGHT).Value)))
            Catch generatedExceptionVariable0 As Exception
            End Try
            Dim oChildNodes As XmlNodeList = theNode.ChildNodes
            Dim nIndex As Integer = 0
            While nIndex < oChildNodes.Count
                Select Case oChildNodes(nIndex).Name
                    Case CONST_TEXT_NODE_COLUMNS
                        oStyledTable.Columns = Me.ResolveColumns(oChildNodes(nIndex), nWidth)
                    Case CONST_TEXT_NODE_HEADER
                        Try
                            oStyledTable.HeaderBackgroundColor = Color.FromName(oChildNodes(nIndex).Attributes(CONST_TEXT_ATTRI_HEADER_COLOR).Value)
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                        Try
                            oStyledTable.HeaderFontColor = Color.FromName(oChildNodes(nIndex).Attributes(CONST_TEXT_ATTRI_HEADER_FONT_COLOR).Value)
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                        Dim headerNodes As XmlNodeList = oChildNodes(nIndex).ChildNodes
                        Dim nSecIndex As Integer = 0
                        While nSecIndex < headerNodes.Count
                            Select Case headerNodes(nIndex).Name
                                Case CONST_TEXT_NODE_FONT
                                    oStyledTable.HeaderFont = ResolveFont(headerNodes(nSecIndex))
                            End Select
                            System.Threading.Interlocked.Increment(nSecIndex)
                        End While
                    Case CONST_TEXT_ATTRI_DATA_ROWS
                        Try
                            oStyledTable.DataFontColor = Color.FromName(oChildNodes(nIndex).Attributes(CONST_TEXT_ATTRI_DATA_FONT_COLOR).Value)
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                        Dim dataNodes As XmlNodeList = oChildNodes(nIndex).ChildNodes
                        Dim nSecIndex As Integer = 0
                        While nSecIndex < dataNodes.Count
                            Select Case dataNodes(nSecIndex).Name
                                Case CONST_TEXT_NODE_FONT
                                    oStyledTable.DataFont = ResolveFont(dataNodes(nSecIndex))
                            End Select
                            System.Threading.Interlocked.Increment(nSecIndex)
                        End While
                    Case CONST_TEXT_NODE_FONT
                        oStyledTable.DataFont = ResolveFont(oChildNodes(nIndex))
                    Case CONST_TEXT_NODE_DATA
                        If Not bHasDataSource Then
                            oStyledTable.Data = ResolveStaticTableData(oChildNodes(nIndex), oStyledTable.Columns)
                        End If
                End Select
                System.Threading.Interlocked.Increment(nIndex)
            End While
            If oStyledTable.Columns.Length = 0 Then
                If bHasDataSource AndAlso m_HtTables.Contains(oStyledTable.DataSource) Then
                    oStyledTable.Columns = CreateColumns(CType(m_HtTables(oStyledTable.DataSource), DataTable))
                Else
                    Dim kolone(1) As StyledTableColumn
                    kolone(0) = New StyledTableColumn
                    kolone(0).Label = "Wrong dataSource name"
                    oStyledTable.Columns = kolone
                End If
            End If
            Return oStyledTable
        End Function

        Private Function ResolveColumns(ByVal theNode As XmlNode, ByVal nWidth As Integer) As StyledTableColumn()
            Dim columnNodes As XmlNodeList = theNode.ChildNodes
            Dim result(columnNodes.Count - 1) As StyledTableColumn
            If columnNodes.Count = 0 Then
                If m_HtTables.Contains(CONST_TEXT_DEFAULT_PRINT_TABLE_NAME) Then
                    Dim dt As DataTable = CType(m_HtTables(CONST_TEXT_DEFAULT_PRINT_TABLE_NAME), DataTable)
                    ReDim result(dt.Columns.Count - 1)
                    Dim nIndex As Integer = 0
                    While nIndex < dt.Columns.Count
                        result(nIndex) = New StyledTableColumn
                        Try
                            result(nIndex).Name = dt.Columns(nIndex).ColumnName
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                        Try
                            result(nIndex).Label = dt.Columns(nIndex).ColumnName
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                        Try
                            result(nIndex).FormatMask = ""
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                        Try
                            result(nIndex).Visible = True
                        Catch generatedExceptionVariable0 As Exception
                        End Try
                        Try
                            result(nIndex).Width = CInt(nWidth / dt.Columns.Count)
                        Catch generatedExceptionVariable0 As Exception
                        End Try

                        '设置列的类型
                        If dt.Columns(nIndex).GetType Is GetType(Boolean) Then
                            result(nIndex).Type = StyledTableColumn.ColumnType.Check
                        Else
                            result(nIndex).Type = StyledTableColumn.ColumnType.Text
                        End If

                        '列为CheckBox列时，设置需要打勾的数据值
                        If dt.Columns(nIndex).GetType Is GetType(Boolean) Then
                            'TrueValue暂且为String型，打印时会转换成相应列的数据类型
                            result(nIndex).TrueValue = dt.Columns(nIndex).DefaultValue
                        End If

                        result(nIndex).Alignment = StyledTableColumn.AlignmentType.Left

                        'StaticValue
                        Try
                            result(nIndex).bStatic = False
                            result(nIndex).StaticValue = ""
                        Catch generatedExceptionVariable0 As Exception
                        End Try


                        System.Threading.Interlocked.Increment(nIndex)
                    End While
                End If
            Else
                ReDim result(columnNodes.Count - 1)
                Dim nIndex As Integer = 0
                While nIndex < columnNodes.Count
                    result(nIndex) = New StyledTableColumn
                    Try
                        result(nIndex).Name = columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_NAME).Value
                    Catch generatedExceptionVariable0 As Exception
                    End Try
                    Try
                        result(nIndex).Label = columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_LABEL).Value
                    Catch generatedExceptionVariable0 As Exception
                    End Try
                    Try
                        result(nIndex).FormatMask = columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_FORMAT_MASK).Value
                    Catch generatedExceptionVariable0 As Exception
                    End Try
                    Try
                        result(nIndex).bStatic = Convert.ToBoolean(columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_STATIC).Value)
                        If result(nIndex).bStatic Then
                            result(nIndex).StaticValue = columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_STATIC_VALUE).Value
                        End If
                    Catch generatedExceptionVariable0 As Exception
                    End Try
                    Try
                        result(nIndex).Visible = Convert.ToBoolean(columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_VISIBLE).Value)
                    Catch generatedExceptionVariable0 As Exception
                    End Try
                    Try
                        result(nIndex).Width = Convert.ToInt32(columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_WIDTH).Value)
                    Catch generatedExceptionVariable0 As Exception
                    End Try

                    '设置列的类型
                    If Not columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_TYPE) Is Nothing _
                                    AndAlso columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_TYPE).Value = CONST_TEXT_CHECK Then
                        result(nIndex).Type = StyledTableColumn.ColumnType.Check
                    Else
                        result(nIndex).Type = StyledTableColumn.ColumnType.Text
                    End If

                    '列为CheckBox列时，设置需要打勾的数据值
                    If Not columnNodes(nIndex).Attributes(CONST_TEXT_TRUE_VALUE) Is Nothing Then
                        'TrueValue暂且为String型，打印时会转换成相应列的数据类型
                        result(nIndex).TrueValue = columnNodes(nIndex).Attributes(CONST_TEXT_TRUE_VALUE).Value
                    End If

                    Try
                        Dim align As String = columnNodes(nIndex).Attributes(CONST_TEXT_ATTRI_ALIGN).Value
                        Select Case align
                            Case CONST_TEXT_ALIGN_CENTER
                                result(nIndex).Alignment = StyledTableColumn.AlignmentType.Center
                            Case CONST_TEXT_ALIGN_RIGHT
                                result(nIndex).Alignment = StyledTableColumn.AlignmentType.Right
                            Case Else
                                result(nIndex).Alignment = StyledTableColumn.AlignmentType.Left
                        End Select
                    Catch generatedExceptionVariable0 As Exception
                        result(nIndex).Alignment = StyledTableColumn.AlignmentType.Left
                    End Try
                    System.Threading.Interlocked.Increment(nIndex)
                End While
            End If

            Return result
        End Function

        Private Function ResolveStaticTableData(ByVal theNode As XmlNode, ByVal staticColumns As StyledTableColumn()) As DataTable
            Dim oDataTable As DataTable = New DataTable
            Dim oRecordNodes As XmlNodeList = theNode.ChildNodes
            Dim nRecordCount As Integer = oRecordNodes.Count
            If nRecordCount > 0 Then
                Dim nColumnCount As Integer = staticColumns.Length
                Dim nIndex As Integer = 0
                While nIndex < nColumnCount
                    oDataTable.Columns.Add(New DataColumn(staticColumns(nIndex).Name))
                    System.Threading.Interlocked.Increment(nIndex)
                End While
                nIndex = 0
                While nIndex < oRecordNodes.Count
                    Dim oFieldNodes As XmlNodeList = oRecordNodes(nIndex).ChildNodes
                    Dim szRow(nColumnCount) As String
                    Dim nSecIndex As Integer = 0
                    While nSecIndex < nColumnCount
                        Try
                            Dim strOutKey As String = ""
                            szRow(nSecIndex) = ResolveParameterValues(oFieldNodes(nSecIndex).InnerText, strOutKey)
                        Catch generatedExceptionVariable0 As Exception
                            szRow(nSecIndex) = ""
                        End Try
                        System.Threading.Interlocked.Increment(nSecIndex)
                    End While
                    oDataTable.Rows.Add(szRow)
                    System.Threading.Interlocked.Increment(nIndex)
                End While
            End If
            Return oDataTable
        End Function

        Private Function CreateColumns(ByVal masterTable As DataTable) As StyledTableColumn()
            Dim cols(masterTable.Columns.Count) As StyledTableColumn
            Dim nIndex As Integer = 0
            While nIndex < masterTable.Columns.Count
                cols(nIndex) = New StyledTableColumn
                cols(nIndex).Name = masterTable.Columns(nIndex).ColumnName
                cols(nIndex).Label = masterTable.Columns(nIndex).ColumnName
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return cols
        End Function

        Private Sub InitDynamicObjects(ByVal designMode As Boolean)
            If m_XmlDynamicElements Is Nothing Then
                m_DynamicObjects = New ICustomPaint(0) {}
                Return
            End If
            m_DynamicObjects = New ICustomPaint(m_XmlDynamicElements.Count) {}
            Dim nTableBottom As Integer = 0
            Dim nIndex As Integer = 0
            While nIndex < m_XmlDynamicElements.Count
                Select Case m_XmlDynamicElements(nIndex).Name
                    Case CONST_TEXT_NODE_TEXT_FIELD
                        DynamicObjects(nIndex) = ResolveTextField(m_XmlDynamicElements(nIndex), designMode, False)
                    Case CONST_TEXT_NODE_TABLE
                        DynamicObjects(nIndex) = ResolveTable(m_XmlDynamicElements(nIndex))
                        Dim table As StyledTable = CType(DynamicObjects(nIndex), StyledTable)
                        If nTableBottom < table.Y + table.Height Then nTableBottom = table.Y + table.Height
                    Case Else
                        DynamicObjects(nIndex) = Nothing
                End Select
                System.Threading.Interlocked.Increment(nIndex)
            End While
            m_nMaxHeight = nTableBottom 'if there is no table, then m_nMaxHeight will not be used.
            nIndex = 0
            While nIndex < DynamicObjects.Length
                If TypeOf DynamicObjects(nIndex) Is StyledTable Then
                    CType(DynamicObjects(nIndex), StyledTable).PageMaxHeight = m_nMaxHeight
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

        Public Sub InitStaticObjects(ByVal designMode As Boolean)
            If m_XmlStaticElements Is Nothing Then
                m_StaticObjects = New ICustomPaint(0) {}
                Return
            End If
            m_StaticObjects = New ICustomPaint(m_XmlStaticElements.Count) {}
            Dim nIndex As Integer = 0
            While nIndex < m_XmlStaticElements.Count
                Select Case m_XmlStaticElements(nIndex).Name
                    Case CONST_TEXT_NODE_TEXT_FIELD
                        m_StaticObjects(nIndex) = ResolveTextField(m_XmlStaticElements(nIndex), designMode, False)
                    Case CONST_TEXT_NODE_TABLE
                        m_StaticObjects(nIndex) = ResolveTable(m_XmlStaticElements(nIndex))
                    Case CONST_TEXT_NODE_BARCODE
                        m_StaticObjects(nIndex) = ResolveBarCode(m_XmlStaticElements(nIndex), designMode, False)
                    Case Else
                        m_StaticObjects(nIndex) = Nothing
                End Select
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

#End Region
        Private Function CalculateContinuousNumberOfPagesEx(ByVal g As Graphics) As Integer
            Dim nPages As Integer = 0
            Dim nLastpos As Integer = 0
            If m_aryKeys.Count = 1 Then
                nPages = CalculateContinuousNumberOfPages(g)
            Else
                For Each strKey As String In m_aryKeys
                    Do
                        Dim dt As DataTable = CType(m_HtTables.Item(strKey), DataTable)
                        If Not dt Is Nothing Then
                            If nLastpos = 0 Then 'apply to the xml file
                                Dim nIndex As Integer = 0
                                While nIndex < m_DynamicObjects.Length
                                    If Not (m_DynamicObjects(nIndex) Is Nothing) AndAlso TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                                        Dim styleTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                                        Dim nHeaderHeight As Integer = styleTable.CalculateRelativeHeaderHeight(g) '标题打印占用的行数
                                        Dim nRowTotalHeight As Integer = nHeaderHeight 'Row 占用行数
                                        For Each row As DataRow In dt.Rows
                                            nRowTotalHeight += styleTable.CalculateRelativeDataRowHeight(row, g)
                                        Next
                                        Dim nTableMaxLine As Integer = CInt(Math.Floor(CDbl(styleTable.Height / styleTable.CellHeight)))
                                        Dim nPagesForTable As Integer = CInt(Math.Ceiling(CDbl(nRowTotalHeight / nTableMaxLine)))
                                        If nPagesForTable * nTableMaxLine = nRowTotalHeight Then '如果页面刚好被打完，要重启一页
                                            nLastpos = 0
                                        Else '如果不是，那么记录下最后的位置
                                            nLastpos = CInt(IIf(nPages > 1, CONST_INTEGER_DEFAULT_SPACE, styleTable.Y)) + styleTable.CellHeight * (nRowTotalHeight - (nPagesForTable - 1) * nTableMaxLine)
                                        End If
                                        nPages += nPagesForTable
                                    End If
                                    System.Threading.Interlocked.Increment(nIndex)
                                End While
                                Exit Do
                            Else 'nLastpos not 0，接着上一次的打印位置
                                Dim nTop As Integer = 9999
                                Dim nBottom As Integer = 0
                                If GetStatiticsParamsLegend(CType(Me.m_HTParaCollection.Item(strKey), Hashtable), nTop, nBottom) Then
                                    '如果打印子头不下，那么另起一页，go do
                                    If nLastpos + CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING + (nBottom - nTop) > m_nMaxHeight Then
                                        nLastpos = 0
                                    Else 'go on for the table
                                        nLastpos += (CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT + CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT) * CONST_INTEGER_DEFAULT_LEADING + (nBottom - nTop)
                                        Dim nIndex As Integer = 0
                                        Dim bFirstTable As Boolean = True 'until now, it has only one table in print config file
                                        While nIndex < m_DynamicObjects.Length
                                            If Not (m_DynamicObjects(nIndex) Is Nothing) AndAlso TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                                                Dim styleTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                                                Dim nTableMaxLine As Integer = CInt(Math.Floor(CDbl(styleTable.Height / styleTable.CellHeight)))
                                                Dim nHeaderHeight As Integer = styleTable.CalculateRelativeHeaderHeight(g) '标题打印占用的行数
                                                Dim nRowTotalHeight As Integer = nHeaderHeight 'Row 占用行数
                                                Dim nRowCountLeft As Integer = 0 '剩余未打印的行数
                                                Dim nPageLeftCount As Integer = CInt(Math.Floor(CDbl(m_nMaxHeight - nLastpos) / styleTable.CellHeight)) '纸张剩余的打印行
                                                For Each row As DataRow In dt.Rows
                                                    Dim nEachRowHeight As Integer = styleTable.CalculateRelativeDataRowHeight(row, g)
                                                    nRowTotalHeight += nEachRowHeight
                                                    If nRowTotalHeight > nPageLeftCount Then
                                                        nRowCountLeft += nEachRowHeight
                                                    End If
                                                Next

                                                If bFirstTable Then '如果不是第一张表，会另起一页（？）
                                                    If m_nMaxHeight - nLastpos < 0 Then
                                                        nLastpos = 0
                                                        Continue Do
                                                    End If
                                                    If nRowTotalHeight <= nPageLeftCount Then
                                                        nLastpos += nRowTotalHeight * styleTable.CellHeight
                                                    End If
                                                    bFirstTable = False
                                                End If
                                                If nRowCountLeft > 0 Then
                                                    Dim nPagesForTable As Integer = 1
                                                    While True
                                                        Dim nTableMax As Integer = CInt(IIf(nPagesForTable > 0, CInt(Math.Floor(CDbl(m_nMaxHeight / styleTable.CellHeight))), nTableMaxLine))
                                                        If nRowCountLeft + nHeaderHeight > nTableMax Then
                                                            nPagesForTable += 1
                                                            nRowCountLeft -= nTableMax - nHeaderHeight
                                                        Else '不足到一页
                                                            nLastpos = styleTable.CellHeight * (nRowCountLeft + nHeaderHeight)
                                                            Exit While
                                                        End If
                                                    End While
                                                    nPages += nPagesForTable
                                                End If
                                            End If
                                            System.Threading.Interlocked.Increment(nIndex)
                                        End While
                                        Exit Do
                                    End If
                                Else 'bTextFieldDisPatched = false
                                    Exit Do
                                End If
                            End If 'judge nLastpos
                        Else 'dt is nothing
                            Exit Do
                        End If
                    Loop
                Next
            End If
            Return nPages
        End Function
        Private Function CalculateContinuousNumberOfPages(ByVal g As Graphics) As Integer
            Dim nResult As Integer = 1
            Dim nIndex As Integer = 0
            While nIndex < m_DynamicObjects.Length
                If Not (m_DynamicObjects(nIndex) Is Nothing) AndAlso TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                    Dim tempTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                    tempTable.DataSource = GetHashTableKey()
                    If Not (tempTable.DataSource Is Nothing) AndAlso m_HtTables.Contains(tempTable.DataSource) Then
                        Dim szTableName As String = tempTable.DataSource
                        Dim oDataTable As DataTable = CType(m_HtTables(szTableName), DataTable)
                        Dim bMore As Boolean = False
                        Dim nCounted As Integer = 0 '累计打印的记录数
                        Dim nNumPages As Integer = 0
                        Dim nRowsPerPage As Integer '当前页可以打印的行数
                        Do
                            If nNumPages = 0 Then
                                nRowsPerPage = tempTable.GetPossibleRowNumber
                            Else
                                nRowsPerPage = tempTable.GetPossibleRowNumber3(m_nContinuousYStartPos, m_nContinuousYStartPos = CONST_INTEGER_DEFAULT_SPACE)
                            End If
                            Dim nRelativeHeaderHeight As Integer = tempTable.CalculateRelativeHeaderHeight(g) '标题打印占用的行数
                            Dim nRowsForPrint As Integer = 0 '当前页打印的记录数
                            Dim nRelativeHeight As Integer = 0 '当前页记录打印累计占用的行数
                            Dim nRelativeDataRowHeight As Integer = 0 '当前记录打印占用的行数
                            Do
                                If oDataTable.Rows.Count <= nCounted + nRowsForPrint Then
                                    Exit Do
                                End If
                                Dim oRow As DataRow = oDataTable.Rows(nCounted + nRowsForPrint)
                                nRelativeDataRowHeight = tempTable.CalculateRelativeDataRowHeight(oRow, g)
                                If nRelativeHeaderHeight + nRelativeHeight + nRelativeDataRowHeight <= nRowsPerPage Then
                                    nRelativeHeight += nRelativeDataRowHeight
                                    System.Threading.Interlocked.Increment(nRowsForPrint)
                                Else
                                    Exit Do
                                End If
                            Loop
                            nCounted += nRowsForPrint
                            System.Threading.Interlocked.Increment(nNumPages)
                            bMore = oDataTable.Rows.Count > nCounted
                        Loop While bMore
                        nResult = Math.Max(nResult, nNumPages)
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return nResult
        End Function

        Private Function CalculateNumberOfPagesEx(ByVal g As Graphics) As Integer
            Dim nPages As Integer = 0
            Dim nLastpos As Integer = 0
            If m_aryKeys.Count = 1 Then
                nPages = CalculateNumberOfPages(g)
            Else
                For Each strKey As String In m_aryKeys
                    Do
                        Dim dt As DataTable = CType(m_HtTables.Item(strKey), DataTable)
                        If Not dt Is Nothing Then
                            If nLastpos = 0 Then 'apply to the xml file
                                Dim nIndex As Integer = 0
                                While nIndex < m_DynamicObjects.Length
                                    If Not (m_DynamicObjects(nIndex) Is Nothing) AndAlso TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                                        Dim styleTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                                        Dim nHeaderHeight As Integer = styleTable.CalculateRelativeHeaderHeight(g) '标题打印占用的行数
                                        Dim nRowTotalHeight As Integer = nHeaderHeight 'Row 占用行数
                                        For Each row As DataRow In dt.Rows
                                            nRowTotalHeight += styleTable.CalculateRelativeDataRowHeight(row, g)
                                        Next
                                        Dim nTableMaxLine As Integer = CInt(Math.Floor(CDbl(styleTable.Height / styleTable.CellHeight)))
                                        Dim nPagesForTable As Integer = CInt(Math.Ceiling(CDbl(nRowTotalHeight / nTableMaxLine)))
                                        If nPagesForTable * nTableMaxLine = nRowTotalHeight Then '如果页面刚好被打完，要重启一页
                                            nLastpos = 0
                                        Else '如果不是，那么记录下最后的位置
                                            nLastpos = styleTable.Y + styleTable.CellHeight * (nRowTotalHeight - (nPagesForTable - 1) * nTableMaxLine)
                                        End If
                                        nPages += nPagesForTable
                                    End If
                                    System.Threading.Interlocked.Increment(nIndex)
                                End While
                                Exit Do
                            Else 'nLastpos not 0，接着上一次的打印位置
                                Dim nTop As Integer = 9999
                                Dim nBottom As Integer = 0
                                If GetStatiticsParamsLegend(CType(Me.m_HTParaCollection.Item(strKey), Hashtable), nTop, nBottom) Then
                                    '如果打印子头不下，那么另起一页，go do
                                    If nLastpos + CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING + (nBottom - nTop) > m_nMaxHeight Then
                                        nLastpos = 0
                                    Else 'go on for the table
                                        nLastpos += (CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT + CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT) * CONST_INTEGER_DEFAULT_LEADING + (nBottom - nTop)
                                        Dim nIndex As Integer = 0
                                        Dim bFirstTable As Boolean = True 'until now, it has only one table in print config file
                                        While nIndex < m_DynamicObjects.Length
                                            If Not (m_DynamicObjects(nIndex) Is Nothing) AndAlso TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                                                Dim styleTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                                                Dim nTableMaxLine As Integer = CInt(Math.Floor(CDbl(styleTable.Height / styleTable.CellHeight)))
                                                Dim nHeaderHeight As Integer = styleTable.CalculateRelativeHeaderHeight(g) '标题打印占用的行数
                                                Dim nRowTotalHeight As Integer = nHeaderHeight 'Row 占用行数
                                                Dim nRowCountLeft As Integer = 0 '剩余未打印的行数
                                                Dim nPageLeftCount As Integer = CInt(Math.Floor(CDbl(m_nMaxHeight - nLastpos) / styleTable.CellHeight)) '纸张剩余的打印行
                                                For Each row As DataRow In dt.Rows
                                                    Dim nEachRowHeight As Integer = styleTable.CalculateRelativeDataRowHeight(row, g)
                                                    nRowTotalHeight += nEachRowHeight
                                                    If nRowTotalHeight > nPageLeftCount Then
                                                        nRowCountLeft += nEachRowHeight
                                                    End If
                                                Next

                                                If bFirstTable Then '如果不是第一张表，会另起一页（？）
                                                    If m_nMaxHeight - nLastpos < 0 Then
                                                        nLastpos = 0
                                                        Continue Do
                                                    End If
                                                    If nRowTotalHeight <= nPageLeftCount Then
                                                        nLastpos += nRowTotalHeight * styleTable.CellHeight
                                                    End If
                                                    bFirstTable = False
                                                End If
                                                If nRowCountLeft > 0 Then
                                                    Dim nPagesForTable As Integer = 1
                                                    While True
                                                        If nRowCountLeft + nHeaderHeight > nTableMaxLine Then
                                                            nPagesForTable += 1
                                                            nRowCountLeft -= nTableMaxLine - nHeaderHeight
                                                        Else '不足到一页
                                                            nLastpos = styleTable.Y + styleTable.CellHeight * (nRowCountLeft + nHeaderHeight)
                                                            Exit While
                                                        End If
                                                    End While
                                                    nPages += nPagesForTable
                                                End If
                                            End If
                                            System.Threading.Interlocked.Increment(nIndex)
                                        End While
                                        Exit Do
                                    End If
                                Else 'bTextFieldDisPatched = false
                                    Exit Do
                                End If
                            End If 'judge nLastpos
                        Else 'dt is nothing
                            Exit Do
                        End If
                    Loop
                Next
            End If
            Return nPages
        End Function

        Private Function GetStatiticsParamsLegend(ByVal htParams As Hashtable, ByRef nTop As Integer, ByRef nBottom As Integer) As Boolean
            If htParams Is Nothing Then Return False
            Dim bTextFieldDisPatched As Boolean = False
            Dim em As IDictionaryEnumerator = htParams.GetEnumerator
            While em.MoveNext
                Dim oTextField As TextField = GetStaticTextField(em.Key.ToString)
                If Not oTextField Is Nothing Then
                    If nTop > oTextField.Y Then nTop = oTextField.Y
                    If nBottom < oTextField.Y + oTextField.Height Then nBottom = oTextField.Y + oTextField.Height
                    bTextFieldDisPatched = True
                End If
            End While
            Return bTextFieldDisPatched
        End Function

        Private Function CalculateNumberOfPages(ByVal g As Graphics) As Integer
            Dim nResult As Integer = 1
            Dim nIndex As Integer = 0
            While nIndex < m_DynamicObjects.Length
                If Not (m_DynamicObjects(nIndex) Is Nothing) AndAlso TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                    Dim tempTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                    tempTable.DataSource = GetHashTableKey()
                    If Not (tempTable.DataSource Is Nothing) AndAlso m_HtTables.Contains(tempTable.DataSource) Then
                        Dim szTableName As String = tempTable.DataSource
                        Dim oDataTable As DataTable = CType(m_HtTables(szTableName), DataTable)
                        Dim bMore As Boolean = False
                        Dim nCounted As Integer = 0 '累计打印的记录数
                        Dim nNumPages As Integer = 0
                        Dim nRowsPerPage As Integer '当前页可以打印的行数
                        Do
                            If nNumPages = 0 Then
                                nRowsPerPage = tempTable.GetPossibleRowNumber
                            Else
                                nRowsPerPage = tempTable.GetPossibleRowNumber2
                            End If
                            Dim nRelativeHeaderHeight As Integer = tempTable.CalculateRelativeHeaderHeight(g) '标题打印占用的行数
                            Dim nRowsForPrint As Integer = 0 '当前页打印的记录数
                            Dim nRelativeHeight As Integer = 0 '当前页记录打印累计占用的行数
                            Dim nRelativeDataRowHeight As Integer = 0 '当前记录打印占用的行数
                            Do
                                If oDataTable.Rows.Count <= nCounted + nRowsForPrint Then
                                    Exit Do
                                End If
                                Dim oRow As DataRow = oDataTable.Rows(nCounted + nRowsForPrint)
                                nRelativeDataRowHeight = tempTable.CalculateRelativeDataRowHeight(oRow, g)
                                If nRelativeHeaderHeight + nRelativeHeight + nRelativeDataRowHeight <= nRowsPerPage Then
                                    nRelativeHeight += nRelativeDataRowHeight
                                    System.Threading.Interlocked.Increment(nRowsForPrint)
                                Else
                                    Exit Do
                                End If
                            Loop
                            nCounted += nRowsForPrint
                            System.Threading.Interlocked.Increment(nNumPages)
                            bMore = oDataTable.Rows.Count > nCounted
                        Loop While bMore
                        nResult = Math.Max(nResult, nNumPages)
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return nResult
        End Function
        Private Function UpdateContinuousDynamicContent(ByVal g As Graphics) As Boolean
            Dim printMore As Boolean = False
            m_bNeedContinuousFirstTitle = True
            Dim nIndex As Integer = 0
            While nIndex < m_DynamicObjects.Length
                If Not (m_DynamicObjects(nIndex) Is Nothing) Then
                    If TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                        Dim tempTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                        tempTable.DataSource = GetHashTableKey()
                        If Not (tempTable.DataSource Is Nothing) AndAlso m_HtTables.Contains(tempTable.DataSource) Then
                            Dim nYOffset As Integer
                            If CInt(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) = 1 Then
                                nYOffset = CInt(IIf(m_nLastPos = 0, 0, m_nLastPos + CONST_INTEGER_DEFAULT_LEADING - tempTable.Y))
                            Else
                                nYOffset = CInt(IIf(m_nContinuousYStartPos = CONST_INTEGER_DEFAULT_SPACE, m_nLastPos + m_nContinuousYStartPos - tempTable.Y, m_nLastPos + CONST_INTEGER_DEFAULT_LEADING - tempTable.Y))
                            End If
                            tempTable.YOffset = nYOffset
                            Dim theTableName As String = tempTable.DataSource
                            Dim podaci As DataTable = CType(m_HtTables(theTableName), DataTable)
                            If Not (tempTable.GroupByField = "") Then
                                podaci = Me.SetGroupByOnDataTable(podaci, tempTable.GroupByField)
                            End If
                            Try
                                Dim relativeHeaderHeight As Integer = tempTable.CalculateRelativeHeaderHeight(g)
                                Dim rowsForPrint As Integer = 0
                                Dim relativeHeight As Integer = 0
                                Dim relativeDataRowHeight As Integer = 0
                                Dim nRowsPerPage As Integer '当前页可以打印的行数
                                Do
                                    If CInt(Me.m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) = 1 Then
                                        nRowsPerPage = tempTable.GetPossibleRowNumber
                                    Else
                                        nRowsPerPage = tempTable.GetPossibleRowNumber3(m_nContinuousYStartPos, m_nContinuousYStartPos = CONST_INTEGER_DEFAULT_SPACE)
                                    End If
                                    If podaci.Rows.Count <= CType(m_HtRowsPrintedSoFar(theTableName), Integer) + rowsForPrint Then
                                        Exit Do
                                    End If
                                    Dim nextRow As DataRow = podaci.Rows(CType(m_HtRowsPrintedSoFar(theTableName), Integer) + rowsForPrint)
                                    relativeDataRowHeight = tempTable.CalculateRelativeDataRowHeight(nextRow, g)
                                    If relativeHeaderHeight + relativeHeight + relativeDataRowHeight <= nRowsPerPage Then
                                        relativeHeight += relativeDataRowHeight
                                        System.Threading.Interlocked.Increment(rowsForPrint)
                                    Else
                                        Exit Do
                                    End If
                                Loop
                                tempTable.Data = CreateSubtable(podaci, tempTable, CType(m_HtRowsPrintedSoFar(theTableName), Integer), rowsForPrint)
                                m_HtRowsPrintedSoFar(theTableName) = rowsForPrint + CType(m_HtRowsPrintedSoFar(theTableName), Integer)
                                If podaci.Rows.Count > CType(m_HtRowsPrintedSoFar(theTableName), Integer) Then
                                    printMore = CInt(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) < CInt(m_HtSystemValues(CONST_TEXT_TOTAL_PAGES))
                                    m_bNeedContinuousFirstTitle = False
                                End If
                                If printMore = False Then 'need not print more, that means this piece of print cource is over.
                                    Dim nStartPos As Integer
                                    If CInt(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) > 1 Then
                                        nStartPos = CInt(IIf(m_nLastPos = 0, m_nContinuousYStartPos, m_nLastPos + CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING))
                                    Else
                                        nStartPos = CInt(IIf(m_nLastPos = 0, tempTable.Y, m_nLastPos + CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING))
                                    End If
                                    m_nLastPos = nStartPos + (relativeHeight + relativeHeaderHeight) * tempTable.CellHeight
                                    m_nFooterPos = m_nLastPos
                                Else
                                    If CInt(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) > 1 Then
                                        m_nFooterPos = CInt(IIf(m_nLastPos = 0, m_nContinuousYStartPos, m_nLastPos)) + (relativeHeight + relativeHeaderHeight) * tempTable.CellHeight + CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING
                                    Else
                                        m_nFooterPos = CInt(IIf(m_nLastPos = 0, tempTable.Y, m_nLastPos)) + (relativeHeight + relativeHeaderHeight) * tempTable.CellHeight + CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING
                                    End If
                                    m_nLastPos = 0
                                End If
                            Catch e As Exception
                                printMore = False
                                m_bNeedContinuousFirstTitle = True
                                Dim kolone(1) As StyledTableColumn
                                kolone(0) = New StyledTableColumn
                                kolone(0).Label = e.Message
                                tempTable.Columns = kolone
                            End Try
                        End If
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return printMore
        End Function
        Private Function UpdateDynamicContent(ByVal g As Graphics) As Boolean
            Dim printMore As Boolean = False
            Dim nIndex As Integer = 0
            While nIndex < m_DynamicObjects.Length
                If Not (m_DynamicObjects(nIndex) Is Nothing) Then
                    If TypeOf m_DynamicObjects(nIndex) Is TextField Then
                        Dim theText As String = ""
                        Dim nSecIndex As Integer = 0
                        While nSecIndex < m_XmlDynamicElements(nIndex).ChildNodes.Count
                            If m_XmlDynamicElements(nIndex).ChildNodes(nSecIndex).Name.Equals(CONST_TEXT_NODE_TEXT) Then
                                theText = m_XmlDynamicElements(nIndex).ChildNodes(nSecIndex).InnerText
                            End If
                            System.Threading.Interlocked.Increment(nSecIndex)
                        End While
                        Dim strOutKey As String = ""
                        CType(m_DynamicObjects(nIndex), TextField).Text = ResolveParameterValues(theText, strOutKey)
                    Else
                        If TypeOf m_DynamicObjects(nIndex) Is StyledTable Then
                            Dim tempTable As StyledTable = CType(m_DynamicObjects(nIndex), StyledTable)
                            tempTable.DataSource = GetHashTableKey()
                            If Not (tempTable.DataSource Is Nothing) AndAlso m_HtTables.Contains(tempTable.DataSource) Then
                                Dim nYOffset As Integer = CInt(IIf(m_nLastPos = 0, 0, m_nLastPos + CONST_INTEGER_DEFAULT_LEADING - tempTable.Y))
                                tempTable.YOffset = nYOffset
                                Dim theTableName As String = tempTable.DataSource
                                Dim podaci As DataTable = CType(m_HtTables(theTableName), DataTable)
                                If Not (tempTable.GroupByField = "") Then
                                    podaci = Me.SetGroupByOnDataTable(podaci, tempTable.GroupByField)
                                End If
                                Try
                                    Dim relativeHeaderHeight As Integer = tempTable.CalculateRelativeHeaderHeight(g)
                                    Dim rowsForPrint As Integer = 0
                                    Dim relativeHeight As Integer = 0
                                    Dim relativeDataRowHeight As Integer = 0
                                    Dim nRowsPerPage As Integer '当前页可以打印的行数
                                    Do
                                        If CInt(Me.m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) = 1 Then
                                            nRowsPerPage = tempTable.GetPossibleRowNumber
                                        Else
                                            nRowsPerPage = tempTable.GetPossibleRowNumber2
                                        End If
                                        If podaci.Rows.Count <= CType(m_HtRowsPrintedSoFar(theTableName), Integer) + rowsForPrint Then
                                            Exit Do
                                        End If
                                        Dim nextRow As DataRow = podaci.Rows(CType(m_HtRowsPrintedSoFar(theTableName), Integer) + rowsForPrint)
                                        relativeDataRowHeight = tempTable.CalculateRelativeDataRowHeight(nextRow, g)
                                        If relativeHeaderHeight + relativeHeight + relativeDataRowHeight <= nRowsPerPage Then
                                            relativeHeight += relativeDataRowHeight
                                            System.Threading.Interlocked.Increment(rowsForPrint)
                                        Else
                                            Exit Do
                                        End If
                                    Loop
                                    tempTable.Data = CreateSubtable(podaci, tempTable, CType(m_HtRowsPrintedSoFar(theTableName), Integer), rowsForPrint)
                                    m_HtRowsPrintedSoFar(theTableName) = rowsForPrint + CType(m_HtRowsPrintedSoFar(theTableName), Integer)
                                    If podaci.Rows.Count > CType(m_HtRowsPrintedSoFar(theTableName), Integer) Then
                                        printMore = CInt(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) < CInt(m_HtSystemValues(CONST_TEXT_TOTAL_PAGES))
                                    End If
                                    If printMore = False Then 'need not print more, that means this piece of print cource is over. fpf, 2009.11.17
                                        Dim nStartPos As Integer = CInt(IIf(m_nLastPos = 0, tempTable.Y, m_nLastPos + CONST_INTEGER_PIECE_HEAD_AFTER_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING))
                                        m_nLastPos = nStartPos + (relativeHeight + relativeHeaderHeight) * tempTable.CellHeight
                                    Else
                                        m_nLastPos = 0
                                    End If
                                Catch e As Exception
                                    printMore = False
                                    Dim kolone(1) As StyledTableColumn
                                    kolone(0) = New StyledTableColumn
                                    kolone(0).Label = e.Message
                                    tempTable.Columns = kolone
                                End Try
                            End If
                        End If
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return printMore
        End Function

        Private Function CreateSubtable(ByVal masterTable As DataTable, ByVal styledTable As StyledTable, ByVal start As Integer, ByVal length As Integer) As DataTable
            Dim oCurrentData As DataTable = New DataTable
            If styledTable.Columns.Length > 0 Then
                Dim nIndex As Integer = 0
                While nIndex < styledTable.Columns.Length
                    'modify by lch 2012-5-22 支持打印配置文件自定义空白列
                    If styledTable.Columns(nIndex).bStatic Then
                        oCurrentData.Columns.Add(styledTable.Columns(nIndex).Name)
                    Else
                        If masterTable.Columns.Contains(styledTable.Columns(nIndex).Name) Then
                            Dim nOrd As Integer = masterTable.Columns.IndexOf(styledTable.Columns(nIndex).Name)
                            oCurrentData.Columns.Add(New DataColumn(masterTable.Columns(nOrd).ColumnName, masterTable.Columns(nOrd).DataType))
                        Else
                            Throw New Exception("No such column " + styledTable.Columns(nIndex).Name.ToString)
                        End If
                    End If
                    'end by lch

                    System.Threading.Interlocked.Increment(nIndex)
                End While
                nIndex = start
                While nIndex < start + length
                    Dim newRow(oCurrentData.Columns.Count - 1) As Object
                    Dim nSecIndex As Integer = 0
                    While nSecIndex < oCurrentData.Columns.Count
                        'modify by lch 2012-5-22 支持打印配置文件自定义空白列
                        If styledTable.Columns(nSecIndex).bStatic Then
                            newRow(nSecIndex) = styledTable.Columns(nSecIndex).StaticValue
                        Else
                            Dim nOrd As Integer = masterTable.Columns.IndexOf(oCurrentData.Columns(nSecIndex).ColumnName)
                            newRow(nSecIndex) = masterTable.Rows(nIndex).ItemArray(nOrd)
                        End If
                        'end by lch
                        System.Threading.Interlocked.Increment(nSecIndex)
                    End While
                    oCurrentData.Rows.Add(newRow)
                    System.Threading.Interlocked.Increment(nIndex)
                End While
            Else
                Dim nIndex As Integer = 0
                While nIndex < masterTable.Columns.Count
                    oCurrentData.Columns.Add(New DataColumn(masterTable.Columns(nIndex).ColumnName, masterTable.Columns(nIndex).DataType))
                    System.Threading.Interlocked.Increment(nIndex)
                End While
                nIndex = start
                While nIndex < start + length
                    oCurrentData.Rows.Add(masterTable.Rows(nIndex).ItemArray)
                    System.Threading.Interlocked.Increment(nIndex)
                End While
            End If
            Return oCurrentData
        End Function

        Private Function SetGroupByOnDataTable(ByVal Table As DataTable, ByVal GroupByValue As String) As DataTable
            Dim tempSourceTable As DataTable = Table.Copy
            Dim tempTargetTable As DataTable = Table.Copy
            Dim FilteredRows As DataRow()
            Dim GroupBysDone As Hashtable = New Hashtable
            tempTargetTable.Rows.Clear()
            For Each CurrentTableRow As DataRow In tempSourceTable.Rows
                If Not GroupBysDone.Contains(CurrentTableRow(GroupByValue).ToString) Then
                    FilteredRows = tempSourceTable.Select(GroupByValue + "='" + CurrentTableRow(GroupByValue).ToString + "'")
                    FilteredRows = CType(FilteredRows.Clone, DataRow())
                    For Each CurrentFilteredRow As DataRow In FilteredRows
                        tempTargetTable.ImportRow(CurrentFilteredRow)
                    Next
                    GroupBysDone.Add(CurrentTableRow(GroupByValue).ToString, "")
                End If
            Next
            Return tempTargetTable
        End Function

#Region "event handler"
        Public Sub RepeatAlignments(ByVal sender As Object)
            Dim nIndex As Integer = 0
            While nIndex < Me.m_StaticObjects.Length
                m_StaticObjects(nIndex).HorizontalAlignment = m_StaticObjects(nIndex).HorizontalAlignment
                m_StaticObjects(nIndex).VerticalAlignment = m_StaticObjects(nIndex).VerticalAlignment
                System.Threading.Interlocked.Increment(nIndex)
            End While
            nIndex = 0
            While nIndex < Me.m_DynamicObjects.Length
                m_DynamicObjects(nIndex).HorizontalAlignment = m_DynamicObjects(nIndex).HorizontalAlignment
                m_DynamicObjects(nIndex).VerticalAlignment = m_DynamicObjects(nIndex).VerticalAlignment
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

        Private Sub PrintDocument_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
            If Me.m_bIsXmlOK = False Then
                e.Cancel = True
                Logger.WriteLine(LOG_PERINT_NOT_READY, EVENT_ENTRY_TYPE.ERRORR)
                Exit Sub
            End If
            AddHandler Me.PrintPage, AddressOf Me.PrintDocument_PrintPage
            PrepareStaticObjects()
            Dim en As IDictionaryEnumerator = m_HtTables.GetEnumerator
            While en.MoveNext
                m_HtRowsPrintedSoFar(en.Key) = 0
            End While
            m_HtSystemValues(CONST_TEXT_PAGE_NUMBER) = 0
            m_HtSystemValues(CONST_TEXT_TOTAL_PAGES) = 0
        End Sub

        Private Sub PrepareStaticObjects()
            Dim nIndex As Integer = 0
            While nIndex < m_StaticObjects.Length
                If TypeOf m_StaticObjects(nIndex) Is TextField Then
                    Dim txtField As TextField = CType(m_StaticObjects(nIndex), TextField)
                    Dim strOutKey As String = ""
                    txtField.Text = ResolveParameterValues(txtField.Text, strOutKey)
                    txtField.MarkKey = strOutKey
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub
        Private Sub UpdateParameterValues(ByVal htParams As Hashtable)
            If htParams Is Nothing Then Return
            Dim em As IDictionaryEnumerator = htParams.GetEnumerator
            While em.MoveNext
                If m_HTParameterValues.Contains(em.Key.ToString) Then
                    m_HTParameterValues.Item(em.Key) = em.Value
                Else
                    m_HTParameterValues.Add(em.Key, em.Value)
                End If
            End While
        End Sub
        Private Sub UpdateStaticObjects()
            Dim nIndex As Integer = 0
            While nIndex < m_StaticObjects.Length
                If TypeOf m_StaticObjects(nIndex) Is TextField Then
                    Dim txtField As TextField = CType(m_StaticObjects(nIndex), TextField)
                    Dim strMarkKey As String = txtField.MarkKey
                    If String.IsNullOrEmpty(strMarkKey) = False AndAlso m_HTParameterValues.Contains(strMarkKey) Then
                        Dim strOutKey As String = ""
                        txtField.Text = ResolveParameterValues(txtField.InitText, strOutKey)
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

        Private Sub PrintDocument_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
            RemoveHandler Me.PrintPage, AddressOf Me.PrintDocument_PrintPage
        End Sub

        Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
            m_HtSystemValues(CONST_TEXT_PAGE_NUMBER) = CType(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER), Integer) + 1
            Dim g As Graphics = e.Graphics

            If m_bContinuousXmlOK Then
                If CType(m_HtSystemValues(CONST_TEXT_TOTAL_PAGES), Integer) = 0 Then
                    m_HtSystemValues(CONST_TEXT_TOTAL_PAGES) = CalculateContinuousNumberOfPagesEx(g) 'before calculate the pages, must called PrepareStaticObjects to set the static object mark.
                End If
                Dim bMorePage As Boolean = False
                PrintContinuousProcess(g, bMorePage)
                e.HasMorePages = bMorePage
            Else
                If CType(m_HtSystemValues(CONST_TEXT_TOTAL_PAGES), Integer) = 0 Then
                    m_HtSystemValues(CONST_TEXT_TOTAL_PAGES) = CalculateNumberOfPagesEx(g) 'before calculate the pages, must called PrepareStaticObjects to set the static object mark.
                End If
                Dim bMorePage As Boolean = False
                PrintProcess(g, bMorePage)
                e.HasMorePages = bMorePage
            End If
        End Sub
        Private Sub PrintContinuousProcess(ByVal g As Graphics, ByRef bMorePage As Boolean)
            PrintContinuousHead(g)
            Do
                bMorePage = PrintContinuousBody(g)
                If bMorePage Then
                    Exit Do
                End If

                If PrintContentUpdate() = False Then 'no more to print
                    Exit Do
                End If
                If DispatchSubHead(g) Then 'need more pages
                    bMorePage = True
                    Exit Do
                End If
            Loop
            PrintFooter(g)
        End Sub
        Private Sub PrintProcess(ByVal g As Graphics, ByRef bMorePage As Boolean)
            PrintHead(g)
            Do
                bMorePage = PrintBody(g)
                If bMorePage Then
                    Exit Do
                End If

                If PrintContentUpdate() = False Then 'no more to print
                    Exit Do
                End If
                If DispatchSubHead(g) Then 'need more pages
                    bMorePage = True
                    Exit Do
                End If
            Loop
        End Sub

        Private Sub PrintHead(ByVal g As Graphics)
            Dim nIndex As Integer = 0
            While nIndex < m_StaticObjects.Length
                If Not (m_StaticObjects(nIndex) Is Nothing) Then
                    If CInt(Me.m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) = 1 OrElse _
                        Not (TypeOf (m_StaticObjects(nIndex)) Is TextField) OrElse _
                        CType(m_StaticObjects(nIndex), TextField).Repeat Then
                        If TypeOf (m_StaticObjects(nIndex)) Is TextField Then CType(m_StaticObjects(nIndex), TextField).YOffset = 0
                        m_StaticObjects(nIndex).Paint(g)
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub
        Private Sub PrintContinuousHead(ByVal g As Graphics)
            Dim nIndex As Integer = 0
            Dim nLastPos As Integer = 0
            Dim smallestY As Integer = 9999
            If m_HTParaCollection IsNot Nothing AndAlso m_HTParaCollection.Count > 0 Then
                Dim strKey As String = GetHashTableKey()
                Dim htParams As Hashtable = CType(Me.m_HTParaCollection.Item(strKey), Hashtable)
                Dim iem As IDictionaryEnumerator = htParams.GetEnumerator
                While iem.MoveNext
                    Dim oTextFiled As TextField = GetStaticTextField(iem.Key.ToString)
                    If Not oTextFiled Is Nothing AndAlso oTextFiled.Repeat Then
                        If oTextFiled.Y <= smallestY Then
                            smallestY = oTextFiled.Y
                        End If
                    End If
                End While
            Else
                smallestY = 0
            End If

            While nIndex < m_StaticObjects.Length
                If Not (m_StaticObjects(nIndex) Is Nothing) Then
                    If CInt(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) = 1 Then
                        If TypeOf (m_StaticObjects(nIndex)) Is TextField Then CType(m_StaticObjects(nIndex), TextField).YOffset = 0
                        m_StaticObjects(nIndex).Paint(g)
                    Else
                        If CInt(m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) > 1 AndAlso CType(m_StaticObjects(nIndex), TextField).Repeat AndAlso m_bNeedContinuousFirstTitle Then
                            If TypeOf (m_StaticObjects(nIndex)) Is TextField Then CType(m_StaticObjects(nIndex), TextField).YOffset = CONST_INTEGER_DEFAULT_SPACE - smallestY
                            m_StaticObjects(nIndex).Paint(g)
                            If m_StaticObjects(nIndex).Y + (CONST_INTEGER_DEFAULT_SPACE - smallestY) + m_StaticObjects(nIndex).Height > nLastPos Then
                                nLastPos = m_StaticObjects(nIndex).Y + (CONST_INTEGER_DEFAULT_SPACE - smallestY) + m_StaticObjects(nIndex).Height
                            End If
                        End If
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            m_nLastPos = nLastPos
            If m_bNeedContinuousFirstTitle Then
                m_nContinuousYStartPos = nLastPos
            Else
                m_nContinuousYStartPos = CONST_INTEGER_DEFAULT_SPACE
            End If
        End Sub
        Private Sub PrintFooter(ByVal g As Graphics)
            Dim nIndex As Integer = 0
            While nIndex < m_FooterObjects.Length
                If Not (m_FooterObjects(nIndex) Is Nothing) Then
                    Dim strOutKey As String = ""
                    CType(m_FooterObjects(nIndex), TextField).Text = ResolveParameterValues(CType(m_FooterObjects(nIndex), TextField).InitText, strOutKey)
                   
                        If TypeOf (m_FooterObjects(nIndex)) Is TextField Then
                            CType(m_FooterObjects(nIndex), TextField).YOffset = m_nMaxHeight - CType(m_FooterObjects(nIndex), TextField).Y + CType(m_FooterObjects(nIndex), TextField).Height
                            m_FooterObjects(nIndex).Paint(g)
                        End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub
        Private Function PrintContinuousBody(ByVal g As Graphics) As Boolean
            Dim bMorePages As Boolean = UpdateContinuousDynamicContent(g)
            Dim nIndex As Integer = 0
            While nIndex < m_DynamicObjects.Length
                If Not (m_DynamicObjects(nIndex) Is Nothing) Then
                    m_DynamicObjects(nIndex).Paint(g)
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return bMorePages
        End Function
        Private Function PrintBody(ByVal g As Graphics) As Boolean
            Dim bMorePages As Boolean = UpdateDynamicContent(g)
            Dim nIndex As Integer = 0
            While nIndex < m_DynamicObjects.Length
                If Not (m_DynamicObjects(nIndex) Is Nothing) Then
                    m_DynamicObjects(nIndex).Paint(g)
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return bMorePages
        End Function
        Private Function PrintContentUpdate() As Boolean
            'update m_StaticObjects and m_DynamicObjects
            If m_HtTables.Count = 1 Then
                Return False 'if only one table, need not call the function to update.
            End If
            Me.m_nPrintingIndex += 1
            Dim strKey As String = GetHashTableKey()
            If strKey Is Nothing Then Return False
            UpdateParameterValues(CType(m_HTParaCollection.Item(strKey), Hashtable))
            UpdateStaticObjects()
            'the DynamicObjects will be updated in UpdateDynamicContent
            Return True
        End Function
        Private Function DispatchSubHead(ByVal g As Graphics) As Boolean
            '1. Calculate the Sub Head
            Dim strKey As String = GetHashTableKey()
            If Not strKey Is Nothing Then
                Dim htParams As Hashtable = CType(Me.m_HTParaCollection.Item(strKey), Hashtable)
                Dim nTop As Integer = 9999
                Dim nBottom As Integer = 0
                If GetStatiticsParamsLegend(htParams, nTop, nBottom) Then
                    If m_nLastPos + CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING + (nBottom - nTop) > m_nMaxHeight Then
                        m_nLastPos = 0
                        Return True
                    End If
                End If

                '2. Print the sub head
                Dim iem As IDictionaryEnumerator = htParams.GetEnumerator
                Dim em As IDictionaryEnumerator = htParams.GetEnumerator
                Dim I As Integer = 0
                Dim smallestY As Integer = 9999
                While iem.MoveNext
                    Dim oTextFiled As TextField = GetStaticTextField(iem.Key.ToString)
                    If Not oTextFiled Is Nothing Then
                        If oTextFiled.Y <= smallestY Then
                            smallestY = oTextFiled.Y
                        End If
                    End If
                End While
                While em.MoveNext
                    Dim oTextField As TextField = GetStaticTextField(em.Key.ToString)
                    If Not oTextField Is Nothing Then
                        oTextField.YOffset = m_nLastPos + CInt(CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING) - smallestY
                        oTextField.Paint(g)
                    End If
                End While
                m_nLastPos += CONST_INTEGER_PIECE_HEAD_BEFORE_LEADING_COUNT * CONST_INTEGER_DEFAULT_LEADING + (nBottom - nTop)
            End If
            Return False
        End Function

        Private Function GetHashTableKey() As String
            Dim strKey As String = Nothing
            If m_nPrintingIndex >= 0 AndAlso m_nPrintingIndex < m_aryKeys.Count Then
                strKey = m_aryKeys.Item(m_nPrintingIndex).ToString
            End If
            Return strKey
        End Function

        Private Function GetStaticTextField(ByVal strKey As String) As TextField
            Dim nIndex As Integer = 0
            While nIndex < m_StaticObjects.Length
                If Not (m_StaticObjects(nIndex) Is Nothing) AndAlso TypeOf (m_StaticObjects(nIndex)) Is TextField Then
                    If String.Compare(strKey, CType(m_StaticObjects(nIndex), TextField).MarkKey, True) = 0 Then
                        Return CType(m_StaticObjects(nIndex), TextField)
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return Nothing
        End Function
#End Region
#End Region
    End Class

    Public MustInherit Class ICustomPaint : Implements ICloneable
        Protected document As PrintReportImp = Nothing

        Public Enum HorizontalAlignmentTypes As Short
            None = 0
            Left
            Center
            Right
        End Enum

        Public Enum VerticalAlignmentTypes As Short
            None = 0
            Top
            Middle
            Bottom
        End Enum
        Protected m_horizontalAlignment As HorizontalAlignmentTypes = HorizontalAlignmentTypes.None
        Protected m_verticalAlignment As VerticalAlignmentTypes = VerticalAlignmentTypes.None
        Protected m_nYOffset As Integer = 0

        Public MustOverride Sub Paint(ByVal g As Graphics)

        Public MustOverride Function GetRegion() As Rectangle

        Public MustOverride Property HorizontalAlignment() As ICustomPaint.HorizontalAlignmentTypes

        Public MustOverride Property VerticalAlignment() As ICustomPaint.VerticalAlignmentTypes

        Public MustOverride Property Selectable() As Boolean

        Public MustOverride Property X() As Integer

        Public MustOverride Property Y() As Integer

        Public MustOverride Property Width() As Integer

        Public MustOverride Property Height() As Integer

        Public MustOverride WriteOnly Property YOffset() As Integer

        Public MustOverride Function CloneImp() As Object

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return CloneImp()
        End Function
    End Class

    Public Class Paper
        Public Enum Type As Short
            A4 = 1
            A5
            HalfA4
            QuarterA4
        End Enum

        Public Shared Function GetPaperSize(ByVal PaperType As Paper.Type) As Integer()
            Dim types As Hashtable = New Hashtable
            types.Add(Type.A4, New Integer() {827, 1169}) '8.27英寸*11.69英寸，即210mm*297mm
            types.Add(Type.A5, New Integer() {583, 827})  '5.83英寸*8.27英寸，即148mm*210mm
            types.Add(Type.HalfA4, New Integer() {827, 585}) 'A4纸宽度不变，长度折半
            types.Add(Type.QuarterA4, New Integer() {585, 415}) 'A4纸的四分之一
            If types.Contains(PaperType) Then
                Return CType(types(PaperType), Integer())
            Else
                Return CType(types(Type.A4), Integer())
            End If
        End Function

        Public Shared Function GetPaperType(ByVal PaperType As String) As Type
            Select Case PaperType
                Case "A4"
                    Return Type.A4
                Case "A5"
                    Return Type.A5
                Case "HalfA4"
                    Return Type.HalfA4
                Case "QuarterA4"
                    Return Type.QuarterA4
                Case Else
                    Return Type.A4
            End Select
        End Function
    End Class

    Public Class TextField : Inherits ICustomPaint


#Region "常量定义"
        Public Enum TextAlignmentType As Short
            Left = 1
            Center
            Right
            Justified
            None
        End Enum

        Public Enum TextVerticalAlignmentType As Short
            Top = 1
            Middle
            Bottom
            None
        End Enum

#End Region

#Region "变量定义"
        Private m_szTheText As String = "Sample text"
        Private m_oTheFont As Font = New Font("Tahoma", 10)
        Private m_oForegroundColor As Color = Color.Black
        Private m_oBackgroundColor As Color = Color.Transparent
        Private m_oBorderColor As Color = Color.Black
        Private m_nBorderWidth As Integer = 0
        Private m_nInnerPadding As Integer = 2
        Private m_nLineSpacing As Integer = 3
        Private m_bMSelectable As Boolean = True
        Private m_textAlignment As TextAlignmentType = TextAlignmentType.Left
        Private m_textVerticalAlignment As TextVerticalAlignmentType = TextVerticalAlignmentType.Top
        Private m_theRegion As Rectangle = New Rectangle(0, 0, 0, 0)
        Private m_theLines As ArrayList
        Private m_bRepeat As Boolean = True '是否需要在第2页起重复打印,缺省时需要
        Private m_strMarkKey As String '有些Text是根据配置文件的标志位来获取的，记录标志字符串
        Private m_strInitText As String '直接从配置文件读出来的值
        Private m_bBarCode As Boolean = False '条形码标识
#End Region

#Region "属性"
        Public Property BarCode() As Boolean
            Get
                Return m_bBarCode
            End Get
            Set(ByVal value As Boolean)
                m_bBarCode = value
            End Set
        End Property
        Public Property BackgroundColor() As Color
            Get
                Return m_oBackgroundColor
            End Get
            Set(ByVal Value As Color)
                m_oBackgroundColor = Value
            End Set
        End Property

        Public Property BorderColor() As Color
            Get
                Return m_oBorderColor
            End Get
            Set(ByVal Value As Color)
                m_oBorderColor = Value
            End Set
        End Property

        Public Property BorderWidth() As Integer
            Get
                Return m_nBorderWidth
            End Get
            Set(ByVal Value As Integer)
                m_nBorderWidth = Value
            End Set
        End Property
        Public Property Font() As Font
            Get
                Return m_oTheFont
            End Get
            Set(ByVal Value As Font)
                m_oTheFont = Value
            End Set
        End Property
        Public Property ForegroundColor() As Color
            Get
                Return m_oBackgroundColor
            End Get
            Set(ByVal Value As Color)
                m_oBackgroundColor = Value
            End Set
        End Property
        Public Property Text() As String
            Get
                Return m_szTheText
            End Get
            Set(ByVal Value As String)
                m_szTheText = Value
            End Set
        End Property
        Public Property TextAlignment() As TextAlignmentType
            Get
                Return m_textAlignment
            End Get
            Set(ByVal Value As TextAlignmentType)
                m_textAlignment = Value
            End Set
        End Property
        Public Property TextVerticalAlignment() As TextVerticalAlignmentType
            Get
                Return m_textVerticalAlignment
            End Get
            Set(ByVal Value As TextVerticalAlignmentType)
                m_textVerticalAlignment = Value
            End Set
        End Property
        Public Property MarkKey() As String
            Get
                Return m_strMarkKey
            End Get
            Set(ByVal value As String)
                m_strMarkKey = value
            End Set
        End Property
        Public Property InitText() As String
            Get
                Return m_strInitText
            End Get
            Set(ByVal value As String)
                m_strInitText = value
            End Set
        End Property
        Public Overloads Overrides Property HorizontalAlignment() As ICustomPaint.HorizontalAlignmentTypes
            Get
                Return Me.m_horizontalAlignment
            End Get
            Set(ByVal Value As ICustomPaint.HorizontalAlignmentTypes)
                Me.m_horizontalAlignment = Value
                Select Case Me.m_horizontalAlignment
                    Case ICustomPaint.HorizontalAlignmentTypes.Center
                        m_theRegion.X = CInt((document.DefaultPageSettings.Bounds.Width - document.Margins.Right + document.Margins.Left) / 2 - Width / 2)
                    Case ICustomPaint.HorizontalAlignmentTypes.Right
                        m_theRegion.X = document.DefaultPageSettings.Bounds.Right - document.Margins.Right - Width
                    Case ICustomPaint.HorizontalAlignmentTypes.Left
                        m_theRegion.X = document.Margins.Left
                End Select
            End Set
        End Property
        Public Overloads Overrides Property Height() As Integer
            Get
                Return m_theRegion.Height
            End Get
            Set(ByVal Value As Integer)
                If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.None OrElse Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Top Then
                    m_theRegion.Height = Value
                Else
                    If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Bottom Then
                        m_theRegion.Y = m_theRegion.Y - Value + m_theRegion.Height
                        m_theRegion.Height = Value
                    Else
                        If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Middle Then
                            m_theRegion.Y = CInt(m_theRegion.Y - Value / 2 + m_theRegion.Height / 2)
                            m_theRegion.Height = Value
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property VerticalAlignment() As ICustomPaint.VerticalAlignmentTypes
            Get
                Return Me.m_verticalAlignment
            End Get
            Set(ByVal Value As ICustomPaint.VerticalAlignmentTypes)
                Me.m_verticalAlignment = Value
                Select Case Me.VerticalAlignment
                    Case ICustomPaint.VerticalAlignmentTypes.Middle
                        m_theRegion.Y = CInt((document.DefaultPageSettings.Bounds.Height - document.Margins.Bottom + document.Margins.Top) / 2 - Height / 2)
                    Case ICustomPaint.VerticalAlignmentTypes.Bottom
                        m_theRegion.Y = document.DefaultPageSettings.Bounds.Bottom - document.Margins.Bottom - Height
                    Case ICustomPaint.VerticalAlignmentTypes.Top
                        m_theRegion.Y = document.Margins.Top
                End Select
            End Set
        End Property
        Public Overloads Overrides Property Width() As Integer
            Get
                Return m_theRegion.Width
            End Get
            Set(ByVal Value As Integer)
                If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.None OrElse Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Left Then
                    m_theRegion.Width = Value
                Else
                    If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Right Then
                        m_theRegion.X = m_theRegion.X - Value + m_theRegion.Width
                        m_theRegion.Width = Value
                    Else
                        If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Center Then
                            m_theRegion.X = m_theRegion.X + CInt(m_theRegion.Width / 2 - Value / 2)
                            m_theRegion.Width = Value
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property X() As Integer
            Get
                Return m_theRegion.X
            End Get
            Set(ByVal Value As Integer)
                If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.None Then
                    m_theRegion.X = Value
                Else
                    If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Right Then
                        m_theRegion.Width = m_theRegion.Width + m_theRegion.X - Value
                        m_theRegion.X = Value
                    Else
                        If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Center Then
                            m_theRegion.Width = m_theRegion.Width + 2 * (m_theRegion.X - Value)
                            m_theRegion.X = Value
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property Y() As Integer
            Get
                Return m_theRegion.Y
            End Get
            Set(ByVal Value As Integer)
                If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.None Then
                    m_theRegion.Y = Value
                Else
                    If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Bottom Then
                        m_theRegion.Height = m_theRegion.Height + m_theRegion.Y - Value
                        m_theRegion.Y = Value
                    Else
                        If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Middle Then
                            m_theRegion.Height = m_theRegion.Height + 2 * (m_theRegion.Y - Value)
                            m_theRegion.Y = Value
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property Selectable() As Boolean
            Get
                Return Me.m_bMSelectable
            End Get
            Set(ByVal Value As Boolean)
                Me.m_bMSelectable = Value
            End Set
        End Property
        Public Property Repeat() As Boolean
            Get
                Return m_bRepeat
            End Get
            Set(ByVal Value As Boolean)
                m_bRepeat = Value
            End Set
        End Property
        Public Overrides WriteOnly Property YOffset() As Integer
            Set(ByVal value As Integer)
                m_nYOffset = value
            End Set
        End Property

#End Region

#Region "成员方法"

        Private Sub DrawJustified(ByVal g As Graphics, ByVal text As String, ByVal yPos As Integer, ByVal isLast As Boolean, ByVal isIndented As Boolean)
            Dim szTxt As String = text.Replace("" & Microsoft.VisualBasic.Chr(9) & "", " ")
            Dim IndentSize As Single = g.MeasureString("mmm", m_oTheFont).Width
            Dim xPos As Single = m_theRegion.X + Me.m_nInnerPadding + CInt(IIf(isIndented, IndentSize, 0))
            Dim szAryTheWords As String() = szTxt.Split(New Char() {" "c})
            Dim IWordsWidths(szAryTheWords.Length) As Single
            Dim ITotalWordsWidth As Single = 0
            Dim nIndex As Integer = 0
            While nIndex < szAryTheWords.Length
                Dim sf As SizeF = g.MeasureString(szAryTheWords(nIndex), m_oTheFont)
                IWordsWidths(nIndex) = sf.Width
                ITotalWordsWidth += sf.Width
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Dim IOffset As Single = 0
            If szAryTheWords.Length > 1 Then
                IOffset = (m_theRegion.Width - 2 * m_nInnerPadding - ITotalWordsWidth - _
                    CInt(IIf(isIndented, IndentSize, 0))) / (szAryTheWords.Length - 1)
            End If
            If isLast Then
                g.DrawString(szTxt, m_oTheFont, New SolidBrush(ForegroundColor), xPos, yPos)
            Else
                nIndex = 0
                While nIndex < szAryTheWords.Length
                    If nIndex = 0 Then
                        xPos = m_theRegion.X + m_nInnerPadding + CInt(IIf(isIndented, IndentSize, 0))
                    Else
                        If nIndex = szAryTheWords.Length - 1 Then
                            xPos = m_theRegion.Right - m_nInnerPadding - g.MeasureString(szAryTheWords(nIndex), m_oTheFont).Width
                        End If
                    End If
                    g.DrawString(szAryTheWords(nIndex), m_oTheFont, New SolidBrush(ForegroundColor), xPos, yPos)
                    xPos += IWordsWidths(nIndex) + IOffset
                    System.Threading.Interlocked.Increment(nIndex)
                End While
            End If
        End Sub

        Private Sub DrawSimpleString(ByVal g As Graphics, ByVal txt As String, ByVal yPos As Integer, ByVal isLast As Boolean)
            Dim xPos As Integer = 0
            Dim sf As SizeF = g.MeasureString(txt, m_oTheFont)
            Select Case Me.m_textAlignment
                Case TextAlignmentType.Center
                    xPos = m_theRegion.X + CInt(m_theRegion.Width / 2 - CType(sf.Width, Integer) / 2)
                    g.DrawString(txt, m_oTheFont, New SolidBrush(m_oForegroundColor), xPos, yPos)
                Case TextAlignmentType.Right
                    xPos = m_theRegion.Right - m_nInnerPadding - CType(sf.Width, Integer)
                    g.DrawString(txt, m_oTheFont, New SolidBrush(m_oForegroundColor), xPos, yPos)
                Case TextAlignmentType.Justified
                    If txt.StartsWith("" & Microsoft.VisualBasic.Chr(9) & "") Then
                        DrawJustified(g, txt.Trim, yPos, isLast, True)
                    Else
                        DrawJustified(g, txt.TrimEnd(New Char() {" "c}), yPos, isLast, False)
                    End If
                Case Else
                    xPos = m_theRegion.X + m_nInnerPadding
                    g.DrawString(txt, m_oTheFont, New SolidBrush(m_oForegroundColor), xPos, yPos)
            End Select
        End Sub

        Private Sub DrawText(ByVal g As Graphics)
            If m_szTheText.Length = 0 Then
                Return
            End If
            Me.m_theLines.Clear()
            Dim szLine As String = ""
            Dim nLastBlank As Integer = -1
            Dim nCurrent As Integer = -1
            Dim yPosition As Integer = m_theRegion.Top + m_nInnerPadding
            Dim sf As SizeF = g.MeasureString(szLine, m_oTheFont)
            While yPosition + sf.Height <= (m_theRegion.Bottom - m_nInnerPadding) AndAlso m_szTheText.Length > System.Threading.Interlocked.Increment(nCurrent)
                Dim nextChar As String = m_szTheText.Substring(nCurrent, 1)
                szLine += nextChar
                sf = g.MeasureString(szLine, m_oTheFont)
                If sf.Width > m_theRegion.Width - 2 * m_nInnerPadding Then
                    If nLastBlank = -1 Then
                        szLine = szLine.Substring(0, szLine.Length - 1)
                        System.Threading.Interlocked.Decrement(nCurrent)
                    Else
                        szLine = szLine.Substring(0, szLine.Length - (nCurrent - nLastBlank))
                        nCurrent = nLastBlank
                    End If
                    m_theLines.Add(szLine)
                    yPosition += CType(sf.Height, Integer) + m_nLineSpacing
                    szLine = ""
                    nLastBlank = -1
                Else
                    If nCurrent = m_szTheText.Length - 1 Then
                        m_theLines.Add(szLine)
                    End If
                End If
            End While
            StartPainting(g)
        End Sub

        Private Sub StartPainting(ByVal g As Graphics)
            Dim nLineHeight As Integer = CType(g.MeasureString("This is dummy text", m_oTheFont).Height, Integer)
            Dim yPos As Integer = 0
            Select Case TextVerticalAlignment
                Case TextVerticalAlignmentType.Bottom
                    yPos = m_theRegion.Bottom - m_nInnerPadding - m_theLines.Count * nLineHeight - (m_theLines.Count - 1) * m_nLineSpacing
                Case TextVerticalAlignmentType.Middle
                    yPos = m_theRegion.Top + CInt(m_theRegion.Height / 2 - (m_theLines.Count * nLineHeight + (m_theLines.Count - 1) * m_nLineSpacing) / 2)
                Case Else
                    yPos = m_theRegion.Top + m_nInnerPadding
            End Select
            yPos += m_nYOffset
            If m_bBarCode Then
                Dim strNoteID As String = m_szTheText
                'BarCodeParse.ParseNote(strNoteID)
                BarCodeParse.DrawBarCode(m_szTheText, strNoteID + TEXT_LABEL_NOUSE_STRING, g, m_theRegion.X + m_nInnerPadding, yPos, m_theRegion.Height + yPos)
            Else
                Dim nIndex As Integer = 0
                While nIndex < m_theLines.Count
                    DrawSimpleString(g, m_theLines(nIndex).ToString, yPos, nIndex = m_theLines.Count - 1)
                    yPos = yPos + nLineHeight + m_nLineSpacing
                    System.Threading.Interlocked.Increment(nIndex)
                End While
            End If
        End Sub

        Public Sub New()
            m_theLines = New ArrayList
        End Sub

        Public Sub New(ByVal originX As Integer, ByVal originY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal parent As PrintReportImp, ByVal bBarCode As Boolean)
            document = parent
            m_szTheText = ""
            m_theRegion = New Rectangle(originX, originY, width, height)
            m_theLines = New ArrayList
            m_bBarCode = bBarCode
        End Sub

        Public Overloads Overrides Function CloneIMP() As Object
            Dim tmp As TextField = New TextField
            tmp.document = Me.document
            tmp.Text = Me.Text
            tmp.X = Me.X
            tmp.Y = Me.Y
            tmp.Width = Me.Width
            tmp.Height = Me.Height
            tmp.BorderWidth = Me.BorderWidth
            tmp.BorderColor = Me.BorderColor
            tmp.BackgroundColor = Me.BackgroundColor
            tmp.Font = Me.Font
            tmp.TextAlignment = Me.TextAlignment
            tmp.TextVerticalAlignment = Me.TextVerticalAlignment
            tmp.ForegroundColor = Me.ForegroundColor
            Return tmp
        End Function

        Public Overloads Overrides Function GetRegion() As Rectangle
            Return m_theRegion
        End Function

        Public Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics)
            If Color.op_Equality(m_oBackgroundColor, Color.Transparent) = True Then
                g.FillRectangle(New SolidBrush(m_oBackgroundColor), m_theRegion)
            End If
            If Me.BorderWidth > 0 Then
                g.DrawRectangle(New Pen(Me.BorderColor, BorderWidth), m_theRegion)
            End If
            DrawText(g)
        End Sub

#End Region
    End Class

    Public Class StyledTable : Inherits ICustomPaint
#Region "定义变量"
        Private m_nCellHeight As Integer = 18
        Private m_TheData As DataTable
        Private m_DataSource As String
        Private m_mSelectable As Boolean = True
        Private m_mBorderColor As Color = Color.Black
        Private m_mGroupByField As String = ""
        Private m_Columns As StyledTableColumn() = New StyledTableColumn(0) {}
        Private m_TheRegion As Rectangle = New Rectangle(0, 0, 0, 0)
        Private m_TheRegion2 As Rectangle = New Rectangle(0, 0, 0, 0) '第2页起的打印区域
        Private m_dataFont As Font = New Font("Tahoma", 8, FontStyle.Regular)
        Private m_mDataFontColor As Color = Color.Black
        Private m_bDoDrawEmptyRows As Boolean = False
        Private m_bDoDrawHeader As Boolean = True
        Private m_HeaderFont As Font = New Font("Tahoma", 8, FontStyle.Bold)
        Private m_mHeaderFontColor As Color = Color.Black
        Private m_mHeaderBackgroundColor As Color = Color.White
        Private m_nPageMaxHeight As Integer = 0
#End Region

#Region "属性"
        Public Property BorderColor() As Color
            Get
                Return Me.m_mBorderColor
            End Get
            Set(ByVal Value As Color)
                Me.m_mBorderColor = Value
            End Set
        End Property

        Public Property CellHeight() As Integer
            Get
                Return m_nCellHeight
            End Get
            Set(ByVal Value As Integer)
                m_nCellHeight = Value
            End Set
        End Property

        Public Property Columns() As StyledTableColumn()
            Get
                Return m_Columns
            End Get
            Set(ByVal Value As StyledTableColumn())
                m_Columns = Value
                If m_Columns.Length > 0 Then
                    Dim sumOfWidths As Integer = 0
                    Dim i As Integer = 0
                    While i < m_Columns.Length
                        sumOfWidths += m_Columns(i).Width
                        System.Threading.Interlocked.Increment(i)
                    End While
                    m_TheRegion.Width = sumOfWidths
                    m_TheRegion2.Width = sumOfWidths
                End If
            End Set
        End Property

        Public Property Data() As DataTable
            Get
                Return m_TheData
            End Get
            Set(ByVal Value As DataTable)
                m_TheData = Value
            End Set
        End Property
        Public Property DataFont() As Font
            Get
                Return m_dataFont
            End Get
            Set(ByVal Value As Font)
                m_dataFont = Value
            End Set
        End Property
        Public Property DataFontColor() As Color
            Get
                Return Me.m_mDataFontColor
            End Get
            Set(ByVal Value As Color)
                Me.m_mDataFontColor = Value
            End Set
        End Property
        Public Property DataSource() As String
            Get
                Return m_DataSource
            End Get
            Set(ByVal Value As String)
                m_DataSource = Value
            End Set
        End Property
        Public Property DrawEmptyRows() As Boolean
            Get
                Return m_bDoDrawEmptyRows
            End Get
            Set(ByVal Value As Boolean)
                m_bDoDrawEmptyRows = Value
            End Set
        End Property
        Public Property DrawHeader() As Boolean
            Get
                Return m_bDoDrawHeader
            End Get
            Set(ByVal Value As Boolean)
                m_bDoDrawHeader = Value
            End Set
        End Property

        Public Property PageMaxHeight() As Integer
            Get
                Return m_nPageMaxHeight
            End Get
            Set(ByVal value As Integer)
                m_nPageMaxHeight = value
            End Set
        End Property
        Public Function GetPossibleRowNumber() As Integer '首页可打印行数
            Dim nRegionHeight As Integer = Math.Min(m_TheRegion.Height, m_nPageMaxHeight - (Me.Y + m_nYOffset))
            Return CInt(nRegionHeight / CellHeight)
        End Function
        Public Function GetPossibleRowNumber2() As Integer '后续页可打印行数
            Dim nRegionHeight As Integer = Math.Min(m_TheRegion2.Height, m_nPageMaxHeight - (Me.Y + m_nYOffset))
            Return CInt(nRegionHeight / CellHeight)
        End Function
        Public Function GetPossibleRowNumber3(ByVal nMeY As Integer, ByVal bMax As Boolean) As Integer '后续页可不包含标题打印行数
            Dim nRegionHeight As Integer
            If bMax Then
                nRegionHeight = Math.Max(m_nPageMaxHeight - (Me.Y + m_nYOffset), m_nPageMaxHeight - (nMeY + CInt(IIf(m_nYOffset > 0, m_nYOffset, 0))))
            Else
                nRegionHeight = Math.Min(m_nPageMaxHeight - (Me.Y + m_nYOffset), m_nPageMaxHeight - (nMeY + m_nYOffset))
            End If
            Return CInt(nRegionHeight / CellHeight)
        End Function
        Public Property GroupByField() As String
            Get
                Return Me.m_mGroupByField
            End Get
            Set(ByVal Value As String)
                Me.m_mGroupByField = Value
            End Set
        End Property
        Public Property HeaderBackgroundColor() As Color
            Get
                Return m_mHeaderBackgroundColor
            End Get
            Set(ByVal Value As Color)
                m_mHeaderBackgroundColor = Value
            End Set
        End Property
        Public Property HeaderFont() As Font
            Get
                Return m_HeaderFont
            End Get
            Set(ByVal Value As Font)
                m_HeaderFont = Value
            End Set
        End Property
        Public Property HeaderFontColor() As Color
            Get
                Return Me.m_mHeaderFontColor
            End Get
            Set(ByVal Value As Color)
                Me.m_mHeaderFontColor = Value
            End Set
        End Property
        Public Overloads Overrides Property Height() As Integer
            Get
                Return m_TheRegion.Height
            End Get
            Set(ByVal Value As Integer)
                If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.None OrElse Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Top Then
                    m_TheRegion.Height = Value
                Else
                    If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Bottom Then
                        m_TheRegion.Y = m_TheRegion.Y - Value + m_TheRegion.Height
                        m_TheRegion.Height = Value
                    Else
                        If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Middle Then
                            m_TheRegion.Y = CInt(m_TheRegion.Y - Value / 2 + m_TheRegion.Height / 2)
                            m_TheRegion.Height = Value
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property HorizontalAlignment() As ICustomPaint.HorizontalAlignmentTypes
            Get
                Return m_horizontalAlignment
            End Get
            Set(ByVal Value As ICustomPaint.HorizontalAlignmentTypes)
                m_horizontalAlignment = Value
                Select Case HorizontalAlignment
                    Case ICustomPaint.HorizontalAlignmentTypes.Center
                        m_TheRegion.X = CInt((document.DefaultPageSettings.Bounds.Width - document.Margins.Right + document.Margins.Left) / 2 - Width / 2)
                    Case ICustomPaint.HorizontalAlignmentTypes.Right
                        m_TheRegion.X = document.DefaultPageSettings.Bounds.Right - document.Margins.Right - Width
                    Case ICustomPaint.HorizontalAlignmentTypes.Left
                        m_TheRegion.X = document.Margins.Left
                End Select
            End Set
        End Property
        Public Overloads Overrides Property VerticalAlignment() As ICustomPaint.VerticalAlignmentTypes
            Get
                Return Me.m_verticalAlignment
            End Get
            Set(ByVal Value As ICustomPaint.VerticalAlignmentTypes)
                m_verticalAlignment = Value
                Select Case VerticalAlignment
                    Case ICustomPaint.VerticalAlignmentTypes.Middle
                        m_TheRegion.Y = CInt((document.DefaultPageSettings.Bounds.Height - document.Margins.Bottom + document.Margins.Top) / 2 - Height / 2)
                    Case ICustomPaint.VerticalAlignmentTypes.Bottom
                        m_TheRegion.Y = document.DefaultPageSettings.Bounds.Bottom - document.Margins.Bottom - Height
                    Case ICustomPaint.VerticalAlignmentTypes.Top
                        m_TheRegion.Y = document.Margins.Top
                End Select
            End Set
        End Property
        Public Overloads Overrides Property Width() As Integer
            Get
                Return m_TheRegion.Width
            End Get
            Set(ByVal Value As Integer)
                If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.None OrElse Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Left Then
                    m_TheRegion.Width = Value
                Else
                    If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Right Then
                        m_TheRegion.X = m_TheRegion.X - Value + m_TheRegion.Width
                        m_TheRegion.Width = Value
                    Else
                        If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Center Then
                            m_TheRegion.X = CInt(m_TheRegion.X - Value / 2 + m_TheRegion.Width / 2)
                            m_TheRegion.Width = Value
                        End If
                    End If
                End If
                If Columns.Length > 0 Then
                    Dim sumOfWidths As Integer = 0
                    Dim i As Integer = 0
                    While i < Columns.Length
                        sumOfWidths += Columns(i).Width
                        System.Threading.Interlocked.Increment(i)
                    End While
                    If sumOfWidths < m_TheRegion.Width Then
                        Columns(Columns.Length - 1).Width += m_TheRegion.Width - sumOfWidths
                    Else
                        If sumOfWidths - Columns(Columns.Length - 1).Width < m_TheRegion.Width Then
                            Columns(Columns.Length - 1).Width -= sumOfWidths - m_TheRegion.Width
                        Else
                            Dim ratio As Double = CType(m_TheRegion.Width, Double) / sumOfWidths
                            i = 0
                            While i < Columns.Length
                                Columns(i).Width = CType((ratio * Columns(i).Width), Integer)
                                System.Threading.Interlocked.Increment(i)
                            End While
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property X() As Integer
            Get
                Return m_TheRegion.X
            End Get
            Set(ByVal Value As Integer)
                If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.None Then
                    m_TheRegion.X = Value
                Else
                    If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Right Then
                        m_TheRegion.Width = m_TheRegion.Width + m_TheRegion.X - Value
                        m_TheRegion.X = Value
                    Else
                        If Me.HorizontalAlignment = ICustomPaint.HorizontalAlignmentTypes.Center Then
                            m_TheRegion.Width = m_TheRegion.Width + 2 * (m_TheRegion.X - Value)
                            m_TheRegion.X = Value
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property Y() As Integer
            Get
                Return m_TheRegion.Y
            End Get
            Set(ByVal Value As Integer)
                If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.None Then
                    m_TheRegion.Y = Value
                Else
                    If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Bottom Then
                        m_TheRegion.Height = m_TheRegion.Height + m_TheRegion.Y - Value
                        m_TheRegion.Y = Value
                    Else
                        If Me.VerticalAlignment = ICustomPaint.VerticalAlignmentTypes.Middle Then
                            m_TheRegion.Height = m_TheRegion.Height + 2 * (m_TheRegion.Y - Value)
                            m_TheRegion.Y = Value
                        End If
                    End If
                End If
            End Set
        End Property
        Public Overloads Overrides Property Selectable() As Boolean
            Get
                Return Me.m_mSelectable
            End Get
            Set(ByVal Value As Boolean)
                Me.m_mSelectable = Value
            End Set
        End Property

        Public Overrides WriteOnly Property YOffset() As Integer
            Set(ByVal value As Integer)
                m_nYOffset = value
            End Set
        End Property
#End Region

#Region "成员方法"

        '计算DataRow的相对高度
        Public Function CalculateRelativeDataRowHeight(ByVal CurrentRow As DataRow, ByVal g As Graphics) As Integer
            Dim nRelativeDataRowHeight As Integer = 0  '当前记录行实际占用的行数
            Dim nIndex As Integer = 0
            While nIndex < Columns.Length
                Dim CurrentColumn As StyledTableColumn = Columns(nIndex)
                If CurrentColumn.Visible Then
                    Dim nDrawnRowsCounter As Integer = 0  '当前单元格实际占用的行数
                    Select Case CurrentColumn.Type '判断列的类型（文本列/CheckBox列）
                        Case StyledTableColumn.ColumnType.Text '如果是文本列
                            'modify by lch 2012-5-22 支持打印配置文件自定义空白列
                            Dim oObject As Object
                            Dim szTmpValue As String
                            If CurrentColumn.bStatic Then
                                szTmpValue = String.Empty
                            Else
                                oObject = CurrentRow(CurrentColumn.Name)
                                szTmpValue = FormatValue(oObject, CurrentRow.Table.Columns(CurrentColumn.Name).DataType, CurrentColumn.FormatMask)
                            End If
                            'end by lch

                            Dim szTheLine As String = ""
                            Dim bMore As Boolean = False
                            Do
                                bMore = SplitString(szTmpValue, szTheLine, Columns(nIndex).Width, g, DataFont)
                                System.Threading.Interlocked.Increment(nDrawnRowsCounter)
                            Loop While bMore
                        Case StyledTableColumn.ColumnType.Check '如果是CheckBox列
                            nDrawnRowsCounter = 1 '占用一行
                    End Select
                    If nDrawnRowsCounter > nRelativeDataRowHeight Then
                        nRelativeDataRowHeight = nDrawnRowsCounter
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return nRelativeDataRowHeight
        End Function

        '计算DataHeader的相对高度
        Public Function CalculateRelativeHeaderHeight(ByVal g As Graphics) As Integer
            If Not m_bDoDrawHeader Then
                Return 0
            End If
            Dim nHeaderRelativeHeight As Integer = 0
            Dim nHeaderLabels(Columns.Length) As ArrayList
            Dim nIndex As Integer = 0
            While nIndex < Columns.Length
                If Columns(nIndex).Visible Then
                    Dim szTmpValue As String = Columns(nIndex).Label
                    Dim szTheLine As String = ""
                    nHeaderLabels(nIndex) = New ArrayList
                    Dim bWillTextWrap As Boolean = False
                    Do
                        bWillTextWrap = SplitString(szTmpValue, szTheLine, Columns(nIndex).Width, g, HeaderFont)
                        nHeaderLabels(nIndex).Add(szTheLine)
                    Loop While bWillTextWrap
                    If nHeaderLabels(nIndex).Count > nHeaderRelativeHeight Then
                        nHeaderRelativeHeight = nHeaderLabels(nIndex).Count
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return nHeaderRelativeHeight
        End Function

        '画DataHeader
        Private Function Draw_Header(ByVal g As Graphics, ByVal TargetRegion As Rectangle, ByVal DrawnSoFar As Integer) As Integer
            Dim nMaxLinesDrawn As Integer = 0
            Dim nLeftBorder As Integer = m_TheRegion.X
            Dim aryHeaderLabels(Columns.Length) As ArrayList
            Dim nIndex As Integer = 0
            While nIndex < Columns.Length
                If Columns(nIndex).Visible Then
                    Dim szTmpValue As String = Columns(nIndex).Label
                    Dim szTheLine As String = ""

                    If Columns(nIndex).bStatic Then
                        szTmpValue = Columns(nIndex).Name
                    End If

                    aryHeaderLabels(nIndex) = New ArrayList
                    Dim bWillTextWrap As Boolean = False
                    Do
                        bWillTextWrap = SplitString(szTmpValue, szTheLine, Columns(nIndex).Width, g, HeaderFont)
                        aryHeaderLabels(nIndex).Add(szTheLine)
                    Loop While bWillTextWrap
                    If aryHeaderLabels(nIndex).Count > nMaxLinesDrawn Then
                        nMaxLinesDrawn = aryHeaderLabels(nIndex).Count
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            g.FillRectangle(New SolidBrush(m_mHeaderBackgroundColor), TargetRegion.X, TargetRegion.Y, TargetRegion.Width, CellHeight * nMaxLinesDrawn)
            nIndex = 0
            While nIndex < Columns.Length
                If Columns(nIndex).Visible Then
                    Dim aryTheLines As ArrayList = aryHeaderLabels(nIndex)
                    Dim nSecIndex As Integer = 0
                    While nSecIndex < aryTheLines.Count
                        Dim sf As SizeF = g.MeasureString(aryTheLines(nSecIndex).ToString, HeaderFont)
                        Dim yPos As Single = nLeftBorder + 1
                        Select Case Columns(nIndex).Alignment
                            Case StyledTableColumn.AlignmentType.Left
                                yPos = nLeftBorder + 1
                            Case StyledTableColumn.AlignmentType.Center
                                yPos = nLeftBorder + CInt((Columns(nIndex).Width / 2) - (sf.Width / 2))
                            Case StyledTableColumn.AlignmentType.Right
                                yPos = nLeftBorder + Columns(nIndex).Width - sf.Width
                            Case Else
                                yPos = nLeftBorder + 1
                        End Select
                        g.DrawString(aryTheLines(nSecIndex).ToString, HeaderFont, New SolidBrush(Me.m_mHeaderFontColor), yPos, _
                                    CInt(TargetRegion.Top + CellHeight * nSecIndex + CellHeight / 2 - sf.Height / 2))
                        System.Threading.Interlocked.Increment(nSecIndex)
                    End While
                    nLeftBorder += Columns(nIndex).Width
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            g.DrawLine(New Pen(Me.m_mBorderColor, 1), TargetRegion.X, TargetRegion.Y, TargetRegion.X + TargetRegion.Width, TargetRegion.Y)
            Return DrawnSoFar + nMaxLinesDrawn
        End Function

        '画DataRow
        Private Function drawDataRow(ByVal g As Graphics, ByVal theRow As Integer, ByVal drawnSoFar As Integer) As Integer
            Dim nNumOfRows As Integer = CalculateRelativeDataRowHeight(m_TheData.Rows(theRow), g)

            If theRow > m_TheData.Rows.Count OrElse theRow < 0 Then
                Return drawnSoFar
            End If
            Dim nMaxDrawnRows As Integer = 0 '当前记录行实际占用的行数
            Dim rcTemp As Rectangle = m_TheRegion
            rcTemp.Y += m_nYOffset

            Dim nTopBorder As Integer = rcTemp.Top + drawnSoFar * CellHeight
            g.DrawLine(New Pen(Me.m_mBorderColor, 1), rcTemp.X, nTopBorder, rcTemp.Right, nTopBorder)
            Dim nLeftBorder As Integer = rcTemp.X
            Dim nIndex As Integer = 0
            While nIndex < m_TheData.Rows(theRow).ItemArray.Length
                If Columns(nIndex).Visible Then
                    Dim oObject As Object = m_TheData.Rows(theRow).ItemArray.GetValue(nIndex)
                    Dim nDrawnRowsCounter As Integer = 0 '当前单元格实际占用的行数

                    Select Case Columns(nIndex).Type '判断列的类型（文本列/CheckBox列）
                        Case StyledTableColumn.ColumnType.Text '如果是文本列
                            Dim szTmpValue As String = FormatValue(oObject, m_TheData.Columns(nIndex).DataType, Columns(nIndex).FormatMask)
                            Dim szTheLine As String = ""
                            Dim bMore As Boolean = False
                            Do
                                bMore = SplitString(szTmpValue, szTheLine, Columns(nIndex).Width, g, DataFont)
                                Dim sf As SizeF = g.MeasureString(szTheLine, DataFont)
                                Dim xPos As Single
                                Select Case Columns(nIndex).Alignment
                                    Case StyledTableColumn.AlignmentType.Left
                                        xPos = nLeftBorder + 1
                                    Case StyledTableColumn.AlignmentType.Center
                                        xPos = nLeftBorder + CInt((Columns(nIndex).Width / 2) - (sf.Width / 2))
                                    Case StyledTableColumn.AlignmentType.Right
                                        xPos = nLeftBorder + Columns(nIndex).Width - sf.Width
                                    Case Else
                                        xPos = nLeftBorder + 1
                                End Select
                                g.DrawString(szTheLine, DataFont, New SolidBrush(Me.m_mDataFontColor), xPos, _
                                                CInt(nTopBorder + CellHeight * nDrawnRowsCounter + CellHeight / 2 - sf.Height / 2))
                                System.Threading.Interlocked.Increment(nDrawnRowsCounter)
                            Loop While bMore
                        Case StyledTableColumn.ColumnType.Check '如果是CheckBox列
                            Dim chkSideLen As Integer = Math.Min(CellHeight, 14) '绘制CheckBox框的边长
                            chkSideLen = Math.Min(Columns(nIndex).Width - 5, chkSideLen)
                            Dim xPos As Single
                            Select Case Columns(nIndex).Alignment
                                Case StyledTableColumn.AlignmentType.Left
                                    xPos = nLeftBorder + 3
                                Case StyledTableColumn.AlignmentType.Center
                                    xPos = nLeftBorder + CInt((Columns(nIndex).Width - chkSideLen) / 2)
                                Case StyledTableColumn.AlignmentType.Right
                                    xPos = nLeftBorder + Columns(nIndex).Width - chkSideLen - 3
                                Case Else
                                    xPos = nLeftBorder + 3
                            End Select
                            '通过xml得到的TrueValue为String型，要根据相应列的数据类型转换
                            Try
                                Columns(nIndex).TrueValue = Convert.ChangeType(Columns(nIndex).TrueValue, System.Type.GetType(m_TheData.Columns(nIndex).DataType.FullName))
                            Catch ex As Exception
                            End Try
                            '画正方形  
                            g.DrawRectangle(Pens.Black, xPos, CInt(nTopBorder + CellHeight / 2 - chkSideLen / 2), chkSideLen, chkSideLen)
                            If Not IsDBNull(oObject) AndAlso oObject.Equals(Columns(nIndex).TrueValue) Then
                                '画√
                                Dim pStart As PointF = New PointF(xPos, CSng(nTopBorder + CellHeight / 2)) '√的起点位置
                                Dim pTurn As PointF = New PointF(CSng(pStart.X + chkSideLen / 2), CSng(pStart.Y + chkSideLen / 2)) '√的折点位置
                                Dim pEnd As PointF = New PointF(CSng(pTurn.X + chkSideLen / 2), pTurn.Y - chkSideLen) '√的终点位置
                                g.DrawLines(Pens.Black, New PointF() {pStart, pTurn, pEnd})
                            End If
                            nDrawnRowsCounter = 1 '占用一行
                    End Select
                    nLeftBorder += Columns(nIndex).Width
                    If nDrawnRowsCounter > nMaxDrawnRows Then
                        nMaxDrawnRows = nDrawnRowsCounter
                    End If
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            Return drawnSoFar + nMaxDrawnRows
        End Function

        '内容的格式化，返回以STRING 类型
        Private Function FormatValue(ByVal theObject As Object, ByVal tip As Type, ByVal FormatMask As String) As String
            Dim szValue As String = ""
            If IsDBNull(theObject) Then
                szValue = ""
            Else
                If Not (FormatMask = "") Then
                    szValue = Microsoft.VisualBasic.Format(theObject, FormatMask)
                Else
                    If tip Is System.Type.GetType("System.DateTime") Then '时间型
                        szValue = CType(theObject, DateTime).ToString("dd.MM.yyyy.")
                    Else '其他类型
                        szValue = theObject.ToString
                    End If
                End If
            End If
            Return szValue
        End Function

        '对STRING的split
        Private Function SplitString(ByRef theSource As String, ByRef theResult As String, ByVal theWidth As Integer, ByVal g As Graphics, ByVal theFont As Font) As Boolean
            Dim nLastBlank As Integer = -1
            Dim szTmpBuffer As String = ""
            Dim bMore As Boolean = False
            Dim nIndex As Integer = 0
            While nIndex < theSource.Length
                If theSource.Chars(nIndex) = " "c Then
                    nLastBlank = nIndex
                End If
                szTmpBuffer += theSource.Chars(nIndex)
                Dim sf As SizeF = g.MeasureString(szTmpBuffer, theFont)
                If sf.Width > theWidth Then
                    Dim breakPoint As Integer = CInt(IIf(Not (nLastBlank = -1), nLastBlank + 1, (Microsoft.VisualBasic.IIf(nIndex = 0, 1, nIndex))))
                    theResult = theSource.Substring(0, breakPoint)
                    theSource = theSource.Substring(breakPoint)
                    bMore = True
                    Return bMore
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
            theResult = theSource
            theSource = ""
            Return bMore
        End Function

        '画出内容为空的DATAROWS
        Private Sub Draw_EmptyRows(ByVal g As Graphics, ByVal drawnSoFar As Integer)
            Dim rcTemp As Rectangle = m_TheRegion
            rcTemp.Y += m_nYOffset
            Dim nTopBorder As Integer
            nTopBorder = rcTemp.Top + CellHeight * Math.Min(drawnSoFar, GetPossibleRowNumber)
            Dim nIndex As Integer = 0
            While nIndex < GetPossibleRowNumber() - Math.Min(drawnSoFar, GetPossibleRowNumber)
                g.DrawLine(New Pen(Color.Black, 1), rcTemp.X, nTopBorder, rcTemp.Right, nTopBorder)
                Dim nLeftBorder As Integer = rcTemp.X
                Dim nSecIndex As Integer = 0
                While nSecIndex < m_TheData.Columns.Count
                    Dim sf As SizeF = g.MeasureString("", DataFont)
                    Dim yPos As Single = nLeftBorder + 1
                    g.DrawString("", DataFont, New SolidBrush(Color.Black), yPos, nTopBorder + CInt(CellHeight / 2 - sf.Height / 2))
                    nLeftBorder += Columns(nSecIndex).Width
                    System.Threading.Interlocked.Increment(nSecIndex)
                End While
                nTopBorder += CellHeight
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

        '画出边框
        Private Sub drawBorders(ByVal g As Graphics, ByVal drawnSoFar As Integer)
            Dim rcTemp As Rectangle = m_TheRegion
            rcTemp.Y += m_nYOffset

            Dim nRectHeight As Integer
            If Not (m_TheData Is Nothing) Then
                If m_bDoDrawEmptyRows Then
                    nRectHeight = CellHeight * GetPossibleRowNumber()
                Else
                    nRectHeight = CellHeight * drawnSoFar
                End If
            Else
                nRectHeight = drawnSoFar * CellHeight
            End If
            g.DrawRectangle(New Pen(Me.m_mBorderColor, 1), rcTemp.X, rcTemp.Y, rcTemp.Width, nRectHeight)
            Dim nLeftBorder As Integer = rcTemp.X
            Dim nIndex As Integer = 0
            While nIndex < Columns.Length
                If Columns(nIndex).Visible Then
                    g.DrawLine(New Pen(Me.m_mBorderColor, 1), nLeftBorder, rcTemp.Y, nLeftBorder, rcTemp.Y + nRectHeight)
                    nLeftBorder += Columns(nIndex).Width
                End If
                System.Threading.Interlocked.Increment(nIndex)
            End While
        End Sub

        Public Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics)
            If CInt(Me.document.m_HtSystemValues(CONST_TEXT_PAGE_NUMBER)) = 2 Then
                m_TheRegion = m_TheRegion2
            End If
            Dim nRowsDrawnSoFar As Integer = 0
            If m_bDoDrawHeader Then
                Dim rcTemp As Rectangle = m_TheRegion
                rcTemp.Y += m_nYOffset
                nRowsDrawnSoFar = Draw_Header(g, rcTemp, nRowsDrawnSoFar)
            End If
            Dim nGroupByFieldIndex As Integer = -1
            Dim szPreviousGroupByFieldValue As String = ""
            If Not (Me.m_mGroupByField = "") Then
                If Not (m_TheData Is Nothing) Then
                    If m_TheData.Rows.Count > 0 Then
                        nGroupByFieldIndex = m_TheData.Columns.IndexOf(Me.m_mGroupByField)
                        szPreviousGroupByFieldValue = m_TheData.Rows(0)(nGroupByFieldIndex).ToString
                    End If
                End If
            End If
            If Not (m_TheData Is Nothing) Then
                Dim nIndex As Integer = 0
                While nIndex < m_TheData.Rows.Count
                    Dim nextRow As DataRow = m_TheData.Rows(nIndex)
                    If Not (Me.m_mGroupByField = "") Then
                        If Not (szPreviousGroupByFieldValue = nextRow(nGroupByFieldIndex).ToString) Then
                            Dim temp As Rectangle = New Rectangle(Me.X, Me.Y + m_nYOffset + (Me.CellHeight * nRowsDrawnSoFar), Me.Width, Me.CellHeight)
                            nRowsDrawnSoFar = Draw_Header(g, temp, nRowsDrawnSoFar)
                            szPreviousGroupByFieldValue = nextRow(nGroupByFieldIndex).ToString
                        End If
                    End If
                    nRowsDrawnSoFar = drawDataRow(g, nIndex, nRowsDrawnSoFar)
                    System.Threading.Interlocked.Increment(nIndex)
                End While
                If m_bDoDrawEmptyRows Then
                    Draw_EmptyRows(g, nRowsDrawnSoFar)
                End If
            End If
            drawBorders(g, nRowsDrawnSoFar)
        End Sub

        Public Overloads Overrides Function GetRegion() As Rectangle
            Return m_TheRegion
        End Function

        Public Overloads Overrides Function CloneIMP() As Object
            Dim tmp As StyledTable = New StyledTable
            tmp.document = Me.document
            tmp.X = Me.X
            tmp.Y = Me.Y
            tmp.Width = Me.Width
            tmp.Height = Me.Height
            tmp.DataFont = Me.DataFont
            Dim cols(Me.Columns.Length) As StyledTableColumn
            Dim i As Integer = 0
            While i < Me.Columns.Length
                cols(i) = CType(Me.Columns(i).Clone, StyledTableColumn)
                System.Threading.Interlocked.Increment(i)
            End While
            tmp.Columns = cols
            tmp.Data = Me.Data
            tmp.DataSource = Me.DataSource
            tmp.CellHeight = Me.CellHeight
            tmp.DrawEmptyRows = Me.DrawEmptyRows
            tmp.DrawHeader = Me.DrawHeader
            tmp.HeaderBackgroundColor = Me.HeaderBackgroundColor
            tmp.HeaderFont = Me.HeaderFont
            Return tmp
        End Function

        Public Sub New()
        End Sub

        Public Sub New(ByVal originX As Integer, ByVal originY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal parent As PrintReportImp)
            MyClass.New()
            document = parent
            m_TheRegion = New Rectangle(originX, originY, width, height)
            m_TheRegion2 = New Rectangle(originX, originY, width, height)
        End Sub
        Public Sub SetRegion2(ByVal originX As Integer, ByVal originY As Integer, ByVal width As Integer, ByVal height As Integer)
            m_TheRegion2 = New Rectangle(originX, originY, width, height)
        End Sub
#End Region
    End Class

    Public Class StyledTableColumn : Implements ICloneable

        Public Enum AlignmentType As Short
            Left = 1
            Center
            Right
        End Enum

        Public Enum ColumnType As Short '列的类型
            Text = 1  '文本列
            Check 'Checkbox列
        End Enum

        Private m_szName As String
        Private m_szLabel As String
        Private m_nWidth As Integer
        Private m_szFormatMask As String = ""
        Private m_Alignment As AlignmentType
        Private m_bVisible As Boolean = True
        Private m_emType As ColumnType = ColumnType.Text
        Private m_oTrueValue As Object = True
        Private m_bStatic As Boolean = False
        Private m_strStatic As String = ""

        Public Property Alignment() As AlignmentType
            Get
                Return m_Alignment
            End Get
            Set(ByVal Value As AlignmentType)
                m_Alignment = Value
            End Set
        End Property
        Public Property FormatMask() As String
            Get
                Return Me.m_szFormatMask
            End Get
            Set(ByVal Value As String)
                Me.m_szFormatMask = Value
            End Set
        End Property

        Public Property Label() As String
            Get
                Return m_szLabel
            End Get
            Set(ByVal Value As String)
                m_szLabel = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_szName
            End Get
            Set(ByVal Value As String)
                m_szName = Value
            End Set
        End Property

        Public Property Visible() As Boolean
            Get
                Return m_bVisible
            End Get
            Set(ByVal Value As Boolean)
                m_bVisible = Value
            End Set
        End Property


        Public Property Width() As Integer
            Get
                Return m_nWidth
            End Get
            Set(ByVal Value As Integer)
                m_nWidth = Value
            End Set
        End Property

        '列的类型
        Public Property Type() As ColumnType
            Get
                Return m_emType
            End Get
            Set(ByVal Value As ColumnType)
                m_emType = Value
            End Set
        End Property

        '列为CheckBox列时，需要打勾的数据值
        Public Property TrueValue() As Object
            Get
                Return m_oTrueValue
            End Get
            Set(ByVal Value As Object)
                m_oTrueValue = Value
            End Set
        End Property

        Public Property bStatic() As Boolean
            Get
                Return m_bStatic
            End Get
            Set(ByVal value As Boolean)
                m_bStatic = value
            End Set
        End Property
        Public Property StaticValue() As String
            Get
                Return m_strStatic
            End Get
            Set(ByVal value As String)
                m_strStatic = value
            End Set
        End Property


        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim tmp As StyledTableColumn = New StyledTableColumn
            tmp.Name = Me.Name
            tmp.Label = Me.Label
            tmp.FormatMask = Me.FormatMask
            tmp.Width = Me.Width
            tmp.Alignment = Me.Alignment
            tmp.Visible = Me.Visible
            tmp.Type = Me.m_emType
            tmp.TrueValue = Me.m_oTrueValue
            Return tmp
        End Function

        Public Sub New()
            m_szName = "columnName"
            m_szLabel = "columnLabel"
            m_nWidth = 80
            m_Alignment = AlignmentType.Left
            m_emType = ColumnType.Text '缺省为文本列
            m_oTrueValue = True
        End Sub
    End Class
End Namespace
