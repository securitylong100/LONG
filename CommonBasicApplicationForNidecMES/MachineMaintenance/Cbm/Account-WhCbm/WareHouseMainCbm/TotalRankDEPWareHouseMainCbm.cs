using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm
{
 public class TotalRankDEPWareHouseMainCbm : CbmController
    {
        private static readonly DataAccessObject getDao = new TotalRankDEPWareHouseMainDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
            {
                //throw ApplicationException
                return null;
            }

            return getDao.Execute(trxContext, vo);
        }
    }

    
}
