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
    public partial class frmDangKyChoSVThueLai : Form
    {
        string maPhong;
        int ngayDongtien;
        Boolean gioiTinh;
        int maNhanVien;
        int songuoi;
        decimal giaThue;
        public frmDangKyChoSVThueLai(string MaPhongChon, int NgayDongTien, Boolean GioiTinh, int songuoihientai, decimal GiaThue, int maNV)
        {
            InitializeComponent();
            maPhong = MaPhongChon;
            ngayDongtien = NgayDongTien;
            if (songuoihientai != 0)
                gioiTinh = GioiTinh;
            else
                gioiTinh = true;
            songuoi = songuoihientai;
            maNhanVien = maNV;
            giaThue = GiaThue;
        }

        clsQLSinhVien clssv;
        IEnumerable<LayDSSinhVienKhongConThueResult> dssvKCT;
        clsQLPhieuThue clspt;
        clsQLPhongTro ptr;
        clsQLHoaDon clshd;
        clsChiTietHoaDon clscthd;
        private void FrmDangKyChoSVThueLai_Load(object sender, EventArgs e)
        {
            ptr = new clsQLPhongTro();
            clspt = new clsQLPhieuThue();
            clssv = new clsQLSinhVien();
            clshd = new clsQLHoaDon();
            clscthd = new clsChiTietHoaDon();
            dssvKCT = clssv.LayTatCaSVKhongConThue();
            LoadDSSVLenListView(lvwDSSinhVien, dssvKCT);
            txtSoCMNDSVCanTim.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSoCMNDSVCanTim.AutoCompleteSource = AutoCompleteSource.CustomSource;
            XuLyAutoComplete();
        }

        void TaoItemKhongConThue(ListView lvw, LayDSSinhVienKhongConThueResult s)
        {
            ListViewItem lvwitem = new ListViewItem(s.maSVThueTro.ToString());
            lvwitem.SubItems.Add(s.tenSV);
            lvwitem.SubItems.Add(s.soCMND);
            lvwitem.SubItems.Add(s.ngaySinh.Value.ToString("dd/MM/yyyy"));
            lvwitem.SubItems.Add(s.SDT);
            lvwitem.SubItems.Add(s.email);
            lvwitem.SubItems.Add(s.queQuan);
            if (s.gioiTinh == true)
                lvwitem.SubItems.Add("Nam");
            else
                lvwitem.SubItems.Add("Nữ");
            lvwitem.SubItems.Add(s.maTruong);
            lvwitem.SubItems.Add(s.maPhong);
            lvwitem.SubItems.Add(s.ngayThue.Value.ToString("dd/MM/yyyy"));
            lvwitem.SubItems.Add(s.ngayTra.Value.ToString("dd/MM/yyyy"));
            lvwitem.Tag = s;
            lvw.Items.Add(lvwitem);
        }

        void LoadDSSVLenListView(ListView lvw, IEnumerable<LayDSSinhVienKhongConThueResult> ds)
        {
            lvw.Items.Clear();
            foreach (LayDSSinhVienKhongConThueResult s in ds)
            {
                TaoItemKhongConThue(lvw, s);
            }
        }

        void TaiHienTuListViewSVKhongConThue(LayDSSinhVienKhongConThueResult s)
        {
            txtMaSVThueTro.Text = s.maSVThueTro.ToString();
            txtHoTen.Text = s.tenSV;
            txtSoCMND.Text = s.soCMND;
            txtSoDT.Text = s.SDT;
            txtEmail.Text = s.email;
            txtTruong.Text = s.tenTruong;
            txtNgaySinh.Text = s.ngaySinh.Value.ToString("dd/MM/yyyy");
            txtQueQuan.Text = s.queQuan;
            if (s.gioiTinh == true)
                txtGioiTinh.Text = "Nam";
            else
                txtGioiTinh.Text = "Nữ";
            txtNgayThue.Text = s.ngayThue.Value.ToString("dd/MM/yyyy");
            txtNgayTra.Text = s.ngayTra.Value.ToString("dd/MM/yyyy");
            txtMaPhong.Text = s.maPhong;
        }
        LayDSSinhVienKhongConThueResult svChon;

        private void LvwDSSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwDSSinhVien.SelectedItems.Count > 0)
            {
                btnDangKyThue.Enabled = true;
                svChon = (LayDSSinhVienKhongConThueResult)lvwDSSinhVien.SelectedItems[0].Tag;
                TaiHienTuListViewSVKhongConThue(svChon);
            }
        }

        tblPhieuThue TaoPhieuThue()
        {
            tblPhieuThue pt = new tblPhieuThue();
            pt.maNV = maNhanVien;
            pt.maSVThuePhong = svChon.maSVThueTro;
            pt.ngayThue = DateTime.Now;
            if (ptr.SoNguoiHienTai(maPhong) == 0)
                pt.NgayDongTien = DateTime.Now.Day;
            else
                pt.NgayDongTien = ngayDongtien;
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

        private void BtnDangKyThue_Click(object sender, EventArgs e)
        {
            if (songuoi == 0)
                gioiTinh = (Boolean) svChon.gioiTinh;
            if (svChon.gioiTinh != gioiTinh)
            {
                MessageBox.Show("Giới tính không phù hợp để thêm vào phòng này!", "Thông báo");
            }
            else
            {
                DialogResult HoiThem = MessageBox.Show("Bạn có chắc chắn muốn thêm sinh viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (HoiThem == DialogResult.Yes)
                {
                    if (songuoi == 0)
                    {
                        clssv.DangKyThueLai(svChon.maSVThueTro);
                        tblPhieuThue p = TaoPhieuThue();
                        clspt.TaoPhieuThue(p);
                        tblHoaDon hd = TaoHoaDon();
                        clshd.TaoHoaDon(hd);
                        tblCT_HoaDon cthd = TaoChiTietHoaDon(hd.maHD, p.maPhieuThue);
                        clscthd.TaoChiTietHoaDon(cthd);
                        MessageBox.Show("Đăng ký thuê phòng cho sinh viên thành công!", "Thông báo");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        clssv.DangKyThueLai(svChon.maSVThueTro);
                        tblPhieuThue p = TaoPhieuThue();
                        clspt.TaoPhieuThue(p);
                        MessageBox.Show("Đăng ký thuê phòng cho sinh viên thành công!", "Thông báo");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void FrmDangKyChoSVThueLai_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        IEnumerable<LayDSSinhVienKhongConThueResult> TimKiemSVKhongConThue(string strSoCMND)
        {
            List<LayDSSinhVienKhongConThueResult> dssvTimDuocTam = new List<LayDSSinhVienKhongConThueResult>();
            IEnumerable<LayDSSinhVienKhongConThueResult> dssvSauKhiTim;
            IEnumerable<TimKiemThongTinSinhVienTheoCMNDResult> dssvTimTheoCMND = clssv.TimSVTheoCMND(strSoCMND);
            foreach (LayDSSinhVienKhongConThueResult s in dssvKCT)
            {
                foreach (TimKiemThongTinSinhVienTheoCMNDResult svTimDuoc in dssvTimTheoCMND)
                {
                    if (s.maSVThueTro == svTimDuoc.maSVThueTro && s.ngayThue == svTimDuoc.ngayThue)
                        dssvTimDuocTam.Add(s);
                }
            }
            dssvSauKhiTim = dssvTimDuocTam;
            return dssvSauKhiTim;
        }

        void XuLyAutoComplete()
        {
            txtSoCMNDSVCanTim.AutoCompleteCustomSource.Clear();
            foreach(LayDSSinhVienKhongConThueResult s in dssvKCT)
            {
                txtSoCMNDSVCanTim.AutoCompleteCustomSource.Add(s.soCMND);
            }
        }

        void Clear()
        {
            txtEmail.Clear();
            txtGioiTinh.Clear();
            txtHoTen.Clear();
            txtMaPhong.Clear();
            txtMaSVThueTro.Clear();
            txtNgaySinh.Clear();
            txtNgayThue.Clear();
            txtNgayTra.Clear();
            txtQueQuan.Clear();
            txtSoCMND.Clear();
            txtSoDT.Clear();
            txtTruong.Clear();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string strSoCMND = txtSoCMNDSVCanTim.Text;
            if (txtSoCMNDSVCanTim.Text == "")
                MessageBox.Show("Vui lòng nhập thông tin sinh viên bạn cần tìm!", "Thông báo");
            IEnumerable<LayDSSinhVienKhongConThueResult> dssvTimDuoc = TimKiemSVKhongConThue(strSoCMND);
            if (dssvTimDuoc.Count() == 0)
                MessageBox.Show("Sinh viên bạn cần tìm không có!", "Thông báo");
            else
                LoadDSSVLenListView(lvwDSSinhVien, dssvTimDuoc);
            Clear();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDSSVLenListView(lvwDSSinhVien, dssvKCT);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
