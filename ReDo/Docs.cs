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
    public class Docs
    {
        private NpgsqlCommand cmd;
        private NpgsqlConnection conn = new Common().conn;
        private string sql;
        private DataTable dt;
        public long Insert(string patientno)
        {
            try
            {
                sql = @"select * from rd_insert(:patientno)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("patientno",patientno);
                long docno = (long)cmd.ExecuteScalar();
                conn.Close();
                return docno;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi tạo hồ sơ khám: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }
        }
        public int Confirm(long docno, string patientno, string symptom, string diagnostic, string advice,string examdate,string doctor)
        {
            try
            {
                sql = @"select * from rd_confirm(:docno,:patientno,:symptom,:diagnostic,:advice,:examdate,:doctor)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("docno",docno);
                cmd.Parameters.AddWithValue("patientno",patientno);
                cmd.Parameters.AddWithValue("symptom",symptom);
                cmd.Parameters.AddWithValue("diagnostic",diagnostic);
                cmd.Parameters.AddWithValue("advice",advice);
                cmd.Parameters.AddWithValue("examdate",examdate);
                cmd.Parameters.AddWithValue("doctor",doctor);
                int rs = (int)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi xác nhận hồ sơ: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public DataTable History(string patientno)
        {
            try
            {
                sql = "select * from rd_history(:patientno)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("patientno",patientno);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi lấy lịch sử khám: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataRow Select(long docno)
        {
            try
            {
                sql = @"select * from rd_select(:docno)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("docno",docno);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi lấy thông tin hồ sơ khám: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
