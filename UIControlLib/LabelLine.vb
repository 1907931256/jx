'********************************************************************
'	Title:			LabelLine 
'	Copyright:		(C) 2009 VICO Software, Ltd
'	Author:			cdx
'	Create Date:	2009-4-29
'	Description:    
'*********************************************************************
Imports System.Windows.Forms

Public Class LabelLine
    Inherits System.Windows.Forms.Label

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.BorderStyle = BorderStyle.Fixed3D
        Me.BackColor = System.Drawing.Color.Transparent
    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Private Sub LabelLine_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Height = 2
        Me.BorderStyle = BorderStyle.Fixed3D
        Me.BackColor = System.Drawing.Color.Transparent
    End Sub
End Class
