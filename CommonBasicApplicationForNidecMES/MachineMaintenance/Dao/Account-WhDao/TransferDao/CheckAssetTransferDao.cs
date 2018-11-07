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
    public class CheckAssetTransferDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as AssetCount from t_transfer_detail_info where 1 = 1 and asset_id = :asset_id ");
            sqlParameter.AddParameterInteger("asset_id", inVo.AssetID);
             
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            TransferVo outVo = new TransferVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["AssetCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
