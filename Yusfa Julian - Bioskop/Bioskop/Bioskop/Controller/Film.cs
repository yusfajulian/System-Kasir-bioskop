using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace Bioskop.Controller
{
    public class Film : Model.Koneksi
    {
        public DataTable tampil()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from tb_film";
                da = new MySqlDataAdapter(query,GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!! "+ex.Message);
            }
            return data;
        }

        public DataTable genre()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select Nama_kategori from tb_kategori";
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!! " + ex.Message);
            }
            return data;
        }

        public void tambah(string id,string judul,string jadwal,string genre,string studio,string tiket,string harga,string durasi,string mulai,string berakhir)
        {
            string query = "insert into tb_film values(@id,@judul,@jadwal,@genre,@studio,@tiket,@harga,@durasi,@mulai,@berakhir)";
            try
            {
                cmd = new MySqlCommand(query,GetConn());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@judul", MySqlDbType.VarChar).Value = judul;
                cmd.Parameters.Add("@jadwal", MySqlDbType.VarChar).Value = jadwal;
                cmd.Parameters.Add("@genre", MySqlDbType.VarChar).Value = genre;
                cmd.Parameters.Add("@studio", MySqlDbType.VarChar).Value = studio;
                cmd.Parameters.Add("@tiket", MySqlDbType.VarChar).Value = tiket;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@durasi", MySqlDbType.VarChar).Value = durasi;
                cmd.Parameters.Add("@mulai", MySqlDbType.VarChar).Value = mulai;
                cmd.Parameters.Add("@berakhir", MySqlDbType.VarChar).Value = berakhir;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menambah data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah "+ex.Message);
            }
        }

        public void update(string id, string judul, string jadwal, string genre, string studio, string tiket, string harga, string durasi, string mulai, string berakhir)
        {
            string query = "update tb_film set Judul = @judul,Id_jadwal = @jadwal,Genre = @genre,Nama_studio = @studio,Id_tiket = @tiket,Harga = @harga,Durasi = @durasi,Tgl_mulai = @mulai,Tgl_berakhir = @berakhir where Id_film = @id";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@judul", MySqlDbType.VarChar).Value = judul;
                cmd.Parameters.Add("@jadwal", MySqlDbType.VarChar).Value = jadwal;
                cmd.Parameters.Add("@genre", MySqlDbType.VarChar).Value = genre;
                cmd.Parameters.Add("@studio", MySqlDbType.VarChar).Value = studio;
                cmd.Parameters.Add("@tiket", MySqlDbType.VarChar).Value = tiket;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@durasi", MySqlDbType.VarChar).Value = durasi;
                cmd.Parameters.Add("@mulai", MySqlDbType.VarChar).Value = mulai;
                cmd.Parameters.Add("@berakhir", MySqlDbType.VarChar).Value = berakhir;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menambah data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah " + ex.Message);
            }
        }

        public void delete(string id)
        {
            string query = "delete from tb_film where Id_film = @id";
            try
            {
                cmd = new MySqlCommand(query,GetConn());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menghapus data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data!"+ex.Message);
            }
        }

        public DataTable tampilDepan()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select Judul,Genre,Nama_studio,Harga,Durasi,Tgl_mulai,Tgl_berakhir from tb_film";
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!! " + ex.Message);
            }
            return data;
        }
    }
}
