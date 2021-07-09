using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DeTaiPTUD_PhongTro
{
    public class clsQLPhieuThue:clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsQLPhieuThue()
        {
            dt = LayDuLieu();
        }
        public IEnumerable<tblPhieuThue> LayDuLieuPhieuThue(string strMaPhong)
        {
            var result = dt.tblPhieuThues.Where(x => x.maPhong.Equals(strMaPhong) && x.ngayTra == null).ToList();
            return result;

        }
        public int LayMaPhieuThueDauTien(string strMaPhong)
        {
            tblPhieuThue pt = (from n in dt.tblPhieuThues
                               where n.maPhong.Equals(strMaPhong) && n.ngayTra == null
                               select n).FirstOrDefault();
            return pt.maPhieuThue;

        }

        public void TaoPhieuThue(tblPhieuThue pt)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblPhieuThues.InsertOnSubmit(pt);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public IEnumerable<LayDSPhieuThueTheoPhongResult> LayDSPhieuThue(string strMaPhong)
        {
            return dt.LayDSPhieuThueTheoPhong(strMaPhong);
        }
    }
}
