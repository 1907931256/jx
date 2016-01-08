Imports System.Drawing
Imports System.ComponentModel
Imports ITSBase

Public Class UITraceInfoPanel
#Region "member variable"
    Private CONST_INTEGER_CONTEXT_MARGIN As Integer = 3
    Private CONST_INTEGER_LINE_SPACING As Integer = 11
    Private CONST_FONT_CONTEXT As Font = New Font("SimSun", 12.0!)
    Private m_crTitleFore As Color
    Private m_crTitleText As String
    Private m_crTitleFont As Font
    Private m_crTitleTextAlign As ContentAlignment
    Private m_ht As Hashtable
    Private m_szContent As String
    Private m_szItems() As String
    Private m_szCycleItems() As String
#End Region

#Region "property"
    Public WriteOnly Property ContentInfo() As Hashtable
        Set(ByVal value As Hashtable)
            m_ht = value
            AfterSetInfo()
            pnlContext.Refresh()
        End Set
    End Property

    Public WriteOnly Property DisplayItems() As String()
        Set(ByVal value As String())
            m_szItems = value
        End Set
    End Property
    Public WriteOnly Property CycleDisplayItems() As String()
        Set(ByVal value As String())
            m_szCycleItems = value
        End Set
    End Property
    '*****************TITLE RELATED**********************
    <CategoryAttribute("Title")> _
    Public Property TitleForeColor() As System.Drawing.Color
        Get
            Return m_crTitleFore
        End Get
        Set(ByVal Value As System.Drawing.Color)
            m_crTitleFore = Value
            pnlHeadMid.Refresh()
        End Set
    End Property

    <CategoryAttribute("Title")> _
    Public Property TitleText() As String
        Get
            Return m_crTitleText
        End Get
        Set(ByVal Value As String)
            m_crTitleText = Value
            pnlHeadMid.Refresh()
        End Set
    End Property

    <CategoryAttribute("Title")> _
    Public Property TitleFont() As Font
        Get
            Return m_crTitleFont
        End Get
        Set(ByVal Value As Font)
            m_crTitleFont = Value
            pnlHeadMid.Refresh()
        End Set
    End Property

    '****************************************************
#End Region

#Region "Method"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_crTitleFore = System.Drawing.SystemColors.ControlText
        m_crTitleText = ""
        m_crTitleFont = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        m_crTitleTextAlign = ContentAlignment.BottomCenter
        Clear()
        Me.picPre.SetImageList(My.Resources.pre_normal, My.Resources.pre_over, My.Resources.pre_press)
        Me.picNext.SetImageList(My.Resources.next_normal, My.Resources.next_over, My.Resources.next_press)
    End Sub

    Private Sub OnHeadMidPanelPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlHeadMid.Paint
        ' Create string to draw.
        Dim drawString As [String] = m_crTitleText
        ' Create font and brush.
        Dim drawBrush As New SolidBrush(m_crTitleFore)
        Dim drawRect As New RectangleF(0, 0, pnlHeadMid.Width, pnlHeadMid.Height)
        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Far
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        e.Graphics.DrawString(drawString, m_crTitleFont, drawBrush, drawRect, drawFormat)
    End Sub

    Private Sub AfterSetInfo()
        'reset the status
        Me.pnlContext.AutoScroll = False
        Me.pnlContext.AutoScrollMinSize = New Size(0, 0)
        Me.picPre.Visible = False
        Me.picNext.Visible = False
        m_szContent = ""
        'calculate the height of the all the text
        Dim nTotalHeight As Integer = m_ht.Count * (CONST_FONT_CONTEXT.Height + CONST_INTEGER_LINE_SPACING)
        If (nTotalHeight > Me.pnlContext.Height) Then
            Me.picPre.Visible = True
            Me.picNext.Visible = True
        End If
        Me.pnlContext.AutoScroll = True
        Me.pnlContext.AutoScrollMinSize = New Size(0, nTotalHeight)
        Me.pnlContext.AutoScroll = False
    End Sub

    Public Sub Clear()
        m_ht = New Hashtable
        m_szContent = ""
        Me.picPre.Visible = False
        Me.picNext.Visible = False
        Me.Refresh()
    End Sub
#End Region

    Private Sub pnlContextPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlContext.Paint
        If m_ht Is Nothing OrElse m_ht.Count <= 0 Then
            Return
        End If
        Dim nStartPos As Integer = CONST_INTEGER_LINE_SPACING + Me.pnlContext.AutoScrollPosition.Y
        'Draw Display Items
        For Each str As String In m_szItems
            If m_ht.Contains(str) Then
                Dim strItem As String = str + ": " + m_ht.Item(str).ToString
                e.Graphics.DrawString(strItem, GetDisplayFont(strItem), GetDisplayBrush(strItem), CONST_INTEGER_CONTEXT_MARGIN, nStartPos, GetDisplayFormat(strItem))
                nStartPos += CONST_FONT_CONTEXT.Height + CONST_INTEGER_LINE_SPACING
            End If
        Next

        If m_szCycleItems Is Nothing Then Exit Sub

        'Draw Cycle Display Items
        Dim bContinue As Boolean = True
        Dim nIndex As Integer = 1
        While bContinue
            bContinue = False
            For Each str As String In m_szCycleItems
                Dim strKey As String = str & nIndex.ToString
                If m_ht.Contains(strKey) Then
                    Dim strItem As String = str + ": " + m_ht.Item(strKey).ToString
                    e.Graphics.DrawString(strItem, GetDisplayFont(strItem), GetDisplayBrush(strItem), CONST_INTEGER_CONTEXT_MARGIN, nStartPos, GetDisplayFormat(strItem))
                    nStartPos += CONST_FONT_CONTEXT.Height + CONST_INTEGER_LINE_SPACING
                    bContinue = True
                End If
            Next

            nIndex += 1
        End While
    End Sub

    Private Function GetDisplayFont(ByVal strItem As String) As Font
        Return CONST_FONT_CONTEXT
    End Function

    Private Function GetDisplayBrush(ByVal strItem As String) As SolidBrush
        Return New SolidBrush(System.Drawing.SystemColors.ControlText)
    End Function

    Private Function GetDisplayFormat(ByVal strItem As String) As StringFormat
        Return New StringFormat
    End Function


    Private Sub picNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picNext.Click
        Me.pnlContext.AutoScrollPosition = New Size(0, -Me.pnlContext.AutoScrollPosition.Y + CONST_FONT_CONTEXT.Height + CONST_INTEGER_LINE_SPACING)
        pnlContext.Refresh()
    End Sub

    Private Sub picPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPre.Click
        Me.pnlContext.AutoScrollPosition = New Size(0, -Me.pnlContext.AutoScrollPosition.Y - CONST_FONT_CONTEXT.Height - CONST_INTEGER_LINE_SPACING)
        pnlContext.Refresh()
    End Sub

    Private Sub UITraceInfoPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.picNext.Size = New Size(20, 20)
        Me.picPre.Size = New Size(20, 20)
        Me.picNext.Location = New Point(Me.Width - 3 - Me.picNext.Width, Me.Height - 3 - Me.picNext.Height)
        Me.picPre.Location = New Point(Me.picNext.Left - 1 - Me.picPre.Width, Me.Height - 3 - Me.picPre.Height)
    End Sub

End Class
