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
    public partial class frmQuanLyDanhSachPhong : Form
    {
        public frmQuanLyDanhSachPhong()
        {
            InitializeComponent();
        }

        clsQLPhongTro clsph;
        IEnumerable<tblPhongTro> dspt;
        private void FrmQuanLyDanhSachPhong_Load(object sender, EventArgs e)
        {
            clsph = new clsQLPhongTro();
            dspt = clsph.LayDSPhong();
            LoadPTLenListView(lvwDSPhong, dspt);
        }

        void ThemItem(ListView lvw, tblPhongTro p)
        {
            ListViewItem lvwitem = new ListViewItem(p.maPhong);
            lvwitem.SubItems.Add(p.tenPhong);
            lvwitem.SubItems.Add(p.tangLau.ToString());
            string giathue = string.Format("{0:0,0 VNĐ}", p.giaThue);
            lvwitem.SubItems.Add(giathue);
            lvwitem.SubItems.Add(p.soNguoiToiDa.ToString());
            lvwitem.SubItems.Add(clsph.SoNguoiHienTai(p.maPhong).ToString());
            if (p.active == false)
                lvwitem.SubItems.Add("Không còn dùng");
            else
                lvwitem.SubItems.Add("Còn dùng");
            lvwitem.Tag = p;
            lvw.Items.Add(lvwitem);
        }

        void LoadPTLenListView(ListView lvw, IEnumerable<tblPhongTro> dsp)
        {
            lvw.Items.Clear();
            foreach (tblPhongTro p in dsp)
            {
                ThemItem(lvw, p);
            }
        }
        private void BtnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
                this.Close();
        }

        void TaiHienTuListView(tblPhongTro p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            string giaPhong = string.Format("{0:0,0 VNĐ}", p.giaThue);
            txtGiaThue.Text = giaPhong;
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = clsph.SoNguoiHienTai(p.maPhong).ToString();
            if (p.active == false)
                txtTinhTrang.Text = "Không còn dùng";
            else
                txtTinhTrang.Text = "Còn dùng";
        }

        void Clear()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtGiaThue.Clear();
            txtSoNguoiHienTai.Clear();
            txtSoNguoiToiDa.Clear();
            txtTangLau.Clear();
            txtTinhTrang.Clear();
        }

        tblPhongTro ptChon;
        private void LvwDSPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhong.SelectedItems.Count > 0)
            {
                btnXoaPhong.Enabled = true;
                btnSuaPhong.Enabled = true;
                ptChon = (tblPhongTro)lvwDSPhong.SelectedItems[0].Tag;
                TaiHienTuListView(ptChon);
                btnSuaPhong.Text = "SỬA";
                demSua = 0;
                btnThemPhong.Text = "THÊM";
                demThem = 0;
                VoHieuHoaTextBox();
            }
            if (ptChon.active == false)
            {
                btnXoaPhong.Text = "MỞ PHÒNG";
            }
            else
                btnXoaPhong.Text = "XÓA";
        }

        private void BtnXoaPhong_Click(object sender, EventArgs e)
        {
            if (ptChon.active == false)
            {
                DialogResult Hoi = MessageBox.Show("Bạn có chắc chắn muốn dùng lại phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Hoi == DialogResult.Yes)
                {
                    clsph.MoPhong(ptChon);
                    MessageBox.Show("Tái sử dụng phòng hoàn tất!", "Thông báo");
                }
                btnSuaPhong.Enabled = false;
                btnXoaPhong.Enabled = false;
                btnXoaPhong.Text = "XÓA";
                Clear();
                LoadPTLenListView(lvwDSPhong, dspt);
            }
            else
            {
                if (clsph.SoNguoiHienTai(ptChon.maPhong) > 0)
                    MessageBox.Show("Phòng này đang có người ở! Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    DialogResult HoiXoa = MessageBox.Show("bạn có chắc chắn muốn xóa phòng này không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (HoiXoa == DialogResult.Yes)
                    {
                        clsph.XoaPhong(ptChon);
                        MessageBox.Show("Xóa thông tin phòng hoàn tất", "Thông báo");
                    }
                    btnSuaPhong.Enabled = false;
                    btnXoaPhong.Enabled = false;
                    Clear();
                    LoadPTLenListView(lvwDSPhong, dspt);
                }
            }
        }

        tblPhongTro TaoPhongSua()
        {
            tblPhongTro p = new tblPhongTro();
            p.giaThue = Convert.ToDecimal(txtGiaThue.Text);
            p.soNguoiToiDa = Convert.ToInt32(txtSoNguoiToiDa.Text);
            return p;
        }

        int demSua = 0;
        private void BtnSuaPhong_Click(object sender, EventArgs e)
        {
            demSua++;
            if (demSua % 2 == 1)
            {
                btnSuaPhong.Text = "LƯU";
                MoTextBox();
                txtTangLau.ReadOnly = true;
                txtSoNguoiToiDa.Clear();
                txtGiaThue.Clear();
            }
            else
            {
                if (txtGiaThue.Text.Trim().Length == 0 || txtSoNguoiToiDa.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    demSua--;
                }
                else
                {
                    try
                    {
                        decimal giaPhong = Convert.ToDecimal(txtGiaThue.Text);
                        int soNguoiToiDa = Convert.ToInt32(txtSoNguoiToiDa.Text);
                        if (giaPhong < 0 || soNguoiToiDa < 0)
                        {
                            MessageBox.Show("các giá trị không được bé hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            demSua--;
                        }
                        else
                        {
                            DialogResult HoiSua = MessageBox.Show("Có có chắc chắn muốn sửa phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (HoiSua == DialogResult.Yes)
                            {
                                tblPhongTro pSua = TaoPhongSua();
                                Boolean kQuaSua = clsph.SuaPhong(ptChon, pSua);
                                MessageBox.Show("Sửa thông tin phòng hoàn tất", "Thông báo");
                            }
                            btnSuaPhong.Text = "SỬA";
                            btnSuaPhong.Enabled = false;
                            btnXoaPhong.Enabled = false;
                            VoHieuHoaTextBox();
                            Clear();
                            LoadPTLenListView(lvwDSPhong, dspt);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Lỗi format kiểu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        void VoHieuHoaTextBox()
        {
            txtGiaThue.ReadOnly = true;
            txtSoNguoiToiDa.ReadOnly = true;
            txtTangLau.ReadOnly = true;
        }
        void MoTextBox()
        {
            txtGiaThue.ReadOnly = false;
            txtSoNguoiToiDa.ReadOnly = false;
            txtTangLau.ReadOnly = false;
        }
        tblPhongTro TaoPhongThem()
        {
            tblPhongTro p = new tblPhongTro();
            p.maPhong = clsph.LayDuLieu().autoMaPhong();
            p.tenPhong = clsph.LayDuLieu().autoTenPhong();
            p.giaThue = Convert.ToDecimal(txtGiaThue.Text);
            p.tangLau = Convert.ToInt32(txtTangLau.Text);
            p.soNguoiToiDa = Convert.ToInt32(txtSoNguoiToiDa.Text);
            p.active = true;
            return p;
        }


        int demThem = 0;
        private void BtnThemPhong_Click(object sender, EventArgs e)
        {
            demSua = 0;
            btnSuaPhong.Text = "SỬA";
            demThem++;
            if (demThem % 2 == 1)
            {
                btnThemPhong.Text = "LƯU";
                MoTextBox();
                btnXoaPhong.Enabled = false;
                btnSuaPhong.Enabled = false;
                Clear();
            }
            else
            {
                if (txtSoNguoiToiDa.Text.Trim().Length == 0 || txtGiaThue.Text.Trim().Length == 0 || txtTangLau.Text.Trim().Length == 0)
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin phòng cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    try
                    {
                        int tLau = Convert.ToInt32(txtTangLau.Text);
                        decimal giaPhong = Convert.ToDecimal(txtGiaThue.Text);
                        int soNguoiToiDa = Convert.ToInt32(txtSoNguoiToiDa.Text);
                        if (tLau < 0 || giaPhong < 0 || soNguoiToiDa < 0)
                        {
                            MessageBox.Show("các giá trị không được bé hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            demThem--;
                        }
                        else
                        {
                            tblPhongTro p = TaoPhongThem();
                            DialogResult HoiThem = MessageBox.Show("Bạn có chắc chắn muốn thêm phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (HoiThem == DialogResult.Yes)
                            {
                                clsph.ThemPhong(p);
                                MessageBox.Show("Thêm phòng hoàn tất!", "Thông báo");
                                
                            }
                            VoHieuHoaTextBox();
                            LoadPTLenListView(lvwDSPhong, dspt);
                            btnThemPhong.Text = "THÊM";
                            Clear();
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Lỗi format kiểu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        demThem--;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Kiểu dữ liệu quá lớn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        demThem--;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        demThem--;
                    }
                }
            }
        }

        private void TxtTangLau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtGiaThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtSoNguoiToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }
    }
}
