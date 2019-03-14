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

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class NGThurstForm : FormCommonNCVP
    {
        public NGThurstForm()
        {
            InitializeComponent();
            dgv_thurst.AutoGenerateColumns = false;
        }
        bool Checkdata()
        {
            if (txt_barcode.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                popUpMessage.Warning(messageData, Text);
                txt_barcode.Focus();
                return false;
            }
            if (txt_barcode.Text.Length != 8)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                popUpMessage.Warning(messageData, Text);
                txt_barcode.Focus();
                return false;
            }
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(txt_timer.Text) * 1000;
            lbl_status.Text = "WAITING";
            lbl_status.ForeColor = System.Drawing.Color.DarkGoldenrod;
            pb_NoData.Visible = false;
            pb_NG.Visible = false;
            timer1.Enabled = false;
        }
        private void NGThurstForm_Load(object sender, EventArgs e)
        {
            txt_barcode.SelectNextControl(txt_barcode, true, false, true, true);
            //dt = new DataTable();
            //dt.Columns.Add("Barcode", typeof(string));
            //dt.Columns.Add("Thurst Status", typeof(string));
            //dgv_thurst.DataSource = dt;
        }
        DataTable dt;
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Checkdata();
                if (txt_barcode.Text.Length == 8)
                {
                    GA1ModelVo testbarcodeVo = new GA1ModelVo()
                    {
                        A90Barcode = txt_barcode.Text,
                    };

                    GA1ModelVo BarcodeVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new Cbm.SearchBarcodeandUpdateNGThurstCbm(), testbarcodeVo);
                    if (BarcodeVo.AffectedCount >= 1)//update thanh cong
                    {
                        pb_NG.Visible = true;
                        pb_NoData.Visible = false;  
                        dgv_thurst.Rows.Add(txt_barcode.Text, "NG");
                    }
                    else
                    {
                        pb_NG.Visible = false;
                        pb_NoData.Visible = true;
                    }
                    
                    timer1.Interval = int.Parse(txt_timer.Text) * 1000;
                    timer1.Enabled = true;
                }
                txt_barcode.Clear();
            }
        }
    }
}
