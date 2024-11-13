using UTS_PBO.View.Admin;
using UTS_PBO.View.Customer;

namespace UTS_PBO
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Hide();
                Login_admin loginAdmin = new Login_admin();
                loginAdmin.Show();
            }

            if (radioButton2.Checked)
            {
                this.Hide();
                Login_customer loginCustomer = new Login_customer();
                loginCustomer.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
