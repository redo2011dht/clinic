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
    public class PharmacyOrderLine
    {
        private NpgsqlConnection conn = new Common().conn;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private string sql;
        public int Insert(string orderid,string itemid, int quantity, string manufactureddate, string expireddate)
        {
            try
            {
                sql = @"select * from rpol_insert(:orderid,:itemid,:quantity,:manufactureddate,:expireddate)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("orderid",orderid);
                cmd.Parameters.AddWithValue("itemid",itemid);
                cmd.Parameters.AddWithValue("quantity",quantity);
                cmd.Parameters.AddWithValue("manufactureddate",manufactureddate);
                cmd.Parameters.AddWithValue("expireddate",expireddate);
                int rs = (int)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi thêm thuốc vào phiếu nhập: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public DataTable Select(string orderid)
        {
            try
            {
                sql = @"select * from rpol_select(:orderid)";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("orderid",orderid);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi lấy danh sách thuốc của phiếu nhập: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public int Delete(string orderid, string itemid)
        {
            try
            {
                sql = @"select * from rpol_delete(:orderid,:itemid)";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("orderid",orderid);
                cmd.Parameters.AddWithValue("itemid",itemid);
                int rs = (int)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi lấy danh sách thuốc của phiếu nhập: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }
        }
    }
}
