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
    public partial class frmEditTable : Form
    {
        private string name;
        public frmEditTable(string name)
        {
            InitializeComponent();
            this.name = name;
            label2.Text += string.Format(" '{0}'", name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Table.CheckTableName(textBox1.Text))
                return;

            DbConnect conn = new DbConnect();
            Table tbl = new Table(textBox1.Text);
            

            if (conn.doesExist(tbl))
            {
                MessageBox.Show("Table with that name already exists, please enter another name", "Please try again");
                conn.closeConnection();
                return;
            }

            conn.openConnection();
            conn.editTable(tbl, name);
            conn.closeConnection();

            this.Close();
        }

        
    }
}
