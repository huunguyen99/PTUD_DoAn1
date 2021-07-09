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
    public partial class frmMenu : Form
    {
        static string strTK, strMK;
        static int maNV;
        static bool chucVu;

        frmDangKiThueMoi frmDkiThueMoi = new frmDangKiThueMoi(maNV);
        frmDangKyThueOGhep frmDkyOGhep = new frmDangKyThueOGhep(maNV);
        frmTraPhong frmTrP = new frmTraPhong();
        frmLapHoaDon frmTinhTienPhong = new frmLapHoaDon(maNV);
        frmQuanLyDanhSachPhong frmQLDSPhong = new frmQuanLyDanhSachPhong();
        frmQuanLyThongTinSV frmQLSV = new frmQuanLyThongTinSV();
        frmQuanLyDSHoaDon frmQLHD = new frmQuanLyDSHoaDon();
        frmQuanLyNhanVien frmQLNV = new frmQuanLyNhanVien();
        frmThongKeDSPhieuThue frmQLPT = new frmThongKeDSPhieuThue();
        frmQuanLyDSTruong frmQLDSTruong = new frmQuanLyDSTruong();
        frmTimKiemSV frmTimKiemSV = new frmTimKiemSV();
        frmTimKiemNV frmTimKiemNV = new frmTimKiemNV();
        frmTimKiemPhong frmTimPhong = new frmTimKiemPhong();
        frmTimKiemHoaDon frmTimKiemHD = new frmTimKiemHoaDon();
        frmThongKeDSSVDangThue frmThongKeSVDangThue = new frmThongKeDSSVDangThue();
        frmThongKeDSSVKhongConThue frmDSSVKhongConThue = new frmThongKeDSSVKhongConThue();
        frmThongKePhongTrong frmTKPhongTrong = new frmThongKePhongTrong();
        frmThongKePhongNam frmTKPhongNam = new frmThongKePhongNam();
        frmThongKePhongNu frmTKPhongNu = new frmThongKePhongNu();
        frmXemLichSuSinhVienThuePhong frmXemLichSu = new frmXemLichSuSinhVienThuePhong();
        frmDangKyTaiKhoan frmTaoTK = new frmDangKyTaiKhoan();
        frmDoiMatKhau frmDMK = new frmDoiMatKhau(strTK, strMK);
        frmThongKeDoanhThuThang frmTKDTT = new frmThongKeDoanhThuThang();
        frmThongKeDoanhThuNam frmTKDTN = new frmThongKeDoanhThuNam();
        ThongKeThuePhongTheoThang frmTKTPTT = new ThongKeThuePhongTheoThang();
        ThongKeThuePhongTheoNam frmTKTPTN = new ThongKeThuePhongTheoNam();
        frmThongKeTraPhongTheoNam frmTKTrPTN = new frmThongKeTraPhongTheoNam();
        frmThongKeTraPhongTheoThang frmTKTrPTT = new frmThongKeTraPhongTheoThang();


        public frmMenu(clsTaiKhoan tk)
        {
            InitializeComponent();
            strTK = tk.TaiKhoan;
            strMK = tk.MatKhau;
            maNV = tk.KtraTaiKhoan(strTK, strMK).maNV;
            chucVu = tk.KtraTaiKhoan(strTK, strMK).chucVu;
        }
        //bool KiemTraTonTaiForm(string frmTenForm)
        //{
        //    foreach (Form frm in this.MdiChildren)
        //    {
        //        if (frm.Name.Equals(frmTenForm))
        //        {
        //            frm.Activate();
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        private void MnuDangKyThueTro_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmDkiThueMoi.IsAccessible == false)
            {
                frmDkiThueMoi = new frmDangKiThueMoi(maNV);
                frmDkiThueMoi.MdiParent = this;
                frmDkiThueMoi.Show();
            }
        }

        private void BtnMenuTimKiemSV_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTimKiemSV.IsAccessible == false)
            {
                frmTimKiemSV = new frmTimKiemSV();
                frmTimKiemSV.MdiParent = this;
                frmTimKiemSV.Show();
            }
        }

        private void MnuTimKiemNV_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTimKiemNV.IsAccessible == false)
            {
                frmTimKiemNV = new frmTimKiemNV();
                frmTimKiemNV.MdiParent = this;
                frmTimKiemNV.Show();
            }
            
        }

        private void MnuDangKyOGhep_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if(frmDkyOGhep.IsAccessible == false)
            {
                frmDkyOGhep = new frmDangKyThueOGhep(maNV);
                frmDkyOGhep.MdiParent = this;
                frmDkyOGhep.Show();
            }
        }

        private void MnuTraPhong_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmDkyOGhep.IsAccessible == false)
            {
                frmTrP = new frmTraPhong();
                frmTrP.MdiParent = this;
                frmTrP.Show();
            }
        }

        private void MnuXemDSSinhVien_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmQLSV.IsAccessible == false)
            {
                frmQLSV = new frmQuanLyThongTinSV();
                frmQLSV.MdiParent = this;
                frmQLSV.Show();
            }
        }

        private void BtnXemDSPhong_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmQLDSPhong.IsAccessible == false)
            {
                frmQLDSPhong = new frmQuanLyDanhSachPhong();
                frmQLDSPhong.MdiParent = this;
                frmQLDSPhong.Show();
            }
        }

        private void MnuHoaDon_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmQLHD.IsAccessible == false)
            {
                frmQLHD = new frmQuanLyDSHoaDon();
                frmQLHD.MdiParent = this;
                frmQLHD.Show();
            }
        }

        private void MnuXemDSNhanVien_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmQLNV.IsAccessible == false)
            {
                frmQLNV = new frmQuanLyNhanVien();
                frmQLNV.MdiParent = this;
                frmQLNV.Show();
            }
        }

        private void MnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmDMK.IsAccessible == false)
            {
                frmDMK = new frmDoiMatKhau(strTK, strMK);
                frmDMK.MdiParent = this;
                frmDMK.Show();
            }
        }

        private void MnuTinhTienPhong_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTinhTienPhong.IsAccessible == false)
            {
                frmTinhTienPhong = new frmLapHoaDon(maNV);
                frmTinhTienPhong.MdiParent = this;
                frmTinhTienPhong.Show();
            }
        }

        private void MnuXemDanhSachTruong_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmQLDSTruong.IsAccessible == false)
            {
                frmQLDSTruong = new frmQuanLyDSTruong();
                frmQLDSTruong.MdiParent = this;
                frmQLDSTruong.Show();
            }
        }

        private void MnuXemDSSVDangThue_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmThongKeSVDangThue.IsAccessible == false)
            {
                frmThongKeSVDangThue = new frmThongKeDSSVDangThue();
                frmThongKeSVDangThue.MdiParent = this;
                frmThongKeSVDangThue.Show();
            }
        }

        private void MnuTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTimKiemHD.IsAccessible == false)
            {
                frmTimKiemHD = new frmTimKiemHoaDon();
                frmTimKiemHD.MdiParent = this;
                frmTimKiemHD.Show();
            }
        }

        
        private void MnuTimKiemPhong_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTimPhong.IsAccessible == false)
            {
                frmTimPhong = new frmTimKiemPhong();
                frmTimPhong.MdiParent = this;
                frmTimPhong.Show();
            }
        }

        private void MnuXemDSSVKhongConThue_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmDSSVKhongConThue.IsAccessible == false)
            {
                frmDSSVKhongConThue = new frmThongKeDSSVKhongConThue();
                frmDSSVKhongConThue.MdiParent = this;
                frmDSSVKhongConThue.Show();
            }
        }

        private void MnuXemDSPhongTrong_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKPhongTrong.IsAccessible == false)
            {
                frmTKPhongTrong = new frmThongKePhongTrong();
                frmTKPhongTrong.MdiParent = this;
                frmTKPhongTrong.Show();
            }
        }

        private void MnuXemDSPhongNam_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKPhongNam.IsAccessible == false)
            {
                frmTKPhongNam = new frmThongKePhongNam();
                frmTKPhongNam.MdiParent = this;
                frmTKPhongNam.Show();
            }
        }

        private void MnuXemDSPhongNu_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKPhongNu.IsAccessible == false)
            {
                frmTKPhongNu = new frmThongKePhongNu();
                frmTKPhongNu.MdiParent = this;
                frmTKPhongNu.Show();
            }
        }
        private void MnuTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTaoTK.IsAccessible == false)
            {
                frmTaoTK = new frmDangKyTaiKhoan();
                frmTaoTK.MdiParent = this;
                frmTaoTK.Show();
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void MnuXemDSPhieuThue_Click_1(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmQLPT.IsAccessible == false)
            {
                frmQLPT = new frmThongKeDSPhieuThue();
                frmQLPT.MdiParent = this;
                frmQLPT.Show();
            }
        }

        private void mnuXemThongKeDoanhThuThang_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKDTT.IsAccessible == false)
            {
                frmTKDTT = new frmThongKeDoanhThuThang();
                frmTKDTT.MdiParent = this;
                frmTKDTT.Show();
            }
        }

        private void mnuXemThongKeDoanThuNam_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKDTT.IsAccessible == false)
            {
                frmTKDTN = new frmThongKeDoanhThuNam();
                frmTKDTN.MdiParent = this;
                frmTKDTN.Show();
            }
        }

        private void mnuXemThongKeThuePhongThang_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKTPTT.IsAccessible == false)
            {
                frmTKTPTT = new ThongKeThuePhongTheoThang();
                frmTKTPTT.MdiParent = this;
                frmTKTPTT.Show();
            }
        }

        private void mnuXemThongKeThuePhongNam_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKTPTT.IsAccessible == false)
            {
                frmTKTPTN = new ThongKeThuePhongTheoNam();
                frmTKTPTN.MdiParent = this;
                frmTKTPTN.Show();
            }
        }

        private void mnuXemThongKeTraPhongThang_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKTPTT.IsAccessible == false)
            {
                frmTKTrPTT = new frmThongKeTraPhongTheoThang();
                frmTKTrPTT.MdiParent = this;
                frmTKTrPTT.Show();
            }
        }

        private void mnuXemThongKeTraPhongNam_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmTKTPTT.IsAccessible == false)
            {
                frmTKTrPTN = new frmThongKeTraPhongTheoNam();
                frmTKTrPTN.MdiParent = this;
                frmTKTrPTN.Show();
            }
        }

        private void MnuXemLichSu_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            if (frmXemLichSu.IsAccessible == false)
            {
                frmXemLichSu = new frmXemLichSuSinhVienThuePhong();
                frmXemLichSu.MdiParent = this;
                frmXemLichSu.Show();
            }
        }

        
    }
}
