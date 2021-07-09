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
    public partial class frmDangKyThueOGhep : Form
    {
        int maNhanVien;
        public frmDangKyThueOGhep(int maNV)
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

        clsQLPhongTro ptr;
        IEnumerable<ThongKePhongNuResult> dsptNu;
        IEnumerable<ThongKePhongNamResult> dsptNam;

        private void FrmDangKyThueOGhep_Load(object sender, EventArgs e)
        {
            ptr = new clsQLPhongTro();
            dsptNu = ptr.ThongKePhongNu();
            dsptNam = ptr.ThongKePhongNam();
            LoadPTLenListView(lvwDSPhong);
        }

        void ThemItemNu(ListView lvw, ThongKePhongNuResult p)
        {
            ListViewItem lvwitem = new ListViewItem(p.maPhong);
            lvwitem.SubItems.Add(p.tenPhong);
            lvwitem.SubItems.Add(p.tangLau.ToString());
            string giathue = string.Format("{0:0,0 VNĐ}", p.giaThue);
            lvwitem.SubItems.Add(giathue);
            lvwitem.SubItems.Add(p.soNguoiToiDa.ToString());
            lvwitem.SubItems.Add(p.soNguoiHienTai.ToString());
            lvwitem.Tag = p;
            lvw.Items.Add(lvwitem);
        }

        void ThemItemNam(ListView lvw, ThongKePhongNamResult p)
        {
            ListViewItem lvwitem = new ListViewItem(p.maPhong);
            lvwitem.SubItems.Add(p.tenPhong);
            lvwitem.SubItems.Add(p.tangLau.ToString());
            string giathue = string.Format("{0:0,0 VNĐ}", p.giaThue);
            lvwitem.SubItems.Add(giathue);
            lvwitem.SubItems.Add(p.soNguoiToiDa.ToString());
            lvwitem.SubItems.Add(p.soNguoiHienTai.ToString());
            lvwitem.Tag = p;
            lvw.Items.Add(lvwitem);
        }


        void LoadPTLenListView(ListView lvw)
        {
            if (rdoDSPhongNam.Checked == true)
            {
                lvw.Items.Clear();
                foreach (ThongKePhongNamResult p in dsptNam)
                {
                    ThemItemNam(lvw, p);
                }
            }
            else
            {
                lvw.Items.Clear();
                foreach (ThongKePhongNuResult p in dsptNu)
                {
                    ThemItemNu(lvw, p);
                }
            }
        }


        void TaiHienTuListViewNu(ThongKePhongNuResult p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            txtGiaThue.Text = p.giaThue.ToString();
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = p.soNguoiHienTai.ToString();
        }

        void TaiHienTuListViewNam(ThongKePhongNamResult p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            string giaPhong = string.Format("{0:0,0 VNĐ}", p.giaThue);
            txtGiaThue.Text = giaPhong;
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = p.soNguoiHienTai.ToString();
        }

        public ThongKePhongNuResult ptNuChon;
        public ThongKePhongNamResult ptNamChon;


        void Clear()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtTangLau.Clear();
            txtGiaThue.Clear();
            txtSoNguoiToiDa.Clear();
            txtSoNguoiHienTai.Clear();
        }
        private void LvwDSPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoDSPhongNam.Checked == true)
            {
                if (lvwDSPhong.SelectedItems.Count > 0)
                {
                    btnDangKiThue.Enabled = true;
                    ptNamChon = (ThongKePhongNamResult)lvwDSPhong.SelectedItems[0].Tag;
                    TaiHienTuListViewNam(ptNamChon);
                }
                else
                    Clear();
            }
            else
            {
                if (lvwDSPhong.SelectedItems.Count > 0)
                {
                    btnDangKiThue.Enabled = true;
                    ptNuChon = (ThongKePhongNuResult)lvwDSPhong.SelectedItems[0].Tag;
                    TaiHienTuListViewNu(ptNuChon);
                }
                else
                    Clear();
            }
        }

       

        private void BtnDangKiThue_Click(object sender, EventArgs e)
        {
            if (rdoDSPhongNam.Checked)
            {
                if (ptr.SoNguoiHienTai(ptNamChon.maPhong) >= ptNamChon.soNguoiToiDa)
                    MessageBox.Show("Số người trong phòng đã đủ!\nKhông thể thêm sinh viên vào phòng này!", "Thông báo");
                else
                {
                    DialogResult HoiThem = MessageBox.Show("Sinh viên đã từng thuê ở đây chưa?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (HoiThem == DialogResult.Yes)
                    {
                        frmDangKyChoSVThueLai frmThueLai = new frmDangKyChoSVThueLai(ptNamChon.maPhong, (int) ptNamChon.NgayDongTien, (Boolean) ptNamChon.gioiTinh, (int)ptNamChon.soNguoiHienTai, (decimal)ptNamChon.giaThue, maNhanVien);
                        if (frmThueLai.ShowDialog() == DialogResult.OK)
                            LoadPTLenListView(lvwDSPhong);
                    }
                    else if (HoiThem == DialogResult.No)
                    {
                        frmDienThongTinSinhVienThueTro frmThueMoi = new frmDienThongTinSinhVienThueTro(this.ptNamChon.maPhong, (int) ptNamChon.NgayDongTien, (Boolean)ptNamChon.gioiTinh, (int)ptNamChon.soNguoiHienTai, (decimal)ptNamChon.giaThue, maNhanVien);
                        if (frmThueMoi.ShowDialog() == DialogResult.OK)
                            LoadPTLenListView(lvwDSPhong);
                    }
                }
            }
            else
            {
                if (ptr.SoNguoiHienTai(ptNuChon.maPhong) >= ptNuChon.soNguoiToiDa)
                    MessageBox.Show("Số người trong phòng đã đủ!\nKhông thể thêm sinh viên vào phòng này!", "Thông báo");
                else
                {
                    DialogResult HoiThem = MessageBox.Show("Sinh viên muốn thêm vào đã từng thuê ở đây chưa?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (HoiThem == DialogResult.Yes)
                    {
                        frmDangKyChoSVThueLai frmThueLai = new frmDangKyChoSVThueLai(ptNuChon.maPhong, (int)ptNuChon.NgayDongTien, (Boolean)ptNuChon.gioiTinh, (int) ptNuChon.soNguoiHienTai, (decimal)ptNuChon.giaThue, maNhanVien);
                        if (frmThueLai.ShowDialog() == DialogResult.OK)
                            LoadPTLenListView(lvwDSPhong);
                    }
                    else if (HoiThem == DialogResult.No)
                    {
                        frmDienThongTinSinhVienThueTro frmThueMoi = new frmDienThongTinSinhVienThueTro(this.ptNuChon.maPhong, (int)ptNuChon.NgayDongTien, (Boolean)ptNuChon.gioiTinh, (int)ptNuChon.soNguoiHienTai, (decimal)ptNuChon.giaThue, maNhanVien);
                        if (frmThueMoi.ShowDialog() == DialogResult.OK)
                            LoadPTLenListView(lvwDSPhong);
                    }
                }
            }          
        }

        private void RdoNam_CheckedChanged(object sender, EventArgs e)
        {
            LoadPTLenListView(lvwDSPhong);
        }

        private void RdoNu_CheckedChanged(object sender, EventArgs e)
        {
            LoadPTLenListView(lvwDSPhong);
        }

        private void TxtMaPhong_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtMaPhong_Leave(object sender, EventArgs e)
        {
            if (rdoDSPhongNam.Checked == true)
                txtMaPhong.Text = ptNamChon.maPhong;
            else
                txtMaPhong.Text = ptNuChon.maPhong;
        }
    }
}
