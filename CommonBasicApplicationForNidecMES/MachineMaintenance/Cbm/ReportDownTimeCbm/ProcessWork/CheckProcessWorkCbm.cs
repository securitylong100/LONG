using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm
{
    public class CheckProcessWorkCbm : CbmController
    {

        private readonly DataAccessObject checkProcessWorkDao = new CheckProcessWorkDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkProcessWorkDao.Execute(trxContext, vo);

        }
    }
}
