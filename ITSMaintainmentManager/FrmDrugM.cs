using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBManager;
using ITSBase;
using ZhiFa.Base.MessageControl;

namespace ITSMaintainmentManager
{
    public partial class FrmDrugM : UserControl
    {
        public FrmDrugM()
        {
            InitializeComponent();
        }

        private void FrmDrugM_Load(object sender, EventArgs e) 
        {
            EnterUpdateStatus(false);
            InitialControls();
            InitialDrug();
        }

        private void InitialControls()
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable queryTable = new DataTable();
            if (operDb.QueryDrugManufacturerInfo(ref queryTable) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                foreach (DataRow row in queryTable.Rows)
                {
                    string name = (string)Judgement.JudgeDBNullValue(row[ConstDef.TEXT_DRUG_COMPANY_NAME], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING);
                    if (!string.IsNullOrEmpty(name))
                        cmbManufactuer.Items.Add(name);
                }
            }
        }

        private void InitialDrug()
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable drugTable = new DataTable();
            if (operDb.QueryDrugInfo(ref drugTable) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                dgv.DataSource = drugTable;
                if (null != dgv.Columns[DBConstDef.DRUG_ID])
                    dgv.Columns[DBConstDef.DRUG_ID].Visible = false;
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
            tbName.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_NAME].Value.ToString();
            tbInputcode.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_INPUTCODE].Value.ToString();
            tbCommonName.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_PRODUCT_NAME].Value.ToString();
            tbCommonInputcode.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_COMMON_INPUTCODE].Value.ToString();
            cmbManufactuer.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_MANUFACTUER].Value.ToString();
            tbCode.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_CODE].Value.ToString();
            tbSpec.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_SPECIFICATION].Value.ToString();
            tbUnit.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_UNIT].Value.ToString();
            tbPackUnit.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_PACK_UNIT].Value.ToString();
            tbUnitRatio.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_UNIT_RATIO].Value.ToString();

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
                UpdateDrugInfo();
                EnterUpdateStatus(false);
            }
        }

        private void UpdateDrugInfo()
        {
            int drugId = Convert.ToInt32(Judgement.JudgeDBNullValue(dgv.SelectedRows[0].Cells[DBConstDef.DRUG_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            if (drugId > 0)
            {
                //apply to datagridview, its datasource and db
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_NAME].Value = tbName.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_INPUTCODE].Value = tbInputcode.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_PRODUCT_NAME].Value = tbCommonName.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_COMMON_INPUTCODE].Value = tbCommonInputcode.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_MANUFACTUER].Value = cmbManufactuer.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_CODE].Value = tbCode.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_SPECIFICATION].Value = tbSpec.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_UNIT].Value = tbUnit.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_PACK_UNIT].Value = tbPackUnit.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_DRUG_UNIT_RATIO].Value = tbUnitRatio.Text;
                ((DataTable)dgv.DataSource).AcceptChanges();
                DbMaintainment operDb = new DbMaintainment();
                operDb.UpdateDrugInfo(drugId, tbName.Text, tbInputcode.Text, tbCommonName.Text, tbCommonInputcode.Text, cmbManufactuer.Text, tbCode.Text, tbSpec.Text, tbUnit.Text, tbPackUnit.Text, tbUnitRatio.Text);
            }
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
                int drugId = 0;
                operDb.InsertDrugInfo(ref drugId, tbName.Text, tbInputcode.Text, tbCommonName.Text, tbCommonInputcode.Text, cmbManufactuer.Text, tbCode.Text, tbSpec.Text, tbUnit.Text, tbPackUnit.Text, tbUnitRatio.Text);

                DataRow newRow = ((DataTable) dgv.DataSource).NewRow();
                newRow[DBConstDef.DRUG_ID] = drugId;
                newRow[ConstDef.TEXT_DRUG_NAME] = tbName.Text;
                newRow[ConstDef.TEXT_DRUG_INPUTCODE] = tbInputcode.Text;
                newRow[DBConstDef.TEXT_DRUG_PRODUCT_NAME] = tbCommonName.Text;
                newRow[ConstDef.TEXT_DRUG_COMMON_INPUTCODE] = tbCommonInputcode.Text;
                newRow[ConstDef.TEXT_DRUG_MANUFACTUER] = cmbManufactuer.Text;
                newRow[ConstDef.TEXT_DRUG_CODE] = tbCode.Text;
                newRow[DBConstDef.TEXT_DRUG_SPECIFICATION] = tbSpec.Text;
                newRow[DBConstDef.TEXT_DRUG_UNIT] = tbUnit.Text;
                newRow[ConstDef.TEXT_DRUG_PACK_UNIT] = tbPackUnit.Text;
                int ratio = -1;
                if (int.TryParse(tbUnitRatio.Text,out ratio))
                    newRow[ConstDef.TEXT_DRUG_UNIT_RATIO] = ratio;

                ((DataTable) dgv.DataSource).Rows.Add(newRow);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MsgConstDef.MSG_DEL_QUESTION) == DialogResult.Yes)
            {
                //del the selections
                DeleteDrugInfo();
                ((DataTable)dgv.DataSource).AcceptChanges();
                dgv.ClearSelection();
            }
        }

        private void DeleteDrugInfo()
        {
            foreach (DataGridViewRow selRow in dgv.SelectedRows)
            {
                int drugId = Convert.ToInt32(Judgement.JudgeDBNullValue(selRow.Cells[DBConstDef.DRUG_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                DbMaintainment operDb = new DbMaintainment();
                operDb.DeleteDrugInfo(drugId);
                DataRow[] selRows = ((DataTable)dgv.DataSource).Select(string.Format("{0}={1}", DBConstDef.DRUG_ID, drugId));
                if (selRows.Length>0)
                    ((DataTable)dgv.DataSource).Rows.Remove(selRows[0]);
            }
        }

        private bool CheckInfoValid(ref string errMsg, bool checkCode)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbInputcode.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_INPUTCODE_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbCommonName.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_COMMON_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbCommonInputcode.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_COMMON_INPUTCODE_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbCode.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_CODE_EMPTY;
                return false;
            }

            DataTable drugTable =(DataTable) dgv.DataSource;
            if (checkCode && drugTable.Select(String.Format("{0}='{1}'", ConstDef.TEXT_DRUG_CODE, tbCode.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_DRUG_CODE_EXIST;
                return false;
            }

            return true;
        }

        private void tbUnitRatio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9 , 8代表backspace，46代表小数点
            if ((e.KeyChar < Convert.ToChar(48) || e.KeyChar > Convert.ToChar(57)) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(46))
                e.Handled = true;
        }
    }
}
