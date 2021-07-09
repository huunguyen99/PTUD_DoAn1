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
    public partial class frmDienThongTinSinhVienThueTro : Form
    {
        string maPhong;
        int ngayDongTien;
        Boolean gioiTinh;
        int maNhanVien;
        int songuoi;
        decimal giaThue;
        public frmDienThongTinSinhVienThueTro(string maPhongChon, int NgayDongTien, Boolean GioiTinh, int songuoihientai, decimal GiaThue, int maNV)
        {
            InitializeComponent();
            maPhong = maPhongChon;
            ngayDongTien = NgayDongTien;
            if (songuoihientai != 0)
                gioiTinh = GioiTinh;
            else
                gioiTinh = true;
            songuoi = songuoihientai;
            maNhanVien = maNV;
            giaThue = GiaThue;
        }
        clsQLSinhVien clssv;
        clsQLPhieuThue pthue;
        clsQLPhongTro ptr;
        clsQLTruong tr;
        clsQLHoaDon clshd;
        clsChiTietHoaDon clscthd;
        clsQueQuan clsqq;
        IEnumerable<tblQueQuan> dsqq;
        IEnumerable<tblTruong> dstr;
        
        ErrorProvider ep;
        private void FrmDienThongTinSinhVienThueTro_Load(object sender, EventArgs e)
        {
            ep = new ErrorProvider();
            ptr = new clsQLPhongTro();
            clssv = new clsQLSinhVien();
            pthue = new clsQLPhieuThue();
            tr = new clsQLTruong();
            clshd = new clsQLHoaDon();
            clscthd = new clsChiTietHoaDon();
            clsqq = new clsQueQuan();
            dsqq = clsqq.LayDSQueQuan();
            cboQueQuan.DataSource = dsqq;
            cboQueQuan.DisplayMember = "TenTinhThanh";
            cboQueQuan.ValueMember = "TenTinhThanh";
            dstr = tr.LayDSTruong();
            cboTruong.DataSource = dstr;
            cboTruong.DisplayMember = "tenTruong";
            cboTruong.ValueMember = "maTruong";
            XuLyAutoComplete();
        }
        
        
        void XuLyAutoComplete()
        {
            cboTruong.AutoCompleteCustomSource.Clear();
            foreach(tblTruong t in dstr)
            {
                cboTruong.AutoCompleteCustomSource.Add(t.tenTruong);
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
        public tblSinhVien TaoSVThem()
        {
            tblSinhVien p = new tblSinhVien();
            p.email = txtEmail.Text;
            p.soCMND = txtSoCMND.Text;
            p.gioiTinh = rdoNam.Checked == true ? true : false;
            p.maTruong = cboTruong.SelectedValue.ToString();
            p.ngaySinh = dtmNgaySinh.Value;
            p.queQuan = cboQueQuan.SelectedValue.ToString();
            p.SDT = txtSoDT.Text;
            p.tenSV = txtHoTen.Text;
            p.active = true;
            return p;
        }
        tblPhieuThue TaoPhieuThue(int maSVThueTro)
        {
            tblPhieuThue pt = new tblPhieuThue();
            pt.maNV = maNhanVien;
            pt.maSVThuePhong = maSVThueTro;
            pt.ngayThue = DateTime.Now;
            if (songuoi == 0)
                pt.NgayDongTien = DateTime.Now.Day > 28 ? 28 : DateTime.Now.Day;
            else
                pt.NgayDongTien = ngayDongTien;
            pt.maPhong = maPhong;
            return pt;
        }

        tblHoaDon TaoHoaDon()
        {
            tblHoaDon hd = new tblHoaDon();
            hd.maHD = clshd.LayDuLieu().autoMaHD();
            hd.ngayCanLap = DateTime.Now;
            hd.ngayLap = DateTime.Now;
            hd.maNV = maNhanVien;
            hd.tinhTrangHD = false;
            return hd;
        }

        tblCT_HoaDon TaoChiTietHoaDon(string maHD, int mapth)
        {
            tblCT_HoaDon cthd = new tblCT_HoaDon();
            cthd.maHD = maHD;
            cthd.maPhieuThue = mapth;
            cthd.tienDien = 0;
            cthd.tienNuoc = 0;
            cthd.phuPhi = 0;
            cthd.tienWifi = 0;
            cthd.tienGuiXe = 0;
            cthd.TienPhong = giaThue;
            return cthd;
        }


        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim().Length == 0 || txtEmail.Text.Trim().Length == 0 || cboQueQuan.Text.Trim().Length == 0 || txtSoCMND.Text.Trim().Length == 0 || txtSoDT.Text.Trim().Length == 0 || cboTruong.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sinh viên cần thêm!", "Thông báo");
            else if (!txtSoCMND.Text.KtraSCMND())
                ep.SetError(txtSoCMND, "số chứng minh có 9 số và không bắt đầu bằng số 0");
            else if (!txtSoDT.Text.KtraSDT())
                ep.SetError(txtSoDT, "số điện thoại bắt đầu bằng số 0 + số lẻ + 8 số bất kì");
            else if (!txtEmail.Text.KtraEmail())
                ep.SetError(txtEmail, "Email phải theo mẫu abcd123@gmail.com");
            else
            {
                tblSinhVien sv = TaoSVThem();
                tblSinhVien kiemtra = clssv.KiemTraTrungMa(sv.soCMND);
                if (songuoi == 0)
                    gioiTinh = (Boolean)sv.gioiTinh;

                if (DateTime.Now.Year - sv.ngaySinh.Value.Year < 17 || DateTime.Now.Year - sv.ngaySinh.Value.Year > 28)
                    MessageBox.Show("Đối tượng cần thêm không phải sinh viên\nVui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if (sv.gioiTinh != gioiTinh)
                    MessageBox.Show("Giới tính sinh viên không phù hợp\n để thêm vào phòng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if(kiemtra != null)
                    MessageBox.Show("Sinh viên này đã từng thuê phòng ở đây.\nVui lòng chọn chức năng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 else
                {
                    DialogResult HoiThem = MessageBox.Show("Bạn có chắc chắn muốn cho sinh viên này thuê không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (HoiThem == DialogResult.Yes)
                    {
                        if (songuoi == 0)
                        {
                            clssv.Them(sv);
                            tblPhieuThue p = TaoPhieuThue(sv.maSVThueTro);
                            pthue.TaoPhieuThue(p);
                            tblHoaDon hd = TaoHoaDon();
                            clshd.TaoHoaDon(hd);
                            tblCT_HoaDon cthd = TaoChiTietHoaDon(hd.maHD, p.maPhieuThue);
                            clscthd.TaoChiTietHoaDon(cthd);
                            MessageBox.Show("Đăng ký thuê phòng cho sinh viên thành công!", "Thông báo");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            clssv.Them(sv);
                            tblPhieuThue p = TaoPhieuThue(sv.maSVThueTro);
                            pthue.TaoPhieuThue(p);
                            MessageBox.Show("Đăng ký thuê phòng cho sinh viên thành công!", "Thông báo");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
        }

        private void FrmDienThongTinSinhVienThueTro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.KtraEmail())
                ep.Clear();
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

    }
}
