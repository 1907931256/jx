using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBManager;
using ITSBase;
using ZhiFa.Base.MessageControl;

namespace ITSMaintainmentManager
{
    public partial class FrmSterileAreaM : UserControl
    {
        public FrmSterileAreaM()
        {
            InitializeComponent();
        }

        private void SterileAreaM_Load(object sender, EventArgs e) 
        {
            EnterUpdateStatus(false);
            InitialControls();
            InitialSterileArea();
        }

        private void InitialControls()
        {
            //initial type
            cmbType.Items.Add(new { Key = EnumDef.STERILE_ROOM_TYPE.CSSD, Value = ConstDef.TEXT_CSSD_STERILEROOM });
            cmbType.Items.Add(new { Key = EnumDef.STERILE_ROOM_TYPE.OP, Value = ConstDef.TEXT_OP_STERILEROOM });
            cmbType.Items.Add(new { Key = EnumDef.STERILE_ROOM_TYPE.FACILITY, Value = ConstDef.TEXT_FACILITY_STERILEROOM });
            cmbType.ValueMember = "Key";
            cmbType.DisplayMember = "Value";

            //initial dept
            DbMaintainment operDb = new DbMaintainment();
            DataTable queryTable = new DataTable();
            if (operDb.QueryDeptInfo(ref queryTable) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                foreach (DataRow row in queryTable.Rows)
                {
                    int id = Convert.ToInt32(Judgement.JudgeDBNullValue(row[DBConstDef.DEPT_ID], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                    string name = Judgement.JudgeDBNullValue(row[ConstDef.TEXT_DEPT_SIMPLE_NAME],EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
                    cmbDept.Items.Add(new { Key = id, Value = name });
                }
                cmbDept.ValueMember = "Key";
                cmbDept.DisplayMember = "Value";
            }
        }

        private void InitialSterileArea()
        {
            DbMaintainment operDb = new DbMaintainment();
            DataTable queryTable = new DataTable();
            if (operDb.QuerySterileAreaInfo(ref queryTable) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                if (null != queryTable.Columns[ConstDef.TEXT_STERILE_AREA_TYPE])
                {
                    foreach (DataRow row in queryTable.Rows)
                    {
                        int type = Convert.ToInt32(Judgement.JudgeDBNullValue(row[ConstDef.TEXT_STERILE_AREA_TYPE].ToString(), EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                        row[ConstDef.TEXT_STERILE_AREA_TYPE] = TransDef.MatchSterileRoomTypeToString((EnumDef.STERILE_ROOM_TYPE)type);
                    }
                }
                dgv.DataSource = queryTable;
                if (null != dgv.Columns[DBConstDef.SI_ID])
                    dgv.Columns[DBConstDef.SI_ID].Visible = false;
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
            cmbType.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_STERILE_AREA_TYPE].Value.ToString();
            tbName.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_STERILE_AREA_NAME].Value.ToString();
            cmbDept.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_DEPT_NAME].Value.ToString();
            cmbRoom.Text = dgv.SelectedRows[0].Cells[ConstDef.TEXT_ROOM_NAME].Value.ToString();

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
                UpdateSterileAreaInfo();
                EnterUpdateStatus(false);
            }
        }

        private void UpdateSterileAreaInfo()
        {
            int id = Convert.ToInt32(Judgement.JudgeDBNullValue(dgv.SelectedRows[0].Cells[DBConstDef.SI_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
            if (id <= 0) return;
            //apply to datagridview, its datasource and db
            dgv.SelectedRows[0].Cells[ConstDef.TEXT_STERILE_AREA_TYPE].Value = cmbType.Text;
            dgv.SelectedRows[0].Cells[ConstDef.TEXT_STERILE_AREA_NAME].Value = tbName.Text;
            dgv.SelectedRows[0].Cells[ConstDef.TEXT_DEPT_NAME].Value = cmbDept.Text;
            dgv.SelectedRows[0].Cells[ConstDef.TEXT_ROOM_NAME].Value = cmbRoom.Text;
            int type = (int)(EnumDef.STERILE_ROOM_TYPE)(cmbType.SelectedItem.GetType().GetProperty("Key").GetValue(cmbType.SelectedItem, null));
            int dept = (int)(cmbDept.SelectedItem.GetType().GetProperty("Key").GetValue(cmbDept.SelectedItem, null));
            int room = -1;
            if (null != cmbRoom.SelectedItem)
                room = (int)(cmbRoom.SelectedItem.GetType().GetProperty("Key").GetValue(cmbRoom.SelectedItem, null));
            ((DataTable)dgv.DataSource).AcceptChanges();
            DbMaintainment operDb = new DbMaintainment();
            operDb.UpdateSterileAreaInfo(id, tbName.Text, type, dept, cmbDept.Text, room, cmbRoom.Text);
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
                int type = (int)(EnumDef.STERILE_ROOM_TYPE)(cmbType.SelectedItem.GetType().GetProperty("Key").GetValue(cmbType.SelectedItem, null));
                int dept = (int)(cmbDept.SelectedItem.GetType().GetProperty("Key").GetValue(cmbDept.SelectedItem, null));
                int room = -1;
                if (null != cmbRoom.SelectedItem)
                    room = (int)(cmbRoom.SelectedItem.GetType().GetProperty("Key").GetValue(cmbRoom.SelectedItem, null));
                operDb.InsertSterileAreaInfo(ref id, tbName.Text, type, dept, cmbDept.Text, room, cmbRoom.Text);

                DataRow newRow = ((DataTable) dgv.DataSource).NewRow();
                newRow[DBConstDef.SI_ID] = id;
                newRow[ConstDef.TEXT_STERILE_AREA_TYPE] = cmbType.Text;
                newRow[ConstDef.TEXT_STERILE_AREA_NAME] = tbName.Text;
                newRow[ConstDef.TEXT_DEPT_NAME] = cmbDept.Text;
                newRow[ConstDef.TEXT_ROOM_NAME] = cmbRoom.Text;
                ((DataTable) dgv.DataSource).Rows.Add(newRow);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (BaseMessageBox.ShowCustomerMessage(MessageBoxIcon.Question, "", MsgConstDef.MSG_DEL_QUESTION) == DialogResult.Yes)
            {
                //del the selections
                DeleteSterileAreaInfo();
                ((DataTable)dgv.DataSource).AcceptChanges();
                dgv.ClearSelection();
            }
        }

        private void DeleteSterileAreaInfo()
        {
            foreach (DataGridViewRow selRow in dgv.SelectedRows)
            {
                int id = Convert.ToInt32(Judgement.JudgeDBNullValue(selRow.Cells[DBConstDef.SI_ID].Value, EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                DbMaintainment operDb = new DbMaintainment();
                operDb.DeleteSterileAreaInfo(id);
                DataRow[] selRows = ((DataTable)dgv.DataSource).Select(string.Format("{0}={1}", DBConstDef.SI_ID, id));
                if (selRows.Length>0)
                    ((DataTable)dgv.DataSource).Rows.Remove(selRows[0]);
            }
        }

        private bool CheckInfoValid(ref string errMsg, bool checkCode)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                errMsg = MsgConstDef.MSG_STERILE_AREA_NAME_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(cmbType.Text))
            {
                errMsg = MsgConstDef.MSG_STERILE_AREA_TYPE_EMPTY;
                return false;
            }

            if (string.IsNullOrEmpty(cmbDept.Text))
            {
                errMsg = MsgConstDef.MSG_STERILE_AREA_DEPT_EMPTY;
                return false;
            }

            if (cmbRoom.Items.Count>0 && string.IsNullOrEmpty(cmbRoom.Text))
            {
                errMsg = MsgConstDef.MSG_STERILE_AREA_ROOM_EMPTY;
                return false;
            }

            DataTable table = (DataTable)dgv.DataSource;
            if (checkCode && table.Select(String.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}'",
                                          ConstDef.TEXT_STERILE_AREA_NAME, tbName.Text, ConstDef.TEXT_STERILE_AREA_TYPE, cmbType.Text,
                                          ConstDef.TEXT_DEPT_NAME, cmbDept.Text, ConstDef.TEXT_ROOM_NAME, cmbRoom.Text)).Length > 0)
            {
                errMsg = MsgConstDef.MSG_STERILE_AREA_EXIST;
                return false;
            }
            return true;
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRoom.Items.Clear();
            int id = (int)(EnumDef.STERILE_ROOM_TYPE)(cmbDept.SelectedItem.GetType().GetProperty("Key").GetValue(cmbDept.SelectedItem, null));
            DbMaintainment operDb = new DbMaintainment();
            DataTable queryTable = new DataTable();
            if (operDb.QueryRoomInfoByDeptId(ref queryTable,id) == EnumDef.DBMEDITS_RESULT.SUCCESS)
            {
                foreach (DataRow row in queryTable.Rows)
                {
                    int roomId = Convert.ToInt32(Judgement.JudgeDBNullValue(row[DBConstDef.ROOM_ID], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_INTEGER));
                    string name = Judgement.JudgeDBNullValue(row[ConstDef.TEXT_ROOM_NAME], EnumDef.ENUM_DATA_TYPE.DATA_TYPE_STRING).ToString();
                    cmbRoom.Items.Add(new { Key = roomId, Value = name });
                }
                cmbRoom.ValueMember = "Key";
                cmbRoom.DisplayMember = "Value";
            }
        }
    }
}
