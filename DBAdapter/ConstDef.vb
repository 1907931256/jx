'*************************************************************
'FileName:      DBConstDef
'Author:        yxh 
'Date:          2006-02-20
'Description:   该文件主要是定义一些查询数据库时需要用到的常量
'****************************************************
Public Module ConstDef
    Public Const DBCONSTDEF_SQL_ASCEND As String = " ASC"
    Public Const DBCONSTDEF_SQL_DESCEND As String = " DESC"
    Public Const DBCONSTDEF_SQL_DELETE As String = "DELETE "
    Public Const DBCONSTDEF_SQL_WHERE As String = " WHERE "
    Public Const DBCONSTDEF_SQL_AND As String = " AND "
    Public Const DBCONSTDEF_SQL_OR As String = " OR "
    Public Const DBCONSTDEF_SQL_EQUAL As String = " ="
    Public Const DBCONSTDEF_SQL_NOTEQUAL As String = "<>"
    Public Const DBCONSTDEF_SQL_GREATER As String = ">"
    Public Const DBCONSTDEF_SQL_GREATER_EQUAL As String = ">="
    Public Const DBCONSTDEF_SQL_SMALLER As String = "<"
    Public Const DBCONSTDEF_SQL_SMALLER_EQUAL As String = "<="
    Public Const DBCONSTDEF_SQL_SINGLE_QUOTE As String = "'"
    Public Const DBCONSTDEF_SQL_ACCESS As String = "#"
    Public Const DBCONSTDEF_SQL_LEFT_BRACE As String = "("
    Public Const DBCONSTDEF_SQL_RIGHT_BRACE As String = ")"
    Public Const DBCONSTDEF_SQL_LIKE As String = " LIKE "
    Public Const DBCONSTDEF_SQL_WILDCARD_CHAR As String = "_"
    Public Const DBCONSTDEF_SQL_WILDCARD_MIDDLCHAR As String = "-"    'Add by yxh at 2005.07.12
    Public Const DBCONSTDEF_SQL_WILDCARD_STRING As String = "%"
    Public Const DBCONSTDEF_SQL_TIME_FORMAT As String = "%Y-%m-%d %H:%M:%S"
    Public Const DBCONSTDEF_SQL_ORDERBY As String = " ORDER BY "
    Public Const DBCONSTDEF_SQL_FROM As String = " FROM "
    Public Const DBCONSTDEF_SQL_SPACE As String = " "
    Public Const DBCONSTDEF_SQL_COMMA As String = ","
    Public Const DBCONSTDEF_SQL_DOT As String = "."
    Public Const DBCONSTDEF_SQL_INVERTED_COMMA As String = "'"
    Public Const DBCONSTDEF_SQL_ORACLE_TO_DATE_HEAD As String = "to_date('"
    Public Const DBCONSTDEF_SQL_ORACLE_TO_DATE_TRAIL As String = "','yyyyMMddHH24miss')"
    Public Const DBCONSTDEF_SQL_ORACLE_TO_DATE_YEAR As String = "','yyyy')"
    Public Const DBCONSTDEF_SQL_ORACLE_TO_DATE_YAER_MOTH As String = "','yyyyMM')"
    Public Const DBCONSTDEF_SQL_ORACLE_TO_DATE_YAER_MOTH_DAY As String = "','yyyyMMdd')"
    Public Const DBCONSTDEF_SQL_ON As String = " ON "
    Public Const DBCONSTDEF_SQL_INNER_JOIN As String = " INNER JOIN "
    Public Const DBCONSTDEF_SQL_INNER_LEFT As String = " LEFT "
    Public Const DBCONSTDEF_SQL_OUTER_JOIN As String = " OUTER JOIN "
    Public Const DBCONSTDEF_SQL_TRIM As String = " TRIM"
    Public Const DBCONSTDEF_SQL_SELECT_ALL As String = " * "
    Public Const DBCONSTDEF_SQL_AS As String = " AS "
    '如果查询某个字段值，如果各个值都有，则这个字段值为这个常量
    Public Const DBCONSTDEF_SQL_DATA_VALUE_ALL As String = "%"
    Public Const DBCONSTDEF_SQL_DATE_TIME_BEGIN As String = " 00:00:00"
    Public Const DBCONSTDEF_SQL_DATE_TIME_END As String = " 23:59:59"
    Public Const DBCONSTDEF_SQL_ROWNUM As String = "ROWNUM"
    Public Const DBCONSTDEF_SQL_ROWNUM_MAXVALUE As String = "500"
    Public Const DBCONSTDEF_SQL_SEPARATOR As String = "/"
    Public Const DBCONSTDEF_SQL_SEQ_ID As String = "SEQ_ID"

    Public Const DBCONSTDEF_ORACLE_INSERT_FULL_OUTPUT_SEQ_ID As String = "declare SEQ_ID number;begin INSERT INTO {0}({1}) VALUES({2}) returning {3} into SEQ_ID; end;"
    Public Const DBCONSTDEF_ORACLE_INSERT_FULL_OUTPUT_SEQ_ID_1 As String = "begin INSERT INTO {0}({1}) VALUES({2}) returning {3} into SEQ_ID;end;"
    Public Const DBCONSTDEF_ORACLE_INSERT_FULL_RETURN_ID As String = "INSERT INTO {0}({1}) VALUES({2}) returning {3} into ?"
    Public Const DBCONSTDEF_ORACLE_INSERT_FULL As String = "INSERT INTO {0}({1}) VALUES({2})"
    Public Const DBCONSTDEF_SQL_SELECT_NEXTVAL As String = "SELECT {0}.NEXTVAL  AS SEQ_ID FROM DUAL"
    Public Const DBCONSTDEF_SQL_INSERT_FULL As String = "INSERT INTO {0}({1}) VALUES({2})"
    Public Const DBCONSTDEF_SQL_INSERT_FULL_OUTPUT_SEQ_ID As String = DBCONSTDEF_SQL_INSERT_FULL & " SET @SEQ_ID = Scope_Identity()"
    Public Const DBCONSTDEF_SQL_SELECT As String = " SELECT {0} FROM {1}"
    Public Const DBCONSTDEF_SQL_SELECT_ORDER_ASC As String = " SELECT {0} FROM {1} ORDER BY {2} ASC"
    Public Const DBCONSTDEF_SQL_SELECT_WHERE As String = " SELECT {0} FROM {1} WHERE {2}"
    Public Const DBCONSTDEF_SQL_SELECT_ORDER As String = " SELECT {0} FROM {1} ORDER BY {2}"
    Public Const DBCONSTDEF_SQL_SELECT_GROUP_ORDER As String = " SELECT {0} FROM {1} GROUP BY {2} ORDER BY {3}"
    Public Const DBCONSTDEF_SQL_SELECT_WHERE_ORDER As String = " SELECT {0} FROM {1} WHERE {2} ORDER BY {3}"
    Public Const DBCONSTDEF_SQL_SELECT_WHERE_ORDER_DESC As String = " SELECT {0} FROM {1} WHERE {2} ORDER BY {3} DESC"
    Public Const DBCONSTDEF_SQL_SELECT_DISTINCT_WHERE_ORDER As String = " SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3}"
    Public Const DBCONSTDEF_SQL_SELECT_WHERE_ORDER_ASC As String = " SELECT {0} FROM {1} WHERE {2} ORDER BY {3} ASC"
    Public Const DBCONSTDEF_SQL_SELECT_WHERE_GROUPBY As String = " SELECT {0} FROM {1} WHERE {2} GROUP BY {3}"
    Public Const DBCONSTDEF_SQL_SELECT_WHERE_GROUP_ORDER_ASC As String = " SELECT {0} FROM {1} WHERE {2} GROUP BY {3} ORDER BY {4}"
    Public Const DBCONSTEDF_SQL_SELECT_WHERE_TOP_ORDER_DESC As String = "SELECT TOP 5 {0} FROM {1} WHERE {2} ORDER BY {3} DESC"
    Public Const DBCONSTEDF_SQL_SELECT_WHERE_IN_SELECT_SQL_WHERE As String = "SELECT {0} FROM {1} WHERE {2} IN ({3})"
    Public Const DBCONSTDEF_SQL_DELETE_ALL As String = "DELETE FROM {0}"
    Public Const DBCONSTDEF_SQL_DELETE_WHERE As String = "DELETE FROM {0} WHERE {1}"
    Public Const DBCONSTDEF_SQL_UPDATE As String = "UPDATE {0} SET {1}"
    Public Const DBCONSTDEF_SQL_UPDATE_WHERE As String = "UPDATE {0} SET {1} WHERE {2}"
    Public Const DBCONSTDEF_SQL_SELECT_INNERJOIN_WHERE As String = " SELECT {0} FROM {1} INNER JOIN {2} ON({3}) WHERE {4}"
    Public Const DBCONSTDEF_SQL_SELECT_INNERJOIN_WHERE_GROUPBY As String = " SELECT {0} FROM {1} INNER JOIN {2} ON({3})  WHERE {4} GROUP BY {5}"
    Public Const DBCONSTDEF_LANGUAGE_COUNT As String = "COUNT(*)"
    Public Const DBCONSTDEF_SQL_SELECT_WHERE_NESTED As String = "(SELECT {0} FROM {1} WHERE {2})"
    Public Const DBCONSTDEF_SQL_SELECT_MAX As String = "SELECT MAX({0}) AS {1} FROM {2}"
    Public Const DBCONSTDEF_SQL_SELECT_MAX_WHERE As String = "SELECT MAX({0}) FROM {1} WHERE {2}"
    Public Const DBCONSTDEF_SQL_SELECT_MAX_WHERE_NESTED As String = "(SELECT MAX({0}) FROM {1} WHERE {2})"
    Public Const DBCONSTDEF_LEFT_JOIN_ON As String = "{0} LEFT JOIN {1} ON {2}"
    Public Const DBCONSTDEF_TIME_NOT_LATE As String = "DATEPART(HOUR,{0})<DATEPART(HOUR,{1})" & "or(DATEPART(HOUR,{0})=DATEPART(HOUR,{1})and DATEPART(MINUTE,{0})<DATEPART(MINUTE,{1}))" & _
                                                       "or(DATEPART(HOUR,{0})=DATEPART(HOUR,{1})and DATEPART(MINUTE,{0})=DATEPART(MINUTE,{1})and DATEPART(SECOND,{0})<=DATEPART(SECOND,{1}))"


    Public Const DBCONSTDEF_ORACLE_SELECT_INSERT_UPDATE As String = "Declare x  number;begin select count(1) into x from {0} where exists({1});if x>0 then {2}; else {3};end if; end; "
    Public Const DBCONSTDEF_ORACLE_SELECT_INSERT As String = "Declare x  number;begin select count(1) into x from {0} where exists({1});if x<1 then {2};end if; end; "
    Public Const DBCONSTEDF_SQL_SELECT_WHERE_NOTEXISTS_SELECT_SQL_WHERE As String = "SELECT {0} FROM {1} WHERE {2} NOT EXISTS ({3})"

    Public Const DBCONSTEDF_SQL_CONVERT_DATE_FORMAT As String = "CONVERT(varchar(12) , {0}, 111 )"
    Public Const DBCONSTDEF_SQL_SELECT_ALL_FROM_EXCEL As String = "SELECT * FROM [{0}$]"
End Module

Public Module ErrorConstDef
    Public Const ERRORCONSTDEF_CONNECT_STRING As String = "数据库连接信息："
    Public Const ERRORCONSTDEF_TRANSACTION_NOTHING As String = "事务未被创建。"
    Public Const ERRORCONSTDEF_TRANSACTION_EXIST As String = "有未被提交的事务存在。"
    Public Const ERRORCONSTDEF_COMMANDTEXT As String = "[CommandText:{0}]"
    Public Const ERRORCONSTDEF_COMMAND_PARAMETERS As String = "[Parameters - ParameterName:{0}, Direction:{1}, OleDbType:{2}, Value:{3}]"
End Module
