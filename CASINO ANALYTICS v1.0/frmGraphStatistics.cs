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
    public partial class frmGraphStatistics : Form
    {
        List<Data> dataList = new List<Data>();
        private string tableName;
        private string dmy;
        private string date;
        private int day, month, year;

        public frmGraphStatistics(string pushedTableName, string pushedDmy, List<Data> pushedDataList, string pushedDate)
        {
            InitializeComponent();
            tableName = pushedTableName;
            dmy = pushedDmy;
            dataList = pushedDataList;
            date = pushedDate;
        }
       

        private void frmGraphStatistics_Load(object sender, EventArgs e)
        {
            
            label2.Text = tableName;
            label4.Text = date;
            string[] splitedDate = date.Split('.');
            this.chart1.Series["Drop"].BorderWidth = 3;
            this.chart1.Series["Result"].BorderWidth = 3;
            if (dmy =="daily")
            {
                day =Int32.Parse(splitedDate[0]);
                month =Int32.Parse(splitedDate[1]);
                year =Int32.Parse(splitedDate[2]);

                foreach (Data item in dataList)
                {
                    if (item.tableName == tableName && item.day == day && item.month == month && item.year == year)
                    {
                        this.chart1.Series["Drop"].Points.AddXY(item.fromH.ToString()+"-"+item.toH.ToString(), item.drop);
                        this.chart1.Series["Result"].Points.AddXY(item.fromH.ToString() + "-" + item.toH.ToString(), item.result);
                    }
                }
            }

            if (dmy == "monthly")
            {
                month = Int32.Parse(splitedDate[0]);
                year = Int32.Parse(splitedDate[1]);

                foreach (Data item in dataList)
                {
                    if (item.tableName == tableName && item.month == month && item.year == year)
                    {
                        this.chart1.Series["Drop"].Points.AddXY(item.day.ToString(), item.drop);
                        this.chart1.Series["Result"].Points.AddXY(item.day.ToString(), item.result);
                    }
                }
            }

            if (dmy == "yearly")
            {
                year = Int32.Parse(splitedDate[0]);

                foreach (Data item in dataList)
                {
                    if (item.tableName == tableName && item.year == year)
                    {
                        this.chart1.Series["Drop"].Points.AddXY(item.month.ToString(), item.drop);
                        this.chart1.Series["Drop"].Points.AddXY(item.month.ToString(), item.result);
                    }
                }
            }
            
        }
    }
}
