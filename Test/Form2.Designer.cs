using System.ComponentModel;
using System.Windows.Forms;

namespace Test
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlFunc = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAlertQuery = new System.Windows.Forms.Button();
            this.btnWorkVolumnStatistic = new System.Windows.Forms.Button();
            this.btnTraceQuery = new System.Windows.Forms.Button();
            this.btnLocationQuery = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInOutStatistics = new System.Windows.Forms.Button();
            this.btnStockManage = new System.Windows.Forms.Button();
            this.btnWareHouseOutReg = new System.Windows.Forms.Button();
            this.btnWareHouseInReg = new System.Windows.Forms.Button();
            this.btnHighValueDispatch = new System.Windows.Forms.Button();
            this.gbOper = new System.Windows.Forms.GroupBox();
            this.btnRecycleReg = new System.Windows.Forms.Button();
            this.btnUseReg = new System.Windows.Forms.Button();
            this.btnFrontUse = new System.Windows.Forms.Button();
            this.btnPreOpertionReg = new System.Windows.Forms.Button();
            this.btnOperationNote = new System.Windows.Forms.Button();
            this.pnlPatInfo = new System.Windows.Forms.Panel();
            this.lblScretch = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlFunc.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbOper.SuspendLayout();
            this.pnlPatInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFunc
            // 
            this.pnlFunc.Controls.Add(this.button1);
            this.pnlFunc.Controls.Add(this.groupBox1);
            this.pnlFunc.Controls.Add(this.groupBox2);
            this.pnlFunc.Controls.Add(this.groupBox3);
            this.pnlFunc.Controls.Add(this.gbOper);
            this.pnlFunc.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFunc.Location = new System.Drawing.Point(0, 0);
            this.pnlFunc.Name = "pnlFunc";
            this.pnlFunc.Size = new System.Drawing.Size(228, 496);
            this.pnlFunc.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAlertQuery);
            this.groupBox2.Controls.Add(this.btnWorkVolumnStatistic);
            this.groupBox2.Controls.Add(this.btnTraceQuery);
            this.groupBox2.Controls.Add(this.btnLocationQuery);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "定位管理";
            // 
            // btnAlertQuery
            // 
            this.btnAlertQuery.Location = new System.Drawing.Point(116, 50);
            this.btnAlertQuery.Name = "btnAlertQuery";
            this.btnAlertQuery.Size = new System.Drawing.Size(108, 23);
            this.btnAlertQuery.TabIndex = 16;
            this.btnAlertQuery.Text = "报警分析";
            this.btnAlertQuery.UseVisualStyleBackColor = true;
            this.btnAlertQuery.Click += new System.EventHandler(this.btnAlertQuery_Click);
            // 
            // btnWorkVolumnStatistic
            // 
            this.btnWorkVolumnStatistic.Location = new System.Drawing.Point(4, 50);
            this.btnWorkVolumnStatistic.Name = "btnWorkVolumnStatistic";
            this.btnWorkVolumnStatistic.Size = new System.Drawing.Size(108, 23);
            this.btnWorkVolumnStatistic.TabIndex = 15;
            this.btnWorkVolumnStatistic.Text = "工作量统计";
            this.btnWorkVolumnStatistic.UseVisualStyleBackColor = true;
            this.btnWorkVolumnStatistic.Click += new System.EventHandler(this.btnWorkVolumnStatistic_Click);
            // 
            // btnTraceQuery
            // 
            this.btnTraceQuery.Location = new System.Drawing.Point(116, 21);
            this.btnTraceQuery.Name = "btnTraceQuery";
            this.btnTraceQuery.Size = new System.Drawing.Size(108, 23);
            this.btnTraceQuery.TabIndex = 14;
            this.btnTraceQuery.Text = "运动轨迹查询";
            this.btnTraceQuery.UseVisualStyleBackColor = true;
            this.btnTraceQuery.Click += new System.EventHandler(this.btnTraceQuery_Click);
            // 
            // btnLocationQuery
            // 
            this.btnLocationQuery.Location = new System.Drawing.Point(4, 21);
            this.btnLocationQuery.Name = "btnLocationQuery";
            this.btnLocationQuery.Size = new System.Drawing.Size(108, 23);
            this.btnLocationQuery.TabIndex = 13;
            this.btnLocationQuery.Text = "实时定位查询";
            this.btnLocationQuery.UseVisualStyleBackColor = true;
            this.btnLocationQuery.Click += new System.EventHandler(this.btnLocationQuery_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInOutStatistics);
            this.groupBox3.Controls.Add(this.btnStockManage);
            this.groupBox3.Controls.Add(this.btnWareHouseOutReg);
            this.groupBox3.Controls.Add(this.btnWareHouseInReg);
            this.groupBox3.Controls.Add(this.btnHighValueDispatch);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 111);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "库房管理";
            // 
            // btnInOutStatistics
            // 
            this.btnInOutStatistics.Location = new System.Drawing.Point(4, 80);
            this.btnInOutStatistics.Name = "btnInOutStatistics";
            this.btnInOutStatistics.Size = new System.Drawing.Size(108, 23);
            this.btnInOutStatistics.TabIndex = 14;
            this.btnInOutStatistics.Text = "物品出入库统计";
            this.btnInOutStatistics.UseVisualStyleBackColor = true;
            this.btnInOutStatistics.Click += new System.EventHandler(this.btnInOutStatistics_Click);
            // 
            // btnStockManage
            // 
            this.btnStockManage.Location = new System.Drawing.Point(116, 51);
            this.btnStockManage.Name = "btnStockManage";
            this.btnStockManage.Size = new System.Drawing.Size(108, 23);
            this.btnStockManage.TabIndex = 13;
            this.btnStockManage.Text = "库存管理";
            this.btnStockManage.UseVisualStyleBackColor = true;
            this.btnStockManage.Click += new System.EventHandler(this.btnStockManage_Click);
            // 
            // btnWareHouseOutReg
            // 
            this.btnWareHouseOutReg.Location = new System.Drawing.Point(4, 51);
            this.btnWareHouseOutReg.Name = "btnWareHouseOutReg";
            this.btnWareHouseOutReg.Size = new System.Drawing.Size(108, 23);
            this.btnWareHouseOutReg.TabIndex = 12;
            this.btnWareHouseOutReg.Text = "物品出库登记";
            this.btnWareHouseOutReg.UseVisualStyleBackColor = true;
            this.btnWareHouseOutReg.Click += new System.EventHandler(this.btnWareHouseOutReg_Click);
            // 
            // btnWareHouseInReg
            // 
            this.btnWareHouseInReg.Location = new System.Drawing.Point(116, 22);
            this.btnWareHouseInReg.Name = "btnWareHouseInReg";
            this.btnWareHouseInReg.Size = new System.Drawing.Size(108, 23);
            this.btnWareHouseInReg.TabIndex = 11;
            this.btnWareHouseInReg.Text = "物品入库登记";
            this.btnWareHouseInReg.UseVisualStyleBackColor = true;
            this.btnWareHouseInReg.Click += new System.EventHandler(this.btnWareHouseInReg_Click);
            // 
            // btnHighValueDispatch
            // 
            this.btnHighValueDispatch.Location = new System.Drawing.Point(4, 22);
            this.btnHighValueDispatch.Name = "btnHighValueDispatch";
            this.btnHighValueDispatch.Size = new System.Drawing.Size(108, 23);
            this.btnHighValueDispatch.TabIndex = 10;
            this.btnHighValueDispatch.Text = "高值耗材发放登记";
            this.btnHighValueDispatch.UseVisualStyleBackColor = true;
            this.btnHighValueDispatch.Click += new System.EventHandler(this.btnHighValueDispatch_Click);
            // 
            // gbOper
            // 
            this.gbOper.Controls.Add(this.btnRecycleReg);
            this.gbOper.Controls.Add(this.btnUseReg);
            this.gbOper.Controls.Add(this.btnFrontUse);
            this.gbOper.Controls.Add(this.btnPreOpertionReg);
            this.gbOper.Controls.Add(this.btnOperationNote);
            this.gbOper.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOper.Location = new System.Drawing.Point(0, 0);
            this.gbOper.Name = "gbOper";
            this.gbOper.Size = new System.Drawing.Size(228, 110);
            this.gbOper.TabIndex = 2;
            this.gbOper.TabStop = false;
            this.gbOper.Text = "手术管理";
            // 
            // btnRecycleReg
            // 
            this.btnRecycleReg.Location = new System.Drawing.Point(4, 80);
            this.btnRecycleReg.Name = "btnRecycleReg";
            this.btnRecycleReg.Size = new System.Drawing.Size(108, 23);
            this.btnRecycleReg.TabIndex = 9;
            this.btnRecycleReg.Text = "术后回收清点";
            this.btnRecycleReg.UseVisualStyleBackColor = true;
            this.btnRecycleReg.Click += new System.EventHandler(this.btnRecycleReg_Click);
            // 
            // btnUseReg
            // 
            this.btnUseReg.Location = new System.Drawing.Point(116, 51);
            this.btnUseReg.Name = "btnUseReg";
            this.btnUseReg.Size = new System.Drawing.Size(108, 23);
            this.btnUseReg.TabIndex = 8;
            this.btnUseReg.Text = "术中使用登记";
            this.btnUseReg.UseVisualStyleBackColor = true;
            this.btnUseReg.Click += new System.EventHandler(this.btnUseReg_Click);
            // 
            // btnFrontUse
            // 
            this.btnFrontUse.Location = new System.Drawing.Point(4, 51);
            this.btnFrontUse.Name = "btnFrontUse";
            this.btnFrontUse.Size = new System.Drawing.Size(108, 23);
            this.btnFrontUse.TabIndex = 7;
            this.btnFrontUse.Text = "术前拆包确认";
            this.btnFrontUse.UseVisualStyleBackColor = true;
            this.btnFrontUse.Click += new System.EventHandler(this.btnFrontUse_Click);
            // 
            // btnPreOpertionReg
            // 
            this.btnPreOpertionReg.Location = new System.Drawing.Point(116, 22);
            this.btnPreOpertionReg.Name = "btnPreOpertionReg";
            this.btnPreOpertionReg.Size = new System.Drawing.Size(108, 23);
            this.btnPreOpertionReg.TabIndex = 6;
            this.btnPreOpertionReg.Text = "手术请领登记";
            this.btnPreOpertionReg.UseVisualStyleBackColor = true;
            this.btnPreOpertionReg.Click += new System.EventHandler(this.btnPreOpertionReg_Click);
            // 
            // btnOperationNote
            // 
            this.btnOperationNote.Location = new System.Drawing.Point(4, 22);
            this.btnOperationNote.Name = "btnOperationNote";
            this.btnOperationNote.Size = new System.Drawing.Size(108, 23);
            this.btnOperationNote.TabIndex = 5;
            this.btnOperationNote.Text = "手术通知单查询";
            this.btnOperationNote.UseVisualStyleBackColor = true;
            this.btnOperationNote.Click += new System.EventHandler(this.btnOperationNote_Click);
            // 
            // pnlPatInfo
            // 
            this.pnlPatInfo.Controls.Add(this.lblScretch);
            this.pnlPatInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPatInfo.Location = new System.Drawing.Point(228, 0);
            this.pnlPatInfo.Name = "pnlPatInfo";
            this.pnlPatInfo.Size = new System.Drawing.Size(209, 496);
            this.pnlPatInfo.TabIndex = 1;
            // 
            // lblScretch
            // 
            this.lblScretch.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblScretch.Location = new System.Drawing.Point(192, 0);
            this.lblScretch.Name = "lblScretch";
            this.lblScretch.Size = new System.Drawing.Size(17, 496);
            this.lblScretch.TabIndex = 0;
            this.lblScretch.Text = "<<";
            this.lblScretch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScretch.Click += new System.EventHandler(this.lblScretch_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(437, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(673, 496);
            this.pnlContainer.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "维护";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 496);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlPatInfo);
            this.Controls.Add(this.pnlFunc);
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.pnlFunc.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbOper.ResumeLayout(false);
            this.pnlPatInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlFunc;
        private GroupBox groupBox2;
        private Button btnAlertQuery;
        private Button btnWorkVolumnStatistic;
        private Button btnTraceQuery;
        private Button btnLocationQuery;
        private GroupBox groupBox3;
        private Button btnInOutStatistics;
        private Button btnStockManage;
        private Button btnWareHouseOutReg;
        private Button btnWareHouseInReg;
        private Button btnHighValueDispatch;
        private GroupBox gbOper;
        private Button btnRecycleReg;
        private Button btnUseReg;
        private Button btnFrontUse;
        private Button btnPreOpertionReg;
        private Button btnOperationNote;
        private Panel pnlPatInfo;
        private Label lblScretch;
        private Panel pnlContainer;
        private Button button1;
        private GroupBox groupBox1;
    }
}