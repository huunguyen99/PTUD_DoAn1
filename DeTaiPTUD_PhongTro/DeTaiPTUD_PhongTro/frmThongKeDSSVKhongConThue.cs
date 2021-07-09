using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace DeTaiPTUD_PhongTro
{
    public partial class frmThongKeDSSVKhongConThue : Form
    {
        public frmThongKeDSSVKhongConThue()
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
        clsQLSinhVien sv;
        IEnumerable<tblPhongTro> dsptr;
        IEnumerable<ThongKeSinhVienKhongConThueResult> dssv;
        private void FrmThongKeDSSVKhongConThue_Load(object sender, EventArgs e)
        {
            pt = new clsQLPhongTro();
            sv = new clsQLSinhVien();
            dsptr = pt.LayDSPhong();
            LoadPhongLenTreeView(treDSPhongTro, dsptr);
        }

        void LoadPhongLenTreeView(TreeView tre, IEnumerable<tblPhongTro> dsp)
        {
            tre.Nodes.Clear();
            foreach(tblPhongTro p in dsp)
            {
                TreeNode n = new TreeNode();
                n.Text = p.tenPhong;
                n.Tag = p.maPhong;
                tre.Nodes.Add(n);
            }
            tre.ExpandAll();
        }

        private void TreDSPhongTro_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strMaPhong = "";
            if(treDSPhongTro.SelectedNode != null)
            {
                strMaPhong = treDSPhongTro.SelectedNode.Tag.ToString();
                dssv = sv.ThongKeSVKhongConThue(strMaPhong);
                LoadDSSVLenListView(lvwDSSinhVien, dssv);
                Clear();
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

        void TaoItem(ListView lvw, ThongKeSinhVienKhongConThueResult s)
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
            lvwitem.SubItems.Add(s.ngayThue.Value.ToString("dd/MM/yyyy"));
            lvwitem.SubItems.Add(s.ngayTra.Value.ToString("dd/MM/yyyy"));
            lvwitem.Tag = s;
            lvw.Items.Add(lvwitem);
        }

        void LoadDSSVLenListView(ListView lvw, IEnumerable<ThongKeSinhVienKhongConThueResult> ds)
        {
            lvw.Items.Clear();
            foreach(ThongKeSinhVienKhongConThueResult s in ds)
            {
                TaoItem(lvw, s);
            }
        }

        void TaiHienTuListView(ThongKeSinhVienKhongConThueResult s)
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
            txtMaPhong.Text = treDSPhongTro.SelectedNode.Tag.ToString();
        }
        ThongKeSinhVienKhongConThueResult svChon;

        private void LvwDSSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSSinhVien.SelectedItems.Count > 0)
            {
                svChon = (ThongKeSinhVienKhongConThueResult)lvwDSSinhVien.SelectedItems[0].Tag;
                TaiHienTuListView(svChon);
            }
        }
    }
}
