Imports System.Windows.Forms

Public Class UIDataGridViewTextBoxColumn
    Inherits DataGridViewTextBoxColumn
    Private m_bBoolStyle As Boolean
    Private m_oTrueValue As Object
    Private m_oFasleValue As Object
    Property BoolStyle() As Boolean
        Get
            BoolStyle = m_bBoolStyle
        End Get
        Set(ByVal Value As Boolean)
            m_bBoolStyle = Value
        End Set
    End Property
    Property TrueValue() As Object
        Get
            TrueValue = m_oTrueValue
        End Get
        Set(ByVal Value As Object)
            m_oTrueValue = Value
        End Set
    End Property
    Property FalseValue() As Object
        Get
            FalseValue = m_oFasleValue
        End Get
        Set(ByVal Value As Object)
            m_oFasleValue = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        m_bBoolStyle = False
        m_oTrueValue = True
        m_oFasleValue = False
    End Sub
End Class
