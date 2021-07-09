using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DeTaiPTUD_PhongTro
{
    public partial class frmGioiThieu : Form
    {
        public frmGioiThieu()
        {
            InitializeComponent();
        }

        private void frmGioiThieu_MouseMove(object sender, MouseEventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            for(int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                txtLoading.Clear();
                txtLoading.AppendText("Loading " + i.ToString() + "%");
                Thread.Sleep(50);
                if(i == 90)
                {
                    Thread.Sleep(1000);
                    i = 99;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmGioiThieu_Load(object sender, EventArgs e)
        {
            kryptonWrapLabel1.Text = "CHƯƠNG TRÌNH QUẢN LÝ CHO THUÊ PHÒNG TRỌ SINH VIÊN";
            label1.Text = "Loading...";
        }
    }
}
