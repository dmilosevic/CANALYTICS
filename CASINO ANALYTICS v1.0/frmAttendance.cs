using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CASINO_ANALYTICS_v1._0
{
    public partial class frmAttendance : Form
    {
        public frmAttendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnect conn = new DbConnect();
            int year = monthCalendar1.SelectionStart.Year;
            int month = monthCalendar1.SelectionStart.Month;
            int day = monthCalendar1.SelectionStart.Day;

            Attendance newAttendance = new Attendance(year, month, day, int.Parse(textBox1.Text));

            conn.openConnection();
            conn.addNewAttendance(newAttendance);
            conn.closeConnection();
            if (MessageBox.Show("Succesfully added new attendance", "Sucess!") == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
