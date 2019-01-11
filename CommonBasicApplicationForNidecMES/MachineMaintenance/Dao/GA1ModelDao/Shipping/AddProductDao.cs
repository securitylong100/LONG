﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddProductDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            //DataTable dtadd = new DataTable();
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO t_product_serial(boxid, serialno, line, thurst, noise, oqc, model) " +
                    "VALUES (:boxid, :serialno, :line, :thurst, :noise, :oqc, :model)");

            //dtadd = inVo.dt;

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameter("boxid", inVo.BoxID);
            sqlParameter.AddParameter("serialno", inVo.A90Barcode);
            sqlParameter.AddParameter("line", inVo.LineCode);
            sqlParameter.AddParameter("thurst", inVo.A90ThurstStatus);
            sqlParameter.AddParameter("noise", inVo.A90NoiseStatus);
            sqlParameter.AddParameter("oqc", inVo.A90OQCStatus);
            sqlParameter.AddParameter("model", inVo.ModelCode);

            //execute SQL

            GA1ModelVo outVo = new GA1ModelVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}