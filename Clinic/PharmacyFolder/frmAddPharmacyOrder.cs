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
    public partial class frmAddPharmacyOrder : Form
    {
        public frmAddPharmacyOrder(string orderid)
        {
            this.orderid = orderid;
            InitializeComponent();            
        }

        #region define_variable
        public string orderid;
        private DataTable dtPharmacy;
        private List<Pharmacy> lstPharmacy;
        private string itemid;
        private string itemname;
        private int rowIndex;
        #endregion end_define_variable
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
            this.Dispose();
        }

        private void frmAddPharmacyOrder_Load(object sender, EventArgs e)
        {
            lblTitle.Text = string.Format("Phiếu nhập kho: {0}", orderid);
            dtPharmacy = new Drug().Select();
            sleDrug.Properties.DataSource = dtPharmacy;
            sleDrug.Properties.DisplayMember = "name";
            sleDrug.Properties.ValueMember = "id";
            var dt = new PharmacyOrderLine().Select(orderid);
            if (dt.Rows.Count>0)
            {
                lstPharmacy = new List<Pharmacy>();
                foreach(DataRow r in dt.Rows)
                {
                    lstPharmacy.Add(new Pharmacy() {
                        id = r["id"].ToString(),
                        name = r["name"].ToString(),
                        unit = r["unit"].ToString(),
                        price = int.Parse(r["price"].ToString()),
                        quantity = int.Parse(r["quantity"].ToString()),
                        manufactureddate = r["manufactureddate"].ToString(),
                        expireddate = r["expireddate"].ToString()                        
                    });
                }
                LoadPharmacy();
                
            }
           
        }
        #region keydown
        private void sleDrug_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtQuantity.Select();
            }
        }

        private void mtbManufacturedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                mtbExpiredDate.Select();
            }
        }

        private void mtbExpiredDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                mtbManufacturedDate.Focus();
            }
        }
        #endregion keydown

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(lstPharmacy==null)
            {
                lstPharmacy = new List<Pharmacy>();
            }
            string id = sleDrug.EditValue.ToString();
            string name = sleDrug.Text;
            int quantity;
            try
            {
                quantity = int.Parse(txtQuantity.Text);
                if(quantity<=0)
                {
                    Common.ErrorMessageBox("Vui lòng nhập số dương", "Lỗi số lượng");
                    txtQuantity.Focus();
                    return;
                }
            }
            catch
            {
                Common.ErrorMessageBox("Vui lòng nhập số nguyên","Lỗi định dạng số");
                txtQuantity.Select();
                return;
            }
            try
            {
                var manufactureddate = DateTime.ParseExact(mtbManufacturedDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                var expireddate = DateTime.ParseExact(mtbExpiredDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if(expireddate<=manufactureddate)
                {
                    Common.ErrorMessageBox("Ngày hết hạn không thể nhỏ hơn ngày sản xuất");
                    mtbExpiredDate.Focus();
                    return;
                }
            }
            catch 
            {
                Common.ErrorMessageBox("Vui lòng nhập theo định dạng: dd/MM/yyyy","Lỗi định dạng ngày tháng");
                mtbManufacturedDate.Focus();
                return;
            }
            var item = lstPharmacy.SingleOrDefault(x=>x.id == id);
            if(item!=null)
            {
                item.quantity += quantity;
            }
            else
            {
                string unit = "";
                int price=0;
                foreach(DataRow r in dtPharmacy.Rows)
                {
                    if(r["id"].ToString().Equals(id))
                    {
                        unit = r["unit"].ToString();
                        price = int.Parse(r["inprice"].ToString());
                        break;
                    }
                }
                lstPharmacy.Add(new Pharmacy() {
                    id = id,
                    name = name,
                    unit = unit,
                    price = price,
                    quantity = quantity,
                    manufactureddate = mtbManufacturedDate.Text,
                    expireddate = mtbExpiredDate.Text
                });
            }
            LoadPharmacy();
        }

        private void LoadPharmacy()
        {
            dgvPharmacy.DataSource = null;
            dgvPharmacy.DataSource = lstPharmacy;
            dgvPharmacy.Columns["id"].HeaderText = "Mã thuốc";
            dgvPharmacy.Columns["name"].HeaderText = "Tên thuốc";
            dgvPharmacy.Columns["manufactureddate"].HeaderText = "Ngày sản xuất";
            dgvPharmacy.Columns["expireddate"].HeaderText = "Ngày hết hạn";
            dgvPharmacy.Columns["quantity"].HeaderText = "SL";
            dgvPharmacy.Columns["unit"].HeaderText = "Đvt";
            dgvPharmacy.Columns["price"].HeaderText = "Đơn giá";
            dgvPharmacy.Columns["sum"].HeaderText = "Thành tiền";

            dgvPharmacy.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["manufactureddate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["expireddate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["sum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPharmacy.Columns["quantity"].DefaultCellStyle.Format = "N0";
            dgvPharmacy.Columns["price"].DefaultCellStyle.Format = "N0";
            dgvPharmacy.Columns["sum"].DefaultCellStyle.Format = "N0";
            dgvPharmacy.Columns["sum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPharmacy.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPharmacy.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(lstPharmacy!=null && lstPharmacy.Count>0)
            {
                var isSuccess = true;
                var rpol = new PharmacyOrderLine();
                foreach(var item in lstPharmacy)
                {
                    if(rpol.Insert(orderid,item.id,item.quantity,item.manufactureddate,item.expireddate)!=1)
                    {
                        Common.ErrorMessageBox("Thêm thuốc "+item.name+" thất bại");
                        isSuccess = false;
                        break;
                    }
                }
                if(isSuccess)
                    this.Dispose();
            }
        }

        private void dgvPharmacy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                itemid = lstPharmacy.ElementAt(e.RowIndex).id;
                itemname = lstPharmacy.ElementAt(e.RowIndex).name;
                rowIndex = e.RowIndex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(itemid) && Common.ConfirmMessage("XÁC NHẬN XÓA THUỐC","Bạn muốn xóa thuốc " +itemname+" ra khỏi danh sách?")==DialogResult.Yes)
            {
                var rs = new PharmacyOrderLine().Delete(orderid, itemid);
                if (rs==1)
                {
                    lstPharmacy.RemoveAt(rowIndex);
                    Common.SuccessMessageBox("Xóa thuốc thành công");
                    LoadPharmacy();
                }
                else
                {
                    Common.ErrorMessageBox("Lỗi xóa thuốc: "+rs);
                }
            }
        }
    }
}
