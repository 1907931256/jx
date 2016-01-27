Public Module MsgConstDef
    'Gerenally
    Public Const MSG_SYSERROR_CONTACTSA As String = "系统出错，请联系管理员。"
    Public Const MSG_DBERROR_EXCEPTION As String = "数据库异常，请联系管理员。"
    Public Const MSG_PARAMETER_ERROR_PLEASE_RESET As String = "参数错误，请重新设置。"
    Public Const MSG_PARAMETER_ERROR_START_BEYOND_END As String = "参数错误，开始时间比结束时间大。"
    Public Const MSG_PARAMETER_ERROR_MACHINETYPE_NOT_SUPPORT As String = "参数错误，机器类型不支持。"
    Public Const MSG_STAFF_NO_SCANPERMITT As String = "当前用户没有扫描权限，请联系管理员。"
    Public Const MSG_ERROR_START_BEYOND_END As String = "起始时间不能晚于结束时间。"
    Public Const MSG_ERROR_PRINT_COLUMNS_TOO_MUCH As String = "打印列过多，请删除部分列后重试。"
    'GridView No Item Alter
    Public Const MSG_GRIDVIEW_NOITEM_ALTER_GERENAL As String = "当前无显示项"
    Public Const MSG_GRIDVIEW_NOITEM_ALTER_QUERY As String = "没有与搜索条件匹配的记录"
    Public Const MSG_GRIDVIEW_NOITEM_INFO_NOT_EXIST As String = "没有匹配的记录"
    Public Const MSG_GRIDVIEW_NOITEM_ERROR_INS_INPUT As String = "请输入申请物品"
    Public Const MSG_GRIDVIEW_NOITEM_RETURN_ERROR_NEED_PACKAGE As String = "请扫描需要回收的治疗包"
    Public Const MSG_GRIDVIEW_NOITEM_INS_USE_ERROR_NEED_PACKAGE As String = "请扫描需要使用的治疗包"
    Public Const MSG_GRIDVIEW_NOITEM_ERROR_SU_IN_REG As String = "请输入入库物品"
    Public Const MSG_GRIDVIEW_NOITEM_ERROR_SU_OUT_REG As String = "请输入出库物品"
    Public Const MSG_GRIDVIEW_NOITEM_SHELF_INS_ERROR_INS_NOT_EXIST As String = "请输入物品信息"
    Public Const MSG_GRIDVIEW_NOITEM_ERROR_DAMAGEINS_INPUT As String = "请输入报损物品"
    Public Const MSG_GRIDVIEW_NOITEM_RECALL_LOG_PRE As String = "没有召回记录"
    Public Const MSG_GRIDVIEW_NOITEM_ERROR_BILLING_INS_INPUT As String = "请输入计费物品"
    Public Const MSG_GRIDVIEW_NOITEM_INFECTED_ERROR_NEED_PACKAGE As String = "请扫描需要登记感染的治疗包"
    Public Const MSG_GRIDVIEW_NOITEM_ERROR_RETURN_INS_INPUT As String = "请输入需要回收的物品"

    'Start Up
    Public Const MSG_START_UP_ONLY_ONE_INSTANCE_PERMIT As String = "操作未能进行，因为已经启动了一个实例。"
    Public Const MSG_START_UP_LOG_FILE_CREATE_ERROR_ As String = "创建日志文件出错，程序将自动退出。"
    Public Const MSG_START_UP_GET_DB_INFORMATION_ERROR As String = "获取数据库信息出错，程序将自动退出。"


    'Login 
    Public Const MSG_LOGIN_USERID_EMPTY As String = "请输入用户编号。"
    Public Const MSG_LOGIN_USERID_NOT_EXIST As String = "{0}号用户不存在。"
    Public Const MSG_LOGIN_PASSWORD_ERROR As String = "密码错误，请重新输入。"
    Public Const MSG_LOGIN_MULTI_USER_ERROR = "{0}编号有多个用户，请联系管理员。"
    Public Const MSG_LOGIN_ROLE_ERROR As String = "{0}不允许{1}登录。"

    Public Const MSG_DEPARTMENT_NOT_EXIST = "{0}科室不存在。"
    'Public Const MSG_MAP_MULTI_DEP_NUMBER = "{0}对应多个科室编号，请联系管理员。"
    'Public Const MSG_FAIL_GET_TIME_FROM_SERVER = "无法得到服务器时间。"
    Public Const MSG_USER_ROLE_NOT_PERMISSIONS_QUERY_PATIENT_USE As String = "用户:{0} 没有权限查看病人使用信息。"

    'Load Info
    Public Const MSG_LOAD_LOCALDATA_ERROR As String = "初始化失败。"

    '自动更新
    Public Const MSG_UPDATE_OVER_RESTART As String = "更新完毕，V-TRACK系统将重启。"
    Public Const MSG_UPDATE_ERROR As String = "自动更新出错。"
    Public Const MSG_ASK_FOR_UPDATING As String = "V-TRACK有新版本，是否执行更新？"

    'INS
    Public Const MSG_OP_INS_RQUEST_ERROR_INS_INFO As String = "物品信息无效，请重新输入。"

    Public Const MSG_HV_INS_RQUEST_ERROR_INS_INFO As String = "配件名称信息无效，请重新输入。"
    Public Const MSG_OP_INS_RQUEST_ERROR_INS_COUNT As String = "物品数量请输入正整数。"
    Public Const MSG_FAILED_MODIFY As String = "修改失败。"
    Public Const MSG_MODIFY_SUCESS As String = "修改成功。"
    Public Const MSG_EXISTED_INPUT_HINT As String = "本项信息已存在，是否归并？"
    Public Const MSG_REQUISITION_BORROW_ERROR As String = "一次性物品不能借用，请重新选择申请类型，或删除一次性物品。"
    Public Const MSG_REQUISITION_GROUP_REQUEST_SUCESS As String = "集中申请成功。"
    Public Const MSG_REQUISITION_BORROW_SUCESS As String = "借用成功，借用单号为：{0}。"
    Public Const MSG_REQUISITION_REQUISITIONED_SU_RU_SUCESS As String = "更换领用成功，单号为：{0}和{1}。"
    Public Const MSG_REQUISITION_REQUISITIONED_SUCESS As String = "更换领用成功，单号为：{0}。"
    Public Const MSG_REQUISITION_REQUISITIONED_SUCESS_RETURN As String = "更换领用成功。"
    Public Const MSG_ERROR_INPUT_DP As String = "请输入科室拼音。"
    Public Const MSG_ERROR_DP_NAME As String = "科室名称错误，请重新输入。"
    Public Const MSG_ERROR_INPUT_WARD As String = "请输入病区拼音。"
    Public Const MSG_ERROR_WARD_NAME As String = "病区名称错误，请重新输入。"
    Public Const MSG_ERROR_GROUP_NAME As String = "组别信息错误，请重新输入。"
    Public Const MSG_ERROR_DISRICT_NAME As String = "请选择院区信息"
    Public Const MSG_ERROR_INS_INPUT As String = "请输入申请物品。"
    Public Const MSG_ERROR_DAMAGEINS_INPUT As String = "请输入报损物品。"
    Public Const MSG_ERROR_INS_COUNT As String = "数量请输入5位以下非负的整数。"
    Public Const MSG_ERROR_INS_INERST As String = "{0}不允许添加{1}类型物品。"
    Public Const MSG_ERROR_INS_MODIFY_REQUEST_LESS_THAN_DISPATCH As String = "申请数量不能小于发放数量。"
    Public Const MSG_ERROR_INS_MODIFY_REQUEST_LESS_THAN_RETURN As String = "申请数量不能小于回收数量。"
    Public Const MSG_REQUEST_PRI_SUCESS_NOTE_ID As String = "登记成功，登记单号为：{0}"
    Public Const MSG_INS_ERROR_INS_COUNT As String = "{0}请输入正整数。"
    Public Const MSG_INS_ERROR_INS_DETAILS_SAME As String = "详细信息中已经存在{0},{1}相同的物品。"
    Public Const MSG_FACTOR_ERROR_INS_COUNT As String = "{0}输入错误，允许输入为只包含一位小数或3位以下数值。"
    Public Const MSG_REQUISITION_OP_SUCESS As String = "手术器械申请成功，申请单号为：{0}。"
    Public Const MSG_AUTO_GENERATE_REQUISITION_OP_SUCESS As String = "自动生成手术器械申请成功，申请单号为：{0}。"
    Public Const MSG_ERROR_PLEASE_INPUT As String = "{0}错误，请重新输入。"
    Public Const MSG_LOANER_INS_REQUEST_ERROR_NEED_SAME_COMPANY As String = "单据中已存在{0}的申请信息，请输入与{0}生产厂商相同的物品信息。"
    Public Const MSG_LOANER_INS_REQUEST_ERROR_COMPANY_NOT_EXIT As String = "编号{0}的物品，生产厂商信息错误。"
    Public Const MSG_OP_REQUEST_ERROR_ONE_NOTE_ALLOW_ONE_OPERATION As String = "不允许添加多次手术物品，请确认后再次添加。"
    Public Const MSG_ERROR_BILLING_INS_INPUT As String = "请输入计费物品。"
    Public Const MSG_FAILED_SU_REQUEST_STOCK_NOT_ENOUGH As String = "编号为{0}的{1}申请数量为{2}，实际库存为{3}，请修改数量后再提交。"
    Public Const MSG_ERROR_PACK_STAFF_SHOULD_BE_DIFFENCE As String = "打包人员不能相同，请重新输入。"
    Public Const MSG_STERILIZE_INFO_STOP_YESORNO As String = "是否停用编号为{0}的物品？"
    Public Const MSG_STERILIZE_INFO_ENABLE_YESORNO As String = "是否启用编号为{0}的物品？"
    Public Const MSG_ERROR_DEPARTMENT_INS_LOW_STOCK As String = "{0}号物品{1}库存量不足，请重新填写数量！"
    Public Const MSG_AUTO_DISPATCH_SUCESS As String = "自动发放成功。"
    Public Const MSG_ERROR_DS_NAME As String = "请选择院区名称"
    Public Const MSG_REQUISITION_DISTRICT_REQUEST_SUCESS As String = "单据申请成功。"
    Public Const MSG_REQUISITION_OP_HVSU_SUCESS As String = "一次性高值耗材申请成功，申请单号为：{0}。"
    Public Const MSG_REQUISITION_OP_HVRU_SUCESS As String = "非一次性高值耗材申请成功，申请单号为：{0}。"
    Public Const MSG_ERROR_NOTE_NOT_NEED_INS As String = "此单据不需要物品：{0}"
    Public Const MSG_ERROR_NOTE_RETURN_BELONG_REQUEST As String = "回收数量多于申请数量，请重新输入"
    Public Const MSG_ERROR_NOTE_RETURN_COUNT_LONG As String = "回收数量过大"
    Public Const MSG_ERROR_NOTE_RETURN_PARAMENT As String = "参数错误，请联系管理员"
    Public Const MSG_ERROR_NOTE_RETURN_EXIST_DONE As String = "是否放弃本次操作。"
    Public Const MSG_ERROR_NUMBER_INVALID As String = "数值无效，请输入非负数"
    Public Const MSG_ERROR_TRAY_ID As String = "{0}为敷料包，不允许清洗消毒"
    Public Const MSG_ERRR_NO_TRAY As String = "请选择托盘"
    Public Const MSG_ERRR_NO_TRAY_CONTINUE As String = "选择是回收上述物品，并不添加至托盘。"
    Public Const MSG_ERROR_TRAY_LOAD_ERROR As String = "托盘信息加载出错。"
    Public Const MSG_ERROR_TRAY_STATE As String = "{0}号托盘的状态为{1}，不允许将物品回收至该托盘，请重新选择托盘。"
    Public Const MSG_ERROR_TRAY_INFO As String = "托盘信息有误，请重新输入"

    'Clean Reg
    Public Const MSG_CLEANREG_CHANGE_TRAY_INS_YESORNO As String = "您修改了托盘中的物品，是否继续？"
    Public Const MSG_CLEANREG_CHANGE_CLEANER_TRAY_YESORNO As String = "您修改了清洗消毒器中的托盘，是否继续？"
    Public Const MSG_CLEANREG_CHANGE_STERILIZER_PACKAGE_YESORNO As String = "您修改了灭菌器中的治疗包，是否继续？"
    'Sterilize reg
    Public Const MSG_CLEANREG_CHANGE_BARROW_PACKAGE_YESORNO As String = "您修改了推车中的治疗包，是否继续？"
    'Dispatch prepare
    Public Const TEXT_DISPACTHPREPARE_ERROR_QUERY_PACKAGE_NOTEXIST As String = "{0}号治疗包不存在。"
    Public Const TEXT_DISPACTHPREPARE_ERROR_PACKAGE_OVERFLOW As String = "{0}号治疗包信息不唯一。"
    Public Const TEXT_DISPACTHPREPARE_ERROR_QUERY_PACKAGE_DBERROR As String = "查询治疗包信息时" & MSG_DBERROR_EXCEPTION
    Public Const TEXT_DISPACTHPREPARE_ERROR_EXPIRED As String = "该物品已过期，不允许发放！"
    Public Const TEXT_DISPACTHPREPARE_ERROR_INS_LESS As String = "发放数量不允许小于0或为空，请重新填写发放数量！"
    Public Const TEXT_DISPACTHPREPARE_ERROR_INS_MORETHAN_RES As String = "发放数量不允许大于库存量，请重新填写发放数量！"
    'WH info
    Public Const MSG_WH_ERROR_SU_NOT_EXIT As String = "编号{0}批次为{1}的物品不存在。"
    Public Const MSG_WH_ERROR_SU_COMPANY_NOT_EXIT As String = "编号{0}的物品批次与生产厂商不符。"
    Public Const MSG_WH_ERROR_RU_NOT_EXIT As String = "编号{0}的物品库存不足。"
    Public Const MSG_WH_ERROR_SU_EXIST_OVERFLOW As String = "编号{0}批次为{1}的物品存在多条。"
    Public Const MSG_WH_ERROR_RU_EXIST_OVERFLOW As String = "编号{0}的物品存在多条。"
    Public Const MSG_WH_ERROR_EXIST_OUT_STERILEROOM As String = "库房物品中非一次性物品不可出库至无菌区。"
    Public Const MSG_ERROR_WH_OUT_REG As String = "请输入出库物品。"
    Public Const MSG_ERROR_WH_OUT_REG_COUNT_OVERFLOW As String = "编号{0}批次为{1}的库房物品出库至无菌区，对应编号为{2}的物品，比例为1：{3}，数量超过5位，请重新输入。"
    Public Const MSG_ERROR_WH_OUT_REG_COUNT_NO_RELATIONSHIP As String = "编号{0}批次为{1}的库房物品出库至无菌区，没有可对应的物品，请联系管理员。"
    'Query Note
    Public Const MSG_NOTE_NOT_EXIT As String = "您所查询的单据不存在。"
    Public Const MSG_NOTE_DISPATCHED As String = "此单据已发放，不允许解锁。"
    Public Const MSG_NOTE_RECEIVED As String = "此单据已接收，不允许解锁。"
    Public Const MSG_NOTE_NOT_CONFIRM As String = "此单据未确认，无须解锁。"
    Public Const MSG_NOTE_UNLOCK_SUCESS As String = "单据解锁成功。"
    Public Const MSG_DELETE_SUCESS As String = "信息删除成功。"
    Public Const MSG_NOTE_NOT_ALLOW_DETELE As String = "该单据不允许删除。"
    Public Const MSG_NOTE_NOT_ALLOW_MODIFY As String = "此单据已发放，不允许修改。"
    Public Const MSG_NOTE_NOT_ALLOW_MODIFY_FOR_RECEIVED As String = "此单据已接收，不允许修改。"
    Public Const MSG_NOTE_NOT_ALLOW_MODIFY_FOR_BORROW_BACK As String = "此单据已归还，不允许修改。"
    Public Const MSG_NOTE_NOT_ALLOW_MODIFY_FOR_BORROW_BACK_CONFRIM As String = "此单据已归还确认，不允许修改。"
    Public Const MSG_NOTE_NOT_ALLOW_MODIFY_YET As String = "此单据{0}，不允许修改。"
    Public Const MSG_NOTE_LOCKED_NOT_ALLOW_MODIFY As String = "此单据被锁定，请解锁后继续操作。"
    Public Const MSG_NOTE_AUDIT_NOT_ALLOW_MODIFY As String = "此单据已审核，请解锁后继续操作。"
    Public Const MSG_NOTE_CHANGE_INS_YESORNO As String = "您修改了单据中的物品，是否继续？"
    Public Const MSG_NOTE_FORMAT_ERROR As String = "单号格式错误，请重新输入。"
    Public Const MSG_NOTE_DELETE As String = "是否删除{0}号单据？"
    Public Const MSG_DATE_ERROR_STARTDATE_LATER_THAN_ENDDATE As String = "查询条件错误：起始时间不能晚于结束时间。"
    Public Const MSG_NOTE_NOT_ALLOW_MODIFY_FOR_REQUEST_USER_ERROR As String = "此单据不是当前用户申请，不允许修改。"
    Public Const MSG_NOTE_NOT_ALLOW_DELETE_FOR_REQUEST_USER_ERROR As String = "此单据不是当前用户申请，不允许删除。"
    Public Const MSG_NOTE_NOT_ALLOW_MODIFY_FOR_REQUEST_DP_ERROR As String = "此单据不是当前科室申请，不允许修改。"
    Public Const MSG_NOTE_NOT_ALLOW_DELETE_FOR_REQUEST_DP_ERROR As String = "此单据不是当前科室申请，不允许删除。"
    Public Const MSG_NOTE_NOT_ALLOW_AUDIT_FOR_REQUEST_DP_ERROR As String = "此单据不是当前科室申请，不允许审核。"
    Public Const MSG_NOTE_DELETE_ERROR As String = "删除单据错误，请联系管理员。"
    Public Const MSG_INPUT_EMPTY_ERROR As String = "{0}不能为空，请输入。"
    Public Const MSG_INPUT_DP_NAME_NOT_EXIST As String = "输入的手术室名称不存在，请重新输入。"
    Public Const MSG_INPUT_USER_NAME_NOT_EXIST As String = "输入的护士名称不存在，请重新输入。"
    Public Const MSG_INPUT_PATIRNT_USER_NAME_NOT_ALL_EMPTY As String = "{0}和{1}不能全部为空，请重新输入。"
    Public Const MSG_ERROR_GET_DP_INFO_FAILE As String = "获取科室信息失败"
    Public Const MSG_ERROE_DP_NOT_IN_ONE_DISTRICT As String = "{0} 科室与 {1} 科室不在同一个院区，请重新输入科室名称"
    Public Const MSG_NOTE_NOT_ALLOW_NOTICE_FOR_REQUEST_DP_ERROR As String = "此单据不是当前用户所在科室申请，不允许通知归还。"


    'RUTrace
    Public Const TEXT_TRACE_RU_PACKAGE_FORMAT_ERROR As String = "治疗包编号格式错误，请重新输入！"
    Public Const TEXT_TRACE_RU_PACKAGE_ERROR_EXCEPTION As String = "获得治疗包的回溯信息失败！"
    Public Const TEXT_TRACE_RU_PACKAGE_NOT_EXIST As String = "{0}号治疗包不存在。"
    Public Const TEXT_TRACE_RU_PACKAGE_ERROR_NOT_EXIST As String = "编号 {0} 的物品 {1} 无打包信息。"
    Public Const TEXT_TRACE_RU_INS_ERROR_EXCEPTION As String = "获得编号为 {0} 的物品 {1} 的回溯信息失败！"
    Public Const MSG_OP_INS_RQUEST_ERROR_INS_INFO_MORE_NAME As String = "物品信息无效，存在相同物品名的物品信息。"

    'SUInReg
    Public Const MSG_COMPANY_ERROR_INFO As String = "生产厂家信息无效，请重新输入。"
    Public Const MSG_BATCH_INFO_ERROR As String = "生产批号输入错误，请重新输入，生产批号格式为yyyyMMdd，如20090101，yyyy表示年份，MM表示月份。"
    Public Const MSG_BATCH_INFO_ERROR_TOO_LONG As String = "生产批号输入错误，请重新输入。"
    Public Const MSG_EFFECTDATE_ERROR As String = "请选择有效期。"
    Public Const MSG_VALIDDATE_ERROR As String = "请输入失效时间。"
    Public Const MSG_ERROR_SU_IN_REG As String = "请输入入库物品。"
    Public Const MSG_INSERT_ERROR As String = "物品编号为{0}生产厂家为{1}的物品已经存在失效日期为{2}的记录，同一批号的物品，不允许登记不同失效日期的记录。"
    Public Const MSG_SU_IN_REG_INSERT_ERROR As String = "新入库的物品不能与已存在的同一批号物品失效日期不同。已存在批号为{0}的物品失效日期为{1}。"
    Public Const MSG_INSERT_SUCESS As String = "信息登记成功。"
    Public Const MSG_WAREHOUSE_STOCK_NOT_ENOUGH As String = "物品名称为{0}，厂商为{1}，批次为{2}的物品库存数量不足，请重新输入出库数量"
    Public Const MSG_WAREHOUSE_STOCK_NOT_EXIST As String = "物品名称为{0}，厂商为{1}，批次为{2}的库存信息不存在，请重新输入"

    'SUStock
    Public Const MSG_QUERY_INFO_NOT_EXIT As String = "您所查询的信息不存在。"
    'RUStock
    Public Const MSG_REAL_STOCK_CHANGED As String = "库存量有变动，请先刷新。"
    Public Const MSG_INS_ERROR_PARAMETER As String = "物品编号错误。"

    'USER MAINTENANCE
    Public Const MSG_USER_MAINTENANCE_USER_NOTEXIST As String = "用户信息不存在。"
    Public Const MSG_USER_MAINTENANCE_DELETE_YESORNO As String = "是否删除{0}号用户？"
    Public Const MSG_USER_MAINTENANCE_ERROR_ID_NOTEXIST As String = "请输入用户编号。"
    Public Const MSG_USER_MAINTENANCE_ERROR_ID_LENGTH_ERROR As String = "用户编号字符长度过长，请重新输入。"
    Public Const MSG_USER_MAINTENANCE_ERROR_NAME_NOTEXIST As String = "请输入用户名。"
    Public Const MSG_USER_MAINTENANCE_ERROR_PASSWORD_NOTEXIST As String = "请输入密码。"
    Public Const MSG_USER_MAINTENANCE_ERROR_PERMIT_NOTEXIST As String = "请选择用户权限。"
    Public Const MSG_USER_MAINTENANCE_ERROR_CHINESECODE As String = "请输入拼音代码。"
    Public Const MSG_USER_MAINTENANCE_ERROR_DEPARTMENT_NOTEXIST As String = "请输入用户科室。"
    Public Const MSG_USER_MAINTENANCE_ERROR_ID_EXIST_ONE As String = "{0}号用户已存在。"
    Public Const MSG_USER_MAINTENANCE_ERROR_ID_EXIST_OVERFLOW As String = "{0}号用户有多项记录。"
    Public Const MSG_USER_MAINTENANCE_USER_CHANGE_YESORNO As String = "您修改了用户信息，是否继续？"
    Public Const MSG_USER_MAINTENANCE_ERROR_COMFIRMPASSWORD As String = "两次输入的密码不同。"
    Public Const MSG_USER_MAINTENANCE_ERROR_OLDPASSWORD As String = "旧密码错误，请重新输入。"

    'Sterilize Info
    Public Const MSG_STERILIZE_INFO_DELETE_YESORNO As String = "是否删除编号为{0}的信息？"
    Public Const MSG_STERILIZE_INFO_ERROR_NAME_NOTEXIST As String = "请输入名称。"
    Public Const MSG_STERILIZE_INFO_ERROR_METHOD_NOTEXIST As String = "请选择灭菌方式。"
    Public Const MSG_STERILIZE_INFO_ERROR_VALID_DATE As String = "有效期限请输入正整数。"
    Public Const MSG_STERILIZE_INFO_ERROR_UNIT_NOTEXIST As String = "请选择单位。"
    Public Const MSG_STERILIZE_INFO_CHANGE_YESORNO As String = "您修改了信息，是否继续？"

    'Equipment Info
    Public Const MSG_EQUIPMENT_INFO_ERROR_TYPE_NOTEXIST As String = "请选择机器类型。"
    Public Const MSG_STERILIZE_INFO_ERROR_TYPE_NAME_NOTEXIST As String = "请输入类型名称。"
    Public Const MSG_STERILIZE_INFO_ERROR_TYPE_LIMIT_VALUE_NOTEXIST As String = "限时数值请输入正整数。"
    Public Const MSG_STERILIZE_INFO_ERROR_TYPE_LIMIT_UNIT_NOTEXIST As String = "请选择限时单位。"

    'Return Reg
    Public Const MSG_RETURN_REG_EXCHANGE_REG_AGAIN_YESORNO As String = "本次回收登记已经登记更换单，是否再次登记？"
    Public Const MSG_RETURN_REG_NEED_EXCHANGE_REG_YESORNO As String = "本次回收登记未登记更换单，是否登记？"
    Public Const MSG_RETURN_REG_TRAY_INFO_ERROR As String = "托盘信息载入出错"
    Public Const MSG_RETURN_REG_DRESS_INS_CANNOT_TO_TRAY As String = "敷料布类包不允许放入托盘"


    'Print
    Public Const MSG_PRINT_FILE_FORMAT_ERROR As String = "打印格式文件载入出错。"
    Public Const MSG_PRINT_FAIL_FINISH_PRINT As String = "打印未完成，请确认打印机是否正常。"

    'RequestPri
    Public Const MSG_STERILIZE_DATE_ERROR As String = "灭菌时间不允许小于今天。"
    Public Const MSG_STERILIZE_INS_INFO As String = "编号{0}的物品需要{1}"
    Public Const MSG_STERILIZE_CHECK As String = "确实要{0}吗？"

    'SUDispatchQuery 
    Public Const MSG_CMBCOMPANY_EMPTY As String = "请选择生产厂家。"
    Public Const MSG_CMBBATCH_EMPTY As String = "请选择生产批号。"

    'AutoWarning
    Public Const MSG_BORROW_BACK_CONFIRM_HAS_CONFIRMED As String = "{0}借单已确认归还。"
    Public Const MSG_BORROW_BACK_CONFIRM_ONE_CONFIRM_REG As String = "{0}借单归还确认？"
    Public Const MSG_BORROW_BACK_CONFIRM_ALL_CONFIRM_REG As String = "所有借单归还确认？"

    'Device Manage
    Public Const MSG_LEGEND_NAME_EXISTED As String = "当前的名字已经存在，请重新输入。"
    Public Const MSG_FAIL_QUERY_DEV_UTILITY_RATE As String = "查询指定设备的使用率失败。"
    Public Const MSG_FAIL_QUERY_WORK_VOLUME As String = "查询指定的工作量失败。"
    Public Const MSG_LOAD_HIS_STATISTICS_FAIL As String = "部分历史统计数据载入出错。"
    Public Const MSG_SAVE_HIS_STATISTICS_FAIL As String = "保存历史统计数据出错。"

    'Volume Manage
    Public Const MSG_ADD_ITEM_NAME_EMPTY As String = "类型名称不能为空，请输入。"
    Public Const MSG_SELECT_ITEM_EMPTY As String = "当前没有条目被选入，请选择。"
    Public Const MSG_SELECT_ITEM_ALREADY As String = "该条目已经被选中。"
    Public Const MSG_INS_STATISTICS_TYPE_EMPTY As String = "当前统计类型无效，请选择。"

    'Check
    Public Const MSG_ACBIO_CHECK_LOCATION_ERROR As String = "请选择监测位置。"
    Public Const MSG_DELETE_CUR_INFO_YESORNO As String = "是否删除当前的信息？"
    Public Const MSG_CUR_INFO_HAD_DELETE As String = "当前信息已被删除。"
    Public Const MSG_EXAM_RESULT_CHECKD_ERROR As String = "请选择实验管结果。"
    Public Const MSG_COLLATOR_RESULT_CHECKD_ERROR As String = "请选择对照管结果。"

    'Infection Checked
    Public Const MSG_ERROR_PACKAGE_COUNT_ERROR As String = "包数有误，请输入正整数。"

    'Department
    Public Const MSG_DEPARTMENT_MAINTENANCE_ERROR_ID_EXIST_ONE As String = "{0}号科室已存在。"
    Public Const MSG_DEPARTMENT_MAINTENANCE_ERROR_ID_EXIST_OVERFLOW As String = "{0}号科室有多项记录。"
    Public Const MSG_DEPARTMENT_MAINTENANCE_DELETE_YESORNO As String = "是否删除科室编号为{0}的信息？"
    Public Const MSG_DEPARTMENT_ERROR_DPGROUP_NAME As String = "所属组合错误，请重新输入。"
    Public Const MSG_DEPARTMENT_ERRO_BELONG_ID_EXIST As String = "归属科室编号 {0} 已存在，请重新输入。"
    Public Const MSG_DEPARTMENT_ERRO_BELONG_NAME_EXIST As String = "归属科室名称 {0} 已存在，请重新输入。"
    Public Const MSG_DEPARTMENT_MAINTENANCE_ERROR_BELONG_NAME As String = "归属科室错误，请重新输入。"
    Public Const MSG_DEPARTMENT_MAINTENANCE_ERROR_DISTRICT_NAME As String = "所属院区错误，请重新输入。"

    'LocalSetting
    Public Const MSG_LOCAL_SETTING_INSTALL_SUCESS As String = "设置成功。"
    Public Const MSG_LOCAL_SETTING_MORTH_THEN_TWO As String = "最多可设2项。"
    Public Const MSG_LOCAL_SETTING_MUST_ONE_KIND As String = "{0}只可以设置1项。"
    Public Const MSG_LOCAL_SETTING_MUST_SELECT_ONE_LABEL As String = "请先选择一种标签。"

    'Shelf
    Public Const MSG_SHELF_INS_ERROR As String = "{0}错误，请重新输入。"
    Public Const MSG_SHELF_INS_ERROR_ID_EXIST_ONE As String = "{0}货架已存在{1}号物品。"
    Public Const MSG_SHELF_INS_ERROR_ID_EXIST_OVERFLOW As String = "{0}货架有{1}号物品的多项记录。"
    Public Const MSG_SHELF_INS_ERROR_INS_NOT_EXIST As String = "货架物品信息不存在，请输入物品信息。"
    Public Const MSG_SHELF_ERROR_EXIST_ONE As String = "{0}货架已存在。"
    Public Const MSG_SHELF_ERROR_EXIST_OVERFLOW As String = "{0}货架有多项记录。"
    'Lisence Admin
    Public Const MSG_QUERY_LIECENSE_FAIL As String = "获取许可信息失败。"
    Public Const MSG_DESC_EMPTY As String = "描述项内容不能为空。"
    Public Const MSG_IP_EMPTY As String = "IP项内容不能为空。"
    Public Const MSG_IP_FORMAT_ERROR As String = "IP地址格式错误。"
    Public Const MSG_IP_SAME_EXIST As String = "已经存在相同的IP地址。"
    Public Const MSG_DEL_HARDWARE_QUERY As String = "确定删除吗?"
    Public Const MSG_RESET_HARDWARE_QUERY As String = "确定重置吗?"
    Public Const MSG_IMPORT_FILE_FAIL As String = "导入文件失败。"
    Public Const MSG_IMPORT_FILE_SCUSSCE As String = "导出文件成功"
    Public Const MSG_ADD_LICENSE_FAIL As String = "添加失败。"

    'SUBack
    Public Const MSG_SU_BACK_COUNT_MORE_THAN_DISPATCH As String = "退回数量大于发放数量，请重新输入。" & Chr(10) & "本次允许最大退回数量为：{0}"

    'OPStock
    Public Const MSG_OP_STOCK_REMOVE_PACKAGE As String = "确定下架{0}治疗包？"
    Public Const MSG_OP_STOCK_GET_KNIFE_REST_ERROR As String = "停刀架信息获取失败，请联系管理员。"

    'Terminal 
    Public Const MSG_TERMINAL_NOT_CONNECT As String = " 手持终端未连接，请检查后再尝试。"
    Public Const MSG_GET_TERMINAL_FAIL As String = "载入失败，请联系管理员。"

    'UserGroupSet
    Public Const MSG_USER_GROUP_STAFF_ERROR As String = "人员信息错误，请重新输入。"
    Public Const MSG_USER_GROUP_ERROR As String = "组别信息错误，请重新输入。"
    Public Const MSG_USER_GROUP_STAFF_NOT_EXIST As String = "当前组别没有人员信息，请添加。"


    'Recall
    Public Const MSG_RECALL_LOSTED_REG As String = "{0}号治疗包丢失确认？"
    Public Const MSG_RECALL_END_REG As String = "结束单号为{0}的召回？"
    Public Const MSG_RECALL_NOTE_RECALLED As String = "此单据已召回，不允许解锁。"
    Public Const MSG_RECALL_INFO_NOT_EXIT As String = "当前信息已不存在。"
    Public Const MSG_NOTE_NOT_ALLOW_CUR_OPERATE As String = "该单据不允许当前操作。"

    'CostAccount
    Public Const MSG_INS_ERROR_COST As String = "{0}请输入正确的金额。"
    Public Const MSG_INS_ERROR_COST_RATIO As String = "{0}请输入正确的百分比。"

    'ExportExcel
    Public Const MSG_EXCEL_SOFT_ERROR As String = "当前的系统可能未安装MicroSoft Excel 系列软件，请安装后重试!"
    Public Const MSG_EXCEL_EXPORT_ERROR As String = "导出错误,请联系管理员！"
    Public Const MSG_EXCEL_REOVER_FILE_ERROR As String = "文件正在被使用，请关闭后再进行覆盖！"
    Public Const MSG_EXCEL_CONFIG_ERROR As String = "配置错误，请联系管理员！"

    'INSMenu Info
    Public Const MSG_INS_MENU_INFO_DELETE_BY_REG_ID_YESORNO As String = "是否删除套餐名为{0}的信息？"
    Public Const MSG_INS_MENU_INFO_DELETE_BY_DP_ID_YESORNO As String = "是否删除{0}的所有套餐信息？"

    'Department INS Flow
    Public Const MSG_DEPARTMENT_INS_FLOW_EXISTED_INPUT As String = "科室为{0}，物品为{1}的信息已存在，不允许添加。"
    Public Const MSG_DEPARTMENT_INS_FLOW_ERROR_SUM_COUNT As String = "发放数量加回收数量不能大于物品基数。"

    'Service Plans
    Public Const MSG_SERVICE_PLANS_ERROR_TYPE_NOTEXIST As String = "请选择维护类型。"
    Public Const MSG_SERVICE_PLANS_ERROR_NAME_NOTEXIST As String = "请输入维护项目。"
    Public Const MST_PLEASE_SELECT_ITEM As String = "请选择{0}。"
    Public Const MSG_SERVICE_PLANS_NOT_MONITOR_IF_DELETE As String = "该记录为下次提醒记录，如删除下次将不提醒，是否删除？"

    'Infection
    Public Const MSG_ERROR_INFECTION_CULTURE_NOT_EXIST As String = "请选择感染菌种。"

    Public Const MSG_PACKING_IMAGE_OPEN_ERROR As String = "打开图片失败,原因可能是格式错误。"

    'WorkSheet
    Public Const MSG_ERROR_LENGTH As String = "工作分配输入字符不能超过20个，请重新输入！"
    Public Const MSG_ADD_NAME_EMPTY As String = "班种类别不能为空"
    Public Const MSG_LEGEND_NAME_EXISTED_MODIFY As String = "班种类别已存在，请重新输入"
    'Examine
    Public Const MSG_ERROR_ITEMNAME_EXISTED_MODIFY As String = "项目名称已存在，请重新输入。"
    Public Const MSG_ERROE_ITEM_NAME_EMPTY As String = "项目名称不能为空。"
    Public Const MSG_ERROE_COM_NAME_EMPTY As String = "单位名称不能为空。"
    Public Const MSG_ERROR_TYPE_NAME_EMPTY As String = "培训类型不能为空。"

    Public Const MSG_ERROR_NAME_EMPTY As String = "请输入员工姓名。"
    Public Const MSG_ERROE_ID_EMPTY As String = "请输入员工编号。"
    Public Const MSG_ERROR_ITEM_EMPTY As String = "请输入考试项目。"
    Public Const MSG_ERROR_TRIAN_EMPTY As String = "请输入培训类型。"
    Public Const MSG_ERROR_DUTY_EMPTY As String = "请输入考试类型。"
    Public Const MSG_ERROR_COM_EMPTY As String = "请输入培训单位。"
    Public Const MSG_ERROR_GRADE_EMPTY As String = "请输入有效成绩，支持2位小数，范围在0~1000。"
    Public Const MSG_ERROR_TIME_FRONT As String = "请选择过去的时间。"
    Public Const MSG_ERROR_ID_NOT_EXSIT As String = "员工ID不存在。"
    Public Const MSG_ERROR_NAME_NOT_EXSIT As String = "员工姓名不存在。"
    Public Const MSG_ERROR_STAR_BIGER_END As String = "开始时间大于结束时间。"
    Public Const MSG_ERROR_NO_ITEM As String = "无效考试项目，请重新输入。"
    Public Const MSG_ERROR_NO_COM As String = "无效培训单位名称，请重新输入。"
    Public Const MSG_ERROR_NO_TRAIN_TYPE As String = "无效培训类型，请重新输入。"
    Public Const MSG_ERROR_NO_DUTY_TYPE As String = "无效考试类型，请重新输入。"

    Public Const MSG_ERROR_EXPENSE_SETTING_DP_EMPTY As String = "手术室信息错误，请重新输入。"
    Public Const MSG_ERROR_EXPENSE_SETTING_DP_OOM_EMPTY As String = "手术使用间信息错误，请重新输入。"
    Public Const MSG_ERROR_STERILIZER_FAILE_REASON_EXIST As String = "灭菌不合格原因已存在，请重新输入。"
    Public Const MSG_ERROR_CLEAN_FAILE_REASON_EXIST As String = "清洗不合格原因已存在，请重新输入。"
    Public Const MSG_ERROR_USE_FAILE_REASON_EXIST As String = "不合格原因已存在，请重新输入。"

    Public Const MSG_CONTROL_ERROR_NUD_SELECT As String = "请重新输入{0}、范围{1}-{2}"
    Public Const MSG_ERROR_UVLAMP_EXIST As String = "紫外线灯管名称已存在，请重新输入"
    Public Const MSG_ERROR_UVLAMP_USED_TIME As String = "请重新输入{0}、范围{1}-{2}，支持2位小数"
    Public Const MSG_ERROR_INPUT__POSITIVE_INT As String = "{0}无效、请输入合法的正整数"
    Public Const MSG_ERROR_UVLAMP_INFO As String = "紫外线灯管：{0}信息不存在"
    Public Const MSG_ERROR_UVLAMP_TIME_CONFLICT As String = "时间冲突：{0}灯管在{1}时照射{2}小时"
    Public Const MSG_ERROR_UVLAMP_TIME_OVER As String = "{0}灯管照射时间大于剩余时间，请重新输入"
    Public Const MSG_ERROR_UVLAMP_TIME_APPROACH As String = "{0}灯管使用时间接近寿命,请注意下次更换灯管"
    Public Const MSG_ERROR_UVLAMP_TIME_CHANGE_CONFLICT As String = "时间冲突：{0}灯管更换时间已存在"
    Public Const MSG_ERROR_UVLAMP_TIME_CHANGE_OK As String = "{0}灯管使用时间没达到最大寿命，是否更换"
    Public Const MSG_ERROR_UVLAMP_CHANGE_TIME_CONFLICT As String = "紫外线灯管正在照射，不允许更换：{0}灯管在{1}时照射{2}小时"
    Public Const MSG_ERROR_UVLAMP_CHANGE_TIME_CONFLICT_OK_CAMCEL As String = "{0}灯管在{1}时照射{2}小时。紫外线灯管正在照射，是否更换?"
    Public Const MSG_ERROR_UVLAMP_CONTINUE_SHINE As String = "是否继续上次未完成的照射"
    Public Const MSG_ERROR_UVLAMP_CHANGED_NUOPERATE As String = "{0}灯管已更换，不允许其它操作"
    Public Const MSG_ERROR_UVLAMP_OPERATE_TIME_PER As String = "操作时间不能大于今天"
    Public Const MSG_ERROR_UVLAMP_CHANGED_TIME_NULAST As String = "{0}灯管不允许更换：本次更换操作时间后有其他操作"

    'Clean Sterilizer Audit
    Public Const MSG_ERROR_SELECT_AUDIT_RESULT As String = "请选择审核结果。"

    Public Const MSG_SAVE_REALTIME_MACHINE_INFORMATION_ERROR As String = "保存机器信息出错，请联系管理员。"

    'Scan
    Public Const MSG_PACKAGE_SCAN_CONTROL_ERROR_PACKAGE_EXIST_INLIST As String = "{0}号治疗包已被扫描。"
    Public Const MSG_PACKAGE_SCAN_CONTROL_ERROR_PACKAGE_NOT_EXIST As String = "{0}号治疗包不存在。"
    Public Const MSG_PACKAGE_SCAN_CONTROL_ERROR_PACKAGE_NOT_ALLOW_RETURN As String = "治疗包编号为{0}的治疗包不允许{1}，该治疗包将不被记录入本次{1}。"
    Public Const MSG_PACKAGE_SCAN_CONTROL_ERROR_PACKAGE_NOT_ALLOW_RETURN_REASON As String = "该治疗包错误信息：{0}"

    'use
    Public Const MSG_ERROR_USE_AUDIT_ERROR_METHOD As String = "请选择处理方法"
    Public Const MSG_ERROR_USE_AUDIT_HAS_UNCHECK As String = "存在没有检查确认的治疗包，是否继续？"
    Public Const MSG_ERROR_OP_STERILIZER_ROOM_NOTHING As String = "获取手术室无菌区信息错误。"

    'Stop use
    Public Const MSG_ERROR_USE_STOP_NOT_EXIST As String = "获取{0}号治疗包时，数据库异常"
    Public Const MSG_ERROR_USE_STOP_PACKAGE_STATE_ERROR As String = "{0}治疗包状态为{1}，不能变更"
    Public Const MSG_ERROR_USE_STOP_PACKAGE_NOT_CHAGE As String = "以上物品不做变更处理"


    'District
    Public Const MSG_EOOR_MAIN_DISTRICT_STOP As String = "主院区不可停用"
    Public Const MSG_EOOR_NAME_EMPTY As String = "院区名称不能为空，请重新输入"
    Public Const MSG_EOOR_NAME_EXIT As String = "院区名称 {0} 已存在，请重新输入"
    Public Const MSG_EOOR_MAIN_NOT_SET As String = "停用的院区不可设为主院区"
    Public Const MSG_EOOR_STERILIZERROOM_NOT_FIND As String = "查找院区 {0} 无菌区，不存在"
    Public Const MSG_ERROR_STERILIZERROOM_OVERLOAD As String = "查找院区 {0}，存在多个供应室无菌区"

    'HighVale
    Public Const MSG_CHECK_DATE_INFO_ERROR As String = "检验日期输入错误，请重新输入，格式为yyyyMMdd，如20090101，yyyy表示年份，MM表示月份。"
    Public Const MSG_VALI_DATE_INFO_ERROR As String = "失效日期输入错误，请重新输入，格式为yyyyMMdd，如20090101，yyyy表示年份，MM表示月份。"
    Public Const MSG_EXIST_RECODR As String = "序列条码{0}的高值耗材已存在，请重新输入"
    Public Const MSG_SCAN_HV_INS As String = "请扫描高值耗材序列条码"
    Public Const MSG_ERROR_SN_CODE_LESS As String = "请扫描有效的序列条码,13-25位数字"
    Public Const MSG_ERROR_COM_CODE_LESS As String = "请扫描有效的厂商条码,10-25位数字"
    Public Const MSG_ERROR_BATCH_CODE_LESS As String = "请扫描有效的生产批号,8-12位数字"
    Public Const MSG_ERROR_CHECKDATE_BEYONUD_VALIDDATE As String = "检验日期大于失效日期，请重新输入"

    'INS Container
    Public Const MSG_INS_CONTAINER_NAME_EMPTY_ERROR As String = "请输入容器名称"
    Public Const MSG_INS_CONTAINER_IMG_EMPTY_ERROR As String = "请选择容器图片"

    'system setting
    Public Const MSG_SYSTEM_SETTING_RECEIVE_TAKING As String = "接收单据设置不正确，公用物品申请单及手术器械申请单至少选择一项。"

    'Ware house label print
    Public Const MSG_INPUT_CONTROL_ERROR_INS_EXPIRED_LATER As String = "物品失效日期小于当前日期。请确认。"
    Public Const MSG_INPUT_CONtROL_ERROR_INS_EXPRIED_LESS_PRODUCE_DATE As String = "物品失效日期小于生产日期，请确认。"

    'Dispatch today set
    Public Const MSG_ERROR_STAR_DAY_EMPTY As String = "提前天数不能为空"
    Public Const MSG_ERROR_END_DAY_EMPTY As String = "推迟天数不能为空"
    Public Const MSG_ERROR_EXIST_SET_INFO As String = "信息已存在，请重新输入"

    'Borrow notice
    Public Const MSG_BORROW_NOTICE_CONFIRM As String = "确认 {0} {1} 归还通知?"
    Public Const MSG_BORROW_NOTICE_BACKED As String = "此单据已通知归还，不允许再次通知归还。"
    Public Const MSG_INPUT_ERROR_INFO As String = "{0}错误，请重新输入"

    'Map info
    Public Const MSG_EORROE_MAP_CSSD As String = "CSSD{0}错误，请重新输入"
    Public Const MSG_EORROE_MAP_CSSD_EMPTY As String = "请输入CSSD{0}"
    Public Const MSG_EORROE_MAP_CSSD_EXIST As String = "CSSD编号{0}的映射信息已存在：HIS编号{1}，请重新输入"

    Public Const MSG_EORROE_MAP_HIS As String = "HIS{0}错误，请重新输入"
    Public Const MSG_EORROE_MAP_HIS_EMPTY As String = "请输入HIS{0}"
    Public Const MSG_EORROE_MAP_HIS_EXIST As String = "HIS编号{0}的映射信息已存在：CSSD编号{1}，请重新输入"

    Public Const MSG_EORROR_DISPATCH_HIS_FAILE As String = "HIS系统物品发放失败！"

    'UseDetail
    Public Const MSG_ERROR_USESTART_LITTLE_USEEND As String = "手术开始时间大于术后确认时间,请重新输入。"
    Public Const MSG_ERROR_USE_INFO_NOT_EXIST As String = "手术使用信息不存在"
    Public Const MSG_ERROR_USE_DATE_ERROR As String = "使用时间大于确认时间，请重新输入"

    'WEB
    Public Const MSG_ERROR_NOTE_INVALID As String = "单据信息无效"
    Public Const MSG_ERROR_NOTE_NOT_EXIST_RECEIVE_INS As String = "单据中没有需要接收的物品"
    Public Const MSG_ERROR_STAFF_ERROR_NOT_EXIST As String = "灭菌人员信息无效"
    Public Const MSG_ERROR_STAFF_ERROR_EMPTY_IN As String = "灭菌人员为空，请重新输入"

    Public Const MSG_ERROR_LABEL_PREFIX_EMPTY As String = "标签前缀为空，是否继续？"
    Public Const MSG_ERROR_LABEL_STAR_EMPTY As String = "标签起始编号不能为空"
    Public Const MSG_ERROR_LABEL_END_EMPTY As String = "标签结束编号不能为空"
    Public Const MSG_ERROR_LABEL_STAR_TNEN_END As String = "标签起始编号不能大于结束编号"
    Public Const MSG_ERROR_LABEL_NOT_LEGTH As String = "标签起始编号和结束编号位数不一样"

    'Ward
    Public Const MSG_ERROR_WARD_ID_EMPTY As String = "请输入病区编号。"
    Public Const MSG_ERROR_WARD_NAME_EMPTY As String = "请输入病区名称。"
    Public Const MSG_ERROR_WARD_DP_EMPTY As String = "请选择所属科室。"
    Public Const MSG_ERROR_WARD_ID_EXIST As String = "{0}编号病区已存在。"
    Public Const MSG_ERROR_WARD_NAME_EXIST As String = "当前的病区名称已存在，请重新输入。"
    Public Const MSG_ERROR_WARD_EXIST_OVERFLOW As String = "{0}号病区有多项纪录。"

    'OperationManage
    Public Const MSG_ERROR_DRUG_DICT_EMPTY As String = "没有加载有效的药品信息，请联系管理员。"
    Public Const MSG_ERROR_INS_DICT_EMPTY As String = "没有加载有效的物品信息，请联系管理员。"
    Public Const MSG_ERROR_DRUG_DICT_FIND_NULL As String = "指定的药品信息未找到，请重新输入。"
    Public Const MSG_ERROR_INS_DICT_FIND_NULL As String = "指定的物品信息未找到，请重新输入。"
    Public Const MSG_ERROR_INPUT_AMOUNT As String = "请输入数量。"

    'DrugManage
    Public Const MSG_ERROR_DGV_SEL_ONE As String = "请选择一条记录。"

    'General
    Public Const CONST_TEXT_SELECT_ONE_RECORD_ATLEAST = "请至少选择一条记录。"
    Public Const MSG_USE_SUCESS As String = "使用登记成功。"
    Public Const MSG_DRUG_IN_SUCCESS As String = "药品入库成功。"
    Public Const MSG_DRUG_OUT_SUCCESS As String = "药品出库成功。"
    Public Const MSG_DRUG_ERROR_GET_STOCK_AMOUNT As String = "获取库存数量错误，请联系管理员。"
    Public Const MSG_DRUG_ERROR_STOCK_AMOUNT_NOT_INNOUGH As String = "库存不足，当前数量为：{0}。"
    Public Const MSG_OPERATOR_USE_FRONT_NO_PACKAGE_INFO As String = "{0}号治疗包不在手术室无菌区"
    Public Const MSG_OPERATOR_USE_FRONT_OVER_PACKAGE_INFO As String = "手术室无菌区库存差额异动，请联系管理员"
    Public Const MSG_USE_FRONT_SUCESS As String = "术前拆包登记成功。"

    Public Const MSG_OPERATOR_USE_PACKAGE_IN_USE As String = "{0}治疗包状态为{1},不允许使用"
    Public Const MSG_OPERATOR_USE_PACKAGE_CANNOT_USE As String = "{0}治疗包已过期,不允许使用"
    Public Const MSG_RETURN_SUCESS As String = "回收登记成功。"

    Public Const MSG_DEL_QUESTION As String = "确定删除吗?"

    'Durg
    Public Const MSG_DURG_IN_STOCK As String = "药品信息无效，请重新输入。"
    Public Const MSG_USE_FRONT_REASON As String = "请选择原因"
    Public Const MSG_USE_PACKAGE_SCAN_ALREADY As String = "{0}号治疗包已扫描"
    Public Const MSG_RETURN_PACKAGE_NOT_USE As String = "{0}号治疗包不在使用列表中"
    Public Const MSG_NOTE_QUERY_REQUEST_ALL As String = "请选择需要申请的手术通知单"

    'LBS
    Public Const MSG_LBS_LOAD_LAYOUT_FIAL As String = "加载平面图失败，请联系管理员。"
    Public Const MSG_LBS_LOAD_ENTITY_FIAL As String = "加载ID卡信息失败，请联系管理员。"
    Public Const MSG_LBS_LOAD_CARD_LOCATION_TIME_RANGE_FIAL As String = "找不到{0}至{1}期间编号:{2}的位置信息，请联系管理员。"
    Public Const MSG_LBS_FIND_LOCATION_FIAL As String = "找不到位置信息:{0}。"

    'Maintain
    Public Const MSG_INS_TYPE_EMPTY As String = "物品类型不能为空。"
    Public Const MSG_INS_NAME_EMPTY As String = "物品名称不能为空。"
    Public Const MSG_INS_CODE_EMPTY As String = "物品编码不能为空。"
    Public Const MSG_INS_CODE_EXIST As String = "物品编码已经存在。"
    Public Const MSG_INS_INPUTCODE_EMPTY As String = "物品拼音码不能为空。"
    Public Const MSG_INS_AMOUNT_EMPTY As String = "物品数量不能为空。"
    Public Const MSG_INS_EXIST As String = "物品已经存在。"

    Public Const MSG_DRUG_NAME_EMPTY As String = "药品名称不能为空。"
    Public Const MSG_DRUG_COMMON_NAME_EMPTY As String = "药品商品名不能为空。"
    Public Const MSG_DRUG_CODE_EMPTY As String = "药品编码不能为空。"
    Public Const MSG_DRUG_CODE_EXIST As String = "药品编码已经存在。"
    Public Const MSG_DRUG_INPUTCODE_EMPTY As String = "药品拼音码不能为空。"
    Public Const MSG_DRUG_COMMON_INPUTCODE_EMPTY As String = "商品名拼音码不能为空。"
    Public Const MSG_DRUG_AMOUNT_EMPTY As String = "药品数量不能为空。"
    Public Const MSG_DRUG_EXIST As String = "药品已经存在。"

    Public Const MSG_DRUG_MANUFACTURES_NAME_EMPTY As String = "药品生厂厂家不能为空。"
    Public Const MSG_DRUG_MANUFACTURES_INPUTCODE_EMPTY As String = "药品生厂厂家编码不能为空。"
    Public Const MSG_DRUG_MANUFACTURES_NAME_EXIST As String = "药品生厂厂家已经存在。"

    Public Const MSG_STERILE_AREA_NAME_EMPTY As String = "无菌室名称不能为空。"
    Public Const MSG_STERILE_AREA_TYPE_EMPTY As String = "无菌室类型不能为空。"
    Public Const MSG_STERILE_AREA_DEPT_EMPTY As String = "无菌室所属科室不能为空。"
    Public Const MSG_STERILE_AREA_ROOM_EMPTY As String = "无菌室所属手术间不能为空。"
    Public Const MSG_STERILE_AREA_EXIST As String = "无菌室的信息已经存在。"

    Public Const MSG_IDCARD_TYPE_EMPTY As String = "ID卡类型不能为空。"
    Public Const MSG_IDCARD_NAME_EMPTY As String = "ID卡名称不能为空。"
    Public Const MSG_IDCARD_CODE_EMPTY As String = "ID卡编码不能为空。"
    Public Const MSG_IDCARD_NO_EMPTY As String = "ID卡号不能为空。"
    Public Const MSG_IDCARD_CODE_EXIST As String = "ID卡编码已经存在。"
    Public Const MSG_IDCARD_NO_EXIST As String = "ID卡号已经存在。"
End Module
