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
    public partial class frmTraPhong : Form
    {
        public frmTraPhong()
        {
            InitializeComponent();
        }

        clsQLPhongTro ptr;
        IEnumerable<LayDSPhongTroDangCoNguoiOResult> dsPh;

        private void FrmTraPhong_Load(object sender, EventArgs e)
        {
            ptr = new clsQLPhongTro();
            dsPh = ptr.LayDSPhongDangChoThue();
            LoadPTLenListView(lvwDSPhongTro, dsPh);
        }

        void TaoItem(ListView lvw, LayDSPhongTroDangCoNguoiOResult p)
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

        void LoadPTLenListView(ListView lvw, IEnumerable<LayDSPhongTroDangCoNguoiOResult> ds)
        {
            lvw.Items.Clear();
            foreach(LayDSPhongTroDangCoNguoiOResult p in ds)
            {
                TaoItem(lvw, p);
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
        LayDSPhongTroDangCoNguoiOResult ptChon;
        void TaiHienTuListView(LayDSPhongTroDangCoNguoiOResult p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            txtSoNguoiHienTai.Text = p.soNguoiHienTai.ToString();
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            string giaPhong = string.Format("{0:0,0 VNĐ}", p.giaThue);
            txtGiaThue.Text = giaPhong;
        }

        private void LvwDSPhongTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhongTro.SelectedItems.Count > 0)
            {
                ptChon = (LayDSPhongTroDangCoNguoiOResult)lvwDSPhongTro.SelectedItems[0].Tag;
                TaiHienTuListView(ptChon);
                btnTraPhong.Enabled = true;
            }
            else
            {
                btnTraPhong.Enabled = false;
                Clear();
            }
        }

        void Clear()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtGiaThue.Clear();
            txtSoNguoiHienTai.Clear();
            txtSoNguoiToiDa.Clear();
            txtTangLau.Clear();
        }

        private void BtnTraPhong_Click(object sender, EventArgs e)
        {
            DialogResult HoiTraPhong = MessageBox.Show("Bạn có chắc chắn phòng này muốn trả không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiTraPhong == DialogResult.Yes)
            {
                ptr.TraPhong(ptChon.maPhong);
                MessageBox.Show("Trả Phòng thành công!", "Thông Báo");
            }
            IEnumerable<LayDSPhongTroDangCoNguoiOResult> ds = ptr.LayDSPhongDangChoThue();
            LoadPTLenListView(lvwDSPhongTro, ds);
            btnTraPhong.Enabled = false;
            Clear();
        }
    }
}
