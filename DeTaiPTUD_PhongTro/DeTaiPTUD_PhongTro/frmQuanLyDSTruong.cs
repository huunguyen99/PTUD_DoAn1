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
    public partial class frmQuanLyDSTruong : Form
    {
        public frmQuanLyDSTruong()
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

        clsQLTruong tr;
        IEnumerable<tblTruong> dsTr;
        private void FrmQuanLyDSTruong_Load(object sender, EventArgs e)
        {
            tr = new clsQLTruong();
            dsTr = tr.LayDSTruong();
            LoadTruongLenListView(lvwDSTruong, dsTr);
        }

        void ThemItem(ListView lvw, tblTruong t)
        {
            ListViewItem lvwitem = new ListViewItem(t.maTruong);
            lvwitem.SubItems.Add(t.tenTruong);
            lvwitem.SubItems.Add(t.diaChi);
            lvwitem.Tag = t;
            lvw.Items.Add(lvwitem);
        }

        void LoadTruongLenListView(ListView lvw, IEnumerable<tblTruong> dst)
        {
            lvw.Items.Clear();
            foreach (tblTruong t in dst)
            {
                ThemItem(lvw, t);
            }
        }

        void TaiHienTuListView(tblTruong t)
        {
            txtMaTruong.Text = t.maTruong;
            txtTenTruong.Text = t.tenTruong;
            txtDiaChi.Text = t.diaChi;
        }
        void Clear()
        {
            txtMaTruong.Clear();
            txtTenTruong.Clear();
            txtDiaChi.Clear();
        }

        tblTruong trChon;
        private void LvwDSTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwDSTruong.SelectedItems.Count > 0)
            {
                trChon = (tblTruong)lvwDSTruong.SelectedItems[0].Tag;
                btnSua.Enabled = true;
                TaiHienTuListView(trChon);
                btnSua.Text = "SỬA";
                btnThem.Text = "THÊM";
                demThem = 0;
                demSua = 1;
                VoHieuHoaTextBox();
            }
            else
            {
                btnSua.Enabled = false;
                Clear();
            }
        }

        tblTruong TaoTruongSua()
        {
            tblTruong t = new tblTruong();
            t.tenTruong = txtTenTruong.Text;
            t.diaChi = txtDiaChi.Text;
            return t;
        }

        int demSua = 0;
        private void BtnSua_Click(object sender, EventArgs e)
        {
            demSua++;
            if (demSua % 2 == 0)
            {
                btnSua.Text = "LƯU";
                txtTenTruong.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtTenTruong.Clear();
                txtDiaChi.Clear();
            }
            else
            {
                if (txtTenTruong.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cần sửa!", "Thông báo");
                    demSua--;
                }
                else
                {
                    DialogResult HoiSua = MessageBox.Show("Có có chắc chắn muốn sửa phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (HoiSua == DialogResult.Yes)
                    {
                        tblTruong t = TaoTruongSua();
                        Boolean kQuaSua = tr.SuaTruong(trChon, t);
                        MessageBox.Show("Sửa thông tin trường hoàn tất", "Thông báo");
                    }
                    btnSua.Text = "SỬA";
                    btnSua.Enabled = false;
                    txtTenTruong.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;
                    Clear();
                    LoadTruongLenListView(lvwDSTruong, dsTr);
                }
            }
        }

        void MoTextBox()
        {
            txtMaTruong.ReadOnly = false;
            txtTenTruong.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            btnSua.Enabled = false;
        }

        void VoHieuHoaTextBox()
        {
            txtMaTruong.ReadOnly = true;
            txtTenTruong.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
        }

        int demThem = 0;

        tblTruong TaoTruongThem()
        {
            tblTruong t = new tblTruong();
            t.maTruong = txtMaTruong.Text;
            t.tenTruong = txtTenTruong.Text;
            t.diaChi = txtDiaChi.Text;
            return t;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            btnSua.Text = "SỬA";
            demSua = 1;
            demThem++;
            if (demThem % 2 == 1)
            {
                btnThem.Text = "LƯU";
                MoTextBox();
                Clear();
            }
            else
            {
                if (txtMaTruong.Text.Trim().Length == 0 || txtTenTruong.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0)
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trường cần thêm!", "Thông báo");
                else
                {
                    tblTruong t = TaoTruongThem();
                    tblTruong kqTim = tr.TimKiemTruong(t.maTruong);
                    if (kqTim != null)
                    {
                        MessageBox.Show("Mã trường đã bị trùng!", "Thông báo");
                        demThem--;
                    }
                    else
                    {
                        DialogResult HoiThem = MessageBox.Show("Bạn có chắc chắn muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (HoiThem == DialogResult.No)
                        {
                            VoHieuHoaTextBox();
                            Clear();
                        }
                        else
                        {
                            tr.ThemTruong(t);
                            MessageBox.Show("Thêm trường hoàn tất", "Thông báo");
                            VoHieuHoaTextBox();
                        }
                        LoadTruongLenListView(lvwDSTruong, dsTr);
                        btnThem.Text = "THÊM";
                    }
                }
            }
        }
    }
}
