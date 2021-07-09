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
    public partial class frmThongKeThueChiTiet : Form
    {
        private DataSet dataSource;
        public frmThongKeThueChiTiet()
        {
            InitializeComponent();
        }
        public frmThongKeThueChiTiet(DataSet ds,string label)
        {
            dataSource = ds;
            InitializeComponent();

            lvwDSChiTiet.Items.Clear();
            for (int i = 0; i < dataSource.Tables[0].Rows.Count; i++)
            {
                TaoItem(lvwDSChiTiet, dataSource, i);
            }
            lblTKThueChiTiet.Text = label;
        }

        private void frmThongKeThueChiTiet_Load(object sender, EventArgs e)
        {
            //lvwDSChiTiet.Items.Clear();
            //for (int i = 0; i < dataSource.Tables[0].Rows.Count; i++)
            //{
            //    TaoItem(lvwDSChiTiet, dataSource, i);
            //}
        }
        void TaoItem(ListView lvw, DataSet ds, int indexRow)
        {
            var s = ds.Tables[0].Rows[indexRow];
            ListViewItem lvwitem = new ListViewItem(s["TenSV"].ToString());
            lvwitem.SubItems.Add(s["CMNDSV"].ToString());
            var gioitinh = (bool)s["GioiTinh"];
            lvwitem.SubItems.Add(gioitinh == true ? "Nam": "Nữ");

            lvwitem.SubItems.Add(s["TenTruong"].ToString());
            lvwitem.SubItems.Add(s["MaPhong"].ToString());
            lvwitem.SubItems.Add(s["TenPhong"].ToString());

            lvwitem.SubItems.Add(s["GiaThue"].ToString());
            lvwitem.SubItems.Add(s["TenNV"].ToString());
            lvwitem.SubItems.Add(s["CMNDNV"].ToString());
            var ngaythue = (DateTime?)s["NgayThue"];
            if (ngaythue != null)
            {
                lvwitem.SubItems.Add(ngaythue.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                lvwitem.SubItems.Add("");
            }
            try
            {
                var ngaytra = (DateTime?)s["NgayTra"];
                lvwitem.SubItems.Add(ngaytra.Value.ToString("dd/MM/yyyy"));
            }
            catch
            {
                lvwitem.SubItems.Add("Chưa trả phòng");
            }
            lvwitem.Tag = s;
            lvw.Items.Add(lvwitem);
        }
    }
}
