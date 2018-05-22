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
    public class PharmacyOrder
    {
        private NpgsqlConnection conn = new Common().conn;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private string sql;
        public string Insert(string billno,int supplier_id,string performedby, string performeddate, string remark)
        {
            try
            {
                sql = @"select * from rpo_insert(:billno,:supplier_id,:performedby,:performeddate,:remark)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("billno",billno);
                cmd.Parameters.AddWithValue("supplier_id",supplier_id);
                cmd.Parameters.AddWithValue("performedby",performedby);
                cmd.Parameters.AddWithValue("performeddate",performeddate);
                cmd.Parameters.AddWithValue("remark",remark);
                string orderid = (string)cmd.ExecuteScalar();
                conn.Close();
                return orderid;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi thêm phiếu nhập: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable Select(string fromdate,string todate,string searchKey)
        {
            try
            {
                sql = @"select * from rpo_select(:fromdate,:todate,:searchKey)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
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
                MessageBox.Show("Lỗi lấy danh sách phiếu nhập: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public string Delete(string orderid)
        {
            try
            {
                sql = @"select * from rpo_delete(:orderid)";
                conn.Open();
                cmd = new NpgsqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("orderid",orderid);
                string rs = (string)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi xóa phiếu nhập: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public string Submit(string orderid)
        {
            try
            {
                sql = @"select * from rpo_submit(:orderid)";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("orderid",orderid);
                string rs = (string)cmd.ExecuteScalar();
                conn.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi xác nhận phiếu nhập: " + ex.Message, "ERROR!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
