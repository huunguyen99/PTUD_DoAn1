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
    public partial class frmThongKeDSPhieuThue : Form
    {
        public frmThongKeDSPhieuThue()
        {
            InitializeComponent();
        }

        clsQLPhongTro pt;
        IEnumerable<tblPhongTro> dsptr;
        clsQLPhieuThue pth;
        IEnumerable<LayDSPhieuThueTheoPhongResult> dspth;
        private void FrmQuanLyDSPhieuThue_Load(object sender, EventArgs e)
        {
            pth = new clsQLPhieuThue();
            pt = new clsQLPhongTro();
            dsptr = pt.LayDSPhong();
            LoadPhongLenTreeView(treDSPhong, dsptr);
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

        private void TreDSPhong_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strMaPhong = "";
            if (treDSPhong.SelectedNode != null)
            {
                strMaPhong = treDSPhong.SelectedNode.Tag.ToString();
                dspth = pth.LayDSPhieuThue(strMaPhong);
                LoadDSPhieuThueLenListView(lvwDSPhieuThue, dspth);
                Clear();
            }
        }

        void Clear()
        {
            txtGioiTinh.Clear();
            txtMaNhanVien.Clear();
            txtMaPHieuThue.Clear();
            txtMaSVThue.Clear();
            txtNgayDongTien.Clear();
            txtNgayThue.Clear();
            txtNgayTra.Clear();
            txtTenNhanVien.Clear();
            txtTenSinhVien.Clear();
            txtTruong.Clear();
        }
        void TaoItem(ListView lvw, LayDSPhieuThueTheoPhongResult p)
        {
            ListViewItem lvwitem = new ListViewItem(p.maPhieuThue.ToString());
            lvwitem.SubItems.Add(p.ngayThue.Value.ToString("dd/MM/yyyy"));
            if (p.ngayTra != null)
                lvwitem.SubItems.Add(p.ngayTra.Value.ToString("dd/MM/yyyy"));
            else
                lvwitem.SubItems.Add("Chưa trả");
            lvwitem.SubItems.Add(p.maNV.ToString());
            lvwitem.SubItems.Add(p.tenNV);
            lvwitem.SubItems.Add(p.maSVThueTro.ToString());
            lvwitem.SubItems.Add(p.tenSV);
            if (p.gioiTinh == true)
                lvwitem.SubItems.Add("Nam");
            else
                lvwitem.SubItems.Add("Nữ");
            lvwitem.SubItems.Add(p.maTruong);
            lvwitem.SubItems.Add(p.NgayDongTien.ToString());
            lvwitem.Tag = p;
            lvw.Items.Add(lvwitem);
        }

        void LoadDSPhieuThueLenListView(ListView lvw, IEnumerable<LayDSPhieuThueTheoPhongResult> ds)
        {
            lvw.Items.Clear();
            foreach(LayDSPhieuThueTheoPhongResult p in ds)
            {
                TaoItem(lvw, p);
            }
        }

        void TaiHienPhieuThueTuListView(LayDSPhieuThueTheoPhongResult p)
        {
            txtMaPHieuThue.Text = p.maPhieuThue.ToString();
            txtNgayThue.Text = p.ngayThue.Value.ToString("dd/MM/yyyy");
            if (p.ngayTra != null)
                txtNgayTra.Text = p.ngayTra.Value.ToString("dd/MM/yyyy");
            else
                txtNgayTra.Text = "Chưa trả";
            if (p.gioiTinh == true)
                txtGioiTinh.Text = "Nam";
            else
                txtGioiTinh.Text = "Nữ";
            txtMaNhanVien.Text = p.maNV.ToString();
            txtTenNhanVien.Text = p.tenNV;
            txtMaSVThue.Text = p.maSVThueTro.ToString();
            txtTenSinhVien.Text = p.tenSV;
            txtNgayDongTien.Text = p.NgayDongTien.ToString();
            txtTruong.Text = p.tenTruong;
        }

        LayDSPhieuThueTheoPhongResult pthChon;
        private void LvwDSPhieuThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwDSPhieuThue.SelectedItems.Count > 0)
            {
                pthChon = (LayDSPhieuThueTheoPhongResult)lvwDSPhieuThue.SelectedItems[0].Tag;
                TaiHienPhieuThueTuListView(pthChon);
            }
        }


        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if(HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}