using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using System.Globalization;
using System.Drawing;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ShippingForm : FormCommonNCVP
    {
        public ShippingForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        DataGridViewButtonColumn openBoxId;
        DataGridViewButtonColumn editShipDate;
        DataTable dtOverall = new DataTable();     

        // Sub procedure: Add button to datagridview
        private void addButtonsToDataGridView(DataGridView dgv)
        {
            // Set OPEN button for every user
            openBoxId = new DataGridViewButtonColumn();
            openBoxId.HeaderText = "Open";
            openBoxId.Text = "Open";
            openBoxId.UseColumnTextForButtonValue = true;
            openBoxId.Width = 80;
            dgv.Columns.Add(openBoxId);

            // Set SHIPPING button only for the super user
            if (txtUser.Text == "User_9")
            {
                editShipDate = new DataGridViewButtonColumn();
                editShipDate.HeaderText = "Ship";
                editShipDate.Text = "Ship";
                editShipDate.UseColumnTextForButtonValue = true;
                editShipDate.Width = 80;
                dgv.Columns.Add(editShipDate);
            }
        }

        private void ShippingForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<GA1ModelVo> getList = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new GetBoxIDCbm(), new GA1ModelVo { PrintDate = DateTime.Today });
            dgvBoxId.DataSource = getList.GetList();
            addButtonsToDataGridView(dgvBoxId);
            ShowRowNumber(dgvBoxId);
        }

        private void btnSearchBoxId_Click(object sender, EventArgs e)
        {
            if (rdbPrintDate.Checked == false && rdbShipDate.Checked == false && rdbProductSerial.Checked == false)
            {
                MessageBox.Show(Properties.Resources.vnce00001, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdbPrintDate.Checked == true || rdbShipDate.Checked == true)
            {
                ValueObjectList<GA1ModelVo> getList = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchBoxIDCbm(), new GA1ModelVo
                {
                    PrintDate = dtpPrintDate.Value,
                    ShipDate = dtpShipDate.Value
                });
                dgvBoxId.DataSource = getList.GetList();
            }

            if (rdbProductSerial.Checked == true)
            {
                ValueObjectList<GA1ModelVo> getList = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchBoxIDProCbm(), new GA1ModelVo
                {
                    A90Barcode = txtProductSerial.Text
                });
                dgvBoxId.DataSource = getList.GetList();
            }
            addButtonsToDataGridView(dgvBoxId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ResetControlValues.ResetControlValue(tableLayoutPanel2);
            ResetControlValues.ResetControlValue(tableLayoutPanel3);
            dgvProductSerial.Rows.Clear();
            txtLimit.Text = "100";
        }

        private void btnChangeLimit_Click(object sender, EventArgs e)
        {
            if (btnChangeLimit.Text == "Change Limit")
            {
                btnChangeLimit.Text = "OK";
                txtLimit.Enabled = true;
            }
            else
            {
                btnChangeLimit.Text = "Change Limit";
                txtLimit.Enabled = false;
            }
        }

        private void txtLimit_Leave(object sender, EventArgs e)
        {
            if (txtLimit.Enabled)
            {
                MessageBox.Show("You need to save the limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLimit.Focus();
            }
        }

        private void btnAddBox_Click(object sender, EventArgs e)
        {
            defineDataTable(ref dtOverall);
            splMain.Panel2.Enabled = true;
            txtBoxId.Text = getNewBoxId();
            txtUser.Text = UserData.GetUserData().UserCode;
        }

        // Sub procedure: Issue new box id
        private string getNewBoxId()
        {
            ValueObjectList<GA1ModelVo> outd = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new GetNewBoxIDCbm(), new GA1ModelVo());

            string boxIdOld = outd.GetList()[0].BoxID;

            DateTime dateOld = new DateTime(0);
            long numberOld = 0;
            string boxIdNew;

            if (boxIdOld != string.Empty)
            {
                dateOld = DateTime.ParseExact(VBStrings.Mid(boxIdOld, 4, 6), "yyMMdd", CultureInfo.InvariantCulture);
                numberOld = long.Parse(VBStrings.Right(boxIdOld, 2));
            }

            if (dateOld != DateTime.Today)
            {
                boxIdNew = "GA1" + "-" + DateTime.Today.ToString("yyMMdd") + "01";
            }
            else
            {
                boxIdNew = "GA1" + "-" + DateTime.Today.ToString("yyMMdd") + (numberOld + 1).ToString("00");
            }

            return boxIdNew;
        }

        private void btnRegisterBoxId_Click(object sender, EventArgs e)
        {
            GA1ModelVo outVo = new GA1ModelVo();
            outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddBoxIDCbm(), new GA1ModelVo
            {
                BoxID = txtBoxId.Text,
                User = txtUser.Text
            });
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Disenalbe the extbox to block scanning
                txtProduct.Enabled = false;

               
                DataTable dt1 = new DataTable();
                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDProductCbm(), new GA1ModelVo
                {
                    A90Barcode = txtProduct.Text
                });
                dt1 = getList.dt;

                // Even when no tester data is found, the module have to appear in the datagridview
                DataRow newrow = dtOverall.NewRow();

                // If tester data exists, show it in the datagridview
                if (dt1.Rows.Count != 0)
                {
                    string serial = dt1.Rows[0][0].ToString();
                    string model = dt1.Rows[0][1].ToString();
                    string line = dt1.Rows[0][2].ToString();
                    string thurst = dt1.Rows[0][3].ToString();
                    string noise = dt1.Rows[0][4].ToString();
                    string oqc = dt1.Rows[0][5].ToString();

                    newrow["a90_barcode"] = serial;
                    newrow["a90_model"] = model;
                    newrow["a90_line"] = line;
                    newrow["a90_thurst_status"] = thurst;
                    newrow["a90_noise_status"] = noise;
                    newrow["a90_oqc_status"] = oqc;
                }

                // Add the row to the datatable
                dtOverall.Rows.Add(newrow);
                dgvProductSerial.DataSource = dtOverall;
                ShowRowNumber(dgvProductSerial);
                colorViewForFailAndBlank(ref dgvProductSerial);
                colorViewForDuplicateSerial(ref dgvProductSerial);
                colorMixedConfig(dtOverall, ref dgvProductSerial);
                txtProduct.Focus();
            }
        }

        // Sub procedure: Mark the test results with FAIL or missing test records
        private void colorViewForFailAndBlank(ref DataGridView dgv)
        {
            int rowCount = dgv.BindingContext[dgv.DataSource, dgv.DataMember].Count;
            for (int i = 0; i < rowCount; i++)
            {
                if (dgv[3, i].Value.ToString() == "NG" || dgv[3, i].Value.ToString() == String.Empty)
                {
                    dgv[3, i].Style.BackColor = Color.Red;
                }
                if (dgv[4, i].Value.ToString() == "NG" || dgv[4, i].Value.ToString() == String.Empty)
                {
                    dgv[4, i].Style.BackColor = Color.Red;
                }
                if (dgv[5, i].Value.ToString() == "NG" || dgv[5, i].Value.ToString() == String.Empty)
                {
                    dgv[5, i].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv[3, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    dgv[4, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    dgv[5, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        // Sub procesure: Mark product serials with duplicate or character length error
        private void colorViewForDuplicateSerial(ref DataGridView dgv)
        {
            DataTable dt = ((DataTable)dgv.DataSource).Copy();
            if (dt.Rows.Count <= 0) return;

            for (int i = 0; i < dtOverall.Rows.Count; i++)
            {
                string serial = dgv[0, i].Value.ToString();
                DataRow[] dr = dt.Select("a90_barcode = '" + serial + "'");
                if (dr.Length >= 2)
                {
                    dgv[0, i].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv[0, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        // Sub procesure: Mark config with duplicate or character length error
        private void colorMixedConfig(DataTable dt, ref DataGridView dgv)
        {
            if (dt.Rows.Count <= 0) return;
            string line;
            DataTable distinct = dt.DefaultView.ToTable(true, new string[] { "a90_line" });

            if (distinct.Rows.Count == 1)
                line = distinct.Rows[0]["a90_line"].ToString();

            if (distinct.Rows.Count >= 2)
            {
                string A = distinct.Rows[0]["a90_line"].ToString();
                string B = distinct.Rows[1]["a90_line"].ToString();
                int a = distinct.Select("a90_line = '" + A + "'").Length;
                int b = distinct.Select("a90_line = '" + B + "'").Length;

                // Œ”‚Ì‘½‚¢ƒRƒ“ƒtƒBƒO‚ðA‚±‚Ì” ‚ÌƒƒCƒ“ƒ‚ƒfƒ‹‚Æ‚·‚é
                line = a > b ? A : B;

                // Œ”‚Ì­‚È‚¢‚Ù‚¤‚ÌƒƒCƒ“ƒ‚ƒfƒ‹•¶Žš‚ðŽæ“¾‚µAƒZƒ‹”Ô’n‚ð“Á’è‚µ‚Äƒ}[ƒN‚·‚é
                string C = a < b ? A : B;
                int c = -1;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["a90_line"].ToString() == C) { c = i; }
                }

                if (c != -1)
                {
                    dgv["a90_line", c].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv.Columns["a90_line"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        private void defineDataTable(ref DataTable dt)
        {
            string boxId = txtBoxId.Text;
            dt.Columns.Add("a90_barcode", Type.GetType("System.String"));
            dt.Columns.Add("a90_model", Type.GetType("System.String"));
            dt.Columns.Add("a90_line", Type.GetType("System.String"));
            dt.Columns.Add("a90_thurst_status", Type.GetType("System.String"));
            dt.Columns.Add("a90_noise_status", Type.GetType("System.String"));
            dt.Columns.Add("a90_oqc_status", Type.GetType("System.String"));
        }

        public void ShowRowNumber(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
        }

        // Delete all records on datagridview, by the user's click on the delete all button
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            int rowCount = dgvProductSerial.Rows.Count;
            if (rowCount != 0)
            {
                DialogResult result = MessageBox.Show("Do you really want to delete all the record?",
                    "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    dtOverall.Clear();
                    dtOverall.AcceptChanges();
                    dgvProductSerial.Rows.Clear();
                    txtProduct.Focus();
                    defineDataTable(ref dtOverall);
                }
            }
        }

        // Delete records on datagridview selected by the user
        private void btnDeleteSelection_Click(object sender, EventArgs e)
        {
            if (dgvProductSerial.Columns.GetColumnCount(DataGridViewElementStates.Selected) >= 2)
            {
                MessageBox.Show("Please select range with only one columns.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to delete the selected rows?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewCell cell in dgvProductSerial.SelectedCells)
                {
                    int i = cell.RowIndex;
                    dtOverall.Rows[i].Delete();
                }
                dtOverall.AcceptChanges();
                dgvProductSerial.Rows.Clear();
                txtProduct.Focus();
                defineDataTable(ref dtOverall);
            }
        }
    }
}