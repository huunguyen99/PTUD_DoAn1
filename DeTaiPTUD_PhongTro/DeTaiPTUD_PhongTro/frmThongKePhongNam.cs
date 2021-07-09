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
    public partial class frmThongKePhongNam : Form
    {
        public frmThongKePhongNam()
        {
            InitializeComponent();
        }

        

        clsQLPhongTro ptr;
        IEnumerable<ThongKePhongNamResult> dsptNam;

        private void FrmThongKePhongNam_Load(object sender, EventArgs e)
        {
            ptr = new clsQLPhongTro();
            dsptNam = ptr.ThongKePhongNam();
            LoadPTLenListView(lvwDSPhongNam, dsptNam);
        }


        void ThemItem(ListView lvw, ThongKePhongNamResult pn)
        {
            ListViewItem lvwitem = new ListViewItem(pn.maPhong);
            lvwitem.SubItems.Add(pn.tenPhong);
            lvwitem.SubItems.Add(pn.tangLau.ToString());
            string giathue = string.Format("{0:0,0 VNĐ}", pn.giaThue);
            lvwitem.SubItems.Add(giathue);
            lvwitem.SubItems.Add(pn.soNguoiToiDa.ToString());
            lvwitem.SubItems.Add(pn.soNguoiHienTai.ToString());
            lvwitem.Tag = pn;
            lvw.Items.Add(lvwitem);
        }

        void LoadPTLenListView(ListView lvw, IEnumerable<ThongKePhongNamResult> dsp)
        {
            lvw.Items.Clear();
            foreach (ThongKePhongNamResult pn in dsp)
            {
                ThemItem(lvw, pn);
            }
        }

        

        void TaiHienTuListView(ThongKePhongNamResult p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            string giaPhong = string.Format("{0:0,0 VNĐ}", p.giaThue);
            txtGiaThue.Text = giaPhong;
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = p.soNguoiHienTai.ToString();
        }
        

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }
        ThongKePhongNamResult ptChon;

        private void LvwDSPhongNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhongNam.SelectedItems.Count > 0)
            {
                ptChon = (ThongKePhongNamResult)lvwDSPhongNam.SelectedItems[0].Tag;
                TaiHienTuListView(ptChon);
            }
        }
    }
}
