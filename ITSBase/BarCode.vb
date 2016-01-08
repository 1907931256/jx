'********************************************************************
'	Title:			BarCode
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-8-19
'	Description:    
'*********************************************************************

Option Explicit On
Option Strict On
Public Class BarCodeParse
    Public Const STAFF_PRE As String = "S-"
    Public Const FUNCTION_PRE As String = "F-"
    Public Const NUMBER_PRE As String = "N-"
    Public Const MACHINE_PRE As String = "M-"
    Public Const TRAY_PRE As String = "T-"
    Public Const INS_PRE As String = "W-"
    Public Const PACKAGE_PRE As String = "P-"
    Public Const MACHINE_PROCEDURE_PRE As String = "C-"
    Public Const OPERATING_ROOM As String = "OR-"
    Public Const OPERATING_TABLE As String = "OT-"
    Public Const BARROW_PRE As String = "B-"

    Public Const SU_REQUEST_PRE As String = "SY-"
    Public Const SU_GET_PRE As String = "LY-"
    Public Const RU_REQUEST_PRE As String = "SZ-"
    Public Const RU_EXCHANGE_PRE As String = "HZ-"
    Public Const RU_BORROW_PRE As String = "JZ-"
    Public Const PRI_AC_PRE As String = "ZG-"
    Public Const PRI_EO_PRE As String = "ZD-"
    Public Const OP_PRE As String = "OP-"
    Public Const LOANER_PRE As String = "WL-"
    Public Const DISPATCH_WITHOUT_REQUEST As String = "MZ-"

    Public Const DISTRICT_SU As String = "YY-"
    Public Const DISTRICT_RU As String = "YZ-"

    Public Const RECALL_RU_PRE As String = "ZZ-"
    Public Const RECALL_SU_PRE As String = "ZY-"

    Public Const SU_HIGH_VALUE_PRE As String = "GY-"
    Public Const RU_HIGH_VALUE_PRE As String = "GZ-"

    Public Const INS_BILLING As String = "JF-"

    Public Const SU_WH_INS As String = "WH-"  '库房一次性物品装箱条码

    Private Const Code128A As Integer = 103
    Private Const Code128B As Integer = 104
    Private Const Code128C As Integer = 105
    Private Const Code128Stop As Integer = 106
    Private Const CodeTest As Integer = 103 '计算检验位的Mod数值
  
   
  
    Public Shared Function PackageIDFormat(ByVal lPackgeID As Long) As String
        Return PACKAGE_PRE & lPackgeID.ToString
    End Function



    '********************************************************************
    '	Title:			WHSUCodeFormat
    '	Author:			MPY
    '	Create Date:	2013-11-20
    '	Description:    get barCode
    '*********************************************************************
    Public Shared Function WHSUCodeIDFormat(ByVal lID As Long) As String
        Return SU_WH_INS & lID.ToString
    End Function

    '********************************************************************
    '	Title:			Encode128AB
    '	Author:			cdx
    '	Create Date:	2011-7-7
    '	Description:    Draw BarCode 128AB
    '*********************************************************************
    Public Shared Sub DrawBarCode(ByVal strBarData As String, ByVal strId As String, ByVal g As Drawing.Graphics, _
                        ByVal nPostionX As Integer, ByVal nPostionBeginY As Integer, ByVal nPostionEndY As Integer)
        Dim myPenBlack As New Drawing.Pen(Drawing.Color.Black, 1)
        Dim myPenWhite As New Drawing.Pen(Drawing.Color.White, 1)
        Dim nLen As Integer = strId.Length
        '128码值
        Dim arrCode128End As String() = New String() {"bbsssbbbsbsbb"}
        Dim arrCode128 As String() = New String() {"bbsbbssbbss", "bbssbbsbbss", "bbssbbssbbs", "bssbssbbsss", "bssbsssbbss", _
                                                   "bsssbssbbss", "bssbbssbsss", "bssbbsssbss", "bsssbbssbss", "bbssbssbsss", _
                                                   "bbssbsssbss", "bbsssbssbss", "bsbbssbbbss", "bssbbsbbbss", "bssbbssbbbs", _
                                                   "bsbbbssbbss", "bssbbbsbbss", "bssbbbssbbs", "bbssbbbssbs", "bbssbsbbbss", _
                                                   "bbssbssbbbs", "bbsbbbssbss", "bbssbbbsbss", "bbbsbbsbbbs", "bbbsbssbbss", _
                                                   "bbbssbsbbss", "bbbssbssbbs", "bbbsbbssbss", "bbbssbbsbss", "bbbssbbssbs", _
                                                   "bbsbbsbbsss", "bbsbbsssbbs", "bbsssbbsbbs", "bsbsssbbsss", "bsssbsbbsss", _
                                                   "bsssbsssbbs", "bsbbsssbsss", "bsssbbsbsss", "bsssbbsssbs", "bbsbsssbsss", _
                                                   "bbsssbsbsss", "bbsssbsssbs", "bsbbsbbbsss", "bsbbsssbbbs", "bsssbbsbbbs", _
                                                   "bsbbbsbbsss", "bsbbbsssbbs", "bsssbbbsbbs", "bbbsbbbsbbs", "bbsbsssbbbs", _
                                                   "bbsssbsbbbs", "bbsbbbsbsss", "bbsbbbsssbs", "bbsbbbsbbbs", "bbbsbsbbsss", _
                                                   "bbbsbsssbbs", "bbbsssbsbbs", "bbbsbbsbsss", "bbbsbbsssbs", "bbbsssbbsbs", _
                                                   "bbbsbbbbsbs", "bbssbssssbs", "bbbbsssbsbs", "bsbssbbssss", "bsbssssbbss", _
                                                   "bssbsbbssss", "bssbssssbbs", "bssssbsbbss", "bssssbssbbs", "bsbbssbssss", _
                                                   "bsbbssssbss", "bssbbsbssss", "bssbbssssbs", "bssssbbsbss", "bssssbbssbs", _
                                                   "bbssssbssbs", "bbssbsbssss", "bbbbsbbbsbs", "bbssssbsbss", "bsssbbbbsbs", _
                                                   "bsbssbbbbss", "bssbsbbbbss", "bssbssbbbbs", "bsbbbbssbss", "bssbbbbsbss", _
                                                   "bssbbbbssbs", "bbbbsbssbss", "bbbbssbsbss", "bbbbssbssbs", "bbsbbsbbbbs", _
                                                   "bbsbbbbsbbs", "bbbbsbbsbbs", "bsbsbbbbsss", "bsbsssbbbbs", "bsssbsbbbbs", _
                                                   "bsbbbbsbsss", "bsbbbbsssbs", "bbbbsbsbsss", "bbbbsbsssbs", "bsbbbsbbbbs", _
                                                   "bsbbbbsbbbs", "bbbsbsbbbbs", "bbbbsbsbbbs", "bbsbssssbss", "bbsbssbssss", _
                                                   "bbsbssbbbss"}
        Dim arrCode128ComboAB As Char() = New Char() {" "c, "!"c, """"c, "#"c, "$"c, "%"c, _
                                                      "&"c, "'"c, "("c, ")"c, "*"c, "+"c, _
                                                      ","c, "-"c, "."c, "/"c, "0"c, "1"c, _
                                                      "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, _
                                                      "8"c, "9"c, ":"c, ";"c, "<"c, "="c, _
                                                      ">"c, "?"c, "@"c, "A"c, "B"c, "C"c, _
                                                      "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, _
                                                      "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, _
                                                      "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, _
                                                      "V"c, "W"c, "X"c, "Y"c, "Z"c, "["c, _
                                                      "\"c, "]"c, "^"c, "_"c, _
                                                      "`"c, "a"c, "b"c, "c"c, "d"c, "e"c, _
                                                      "f"c, "g"c, "h"c, "i"c, "j"c, "k"c, _
                                                      "l"c, "m"c, "n"c, "o"c, "p"c, "q"c, _
                                                      "r"c, "s"c, "t"c, "u"c, "v"c, "w"c, _
                                                      "x"c, "y"c, "z"c, "{"c, "|"c, "}"c, _
                                                      "~"c}

        '先计算检验位
        '检验位计算公式： 开始位＋（位值×数据） ％ 103
        '如 W-2001 采用128B编码
        '104+(1*55 + 2*13 + 3*18 + 4*16 + 5*16 + 6*17) %103
        Dim nTotle As Integer = 0 + Code128B
        'nNum存储编码的数据位置
        Dim nNum(1 + strBarData.Length - 1 + 1 + 1) As Integer
        nNum(0) = Code128B
        nNum(1 + strBarData.Length - 1 + 1 + 1) = Code128Stop
        For nIndexNum As Integer = 0 To strBarData.Length - 1
            For nIndexID As Integer = 0 To arrCode128ComboAB.Length - 1
                If strBarData(nIndexNum) = arrCode128ComboAB(nIndexID) Then
                    nTotle = nTotle + (nIndexNum + 1) * nIndexID
                    nNum(nIndexNum + 1) = nIndexID
                    Exit For
                End If
                If nIndexID = arrCode128ComboAB.Length Then
                    'error
                End If
            Next
        Next
        Dim nTestNum As Integer = nTotle Mod CodeTest
        nNum(1 + strBarData.Length - 1 + 1 + 1 - 1) = nTestNum
        'strResult用于存放最终画线的字符串
        '128ab编码规则 开始位＋数据位＋检验位＋结束位
        'nLen为数据位，2为开始位和检验位，13为结束位，
        Dim j As Integer = 0
        Dim strResult((nLen + 4) * 11 + 13 - 1) As String
        For i As Integer = 0 To nNum.Length - 1
            If i = nNum.Length - 1 Then
                For nI As Integer = 0 To arrCode128End(0).Length - 1
                    strResult(j) = arrCode128End(0).Chars(nI)
                    j += 1
                Next
            Else
                For nI As Integer = 0 To arrCode128(Code128B).Length - 1
                    strResult(j) = arrCode128(nNum(i)).Chars(nI)
                    j += 1
                Next
            End If
        Next
        Dim pos As Short = CShort(nPostionX)
        For i As Integer = 0 To strResult.Length - 1
            If strResult(i) = "s" Then
                g.DrawLine(myPenWhite, pos, nPostionBeginY, pos, nPostionEndY)   '画出条码的白线部分，pos为条码的的x轴位置控制条码的长度，60 90表示条码的y轴位置控制条码的宽度
            End If
            If strResult(i) = "b" Then
                g.DrawLine(myPenBlack, pos, nPostionBeginY, pos, nPostionEndY)
            End If
            pos = CShort(pos + 1)
        Next
    End Sub

    '********************************************************************
    '	Title:			HighValueSequenceCode
    '	Author:			MPY
    '	Create Date:	2013-09-18
    '	Description:    Analytical high value ins sequence code
    '*********************************************************************
    Public Shared Function HighValueSequenceCode(ByVal strCode As String, ByRef strBatch As String, ByRef strCheckDate As String) As Boolean
        If strCode.Length = 22 Then
            strBatch = strCode.Substring(10, 8)
            strCheckDate = DateTime.Now.Year.ToString.Substring(0, 2) & strCode.Substring(2, 6)
            Return True
        ElseIf strCode.Length = 20 Then
            strBatch = strCode.Substring(10, 10)
            strCheckDate = DateTime.Now.Year.ToString.Substring(0, 2) & strCode.Substring(2, 6)
            Return True
        End If

        Return False
    End Function
    Public Shared Function ParseCode(ByRef strGlobalCode As String) As BAR_CODE_TYPE
        Dim eBarCodeType As BAR_CODE_TYPE = BAR_CODE_TYPE.BARCODE_UNKNOW

        Dim nCodeLen As Integer = strGlobalCode.Length
        If nCodeLen < 3 Then Return eBarCodeType

        Dim nStart As Integer = strGlobalCode.IndexOf("-")
        If nStart <= 0 Then Return eBarCodeType

        Dim strStartFlag, strCode As String

        strStartFlag = strGlobalCode.Substring(0, nStart + 1).ToUpper
        strCode = strGlobalCode.Substring(nStart + 1)
        Select Case strStartFlag
            
            Case PACKAGE_PRE
                eBarCodeType = JudgePackageType(strCode)
            Case Else
                Return BAR_CODE_TYPE.BARCODE_UNKNOW
        End Select

        strGlobalCode = strCode
        Return eBarCodeType
    End Function
    Private Shared Function JudgePackageType(ByVal strCode As String) As BAR_CODE_TYPE '判断是否治疗包
        Dim eBarCodeType As BAR_CODE_TYPE = BAR_CODE_TYPE.BARCODE_UNKNOW
        If Judgement.IsNumeric(strCode, 1, 10) Then
            eBarCodeType = BAR_CODE_TYPE.BARCODE_PACKAGE
        End If
        Return eBarCodeType
    End Function
End Class

