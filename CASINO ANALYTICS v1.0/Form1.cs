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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegister frmReg = new frmRegister();
            frmReg.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblInvalidLogin.Visible = false;
            List<User> list = new List<User>();
            DbConnect conn = new DbConnect();
            conn.openConnection();
            list = conn.selectUsers();

            foreach (User u in list)
            {
                if(u.getUsername() == tbUser.Text && u.getPassword()==tbPassword.Text)
                {
                    
                    conn.closeConnection();
                    frmMainScreen frmMain = new frmMainScreen(u.getUsername());
                    frmMain.Show();
                    this.Hide();
                }
            }
            lblInvalidLogin.Visible = true;
            conn.closeConnection();
        }

        private void tbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
            }
        }
    }
}
