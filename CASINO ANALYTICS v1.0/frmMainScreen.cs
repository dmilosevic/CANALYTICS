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
    public partial class frmMainScreen : Form
    {
        public void loadTables()
        {
            DbConnect conn = new DbConnect();
            List<Table> listaStolova = new List<Table>();

            conn.openConnection();
            listaStolova = conn.selectTables();
            lbTables.Items.Clear();

            foreach (Table item in listaStolova)
            {
                lbTables.Items.Add(item.getTableName());
            }

            conn.closeConnection();
        }

        public void showTodayStatsForThisTable(string selectedTable) //ovde u listbox selectovanju proslediti ime stola
        {
            tbTotalDrop.Text = "0";
            tbTotalHeadcount.Text = "0";
            tbTotalResult.Text = "0";
            DbConnect conn = new DbConnect();
            List<Data> dataList = new List<Data>();

            conn.openConnection();
            int dan, mesec, godina;
            dan = DateTime.Today.Day;
            mesec = DateTime.Today.Month;
            godina = DateTime.Today.Year;
            dataList = conn.getData(selectedTable,dan,mesec,godina);
            if (dataList.Count == 0)
                return;
            Data newest = dataList[0];

            foreach (Data item in dataList)
            {
                if (DbConnect.compareTime(item.fromH, newest.fromH) == 1)
                    newest = item;
            }
            tbTotalDrop.Text = newest.drop.ToString();
            tbTotalResult.Text = newest.result.ToString();
            tbTotalHeadcount.Text = newest.headcount.ToString();


            conn.closeConnection();
        }

        public frmMainScreen(string user)
        {            
            InitializeComponent();
            lblUser.Text = user;
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            frmAddTable addTable = new frmAddTable();
            addTable.ShowDialog();
        }

        private void btnEnterCheck_Click(object sender, EventArgs e)
        {
            frmEnterCheck enter = new frmEnterCheck(lblUser.Text);
            enter.ShowDialog();
        }

        private void btnAllStats_Click(object sender, EventArgs e)
        {
            frmStatistics fs = new frmStatistics();
            fs.ShowDialog();
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex < 0)
            {
                MessageBox.Show("Please select table to edit", "Error");
                return;
            }
            frmEditTable fe = new frmEditTable(lbTables.SelectedItem.ToString());
            fe.ShowDialog();
        }

        private void frmMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmMainScreen_Load(object sender, EventArgs e) // ovo pogledati da li puno vremena oduzima
        {
            lblDate.Text = (DateTime.Today.Day).ToString() + "." + (DateTime.Today.Month).ToString() + "." + (DateTime.Today.Year).ToString();

        }

        private void btnDeleteCheck_Click(object sender, EventArgs e)
        {
            frmDeleteCheck fdel = new frmDeleteCheck();
            fdel.ShowDialog();
        }

        private void frmMainScreen_Activated(object sender, EventArgs e)
        {
            loadTables();
            lblCurrentTable.Text = "Select Table";
            tbTotalDrop.Text = "0";
            tbTotalResult.Text = "0";
            tbTotalHeadcount.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadTables();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex < 0)
            {
                MessageBox.Show("Please select table to delete", "Error");
                return;
            }
            string tblName = lbTables.SelectedItem.ToString();
            if(MessageBox.Show("Are you sure you want to delete table " + tblName + "? All the data linked with that table will be permamently lost.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                DbConnect conn = new DbConnect();

                conn.openConnection();
                conn.deleteTableAndData(new Table(tblName)); //use deleteTable or deleteTableAndData
                conn.closeConnection();
                loadTables();
            }
        }

        private void lbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex < 0)
                return;

            showTodayStatsForThisTable(lbTables.SelectedItem.ToString());
            lblCurrentTable.Text = lbTables.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInstructions frins = new frmInstructions();
            frins.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAbout fa = new frmAbout();
            fa.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmHourlyStats fha = new frmHourlyStats();
            fha.ShowDialog();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            frmAttendancePanel fap = new frmAttendancePanel();
            fap.Show();
        }

    }
}
