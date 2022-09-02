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
    public class Jadwal : Model.Koneksi
    {
        public DataTable tampil()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "select *from tb_jadwal";
                da = new MySqlDataAdapter(query, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan!! " + ex.Message);
            }
            return data;
        }

        public void update(string id, string mulai,string status)
        {
            string query = "update tb_jadwal set jam_mulai = @mulai,status = @status where id_jadwal = @id";
            try
            {
                cmd = new MySqlCommand(query, GetConn());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@mulai", MySqlDbType.VarChar).Value = mulai;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengupdate data!" + ex.Message);
            }
        }
    }
}
