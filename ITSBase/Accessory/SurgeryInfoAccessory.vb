Imports System.Runtime.CompilerServices

Namespace Accessory
    Public Module OperationManageExtension

    End Module

    Public Module SurgeryInfoAccessory
        Public Class SurgeryRequestMaster
            Private _id As String
            Private _noteId As String
            Private _depId As String
            Private _depName As String
            Private _room As String
            Private _tableId As String
            Private _emergencyFlag As String
            Private _requestDate As String
            Private _staffId As String
            Private _staffName As String
            Private _memo As String
            Private _status As String

            Public Sub New()
                Reset()
            End Sub

            Private Sub Reset()
                _id = String.Empty
                _noteId = String.Empty
                _depId = String.Empty
                _depName = String.Empty
                _room = String.Empty
                _tableId = String.Empty
                _emergencyFlag = String.Empty
                _requestDate = String.Empty
                _staffId = String.Empty
                _staffName = String.Empty
                _memo = String.Empty
                _status = String.Empty
            End Sub

            Public Property Id() As String
                Get
                    Return _id
                End Get
                Set(ByVal value As String)
                    _id = value
                End Set
            End Property

            Public Function TransFromDataRow(ByVal dr As DataRow) As Boolean
                If dr Is Nothing Then Return False
                Dim arrCols = New String() {DR_ID, DR_OPN_REG_ID, DR_ROOM_NAME, DR_TABLE_ID}
                If Not (arrCols.All(Function(col) dr.Table.Columns.Contains(col))) Then Return False
                _id = Judgement.JudgeDBNullValue(dr.Item(DR_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _noteId = Judgement.JudgeDBNullValue(dr.Item(DR_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Return True
            End Function
        End Class

        Public Class SurgerUseMaster
            Private _id As String
            Private _noteId As String

            Public Property Id() As String
                Get
                    Return _id
                End Get
                Set(ByVal value As String)
                    _id = value
                End Set
            End Property

            Public Function TransFromDataRow(ByVal dr As DataRow) As Boolean
                If dr Is Nothing Then Return False
                Dim arrCols = New String() {UM_ID, UM_OPN_REG_ID}
                If Not (arrCols.All(Function(col) dr.Table.Columns.Contains(col))) Then Return False
                _id = Judgement.JudgeDBNullValue(dr.Item(UM_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _noteId = Judgement.JudgeDBNullValue(dr.Item(UM_OPN_REG_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                Return True
            End Function
        End Class

        Public Class SurgeryNoteInfo
            Private _id As String
            Private _orderDate As String
            Private _surId As String
            Private _surName As String
            Private _roomID As String
            Private _room As String
            Private _table As String
            Private _visitId As String
            Private _patName As String
            Private _gender As String
            Private _age As String
            Private _Weight As String
            Private _departmentName As String
            Private _departmentID As String
            Private _surgeon As String
            Private _diagnosis As String
            Private _memo As String
            Private _surgeryRequestMaster As SurgeryRequestMaster '目前只考虑1对1的情况
            Private _surgeryUseMaster As SurgerUseMaster
            Private _noteStatus As OPerationNoteState

            Public Sub New()
                Reset()
            End Sub
            Public Property Id() As Object
                Get
                    Return _id
                End Get
                Set(value As Object)
                    _id = value
                End Set
            End Property
            Public Property Weight() As Object
                Get
                    Return _Weight
                End Get
                Set(value As Object)
                    _Weight = value
                End Set
            End Property
            Public Property DepartmentName() As String
                Get
                    Return _departmentName
                End Get
                Set(value As String)
                    _departmentName = value
                End Set

            End Property
            Public Property DepartmentID() As String
                Get
                    Return _departmentID
                End Get
                Set(value As String)
                    _departmentID = value
                End Set

            End Property
            Public Property SurId() As Object
                Get
                    Return _surId
                End Get
                Set(value As Object)
                    _surId = value
                End Set
            End Property
            Public Property OrderDate() As String
                Get
                    Return _orderDate
                End Get
                Set(value As String)
                    _orderDate = value
                End Set

            End Property

            Public Property SurName() As String
                Get
                    Return _surName
                End Get
                Set(value As String)
                    _surName = value
                End Set
            End Property

            Public Property Room() As String
                Get
                    Return _room
                End Get
                Set(value As String)
                    _room = value
                End Set
            End Property
            Public Property RoomID() As String
                Get
                    Return _roomID
                End Get
                Set(value As String)
                    _roomID = value
                End Set
            End Property

            Public Property Table() As String
                Get
                    Return _table
                End Get
                Set(value As String)
                    _table = value
                End Set
            End Property

            Public Property VisitId() As String
                Get
                    Return _visitId
                End Get
                Set(value As String)
                    _visitId = value
                End Set
            End Property

            Public Property PatName() As String
                Get
                    Return _patName
                End Get
                Set(value As String)
                    _patName = value
                End Set
            End Property

            Public Property Gender() As String
                Get
                    Return _gender
                End Get
                Set(value As String)
                    _gender = value
                End Set
            End Property

            Public Property Age() As String
                Get
                    Return _age
                End Get
                Set(value As String)
                    _age = value
                End Set
            End Property

            Public Property Surgeon() As String
                Get
                    Return _surgeon
                End Get
                Set(value As String)
                    _surgeon = value
                End Set
            End Property

            Public Property Diagnosis() As String
                Get
                    Return _diagnosis
                End Get
                Set(value As String)
                    _diagnosis = value
                End Set
            End Property

            Public Property Memo() As String
                Get
                    Return _memo
                End Get
                Set(value As String)
                    _memo = value
                End Set
            End Property

            Public ReadOnly Property RequestReg() As SurgeryRequestMaster
                Get
                    Return _surgeryRequestMaster
                End Get
            End Property

            Public ReadOnly Property UseReg() As SurgerUseMaster
                Get
                    Return _surgeryUseMaster
                End Get
            End Property
            Public Property NoteStatus() As OPerationNoteState
                Get
                    Return _noteStatus
                End Get
                Set(value As OPerationNoteState)
                    _noteStatus = value
                End Set
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
                _surgeryUseMaster = New SurgerUseMaster()
                _noteStatus = OPerationNoteState.UnConfirmed
            End Sub

            Public Function TransFromDataRow(ByVal dr As DataRow) As Boolean
                If dr Is Nothing Then Return False
                Dim arrCols = New String() {OPN_ID, TEXT_ORDER_DATE, TEXT_PATIENT_NAME, OPN_OPERATION_ID, TEXT_OPERATION_NAME, TEXT_ROOM_NAME, TEXT_TABLE_ID, _
                                            TEXT_VISIT_ID, TEXT_GENDER, TEXT_AGE, TEXT_DOCTOR_NAME, TEXT_DIAGNOSIS, TEXT_DR_MEMO, TEXT_OPERATION_STATUS}
                If Not (arrCols.All(Function(col) dr.Table.Columns.Contains(col))) Then Return False
                _id = dr.Item(OPN_ID)
                _orderDate = CDate(Judgement.JudgeDBNullValue(dr.Item(TEXT_ORDER_DATE), ENUM_DATA_TYPE.DATA_TYPE_DATE)).ToString()
                _patName = Judgement.JudgeDBNullValue(dr.Item(TEXT_PATIENT_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _surId = Judgement.JudgeDBNullValue(dr.Item(OPN_OPERATION_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _surName = Judgement.JudgeDBNullValue(dr.Item(TEXT_OPERATION_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _room = Judgement.JudgeDBNullValue(dr.Item(TEXT_ROOM_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _table = Judgement.JudgeDBNullValue(dr.Item(TEXT_TABLE_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _visitId = Judgement.JudgeDBNullValue(dr.Item(TEXT_VISIT_ID), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _gender = Judgement.JudgeDBNullValue(dr.Item(TEXT_GENDER), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _age = Judgement.JudgeDBNullValue(dr.Item(TEXT_AGE), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _surgeon = Judgement.JudgeDBNullValue(dr.Item(TEXT_DOCTOR_NAME), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _diagnosis = Judgement.JudgeDBNullValue(dr.Item(TEXT_DIAGNOSIS), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _memo = Judgement.JudgeDBNullValue(dr.Item(TEXT_DR_MEMO), ENUM_DATA_TYPE.DATA_TYPE_STRING)
                _noteStatus = MatchStringToEnumNoteStatus(Judgement.JudgeDBNullValue(dr.Item(TEXT_OPERATION_STATUS), ENUM_DATA_TYPE.DATA_TYPE_STRING))
                Return True
            End Function
        End Class

        Public Class DrugInfo
            Public strDrugID As String
            Public CommonName As String
            Public ProductName As String
            Public Specification As String
            Public Factory As String
            Public Unit As String
            Public Amount As String

            Public Sub TransToDataRow(ByRef belongTable As DataTable)
                If belongTable Is Nothing Then Return
                For Each dr As DataRow In belongTable.Rows
                    If (belongTable.Columns.Contains(TEXT_DRUG_ID)) Then
                        If dr.Item(TEXT_DRUG_ID).Equals(strDrugID) Then
                            If (belongTable.Columns.Contains(TEXT_DRUG_AMOUNT)) Then
                                dr.Item(TEXT_DRUG_AMOUNT) = CLng(dr.Item(TEXT_DRUG_AMOUNT)) + CLng(Amount)
                                Exit Sub
                            End If
                        End If
                    End If
                Next
                Dim newRow As DataRow = belongTable.NewRow()
                If (belongTable.Columns.Contains(TEXT_DRUG_ID)) Then newRow.Item(TEXT_DRUG_ID) = strDrugID
                If (belongTable.Columns.Contains(TEXT_DRUG_COMMON_NAME)) Then newRow.Item(TEXT_DRUG_COMMON_NAME) = CommonName
                If (belongTable.Columns.Contains(TEXT_DRUG_PRODUCT_NAME)) Then newRow.Item(TEXT_DRUG_PRODUCT_NAME) = ProductName
                If (belongTable.Columns.Contains(TEXT_DRUG_SPECIFICATION)) Then newRow.Item(TEXT_DRUG_SPECIFICATION) = Specification
                If (belongTable.Columns.Contains(TEXT_DRUG_FACTORY)) Then newRow.Item(TEXT_DRUG_FACTORY) = Factory
                If (belongTable.Columns.Contains(TEXT_DRUG_UNIT)) Then newRow.Item(TEXT_DRUG_UNIT) = Unit
                If (belongTable.Columns.Contains(TEXT_DRUG_AMOUNT)) Then newRow.Item(TEXT_DRUG_AMOUNT) = Amount
                belongTable.Rows.Add(newRow)
            End Sub

            Public Sub TransFromDataRow(ByVal drugRow As DataRow)
                If drugRow Is Nothing Then Return
                If (drugRow.Table.Columns.Contains(TEXT_DRUG_ID)) Then Me.CommonName = drugRow.Item(TEXT_DRUG_ID).ToString()
                If (drugRow.Table.Columns.Contains(TEXT_DRUG_COMMON_NAME)) Then Me.CommonName = drugRow.Item(TEXT_DRUG_COMMON_NAME).ToString()
                If (drugRow.Table.Columns.Contains(TEXT_DRUG_PRODUCT_NAME)) Then Me.ProductName = drugRow.Item(TEXT_DRUG_PRODUCT_NAME).ToString()
                If (drugRow.Table.Columns.Contains(TEXT_DRUG_SPECIFICATION)) Then Me.Specification = drugRow.Item(TEXT_DRUG_SPECIFICATION).ToString()
                If (drugRow.Table.Columns.Contains(TEXT_DRUG_FACTORY)) Then Me.Factory = drugRow.Item(TEXT_DRUG_FACTORY).ToString()
                If (drugRow.Table.Columns.Contains(TEXT_DRUG_UNIT)) Then Me.Unit = drugRow.Item(TEXT_DRUG_UNIT).ToString()
                If (drugRow.Table.Columns.Contains(TEXT_DRUG_AMOUNT)) Then Me.Amount = drugRow.Item(TEXT_DRUG_AMOUNT).ToString()
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
                For Each dr As DataRow In belongTable.Rows
                    If (belongTable.Columns.Contains(TEXT_INS_CODE)) Then
                        If dr.Item(TEXT_INS_CODE).Equals(Code) Then
                            If (belongTable.Columns.Contains(TEXT_INS_AMOUNT)) Then
                                dr.Item(TEXT_INS_AMOUNT) = CLng(dr.Item(TEXT_INS_AMOUNT)) + CLng(Amount)
                                Exit Sub
                            End If
                        End If
                    End If
                Next
                Dim newRow As DataRow = belongTable.NewRow()
                If (belongTable.Columns.Contains(TEXT_INS_CODE)) Then newRow.Item(TEXT_INS_CODE) = Code
                If (belongTable.Columns.Contains(TEXT_INS_NAME)) Then newRow.Item(TEXT_INS_NAME) = Name
                If (belongTable.Columns.Contains(TEXT_INS_SPECIFICATION)) Then newRow.Item(TEXT_INS_SPECIFICATION) = Specification
                If (belongTable.Columns.Contains(TEXT_INS_UNIT)) Then newRow.Item(TEXT_INS_UNIT) = Unit
                If (belongTable.Columns.Contains(TEXT_INS_AMOUNT)) Then newRow.Item(TEXT_INS_AMOUNT) = Amount
                belongTable.Rows.Add(newRow)
            End Sub

            Public Sub TransFromDataRow(ByVal insRow As DataRow)
                If insRow Is Nothing Then Return
                If (insRow.Table.Columns.Contains(TEXT_INS_CODE)) Then Me.Code = insRow.Item(TEXT_INS_CODE).ToString()
                If (insRow.Table.Columns.Contains(TEXT_INS_NAME)) Then Me.Name = insRow.Item(TEXT_INS_NAME).ToString()
                If (insRow.Table.Columns.Contains(TEXT_INS_SPECIFICATION)) Then Me.Specification = insRow.Item(TEXT_INS_SPECIFICATION).ToString()
                If (insRow.Table.Columns.Contains(TEXT_INS_UNIT)) Then Me.Unit = insRow.Item(TEXT_INS_UNIT).ToString()
                If (insRow.Table.Columns.Contains(TEXT_INS_AMOUNT)) Then Me.Amount = insRow.Item(TEXT_INS_AMOUNT).ToString()
            End Sub
        End Class
    End Module
End Namespace