Imports System.Windows.Forms
Imports ITSBase
Public Class UIChineseCodeLoad
    Inherits UIDropDownList
    Private m_nCodeIndex As Integer
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_nCodeIndex = 0
    End Sub
    Private Sub UserCtrlDropDown_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If MyBase.Focused Then
            ShowFilteredData(False)
            MyBase.Focus()
        End If
    End Sub

    Public Property CodeIndex() As Integer
        Get
            Return m_nCodeIndex
        End Get
        Set(ByVal value As Integer)
            m_nCodeIndex = value
        End Set
    End Property
    Public ReadOnly Property CurrentRow() As DataRow
        Get
            If CheckInputValid() Then
                Return CurrentSelectedRow
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Function CheckInputValid() As Boolean
        Dim strText = MyBase.Text
        If Not strText.Equals("") Then
            Dim dvIntermediate As New DataView(m_dtblSource)
            dvIntermediate.RowFilter = String.Format("{0} = '{1}'", m_dtblSource.Columns(m_nDisplayIndex).ColumnName, strText)
            If m_dgvDropDown.Visible = True Then
                If CType(m_dgvDropDown.DataSource, DataTable).Rows.Count > 1 Then Return False
                Dim dr As DataRow = CType(m_dgvDropDown.DataSource, DataTable).Rows(0)
                If dr IsNot CurrentSelectedRow Then
                    Return False
                End If
            Else
                Return False
            End If
        End If
        Return True
    End Function

    Protected Overrides Sub ShowDropDown()
        m_dgvDropDown.Visible = True
        m_frmShow.Visible = True
        DropDownBeShowing = True
    End Sub
    Private Sub ShowFilteredData(Optional ByVal bShowAllData As Boolean = False)

        If m_dtblSource.Rows.Count = 0 Then
            HideDropDown()
            Exit Sub
        End If


        Dim strtxt As String = MyBase.Text.ToString
        Dim dvIntermediate As New DataView(m_dtblSource)
        Dim nRowsShow As Integer = m_nVisibleRowCount
        Dim bHorizonScrollBar As Boolean = False
        strtxt = MakeSQLLIKEPattern(strtxt)

        If Not bShowAllData Then
            If (strtxt = "" Or strtxt Is Nothing) Then
                HideDropDown()
                Return
            End If
        Else
            strtxt = ""
        End If


        With dvIntermediate
            .AllowNew = False
            If dvIntermediate.Table.Columns.Count > 0 Then
                If m_dtblSource.Columns(m_nCodeIndex).DataType Is strtxt.GetType() AndAlso m_dtblSource.Columns(m_nIDIndex).DataType Is strtxt.GetType() Then
                    .RowFilter = String.Format("{0} like '{1}%' or {2} like '{3}%'", m_dtblSource.Columns(m_nCodeIndex).ColumnName, strtxt, m_dtblSource.Columns(m_nIDIndex).ColumnName, strtxt)
                ElseIf m_dtblSource.Columns(m_nCodeIndex).DataType Is strtxt.GetType() Then
                    .RowFilter = String.Format("{0} like '{1}%' ", m_dtblSource.Columns(m_nCodeIndex).ColumnName, strtxt)
                ElseIf m_dtblSource.Columns(m_nIDIndex).DataType Is strtxt.GetType() Then
                    .RowFilter = String.Format("{0} like '{1}%' ", m_dtblSource.Columns(m_nIDIndex).ColumnName, strtxt)
                End If
            End If
        End With
        '指定列宽，如果给定的列宽数组元素个数比数据源列数少，则不处理
        If Not m_ArrColWidth Is Nothing AndAlso Not m_ArrColWidth.Length < m_dtblSource.Columns.Count Then
            Dim nColumnWholeWidth As Integer = 0
            For Each nWidth As Integer In m_ArrColWidth
                nColumnWholeWidth += nWidth
            Next
            '根据各列宽，设定DataGridView总宽度
            m_dgvDropDown.RealColumnWidthCollection = m_ArrColWidth
            m_dgvDropDown.Width = nColumnWholeWidth
        End If


        '指定数据源，根据UIDataGridView的设计，指定数据源要放在设定列宽后边，列宽才能生效
        m_dgvDropDown.DataSource = dvIntermediate.ToTable

        '指定一次要显示的行数
        If (dvIntermediate.Count > m_nVisibleRowCount) Then
            nRowsShow = m_nVisibleRowCount
        Else
            nRowsShow = dvIntermediate.Count
        End If

        '设定DataGridView和Form的位置和size
        If (dvIntermediate.Count > 0) Then
            Dim ptPoint As Drawing.Point = m_ptPosition
            ptPoint = PointToScreen(ptPoint)
            '防止窗体右边界超出。
            If m_nOnLeft = SNAP_MODE.OnLeft Then
                If ptPoint.X + m_dgvDropDown.Width > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    'm_dgvDropDown.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - ptPoint.X - 2
                    'bHorizonScrollBar = True
                    ptPoint.X = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - m_dgvDropDown.Width - 2
                End If
                '防止窗体左边界超出。
            Else
                ptPoint.X = ptPoint.X + Me.Width - m_dgvDropDown.Width
                If ptPoint.X <= 0 Then
                    'm_dgvDropDown.Width = PointToScreen(m_ptPosition).X + Me.Width - 2
                    ptPoint.X = 2
                    'bHorizonScrollBar = True
                End If
            End If
            '设定DataGridView高度
            If m_dgvDropDown.Rows.Count > 0 Then
                m_dgvDropDown.Height = m_dgvDropDown.Rows(0).Height * nRowsShow + System.Windows.Forms.SystemInformation.BorderSize.Width * 2
                If bHorizonScrollBar Then
                    m_dgvDropDown.Height += System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight
                End If
            Else
                m_dgvDropDown.Height = 0
            End If

            '设定窗体size
            With m_frmShow
                .Size = m_dgvDropDown.Size
                .Location = ptPoint
            End With

            ShowDropDown()
            m_dgvDropDown.ClearSelection()
            m_frmShow.Show()
        Else
            HideDropDown()
        End If

    End Sub
End Class
