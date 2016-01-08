Imports UIGraphLib
Imports System.Drawing
Imports ITSBase

Public Class UIMachineChart
    Private m_DevType As String = TEXT_MACHINE_GRAPH_TYPE_S

    Public Property DevType() As String
        Get
            Return m_DevType
        End Get
        Set(ByVal value As String)
            m_DevType = value
            InitialControl()
        End Set
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.IsShowContextMenu = False
        Me.IsShowPointValues = True
        Me.IsEnableZoom = False

        InitialControl()
    End Sub

    Public Sub ShowChart(ByRef oLog As CLog)

        If DevType.ToUpper().Equals(TEXT_MACHINE_GRAPH_TYPE_W) Then '清洗器
            Dim oPane As GraphPane = Me.GraphPane
            If oPane Is Nothing Then
                Return
            End If
            Me.MasterPane.PaneList.Clear()

            Dim lstChamber As New PointPairList()
            Dim lstDryer As New PointPairList()
            Dim nI As Integer
            Dim nCount As Integer = oLog.GetLogEventCount()
            For nI = 0 To nCount - 1
                Dim dIntervalTime, dPressure, dJacketTemp, dDraintTemp, dChamber, dDryer As Double
                oLog.GetLogEvent(nI, dIntervalTime, dPressure, dJacketTemp, dDraintTemp, dChamber, dDryer)
                lstChamber.Add(dIntervalTime, dChamber)
                lstDryer.Add(dIntervalTime, dDryer)
            Next

            Dim ciChamber, ciDryer As CurveItem
            ciChamber = oPane.CurveList.Item("Dryer")
            ciDryer = oPane.CurveList.Item("Chamber")

            Dim liCurve As LineItem
            liCurve = CType(ciChamber, LineItem)
            liCurve.Points = lstChamber
            liCurve = CType(ciDryer, LineItem)
            liCurve.Points = lstDryer

            Me.MasterPane.Add(oPane)

            Me.AxisChange()
            Me.Refresh()

        ElseIf DevType.ToUpper().Equals(TEXT_MACHINE_GRAPH_TYPE_S) Then '灭菌器
            Dim oPane As GraphPane = Me.GraphPane
            If oPane Is Nothing Then
                Return
            End If
            Me.MasterPane.PaneList.Clear()

            Dim lstPressure As New PointPairList()
            Dim lstJacket As New PointPairList()
            Dim lstDrain As New PointPairList()
            Dim nI As Integer
            Dim nCount As Integer = oLog.GetLogEventCount()
            For nI = 0 To nCount - 1
                Dim dIntervalTime, dPressure, dJacketTemp, dDraintTemp, dChamber, dDryer As Double
                oLog.GetLogEvent(nI, dIntervalTime, dPressure, dJacketTemp, dDraintTemp, dChamber, dDryer)
                lstPressure.Add(dIntervalTime, dPressure)
                lstJacket.Add(dIntervalTime, dJacketTemp)
                lstDrain.Add(dIntervalTime, dDraintTemp)
            Next

            Dim ciPressure, ciJacket, ciDrain As CurveItem
            ciPressure = oPane.CurveList.Item("Pressure")
            ciJacket = oPane.CurveList.Item("Jacket")
            ciDrain = oPane.CurveList.Item("Drain")

            Dim liCurve As LineItem
            liCurve = CType(ciPressure, LineItem)
            liCurve.Points = lstPressure
            liCurve = CType(ciJacket, LineItem)
            liCurve.Points = lstJacket
            liCurve = CType(ciDrain, LineItem)
            liCurve.Points = lstDrain

            Me.MasterPane.Add(oPane)

            Me.AxisChange()
            Me.Refresh()

        End If
    End Sub


    Private Sub CChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitialControl()
    End Sub
    Private Sub InitialControl()

        If DevType.ToUpper().Equals(TEXT_MACHINE_GRAPH_TYPE_W) Then '清洗器
            Dim oPane As GraphPane = Me.GraphPane
            'Dim oPane As New GraphPane
            'oPane.Rect = New RectangleF(New Point(0, 0), Me.Size)
            oPane.CurveList.Clear()
            Dim lst As New PointPairList()
            Dim liCurve As LineItem
            liCurve = oPane.AddCurve("Dryer", lst, Color.Red, SymbolType.None)
            'liCurve = oPane.AddCurve("Pressure", lst, Color.Red, SymbolType.None)

            liCurve.Line.IsSmooth = True
            liCurve.Line.SmoothTension = 0.5
            liCurve.IsY2Axis = True
            liCurve = oPane.AddCurve("Chamber", lst, Color.Green, SymbolType.None)
            'liCurve = oPane.AddCurve("Jacket", lst, Color.Blue, SymbolType.None)
            liCurve.Line.IsSmooth = True
            liCurve.Line.SmoothTension = 0.5
            liCurve.YAxisIndex = 1

            oPane.Title.Text = "Cleaner Data Chart"
            oPane.XAxis.Title.Text = "Time(m)"
            oPane.YAxis.Title.Text = "Dryer(℃)"
            oPane.Y2Axis.Title.Text = "Chamber(℃)"

            oPane.XAxis.MajorGrid.IsVisible = True

            oPane.YAxis.MajorTic.IsOpposite = False
            oPane.YAxis.MinorTic.IsOpposite = False

            'Don't display the Y zero line
            oPane.YAxis.MajorGrid.IsZeroLine = False

            ' Enable the Y2 axis display
            oPane.Y2Axis.IsVisible = True
            ' Make the Y2 axis scale blue
            oPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue
            oPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue
            ' turn off the opposite tics so the Y2 tics don't show up on the Y axis
            oPane.Y2Axis.MajorTic.IsOpposite = False
            oPane.Y2Axis.MinorTic.IsOpposite = False
            ' Display the Y2 axis grid lines
            oPane.Y2Axis.MajorGrid.IsVisible = True
            ' Align the Y2 axis labels so they are flush to the axis
            'oPane.Y2Axis.Scale.Align = AlignP.Inside
            'oPane.Y2Axis.Scale.Min = 1.5
            'oPane.Y2Axis.Scale.Max = 3

            oPane.Chart.Fill = New Fill(Color.White, Color.LightGoldenrodYellow, 45.0F)

            ' Just manually control the X axis range so it scrolls continuously
            ' instead of discrete step-sized jumps
            oPane.XAxis.Scale.Min = 0
            oPane.XAxis.Scale.Max = 80
            oPane.XAxis.Scale.MinorStep = 10
            oPane.XAxis.Scale.MajorStep = 10

            oPane.YAxis.Scale.Min = 20
            oPane.YAxis.Scale.Max = 100
            oPane.YAxis.Scale.MinorStep = 10
            oPane.YAxis.Scale.MajorStep = 10

            oPane.Y2Axis.Scale.Min = 20
            oPane.Y2Axis.Scale.Max = 100
            oPane.Y2Axis.Scale.MinorStep = 10
            oPane.Y2Axis.Scale.MajorStep = 10

            'Me.MasterPane.Add(oPane)
            Me.AxisChange()
            Me.Refresh()
        ElseIf DevType.ToUpper().Equals(TEXT_MACHINE_GRAPH_TYPE_S) Then '灭菌器
            Dim oPane As GraphPane = Me.GraphPane
            'Dim oPane As New GraphPane
            ' oPane.Rect = New RectangleF(New Point(0, 0), Me.Size)
            oPane.CurveList.Clear()
            Dim lst As New PointPairList()
            Dim liCurve As LineItem
            liCurve = oPane.AddCurve("Pressure", lst, Color.Red, SymbolType.None)
            'liCurve = oPane.AddCurve("Pressure", lst, Color.Red, SymbolType.None)

            liCurve.Line.IsSmooth = True
            liCurve.Line.SmoothTension = 0.5
            liCurve.IsY2Axis = True
            liCurve = oPane.AddCurve("Jacket", lst, Color.Blue, SymbolType.None)
            'liCurve = oPane.AddCurve("Jacket", lst, Color.Blue, SymbolType.None)
            liCurve.Line.IsSmooth = True
            liCurve.Line.SmoothTension = 0.5
            liCurve.YAxisIndex = 1
            liCurve = oPane.AddCurve("Drain", lst, Color.Green, SymbolType.None)
            'liCurve = oPane.AddCurve("Drain", lst, Color.Green, SymbolType.None)
            liCurve.Line.IsSmooth = True
            liCurve.Line.SmoothTension = 0.5
            liCurve.YAxisIndex = 1

            oPane.Title.Text = "Sterilizer Data Chart"
            oPane.XAxis.Title.Text = "Time(m)"
            oPane.YAxis.Title.Text = "Temperature(℃)"
            oPane.Y2Axis.Title.Text = "Pressure(Bar)"

            oPane.XAxis.MajorGrid.IsVisible = True

            oPane.YAxis.MajorTic.IsOpposite = False
            oPane.YAxis.MinorTic.IsOpposite = False

            'Don't display the Y zero line
            oPane.YAxis.MajorGrid.IsZeroLine = False

            ' Enable the Y2 axis display
            oPane.Y2Axis.IsVisible = True
            ' Make the Y2 axis scale blue
            oPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue
            oPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue
            ' turn off the opposite tics so the Y2 tics don't show up on the Y axis
            oPane.Y2Axis.MajorTic.IsOpposite = False
            oPane.Y2Axis.MinorTic.IsOpposite = False
            ' Display the Y2 axis grid lines
            oPane.Y2Axis.MajorGrid.IsVisible = True
            ' Align the Y2 axis labels so they are flush to the axis
            'oPane.Y2Axis.Scale.Align = AlignP.Inside
            'oPane.Y2Axis.Scale.Min = 1.5
            'oPane.Y2Axis.Scale.Max = 3

            oPane.Chart.Fill = New Fill(Color.White, Color.LightGoldenrodYellow, 45.0F)

            ' Just manually control the X axis range so it scrolls continuously
            ' instead of discrete step-sized jumps
            oPane.XAxis.Scale.Min = 0
            oPane.XAxis.Scale.Max = 80
            oPane.XAxis.Scale.MinorStep = 10
            oPane.XAxis.Scale.MajorStep = 10

            oPane.YAxis.Scale.Min = 0
            oPane.YAxis.Scale.Max = 150
            oPane.YAxis.Scale.MinorStep = 30
            oPane.YAxis.Scale.MajorStep = 30

            oPane.Y2Axis.Scale.Min = 0
            oPane.Y2Axis.Scale.Max = 5
            oPane.Y2Axis.Scale.MinorStep = 1
            oPane.Y2Axis.Scale.MajorStep = 1

            'Me.MasterPane.Add(oPane)
            Me.AxisChange()
            Me.Refresh()
        End If
    End Sub
End Class


