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
    public class Systems
    {
        private NpgsqlCommand cmd;
        private DataTable dt;
        private NpgsqlConnection conn = new Common().conn;
        private string sql;
        public DataTable Address()
        {
            try
            {
                sql = @"select * from sys_address()";
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
                MessageBox.Show("Lỗi load địa chỉ: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable Symptom()
        {
            try
            {
                sql = "select * from sys_symptom()";
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
                MessageBox.Show("Lỗi load triệu chứng: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable Icd()
        {
            try
            {
                sql = "select * from hi_select()";
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
                MessageBox.Show("Lỗi load danh sách bệnh: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable Advice()
        {
            try
            {
                sql = "select * from ra_select()";
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
                MessageBox.Show("Lỗi load danh sách lời khuyên của bác sỹ: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable FeeList()
        {
            try
            {
                sql = "select * from hfl_select()";
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
                MessageBox.Show("Lỗi load danh sách phí: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataRow Examination()
        {
            try
            {
                sql = @"select * from hfl_get_examination()";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi lấy công khám: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
                    
        }
        public DataTable DrugUsage()
        {
            try
            {
                sql = "select * from pdu_select()";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi load hướng dẫn sử dụn thuốc: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public string SelectValue(string key)
        {
            try
            {
                sql = @"select * from sst_select(:key)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("key",key);
                string value = (string)cmd.ExecuteScalar();
                conn.Close();
                return value;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi load value by key: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
