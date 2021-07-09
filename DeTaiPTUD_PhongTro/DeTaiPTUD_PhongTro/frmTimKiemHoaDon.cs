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
    public partial class frmTimKiemHoaDon : Form
    {
        public frmTimKiemHoaDon()
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

        clsQLPhongTro pt;
        clsQLHoaDon hd;
        IEnumerable<tblPhongTro> dsptr;
        IEnumerable<LayDanhSachHoaDonResult> dshd;

        private void FrmTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            hd = new clsQLHoaDon();
            pt = new clsQLPhongTro();
            dsptr = pt.LayDSPhong();
            LoadPhongLenTreeView(treDSPhongTro, dsptr);
        }
        
        void LoadPhongLenTreeView(TreeView tre, IEnumerable<tblPhongTro> dsp)
        {
            tre.Nodes.Clear();
            foreach (tblPhongTro p in dsp)
            {
                TreeNode n = new TreeNode();
                n.Text = p.tenPhong;
                n.Tag = p.maPhong;
                tre.Nodes.Add(n);
            }
            tre.ExpandAll();
        }

        void TaoItem(ListView lvw, LayDanhSachHoaDonResult h)
        {
            ListViewItem lvwitem = new ListViewItem(h.maHD);
            lvwitem.SubItems.Add(h.maNV.ToString());
            lvwitem.SubItems.Add(h.maPhieuThue.ToString());
            lvwitem.SubItems.Add(h.ngayThue.Value.ToString("dd/MM/yyyy"));
            lvwitem.SubItems.Add(h.ngayCanLap.Value.ToString("dd/MM/yyyy"));
            lvwitem.SubItems.Add(h.ngayLap.Value.ToString("dd/MM/yyyy"));
            if (h.ngayTra == null)
                lvwitem.SubItems.Add("Chưa thanh toán");
            else
                lvwitem.SubItems.Add(h.ngayTra.Value.ToString("dd/MM/yyyy"));
            string giaPhong = string.Format("{0:0,0 VNĐ}", h.TienPhong);
            string tiendien = string.Format("{0:0,0 VNĐ}", h.tienDien);
            string tiennuoc = string.Format("{0:0,0 VNĐ}", h.tienNuoc);
            string tienwifi = string.Format("{0:0,0 VNĐ}", h.tienWifi);
            string tienguixe = string.Format("{0:0,0 VNĐ}", h.tienGuiXe);
            string phuphi = string.Format("{0:0,0 VNĐ}", h.phuPhi);
            string tongtien = string.Format("{0:0,0 VNĐ}", h.TongTien);
            lvwitem.SubItems.Add(giaPhong);
            lvwitem.SubItems.Add(tiendien);
            lvwitem.SubItems.Add(tiennuoc);
            lvwitem.SubItems.Add(tienwifi);
            lvwitem.SubItems.Add(tienguixe);
            lvwitem.SubItems.Add(phuphi);
            lvwitem.SubItems.Add(tongtien);
            lvwitem.Tag = h;
            lvw.Items.Add(lvwitem);
        }

        void LoadHoaDonLenListView(ListView lvw, IEnumerable<LayDanhSachHoaDonResult> ds)
        {
            lvw.Items.Clear();
            foreach (LayDanhSachHoaDonResult d in ds)
            {
                TaoItem(lvw, d);
            }
        }

        void Clear()
        {
            txtMaHoaDon.Clear();
            txtMaPhieuThue.Clear();
            txtNgayLap.Clear();
            txtNgayThue.Clear();
            txtPhuPhi.Clear();
            txtTenNV.Clear();
            txtTienDien.Clear();
            txtTienGuiXe.Clear();
            txtTienNuoc.Clear();
            txtTienPhong.Clear();
            txtTienWifi.Clear();
            txtNgayTra.Clear();
            txtTongTien.Clear();
            rtxtGhiChu.Clear();
            txtNgayCanLapHoaDon.Clear();
        }

        private void TreDSPhongTro_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strMaPhong = "";
            if (treDSPhongTro.SelectedNode != null)
            {
                strMaPhong = treDSPhongTro.SelectedNode.Tag.ToString();
                dshd = hd.LayDSHoaDon(strMaPhong);
                LoadHoaDonLenListView(lvwDSHoaDon, dshd);
                Clear();
            }
        }

        void TaiHienHDTuListView(LayDanhSachHoaDonResult h)
        {
            txtMaHoaDon.Text = h.maHD;
            txtMaPhieuThue.Text = h.maPhieuThue.ToString();
            txtTenNV.Text = h.tenNV.ToString();
            txtNgayCanLapHoaDon.Text = h.ngayCanLap.Value.ToString("dd/MM/yyyy");
            txtNgayLap.Text = h.ngayLap.Value.ToString("dd/MM/yyyy");
            txtNgayThue.Text = h.ngayThue.Value.ToString("dd/MM/yyyy");
            string giaPhong = string.Format("{0:0,0 VNĐ}", h.TienPhong);
            string tiendien = string.Format("{0:0,0 VNĐ}", h.tienDien);
            string tiennuoc = string.Format("{0:0,0 VNĐ}", h.tienNuoc);
            string tienwifi = string.Format("{0:0,0 VNĐ}", h.tienWifi);
            string tienguixe = string.Format("{0:0,0 VNĐ}", h.tienGuiXe);
            string phuphi = string.Format("{0:0,0 VNĐ}", h.phuPhi);
            string tongtien = string.Format("{0:0,0 VNĐ}", h.TongTien);
            txtTienPhong.Text = giaPhong;
            txtTienDien.Text = tiendien;
            txtTienNuoc.Text = tiennuoc;
            txtTienGuiXe.Text = tienguixe;
            txtTienWifi.Text = tienwifi;
            txtPhuPhi.Text = phuphi;
            txtTongTien.Text = tongtien;
            rtxtGhiChu.Text = h.ghiChu;
            if (h.ngayTra == null)
                txtNgayTra.Text = "Chưa Thanh Toán";
            else
                txtNgayTra.Text = h.ngayTra.Value.ToString("dd/MM/yyyy");
        }

        LayDanhSachHoaDonResult hdChon;

        private void lvwDSHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSHoaDon.SelectedItems.Count > 0)
            {
                hdChon = (LayDanhSachHoaDonResult)lvwDSHoaDon.SelectedItems[0].Tag;
                TaiHienHDTuListView(hdChon);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            if (dtpKhoangTGCanTimTruoc.Value > dtpKhoangTGCanTimSau.Value)
                MessageBox.Show("Thời gian trước phải nhỏ hơn thời gian sau", "Thông báo");
            else
            {
                List<LayDanhSachHoaDonResult> dshdon = new List<LayDanhSachHoaDonResult>();
                foreach(LayDanhSachHoaDonResult hd in dshd)
                {
                    if (hd.ngayLap >= dtpKhoangTGCanTimTruoc.Value && hd.ngayLap <= dtpKhoangTGCanTimSau.Value)
                    {
                        dshdon.Add(hd);
                    }
                }
                IEnumerable<LayDanhSachHoaDonResult> ds = dshdon;
                LoadHoaDonLenListView(lvwDSHoaDon, ds);
                if (ds.Count() == 0)
                    MessageBox.Show("Không có hóa đơn nào trong khoảng thời gian bạn cần tìm", "Thông báo");
            }
        }

        
    }
}
