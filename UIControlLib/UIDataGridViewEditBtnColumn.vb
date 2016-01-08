Imports System.Windows.Forms
Imports System.Drawing

Public Class UIDataGridViewEditBtnColumn
    Inherits DataGridViewButtonColumn
    'Constructer
    Public Sub New()
        Me.CellTemplate = New UIDataGridViewEditBtnCell()
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            If Not TypeOf value Is UIDataGridViewEditBtnCell Then
                Throw New InvalidCastException()
            End If
            MyBase.CellTemplate = value
        End Set
    End Property

End Class

Public Class UIDataGridViewEditBtnCell
    Inherits DataGridViewButtonCell
    Private m_emImageType As IMAGE_TYPE = IMAGE_TYPE.NORMAL
    Private Const CONST_INT_ICON_INDENT As Integer = 1
    Private Const CONST_INT_ICON_WIDTH As Integer = 18
    Private Const CONST_INT_ICON_HEIGHT As Integer = 18
    Private BUTTONCOLUMN_BACK_COLOR As Color = Color.FromArgb(244, 247, 252)
    Private m_crBackColor As Color = BUTTONCOLUMN_BACK_COLOR

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(Integer)
        End Get
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
        Dim img As Image = My.Resources.Add_normal
        If m_emImageType = IMAGE_TYPE.OVER Then img = My.Resources.Add_over
        If m_emImageType = IMAGE_TYPE.PRESS Then
            img = My.Resources.Add_press
            iIndent = 1
        End If

        If (paintParts And DataGridViewPaintParts.ContentForeground) = _
             DataGridViewPaintParts.ContentForeground Then
            graphics.DrawImage(img, paintRect.Left + CInt((paintRect.Width - CONST_INT_ICON_WIDTH) / 2) + iIndent, paintRect.Top + iIndent + CInt((paintRect.Height - CONST_INT_ICON_HEIGHT) / 2), CONST_INT_ICON_WIDTH, CONST_INT_ICON_HEIGHT)
        End If
    End Sub
End Class
