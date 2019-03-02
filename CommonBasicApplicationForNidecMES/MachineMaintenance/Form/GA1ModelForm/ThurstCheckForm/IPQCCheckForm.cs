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
using System.Drawing;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class IPQCCheckForm : FormCommonNCVP
    {
        public IPQCCheckForm()
        {
            InitializeComponent();
        }
        void callModel()
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            cmb_model.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            cmb_model.DataSource = b1;
            cmb_model.Text = "GA1";
        }
        private void IPQCCheckForm_Load(object sender, EventArgs e)
        {
            callModel();
            txt_barcode.SelectNextControl(txt_barcode, true, false, true, true);
            pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
            pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
            pnlThurst.BackgroundImage = Properties.Resources.STANDBY;
            pnlNoise.BackgroundImage = Properties.Resources.STANDBY;
        }
        bool Checkdata()
        {
            if (cmb_model.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_model.Text);
                popUpMessage.Warning(messageData, Text);
                cmb_model.Focus();
                return false;
            }

            if (txt_barcode.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                popUpMessage.Warning(messageData, Text);
                txt_barcode.Focus();
                return false;
            }
            return true;
        }
        int count = 0;
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode != Keys.Enter) return;

            if (txt_barcode.Text == string.Empty) return;

            if (txt_barcode.ReadOnly == true) return;

            //if (duplicate) return;

            bool res = checkThurstNoise(txt_barcode.Text);
            if (!res) return;

            //Counter
            
            count = count + 1;
            lblCounter.Text = count.ToString();
        }
        private bool checkThurstNoise(string id)
        {
            string scanTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            GA1ModelVo inVo = new GA1ModelVo
            {
                A90Barcode = id,
                A90Model = cmb_model.Text
            };

            ValueObjectList<GA1ModelVo> outVo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchThurstDGVCbm(), inVo);
            
            bool result = false;

            if (outVo.GetList().Count > 0)
            {
                //Check Thurst
                switch (outVo.GetList()[0].A90ThurstStatus)
                {
                    case "OK":
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.OK_BEAR;
                        //checkDuplicate();

                        result = true;

                        txt_barcode.ResetText();
                        break;
                    case "NG":
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.NG_BEAR;
                        //checkDuplicate();

                        result = true;

                        txt_barcode.ReadOnly = true;
                        txt_barcode.BackColor = Color.Red;
                        break;
                    default:
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.NoDaTa;

                        result = true;

                        txt_barcode.ReadOnly = true;
                        txt_barcode.BackColor = Color.Red;
                        break;
                }

                //Check Noise
                switch (outVo.GetList()[0].A90NoiseStatus)
                {
                    case "OK":
                        pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlNoise.BackgroundImage = Properties.Resources.OK_BEAR;
                        //checkDuplicate();

                        result = true;

                        txt_barcode.ResetText();
                        break;
                    case "NG":
                        pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlNoise.BackgroundImage = Properties.Resources.NG_BEAR;
                        //checkDuplicate();

                        result = true;

                        //txt_barcode.ReadOnly = true;
                        //txt_barcode.BackColor = Color.Red;
                        break;
                    default:
                        pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlNoise.BackgroundImage = Properties.Resources.NoDaTa;

                        result = true;

                        //txt_barcode.ReadOnly = true;
                        //txt_barcode.BackColor = Color.Red;
                        break;
                }
            }
            else
            {
                pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                pnlThurst.BackgroundImage = Properties.Resources.NoDaTa;
                pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                pnlNoise.BackgroundImage = Properties.Resources.NoDaTa;
                txt_barcode.ReadOnly = true;
                txt_barcode.BackColor = Color.Red;
                result = false;
            }
            return result;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
            pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
            pnlThurst.BackgroundImage = Properties.Resources.STANDBY;
            pnlNoise.BackgroundImage = Properties.Resources.STANDBY;

            txt_barcode.ResetText();
            txt_barcode.ReadOnly = false;
            txt_barcode.BackColor = Color.White;
            txt_barcode.Focus();
        }
    }
}
