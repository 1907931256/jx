'the class acts as a label whose backcolor will change
'when it is clicked. It's somehow like the labelEx. 
'Fpf, 2009-08-27.

Imports System.Windows.Forms
Imports System.Drawing

Public Class ColorLabel
    Private m_BindingCtrl As Control
    Const strNamePrefix As String = "MedITSDynamicCreateColorLabel"
    Private Shared nSeq As Integer = 0
    Private m_bOnPerform As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Name = strNamePrefix + nSeq.ToString
        Me.BackColor = System.Drawing.Color.Transparent
        Me.TextAlign = Drawing.ContentAlignment.MiddleCenter
        Me.AutoSize = False
        nSeq += 1
        Dim pnls As Panel() = {Me.pnlLeft, Me.pnlMid, Me.pnlRight}
        For Each pnl As Panel In pnls
            AddHandler pnl.Click, AddressOf OnPnlClick
        Next
    End Sub

    Public Sub PerformClick()
        Me.pnlLeft.BackgroundImage = My.Resources.listtitle_left
        Me.pnlMid.BackgroundImage = My.Resources.listtitle_mid
        Me.pnlRight.BackgroundImage = My.Resources.listtitle_right
        m_bOnPerform = True
    End Sub

    Public Sub PerformUnClick()
        Me.pnlLeft.BackgroundImage = My.Resources.listtitleB_left
        Me.pnlMid.BackgroundImage = My.Resources.listtitleB_mid
        Me.pnlRight.BackgroundImage = My.Resources.listtitleB_right
        m_bOnPerform = False
    End Sub

    Public Property BindingCtrl() As Control
        Get
            Return m_BindingCtrl
        End Get
        Set(ByVal value As Control)
            m_BindingCtrl = value
        End Set
    End Property

    Public ReadOnly Property OnPerform() As Boolean
        Get
            Return m_bOnPerform
        End Get
    End Property

    Private Sub PnlMiddle_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlMid.Paint
        ' Create string to draw.
        Dim drawString As [String] = Me.Text
        ' Create font and brush.
        Dim drawFont As Font = Me.Font
        Dim drawBrush As New SolidBrush(Color.Blue)
        Dim nOffset As Integer = IIf(m_bOnPerform, 1, 0)
        Dim drawRect As RectangleF = New RectangleF(-Me.pnlMid.Location.X + nOffset, Me.pnlMid.Location.Y + nOffset + 2, Me.Size.Width, Me.pnlMid.Height)

        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat)
    End Sub

    Private Sub OnPnlClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Focus() 'as the pnl will not get the focus as soon as it is clicked like btn,so here complusive set it
        MyBase.OnClick(EventArgs.Empty)
    End Sub
End Class
