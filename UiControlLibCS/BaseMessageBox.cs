using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using UiControlLibCS.Properties;

namespace ZhiFa.Base.MessageControl
{
    public partial class BaseMessageBox : Office2007Form
    {
        static BaseMessageBox newMessageBox;
        static Image iconExclamation = Resources.Exclamation;
        static Image iconInformation = Resources.information;
        static Image iconQuestion = Resources.question;
        public static Control parentControl;

        public Timer msgTimer;
        static DialogResult result;
        int disposeFormTimer;

        public BaseMessageBox()
        {
            InitializeComponent();
            result = DialogResult.Cancel;
        }

        private void CustomerMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (msgTimer != null)
            {
                msgTimer.Stop();
                msgTimer.Dispose();
            }
            // Mod hyx 2014-11-20  Start 尽量避免闪烁
            //if (parentControl != null && !parentControl.Enabled)
            //    parentControl.Enabled = true;
            SP1(true, parentControl);
            // Mod hyx 2014-11-20  End 尽量避免闪烁
            newMessageBox.Dispose();
        }

        private void BaseMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        #region 初始化
        public void Init(MessageBoxIcon icon, string title, string message, int timer, string buttonOkText, string buttonCancelText)
        {
            if (!string.IsNullOrEmpty(buttonOkText))
                btnOK.Text = buttonOkText;
            if (!string.IsNullOrEmpty(buttonCancelText))
                btnCancel.Text = buttonCancelText;
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    break;
                case MessageBoxIcon.Information:
                    if (timer > 0)
                    {
                        disposeFormTimer = timer;
                        msgTimer = new Timer();
                        msgTimer.Enabled = true;
                        msgTimer.Interval = 1000;
                        msgTimer.Tick += timer_tick;
                        msgTimer.Start();
                        lblTimer.Text = disposeFormTimer.ToString();
                    }
                    pictureBox1.Image = iconInformation;
                    btn_close.Visible = true;
                    btnCancel.Visible = false;
                    btnOK.Visible = false;
                    btn_close.Focus();
                    break;
                case MessageBoxIcon.None:
                    break;
                case MessageBoxIcon.Question:
                    if (timer > 0)
                    {
                        disposeFormTimer = timer;
                        msgTimer = new Timer();
                        msgTimer.Enabled = true;
                        msgTimer.Interval = 1000;
                        msgTimer.Tick += timer_tick;
                        msgTimer.Start();
                        lblTimer.Text = disposeFormTimer.ToString();
                    }
                    pictureBox1.Image = iconQuestion;
                    btn_close.Visible = false;
                    btnCancel.Visible = true;
                    btnOK.Visible = true;
                    btnOK.Focus();
                    break;
                case MessageBoxIcon.Warning:
                    if (timer > 0)
                    {
                        disposeFormTimer = timer;
                        msgTimer = new Timer();
                        msgTimer.Enabled = true;
                        msgTimer.Interval = 1000;
                        msgTimer.Tick += timer_tick;
                        msgTimer.Start();
                        lblTimer.Text = disposeFormTimer.ToString();
                    }
                    pictureBox1.Image = iconExclamation;
                    btn_close.Visible = true;
                    btnCancel.Visible = false;
                    btnOK.Visible = false;
                    btn_close.Focus();
                    break;
                default:
                    break;
            }
            Text = title;
            lblMessage.Text = message;
        }

        public void Init(MessageBoxIcon icon, string title, string message, double timer, string buttonOkText, string buttonCancelText)
        {
            if (!string.IsNullOrEmpty(buttonOkText))
                btnOK.Text = buttonOkText;
            if (!string.IsNullOrEmpty(buttonCancelText))
                btnCancel.Text = buttonCancelText;
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    break;
                case MessageBoxIcon.Information:
                    if (timer > 0)
                    {
                        disposeFormTimer = int.Parse(Math.Floor(timer).ToString());
                        msgTimer = new Timer();
                        msgTimer.Enabled = true;
                        msgTimer.Interval = 1000;
                        msgTimer.Tick += timer_tick;
                        msgTimer.Start();
                        lblTimer.Text = disposeFormTimer.ToString();
                    }
                    pictureBox1.Image = iconInformation;
                    btn_close.Visible = true;
                    btnCancel.Visible = false;
                    btnOK.Visible = false;
                    btn_close.Focus();
                    break;
                case MessageBoxIcon.None:
                    break;
                case MessageBoxIcon.Question:
                    if (timer > 0)
                    {
                        disposeFormTimer = int.Parse(Math.Floor(timer).ToString());
                        msgTimer = new Timer();
                        msgTimer.Enabled = true;
                        msgTimer.Interval = 1000;
                        msgTimer.Tick += timer_tick;
                        msgTimer.Start();
                        lblTimer.Text = disposeFormTimer.ToString();
                    }
                    pictureBox1.Image = iconQuestion;
                    btn_close.Visible = false;
                    btnCancel.Visible = true;
                    btnOK.Visible = true;
                    btnOK.Focus();
                    break;
                case MessageBoxIcon.Warning:
                    if (timer > 0)
                    {
                        disposeFormTimer = int.Parse(Math.Floor(timer).ToString());
                        msgTimer = new Timer();
                        msgTimer.Enabled = true;
                        msgTimer.Interval = 1000;
                        msgTimer.Tick += timer_tick;
                        msgTimer.Start();
                        lblTimer.Text = disposeFormTimer.ToString();
                    }
                    pictureBox1.Image = iconExclamation;
                    btn_close.Visible = true;
                    btnCancel.Visible = false;
                    btnOK.Visible = false;
                    btn_close.Focus();
                    break;
                default:
                    break;
            }
            Text = title;
            lblMessage.Text = message;
        }
        #endregion

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowCustomerMessage(MessageBoxIcon icon, string title, string message)
        {
            ////newMessageBox = new BaseMessageBox();
            ////newMessageBox.Init(icon, title, message, 0);
            ////newMessageBox.ShowDialog();
            ////return result;
            return ShowCustomerMessage(icon, title, message, null);
        }

        /// <summary>
        /// 显示消息框，带遮蔽层
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowCustomerMessage(MessageBoxIcon icon, string title, string message, Control control)
        {
            ////#region 显示遮蔽层
            //////panel = new OpaqueLayer();
            //////control.Controls.Add(panel);
            //////panel.Dock = DockStyle.Fill;
            //////panel.BringToFront();
            //////panel.Enabled = true;
            //////panel.Visible = true;
            ////#endregion

            ////#region 屏蔽父窗体
            ////control.Enabled = false;
            ////parentControl = control;
            ////#endregion

            ////newMessageBox = new BaseMessageBox();
            ////newMessageBox.Init(icon, title, message, 0);
            ////newMessageBox.ShowDialog();
            ////return result;

            return ShowCustomerMessage(icon, title, message, 0, control);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowCustomerMessage(MessageBoxIcon icon, string title, string message, int timer)
        {
            ////newMessageBox = new BaseMessageBox();
            ////newMessageBox.Init(icon, title, message, timer);
            ////newMessageBox.ShowDialog();
            ////return result;

            return ShowCustomerMessage(icon, title, message, timer, null);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowCustomerMessage(MessageBoxIcon icon, string title, string message, double timer)
        {
            ////newMessageBox = new BaseMessageBox();
            ////newMessageBox.Init(icon, title, message, timer);
            ////newMessageBox.ShowDialog();
            ////return result;

            return ShowCustomerMessage(icon, title, message, timer, null);
        }

        /// <summary>
        /// 显示消息框，带遮蔽层
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowCustomerMessage(MessageBoxIcon icon, string title, string message, int timer, Control control)
        {
            #region 显示遮蔽层
            //panel = new OpaqueLayer();
            //control.Controls.Add(panel);
            //panel.Dock = DockStyle.Fill;
            //panel.BringToFront();
            //panel.Enabled = true;
            //panel.Visible = true;
            #endregion

            #region 屏蔽父窗体
            // Mod hyx 2014-11-20  Start 尽量避免闪烁
            // control.Enabled = false;
            SP1(false, control);
            // Mod hyx 2014-11-20  End 尽量避免闪烁
            parentControl = control;
            #endregion

            newMessageBox = new BaseMessageBox();
            newMessageBox.Init(icon, title, message, timer, null, null);
            newMessageBox.ShowDialog();
            return result;
        }

        public static DialogResult ShowCustomerMessage(MessageBoxIcon icon, string title, string message, int timer, Control control, string buttonOkText, string buttonCancelText)
        {
            #region 显示遮蔽层
            //panel = new OpaqueLayer();
            //control.Controls.Add(panel);
            //panel.Dock = DockStyle.Fill;
            //panel.BringToFront();
            //panel.Enabled = true;
            //panel.Visible = true;
            #endregion

            #region 屏蔽父窗体
            // Mod hyx 2014-11-20  Start 尽量避免闪烁
            // control.Enabled = false;
            SP1(false, control);
            // Mod hyx 2014-11-20  End 尽量避免闪烁
            parentControl = control;
            #endregion

            newMessageBox = new BaseMessageBox();
            newMessageBox.Init(icon, title, message, timer, buttonOkText, buttonCancelText);
            newMessageBox.ShowDialog();
            return result;
        }

        /// <summary>
        /// 显示消息框，带遮蔽层
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowCustomerMessage(MessageBoxIcon icon, string title, string message, double timer, Control control)
        {
            #region 显示遮蔽层
            //panel = new OpaqueLayer();
            //control.Controls.Add(panel);
            //panel.Dock = DockStyle.Fill;
            //panel.BringToFront();
            //panel.Enabled = true;
            //panel.Visible = true;
            #endregion

            #region 屏蔽父窗体
            // Mod hyx 2014-11-20  Start 尽量避免闪烁
            // control.Enabled = false;
            SP1(false, control);
            // Mod hyx 2014-11-20  End 尽量避免闪烁
            parentControl = control;
            #endregion

            newMessageBox = new BaseMessageBox();
            newMessageBox.Init(icon, title, message, timer, null, null);
            newMessageBox.ShowDialog();
            return result;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            }
            else
            {
                newMessageBox.msgTimer.Stop();
                newMessageBox.msgTimer.Dispose();
                newMessageBox.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (msgTimer != null)
            {
                msgTimer.Stop();
                msgTimer.Dispose();
            }
            result = DialogResult.Yes;
            newMessageBox.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (msgTimer != null)
            {
                msgTimer.Stop();
                msgTimer.Dispose();
            }
            result = DialogResult.No;
            newMessageBox.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (msgTimer != null)
            {
                msgTimer.Stop();
                msgTimer.Dispose();
            }
            result = DialogResult.OK;
            newMessageBox.Close();
        }

        private static void SP1(bool enabled, Control control)
        {
            return;
            if (control == null)
                return;
            // 尽量避免闪烁
            Application.DoEvents();
            control.SuspendLayout();
            control.Visible = false;
            control.Enabled = enabled;
            control.ResumeLayout();
            control.Visible = true;


            ////this.DoubleBuffered = true;
            ////this.SetStyle(ControlStyles.UserPaint, true);
            ////this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            ////this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲
        }
    }
}
