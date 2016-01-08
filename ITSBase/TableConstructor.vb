
Public Class TableConstructor


    'CREATE WAREHOUSE INS TABLE
    Public Shared Sub CreateWareHouseTable(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_BATCH_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_COMPANY_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_COMPANY_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_PRODUCE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_EXPIRE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_COUNT, GetType(String)))
    End Sub
    '********************************************************************
    '	Title:			CreateSUStockReg
    '	Author:			FB
    '	Create Date:	2009-10-26
    '	Columns:        TEXT_INS_ID
    '                   TEXT_INS_NAME
    '                   TEXT_INS_TYPE
    '                   TEXT_UNIT
    '                   TEXT_PRODUCE_COMPANY
    '                   TEXT_INS_BATCH
    '                   TEXT_EXPIRE_DATE
    '                   TEXT_COUNT
    '                   SSS_COMPANY_ID
    '*********************************************************************
    Public Shared Sub CreateSUStockReg(ByRef dt As DataTable)

        dt = New DataTable
        AddINSFourColumns(dt)
        dt.Columns.Add(New DataColumn(TEXT_PRODUCE_COMPANY, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_BATCH, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_EXPIRE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_COUNT, GetType(Integer)))
        dt.Columns.Add(New DataColumn(SSS_COMPANY_ID, GetType(Long)))
    End Sub

    '********************************************************************
    '	Title:			CreateSUStockDetail
    '	Author:			FB
    '	Create Date:	2009-10-26
    '	Columns:        TEXT_INS_ID
    '                   TEXT_INS_NAME
    '                   TEXT_INS_TYPE
    '                   TEXT_UNIT
    '                   TEXT_PRODUCE_COMPANY
    '                   TEXT_INS_BATCH
    '                   TEXT_EXPIRE_DATE
    '                   TEXT_STOCK_COUNT
    '*********************************************************************
    Public Shared Sub CreateSUStockDetail(ByRef dt As DataTable)
        dt = New DataTable
        AddINSFourColumns(dt)
        dt.Columns.Add(New DataColumn(TEXT_PRODUCE_COMPANY, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_BATCH, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_EXPIRE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STOCK_COUNT, GetType(Integer)))
    End Sub

    '********************************************************************
    '	Title:			CreateSUStockTotal
    '	Author:			CXX
    '	Create Date:	2009-10-26
    '	Columns:        TEXT_INS_ID
    '                   TEXT_INS_NAME
    '                   TEXT_INS_TYPE
    '                   TEXT_UNIT
    '                   TEXT_STOCK_COUNT
    '                   TEXT_STOCK_FIX_COUNT
    '                   TEXT_STOCK_BALANCE_COUNT
    '                   TEXT_COLOR_MARK
    '*********************************************************************
    Public Shared Sub CreateSUStockTotal(ByRef dt As DataTable)
        dt = New DataTable
        AddINSFourColumns(dt)
        dt.Columns.Add(New DataColumn(TEXT_STOCK_COUNT, GetType(Integer)))
        dt.Columns.Add(New DataColumn(TEXT_STOCK_FIX_COUNT, GetType(Integer)))
        dt.Columns.Add(New DataColumn(TEXT_STOCK_BALANCE_COUNT, GetType(Integer)))
        'dt.Columns.Add(New DataColumn(TEXT_COLOR_MARK, GetType(Color)))
    End Sub
    Private Shared Sub AddINSFourColumns(ByRef dt As DataTable)
        dt.Columns.Add(New DataColumn(TEXT_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_UNIT, GetType(String)))
    End Sub
    Public Shared Sub CreateINSColumns(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(INS_NAME_INPUTCODE, GetType(String)))
        dt.Columns.Add(New DataColumn(INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(INS_UNIT, GetType(String)))
    End Sub
    '********************************************************************
    '	Title:			CreateWarerhouseStock
    '	Author:			CXX
    '	Create Date:	2015-11-21
    '	Columns:        
    '*********************************************************************
    Public Shared Sub CreateWarerhouseStock(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_WS_ID, GetType(Long)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_COMPANY_ID, GetType(Long)))
        dt.Columns.Add(New DataColumn(TEXT_WS_COMPANY_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_BATCH_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_PRODUCE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_EXPIRE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STOCK_COUNT, GetType(Long)))
    End Sub
    '********************************************************************
    '	Title:			CreateBalanceStock
    '	Author:			CXX
    '	Create Date:	2015-11-22
    '	Columns:        TEXT_INS_ID
    '                   TEXT_INS_NAME
    '                   TEXT_INS_TYPE
    '                   TEXT_UNIT
    '                   TEXT_STOCK_COUNT
    '*********************************************************************
    Public Shared Sub CreateBalanceStock(ByRef dt As DataTable)
        dt = New DataTable
        AddINSFourColumns(dt)
        dt.Columns.Add(New DataColumn(TEXT_STOCK_COUNT, GetType(Integer)))
    End Sub
    '********************************************************************
    '	Title:			CreateWarerhouseStock
    '	Author:			CXX
    '	Create Date:	2015-11-21
    '	Columns:        
    '*********************************************************************
    Public Shared Sub CreateWarerhouseExpried(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_WS_ID, GetType(Long)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_COMPANY_ID, GetType(Long)))
        dt.Columns.Add(New DataColumn(TEXT_WS_COMPANY_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_BATCH_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_PRODUCE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_EXPIRE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WS_INS_COUNT, GetType(Long)))
        dt.Columns.Add(New DataColumn(TEXT_BTN_MOVE_OUT, GetType(Long)))
    End Sub
    Public Shared Sub CreateWareHouseINSInOut(ByRef dt As DataTable)
        dt = New DataTable
        AddINSFourColumns(dt)
        dt.Columns.Add(New DataColumn(TEXT_CONST_TOTAL_COUNT, GetType(Integer)))
    End Sub

    Public Shared Sub CreateWareHouseInOutDetail(ByRef dt As DataTable)
        dt = New DataTable
        AddINSFourColumns(dt)
        dt.Columns.Add(New DataColumn(TEXT_COUNT, GetType(Integer)))
        dt.Columns.Add(New DataColumn(TEXT_PRODUCE_COMPANY, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_BATCH, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_EXPIRE_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_REG_TIME, GetType(Date)))
    End Sub

    Public Shared Sub CreateWareHouseINSInOutTotal(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_NO, GetType(Integer)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_TYPE_ID, GetType(Integer)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_STAFF_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_STAFF_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_INS_INOUT_REG_TIME, GetType(Date)))
        dt.Columns.Add(New DataColumn(SIM_REG_ID, GetType(Integer)))
    End Sub
    Public Shared Sub CreateDrugStock(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(DRS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_COMMON_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_PRODUCT_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_SPECIFICATION, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_FACTORY, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_AMOUNT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_STOCK_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_MFG, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_BATCHNO, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_EXPIRE, GetType(String)))
    End Sub

    Public Shared Sub CreateDrugStockDetail(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_DRUG_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_COMMON_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_PRODUCT_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_SPECIFICATION, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_FACTORY, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_AMOUNT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_STOCK_UNIT, GetType(String)))
    End Sub
    Public Shared Sub CreateOperationNote(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(OPN_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_VISIT_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_PATIENT_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_GENDER, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_AGE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_OPERATION_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_ORDER_DATE, GetType(String)))
        dt.Columns.Add(New DataColumn(OPN_ROOM_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_ROOM_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_TABLE_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DOCTOR_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DEPARTMENT_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_WEIGHT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DIAGNOSIS, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_OPERATION_STATUS, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DR_MEMO, GetType(String)))
        dt.Columns.Add(New DataColumn(OPN_OPERATION_ID, GetType(String)))
    End Sub
    Public Shared Sub CreateUseINS(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_PACKAGE_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_RESULT, GetType(String)))
    End Sub
    Public Shared Sub CreateUseingINS(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_PACKAGE_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_UNIT, GetType(String)))
    End Sub
    Public Shared Sub CreateReturnDrug(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_DRUG_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_COMMON_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_PRODUCT_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_SPECIFICATION, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_FACTORY, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_AMOUNT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_BACK_COUNT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_DRUG_RETURN_COUNT, GetType(String)))
    End Sub
    Public Shared Sub CreateReturnINS(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(TEXT_PACKAGE_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_RETURN_IS_EXIST, GetType(String)))
    End Sub
    Public Shared Sub CreatePackageExpried(ByRef dt As DataTable)
        dt = New DataTable
        dt.Columns.Add(New DataColumn(SRS_STERILIZE_ROOM_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_STERILIZEROOM_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_PACKAGE_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_ID, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_NAME, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_TYPE, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_INS_UNIT, GetType(String)))
        dt.Columns.Add(New DataColumn(TEXT_EXPIRE_DATE, GetType(String)))
    End Sub
End Class
