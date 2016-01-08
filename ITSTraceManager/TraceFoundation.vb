Imports System.Drawing
Imports System.Windows.Forms
Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports TraceCtrlLib.PanelExtend

Public Class TraceFoundation
    Public Shared Function LoadLayout(layoutName As String, host As Panel) As Boolean
        If String.IsNullOrEmpty(layoutName) OrElse host Is Nothing Then Return False
        Try
            Dim traceDb As New DbTraceLayout
            Dim layoutEntity As New TraceLayoutEntity
            'load Layout basic info by Name
            Dim layoutBasic As New DataTable
            If DBMEDITS_RESULT.SUCCESS = traceDb.QueryLayoutInfoByName(layoutBasic, layoutName) AndAlso Not layoutBasic.IsNullOrEmpty() Then
                layoutEntity.Id = Judgement.JudgeDBNullValue(layoutBasic.Rows(0).Item(LAYOUT_INFO_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                Dim xRatio As Double = host.Width / CInt(layoutBasic.Rows(0).Item(LAYOUT_INFO_INIT_WIDTH))
                Dim yRatio As Double = host.Height / CInt(layoutBasic.Rows(0).Item(LAYOUT_INFO_INIT_HEIGHT))

                'load the detail info
                Dim layoutDetail As New DataTable
                If DBMEDITS_RESULT.SUCCESS = traceDb.QueryLayoutDetails(layoutDetail, layoutEntity.Id) AndAlso Not layoutDetail.IsNullOrEmpty() Then
                    For Each layoutRow As DataRow In layoutDetail.Rows
                        Dim traceEntity As New TraceEntity
                        traceEntity.Id = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_INFO_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.ParentId = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_PARENT_ID), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.Name = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                        traceEntity.Type = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_TYPE), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.InitWidth = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_INIT_WIDTH), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.InitHeight = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_INIT_HEIGHT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.OpenAt = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_OPEN_AT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.OpenStart = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_OPEN_START), ENUM_DATA_TYPE.DATA_TYPE_FLOAT)
                        traceEntity.OpenRatio = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_OPEN_RATIO), ENUM_DATA_TYPE.DATA_TYPE_FLOAT)
                        traceEntity.Dock = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_DOCK), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.Text = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_TEXT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                        traceEntity.DoorAt = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_DOOR_AT), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
                        traceEntity.DoorStyle = Judgement.JudgeDBNullValue(layoutRow.Item(LAYOUT_DETAIL_DOOR_STYLE), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)

                        Dim panel As Panel = Nothing
                        If traceEntity.Type = TRACE_PANEL_PANEL.PANEL Then
                            panel = New Panel() With {.Name = String.Format("{0}___{1}", host.Name, traceEntity.Name), .Dock = traceEntity.Dock, .Width = traceEntity.InitWidth * xRatio, .Height = traceEntity.InitHeight * yRatio}
                        ElseIf traceEntity.Type = TRACE_PANEL_PANEL.TRACE_PANEL Then
                            panel = New TracePanel() With {.Name = String.Format("{0}___{1}", host.Name, traceEntity.Name), .Dock = traceEntity.Dock, .Width = traceEntity.InitWidth * xRatio, .Height = traceEntity.InitHeight * yRatio, _
                                                          .OpenAt = traceEntity.OpenAt, .OpenStart = traceEntity.OpenStart, .OpenRatio = traceEntity.OpenRatio, .DisplayText = traceEntity.Text, .DoorAt = traceEntity.DoorAt, .DoorStyle = traceEntity.DoorStyle}
                            AddHandler panel.MouseHover, AddressOf TracePanelMouseHover
                        End If
                        If panel IsNot Nothing Then
                            panel.BackColor = Color.FromArgb(194, 217, 247)
                            If traceEntity.ParentId = -1 Then 'the child of root
                                host.Controls.Add(panel)
                            Else
                                'find the parent control according to parent_id 
                                Dim parentTraceEntity = layoutEntity.TraceEntityColl.First(Function(o) o.Id = traceEntity.ParentId)
                                If parentTraceEntity Is Nothing Then Continue For
                                parentTraceEntity.RelatePanel.Controls.Add(panel)
                            End If
                            traceEntity.RelatePanel = panel
                            layoutEntity.TraceEntityColl.Add(traceEntity)
                        End If
                    Next
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Shared Sub TracePanelMouseHover(ByVal sender As Object, ByVal e As EventArgs)
        CType(sender, TracePanel).MouseHoverHandle(e)
    End Sub
End Class
