using Npgsql;
using System;
using System.Windows.Forms;

namespace ReDo
{
    public class FeeOrder
    {
        private NpgsqlConnection conn = new Common().conn;
        private NpgsqlCommand cmd;

        public long Insert(string orderdate, long docno, string performedby)
        {
            try
            {
                string sql = @"select * from rfo_insert(:orderdate,:docno,:performedby)";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("orderdate", orderdate);
                cmd.Parameters.AddWithValue("docno", docno);
                cmd.Parameters.AddWithValue("performedby", performedby);
                long rs = (long)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi tạo hồ sơ dịch vụ: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }
        }
    }
}

