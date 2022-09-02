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
    public class Transaksi : Model.Koneksi
    {
        public DataTable tampil(string table)
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from "+table;
                da = new MySqlDataAdapter(query,GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!!"+ex.Message);
            }
            return data;
        }

        public void tambah(string transaksi, string film, string studio, string kursi, string tiket, string harga, string tgl, string status)
        {
            string query = "insert into tb_transaksi values(@transaksi,@film,@studio,@kursi,@tiket,@harga,@tgl,@status,'')";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@transaksi", MySqlDbType.VarChar).Value = transaksi;
                cmd.Parameters.Add("@film", MySqlDbType.VarChar).Value = film;
                cmd.Parameters.Add("@studio", MySqlDbType.VarChar).Value = studio;
                cmd.Parameters.Add("@kursi", MySqlDbType.VarChar).Value = kursi;
                cmd.Parameters.Add("@tiket", MySqlDbType.VarChar).Value = tiket;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@tgl", MySqlDbType.VarChar).Value = tgl;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil memesan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memesan " + ex.Message);
            }
        }
        public void UpdatePesanan(string transaksi, string film, string studio, string kursi, string tiket, string harga, string tgl, string status)
        {
            string query = "update tb_transaksi set id_film=@film,nama_studio=@studio,no_kursi=@kursi,id_tiket=@tiket,harga=@harga where id_transaksi=@transaksi";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@transaksi", MySqlDbType.VarChar).Value = transaksi;
                cmd.Parameters.Add("@film", MySqlDbType.VarChar).Value = film;
                cmd.Parameters.Add("@studio", MySqlDbType.VarChar).Value = studio;
                cmd.Parameters.Add("@kursi", MySqlDbType.VarChar).Value = kursi;
                cmd.Parameters.Add("@tiket", MySqlDbType.VarChar).Value = tiket;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil memesan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memesan " + ex.Message);
            }
        }
        public void update(string transaksi, string harga)
        {
            string query = "update tb_transaksi set status=Lunas where id_transaksi = @transaksi";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@transaksi", MySqlDbType.VarChar).Value = transaksi;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil membayar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memesan " + ex.Message);
            }
        }

        public void delete(string transaksi)
        {
            string query = "delete from tb_transaksi where id_transaksi = @transaksi";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@transaksi", MySqlDbType.VarChar).Value = transaksi;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil membayar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memesan " + ex.Message);
            }
        }
    }
}
