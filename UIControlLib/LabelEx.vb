Public Class LabelEx
    Inherits MyLabelExBase

    Private m_AryDisableImage(3) As System.Drawing.Image
    Private m_bKeepClickStatus As Boolean = False
    Private m_bClicked As Boolean = False
    Private m_bNoEffect As Boolean = False

    Public ReadOnly Property KeepClickStatus As Boolean
        Get
            Return m_bKeepClickStatus
        End Get
    End Property

#Region " Component Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.AutoSize = False
        SetImages()
    End Sub

    Public Sub New(ByVal bKeepClickStatus As Boolean)
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.AutoSize = False
        SetImages()
        m_bKeepClickStatus = bKeepClickStatus
    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    Friend WithEvents LblDisableLeft As System.Windows.Forms.Label
    Friend WithEvents LblDisableMiddle As System.Windows.Forms.Label
    Friend WithEvents LblDisableRight As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.LblDisableLeft = New System.Windows.Forms.Label
        Me.LblDisableMiddle = New System.Windows.Forms.Label
        Me.LblDisableRight = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PnlLeft
        '
        Me.PnlLeft.BackgroundImage = Global.UIControlLib.My.Resources.Resources.buttonleft_normal
        '
        'PnlMiddle
        '
        Me.PnlMiddle.BackgroundImage = Global.UIControlLib.My.Resources.Resources.button_mid_normal
        Me.PnlMiddle.Size = New System.Drawing.Size(290, 30)
        '
        'PnlRight
        '
        Me.PnlRight.BackgroundImage = Global.UIControlLib.My.Resources.Resources.button_right_normal
        '
        'LblDisableLeft
        '
        Me.LblDisableLeft.Image = Global.UIControlLib.My.Resources.Resources.button_left
        Me.LblDisableLeft.Location = New System.Drawing.Point(494, 37)
        Me.LblDisableLeft.Name = "LblDisableLeft"
        Me.LblDisableLeft.Size = New System.Drawing.Size(11, 28)
        Me.LblDisableLeft.TabIndex = 0
        '
        'LblDisableMiddle
        '
        Me.LblDisableMiddle.Image = Global.UIControlLib.My.Resources.Resources.button_mid
        Me.LblDisableMiddle.Location = New System.Drawing.Point(615, 37)
        Me.LblDisableMiddle.Name = "LblDisableMiddle"
        Me.LblDisableMiddle.Size = New System.Drawing.Size(11, 28)
        Me.LblDisableMiddle.TabIndex = 0
        '
        'LblDisableRight
        '
        Me.LblDisableRight.Image = Global.UIControlLib.My.Resources.Resources.button_right
        Me.LblDisableRight.Location = New System.Drawing.Point(17, 74)
        Me.LblDisableRight.Name = "LblDisableRight"
        Me.LblDisableRight.Size = New System.Drawing.Size(11, 28)
        Me.LblDisableRight.TabIndex = 0
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public WriteOnly Property NoExtraEffect() As Boolean
        Set(ByVal value As Boolean)
            m_bNoEffect = value
        End Set
    End Property
    Protected Overrides Sub SetImages()
        m_AryLeftImage = New System.Drawing.Image() {My.Resources.buttonleft_normal, My.Resources.button_left_over, My.Resources.button_left_press}
        m_AryMiddleImage = New System.Drawing.Image() {My.Resources.button_mid_normal, My.Resources.button_mid_over, My.Resources.button_mid_press}
        m_AryRightImage = New System.Drawing.Image() {My.Resources.button_right_normal, My.Resources.button_right_over, My.Resources.button_right_press}
        m_AryDisableImage = New System.Drawing.Image() {Me.LblDisableLeft.Image, Me.LblDisableMiddle.Image, Me.LblDisableRight.Image}
    End Sub

    Public Overloads Sub SetImageList(ByVal ImgNormal As System.Drawing.Image(), ByVal ImgOver As System.Drawing.Image(), ByVal ImgPress As System.Drawing.Image())
        m_AryLeftImage = ImgNormal
        m_AryMiddleImage = ImgOver
        m_AryRightImage = ImgPress
        m_AryDisableImage = New System.Drawing.Image() {Me.LblDisableLeft.Image, Me.LblDisableMiddle.Image, Me.LblDisableRight.Image}
    End Sub

    Public Overloads Sub SetImageList(ByVal ImgNormal As System.Drawing.Image, ByVal ImgOver As System.Drawing.Image, ByVal ImgPress As System.Drawing.Image, Optional ByVal ImgDisable As System.Drawing.Image = Nothing)
        Debug.Assert(False)
    End Sub

    Protected Overrides Sub PnlEnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If m_bNoEffect Then
            Return
        End If
        MyBase.PnlEnabledChanged(sender, e)
        If Me.Enabled = False Then
            Me.PnlLeft.BackgroundImage = Me.m_AryDisableImage(0)
            Me.PnlMiddle.BackgroundImage = Me.m_AryDisableImage(1)
            Me.PnlRight.BackgroundImage = Me.m_AryDisableImage(2)
        Else 'reset the image as normal by default.
            Me.PnlMouseLeave(sender, e)
        End If
    End Sub

    Public Sub BtnPerformClick()
        Debug.Assert(m_bKeepClickStatus)
        If Not m_bKeepClickStatus Then
            Return
        End If
        m_bClicked = True
        MyBase.PnlMouseDown(Me, Nothing)
    End Sub

    Public Sub BtnPerformUnClick()
        Debug.Assert(m_bKeepClickStatus)
        If Not m_bKeepClickStatus Then
            Return
        End If
        m_bClicked = False
        MyBase.PnlMouseLeave(Me, Nothing)
    End Sub

    Protected Overrides Sub PnlMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        If (m_bKeepClickStatus AndAlso m_bClicked) OrElse m_bNoEffect Then
        Else
            MyBase.PnlMouseEnter(sender, e)
        End If
    End Sub

    Protected Overrides Sub PnlMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        If (m_bKeepClickStatus AndAlso m_bClicked) OrElse m_bNoEffect Then
        Else
            MyBase.PnlMouseLeave(sender, e)
        End If
    End Sub

    Protected Overrides Sub PnlMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_bKeepClickStatus AndAlso m_bClicked) OrElse m_bNoEffect Then
        Else
            MyBase.PnlMouseDown(sender, e)
        End If
    End Sub
End Class
