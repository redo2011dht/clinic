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
    public class Patients
    {
        private NpgsqlCommand cmd;
        private NpgsqlConnection conn = new Common().conn;
        private string sql;
        private DataTable dt;
        public string Insert(string fullname,string birthdate,string gender,string phone,string address)
        {
            try
            {
                sql = @"select * from rp_insert(:fullname,:birthdate,:gender,:phone,:address)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("fullname",fullname);
                cmd.Parameters.AddWithValue("birthdate",birthdate);
                cmd.Parameters.AddWithValue("gender", gender);
                cmd.Parameters.AddWithValue("phone",phone);
                cmd.Parameters.AddWithValue("address",address);
                string v_patientno =(string)cmd.ExecuteScalar();
                conn.Close();
                return v_patientno;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi thêm bệnh nhân: " + ex.Message,"ERROR!!!!!!!!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable Select(string fromdate,string todate, string searchKey)
        {
            try
            {
                sql = @"select * from rp_select(:fromdate,:todate,:searchKey)";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("fromdate",fromdate);
                cmd.Parameters.AddWithValue("todate",todate);
                cmd.Parameters.AddWithValue("searchKey",searchKey);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());                
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi load ds bệnh nhân: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
