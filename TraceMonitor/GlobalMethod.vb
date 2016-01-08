Public Class GlobalMethod
    Public Shared Function Scale16ToByts(ByVal strOri As String) As Byte()
        If String.IsNullOrEmpty(strOri) Then Return Nothing
        Debug.Assert(strOri.Length Mod 3 = 0)
        If (strOri.Length Mod 3 <> 0) Then
            Return Nothing
        End If
        Dim byts() As Byte = New Byte(strOri.Length / 3 - 1) {}
        For i As Integer = 0 To strOri.Length / 3 - 1
            Dim strCur As String = strOri.Substring(i * 3, 3).Trim()
            Dim nValue As Integer = Convert.ToInt32(strCur, 16)
            byts(i) = nValue
        Next
        Return byts
    End Function

    Public Shared Function BytsToScale16(ByVal byts() As Byte, nLength As Integer) As String
        Dim strRet As String = ""
        If Not byts Is Nothing Then
            For i As Integer = 0 To Math.Min(nLength - 1, byts.Length - 1)
                strRet += Convert.ToString(byts(i), 16).ToUpper.PadLeft(2, "0") + " "
            Next
        End If
        Return strRet
    End Function

    Public Shared Function Scalize16With4Pad(ByVal nValue As Integer) As String
        '10 scale to 16 scale
        Dim strValue As String = Convert.ToString(nValue, 16).PadLeft(4, "0")
        Dim strRet As String = strValue.Substring(2, 2).ToUpper + " " + strValue.Substring(0, 2).ToUpper
        Return strRet
    End Function

    Public Shared Function Scale16StringToByts(ByVal strScale16 As String, Optional ByVal bExcludeZero As Boolean = False) As Byte()
        If strScale16 = "" Then Return New Byte() {}
        Debug.Assert(strScale16.Length Mod 3 = 0)
        Dim byts() As Byte = New Byte(strScale16.Length / 3 - 1) {}
        Dim nZeroCount As Integer = 0
        For i As Integer = 0 To strScale16.Length / 3 - 1
            Dim strCur As String = strScale16.Substring(i * 3, 3).Trim()
            Dim nValue As Integer = Convert.ToInt32(strCur, 16)
            If nValue = 0 Then nZeroCount += 1
            byts(i) = nValue
        Next
        If nZeroCount > 0 AndAlso bExcludeZero = True Then
            Dim bytsRtn() As Byte = New Byte(strScale16.Length / 3 - 1 - nZeroCount) {}
            Dim i As Integer = 0
            For Each byt As Byte In byts
                If byt <> 0 Then
                    bytsRtn(i) = byt
                    i += 1
                End If
            Next
            Return bytsRtn
        Else
            Return byts
        End If
    End Function

    Public Shared Function IsIPV4(ByVal oInput As Object) As Boolean
        If IsDBNull(oInput) OrElse oInput Is Nothing Then Return False
        If CStr(oInput).Length = 0 Then Return False
        Dim strRegexExpression As String = "^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"
        Return System.Text.RegularExpressions.Regex.IsMatch(CStr(oInput), strRegexExpression)
    End Function

    Public Shared Function ExcludeZeroByte(ByVal byts() As Byte) As Byte()
        If byts Is Nothing OrElse byts.Length = 0 Then Return Nothing
        Dim nZeroCount = 0
        For Each byt As Byte In byts
            If byt = 0 Then nZeroCount += 1
        Next
        Dim bytsRtn() As Byte = New Byte(byts.Length - nZeroCount - 1) {}
        Dim nStep As Integer = 0
        For Each byt As Byte In byts
            If byt <> 0 Then
                bytsRtn(nStep) = byt
                nStep += 1
            End If
        Next
        Return bytsRtn
    End Function

    Public Shared Function IsStringAllBlank(ByVal strOri As String) As Boolean
        If String.IsNullOrEmpty(strOri) Then
            Return True
        End If

        Dim nIndex As Integer = strOri.IndexOf(vbCrLf)
        While nIndex >= 0
            Dim strSep As String = strOri.Substring(0, nIndex).Trim()
            If Not String.IsNullOrEmpty(strSep) Then
                Return False
            End If
            strOri = strOri.Substring(nIndex + vbCrLf.Length)
            nIndex = strOri.IndexOf(vbCrLf)
        End While
        If Not String.IsNullOrEmpty(strOri.Trim) Then
            Return False
        End If
        Return True
    End Function

    Public Shared Sub RemoveString(ByRef str As String, ByVal strRemove As String)
        If String.IsNullOrEmpty(str) Then
            Return
        End If
        Dim nIndex As Integer = str.IndexOf(strRemove)
        While nIndex >= 0
            str = str.Remove(nIndex, strRemove.Length)
            nIndex = str.IndexOf(strRemove)
        End While
    End Sub

    Public Shared Function ByteIndexOf(ByRef searched As Byte(), find As Byte(), start As Integer) As Integer
        If searched Is Nothing OrElse find Is Nothing OrElse searched.Length < find.Length OrElse start < 0 Then Return -1
        Dim strFind As String = BytsToScale16(find, find.Length)
        For i As Integer = start To searched.Length - find.Length
            Dim bytSearch As Byte() = TruncateByts(searched, i)
            If BytsToScale16(bytSearch, find.Length) = strFind Then Return i
        Next
        Return -1
    End Function

    Public Shared Sub ConcatByts(ByRef source As Byte(), concat As Byte())
        If source Is Nothing Then source = New Byte() {}
        If concat Is Nothing Then Return
        Dim srcCopy As Byte() = New Byte(source.Length - 1) {}
        Array.Copy(source, 0, srcCopy, 0, source.Length)
        source = New Byte(source.Length + concat.Length - 1) {}
        srcCopy.CopyTo(source, 0)
        concat.CopyTo(source, srcCopy.Length)
    End Sub

    Public Shared Function TruncateByts(ByVal source As Byte(), nStart As Integer)
        Dim bytsReturn As Byte() = New Byte(-1) {}
        If Not source Is Nothing AndAlso nStart < source.Length Then
            bytsReturn = New Byte(source.Length - 1 - nStart) {}
            Array.Copy(source, nStart, bytsReturn, 0, bytsReturn.Length)
        End If
        Return bytsReturn
    End Function
End Class
