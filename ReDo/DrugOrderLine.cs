using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace ReDo
{
    public class DrugOrderLine
    {
        private NpgsqlConnection conn = new Common().conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        public int Insert(long orderid, string itemid, int exportprice, int quantity, string usage)
        {
            try
            {
                sql = @"select * from rdol_insert(:orderid,:itemid,:price, :quantity,:usage)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("orderid",orderid);
                cmd.Parameters.AddWithValue("itemid",itemid);
                cmd.Parameters.AddWithValue("price",exportprice);
                cmd.Parameters.AddWithValue("quantity",quantity);
                cmd.Parameters.AddWithValue("usage",usage);
                int rs = (int)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi thêm dòng thuốc: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public DataTable Select(long docno)
        {
            try
            {
                sql = @"select * from rdol_select(:docno)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("docno",docno);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi lấy danh sách thuốc: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
