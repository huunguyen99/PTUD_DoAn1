using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiPTUD_PhongTro
{
    public class clsQLSinhVien: clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsQLSinhVien()
        {
            dt = LayDuLieu();
        }
        public void Them(tblSinhVien sv)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblSinhViens.InsertOnSubmit(sv);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public IEnumerable<LayDSSinhVienConThueResult> LayTatCaSVConThue()
        {
            return dt.LayDSSinhVienConThue();
        }

        public IEnumerable<LayDSSinhVienKhongConThueResult> LayTatCaSVKhongConThue()
        {
            return dt.LayDSSinhVienKhongConThue().OrderBy(x => x.maSVThueTro);
        }

        public IEnumerable<ThongKeSinhVienDangThueResult> ThongKeSVDangThue(string strMaPhong)
        {
            return dt.ThongKeSinhVienDangThue(strMaPhong);
        }

        public IEnumerable<ThongKeSinhVienKhongConThueResult> ThongKeSVKhongConThue(string strMaPhong)
        {
            return dt.ThongKeSinhVienKhongConThue(strMaPhong);
        }
        public void XoaSinhVien(ThongKeSinhVienDangThueResult svChon)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IEnumerable<tblSinhVien> sv = (from n in dt.tblSinhViens
                                               where n.maSVThueTro.Equals(svChon.maSVThueTro)
                                               select n);
                IEnumerable<tblPhieuThue> pth = (from n in dt.tblPhieuThues
                                                 where n.maSVThuePhong.Equals(svChon.maSVThueTro)
                                                 select n);
                if (sv != null)
                {
                    sv.First().active = false;
                    pth.First().ngayTra = DateTime.Now;
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

        

        public void SuaTTSinhVien(ThongKeSinhVienDangThueResult svCanSua, tblSinhVien svSua)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                tblSinhVien sv = (from n in dt.tblSinhViens
                                  where n.maSVThueTro.Equals(svCanSua.maSVThueTro)
                                  select n).FirstOrDefault();
                if (sv != null)
                {
                    sv.email = svSua.email;
                    sv.maTruong = svSua.maTruong;
                    sv.SDT = svSua.SDT;
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

        public void DangKyThueLai(int maSVThue)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                tblSinhVien sv = (from s in dt.tblSinhViens
                                  join p in dt.tblPhieuThues
                                  on s.maSVThueTro equals p.maSVThuePhong
                                  where s.active == false && p.ngayTra != null && s.maSVThueTro == maSVThue
                                  select s).FirstOrDefault();
                if (sv != null)
                {
                    sv.active = true;
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                }
            }
            catch(Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không xác định " + ex.Message);
            }
        }

        public tblSinhVien KiemTraTrungMa(string strSoCMND)
        {
            tblSinhVien p = (from pt in dt.tblSinhViens
                             where pt.soCMND.Equals(strSoCMND)
                             select pt).FirstOrDefault();
            return p;
        }

        //public void XoaTam(XemLichSuSinhVienThuePhongResult svChon)
        //{
        //    DbTransaction myTran = dt.Connection.BeginTransaction();
        //    try
        //    {
        //        dt.Transaction = myTran;
        //        tblPhieuThue sv = (from n in dt.tblPhieuThues
        //                           where n.maSVThuePhong == svChon.maSVThueTro && n.maPhieuThue == svChon.maPhieuThue
        //                           select n).FirstOrDefault();
        //        if (sv != null)
        //        {
        //            sv.ngayTra = DateTime.Now;
        //            dt.SubmitChanges();
        //            dt.Transaction.Commit();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dt.Transaction.Rollback();
        //        throw new Exception("Lỗi " + ex.Message);
        //    }

        //}

        public IEnumerable<TimKiemThongTinSinhVienTheoCMNDResult> TimSVTheoCMND(string strSoCMND)
        {
            return dt.TimKiemThongTinSinhVienTheoCMND(strSoCMND);
        }

        public IEnumerable<TimKiemThongTinSinhVienTheoTenResult> TimSVTheoTen(string strTenSV)
        {
            return dt.TimKiemThongTinSinhVienTheoTen(strTenSV);
        }

        public IEnumerable<XemLichSuSinhVienThuePhongResult> XemLichSu(string strMaPhong)
        {
            return dt.XemLichSuSinhVienThuePhong(strMaPhong);
        }
    }
}
