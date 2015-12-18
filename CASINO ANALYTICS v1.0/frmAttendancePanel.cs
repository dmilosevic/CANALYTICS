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
    public partial class frmAttendancePanel : Form
    {
        public frmAttendancePanel()
        {
            InitializeComponent();
        }

        List<Attendance> attendanceList;
        List<Attendance> specificQueryAttendanceList;

        private List<Attendance> getStatsForYear(int y)
        {
            List<Attendance> ret = new List<Attendance>();
            foreach (Attendance item in attendanceList)
            {
                if (item.Year == y) ret.Add(item);
            }
            return ret;
        }

        private List<Attendance> getStatsForMonth(int y,int m)
        {
            List<Attendance> ret = new List<Attendance>();
            foreach (Attendance item in attendanceList)
            {
                if (item.Year == y && item.Month == m) ret.Add(item);
            }
            return ret;
        }

        private List<Attendance> getStatsForDay(int y, int m, int d)
        {
            List<Attendance> ret = new List<Attendance>();
            foreach (Attendance item in attendanceList)
            {
                if (item.Year == y && item.Month == m && item.Day == d) ret.Add(item);
            }
            return ret;
        }

        private void btnAddAttendance_Click(object sender, EventArgs e)
        {
            frmAttendance fa = new frmAttendance();
            fa.ShowDialog();
        }

        private void resetAll()
        {
            cbDayDaily.Text = cbMonthDaily.Text = tbYearDaily.Text = "";
            cbMonthMonthly.Text = tbYearMonthly.Text = "";
            tbYearAnnual.Text = "";

            cbDayDaily.Enabled = true;
            cbMonthDaily.Enabled = true;
            tbYearDaily.Enabled = true;
            cbMonthMonthly.Enabled = true;
            tbYearMonthly.Enabled = true;
            tbYearAnnual.Enabled = true;

        }

        private void frmAttendancePanel_Load(object sender, EventArgs e)
        {
            rbDaily.Checked = true;
            DbConnect conn = new DbConnect();
            conn.openConnection();
            attendanceList = conn.getAllAttendances();
            conn.closeConnection();

            DataGridViewColumn c0 = dataGridView1.Columns[0];
            DataGridViewColumn c1 = dataGridView1.Columns[1];
            DataGridViewColumn c2 = dataGridView1.Columns[2];
            DataGridViewColumn c3 = dataGridView1.Columns[3];

            c0.Width = c1.Width = c2.Width = c3.Width = 122;
        }

        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            resetAll();
            if (rbDaily.Checked)
            {
                cbDayDaily.Text = DateTime.Today.Day.ToString();
                cbMonthDaily.Text = DateTime.Today.Month.ToString();
                tbYearDaily.Text = DateTime.Today.Year.ToString();

                cbMonthMonthly.Enabled = false;
                tbYearMonthly.Enabled = false;
                tbYearAnnual.Enabled = false;
            }
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            resetAll();
            if (rbMonthly.Checked)
            {
                cbDayDaily.Enabled = cbMonthDaily.Enabled = tbYearDaily.Enabled = false;
                tbYearAnnual.Enabled = false;
            }
        }

        private void rbAnnual_CheckedChanged(object sender, EventArgs e)
        {
            resetAll();
            if (rbAnnual.Checked)
            {
                cbDayDaily.Enabled = cbMonthDaily.Enabled = tbYearDaily.Enabled = false;
                cbMonthMonthly.Enabled = tbYearMonthly.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbDaily.Checked)
            {
                if (cbDayDaily.Text == "" || cbMonthDaily.Text == "" || tbYearDaily.Text == "")
                {
                    MessageBox.Show("Enter all the values needed", "Error");
                    return;
                }
                specificQueryAttendanceList = getStatsForDay(int.Parse(tbYearDaily.Text), int.Parse(cbMonthDaily.Text), int.Parse(cbDayDaily.Text));
            }
            else if (rbMonthly.Checked)
            {
                if (cbMonthMonthly.Text == "" || tbYearMonthly.Text == "")
                {
                    MessageBox.Show("Enter all the values needed", "Error");
                    return;
                }
                specificQueryAttendanceList = getStatsForMonth(int.Parse(tbYearMonthly.Text), int.Parse(cbMonthMonthly.Text));
            }
            else if (rbAnnual.Checked)
            {
                if (tbYearAnnual.Text == "")
                {
                    MessageBox.Show("Enter all the values needed", "Error");
                    return;
                }
                specificQueryAttendanceList = getStatsForYear(int.Parse(tbYearAnnual.Text));
            }

            dataGridView1.Rows.Clear();


            foreach (Attendance att in specificQueryAttendanceList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = att.Year;
                row.Cells[1].Value = att.Month;
                row.Cells[2].Value = att.Day;
                row.Cells[3].Value = att.Attendace;


                dataGridView1.Rows.Add(row);
            }

        }
    }
}
