using System;
using System.Windows.Forms;
using ITSBase;
using VTRACK;
using ZhiFa.Base.MessageControl;

namespace Test
{
    public partial class Form2 : Form
    {
        private int _patInfoWidth;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (TrackFactory.Init())
            {
                TrackFactory.SetUserInfo("User_001", "管理员");
                TrackFactory.Host = pnlContainer;
            }
            else
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Exclamation, "警告", "系统初始化失败!");
            }
            _patInfoWidth = pnlPatInfo.Width;
        }

        private void lblScretch_Click(object sender, EventArgs e)
        {
            if (lblScretch.Text == "<<")
            {
                lblScretch.Text = ">>";
                pnlPatInfo.Width = lblScretch.Width;
            }
            else
            {
                lblScretch.Text = "<<";
                pnlPatInfo.Width = _patInfoWidth;
            }
        }
        private void btnLocationQuery_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.LocationQuery);
        }

        private void btnTraceQuery_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.TraceQuery);
        }

        private void btnWorkVolumnStatistic_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.TraceWorkloadAccount);
        }

        private void btnAlertQuery_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.TraceAlertQuery);
        }

        private void btnOperationNote_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.OperationNoteQuery);
        }
        private void btnRecycleReg_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.OperationRecycleReg);
        }

        private void btnPreOpertionReg_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.OperationPreReg);
        }

        private void btnFrontUse_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.OPerationFrontUse);
        }

        private void btnUseReg_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.OperationUseReg);
        }

        private void btnHighValueDispatch_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.HighValueDispatchReg);
        }

        private void btnWareHouseInReg_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.WareHouseInReg);
        }

        private void btnWareHouseOutReg_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.WareHouseOutReg);
        }

        private void btnStockManage_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.WareHouseStock);
        }

        private void btnInOutStatistics_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.WareHouseInOutStatisc);
        }

        private void btnInsM_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.InsMaintainment);
        }

        private void btnDrugM_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.DrugMaintainment);
        }

        private void btnAutoPackageM_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.AutoPackageMaintainment);
        }

        private void btnFactoryM_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.FactoryMaintainment);
        }

        private void btnSterileAreaM_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.SterileAreaMaintainment);
        }

        private void btnIdCardM_Click(object sender, EventArgs e)
        {
            TrackFactory.SwitchToPage(EnumDef.PageSelector.IdCardMaintainment);
        }

    }
}
