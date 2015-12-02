using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CASINO_ANALYTICS_v1._0
{
    class User
    {
        //private int ID;
        private string Username;
        private string Password;

        public User() { }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string getUsername()
        {
            return Username;
        }
        public string getPassword()
        {
            return Password;
        }
    }
}
