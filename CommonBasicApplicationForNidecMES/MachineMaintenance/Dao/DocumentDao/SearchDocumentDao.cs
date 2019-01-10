using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchDocumentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DocumentVo inVo = (DocumentVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DocumentVo> voList = new ValueObjectList<DocumentVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT a.document_id, a.document_cd, a.document_name, b.model_cd,a.department,
                        a.groups, a.revision, a.update_date_time, a.registration_user_cd,a.registration_date_time, a.registration_user_cd, a.factory_cd 
                        from t_document a 

                        left join m_model b on b.model_id = a.model_id
                        WHERE 1 = 1");


            //sql.Append(@"time_record >= :timefrom");
            //sqlParameter.AddParameterDateTime("timefrom", inVo.TimeFrom);

            //sql.Append(" and time_record <= :timeto");
            //sqlParameter.AddParameterDateTime("timeto", inVo.TimeTo);

            sql.Append(" and model_cd =:model_cd ");
            sqlParameter.AddParameterString("model_cd", inVo.ModelCode);

            if (!String.IsNullOrEmpty(inVo.DocumentCode))
            {
                sql.Append(" and document_cd =:document_cd ");
                sqlParameter.AddParameterString("document_cd", inVo.DocumentCode);
            }
            if (!String.IsNullOrEmpty(inVo.DocumentName))
            {
                sql.Append(" and document_name =:document_name ");
                sqlParameter.AddParameterString("document_name", inVo.DocumentName);
            }
            if (!String.IsNullOrEmpty(inVo.Department))
            {
                sql.Append(" and department =:department ");
                sqlParameter.AddParameterString("department", inVo.Department);
            }
            if (!String.IsNullOrEmpty(inVo.Group))
            {
                sql.Append(" and groups =:groups ");
                sqlParameter.AddParameterString("groups", inVo.Group);
            }
            if (!String.IsNullOrEmpty(inVo.DocumentType))
            {
                sql.Append(" and document_type =:document_type ");
                sqlParameter.AddParameterString("document_type", inVo.DocumentType);
            }
            if (!String.IsNullOrEmpty(inVo.RegistrationUserCode))
            {
                sql.Append(" and registration_user_cd =:registration_user_cd ");
                sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            }

            sql.Append(" order by document_cd ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DocumentVo outVo = new DocumentVo
                {
                    //  , h., i., k., o.prodution_work_content_name
                    DocumentID = int.Parse(dataReader["document_id"].ToString()),
                    DocumentCode = dataReader["document_cd"].ToString(),
                    DocumentName = dataReader["document_name"].ToString(),
                    Department = dataReader["department"].ToString(),
                    Group = dataReader["groups"].ToString(),
                    TimeFrom = DateTime.Parse(dataReader["update_date_time"].ToString()),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    ModelCode = dataReader["model_cd"].ToString(),                 
                    Revision = dataReader["revision"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }


}
