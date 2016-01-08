Public Class UILabelCheckboxes
    Private m_strTitleText As String
    Private m_bCheckValue() As Boolean
    Private m_lstUiLabelCheckbox As List(Of UILabelCheckboxes)
    Private m_oUILabelcheckbox As UILabelCheckboxes
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_strTitleText = String.Empty
        m_bCheckValue = New Boolean() {False, False, False, False}
        m_lstUiLabelCheckbox = New List(Of UILabelCheckboxes)
    End Sub
    Public Property TitleText() As String
        Get
            Return m_strTitleText
        End Get
        Set(ByVal value As String)
            m_strTitleText = value
            AddTextToControl()
        End Set
    End Property
    Public Property CheckValue() As Boolean()
        Get
            Return m_bCheckValue
        End Get
        Set(ByVal value As Boolean())
            m_bCheckValue = value
            AddTextToControl()
        End Set
    End Property
    Public Property UICheckboxNodes() As List(Of UILabelCheckboxes)
        Get
            Return m_lstUiLabelCheckbox
        End Get
        Set(ByVal value As List(Of UILabelCheckboxes))
            m_lstUiLabelCheckbox = value
        End Set
    End Property
    Public Property UICheckBoxParentNode() As UILabelCheckboxes
        Get
            Return m_oUILabelcheckbox
        End Get
        Set(ByVal value As UILabelCheckboxes)
            m_oUILabelcheckbox = value
        End Set
    End Property
    Public Sub AddTextToControl()
        lbltitle.Text = m_strTitleText
        chba.Checked = m_bCheckValue(0)
        chbc.Checked = m_bCheckValue(1)
        chbo.Checked = m_bCheckValue(2)
        chbd.Checked = m_bCheckValue(3)
    End Sub

    Private Sub chba_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chba.CheckedChanged, chbc.CheckedChanged, chbo.CheckedChanged, chbd.CheckedChanged
        If sender Is chba Then
            m_bCheckValue(0) = chba.Checked
            If Not m_bCheckValue(0) Then
                SetCheckFalse(0)
            Else
                SetCheckTrue(0)
            End If
        ElseIf sender Is chbc Then
            m_bCheckValue(1) = chbc.Checked
            If Not m_bCheckValue(1) Then
                SetCheckFalse(1)
            Else
                SetCheckTrue(1)
            End If
        ElseIf sender Is chbo Then
            m_bCheckValue(2) = chbo.Checked
            If Not m_bCheckValue(2) Then
                SetCheckFalse(2)
            Else
                SetCheckTrue(2)
            End If
        ElseIf sender Is chbd Then
            m_bCheckValue(3) = chbd.Checked
            If Not m_bCheckValue(3) Then
                SetCheckFalse(3)
            Else
                SetCheckTrue(3)
            End If
        End If
    End Sub
    Private Sub SetCheckFalse(ByVal nNum As Integer)
        For Each oUt As UILabelCheckboxes In m_lstUiLabelCheckbox
            oUt.CheckValue(nNum) = False
            oUt.AddTextToControl()
            SetChildCheckFalse(nNum, oUt)
        Next
    End Sub
    Private Sub SetChildCheckFalse(ByVal nNum As Integer, ByVal oUT As UILabelCheckboxes)
        For Each oUtChilds As UILabelCheckboxes In oUT.UICheckboxNodes
            oUtChilds.CheckValue(nNum) = False
            oUtChilds.AddTextToControl()
            SetChildCheckFalse(nNum, oUtChilds)
        Next
    End Sub
    Private Sub SetCheckTrue(ByVal nNum As Integer)
        If Not UICheckBoxParentNode Is Nothing Then
            UICheckBoxParentNode.CheckValue(nNum) = True
            UICheckBoxParentNode.AddTextToControl()
        End If
    End Sub
    Private Sub SetChildCheckTrue(ByVal nNum As Integer, ByVal oUt As UILabelCheckboxes)
        If Not oUt.UICheckBoxParentNode Is Nothing Then
            oUt.UICheckBoxParentNode.CheckValue(nNum) = True
            oUt.UICheckBoxParentNode.AddTextToControl()
            SetChildCheckTrue(nNum, oUt.UICheckBoxParentNode)
        End If
    End Sub
    Private Sub lbltitle_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltitle.SizeChanged
        chba.Location = New System.Drawing.Point(lbltitle.Size.Width + 20, chba.Location.Y)
        chbc.Location = New System.Drawing.Point(chba.Location.X + chba.Size.Width, chbc.Location.Y)
        chbo.Location = New System.Drawing.Point(chbc.Location.X + chbo.Size.Width, chbo.Location.Y)
        chbd.Location = New System.Drawing.Point(chbo.Location.X + chbo.Size.Width, chbd.Location.Y)
    End Sub
End Class
