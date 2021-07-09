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
    public partial class frmQuanLyDSHoaDon : Form
    {
        public frmQuanLyDSHoaDon()
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
        private void FrmQuanLyDSHoaDon_Load(object sender, EventArgs e)
        {
            pt = new clsQLPhongTro();
            hd = new clsQLHoaDon();
            dsptr = pt.LayDSPhong();
            LoadPhongLenTreeView(treDSPhongTro, dsptr);
            btnThanhToan.Enabled = false;
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

        private void TreDSPhongTro_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strMaPhong = "";
            if (treDSPhongTro.SelectedNode != null)
            {
                strMaPhong = treDSPhongTro.SelectedNode.Tag.ToString();
                dshd = hd.LayDSHoaDon(strMaPhong);
                LoadHoaDonLenListView(lvwDSHoaDon, dshd);
                Clear();
                btnSuaHoaDon.Enabled = false;
                btnSuaHoaDon.Text = "SỬA";
                demSua = 1;
                btnThanhToan.Enabled = false;
                btnThanhToan.Text = "THANH TOÁN";
                demTT = 1;
                KhoaTextBoxSua();
            }
        }

        void Clear()
        {
            txtMaHoaDon.Clear();
            txtMaPhieuThue.Clear();
            txtNgayLap.Clear();
            txtNgayCanLapHoaDon.Clear();
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
        private void LvwDSHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSHoaDon.SelectedItems.Count > 0)
            {
                hdChon = (LayDanhSachHoaDonResult)lvwDSHoaDon.SelectedItems[0].Tag;
                TaiHienHDTuListView(hdChon);
                btnSuaHoaDon.Text = "SỬA";
                btnSuaHoaDon.Enabled = true;
                demSua = 1;
                btnThanhToan.Text = "THANH TOÁN";
                btnThanhToan.Enabled = true;
                demTT = 1;
                KhoaTextBoxSua();
            }
        }

        tblCT_HoaDon TaoLaiCTHD()
        {
            tblCT_HoaDon ct = new tblCT_HoaDon();
            ct.tienNuoc = Convert.ToDecimal(txtTienNuoc.Text);
            ct.tienDien = Convert.ToDecimal(txtTienDien.Text);
            ct.tienWifi = Convert.ToDecimal(txtTienWifi.Text);
            ct.tienGuiXe = Convert.ToDecimal(txtTienGuiXe.Text);
            ct.phuPhi = Convert.ToDecimal(txtPhuPhi.Text);
            return ct;
        }
        int demSua = 0;

        void MoTextBoxSua()
        {
            txtTienDien.ReadOnly = false;
            txtTienGuiXe.ReadOnly = false;
            txtTienNuoc.ReadOnly = false;
            txtTienWifi.ReadOnly = false;
            txtPhuPhi.ReadOnly = false;
            rtxtGhiChu.ReadOnly = false;
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            txtTienWifi.Clear();
            txtPhuPhi.Clear();
            txtTienGuiXe.Clear();
            rtxtGhiChu.Clear();
        }

        void KhoaTextBoxSua()
        {
            txtTienDien.ReadOnly = true;
            txtTienGuiXe.ReadOnly = true;
            txtTienNuoc.ReadOnly = true;
            txtTienWifi.ReadOnly = true;
            txtPhuPhi.ReadOnly = true;
            rtxtGhiChu.ReadOnly = true;
        }

        private void BtnSuaHoaDon_Click(object sender, EventArgs e)
        {
            demSua++;
            if (demSua % 2 == 0)
            {
                MoTextBoxSua();
                btnSuaHoaDon.Text = "LƯU";
            }
            else
            {
                if (txtTienDien.Text.Trim().Length == 0 || txtTienGuiXe.Text.Trim().Length == 0 || txtTienNuoc.Text.Trim().Length == 0 || txtPhuPhi.Text.Trim().Length == 0 || txtTienWifi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    demSua--;
                }
                else
                {
                    try
                    {
                        decimal tienDien = Convert.ToDecimal(txtTienDien.Text);
                        decimal tienNuoc = Convert.ToDecimal(txtTienNuoc.Text);
                        decimal tienWifi = Convert.ToDecimal(txtTienWifi.Text);
                        decimal tienGuiXe = Convert.ToDecimal(txtTienGuiXe.Text);
                        decimal phuPhi = Convert.ToDecimal(txtPhuPhi.Text);
                        if (tienDien < 0 || tienNuoc < 0 || tienWifi < 0 || tienGuiXe < 0 || phuPhi < 0)
                        {
                            MessageBox.Show("Các giá trị phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            demSua--;
                        }
                        else
                        {
                            DialogResult HoiSua = MessageBox.Show("Bạn có chắc chắn muốn lưu lại thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (HoiSua == DialogResult.Yes)
                            {
                                tblCT_HoaDon cthdSua = TaoLaiCTHD();
                                hd.SuaHoaDon(hdChon.maHD.ToString(), cthdSua, rtxtGhiChu.Text);
                                MessageBox.Show("Sửa thông tin hoàn tất", "Thông báo");
                            }
                            btnSuaHoaDon.Text = "SỬA";
                            KhoaTextBoxSua();
                            LoadHoaDonLenListView(lvwDSHoaDon, dshd);
                            Clear();
                            btnSuaHoaDon.Enabled = false;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Kiểu dữ liệu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        demSua--;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Kiểu dữ liệu quá lớn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        demSua--;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        demSua--;
                    }
                }
            }
        }

        private void TxtTienDien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtTienNuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtTienGuiXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtPhuPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtTienWifi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        int demTT = 0;

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            btnSuaHoaDon.Text = "SỬA";
            demSua = 1;
            if (hdChon.tinhTrangHD == true || hdChon.ngayTra != null)
            {
                MessageBox.Show("Hóa đơn này đã thanh toán rồi!\nKhông thể thanh toán nữa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                demTT++;
                if (demTT % 2 == 0)
                {
                    btnThanhToan.Text = "XÁC NHẬN";
                    rtxtGhiChu.ReadOnly = false;
                }
                else
                {
                    if (rtxtGhiChu.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập vào ghi chú!", "Thông báo");
                        demTT--;
                    }
                    else
                    {
                        DialogResult HoiTT = MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if(HoiTT == DialogResult.Yes)
                        {
                            hd.ThanhToan(hdChon.maHD, rtxtGhiChu.Text);
                            MessageBox.Show("Thanh toán thành công!", "Thông báo");
                        }
                        btnThanhToan.Text = "THANH TOÁN";
                        LoadHoaDonLenListView(lvwDSHoaDon, dshd);
                        Clear();
                        btnThanhToan.Enabled = false;
                    }
                }
            }
        }
    }
}
