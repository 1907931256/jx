Public Module LogConstDef
    'Information
    Public Const LOG_INFORMATION_STARTUP As String = "��������"
    Public Const LOG_INFORMATION_MAINFORM_SHOW As String = "V-TRACK����"
    Public Const LOG_INFORMATION_MAINFORM_INNER_SWITCH As String = "V-TRACK�л�ҳ����{0}"
    Public Const LOG_INFORMATION_MAINFORM_INNER_SWITCH_TO_MAIN As String = "V-TRACK�л�ҳ����������"
    Public Const LOG_INFORMATION_MAINFORM_INNER_CREATE As String = "V-TRACK����ҳ��{0}"
    Public Const LOG_INFORMATION_MAINFORM_DISPOSE As String = "V-TRACK�ͷ�"
    Public Const LOG_INFORMATION_CLOSE As String = "�����˳�"
    Public Const LOG_INFORMATION_LOGOUT As String = "ע��"
    Public Const LOG_INFORMATION_LOCK As String = "����"
    Public Const LOG_INFORMATION_START_EXTERNAL_PROCESS_SUCESS As String = "V-TRACK�ɹ������ⲿ����������ַΪ{0}����������Ϊ{1}"
    Public Const LOG_INFORMATION_START_EXTERNAL_PROCESS_ERROR As String = "V-TRACK�����ⲿ����ʧ�ܣ�������ַΪ{0}����������Ϊ{1}��ԭ��{0}"
    Public Const LOG_INFORMATION_START_EXTERNAL_PROCESS_ERROR_NOT_EXIST As String = "V-TRACK�����ⲿ����ʧ�ܣ�������ַΪ{0}��Ӧ�ó��򲻴���"

    Public Const LOG_INFORMATION_TIMER_TASK_SETTING As String = "��ʱ�����óɹ����������ƣ�{0}"
    Public Const LOG_INFORMATION_TIMER_START As String = "��ʱ������"

    'Update
    Public Const LOG_INFORMATION_AUTOUPDATE_SUC As String = "�ɹ��ӷ����������ص��°汾{0}��"
    Public Const LOG_INFORMATION_AUTOUPDATE_ERROR As String = "�汾����ʧ�ܡ���ǰ�汾��{0}��Ŀ��汾{1}��"
    Public Const LOG_UPDATE_EXCEPTION As String = "�Զ����¹����г����쳣��{0}"
    Public Const LOG_DETECT_AUTO_UPDATE_CLOSE As String = "ϵͳ��⵽����Ϊ�����ļ������Զ�����δ���С�"

    'Main Form
    Public Const LOG_MAINFORM_DISPOSE_FAILURE As String = "V-TRACK�ͷ��쳣�������쳣��"

    'XML
    Public Const LOG_ELEMENT_READ_FAILURE As String = "��ȡ�ڵ���󣬽ڵ㣺{0} "
    Public Const LOG_ELEMENT_READ_FAILURE_SUB As String = "��ȡ�ڵ���󣬽ڵ�·����{0}���ӽڵ㣺{1} "
    Public Const LOG_ELEMENT_VALUE As String = "��ȡ�ڵ����ݴ��󣬽ڵ�·����{0}��ֵ��{1} "
    Public Const LOG_ELEMENT_VALUE_SUB As String = "��ȡ�ڵ����ݴ��󣬽ڵ�·����{0}���ӽڵ㣺{1}��ֵ��{2} "

    'License
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_LOAD_FAILURE As String = "�����ļ��������"
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_ROLE_NOT_UPDATE As String = "{0}�������"
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_ROLE_UPDATE_SUCCESS As String = "{0}���³ɹ������º�ֵ��{1}"
    Public Const LOG_LOAD_LICENSE_LICENSEFILE_DB_EXCEPTION As String = "���²���ʱ�����ݿ��쳣"

    'Structure Config
    Public Const LOG_STRUCTURE_LOAD_FAILURE As String = "�����ݿ�������������ó���"
    Public Const LOG_STRUCTURE_READ_FAILURE As String = "���������ö�ȡ����"

    'Config
    Public Const LOG_CONFIGFILE_LOAD_FAILURE As String = "�����ļ��������"
    Public Const LOG_CONFIGFILE_READ_FAILURE As String = "�����ļ���ȡ����"
    Public Const LOG_CONFIGFILE_LABEL_PRINTER_FAILURE As String = "V-TRACK��ǩ��ӡ����ʼ��ʧ�ܣ������쳣��"
    Public Const LOG_CONFIGFILE_MEDITS_PRINTER_FAILURE As String = "V-TRACKĬ�ϴ�ӡ����ʼ��ʧ�ܣ������쳣��"
    Public Const LOG_CONFIGFILE_RESET_MEDITS_PRINTER_FAILURE As String = "���Խ�ϵͳĬ�ϴ�ӡ����ΪV-TRACKĬ�ϴ�ӡ��ʧ��"
    Public Const LOG_CONFIGFILE_RESET_MEDITS_PRINTER_SUCCESS As String = "��ϵͳĬ�ϴ�ӡ����ΪV-TRACKĬ�ϴ�ӡ����д�������ļ��ɹ�"
    Public Const LOG_CONFIGFILE_CURDEPARTMENT_FAILURE As String = "��õ�ǰ������Ϣ�쳣�������ļ�ֵ��"
    Public Const LOG_CONFIGFILE_CUROPROOM_FAILURE As String = "��õ�ǰ����������Ϣ�쳣�������ļ�ֵ��"
    Public Const LOG_CONFIGFILE_CREATE_ERROR As String = "�����ļ�����ʧ��"

    'Load
    Public Const LOG_LOAD_LOCALDATA_FAILURE As String = "��ʼ��{0}ʧ��"

    'Login
    Public Const LOG_LOGIN_USERID_ERROR As String = "�û�ID��{0}����¼�쳣"
    Public Const LOG_LOGIN_PASSWORD_ERROR As String = "������������û�ID��{0},�������룺{1}"
    Public Const LOG_LOGIN_USERID_SUCCESS As String = "�û�ID��{0}����¼�ɹ�"
    Public Const LOG_LOGIN_USERROLE_ERROR As String = "{0}ID��{1}����¼{2},��ɫ��ƥ��"
    Public Const LOG_LOGIN_USERROLE As String = "{0}�û���Ȩ�رոý���"
    'INS
    Public Const LOG_INS_ERROR_EXIST_OVERFLOW As String = "��ѯ���Ϊ{0}��Ʒʱ,��¼��Ψһ"
    Public Const LOG_INS_COST_ERROR_EXIST_OVERFLOW As String = "��ѯ���Ϊ{0}��Ʒ�ɱ���Ϣʱ,��¼��Ψһ"
    Public Const LOG_SYS_OPERATION_COST_ERROR_EXIST_OVERFLOW As String = "��ѯ���Ϊ{0}��ҵ�ɱ���Ϣʱ,��¼��Ψһ"
    Public Const LOG_SYS_OPERATION_COST_ERROR_NOT_EXIST As String = "��ѯ���Ϊ{0}��ҵ�ɱ���Ϣʱ,��¼������"
    Public Const LOG_SYS_OPERATION_DETAIL_COST_ERROR_EXIST_OVERFLOW As String = "��ѯ���Ϊ{0}��ҵ��ϸ�ɱ���Ϣʱ,��¼��Ψһ"
    Public Const LOG_SYS_OPERATION_DETAIL_COST_ERROR_NOT_EXIST As String = "��ѯ���Ϊ{0}��ҵ��ϸ�ɱ���Ϣʱ,��¼������"
    Public Const LOG_SYS_COST_FACTOR_ERROR_EXIST_OVERFLOW As String = "��ѯ���Ϊ{0}�ɱ�������Ϣʱ,��¼��Ψһ"
    Public Const LOG_SYS_COST_FACTOR_ERROR_NOT_EXIST As String = "��ѯ���Ϊ{0}�ɱ�������Ϣʱ,��¼������"
    Public Const LOG_SYS_COST_FACTOR_BY_TYPE_ERROR_EXIST_OVERFLOW As String = "��ѯ����Ϊ{0}�ĳɱ�������Ϣʱ,��¼��Ψһ"
    Public Const LOG_SYS_COST_FACTOR_BY_TYPE_ERROR_NOT_EXIST As String = "��ѯ����Ϊ{0}�ĳɱ�������Ϣʱ,��¼������"
    'Public Const LOG_INS_ERROR_NOT_EXIST As String = "��ѯ���Ϊ{0}��Ʒʱ,��¼�����ڻ��ѱ�ɾ��"

    'Sterilize Info
    Public Const LOG_STERILIZE_INFO_ERROR_EXIST_OVERFLOW As String = "��ѯ���Ϊ{0}�����Ϣʱ,��¼��Ψһ"
    Public Const LOG_STERILIZE_INFO_ERROR_NOT_EXIST As String = "��ѯ���Ϊ{0}�����Ϣʱ,��¼������"
    Public Const LOG_STERILIZE_INFO_ERROR_AVAILABELDATE_INVALID As String = "�����Ϣ�޷������Чʱ�䣺Method-{0},Unit-{1},Value{2},�����쳣��"

    Public Const LOG_STERILIZE_BATCH_ERROR_EXIST_OVERFLOW As String = "��ѯ�������Ϊ{0}��ʱ�䷶Χ��{1}��{2}֮��������Ϣʱ,��¼��Ψһ"
    Public Const LOG_STERILIZE_BATCH_ERROR_NOT_EXIST As String = "��ѯ�������Ϊ{0}��ʱ�䷶Χ��{1}��{2}֮��������Ϣʱ,��¼������"

    Public Const LOG_WASH_DISINFECT_ERROR_EXIST_OVERFLOW As String = "��ѯ�������Ϊ{0}��ʱ�䷶Χ��{1}��{2}֮�����ϴ��Ϣʱ,��¼��Ψһ"
    Public Const LOG_WASH_DISINFECT_ERROR_NOT_EXIST As String = "��ѯ�������Ϊ{0}��ʱ�䷶Χ��{1}��{2}֮�����ϴ��Ϣʱ,��¼������"

    'Validity Period Info
    Public Const LOG_VALIDITY_PERIOD_INFO_ERROR_EXIST_OVERFLOW As String = "��ѯ���Ϊ{0}��Ч����Ϣʱ,��¼��Ψһ"
    Public Const LOG_VALIDITY_PERIOD_INFO_ERROR_NOT_EXIST As String = "��ѯ���Ϊ{0}��Ч����Ϣʱ,��¼������"
    Public Const LOG_VALIDITY_PERIOD_INFO_ERROR_AVAILABELDATE_INVALID As String = "��Ч����Ϣ�޷������Чʱ�䣺Index-{0},Unit-{1},Value{2},�����쳣��"

    'Performance Factor Info
    Public Const LOG_PERFORMANCE_FACTOR_INFO_ERROR_EXIST_OVERFLOW As String = "��ѯKeyΪ{0}��Ч������Ϣʱ,��¼��Ψһ"
    Public Const LOG_PERFORMANCE_FACTOR_INFO_ERROR_NOT_EXIST As String = "��ѯKeyΪ{0}��Ч������Ϣʱ,��¼������"

    'Performance Evaluation
    Public Const LOG_PERFORMANCE_EVALUATION_STAFF_NOT_EXIST As String = "��Ч����ͳ��ʱ���û����Ϊ{0}���û�,�޷�����û�����"
    Public Const LOG_PERFORMANCE_EVALUATION_SUB_PROCEDURE_INS_KIND_NOT_EXIST As String = "��Ч����ͳ��ʱ����ѯKeyΪ{0}��Ч���Ӷ�Ӧ��Ʒ���ͼ���,��¼������"
    Public Const LOG_PERFORMANCE_EVALUATION_SUB_PROCEDURE_DB_EXCEPTIONT As String = "��Ч����ͳ��ʱ��ͳ��{0}ʱ,���ݿ��쳣"

    'Package Scan
    Public Const LOG_PACKAGE_SCAN_PACKAGE_NOT_EXIST As String = "{0}ʱ��ѯ����ֵΪ{1}���ư�,��¼������"

    'Dispatch
    Public Const LOG_DISPATCH_NOTE_NOT_EXIST As String = "����ʱ��ѯ����ֵΪ{0}���뵥��,��¼������"
    Public Const LOG_DISPATCH_NOTE_STATE_ERROR As String = "����ʱ��ѯ����ֵΪ{0}���뵥��,״̬Ϊ{1}��������ִ����һ������"
    Public Const LOG_DISPATCH_PACKAGE_NOT_EXIST As String = "����ʱ��ѯ����ֵΪ{0}���ư�,��¼������"
    Public Const LOG_DISPATCH_PACKAGE_STATE_ERROR As String = "����ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}����������"
    Public Const LOG_DISPATCH_PACKAGE_STERILIZER_ERROR As String = "����ʱ��ѯ����ֵΪ{0}���ư�,�޷������޾�����Ϣ����������"

    'Receive
    Public Const LOG_RECEIVE_NOTE_STATE_ERROR As String = "����ʱ��ѯ����ֵΪ{0}���뵥��,״̬Ϊ{1}��������ִ����һ������"
    Public Const LOG_RECEIVE_PACKAGE_STATE_ERROR As String = "����ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}�����������"
    Public Const LOG_RECEIVE_NOTE_NOT_EXIST As String = "����ʱ��ѯ����ֵΪ{0}���뵥��,��¼������"
    Public Const LOG_RECEIVE_DISPATCH_NOTE_NOT_EXIST As String = "����ʱ��ѯ����ֵΪ{0}���ŵ���,��¼������"

    'Borrow Back
    Public Const LOG_BORROW_BACK_DISPATCH_NOTE_NOT_EXIST As String = "�黹ʱ��ѯ����ֵΪ{0}���ŵ���,��¼������"
    Public Const LOG_BORROW_BACK_RECEIVE_NOTE_NOT_EXIST As String = "�黹ʱ��ѯ����ֵΪ{0}���յ���,��¼������"
    Public Const LOG_BORROW_BACK_PACKAGE_STATE_ERROR As String = "�黹ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}��������黹"
    Public Const LOG_BORROW_BACK_NOTE_STATE_ERROR As String = "�黹ʱ��ѯ����ֵΪ{0}���뵥��,״̬Ϊ{1}��������ִ����һ������"

    'Return Back
    Public Const LOG_RETURN_BACK_PACKAGE_STATE_ERROR As String = "�˻�ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}���������˻�"
    Public Const LOG_RETURN_BACK_PACKAGE_DISPATCH_ERROR As String = "�˻�ʱ��ѯ����ֵΪ{0}���ư�,û�з�����Ϣ���������˻�"
    Public Const LOG_RETURN_BACK_PACKAGE_DISPATCH_NOTE_ERROR As String = "�˻�ʱ��ѯ����ֵΪ{0}���ư�,���ŵ�����Ϊ{1}���������˻�"

    'INS Use
    Public Const LOG_INS_USE_PACKAGE_STATE_ERROR As String = "ʹ��ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}��������ʹ��"
    Public Const LOG_INS_USE_PACKAGE_EXIST_IN_STOCK As String = "ʹ��ʱ��ѯ����ֵΪ{0}���ư�,�����޾��������У�������ɨ��"
    'RU TRACE
    Public Const LOG_RU_TRACE_PACKAGE_STATE_ERROR As String = "��һ������Ʒ����ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}���޷���ȡ��Ʒʹ����Ϣ"

    'OP_STOCK
    Public Const LOG_OP_STOCK_PACKAGE_STATE_ERROR As String = "������е��ѯ���ʱ��ѯ����Ϊ{0}���ư�,״̬Ϊ{1}��������ɨ��"
    Public Const LOG_OP_STOCK_NOT_EXIST_IN_STOCK As String = "������е��ѯ���ʱ��ѯ����Ϊ{0}���ư�,�����޾��������У�������ɨ��"
    Public Const LOG_OP_STOCK_PACKAGE_NOT_BACK_STERILEROOM As String = "������е��ѯ���ʱ��ѯ����Ϊ{0}���ư�,�����޾������ֶ�Ϊ{1},�޶�Ӧ�����޾����ֶΣ���������"
    Public Const LOG_OP_STOCK_PACKAGE_OVRRIED As String = "������е��ѯʱ��ѯ����Ϊ{0}���ư�,��¼��Ωһ"
    Public Const LOG_OP_STOCK_NO_ROOM As String = "��ѯ�������������޾�����"

    'Back
    Public Const LOG_CSSD_STOCK_NOT_EXIST_IN_STOCK As String = "Ժ����Ʒ����ʱ����ѯ���ư�{0}����Ժ���޾����У�������ɨ��"
    'Return
    Public Const LOG_RETURN_PACKAGE_STATE_ERROR As String = "����ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}�����������"
    Public Const LOG_RETURN_PACKAGE_STATE_NOTUSE As String = "����ʱ��ѯ����ֵΪ{0}���ư�,δ��ʹ��"

    'Terminaler
    Public Const LOG_TERMINALER_ERROR_NOT_EXIST As String = "V-TRACK�ֳ��ն˲����ڻ�δ���ã������쳣��"
    Public Const LOG_TERMINALER_ERROR_CANNOT_GET_STATE As String = "V-TRACK�ֳ��ն��޷�������ӣ������쳣��"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_UPLOAD_FAILURE As String = "V-TRACK�ֳ��ն��ļ��ϴ�ʧ�ܣ������쳣��"
    Public Const LOG_TERMINALER_INFORMATION_STATE_CHANGE As String = "V-TRACK�ֳ��ն�״̬���£�{0}"
    Public Const LOG_TERMINALER_INFORMATION_LOAD_SUCCESS As String = "V-TRACK�ֳ��ն������������ɹ�����ǰ���棺{0}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_NOT_EXIST As String = "V-TRACK�ֳ��ն������ļ������ڣ�����·����{0}"
    Public Const LOG_TERMINALER_ERROR_CREATE_TEMPDIR_FAILURE As String = "V-TRACK�ֳ��ն˴�����ʱ·��ʧ�ܣ�����·����{0},�����쳣��{1}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_PARSE_FAILURE As String = "V-TRACK�ֳ��ն������ļ�����ʧ�ܣ�����·����{0},�����쳣��{1}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_SAVE_FAILURE As String = "V-TRACK�ֳ��ն������ļ�����ʧ�ܣ�����·����{0},�����쳣��{1}"
    Public Const LOG_TERMINALER_ERROR_DATAFILE_PARSE_FORMAT_ERROR As String = "V-TRACK�ֳ��ն������ļ�����ʱ�����ݸ�ʽ��������·����{0},�кţ�{1}"
    Public Const LOG_TERMINALER_ERROR_TIMEOUT As String = "V-TRACK�ֳ��ն˼�����ʱ����ʱ���ã�"
    Public Const LOG_TERMINALER_INTIAL_FAILURE_RESET As String = "V-TRACK�ֳ��ն˳�ʼ��ʧ�ܣ��ѹر�"
    Public Const LOG_TERMINALER_TEMPFILE_NOTEXIST As String = "V-TRACK�ֳ��ն���ʱ�ļ������ڣ���ʱ�ļ���"
    Public Const LOG_TERMINALER_TEMPFILE_COPY_FAILURE As String = "V-TRACK�ֳ��ն˿�����ʱ�ļ�ʧ�ܣ�Դ�ļ���{0},Ŀ���ļ���{1}�������쳣��{2}"
    'Printer
    Public Const LOG_PERINTER_ERROR_SYSTEM_DEFAULT_NOT_EXIST As String = "����ϵͳĬ�ϴ�ӡ�������ڻ�δ���ã������쳣��"
    Public Const LOG_PERINTER_ERROR_MEDITS_DEFAULT_NOT_EXIST As String = "V-TRACKĬ�ϴ�ӡ�������ڻ�δ���ã������쳣��"
    Public Const LOG_PERINTER_ERROR_MEDITS_LABEL_NOT_EXIST As String = "V-TRACK��ǩ��ӡ�������ڻ�δ���ã������쳣��"

    'Print
    Public Const LOG_PERINT_ERROR As String = "��ӡִ��δ��ɣ������쳣��"
    Public Const LOG_PERINT_ERROR_FORMAT_FILE_LOAD_FAILURE As String = "��ӡ��ʽ�ļ���{0}��������������쳣��{1}"
    Public Const LOG_PERINT_NOT_READY As String = "��ӡ��ʽ�ļ�δ׼���á�"
    Public Const LOG_PERINT_ERROR_FORMAT_FILE_LOAD_EXCEPTION As String = "��ӡ��ʽ�ļ�������������쳣��"
    Public Const LOG_PERINT_ERROR_INTERRUPT_OR_EXCEPTION As String = "��ӡ���̱��жϻ�ʧ�ܣ������쳣��"

    'Monitor BorrowBack
    Public Const LOG_MONITOR_BORROW_BACK_ERROR_EXCEPTION As String = "�赥�黹�����쳣�������쳣��"
    Public Const LOG_MONITOR_BORROW_BACK_ERROR_DB_EXCEPTION As String = "�赥�黹�������ݿ��쳣"
    Public Const LOG_MONITOR_BORROW_BACK_ERROR_TIMEOUT As String = "�赥�黹������ʱ����ʱ���ã�"

    'BorrowBack Notice
    Public Const LOG_MONITOR_BORROW_BACK_NOTICE_ERROR_EXCEPTION As String = "�赥�黹֪ͨ�����쳣�������쳣��"
    Public Const LOG_MONITOR_BORROW_BACK_NOTICE_ERROR_DB_EXCEPTION As String = "�赥�黹֪ͨ�������ݿ��쳣"
    Public Const LOG_MONITOR_BORROW_BACK_NOTICE_ERROR_TIMEOUT As String = "�赥�黹֪ͨ������ʱ����ʱ���ã�"

    'Recall
    Public Const LOG_MONITOR_BORROW_RECALL_ERROR_EXCEPTION As String = "�ٻؼ����쳣�������쳣��"
    Public Const LOG_MONITOR_BORROW_RECALL_ERROR_TIMEOUT As String = "�ٻؼ�����ʱ����ʱ���ã�"
    Public Const LOG_MONITOR_BORROW_RECALL_ERROR_DB_EXCEPTION As String = "�ٻؼ������ݿ��쳣"

    'Expired BorrowBack
    Public Const LOG_MONITOR_EXPIRED_ERROR_EXCEPTION As String = "��Ӧ�ҹ�����Ʒ���Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_EXPIRED_ERROR_DB_EXCEPTION As String = "��Ӧ�ҹ�����Ʒ���Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_EXPIRED_ERROR_TIMEOUT As String = "��Ӧ�ҹ�����Ʒ���Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_WHEXPIRED_ERROR_EXCEPTION As String = "�ⷿ������Ʒ���Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_WHEXPIRED_ERROR_DB_EXCEPTION As String = "�ⷿ������Ʒ���Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_WHEXPIRED_ERROR_TIMEOUT As String = "�ⷿ������Ʒ���Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_WHBALANCE_ERROR_EXCEPTION As String = "�ⷿ������������Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_WHBALANCE_ERROR_DB_EXCEPTION As String = "�ⷿ������������Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_WHBALANCE_ERROR_TIMEOUT As String = "�ⷿ������������Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_EIEXPIRED_ERROR_EXCEPTION As String = "�ĲĹ�����Ʒ���Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_EIEXPIRED_ERROR_DB_EXCEPTION As String = "�ĲĹ�����Ʒ���Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_EIEXPIRED_ERROR_TIMEOUT As String = "�ĲĹ�����Ʒ���Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_EIBALANCE_ERROR_EXCEPTION As String = "�ĲĿ�����������Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_EIBALANCE_ERROR_DB_EXCEPTION As String = "�ĲĿ�����������Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_EIBALANCE_ERROR_TIMEOUT As String = "�ĲĿ�����������Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_OPEXPIRED_ERROR_TIMEOUT As String = "�����ҹ�����Ʒ���Ѽ�����ʱ����ʱ���ã�"
    Public Const LOG_MONITOR_OPEXPIRED_ERROR_EXCEPTION As String = "�����ҹ�����Ʒ���Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_OPEXPIRED_ERROR_DB_EXCEPTION As String = "�����ҹ�����Ʒ���Ѽ������ݿ��쳣"

    Public Const LOG_MONITOR_SERVICE_PLAN_ERROR_EXCEPTION As String = "ά���ƻ����Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_SERVICE_PLAN_ERROR_DB_EXCEPTION As String = "ά���ƻ����Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_SERVICE_PLANS_ERROR_TIMEOUT As String = "ά���ƻ����Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_RU_BALANCE_ERROR_EXCEPTION As String = "��һ������Ʒ�������Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_RU_BALANCE_ERROR_DB_EXCEPTION As String = "��һ������Ʒ�������Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_RU_BALANCE_ERROR_TIMEOUT As String = "��һ������Ʒ�������Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_SU_BALANCE_ERROR_EXCEPTION As String = "һ������Ʒ�������Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_SU_BALANCE_ERROR_DB_EXCEPTION As String = "һ������Ʒ�������Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_SU_BALANCE_ERROR_TIMEOUT As String = "һ������Ʒ�������Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_UVLAMP_BALANCE_ERROR_EXCEPTION As String = "�����ߵƹܵ������Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_UVLAMP_BALANCE_ERROR_DB_EXCEPTION As String = "�����ߵƹܵ������Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_UVLAMP_BALANCE_ERROR_TIMEOUT As String = "�����ߵƹܵ������Ѽ�����ʱ����ʱ���ã�"

    Public Const LOG_MONITOR_OPREQEST_ERROR_EXCEPTION As String = "������е�����������Ѽ����쳣�������쳣��"
    Public Const LOG_MONITOR_OPREQEST_BALANCE_ERROR_DB_EXCEPTION As String = "������е�����������Ѽ������ݿ��쳣"
    Public Const LOG_MONITOR_OPREQEST_BALANCE_ERROR_TIMEOUT As String = "������е�����������Ѽ�����ʱ����ʱ���ã�"
    'Timer Task 
    Public Const LOG_TIMER_TASK_SETTING_FAILURE As String = "��ʱ������ʧ�ܣ��������ƣ�{0}"

    'Work Volume Statistic
    Public Const LOG_VOLUME_STATISTIC_MAIN_TYPE_ERROR As String = "������ͳ���쳣������ֵΪ{0}��ͳ����,���������Value-{1}"
    Public Const LOG_VOLUME_STATISTIC_DETAIL_ITEM_ERROR As String = "������ͳ���쳣������ֵΪ{0}��ͳ����,��ϸ�����"
    Public Const LOG_VOLUME_STATISTIC_DETAIL_ITEM_NOT_CORRECT As String = "������ͳ���쳣������ֵΪ{0}��ͳ����,��ϸ���쳣���߲����ڣ�Value-{1}"
    Public Const LOG_VOLUME_STATISTIC_DB_EXCEPTION As String = "������ͳ���쳣��ͳ������ֵΪ{0}��ͳ����ʱ,���ݿ��쳣"
    Public Const LOG_VOLUME_STATISTIC_GET_TOTAL_ITEM As String = "������ͳ��ʧ�ܣ����ܳɹ���ȡ�Ѵ��ڵ�ͳ�����"

    'Serial Number
    Public Const LOG_SERIAL_NUMBER_IN_THE_TERM As String = "���к�ʹ�������ڣ�������������"
    Public Const LOG_SERIAL_NUMBER_ACTIVATION As String = "���к��Ѿ����������������"
    Public Const LOG_SERIAL_NUMBER_ACTIVATION_SUCCESS As String = "���кż���ɹ�"
    Public Const LOG_SERIAL_NUMBER_GET_SERVERTIME_FAILURE As String = "��֤���к�ʱ����ȡ������ʱ��ʧ��"
    Public Const LOG_SERIAL_NUMBER_GET_SERIALTERM_FAILURE As String = "��֤���к�ʱ����ȡʹ������ʧ��"
    Public Const LOG_SERIAL_NUMBER_GET_SERIALNUM_FAILURE As String = "��֤���к�ʱ����ȡ���к�ʧ��"
    Public Const LOG_SERIAL_NUMBER_EXPECT_SERIALNUM_EMPTY As String = "��֤���к�ʱ��Ԥ�����к�Ϊ��"
    Public Const LOG_SERIAL_NUMBER_NON_ACTIVATION As String = "��֤���к�ʱ����ʵ���к�Ϊ�գ�δ����"
    Public Const LOG_SERIAL_NUMBER_CANNOT_MATCH As String = "��֤���к�ʱ��Ԥ�����к�����ʵ���кŲ�ƥ��"

    'Hardware
    Public Const LOG_HARDWARE_GET_NETINFO_FAILURE As String = "��ȡ������������Ϣʧ�ܣ������쳣��"
    Public Const LOG_HARDWARE_NETINFO_NOT_EXIST As String = "�޷���Ӳ����Ϣ���л�ñ���IP��Ϣ������IP�б�"
    Public Const LOG_HARDWARE_NETINFO_INFO_ERROR As String = "Ӳ����֤ʱ��ѯ����ֵΪ{0}��¼ʱ,���ݴ���"
    Public Const LOG_HARDWARE_NETINFO_INFO_CHANGE As String = "Ӳ����֤ʱ��ѯ����ֵΪ{0}��¼ʱ,Ӳ���ѱ��"
    Public Const LOG_HARDWARE_NETINFO_INFO_ACTIVATION As String = "����ֵΪ{0}�ļ�¼����ɹ�,IP��{1}��������������{2}"
    Public Const LOG_HARDWARE_NETINFO_INFO_VALIDATE_SUCCESS As String = "Ӳ����֤ͨ��,IP��{0}�����Ƶ��ɫ��{1}"

    'Package Reg
    Public Const LOG_PACKREG_RELATIONSHIP_PACKAGE_COUNT_ERROR As String = "����Ǽ�ʱ�����̺�Ϊ{0}�������У���Ʒ���Ϊ{1}����Ʒ��������{2}���ư�����Ʒ����Ϊ{3}"

    'PackageRedo
    Public Const LOG_REDO_PACKAGE_STATE_ERROR As String = "����ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}������������"

    'HistoryStatistics Parse
    Public Const LOG_HISSTAT_CONFIGFILE_LOAD_FAILURE As String = "��ʷͳ�������ļ��������"
    Public Const LOG_HISSTAT_CONFIGFILE_SAVE_FAILURE As String = "��ʷͳ�������ļ��������"
    Public Const LOG_HISSTAT_SAVE_FAIL As String = "����ʧ�ܣ�{0}"
    Public Const LOG_HISSTAT_LOAD_FAIL As String = "����ʧ�ܣ�{0}"
    Public Const LOG_HISSTAT_SAVE_WITH_NO_TIEM As String = "û���κ�ͳ���"

    '��������
    Public Const LOG_DEVARCHIVE_ERROR_CREATE_TEMPDIR_FAILURE As String = "V-TRACK�豸������־������ʱ·��ʧ�ܣ�����·����{0},�����쳣��{1}"
    Public Const LOG_WASH_DISINFECT_ARCHIVE_SQL As String = "������ϴ�Ǽ���Ϣ��{0}��"
    Public Const LOG_WASH_DISINFECT_ARCHIVE_SUCCESS As String = "�鵵��ϴ��־�ɹ���"
    Public Const LOG_WASH_DISINFECT_FIND_DATA_SUCCESS As String = "�ҵ�������������ϴ�Ǽ���Ϣ:�������Ϊ��{0},��ʼʱ��Ϊ��{1},����Ϊ��{2}��"
    Public Const LOG_STERILIZE_BATCH_ARCHIVE_SQL As String = "��������Ǽ���Ϣ��{0}��"
    Public Const LOG_STERILIZE_BATCH_ARCHIVE_SUCCESS As String = "�鵵�����־�ɹ���"
    Public Const LOG_STERILIZE_BATCH_FIND_DATA_SUCCESS As String = "�ҵ���������������Ǽ���Ϣ:�������Ϊ��{0},��ʼʱ��Ϊ��{1},����Ϊ��{2}��"


    Public Const LOG_ARCHIVE_ERROR As String = "û���ҵ�������������ϴ/����ĵǼ���Ϣ�����������Ѿ��������޷����й鵵���������Ϊ:{0}"
    Public Const LOG_ARCHIVE_MACHINE_NONMONOTOR As String = "����{0}���ܼ�أ��߳��˳���"

    Public Const LOG_MACHINE_CONFIG_LOAD_FAILURE As String = "�豸���������ļ��������,�����ļ���"

    'PackPrintInfo
    Public Const LOG_PACKPRINTINFO_LOAD_FAILURE As String = "��ǩ��ӡ�����ļ��������,�����ļ���"
    Public Const LOG_PACKPRINTINFO_ATT_VALUE_TYPE_MISMATCH As String = "��ǩ��ӡ�����ļ�value���Բ�ƥ�䣬�����ļ���"
    Public Const LOG_PACKPRINTINFO_ATT_X_TYPE_MISMATCH As String = "��ǩ��ӡ�����ļ�x���Բ�ƥ�䣬�����ļ���"
    Public Const LOG_PACKPRINTINFO_ATT_Y_TYPE_MISMATCH As String = "��ǩ��ӡ�����ļ�y���Բ�ƥ�䣬�����ļ���"
    Public Const LOG_PACKPRINTINFO_ATT_SIZE_TYPE_MISMATCH As String = "��ǩ��ӡ�����ļ�size���Բ�ƥ�䣬�����ļ���"
    Public Const LOG_PACKPRINTINFO_ATT_REVERSE_TYPE_MISMATCH As String = "��ǩ��ӡ�����ļ�reverse���Բ�ƥ�䣬�����ļ���"
    Public Const LOG_PACKPRINTINFO_TYPE_MISMATCH_ITEM As String = "������Ŀ��"
    Public Const LOG_PACKPRINTINFO_ATT_VISIBLE_TYPE_MISMATCH As String = "��ǩ��ӡ�����ļ�visible���Բ�ƥ�䣬�����ļ���"

    'Recall
    Public Const LOG_RECALL_NOTE_NOT_EXIST As String = "�ٻ�ʱ��ѯ����ֵΪ{0}�ٻص���,��¼������"
    Public Const LOG_RECALL_NOTE_STATE_ERROR As String = "�ٻ�ʱ��ѯ����ֵΪ{0}�ٻص���,״̬Ϊ{1}��������ִ����һ������"
    Public Const LOG_RECALL_PACKAGE_STATE_ERROR As String = "�ٻ�ʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}���������ٻ�"


    'Performance Evaluation
    'Public Const LOG_PERFORMANCE_EVALUATION_STAFF_NOT_EXIST As String = "��Ч����ͳ��ʱ���û����Ϊ{0}���û�,�޷�����û�����"
    'Public Const LOG_PERFORMANCE_EVALUATION_SUB_PROCEDURE_INS_KIND_NOT_EXIST As String = "��Ч����ͳ��ʱ����ѯKeyΪ{0}��Ч���Ӷ�Ӧ��Ʒ���ͼ���,��¼������"
    Public Const LOG_COST_ACCOUNT_DB_EXCEPTIONT As String = "�ɱ�����ͳ��ʱ,���ݿ��쳣"

    'Infection Reg
    Public Const LOG_INFECTION_PACKAGE_STATE_ERROR As String = "�ǼǸ�Ⱦʱ��ѯ����ֵΪ{0}���ư�,״̬Ϊ{1}��������ǼǸ�Ⱦ"

    'INS Image 
    Public Const LOG_COST_PACKING_IMAGE_EXIST_OVERFLOW As String = "���Ϊ{0}����Ʒ�����ڶ�����Ϊ{1}��ͼƬ��"
    Public Const LOG_COST_PACKING_IMAGE_NOT_EXIST As String = "��������Ϊ{0}��ͼƬ��"
    Public Const LOG_COST_PACKING_IMAGE_OPEN_ERROR As String = "��ͼƬ{0}ʧ�ܡ�ԭ������Ǹ�ʽ����"
    Public Const LOG_COST_PACKING_IMAGE_UPLOAD_ERROR As String = "�ϴ��ļ�{0}ʧ�ܡ�"
    Public Const LOG_COST_PACKING_IMAGE_DELETE_ERROR As String = "ɾ��ͼƬ{0}ʧ�ܡ�"
    Public Const LOG_COST_PACKING_IMAGE_DELETE_TEMP_ERROR As String = "ɾ���򴴽���ʱĿ¼ʧ�ܡ�"
    Public Const LOG_COST_PACKING_IMAGE_DOWNLOAD_ERROR As String = "����ͼƬʧ�ܡ�"
    Public Const LOG_COST_PACKING_IMAGE_UPDATELOG_UPDATE_ERROR As String = "UpdateLog.xml����ʧ�ܡ�"
    Public Const LOG_COST_PACKING_IMAGE_FTP_CONNECT_ERROR As String = "δ������FTP������ͼƬʧ�ܣ�����ϵ����Ա��"

    'LocalSet
    Public Const LOG_CONST_DISPATCH_TODAY_TIME_ANALYTICAL_ERROR As String = "���շ���ʱ�������������Ϊ {0}"
End Module

