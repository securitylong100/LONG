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
using System.IO;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.Threading;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class NoiseCheckForm : FormCommonNCVP
    {
        public NoiseCheckForm()
        {
            InitializeComponent();
        }

        private void NoiseCheckForm_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                if (File.Exists(@"D:\Noise Check Barcode Data\login.txt"))
                {
                    using (var reader = new StreamReader(@"D:\Noise Check Barcode Data\login.txt"))
                    {
                        string path = reader.ReadLine();
                        if (Directory.Exists(path))
                        {
                            txtBrowser.Text = path;
                        }
                    }
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {

                string file = DateTime.Now.ToString("yyyyMMdd") + "_InspectionResult.txt";
                if (File.Exists(txtBrowser.Text + "\\" + file))
                {
                    string sourceFile = txtBrowser.Text + "\\" + file;
                    string destFile = @"D:\Noise Check Barcode Data\" + "Barcode_" + txtBarcode.Text + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                    if (txtBarcode.Text.Length == 8)
                    {
                        Thread.Sleep(1000);
                        System.IO.File.Move(sourceFile, destFile);

                        if (File.Exists(destFile))
                        {
                            DataTable dt = new DataTable();
                            using (var reader = new StreamReader(destFile))
                            {
                                string[] headers = reader.ReadLine().Split(',');
                                foreach (string header in headers)
                                {
                                    dt.Columns.Add(header);
                                }
                                dt.Columns.Add("barcode");
                                dt.Columns.Add("registration_user_cd");
                                dt.Columns.Add("registration_date_time");
                                dt.Columns.Add("factory_cd");
                                while (!reader.EndOfStream)
                                {
                                    string[] rows = reader.ReadLine().Split(',');
                                    DataRow dr = dt.NewRow();
                                    for (int i = 0; i < headers.Length; i++)
                                    {
                                        dr[i] = rows[i];
                                        string datetimes = "";
                                        if (i == 5)
                                        {
                                            datetimes = rows[i].Substring(1, 4) + "/" + rows[i].Substring(5, 2) + "/" + rows[i].Substring(7, 2) + " " + rows[i].Substring(9, 2) + ":" + rows[i].Substring(11, 2) + ":" + rows[i].Substring(13, 2);
                                            dr[i] = datetimes;
                                        }
                                    }
                                    dr["barcode"] = txtBarcode.Text;
                                    dr["registration_user_cd"] = UserData.GetUserData().UserName;
                                    dr["registration_date_time"] = DateTime.Now.ToString();
                                    dr["factory_cd"] = UserData.GetUserData().FactoryCode; ;
                                    dt.Rows.Add(dr);
                                }
                            }
                            dgvNoise.DataSource = dt;

                            if (dgvNoise.RowCount > 0)
                            {
                                GA1ModelVo NoiseVo = new GA1ModelVo()
                                {
                                    Noise_eq_id = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["EQ_ID"].Value.ToString(),
                                    Noise_model = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" MODEL"].Value.ToString(),
                                    Noise_line = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" LINE_ID"].Value.ToString(),
                                    Noise_serial_id = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" SERIAL_ID"].Value.ToString(),
                                    Noise_id = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" ID"].Value.ToString(),
                                    Noise_date_check = DateTime.Parse(dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" DATE"].Value.ToString()),
                                    Noise_judgment = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" JUDGMENT"].Value.ToString(),
                                    Noise_l1_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" L1_V_CW"].Value.ToString(),
                                    Noise_l1_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" L1_V_CCW"].Value.ToString(),
                                    Noise_e1_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E1_V_CW"].Value.ToString(),
                                    Noise_e2_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E2_V_CW"].Value.ToString(),
                                    Noise_e3_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E3_V_CW"].Value.ToString(),
                                    Noise_e4_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E4_V_CW"].Value.ToString(),
                                    Noise_e5_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E5_V_CW"].Value.ToString(),
                                    Noise_e1_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E1_V_CCW"].Value.ToString(),
                                    Noise_e2_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E2_V_CCW"].Value.ToString(),
                                    Noise_e3_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E3_V_CCW"].Value.ToString(),
                                    Noise_e4_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E4_V_CCW"].Value.ToString(),
                                    Noise_e5_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E5_V_CCW"].Value.ToString(),
                                    Noise_barcode = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["barcode"].Value.ToString(),
                                    Noise_registration_user_cd = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["registration_user_cd"].Value.ToString(),
                                    Noise_factory_cd = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["factory_cd"].Value.ToString(),
                                };

                                GA1ModelVo addNoiseVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddGA1ModelNoiseCbm(), NoiseVo);
                                GA1ModelVo updateNoiseVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new UpdateGA1ModelNoiseCbm(), new GA1ModelVo()
                                {
                                    A90Barcode = txtBarcode.Text,
                                    A90NoiseStatus = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" JUDGMENT"].Value.ToString().Substring(1, 2),
                                });
                                int t = updateNoiseVo.AffectedCount;
                                //UpdateGA1ModelNoiseCbm

                                ValueObjectList<GA1ModelVo> ThurtVo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchThusrtByBarcodeCbm(),
                                    new GA1ModelVo()
                                    {
                                        A90Barcode = txtBarcode.Text,
                                    });
                                if (ThurtVo.GetList().Count == 0)
                                {
                                    lblThurst.Text = "No data";
                                    lblThurst.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
                                }
                                else
                                {
                                    lblThurst.Text = ThurtVo.GetList()[0].A90ThurstStatus;
                                    if (lblThurst.Text == "OK") { lblThurst.BackColor = System.Drawing.Color.Green; }
                                    else { lblThurst.BackColor = System.Drawing.Color.Red; }
                                }
                                if (addNoiseVo.AffectedCount == 1)
                                {
                                    txtBarcode.Clear();
                                    lblNoise.Text = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" JUDGMENT"].Value.ToString().Substring(1, 2);
                                    if (lblNoise.Text == "OK") { lblNoise.BackColor = System.Drawing.Color.Green; }
                                    else { lblNoise.BackColor = System.Drawing.Color.Red; }
                                }
                                timerOff.Enabled = true;
                            }
                        }
                    }
                    else // barcode < 8 character
                    {
                        txtBarcode.BackColor = System.Drawing.Color.Red;
                        System.IO.File.Move(sourceFile, destFile);
                        if (File.Exists(destFile))
                        {
                            timerOffBarcodenull.Enabled = true;
                        }
                    }
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void timerOffBarcodenull_Tick(object sender, EventArgs e)
        {
            txtBarcode.BackColor = System.Drawing.Color.White;
            timerOffBarcodenull.Enabled = false;
        }
        private void timerOff_Tick(object sender, EventArgs e)
        {
            lblThurst.Text = "";
            lblThurst.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);

            lblNoise.Text = "";
            lblNoise.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
            DataTable dt = new DataTable();
            dgvNoise.DataSource = dt;
            timerOff.Enabled = false;
        }
        private string directorySave = "";
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "C:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtBrowser.Text = fl.SelectedPath;
                directorySave = txtBrowser.Text;
            }
        }

        private void NoiseCheckForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            timerOff.Enabled = false;
        }
        
    }
}
