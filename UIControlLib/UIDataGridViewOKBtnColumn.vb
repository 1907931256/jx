Imports System.Windows.Forms
Imports System.Drawing

Public Class UIDataGridViewOKBtnColumn
    Inherits DataGridViewButtonColumn

    Public Sub New()
        Me.CellTemplate = New UIDataGridViewOKBtnCell
    End Sub

    Public Overrides Property CellTemplate() As System.Windows.Forms.DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridViewCell)
            If Not TypeOf value Is UIDataGridViewOKBtnCell Then
                Throw New InvalidCastException()
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class UIDataGridViewOKBtnCell
    Inherits DataGridViewButtonCell

    Private m_strText As String
    Private m_crBackColor As Color = Color.FromArgb(244, 247, 252)
    Private m_imgBack As Image
    Private m_emImageType As IMAGE_TYPE = IMAGE_TYPE.NORMAL

    Private Const CONST_INT_X_SPACE As Integer = 10
    Private Const CONST_INT_Y_SPACE As Integer = 2
    Private Const CONST_INT_BTN_HEIGHT As Integer = 18
    Private Const CONST_INT_BTN_WiDTH As Integer = 50
    Private Const CONST_INT_FONT_SIZE As Integer = 10.0!

    Public Sub New()
        MyBase.new()
        m_strText = String.Empty
        m_imgBack = My.Resources.btnNormal_50
    End Sub

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(String)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return String.Empty
        End Get
    End Property

    Public WriteOnly Property BackColor() As Color
        Set(ByVal value As Color)
            m_crBackColor = value
        End Set
    End Property
    Property ImageType() As IMAGE_TYPE
        Get
            Return m_emImageType
        End Get
        Set(ByVal value As IMAGE_TYPE)
            m_emImageType = value
        End Set
    End Property

    'Protected Overrides Sub OnMouseLeave(ByVal rowIndex As Integer)
    '    m_imgBack = My.Resources.btnNormal_125
    'End Sub
    'Protected Overrides Sub OnMouseEnter(ByVal rowIndex As Integer)
    '    m_imgBack = My.Resources.btnOver_125
    'End Sub
    'Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    m_imgBack = My.Resources.btnPress_125
    'End Sub

    Private Sub SetImage()
        Select Case m_emImageType
            Case IMAGE_TYPE.NORMAL
                m_imgBack = My.Resources.btnNormal_50
            Case IMAGE_TYPE.OVER
                m_imgBack = My.Resources.btnOver_50
            Case IMAGE_TYPE.PRESS
                m_imgBack = My.Resources.btnOver_50
        End Select
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As System.Drawing.Graphics, _
                                  ByVal clipBounds As System.Drawing.Rectangle, _
                                  ByVal cellBounds As System.Drawing.Rectangle, _
                                  ByVal rowIndex As Integer, _
                                  ByVal elementState As System.Windows.Forms.DataGridViewElementStates, _
                                  ByVal value As Object, _
                                  ByVal formattedValue As Object, _
                                  ByVal errorText As String, _
                                  ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, _
                                  ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, _
                                  ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

        Dim borderRect As Rectangle = Me.BorderWidths(advancedBorderStyle)
        Dim paintRect As New Rectangle(cellBounds.Left + borderRect.Left, _
            cellBounds.Top + borderRect.Top, _
            cellBounds.Width - borderRect.Right, _
            cellBounds.Height - borderRect.Bottom)
        graphics.FillRectangle(New SolidBrush(m_crBackColor), paintRect)

        If CStr(value) = String.Empty Then
            Exit Sub
        End If

        Dim strText As String = CStr(value)
        Dim nTextWidth As Integer = strText.Length * (CONST_INT_FONT_SIZE + 4)

        Dim nMiddleX As Integer = paintRect.Left + paintRect.Width / 2
        Dim nMiddleY As Integer = paintRect.Top + paintRect.Height / 2

        If (paintParts And DataGridViewPaintParts.ContentBackground) = _
            DataGridViewPaintParts.ContentBackground Then
            SetImage()
            graphics.DrawImage(m_imgBack, _
                               nMiddleX - CONST_INT_BTN_WiDTH \ 2, _
                               nMiddleY - CONST_INT_BTN_HEIGHT \ 2, _
                               CONST_INT_BTN_WiDTH, CONST_INT_BTN_HEIGHT)
        End If

        If (paintParts And DataGridViewPaintParts.ContentForeground) = _
           DataGridViewPaintParts.ContentForeground Then
            Dim nIndex As Integer = 0
            If m_emImageType = IMAGE_TYPE.PRESS Then
                nIndex += 1
            End If
            graphics.DrawString(strText, New Font("SimSun", CONST_INT_FONT_SIZE), New SolidBrush(Color.Black), nMiddleX - nTextWidth \ 2 + nIndex, nMiddleY - CONST_INT_FONT_SIZE \ 2 - 1 + nIndex)
        End If
    End Sub
End Class
