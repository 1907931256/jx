Imports System.Windows.Forms

Public Class UITabControl
    Private m_arrColoreLable As Collection
    Private m_strText As String

    Public Event ItemClicked(ByVal strName As String)
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_arrColoreLable = New Collection
        Me.DoubleBuffered = True
        m_strText = String.Empty
    End Sub

    Public Overrides Property Text() As String
        Get
            Return m_strText
        End Get
        Set(ByVal value As String)
            m_strText = value
        End Set
    End Property

    Public Sub AddItem(ByVal strName As String, Optional ByVal bInit As Boolean = False)
        Dim oColoreLable As ColorLabel = New ColorLabel
        For Each sheet As ColorLabel In m_arrColoreLable
            If String.Compare(sheet.Text, strName, True) = 0 Then
                Exit Sub
            End If
        Next
        oColoreLable.Text = strName
        AddHandler oColoreLable.Click, AddressOf OnColorLblClick
        m_arrColoreLable.Add(oColoreLable)
        Me.Controls.Add(oColoreLable)
        RelayoutLabels()
        If bInit Then
            oColoreLable.PerformClick()
            m_strText = strName
        End If
    End Sub

    Private Sub RelayoutLabels()
        If m_arrColoreLable IsNot Nothing AndAlso m_arrColoreLable.Count > 0 Then
            Dim nEachLength As Integer = (Me.Width) / m_arrColoreLable.Count

            Dim nStartPos As Integer = 0
            For Each lbl As ColorLabel In m_arrColoreLable
                lbl.Location = New System.Drawing.Point(nStartPos, 0)
                lbl.Size = New System.Drawing.Size(nEachLength, Me.Height)
                nStartPos += nEachLength
            Next
        End If
    End Sub

    Private Sub OnColorLblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each lbl As ColorLabel In m_arrColoreLable
            If lbl Is sender Then
                lbl.PerformClick()
                If m_strText <> lbl.Text Then
                    m_strText = lbl.Text
                    RaiseEvent ItemClicked(CType(sender, ColorLabel).Text)
                End If

            Else
                lbl.PerformUnClick()
            End If
        Next
    End Sub

    Private Sub UITabControl_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        RelayoutLabels()
    End Sub
End Class
