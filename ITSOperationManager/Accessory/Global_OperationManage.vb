Imports DBManager
Imports ITSBase
Imports ITSBase.Accessory

Namespace Accessory

    Public Class GlobalOperationManage

        Public Shared Function GetSurgeryDrug(ByVal surNoteInfo As SurgeryNoteInfo) As DataTable
            If surNoteInfo Is Nothing Then Return Nothing
            Dim returnTable As New DataTable
            Call New DbOperationManage().QueryDrugRequestDetail(returnTable, surNoteInfo.Id) '根据手术编号加载药品
            If returnTable.IsNullOrEmpty() Then
                Call New DbOperationManage().QueryDrugPredefineDetail(returnTable, surNoteInfo.SurId) '根据手术编号加载默认药品
            End If
            Return returnTable
        End Function

        Public Shared Function GetSurgeryInstrument(ByVal surNoteInfo As SurgeryNoteInfo) As DataTable
            If surNoteInfo Is Nothing Then Return Nothing
            Dim returnTable As New DataTable
            Call New DbOperationManage().QueryInstrumentRequestDetail(returnTable, surNoteInfo.Id) '根据手术编号加载物品
            If returnTable.IsNullOrEmpty() Then
                Call New DbOperationManage().QueryInstrumentPredefineDetail(returnTable, surNoteInfo.SurId) '根据手术编号加载默认物品
            End If
            Return returnTable
        End Function
        Public Shared Function GetSurgeryDrug(ByVal strOperationID As String) As DataTable
            If strOperationID = String.Empty Then Return Nothing
            Dim returnTable As New DataTable
            Call New DbOperationManage().QueryDrugRequestDetail(returnTable, strOperationID) '根据手术编号加载药品
            If returnTable.IsNullOrEmpty() Then
                Call New DbOperationManage().QueryDrugPredefineDetail(returnTable, strOperationID) '根据手术编号加载默认药品
            End If
            Return returnTable
        End Function

        Public Shared Function GetSurgeryInstrument(ByVal strOperationID As String) As DataTable
            If strOperationID = String.Empty Then Return Nothing
            Dim returnTable As New DataTable
            Call New DbOperationManage().QueryInstrumentRequestDetail(returnTable, strOperationID) '根据手术编号加载物品
            If returnTable.IsNullOrEmpty() Then
                Call New DbOperationManage().QueryInstrumentPredefineDetail(returnTable, strOperationID) '根据手术编号加载默认物品
            End If
            Return returnTable
        End Function
    End Class
End Namespace