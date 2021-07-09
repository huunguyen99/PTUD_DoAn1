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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        clsTaiKhoan clstk;
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            clstk = new clsTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
        }

        int demDN = 0;

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            LayDSTaiKhoanDangNhapResult tk = clstk.KtraTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
            if (txtTaiKhoan.Text.Trim().Length == 0 || txtMatKhau.Text.Trim().Length == 0)
            {
                demDN++;
                MessageBox.Show("Vui lòng điền đầy đủ thông tin đăng nhập!", "Thông báo");
            }
            else if (tk != null)
            {
                clstk = new clsTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
                frmMenu frmMN = new frmMenu(clstk);
                if(tk.chucVu == false)
                {
                    frmMN.mnuXemDSNhanVien.Enabled = false;
                    frmMN.mnuTimKiemNV.Enabled = false;
                    frmMN.mnuTaoTaiKhoan.Enabled = false;
                    frmMN.mnuXemDSPhong.Enabled = false;
                }
                frmMN.Owner = this;
                if (chkLuuMK.Checked == false)
                    txtMatKhau.Clear();
                this.Hide();
                frmMN.Show();
            }
            else
            {
                demDN++;
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "THÔNG BÁO");
            }
            if (demDN == 3)
            {
                MessageBox.Show("Bạn đã hết quyền đăng nhập! vui lòng truy cập lại!", "THÔNG BÁO");
                Application.Exit();
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
    }
}
