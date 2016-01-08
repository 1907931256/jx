Imports System.Drawing
Public Class UIHidPanel
    Public Property Title() As String
        Get
            Return m_strTiltle
        End Get
        Set(ByVal value As String)
            m_strTiltle = value
        End Set
    End Property
    Public Property TitleFont() As Font
        Get
            Return m_strTitleFont
        End Get
        Set(ByVal value As Font)
            m_strTitleFont = Font
        End Set
    End Property
    Public Property TitleColor() As Color
        Get
            Return m_crColor
        End Get
        Set(ByVal value As Color)
            m_crColor = value
        End Set
    End Property
    Public Property TitleImage() As Drawing.Image
        Get
            Return plTop.BackgroundImage
        End Get
        Set(ByVal value As Drawing.Image)
            plTop.BackgroundImage = value
        End Set
    End Property
    Public Property HidImage() As Image
        Get
            Return plRight.BackgroundImage
        End Get
        Set(ByVal value As Image)
            plRight.BackgroundImage = value
        End Set
    End Property
    Public Property ControlWidth() As Integer
        Get
            Return m_nWidth
        End Get
        Set(ByVal value As Integer)
            m_nWidth = value
        End Set
    End Property
    Public ReadOnly Property HidWidth() As Integer
        Get
            Return plRight.Width
        End Get
    End Property
    Public ReadOnly Property InitialType() As ITSBase.EnumDef.HID_CONTROL_STYLE
        Get
            Return m_emType
        End Get
    End Property

    Private TEXT_COLOR_MOVE As Color = System.Drawing.Color.Orange
    Private TEXT_COLOR_BACK_COLOR As Color = Color.Transparent
    Private TEXT_COLOR_LEAVE As Color = System.Drawing.Color.White
    Private TEXT_CONST_LENTH As Integer = 32
    Private m_crColor As Color
    Private m_strTitleFont As Font
    Private m_strTiltle As String
    Private m_nLocationRightX As Integer
    Private m_emType As ITSBase.EnumDef.HID_CONTROL_STYLE
    Private m_nWidth As Integer
    Public Event HidControl()
    Public Event ShowControl()
    Public Sub New()
        InitializeComponent()
        Me.BackColor = Color.Transparent
        m_strTitleFont = New Font("SimSun", 12.0!, FontStyle.Bold)
        m_crColor = Color.White
        m_strTiltle = "œÍœ∏–≈œ¢"
        m_emType = ITSBase.EnumDef.HID_CONTROL_STYLE.SHOW
        lblTitle.Text = ""
        lblHid.Text = lblTitle.Text
        ChangeFormStyle()
    End Sub

    Private Sub ChangeFormStyle()
        btnHid.ForeColor = m_crColor
        If m_emType = ITSBase.EnumDef.HID_CONTROL_STYLE.HID Then
            btnHid.Text = "<<"
            plRight.Visible = True
            'lblTitle.Visible = False
            plTop.Visible = False
            Me.Width = plRight.Width + 2
            RaiseEvent HidControl()
        Else
            btnHid.Text = ">>"
            plRight.Visible = False
            'lblTitle.Visible = True
            plTop.Visible = True
            Me.Width = m_nWidth
            RaiseEvent ShowControl()
        End If
    End Sub

    Private Function DrawText(ByVal cr As Color) As Bitmap
        Dim g As Graphics = Nothing
        g = lblTitle.CreateGraphics
        Dim sfTextSize As SizeF = g.MeasureString(m_strTiltle, lblTitle.Font)
        Dim bmpInfo As Bitmap = New Bitmap(CInt(IIf(lblTitle.Width < sfTextSize.Width, sfTextSize.Width, lblTitle.Width)), CInt(IIf(lblTitle.Height < sfTextSize.Height, sfTextSize.Height, lblTitle.Height)), System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim drawBrush As SolidBrush = New SolidBrush(cr)
        g = Graphics.FromImage(bmpInfo)
        g.Clear(Color.Black)
        g.DrawString(m_strTiltle, m_strTitleFont, drawBrush, 2, bmpInfo.Height / 2 - lblTitle.Font.Height / 2 + 2)
        bmpInfo.MakeTransparent()
        Return bmpInfo
    End Function

    Private Function DrawEnterText() As Bitmap
        Dim bmpInfo As Bitmap = DrawText(TEXT_COLOR_MOVE)
        bmpInfo.RotateFlip(RotateFlipType.Rotate270FlipXY)
        Return bmpInfo
    End Function
    Private Function DrawRotateEnterText() As Bitmap
        Dim bmpTextRoate As Bitmap = DrawText(TEXT_COLOR_MOVE)
        bmpTextRoate.RotateFlip(RotateFlipType.Rotate270FlipXY)
        Dim bmpInfo As Bitmap = New Bitmap(bmpTextRoate.Width, bmpTextRoate.Height + 20, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim g As Graphics = lblHid.CreateGraphics
        Dim drawBrush As SolidBrush = New SolidBrush(TEXT_COLOR_MOVE)
        Dim sfTitleFont As Font = btnHid.Font
        g = Graphics.FromImage(bmpInfo)
        g.DrawString("<<", sfTitleFont, drawBrush, 4, 2)
        g.DrawImage(bmpTextRoate, 0, 20)
        bmpInfo.MakeTransparent()
        Return bmpInfo
    End Function
    Private Function DrawRotateText() As Bitmap
        Dim bmpTextRoate As Bitmap = DrawText(m_crColor)
        bmpTextRoate.RotateFlip(RotateFlipType.Rotate270FlipXY)
        Dim bmpInfo As Bitmap = New Bitmap(bmpTextRoate.Width, bmpTextRoate.Height + 20, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim g As Graphics = lblHid.CreateGraphics
        Dim drawBrush As SolidBrush = New SolidBrush(m_crColor)
        Dim sfTitleFont As Font = btnHid.Font
        g = Graphics.FromImage(bmpInfo)
        g.DrawString("<<", sfTitleFont, drawBrush, 4, 2)
        g.DrawImage(bmpTextRoate, 0, 20)
        bmpInfo.MakeTransparent()
        Return bmpInfo
    End Function

    Private Sub OnHidPanelResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        OnResizeDrawText()
    End Sub

    Public Sub OnResizeDrawText()
        lblTitle.Image = DrawText(m_crColor)
        lblHid.Image = DrawRotateText()
    End Sub
    Public Sub OnHid()
        m_emType = ITSBase.EnumDef.HID_CONTROL_STYLE.HID
        ChangeFormStyle()
    End Sub
    Private Sub OnbtnHidClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHid.Click
        If m_emType = ITSBase.EnumDef.HID_CONTROL_STYLE.HID Then
            m_emType = ITSBase.EnumDef.HID_CONTROL_STYLE.SHOW
        Else
            m_emType = ITSBase.EnumDef.HID_CONTROL_STYLE.HID
        End If
        ChangeFormStyle()
    End Sub

    Private Sub OnbtnHidMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHid.MouseEnter
        btnHid.ForeColor = TEXT_COLOR_MOVE
    End Sub

    Private Sub OnbtnHidMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHid.MouseLeave
        btnHid.ForeColor = TEXT_COLOR_LEAVE
    End Sub

    Private Sub OnlblHidClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHid.Click
        m_emType = ITSBase.EnumDef.HID_CONTROL_STYLE.SHOW
        ChangeFormStyle()
    End Sub

    Private Sub OnlblHidMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHid.MouseEnter
        lblHid.Image = DrawRotateEnterText()
    End Sub

    Private Sub OnlblHidMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHid.MouseLeave
        lblHid.Image = DrawRotateText()
    End Sub

#Region "Child Control Resize"
    Private Sub OnplRightResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles plRight.Resize
        plRight.Width = TEXT_CONST_LENTH
    End Sub

    Private Sub OnplTopResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles plTop.Resize
        plTop.Height = TEXT_CONST_LENTH
    End Sub

    Private Sub OnbtnHidResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHid.Resize
        btnHid.Width = TEXT_CONST_LENTH
    End Sub
#End Region

End Class
