'********************************************************************
'	Title:			Schedule
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FB
'	Create Date:	2009-9-23
'	Description:    
'*********************************************************************
Imports System.Threading
Imports System.Runtime.CompilerServices
Imports ITSBase
Namespace Schedule
    Public Delegate Sub ImplementMethod()
    Public Class ScheduleTimer
        Private m_oTimer As Timer
        Private m_bRun As Boolean
        Private m_oTaskCollection As TaskCollection
        Private Shared m_tsDifferentNow As TimeSpan
        Public Shared ReadOnly Property Now() As DateTime
            Get
                Return Date.Now.Subtract(m_tsDifferentNow)
            End Get
        End Property
        'nPeriod is the Milliseconds
        Public Sub New(ByVal dtimeCurrentNow As DateTime, Optional ByVal nPeriod As Integer = 500)
            m_tsDifferentNow = Date.Now.Subtract(dtimeCurrentNow)
            m_bRun = False
            m_oTaskCollection = New TaskCollection
            m_oTimer = New Timer(AddressOf Timer_Elapsed, Nothing, 0, nPeriod)
        End Sub
        Public Sub Release()
            StopTimer()
            m_oTimer.Dispose()
            m_oTaskCollection.Clear()
        End Sub
        Public Function AddTask(ByVal nTaskIndex As Integer, ByVal eType As SCHEDULE_TYPE, _
                                ByVal nInterval As Integer, ByVal ts As TimeSpan, _
                                ByVal oMethod As ImplementMethod) As Boolean

            Dim bRun As Boolean = m_bRun
            StopTimer()
            Dim bRet As Boolean
            Dim oTaskItem As New TaskItem(nTaskIndex, eType, nInterval, ts, oMethod)
            bRet = m_oTaskCollection.AddTask(oTaskItem)
            If bRun Then StartTimer()
            Return bRet
        End Function
        Public Function RemoveTask(ByVal nTaskIndex As Integer)
            Dim bRun As Boolean = m_bRun
            StopTimer()

            Dim bRet As Boolean
            bRet = m_oTaskCollection.RemoveTask(nTaskIndex)
            If bRun Then StartTimer()
            Return bRet
        End Function
        <MethodImpl(MethodImplOptions.Synchronized)> _
        Public Sub StartTimer()
            m_bRun = True
        End Sub

        <MethodImpl(MethodImplOptions.Synchronized)> _
        Public Sub StopTimer()
            m_bRun = False
        End Sub

        <MethodImpl(MethodImplOptions.Synchronized)> _
        Private Sub Timer_Elapsed(ByVal sender As Object)
            If Not m_bRun Then Exit Sub

            Dim oItem As TaskItem = m_oTaskCollection.FindNewtRunTask
            If oItem IsNot Nothing Then oItem.Implement()
        End Sub

    End Class

    Public Class TaskCollection
        Inherits List(Of TaskItem)
        Private m_nFindIndexKey As Integer
        Public Function FindNewtRunTask() As TaskItem
            For Each oItem As TaskItem In Me
                If oItem.NextRunTime < ScheduleTimer.Now Then
                    Return oItem
                End If
            Next

            Return Nothing
        End Function
        Public Function AddTask(ByVal oTaskItem As TaskItem) As Boolean
            Dim oItem As TaskItem = FindTask(oTaskItem.TaskIndex)
            If oItem Is Nothing Then
                Me.Add(oTaskItem)
                Return True
            End If
            Return False
        End Function
        Public Overloads Function RemoveTask(ByVal nTaskIndex As Integer) As Boolean
            Dim oItem As TaskItem = FindTask(nTaskIndex)
            If oItem IsNot Nothing Then
                Me.Remove(oItem)
                Return True
            End If
            Return False
        End Function
        Private Function FindTask(ByVal nTaskIndex As Integer) As TaskItem
            m_nFindIndexKey = nTaskIndex
            Dim oItem As TaskItem = Me.Find(AddressOf FindItem)
            m_nFindIndexKey = -1
            Return oItem
        End Function
        Private Function FindItem(ByVal oElement As TaskItem) As Boolean
            Return oElement.TaskIndex = m_nFindIndexKey
        End Function
    End Class

    Public Class TaskItem
        Private m_nTaskIndex As Integer
        Private m_eType As SCHEDULE_TYPE
        Private m_nInterval As Integer
        Private m_oMethod As ImplementMethod
        Private m_dtimeNextRun As DateTime
        Public ReadOnly Property NextRunTime() As DateTime
            Get
                Return m_dtimeNextRun
            End Get
        End Property
        Public ReadOnly Property TaskIndex() As Integer
            Get
                Return m_nTaskIndex
            End Get
        End Property
        Public Sub New(ByVal nTaskIndex As Integer, ByVal eType As SCHEDULE_TYPE, _
                       ByVal nInterval As Integer, ByVal ts As TimeSpan, _
                       ByVal oMethod As ImplementMethod)

            m_nTaskIndex = nTaskIndex
            m_eType = eType
            m_nInterval = nInterval
            m_oMethod = oMethod
            If m_eType = SCHEDULE_TYPE.DAILY Then
                Dim dtime As DateTime = ScheduleTimer.Now.Date.Add(ts)
                If dtime < ScheduleTimer.Now Then
                    m_dtimeNextRun = dtime.AddDays(1)
                Else
                    m_dtimeNextRun = dtime
                End If
            Else
                CalculateNextTime()
            End If
        End Sub
        Public Sub Implement()
            If m_oMethod IsNot Nothing Then
                m_oMethod.Invoke()
                CalculateNextTime()
            End If
        End Sub
        Private Sub CalculateNextTime()
            If m_eType = SCHEDULE_TYPE.DAILY Then
                m_dtimeNextRun = m_dtimeNextRun.AddDays(1)
                Exit Sub
            End If
            m_dtimeNextRun = ScheduleTimer.Now.Add(CalculateNextTimeSpan)
        End Sub
        Private Function CalculateNextTimeSpan() As TimeSpan
            Select Case m_eType
                Case SCHEDULE_TYPE.BYSECOND
                    Return New TimeSpan(0, 0, 0, m_nInterval)
                Case SCHEDULE_TYPE.BYMINUTE
                    Return New TimeSpan(0, 0, m_nInterval, 0)
                Case SCHEDULE_TYPE.BYHOUR
                    Return New TimeSpan(0, m_nInterval, 0, 0)
                Case Else
                    Return New TimeSpan(0, 0, 0, 0)
            End Select
        End Function
    End Class
End Namespace
