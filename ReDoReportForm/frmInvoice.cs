using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using ReDo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReDoReportForm
{
    public partial class frmInvoice : Form
    {
        public frmInvoice()
        {
            InitializeComponent();
        }
        InvoiceReport rpt;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.Print();
                //or printTool.PrintDialog();
                btnClose.PerformClick();
            }
        }
        public void Invoice(string clinicname, string clinicphone, string clinicaddress, string patientno, string docno, string examdate,
            string patientname, string patientbirthdate, string patientgender, string patientaddress, string patientphone,string symptom, string diagnostic,
            string advice, List<Fee> lstfee)
        {
            rpt= new InvoiceReport();
            foreach(Parameter p in rpt.Parameters)
            {
                p.Visible = false;
            }
            rpt.Init( clinicname,  clinicphone,  clinicaddress,  patientno,  docno,  examdate,
             patientname,  patientbirthdate,  patientgender,  patientaddress,  patientphone,symptom,  diagnostic,
             advice, lstfee);
            dmcDrugOrder.DocumentSource = rpt;
            rpt.CreateDocument();
        }
        #region panelcontrol
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dmcInvoice_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
