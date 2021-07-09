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
    public partial class frmThongKePhongNu : Form
    {
        public frmThongKePhongNu()
        {
            InitializeComponent();
        }

        clsQLPhongTro ptr;
        IEnumerable<ThongKePhongNuResult> dsptNu;
        private void FrmThongKePhongNu_Load(object sender, EventArgs e)
        {
            ptr = new clsQLPhongTro();
            dsptNu = ptr.ThongKePhongNu();
            LoadPTLenListView(lvwDSPhongNu, dsptNu);
        }

        void ThemItem(ListView lvw, ThongKePhongNuResult p)
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

        void LoadPTLenListView(ListView lvw, IEnumerable<ThongKePhongNuResult> dsp)
        {
            lvw.Items.Clear();
            foreach (ThongKePhongNuResult p in dsp)
            {
                ThemItem(lvw, p);
            }
        }

        ThongKePhongNuResult ptChon;

        void TaiHienTuListView(ThongKePhongNuResult p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            string giaPhong = string.Format("{0:0,0 VNĐ}", p.giaThue);
            txtGiaThue.Text = giaPhong;
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = p.soNguoiHienTai.ToString();
        }

        private void LvwDSPhongNu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhongNu.SelectedItems.Count > 0)
            {
                ptChon = (ThongKePhongNuResult)lvwDSPhongNu.SelectedItems[0].Tag;
                TaiHienTuListView(ptChon);
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

        
    }
}
