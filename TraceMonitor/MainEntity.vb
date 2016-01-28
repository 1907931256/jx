Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Windows.Forms
Imports DBManager
Imports ITSBase

Public Class MainEntity
    Private Const Ip As String = "192.168.1.180"
    Private Const Port As Integer = 13121
    Private Const DefBufferSize As Integer = 4096
    Private Const HandShake As String = "ff ff ff ff 0a 3a c1 02 00 0a 94 16 40 06 00 37 56 6a a2 6b "
    Private Const ClientRequest As String = "FF FF FF FF CB B6 C1 02 00 06 47 B0 C0 06 00 37 "

    Private ReadOnly _treatyHead As Byte() = {&HFF, &HFF, &HFF, &HFF}
    Private _lastCardExicterPair As Dictionary(Of Integer, TraceNodeData)
    Private _dbSavedCardExciterPair As Dictionary(Of Integer, Integer)
    Private _parsingTraceData As List(Of TraceNodeData)
    Private _threadColl As List(Of Thread)
    Private _inRunning As Boolean
    Private _tcpListener As TcpListener

    Private Function Reset() As Boolean
        _inRunning = False
        Dim oLocalData As LocalDataModule.LocalData = LocalData.Create()
        oLocalData.SetPath(Application.StartupPath)
        If Not ConfigParse.LoadDBSetting() Then Return False
        If Not ConfigParse.LoadPrinterSetting() Then Return False
        JoinThread()
        _threadColl = New List(Of Thread)()
        _dbSavedCardExciterPair = New Dictionary(Of Integer, Integer)()
        _lastCardExicterPair = New Dictionary(Of Integer, TraceNodeData)
        _parsingTraceData = New List(Of TraceNodeData)()
        Return True
    End Function

    Private Sub JoinThread()
        If Not _threadColl Is Nothing Then
            For Each thread As Thread In _threadColl
                thread.Join()
            Next
        End If
    End Sub

    Public Function Start() As Boolean
        If Not Reset() Then Return False
        _inRunning = True
        _tcpListener = New TcpListener(New IPEndPoint(IPAddress.Parse(Ip), Port))
        _tcpListener.Start()
        Dim listenThread As New Thread(AddressOf ListenClientConnect)
        listenThread.Start()
        _threadColl.Add(listenThread)
        Dim analysizThread As New Thread(AddressOf ClientAnalysizThread)
        analysizThread.Start()
        _threadColl.Add(analysizThread)
        Return True
    End Function

    Private Sub ListenClientConnect()
        While _inRunning
            Try
                Dim remoteClient = (_tcpListener.AcceptTcpClient())
                Dim procThread As New Thread(AddressOf ClientProcThread)
                procThread.Start(remoteClient)
                _threadColl.Add(procThread)
                Thread.Sleep(1)
            Catch ex As Exception

            End Try
        End While
    End Sub

    Private Sub ClientAnalysizThread()
        While _inRunning
            SyncLock _parsingTraceData
                For i As Integer = _parsingTraceData.Count - 1 To 0 Step -1
                    AddTraceRecord(_parsingTraceData(i))
                    _parsingTraceData.RemoveAt(i)
                Next
            End SyncLock
            Thread.Sleep(1)
        End While
    End Sub

    Private Sub ClientProcThread(remoteClient As TcpClient)
        Dim streamToClient As NetworkStream = remoteClient.GetStream()
        SyncLock (streamToClient)
            '先网客户端发送指令，让其传入数据进来
            OmitData(streamToClient)
            Dim handShakeByts As Byte() = GlobalMethod.Scale16StringToByts(HandShake)
            streamToClient.Write(handShakeByts, 0, handShakeByts.Length)
            '接收数据
            While _inRunning
                Dim readByts As Byte() = New Byte(DefBufferSize) {}
                Dim bytsReadCount As Integer = streamToClient.Read(readByts, 0, DefBufferSize)
                Dim read As String = GlobalMethod.BytsToScale16(readByts, bytsReadCount)
                Debug.Print(bytsReadCount.ToString().PadLeft(3) + "   " + read)
                If read = ClientRequest Then
                    streamToClient.Write(handShakeByts, 0, handShakeByts.Length)
                    Continue While
                End If
                AnalysizRecievedData(readByts, bytsReadCount)
                Thread.Sleep(1)
            End While
        End SyncLock
    End Sub

    Private Sub AnalysizRecievedData(ByVal readByts As Byte(), bytsReadCount As Integer)
        If readByts Is Nothing OrElse readByts.Length <= 0 Then Return
        Dim cards As New List(Of Integer)
        Dim first As Integer = GlobalMethod.ByteIndexOf(readByts, _treatyHead, 0)
        Dim second As Integer = GlobalMethod.ByteIndexOf(readByts, _treatyHead, first + _treatyHead.Length)
        While (second - first >= 20)
            Dim newExciter As Integer = readByts(second - 4) * 256 + readByts(second - 3)
            Dim oldExciter As Integer = readByts(second - 2) * 256 + readByts(second - 1)
            Dim cardNo As Integer = readByts(second - 8) * 256 * 256 + readByts(second - 7) * 256 + readByts(second - 6)
            If Not cards.Contains(cardNo) Then '已经包含该卡，则忽略解析
                cards.Add(cardNo)
                SyncLock _parsingTraceData
                    _parsingTraceData.Add(New TraceNodeData() With {.CardNo = cardNo, .OldExciter = oldExciter, .NewExciter = newExciter})
                End SyncLock
            End If
            first = second
            second = GlobalMethod.ByteIndexOf(readByts, _treatyHead, first + _treatyHead.Length)
        End While
    End Sub

    Private Sub AddTraceRecord(parsing As TraceNodeData)
        If Not _lastCardExicterPair.Keys.Contains(parsing.CardNo) Then
            _lastCardExicterPair.Add(parsing.CardNo, New TraceNodeData() With {.CardNo = parsing.CardNo, .NewExciter = parsing.NewExciter, .OldExciter = parsing.OldExciter})
            AddTraceRecordToDb(parsing.CardNo, parsing.NewExciter)
        Else
            Dim traceNode As TraceNodeData = _lastCardExicterPair(parsing.CardNo)
            If parsing.NewExciter = traceNode.NewExciter AndAlso parsing.OldExciter = traceNode.OldExciter Then '如果连续两次都一样，则认为是有效定位数据
                AddTraceRecordToDb(parsing.CardNo, parsing.NewExciter)
            Else
                _lastCardExicterPair(parsing.CardNo).NewExciter = parsing.NewExciter
                _lastCardExicterPair(parsing.CardNo).OldExciter = parsing.OldExciter
            End If
        End If
    End Sub

    Private Sub AddTraceRecordToDb(cardno As Integer, exciter As Integer)
        Dim traceDb As New DbTraceLayout
        If Not _dbSavedCardExciterPair.Keys.Contains(cardno) OrElse _dbSavedCardExciterPair(cardno) <> exciter Then '没有存过DB或者和上一次存的DB不一样
            If traceDb.AddTraceRecord(cardno, exciter) = DBMEDITS_RESULT.SUCCESS Then
                If Not _dbSavedCardExciterPair.Keys.Contains(cardno) Then
                    _dbSavedCardExciterPair.Add(cardno, exciter)
                Else
                    _dbSavedCardExciterPair(cardno) = exciter
                End If
            End If
        End If
    End Sub

    Private Sub OmitData(streamToClient As NetworkStream)
        Dim readByts As Byte() = New Byte(DefBufferSize) {}
        While (streamToClient.DataAvailable)
            streamToClient.Read(readByts, 0, DefBufferSize)
        End While
    End Sub

    Public Sub [Stop]()
        _tcpListener.Stop()
        _inRunning = False
        JoinThread()
    End Sub
End Class

Public Class TraceNodeData
    Public Property CardNo() As Integer
    Public Property NewExciter() As Integer
    Public Property OldExciter() As Integer
End Class
