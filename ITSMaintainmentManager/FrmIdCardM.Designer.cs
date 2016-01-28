namespace ITSMaintainmentManager
{
    partial class FrmIdCardM
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFunc = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnUpdateCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdateConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.dgv = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tbCardNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.pnlFunc.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFunc
            // 
            this.pnlFunc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.pnlFunc.Controls.Add(this.btnClose);
            this.pnlFunc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFunc.Location = new System.Drawing.Point(0, 0);
            this.pnlFunc.Name = "pnlFunc";
            this.pnlFunc.Size = new System.Drawing.Size(1024, 32);
            this.pnlFunc.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.Location = new System.Drawing.Point(5, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 22);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.gbInfo);
            this.pnlInfo.Controls.Add(this.pnlAction);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 32);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1024, 73);
            this.pnlInfo.TabIndex = 15;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.tbCardNo);
            this.gbInfo.Controls.Add(this.lblCardNo);
            this.gbInfo.Controls.Add(this.tbCode);
            this.gbInfo.Controls.Add(this.lblCode);
            this.gbInfo.Controls.Add(this.tbName);
            this.gbInfo.Controls.Add(this.cmbType);
            this.gbInfo.Controls.Add(this.lblName);
            this.gbInfo.Controls.Add(this.lblType);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInfo.Font = new System.Drawing.Font("SimSun", 9F);
            this.gbInfo.Location = new System.Drawing.Point(0, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(958, 71);
            this.gbInfo.TabIndex = 1;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "信息";
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbCode.Location = new System.Drawing.Point(257, 45);
            this.tbCode.Margin = new System.Windows.Forms.Padding(2);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(124, 21);
            this.tbCode.TabIndex = 40;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(200, 49);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(53, 12);
            this.lblCode.TabIndex = 39;
            this.lblCode.Text = "ID卡编码";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbName.Location = new System.Drawing.Point(62, 45);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(124, 21);
            this.tbName.TabIndex = 36;
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(62, 16);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(124, 20);
            this.cmbType.TabIndex = 35;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 49);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 30;
            this.lblName.Text = "ID卡名称";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 20);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 12);
            this.lblType.TabIndex = 29;
            this.lblType.Text = "ID卡类别";
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.btnUpdateCancel);
            this.pnlAction.Controls.Add(this.btnDel);
            this.pnlAction.Controls.Add(this.btnUpdateConfirm);
            this.pnlAction.Controls.Add(this.btnUpdate);
            this.pnlAction.Controls.Add(this.btnAdd);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAction.Location = new System.Drawing.Point(958, 0);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(64, 71);
            this.pnlAction.TabIndex = 0;
            // 
            // btnUpdateCancel
            // 
            this.btnUpdateCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdateCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnUpdateCancel.Location = new System.Drawing.Point(3, 46);
            this.btnUpdateCancel.Name = "btnUpdateCancel";
            this.btnUpdateCancel.Size = new System.Drawing.Size(58, 22);
            this.btnUpdateCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdateCancel.TabIndex = 44;
            this.btnUpdateCancel.Text = "取消";
            this.btnUpdateCancel.Click += new System.EventHandler(this.btnUpdateCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDel.Location = new System.Drawing.Point(3, 46);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(58, 22);
            this.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdateConfirm
            // 
            this.btnUpdateConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdateConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnUpdateConfirm.Location = new System.Drawing.Point(3, 23);
            this.btnUpdateConfirm.Name = "btnUpdateConfirm";
            this.btnUpdateConfirm.Size = new System.Drawing.Size(58, 22);
            this.btnUpdateConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdateConfirm.TabIndex = 43;
            this.btnUpdateConfirm.Text = "确定";
            this.btnUpdateConfirm.Click += new System.EventHandler(this.btnUpdateConfirm_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(3, 23);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(58, 22);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "更改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAdd.Location = new System.Drawing.Point(3, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 22);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "增加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv.Location = new System.Drawing.Point(0, 105);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1024, 463);
            this.dgv.TabIndex = 17;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // tbCardNo
            // 
            this.tbCardNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbCardNo.Location = new System.Drawing.Point(257, 17);
            this.tbCardNo.Margin = new System.Windows.Forms.Padding(2);
            this.tbCardNo.Name = "tbCardNo";
            this.tbCardNo.Size = new System.Drawing.Size(124, 21);
            this.tbCardNo.TabIndex = 42;
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Location = new System.Drawing.Point(200, 21);
            this.lblCardNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(41, 12);
            this.lblCardNo.TabIndex = 41;
            this.lblCardNo.Text = "ID卡号";
            // 
            // FrmIdCardM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlFunc);
            this.Name = "FrmIdCardM";
            this.Size = new System.Drawing.Size(1024, 568);
            this.Load += new System.EventHandler(this.FrmIdCardM_Load);
            this.pnlFunc.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlFunc;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Panel pnlAction;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv;
        internal System.Windows.Forms.ComboBox cmbType;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Label lblType;
        internal System.Windows.Forms.TextBox tbName;
        internal System.Windows.Forms.TextBox tbCode;
        internal System.Windows.Forms.Label lblCode;
        private DevComponents.DotNetBar.ButtonX btnUpdateCancel;
        private DevComponents.DotNetBar.ButtonX btnUpdateConfirm;
        internal System.Windows.Forms.TextBox tbCardNo;
        internal System.Windows.Forms.Label lblCardNo;
    }
}
