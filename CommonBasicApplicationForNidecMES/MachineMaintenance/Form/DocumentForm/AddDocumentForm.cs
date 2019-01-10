using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.Diagnostics;
using System.IO;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddDocumentForm : FormCommonNCVP
    {
        public AddDocumentForm()
        {
            InitializeComponent();
        }

        public DocumentVo vo = new DocumentVo();

        private static GetModelCbm getModelCbm = new GetModelCbm();

        private static GetDepartmentCbm getDeptCbm = new GetDepartmentCbm();

        private static GetDocumentModelCbm dmoCbm = new GetDocumentModelCbm();

        private static GetGroupCbm grCbm = new GetGroupCbm();

        private static GetDocumentCodeCbm dcdCbm = new GetDocumentCodeCbm();

        private static GetDocumentNameCbm dnmCbm = new GetDocumentNameCbm();

        private void AddDocumentForm_Load(object sender, EventArgs e)
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

            if (vo.DocumentID > 0)
            {
                model_cmb.Enabled = false;
                group_txt.Enabled = false;
                depart_txt.Enabled = false;
                model_cmb.Text = vo.ModelCode;
                doc_code_txt.Text = vo.DocumentCode;
                group_txt.Text = vo.Group;
                depart_txt.Text = vo.Department;
                doc_name_txt.Text = vo.DocumentName;
                DocType_txt.Text = vo.DocumentType;
            }
        }

        bool checkdata()
        {
            if (model_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, model_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                model_cmb.Focus();
                return false;
            }

            if (group_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, group_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                group_txt.Focus();
                return false;
            }

            if (doc_code_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, doc_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                doc_code_txt.Focus();
                return false;
            }

            if (doc_name_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Doc_name_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                doc_name_txt.Focus();
                return false;
            }

            if (depart_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, depart_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                depart_txt.Focus();
                return false;
            }

            return true;
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            string mcPath = @"Z:\(01)KK03\QA\(00)Public\DOCUMENT\";
            string parentPath;
            string User = UserData.GetUserData().UserCode;
            if (User == "225" || User == "558" || User == "1927")
            {
                parentPath = mcPath + @"01. AREA A\";
            }
            else parentPath = mcPath + @"02. AREA B\";
            string gr = group_txt.Text;
            //string mdl = model_cmb.Text;
            string folder1 = parentPath + gr + @"\SOP\";
            string folder2 = parentPath + gr + @"\Standard\";
            string folder3 = parentPath + gr + @"\Data\";
            string folder4 = parentPath + gr + @"\Form\";
            string folder5 = parentPath + gr + @"\Drawing\";
            string folder6 = parentPath + gr + @"\Report\";
            string folder7 = parentPath + gr + @"\Inspect\";
            string folder8 = parentPath + gr + @"\Traceability\";

            if (!checkdata()) { return; }
            DocumentVo outVo = new DocumentVo();
            DocumentVo inVo = new DocumentVo
            {
                DocumentID = this.vo.DocumentID,
                TimeFrom = this.updatetime_dtp.Value,
                ModelID = ((ModelVo)this.model_cmb.SelectedItem).ModelId,
                DocumentCode = doc_code_txt.Text,
                DocumentName = doc_name_txt.Text,
                DocumentType = DocType_txt.Text,
                Group = group_txt.Text,
                Department = depart_txt.Text,
                Revision = revision_txt.Text,
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };

            try
            {
                if (inVo.DocumentID > 0)
                {
                    outVo = (DocumentVo)DefaultCbmInvoker.Invoke(new UpdateDocumentCbm(), inVo);
                }
                else
                {
                    outVo = (DocumentVo)DefaultCbmInvoker.Invoke(new AddDocumentCbm(), inVo);
                }
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
            if (outVo.AffectedCount > 0)
            {
                this.DialogResult = DialogResult.OK;
            }

            #region Create a new target folder.
            string[] dcd = doc_code_txt.Text.Split('-');
            Process prc = new Process();
            if (dcd[2] == "SOP")
            {
                try
                {
                    if (!Directory.Exists(folder1))
                    {
                        Directory.CreateDirectory(folder1);

                        File.Move(linksave_txt.Text, folder1 + doc_name_txt.Text);

                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder1 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder1;
                        prc.Start();
                    }
                }
                catch (Exception) { e.ToString(); }
            }
            if (dcd[2] == "STD")
            {
                try
                {
                    if (!System.IO.Directory.Exists(folder2))
                    {
                        System.IO.Directory.CreateDirectory(folder2);
                        File.Move(linksave_txt.Text, folder2 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder2 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder2;
                        prc.Start();
                    }
                }
                catch { }
            }

            if (dcd[2] == "DTA")
            {
                try
                {
                    if (!System.IO.Directory.Exists(folder3))
                    {
                        System.IO.Directory.CreateDirectory(folder3);
                        File.Move(linksave_txt.Text, folder3 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder3 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder3;
                        prc.Start();
                    }
                }
                catch { }
                
            }
            if (dcd[2] == "FRM")
            {
                try
                {
                    if (!System.IO.Directory.Exists(folder4))
                    {
                        System.IO.Directory.CreateDirectory(folder4);
                        File.Move(linksave_txt.Text, folder4 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder4 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder4;
                        prc.Start();
                    }
                }
                catch { }
            }

            if (dcd[2] == "DRW")
            {
                try
                {
                    if (!System.IO.Directory.Exists(folder5))
                    {
                        System.IO.Directory.CreateDirectory(folder5);
                        File.Move(linksave_txt.Text, folder5 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder5 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder5;
                        prc.Start();
                    }
                }
                catch { }
            }

            if (dcd[2] == "RPT")
            {
                try
                {
                    if (!System.IO.Directory.Exists(folder6))
                    {
                        System.IO.Directory.CreateDirectory(folder6);
                        File.Move(linksave_txt.Text, folder6 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder6 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder6;
                        prc.Start();
                    }
                }
                catch { }
            }

            if (dcd[2] == "INS")
            {
                try
                {
                    if (!System.IO.Directory.Exists(folder7))
                    {
                        System.IO.Directory.CreateDirectory(folder7);
                        File.Move(linksave_txt.Text, folder7 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder7 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder7;
                        prc.Start();
                    }
                }
                catch { }
            }

            if (dcd[2] == "TRC")
            {
                try
                {
                    if (!System.IO.Directory.Exists(folder8))
                    {
                        System.IO.Directory.CreateDirectory(folder8);
                        File.Move(linksave_txt.Text, folder8 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, folder8 + doc_name_txt.Text);
                        MessageBox.Show("Document folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DialogResult == DialogResult.OK)
                    {
                        prc.StartInfo.FileName = folder8;
                        prc.Start();
                    }
                }
                catch { }
            }
            #endregion
        }

        private void browser_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog o1 = new OpenFileDialog();
            o1.ShowDialog();
            doc_name_txt.Text = Path.GetFileName(o1.FileName);
            linksave_txt.Text = o1.FileName;
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doc_code_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] a = doc_code_txt.Text.Split('-');
                int b = doc_code_txt.Text.Length;
                DocType_txt.Text = doc_code_txt.Text.Substring(0, b - 3);
                depart_txt.Text = a[0];
                group_txt.Text = a[1];
                doc_name_txt.Focus();
            }
        }

        private void doc_name_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (doc_code_txt.Text.Length > 0)
            {
                string[] a = doc_code_txt.Text.Split('-');
                int b = doc_code_txt.Text.Length;
                DocType_txt.Text = doc_code_txt.Text.Substring(0, b - 3);
                depart_txt.Text = a[0];
                group_txt.Text = a[1];
                doc_name_txt.Focus();
            }
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doc_code_txt.Text.Length > 0)
            {
                string[] a = doc_code_txt.Text.Split('-');
                int b = doc_code_txt.Text.Length;
                DocType_txt.Text = doc_code_txt.Text.Substring(0, b - 3);
                depart_txt.Text = a[0];
                group_txt.Text = a[1];
                doc_name_txt.Focus();
            }
        }
    }
}
