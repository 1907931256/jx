using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBManager;
using ITSBase;
using ZhiFa.Base.MessageControl;

namespace ITSMaintainmentManager
{
    public partial class FrmDrugManufacturesM : UserControl
    {
        public FrmDrugManufacturesM()
        {
            InitializeComponent();
        }

        private void FrmDrugManufacturesM_Load(object sender, EventArgs e) 
        {
            EnterUpdateStatus(false);
            InitialControls();
            InitialDrugManufactures();
        }

        private void InitialControls()
        {
        
        }

        private void InitialDrugManufactures()
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable queryTable = new DataTable();
            if (operDb.QueryDrugManufacturerInfo(ref queryTable) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                dgv.DataSource = queryTable;
                if (null != dgv.Columns[DBConstDef.PC_ID])
                    dgv.Columns[DBConstDef.PC_ID].Visible = false;
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            btnDel.Enabled = dgv.SelectedRows.Count > 0;
            btnUpdate.Enabled = dgv.SelectedRows.Count == 1;
        }

        private void EnterUpdateStatus(bool status)
        {
            dgv.Enabled = !status;
            btnAdd.Visible = !status;
            btnDel.Visible = !status;
            btnUpdate.Visible = !status;
            btnUpdateConfirm.Visible = status;
            btnUpdateCancel.Visible = status;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tbName.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_COMPANY_NAME].Value.ToString();
            tbInputcode.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_COMPANY_CODE].Value.ToString();

            EnterUpdateStatus(true);
        }

        private void btnUpdateConfirm_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            if (!CheckInfoValid(ref errMsg,false))
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", errMsg, 10);
            }
            else
            {
                //Update the value of selected drug
                UpdateDrugManufacturersInfo();
                EnterUpdateStatus(false);
            }
        }

        private void UpdateDrugManufacturersInfo()
        {
            int id = Convert.ToInt32(Judgement.JudgeDBNullValue(dgv.SelectedRows[0].Cells[DBConstDef.PC_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            if (id <= 0) return;
            //apply to datagridview, its datasource and db
            dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_COMPANY_NAME].Value = tbName.Text;
            dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_COMPANY_CODE].Value = tbInputcode.Text;
            ((DataTable)dgv.DataSource).AcceptChanges();
            DbMaintainment operDb = new DbMaintainment();
            operDb.UpdateDrugManufacturersInfo(id, tbName.Text, tbInputcode.Text);
        }

        private void btnUpdateCancel_Click(object sender, EventArgs e)
        {
            EnterUpdateStatus(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            if (!CheckInfoValid(ref errMsg, true))
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", errMsg);
            }
            else
            {
                //insert a new row,db and datatable
                DbMaintainment operDb = new DbMaintainment();
                int id = 0;
                operDb.InsertDrugManufacturersInfo(ref id, tbName.Text, tbInputcode.Text);

                DataRow newRow = ((DataTable) dgv.DataSource).NewRow();
                newRow[DBConstDef.PC_ID] = id;
                newRow[ConstDef.TEXT_DRUG_COMPANY_NAME] = tbName.Text;
                newRow[ConstDef.TEXT_DRUG_COMPANY_CODE] = tbInputcode.Text;
                ((DataTable) dgv.DataSource).Rows.Add(newRow);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MsgConstDef.MSG_DEL_QUESTION) == DialogResult.Yes)
            {
                //del the selections
                DeleteDrugManufacturersInfo();
                ((DataTable)dgv.DataSource).AcceptChanges();
                dgv.ClearSelection();
            }
        }

        private void DeleteDrugManufacturersInfo()
        {
            foreach (DataGridViewRow selRow in dgv.SelectedRows)
            {
                int id = Convert.ToInt32(Judgement.JudgeDBNullValue(selRow.Cells[DBConstDef.PC_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                DbMaintainment operDb = new DbMaintainment();
                operDb.DeleteDrugManufacturersInfo(id);
                DataRow[] selRows = ((DataTable)dgv.DataSource).Select(string.Format("{0}={1}", DBConstDef.PC_ID, id));
                if (selRows.Length>0)
                    ((DataTable)dgv.DataSource).Rows.Remove(selRows[0]);
            }
        }

        private bool CheckInfoValid(ref string errMsg, bool checkCode)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_MANUFACTURES_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbInputcode.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_MANUFACTURES_INPUTCODE_EMPTY;
                return false;
            }

            DataTable table =(DataTable) dgv.DataSource;
            if (checkCode && table.Select(String.Format("{0}='{1}'", ConstDef.TEXT_DRUG_COMPANY_NAME, tbName.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_DRUG_MANUFACTURES_NAME_EXIST;
                return false;
            }

            return true;
        }
    }
}
