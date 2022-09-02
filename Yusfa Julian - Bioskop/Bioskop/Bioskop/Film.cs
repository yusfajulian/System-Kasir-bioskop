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
using System.IO;

namespace Bioskop
{
    public partial class Film : Form
    {
        Controller.Film film;
        public string constring = "server=localhost;user=root;database=db_bioskop";
        public MySqlCommand cmd;
        public MySqlConnection connection;
        public MySqlDataReader myread;
        public Film()
        {
            InitializeComponent();
            film = new Controller.Film();
            combo();
        }
        public void combo()
        {
            comboBox1.Items.Clear();
            string queri = "select *from tb_kategori";
            connection = new MySqlConnection(constring);
            cmd = new MySqlCommand(queri, connection);
            try
            {
                connection.Open();
                myread = cmd.ExecuteReader();
                while (myread.Read())
                {
                    string studio = myread.GetString("Nama_Kategori");
                    comboBox1.Items.Add(studio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox3.Items.Clear();
            string queri1 = "select *from tb_jadwal where status='false'";
            connection = new MySqlConnection(constring);
            cmd = new MySqlCommand(queri1, connection);
            try
            {
                connection.Open();
                myread = cmd.ExecuteReader();
                while (myread.Read())
                {
                    string jadwal = myread.GetString("id_jadwal");
                    comboBox3.Items.Add(jadwal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void reload()
        {
            dataGridView1.DataSource = film.tampil();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||textBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" )
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin mengupdate data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    film = new Controller.Film();
                    film.update(textBox1.Text, textBox2.Text, comboBox3.Text, comboBox1.Text, comboBox4.Text,comboBox5.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Text, dateTimePicker2.Text);
                    textBox1.Focus();
                    reload();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin kembali?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Utama utama  = new Utama();
                utama.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Yakin ingin menghapus data?", "Warning", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                film = new Controller.Film();
                var val1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                film.delete(val1);
                reload();
                combo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" ||textBox2.Text==""|| comboBox3.Text==""|| comboBox1.Text==""|| comboBox4.Text==""||comboBox5.Text==""|| textBox5.Text==""|| textBox6.Text=="")
            {
                MessageBox.Show("lengkapi data diatas terlebih dahulu!!", "Peringatan!!");
            }
            else
            {
                DialogResult x = MessageBox.Show("Yakin ingin menambah data?", "Warning", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    film = new Controller.Film();
                    film.tambah(textBox1.Text, textBox2.Text, comboBox3.Text, comboBox1.Text, comboBox4.Text, comboBox5.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Text, dateTimePicker2.Text);
                    reload();
                    combo();
                }
            }
        }

        private void UpdateFilm_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFile.FileName;
                pictureBox1.Image = new Bitmap(openFile.FileName);
                pictureBox1.ImageLocation = openFile.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.Text == "j001")
            {
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox4.Text = "A";
                if (comboBox4.Text == "A")
                {
                    comboBox5.Text = "t001";
                }
            }else if (comboBox3.Text == "j002")
            {
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox4.Text = "B";
                if (comboBox4.Text == "B")
                {
                    comboBox5.Text = "t002";
                }
            }else if (comboBox3.Text == "j003")
            {
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox4.Text = "C";
                if (comboBox4.Text == "C")
                {
                    comboBox5.Text = "t003";
                }
            }
            else
            {
                MessageBox.Show("Maksimal Hanya 3 Film karna hanya ada 3 Studio");
                comboBox3.Text = "";
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}

