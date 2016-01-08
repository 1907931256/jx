Imports ITSBase

Public Class FrmLayoutDesigner

    Private Sub FrmLayoutDesigner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TraceFoundation.LoadLayout(ConstDef.TEXT_LBS_LAYOUT_DEMO, Me.LoyoutContainer)
    End Sub
End Class