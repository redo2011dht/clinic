using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReDo
{
    public class Drug
    {
        private NpgsqlCommand cmd;
        private DataTable dt;
        private NpgsqlConnection conn = new Common().conn;
        private string sql;      
        public DataTable Select()
        {
            try
            {
                sql = "select * from pmi_select()";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi load danh sách thuốc: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
       
    }
}
