namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class AddDocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDocumentForm));
            this.doc_code_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.doc_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Cancel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.OK_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.group_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.revision_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.revision_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DocType_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DocType_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.depart_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.depart_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Doc_name_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.doc_name_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.group_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.updatetime_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.updatetime_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.browser_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.linksave_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.SuspendLayout();
            // 
            // doc_code_txt
            // 
            this.doc_code_txt.ControlId = null;
            resources.ApplyResources(this.doc_code_txt, "doc_code_txt");
            this.doc_code_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.doc_code_txt.Name = "doc_code_txt";
            this.doc_code_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.doc_code_txt_KeyDown);
            // 
            // doc_code_lbl
            // 
            resources.ApplyResources(this.doc_code_lbl, "doc_code_lbl");
            this.doc_code_lbl.ControlId = null;
            this.doc_code_lbl.Name = "doc_code_lbl";
            // 
            // model_cmb
            // 
            this.model_cmb.ControlId = null;
            resources.ApplyResources(this.model_cmb, "model_cmb");
            this.model_cmb.FormattingEnabled = true;
            this.model_cmb.Name = "model_cmb";
            this.model_cmb.SelectedIndexChanged += new System.EventHandler(this.model_cmb_SelectedIndexChanged);
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Cancel_btn.ControlId = null;
            resources.ApplyResources(this.Cancel_btn, "Cancel_btn");
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.UseVisualStyleBackColor = false;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.BackColor = System.Drawing.SystemColors.Control;
            this.OK_btn.ControlId = null;
            resources.ApplyResources(this.OK_btn, "OK_btn");
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // group_lbl
            // 
            resources.ApplyResources(this.group_lbl, "group_lbl");
            this.group_lbl.ControlId = null;
            this.group_lbl.Name = "group_lbl";
            // 
            // revision_lbl
            // 
            resources.ApplyResources(this.revision_lbl, "revision_lbl");
            this.revision_lbl.ControlId = null;
            this.revision_lbl.Name = "revision_lbl";
            // 
            // revision_txt
            // 
            this.revision_txt.ControlId = null;
            resources.ApplyResources(this.revision_txt, "revision_txt");
            this.revision_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.revision_txt.Name = "revision_txt";
            // 
            // DocType_lbl
            // 
            resources.ApplyResources(this.DocType_lbl, "DocType_lbl");
            this.DocType_lbl.ControlId = null;
            this.DocType_lbl.Name = "DocType_lbl";
            // 
            // DocType_txt
            // 
            this.DocType_txt.ControlId = null;
            resources.ApplyResources(this.DocType_txt, "DocType_txt");
            this.DocType_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DocType_txt.Name = "DocType_txt";
            // 
            // depart_lbl
            // 
            resources.ApplyResources(this.depart_lbl, "depart_lbl");
            this.depart_lbl.ControlId = null;
            this.depart_lbl.Name = "depart_lbl";
            // 
            // depart_txt
            // 
            this.depart_txt.ControlId = null;
            resources.ApplyResources(this.depart_txt, "depart_txt");
            this.depart_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.depart_txt.Name = "depart_txt";
            // 
            // Doc_name_lbl
            // 
            resources.ApplyResources(this.Doc_name_lbl, "Doc_name_lbl");
            this.Doc_name_lbl.ControlId = null;
            this.Doc_name_lbl.Name = "Doc_name_lbl";
            // 
            // doc_name_txt
            // 
            this.doc_name_txt.ControlId = null;
            resources.ApplyResources(this.doc_name_txt, "doc_name_txt");
            this.doc_name_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.doc_name_txt.Name = "doc_name_txt";
            this.doc_name_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.doc_name_txt_MouseClick);
            // 
            // group_txt
            // 
            this.group_txt.ControlId = null;
            resources.ApplyResources(this.group_txt, "group_txt");
            this.group_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.group_txt.Name = "group_txt";
            // 
            // updatetime_dtp
            // 
            this.updatetime_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.updatetime_dtp.ControlId = null;
            resources.ApplyResources(this.updatetime_dtp, "updatetime_dtp");
            this.updatetime_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.updatetime_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.updatetime_dtp.Name = "updatetime_dtp";
            // 
            // updatetime_lbl
            // 
            resources.ApplyResources(this.updatetime_lbl, "updatetime_lbl");
            this.updatetime_lbl.ControlId = null;
            this.updatetime_lbl.Name = "updatetime_lbl";
            // 
            // browser_btn
            // 
            this.browser_btn.BackColor = System.Drawing.SystemColors.Control;
            this.browser_btn.ControlId = null;
            resources.ApplyResources(this.browser_btn, "browser_btn");
            this.browser_btn.Name = "browser_btn";
            this.browser_btn.UseVisualStyleBackColor = false;
            this.browser_btn.Click += new System.EventHandler(this.browser_btn_Click);
            // 
            // linksave_txt
            // 
            this.linksave_txt.ControlId = null;
            resources.ApplyResources(this.linksave_txt, "linksave_txt");
            this.linksave_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.linksave_txt.Name = "linksave_txt";
            // 
            // AddDocumentForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.browser_btn);
            this.Controls.Add(this.linksave_txt);
            this.Controls.Add(this.updatetime_dtp);
            this.Controls.Add(this.updatetime_lbl);
            this.Controls.Add(this.depart_lbl);
            this.Controls.Add(this.revision_txt);
            this.Controls.Add(this.group_lbl);
            this.Controls.Add(this.revision_lbl);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.group_txt);
            this.Controls.Add(this.depart_txt);
            this.Controls.Add(this.DocType_txt);
            this.Controls.Add(this.DocType_lbl);
            this.Controls.Add(this.doc_name_txt);
            this.Controls.Add(this.doc_code_txt);
            this.Controls.Add(this.Doc_name_lbl);
            this.Controls.Add(this.doc_code_lbl);
            this.Controls.Add(this.model_cmb);
            this.Controls.Add(this.model_lbl);
            this.Name = "AddDocumentForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddDocumentForm_Load);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.model_cmb, 0);
            this.Controls.SetChildIndex(this.doc_code_lbl, 0);
            this.Controls.SetChildIndex(this.Doc_name_lbl, 0);
            this.Controls.SetChildIndex(this.doc_code_txt, 0);
            this.Controls.SetChildIndex(this.doc_name_txt, 0);
            this.Controls.SetChildIndex(this.DocType_lbl, 0);
            this.Controls.SetChildIndex(this.DocType_txt, 0);
            this.Controls.SetChildIndex(this.depart_txt, 0);
            this.Controls.SetChildIndex(this.group_txt, 0);
            this.Controls.SetChildIndex(this.OK_btn, 0);
            this.Controls.SetChildIndex(this.Cancel_btn, 0);
            this.Controls.SetChildIndex(this.revision_lbl, 0);
            this.Controls.SetChildIndex(this.group_lbl, 0);
            this.Controls.SetChildIndex(this.revision_txt, 0);
            this.Controls.SetChildIndex(this.depart_lbl, 0);
            this.Controls.SetChildIndex(this.updatetime_lbl, 0);
            this.Controls.SetChildIndex(this.updatetime_dtp, 0);
            this.Controls.SetChildIndex(this.linksave_txt, 0);
            this.Controls.SetChildIndex(this.browser_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TextBoxCommon doc_code_txt;
        private Framework.LabelCommon doc_code_lbl;
        private Framework.ComboBoxCommon model_cmb;
        private Framework.LabelCommon model_lbl;
        private Framework.ButtonCommon Cancel_btn;
        private Framework.ButtonCommon OK_btn;
        private Framework.LabelCommon group_lbl;
        private Framework.LabelCommon revision_lbl;
        private Framework.TextBoxCommon revision_txt;
        private Framework.LabelCommon DocType_lbl;
        private Framework.TextBoxCommon DocType_txt;
        private Framework.LabelCommon depart_lbl;
        private Framework.TextBoxCommon depart_txt;
        private Framework.LabelCommon Doc_name_lbl;
        private Framework.TextBoxCommon doc_name_txt;
        private Framework.TextBoxCommon group_txt;
        private Framework.DateTimePickerCommon updatetime_dtp;
        private Framework.LabelCommon updatetime_lbl;
        private Framework.ButtonCommon browser_btn;
        private Framework.TextBoxCommon linksave_txt;
    }
}
