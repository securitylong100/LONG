namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class ShowCheckForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_model = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_autoview = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.dpt_to = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.dpt_from = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.btn_search = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.cmb_model = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.btn_exportexcel = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.txt_linksave = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.btn_browser = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.dgv_thurst = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.col_stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_thurst_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_noise_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_oqc_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_oqc_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shipping = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_datatime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBoxCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_model
            // 
            this.lbl_model.AutoSize = true;
            this.lbl_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_model.Location = new System.Drawing.Point(8, 18);
            this.lbl_model.Name = "lbl_model";
            this.lbl_model.Size = new System.Drawing.Size(49, 16);
            this.lbl_model.TabIndex = 3;
            this.lbl_model.Text = "Model:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_autoview);
            this.groupBox1.Controls.Add(this.labelCommon2);
            this.groupBox1.Controls.Add(this.labelCommon1);
            this.groupBox1.Controls.Add(this.dpt_to);
            this.groupBox1.Controls.Add(this.dpt_from);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.cmb_model);
            this.groupBox1.Controls.Add(this.lbl_model);
            this.groupBox1.Location = new System.Drawing.Point(8, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // btn_autoview
            // 
            this.btn_autoview.BackColor = System.Drawing.SystemColors.Control;
            this.btn_autoview.ControlId = null;
            this.btn_autoview.Font = new System.Drawing.Font("Arial", 9F);
            this.btn_autoview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_autoview.Location = new System.Drawing.Point(622, 28);
            this.btn_autoview.Name = "btn_autoview";
            this.btn_autoview.Size = new System.Drawing.Size(82, 34);
            this.btn_autoview.TabIndex = 70;
            this.btn_autoview.Text = "Auto View";
            this.btn_autoview.UseVisualStyleBackColor = false;
            this.btn_autoview.Click += new System.EventHandler(this.btn_autoview_Click);
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon2.Location = new System.Drawing.Point(340, 19);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(80, 15);
            this.labelCommon2.TabIndex = 69;
            this.labelCommon2.Text = "To DateTime:";
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon1.Location = new System.Drawing.Point(159, 19);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(96, 15);
            this.labelCommon1.TabIndex = 68;
            this.labelCommon1.Text = "From DateTime:";
            // 
            // dpt_to
            // 
            this.dpt_to.BackColor = System.Drawing.SystemColors.Control;
            this.dpt_to.ControlId = null;
            this.dpt_to.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dpt_to.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.dpt_to.Font = new System.Drawing.Font("Arial", 9F);
            this.dpt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpt_to.Location = new System.Drawing.Point(343, 40);
            this.dpt_to.Name = "dpt_to";
            this.dpt_to.Size = new System.Drawing.Size(155, 21);
            this.dpt_to.TabIndex = 67;
            // 
            // dpt_from
            // 
            this.dpt_from.BackColor = System.Drawing.SystemColors.Control;
            this.dpt_from.ControlId = null;
            this.dpt_from.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dpt_from.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.dpt_from.Font = new System.Drawing.Font("Arial", 9F);
            this.dpt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpt_from.Location = new System.Drawing.Point(162, 40);
            this.dpt_from.Name = "dpt_from";
            this.dpt_from.Size = new System.Drawing.Size(155, 21);
            this.dpt_from.TabIndex = 66;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Control;
            this.btn_search.ControlId = null;
            this.btn_search.Font = new System.Drawing.Font("Arial", 9F);
            this.btn_search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_search.Location = new System.Drawing.Point(519, 28);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(82, 34);
            this.btn_search.TabIndex = 63;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // cmb_model
            // 
            this.cmb_model.ControlId = null;
            this.cmb_model.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_model.FormattingEnabled = true;
            this.cmb_model.Location = new System.Drawing.Point(11, 37);
            this.cmb_model.Name = "cmb_model";
            this.cmb_model.Size = new System.Drawing.Size(121, 24);
            this.cmb_model.TabIndex = 12;
            // 
            // btn_exportexcel
            // 
            this.btn_exportexcel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_exportexcel.ControlId = null;
            this.btn_exportexcel.Font = new System.Drawing.Font("Arial", 9F);
            this.btn_exportexcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_exportexcel.Location = new System.Drawing.Point(328, 20);
            this.btn_exportexcel.Name = "btn_exportexcel";
            this.btn_exportexcel.Size = new System.Drawing.Size(82, 34);
            this.btn_exportexcel.TabIndex = 62;
            this.btn_exportexcel.Text = "Export Excel";
            this.btn_exportexcel.UseVisualStyleBackColor = false;
            this.btn_exportexcel.Click += new System.EventHandler(this.btn_exportexcel_Click);
            // 
            // txt_linksave
            // 
            this.txt_linksave.ControlId = null;
            this.txt_linksave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_linksave.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txt_linksave.Location = new System.Drawing.Point(134, 26);
            this.txt_linksave.Name = "txt_linksave";
            this.txt_linksave.Size = new System.Drawing.Size(188, 21);
            this.txt_linksave.TabIndex = 61;
            // 
            // btn_browser
            // 
            this.btn_browser.BackColor = System.Drawing.SystemColors.Control;
            this.btn_browser.ControlId = null;
            this.btn_browser.Font = new System.Drawing.Font("Arial", 9F);
            this.btn_browser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_browser.Location = new System.Drawing.Point(51, 20);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(67, 33);
            this.btn_browser.TabIndex = 60;
            this.btn_browser.Text = "Browser";
            this.btn_browser.UseVisualStyleBackColor = false;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.btn_exportexcel);
            this.groupBoxCommon1.Controls.Add(this.btn_browser);
            this.groupBoxCommon1.Controls.Add(this.txt_linksave);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(785, 113);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(455, 70);
            this.groupBoxCommon1.TabIndex = 5;
            this.groupBoxCommon1.TabStop = false;
            this.groupBoxCommon1.Text = "Export File";
            // 
            // dgv_thurst
            // 
            this.dgv_thurst.AllowUserToAddRows = false;
            this.dgv_thurst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_thurst.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thurst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_thurst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_stt,
            this.col_model,
            this.col_line,
            this.col_barcode,
            this.col_thurst_data,
            this.col_noise_status,
            this.col_oqc_status,
            this.col_oqc_data,
            this.col_shipping,
            this.col_datatime,
            this.col_user});
            this.dgv_thurst.ControlId = null;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_thurst.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_thurst.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_thurst.Location = new System.Drawing.Point(0, 210);
            this.dgv_thurst.Name = "dgv_thurst";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thurst.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_thurst.Size = new System.Drawing.Size(1284, 460);
            this.dgv_thurst.TabIndex = 9;
            // 
            // col_stt
            // 
            this.col_stt.DataPropertyName = "STT";
            this.col_stt.HeaderText = "Qty";
            this.col_stt.Name = "col_stt";
            this.col_stt.Width = 49;
            // 
            // col_model
            // 
            this.col_model.DataPropertyName = "A90Model";
            this.col_model.HeaderText = "Model";
            this.col_model.Name = "col_model";
            this.col_model.Width = 65;
            // 
            // col_line
            // 
            this.col_line.DataPropertyName = "A90Line";
            this.col_line.HeaderText = "Line";
            this.col_line.Name = "col_line";
            this.col_line.Width = 56;
            // 
            // col_barcode
            // 
            this.col_barcode.DataPropertyName = "A90Barcode";
            this.col_barcode.HeaderText = "Barcode";
            this.col_barcode.Name = "col_barcode";
            this.col_barcode.Width = 78;
            // 
            // col_thurst_data
            // 
            this.col_thurst_data.DataPropertyName = "A90ThurstStatus";
            this.col_thurst_data.HeaderText = "Thurst Status";
            this.col_thurst_data.Name = "col_thurst_data";
            this.col_thurst_data.Width = 105;
            // 
            // col_noise_status
            // 
            this.col_noise_status.DataPropertyName = "A90NoiseStatus";
            this.col_noise_status.HeaderText = "Noise Status";
            this.col_noise_status.Name = "col_noise_status";
            this.col_noise_status.Width = 103;
            // 
            // col_oqc_status
            // 
            this.col_oqc_status.DataPropertyName = "A90OQCStatus";
            this.col_oqc_status.HeaderText = "OQC Status";
            this.col_oqc_status.Name = "col_oqc_status";
            this.col_oqc_status.Width = 97;
            // 
            // col_oqc_data
            // 
            this.col_oqc_data.DataPropertyName = "A90OQCData";
            this.col_oqc_data.HeaderText = "OQC Data";
            this.col_oqc_data.Name = "col_oqc_data";
            this.col_oqc_data.Width = 88;
            // 
            // col_shipping
            // 
            this.col_shipping.DataPropertyName = "A90Shipping";
            this.col_shipping.HeaderText = "Shipping Status";
            this.col_shipping.Name = "col_shipping";
            this.col_shipping.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_shipping.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_shipping.Width = 119;
            // 
            // col_datatime
            // 
            this.col_datatime.DataPropertyName = "RegistrationDateTime";
            this.col_datatime.HeaderText = "Date Time";
            this.col_datatime.Name = "col_datatime";
            this.col_datatime.Width = 89;
            // 
            // col_user
            // 
            this.col_user.DataPropertyName = "RegistrationUserCode";
            this.col_user.HeaderText = "User Name";
            this.col_user.Name = "col_user";
            this.col_user.Width = 96;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ShowCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 670);
            this.Controls.Add(this.dgv_thurst);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShowCheckForm";
            this.Text = "Show Form";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ShowCheckForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.dgv_thurst, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_model;
        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.ComboBoxCommon cmb_model;
        private Framework.ButtonCommon btn_exportexcel;
        private Framework.TextBoxCommon txt_linksave;
        private Framework.ButtonCommon btn_browser;
        private Framework.ButtonCommon btn_search;
        private Framework.ButtonCommon btn_autoview;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.DateTimePickerCommon dpt_to;
        private Framework.DateTimePickerCommon dpt_from;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.DataGridViewCommon dgv_thurst;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_line;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_thurst_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_noise_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_oqc_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_oqc_data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_shipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_datatime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user;
        private System.Windows.Forms.Timer timer1;
    }
}