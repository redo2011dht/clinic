using Npgsql;
using System;
using System.Windows.Forms;

namespace ReDo
{
    public class FeeOrderLine
    {
        private NpgsqlConnection conn = new Common().conn;
        private NpgsqlCommand cmd;
        private string sql;
        public int Insert(long orderid, string itemid, int quantity, int price)
        {
            try
            {
                sql = @"select * from rfol_insert(:orderid,:itemid,:quantity,:price)";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("orderid", orderid);
                cmd.Parameters.AddWithValue("itemid", itemid);
                cmd.Parameters.AddWithValue("quantity", quantity);
                cmd.Parameters.AddWithValue("price", price);
                int rs = (int)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi xác thực dịch vụ: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }
        }
    }
}
