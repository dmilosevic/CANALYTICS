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
    public partial class frmInstructions : Form
    {
        public frmInstructions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text = "On the left table panel, table options etc... On the right showing statistics for this day for specific selected table (table must be selected)! ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text = "Options: \n ADDING NEW TABLE \n EDITING EXISTING TABLE \n DELETING SPECIFIC TABLE \n\n Refresh button - refreshes table list if needed to";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text = "ENTER CHECK: \n Enters a new entry for specific table, date,time,drop,result and hc. \n\n DELETE CHECK:\nDeletes specific entry , first shows all entries for today, you can search entries you wish to delete.";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text = "For selected table in the list box you need to select the statistic view you want to see.\n\n If you want to see on daily level check daily, then enter values, same for the monthly and annual.\n\n Below the main data grid there are 3 boxes. The first box shows the entire drop/result/hc for the specific day /month/or year(it depends on what you selected) , the second shows the entire drop/result/hc for the specific table EVER. And the last shows the overall drop/result/hc for ALL tables. \n\n Save to txt option - saves file in a .txt for later use.";
        }
    }
}
