using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.PharmacyFolder
{
    public partial class frmPharmacyMngr : Form
    {
        public frmPharmacyMngr()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Common.f.WindowState = FormWindowState.Normal;
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

        private Form CheckExist(Type fType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            Form f = CheckExist(typeof(frmItems));
            if (f != null)
            {
                f.Close();
            }

            frmItems frm = new frmItems();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPharmacyOrder_Click(object sender, EventArgs e)
        {
            Form f = CheckExist(typeof(frmPharmacyOrder));
            if(f!=null)
            {
                f.Close();
            }
            frmPharmacyOrder frm = new frmPharmacyOrder();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
