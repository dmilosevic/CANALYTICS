﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CASINO_ANALYTICS_v1._0
{
    public partial class frmAttendancePanel : Form
    {
        public frmAttendancePanel()
        {
            InitializeComponent();
        }

        private void btnAddAttendance_Click(object sender, EventArgs e)
        {
            frmAttendance fa = new frmAttendance();
            fa.ShowDialog();
        }
    }
}
