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
    public partial class frmGraphHourly : Form
    {
        List<Data> dataList = new List<Data>();
        string[] tableArray;
        DateTime localFrom;
        DateTime localTo;
        string day;
        int fromInt;
        int toInt;

        public frmGraphHourly(List<Data> pushedDataList, string[] pushedTableArray, DateTime pushedFrom, DateTime pushedTo,string pushedDay,string pushedFromString, string pushedToString)
        {
            InitializeComponent();
            dataList = pushedDataList;
            tableArray = pushedTableArray;
            localFrom = pushedFrom;
            localTo = pushedTo;
            day = pushedDay;
            fromInt = Int32.Parse(pushedFromString);
            toInt = Int32.Parse(pushedToString);
        }

        private int compareTime(int first, int second)
        {
            int[] val = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
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

        private void frmGraphHourly_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            for (int i = 0; i < tableArray.Length; i++)
            {
                label2.Text += tableArray[i] + " ; ";
            }
            string[] splittedFromDate = localFrom.ToString().Split(' ');
            string[] splittedToDate = localTo.ToString().Split(' ');
            label3.Text = splittedFromDate[0] + " - " + splittedToDate[0];
            label4.Text = day;

            this.chart1.Series["Drop"].BorderWidth = 3;
            this.chart1.Series["Result"].BorderWidth = 3;
            this.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            foreach (Data d in dataList)
            {
                if (tableArray.Contains(d.tableName))
                {
                    if (day != "All days")
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
                        if (compareTime(d.fromH, fromInt) >= 0 && compareTime(d.toH, toInt) <= 0)
                        {
                            this.chart1.Series["Drop"].Points.AddY(d.drop);
                            this.chart1.Series["Result"].Points.AddY(d.result);
                        }
                    }
                }
            }

        }
    }
}
