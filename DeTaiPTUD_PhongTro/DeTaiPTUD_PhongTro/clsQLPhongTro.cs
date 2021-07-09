using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DeTaiPTUD_PhongTro
{
    public class clsQLPhongTro : clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsQLPhongTro()
        {
            dt = LayDuLieu();
        }

        public IEnumerable<tblPhongTro> LayDSPhongLoadLenThongKe()
        {
            IEnumerable<tblPhongTro> dspt = from n in dt.tblPhongTros
                                            select n;
            return dspt;
        }

        public IEnumerable<tblPhongTro> LayDSPhong()
        {
            IEnumerable<tblPhongTro> dspt = from n in dt.tblPhongTros
                                            select n;
            return dspt;
        }

        public DateTime layHDSauCung(String strMaPhong)
        {
            return (DateTime) dt.LayHDSauCung(strMaPhong);
        }

        public IEnumerable<LayDSPhongTroDangCoNguoiOResult> LayDSPhongDangChoThue()
        {
            return dt.LayDSPhongTroDangCoNguoiO().OrderBy(x => x.maPhong);
        }

        public void TraPhong(string strMaPhong)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IEnumerable<ThongKeSinhVienDangThueResult> dssv = dt.ThongKeSinhVienDangThue(strMaPhong);
                foreach (ThongKeSinhVienDangThueResult sv in dssv)
                {
                    tblSinhVien s = (from n in dt.tblSinhViens
                                     where n.maSVThueTro == sv.maSVThueTro && n.active == true
                                     select n).FirstOrDefault();
                    if (s != null)
                    {
                        tblPhieuThue p = (from n in dt.tblPhieuThues
                                          where n.maPhong.Equals(strMaPhong) && n.ngayTra == null && n.maSVThuePhong == s.maSVThueTro
                                          select n).FirstOrDefault();
                        s.active = false;
                        if (p != null)
                        {
                            p.ngayTra = DateTime.Now;
                        }
                    }
                }
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public int SoNguoiHienTai(string strMaPhong)
        {
            return Convert.ToInt32(dt.DemSoSinhVienTrongPhong(strMaPhong));
        }

        public IEnumerable<tblPhongTro> LayDSPhongTrong()
        {
            IEnumerable<tblPhongTro> dsptrong = (from p in dt.tblPhongTros
                                                 where p.active.Equals(1) && dt.DemSoSinhVienTrongPhong(p.maPhong) == 0
                                                 select p);
            return dsptrong;
        }

        public IEnumerable<tblPhongTro> TimKiemPhong(decimal giaNho, decimal giaCao)
        {
            IEnumerable<tblPhongTro> dsp = (from pt in dt.tblPhongTros
                                            where pt.giaThue >= giaNho && pt.giaThue <= giaCao && pt.active == true
                                            select pt);
            return dsp;
        }

        public IEnumerable<ThongKePhongNamResult> ThongKePhongNam()
        {
            return dt.ThongKePhongNam().OrderBy(x => x.maPhong);
        }

        public IEnumerable<ThongKePhongNuResult> ThongKePhongNu()
        {
            return dt.ThongKePhongNu().OrderBy(x => x.maPhong);
        }

        public void ThemPhong(tblPhongTro p)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblPhongTros.InsertOnSubmit(p);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }


        public void MoPhong(tblPhongTro p)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IEnumerable<tblPhongTro> ph = (from n in dt.tblPhongTros
                                               where n.maPhong.Equals(p.maPhong)
                                               select n);
                if (ph != null)
                {
                    ph.First().active = true;
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
        public Boolean XoaPhong(tblPhongTro p)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IEnumerable<tblPhongTro> ph = (from n in dt.tblPhongTros
                                               where n.maPhong.Equals(p.maPhong)
                                               select n);
                if (ph != null)
                {
                    ph.First().active = false;
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

        public Boolean SuaPhong(tblPhongTro pCanSua, tblPhongTro pSua)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IEnumerable<tblPhongTro> ph = (from n in dt.tblPhongTros
                                               where n.maPhong.Equals(pCanSua.maPhong)
                                               select n);
                if (ph != null)
                {
                    ph.First().giaThue = pSua.giaThue;
                    ph.First().soNguoiToiDa = pSua.soNguoiToiDa;
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

    }
}
