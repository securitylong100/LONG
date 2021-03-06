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
    public class SearchProDetailAllLineCaseAssyNCVCDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerNCVCVo inVo = (ProductionControllerNCVCVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerNCVCVo> voList = new ValueObjectList<ProductionControllerNCVCVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select Case When times between '06:00:00' and '23:59:00' then dates when ");
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss,model_cd,'All Line' line_cd, sum(ca_app_metal_dirty) ca_app_metal_dirty, sum(ca_app_tape_hole_deform) ca_app_tape_hole_deform, sum(ca_app_metal_high) ca_app_metal_high, sum(ca_app_case_deform_scracth) ca_app_case_deform_scracth, sum(ca_app_metal_deform_scratch) ca_app_metal_deform_scratch, sum(ca_app_magnet_broken) ca_app_magnet_broken from ");

            sql.Append("(select i2.dates,i2.times,i2.model_cd,i2.line_cd, ca_app_metal_dirty, ca_app_tape_hole_deform, ca_app_metal_high, ca_app_case_deform_scracth, ca_app_metal_deform_scratch, ca_app_magnet_broken from t_ncvc_pdc_ca i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.ca_id) idca1  from t_ncvc_pdc_ca o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.ca_id) idca3  from t_ncvc_pdc_ca o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.ca_id = l.id order by i2.dates,i2.line_cd ) t where model_cd = :model_cd group by datesss,model_cd order by datesss");

            
            sqlParameter.AddParameterDateTime("datefrom", DateTime.Parse(inVo.DateFrom));
            sqlParameter.AddParameterDateTime("dateto", DateTime.Parse(inVo.DateTo));
            sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerNCVCVo outVo = new ProductionControllerNCVCVo
                {
                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["datesss"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),

                    CA_app_metal_dirty = int.Parse(dataReader["ca_app_metal_dirty"].ToString()),
                     CA_app_tape_hole_deform = int.Parse(dataReader["ca_app_tape_hole_deform"].ToString()),
                    CA_app_metal_high = int.Parse(dataReader["ca_app_metal_high"].ToString()),
                    CA_app_case_deform_scracth = int.Parse(dataReader["ca_app_case_deform_scracth"].ToString()),
                    CA_app_metal_deform_scratch = int.Parse(dataReader["ca_app_metal_deform_scratch"].ToString()),
                    CA_app_magnet_broken = int.Parse(dataReader["ca_app_magnet_broken"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
