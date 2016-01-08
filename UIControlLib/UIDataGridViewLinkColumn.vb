Imports System.Windows.Forms
Imports System.Drawing

Public Class UIDataGridViewLinkColumn
    Inherits DataGridViewLinkColumn
    'Constructer
    Public Sub New()
        Me.CellTemplate = New UIDataGridViewLinkCell()
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            If Not TypeOf value Is UIDataGridViewLinkCell Then
                Throw New InvalidCastException()
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class UIDataGridViewLinkCell
    Inherits DataGridViewLinkCell
    Private Const CONST_INT_ICON_INDENT As Integer = 1
    Private Const CONST_INT_ICON_WIDTH As Integer = 18
    Private Const CONST_INT_ICON_HEIGHT As Integer = 18
    Private BUTTONCOLUMN_BACK_COLOR As Color = Color.FromArgb(244, 247, 252)
    Private m_crBackColor As Color = BUTTONCOLUMN_BACK_COLOR

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

        ''get the bounds
        Dim borderRect As Rectangle = Me.BorderWidths(advancedBorderStyle)
        Dim paintRect As New Rectangle(cellBounds.Left + borderRect.Left, _
            cellBounds.Top + borderRect.Top, _
            cellBounds.Width - borderRect.Right, _
            cellBounds.Height - borderRect.Bottom)
        graphics.FillRectangle(New SolidBrush(m_crBackColor), paintRect)
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
    End Sub
End Class