using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchThusrtByBarcodeDao : AbstractDataAccessObject
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
            sql.Append(@"select bar,a90_thurst_status from (select a90_barcode bar,max(a90_date+a90_time) datetimes from t_checkpusha90 group by a90_barcode) a left join t_checkpusha90 b on a.bar = b.a90_barcode and datetimes = a90_date+a90_time where 1=1 ");

            //if (!string.IsNullOrEmpty(inVo.A90Line))
            //{
            //    sql.Append(@" and a90_line  =:a90_line");
            //    sqlParameter.AddParameterString("a90_line", inVo.A90Line);

            //}
            if (!string.IsNullOrEmpty(inVo.A90Barcode))
            {
                sql.Append(@" and a90_barcode  =:a90_barcode");
                sqlParameter.AddParameterString("a90_barcode", inVo.A90Barcode);
            }

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                GA1ModelVo outVo = new GA1ModelVo
                {
                    A90Barcode = dataReader["bar"].ToString(),
                    A90ThurstStatus = dataReader["a90_thurst_status"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}