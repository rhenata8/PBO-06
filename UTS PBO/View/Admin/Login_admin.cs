using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTS_PBO.App.Context;
using UTS_PBO.App.Model;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTS_PBO.App.Context.Admin;

namespace UTS_PBO.View.Admin
{
    public partial class Login_admin : Form
    {
        public Login_admin()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;


            try
            {
                bool isValid = LoginAdminContext.ValidateLogin(username, password);

                if (isValid)
                {
                    this.Hide();
                    Dashboard_admin dashboard_Admin = new Dashboard_admin();
                    dashboard_Admin.Show();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterAdmin register_Admin = new RegisterAdmin();
            register_Admin.Show();
        }
    }

}

    
