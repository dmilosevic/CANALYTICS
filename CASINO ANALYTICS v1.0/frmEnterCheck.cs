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
    public partial class frmEnterCheck : Form
    {
        public frmEnterCheck()
        {
            InitializeComponent();
        }
        private string tableName;
        private string user;

        public frmEnterCheck(string table, string user)
        {
            InitializeComponent();
            this.tableName = table;
            this.user = user;
            lblTableName.Text = table;
        }

        public bool checkValues()
        {
            try
            {
                int fromparsed = Int32.Parse(tbFrom.Text);
                int toparsed = Int32.Parse(tbTo.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a time in a correct format HH", "Invalid entry");
                
                return false;
            }
            if (tbDrop.Text == "" || tbHeadcount.Text == "" || tbTo.Text == "" || tbFrom.Text == "" || tbResult.Text == "" || monthCalendar1.SelectionRange.Start.ToShortDateString() == null)
            {
                MessageBox.Show("Please enter all values and pick a date", "Invalid entry");
                return false;
            }
            return true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(!checkValues())
                return;

            //all good, insert 

            int year = monthCalendar1.SelectionStart.Year;
            int month = monthCalendar1.SelectionStart.Month;
            int day = monthCalendar1.SelectionStart.Day;

            Data newData = new Data(user, tableName, year, month, day, int.Parse(tbFrom.Text), int.Parse(tbTo.Text),
                                double.Parse(tbDrop.Text), double.Parse(tbResult.Text), int.Parse(tbHeadcount.Text));

            DbConnect conn = new DbConnect();
            conn.openConnection();
            conn.addNewData(newData);
            conn.closeConnection();

            MessageBox.Show("Successfully added!");
            this.Close();

        }
    }
}
