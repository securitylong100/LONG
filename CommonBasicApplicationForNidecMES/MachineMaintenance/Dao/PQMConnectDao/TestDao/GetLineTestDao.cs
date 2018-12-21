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
    class GetLineTestDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TestVo inVo = (TestVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<TestVo> voList = new ValueObjectList<TestVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select distinct line from processtbl where 1=1 ");

            if (!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(" and model = :model ");
                sqlParameter.AddParameterString("model", inVo.Model);
            }

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            TestVo outVo1 = new TestVo
            {
                dt = ds.Tables[0],
            };

            return outVo1;
        }
    }
}