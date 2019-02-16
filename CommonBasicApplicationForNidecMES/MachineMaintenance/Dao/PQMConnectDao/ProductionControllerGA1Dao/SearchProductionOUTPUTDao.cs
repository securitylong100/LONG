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
            string sqlChung = " times,count(*)  from (select a90_barcode, a90_date+a90_time datetimes from t_checkpusha90 where a90_thurst_status = 'OK' and  a90_date+a90_time >= :datefrom and a90_date+a90_time <= :dateto) wl where datetimes >= ";
            sql.Append(@"select '06:00:00' " + sqlChung + " '" + inVo.Date + " 06:00:00' and datetimes <= '" + inVo.Date + " 06:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '07:00:00' " + sqlChung + " '" + inVo.Date + " 06:00:00' and datetimes <= '" + inVo.Date + " 07:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '08:00:00' " + sqlChung + " '" + inVo.Date + " 07:00:00' and datetimes <= '" + inVo.Date + " 08:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '09:00:00' " + sqlChung + " '" + inVo.Date + " 08:00:00' and datetimes <= '" + inVo.Date + " 09:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '10:00:00' " + sqlChung + " '" + inVo.Date + " 09:00:00' and datetimes <= '" + inVo.Date + " 10:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '11:00:00' " + sqlChung + " '" + inVo.Date + " 10:00:00' and datetimes <= '" + inVo.Date + " 11:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '12:00:00' " + sqlChung + " '" + inVo.Date + " 11:00:00' and datetimes <= '" + inVo.Date + " 12:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '13:00:00' " + sqlChung + " '" + inVo.Date + " 12:00:00' and datetimes <= '" + inVo.Date + " 13:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '14:00:00' " + sqlChung + " '" + inVo.Date + " 13:00:00' and datetimes <= '" + inVo.Date + " 14:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '15:00:00' " + sqlChung + " '" + inVo.Date + " 14:00:00' and datetimes <= '" + inVo.Date + " 15:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '16:00:00' " + sqlChung + " '" + inVo.Date + " 15:00:00' and datetimes <= '" + inVo.Date + " 16:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '17:00:00' " + sqlChung + " '" + inVo.Date + " 16:00:00' and datetimes <= '" + inVo.Date + " 17:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '18:00:00' " + sqlChung + " '" + inVo.Date + " 17:00:00' and datetimes <= '" + inVo.Date + " 18:00:00'");
            sql.Append(" order by times ");

            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            //if (!string.IsNullOrEmpty(inVo.LineCode))
            //{
            //    sql.Append(@" and a90_line  =:line");
            //    sqlParameter.AddParameterString("line", inVo.LineCode);
            //}
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