using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using System.Diagnostics;
using UiControlLibCS;

namespace Doris
{
    public partial class frmMainBase : DevComponents.DotNetBar.Office2007Form, IBaseForm
    {
        protected DevComponents.DotNetBar.Bar baseMenuBar;
        protected Stimulsoft.Report.StiReport baseReport;

        #region private

        private bool canSaveData = false;//当前用户是否拥有当前功能模块的保存权限
        private bool isHaveSaveFunc = true;//当前模块是否拥有保存功能
        private FormState formState = FormState.New;
        private bool isNeedPatient = true;
        private bool enabled = true;

        #endregion

        #region public

        /// <summary>
        /// 当前用户是否拥有当前功能模块的保存权限
        /// </summary>
        [Description("当前用户是否拥有当前功能模块的保存权限")]
        public bool CanSaveData
        {
            get { return canSaveData; }
            set { canSaveData = value; }
        }

        /// <summary>
        /// 当前模块是否拥有保存功能
        /// </summary>
        [Description("当前模块是否拥有保存功能")]
        public bool IsHaveSaveFunc
        {
            get { return isHaveSaveFunc; }
            set { isHaveSaveFunc = value; }
        }

        /// <summary>
        /// 页面状态，首次加载状态为New，关闭时如状态为Modify则判断保存
        /// </summary>
        [Description("页面状态，首次加载状态为New，关闭时如状态为Modify则判断保存")]
        public FormState FormState
        {
            get { return formState; }
            set { formState = value; }
        }

        /// <summary>
        /// 打开该功能模块是否需要首先选中一个病人
        /// </summary>
        [Description("打开该功能模块是否需要首先选中一个病人")]
        public bool IsNeedPatient
        {
            get { return isNeedPatient; }
            set { isNeedPatient = value; }
        }

        #endregion

        #region 基类属性重写

        /// <summary>
        /// 重写的Enable属性，容器Enable属性时时，对容器内的非容器类型控件的Enable属性进行赋值
        /// </summary>
        [Description("重写的Enable属性，容器Enable属性时时，对容器内的非容器类型控件的Enable属性进行赋值")]
        public new bool Enabled
        {
            get { return this.enabled; }
            set
            {
                enabled = value;

                SetEnable(value, this);
            }
        }

        #endregion


        public frmMainBase()
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmMainBase_Shown);
            this.FormClosing += new FormClosingEventHandler(ClosingForm);
            this.cmdMenu.Executed += new System.EventHandler(this.cmdMenu_Executed);
        }

        /// <summary>
        /// 初始化菜单项
        /// </summary>
        public virtual void InitToolBar()
        {
            InitToolBar(CommonObjects.CurrentMenu.MenuCode);
        }

        public virtual void InitToolBar(string menuCode)
        {
            if (baseMenuBar == null) return;

            baseMenuBar.Items.Clear();

            if (CommonObjects.CurrentMenu != null)
            {
                List<SysMenu> listMenus = CommonObjects.MenuList.FindAll(
                        p => p.ParentCode == menuCode)
                        .OrderByDescending(p => p.SortNum
                    ).ToList();

                foreach (SysMenu menu in listMenus)
                {
                    ButtonItem btnItem = new ButtonItem();
                    btnItem.Name = menu.MenuCode;
                    btnItem.Text = menu.MenuName;
                    btnItem.Image = IOHelper.LoadIcon(menu.Icon); ;
                    btnItem.ImageFixedSize = new System.Drawing.Size(24, 24);

                    btnItem.Tag = menu;

                    if (menu.MenuLabel == SysConstants.MENULABELSAVE)
                        canSaveData = true;

                    btnItem.ImagePosition = eImagePosition.Top;
                    btnItem.ButtonStyle = eButtonStyle.ImageAndText;
                    btnItem.AutoCollapseOnClick = true;
                    btnItem.Command = cmdMenu;
                    btnItem.CommandParameter = menu.MenuLabel;

                    baseMenuBar.Items.Insert(0, btnItem);
                }
                baseMenuBar.DockedBorderStyle = eBorderType.None;
            }
        }

        /// <summary>
        /// 加载页面之前，用于处理页面控件数据源的数据绑定
        /// </summary>
        public virtual void BindingData() { }

        /// <summary>
        /// 绑定控件响应事件
        /// </summary>
        public virtual void BingingEvents() { }

        /// <summary>
        /// 加载页面信息
        /// </summary>
        public virtual void LoadFormData() { }

        /// <summary>
        /// 保存更改
        /// </summary>
        public virtual void SaveChanges() { }

        /// <summary>
        /// 为Form内的非Label类型控件绑定编辑事件，当内容发生变化时，FormState修改为Modify
        /// </summary>
        public virtual void BindingModifyEvents()
        {
            this.BindingModifyEvents(this);
        }

        /// <summary>
        /// 为Form内的非Label类型控件绑定编辑事件，当内容发生变化时，FormState修改为Modify
        /// </summary>
        /// <param name="container">装载控件的容器</param>
        public virtual void BindingModifyEvents(Control container)
        {
            foreach (Control ctl in container.Controls)
            {
                if (ctl.GetType().Equals(typeof(Label)) || ctl.GetType().Equals(typeof(LabelX))) continue;

                if (ctl.Controls.Count > 0)
                {
                    BindingModifyEvents(ctl);
                    continue;
                }

                if (ctl is SuperGridControl)
                {
                    ((SuperGridControl)ctl).CellValueChanged += delegate(object sender, GridCellValueChangedEventArgs e)
                    {
                        this.formState = FormState.Modify;
                    };
                }
                else if (ctl is DataGridView)
                {
                    ((DataGridView)ctl).CellValueChanged += delegate(object sender, DataGridViewCellEventArgs e)
                    {
                        this.FormState = FormState.Modify;
                    };
                }
                else if (ctl.GetType().Equals(typeof(CheckBoxX)))
                {
                    (ctl as CheckBoxX).CheckedChanged += delegate(object sender, EventArgs e)
                    {
                        this.formState = FormState.Modify;
                    };
                }
                else
                {
                    ctl.TextChanged += delegate(object sender, EventArgs e) { this.formState = FormState.Modify; };
                    String flag = System.Configuration.ConfigurationManager.AppSettings["IsMobileNursing"];
                    if (!String.IsNullOrEmpty(flag) && flag.Equals("1"))
                    {
                        String file = System.Configuration.ConfigurationManager.AppSettings["MobileKeyBoard"];
                        ctl.MouseClick += delegate(object sender, MouseEventArgs e)
                        {
                            if (File.Exists(file))
                                Process.Start(file);
                        };
                    }
                }
            }
        }


        /// <summary>
        /// 重写该方法，处理菜单栏的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void cmdMenu_Executed(object sender, EventArgs e)
        {
            ButtonItem btn = sender as ButtonItem;
            SysMenu menu = btn.Tag as SysMenu;

            if (!string.IsNullOrEmpty(menu.RunUrl))
            {
                ReflectionHelper.Invoke(this, menu.RunUrl);
                // Add hyx 2014-08-18 Start
                // 成功保存数据后 强制修改窗体状态
                if (menu.RunUrl == "SaveChanges")
                {
                    this.FormState = FormState.NoChanged;
                }
                this.Focus();
            }
        }

        /// <summary>
        /// 不保存页面信息，在关闭窗体前的业务处理
        /// </summary>
        protected virtual void PreClose() { }

        /// <summary>
        /// 窗体关闭之前的逻辑处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void ClosingForm(object sender, FormClosingEventArgs e)
        {
            ClearEditMode();
            if (this.formState == FormState.Modify && canSaveData)
            {
                if (ErrorControl.ShowQuestion("页面信息已改变，是否保存？") == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveChanges();
                }
            }
            else
            {
                PreClose();
            }
        }


        void frmMainBase_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode || !this.IsHandleCreated)
                return;

            SetEnableState();

            if (baseReport != null)
                baseReport.Printed += new EventHandler(baseReport_Printed);
        }

        public virtual void baseReport_Printed(object sender, EventArgs e)
        {

        }

        private void SetEnableState()
        {
            if (!this.CanSaveData && this.IsHaveSaveFunc)
            {
                this.Enabled = false;
            }
            else
            {
                if ((CommonObjects.CurrentMenu.ShowBanner == 1) && (!CommonObjects.LoginUser.IsSuperEdit) &&
                (CommonObjects.OperInfo != null && CommonObjects.OperInfo.IsCommitted == "1"))
                {
                    this.Enabled = false;
                }
                else
                {
                    this.Enabled = true;
                }
            }
        }


        private void SetEnable(bool EnabledValue, Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl.HasChildren && ctl.GetType() != typeof(SuperGridControl))
                {
                    ctl.Enabled = true;
                    SetEnable(EnabledValue, ctl);

                    if (ctl.GetType().Name == "UCAnestheticInfo")
                    {
                        ctl.GetType().GetMethod("SetEnable").Invoke(ctl, new object[] { false });
                    }

                    continue;
                }
                ctl.Enabled = EnabledValue;
            }
        }

        #region 消息处理

        /// <summary>
        /// 重写该方法主要用来处理用户消息，响应病人切换事件
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref Message m)
        {
            if (CommonObjects.IsDesignMode)
            {
                base.DefWndProc(ref m);
                return;
            }
            switch (m.Msg)
            {
                case SysConstants.MYMESSAGE:

                    ClearEditMode();

                    if (this.formState == FormState.Modify && canSaveData)
                    {
                        if (ErrorControl.ShowQuestion("页面信息已改变，是否保存？") == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveChanges();
                            this.formState = FormState.NoChanged;
                        }
                    }
                    LoadFormData();

                    SetEnableState();

                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// 取消当前页面控件的编辑状态，使当前活动组件失去焦点
        /// </summary>
        private void ClearEditMode()
        {
            if (this.ActiveControl != null)
                this.SelectNextControl(this.ActiveControl, true, false, true, true);
        }

        #endregion

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        #region 报表

        /// <summary>
        /// 向报表中写入数据
        /// </summary>
        public virtual bool WriteReportData()
        {
            return true;
        }

        public virtual void PreView()
        {
            if (WriteReportData())
                baseReport.Show(frmMainFrame.Instance, true);
        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual void Print()
        {
            if (WriteReportData())
                baseReport.Print();
        }

        /// <summary>
        /// 导出PDF文件
        /// </summary>
        public virtual void ExportPdf()
        {
            if (!WriteReportData()) return;

            baseReport.Render();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf文件(*.pdf)|*.pdf";
            sfd.RestoreDirectory = true;

            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = sfd.OpenFile();

                    baseReport.ExportDocument(StiExportFormat.Pdf, stream);

                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Default))
                    {
                        writer.Write(stream.ToString());
                    }

                    stream.Close();

                    ErrorControl.ShowInformation(this, "导出成功!");
                }
            }
            catch (Exception ex)
            {
                ErrorControl.ShowInformation("导出失败!");

                throw ex;
            }
        }

        /// <summary>
        /// 导出Excel文件
        /// </summary>
        public virtual void ExportExcel()
        {
            if (!WriteReportData()) return;
            baseReport.Render();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            sfd.RestoreDirectory = true;

            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = sfd.OpenFile();

                    baseReport.ExportDocument(StiExportFormat.Excel, stream);

                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Default))
                    {
                        writer.Write(stream.ToString());
                    }

                    stream.Close();

                    ErrorControl.ShowInformation("导出成功!");
                }
            }
            catch (Exception ex)
            {
                ErrorControl.ShowInformation("导出失败!");

                throw ex;
            }
        }
        #endregion

    }
}
