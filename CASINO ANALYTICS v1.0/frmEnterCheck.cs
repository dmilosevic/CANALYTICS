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
        private string[] checkedTableArray;
        private string user;

        public frmEnterCheck(string user)
        {
            InitializeComponent();
            this.user = user;
        }
        public void nullAllFields()
        {
            tbDrop.Clear();
            tbFrom.Clear();
            tbHeadcount.Clear();
            tbResult.Clear();
            tbTo.Clear();
            foreach (int i in lbTables.CheckedIndices)
            {
                lbTables.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

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
            checkedTableArray = new string[lbTables.CheckedItems.Count];
            for (int i = 0; i < lbTables.CheckedItems.Count; i++)
            {
                checkedTableArray[i] = lbTables.CheckedItems[i].ToString();
            }
            DbConnect conn = new DbConnect();
            conn.openConnection();
            for (int i = 0; i < checkedTableArray.Length; i++)
            {
                tableName = checkedTableArray[i];
                try {
                    Data newData = new Data(user, tableName, year, month, day, int.Parse(tbFrom.Text), int.Parse(tbTo.Text),
                                        double.Parse(tbDrop.Text), double.Parse(tbResult.Text), int.Parse(tbHeadcount.Text));

                    conn.addNewData(newData);
                }        

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Successfully added!");
            conn.closeConnection();
            nullAllFields();

        }

        private void frmEnterCheck_Load(object sender, EventArgs e)
        {
            loadTables();
        }
    }
}
