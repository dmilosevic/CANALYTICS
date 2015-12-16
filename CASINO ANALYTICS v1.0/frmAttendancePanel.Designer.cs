namespace CASINO_ANALYTICS_v1._0
{
    partial class frmAttendancePanel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbYearAnnual = new System.Windows.Forms.TextBox();
            this.tbYearMonthly = new System.Windows.Forms.TextBox();
            this.tbYearDaily = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMonthMonthly = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMonthDaily = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDayDaily = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbAnnual = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.btnAddAttendance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(532, 373);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Droid Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "ATTENDANCE PANEL STATISTICS";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::CASINO_ANALYTICS_v1._0.Properties.Resources.rsz_left225;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(292, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 40);
            this.button1.TabIndex = 75;
            this.button1.Text = "Show Statistics";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbYearAnnual
            // 
            this.tbYearAnnual.Location = new System.Drawing.Point(105, 501);
            this.tbYearAnnual.Name = "tbYearAnnual";
            this.tbYearAnnual.Size = new System.Drawing.Size(50, 21);
            this.tbYearAnnual.TabIndex = 74;
            // 
            // tbYearMonthly
            // 
            this.tbYearMonthly.Location = new System.Drawing.Point(175, 467);
            this.tbYearMonthly.Name = "tbYearMonthly";
            this.tbYearMonthly.Size = new System.Drawing.Size(50, 21);
            this.tbYearMonthly.TabIndex = 73;
            // 
            // tbYearDaily
            // 
            this.tbYearDaily.Location = new System.Drawing.Point(214, 434);
            this.tbYearDaily.Name = "tbYearDaily";
            this.tbYearDaily.Size = new System.Drawing.Size(50, 21);
            this.tbYearDaily.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 504);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 14);
            this.label8.TabIndex = 71;
            this.label8.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 14);
            this.label6.TabIndex = 70;
            this.label6.Text = "Y:";
            // 
            // cbMonthMonthly
            // 
            this.cbMonthMonthly.FormattingEnabled = true;
            this.cbMonthMonthly.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbMonthMonthly.Location = new System.Drawing.Point(108, 467);
            this.cbMonthMonthly.Name = "cbMonthMonthly";
            this.cbMonthMonthly.Size = new System.Drawing.Size(41, 22);
            this.cbMonthMonthly.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 470);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 68;
            this.label7.Text = "M:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 14);
            this.label5.TabIndex = 67;
            this.label5.Text = "Y:";
            // 
            // cbMonthDaily
            // 
            this.cbMonthDaily.FormattingEnabled = true;
            this.cbMonthDaily.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbMonthDaily.Location = new System.Drawing.Point(149, 434);
            this.cbMonthDaily.Name = "cbMonthDaily";
            this.cbMonthDaily.Size = new System.Drawing.Size(41, 22);
            this.cbMonthDaily.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 65;
            this.label4.Text = "M:";
            // 
            // cbDayDaily
            // 
            this.cbDayDaily.FormattingEnabled = true;
            this.cbDayDaily.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbDayDaily.Location = new System.Drawing.Point(88, 434);
            this.cbDayDaily.Name = "cbDayDaily";
            this.cbDayDaily.Size = new System.Drawing.Size(38, 22);
            this.cbDayDaily.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 14);
            this.label3.TabIndex = 63;
            this.label3.Text = "D:";
            // 
            // rbAnnual
            // 
            this.rbAnnual.AutoSize = true;
            this.rbAnnual.Location = new System.Drawing.Point(12, 502);
            this.rbAnnual.Name = "rbAnnual";
            this.rbAnnual.Size = new System.Drawing.Size(63, 18);
            this.rbAnnual.TabIndex = 62;
            this.rbAnnual.TabStop = true;
            this.rbAnnual.Text = "Annual";
            this.rbAnnual.UseVisualStyleBackColor = true;
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(12, 468);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(69, 18);
            this.rbMonthly.TabIndex = 61;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Location = new System.Drawing.Point(12, 435);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(51, 18);
            this.rbDaily.TabIndex = 60;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            // 
            // btnAddAttendance
            // 
            this.btnAddAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAttendance.Image = global::CASINO_ANALYTICS_v1._0.Properties.Resources.rsz_round77;
            this.btnAddAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAttendance.Location = new System.Drawing.Point(292, 470);
            this.btnAddAttendance.Name = "btnAddAttendance";
            this.btnAddAttendance.Size = new System.Drawing.Size(252, 40);
            this.btnAddAttendance.TabIndex = 76;
            this.btnAddAttendance.Text = "Add Attendance";
            this.btnAddAttendance.UseVisualStyleBackColor = true;
            this.btnAddAttendance.Click += new System.EventHandler(this.btnAddAttendance_Click);
            // 
            // frmAttendancePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 531);
            this.Controls.Add(this.btnAddAttendance);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbYearAnnual);
            this.Controls.Add(this.tbYearMonthly);
            this.Controls.Add(this.tbYearDaily);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbMonthMonthly);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbMonthDaily);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDayDaily);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbAnnual);
            this.Controls.Add(this.rbMonthly);
            this.Controls.Add(this.rbDaily);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Droid Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAttendancePanel";
            this.Text = "frmAttendancePanel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbYearAnnual;
        private System.Windows.Forms.TextBox tbYearMonthly;
        private System.Windows.Forms.TextBox tbYearDaily;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMonthMonthly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMonthDaily;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDayDaily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbAnnual;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.Button btnAddAttendance;
    }
}