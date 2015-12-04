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

            tableArray = new string[listaStolova.Count];

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
            
            if (string.IsNullOrEmpty(tbFromH.Text) || string.IsNullOrEmpty(tbToH.Text) || cbDay.Text.Equals("All days"))
            {
                MessageBox.Show("Please enter all the values needed.","Information");
                return;
            }
            
            for(int i=0; i<lbTables.CheckedItems.Count; i++)
            {
                tableArray[i] = lbTables.CheckedItems[i].ToString();
            }

            string day = cbDay.Text;
            string past = cbPast.Text;
            int from = int.Parse(tbFromH.Text);
            int to = int.Parse(tbToH.Text);
            int count = 0;
            double totalDrop = 0;
            double totalResult = 0;
            int totalHc = 0;
            foreach(Data d in dataList)
            {
                if (tableArray.Contains(d.tableName) && new DateTime(d.year, d.month, d.day).DayOfWeek.ToString() == day)
                {
                    //correct table and day of the week, check time
                    DateTime dtFrom = new DateTime(d.year, d.month, d.day, d.fromH, 0, 0);
                    DateTime dtTo = new DateTime(d.year, d.month, d.day, d.toH, 0, 0);
                    if (dtFrom.Hour >= from && dtTo.Hour <= to)
                    {
                        totalDrop += d.drop;
                        totalResult += d.result;
                        totalHc += d.headcount;
                        count++;
                    }
                }
            }
            tbTotalDrop.Text = totalDrop.ToString();
            tbTotalResult.Text = totalResult.ToString();
            tbTotalHc.Text = totalHc.ToString();

            //average
            if (count == 0)
                return;
            tbAvgDrop.Text = (totalDrop / count).ToString();
            tbAvgResult.Text = (totalResult / count).ToString();
            tbAvgHc.Text = (totalHc / count).ToString();
            
        }
    }
}
