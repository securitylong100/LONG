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
    public class AddDetailRequestDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_transfer_detail_info(transfer_device_id, asset_id, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:transfer_device_id,:asset_id, :registration_user_cd,now(),:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("transfer_device_id", inVo.TransferDeviceId);
            sqlParameter.AddParameterInteger("asset_id", inVo.AssetID);
        
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            TransferVo outVo = new TransferVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
