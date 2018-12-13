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
    public class SearchProDetailAllLineAllProcessNCVCDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerVo inVo = (ProductionControllerVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerVo> voList = new ValueObjectList<ProductionControllerVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append("select tbloutput.datesss dates,'LA459' model_cd,'All Line' line_cd,* from ");
            sql.Append("(select Case When t.timesfc between '06:00:00' and '23:59:00' then t.datefc when ");
            sql.Append("t.timesfc between '00:00:00' and '05:59:00' then t.datefc-1 end datesss, ");

            sql.Append("sum(fc_endplay_small) fc_endplay_small , sum(fc_endplay_big) fc_endplay_big, ");
            sql.Append("sum(fc_shaft_scracth) fc_shaft_scracth, sum(fc_terminal_low) fc_terminal_low, ");
            sql.Append("sum(fc_case_scracth_dirty) fc_case_scracth_dirty ,  sum(fc_pinion_worm_ng) fc_pinion_worm_ng,  ");
            sql.Append("sum(fc_shaft_lock) fc_shaft_lock, sum(fc_ba_deform) fc_ba_deform, ");
            sql.Append("sum(fc_tape_hole_deform) fc_tape_hole_deform, sum(fc_brush_rust) fc_brush_rust, ");
            sql.Append("sum(fc_metal_deform_scracth) fc_metal_deform_scracth, sum(fc_washer_tape_hole ) fc_washer_tape_hole, ");
            
            sql.Append("sum(en2_insulation_resistance_ng) en2_insulation_resistance_ng, ");
            sql.Append("sum(en2_cut_coil_wire) en2_cut_coil_wire ,");
            sql.Append("sum(en2_no_load_current_hight) en2_no_load_current_hight, ");
            sql.Append("sum(en2_ripple) en2_ripple, ");
            sql.Append("sum(en2_chattering) en2_chattering, ");
            sql.Append("sum(en2_lock) en2_lock, ");
            sql.Append("sum(en2_open) en2_open, ");
            sql.Append("sum(en2_no_load_speed_low) en2_no_load_speed_low, ");
            sql.Append("sum(en2_starting_voltage) en2_starting_voltage, ");
            sql.Append("sum(en2_no_load_speed_high) en2_no_load_speed_high, ");
            sql.Append("sum(en2_rotor_mix) en2_rotor_mix, ");
            sql.Append("sum(en2_surge_volt_max) en2_surge_volt_max, ");
            sql.Append("sum(en2_wrong_post_of_pole) en2_wrong_post_of_pole, ");
            sql.Append("sum(en2_err) en2_err, ");
            sql.Append("sum(en2_noise) en2_noise, ");

            sql.Append("sum(fd_ng_beat_point) fd_ng_beat_point , sum(fd_fundou_deform) fd_fundou_deform , ");
            sql.Append("sum(en1_lock) en1_lock, sum(en1_cut) en1_cut, sum(en1_chattering) en1_chattering, ");
            sql.Append("sum(en1_insulation) en1_insulation, sum(en1_open) en1_open, ");
            sql.Append("sum(en1_bad_wave) en1_bad_wave, sum(en1_duty) en1_duty, ");
            sql.Append("sum(en1_short) en1_short, sum(en1_beat_case_ng ) en1_beat_case_ng, ");
            sql.Append("sum(en1_beat_fundou_ng) en1_beat_fundou_ng, ");

            sql.Append("sum(insc_no_ink_case_mc1) insc_no_ink_case_mc1, sum(insc_ba_deform_mc1) insc_ba_deform_mc1, ");
            sql.Append("sum(insc_break_case_mc1) insc_break_case_mc1 ,");
            sql.Append("sum(insc_drop_mc1) insc_drop_mc1 ,  sum(insc_break_wire_mc1) insc_break_wire_mc1, ");
            sql.Append("sum(insc_break_ring_mc1) insc_break_ring_mc1, ");

            sql.Append("sum(ra_com_pb_sticky) ra_com_pb_sticky,");
            sql.Append("sum(ra_wire_pb_sticky) ra_wire_pb_sticky, sum(ra_com_slip) ra_com_slip, ");
            sql.Append("sum(ra_renew_ring) ra_renew_ring, sum(ra_break_wire_final_app ) ra_break_wire_final_app, ");
            sql.Append("sum(ra_wire_combine_wrong) ra_wire_combine_wrong, ");
            sql.Append("sum(ra_core_ng) ra_core_ng, ");
            sql.Append("sum(ra_segment_hole) ra_segment_hole, sum(ra_glue_sticky) ra_glue_sticky, ");
            sql.Append("sum(ra_loose_wire_final_app) ra_loose_wire_final_app, sum(ra_lead_not_covered ) ra_lead_not_covered,");
            sql.Append("sum(ra_less_lead) ra_less_lead ");
            sql.Append("from ");

            sql.Append("(select fc.dates datefc,fc.times timesfc,* from t_ncvp_pdc_fc fc left join ");
            sql.Append("t_ncvp_pdc_en2 e2 on fc.fc_id = e2.en2_id ");
            sql.Append("left join t_ncvp_pdc_en1 e1 on fc.fc_id = e1.en1_id ");
            sql.Append("left join t_ncvp_pdc_ca ca on fc.fc_id = ca.ca_id ");
            sql.Append("left join t_ncvp_pdc_ba ba on fc.fc_id = ba.ba_id ");
            sql.Append("left join ");

            sql.Append("(select dates date1, line_cd line1, Case when idca3 is null then idca1 else ");
            sql.Append("idca3 end id  from (select tblca1.dates,tblca1.line_cd, idca1, idca3  from ");
            sql.Append("(select line_cd,o.dates , max(o.ca_id) idca1  from ");
            sql.Append("t_ncvp_pdc_ca o where o.times > '06:00:00' ");
            sql.Append("and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto ");
            sql.Append("group by o.dates, line_cd order by dates) tblca1 ");
            sql.Append("left join ");

            sql.Append("(select line_cd,(o.dates-1) dates , max(o.ca_id) idca3 from t_ncvp_pdc_ca o ");
            sql.Append("where o.times > '00:00:00' and o.times <= '05:30:00' ");
            sql.Append("and o.dates > :datefrom and o.dates - 1 <= :dateto ");
            sql.Append("group by line_cd,o.dates order by idca3) tblca3 ");
            sql.Append("on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl ");
            sql.Append("order by dates,line_cd) l on l.line1 = fc.line_cd ");
            sql.Append("where fc.fc_id = l.id and l.line1 = e2.line_cd and l.line1 = e1.line_cd ");
            sql.Append("and l.line1 = ca.line_cd order by fc.dates, fc.line_cd) ");
            sql.Append("t group by datesss order by datesss ) tbloutput ");

            

            sqlParameter.AddParameterDateTime("datefrom", DateTime.Parse(inVo.DateFrom));
            sqlParameter.AddParameterDateTime("dateto", DateTime.Parse(inVo.DateTo));
            //sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerVo outVo = new ProductionControllerVo
                {
                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["dates"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),

                    HolGapHolder = int.Parse(dataReader["hol_gap_holder"].ToString()),

                    App_stamping_ba = int.Parse(dataReader["fiapp_stamping_ba"].ToString()),
                    App_case_set = int.Parse(dataReader["fiapp_case_set"].ToString()),
                    App_tough_shaft = int.Parse(dataReader["fiapp_tough_shaft"].ToString()),
                    App_case_glue_sticky = int.Parse(dataReader["fiapp_case_glue_sticky"].ToString()),
                    App_up_low_shabby = int.Parse(dataReader["fiapp_up_low_shabby"].ToString()),
                    App_hole_shaft = int.Parse(dataReader["fiapp_hole_shaft"].ToString()),
                    App_no_beat_prone_case = int.Parse(dataReader["fiapp_no_beat_prone_case"].ToString()),
                    App_hole_case = int.Parse(dataReader["fiapp_hole_case"].ToString()),
                    App_prone_case = int.Parse(dataReader["fiapp_prone_case"].ToString()),
                    App_lot_ng = int.Parse(dataReader["fiapp_lot_ng"].ToString()),
                    App_ter_deform = int.Parse(dataReader["fiapp_ter_deform"].ToString()),
                    App_hole_ter = int.Parse(dataReader["fiapp_hole_ter"].ToString()),
                    App_soder_hl = int.Parse(dataReader["fiapp_soder_hl"].ToString()),
                    App_metal_oven_low = int.Parse(dataReader["fiapp_metal_oven_low"].ToString()),
                    App_fundou_ng = int.Parse(dataReader["fiapp_fundou_ng"].ToString()),
                    App_ter_glue_sticky = int.Parse(dataReader["fiapp_ter_glue_sticky"].ToString()),
                    App_lead_glue_sticky = int.Parse(dataReader["fiapp_lead_glue_sticky"].ToString()),

                    Co_beat_core_ng = int.Parse(dataReader["co_beat_core_ng"].ToString()),
                    Co_com_wrap = int.Parse(dataReader["co_com_wrap"].ToString()),
                    Co_core_ng = int.Parse(dataReader["co_core_ng"].ToString()),
                    Co_com_glue_sticky = int.Parse(dataReader["co_com_glue_sticky"].ToString()),

                    En1_lock = int.Parse(dataReader["en1_lock"].ToString()),
                    En1_cut = int.Parse(dataReader["en1_cut"].ToString()),
                    En1_chattering = int.Parse(dataReader["en1_chattering"].ToString()),
                    En1_insulation = int.Parse(dataReader["en1_insulation"].ToString()),
                    En1_open = int.Parse(dataReader["en1_open"].ToString()),
                    En1_bad_wave = int.Parse(dataReader["en1_bad_wave"].ToString()),
                    En1_duty = int.Parse(dataReader["en1_duty"].ToString()),
                    En1_short = int.Parse(dataReader["en1_short"].ToString()),
                    En1_beat_case_ng = int.Parse(dataReader["en1_beat_case_ng"].ToString()),
                    En1_beat_fundou_ng = int.Parse(dataReader["en1_beat_fundou_ng"].ToString()),

                    En2_lock = int.Parse(dataReader["en2_lock"].ToString()),
                    En2_cut = int.Parse(dataReader["en2_cut"].ToString()),
                    En2_chattering = int.Parse(dataReader["en2_chattering"].ToString()),
                    En2_insulation = int.Parse(dataReader["en2_insulation"].ToString()),
                    En2_open = int.Parse(dataReader["en2_open"].ToString()),
                    En2_short = int.Parse(dataReader["en2_short"].ToString()),
                    En2_duty = int.Parse(dataReader["en2_duty"].ToString()),
                    En2_no = int.Parse(dataReader["en2_no"].ToString()),
                    En2_var = int.Parse(dataReader["en2_var"].ToString()),
                    En2_reverse_spinning = int.Parse(dataReader["en2_reverse_spinning"].ToString()),
                    En2_starting_volt = int.Parse(dataReader["en2_starting_volt"].ToString()),
                    En2_io = int.Parse(dataReader["en2_io"].ToString()),

                    Fd_ng_beat_point = int.Parse(dataReader["fd_ng_beat_point"].ToString()),
                    Fd_fundou_deform = int.Parse(dataReader["fd_fundou_deform"].ToString()),

                    Insc_no_ink_case_mc1 = int.Parse(dataReader["insc_no_ink_case_mc1"].ToString()),
                    Insc_ba_deform_mc1 = int.Parse(dataReader["insc_ba_deform_mc1"].ToString()),
                    Insc_break_case_mc1 = int.Parse(dataReader["insc_break_case_mc1"].ToString()),
                    Insc_drop_mc1 = int.Parse(dataReader["insc_drop_mc1"].ToString()),
                    Insc_break_wire_mc1 = int.Parse(dataReader["insc_break_wire_mc1"].ToString()),
                    Insc_break_ring_mc1 = int.Parse(dataReader["insc_break_ring_mc1"].ToString()),


                    RA_com_pb_sticky = int.Parse(dataReader["ra_com_pb_sticky"].ToString()),
                    RA_wire_pb_sticky = int.Parse(dataReader["ra_wire_pb_sticky"].ToString()),
                    RA_com_slip = int.Parse(dataReader["ra_com_slip"].ToString()),
                    RA_renew_ring = int.Parse(dataReader["ra_renew_ring"].ToString()),
                    RA_break_wire_final_app = int.Parse(dataReader["ra_break_wire_final_app"].ToString()),
                    RA_wire_combine_wrong = int.Parse(dataReader["ra_wire_combine_wrong"].ToString()),
                    RA_core_ng = int.Parse(dataReader["ra_core_ng"].ToString()),
                    RA_segment_hole = int.Parse(dataReader["ra_segment_hole"].ToString()),
                    RA_glue_sticky = int.Parse(dataReader["ra_glue_sticky"].ToString()),
                    RA_loose_wire_final_app = int.Parse(dataReader["ra_loose_wire_final_app"].ToString()),
                    RA_lead_not_covered = int.Parse(dataReader["ra_lead_not_covered"].ToString()),
                    RA_less_lead = int.Parse(dataReader["ra_less_lead"].ToString()),

                    Rigs_wire_pb_sticky = int.Parse(dataReader["rigs_wire_pb_sticky"].ToString()),
                    Rigs_com_pb_sticky = int.Parse(dataReader["rigs_com_pb_sticky"].ToString()),
                    Rigs_ring_prone = int.Parse(dataReader["rigs_ring_prone"].ToString()),
                    Rigs_cracked_ring = int.Parse(dataReader["rigs_cracked_ring"].ToString()),

                    Pbs_break_copper = int.Parse(dataReader["pbs_break_copper"].ToString()),
                    Pbs_climb_core = int.Parse(dataReader["pbs_climb_core"].ToString()),
                    Pbs_skip_edge = int.Parse(dataReader["pbs_skip_edge"].ToString()),
                    Pbs_wire_combine_wrong = int.Parse(dataReader["pbs_wire_combine_wrong"].ToString()),
                    Pbs_loose_wire = int.Parse(dataReader["pbs_loose_wire"].ToString()),
                    Pbs_rizer_edge_ng = int.Parse(dataReader["pbs_rizer_edge_ng"].ToString()),
                    Pbs_core_ng = int.Parse(dataReader["pbs_core_ng"].ToString()),
                    Pbs_com_slip = int.Parse(dataReader["pbs_com_slip"].ToString()),
                    Pbs_hole = int.Parse(dataReader["pbs_hole"].ToString()),
                    Pbs_2_sleeve = int.Parse(dataReader["pbs_2_sleeve"].ToString()),
                    Pbs_wire_pb_sticky = int.Parse(dataReader["pbs_wire_pb_sticky"].ToString()),
                    Pbs_com_pb_sticky = int.Parse(dataReader["pbs_com_pb_sticky"].ToString()),
                    Pbs_no_lead = int.Parse(dataReader["pbs_no_lead"].ToString()),

                    We_com_slip = int.Parse(dataReader["we_com_slip"].ToString()),
                    We_long_shaft = int.Parse(dataReader["we_long_shaft"].ToString()),
                    We_short_shaft = int.Parse(dataReader["we_short_shaft"].ToString()),

                    Wi_break_copper_mc = int.Parse(dataReader["wi_break_copper_mc"].ToString()),
                    Wi_ruffle_copper_mc = int.Parse(dataReader["wi_ruffle_copper_mc"].ToString()),
                    Wi_edge_ng_mc = int.Parse(dataReader["wi_edge_ng_mc"].ToString()),
                    Wi_no_sleeve_mc = int.Parse(dataReader["wi_no_sleeve_mc"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
