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
    public partial class TestForm : FormCommonNCVP
    {
        public TestForm()
        {
            InitializeComponent();
        }
        public static readonly string connection = "Server=192.168.145.12;Port=5432;UserId=pqm;Password=mesdb;Database=pqmdb;;";
        private void TestForm_Load(object sender, EventArgs e)
        {
            loadDGV();
            loadBegin();
        }
        public void loadBegin()
        {
            TestVo testVo = (TestVo)DefaultCbmInvoker.Invoke(new GetModelTestCbm(), new TestVo() { }, connection);

            model_cmb.DataSource = testVo.dt;
            model_cmb.DisplayMember = "model";
        }
        public void loadDGV()
        {
            TestVo testVo = (TestVo)DefaultCbmInvoker.Invoke(new GetTestCbm(), new TestVo() { }, connection);

            //production_controller_dgv.DataSource = testVo.dt;
            var distinctNames = (from row in testVo.dt.AsEnumerable() select row.Field<string>("inspect")).Distinct();
            DataTable dt = new DataTable();
            dt.Columns.Add("Model");
            dt.Columns.Add("Line");
            dt.Columns.Add("Process");
            dt.Columns.Add("Serno");
            dt.Columns.Add("Lot");
            dt.Columns.Add("Judge");
            dt.Columns.Add("Date");
            foreach (var a in distinctNames)
            {
                dt.Columns.Add(a.ToString());
            }


            var distinctSerno = (from row in testVo.dt.AsEnumerable() select row.Field<string>("serno")).Distinct();

            foreach (var serno in distinctSerno)
            {
                var infoSerno = (from row in testVo.dt.AsEnumerable() where row.Field<string>("serno") == serno.ToString() select row).ToList();

                var inspectdata = (from row in testVo.dt.AsEnumerable() where row.Field<string>("serno") == serno.ToString() select row.Field<double>("inspectdata")).ToList();

                DataRow dr = dt.NewRow();

                dr[0] = infoSerno[0]["model"].ToString();
                dr[1] = infoSerno[0]["line"].ToString();
                dr[2] = infoSerno[0]["process"].ToString();
                dr[3] = infoSerno[0]["serno"].ToString();
                dr[4] = infoSerno[0]["lot"].ToString();
                dr[5] = infoSerno[0]["tjudge"].ToString();
                dr[6] = infoSerno[0]["datetimes"].ToString();

                for (int i = 0; i < dt.Columns.Count - 7; i++)
                {
                    dr[i + 7] = inspectdata[i].ToString();
                }
                dt.Rows.Add(dr);
            }
            production_controller_dgv.DataSource = dt;
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TestVo testVo = (TestVo)DefaultCbmInvoker.Invoke(new GetLineTestCbm(), new TestVo() { Model = "LD4" }, connection);

            //line_cmb.DataSource = testVo.dt;
            //line_cmb.DisplayMember = "line";
        }

        private void search_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
