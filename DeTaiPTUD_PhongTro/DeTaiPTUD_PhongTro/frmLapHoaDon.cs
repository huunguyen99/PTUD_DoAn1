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
    public partial class frmLapHoaDon : Form
    {
        int maNhanVien;
        public frmLapHoaDon(int maNV)
        {
            InitializeComponent();
            maNhanVien = maNV;
        }

        clsQLPhongTro clsptr;
        clsQLHoaDon clshd;
        IEnumerable<LayDSPhongTroDangCoNguoiOResult> dsPh;
        private void FrmLapHoaDon_Load(object sender, EventArgs e)
        {
            clsptr = new clsQLPhongTro();
            clshd = new clsQLHoaDon();
            dsPh = clsptr.LayDSPhongDangChoThue();
            LoadPTLenListView(lvwDSPhongTro, dsPh);
        }


        void TaoItem(ListView lvw, LayDSPhongTroDangCoNguoiOResult p)
        {
            ListViewItem lvwitem = new ListViewItem(p.maPhong);
            lvwitem.SubItems.Add(p.tenPhong);
            lvwitem.SubItems.Add(p.tangLau.ToString());
            string giathue = string.Format("{0:0,0 VNĐ}", p.giaThue);
            lvwitem.SubItems.Add(giathue);
            lvwitem.SubItems.Add(p.soNguoiToiDa.ToString());
            lvwitem.SubItems.Add(clsptr.SoNguoiHienTai(p.maPhong).ToString());
            lvwitem.SubItems.Add(clsptr.layHDSauCung(p.maPhong).ToString("dd/MM/yyyy"));
            DateTime hdSauCung = clsptr.layHDSauCung(p.maPhong);
            if ((DateTime.Now - hdSauCung).TotalDays >= 29 && (DateTime.Now - hdSauCung).TotalDays <= 30)
                lvwitem.SubItems.Add("Đến hạn đóng tiền phòng");
            else if ((DateTime.Now - hdSauCung).TotalDays > 30)
                lvwitem.SubItems.Add("Trễ hạn đóng tiền phòng");
            else
                lvwitem.SubItems.Add("Đã Lập Hóa Đơn");
            lvwitem.Tag = p;
            lvw.Items.Add(lvwitem);
        }

        void LoadPTLenListView(ListView lvw, IEnumerable<LayDSPhongTroDangCoNguoiOResult> ds)
        {
            lvw.Items.Clear();
            foreach (LayDSPhongTroDangCoNguoiOResult p in ds)
            {
                TaoItem(lvw, p);
            }
        }

        LayDSPhongTroDangCoNguoiOResult ptChon;
        void TaiHienTuListView(LayDSPhongTroDangCoNguoiOResult p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            txtSoNguoiHienTai.Text = clsptr.SoNguoiHienTai(p.maPhong).ToString();
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            string giathue = string.Format("{0:0,0 VNĐ}", p.giaThue);
            txtGiaThue.Text = giathue;
            DateTime hdSauCung = clsptr.layHDSauCung(p.maPhong);
            if ((DateTime.Now - hdSauCung).TotalDays >= 29 && (DateTime.Now - hdSauCung).TotalDays <= 30)
                txtTrangThai.Text = "Đến hạn đóng tiền phòng";
            else if ((DateTime.Now - hdSauCung).TotalDays > 30)
                txtTrangThai.Text = "Trễ hạn đóng tiền phòng";
            else
                txtTrangThai.Text = "Đã Lập Hóa Đơn";
            txtHoaDonGanNhat.Text = clsptr.layHDSauCung(p.maPhong).ToString("dd/MM/yyyy");

        }

        void Clear()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtTangLau.Clear();
            txtTrangThai.Clear();
            txtGiaThue.Clear();
            txtSoNguoiToiDa.Clear();
            txtSoNguoiHienTai.Clear();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LvwDSPhongTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhongTro.SelectedItems.Count > 0)
            {
                ptChon = (LayDSPhongTroDangCoNguoiOResult)lvwDSPhongTro.SelectedItems[0].Tag;
                TaiHienTuListView(ptChon);
            }
        }

        private void BtnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (ptChon == null || string.IsNullOrEmpty(ptChon.maPhong))
            {
                MessageBox.Show("Vui lòng chọn trên danh sách");
                return;
            }
            DateTime hdSauCung = clsptr.layHDSauCung(ptChon.maPhong);
            if ((DateTime.Now - hdSauCung).TotalDays <= 26)
                MessageBox.Show("Phòng này chưa đến hạn\nlập hóa đơn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                frmDienThongTinHoaDon frmLapHD = new frmDienThongTinHoaDon(ptChon.maPhong, (decimal)ptChon.giaThue, maNhanVien, (DateTime) clsptr.layHDSauCung(ptChon.maPhong));
                if (frmLapHD.ShowDialog() == DialogResult.OK)
                {
                    LoadPTLenListView(lvwDSPhongTro, dsPh);
                }
            }
        }
    }
}
