namespace CASINO_ANALYTICS_v1._0
{
    partial class frmHourlyStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHourlyStats));
            this.label1 = new System.Windows.Forms.Label();
            this.lbTables = new System.Windows.Forms.CheckedListBox();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.cbPast = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFromH = new System.Windows.Forms.TextBox();
            this.tbToH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbTotalDrop = new System.Windows.Forms.TextBox();
            this.tbAvgDrop = new System.Windows.Forms.TextBox();
            this.tbTotalResult = new System.Windows.Forms.TextBox();
            this.tbAvgResult = new System.Windows.Forms.TextBox();
            this.tbTotalHc = new System.Windows.Forms.TextBox();
            this.tbAvgHc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Day:";
            // 
            // lbTables
            // 
            this.lbTables.FormattingEnabled = true;
            this.lbTables.Location = new System.Drawing.Point(12, 78);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(188, 228);
            this.lbTables.TabIndex = 2;
            // 
            // cbDay
            // 
            this.cbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] {
            "All days",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbDay.Location = new System.Drawing.Point(45, 322);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(155, 23);
            this.cbDay.TabIndex = 3;
            // 
            // cbPast
            // 
            this.cbPast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPast.FormattingEnabled = true;
            this.cbPast.Items.AddRange(new object[] {
            "1 week",
            "2 weeks",
            "3 weeks",
            "1 month",
            "2 months"});
            this.cbPast.Location = new System.Drawing.Point(45, 350);
            this.cbPast.Name = "cbPast";
            this.cbPast.Size = new System.Drawing.Size(155, 23);
            this.cbPast.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Past:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "From H:";
            // 
            // tbFromH
            // 
            this.tbFromH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFromH.Location = new System.Drawing.Point(64, 378);
            this.tbFromH.Name = "tbFromH";
            this.tbFromH.Size = new System.Drawing.Size(48, 21);
            this.tbFromH.TabIndex = 7;
            // 
            // tbToH
            // 
            this.tbToH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbToH.Location = new System.Drawing.Point(152, 378);
            this.tbToH.Name = "tbToH";
            this.tbToH.Size = new System.Drawing.Size(48, 21);
            this.tbToH.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "To H:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculate.Image = global::CASINO_ANALYTICS_v1._0.Properties.Resources.rsz_1basic16;
            this.btnCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculate.Location = new System.Drawing.Point(9, 405);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(191, 30);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(180, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "HOURLY STATISTICS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(297, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "IN THAT PERIOD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(225, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "TOTAL DROP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(225, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "AVERAGE DROP:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(225, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "TOTAL RESULT:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(225, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "AVERAGE RESULT:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(225, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "TOTAL H/C:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(225, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 25);
            this.label12.TabIndex = 18;
            this.label12.Text = "AVERAGE H/C:";
            // 
            // tbTotalDrop
            // 
            this.tbTotalDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTotalDrop.Enabled = false;
            this.tbTotalDrop.Location = new System.Drawing.Point(464, 133);
            this.tbTotalDrop.Multiline = true;
            this.tbTotalDrop.Name = "tbTotalDrop";
            this.tbTotalDrop.Size = new System.Drawing.Size(135, 25);
            this.tbTotalDrop.TabIndex = 19;
            // 
            // tbAvgDrop
            // 
            this.tbAvgDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAvgDrop.Enabled = false;
            this.tbAvgDrop.Location = new System.Drawing.Point(464, 177);
            this.tbAvgDrop.Multiline = true;
            this.tbAvgDrop.Name = "tbAvgDrop";
            this.tbAvgDrop.Size = new System.Drawing.Size(135, 25);
            this.tbAvgDrop.TabIndex = 20;
            // 
            // tbTotalResult
            // 
            this.tbTotalResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTotalResult.Enabled = false;
            this.tbTotalResult.Location = new System.Drawing.Point(464, 221);
            this.tbTotalResult.Multiline = true;
            this.tbTotalResult.Name = "tbTotalResult";
            this.tbTotalResult.Size = new System.Drawing.Size(135, 25);
            this.tbTotalResult.TabIndex = 21;
            // 
            // tbAvgResult
            // 
            this.tbAvgResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAvgResult.Enabled = false;
            this.tbAvgResult.Location = new System.Drawing.Point(464, 265);
            this.tbAvgResult.Multiline = true;
            this.tbAvgResult.Name = "tbAvgResult";
            this.tbAvgResult.Size = new System.Drawing.Size(135, 25);
            this.tbAvgResult.TabIndex = 22;
            // 
            // tbTotalHc
            // 
            this.tbTotalHc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTotalHc.Enabled = false;
            this.tbTotalHc.Location = new System.Drawing.Point(464, 311);
            this.tbTotalHc.Multiline = true;
            this.tbTotalHc.Name = "tbTotalHc";
            this.tbTotalHc.Size = new System.Drawing.Size(135, 25);
            this.tbTotalHc.TabIndex = 23;
            // 
            // tbAvgHc
            // 
            this.tbAvgHc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAvgHc.Enabled = false;
            this.tbAvgHc.Location = new System.Drawing.Point(464, 353);
            this.tbAvgHc.Multiline = true;
            this.tbAvgHc.Name = "tbAvgHc";
            this.tbAvgHc.Size = new System.Drawing.Size(135, 25);
            this.tbAvgHc.TabIndex = 24;
            // 
            // frmHourlyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 450);
            this.Controls.Add(this.tbAvgHc);
            this.Controls.Add(this.tbTotalHc);
            this.Controls.Add(this.tbAvgResult);
            this.Controls.Add(this.tbTotalResult);
            this.Controls.Add(this.tbAvgDrop);
            this.Controls.Add(this.tbTotalDrop);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.tbToH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFromH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDay);
            this.Controls.Add(this.lbTables);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(627, 488);
            this.MinimumSize = new System.Drawing.Size(627, 488);
            this.Name = "frmHourlyStats";
            this.Text = "Hourly Stats";
            this.Load += new System.EventHandler(this.frmHourlyStats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox lbTables;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.ComboBox cbPast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFromH;
        private System.Windows.Forms.TextBox tbToH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbTotalDrop;
        private System.Windows.Forms.TextBox tbAvgDrop;
        private System.Windows.Forms.TextBox tbTotalResult;
        private System.Windows.Forms.TextBox tbAvgResult;
        private System.Windows.Forms.TextBox tbTotalHc;
        private System.Windows.Forms.TextBox tbAvgHc;
    }
}