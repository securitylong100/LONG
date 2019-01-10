using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetDocumentCodeDao : AbstractDataAccessObject
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
            sql.Append(@"SELECT document_cd from t_document where 1 = 1");

            if (!String.IsNullOrEmpty(inVo.DocumentType))
            {
                sql.Append(" and document_type =:document_type ");
                sqlParameter.AddParameterString("document_type", inVo.DocumentType);
            }

            sql.Append(" and model_id =:model_id ");
            sqlParameter.AddParameterInteger("model_id", inVo.ModelID);

            sql.Append(" order by document_cd");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DocumentVo outVo = new DocumentVo
                {
                    DocumentCode = dataReader["document_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}