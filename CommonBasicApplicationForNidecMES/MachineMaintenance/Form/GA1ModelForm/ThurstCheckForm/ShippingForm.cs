using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using System.Globalization;
using System.Drawing;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ShippingForm : FormCommonNCVP
    {
        string directory = @"C:\Users\mt-qc20\Desktop\print\"; //@"\\192.168.145.7\ncvp\print\";

        public ShippingForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
            dgvBoxId.AutoGenerateColumns = false;
        }

        DataGridViewButtonColumn openBoxId;
        DataGridViewButtonColumn editShipDate;
        DataTable dtOverall;
        bool res;

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
            selectdata();
            addButtonsToDataGridView(dgvBoxId);
            ShowRowNumber(dgvBoxId);
        }

        #region CLICK EVENT

        private void btnSearchBoxId_Click(object sender, EventArgs e)
        {
            if (rdbPrintDate.Checked == false && rdbShipDate.Checked == false && rdbProductSerial.Checked == false)
            {
                MessageBox.Show(Properties.Resources.vnce00001, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdbPrintDate.Checked == true)
            {
                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDCbm(), new GA1ModelVo
                {
                    PrintDate = dtpPrintDate.Value.Date
                });
                dgvBoxId.DataSource = getList.dt;
            }

            if (rdbShipDate.Checked == true)
            {
                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDCbm(), new GA1ModelVo
                {
                    ShipDate = dtpShipDate.Value.Date
                });
                dgvBoxId.DataSource = getList.dt;
            }

            if (rdbProductSerial.Checked == true)
            {
                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDProCbm(), new GA1ModelVo
                {
                    A90Barcode = txtProductSerial.Text
                });
                dgvBoxId.DataSource = getList.dt;
            }
            //addButtonsToDataGridView(dgvBoxId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (res)
            {
                ResetControlValues.ResetControlValue(tableLayoutPanel2);
                ResetControlValues.ResetControlValue(tableLayoutPanel3);
                dtOverall.Reset();
                dtOverall.AcceptChanges();
                //dgvProductSerial.Rows.Clear();
                btnDeleteAll.PerformClick();
                txtLimit.Text = "100";
                splMain.Panel2.Enabled = false;
                splMain.Panel1Collapsed = false;
            }
            else
            {
                ResetControlValues.ResetControlValue(tableLayoutPanel2);
                ResetControlValues.ResetControlValue(tableLayoutPanel3);
                btnDeleteAll.PerformClick();
                //dgvProductSerial.Rows.Clear();
                txtLimit.Text = "100";
                splMain.Panel2.Enabled = false;
                splMain.Panel1Collapsed = false;
            }
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
                limitOkChange();
            }
        }

        private void btnAddBox_Click(object sender, EventArgs e)
        {
            dtOverall = new DataTable();
            defineDataTable(ref dtOverall);
            splMain.Panel2.Enabled = true;
            txtProduct.Enabled = true;
            txtUser.Enabled = true;
            splMain.Panel1Collapsed = true;
            btnDeleteAll.Enabled = true;
            btnDeleteSelection.Enabled = true;
            txtLimit.Text = "100";
            txtBoxId.Text = getNewBoxId();
            res = true;
        }

        private void btnRegisterBoxId_Click(object sender, EventArgs e)
        {
            string boxIdNew;
            if (btnRegisterBoxId.Text == "Register Box ID")
            {
                if (String.IsNullOrEmpty(txtUser.Text))
                {
                    messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lblUser.Text);
                    popUpMessage.Warning(messageData, Text);
                    txtUser.Focus();
                    return;
                }

                GA1ModelVo outVo = new GA1ModelVo();
                outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddBoxIDCbm(), new GA1ModelVo
                {
                    BoxID = txtBoxId.Text,
                    User = txtUser.Text
                });

                for (int i = 0; i < dgvProductSerial.Rows.Count; i++)
                {
                    outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddProductCbm(), new GA1ModelVo
                    {
                        BoxID = txtBoxId.Text,
                        A90Barcode = dgvProductSerial["Serial", i].Value.ToString(),
                        LineCode = dgvProductSerial["Line", i].Value.ToString(),
                        Lot = dgvProductSerial["Lot", i].Value.ToString(),
                        ModelCode = dgvProductSerial["Model", i].Value.ToString(),
                        A90ThurstStatus = dgvProductSerial["Thurst", i].Value.ToString()
                        //A90NoiseStatus = dgvProductSerial["Noise", i].Value.ToString()
                    });
                }

                // Issue new box id
                
                boxIdNew = getNewBoxId();

                // Print barcode
                printBarcode(directory, txtBoxId.Text, "GA1", dgvDateCode, ref dgvDateCode2, ref txtBoxIdPrint);

                // Clear the datatable
                dtOverall.Clear();

                txtBoxId.Text = boxIdNew;
                dtpPrintDate.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 5, 6), "yyMMdd", CultureInfo.InvariantCulture);
                MessageBox.Show("BoxID is registered", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                boxIdNew = txtBoxId.Text;
                // Print barcode
                printBarcode(directory, boxIdNew, "GA1", dgvDateCode, ref dgvDateCode2, ref txtBoxIdPrint);

                // Clear the datatable
                dtOverall.Clear();

                txtBoxId.Text = boxIdNew;
                dtpPrintDate.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 5, 6), "yyMMdd", CultureInfo.InvariantCulture);
            }
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
                    //dgvProductSerial.Rows.Clear();
                    txtProduct.Focus();
                    //defineDataTable(ref dtOverall);
                    updateDataGripViewsSub(dtOverall, ref dgvProductSerial);
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

            DialogResult result = MessageBox.Show("Do you really want to delete the selected rows ?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewCell cell in dgvProductSerial.SelectedCells)
                {
                    int i = cell.RowIndex;
                    dtOverall.Rows[i].Delete();
                }
                dtOverall.AcceptChanges();
                //dgvProductSerial.Rows.Clear();
                txtProduct.Focus();
                //defineDataTable(ref dtOverall);
                updateDataGripViewsSub(dtOverall, ref dgvProductSerial);
            }
        }

        private void dgvBoxId_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = int.Parse(e.RowIndex.ToString());
            DataTable dt_temp = new DataTable();
            // OPEN button generate frmModule by view mode without delegate event
            if (dgvBoxId.Columns[e.ColumnIndex] == openBoxId && currentRow >= 0)
            {
                txtBoxId.Text = dgvBoxId["boxid", currentRow].Value.ToString();
                dtpPrint.Value = DateTime.Parse(dgvBoxId["printdate", currentRow].Value.ToString());
                txtUser.Text = dgvBoxId["suser", currentRow].Value.ToString();

                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetSerialBoxCbm(), new GA1ModelVo
                {
                    BoxID = txtBoxId.Text
                });
                defineDataTable(ref dt_temp);
                dt_temp = getList.dt;
                dgvProductSerial.DataSource = dt_temp;
                splMain.Panel2.Enabled = true;
                txtProduct.Enabled = false;
                txtUser.Enabled = false;
                btnDeleteAll.Enabled = false;
                btnDeleteSelection.Enabled = false;
                btnDeleteBoxId.Enabled = true;
                btnRegisterBoxId.Text = "Re-Print";
                btnRegisterBoxId.Enabled = true;
                //getOkCount(dt_temp);
                txtLimit.Text = dgvProductSerial.RowCount.ToString();
                res = false;
                updateDataGripViewsSub(dt_temp, ref dgvProductSerial);
            }

            // SHIP button edit the shipping date for box id
            if (dgvBoxId.Columns[e.ColumnIndex] == editShipDate && currentRow >= 0)
            {
                string boxId = dgvBoxId["boxid", currentRow].Value.ToString();
                DateTime shipdate = dtpShipDate.Value;

                DialogResult result1 = MessageBox.Show("Do you want to update the shipping date of as follows:" + System.Environment.NewLine +
                    boxId + ": " + shipdate, "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result1 == DialogResult.Yes)
                {
                    GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new UpdateShipdateCbm(), new GA1ModelVo
                    {
                        BoxID = dgvBoxId["boxid", currentRow].Value.ToString(),
                        ShipDate = DateTime.Parse(dgvBoxId["shipdate", currentRow].Value.ToString())
                    });
                    selectdata();
                }
                updateDataGripViewsSub(dt_temp, ref dgvProductSerial);
            }
        }

        private void btnDeleteBoxId_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete this box ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                GA1ModelVo deleteBox = (GA1ModelVo)DefaultCbmInvoker.Invoke(new DeleteBoxIDCbm(), new GA1ModelVo
                {
                    BoxID = txtBoxId.Text
                });

                GA1ModelVo delProduct = (GA1ModelVo)DefaultCbmInvoker.Invoke(new DeleteProductCbm(), new GA1ModelVo
                {
                    BoxID = txtBoxId.Text
                });
                MessageBox.Show("Delete successful!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            updateDataGripViewsSub(dtOverall, ref dgvProductSerial);
        }

        #endregion

        #region VOID

        private void selectdata()
        {
            GA1ModelVo getList = null;
            try
            {
                getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetBoxIDCbm(), new GA1ModelVo
                {
                    PrintDate = DateTime.Today
                });
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            dgvBoxId.DataSource = getList.dt;
        }

        private void limitOkChange()
        {
            // Store the OK record count to the variable and show in the text box
            int okCount = getOkCount(dtOverall);
            txtOkCount.Text = okCount + "/" + txtLimit.Text;

            // If the OK record count has already reached to the capacity, disenable the scan text box
            if (okCount == int.Parse(txtLimit.Text))
                txtProduct.Enabled = false;
            else
                txtProduct.Enabled = true;

            // If the OK record coutn has already reached to the capacity, enable the register button
            if (okCount == int.Parse(txtLimit.Text) && dgvProductSerial.Rows.Count == int.Parse(txtLimit.Text))
                btnRegisterBoxId.Enabled = true;
            else
                btnRegisterBoxId.Enabled = false;
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
                dateOld = DateTime.ParseExact(VBStrings.Mid(boxIdOld, 5, 6), "yyMMdd", CultureInfo.InvariantCulture);
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

        // Sub procedure: Print barcode, by generating a text file in shared folder and let another application print it
        private void printBarcode(string dir, string id, string m_model, DataGridView dgv1, ref DataGridView dgv2, ref TextBox txt)
        {
            PrintLabel tf = new PrintLabel();
            tf.createBoxidFiles(dir, id, m_model, dgv1, ref dgv2, ref txt);
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
                //if (dgv[4, i].Value.ToString() == "NG" || dgv[4, i].Value.ToString() == String.Empty)
                //{
                //    dgv[4, i].Style.BackColor = Color.Red;
                //}
                //if (dgv[5, i].Value.ToString() == "NG" || dgv[5, i].Value.ToString() == String.Empty)
                //{
                //    dgv[5, i].Style.BackColor = Color.Red;
                //}
                else
                {
                    dgv[3, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    //dgv[4, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    //dgv[5, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
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
                string serial = dgv["Serial", i].Value.ToString();
                DataRow[] dr = dt.Select("Serial = '" + serial + "'");
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
            DataTable distinct = dt.DefaultView.ToTable(true, new string[] { "Line" });

            if (distinct.Rows.Count == 1)
                line = distinct.Rows[0]["Line"].ToString();

            if (distinct.Rows.Count >= 2)
            {
                string A = distinct.Rows[0]["Line"].ToString();
                string B = distinct.Rows[1]["Line"].ToString();
                int a = distinct.Select("Line = '" + A + "'").Length;
                int b = distinct.Select("Line = '" + B + "'").Length;

                // Œ”‚Ì‘½‚¢ƒRƒ“ƒtƒBƒO‚ðA‚±‚Ì” ‚ÌƒƒCƒ“ƒ‚ƒfƒ‹‚Æ‚·‚é
                line = a > b ? A : B;

                // Œ”‚Ì­‚È‚¢‚Ù‚¤‚ÌƒƒCƒ“ƒ‚ƒfƒ‹•¶Žš‚ðŽæ“¾‚µAƒZƒ‹”Ô’n‚ð“Á’è‚µ‚Äƒ}[ƒN‚·‚é
                string C = a < b ? A : B;
                int c = -1;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Line"].ToString() == C) { c = i; }
                }

                if (c != -1)
                {
                    dgv["Line", c].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv.Columns["Line"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        private void defineDataTable(ref DataTable dt)
        {
            string boxId = txtBoxId.Text;
            dt.Columns.Add("Serial", Type.GetType("System.String"));
            dt.Columns.Add("Model", Type.GetType("System.String"));
            dt.Columns.Add("Line", Type.GetType("System.String"));
            dt.Columns.Add("Lot", Type.GetType("System.String"));
            dt.Columns.Add("Thurst", Type.GetType("System.String"));
            //dt.Columns.Add("Noise", Type.GetType("System.String"));
        }

        public void ShowRowNumber(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();

            // Show the bottom of the datagridview
            if (dgv.Rows.Count >= 1)
                dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
        }

        // Sub procedure: Count the without-duplicate OK records
        private int getOkCount(DataTable dt)
        {
            if (dt.Rows.Count <= 0) return 0;
            DataTable distinct = dt.DefaultView.ToTable(true, new string[] { "Serial", "Thurst" });
            DataRow[] dr = distinct.Select("Thurst = 'OK'"); //and Noise = 'OK'");
            int dist = dr.Length;
            return dist;
        }

        // Sub procedure: Bind main datatable to the datagridview and make summary datatables
        private void updateDataGripViewsSub(DataTable dt1, ref DataGridView dgv1)
        {
            string[] criteriaDateCode = getLotArray(dt1);
            makeDatatableSummary(dt1, ref dgvDateCode, criteriaDateCode, "Lot");
        }

        // Sub procedure: Make lot summary
        private string[] getLotArray(DataTable dt0)
        {
            DataTable dt1 = dt0.Copy();
            DataView dv = dt1.DefaultView;
            dv.Sort = "Lot";
            DataTable dt2 = dv.ToTable(true, "Lot");
            string[] array = new string[dt2.Rows.Count + 1];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                array[i] = dt2.Rows[i]["Lot"].ToString();
            }
            array[dt2.Rows.Count] = "Total";
            return array;
        }

        // Sub procedure: Make the summary datatables and bind them to the summary datagridviews
        public void makeDatatableSummary(DataTable dt0, ref DataGridView dgv, string[] criteria, string header)
        {
            DataTable dt1 = new DataTable();
            DataRow dr = dt1.NewRow();
            Int32 count;
            Int32 total = 0;
            string condition;

            for (int i = 0; i < criteria.Length; i++)
            {
                dt1.Columns.Add(criteria[i], typeof(Int32));
                condition = header + " = '" + criteria[i] + "'";
                count = dt0.Select(condition).Length;
                total += count;
                dr[criteria[i]] = (i != criteria.Length - 1 ? count : total);
                if (criteria[i] == "Total" && header == "Lot")
                {
                    dr[criteria[i]] = dgvProductSerial.Rows.Count;
                    //dr[criteria[i - 1]] = dgvProductSerial.Rows.Count - total;
                }
            }
            dt1.Rows.Add(dr);

            dgv.Columns.Clear();
            dgv.DataSource = dt1;
            dgv.AllowUserToAddRows = false; // remove the null line
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Disenalbe the textbox to block scanning
                //txtProduct.Enabled = false;
                if (txtProduct.Text.Length != 8) return;

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
                    string serial = txtProduct.Text;
                    string lot = VBStrings.Left(txtProduct.Text, 5);
                    string model = dt1.Rows[0][1].ToString();
                    string line = dt1.Rows[0][2].ToString();
                    string thurst = dt1.Rows[0][3].ToString();
                    //string noise = dt1.Rows[0][4].ToString();

                    newrow["Serial"] = serial;
                    newrow["Model"] = model;
                    newrow["Lot"] = lot;
                    newrow["Line"] = line;
                    newrow["Thurst"] = thurst;
                    //newrow["Noise"] = noise;
                }

                // Add the row to the datatable
                dtOverall.Rows.Add(newrow);
                dgvProductSerial.DataSource = dtOverall;
                txtProduct.SelectAll();
                ShowRowNumber(dgvProductSerial);
                colorViewForFailAndBlank(ref dgvProductSerial);
                colorViewForDuplicateSerial(ref dgvProductSerial);
                colorMixedConfig(dtOverall, ref dgvProductSerial);

                limitOkChange();
                updateDataGripViewsSub(dtOverall, ref dgvProductSerial);
            }
        }

        #region PRINTTING LABEL TOOL

        //string barcodeNumber = String.Empty;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //    if (!System.IO.Directory.Exists(directory)) return;

            //    string[] files = System.IO.Directory.GetFiles(directory, "*", System.IO.SearchOption.AllDirectories);

            //    for (int i = 0; i < files.Length; i++)
            //    {
            //        string fname = System.IO.Path.GetFileName(files[i]);
            //        if (VBStrings.Right(fname.ToLower(), 4) == ".txt")
            //        {
            //            string boxid = VBStrings.Left(fname, fname.Length - 4);

            //            PrintLabelTool.printBarCode(boxid);
            //            PrintLabelTool.printBarCode(boxid);
            //            if (boxid != String.Empty) barcodeNumber = boxid;
            //            pnlBarcode.Refresh();
            //            System.IO.File.Delete(files[i]);
            //            lblTime.Text = DateTime.Now.ToString();
            //        }
            //        else if (VBStrings.Right(fname.ToLower(), 4) == ".bmp")
            //        {
            //            string datecdFile = files[i];

            //            PrintLabelTool.printBitmap(datecdFile);
            //            PrintLabelTool.printBitmap(datecdFile);
            //            System.IO.File.Delete(files[i]);
            //        }
            //    }
        }

        private void pnlBarcode_Paint(object sender, PaintEventArgs e)
        {
            //    DotNetBarcode barCode = new DotNetBarcode();
            //    Single x1;
            //    Single y1;
            //    Single x2;
            //    Single y2;
            //    x1 = 0;
            //    y1 = 0;
            //    x2 = pnlBarcode.Size.Width;
            //    y2 = pnlBarcode.Size.Height;
            //    barCode.Type = DotNetBarcode.Types.Code39;

            //    if (barcodeNumber != String.Empty)
            //        barCode.WriteBar(barcodeNumber, x1, y1, x2, y2, e.Graphics);
        }
        #endregion
    }
}