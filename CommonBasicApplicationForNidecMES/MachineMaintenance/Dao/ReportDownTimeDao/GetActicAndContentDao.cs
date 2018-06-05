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
    class GetActicAndContentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo  inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProdutionWorkContentVo> voList = new ValueObjectList<ProdutionWorkContentVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT b.prodution_work_content_id, b.prodution_work_content_name from m_prodution_work_content b, m_response_machine a where a.prodution_work_content_id = b.prodution_work_content_id and machine_id = :machine_id order by display_order");


            sqlParameter.AddParameterInteger("machine_id", inVo.ProdutionWorkContentId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProdutionWorkContentVo outVo = new ProdutionWorkContentVo
                {
                     ProdutionWorkContentId=int.Parse(dataReader["prodution_work_content_id"].ToString()),
                     ProdutionWorkContentName = dataReader["prodution_work_content_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
