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
        DateTime from;
        DateTime to;
        string day;

        public frmGraphHourly(List<Data> pushedDataList, string[] pushedTableArray, DateTime pushedFrom, DateTime pushedTo,string pushedDay)
        {
            InitializeComponent();
            dataList = pushedDataList;
            tableArray = pushedTableArray;
            from = pushedFrom;
            to = pushedTo;
            day = pushedDay;
        }

        private void frmGraphHourly_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            for (int i = 0; i < tableArray.Length; i++)
            {
                label2.Text += tableArray[i] + " ; ";
            }
            label3.Text = from.ToString() + " - " + to.ToString();
            label4.Text = day;

            //continue in the morning

        }
    }
}
