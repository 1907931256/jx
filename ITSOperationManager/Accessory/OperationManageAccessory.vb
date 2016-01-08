Imports System.Runtime.CompilerServices
Imports DBManager
Imports ITSBase

Namespace Accessory
    Public Module OperationManageExtension
        <Extension> Function TransToTable(ByVal lstDrug As List(Of DrugInfo)) As DataTable
            Return New DataTable()
        End Function

        <Extension> Sub TransFromDataRow(ByVal drugInfo As DrugInfo, ByVal drugRow As DataRow)

        End Sub

        <Extension> Sub TransFromDataRow(ByVal insInfo As InstrumentInfo, ByVal drugRow As DataRow)

        End Sub
    End Module

    Public Module OperationManageAccessory
        Public Class SurgeryRequestMaster
            Private _id As String
            Private _noteId As String
            Private _depId As String
            Private _depName As String
            Private _tableId As String
            Private _emergencyFlag As String
            Private _requestDate As String
            Private _staffId As String
            Private _staffName As String
            Private _memo As String
            Private _status As String
            Private _tableDrug As DataTable
            Private _tableIns As DataTable

            Public Sub New()
                Reset()
            End Sub

            Private Sub Reset()
                _id = String.Empty
                _noteId = String.Empty
                _depId = String.Empty
                _depName = String.Empty
                _tableId = String.Empty
                _emergencyFlag = String.Empty
                _requestDate = String.Empty
                _staffId = String.Empty
                _staffName = String.Empty
                _memo = String.Empty
                _status = String.Empty
                _tableDrug = Nothing
                _tableIns = Nothing
            End Sub

            Public ReadOnly Property TableDrug() As DataTable
                Get
                    If _tableDrug Is Nothing Then
                        Call New DbOperationManage().QueryDrugRequestDetail(_tableDrug, _id) '根据手术申请单号加载药品
                    End If
                    Return _tableDrug
                End Get
            End Property

            Public ReadOnly Property TableInstrument() As DataTable
                Get
                    If _tableIns Is Nothing Then
                        Call New DbOperationManage().QueryInstrumentRequestDetail(_tableIns, _id) '根据手术申请单号加载物品
                    End If
                    Return _tableIns
                End Get
            End Property

            Public ReadOnly Property Id() As String
                Get
                    Return _id
                End Get
            End Property

        End Class

        Public Class SurgeryNoteInfo
            Private _id As String
            Private _orderDate As String
            Private _surId As String
            Private _surName As String
            Private _room As String
            Private _table As String
            Private _visitId As String
            Private _patName As String
            Private _gender As String
            Private _age As String
            Private _surgeon As String
            Private _diagnosis As String
            Private _memo As String
            Private _surgeryRequestMaster As SurgeryRequestMaster '目前只考虑1对1的情况

            Public Sub New()
                Reset()
            End Sub
            Public ReadOnly Property Id() As Object
                Get
                    Return _id
                End Get
            End Property
            Public ReadOnly Property OrderDate() As String
                Get
                    Return _orderDate
                End Get
            End Property

            Public ReadOnly Property SurName() As String
                Get
                    Return _surName
                End Get
            End Property

            Public ReadOnly Property Room() As String
                Get
                    Return _room
                End Get
            End Property

            Public ReadOnly Property Table() As String
                Get
                    Return _table
                End Get
            End Property

            Public ReadOnly Property VisitId() As String
                Get
                    Return _visitId
                End Get
            End Property

            Public ReadOnly Property PatName() As String
                Get
                    Return _patName
                End Get
            End Property

            Public ReadOnly Property Gender() As String
                Get
                    Return _gender
                End Get
            End Property

            Public ReadOnly Property Age() As String
                Get
                    Return _age
                End Get
            End Property

            Public ReadOnly Property Surgeon() As String
                Get
                    Return _surgeon
                End Get
            End Property

            Public ReadOnly Property Diagnosis() As String
                Get
                    Return _diagnosis
                End Get
            End Property

            Public ReadOnly Property Memo() As String
                Get
                    Return _memo
                End Get
            End Property

            Public ReadOnly Property RequestReg() As SurgeryRequestMaster
                Get
                    Return _surgeryRequestMaster
                End Get
            End Property

            Public ReadOnly Property TableDrug() As DataTable
                Get
                    If Me.RequestReg.TableDrug.IsNullOrEmpty() Then
                        Dim predefineDrug As New DataTable
                        Call New DbOperationManage().QueryDrugPredefineDetail(predefineDrug, _surId) '根据手术编号加载默认药品
                        Return predefineDrug
                    Else
                        Return Me.RequestReg.TableDrug
                    End If
                End Get
            End Property

            Public ReadOnly Property TableInstrument() As DataTable
                Get
                    If Me.RequestReg.TableInstrument.IsNullOrEmpty() Then
                        Dim predefineIns As New DataTable
                        Call New DbOperationManage().QueryInstrumentPredefineDetail(predefineIns, _surId) '根据手术编号加载默认物品
                        Return predefineIns
                    Else
                        Return Me.RequestReg.TableInstrument
                    End If
                End Get
            End Property

            Private Sub Reset()
                _id = String.Empty
                _orderDate = String.Empty
                _surId = String.Empty
                _surName = String.Empty
                _room = String.Empty
                _table = String.Empty
                _visitId = String.Empty
                _patName = String.Empty
                _gender = String.Empty
                _age = String.Empty
                _surgeon = String.Empty
                _diagnosis = String.Empty
                _memo = String.Empty
                _surgeryRequestMaster = New SurgeryRequestMaster()
            End Sub

            Public Function TransFromDataRow(ByVal dr As DataRow) As Boolean
                If dr Is Nothing Then Return False
                Dim arrCols = New String() {OPN_ID, TEXT_ORDER_DATE, TEXT_PATIENT_NAME, OPN_OPERATION_ID, DBConstDef.TEXT_OPERATION_NAME, TEXT_ROOM_NAME, TEXT_TABLE_ID, _
                                            TEXT_VISIT_ID, TEXT_GENDER, TEXT_AGE, TEXT_DOCTOR_NAME, TEXT_DIAGNOSIS, TEXT_DR_MEMO}
                If Not (arrCols.All(Function(col) dr.Table.Columns.Contains(col))) Then Return False
                _id = dr.Item(OPN_ID)
                _orderDate = CDate(Judgement.JudgeDBNullValue(dr.Item(TEXT_ORDER_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString()
                _patName = Judgement.JudgeDBNullValue(dr.Item(TEXT_PATIENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _surId = Judgement.JudgeDBNullValue(dr.Item(OPN_OPERATION_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _surName = Judgement.JudgeDBNullValue(dr.Item(DBConstDef.TEXT_OPERATION_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _room = Judgement.JudgeDBNullValue(dr.Item(TEXT_ROOM_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _table = Judgement.JudgeDBNullValue(dr.Item(TEXT_TABLE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _visitId = Judgement.JudgeDBNullValue(dr.Item(TEXT_VISIT_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _gender = Judgement.JudgeDBNullValue(dr.Item(TEXT_GENDER), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _age = Judgement.JudgeDBNullValue(dr.Item(TEXT_AGE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _surgeon = Judgement.JudgeDBNullValue(dr.Item(TEXT_DOCTOR_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _diagnosis = Judgement.JudgeDBNullValue(dr.Item(TEXT_DIAGNOSIS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _memo = Judgement.JudgeDBNullValue(dr.Item(TEXT_DR_MEMO), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Return True
            End Function
        End Class

        Public Class DrugInfo
            Public CommonName As String
            Public ProductName As String
            Public Specification As String
            Public Factory As String
            Public Unit As String
            Public Amount As String

            Public Sub TransToDataRow(ByRef belongTable As DataTable)
                If belongTable Is Nothing Then Return
                Dim newRow As DataRow = belongTable.NewRow()
                If (belongTable.Columns.Contains(TEXT_DRUG_COMMON_NAME)) Then newRow.Item(TEXT_DRUG_COMMON_NAME) = CommonName
                If (belongTable.Columns.Contains(TEXT_DRUG_PRODUCT_NAME)) Then newRow.Item(TEXT_DRUG_PRODUCT_NAME) = ProductName
                If (belongTable.Columns.Contains(TEXT_DRUG_SPECIFICATION)) Then newRow.Item(TEXT_DRUG_SPECIFICATION) = Specification
                If (belongTable.Columns.Contains(TEXT_DRUG_FACTORY)) Then newRow.Item(TEXT_DRUG_FACTORY) = Factory
                If (belongTable.Columns.Contains(TEXT_DRUG_UNIT)) Then newRow.Item(TEXT_DRUG_UNIT) = Unit
                If (belongTable.Columns.Contains(TEXT_DRUG_AMOUNT)) Then newRow.Item(TEXT_DRUG_AMOUNT) = Amount
                belongTable.Rows.Add(newRow)
            End Sub
        End Class

        Public Class InstrumentInfo
            Public Code As String
            Public Name As String
            Public Specification As String
            Public Unit As String
            Public Amount As String

            Public Sub TransToDataRow(ByRef belongTable As DataTable)
                If belongTable Is Nothing Then Return
                Dim newRow As DataRow = belongTable.NewRow()
                If (belongTable.Columns.Contains(TEXT_INS_CODE)) Then newRow.Item(TEXT_INS_CODE) = Code
                If (belongTable.Columns.Contains(TEXT_INS_NAME)) Then newRow.Item(TEXT_INS_NAME) = Name
                If (belongTable.Columns.Contains(TEXT_INS_SPECIFICATION)) Then newRow.Item(TEXT_INS_SPECIFICATION) = Specification
                If (belongTable.Columns.Contains(TEXT_INS_UNIT)) Then newRow.Item(TEXT_INS_UNIT) = Unit
                If (belongTable.Columns.Contains(TEXT_INS_AMOUNT)) Then newRow.Item(TEXT_INS_AMOUNT) = Amount
                belongTable.Rows.Add(newRow)
            End Sub
        End Class
    End Module
End Namespace