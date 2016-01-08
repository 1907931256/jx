Public Class UIFrmInfo
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Property TitleVisable() As Boolean
        Get
            Return Me.lblTitle.Visible
        End Get
        Set(ByVal value As Boolean)
            lblTitle.Visible = value
        End Set
    End Property
    Property TitleText() As String
        Get
            Return Me.lblTitle.Text
        End Get
        Set(ByVal value As String)
            lblTitle.Text = value
        End Set
    End Property
    Private Sub UIFrmInfo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lblTitle.Size = New System.Drawing.Size(129, 23)
        PanelLeftTop.Size = New System.Drawing.Size(7, 7)
        PanelLeftDown.Size = New System.Drawing.Size(7, 7)
        PanelRightTop.Size = New System.Drawing.Size(7, 7)
        PanelRightDown.Size = New System.Drawing.Size(7, 7)
        PanelMidDown.Height = 7
        PanelMidTop.Height = 7
        PanelMidLeft.Width = 7
        PanelMidRight.Width = 7

        PanelBackColor.Top = 0
        PanelBackColor.Left = 0
        PanelBackColor.Height = 11
        PanelBackColor.Width = Me.Width
        PanelLeftTop.Left = 0
        PanelLeftTop.Top = 11
        PanelLeftDown.Left = 0
        PanelLeftDown.Top = Me.Height - PanelLeftDown.Height
        PanelMidLeft.Left = 0
        PanelMidLeft.Top = PanelLeftTop.Height + 11
        PanelMidLeft.Height = Me.Height - PanelLeftTop.Height - 11 - PanelLeftDown.Height
        PanelRightDown.Top = PanelLeftDown.Top
        PanelRightDown.Left = Me.Width - PanelRightDown.Width
        PanelRightTop.Top = PanelLeftTop.Top
        PanelRightTop.Left = PanelRightDown.Left
        PanelMidTop.Top = PanelLeftTop.Top
        PanelMidTop.Left = PanelLeftTop.Width
        PanelMidTop.Width = Me.Width - PanelLeftTop.Width - PanelRightDown.Width
        PanelMidDown.Width = PanelMidTop.Width
        PanelMidDown.Left = PanelMidTop.Left
        PanelMidDown.Top = PanelLeftDown.Top
        PanelMidRight.Top = PanelRightTop.Height + 11
        PanelMidRight.Left = PanelRightTop.Left
        PanelMidRight.Height = PanelMidLeft.Height
        lblTitle.Left = PanelLeftTop.Width + 5
        lblTitle.Top = PanelLeftTop.Top / 2 - 3
    End Sub

    Public Sub RestoreEdge()
        Me.UIFrmInfo_Resize(Me, EventArgs.Empty)
    End Sub
End Class
