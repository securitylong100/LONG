using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateDocumentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DocumentVo inVo = (DocumentVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_document set document_cd=:document_cd,
                                           model_id=:model_id,
                                           department=:department,
                                           groups=:groups,
                                           document_type=:document_type,
                                           update_date_time=now(),
                                           revision=:revision");
            sql.Append(" where document_id =:document_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("document_id", inVo.DocumentID);
            sqlParameter.AddParameter("document_cd", inVo.DocumentCode);
            sqlParameter.AddParameter("model_id", inVo.ModelID);
            sqlParameter.AddParameter("department", inVo.Department);
            sqlParameter.AddParameter("groups", inVo.Group);
            sqlParameter.AddParameter("document_type", inVo.DocumentType);
            sqlParameter.AddParameter("update_date_time", inVo.TimeFrom);
            sqlParameter.AddParameter("revision", inVo.Revision);


            //execute SQL

            DocumentVo outVo = new DocumentVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}