using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace UTS_PBO.View.Admin
{
    public partial class RegisterAdmin : Form
    {
        public RegisterAdmin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string noTlp = txtNoTlp.Text;
            string password = txtPassword.Text;

            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(noTlp) ||
                    string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                openConnection();

                string query = "INSERT INTO Akun_admin (email, nama, no_tlp, username, password) VALUES (@Email, @Nama, @NoTlp, @Username, @Password)";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Nama", nama);
                    command.Parameters.AddWithValue("@NoTlp", noTlp);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pendaftaran berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Login_admin loginAdmin = new Login_admin();
                        loginAdmin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Pendaftaran gagal. Coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private static readonly string DB_DATABASE = "UAS PBO";
        private static readonly string DB_USERNAME = "postgres";
        private static readonly string DB_PASSWORD = "1";
        private static readonly string DB_PORT = "5432";
        private static NpgsqlConnection connection;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_admin loginAdmin = new Login_admin();
            loginAdmin.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

