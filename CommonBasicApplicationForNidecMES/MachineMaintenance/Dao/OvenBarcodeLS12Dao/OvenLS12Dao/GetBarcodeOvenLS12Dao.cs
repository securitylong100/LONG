﻿using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
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
    public class GetBarcodeOvenLS12Dao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            OvenBarcodeVo inVo = (OvenBarcodeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<OvenBarcodeVo> voList = new ValueObjectList<OvenBarcodeVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select distinct barcode from t_ovenmachine_ls 
                        where 1=1 ");

            if (!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(@" and model = :model ");
                sqlParameter.AddParameterString("model", inVo.Model);
            }
            if (!String.IsNullOrEmpty(inVo.Line))
            {
                sql.Append(@" and line_cd = :line_cd ");
                sqlParameter.AddParameterString("line_cd", inVo.Line);
            }
            sql.Append(" order by barcode");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            
            

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                OvenBarcodeVo outVo = new OvenBarcodeVo
                {

             
                    Barcode = dataReader["barcode"].ToString(),
                    
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
