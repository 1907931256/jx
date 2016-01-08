Public Module PrintConstDef
    'path
    Public Const CONST_TEXT_PATH_PAPER_ITEM = "Print/Paper/Item"
    Public Const CONST_TEXT_PATH_STATICCONTENT_ITEM = "Print/StaticContent/Item"
    Public Const CONST_TEXT_PATH_DYNAMICCONTENT_ITEM = "Print/DynamicContent/Item"
    Public Const CONST_TEXT_PATH_FOOTER_ITEM = "Print/Footer/Item"

    'attribute&node
    Public Const CONST_TEXT_ATTRI_KEY As String = "key"
    Public Const CONST_TEXT_ATTRI_PAPER_SIZE As String = "papersize"
    Public Const CONST_TEXT_ATTRI_SIZE As String = "size"
    Public Const CONST_TEXT_ATTRI_LAYOUT As String = "layout"
    Public Const CONST_TEXT_ATTRI_MARGIN_LFET As String = "left"
    Public Const CONST_TEXT_ATTRI_MARGIN_TOP As String = "top"
    Public Const CONST_TEXT_ATTRI_MARGIN_RIGHT As String = "right"
    Public Const CONST_TEXT_ATTRI_MARGIN_BOTTOM As String = "bottom"
    Public Const CONST_TEXT_ATTRI_NAME As String = "name"
    Public Const CONST_TEXT_ATTRI_COLOR As String = "color"
    Public Const CONST_TEXT_ATTRI_LABEL As String = "label"
    Public Const CONST_TEXT_ATTRI_X As String = "x"
    Public Const CONST_TEXT_ATTRI_X2 As String = "x2"
    Public Const CONST_TEXT_ATTRI_Y As String = "y"
    Public Const CONST_TEXT_ATTRI_Y2 As String = "y2"
    Public Const CONST_TEXT_ATTRI_WIDTH As String = "width"
    Public Const CONST_TEXT_ATTRI_HEIGHT As String = "height"
    Public Const CONST_TEXT_ATTRI_WIDTH2 As String = "width2"
    Public Const CONST_TEXT_ATTRI_HEIGHT2 As String = "height2"
    Public Const CONST_TEXT_ATTRI_HOR_ALIGH As String = "horAlignment"
    Public Const CONST_TEXT_ATTRI_VER_ALIGH As String = "verAlignment"
    Public Const CONST_TEXT_ATTRI_SELECTABLE As String = "Selectable"
    Public Const CONST_TEXT_ATTRI_REPEAT As String = "Repeat"
    Public Const CONST_TEXT_ATTRI_FONT_FAMILY As String = "family"
    Public Const CONST_TEXT_ATTRI_STYLE As String = "style"
    Public Const CONST_TEXT_ATTRI_FORMAT_MASK As String = "FormatMask"
    Public Const CONST_TEXT_ATTRI_STATIC As String = "static"
    Public Const CONST_TEXT_ATTRI_STATIC_VALUE As String = "staticValue"
    Public Const CONST_TEXT_ATTRI_VISIBLE As String = "Visible"
    Public Const CONST_TEXT_ATTRI_TYPE As String = "Type"
    Public Const CONST_TEXT_ATTRI_GROUP_BY_FIELD As String = "GroupByField"
    Public Const CONST_TEXT_ATTRI_DATA_SOURCE As String = "dataSource"
    Public Const CONST_TEXT_ATTRI_DATA_ROWS As String = "dataRows"
    Public Const CONST_TEXT_ATTRI_HEADER_COLOR As String = "headerColor"
    Public Const CONST_TEXT_ATTRI_HEADER_FONT_COLOR As String = "headerFontColor"
    Public Const CONST_TEXT_ATTRI_DATA_FONT_COLOR As String = "dataFontColor"
    Public Const CONST_TEXT_ATTRI_ALIGN As String = "align"

    Public Const CONST_TEXT_NODE_MARGINS As String = "margins"
    Public Const CONST_TEXT_NODE_PARAMETERS As String = "parameters"
    Public Const CONST_TEXT_NODE_CONTENT As String = "content"
    Public Const CONST_TEXT_NODE_DYNAMIC_CONTENT As String = "dynamicContent"
    Public Const CONST_TEXT_NODE_STATIC_CONTENT As String = "staticContent"
    Public Const CONST_TEXT_NODE_TEXT_FIELD As String = "textField"
    Public Const CONST_TEXT_NODE_TABLE As String = "table"
    Public Const CONST_TEXT_NODE_BARCODE As String = "barCode"
    Public Const CONST_TEXT_NODE_TEXT As String = "text"
    Public Const CONST_TEXT_NODE_FONT As String = "font"
    Public Const CONST_TEXT_NODE_DATA As String = "data"
    Public Const CONST_TEXT_NODE_FORE_COLOR As String = "foregroundColor"
    Public Const CONST_TEXT_NODE_BACK_COLOR As String = "backgroundColor"
    Public Const CONST_TEXT_NODE_BORDER As String = "border"
    Public Const CONST_TEXT_NODE_COLUMNS As String = "columns"
    Public Const CONST_TEXT_NODE_HEADER As String = "header"
    Public Const CONST_TEXT_NODE_BORDER_COLOR As String = "borderColor"

    'align
    Public Const CONST_TEXT_ALIGN_LEFT As String = "Left"
    Public Const CONST_TEXT_ALIGN_CENTER As String = "Center"
    Public Const CONST_TEXT_ALIGN_RIGHT As String = "Right"
    Public Const CONST_TEXT_ALIGN_TOP As String = "Top"
    Public Const CONST_TEXT_ALIGN_MIDDLE As String = "Middle"
    Public Const CONST_TEXT_ALIGN_BOTTOM As String = "Bottom"
    Public Const CONST_TEXT_ALIGN_JUSTIFIED As String = "Justified"
    'Common
    Public Const CONST_TEXT_LAYOUT_LANDSCAPE As String = "Landscape"
    Public Const CONST_TEXT_CHECK As String = "Check"
    Public Const CONST_TEXT_TRUE_VALUE As String = "TrueValue"
    Public Const CONST_TEXT_PARAMETER_INDICATOR As String = "$P"
    Public Const CONST_TEXT_SHOW_HEADER As String = "showHeader"
    Public Const CONST_TEXT_DRAW_EMPTY_ROWS As String = "drawEmptyRows"
    Public Const CONST_TEXT_CELL_HEIGHT As String = "cellHeight"
    Public Const CONST_TEXT_PAGE_NUMBER As String = "pageNumber"
    Public Const CONST_TEXT_TOTAL_PAGES As String = "totalPages"
    Public Const CONST_TEXT_SYSTEM_DATA As String = "systemDate"
    Public Const CONST_TEXT_SYSTEM_TIME As String = "systemTime"
    'Font
    Public Const CONST_TEXT_FONT_ARAIL As String = "Arial"
    Public Const CONST_TEXT_FONT_REGULAR As String = "Regular"
    Public Const CONST_TEXT_FONT_BOLD_ITALIC As String = "Bold Italic"
    Public Const CONST_TEXT_FONT_BOLD As String = "Bold"
    Public Const CONST_TEXT_FONT_ITALIC As String = "Italic"

    'content
    'File'name
    Public Const CONST_PRINT_FILE_MARK As String = "."
    Public Const CONST_PRINT_CONTINUOUS_FILE As String = "_C"

    Public Const _PrintWareHouseStock As String = "_PrintWareHouseStock.xml"
    Public Const _PrintWareHouseStockDetail As String = "_PrintWareHouseStockDetail.xml"
    Public Const _PrintWareHouseInOut As String = "_PrintWareHouseInOut.xml"
    Public Const _PrintWareHouseInOutTotal As String = "_PrintWareHouseInOutTotal.xml"
    Public Const _PrintWareHouseInOutDetail As String = "_PrintWareHouseInOutDetail.xml"

    'xml's parameters
    Public Const CONST_XML_PARAMETERS_TITLE As String = "Title"
    Public Const CONST_XML_PARAMETERS_SUPPLYROOM As String = "SupplyRoom"
    Public Const CONST_XML_PARAMETERS_NOTETYPE As String = "NoteType"
    Public Const CONST_XML_PARAMETERS_NOTEID As String = "NoteID"
    Public Const CONST_XML_PARAMETERS_BARCODENUM As String = "BarCodeNum"
    Public Const CONST_XML_PARAMETERS_REGREQUEST As String = "RegRequest"
    Public Const CONST_XML_PARAMETERS_REGTIME As String = "RegTime"
    Public Const CONST_XML_PARAMETERS_REGNAME As String = "RegName"
    Public Const CONST_XML_PARAMETERS_OPROOM As String = "OPRoom"
    Public Const CONST_XML_PARAMETERS_DEPARTMENTNAME As String = "DepartmentName"
    Public Const CONST_XML_PARAMETERS_INSTYPE As String = "INSType"
    Public Const CONST_XML_PARAMETERS_INSKIND As String = "INSKind"

    Public Const CONST_XML_PARAMETERS_STARTDATE As String = "StartDate"
    Public Const CONST_XML_PARAMETERS_ENDDATE As String = "EndDate"
    Public Const CONST_XML_PARAMETERS_TYPEDATE As String = "DateType"
    Public Const CONST_XML_PARAMETERS_DPGROUP As String = "DPGroup"
    Public Const CONST_XML_PARAMETERS_WARD As String = "WARD"
    Public Const CONST_XML_PARAMETERS_BELONG As String = "DPBelong"
    Public Const CONST_XML_PARAMETERS_INSID As String = "INSID"
    Public Const CONST_XML_PARAMETERS_INSNAME As String = "INSName"
    Public Const CONST_XML_PARAMETERS_INSUnit As String = "INSUnit"
    Public Const CONST_XML_PARAMETERS_BATCH As String = "Batch"
    Public Const CONST_XML_PARAMETERS_COMPANY As String = "Company"
    Public Const CONST_XML_PARAMETERS_CONFIRMSTAFF As String = "ConfirmStaff"
    Public Const CONST_XML_PARAMETERS_CONFIRMDATE As String = "ConfirmDate"
    Public Const CONST_XML_PARAMETERS_PACKAGEID As String = "PackageID"
    Public Const CONST_XML_PARAMETERS_NAME As String = "Name"
    Public Const CONST_XML_PARAMETERS_TYPE As String = "Type"
    Public Const CONST_XML_PARAMETERS_GROUP As String = "Group"
    Public Const CONST_XML_PARAMETERS_RECEIVE_STAFF As String = "ReceiveStaff"
    Public Const CONST_XML_PARAMETERS_RECEIVE_DATE As String = "ReceiveDate"
    Public Const CONST_XML_PARAMETERS_TRAY_ID As String = "TrayID"
    Public Const CONST_XML_PARAMETERS_NOTES As String = "Notes"
    Public Const CONST_XML_PARAMETERS_MON_DATE As String = "MonDate"
    Public Const CONST_XML_PARAMETERS_COUNT As String = "Count"
    Public Const CONST_XML_PARAMETERS_USERNAME As String = "UserName"
    Public Const CONST_XML_PARAMETERS_UNITNAME As String = "UnitName"
    Public Const CONST_XML_PARAMETERS_DEPARTMENTTYPE As String = "DepartmentType"
    Public Const CONST_XML_PARAMETERS_DISTRICT_NAME As String = "DistrictName"

    Public Const CONST_XML_PARAMETERS_RETURNDP As String = "ReturnDP"
    Public Const CONST_XML_PARAMETERS_RETURNSTAFF As String = "ReturnStaff"
    Public Const CONST_XML_PARAMETERS_RETURNTIME As String = "ReturnTime"
    Public Const CONST_XML_PARAMETERS_RETURNTYPE As String = "ReturnType"
    Public Const CONST_XML_PARAMETERS_RETURNNURSE As String = "ReturnNurse"
    Public Const CONST_XML_PARAMETERS_RETURNOPROOM As String = "ReturnOPRoom"
    Public Const CONST_XML_PARAMETERS_ROOM_TYPE As String = "RoomType"

    Public Const CONST_PRINTMAP64_INVALIDE = 0
    Public Const CONST_PRINTMAP64_PRINT_TITLE As Integer = 1
    Public Const CONST_PRINTMAP64_INS_TYPE As Integer = 2
    Public Const CONST_PRINTMAP64_STERILIZE_METHOD As Integer = 3
    Public Const CONST_PRINTMAP64_STERILIZE_DATE As Integer = 4
    Public Const CONST_PRINTMAP64_AVAILABLE_DATE As Integer = 5
    Public Const CONST_PRINTMAP64_PACKAGE_STAFF As Integer = 6
    Public Const CONST_PRINTMAP64_DEPARTMENT As Integer = 7
    Public Const CONST_PRINTMAP64_NOTE_ID As Integer = 8
    Public Const CONST_PRINTMAP64_STAFFID_SUB As Integer = 9
    Public Const CONST_PRINTMAP64_BARCODE As Integer = 10
    Public Const CONST_PRINTMAP64_BARCODE_TEXTSTYLE As Integer = 11



    'Print map for 86 type
    Public Const CONST_PRINTMAP86_INVALIDE = 0
    Public Const CONST_PRINTMAP86_PRINT_TITLE As Integer = 1
    Public Const CONST_PRINTMAP86_INS_TYPE As Integer = 2
    Public Const CONST_PRINTMAP86_STERILIZE_METHOD As Integer = 3
    Public Const CONST_PRINTMAP86_STERILIZE_DATE As Integer = 4
    Public Const CONST_PRINTMAP86_AVAILABLE_DATE As Integer = 5
    Public Const CONST_PRINTMAP86_PACKAGE_STAFF As Integer = 6
    Public Const CONST_PRINTMAP86_DEPARTMENT As Integer = 7
    Public Const CONST_PRINTMAP86_NOTE_ID As Integer = 8
    Public Const CONST_PRINTMAP86_STAFFID_SUB As Integer = 9
    Public Const CONST_PRINTMAP86_BARCODE_FIRST As Integer = 10
    Public Const CONST_PRINTMAP86_BARCODE_SECOND As Integer = 11
    Public Const CONST_PRINTMAP86_BARCODE_THIRD As Integer = 12
    Public Const CONST_PRINTMAP86_BARCODE_FIRST_TEXTSTYLE As Integer = 13
    Public Const CONST_PRINTMAP86_BARCODE_SECOND_TEXTSTYLE As Integer = 14
    Public Const CONST_PRINTMAP86_BARCODE_THIRD_TEXTSTYLE As Integer = 15
    Public Const CONST_PRINTMAP86_PRINT_TITLE_SMALL_FIRST As Integer = 16
    Public Const CONST_PRINTMAP86_PRINT_TITLE_SMALL_SECOND As Integer = 17
    Public Const CONST_PRINTMAP86_MACHINE_ID_AND_BATCH As Integer = 18
    Public Const CONST_PRINTMAP86_PACKAGE_STAFF_1_AND_2 As Integer = 19

    Public Const CONST_PRINT86_WILDTH As Integer = 640
    Public Const CONST_PRINT86_HEIGHT As Integer = 480
End Module
