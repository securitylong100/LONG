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
    public partial class ShippingCheckForm : FormCommonNCVP
    {
        public ShippingCheckForm()
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
        private void ShippingCheckForm_Load(object sender, EventArgs e)
        {
            callModel();
            txt_barcode.SelectNextControl(txt_barcode, true, false, true, true);
            AcceptButton = btn_search;
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                GA1ModelVo checkVo = new GA1ModelVo();
                GA1ModelVo outVo = new GA1ModelVo();
                GA1ModelVo inVo = new GA1ModelVo
                {
                    A90Shipping = true,
                    A90Barcode = txt_barcode.Text,
                };

                checkVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new Cbm.CheckIBarcodeDuplicateCbm(), inVo);
                if (checkVo.AffectedCount > 0)
                {
                    outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new Cbm.UpdateGA1ModelShippingCbm(), inVo);
                    GridBind();
                    alarm("col_thurst_data", pb_OK, pb_NG, pb_nodata);
                    alarm("col_noise_status", pb_noise_ok, pb_noise_NG, pb_noiseNodata);
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
                txt_barcode.Text = "";
            }

            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
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
        }//col_thurst_data
        void alarm(string columnsvalue, PictureBox pb_OK_, PictureBox pb_NG_, PictureBox pb_nodata_)
        {
            if (dgv_thurst.RowCount > 0)
            {
                if (dgv_thurst.Rows[0].Cells[columnsvalue].Value.ToString() == "OK")
                {
                    pb_OK_.Visible = true;
                    pb_NG_.Visible = false;
                    pb_nodata_.Visible = false;
                }
                else if (dgv_thurst.Rows[0].Cells[columnsvalue].Value.ToString() == "NG")
                {
                    pb_OK_.Visible = false;
                    pb_NG_.Visible = true;
                    pb_nodata_.Visible = false;
                }
                else if (dgv_thurst.Rows[0].Cells[columnsvalue].Value.ToString() == "")
                {
                    pb_OK_.Visible = false;
                    pb_NG_.Visible = false;
                    pb_nodata_.Visible = true;
                }
            }
        }
        bool checkdata()
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
    }
}
