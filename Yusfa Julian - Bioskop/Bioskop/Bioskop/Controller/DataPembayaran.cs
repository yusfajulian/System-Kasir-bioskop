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
    public class DataPembayaran : Model.Koneksi
    {
        public DataTable tampil()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from tb_transaksi where status = 'Belum Lunas'";
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!!" + ex.Message);
            }
            return data;
        }

        public DataTable muncul()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from tb_transaksi where status = 'Lunas'";
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!!" + ex.Message);
            }
            return data;
        }

        public DataTable cari(string id)
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from tb_transaksi where id_transaksi="+id;
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!!" + ex.Message);
            }
            return data;
        }

        public void bayar(string transaksi, string harga,string metode)
        {
            string query = "update tb_transaksi set status='Lunas',metode_pembayaran=@metode where id_transaksi = @transaksi";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@transaksi", MySqlDbType.VarChar).Value = transaksi;
                cmd.Parameters.Add("@metode", MySqlDbType.VarChar).Value = metode;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil membayar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memesan " + ex.Message);
            }
        }

        public void clear()
        {
            string query = "delete from tb_transaksi where  status='Lunas'";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menghapus data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data!" + ex.Message);
            }
        }

        public void delete(string id)
        {
            string query = "delete from tb_transaksi where id_transaksi = "+id;
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menghapus data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data!" + ex.Message);
            }
        }
    }
}
