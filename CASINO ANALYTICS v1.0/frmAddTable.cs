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
    public partial class frmAddTable : Form
    {

        public frmAddTable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnect conn = new DbConnect();
            List<Table> list = new List<Table>();

            if (!Table.CheckTableName(tbTableName.Text))
                return;

            Table newTable = new Table(tbTableName.Text);

            if(conn.doesExist(newTable))
            {
                MessageBox.Show("Table with that name already exists, please enter another name", "Please try again");             
                return;
            }

            conn.openConnection();
            conn.addNewTable(newTable);
            conn.closeConnection();
            if (MessageBox.Show("Succesfully created table "+newTable.getTableName()+"!","Sucess!")==DialogResult.OK)
            {                
                this.Close();
            }
            
           
        }
    }
}
