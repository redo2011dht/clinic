using Npgsql;
using System;
using System.Windows.Forms;

namespace ReDo
{
    public class Common
    {
        public NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" +
                  "User Id={2};Password={3};Database={4};",
                  "localhost", "5432", "postgres",
                  "17052016", "Clinic");
        public Common()
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR CONNECTION: " + ex.Message);
            }
        }
        #region reading number
        public static string OneNumber(long n)
        {
            if (n == 0) return "không ";
            if (n == 1) return "một ";
            if (n == 2) return "hai ";
            if (n == 3) return "ba ";
            if (n == 4) return "bốn ";
            if (n == 5) return "năm ";
            if (n == 6) return "sáu ";
            if (n == 7) return "bảy ";
            if (n == 8) return "tám ";
            if (n == 9) return "chín ";
            return null;
        }
        public static string TwoNumbers(long c, long dv)
        {
            if (c == 1)
            {
                if (dv == 0) return "mười ";
                else
                    if (dv == 5) return "mười lăm ";

                return "mười " + OneNumber(dv);
            }
            else
            {
                if (dv == 4) return OneNumber(c) + "mươi tư ";
                if (dv == 0) return OneNumber(c) + "mươi ";
                if (dv == 1) return OneNumber(c) + "mươi mốt ";
                if (dv == 5) return OneNumber(c) + "mươi lăm ";
                return OneNumber(c) + "mươi " + OneNumber(dv);
            }

        }
        public static string ThreeNumbers(long t, long c, long dv)
        {
            if (t == 0 && c == 0 && dv == 0) return null;
            if (c == 0 && dv == 0) return OneNumber(t) + "trăm ";
            if (c == 0) return OneNumber(t) + "trăm lẻ " + OneNumber(dv);
            return OneNumber(t) + "trăm " + TwoNumbers(c, dv);
        }

        public static string ReadingNumber(long n)
        {
            string st1 = "";
            string st2 = "";
            int nhom = 1;
            while (n != 0)
            {
                long dv = n % 10;
                long c = n / 10 % 10;
                long t = n / 100 % 10;
                if (n < 10) st1 = OneNumber(n);
                else if (n < 100) st1 = TwoNumbers(c, dv);
                else st1 = ThreeNumbers(t, c, dv);
                if (st1 != null)
                {
                    if (nhom == 1) st2 = st1;
                    if (nhom == 2) st2 = st1 + "nghìn " + st2;
                    if (nhom == 3) st2 = st1 + "triệu " + st2;
                    if (nhom == 4) st2 = st1 + "tỷ " + st2;
                }
                n = n / 1000; nhom++;
            }
            if (st2 != "" || st2 != null) return st2.Substring(0, 1).ToUpper() + st2.Substring(1, st2.Length - 1).ToLower() + "đồng";
            return "";
        }
        #endregion ___readingnumber


        public static string FormatString(string input)
        {
            string[] words = input.Split(' ');
            string result=null;
            foreach(string word in words)
            {
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }
            }
            return result;
        }
    }
}
