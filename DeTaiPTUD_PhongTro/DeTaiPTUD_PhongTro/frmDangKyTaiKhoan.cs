using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiPTUD_PhongTro
{
    public partial class frmDangKyTaiKhoan : Form
    {
        public frmDangKyTaiKhoan()
        {
            InitializeComponent();
        }
        clsQLNhanVien clsnv;
        clsTaiKhoan clstk;
        ErrorProvider ep;
        clsQueQuan clsqq;
        IEnumerable<tblQueQuan> dsqq;
        private void FrmDangKyTaiKhoan_Load(object sender, EventArgs e)
        {
            ep = new ErrorProvider();
            clsnv = new clsQLNhanVien();
            clstk = new clsTaiKhoan(txtTenTK.Text, txtMatKhau.Text);
            clsqq = new clsQueQuan();
            dsqq = clsqq.LayDSQueQuan();
            cboQueQuan.DataSource = dsqq;
            cboQueQuan.DisplayMember = "TenTinhThanh";
            cboQueQuan.ValueMember = "TenTinhThanh";
        }
        tblNhanVien TaoNVThem()
        {
            tblNhanVien p = new tblNhanVien();
            p.tenNV = txtHoTen.Text;
            p.ngaySinh = dtmNgaySinh.Value;
            p.queQuan = cboQueQuan.SelectedValue.ToString();
            p.chucVu = false;
            p.diaChi = txtDiaChi.Text;
            p.soCMND = txtSoCMND.Text;
            p.SDT = txtSoDT.Text;
            p.email = txtEmail.Text;
            p.active = true;
            return p;
        }

        tblTaiKhoan TaoTK(int maNV)
        {
            tblTaiKhoan tk = new tblTaiKhoan();
            tk.tenTK = txtTenTK.Text;
            tk.matKhau = txtMatKhau.Text;
            tk.maNV = maNV;
            return tk;
        }

        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text.Trim().Length == 0 || txtHoTen.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0 || txtEmail.Text.Trim().Length == 0 || txtMatKhau.Text.Trim().Length == 0 || cboQueQuan.Text.Trim().Length == 0 || txtSoCMND.Text.Trim().Length == 0 || txtSoDT.Text.Trim().Length == 0 || txtXacNhanMk.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên!", "Thông báo");
            else if (!txtSoCMND.Text.KtraSCMND())
                ep.SetError(txtSoCMND, "số chứng minh có 9 số và không bắt đầu bằng số 0");
            else if (!txtSoDT.Text.KtraSDT())
                ep.SetError(txtSoDT, "số điện thoại bắt đầu bằng số 0 + số lẻ + 8 số bất kì");
            else if (!txtEmail.Text.KtraEmail())
                ep.SetError(txtEmail, "Email phải theo mẫu abcd123@gmail.com");
            else if(!txtTenTK.Text.KtraTenTK())
                ep.SetError(txtTenTK, "Tên tài khoản có ít nhất 6 kí tự và bắt đầu bằng chữ");
            else if(!txtMatKhau.Text.KtraMatKhau())
                ep.SetError(txtMatKhau, "mật khẩu có ít nhất 8 kí tự và bắt đầu bằng chữ");
            else
            {
                tblNhanVien nv = TaoNVThem();
                if ((DateTime.Now - nv.ngaySinh.Value).TotalDays < 18*365)
                    MessageBox.Show("Nhân viên cần thuê chưa đủ tuổi đi làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if (txtMatKhau.Text.Equals(txtXacNhanMk.Text) == false)
                    MessageBox.Show("Mật khẩu xác nhận không đúng!", "Thông báo");
                else
                {
                    clsnv.ThemNhanVien(nv);
                    tblTaiKhoan t = TaoTK(nv.maNV);
                    tblTaiKhoan KtraTaiKhoan = clstk.KtraTKTonTai(t.tenTK);
                    if (KtraTaiKhoan == null)
                    {
                        DialogResult HoiThem = MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (HoiThem == DialogResult.Yes)
                        {
                            clstk.ThemTaiKhoan(t);
                            this.Close();
                        }
                    }
                    else
                    {
                        clsnv.XoaNVKhiTaoTKLoi(nv);
                        MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo");
                    }
                }
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void TxtSoDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtSoCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtSoCMND_TextChanged(object sender, EventArgs e)
        {
            if (txtSoCMND.Text.KtraSCMND())
                ep.Clear();
        }
        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSoDT.Text.KtraSDT())
                ep.Clear();
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.KtraEmail())
                ep.Clear();
        }

        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTenTK.Text.KtraTenTK())
                ep.Clear();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.KtraMatKhau())
                ep.Clear();
        }
    }
}
