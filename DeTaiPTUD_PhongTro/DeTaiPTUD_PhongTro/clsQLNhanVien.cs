using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiPTUD_PhongTro
{
    public class clsQLNhanVien: clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsQLNhanVien()
        {
            dt = LayDuLieu();
        }
        public void ThemNhanVien(tblNhanVien p)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblNhanViens.InsertOnSubmit(p);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public void XoaNVKhiTaoTKLoi(tblNhanVien nvXoa)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblNhanViens.DeleteOnSubmit(nvXoa);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public tblNhanVien TimKiemNV(int maNV)
        {
            tblNhanVien p = (from pt in dt.tblNhanViens
                             join t in dt.tblTaiKhoans on pt.maNV equals t.maNV
                             where pt.maNV == maNV
                             select pt).FirstOrDefault();
            return p;
        }
        public Boolean XoaNhanVien(LayDSNhanVienResult nv)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                tblTaiKhoan t = (from tk in dt.tblTaiKhoans
                                 where tk.maNV == nv.maNV
                                 select tk).FirstOrDefault();
                tblNhanVien n = TimKiemNV(nv.maNV);
                if (n != null)
                {
                    n.active = false;
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public void SuaNhanVien(LayDSNhanVienResult nvChon, tblNhanVien nvSua)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IEnumerable<tblNhanVien> nvCanSua = (from n in dt.tblNhanViens
                                                     where n.maNV == nvChon.maNV
                                                     select n);
                if (nvCanSua != null)
                {
                    nvCanSua.First().email = nvSua.email;
                    nvCanSua.First().diaChi = nvSua.diaChi;
                    nvCanSua.First().SDT = nvSua.SDT;
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }
        public IEnumerable<LayDSNhanVienResult> LayDSNV()
        {
            return dt.LayDSNhanVien();
        }

        public IEnumerable<TimKiemThongTinNhanVienTheoCMNDResult> TimNhanVienTheoCMND(string strSoCMND)
        {
            return dt.TimKiemThongTinNhanVienTheoCMND(strSoCMND);
        }

        public IEnumerable<TimKiemThongTinNhanVienTheoTenResult> TimNhanVienTheoTen(string strTenNV)
        {
            return dt.TimKiemThongTinNhanVienTheoTen(strTenNV);
        }
    }
}
