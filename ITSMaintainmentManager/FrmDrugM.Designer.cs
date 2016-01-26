namespace ITSMaintainmentManager
{
    partial class FrmDrugM
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
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.tbUnitRatio = new System.Windows.Forms.TextBox();
            this.lblUnitRatio = new System.Windows.Forms.Label();
            this.tbPackUnit = new System.Windows.Forms.TextBox();
            this.lblPackUnit = new System.Windows.Forms.Label();
            this.tbCommonInputcode = new System.Windows.Forms.TextBox();
            this.lblCommonInputcode = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.tbInputcode = new System.Windows.Forms.TextBox();
            this.lblInputcode = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.tbCommonName = new System.Windows.Forms.TextBox();
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblCommonName = new System.Windows.Forms.Label();
            this.lblSpec = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnUpdateCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdateConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.dgv = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cmbManufactuer = new System.Windows.Forms.ComboBox();
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
            this.pnlInfo.Size = new System.Drawing.Size(1024, 76);
            this.pnlInfo.TabIndex = 15;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.cmbManufactuer);
            this.gbInfo.Controls.Add(this.lblManufacturer);
            this.gbInfo.Controls.Add(this.tbUnitRatio);
            this.gbInfo.Controls.Add(this.lblUnitRatio);
            this.gbInfo.Controls.Add(this.tbPackUnit);
            this.gbInfo.Controls.Add(this.lblPackUnit);
            this.gbInfo.Controls.Add(this.tbCommonInputcode);
            this.gbInfo.Controls.Add(this.lblCommonInputcode);
            this.gbInfo.Controls.Add(this.tbCode);
            this.gbInfo.Controls.Add(this.lblCode);
            this.gbInfo.Controls.Add(this.tbInputcode);
            this.gbInfo.Controls.Add(this.lblInputcode);
            this.gbInfo.Controls.Add(this.tbName);
            this.gbInfo.Controls.Add(this.tbUnit);
            this.gbInfo.Controls.Add(this.tbCommonName);
            this.gbInfo.Controls.Add(this.tbSpec);
            this.gbInfo.Controls.Add(this.lblUnit);
            this.gbInfo.Controls.Add(this.lblCommonName);
            this.gbInfo.Controls.Add(this.lblSpec);
            this.gbInfo.Controls.Add(this.lblName);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInfo.Font = new System.Drawing.Font("SimSun", 9F);
            this.gbInfo.Location = new System.Drawing.Point(0, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(958, 74);
            this.gbInfo.TabIndex = 1;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "信息";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(765, 23);
            this.lblManufacturer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(53, 12);
            this.lblManufacturer.TabIndex = 49;
            this.lblManufacturer.Text = "生产厂家";
            // 
            // tbUnitRatio
            // 
            this.tbUnitRatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbUnitRatio.Location = new System.Drawing.Point(845, 47);
            this.tbUnitRatio.Margin = new System.Windows.Forms.Padding(2);
            this.tbUnitRatio.Name = "tbUnitRatio";
            this.tbUnitRatio.Size = new System.Drawing.Size(111, 21);
            this.tbUnitRatio.TabIndex = 48;
            this.tbUnitRatio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUnitRatio_KeyPress);
            // 
            // lblUnitRatio
            // 
            this.lblUnitRatio.AutoSize = true;
            this.lblUnitRatio.Location = new System.Drawing.Point(765, 51);
            this.lblUnitRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitRatio.Name = "lblUnitRatio";
            this.lblUnitRatio.Size = new System.Drawing.Size(77, 12);
            this.lblUnitRatio.TabIndex = 47;
            this.lblUnitRatio.Text = "药品单位比率";
            // 
            // tbPackUnit
            // 
            this.tbPackUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbPackUnit.Location = new System.Drawing.Point(643, 47);
            this.tbPackUnit.Margin = new System.Windows.Forms.Padding(2);
            this.tbPackUnit.Name = "tbPackUnit";
            this.tbPackUnit.Size = new System.Drawing.Size(111, 21);
            this.tbPackUnit.TabIndex = 46;
            // 
            // lblPackUnit
            // 
            this.lblPackUnit.AutoSize = true;
            this.lblPackUnit.Location = new System.Drawing.Point(575, 51);
            this.lblPackUnit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPackUnit.Name = "lblPackUnit";
            this.lblPackUnit.Size = new System.Drawing.Size(65, 12);
            this.lblPackUnit.TabIndex = 45;
            this.lblPackUnit.Text = "药品小单位";
            // 
            // tbCommonInputcode
            // 
            this.tbCommonInputcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbCommonInputcode.Location = new System.Drawing.Point(643, 19);
            this.tbCommonInputcode.Margin = new System.Windows.Forms.Padding(2);
            this.tbCommonInputcode.Name = "tbCommonInputcode";
            this.tbCommonInputcode.Size = new System.Drawing.Size(111, 21);
            this.tbCommonInputcode.TabIndex = 44;
            // 
            // lblCommonInputcode
            // 
            this.lblCommonInputcode.AutoSize = true;
            this.lblCommonInputcode.Location = new System.Drawing.Point(561, 23);
            this.lblCommonInputcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommonInputcode.Name = "lblCommonInputcode";
            this.lblCommonInputcode.Size = new System.Drawing.Size(77, 12);
            this.lblCommonInputcode.TabIndex = 43;
            this.lblCommonInputcode.Text = "商品名拼音码";
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbCode.Location = new System.Drawing.Point(62, 47);
            this.tbCode.Margin = new System.Windows.Forms.Padding(2);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(111, 21);
            this.tbCode.TabIndex = 40;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(5, 51);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(53, 12);
            this.lblCode.TabIndex = 39;
            this.lblCode.Text = "药品编码";
            // 
            // tbInputcode
            // 
            this.tbInputcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbInputcode.Location = new System.Drawing.Point(251, 19);
            this.tbInputcode.Margin = new System.Windows.Forms.Padding(2);
            this.tbInputcode.Name = "tbInputcode";
            this.tbInputcode.Size = new System.Drawing.Size(111, 21);
            this.tbInputcode.TabIndex = 38;
            // 
            // lblInputcode
            // 
            this.lblInputcode.AutoSize = true;
            this.lblInputcode.Location = new System.Drawing.Point(183, 23);
            this.lblInputcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInputcode.Name = "lblInputcode";
            this.lblInputcode.Size = new System.Drawing.Size(65, 12);
            this.lblInputcode.TabIndex = 37;
            this.lblInputcode.Text = "药品拼音码";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbName.Location = new System.Drawing.Point(62, 19);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(111, 21);
            this.tbName.TabIndex = 36;
            // 
            // tbUnit
            // 
            this.tbUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbUnit.Location = new System.Drawing.Point(440, 48);
            this.tbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.Size = new System.Drawing.Size(111, 21);
            this.tbUnit.TabIndex = 34;
            // 
            // tbCommonName
            // 
            this.tbCommonName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbCommonName.Location = new System.Drawing.Point(440, 19);
            this.tbCommonName.Margin = new System.Windows.Forms.Padding(2);
            this.tbCommonName.Name = "tbCommonName";
            this.tbCommonName.Size = new System.Drawing.Size(111, 21);
            this.tbCommonName.TabIndex = 33;
            // 
            // tbSpec
            // 
            this.tbSpec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbSpec.Location = new System.Drawing.Point(251, 47);
            this.tbSpec.Margin = new System.Windows.Forms.Padding(2);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.Size = new System.Drawing.Size(111, 21);
            this.tbSpec.TabIndex = 33;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(372, 51);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(65, 12);
            this.lblUnit.TabIndex = 32;
            this.lblUnit.Text = "药品大单位";
            // 
            // lblCommonName
            // 
            this.lblCommonName.AutoSize = true;
            this.lblCommonName.Location = new System.Drawing.Point(372, 23);
            this.lblCommonName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommonName.Name = "lblCommonName";
            this.lblCommonName.Size = new System.Drawing.Size(65, 12);
            this.lblCommonName.TabIndex = 31;
            this.lblCommonName.Text = "药品商品名";
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(195, 51);
            this.lblSpec.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(53, 12);
            this.lblSpec.TabIndex = 31;
            this.lblSpec.Text = "药品规格";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 23);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 30;
            this.lblName.Text = "药品名称";
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
            this.pnlAction.Size = new System.Drawing.Size(64, 74);
            this.pnlAction.TabIndex = 0;
            // 
            // btnUpdateCancel
            // 
            this.btnUpdateCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdateCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnUpdateCancel.Location = new System.Drawing.Point(3, 49);
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
            this.btnDel.Location = new System.Drawing.Point(3, 49);
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
            this.btnUpdateConfirm.Location = new System.Drawing.Point(3, 26);
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
            this.btnUpdate.Location = new System.Drawing.Point(3, 26);
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
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
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
            this.dgv.Location = new System.Drawing.Point(0, 108);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1024, 460);
            this.dgv.TabIndex = 17;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // cmbManufactuer
            // 
            this.cmbManufactuer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufactuer.FormattingEnabled = true;
            this.cmbManufactuer.Location = new System.Drawing.Point(823, 19);
            this.cmbManufactuer.Name = "cmbManufactuer";
            this.cmbManufactuer.Size = new System.Drawing.Size(132, 20);
            this.cmbManufactuer.TabIndex = 50;
            // 
            // FrmDrugM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlFunc);
            this.Name = "FrmDrugM";
            this.Size = new System.Drawing.Size(1024, 568);
            this.Load += new System.EventHandler(this.FrmDrugM_Load);
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
        internal System.Windows.Forms.TextBox tbUnit;
        internal System.Windows.Forms.TextBox tbSpec;
        internal System.Windows.Forms.Label lblUnit;
        internal System.Windows.Forms.Label lblSpec;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox tbName;
        internal System.Windows.Forms.TextBox tbCommonName;
        internal System.Windows.Forms.Label lblCommonName;
        internal System.Windows.Forms.TextBox tbCode;
        internal System.Windows.Forms.Label lblCode;
        internal System.Windows.Forms.TextBox tbInputcode;
        internal System.Windows.Forms.Label lblInputcode;
        private DevComponents.DotNetBar.ButtonX btnUpdateCancel;
        private DevComponents.DotNetBar.ButtonX btnUpdateConfirm;
        internal System.Windows.Forms.TextBox tbUnitRatio;
        internal System.Windows.Forms.Label lblUnitRatio;
        internal System.Windows.Forms.TextBox tbPackUnit;
        internal System.Windows.Forms.Label lblPackUnit;
        internal System.Windows.Forms.TextBox tbCommonInputcode;
        internal System.Windows.Forms.Label lblCommonInputcode;
        internal System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.ComboBox cmbManufactuer;
    }
}
