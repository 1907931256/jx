Imports ITSBase

Public Class DbTraceLayout
    Inherits DbOperateSummery

    Public Function InsertLayoutInfo(name As String, width As Integer, height As Integer, ByRef layoutId As Long) As Boolean
        Dim insertSql As String = String.Format("Insert into trace_layout_info(name,init_width,init_height,create_time) values ('{0}',{1},{2},sysdate)", name, width, height)
        If UpdateOleDb(insertSql) Then
            Return GetPrimaryKeyValue(layoutId, "Seq_trace_layout_info_id")
        Else
            Return False
        End If
    End Function

    Public Function InsertLayoutDetail(ByVal layoutId As Long, ByVal parentId As Long, ByVal name As String, ByVal type As Integer, ByVal width As Integer, ByVal height As Integer, ByVal openAt As Integer, ByVal openStart As Double, ByVal openRatio As Double, ByVal dock As Integer, ByVal displayText As String, ByRef currentId As Long) As Boolean
        Dim insertSql As String = String.Format("Insert into trace_layout_detail(layout_id,parent_id,name,type,init_width,init_height,open_at,open_start,open_ratio,dock,text) values ({0},{1},'{2}',{3},{4},{5},{6},{7},{8},{9},'{10}')", layoutId, parentId, name, type, width, height, openAt, openStart, openRatio, dock, displayText)
        If UpdateOleDb(insertSql) Then
            Return GetPrimaryKeyValue(currentId, "Seq_trace_layout_detail_id")
        Else
            Return False
        End If
    End Function

    Public Function QueryCardInfo(ByRef returnTable As DataTable) As EnumDef.DBMEDITS_RESULT
        Const cardSql As String = "Select * from trace_id_info where valid = 1 order by code"
        Return QueryTable(cardSql, returnTable)
    End Function

    Public Function QueryLayoutInfoByName(ByRef returnTable As DataTable, ByVal layoutName As String) As EnumDef.DBMEDITS_RESULT
        Dim layoutSql As String = String.Format("select * from trace_layout_info where name='{0}'", layoutName)
        Return QueryTable(layoutSql, returnTable)
    End Function

    Public Function QueryLayoutDetails(ByRef returnTable As DataTable, ByVal layoutId As Integer) As EnumDef.DBMEDITS_RESULT
        Dim layoutDetailSql As String = String.Format("select * from trace_layout_detail where layout_id={0} order by id", layoutId)
        Return QueryTable(layoutDetailSql, returnTable)
    End Function

    Public Function QueryTraceInfo(ByRef returnTable As DataTable, code As String, ByVal dateRangeStart As Date, ByVal dateRangeEnd As Date) As EnumDef.DBMEDITS_RESULT
        Dim startTime As String = String.Format("to_date('{0}','yyyy-mm-dd hh24:mi:ss')", dateRangeStart.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS))
        Dim endTime As String = String.Format("to_date('{0}','yyyy-mm-dd hh24:mi:ss')", dateRangeEnd.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS))
        Dim tableJoin As String = String.Format("{0}, {1}, {2}", TRACE_TRAIL_RECORD, TRACE_ID_INFO, TRACE_LAYOUT_DETAIL)
        Dim cols As String = String.Format("{0}.{1} as {2},{3}.{4} as {5}, {6} as {7}, {8} as {9}", TRACE_ID_INFO, ID_INFO_NAME, TEXT_TRACE_CARD_NAME, TRACE_LAYOUT_DETAIL, LAYOUT_DETAIL_NAME, TEXT_TRACE_LOCATION_NAME, TRAIL_RECORD_ARRIVE_TIME, TEXT_TRAIL_RECORD_ARRIVE_TIME, TRAIL_RECORD_LEAVE_TIME, TEXT_TRAIL_RECORD_LEAVE_TIME)
        Dim where As String = String.Format("{0}={1}.{2} and {3}.{4}={5}.{6} and {7}={8}.{9} and {10} between {11} and {12} and {13}='{14}'", _
                                             TRAIL_RECORD_CARD_ID, TRACE_ID_INFO, ID_INFO_ID, TRACE_TRAIL_RECORD, TRAIL_RECORD_LAYOUT_ID_ID, TRACE_LAYOUT_DETAIL, LAYOUT_DETAIL_LAYOUT_ID, _
                                             TRAIL_RECORD_LOCATION_ID, TRACE_LAYOUT_DETAIL, LAYOUT_DETAIL_ID, TRAIL_RECORD_ARRIVE_TIME, startTime, endTime, ID_INFO_CODE, code)
        Dim orderBy As String = String.Format("{0} asc", TEXT_TRAIL_RECORD_ARRIVE_TIME)
        Dim querySql As String = String.Format("Select {0} From {1} Where {2} Order By {3}", cols, tableJoin, where, orderBy)
        Return QueryTable(querySql, returnTable)
    End Function

    Public Function QuerySurSchedule(ByRef surArrangeTable As DataTable, ByVal surNoteId As Integer) As DBMEDITS_RESULT
        Dim cols As String = String.Format("{0} as {1}, {2} as {3}, {4}, {5}", WORK_SCHEDULE_STAFF_ID, TEXT_ID_INFO_CODE, ID_INFO_NAME, TEXT_ID_INFO_NAME, WORK_SCHEDULE_START_TIME, WORK_SCHEDULE_CLOSE_TIME)
        Dim tableJoin As String = String.Format("{0},{1}", TBL_WORK_SCHEDULE, TRACE_ID_INFO)
        Dim where As String = String.Format("{0}={1} And {2}={3}", WORK_SCHEDULE_STAFF_ID, ID_INFO_CODE, WORK_SCHEDULE_SUR_ID, surNoteId)
        Dim querySql As String = String.Format("Select {0} From {1} Where {2}", cols, tableJoin, where)
        Return QueryTable(querySql, surArrangeTable)
    End Function

    Public Function QueryWorkload(ByRef surWorkloadTable As DataTable, ByVal staffCode As String, ByVal layoutId As Integer, ByVal surRoomId As Integer, ByVal scheduleStartTime As Date, ByVal scheduleCloseTime As Date) As DBMEDITS_RESULT
        Dim startTime As String = String.Format("to_date('{0}','yyyy-mm-dd hh24:mi:ss')", scheduleStartTime.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS))
        Dim endTime As String = String.Format("to_date('{0}','yyyy-mm-dd hh24:mi:ss')", scheduleCloseTime.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS))
        Dim cols As String = String.Format("{0},{1}", TRAIL_RECORD_ARRIVE_TIME, TRAIL_RECORD_LEAVE_TIME)
        Dim tableJoin As String = String.Format("{0},{1},{2}", TRACE_TRAIL_RECORD, TRACE_ID_INFO, TRACE_LAYOUT_DETAIL)
        Dim where As String = String.Format("{0}={1}.{2} And {3}='{4}' And {5}.{6}={7} And {8}.{9}={10}.{11} And {12}={13} And {14} Between {15} And {16}", TRAIL_RECORD_CARD_ID, TRACE_ID_INFO, ID_INFO_ID, ID_INFO_CODE, staffCode, TRACE_TRAIL_RECORD, TRAIL_RECORD_LAYOUT_ID_ID, layoutId, TRACE_TRAIL_RECORD, TRAIL_RECORD_LOCATION_ID, TRACE_LAYOUT_DETAIL, LAYOUT_DETAIL_ID, LAYOUT_DETAIL_ROOM_ID, surRoomId, TRAIL_RECORD_ARRIVE_TIME, startTime, endTime)
        Dim orderBy As String = String.Format("{0} asc", TRAIL_RECORD_ARRIVE_TIME)
        Dim querySql As String = String.Format("Select {0} From {1} Where {2} Order By {3}", cols, tableJoin, where, orderBy)
        Return QueryTable(querySql, surWorkloadTable)
    End Function

    Public Function AddTraceRecord(ByVal cardNo As Integer, ByVal exciter As Integer) As DBMEDITS_RESULT
        Const tableJoin As String = "trace_trail_record,trace_id_info,trace_layout_detail"
        Dim where As String = String.Format("trace_trail_record.card_id = trace_id_info.id and trace_trail_record.location_id = trace_layout_detail.id and trace_id_info.cardno='{0}'", cardNo)
        Const orderBy As String = "trace_trail_record.id desc"
        Dim lastTraceSql As String = String.Format("Select * From {0} Where {1} Order By {2}", tableJoin, where, orderBy)
        Dim queryedTable As New DataTable
        QueryTable(lastTraceSql, queryedTable)
        If Not queryedTable.IsNullOrEmpty() Then
            Dim traceId As Integer = CInt(queryedTable.Rows(0).Item(0))
            Dim exciterId As Integer = Judgement.JudgeDBNullValue(queryedTable.Rows(0).Item(LAYOUT_DETAIL_EXCITER), ENUM_DATA_TYPE.DATA_TYPE_INTEGER)
            If exciterId = exciter Then
                Return DBMEDITS_RESULT.SUCCESS
            End If
            Dim updateTraceSql As String = String.Format("update trace_trail_record set leave_time = sysdate where id = {0}", traceId)
            UpdateOleDb(updateTraceSql)
        End If
        Dim cardInfoSql As String = String.Format("select * from trace_id_info where cardNo = '{0}'", cardNo)
        QueryTable(cardInfoSql, queryedTable)
        If Not queryedTable.IsNullOrEmpty() Then
            Dim cardId As Integer = CInt(queryedTable.Rows(0).Item(0))
            Dim locationInfoSql As String = String.Format("select * from trace_layout_detail where exciter={0}", exciter)
            QueryTable(locationInfoSql, queryedTable)
            If Not queryedTable.IsNullOrEmpty() Then
                Dim locationId As Integer = CInt(queryedTable.Rows(0).Item(0))
                Dim insertTrace As String = String.Format("insert into trace_trail_record (card_id,layout_id, location_id, arrive_time) values({0},73,{1},sysdate)", cardId, locationId)
                UpdateOleDb(insertTrace)
                Return DBMEDITS_RESULT.SUCCESS
            End If
        End If
        Return DBMEDITS_RESULT.ERROR_EXCEPTION
    End Function

    Public Function QueryAlertRecord(ByRef alertTable As DataTable, ByVal startTime As Date, ByVal closeTime As Date) As DBMEDITS_RESULT
        Dim start_Time = String.Format("to_date('{0}','yyyy-mm-dd hh24:mi:ss')", startTime.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS))
        Dim close_Time = String.Format("to_date('{0}','yyyy-mm-dd hh24:mi:ss')", closeTime.ToString(CONST_TEXT_DATETIME_FORMAT_YYYYMMDDHHMMSS))
        Dim querySql As String = String.Format("select name as 姓名, arrive_time as 进入时间, schedule_room as 排班房间, actual_room as 实际所在房间, reason as 报警原因 from trace_alert_record where arrive_time between {0} and {1}", start_Time, close_Time)
        Return QueryTable(querySql, alertTable)
    End Function
End Class
