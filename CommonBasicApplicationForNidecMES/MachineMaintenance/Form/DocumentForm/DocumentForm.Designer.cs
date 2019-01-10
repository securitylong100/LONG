namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class DocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timefrom_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.document_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.col_document_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_document_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_update_date_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.doc_name_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timefrom_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.version_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.version_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.doc_type_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.doc_type_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.timeto_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timeto_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.depart_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.depart_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.group_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.group_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.doc_name_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            ((System.ComponentModel.ISupportInitialize)(this.document_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // model_cmb
            // 
            this.model_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
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
            // timefrom_lbl
            // 
            resources.ApplyResources(this.timefrom_lbl, "timefrom_lbl");
            this.timefrom_lbl.ControlId = null;
            this.timefrom_lbl.Name = "timefrom_lbl";
            // 
            // document_dgv
            // 
            resources.ApplyResources(this.document_dgv, "document_dgv");
            this.document_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.document_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.document_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.document_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_document_id,
            this.col_document_code,
            this.col_doc_name,
            this.col_model_code,
            this.col_department,
            this.col_group,
            this.col_revision,
            this.col_update_date_time,
            this.col_time_record});
            this.document_dgv.ControlId = null;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.document_dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.document_dgv.Name = "document_dgv";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.document_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.document_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.document_dgv_CellContentClick);
            // 
            // col_document_id
            // 
            this.col_document_id.DataPropertyName = "DocumentID";
            resources.ApplyResources(this.col_document_id, "col_document_id");
            this.col_document_id.Name = "col_document_id";
            this.col_document_id.ReadOnly = true;
            // 
            // col_document_code
            // 
            this.col_document_code.DataPropertyName = "DocumentCode";
            resources.ApplyResources(this.col_document_code, "col_document_code");
            this.col_document_code.Name = "col_document_code";
            this.col_document_code.ReadOnly = true;
            // 
            // col_doc_name
            // 
            this.col_doc_name.DataPropertyName = "DocumentName";
            resources.ApplyResources(this.col_doc_name, "col_doc_name");
            this.col_doc_name.Name = "col_doc_name";
            this.col_doc_name.ReadOnly = true;
            // 
            // col_model_code
            // 
            this.col_model_code.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.col_model_code, "col_model_code");
            this.col_model_code.Name = "col_model_code";
            this.col_model_code.ReadOnly = true;
            // 
            // col_department
            // 
            this.col_department.DataPropertyName = "Department";
            resources.ApplyResources(this.col_department, "col_department");
            this.col_department.Name = "col_department";
            this.col_department.ReadOnly = true;
            // 
            // col_group
            // 
            this.col_group.DataPropertyName = "Group";
            resources.ApplyResources(this.col_group, "col_group");
            this.col_group.Name = "col_group";
            this.col_group.ReadOnly = true;
            // 
            // col_revision
            // 
            this.col_revision.DataPropertyName = "Revision";
            resources.ApplyResources(this.col_revision, "col_revision");
            this.col_revision.Name = "col_revision";
            this.col_revision.ReadOnly = true;
            // 
            // col_update_date_time
            // 
            this.col_update_date_time.DataPropertyName = "TimeFrom";
            resources.ApplyResources(this.col_update_date_time, "col_update_date_time");
            this.col_update_date_time.Name = "col_update_date_time";
            this.col_update_date_time.ReadOnly = true;
            // 
            // col_time_record
            // 
            this.col_time_record.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_time_record.DataPropertyName = "RegistrationDateTime";
            resources.ApplyResources(this.col_time_record, "col_time_record");
            this.col_time_record.Name = "col_time_record";
            this.col_time_record.ReadOnly = true;
            // 
            // update_btn
            // 
            resources.ApplyResources(this.update_btn, "update_btn");
            this.update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.update_btn.ControlId = "mcfb002";
            this.update_btn.Name = "update_btn";
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // add_btn
            // 
            resources.ApplyResources(this.add_btn, "add_btn");
            this.add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.add_btn.ControlId = "mcfb001";
            this.add_btn.Name = "add_btn";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // clear_btn
            // 
            resources.ApplyResources(this.clear_btn, "clear_btn");
            this.clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.clear_btn.ControlId = null;
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // search_btn
            // 
            resources.ApplyResources(this.search_btn, "search_btn");
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.ControlId = null;
            this.search_btn.Name = "search_btn";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // doc_name_lbl
            // 
            resources.ApplyResources(this.doc_name_lbl, "doc_name_lbl");
            this.doc_name_lbl.ControlId = null;
            this.doc_name_lbl.Name = "doc_name_lbl";
            // 
            // timefrom_dtp
            // 
            this.timefrom_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timefrom_dtp.Checked = false;
            this.timefrom_dtp.ControlId = null;
            resources.ApplyResources(this.timefrom_dtp, "timefrom_dtp");
            this.timefrom_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timefrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timefrom_dtp.Name = "timefrom_dtp";
            // 
            // version_lbl
            // 
            resources.ApplyResources(this.version_lbl, "version_lbl");
            this.version_lbl.ControlId = null;
            this.version_lbl.Name = "version_lbl";
            // 
            // version_cmb
            // 
            this.version_cmb.ControlId = null;
            resources.ApplyResources(this.version_cmb, "version_cmb");
            this.version_cmb.FormattingEnabled = true;
            this.version_cmb.Name = "version_cmb";
            this.version_cmb.TextChanged += new System.EventHandler(this.version_cmb_TextChanged);
            // 
            // doc_type_lbl
            // 
            resources.ApplyResources(this.doc_type_lbl, "doc_type_lbl");
            this.doc_type_lbl.ControlId = null;
            this.doc_type_lbl.Name = "doc_type_lbl";
            // 
            // doc_type_cmb
            // 
            this.doc_type_cmb.ControlId = null;
            resources.ApplyResources(this.doc_type_cmb, "doc_type_cmb");
            this.doc_type_cmb.FormattingEnabled = true;
            this.doc_type_cmb.Name = "doc_type_cmb";
            this.doc_type_cmb.SelectedIndexChanged += new System.EventHandler(this.doc_type_cmb_SelectedIndexChanged);
            // 
            // timeto_lbl
            // 
            resources.ApplyResources(this.timeto_lbl, "timeto_lbl");
            this.timeto_lbl.ControlId = null;
            this.timeto_lbl.Name = "timeto_lbl";
            // 
            // timeto_dtp
            // 
            this.timeto_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timeto_dtp.Checked = false;
            this.timeto_dtp.ControlId = null;
            resources.ApplyResources(this.timeto_dtp, "timeto_dtp");
            this.timeto_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timeto_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeto_dtp.Name = "timeto_dtp";
            // 
            // depart_lbl
            // 
            resources.ApplyResources(this.depart_lbl, "depart_lbl");
            this.depart_lbl.ControlId = null;
            this.depart_lbl.Name = "depart_lbl";
            // 
            // depart_cmb
            // 
            this.depart_cmb.ControlId = null;
            resources.ApplyResources(this.depart_cmb, "depart_cmb");
            this.depart_cmb.FormattingEnabled = true;
            this.depart_cmb.Name = "depart_cmb";
            this.depart_cmb.SelectedIndexChanged += new System.EventHandler(this.depart_cmb_SelectedIndexChanged);
            // 
            // group_lbl
            // 
            resources.ApplyResources(this.group_lbl, "group_lbl");
            this.group_lbl.ControlId = null;
            this.group_lbl.Name = "group_lbl";
            // 
            // group_cmb
            // 
            this.group_cmb.ControlId = null;
            resources.ApplyResources(this.group_cmb, "group_cmb");
            this.group_cmb.FormattingEnabled = true;
            this.group_cmb.Name = "group_cmb";
            this.group_cmb.SelectedIndexChanged += new System.EventHandler(this.group_cmb_SelectedIndexChanged);
            // 
            // doc_name_cmb
            // 
            this.doc_name_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.doc_name_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.doc_name_cmb.ControlId = null;
            resources.ApplyResources(this.doc_name_cmb, "doc_name_cmb");
            this.doc_name_cmb.FormattingEnabled = true;
            this.doc_name_cmb.Name = "doc_name_cmb";
            // 
            // DocumentForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.timeto_dtp);
            this.Controls.Add(this.timefrom_dtp);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.update_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.timeto_lbl);
            this.Controls.Add(this.document_dgv);
            this.Controls.Add(this.timefrom_lbl);
            this.Controls.Add(this.group_cmb);
            this.Controls.Add(this.group_lbl);
            this.Controls.Add(this.depart_cmb);
            this.Controls.Add(this.depart_lbl);
            this.Controls.Add(this.doc_type_cmb);
            this.Controls.Add(this.doc_type_lbl);
            this.Controls.Add(this.doc_name_cmb);
            this.Controls.Add(this.version_cmb);
            this.Controls.Add(this.version_lbl);
            this.Controls.Add(this.doc_name_lbl);
            this.Controls.Add(this.model_cmb);
            this.Controls.Add(this.model_lbl);
            this.Name = "DocumentForm";
            this.TitleText = "Document Management";
            this.Load += new System.EventHandler(this.DocumentForm_Load);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.model_cmb, 0);
            this.Controls.SetChildIndex(this.doc_name_lbl, 0);
            this.Controls.SetChildIndex(this.version_lbl, 0);
            this.Controls.SetChildIndex(this.version_cmb, 0);
            this.Controls.SetChildIndex(this.doc_name_cmb, 0);
            this.Controls.SetChildIndex(this.doc_type_lbl, 0);
            this.Controls.SetChildIndex(this.doc_type_cmb, 0);
            this.Controls.SetChildIndex(this.depart_lbl, 0);
            this.Controls.SetChildIndex(this.depart_cmb, 0);
            this.Controls.SetChildIndex(this.group_lbl, 0);
            this.Controls.SetChildIndex(this.group_cmb, 0);
            this.Controls.SetChildIndex(this.timefrom_lbl, 0);
            this.Controls.SetChildIndex(this.document_dgv, 0);
            this.Controls.SetChildIndex(this.timeto_lbl, 0);
            this.Controls.SetChildIndex(this.add_btn, 0);
            this.Controls.SetChildIndex(this.update_btn, 0);
            this.Controls.SetChildIndex(this.clear_btn, 0);
            this.Controls.SetChildIndex(this.search_btn, 0);
            this.Controls.SetChildIndex(this.timefrom_dtp, 0);
            this.Controls.SetChildIndex(this.timeto_dtp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.document_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ComboBoxCommon model_cmb;
        private Framework.LabelCommon model_lbl;
        private Framework.LabelCommon timefrom_lbl;
        private Framework.DataGridViewCommon document_dgv;
        private Framework.ButtonCommon update_btn;
        private Framework.ButtonCommon add_btn;
        private Framework.ButtonCommon clear_btn;
        private Framework.ButtonCommon search_btn;
        private Framework.LabelCommon doc_name_lbl;
        private Framework.DateTimePickerCommon timefrom_dtp;
        private Framework.LabelCommon version_lbl;
        private Framework.ComboBoxCommon version_cmb;
        private Framework.LabelCommon doc_type_lbl;
        private Framework.ComboBoxCommon doc_type_cmb;
        private Framework.LabelCommon timeto_lbl;
        private Framework.DateTimePickerCommon timeto_dtp;
        private Framework.LabelCommon depart_lbl;
        private Framework.ComboBoxCommon depart_cmb;
        private Framework.LabelCommon group_lbl;
        private Framework.ComboBoxCommon group_cmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_document_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_document_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_department;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_update_date_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_record;
        private Framework.ComboBoxCommon doc_name_cmb;
    }
}
