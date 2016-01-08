Imports System.Windows.Forms

Public Class MyLabelBase
    Inherits System.Windows.Forms.Label

    Enum ImageStatus
        Over
        Press
        Disable
    End Enum
    Private m_OriImage As System.Drawing.Image
    Private m_OverImage As System.Drawing.Image
    Private m_PressImage As System.Drawing.Image
    Private m_DisableImage As System.Drawing.Image = Nothing
    Private m_strTipText As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_strTipText = ""
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = ""
    End Sub

#End Region

#Region "Propety"
    Public Property TipText() As String
        Get
            Return m_strTipText
        End Get
        Set(ByVal value As String)
            m_strTipText = value
        End Set
    End Property
#End Region
    Public Overridable Sub SetImageList(ByVal ImgNormal As System.Drawing.Image, ByVal ImgOver As System.Drawing.Image, ByVal ImgPress As System.Drawing.Image, Optional ByVal ImgDisable As System.Drawing.Image = Nothing)
        m_OriImage = ImgNormal
        m_OverImage = ImgOver
        m_PressImage = ImgPress
        If Not ImgDisable Is Nothing Then
            m_DisableImage = ImgDisable
        End If
    End Sub

    Private Sub MyLabelBase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.Focus() 'as the pnl will not get the focus as soon as it is clicked like btn,so here complusive set it
    End Sub

    Private Sub LabelEx_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        Me.Image = m_OverImage
    End Sub

    Private Sub LabelEx_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        Me.Image = m_OriImage
    End Sub

    Private Sub LabelEx_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Me.Image = m_PressImage
    End Sub

    Private Sub LabelEx_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        'if the mouse is above the control, set it as OVER status; otherwise, set it as Normal.
        If TypeOf sender Is System.Windows.Forms.Control Then
            Dim ctrl As System.Windows.Forms.Control = CType(sender, System.Windows.Forms.Control)
            If ctrl Is Nothing Or ctrl.Parent Is Nothing Then
                Return 'some times, the control is response the message while its parent form is disposing. 
            End If
            Dim ptUp As System.Drawing.Point = ctrl.PointToClient(Control.MousePosition)
            Dim rect As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), ctrl.Size)
            If rect.Contains(ptUp) Then
                Me.Image = m_OverImage
            Else
                Me.Image = m_OriImage
            End If
        End If
    End Sub

    Private Sub MyLabelBase_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        If String.IsNullOrEmpty(Me.TipText) = False Then
            Dim oToolTip As New ToolTip
            oToolTip.SetToolTip(Me, TipText)
        End If
    End Sub

    Public Overridable Sub PerformClick()
        If Me.Enabled = True AndAlso Me.Visible = True Then
            Me.Focus() 'as the pnl will not get the focus as soon as it is clicked like btn,so here complusive set it
            MyBase.OnClick(EventArgs.Empty)
        End If
    End Sub

    Private Sub MyLabelBase_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled = False Then
            If Not m_DisableImage Is Nothing Then
                Me.Image = m_DisableImage
            End If
        Else 'reset the image as normal by default.
            LabelEx_MouseLeave(sender, e)
        End If
    End Sub
End Class
