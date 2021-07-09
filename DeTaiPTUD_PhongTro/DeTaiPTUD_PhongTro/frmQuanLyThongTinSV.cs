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
    public partial class frmQuanLyThongTinSV : Form
    {
        public frmQuanLyThongTinSV()
        {
            InitializeComponent();
        }

        clsQLPhongTro clspt;
        clsQLSinhVien clssv;
        IEnumerable<tblPhongTro> dsptr;
        IEnumerable<ThongKeSinhVienDangThueResult> dssv;
        clsQLTruong clstr;
        IEnumerable<tblTruong> dstr;
        ErrorProvider ep;
        private void FrmQuanLyThongTinSV_Load(object sender, EventArgs e)
        {
            ep = new ErrorProvider();
            clspt = new clsQLPhongTro();
            clssv = new clsQLSinhVien();
            clstr = new clsQLTruong();
            dsptr = clspt.LayDSPhong();
            LoadPhongLenTreeView(treDSPhongTro, dsptr);
            dstr = clstr.LayDSTruong();
            cboTruong.DataSource = dstr;
            cboTruong.DisplayMember = "tenTruong";
            cboTruong.ValueMember = "maTruong";
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
                dssv = clssv.ThongKeSVDangThue(strMaPhong);
                LoadDSSVLenListView(lvwDSSinhVien, dssv);
                demSua = 1;
                btnSuaThongTin.Text = "SỬA";
                VoHieuHoaTextBox();
                Clear();
                btnSuaThongTin.Enabled = false;
                btnXoaSV.Enabled = false;
            }
        }

        void TaoItem(ListView lvw, ThongKeSinhVienDangThueResult s)
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

        void LoadDSSVLenListView(ListView lvw, IEnumerable<ThongKeSinhVienDangThueResult> ds)
        {
            lvw.Items.Clear();
            foreach (ThongKeSinhVienDangThueResult s in ds)
            {
                TaoItem(lvw, s);
            }
        }



        void TaiHienTuListView(ThongKeSinhVienDangThueResult s)
        {
            txtMaSVThueTro.Text = s.maSVThueTro.ToString();
            txtHoTen.Text = s.tenSV;
            txtSoCMND.Text = s.soCMND;
            txtSoDT.Text = s.SDT;
            txtEmail.Text = s.email;
            cboTruong.SelectedText = s.tenTruong;
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

        ThongKeSinhVienDangThueResult svChon;

        private void lvwDSSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSSinhVien.SelectedItems.Count > 0)
            {
                btnXoaSV.Enabled = true;
                btnSuaThongTin.Enabled = true;
                svChon = (ThongKeSinhVienDangThueResult)lvwDSSinhVien.SelectedItems[0].Tag;
                TaiHienTuListView(svChon);
                demSua = 1;
                btnSuaThongTin.Text = "SỬA";
                VoHieuHoaTextBox();
            }
            else
            {
                btnSuaThongTin.Enabled = false;
                btnXoaSV.Enabled = false;
                Clear();
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
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
            txtQueQuan.Clear();
            txtSoCMND.Clear();
            txtSoDT.Clear();
            cboTruong.Text = "";
            txtNgayThue.Clear();
            txtNgayTra.Clear();
        }

        void MoTextBoxSua()
        {
            txtEmail.ReadOnly = false;
            txtSoDT.ReadOnly = false;
            txtEmail.Clear();
            txtSoDT.Clear();
            cboTruong.Text = "";
        }

        void VoHieuHoaTextBox()
        {
            txtEmail.ReadOnly = true;
            txtSoDT.ReadOnly = true;
        }

        tblSinhVien TaoThongTinSVSua()
        {
            tblSinhVien sv = new tblSinhVien();
            sv.email = txtEmail.Text;
            sv.SDT = txtSoDT.Text;
            sv.maTruong = cboTruong.SelectedValue.ToString();
            return sv;
        }

        int demSua = 0;

        private void BtnSuaThongTin_Click(object sender, EventArgs e)
        {
            demSua++;
            if (demSua % 2 == 0)
            {
                btnSuaThongTin.Text = "LƯU";
                MoTextBoxSua();
            }
            else
            {
                if (txtEmail.Text.Trim().Length == 0 || txtSoDT.Text.Trim().Length == 0 || cboTruong.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cần sửa!", "Thông báo");
                    demSua--;
                }
                else if (!txtEmail.Text.KtraEmail())
                {
                    ep.SetError(txtEmail, "Email phải theo mẫu abcd123@gmail.com");
                    demSua--;
                }
                else if (!txtSoDT.Text.KtraSDT())
                {
                    ep.SetError(txtSoDT, "số điện thoại bắt đầu bằng số 0 + số lẻ + 8 số bất kì");
                    demSua--;
                }
                else
                {
                    DialogResult HoiSua = MessageBox.Show("Có có chắc chắn muốn sửa phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (HoiSua == DialogResult.Yes)
                    {
                        tblSinhVien sv = TaoThongTinSVSua();
                        clssv.SuaTTSinhVien(svChon, sv);
                        MessageBox.Show("Sửa thông tin sinh viên hoàn tất!", "Thông báo");
                    }
                    btnSuaThongTin.Text = "SỬA";
                    VoHieuHoaTextBox();
                    Clear();
                    LoadDSSVLenListView(lvwDSSinhVien, dssv);
                }
            }
        }

        private void BtnXoaSV_Click(object sender, EventArgs e)
        {
            DialogResult HoiXoa = MessageBox.Show("bạn có chắc chắn muốn xóa sinh viên này\nra khỏi phòng này không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiXoa == DialogResult.Yes)
            {
                clssv.XoaSinhVien(svChon);
                MessageBox.Show("Xóa sinh viên khỏi phòng hoàn tất", "Thông báo");
            }
            btnXoaSV.Enabled = false;
            btnSuaThongTin.Enabled = false;
            Clear();
            LoadDSSVLenListView(lvwDSSinhVien, dssv);
        }

        private void TxtSoDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.KtraEmail())
                ep.Clear();
        }
        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSoDT.Text.KtraSDT())
                ep.Clear();
        }
    }
}
