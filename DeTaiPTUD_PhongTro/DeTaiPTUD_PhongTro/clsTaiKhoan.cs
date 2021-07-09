using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DeTaiPTUD_PhongTro
{
    public class clsTaiKhoan:clsKetNoiData
    {
        QLThueTroSVDataContext dt;

        private string taiKhoan, matKhau;
        private int maNV;
        private bool chucVu;

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public bool ChucVu { get => chucVu; set => chucVu = value; }
        public int MaNV { get => maNV; set => maNV = value; }

        public clsTaiKhoan(string strTK, string strMK)
        {
            dt = LayDuLieu();
            this.taiKhoan = strTK;
            this.matKhau = strMK;
        }

        public void ThemTaiKhoan(tblTaiKhoan tk)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblTaiKhoans.InsertOnSubmit(tk);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }
        
        public tblTaiKhoan KtraTKTonTai(string strTenTK)
        {
            tblTaiKhoan t = (from n in dt.tblTaiKhoans
                             where n.tenTK.Equals(strTenTK)
                             select n).FirstOrDefault();
            return t;
        }

        public LayDSTaiKhoanDangNhapResult KtraTaiKhoan(string strTK, string strMK)
        {
            LayDSTaiKhoanDangNhapResult tk = (from t in dt.LayDSTaiKhoanDangNhap()
                                              where t.tenTK.Equals(strTK) && t.matKhau.Equals(strMK) && t.active == true
                                              select t).FirstOrDefault();
            return tk;
        }

        public void DoiMatKhau(LayDSTaiKhoanDangNhapResult tkCanSua, string MKSua)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                tblTaiKhoan tk = (from t in dt.tblTaiKhoans
                                  where t.tenTK.Equals(tkCanSua.tenTK)
                                  select t).FirstOrDefault();
                tk.matKhau = MKSua;
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch(Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không xác định " + ex.Message);
            }
        }
    }
}
