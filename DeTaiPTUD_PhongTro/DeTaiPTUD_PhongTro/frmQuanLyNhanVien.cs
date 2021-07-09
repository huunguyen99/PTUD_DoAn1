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
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }
        clsQLNhanVien clsnv;
        IEnumerable<LayDSNhanVienResult> dsnv;
        ErrorProvider ep;

        private void FrmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            ep = new ErrorProvider();
            clsnv = new clsQLNhanVien();
            dsnv = clsnv.LayDSNV();
            LoadNVLenListView(lvwDSNhanVien, dsnv);
        }

        void ThemItem(ListView lvw, LayDSNhanVienResult p)
        {
            ListViewItem lvwitem = new ListViewItem(p.maNV.ToString());
            lvwitem.SubItems.Add(p.tenNV);
            lvwitem.SubItems.Add(p.soCMND);
            lvwitem.SubItems.Add(p.ngaySinh.Value.ToString("dd/MM/yyyy"));
            lvwitem.SubItems.Add(p.queQuan);
            lvwitem.SubItems.Add(p.diaChi);
            lvwitem.SubItems.Add(p.SDT);
            lvwitem.SubItems.Add(p.email);
            lvwitem.SubItems.Add(p.tenTK);
            lvwitem.SubItems.Add(p.matKhau);
            lvwitem.Tag = p;
            lvw.Items.Add(lvwitem);
        }

        void LoadNVLenListView(ListView lvw, IEnumerable<LayDSNhanVienResult> ds)
        {
            lvw.Items.Clear();
            foreach (LayDSNhanVienResult p in ds)
            {
                ThemItem(lvw, p);
            }
        }

        void TaiHienTuListView(LayDSNhanVienResult nv)
        {
            txtMaNV.Text = nv.maNV.ToString();
            txtDiaChi.Text = nv.diaChi;
            txtSoCMND.Text = nv.soCMND;
            txtEmail.Text = nv.email;
            txtTenNV.Text = nv.tenNV;
            txtDiaChi.Text = nv.diaChi;
            txtSoDT.Text = nv.SDT;
            txtNgaySinh.Text = nv.ngaySinh.Value.ToString("dd/MM/yyyy");
            txtQueQuan.Text = nv.queQuan.ToString();
            txtTaiKhoan.Text = nv.tenTK;
            txtMatKhau.Text = nv.matKhau;
            if (nv.active == true)
                txtTinhTrang.Text = "Vẫn còn làm";
            else
                txtTinhTrang.Text = "Đã nghỉ việc";
        }

        private void LvwDSNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSNhanVien.SelectedItems.Count > 0)
            {
                btnXoaNV.Enabled = true;
                btnSua.Enabled = true;
                nvChon = (LayDSNhanVienResult)lvwDSNhanVien.SelectedItems[0].Tag;
                TaiHienTuListView(nvChon);
                demSua = 1;
                btnSua.Text = "SỬA";
                KhoaTextBox();
            }
            else
            {
                btnXoaNV.Enabled = false;
                btnSua.Enabled = false;
                Clear();
            }
        }


        void Clear()
        {
            txtMaNV.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSoCMND.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSoDT.Clear();
            txtNgaySinh.Clear();
            txtQueQuan.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtTinhTrang.Clear();
        }


        LayDSNhanVienResult nvChon;
        private void BtnXoaNV_Click(object sender, EventArgs e)
        {
            if (nvChon.active == false)
                MessageBox.Show("Nhân viên này đã bị xa thải rồi!", "Thông báo");
            else
            {
                DialogResult HoiXoa = MessageBox.Show("bạn có chắc chắn muốn xa thải nhân viên này không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (HoiXoa == DialogResult.Yes)
                {
                    clsnv.XoaNhanVien(nvChon);
                    MessageBox.Show("Xa thải nhân viên hoàn tất", "Thông báo");
                }
                btnSua.Enabled = false;
                btnSua.Enabled = false;
                Clear();
                LoadNVLenListView(lvwDSNhanVien, dsnv);
            }
        }

        tblNhanVien TaoNhanVienSua()
        {
            tblNhanVien nv = new tblNhanVien();
            nv.diaChi = txtDiaChi.Text;
            nv.email = txtEmail.Text;
            nv.SDT = txtSoDT.Text;
            return nv;
        }

        void MoTextBox()
        {
            txtEmail.ReadOnly = false;
            txtSoDT.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtEmail.Clear();
            txtSoDT.Clear();
            txtDiaChi.Clear();
        }

        void KhoaTextBox()
        {
            txtEmail.ReadOnly = true;
            txtSoDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
        }

        int demSua = 0;
        private void BtnSua_Click(object sender, EventArgs e)
        {
            demSua++;
            if (demSua % 2 == 0)
            {
                btnSua.Text = "LƯU";
                MoTextBox();
            }
            else
            {
                if (txtEmail.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0 || txtSoDT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    demSua--;
                }
                else if(!txtEmail.Text.KtraEmail())
                {
                    ep.SetError(txtEmail, "Email phải theo mẫu abcd123@gmail.com");
                    demSua--;
                }
                else if(!txtSoDT.Text.KtraSDT())
                {
                    ep.SetError(txtSoDT, "số điện thoại bắt đầu bằng số 0 + số lẻ + 8 số bất kì");
                    demSua--;
                }
                else
                {
                    DialogResult HoiSua = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (HoiSua == DialogResult.Yes)
                    {
                        tblNhanVien nv = TaoNhanVienSua();
                        clsnv.SuaNhanVien(nvChon, nv);
                        MessageBox.Show("Sửa thông tin nhân viên hoàn tất!", "Thông báo");
                    }
                    KhoaTextBox();
                    Clear();
                    btnSua.Text = "SỬA";
                    LoadNVLenListView(lvwDSNhanVien, dsnv);
                }
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
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
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.KtraEmail())
                ep.Clear();
        }
        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSoDT.Text.KtraSDT())
                ep.Clear();
        }
    }
}
