'the class wraps all the action of Expandpanel.
'it's designed for outer-use .
'You can simply call  AddItem() interface to fill the panel.
'Fpf,  2009-08-27

Imports ITSBase
Imports System.Windows.Forms

Public Enum TOOLBAR_SUBITEM
    REFRESH
    PRINT
    PRINTALL
    DISPATCHSTATISTIC
End Enum

Public Class UIRoundPanelBase
    Const CONST_PANEL_WAIT_ON_FIRST_SHOW = 750
    Const COLOR_LABEL_MAX_WIDTH As Integer = 180
    Const COLOR_LABEL_HEIGHT As Integer = 28
    Const COLOR_LABEL_OFFSET As Integer = 1
    Private m_aryColorLabels As Collection
    Public Event DataGridViewSelChanged(ByVal sender As UIControlLib.UIDataGridView)
    Public Event SubItemClicked(ByVal strItemName As String, ByVal strBindTableName As String)
    Public Event SubItemSwitch(ByVal strItemName As String, ByVal strOldSubItemName As String, ByVal strNewSubItemName As String)
    Public Event DataGridViewCellClick(ByVal sender As UIControlLib.UIDataGridView)
    Public Event DataGridViewCellDoubleClick(ByVal sender As UIControlLib.UIDataGridView)
    Public Event ItemClicked(ByVal strItemName As String)
    Public Event ItemSwitch(ByVal strOldItemName As String, ByVal strNewItemName As String)
    Public Event DoRefresh()
    Public Event DoCurrentPrint()
    Public Event DoPrintAll()
    Public Event DoDispatchStatistic()
    Private m_nTotalTime As Integer
    Private m_bInnateBehavior As Boolean = True
    Private m_oCurItem As ColorLabel

    Private Sub UIRoundPanelBase_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Me.pnlClient.Location = New System.Drawing.Point(2, Me.pnlHead.Bottom)
        Me.pnlClient.Size = New System.Drawing.Size(Me.Width - 4, Me.Height - 2)
        RelayoutLabels()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_aryColorLabels = New Collection
        Me.DoubleBuffered = True
        Me.Visible = False
        m_oCurItem = Nothing
    End Sub

    Public Sub AddItem(ByVal strSheetName As String, ByRef ds As DataSet, ByVal emStyle As EXPAND_PANEL_TYPE, _
                                      Optional ByVal bInitSel As Boolean = False, Optional ByVal dtDepartment As DataTable = Nothing, _
                                      Optional ByVal strSearchCaption As String = Nothing)
        'create a new colorLabel, and the binding ctrl
        Dim oColorLbl As New ColorLabel
        Dim bExisted As Boolean = False
        For Each sheet As ColorLabel In m_aryColorLabels
            If String.Compare(sheet.Text, strSheetName, True) = 0 Then 'if find a same sheet ,update its binding ctrl.
                oColorLbl = sheet
                bExisted = True
                Exit For
            End If
        Next

        oColorLbl.Text = strSheetName

        If bExisted = False Then
            Dim uiExpandpanel As New UIExpandPanel
            AddHandler uiExpandpanel.DataGridViewSelChanged, AddressOf OnDataGridViewSelChanged
            AddHandler uiExpandpanel.SubItemClicked, AddressOf OnSubItemClicked
            AddHandler uiExpandpanel.SubItemSwitch, AddressOf OnSubItemSwitch
            AddHandler uiExpandpanel.DataGridViewCellClick, AddressOf OnDataGridViewCellClick
            AddHandler uiExpandpanel.DataGridViewCellDoubleClick, AddressOf OnDataGridViewCellDoubleClick
            AddHandler uiExpandpanel.DoRefresh, AddressOf OnExpandpanelDoRefresh
            AddHandler uiExpandpanel.DoCurrentPrint, AddressOf OnExpandpanelDoCurrentPrint
            AddHandler uiExpandpanel.DoPrintAll, AddressOf OnExpandpanelDoPrintAll
            AddHandler uiExpandpanel.DoDispatchStatistic, AddressOf OnExpandpanelDoDispatchStatistic
            m_aryColorLabels.Add(oColorLbl)

            oColorLbl.BindingCtrl = uiExpandpanel
            uiExpandpanel.Dock = DockStyle.Fill
            uiExpandpanel.SetDepartment(dtDepartment)
            If Not String.IsNullOrEmpty(strSearchCaption) Then
                uiExpandpanel.SetSearchCaption(strSearchCaption)
            End If
            uiExpandpanel.SetDataSet(ds, emStyle)
            'Me.pnlTopMid.Controls.Add(oColorLbl)
            'Me.pnlTopMid.Controls.SetChildIndex(oColorLbl, 0)
            AddHandler oColorLbl.Click, AddressOf OnColorLblClick
            RelayoutLabels()
        Else
            If oColorLbl.BindingCtrl IsNot Nothing Then
                CType(oColorLbl.BindingCtrl, UIExpandPanel).SetDepartment(dtDepartment)
                If Not String.IsNullOrEmpty(strSearchCaption) Then
                    CType(oColorLbl.BindingCtrl, UIExpandPanel).SetSearchCaption(strSearchCaption)
                End If
                CType(oColorLbl.BindingCtrl, UIExpandPanel).UpdateDataSet(ds, emStyle)
            End If
        End If

        If bInitSel Then
            m_bInnateBehavior = False
            OnColorLblClick(oColorLbl, EventArgs.Empty)
            m_bInnateBehavior = True
        End If
    End Sub

    Private Sub RelayoutLabels()
        'If m_aryColorLabels IsNot Nothing AndAlso m_aryColorLabels.Count > 0 Then
        '    Dim nEachLength As Integer = (Me.pnlTopMid.Width) / m_aryColorLabels.Count
        '    If nEachLength > COLOR_LABEL_MAX_WIDTH Then
        '        nEachLength = COLOR_LABEL_MAX_WIDTH
        '    End If
        '    Dim nStartPos As Integer = (Me.pnlTopMid.Width - nEachLength * m_aryColorLabels.Count) / 2
        '    For Each lbl As ColorLabel In m_aryColorLabels
        '        lbl.Location = New System.Drawing.Point(nStartPos, Me.pnlHead.Height - COLOR_LABEL_HEIGHT)
        '        lbl.Size = New System.Drawing.Size(nEachLength, COLOR_LABEL_HEIGHT)
        '        nStartPos += nEachLength
        '    Next
        'End If
    End Sub

    Private Sub OnColorLblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If m_bInnateBehavior Then
            RaiseEvent ItemClicked(CType(sender, ColorLabel).Text)
        End If
        Dim strPreText As String = ""
        If Not m_oCurItem Is Nothing Then strPreText = m_oCurItem.Text
        m_oCurItem = CType(sender, ColorLabel)
        If (CType(sender, ColorLabel).OnPerform) Then
            Return
        End If
        Me.pnlClient.Visible = False 'temp set to avoid flash
        For Each lbl As ColorLabel In m_aryColorLabels
            If lbl Is sender Then
                PerformClick(lbl)
            Else
                PerformUnClick(lbl)
            End If
        Next
        If m_bInnateBehavior Then
            RaiseEvent ItemSwitch(strPreText, CType(sender, ColorLabel).Text)
        End If
        Me.pnlClient.Visible = True
    End Sub

    Private Sub PerformClick(ByVal oSender As ColorLabel)
        Try
            oSender.PerformClick()
            Me.pnlClient.Controls.Clear()
            Me.pnlClient.Controls.Add(oSender.BindingCtrl)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PerformUnClick(ByVal oSender As ColorLabel)
        oSender.PerformUnClick()
    End Sub

    Private Sub OnDataGridViewSelChanged(ByVal sender As UIControlLib.UIDataGridView)
        RaiseEvent DataGridViewSelChanged(sender)
    End Sub

    Private Sub OnDataGridViewCellClick(ByVal sender As UIControlLib.UIDataGridView)
        RaiseEvent DataGridViewCellClick(sender)
    End Sub

    Private Sub OnDataGridViewCellDoubleClick(ByVal sender As UIControlLib.UIDataGridView)
        RaiseEvent DataGridViewCellDoubleClick(sender)
    End Sub

    Private Sub OnSubItemClicked(ByVal sender As UIExpandPanel, ByVal strBindTableName As String)
        Dim lblFind As ColorLabel = Nothing
        For Each lbl As ColorLabel In Me.m_aryColorLabels
            If lbl.BindingCtrl Is sender Then
                lblFind = lbl
                Exit For
            End If
        Next
        If lblFind IsNot Nothing Then
            RaiseEvent SubItemClicked(lblFind.Text, strBindTableName)
        End If
    End Sub

    Private Sub OnSubItemSwitch(ByVal sender As UIExpandPanel, ByVal strOldSubItemName As String, ByVal strNewSubItemName As String)
        Dim lblFind As ColorLabel = Nothing
        For Each lbl As ColorLabel In Me.m_aryColorLabels
            If lbl.BindingCtrl Is sender Then
                lblFind = lbl
                Exit For
            End If
        Next
        If lblFind IsNot Nothing Then
            RaiseEvent SubItemSwitch(lblFind.Text, strOldSubItemName, strNewSubItemName)
        End If
    End Sub

    'the funciton is to avoid flash while first to show the control.
    'otherwise, it is a litter flash ,expesially when with lots of child controls
    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick
        m_nTotalTime += Timer.Interval
        If m_nTotalTime >= CONST_PANEL_WAIT_ON_FIRST_SHOW Then
            Me.Visible = True
            Me.Timer.Enabled = False
        End If
    End Sub

    Private Sub pnlClient_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlClient.Resize
        m_nTotalTime = 0
    End Sub

    Public Function UpdateDataTable(ByVal strItemName As String, ByVal strBindTableName As String, ByVal dt As DataTable) As Boolean
        If dt Is Nothing Then
            Return False
        End If
        'Return CType(Label, UIExpandPanel).UpdateDataTable(strBindTableName, dt)
        Return False
    End Function

    Public Function UpdateDataTable(ByVal strItemName As String, ByVal nTableIndex As Integer, ByVal dt As DataTable) As Boolean
        If String.IsNullOrEmpty(strItemName) OrElse nTableIndex < 0 OrElse dt Is Nothing Then
            Return False
        End If
        For Each lbl As ColorLabel In m_aryColorLabels
            If String.Compare(strItemName, lbl.Text, True) = 0 Then
                Return CType(lbl.BindingCtrl, UIExpandPanel).UpdateDataTable(nTableIndex, dt)
            End If
        Next
        Return False
    End Function

    Public Function SetForeColor(ByVal strItemName As String, ByVal strBindTableName As String, ByVal cr As System.Drawing.Color) As Boolean
        If String.IsNullOrEmpty(strItemName) OrElse String.IsNullOrEmpty(strBindTableName) Then
            Return False
        End If
        For Each lbl As ColorLabel In m_aryColorLabels
            If String.Compare(strItemName, lbl.Text, True) = 0 Then
                Return CType(lbl.BindingCtrl, UIExpandPanel).SetForeColor(strBindTableName, cr)
            End If
        Next
        Return False
    End Function

    Public Function SetForeColor(ByVal strItemName As String, ByVal nTableIndex As Integer, ByVal cr As System.Drawing.Color) As Boolean
        If String.IsNullOrEmpty(strItemName) OrElse nTableIndex < 0 Then
            Return False
        End If
        For Each lbl As ColorLabel In m_aryColorLabels
            If String.Compare(strItemName, lbl.Text, True) = 0 Then
                Return CType(lbl.BindingCtrl, UIExpandPanel).SetForeColor(nTableIndex, cr)
            End If
        Next
        Return False
    End Function

    Public Function GetDataTable(ByVal strItemName As String, ByVal strBindTableName As String) As DataTable
        If String.IsNullOrEmpty(strItemName) OrElse String.IsNullOrEmpty(strBindTableName) Then
            Return Nothing
        End If
        For Each lbl As ColorLabel In m_aryColorLabels
            If String.Compare(strItemName, lbl.Text, True) = 0 Then
                Return CType(lbl.BindingCtrl, UIExpandPanel).GetDataTable(strBindTableName)
            End If
        Next
        Return Nothing
    End Function

    Public Function GetDataTable(ByVal strItemName As String, ByVal nTableIndex As Integer) As DataTable
        If String.IsNullOrEmpty(strItemName) OrElse nTableIndex < 0 Then
            Return Nothing
        End If
        For Each lbl As ColorLabel In m_aryColorLabels
            If String.Compare(strItemName, lbl.Text, True) = 0 Then
                Return CType(lbl.BindingCtrl, UIExpandPanel).GetDataTable(nTableIndex)
            End If
        Next
        Return Nothing
    End Function

    Public Function GetCurTableClassify(ByRef strItemName As String, ByRef strBindTableName As String) As Boolean
        For Each lbl As ColorLabel In m_aryColorLabels
            If lbl.OnPerform Then
                Dim bRet As Boolean = CType(lbl.BindingCtrl, UIExpandPanel).GetCurTableClassify(strBindTableName)
                If bRet Then strItemName = lbl.Text
                Return bRet
            End If
        Next
        Return False
    End Function

    Public Function GetCurTableClassify(ByRef strItemName As String, ByRef nIndex As Integer) As Boolean
        For Each lbl As ColorLabel In m_aryColorLabels
            If lbl.OnPerform Then
                Dim bRet As Boolean = CType(lbl.BindingCtrl, UIExpandPanel).GetCurTableClassify(nIndex)
                If bRet Then strItemName = lbl.Text
                Return bRet
            End If
        Next
        Return False
    End Function

    Public Function GetCurTable() As DataTable
        Dim strItemName As String = String.Empty
        Dim nIndex As Integer = -1
        If GetCurTableClassify(strItemName, nIndex) Then
            Return GetDataTable(strItemName, nIndex)
        End If
        Return Nothing
    End Function

    Private Sub OnExpandpanelDoRefresh()
        RaiseEvent DoRefresh()
    End Sub

    Private Sub OnExpandpanelDoCurrentPrint()
        RaiseEvent DoCurrentPrint()
    End Sub

    Private Sub OnExpandpanelDoPrintAll()
        RaiseEvent DoPrintAll()
    End Sub

    Private Sub OnExpandpanelDoDispatchStatistic()
        RaiseEvent DoDispatchStatistic()
    End Sub

    Public Sub ToolBarSubItemVisible(ByVal strItemName As String, ByVal emBarItem As TOOLBAR_SUBITEM, ByVal bVisible As Boolean)
        If String.IsNullOrEmpty(strItemName) Then
            Return
        End If
        For Each lbl As ColorLabel In m_aryColorLabels
            If String.Compare(strItemName, lbl.Text, True) = 0 Then
                CType(lbl.BindingCtrl, UIExpandPanel).ToolBarSubItemVisible(emBarItem, bVisible)
                Exit For
            End If
        Next
    End Sub

End Class
