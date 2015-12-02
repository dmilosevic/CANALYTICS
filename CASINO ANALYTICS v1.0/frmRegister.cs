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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            lblUserExists.Visible = false;
            if(tbPassword.Text!=tbPassReenter.Text)
            {
                MessageBox.Show("Passwords you entered do not match!");
                lblUserExists.Visible = false;
                return;
            }
            if (tbUser.Text == "" || tbPassword.Text == "" || tbPassReenter.Text == "")
            {
                MessageBox.Show("Cannot create blank user!");
                lblUserExists.Visible = false;
                return;
            }

            User newUser = new User(tbUser.Text, tbPassword.Text);

            DbConnect conn = new DbConnect();
            List<User> list = new List<User>(); //stores users from database

            if (!conn.openConnection())
                return;

            //connected
            list = conn.selectUsers();

            foreach(User u in list)
            {
                if(u.getUsername() == newUser.getUsername())
                {
                    lblUserExists.Visible = true;
                    conn.closeConnection();
                    return;
                }
            }           

            conn.addNewUser(newUser);

            conn.closeConnection();

           // lblSuccess.Text = "User " + newUser.getUsername() + " successfully added";
            MessageBox.Show("User " + newUser.getUsername() + " successfully added");
            lblSuccess.Visible = true;
            lblUserExists.Visible = false;
            tbPassReenter.Clear();
            tbPassword.Clear();
            tbUser.Clear();
            this.Close();
        }
    }
}
