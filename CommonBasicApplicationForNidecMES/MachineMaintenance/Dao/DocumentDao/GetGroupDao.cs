﻿using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetGroupDao : AbstractDataAccessObject
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
            sql.Append(@"SELECT distinct groups from t_document where department = :department order by groups");

            sqlParameter.AddParameterString("department", inVo.Department);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DocumentVo outVo = new DocumentVo
                {
                    Group = dataReader["groups"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}