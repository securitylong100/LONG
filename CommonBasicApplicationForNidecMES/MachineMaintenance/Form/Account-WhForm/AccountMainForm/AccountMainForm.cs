using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AccountMainForm : FormCommonNCVP
    {
        public AccountMainForm()
        {
            InitializeComponent();
            account_main_dgv.AutoGenerateColumns = false;
            account_depreciation_dgv.AutoGenerateColumns = false;
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = false;
            account_main_dgv.Visible = true;
            account_main_dgv.DataSource = null;
            GridBind();
            updatedatatodatabase();
        }
        void updatedatatodatabase()
        {
            if (account_main_dgv.RowCount > 0)
            {
                AccountMainVo outVo = new AccountMainVo();
                for (int i = 0; i < account_main_dgv.RowCount; i++)
                {
                    AccountMainVo inVo = new AccountMainVo()
                    {
                        AcountMainId = int.Parse(account_main_dgv.Rows[i].Cells["colAcountMainId"].Value.ToString()),
                        CurrentDepreciation = double.Parse(account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value.ToString()),
                        MonthlyDepreciation = double.Parse(account_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value.ToString()),
                        AccumDepreciation = double.Parse(account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value.ToString()),
                        NetValue = double.Parse(account_main_dgv.Rows[i].Cells["colNetValue"].Value.ToString()),
                    };
                    outVo = (AccountMainVo)DefaultCbmInvoker.Invoke(new Cbm.UpdateAccountMainDGVCbm(), inVo);
                }
            }
        }
        private void GridBind()
        {
            try
            {
                AccountMainVo whvos = new AccountMainVo()
                {
                    AssetCode = asset_Code_txt.Text,
                    RankCode = rank_code_cbm.Text,
                    AssetType = asset_type_cbm.Text,
                    AccountCodeCode = account_code_cmb.Text,
                    AccountLocationCode = section_cd_cmb.Text,
                    AssetInvoice = invoice_cbm.Text,
                    AssetModel = asset_model_cbm.Text,
                    LocationCode = location_cbm.Text,
                    AssetName = asset_name_cbm.Text,
                    //AssetNo = 
                };
                ValueObjectList<AccountMainVo> listvo = (ValueObjectList<AccountMainVo>)DefaultCbmInvoker.Invoke(new Cbm.SeachAccountMainCbm(), whvos);
                account_main_dgv.DataSource = listvo.GetList();
                calculator();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        public void calculator()
        {
            if (account_main_dgv.RowCount > 0)
            {
                for (int i = 0; i < account_main_dgv.RowCount; i++)
                {
                    DateTime Dep_Start = DateTime.Parse(account_main_dgv.Rows[i].Cells["colStartDepreciation"].Value.ToString());
                    DateTime Dep_End = DateTime.Parse(account_main_dgv.Rows[i].Cells["colEndDepreciation"].Value.ToString());
                    int Start_Year = Dep_Start.Year;
                    int Start_month = Dep_Start.Month;
                    int Current_Year = DateTime.Now.Year;
                    int Current_month = DateTime.Now.Month;

                    double mothcounter = ((Current_Year - Start_Year) * 12) + (Current_month - Start_month);
                    double monthlife = double.Parse(account_main_dgv.Rows[i].Cells["colAssetLife"].Value.ToString()) * 12;
                    double Acquisition = double.Parse(account_main_dgv.Rows[i].Cells["colAcquisitionCost"].Value.ToString());
                    double monthly_depr = Acquisition / monthlife;

                    //Monthly
                    account_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value = Math.Round(monthly_depr, 3).ToString();

                    //Curent Depreciation
                    double current_depr = (mothcounter - 1) * monthly_depr;
                    account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = Math.Round(current_depr, 3).ToString();
                    if (current_depr > Acquisition)
                    {
                        account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = Acquisition.ToString();
                    }
                    if (current_depr < 0)
                    {
                        account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = 0.ToString();
                    }
                    //Accum
                    double Accum = (mothcounter * monthly_depr);
                    account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = Math.Round(Accum, 3).ToString();
                    if (Accum > Acquisition)
                    {
                        account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = Acquisition.ToString();
                    }
                    if (Accum < 0)
                    {
                        account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = 0.ToString();
                    }

                    //Net Value
                    double net_value = (Acquisition - Accum);
                    account_main_dgv.Rows[i].Cells["colNetValue"].Value = Math.Round(net_value, 3).ToString();
                    if (net_value > Acquisition)
                    {
                        account_main_dgv.Rows[i].Cells["colNetValue"].Value = Acquisition.ToString();
                    }
                    if (net_value < 0)
                    {
                        account_main_dgv.Rows[i].Cells["colNetValue"].Value = 0.ToString();
                    }
                }
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            AddAcountMainForm addaccountmain = new AddAcountMainForm();
            addaccountmain.ShowDialog();
        }

        private void AccountMainForm_Load(object sender, EventArgs e)
        {
            {
                account_depreciation_dgv.DefaultCellStyle.Font = new Font("Arial", 9);
                account_depreciation_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                account_main_dgv.DefaultCellStyle.Font = new Font("Arial", 9);
                account_main_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            }


            AcceptButton = search_btn;
            ValueObjectList<RankVo> rankcode = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), new RankVo());
            rank_code_cbm.DisplayMember = "RankCode";
            rank_code_cbm.DataSource = rankcode.GetList();
            rank_code_cbm.Text = "";

            ValueObjectList<AssetVo> assetvotype = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetTypeCbm(), new AssetVo());
            asset_type_cbm.DisplayMember = "AssetType";
            asset_type_cbm.DataSource = assetvotype.GetList();
            asset_type_cbm.Text = "";

            // account_code
            ValueObjectList<AccountCodeVo> accountcodevo = (ValueObjectList<AccountCodeVo>)DefaultCbmInvoker.Invoke(new GetAccountCodeCbm(), new AccountCodeVo());
            account_code_cmb.DisplayMember = "AccountCodeCode";
            account_code_cmb.DataSource = accountcodevo.GetList();
            account_code_cmb.Text = "";

            //accountlocationcode
            ValueObjectList<AccountLocationVo> accountlocationcodevo = (ValueObjectList<AccountLocationVo>)DefaultCbmInvoker.Invoke(new GetAccountLocationCbm(), new AccountLocationVo());
            section_cd_cmb.DisplayMember = "AccountLocationCode";
            section_cd_cmb.DataSource = accountlocationcodevo.GetList();
            section_cd_cmb.Text = "";

            ValueObjectList<AssetVo> assetvoinvoice = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetInvoiceCbm(), new AssetVo());
            invoice_cbm.DisplayMember = "AssetInvoice";
            invoice_cbm.DataSource = assetvoinvoice.GetList();
            invoice_cbm.Text = "";

            ValueObjectList<AssetVo> assetvomodel = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetModelCbm(), new AssetVo());
            asset_model_cbm.DisplayMember = "AssetModel";
            asset_model_cbm.DataSource = assetvomodel.GetList();
            asset_model_cbm.Text = "";

            ValueObjectList<AssetVo> assetvoname = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetNameCbm(), new AssetVo());
            asset_name_cbm.DisplayMember = "AssetName";
            asset_name_cbm.DataSource = assetvoname.GetList();
            asset_name_cbm.Text = "";

            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            location_cbm.DisplayMember = "LocationCode";
            location_cbm.DataSource = Locationvo.LocationListVo;
            location_cbm.Text = "";
        }
        public void trimcode()
        {
            if (full_asset_Code_txt.TextLength >= 10)
            {
                //asset_Code_txt.Text = full_asset_Code_txt.Text.Substring(0, 10);
                string str = full_asset_Code_txt.Text;
                string[] arrListStr = str.Split(',');
                asset_Code_txt.Text = arrListStr[0];
                asset_Code_txt.Enabled = false;
            }
            else
            {
                asset_Code_txt.Enabled = true;
                asset_Code_txt.Text = "";
            }
        }

        private void full_asset_Code_txt_TextChanged(object sender, EventArgs e)
        {
            trimcode();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (account_main_dgv.SelectedCells.Count > 0)
            {
                AccountMainVo selectedvo = (AccountMainVo)account_main_dgv.CurrentRow.DataBoundItem;

                if (new AddAcountMainForm { accountmainVo = selectedvo, }.ShowDialog() == DialogResult.OK)
                { GridBind(); }
            }
        }

        private void depreciation_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = true;
            account_main_dgv.Visible = false;
            account_depreciation_dgv.DataSource = null;

            account_depreciation_dgv.Columns[0].HeaderText = "Account Name";

            try
            {
                AccountMainVo whvos = new AccountMainVo()
                {

                };
                ValueObjectList<AccountMainVo> listvo = (ValueObjectList<AccountMainVo>)DefaultCbmInvoker.Invoke(new Cbm.TotalDEPAccountMainCbm(), whvos);
                account_depreciation_dgv.DataSource = listvo.GetList();

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

        }

        private void Rank_Dep_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = true;
            account_main_dgv.Visible = false;
            account_depreciation_dgv.DataSource = null;
            account_depreciation_dgv.Columns[0].HeaderText = "Rank Name";
            try
            {
                AccountMainVo whvos = new AccountMainVo()
                {

                };
                ValueObjectList<AccountMainVo> listvo = (ValueObjectList<AccountMainVo>)DefaultCbmInvoker.Invoke(new Cbm.TotalRankDEPAccountMainCbm(), whvos);
                account_depreciation_dgv.DataSource = listvo.GetList();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

        }

        private void exportexcel_btn_Click(object sender, EventArgs e)
        {
            if (account_depreciation_dgv.Visible == true)
            {
                Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.Excel_Class exportexcel = new Common.Excel_Class();
                exportexcel.exportexcel(ref account_depreciation_dgv, linksave_txt.Text, account_depreciation_dgv.Columns[0].HeaderText);
            }
            else if (account_main_dgv.Visible == true)
            {
                Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.Excel_Class exportexcel = new Common.Excel_Class();
                exportexcel.exportexcel(ref account_main_dgv, linksave_txt.Text, account_main_dgv.Columns[0].HeaderText);

            }
        }
        private string directorySave = "";
        private void browser_btn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "d:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                linksave_txt.Text = fl.SelectedPath;
                directorySave = linksave_txt.Text;
            }
        }
    }
}
