Public Class MainForm
    Private ReadOnly _mainEntity As MainEntity

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _mainEntity = New MainEntity()
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        _mainEntity.Stop()
    End Sub


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _mainEntity.Start()
    End Sub
End Class