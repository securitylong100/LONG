using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchBoxIDProDao : AbstractDataAccessObject
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
            sql.Append("select a.boxid, a.printdate, a.user_cd, a.shipdate from t_box_id a left join t_product_serial b on b.boxid = a.boxid where 1 = 1");

            sql.Append(" and b.serialno >= :serialno");
            sqlParameter.AddParameterString("serialno", inVo.A90Barcode);

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