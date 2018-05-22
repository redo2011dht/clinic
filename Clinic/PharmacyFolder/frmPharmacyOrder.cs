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

namespace Clinic.PharmacyFolder
{
    public partial class frmPharmacyOrder : Form
    {
        public frmPharmacyOrder()
        {
            InitializeComponent();
        }

        private void frmPharmacyOrder_Load(object sender, EventArgs e)
        {
            SetEnable(false);
            mtbFromdate.Text = DateTime.Now.ToString("01/MM/yyyy");
            mtbTodate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadSuppliers();
            LoadEmployees();
            btnSearch.PerformClick();
        }
        #region define_variable
        private string orderid;
        private bool isCreated = false;
        private bool isSubmit = false;
        #endregion define_variable
        private void SetEnable(bool b)
        {
            sleSupplier.Enabled = mtbPerformedDate.Enabled = txtBillno.Enabled = cbbEmployee.Enabled = txtRemark.Enabled = b;
            btnSave.Enabled = b;
        }
        #region loadData
        private void LoadSuppliers()
        {
            sleSupplier.Properties.DataSource = new Supplier().Select();
            sleSupplier.Properties.DisplayMember = "name";
            sleSupplier.Properties.ValueMember = "id";
        }
        private void LoadEmployees()
        {
            cbbEmployee.DataSource = new Employee().Select();
            cbbEmployee.DisplayMember = "fullname";
            cbbEmployee.ValueMember = "username";
            cbbEmployee.SelectedIndex = -1;
        }
        #endregion loadData

        #region keydown
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.Focus();
            }
        }
        private void sleSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Down)
            {
                sleSupplier.ShowPopup();
            }
            if(e.KeyCode ==Keys.Enter)
            {
                mtbPerformedDate.Select();
            }
        }     
        private void mtbPerformedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtBillno.Select();
            }
        }

        private void txtBillno_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cbbEmployee.Select();
            }
        }

        private void cbbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtRemark.Select();
            }
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        #endregion keydown


        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            ResetComponents();
            mtbPerformedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            sleSupplier.Select();
            isCreated = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(sleSupplier.EditValue.ToString()))
            {
                Common.WarningMessageBox("Vui lòng chọn nhà cung cấp");
                sleSupplier.Focus();
                return;
            }
            int id = int.Parse(sleSupplier.EditValue.ToString());
            try
            {
                DateTime.ParseExact(mtbPerformedDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Common.ErrorMessageBox("Vui lòng nhập định dạng ngày nhập: dd/MM/yyyy");
                mtbFromdate.Focus();
                return;
            }
            string performeddate = mtbPerformedDate.Text;
            string billno = txtBillno.Text;
            if(string.IsNullOrEmpty(billno))
            {
                Common.WarningMessageBox("Vui lòng nhập hóa đơn");
                txtBillno.Focus();
                return;
            }

            if(cbbEmployee.SelectedIndex<0)
            {
                Common.WarningMessageBox("Vui lòng chọn nhân viên nhập hàng");
                cbbEmployee.Focus();
                return;
            }
            string performedby = cbbEmployee.SelectedValue.ToString();
            string remark = txtRemark.Text;
            if(isCreated)
            {
                orderid = new PharmacyOrder().Insert(billno,id, performedby, performeddate, remark);
                if(string.IsNullOrEmpty(orderid)||orderid=="FAIL")
                {
                    Common.ErrorMessageBox("Tạo phiếu nhập thất bại");
                    return;
                }
                txtSearch.Text = orderid;
                btnSearch.PerformClick();                
                btnAddDetail.Enabled = true;
            }
            else
            {

            }
            ResetComponents();
            btnSave.Enabled = false;
        }

        private void ResetComponents()
        {
            sleSupplier.EditValue = null;
            mtbPerformedDate.Text = null;
            txtBillno.Text = null;
            cbbEmployee.SelectedIndex = -1;
            txtRemark.Text = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime.ParseExact(mtbFromdate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime.ParseExact(mtbTodate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Common.ErrorMessageBox("Vui lòng nhập định dạng ngày tháng: dd/MM/yyyy");
                mtbFromdate.Focus();
                return;
            }
            dgvOrders.DataSource = null;
            dgvOrders.DataSource = new PharmacyOrder().Select(mtbFromdate.Text,mtbTodate.Text,txtSearch.Text);
            dgvOrders.Columns["supplier_id"].Visible = false;
            dgvOrders.Columns["orderid"].HeaderText = "Mã phiếu";
            dgvOrders.Columns["billno"].HeaderText = "Mã hóa đơn";
            dgvOrders.Columns["suppliername"].HeaderText = "Nhà cung cấp";
            dgvOrders.Columns["employeename"].HeaderText = "Người nhập";
            dgvOrders.Columns["performeddate"].HeaderText = "Ngày nhập";
            dgvOrders.Columns["status"].HeaderText = "Trạng thái";
            dgvOrders.Columns["remark"].HeaderText = "Ghi chú";
            dgvOrders.Columns["orderid"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["billno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["employeename"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["performeddate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["remark"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["suppliername"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrders.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                orderid = dgvOrders.Rows[e.RowIndex].Cells["orderid"].Value.ToString();
                sleSupplier.EditValue = dgvOrders.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString();
                mtbPerformedDate.Text = dgvOrders.Rows[e.RowIndex].Cells["performeddate"].Value.ToString();
                txtBillno.Text = dgvOrders.Rows[e.RowIndex].Cells["billno"].Value.ToString();
                cbbEmployee.Text = dgvOrders.Rows[e.RowIndex].Cells["employeename"].Value.ToString();
                txtRemark.Text = dgvOrders.Rows[e.RowIndex].Cells["remark"].Value.ToString();
                if (dgvOrders.Rows[e.RowIndex].Cells["status"].Value.ToString().Equals("O"))
                {
                    isSubmit = false;
                    btnAction.Text = "Xác nhận";
                    btnAddDetail.Enabled = true;
                }
                else
                {
                    isSubmit = true;
                    btnAddDetail.Enabled = false;
                    btnAction.Text = "Bỏ xác nhận";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(orderid))
            {
                Common.WarningMessageBox("Vui lòng chọn phiếu cần xóa");
                return;
            }
            if(Common.ConfirmMessage("Xác nhận xóa phiếu nhập","Bạn chắc chắn muốn xóa phiếu: "+orderid+"?")==DialogResult.Yes)
            {
                var rs = new PharmacyOrder().Delete(orderid);
                if(rs.Equals("NOTFOUND"))
                {
                    Common.WarningMessageBox("Mã phiếu nhập không tồn tại");
                    return;
                }
                if(rs.Equals("T"))
                {
                    Common.ErrorMessageBox("KHÔNG THỂ XÓA","PHIẾU ĐÃ XÁC NHẬN NHẬP KHO");
                    return;
                }
                if(rs.Equals("SUCCESS"))
                {
                    Common.SuccessMessageBox("Xóa phiếu thành công");
                    btnSearch.PerformClick();
                }
            }
            orderid = null;
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(orderid))
            {
                Common.WarningMessageBox("Vui lòng chọn phiếu nhập trước");
                return;
            }
            new frmAddPharmacyOrder(orderid).ShowDialog();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(orderid))
            {
                Common.WarningMessageBox("Vui lòng chọn phiếu nhập trước");
                return;
            }
            if(!isSubmit)
            {
                var rs =  new PharmacyOrder().Submit(orderid);
                if(rs=="T")
                {
                    Common.SuccessMessageBox("Xác nhận thành công");
                    btnSearch.PerformClick();
                    return;
                }
                if(rs=="N")
                {
                    Common.ErrorMessageBox("PHIẾU NHẬP TRỐNG", "Vui lòng nhập thuốc vào trước");
                    new frmAddPharmacyOrder(orderid).ShowDialog();
                }
              
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(orderid))
            {
                Common.WarningMessageBox("Vui lòng chọn phiếu cần in");
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(orderid))
            {
                Common.WarningMessageBox("Vui lòng chọn phiếu cần sửa");
                return;
            }
        }
    }
}
