Imports System.Windows.Forms

Namespace Accessory

    Public Class TraceLayoutEntity
        Public Property Id() As Integer
        Public Property Name() As String
        Public Property InitWidth() As Integer
        Public Property InitHeight() As Integer
        Public Property CreateTime() As DateTime
        Public Property TraceEntityColl() As List(Of TraceEntity)

        Public Sub New()
            TraceEntityColl = New List(Of TraceEntity)()
        End Sub
    End Class

    Public Class TraceEntity
        Public Property Id() As Integer
        Public Property LayoutId() As Integer
        Public Property ParentId() As Integer
        Public Property Name() As String
        Public Property Type() As Integer
        Public Property InitWidth() As Integer
        Public Property InitHeight() As Integer
        Public Property OpenAt() As Integer
        Public Property OpenStart() As Double
        Public Property OpenRatio() As Double
        Public Property Dock As Integer
        Public Property Text() As String
        Public Property RelatePanel() As Panel
        Public Property DoorAt() As Integer
        Public Property DoorStyle As Integer
    End Class
End Namespace