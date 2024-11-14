using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UTS_PBO.App.Model;
using UTS_PBO.App.Context;
using UTS_PBO.App.Context.Admin;

namespace UTS_PBO.View.Admin
{
    public partial class RegisterAdmin : Form
    {
        public bool IsEditMode { get; set; } = false;
        public int AdminId { get; set; }

        public RegisterAdmin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Inputan tidak valid");
                return;
            }

            try
            {
                M_registadmin admin = new M_registadmin
                {
                    nama = textBox1.Text,
                    username = textBox2.Text,
                    email = textBox3.Text,
                    no_telp = textBox4.Text,
                    password = textBox5.Text,
                };

                if (IsEditMode)
                {
                    // Jika mode edit, gunakan UpdateAdmin
                    admin.id = AdminId;
                    RegistAdminContext.UpdateAdmin(admin);
                    MessageBox.Show("Akun berhasil diupdate");
                }
                else
                {
                    // Jika mode tambah baru, gunakan AddAdmin
                    RegistAdminContext.AddAdmin(admin);
                    MessageBox.Show("Akun baru berhasil ditambahkan");
                }

                ClearFields();
                this.DialogResult = DialogResult.OK;
                this.Hide();

                // Refresh tampilan login
                Login_admin loginForm = new Login_admin();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
