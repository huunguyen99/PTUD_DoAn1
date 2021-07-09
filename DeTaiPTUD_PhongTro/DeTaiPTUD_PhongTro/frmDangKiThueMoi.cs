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
    public partial class frmDangKiThueMoi : Form
    {
        int maNhanVien;
        public frmDangKiThueMoi(int maNV)
        {
            InitializeComponent();
            maNhanVien = maNV;
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnDangKiThue_Click(object sender, EventArgs e)
        {
            DialogResult HoiThem = MessageBox.Show("Sinh viên đã từng thuê ở đây chưa?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThem == DialogResult.Yes)
            {
                frmDangKyChoSVThueLai frmThueLai = new frmDangKyChoSVThueLai(ptChon.maPhong, DateTime.Now.Day, true, ptr.SoNguoiHienTai(ptChon.maPhong), (decimal) ptChon.giaThue, maNhanVien);
                if (frmThueLai.ShowDialog() == DialogResult.OK)
                    LoadPTLenListView(lvwDSPhong, dsptrong);
            }
            else if (HoiThem == DialogResult.No)
            {
                frmDienThongTinSinhVienThueTro frmThueMoi = new frmDienThongTinSinhVienThueTro(this.ptChon.maPhong, DateTime.Now.Day, true, ptr.SoNguoiHienTai(ptChon.maPhong), (decimal)ptChon.giaThue, maNhanVien);
                if (frmThueMoi.ShowDialog() == DialogResult.OK)
                    LoadPTLenListView(lvwDSPhong, dsptrong);
            }
        }

        
        clsQLPhongTro ptr;
        IEnumerable<tblPhongTro> dsptrong;

        private void FrmDangKiThueMoi_Load(object sender, EventArgs e)
        {
            ptr = new clsQLPhongTro();
            dsptrong = ptr.LayDSPhongTrong();
            LoadPTLenListView(lvwDSPhong, dsptrong);
        }

        void ThemItem(ListView lvw, tblPhongTro pn)
        {
            ListViewItem lvwitem = new ListViewItem(pn.maPhong);
            lvwitem.SubItems.Add(pn.tenPhong);
            lvwitem.SubItems.Add(pn.tangLau.ToString());
            string giathue = string.Format("{0:0,0 VNĐ}", pn.giaThue);
            lvwitem.SubItems.Add(giathue);
            lvwitem.SubItems.Add(pn.soNguoiToiDa.ToString());
            lvwitem.SubItems.Add(ptr.SoNguoiHienTai(pn.maPhong).ToString());
            lvwitem.Tag = pn;
            lvw.Items.Add(lvwitem);
        }

        void LoadPTLenListView(ListView lvw, IEnumerable<tblPhongTro> dsp)
        {
            lvw.Items.Clear();
            foreach (tblPhongTro pn in dsp)
            {
                ThemItem(lvw, pn);
            }
        }

        void TaiHienTuListView(tblPhongTro p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            txtGiaThue.Text = p.giaThue.ToString();
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = ptr.SoNguoiHienTai(p.maPhong).ToString();
        }

        tblPhongTro ptChon;

        private void LvwDSPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhong.SelectedItems.Count > 0)
            {
                btnDangKiThue.Enabled = true;
                ptChon = (tblPhongTro)lvwDSPhong.SelectedItems[0].Tag;
                TaiHienTuListView(ptChon);
            }
        }
    }
}
