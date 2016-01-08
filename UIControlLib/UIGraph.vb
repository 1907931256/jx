Imports System.Drawing
Imports UIGraphLib
Imports ITSBase

Public Class UIGraph
    Private Const CONST_INTEGER_DEFAULT_FONT_SIZE As Integer = 15.0!
    Private m_strTitle As String = ""
    Private m_strXAxisTitle As String = ""
    Private m_strYAxisTitle As String = ""
    Private m_nMinLabelsCount As Integer = CONST_INTEGER_TARGET_STEP_COUNT
    Private m_crBackColor As Color = Color.FromArgb(243, 243, 243)
    Private m_aryGraphColor() As Color = New Color() {Color.FromArgb(153, 153, 255), Color.FromArgb(153, 51, 102), _
                                                    Color.FromArgb(255, 255, 204), Color.FromArgb(204, 255, 255), Color.FromArgb(102, 0, 102), _
                                                    Color.FromArgb(255, 124, 128), Color.FromArgb(0, 102, 204), Color.FromArgb(204, 204, 255), _
                                                    Color.FromArgb(0, 0, 128), Color.FromArgb(255, 0, 255)}
    Private Const CONST_STR_TITLE As String = "±êÌâ"
    Private Const CONST_STR_X_TITILE As String = "XÖá"
    Private Const CONST_STR_Y_TITILE As String = "YÖá"
    Private Const CONST_R_INCREASMENT As Integer = 19
    Private Const CONST_G_INCREASMENT As Integer = 29
    Private Const CONST_B_INCREASMENT As Integer = 39
    Private Const CONST_INTEGER_TARGET_STEP_COUNT As Integer = 7
    Private Const CONST_INTEGER_TARGET_STEP_SIZE As Integer = 50

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.IsShowContextMenu = False
        Me.IsShowPointValues = True
        Me.IsEnableZoom = False
    End Sub
#Region "Property"
    Public Property Title() As String
        Get
            Return m_strTitle
        End Get
        Set(ByVal value As String)
            m_strTitle = value
        End Set
    End Property
    Public Property XAxisText() As String
        Get
            Return m_strXAxisTitle
        End Get
        Set(ByVal value As String)
            m_strXAxisTitle = value
        End Set
    End Property
    Public Property YAxisText() As String
        Get
            Return m_strYAxisTitle
        End Get
        Set(ByVal value As String)
            m_strYAxisTitle = value
        End Set
    End Property

    Public WriteOnly Property MinLabelsCount() As Integer
        Set(ByVal value As Integer)
            m_nMinLabelsCount = value
        End Set
    End Property
#End Region

#Region "Method"
    'The scale picking logic is based on the assumption that the most humanly palatable 
    'step sizes will be even divisors of 10. That is, step sizes should be 1, 2, or 5 times some power of 10
    Private Function CalcStepSize(ByVal range As Double, ByVal targetSteps As Double) As Double
        If range = 0.0 Then Return 1.0
        ' Calculate an initial guess at step size
        Dim tempStep As Double = range / targetSteps
        'Get the magnitude of the step size
        Dim mag As Double = Math.Floor(Math.Log10(tempStep))
        Dim magPow As Double = Math.Pow(10.0, mag)
        'Calculate most significant digit of the new step size
        Dim magMsd As Double = CInt(tempStep / magPow + 0.5)
        'promote the MSD to either 1, 2, or 5
        If (magMsd > 5.0) Then
            magMsd = 10.0
        ElseIf (magMsd > 2.0) Then
            magMsd = 5.0
        ElseIf (magMsd > 1.0) Then
            magMsd = 2.0
        End If
        Return magMsd * magPow
    End Function
    Private Function GetGraphYStep(ByVal dtTable As DataTable, ByRef dStepSize As Double) As Boolean
        If dtTable Is Nothing Then Return False
        Dim dMin As Double = Double.MaxValue / 2 - 1.0
        Dim dMax As Double = Double.MinValue / 2 + 1.0
        If dtTable.Rows.Count = 0 Then
            dMin = 0
            dMax = 0
        Else
            For Each row As DataRow In dtTable.Rows
                ArrayMaxMin(GetYValues(row), dMax, dMin)
            Next
        End If
        If dMax <> 0 AndAlso Math.Abs((dMax - dMin) / dMax) < 0.2 Then
            dStepSize = Math.Abs(dMax) / 5
        Else
            dStepSize = CalcStepSize(dMax - dMin, CONST_INTEGER_TARGET_STEP_COUNT)
        End If
        If dStepSize < 1.0 Then dStepSize = 1.0
        Return True
    End Function
    Private Sub ArrayMaxMin(ByVal dValues() As Double, ByRef dMax As Double, ByRef dMin As Double)
        If dValues Is Nothing Then Return
        Dim n1 As Integer, n2 As Integer
        n1 = UBound(dValues)
        n2 = LBound(dValues)
        Dim maxnumber As Double = dValues(n1)
        Dim minnumber As Double = dValues(n2)
        For i As Integer = n2 + 1 To n1
            If dValues(i) > maxnumber Then
                maxnumber = dValues(i)
            End If
        Next i
        For i As Integer = n2 + 1 To n1
            If dValues(i) < minnumber Then
                minnumber = dValues(i)
            End If
        Next i
        If maxnumber > dMax Then dMax = maxnumber
        If minnumber < dMin Then dMin = minnumber
    End Sub
    Public Sub DrawPieGraph(ByVal dtTable As DataTable)
        If dtTable Is Nothing Then Return
        Me.MasterPane.PaneList.Clear()
        Dim myPane As New GraphPane
        myPane.Rect = New RectangleF(New Point(0, 0), Me.Size)

        myPane.Title.Text = m_strTitle
        myPane.Fill = New Fill(m_crBackColor)
        myPane.Chart.Fill = New Fill(m_crBackColor)
        myPane.Legend.Position = LegendPos.Right
        myPane.Legend.FontSpec.Size = CONST_INTEGER_DEFAULT_FONT_SIZE

        Dim i As Integer = 0
        For Each row As DataRow In dtTable.Rows
            Dim nCount As Integer = CInt(row.Item(TEXT_MACHINE_STARTUP_COUNT))
            Dim strName As String = row.Item(TEXT_MACHINE_ID).ToString
            Dim segment As PieItem = myPane.AddPieSlice(nCount, GenerateColor(i), 0, strName)
            segment.LabelType = PieLabelType.Percent
            segment.LabelDetail.FontSpec.Size = CONST_INTEGER_DEFAULT_FONT_SIZE
            i += 1
        Next

        Me.MasterPane.Add(myPane)
        Me.AxisChange()
        Me.Refresh()
    End Sub

    Public Sub DrawBarGraph(ByVal dtTable As DataTable)
        If dtTable Is Nothing Then Return
        Me.MasterPane.PaneList.Clear()
        Dim myPane As New GraphPane
        myPane.Rect = New RectangleF(New Point(0, 0), Me.Size)

        myPane.Title.Text = m_strTitle
        myPane.Fill = New Fill(m_crBackColor)
        myPane.Chart.Fill = New Fill(m_crBackColor)
        myPane.Legend.Position = LegendPos.Right
        myPane.Legend.FontSpec.Size = CONST_INTEGER_DEFAULT_FONT_SIZE

        myPane.XAxis.Title.Text = XAxisText
        myPane.YAxis.Title.Text = YAxisText
        myPane.XAxis.Scale.TextLabels = GetXAxisLabels(dtTable)
        myPane.XAxis.Type = AxisType.Text
        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOff = 0.0
        Dim dStepSize As Double = CONST_INTEGER_TARGET_STEP_SIZE
        If GetGraphYStep(dtTable, dStepSize) Then
            myPane.YAxis.Scale.MajorStep = dStepSize
            myPane.YAxis.Scale.MinorStep = dStepSize
        End If
        'add date
        Dim i As Integer = 0
        For Each row As DataRow In dtTable.Rows
            Dim strItemName As String = row.Item(TEXT_STATISTIC_ITEM).ToString
            Dim cr As Color = GenerateColor(i)
            Dim barItem As BarItem = myPane.AddBar(strItemName, Nothing, GetYValues(row), cr)
            barItem.Bar.Fill = New Fill(cr)
            i += 1
        Next

        Me.MasterPane.Add(myPane)
        Me.AxisChange()
        Me.Refresh()
    End Sub

    Public Sub DrawLineGraph(ByVal dtTable As DataTable)
        If dtTable Is Nothing Then Return
        Me.MasterPane.PaneList.Clear()
        Dim myPane As New GraphPane
        myPane.Rect = New RectangleF(New Point(0, 0), Me.Size)

        myPane.Title.Text = m_strTitle
        myPane.Fill = New Fill(m_crBackColor)
        myPane.Chart.Fill = New Fill(m_crBackColor)
        myPane.Legend.Position = LegendPos.Right
        myPane.Legend.FontSpec.Size = CONST_INTEGER_DEFAULT_FONT_SIZE

        myPane.XAxis.Title.Text = XAxisText
        myPane.YAxis.Title.Text = YAxisText
        myPane.XAxis.Scale.TextLabels = GetXAxisLabels(dtTable)
        myPane.XAxis.Type = AxisType.Text
        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOff = 0.0
        Dim dStepSize As Double = CONST_INTEGER_TARGET_STEP_SIZE
        If GetGraphYStep(dtTable, dStepSize) Then
            myPane.YAxis.Scale.MajorStep = dStepSize
            myPane.YAxis.Scale.MinorStep = dStepSize
        End If

        'add date
        Dim i As Integer = 0
        For Each row As DataRow In dtTable.Rows
            Dim strItemName As String = row.Item(TEXT_STATISTIC_ITEM).ToString
            Dim curve As LineItem = myPane.AddCurve(strItemName, Nothing, GetYValues(row), GenerateColor(i), SymbolType.Circle)
            curve.Symbol.Size = 2.0F
            curve.Symbol.Fill = New Fill(Color.RoyalBlue)
            i += 1
        Next

        Me.MasterPane.Add(myPane)
        Me.AxisChange()
        Me.Refresh()
    End Sub

    Public Sub DrawEmpty()
        Me.MasterPane.PaneList.Clear()
        Dim myPane As New GraphPane
        myPane.Rect = New RectangleF(New Point(0, 0), Me.Size)
        myPane.Title.Text = CONST_STR_TITLE
        myPane.Fill = New Fill(m_crBackColor)
        myPane.Chart.Fill = New Fill(m_crBackColor)

        myPane.XAxis.Title.Text = CONST_STR_X_TITILE
        myPane.YAxis.Title.Text = CONST_STR_Y_TITILE
        Me.MasterPane.Add(myPane)
        Me.AxisChange()
        Me.Refresh()
    End Sub

    Private Function GetXAxisLabels(ByVal dtTable As DataTable) As String()
        If dtTable Is Nothing OrElse dtTable.Columns.Count < 1 Then Return Nothing
        Dim nValidColCount As Integer = dtTable.Columns.Count
        If dtTable.Columns.Contains(TEXT_STATISTIC_ITEM) Then nValidColCount -= 1
        Dim nMinLabelCount As Integer = Math.Max(m_nMinLabelsCount, nValidColCount)
        Dim strXLabels() As String = New String(nMinLabelCount - 1) {}
        Dim nIndex As Integer = 0
        For Each col As DataColumn In dtTable.Columns
            If col.ColumnName <> TEXT_STATISTIC_ITEM Then
                strXLabels.SetValue(col.ColumnName, nIndex)
                nIndex += 1
            End If
        Next
        Return strXLabels
    End Function

    Private Function GetYValues(ByVal row As DataRow) As Double()
        If row Is Nothing OrElse row.Table.Columns.Count < 1 Then Return Nothing
        Dim nOffset As Integer = -1
        If row.Table.Columns.Contains(TEXT_STATISTIC_ITEM) Then nOffset = -2
        Dim dYValues() As Double = New Double(row.Table.Columns.Count + nOffset) {}
        Dim nIndex As Integer = 0
        For i As Integer = 0 To row.Table.Columns.Count - 1
            If row.Table.Columns(i).ColumnName <> TEXT_STATISTIC_ITEM Then
                dYValues.SetValue(row.Item(i), nIndex)
                nIndex += 1
            End If
        Next
        Return dYValues
    End Function

    Private Function GenerateColor(ByVal nIndex As Integer) As Color
        Dim crRet As Color = Color.Red
        Dim nReminder As Integer = nIndex Mod m_aryGraphColor.Length
        Dim nMultiple As Integer = Math.Truncate(Math.Abs(CDbl(nIndex / m_aryGraphColor.Length)))
        crRet = Color.FromArgb(m_aryGraphColor(nReminder).R + nMultiple * CONST_R_INCREASMENT, _
                                                    m_aryGraphColor(nReminder).G + nMultiple * CONST_G_INCREASMENT, _
                                                    m_aryGraphColor(nReminder).B + nMultiple * CONST_B_INCREASMENT)
        Return crRet
    End Function
#End Region
End Class
