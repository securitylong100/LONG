using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteDetailPositionDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DetailPositionVo inVo = (DetailPositionVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_detail_postion Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.DetailPositionId > 0)
            {
                sql.Append(" and detail_postion_id = :detail_postion_id ");
                sqlParameter.AddParameterInteger("detail_postion_id", inVo.DetailPositionId);
            }
            if (!string.IsNullOrEmpty(inVo.DetailPositionCode))
            {
                sql.Append(" and detail_postion_cd = :detail_postion_cd ");
                sqlParameter.AddParameterString("detail_postion_cd", inVo.DetailPositionCode);
            }
            if (!string.IsNullOrEmpty(inVo.DetailPositionName))
            {
                sql.Append(" and detail_postion_name = :detail_postion_name ");
                sqlParameter.AddParameterString("detail_postion_name", inVo.DetailPositionName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

           DetailPositionVo outVo = new DetailPositionVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
