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
    public partial class Tiket : Form
    {
        DataTiket tiket;
        public Tiket()
        {
            InitializeComponent();
            tiket = new DataTiket();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama = new Utama();
                utama.Show();
                this.Close();
            }
        }

        private void reload()
        {
            dataGridView1.DataSource = tiket.tampil();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Tiket_Load(object sender, EventArgs e)
        {
            reload();
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin menambah data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    tiket = new DataTiket();
                    tiket.tambah(textBox1.Text, textBox2.Text);
                    reload();
                    textBox1.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin mengupdate data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    tiket = new DataTiket();
                    tiket.update(textBox1.Text, textBox2.Text);
                    reload();
                    textBox1.Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin menghapus data?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                tiket = new DataTiket();
                tiket.delete(textBox1.Text);
                reload();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
