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
    public partial class frmThongKePhongTrong : Form
    {
        public frmThongKePhongTrong()
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
        
        clsQLPhongTro ptr;
        IEnumerable<tblPhongTro> dsptrong;
        private void FrmThongKePhongTrong_Load(object sender, EventArgs e)
        {
            ptr = new clsQLPhongTro();
            dsptrong = ptr.LayDSPhongTrong();
            LoadPTLenListView(lvwDSPhongTrong, dsptrong);
        }

        void ThemItem(ListView lvw, tblPhongTro pn)
        {
            ListViewItem lvwitem = new ListViewItem(pn.maPhong);
            lvwitem.SubItems.Add(pn.tenPhong);
            lvwitem.SubItems.Add(pn.tangLau.ToString());
            string giathue = string.Format("{0:0,0 VNĐ}", pn.giaThue);
            lvwitem.SubItems.Add(giathue);
            lvwitem.SubItems.Add(pn.soNguoiToiDa.ToString());
            lvwitem.SubItems.Add(ptr.SoNguoiHienTai(pn.maPhong).ToString());
            lvwitem.Tag = pn;
            lvw.Items.Add(lvwitem);
        }

        void LoadPTLenListView(ListView lvw, IEnumerable<tblPhongTro> dsp)
        {
            lvw.Items.Clear();
            foreach (tblPhongTro pn in dsp)
            {
                ThemItem(lvw, pn);
            }
        }

        void TaiHienTuListView(tblPhongTro p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            txtGiaThue.Text = p.giaThue.ToString();
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = ptr.SoNguoiHienTai(p.maPhong).ToString();
        }

        tblPhongTro ptChon;

        private void LvwDSPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhongTrong.SelectedItems.Count > 0)
            {
                ptChon = (tblPhongTro)lvwDSPhongTrong.SelectedItems[0].Tag;
                TaiHienTuListView(ptChon);
            }
        }
    }
}
