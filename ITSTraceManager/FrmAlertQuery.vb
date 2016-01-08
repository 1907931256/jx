
Imports DBManager

Public Class FrmAlertQuery

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        BindTable()
    End Sub

    Private Sub BindTable()
        Dim traceDb As New DbTraceLayout
        Dim alertTable As New DataTable
        Dim startTime As String = dtpStart.Value.Date
        Dim endTime As String = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)
        traceDb.QueryAlertRecord(alertTable, CDate(startTime), CDate(endTime))
        Me.dgv.ClearBoolColumn()
        Me.dgv.ClearFormatColumn()
        Dim nArrWidth() As Short = {100, 200, 150, 150, 250}
        Me.dgv.RealColumnWidthCollection = nArrWidth
        Me.dgv.DataSource = alertTable
        Me.dgv.ClearSelection()
    End Sub
End Class
