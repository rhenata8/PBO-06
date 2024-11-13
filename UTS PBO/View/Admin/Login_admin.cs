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

            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Password: {password}");

            try
            {
                openConnection();

                string query = "SELECT * FROM Akun_admin WHERE username = @username AND password = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            this.Hide();
                            Dashboard_admin dashboard_Admin = new Dashboard_admin();
                            dashboard_Admin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Username tidak terdaftar");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private static void openConnection()
        {
            connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}");
            connection.Open();
        }

        private static readonly string DB_HOST = "localhost";
        private static readonly string DB_DATABASE = "PROJEK PBO";
        private static readonly string DB_USERNAME = "postgres";
        private static readonly string DB_PASSWORD = "rh3r1ffs";
        private static readonly string DB_PORT = "5432";
        private static NpgsqlConnection connection;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register_admin register_Admin = new Register_admin();
            register_Admin.Show();
        }
    }

}

    
