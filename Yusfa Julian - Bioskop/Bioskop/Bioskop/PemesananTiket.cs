using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using Bioskop.Controller;

namespace Bioskop
{
    public partial class Pemesanan_Tiket : Form
    {
        Transaksi transaksi;
        public string constring = "server=localhost;user=root;database=db_bioskop";
        public MySqlCommand cmd;
        MySqlConnection connection;
        public MySqlDataReader myread;
        public Pemesanan_Tiket()
        {
            InitializeComponent();
            transaksi = new Transaksi();
            combo();
        }

        public void combo()
        {
            string queri = "select *from tb_film";
            connection = new MySqlConnection(constring);
            cmd = new MySqlCommand(queri, connection);
            try
            {
                connection.Open();
                myread = cmd.ExecuteReader();
                while (myread.Read())
                {
                    string judul = myread.GetString("Id_film");
                    comboBox3.Items.Add(judul);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string queri0 = "select Harga from tb_film where Id_film ='"+comboBox3.Text +"'";
            connection = new MySqlConnection(constring);
            cmd = new MySqlCommand(queri0, connection);
            try
            {
                connection.Open();
                myread = cmd.ExecuteReader();
                    string judul = myread.GetString("Harga");
                    textBox7.Text = judul;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pemesanan_Tiket_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            dataGridView1.DataSource = transaksi.tampil(comboBox6.Text);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            comboBox3.Text = "";
            textBox2.Text = "";
            comboBox6.Text = "tb_transaksi";
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin menambah data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    transaksi = new Transaksi();
                    transaksi.tambah(textBox8.Text, comboBox3.Text, textBox1.Text, comboBox1.Text, textBox2.Text, textBox7.Text, dateTimePicker1.Text, textBox3.Text);
                    reload();
                    comboBox3.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin menambah data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    transaksi = new Transaksi();
                    transaksi.UpdatePesanan(textBox8.Text, comboBox3.Text, textBox1.Text, comboBox1.Text, textBox2.Text, textBox7.Text, dateTimePicker1.Text, textBox3.Text);
                    reload();
                    comboBox3.Focus();
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                comboBox1.Items.Clear();
                string queri = "select Harga from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string harga = myread.GetString("Harga");
                        textBox7.Text = harga;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri0 = "select Nama_studio from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri0, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string studio = myread.GetString("Nama_Studio");
                        textBox1.Text = studio;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri1 = "SELECT no_kursi FROM tb_kursi where nama_studio='" + textBox1.Text + "' AND status='BELUM DIPESAN'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri1, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string kursi = myread.GetString("no_kursi");
                        comboBox1.Items.Add(kursi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri2 = "select Id_tiket from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri2, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string tiket = myread.GetString("Id_tiket");
                        textBox2.Text = tiket;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                comboBox1.Items.Clear();
                string queri = "select Harga from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string harga = myread.GetString("Harga");
                        textBox7.Text = harga;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri0 = "select Nama_studio from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri0, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string studio = myread.GetString("Nama_Studio");
                        textBox1.Text = studio;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri1 = "SELECT no_kursi FROM tb_kursi where nama_studio='" + textBox1.Text + "' AND status='BELUM DIPESAN'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri1, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string kursi = myread.GetString("no_kursi");
                        comboBox1.Items.Add(kursi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri2 = "select Id_tiket from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri2, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string tiket = myread.GetString("Id_tiket");
                        textBox2.Text = tiket;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                comboBox1.Items.Clear();
                string queri = "select Harga from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string harga = myread.GetString("Harga");
                        textBox7.Text = harga;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri0 = "select Nama_studio from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri0, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string studio = myread.GetString("Nama_Studio");
                        textBox1.Text = studio;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri1 = "SELECT no_kursi FROM tb_kursi where nama_studio='" + textBox1.Text + "' AND status='BELUM DIPESAN'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri1, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string kursi = myread.GetString("no_kursi");
                        comboBox1.Items.Add(kursi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string queri2 = "select Id_tiket from tb_film where Id_film = '" + comboBox3.Text + "'";
                connection = new MySqlConnection(constring);
                cmd = new MySqlCommand(queri2, connection);
                try
                {
                    connection.Open();
                    myread = cmd.ExecuteReader();
                    while (myread.Read())
                    {
                        string tiket = myread.GetString("Id_tiket");
                        textBox2.Text = tiket;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama = new Utama();
                utama.Show();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
            comboBox1.Items.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin menghapus data?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                transaksi = new Transaksi();
                transaksi.delete(textBox8.Text);
                reload();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            transaksi = new Transaksi();
            transaksi.tampil(comboBox6.Text);
            reload();
        }
    }
}
