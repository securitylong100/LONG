using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Diagnostics;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class DocumentForm : FormCommonNCVP
    {
        DataGridViewButtonColumn Open;
        public DocumentForm()
        {
            InitializeComponent();
            document_dgv.AutoGenerateColumns = false;
        }

        private static GetModelCbm getModelCbm = new GetModelCbm();

        private static GetDepartCbm getDeptCbm = new GetDepartCbm();

        private static GetDocumentModelCbm dmoCbm = new GetDocumentModelCbm();

        private static GetGroupCbm grCbm = new GetGroupCbm();

        private static GetDocumentCodeCbm dcdCbm = new GetDocumentCodeCbm();

        private static GetDocumentNameCbm dnmCbm = new GetDocumentNameCbm();

        private static GetDocumentNameOnlyCbm dnmoCbm = new GetDocumentNameOnlyCbm();

        private static GetNameDeptCbm getndcbm = new GetNameDeptCbm();

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<ModelVo> modelvolist = null;
            try
            {
                modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(getModelCbm, new ModelVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            model_cmb.DataSource = b1;
            model_cmb.Text = "";

            ValueObjectList<DocumentVo> dpmlist = null;
            try
            {
                dpmlist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(getDeptCbm, new DocumentVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            depart_cmb.DisplayMember = "Department";
            BindingSource d1 = new BindingSource(dpmlist.GetList(), null);
            depart_cmb.DataSource = d1;
            depart_cmb.Text = "";

            ValueObjectList<DocumentVo> dpimlist = null;
            try
            {
                dpimlist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(dnmCbm, new DocumentVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            doc_name_cmb.DisplayMember = "DocumentName";
            BindingSource d4 = new BindingSource(dpimlist.GetList(), null);
            doc_name_cmb.DataSource = d4;
            doc_name_cmb.Text = "";

            addButtonTodgv(document_dgv);
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model_cmb.SelectedItem != null)
            {
                ModelVo mdvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<DocumentVo> dovolist = null;
                try
                {
                    dovolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(dmoCbm, new DocumentVo { ModelID = mdvo.ModelId });
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                doc_type_cmb.DisplayMember = "DocumentType";
                doc_type_cmb.DataSource = dovolist.GetList();
                doc_type_cmb.Text = "";


                try
                {
                    dovolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(dnmoCbm, new DocumentVo { ModelID = mdvo.ModelId });
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                doc_name_cmb.DisplayMember = "DocumentName";
                doc_name_cmb.DataSource = dovolist.GetList();
                doc_name_cmb.Text = "";


                try
                {
                    dovolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(dcdCbm, new DocumentVo { ModelID = mdvo.ModelId, DocumentType = doc_type_cmb.Text });
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                version_cmb.DisplayMember = "DocumentCode";
                version_cmb.DataSource = dovolist.GetList();
                version_cmb.Text = "";
            }
        }

        private void depart_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (depart_cmb.SelectedItem != null)
            {
                ModelVo mdvo = (ModelVo)model_cmb.SelectedItem;
                DocumentVo dcvo = (DocumentVo)depart_cmb.SelectedItem;
                ValueObjectList<DocumentVo> dvolist = null;
                try
                {
                    dvolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(grCbm, new DocumentVo { Department = depart_cmb.Text });
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                group_cmb.DisplayMember = "Group";
                group_cmb.DataSource = dvolist.GetList();
                group_cmb.Text = "";


                ValueObjectList<DocumentVo> dlist = null;
                try
                {
                    dlist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(getndcbm, new DocumentVo { ModelID = mdvo.ModelId, Department = depart_cmb.Text });
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                doc_name_cmb.DisplayMember = "DocumentName";
                doc_name_cmb.DataSource = dlist.GetList();
                doc_name_cmb.Text = "";

                try
                {
                    dvolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(dmoCbm, new DocumentVo { ModelID = mdvo.ModelId, Department = depart_cmb.Text });
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                doc_type_cmb.DisplayMember = "DocumentType";
                doc_type_cmb.DataSource = dvolist.GetList();
                doc_type_cmb.Text = "";
            }
        }

        private void group_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelVo mdvo = (ModelVo)model_cmb.SelectedItem;
            DocumentVo dcvo = (DocumentVo)group_cmb.SelectedItem;
            ValueObjectList<DocumentVo> dlist = null;
            try
            {
                dlist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(getndcbm, new DocumentVo { ModelID = mdvo.ModelId, Group = group_cmb.Text });
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            doc_name_cmb.DisplayMember = "DocumentName";
            doc_name_cmb.DataSource = dlist.GetList();
            doc_name_cmb.Text = "";

            try
            {
                dlist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(dmoCbm, new DocumentVo { ModelID = mdvo.ModelId, Group = group_cmb.Text });
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            doc_type_cmb.DisplayMember = "DocumentType";
            doc_type_cmb.DataSource = dlist.GetList();
            doc_type_cmb.Text = "";
        }

        private void doc_type_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelVo mdvo = (ModelVo)model_cmb.SelectedItem;
            DocumentVo dcvo = (DocumentVo)doc_type_cmb.SelectedItem;
            ValueObjectList<DocumentVo> dovolist = null;
            try
            {
                dovolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(dcdCbm, new DocumentVo { ModelID = mdvo.ModelId, DocumentType = dcvo.DocumentType });
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            version_cmb.DisplayMember = "DocumentCode";
            version_cmb.DataSource = dovolist.GetList();
            version_cmb.Text = "";
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            Open.Visible = true;
            if (model_cmb.SelectedIndex == -1)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, model_lbl.Text);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);
                return;
            }

            document_dgv.DataSource = null;

            try
            {
                selectdata();
            }
            catch
            { }
        }

        private void selectdata()
        {
            ValueObjectList<DocumentVo> getList = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(new SearchDocumentCbm(), new DocumentVo
            {
                DocumentCode = version_cmb.Text,
                DocumentType = doc_type_cmb.Text,
                ModelCode = model_cmb.Text,
                ModelID = ((ModelVo)this.model_cmb.SelectedItem).ModelId,
                DocumentName = doc_name_cmb.Text,
                Department = depart_cmb.Text,
                Group = group_cmb.Text,
                TimeFrom = timefrom_dtp.Value,
                TimeTo = timeto_dtp.Value
            });
            document_dgv.DataSource = getList.GetList();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (new AddDocumentForm().ShowDialog() == DialogResult.OK)
            {
                add_btn_Click(null, null);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (document_dgv.SelectedCells.Count > 0)
            {
                DocumentVo uvo = (DocumentVo)document_dgv.CurrentRow.DataBoundItem;
                if (new AddDocumentForm { vo = uvo }.ShowDialog() != DialogResult.OK)
                {
                    selectdata();
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            doc_name_cmb.ResetText();
            model_cmb.ResetText();
            doc_name_cmb.ResetText();
            version_cmb.ResetText();
            doc_type_cmb.ResetText();
            depart_cmb.ResetText();
            group_cmb.ResetText();
        }

        public void addButtonTodgv (DataGridView dgv)
        {
            Open = new DataGridViewButtonColumn();
            Open.Text = "Open";
            Open.UseColumnTextForButtonValue = true;
            Open.Width = 45;
            Open.Visible = false;
            dgv.Columns.Add(Open);
        }

        private void depart_cmb_TextUpdate(object sender, EventArgs e)
        {
            if (depart_cmb.Text != null)
            {
                ValueObjectList<DocumentVo> dpmlist = null;
                try
                {
                    dpmlist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(getDeptCbm, new DocumentVo { Department = depart_cmb.Text });
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                depart_cmb.DisplayMember = "Department";
                BindingSource d1 = new BindingSource(dpmlist.GetList(), null);
                depart_cmb.DataSource = d1;

                depart_cmb.SelectedItem = true;
            }
        }

        private void version_cmb_TextChanged(object sender, EventArgs e)
        {
            ModelVo mdvo = (ModelVo)model_cmb.SelectedItem;
            DocumentVo dvo = (DocumentVo)version_cmb.SelectedItem;
            ValueObjectList<DocumentVo> dvolist = null;
            try
            {
                dvolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(getndcbm, new DocumentVo { ModelID = mdvo.ModelId, DocumentCode = version_cmb.Text });
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            doc_name_cmb.DisplayMember = "DocumentName";
            doc_name_cmb.DataSource = dvolist.GetList();
            doc_name_cmb.Text = "";
        }

        private void document_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string parentPath;
            string openPath;
            int curRow = int.Parse(e.RowIndex.ToString());
            string docName = document_dgv[2, curRow].Value.ToString();
            string docCd = document_dgv[1, curRow].Value.ToString();
            string gr = document_dgv[5, curRow].Value.ToString();
            string User = UserData.GetUserData().UserCode;
            if (User == "225" || User == "558" || User == "1927")
            {
                parentPath = @"Z:\(01)KK03\QA\(00)Public\DOCUMENT\01. AREA A\";
            }
            else parentPath = @"Z:\(01)KK03\QA\(00)Public\DOCUMENT\02. AREA B\";

            string[] dcd = docCd.Split('-');

            if (document_dgv.Columns[e.ColumnIndex] == Open)
            {
                Process prc = new Process();
                if (dcd[2] == "SOP")
                {
                    openPath = parentPath + gr + @"\SOP\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
                if (dcd[2] == "STD")
                {
                    openPath = parentPath + gr + @"\Standard\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
                if (dcd[2] == "DTA")
                {
                    openPath = parentPath + gr + @"\Data\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
                if (dcd[2] == "FRM")
                {
                    openPath = parentPath + gr + @"\Form\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
                if (dcd[2] == "DRW")
                {
                    openPath = parentPath + gr + @"\Drawing\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
                if (dcd[2] == "RPT")
                {
                    openPath = parentPath + gr + @"\Report\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
                if (dcd[2] == "INS")
                {
                    openPath = parentPath + gr + @"\Inspect\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
                if (dcd[2] == "TRC")
                {
                    openPath = parentPath + gr + @"\Traceability\";
                    try
                    {
                        prc.StartInfo.FileName = openPath + docName;
                        prc.Start();
                    }
                    catch { }
                }
            }
        }
    }
}
