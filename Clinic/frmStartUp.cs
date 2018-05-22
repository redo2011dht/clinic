using Clinic.Document;
using Clinic.PharmacyFolder;
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

namespace Clinic
{
    public partial class frmStartUp : Form
    {
        public frmStartUp()
        {
            InitializeComponent();
            lblTitle.Text = new Systems().SelectValue("clinic_name");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnDoc_Click(object sender, EventArgs e)
        {
           
            new frmReception().Show();
            Common.f.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPharmacy_Click(object sender, EventArgs e)
        {
            new frmPharmacyMngr().Show();
            Common.f.WindowState = FormWindowState.Minimized;
        }
    }
}
