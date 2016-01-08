'/////////////////////////////////////////
'    名称:   XP Style Menu
'    作者:   DeityFox
'  E-Mail:   daniel_0571@163.com
'    修改:   2002.5.15
'    类名:   xpMenu
'    注释:   如果要转载本代码,请注明出处
'/////////////////////////////////////////

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Diagnostics

Namespace xpmenuitem  '命名名字空间
    Public Class xpMenu  '创建子类xpMenu,继承于MenuItem
        Inherits MenuItem

#Region "定义和初始化变量、常量"

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

#Region "重载MenuItem的构造函数 "


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

#Region "菜单项的menuitemicon属性"
        '添加新属性MenuItemIcon,主要是用来设置菜单项左边的图形
        Public Property MenuItemIcon() As Image
            Get
                Return icon
            End Get
            Set(ByVal Value As Image)
                icon = Value
            End Set
        End Property
#End Region

#Region "覆盖OnMeasureItem方法"
        '覆盖OnMeasureItem方法
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

#Region "覆盖OnDrawItem方法"
        '覆盖OnDrawItem方法
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

#Region "画菜单的各个功能方法,如画文字、图形、背景、分隔线等"

        '功能名称:       DrawCheckmark(画菜单选项)
        '参数说明: 
        'bounds          菜单项前面表示选中的小方块
        'selected        boolean型,表示是否选中
        Public Sub DrawCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean)
            ControlPaint.DrawMenuGlyph(g, New Rectangle(bounds.X + 3, bounds.Y + 4, 14, 14), MenuGlyph.Checkmark)
        End Sub

        '功能名称:       DrawIcon(画菜单项图形)
        '参数说明:
        'icon            菜单项前面的图形
        'enabled         菜单项是否被禁用
        'ischecked       是否被选中
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

        '功能名称:       DrawSeparator(画分隔线)
        Public Sub DrawSeparator(ByVal G As Graphics, ByVal Bounds As Rectangle)
            Dim y As Integer = Bounds.Y + Bounds.Height / 2
            G.DrawLine(New Pen(SystemColors.ControlDark), Bounds.X + SystemInformation.SmallIconSize.Width + 7, y, Bounds.X + Bounds.Width - 2, y)
        End Sub

        '功能名称:       DrawBackground(画菜单背景)
        '参数说明:
        'State           菜单项状态
        'TopLevel        是否为菜单标题,即顶层菜单
        'HasIcon         菜单项是否有图形
        Public Sub DrawBackground(ByVal G As Graphics, ByVal Bounds As Rectangle, ByVal State As DrawItemState, ByVal TopLevel As Boolean, ByVal HasIcon As Boolean, ByVal enabled As Boolean)
            Dim selected As Boolean = (State And DrawItemState.Selected) > 0
            If (selected Or (State And DrawItemState.HotLight) > 0) Then
                If TopLevel And selected Then
                    'draw toplevel(画顶层菜单条)
                    G.FillRectangle(New SolidBrush(ibgcolor), Bounds)
                    ControlPaint.DrawBorder3D(G, Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height, Border3DStyle.Flat, Border3DSide.Top Or Border3DSide.Left Or Border3DSide.Right)
                Else
                    If enabled Then                 '如果菜单可用
                        'draw menuitem,selected  or toplevel,hotlighted
                        G.FillRectangle(New SolidBrush(sbcolor), Bounds)
                        G.DrawRectangle(New Pen(sbbcolor), Bounds.X, Bounds.Y, Bounds.Width - 1, Bounds.Height - 1)
                    Else                            '菜单被禁用
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

        '功能名称:       DrawMenuText(画菜单项文字)
        '参数说明:
        'text            菜单项文字
        'shortcut        菜单项快捷方式
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
            '画菜单项文字
            g.DrawString(text, SystemInformation.MenuFont, brush, x, y, strFormat)
            strFormat.Alignment = StringAlignment.Far    '设置对齐方式为右对齐
            '画菜单项快捷方式
            g.DrawString(shortcut, SystemInformation.MenuFont, brush, bounds.Left + 160, y, strFormat)
            '释放资源
            strFormat.Dispose()
            brush.Dispose()
        End Sub
#End Region
    End Class
End Namespace

