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
    public partial class frmTimKiemPhong : Form
    {
        public frmTimKiemPhong()
        {
            InitializeComponent();
        }


        clsQLPhongTro clsph;
        IEnumerable<tblPhongTro> dspt;
        private void FrmTimKiemPhong_Load(object sender, EventArgs e)
        {
            clsph = new clsQLPhongTro();
            dspt = clsph.LayDSPhong();
            LoadPTLenListView(lvwDSPhongTro, dspt);
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


        void TaiHienTuListView(tblPhongTro p)
        {
            txtMaPhong.Text = p.maPhong;
            txtTenPhong.Text = p.tenPhong;
            txtTangLau.Text = p.tangLau.ToString();
            string giaPhong = string.Format("{0:0,0 VNĐ}", p.giaThue);
            txtGiaThue.Text = giaPhong;
            txtSoNguoiToiDa.Text = p.soNguoiToiDa.ToString();
            txtSoNguoiHienTai.Text = clsph.SoNguoiHienTai(p.maPhong).ToString();
        }

        tblPhongTro ptChon;
        private void LvwDSPhongTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSPhongTro.SelectedItems.Count > 0)
            {
                ptChon = (tblPhongTro)lvwDSPhongTro.SelectedItems[0].Tag;
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
        void Clear()
        {
            txtMaPhong.Clear();
            txtGiaThue.Clear();
            txtSoNguoiHienTai.Clear();
            txtSoNguoiToiDa.Clear();
            txtTangLau.Clear();
            txtTenPhong.Clear();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadPTLenListView(lvwDSPhongTro, dspt);
            Clear();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                decimal giaNho = Convert.ToDecimal(cboGiaThap.Text);
                decimal giaCao = Convert.ToDecimal(cboGiaCao.Text);
                if (giaNho > giaCao)
                    MessageBox.Show("giá nhỏ không được lớn hơn giá cao!", "Thông báo");
                else
                {
                    IEnumerable<tblPhongTro> dsPhongTimDuoc = clsph.TimKiemPhong(giaNho, giaCao);
                    if(dsPhongTimDuoc.Count() == 0)
                    {
                        MessageBox.Show("Giá phòng bạn cần tìm không có!", "Thông báo");
                        LoadPTLenListView(lvwDSPhongTro, dspt);
                    }
                    else
                        LoadPTLenListView(lvwDSPhongTro, dsPhongTimDuoc);
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Lỗi format kiểu dữ liệu!", "Thông báo");
            }
            catch(OverflowException)
            {
                MessageBox.Show("số tiền nhập vào quá lớn!", "Thông báo");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi không xác định " + ex.Message);
            }
            Clear();
        }
    }
}
