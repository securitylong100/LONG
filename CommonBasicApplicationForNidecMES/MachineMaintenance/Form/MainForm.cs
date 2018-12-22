using Com.Nidec.Mes.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Framework.Login;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    //public partial class MainForm : Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.FormCommonNCVP
    public partial class MainForm : GlobalMasterMaintenance.FormCommonNCVP
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Main form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SystemMaster_gpb.Visible = false;
            NcvpMaster_gpb.Visible = false;
            NCVP_Function_gr.Visible = false;
            NCVC_Function_gr.Visible = false;

            //if (UserData.GetUserData().UserCode == "admin")
            //{
            //    SystemMaster_btn.Enabled = false;
            //}
        }
        /// <summary>
        /// System Master Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemMaster_btn_Click(object sender, EventArgs e)
        {
            SystemMaster_gpb.Visible = true;
            NcvpMaster_gpb.Visible = false;
            NCVP_Function_gr.Visible = false;
            NCVC_Function_gr.Visible = false;
        }
        /// <summary>
        /// Local Master Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NcvpMaster_btn_Click(object sender, EventArgs e)
        {
            NcvpMaster_gpb.Visible = true;
            SystemMaster_gpb.Visible = false;
            NCVP_Function_gr.Visible = false;
            NCVC_Function_gr.Visible = false;
        }
        /// <summary>
        /// NCVP Function Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncvp_btn_Click(object sender, EventArgs e)
        {
            NCVP_Function_gr.Visible = true;
            SystemMaster_gpb.Visible = false;
            NcvpMaster_gpb.Visible = false;
            NCVC_Function_gr.Visible = false;
        }
        /// <summary>
        /// NCVC Function Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncvc_btn_Click(object sender, EventArgs e)
        {
            NCVC_Function_gr.Visible = true;
            NCVP_Function_gr.Visible = false;
            SystemMaster_gpb.Visible = false;
            NcvpMaster_gpb.Visible = false;
        }
        /// <summary>
        /// DownTime button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownTime_bt_Click(object sender, EventArgs e)
        {
            ReportDownTimeForm reportdowntimeform = new ReportDownTimeForm();
            reportdowntimeform.ShowDialog();
        }
        /// <summary>
        /// Jig Repair Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jig_repair_btn_Click(object sender, EventArgs e)
        {
            JigRepairInformationForm reportdowntimeform = new JigRepairInformationForm();
            reportdowntimeform.ShowDialog();
        }
        /// <summary>
        /// Register Drawing Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRegist_btn_Click(object sender, EventArgs e)
        {
            DrawForm drawform = new DrawForm();
            drawform.Show();
        }
        /// <summary>
        /// Document Management Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Doc_Main_btn_Click(object sender, EventArgs e)
        {
            DocumentForm docfrm = new DocumentForm();
            docfrm.ShowDialog();
        }
        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePass_btn_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpform = new ChangePasswordForm();
            cpform.ShowDialog();
        }
        #region System Master
        private void user_bt_Click(object sender, EventArgs e)
        {
            UserMasterForm usermasterform = new UserMasterForm();
            usermasterform.ShowDialog();
        }

        private void local_user_btn_Click(object sender, EventArgs e)
        {
            LocalUserMasterForm localuser = new LocalUserMasterForm();
            localuser.ShowDialog();
        }

        private void language_bt_Click(object sender, EventArgs e)
        {
            CountryLanguageForm conlang = new CountryLanguageForm();
            conlang.ShowDialog();
        }

        private void factory_bt_Click(object sender, EventArgs e)
        {
            FactoryMasterForm factory = new FactoryMasterForm();
            factory.ShowDialog();
        }

        private void userfac_bt_Click(object sender, EventArgs e)
        {
            UserFactoryForm userfact = new UserFactoryForm();
            userfact.ShowDialog();
        }

        private void auth_cotrol_bt_Click(object sender, EventArgs e)
        {
            AuthorityControlForm authorityctr = new AuthorityControlForm();
            authorityctr.ShowDialog();
        }

        private void Role_btn_Click(object sender, EventArgs e)
        {
            RoleForm roleform = new RoleForm();
            roleform.ShowDialog();
        }

        private void UserRoles_btn_Click(object sender, EventArgs e)
        {

            UserRoleForm userrole = new UserRoleForm();
            userrole.ShowDialog();
        }

        private void RoleAuthorityControl_btn_Click(object sender, EventArgs e)
        {
            RoleAuthorityControlForm roleauthor = new RoleAuthorityControlForm();
            roleauthor.ShowDialog();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region NCVP Master
        private void Equipment_btn_Click(object sender, EventArgs e)
        {
            EquipmentForm equipmasterform = new EquipmentForm();
            equipmasterform.ShowDialog();
        }

        private void Process_btn_Click(object sender, EventArgs e)
        {
            ProcessForm processmasterform = new ProcessForm();
            processmasterform.ShowDialog();
        }

        private void Model_btn_Click(object sender, EventArgs e)
        {
            ItemForm modelmasterform = new ItemForm();
            modelmasterform.ShowDialog();
        }

        private void DefectiveReason_btn_Click(object sender, EventArgs e)
        {
            DefectiveReasonForm defectmasterform = new DefectiveReasonForm();
            defectmasterform.ShowDialog();
        }

        private void ProductionWorkContent_btn_Click(object sender, EventArgs e)
        {
            ProdutionWorkContentForm prodworkcontmasterform = new ProdutionWorkContentForm();
            prodworkcontmasterform.ShowDialog();
        }

        private void Line_btn_Click(object sender, EventArgs e)
        {
            LineMasterForm linemasterform = new LineMasterForm();
            linemasterform.ShowDialog();
        }
        
        private void Machine_btn_Click(object sender, EventArgs e)
        {
            MachineForm machinemasterform = new MachineForm();
            machinemasterform.ShowDialog();
        }
        
        private void modellinemaster_btn_Click(object sender, EventArgs e)
        {
            ModelLineMasterForm modelline = new ModelLineMasterForm();
            modelline.ShowDialog();
        }

        private void response_machine_btn_Click(object sender, EventArgs e)
        {
            ResponseMachineMasterForm respmachine = new ResponseMachineMasterForm();
            respmachine.ShowDialog();
        }

        private void JigCause_btn_Click(object sender, EventArgs e)
        {
            JigCauseMasterForm jigcause = new JigCauseMasterForm();
            jigcause.ShowDialog();
        }

        private void JigResponse_btn_Click(object sender, EventArgs e)
        {
            JigResponseMasterForm jigrespform = new JigResponseMasterForm();
            jigrespform.ShowDialog();
        }

        private void CauseMaster_btn_Click(object sender, EventArgs e)
        {
            DefectiveCategoryForm dcform = new DefectiveCategoryForm();
            dcform.ShowDialog();
        }

        private void ProductionWorkContType_btn_Click(object sender, EventArgs e)
        {
            ProdutionWorkContentTypeForm prodworkconttypeform = new ProdutionWorkContentTypeForm();
            prodworkconttypeform.ShowDialog();
        }

        private void ProcessModel_btn_Click(object sender, EventArgs e)
        {
            ModelProcessMasterForm modelprocess = new ModelProcessMasterForm();
            modelprocess.ShowDialog();
        }

        private void Draw_btn_Click(object sender, EventArgs e)
        {
            DrawMasterForm draw = new DrawMasterForm();
            draw.Show();
        }

        private void Supplier_btn_Click(object sender, EventArgs e)
        {
            LocalSupplierForm supplierform = new LocalSupplierForm();
            supplierform.ShowDialog();
        }

        private void equipment_machine_btn_Click(object sender, EventArgs e)
        {
            MachineAndEquipmentMaster mceqform = new MachineAndEquipmentMaster();
            mceqform.ShowDialog();
        }

        private void Location_btn_Click(object sender, EventArgs e)
        {
            LocationForm locaform = new LocationForm();
            locaform.ShowDialog();
        }

        private void Building_btn_Click(object sender, EventArgs e)
        {
            BuildingForm buildform = new BuildingForm();
            buildform.ShowDialog();
        }

        #endregion
    }
}
