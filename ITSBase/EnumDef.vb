Public Module EnumDef
    Public Enum DBMEDITS_RESULT As Long
        SUCCESS = 1                                 '数据库操作成功
        ERROR_PARAMETER = 1001                      '数据库参数错误
        ERROR_EXCEPTION                             '数据库异常
        'ERROR_NOT_OPEN                              '数据库打开失败
        ERROR_EXIST                                 '数据库记录已存在
        ERROR_EXIST_OVERFLOW                        '数据库记录数错误
        ERROR_NOT_EXIST                             '数据库记录不存在
        ERROR_RECORD_INVAILD                        '数据库记录值错误
        ERROR_BALANCE_CHANGE                        '数据库差额异动

        'ERROR_NOT_EXIST_MACHINE                     '机器不存在
        'ERROR_STOCK                                 '库存量错误
        'ERROR_NOTE_HAS_CONFIRMED                    '申请单已确认
        'ERROR_RU_HAS_RETURNED                       '非一次性物品已回收
        'ERROR_WarehouseInsOut                       '库房物品出库异常
        'ERROR_DispatchBatchTime                     '发放批次时间错误
        'EXIST_ZERO                                  '存在0条记录
        'EXIST_ONE                                   '存在一条记录
        EXIST_OVERFLOW                              '存在多条记录

    End Enum
    Public Enum ENUM_DATA_TYPE As Integer
        DATA_TYPE_STRING = 1        '包含string，char
        DATA_TYPE_INTEGER = 2       '包含integer，long，short，int16，int32，int64
        DATA_TYPE_FLOAT = 3         '包含single等所有浮点型
        DATA_TYPE_DATE = 4          '包含时间类型
        DATA_TYPE_OTHER = 5         '其他所有的类型
    End Enum
    '日志的类型
    Public Enum EVENT_ENTRY_TYPE As Short
        ERRORR
        FAILUREAUDIT
        INFORMATION
        SUCCEFULLAUDIT
        WARNING
    End Enum


    Public Enum USER_ROLE As Short
        ROLE_NULL = -1
        DEPARTMENT_COMMONS = 1         '临床科室用户
        OPERATE_COMMONS = 2            '手术室用户
        CSSD_COMMONS = 3               '供应室普通用户
        CSSD_ADMINISTRATOR = 4         '供应室管理员
        DEPARTMENT_ADMINISTRATOR = 5   '临床护士长

        CSSD_BROWSER = 10
    End Enum
    Public Enum USER_STATE As Short
        NORMAL_USE = 0
        STOP_USE = 1
    End Enum
    Public Enum HARDWARE_ROLE As Short
        ROLE_NULL = -1
        DEPARTMENT = 0  '临床科室辅助控制点
        OPERATE         '手术室辅助控制点
        CSSD            '系统控制点
    End Enum
    Public Enum HID_CONTROL_STYLE
        SHOW
        HID
    End Enum
    Public Enum EXPAND_PANEL_TYPE As Short
        STANDARD
        SEARCHBAR_HIGHLIGHT
        SEARCHBAR_FILTER
    End Enum
    Public Enum SCHEDULE_TYPE As Short
        BYSECOND = 1
        BYMINUTE
        BYHOUR
        DAILY
    End Enum
    Public Enum OUTPUT_TAG As Short
        OPERATE = 0
        INFORMATION
        INFOERROR
        CLEAR
    End Enum

    Public Enum PageSelector As Short
        PageInvalid = -1
        PageMin = &H0
        '1~F DRUG MANAGEMENT
        DrugStorageIn = &H1
        DrugStorageOut = &H2
        DrugDispatch = &H3
        DrugStockTaking = &H4
        DrugInOutStatistics = &H5
        DrugConsumeStatistics = &H6
        DrugManagement = &HF
        '10-1F SURGERY MANAGEMENT
        OperationNoteQuery = &H10 '手术通知单查看
        OperationPreReg = &H11 '术前请领登记
        OperationUseReg = &H12 '手术使用登记
        OperationRecycleReg = &H13 '术后回收清点
        OPerationFrontUse = &H14 '术前拆包登记
        OperationManagement = &H1F '手术管理


        HighValueDispatchReg = &H20
        WareHouseInReg = &H21
        WareHouseOutReg = &H22
        WareHouseStock = &H23
        WareHouseInOutStatisc = &H24
        WareHouseManagement = &H2F
        HighValueInReg = &H25
        '30~3F TRACE MANAGEMENT
        LocationQuery = &H31
        TraceQuery = &H32
        TraceWorkloadAccount = &H33
        TraceAlertQuery = &H34

        TraceManagement = &H3F

        '40~4F Maintainment
        InsMaintainment = &H40
        DrugMaintainment = &H41
        AutoPackageMaintainment = &H42
        FactoryMaintainment = &H43
        SterileAreaMaintainment = &H44
        IdCardMaintainment = &H45

        MaintainmentManagement = &H4F

        PageMax = &HFF
    End Enum


    Public Enum DrugInOutType As Short
        InFromMain = 101
        InChong = 102
        OutToMain = 113
        OutToOther = 112
    End Enum
    Public Enum OPerationNoteState As Short
        UnConfirmed = 0 '未确认
        Requested '已申请
        SurgeryConfirm '术前确认
        SurgeryEnd '手术结束
        SurgeryReturn '已回收
        SurgeryCancel '手术取消
    End Enum
    Public Enum EVENT_DBTYPE As Short
        NONE
        SQL_SERVER
        ORACLE
    End Enum
    'Public Enum PACKAGE_STATE As Short
    '    NORMAL = 0
    '    LOCK
    'End Enum
    Public Enum INS_KINDS As Short
        INS_NULL = -1
        WAREHOUSE_SU = 101
        WAREHOUSE_INSTRUMENTS = 102
        OP_INSTRUMENTS = 201
        HIGH_VALUE = 301
        HIGH_VALUE_SU = 302

    End Enum
    '无菌区出入库类型
    Public Enum SR_LOG_INOUT_TYPE As Short
        INOUT_TYPE_NULL = -1

        DRUG_IN = 101                '从大药房入库
        DRUG_IN_BALANCE = 102        '入充
        DRUG_BACK_OUT = 103          '返回大药房出库
        DRUG_DISPATCH = 111          '发放出库
        DRUG_OUT_OTHER = 112         '出库至其他
        DRUG_BACK_OUT_OP = 113       '返回手术室库房出库
        DRUG_OUT_BALANCE = 114       '出充
        DRUG_OUT_EXPRIED = 115       '过期出库

        INS_DISPATCH_IN = 201
        INS_USE_OUT = 202
        INS_EXPRIED_OUT = 203

        WH_IN = 300              '库房物品入库
        WH_OUT_OTHER = 301       '库房物品出库至其他
        WH_IN_BALANCE = 302      '库房物品入充
        WH_OUT_BALANCE = 303     '库房物品出充
        WH_OUT_EXPIRED = 304     '过期出库

        HV_IN_STOCK = 400       '一次性高值耗材打包入库
        HV_IN_DISPATCH = 401    '高值耗材发放入库

        HV_OUT_DISPATCH = 402   '高值耗材发放出库
        HV_OUT_USED = 403       '高值耗材使用出库
        HV_OUT_BACK = 404        '高值耗材退回出库



    End Enum
    Public Enum PRINTER_PAPER_FORMAT As Short
        NOT_CONTINUOUS_PAPER = 0        '非连续纸张
        CONTINUOUS_PAPER = 1            '连续纸张
    End Enum
    'Excel导出的返回结果
    Public Enum EXCEL_OPERATE_RESULTS As Short
        SUCESS = 0              '导出成功
        EXCEPTIONS = 1          '导出异常
        SOFTERROR = 2           'Excel软件错误
        FILERUN = 3             '文件正在运行
        CONFIGERROR = 4         '配置文件错误
    End Enum

    Public Enum BAR_CODE_TYPE As Short
        BARCODE_UNKNOW = 0
        BARCODE_PACKAGE = 1
    End Enum
    Public Enum CHECK_RESULT As Short
        FAILD = 0
        PASS = 1
    End Enum
    Public Enum CHECK_TYPE As Short
        FRONT = 0
        AFTER = 1
    End Enum
    Public Enum PACKAGE_DETAIL_CHECK As Short
        NULL = -1
        Front = 0
        MIDDLE = 1
        AFTER = 2
    End Enum
    'LBS
    Public Enum TRACE_CARD_CATEGORY As Integer
        HIGH_VALUE_DEVICE = 1
        DOCTOR_ON_DUTY = 2
        NURSE_ON_DUTY = 3
    End Enum

    Public Enum TRACE_PANEL_PANEL As Integer
        PANEL = 1
        TRACE_PANEL = 2
    End Enum

    Public Enum TRACE_ID_CATEGORY As Integer
        高值器械 = 1
        排班医生 = 2
        排班护士 = 3
    End Enum
    Public Enum STERILIZE_ROOM_TYPE As Integer
        CSSD = 1
        OP = 2
        EQUIP = 3
    End Enum
    Public Enum LABEL_PRINTER_TYPE As Short
        TYPE_NULL = -1
        TSC = 0         '台湾半岛体(TSC)243/244
        ZEBRA           '美国斑马(Zebra) 888-TT 
    End Enum
    Public Enum PACKAGE_TYPE As Short
        PACK_PUB = 0 '清洁区打包，公用物品
        PACK_PRI     '自备物品打包
        PACK_INS    '物品打包
        PACK_BATCH   '锅号锅次
        PACK_SU_INS   '库房一次性物品标签'
        PACK_TOOL    '标签辅助工具
    End Enum
    Public Enum BAR_CODE_2D_MODE As Short
        NOT_PRINT_2D_BAR_CODE = 0              '关闭二维码打印
        PRINT_2D_BAR_CODE = 1             '开启二维码打印
    End Enum
    Public Enum PACKAGE_STATE As Short
        STATE_NULL = -1
        NOT_STERILIZE = 0 '未灭菌
        STERILIZE_PARPARE '灭菌准备
        STERILIZING       '正在进行灭菌   
        END_STERILIZE     '已灭菌
        DISPATCHED        '已发放
        USED              '已使用
        BACK              '已返回
        RETURNED          '已回收
        BORROW_BACK       '已归还
        DISUSED           '已废弃
        PRE_RECALL        '待召回
        RECALLED          '已召回
        LOSTED            '已丢包
        EXPIRE            '已过期
        INFECTED          '已感染
        RECEVIED          '已接收
        UNPASS_RETURN     '不合格退回
        DISTRICT_DISPACTH  '区域发放
        DISTRICT_BACK      '区域返回
        DISTRICT_RECIVE    '区域接收
        RETURN_BACK        '已退回
        CLEAN_OUT          '清洗出库
    End Enum
    Public Enum REQUEST_STATE As Short
        NULL
        UNCOMFIRM
        PART_DISPATCH
        DISPATCH
    End Enum
    Public Enum REQUEST_KIND As Short
        null
        INS = 101
        HIGH_VALUE_SU = 102
        HIGH_VALUE_RU = 103
        DRUG = 201
    End Enum
    Public Enum EMERGENCY_FLAG As Short  '手术紧急
        EMERGENCY_NOT = 0       '正常
        EMERGENCY = 1           '紧急
    End Enum
    Public Enum EDIT_FLAG As Short
        EDITABLE = 0
        LOCKED
        DELETED
    End Enum
    Public Enum HIGHVALUE_STATE As Short
        UNUSED
        DISPATCH
        FRONT_USE
        USED
        BACK
    End Enum
    Public Enum BACK As Short
        NOTBACK = 0
        BACK
    End Enum
    Public Enum STERILE_ROOM_TYPE As Integer
        CSSD = 1
        OP = 2
        FACILITY = 3
    End Enum

End Module