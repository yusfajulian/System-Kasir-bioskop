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
using MySqlConnector;

namespace Bioskop
{
    public partial class Pembayaran : Form
    {
        DataPembayaran pembayaran;
        public string constring = "server=localhost;user=root;database=db_bioskop";
        public MySqlCommand cmd;
        public MySqlConnection connection;
        public MySqlDataReader myread;
        public Pembayaran()
        {
            InitializeComponent();
            pembayaran = new DataPembayaran();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama = new Utama();
                utama.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin membayar?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    pembayaran = new DataPembayaran();
                    pembayaran.bayar(textBox3.Text, textBox1.Text, comboBox1.Text);
                    reload();
                }
            }
        }

        private void reload()
        {
            dataGridView1.DataSource = pembayaran.tampil();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pembayaran.cari(textBox2.Text);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

       
        private void button2_Click_1(object sender, EventArgs e)
        {
            reload();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin menghapus data?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                pembayaran = new DataPembayaran();
                pembayaran.delete(textBox3.Text);
                reload();
            }
        }
    }
}
