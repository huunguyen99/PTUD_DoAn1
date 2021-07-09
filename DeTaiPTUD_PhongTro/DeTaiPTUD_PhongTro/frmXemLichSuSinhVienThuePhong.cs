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
    public partial class frmXemLichSuSinhVienThuePhong : Form
    {
        public frmXemLichSuSinhVienThuePhong()
        {
            InitializeComponent();
        }

        clsQLPhongTro pt;
        IEnumerable<tblPhongTro> dspt;
        clsQLSinhVien clsSV;
        IEnumerable<XemLichSuSinhVienThuePhongResult> dsSV;
        private void FrmXemLichSuSinhVienThuePhong_Load(object sender, EventArgs e)
        {
            clsSV = new clsQLSinhVien();
            pt = new clsQLPhongTro();
            dspt = pt.LayDSPhong();
            LoadPhongLenTreeView(treDSPhongTro, dspt);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
                this.Close();
        }

        void TaoItem(ListView lvw, XemLichSuSinhVienThuePhongResult s)
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
            if (s.ngayTra != null)
                lvwitem.SubItems.Add(s.ngayTra.Value.ToString("dd/MM/yyyy"));
            else
                lvwitem.SubItems.Add("Chưa trả");
            lvwitem.Tag = s;
            lvw.Items.Add(lvwitem);
        }

        void LoadDSSVLenListView(ListView lvw, IEnumerable<XemLichSuSinhVienThuePhongResult> ds)
        {
            lvw.Items.Clear();
            foreach (XemLichSuSinhVienThuePhongResult s in ds)
            {
                TaoItem(lvw, s);
            }
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

        private void TreDSPhongTro_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strMaPhong = "";
            if (treDSPhongTro.SelectedNode != null)
            {
                strMaPhong = treDSPhongTro.SelectedNode.Tag.ToString();
                dsSV = clsSV.XemLichSu(strMaPhong);
                LoadDSSVLenListView(lvwDSSinhVien, dsSV);
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

        void TaiHienTuListView(XemLichSuSinhVienThuePhongResult s)
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
            if (s.ngayTra != null)
                txtNgayTra.Text = s.ngayTra.Value.ToString("dd/MM/yyyy");
            else
                txtNgayTra.Text = "Chưa trả";


            txtMaPhong.Text = treDSPhongTro.SelectedNode.Tag.ToString();
        }

        XemLichSuSinhVienThuePhongResult svChon;

        private void LvwDSSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSSinhVien.SelectedItems.Count > 0)
            {
                svChon = (XemLichSuSinhVienThuePhongResult)lvwDSSinhVien.SelectedItems[0].Tag;
                TaiHienTuListView(svChon);
            }
        }
    }
}
