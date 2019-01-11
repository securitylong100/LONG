﻿using Com.Nidec.Mes.Framework;
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
        public static readonly string connection = "Server=192.168.145.12;Port=5432;UserId=pqm;Password=mesdb;Database=pqmdb;;";
        public string tablename;

        private void ProducionControllerGA1Form_Load(object sender, EventArgs e)
        {
            search_cmb.Text = "Time";
            callModel();
        }
        void callModel()
        {
            //ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            ValueObjectList<ProductionControllerGA1Vo> modelvolist = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionModelCbm(), new ProductionControllerGA1Vo(), connection);
            cmb_model.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            cmb_model.DataSource = b1;
            cmb_model.Text = "";
        }
        void callLine()
        {
            ValueObjectList<ProductionControllerGA1Vo> assetvoinvoice = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionLineCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text }, connection);
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
            if (cmb_model.Text != "" && cmb_line.Text == "" && cmb_process.Text == "")
            {
                if (search_cmb.Text == "Time")
                {
                    GridBind();
                    showchartProcess();
                }
                else if (search_cmb.Text == "Date")
                {
                    GridBindByDate();
                    showchartLine(false);
                }
            }
            else if (cmb_model.Text != "" && cmb_line.Text != "" && cmb_process.Text == "")
            {
                if (search_cmb.Text == "Time")
                {
                    GridBind();
                    showchartProcess();
                }
                else if (search_cmb.Text == "Date")
                {
                    GridBindByDate();
                    showchartLine(false);
                }
            }
            else if (cmb_model.Text != "" && cmb_line.Text != "" && cmb_process.Text != "" || cmb_model.Text != "" && cmb_line.Text == "" && cmb_process.Text != "")
            {
                GridBindProcess();
                showchartProcess();
            }
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
            chr_main.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
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

            chr_main.Series.Add("Input");
            chr_main.Series["Input"].XValueType = ChartValueType.Date;
            chr_main.Series["Input"].ChartType = SeriesChartType.Line;
            chr_main.Series["Input"].Color = Color.FromArgb(192, 192, 0); //green
            chr_main.Series["Input"].BorderWidth = 5;
            chr_main.Series["Input"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chr_main.Series["Input"].IsValueShownAsLabel = true;

            chr_main.Series.Add("YEILD");
            chr_main.Series["YEILD"].ChartType = SeriesChartType.Line;
            chr_main.Series["YEILD"].Color = Color.FromArgb(192, 100, 0); //yellow    
            chr_main.Series["YEILD"].BorderWidth = 1;
            chr_main.Series["YEILD"].IsValueShownAsLabel = true;
            chr_main.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chr_main.Series["YEILD"].YAxisType = AxisType.Secondary;
            chr_main.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chr_main.Series["YEILD"].XAxisType = AxisType.Secondary;
            chr_main.Series["YEILD"].XValueType = ChartValueType.DateTime;
            chr_main.ChartAreas[0].AxisX2.LabelStyle.Format = "HH:mm";
            chr_main.ChartAreas[0].AxisX2.LabelStyle.Angle = 0;
            chr_main.ChartAreas[0].AxisY2.Maximum = 100;
            chr_main.ChartAreas[0].AxisY2.Title = "YEILD [%]";

            if (dgv.RowCount > 8)
            {
                int refa = dgv.RowCount / 8;
                double dataOut = 0;
                double dataIn = 0;
                double dataNG = 0;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv.Columns.Contains("OUTPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString()); }
                    if (dgv.Columns.Contains("INPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["INPUT"].Value.ToString()); }
                    dataNG += double.Parse(dgv.Rows[i].Cells["Total_NG"].Value.ToString());
                    if (i % refa == 0)
                    {
                        chr_main.Series["Output"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataOut);
                        chr_main.Series["Input"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataIn);
                        chr_main.Series["YEILD"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), Math.Round(((dataNG / dataOut) * 100) < 100 ? ((dataNG / dataOut) * 100) : 100, 2));
                    }
                }
            }
        }
        void showchartProcess()
        {
            chr_main.ResetAutoValues();
            chr_main.ResumeLayout();
            chr_main.Series.Clear();

            chr_main.Titles[0].Text = cmb_process.Text + " Process"; //ten
            chr_main.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chr_main.Series.Add("Pie");
            chr_main.Series["Pie"].ChartType = SeriesChartType.Pie;
            chr_main.Series["Pie"].IsValueShownAsLabel = true;
            
            string header = "";
            for (int j = 4; j < dgv.ColumnCount; j++)
            {
                int value = 0;
                header = dgv.Columns[j].HeaderText;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    value += int.Parse(dgv.Rows[i].Cells[j].Value.ToString());
                }
                chr_main.Series["Pie"].Points.AddXY(header, value);
            }
        }
        void showchartLine(bool dt)
        {
            chr_main.ResetAutoValues();
            chr_main.ResumeLayout();
            chr_main.Series.Clear();

            chr_main.Titles[0].Text = "CHART SHOW PROGRESS DATA"; //ten
            chr_main.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chr_main.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM HH:mm";
            chr_main.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
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

            chr_main.Series.Add("Input");
            chr_main.Series["Input"].XValueType = ChartValueType.Date;
            chr_main.Series["Input"].ChartType = SeriesChartType.Line;
            chr_main.Series["Input"].Color = Color.FromArgb(192, 192, 0); //green
            chr_main.Series["Input"].BorderWidth = 5;
            chr_main.Series["Input"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chr_main.Series["Input"].IsValueShownAsLabel = true;

            chr_main.Series.Add("YEILD");
            chr_main.Series["YEILD"].ChartType = SeriesChartType.Line;
            chr_main.Series["YEILD"].Color = Color.FromArgb(192, 100, 0); //yellow    
            chr_main.Series["YEILD"].BorderWidth = 1;
            chr_main.Series["YEILD"].IsValueShownAsLabel = true;
            chr_main.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chr_main.Series["YEILD"].YAxisType = AxisType.Secondary;
            chr_main.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chr_main.Series["YEILD"].XAxisType = AxisType.Secondary;
            chr_main.Series["YEILD"].XValueType = ChartValueType.DateTime;
            chr_main.ChartAreas[0].AxisX2.LabelStyle.Format = "HH:mm";
            chr_main.ChartAreas[0].AxisX2.LabelStyle.Angle = 0;
            chr_main.ChartAreas[0].AxisY2.Maximum = 100;
            chr_main.ChartAreas[0].AxisY2.Title = "YEILD [%]";

            if (dt)//time
            {
                if (dgv.RowCount > 8)
                {
                    int refa = dgv.RowCount / 8;
                    double dataOut = 0;
                    double dataIn = 0;
                    double dataNG = 0;
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        if (dgv.Columns.Contains("OUTPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString()); }
                        if (dgv.Columns.Contains("INPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["INPUT"].Value.ToString()); }
                        dataNG = double.Parse(dgv.Rows[i].Cells["Total_NG"].Value.ToString());
                        if (i % refa == 0)
                        {
                            chr_main.Series["Output"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataOut);
                            chr_main.Series["Input"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataIn);
                            chr_main.Series["YEILD"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), Math.Round((100 - (dataNG / dataOut) * 100), 2));
                        }
                    }
                }
            }
            else//date
            {
                if (dgv.RowCount > 0)
                {
                    double dataOut = 0;
                    double dataIn = 0;
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        if (dgv.Columns.Contains("OUTPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString()); }
                        if (dgv.Columns.Contains("INPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["INPUT"].Value.ToString()); }
                        double dataNG = double.Parse(dgv.Rows[i].Cells["Total_NG"].Value.ToString());
                        chr_main.Series["Output"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataOut);
                        chr_main.Series["Input"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataIn);
                        chr_main.Series["YEILD"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), Math.Round(((dataNG / dataOut) * 100) < 100 ? ((dataNG / dataOut) * 100) : 100, 2));

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
                    DateFrom = DateTime.Parse(dtp_from.Text),
                    DateTo = DateTime.Parse(dtp_to.Text)
                };

                ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionINPUTCbm(), dgvVo, connection);
                var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
                DataTable dt = new DataTable();
                dt.Columns.Add("Model");
                dt.Columns.Add("Line");
                dt.Columns.Add("Date");
                dt.Columns.Add("Total_NG");
                foreach (var a in distinctProcess)
                {
                    dt.Columns.Add(a.ToString());
                }

                var distinctId = (from row in listvo.dt.AsEnumerable() select row.Field<int>("id")).Distinct();
                foreach (var serno in distinctId)
                {
                    var infoSerno = (from row in listvo.dt.AsEnumerable() where row.Field<int>("id") == int.Parse(serno.ToString()) select row).ToList();

                    var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["process"] where row.Field<int>("id") == int.Parse(serno.ToString()) select row).ToList();

                    DataRow dr = dt.NewRow();

                    dr[0] = infoSerno[0]["model"].ToString();
                    dr[1] = infoSerno[0]["line"].ToString();
                    dr[2] = infoSerno[0]["inspectdate"].ToString();
                    int j = 0;
                    for (int i = 0; i < dt.Columns.Count - 4; i++)
                    {
                        if (dt.Columns[i + 4].ColumnName == inspectdata[j]["process"].ToString())
                        {
                            dr[i + 4] = inspectdata[j]["inspectdata"].ToString();
                            j++;
                        }
                        else
                        {
                            dr[i + 4] = "0";
                        }
                    }
                    dt.Rows.Add(dr);
                }
                dgv.DataSource = dt;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    double a = 0;
                    for (int j = 4; j < dgv.ColumnCount; j++)
                    {
                        string b = dgv[j, i].Value.ToString();
                        if (dgv.Columns[j].HeaderText != "INPUT" && dgv.Columns[j].HeaderText != "OUTPUT")
                        {
                            a += double.Parse(dgv[j, i].Value.ToString());
                        }
                    }
                    dgv[3, i].Value = a;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void GridBindByDate()
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
                    DateFrom = DateTime.Parse(dtp_from.Text),
                    DateTo = DateTime.Parse(dtp_to.Text)
                };

                ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionInputByDateCbm(), dgvVo, connection);
                var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
                DataTable dt = new DataTable();
                dt.Columns.Add("Model");
                dt.Columns.Add("Line");
                dt.Columns.Add("Date");
                dt.Columns.Add("Total_NG");
                foreach (var a in distinctProcess)
                {
                    dt.Columns.Add(a.ToString());
                }

                var distinctId = (from row in listvo.dt.AsEnumerable() select row.Field<DateTime>("dates")).Distinct();
                foreach (var serno in distinctId)
                {
                    var infoSerno = (from row in listvo.dt.AsEnumerable() where row.Field<DateTime>("dates") == DateTime.Parse(serno.ToString()) select row).ToList();

                    var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["process"] where row.Field<DateTime>("dates") == DateTime.Parse(serno.ToString()) select row).ToList();

                    DataRow dr = dt.NewRow();

                    dr[0] = infoSerno[0]["model"].ToString();
                    dr[1] = infoSerno[0]["line"].ToString();
                    dr[2] = DateTime.Parse(infoSerno[0]["dates"].ToString()).ToShortDateString();
                    int j = 0;
                    for (int i = 0; i < dt.Columns.Count - 4; i++)
                    {
                        if (dt.Columns[i + 4].ColumnName == inspectdata[j]["process"].ToString())
                        {
                            if (j <= inspectdata.Count)
                            {
                                dr[i + 4] = inspectdata[j]["inspectdata"].ToString();
                                j++;
                            } 
                        }
                        else
                        {
                            dr[i + 4] = "0";
                        }
                    }
                    dt.Rows.Add(dr);
                }
                dgv.DataSource = dt;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    double a = 0;
                    for (int j = 4; j < dgv.ColumnCount; j++)
                    {
                        string b = dgv[j, i].Value.ToString();
                        if (dgv.Columns[j].HeaderText != "INPUT" && dgv.Columns[j].HeaderText != "OUTPUT")
                        {
                            a += double.Parse(dgv[j, i].Value.ToString());
                        }
                    }
                    dgv[3, i].Value = a;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void GridBindProcess()
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
                    DateFrom = DateTime.Parse(dtp_from.Text),
                    DateTo = DateTime.Parse(dtp_to.Text)
                };

                ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionProcessCbm(), dgvVo, connection);
                var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["inspect"] select row.Field<string>("inspect")).Distinct();
                DataTable dt = new DataTable();
                dt.Columns.Add("Model");
                dt.Columns.Add("Line");
                dt.Columns.Add("Process");
                dt.Columns.Add("Total_NG");
                foreach (var a in distinctProcess)
                {
                    dt.Columns.Add(a.ToString());
                }

                var infoSerno = (from row in listvo.dt.AsEnumerable() select row).ToList();

                var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["inspect"] select row.Field<double>("inspectdata")).ToList();

                DataRow dr = dt.NewRow();

                dr[0] = infoSerno[0]["model"].ToString();
                dr[1] = infoSerno[0]["line"].ToString();
                dr[2] = infoSerno[0]["process"].ToString();

                for (int i = 0; i < inspectdata.Count; i++)
                {
                    dr[i + 4] = inspectdata[i];
                }
                dt.Rows.Add(dr);
                dgv.DataSource = dt;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    double a = 0;
                    for (int j = 4; j < dgv.ColumnCount; j++)
                    {
                        a += double.Parse(dgv[j, i].Value.ToString());
                    }
                    dgv[3, i].Value = a;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void search_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (search_cmb.Text == "Time")
            {
                dtp_from.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtp_to.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            }
            else if (search_cmb.Text == "Date")
            {
                dtp_from.CustomFormat = "yyyy-MM-dd 00:00:00";
                dtp_to.CustomFormat = "yyyy-MM-dd 23:59:59";
            }
        }
    }
}