using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Linq;
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
    public partial class ProducionControllerGA1Form : FormCommonNCVP
    {
        public ProducionControllerGA1Form()
        {
            InitializeComponent();
            dgv_main.AutoGenerateColumns = false;
        }
        public static readonly string connection = "Server=192.168.145.12;Port=5432;UserId=pqm;Password=mesdb;Database=mesdb;;";
        public string tablename;

        private void ProducionControllerGA1Form_Load(object sender, EventArgs e)
        {

            callModel();
        }
        void callModel()
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            cmb_model.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            cmb_model.DataSource = b1;
            cmb_model.Text = "";
        }
        void callLine()
        {
            ValueObjectList<ProductionControllerGA1Vo> assetvoinvoice = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionLineCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text });
            cmb_line.DisplayMember = "LineCode";
            cmb_line.DataSource = assetvoinvoice.GetList();
            cmb_line.Text = "";
        }

        private void cmb_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            callLine();
            cmb_process.Text = "";
            cmb_item.Text = "";
        }

        private void cmb_line_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> assetvoinvoice = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionProcessCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename }, connection);
                cmb_process.DisplayMember = "ProcessCode";
                cmb_process.DataSource = assetvoinvoice.GetList();
                cmb_process.Text = "";
                cmb_item.Text = "";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void cmb_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> assetvoinvoice = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionItemCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename, ProcessCode = cmb_process.Text }, connection);
                cmb_item.DisplayMember = "ItemCode";
                cmb_item.DataSource = assetvoinvoice.GetList();
                cmb_item.Text = "";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            GridBind();
            showchart();
        }
        void showchart()
        {
            chr_main.ResetAutoValues();
            chr_main.ResumeLayout();
            chr_main.Series.Clear();

            chr_main.Titles[0].Text = "CHART SHOW PROGRESS DATA"; //ten
            chr_main.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chr_main.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM HH:mm";
            chr_main.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chr_main.ChartAreas[0].AxisY.Title = "TOTAL[PCS]"; //sua ten truc
            chr_main.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chr_main.Series.Add("Output");
            chr_main.Series["Output"].XValueType = ChartValueType.Date;
            chr_main.Series["Output"].ChartType = SeriesChartType.Line;
            chr_main.Series["Output"].Color = Color.FromArgb(0, 192, 0); //green
            chr_main.Series["Output"].BorderWidth = 5;
            chr_main.Series["Output"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chr_main.Series["Output"].IsValueShownAsLabel = true;
            //chr_main.Series["Output"].XValueMember = "InspectDate";
            //chr_main.Series["Output"].YValueMembers = "Data";
            //chr_main.DataSource = dgv_main.DataSource;
            //chr_main.DataBind();

            if (dgv_main.RowCount > 8)
            {
                int refa = dgv_main.RowCount / 8;
                int datasum = 0;
                for (int i = 0; i < dgv_main.RowCount; i++)
                {
                    datasum += int.Parse(dgv_main.Rows[i].Cells["col_data"].Value.ToString());
                    if (i % refa == 0)
                    {
                        chr_main.Series["Output"].Points.AddXY(dgv_main.Rows[i].Cells["col_inspectdate"].Value.ToString(), datasum);
                    }
                }
            }
        }
        private void GridBind()
        {
            tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
            try
            {
                ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
                {
                    TableName = tablename,
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    ProcessCode = cmb_process.Text,
                    ItemCode = cmb_item.Text,
                };

                ValueObjectList<ProductionControllerGA1Vo> listvo = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionINPUTCbm(), dgvVo, connection);
                dgv_main.DataSource = listvo.GetList();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
    }
}
