'/////////////////////////////////////////
'    ����:   XP Style Menu
'    ����:   DeityFox
'  E-Mail:   daniel_0571@163.com
'    �޸�:   2002.5.15
'    ����:   xpMenu
'    ע��:   ���Ҫת�ر�����,��ע������
'/////////////////////////////////////////

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Diagnostics

Namespace xpmenuitem  '�������ֿռ�
    Public Class xpMenu  '��������xpMenu,�̳���MenuItem
        Inherits MenuItem

#Region "����ͳ�ʼ������������"

        Const TEXTSTART = 25
        Private icon As Image = Nothing
        Private shortcuttext As String = ""
        Dim itemHeight As Integer
        Dim bgcolor As Color = Color.FromArgb(70, 70, 90)
        Dim ibgcolor As Color = Color.FromArgb(50, 50, 70)
        Dim sbcolor As Color = Color.FromArgb(130, 140, 150)
        Dim sbbcolor As Color = Color.FromArgb(0, 0, 128)
        Dim ftcolor As Color = Color.FromArgb(235, 245, 255)
        Dim encolor As Color = Color.FromArgb(200, 200, 200)
#End Region

#Region "����MenuItem�Ĺ��캯�� "


        Public Sub New()
            MyBase.New()
            Me.OwnerDraw = True

        End Sub

        Public Sub New(ByVal Name As String)
            MyBase.New(Name)
            Me.OwnerDraw = True

        End Sub
        Public Sub New(ByVal Name As String, ByVal EventHandler As System.EventHandler)
            MyBase.New(Name, EventHandler)
            Me.OwnerDraw = True

        End Sub
        Public Sub New(ByVal name As String, ByVal items() As MenuItem)
            MyBase.New(name, items)
            Me.OwnerDraw = True
        End Sub
        Public Sub New(ByVal Name As String, ByVal EventHandler As System.EventHandler, ByVal Shortcut As System.Windows.Forms.Shortcut)
            MyBase.New(Name, EventHandler, Shortcut)
            Me.OwnerDraw = True
        End Sub
        Public Sub New(ByVal Name As String, ByVal img As Image)
            MyBase.New(Name)
            Me.OwnerDraw = True
            icon = img
        End Sub
        Public Sub New(ByVal Name As String, ByVal EventHandler As System.EventHandler, ByVal img As Image)
            MyBase.New(Name, EventHandler)
            Me.OwnerDraw = True
            icon = img
        End Sub
        Public Sub New(ByVal Name As String, ByVal EventHandler As System.EventHandler, ByVal Shortcut As System.Windows.Forms.Shortcut, ByVal img As Image)
            MyBase.New(Name, EventHandler, Shortcut)
            Me.OwnerDraw = True
            icon = img
        End Sub
#End Region

#Region "�˵����menuitemicon����"
        '���������MenuItemIcon,��Ҫ���������ò˵�����ߵ�ͼ��
        Public Property MenuItemIcon() As Image
            Get
                Return icon
            End Get
            Set(ByVal Value As Image)
                icon = Value
            End Set
        End Property
#End Region

#Region "����OnMeasureItem����"
        '����OnMeasureItem����
        Protected Overrides Sub onmeasureitem(ByVal e As System.Windows.Forms.MeasureItemEventArgs)
            MyBase.OnMeasureItem(e)
            If Shortcut <> Shortcut.None Then
                Dim text As String = ""
                Dim key As Integer = System.Convert.ToInt32(Shortcut)
                Dim ch As Integer = key And &HFF
                If (System.Convert.ToInt32(Keys.Control) And key) > 0 Then
                    text += "Ctrl+"
                End If
                If (System.Convert.ToInt32(Keys.Shift) And key) > 0 Then
                    text += "Shift+"
                End If
                If (System.Convert.ToInt32(Keys.Alt) And key) > 0 Then
                    text += "Alt+"
                End If
                If (ch >= System.Convert.ToInt32(Shortcut.F1)) And (ch <= System.Convert.ToInt32(Shortcut.F12)) Then
                    text += "F" + System.Convert.ToChar((ch - System.Convert.ToInt32(Shortcut.F1) + 1))
                Else
                    If Shortcut = Shortcut.Del Then
                        text += "Del"
                    Else
                        text += System.Convert.ToChar(ch)
                    End If
                End If
                shortcuttext = text
            End If

            Dim topLevel As Boolean
            Dim tempshortcuttext As String = shortcuttext
            If Parent Is Parent.GetMainMenu Then
                topLevel = True
            End If
            If topLevel Then
                tempshortcuttext = ""
            End If

            Dim textwidth As Integer = System.Convert.ToInt32(e.Graphics.MeasureString(Text + tempshortcuttext, SystemInformation.MenuFont).Width)
            Dim extraheight As Integer = 4
            e.ItemHeight = SystemInformation.MenuHeight + extraheight
            If topLevel Then
                e.ItemWidth = textwidth - 5
            Else
                e.ItemWidth = Math.Max(160, textwidth + 50)
            End If
            If Text = "-" Then
                e.ItemHeight = 5
                e.ItemWidth = 4
            End If
            itemHeight = e.ItemHeight

        End Sub
#End Region

#Region "����OnDrawItem����"
        '����OnDrawItem����
        Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
            MyBase.OnDrawItem(e)
            Dim g As Graphics = e.Graphics
            Dim bounds As Rectangle = e.Bounds
            Dim selected As Boolean = (e.State And DrawItemState.Selected) > 0
            Dim toplevel As Boolean = (Parent Is Parent.GetMainMenu)
            Dim hasicon As Boolean = (Not (icon Is Nothing))
            Dim ena As Boolean = Enabled
            DrawBackground(g, bounds, e.State, toplevel, hasicon, ena)
            If hasicon Then
                DrawIcon(g, icon, bounds, selected, Enabled, Checked)
            Else
                If Checked Then
                    DrawCheckmark(g, bounds, selected)
                End If

            End If
            If Text = "-" Then
                DrawSeparator(g, bounds)
            Else
                DrawMenuText(g, bounds, Text, shortcuttext, ena, toplevel, e.State)
            End If
        End Sub
#End Region

#Region "���˵��ĸ������ܷ���,�续���֡�ͼ�Ρ��������ָ��ߵ�"

        '��������:       DrawCheckmark(���˵�ѡ��)
        '����˵��: 
        'bounds          �˵���ǰ���ʾѡ�е�С����
        'selected        boolean��,��ʾ�Ƿ�ѡ��
        Public Sub DrawCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean)
            ControlPaint.DrawMenuGlyph(g, New Rectangle(bounds.X + 3, bounds.Y + 4, 14, 14), MenuGlyph.Checkmark)
        End Sub

        '��������:       DrawIcon(���˵���ͼ��)
        '����˵��:
        'icon            �˵���ǰ���ͼ��
        'enabled         �˵����Ƿ񱻽���
        'ischecked       �Ƿ�ѡ��
        Public Sub DrawIcon(ByVal g As Graphics, ByVal icon As Image, ByVal bounds As Rectangle, ByVal selected As Boolean, ByVal enabled As Boolean, ByVal ischecked As Boolean)
            If enabled Then
                If selected Then
                    ControlPaint.DrawImageDisabled(g, icon, bounds.Left + 2, bounds.Top + 3, Color.Black)
                    g.DrawImage(icon, bounds.Left + 1, bounds.Top + 3)
                Else
                    g.DrawImage(icon, bounds.Left + 2, bounds.Top + 4)
                End If
            Else
                ControlPaint.DrawImageDisabled(g, icon, bounds.Left + 2, bounds.Top + 4, SystemColors.HighlightText)
            End If
        End Sub

        '��������:       DrawSeparator(���ָ���)
        Public Sub DrawSeparator(ByVal G As Graphics, ByVal Bounds As Rectangle)
            Dim y As Integer = Bounds.Y + Bounds.Height / 2
            G.DrawLine(New Pen(SystemColors.ControlDark), Bounds.X + SystemInformation.SmallIconSize.Width + 7, y, Bounds.X + Bounds.Width - 2, y)
        End Sub

        '��������:       DrawBackground(���˵�����)
        '����˵��:
        'State           �˵���״̬
        'TopLevel        �Ƿ�Ϊ�˵�����,������˵�
        'HasIcon         �˵����Ƿ���ͼ��
        Public Sub DrawBackground(ByVal G As Graphics, ByVal Bounds As Rectangle, ByVal State As DrawItemState, ByVal TopLevel As Boolean, ByVal HasIcon As Boolean, ByVal enabled As Boolean)
            Dim selected As Boolean = (State And DrawItemState.Selected) > 0
            If (selected Or (State And DrawItemState.HotLight) > 0) Then
                If TopLevel And selected Then
                    'draw toplevel(������˵���)
                    G.FillRectangle(New SolidBrush(ibgcolor), Bounds)
                    ControlPaint.DrawBorder3D(G, Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height, Border3DStyle.Flat, Border3DSide.Top Or Border3DSide.Left Or Border3DSide.Right)
                Else
                    If enabled Then                 '����˵�����
                        'draw menuitem,selected  or toplevel,hotlighted
                        G.FillRectangle(New SolidBrush(sbcolor), Bounds)
                        G.DrawRectangle(New Pen(sbbcolor), Bounds.X, Bounds.Y, Bounds.Width - 1, Bounds.Height - 1)
                    Else                            '�˵�������
                        G.FillRectangle(New SolidBrush(ibgcolor), Bounds)
                        Bounds.X += SystemInformation.SmallIconSize.Width + 5
                        Bounds.Width -= SystemInformation.SmallIconSize.Width + 5
                        G.FillRectangle(New SolidBrush(bgcolor), Bounds)
                    End If
                End If
            Else
                If Not TopLevel Then
                    'draw menuitem,unselected
                    G.FillRectangle(New SolidBrush(ibgcolor), Bounds)
                    Bounds.X += SystemInformation.SmallIconSize.Width + 5
                    Bounds.Width -= SystemInformation.SmallIconSize.Width + 5
                    G.FillRectangle(New SolidBrush(bgcolor), Bounds)
                Else
                    'draw toplevel,unselected menutiem
                    G.FillRectangle(SystemBrushes.Menu, Bounds)
                End If
            End If
        End Sub

        '��������:       DrawMenuText(���˵�������)
        '����˵��:
        'text            �˵�������
        'shortcut        �˵����ݷ�ʽ
        Public Sub DrawMenuText(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal text As String, ByVal shortcut As String, ByVal enabled As Boolean, ByVal toplevel As Boolean, ByVal state As DrawItemState)
            Dim strFormat As StringFormat = New StringFormat()
            If (state And DrawItemState.NoAccelerator) > 0 Then
                strFormat.HotkeyPrefix = HotkeyPrefix.Hide
            Else
                strFormat.HotkeyPrefix = HotkeyPrefix.Show
            End If

            Dim textwidth As Integer = System.Convert.ToInt32(g.MeasureString(text, SystemInformation.MenuFont).Width)
            Dim x As Integer
            Dim y As Integer = bounds.Top + (bounds.Height - SystemInformation.MenuFont.Height) / 2
            If toplevel Then
                x = bounds.Left + (bounds.Width - textwidth) / 2
            Else
                x = bounds.Left + TEXTSTART
            End If
            Dim brush As Brush = Nothing
            If Not enabled Then
                brush = New SolidBrush(encolor)
            Else
                brush = New SolidBrush(ftcolor)
            End If
            '���˵�������
            g.DrawString(text, SystemInformation.MenuFont, brush, x, y, strFormat)
            strFormat.Alignment = StringAlignment.Far    '���ö��뷽ʽΪ�Ҷ���
            '���˵����ݷ�ʽ
            g.DrawString(shortcut, SystemInformation.MenuFont, brush, bounds.Left + 160, y, strFormat)
            '�ͷ���Դ
            strFormat.Dispose()
            brush.Dispose()
        End Sub
#End Region
    End Class
End Namespace

