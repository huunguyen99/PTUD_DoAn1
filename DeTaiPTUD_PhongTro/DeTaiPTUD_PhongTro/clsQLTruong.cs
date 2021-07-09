using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DeTaiPTUD_PhongTro
{
    public class clsQLTruong:clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsQLTruong()
        {
            dt = LayDuLieu();
        }

        public IEnumerable<tblTruong> LayDSTruong()
        {
            IEnumerable<tblTruong> dsTr = from n in dt.tblTruongs
                                          select n;
            return dsTr;
        }

        public tblTruong TimKiemTruong(String strMaTruong)
        {
            tblTruong tr = (from t in dt.tblTruongs
                            where t.maTruong.Equals(strMaTruong)
                            select t).FirstOrDefault();
            return tr;
        }


        public void ThemTruong(tblTruong t)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblTruongs.InsertOnSubmit(t);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }
        //public Boolean XoaTruong(tblTruong t)
        //{
        //    DbTransaction myTran = dt.Connection.BeginTransaction();
        //    try
        //    {
        //        dt.Transaction = myTran;
        //        dt.tblTruongs.DeleteOnSubmit(t);
        //        dt.SubmitChanges();
        //        dt.Transaction.Commit();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        dt.Transaction.Rollback();
        //        throw new Exception("Lỗi " + ex.Message);
        //    }
        //}

        public Boolean SuaTruong(tblTruong tCanSua, tblTruong tSua)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IEnumerable<tblTruong> tr = (from n in dt.tblTruongs
                                             where n.maTruong.Equals(tCanSua.maTruong)
                                             select n);
                if (tr != null)
                {
                    tr.First().tenTruong = tSua.tenTruong;
                    tr.First().diaChi = tSua.diaChi;
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
