using System.Text;
using Com.Nidec.Mes.Framework;
using System;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionINPUTDao : AbstractDataAccessObject
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
            string sqlChung = " times, model,line, process,sum(inspectdata) inspectdata from (select a.serno,a.model,a.line, a.process,sum(inspectdata) inspectdata,a.inspectdate from ldp_5sg201902 a left join ldp_5sg201902data b on a.serno = b.serno where a.inspectdate = b.inspectdate and a.inspectdate >= :datefrom and a.inspectdate <= :dateto group by a.serno,a.model,a.line, a.process,a.inspectdate order by a.inspectdate) tbl where inspectdate >= ";
            sql.Append("select '06:00:00'" + sqlChung + " '" + inVo.Date + " 06:00:00' and inspectdate <= '" + inVo.Date + " 06:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '07:00:00'" + sqlChung + " '" + inVo.Date + " 06:00:00' and inspectdate <= '" + inVo.Date + " 07:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '08:00:00'" + sqlChung + " '" + inVo.Date + " 07:00:01' and inspectdate <= '" + inVo.Date + " 08:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '09:00:00'" + sqlChung + " '" + inVo.Date + " 08:00:01' and inspectdate <= '" + inVo.Date + " 09:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '10:00:00'" + sqlChung + " '" + inVo.Date + " 09:00:01' and inspectdate <= '" + inVo.Date + " 10:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '11:00:00'" + sqlChung + " '" + inVo.Date + " 10:00:01' and inspectdate <= '" + inVo.Date + " 11:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '12:00:00'" + sqlChung + " '" + inVo.Date + " 11:00:01' and inspectdate <= '" + inVo.Date + " 12:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '13:00:00'" + sqlChung + " '" + inVo.Date + " 12:00:01' and inspectdate <= '" + inVo.Date + " 13:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '14:00:00'" + sqlChung + " '" + inVo.Date + " 13:00:01' and inspectdate <= '" + inVo.Date + " 14:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '15:00:00'" + sqlChung + " '" + inVo.Date + " 14:00:01' and inspectdate <= '" + inVo.Date + " 15:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '16:00:00'" + sqlChung + " '" + inVo.Date + " 15:00:01' and inspectdate <= '" + inVo.Date + " 16:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '17:00:00'" + sqlChung + " '" + inVo.Date + " 16:00:01' and inspectdate <= '" + inVo.Date + " 17:00:00' group by model,line, process");
            sql.Append(" union ");
            sql.Append("select '18:00:00'" + sqlChung + " '" + inVo.Date + " 17:00:01' and inspectdate <= '" + inVo.Date + " 18:00:00' group by model,line, process");

            sql.Append(" order by times, process ");
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

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