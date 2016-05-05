using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_Of__Members
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin admin;
            try
            {
                admin = new Admin(txtUsername.Text, txtPassword.Text);
                Admin.IsAdmin(admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtPassword.Clear();
                txtUsername.Clear();
                txtUsername.Focus();
                return;
            }

            AdminView aw = new AdminView(admin);
            aw.Show();
            this.Hide();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Admin a;
                try
                {
                    a = new Admin(txtUsername.Text, txtPassword.Text);
                    Admin.IsAdmin(a);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtPassword.Clear();
                    txtUsername.Clear();
                    txtUsername.Focus();
                    return;
                }

                e.Handled = true; // zaustavlja bip sound :)
                AdminView aw = new AdminView(a);
                aw.Show();
                this.Hide();
            }
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
