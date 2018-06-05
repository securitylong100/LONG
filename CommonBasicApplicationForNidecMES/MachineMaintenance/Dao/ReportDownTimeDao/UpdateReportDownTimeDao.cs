using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateReportDownTimeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ReportDownTimeVo inVo = (ReportDownTimeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_downtime_report set time_from=:time_from,time_to=:time_to,
                prodution_work_content_id=:prodution_work_content_id,line_id=:line_id,
                model_id=:model_id,machine_id=:machine_id,defective_reason_id=:defective_reason_id, remarks=:remarks");
            sql.Append(" where downtime_report_id =:downtime_report_id");




            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("downtime_report_id", inVo.DowntimeReportId);
            sqlParameter.AddParameterDateTime("time_to", inVo.TimeTo);
            sqlParameter.AddParameterDateTime("time_from", inVo.TimeFrom);
            sqlParameter.AddParameterString("remarks", inVo.Remakes);

            sqlParameter.AddParameterInteger("line_id", inVo.LineId);
            sqlParameter.AddParameterInteger("machine_id", inVo.MachineId);
            sqlParameter.AddParameterInteger("model_id", inVo.ModelId);
            sqlParameter.AddParameterInteger("prodution_work_content_id", inVo.ProductionWorkContentId);
            sqlParameter.AddParameterInteger("defective_reason_id", inVo.DefectiveReasonId);
            //execute SQL

            ReportDownTimeVo outVo = new ReportDownTimeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}