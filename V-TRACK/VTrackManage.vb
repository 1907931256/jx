Imports System.Reflection
Imports System.Windows.Forms
Imports ITSBase
Imports ITSBase.Accessory
Imports ITSMaintainmentManager
Imports ITSOperationManager
Imports ITSTraceManager
Imports ITSWareHouseManager

Friend Class VTrackManage

#Region "member"
    Private _operationNoteQuery As FrmOperationNoteQuery
    Private _operationRequestReg As FrmOperationRequestReg
    Private _operationUseFront As FrmOperationUseFront
    Private _operationUseReg As FrmOperationUseReg
    Private _operationRecycleReg As FrmOperationRecycleReg
    Private _highValueDispatchReg As FrmHighValueDispatchReg
    Private _wareHouseInReg As FrmWareHouseInReg
    Private _wareHouseOutReg As FrmWareHouseOutReg
    Private _wareHouseStock As FrmWareHouseStock
    Private _wareHouseInOutQuery As FrmWareHouseInOutQuery
    Private _locationQuery As FrmLocationQuery
    Private _traceQuery As FrmTraceQuery
    Private _workloadAccount As FrmWorkloadAccount
    Private _alertQuery As FrmAlertQuery
    Private _HighValueInReg As FrmHighValueInReg
    Private _insMaintain As FrmInsM
    Private _drugMaintain As FrmDrugM
    Private _drugManufactures As FrmDrugManufacturesM
    Private _sterileRoomMaintain As FrmSterileAreaM
    Private _idCardMaintain As FrmIdCardM
    Private _autoPackageMaintain As FrmAutoPackageM
#End Region
    Public Property PageHost() As Control

    Public Function SwitchToPage(ByVal host As Control, ByVal pageSeletor As PageSelector, Optional initialFunc As Long = Long.MaxValue) As Object
        If host Is Nothing OrElse Not pageSeletor.IsBetween(PageSelector.PageMin, PageSelector.PageMax, False, False) OrElse initialFunc <= 0 Then
            Return Nothing
        End If

        Dim oCurObj As Object = Nothing
        Dim oCurfield As FieldInfo = Nothing
        Dim type As Type = MatchType(pageSeletor)
        For Each oFieldInfo As FieldInfo In Me.GetType.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance)
            If (oFieldInfo.FieldType Is type) Then
                oCurObj = oFieldInfo.GetValue(Me)
                oCurfield = oFieldInfo
                Exit For
            End If
        Next
        If oCurfield Is Nothing Then Return Nothing
        Dim instance As Object = Nothing
        If oCurObj Is Nothing Then
            instance = Activator.CreateInstance(type)
            InstanceEventBind(instance)
            oCurfield.SetValue(Me, instance)
            Logger.WriteLine(String.Format(LOG_INFORMATION_MAINFORM_INNER_CREATE, oCurfield.FieldType.ToString), _
                                            EVENT_ENTRY_TYPE.INFORMATION)
        Else
            instance = oCurObj
        End If

        If Not instance Is Nothing Then
            host.Controls.Clear()
            instance.Dock = DockStyle.Fill
            host.Visible = False
            host.Controls.Add(instance)
            instance.Focus()
            Logger.WriteLine(String.Format(LOG_INFORMATION_MAINFORM_INNER_SWITCH, instance.GetType().ToString), _
                                            EVENT_ENTRY_TYPE.INFORMATION)
            host.Visible = True
        End If

        Return instance
    End Function

    Private Function MatchType(ByVal page As PageSelector) As Type
        Return Microsoft.VisualBasic.Switch( _
            page = PageSelector.OperationNoteQuery, GetType(FrmOperationNoteQuery), _
            page = PageSelector.OperationPreReg, GetType(FrmOperationRequestReg), _
            page = PageSelector.OPerationFrontUse, GetType(FrmOperationUseFront), _
            page = PageSelector.OperationUseReg, GetType(FrmOperationUseReg), _
            page = PageSelector.OperationRecycleReg, GetType(FrmOperationRecycleReg), _
            page = PageSelector.HighValueDispatchReg, GetType(FrmHighValueDispatchReg), _
            page = PageSelector.WareHouseInReg, GetType(FrmWareHouseInReg), _
            page = PageSelector.WareHouseOutReg, GetType(FrmWareHouseOutReg), _
            page = PageSelector.WareHouseStock, GetType(FrmWareHouseStock), _
            page = PageSelector.WareHouseInOutStatisc, GetType(FrmWareHouseInOutQuery), _
            page = PageSelector.LocationQuery, GetType(FrmLocationQuery), _
            page = PageSelector.TraceQuery, GetType(FrmTraceQuery), _
            page = PageSelector.TraceWorkloadAccount, GetType(FrmWorkloadAccount), _
            page = PageSelector.TraceAlertQuery, GetType(FrmAlertQuery), _
            page = PageSelector.HighValueInReg, GetType(FrmHighValueInReg), _
            page = PageSelector.InsMaintainment, GetType(FrmInsM), _
            page = PageSelector.DrugMaintainment, GetType(FrmDrugM), _
            page = PageSelector.AutoPackageMaintainment, GetType(FrmAutoPackageM), _
            page = PageSelector.FactoryMaintainment, GetType(FrmDrugManufacturesM), _
            page = PageSelector.SterileAreaMaintainment, GetType(FrmSterileAreaM), _
            page = PageSelector.IdCardMaintainment, GetType(FrmIdCardM))
    End Function

    Private Sub InstanceEventBind(ByVal instance As Object)
        If instance Is Nothing Then Return

        If TypeOf (instance) Is FrmOperationNoteQuery Then
            AddHandler CType(instance, FrmOperationNoteQuery).SurRequestReg, AddressOf SurRequestRegHandler
            AddHandler CType(instance, FrmOperationNoteQuery).SurUseReg, AddressOf SurUseRegHandler
            AddHandler CType(instance, FrmOperationNoteQuery).SurRecycleReg, AddressOf SurRecycleRegHandler
            AddHandler CType(instance, FrmOperationNoteQuery).SurFrontUseReg, AddressOf SurFrontUseRegHandler
        End If
    End Sub

    Private Sub SurFrontUseRegHandler(ByVal surnoteinfo As SurgeryNoteInfo)
        Dim frmFrontUse As FrmOperationUseFront = SwitchToPage(PageHost, PageSelector.OPerationFrontUse)
        If frmFrontUse IsNot Nothing Then
            frmFrontUse.LoadSurgeryInfo(surnoteinfo)
        End If
    End Sub

    Private Sub SurRecycleRegHandler(ByVal surnoteinfo As SurgeryNoteInfo)
        Dim frmRecycleReg As FrmOperationRecycleReg = SwitchToPage(PageHost, PageSelector.OperationRecycleReg)
        If frmRecycleReg IsNot Nothing Then
            frmRecycleReg.LoadSurgeryInfo(surnoteinfo)
        End If
    End Sub

    Private Sub SurUseRegHandler(ByVal surnoteinfo As SurgeryNoteInfo)
        Dim frmUseReg As FrmOperationUseReg = SwitchToPage(PageHost, PageSelector.OperationUseReg)
        If frmUseReg IsNot Nothing Then
            frmUseReg.LoadSurgeryInfo(surnoteinfo)
        End If
    End Sub

    Private Sub SurRequestRegHandler(ByVal surnoteinfo As SurgeryInfoAccessory.SurgeryNoteInfo)
        Dim frmRequestReg As FrmOperationRequestReg = SwitchToPage(PageHost, PageSelector.OperationPreReg)
        If frmRequestReg IsNot Nothing Then
            frmRequestReg.LoadSurgeryInfo(surnoteinfo)
        End If
    End Sub
End Class
