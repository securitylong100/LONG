namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class TestForm
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
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.production_controller_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.process_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.timeto_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timeto_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timefrom_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timefrom_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.textBoxCommon1 = new Com.Nidec.Mes.Framework.TextBoxCommon();
            ((System.ComponentModel.ISupportInitialize)(this.production_controller_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // model_lbl
            // 
            this.model_lbl.AutoSize = true;
            this.model_lbl.ControlId = null;
            this.model_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.model_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.model_lbl.Location = new System.Drawing.Point(12, 119);
            this.model_lbl.Name = "model_lbl";
            this.model_lbl.Size = new System.Drawing.Size(43, 15);
            this.model_lbl.TabIndex = 3;
            this.model_lbl.Text = "Model:";
            // 
            // production_controller_dgv
            // 
            this.production_controller_dgv.AllowUserToAddRows = false;
            this.production_controller_dgv.AllowUserToDeleteRows = false;
            this.production_controller_dgv.AllowUserToOrderColumns = true;
            this.production_controller_dgv.AllowUserToResizeRows = false;
            this.production_controller_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.production_controller_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.production_controller_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.production_controller_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.production_controller_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.production_controller_dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.production_controller_dgv.Location = new System.Drawing.Point(0, 177);
            this.production_controller_dgv.Name = "production_controller_dgv";
            this.production_controller_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.production_controller_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.production_controller_dgv.RowHeadersVisible = false;
            this.production_controller_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.production_controller_dgv.Size = new System.Drawing.Size(826, 289);
            this.production_controller_dgv.TabIndex = 25;
            // 
            // model_cmb
            // 
            this.model_cmb.ControlId = null;
            this.model_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.model_cmb.FormattingEnabled = true;
            this.model_cmb.Location = new System.Drawing.Point(61, 116);
            this.model_cmb.Name = "model_cmb";
            this.model_cmb.Size = new System.Drawing.Size(152, 23);
            this.model_cmb.TabIndex = 91;
            this.model_cmb.SelectedIndexChanged += new System.EventHandler(this.model_cmb_SelectedIndexChanged);
            // 
            // line_cmb
            // 
            this.line_cmb.ControlId = null;
            this.line_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line_cmb.FormattingEnabled = true;
            this.line_cmb.Location = new System.Drawing.Point(279, 116);
            this.line_cmb.Name = "line_cmb";
            this.line_cmb.Size = new System.Drawing.Size(152, 23);
            this.line_cmb.TabIndex = 93;
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon1.Location = new System.Drawing.Point(230, 119);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(34, 15);
            this.labelCommon1.TabIndex = 92;
            this.labelCommon1.Text = "Line:";
            // 
            // process_cmb
            // 
            this.process_cmb.ControlId = null;
            this.process_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.process_cmb.FormattingEnabled = true;
            this.process_cmb.Location = new System.Drawing.Point(504, 116);
            this.process_cmb.Name = "process_cmb";
            this.process_cmb.Size = new System.Drawing.Size(152, 23);
            this.process_cmb.TabIndex = 95;
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon2.Location = new System.Drawing.Point(446, 119);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(56, 15);
            this.labelCommon2.TabIndex = 94;
            this.labelCommon2.Text = "Process:";
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.ControlId = null;
            this.search_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.search_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.search_btn.Location = new System.Drawing.Point(690, 138);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(70, 33);
            this.search_btn.TabIndex = 96;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            // 
            // timeto_dtp
            // 
            this.timeto_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timeto_dtp.ControlId = null;
            this.timeto_dtp.CustomFormat = "yyyy/MM/dd hh:mm";
            this.timeto_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timeto_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.timeto_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeto_dtp.Location = new System.Drawing.Point(336, 150);
            this.timeto_dtp.Name = "timeto_dtp";
            this.timeto_dtp.Size = new System.Drawing.Size(166, 21);
            this.timeto_dtp.TabIndex = 98;
            // 
            // timeto_lbl
            // 
            this.timeto_lbl.AutoSize = true;
            this.timeto_lbl.ControlId = null;
            this.timeto_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.timeto_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timeto_lbl.Location = new System.Drawing.Point(273, 152);
            this.timeto_lbl.Name = "timeto_lbl";
            this.timeto_lbl.Size = new System.Drawing.Size(55, 15);
            this.timeto_lbl.TabIndex = 97;
            this.timeto_lbl.Text = "Time To:";
            // 
            // timefrom_dtp
            // 
            this.timefrom_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timefrom_dtp.ControlId = null;
            this.timefrom_dtp.CustomFormat = "yyyy/MM/dd hh:mm";
            this.timefrom_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timefrom_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.timefrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timefrom_dtp.Location = new System.Drawing.Point(88, 150);
            this.timefrom_dtp.Name = "timefrom_dtp";
            this.timefrom_dtp.Size = new System.Drawing.Size(166, 21);
            this.timefrom_dtp.TabIndex = 100;
            // 
            // timefrom_lbl
            // 
            this.timefrom_lbl.AutoSize = true;
            this.timefrom_lbl.ControlId = null;
            this.timefrom_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.timefrom_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timefrom_lbl.Location = new System.Drawing.Point(9, 153);
            this.timefrom_lbl.Name = "timefrom_lbl";
            this.timefrom_lbl.Size = new System.Drawing.Size(70, 15);
            this.timefrom_lbl.TabIndex = 99;
            this.timefrom_lbl.Text = "Time From:";
            // 
            // textBoxCommon1
            // 
            this.textBoxCommon1.ControlId = null;
            this.textBoxCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommon1.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.textBoxCommon1.Location = new System.Drawing.Point(504, 144);
            this.textBoxCommon1.Name = "textBoxCommon1";
            this.textBoxCommon1.Size = new System.Drawing.Size(187, 21);
            this.textBoxCommon1.TabIndex = 101;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 466);
            this.Controls.Add(this.textBoxCommon1);
            this.Controls.Add(this.timeto_dtp);
            this.Controls.Add(this.timeto_lbl);
            this.Controls.Add(this.timefrom_dtp);
            this.Controls.Add(this.timefrom_lbl);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.process_cmb);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.line_cmb);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.model_cmb);
            this.Controls.Add(this.production_controller_dgv);
            this.Controls.Add(this.model_lbl);
            this.Name = "TestForm";
            this.Text = "Test";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.production_controller_dgv, 0);
            this.Controls.SetChildIndex(this.model_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.line_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.process_cmb, 0);
            this.Controls.SetChildIndex(this.search_btn, 0);
            this.Controls.SetChildIndex(this.timefrom_lbl, 0);
            this.Controls.SetChildIndex(this.timefrom_dtp, 0);
            this.Controls.SetChildIndex(this.timeto_lbl, 0);
            this.Controls.SetChildIndex(this.timeto_dtp, 0);
            this.Controls.SetChildIndex(this.textBoxCommon1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.production_controller_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.LabelCommon model_lbl;
        internal Framework.DataGridViewCommon production_controller_dgv;
        private Framework.ComboBoxCommon model_cmb;
        private Framework.ComboBoxCommon line_cmb;
        private Framework.LabelCommon labelCommon1;
        private Framework.ComboBoxCommon process_cmb;
        private Framework.LabelCommon labelCommon2;
        private Framework.ButtonCommon search_btn;
        private Framework.DateTimePickerCommon timeto_dtp;
        private Framework.LabelCommon timeto_lbl;
        private Framework.DateTimePickerCommon timefrom_dtp;
        private Framework.LabelCommon timefrom_lbl;
        private Framework.TextBoxCommon textBoxCommon1;
    }
}