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
    public partial class frmDeleteCheck : Form
    {
        public frmDeleteCheck()
        {
            InitializeComponent();
        }
        BindingSource bs;

        private void frmDeleteCheck_Load(object sender, EventArgs e)
        {
            DbConnect conn = new DbConnect();
            conn.openConnection();
            bs = conn.getDataByDate(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day));
            conn.closeConnection();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bs;

            DataGridViewColumn c0 = dataGridView1.Columns[0];
            DataGridViewColumn c1 = dataGridView1.Columns[1];
            DataGridViewColumn c2 = dataGridView1.Columns[2];
            DataGridViewColumn c3 = dataGridView1.Columns[3];
            DataGridViewColumn c4 = dataGridView1.Columns[4];
            DataGridViewColumn c5 = dataGridView1.Columns[5];
            DataGridViewColumn c6 = dataGridView1.Columns[6];
            DataGridViewColumn c7 = dataGridView1.Columns[7];
            DataGridViewColumn c8 = dataGridView1.Columns[8];
            DataGridViewColumn c9 = dataGridView1.Columns[9];

            c1.Width = c2.Width = c3.Width = c4.Width = c5.Width = c6.Width = c7.Width = c8.Width = c9.Width = 66;

                     
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cbDayDaily.Text == "" || cbMonthDaily.Text == "" || tbYearDaily.Text == "")
            {
                MessageBox.Show("Please choose date to display data", "Incomplete date");
                return;
            }
            int year = int.Parse(tbYearDaily.Text);
            int month = int.Parse(cbMonthDaily.Text);
            int day = int.Parse(cbDayDaily.Text);

            DbConnect conn = new DbConnect();
            conn.openConnection();
            bs = conn.getDataByDate(new DateTime(year, month, day));
            conn.closeConnection();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bs;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;

            string tableName = dataGridView1.Rows[index].Cells[0].Value.ToString();
            int year = int.Parse(dataGridView1.Rows[index].Cells[1].Value.ToString());
            int month = int.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
            int day = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
            int from = int.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString());
            int to = int.Parse(dataGridView1.Rows[index].Cells[5].Value.ToString());
            int drop = int.Parse(dataGridView1.Rows[index].Cells[6].Value.ToString());
            int result = int.Parse(dataGridView1.Rows[index].Cells[7].Value.ToString());
            int hc = int.Parse(dataGridView1.Rows[index].Cells[8].Value.ToString());
            string user = dataGridView1.Rows[index].Cells[9].Value.ToString();

            Data dt = new Data(user, tableName, year, month, day, from, to, drop, result, hc);

            DbConnect conn = new DbConnect();
            conn.openConnection();
            if (MessageBox.Show("Are you sure you want to delete this entry?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conn.deleteRow(dt);
                dataGridView1.Rows.RemoveAt(index);
            }
            else return;
            conn.closeConnection();

            

        }
    }
}
