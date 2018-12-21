namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class ShippingCheckForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_model = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_search = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.txt_barcode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.cmb_model = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.lbl_barcode = new System.Windows.Forms.Label();
            this.pb_OK = new System.Windows.Forms.PictureBox();
            this.pb_NG = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.pb_nodata = new System.Windows.Forms.PictureBox();
            this.pb_noiseNodata = new System.Windows.Forms.PictureBox();
            this.pb_noise_ok = new System.Windows.Forms.PictureBox();
            this.pb_noise_NG = new System.Windows.Forms.PictureBox();
            this.dgv_thurst = new Com.Nidec.Mes.Framework.DataGridViewCommon();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_OK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NG)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nodata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noiseNodata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noise_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noise_NG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_model
            // 
            this.lbl_model.AutoSize = true;
            this.lbl_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_model.Location = new System.Drawing.Point(8, 18);
            this.lbl_model.Name = "lbl_model";
            this.lbl_model.Size = new System.Drawing.Size(56, 20);
            this.lbl_model.TabIndex = 3;
            this.lbl_model.Text = "Model:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.txt_barcode);
            this.groupBox1.Controls.Add(this.cmb_model);
            this.groupBox1.Controls.Add(this.lbl_barcode);
            this.groupBox1.Controls.Add(this.lbl_model);
            this.groupBox1.Location = new System.Drawing.Point(8, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 87);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Control;
            this.btn_search.ControlId = null;
            this.btn_search.Font = new System.Drawing.Font("Arial", 9F);
            this.btn_search.Location = new System.Drawing.Point(311, 48);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(90, 33);
            this.btn_search.TabIndex = 14;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_barcode
            // 
            this.txt_barcode.ControlId = null;
            this.txt_barcode.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_barcode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txt_barcode.Location = new System.Drawing.Point(311, 13);
            this.txt_barcode.MaxLength = 8;
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(163, 29);
            this.txt_barcode.TabIndex = 13;
            // 
            // cmb_model
            // 
            this.cmb_model.ControlId = null;
            this.cmb_model.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_model.FormattingEnabled = true;
            this.cmb_model.Location = new System.Drawing.Point(70, 13);
            this.cmb_model.Name = "cmb_model";
            this.cmb_model.Size = new System.Drawing.Size(121, 30);
            this.cmb_model.TabIndex = 12;
            // 
            // lbl_barcode
            // 
            this.lbl_barcode.AutoSize = true;
            this.lbl_barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_barcode.Location = new System.Drawing.Point(241, 18);
            this.lbl_barcode.Name = "lbl_barcode";
            this.lbl_barcode.Size = new System.Drawing.Size(73, 20);
            this.lbl_barcode.TabIndex = 9;
            this.lbl_barcode.Text = "Barcode:";
            // 
            // pb_OK
            // 
            this.pb_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_OK.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.ok;
            this.pb_OK.Location = new System.Drawing.Point(109, 43);
            this.pb_OK.Name = "pb_OK";
            this.pb_OK.Size = new System.Drawing.Size(364, 328);
            this.pb_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_OK.TabIndex = 5;
            this.pb_OK.TabStop = false;
            // 
            // pb_NG
            // 
            this.pb_NG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_NG.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.NG;
            this.pb_NG.Location = new System.Drawing.Point(113, 43);
            this.pb_NG.Name = "pb_NG";
            this.pb_NG.Size = new System.Drawing.Size(360, 327);
            this.pb_NG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_NG.TabIndex = 6;
            this.pb_NG.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelCommon2);
            this.groupBox2.Controls.Add(this.labelCommon1);
            this.groupBox2.Controls.Add(this.pb_nodata);
            this.groupBox2.Controls.Add(this.pb_noiseNodata);
            this.groupBox2.Controls.Add(this.pb_noise_ok);
            this.groupBox2.Controls.Add(this.pb_noise_NG);
            this.groupBox2.Controls.Add(this.dgv_thurst);
            this.groupBox2.Controls.Add(this.pb_OK);
            this.groupBox2.Controls.Add(this.pb_NG);
            this.groupBox2.Location = new System.Drawing.Point(0, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1281, 456);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // labelCommon2
            // 
            this.labelCommon2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon2.Location = new System.Drawing.Point(944, 16);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(118, 22);
            this.labelCommon2.TabIndex = 14;
            this.labelCommon2.Text = "Noise Check";
            // 
            // labelCommon1
            // 
            this.labelCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon1.Location = new System.Drawing.Point(224, 16);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(122, 22);
            this.labelCommon1.TabIndex = 13;
            this.labelCommon1.Text = "Thurst Check";
            // 
            // pb_nodata
            // 
            this.pb_nodata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_nodata.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.NoDaTa;
            this.pb_nodata.InitialImage = null;
            this.pb_nodata.Location = new System.Drawing.Point(109, 43);
            this.pb_nodata.Name = "pb_nodata";
            this.pb_nodata.Size = new System.Drawing.Size(364, 327);
            this.pb_nodata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_nodata.TabIndex = 12;
            this.pb_nodata.TabStop = false;
            // 
            // pb_noiseNodata
            // 
            this.pb_noiseNodata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_noiseNodata.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.NoDaTa;
            this.pb_noiseNodata.InitialImage = null;
            this.pb_noiseNodata.Location = new System.Drawing.Point(821, 43);
            this.pb_noiseNodata.Name = "pb_noiseNodata";
            this.pb_noiseNodata.Size = new System.Drawing.Size(362, 327);
            this.pb_noiseNodata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_noiseNodata.TabIndex = 11;
            this.pb_noiseNodata.TabStop = false;
            // 
            // pb_noise_ok
            // 
            this.pb_noise_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_noise_ok.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.ok;
            this.pb_noise_ok.Location = new System.Drawing.Point(821, 43);
            this.pb_noise_ok.Name = "pb_noise_ok";
            this.pb_noise_ok.Size = new System.Drawing.Size(362, 327);
            this.pb_noise_ok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_noise_ok.TabIndex = 10;
            this.pb_noise_ok.TabStop = false;
            // 
            // pb_noise_NG
            // 
            this.pb_noise_NG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_noise_NG.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.NG;
            this.pb_noise_NG.Location = new System.Drawing.Point(821, 43);
            this.pb_noise_NG.Name = "pb_noise_NG";
            this.pb_noise_NG.Size = new System.Drawing.Size(362, 327);
            this.pb_noise_NG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_noise_NG.TabIndex = 9;
            this.pb_noise_NG.TabStop = false;
            // 
            // dgv_thurst
            // 
            this.dgv_thurst.AllowUserToAddRows = false;
            this.dgv_thurst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_thurst.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thurst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_thurst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_thurst.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_thurst.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_thurst.Location = new System.Drawing.Point(3, 376);
            this.dgv_thurst.Name = "dgv_thurst";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thurst.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_thurst.Size = new System.Drawing.Size(1275, 77);
            this.dgv_thurst.TabIndex = 8;
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureBox1.Location = new System.Drawing.Point(547, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(734, 85);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(813, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "MOUSE AREA";
            // 
            // ShippingCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 670);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShippingCheckForm";
            this.Text = "NoiseCheckForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ShippingCheckForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_OK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NG)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nodata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noiseNodata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noise_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noise_NG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_model;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_barcode;
        private Framework.ComboBoxCommon cmb_model;
        private Framework.TextBoxCommon txt_barcode;
        private System.Windows.Forms.PictureBox pb_OK;
        private System.Windows.Forms.PictureBox pb_NG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Framework.DataGridViewCommon dgv_thurst;
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
        private System.Windows.Forms.PictureBox pb_noiseNodata;
        private System.Windows.Forms.PictureBox pb_noise_ok;
        private System.Windows.Forms.PictureBox pb_noise_NG;
        private System.Windows.Forms.PictureBox pb_nodata;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.ButtonCommon btn_search;
    }
}