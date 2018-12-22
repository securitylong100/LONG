using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetTestDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TestVo  inVo = (TestVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<TestVo> voList = new ValueObjectList<TestVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select a.serno ,a.lot , model, site, factory, line, process, a.inspectdate datetimes,  tjudge, inspect , inspectdata, judge from ls12_004a201812data a left join ls12_004a201812 b on a.serno = b.serno and a.inspectdate = b.inspectdate and a.lot = b.lot where 1=1 and a.inspectdate >= '2018-12-01 05:53:35' and a.inspectdate <= '2018-12-01 05:54:00'");

            //sqlParameter.AddParameterInteger("model_id);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                TestVo outVo = new TestVo
                {
                     //Serno = dataReader["serno"].ToString(),
                     dt = ds.Tables[0],
                };
                voList.add(outVo);
            }
            dataReader.Close();

            TestVo outVo1 = new TestVo
            {
                dt = ds.Tables[0],
            };

            return outVo1;
        }

    }

}
