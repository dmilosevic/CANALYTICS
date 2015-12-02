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
    public partial class frmHourlyStats : Form
    {
        public frmHourlyStats()
        {
            InitializeComponent();
        }
        List<Data> dataList;
        string[] tableArray;
        private void frmHourlyStats_Load(object sender, EventArgs e)
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

            dataList = conn.getAllData();
            conn.closeConnection();

            tbTotalDrop.Text = "0";
            tbAvgDrop.Text = "0";
            tbTotalResult.Text = "0";
            tbAvgResult.Text = "0";
            tbTotalHc.Text = "0";
            tbAvgHc.Text = "0";
            cbDay.Text = "All days";
            cbPast.Text = "1 week";

        }
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(tbFromH.Text) || string.IsNullOrEmpty(tbToH.Text))
            {
                MessageBox.Show("Please enter all the values needed.","Information");
                return;
            }
            for (int i = 0; i < lbTables.Items.Count; i++)
			{
                if (lbTables.GetItemChecked(i))
                {
                    tableArray[i] = lbTables.CheckedItems[i].ToString();
                    MessageBox.Show(tableArray[i]);
                }
			}
            */
        }
    }
}
