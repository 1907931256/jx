Public Delegate Sub DlgDispose(ByVal sender As Object)
Public Class FocusDispatch
    Private Shared m_Instance As FocusDispatch
    Public Shared Event ModalDlgDispose As DlgDispose
    Private Sub New()

    End Sub

    Private Shared Sub Create()
        If m_Instance Is Nothing Then
            m_Instance = New FocusDispatch
        End If
    End Sub

    Public Shared Sub RaiseModalDlgBaseDispose(ByVal sender As Object)
        Create()
        RaiseEvent ModalDlgDispose(sender)
    End Sub

    Public Shared Sub RaiseFormDispose(ByVal sender As Object)
        Create()
        RaiseEvent ModalDlgDispose(sender)
    End Sub
End Class
