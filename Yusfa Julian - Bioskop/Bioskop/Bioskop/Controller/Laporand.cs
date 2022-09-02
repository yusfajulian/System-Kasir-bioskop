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
    public class Laporand : Model.Koneksi
    {
        public DataTable cek()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from tb_laporan";
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kode admin tidak diketahui!"+ex.Message);
            }
            return data;
        }

        public void tambah(string judul,string pesan)
        {
            string queri = "insert into tb_laporan values('',@judul,@pesan)";
            try
            {
                cmd = new MySqlCommand(queri,GetConn());
                cmd.Parameters.Add("@judul", MySqlDbType.VarChar).Value = judul;
                cmd.Parameters.Add("@pesan", MySqlDbType.VarChar).Value = pesan;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Menambah Data"+ex.Message);
            }
        }

        public void update(string judul,string pesan, string no)
        {
            string queri = "update tb_laporan set judul=@judul,pesan=@pesan where no_pesan=@no";
            try
            {
                cmd = new MySqlCommand(queri, GetConn());
                cmd.Parameters.Add("@judul", MySqlDbType.VarChar).Value = judul;
                cmd.Parameters.Add("@pesan", MySqlDbType.VarChar).Value = pesan;
                cmd.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengupdate Data" + ex.Message);
            }
        }

        public void delete(string no)
        {
            string query = "delete from tb_laporan where no_pesan=@no";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus Data" + ex.Message);
            }
        }
    }
}
