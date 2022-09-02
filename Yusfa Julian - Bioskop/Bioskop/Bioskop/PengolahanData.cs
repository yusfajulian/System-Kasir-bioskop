using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class PengolahanData : Form
    {
        public PengolahanData()
        {
            InitializeComponent();
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.AliceBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Film film = new Film();
            film.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Jadwal jadwal = new Jadwal();
            jadwal.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tiket tiket = new Tiket();
            tiket.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama = new Utama();
                utama.Show();
                this.Hide();
            }
        }
    }
}
