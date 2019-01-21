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
    public partial class ShowCheckForm : FormCommonNCVP
    {
        public ShowCheckForm()
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
        private void ShowCheckForm_Load(object sender, EventArgs e)
        {
            callModel();
        }


        private void GridBind(bool data, DateTimePicker dtpfrom, DateTimePicker dtptto)
        {
            try
            {
                GA1ModelVo calldgv = new GA1ModelVo()
                {
                    DateTimeFrom = dtpfrom.Value,
                    DateTimeTo = dtptto.Value,
                    DaTa = data,
                };

                ValueObjectList<GA1ModelVo> listvo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new Cbm.SearchGA1DGVCbm(), calldgv);
                dgv_thurst.DataSource = listvo.GetList();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            GridBind(false, dpt_from, dpt_from);
        }
        private void btn_autoview_Click(object sender, EventArgs e)
        {
            if (btn_autoview.Text == "Auto View")
            {
                timer1.Interval = 2000;
                timer1.Enabled = true;
                btn_autoview.Text = "Stop Auto";
            }
            else if (btn_autoview.Text == "Stop Auto")
            {
                timer1.Enabled = false;
                btn_autoview.Text = "Auto View";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GridBind(true, dpt_from, dpt_from);
        }
        private string directorySave = "";
        private void btn_browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "d:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txt_linksave.Text = fl.SelectedPath;
                directorySave = txt_linksave.Text;
            }
        }

        private void btn_exportexcel_Click(object sender, EventArgs e)
        {
            string  datetime = DateTime.Now.ToString("yyMMdd_HHmm");
           Common.CSV_Class exportexcel = new Common.CSV_Class();
            exportexcel.exportcsv(ref dgv_thurst, txt_linksave.Text, "GA1Thurst_"+ datetime);
        }
    }
}
