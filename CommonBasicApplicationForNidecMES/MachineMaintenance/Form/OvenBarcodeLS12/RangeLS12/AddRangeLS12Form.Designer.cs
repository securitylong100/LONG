﻿namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    partial class AddRangeLS12Form
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
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.upper_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.upper_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.lower_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.lower_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.process_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon5 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon7 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.process_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.SuspendLayout();
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon1.Location = new System.Drawing.Point(218, 181);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(27, 15);
            this.labelCommon1.TabIndex = 30;
            this.labelCommon1.Text = "(＊)";
            this.labelCommon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon2.Location = new System.Drawing.Point(218, 141);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(27, 15);
            this.labelCommon2.TabIndex = 31;
            this.labelCommon2.Text = "(＊)";
            this.labelCommon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(146, 296);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 29;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Ok_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Ok_btn.Location = new System.Drawing.Point(46, 296);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(80, 33);
            this.Ok_btn.TabIndex = 28;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // upper_txt
            // 
            this.upper_txt.ControlId = null;
            this.upper_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.upper_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.upper_txt.Location = new System.Drawing.Point(89, 254);
            this.upper_txt.MaxLength = 32;
            this.upper_txt.Name = "upper_txt";
            this.upper_txt.Size = new System.Drawing.Size(123, 21);
            this.upper_txt.TabIndex = 27;
            // 
            // upper_lbl
            // 
            this.upper_lbl.AutoSize = true;
            this.upper_lbl.ControlId = null;
            this.upper_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.upper_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.upper_lbl.Location = new System.Drawing.Point(33, 256);
            this.upper_lbl.Name = "upper_lbl";
            this.upper_lbl.Size = new System.Drawing.Size(50, 15);
            this.upper_lbl.TabIndex = 26;
            this.upper_lbl.Text = "t⁰ Upper";
            // 
            // lower_txt
            // 
            this.lower_txt.ControlId = null;
            this.lower_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.lower_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.lower_txt.Location = new System.Drawing.Point(89, 217);
            this.lower_txt.MaxLength = 32;
            this.lower_txt.Name = "lower_txt";
            this.lower_txt.Size = new System.Drawing.Size(123, 21);
            this.lower_txt.TabIndex = 25;
            // 
            // lower_lbl
            // 
            this.lower_lbl.AutoSize = true;
            this.lower_lbl.ControlId = null;
            this.lower_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.lower_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lower_lbl.Location = new System.Drawing.Point(33, 220);
            this.lower_lbl.Name = "lower_lbl";
            this.lower_lbl.Size = new System.Drawing.Size(50, 15);
            this.lower_lbl.TabIndex = 24;
            this.lower_lbl.Text = "t⁰ Lower";
            // 
            // model_lbl
            // 
            this.model_lbl.AutoSize = true;
            this.model_lbl.ControlId = null;
            this.model_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.model_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.model_lbl.Location = new System.Drawing.Point(43, 141);
            this.model_lbl.Name = "model_lbl";
            this.model_lbl.Size = new System.Drawing.Size(40, 15);
            this.model_lbl.TabIndex = 81;
            this.model_lbl.Text = "Model";
            // 
            // process_lbl
            // 
            this.process_lbl.AutoSize = true;
            this.process_lbl.ControlId = null;
            this.process_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.process_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.process_lbl.Location = new System.Drawing.Point(32, 181);
            this.process_lbl.Name = "process_lbl";
            this.process_lbl.Size = new System.Drawing.Size(53, 15);
            this.process_lbl.TabIndex = 85;
            this.process_lbl.Text = "Process";
            // 
            // labelCommon5
            // 
            this.labelCommon5.AutoSize = true;
            this.labelCommon5.ControlId = null;
            this.labelCommon5.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon5.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon5.Location = new System.Drawing.Point(218, 220);
            this.labelCommon5.Name = "labelCommon5";
            this.labelCommon5.Size = new System.Drawing.Size(27, 15);
            this.labelCommon5.TabIndex = 87;
            this.labelCommon5.Text = "(＊)";
            this.labelCommon5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCommon7
            // 
            this.labelCommon7.AutoSize = true;
            this.labelCommon7.ControlId = null;
            this.labelCommon7.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon7.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon7.Location = new System.Drawing.Point(218, 256);
            this.labelCommon7.Name = "labelCommon7";
            this.labelCommon7.Size = new System.Drawing.Size(27, 15);
            this.labelCommon7.TabIndex = 89;
            this.labelCommon7.Text = "(＊)";
            this.labelCommon7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_cbm
            // 
            this.model_cbm.ControlId = null;
            this.model_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.model_cbm.FormattingEnabled = true;
            this.model_cbm.Location = new System.Drawing.Point(89, 138);
            this.model_cbm.Name = "model_cbm";
            this.model_cbm.Size = new System.Drawing.Size(123, 23);
            this.model_cbm.TabIndex = 93;
            this.model_cbm.SelectedIndexChanged += new System.EventHandler(this.model_cbm_SelectedIndexChanged);
            // 
            // process_cbm
            // 
            this.process_cbm.ControlId = null;
            this.process_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.process_cbm.FormattingEnabled = true;
            this.process_cbm.Location = new System.Drawing.Point(89, 178);
            this.process_cbm.Name = "process_cbm";
            this.process_cbm.Size = new System.Drawing.Size(123, 23);
            this.process_cbm.TabIndex = 94;
            this.process_cbm.SelectedIndexChanged += new System.EventHandler(this.line_cbm_SelectedIndexChanged);
            // 
            // AddRangeLS12Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(271, 341);
            this.Controls.Add(this.process_cbm);
            this.Controls.Add(this.model_cbm);
            this.Controls.Add(this.labelCommon7);
            this.Controls.Add(this.labelCommon5);
            this.Controls.Add(this.process_lbl);
            this.Controls.Add(this.model_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.upper_txt);
            this.Controls.Add(this.upper_lbl);
            this.Controls.Add(this.lower_txt);
            this.Controls.Add(this.lower_lbl);
            this.Name = "AddRangeLS12Form";
            this.Text = "Temp Range";
            this.TitleText = "Add Temp Range";
            this.Load += new System.EventHandler(this.AddRankForm_Load);
            this.Controls.SetChildIndex(this.lower_lbl, 0);
            this.Controls.SetChildIndex(this.lower_txt, 0);
            this.Controls.SetChildIndex(this.upper_lbl, 0);
            this.Controls.SetChildIndex(this.upper_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.process_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon5, 0);
            this.Controls.SetChildIndex(this.labelCommon7, 0);
            this.Controls.SetChildIndex(this.model_cbm, 0);
            this.Controls.SetChildIndex(this.process_cbm, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        private Framework.TextBoxCommon upper_txt;
        private Framework.LabelCommon upper_lbl;
        private Framework.TextBoxCommon lower_txt;
        private Framework.LabelCommon lower_lbl;
        private Framework.LabelCommon model_lbl;
        private Framework.LabelCommon process_lbl;
        private Framework.LabelCommon labelCommon5;
        private Framework.LabelCommon labelCommon7;
        private Framework.ComboBoxCommon model_cbm;
        private Framework.ComboBoxCommon process_cbm;
    }
}
