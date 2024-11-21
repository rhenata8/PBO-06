using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTS_PBO.View.Admin
{
    public partial class Dashboard_admin : Form
    {
        public Dashboard_admin()
        {
            InitializeComponent();
        }

        private void Dashboard_admin_Load(object sender, EventArgs e)
        {
            this.Text = "Dashboard Admin";

            InitializeDashboardUI();
        }

        private void InitializeDashboardUI()
        {
            Panel mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(mainContentPanel);

            Button btnDataMeja = new Button
            {
                Text = "Data Meja",
                Width = 100,
                Height = 30,
                Location = new Point(20, 20)
            };
            btnDataMeja.Click += (s, e) => LoadDataMeja(mainContentPanel);
            this.Controls.Add(btnDataMeja);

            Button btnKonfirmasiPesanan = new Button
            {
                Text = "Konfirmasi Pesanan",
                Width = 150,
                Height = 30,
                Location = new Point(140, 20)
            };
            btnKonfirmasiPesanan.Click += (s, e) => LoadKonfirmasiPesanan(mainContentPanel);
            this.Controls.Add(btnKonfirmasiPesanan);

            Button btnRiwayat = new Button
            {
                Text = "Riwayat",
                Width = 100,
                Height = 30,
                Location = new Point(320, 20)
            };
            btnRiwayat.Click += (s, e) => LoadRiwayat(mainContentPanel);
            this.Controls.Add(btnRiwayat);
        }

        private void LoadDataMeja(Panel mainContentPanel)
        {
            mainContentPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text = "Halaman Data Meja",
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(20, 60)
            };
            mainContentPanel.Controls.Add(lbl);

        }

        private void LoadKonfirmasiPesanan(Panel mainContentPanel)
        {
            mainContentPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text = "Halaman Konfirmasi Pesanan",
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(20, 60)
            };
            mainContentPanel.Controls.Add(lbl);

        }

        private void LoadRiwayat(Panel mainContentPanel)
        {
            mainContentPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text = "Halaman Riwayat",
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(20, 60)
            };
            mainContentPanel.Controls.Add(lbl);

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
