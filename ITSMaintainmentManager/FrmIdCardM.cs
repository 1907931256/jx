using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBManager;
using ITSBase;
using ZhiFa.Base.MessageControl;

namespace ITSMaintainmentManager
{
    public partial class FrmIdCardM : UserControl
    {
        public FrmIdCardM()
        {
            InitializeComponent();
        }

        private void FrmIdCardM_Load(object sender, EventArgs e)
        {
            EnterUpdateStatus(false);
            InitialControls();
            InitialIdCard();
        }

        private void InitialControls()
        {
            cmbType.Items.Add(
                new { Key = EnumDef.TRACE_ID_CATEGORY.高值器械, Value = Enum.GetName(typeof(EnumDef.TRACE_ID_CATEGORY),EnumDef.TRACE_ID_CATEGORY.高值器械) });
            cmbType.Items.Add(
                new { Key = EnumDef.TRACE_ID_CATEGORY.排班医生, Value = Enum.GetName(typeof(EnumDef.TRACE_ID_CATEGORY), EnumDef.TRACE_ID_CATEGORY.排班医生) });
            cmbType.Items.Add(
                new { Key = EnumDef.TRACE_ID_CATEGORY.排班护士, Value = Enum.GetName(typeof(EnumDef.TRACE_ID_CATEGORY), EnumDef.TRACE_ID_CATEGORY.排班护士) });
            cmbType.ValueMember = "Key";
            cmbType.DisplayMember = "Value";
        }

        private void InitialIdCard()
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable queryTable = new DataTable();
            if (operDb.QueryIdCardInfo(ref queryTable) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                if (null != queryTable.Columns[DBConstDef.TEXT_ID_INFO_CATEGORY])
                {
                    foreach (DataRow row in queryTable.Rows)
                    {
                        int category = Convert.ToInt32(Judgement.JudgeDBNullValue(row[DBConstDef.TEXT_ID_INFO_CATEGORY].ToString(), EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                        row[DBConstDef.TEXT_ID_INFO_CATEGORY] = Enum.GetName(typeof(EnumDef.TRACE_ID_CATEGORY), (EnumDef.TRACE_ID_CATEGORY)category);
                    }
                }
                dgv.DataSource = queryTable;
                if (null != dgv.Columns[DBConstDef.ID_INFO_ID])
                    dgv.Columns[DBConstDef.ID_INFO_ID].Visible = false;
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
            cmbType.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_CATEGORY].Value.ToString();
            tbName.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_NAME].Value.ToString();
            tbCode.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_CODE].Value.ToString();
            tbCardNo.Text = dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_NO].Value.ToString();

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
                //Update the value of selected ins
                UpdateInfo();
                EnterUpdateStatus(false);
            }
        }

        private void UpdateInfo()
        {
            int id = Convert.ToInt32(Judgement.JudgeDBNullValue(dgv.SelectedRows[0].Cells[DBConstDef.ID_INFO_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            if (id > 0)
            {
                //apply to datagridview, its datasource and db
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_CATEGORY].Value = cmbType.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_NAME].Value = tbName.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_CODE].Value = tbCode.Text;
                dgv.SelectedRows[0].Cells[DBConstDef.TEXT_ID_INFO_NO].Value = tbCardNo.Text;
                ((DataTable)dgv.DataSource).AcceptChanges();
                DbMaintainment operDb = new DbMaintainment();
                operDb.UpdateIdCardInfo(id, (int)(EnumDef.TRACE_ID_CATEGORY)(cmbType.SelectedItem.GetType().GetProperty("Key").GetValue(cmbType.SelectedItem, null)), tbName.Text, tbCode.Text, tbCardNo.Text);
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
                //insert a new row, db and datatable
                DbMaintainment operDb = new DbMaintainment();
                int id = 0;
                operDb.InsertIdCardInfo(ref id, (int)(EnumDef.TRACE_ID_CATEGORY)(cmbType.SelectedItem.GetType().GetProperty("Key").GetValue(cmbType.SelectedItem, null)), tbName.Text, tbCode.Text, tbCardNo.Text);

                DataRow newRow = ((DataTable) dgv.DataSource).NewRow();
                newRow[DBConstDef.ID_INFO_ID] = id;
                newRow[DBConstDef.TEXT_ID_INFO_CATEGORY] = cmbType.Text;
                newRow[DBConstDef.TEXT_ID_INFO_NAME] = tbName.Text;
                newRow[DBConstDef.TEXT_ID_INFO_CODE] = tbCode.Text;
                newRow[DBConstDef.TEXT_ID_INFO_NO] = tbCardNo.Text;
                ((DataTable) dgv.DataSource).Rows.Add(newRow);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MsgConstDef.MSG_DEL_QUESTION) == DialogResult.Yes)
            {
                //del the selections
                DeleteIdCardInfo();
                ((DataTable)dgv.DataSource).AcceptChanges();
                dgv.ClearSelection();
            }
        }

        private void DeleteIdCardInfo()
        {
            foreach (DataGridViewRow selRow in dgv.SelectedRows)
            {
                int id = Convert.ToInt32(Judgement.JudgeDBNullValue(selRow.Cells[DBConstDef.ID_INFO_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                DbMaintainment operDb = new DbMaintainment();
                operDb.DeleteIdCardInfo(id);
                DataRow[] selRows = ((DataTable)dgv.DataSource).Select(string.Format("{0}={1}", DBConstDef.ID_INFO_ID, id));
                if (selRows.Length>0)
                    ((DataTable)dgv.DataSource).Rows.Remove(selRows[0]);
            }
        }

        private bool CheckInfoValid(ref string errMsg, bool check)
        {
            if (string.IsNullOrEmpty(cmbType.Text))
            {
                errMsg = MsgConstDef.MSG_IDCARD_TYPE_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbName.Text))
            {
                errMsg = MsgConstDef.MSG_IDCARD_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbCode.Text))
            {
                errMsg = MsgConstDef.MSG_IDCARD_CODE_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbCardNo.Text))
            {
                errMsg = MsgConstDef.MSG_IDCARD_NO_EMPTY;
                return false;
            }

            DataTable table =(DataTable) dgv.DataSource;
            if (check && table.Select(String.Format("{0}='{1}'", DBConstDef.TEXT_ID_INFO_CODE, tbCode.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_IDCARD_CODE_EXIST;
                return false;
            }

            if (check && table.Select(String.Format("{0}='{1}'", DBConstDef.TEXT_ID_INFO_NO, tbCardNo.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_IDCARD_NO_EXIST;
                return false;
            }

            return true;
        }
    }
}
