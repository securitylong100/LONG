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
    public class CheckDetailPositionDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DetailPositionVo inVo = (DetailPositionVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as DetailPositionCounter ");
            sql.Append(" from  m_detail_postion");
            sql.Append(" Where 1=1 ");
    
           
            if (!string.IsNullOrEmpty(inVo.DetailPositionCode))
            {
                sql.Append(" and UPPER(detail_postion_cd) = UPPER(:detail_postion_cd) ");
                sqlParameter.AddParameterString("detail_postion_cd", inVo.DetailPositionCode);
            }
            if (inVo.DetailPositionId > 0)
            {
                sql.Append(" and detail_postion_id != :detail_postion_id "); ///?????
                sqlParameter.AddParameterInteger("detail_postion_id", inVo.DetailPositionId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            DetailPositionVo outVo = new DetailPositionVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["DetailPositionCounter"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
