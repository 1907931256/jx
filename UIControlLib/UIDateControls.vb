Imports System.Windows.Forms
Imports ITSBase
Imports System.Drawing
Public Class UIDateControls
    Private Const CONST_TEXT_YEAR As String = "Äê"
    Private m_aryButtons() As LabelEx 'Button control array
    Private m_nServerYear As Integer
    Private m_nServerMonth As Integer
    Private m_nCurrentSelectYear As Integer
    Private m_strCurrenSelectDate As String
    Private m_oIsMonthEnableList As New ArrayList
    Private m_strServerCurrentDate As String = ""
    Public Event btnReFreshClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event lblMonthClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event btnAddClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event btnModifyClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event btnPreClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event btnNextClick(ByVal sender As Object, ByVal e As EventArgs)

#Region "Windows Form Designer generated code"
    Private Sub UIDateControls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_strServerCurrentDate.Length = 6 Then
            m_nServerYear = m_strServerCurrentDate.Substring(0, 4)
            m_nServerMonth = m_strServerCurrentDate.Substring(4, 2)
            m_nCurrentSelectYear = m_nServerYear
            lblYear.Text = m_nCurrentSelectYear.ToString() + CONST_TEXT_YEAR
            MonthShow()
        End If
        IsMonthLabelEnable()
        If m_oIsMonthEnableList.Count > 0 Then
            If m_oIsMonthEnableList(0).ToString().Trim().Length = 6 Then
                Dim strMonthTag As String = m_oIsMonthEnableList(0).ToString().Trim().Substring(4, 2)
                m_strCurrenSelectDate = m_oIsMonthEnableList(0).ToString().Trim()
                SelectDefaultMonth(strMonthTag)
            End If
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        SetRefreshTurn()
    End Sub
#End Region

#Region "Propety"
    Public ReadOnly Property StrSelectYearMonth() As String
        Get
            Return m_strCurrenSelectDate
        End Get
    End Property

    Public Property IsMonthLabelEnableList() As ArrayList
        Get
            Return m_oIsMonthEnableList
        End Get
        Set(ByVal value As ArrayList)
            m_oIsMonthEnableList = value
            IsMonthLabelEnable()
        End Set
    End Property

    Public ReadOnly Property strCurrentYear() As String
        Get
            Return m_nCurrentSelectYear.ToString()
        End Get
    End Property

    Public WriteOnly Property strServerCurrentDate() As String
        Set(ByVal value As String)
            m_strServerCurrentDate = value
        End Set
    End Property
#End Region

    Private Sub SetRefreshTurn()

        SetBtnPreShow(btnPre)

        SetBtnNextShow(btnNext)

        SetBtnRefreshShow(btnRefreshJan)
        SetBtnRefreshShow(btnRefreshFeb)
        SetBtnRefreshShow(btnRefreshMar)
        SetBtnRefreshShow(btnRefreshApr)
        SetBtnRefreshShow(btnRefreshMay)
        SetBtnRefreshShow(btnRefreshJune)
        SetBtnRefreshShow(btnRefreshJuly)
        SetBtnRefreshShow(btnRefreshAug)
        SetBtnRefreshShow(btnRefreshSept)
        SetBtnRefreshShow(btnRefreshOct)
        SetBtnRefreshShow(btnRefreshNov)
        SetBtnRefreshShow(btnRefreshDec)
    End Sub

    Private Sub SetBtnPreShow(ByVal oBtnPre As UIControlLib.MyLabelBase)
        oBtnPre.SetImageList(My.Resources.pre_normal, My.Resources.pre_over, My.Resources.pre_press)
        AddHandler oBtnPre.Click, AddressOf OnBtnPreClick
    End Sub

    Private Sub SetBtnNextShow(ByVal oBtnNext As UIControlLib.MyLabelBase)
        oBtnNext.SetImageList(My.Resources.next_normal, My.Resources.next_over, My.Resources.next_press)
        AddHandler oBtnNext.Click, AddressOf OnBtnNextClick
    End Sub

    Private Sub SetBtnRefreshShow(ByVal oBtnRefresh As UIControlLib.MyLabelBase)
        oBtnRefresh.SetImageList(My.Resources.refresh1, My.Resources.refresh_over1, My.Resources.refresh_press1)
        AddHandler oBtnRefresh.Click, AddressOf OnBtnRefreshClick
    End Sub

    Private Sub SetBtnAddShow(ByVal oBtnAdd As UIControlLib.MyLabelBase)
        oBtnAdd.Image = My.Resources.Add_normal_1
        oBtnAdd.SetImageList(My.Resources.Add_normal_1, My.Resources.Add_over_1, My.Resources.Add_press_1)
        oBtnAdd.TipText = "Ìí¼Ó"
    End Sub

    Private Sub SetBtnModifyShow(ByVal oBtnModify As UIControlLib.MyLabelBase)
        oBtnModify.Image = My.Resources.edit_normal1
        oBtnModify.SetImageList(My.Resources.edit_normal1, My.Resources.edit_over1, My.Resources.edit_press1)
        oBtnModify.TipText = "ÐÞ¸Ä"
    End Sub

    Private Sub OnBtnPreClick(ByVal sender As Object, ByVal e As EventArgs)
        m_nCurrentSelectYear = m_nCurrentSelectYear - 1
        lblYear.Text = m_nCurrentSelectYear.ToString() + CONST_TEXT_YEAR
        If m_nCurrentSelectYear < m_nServerYear Then
            btnNext.Enabled = True
        End If
        MonthShow()
        RaiseEvent btnPreClick(sender, e)
        IsMonthLabelEnable()
        m_strCurrenSelectDate = String.Empty
    End Sub

    Private Sub OnBtnNextClick(ByVal sender As Object, ByVal e As EventArgs)
        m_nCurrentSelectYear = m_nCurrentSelectYear + 1
        lblYear.Text = m_nCurrentSelectYear.ToString() + CONST_TEXT_YEAR
        If m_nCurrentSelectYear = m_nServerYear Then
            btnNext.Enabled = False
        End If
        MonthShow()
        RaiseEvent btnNextClick(sender, e)
        IsMonthLabelEnable()
        m_strCurrenSelectDate = String.Empty
    End Sub

    Private Sub OnBtnRefreshClick(ByVal sender As Object, ByVal e As EventArgs)
        m_strCurrenSelectDate = m_nCurrentSelectYear.ToString() + sender.Tag.ToString()
        RaiseEvent btnReFreshClick(sender, e)
        IsMonthLabelEnable()
    End Sub

    Private Function IsInArray(ByVal oValue As Object, ByVal oArray As ArrayList) As Boolean
        For Each oArrayValue As Object In oArray
            If oArrayValue.ToString().Trim().Equals(oValue.ToString().Trim()) Then
                Return True
            End If
        Next
    End Function

    Private Sub MonthShow()
        If m_nCurrentSelectYear = m_nServerYear Then
            If m_nServerMonth >= 1 Then
                lblMonthJan.Visible = True
                btnRefreshJan.Visible = True
                btnAddModifyJan.Visible = True
            Else
                lblMonthJan.Visible = False
                btnRefreshJan.Visible = False
                btnAddModifyJan.Visible = False
            End If
            If m_nServerMonth >= 2 Then
                lblMonthFeb.Visible = True
                btnRefreshFeb.Visible = True
                btnAddModifyFeb.Visible = True
            Else
                lblMonthFeb.Visible = False
                btnRefreshFeb.Visible = False
                btnAddModifyFeb.Visible = False
            End If
            If m_nServerMonth >= 3 Then
                lblMonthMar.Visible = True
                btnRefreshMar.Visible = True
                btnAddModifyMar.Visible = True
            Else
                lblMonthMar.Visible = False
                btnRefreshMar.Visible = False
                btnAddModifyMar.Visible = False
            End If
            If m_nServerMonth >= 4 Then
                lblMonthApr.Visible = True
                btnRefreshApr.Visible = True
                btnAddModifyApr.Visible = True
            Else
                lblMonthApr.Visible = False
                btnRefreshApr.Visible = False
                btnAddModifyApr.Visible = False
            End If
            If m_nServerMonth >= 5 Then
                lblMonthMay.Visible = True
                btnRefreshMay.Visible = True
                btnAddModifyMay.Visible = True
            Else
                lblMonthMay.Visible = False
                btnRefreshMay.Visible = False
                btnAddModifyMay.Visible = False
            End If
            If m_nServerMonth >= 6 Then
                lblMonthJune.Visible = True
                btnRefreshJune.Visible = True
                btnAddModifyJune.Visible = True
            Else
                lblMonthJune.Visible = False
                btnRefreshJune.Visible = False
                btnAddModifyJune.Visible = False
            End If
            If m_nServerMonth >= 7 Then
                lblMonthJuly.Visible = True
                btnRefreshJuly.Visible = True
                btnAddModifyJuly.Visible = True
            Else
                lblMonthJuly.Visible = False
                btnRefreshJuly.Visible = False
                btnAddModifyJuly.Visible = False
            End If
            If m_nServerMonth >= 8 Then
                lblMonthAug.Visible = True
                btnRefreshAug.Visible = True
                btnAddModifyAug.Visible = True
            Else
                lblMonthAug.Visible = False
                btnRefreshAug.Visible = False
                btnAddModifyAug.Visible = False
            End If
            If m_nServerMonth >= 9 Then
                lblMonthSept.Visible = True
                btnRefreshSept.Visible = True
                btnAddModifySept.Visible = True
            Else
                lblMonthSept.Visible = False
                btnRefreshSept.Visible = False
                btnAddModifySept.Visible = False
            End If
            If m_nServerMonth >= 10 Then
                lblMonthOct.Visible = True
                btnRefreshOct.Visible = True
                btnAddModifyOct.Visible = True
            Else
                lblMonthOct.Visible = False
                btnRefreshOct.Visible = False
                btnAddModifyOct.Visible = False
            End If
            If m_nServerMonth >= 11 Then
                lblMonthNov.Visible = True
                btnRefreshNov.Visible = True
                btnAddModifyNov.Visible = True
            Else
                lblMonthNov.Visible = False
                btnRefreshNov.Visible = False
                btnAddModifyNov.Visible = False
            End If
            If m_nServerMonth >= 12 Then
                lblMonthDec.Visible = True
                btnRefreshDec.Visible = True
                btnAddModifyDec.Visible = True
            Else
                lblMonthDec.Visible = False
                btnRefreshDec.Visible = False
                btnAddModifyDec.Visible = False
            End If
        ElseIf m_nCurrentSelectYear < m_nServerYear Then
            lblMonthJan.Visible = True
            btnRefreshJan.Visible = True
            btnAddModifyJan.Visible = True
            lblMonthFeb.Visible = True
            btnRefreshFeb.Visible = True
            btnAddModifyFeb.Visible = True
            lblMonthMar.Visible = True
            btnRefreshMar.Visible = True
            btnAddModifyMar.Visible = True
            lblMonthApr.Visible = True
            btnRefreshApr.Visible = True
            btnAddModifyApr.Visible = True
            lblMonthMay.Visible = True
            btnRefreshMay.Visible = True
            btnAddModifyMay.Visible = True
            lblMonthJune.Visible = True
            btnRefreshJune.Visible = True
            btnAddModifyJune.Visible = True
            lblMonthJuly.Visible = True
            btnRefreshJuly.Visible = True
            btnAddModifyJuly.Visible = True
            lblMonthAug.Visible = True
            btnRefreshAug.Visible = True
            btnAddModifyAug.Visible = True
            lblMonthSept.Visible = True
            btnRefreshSept.Visible = True
            btnAddModifySept.Visible = True
            lblMonthOct.Visible = True
            btnRefreshOct.Visible = True
            btnAddModifyOct.Visible = True
            lblMonthNov.Visible = True
            btnRefreshNov.Visible = True
            btnAddModifyNov.Visible = True
            lblMonthDec.Visible = True
            btnRefreshDec.Visible = True
            btnAddModifyDec.Visible = True
        End If
    End Sub

    Private Sub IsMonthLabelEnable()
        SetlblMonthEnableFalseBtnAdd()
        If m_oIsMonthEnableList.Count > 0 Then
            Dim strYear As String = String.Empty
            Dim strMonth As String = String.Empty
            For Each strDate As String In m_oIsMonthEnableList
                If strDate.Length = 6 Then
                    strYear = strDate.Substring(0, 4)
                    strMonth = strDate.Substring(4, 2)
                    If m_nCurrentSelectYear.ToString() = strYear Then
                        lblEnable(strMonth)
                    Else
                        lblMonthJan.Enabled = False
                        lblMonthFeb.Enabled = False
                        lblMonthMar.Enabled = False
                        lblMonthApr.Enabled = False
                        lblMonthMay.Enabled = False
                        lblMonthJune.Enabled = False
                        lblMonthJuly.Enabled = False
                        lblMonthAug.Enabled = False
                        lblMonthSept.Enabled = False
                        lblMonthOct.Enabled = False
                        lblMonthNov.Enabled = False
                        lblMonthDec.Enabled = False
                        SetBtnAddShow(btnAddModifyJan)
                        SetBtnAddShow(btnAddModifyFeb)
                        SetBtnAddShow(btnAddModifyMar)
                        SetBtnAddShow(btnAddModifyApr)
                        SetBtnAddShow(btnAddModifyMay)
                        SetBtnAddShow(btnAddModifyJune)
                        SetBtnAddShow(btnAddModifyJuly)
                        SetBtnAddShow(btnAddModifyAug)
                        SetBtnAddShow(btnAddModifySept)
                        SetBtnAddShow(btnAddModifyOct)
                        SetBtnAddShow(btnAddModifyNov)
                        SetBtnAddShow(btnAddModifyDec)
                    End If
                End If
            Next
        Else
            lblMonthJan.Enabled = False
            lblMonthFeb.Enabled = False
            lblMonthMar.Enabled = False
            lblMonthApr.Enabled = False
            lblMonthMay.Enabled = False
            lblMonthJune.Enabled = False
            lblMonthJuly.Enabled = False
            lblMonthAug.Enabled = False
            lblMonthSept.Enabled = False
            lblMonthOct.Enabled = False
            lblMonthNov.Enabled = False
            lblMonthDec.Enabled = False
            SetBtnAddShow(btnAddModifyJan)
            SetBtnAddShow(btnAddModifyFeb)
            SetBtnAddShow(btnAddModifyMar)
            SetBtnAddShow(btnAddModifyApr)
            SetBtnAddShow(btnAddModifyMay)
            SetBtnAddShow(btnAddModifyJune)
            SetBtnAddShow(btnAddModifyJuly)
            SetBtnAddShow(btnAddModifyAug)
            SetBtnAddShow(btnAddModifySept)
            SetBtnAddShow(btnAddModifyOct)
            SetBtnAddShow(btnAddModifyNov)
            SetBtnAddShow(btnAddModifyDec)
        End If
    End Sub

    Private Sub SetlblMonthEnableFalseBtnAdd()
        lblMonthJan.Enabled = False
        lblMonthFeb.Enabled = False
        lblMonthMar.Enabled = False
        lblMonthApr.Enabled = False
        lblMonthMay.Enabled = False
        lblMonthJune.Enabled = False
        lblMonthJuly.Enabled = False
        lblMonthAug.Enabled = False
        lblMonthSept.Enabled = False
        lblMonthOct.Enabled = False
        lblMonthNov.Enabled = False
        lblMonthDec.Enabled = False
        SetBtnAddShow(btnAddModifyJan)
        SetBtnAddShow(btnAddModifyFeb)
        SetBtnAddShow(btnAddModifyMar)
        SetBtnAddShow(btnAddModifyApr)
        SetBtnAddShow(btnAddModifyMay)
        SetBtnAddShow(btnAddModifyJune)
        SetBtnAddShow(btnAddModifyJuly)
        SetBtnAddShow(btnAddModifyAug)
        SetBtnAddShow(btnAddModifySept)
        SetBtnAddShow(btnAddModifyOct)
        SetBtnAddShow(btnAddModifyNov)
        SetBtnAddShow(btnAddModifyDec)
    End Sub

    Private Sub lblEnable(ByVal strMonth As String)
        If strMonth = lblMonthJan.Tag.ToString.Trim() Then
            lblMonthJan.Enabled = True
            SetBtnModifyShow(btnAddModifyJan)
        End If
        If strMonth = lblMonthFeb.Tag.ToString.Trim() Then
            lblMonthFeb.Enabled = True
            SetBtnModifyShow(btnAddModifyFeb)
        End If
        If strMonth = lblMonthMar.Tag.ToString.Trim() Then
            lblMonthMar.Enabled = True
            SetBtnModifyShow(btnAddModifyMar)
        End If
        If strMonth = lblMonthApr.Tag.ToString.Trim() Then
            lblMonthApr.Enabled = True
            SetBtnModifyShow(btnAddModifyApr)
        End If
        If strMonth = lblMonthMay.Tag.ToString.Trim() Then
            lblMonthMay.Enabled = True
            SetBtnModifyShow(btnAddModifyMay)
        End If
        If strMonth = lblMonthJune.Tag.ToString.Trim() Then
            lblMonthJune.Enabled = True
            SetBtnModifyShow(btnAddModifyJune)
        End If
        If strMonth = lblMonthJuly.Tag.ToString.Trim() Then
            lblMonthJuly.Enabled = True
            SetBtnModifyShow(btnAddModifyJuly)
        End If
        If strMonth = lblMonthAug.Tag.ToString.Trim() Then
            lblMonthAug.Enabled = True
            SetBtnModifyShow(btnAddModifyAug)
        End If
        If strMonth = lblMonthSept.Tag.ToString.Trim() Then
            lblMonthSept.Enabled = True
            SetBtnModifyShow(btnAddModifySept)
        End If
        If strMonth = lblMonthOct.Tag.ToString.Trim() Then
            lblMonthOct.Enabled = True
            SetBtnModifyShow(btnAddModifyOct)
        End If
        If strMonth = lblMonthNov.Tag.ToString.Trim() Then
            lblMonthNov.Enabled = True
            SetBtnModifyShow(btnAddModifyNov)
        End If
        If strMonth = lblMonthDec.Tag.ToString.Trim() Then
            lblMonthDec.Enabled = True
            SetBtnModifyShow(btnAddModifyDec)
        End If
    End Sub

    Private Sub lblMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonthSept.Click, lblMonthAug.Click, lblMonthJuly.Click, lblMonthJune.Click, lblMonthMay.Click, lblMonthApr.Click, lblMonthMar.Click, lblMonthFeb.Click, lblMonthDec.Click, lblMonthNov.Click, lblMonthOct.Click, lblMonthJan.Click
        m_strCurrenSelectDate = m_nCurrentSelectYear.ToString() + sender.Tag.ToString()
        KeepClickStatus(sender)
        RaiseEvent lblMonthClick(sender, e)
    End Sub

    Private Sub KeepClickStatus(ByVal sender As Object)
        Dim MonthLabelArray As New ArrayList
        MonthLabelArray.Add(lblMonthJan)
        MonthLabelArray.Add(lblMonthFeb)
        MonthLabelArray.Add(lblMonthMar)
        MonthLabelArray.Add(lblMonthApr)
        MonthLabelArray.Add(lblMonthMay)
        MonthLabelArray.Add(lblMonthJune)
        MonthLabelArray.Add(lblMonthJuly)
        MonthLabelArray.Add(lblMonthAug)
        MonthLabelArray.Add(lblMonthSept)
        MonthLabelArray.Add(lblMonthOct)
        MonthLabelArray.Add(lblMonthNov)
        MonthLabelArray.Add(lblMonthDec)
        Dim labelKeepClickStatus As New LabelEx(True)
        For Each labelMonth As LabelEx In MonthLabelArray
            If labelMonth.Text.ToString() = sender.Text.ToString() Then
                labelMonth.BtnPerformClick()
            Else
                labelMonth.BtnPerformUnClick()
            End If
        Next
    End Sub

    Private Sub SelectDefaultMonth(ByVal strMonth As String)
        If strMonth = lblMonthJan.Tag.ToString().Trim() Then
            lblMonthJan.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthJan, EventArgs.Empty)
        End If
        If strMonth = lblMonthFeb.Tag.ToString().Trim() Then
            lblMonthFeb.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthFeb, EventArgs.Empty)
        End If
        If strMonth = lblMonthMar.Tag.ToString().Trim() Then
            lblMonthMar.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthMar, EventArgs.Empty)
        End If
        If strMonth = lblMonthApr.Tag.ToString().Trim() Then
            lblMonthApr.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthApr, EventArgs.Empty)
        End If
        If strMonth = lblMonthMay.Tag.ToString().Trim() Then
            lblMonthMay.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthMay, EventArgs.Empty)
        End If
        If strMonth = lblMonthJune.Tag.ToString().Trim() Then
            lblMonthJune.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthJune, EventArgs.Empty)
        End If
        If strMonth = lblMonthJuly.Tag.ToString().Trim() Then
            lblMonthJuly.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthJuly, EventArgs.Empty)
        End If
        If strMonth = lblMonthAug.Tag.ToString().Trim() Then
            lblMonthAug.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthAug, EventArgs.Empty)
        End If
        If strMonth = lblMonthSept.Tag.ToString().Trim() Then
            lblMonthSept.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthSept, EventArgs.Empty)
        End If
        If strMonth = lblMonthOct.Tag.ToString().Trim() Then
            lblMonthOct.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthOct, EventArgs.Empty)
        End If
        If strMonth = lblMonthNov.Tag.ToString().Trim() Then
            lblMonthNov.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthNov, EventArgs.Empty)
        End If
        If strMonth = lblMonthDec.Tag.ToString().Trim() Then
            lblMonthDec.BtnPerformClick()
            RaiseEvent lblMonthClick(lblMonthDec, EventArgs.Empty)
        End If
    End Sub

    Private Sub AddModifyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModifySept.Click, btnAddModifyOct.Click, btnAddModifyNov.Click, btnAddModifyMay.Click, btnAddModifyMar.Click, btnAddModifyJune.Click, btnAddModifyJuly.Click, btnAddModifyJan.Click, btnAddModifyFeb.Click, btnAddModifyDec.Click, btnAddModifyAug.Click, btnAddModifyApr.Click
        m_strCurrenSelectDate = m_nCurrentSelectYear.ToString() + sender.Tag.ToString()
        If IsInArray(m_strCurrenSelectDate, m_oIsMonthEnableList) Then
            RaiseEvent btnModifyClick(sender, e)
        Else
            RaiseEvent btnAddClick(sender, e)
        End If
    End Sub
End Class
