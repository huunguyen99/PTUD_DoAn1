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
    public partial class frmTimKiemNV : Form
    {
        public frmTimKiemNV()
        {
            InitializeComponent();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        clsQLNhanVien clsnv;
        IEnumerable<LayDSNhanVienResult> dsnv;
        private void FrmTimKiemNV_Load(object sender, EventArgs e)
        {
            clsnv = new clsQLNhanVien();
            dsnv = clsnv.LayDSNV();
            LoadNVLenListView(lvwDSNhanVien, dsnv);
            txtGiaTriTim.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtGiaTriTim.AutoCompleteSource = AutoCompleteSource.CustomSource;
            XuLyAutoComplete();
        }

        void LoadNVLenListView(ListView lvw, IEnumerable<LayDSNhanVienResult> dsp)
        {
            lvw.Items.Clear();
            foreach (LayDSNhanVienResult p in dsp)
            {
                ThemItem(lvw, p);
            }
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

        void Clear()
        {
            txtMaNV.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSoDT.Clear();
            txtNgaySinh.Clear();
            txtQueQuan.Clear();
            txtSoCMND.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
        }
        void TaiHienTuListView(LayDSNhanVienResult nv)
        {
            txtMaNV.Text = nv.maNV.ToString();
            txtDiaChi.Text = nv.diaChi;
            txtEmail.Text = nv.email;
            txtTenNV.Text = nv.tenNV;
            txtDiaChi.Text = nv.diaChi;
            txtSoCMND.Text = nv.soCMND;
            txtSoDT.Text = nv.SDT;
            txtNgaySinh.Text = nv.ngaySinh.Value.ToString("dd/MM/yyyy");
            txtQueQuan.Text = nv.queQuan.ToString();
            if (nv.active == true)
                txtTinhTrang.Text = "Vẫn còn làm";
            else
                txtTinhTrang.Text = "Đã nghỉ việc";
            txtTaiKhoan.Text = nv.tenTK;
            txtMatKhau.Text = nv.matKhau;
        }

        LayDSNhanVienResult nvChon;

        private void LvwDSNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSNhanVien.SelectedItems.Count > 0)
            {
                nvChon = (LayDSNhanVienResult)lvwDSNhanVien.SelectedItems[0].Tag;
                TaiHienTuListView(nvChon);
            }
            else
            {
                Clear();
            }
        }
        void XuLyAutoComplete()
        {
            if (rdoTimTheoCMND.Checked == true)
            {
                txtGiaTriTim.AutoCompleteCustomSource.Clear();
                foreach (LayDSNhanVienResult n in dsnv)
                {
                    txtGiaTriTim.AutoCompleteCustomSource.Add(n.soCMND);
                }
            }
            else
            {
                txtGiaTriTim.AutoCompleteCustomSource.Clear();
                foreach (LayDSNhanVienResult n in dsnv)
                {
                    txtGiaTriTim.AutoCompleteCustomSource.Add(n.tenNV);
                }
            }
        }


        IEnumerable<LayDSNhanVienResult> TimKiem(string strGiaTriTim)
        {
            List<LayDSNhanVienResult> dsNVTimDuoc = new List<LayDSNhanVienResult>();
            IEnumerable<LayDSNhanVienResult> DSNVSauKhiTim;
            
            if (rdoTimTheoCMND.Checked == true)
            {
                IEnumerable<TimKiemThongTinNhanVienTheoCMNDResult> dsnvTimTheoCMND = clsnv.TimNhanVienTheoCMND(strGiaTriTim);
                foreach (LayDSNhanVienResult n in dsnv)
                {
                    foreach (TimKiemThongTinNhanVienTheoCMNDResult tnv in dsnvTimTheoCMND)
                    {
                        if (tnv.maNV == n.maNV)
                            dsNVTimDuoc.Add(n);
                    }
                }
                DSNVSauKhiTim = dsNVTimDuoc;
            }
            else
            {
                IEnumerable<TimKiemThongTinNhanVienTheoTenResult> dsnvTimTheoTen = clsnv.TimNhanVienTheoTen(strGiaTriTim);
                foreach (LayDSNhanVienResult n in dsnv)
                {
                    foreach (TimKiemThongTinNhanVienTheoTenResult tnv in dsnvTimTheoTen)
                    {
                        if (tnv.maNV == n.maNV)
                            dsNVTimDuoc.Add(n);
                    }
                }
                DSNVSauKhiTim = dsNVTimDuoc;
            }
            return DSNVSauKhiTim;
        }

        private void BtnTimKiemNV_Click(object sender, EventArgs e)
        {
            string strGiaTriTim = txtGiaTriTim.Text;
            if (txtGiaTriTim.Text == "")
                BtnTaiLai_Click(sender, e);
            else
            {
                IEnumerable<LayDSNhanVienResult> dsnvTimDuoc = TimKiem(strGiaTriTim);
                LoadNVLenListView(lvwDSNhanVien, dsnvTimDuoc);
            }
            Clear();
        }

        private void RdoTimTheoCMND_CheckedChanged(object sender, EventArgs e)
        {
            XuLyAutoComplete();
        }

        private void RdoTimTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            XuLyAutoComplete();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadNVLenListView(lvwDSNhanVien, dsnv);
        }

        private void TxtGiaTriTim_TextChanged(object sender, EventArgs e)
        {
            BtnTimKiemNV_Click(sender, e);
        }
    }
}
