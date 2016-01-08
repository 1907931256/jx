Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing

Public Class RoundedPanel
    Inherits Windows.Forms.Panel

    Public Sub New()
        InitializeComponent()
    End Sub
    Private m_PanelColor As Color = Color.FromArgb(214, 226, 242)
    Private m_HasTitle As Boolean = True
    Private m_strTitle As String = ""
    Public Property PanelColor() As Color
        Get
            Return m_PanelColor
        End Get
        Set(ByVal value As Color)
            m_PanelColor = value
        End Set
    End Property

    Public Property HasTitle() As Boolean
        Get
            Return m_HasTitle
        End Get
        Set(ByVal value As Boolean)
            m_HasTitle = value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return m_strTitle
        End Get
        Set(ByVal value As String)
            m_strTitle = value
            Me.Refresh()
        End Set
    End Property
    Private Sub RoundedPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim pnl As Panel = TryCast(sender, Panel)
        Dim oPath As New GraphicsPath()

        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim w As Integer = pnl.Width
        Dim h As Integer = pnl.Height
        Dim a As Integer = 30

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        oPath.AddArc(x, y, a, a, 180, 90)
        oPath.AddArc(w - a - 1, y, a, a, 270, 90)
        oPath.AddArc(w - a - 1, h - a - 1, a, a, 0, 90)
        oPath.AddArc(x, h - a - 1, a, a, 90, 90)
        oPath.CloseAllFigures()
        e.Graphics.DrawPath(New Pen(New SolidBrush(Color.FromArgb(200, 204, 207))), oPath)
        'Dim blueBrush As New SolidBrush(m_PanelColor)
        'e.Graphics.FillRegion(blueBrush, New Region(oPath))

        Dim oPath2 As New GraphicsPath()
        oPath2.AddArc(x + 1, y + 1, a, a, 180, 90)
        oPath2.AddArc(w - a - 2, y, a, a, 270, 90)
        oPath2.AddArc(w - a - 2, h - a - 2, a, a, 0, 90)
        oPath2.AddArc(x, h - a - 2, a, a, 90, 90)
        oPath2.CloseAllFigures()

        Dim blueBrush As New SolidBrush(Me.BackColor)
        e.Graphics.FillRegion(blueBrush, New Region(oPath2))

        Dim oPath3 As New GraphicsPath()
        oPath3.AddArc(x, y + 29, a, a, 180, 90)
        oPath3.AddArc(w - a - 1, y + 29, a, a, 270, 90)
        oPath3.AddArc(w - a - 1, h - a - 1, a, a, 0, 90)
        oPath3.AddArc(x, h - a - 1, a, a, 90, 90)
        oPath3.CloseAllFigures()
        e.Graphics.DrawPath(New Pen(New SolidBrush(Color.FromArgb(200, 204, 207))), oPath3)

        Dim oPath4 As New GraphicsPath()
        oPath4.AddArc(x + 1, y + 30, a, a, 180, 90)
        oPath4.AddArc(w - a - 1, y + 30, a, a, 270, 90)
        oPath4.AddArc(w - a - 2, h - a - 2, a, a, 0, 90)
        oPath4.AddArc(x, h - a - 2, a, a, 90, 90)
        oPath4.CloseAllFigures()
        Dim blueBrush2 As New SolidBrush(m_PanelColor)
        e.Graphics.FillRegion(blueBrush2, New Region(oPath4))

        If m_HasTitle Then
            e.Graphics.DrawString(m_strTitle, Me.Font, New SolidBrush(Me.ForeColor), 7, 7)
        End If
    End Sub
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'RoundedPanel
        '
        Me.ResumeLayout(False)

    End Sub
End Class
