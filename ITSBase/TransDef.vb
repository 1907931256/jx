Public Module TransDef
    Public Function MatchUserRoleToString(ByVal nKind As Short) As String
        Select Case nKind
            Case USER_ROLE.DEPARTMENT_COMMONS
                Return TEXT_DP_COMMONS
            Case USER_ROLE.OPERATE_COMMONS
                Return TEXT_OP_COMMONS
            Case USER_ROLE.CSSD_COMMONS
                Return TEXT_CSSD_COMMONS
            Case USER_ROLE.CSSD_ADMINISTRATOR
                Return TEXT_CSSD_ADMINISTRATOR
            Case USER_ROLE.CSSD_BROWSER
                Return TEXT_CSSD_BROWSER
            Case USER_ROLE.DEPARTMENT_ADMINISTRATOR
                Return TEXT_DP_ADMINISTRATOR
            Case Else
                Return ""
        End Select
    End Function
    Public Function MatchUserRoleToShort(ByVal strKind As String) As Short
        Select Case strKind
            Case TEXT_DP_COMMONS
                Return USER_ROLE.DEPARTMENT_COMMONS
            Case TEXT_CSSD_COMMONS
                Return USER_ROLE.CSSD_COMMONS
            Case TEXT_CSSD_ADMINISTRATOR
                Return USER_ROLE.CSSD_ADMINISTRATOR
            Case TEXT_OP_COMMONS
                Return USER_ROLE.OPERATE_COMMONS
            Case TEXT_DP_ADMINISTRATOR
                Return USER_ROLE.DEPARTMENT_ADMINISTRATOR
            Case Else
                Return USER_ROLE.ROLE_NULL
        End Select
    End Function
    Public Function MatchDBTypeToString(ByVal eKind As EVENT_DBTYPE) As String
        Select Case eKind
            Case EVENT_DBTYPE.SQL_Server
                Return TEXT_CONST_DBTYPE_SQL_SERVER
            Case EVENT_DBTYPE.Oracle
                Return TEXT_CONST_DBTYPE_ORACLE
        End Select
        Return String.Empty
    End Function
    Public Function MatchStringToDBType(ByVal strKind As String) As EVENT_DBTYPE
        Select Case strKind
            Case TEXT_CONST_DBTYPE_SQL_SERVER
                Return EVENT_DBTYPE.SQL_SERVER
            Case TEXT_CONST_DBTYPE_ORACLE
                Return EVENT_DBTYPE.ORACLE
        End Select
        Return EVENT_DBTYPE.NONE
    End Function
    Public Function MatchStringToEnumNoteStatus(ByVal strKind As String) As OPerationNoteState
        Select Case strKind
            Case TEXT_CONT_NOTE_STATUS_NULL
                Return OPerationNoteState.UnConfirmed
            Case TEXT_CONT_NOTE_STATUS_REQUEST
                Return OPerationNoteState.Requested
            Case TEXT_CONT_NOTE_STATUS_USE_COMFIRED
                Return OPerationNoteState.SurgeryConfirm
            Case TEXT_CONT_NOTE_STATUS_USED
                Return OPerationNoteState.SurgeryEnd
            Case TEXT_CONT_NOTE_STATUS_RETURN
                Return OPerationNoteState.SurgeryReturn
            Case TEXT_CONT_NOTE_STATUS_cancel
                Return OPerationNoteState.SurgeryCancel
        End Select
        Return EVENT_DBTYPE.NONE
    End Function
    Public Function MatchNoteStatusToString(ByVal strKind As OPerationNoteState) As String
        Select Case strKind
            Case OPerationNoteState.UnConfirmed
                Return TEXT_CONT_NOTE_STATUS_NULL
            Case OPerationNoteState.Requested
                Return TEXT_CONT_NOTE_STATUS_REQUEST
            Case OPerationNoteState.SurgeryConfirm
                Return TEXT_CONT_NOTE_STATUS_USE_COMFIRED
            Case OPerationNoteState.SurgeryEnd
                Return TEXT_CONT_NOTE_STATUS_USED
            Case OPerationNoteState.SurgeryReturn
                Return TEXT_CONT_NOTE_STATUS_RETURN
            Case OPerationNoteState.SurgeryCancel
                Return TEXT_CONT_NOTE_STATUS_CANCEL
        End Select
        Return EVENT_DBTYPE.NONE
    End Function
#Region "SQL Method"
    Public Function MakeSQLLIKEPattern(ByVal strInput As String) As String
        Dim strOutput As String = strInput
        strOutput = strOutput.Replace("[", "[[]")
        strOutput = strOutput.Replace("%", "[%]")
        strOutput = strOutput.Replace("_", "[_]")
        strOutput = strOutput.Replace("^", "[^]")
        strOutput = strOutput.Replace("*", "[*]")
        strOutput = strOutput.Replace("'", "''")
        Return strOutput
    End Function
    Public Function MakeSQLInputPattern(ByVal strInput As String) As String
        If strInput Is Nothing Then Return String.Empty
        Return strInput.Replace("'", "''")
    End Function
#End Region
    Public Function MatchAlignStyleToConstals(ByVal strName As String) As Excel.Constants
        Select Case strName
            Case XML_STR_ATTRIBUTE_ALIGN_LEFT
                Return Excel.Constants.xlLeft
            Case XML_STR_ATTRIBUTE_ALIGN_CENTER
                Return Excel.Constants.xlCenter
            Case XML_STR_ATTRIBUTE_ALIGN_RIGHT
                Return Excel.Constants.xlRight
            Case Else
                Return Excel.Constants.xlCenter
        End Select
    End Function
    Public Function MatchStringToStelizeRoomINSInOutType(ByVal strText As String) As SR_LOG_INOUT_TYPE
        Select Case strText
            Case TEXT_WH_IN
                Return SR_LOG_INOUT_TYPE.WH_IN
            Case TEXT_WH_IN_BALANCE
                Return SR_LOG_INOUT_TYPE.WH_IN_BALANCE
            Case TEXT_WH_OUT_BALANCE
                Return SR_LOG_INOUT_TYPE.WH_OUT_BALANCE
            Case TEXT_WH_OUT_EXPIRED
                Return SR_LOG_INOUT_TYPE.WH_OUT_EXPIRED
            Case TEXT_WH_OUT_OTHER
                Return SR_LOG_INOUT_TYPE.WH_OUT_OTHER
            Case TEXT_HV_IN_STOCK
                Return SR_LOG_INOUT_TYPE.HV_IN_STOCK
            Case TEXT_HV_OUT_BACK
                Return SR_LOG_INOUT_TYPE.HV_OUT_BACK
            Case TEXT_HV_OUT_DISPATCH
                Return SR_LOG_INOUT_TYPE.HV_OUT_DISPATCH
            Case TEXT_HV_OUT_USED
                Return SR_LOG_INOUT_TYPE.HV_OUT_USED
            Case Else
                Return SR_LOG_INOUT_TYPE.INOUT_TYPE_NULL
        End Select
    End Function
    Public Function MatchStelizeRoomINSInOutTypeToString(ByVal eType As SR_LOG_INOUT_TYPE) As String
        Select Case eType
            Case SR_LOG_INOUT_TYPE.WH_IN
                Return TEXT_WH_IN
            Case SR_LOG_INOUT_TYPE.WH_IN_BALANCE
                Return TEXT_WH_IN_BALANCE
            Case SR_LOG_INOUT_TYPE.WH_OUT_BALANCE
                Return TEXT_WH_OUT_BALANCE
            Case SR_LOG_INOUT_TYPE.WH_OUT_EXPIRED
                Return TEXT_WH_OUT_EXPIRED
            Case SR_LOG_INOUT_TYPE.WH_OUT_OTHER
                Return TEXT_WH_OUT_OTHER
            Case SR_LOG_INOUT_TYPE.HV_IN_DISPATCH
                Return TEXT_HV_IN_DISPATCH
                Return TEXT_HV_IN_STERILZE
            Case SR_LOG_INOUT_TYPE.HV_IN_STOCK
                Return TEXT_HV_IN_STOCK
            Case SR_LOG_INOUT_TYPE.HV_OUT_BACK
                Return TEXT_HV_OUT_BACK
            Case SR_LOG_INOUT_TYPE.HV_OUT_DISPATCH
                Return TEXT_HV_OUT_DISPATCH
            Case SR_LOG_INOUT_TYPE.HV_OUT_USED
                Return TEXT_HV_OUT_USED
            Case Else
                Return String.Empty
        End Select
    End Function
    Public Function MatchCheckStringToState(ByVal strCheck As String) As Short
        Select Case strCheck
            Case TEXT_RESULT_OK
                Return CHECK_RESULT.PASS
            Case TEXT_RESULT_FAILD
                Return CHECK_RESULT.FAILD
            Case Else
                Return CHECK_RESULT.PASS
        End Select

    End Function
    Public Function MatchCheckStateToString(ByVal eCheck As PACKAGE_STATE) As String
        Select Case eCheck
            Case CHECK_RESULT.PASS
                Return TEXT_RESULT_OK
            Case CHECK_RESULT.FAILD
                Return TEXT_RESULT_FAILD
            Case Else
                Return String.Empty
        End Select

    End Function

    Public Function MatchInsKindToString(ByVal insKind As INS_KINDS) As String
        Select Case insKind
            Case INS_KINDS.WAREHOUSE_SU
                Return TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS
            Case INS_KINDS.HIGH_VALUE
                Return TEXT_WAREHOUSE_IN_REG_TYPE_HIGN_VALUE
            Case INS_KINDS.OP_INSTRUMENTS
                Return TEXT_WAREHOUSE_IN_REG_TYPE_DRUG
            Case Else
                Return String.Empty
        End Select
    End Function

    Public Function MatchSterileRoomTypeToString(ByVal type As STERILE_ROOM_TYPE) As String
        Select Case type
            Case STERILE_ROOM_TYPE.CSSD
                Return TEXT_CSSD_STERILEROOM
            Case STERILE_ROOM_TYPE.OP
                Return TEXT_OP_STERILEROOM
            Case STERILE_ROOM_TYPE.FACILITY
                Return TEXT_FACILITY_STERILEROOM
            Case Else
                Return String.Empty
        End Select
    End Function


End Module
