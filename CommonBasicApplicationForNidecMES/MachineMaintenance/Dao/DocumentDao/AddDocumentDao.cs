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
    class AddDocumentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DocumentVo inVo = (DocumentVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"insert into t_document(document_cd, document_name, document_type, model_id, department, groups, revision, 
                        update_date_time, registration_user_cd, registration_date_time, factory_cd)");
            sql.Append(@"values(:document_cd, :document_name, :document_type, :model_id, :department, :groups, :revision,
                        now(), :registration_user_cd, now(), :factory_cd)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("document_id", inVo.DocumentID);
            sqlParameter.AddParameter("document_cd", inVo.DocumentCode);
            sqlParameter.AddParameter("document_name", inVo.DocumentName);
            sqlParameter.AddParameter("document_type", inVo.DocumentType);
            sqlParameter.AddParameter("model_id", inVo.ModelID);
            sqlParameter.AddParameter("department", inVo.Department);
            sqlParameter.AddParameter("groups", inVo.Group);
            sqlParameter.AddParameter("revision", inVo.Revision);
            sqlParameter.AddParameter("update_date_time", inVo.TimeFrom);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameter("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameter("factory_cd", inVo.FactoryCode);
            //execute SQL

            DocumentVo outVo = new DocumentVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
