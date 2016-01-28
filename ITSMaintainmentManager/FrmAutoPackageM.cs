using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBManager;
using ITSBase;
using ZhiFa.Base.MessageControl;

namespace ITSMaintainmentManager
{
    public partial class FrmAutoPackageM : UserControl
    {
        private DataTable _operDict;
        private DataTable _insDict;
        private DataTable _drugDict;
        public FrmAutoPackageM()
        {
            InitializeComponent();
        }

        private void FrmAutoPackageM_Resize(object sender, EventArgs e)
        {
            this.pnlOperList.Width = (int)(0.2 * Width);
            this.pnlIns.Width = (int)(0.4 * Width);
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9 , 8代表backspace，46代表小数点
            if ((e.KeyChar < Convert.ToChar(48) || e.KeyChar > Convert.ToChar(57)) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        private void FrmAutoPackageM_Load(object sender, EventArgs e)
        {
            EnterInsUpdateStatus(false);
            EnterDrugUpdateStatus(false);
            InitialControls();
            InitialInsInfo();
            InitialDrugInfo();
            InitialOperList();
        }

        private void InitialControls()
        {
         
        }

        private void InitialOperList()
        {
            DbMaintainment operDb = new DbMaintainment();
            _operDict = new DataTable();
            if (operDb.QueryOperationDicInfo(ref _operDict) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                BingOperTable();
            }
        }

        private void BingOperTable()
        {
            string filter = tbOperFilter.Text;
            if (!string.IsNullOrEmpty(filter))
                filter = string.Format("{0} like '%{1}%'", ConstDef.TEXT_OPERATION_NAME, filter);
            DataRow[] selectRows = _operDict.Select(filter);
            DataTable filterTable = new DataTable();
            filterTable.Columns.Add(DBConstDef.OPERATION_CODE, typeof (int));
            filterTable.Columns.Add(ConstDef.TEXT_OPERATION_NAME, typeof(string));
            foreach (DataRow selrow in selectRows)
            {
                DataRow newRow = filterTable.NewRow();
                newRow[DBConstDef.OPERATION_CODE] = Judgement.JudgeDBNullValue(selrow[DBConstDef.OPERATION_CODE],EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER);
                newRow[ConstDef.TEXT_OPERATION_NAME] = Judgement.JudgeDBNullValue(selrow[ConstDef.TEXT_OPERATION_NAME], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING);
                filterTable.Rows.Add(newRow);
            }
            dgvOperList.DataSource = filterTable;
            if (null != dgvOperList.Columns[DBConstDef.OPERATION_CODE])
                dgvOperList.Columns[DBConstDef.OPERATION_CODE].Visible = false;
            dgvOperList.ClearSelection();
            ClearIns();
            ClearDrug();
        }
        private void ClearIns()
        {
            ((DataTable)dgvIns.DataSource).Clear();
            ddlInsName.Clear();
            tbInsCode.Clear();
            tbInsSpec.Clear();
            tbInsUnit.Clear();
            tbInsQuantity.Clear();
        }

        private void ClearDrug()
        {
            ((DataTable)dgvDrug.DataSource).Clear();
            ddlDrugName.Clear();
            tbDrugProductName.Clear();
            tbDrugSpec.Clear();
            tbDrugUnit.Clear();
            tbDrugManufacture.Clear();
            tbDrugQuantity.Clear();
            tbDrugCode.Clear();
        }

        private void tbOperFilter_TextChanged(object sender, EventArgs e)
        {
            BingOperTable();
        }

        private void dgvOperList_SelectionChanged(object sender, EventArgs e)
        {
            pnlIns.Enabled = dgvOperList.SelectedRows.Count == 1;
            pnlDrug.Enabled = dgvOperList.SelectedRows.Count == 1;
            if (dgvOperList.SelectedRows.Count != 1)
                return;
            int id = Convert.ToInt32(Judgement.JudgeDBNullValue(dgvOperList.SelectedRows[0].Cells[DBConstDef.OPERATION_CODE].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            LoadIns(id);
            LoadDrug(id);
        }

        private void LoadIns(int operId)
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable insTable = new DataTable();
            operDb.QueryAutoPackageInsInfo(ref insTable, operId.ToString());
            dgvIns.DataSource = insTable;
            if (null != dgvIns.Columns[DBConstDef.OPID_ID])
                dgvIns.Columns[DBConstDef.OPID_ID].Visible = false;
        }

        private void LoadDrug(int operId)
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable drugTable = new DataTable();
            operDb.QueryAutoPackageDrugInfo(ref drugTable, operId.ToString());
            dgvDrug.DataSource = drugTable;
            if (null != dgvDrug.Columns[DBConstDef.OPDD_ID])
                dgvDrug.Columns[DBConstDef.OPDD_ID].Visible = false;
        }

        private void InitialInsInfo()
        {
            _insDict = new DataTable();
            DbOperationManage operDb = new DbOperationManage();
            if (EnumDef.DBMEDITS_RESULT.SUCCESS == operDb.QueryInstrumentInfo(ref _insDict) && !_insDict.IsNullOrEmpty())
            {
                ddlInsName.PressEnter += InsNamePressEnter;
                ddlInsName.ColNoOfCode = 5;
                ddlInsName.IDIndex = 0;
                ddlInsName.DisplayIndex = 3;
                ddlInsName.ColumnWidthCollection = new short[] {0, 0, 100, 200, 0, 0, 150, 75};
                var insName = (TextBox)ddlInsName;
                ddlInsName.Attach(ref insName, _insDict);
            }
            LoadIns(-1);
        }

        private void InsNamePressEnter()
        {
            if (_insDict.IsNullOrEmpty())
                return;
            ListViewItem firstSel = ddlInsName.GetFirstSelListItem();
            if (null == firstSel)
                return;
            DataRow[] selRows = _insDict.Select(String.Format("{0}='{1}'", DBConstDef.INS_CODE, firstSel.Text));
            if (selRows.IsNullOrEmpty())
                return;
            ddlInsName.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.INS_NAME], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbInsCode.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.INS_CODE], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbInsSpec.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.INS_SPEC], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbInsUnit.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.INS_UNIT], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbInsQuantity.Text = String.Empty;
        }

        private void InitialDrugInfo()
        {
            _drugDict = new DataTable();
            DbOperationManage operationManage = new DbOperationManage();
            if (EnumDef.DBMEDITS_RESULT.SUCCESS == operationManage.QueryDrugInfo(ref _drugDict) && !_drugDict.IsNullOrEmpty() )
            {
                ddlDrugName.PressEnter+= DrugNamePressEnter;
                ddlDrugName.ColNoOfCode = 2;
                ddlDrugName.IDIndex = 0;
                ddlDrugName.DisplayIndex = 1;
                ddlDrugName.ColumnWidthCollection = new short[] {0, 100, 0, 150, 0, 100, 125, 50};
                var textBox = ddlDrugName as TextBox;
                ddlDrugName.Attach(ref textBox, _drugDict);
            }
            LoadDrug(-1);
        }

        private void DrugNamePressEnter()
        {
            if (_drugDict.IsNullOrEmpty())
                return;
            ListViewItem firstSel = ddlDrugName.GetFirstSelListItem();
            if( firstSel == null )
                return;
            DataRow[] selRows = _drugDict.Select(String.Format("{0}='{1}'", DBConstDef.DRUG_CODE, firstSel.Text));
            if (selRows.IsNullOrEmpty())
                return;
            tbDrugCode.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.DRUG_CODE], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            ddlDrugName.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.DRUG_COMMON_NAME], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbDrugProductName.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.DRUG_PRODUCT_NAME], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbDrugSpec.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.DRUG_SPECIFICATION], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbDrugManufacture.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.DRUG_MANUFACTURERS], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbDrugUnit.Text = Judgement.JudgeDBNullValue(selRows[0][DBConstDef.DRUG_MEASUER_UNITS], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
            tbDrugQuantity.Text = String.Empty;
        }

        private void dgvIns_SelectionChanged(object sender, EventArgs e)
        {
            btnInsDel.Enabled = dgvIns.SelectedRows.Count > 0;
            btnInsUpdate.Enabled = dgvIns.SelectedRows.Count == 1;
        }

        private void dgvDrug_SelectionChanged(object sender, EventArgs e)
        {
            btnDrugDel.Enabled = dgvDrug.SelectedRows.Count > 0;
            btnDrugUpdate.Enabled = dgvDrug.SelectedRows.Count == 1;
        }

        private void EnterInsUpdateStatus(bool status)
        {
            dgvIns.Enabled = !status;
            btnInsAdd.Visible = !status;
            btnInsDel.Visible = !status;
            btnInsUpdate.Visible = !status;
            btnInsUpdateConfirm.Visible = status;
            btnInsUpdateCancel.Visible = status;
        }

        private void EnterDrugUpdateStatus(bool status)
        {
            dgvDrug.Enabled = !status;
            btnDrugAdd.Visible = !status;
            btnDrugDel.Visible = !status;
            btnDrugUpdate.Visible = !status;
            btnDrugUpdateConfirm.Visible = status;
            btnDrugUpdateCancel.Visible = status;
        }

        private void btnInsAdd_Click(object sender, EventArgs e)
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
                int id = 0;
                int operId = Convert.ToInt32(Judgement.JudgeDBNullValue(dgvOperList.SelectedRows[0].Cells[DBConstDef.OPERATION_CODE].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                int insCount = 0;
                if (!string.IsNullOrEmpty(tbInsQuantity.Text))
                    insCount = Convert.ToInt32(tbInsQuantity.Text);
                operDb.InsertAutoPackageInsInfo(ref id, operId, tbInsCode.Text, insCount);
                DataRow newRow = ((DataTable)dgvIns.DataSource).NewRow();
                newRow[DBConstDef.OPID_ID] = id;
                newRow[ConstDef.TEXT_INS_NAME] = ddlInsName.Text;
                newRow[DBConstDef.TEXT_INS_CODE] = tbInsCode.Text;
                newRow[DBConstDef.TEXT_INS_SPECIFICATION] = tbInsSpec.Text;
                newRow[DBConstDef.TEXT_INS_UNIT] = tbInsUnit.Text;
                newRow[DBConstDef.TEXT_INS_AMOUNT] = tbInsQuantity.Text;
                ((DataTable)dgvIns.DataSource).Rows.Add(newRow);
            }
        }

        private bool CheckInsInfoValid(ref string errMsg, bool check)
        {
            if (string.IsNullOrEmpty(ddlInsName.Text))
            {
                errMsg = MsgConstDef.MSG_INS_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbInsQuantity.Text))
            {
                errMsg = MsgConstDef.MSG_INS_AMOUNT_EMPTY;
                return false;
            }


            DataTable table = (DataTable)dgvIns.DataSource;
            if (check && !table.IsNullOrEmpty() && table.Select(String.Format("{0}='{1}'", DBConstDef.TEXT_INS_CODE, tbInsCode.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_INS_EXIST;
                return false;
            }

            return true;
        }

        private void btnDrugAdd_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            if (!CheckDrugInfoValid(ref errMsg, true))
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", errMsg);
            }
            else
            {
                //insert a new row, db and datatable
                DbMaintainment operDb = new DbMaintainment();
                int id = 0;
                int operId = Convert.ToInt32(Judgement.JudgeDBNullValue(dgvOperList.SelectedRows[0].Cells[DBConstDef.OPERATION_CODE].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                int drugCount = 0;
                if (!string.IsNullOrEmpty(tbDrugQuantity.Text))
                    drugCount = Convert.ToInt32(tbDrugQuantity.Text);
                operDb.InsertAutoPackageDrugInfo(ref id, operId, tbDrugCode.Text, ddlDrugName.Text, tbDrugProductName.Text, tbDrugSpec.Text, tbDrugManufacture.Text,  tbDrugUnit.Text, drugCount);
                DataRow newRow = ((DataTable)dgvDrug.DataSource).NewRow();
                newRow[DBConstDef.OPDD_ID] = id;
                newRow[DBConstDef.TEXT_DRUG_COMMON_NAME] = ddlDrugName.Text;
                newRow[DBConstDef.TEXT_DRUG_PRODUCT_NAME] = tbDrugProductName.Text;
                newRow[DBConstDef.TEXT_DRUG_SPECIFICATION] = tbDrugSpec.Text;
                newRow[DBConstDef.TEXT_DRUG_FACTORY] = tbDrugManufacture.Text;
                newRow[DBConstDef.TEXT_DRUG_UNIT] = tbDrugUnit.Text;
                newRow[DBConstDef.TEXT_DRUG_AMOUNT] = tbDrugQuantity.Text;
                newRow[DBConstDef.TEXT_DRUG_ID] = tbDrugCode.Text;
                ((DataTable)dgvDrug.DataSource).Rows.Add(newRow);
            }
        }

        private bool CheckDrugInfoValid(ref string errMsg, bool check)
        {
            if (string.IsNullOrEmpty(ddlDrugName.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_COMMON_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(tbDrugQuantity.Text))
            {
                errMsg = MsgConstDef.MSG_DRUG_AMOUNT_EMPTY;
                return false;
            }


            DataTable table = (DataTable)dgvDrug.DataSource;
            if (check && !table.IsNullOrEmpty() && table.Select(String.Format("{0}='{1}'", DBConstDef.TEXT_DRUG_ID, tbDrugCode.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_DRUG_EXIST;
                return false;
            }

            return true;
        }

        private void btnInsUpdate_Click(object sender, EventArgs e)
        {
            ddlInsName.Text = dgvIns.SelectedRows[0].Cells[ConstDef.TEXT_INS_NAME].Value.ToString();
            tbInsCode.Text = dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_CODE].Value.ToString();
            tbInsSpec.Text = dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_SPECIFICATION].Value.ToString();
            tbInsUnit.Text = dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_UNIT].Value.ToString();
            tbInsQuantity.Text = dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_AMOUNT].Value.ToString();

            EnterInsUpdateStatus(true);
        }

        private void btnDrugUpdate_Click(object sender, EventArgs e)
        {
            ddlDrugName.Text = dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_COMMON_NAME].Value.ToString();
            tbDrugProductName.Text = dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_PRODUCT_NAME].Value.ToString();
            tbDrugManufacture.Text = dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_FACTORY].Value.ToString();
            tbDrugCode.Text = dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_ID].Value.ToString();
            tbDrugSpec.Text = dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_SPECIFICATION].Value.ToString();
            tbDrugUnit.Text = dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_UNIT].Value.ToString();
            tbDrugQuantity.Text = dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_AMOUNT].Value.ToString();

            EnterDrugUpdateStatus(true);
        }

        private void btnInsUpdateConfirm_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            if (!CheckInsInfoValid(ref errMsg, false))
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", errMsg, 10);
            }
            else
            {
                //Update the value of selected ins
                UpdateInsInfo();
                EnterInsUpdateStatus(false);
            }
        }


        private void UpdateInsInfo()
        {
            int id = Convert.ToInt32(Judgement.JudgeDBNullValue(dgvIns.SelectedRows[0].Cells[DBConstDef.OPID_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            if (id > 0)
            {
                //apply to datagridview, its datasource and db
                dgvIns.SelectedRows[0].Cells[ConstDef.TEXT_INS_NAME].Value = ddlInsName.Text;
                dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_CODE].Value = tbInsCode.Text;
                dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_SPECIFICATION].Value = tbInsSpec.Text;
                dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_UNIT].Value = tbInsUnit.Text;
                dgvIns.SelectedRows[0].Cells[DBConstDef.TEXT_INS_AMOUNT].Value = tbInsQuantity.Text;
                ((DataTable)dgvIns.DataSource).AcceptChanges();
                DbMaintainment operDb = new DbMaintainment();
                int insCount = 0;
                if (!string.IsNullOrEmpty(tbInsQuantity.Text))
                    insCount = Convert.ToInt32(tbInsQuantity.Text);
                operDb.UpdateAutoPackageInsInfo(id, tbInsCode.Text, insCount);
            }
        }

        private void btnDrugUpdateConfirm_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            if (!CheckDrugInfoValid(ref errMsg, false))
            {
                BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Error, "", errMsg, 10);
            }
            else
            {
                //Update the value of selected ins
                UpdateDrugInfo();
                EnterDrugUpdateStatus(false);
            }
        }

        private void UpdateDrugInfo()
        {
            int id = Convert.ToInt32(Judgement.JudgeDBNullValue(dgvDrug.SelectedRows[0].Cells[DBConstDef.OPDD_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            if (id > 0)
            {
                //apply to datagridview, its datasource and db
                dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_COMMON_NAME].Value = ddlDrugName.Text;
                dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_PRODUCT_NAME].Value = tbDrugProductName.Text;
                dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_FACTORY].Value = tbDrugManufacture.Text;
                dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_ID].Value = tbDrugCode.Text;
                dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_SPECIFICATION].Value = tbDrugSpec.Text;
                dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_UNIT].Value = tbDrugUnit.Text;
                dgvDrug.SelectedRows[0].Cells[DBConstDef.TEXT_DRUG_AMOUNT].Value = tbDrugQuantity.Text;
                ((DataTable)dgvDrug.DataSource).AcceptChanges();
                DbMaintainment operDb = new DbMaintainment();
                int drugCount = 0;
                if (!string.IsNullOrEmpty(tbDrugQuantity.Text))
                    drugCount = Convert.ToInt32(tbDrugQuantity.Text);
                operDb.UpdateAutoPackageDrugInfo(id, tbDrugCode.Text, ddlDrugName.Text, tbDrugProductName.Text, tbDrugSpec.Text, tbDrugManufacture.Text, tbDrugUnit.Text, drugCount);
            }
        }

        private void btnInsUpdateCancel_Click(object sender, EventArgs e)
        {
            EnterInsUpdateStatus(false);
        }

        private void btnDrugUpdateCancel_Click(object sender, EventArgs e)
        {
            EnterDrugUpdateStatus(false);
        }

        private void btnInsDel_Click(object sender, EventArgs e)
        {
            if (BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MsgConstDef.MSG_DEL_QUESTION) == DialogResult.Yes)
            {
                //del the selections
                DeleteAutoPackageInsInfo();
                ((DataTable)dgvIns.DataSource).AcceptChanges();
                dgvIns.ClearSelection();
            }
        }

        private void DeleteAutoPackageInsInfo()
        {
            foreach (DataGridViewRow selRow in dgvIns.SelectedRows)
            {
                int id = Convert.ToInt32(Judgement.JudgeDBNullValue(selRow.Cells[DBConstDef.OPID_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                DbMaintainment operDb = new DbMaintainment();
                operDb.DeleteAutoPackageInsInfo(id);
                DataRow[] selRows = ((DataTable)dgvIns.DataSource).Select(string.Format("{0}={1}", DBConstDef.OPID_ID, id));
                if (selRows.Length > 0)
                    ((DataTable)dgvIns.DataSource).Rows.Remove(selRows[0]);
            }
        }

        private void btnDrugDel_Click(object sender, EventArgs e)
        {
            if (BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MsgConstDef.MSG_DEL_QUESTION) == DialogResult.Yes)
            {
                //del the selections
                DeleteAutoPackageDrugInfo();
                ((DataTable)dgvDrug.DataSource).AcceptChanges();
                dgvDrug.ClearSelection();
            }
        }

        private void DeleteAutoPackageDrugInfo()
        {
            foreach (DataGridViewRow selRow in dgvDrug.SelectedRows)
            {
                int id = Convert.ToInt32(Judgement.JudgeDBNullValue(selRow.Cells[DBConstDef.OPDD_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                DbMaintainment operDb = new DbMaintainment();
                operDb.DeleteAutoPackageDrugInfo(id);
                DataRow[] selRows = ((DataTable)dgvDrug.DataSource).Select(string.Format("{0}={1}", DBConstDef.OPDD_ID, id));
                if (selRows.Length > 0)
                    ((DataTable)dgvDrug.DataSource).Rows.Remove(selRows[0]);
            }
        }
    }
}
