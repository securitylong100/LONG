using System.Text;
using Com.Nidec.Mes.Framework;
using System;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionOUTPUTDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerGA1Vo inVo = (ProductionControllerGA1Vo)vo;
            StringBuilder sql = new StringBuilder();
            ProductionControllerGA1Vo voList = new ProductionControllerGA1Vo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            string date = "";
            string grdate = "";
            if (inVo.grDate)
            {
                date = ", datetimes";
                grdate = "group by datetimes";
            }
            else { date = ""; grdate = ""; }

            sql.Append(@"select count(*) output" + date + " from ");
            sql.Append(@"(select distinct(a90_barcode), cast(a90_datetime as date) datetimes from t_checkpusha90 ");
            sql.Append(@"where a90_thurst_status = 'OK' ");
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(@" and a90_line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }
            sql.Append(@" group by cast(a90_datetime as date), a90_barcode) tbl " + grdate + "");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL

            ProductionControllerGA1Vo outVo1 = new ProductionControllerGA1Vo
            {
                dt = ds.Tables[0],
            };

            return outVo1;

        }
    }
}