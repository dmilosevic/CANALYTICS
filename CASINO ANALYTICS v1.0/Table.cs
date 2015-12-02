using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CASINO_ANALYTICS_v1._0
{
    class Table
    {
        private string tableName;

        public Table() { }

        public Table(string tname) 
        {
            this.tableName = tname;
        }

        public string getTableName()
        {
            return tableName;
        }

        public static bool CheckTableName(string name)
        {
            if (name == "" || name.Contains(" "))
            {
                MessageBox.Show("Table name is invalid, please enter a new table name\n (Table name cannot be blank nor contain spaces)", "Please try again");
                return false;
            }

            if (name.Length > 20)
            {
                MessageBox.Show("Table name should be 20 characters or less, please enter a valid table name", "Please try again");
                return false;
            }
            return true;
        }
    }
}
