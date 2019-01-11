﻿namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class NoiseCheckForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_timer = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.txt_barcode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.cmb_model = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.lbl_barcode = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pb_OK = new System.Windows.Forms.PictureBox();
            this.pb_NG = new System.Windows.Forms.PictureBox();
            this.lbl_status = new Com.Nidec.Mes.Framework.LabelCommon();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_OK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_model
            // 
            this.lbl_model.AutoSize = true;
            this.lbl_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_model.Location = new System.Drawing.Point(3, 5);
            this.lbl_model.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_model.Name = "lbl_model";
            this.lbl_model.Size = new System.Drawing.Size(56, 20);
            this.lbl_model.TabIndex = 3;
            this.lbl_model.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "seconds";
            // 
            // txt_timer
            // 
            this.txt_timer.ControlId = null;
            this.txt_timer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timer.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.txt_timer.Location = new System.Drawing.Point(3, 3);
            this.txt_timer.Name = "txt_timer";
            this.txt_timer.Size = new System.Drawing.Size(48, 29);
            this.txt_timer.TabIndex = 15;
            this.txt_timer.Text = "5";
            // 
            // txt_barcode
            // 
            this.txt_barcode.ControlId = null;
            this.txt_barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_barcode.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_barcode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txt_barcode.Location = new System.Drawing.Point(381, 3);
            this.txt_barcode.MaxLength = 8;
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(217, 29);
            this.txt_barcode.TabIndex = 13;
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timer.Location = new System.Drawing.Point(3, 46);
            this.lbl_timer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(52, 20);
            this.lbl_timer.TabIndex = 10;
            this.lbl_timer.Text = "Timer:";
            // 
            // cmb_model
            // 
            this.cmb_model.ControlId = null;
            this.cmb_model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_model.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_model.FormattingEnabled = true;
            this.cmb_model.Location = new System.Drawing.Point(75, 3);
            this.cmb_model.Name = "cmb_model";
            this.cmb_model.Size = new System.Drawing.Size(220, 30);
            this.cmb_model.TabIndex = 12;
            // 
            // lbl_barcode
            // 
            this.lbl_barcode.AutoSize = true;
            this.lbl_barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_barcode.Location = new System.Drawing.Point(301, 5);
            this.lbl_barcode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_barcode.Name = "lbl_barcode";
            this.lbl_barcode.Size = new System.Drawing.Size(73, 20);
            this.lbl_barcode.TabIndex = 9;
            this.lbl_barcode.Text = "Barcode:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pb_OK
            // 
            this.pb_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_OK.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.ok;
            this.pb_OK.Location = new System.Drawing.Point(0, 0);
            this.pb_OK.Name = "pb_OK";
            this.pb_OK.Size = new System.Drawing.Size(679, 349);
            this.pb_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_OK.TabIndex = 5;
            this.pb_OK.TabStop = false;
            // 
            // pb_NG
            // 
            this.pb_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_NG.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.NG;
            this.pb_NG.Location = new System.Drawing.Point(0, 0);
            this.pb_NG.Name = "pb_NG";
            this.pb_NG.Size = new System.Drawing.Size(679, 349);
            this.pb_NG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_NG.TabIndex = 6;
            this.pb_NG.TabStop = false;
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_status.AutoSize = true;
            this.lbl_status.ControlId = null;
            this.lbl_status.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(39, 120);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(513, 107);
            this.lbl_status.TabIndex = 7;
            this.lbl_status.Text = "CHECKED";
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
            this.dgv_thurst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_thurst.Location = new System.Drawing.Point(0, 0);
            this.dgv_thurst.Name = "dgv_thurst";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thurst.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_thurst.Size = new System.Drawing.Size(1284, 123);
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
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.Capture;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(679, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 107);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 563);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1284, 83);
            this.splitContainer2.SplitterDistance = 601;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.14642F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.77038F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.47754F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.93843F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_model, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_timer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_barcode, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmb_model, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_barcode, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(601, 83);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_timer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(75, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 36);
            this.panel2.TabIndex = 14;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgv_thurst);
            this.splitContainer3.Size = new System.Drawing.Size(1284, 476);
            this.splitContainer3.SplitterDistance = 349;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pb_OK);
            this.splitContainer4.Panel2.Controls.Add(this.pb_NG);
            this.splitContainer4.Size = new System.Drawing.Size(1284, 349);
            this.splitContainer4.SplitterDistance = 601;
            this.splitContainer4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 349);
            this.panel1.TabIndex = 0;
            // 
            // NoiseCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 670);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NoiseCheckForm";
            this.Text = "ShippingCheckForm";
            this.TitleText = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NoiseCheckForm_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pb_OK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_model;
        private System.Windows.Forms.Label lbl_barcode;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Timer timer1;
        private Framework.ComboBoxCommon cmb_model;
        private Framework.TextBoxCommon txt_barcode;
        private System.Windows.Forms.Label label3;
        private Framework.TextBoxCommon txt_timer;
        private System.Windows.Forms.PictureBox pb_OK;
        private System.Windows.Forms.PictureBox pb_NG;
        private Framework.LabelCommon lbl_status;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel1;
    }
}