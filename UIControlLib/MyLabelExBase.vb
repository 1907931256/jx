Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class MyLabelExBase
    Inherits MyLabelBase
    Private m_crFore As Color
    Private m_crDisableText As System.Drawing.Color = System.Drawing.Color.FromArgb(255, 150, 150, 150)
    Protected m_bNeedOffset As Boolean = False
    Const CONST_MOUSEDOWN_OFFSET As Integer = 1

    Enum ImageStatusEx
        Normal
        Over
        Press
    End Enum
    Protected m_AryLeftImage(3) As System.Drawing.Image
    Protected m_AryMiddleImage(3) As System.Drawing.Image
    Protected m_AryRightImage(3) As System.Drawing.Image

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_crFore = Color.Black

        Dim aryPanels As Panel() = {PnlLeft, PnlMiddle, PnlRight}
        For Each pnl As Panel In aryPanels
            AddHandler pnl.MouseEnter, AddressOf PnlMouseEnter
            AddHandler pnl.MouseLeave, AddressOf PnlMouseLeave
            AddHandler pnl.MouseDown, AddressOf PnlMouseDown
            AddHandler pnl.MouseUp, AddressOf PnlMouseUp
            AddHandler pnl.Click, AddressOf pnlClick
            AddHandler EnabledChanged, AddressOf PnlEnabledChanged
        Next

        Me.ForeColor = Color.Transparent
        Me.AutoSize = False
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Protected Friend WithEvents PnlLeft As System.Windows.Forms.Panel
    Protected Friend WithEvents PnlMiddle As System.Windows.Forms.Panel
    Protected Friend WithEvents PnlRight As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PnlLeft = New System.Windows.Forms.Panel
        Me.PnlMiddle = New System.Windows.Forms.Panel
        Me.PnlRight = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'PnlLeft
        '
        Me.PnlLeft.BackColor = System.Drawing.Color.Transparent
        Me.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.PnlLeft.Name = "PnlLeft"
        Me.PnlLeft.Size = New System.Drawing.Size(3, 30)
        Me.PnlLeft.TabIndex = 0
        '
        'PnlMiddle
        '
        Me.PnlMiddle.BackColor = System.Drawing.Color.Transparent
        Me.PnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMiddle.Location = New System.Drawing.Point(3, 0)
        Me.PnlMiddle.Name = "PnlMiddle"
        Me.PnlMiddle.Size = New System.Drawing.Size(293, 30)
        Me.PnlMiddle.TabIndex = 2
        '
        'PnlRight
        '
        Me.PnlRight.BackColor = System.Drawing.Color.Transparent
        Me.PnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlRight.Location = New System.Drawing.Point(293, 0)
        Me.PnlRight.Name = "PnlRight"
        Me.PnlRight.Size = New System.Drawing.Size(3, 30)
        Me.PnlRight.TabIndex = 1
        '
        'MyLabelExBase
        '
        Me.BackColor = Color.Transparent
        Me.Controls.Add(Me.PnlMiddle)
        Me.Controls.Add(Me.PnlRight)
        Me.Controls.Add(Me.PnlLeft)
        Me.Size = New System.Drawing.Size(296, 30)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overridable Sub SetImages()

    End Sub

    Protected Overridable Sub PnlMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PnlLeft.BackgroundImage = Me.m_AryLeftImage(ImageStatusEx.Over)
        Me.PnlMiddle.BackgroundImage = Me.m_AryMiddleImage(ImageStatusEx.Over)
        Me.PnlRight.BackgroundImage = Me.m_AryRightImage(ImageStatusEx.Over)
    End Sub

    Protected Overridable Sub PnlMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PnlLeft.BackgroundImage = Me.m_AryLeftImage(ImageStatusEx.Normal)
        Me.PnlMiddle.BackgroundImage = Me.m_AryMiddleImage(ImageStatusEx.Normal)
        Me.PnlRight.BackgroundImage = Me.m_AryRightImage(ImageStatusEx.Normal)
    End Sub

    Protected Overridable Sub PnlMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.PnlLeft.BackgroundImage = Me.m_AryLeftImage(ImageStatusEx.Press)
        Me.PnlMiddle.BackgroundImage = Me.m_AryMiddleImage(ImageStatusEx.Press)
        Me.PnlRight.BackgroundImage = Me.m_AryRightImage(ImageStatusEx.Press)
        m_bNeedOffset = True
    End Sub

    Protected Sub PnlMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'if the mouse is above the control, set it as OVER status; otherwise, set it as Normal.
        If Me.Parent Is Nothing Then
            Return 'some times, the control is response the message while its parent form is disposing. 
        End If
        Dim ptUp As System.Drawing.Point = Me.PointToClient(Control.MousePosition)
        Dim rect As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.Size)
        If rect.Contains(ptUp) Then 'own the point
            PnlMouseEnter(Nothing, Nothing)
        Else
            PnlMouseLeave(Nothing, Nothing)
        End If
        m_bNeedOffset = False
    End Sub

    Private Sub pnlClick(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.OnClick(EventArgs.Empty)
    End Sub

    Protected Overridable Sub PnlEnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PnlLeft.Enabled = Me.Enabled
        Me.PnlMiddle.Enabled = Me.Enabled
        Me.PnlRight.Enabled = Me.Enabled
    End Sub

    Private Sub PnlMiddle_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlMiddle.Paint
        ' Create string to draw.
        Dim drawString As [String] = Me.Text
        ' Create font and brush.
        Dim drawFont As Font = Me.Font
        Dim crText As Color = IIf(Me.Enabled, m_crFore, m_crDisableText)
        Dim drawBrush As New SolidBrush(crText)
        Dim nOffset As Integer = 0
        If m_bNeedOffset = True Then
            nOffset = CONST_MOUSEDOWN_OFFSET
        End If
        Dim drawRect As RectangleF = New RectangleF(-Me.PnlMiddle.Location.X + nOffset, Me.PnlMiddle.Location.Y + nOffset + 2, Me.Size.Width, Me.PnlMiddle.Height)

        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat)
    End Sub

    <Browsable(False)> _
    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
        Set(ByVal Value As System.Drawing.Color)
            MyBase.ForeColor = Value
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property TextAlign() As System.Drawing.ContentAlignment
        Get
            Return ContentAlignment.TopCenter
        End Get
        Set(ByVal Value As System.Drawing.ContentAlignment)
            MyBase.TextAlign = Value
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property AutoSize() As Boolean
        Get
            Return False
        End Get
        Set(ByVal Value As Boolean)
            MyBase.AutoSize = Value
        End Set
    End Property

    <CategoryAttribute("Appearance")> _
   Public Property Fore_Color() As System.Drawing.Color
        Get
            Return m_crFore
        End Get
        Set(ByVal Value As System.Drawing.Color)
            m_crFore = Value
        End Set
    End Property
End Class
