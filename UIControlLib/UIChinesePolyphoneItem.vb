Imports System.Windows.Forms
Imports ITSBase
Public Class UIChinesePolyphoneItem
    WithEvents m_oLabel As Label
    Private m_oChineseCharter As ChineseCharacter
    Private m_strValue As String
    Private m_strTitle As String
    Private m_nWidth As Integer
    Private m_nIndex As Integer
    Private m_oPreItem As Control
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_oChineseCharter = New ChineseCharacter
        m_strValue = String.Empty
        m_strTitle = String.Empty
        m_nWidth = 0
        m_nIndex = 0
    End Sub
    Public ReadOnly Property CheckValue() As String
        Get
            Return m_strValue
        End Get
    End Property
    Public ReadOnly Property Title() As String
        Get
            Return m_strTitle
        End Get
    End Property
    Public WriteOnly Property ChineseCharter() As ChineseCharacter
        Set(ByVal value As ChineseCharacter)
            m_oChineseCharter = value
            SetControls()
        End Set
    End Property
    Public Property Widths() As Integer
        Get
            Return m_nWidth
        End Get
        Set(ByVal value As Integer)
            m_nWidth = value
        End Set
    End Property
    Public Property ItemIndex() As Integer
        Get
            Return m_nIndex
        End Get
        Set(ByVal value As Integer)
            m_nIndex = value
        End Set
    End Property
    Public Property PreItem() As Control
        Get
            Return m_oPreItem
        End Get
        Set(ByVal value As Control)
            m_oPreItem = value
        End Set
    End Property
    Private Sub SetControls()
        If m_oChineseCharter.m_lstChineseCode.Count > 1 Then
            Dim nX, nY, i As Integer
            nX = 3
            nY = 3
            i = 0
            m_oLabel = New Label
            m_strTitle = m_oChineseCharter.m_strChineseCharacter
            With m_oLabel
                .Font = New System.Drawing.Font("SimSun", 12)
                .Text = m_oChineseCharter.m_strChineseCharacter
                .AutoSize = False
                .Size = New System.Drawing.Size(20, 20)
                .Location = New System.Drawing.Point(nX, nY + 1)
                .TabIndex = i
            End With
            MyBase.Controls.Add(m_oLabel)
            nX += 25
            i += 1
            For Each strPY As String In m_oChineseCharter.m_lstChineseCode
                Dim radChioce As New RadioButton
                With radChioce
                    .Text = strPY
                    .Size = New System.Drawing.Size(40, 20)
                    .Location = New System.Drawing.Point(nX, nY)
                    .Font = New System.Drawing.Font("SimSun", 12)
                    .TabIndex = i
                End With
                MyBase.Controls.Add(radChioce)
                nX += 45
                i += 1
                If m_nWidth < nX Then
                    m_nWidth = nX
                End If
                If strPY = m_oChineseCharter.m_lstChineseCode.Item(0) Then
                    radChioce.Checked = True
                End If
            Next
        End If
        MyBase.Size = New System.Drawing.Size(m_nWidth, 25)
        MyBase.BackColor = System.Drawing.Color.Transparent
    End Sub
    Public Sub SetValues()
        For i As Integer = 0 To MyBase.Controls.Count - 1
            If i > 0 Then
                If CType(MyBase.Controls.Item(i), RadioButton).Checked = True Then
                    m_strValue = CType(MyBase.Controls.Item(i), RadioButton).Text
                End If
            End If
        Next
    End Sub
    Private Sub Panel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        MyBase.Controls.Item(1).Focus()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim WM_KEYDOWN As Integer = 256
        Dim WM_SYSKEYDOWN As Integer = 260
        If ((msg.Msg = WM_KEYDOWN) Or (msg.Msg = WM_SYSKEYDOWN)) Then
            Select Case keyData
                Case Windows.Forms.Keys.Down
                    SendKeys.Send("{Tab}")
                    Return True
                Case Keys.Up
                    If Not m_oPreItem Is Nothing Then
                        If TypeOf (m_oPreItem) Is UIChinesePolyphoneItem Then
                            For i As Integer = 1 To m_oPreItem.Controls.Count - 1
                                If CType(m_oPreItem.Controls.Item(i), RadioButton).Checked Then
                                    m_oPreItem.Controls.Item(i).Focus()
                                End If
                            Next
                        End If
                    End If
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
