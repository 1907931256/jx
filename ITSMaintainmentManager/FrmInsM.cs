using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBManager;
using ITSBase;
using ZhiFa.Base.MessageControl;

namespace ITSMaintainmentManager
{
    public partial class FrmInsM : UserControl
    {
        public FrmInsM()
        {
            InitializeComponent();
        }

        private void FrmInsM_Load(object sender, EventArgs e)
        {
            EnterUpdateStatus(false);
            InitialControls();
            InitialIns();
        }

        private void InitialControls()
        {
            cmbINSType.Items.Add(
                new {Key = EnumDef.INS_KINDS.WAREHOUSE_SU, Value = ConstDef.TEXT_WAREHOUSE_IN_REG_TYPE_WAREHOUSE_INS});
            cmbINSType.Items.Add(
                new {Key = EnumDef.INS_KINDS.HIGH_VALUE, Value = ConstDef.TEXT_WAREHOUSE_IN_REG_TYPE_HIGN_VALUE});
            cmbINSType.Items.Add(
                new {Key = EnumDef.INS_KINDS.OP_INSTRUMENTS, Value = ConstDef.TEXT_WAREHOUSE_IN_REG_TYPE_DRUG});
            cmbINSType.ValueMember = "Key";
            cmbINSType.DisplayMember = "Value";
        }

        private void InitialIns()
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable insTable = new DataTable();
            if (operDb.QueryInsInfo(ref insTable) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                if (null != insTable.Columns[ConstDef.TEXT_CONST_IND_KIND])
                {
                    foreach (DataRow row in insTable.Rows)
                    {
                        int kind = Convert.ToInt32(Judgement.JudgeDBNullValue(row[ConstDef.TEXT_CONST_IND_KIND].ToString(), EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                        row[ConstDef.TEXT_CONST_IND_KIND] = TransDef.MatchInsKindToString((EnumDef.INS_KINDS) kind);
                    }
                }
                dgv.DataSource = insTable;
                if (null != dgv.Columns[DBConstDef.INS_ID])
                    dgv.Columns[DBConstDef.INS_ID].Visible = false;
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
            cmbINSType.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_CONST_IND_KIND].Value.ToString();
            tbProductName.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_INS_NAME].Value.ToString();
            tbCommonName.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_INS_PRODUCT_NAME].Value.ToString();
            tbCode.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_INS_CODE].Value.ToString();
            tbSpec.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_INS_SPECIFICATION].Value.ToString();
            txtINSUnit.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_INS_UNIT].Value.ToString();
            tbInputcode.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_INS_INPUTCODE].Value.ToString();

            EnterUpdateStatus(true);
        }

        private void btnUpdateConfirm_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            if (!CheckInsInfoValid(ref errMsg,false))
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", errMsg, 10);
            }
            else
            {
                //Update the value of selected ins
                UpdateInsInfo();
                EnterUpdateStatus(false);
            }
        }

        private void UpdateInsInfo()
        {
            int insId = Convert.ToInt32(Judgement.JudgeDBNullValue(dgv.SelectedRows[0].Cells[DBConstDef.INS_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            if (insId > 0)
            {
                //apply to datagridview, its datasource and db
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_CONST_IND_KIND].Value = cmbINSType.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_INS_NAME].Value = tbProductName.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_INS_PRODUCT_NAME].Value = tbCommonName.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_INS_CODE].Value = tbCode.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_INS_SPECIFICATION].Value = tbSpec.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_INS_UNIT].Value = txtINSUnit.Text;
                dgv.SelectedRows[0].Cells[ConstDef.TEXT_INS_INPUTCODE].Value = tbInputcode.Text;
                ((DataTable)dgv.DataSource).AcceptChanges();
                DbMaintainment operDb = new DbMaintainment();
                operDb.UpdateInsInfo(insId, (int)(EnumDef.INS_KINDS)(cmbINSType.SelectedItem.GetType().GetProperty("Key").GetValue(cmbINSType.SelectedItem, null)), tbProductName.Text, tbCommonName.Text, tbCode.Text, tbSpec.Text, txtINSUnit.Text, tbInputcode.Text);
            }
        }

        private void btnUpdateCancel_Click(object sender, EventArgs e)
        {
            EnterUpdateStatus(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            if (!CheckInsInfoValid(ref errMsg, true))
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", errMsg);
            }
            else
            {
                //insert a new row, db and datatable
                DbMaintainment operDb = new DbMaintainment();
                int insId = 0;
                operDb.InsertInsInfo(ref insId, (int)(EnumDef.INS_KINDS)(cmbINSType.SelectedItem.GetType().GetProperty("Key").GetValue(cmbINSType.SelectedItem, null)), tbProductName.Text, tbCommonName.Text, tbCode.Text, tbSpec.Text, txtINSUnit.Text, tbInputcode.Text);

                DataRow newRow = ((DataTable) dgv.DataSource).NewRow();
                newRow[DBConstDef.INS_ID] = insId;
                newRow[ConstDef.TEXT_CONST_IND_KIND] = cmbINSType.Text;
                newRow[ConstDef.TEXT_INS_NAME] = tbProductName.Text;
                newRow[ConstDef.TEXT_INS_PRODUCT_NAME] = tbCommonName.Text;
                newRow[DBConstDef.TEXT_INS_CODE] = tbCode.Text;
                newRow[DBConstDef.TEXT_INS_SPECIFICATION] = tbSpec.Text;
                newRow[DBConstDef.TEXT_INS_UNIT] = txtINSUnit.Text;
                newRow[ConstDef.TEXT_INS_INPUTCODE] = tbInputcode.Text;
                ((DataTable) dgv.DataSource).Rows.Add(newRow);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MsgConstDef.MSG_DEL_QUESTION) == DialogResult.Yes)
            {
                //del the selections
                DeleteInsInfo();
                ((DataTable)dgv.DataSource).AcceptChanges();
                dgv.ClearSelection();
            }
        }

        private void DeleteInsInfo()
        {
            foreach (DataGridViewRow selRow in dgv.SelectedRows)
            {
                int insId = Convert.ToInt32(Judgement.JudgeDBNullValue(selRow.Cells[DBConstDef.INS_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                DbMaintainment operDb = new DbMaintainment();
                operDb.DeleteInsInfo(insId);
                DataRow[] selRows =((DataTable) dgv.DataSource).Select(string.Format("{0}={1}", DBConstDef.INS_ID, insId));
                if (selRows.Length>0)
                    ((DataTable)dgv.DataSource).Rows.Remove(selRows[0]);
            }
        }

        private bool CheckInsInfoValid(ref string errMsg, bool checkCode)
        {
            if (string.IsNullOrEmpty(cmbINSType.Text))
            {
                errMsg = MsgConstDef.MSG_INS_TYPE_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbProductName.Text))
            {
                errMsg = MsgConstDef.MSG_INS_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbCode.Text))
            {
                errMsg = MsgConstDef.MSG_INS_CODE_EMPTY;
                return false;
            }

            DataTable insTable =(DataTable) dgv.DataSource;
            if (checkCode && insTable.Select(String.Format("{0}='{1}'", DBConstDef.TEXT_INS_CODE, tbCode.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_INS_CODE_EXIST;
                return false;
            }

            if (string.IsNullOrEmpty(tbInputcode.Text))
            {
                errMsg = MsgConstDef.MSG_INS_INPUTCODE_EMPTY;
                return false;
            }

            return true;
        }
    }
}
