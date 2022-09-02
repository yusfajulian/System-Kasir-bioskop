using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bioskop.Controller;

namespace Bioskop
{
    public partial class Utama : Form
    {
        Controller.Film film;
        public Utama()
        {
            InitializeComponent();
            film = new Controller.Film();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            PengolahanData pengolahan = new PengolahanData();
            pengolahan.Show();
            this.Hide();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            Pemesanan_Tiket pesan = new Pemesanan_Tiket();
            pesan.Show();
            this.Hide();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            Laporan laporan = new Laporan();
            laporan.Show();
            this.Hide();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            Pembayaran pembayaran = new Pembayaran();
            pembayaran.Show();
            this.Hide();
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin keluar?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Pemesanan_Tiket pesan = new Pemesanan_Tiket();
            pesan.Show();
            this.Hide();
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            Pembayaran pembayaran = new Pembayaran();
            pembayaran.Show();
            this.Hide();
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            Laporan laporan = new Laporan();
            laporan.Show();
            this.Hide();
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            DaftarTransaksi daftar = new DaftarTransaksi();
            daftar.Show();
            this.Hide();
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            DaftarTransaksi daftar = new DaftarTransaksi();
            daftar.Show();
            this.Hide();
        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin keluar?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gray;
            panel3.BackColor = Color.DarkRed;
            panel4.BackColor = Color.DarkRed;
            panel5.BackColor = Color.DarkRed;
            panel6.BackColor = Color.DarkRed;
            panel7.BackColor = Color.DarkRed;
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gray;
            panel2.BackColor = Color.DarkRed;
            panel4.BackColor = Color.DarkRed;
            panel5.BackColor = Color.DarkRed;
            panel6.BackColor = Color.DarkRed;
            panel7.BackColor = Color.DarkRed;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Gray;
            panel3.BackColor = Color.DarkRed;
            panel2.BackColor = Color.DarkRed;
            panel5.BackColor = Color.DarkRed;
            panel6.BackColor = Color.DarkRed;
            panel7.BackColor = Color.DarkRed;
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Gray;
            panel3.BackColor = Color.DarkRed;
            panel4.BackColor = Color.DarkRed;
            panel2.BackColor = Color.DarkRed;
            panel6.BackColor = Color.DarkRed;
            panel7.BackColor = Color.DarkRed;
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Gray;
            panel3.BackColor = Color.DarkRed;
            panel4.BackColor = Color.DarkRed;
            panel5.BackColor = Color.DarkRed;
            panel2.BackColor = Color.DarkRed;
            panel7.BackColor = Color.DarkRed;
        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Gray;
            panel3.BackColor = Color.DarkRed;
            panel4.BackColor = Color.DarkRed;
            panel5.BackColor = Color.DarkRed;
            panel6.BackColor = Color.DarkRed;
            panel2.BackColor = Color.DarkRed;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DarkRed;
            panel3.BackColor = Color.DarkRed;
            panel4.BackColor = Color.DarkRed;
            panel5.BackColor = Color.DarkRed;
            panel6.BackColor = Color.DarkRed;
            panel7.BackColor = Color.DarkRed;
        }

        private void Utama_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DarkRed;
            panel3.BackColor = Color.DarkRed;
            panel4.BackColor = Color.DarkRed;
            panel5.BackColor = Color.DarkRed;
            panel6.BackColor = Color.DarkRed;
            panel7.BackColor = Color.DarkRed;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PengolahanData pengolahan = new PengolahanData();
            pengolahan.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PengolahanData pengolahan = new PengolahanData();
            pengolahan.Show();
            this.Hide();
        }

        private void reload()
        {
            dataGridView1.DataSource = film.tampilDepan();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Utama_Load(object sender, EventArgs e)
        {
            reload();
        }
    }
}
