Imports System.Windows.Forms
Imports System.Drawing
'The Class ResizeAlgorithm, which is aimed to stretch controls 
'while its parenet window is flating or deflating,is published  
'on 2009.06.30, for the sake of that avoiding the case that the 
'controls keep its layout the same. 
'There are two important points when using:
'1. when calculating the stretch ratio, make sure to avoid the
'   case of division by zero
'2. To reduce the gaps of converting float to int, record the original
'   layout when register the ctrl, each time, compare with to 
'   original ones, but not the pre ones.
Public Class ResizeAlgorithm

    Private Class CtrlLayout
        Private x As Integer = 0
        Private y As Integer = 0
        Private width As Integer = 0
        Private height As Integer = 0
        Private font_size As Single = 0
        Private captain_size As Single = 0
        Private header_size As Single = 0

        Public Property Location() As System.Drawing.Point
            Get
                Return New System.Drawing.Point(x, y)
            End Get
            Set(ByVal value As System.Drawing.Point)
                x = value.X
                y = value.Y
            End Set
        End Property

        Public Property Size() As System.Drawing.Size
            Get
                Return New System.Drawing.Size(width, height)
            End Get
            Set(ByVal value As System.Drawing.Size)
                width = value.Width
                height = value.Height
            End Set
        End Property

        Public Property FontSize() As Single
            Get
                Return font_size
            End Get
            Set(ByVal value As Single)
                font_size = value
            End Set
        End Property

        Public Property CaptainSize() As Single
            Get
                Return captain_size
            End Get
            Set(ByVal value As Single)
                captain_size = value
            End Set
        End Property

        Public Property HeaderSize() As Single
            Get
                Return header_size
            End Get
            Set(ByVal value As Single)
                header_size = value
            End Set
        End Property
    End Class

    Private Shared m_Instance As ResizeAlgorithm = Nothing
    Private Shared m_CtrlHashTable As New System.Collections.Hashtable
    Private Sub New()

    End Sub

    'implement singleton 
    Public Shared Function GetInstanse() As ResizeAlgorithm
        If m_Instance Is Nothing Then
            m_Instance = New ResizeAlgorithm()
        End If
        Return m_Instance
    End Function

    Public Function RegisterCtrlResize(ByVal ctrl As System.Windows.Forms.Control) As Boolean
        If m_Instance Is Nothing OrElse m_CtrlHashTable Is Nothing Then
            Return False
        End If
        If m_CtrlHashTable.ContainsKey(ctrl) Then
            Return False
        End If
        'record the original layout to avoid the calculation gaps, Important Point Two
        Dim htCtrlLayout As New Hashtable
        GetCtrlOriginalLayout(ctrl, htCtrlLayout)
        m_CtrlHashTable.Add(ctrl, htCtrlLayout)
        AddHandler ctrl.Resize, AddressOf CtrlResizeDelegate
        Return True
    End Function

    Private Sub GetCtrlOriginalLayout(ByVal ctrl As Control, ByVal htCtrlLayout As Hashtable)
        Dim OriLayout As New CtrlLayout
        OriLayout.Location = ctrl.Location
        OriLayout.Size = ctrl.Size
        OriLayout.FontSize = ctrl.Font.Size
        If ctrl.GetType() Is GetType(UIDataGridView) Then 'if it is a datagridview, then record all the column font.
            CType(ctrl, UIDataGridView).ResizeRegister()
        End If

        htCtrlLayout.Add(ctrl, OriLayout)

        'below process the child controls
        If IsIngoreChildResize(ctrl) Then
            Exit Sub
        End If
        If ctrl.Controls.Count > 0 Then 'has children controls
            For Each child As Control In ctrl.Controls
                GetCtrlOriginalLayout(child, htCtrlLayout)
            Next
        End If
    End Sub

    Public Function UnRegisterCtrlResize(ByVal ctrl As System.Windows.Forms.Control) As Boolean
        If m_Instance Is Nothing OrElse m_CtrlHashTable Is Nothing Then
            Return False
        End If
        If m_CtrlHashTable.ContainsKey(ctrl) Then
            m_CtrlHashTable.Remove(ctrl)
            RemoveHandler ctrl.Resize, AddressOf CtrlResizeDelegate
        End If
        Return True
    End Function

    Private Sub CtrlResizeDelegate(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ctrl As Control = CType(sender, Control)
        If m_CtrlHashTable.ContainsKey(ctrl) = False Then
            Return
        End If
        Dim ctrlOldLayout As CtrlLayout = m_CtrlHashTable.Item(ctrl).Item(ctrl)
        'the Desigenr will ensure that the width and height will be > 10, Important Point One
        Dim dXScale As Double = ctrl.Size.Width / ctrlOldLayout.Size.Width
        Dim dYScale As Double = ctrl.Size.Height / ctrlOldLayout.Size.Height
        ResizeCtrl(ctrl, m_CtrlHashTable.Item(ctrl), dXScale, dYScale, False)
    End Sub

    Private Sub ResizeCtrl(ByVal ctrl As Control, ByVal htOriLayout As Hashtable, ByVal dXScale As Double, _
                           ByVal dyScale As Double, Optional ByVal bIncludeSelf As Boolean = True)
        If dXScale <= 0.0 OrElse dyScale <= 0.0 Then
            Return
        End If

        Dim ctrlOriLayout As CtrlLayout = htOriLayout.Item(ctrl)
        If bIncludeSelf AndAlso ctrlOriLayout IsNot Nothing Then
            ctrl.Location = New Point(ctrlOriLayout.Location.X * dXScale, ctrlOriLayout.Location.Y * dyScale)
            'ctrl.Font = New Font(ctrl.Font.FontFamily, ctrlOriLayout.FontSize * dyScale, ctrl.Font.Style, ctrl.Font.Unit, _
            '                     ctrl.Font.GdiCharSet, ctrl.Font.GdiVerticalFont)
            If TypeOf ctrl Is LabelEx Then 'if labelEx, only dispatch its width.
                ctrl.Size = New Size(ctrlOriLayout.Size.Width, ctrlOriLayout.Size.Height)
            Else
                ctrl.Size = New Size(ctrlOriLayout.Size.Width * dXScale, ctrlOriLayout.Size.Height * dyScale)
                If ctrl.GetType() Is GetType(UIDataGridView) Then 'if it is a datagridview, then resize the column font.
                    CType(ctrl, UIDataGridView).ResizeDetailImp(dXScale, dyScale)
                End If
            End If
        End If

        'below process the child controls
        If IsIngoreChildResize(ctrl) Then
            Exit Sub
        End If

        If ctrl.Controls.Count > 0 Then 'has children controls
            For Each child As Control In ctrl.Controls
                ResizeCtrl(child, htOriLayout, dXScale, dyScale)
            Next
        End If

        If ctrl.GetType() Is GetType(UIFrmInfo) Then
            CType(ctrl, UIFrmInfo).RestoreEdge()
        End If
    End Sub

    Private Function IsIngoreChildResize(ByVal ctrl As Control) As Boolean
        Dim aryType() As Type = New Type() {GetType(UIRoundPanelBase), _
                                                                               GetType(UITraceInfoPanel), _
                                                                               GetType(LabelEx), _
                                                                               GetType(UITerminalDataLoadButton)}
        For Each typeChild As Type In aryType
            If ctrl.GetType() Is typeChild OrElse ctrl.GetType().IsSubclassOf(typeChild) Then
                Return True
            End If
        Next
        Return False
    End Function
End Class


