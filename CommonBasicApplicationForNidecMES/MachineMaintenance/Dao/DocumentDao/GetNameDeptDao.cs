using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetNameDeptDao : AbstractDataAccessObject
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
            sql.Append(@"SELECT document_name from t_document where 1 = 1");

            //sqlParameter.AddParameterString("department", inVo.Department);

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
            if (!String.IsNullOrEmpty(inVo.DocumentCode))
            {
                sql.Append(" and document_cd =:document_cd ");
                sqlParameter.AddParameterString("document_cd", inVo.DocumentCode);
            }

            sql.Append(" and model_id =:model_id ");
            sqlParameter.AddParameterInteger("model_id", inVo.ModelID);

            sql.Append(" order by document_name");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DocumentVo outVo = new DocumentVo
                {
                    DocumentName = dataReader["document_name"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}