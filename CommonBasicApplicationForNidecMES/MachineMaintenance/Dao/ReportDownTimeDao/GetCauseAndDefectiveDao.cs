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
    class GetCauseAndDefectiveDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DefectiveReasonVo  inVo = (DefectiveReasonVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DefectiveReasonVo> voList = new ValueObjectList<DefectiveReasonVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT b.defective_reason_id, b.defective_reason_name from m_defective_reason b, m_cause a where a.defective_reason_id = b.defective_reason_id and machine_id = :machine_id order by display_order");


            sqlParameter.AddParameterInteger("machine_id", inVo.DefectiveReasonId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DefectiveReasonVo outVo = new DefectiveReasonVo
                {
                     DefectiveReasonId=int.Parse(dataReader["defective_reason_id"].ToString()),
                     DefectiveReasonName = dataReader["defective_reason_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
