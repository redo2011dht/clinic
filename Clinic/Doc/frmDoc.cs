using Clinic.Report;
using DevExpress.XtraEditors.Controls;
using ReDo;
using ReDoReportForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Document
{
    public partial class frmReception : Form
    {
        public frmReception()
        {
            InitializeComponent();
        }
        #region click
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Common.f.WindowState = FormWindowState.Normal;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isNewPatient = false;
            btnAdd.Enabled = btnAddNewPatient.Enabled = btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtFullname.Focus();
        }
        #endregion click
        private void frmReception_Load(object sender, EventArgs e)
        {
            ComboboxItem item = new ComboboxItem();
            item.Value = "M";
            item.Text = "Nam";
            cbbGender.Items.Add(item);
            ComboboxItem item1 = new ComboboxItem();
            item1.Value = "F";
            item1.Text = "Nữ";
            cbbGender.Items.Add(item1);
            cbbGender.SelectedIndex = 0;
            cbbGender.DisplayMember = "Text";
            mtbFromdate.Text = DateTime.Now.ToString("01/MM/yyyy 00:01");
            mtbTodate.Text = DateTime.Now.ToString("dd/MM/yyyy 23:59");
            btnSearch.PerformClick();
            var st = new Systems();
            string[] arrAddress = st.Address().AsEnumerable()
                           .Select(r => r.Field<string>("sys_address"))
                           .ToArray();
            actAddress.Values = arrAddress;
            string[] arrSymptom = st.Symptom().AsEnumerable()
                           .Select(r => r.Field<string>("symptom"))
                           .ToArray();
            actSymptom.Values = arrSymptom;

            string[] icd = st.Icd().AsEnumerable()
                          .Select(r => r.Field<string>("hi_fullname"))
                          .ToArray();
            actDiagnostic.Values = icd;
            string[] advices = st.Advice().AsEnumerable()
                         .Select(r => r.Field<string>("advice"))
                         .ToArray();
            actAdvice.Values = advices;


            string[] usages = st.DrugUsage().AsEnumerable()
                         .Select(r => r.Field<string>("drugusage"))
                         .ToArray();
            actUsage.Values = usages;

            feelist = st.FeeList();
            sleFee.Properties.DataSource = st.FeeList();
            //sleFee.Properties.Columns["feeid"].Caption = "Mã";
            //sleFee.Properties.Columns["name"].Caption = "Tên dịch vụ";
            sleFee.Properties.DisplayMember = "name";
            sleFee.Properties.ValueMember = "feeid";
            sleFee.Properties.BestFitMode = BestFitMode.BestFit;

            tblDrug = new Drug().Select();
            sleDrug.Properties.DataSource = tblDrug;
            sleDrug.Properties.DisplayMember = "name";
            sleDrug.Properties.ValueMember = "id";
            sleDrug.Properties.BestFitMode = BestFitMode.BestFit;

            if (status == null || status == "T")
            {
                SetEnableComponents(false);
            }
            s = new Systems();
            lblTitle.Text = string.Format("{0} [{1}]", s.SelectValue("clinic_name"), s.SelectValue("clinic_address"));

            cbbDoctor.DataSource = new Doctor().Select();
            cbbDoctor.DisplayMember = "fullname";
            cbbDoctor.ValueMember = "username";
            cbbDoctor.SelectedIndex = -1;

            txtSearch.Select();

        }
        private DataTable dt;
        private DataGridViewRow selectedRow;
        private List<Fee> lstFee;
        private DataTable feelist;
        private DataTable tblDrug;
        private bool isNewPatient = false;
        private string status = null;
        private long docno = 0;
        private Systems s;
        private class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string patientno = txtPatientno.Text;
                string fullname = txtFullname.Text;
                string birthdate = mtbBirthdate.Text;
                string gender = (cbbGender.SelectedItem as ComboboxItem).Value;
                string phone = txtPhone.Text;
                string address = actAddress.Text;


                if (string.IsNullOrEmpty(fullname))
                {
                    Common.WarningMessageBox("Vui lòng nhập tên bệnh nhân");
                    txtFullname.Focus();
                    return;
                }
                try
                {
                    var date = DateTime.ParseExact(mtbBirthdate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    Common.ErrorMessageBox("Vui lòng nhập định dạng ngày sinh dd/mm/yyyy");
                    mtbBirthdate.Focus();
                    return;
                }
                if (isNewPatient)
                {
                    patientno = new Patients().Insert(fullname, birthdate, gender, phone, address);
                    status = "O";
                }

                txtPatientno.Text = patientno;
                long docno = new Docs().Insert(patientno);
                txtDocno.Text = docno.ToString();
                btnSave.Enabled = false;
                btnAdd.Enabled = btnUpdate.Enabled = btnAddNewPatient.Enabled = true;
                isNewPatient = false;
                if (docno == 0)
                {
                    Common.WarningMessageBox("Hồ sơ khám chưa kết thúc, không thể tạo hồ sơ mới");
                }
                docno = long.Parse(txtDocno.Text);
                SetEnableComponents(true);
                if (lstFee == null)
                {
                    lstFee = new List<Fee>();
                    var r = new Systems().Examination();
                    lstFee.Add(new Fee()
                    {
                        id = r["id"].ToString(),
                        name = r["name"].ToString(),
                        price = int.Parse(r["price"].ToString()),
                        quantity = 1,
                        type = "S",
                        unit = r["unit"].ToString()
                    });
                }
                mtbExamDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                cbbDoctor.Focus();
            }
            catch (Exception ex)
            {
                Common.ErrorMessageBox("Lỗi tạo hồ sơ: " + ex.Message);
            }
        }
        #region key_dow
        private void txtFullname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFullname.Text = ReDo.Common.FormatString(txtFullname.Text);
                mtbBirthdate.Focus();
            }
        }

        private void mtbBirthdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbbGender.Focus();
        }

        private void cbbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPhone.Focus();
        }
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                actAddress.Focus();
        }
        private void actAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion key_down

        private void SetEnableComponents(bool b)
        {
            grbExam.Enabled = grbFee.Enabled = grbSubClinic.Enabled = grbDrug.Enabled = b;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fromdate = mtbFromdate.Text;
            string todate = mtbTodate.Text;
            string searchKey = txtSearch.Text;
            try
            {
                var date1 = DateTime.ParseExact(mtbFromdate.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                var date2 = DateTime.ParseExact(mtbTodate.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Common.ErrorMessageBox("Vui lòng nhập định dạng ngày tháng dd/MM/yyyy hh:mm");
                return;
            }
            fromdate = fromdate.Split('/')[2].Split(' ')[0] + "-" + fromdate.Split('/')[1] + "-" + fromdate.Split('/')[0] + " " + fromdate.Split(' ')[1];
            todate = todate.Split('/')[2].Split(' ')[0] + "-" + todate.Split('/')[1] + "-" + todate.Split('/')[0] + " " + todate.Split(' ')[1];
            dt = new Patients().Select(fromdate, todate, searchKey);
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = dt;
            dgvPatients.Columns["patientno"].HeaderText = "Mã BN";
            dgvPatients.Columns["patientno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPatients.Columns["docno"].HeaderText = "Mã HS";
            dgvPatients.Columns["docno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPatients.Columns["fullname"].HeaderText = "Họ tên";
            dgvPatients.Columns["fullname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPatients.Columns["gender"].HeaderText = "Giới tính";
            dgvPatients.Columns["gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPatients.Columns["phone"].HeaderText = "Số ĐT";
            dgvPatients.Columns["phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPatients.Columns["address"].HeaderText = "Địa chỉ";
            dgvPatients.Columns["address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPatients.Columns["status"].HeaderText = "Trạng thái";
            dgvPatients.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatients.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgvPatients.Rows[e.RowIndex];
                tbcMain.SelectedTabPageIndex = 1;
                string patientno = selectedRow.Cells["patientno"].Value.ToString();
                txtPatientno.Text = selectedRow.Cells["patientno"].Value.ToString();
                txtDocno.Text = selectedRow.Cells["docno"].Value.ToString();
                txtFullname.Text = selectedRow.Cells["fullname"].Value.ToString();
                mtbBirthdate.Text = selectedRow.Cells["birthdate"].Value.ToString();
                cbbGender.SelectedIndex = selectedRow.Cells["gender"].Value.ToString() == "Nam" ? 0 : 1;
                txtPhone.Text = selectedRow.Cells["phone"].Value.ToString();
                actAddress.Text = selectedRow.Cells["address"].Value.ToString();
                btnAdd.Enabled = btnAddNewPatient.Enabled = btnUpdate.Enabled = true;
                btnSave.Enabled = false;
                status = selectedRow.Cells["status"].Value.ToString();
                if (status == "O")
                {
                    SetEnableComponents(true);
                    mtbExamDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    cbbDoctor.Focus();
                }
                else
                {
                    SetEnableComponents(false);
                }

                //---show lịch sử khám
                dgvHistoryExam.DataSource = null;
                dgvHistoryExam.DataSource = new Docs().History(patientno);
                dgvHistoryExam.Columns["docno"].HeaderText="Mã hồ sơ";
                dgvHistoryExam.Columns["docno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryExam.Columns["examdate"].HeaderText = "Ngày khám";
                dgvHistoryExam.Columns["examdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryExam.Columns["diagnostic"].HeaderText = "Chẩn đoán";
                dgvHistoryExam.Columns["diagnostic"].MinimumWidth = 240;
                //end show lskcb(.

            }
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            txtPatientno.Text = txtDocno.Text = txtFullname.Text = mtbBirthdate.Text = txtPhone.Text = actAddress.Text = null;
            txtFullname.Focus();
            isNewPatient = true;
            btnAdd.Enabled = btnAddNewPatient.Enabled = btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtFullname.Focus();
            btnAdd.Enabled = btnAddNewPatient.Enabled = btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnAddFee_Click(object sender, EventArgs e)
        {
            if (lstFee == null)
            {
                lstFee = new List<Fee>();
                var r = new Systems().Examination();
                lstFee.Add(new Fee()
                {
                    id = r["id"].ToString(),
                    name = r["name"].ToString(),
                    price = int.Parse(r["price"].ToString()),
                    quantity = 1,
                    type = "S",
                    unit = r["unit"].ToString()
                });
            }
            string feeid = sleFee.EditValue.ToString();

            if (string.IsNullOrEmpty(feeid))
            {
                Common.WarningMessageBox("Vui lòng chọn mục cls");
                return;
            }
            var rs = lstFee.FirstOrDefault(x => x.type == "S" && x.id == feeid);
            if (rs != null)
            {
                if (Common.ConfirmMessage("Mục phí đã tồn tại", "Bạn vẫn muốn thêm?") == DialogResult.Yes)
                {
                    rs.quantity += 1;
                }
            }
            else
            {
                Fee fee = new Fee();
                foreach (DataRow r in feelist.Rows)
                {
                    if (r["feeid"].ToString() == feeid)
                    {
                        fee.id = feeid;
                        fee.name = r["name"].ToString();
                        fee.unit = r["unit"].ToString();
                        fee.quantity = 1;
                        fee.price = int.Parse(r["price"].ToString());
                        fee.type = "S";
                        break;
                    }
                }
                lstFee.Add(fee);
            }
            LoadFeeList();
            sleFee.Focus();
        }

        private void LoadFeeList()
        {
            dgvFeeList.DataSource = null;
            dgvFeeList.DataSource = lstFee.Where(x => x.type == "S").ToList();
            dgvFeeList.Columns["name"].HeaderText = "Dịch vụ kỹ thuật";
            dgvFeeList.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFeeList.Columns["unit"].HeaderText = "Đvt";
            dgvFeeList.Columns["unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvFeeList.Columns["quantity"].HeaderText = "Sl";
            dgvFeeList.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvFeeList.Columns["price"].HeaderText = "ĐG";
            dgvFeeList.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFeeList.Columns["price"].DefaultCellStyle.Format = "N0";
            dgvFeeList.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvFeeList.Columns["sum"].HeaderText = "Thành tiền";
            dgvFeeList.Columns["sum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvFeeList.Columns["sum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFeeList.Columns["sum"].DefaultCellStyle.Format = "N0";

            dgvFeeList.Columns["id"].Visible = false;
            dgvFeeList.Columns["usage"].Visible = false;
            dgvFeeList.Columns["type"].Visible = false;
        }


        private void btnAddDrug_Click(object sender, EventArgs e)
        {
            if (lstFee == null)
            {
                lstFee = new List<Fee>();
                var r = new Systems().Examination();
                lstFee.Add(new Fee()
                {
                    id = r["id"].ToString(),
                    name = r["name"].ToString(),
                    price = int.Parse(r["price"].ToString()),
                    quantity = 1,
                    type = "S",
                    unit = r["unit"].ToString()
                });
            }
            var id = sleDrug.EditValue.ToString();
            if (string.IsNullOrEmpty(id))
            {
                Common.WarningMessageBox("Vui lòng chọn thuốc");
                sleDrug.Focus();
                return;
            }
            var drug = lstFee.FirstOrDefault(x => x.id == id);
            if (drug != null && DialogResult.Yes == Common.ConfirmMessage("Thuốc đã kê!!!!!!!!!!", "Bạn vẫn muốn kê thêm?"))
            {
                drug.quantity += int.Parse(txtQuantity.Text);
            }
            else
            {
                if (drug == null)
                    foreach (DataRow r in tblDrug.Rows)
                    {
                        if (r["id"].ToString() == id)
                        {
                            lstFee.Add(new Fee()
                            {
                                id = id,
                                name = r["name"].ToString(),
                                unit = r["unit"].ToString(),
                                price = int.Parse(txtPrice.Text),
                                quantity = int.Parse(txtQuantity.Text),
                                usage = actUsage.Text,
                                type = "D"
                            });
                            break;
                        }
                    }
            }
            ShowDrugOrder();
            sleDrug.Focus();
        }

        private void ShowDrugOrder()
        {
            dgvPharmacy.DataSource = null;
            dgvPharmacy.DataSource = lstFee.Where(x => x.type == "D").ToList();
            dgvPharmacy.Columns["name"].HeaderText = "Tên thuốc";
            dgvPharmacy.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["unit"].HeaderText = "Đvt";
            dgvPharmacy.Columns["unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["price"].HeaderText = "Đơn giá";
            dgvPharmacy.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["price"].DefaultCellStyle.Format = "N0";
            dgvPharmacy.Columns["quantity"].HeaderText = "SL";
            dgvPharmacy.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["usage"].HeaderText = "Hướng dẫn sử dụng";
            dgvPharmacy.Columns["sum"].HeaderText = "Thành tiền";
            dgvPharmacy.Columns["sum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPharmacy.Columns["sum"].DefaultCellStyle.Format = "N0";
            dgvPharmacy.Columns["id"].Visible = false;
            dgvPharmacy.Columns["type"].Visible = false;
        }

        private void sleDrug_EditValueChanged(object sender, EventArgs e)
        {
            var id = sleDrug.EditValue.ToString();
            foreach (DataRow r in tblDrug.Rows)
            {
                if (r["id"].ToString() == id)
                {
                    txtPrice.Text = r["outprice"].ToString();
                    break;
                }
            }
            txtQuantity.Focus();
        }





        private void btnFinishDoc_Click(object sender, EventArgs e)
        {
            try
            {
                //cap nhat lai thong tin ho so kham
                if(cbbDoctor.SelectedIndex==-1)
                {
                    Common.WarningMessageBox("Vui lòng chọn bác sỹ khám");
                    xtcExam.SelectedTabPageIndex = 0;
                    cbbDoctor.Focus();
                    return;
                }
                string doctor = cbbDoctor.SelectedValue.ToString();
               
                try
                {
                    var date = DateTime.ParseExact(mtbExamDate.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    Common.ErrorMessageBox("Vui lòng nhập định dạng ngày khám dd/mm/yyyy HH:mm");
                    xtcExam.SelectedTabPageIndex = 0;
                    mtbExamDate.Focus();
                    return;
                }
                string examdate = mtbExamDate.Text;

                string diagnostic = actDiagnostic.Text;
                if (string.IsNullOrEmpty(diagnostic))
                {
                    Common.ErrorMessageBox("Vui lòng nhập chẩn đoán");
                    xtcExam.SelectedTabPageIndex = 0;
                    actDiagnostic.Focus();
                    return;
                }
                string patientno = txtPatientno.Text;

                try
                {
                    docno = long.Parse(txtDocno.Text);
                }
                catch
                {
                    Common.ErrorMessageBox("Số hồ sơ không hợp lệ");
                }
                string symptom = actSymptom.Text;
                string advice = actAdvice.Text;
                if (new Docs().Confirm(docno, patientno, symptom, diagnostic, advice,examdate,doctor) != 1)
                {
                    Common.ErrorMessageBox("Lỗi tạo hồ sơ khám");
                    return;
                }
                //----> ket thuc phan cap nhat ho so kham

                //xu ly don thuoc

                if ((lstFee == null || lstFee.Where(x => x.type == "D").ToList().Count == 0) && DialogResult.No == Common.ConfirmMessage("Chưa kê thuốc", "Bạn vẫn muốn tiếp tục?"))
                {
                    xtcExam.SelectedTabPageIndex = 2;
                    return;
                }

                if (lstFee != null && lstFee.Where(x => x.type == "D").ToList().Count > 0)
                {
                    long id = new DrugOrder().Insert(docno, doctor, examdate, examdate);
                    if (id > 0)
                    {
                        var chk = true;
                        foreach (var t in lstFee.Where(x => x.type == "D").ToList())
                        {
                            var rs = new DrugOrderLine().Insert(id, t.id, t.price, t.quantity, t.usage);
                            if (rs == 0)
                            {
                                chk = false;
                                Common.ErrorMessageBox("Số lượng thuốc không đủ");
                                break;
                            }
                            if (rs == -1)
                            {
                                chk = false;
                                break;
                            }

                        }
                        if (!chk)
                            return;
                    }
                    else
                    {
                        Common.WarningMessageBox("Thêm đơn thuốc thất bại");
                        return;
                    }
                }
                // ket thuc xu ly don thuoc

                //xu ly cls
                if (lstFee != null && lstFee.Where(x => x.type == "S").ToList().Count > 0)
                {
                    long orderid = new FeeOrder().Insert(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), docno, "admin");
                    if (orderid > 0)
                    {
                        var chk = true;
                        foreach (var item in lstFee.Where(x => x.type == "S").ToList())
                        {
                            if (new FeeOrderLine().Insert(orderid, item.id, item.quantity, item.price) <= 0)
                            {
                                chk = false;
                                break;
                            }
                        }
                        if (!chk)
                        {
                            Common.ErrorMessageBox("Thêm phí dịch vụ thất bại");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                //---> ket thuc xu ly cls

                //in đơn thuốc
                if (ckbDrugPrint.Checked)
                {
                    frmDrugReport f = new frmDrugReport();
                    f.PrintOrder(s.SelectValue("clinic_name"), s.SelectValue("clinic_phone"), s.SelectValue("clinic_address"), txtPatientno.Text, txtDocno.Text, DateTime.Now.ToString("dd/MM/yyyy HH:mm"), txtFullname.Text, mtbBirthdate.Text, cbbGender.Text, actAddress.Text, txtPhone.Text, actSymptom.Text, actDiagnostic.Text, actAdvice.Text,cbbDoctor.Text, lstFee.Where(x => x.type == "D").ToList());
                    f.ShowInTaskbar = false;
                    f.ShowDialog();
                }

                //--->kết thúc in đơn thuốc


                //  in hóa đơn
                if (ckbPrint.Checked)
                {
                    frmInvoiceReport frm = new frmInvoiceReport();
                    frm.Invoice(s.SelectValue("clinic_name"), s.SelectValue("clinic_phone"), s.SelectValue("clinic_address"), txtPatientno.Text, txtDocno.Text, DateTime.Now.ToString("dd/MM/yyyy HH:mm"), txtFullname.Text, mtbBirthdate.Text, cbbGender.Text, actAddress.Text, txtPhone.Text, actSymptom.Text, actDiagnostic.Text, actAdvice.Text,cbbDoctor.Text, lstFee);
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                }
                //----->kết thúc in hóa đơn   
                lstFee = null;
                dgvFeeList.DataSource = null;
                dgvFees.DataSource = null;
                dgvPharmacy.DataSource = null;
                btnSearch.PerformClick();
                SetEnableComponents(false);
                ResetComponents();
            }
            catch (Exception ex)
            {
                Common.ErrorMessageBox("Lỗi kết thúc hồ sơ: " + ex.Message);
            }
           
        }
        private void ResetComponents()
        {
            txtDocno.Text = txtFullname.Text = txtPatientno.Text = txtPhone.Text = null;
            txtPrice.Text = txtQuantity.Text = null;
            actSymptom.Text = actAddress.Text = actAdvice.Text = actDiagnostic.Text = null;
            mtbBirthdate.Text = null;
            cbbDoctor.SelectedIndex = -1;
        }
        private void xtcExam_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            if (e.PageIndex == 3 && lstFee != null && lstFee.Count > 0)
            {
                dgvFees.DataSource = null;
                dgvFees.DataSource = lstFee;
                dgvFees.Columns["id"].Visible = false;
                dgvFees.Columns["usage"].Visible = false;
                dgvFees.Columns["type"].Visible = false;
                dgvFees.Columns["name"].HeaderText = "Tên thuốc/dịch vụ";
                dgvFees.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvFees.Columns["unit"].HeaderText = "Đvt";
                dgvFees.Columns["unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFees.Columns["price"].HeaderText = "Đơn giá";
                dgvFees.Columns["price"].DefaultCellStyle.Format = "N0";
                dgvFees.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFees.Columns["quantity"].HeaderText = "SL";
                dgvFees.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFees.Columns["quantity"].DefaultCellStyle.Format = "N0";
                dgvFees.Columns["sum"].HeaderText = "Thành tiền";
                dgvFees.Columns["sum"].DefaultCellStyle.Format = "N0";
                dgvFees.Columns["sum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        #region keydown
        private void cbbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                actSymptom.Focus();
            }
        }
        private void actSymptom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                actDiagnostic.Focus();
            }
        }

        private void actDiagnostic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                actAdvice.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Focus();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                actUsage.Focus();
            }
        }

        private void actUsage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddDrug.PerformClick();
            }
        }

        private void actAdvice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                xtcExam.SelectedTabPageIndex = 1;
                sleFee.Focus();
            }
        }
        #endregion keydown

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

        private void dgvHistoryExam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string docno = dgvHistoryExam.Rows[e.RowIndex].Cells["docno"].Value.ToString();
            //show thông tin khám hồ sơ cũ
            List<Fee> lstDrug = new List<Fee>();
            var dt = new DrugOrderLine().Select(long.Parse(docno));
            foreach(DataRow r in dt.Rows)
            {
                lstDrug.Add(new Fee() {
                    name = r["name"].ToString(),
                    unit = r["unit"].ToString(),
                    price = int.Parse(r["price"].ToString()),
                    quantity = int.Parse(r["quantity"].ToString()),
                    usage = r["usage"].ToString()
                });
            }
            DataRow doc = new Docs().Select(long.Parse(docno));
            frmDrugReport frm = new frmDrugReport();
            frm.PrintOrder(s.SelectValue("clinic_name"), s.SelectValue("clinic_phone"), 
                    s.SelectValue("clinic_address"), txtPatientno.Text, docno, 
                    doc["examdate"].ToString(), 
                    txtFullname.Text, mtbBirthdate.Text, cbbGender.Text, actAddress.Text, 
                    txtPhone.Text, actSymptom.Text, doc["diagnostic"].ToString(), doc["advice"].ToString(),doc["doctor"].ToString(), lstDrug);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            //-----kết thúc show thông tin khám hồ sơ cũ
        }

        private void txtFullname_Leave(object sender, EventArgs e)
        {
            txtFullname.Text = ReDo.Common.FormatString(txtFullname.Text);
        }

      
    }
}
