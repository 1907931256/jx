Imports System.Windows.Forms
Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports UIControlLib

Public Class FrmAddInstrument
    Public InstrumentInfo As InstrumentInfo
    Private _insDict As DataTable

    Private Sub FrmAddIns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialInsInfo()
    End Sub

    Private Sub InitialInsInfo()
        _insDict = New DataTable()
        Dim operationManage As New DbOperationManage
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QueryInstrumentInfo(_insDict) AndAlso Not _insDict.IsNullOrEmpty() Then
            AddHandler ddlInsName.PressEnter, AddressOf NamePressEnter
            ddlInsName.ColNoOfCode = 5
            ddlInsName.IDIndex = 0
            With ddlInsName
                .DisplayIndex = 3
                .ColumnWidthCollection = New Short() {0, 0, 100, 200, 0, 0, 150, 75}
                .Attach(CType(ddlInsName, TextBox), _insDict)
            End With
        End If
    End Sub

    Private Sub NamePressEnter()
        If _insDict.IsNullOrEmpty() Then Return
        Dim firstSel As ListViewItem = ddlInsName.GetFirstSelListItem()
        If firstSel Is Nothing Then Return
        Dim selRows As DataRow() = _insDict.Select(String.Format("{0}='{1}'", INS_CODE, firstSel.Text))
        If selRows.IsNullOrEmpty() Then Return
        Me.ddlInsName.Text = Judgement.JudgeDBNullValue(selRows(0).Item(INS_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbCode.Text = Judgement.JudgeDBNullValue(selRows(0).Item(INS_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbSpec.Text = Judgement.JudgeDBNullValue(selRows(0).Item(INS_SPEC), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbUnit.Text = Judgement.JudgeDBNullValue(selRows(0).Item(INS_UNIT), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbQuantity.Text = String.Empty
    End Sub

    Private Sub lbl_OK_Click(sender As Object, e As EventArgs) Handles lbl_OK.Click
        Dim errorMsg As String = String.Empty
        If Not CheckParameter(errorMsg) Then
            UIMsgBox.Show(errorMsg)
            Return
        End If
        InstrumentInfo = New InstrumentInfo With {.Code = tbCode.Text, .Name = ddlInsName.Text, .Specification = tbSpec.Text, .Unit = tbUnit.Text, .Amount = tbQuantity.Text}
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub lbl_Cancel_Click(sender As Object, e As EventArgs) Handles lbl_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Function CheckParameter(ByRef errorMsg As String) As Boolean
        errorMsg = String.Empty
        If _insDict.IsNullOrEmpty() Then
            errorMsg = MSG_ERROR_INS_DICT_EMPTY
            Return False
        End If
        Dim selRows As DataRow() = _insDict.Select(String.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}'", INS_NAME, ddlInsName.Text, _
                                    INS_CODE, tbCode.Text, INS_SPEC, tbSpec.Text, INS_UNIT, tbUnit.Text))
        'If selRows.IsNullOrEmpty() Then
        '    errorMsg = MSG_ERROR_INS_DICT_FIND_NULL
        '    Return False
        'End If

        If String.IsNullOrEmpty(Me.tbQuantity.Text) Then
            errorMsg = MSG_ERROR_INPUT_AMOUNT
            Return False
        End If

        Return True
    End Function

    Private Sub tbQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQuantity.KeyPress
        '48代表0，57代表9，8代表空格，46代表小数点  
        If ((e.KeyChar < Chr(48) OrElse e.KeyChar > Chr(57)) AndAlso (e.KeyChar <> Chr(8)) AndAlso (e.KeyChar <> Chr(46))) Then e.Handled = True
    End Sub
End Class