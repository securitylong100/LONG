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
        }
        public static readonly string connection = "Server=192.168.145.12;Port=5432;UserId=pqm;Password=mesdb;Database=pqmdb;;";
        public static readonly string connectionmes = "Server=192.168.145.12;Port=5432;UserId=pqm;Password=mesdb;Database=mesdb;;";
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
        private void btn_SearchData_Click(object sender, EventArgs e)
        {
            funtion();
            btn_Run.Enabled = false;
            btnStop.Enabled = true;
            timer1.Enabled = true;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btn_Run.Enabled = true;
            btnStop.Enabled = false;
            timer1.Enabled = false;
        }

        private void funtion()
        {
            lblInput1.Text = GridBindNew("FA_IP");
            lblOutput1.Text = GridBindNew("FA_OP");
            lblF1.Text = GridBindNew("FA_BallB");
            lblF2.Text = GridBindNew("FA_Caulk");
            lblF3.Text = GridBindNew("FA_APP");
            lblNg1.Text = (int.Parse(lblF1.Text) + int.Parse(lblF2.Text) + int.Parse(lblF3.Text)).ToString();

            lblInput2.Text = GridBindNew("GC_IP");
            lblOutput2.Text = GridBindNew("GC_OP");
            lblG1.Text = GridBindNew("GC_Bear");
            lblG2.Text = GridBindNew("GC_OSW");
            lblG3.Text = GridBindNew("GC_PD");
            lblG4.Text = GridBindNew("GC_C");
            lblG5.Text = GridBindNew("GC_PU");
            lblG6.Text = GridBindNew("GC_FGASS");
            lblG7.Text = GridBindNew("GC_FGCHK");
            lblNG2.Text = (int.Parse(lblG1.Text) + int.Parse(lblG2.Text) + int.Parse(lblG3.Text) + int.Parse(lblG4.Text) + int.Parse(lblG5.Text) + int.Parse(lblG6.Text) + int.Parse(lblG7.Text)).ToString();

            lblInput3.Text = GridBindNew("MC_IP");
            lblOutput3.Text = GridBindOutputMotor(true);
            lblM1.Text = GridBindNew("MC_FWCHK");
            lblM2.Text = GridBindNew("MC_STMASS");
            lblM3.Text = GridBindNew("MC_FPC");
            lblM4.Text = GridBindNew("MC_Mark");
            lblM5.Text = GridBindOutputMotor(false);
            lblM6.Text = GridBindNew("MC_NOICHK");
            lblM7.Text = GridBindNew("MC_APPCHK");
            lblNG3.Text = (int.Parse(lblM1.Text) + int.Parse(lblM2.Text) + int.Parse(lblM3.Text) + int.Parse(lblM4.Text) + int.Parse(lblM5.Text) + int.Parse(lblM6.Text) + int.Parse(lblM7.Text)).ToString();
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
            chart_pie.ResetAutoValues();
            chart_pie.ResumeLayout();
            chart_pie.Series.Clear();

            chart_pie.Titles[0].Text = "Process Comparison"; //ten
            chart_pie.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chart_pie.Series.Add("Pie");
            chart_pie.Series["Pie"].ChartType = SeriesChartType.Pie;
            chart_pie.Series["Pie"].IsValueShownAsLabel = true;

            string header = "";
            for (int j = 6; j < dgv.ColumnCount; j++)
            {
                int value = 0;
                if (dgv.Columns[j].HeaderText != "FA_IP" && dgv.Columns[j].HeaderText != "FA_OP" && dgv.Columns[j].HeaderText != "GC_IP" && dgv.Columns[j].HeaderText != "GC_OP" && dgv.Columns[j].HeaderText != "MC_IP" && dgv.Columns[j].HeaderText != "OUTPUT")
                {
                    header = dgv.Columns[j].HeaderText;
                    if (dgv.Rows[dgv.RowCount - 1].Cells[j].Value.ToString() != "")
                    {
                        value += int.Parse(dgv.Rows[dgv.RowCount - 1].Cells[j].Value.ToString());
                    }
                    chart_pie.Series["Pie"].Points.AddXY(header, value);
                }
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
                    for (int i = 0; i < dgv.RowCount-1; i++)
                    {
                        if (dgv.Columns.Contains("OUTPUT"))
                        {
                            if (dgv.Rows[i].Cells["OUTPUT"].Value.ToString() != "")
                            {
                                dataOut += double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString());
                            }
                        }
                        if (dgv.Columns.Contains("FA_IP")) { dataIn += double.Parse(dgv.Rows[i].Cells["FA_IP"].Value.ToString()); }
                        double dataNG = double.Parse(dgv.Rows[i].Cells["Total_NG"].Value.ToString());
                        chr_main.Series["Output"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataOut);
                        chr_main.Series["Input"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataIn);
                        chr_main.Series["YEILD"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), Math.Round(((dataNG / dataOut) * 100) < 100 ? ((dataNG / dataOut) * 100) : 100, 2));

                    }
                }
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            GridBind();
            showchartLine(false);
            showchartProcess();
            //GridBindByDate();
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
                    DateTo = DateTime.Parse(dtp_to.Text),
                    grDate = false,
                    Date = DateTime.Parse(dtp_to.Text).ToShortDateString(),
                };

                ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionINPUTCbm(), dgvVo, connection);
                ProductionControllerGA1Vo outputvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionOUTPUTCbm(), dgvVo, connectionmes);
                var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
                DataTable dt = new DataTable();
                dt.Columns.Add("Model");
                dt.Columns.Add("Line");
                dt.Columns.Add("Date");
                dt.Columns.Add("Total_NG");
                dt.Columns.Add("OUTPUT");
                dt.Columns.Add("RateNG");
                foreach (var a in distinctProcess)
                {
                    dt.Columns.Add(a.ToString());
                }

                var distinctTime = (from row in listvo.dt.AsEnumerable() orderby row["times"] select row.Field<string>("times")).Distinct();
                foreach (var times in distinctTime)
                {
                    if (listvo.dt.Rows.Count > 0)
                    {
                        var info = (from row in listvo.dt.AsEnumerable() where row.Field<string>("times") == times.ToString() select row).ToList();

                        var inspectdata = (from row in listvo.dt.AsEnumerable() where row.Field<string>("times") == times.ToString() select row).ToList();

                        DataRow dr = dt.NewRow();

                        dr[0] = info[0]["model"].ToString();
                        dr[1] = info[0]["line"].ToString();
                        dr[2] = info[0]["times"].ToString();
                        int j = 0;
                        for (int i = 0; i < dt.Columns.Count - 6; i++)
                        {
                            if (j < inspectdata.Count)
                            {
                                if (dt.Columns[i + 6].ColumnName == inspectdata[j]["process"].ToString())
                                {
                                    dr[i + 6] = inspectdata[j]["inspectdata"].ToString();
                                    j++;
                                }
                                else
                                {
                                    dr[i + 6] = "0";
                                }
                            }
                            else dr[i + 6] = "0";
                        }
                        dt.Rows.Add(dr);
                    }
                }

                //sum hang cuoi
                DataRow dr1 = dt.NewRow();
                for (int i = 6; i < dt.Columns.Count; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        sum += double.Parse(dt.Rows[j][i].ToString());
                        dr1[i] = sum;
                    }
                }
                dt.Rows.Add(dr1);

                    dgv.DataSource = dt;
                //int t = 0;
                for (int i = 0; i < dgv.RowCount-1; i++)
                {
                    double totalNG = 0;
                    double rateNG = 0;
                    for (int t = 0; t < outputvo.dt.Rows.Count; t++)
                    {
                        if (dgv.Rows[i].Cells["Date"].Value.ToString() == outputvo.dt.Rows[t]["times"].ToString())
                        {
                            dgv.Rows[i].Cells["OUTPUT"].Value = outputvo.dt.Rows[t]["count"].ToString();
                        }
                    }
                    for (int j = 6; j < dgv.ColumnCount; j++)
                    {
                        string b = dgv[j, i].Value.ToString();
                        if (dgv.Columns[j].HeaderText != "FA_IP" && dgv.Columns[j].HeaderText != "FA_OP" && dgv.Columns[j].HeaderText != "GC_IP" && dgv.Columns[j].HeaderText != "GC_OP" && dgv.Columns[j].HeaderText != "MC_IP" && dgv.Columns[j].HeaderText != "OUTPUT")
                        {
                            if (dgv[j, i].Value.ToString() != "")
                            {
                                totalNG += double.Parse(dgv[j, i].Value.ToString());
                            }
                        }
                    }

                    double output = double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString());
                    if(output == 0) { rateNG = 0; } else rateNG = (totalNG / output) * 100;

                    dgv["RateNG", i].Value = rateNG;
                    dgv["Total_NG", i].Value = totalNG;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        //private void GridBind()
        //{
        //    tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
        //    try
        //    {
        //        ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
        //        {
        //            TableName = tablename,
        //            ModelCode = cmb_model.Text,
        //            LineCode = cmb_line.Text,
        //            ProcessCode = cmb_process.Text,
        //            ItemCode = cmb_item.Text,
        //            DateFrom = DateTime.Parse(dtp_from.Text),
        //            DateTo = DateTime.Parse(dtp_to.Text),
        //            grDate = false,
        //        };

        //        ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionINPUTCbm(), dgvVo, connection);
        //        ProductionControllerGA1Vo outputvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionOUTPUTCbm(), dgvVo, connectionmes);
        //        var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("Model");
        //        dt.Columns.Add("Line");
        //        dt.Columns.Add("Star");
        //        dt.Columns.Add("End");
        //        dt.Columns.Add("Total_NG");
        //        dt.Columns.Add("OUTPUT");
        //        foreach (var a in distinctProcess)
        //        {
        //            dt.Columns.Add(a.ToString());
        //        }

        //        //var distinctId = (from row in listvo.dt.AsEnumerable() select row.Field<int>("id")).Distinct();
        //        //foreach (var serno in distinctId)
        //        if (listvo.dt.Rows.Count > 0)
        //        {
        //            //var infoSerno = (from row in listvo.dt.AsEnumerable() where row.Field<int>("id") == int.Parse(serno.ToString()) select row).ToList();

        //            var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row).ToList();

        //            DataRow dr = dt.NewRow();

        //            dr[0] = listvo.dt.Rows[0]["model"].ToString();
        //            dr[1] = listvo.dt.Rows[0]["line"].ToString();
        //            dr[2] = dtp_from.Text;
        //            dr[3] = dtp_to.Text;
        //            int j = 0;
        //            for (int i = 0; i < dt.Columns.Count - 6; i++)
        //            {
        //                //dr[5] = outputvo.dt.Rows[0][1].ToString();
        //                if (j < inspectdata.Count)
        //                {
        //                    if (dt.Columns[i + 6].ColumnName == inspectdata[j]["process"].ToString())
        //                    {
        //                        dr[i + 6] = inspectdata[j]["inspectdata"].ToString();
        //                        j++;
        //                    }
        //                    else
        //                    {
        //                        dr[i + 6] = "0";
        //                    }
        //                }
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //        dgv.DataSource = dt;
        //        for (int i = 0; i < dgv.RowCount; i++)
        //        {
        //            double a = 0;
        //            dgv.Rows[i].Cells["OUTPUT"].Value = outputvo.dt.Rows[0]["output"].ToString();
        //            for (int j = 6; j < dgv.ColumnCount; j++)
        //            {
        //                string b = dgv[j, i].Value.ToString();
        //                if (dgv.Columns[j].HeaderText != "INPUT" && dgv.Columns[j].HeaderText != "OUTPUT")
        //                {
        //                    if (dgv[j, i].Value.ToString() != "")
        //                    {
        //                        a += double.Parse(dgv[j, i].Value.ToString());
        //                    }
        //                }
        //            }
        //            dgv[4, i].Value = a;
        //        }
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }
        //}
        //private void GridBindByDate()
        //{
        //    tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
        //    try
        //    {
        //        ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
        //        {
        //            TableName = tablename,
        //            ModelCode = cmb_model.Text,
        //            LineCode = cmb_line.Text,
        //            ProcessCode = cmb_process.Text,
        //            ItemCode = cmb_item.Text,
        //            DateFrom = DateTime.Parse(dtp_from.Text),
        //            DateTo = DateTime.Parse(dtp_to.Text),
        //            grDate = true,
        //        };

        //        ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionInputByDateCbm(), dgvVo, connection);
        //        ProductionControllerGA1Vo outputvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionOUTPUTCbm(), dgvVo, connectionmes);
        //        var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("Model");
        //        dt.Columns.Add("Line");
        //        dt.Columns.Add("Date");
        //        dt.Columns.Add("Total_NG");
        //        dt.Columns.Add("OUTPUT");
        //        foreach (var a in distinctProcess)
        //        {
        //            dt.Columns.Add(a.ToString());
        //        }

        //        var distinctId = (from row in listvo.dt.AsEnumerable() select row.Field<DateTime>("dates")).Distinct();
        //        foreach (var serno in distinctId)
        //        {
        //            var infoSerno = (from row in listvo.dt.AsEnumerable() where row.Field<DateTime>("dates") == DateTime.Parse(serno.ToString()) select row).ToList();

        //            var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["process"] where row.Field<DateTime>("dates") == DateTime.Parse(serno.ToString()) select row).ToList();

        //            DataRow dr = dt.NewRow();

        //            dr[0] = infoSerno[0]["model"].ToString();
        //            dr[1] = infoSerno[0]["line"].ToString();
        //            dr[2] = DateTime.Parse(infoSerno[0]["dates"].ToString()).ToShortDateString();
        //            int j = 0;
        //            for (int i = 0; i < dt.Columns.Count - 5; i++)
        //            {
        //                if (j < inspectdata.Count)
        //                {
        //                    if (dt.Columns[i + 5].ColumnName == inspectdata[j]["process"].ToString())
        //                    {
        //                        dr[i + 5] = inspectdata[j]["inspectdata"].ToString();
        //                        j++;
        //                    }
        //                    else
        //                    {
        //                        dr[i + 5] = "0";
        //                    }
        //                }
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //        dgv.DataSource = dt;
        //        int k = 0;
        //        for (int i = 0; i < dgv_main.RowCount; i++)
        //        {
        //            if (dgv_main.Rows[i].Cells["Date"].Value.ToString() == DateTime.Parse(outputvo.dt.Rows[k]["datetimes"].ToString()).ToShortDateString())
        //            {
        //                dgv_main.Rows[i].Cells["OUTPUT"].Value = outputvo.dt.Rows[k]["output"].ToString();
        //                k++;
        //            }
        //            double a = 0;
        //            for (int j = 5; j < dgv_main.ColumnCount; j++)
        //            {
        //                string b = dgv_main[j, i].Value.ToString();
        //                if (dgv_main.Columns[j].HeaderText != "INPUT" && dgv_main.Columns[j].HeaderText != "OUTPUT")
        //                {
        //                    if (dgv_main[j, i].Value.ToString() != "")
        //                    {
        //                        a += double.Parse(dgv_main[j, i].Value.ToString());
        //                    }
        //                }
        //            }
        //            dgv_main[3, i].Value = a;
        //        }
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }
        //}
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

                if (inspectdata.Count > 0)
                {
                    dr[0] = infoSerno[0]["model"].ToString();
                    dr[1] = infoSerno[0]["line"].ToString();
                    dr[2] = infoSerno[0]["process"].ToString();
                }

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
                cmb_process.ResetText();
                dtp_from.CustomFormat = "yyyy-MM-dd 00:00:00";
                dtp_to.CustomFormat = "yyyy-MM-dd 23:59:59";
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(txtTimer.Text);
            funtion();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }
        private string GridBindNew(string ProcessName_)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionGA1Cbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value, ProcessName = ProcessName_ }, connection);
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }
        private string GridBindOutputMotor(bool t)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionoOutputMotorCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename, DateFrom = dtp_from.Value, DateTo = dtp_to.Value,change =t}, connectionmes);
                //cmb_item.DisplayMember = "ItemCode";
                //cmb_item.DataSource = assetvoinvoice.GetList();
                //cmb_item.Text = "";
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_line_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void cmb_model_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            callLine();
            cmb_process.Text = "";
            cmb_item.Text = "";
        }

        private void btnSearchData_Click(object sender, EventArgs e)
        {
            funtion();
        }
    }
}
