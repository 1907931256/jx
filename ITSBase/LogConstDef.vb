Public Module LogConstDef
    'Information
    Public Const LOG_INFORMATION_STARTUP As String = "程序启动"
    Public Const LOG_INFORMATION_MAINFORM_SHOW As String = "V-TRACK启动"
    Public Const LOG_INFORMATION_MAINFORM_INNER_SWITCH As String = "V-TRACK切换页面至{0}"
    Public Const LOG_INFORMATION_MAINFORM_INNER_SWITCH_TO_MAIN As String = "V-TRACK切换页面至主界面"
    Public Const LOG_INFORMATION_MAINFORM_INNER_CREATE As String = "V-TRACK创建页面{0}"
    Public Const LOG_INFORMATION_MAINFORM_DISPOSE As String = "V-TRACK释放"
    Public Const LOG_INFORMATION_CLOSE As String = "程序退出"
    Public Const LOG_INFORMATION_LOGOUT As String = "注销"
    Public Const LOG_INFORMATION_LOCK As String = "锁定"
    Public Const LOG_INFORMATION_START_EXTERNAL_PROCESS_SUCESS As String = "V-TRACK成功启动外部程序，启动地址为{0}，启动参数为{1}"
    Public Const LOG_INFORMATION_START_EXTERNAL_PROCESS_ERROR As String = "V-TRACK启动外部程序失败，启动地址为{0}，启动参数为{1}，原因{0}"
    Public Const LOG_INFORMATION_START_EXTERNAL_PROCESS_ERROR_NOT_EXIST As String = "V-TRACK启动外部程序失败，启动地址为{0}的应用程序不存在"

    Public Const LOG_INFORMATION_TIMER_TASK_SETTING As String = "定时器设置成功，任务名称：{0}"
    Public Const LOG_INFORMATION_TIMER_START As String = "定时器启动"

    'Update
    Public Const LOG_INFORMATION_AUTOUPDATE_SUC As String = "成功从服务器上下载到新版本{0}。"
    Public Const LOG_INFORMATION_AUTOUPDATE_ERROR As String = "版本更新失败。当前版本：{0}，目标版本{1}。"
    Public Const LOG_UPDATE_EXCEPTION As String = "自动更新过程中出现异常：{0}"
    Public Const LOG_DETECT_AUTO_UPDATE_CLOSE As String = "系统检测到，因为配置文件设置自动更新未进行。"

    'Main Form
    Public Const LOG_MAINFORM_DISPOSE_FAILURE As String = "V-TRACK释放异常，捕获异常："

    'XML
    Public Const LOG_ELEMENT_READ_FAILURE As String = "获取节点错误，节点：{0} "
    Public Const LOG_ELEMENT_READ_FAILURE_SUB As String = "获取节点错误，节点路径：{0}，子节点：{1} "
    Public Const LOG_ELEMENT_VALUE As String = "获取节点内容错误，节点路径：{0}，值：{1} "
    Public Const LOG_ELEMENT_VALUE_SUB As String = "获取节点内容错误，节点路径：{0}，子节点：{1}，值：{2} "

    'License
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_LOAD_FAILURE As String = "策略文件载入出错"
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_ROLE_NOT_UPDATE As String = "{0}无需更新"
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_ROLE_UPDATE_SUCCESS As String = "{0}更新成功，更新后值：{1}"
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_DB_EXCEPTION As String = "更新策略时，数据库异常"

    'Structure Config
    Public Const LOG_STRUCTURE_LOAD_FAILURE As String = "从数据库载入程序框架配置出错"
    Public Const LOG_STRUCTURE_READ_FAILURE As String = "程序框架配置读取出错"

    'Config
    Public Const LOG_CONFIGFILE_LOAD_FAILURE As String = "配置文件载入出错"
    Public Const LOG_CONFIGFILE_READ_FAILURE As String = "配置文件读取出错"
    Public Const LOG_CONFIGFILE_LABEL_PRINTER_FAILURE As String = "V-TRACK标签打印机初始化失败，捕获异常："
    Public Const LOG_CONFIGFILE_MEDITS_PRINTER_FAILURE As String = "V-TRACK默认打印机初始化失败，捕获异常："
    Public Const LOG_CONFIGFILE_RESET_MEDITS_PRINTER_FAILURE As String = "尝试将系统默认打印机设为V-TRACK默认打印机失败"
    Public Const LOG_CONFIGFILE_RESET_MEDITS_PRINTER_SUCCESS As String = "将系统默认打印机设为V-TRACK默认打印机，写入配置文件成功"
    Public Const LOG_CONFIGFILE_CURDEPARTMENT_FAILURE As String = "获得当前科室信息异常，配置文件值："
    Public Const LOG_CONFIGFILE_CUROPROOM_FAILURE As String = "获得当前手术房号信息异常，配置文件值："
    Public Const LOG_CONFIGFILE_CREATE_ERROR As String = "配置文件创建失败"

    'Load
    Public Const LOG_LOAD_LOCALDATA_FAILURE As String = "初始化{0}失败"

    'Login
    Public Const LOG_LOGIN_USERID_ERROR As String = "用户ID：{0}，登录异常"
    Public Const LOG_LOGIN_PASSWORD_ERROR As String = "密码输入错误，用户ID：{0},输入密码：{1}"
    Public Const LOG_LOGIN_USERID_SUCCESS As String = "用户ID：{0}，登录成功"
    Public Const LOG_LOGIN_USERROLE_ERROR As String = "{0}ID：{1}，登录{2},角色不匹配"
    Public Const LOG_LOGIN_USERROLE As String = "{0}用户无权关闭该界面"
    'INS
    Public Const LOG_INS_ERROR_EXIST_OVERFLOW As String = "查询编号为{0}物品时,记录不唯一"
    Public Const LOG_INS_COST_ERROR_EXIST_OVERFLOW As String = "查询编号为{0}物品成本信息时,记录不唯一"
    Public Const LOG_SYS_OPERATION_COST_ERROR_EXIST_OVERFLOW As String = "查询编号为{0}作业成本信息时,记录不唯一"
    Public Const LOG_SYS_OPERATION_COST_ERROR_NOT_EXIST As String = "查询编号为{0}作业成本信息时,记录不存在"
    Public Const LOG_SYS_OPERATION_DETAIL_COST_ERROR_EXIST_OVERFLOW As String = "查询编号为{0}作业详细成本信息时,记录不唯一"
    Public Const LOG_SYS_OPERATION_DETAIL_COST_ERROR_NOT_EXIST As String = "查询编号为{0}作业详细成本信息时,记录不存在"
    Public Const LOG_SYS_COST_FACTOR_ERROR_EXIST_OVERFLOW As String = "查询编号为{0}成本因子信息时,记录不唯一"
    Public Const LOG_SYS_COST_FACTOR_ERROR_NOT_EXIST As String = "查询编号为{0}成本因子信息时,记录不存在"
    Public Const LOG_SYS_COST_FACTOR_BY_TYPE_ERROR_EXIST_OVERFLOW As String = "查询类型为{0}的成本因子信息时,记录不唯一"
    Public Const LOG_SYS_COST_FACTOR_BY_TYPE_ERROR_NOT_EXIST As String = "查询类型为{0}的成本因子信息时,记录不存在"
    'Public Const LOG_INS_ERROR_NOT_EXIST As String = "查询编号为{0}物品时,记录不存在或已被删除"

    'Sterilize Info
    Public Const LOG_STERILIZE_INFO_ERROR_EXIST_OVERFLOW As String = "查询编号为{0}灭菌信息时,记录不唯一"
    Public Const LOG_STERILIZE_INFO_ERROR_NOT_EXIST As String = "查询编号为{0}灭菌信息时,记录不存在"
    Public Const LOG_STERILIZE_INFO_ERROR_AVAILABELDATE_INVALID As String = "灭菌信息无法获得有效时间：Method-{0},Unit-{1},Value{2},捕获异常："

    Public Const LOG_STERILIZE_BATCH_ERROR_EXIST_OVERFLOW As String = "查询机器编号为{0}，时间范围在{1}到{2}之间的灭菌信息时,记录不唯一"
    Public Const LOG_STERILIZE_BATCH_ERROR_NOT_EXIST As String = "查询机器编号为{0}，时间范围在{1}到{2}之间的灭菌信息时,记录不存在"

    Public Const LOG_WASH_DISINFECT_ERROR_EXIST_OVERFLOW As String = "查询机器编号为{0}，时间范围在{1}到{2}之间的清洗信息时,记录不唯一"
    Public Const LOG_WASH_DISINFECT_ERROR_NOT_EXIST As String = "查询机器编号为{0}，时间范围在{1}到{2}之间的清洗信息时,记录不存在"

    'Validity Period Info
    Public Const LOG_VALIDITY_PERIOD_INFO_ERROR_EXIST_OVERFLOW As String = "查询编号为{0}有效期信息时,记录不唯一"
    Public Const LOG_VALIDITY_PERIOD_INFO_ERROR_NOT_EXIST As String = "查询编号为{0}有效期信息时,记录不存在"
    Public Const LOG_VALIDITY_PERIOD_INFO_ERROR_AVAILABELDATE_INVALID As String = "有效期信息无法获得有效时间：Index-{0},Unit-{1},Value{2},捕获异常："

    'Performance Factor Info
    Public Const LOG_PERFORMANCE_FACTOR_INFO_ERROR_EXIST_OVERFLOW As String = "查询Key为{0}绩效因子信息时,记录不唯一"
    Public Const LOG_PERFORMANCE_FACTOR_INFO_ERROR_NOT_EXIST As String = "查询Key为{0}绩效因子信息时,记录不存在"

    'Performance Evaluation
    Public Const LOG_PERFORMANCE_EVALUATION_STAFF_NOT_EXIST As String = "绩效考核统计时，用户编号为{0}的用户,无法获得用户名字"
    Public Const LOG_PERFORMANCE_EVALUATION_SUB_PROCEDURE_INS_KIND_NOT_EXIST As String = "绩效考核统计时，查询Key为{0}绩效因子对应物品类型集合,记录不存在"
    Public Const LOG_PERFORMANCE_EVALUATION_SUB_PROCEDURE_DB_EXCEPTIONT As String = "绩效考核统计时，统计{0}时,数据库异常"

    'Package Scan
    Public Const LOG_PACKAGE_SCAN_PACKAGE_NOT_EXIST As String = "{0}时查询主键值为{1}治疗包,记录不存在"

    'Dispatch
    Public Const LOG_DISPATCH_NOTE_NOT_EXIST As String = "发放时查询主键值为{0}申请单据,记录不存在"
    Public Const LOG_DISPATCH_NOTE_STATE_ERROR As String = "发放时查询主键值为{0}申请单据,状态为{1}，不允许执行下一步操作"
    Public Const LOG_DISPATCH_PACKAGE_NOT_EXIST As String = "发放时查询主键值为{0}治疗包,记录不存在"
    Public Const LOG_DISPATCH_PACKAGE_STATE_ERROR As String = "发放时查询主键值为{0}治疗包,状态为{1}，不允许发放"
    Public Const LOG_DISPATCH_PACKAGE_STERILIZER_ERROR As String = "发放时查询主键值为{0}治疗包,无法关联无菌区信息，不允许发放"

    'Receive
    Public Const LOG_RECEIVE_NOTE_STATE_ERROR As String = "接收时查询主键值为{0}申请单据,状态为{1}，不允许执行下一步操作"
    Public Const LOG_RECEIVE_PACKAGE_STATE_ERROR As String = "接收时查询主键值为{0}治疗包,状态为{1}，不允许接收"
    Public Const LOG_RECEIVE_NOTE_NOT_EXIST As String = "接收时查询主键值为{0}申请单据,记录不存在"
    Public Const LOG_RECEIVE_DISPATCH_NOTE_NOT_EXIST As String = "接收时查询主键值为{0}发放单据,记录不存在"

    'Borrow Back
    Public Const LOG_BORROW_BACK_DISPATCH_NOTE_NOT_EXIST As String = "归还时查询主键值为{0}发放单据,记录不存在"
    Public Const LOG_BORROW_BACK_RECEIVE_NOTE_NOT_EXIST As String = "归还时查询主键值为{0}接收单据,记录不存在"
    Public Const LOG_BORROW_BACK_PACKAGE_STATE_ERROR As String = "归还时查询主键值为{0}治疗包,状态为{1}，不允许归还"
    Public Const LOG_BORROW_BACK_NOTE_STATE_ERROR As String = "归还时查询主键值为{0}申请单据,状态为{1}，不允许执行下一步操作"

    'Return Back
    Public Const LOG_RETURN_BACK_PACKAGE_STATE_ERROR As String = "退回时查询主键值为{0}治疗包,状态为{1}，不允许退回"
    Public Const LOG_RETURN_BACK_PACKAGE_DISPATCH_ERROR As String = "退回时查询主键值为{0}治疗包,没有发放信息，不允许退回"
    Public Const LOG_RETURN_BACK_PACKAGE_DISPATCH_NOTE_ERROR As String = "退回时查询主键值为{0}治疗包,发放单类型为{1}，不允许退回"

    'INS Use
    Public Const LOG_INS_USE_PACKAGE_STATE_ERROR As String = "使用时查询主键值为{0}治疗包,状态为{1}，不允许使用"
    Public Const LOG_INS_USE_PACKAGE_EXIST_IN_STOCK As String = "使用时查询主键值为{0}治疗包,不在无菌区库存表中，不允许扫描"
    'RU TRACE
    Public Const LOG_RU_TRACE_PACKAGE_STATE_ERROR As String = "非一次性物品回溯时查询主键值为{0}治疗包,状态为{1}，无法获取物品使用信息"

    'OP_STOCK
    Public Const LOG_OP_STOCK_PACKAGE_STATE_ERROR As String = "手术器械查询变更时查询包号为{0}治疗包,状态为{1}，不允许扫描"
    Public Const LOG_OP_STOCK_NOT_EXIST_IN_STOCK As String = "手术器械查询变更时查询包号为{0}治疗包,不在无菌区库存表中，不允许扫描"
    Public Const LOG_OP_STOCK_PACKAGE_NOT_BACK_STERILEROOM As String = "手术器械查询变更时查询包号为{0}治疗包,所在无菌区库字段为{1},无对应返回无菌区字段，不允许返回"
    Public Const LOG_OP_STOCK_PACKAGE_OVRRIED As String = "手术器械查询时查询包号为{0}治疗包,记录不惟一"
    Public Const LOG_OP_STOCK_NO_ROOM As String = "查询不存在手术室无菌区。"

    'Back
    Public Const LOG_CSSD_STOCK_NOT_EXIST_IN_STOCK As String = "院区物品返回时，查询治疗包{0}不在院区无菌区中，不允许扫描"
    'Return
    Public Const LOG_RETURN_PACKAGE_STATE_ERROR As String = "回收时查询主键值为{0}治疗包,状态为{1}，不允许回收"
    Public Const LOG_RETURN_PACKAGE_STATE_NOTUSE As String = "回收时查询主键值为{0}治疗包,未被使用"

    'Terminaler
    Public Const LOG_TERMINALER_ERROR_NOT_EXIST As String = "V-TRACK手持终端不存在或未设置，捕获异常："
    Public Const LOG_TERMINALER_ERROR_CANNOT_GET_STATE As String = "V-TRACK手持终端无法检查连接，捕获异常："
    Public Const LOG_TERMINALER_ERROR_DATAFILE_UPLOAD_FAILURE As String = "V-TRACK手持终端文件上传失败，捕获异常："
    Public Const LOG_TERMINALER_INFORMATION_STATE_CHANGE As String = "V-TRACK手持终端状态更新：{0}"
    Public Const LOG_TERMINALER_INFORMATION_LOAD_SUCCESS As String = "V-TRACK手持终端数据载入界面成功，当前界面：{0}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_NOT_EXIST As String = "V-TRACK手持终端数据文件不存在，数据路径：{0}"
    Public Const LOG_TERMINALER_ERROR_CREATE_TEMPDIR_FAILURE As String = "V-TRACK手持终端创建临时路径失败，数据路径：{0},捕获异常：{1}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_PARSE_FAILURE As String = "V-TRACK手持终端数据文件解析失败，数据路径：{0},捕获异常：{1}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_SAVE_FAILURE As String = "V-TRACK手持终端数据文件保存失败，数据路径：{0},捕获异常：{1}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_PARSE_FORMAT_ERROR As String = "V-TRACK手持终端数据文件解析时，数据格式错误，数据路径：{0},行号：{1}"
    Public Const LOG_TERMINALER_ERROR_TIMEOUT As String = "V-TRACK手持终端监听超时，超时设置："
    Public Const LOG_TERMINALER_INTIAL_FAILURE_RESET As String = "V-TRACK手持终端初始化失败，已关闭"
    Public Const LOG_TERMINALER_TEMPFILE_NOTEXIST As String = "V-TRACK手持终端临时文件不存在，临时文件："
    Public Const LOG_TERMINALER_TEMPFILE_COPY_FAILURE As String = "V-TRACK手持终端拷贝临时文件失败，源文件：{0},目标文件：{1}，捕获异常：{2}"
    'Printer
    Public Const LOG_PERINTER_ERROR_SYSTEM_DEFAULT_NOT_EXIST As String = "操作系统默认打印机不存在或未设置，捕获异常："
    Public Const LOG_PERINTER_ERROR_MEDITS_DEFAULT_NOT_EXIST As String = "V-TRACK默认打印机不存在或未设置，捕获异常："
    Public Const LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST As String = "V-TRACK标签打印机不存在或未设置，捕获异常："

    'Print
    Public Const LOG_PERINT_ERROR As String = "打印执行未完成，捕获异常："
    Public Const LOG_PERINT_ERROR_FORMAT_FILE_LOAD_FAILURE As String = "打印格式文件：{0}，载入出错，捕获异常：{1}"
    Public Const LOG_PERINT_NOT_READY As String = "打印格式文件未准备好。"
    Public Const LOG_PERINT_ERROR_FORMAT_FILE_LOAD_EXCEPTION As String = "打印格式文件载入出错，捕获异常："
    Public Const LOG_PERINT_ERROR_INTERRUPT_OR_EXCEPTION As String = "打印过程被中断或失败，捕获异常："

    'Monitor BorrowBack
    Public Const LOG_MONITOR_BORROW_BACK_ERROR_EXCEPTION As String = "借单归还监听异常，捕获异常："
    Public Const LOG_MONITOR_BORROW_BACK_ERROR_DB_EXCEPTION As String = "借单归还监听数据库异常"
    Public Const LOG_MONITOR_BORROW_BACK_ERROR_TIMEOUT As String = "借单归还监听超时，超时设置："

    'BorrowBack Notice
    Public Const LOG_MONITOR_BORROW_BACK_NOTICE_ERROR_EXCEPTION As String = "借单归还通知监听异常，捕获异常："
    Public Const LOG_MONITOR_BORROW_BACK_NOTICE_ERROR_DB_EXCEPTION As String = "借单归还通知监听数据库异常"
    Public Const LOG_MONITOR_BORROW_BACK_NOTICE_ERROR_TIMEOUT As String = "借单归还通知监听超时，超时设置："

    'Recall
    Public Const LOG_MONITOR_BORROW_RECALL_ERROR_EXCEPTION As String = "召回监听异常，捕获异常："
    Public Const LOG_MONITOR_BORROW_RECALL_ERROR_TIMEOUT As String = "召回监听超时，超时设置："
    Public Const LOG_MONITOR_BORROW_RECALL_ERROR_DB_EXCEPTION As String = "召回监听数据库异常"

    'Expired BorrowBack
    Public Const LOG_MONITOR_EXPIRED_ERROR_EXCEPTION As String = "供应室过期物品提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_EXPIRED_ERROR_DB_EXCEPTION As String = "供应室过期物品提醒监听数据库异常"
    Public Const LOG_MONITOR_EXPIRED_ERROR_TIMEOUT As String = "供应室过期物品提醒监听超时，超时设置："

    Public Const LOG_MONITOR_WHEXPIRED_ERROR_EXCEPTION As String = "库房过期物品提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_WHEXPIRED_ERROR_DB_EXCEPTION As String = "库房过期物品提醒监听数据库异常"
    Public Const LOG_MONITOR_WHEXPIRED_ERROR_TIMEOUT As String = "库房过期物品提醒监听超时，超时设置："

    Public Const LOG_MONITOR_WHBALANCE_ERROR_EXCEPTION As String = "库房库存量不足提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_WHBALANCE_ERROR_DB_EXCEPTION As String = "库房库存量不足提醒监听数据库异常"
    Public Const LOG_MONITOR_WHBALANCE_ERROR_TIMEOUT As String = "库房库存量不足提醒监听超时，超时设置："

    Public Const LOG_MONITOR_EIEXPIRED_ERROR_EXCEPTION As String = "耗材过期物品提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_EIEXPIRED_ERROR_DB_EXCEPTION As String = "耗材过期物品提醒监听数据库异常"
    Public Const LOG_MONITOR_EIEXPIRED_ERROR_TIMEOUT As String = "耗材过期物品提醒监听超时，超时设置："

    Public Const LOG_MONITOR_EIBALANCE_ERROR_EXCEPTION As String = "耗材库存量不足提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_EIBALANCE_ERROR_DB_EXCEPTION As String = "耗材库存量不足提醒监听数据库异常"
    Public Const LOG_MONITOR_EIBALANCE_ERROR_TIMEOUT As String = "耗材库存量不足提醒监听超时，超时设置："

    Public Const LOG_MONITOR_OPEXPIRED_ERROR_TIMEOUT As String = "手术室过期物品提醒监听超时，超时设置："
    Public Const LOG_MONITOR_OPEXPIRED_ERROR_EXCEPTION As String = "手术室过期物品提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_OPEXPIRED_ERROR_DB_EXCEPTION As String = "手术室过期物品提醒监听数据库异常"

    Public Const LOG_MONITOR_SERVICE_PLAN_ERROR_EXCEPTION As String = "维护计划提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_SERVICE_PLAN_ERROR_DB_EXCEPTION As String = "维护计划提醒监听数据库异常"
    Public Const LOG_MONITOR_SERVICE_PLANS_ERROR_TIMEOUT As String = "维护计划提醒监听超时，超时设置："

    Public Const LOG_MONITOR_RU_BALANCE_ERROR_EXCEPTION As String = "非一次性物品不足提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_RU_BALANCE_ERROR_DB_EXCEPTION As String = "非一次性物品不足提醒监听数据库异常"
    Public Const LOG_MONITOR_RU_BALANCE_ERROR_TIMEOUT As String = "非一次性物品不足提醒监听超时，超时设置："

    Public Const LOG_MONITOR_SU_BALANCE_ERROR_EXCEPTION As String = "一次性物品不足提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_SU_BALANCE_ERROR_DB_EXCEPTION As String = "一次性物品不足提醒监听数据库异常"
    Public Const LOG_MONITOR_SU_BALANCE_ERROR_TIMEOUT As String = "一次性物品不足提醒监听超时，超时设置："

    Public Const LOG_MONITOR_UVLAMP_BALANCE_ERROR_EXCEPTION As String = "紫外线灯管到期提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_UVLAMP_BALANCE_ERROR_DB_EXCEPTION As String = "紫外线灯管到期提醒监听数据库异常"
    Public Const LOG_MONITOR_UVLAMP_BALANCE_ERROR_TIMEOUT As String = "紫外线灯管到期提醒监听超时，超时设置："

    Public Const LOG_MONITOR_OPREQEST_ERROR_EXCEPTION As String = "手术器械紧急申请提醒监听异常，捕获异常："
    Public Const LOG_MONITOR_OPREQEST_BALANCE_ERROR_DB_EXCEPTION As String = "手术器械紧急申请提醒监听数据库异常"
    Public Const LOG_MONITOR_OPREQEST_BALANCE_ERROR_TIMEOUT As String = "手术器械紧急申请提醒监听超时，超时设置："
    'Timer Task 
    Public Const LOG_TIMER_TASK_SETTING_FAILURE As String = "定时器设置失败，任务名称：{0}"

    'Work Volume Statistic
    Public Const LOG_VOLUME_STATISTIC_MAIN_TYPE_ERROR As String = "工作量统计异常，主键值为{0}的统计项,主分类错误：Value-{1}"
    Public Const LOG_VOLUME_STATISTIC_DETAIL_ITEM_ERROR As String = "工作量统计异常，主键值为{0}的统计项,详细项错误"
    Public Const LOG_VOLUME_STATISTIC_DETAIL_ITEM_NOT_CORRECT As String = "工作量统计异常，主键值为{0}的统计项,详细项异常或者不存在：Value-{1}"
    Public Const LOG_VOLUME_STATISTIC_DB_EXCEPTION As String = "工作量统计异常，统计主键值为{0}的统计项时,数据库异常"
    Public Const LOG_VOLUME_STATISTIC_GET_TOTAL_ITEM As String = "工作量统计失败，不能成功获取已存在的统计子项。"

    'Serial Number
    Public Const LOG_SERIAL_NUMBER_IN_THE_TERM As String = "序列号使用期限内，程序允许启动"
    Public Const LOG_SERIAL_NUMBER_ACTIVATION As String = "序列号已经激活，程序允许启动"
    Public Const LOG_SERIAL_NUMBER_ACTIVATION_SUCCESS As String = "序列号激活成功"
    Public Const LOG_SERIAL_NUMBER_GET_SERVERTIME_FAILURE As String = "验证序列号时，获取服务器时间失败"
    Public Const LOG_SERIAL_NUMBER_GET_SERIALTERM_FAILURE As String = "验证序列号时，获取使用期限失败"
    Public Const LOG_SERIAL_NUMBER_GET_SERIALNUM_FAILURE As String = "验证序列号时，获取序列号失败"
    Public Const LOG_SERIAL_NUMBER_EXPECT_SERIALNUM_EMPTY As String = "验证序列号时，预设序列号为空"
    Public Const LOG_SERIAL_NUMBER_NON_ACTIVATION As String = "验证序列号时，真实序列号为空，未激活"
    Public Const LOG_SERIAL_NUMBER_CANNOT_MATCH As String = "验证序列号时，预设序列号与真实序列号不匹配"

    'Hardware
    Public Const LOG_HARDWARE_GET_NETINFO_FAILURE As String = "获取网络适配器信息失败，捕获异常："
    Public Const LOG_HARDWARE_NETINFO_NOT_EXIST As String = "无法在硬件信息表中获得本机IP信息，本机IP列表："
    Public Const LOG_HARDWARE_NETINFO_INFO_ERROR As String = "硬件验证时查询主键值为{0}记录时,内容错误"
    Public Const LOG_HARDWARE_NETINFO_INFO_CHANGE As String = "硬件验证时查询主键值为{0}记录时,硬件已变更"
    Public Const LOG_HARDWARE_NETINFO_INFO_ACTIVATION As String = "主键值为{0}的记录激活成功,IP：{1}，网络适配器：{2}"
    Public Const LOG_HARDWARE_NETINFO_INFO_VALIDATE_SUCCESS As String = "硬件验证通过,IP：{0}，控制点角色：{1}"

    'Package Reg
    Public Const LOG_PACKREG_RELATIONSHIP_PACKAGE_COUNT_ERROR As String = "打包登记时，托盘号为{0}的托盘中，物品编号为{1}的物品，关联至{2}治疗包，物品数量为{3}"

    'PackageRedo
    Public Const LOG_REDO_PACKAGE_STATE_ERROR As String = "重做时查询主键值为{0}治疗包,状态为{1}，不允许重做"

    'HistoryStatistics Parse
    Public Const LOG_HISSTAT_CONFIGFILE_LOAD_FAILURE As String = "历史统计配置文件载入出错"
    Public Const LOG_HISSTAT_CONFIGFILE_SAVE_FAILURE As String = "历史统计配置文件保存出错"
    Public Const LOG_HISSTAT_SAVE_FAIL As String = "保存失败：{0}"
    Public Const LOG_HISSTAT_LOAD_FAIL As String = "加载失败：{0}"
    Public Const LOG_HISSTAT_SAVE_WITH_NO_TIEM As String = "没有任何统计项。"

    '机器连接
    Public Const LOG_DEVARCHIVE_ERROR_CREATE_TEMPDIR_FAILURE As String = "V-TRACK设备连接日志创建临时路径失败，数据路径：{0},捕获异常：{1}"
    Public Const LOG_WASH_DISINFECT_ARCHIVE_SQL As String = "更新清洗登记信息：{0}。"
    Public Const LOG_WASH_DISINFECT_ARCHIVE_SUCCESS As String = "归档清洗日志成功。"
    Public Const LOG_WASH_DISINFECT_FIND_DATA_SUCCESS As String = "找到满足条件的清洗登记信息:机器编号为：{0},开始时间为：{1},批次为：{2}。"
    Public Const LOG_STERILIZE_BATCH_ARCHIVE_SQL As String = "更新灭菌登记信息：{0}。"
    Public Const LOG_STERILIZE_BATCH_ARCHIVE_SUCCESS As String = "归档灭菌日志成功。"
    Public Const LOG_STERILIZE_BATCH_FIND_DATA_SUCCESS As String = "找到满足条件的灭菌登记信息:机器编号为：{0},开始时间为：{1},批次为：{2}。"


    Public Const LOG_ARCHIVE_ERROR As String = "没有找到满足条件的清洗/灭菌的登记信息。机器工作已经结束，无法进行归档。机器编号为:{0}"
    Public Const LOG_ARCHIVE_MACHINE_NONMONOTOR As String = "机器{0}不受监控，线程退出。"

    Public Const LOG_MACHINE_CONFIG_LOAD_FAILURE As String = "设备连接配置文件载入出错,出错文件："

    'PackPrintInfo
    Public Const LOG_PACKPRINTINFO_LOAD_FAILURE As String = "标签打印配置文件载入出错,出错文件："
    Public Const LOG_PACKPRINTINFO_ATT_VALUE_TYPE_MISMATCH As String = "标签打印配置文件value属性不匹配，出错文件："
    Public Const LOG_PACKPRINTINFO_ATT_X_TYPE_MISMATCH As String = "标签打印配置文件x属性不匹配，出错文件："
    Public Const LOG_PACKPRINTINFO_ATT_Y_TYPE_MISMATCH As String = "标签打印配置文件y属性不匹配，出错文件："
    Public Const LOG_PACKPRINTINFO_ATT_SIZE_TYPE_MISMATCH As String = "标签打印配置文件size属性不匹配，出错文件："
    Public Const LOG_PACKPRINTINFO_ATT_REVERSE_TYPE_MISMATCH As String = "标签打印配置文件reverse属性不匹配，出错文件："
    Public Const LOG_PACKPRINTINFO_TYPE_MISMATCH_ITEM As String = "出错条目："
    Public Const LOG_PACKPRINTINFO_ATT_VISIBLE_TYPE_MISMATCH As String = "标签打印配置文件visible属性不匹配，出错文件："

    'Recall
    Public Const LOG_RECALL_NOTE_NOT_EXIST As String = "召回时查询主键值为{0}召回单据,记录不存在"
    Public Const LOG_RECALL_NOTE_STATE_ERROR As String = "召回时查询主键值为{0}召回单据,状态为{1}，不允许执行下一步操作"
    Public Const LOG_RECALL_PACKAGE_STATE_ERROR As String = "召回时查询主键值为{0}治疗包,状态为{1}，不允许召回"


    'Performance Evaluation
    'Public Const LOG_PERFORMANCE_EVALUATION_STAFF_NOT_EXIST As String = "绩效考核统计时，用户编号为{0}的用户,无法获得用户名字"
    'Public Const LOG_PERFORMANCE_EVALUATION_SUB_PROCEDURE_INS_KIND_NOT_EXIST As String = "绩效考核统计时，查询Key为{0}绩效因子对应物品类型集合,记录不存在"
    Public Const LOG_COST_ACCOUNT_DB_EXCEPTIONT As String = "成本核算统计时,数据库异常"

    'Infection Reg
    Public Const LOG_INFECTION_PACKAGE_STATE_ERROR As String = "登记感染时查询主键值为{0}治疗包,状态为{1}，不允许登记感染"

    'INS Image 
    Public Const LOG_COST_PACKING_IMAGE_EXIST_OVERFLOW As String = "编号为{0}的物品，存在多张名为{1}的图片。"
    Public Const LOG_COST_PACKING_IMAGE_NOT_EXIST As String = "不存在名为{0}的图片。"
    Public Const LOG_COST_PACKING_IMAGE_OPEN_ERROR As String = "打开图片{0}失败。原因可能是格式错误。"
    Public Const LOG_COST_PACKING_IMAGE_UPLOAD_ERROR As String = "上传文件{0}失败。"
    Public Const LOG_COST_PACKING_IMAGE_DELETE_ERROR As String = "删除图片{0}失败。"
    Public Const LOG_COST_PACKING_IMAGE_DELETE_TEMP_ERROR As String = "删除或创建临时目录失败。"
    Public Const LOG_COST_PACKING_IMAGE_DOWNLOAD_ERROR As String = "下载图片失败。"
    Public Const LOG_COST_PACKING_IMAGE_UPDATELOG_UPDATE_ERROR As String = "UpdateLog.xml更新失败。"
    Public Const LOG_COST_PACKING_IMAGE_FTP_CONNECT_ERROR As String = "未连接至FTP，更新图片失败，请联系管理员。"

    'LocalSet
    Public Const LOG_CONST_DISPATCH_TODAY_TIME_ANALYTICAL_ERROR As String = "当日发放时间解析错误，内容为 {0}"
End Module

