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
    class GetModelTestDao : AbstractDataAccessObject
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
            sql.Append(@"select distinct model from processtbl");

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
