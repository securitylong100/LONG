using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchBoxIDDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            GA1ModelVo voList = new GA1ModelVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select boxid, printdate, user_cd as User, shipdate from t_box_id where 1 = 1");

            if (inVo.PrintDate.ToString() != "0001/01/01 00:00:00")
            {
                sql.Append(" and printdate >= :printdate and printdate < :printdate1");
                sqlParameter.AddParameterDateTime("printdate", inVo.PrintDate);
                sqlParameter.AddParameterDateTime("printdate1", inVo.PrintDate.AddDays(1));
            }
            if (inVo.ShipDate.ToString() != "0001/01/01 00:00:00")
            {
                sql.Append(@" and shipdate >= :shipdate and shipdate < :shipdate1");
                sqlParameter.AddParameterDateTime("shipdate", inVo.ShipDate);
                sqlParameter.AddParameterDateTime("shipdate1", inVo.ShipDate.AddDays(1));
            }

            sql.Append(@" order by boxid");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = new DataSet();
            ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);
            //execute SQL
            //IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            GA1ModelVo outVo = new GA1ModelVo
            {
                dt = ds.Tables[0]
            };

            return outVo;
        }
    }
}