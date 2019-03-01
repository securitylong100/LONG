namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBarcode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.txtBrowser = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.btnBrowser = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.dgvNoise = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.lblThurst = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.lblNoise = new Com.Nidec.Mes.Framework.LabelCommon();
            this.groupBoxCommon3 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.groupBoxCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoise)).BeginInit();
            this.groupBoxCommon2.SuspendLayout();
            this.groupBoxCommon3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.ControlId = null;
            this.txtBarcode.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtBarcode.Location = new System.Drawing.Point(132, 27);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(212, 47);
            this.txtBarcode.TabIndex = 2;
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.lbl);
            this.groupBoxCommon1.Controls.Add(this.txtBarcode);
            this.groupBoxCommon1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(0, 107);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(460, 101);
            this.groupBoxCommon1.TabIndex = 4;
            this.groupBoxCommon1.TabStop = false;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ControlId = null;
            this.lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(44, 47);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(72, 18);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Barcode:";
            // 
            // txtBrowser
            // 
            this.txtBrowser.ControlId = null;
            this.txtBrowser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrowser.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtBrowser.Location = new System.Drawing.Point(137, 24);
            this.txtBrowser.Name = "txtBrowser";
            this.txtBrowser.Size = new System.Drawing.Size(231, 21);
            this.txtBrowser.TabIndex = 6;
            // 
            // btnBrowser
            // 
            this.btnBrowser.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowser.ControlId = null;
            this.btnBrowser.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBrowser.Location = new System.Drawing.Point(33, 21);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(74, 27);
            this.btnBrowser.TabIndex = 5;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = false;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // dgvNoise
            // 
            this.dgvNoise.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoise.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNoise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoise.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNoise.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNoise.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNoise.Location = new System.Drawing.Point(0, 340);
            this.dgvNoise.Name = "dgvNoise";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoise.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNoise.RowHeadersVisible = false;
            this.dgvNoise.Size = new System.Drawing.Size(460, 116);
            this.dgvNoise.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.lblThurst);
            this.groupBoxCommon2.Controls.Add(this.labelCommon4);
            this.groupBoxCommon2.Controls.Add(this.labelCommon3);
            this.groupBoxCommon2.Controls.Add(this.lblNoise);
            this.groupBoxCommon2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon2.Location = new System.Drawing.Point(0, 208);
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.Size = new System.Drawing.Size(460, 63);
            this.groupBoxCommon2.TabIndex = 7;
            this.groupBoxCommon2.TabStop = false;
            // 
            // lblThurst
            // 
            this.lblThurst.AutoSize = true;
            this.lblThurst.ControlId = null;
            this.lblThurst.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThurst.Location = new System.Drawing.Point(316, 16);
            this.lblThurst.Name = "lblThurst";
            this.lblThurst.Size = new System.Drawing.Size(0, 40);
            this.lblThurst.TabIndex = 7;
            // 
            // labelCommon4
            // 
            this.labelCommon4.AutoSize = true;
            this.labelCommon4.ControlId = null;
            this.labelCommon4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon4.Location = new System.Drawing.Point(232, 17);
            this.labelCommon4.Name = "labelCommon4";
            this.labelCommon4.Size = new System.Drawing.Size(83, 15);
            this.labelCommon4.TabIndex = 6;
            this.labelCommon4.Text = "Thurst Check:";
            // 
            // labelCommon3
            // 
            this.labelCommon3.AutoSize = true;
            this.labelCommon3.ControlId = null;
            this.labelCommon3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon3.Location = new System.Drawing.Point(6, 16);
            this.labelCommon3.Name = "labelCommon3";
            this.labelCommon3.Size = new System.Drawing.Size(81, 15);
            this.labelCommon3.TabIndex = 5;
            this.labelCommon3.Text = "Noise Check:";
            // 
            // lblNoise
            // 
            this.lblNoise.AutoSize = true;
            this.lblNoise.ControlId = null;
            this.lblNoise.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoise.Location = new System.Drawing.Point(90, 16);
            this.lblNoise.Name = "lblNoise";
            this.lblNoise.Size = new System.Drawing.Size(0, 40);
            this.lblNoise.TabIndex = 0;
            // 
            // groupBoxCommon3
            // 
            this.groupBoxCommon3.ControlId = null;
            this.groupBoxCommon3.Controls.Add(this.btnBrowser);
            this.groupBoxCommon3.Controls.Add(this.txtBrowser);
            this.groupBoxCommon3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxCommon3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon3.Location = new System.Drawing.Point(0, 277);
            this.groupBoxCommon3.Name = "groupBoxCommon3";
            this.groupBoxCommon3.Size = new System.Drawing.Size(460, 63);
            this.groupBoxCommon3.TabIndex = 8;
            this.groupBoxCommon3.TabStop = false;
            // 
            // NoiseCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 456);
            this.Controls.Add(this.groupBoxCommon3);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.dgvNoise);
            this.Controls.Add(this.groupBoxCommon1);
            this.Name = "NoiseCheckForm";
            this.Text = "Noise Check";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.NoiseCheckForm_Load);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.dgvNoise, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon2, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon3, 0);
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoise)).EndInit();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon2.PerformLayout();
            this.groupBoxCommon3.ResumeLayout(false);
            this.groupBoxCommon3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.TextBoxCommon txtBarcode;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.TextBoxCommon txtBrowser;
        private Framework.ButtonCommon btnBrowser;
        private Framework.LabelCommon lbl;
        private Framework.DataGridViewCommon dgvNoise;
        private System.Windows.Forms.Timer timer1;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.GroupBoxCommon groupBoxCommon3;
        private Framework.LabelCommon lblThurst;
        private Framework.LabelCommon labelCommon4;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon lblNoise;
    }
}