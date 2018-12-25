namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class ProducionControllerGA1Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelCommon5 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.cmb_item = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.cmb_process = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.cmb_line = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.btn_search = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.cmb_model = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.lbl_model = new System.Windows.Forms.Label();
            this.dgv_main = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.col_serno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_inspectdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chr_main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chr_main)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelCommon5);
            this.groupBox1.Controls.Add(this.cmb_item);
            this.groupBox1.Controls.Add(this.cmb_process);
            this.groupBox1.Controls.Add(this.labelCommon3);
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Controls.Add(this.labelCommon4);
            this.groupBox1.Controls.Add(this.cmb_line);
            this.groupBox1.Controls.Add(this.labelCommon2);
            this.groupBox1.Controls.Add(this.labelCommon1);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.cmb_model);
            this.groupBox1.Controls.Add(this.lbl_model);
            this.groupBox1.Location = new System.Drawing.Point(0, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // labelCommon5
            // 
            this.labelCommon5.AutoSize = true;
            this.labelCommon5.ControlId = null;
            this.labelCommon5.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon5.Location = new System.Drawing.Point(135, 63);
            this.labelCommon5.Name = "labelCommon5";
            this.labelCommon5.Size = new System.Drawing.Size(77, 15);
            this.labelCommon5.TabIndex = 100;
            this.labelCommon5.Text = "Inspect Item:";
            // 
            // cmb_item
            // 
            this.cmb_item.ControlId = null;
            this.cmb_item.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_item.FormattingEnabled = true;
            this.cmb_item.Location = new System.Drawing.Point(138, 81);
            this.cmb_item.Name = "cmb_item";
            this.cmb_item.Size = new System.Drawing.Size(121, 23);
            this.cmb_item.TabIndex = 101;
            // 
            // cmb_process
            // 
            this.cmb_process.ControlId = null;
            this.cmb_process.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_process.FormattingEnabled = true;
            this.cmb_process.Location = new System.Drawing.Point(11, 81);
            this.cmb_process.Name = "cmb_process";
            this.cmb_process.Size = new System.Drawing.Size(121, 23);
            this.cmb_process.TabIndex = 99;
            this.cmb_process.SelectedIndexChanged += new System.EventHandler(this.cmb_process_SelectedIndexChanged);
            // 
            // labelCommon3
            // 
            this.labelCommon3.AutoSize = true;
            this.labelCommon3.ControlId = null;
            this.labelCommon3.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon3.Location = new System.Drawing.Point(8, 67);
            this.labelCommon3.Name = "labelCommon3";
            this.labelCommon3.Size = new System.Drawing.Size(56, 15);
            this.labelCommon3.TabIndex = 98;
            this.labelCommon3.Text = "Process:";
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(476, 41);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(151, 20);
            this.dtp_to.TabIndex = 70;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(300, 41);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(142, 20);
            this.dtp_from.TabIndex = 7;
            // 
            // labelCommon4
            // 
            this.labelCommon4.AutoSize = true;
            this.labelCommon4.ControlId = null;
            this.labelCommon4.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon4.Location = new System.Drawing.Point(135, 20);
            this.labelCommon4.Name = "labelCommon4";
            this.labelCommon4.Size = new System.Drawing.Size(34, 15);
            this.labelCommon4.TabIndex = 96;
            this.labelCommon4.Text = "Line:";
            // 
            // cmb_line
            // 
            this.cmb_line.ControlId = null;
            this.cmb_line.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_line.FormattingEnabled = true;
            this.cmb_line.Location = new System.Drawing.Point(138, 38);
            this.cmb_line.Name = "cmb_line";
            this.cmb_line.Size = new System.Drawing.Size(121, 23);
            this.cmb_line.TabIndex = 97;
            this.cmb_line.SelectedIndexChanged += new System.EventHandler(this.cmb_line_SelectedIndexChanged);
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon2.Location = new System.Drawing.Point(473, 23);
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
            this.labelCommon1.Location = new System.Drawing.Point(297, 23);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(96, 15);
            this.labelCommon1.TabIndex = 68;
            this.labelCommon1.Text = "From DateTime:";
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Control;
            this.btn_search.ControlId = null;
            this.btn_search.Font = new System.Drawing.Font("Arial", 9F);
            this.btn_search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_search.Location = new System.Drawing.Point(649, 31);
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
            this.cmb_model.SelectedIndexChanged += new System.EventHandler(this.cmb_model_SelectedIndexChanged);
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
            // dgv_main
            // 
            this.dgv_main.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_serno,
            this.col_process,
            this.col_inspectdate,
            this.col_data});
            this.dgv_main.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_main.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_main.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv_main.Location = new System.Drawing.Point(834, 107);
            this.dgv_main.Name = "dgv_main";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_main.Size = new System.Drawing.Size(453, 553);
            this.dgv_main.TabIndex = 6;
            // 
            // col_serno
            // 
            this.col_serno.DataPropertyName = "Serno";
            this.col_serno.HeaderText = "Serno";
            this.col_serno.Name = "col_serno";
            // 
            // col_process
            // 
            this.col_process.DataPropertyName = "ProcessCode";
            this.col_process.HeaderText = "Process";
            this.col_process.Name = "col_process";
            // 
            // col_inspectdate
            // 
            this.col_inspectdate.DataPropertyName = "InspectDate";
            this.col_inspectdate.HeaderText = "InspectDate";
            this.col_inspectdate.Name = "col_inspectdate";
            // 
            // col_data
            // 
            this.col_data.DataPropertyName = "Data";
            this.col_data.HeaderText = "Data";
            this.col_data.Name = "col_data";
            // 
            // chr_main
            // 
            this.chr_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chr_main.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chr_main.Legends.Add(legend1);
            this.chr_main.Location = new System.Drawing.Point(28, 33);
            this.chr_main.Name = "chr_main";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chr_main.Series.Add(series1);
            this.chr_main.Size = new System.Drawing.Size(779, 374);
            this.chr_main.TabIndex = 7;
            this.chr_main.Text = "chart1";
            title1.Name = "Title1";
            this.chr_main.Titles.Add(title1);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chr_main);
            this.groupBox2.Location = new System.Drawing.Point(0, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(828, 429);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // ProducionControllerGA1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 660);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_main);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProducionControllerGA1Form";
            this.Text = "Test";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ProducionControllerGA1Form_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dgv_main, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chr_main)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.ButtonCommon btn_search;
        private Framework.ComboBoxCommon cmb_model;
        private System.Windows.Forms.Label lbl_model;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private Framework.DataGridViewCommon dgv_main;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DataVisualization.Charting.Chart chr_main;
        private System.Windows.Forms.GroupBox groupBox2;
        private Framework.ComboBoxCommon cmb_process;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon labelCommon4;
        private Framework.ComboBoxCommon cmb_line;
        private Framework.LabelCommon labelCommon5;
        private Framework.ComboBoxCommon cmb_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_serno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_process;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_inspectdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_data;
    }
}