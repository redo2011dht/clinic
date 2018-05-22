using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReDo
{
    public class DrugOrder
    {
        private string sql;
        private NpgsqlConnection conn = new Common().conn;
        private NpgsqlCommand cmd;
        public long Insert(long docno, string doctor, string orderdate, string issuedate)
        {
            try
            {
                sql = @"select * from rdo_insert(:docno,:doctor,:orderdate,:issuedate)";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("docno", docno);
                cmd.Parameters.AddWithValue("doctor", doctor);
                cmd.Parameters.AddWithValue("orderdate", orderdate);
                cmd.Parameters.AddWithValue("issuedate", issuedate);
                long id = (long)cmd.ExecuteScalar();
                conn.Close();
                return id;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi thêm đơn thuốc: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}
