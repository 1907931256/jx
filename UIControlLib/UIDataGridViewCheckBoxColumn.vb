Imports System.Windows.Forms
Imports System.Drawing

Public Class UIDataGridViewCheckBoxColumn
    Inherits DataGridViewCheckBoxColumn

    Public Sub New()
        Me.CellTemplate = New UIDataGridViewCheckBoxCell()
    End Sub
End Class

Public Class UIDataGridViewCheckBoxCell
    Inherits DataGridViewCheckBoxCell
    Private BUTTONCOLUMN_BACK_COLOR As Color = Color.FromArgb(244, 247, 252)
    Private m_crBackColor As Color = BUTTONCOLUMN_BACK_COLOR
    Private m_bformattedValue As Boolean = False
    Public WriteOnly Property BackColor() As Color
        Set(ByVal value As Color)
            m_crBackColor = value
        End Set
    End Property
    Public WriteOnly Property FormatValue() As Boolean
        Set(ByVal value As Boolean)
            m_bformattedValue = value
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

        cellStyle.SelectionBackColor = m_crBackColor

        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
    End Sub

End Class
