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
    public partial class frmTimKiemSV : Form
    {
        public frmTimKiemSV()
        {
            InitializeComponent();
        }

        clsQLSinhVien sv;
        IEnumerable<LayDSSinhVienConThueResult> dssvConThue;
        IEnumerable<LayDSSinhVienKhongConThueResult> dssvKhongConThue;

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmTimKiemSV_Load(object sender, EventArgs e)
        {
            sv = new clsQLSinhVien();
            dssvConThue = sv.LayTatCaSVConThue();
            dssvKhongConThue = sv.LayTatCaSVKhongConThue();
            if (rdoLoadDanhSachSinhVienConThue.Checked == true)
                LoadDSSVLenListView(lvwDSSinhVien);
            else
                LoadDSSVLenListView(lvwDSSinhVien);
            txtGiaTriTim.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtGiaTriTim.AutoCompleteSource = AutoCompleteSource.CustomSource;
            XuLyAutoComplete();
        }

        void TaoItemConThue(ListView lvw, LayDSSinhVienConThueResult s)
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
            lvwitem.SubItems.Add("Chưa trả");
            lvwitem.Tag = s;
            lvw.Items.Add(lvwitem);
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

        void LoadDSSVLenListView(ListView lvw)
        {
            lvw.Items.Clear();
            if (rdoLoadDanhSachSinhVienConThue.Checked == true)
            {
                foreach (LayDSSinhVienConThueResult s in dssvConThue)
                {
                    TaoItemConThue(lvw, s);
                }
            }
            else
            {
                foreach (LayDSSinhVienKhongConThueResult s in dssvKhongConThue)
                {
                    TaoItemKhongConThue(lvw, s);
                }
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
        void TaiHienTuListViewSVConThue(LayDSSinhVienConThueResult s)
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
            txtNgayTra.Text = "Chưa trả";
            txtMaPhong.Text = s.maPhong;
        }

        LayDSSinhVienConThueResult svCTChon;
        LayDSSinhVienKhongConThueResult svKCTChon;
        private void LvwDSSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwDSSinhVien.SelectedItems.Count > 0)
            {
                if(rdoLoadDanhSachSinhVienConThue.Checked == true)
                {
                    svCTChon = (LayDSSinhVienConThueResult)lvwDSSinhVien.SelectedItems[0].Tag;
                    TaiHienTuListViewSVConThue(svCTChon);
                }
                else
                {
                    svKCTChon = (LayDSSinhVienKhongConThueResult)lvwDSSinhVien.SelectedItems[0].Tag;
                    TaiHienTuListViewSVKhongConThue(svKCTChon);
                }
            }

        }

        private void RdoLoadDanhSachSinhVienConThue_CheckedChanged(object sender, EventArgs e)
        {
            LoadDSSVLenListView(lvwDSSinhVien);
            XuLyAutoComplete();
            Clear();
        }

        private void RdoLoadDanhSachSinhVienKhongConThue_CheckedChanged(object sender, EventArgs e)
        {
            LoadDSSVLenListView(lvwDSSinhVien);
            XuLyAutoComplete();
            Clear();
        }

        void XuLyAutoComplete()
        {
            if (rdoLoadDanhSachSinhVienConThue.Checked == true)
            {
                txtGiaTriTim.AutoCompleteCustomSource.Clear();
                if (rdoTimTheoCMND.Checked == true)
                {
                    txtGiaTriTim.AutoCompleteCustomSource.Clear();
                    foreach (LayDSSinhVienConThueResult n in dssvConThue)
                    {
                        txtGiaTriTim.AutoCompleteCustomSource.Add(n.soCMND);
                    }
                }
                else if(rdoTimTheoTen.Checked == true)
                {
                    txtGiaTriTim.AutoCompleteCustomSource.Clear();
                    foreach (LayDSSinhVienConThueResult n in dssvConThue)
                    {
                        txtGiaTriTim.AutoCompleteCustomSource.Add(n.tenSV);
                    }
                }
            }
            else if(rdoLoadDanhSachSinhVienKhongConThue.Checked == true)
            {
                txtGiaTriTim.AutoCompleteCustomSource.Clear();
                if (rdoTimTheoCMND.Checked == true)
                {
                    txtGiaTriTim.AutoCompleteCustomSource.Clear();
                    foreach (LayDSSinhVienKhongConThueResult n in dssvKhongConThue)
                    {
                        txtGiaTriTim.AutoCompleteCustomSource.Add(n.soCMND);
                    }
                }
                else if( rdoTimTheoTen.Checked == true)
                {
                    txtGiaTriTim.AutoCompleteCustomSource.Clear();
                    foreach (LayDSSinhVienKhongConThueResult n in dssvKhongConThue)
                    {
                        txtGiaTriTim.AutoCompleteCustomSource.Add(n.tenSV);
                    }
                }
            }
        }

        IEnumerable<LayDSSinhVienConThueResult> TimKiemSVConThue(string strGiaTriTim)
        {
            List<LayDSSinhVienConThueResult> dssvTimDuoc = new List<LayDSSinhVienConThueResult>();
            IEnumerable<LayDSSinhVienConThueResult> dssvSauKhiTim;
            if (rdoTimTheoCMND.Checked == true)
            {
                IEnumerable<TimKiemThongTinSinhVienTheoCMNDResult> dssvTimTheoCMND = sv.TimSVTheoCMND(strGiaTriTim);
                foreach(LayDSSinhVienConThueResult s in dssvConThue)
                {
                    foreach (TimKiemThongTinSinhVienTheoCMNDResult svTimDuoc in dssvTimTheoCMND)
                    {
                        if (s.maSVThueTro == svTimDuoc.maSVThueTro)
                            dssvTimDuoc.Add(s);
                    }
                }
                dssvSauKhiTim = dssvTimDuoc;
            }
            else
            {
                IEnumerable<TimKiemThongTinSinhVienTheoTenResult> dssvTimTheoTen = sv.TimSVTheoTen(strGiaTriTim);
                foreach (LayDSSinhVienConThueResult s in dssvConThue)
                {
                    foreach (TimKiemThongTinSinhVienTheoTenResult svTimDuoc in dssvTimTheoTen)
                    {
                        if (s.maSVThueTro == svTimDuoc.maSVThueTro)
                            dssvTimDuoc.Add(s);
                    }
                }
                dssvSauKhiTim = dssvTimDuoc;
            }
            return dssvSauKhiTim;
        }

        IEnumerable<LayDSSinhVienKhongConThueResult> TimKiemSVKhongConThue(string strGiaTriTim)
        {
            List<LayDSSinhVienKhongConThueResult> dssvTimDuoc = new List<LayDSSinhVienKhongConThueResult>();
            IEnumerable<LayDSSinhVienKhongConThueResult> dssvSauKhiTim;
            if (rdoTimTheoCMND.Checked == true)
            {
                IEnumerable<TimKiemThongTinSinhVienTheoCMNDResult> dssvTimTheoCMND = sv.TimSVTheoCMND(strGiaTriTim);
                foreach (LayDSSinhVienKhongConThueResult s in dssvKhongConThue)
                {
                    foreach (TimKiemThongTinSinhVienTheoCMNDResult svTimDuoc in dssvTimTheoCMND)
                    {
                        if (s.maSVThueTro == svTimDuoc.maSVThueTro && s.ngayThue == svTimDuoc.ngayThue)
                            dssvTimDuoc.Add(s);
                    }
                }
                dssvSauKhiTim = dssvTimDuoc;
            }
            else
            {
                IEnumerable<TimKiemThongTinSinhVienTheoTenResult> dssvTimTheoTen = sv.TimSVTheoTen(strGiaTriTim);
                foreach (LayDSSinhVienKhongConThueResult s in dssvKhongConThue)
                {
                    foreach (TimKiemThongTinSinhVienTheoTenResult svTimDuoc in dssvTimTheoTen)
                    {
                        if (s.maSVThueTro == svTimDuoc.maSVThueTro && s.ngayThue == svTimDuoc.ngayThue)
                            dssvTimDuoc.Add(s);
                    }
                }
                dssvSauKhiTim = dssvTimDuoc;
            }
            return dssvSauKhiTim;
        }

        void LoadSVConThueTimDuocLenListView(ListView lvw, IEnumerable<LayDSSinhVienConThueResult> ds)
        {
            lvw.Items.Clear();
            foreach(LayDSSinhVienConThueResult s in ds)
            {
                TaoItemConThue(lvw, s);
            }
        }

        void LoadSVKhongConThueTimDuocLenListView(ListView lvw, IEnumerable<LayDSSinhVienKhongConThueResult> ds)
        {
            lvw.Items.Clear();
            foreach (LayDSSinhVienKhongConThueResult s in ds)
            {
                TaoItemKhongConThue(lvw, s);
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
            string strGiaTriTim = txtGiaTriTim.Text;
            if (txtGiaTriTim.Text == "")
                BtnTaiLai_Click(sender, e);
            else
            {
                if (rdoLoadDanhSachSinhVienConThue.Checked == true)
                {
                    IEnumerable<LayDSSinhVienConThueResult> dssvTimDuoc = TimKiemSVConThue(strGiaTriTim);
                    LoadSVConThueTimDuocLenListView(lvwDSSinhVien, dssvTimDuoc);
                }
                else
                {
                    IEnumerable<LayDSSinhVienKhongConThueResult> dssvTimDuoc = TimKiemSVKhongConThue(strGiaTriTim);
                    LoadSVKhongConThueTimDuocLenListView(lvwDSSinhVien, dssvTimDuoc);
                }
            }
            Clear();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDSSVLenListView(lvwDSSinhVien);
        }

        private void RdoTimTheoCMND_CheckedChanged(object sender, EventArgs e)
        {
            XuLyAutoComplete();
        }

        private void RdoTimTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            XuLyAutoComplete();
        }

        private void TxtGiaTriTim_TextChanged(object sender, EventArgs e)
        {
            BtnTimKiem_Click(sender, e);
        }
    }
}
