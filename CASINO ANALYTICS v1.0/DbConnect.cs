using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace CASINO_ANALYTICS_v1._0
{
    class DbConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;
        private string connectionString;


        public DbConnect()
        {
            Initialize();            
        }

        private void Initialize()
        {
            server = "thenamespace.com";
            database = "thenames_dbCasino";
            username = "thenames_root";
            password = "Jacoby10";
            connectionString = "SERVER=" + server + "; DATABASE=" + database +
                                "; UID=" + username + "; PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("Could not connect to server", "Error: " + ex.Number); break;

                    case 1045:
                        System.Windows.Forms.MessageBox.Show("Invalid Username/Password"); break;
                    default:
                        System.Windows.Forms.MessageBox.Show("Could not connect to server", "Error: " + ex.Number); break;
                }
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
        //---------------USERS----------------

        public List<User> selectUsers()
        {
            List<User> ls = new List<User>();
            string query = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while(dataReader.Read())
            {
                User u = new User(dataReader["Username"].ToString(), dataReader["Password"].ToString());
                ls.Add(u);                
            }

            dataReader.Close();
            return ls;
        }

        public void addNewUser(User usr)
        {
            string query = string.Format("INSERT INTO users (Username, Password) VALUES('{0}', '{1}')", usr.getUsername(), usr.getPassword());
            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.ExecuteNonQuery();

        }

        //-----------------TABLES------------------
        public List<Table> selectTables()
        {
            List<Table> ltable = new List<Table>();
            string query = "SELECT * from tables";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Table tb = new Table(dataReader["TableName"].ToString());
                ltable.Add(tb);
            }

            dataReader.Close();
            return ltable;
        }

        public void addNewTable(Table tbl)
        {
            string query = string.Format("INSERT INTO tables (TableName) VALUES('{0}')", tbl.getTableName());
            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void editTable(Table tbl, string oldName)
        {
            string query = string.Format("UPDATE tables SET TableName='{0}' WHERE TableName='{1}'", tbl.getTableName(), oldName);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void deleteTable(Table tbl)
        {
            string query = string.Format("DELETE  FROM tables WHERE TableName='{0}'", tbl.getTableName());
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void deleteTableAndData(Table tbl)
        {
            string query = string.Format("DELETE FROM tables WHERE TableName='{0}'", tbl.getTableName());
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = string.Format("DELETE FROM data WHERE TableName='{0}'", tbl.getTableName());
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        //------------------------DATA---------------------
        public List<Data> getData(string selectedTable, int dan, int mesec, int godina) //napraviti jos jednu metodu samo za jedan parametar TABLE, to ce trebati za statistiku
        {
            List<Data> ldata = new List<Data>();
            string query = string.Format("SELECT * FROM data WHERE Tablename='{0}' AND Year='{1}' AND Month='{2}' AND Day='{3}'",selectedTable,godina,mesec,dan);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                string user = dataReader["User"].ToString();
                string tablename = dataReader["TableName"].ToString();
                int year = Int32.Parse(dataReader["Year"].ToString());
                int month = Int32.Parse(dataReader["Month"].ToString());
                int day = Int32.Parse(dataReader["Day"].ToString());
                int fromH = Int32.Parse(dataReader["fromH"].ToString());
                int toH = Int32.Parse(dataReader["toH"].ToString());
                double drop = Double.Parse(dataReader["DropF"].ToString());
                double result = Double.Parse(dataReader["Result"].ToString());
                int hc = Int32.Parse(dataReader["Headcount"].ToString());
                Data dat = new Data(user,tablename,year,month,day,fromH,toH,drop,result,hc);
                ldata.Add(dat);
            }

            dataReader.Close();
            return ldata;

        }

        public List<Data> getAllData()
        {
            List<Data> ldata = new List<Data>();
            string query = "SELECT * FROM data";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while(dataReader.Read())
            {
                string user = dataReader["User"].ToString();
                string tablename = dataReader["TableName"].ToString();
                int year = Int32.Parse(dataReader["Year"].ToString());
                int month = Int32.Parse(dataReader["Month"].ToString());
                int day = Int32.Parse(dataReader["Day"].ToString());
                int fromH = Int32.Parse(dataReader["fromH"].ToString());
                int toH = Int32.Parse(dataReader["toH"].ToString());
                double drop = Double.Parse(dataReader["DropF"].ToString());
                double result = Double.Parse(dataReader["Result"].ToString());
                int hc = Int32.Parse(dataReader["Headcount"].ToString());
                Data dat = new Data(user, tablename, year, month, day, fromH, toH, drop, result, hc);
                ldata.Add(dat);
            }
            dataReader.Close();
            return ldata;
        }

        public BindingSource getDataByDate(DateTime dt)
        {
            List<Data> list = new List<Data>();
            string query = string.Format("SELECT * FROM data WHERE Year='{0}' AND Month='{1}' AND Day='{2}'", dt.Year, dt.Month, dt.Day);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            MySqlCommand cmd = new MySqlCommand(query, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];

            return bs;
        }

        public void addNewData(Data dt)
        {
            string query = string.Format("INSERT INTO data VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                dt.tableName, dt.year, dt.month, dt.day, dt.fromH, dt.toH, dt.drop, dt.result, dt.headcount, dt.user);

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        
        /// <summary>
        /// Checks whether table name is already in use
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        public bool doesExist(Table tbl)
        {
            List<Table> list = new List<Table>();
            if (!this.openConnection())
                return true;

            list = this.selectTables();

            foreach (Table item in list)
            {
                if (item.getTableName().ToLower() == tbl.getTableName().ToLower())
                {                    
                    this.closeConnection();
                    return true;
                }
            }
            this.closeConnection();
            return false;
        }


        public void deleteRow(Data dt)
        {
            string query = string.Format("DELETE FROM data WHERE TableName='{0}' AND Year='{1}' AND Month='{2}' AND Day='{3}' AND fromH='{4}' AND toH='{5}' AND DropF='{6}' AND Result='{7}' AND Headcount='{8}' AND User='{9}'", dt.tableName, dt.year, dt.month, dt.day, dt.fromH, dt.toH, dt.drop, dt.result, dt.headcount, dt.user);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();                   
        }

    }
}
