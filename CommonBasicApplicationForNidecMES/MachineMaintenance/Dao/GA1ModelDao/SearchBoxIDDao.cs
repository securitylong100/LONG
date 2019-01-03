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
            ValueObjectList<GA1ModelVo> voList = new ValueObjectList<GA1ModelVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select boxid, printdate, user_cd, shipdate from t_box_id where 1 = 1");

            if (!String.IsNullOrEmpty(inVo.PrintDate.ToString()))
            {
                sql.Append(" and printdate >= :printdate and printdate < :printdate1");
                sqlParameter.AddParameterDateTime("printdate", inVo.PrintDate);
                sqlParameter.AddParameterDateTime("printdate1", inVo.PrintDate.AddDays(1));
            }
            if (!String.IsNullOrEmpty(inVo.ShipDate.ToString()))
            {
                sql.Append(@" and shipdate >= :shipdate and shipdate < :shipdate1");
                sqlParameter.AddParameterDateTime("shipdate", inVo.ShipDate);
                sqlParameter.AddParameterDateTime("shipdate1", inVo.ShipDate.AddDays(1));
            }
            
            sql.Append(@" order by boxid");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                GA1ModelVo outVo = new GA1ModelVo
                {
                    BoxID = dataReader["boxid"].ToString(),
                    PrintDate = DateTime.Parse(dataReader["printdate"].ToString()),
                    User = dataReader["user_cd"].ToString(),
                    ShipDate = DateTime.Parse(dataReader["shipdate"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}