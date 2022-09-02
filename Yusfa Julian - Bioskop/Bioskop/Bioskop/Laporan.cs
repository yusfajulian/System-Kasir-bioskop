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
    public partial class Laporan : Form
    {
        Laporand laporand;
        public Laporan()
        {
            InitializeComponent();
            laporand = new Laporand();
        }

        private void reload()
        {
            dataGridView1.DataSource = laporand.cek();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Laporan_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama = new Utama();
                utama.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin menyimpan?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    laporand = new Laporand();
                    laporand.tambah(textBox8.Text, textBox1.Text);
                    reload();
                    textBox8.Text = "";
                    textBox1.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox8.Text == "" )
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin mengupdate data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    laporand = new Laporand();
                    var val1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    laporand.update(textBox8.Text, textBox1.Text, val1);
                    reload();
                    textBox8.Text = "";
                    textBox1.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                DialogResult x = MessageBox.Show("Yakin ingin menghapus pesan?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                laporand = new Laporand();

                var val1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                laporand.delete(val1);
                reload();
                textBox8.Text = "";
                textBox1.Text = "";
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
