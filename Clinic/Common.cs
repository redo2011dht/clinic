using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public static class Common
    {
        public static frmStartUp f;
        public static void WarningMessageBox(string content)
        {
            MessageBox.Show(content, "WARNING!!!!!!!!!!!!!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        public static void ErrorMessageBox(string content)
        {
            MessageBox.Show(content, "ERROR!!!!!!!!!!!!!!!",  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public static void ErrorMessageBox(string title,string content)
        {
            MessageBox.Show(content, title+"!!!!!!!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public static void SuccessMessageBox(string content)
        {
            MessageBox.Show(content, "SUCCESS!!!!!!!!!!!!!!!",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult ConfirmMessage(string title,string content)
        {
            return MessageBox.Show(content, title,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        }
    }
   
}
