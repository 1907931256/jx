'********************************************************************
'	Title:			    InputMonitor
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			FPF
'	Create Date:	2009-12-7
'	Description:  Apply the Observer Modal to monitor the Mouse&Key action
'   Remark:          InputMonitor2-is constructed by Hook, and InputMonitor is by the input API monitoring.
'*********************************************************************
Option Explicit On
'Option Strict On '''Strict will disallow late binding

Imports System.Windows.Forms

Public Class InputMonitor2
    Private Class ObserverBaseInfo
        Private Const CONST_INT_DEFAULT_TIME_EXTERNAL As Integer = 60000 ' the default is one minute
        Public m_nRegisterTick As Integer
        Public m_nInternalTime As Integer
        Public m_bNonExecuted As Boolean
        Public m_nImpluseCount As Integer
        Public Sub New(Optional ByVal nInteval As Integer = CONST_INT_DEFAULT_TIME_EXTERNAL)
            m_nRegisterTick = Environment.TickCount
            m_nInternalTime = nInteval
            m_bNonExecuted = True
            m_nImpluseCount = 1
        End Sub
    End Class
    Private Shared m_Instance As InputMonitor2
    Private Shared m_TimerCheck As Timer
    Private Shared m_htObserverInfo As Hashtable

    Private Sub New()
        m_TimerCheck = New Timer 'the timer internal is 200ms by default, so any observer's internal is less than 200ms will not be check all. 
        m_htObserverInfo = New Hashtable
        Start()
    End Sub

    Private Shared Sub Create()
        If m_Instance Is Nothing Then
            m_Instance = New InputMonitor2
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Try
            [Stop]()
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Shared WriteOnly Property Enabled() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then
                AddHandler m_TimerCheck.Tick, AddressOf OnTimerCheckTick
            Else
                RemoveHandler m_TimerCheck.Tick, AddressOf OnTimerCheckTick
            End If
            m_TimerCheck.Enabled = value
        End Set
    End Property

    Private Shared Sub Start()
        Enabled = True
    End Sub

    Public Sub [Stop]()
        Enabled = False
    End Sub

    Public Shared Sub Subcribe(ByVal oObj As IInputObserver)
        Create()
        Dim oBaseInfo As New ObserverBaseInfo
        If m_htObserverInfo.Contains(oObj) Then
            m_htObserverInfo.Item(oObj) = oBaseInfo
        Else
            m_htObserverInfo.Add(oObj, oBaseInfo)
        End If
    End Sub

    Public Shared Sub DeSubcribe(ByVal oObj As IInputObserver)
        Create()
        If m_htObserverInfo.Contains(oObj) Then
            m_htObserverInfo.Remove(oObj)
        End If
    End Sub

    Private Shared Sub OnTimerCheckTick(ByVal sender As Object, ByVal e As EventArgs)
        Dim lastInputInfo As LASTINPUTINFO
        lastInputInfo.cbSize = Len(lastInputInfo)
        Dim thObject2 As Runtime.InteropServices.GCHandle = Runtime.InteropServices.GCHandle.Alloc(lastInputInfo, Runtime.InteropServices.GCHandleType.Pinned)
        Dim tpObject2 As IntPtr = thObject2.AddrOfPinnedObject()
        GetLastInputInfo(tpObject2)
        Dim dwTime As Int32 = thObject2.Target.dwTime
        If thObject2.IsAllocated Then thObject2.Free()
        Dim em As IDictionaryEnumerator = m_htObserverInfo.GetEnumerator
        While em.MoveNext
            Dim oKey As IInputObserver = CType(em.Key, IInputObserver)
            Dim oValue As ObserverBaseInfo = CType(em.Key, ObserverBaseInfo)
            Dim dwCurTime As Integer = dwTime
            If oValue.m_bNonExecuted AndAlso dwCurTime < oValue.m_nRegisterTick Then
                dwCurTime = oValue.m_nRegisterTick
            End If
            oValue.m_bNonExecuted = True
            If Environment.TickCount - dwCurTime >= oValue.m_nImpluseCount * oValue.m_nInternalTime Then
                oValue.m_nImpluseCount += 1
                oKey.NotifyDeactiveImpluse()
            End If
            If Environment.TickCount - dwCurTime < oValue.m_nInternalTime AndAlso (oValue.m_nImpluseCount > 1) Then 'turn to active
                oValue.m_nImpluseCount = 1
                oKey.NotifyReaction()
            End If
        End While
    End Sub
    Private Declare Function GetLastInputInfo Lib "user32" (ByVal plii As IntPtr) As Long
End Class

Public Interface IInputObserver
    Sub NotifyDeactiveImpluse()
    Sub NotifyReaction()
End Interface

<Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
    Public Structure LASTINPUTINFO
    Dim cbSize As Int32
    Dim dwTime As Int32
End Structure

Public Delegate Sub InputAction()
Public Class InputMonitor
    Private Declare Function GetLastInputInfo Lib "user32" (ByVal plii As IntPtr) As Long
    Private Shared m_Instance As InputMonitor
    Private Const CONST_INT_DEFAULT_NON_ACTIVE As Integer = 90 * 1000 'default 1.5 minute
    Private Shared m_TimerCheck As Timer
    Private Shared m_bBeginDeactive As Boolean
    Public Shared Event BeginDeactive As InputAction
    Public Shared Event BeginReactive As InputAction

    Private Sub New()
        m_TimerCheck = New Timer 'the timer internal is 200ms by default, so any observer's internal is less than 200ms will not be check all. 
        m_bBeginDeactive = False
        Start()
    End Sub

    Public Shared Sub Create()
        If m_Instance Is Nothing Then
            m_Instance = New InputMonitor
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Try
            [Stop]()
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Private Shared Sub Start()
        m_TimerCheck.Enabled = True
        AddHandler m_TimerCheck.Tick, AddressOf OnTimerCheckTick
    End Sub

    Public Sub [Stop]()
        m_TimerCheck.Enabled = False
        RemoveHandler m_TimerCheck.Tick, AddressOf OnTimerCheckTick
    End Sub

    Private Shared Sub OnTimerCheckTick(ByVal sender As Object, ByVal e As EventArgs)
        Dim lastInputInfo As LASTINPUTINFO
        lastInputInfo.cbSize = Len(lastInputInfo)
        Dim thObject2 As Runtime.InteropServices.GCHandle = Runtime.InteropServices.GCHandle.Alloc(lastInputInfo, Runtime.InteropServices.GCHandleType.Pinned)
        Dim tpObject2 As IntPtr = thObject2.AddrOfPinnedObject()
        GetLastInputInfo(tpObject2)
        Dim dwTime As Int32 = thObject2.Target.dwTime
        If thObject2.IsAllocated Then thObject2.Free()
        If Environment.TickCount - dwTime >= CONST_INT_DEFAULT_NON_ACTIVE AndAlso m_bBeginDeactive = False Then
            m_bBeginDeactive = True
            RaiseEvent BeginDeactive()
        End If
        If Environment.TickCount - dwTime < CONST_INT_DEFAULT_NON_ACTIVE AndAlso m_bBeginDeactive Then
            m_bBeginDeactive = False
            RaiseEvent BeginReactive()
        End If
    End Sub
End Class