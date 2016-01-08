Imports System.Windows.Forms
Imports System.Drawing

Public Class UIDataGridViewImgColumn
    Inherits DataGridViewButtonColumn
    'Constructer
    Public Sub New()
        Me.CellTemplate = New UIDataGridViewImgCell()
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            If Not TypeOf value Is UIDataGridViewImgCell Then
                Throw New InvalidCastException()
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Enum IMAGE_LIST
    NULL
    image_add
    image_add_over
    image_add_press
    image_delete
    image_delete_over
    image_delete_press
    image_edit
    image_edit_over
    image_edit_press
    image_normal
    image_normal_over
    image_normal_press
End Enum


Public Class UIDataGridViewImgCell
    Inherits DataGridViewButtonCell
    Private m_emImageType As IMAGE_TYPE = IMAGE_TYPE.NORMAL
    Private m_emImageList As IMAGE_TYPE = IMAGE_LIST.NULL
    Private Const CONST_INT_ICON_INDENT As Integer = 1
    Private Const CONST_INT_ICON_WIDTH As Integer = 18
    Private Const CONST_INT_ICON_HEIGHT As Integer = 18
    Private BUTTONCOLUMN_BACK_COLOR As Color = Color.FromArgb(244, 247, 252)
    Private m_crBackColor As Color = BUTTONCOLUMN_BACK_COLOR

    Private m_OriImage As Image = Nothing
    Private m_OverImage As Image = Nothing
    Private m_PressImage As Image = Nothing
    Private m_DisableImage As Image = Nothing

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(Integer)
        End Get
    End Property

    Public Property ImageList() As IMAGE_LIST
        Get
            Return m_emImageType
        End Get
        Set(ByVal value As IMAGE_LIST)
            m_emImageType = value
        End Set
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return 0
        End Get
    End Property

    Public WriteOnly Property ImageType() As IMAGE_TYPE
        Set(ByVal value As IMAGE_TYPE)
            m_emImageType = value
        End Set
    End Property

    Public WriteOnly Property BackColor() As Color
        Set(ByVal value As Color)
            m_crBackColor = value
        End Set
    End Property

    Public Overridable Sub SetImageList(ByVal ImgNormal As IMAGE_LIST, ByVal ImgOver As IMAGE_LIST, ByVal ImgPress As IMAGE_LIST, Optional ByVal ImgDisable As IMAGE_LIST = Nothing)
        m_OriImage = My.Resources.ResourceManager.GetObject(ImgNormal.ToString, My.Resources.Culture)
        m_OverImage = My.Resources.ResourceManager.GetObject(ImgOver.ToString, My.Resources.Culture)
        m_PressImage = My.Resources.ResourceManager.GetObject(ImgPress.ToString, My.Resources.Culture)
        If ImgDisable <> IMAGE_LIST.NULL Then
            m_DisableImage = My.Resources.ResourceManager.GetObject(ImgDisable.ToString, My.Resources.Culture)
        End If
    End Sub

    Public Overridable Sub SetImageList(ByVal ImgNormal As System.Drawing.Image, ByVal ImgOver As System.Drawing.Image, ByVal ImgPress As System.Drawing.Image, Optional ByVal ImgDisable As System.Drawing.Image = Nothing)
        m_OriImage = ImgNormal
        m_OverImage = ImgOver
        m_PressImage = ImgPress
        If Not ImgDisable Is Nothing Then
            m_DisableImage = ImgDisable
        End If
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As Graphics, _
            ByVal clipBounds As Rectangle, _
            ByVal cellBounds As Rectangle, _
            ByVal rowIndex As Integer, _
            ByVal cellState As DataGridViewElementStates, _
            ByVal value As Object, _
            ByVal formattedValue As Object, _
            ByVal errorText As String, _
            ByVal cellStyle As DataGridViewCellStyle, _
            ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
            ByVal paintParts As DataGridViewPaintParts)

        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

        ''get the bounds
        Dim borderRect As Rectangle = Me.BorderWidths(advancedBorderStyle)
        Dim paintRect As New Rectangle(cellBounds.Left + borderRect.Left, _
            cellBounds.Top + borderRect.Top, _
            cellBounds.Width - borderRect.Right, _
            cellBounds.Height - borderRect.Bottom)
        graphics.FillRectangle(New SolidBrush(m_crBackColor), paintRect)

        Dim iIndent As Integer = 0
        Dim img As Image = m_OriImage
        If m_emImageType = IMAGE_TYPE.OVER Then img = m_OverImage
        If m_emImageType = IMAGE_TYPE.PRESS Then
            img = m_PressImage
            iIndent = 1
        End If

        If (paintParts And DataGridViewPaintParts.ContentForeground) = _
             DataGridViewPaintParts.ContentForeground Then
            If img Is Nothing Then
                Return
            End If
            graphics.DrawImage(img, paintRect.Left + CInt((paintRect.Width - CONST_INT_ICON_WIDTH) / 2) + iIndent, paintRect.Top + iIndent + CInt((paintRect.Height - CONST_INT_ICON_HEIGHT) / 2), CONST_INT_ICON_WIDTH, CONST_INT_ICON_HEIGHT)
        End If
    End Sub
End Class