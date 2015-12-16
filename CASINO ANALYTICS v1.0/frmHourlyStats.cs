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
        List<Table> listaStolova;
        string[] tableArray;
        DateTime localFrom;
        DateTime localTo;
        string[] checkedTableArray;
        private void frmHourlyStats_Load(object sender, EventArgs e)
        {
            DbConnect conn = new DbConnect();
            listaStolova = new List<Table>();            

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

        private void setTimeSpan(int from, int to)
        {
            int todayYear = DateTime.Today.Year;
            int todayMonth = DateTime.Today.Month;
            int todayDay = DateTime.Today.Day;

            switch (cbPast.Text)
            {
                case "1 week":
                    localFrom = new DateTime(todayYear, todayMonth, todayDay).Subtract(TimeSpan.FromDays(7));
                    localTo = new DateTime(todayYear, todayMonth, todayDay);
                    break;
                case "2 weeks":
                    localFrom = new DateTime(todayYear, todayMonth, todayDay).Subtract(TimeSpan.FromDays(14));
                    localTo = new DateTime(todayYear, todayMonth, todayDay);
                    break;
                case "3 weeks":
                    localFrom = new DateTime(todayYear, todayMonth, todayDay).Subtract(TimeSpan.FromDays(21));
                    localTo = new DateTime(todayYear, todayMonth, todayDay);
                    break;
                case "1 month":
                    localFrom = new DateTime(todayYear, todayMonth, todayDay).Subtract(TimeSpan.FromDays(DateTime.DaysInMonth(todayYear, DateTime.Now.AddMonths(-1).Month)));
                    localTo = new DateTime(todayYear, todayMonth, todayDay);
                    break;
                case "2 months":
                    localFrom = new DateTime(todayYear, todayMonth, todayDay).Subtract(TimeSpan.FromDays(DateTime.DaysInMonth(todayYear, DateTime.Now.AddMonths(-2).Month)+ DateTime.DaysInMonth(todayYear, DateTime.Now.AddMonths(-1).Month)));
                    localTo = new DateTime(todayYear, todayMonth, todayDay, to, 0, 0);
                    break;
            }            
        }
        /// <summary>
        /// -1 (smaller), 0 (equal), 1(larger)
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private int compareTime(int first, int second)
        {
            int[] val = { 0, 1, 2, 3, 4, 5, 6, 7, 8};
            int[] ten = { 18, 19, 20, 21, 22, 23 };

            if (val.Contains(first) && ten.Contains(second))
                return 1;

            if (val.Contains(second) && ten.Contains(first))
                return -1;

            if (first == second) return 0;

            if (first < second) return -1;
            if (second < first) return 1;

            return 404;
        }
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            tableArray = new string[listaStolova.Count]; //initialize new (empty) array each time

            if (string.IsNullOrEmpty(tbFromH.Text) || string.IsNullOrEmpty(tbToH.Text))
            {
                MessageBox.Show("Please enter all the values needed.","Information");
                return;
            }
            int duzinaChekiranihStolova = 0;
            for(int i=0; i<lbTables.CheckedItems.Count; i++)
            {
                tableArray[i] = lbTables.CheckedItems[i].ToString();
                duzinaChekiranihStolova++;
            }

            checkedTableArray = new string[duzinaChekiranihStolova];
            for (int i = 0; i < duzinaChekiranihStolova; i++)
            {
                checkedTableArray[i] = tableArray[i];
            }
            string day = cbDay.Text;
            string past = cbPast.Text;
            int from = int.Parse(tbFromH.Text);
            int to = int.Parse(tbToH.Text);

            setTimeSpan(from, to); //important

            double dropBegin=0, dropEnd=0;
            double resultBegin = 0, resultEnd = 0;
            int hcBegin = 0, hcEnd = 0;
            int count = 0;
            double totalDrop = 0;
            double totalResult = 0;
            int totalHc = 0;
            for (int i = 0; i < dataList.Count; i++)
            {
                Data d = (Data)dataList[i];
                
                if (tableArray.Contains(d.tableName))
                {
                    if(day != "All days")
                    {
                        if (new DateTime(d.year, d.month, d.day).DayOfWeek.ToString() != day)
                            continue;
                    }
                    //correct table and day of the week, check date
                    DateTime dtFrom = new DateTime(d.year, d.month, d.day);
                    DateTime dtTo = new DateTime(d.year, d.month, d.day);

                    if (DateTime.Compare(localFrom, dtFrom) <= 0 && DateTime.Compare(localTo, dtTo) >= 0)
                    {
                        //correct date, check time
                        if (d.toH == from)
                        {   
                            dropBegin += d.drop;
                            resultBegin += d.result;
                            hcBegin += d.headcount;
                            count++;
                        }
                        if (d.toH == to)
                        {
                            dropEnd += d.drop;
                            resultEnd += d.result;
                            hcEnd += d.headcount;
                            count++;
                        }

                        
                            //totalResult += d.result;
                            //totalHc += d.headcount;
                            //count++;
                    }
                }
            }
            totalDrop = dropEnd - dropBegin;
            totalResult = resultEnd - resultBegin;
            totalHc = hcEnd - hcBegin;
            tbTotalDrop.Text = totalDrop.ToString();
            tbTotalResult.Text = totalResult.ToString();
            tbTotalHc.Text = totalHc.ToString();

            //average
            if (count == 0)
            {
                tbAvgDrop.Text = "0";
                tbAvgResult.Text = "0";
                tbAvgHc.Text = "0";
                return;
            }
            tbAvgDrop.Text = (totalDrop / count).ToString();
            tbAvgResult.Text = (totalResult / count).ToString();
            tbAvgHc.Text = (totalHc / count).ToString();
            
        }

        private void populateArray()
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tbTotalDrop.Text == "0")
            {
                MessageBox.Show("Cannot show graph for empty results, please fill in all the fields and try again.","Cannot show graph");
                return;
            }
            else
            {
                frmGraphHourly frmgh = new frmGraphHourly(dataList,checkedTableArray,localFrom,localTo,cbDay.Text,tbFromH.Text,tbToH.Text);
                frmgh.ShowDialog();
            }
        }
    }
}
