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
    public partial class Jadwal : Form
    {
        Controller.Jadwal jadwal;
        public Jadwal()
        {
            InitializeComponent();
            jadwal = new Controller.Jadwal();
        }

        private void TambahJadwal_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            dataGridView1.DataSource = jadwal.tampil();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBox1.Text = "";
            textBox3.Text = "";
        }
        
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            reload();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin menambah data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    jadwal = new Controller.Jadwal();
                    jadwal.update(textBox1.Text, textBox3.Text,comboBox1.Text);
                    reload();
                }
            }
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama = new Utama();
                utama.Show();
                this.Close();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
