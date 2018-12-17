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
    class GetProcessWorkDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProcessWorkVo inVo = (ProcessWorkVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProcessWorkVo> voList = new ValueObjectList<ProcessWorkVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT b.process_work_id, b.process_work_name from m_process_work b, m_machine a where a.machine_id = b.machine_id and a.machine_id = :machine_id order by process_work_id");


            sqlParameter.AddParameterInteger("machine_id", inVo.ProcessWorkId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProcessWorkVo outVo = new ProcessWorkVo
                {
                     ProcessWorkId = int.Parse(dataReader["process_work_id"].ToString()),
                     ProcessWorkName = dataReader["process_work_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
