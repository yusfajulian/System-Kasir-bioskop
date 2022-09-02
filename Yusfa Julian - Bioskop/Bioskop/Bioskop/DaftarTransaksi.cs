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
    public partial class DaftarTransaksi : Form
    {
        DataPembayaran pembayaran;
        public DaftarTransaksi()
        {
            InitializeComponent();
            pembayaran = new DataPembayaran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama = new Utama();
                utama.Show();
                this.Close();
            }
        }

        private void DaftarTransaksi_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            dataGridView1.DataSource = pembayaran.muncul();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pembayaran.cari(textBox2.Text);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin membersihkan daftar transaksi", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                pembayaran = new DataPembayaran();
                pembayaran.clear();
                reload();
            }
        }
    }
}
