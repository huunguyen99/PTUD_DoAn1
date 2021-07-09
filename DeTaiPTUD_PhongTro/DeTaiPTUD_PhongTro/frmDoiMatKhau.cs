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
    public partial class frmDoiMatKhau : Form
    {
        private string strTK;
        private string strMK;
        public string StrTK { get => strTK; set => strTK = value; }
        public string StrMK { get => strMK; set => strMK = value; }
        public frmDoiMatKhau(string TK, string MK)
        {
            InitializeComponent();
            StrTK = TK;
            StrMK = MK;
        }

        clsTaiKhoan clstk;
        ErrorProvider ep;

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            ep = new ErrorProvider();
            clstk = new clsTaiKhoan(StrTK, StrMK);
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            LayDSTaiKhoanDangNhapResult tkCanSua = clstk.KtraTaiKhoan(strTK, strMK);
            if (txtMatKhauHienTai.Text.Trim().Length == 0 || txtMatKhauMoi.Text.Trim().Length == 0 || txtXacNhanMatKhauMoi.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if(!txtMatKhauMoi.Text.KtraMatKhau())
                ep.SetError(txtMatKhauMoi, "mật khẩu có ít nhất 8 kí tự và bắt đầu bằng chữ cái");
            else if (tkCanSua.matKhau.Equals(txtMatKhauHienTai.Text) && txtMatKhauMoi.Text.Equals(txtXacNhanMatKhauMoi.Text))
            {
                DialogResult HoiSua = MessageBox.Show("Bạn có chắc chắn muốn thay đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (HoiSua == DialogResult.Yes)
                {
                    clstk.DoiMatKhau(tkCanSua, txtMatKhauMoi.Text);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                    this.Close();
                }
            }
            else if (tkCanSua.matKhau.Equals(txtMatKhauHienTai.Text) == false)
                MessageBox.Show("Mật khẩu hiện tại không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (txtMatKhauMoi.Text.Equals(txtXacNhanMatKhauMoi.Text) == false)
                MessageBox.Show("Mật khẩu xác nhận sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.KtraMatKhau())
                ep.Clear();
        }
    }
}
