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
            ValueObjectList<ProductionControllerGA1Vo> voList = new ValueObjectList<ProductionControllerGA1Vo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select a.serno,  a.inspectdate, a.process,  b.inspectdata from  " + inVo.TableName);
            sql.Append(" a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate = b.inspectdate ");

            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and a.model  =:model");
                sqlParameter.AddParameterString("model", inVo.ModelCode);
            }
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(@" and a.line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }
            if (!string.IsNullOrEmpty(inVo.ProcessCode))
            {
                sql.Append(@" and a.process  =:process");
                sqlParameter.AddParameterString("process", inVo.ProcessCode);
            }

            sql.Append(@" order by a.inspectdate");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerGA1Vo outVo = new ProductionControllerGA1Vo
                {
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