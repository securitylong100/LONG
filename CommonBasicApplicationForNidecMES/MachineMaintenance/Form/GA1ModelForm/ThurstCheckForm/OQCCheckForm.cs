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
    public partial class OQCCheckForm : FormCommonNCVP
    {
        public OQCCheckForm()
        {
            InitializeComponent();
            dgv_thurst.AutoGenerateColumns = false;
        }
        void callModel()
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            cmb_model.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            cmb_model.DataSource = b1;
            cmb_model.Text = "";
        }
        private void OQCCheckForm_Load(object sender, EventArgs e)
        {
            callModel();
            txt_barcode.SelectNextControl(txt_barcode, true, false, true, true);
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
            if (txt_data.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_data.Text);
                popUpMessage.Warning(messageData, Text);
                txt_data.Focus();
                return false;
            }
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(txt_timer.Text) * 1000;
            lbl_status.Text = "WAITING";
            lbl_status.ForeColor = System.Drawing.Color.DarkGoldenrod;
            pb_OK.Visible = false;
            pb_NG.Visible = false;
            timer1.Enabled = false;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string check = "";
            if (Checkdata())
            {
                GA1ModelVo outVo = new GA1ModelVo();
                GA1ModelVo inVo = new GA1ModelVo();
                GA1ModelVo checkVo = new GA1ModelVo();
                if (e.Button == MouseButtons.Right)
                {
                    inVo = new GA1ModelVo()
                    {
                        A90Model = ((ModelVo)this.cmb_model.SelectedItem).ModelCode,
                        A90Barcode = txt_barcode.Text,
                        A90Shipping = false,
                        RegistrationDateTime = DateTime.Now,
                        FactoryCode = UserData.GetUserData().FactoryCode,
                        A90ThurstStatus = "OK",
                        RegistrationUserCode = UserData.GetUserData().UserName,
                        A90OQCStatus = "OK",
                        A90OQCData = txt_data.Text,
                    };
                    check = "OK";
                }
                if (e.Button == MouseButtons.Left)
                {
                    inVo = new GA1ModelVo()
                    {
                        A90Model = ((ModelVo)this.cmb_model.SelectedItem).ModelCode,
                        A90Barcode = txt_barcode.Text,
                        A90Shipping = false,
                        RegistrationDateTime = DateTime.Now,
                        FactoryCode = UserData.GetUserData().FactoryCode,
                        A90ThurstStatus = "NG",
                        RegistrationUserCode = UserData.GetUserData().UserName,
                        A90OQCStatus ="NG",
                        A90OQCData = txt_data.Text,
                       
                    };
                    check = "NG";
                }
                checkVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new Cbm.CheckIBarcodeDuplicateCbm(), inVo);
                if (checkVo.AffectedCount > 0)
                {
                    outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new Cbm.UpdateGA1ModelOQCCbm(), inVo);
                    GridBind();
                }
                else
                {
                    messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                    popUpMessage.Warning(messageData, Text);
                    txt_barcode.Focus();
                    txt_barcode.Text = "";
                    dgv_thurst.DataSource = null;
                    return;
                }

                if (check == "OK")
                {
                    pb_OK.Visible = true;
                    pb_NG.Visible = false;
                    lbl_status.Text = "CHECKED";
                    timer1.Enabled = true;
                    lbl_status.ForeColor = System.Drawing.Color.Green;
                }
                else if (check == "NG")
                {
                    pb_OK.Visible = false;
                    pb_NG.Visible = true;
                    lbl_status.Text = "CHECKED";
                    timer1.Enabled = true;
                    lbl_status.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbl_status.Text = "WAITING";
                    messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                    popUpMessage.Warning(messageData, Text);
                    txt_barcode.Focus();
                }
                txt_barcode.Text = "";
            }
        }
        private void GridBind()
        {
            try
            {
                GA1ModelVo calldgv = new GA1ModelVo()
                {
                    A90Model = cmb_model.Text,
                    A90Barcode = txt_barcode.Text,
                };

                ValueObjectList<GA1ModelVo> listvo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new Cbm.SearchThurstDGVCbm(), calldgv);
                dgv_thurst.DataSource = listvo.GetList();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }


    }
}
