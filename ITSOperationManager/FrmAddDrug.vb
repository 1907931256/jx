Imports System.Windows.Forms
Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory
Imports UIControlLib

Public Class FrmAddDrug
    Public DrugInfo As DrugInfo
    Private _drugDict As DataTable
    Private m_strDrugCode As String = String.Empty

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmAddDrug_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialDrugInfo()
    End Sub

    Private Sub lbl_OK_Click(sender As Object, e As EventArgs) Handles lbl_OK.Click
        Dim errorMsg As String = String.Empty
        If Not CheckParameter(errorMsg) Then
            UIMsgBox.Show(errorMsg)
            Return
        End If
        DrugInfo = New DrugInfo With {.CommonName = tbCommonName.Text, .ProductName = tbProductName.Text, .Specification = tbSpec.Text, .Factory = tbManufacture.Text, .Unit = tbUnit.Text, .Amount = tbQuantity.Text, .strDrugID = m_strDrugCode}
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub lbl_Cancel_Click(sender As Object, e As EventArgs) Handles lbl_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub InitialDrugInfo()
        _drugDict = New DataTable()
        Dim operationManage As New DbOperationManage
        If EnumDef.DBMEDITS_RESULT.SUCCESS = operationManage.QueryDrugInfo(_drugDict) AndAlso Not _drugDict.IsNullOrEmpty() Then
            AddHandler tbCommonName.PressEnter, AddressOf CommonNamePressEnter
            tbCommonName.ColNoOfCode = 2
            tbCommonName.IDIndex = 0
            With tbCommonName
                .DisplayIndex = 1
                .ColumnWidthCollection = New Short() {0, 100, 0, 150, 0, 100, 125, 50}
                .Attach(CType(tbCommonName, TextBox), _drugDict)
            End With
        End If
    End Sub

    Private Sub CommonNamePressEnter()
        If _drugDict.IsNullOrEmpty() Then Return
        Dim firstSel As ListViewItem = tbCommonName.GetFirstSelListItem()
        If firstSel Is Nothing Then Return
        Dim selRows As DataRow() = _drugDict.Select(String.Format("{0}='{1}'", DRUG_CODE, firstSel.Text))
        If selRows.IsNullOrEmpty() Then Return
        m_strDrugCode = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_CODE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbCommonName.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_COMMON_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbProductName.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_PRODUCT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbSpec.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_SPECIFICATION), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbManufacture.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_MANUFACTURERS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbUnit.Text = Judgement.JudgeDBNullValue(selRows(0).Item(DRUG_MEASUER_UNITS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
        Me.tbQuantity.Text = String.Empty
    End Sub

    Private Function CheckParameter(ByRef errorMsg As String) As Boolean
        errorMsg = String.Empty
        If _drugDict.IsNullOrEmpty() Then
            errorMsg = MSG_ERROR_DRUG_DICT_EMPTY
            Return False
        End If
        Dim selRows As DataRow() = _drugDict.Select(String.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}='{9}'", DRUG_COMMON_NAME, tbCommonName.Text, _
                                    DRUG_PRODUCT_NAME, tbProductName.Text, DRUG_SPECIFICATION, tbSpec.Text, DRUG_MANUFACTURERS, tbManufacture.Text, DRUG_MEASUER_UNITS, tbUnit.Text))
        If selRows.IsNullOrEmpty() Then
            errorMsg = MSG_ERROR_DRUG_DICT_FIND_NULL
            Return False
        End If

        If String.IsNullOrEmpty(Me.tbQuantity.Text) Then
            errorMsg = MSG_ERROR_INPUT_AMOUNT
            Me.tbQuantity.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub tbQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQuantity.KeyPress
        '48代表0，57代表9，8代表空格，46代表小数点  
        If ((e.KeyChar < Chr(48) OrElse e.KeyChar > Chr(57)) AndAlso (e.KeyChar <> Chr(8)) AndAlso (e.KeyChar <> Chr(46))) Then e.Handled = True
    End Sub
End Class