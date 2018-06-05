using Com.Nidec.Mes.Framework;


using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ReportDownTimeForm : FormCommonNCVP
    {
        public ReportDownTimeForm()
        {
            InitializeComponent();
            reportdowntime_dgv.AutoGenerateColumns = false;
        }

        private void ReportDownTimeForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            model_cmb.DataSource = b1;
            model_cmb.Text = "";

            ProcessVo processvo = (ProcessVo)DefaultCbmInvoker.Invoke(new GetProcessMasterMntCbm(), new ProcessVo());
            process_cmb.DisplayMember = "ProcessName";
            BindingSource b2 = new BindingSource(processvo.ProcessListVo, null);
            process_cmb.DataSource = b2;
            process_cmb.Text = "";

            MachineVo machinevo = (MachineVo)DefaultCbmInvoker.Invoke(new GetMachineMasterMntCbm(), new MachineVo());
            machine_cmb.DisplayMember = "MachineName";
            BindingSource b4 = new BindingSource(machinevo.MachineListVo, null);
            machine_cmb.DataSource = b4;
            machine_cmb.Text = "";

            line_cmb.Text = "";

            cause_cmb.Text = "";
            action_cmb.Text = "";
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model_cmb.SelectedItem != null)
            {
                ModelVo mvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<LineVo> linevo = (ValueObjectList<LineVo>)DefaultCbmInvoker.Invoke(new GetLineMoCbm(), new LineVo { LineId = mvo.ModelId });
                line_cmb.DisplayMember = "LineCode";
                line_cmb.DataSource = linevo.GetList();
            }
        }

        private void machine_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (machine_cmb.SelectedItem != null)
            {
                MachineVo mvo = (MachineVo)machine_cmb.SelectedItem;
                ValueObjectList<DefectiveReasonVo> defectivereasonvo = (ValueObjectList<DefectiveReasonVo>)DefaultCbmInvoker.Invoke(new GetCauseAndDefectiveCbm(), new DefectiveReasonVo { DefectiveReasonId = mvo.MachineId });
                cause_cmb.DisplayMember = "DefectiveReasonName";
                cause_cmb.DataSource = defectivereasonvo.GetList();

                ValueObjectList<ProdutionWorkContentVo> respmachinevolist = (ValueObjectList<ProdutionWorkContentVo>)DefaultCbmInvoker.Invoke(new GetActicAndContentCbm(), new ProdutionWorkContentVo { ProdutionWorkContentId = mvo.MachineId });
                action_cmb.DisplayMember = "ProdutionWorkContentName";
                action_cmb.DataSource = respmachinevolist.GetList();
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (model_cmb.SelectedIndex == -1)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, model_lbl.Text);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);
                return;
            }

            reportdowntime_dgv.DataSource = null;

            try
            {
                selectdata();
            }
            catch
            { }
        }

        private void selectdata()
        {
            ValueObjectList<ReportDownTimeVo> getList = (ValueObjectList<ReportDownTimeVo>)DefaultCbmInvoker.Invoke(new SearchReportDownTimeCbm(), new ReportDownTimeVo
            {
                ModelCode = model_cmb.Text,
                MachineCode = machine_cmb.Text,
                ProcessName = process_cmb.Text,
                LineCode = line_cmb.Text,
                DefectiveReasonName = cause_cmb.Text,
                ProductionWorkContentName = action_cmb.Text,
                TimeFrom = timefrom_dtp.Value,
                TimeTo = timeto_dtp.Value
            });
            reportdowntime_dgv.DataSource = getList.GetList();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (new AddUpdateReportDownTimeFrom().ShowDialog() == DialogResult.OK)
            {
                add_btn_Click(null, null);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (reportdowntime_dgv.SelectedCells.Count > 0)
            {
                ReportDownTimeVo selectedvo = (ReportDownTimeVo)reportdowntime_dgv.CurrentRow.DataBoundItem;

                //model_cmb.Enabled = false;

                //line_cmb.Enabled = false;

                //machine_cmb.Enabled = false;

                //process_cmb.Enabled = false;

                if (new AddUpdateReportDownTimeFrom { reportDownTimeVo = selectedvo }.ShowDialog() == DialogResult.OK)
                {
                    //search_btn_Click(null, null);
                    selectdata();
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            reportdowntime_dgv.DataSource = null;
            process_cmb.Text = "";
            line_cmb.Text = "";
            machine_cmb.Text = "";
            cause_cmb.Text = "";
            action_cmb.Text = "";
        }
    }
}
