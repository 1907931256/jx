'********************************************************************
'	Title:			Judgement
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-4-18
'	Description:    Tool Class for check the data valid
'*********************************************************************
Option Explicit On 
Option Strict On
Imports System.Text.RegularExpressions
Public Class Judgement
    '********************************************************************
    '	Title:			JudgeDataValue
    '	Author:			FB
    '	Create Date:	2009-4-27
    '	Description:    Judge IsDBNull,if it is true convert it into a nothing value 
    '*********************************************************************
    Public Shared Function JudgeDBNullValue(ByVal objSourceObject As Object, ByVal enumDataType As ENUM_DATA_TYPE) As Object
        Dim objResult As Object
        If IsDBNull(objSourceObject) Then
            Select Case enumDataType
                Case ENUM_DATA_TYPE.DATA_TYPE_STRING
                    objResult = ""
                    Return objResult
                Case ENUM_DATA_TYPE.DATA_TYPE_INTEGER
                    objResult = 0
                    Return objResult
                Case ENUM_DATA_TYPE.DATA_TYPE_FLOAT
                    objResult = 0.0
                    Return objResult
                Case ENUM_DATA_TYPE.DATA_TYPE_DATE
                    objResult = DateTime.MinValue
                    Return objResult
                Case ENUM_DATA_TYPE.DATA_TYPE_OTHER
                    objResult = Nothing
                    Return objResult
            End Select
        End If
        objResult = objSourceObject
        Return objResult
    End Function
    '********************************************************************
    '	Title:			IsSterilizeNothing
    '	Author:			FB
    '	Create Date:	2009-4-18
    '	Description:    Check Sterilize nothing according to the batch ID.
    '                   batch ID is letter,that means sterilize nothing 
    '*********************************************************************
    Public Shared Function IsSterilizeNothing(ByVal strBatchID As String) As Boolean
        If strBatchID <> "" AndAlso Char.IsLetter(strBatchID.Chars(0)) Then
            Return True
        Else
            Return False
        End If
    End Function
    '********************************************************************
    '	Title:			IsPlusInteger
    '	Author:			FB
    '	Create Date:	2009-4-20
    '	Description:    check the integer > 0
    '*********************************************************************
    Public Shared Function IsPlusInteger(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False

        If CStr(oInput).Length = 0 Then Return False

        Return Regex.IsMatch(CStr(oInput), "^\+?[1-9][0-9]*$")
    End Function

    '********************************************************************
    '	Title:			IsPlusOrZeroInteger
    '	Author:			FB
    '	Create Date:	2009-4-21
    '	Description:    check the integer >= 0
    '*********************************************************************
    Public Shared Function IsPlusOrZeroInteger(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False

        If CStr(oInput).Length = 0 Then Return False

        Return Regex.IsMatch(CStr(oInput), "^\+?(0|[1-9][0-9]*)$")
    End Function

    '********************************************************************
    '	Title:			IsMinusInteger
    '	Author:			FPF
    '	Create Date:	2009-4-22
    '	Description:    check the integer < 0
    '*********************************************************************
    Public Shared Function IsMinusInteger(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False

        If CStr(oInput).Length = 0 Then Return False

        Return Regex.IsMatch(CStr(oInput), "^\-[1-9][0-9]*$")
    End Function

    '********************************************************************
    '	Title:			IsCountedPlusInteger
    '	Author:			FPF
    '	Create Date:	2009-4-22
    '	Description:    check the integer >= 0 with specified bit count
    '*********************************************************************
    Public Shared Function IsCountedPlusInteger(ByVal oInput As Object, ByVal nBitCount As Integer) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing OrElse nBitCount <= 0 Then Return False

        If CStr(oInput).Length = 0 Then Return False

        'Dim strRegexExpression As String = String.Format("^\+?(0|[1-9][0-9]{0,{0}})$", nBitCount - 1)
        Dim strRegexExpression As String = "^\+?[1-9][0-9]{0," + (nBitCount - 1).ToString + "}$"
        Return Regex.IsMatch(CStr(oInput), strRegexExpression)
    End Function
    '********************************************************************
    '	Title:			IsCountedPlusDecimal
    '	Author:			FB
    '	Create Date:	2009-5-5
    '	Description:    check the integer >0.00 with specified bit count
    '*********************************************************************
    Public Shared Function IsCountedPlusDecimal(ByVal oInput As Object, ByVal nBitCount As Integer) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing OrElse nBitCount <= 0 Then Return False
        If CStr(oInput).Length = 0 Then Return False

        Dim strRegexExpression As String = "^\+?([0-9]*)+(\.[0-9]{0," + nBitCount.ToString + "})?$"
        If Regex.IsMatch(CStr(oInput), strRegexExpression) Then
            Return (CSng(oInput) > 0)
        End If

        Return False
    End Function
    '********************************************************************
    '	Title:			FormatExpense
    '	Author:			FB
    '	Create Date:	2010-9-7  
    '	Description:    Format Expense (Delete the signal of "£¤")
    '*********************************************************************
    Public Shared Function FormatExpense(ByVal oInput As Object) As String
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return String.Empty
        If CStr(oInput).Length = 0 Then Return String.Empty

        Dim strRegexExpression As String = "\+?([0-9]{1,})+(\.[0-9]{0,2})?$"
        Dim lst As MatchCollection = Regex.Matches(CStr(oInput), strRegexExpression, RegexOptions.Compiled)
        If lst Is Nothing OrElse lst.Count <> 1 Then Return String.Empty
        Return lst.Item(0).ToString
    End Function

    '********************************************************************
    '	Title:			IsNumeric
    '	Author:			FB
    '	Create Date:	2009-5-5
    '	Description:    check every bit is number
    '*********************************************************************
    Public Shared Function IsNumeric(ByVal oInput As Object, ByVal nMin As Integer, ByVal nMax As Integer) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False
        If CStr(oInput).Length = 0 Then Return False

        Dim strRegexExpression As String = "^\d{" + nMin.ToString + "," + nMax.ToString + "}$"
        Return Regex.IsMatch(CStr(oInput), strRegexExpression)

    End Function
    '********************************************************************
    '	Title:			IsNumeric
    '	Author:			FB
    '	Create Date:	2009-5-5
    '	Description:    check every bit is number
    '*********************************************************************
    Public Shared Function IsNumeric(ByVal oInput As Object, ByVal nFixLenth As Integer) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False
        If CStr(oInput).Length = 0 Then Return False

        Dim strRegexExpression As String = "^\d{" + nFixLenth.ToString + "}$"
        Return Regex.IsMatch(CStr(oInput), strRegexExpression)

    End Function
    '********************************************************************
    '	Title:			IsBatchNum
    '	Author:			cdx
    '	Create Date:	2009-8-12
    '	Description:    check the input is BatchNum or not
    '                   yyyy from 2000 to 2999
    '                   MM   from 01   to 12
    '                   dd   from 01   to 99
    '*********************************************************************
    Public Shared Function IsBatchNum(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False


        If CStr(oInput).Length = 0 Then Return False


        Return Regex.IsMatch(CStr(oInput), "([2][0-9]{3})([0][1-9]|[1][0-2])([0][1-9]|[1-9][0-9])$")
    End Function
    '********************************************************************
    '	Title:			IsTime
    '	Author:			FB
    '	Create Date:	2009-9-23
    '	Description:    check time (10:12:59)
    '*********************************************************************
    Public Shared Function IsTime(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False
        If CStr(oInput).Length = 0 Then Return False

        Dim strRegexExpression As String = "(\s(((0?[0-9])|([1-2][0-3]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$"
        Return Regex.IsMatch(CStr(oInput), strRegexExpression)

    End Function

    '********************************************************************
    '	Title:			    IsIPV4
    '	Author:			FPF
    '	Create Date:	2009-11-27
    '	Description:    Check IPV4
    '*********************************************************************
    Public Shared Function IsIPV4(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False
        If CStr(oInput).Length = 0 Then Return False
        Dim strRegexExpression As String = "^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"
        Return Regex.IsMatch(CStr(oInput), strRegexExpression)
    End Function
    '********************************************************************
    '	Title:			IsPerformanceEvaluation
    '	Author:			cdx
    '	Create Date:	2010-7-15
    '	Description:    check the integer >0.0  and <=999.9
    '*********************************************************************
    Public Shared Function IsPerformanceEvaluation(ByVal oInput As Object) As Boolean
        If IsCountedPlusDecimal(oInput, 1) Then
            Return (CSng(oInput) < 1000)
        End If
        Return False
    End Function
    '********************************************************************
    '	Title:			IsCostMonth
    '	Author:			FB
    '	Create Date:	2010-8-25
    '	Description:    check the input is Cost month or not (Format:yyyyMM)
    '                   yyyy from 2000 to 2999
    '                   MM   from 01   to 12
    '*********************************************************************
    Public Shared Function IsCostMonth(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False


        If CStr(oInput).Length = 0 Then Return False


        Return Regex.IsMatch(CStr(oInput), "([2][0-9]{3})([0][1-9]|[1][0-2])$")
    End Function
    '********************************************************************
    '	Title:			ExpenseCompare
    '	Author:			FB
    '	Create Date:	2010-8-26
    '	Description:    Compare two expense value
    '                   if left = right return zero,otherwise return left - right
    '*********************************************************************
    Public Shared Function ExpenseCompare(ByVal left As Single, ByVal right As Single) As Single
        Dim fLeft As Single = CSng(Math.Round(left, 2))
        Dim fRight As Single = CSng(Math.Round(right, 2))
        Return CSng(fLeft - fRight)
    End Function

    '********************************************************************
    '	Title:			IsCostDecimal
    '	Author:			LCH
    '	Create Date:	2010-7-15
    '	Description:    check the integer >0.00  and <=99999999.99,DoubleÐÍ
    '*********************************************************************
    Public Shared Function IsCostDecimal(ByVal oInput As Object) As Boolean
        If IsCountedPlusDecimal(oInput, 2) Then
            Return (CDbl(oInput) < 100000000)
        End If
        Return False
    End Function
    Public Shared Function IsPercentage(ByVal oInput As Object) As Boolean
        If IsCountedPlusDecimal(oInput, 2) Then
            Return (CDbl(oInput) <= 100)
        End If
        Return False
    End Function

    '********************************************************************
    '	Title:			IsNonnegtiveDecimal
    '	Author:			MPY
    '	Create Date:	2012-12-28
    '	Description:   Not negative Decimal and two Decimal (>=0.00)
    '*********************************************************************
    Public Shared Function IsNonnegtiveDecimal(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) Then Return False
        If CStr(oInput).Length = 0 Then Return False
        Return Regex.IsMatch(CStr(oInput), "^\+?[0-9]*\.?[0-9]{0,2}$")
    End Function
    '********************************************************************
    '	Title:			IsAge
    '	Author:			MPY
    '	Create Date:	2013-06-17
    '	Description:   0-150
    '*********************************************************************
    Public Shared Function IsAge(ByVal oInput As Object) As Boolean
        If IsPlusOrZeroInteger(oInput) Then
            If CInt(oInput) < 151 Then
                Return True
            End If
        End If
        Return False
    End Function

    '********************************************************************
    '	Title:			IsNum
    '	Author:			MPY
    '	Create Date:	2013-09-28
    '	Description:    0~9 build 13~25
    '*********************************************************************
    Public Shared Function IsNum(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) Then Return False
        If CStr(oInput).Length = 0 Then Return False
        Return Regex.IsMatch(CStr(oInput), "^\+?[0-9]{13,25}")
    End Function
End Class
