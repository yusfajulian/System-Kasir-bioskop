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
    public class DataTiket : Model.Koneksi
    {
        public DataTable tampil()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from tb_tiket";
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!! " + ex.Message);
            }
            return data;
        }

        public void tambah(string id,string stok)
        {
            string query = "insert into tb_tiket values(@id,@stok)";
            try
            {
                cmd = new MySqlCommand(query,GetConn());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@stok", MySqlDbType.VarChar).Value = stok;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menambah data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah data!" + ex.Message);
            }
        }
        public void update(string id, string stok)
        {
            string query = "update tb_tiket set stok = @stok where id_tiket = @id";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@stok", MySqlDbType.VarChar).Value = stok;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil mengupdate data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah data!" + ex.Message);
            }
        }
        public void delete(string id)
        {
            string query = "delete from tb_tiket where id_tiket = @id";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
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
