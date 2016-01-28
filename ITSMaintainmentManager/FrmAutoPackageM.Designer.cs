namespace ITSMaintainmentManager
{
    partial class FrmAutoPackageM
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFunc = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.pnlOperList = new System.Windows.Forms.Panel();
            this.gbOperList = new System.Windows.Forms.GroupBox();
            this.dgvOperList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tbOperFilter = new System.Windows.Forms.TextBox();
            this.pnlIns = new System.Windows.Forms.Panel();
            this.dgvIns = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlInsHeader = new System.Windows.Forms.Panel();
            this.gbIns = new System.Windows.Forms.GroupBox();
            this.tbInsQuantity = new System.Windows.Forms.TextBox();
            this.tbInsUnit = new System.Windows.Forms.TextBox();
            this.lblInsName = new System.Windows.Forms.Label();
            this.lblInsQuantity = new System.Windows.Forms.Label();
            this.lblInsUnit = new System.Windows.Forms.Label();
            this.lblInsSpec = new System.Windows.Forms.Label();
            this.tbInsCode = new System.Windows.Forms.TextBox();
            this.tbInsSpec = new System.Windows.Forms.TextBox();
            this.lblInsCode = new System.Windows.Forms.Label();
            this.pnlInsAction = new System.Windows.Forms.Panel();
            this.btnInsUpdateCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnInsDel = new DevComponents.DotNetBar.ButtonX();
            this.btnInsUpdateConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnInsUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnInsAdd = new DevComponents.DotNetBar.ButtonX();
            this.pnlDrug = new System.Windows.Forms.Panel();
            this.dgvDrug = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlDrugHeader = new System.Windows.Forms.Panel();
            this.gbDrug = new System.Windows.Forms.GroupBox();
            this.tbDrugQuantity = new System.Windows.Forms.TextBox();
            this.lblDrugQuantity = new System.Windows.Forms.Label();
            this.tbDrugCode = new System.Windows.Forms.TextBox();
            this.lblDrugCode = new System.Windows.Forms.Label();
            this.tbDrugProductName = new System.Windows.Forms.TextBox();
            this.tbDrugSpec = new System.Windows.Forms.TextBox();
            this.tbDrugManufacture = new System.Windows.Forms.TextBox();
            this.lblDrugName = new System.Windows.Forms.Label();
            this.lblDrugManufactur = new System.Windows.Forms.Label();
            this.lblDrugSpec = new System.Windows.Forms.Label();
            this.lblDrugProductName = new System.Windows.Forms.Label();
            this.lblDrugUnit = new System.Windows.Forms.Label();
            this.tbDrugUnit = new System.Windows.Forms.TextBox();
            this.pnlDrugAction = new System.Windows.Forms.Panel();
            this.btnDrugUpdateCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnDrugDel = new DevComponents.DotNetBar.ButtonX();
            this.btnDrugUpdateConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnDrugUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnDrugAdd = new DevComponents.DotNetBar.ButtonX();
            this.ddlDrugName = new UIControlLib.UIDropDownList(this.components);
            this.ddlInsName = new UIControlLib.UIDropDownList(this.components);
            this.pnlFunc.SuspendLayout();
            this.pnlOperList.SuspendLayout();
            this.gbOperList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperList)).BeginInit();
            this.pnlIns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIns)).BeginInit();
            this.pnlInsHeader.SuspendLayout();
            this.gbIns.SuspendLayout();
            this.pnlInsAction.SuspendLayout();
            this.pnlDrug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrug)).BeginInit();
            this.pnlDrugHeader.SuspendLayout();
            this.gbDrug.SuspendLayout();
            this.pnlDrugAction.SuspendLayout();
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
            // pnlOperList
            // 
            this.pnlOperList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOperList.Controls.Add(this.gbOperList);
            this.pnlOperList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOperList.Location = new System.Drawing.Point(0, 32);
            this.pnlOperList.Name = "pnlOperList";
            this.pnlOperList.Size = new System.Drawing.Size(225, 536);
            this.pnlOperList.TabIndex = 16;
            // 
            // gbOperList
            // 
            this.gbOperList.Controls.Add(this.dgvOperList);
            this.gbOperList.Controls.Add(this.tbOperFilter);
            this.gbOperList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOperList.Font = new System.Drawing.Font("SimSun", 9F);
            this.gbOperList.Location = new System.Drawing.Point(0, 0);
            this.gbOperList.Name = "gbOperList";
            this.gbOperList.Size = new System.Drawing.Size(223, 534);
            this.gbOperList.TabIndex = 0;
            this.gbOperList.TabStop = false;
            this.gbOperList.Text = "手术列表";
            // 
            // dgvOperList
            // 
            this.dgvOperList.AllowUserToAddRows = false;
            this.dgvOperList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOperList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvOperList.Location = new System.Drawing.Point(3, 38);
            this.dgvOperList.Name = "dgvOperList";
            this.dgvOperList.ReadOnly = true;
            this.dgvOperList.RowTemplate.Height = 23;
            this.dgvOperList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperList.Size = new System.Drawing.Size(217, 493);
            this.dgvOperList.TabIndex = 1;
            this.dgvOperList.SelectionChanged += new System.EventHandler(this.dgvOperList_SelectionChanged);
            // 
            // tbOperFilter
            // 
            this.tbOperFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbOperFilter.Location = new System.Drawing.Point(3, 17);
            this.tbOperFilter.Name = "tbOperFilter";
            this.tbOperFilter.Size = new System.Drawing.Size(217, 21);
            this.tbOperFilter.TabIndex = 0;
            this.tbOperFilter.TextChanged += new System.EventHandler(this.tbOperFilter_TextChanged);
            // 
            // pnlIns
            // 
            this.pnlIns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIns.Controls.Add(this.dgvIns);
            this.pnlIns.Controls.Add(this.pnlInsHeader);
            this.pnlIns.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIns.Location = new System.Drawing.Point(225, 32);
            this.pnlIns.Name = "pnlIns";
            this.pnlIns.Size = new System.Drawing.Size(403, 536);
            this.pnlIns.TabIndex = 17;
            // 
            // dgvIns
            // 
            this.dgvIns.AllowUserToAddRows = false;
            this.dgvIns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIns.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIns.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvIns.Location = new System.Drawing.Point(0, 127);
            this.dgvIns.Name = "dgvIns";
            this.dgvIns.ReadOnly = true;
            this.dgvIns.RowHeadersVisible = false;
            this.dgvIns.RowTemplate.Height = 23;
            this.dgvIns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIns.Size = new System.Drawing.Size(401, 407);
            this.dgvIns.TabIndex = 17;
            this.dgvIns.SelectionChanged += new System.EventHandler(this.dgvIns_SelectionChanged);
            // 
            // pnlInsHeader
            // 
            this.pnlInsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInsHeader.Controls.Add(this.gbIns);
            this.pnlInsHeader.Controls.Add(this.pnlInsAction);
            this.pnlInsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlInsHeader.Name = "pnlInsHeader";
            this.pnlInsHeader.Size = new System.Drawing.Size(401, 127);
            this.pnlInsHeader.TabIndex = 16;
            // 
            // gbIns
            // 
            this.gbIns.Controls.Add(this.ddlInsName);
            this.gbIns.Controls.Add(this.tbInsQuantity);
            this.gbIns.Controls.Add(this.tbInsUnit);
            this.gbIns.Controls.Add(this.lblInsName);
            this.gbIns.Controls.Add(this.lblInsQuantity);
            this.gbIns.Controls.Add(this.lblInsUnit);
            this.gbIns.Controls.Add(this.lblInsSpec);
            this.gbIns.Controls.Add(this.tbInsCode);
            this.gbIns.Controls.Add(this.tbInsSpec);
            this.gbIns.Controls.Add(this.lblInsCode);
            this.gbIns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbIns.Font = new System.Drawing.Font("SimSun", 9F);
            this.gbIns.Location = new System.Drawing.Point(0, 0);
            this.gbIns.Name = "gbIns";
            this.gbIns.Size = new System.Drawing.Size(335, 125);
            this.gbIns.TabIndex = 1;
            this.gbIns.TabStop = false;
            this.gbIns.Text = "物品信息";
            // 
            // tbInsQuantity
            // 
            this.tbInsQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.tbInsQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInsQuantity.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbInsQuantity.Location = new System.Drawing.Point(62, 75);
            this.tbInsQuantity.Name = "tbInsQuantity";
            this.tbInsQuantity.Size = new System.Drawing.Size(108, 21);
            this.tbInsQuantity.TabIndex = 47;
            this.tbInsQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Quantity_KeyPress);
            // 
            // tbInsUnit
            // 
            this.tbInsUnit.BackColor = System.Drawing.Color.Ivory;
            this.tbInsUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInsUnit.Enabled = false;
            this.tbInsUnit.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbInsUnit.Location = new System.Drawing.Point(228, 48);
            this.tbInsUnit.Name = "tbInsUnit";
            this.tbInsUnit.ReadOnly = true;
            this.tbInsUnit.Size = new System.Drawing.Size(108, 21);
            this.tbInsUnit.TabIndex = 49;
            // 
            // lblInsName
            // 
            this.lblInsName.AutoSize = true;
            this.lblInsName.Location = new System.Drawing.Point(9, 25);
            this.lblInsName.Name = "lblInsName";
            this.lblInsName.Size = new System.Drawing.Size(53, 12);
            this.lblInsName.TabIndex = 43;
            this.lblInsName.Text = "物品名称";
            // 
            // lblInsQuantity
            // 
            this.lblInsQuantity.AutoSize = true;
            this.lblInsQuantity.Location = new System.Drawing.Point(9, 79);
            this.lblInsQuantity.Name = "lblInsQuantity";
            this.lblInsQuantity.Size = new System.Drawing.Size(53, 12);
            this.lblInsQuantity.TabIndex = 48;
            this.lblInsQuantity.Text = "物品数量";
            // 
            // lblInsUnit
            // 
            this.lblInsUnit.AutoSize = true;
            this.lblInsUnit.Location = new System.Drawing.Point(175, 52);
            this.lblInsUnit.Name = "lblInsUnit";
            this.lblInsUnit.Size = new System.Drawing.Size(53, 12);
            this.lblInsUnit.TabIndex = 46;
            this.lblInsUnit.Text = "物品单位";
            // 
            // lblInsSpec
            // 
            this.lblInsSpec.AutoSize = true;
            this.lblInsSpec.Location = new System.Drawing.Point(9, 52);
            this.lblInsSpec.Name = "lblInsSpec";
            this.lblInsSpec.Size = new System.Drawing.Size(53, 12);
            this.lblInsSpec.TabIndex = 44;
            this.lblInsSpec.Text = "物品规格";
            // 
            // tbInsCode
            // 
            this.tbInsCode.BackColor = System.Drawing.Color.Ivory;
            this.tbInsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInsCode.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbInsCode.Location = new System.Drawing.Point(228, 20);
            this.tbInsCode.Name = "tbInsCode";
            this.tbInsCode.ReadOnly = true;
            this.tbInsCode.Size = new System.Drawing.Size(108, 21);
            this.tbInsCode.TabIndex = 42;
            // 
            // tbInsSpec
            // 
            this.tbInsSpec.BackColor = System.Drawing.Color.Ivory;
            this.tbInsSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInsSpec.Enabled = false;
            this.tbInsSpec.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbInsSpec.Location = new System.Drawing.Point(62, 48);
            this.tbInsSpec.Name = "tbInsSpec";
            this.tbInsSpec.ReadOnly = true;
            this.tbInsSpec.Size = new System.Drawing.Size(108, 21);
            this.tbInsSpec.TabIndex = 45;
            // 
            // lblInsCode
            // 
            this.lblInsCode.AutoSize = true;
            this.lblInsCode.Location = new System.Drawing.Point(175, 25);
            this.lblInsCode.Name = "lblInsCode";
            this.lblInsCode.Size = new System.Drawing.Size(53, 12);
            this.lblInsCode.TabIndex = 41;
            this.lblInsCode.Text = "物品编号";
            // 
            // pnlInsAction
            // 
            this.pnlInsAction.Controls.Add(this.btnInsUpdateCancel);
            this.pnlInsAction.Controls.Add(this.btnInsDel);
            this.pnlInsAction.Controls.Add(this.btnInsUpdateConfirm);
            this.pnlInsAction.Controls.Add(this.btnInsUpdate);
            this.pnlInsAction.Controls.Add(this.btnInsAdd);
            this.pnlInsAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInsAction.Location = new System.Drawing.Point(335, 0);
            this.pnlInsAction.Name = "pnlInsAction";
            this.pnlInsAction.Size = new System.Drawing.Size(64, 125);
            this.pnlInsAction.TabIndex = 0;
            // 
            // btnInsUpdateCancel
            // 
            this.btnInsUpdateCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsUpdateCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsUpdateCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnInsUpdateCancel.Location = new System.Drawing.Point(3, 100);
            this.btnInsUpdateCancel.Name = "btnInsUpdateCancel";
            this.btnInsUpdateCancel.Size = new System.Drawing.Size(58, 22);
            this.btnInsUpdateCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsUpdateCancel.TabIndex = 44;
            this.btnInsUpdateCancel.Text = "取消";
            this.btnInsUpdateCancel.Click += new System.EventHandler(this.btnInsUpdateCancel_Click);
            // 
            // btnInsDel
            // 
            this.btnInsDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsDel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnInsDel.Location = new System.Drawing.Point(3, 100);
            this.btnInsDel.Name = "btnInsDel";
            this.btnInsDel.Size = new System.Drawing.Size(58, 22);
            this.btnInsDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsDel.TabIndex = 3;
            this.btnInsDel.Text = "删除";
            this.btnInsDel.Click += new System.EventHandler(this.btnInsDel_Click);
            // 
            // btnInsUpdateConfirm
            // 
            this.btnInsUpdateConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsUpdateConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsUpdateConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnInsUpdateConfirm.Location = new System.Drawing.Point(3, 77);
            this.btnInsUpdateConfirm.Name = "btnInsUpdateConfirm";
            this.btnInsUpdateConfirm.Size = new System.Drawing.Size(58, 22);
            this.btnInsUpdateConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsUpdateConfirm.TabIndex = 43;
            this.btnInsUpdateConfirm.Text = "确定";
            this.btnInsUpdateConfirm.Click += new System.EventHandler(this.btnInsUpdateConfirm_Click);
            // 
            // btnInsUpdate
            // 
            this.btnInsUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnInsUpdate.Location = new System.Drawing.Point(3, 77);
            this.btnInsUpdate.Name = "btnInsUpdate";
            this.btnInsUpdate.Size = new System.Drawing.Size(58, 22);
            this.btnInsUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsUpdate.TabIndex = 2;
            this.btnInsUpdate.Text = "更改";
            this.btnInsUpdate.Click += new System.EventHandler(this.btnInsUpdate_Click);
            // 
            // btnInsAdd
            // 
            this.btnInsAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnInsAdd.Location = new System.Drawing.Point(3, 54);
            this.btnInsAdd.Name = "btnInsAdd";
            this.btnInsAdd.Size = new System.Drawing.Size(58, 22);
            this.btnInsAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsAdd.TabIndex = 1;
            this.btnInsAdd.Text = "增加";
            this.btnInsAdd.Click += new System.EventHandler(this.btnInsAdd_Click);
            // 
            // pnlDrug
            // 
            this.pnlDrug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrug.Controls.Add(this.dgvDrug);
            this.pnlDrug.Controls.Add(this.pnlDrugHeader);
            this.pnlDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDrug.Location = new System.Drawing.Point(628, 32);
            this.pnlDrug.Name = "pnlDrug";
            this.pnlDrug.Size = new System.Drawing.Size(396, 536);
            this.pnlDrug.TabIndex = 17;
            // 
            // dgvDrug
            // 
            this.dgvDrug.AllowUserToAddRows = false;
            this.dgvDrug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDrug.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrug.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDrug.Location = new System.Drawing.Point(0, 128);
            this.dgvDrug.Name = "dgvDrug";
            this.dgvDrug.ReadOnly = true;
            this.dgvDrug.RowHeadersVisible = false;
            this.dgvDrug.RowTemplate.Height = 23;
            this.dgvDrug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrug.Size = new System.Drawing.Size(394, 406);
            this.dgvDrug.TabIndex = 18;
            this.dgvDrug.SelectionChanged += new System.EventHandler(this.dgvDrug_SelectionChanged);
            // 
            // pnlDrugHeader
            // 
            this.pnlDrugHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrugHeader.Controls.Add(this.gbDrug);
            this.pnlDrugHeader.Controls.Add(this.pnlDrugAction);
            this.pnlDrugHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDrugHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDrugHeader.Name = "pnlDrugHeader";
            this.pnlDrugHeader.Size = new System.Drawing.Size(394, 128);
            this.pnlDrugHeader.TabIndex = 17;
            // 
            // gbDrug
            // 
            this.gbDrug.Controls.Add(this.tbDrugQuantity);
            this.gbDrug.Controls.Add(this.lblDrugQuantity);
            this.gbDrug.Controls.Add(this.tbDrugCode);
            this.gbDrug.Controls.Add(this.lblDrugCode);
            this.gbDrug.Controls.Add(this.tbDrugProductName);
            this.gbDrug.Controls.Add(this.tbDrugSpec);
            this.gbDrug.Controls.Add(this.ddlDrugName);
            this.gbDrug.Controls.Add(this.tbDrugManufacture);
            this.gbDrug.Controls.Add(this.lblDrugName);
            this.gbDrug.Controls.Add(this.lblDrugManufactur);
            this.gbDrug.Controls.Add(this.lblDrugSpec);
            this.gbDrug.Controls.Add(this.lblDrugProductName);
            this.gbDrug.Controls.Add(this.lblDrugUnit);
            this.gbDrug.Controls.Add(this.tbDrugUnit);
            this.gbDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDrug.Font = new System.Drawing.Font("SimSun", 9F);
            this.gbDrug.Location = new System.Drawing.Point(0, 0);
            this.gbDrug.Name = "gbDrug";
            this.gbDrug.Size = new System.Drawing.Size(328, 126);
            this.gbDrug.TabIndex = 1;
            this.gbDrug.TabStop = false;
            this.gbDrug.Text = "药品信息";
            // 
            // tbDrugQuantity
            // 
            this.tbDrugQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.tbDrugQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDrugQuantity.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbDrugQuantity.Location = new System.Drawing.Point(230, 74);
            this.tbDrugQuantity.Name = "tbDrugQuantity";
            this.tbDrugQuantity.Size = new System.Drawing.Size(108, 21);
            this.tbDrugQuantity.TabIndex = 57;
            this.tbDrugQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Quantity_KeyPress);
            // 
            // lblDrugQuantity
            // 
            this.lblDrugQuantity.AutoSize = true;
            this.lblDrugQuantity.Location = new System.Drawing.Point(174, 78);
            this.lblDrugQuantity.Name = "lblDrugQuantity";
            this.lblDrugQuantity.Size = new System.Drawing.Size(53, 12);
            this.lblDrugQuantity.TabIndex = 56;
            this.lblDrugQuantity.Text = "药品数量";
            // 
            // tbDrugCode
            // 
            this.tbDrugCode.BackColor = System.Drawing.Color.Ivory;
            this.tbDrugCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDrugCode.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbDrugCode.Location = new System.Drawing.Point(230, 19);
            this.tbDrugCode.Name = "tbDrugCode";
            this.tbDrugCode.ReadOnly = true;
            this.tbDrugCode.Size = new System.Drawing.Size(108, 21);
            this.tbDrugCode.TabIndex = 57;
            // 
            // lblDrugCode
            // 
            this.lblDrugCode.AutoSize = true;
            this.lblDrugCode.Location = new System.Drawing.Point(174, 24);
            this.lblDrugCode.Name = "lblDrugCode";
            this.lblDrugCode.Size = new System.Drawing.Size(53, 12);
            this.lblDrugCode.TabIndex = 58;
            this.lblDrugCode.Text = "药品编码";
            // 
            // tbDrugProductName
            // 
            this.tbDrugProductName.BackColor = System.Drawing.Color.Ivory;
            this.tbDrugProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDrugProductName.Enabled = false;
            this.tbDrugProductName.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbDrugProductName.Location = new System.Drawing.Point(77, 101);
            this.tbDrugProductName.Name = "tbDrugProductName";
            this.tbDrugProductName.ReadOnly = true;
            this.tbDrugProductName.Size = new System.Drawing.Size(150, 21);
            this.tbDrugProductName.TabIndex = 56;
            // 
            // tbDrugSpec
            // 
            this.tbDrugSpec.BackColor = System.Drawing.Color.Ivory;
            this.tbDrugSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDrugSpec.Enabled = false;
            this.tbDrugSpec.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbDrugSpec.Location = new System.Drawing.Point(62, 47);
            this.tbDrugSpec.Name = "tbDrugSpec";
            this.tbDrugSpec.ReadOnly = true;
            this.tbDrugSpec.Size = new System.Drawing.Size(108, 21);
            this.tbDrugSpec.TabIndex = 49;
            // 
            // tbDrugManufacture
            // 
            this.tbDrugManufacture.BackColor = System.Drawing.Color.Ivory;
            this.tbDrugManufacture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDrugManufacture.Enabled = false;
            this.tbDrugManufacture.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbDrugManufacture.Location = new System.Drawing.Point(230, 47);
            this.tbDrugManufacture.Name = "tbDrugManufacture";
            this.tbDrugManufacture.ReadOnly = true;
            this.tbDrugManufacture.Size = new System.Drawing.Size(108, 21);
            this.tbDrugManufacture.TabIndex = 53;
            // 
            // lblDrugName
            // 
            this.lblDrugName.AutoSize = true;
            this.lblDrugName.Location = new System.Drawing.Point(7, 24);
            this.lblDrugName.Name = "lblDrugName";
            this.lblDrugName.Size = new System.Drawing.Size(53, 12);
            this.lblDrugName.TabIndex = 45;
            this.lblDrugName.Text = "药品名称";
            // 
            // lblDrugManufactur
            // 
            this.lblDrugManufactur.AutoSize = true;
            this.lblDrugManufactur.Location = new System.Drawing.Point(174, 51);
            this.lblDrugManufactur.Name = "lblDrugManufactur";
            this.lblDrugManufactur.Size = new System.Drawing.Size(53, 12);
            this.lblDrugManufactur.TabIndex = 52;
            this.lblDrugManufactur.Text = "药品厂家";
            // 
            // lblDrugSpec
            // 
            this.lblDrugSpec.AutoSize = true;
            this.lblDrugSpec.Location = new System.Drawing.Point(7, 51);
            this.lblDrugSpec.Name = "lblDrugSpec";
            this.lblDrugSpec.Size = new System.Drawing.Size(53, 12);
            this.lblDrugSpec.TabIndex = 48;
            this.lblDrugSpec.Text = "药品规格";
            // 
            // lblDrugProductName
            // 
            this.lblDrugProductName.AutoSize = true;
            this.lblDrugProductName.Location = new System.Drawing.Point(7, 106);
            this.lblDrugProductName.Name = "lblDrugProductName";
            this.lblDrugProductName.Size = new System.Drawing.Size(65, 12);
            this.lblDrugProductName.TabIndex = 46;
            this.lblDrugProductName.Text = "药品商品名";
            // 
            // lblDrugUnit
            // 
            this.lblDrugUnit.AutoSize = true;
            this.lblDrugUnit.Location = new System.Drawing.Point(7, 78);
            this.lblDrugUnit.Name = "lblDrugUnit";
            this.lblDrugUnit.Size = new System.Drawing.Size(53, 12);
            this.lblDrugUnit.TabIndex = 50;
            this.lblDrugUnit.Text = "药品单位";
            // 
            // tbDrugUnit
            // 
            this.tbDrugUnit.BackColor = System.Drawing.Color.Ivory;
            this.tbDrugUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDrugUnit.Enabled = false;
            this.tbDrugUnit.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbDrugUnit.Location = new System.Drawing.Point(62, 74);
            this.tbDrugUnit.Name = "tbDrugUnit";
            this.tbDrugUnit.ReadOnly = true;
            this.tbDrugUnit.Size = new System.Drawing.Size(108, 21);
            this.tbDrugUnit.TabIndex = 51;
            // 
            // pnlDrugAction
            // 
            this.pnlDrugAction.Controls.Add(this.btnDrugUpdateCancel);
            this.pnlDrugAction.Controls.Add(this.btnDrugDel);
            this.pnlDrugAction.Controls.Add(this.btnDrugUpdateConfirm);
            this.pnlDrugAction.Controls.Add(this.btnDrugUpdate);
            this.pnlDrugAction.Controls.Add(this.btnDrugAdd);
            this.pnlDrugAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDrugAction.Location = new System.Drawing.Point(328, 0);
            this.pnlDrugAction.Name = "pnlDrugAction";
            this.pnlDrugAction.Size = new System.Drawing.Size(64, 126);
            this.pnlDrugAction.TabIndex = 0;
            // 
            // btnDrugUpdateCancel
            // 
            this.btnDrugUpdateCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDrugUpdateCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrugUpdateCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDrugUpdateCancel.Location = new System.Drawing.Point(3, 101);
            this.btnDrugUpdateCancel.Name = "btnDrugUpdateCancel";
            this.btnDrugUpdateCancel.Size = new System.Drawing.Size(58, 22);
            this.btnDrugUpdateCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDrugUpdateCancel.TabIndex = 44;
            this.btnDrugUpdateCancel.Text = "取消";
            this.btnDrugUpdateCancel.Click += new System.EventHandler(this.btnDrugUpdateCancel_Click);
            // 
            // btnDrugDel
            // 
            this.btnDrugDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDrugDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrugDel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDrugDel.Location = new System.Drawing.Point(3, 101);
            this.btnDrugDel.Name = "btnDrugDel";
            this.btnDrugDel.Size = new System.Drawing.Size(58, 22);
            this.btnDrugDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDrugDel.TabIndex = 3;
            this.btnDrugDel.Text = "删除";
            this.btnDrugDel.Click += new System.EventHandler(this.btnDrugDel_Click);
            // 
            // btnDrugUpdateConfirm
            // 
            this.btnDrugUpdateConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDrugUpdateConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrugUpdateConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDrugUpdateConfirm.Location = new System.Drawing.Point(3, 78);
            this.btnDrugUpdateConfirm.Name = "btnDrugUpdateConfirm";
            this.btnDrugUpdateConfirm.Size = new System.Drawing.Size(58, 22);
            this.btnDrugUpdateConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDrugUpdateConfirm.TabIndex = 43;
            this.btnDrugUpdateConfirm.Text = "确定";
            this.btnDrugUpdateConfirm.Click += new System.EventHandler(this.btnDrugUpdateConfirm_Click);
            // 
            // btnDrugUpdate
            // 
            this.btnDrugUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDrugUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrugUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDrugUpdate.Location = new System.Drawing.Point(3, 78);
            this.btnDrugUpdate.Name = "btnDrugUpdate";
            this.btnDrugUpdate.Size = new System.Drawing.Size(58, 22);
            this.btnDrugUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDrugUpdate.TabIndex = 2;
            this.btnDrugUpdate.Text = "更改";
            this.btnDrugUpdate.Click += new System.EventHandler(this.btnDrugUpdate_Click);
            // 
            // btnDrugAdd
            // 
            this.btnDrugAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDrugAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrugAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDrugAdd.Location = new System.Drawing.Point(3, 55);
            this.btnDrugAdd.Name = "btnDrugAdd";
            this.btnDrugAdd.Size = new System.Drawing.Size(58, 22);
            this.btnDrugAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDrugAdd.TabIndex = 1;
            this.btnDrugAdd.Text = "增加";
            this.btnDrugAdd.Click += new System.EventHandler(this.btnDrugAdd_Click);
            // 
            // ddlDrugName
            // 
            this.ddlDrugName.BackColor = System.Drawing.SystemColors.Window;
            this.ddlDrugName.ColNoOfCode = 0;
            this.ddlDrugName.ColNoOfContent = 1;
            this.ddlDrugName.ContentID = 2;
            this.ddlDrugName.DisplayContent = "";
            this.ddlDrugName.IDContent = "";
            this.ddlDrugName.Location = new System.Drawing.Point(62, 19);
            this.ddlDrugName.Name = "ddlDrugName";
            this.ddlDrugName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft;
            this.ddlDrugName.Size = new System.Drawing.Size(108, 21);
            this.ddlDrugName.TabIndex = 47;
            this.ddlDrugName.VisibleRowCount = 10;
            // 
            // ddlInsName
            // 
            this.ddlInsName.ColNoOfCode = 0;
            this.ddlInsName.ColNoOfContent = 1;
            this.ddlInsName.ContentID = 2;
            this.ddlInsName.DisplayContent = "";
            this.ddlInsName.IDContent = "";
            this.ddlInsName.Location = new System.Drawing.Point(62, 20);
            this.ddlInsName.Name = "ddlInsName";
            this.ddlInsName.OnLeft = UIControlLib.UIDropDownList.SNAP_MODE.OnLeft;
            this.ddlInsName.Size = new System.Drawing.Size(108, 21);
            this.ddlInsName.TabIndex = 50;
            this.ddlInsName.VisibleRowCount = 10;
            // 
            // FrmAutoPackageM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.pnlDrug);
            this.Controls.Add(this.pnlIns);
            this.Controls.Add(this.pnlOperList);
            this.Controls.Add(this.pnlFunc);
            this.Name = "FrmAutoPackageM";
            this.Size = new System.Drawing.Size(1024, 568);
            this.Load += new System.EventHandler(this.FrmAutoPackageM_Load);
            this.Resize += new System.EventHandler(this.FrmAutoPackageM_Resize);
            this.pnlFunc.ResumeLayout(false);
            this.pnlOperList.ResumeLayout(false);
            this.gbOperList.ResumeLayout(false);
            this.gbOperList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperList)).EndInit();
            this.pnlIns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIns)).EndInit();
            this.pnlInsHeader.ResumeLayout(false);
            this.gbIns.ResumeLayout(false);
            this.gbIns.PerformLayout();
            this.pnlInsAction.ResumeLayout(false);
            this.pnlDrug.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrug)).EndInit();
            this.pnlDrugHeader.ResumeLayout(false);
            this.gbDrug.ResumeLayout(false);
            this.gbDrug.PerformLayout();
            this.pnlDrugAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlFunc;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.Panel pnlOperList;
        private System.Windows.Forms.Panel pnlIns;
        private System.Windows.Forms.Panel pnlInsHeader;
        private System.Windows.Forms.Panel pnlInsAction;
        private DevComponents.DotNetBar.ButtonX btnInsUpdateCancel;
        private DevComponents.DotNetBar.ButtonX btnInsDel;
        private DevComponents.DotNetBar.ButtonX btnInsUpdateConfirm;
        private DevComponents.DotNetBar.ButtonX btnInsUpdate;
        private DevComponents.DotNetBar.ButtonX btnInsAdd;
        private System.Windows.Forms.Panel pnlDrug;
        private System.Windows.Forms.GroupBox gbIns;
        private System.Windows.Forms.Panel pnlDrugHeader;
        private System.Windows.Forms.GroupBox gbDrug;
        private System.Windows.Forms.Panel pnlDrugAction;
        private DevComponents.DotNetBar.ButtonX btnDrugUpdateCancel;
        private DevComponents.DotNetBar.ButtonX btnDrugDel;
        private DevComponents.DotNetBar.ButtonX btnDrugUpdateConfirm;
        private DevComponents.DotNetBar.ButtonX btnDrugUpdate;
        private DevComponents.DotNetBar.ButtonX btnDrugAdd;
        private System.Windows.Forms.GroupBox gbOperList;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvIns;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDrug;
        internal System.Windows.Forms.TextBox tbInsQuantity;
        internal System.Windows.Forms.TextBox tbInsUnit;
        internal System.Windows.Forms.Label lblInsName;
        internal System.Windows.Forms.Label lblInsQuantity;
        internal System.Windows.Forms.Label lblInsUnit;
        internal System.Windows.Forms.Label lblInsSpec;
        internal System.Windows.Forms.TextBox tbInsCode;
        internal System.Windows.Forms.TextBox tbInsSpec;
        internal System.Windows.Forms.Label lblInsCode;
        private UIControlLib.UIDropDownList ddlInsName;
        internal System.Windows.Forms.TextBox tbDrugProductName;
        internal System.Windows.Forms.TextBox tbDrugSpec;
        internal UIControlLib.UIDropDownList ddlDrugName;
        internal System.Windows.Forms.TextBox tbDrugManufacture;
        internal System.Windows.Forms.Label lblDrugName;
        internal System.Windows.Forms.Label lblDrugManufactur;
        internal System.Windows.Forms.Label lblDrugSpec;
        internal System.Windows.Forms.Label lblDrugProductName;
        internal System.Windows.Forms.Label lblDrugUnit;
        internal System.Windows.Forms.TextBox tbDrugUnit;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvOperList;
        private System.Windows.Forms.TextBox tbOperFilter;
        internal System.Windows.Forms.TextBox tbDrugQuantity;
        internal System.Windows.Forms.Label lblDrugQuantity;
        internal System.Windows.Forms.TextBox tbDrugCode;
        internal System.Windows.Forms.Label lblDrugCode;
    }
}
