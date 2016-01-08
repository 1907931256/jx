Imports System.Windows.Forms
Imports ITSBase
Imports System.Drawing
Public Class UIChinesePolyphoneChioces
    Private Const TEXT_BTN_NAME_CONFIRM As String = "确定"
    Private Const TEXT_LBLTITLE_TEXT As String = "多音字选择"
    Public WithEvents m_frmShow As Form
    Public WithEvents m_obtnConfirm As LabelEx
    Public WithEvents m_ochiensePloyItem As UIChinesePolyphoneItem
    Public WithEvents m_pnlMain As Panel
    Private m_strChineseCode As String
    Private m_strText As String
    Private m_nWidth As Integer
    Private m_oChineseCollection As ChineseCharacterCollection
    Private m_oEnterProcessManager As UIControlLib.EnterProcessManager
    Private m_ptPoint As Drawing.Point
    Private m_lstIndex As List(Of Integer)
    Private m_lblTitle As Label
    Private m_bValueChange As Boolean
    Private m_bIsLastControl As Boolean

#Region "Initial"
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()
        Container.Add(Me)
    End Sub
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_frmShow = New Form
        m_pnlMain = New Panel
        m_oEnterProcessManager = New EnterProcessManager
        m_strChineseCode = String.Empty
        m_strText = String.Empty
        m_nWidth = 0
        m_lstIndex = New List(Of Integer)
        m_bValueChange = False
        m_bIsLastControl = False
        SetChineseCollection()
    End Sub
#End Region

#Region "Properties"
    Public WriteOnly Property ptPoint() As Point
        Set(ByVal value As Point)
            m_ptPoint = value
        End Set
    End Property
    Public WriteOnly Property ChineseCharaterCollection() As ChineseCharacterCollection
        Set(ByVal value As ChineseCharacterCollection)
            m_oChineseCollection = value
            SetChineseCollection()
        End Set
    End Property
    Public Property IsLastControl() As Boolean
        Get
            Return m_bIsLastControl
        End Get
        Set(ByVal value As Boolean)
            m_bIsLastControl = value
        End Set
    End Property
#End Region
  
#Region "Method"
    Private Sub SetChineseCollection()
        If m_oChineseCollection Is Nothing Then Exit Sub
        m_pnlMain.Controls.Clear()
        m_frmShow.Controls.Clear()
        m_strChineseCode = String.Empty
        Dim bHasPoly As Boolean = False
        If m_oChineseCollection.Count > 0 Then
            For Each oChineseCharter As ChineseCharacter In m_oChineseCollection
                If oChineseCharter.m_lstChineseCode.Count > 0 Then
                    For i As Integer = 0 To oChineseCharter.m_lstChineseCode.Count - 1
                        oChineseCharter.m_lstChineseCode.Item(i) = oChineseCharter.m_lstChineseCode.Item(i).Substring(0, 1).ToUpper
                    Next
                End If
            Next
            For Each oChineseCharter As ChineseCharacter In m_oChineseCollection
                If oChineseCharter.m_lstChineseCode.Count > 0 Then
                    Dim lstNewString As New List(Of String)
                    For Each strSp As String In oChineseCharter.m_lstChineseCode
                        If Not lstNewString.Contains(strSp) Then
                            lstNewString.Add(strSp)
                        End If
                    Next
                    oChineseCharter.m_lstChineseCode = lstNewString
                    If lstNewString.Count > 1 Then
                        bHasPoly = True
                    End If
                End If
            Next
        End If
        If bHasPoly Then
            ShowPloyphoneChioce()
        Else
            SetLstToText()
            MyBase.Text = m_strChineseCode
        End If
    End Sub

    Private Sub ShowPloyphoneChioce()
        If m_oChineseCollection.Count > 0 Then
            m_nWidth = 0
            m_ptPoint.X = 0
            m_ptPoint.Y = MyBase.Height + 2
            m_ptPoint = PointToScreen(m_ptPoint)
            If m_ptPoint.X + m_nWidth > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                m_ptPoint.X = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - m_nWidth - 2
            End If
            Dim nX As Integer = 5
            Dim nY As Integer = 23
            Dim i As Integer = 0
            Dim nItemCount As Integer = 1
            For Each oChineseCode As ChineseCharacter In m_oChineseCollection
                If oChineseCode.m_lstChineseCode.Count > 1 And nItemCount < 21 Then
                    m_lstIndex.Add(i)
                    SetPloyItem(oChineseCode, nX, nY, i)
                    nY += 25
                    nItemCount += 1
                End If
                i += 1
            Next
            SetFixedControlAdd(nX, nY)
        End If
    End Sub

    Private Sub SetFixedControlAdd(ByVal nX As Integer, ByVal nY As Integer)
        If m_pnlMain.Controls.Count > 0 Then
            CType(m_pnlMain.Controls.Item(0), UIChinesePolyphoneItem).PreItem = m_pnlMain.Controls.Item(m_pnlMain.Controls.Count - 1)
            m_lblTitle = New Label
            With m_lblTitle
                .Text = TEXT_LBLTITLE_TEXT
                .Location = New System.Drawing.Point(8, 2)
                .AutoSize = False
                .Size = New System.Drawing.Size(m_nWidth, 20)
                .Font = New System.Drawing.Font("SimSun", 12)
                .BackColor = System.Drawing.Color.Transparent
            End With
            m_pnlMain.Controls.Add(m_lblTitle)
            m_obtnConfirm = New LabelEx
            With m_obtnConfirm
                .Text = TEXT_BTN_NAME_CONFIRM
                .Size = New System.Drawing.Size(60, 30)
                .Location = New System.Drawing.Point(m_nWidth - 65, nY)
                .Font = New System.Drawing.Font("SimSun", 12)
            End With
            m_pnlMain.Controls.Add(m_obtnConfirm)
            With m_pnlMain
                .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                .Location = New System.Drawing.Point(0, 0)
                .Size = New System.Drawing.Size(m_nWidth, nY + 35)
                .BackColor = System.Drawing.Color.Transparent
            End With
            With m_frmShow
                .KeyPreview = False
                .FormBorderStyle = FormBorderStyle.None
                .ShowInTaskbar = False
                .StartPosition = FormStartPosition.Manual
                .Size = New System.Drawing.Size(m_nWidth, nY + 35)
                .Location = m_ptPoint
                .BackColor = System.Drawing.Color.FromArgb(244, 247, 252)
                .TopMost = True
                m_frmShow.Controls.Add(m_pnlMain)
            End With
            ' SetEnterManger()
            AddControls()
            m_frmShow.Show()
            MyBase.Focus()
        End If
    End Sub

    'Private Sub SetEnterManger()
    '    If m_pnlMain.Controls.Count > 0 Then
    '        For i As Integer = 0 To m_pnlMain.Controls.Count - 3
    '            Dim oUIChioceItem As UIChinesePolyphoneItem = CType(m_pnlMain.Controls.Item(i), UIChinesePolyphoneItem)
    '            For j As Integer = 0 To oUIChioceItem.Controls.Count - 1
    '                If j > 0 Then
    '                    m_oEnterProcessManager.Add(oUIChioceItem.Controls.Item(j))
    '                    m_oEnterProcessManager.Add(m_pnlMain.Controls.Item(m_pnlMain.Controls.Count - 1))
    '                End If
    '            Next
    '        Next
    '    End If
    'End Sub

    Private Sub SetPloyItem(ByVal oChineseCharacter As ChineseCharacter, ByVal nX As Integer, ByVal nY As Integer, ByVal nIndex As Integer)
        m_ochiensePloyItem = New UIChinesePolyphoneItem
        m_ochiensePloyItem.ChineseCharter = oChineseCharacter
        m_ochiensePloyItem.ItemIndex = nIndex
        m_ochiensePloyItem.Location = New System.Drawing.Point(nX, nY)
        If m_nWidth < m_ochiensePloyItem.Widths Then
            m_nWidth = m_ochiensePloyItem.Widths
        End If
        If m_pnlMain.Controls.Count > 0 Then
            m_ochiensePloyItem.PreItem = m_pnlMain.Controls.Item(m_pnlMain.Controls.Count - 1)
        End If
        m_pnlMain.Controls.Add(m_ochiensePloyItem)
    End Sub

    Private Sub SetLstToText()
        If m_oChineseCollection Is Nothing Then Exit Sub
        If m_oChineseCollection.Count > 0 Then
            m_strChineseCode = String.Empty
            For Each oChinese As ChineseCharacter In m_oChineseCollection
                m_strChineseCode = m_strChineseCode + oChinese.m_lstChineseCode.Item(0)
            Next
        End If
    End Sub

    Private Sub AddControls()
        If m_pnlMain.Controls.Count > 0 Then
            For i As Integer = 0 To m_pnlMain.Controls.Count - 3
                Dim oUIChioceItem As UIChinesePolyphoneItem = CType(m_pnlMain.Controls.Item(i), UIChinesePolyphoneItem)
                For j As Integer = 0 To oUIChioceItem.Controls.Count - 1
                    If j > 0 Then
                        AddHandler oUIChioceItem.Controls.Item(j).KeyPress, AddressOf OnControlKeyPress
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub ConFirm()
        If m_pnlMain.Controls.Count > 1 Then
            Dim oUichineseItem As UIChinesePolyphoneItem
            For i As Integer = 0 To m_pnlMain.Controls.Count - 3
                oUichineseItem = CType(m_pnlMain.Controls.Item(i), UIChinesePolyphoneItem)
                oUichineseItem.SetValues()
                For Each nIndex As Integer In m_lstIndex
                    If oUichineseItem.ItemIndex = nIndex Then
                        m_oChineseCollection.Item(nIndex).m_lstChineseCode.Item(0) = oUichineseItem.CheckValue
                    End If
                Next
            Next
        End If
        SetLstToText()
        m_bValueChange = True
        m_frmShow.Visible = False
        MyBase.Text = m_strChineseCode
        MyBase.Focus()
        MyBase.SelectAll()
    End Sub

#End Region

#Region "Event"
    Private Sub OnbtnConfirmClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_obtnConfirm.Click
        ConFirm()
        If Not m_bIsLastControl Then
            SendKeys.Send("{Enter}")
        End If
    End Sub

    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        If m_pnlMain.Controls.Count > 0 Then
            m_frmShow.Visible = False
            m_bValueChange = False
        End If
    End Sub

    Private Sub UIChinesePolyphoneChioces_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        m_frmShow.Dispose()
    End Sub

    Private Sub TextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If m_pnlMain.Controls.Count > 0 Then
                ConFirm()
            End If
        End If
        If e.KeyCode = Keys.Down Then
            If m_pnlMain.Controls.Count > 0 Then
                For i As Integer = 1 To m_pnlMain.Controls(0).Controls.Count - 1
                    If CType(m_pnlMain.Controls(0).Controls(i), RadioButton).Checked Then
                        m_pnlMain.Controls(0).Focus()
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub TextBox_GetFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        If Not m_bValueChange Then
            If m_pnlMain.Controls.Count > 0 Then
                m_ptPoint.X = 0
                m_ptPoint.Y = MyBase.Height + 3
                m_ptPoint = PointToScreen(m_ptPoint)
                m_frmShow.Location = m_ptPoint
                m_frmShow.Show()
            End If
        End If
    End Sub

    Private Sub OnControlKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If m_pnlMain.Controls.Count > 0 Then
           If e.KeyChar.ToString = Chr(13) Then
                m_obtnConfirm.PerformClick()
            End If
        End If
    End Sub
#End Region
End Class
